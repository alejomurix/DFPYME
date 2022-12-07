namespace Aplicacion.Configuracion.Marcas
{
    partial class frmEditarMarca
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditarMarca));
            this.txtEditarMarca = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbGuardarCambios = new System.Windows.Forms.ToolStripButton();
            this.tsbCancelarEditarMarca = new System.Windows.Forms.ToolStripButton();
            this.tsbSalir = new System.Windows.Forms.ToolStripButton();
            this.txtIdEditarMarca = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtEditarMarca
            // 
            this.txtEditarMarca.Location = new System.Drawing.Point(110, 55);
            this.txtEditarMarca.Name = "txtEditarMarca";
            this.txtEditarMarca.Size = new System.Drawing.Size(100, 22);
            this.txtEditarMarca.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.label1.Location = new System.Drawing.Point(6, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nombre Marca";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbGuardarCambios,
            this.tsbCancelarEditarMarca,
            this.tsbSalir});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(361, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbGuardarCambios
            // 
            this.tsbGuardarCambios.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.tsbGuardarCambios.Image = ((System.Drawing.Image)(resources.GetObject("tsbGuardarCambios.Image")));
            this.tsbGuardarCambios.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbGuardarCambios.Name = "tsbGuardarCambios";
            this.tsbGuardarCambios.Size = new System.Drawing.Size(127, 22);
            this.tsbGuardarCambios.Text = "Guardar Cambios";
            this.tsbGuardarCambios.Click += new System.EventHandler(this.tsbGuardarCambios_Click);
            // 
            // tsbCancelarEditarMarca
            // 
            this.tsbCancelarEditarMarca.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.tsbCancelarEditarMarca.Image = ((System.Drawing.Image)(resources.GetObject("tsbCancelarEditarMarca.Image")));
            this.tsbCancelarEditarMarca.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCancelarEditarMarca.Name = "tsbCancelarEditarMarca";
            this.tsbCancelarEditarMarca.Size = new System.Drawing.Size(78, 22);
            this.tsbCancelarEditarMarca.Text = "Cancelar";
            this.tsbCancelarEditarMarca.Click += new System.EventHandler(this.tsbCancelarEditarMarca_Click);
            // 
            // tsbSalir
            // 
            this.tsbSalir.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.tsbSalir.Image = ((System.Drawing.Image)(resources.GetObject("tsbSalir.Image")));
            this.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSalir.Name = "tsbSalir";
            this.tsbSalir.Size = new System.Drawing.Size(54, 22);
            this.tsbSalir.Text = "Salir";
            this.tsbSalir.Click += new System.EventHandler(this.tsbSalir_Click);
            // 
            // txtIdEditarMarca
            // 
            this.txtIdEditarMarca.Enabled = false;
            this.txtIdEditarMarca.Location = new System.Drawing.Point(110, 21);
            this.txtIdEditarMarca.Name = "txtIdEditarMarca";
            this.txtIdEditarMarca.Size = new System.Drawing.Size(100, 22);
            this.txtIdEditarMarca.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.label2.Location = new System.Drawing.Point(6, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Id Marca";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtIdEditarMarca);
            this.groupBox1.Controls.Add(this.txtEditarMarca);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.groupBox1.Location = new System.Drawing.Point(12, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(272, 100);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Información Marca";
            // 
            // frmEditarMarca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 266);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmEditarMarca";
            this.Text = "Editar Marca";
            this.Load += new System.EventHandler(this.EditarMarca_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbGuardarCambios;
        public System.Windows.Forms.TextBox txtEditarMarca;
        private System.Windows.Forms.ToolStripButton tsbCancelarEditarMarca;
        private System.Windows.Forms.ToolStripButton tsbSalir;
        private System.Windows.Forms.TextBox txtIdEditarMarca;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}