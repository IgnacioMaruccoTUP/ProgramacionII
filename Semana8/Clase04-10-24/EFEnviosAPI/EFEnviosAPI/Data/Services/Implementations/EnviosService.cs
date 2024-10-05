using EFEnviosAPI.Data.Models;
using EFEnviosAPI.Data.Repositories.Contracts;
using EFEnviosAPI.Data.Services.Contracts;

namespace EFEnviosAPI.Data.Services.Implementations
{
    public class EnviosService : IEnviosService
    {
        private readonly IEnviosRepository _enviosRepository;
        public EnviosService(IEnviosRepository enviosRepository)
        {
            _enviosRepository = enviosRepository;
        }
        public List<TEnvio> RecuperarEntreFechas(DateTime date1, DateTime date2)
        {
            return _enviosRepository.GetAllByDates(date1, date2);
        }

        public TEnvio? RecuperarPorId(int id)
        {
            return _enviosRepository.GetById(id);
        }

        public bool Registrar(TEnvio oEnvio)
        {
            return _enviosRepository.Create(oEnvio);
        }

        public bool RegistrarBaja(int id)
        {
            return _enviosRepository.Delete(id);
        }
    }
}
