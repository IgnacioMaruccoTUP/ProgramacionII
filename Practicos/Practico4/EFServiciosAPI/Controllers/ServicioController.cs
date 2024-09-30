using DataAPI.Data.Services.Contracts;
using DataAPI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EFServiciosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicioController : ControllerBase
    {
        private readonly IServicioService _servicioService;
        public ServicioController(IServicioService servicioService)
        {
            _servicioService = servicioService;
        }
        // GET: api/<ServicioController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _servicioService.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno");
            }
        }

        // GET api/<ServicioController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var oServicio = await _servicioService.GetById(id);
                if (oServicio != null)
                    return Ok(oServicio);
                else
                    return NotFound($"No se encontró el servicio con el ID ingresado. ID: <{id}>");
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno");
            }
        }
        //onSale = N o S, strings.
        [HttpGet("Filters")]
        public async Task<IActionResult> GetByFilters(string? name, string? onSale)
        {
            try
            {
                return Ok(await _servicioService.GetByFilters(name, onSale));
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno");
            }
        }

        private bool IsValid(TServicio oServicio)
        {
            if (!string.IsNullOrWhiteSpace(oServicio.Nombre) && !string.IsNullOrWhiteSpace(oServicio.EnPromocion)
                && oServicio.Costo > 0 && oServicio.Id > 0)
            {
                return true;
            }
            else
                return false;
        }

        // POST api/<ServicioController>
        [HttpPost]
        public async Task<IActionResult> PostService([FromBody] TServicio oServicio)
        {
            try
            {
                if (IsValid(oServicio))
                {
                    await _servicioService.Save(oServicio);
                    return Ok("Servicio registrado exitosamente.");
                }
                else
                {
                    return BadRequest("No se pudo registrar servicio. Chequear datos ingresados.");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno");
            }
        }

        // PUT api/<ServicioController>/5
        [HttpPut]
        public async Task<IActionResult> PutService([FromBody] TServicio oServicio)
        {
            try
            {
                if (IsValid(oServicio))
                {
                    var serviceToDelete = await _servicioService.GetById(oServicio.Id);
                    if (serviceToDelete == null)
                        return NotFound("No se encuentra el servicio que intenta actualizar");
                    else if (await _servicioService.Update(oServicio))
                        return Ok("Servicio actualizado exitosamente");
                    else
                        return BadRequest("No se pudo actualizar el servicio");
                }
                else
                    return BadRequest("No se pudo actualizar el servicio. Chequear datos ingresados.");
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno");
            }
        }

        // DELETE api/<ServicioController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, string motivo)
        {
            try
            {
                if (await _servicioService.Delete(id, motivo))
                    return Ok("Se dio de baja el servicio");
                else
                    return NotFound("No se encontro el servicio");
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno");
            }
        }
    }
}
