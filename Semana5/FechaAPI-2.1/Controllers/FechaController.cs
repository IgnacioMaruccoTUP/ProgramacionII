using FechaAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FechaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FechaController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new Fecha()); //El objeto new Fecha() sera enviado como Response Body, con el codigo 200 (correcto, exitoso)
        }
    }
}
