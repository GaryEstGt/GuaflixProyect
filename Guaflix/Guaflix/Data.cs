using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Guaflix
{
    public class Data
    {
        private static Data Instance;
        public static Data instance
        {

            get
            {
                if (Instance == null)
                {
                    Instance = new Data();
                }
                return Instance;
            }
            set { Instance = value; }
        }
        public string datosUsuarios=string.Empty;

        public EscribirJson escritor = new EscribirJson();
    }
}
   