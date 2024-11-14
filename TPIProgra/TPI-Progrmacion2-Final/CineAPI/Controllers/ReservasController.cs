using CIneData.Models;
using CIneData.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CineAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservasController : ControllerBase
    {
        private readonly IReservaRepository _repository;

        public ReservasController(IReservaRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("cliente/{idCliente}")]
        public async Task<IActionResult> RecuperarReservasPorCliente([FromRoute]int idCliente = 0 )
        {
            try
            {
                var lst = await _repository.RecuperarReservasPorCliente(idCliente);
                return Ok(lst);
                
            }
            catch (Exception)
            {
                return StatusCode(500, "Error al recuperar reservas");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AgregarReserva([FromBody] Reserva reserva)
        {
            try
            {
                await _repository.CrearReserva(reserva);
                if (reserva == null)
                {
                    return BadRequest("No se pudo crear la reserva. Por favor, intente nuevamente.");
                }
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }

        //reservada
        //{
        //"idFormaPago": 1,
        //"idCliente": 1,
        //"fechaPago": "2024-11-10T15:42:04.047Z"
        //}

        //No reservada 
        //{
        //  "idCliente": 
        //}

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarReserva(int id)
        {
            try
            {
                if (await _repository.EliminarReserva(id))
                    return Ok(new { message = "Se dio de baja la reserva" });
                else
                    return NotFound(new { message = "No se encontro la reserva" });

            }
            catch (Exception)
            {
                return StatusCode(500, "Ocurrió un problema al interactuar con la base de datos. Por favor, intente nuevamente.");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> RecuperarReserva(int id)
        {
            try
            {
                var oReserva = await _repository.RecuperarReserva(id);
                if (oReserva != null)
                    return Ok(oReserva);
                else
                    return NotFound(new { message = $"No se encontró la reserva con el ID ingresado. ID: <{id}>" });

            }
            catch (Exception)
            {
                return StatusCode(500, "Ocurrió un problema al interactuar con la base de datos. Por favor, intente nuevamente.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarReserva(int id, [FromBody] Reserva oReserva)
        {
            try
            {
                var reserva = await _repository.RecuperarReserva(id);

                if (reserva == null)
                    return NotFound(new { message = "La reserva no fue encontrada." });
                oReserva.IdReserva = id;
                var resultado = await _repository.ActualizarReserva(id, oReserva);

                if (resultado)
                    return Ok(new { message = "Reserva actualizada correctamente." });
                else
                    return BadRequest(new { message = "No se pudo actualizar la reserva." });
            }
            catch (Exception)
            {
                return StatusCode(500, new { message = "Error interno" });
            }
        }
    
    }
}
