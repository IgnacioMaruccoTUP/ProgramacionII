using DataAPI.Data.Models;
using DataAPI.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EFServiciosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurnoController : ControllerBase
    {
        private readonly ITurnoService _turnoService;
        public TurnoController(ITurnoService turnoService)
        {
            _turnoService = turnoService;
        }
        // GET: api/<TurnoController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _turnoService.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno");
            }
        }

        // GET api/<TurnoController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var oTurno = await _turnoService.GetById(id);
                if (oTurno == null)
                    return NotFound("No se encontro el turno con el id especificado.");
                return Ok(oTurno);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno");
            }
        }

        // POST api/<TurnoController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TTurno oTurno)
        {
            try
            {
                //Fecha default (un dia despues)
                if (oTurno.Fecha == default)
                    oTurno.Fecha = DateTime.Now.AddDays(1);

                //Maximo 45 dias despues
                if (oTurno.Fecha > DateTime.Now.AddDays(45))
                    return BadRequest("Fecha incorrecta.");

                //Al menos un servicio
                if (oTurno.TDetallesTurnos.Count <= 0)
                    return BadRequest("Ingresar al menos un servicio.");

                //Evitar servicios duplicados
                var serviciosDuplicados = oTurno.TDetallesTurnos
                                            .GroupBy(detalle => detalle.IdServicio)
                                            .Any(grupo => grupo.Count() > 1);

                if (serviciosDuplicados)
                    return BadRequest("No se puede registrar el mismo servicio más de una vez en el mismo turno.");

                //Evitar dar turno mismo dia y hora (logica en repositorio)
                if (!await _turnoService.Save(oTurno))
                    return StatusCode(500, "La fecha y hora ya estan ocupadas por otro turno.");

                return Ok("Turno registrado exitosamente.");
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno");
            }
        }

        // PUT api/<TurnoController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] TTurno oTurno)
        {
            try
            {
                var turnoToUpdate = await _turnoService.GetById(oTurno.Id);
                if (turnoToUpdate == null)
                    return NotFound("No se encontro el turno con el id especificado.");
                if (!await _turnoService.Update(oTurno))
                    return StatusCode(500, "Ocurrio un error interno");
                return Ok("Se actualizo correctamente el turno.");
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno");
            }
        }

        // DELETE api/<TurnoController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, string motivo)
        {
            try
            {
                var oTurno = await _turnoService.GetById(id);
                if (oTurno == null)
                    return NotFound("No se encontro el turno con el id especificado.");
                if (!await _turnoService.Delete(id, motivo))
                    return StatusCode(500, "Ocurrio un error interno");
                return Ok("Se registro la baja del turno exitosamente.");
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno");
            }
        }
    }
}
