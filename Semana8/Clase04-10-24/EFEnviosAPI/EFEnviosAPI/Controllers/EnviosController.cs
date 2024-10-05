using EFEnviosAPI.Data.Models;
using EFEnviosAPI.Data.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EFEnviosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnviosController : ControllerBase
    {
        private readonly IEnviosService _enviosService;
        public EnviosController(IEnviosService enviosService)
        {
            _enviosService = enviosService;
        }
        // GET: api/<EnviosController>
        [HttpGet]
        public IActionResult Get([FromQuery] DateTime fecha1, DateTime fecha2)
        {
            try
            {
                if (fecha1 > fecha2)
                    return BadRequest("Ingresar fechas validas. La fecha1 debe ser anterior a la fecha2.");
                return Ok(_enviosService.RecuperarEntreFechas(fecha1, fecha2));
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno");
            }
        }

        // GET api/<EnviosController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<EnviosController>
        [HttpPost]
        public IActionResult Post([FromBody] TEnvio oEnvio)
        {
            try
            {
                if (!oEnvio.IsValid())
                    return BadRequest("Los datos ingresados no son validos o estan incompletos.");
                if (!_enviosService.Registrar(oEnvio))
                    return StatusCode(500, "Ocurrio un error interno.");
                return Ok("Envio registrado exitosamente");
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno");
            }
        }

        // PUT api/<EnviosController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<EnviosController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            { 
                var envioToDelete = _enviosService.RecuperarPorId(id);
                if (envioToDelete == null)
                    return NotFound($"El envio con el id especificado ID: <{id}> no se encuentra.");
            if (!_enviosService.RegistrarBaja(id))
                return StatusCode(500, "Ocurrio un error interno");
            return Ok($"Se dio de baja exitosamente el envio con el id especificado ID: <{id}>.");
                    
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno");
            }
        }
    }
}
