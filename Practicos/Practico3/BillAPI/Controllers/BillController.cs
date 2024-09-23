using DataAPI.Entities;
using DataAPI.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BillAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillController : ControllerBase
    {
        private IBillService _service;

        public BillController()
        {
            _service = new BillService();
        }

        // GET: api/<BillController>
        [HttpGet("bills")]
        public IActionResult GetBills([FromQuery] DateTime? dateQuery, [FromQuery] int? paymentTypeQuery)
        {
            try
            {
                var billList = _service.GetBills(dateQuery, paymentTypeQuery);
                if (billList.Count == 0)
                    return NotFound("No se encontraron facturas para los filtros indicados");
                return Ok(billList);
            }
            catch (Exception)
            {
                return StatusCode(500, "ERROR INTERNO");
            }
            //try
            //{
            //    return Ok(_service.GetAllBills());
            //}
            //catch (Exception)
            //{
            //    return StatusCode(500, "Error interno");
            //}

        }

        // GET api/<BillController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                Bill oBill = _service.GetBillById(id);
                if (oBill != null)
                    return Ok(oBill);
                else
                    return NotFound($"No existe una factura con el id <{id}> especificado.");
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno");
            }
        }

        // POST api/<BillController>
        [HttpPost]
        public IActionResult Post([FromBody] Bill oBill)
        {
            try
            {
                if (_service.SaveBill(oBill))
                    return Ok("Factura registrada con exito");
                else
                    return BadRequest("Hubo un error en la carga de datos");
            }
            catch (Exception)
            {

                return StatusCode(500, "PROBLEMAS");
            }
        }

        // PUT api/<BillController>/5
        [HttpPut]
        public IActionResult Put([FromBody] Bill oBill)
        {
            try
            {
                if (_service.GetBillById(oBill.Code) == null)
                    return NotFound("Tu factura esta en otro castillo.");

                if (_service.EditBill(oBill))
                {
                    return Ok("Factura actualizada.");
                }
                else
                {
                    return BadRequest("Factura no actualizada.");
                }

            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno.");
            }
        }
    }
}
