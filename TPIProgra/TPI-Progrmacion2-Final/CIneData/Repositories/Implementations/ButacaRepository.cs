using CIneData.Models;
using CIneData.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIneData.Repositories.Implementations
{
    public class ButacaRepository : IButacaRepository
    {
        CineDbContext _context;
        public ButacaRepository(CineDbContext context)
        {
            _context = context;
        }
        public async Task<List<Butaca>> GetButacasByFuncionOcupadas(int idFuncion)
        {
            return await _context.Butacas
                    .Where(b => _context.Entradas
                    .Any(e => e.IdFuncion == idFuncion && e.IdButaca == b.IdButaca))
                    .ToListAsync();
        }

        public async Task<List<Butaca>> GetButacasByFuncion(int idFuncion)
        {
            return await _context.Butacas
                    .Where(b => _context.Funciones
                    .Any(f => f.IdFuncion == idFuncion && f.IdSala == b.IdSala))
                    .ToListAsync();
        }
    }
}
