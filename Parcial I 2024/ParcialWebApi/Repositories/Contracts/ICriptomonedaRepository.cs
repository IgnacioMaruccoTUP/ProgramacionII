using ParcialWebApi.Models;

namespace ParcialWebApi.Repositories.Contracts
{
    public interface ICriptomonedaRepository
    {
        bool Update(string simbolo, float valorActual, DateTime fecha);
        List<Criptomoneda> GetByCategory(int id);
        Criptomoneda? GetBySymbol(string simbolo);
        Criptomoneda? GetById(int id);
        bool Delete(int id);
    }
}
