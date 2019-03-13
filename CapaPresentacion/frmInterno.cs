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
    public partial class frmInterno : Form
    {
        public frmInterno(int prontuario)
        {
            InitializeComponent();
            this.dataPreso.DataSource = CapaNegocio.NInterno.Buscar(prontuario);
        }

        private void frmInterno_Load(object sender, EventArgs e)
        {
            byte[] imagenbuffer = (byte[])(this.dataPreso.CurrentRow.Cells["foto_frente"].Value);
            System.IO.MemoryStream ms = new System.IO.MemoryStream(imagenbuffer);
            this.ptxFoto.Image = Image.FromStream(ms);

            this.txtProntuario.Text = Convert.ToString(this.dataPreso.CurrentRow.Cells["prontuario"].Value);
            this.txtNombre.Text = Convert.ToString(this.dataPreso.CurrentRow.Cells["nombre"].Value);
            this.txtApellido.Text = Convert.ToString(this.dataPreso.CurrentRow.Cells["apellido"].Value);
        }

        
    }
}
