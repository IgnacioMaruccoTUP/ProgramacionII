using ProduccionBack.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProduccionBack.Services
{
    public interface IProduccionService
    {
        List<Componente> ConsultarComponentes();
        bool RegistrarProduccion(OrdenProduccion orden);
        List<OrdenProduccion> ConsultarOrdenes(DateTime? fechaConsulta, string? estadoConsulta);
        bool CancelarOrden(int nro);
        bool EsOrdenValida(OrdenProduccion orden);
    }
}
