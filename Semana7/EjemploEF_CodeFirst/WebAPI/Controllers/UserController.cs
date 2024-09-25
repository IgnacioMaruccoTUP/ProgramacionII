using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Repositories.Contracts;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserRepository _repository;

        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }
        // GET: api/<UserController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_repository.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(500, "MUERTE!");
            }
        }


        [HttpGet("rol/{id}")]
        public IActionResult GetByFilters(int id)
        {
            try
            {
                return Ok(_repository.GetByFilters(id));
            }
            catch (Exception)
            {
                return StatusCode(500, "MUERTE!");
            }
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserController>
        [HttpPost]
        public IActionResult Post([FromBody] User oUser)
        {
            try
            {
                _repository.Save(oUser);
                return Ok($"Se registro exitosamente el usuario.");
            }
            catch (Exception)
            {
                return StatusCode(500, "MUERTE!");
            }
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
