using DataAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAPI.Services.Contracts
{
    public interface ITurnoService
    {
        Task<bool> Delete(int id, string motivo);
        Task<List<TTurno>> GetAll();
        Task<TTurno?> GetById(int id);
        Task<List<TTurno>> GetByFilters(string? cliente, DateTime? fecha);
        Task<bool> Save(TTurno oTurno);
        Task<bool> Update(TTurno oTurno);
    }
}
