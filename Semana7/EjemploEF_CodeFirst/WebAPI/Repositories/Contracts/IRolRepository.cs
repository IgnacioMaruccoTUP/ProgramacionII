using WebAPI.Models;

namespace WebAPI.Repositories.Contracts
{
    public interface IRolRepository
    {
        void Create(Rol oRol);
        void Update(Rol oRol);
        List<Rol> GetAll();
        Rol GetById(int id);
        void Delete(int id);
    }
}
