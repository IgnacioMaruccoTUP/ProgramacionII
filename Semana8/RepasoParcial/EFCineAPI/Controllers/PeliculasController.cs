﻿using EFCineAPI.Models;
using EFCineAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EFCineAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculasController : ControllerBase
    {
        private readonly IPeliculaRepository _peliculaRepository;
        public PeliculasController(IPeliculaRepository peliculaRepository)
        {
            _peliculaRepository = peliculaRepository;
        }
        // GET: api/<PeliculasController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_peliculaRepository.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno");
            }
        }

        [HttpGet("filtros/anios")]
        public IActionResult GetByFechas([FromQuery] int anioDesde,[FromQuery] int anioHasta)
        {
            try
            {
                if (anioDesde > anioHasta)
                    return BadRequest("Periodo incorrecto");
                return Ok(_peliculaRepository.GetEstrenosEntreFechas(anioDesde, anioHasta   ));
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno");
            }
        }

        [HttpGet("filtros/aniosYgenero")]
        public IActionResult GetByGeneroYAnios([FromQuery] int idGenero, [FromQuery] int anioDesde, [FromQuery] int anioHasta)
        {
            try
            {
                if (anioDesde > anioHasta)
                    return BadRequest("Periodo incorrecto");
                return Ok(_peliculaRepository.GetPeliculasPorGenero(idGenero, anioDesde, anioHasta));
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno");
            }
        }



        // GET api/<PeliculasController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PeliculasController>
        [HttpPost]
        public IActionResult Post([FromBody] Pelicula oPelicula)
        {
            try
            {
                if (IsValid(oPelicula)) 
                {
                    _peliculaRepository.Create(oPelicula);
                    return Ok("Pelicula creada con exito.");
                }
                else
                {
                    return BadRequest("Los campos ingresados no son correctos. Completarlos y verificar.");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno");
            }
        }

        private bool IsValid(Pelicula oPelicula)
        {
            if (!string.IsNullOrEmpty(oPelicula.Titulo) && !string.IsNullOrEmpty(oPelicula.Director) && oPelicula.Anio > 0 && oPelicula.IdGenero > 0)
                return true;
            else
                return false;
        }

        // PUT api/<PeliculasController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id)
        {
            try
            {
                if (_peliculaRepository.Update(id))
                    return Ok("Pelicula actualizada");
                else
                    return NotFound("No se encontró la pelicula.");
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id, string motivo)
        {
            try
            {
                if (_peliculaRepository.Delete(id, motivo))
                    return Ok("Se dio de baja la pelicula");
                else
                    return NotFound($"La pelicula especificada id: <{id}> no existe.");
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno");
            }
        }
    }
}
