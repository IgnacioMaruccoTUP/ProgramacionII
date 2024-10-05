using Microsoft.AspNetCore.Mvc;
using ParcialWebApi.Services.Contracts;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ParcialWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CriptomonedasController : ControllerBase
    {
        private readonly ICriptomonedaService _criptomonedaService;
        public CriptomonedasController(ICriptomonedaService criptomonedaService)
        {
            _criptomonedaService = criptomonedaService;
        }
        // GET: api/<CriptomonedasController>
        [HttpGet]
        public IActionResult GetByCategory(int id)
        {
            try
            {
                return Ok(_criptomonedaService.GetByCategory(id));
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno.");
            }
        }


        // PUT api/<CriptomonedasController>/5
        [HttpPut]
        public IActionResult Put([FromQuery] string simbolo, [FromQuery] float valorActual, [FromQuery] DateTime fecha)
        {
            try
            {
                var criptoToUpdate = _criptomonedaService.GetBySymbol(simbolo);
                if (criptoToUpdate == null)
                    return NotFound("No se encontro la criptomoneda especificada.");

                var aux = DateTime.Now.AddDays(-1);
                if(fecha <= aux)
                    return BadRequest("Fecha incorrecta");


                if (!_criptomonedaService.ActualizarValor(simbolo, valorActual, fecha))
                    return StatusCode(500, "Ocurrio un error interno.");
                return Ok("Se actualizo el valor de la criptomoneda.");
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno.");
            }
        }

        // DELETE api/<CriptomonedasController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var criptoToDelete = _criptomonedaService.GetById(id);
                if (criptoToDelete == null)
                    return NotFound("No se encontro la criptomoneda especificada.");
                if (!_criptomonedaService.Delete(id))
                    return StatusCode(500, "Ocurrio un error interno.");
                return Ok("Se registro la baja de la criptomoneda.");
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno.");
            }
        }
    }
}
