using CIneData.Models;
using CIneData.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIneData.Repositories.Implementations
{
    public class ReservaRepository : IReservaRepository
    {
        private CineDbContext _db_prograContext;

        public ReservaRepository(CineDbContext prograContext)
        {
            _db_prograContext = prograContext;
        }

        public async Task<bool> ActualizarReserva(int idReserva, Reserva oReserva)
        {
            var reserva = await _db_prograContext.Reservas.FindAsync(idReserva);

            if (reserva == null)
            {
                return false;
            }

            reserva.IdFormaPago = oReserva.IdFormaPago;
            reserva.FechaPago = DateTime.Now;
            reserva.EstadoPago = true;

            return await _db_prograContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> CrearReserva(Reserva oReserva)
        {
            var reserva = new Reserva
            {
                IdFormaPago = oReserva.IdFormaPago,
                IdCliente = oReserva.IdCliente,
                FechaEmision = DateTime.Now,
                FechaPago = oReserva.FechaPago,
                EstadoPago = oReserva.FechaPago.HasValue,
                Entrada = oReserva.Entrada,
            };

            _db_prograContext.Reservas.Add(reserva);
            return await _db_prograContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> EliminarReserva(int idReserva)
        {
            var reserva = await _db_prograContext.Reservas.FindAsync(idReserva);
            if (reserva == null)
            {
                return false;
            }
            _db_prograContext.Remove(reserva);
            await _db_prograContext.SaveChangesAsync();

            return true;
        }

        public async Task<Reserva?> RecuperarReserva(int ReservaId)
        {
            return await _db_prograContext.Reservas.Where(r => r.IdReserva == ReservaId).FirstOrDefaultAsync();
        }

        public async Task<List<Reserva>> RecuperarReservasPorCliente(int idCliente)
        {
            List<Reserva> lst;
            if(idCliente == 0)
            {
                lst = await _db_prograContext.Reservas
                    .Include( r => r.Entrada)
                    .Include( r => r.IdClienteNavigation)
                    .Include( r => r.IdFormaPagoNavigation)
                    .ToListAsync();
            }
            else
            {
                lst = await _db_prograContext.Reservas
                    .Include(r => r.Entrada)
                    .Include(r => r.IdClienteNavigation)
                    .Include(r => r.IdFormaPagoNavigation)
                    .Where( r => r.IdCliente == idCliente)
                    .ToListAsync();
            }
            return lst;
        }
    }
}
