using EFCineAPI.Models;

namespace EFCineAPI.Repositories
{
    public class PeliculaRepository : IPeliculaRepository
    {
        private readonly CineDbContext _context;
        public PeliculaRepository(CineDbContext context)
        {
            _context = context;
        }
        public bool Create(Pelicula oPelicula)
        {
            _context.Peliculas.Add(oPelicula);
            return _context.SaveChanges() == 1;
        }

        public List<Pelicula> GetAll()
        {
            return _context.Peliculas.Where(x => x.Estreno).ToList();
        }

        public bool Update(int id)
        {
            var peliculaToUpdate = _context.Peliculas.FirstOrDefault(p => p.Id == id);
            if (peliculaToUpdate == null)
                return false;
            else
            {
                peliculaToUpdate.Estreno = false;
                _context.SaveChanges();
                return true;
            }
        }
    }
}
