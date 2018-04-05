using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    class BReader<T> where T : IFixedSizeText
    {
        public static void LeerEncabezado(string ruta, ref int raiz, ref int nuevaPosicion)
        {
            var buffer = new byte[NodoB<T>.FixedSize];
            using (var fs = new FileStream(ruta, FileMode.OpenOrCreate))
            {
                fs.Read(buffer, 0, NodoB<T>.FixedSize);
            }

            raiz = int.Parse(ByteGenerator.ConvertToString(buffer));

            buffer = new byte[NodoB<T>.FixedSize];
            using (var fs = new FileStream(ruta, FileMode.OpenOrCreate))
            {
                fs.Seek(12, SeekOrigin.Begin);
                fs.Read(buffer, 0, NodoB<T>.FixedSize);
            }

            nuevaPosicion = int.Parse(ByteGenerator.ConvertToString(buffer));
        }
        public static void Leer(string ruta, int posicion)
        {

        }
    }
}
