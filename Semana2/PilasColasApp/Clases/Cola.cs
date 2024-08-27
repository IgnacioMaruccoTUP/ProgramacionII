using PilasColasApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilasColasApp.Clases
{
    public class Cola : IColeccion
    {
        List<object> listaElementos;
        public Cola()
        {
            this.listaElementos = new List<object>();
        }
        public bool Aniadir(object elemento)
        {
            listaElementos.Add(elemento);
            return true;
        }

        public bool EstaVacia()
        {
            return listaElementos.Count == 0;
        }

        public object Extraer()
        {
            if (EstaVacia())
            {
                return "La cola esta vacia";
            }

            object elemento = listaElementos[0];
            listaElementos.RemoveAt(0);
            return elemento;

        }

        public object Primero()
        {
            if (EstaVacia())
            {
                return "La cola esta vacia.";
            }
            return listaElementos[0];
        }
    }
}
