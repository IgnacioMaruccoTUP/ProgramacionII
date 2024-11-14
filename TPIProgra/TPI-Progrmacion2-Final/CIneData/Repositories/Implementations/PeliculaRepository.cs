using CIneData.Models;
using CIneData.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIneData.Repositories.Implementations
{
    public class PeliculaRepository : IPeliculaRepository
    {
        private readonly CineDbContext _context;

        public PeliculaRepository(CineDbContext context)
        {
            _context = context;
        }
        public async Task<List<Pelicula>> RecuperarTodasPeliculas()
        {
            return await _context.Peliculas.Where(p => p.FechaBaja > DateTime.Now || !p.FechaBaja.HasValue).ToListAsync();
        }

        public async Task<List<Pelicula>> GetPelisCartelera()
        {
            return _context.Funciones
                .Where(f => f.FechaAlta <= DateTime.Today && (f.FechaBaja == null || f.FechaBaja >= DateTime.Today))
                .Select(f => f.IdPeliculaNavigation)
                .ToList();
        }

    }
}
