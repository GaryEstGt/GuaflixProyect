using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class BReader<T> where T : IFixedSizeText
    {
        public static void LeerRaiz(string ruta, ref int raiz)
        {
            var buffer = new byte[12];
            using (var fs = new FileStream(ruta, FileMode.OpenOrCreate))
            {
                fs.Read(buffer, 0, 12);
            }

            raiz = int.Parse(ByteGenerator.ConvertToString(buffer));
        }
        public static void LeerPosicionDisponible(string ruta, ref int nuevaPosicion)
        {            
            var buffer = new byte[12];
            using (var fs = new FileStream(ruta, FileMode.OpenOrCreate))
            {
                fs.Seek(11, SeekOrigin.Begin);
                fs.Read(buffer, 0, 12);
            }

            nuevaPosicion = int.Parse(ByteGenerator.ConvertToString(buffer));
        }
        public static string LeerNodo(string ruta, int posicion)
        {
            var buffer = new byte[NodoB<T>.FixedSize];
            using (var fs = new FileStream(ruta, FileMode.OpenOrCreate))
            {
                fs.Seek(22 + ((posicion - 1) * NodoB<T>.FixedSize), SeekOrigin.Begin);
                fs.Read(buffer, 0, NodoB<T>.FixedSize);
            }

            return ByteGenerator.ConvertToString(buffer);
        }
    }
}
