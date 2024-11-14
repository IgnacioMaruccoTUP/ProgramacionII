using CIneData.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CineAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntradasController : ControllerBase
    {
        IEntradaRepository _repository;
        public EntradasController(IEntradaRepository repository)
        {
            _repository = repository;
        }



        [HttpGet]
        [Route("EntradasByFuncion")]

        public async Task<IActionResult> GetEntradasByFunc([FromQuery] int idFuncion)
        {
            return Ok(await _repository.GetEntradasByFuncion(idFuncion));
        }

        [HttpGet("reserva/{idReserva}")]
        public async Task<IActionResult> GetEntradasPorReserva(int idReserva)
        {
            return Ok(await _repository.GetEntradasPorReserva(idReserva));
        }
        

    }

}   
