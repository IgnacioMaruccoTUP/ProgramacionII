using ModeloParcialWebApi.Models;

namespace ModeloParcialWebApi.Repositories
{
    public class GeneroRepository : IGeneroRepository
    {
        private CineDbContext _context;

        public GeneroRepository(CineDbContext context)
        {
            _context = context;
        }

        public List<Genero> GetAll()
        {
            return _context.Generos.ToList();
        }
    }
}
