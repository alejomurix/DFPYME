namespace Aplicacion.Inventario.Bodega
{
    partial class frmEditarBodega
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditarBodega));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbGuardarCambiosEditarBodega = new System.Windows.Forms.ToolStripButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNombreBodegaEditar = new System.Windows.Forms.TextBox();
            this.txtUbicacionBodegaEditar = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbGuardarCambiosEditarBodega});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(312, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbGuardarCambiosEditarBodega
            // 
            this.tsbGuardarCambiosEditarBodega.Image = ((System.Drawing.Image)(resources.GetObject("tsbGuardarCambiosEditarBodega.Image")));
            this.tsbGuardarCambiosEditarBodega.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbGuardarCambiosEditarBodega.Name = "tsbGuardarCambiosEditarBodega";
            this.tsbGuardarCambiosEditarBodega.Size = new System.Drawing.Size(78, 22);
            this.tsbGuardarCambiosEditarBodega.Text = "Guardar ";
            this.tsbGuardarCambiosEditarBodega.Click += new System.EventHandler(this.tsbGuardarCambiosEditarBodega_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 30);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nombre";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 78);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ubicación";
            // 
            // txtNombreBodegaEditar
            // 
            this.txtNombreBodegaEditar.Location = new System.Drawing.Point(86, 30);
            this.txtNombreBodegaEditar.Margin = new System.Windows.Forms.Padding(4);
            this.txtNombreBodegaEditar.Name = "txtNombreBodegaEditar";
            this.txtNombreBodegaEditar.Size = new System.Drawing.Size(178, 22);
            this.txtNombreBodegaEditar.TabIndex = 5;
            this.txtNombreBodegaEditar.Validating += new System.ComponentModel.CancelEventHandler(this.txtNombreBodegaEditar_Validating);
            // 
            // txtUbicacionBodegaEditar
            // 
            this.txtUbicacionBodegaEditar.Location = new System.Drawing.Point(86, 78);
            this.txtUbicacionBodegaEditar.Margin = new System.Windows.Forms.Padding(4);
            this.txtUbicacionBodegaEditar.Name = "txtUbicacionBodegaEditar";
            this.txtUbicacionBodegaEditar.Size = new System.Drawing.Size(178, 22);
            this.txtUbicacionBodegaEditar.TabIndex = 6;
            this.txtUbicacionBodegaEditar.Validating += new System.ComponentModel.CancelEventHandler(this.txtUbicacionBodegaEditar_Validating);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtUbicacionBodegaEditar);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtNombreBodegaEditar);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(292, 150);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " Bodega";
            // 
            // frmEditarBodega
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 206);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmEditarBodega";
            this.Text = "Editar Bodega";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbGuardarCambiosEditarBodega;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNombreBodegaEditar;
        private System.Windows.Forms.TextBox txtUbicacionBodegaEditar;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}