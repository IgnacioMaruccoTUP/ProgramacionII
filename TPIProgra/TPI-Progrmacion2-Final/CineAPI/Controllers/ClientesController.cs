using CIneData.Models;
using CIneData.Repositories.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CineAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        IClienteRepository _repo;
        public ClientesController(IClienteRepository repo)
        {
            _repo = repo;
        }
        // GET: api/<ClientesController>
        //[Authorize(Policy = "AdminOnly")]
        [HttpGet]
        public async Task<IActionResult> GetClientes()
        {
            try
            {
                var res = await _repo.GetAll();
                return Ok(res);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        // GET api/<ClientesController>/5
        [HttpPost]
        public async Task<IActionResult> RegistrarCliente([FromBody] Cliente cliente)
        {
            try
            {
                var res = await _repo.Create(cliente);
                return Ok(res);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

    }
}
