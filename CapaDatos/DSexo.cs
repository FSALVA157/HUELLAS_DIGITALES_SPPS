using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
   public class DSexo
    {//inicio clase Dsexo
        private int _id;
        public int Id {
            get {return _id; }

            set { _id = value; }
        }

        

        private string _sexo;
        public string Sexo
        {
            get { return _sexo; }

            set
            {
                _sexo = value;
            }
        }



        //constructor vacio
        public DSexo() {
        }
        //constructor con parametros
        public DSexo(int id, string sexo)
        {
            this.Id = id;
            this.Sexo = sexo;

         }

        public DataTable mostrar()
        {//inicio metodo mostrar
            SqlConnection SqlCon = new SqlConnection();
            DataTable DataResultado = new DataTable("sexo");
            
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;

                //inicio procedimiento almacenado
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.CommandText = "spmostrar_sexo";

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DataResultado);
            }
            catch (Exception ex)
            {
                DataResultado = null;
            }
            return DataResultado;
 


        }//fin metodo mostrar


       
    }//fin clase Dsexo
}
