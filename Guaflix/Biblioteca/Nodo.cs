using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    class Nodo<T>
    {
        public Nodo<T> Padre;
        public T info { get; set; }
        public Nodo<T> siguiente { get; set; }
        public Nodo<T> anterior { get; set; }
        public Nodo<T> Derecha { get; set; }
        public Nodo<T> Izquierda { get; set; }
        public int equilibrio { get; set; }

        public Nodo(T Info)
        {
            info = Info;
            siguiente = null;
            anterior = null;
            Derecha = null;
            Izquierda = null;
            Padre = null;
            equilibrio = 0;
        }
        public Nodo<T> getIzquierda()
        {
            return Izquierda;
        }
        public Nodo<T> getDerecha()
        {
            return Derecha;
        }
        public Nodo<T> getPadre()
        {
            return Padre;
        }
    
}
}
