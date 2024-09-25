using WebAPI.Models;
using WebAPI.Repositories.Contracts;

namespace WebAPI.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        //Necesita de un contexto para acceder a la base de datos
        private AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }
        public void Delete(int id)
        {
            var userToDelete = GetById(id);
            _context.Usuarios.Remove(userToDelete);
            _context.SaveChanges();
        }

        public List<User> GetAll()
        {
            return _context.Usuarios.ToList();
        }

        public List<User> GetByFilters(int idRol)
        {
            return _context.Usuarios.Where(user => user.IdRol == idRol).ToList();
        }

        public User? GetById(int id)
        {
            return _context.Usuarios.Find(id);
        }

        public void Save(User oUser)
        {
            if(oUser != null)
            {
                if(oUser.Id == 0)
                {
                    _context.Usuarios.Add(oUser);
                }
                else
                {
                    _context.Usuarios.Update(oUser);
                }
                _context.SaveChanges();
            }
        }
    }
}
