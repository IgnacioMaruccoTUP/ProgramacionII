using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Repositories.Contracts;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private IRolRepository _repository;

        public RolController(IRolRepository repository)
        {
            _repository = repository;
        }
        // GET: api/<RolController>
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

        // GET api/<RolController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var oRol = _repository.GetById(id);
                if(oRol != null)
                    return Ok(oRol);
                else
                    return NotFound("No se encontro el rol especificado.");
                
            }
            catch (Exception)
            {
                return StatusCode(500, "MUERTE!");
            }
        }

        // POST api/<RolController>
        [HttpPost]
        public IActionResult Post([FromBody] Rol oRol)
        {
            try
            {
                _repository.Create(oRol);
                return Ok("Rol registrado");
            }
            catch (Exception)
            {
                return StatusCode(500, "MUERTE!");
            }
        }

        // PUT api/<RolController>/5
        [HttpPut]
        public IActionResult Put([FromBody] Rol oRol)
        {
            try
            {
                _repository.Update(oRol);
                return Ok("Rol actualizado exitosamente");
            }
            catch (Exception)
            {
                return StatusCode(500, "MUERTE!");
            }
        }

        // DELETE api/<RolController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _repository.Delete(id);
                return Ok("Rol eliminado.");
            }
            catch (Exception)
            {
                return StatusCode(500, "MUERTE!");
            }
        }
    }
}
