using ProduccionBack.Entities;

namespace ProduccionBack.Data
{
    public interface IOrdenRepository
    {
        List<Componente> ObtenerComponentes();
        bool CrearOrden(OrdenProduccion orden);
        List<OrdenProduccion> ObtenerOrdenesProduccion(DateTime? fechaConsulta, string? estadoConsulta);

        bool CancelarOrdenProduccion(int nro);
    }
}
