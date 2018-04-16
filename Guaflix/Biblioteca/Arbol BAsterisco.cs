using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    class Arbol_BAsterisco<T> where T : IFixedSizeText
    {
        public static int Grado { get; set; }
        public int Raiz;
        public int PosicionDisponible;
        public string RutaArbol { get; set; }

        public Arbol_BAsterisco(int grado, string ruta)
        {
            Grado = grado;
            Raiz = int.MinValue;
            PosicionDisponible = 1;
            RutaArbol = ruta;

            //BWriter.Escribir(Raiz.ToString("00000000000;-0000000000"), RutaArbol);
            //BWriter.Escribir(PosicionDisponible.ToString("00000000000;-0000000000"), RutaArbol);
        }

        public void Insertar(T valor, Delegate delegado)
        {
            //BReader<T>.LeerEncabezado(RutaArbol, ref Raiz, ref PosicionDisponible);
            //if (Raiz == int.MinValue)
            //{
            //    NodoB<T> nuevo = new NodoB<T>(valor.FixedSizeText, Grado);
            //    nuevo.Valores.Add(valor);
            //    BWriter.Escribir();
            //}
            //else
            //{
            //    NodoB<T> aux = Raiz;

            //    for (int i = 0; i < Grado - 1; i++)
            //    {
            //        if ((int)delegado.DynamicInvoke(aux.Valores[i], valor) == -1)
            //        {

            //        }
            //        else if ((int)delegado.DynamicInvoke(aux.Valores[i], valor) == 1)
            //        {

            //        }
            //    }


            //    if (nuevo.Valores.Count == Grado)
            //    {
                    
            //    }
            //}
        }

        public void Eliminar(T valor)
        {

        }

        public void FindWhere(Delegate delegado)
        {

        }

        //public List<T> Ordenar(T valor, Delegate delegado)
        //{

        //}
    }
}
