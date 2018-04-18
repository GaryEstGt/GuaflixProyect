using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Guaflix
{
    public class EscribirJson
    {
        public void EscribirArchivo(string texto)
        {
            File.WriteAllText(@"C:\Arboles\pruebajson.json", "[" + texto + "]");
        }
    }
}