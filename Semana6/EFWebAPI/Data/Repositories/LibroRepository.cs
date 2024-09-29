using EFWebAPI.Data.Models;

namespace EFWebAPI.Data.Repositories
{
    public class LibroRepository : ILibroRepository
    {
        private LibrosDbContext _context;
        public LibroRepository(LibrosDbContext context)
        {
            _context = context;
        }
        public void Create(Libro oLibro)
        {
            _context.Libros.Add(oLibro);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var libroDeleted = GetById(id);
            if (libroDeleted != null)
            {
                _context.Libros.Remove(libroDeleted);
                _context.SaveChanges();
            }
        }

        public List<Libro> GetAll()
        {
            return _context.Libros.ToList();
        }

        public Libro? GetById(int id)
        {
            return _context.Libros.Find(id);
        }

        public void Update(Libro oLibro)
        {
            if (oLibro != null)
            {
                _context.Libros.Update(oLibro);
                _context.SaveChanges();
            }
        }
    }
}
