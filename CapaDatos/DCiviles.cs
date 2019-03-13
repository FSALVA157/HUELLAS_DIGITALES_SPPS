using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    #region ATRIBUTOS Y PROPIEDADES
    public class DCiviles
    {//inicio clase DCiviles
        private long _cuil;
        public long Cuil
        {
            get { return _cuil; }

            set { _cuil = value; }
        }

        

        private string _apellido;
        public string Apellido
        {
            get { return _apellido; }

            set { _apellido = value; }
        }
        private string _nombre;
        public string Nombre
        {
            get { return _nombre; }

            set { _nombre = value; }
        }
        private byte[] _foto;
        public byte[] Foto
        {
            get { return _foto; }
            set { _foto = value; }
        }
        
        private int _sexo;
        public int Sexo
        {
            get { return _sexo; }

            set { _sexo = value; }
        }

        private string _domicilio;
        public string Domicilio
        {
            get { return _domicilio; }
            set { _domicilio = value; }
        }

        private int _barrio;
        public int Barrio
        {
            get { return _barrio; }
            set { _barrio = value; }
        }

        private int _provincia;
        public int Provincia
        {
            get { return _provincia; }
            set { _provincia = value; }
        }
        private DateTime _fecha_Nacimiento;
        public DateTime Fecha_Nacimiento
        {
            get { return _fecha_Nacimiento; }
            set { _fecha_Nacimiento = value; }
        }

        #endregion ATRIBUTOS Y PROPIEDADES
        //constructor vacio
        #region CONSTRUCTORES
        public DCiviles() { }
        //constructor con parametros
        public DCiviles(long cuil,string apellido, string nombre, byte[] foto, int sexo,
            string domicilio, int barrio, int provincia, DateTime fecha_nacimiento)
        {//inicio constructor con parametros
            this.Cuil = cuil;
            this.Apellido = apellido;
            this.Nombre = nombre;
            this.Foto = foto;
            this.Sexo = sexo;
            this.Domicilio = domicilio;
            this.Barrio = barrio;
            this.Provincia = provincia;
            this.Fecha_Nacimiento = fecha_nacimiento;

        }//fin constructor con parametros

        #endregion CONSTRUCTORES
        //metodo insertar
        public string Insertar(DCiviles Civil)
        {//inicio metodo insertar
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                //conexion a procedimiento almacenado
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spinsertar_civil";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //parametro cuil
                SqlParameter ParCuil = new SqlParameter();
                ParCuil.SqlDbType = SqlDbType.BigInt;
                ParCuil.ParameterName = "@cuil";
                ParCuil.Value = Civil.Cuil;
                SqlCmd.Parameters.Add(ParCuil);

                
                //parametro apellido
                SqlParameter ParApellido = new SqlParameter();
                ParApellido.ParameterName = "@apellido";
                ParApellido.SqlDbType = SqlDbType.VarChar;
                ParApellido.Size = 100;
                ParApellido.Value = Civil.Apellido;
                SqlCmd.Parameters.Add(ParApellido);

                //parametro nombre
                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 100;
                ParNombre.Value = Civil.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                //parametro foto
                SqlParameter ParFoto = new SqlParameter();
                ParFoto.ParameterName = "@foto";
                ParFoto.SqlDbType = SqlDbType.Image;
                ParFoto.Value = Civil.Foto;
                SqlCmd.Parameters.Add(ParFoto);

                
                //parametro sexo
                SqlParameter ParSexo = new SqlParameter();
                ParSexo.ParameterName = "@sexo";
                ParSexo.SqlDbType = SqlDbType.Int;
                ParSexo.Value = Civil.Sexo;
                SqlCmd.Parameters.Add(ParSexo);

                //parametro domicilio
                SqlParameter ParDomicilio= new SqlParameter();
                ParDomicilio.ParameterName = "@domicilio";
                ParDomicilio.SqlDbType = SqlDbType.VarChar;
                ParDomicilio.Size = 150;
                ParDomicilio.Value = Civil.Domicilio;
                SqlCmd.Parameters.Add(ParDomicilio);

                //parametro barrio
                SqlParameter ParBarrio = new SqlParameter();
                ParBarrio.ParameterName = "@barrio";
                ParBarrio.SqlDbType = SqlDbType.Int;
                ParBarrio.Value = Civil.Barrio;
                SqlCmd.Parameters.Add(ParBarrio);

                //parametro provincia
                SqlParameter ParProvincia= new SqlParameter();
                ParProvincia.ParameterName = "@provincia";
                ParProvincia.SqlDbType = SqlDbType.Int;
                ParProvincia.Value = Civil.Provincia;
                SqlCmd.Parameters.Add(ParProvincia);

                //parametro fecha nacimiento
                SqlParameter ParNacimiento = new SqlParameter();
                ParNacimiento.ParameterName = "@fecha_nacimiento";
                ParNacimiento.SqlDbType = SqlDbType.Date;
                ParNacimiento.Value = Civil.Fecha_Nacimiento;
                SqlCmd.Parameters.Add(ParNacimiento);

                //ejecucion del procedimiento almacenado
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "Registro Agregado sin Errores" : "No se Agrego el Registro!!";
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
        }//fin metodo insertar

        //Metodo buscar ciudadano

        public DataTable BuscarXCuil(DCiviles Civil)
        {//inicio metodo buscar ciudadano
            DataTable DtResultado = new DataTable("civiles");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;

                //conexion a procedimiento almacenado
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.CommandText = "spbuscar_civil";

                //parametro prontuario
                SqlParameter ParCuil = new SqlParameter();
                ParCuil.ParameterName = "@cuil";
                ParCuil.SqlDbType = SqlDbType.BigInt;
                ParCuil.Value = Civil.Cuil;
                SqlCmd.Parameters.Add(ParCuil);

                //ejecucion de la consulta
                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;
            }

            return DtResultado;

        }//fin metodo buscar ciudadano

        public string editar(DCiviles Civil)
        {
            string rpta = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = Conexion.Cn;
                sqlCon.Open();

                //inicio trabajo con procedimiento almacenado
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = sqlCon;
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.CommandText = "speditar_civiles";

                //parametro cuil
                SqlParameter ParCuil = new SqlParameter();
                ParCuil.SqlDbType = SqlDbType.BigInt;
                ParCuil.ParameterName = "@cuil";
                ParCuil.Value = Civil.Cuil;
                SqlCmd.Parameters.Add(ParCuil);


                //parametro apellido
                SqlParameter ParApellido = new SqlParameter();
                ParApellido.ParameterName = "@apellido";
                ParApellido.SqlDbType = SqlDbType.VarChar;
                ParApellido.Size = 100;
                ParApellido.Value = Civil.Apellido;
                SqlCmd.Parameters.Add(ParApellido);

                //parametro nombre
                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 100;
                ParNombre.Value = Civil.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                //parametro foto
                SqlParameter ParFoto = new SqlParameter();
                ParFoto.ParameterName = "@foto";
                ParFoto.SqlDbType = SqlDbType.Image;
                ParFoto.Value = Civil.Foto;
                SqlCmd.Parameters.Add(ParFoto);


                //parametro sexo
                SqlParameter ParSexo = new SqlParameter();
                ParSexo.ParameterName = "@sexo";
                ParSexo.SqlDbType = SqlDbType.Int;
                ParSexo.Value = Civil.Sexo;
                SqlCmd.Parameters.Add(ParSexo);

                //parametro domicilio
                SqlParameter ParDomicilio = new SqlParameter();
                ParDomicilio.ParameterName = "@domicilio";
                ParDomicilio.SqlDbType = SqlDbType.VarChar;
                ParDomicilio.Size = 150;
                ParDomicilio.Value = Civil.Domicilio;
                SqlCmd.Parameters.Add(ParDomicilio);

                //parametro barrio
                SqlParameter ParBarrio = new SqlParameter();
                ParBarrio.ParameterName = "@barrio";
                ParBarrio.SqlDbType = SqlDbType.Int;
                ParBarrio.Value = Civil.Barrio;
                SqlCmd.Parameters.Add(ParBarrio);

                //parametro provincia
                SqlParameter ParProvincia = new SqlParameter();
                ParProvincia.ParameterName = "@provincia";
                ParProvincia.SqlDbType = SqlDbType.Int;
                ParProvincia.Value = Civil.Provincia;
                SqlCmd.Parameters.Add(ParProvincia);

                //parametro fecha nacimiento
                SqlParameter ParNacimiento = new SqlParameter();
                ParNacimiento.ParameterName = "@fecha_nacimiento";
                ParNacimiento.SqlDbType = SqlDbType.Date;
                ParNacimiento.Value = Civil.Fecha_Nacimiento;
                SqlCmd.Parameters.Add(ParNacimiento);


                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "ERROR EN LA EDICION DE LOS DATOS SELECCIONADOS";

            }
            catch (Exception ex)
            {

                rpta = ex.Message;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                {
                    sqlCon.Close();
                }
            }
            return rpta;
        }




    }//fin clase DCiviles
}
