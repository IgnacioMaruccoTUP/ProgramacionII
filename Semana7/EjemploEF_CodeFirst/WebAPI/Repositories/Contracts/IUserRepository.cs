using WebAPI.Models;

namespace WebAPI.Repositories.Contracts
{
    public interface IUserRepository
    {
        List<User> GetAll();
        List<User> GetByFilters(int idRol);
        User? GetById(int id);
        void Save(User oUser);
        void Delete(int id);
    }
}
