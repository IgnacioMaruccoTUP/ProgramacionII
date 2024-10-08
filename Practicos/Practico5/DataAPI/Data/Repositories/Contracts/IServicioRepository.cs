using DataAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAPI.Data.Repositories.Contracts
{
    public interface IServicioRepository
    {
        Task<bool> Delete(int id, string motivo);
        Task<List<TServicio>> GetAll();
        Task<TServicio?> GetById(int id);
        Task<List<TServicio>> GetByFilters(string? name, string? onSale);
        Task<bool> Save(TServicio oServicio);
        Task<bool> Update(TServicio oServicio);
    }
}
