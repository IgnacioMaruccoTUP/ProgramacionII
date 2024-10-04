using EFBancoAPI.Data.Models;

namespace EFBancoAPI.Data.Services.Contracts
{
    public interface ICuentaService
    {
        List<Cuenta> RecuperarCuentas();
        Cuenta? RecuperarCuentaPorId(int id);
        List<Cuenta> RecuperarEntre(int year1, int year2);
        List<Cuenta> RecuperarMovimientoUltimosNDias(int days);
        List<Cuenta> RecuperarConCbu(string cbu);
        bool AgregarCuenta(Cuenta oCuenta);
        bool ActualizarCuenta(Cuenta oCuenta);
        bool DesactivarCuenta(int id, string motivoBaja);
    }
}
