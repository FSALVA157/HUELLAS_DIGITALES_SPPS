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
    public partial class frmMensaExito : Form
    {
        public frmMensaExito()
        {
            InitializeComponent();
        }

        private void frmMensaExito_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        private void frmMensaExito_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.Close();
            frmCargarHuella2 frmch2 = frmCargarHuella2.getInstanciaFrmCH2();
            frmch2.Close();
        }
    }
}
