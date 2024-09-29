using EFWebAPI.Data.Models;

namespace EFWebAPI.Data.Repositories
{
    public interface ILibroRepository
    {
        void Create(Libro oLibro);
        void Update(Libro oLibro);
        List<Libro> GetAll();
        Libro? GetById(int id);
        void Delete(int id);
    }
}
