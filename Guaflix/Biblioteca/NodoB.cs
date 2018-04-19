using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class NodoB<T> : IFixedSizeText where T : IFixedSizeText
    {
        public int Grado { get; set; }
        public int posicion { get; set; }
        public int Padre { get; set; }
        public int[] hijos { get; set; }
        public T[] Valores { get; set; }        
        public static int FixedSize { get; set; }
        public int FixedSizeText { get; set; }
        public string ToFixedSizeString()
        {
            string FixedString = "";

            FixedString += $"{posicion.ToString("00000000000;-0000000000")}|{Padre.ToString("00000000000;-0000000000")}|";

            for (int i = 0; i < Grado; i++)
            {
                FixedString += $"{hijos[i].ToString("00000000000;-0000000000")}|";
            }

            for (int i = 0; i < Grado - 1; i++)
            {
                if (Valores[i] != null)
                {
                    FixedString += $"{Valores[i].ToFixedSizeString()}";
                }
                else
                {
                    FixedString += $"{ArbolB<T>.ToTNullFormat()}";
                }

                if (i != Grado - 2)
                {
                    FixedString += "|";
                }
            }

            FixedString += "\n";

            return FixedString;
        }     

        public NodoB(int tamañoValor, int grado, int Posicion)
        {
            Grado = grado;
            FixedSize = 2 + (2 * 11) + (Grado) + (Grado * 11) + (Grado - 1) + ((Grado - 1) * tamañoValor);
            FixedSizeText = FixedSize;
            posicion = Posicion;
            Padre = int.MinValue;
            hijos = new int[Grado + 1];            
            Valores = new T[Grado];            

            for (int i = 0; i < Grado + 1; i++)
            {
                hijos[i] = int.MinValue;                         
            }
        }

        public NodoB(int Posicion, int padre, int[] Hijos, T[] valores, int tamañoValor, int grado)
        {            
            Grado = grado;
            posicion = Posicion;
            Padre = padre;
            FixedSize = 2 + (2 * 11) + (Grado) + (Grado * 11) + (Grado - 1) + ((Grado - 1) * tamañoValor);
            FixedSizeText = FixedSize;
            hijos = Hijos;

            Valores = valores;
        }                

        public int GetCantidadValores()
        {
            int cantidad = 0;

            for (int i = 0; i < hijos.Length - 1; i++)
            {
                if (Valores[i] != null)
                {
                    cantidad++;
                }
            }

            return cantidad;
        }
    }
}
