using ProduccionBack.Data;
using ProduccionBack.Entities;

namespace ProduccionBack.Services
{
    public class ProduccionService : IProduccionService
    {
        private IOrdenRepository repository;
        public ProduccionService()
        {
            repository = new OrdenRepository();
        }

        public bool CancelarOrden(int nro)
        {
            return repository.CancelarOrdenProduccion(nro);
        }

        public List<Componente> ConsultarComponentes()
        {
            return repository.ObtenerComponentes();
        }

        public List<OrdenProduccion> ConsultarOrdenes(DateTime? fechaConsulta, string? estadoConsulta)
        {
            return repository.ObtenerOrdenesProduccion(fechaConsulta, estadoConsulta);
        }

        public bool RegistrarProduccion(OrdenProduccion orden)
        {
            return repository.CrearOrden(orden);
        }

        //Validar las reglas de negocio q se piden por enunciado
        public bool EsOrdenValida(OrdenProduccion orden)
        {
            return true;
        }
    }
}
