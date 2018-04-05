using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    class NodoB<T> : IFixedSizeText where T : IFixedSizeText
    {
        public int Grado { get; set; }
        public int posicion { get; set; }
        public int Padre { get; set; }
        public List<int> hijos { get; set; }
        public List<T> Valores { get; set; }
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
                    FixedString += $"{Valores[i].ToFixedSizeString()}|";
                }
                else
                {
                    FixedString += $"{Valores[0].ToNullFormat()}|";
                }
            }

            FixedString += "\n";

            return FixedString;
        }

        public string ToNullFormat()
        {
            return null;
        }

        public NodoB(int tamañoValor, int grado)
        {
            Grado = grado;
            FixedSize = 2 + (2 * 11) + (Grado) + (Grado * 11) + (Grado - 1) + ((Grado - 1) * tamañoValor) + 1;
            FixedSizeText = FixedSize;
            posicion = int.MinValue;
            Padre = int.MinValue;
            hijos = new List<int>(Grado);
            Valores = new List<T>(Grado);

            for (int i = 0; i < Grado; i++)
            {
                hijos.Add(int.MinValue);
            }
        }
    }
}
