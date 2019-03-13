using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion
{

    public partial class frmEnrolarCivil : Form
    {
        bool IsNuevo = false;
        bool IsEditar = false;
        DataTable dt = new DataTable();
        private static frmEnrolarCivil _instanciafrmEnrolarCivil;

        public static frmEnrolarCivil getInstanciaFrmEnrolarCivil()
        {
            if (_instanciafrmEnrolarCivil == null || _instanciafrmEnrolarCivil.IsDisposed)
            {
                _instanciafrmEnrolarCivil = new frmEnrolarCivil();
            }
            _instanciafrmEnrolarCivil.BringToFront();
            return _instanciafrmEnrolarCivil;
        } 
        private frmEnrolarCivil()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtCuil, "INGRESE EL NUMERO DE CUIL DEL CIUDADANO");
            this.ttMensaje.SetToolTip(this.txtApellido, "DEBE INGRESAR EL APELLIDO DEL INTERNO");
            this.ttMensaje.SetToolTip(this.txtNombre, "ESPECIFIQUE EL NOMBRE DEL INTERNO");
            this.cargarSexo();
        }

        private void frmEnrolarCivil_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.habilitar(false);
            this.botones();
        }

        
        //metodo que habilita o deshabilita los controles del formulario

        private void habilitar(bool valor)
        {
            this.txtCuil.ReadOnly = !valor;
            this.txtApellido.ReadOnly = !valor;
            this.txtNombre.ReadOnly = !valor;
            //this.cargarSexo();
            this.cmbSexo.Enabled = valor;
            this.txtDomicilio.ReadOnly = !valor;
            this.txtBarrio.ReadOnly = !valor;
            this.txtProvincia.ReadOnly = !valor;
            this.txtFechaNacimiento.ReadOnly = !valor;
            
            this.btnCargarFoto.Enabled = valor;
            this.btnLimpiarFoto.Enabled = valor;
            this.btnGuardar.Enabled = valor;
            this.btnCancelar.Enabled = valor;
            

        }
        private void cargarSexo()
        {
            // dt = NSexo.mostrar();

            this.cmbSexo.DataSource = NSexo.mostrar();
            this.cmbSexo.DisplayMember = "sexo";
            this.cmbSexo.ValueMember = "id";
        }
        
        private void btnCargarFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            DialogResult dialogResult = dialog.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                this.pictFoto.SizeMode = PictureBoxSizeMode.StretchImage;
                this.pictFoto.Image = Image.FromFile(dialog.FileName);

            }


        }
        

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                String rpta = "";
                if (this.txtCuil.Text == String.Empty ||
                    this.txtNombre.Text == String.Empty || this.txtApellido.Text == String.Empty)
                {
                    this.mensajeError("Falta llenar algunos campos obligatorios los mismos seran remarcados");
                    this.errorCarga.SetError(this.txtCuil, "Debe cargar un Numero de Prontuario");
                    this.errorCarga.SetError(this.txtApellido, "Debe cargar el Apellido del interno");
                    this.errorCarga.SetError(this.txtNombre, "Debe cargar un Nombre del interno");

                }
                else
                {
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    this.pictFoto.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    byte[] imagen = ms.GetBuffer();

                    

                    if (this.IsNuevo)
                    {


                        //rpta = NInterno.Insertar(Convert.ToInt32(this.txtProntuario.Text), this.txtApellido.Text.Trim().ToUpper(), this.txtNombre.Text.Trim().ToUpper(),imagen, Convert.ToString(this.cmbSexo.SelectedValue), Convert.ToString(this.cmbJurisdiccion.SelectedValue));
                        //this.mensajeOK(rpta);

                        rpta = NCivil.Insertar(Convert.ToInt64(this.txtCuil.Text), this.txtApellido.Text.Trim().ToUpper(), this.txtNombre.Text.Trim().ToUpper(), imagen, Convert.ToInt32(this.cmbSexo.SelectedValue), 
                            this.txtDomicilio.Text.Trim(),1,1,this.txtFechaNacimiento.Text);
                        this.mensajeOK(rpta);
                    }

                    else
                    {
                        rpta = NCivil.Editar(Convert.ToInt64(this.txtCuil.Text), this.txtApellido.Text.Trim().ToUpper(), this.txtNombre.Text.Trim().ToUpper(), imagen, Convert.ToInt32(this.cmbSexo.SelectedValue),
                            this.txtDomicilio.Text.Trim(), 1, 1, this.txtFechaNacimiento.Text);
                        this.mensajeOK(rpta);
                        // MessageBox.Show (rpta, "Sistema de Registro Dactilografico", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void sexo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnLimpiarFoto_Click(object sender, EventArgs e)
        {
            this.pictFoto.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pictFoto.Image = global::CapaPresentacion.Properties.Resources.silueta_negra;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.IsEditar = false;
            this.IsNuevo = true;

            this.habilitar(true);
        }
        private void mensajeError(String mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Control Biometrico S.P.P.S.", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        private void mensajeOK(String mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Control Biometrico S.P.P.S.", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void toolStripContainer1_TopToolStripPanel_Click(object sender, EventArgs e)
        {

        }

        private void RbAlta_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAlta.Checked == true)
            {
                this.IsEditar = false;
                this.IsNuevo = true;
                this.limpiar();
                this.habilitar(true);
                this.botones();
            }
            else
            {
                this.IsEditar = false;
                this.IsNuevo = false;

                this.habilitar(false);
                this.botones();
            }
        }

        private void rbEdicion_CheckedChanged(object sender, EventArgs e)
        {
            if (rbEdicion.Checked == true)
            {
                this.IsEditar = true;
                this.IsNuevo = false;
                this.limpiar();
                this.habilitar(true);
                this.botones();
            }
            else
            {
                this.IsEditar = false;
                this.IsNuevo = false;

                this.habilitar(false);
                this.botones();
            }
        }
        private void botones()
        {
            if ((this.IsEditar) || (this.IsNuevo))
            {
                this.habilitar(true);
                this.btnGuardar.Enabled = true;
                this.btnCancelar.Enabled = true;
                this.btnCargarFoto.Enabled = true;
                this.btnLimpiarFoto.Enabled = true;
              

            }
            else
            {
                this.habilitar(false);
                this.btnGuardar.Enabled = false;
                this.btnCancelar.Enabled = false;
                this.btnCargarFoto.Enabled = false;
                this.btnLimpiarFoto.Enabled = false;
               
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.habilitar(false);
            this.IsNuevo = false;
            this.IsEditar = false;
            this.botones();
        }

        //El siguiente metodo debe buscar en cada tabla una identificacion de persona a partir de una huella
       

        private void buscarCivil()
        {
            this.dataCivil.DataSource = NCivil.Buscar(Convert.ToInt64(this.txtCuilIdentificado.Text));

        }

       /* private void buscarDedos()
        {
            this.dataHuellas.DataSource = CapaNegocio.NHuellas.Dedos(Convert.ToInt64(this.txtCuilIdentificado.Text));
        }
        */
        private void dataInternos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataCivil_DoubleClick(object sender, EventArgs e)
        {
            if (this.rbEdicion.Checked == true)
            {
                this.txtCuil.Text = Convert.ToString(this.dataCivil.CurrentRow.Cells["cuil"].Value);
                this.txtNombre.Text = Convert.ToString(this.dataCivil.CurrentRow.Cells["nombre"].Value);
                this.txtApellido.Text = Convert.ToString(this.dataCivil.CurrentRow.Cells["apellido"].Value);
               
                //tratamiento de imagen
                try
                {
                    byte[] imagenbuffer = (byte[])(this.dataCivil.CurrentRow.Cells["foto"].Value);
                    System.IO.MemoryStream ms = new System.IO.MemoryStream(imagenbuffer);

                    this.pictFoto.Image = Image.FromStream(ms);
                    this.pictFoto.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                catch (Exception)
                {

                    this.pictFoto.SizeMode = PictureBoxSizeMode.StretchImage;
                    this.pictFoto.Image = global::CapaPresentacion.Properties.Resources.silueta;
                }

               


                this.cmbSexo.SelectedValue = this.dataCivil.CurrentRow.Cells["sexo"].Value;
                this.txtBarrio.Text = Convert.ToString(this.dataCivil.CurrentRow.Cells["barrio"].Value);
                this.txtProvincia.Text = Convert.ToString(this.dataCivil.CurrentRow.Cells["provincia"].Value);
                this.txtFechaNacimiento.Text = Convert.ToString(this.dataCivil.CurrentRow.Cells["fecha_nacimiento"].Value);
            }
            else
            {
                MessageBox.Show("PARA VISUALIZAR UN REGISTRO DEBE ESTAR EN MODO EDICION", "Sistema de Registro Dactilar",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        private void limpiar()
        {
            this.txtCuil.Text = String.Empty;
            this.txtNombre.Text = String.Empty;
            this.txtApellido.Text = String.Empty;
            this.cmbSexo.SelectedValue = 1;
            this.txtBarrio.Text = String.Empty;
            this.txtProvincia.Text = String.Empty;
            this.txtDomicilio.Text = String.Empty;
            this.txtFechaNacimiento.Text = String.Empty;
            this.pictFoto.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pictFoto.Image = global::CapaPresentacion.Properties.Resources.silueta_negra;
            

        }

        private void pictFoto_Click(object sender, EventArgs e)
        {

        }

        

        private void opMEI_Click(object sender, EventArgs e)
        {

        }

        private void opMEI_CheckedChanged_1(object sender, EventArgs e)
        {
            if (opMEI.Checked == true)
            {
                //opMEI.Checked = true;
                //  frmCargarHuella2 frmCargar = new frmCargarHuella2();
                // frmCargar.Show();
                frmBusqueda frmBuscar = frmBusqueda.getInstancia();
                frmBuscar.lblCodigoDedo.Text = "1";
                frmBuscar.lblDedo.Text = "DEBE REGISTRAR EL DEDO MEÑIQUE IZQUIERDO";
                frmBuscar.lblNombre.Text = this.txtApellido.Text + "_" + this.txtNombre.Text;
                frmBuscar.lblD.Text = "_mi_";
                if (txtCuil.Text != String.Empty)
                {
                    frmBuscar.lblCodigoPersonal.Text = this.txtCuil.Text;
                }
                else
                {
                    frmBuscar.lblCodigoPersonal.Text = "0";
                }

                frmBuscar.Show();
            }
            else
            {

                opMEI.Checked = false;
            }
        }

        private void opAI_CheckedChanged(object sender, EventArgs e)
        {
            if (opAI.Checked == true)
            {

                frmBusqueda frmBuscar = frmBusqueda.getInstancia();
                frmBuscar.lblCodigoDedo.Text = "2";
                frmBuscar.lblDedo.Text = "DEBE REGISTRAR EL DEDO ANULAR IZQUIERDO";
                frmBuscar.lblNombre.Text = this.txtApellido.Text + "_" + this.txtNombre.Text;
                frmBuscar.lblD.Text = "_ai_";
                if (txtCuil.Text != String.Empty)
                {
                    frmBuscar.lblCodigoPersonal.Text = this.txtCuil.Text;
                }
                else
                {
                    frmBuscar.lblCodigoPersonal.Text = "0";
                }
                frmBuscar.Show();
            }
            else
            {

                opAI.Checked = false;
            }

        }

        private void opMAI_CheckedChanged(object sender, EventArgs e)
        {
            if (opMAI.Checked == true)
            {

                frmBusqueda frmBuscar = frmBusqueda.getInstancia();
                frmBuscar.lblCodigoDedo.Text = "3";
                frmBuscar.lblDedo.Text = "DEBE REGISTRAR EL DEDO MAYOR IZQUIERDO";
                frmBuscar.lblNombre.Text = this.txtApellido.Text + "_" + this.txtNombre.Text;
                frmBuscar.lblD.Text = "_mai_";
                if (txtCuil.Text != String.Empty)
                {
                    frmBuscar.lblCodigoPersonal.Text = this.txtCuil.Text;
                }
                else
                {
                    frmBuscar.lblCodigoPersonal.Text = "0";
                }
                frmBuscar.Show();
            }
            else
            {

                opMAI.Checked = false;
            }
        }

        private void opII_CheckedChanged(object sender, EventArgs e)
        {
            if (opII.Checked == true)
            {

                frmBusqueda frmBuscar = frmBusqueda.getInstancia();
                frmBuscar.lblCodigoDedo.Text = "4";
                frmBuscar.lblDedo.Text = "DEBE REGISTRAR EL DEDO INDICE IZQUIERDO";
                frmBuscar.lblNombre.Text = this.txtApellido.Text + "_" + this.txtNombre.Text;
                frmBuscar.lblD.Text = "_ii_";
                if (txtCuil.Text != String.Empty)
                {
                    frmBuscar.lblCodigoPersonal.Text = this.txtCuil.Text;
                }
                else
                {
                    frmBuscar.lblCodigoPersonal.Text = "0";
                }
                frmBuscar.Show();
            }
            else
            {

                opII.Checked = false;
            }
        }

        private void opPI_CheckedChanged(object sender, EventArgs e)
        {
            if (opPI.Checked == true)
            {

                frmBusqueda frmBuscar = frmBusqueda.getInstancia();
                frmBuscar.lblCodigoDedo.Text = "5";
                frmBuscar.lblDedo.Text = "DEBE REGISTRAR EL DEDO PULGAR IZQUIERDO";
                frmBuscar.lblNombre.Text = this.txtApellido.Text + "_" + this.txtNombre.Text;
                frmBuscar.lblD.Text = "_pi_";
                if (txtCuil.Text != String.Empty)
                {
                    frmBuscar.lblCodigoPersonal.Text = this.txtCuil.Text;
                }
                else
                {
                    frmBuscar.lblCodigoPersonal.Text = "0";
                }
                frmBuscar.Show();
            }
            else
            {

                opPI.Checked = false;
            }
        }

        private void opPD_CheckedChanged(object sender, EventArgs e)
        {
            if (opPD.Checked == true)
            {

                frmBusqueda frmBuscar = frmBusqueda.getInstancia();
                frmBuscar.lblCodigoDedo.Text = "6";
                frmBuscar.lblDedo.Text = "DEBE REGISTRAR EL DEDO PULGAR DERECHO";
                frmBuscar.lblNombre.Text = this.txtApellido.Text + "_" + this.txtNombre.Text;
                frmBuscar.lblD.Text = "_pd_";
                if (txtCuil.Text != String.Empty)
                {
                    frmBuscar.lblCodigoPersonal.Text = this.txtCuil.Text;
                }
                else
                {
                    frmBuscar.lblCodigoPersonal.Text = "0";
                }
                frmBuscar.Show();
            }
            else
            {

                opPD.Checked = false;
            }
        }

        private void opID_CheckedChanged(object sender, EventArgs e)
        {
            if (opID.Checked == true)
            {

                frmBusqueda frmBuscar = frmBusqueda.getInstancia();
                frmBuscar.lblCodigoDedo.Text = "7";
                frmBuscar.lblDedo.Text = "DEBE REGISTRAR EL DEDO INDICE DERECHO";
                frmBuscar.lblNombre.Text = this.txtApellido.Text + "_" + this.txtNombre.Text;
                frmBuscar.lblD.Text = "_id_";
                if (txtCuil.Text != String.Empty)
                {
                    frmBuscar.lblCodigoPersonal.Text = this.txtCuil.Text;
                }
                else
                {
                    frmBuscar.lblCodigoPersonal.Text = "0";
                }
                frmBuscar.Show();
            }
            else
            {

                opID.Checked = false;
            }
        }

        private void opMAD_CheckedChanged(object sender, EventArgs e)
        {
            if (opMAD.Checked == true)
            {

                frmBusqueda frmBuscar = frmBusqueda.getInstancia();
                frmBuscar.lblCodigoDedo.Text = "8";
                frmBuscar.lblDedo.Text = "DEBE REGISTRAR EL DEDO MAYOR DERECHO";
                frmBuscar.lblNombre.Text = this.txtApellido.Text + "_" + this.txtNombre.Text;
                frmBuscar.lblD.Text = "_md_";
                if (txtCuil.Text != String.Empty)
                {
                    frmBuscar.lblCodigoPersonal.Text = this.txtCuil.Text;
                }
                else
                {
                    frmBuscar.lblCodigoPersonal.Text = "0";
                }
                frmBuscar.Show();
            }
            else
            {

                opMAD.Checked = false;
            }
        }

        private void opAD_CheckedChanged(object sender, EventArgs e)
        {
            if (opAD.Checked == true)
            {

                frmBusqueda frmBuscar = frmBusqueda.getInstancia();
                frmBuscar.lblCodigoDedo.Text = "9";
                frmBuscar.lblDedo.Text = "DEBE REGISTRAR EL DEDO ANULAR DERECHO";
                frmBuscar.lblNombre.Text = this.txtApellido.Text + "_" + this.txtNombre.Text;
                frmBuscar.lblD.Text = "_ad_";
                if (txtCuil.Text != String.Empty)
                {
                    frmBuscar.lblCodigoPersonal.Text = this.txtCuil.Text;
                }
                else
                {
                    frmBuscar.lblCodigoPersonal.Text = "0";
                }
                frmBuscar.Show();
            }
            else
            {

                opAD.Checked = false;
            }
        }

        private void opMED_CheckedChanged(object sender, EventArgs e)
        {
            if (opMED.Checked == true)
            {

                frmBusqueda frmBuscar = frmBusqueda.getInstancia();
                frmBuscar.lblCodigoDedo.Text = "10";
                frmBuscar.lblDedo.Text = "DEBE REGISTRAR EL DEDO MEÑIQUE DERECHO";
                frmBuscar.lblNombre.Text = this.txtApellido.Text + "_" + this.txtNombre.Text;
                frmBuscar.lblD.Text = "_med_";
                if (txtCuil.Text != String.Empty)
                {
                    frmBuscar.lblCodigoPersonal.Text = this.txtCuil.Text;
                }
                else
                {
                    frmBuscar.lblCodigoPersonal.Text = "0";
                }
                frmBuscar.Show();
            }
            else
            {

                opMED.Checked = false;
            }
        }

        private void txtCuilIdentificado_TextChanged(object sender, EventArgs e)
        {
            this.buscarCivil();
            //this.buscarDedos();
        }
    }
}
