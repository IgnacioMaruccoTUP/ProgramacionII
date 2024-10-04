using EFBancoAPI.Data.Models;
using EFBancoAPI.Data.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EFBancoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuentasController : ControllerBase
    {
        private readonly ICuentaService _cuentaService;
        public CuentasController(ICuentaService cuentaService)
        {
            _cuentaService = cuentaService;
        }
        // GET: api/<CuentasController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_cuentaService.RecuperarCuentas());
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno.");
            }
        }

        // GET api/<CuentasController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var oCuenta = _cuentaService.RecuperarCuentaPorId(id);
                if (oCuenta == null)
                    return NotFound($"No se encontro la cuenta especificada por el id: <{id}>");
                return Ok(oCuenta);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno.");
            }
        }

        // POST api/<CuentasController>
        [HttpPost]
        public IActionResult Post([FromBody] Cuenta oCuenta)
        {
            try
            {
                if (!oCuenta.IsValid())
                    return BadRequest("Datos ingresados incorrectos o incompletos. Vuelva a intentarlo.");
                
                oCuenta.Id = 0;
                if (_cuentaService.AgregarCuenta(oCuenta))
                    return Ok("Cuenta registrada exitosamente.");
                return StatusCode(500, "Ocurrio un error interno");
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno.");
            }
        }

        // PUT api/<CuentasController>/5
        [HttpPut]
        public IActionResult Put([FromBody] Cuenta oCuenta)
        {
            try
            {
                if (!oCuenta.IsValid())
                    return BadRequest("Datos ingresados incorrectos o incompletos. Vuelva a intentarlo.");

                if (_cuentaService.ActualizarCuenta(oCuenta))
                    return Ok("Cuenta actualizada exitosamente.");

                return StatusCode(500, "Ocurrio un error interno");
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno.");
            }
        }

        // DELETE api/<CuentasController>/5
        [HttpDelete("{id}/{motivoBaja}")]
        public IActionResult Delete(int id,string motivoBaja)
        {
            try
            {
                var oCuenta = _cuentaService.RecuperarCuentaPorId(id);
                if (oCuenta == null)
                    return NotFound($"No se encontro la cuenta especificada por el id: <{id}>");

                if (!_cuentaService.DesactivarCuenta(id, motivoBaja))
                    return StatusCode(500, "Ocurrio un error interno.");

                return Ok("Cuenta desactivada exitosamente.");
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno.");
            }
        }

        [HttpGet("filtros/entre-anios")]
        public IActionResult Get(int year1, int year2)
        {
            try
            {
                return Ok(_cuentaService.RecuperarEntre(year1, year2));
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno.");
            } 
        }

        [HttpGet("filtros/ultimos-{days}-dias")]
        public IActionResult Get(int days)
        {
            try
            {
                return Ok(_cuentaService.RecuperarMovimientoUltimosNDias(days));
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno.");
            }
        }
        [HttpGet("filtros/cbu")]
        public IActionResult Get(string cbu)
        {
            try
            {
                return Ok(_cuentaService.RecuperarConCbu(cbu));
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno.");
            }
        }
    }
}
