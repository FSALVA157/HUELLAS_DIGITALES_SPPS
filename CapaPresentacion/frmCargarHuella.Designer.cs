namespace CapaPresentacion
{
    partial class frmCargarHuella
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblVecesDedo = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.imgHuella = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuella)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblVecesDedo);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.btnGrabar);
            this.groupBox1.Controls.Add(this.imgHuella);
            this.groupBox1.Location = new System.Drawing.Point(17, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(708, 465);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Carga de Huella Digital";
            // 
            // lblVecesDedo
            // 
            this.lblVecesDedo.AutoSize = true;
            this.lblVecesDedo.Font = new System.Drawing.Font("Swis721 Blk BT", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVecesDedo.ForeColor = System.Drawing.Color.Yellow;
            this.lblVecesDedo.Location = new System.Drawing.Point(43, 419);
            this.lblVecesDedo.Name = "lblVecesDedo";
            this.lblVecesDedo.Size = new System.Drawing.Size(241, 24);
            this.lblVecesDedo.TabIndex = 6;
            this.lblVecesDedo.Text = "Debe Pasar el Dedo: ";
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.CadetBlue;
            this.btnBuscar.Font = new System.Drawing.Font("Impact", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(520, 247);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(169, 129);
            this.btnBuscar.TabIndex = 5;
            this.btnBuscar.Text = "BUSCAR";
            this.btnBuscar.UseVisualStyleBackColor = false;
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackColor = System.Drawing.Color.CadetBlue;
            this.btnGrabar.Font = new System.Drawing.Font("Impact", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGrabar.Location = new System.Drawing.Point(520, 49);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(169, 129);
            this.btnGrabar.TabIndex = 4;
            this.btnGrabar.Text = "GRABAR";
            this.btnGrabar.UseVisualStyleBackColor = false;
            // 
            // imgHuella
            // 
            this.imgHuella.BackColor = System.Drawing.Color.White;
            this.imgHuella.Location = new System.Drawing.Point(98, 94);
            this.imgHuella.Name = "imgHuella";
            this.imgHuella.Size = new System.Drawing.Size(279, 253);
            this.imgHuella.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgHuella.TabIndex = 3;
            this.imgHuella.TabStop = false;
            // 
            // frmCargarHuella
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.IndianRed;
            this.ClientSize = new System.Drawing.Size(738, 488);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmCargarHuella";
            this.Text = "                                                                .:.  FORMULARIO D" +
    "E CARGA DE HUELLA DIGITAL  .:.";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmCargarHuella_FormClosed);
            this.Load += new System.EventHandler(this.frmCargarHuella_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuella)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.PictureBox imgHuella;
        private System.Windows.Forms.Label lblVecesDedo;
    }
}