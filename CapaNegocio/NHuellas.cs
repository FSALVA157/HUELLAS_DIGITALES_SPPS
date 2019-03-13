using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;
using System.Security.Cryptography;

namespace CapaNegocio
{
    public class NHuellas
    {//inicio clase NHuellas
        public static string Insertar_Huella_Interno(long prontuario, int dedo, byte[] huella)
        {
            DHuellas Obj = new DHuellas();
            Obj.Prontuario = prontuario;
            Obj.Dedo = dedo;
            Obj.Huella = huella;
            return Obj.Insertar_Huella_Interno(Obj);
        }

        public static string Insertar_Huella_Civil(long cuil, int dedo, byte[] huella)
        {
            DHuellas Obj = new DHuellas();
            Obj.Dni = cuil;
            Obj.Dedo = dedo;
            Obj.Huella = huella;
            return Obj.Insertar_Huella_Civil(Obj);
        }

        public static string Insertar_Huella_Personal(int legajo, int dedo, byte[] huella)
        {
            DHuellas Obj = new DHuellas();
            Obj.Legajo = legajo;
            Obj.Dedo = dedo;
            Obj.Huella = huella;
            return Obj.Insertar_Huella_Personal(Obj);
        }

        public static string Insertar_CuilEnRegistro(int clave, long cuil)
        {
            DHuellas Obj = new DHuellas();
            Obj.Clave = clave;
            Obj.Dni = cuil;
            return Obj.Insertar_Cuil(Obj);
        }

        public static string Insertar_ProntuarioEnRegistro(int clave, long prontuario)
        {
            DHuellas Obj = new DHuellas();
            Obj.Clave = clave;
            Obj.Prontuario = prontuario;
            return Obj.Insertar_Prontuario(Obj);
        }

        public static string Insertar_LegajoEnRegistro(int clave, int legajo)
        {
            DHuellas Obj = new DHuellas();
            Obj.Clave = clave;
            Obj.Legajo = legajo;
            return Obj.Insertar_Legajo(Obj);
        }

        public static byte[] hashearHuella(byte[] huella)
        {
            SHA1CryptoServiceProvider proveedor = new SHA1CryptoServiceProvider();
            byte[] hash = proveedor.ComputeHash(huella);
            return hash;
        }

        public static DataTable Dedos(long dni)
        {
            DHuellas Obj = new DHuellas();
            Obj.Dni = dni;
            return Obj.GeneraDedo(Obj);
        }

    }//fin clase NHuellas

}
