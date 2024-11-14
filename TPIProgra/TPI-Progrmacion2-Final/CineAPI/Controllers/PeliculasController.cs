using CIneData.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CineAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculasController : ControllerBase
    {
        private readonly IPeliculaRepository _peliculaRepository;
        public PeliculasController(IPeliculaRepository peliculaRepository)
        {
            _peliculaRepository = peliculaRepository;
        }
        // GET: api/<PeliculaController>
        [HttpGet]
        public async Task<IActionResult> RecuperarTodasPeliculas()
        {
            try
            {
                return Ok(await _peliculaRepository.RecuperarTodasPeliculas());
            }
            catch (Exception)
            {
                return StatusCode(500, new { message = "Error interno" });
            }
        }

        [HttpGet]
        [Route("PelisCarterela")]

        public async Task<IActionResult> GetCartelera()
        {
            return Ok(await _peliculaRepository.GetPelisCartelera());
        }




    }
}
