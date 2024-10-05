using EFEnviosAPI.Data.Models;

namespace EFEnviosAPI.Data.Services.Contracts
{
    public interface IEnviosService
    {
        List<TEnvio> RecuperarEntreFechas(DateTime date1, DateTime date2);
        bool Registrar(TEnvio oEnvio);
        bool RegistrarBaja(int id);
        TEnvio? RecuperarPorId(int id);
    }
}
