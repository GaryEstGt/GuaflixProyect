using Biblioteca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class ArbolB<T> where T : IFixedSizeText
    {
        public static int Grado { get; set; }
        public int Raiz { get; set; }
        public int PosicionDisponible { get; set; }
        public string RutaArbol { get; set; }
        public int TamañoT { get; set; }
        public Func<string, T> ConvertToT { get; set; }
        public static Func<string> ToTNullFormat { get; set; }
        public ArbolB(int grado, string ruta, string archivo, int tamañoValor, Func<string, T> funcion, Func<string> nullFormat)
        {
            Grado = grado;
            Raiz = int.MinValue;
            PosicionDisponible = 1;
            BWriter<T>.EvaluarRuta(ruta);
            RutaArbol = ruta + archivo;
            TamañoT = tamañoValor;
            ConvertToT = funcion;
            ToTNullFormat = nullFormat;

            BWriter<T>.EscribirRaiz(RutaArbol, int.MinValue);
            BWriter<T>.EscribirPosicionDisponible(RutaArbol, 1);
        }

        public void Insertar(T valor, Delegate comparador1, Delegate comparador2)
        {
            Raiz = BReader<T>.LeerRaiz(RutaArbol);

            if (Raiz == int.MinValue)
            {
                NodoB<T> nodo = new NodoB<T>(TamañoT, Grado, PosicionDisponible);
                nodo.Valores[0] = valor;
                BWriter<T>.EscribirNodo(RutaArbol, nodo, PosicionDisponible);
                Raiz = nodo.posicion;
                BWriter<T>.EscribirRaiz(RutaArbol, Raiz);
                PosicionDisponible++;
                BWriter<T>.EscribirPosicionDisponible(RutaArbol, PosicionDisponible);
            }
            else
            {
                int posicionNodo = BuscarPosicion(valor, GuardarNodo(BReader<T>.LeerNodo(RutaArbol, Raiz)), comparador1, comparador2);
                if (posicionNodo != int.MaxValue)
                {
                    NodoB<T> Nodo = GuardarNodo(BReader<T>.LeerNodo(RutaArbol, posicionNodo));

                    int i;
                    for (i = 0; i < Nodo.Valores.Length; i++)
                    {
                        if (Nodo.Valores[i] == null)
                        {
                            Nodo.Valores[i] = valor;
                            break;
                        }
                    }

                    Nodo.Valores = OrdenarValores(Nodo.Valores, comparador1, comparador2);

                    if (i == Nodo.Valores.Length)
                    {

                    }
                }                
            }
        }

        public NodoB<T> GuardarNodo(string nodo)
        {
            string[] datosNodo = nodo.Split('|');
            List<int> hijos = new List<int>();
            T[] valores = new T[Grado];

            for (int i = 2; i < Grado + 2; i++)
            {
                hijos.Add(int.Parse(datosNodo[i]));
            }

            int x = 0;
            for (int i = 2 + Grado; i < (2*Grado) + 1; i++)
            {
                T valor = ConvertToT(datosNodo[i]);
                if (valor != null)
                {
                    valores[x] = valor;
                }                
            }            

            NodoB<T> Nodo = new NodoB<T>(int.Parse(datosNodo[0]), int.Parse(datosNodo[1]), hijos, valores, TamañoT, Grado);
            return Nodo;
        }

        public T[] OrdenarValores(T[] Valores,Delegate comparador1, Delegate comparador2)
        {
            for (int i = 0; i < Valores.Length - 1; i++)
            {
                if (Valores[i] != null && Valores[i+1] != null)
                {
                    if ((int)comparador1.DynamicInvoke(Valores[i], Valores[i + 1]) == 1)
                    {

                    }
                    else if ((int)comparador1.DynamicInvoke(Valores[i], Valores[i + 1]) == 0)
                    {
                        if ((int)comparador2.DynamicInvoke(Valores[i], Valores[i + 1]) == 1)
                        {

                        }
                    }
                }                
            }
            return null;
        }

        public bool VerSiEsHoja(NodoB<T> nodo)
        {
            int hijos = 0;

            for (int i = 0; i < nodo.hijos.Count; i++)
            {
                if (nodo.hijos[i] != int.MinValue)
                    hijos++;
            }

            if (hijos != 0)
                return false;
            else
                return true;                
        }

        public bool VerSiRepite(T valor, NodoB<T> nodo, Delegate comparador1, Delegate comparador2)
        {
            int repeticion = 0;

            for (int i = 0; i < nodo.Valores.Length - 1; i++)
            {
                if (nodo.Valores[i] != null)
                {
                    if ((int)comparador1.DynamicInvoke(valor, nodo.Valores[i]) == 0 && (int)comparador2.DynamicInvoke(valor, nodo.Valores[i]) == 0)
                    {
                        repeticion++;
                    }
                }                
            }

            if (repeticion != 0)
                return true;
            else
                return false;        
        }

        public int BuscarPosicion(T valor, NodoB<T> nodo, Delegate comparador1, Delegate comparador2)
        {
            int hijo = int.MinValue;
            bool repite = VerSiRepite(valor, nodo, comparador1, comparador2);
            bool hoja = VerSiEsHoja(nodo);

            if (!hoja && !repite)
            {
                for (int i = 0; i < nodo.Valores.Length - 1; i++)
                {
                    if ((int)comparador1.DynamicInvoke(valor, nodo.Valores[i]) == -1)
                        hijo = i;
                    else if ((int)comparador1.DynamicInvoke(valor, nodo.Valores[i]) == 1)
                        hijo = i + 1;
                    else
                    {
                        if ((int)comparador2.DynamicInvoke(valor, nodo.Valores[i]) == -1)
                            hijo = i;
                        else if ((int)comparador2.DynamicInvoke(valor, nodo.Valores[i]) == 1)
                            hijo = i + 1;                        
                    }

                    if (hijo != int.MinValue)
                        break;
                }

                BuscarPosicion(valor, GuardarNodo(BReader<T>.LeerNodo(RutaArbol, hijo)), comparador1, comparador2);
            }
            else if (repite)
            {
                hijo = int.MaxValue;
            }

            if (hijo == int.MaxValue)            
                return hijo;            
            else
                return nodo.posicion;
        }
    }
}
