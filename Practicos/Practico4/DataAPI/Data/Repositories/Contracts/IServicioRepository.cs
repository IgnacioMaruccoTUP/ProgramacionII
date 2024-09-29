using DataAPI.Models;
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
        Task<TServicio> GetById(int id);
        Task<bool> Save(TServicio oServicio);
        Task<bool> Update(TServicio oServicio);
    }
}
