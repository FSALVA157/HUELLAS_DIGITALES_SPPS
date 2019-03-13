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
    public partial class frmEnrolar : Form
    {
        bool IsNuevo = false;
        bool IsEditar = false;
        DataTable dt = new DataTable();
        private static frmEnrolar _instanciaFrmEnrolar;

        public static frmEnrolar getInstanciaFrmEnrolar()
        {
            if ((_instanciaFrmEnrolar == null) || (_instanciaFrmEnrolar.IsDisposed))
            {
                _instanciaFrmEnrolar = new frmEnrolar();
            }
            _instanciaFrmEnrolar.BringToFront();
            return _instanciaFrmEnrolar;
            
        }
        private frmEnrolar()
         {
           InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtProntuario, "INGRESE EL NUMERO DE PRONTUARIO DEL INTERNO");
            this.ttMensaje.SetToolTip(this.txtApellido, "DEBE INGRESAR EL APELLIDO DEL INTERNO");
            this.ttMensaje.SetToolTip(this.txtNombre, "ESPECIFIQUE EL NOMBRE DEL INTERNO");
            this.cargarSexo();
            this.cargarJurisdiccion();
            this.CargarEstadoProcesal();
            
        }
        //metodo que habilita o deshabilita los controles del formulario

            private void habilitar(bool valor)
        {
            this.txtId.ReadOnly = !valor;
            this.txtProntuario.ReadOnly = !valor;
            this.txtApellido.ReadOnly = !valor;
            this.txtNombre.ReadOnly = !valor;
            this.cmbSexo.Enabled = valor;
            this.cmbEstadoProcesal.Enabled = valor;
            this.cmbJurisdiccion.Enabled = valor;
            this.txtCausa.ReadOnly = !valor;
            this.btnCargarFoto.Enabled = valor;
            this.btnLimpiarFoto.Enabled = valor;
            this.btnGuardar.Enabled = valor;
            this.btnCancelar.Enabled = valor;
            this.btnCargarFotoPerfil.Enabled = valor;
            this.btnLimpiarFotoPerfil.Enabled = valor;

        }
        private void cargarSexo()
        {
           // dt = NSexo.mostrar();

            this.cmbSexo.DataSource = NSexo.mostrar();
            this.cmbSexo.DisplayMember = "sexo";
            this.cmbSexo.ValueMember = "id";
        }
        private void cargarJurisdiccion()
        {
            this.cmbJurisdiccion.DataSource = NJurisdiccion.mostrar();
            this.cmbJurisdiccion.ValueMember = "clave";
            this.cmbJurisdiccion.DisplayMember = "jurisdiccion";
        }

        private void CargarEstadoProcesal()
        {
            this.cmbEstadoProcesal.DataSource = NEstadoProcesal.mostrar();
            this.cmbEstadoProcesal.ValueMember = "id";
            this.cmbEstadoProcesal.DisplayMember = "estado_procesal";
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

        private void frmEnrolar_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.habilitar(false);
            this.botones();
        }
       

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                String rpta = "";
                if (this.txtProntuario.Text == String.Empty ||
                    this.txtNombre.Text == String.Empty || this.txtApellido.Text == String.Empty)
                {
                    this.mensajeError("Falta llenar algunos campos obligatorios los mismos seran remarcados");
                    this.errorCarga.SetError(this.txtProntuario, "Debe cargar un Numero de Prontuario");
                    this.errorCarga.SetError(this.txtApellido, "Debe cargar el Apellido del interno");
                    this.errorCarga.SetError(this.txtNombre, "Debe cargar un Nombre del interno");

                }else
                {
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    this.pictFoto.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    byte[] imagen = ms.GetBuffer();

                    System.IO.MemoryStream ms2 = new System.IO.MemoryStream();
                    this.pictFotoPerfil.Image.Save(ms2,System.Drawing.Imaging.ImageFormat.Png);
                    byte[] imagen2 = ms.GetBuffer();

                    if (this.IsNuevo)
                    {
                        
                       
                        //rpta = NInterno.Insertar(Convert.ToInt32(this.txtProntuario.Text), this.txtApellido.Text.Trim().ToUpper(), this.txtNombre.Text.Trim().ToUpper(),imagen, Convert.ToString(this.cmbSexo.SelectedValue), Convert.ToString(this.cmbJurisdiccion.SelectedValue));
                        //this.mensajeOK(rpta);

                        rpta = NInterno.Insertar(Convert.ToInt32(this.txtProntuario.Text), this.txtApellido.Text.Trim().ToUpper(), this.txtNombre.Text.Trim().ToUpper(),imagen,imagen2,Convert.ToString(this.cmbSexo.SelectedValue), Convert.ToString(this.cmbJurisdiccion.SelectedValue), Convert.ToString(this.cmbEstadoProcesal.SelectedValue),this.txtCausa.Text);
                        this.mensajeOK(rpta);
                    }

                    else
                    {
                        rpta = NInterno.Editar(Convert.ToInt32(this.txtProntuario.Text), this.txtApellido.Text.Trim().ToUpper(), this.txtNombre.Text.Trim().ToUpper(), imagen,imagen2, Convert.ToString(this.cmbSexo.SelectedValue), Convert.ToString(this.cmbJurisdiccion.SelectedValue), Convert.ToString(this.cmbEstadoProcesal.SelectedValue), this.txtCausa.Text);
                        this.mensajeOK(rpta);
                       // MessageBox.Show (rpta, "Sistema de Registro Dactilografico", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace) ;
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
            MessageBox.Show(mensaje,"Sistema de Control Biometrico S.P.P.S.",MessageBoxButtons.OK,MessageBoxIcon.Error);

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
            if (rbAlta.Checked == true) {
                this.IsEditar = false;
                this.IsNuevo = true;
                this.limpiar();
                this.habilitar(true);
                this.botones();
            }else
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
            }else
            {
                this.IsEditar = false;
                this.IsNuevo = false;

                this.habilitar(false);
                this.botones();
            }
        }
        private void botones()
        {
            if ((this.IsEditar) || (this.IsNuevo)){
                this.habilitar(true);
                this.btnGuardar.Enabled = true;
                this.btnCancelar.Enabled = true;
                this.btnCargarFoto.Enabled = true;
                this.btnLimpiarFoto.Enabled = true;
                this.btnCargarFotoPerfil.Enabled = true;
                this.btnLimpiarFotoPerfil.Enabled = true;

            }
            else{
                this.habilitar(false);
                this.btnGuardar.Enabled = false;
                this.btnCancelar.Enabled = false;
                this.btnCargarFoto.Enabled = false;
                this.btnLimpiarFoto.Enabled = false;
                this.btnCargarFotoPerfil.Enabled = false;
                this.btnLimpiarFotoPerfil.Enabled = false;
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
        private void txtProntIdentificado_TextChanged(object sender, EventArgs e)
        {
            this.buscarInterno();
        }

        private void buscarInterno()
        {
            this.dataInternos.DataSource = NInterno.Buscar(Convert.ToInt32(this.txtProntIdentificado.Text));

        }

        private void dataInternos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataInternos_DoubleClick(object sender, EventArgs e)
        {
            if (this.rbEdicion.Checked == true)
            {
                this.txtId.Text = Convert.ToString(this.dataInternos.CurrentRow.Cells["id"].Value);
                this.txtNombre.Text = Convert.ToString(this.dataInternos.CurrentRow.Cells["nombre"].Value);
                this.txtApellido.Text = Convert.ToString(this.dataInternos.CurrentRow.Cells["apellido"].Value);
                this.txtProntuario.Text = Convert.ToString(this.dataInternos.CurrentRow.Cells["prontuario"].Value);
                //tratamiento de imagen
                try
                {
                    byte[] imagenbuffer = (byte[])(this.dataInternos.CurrentRow.Cells["foto_frente"].Value);
                    System.IO.MemoryStream ms = new System.IO.MemoryStream(imagenbuffer);

                    this.pictFoto.Image = Image.FromStream(ms);
                    this.pictFoto.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                catch (Exception)
                {

                    this.pictFoto.SizeMode = PictureBoxSizeMode.StretchImage;
                    this.pictFoto.Image = global::CapaPresentacion.Properties.Resources.silueta;
                }

                //imagen perfil
                try
                {
                    byte[] imagenPerfilBuffer = (byte[])(this.dataInternos.CurrentRow.Cells["foto_perfil"].Value);
                    System.IO.MemoryStream ms2 = new System.IO.MemoryStream(imagenPerfilBuffer);

                    this.pictFotoPerfil.Image = Image.FromStream(ms2);
                    this.pictFotoPerfil.SizeMode = PictureBoxSizeMode.StretchImage;

                }
                catch (Exception)
                {

                    this.pictFotoPerfil.SizeMode = PictureBoxSizeMode.StretchImage;
                    this.pictFotoPerfil.Image = global::CapaPresentacion.Properties.Resources.perfil;
                }


                this.cmbSexo.SelectedValue = this.dataInternos.CurrentRow.Cells["sexo"].Value;
                this.cmbJurisdiccion.SelectedValue = this.dataInternos.CurrentRow.Cells["jurisdiccion"].Value;
                this.cmbEstadoProcesal.SelectedValue = this.dataInternos.CurrentRow.Cells["estado_procesal"].Value;
                this.txtCausa.Text = Convert.ToString(this.dataInternos.CurrentRow.Cells["causa"].Value);
            }
            else
            {
                MessageBox.Show("PARA VISUALIZAR UN REGISTRO DEBE ESTAR EN MODO EDICION", "Sistema de Registro Dactilar",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        private void limpiar()
        {
            this.txtId.Text = String.Empty;
            this.txtProntuario.Text = String.Empty;
            this.txtNombre.Text = String.Empty;
            this.txtApellido.Text = String.Empty;
            this.cmbSexo.SelectedValue = 1;
            this.cmbJurisdiccion.SelectedValue = 1;
            this.cmbEstadoProcesal.SelectedValue = 1;
            this.txtCausa.Text = String.Empty;
            this.pictFoto.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pictFoto.Image = global::CapaPresentacion.Properties.Resources.silueta_negra;
            this.pictFotoPerfil.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pictFotoPerfil.Image = global::CapaPresentacion.Properties.Resources.perfil;

        }

        private void pictFoto_Click(object sender, EventArgs e)
        {

        }

        private void btnCargarFotoPerfil_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog1 = new OpenFileDialog();
            DialogResult dialogResult1 = dialog1.ShowDialog();
            if(dialogResult1 == DialogResult.OK)
            {
                this.pictFotoPerfil.SizeMode = PictureBoxSizeMode.StretchImage;
                this.pictFotoPerfil.Image = Image.FromFile(dialog1.FileName);
            }

        }

        private void opMEI_CheckedChanged(object sender, EventArgs e)
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
                if (txtProntuario.Text != String.Empty)
                {
                    frmBuscar.lblCodigoPersonal.Text = this.txtProntuario.Text;
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
                if (txtProntuario.Text != String.Empty)
                {
                    frmBuscar.lblCodigoPersonal.Text = this.txtProntuario.Text;
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
                if (txtProntuario.Text != String.Empty)
                {
                    frmBuscar.lblCodigoPersonal.Text = this.txtProntuario.Text;
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
                if (txtProntuario.Text != String.Empty)
                {
                    frmBuscar.lblCodigoPersonal.Text = this.txtProntuario.Text;
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
                if (txtProntuario.Text != String.Empty)
                {
                    frmBuscar.lblCodigoPersonal.Text = this.txtProntuario.Text;
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
                if (txtProntuario.Text != String.Empty)
                {
                    frmBuscar.lblCodigoPersonal.Text = this.txtProntuario.Text;
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
                if (txtProntuario.Text != String.Empty)
                {
                    frmBuscar.lblCodigoPersonal.Text = this.txtProntuario.Text;
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
                if (txtProntuario.Text != String.Empty)
                {
                    frmBuscar.lblCodigoPersonal.Text = this.txtProntuario.Text;
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
                if (txtProntuario.Text != String.Empty)
                {
                    frmBuscar.lblCodigoPersonal.Text = this.txtProntuario.Text;
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
                if (txtProntuario.Text != String.Empty)
                {
                    frmBuscar.lblCodigoPersonal.Text = this.txtProntuario.Text;
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
    }
}
