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

        public bool Delete(int id, string motivo)
        {
            var peliculaToUpdate = _context.Peliculas.Find(id);
            if (peliculaToUpdate == null)
                return false;
            else
            {
                peliculaToUpdate.FechaBaja = DateTime.Now;
                peliculaToUpdate.MotivoBaja = motivo;
                return _context.SaveChanges() > 0;
            }
        }

        public List<Pelicula> GetAll()
        {
            return _context.Peliculas.Where(x => x.Estreno && !x.FechaBaja.HasValue).ToList();
        }

        public List<Pelicula> GetEstrenosEntreFechas(int anioDesde, int anioHasta)
        {
            return _context.Peliculas.Where(p => p.Anio >= anioDesde && p.Anio <= anioHasta && !p.FechaBaja.HasValue).ToList();
        }

        public List<Pelicula> GetPeliculasPorGenero(int idGenero, int anioDesde, int anioHasta)
        {
            return _context.Peliculas.Where(p => p.IdGenero == idGenero && !p.FechaBaja.HasValue && p.Anio >= anioDesde && p.Anio <= anioHasta).ToList();
        }

        public bool Update(int id)
        {
            var peliculaToUpdate = _context.Peliculas.Find(id);
            if (peliculaToUpdate == null)
                return false;
            else
            {
                peliculaToUpdate.Estreno = false;
                return _context.SaveChanges() > 0;
            }
        }
    }
}
