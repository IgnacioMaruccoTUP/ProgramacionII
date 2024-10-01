using EFCineAPI.Models;

namespace EFCineAPI.Repositories
{
    public interface IPeliculaRepository
    {
        List<Pelicula> GetAll();
        bool Create(Pelicula oPelicula);
        bool Update(int id);

    }
}
