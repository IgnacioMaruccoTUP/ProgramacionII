using Microsoft.AspNetCore.Mvc;
using ProduccionBack.Entities;
using ProduccionBack.Services;

namespace ProduccionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenProduccionController : ControllerBase
    {
        private IProduccionService service;

        public OrdenProduccionController()
        {
            service = new ProduccionService();
        }

        // GET: api/<OrdenProduccionController>
        [HttpGet("componentes")]
        public IActionResult Get()
        {
            return Ok(service.ConsultarComponentes());
        }

        [HttpGet("ordenes")]    //servidor:puerto/api/OrdenProduccion/ordenes?fecha='algo'&estado='algo'
        public IActionResult GetOrdenes([FromQuery] DateTime? fechaConsulta, [FromQuery] string? estadoConsulta)
        {
            try
            {
                var lst = service.ConsultarOrdenes(fechaConsulta, estadoConsulta);
                if (lst.Count == 0)
                    return NotFound("No se encontraron ordenes de produccion para los filtros indicados");
                return Ok(lst);
            }
            catch (Exception)
            {
                return StatusCode(500, "No se pudieron consultar las ordenes de produccion");
            }
        }

        [HttpDelete("ordenes/{nro}")]
        public IActionResult DeleteOrden(int nro)
        {
            try
            {
                if (service.CancelarOrden(nro))
                    return Ok($"Orden de produccion <{nro}> cancelada");
                else
                    return NotFound("Orden no encontrada o en un estado incorrecto");
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno");
            }
            
        }




        // POST api/<OrdenProduccionController>
        [HttpPost]
        public IActionResult Post([FromBody] OrdenProduccion orden)
        {
            try { 
                if(orden == null || !service.EsOrdenValida(orden))
                {
                    return BadRequest("Se esperaba una orden de producción completa");
                }
                if (service.RegistrarProduccion(orden))
                    return Ok("Orden registrada con éxito!");
                else
                    return StatusCode(500, "No se pudo registrar la orden!");
            }
            catch (Exception )
            {
                return StatusCode(500, "Error interno, intente nuevamente!");
            }
        }
    }
}
