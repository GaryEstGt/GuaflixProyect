using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    class DoubleLinkedList<T>
    {
        Nodo<T> Inicio;
        Nodo<T> Fin;
        int tamaño;

        public DoubleLinkedList()
        {
            Inicio = null;
            Fin = null;
            tamaño = 0;
        }

        //public void InsertarInicio(T datos)
        //{
        //    Nodo<T> nuevo = new Nodo<T>(datos);            

        //    if (Inicio == null)
        //    {
        //        Inicio = nuevo;
        //        Fin = nuevo;
        //    }
        //    else
        //    {
        //        nuevo.siguiente = Inicio;
        //        Inicio.anterior = nuevo;
        //        Inicio = nuevo;
        //    }
        //}

        public int GetCantidad()
        {
            return tamaño;
        }
        public List<T> GenerarLista()
        {
            if (Inicio != null)
            {
                List<T> lista = new List<T>();

                Nodo<T> aux = Inicio;

                while (aux != null)
                {
                    lista.Add(aux.info);
                    aux = aux.siguiente;
                }

                return lista;
            }

            return new List<T>();

        }
        public void InsertarFinal(T datos)
        {
            Nodo<T> nuevo = new Nodo<T>(datos);

            tamaño++;

            if (Inicio == null)
            {
                Inicio = nuevo;
                Fin = nuevo;
            }
            else
            {
                Fin.siguiente = nuevo;
                nuevo.anterior = Fin;
                Fin = nuevo;
            }
        }

        //public void InsertarOrden(T datos)
        //{
        //    Nodo<T> nuevo = new Nodo<T>(datos);            

        //    if (Inicio == null)
        //    {
        //        Inicio = nuevo;
        //        Fin = nuevo;
        //    }
        //    else
        //    {
        //        if (nuevo->info.numero < Inicio.info)
        //        {
        //            nuevo->siguiente = Inicio;
        //            Inicio->anterior = nuevo;
        //            Inicio = nuevo;
        //        }
        //        else
        //        {
        //            Nodo* temp1 = Inicio;

        //            while ((nuevo->info.numero > temp1->info.numero) && (temp1 != Fin))
        //            {
        //                if (nuevo->info.numero <= temp1->siguiente->info.numero)
        //                {
        //                    break;
        //                }
        //                temp1 = temp1->siguiente;
        //            }

        //            if (temp1 == Fin)
        //            {
        //                nuevo->siguiente = temp1->siguiente;
        //                nuevo->anterior = temp1;
        //                temp1->siguiente = nuevo;
        //                Fin = nuevo;

        //            }
        //            else
        //            {
        //                nuevo->siguiente = temp1->siguiente;
        //                temp1->siguiente->anterior = nuevo;
        //                nuevo->anterior = temp1;
        //                temp1->siguiente = nuevo;
        //            }


        //        }

        //    }
        //}

        public bool ExisteValor(T valor)
        {
            bool existe = false;

            Nodo<T> aux = Inicio;
            while (aux != Fin)
            {
                if (aux.info.Equals(valor))
                {
                    existe = true;
                    break;
                }
                else
                {
                    aux = aux.siguiente;
                }

            }

            return existe;
        }

        //public T Buscar(int ID)
        //{
        //    Nodo<T> aux = Inicio;
        //    while (aux != Fin)
        //    {
        //        if (aux.info.Equals(valor))
        //        {
        //            existe = true;
        //            break;
        //        }
        //        else
        //        {
        //            aux = aux.siguiente;
        //        }

        //    }

        //    return existe;
        //}

        //public void EliminarInicio()
        //{
        //    Nodo<T> temp = Inicio;
        //    Inicio = Inicio.siguiente;
        //    Inicio.anterior = null;        
        //}

        //public void Eliminar_ultimo()
        //{
        //    Nodo<T> aux = Inicio;
        //    while (!aux.siguiente.equals(Fin))
        //    {
        //        aux = aux.siguiente;
        //    }

        //    Nodo<T> temp = aux.siguiente;
        //    aux.siguiente = null;
        //    Fin = aux;        
        //}

        public void EditarEspecifico(T valor, T buscar)
        {
            Nodo<T> aux = Inicio;
            if (aux.info.Equals(buscar))
            {
                Inicio.info = valor;
            }
            else
            {
                if (ExisteValor(buscar))
                {
                    while (!aux.siguiente.info.Equals(buscar))
                    {
                        aux = aux.siguiente;
                    }

                    aux.siguiente.info = valor;
                }
            }
        }
        public void Eliminar_especifico(T valor)
        {
            Nodo<T> aux = Inicio;
            if (aux.info.Equals(valor))
            {
                Inicio = aux.siguiente;
                Inicio.anterior = null;
            }
            else
            {
                if (ExisteValor(valor))
                {
                    while (!aux.siguiente.info.Equals(valor))
                    {
                        aux = aux.siguiente;
                    }

                    aux.siguiente = aux.siguiente.siguiente;
                    aux.siguiente.anterior = aux;
                }

            }
        }

        public T findWhere(Func<T, bool> delegado)
        {
            Nodo<T> aux = Inicio;

            while (aux != null)
            {
                if (delegado.Invoke(aux.info))
                {
                    break;
                }

                aux = aux.siguiente;
            }

            return aux.info;
        }

        public List<T> where(Func<T, bool> delegado)
        {
            var filtered = new List<T>();
            var aux = Inicio;

            while (aux != null)
            {
                if (delegado.Invoke(aux.info))
                {
                    filtered.Add(aux.info);
                }

                aux = aux.siguiente;
            }

            return filtered;
        }
    }
}
