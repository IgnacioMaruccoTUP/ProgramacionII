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
    public class FuncionRepository : IFuncionRepository
    {
        private readonly CineDbContext _context;

        public FuncionRepository(CineDbContext context)
        {
            _context = context;
        }

        public async Task<bool> EliminarFuncion(int id)
        {
            var funcionToDelete = await _context.Funciones.FindAsync(id);
            if (funcionToDelete == null)
                return false;

            funcionToDelete.FechaBaja = DateTime.Now;
            _context.Funciones.Update(funcionToDelete);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<Funcione>> RecuperarTodasFunciones()
        {
            return await _context.Funciones.Where(f => !f.FechaBaja.HasValue)
                .ToListAsync();
        }

        public async Task<Funcione?> RecuperarFuncionPorId(int id)
        {
            return await _context.Funciones.Where(f => f.IdFuncion == id && !f.FechaBaja.HasValue).FirstOrDefaultAsync();
        }

        public async Task<bool> AgregarFuncion(Funcione oFuncion)
        {
            _context.Funciones.Add(oFuncion);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> ActualizarFuncion(Funcione oFuncion)
        {
            var funcionToUpdate = await _context.Funciones.FindAsync(oFuncion.IdFuncion);
            if (funcionToUpdate == null)
                return false;

            funcionToUpdate.IdPelicula = oFuncion.IdPelicula;
            funcionToUpdate.IdSala = oFuncion.IdSala;
            funcionToUpdate.Horario = oFuncion.Horario;
            funcionToUpdate.Subtitulada = oFuncion.Subtitulada;
            funcionToUpdate.PrecioActual = oFuncion.PrecioActual;

            _context.Funciones.Update(funcionToUpdate);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<Funcione>> RecuperarFuncionesFiltradas(int? sala, string? pelicula, DateTime? fechaDesde, DateTime? fechaHasta, decimal? precioDesde, decimal? precioHasta)
        {
            return await _context.Funciones
                .Where(f =>
                    (sala == null || f.IdSala == sala) &&
                    (pelicula == null || f.IdPeliculaNavigation.Pelicula1.Contains(pelicula)) &&
                    (!fechaDesde.HasValue || f.Horario >= fechaDesde) &&
                    (!fechaHasta.HasValue || f.Horario <= fechaHasta) &&
                    (!precioDesde.HasValue || f.PrecioActual >= precioDesde) &&
                    (!precioHasta.HasValue || f.PrecioActual <= precioHasta) &&
                    !f.FechaBaja.HasValue)
                .ToListAsync();
        }

        public async Task<List<EncontrarConflictoResult>> EncontrarConflicto(DateTime horario, int id_pelicula, int id_sala, int? id_funcion = null)
        {
            return await _context.Procedures.EncontrarConflictoAsync(horario, id_pelicula, id_sala, id_funcion);
        }


        public async Task<List<Funcione>?> GetFunctionsByFilters(string? movieName, DateTime? fecha1, DateTime? fecha2)
        {
            if (fecha1 == null && fecha2 != null && movieName != null)
                return await _context.Funciones.Where(x => x.Horario <= fecha2 && x.IdPeliculaNavigation.Pelicula1.Contains(movieName)).ToListAsync();
            if (fecha2 == null && fecha1 != null && movieName != null)
                return await _context.Funciones.Where(x => x.Horario >= fecha1 && x.IdPeliculaNavigation.Pelicula1.Contains(movieName)).ToListAsync();
            if (fecha1 == null && fecha2 == null && movieName != null)
                return await _context.Funciones.Where(x => x.IdPeliculaNavigation.Pelicula1.Contains(movieName)).ToListAsync();
            if (movieName == null)
                return await _context.Funciones.Where(x => x.Horario >= fecha1 && x.Horario <= fecha2).ToListAsync();


            return await _context.Funciones.Where(x => x.IdPeliculaNavigation.Pelicula1.Contains(movieName) && x.Horario >= fecha1 && x.Horario <= fecha2).ToListAsync();
        }

        public async Task<List<Funcione>> GetFuncionesPorPelicula(int idPelicula) {
            return await _context.Funciones
                .Where(f => f.IdPelicula == idPelicula)
                .ToListAsync();
        }

    }
}
