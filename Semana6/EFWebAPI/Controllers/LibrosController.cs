using EFWebAPI.Data.Models;
using EFWebAPI.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EFWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController : ControllerBase
    {
        private ILibroRepository _repository;

        public LibrosController(ILibroRepository repository)
        {
            _repository = repository;
        }




        // GET: api/<LibrosController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_repository.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno");
            }
        }

        // GET api/<LibrosController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LibrosController>
        [HttpPost]
        public IActionResult Post([FromBody] Libro oLibro)
        {
            try
            {
                if (IsValid(oLibro))
                {
                    _repository.Create(oLibro);
                    return Ok("Libro insertado");
                }
                else
                {
                    return BadRequest("Los datos no son correctos o incompletos.");
                }
            }
            catch (Exception)
            {

                return StatusCode(500, "Error interno.");
            }
        }
        private bool IsValid(Libro oLibro)
        {
            return !string.IsNullOrWhiteSpace(oLibro.Isbn) && !string.IsNullOrWhiteSpace(oLibro.Nombre) &&
                !string.IsNullOrWhiteSpace(oLibro.FechaPublicacion) && oLibro.Autor != 0;
        }
        // PUT api/<LibrosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LibrosController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
               _repository.Delete(id);
                return Ok("Libro borrado.");
            }
            catch (Exception)
            {

                return StatusCode(500, "Error interno.");
            }
        }
    }
}
