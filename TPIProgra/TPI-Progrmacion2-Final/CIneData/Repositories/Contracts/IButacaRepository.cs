using CIneData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIneData.Repositories.Contracts
{
    public interface IButacaRepository
    {
        Task<List<Butaca>> GetButacasByFuncionOcupadas(int idFuncion);
        Task<List<Butaca>> GetButacasByFuncion(int idFuncion);
    }
}
