using Microsoft.AspNetCore.Mvc;
using ModeloParcialWebApi.Models;
using ModeloParcialWebApi.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ModeloParcialWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculasController : ControllerBase
    {
        private IPeliculaRepository _repository;
        private IGeneroRepository _generosRepo;

        public PeliculasController(IPeliculaRepository repository ,IGeneroRepository repo)
        {
            _repository = repository;
            _generosRepo = repo;
        }


       /* public void SetGenerosRepo(IGeneroRepository repo)
        {
            _generosRepo = repo;
        }*/

        [HttpGet("/api/Generos")]
        public IActionResult GetGeneros()
        {
            try
            {
                return Ok(_generosRepo.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(500, "Ha ocurrido un error interno. Intente nuevamente luego!");
            }
        }

        // GET: api/<PeliculasController>
     
        // GET: api/<PeliculasController>
        [HttpGet("{genero}")]
        public IActionResult GetByGenero(int genero)
        {
            try
            {
                return Ok(_repository.GetByGenero(genero));
            }
            catch (Exception)
            {
                return StatusCode(500, "Ha ocurrido un error interno. Intente nuevamente luego!");
            }
        }




        [HttpGet("Entre")]
        public IActionResult GetByYears([FromQuery] int anioDesde, [FromQuery]  int anioHasta)
        {
            try
            {
                if (anioHasta < anioDesde)
                    return BadRequest("Periodo incorrecto!");
                return Ok(_repository.GetAllByYears(anioDesde, anioHasta));
            }
            catch (Exception)
            {
                return StatusCode(500, "Ha ocurrido un error interno. Intente nuevamente luego!");
            }
        }



        // POST api/<PeliculasController>
        [HttpPost]
        public IActionResult Post([FromBody] Pelicula pelicula)
        {
            try
            {
                if (IsValid(pelicula))
                {
                    _repository.Create(pelicula);
                    return Ok("Pelicula registrada con éxito!");
                }
                else
                {
                    return BadRequest("Debe completar los campos obligatorios!");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Ha ocurrido un error interno. Intente nuevamente luego!");
            }
        }

        private bool IsValid(Pelicula pelicula)
        {
            return !string.IsNullOrEmpty(pelicula.Titulo) && !string.IsNullOrEmpty(pelicula.Director) && pelicula.Anio > 0 && pelicula.IdGenero > 0;
        }

        // PUT api/<PeliculasController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id)
        {
            try
            {
                if (_repository.Update(id))
                {
                    return Ok("Pelicula fuera de cartelera!");
                }
                else
                {
                    return NotFound("Pelicula no encontrada!");
                }             
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (_repository.Delete(id))
                    return Ok("Se ha dado de baja la película correctamente");
                else
                    return NotFound($"La película con id {id} no existe");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno");
            }
        }



    }
}