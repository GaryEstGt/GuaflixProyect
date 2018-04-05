using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    class BWriter
    {
        public static void Escribir(string text, string ruta, int posicion)
        {
            using (var fs = new FileStream(ruta, FileMode.OpenOrCreate))
            {
                if (posicion == 0)
                {

                    fs.Write(ByteGenerator.ConvertToBytes(text), 0, 1000);
                }

            }
        }
    }
}
