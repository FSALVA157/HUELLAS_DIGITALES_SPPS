using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NSexo
    {//inicio clase principal
        public static DataTable mostrar()
        {
            return new DSexo().mostrar();

        }

    }//fin clase principal
}
