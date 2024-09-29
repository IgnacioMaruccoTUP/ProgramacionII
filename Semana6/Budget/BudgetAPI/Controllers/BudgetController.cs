using BudgetData.Domain;
using BudgetData.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BudgetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BudgetController : ControllerBase
    {
        private readonly BudgetManager _service;

        public BudgetController()
        {
            _service= new BudgetManager();
        }
        // GET: api/<BudgetController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_service.GetBudgets());
            }
            catch (Exception)
            {

                return StatusCode(500, "");
            }
            
        }

        // GET api/<BudgetController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_service.GetBudgetsById(id));
        }

        // POST api/<BudgetController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BudgetController>/5
        [HttpPut]
        public IActionResult Put([FromBody] Budget p)
        {
            try
            {
                if (_service.GetBudgetsById(p.Id) == null) return NotFound("Tu budget esta en otro castillo");

                if (_service.UpdateBudget(p))
                {
                    return Ok("Presupuesto actualizado");
                }
                else
                {
                    return BadRequest("Presupuesto no actualizado"); 
                }
                
            }
            catch (Exception)
            {

                return StatusCode(500, "MUERTEEEE");
            }
            
        }

        // DELETE api/<BudgetController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
