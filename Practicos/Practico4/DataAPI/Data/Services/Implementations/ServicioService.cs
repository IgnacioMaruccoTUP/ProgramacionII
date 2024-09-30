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
        private readonly IServicioRepository _servicioRepository;
        public ServicioService(IServicioRepository servicioRepository)
        {
            _servicioRepository = servicioRepository;
        }

        public async Task<bool> Delete(int id, string motivo)
        {
            return await _servicioRepository.Delete(id, motivo);
        }

        public async Task<List<TServicio>> GetAll()
        {
            return await _servicioRepository.GetAll();
        }

        public async Task<List<TServicio>> GetByFilters(string? name, string? onSale)
        {
            return await _servicioRepository.GetByFilters(name, onSale);
        }

        public async Task<TServicio>? GetById(int id)
        {
            return await _servicioRepository.GetById(id);
        }

        public async Task<bool> Save(TServicio oServicio)
        {
            return await _servicioRepository.Save(oServicio);
        }

        public async Task<bool> Update(TServicio oServicio)
        {
            return await _servicioRepository.Update(oServicio);
        }
    }
}
