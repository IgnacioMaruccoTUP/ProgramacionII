using DataAPI.Entities;
using DataAPI.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ArticleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private IArticleService oService;

        public ArticleController()
        {
            oService = new ArticleService();
        }

        // GET: api/<ArticleController>
        [HttpGet("articulos")]
        public IActionResult Get()
        {
            return Ok(oService.GetAllArticles());
        }

        // GET api/<ArticleController>/5
        [HttpGet("{id}")]
        public IActionResult GetArticle(int id)
        {
            var article = oService.GetArticleById(id);
            if (article == null)
                return NotFound($"No se encontró el articulo especificado. ID: <{id}>");
            return Ok(article);
        }

        // POST api/<ArticleController>
        [HttpPost]
        public IActionResult Post([FromBody] Article oArticle)
        {
            try
            {
                return Ok("Se registro exitosamente el articulo");
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno, intentar nuevamente.");
            }
        }

        // PUT api/<ArticleController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ArticleController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (oService.DeleteArticle(id))
                    return Ok($"Articulo <{id}> eliminado.");
                else
                    return NotFound($"Articulo ID: <{id}> no encontrado.");
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno");
            }
        }
    }
}
