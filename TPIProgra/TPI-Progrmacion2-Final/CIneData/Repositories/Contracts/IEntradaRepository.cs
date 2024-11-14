using CIneData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIneData.Repositories.Contracts
{
    public interface IEntradaRepository
    {
        Task<List<Entrada>> GetEntradasByFuncion(int idFuncion);
        Task<List<Entrada>> GetEntradasPorReserva(int idReserva);

    }
}
