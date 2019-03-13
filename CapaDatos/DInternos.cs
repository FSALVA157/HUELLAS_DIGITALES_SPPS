using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{//inicio espacio de nombre
    public class DInternos
    {//inicio clase DInternos
        private int _id;
        public int Id
        {
            get { return _id; }

            set { _id = value; }
        }

        private long _prontuario;
        public long Prontuario
        {
            get { return _prontuario; }

            set { _prontuario = value; }
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
        private byte[] _foto_Perfil;
        public byte[] Foto_Perfil
        {
            get
            {
                return _foto_Perfil;
            }
            set
            {
                _foto_Perfil = value;
            }
        }

        private string _sexo;
        public string Sexo
        {
            get { return _sexo; }

            set { _sexo = value; }
        }

        private string _jurisdiccion;
        public string Jurisdiccion
        {
            get { return _jurisdiccion; }
            set { _jurisdiccion = value; }
        }

        private string _estado_procesal;
        public string Estado_procesal
        {
            get { return _estado_procesal; }
            set { _estado_procesal = value; }
        }

        private string _causa;
        public string Causa
        {
            get { return _causa; }
            set { _causa = value; }
        }
        //constructor vacio
        public DInternos(){    }
        //constructor con parametros
        public DInternos(int id, long prontuario, string apellido, string nombre, byte[] foto, string sexo, string jurisdiccion, 
            string estado_procesal, string causa)
        {//inicio constructor con parametros
            this.Id = id;
            this.Prontuario = prontuario;
            this.Apellido = apellido;
            this.Nombre = nombre;
            this.Foto = foto;
            this.Sexo = sexo;
            this.Jurisdiccion = jurisdiccion;
            this.Estado_procesal = estado_procesal;

        }//fin constructor con parametros


        //metodo insertar
        public string Insertar(DInternos Interno)
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
                SqlCmd.CommandText = "spinsertar_interno";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //parametro id
                SqlParameter ParId = new SqlParameter();
                ParId.SqlDbType = SqlDbType.Int;
                ParId.ParameterName = "@id";
                ParId.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParId);

                //parametro prontuario
                SqlParameter ParProntuario = new SqlParameter();
                ParProntuario.ParameterName = "@prontuario";
                ParProntuario.SqlDbType = SqlDbType.BigInt;
                ParProntuario.Value = Interno.Prontuario;
                SqlCmd.Parameters.Add(ParProntuario);

                //parametro apellido
                SqlParameter ParApellido = new SqlParameter();
                ParApellido.ParameterName = "@apellido";
                ParApellido.SqlDbType = SqlDbType.VarChar;
                ParApellido.Size = 50;
                ParApellido.Value = Interno.Apellido;
                SqlCmd.Parameters.Add(ParApellido);

                //parametro nombre
                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Interno.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

               //parametro foto
                SqlParameter ParFoto = new SqlParameter();
                ParFoto.ParameterName = "@foto_frente";
                ParFoto.SqlDbType = SqlDbType.Image;
                ParFoto.Value = Interno.Foto;
                SqlCmd.Parameters.Add(ParFoto);

                //parametro foto perfil
                SqlParameter ParFotoPerfil = new SqlParameter();
                ParFotoPerfil.ParameterName = "@foto_perfil";
                ParFotoPerfil.SqlDbType = SqlDbType.Image;
                ParFotoPerfil.Value = Interno.Foto_Perfil;
                SqlCmd.Parameters.Add(ParFotoPerfil);

                //parametro sexo
                SqlParameter ParSexo = new SqlParameter();
                ParSexo.ParameterName = "@sexo";
                ParSexo.SqlDbType = SqlDbType.Char;
                ParSexo.Size = 1;
                ParSexo.Value = Interno.Sexo;
                SqlCmd.Parameters.Add(ParSexo);
                
                //parametro jurisdiccion
                SqlParameter ParJurisdiccion = new SqlParameter();
                ParJurisdiccion.ParameterName = "@jurisdiccion";
                ParJurisdiccion.SqlDbType = SqlDbType.VarChar;
                ParJurisdiccion.Size = 2;
                ParJurisdiccion.Value = Interno.Jurisdiccion;
                SqlCmd.Parameters.Add(ParJurisdiccion);

                //parametro estado_procesal
                SqlParameter ParEstadoProcesal = new SqlParameter();
                ParEstadoProcesal.ParameterName = "@estado_procesal";
                ParEstadoProcesal.SqlDbType = SqlDbType.Char;
                ParEstadoProcesal.Size = 2;
                ParEstadoProcesal.Value = Interno.Estado_procesal;
                SqlCmd.Parameters.Add(ParEstadoProcesal);

                //parametro causa
                SqlParameter ParCausa = new SqlParameter();
                ParCausa.ParameterName = "@causa";
                ParCausa.SqlDbType = SqlDbType.VarChar;
                ParCausa.Size = 200;
                ParCausa.Value = Interno.Causa;
                SqlCmd.Parameters.Add(ParCausa);

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

        //Metodo buscar por prontuario

        public DataTable BuscarXProntuario(DInternos Interno)
        {//inicio metodo buscar prontuario
            DataTable DtResultado = new DataTable("Interno");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;

                //conexion a procedimiento almacenado
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.CommandText = "spbuscar_interno";

                //parametro prontuario
                SqlParameter ParProntuario = new SqlParameter();
                ParProntuario.ParameterName = "@prontuario";
                ParProntuario.SqlDbType = SqlDbType.BigInt;
                ParProntuario.Value = Interno.Prontuario;
                SqlCmd.Parameters.Add(ParProntuario);

                //ejecucion de la consulta
                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch(Exception ex)
            {
                DtResultado = null;
            }

            return DtResultado;

        }//fin metodo buscarprontuario

        public string editar(DInternos interno)
        {
            string rpta = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = Conexion.Cn;
                sqlCon.Open();

                //inicio trabajo con procedimiento almacenado
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "speditar_interno";

                SqlParameter ParProntuario = new SqlParameter();
                ParProntuario.ParameterName = "@prontuario";
                ParProntuario.SqlDbType = SqlDbType.BigInt;
                ParProntuario.Value = interno.Prontuario;
                sqlCmd.Parameters.Add(ParProntuario);

                SqlParameter ParApellido = new SqlParameter();
                ParApellido.SqlDbType = SqlDbType.VarChar;
                ParApellido.Size = 50;
                ParApellido.ParameterName = "@apellidos";
                ParApellido.Value = interno.Apellido;
                sqlCmd.Parameters.Add(ParApellido);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.ParameterName = "@nombres";
                ParNombre.Value = interno.Nombre;
                sqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParFoto = new SqlParameter();
                ParFoto.ParameterName = "@foto_frente";
                ParFoto.SqlDbType = SqlDbType.Image;
                ParFoto.Value = interno.Foto;
                sqlCmd.Parameters.Add(ParFoto);

                SqlParameter ParFotoPerfil = new SqlParameter();
                ParFotoPerfil.ParameterName = "@foto_perfil";
                ParFotoPerfil.SqlDbType = SqlDbType.Image;
                ParFotoPerfil.Value = interno.Foto_Perfil;
                sqlCmd.Parameters.Add(ParFotoPerfil);

                SqlParameter ParSexo = new SqlParameter();
                ParSexo.ParameterName = "@sexo";
                ParSexo.SqlDbType = SqlDbType.Char;
                ParSexo.Size = 1;
                ParSexo.Value = interno.Sexo;
                sqlCmd.Parameters.Add(ParSexo);

                SqlParameter ParJurisdiccion = new SqlParameter();
                ParJurisdiccion.SqlDbType = SqlDbType.Char;
                ParJurisdiccion.Size = 2;
                ParJurisdiccion.ParameterName = "@jurisdiccion";
                ParJurisdiccion.Value = interno.Jurisdiccion;
                sqlCmd.Parameters.Add(ParJurisdiccion);

                SqlParameter ParEstadoProcesal = new SqlParameter();
                ParEstadoProcesal.SqlDbType = SqlDbType.Char;
                ParEstadoProcesal.Size = 2;
                ParEstadoProcesal.ParameterName = "@estado_procesal";
                ParEstadoProcesal.Value = interno.Estado_procesal;
                sqlCmd.Parameters.Add(ParEstadoProcesal);

                SqlParameter ParCausa = new SqlParameter();
                ParCausa.SqlDbType = SqlDbType.VarChar;
                ParCausa.Size = 200;
                ParCausa.ParameterName = "@causa";
                ParCausa.Value = interno.Causa;
                sqlCmd.Parameters.Add(ParCausa);

                rpta = sqlCmd.ExecuteNonQuery() == 1 ? "OK": "LA EDICION DE LOS DATOS ";

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

    }//fin clase DInternos
}// fin espacio de nombre
