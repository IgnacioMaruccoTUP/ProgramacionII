using EFBancoAPI.Data.Models;
using EFBancoAPI.Data.Repositories.Contracts;
using EFBancoAPI.Data.Services.Contracts;

namespace EFBancoAPI.Data.Services.Implementations
{
    public class CuentaService : ICuentaService
    {
        private readonly ICuentaRepository _cuentaRepository;
        public CuentaService(ICuentaRepository cuentaRepository)
        {
            _cuentaRepository = cuentaRepository;
        }
        public bool ActualizarCuenta(Cuenta oCuenta)
        {
            return _cuentaRepository.Update(oCuenta);
        }

        public bool AgregarCuenta(Cuenta oCuenta)
        {
            return _cuentaRepository.Create(oCuenta);
        }

        public bool DesactivarCuenta(int id, string motivoBaja)
        {
            return _cuentaRepository.Delete(id, motivoBaja);
        }

        public List<Cuenta> RecuperarConCbu(string cbu)
        {
            return _cuentaRepository.GetAllCbu(cbu);
        }

        public Cuenta? RecuperarCuentaPorId(int id)
        {
            return _cuentaRepository.GetById(id);
        }

        public List<Cuenta> RecuperarCuentas()
        {
            return _cuentaRepository.GetAll();
        }

        public List<Cuenta> RecuperarEntre(int year1, int year2)
        {
            return _cuentaRepository.GetAllBetween(year1, year2);
        }

        public List<Cuenta> RecuperarMovimientoUltimosNDias(int days)
        {
            return _cuentaRepository.GetAllLastNDays(days);
        }
    }
}
