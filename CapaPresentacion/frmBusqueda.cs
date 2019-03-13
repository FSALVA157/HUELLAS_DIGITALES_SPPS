using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DPFP;
using DPFP.Verification;

using DPFP.Capture;
using System.Data.SqlClient;
using DPFP.Gui.Verification;
using System.Data.SqlClient;
using CapaNegocio;
using System.IO;
using System.Drawing.Imaging;

namespace CapaPresentacion
{
       

    public partial class frmBusqueda : Form,DPFP.Capture.EventHandler
    {
        private DPFP.Capture.Capture captura;
        private DPFP.Verification.Verification verificador;
        private DPFP.Template template;
        delegate void Function();
        public delegate void cerrarFormulario();
        private static frmBusqueda _Instancia;
        string clave_huella = "";


        public static frmBusqueda getInstancia()
        {
            if ((_Instancia == null)|| (_Instancia.IsDisposed)){
                _Instancia = new frmBusqueda();
            }
            _Instancia.BringToFront();
            return _Instancia;
        }
        private frmBusqueda()
        {
            InitializeComponent();
        }

        protected virtual void Init()
        {
            try
            {
                captura = new DPFP.Capture.Capture();
                if(captura != null){
                    captura.EventHandler = this;
                    verificador = new DPFP.Verification.Verification();
                }else
                {
                    this.mensajeError("Error al instanciar la captura de huella digital");
                }
            }
            catch (Exception)
            {

                this.mensajeError("No se pudo iniciar el dispositivo de lectura de huella digital");
            }
        }

        /*
        public void Cerrar()
        {
            this.DetenerCaptura();
            this.Close();
        }*/

        protected void IniciarCaptura()
        {//inicio iniciar_captura
            if(captura != null)
            {
                try
                {
                    captura.StartCapture();
                    MakeReport("Iniciada la captura de Huella Digital");

                }
                catch (Exception)
                {

                    MakeReport("Error al capturar huella digital");
                }
            }            
        }//fin metodo iniciar_captura

        protected void DetenerCaptura()
        {//inicio detener
            if (captura != null)
            {
                try
                {
                    captura.StopCapture();
                    MakeReport("Se ha detenido la captura de huella digital");
                }
                catch (Exception)
                {

                    MakeReport("Error al detener la captura de huella");
                }
            }
        }//fin detener
        public Bitmap ConvertirSampleEnBitmap(Sample sample)
        {
            Bitmap bitmap = null;
            DPFP.Capture.SampleConversion conversor = new SampleConversion();
            conversor.ConvertToPicture(sample, ref bitmap);
            return bitmap;
        }

        public FeatureSet ExtraerMinucias(Sample sample, DPFP.Processing.DataPurpose purpose)
        {//inicio extraer minucias
            FeatureSet minucias = new FeatureSet();
            DPFP.Capture.CaptureFeedback calidad = CaptureFeedback.None;
            DPFP.Processing.FeatureExtraction extractor = new DPFP.Processing.FeatureExtraction();
            extractor.CreateFeatureSet(sample,purpose,ref calidad,ref minucias);
            if(calidad == CaptureFeedback.Good)
            {
                return minucias;
            }else
            {
                return null;
            }

        }//fin extraer minucias

        

        #region METODOS DELEGADOS
        private void DibujarImagen(Bitmap imagenHuella)
        {
            this.Invoke(new Function(delegate(){ this.imgHuella.Image = new Bitmap(imagenHuella, this.imgHuella.Size); } ));
        }
        private void CrearArchivoImagen(Bitmap imagenHuella,string archivo)
        {
            string nom = "";
            //Bitmap myBitmap;
            ImageCodecInfo myImageCodecInfo;
            System.Drawing.Imaging.Encoder myEncoder;
            EncoderParameter myEncoderParameter;
            EncoderParameters myEncoderParameters;

            // Create a Bitmap object based on a BMP file.
            //myBitmap = new Bitmap("Shapes.bmp");

            // Get an ImageCodecInfo object that represents the JPEG codec.
            myImageCodecInfo = GetEncoderInfo("image/jpeg");

            // Create an Encoder object based on the GUID

            // for the Quality parameter category.
            myEncoder = System.Drawing.Imaging.Encoder.Quality;

            // Create an EncoderParameters object.

            // An EncoderParameters object has an array of EncoderParameter

            // objects. In this case, there is only one

            // EncoderParameter object in the array.
            myEncoderParameters = new EncoderParameters(1);

            // Save the bitmap as a JPEG file with quality level 25.
         /*   myEncoderParameter = new EncoderParameter(myEncoder, 25L);
            myEncoderParameters.Param[0] = myEncoderParameter;
            myBitmap.Save("Shapes025.jpg", myImageCodecInfo, myEncoderParameters);

            // Save the bitmap as a JPEG file with quality level 50.
            myEncoderParameter = new EncoderParameter(myEncoder, 50L);
            myEncoderParameters.Param[0] = myEncoderParameter;
            myBitmap.Save("Shapes050.jpg", myImageCodecInfo, myEncoderParameters);
            */
            // Save the bitmap as a JPEG file with quality level 75.
            myEncoderParameter = new EncoderParameter(myEncoder, 75L);
            myEncoderParameters.Param[0] = myEncoderParameter;
            nom = @"C:\Users\fer\Desktop\HUELLAS_IMAGENES_PARA_RC\" + archivo + ".jpg" ;
           imagenHuella.Save(nom, myImageCodecInfo, myEncoderParameters);

        }

