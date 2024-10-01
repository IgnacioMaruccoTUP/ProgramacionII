using EFCineAPI.Models;
using Microsoft.Win32;
using System;

namespace EFCineAPI.Repositories
{
    public interface IPeliculaRepository
    {
        List<Pelicula> GetAll();
        bool Create(Pelicula oPelicula);
        bool Update(int id);

        //1.Recuperar todos las peliculas que estuvieron en estreno entre dos años recibidos como parámetro.
        List<Pelicula> GetEstrenosEntreFechas(int anioDesde, int anioHasta);
        //2.Modificar la base de datos y agregar las columnas: fechaBaja y motivo de baja como nulleables para 
        //    registrar mediante Delete una baja lógica de la pelicula
        bool Delete(int id, string motivo);
        //3. Recuperar todas las películas de un deteminado género que estuvieron en estreno entre los años a y b
        List<Pelicula> GetPeliculasPorGenero(int idGenero, int anioDesde, int anioHasta);
    }
}
