using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace CapaPresentacion
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
;        }
        #region Funcionalidades del frmPrincipal
        //variables para capturar tamaño y ubicacion antes de maximizar
        int lx, ly;
        int sx, sy;
        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            lx = this.Location.X;
            ly = this.Location.Y;
            sx = this.Size.Width;
            sy = this.Size.Height;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
            //this.WindowState = FormWindowState.Maximized;
            this.btnMaximizar.Visible = false;
            this.btnRestaurar.Visible = true;
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Normal;
            this.Size = new Size(sx, sy);
            this.Location = new Point(lx, ly);
            this.btnRestaurar.Visible = false;
            this.btnMaximizar.Visible = true;
        }

        private void panelContenedor_Paint(object sender, PaintEventArgs e)
        {

        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void MenuVertical_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void BarraTitulo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void botonCerrar_Click(object sender, EventArgs e)
        {



            //------------------
            Application.Exit();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {//inicio load
           
        }//fin load

        //RESIZE METODO PARA REDIMENCIONAR/CAMBIAR TAMAÑO A FORMULARIO EN TIEMPO DE EJECUCION ----------------------------------------------------------
        private int tolerance = 12;
        private const int WM_NCHITTEST = 132;
        private const int HTBOTTOMRIGHT = 17;
        private Rectangle sizeGripRectangle;

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    base.WndProc(ref m);
                    var hitPoint = this.PointToClient(new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16));
                    if (sizeGripRectangle.Contains(hitPoint))
                        m.Result = new IntPtr(HTBOTTOMRIGHT);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnPersonal_MouseHover(object sender, EventArgs e)
        {
        //    this.BackColor = Color.FromArgb(70, 130, 180);
        }

        private void btnSlide_Click(object sender, EventArgs e)
        {
            if(MenuVertical.Width == 297)
            {
                MenuVertical.Width = 97;
            }else
            {
                MenuVertical.Width = 297;
            }
        }

        private void btnJudiciales_Click(object sender, EventArgs e)
        {
            frmEnrolar frmEnroleInterno = frmEnrolar.getInstanciaFrmEnrolar();
            frmEnroleInterno.Show();
            frmEnroleInterno.WindowState = FormWindowState.Maximized;

        }

        private void btnOAC_Click(object sender, EventArgs e)
        {
            frmEnrolarCivil frm = frmEnrolarCivil.getInstanciaFrmEnrolarCivil();
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();

        }

        private void btnPersonal_Click(object sender, EventArgs e)
        {
            frmEnrolarPersonal frmp = frmEnrolarPersonal.getInstanciaFrmEnrolarPersonal();
            frmp.WindowState = FormWindowState.Maximized;
            frmp.Show();
        }

        //----------------DIBUJAR RECTANGULO / EXCLUIR ESQUINA PANEL 
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            var region = new Region(new Rectangle(0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height));

            sizeGripRectangle = new Rectangle(this.ClientRectangle.Width - tolerance, this.ClientRectangle.Height - tolerance, tolerance, tolerance);

            region.Exclude(sizeGripRectangle);
            this.panelContenedor.Region = region;
            this.Invalidate();
        }
        //----------------COLOR Y GRIP DE RECTANGULO INFERIOR
        protected override void OnPaint(PaintEventArgs e)
        {
            SolidBrush blueBrush = new SolidBrush(Color.FromArgb(176, 196, 222));
            e.Graphics.FillRectangle(blueBrush, sizeGripRectangle);

            base.OnPaint(e);
            ControlPaint.DrawSizeGrip(e.Graphics, Color.Transparent , sizeGripRectangle);
        }
        #endregion Funcionalidades del frmPrincipal


    }
}