        //obtener codecs para las imagenes
        private static ImageCodecInfo GetEncoderInfo(String mimeType)
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;
        }


        public void MakeReport(string texto)
        {
            this.Invoke(new Function(delegate () { this.txtMonitor.AppendText(texto + "\r\n"); }));
        }

        #endregion METODOS DELEGADOS

        #region METODOS DE LA INTERFAZ
        public void OnComplete(object Capture, string ReaderSerialNumber, Sample Sample)
        {
            frmBusqueda bus = new frmBusqueda();
            //cerrarFormulario close = new cerrarFormulario(bus.Cerrar);


            this.DibujarImagen(this.ConvertirSampleEnBitmap(Sample));
            FeatureSet caracteristicas = new FeatureSet();
            caracteristicas = this.ExtraerMinucias(Sample,DPFP.Processing.DataPurpose.Verification);
            if(caracteristicas != null)
            {
                DPFP.Verification.Verification.Result resultado = new Verification.Result();
                SqlConnection SqlCon = new SqlConnection();
                SqlCon.ConnectionString = global::CapaPresentacion.Properties.Settings.Default.ConexionFront;
                SqlCon.Open();
                //conexion a la base de datos
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;

                SqlCmd = SqlCon.CreateCommand();
                SqlCmd.CommandText = "Select * from huellas";

                //extraccion de datos de la base de datos
                SqlDataReader datos = SqlCmd.ExecuteReader();

                //busqueda de datos
                bool verificado = false;
                string pront = "";
                string dni = "";
                string legajo = "";
                string huella = "";
                string nomArchivo = "";
               // string clave_huella = "";

                //recorrer la tabla
                while (datos.Read()){
                    Template template = new Template();
                    MemoryStream memoria = new MemoryStream((byte[])datos["huella"]);
                    //efectuar comparacion
                    if(memoria != null)
                    {
                        template.DeSerialize(memoria.ToArray());
                        this.Invoke(new Function(delegate () { this.btnActualizador.Enabled = true; }));
                        //this.btnActualizador.Enabled = true;
                    }
                    else
                    {
                        MakeReport("No existe dato huella para este registro");
                        this.btnCargar.Enabled = true;
                        this.btnActualizador.Enabled = false;

                    }
                    verificador.Verify(caracteristicas,template,ref resultado);
                    if (resultado.Verified)
                    {
                        pront = Convert.ToString(datos["prontuario"]);
                        legajo = Convert.ToString(datos["legajo"]);
                        dni = Convert.ToString(datos["clave_personal"]);
                        clave_huella = Convert.ToString(datos["clave_automatica"]);
                        //this.btnCargar.Enabled = false;
                     /*   nomArchivo = Convert.ToString(datos["clave_personal"]) + Convert.ToString(datos["clave_automatica"]);
                        CrearArchivoImagen(this.ConvertirSampleEnBitmap(Sample),nomArchivo);
                       */
                        verificado = true;
                        break;
                   }

                }
                if (verificado)
                {
                    //frmEnrolar f = frmEnrolar.getInstanciaFrmEnrolar();
                    //f.txtProntIdentificado.Text = pront;
                  //  MessageBox.Show("Existe el registro: \r\n prontuario:" + pront + "\r\n dni:" + dni + "\r\n legajo:" + legajo + "\r\n");

                    if (dni != String.Empty)
                    {
                        long docu = Convert.ToInt64(dni);
                        frmCiudadano fciudadano = new frmCiudadano(docu);
                        fciudadano.Show();
                    }

                    if (legajo != String.Empty)
                    {
                        int leg = Convert.ToInt32(legajo);
                        frmPersonal fperson = new frmPersonal(leg);
                        fperson.Show();
                    }

                    if (pront != String.Empty)
                    {
                        int clave = Convert.ToInt32(clave_huella);
                        int prontuario_carcel = Convert.ToInt32(pront);
                        frmInterno frmint = new frmInterno(prontuario_carcel);
                        frmint.Show();
                    }


                }
                else
                {

                    //mensajeError("No existe este registro con la huella introducida");
                    this.Invoke(new Function(delegate(){ this.btnCargar.Enabled = true; } ));
                    //this.btnCargar.Enabled = true;
                    
                    frmMensajeNoRegistro mensajeForm = new frmMensajeNoRegistro();
                    mensajeForm.Show();
                    this.Invoke(new Function(delegate () { this.btnActualizador.Enabled = false; }));
                    
                    //  this.btnActualizador.Enabled = false;
                }
                datos.Close();
                SqlCmd.Dispose();
                SqlCon.Close();
                SqlCon.Dispose();
                //this.Close();
            


           }

        }

