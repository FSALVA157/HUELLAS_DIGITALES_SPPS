using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NCivil
    {//inicio clase NCivil
        public static string Insertar(long cuil, string apellido, string nombre, byte[] foto, int sexo,
            string domicilio, int barrio, int provincia, string fecha_nacimiento)
        {//inicio metodo insertar
            DCiviles Obj = new DCiviles();
            Obj.Cuil = cuil;
            Obj.Apellido = apellido;
            Obj.Nombre = nombre;
            Obj.Foto = foto;
            Obj.Sexo = sexo;
            Obj.Domicilio = domicilio;
            Obj.Barrio = barrio;
            Obj.Provincia = provincia;
            Obj.Fecha_Nacimiento = Convert.ToDateTime(fecha_nacimiento);

            return Obj.Insertar(Obj);

        }//fin metodo insertar

        public static DataTable Buscar(long cuil)
        {//inicio metodo buscar por numero de prontuario
            DCiviles Obj = new DCiviles();
            Obj.Cuil = cuil;
            return Obj.BuscarXCuil(Obj);
        }//fin metodo buscar

        public static string Editar(long cuil, string apellido, string nombre, byte[] foto, int sexo,
            string domicilio, int barrio, int provincia, string fecha_nacimiento)
        {//inicio metodo insertar
            DCiviles Obj = new DCiviles();
            Obj.Cuil = cuil;
            Obj.Apellido = apellido;
            Obj.Nombre = nombre;
            Obj.Foto = foto;
            Obj.Sexo = sexo;
            Obj.Domicilio = domicilio;
            Obj.Barrio = barrio;
            Obj.Provincia = provincia;
            Obj.Fecha_Nacimiento = Convert.ToDateTime(fecha_nacimiento);

            return Obj.editar(Obj);

        }
        //


    }//fin clase NCivil
}
