using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocio
{//inicio espacio de nombre
    public class NInterno
    {//inicio clase NInterno
        //metodo insertar que llama al procedimiento almacenado
        
          public static string Insertar(long prontuario, string apellido, string nombre, byte[] foto, byte[] foto_perfil,string sexo, string jurisdiccion,
          string estado_procesal, string causa)
        
        //public static string Insertar(long prontuario, string apellido, string nombre, byte[] foto, string sexo, string jurisdiccion)
        {//inicio metodo insertar
            DInternos Obj = new DInternos();
            Obj.Prontuario = prontuario;
            Obj.Apellido = apellido;
            Obj.Nombre = nombre;
            Obj.Foto = foto;
            Obj.Foto_Perfil = foto_perfil;
            Obj.Sexo = sexo;
            Obj.Jurisdiccion = jurisdiccion;
            Obj.Estado_procesal = estado_procesal;
            Obj.Causa = causa;
            
            return Obj.Insertar(Obj);

        }//fin metodo insertar

        public static DataTable Buscar(long prontuario)
        {//inicio metodo buscar por numero de prontuario
            DInternos Obj = new DInternos();
            Obj.Prontuario = prontuario;
            return Obj.BuscarXProntuario(Obj);
        }//fin metodo buscar

        public static string Editar(long prontuario, string apellido, string nombre, byte[] foto,byte[] foto_perfil, string sexo, string jurisdiccion,
          string estado_procesal, string causa)

        //public static string Insertar(long prontuario, string apellido, string nombre, byte[] foto, string sexo, string jurisdiccion)
        {//inicio metodo insertar
            DInternos Obj = new DInternos();
            Obj.Prontuario = prontuario;
            Obj.Apellido = apellido;
            Obj.Nombre = nombre;
            Obj.Foto = foto;
            Obj.Foto_Perfil = foto_perfil;
            Obj.Sexo = sexo;
            Obj.Jurisdiccion = jurisdiccion;
            Obj.Estado_procesal = estado_procesal;
            Obj.Causa = causa;

            return Obj.editar(Obj);

        }
        //


    }//fin clase NInterno
}//fin espacio de nombre
