using DataAPI.Data.Repositories.Contracts;
using DataAPI.Data.Services.Contracts;
using DataAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAPI.Data.Services.Implementations
{
    public class ServicioService : IServicioService
    {
        private readonly IServicioRepository _context;
        public ServicioService(IServicioRepository context)
        {
            _context = context;
        }

        public async Task<bool> Delete(int id, string motivo)
        {
            return await _context.Delete(id, motivo);
        }

        public async Task<List<TServicio>> GetAll()
        {
            return await _context.GetAll();
        }

        public async Task<TServicio> GetById(int id)
        {
            return await _context.GetById(id);
        }

        public async Task<bool> Save(TServicio oServicio)
        {
            return await _context.Save(oServicio);
        }

        public async Task<bool> Update(TServicio oServicio)
        {
            return await _context.Update(oServicio);
        }
    }
}
