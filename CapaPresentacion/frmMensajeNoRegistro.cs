using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmMensajeNoRegistro : Form
    {
        public frmMensajeNoRegistro()
        {
            InitializeComponent();
        }

        private void frmMensajeNoRegistro_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }
    }
}
