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
using DPFP.Capture;

namespace CapaPresentacion
{
    public partial class frmCargarHuella : Form, DPFP.Capture.EventHandler   
    {
        private DPFP.Capture.Capture Captura;
        private DPFP.Processing.Enrollment Enroller;
        private DPFP.Template template;
        private delegate void  _delegadoMuestra(string txt);
        

        //metodo delegate
        public void mostrarVeces(string texto) {
            if (lblVecesDedo.InvokeRequired)
            {
                _delegadoMuestra deleg = new _delegadoMuestra(this.mostrarVeces);
                Invoke(deleg, texto);

            }else
            {
                lblVecesDedo.Text = texto;
            }
                }
        //constructor
        public frmCargarHuella()
        {
            InitializeComponent();
        }

        protected virtual void Init()
        {
            try
            {
                Captura = new DPFP.Capture.Capture();
                if (Captura != null ){
                    Captura.EventHandler = this;
                    Enroller = new DPFP.Processing.Enrollment();
                    string numero;
                    numero = String.Format("RESTAN {0} LECTURAS DEL DEDO CENSADO", Enroller.FeaturesNeeded);
                    this.lblVecesDedo.Text = numero.ToString();


                }else
                {
                    MessageBox.Show("No se pudo instanciar la captura", "SISTEMA DE HUELLAS DIGITALES", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al instanciar la captura: " + ex.Message, "SISTEMA DE HUELLAS DIGITALES", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

            }

        }

        

        protected void IniciarCaptura()
        {
            if(Captura != null)
            {
                try
                {
                    Captura.StartCapture();
                    MessageBox.Show("Using the fingerprint reader, scan your fingerprint.");
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Error al iniciar captura: " + ex.Message, "SISTEMA DE HUELLAS DIGITALES", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }
        }

        protected void PararCaptura()
        {
            if(Captura != null)
            {
                try
                {
                    Captura.StopCapture();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al detener la captura: " + ex.Message, "SISTEMA DE HUELLAS DIGITALES", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    
                }
            }
        }

        protected Bitmap convertirSampletoMapadeBits(DPFP.Sample sample)
        {
            DPFP.Capture.SampleConversion conversor = new SampleConversion();
            Bitmap imagen = null;
            conversor.ConvertToPicture(sample, ref imagen);
            return imagen;
        }

        private void ponerImagen(Bitmap map)
        {
            this.imgHuella.Image = new Bitmap(map,imgHuella.Size);
        }

        //metodo que captura las caracteristicas
        protected DPFP.FeatureSet extraerCaracteristicas(DPFP.Sample Sample, DPFP.Processing.DataPurpose Purpose)
        {
            DPFP.Processing.FeatureExtraction extractor = new DPFP.Processing.FeatureExtraction();
            DPFP.Capture.CaptureFeedback calidad = DPFP.Capture.CaptureFeedback.None;
            DPFP.FeatureSet caracteristicas = new FeatureSet();
            //extraer caracteristicas
            extractor.CreateFeatureSet(Sample, Purpose, ref calidad, ref caracteristicas);

            if(calidad == DPFP.Capture.CaptureFeedback.Good)
            {
                MessageBox.Show("LA CALIDAD DE LAS CARACTERISTICAS ES BUENA");
                return caracteristicas;
            }else
            {
                MessageBox.Show("LA CALIDAD DE LAS CARACTERISTICAS ES MALA");
                return null;
            }
          }

        protected void Procesar(DPFP.Sample Sample)
        {
            DPFP.FeatureSet caracteristicas = this.extraerCaracteristicas(Sample, DPFP.Processing.DataPurpose.Verification);
            if(caracteristicas != null)
            {
                try
                {
                    Enroller.AddFeatures(caracteristicas);

                }
                finally
                {
                    string numero;
                    numero = String.Format("RESTAN {0} LECTURAS DEL DEDO CENSADO", Enroller.FeaturesNeeded);
                   // mostrarVeces(numero.ToString());
                    switch (Enroller.TemplateStatus)
                    {
                        case DPFP.Processing.Enrollment.Status.Ready:
                            MessageBox.Show("INGRESO POR ENROLE CORRECTO");
                            this.template = Enroller.Template;
                            PararCaptura();
                            break;
                        case DPFP.Processing.Enrollment.Status.Failed:
                            MessageBox.Show("INGRESO POR FALLA DE ENROLE");
                            Enroller.Clear();
                            PararCaptura();
                            IniciarCaptura();
                            break;

                    }
                }
                
            }
        }



        //metodos de la interfaz
        public void OnComplete(Object Capture, string ReaderSerialNumber, Sample Sample)
        {
            this.ponerImagen(this.convertirSampletoMapadeBits(Sample));
            this.Procesar(Sample);
        }

        public void OnFingerGone(object Capture, string ReaderSerialNumber)
        {
           
        }

        public void OnFingerTouch(object Capture, string ReaderSerialNumber)
        {
           // MessageBox.Show("SE HA TOCADO EL ESCANER DIGITAL!!!", "SISTEMA DE HUELLAS DIGITALES", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
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

        private void frmCargarHuella_Load(object sender, EventArgs e)
        {
            this.Init();
            this.IniciarCaptura();
        }

        private void frmCargarHuella_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.PararCaptura();
        }
    }
}
