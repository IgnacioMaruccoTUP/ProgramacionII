using CIneData.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CineAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormaPagosController : ControllerBase
    {
        private readonly IFormaPagoRepositoty _repository;

        public FormaPagosController(IFormaPagoRepositoty repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> RecuperarTodasFormasPago()
        {
            try
            {
                return Ok(await _repository.RecuperarFormasPago());
            }
            catch (Exception)
            {
                return StatusCode(500, new { message = "Error interno" });
            }
        }
    }
}
