using EFEnviosAPI.Data.Models;
using EFEnviosAPI.Data.Repositories.Contracts;

namespace EFEnviosAPI.Data.Repositories.Implementations
{
    public class EnviosRepository : IEnviosRepository
    {
        private readonly EnviosDbContext _context;
        public EnviosRepository(EnviosDbContext context)
        {
            _context = context;
        }
        public bool Create(TEnvio oEnvio)
        {
            _context.Add(oEnvio);
            return _context.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var envioToDelete = GetById(id);
            if (envioToDelete == null)
                return false;
            envioToDelete.Estado = "Cancelado";
            return _context.SaveChanges() > 0;
        }

        public List<TEnvio> GetAllByDates(DateTime date1, DateTime date2)
        {
            return _context.TEnvios.Where(envio => !envio.Estado.Equals("Cancelado") && envio.FechaEnvio >= date1 && envio.FechaEnvio <= date2).ToList();
        }

        public TEnvio? GetById(int id)
        {
            return _context.TEnvios.FirstOrDefault(envio => !envio.Estado.Equals("Cancelado") && envio.Codigo == id );
        }
    }
}
