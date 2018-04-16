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
        public static void EscribirRaiz(string archivo, string raiz)
        {
            EvaluarRuta(@"C:\Arboles\");            
            using (var fs = new FileStream(@"C:\Arboles\" + archivo, FileMode.OpenOrCreate))
            {
                for (int i = 0; i < 2; i++)
                {
                    fs.Write(ByteGenerator.ConvertToBytes(raiz + "\n"), 0, 12);
                }                
            }
        }
        public static void EscribirPosicionDisponible(string archivo, string posicion)
        {
            EvaluarRuta(@"C:\Arboles\");
            using (var fs = new FileStream(@"C:\Arboles\" + archivo, FileMode.OpenOrCreate))
            {
                fs.Seek(13, SeekOrigin.Begin);
                fs.Write(ByteGenerator.ConvertToBytes(posicion + "\n"), 0, 12);
            }
        }
        public static void EscribirNodo(string archivo, string nodo, int posicion)
        {
            EvaluarRuta(@"C:\Arboles\");
            using (var fs = new FileStream(@"C:\Arboles\" + archivo, FileMode.OpenOrCreate))
            {
                fs.Seek(24 + ((posicion - 1) * NodoB<T>.FixedSize) + 1, SeekOrigin.Begin);
                fs.Write(ByteGenerator.ConvertToBytes(nodo), 0, NodoB<T>.FixedSize);            
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
