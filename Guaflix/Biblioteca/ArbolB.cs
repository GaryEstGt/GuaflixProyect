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
                    InsertarValor(valor, ref Nodo, comparador1, comparador2);
                    BWriter<T>.EscribirNodo(RutaArbol, Nodo, Nodo.posicion);

                    if (Nodo.Valores[Grado - 1] != null)
                    {
                        SepararNodo(Nodo, comparador1, comparador2);
                    }
                }                
            }
        }

        public void InsertarValor(T valor, ref NodoB<T> nodo, Delegate comparador1, Delegate comparador2)
        {
            for (int i = 0; i < nodo.Valores.Length; i++)
            {
                if (nodo.Valores[i] == null)
                {
                    nodo.Valores[i] = valor;
                    break;
                }
            }

            OrdenarValores(ref nodo, comparador1, comparador2);
        }
        public NodoB<T> GuardarNodo(string nodo)
        {
            string[] datosNodo = nodo.Split('|');
            int[] hijos = new int[Grado + 1];
            T[] valores = new T[Grado];

            int y = 0;
            for (int i = 2; i < Grado + 2; i++)
            {
                hijos[y] = (int.Parse(datosNodo[i]));
                y++;
            }

            hijos[y] = int.MinValue;

            int x = 0;
            for (int i = 2 + Grado; i < (2*Grado) + 1; i++)
            {
                T valor = ConvertToT(datosNodo[i]);
                if (valor != null)
                {
                    valores[x] = valor;
                }
                x++;             
            }            

            NodoB<T> Nodo = new NodoB<T>(int.Parse(datosNodo[0]), int.Parse(datosNodo[1]), hijos, valores, TamañoT, Grado);
            return Nodo;
        }

        public void OrdenarValores(ref NodoB<T> nodo,Delegate comparador1, Delegate comparador2)
        {
            for (int i = 0; i < nodo.Valores.Length - 1; i++)
            {
                if (nodo.Valores[i] != null)
                {
                    for (int j = i; j < nodo.Valores.Length; j++)
                    {
                        if (nodo.Valores[j] != null)
                        {
                            if ((int)comparador1.DynamicInvoke(nodo.Valores[i], nodo.Valores[j]) == 1)
                            {
                                T temp = nodo.Valores[j];
                                nodo.Valores[j] = nodo.Valores[i];
                                nodo.Valores[i] = temp;
                            }
                            else if ((int)comparador1.DynamicInvoke(nodo.Valores[i], nodo.Valores[j]) == 0)
                            {
                                if ((int)comparador2.DynamicInvoke(nodo.Valores[i], nodo.Valores[j]) == 1)
                                {
                                    T temp = nodo.Valores[j];
                                    nodo.Valores[j] = nodo.Valores[i];
                                    nodo.Valores[i] = temp;
                                }
                            }
                        }
                    }
                }                
            }            
        }

        public bool VerSiEsHoja(NodoB<T> nodo)
        {
            int hijos = 0;

            for (int i = 0; i < nodo.hijos.Length - 1; i++)
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
                    {
                        hijo = i;
                    }
                    else if ((int)comparador1.DynamicInvoke(valor, nodo.Valores[i]) == 1 && i == nodo.GetCantidadValores() - 1)
                    {
                        hijo = i + 1;
                    }
                    else if ((int)comparador1.DynamicInvoke(valor, nodo.Valores[i]) == 0)
                    {
                        if ((int)comparador2.DynamicInvoke(valor, nodo.Valores[i]) == -1)
                        {
                            hijo = i;
                        }
                        else if ((int)comparador2.DynamicInvoke(valor, nodo.Valores[i]) == 1 && i == nodo.GetCantidadValores() - 1)
                        {
                            hijo = i + 1;
                        }
                    }

                    if (hijo != int.MinValue)
                        break;
                }                                                                
            }
            else if (repite)
            {
                hijo = int.MaxValue;
            }
            
            if (hijo == int.MaxValue)            
                return hijo;            
            else if(!hoja)
                return BuscarPosicion(valor, GuardarNodo(BReader<T>.LeerNodo(RutaArbol, nodo.hijos[hijo])), comparador1, comparador2);
            else 
                return nodo.posicion;
        }

        public void SepararNodo(NodoB<T> nodo, Delegate comparador1, Delegate comparador2)
        {
            if (nodo.Valores[Grado - 1] != null)
            {
                if (nodo.Padre == int.MinValue)
                {
                    int posicionMedia = Grado / 2;
                    T valorASubir = nodo.Valores[posicionMedia];

                    NodoB<T> hermano = new NodoB<T>(TamañoT, Grado, PosicionDisponible);

                    PosicionDisponible++;
                    BWriter<T>.EscribirPosicionDisponible(RutaArbol, PosicionDisponible);

                    NodoB<T> padre = new NodoB<T>(TamañoT, Grado, PosicionDisponible);
                    PosicionDisponible++;
                    BWriter<T>.EscribirPosicionDisponible(RutaArbol, PosicionDisponible);
                                        
                    Raiz = padre.posicion;
                    BWriter<T>.EscribirRaiz(RutaArbol, Raiz);

                    hermano.Padre = padre.posicion;
                    nodo.Padre = padre.posicion;

                    RepartirValores(posicionMedia, ref nodo, ref hermano);

                    if (!VerSiEsHoja(nodo))
                    {
                        RepartirHijos(nodo, hermano, posicionMedia);
                    }

                    BWriter<T>.EscribirNodo(RutaArbol, hermano, hermano.posicion);
                    BWriter<T>.EscribirNodo(RutaArbol, nodo, nodo.posicion);

                    InsertarValor(valorASubir, ref padre, comparador1, comparador2);

                    padre.hijos[0] = nodo.posicion;
                    padre.hijos[1] = hermano.posicion;

                    BWriter<T>.EscribirNodo(RutaArbol, padre, padre.posicion);
                }
                else
                {
                    int posicionMedia = Grado / 2;
                    T valorASubir = nodo.Valores[posicionMedia];

                    NodoB<T> hermano = new NodoB<T>(TamañoT, Grado, PosicionDisponible);

                    PosicionDisponible++;
                    BWriter<T>.EscribirPosicionDisponible(RutaArbol, PosicionDisponible);

                    NodoB<T> padre = GuardarNodo(BReader<T>.LeerNodo(RutaArbol, nodo.Padre));

                    hermano.Padre = padre.posicion;

                    RepartirValores(posicionMedia, ref nodo, ref hermano);
                    
                    if (!VerSiEsHoja(nodo))
                    {
                        RepartirHijos(nodo, hermano, posicionMedia);
                    }

                    BWriter<T>.EscribirNodo(RutaArbol, hermano, hermano.posicion);
                    BWriter<T>.EscribirNodo(RutaArbol, nodo, nodo.posicion);

                    InsertarValor(valorASubir, ref padre, comparador1, comparador2);

                    bool hijoEncontrado = false;
                    int posicionHijo = int.MinValue;
                    int temp = int.MinValue;
                    for (int i = 0; i < padre.hijos.Length; i++)
                    {
                        if (hijoEncontrado)
                        {                                                        
                            if (i == posicionHijo + 1)
                            {
                                temp = padre.hijos[i];
                                padre.hijos[i] = hermano.posicion;                                                                
                            }
                            else
                            {
                                int temp2 = padre.hijos[i];
                                padre.hijos[i] = temp;
                                temp = temp2;
                            }                                                        
                        }
                        else
                        {
                            if (padre.hijos[i] == nodo.posicion)
                            {
                                hijoEncontrado = true;
                                posicionHijo = i;
                            }
                        }                        
                    }                    

                    if (padre.hijos[Grado] != int.MinValue)                    
                        SepararNodo(padre, comparador1, comparador2);                    
                    else                    
                        BWriter<T>.EscribirNodo(RutaArbol, padre, padre.posicion);                    
                    
                }
            }
        }

        public void RepartirHijos(NodoB<T> nodo, NodoB<T> hermano, int posicionMedia)
        {
            int x = 0;
            for (int i = posicionMedia + 1; i < nodo.hijos.Length; i++)
            {
                hermano.hijos[x] = nodo.hijos[i];
                nodo.hijos[i] = int.MinValue;
                x++;
            }

            for (int i = 0; i < hermano.hijos.Length; i++)
            {
                if (hermano.hijos[i] != int.MinValue)
                {
                    NodoB<T> temp = GuardarNodo(BReader<T>.LeerNodo(RutaArbol, hermano.hijos[i]));
                    temp.Padre = hermano.posicion;
                    BWriter<T>.EscribirNodo(RutaArbol, temp, temp.posicion);
                }
            }
        }       

        public void RepartirValores(int posicionMedia, ref NodoB<T> nodo, ref NodoB<T> hermano)
        {
            int x = 0;
            for (int i = posicionMedia + 1; i < Grado; i++)
            {
                hermano.Valores[x] = nodo.Valores[i];
                nodo.Valores[i] = default(T);
                x++;
            }

            nodo.Valores[posicionMedia] = default(T);
        }

        public void Eliminar(T valor, Delegate comparador1, Delegate comparador2)
        {
            Raiz = BReader<T>.LeerRaiz(RutaArbol);

            if (Raiz != int.MinValue)
            {
                int posicionNodo = BuscarValor(GuardarNodo(BReader<T>.LeerNodo(RutaArbol, Raiz)), valor, comparador1, comparador2);
            }
            
        }   
        
        public int BuscarValor(NodoB<T> nodo, T valor, Delegate comparador1, Delegate comparador2)
        {
            int posicion = int.MinValue;
            bool encontrado = false;

            for (int i = 0; i < nodo.Valores.Length - 1; i++)
            {
                if (nodo.Valores[i] != null)
                {
                    if ((int) comparador1.DynamicInvoke(valor, nodo.Valores[i]) == 0 && (int)comparador2.DynamicInvoke(valor, nodo.Valores[i]) == 0)
                    {
                        posicion = nodo.posicion;
                    }
                }
            }
        }                    
    }
}
