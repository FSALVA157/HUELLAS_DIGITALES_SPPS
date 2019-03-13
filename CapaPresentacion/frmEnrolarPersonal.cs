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
    public partial class frmEnrolarPersonal : Form
    {
        bool IsNuevo = false;
        bool IsEditar = false;
        private static frmEnrolarPersonal _instanciaFrmEnrolarPersonal;

        public static frmEnrolarPersonal getInstanciaFrmEnrolarPersonal()
        {
            if(_instanciaFrmEnrolarPersonal == null || _instanciaFrmEnrolarPersonal.IsDisposed)
            {
                _instanciaFrmEnrolarPersonal = new frmEnrolarPersonal();
            }
            _instanciaFrmEnrolarPersonal.BringToFront();
            return _instanciaFrmEnrolarPersonal;
        }
        private frmEnrolarPersonal()
        {
            InitializeComponent();
            this.LlenarComboSexo();
            
            
        }

        private void frmEnrolarPersonal_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.habilitar(false);
            this.botones();
        }

        private void limpiar()
        {
            this.txtLegajo.Text = String.Empty;
            this.txtCuil.Text = String.Empty;
            this.txtNombre.Text = String.Empty;
            this.txtApellido.Text = String.Empty;
            this.cmbSexo.SelectedValue = 0;
            this.txtDomicilio.Text = String.Empty;
            this.pictFoto.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pictFoto.Image = global::CapaPresentacion.Properties.Resources.silueta_negra;
            this.txtProvincia.Text = String.Empty;
            this.txtBarrio.Text = String.Empty;
            this.txtDestino.Text = String.Empty;
            this.txtGrado.Text = String.Empty;
            this.txtEscalafon.Text = String.Empty;
            this.txtFechaIngreso.Text = String.Empty;
            this.txtAntiguedad.Text = String.Empty;
            this.txtFechaNacimiento.Text = String.Empty;


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
        private void habilitar(bool valor)
        {
            this.txtLegajo.ReadOnly = !valor;
            this.txtCuil.ReadOnly = !valor;
            this.txtApellido.ReadOnly = !valor;
            this.txtNombre.ReadOnly = !valor;
            this.cmbSexo.Enabled = valor;
            this.txtBarrio.ReadOnly = !valor;
            this.txtProvincia.ReadOnly = !valor;
            this.txtDestino.ReadOnly = !valor;
            this.txtGrado.ReadOnly= !valor;
            this.btnLimpiarFoto.Enabled = valor;
            this.btnGuardar.Enabled = valor;
            this.btnCancelar.Enabled = valor;
            this.txtEscalafon.ReadOnly = !valor;
            this.txtFechaIngreso.ReadOnly = !valor;
            this.txtAntiguedad.ReadOnly = !valor;
            this.txtFechaNacimiento.ReadOnly = !valor;
            
        }
        private void LlenarComboSexo()
        {
            this.cmbSexo.DataSource = NSexo.mostrar();
            this.cmbSexo.ValueMember = "id";
            this.cmbSexo.DisplayMember = "sexo";
            this.cmbSexo.SelectedIndex = 1;
        }

        private void btnCargarFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            DialogResult result = new DialogResult();
            result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                this.pictFoto.SizeMode = PictureBoxSizeMode.StretchImage;
                this.pictFoto.Image = Image.FromFile(dialog.FileName);
            }
        }

        private void mensajeError(String mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Control Biometrico S.P.P.S.", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        private void mensajeOK(String mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Control Biometrico S.P.P.S.", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                String rpta = "";
                if (this.txtLegajo.Text == String.Empty ||
                    this.txtNombre.Text == String.Empty || this.txtApellido.Text == String.Empty || this.txtCuil.Text == String.Empty)
                {
                    this.mensajeError("Falta llenar algunos campos obligatorios los mismos seran remarcados");
                    this.errorCarga.SetError(this.txtLegajo, "Debe cargar el Numero de Legajo del Personal");
                    this.errorCarga.SetError(this.txtApellido, "Debe cargar el Apellido del personal");
                    this.errorCarga.SetError(this.txtNombre, "Debe cargar un Nombre del personal");
                    this.errorCarga.SetError(this.txtCuil, "Debe cargar el número de CUIL del personal");

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

                        rpta = NPersonal.Insertar(Convert.ToInt32(this.txtLegajo.Text), Convert.ToInt64(this.txtCuil.Text), this.txtApellido.Text.Trim().ToUpper(), this.txtNombre.Text.Trim().ToUpper(),
                         imagen, Convert.ToInt32(this.cmbSexo.SelectedValue), this.txtDomicilio.Text.Trim(), 1, 1,1,1,1, this.txtFechaIngreso.Text.Trim(), 24,
                         this.txtFechaNacimiento.Text.Trim());
                        this.mensajeOK(rpta);

                        

                       
                    }

                    else
                    {
                        rpta = NPersonal.Editar(Convert.ToInt32(this.txtLegajo.Text), Convert.ToInt32(this.txtCuil.Text), this.txtApellido.Text.Trim().ToUpper(), this.txtNombre.Text.Trim().ToUpper(),
                         imagen, Convert.ToInt32(this.cmbSexo.SelectedValue), this.txtDomicilio.Text.Trim(), 1, 1, 1, 1, 1, this.txtFechaIngreso.Text.Trim(), 24,
                         this.txtFechaNacimiento.Text.Trim());
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

        private void rbAlta_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAlta.Checked == true)
            {
                this.IsEditar = false;
                this.IsNuevo = true;
                this.limpiar();
                this.habilitar(true);
                this.botones();
                //esta porcion de codigo debe quitarse cuando se configuren de manera correcta los combos
                this.txtProvincia.Text = "Salta";
                this.txtBarrio.Text = "sin especificar";
                this.txtDestino.Text = "Unidad Carcelaria Nº 1 - Salta";
                this.txtGrado.Text = "cabo 1º";
                this.txtEscalafon.Text = "Penitenciario";
                this.txtFechaIngreso.Text = "15/04/1995";
                this.txtAntiguedad.Text = "24 años";
                this.txtFechaNacimiento.Text = "01/01/1975";
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.habilitar(false);
            this.IsNuevo = false;
            this.IsEditar = false;
            this.botones();
        }

        private void buscarPersonal()
        {
            this.dataCuerpo.DataSource = NPersonal.BuscarXLegajo(Convert.ToInt32(this.txtLegajoIdentificado.Text));

        }

        private void txtLegajoIdentificado_TextChanged(object sender, EventArgs e)
        {
            this.buscarPersonal();
        }

        private void dataCuerpo_DoubleClick(object sender, EventArgs e)
        {
            if (this.rbEdicion.Checked == true)
            {
                this.txtLegajo.Text = Convert.ToString(this.dataCuerpo.CurrentRow.Cells["legajo"].Value);
                this.txtCuil.Text = Convert.ToString(this.dataCuerpo.CurrentRow.Cells["cuil"].Value);
                this.txtNombre.Text = Convert.ToString(this.dataCuerpo.CurrentRow.Cells["nombre"].Value);
                this.txtApellido.Text = Convert.ToString(this.dataCuerpo.CurrentRow.Cells["apellido"].Value);
                
                //tratamiento de imagen
                try
                {
                    byte[] imagenbuffer = (byte[])(this.dataCuerpo.CurrentRow.Cells["foto"].Value);
                    System.IO.MemoryStream ms = new System.IO.MemoryStream(imagenbuffer);

                    this.pictFoto.Image = Image.FromStream(ms);
                    this.pictFoto.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                catch (Exception)
                {

                    this.pictFoto.SizeMode = PictureBoxSizeMode.StretchImage;
                    this.pictFoto.Image = global::CapaPresentacion.Properties.Resources.silueta;
                }

             // this.cmbSexo.SelectedValue = this.dataInternos.CurrentRow.Cells["sexo"].Value;
                this.txtDomicilio.Text = Convert.ToString(this.dataCuerpo.CurrentRow.Cells["domicilio"].Value);
                this.txtBarrio.Text = Convert.ToString(this.dataCuerpo.CurrentRow.Cells["barrio"].Value);
                this.txtProvincia.Text = Convert.ToString(this.dataCuerpo.CurrentRow.Cells["provincia"].Value);
                this.txtDestino.Text = Convert.ToString(this.dataCuerpo.CurrentRow.Cells["destino"].Value);
                this.txtGrado.Text = Convert.ToString(this.dataCuerpo.CurrentRow.Cells["grado"].Value);
                this.txtEscalafon.Text = Convert.ToString(this.dataCuerpo.CurrentRow.Cells["escalafon"].Value);
                this.txtFechaIngreso.Text = Convert.ToString(this.dataCuerpo.CurrentRow.Cells["fecha_ingreso"].Value);
                this.txtAntiguedad.Text = Convert.ToString(this.dataCuerpo.CurrentRow.Cells["antiguedad"].Value);
                this.txtFechaNacimiento.Text = Convert.ToString(this.dataCuerpo.CurrentRow.Cells["fecha_nacimiento"].Value);
            }
            else
            {
                MessageBox.Show("PARA VISUALIZAR UN REGISTRO DEBE ESTAR EN MODO EDICION", "Sistema de Registro Dactilar",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnLimpiarFoto_Click(object sender, EventArgs e)
        {
            this.pictFoto.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pictFoto.Image = global::CapaPresentacion.Properties.Resources.silueta_negra;
        }

        private void opMEI_CheckedChanged(object sender, EventArgs e)
        {

            if (opMEI.Checked == true)
            {
                //opMEI.Checked = true;
                //  frmCargarHuella2 frmCargar = new frmCargarHuella2();
                // frmCargar.Show();
                frmBusqueda frmBuscar = frmBusqueda.getInstancia();
                frmBuscar.lblCodigoDedo.Text = "1";
                frmBuscar.lblDedo.Text = "DEBE REGISTRAR EL DEDO MEÑIQUE IZQUIERDO";
                if (txtLegajo.Text != String.Empty)
                {
                    frmBuscar.lblCodigoPersonal.Text = this.txtLegajo.Text;
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
                if (txtLegajo.Text != String.Empty)
                {
                    frmBuscar.lblCodigoPersonal.Text = this.txtLegajo.Text;
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
                if (txtLegajo.Text != String.Empty)
                {
                    frmBuscar.lblCodigoPersonal.Text = this.txtLegajo.Text;
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
                if (txtLegajo.Text != String.Empty)
                {
                    frmBuscar.lblCodigoPersonal.Text = this.txtLegajo.Text;
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
            if (opAI.Checked == true)
            {

                frmBusqueda frmBuscar = frmBusqueda.getInstancia();
                frmBuscar.lblCodigoDedo.Text = "5";
                frmBuscar.lblDedo.Text = "DEBE REGISTRAR EL DEDO PULGAR IZQUIERDO";
                if (txtLegajo.Text != String.Empty)
                {
                    frmBuscar.lblCodigoPersonal.Text = this.txtLegajo.Text;
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
                if (txtLegajo.Text != String.Empty)
                {
                    frmBuscar.lblCodigoPersonal.Text = this.txtLegajo.Text;
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
                if (txtLegajo.Text != String.Empty)
                {
                    frmBuscar.lblCodigoPersonal.Text = this.txtLegajo.Text;
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
                if (txtLegajo.Text != String.Empty)
                {
                    frmBuscar.lblCodigoPersonal.Text = this.txtLegajo.Text;
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
                if (txtLegajo.Text != String.Empty)
                {
                    frmBuscar.lblCodigoPersonal.Text = this.txtLegajo.Text;
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
                if (txtLegajo.Text != String.Empty)
                {
                    frmBuscar.lblCodigoPersonal.Text = this.txtLegajo.Text;
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
