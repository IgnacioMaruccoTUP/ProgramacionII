using ParcialWebApi.Models;
using ParcialWebApi.Repositories.Contracts;
using ParcialWebApi.Services.Contracts;

namespace ParcialWebApi.Services.Implementations
{
    public class CriptomonedaService : ICriptomonedaService
    {
        private readonly ICriptomonedaRepository _criptomonedaRepository;
        public CriptomonedaService(ICriptomonedaRepository criptomonedaRepository)
        {
            _criptomonedaRepository = criptomonedaRepository;
        }

        public bool ActualizarValor(string simbolo, float valorActual, DateTime fecha)
        {
            return _criptomonedaRepository.Update(simbolo, valorActual, fecha);
        }

        public bool Delete(int id)
        {
            return _criptomonedaRepository.Delete(id);
        }

        public List<Criptomoneda> GetByCategory(int id)
        {
            return _criptomonedaRepository.GetByCategory(id);
        }

        public Criptomoneda? GetById(int id)
        {
            return _criptomonedaRepository.GetById(id);
        }

        public Criptomoneda? GetBySymbol(string simbolo)
        {
            return _criptomonedaRepository.GetBySymbol(simbolo);
        }
    }
}
