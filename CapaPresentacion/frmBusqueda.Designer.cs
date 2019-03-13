namespace CapaPresentacion
{
    partial class frmBusqueda
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
            this.imgHuella = new System.Windows.Forms.PictureBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.txtMonitor = new System.Windows.Forms.TextBox();
            this.btnCargar = new System.Windows.Forms.Button();
            this.lblDedo = new System.Windows.Forms.Label();
            this.lblCodigoDedo = new System.Windows.Forms.Label();
            this.lblCodigoPersonal = new System.Windows.Forms.Label();
            this.btnActualizador = new System.Windows.Forms.Button();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblD = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuella)).BeginInit();
            this.SuspendLayout();
            // 
            // imgHuella
            // 
            this.imgHuella.BackColor = System.Drawing.Color.Transparent;
            this.imgHuella.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.imgHuella.Location = new System.Drawing.Point(162, 113);
            this.imgHuella.Name = "imgHuella";
            this.imgHuella.Size = new System.Drawing.Size(335, 266);
            this.imgHuella.TabIndex = 0;
            this.imgHuella.TabStop = false;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblTitulo.Font = new System.Drawing.Font("Square721 BT", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(12, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(600, 22);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Para efectuar la Verificación Coloque el dedo en el sensor....";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtMonitor
            // 
            this.txtMonitor.BackColor = System.Drawing.Color.Black;
            this.txtMonitor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMonitor.ForeColor = System.Drawing.Color.Yellow;
            this.txtMonitor.Location = new System.Drawing.Point(1, 403);
            this.txtMonitor.Multiline = true;
            this.txtMonitor.Name = "txtMonitor";
            this.txtMonitor.Size = new System.Drawing.Size(653, 97);
            this.txtMonitor.TabIndex = 2;
            // 
            // btnCargar
            // 
            this.btnCargar.BackgroundImage = global::CapaPresentacion.Properties.Resources.huella_scaneo_8;
            this.btnCargar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCargar.Location = new System.Drawing.Point(517, 116);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(124, 105);
            this.btnCargar.TabIndex = 3;
            this.btnCargar.UseVisualStyleBackColor = true;
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
            // 
            // lblDedo
            // 
            this.lblDedo.AutoEllipsis = true;
            this.lblDedo.AutoSize = true;
            this.lblDedo.BackColor = System.Drawing.Color.Transparent;
            this.lblDedo.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDedo.ForeColor = System.Drawing.Color.White;
            this.lblDedo.Location = new System.Drawing.Point(78, 43);
            this.lblDedo.Name = "lblDedo";
            this.lblDedo.Size = new System.Drawing.Size(67, 27);
            this.lblDedo.TabIndex = 4;
            this.lblDedo.Text = "DEDO";
            // 
            // lblCodigoDedo
            // 
            this.lblCodigoDedo.AutoSize = true;
            this.lblCodigoDedo.Location = new System.Drawing.Point(9, 62);
            this.lblCodigoDedo.Name = "lblCodigoDedo";
            this.lblCodigoDedo.Size = new System.Drawing.Size(39, 13);
            this.lblCodigoDedo.TabIndex = 5;
            this.lblCodigoDedo.Text = "codigo";
            this.lblCodigoDedo.Visible = false;
            // 
            // lblCodigoPersonal
            // 
            this.lblCodigoPersonal.AutoSize = true;
            this.lblCodigoPersonal.Location = new System.Drawing.Point(13, 100);
            this.lblCodigoPersonal.Name = "lblCodigoPersonal";
            this.lblCodigoPersonal.Size = new System.Drawing.Size(31, 13);
            this.lblCodigoPersonal.TabIndex = 6;
            this.lblCodigoPersonal.Text = "pront";
            // 
            // btnActualizador
            // 
            this.btnActualizador.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnActualizador.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizador.ForeColor = System.Drawing.Color.Khaki;
            this.btnActualizador.Location = new System.Drawing.Point(7, 140);
            this.btnActualizador.Name = "btnActualizador";
            this.btnActualizador.Size = new System.Drawing.Size(137, 238);
            this.btnActualizador.TabIndex = 7;
            this.btnActualizador.Text = "Actualizar Registro de Huella con Nueva Información";
            this.btnActualizador.UseVisualStyleBackColor = false;
            this.btnActualizador.Click += new System.EventHandler(this.btnActualizador_Click);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.ForeColor = System.Drawing.Color.Gold;
            this.lblNombre.Location = new System.Drawing.Point(189, 87);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(0, 20);
            this.lblNombre.TabIndex = 8;
            // 
            // lblD
            // 
            this.lblD.AutoSize = true;
            this.lblD.Location = new System.Drawing.Point(239, 87);
            this.lblD.Name = "lblD";
            this.lblD.Size = new System.Drawing.Size(0, 13);
            this.lblD.TabIndex = 9;
            this.lblD.Visible = false;
            // 
            // frmBusqueda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CapaPresentacion.Properties.Resources.huella11;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(652, 498);
            this.Controls.Add(this.lblD);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.btnActualizador);
            this.Controls.Add(this.lblCodigoPersonal);
            this.Controls.Add(this.lblCodigoDedo);
            this.Controls.Add(this.lblDedo);
            this.Controls.Add(this.btnCargar);
            this.Controls.Add(this.txtMonitor);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.imgHuella);
            this.Name = "frmBusqueda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmBusqueda";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmBusqueda_FormClosed);
            this.Load += new System.EventHandler(this.frmBusqueda_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgHuella)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox imgHuella;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.TextBox txtMonitor;
        private System.Windows.Forms.Button btnCargar;
        public System.Windows.Forms.Label lblDedo;
        public System.Windows.Forms.Label lblCodigoDedo;
        public System.Windows.Forms.Label lblCodigoPersonal;
        private System.Windows.Forms.Button btnActualizador;
        public System.Windows.Forms.Label lblNombre;
        public System.Windows.Forms.Label lblD;
    }
}