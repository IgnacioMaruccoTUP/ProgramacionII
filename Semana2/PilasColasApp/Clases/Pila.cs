using PilasColasApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilasColasApp.Clases
{
    public class Pila : IColeccion
    {
        object[] arrayElementos;
        int contador;

        public Pila(int cantidad)
        {
            this.arrayElementos = new object[cantidad];
            this.contador = -1;
        }
        public bool Aniadir(object elemento)
        {
            bool agregado = false;

            if (contador < arrayElementos.Length - 1)
            {
                contador++;
                arrayElementos[contador] = elemento;

                agregado = true;
            }

            return agregado;
        }

        public bool EstaVacia()
        {
            return contador == -1;
        }

        public object Extraer()
        {
            if (!EstaVacia())
            {
                object elemento = Primero();
                arrayElementos[contador] = null;
                contador--;
                return elemento;
            }

            return "La pila esta vacia.";
        }

        public object Primero()
        {
            if (!EstaVacia())
            {
                return arrayElementos[contador];
            }

            return "La pila esta vacia.";
        }
    }
}
