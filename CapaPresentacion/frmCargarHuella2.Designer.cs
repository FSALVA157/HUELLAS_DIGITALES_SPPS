namespace CapaPresentacion
{
    partial class frmCargarHuella2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCargarHuella2));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAbrirArchivo = new System.Windows.Forms.Button();
            this.txtArch1huellaName = new System.Windows.Forms.TextBox();
            this.lblArch1huellaName = new System.Windows.Forms.Label();
            this.btnGrabarFile = new System.Windows.Forms.Button();
            this.lblD = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.SeñalDedo = new System.Windows.Forms.PictureBox();
            this.lblDedo = new System.Windows.Forms.Label();
            this.lblPersonalCode = new System.Windows.Forms.Label();
            this.txtRegEventos = new System.Windows.Forms.TextBox();
            this.lblVecesDedo = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.imgHuella = new System.Windows.Forms.PictureBox();
            this.prompt = new System.Windows.Forms.Label();
            this.ofd1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SeñalDedo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuella)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.btnAbrirArchivo);
            this.groupBox1.Controls.Add(this.txtArch1huellaName);
            this.groupBox1.Controls.Add(this.lblArch1huellaName);
            this.groupBox1.Controls.Add(this.btnGrabarFile);
            this.groupBox1.Controls.Add(this.lblD);
            this.groupBox1.Controls.Add(this.lblNombre);
            this.groupBox1.Controls.Add(this.SeñalDedo);
            this.groupBox1.Controls.Add(this.lblDedo);
            this.groupBox1.Controls.Add(this.lblPersonalCode);
            this.groupBox1.Controls.Add(this.txtRegEventos);
            this.groupBox1.Controls.Add(this.lblVecesDedo);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.btnGrabar);
            this.groupBox1.Controls.Add(this.imgHuella);
            this.groupBox1.Location = new System.Drawing.Point(27, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(708, 540);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Carga de Huella Digital";
            // 
            // btnAbrirArchivo
            // 
            this.btnAbrirArchivo.BackColor = System.Drawing.Color.Maroon;
            this.btnAbrirArchivo.Font = new System.Drawing.Font("Arial Black", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbrirArchivo.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAbrirArchivo.Location = new System.Drawing.Point(609, 342);
            this.btnAbrirArchivo.Name = "btnAbrirArchivo";
            this.btnAbrirArchivo.Size = new System.Drawing.Size(84, 25);
            this.btnAbrirArchivo.TabIndex = 52;
            this.btnAbrirArchivo.Text = "Explorar";
            this.btnAbrirArchivo.UseVisualStyleBackColor = false;
            this.btnAbrirArchivo.Click += new System.EventHandler(this.btnAbrirArchivo_Click);
            // 
            // txtArch1huellaName
            // 
            this.txtArch1huellaName.Font = new System.Drawing.Font("Swis721 Blk BT", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtArch1huellaName.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtArch1huellaName.Location = new System.Drawing.Point(464, 373);
            this.txtArch1huellaName.Name = "txtArch1huellaName";
            this.txtArch1huellaName.Size = new System.Drawing.Size(238, 23);
            this.txtArch1huellaName.TabIndex = 51;
            // 
            // lblArch1huellaName
            // 
            this.lblArch1huellaName.AutoSize = true;
            this.lblArch1huellaName.Font = new System.Drawing.Font("Swis721 Blk BT", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArch1huellaName.ForeColor = System.Drawing.Color.DarkRed;
            this.lblArch1huellaName.Location = new System.Drawing.Point(461, 347);
            this.lblArch1huellaName.Name = "lblArch1huellaName";
            this.lblArch1huellaName.Size = new System.Drawing.Size(115, 15);
            this.lblArch1huellaName.TabIndex = 53;
            this.lblArch1huellaName.Text = "Nombre Archivo:";
            // 
            // btnGrabarFile
            // 
            this.btnGrabarFile.BackColor = System.Drawing.Color.CadetBlue;
            this.btnGrabarFile.Font = new System.Drawing.Font("Impact", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGrabarFile.Location = new System.Drawing.Point(520, 253);
            this.btnGrabarFile.Name = "btnGrabarFile";
            this.btnGrabarFile.Size = new System.Drawing.Size(182, 83);
            this.btnGrabarFile.TabIndex = 13;
            this.btnGrabarFile.Text = "GRABAR DESDE ARCHIVO";
            this.btnGrabarFile.UseVisualStyleBackColor = false;
            this.btnGrabarFile.Click += new System.EventHandler(this.btnGrabarFile_Click);
            // 
            // lblD
            // 
            this.lblD.AutoSize = true;
            this.lblD.ForeColor = System.Drawing.Color.White;
            this.lblD.Location = new System.Drawing.Point(151, 67);
            this.lblD.Name = "lblD";
            this.lblD.Size = new System.Drawing.Size(35, 13);
            this.lblD.TabIndex = 12;
            this.lblD.Text = "label1";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.ForeColor = System.Drawing.Color.White;
            this.lblNombre.Location = new System.Drawing.Point(157, 20);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(35, 13);
            this.lblNombre.TabIndex = 11;
            this.lblNombre.Text = "label1";
            // 
            // SeñalDedo
            // 
            this.SeñalDedo.BackColor = System.Drawing.Color.CadetBlue;
            this.SeñalDedo.Location = new System.Drawing.Point(3, 16);
            this.SeñalDedo.Name = "SeñalDedo";
            this.SeñalDedo.Size = new System.Drawing.Size(100, 72);
            this.SeñalDedo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.SeñalDedo.TabIndex = 10;
            this.SeñalDedo.TabStop = false;
            // 
            // lblDedo
            // 
            this.lblDedo.AutoSize = true;
            this.lblDedo.ForeColor = System.Drawing.Color.White;
            this.lblDedo.Location = new System.Drawing.Point(255, 509);
            this.lblDedo.Name = "lblDedo";
            this.lblDedo.Size = new System.Drawing.Size(31, 13);
            this.lblDedo.TabIndex = 9;
            this.lblDedo.Text = "dedo";
            this.lblDedo.Visible = false;
            // 
            // lblPersonalCode
            // 
            this.lblPersonalCode.AutoSize = true;
            this.lblPersonalCode.ForeColor = System.Drawing.Color.White;
            this.lblPersonalCode.Location = new System.Drawing.Point(59, 512);
            this.lblPersonalCode.Name = "lblPersonalCode";
            this.lblPersonalCode.Size = new System.Drawing.Size(74, 13);
            this.lblPersonalCode.TabIndex = 8;
            this.lblPersonalCode.Text = "personal code";
            // 
            // txtRegEventos
            // 
            this.txtRegEventos.BackColor = System.Drawing.Color.Black;
            this.txtRegEventos.ForeColor = System.Drawing.Color.White;
            this.txtRegEventos.Location = new System.Drawing.Point(532, 428);
            this.txtRegEventos.Multiline = true;
            this.txtRegEventos.Name = "txtRegEventos";
            this.txtRegEventos.Size = new System.Drawing.Size(151, 106);
            this.txtRegEventos.TabIndex = 7;
            // 
            // lblVecesDedo
            // 
            this.lblVecesDedo.AutoSize = true;
            this.lblVecesDedo.Font = new System.Drawing.Font("Swis721 Blk BT", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVecesDedo.ForeColor = System.Drawing.Color.Yellow;
            this.lblVecesDedo.Location = new System.Drawing.Point(94, 361);
            this.lblVecesDedo.Name = "lblVecesDedo";
            this.lblVecesDedo.Size = new System.Drawing.Size(241, 24);
            this.lblVecesDedo.TabIndex = 6;
            this.lblVecesDedo.Text = "Debe Pasar el Dedo: ";
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.CadetBlue;
            this.btnBuscar.Font = new System.Drawing.Font("Impact", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(520, 147);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(182, 64);
            this.btnBuscar.TabIndex = 5;
            this.btnBuscar.Text = "BUSCAR";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackColor = System.Drawing.Color.CadetBlue;
            this.btnGrabar.Font = new System.Drawing.Font("Impact", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGrabar.Location = new System.Drawing.Point(520, 29);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(182, 69);
            this.btnGrabar.TabIndex = 4;
            this.btnGrabar.Text = "GRABAR";
            this.btnGrabar.UseVisualStyleBackColor = false;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // imgHuella
            // 
            this.imgHuella.BackColor = System.Drawing.Color.Transparent;
            this.imgHuella.BackgroundImage = global::CapaPresentacion.Properties.Resources.huella2;
            this.imgHuella.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imgHuella.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.imgHuella.Location = new System.Drawing.Point(98, 94);
            this.imgHuella.Name = "imgHuella";
            this.imgHuella.Size = new System.Drawing.Size(279, 253);
            this.imgHuella.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgHuella.TabIndex = 3;
            this.imgHuella.TabStop = false;
            // 
            // prompt
            // 
            this.prompt.AutoSize = true;
            this.prompt.Font = new System.Drawing.Font("Clarendon Blk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prompt.ForeColor = System.Drawing.SystemColors.Control;
            this.prompt.Location = new System.Drawing.Point(275, 490);
            this.prompt.Name = "prompt";
            this.prompt.Size = new System.Drawing.Size(0, 16);
            this.prompt.TabIndex = 2;
            // 
            // frmCargarHuella2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::CapaPresentacion.Properties.Resources.captura_huellas_fondo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(761, 564);
            this.Controls.Add(this.prompt);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCargarHuella2";
            this.Text = "                                                             .:. FORMULARIO DE EN" +
    "ROLAMIENTO E IDENTIFICACION .:.";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmCargarHuella2_FormClosed);
            this.Load += new System.EventHandler(this.frmCargarHuella2_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SeñalDedo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuella)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblVecesDedo;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.PictureBox imgHuella;
        private System.Windows.Forms.Label prompt;
        private System.Windows.Forms.TextBox txtRegEventos;
        public System.Windows.Forms.Label lblPersonalCode;
        public System.Windows.Forms.Label lblDedo;
        private System.Windows.Forms.PictureBox SeñalDedo;
        public System.Windows.Forms.Label lblD;
        public System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Button btnGrabarFile;
        private System.Windows.Forms.OpenFileDialog ofd1;
        private System.Windows.Forms.Button btnAbrirArchivo;
        private System.Windows.Forms.TextBox txtArch1huellaName;
        private System.Windows.Forms.Label lblArch1huellaName;
    }
}