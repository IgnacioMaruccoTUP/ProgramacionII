﻿using DataAPI.Data.Models;
using DataAPI.Data.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAPI.Data.Repositories.Implementations
{
    public class ServicioRepository : IServicioRepository
    {
        private readonly PeluqueriaDbContext _context;
        public ServicioRepository(PeluqueriaDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Delete(int id, string motivo)
        {
            var servicioToDelete = await _context.TServicios.FindAsync(id);
            if (servicioToDelete != null) 
            {
                servicioToDelete.FechaCancelacion = DateTime.Now;
                servicioToDelete.MotivoCancelacion = motivo;
                _context.TServicios.Update(servicioToDelete);

                return await _context.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<List<TServicio>> GetAll()
        {
            return await _context.TServicios.Where(s => !s.FechaCancelacion.HasValue).ToListAsync();
        }

        public async Task<List<TServicio>> GetByFilters(string? name, string? onSale)
        {
            if(name != null && onSale != null)
                return await _context.TServicios.Where(s => s.Nombre.Contains(name) && s.EnPromocion == onSale && !s.FechaCancelacion.HasValue).ToListAsync();
            else if(name != null)
                return await _context.TServicios.Where(s => s.Nombre.Contains(name) && !s.FechaCancelacion.HasValue).ToListAsync();
            else
                return await _context.TServicios.Where(s => s.EnPromocion == onSale && !s.FechaCancelacion.HasValue).ToListAsync();
        }

        public async Task<TServicio?> GetById(int id)
        {
            return await _context.TServicios.Where(s => s.Id == id && !s.FechaCancelacion.HasValue).FirstOrDefaultAsync();
            //return await _context.TServicios.FindAsync(id);
        }

        public async Task<bool> Save(TServicio oServicio)
        {
            _context.TServicios.Add(oServicio);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Update(TServicio oServicio)
        {
            var servicioToUpdate = await _context.TServicios.FindAsync(oServicio.Id);

            if (servicioToUpdate != null)
            {
                servicioToUpdate.Nombre = oServicio.Nombre;
                servicioToUpdate.Costo = oServicio.Costo;
                servicioToUpdate.EnPromocion = oServicio.EnPromocion;
                servicioToUpdate.FechaCancelacion = oServicio.FechaCancelacion;
                servicioToUpdate.MotivoCancelacion = oServicio.MotivoCancelacion;
                _context.TServicios.Update(servicioToUpdate);

                return await _context.SaveChangesAsync() > 0;
            }
            else
                return false;
        }
    }
}
