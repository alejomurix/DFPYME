namespace Aplicacion.Inventario.Zona
{
    partial class frmEditarZona
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditarZona));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbGuardarCambiosEditarZona = new System.Windows.Forms.ToolStripButton();
            this.tlbbtnSalir = new System.Windows.Forms.ToolStripButton();
            this.gbInfoZonaEditar = new System.Windows.Forms.GroupBox();
            this.rbNoDisponible = new System.Windows.Forms.RadioButton();
            this.rbDisponible = new System.Windows.Forms.RadioButton();
            this.txtCapacidadZonaEditar = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNumeroZonaEditar = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombreZonaEditar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbInformacionBodegaEditar = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUbicacionBodegaEditar = new System.Windows.Forms.TextBox();
            this.txtNombreBodegaEditar = new System.Windows.Forms.TextBox();
            this.btnAgregarBodegaZona = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            this.gbInfoZonaEditar.SuspendLayout();
            this.gbInformacionBodegaEditar.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbGuardarCambiosEditarZona,
            this.tlbbtnSalir});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(295, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbGuardarCambiosEditarZona
            // 
            this.tsbGuardarCambiosEditarZona.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.tsbGuardarCambiosEditarZona.Image = ((System.Drawing.Image)(resources.GetObject("tsbGuardarCambiosEditarZona.Image")));
            this.tsbGuardarCambiosEditarZona.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbGuardarCambiosEditarZona.Name = "tsbGuardarCambiosEditarZona";
            this.tsbGuardarCambiosEditarZona.Size = new System.Drawing.Size(134, 22);
            this.tsbGuardarCambiosEditarZona.Text = "Guardar Cambios";
            this.tsbGuardarCambiosEditarZona.Click += new System.EventHandler(this.tsbGuardarCambiosEditarZona_Click);
            // 
            // tlbbtnSalir
            // 
            this.tlbbtnSalir.Image = ((System.Drawing.Image)(resources.GetObject("tlbbtnSalir.Image")));
            this.tlbbtnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlbbtnSalir.Name = "tlbbtnSalir";
            this.tlbbtnSalir.Size = new System.Drawing.Size(55, 22);
            this.tlbbtnSalir.Text = "Salir";
            this.tlbbtnSalir.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // gbInfoZonaEditar
            // 
            this.gbInfoZonaEditar.Controls.Add(this.rbNoDisponible);
            this.gbInfoZonaEditar.Controls.Add(this.rbDisponible);
            this.gbInfoZonaEditar.Controls.Add(this.txtCapacidadZonaEditar);
            this.gbInfoZonaEditar.Controls.Add(this.label3);
            this.gbInfoZonaEditar.Controls.Add(this.txtNumeroZonaEditar);
            this.gbInfoZonaEditar.Controls.Add(this.label2);
            this.gbInfoZonaEditar.Controls.Add(this.txtNombreZonaEditar);
            this.gbInfoZonaEditar.Controls.Add(this.label1);
            this.gbInfoZonaEditar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.gbInfoZonaEditar.Location = new System.Drawing.Point(12, 47);
            this.gbInfoZonaEditar.Name = "gbInfoZonaEditar";
            this.gbInfoZonaEditar.Size = new System.Drawing.Size(269, 139);
            this.gbInfoZonaEditar.TabIndex = 3;
            this.gbInfoZonaEditar.TabStop = false;
            this.gbInfoZonaEditar.Text = "Información Zona";
            // 
            // rbNoDisponible
            // 
            this.rbNoDisponible.AutoSize = true;
            this.rbNoDisponible.Location = new System.Drawing.Point(122, 111);
            this.rbNoDisponible.Name = "rbNoDisponible";
            this.rbNoDisponible.Size = new System.Drawing.Size(112, 20);
            this.rbNoDisponible.TabIndex = 10;
            this.rbNoDisponible.TabStop = true;
            this.rbNoDisponible.Text = "No Disponible";
            this.rbNoDisponible.UseVisualStyleBackColor = true;
            // 
            // rbDisponible
            // 
            this.rbDisponible.AutoSize = true;
            this.rbDisponible.Location = new System.Drawing.Point(15, 111);
            this.rbDisponible.Name = "rbDisponible";
            this.rbDisponible.Size = new System.Drawing.Size(91, 20);
            this.rbDisponible.TabIndex = 9;
            this.rbDisponible.TabStop = true;
            this.rbDisponible.Text = "Disponible";
            this.rbDisponible.UseVisualStyleBackColor = true;
            // 
            // txtCapacidadZonaEditar
            // 
            this.txtCapacidadZonaEditar.Location = new System.Drawing.Point(93, 83);
            this.txtCapacidadZonaEditar.Name = "txtCapacidadZonaEditar";
            this.txtCapacidadZonaEditar.Size = new System.Drawing.Size(131, 22);
            this.txtCapacidadZonaEditar.TabIndex = 6;
            this.txtCapacidadZonaEditar.Validating += new System.ComponentModel.CancelEventHandler(this.txtCapacidadZonaEditar_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Capacidad";
            // 
            // txtNumeroZonaEditar
            // 
            this.txtNumeroZonaEditar.Location = new System.Drawing.Point(93, 55);
            this.txtNumeroZonaEditar.Name = "txtNumeroZonaEditar";
            this.txtNumeroZonaEditar.Size = new System.Drawing.Size(131, 22);
            this.txtNumeroZonaEditar.TabIndex = 3;
            this.txtNumeroZonaEditar.Validating += new System.ComponentModel.CancelEventHandler(this.txtNumeroZonaEditar_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Numero ";
            // 
            // txtNombreZonaEditar
            // 
            this.txtNombreZonaEditar.Location = new System.Drawing.Point(93, 27);
            this.txtNombreZonaEditar.Name = "txtNombreZonaEditar";
            this.txtNombreZonaEditar.Size = new System.Drawing.Size(131, 22);
            this.txtNombreZonaEditar.TabIndex = 1;
            this.txtNombreZonaEditar.Validating += new System.ComponentModel.CancelEventHandler(this.txtNombreZonaEditar_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre ";
            // 
            // gbInformacionBodegaEditar
            // 
            this.gbInformacionBodegaEditar.Controls.Add(this.label5);
            this.gbInformacionBodegaEditar.Controls.Add(this.label4);
            this.gbInformacionBodegaEditar.Controls.Add(this.txtUbicacionBodegaEditar);
            this.gbInformacionBodegaEditar.Controls.Add(this.txtNombreBodegaEditar);
            this.gbInformacionBodegaEditar.Controls.Add(this.btnAgregarBodegaZona);
            this.gbInformacionBodegaEditar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.gbInformacionBodegaEditar.Location = new System.Drawing.Point(12, 192);
            this.gbInformacionBodegaEditar.Name = "gbInformacionBodegaEditar";
            this.gbInformacionBodegaEditar.Size = new System.Drawing.Size(269, 154);
            this.gbInformacionBodegaEditar.TabIndex = 4;
            this.gbInformacionBodegaEditar.TabStop = false;
            this.gbInformacionBodegaEditar.Text = "Información Bodega";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = "Nombre";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Ubicación";
            // 
            // txtUbicacionBodegaEditar
            // 
            this.txtUbicacionBodegaEditar.Enabled = false;
            this.txtUbicacionBodegaEditar.Location = new System.Drawing.Point(93, 67);
            this.txtUbicacionBodegaEditar.Name = "txtUbicacionBodegaEditar";
            this.txtUbicacionBodegaEditar.Size = new System.Drawing.Size(100, 22);
            this.txtUbicacionBodegaEditar.TabIndex = 3;
            // 
            // txtNombreBodegaEditar
            // 
            this.txtNombreBodegaEditar.Enabled = false;
            this.txtNombreBodegaEditar.Location = new System.Drawing.Point(93, 36);
            this.txtNombreBodegaEditar.Name = "txtNombreBodegaEditar";
            this.txtNombreBodegaEditar.Size = new System.Drawing.Size(100, 22);
            this.txtNombreBodegaEditar.TabIndex = 2;
            // 
            // btnAgregarBodegaZona
            // 
            this.btnAgregarBodegaZona.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregarBodegaZona.Image")));
            this.btnAgregarBodegaZona.Location = new System.Drawing.Point(93, 95);
            this.btnAgregarBodegaZona.Name = "btnAgregarBodegaZona";
            this.btnAgregarBodegaZona.Size = new System.Drawing.Size(31, 30);
            this.btnAgregarBodegaZona.TabIndex = 0;
            this.btnAgregarBodegaZona.UseVisualStyleBackColor = true;
            this.btnAgregarBodegaZona.Click += new System.EventHandler(this.btnAgregarBodegaZona_Click);
            // 
            // frmEditarZona
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 349);
            this.Controls.Add(this.gbInformacionBodegaEditar);
            this.Controls.Add(this.gbInfoZonaEditar);
            this.Controls.Add(this.toolStrip1);
            this.Location = new System.Drawing.Point(30, 0);
            this.Name = "frmEditarZona";
            this.Text = "Editar Zona";
            this.Load += new System.EventHandler(this.frmEditarZona_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.gbInfoZonaEditar.ResumeLayout(false);
            this.gbInfoZonaEditar.PerformLayout();
            this.gbInformacionBodegaEditar.ResumeLayout(false);
            this.gbInformacionBodegaEditar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbGuardarCambiosEditarZona;
        private System.Windows.Forms.ToolStripButton tlbbtnSalir;
        private System.Windows.Forms.GroupBox gbInfoZonaEditar;
        private System.Windows.Forms.TextBox txtCapacidadZonaEditar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNumeroZonaEditar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNombreZonaEditar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbInformacionBodegaEditar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUbicacionBodegaEditar;
        private System.Windows.Forms.TextBox txtNombreBodegaEditar;
        private System.Windows.Forms.Button btnAgregarBodegaZona;
        private System.Windows.Forms.RadioButton rbNoDisponible;
        private System.Windows.Forms.RadioButton rbDisponible;
    }
}