using CIneData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIneData.Repositories.Contracts
{
    public interface IFuncionRepository
    {
        Task<bool> EliminarFuncion(int id);
        Task<List<Funcione>> RecuperarTodasFunciones();
        Task<List<Funcione>> RecuperarFuncionesFiltradas(int? sala, string? pelicula, DateTime? fechaDesde, DateTime? fechaHasta, decimal? precioDesde, decimal? precioHasta);
        Task<Funcione?> RecuperarFuncionPorId(int id);
        Task<bool> AgregarFuncion(Funcione oFuncion);
        Task<bool> ActualizarFuncion(Funcione oFuncion);
        Task<List<EncontrarConflictoResult>> EncontrarConflicto(DateTime horario, int id_pelicula, int id_sala, int? id_funcion = null);
        Task<List<Funcione>?> GetFunctionsByFilters(string? movieName, DateTime? fecha1, DateTime? fecha2);
        Task<List<Funcione>> GetFuncionesPorPelicula(int idPelicula);
    }
}
