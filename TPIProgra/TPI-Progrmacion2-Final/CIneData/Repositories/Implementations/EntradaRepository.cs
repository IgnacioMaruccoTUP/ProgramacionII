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
    public class EntradaRepository : IEntradaRepository
    {
        CineDbContext _context;
        public EntradaRepository(CineDbContext context)
        {
            _context = context;
        }
        public async Task<List<Entrada>> GetEntradasByFuncion(int idFuncion)
        {
            return await _context.Entradas
                    .Where(e => e.IdFuncion == idFuncion)
                    .ToListAsync();
        }

        public async Task<List<Entrada>> GetEntradasPorReserva(int idReserva)
        {
            return await _context.Entradas
                .Include(e => e.IdButacaNavigation)
                .Include(e => e.IdFuncionNavigation)
                .Where( e => e.IdReserva == idReserva)
                .ToListAsync();
        }
    }
}
