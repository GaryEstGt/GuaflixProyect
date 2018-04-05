using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    class ArbolAVL<T> : ArbolBB<T>
    {
        public ArbolAVL()
        {
            Raiz = null;
            nodosHoja = null;
            altura = 0;
            nodoDesequilibrado = default(T);
        }

        public override void Insertar(T datos, Delegate delegado)
        {
            Nodo<T> nuevo = new Nodo<T>(datos);

            if (Raiz == null)
            {
                Raiz = nuevo;
            }
            else
            {
                Nodo<T> aux = Raiz;
                Nodo<T> Padre = Raiz;
                bool derecha = false;

                while (aux != null)
                {
                    Padre = aux;
                    if ((int)delegado.DynamicInvoke(nuevo.info, aux.info) == 1)
                    {
                        aux = aux.Derecha;
                        derecha = true;
                    }
                    else
                    {
                        aux = aux.Izquierda;
                        derecha = false;
                    }
                }

                if (derecha)
                {
                    Padre.Derecha = nuevo;
                }
                else
                {
                    Padre.Izquierda = nuevo;
                }

                nuevo.Padre = Padre;
            }
            Balancear(nuevo);
        }

        public override void removeNodo(T dato, Delegate delegado)
        {
            Nodo<T> nodo = null;
            findWhere(delegado, dato, Raiz, ref nodo);
            /* Creamos variables para saber si tiene hijos izquierdo y derecho */
            bool tieneNodoDerecha = nodo.getDerecha() != null ? true : false;
            bool tieneNodoIzquierda = nodo.getIzquierda() != null ? true : false;

            if (!tieneNodoDerecha && !tieneNodoIzquierda)
            {
                removeNodoCaso1(nodo);
            }


            if (tieneNodoDerecha && !tieneNodoIzquierda)
            {
                removeNodoCaso2(nodo);
            }


            if (!tieneNodoDerecha && tieneNodoIzquierda)
            {
                removeNodoCaso2(nodo);
            }

            /* Caso 3: Tiene ambos hijos */
            if (tieneNodoDerecha && tieneNodoIzquierda)
            {
                removeNodoCaso3(nodo);
            }

            Balancear(nodo.Padre);
        }

        public void Balancear(Nodo<T> temp)
        {
            while (temp != null)
            {
                ActualizarEquilibrios(Raiz);
                if (temp.equilibrio < -1)
                {
                    if (temp.Izquierda.equilibrio == 1)
                    {
                        rotarIzquierda(temp.Izquierda);
                    }

                    rotarDerecha(temp);
                }
                else if (temp.equilibrio > 1)
                {
                    if (temp.Derecha.equilibrio == -1)
                    {
                        rotarDerecha(temp.Derecha);
                    }
                    rotarIzquierda(temp);
                }

                temp = temp.Padre;
            }
        }

        public void ActualizarEquilibrios(Nodo<T> nAux)
        {
            if (nAux != null)
            {
                ActualizarEquilibrios(nAux.Izquierda);
                if (nAux.Derecha != null && nAux.Izquierda != null)
                {
                    nAux.equilibrio = ((VerAltura(nAux.Derecha) + 2) - (VerAltura(nAux.Izquierda) + 2));
                }
                else if (nAux.Derecha == null && nAux.Izquierda != null)
                {
                    nAux.equilibrio = (1 - (VerAltura(nAux.Izquierda) + 2));
                }
                else if (nAux.Derecha != null && nAux.Izquierda == null)
                {
                    nAux.equilibrio = ((VerAltura(nAux.Derecha) + 2) - 1);
                }
                else
                {
                    nAux.equilibrio = 0;
                }
                ActualizarEquilibrios(nAux.Derecha);
            }
        }

        public void rotarDerecha(Nodo<T> nodo)
        {
            if (nodo != Raiz)
            {
                bool derecha = nodo.Padre.Derecha == nodo ? true : false;

                if (derecha)
                {
                    nodo.Padre.Derecha = nodo.Izquierda;
                }
                else
                {
                    nodo.Padre.Izquierda = nodo.Izquierda;
                }

                nodo.Izquierda.Padre = nodo.Padre;
            }

            nodo.Padre = nodo.Izquierda;
            Nodo<T> der = nodo.Izquierda.Derecha;
            nodo.Izquierda.Derecha = nodo;

            if (der != null)
            {
                der.Padre = nodo;
            }

            nodo.Izquierda = der;

            if (nodo == Raiz)
            {
                Raiz = nodo.Padre;
                Raiz.Padre = null;
            }
        }

        public void rotarIzquierda(Nodo<T> nodo)
        {
            if (nodo != Raiz)
            {
                bool derecha = nodo.Padre.Derecha == nodo ? true : false;

                if (derecha)
                {
                    nodo.Padre.Derecha = nodo.Derecha;
                }
                else
                {
                    nodo.Padre.Izquierda = nodo.Derecha;
                }

                nodo.Derecha.Padre = nodo.Padre;
            }

            nodo.Padre = nodo.Derecha;
            Nodo<T> izquierda = nodo.Derecha.Izquierda;
            nodo.Derecha.Izquierda = nodo;

            if (izquierda != null)
            {
                izquierda.Padre = nodo;
            }

            nodo.Derecha = izquierda;

            if (nodo == Raiz)
            {
                Raiz = nodo.Padre;
                Raiz.Padre = null;
            }
        }
    }
}
