using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using DPFP;
using DPFP.Capture;
using CapaNegocio;
using System.Drawing.Imaging;

namespace CapaPresentacion
{
    public partial class frmCargarHuella2 : Form, DPFP.Capture.EventHandler
    {
        private DPFP.Capture.Capture Capturer;
        delegate void Function();
        private DPFP.Processing.Enrollment enroller;
        private DPFP.Template template;
        private static frmCargarHuella2 _InstanciaFrmCH2;
        public DPFP.Sample plantilla;

        private frmCargarHuella2()
        {
            InitializeComponent();
        }

        public static frmCargarHuella2 getInstanciaFrmCH2()
        {
            if ((_InstanciaFrmCH2 == null)||(_InstanciaFrmCH2.IsDisposed))
            {
                _InstanciaFrmCH2 = new frmCargarHuella2();
            }
            return _InstanciaFrmCH2;
        }


        //metodo de inicio del scanner
        protected virtual void Init()
        {
            try
            {
                Capturer = new DPFP.Capture.Capture();
                if (Capturer != null)
                {
                    Capturer.EventHandler = this;
                    enroller = new DPFP.Processing.Enrollment();
                    /*string numero;
                    numero = String.Format("RESTAN {0} LECTURAS DEL DEDO CENSADO", enroller.FeaturesNeeded);
                    this.lblVecesDedo.Text = numero.ToString();
                   */


                }
                else
                {
                    SetPrompt("No se puede iniciar la Operación de Captura!");

                }


            }
            catch (Exception)
            {
                MessageBox.Show("No se puede iniciar la Operación de Captura!", "SISTEMA DE HUELLAS DIGITALES DEL SPPS", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

            }
        }

        public Bitmap ConvertirSampleEnBitmap(DPFP.Sample Sample)
        {
            DPFP.Capture.SampleConversion Conversor = new SampleConversion();
            Bitmap bitmap = null;
            Conversor.ConvertToPicture(Sample, ref bitmap);
            return bitmap;
        }

        //iniciar captura de la huella

        protected void Start()
        {
            if (this.Capturer != null)
            {
                try
                {
                    Capturer.StartCapture();
                    SetPrompt("INICIANDO ESCANEO DE HUELLA DIGITAL");
                }
                catch (Exception)
                {
                    SetPrompt("ERROR AL INICIAR EL ESCANEO DE LA HUELLA DIGITAL");
                    throw;
                }
            }
        }

        //detener el escaner digital
        protected void Stop()
        {
            if (Capturer != null)
            {
                try
                {
                    Capturer.StopCapture();
                    SetPrompt("SE HA DETENIDO LA CAPTURA DE HUELLA");
                }
                catch (Exception)
                {

                    SetPrompt("ERROR AL DETENER EL ESCANER DIGITAL");
                }
            }
        }

        //dibujar la huella digital en el formulario
        protected virtual void Process(DPFP.Sample Sample)
        {
            plantilla = Sample;
            this.DrawPicture(ConvertirSampleEnBitmap(Sample));
            DPFP.FeatureSet caracteristicas = this.ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Enrollment);
            if (caracteristicas != null)
            {
                try
                {
                    this.enroller.AddFeatures(caracteristicas);
                }
                catch (Exception ex)
                {
                    SetPrompt("HA FALLADO EL PROCESO DE ESCANEO");
                }

                finally
                {
                    string numero;
                    //string nomArchivo = "FERNANDO";
                    /* numero = String.Format("RESTAN {0} LECTURAS DEL DEDO CENSADO", enroller.FeaturesNeeded);
                     this.lblVecesDedo.Text = numero.ToString();*/
                    switch (enroller.TemplateStatus)
                    {
                        case DPFP.Processing.Enrollment.Status.Ready:
                            MessageBox.Show("PROCESO DE MUESTREO DE HUELLAS EXITOSO", "SISTEMA DE HUELLAS DIGITALES DEL S.P.P.S", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.template = enroller.Template;
                            //codigo provisorio para prueba de captura de imagen

                            //nomArchivo = Convert.ToString(datos["clave_personal"]) + Convert.ToString(datos["clave_automatica"]);
                           // CrearArchivoImagen(this.ConvertirSampleEnBitmap(Sample), nomArchivo);



                            Stop();
                            break;
                        case DPFP.Processing.Enrollment.Status.Failed:
                            MessageBox.Show("ERROR EN EL MUESTREO DE HUELLAS DIGITALES", "SISTEMA DE HUELLAS DIGITALES DEL S.P.P.S", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.imgHuella.Image = null;
                            enroller.Clear();
                            Stop();
                            Start();
                            break;

                    }
                }
            }
        }
        //CODIGO PROVISORIO
        private void CrearArchivoImagen(Bitmap imagenHuella, string archivo)
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
            myEncoderParameter = new System.Drawing.Imaging.EncoderParameter(myEncoder, 75L);
            myEncoderParameters.Param[0] = myEncoderParameter;
            nom = @"C:\Users\fer\Desktop\HUELLAS_IMAGENES_PARA_RC\" + archivo + ".jpg";
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

        public delegate void LlamarCrearArchivoImagen(Bitmap imagenHuella, string archivo);


        protected DPFP.FeatureSet ExtractFeatures(DPFP.Sample Sample, DPFP.Processing.DataPurpose Purpose)
        {
            DPFP.FeatureSet features = new FeatureSet();                                            //minucias
            DPFP.Capture.CaptureFeedback feedback = CaptureFeedback.None;                           //calidad
            DPFP.Processing.FeatureExtraction Extractor = new DPFP.Processing.FeatureExtraction(); //extractor
            Extractor.CreateFeatureSet(Sample, Purpose, ref feedback, ref features);
            if (feedback == DPFP.Capture.CaptureFeedback.Good)
            {
                return features;
            }
            else
            {
                return null;
            }
        }




        #region EventHandler_Members
        public void OnComplete(object Capture, string ReaderSerialNumber, Sample Sample)
        {
            MakeReport("Huella Digital Capturada");
            SetPrompt("Coloque el dedo una vez mas");
            Process(Sample);
        }

        public void OnFingerGone(object Capture, string ReaderSerialNumber)
        {
            MakeReport("El dedo se retira del lector de huellas");
        }

        public void OnFingerTouch(object Capture, string ReaderSerialNumber)
        {
            SetPrompt("El lector de Huellas Dactilares ha sido tocado");
        }

        public void OnReaderConnect(object Capture, string ReaderSerialNumber)
        {
            MakeReport("Lector de Huellas Conectado");
        }

        public void OnReaderDisconnect(object Capture, string ReaderSerialNumber)
        {
            MakeReport("Lector de Huellas Desconectado");
        }

        public void OnSampleQuality(object Capture, string ReaderSerialNumber, CaptureFeedback CaptureFeedback)
        {
            
            if (CaptureFeedback == DPFP.Capture.CaptureFeedback.Good)
            {
                MakeReport("La calidad de la muestra es buena");
            
            }
            else
            {
                MakeReport("La calidad de la muestra es pobre");
            }
        }

        #endregion


        #region EVENT HANDLERS DEL FORMULARIO
        private void frmCargarHuella2_Load(object sender, EventArgs e)
        {
            Init();
            Start();
            this.LLenarImagenMano();
        }

        private void LLenarImagenMano()
        {
            if (this.lblDedo.Text.Equals("1"))
            {
                this.SeñalDedo.Image = global::CapaPresentacion.Properties.Resources.manos_1;
            }else
            {
                this.SeñalDedo.Image = global::CapaPresentacion.Properties.Resources.manos_2;
            }
        }

        private void frmCargarHuella2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Stop();
        }

        #endregion

        public void SetPrompt(string mensaje)
        {
            this.Invoke(new Function(delegate ()
            {
                this.prompt.Text = mensaje;
            }));
        }
        #region Procedimientos con Delegado
        //agregar linea de texto a textbox del formulario
        public void MakeReport(string cadena)
        {
            this.Invoke(new Function(delegate ()
            {
                this.txtRegEventos.AppendText(cadena + "\r\n");
            }));
        }

        //dibujar la imagen de la huella en el formulario

        public void DrawPicture(Bitmap bitmap)
        {
            this.Invoke(new Function(delegate ()
            {
                this.imgHuella.Image = new Bitmap(bitmap, imgHuella.Size);
            }));
        }

        #endregion 

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            int dedo = Convert.ToInt32(this.lblDedo.Text);
            //long clave = Convert.ToInt32(this.lblPersonalCode.Text);
            string respuesta = "ERROR: Reinicie el Proceso";
            LlamarCrearArchivoImagen grabarImagen = new LlamarCrearArchivoImagen(CrearArchivoImagen);
            try
            {
                //trabajar la huella
                MemoryStream ms = new MemoryStream();
                this.template.Serialize(ms);
                ms.Position = 0;
                BinaryReader br = new BinaryReader(ms);
                Byte[] bytes = br.ReadBytes((Int32)ms.Length);
                /*
                //calculo del hash de la huella
                byte[] hashCadena = CapaNegocio.NHuellas.hashearHuella(bytes);
                string hashTxt = "";
                
                for (int i = 0; i < (Int32)hashCadena.Length; i++)
                {

                    hashTxt += Convert.ToString(hashCadena[i]);
                    //MessageBox.Show(Convert.ToString(hashCadena[i]));
                }
                ulong hashNumerico =  Convert.ToUInt64(hashTxt);
                MessageBox.Show("EL HASH DE LA HUELLA ES: " + hashTxt);
                */
                string texto = this.lblPersonalCode.Text + this.lblD.Text + this.lblNombre.Text;
                foreach (Form frm in Application.OpenForms)
                {
                    if(frm.GetType() == typeof(frmEnrolar))
                    {
                        long clave = Convert.ToInt32(this.lblPersonalCode.Text);
                        respuesta = CapaNegocio.NHuellas.Insertar_Huella_Interno(clave, dedo, bytes);
                        break;
                    }
                    if (frm.GetType() == typeof(frmEnrolarCivil))
                    {
                        long clave = Convert.ToInt64(this.lblPersonalCode.Text);
                        respuesta = CapaNegocio.NHuellas.Insertar_Huella_Civil(clave, dedo, bytes);
                       grabarImagen(ConvertirSampleEnBitmap(plantilla),texto);
                        break;
                    }
                    if (frm.GetType() == typeof(frmEnrolarPersonal))
                    {
                        int clave = Convert.ToInt32(this.lblPersonalCode.Text);
                        respuesta = CapaNegocio.NHuellas.Insertar_Huella_Personal(clave, dedo, bytes);
                        break;
                    }
                }
                //string respuesta = CapaNegocio.NHuellas.Insertar_Huella_Interno(clave, dedo, bytes);
                //MessageBox.Show(respuesta);
                if (respuesta.Equals("OK"))
                {
                    frmMensaExito exito = new frmMensaExito();
                    exito.Show();
                    
                }else
                {
                    MessageBox.Show(respuesta);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void btnGrabarFile_Click(object sender, EventArgs e)
        {
            int dedo = Convert.ToInt32(this.lblDedo.Text);
            //long clave = Convert.ToInt32(this.lblPersonalCode.Text);
            string respuesta = "ERROR: Reinicie el Proceso";
           
            //LlamarCrearArchivoImagen grabarImagen = new LlamarCrearArchivoImagen(CrearArchivoImagen);
            try
            {

                /*
                MemoryStream ms = new MemoryStream();
                this.template.Serialize(ms);
                ms.Position = 0;
                BinaryReader br = new BinaryReader(ms);
                Byte[] bytes = br.ReadBytes((Int32)ms.Length);
               */
               //proceso de convertir el archivo en una tipo sample
                System.IO.MemoryStream ms1 = new MemoryStream();
                Stream flujo = ofd1.OpenFile();
                //System.Drawing.Bitmap bmpPostedImage = new System.Drawing.Bitmap(flujo);
                Image imagen = new Bitmap(flujo);
                var obj = new ImageConverter();

                // byte[] imageByteArray = obj.con  obj.ConvertImageToByteArray(bmpPostedImage, ".png");
                //System.Drawing.Image imageIn = obj.ConvertByteArrayToImage(imageByteArray);

               // Image imagen = (Image)obj.ConvertTo(bmpPostedImage,typeof(Image));
                byte[] imageBytes = (byte[])obj.ConvertTo(imagen, typeof(byte[]));

                //imageIn.Save(ms1, System.Drawing.Imaging.ImageFormat.Bmp);


                //MessageBox.Show(ofd1.ToString());
                //flujo.CopyTo(ms1);

                System.IO.MemoryStream ms = new MemoryStream(imageBytes);
                

                DPFP.Sample sampleCrudo = new DPFP.Sample(ms);
                this.Process(sampleCrudo);
                string texto = this.lblPersonalCode.Text + this.lblD.Text + this.lblNombre.Text;

                //trabajar la huella
                //MemoryStream ms = new MemoryStream();
                this.template.Serialize(ms);
                ms.Position = 0;
                BinaryReader br = new BinaryReader(ms);
                Byte[] bytes = br.ReadBytes((Int32)ms.Length);
                
                foreach (Form frm in Application.OpenForms)
                {
                    if (frm.GetType() == typeof(frmEnrolar))
                    {
                        long clave = Convert.ToInt32(this.lblPersonalCode.Text);
                        respuesta = CapaNegocio.NHuellas.Insertar_Huella_Interno(clave, dedo, bytes);
                        break;
                    }
                    if (frm.GetType() == typeof(frmEnrolarCivil))
                    {
                        long clave = Convert.ToInt64(this.lblPersonalCode.Text);
                        respuesta = CapaNegocio.NHuellas.Insertar_Huella_Civil(clave, dedo, bytes);
                      //  grabarImagen(ConvertirSampleEnBitmap(plantilla), texto);
                        break;
                    }
                    if (frm.GetType() == typeof(frmEnrolarPersonal))
                    {
                        int clave = Convert.ToInt32(this.lblPersonalCode.Text);
                        respuesta = CapaNegocio.NHuellas.Insertar_Huella_Personal(clave, dedo, bytes);
                        break;
                    }
                }
                //string respuesta = CapaNegocio.NHuellas.Insertar_Huella_Interno(clave, dedo, bytes);
                //MessageBox.Show(respuesta);
                if (respuesta.Equals("OK"))
                {
                    frmMensaExito exito = new frmMensaExito();
                    exito.Show();

                }
                else
                {
                    MessageBox.Show(respuesta);
                }

                #region codigoParaEliminiar
                /*
                //proceso de convertir el sample ---> FeatureSet --------> template
                //********************
                DPFP.FeatureSet caracteristicas = this.ExtractFeatures(sample, DPFP.Processing.DataPurpose.Enrollment);
                if (caracteristicas != null)
                {
                    try
                    {
                        this.enroller.AddFeatures(caracteristicas);
                    }
                    catch (Exception ex)
                    {
                        SetPrompt("HA FALLADO LA CONVERSION DEL ARCHIVO OBTENIDO DESDE EL LECTOR RODADO");
                    }

                    finally
                    {
                        string numero;
                        //string nomArchivo = "FERNANDO";
                        // numero = String.Format("RESTAN {0} LECTURAS DEL DEDO CENSADO", enroller.FeaturesNeeded);
                        // this.lblVecesDedo.Text = numero.ToString();
                        switch (enroller.TemplateStatus)
                        {
                            case DPFP.Processing.Enrollment.Status.Ready:
                                MessageBox.Show("IMAGEN DE LECTOR RODADO CAPTURADO CORRECTAMENTE", "SISTEMA DE HUELLAS DIGITALES DEL S.P.P.S", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.template = enroller.Template;
                                //codigo provisorio para prueba de captura de imagen

                                //nomArchivo = Convert.ToString(datos["clave_personal"]) + Convert.ToString(datos["clave_automatica"]);
                                // CrearArchivoImagen(this.ConvertirSampleEnBitmap(Sample), nomArchivo);



                                Stop();
                                break;
                            case DPFP.Processing.Enrollment.Status.Failed:
                                MessageBox.Show("ERROR EN EL RECONOCIMIENTO DE LA IMAGEN DE LECTOR RODADO", "SISTEMA DE HUELLAS DIGITALES DEL S.P.P.S", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.imgHuella.Image = null;
                                enroller.Clear();
                                Stop();
                                Start();
                                break;

                        }
                    }
                }



                //*****************
                //codigo de insercion del dato

             //   MemoryStream ms = new MemoryStream();
                this.template.Serialize(ms);
                ms.Position = 0;
                BinaryReader br = new BinaryReader(ms);
                Byte[] bytes = br.ReadBytes((Int32)ms.Length);


                foreach (Form frm in Application.OpenForms)
                {
                    if (frm.GetType() == typeof(frmEnrolar))
                    {
                        long clave = Convert.ToInt32(this.lblPersonalCode.Text);
                        respuesta = CapaNegocio.NHuellas.Insertar_Huella_Interno(clave, dedo, bytes);
                        break;
                    }
                    if (frm.GetType() == typeof(frmEnrolarCivil))
                    {
                        long clave = Convert.ToInt64(this.lblPersonalCode.Text);
                        respuesta = CapaNegocio.NHuellas.Insertar_Huella_Civil(clave, dedo, bytes);
                        //grabarImagen(ConvertirSampleEnBitmap(plantilla), texto);
                        break;
                    }
                    if (frm.GetType() == typeof(frmEnrolarPersonal))
                    {
                        int clave = Convert.ToInt32(this.lblPersonalCode.Text);
                        respuesta = CapaNegocio.NHuellas.Insertar_Huella_Personal(clave, dedo, bytes);
                        break;
                    }
                }
               
                if (respuesta.Equals("OK"))
                {
                    frmMensaExito exito = new frmMensaExito();
                    exito.Show();

                }
                else
                {
                    MessageBox.Show(respuesta);
                }
                */
                #endregion codigoParaEliminar


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void btnAbrirArchivo_Click(object sender, EventArgs e)
        {
            ofd1.InitialDirectory = "D:\\ProyectoHuellasRodadas2019\\huellas_muestra";
            ofd1.FilterIndex = 1;
            ofd1.RestoreDirectory = true;
            if (ofd1.ShowDialog() == DialogResult.OK)
            {
                this.txtArch1huellaName.Text = ofd1.FileName;
            }

        }
    }
}
