using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
   public class DJurisdiccion
    {
        private string _id;
        
        public string Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        public string Jurisdiccion
        {
            get
            {
                return _jurisdiccion;
            }

            set
            {
                _jurisdiccion = value;
            }
        }
       
        private string _jurisdiccion;
        //constructor vacio
        public DJurisdiccion() {  }

        //constructor con parametros 
        public DJurisdiccion (String id, String jurisdiccion)
        {
            this.Id = id;
            this.Jurisdiccion = jurisdiccion;
        }

        public DataTable  mostrar()
        {
            SqlConnection SqlCon = new SqlConnection();
            DataTable DataResultado = new DataTable("jurisdiccion");
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.CommandText = "spmostrar_jurisdiccion";

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DataResultado);
                
                }
            catch (Exception)
            {
                
                DataResultado = null;
            }

            return DataResultado;
        }
    }
}
