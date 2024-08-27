using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilasColasApp.Interfaces
{
    public interface IColeccion
    {
        bool EstaVacia();
        object Extraer();
        object Primero();
        bool Aniadir(object elemento);
    }
}
