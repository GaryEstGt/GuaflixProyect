using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class BWriter<T> where T : IFixedSizeText
    {
        public static void EscribirRaiz(string ruta, int raiz)
        {
            using (var fs = new FileStream(ruta, FileMode.OpenOrCreate))
            {
                fs.Write(ByteGenerator.ConvertToBytes(raiz.ToString("00000000000;-0000000000") + "\n"), 0, 12);
            }
        }
        public static void EscribirPosicionDisponible(string ruta, int posicion)
        {            
            using (var fs = new FileStream(ruta, FileMode.OpenOrCreate))
            {
                fs.Seek(12, SeekOrigin.Begin);
                fs.Write(ByteGenerator.ConvertToBytes(posicion.ToString("00000000000;-0000000000") + "\n"), 0, 12);
            }
        }
        public static void EscribirNodo(string ruta, NodoB<T> nodo, int posicion)
        {            
            using (var fs = new FileStream(ruta, FileMode.OpenOrCreate))
            {
                fs.Seek(24 + ((posicion - 1) * NodoB<T>.FixedSize), SeekOrigin.Begin);
                fs.Write(ByteGenerator.ConvertToBytes(nodo.ToFixedSizeString()), 0, NodoB<T>.FixedSize);            
            }
        }

        public static void EvaluarRuta(string ruta)
        {
            if (!Directory.Exists(ruta))
            {
                Directory.CreateDirectory(ruta);
            }
        }        
    }
}
