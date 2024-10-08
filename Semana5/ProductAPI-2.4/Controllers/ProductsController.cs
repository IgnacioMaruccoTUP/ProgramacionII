﻿using Microsoft.AspNetCore.Mvc;
using ProductAPI.Models;
using ProductAPI.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IAplication application;

        public ProductsController()
        {
            application = new ProductService();
        }
        // GET: api/<ProductsController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(application.GetProducts());
        }

        // GET api/<ProductsController>/5
        [HttpGet("{code}")]
        public IActionResult GetById(int code)
        {
            var product = application.GetProduct(code);
            if (product == null)
                return NotFound("No se encontró el producto");
            return Ok(product);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public IActionResult PostProduct(Product producto)
        {
            var result = application.AddOrUpdateProduct(producto);
            return Ok(result);
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{code}")]
        public IActionResult DeleteProduct(int code)
        {
            return Ok(application.DeleteProduct(code));
        }
    }
}
