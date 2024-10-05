using ParcialWebApi.Models;
using ParcialWebApi.Repositories.Contracts;
using System.Runtime.Intrinsics.X86;

namespace ParcialWebApi.Repositories.Implementations
{
    public class CriptomonedaRepository : ICriptomonedaRepository
    {
        private readonly CriptoContext _context;
        public CriptomonedaRepository(CriptoContext context)
        {
            _context = context;
        }
        public bool Delete(int id)
        {
            var criptoToDelete = GetById(id);
            if (criptoToDelete == null)
                return false;
            if (criptoToDelete.Estado == "NH")
                return false;
            criptoToDelete.Estado = "NH";

            return _context.SaveChanges() > 0;
        }

        public List<Criptomoneda> GetByCategory(int id)
        {
            var aux = DateTime.Now.AddDays(-1);
            return _context.Criptomonedas.Where(c => c.Categoria.Equals(id) && !c.Estado.Equals("NH") && c.UltimaActualizacion >= aux).ToList();
        }

        public Criptomoneda? GetById(int id)
        {
            return _context.Criptomonedas.FirstOrDefault(c => !c.Estado.Equals("NH") && c.Id == id);
        }

        public Criptomoneda? GetBySymbol(string simbolo)
        {
            var aux = DateTime.Now.AddDays(-1);
            return _context.Criptomonedas.FirstOrDefault(c => !c.Estado.Equals("NH") && c.Simbolo.Equals(simbolo));
        }

        public bool Update(string simbolo, float valorActual, DateTime fecha)
        {
            

            var criptoToUpdate = GetBySymbol(simbolo);
            if (criptoToUpdate == null)
                return false;


            criptoToUpdate.UltimaActualizacion = DateTime.Now;
            criptoToUpdate.ValorActual = valorActual;

            return _context.SaveChanges() > 0;
        }
    }
}
