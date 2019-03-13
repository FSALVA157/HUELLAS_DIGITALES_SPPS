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
    public partial class frmPersonal : Form
    {
        public frmPersonal(int legajo)
        {
            InitializeComponent();
            this.dataGuardian.DataSource = CapaNegocio.NPersonal.BuscarXLegajo(legajo);
        }

        private void frmPersonal_Load(object sender, EventArgs e)
        {
            byte[] imagenbuffer = (byte[])(this.dataGuardian.CurrentRow.Cells["foto"].Value);
            System.IO.MemoryStream ms = new System.IO.MemoryStream(imagenbuffer);
            this.ptxFoto.Image = Image.FromStream(ms);

            this.txtLegajo.Text = Convert.ToString(this.dataGuardian.CurrentRow.Cells["legajo"].Value);
            this.txtNombre.Text = Convert.ToString(this.dataGuardian.CurrentRow.Cells["nombre"].Value);
            this.txtApellido.Text = Convert.ToString(this.dataGuardian.CurrentRow.Cells["apellido"].Value);
        }
    }
}
