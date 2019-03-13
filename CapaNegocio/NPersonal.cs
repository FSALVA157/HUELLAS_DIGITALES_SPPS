using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
   public class NPersonal
    {//inicio clase principal

        public static string Insertar(int legajo, long cuil, string apellido, string nombre, byte[] foto, int sexo,
            string domicilio, int barrio, int provincia, int destino, int grado, int escalafon, 
            string fecha_ingreso, int antiguedad, string fecha_nacimiento)
        {//inicio metodo insertar
            DPersonal Obj = new DPersonal();
            Obj.Legajo = legajo;
            Obj.Cuil = cuil;
            Obj.Apellido = apellido;
            Obj.Nombre = nombre;
            Obj.Foto = foto;
            Obj.Sexo = sexo;
            Obj.Domicilio = domicilio;
            Obj.Barrio = barrio;
            Obj.Provincia = provincia;
            Obj.Destino = destino;
            Obj.Grado = grado;
            Obj.Escalafon = escalafon;
            Obj.Fecha_Ingreso = Convert.ToDateTime(fecha_ingreso);
            Obj.Antiguedad = antiguedad;
            Obj.Fecha_Nacimiento = Convert.ToDateTime(fecha_nacimiento);

            return Obj.Insertar(Obj);

        }//fin metodo insertar

        public static DataTable BuscarXLegajo(int legajo)
        {//inicio metodo buscar por numero de prontuario
            DPersonal Obj = new DPersonal();
            Obj.Legajo= legajo;
            return Obj.BuscarXLegajo(Obj);
        }//fin metodo buscar

        public static string Editar(int legajo, long cuil, string apellido, string nombre, byte[] foto, int sexo,
            string domicilio, int barrio, int provincia, int destino, int grado, int escalafon,
            string fecha_ingreso, int antiguedad, string fecha_nacimiento)
        {//inicio metodo insertar
            DPersonal Obj = new DPersonal();
            Obj.Legajo = legajo;
            Obj.Cuil = cuil;
            Obj.Apellido = apellido;
            Obj.Nombre = nombre;
            Obj.Foto = foto;
            Obj.Sexo = sexo;
            Obj.Domicilio = domicilio;
            Obj.Barrio = barrio;
            Obj.Provincia = provincia;
            Obj.Destino = destino;
            Obj.Grado = grado;
            Obj.Escalafon = escalafon;
            Obj.Fecha_Ingreso= Convert.ToDateTime(fecha_ingreso);
            Obj.Antiguedad = antiguedad;
            Obj.Fecha_Nacimiento = Convert.ToDateTime(fecha_nacimiento);

            return Obj.editar(Obj);

        }

    }//fin clase principal
}
