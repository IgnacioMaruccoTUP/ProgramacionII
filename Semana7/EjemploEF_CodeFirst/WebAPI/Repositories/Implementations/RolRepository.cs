using WebAPI.Models;
using WebAPI.Repositories.Contracts;

namespace WebAPI.Repositories.Implementations
{
    public class RolRepository : IRolRepository
    {
        private AppDbContext _context;

        public RolRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Create(Rol oRol)
        {
            _context.Roles.Add(oRol);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var rolToDelete = GetById(id);
            if (rolToDelete != null)
            {
                _context.Roles.Remove(rolToDelete);
                _context.SaveChanges();
            }
        }

        public List<Rol> GetAll()
        {
            return _context.Roles.ToList();
        }

        public Rol GetById(int id)
        {
            return _context.Roles.Find(id);
        }

        public void Update(Rol oRol)
        {
            _context.Roles.Update(oRol);
            _context.SaveChanges();
        }
    }
}
