using CIneData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIneData.Repositories.Contracts
{
    public interface IReservaRepository
    {
        Task<List<Reserva>> RecuperarReservasPorCliente(int idCliente);
        Task<bool> CrearReserva(Reserva reserva);
        Task<bool> EliminarReserva(int idReserva);
        Task<Reserva> RecuperarReserva(int ReservaId);
        Task<bool> ActualizarReserva(int idReserva, Reserva oReserva);
    }
}
