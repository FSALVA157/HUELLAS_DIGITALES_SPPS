using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DPersonal
    {//inicio clase DPersonal

        #region ATRIBUTOS Y PROPIEDADES

        private int _legajo;
        public int Legajo
        {
            get { return _legajo; }

            set { _legajo = value; }
        }
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

        private int _destino;
        public int Destino
        {
            get { return _destino; }
            set { _destino = value; }
        }


        private int _grado;
        public int Grado
        {
            get { return _grado; }
            set { _grado = value; }
        }


        private int _escalafon;
        public int Escalafon
        {
            get { return _escalafon; }
            set { _escalafon= value; }
        }


        private DateTime _fecha_Ingreso;
        public DateTime Fecha_Ingreso
        {
            get { return _fecha_Ingreso; }
            set { _fecha_Ingreso= value; }
        }

        private int _antiguedad;
        public int Antiguedad
        {
            get { return _antiguedad; }
            set { _antiguedad = value; }
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
            public DPersonal() { }
            //constructor con parametros
            public DPersonal(int legajo,long cuil, string apellido, string nombre, byte[] foto, int sexo,
                string domicilio, int barrio, int provincia, int destino, int grado, int escalafon, DateTime fecha_ingreso,
                int antiguedad, DateTime fecha_nacimiento)
            {//inicio constructor con parametros
                this.Cuil = cuil;
                this.Apellido = apellido;
                this.Nombre = nombre;
                this.Foto = foto;
                this.Sexo = sexo;
                this.Domicilio = domicilio;
                this.Barrio = barrio;
                this.Provincia = provincia;
                this.Destino = destino;
                this.Grado = grado;
                this.Escalafon = escalafon;
                this.Fecha_Ingreso = fecha_ingreso;
                this.Antiguedad = antiguedad;
                this.Fecha_Nacimiento = fecha_nacimiento;

            }//fin constructor con parametros

            #endregion CONSTRUCTORES
            //metodo insertar
            public string Insertar(DPersonal Personal)
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
                    SqlCmd.CommandText = "spinsertar_personal";
                    SqlCmd.CommandType = CommandType.StoredProcedure;

                //parametro legajo
                SqlParameter ParLegajo = new SqlParameter();
                ParLegajo.SqlDbType = SqlDbType.BigInt;
                ParLegajo.ParameterName = "@legajo";
                ParLegajo.Value = Personal.Legajo;
                SqlCmd.Parameters.Add(ParLegajo);

                //parametro cuil
                SqlParameter ParCuil = new SqlParameter();
                    ParCuil.SqlDbType = SqlDbType.BigInt;
                    ParCuil.ParameterName = "@cuil";
                    ParCuil.Value = Personal.Cuil;
                    SqlCmd.Parameters.Add(ParCuil);


                    //parametro apellido
                    SqlParameter ParApellido = new SqlParameter();
                    ParApellido.ParameterName = "@apellido";
                    ParApellido.SqlDbType = SqlDbType.VarChar;
                    ParApellido.Size = 100;
                    ParApellido.Value = Personal.Apellido;
                    SqlCmd.Parameters.Add(ParApellido);

                    //parametro nombre
                    SqlParameter ParNombre = new SqlParameter();
                    ParNombre.ParameterName = "@nombre";
                    ParNombre.SqlDbType = SqlDbType.VarChar;
                    ParNombre.Size = 100;
                    ParNombre.Value = Personal.Nombre;
                    SqlCmd.Parameters.Add(ParNombre);

                    //parametro foto
                    SqlParameter ParFoto = new SqlParameter();
                    ParFoto.ParameterName = "@foto";
                    ParFoto.SqlDbType = SqlDbType.Image;
                    ParFoto.Value = Personal.Foto;
                    SqlCmd.Parameters.Add(ParFoto);


                    //parametro sexo
                    SqlParameter ParSexo = new SqlParameter();
                    ParSexo.ParameterName = "@sexo";
                    ParSexo.SqlDbType = SqlDbType.Int;
                    ParSexo.Value = Personal.Sexo;
                    SqlCmd.Parameters.Add(ParSexo);

                    //parametro domicilio
                    SqlParameter ParDomicilio = new SqlParameter();
                    ParDomicilio.ParameterName = "@domicilio";
                    ParDomicilio.SqlDbType = SqlDbType.VarChar;
                    ParDomicilio.Size = 150;
                    ParDomicilio.Value = Personal.Domicilio;
                    SqlCmd.Parameters.Add(ParDomicilio);

                    //parametro barrio
                    SqlParameter ParBarrio = new SqlParameter();
                    ParBarrio.ParameterName = "@barrio";
                    ParBarrio.SqlDbType = SqlDbType.Int;
                    ParBarrio.Value = Personal.Barrio;
                    SqlCmd.Parameters.Add(ParBarrio);

                    //parametro provincia
                    SqlParameter ParProvincia = new SqlParameter();
                    ParProvincia.ParameterName = "@provincia";
                    ParProvincia.SqlDbType = SqlDbType.Int;
                    ParProvincia.Value = Personal.Provincia;
                    SqlCmd.Parameters.Add(ParProvincia);

                //parametro destino
                SqlParameter ParDestino = new SqlParameter();
                ParDestino.ParameterName = "@destino";
                ParDestino.SqlDbType = SqlDbType.Int;
                ParDestino.Value = Personal.Provincia;
                SqlCmd.Parameters.Add(ParDestino);

                //parametro grado
                SqlParameter ParGrado = new SqlParameter();
                ParGrado.ParameterName = "@grado";
                ParGrado.SqlDbType = SqlDbType.Int;
                ParGrado.Value = Personal.Provincia;
                SqlCmd.Parameters.Add(ParGrado);

                SqlParameter ParEscalafon= new SqlParameter();
                ParEscalafon.ParameterName = "@escalafon";
                ParEscalafon.SqlDbType = SqlDbType.Int;
                ParEscalafon.Value = Personal.Provincia;
                SqlCmd.Parameters.Add(ParEscalafon);

                //parametro fecha ingreso
                SqlParameter ParIngreso= new SqlParameter();
                ParIngreso.ParameterName = "@fecha_ingreso";
                ParIngreso.SqlDbType = SqlDbType.VarChar;
                ParIngreso.Size = 50;
                ParIngreso.Value = Personal.Fecha_Ingreso;
                SqlCmd.Parameters.Add(ParIngreso);

                //antiguedad
                SqlParameter ParAntiguedad = new SqlParameter();
                ParAntiguedad.ParameterName = "@antiguedad";
                ParAntiguedad.SqlDbType = SqlDbType.Int;
                ParAntiguedad.Value = Personal.Antiguedad;
                SqlCmd.Parameters.Add(ParAntiguedad);


                //parametro fecha nacimiento
                SqlParameter ParNacimiento = new SqlParameter();
                    ParNacimiento.ParameterName = "@fecha_nacimiento";
                    ParNacimiento.SqlDbType = SqlDbType.VarChar;
                    ParNacimiento.Size = 50;
                    ParNacimiento.Value = Personal.Fecha_Nacimiento;
                    SqlCmd.Parameters.Add(ParNacimiento);

                    //ejecucion del procedimiento almacenado
                    rpta = SqlCmd.ExecuteNonQuery() == 1 ? "Registro Agregado sin Errores" : "No se Agrego el Registro!!";
                }
                catch (Exception ex)
                {
                    rpta = "Error en el metodo insertar de la capa de datos de Personal" + ex.Message + ex.StackTrace;
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

            //Metodo buscar personal

            public DataTable BuscarXLegajo(DPersonal Personal)
            {//inicio metodo buscar ciudadano
                DataTable DtResultado = new DataTable("personal");
                SqlConnection SqlCon = new SqlConnection();
                try
                {
                    SqlCon.ConnectionString = Conexion.Cn;

                    //conexion a procedimiento almacenado
                    SqlCommand SqlCmd = new SqlCommand();
                    SqlCmd.Connection = SqlCon;
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.CommandText = "spbuscar_personal";

                    //parametro prontuario
                    SqlParameter ParLegajo= new SqlParameter();
                    ParLegajo.ParameterName = "@legajo";
                    ParLegajo.SqlDbType = SqlDbType.Int;
                    ParLegajo.Value = Personal.Legajo;
                    SqlCmd.Parameters.Add(ParLegajo);

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

            public string editar(DPersonal Personal)
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
                    SqlCmd.CommandText = "speditar_personal";


                //parametro legajo
                SqlParameter ParLegajo = new SqlParameter();
                ParLegajo.SqlDbType = SqlDbType.BigInt;
                ParLegajo.ParameterName = "@legajo";
                ParLegajo.Value = Personal.Legajo;
                SqlCmd.Parameters.Add(ParLegajo);

                //parametro cuil
                SqlParameter ParCuil = new SqlParameter();
                ParCuil.SqlDbType = SqlDbType.BigInt;
                ParCuil.ParameterName = "@cuil";
                ParCuil.Value = Personal.Cuil;
                SqlCmd.Parameters.Add(ParCuil);


                //parametro apellido
                SqlParameter ParApellido = new SqlParameter();
                ParApellido.ParameterName = "@apellido";
                ParApellido.SqlDbType = SqlDbType.VarChar;
                ParApellido.Size = 100;
                ParApellido.Value = Personal.Apellido;
                SqlCmd.Parameters.Add(ParApellido);

                //parametro nombre
                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 100;
                ParNombre.Value = Personal.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                //parametro foto
                SqlParameter ParFoto = new SqlParameter();
                ParFoto.ParameterName = "@foto";
                ParFoto.SqlDbType = SqlDbType.Image;
                ParFoto.Value = Personal.Foto;
                SqlCmd.Parameters.Add(ParFoto);


                //parametro sexo
                SqlParameter ParSexo = new SqlParameter();
                ParSexo.ParameterName = "@sexo";
                ParSexo.SqlDbType = SqlDbType.Int;
                ParSexo.Value = Personal.Sexo;
                SqlCmd.Parameters.Add(ParSexo);

                //parametro domicilio
                SqlParameter ParDomicilio = new SqlParameter();
                ParDomicilio.ParameterName = "@domicilio";
                ParDomicilio.SqlDbType = SqlDbType.VarChar;
                ParDomicilio.Size = 150;
                ParDomicilio.Value = Personal.Domicilio;
                SqlCmd.Parameters.Add(ParDomicilio);

                //parametro barrio
                SqlParameter ParBarrio = new SqlParameter();
                ParBarrio.ParameterName = "@barrio";
                ParBarrio.SqlDbType = SqlDbType.Int;
                ParBarrio.Value = Personal.Barrio;
                SqlCmd.Parameters.Add(ParBarrio);

                //parametro provincia
                SqlParameter ParProvincia = new SqlParameter();
                ParProvincia.ParameterName = "@provincia";
                ParProvincia.SqlDbType = SqlDbType.Int;
                ParProvincia.Value = Personal.Provincia;
                SqlCmd.Parameters.Add(ParProvincia);

                //parametro destino
                SqlParameter ParDestino = new SqlParameter();
                ParDestino.ParameterName = "@destino";
                ParDestino.SqlDbType = SqlDbType.Int;
                ParDestino.Value = Personal.Provincia;
                SqlCmd.Parameters.Add(ParDestino);

                //parametro grado
                SqlParameter ParGrado = new SqlParameter();
                ParGrado.ParameterName = "@grado";
                ParGrado.SqlDbType = SqlDbType.Int;
                ParGrado.Value = Personal.Provincia;
                SqlCmd.Parameters.Add(ParGrado);

                SqlParameter ParEscalafon = new SqlParameter();
                ParEscalafon.ParameterName = "@escalafon";
                ParEscalafon.SqlDbType = SqlDbType.Int;
                ParEscalafon.Value = Personal.Provincia;
                SqlCmd.Parameters.Add(ParEscalafon);

                //parametro fecha ingreso
                SqlParameter ParIngreso = new SqlParameter();
                ParIngreso.ParameterName = "@fecha_ingreso";
                ParIngreso.SqlDbType = SqlDbType.Date;
                ParIngreso.Value = Personal.Fecha_Ingreso;
                SqlCmd.Parameters.Add(ParIngreso);

                //antiguedad
                SqlParameter ParAntiguedad = new SqlParameter();
                ParAntiguedad.ParameterName = "@antiguedad";
                ParAntiguedad.SqlDbType = SqlDbType.Int;
                ParAntiguedad.Value = Personal.Antiguedad;
                SqlCmd.Parameters.Add(ParEscalafon);


                //parametro fecha nacimiento
                SqlParameter ParNacimiento = new SqlParameter();
                ParNacimiento.ParameterName = "@fecha_nacimiento";
                ParNacimiento.SqlDbType = SqlDbType.Date;
                ParNacimiento.Value = Personal.Fecha_Nacimiento;
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





        }//fin clase DPersonal
    }
