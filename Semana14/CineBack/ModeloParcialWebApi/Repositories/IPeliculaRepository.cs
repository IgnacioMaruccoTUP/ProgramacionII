using ModeloParcialWebApi.Models;

namespace ModeloParcialWebApi.Repositories
{
    public interface IPeliculaRepository
    {
        List<Pelicula> GetByGenero(int genero);
        bool Create(Pelicula oPelicula);
        bool Update(int id);

        List<Pelicula> GetAllByYears(int anio1, int anio2);

        bool Delete(int id);

    }
}
