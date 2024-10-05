using EFEnviosAPI.Data.Models;

namespace EFEnviosAPI.Data.Repositories.Contracts
{
    public interface IEnviosRepository
    {
        List<TEnvio> GetAllByDates(DateTime date1, DateTime date2);
        bool Create(TEnvio oEnvio);
        bool Delete(int id);

        TEnvio? GetById(int id);
    }
}
