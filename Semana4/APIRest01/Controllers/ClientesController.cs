using APIRest01.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIRest01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        //Atributo de clase: se carga 1 vez y se mantiene mientras la WebAPI esté activa
        static readonly List<Cliente> lst = new List<Cliente>();

        [HttpGet ]
        public IActionResult Get()
        {
            lst.Add(new Cliente() { Codigo = 1, Nombre = "TEST" });
            return Ok(lst);

        }
    }
}
