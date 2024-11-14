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
    public class SalaRepository : ISalaRepository
    {
        private readonly CineDbContext _context;

        public SalaRepository(CineDbContext context)
        {
            _context = context;
        }

        public async Task<List<Sala>> RecuperarTodasSalas()
        {
            return await _context.Salas.Where(s => s.Activa == true).ToListAsync();
        }
    }
}
