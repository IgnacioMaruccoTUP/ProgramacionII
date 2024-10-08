using DataAPI.Data.Models;
using DataAPI.Data.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAPI.Data.Repositories.Implementations
{
    public class TurnoRepository : ITurnoRepository
    {
        private readonly PeluqueriaDbContext _context;
        public TurnoRepository(PeluqueriaDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Delete(int id, string motivo)
        {
            var turnoToDelete = await GetById(id);
            if (turnoToDelete == null)
                return false;

            turnoToDelete.FechaBaja = DateTime.Now;
            turnoToDelete.MotivoBaja = motivo;

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<TTurno>> GetAll()
        {
            return await _context.TTurnos.Where(t => !t.FechaBaja.HasValue).ToListAsync();
        }

        public async Task<List<TTurno>> GetByFilters(string? cliente, DateTime? fecha)
        {
            if (cliente == null)
                return await _context.TTurnos.Where(t => !t.FechaBaja.HasValue && t.Fecha == fecha).ToListAsync();
            if (fecha == null)
                return await _context.TTurnos.Where(t => !t.FechaBaja.HasValue && t.Cliente == cliente).ToListAsync();

            return await _context.TTurnos.Where(t => !t.FechaBaja.HasValue && t.Fecha == fecha && t.Cliente == cliente).ToListAsync();
        }

        public async Task<TTurno?> GetById(int id)
        {
            return await _context.TTurnos.FirstOrDefaultAsync(t => !t.FechaBaja.HasValue && t.Id == id);
        }

        public async Task<bool> Save(TTurno oTurno)
        {
            var existeTurno = await _context.TTurnos.FirstOrDefaultAsync(t => t.Fecha.DayOfYear == oTurno.Fecha.DayOfYear
                && t.Fecha.Hour == oTurno.Fecha.Hour);

            if (existeTurno != null)
                return false;

            _context.TTurnos.Add(oTurno);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Update(TTurno oTurno)
        {
            var turnoToUpdate = await GetById(oTurno.Id);
            if (turnoToUpdate == null)
                return false;
            turnoToUpdate.Fecha = oTurno.Fecha;
            turnoToUpdate.Cliente = oTurno.Cliente;
            turnoToUpdate.FechaBaja = oTurno.FechaBaja;
            turnoToUpdate.MotivoBaja = oTurno.MotivoBaja;
            _context.TDetallesTurnos.Where(d => d.IdTurno == oTurno.Id).ExecuteDelete();
            turnoToUpdate.TDetallesTurnos = oTurno.TDetallesTurnos;

            return await _context.SaveChangesAsync() > 0;
        }
    }
}
