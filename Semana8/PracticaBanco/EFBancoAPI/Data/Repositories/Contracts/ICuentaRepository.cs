using EFBancoAPI.Data.Models;

namespace EFBancoAPI.Data.Repositories.Contracts
{
    public interface ICuentaRepository
    {
        List<Cuenta> GetAll();
        List<Cuenta> GetAllBetween(int year1, int year2);
        List<Cuenta> GetAllLastNDays(int days);
        List<Cuenta> GetAllCbu(string cbu);
        Cuenta? GetById(int id);
        bool Create(Cuenta oCuenta);
        bool Update(Cuenta oCuenta);
        bool Delete(int id, string motivoBaja);
    }
}
