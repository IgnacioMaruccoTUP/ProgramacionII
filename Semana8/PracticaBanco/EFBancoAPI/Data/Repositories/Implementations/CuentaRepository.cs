using EFBancoAPI.Data.Models;
using EFBancoAPI.Data.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace EFBancoAPI.Data.Repositories.Implementations
{
    public class CuentaRepository : ICuentaRepository
    {
        private readonly BancoDbContext _context;
        public CuentaRepository(BancoDbContext context)
        {
            _context = context;
        }
        public bool Create(Cuenta oCuenta)
        {
            _context.Cuenta.Add(oCuenta);
            return _context.SaveChanges() > 0;
        }

        public bool Delete(int id, string motivoBaja)
        {
            var cuentaToDelete = GetById(id);
            if (cuentaToDelete == null)
                return false;
            cuentaToDelete.FechaBaja = DateTime.Now;
            cuentaToDelete.MotivoBaja = motivoBaja;
            return _context.SaveChanges() > 0;
        }

        public List<Cuenta> GetAll()
        {
             return _context.Cuenta.Where(c => !c.FechaBaja.HasValue).Include(c => c.Cliente).Include(c=>c.TipoCuenta).ToList();
        }

        public List<Cuenta> GetAllBetween(int year1, int year2)
        {
            return _context.Cuenta.Where(c => !c.FechaBaja.HasValue && c.UltimoMovimiento.Value.Year > year1 && c.UltimoMovimiento.Value.Year < year2).ToList();
        }

        public List<Cuenta> GetAllCbu(string cbu)
        {
            return _context.Cuenta.Where(c => !c.FechaBaja.HasValue && c.Cbu.Equals(cbu)).ToList();
        }

        public List<Cuenta> GetAllLastNDays(int days)
        {
            var aux = DateTime.Now.AddDays(-days);
            return _context.Cuenta.Where(c => !c.FechaBaja.HasValue && c.UltimoMovimiento >= aux).ToList();
        }

        public Cuenta? GetById(int id)
        {
            return _context.Cuenta.FirstOrDefault(c => !c.FechaBaja.HasValue && c.Id == id);
        }

        public bool Update(Cuenta oCuenta)
        {
            var cuentaToUpdate = GetById(oCuenta.Id);
            if (cuentaToUpdate == null)
                return false;
            cuentaToUpdate.Cbu = oCuenta.Cbu;
            cuentaToUpdate.Saldo = oCuenta.Saldo;
            cuentaToUpdate.TipoCuentaId = oCuenta.TipoCuentaId;
            cuentaToUpdate.UltimoMovimiento = oCuenta.UltimoMovimiento;
            cuentaToUpdate.ClienteId = oCuenta.ClienteId;
            cuentaToUpdate.FechaBaja = oCuenta.FechaBaja;
            cuentaToUpdate.MotivoBaja = oCuenta.MotivoBaja;

            return _context.SaveChanges() > 0;
        }
    }
}
