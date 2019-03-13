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
    public partial class frmCiudadano : Form
    {
        public frmCiudadano(long cuil)
        {
            InitializeComponent();
            this.dataCitizen.DataSource = CapaNegocio.NCivil.Buscar(cuil);
        }

        private void frmCiudadano_Load(object sender, EventArgs e)
        {
            byte[] imagenbuffer= (byte[])(this.dataCitizen.CurrentRow.Cells["foto"].Value);
            System.IO.MemoryStream ms = new System.IO.MemoryStream(imagenbuffer);
            this.ptxFoto.Image = Image.FromStream(ms);

            this.txtDNI.Text = Convert.ToString(this.dataCitizen.CurrentRow.Cells["cuil"].Value);
            this.txtNombre.Text = Convert.ToString(this.dataCitizen.CurrentRow.Cells["nombre"].Value);
            this.txtApellido.Text = Convert.ToString(this.dataCitizen.CurrentRow.Cells["apellido"].Value);
        }
    }
}
