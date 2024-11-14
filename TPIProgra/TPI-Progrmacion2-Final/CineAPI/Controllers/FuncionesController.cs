using CIneData.Models;
using CIneData.Repositories.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CineAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionesController : ControllerBase
    {
        private readonly IFuncionRepository _funcionRepository;
        public FuncionesController(IFuncionRepository funcionRepository)
        {
            _funcionRepository = funcionRepository;
        }

        // GET: api/<FuncionController>
        [Authorize(Policy = "AdminOnly")]
        [HttpGet]
        public async Task<IActionResult> RecuperarTodasFunciones()
        {
            try
            {
                return Ok(await _funcionRepository.RecuperarTodasFunciones());
            }
            catch (Exception)
            {
                return StatusCode(500, new { message = "Error interno" });
            }
        }
        [Authorize(Policy = "AdminOnly")]
        [HttpGet("GetByFilters")]

        public async Task<IActionResult> GetByFilters([FromQuery] int? sala, [FromQuery] string? pelicula, [FromQuery] DateTime? fechaDesde,
            [FromQuery] DateTime? fechaHasta, [FromQuery] decimal? precioDesde, [FromQuery] decimal? precioHasta)
        {
            try
            {
                return Ok(await _funcionRepository.RecuperarFuncionesFiltradas(sala, pelicula, fechaDesde, fechaHasta, precioDesde, precioHasta));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error interno" });
            }
        }


        // GET api/<FuncionController>/5
        [Authorize(Policy = "AdminOnly")]
        [HttpGet("{id}")]
        public async Task<IActionResult> RecuperarFuncionPorId(int id)
        {
            try
            {
                var oFuncion = await _funcionRepository.RecuperarFuncionPorId(id);
                if (oFuncion != null)
                    return Ok(oFuncion);
                else
                    return NotFound(new { message = $"No se encontró la funcion con el ID ingresado. ID: <{id}>" });
            }
            catch (Exception)
            {
                return StatusCode(500, new { message = "Error interno" });
            }
        }
        // POST api/<FuncionController>
        [Authorize(Policy = "AdminOnly")]
        [HttpPost]
        public async Task<IActionResult> AgregarFuncion([FromBody] Funcione oFuncion)
        {
            try
            {
                var hayConflicto = await _funcionRepository.EncontrarConflicto(oFuncion.Horario.Value, oFuncion.IdPelicula.Value, oFuncion.IdSala.Value);

                if (hayConflicto[0].Conflicto == 1)
                    return BadRequest(new { message = "Ya existe una funcion durante ese horario." });

                if (oFuncion.Horario < DateTime.Now)
                    return BadRequest(new { message = "La fecha de la función no puede ser en el pasado." });

                await _funcionRepository.AgregarFuncion(oFuncion);
                return Ok(new { message = "Funcion registrada exitosamente." });
                //if (IsValid(oFuncion))
                //{


                //}
                //else
                //{
                //    return BadRequest(new { message = "No se pudo registrar funcion. Chequear datos ingresados." });
                //}
            }
            catch (Exception)
            {
                return StatusCode(500, new { message = "Error interno" });
            }
        }


        // PUT api/<FuncionController>/5
        [Authorize(Policy = "AdminOnly")]
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarFuncion(int id, [FromBody] Funcione oFuncion)
        {
            try
            {
                var hayConflicto = await _funcionRepository.EncontrarConflicto(oFuncion.Horario.Value, oFuncion.IdPelicula.Value, oFuncion.IdSala.Value, oFuncion.IdFuncion);

                if (hayConflicto[0].Conflicto == 1)
                    return BadRequest(new { message = "Ya existe una funcion durante ese horario." });

                if (oFuncion.Horario < DateTime.Now)
                    return BadRequest(new { message = "La fecha de la función no puede ser en el pasado." });

                var funcionToUpdate = await _funcionRepository.RecuperarFuncionPorId(oFuncion.IdFuncion);
                if (funcionToUpdate == null)
                    return NotFound(new { message = "No se encuentra la funcion que intenta actualizar." });
                else if (await _funcionRepository.ActualizarFuncion(oFuncion))
                    return Ok(new { message = "Funcion actualizada exitosamente" });
                else
                    return BadRequest(new { message = "No se pudo actualizar la funcion." });
                //if (IsValid(oFuncion))
                //{

                //}
                //else
                //    return BadRequest("No se pudo actualizar la funcion. Chequear datos ingresados.");
            }
            catch (Exception)
            {
                return StatusCode(500, new { message = "Error interno" });
            }
        }
        [Authorize(Policy = "AdminOnly")]
        [HttpDelete("{id}")]
        
        public async Task<IActionResult> EliminarFuncion(int id)
        {
            try
            {
                if (await _funcionRepository.EliminarFuncion(id))
                    return Ok(new { message = "Se dio de baja la funcion" });
                else
                    return NotFound(new { message = "No se encontro la funcion" });
            }
            catch (Exception)
            {
                return StatusCode(500, new { message = "Error interno" });
            }
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpGet("/GetByName")]

        public async Task<IActionResult> GetByName([FromQuery] string? nombre, [FromQuery] DateTime? fecha1, [FromQuery] DateTime? fecha2)
        {
            try
            {
                if (nombre == null && fecha1 == null && fecha2 == null)
                {
                    return BadRequest("Ingrese al menos un dato");
                }

                var funcionesEncontradas = await _funcionRepository.GetFunctionsByFilters(nombre, fecha1, fecha2);
                if (funcionesEncontradas != null)
                {
                    return Ok(funcionesEncontradas);
                }
                return NotFound("No se han encontrado funciones");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        
        [HttpGet("pelicula/{idPelicula}")]
        public async Task<IActionResult> GetById( int idPelicula)
        {
            try
            {
                var funcionesEncontradas = await _funcionRepository.GetFuncionesPorPelicula(idPelicula);
                if (funcionesEncontradas != null)
                {
                    return Ok(funcionesEncontradas);
                }
                return NotFound("No se han encontrado funciones");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }



    }
}
