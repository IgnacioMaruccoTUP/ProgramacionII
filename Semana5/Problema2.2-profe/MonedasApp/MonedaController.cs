using Microsoft.AspNetCore.Mvc;
using MonedasApp.Models;

namespace MonedasApp
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonedaController : Controller
    {
        private static readonly  List<Moneda> lstMoneda = new List<Moneda>();
  
        [HttpGet]
        public IActionResult GetMonedas()
        {
            if (lstMoneda.Count == 0)
            {
                return NotFound("No se encontraron resultados.");
                //devolver 404
            }
            return Ok(lstMoneda);
        }
        [HttpGet("{name}")]
        public IActionResult GetMonedaName(string name)
        {
            var moneda = lstMoneda
                .Find(moneda => moneda.Nombre == name);

            if (moneda == null)
            {
                return NotFound("No se encontraron resultados.");
                //devolver 404
            }
            return Ok(moneda);
        }
        [HttpPost]
        public IActionResult postMoneda(Moneda moneda)
        {
            try
            {
                if(moneda != null)
                {
                    lstMoneda.Add(moneda);
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                //internal Server
                return StatusCode(500,ex.Message);
                throw;
            }
        }
    }
}
