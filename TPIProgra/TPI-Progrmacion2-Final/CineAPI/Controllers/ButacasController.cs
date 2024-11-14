using CIneData.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CineAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ButacasController : ControllerBase
    {
        IButacaRepository _repository;
        public ButacasController( IButacaRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("ButacasOcupadas")]

        public async Task<IActionResult> GetButacasOcupadas([FromQuery] int idFuncion)
        {
            return Ok(await _repository.GetButacasByFuncionOcupadas(idFuncion));
        }

        [HttpGet]
        [Route("ButacasByFuncion")]

        public async Task<IActionResult> GetButacasByFunc([FromQuery] int idFuncion)
        {
            return Ok(await _repository.GetButacasByFuncion(idFuncion));
        }

    }
}
