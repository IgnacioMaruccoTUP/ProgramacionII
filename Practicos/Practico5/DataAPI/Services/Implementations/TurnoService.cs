using DataAPI.Data.Models;
using DataAPI.Data.Repositories.Contracts;
using DataAPI.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAPI.Services.Implementations
{
    public class TurnoService : ITurnoService
    {
        private readonly ITurnoRepository _turnoRepository;
        public TurnoService(ITurnoRepository turnoRepository)
        {
            _turnoRepository = turnoRepository;
        }
        public async Task<bool> Delete(int id, string motivo)
        {
            return await _turnoRepository.Delete(id, motivo);
        }

        public async Task<List<TTurno>> GetAll()
        {
            return await _turnoRepository.GetAll();
        }

        public Task<List<TTurno>> GetByFilters(string? cliente, DateTime? fecha)
        {
            throw new NotImplementedException();
        }

        public async Task<TTurno?> GetById(int id)
        {
            return await _turnoRepository.GetById(id);
        }

        public async Task<bool> Save(TTurno oTurno)
        {
            return await _turnoRepository.Save(oTurno);
        }

        public async Task<bool> Update(TTurno oTurno)
        {
            return await _turnoRepository.Update(oTurno);
        }
    }
}
