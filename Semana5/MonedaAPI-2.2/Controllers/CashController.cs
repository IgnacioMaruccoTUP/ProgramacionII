using Microsoft.AspNetCore.Mvc;
using MonedaAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MonedaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CashController : ControllerBase
    {
        private static readonly List<Moneda> listaMonedas = new List<Moneda>();
        // GET: api/<CashController>
        [HttpGet]
        public IActionResult Get()
        {
            //Permite obtener los datos de todas las monedas
            if (listaMonedas.Count == 0)
            {
                return NotFound("No se encontraron resultados.");
                //devolver 404
            }
            return Ok(listaMonedas);
        }

        // GET api/<CashController>/5               api/cash/Dolar
        [HttpGet("{nombre}")]
        public IActionResult Get(string nombre)
        {
            //permite obtener los datos de una moneda especifica
            foreach (Moneda x in listaMonedas)
            {
                if(x.Nombre.Equals(nombre))
                    return Ok(x);
            }
            return NotFound("No se encontró la moneda.");
        }

        // POST api/<CashController>
        [HttpPost]
        public IActionResult Post(Moneda oMoneda)
        {
            //permite registrar datos de una moneda
            try
            {
                if (oMoneda != null)
                {
                    listaMonedas.Add(oMoneda);
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
                return StatusCode(500, ex.Message);
                throw;
            }
        }
    }
}