        public void OnFingerGone(object Capture, string ReaderSerialNumber)
        {
         
        }

        public void OnFingerTouch(object Capture, string ReaderSerialNumber)
        {
            
        }

        public void OnReaderConnect(object Capture, string ReaderSerialNumber)
        {
          
        }

        public void OnReaderDisconnect(object Capture, string ReaderSerialNumber)
        {
        }

        public void OnSampleQuality(object Capture, string ReaderSerialNumber, CaptureFeedback CaptureFeedback)
        {
            
        }

        private void frmBusqueda_Load(object sender, EventArgs e)
        {
            this.btnCargar.Enabled = false;
            this.btnActualizador.Enabled = false;
            Init();
            IniciarCaptura();
        }
        private void mensajeError(String mensaje)
        {
            MessageBox.Show(mensaje, "Sistema Huellas Digitales S.P.P.S", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        private void mensajeOK(String mensaje)
        {
            MessageBox.Show(mensaje, "Sistema Huellas Digitales S.P.P.S", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion METODOS DE LA INTERFAZ

        private void frmBusqueda_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DetenerCaptura();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            if (this.lblCodigoPersonal.Text != "0")
            {
                var codigo = this.lblCodigoPersonal.Text;
                var dedo = this.lblCodigoDedo.Text;
                var nombre = this.lblNombre.Text;
                var d = this.lblD.Text;
                this.Close();

                frmCargarHuella2 frmCargar = frmCargarHuella2.getInstanciaFrmCH2();
                frmCargar.lblPersonalCode.Text = codigo;
                frmCargar.lblDedo.Text = dedo;
                frmCargar.lblNombre.Text = nombre;
                frmCargar.lblD.Text = d;
                frmCargar.Show();
            }
            else
            {
                this.mensajeError("Para acceder a la carga de huellas dactilares debe tener datos del interno precargados");
            }

        }

        private void btnActualizador_Click(object sender, EventArgs e)
        {
            string respuesta;
            if (this.lblCodigoPersonal.Text != "0")
            {
                foreach (Form frm in Application.OpenForms)
                {
                    if (frm.GetType() == typeof(frmEnrolar))
                    {
                        long clavep = Convert.ToInt64(this.lblCodigoPersonal.Text);
                        int clave = Convert.ToInt32(clave_huella);
                        respuesta = CapaNegocio.NHuellas.Insertar_ProntuarioEnRegistro(clave, clavep);
                        MessageBox.Show(respuesta);
                        break;
                    }
                    if (frm.GetType() == typeof(frmEnrolarCivil))
                    {
                        long clavec = Convert.ToInt64(this.lblCodigoPersonal.Text);
                        int clave = Convert.ToInt32(clave_huella);
                        respuesta = CapaNegocio.NHuellas.Insertar_CuilEnRegistro(clave, clavec);
                        MessageBox.Show(respuesta);
                        break;
                    }
                    if (frm.GetType() == typeof(frmEnrolarPersonal))
                    {
                        int clavel = Convert.ToInt32(this.lblCodigoPersonal.Text);
                        int clave = Convert.ToInt32(clave_huella);
                        respuesta = CapaNegocio.NHuellas.Insertar_LegajoEnRegistro(clave, clavel);
                        MessageBox.Show(respuesta);
                        break;
                    }
                }
            } 
            else
            {
                this.mensajeError("Para acceder a la carga de huellas dactilares debe tener datos del interno precargados");
            }
            
        }
    }
}
