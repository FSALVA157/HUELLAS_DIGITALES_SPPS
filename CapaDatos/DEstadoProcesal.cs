using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DEstadoProcesal
    {//inicio clase principal
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

        private string _estado;

        public string Estado
        {
            get
            {
                return _estado;
            }

            set
            {
                _estado = value;
            }
        }

       
        //constructor vacio
        public DEstadoProcesal() { }
        //constructor con parametros
        public DEstadoProcesal(String id, String estado)
        {//inicio constructor
            this.Id = id;
            this.Estado = estado;
        }//fin constructor

        public DataTable mostrar()
        {
            SqlConnection SqlCon = new SqlConnection();
            DataTable DataResultado = new DataTable("estado_procesal");
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;

                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.CommandText = "spmostrar_estado";

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DataResultado);


            }
            catch (Exception)
            {

                DataResultado = null;
            }
            return DataResultado;
        }


    }//fin clase principal
}
