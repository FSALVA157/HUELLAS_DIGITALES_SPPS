using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace CapaDatos
{
   public class DHuellas
    {//inicio clase DHuellas
        private int _Clave;
        private long _Dni;
        private long _Prontuario;
        private int _Legajo;
        private int _Dedo;
        private byte[] _Huella;

        #region Atributos
        public int Clave
        {
            get
            {
                return _Clave;
            }

            set
            {
                _Clave = value;
            }
        }

        public long Dni
        {
            get
            {
                return _Dni;
            }

            set
            {
                _Dni = value;
            }
        }

        public long Prontuario
        {
            get
            {
                return _Prontuario;
            }

            set
            {
                _Prontuario = value;
            }
        }

        public int Legajo
        {
            get
            {
                return _Legajo;
            }

            set
            {
                _Legajo = value;
            }
        }

        public int Dedo
        {
            get
            {
                return _Dedo;
            }

            set
            {
                _Dedo = value;
            }
        }

        public byte[] Huella
        {
            get
            {
                return _Huella;
            }

            set
            {
                _Huella = value;
            }
        }

        #endregion Atributos

        #region Constructores
        //constructores
        public DHuellas() { }

        public DHuellas(int clave, long dni, long prontuario, int legajo, int dedo, byte[] huella)
        {
            this.Clave = clave;
            this.Dni = dni;
            this.Prontuario = prontuario;
            this.Legajo = legajo;
            this.Dedo = dedo;
            this.Huella = huella;
        }

        #endregion Constructores

        //metodos
        public string Insertar_Huella_Interno(DHuellas Obj)
        {//inicio metodo IHI
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.CommandText = "spinsertar_huella_judiciales";

                //parametros
                SqlParameter ParClave = new SqlParameter();
                ParClave.SqlDbType = SqlDbType.Int;
                ParClave.ParameterName = "@clave";
                ParClave.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParClave);

                SqlParameter ParProntuario = new SqlParameter();
                ParProntuario.SqlDbType = SqlDbType.BigInt;
                ParProntuario.ParameterName = "@prontuario";
                ParProntuario.Value = Obj.Prontuario;
                SqlCmd.Parameters.Add(ParProntuario);

                SqlParameter ParDedo = new SqlParameter();
                ParDedo.SqlDbType = SqlDbType.Int;
                ParDedo.ParameterName = "@dedo";
                ParDedo.Value = Obj.Dedo;
                SqlCmd.Parameters.Add(ParDedo);

                SqlParameter ParHuella = new SqlParameter();
                ParHuella.SqlDbType = SqlDbType.VarBinary;
                ParHuella.ParameterName = "@huella";
                ParHuella.Value = Obj.Huella;
                SqlCmd.Parameters.Add(ParHuella);

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "Error al Insertar el registro de huella dactilar";


            }
            catch (Exception ex)
            {

                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                {
                    SqlCon.Close();
                }
            }
            return rpta;
        }//fin metodo IHI

        public string Insertar_Huella_Civil(DHuellas Obj)
        {//inicio metodo IHC
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.CommandText = "spinsertar_huella_Ciudadanos";

                //parametros
                SqlParameter ParClave = new SqlParameter();
                ParClave.SqlDbType = SqlDbType.Int;
                ParClave.ParameterName = "@clave";
                ParClave.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParClave);

                SqlParameter ParCuil = new SqlParameter();
                ParCuil.SqlDbType = SqlDbType.BigInt;
                ParCuil.ParameterName = "@clave_personal";
                ParCuil.Value = Obj.Dni;
                SqlCmd.Parameters.Add(ParCuil);

                SqlParameter ParDedo = new SqlParameter();
                ParDedo.SqlDbType = SqlDbType.Int;
                ParDedo.ParameterName = "@dedo";
                ParDedo.Value = Obj.Dedo;
                SqlCmd.Parameters.Add(ParDedo);

                SqlParameter ParHuella = new SqlParameter();
                ParHuella.SqlDbType = SqlDbType.VarBinary;
                ParHuella.ParameterName = "@huella";
                ParHuella.Value = Obj.Huella;
                SqlCmd.Parameters.Add(ParHuella);

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "Error al Insertar el registro de huella dactilar";


            }
            catch (Exception ex)
            {

                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                {
                    SqlCon.Close();
                }
            }
            return rpta;
        }//fin metodo IHC

        public string Insertar_Huella_Personal(DHuellas Obj)
        {//inicio metodo IHP
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.CommandText = "spinsertar_huella_Personal";

                //parametros
                SqlParameter ParClave = new SqlParameter();
                ParClave.SqlDbType = SqlDbType.Int;
                ParClave.ParameterName = "@clave";
                ParClave.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParClave);

                SqlParameter ParLegajo = new SqlParameter();
                ParLegajo.SqlDbType = SqlDbType.BigInt;
                ParLegajo.ParameterName = "@legajo";
                ParLegajo.Value = Obj.Legajo;
                SqlCmd.Parameters.Add(ParLegajo);

                SqlParameter ParDedo = new SqlParameter();
                ParDedo.SqlDbType = SqlDbType.Int;
                ParDedo.ParameterName = "@dedo";
                ParDedo.Value = Obj.Dedo;
                SqlCmd.Parameters.Add(ParDedo);

                SqlParameter ParHuella = new SqlParameter();
                ParHuella.SqlDbType = SqlDbType.VarBinary;
                ParHuella.ParameterName = "@huella";
                ParHuella.Value = Obj.Huella;
                SqlCmd.Parameters.Add(ParHuella);

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "Error al Insertar el registro de huella dactilar";


            }
            catch (Exception ex)
            {

                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                {
                    SqlCon.Close();
                }
            }
            return rpta;
        }//fin metodo IHP


        public string Insertar_Cuil(DHuellas Obj)
        {//inicio metodo ICE
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.CommandText = "spinsertar_cuilEnHuellas";

                //parametros
                
                SqlParameter ParClave= new SqlParameter();
                ParClave.SqlDbType = SqlDbType.Int;
                ParClave.ParameterName = "@clave";
                ParClave.Value = Obj.Clave;
                SqlCmd.Parameters.Add(ParClave);

                SqlParameter ParCuil = new SqlParameter();
                ParCuil.SqlDbType = SqlDbType.BigInt;
                ParCuil.ParameterName = "@cuil";
                ParCuil.Value = Obj.Dni;
                SqlCmd.Parameters.Add(ParCuil);

                

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "Error al Actualizar el campo CUIL";


            }
            catch (Exception ex)
            {

                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                {
                    SqlCon.Close();
                }
            }
            return rpta;
        }//fin metodo IHP


        public string Insertar_Prontuario(DHuellas Obj)
        {//inicio metodo IP
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.CommandText = "spinsertar_prontuarioEnHuellas";

                //parametros

                SqlParameter ParClave = new SqlParameter();
                ParClave.SqlDbType = SqlDbType.Int;
                ParClave.ParameterName = "@clave";
                ParClave.Value = Obj.Clave;
                SqlCmd.Parameters.Add(ParClave);

                SqlParameter ParProntuario = new SqlParameter();
                ParProntuario.SqlDbType = SqlDbType.BigInt;
                ParProntuario.ParameterName = "@prontuario";
                ParProntuario.Value = Obj.Prontuario;
                SqlCmd.Parameters.Add(ParProntuario);



                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "Error al Actualizar el campo PRONTUARIO";


            }
            catch (Exception ex)
            {

                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                {
                    SqlCon.Close();
                }
            }
            return rpta;
        }//fin metodo IP


        public string Insertar_Legajo(DHuellas Obj)
        {//inicio metodo IL
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.CommandText = "spinsertar_legajoEnHuellas";

                //parametros

                SqlParameter ParClave = new SqlParameter();
                ParClave.SqlDbType = SqlDbType.Int;
                ParClave.ParameterName = "@clave";
                ParClave.Value = Obj.Clave;
                SqlCmd.Parameters.Add(ParClave);

                SqlParameter ParLegajo = new SqlParameter();
                ParLegajo.SqlDbType = SqlDbType.Int;
                ParLegajo.ParameterName = "@legajo";
                ParLegajo.Value = Obj.Legajo;
                SqlCmd.Parameters.Add(ParLegajo);



                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "Error al Actualizar el campo LEGAJO";


            }
            catch (Exception ex)
            {

                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                {
                    SqlCon.Close();
                }
            }
            return rpta;
        }//fin metodo IL

        public DataTable GeneraDedo(DHuellas Obj)
        {//inicio GeneraDedo
            DataTable dtResultado = new DataTable("huellas");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.CommandText = "spHuellasFromVisitas";

                //parametros

                SqlParameter ParCuil = new SqlParameter();
                ParCuil.SqlDbType = SqlDbType.Int;
                ParCuil.ParameterName = "@dni";
                ParCuil.Value = Obj.Dni;
                SqlCmd.Parameters.Add(ParCuil);

                //Ejecución de la Consulta
                SqlDataAdapter sqlDat = new SqlDataAdapter(SqlCmd);
                sqlDat.Fill(dtResultado);
                


            }
            catch (Exception ex)
            {

                dtResultado = null;
            }
            return dtResultado;
        }//fin GeneraDedo


    }//fin clase DHuellas
}
