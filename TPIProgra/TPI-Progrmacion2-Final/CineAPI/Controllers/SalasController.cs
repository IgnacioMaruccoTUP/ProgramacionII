
using CIneData.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CineAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalasController : ControllerBase
    {
        private ISalaRepository _salaRepository;

        public SalasController(ISalaRepository salaRepository)
        {
            _salaRepository = salaRepository;
        }

        [HttpGet]
        public async Task<IActionResult> RecuperarTodasSalas()
        {
            try
            {
                return Ok(await _salaRepository.RecuperarTodasSalas());
            }
            catch (Exception)
            {
                return StatusCode(500, new { message = "Error interno" });
            }
        }
    }
}
