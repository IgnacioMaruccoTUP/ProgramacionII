using ParcialWebApi.Models;

namespace ParcialWebApi.Services.Contracts
{
    public interface ICriptomonedaService
    {
        List<Criptomoneda> GetByCategory(int id);
        Criptomoneda? GetBySymbol(string simbolo);
        bool ActualizarValor(string simbolo, float valorActual, DateTime fecha);
        bool Delete(int id);
        Criptomoneda? GetById(int id);
    }
}
