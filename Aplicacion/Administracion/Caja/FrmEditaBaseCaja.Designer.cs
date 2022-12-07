namespace Aplicacion.Administracion.Caja
{
    partial class FrmEditaBaseCaja
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEditaBaseCaja));
            this.gbDatosApertura = new System.Windows.Forms.GroupBox();
            this.btnEditarFecha = new System.Windows.Forms.Button();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.txtCierre = new System.Windows.Forms.TextBox();
            this.lblCierre = new System.Windows.Forms.Label();
            this.txtApertura = new System.Windows.Forms.TextBox();
            this.lblApertura = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.tsMenuDatosApertura = new System.Windows.Forms.ToolStrip();
            this.tsBtnGuardar = new System.Windows.Forms.ToolStripButton();
            this.tsBtnSalir = new System.Windows.Forms.ToolStripButton();
            this.gbDatosApertura.SuspendLayout();
            this.tsMenuDatosApertura.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbDatosApertura
            // 
            this.gbDatosApertura.Controls.Add(this.btnEditarFecha);
            this.gbDatosApertura.Controls.Add(this.txtFecha);
            this.gbDatosApertura.Controls.Add(this.txtCierre);
            this.gbDatosApertura.Controls.Add(this.lblCierre);
            this.gbDatosApertura.Controls.Add(this.txtApertura);
            this.gbDatosApertura.Controls.Add(this.lblApertura);
            this.gbDatosApertura.Controls.Add(this.lblFecha);
            this.gbDatosApertura.Controls.Add(this.dtpFecha);
            this.gbDatosApertura.Controls.Add(this.tsMenuDatosApertura);
            this.gbDatosApertura.Location = new System.Drawing.Point(12, 12);
            this.gbDatosApertura.Name = "gbDatosApertura";
            this.gbDatosApertura.Size = new System.Drawing.Size(390, 204);
            this.gbDatosApertura.TabIndex = 1;
            this.gbDatosApertura.TabStop = false;
            this.gbDatosApertura.Text = "Datos de Apertura";
            // 
            // btnEditarFecha
            // 
            this.btnEditarFecha.Image = ((System.Drawing.Image)(resources.GetObject("btnEditarFecha.Image")));
            this.btnEditarFecha.Location = new System.Drawing.Point(348, 65);
            this.btnEditarFecha.Name = "btnEditarFecha";
            this.btnEditarFecha.Size = new System.Drawing.Size(24, 24);
            this.btnEditarFecha.TabIndex = 8;
            this.btnEditarFecha.UseVisualStyleBackColor = true;
            this.btnEditarFecha.Click += new System.EventHandler(this.btnEditarFecha_Click);
            // 
            // txtFecha
            // 
            this.txtFecha.Enabled = false;
            this.txtFecha.Location = new System.Drawing.Point(82, 66);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(259, 22);
            this.txtFecha.TabIndex = 7;
            this.txtFecha.Text = "0";
            // 
            // txtCierre
            // 
            this.txtCierre.Location = new System.Drawing.Point(82, 155);
            this.txtCierre.Name = "txtCierre";
            this.txtCierre.Size = new System.Drawing.Size(259, 22);
            this.txtCierre.TabIndex = 5;
            this.txtCierre.Text = "0";
            this.txtCierre.Validating += new System.ComponentModel.CancelEventHandler(this.txtCierre_Validating);
            // 
            // lblCierre
            // 
            this.lblCierre.AutoSize = true;
            this.lblCierre.Location = new System.Drawing.Point(17, 158);
            this.lblCierre.Name = "lblCierre";
            this.lblCierre.Size = new System.Drawing.Size(44, 16);
            this.lblCierre.TabIndex = 6;
            this.lblCierre.Text = "Cierre";
            // 
            // txtApertura
            // 
            this.txtApertura.Location = new System.Drawing.Point(82, 109);
            this.txtApertura.Name = "txtApertura";
            this.txtApertura.Size = new System.Drawing.Size(259, 22);
            this.txtApertura.TabIndex = 1;
            this.txtApertura.Text = "0";
            this.txtApertura.Validating += new System.ComponentModel.CancelEventHandler(this.txtApertura_Validating);
            // 
            // lblApertura
            // 
            this.lblApertura.AutoSize = true;
            this.lblApertura.Location = new System.Drawing.Point(17, 112);
            this.lblApertura.Name = "lblApertura";
            this.lblApertura.Size = new System.Drawing.Size(59, 16);
            this.lblApertura.TabIndex = 4;
            this.lblApertura.Text = "Apertura";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(16, 69);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(46, 16);
            this.lblFecha.TabIndex = 3;
            this.lblFecha.Text = "Fecha";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(82, 66);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(259, 22);
            this.dtpFecha.TabIndex = 2;
            this.dtpFecha.Visible = false;
            // 
            // tsMenuDatosApertura
            // 
            this.tsMenuDatosApertura.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnGuardar,
            this.tsBtnSalir});
            this.tsMenuDatosApertura.Location = new System.Drawing.Point(3, 18);
            this.tsMenuDatosApertura.Name = "tsMenuDatosApertura";
            this.tsMenuDatosApertura.Size = new System.Drawing.Size(384, 25);
            this.tsMenuDatosApertura.TabIndex = 0;
            this.tsMenuDatosApertura.Text = "toolStrip1";
            // 
            // tsBtnGuardar
            // 
            this.tsBtnGuardar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsBtnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnGuardar.Image")));
            this.tsBtnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnGuardar.Name = "tsBtnGuardar";
            this.tsBtnGuardar.Size = new System.Drawing.Size(76, 22);
            this.tsBtnGuardar.Text = "Guardar";
            this.tsBtnGuardar.Click += new System.EventHandler(this.tsBtnGuardar_Click);
            // 
            // tsBtnSalir
            // 
            this.tsBtnSalir.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsBtnSalir.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnSalir.Image")));
            this.tsBtnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnSalir.Name = "tsBtnSalir";
            this.tsBtnSalir.Size = new System.Drawing.Size(53, 22);
            this.tsBtnSalir.Text = "Salir";
            this.tsBtnSalir.Click += new System.EventHandler(this.tsBtnSalir_Click);
            // 
            // FrmEditaBaseCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(414, 227);
            this.Controls.Add(this.gbDatosApertura);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmEditaBaseCaja";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editar Caja";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmEditaBaseCaja_FormClosing);
            this.Load += new System.EventHandler(this.FrmEditaBaseCaja_Load);
            this.gbDatosApertura.ResumeLayout(false);
            this.gbDatosApertura.PerformLayout();
            this.tsMenuDatosApertura.ResumeLayout(false);
            this.tsMenuDatosApertura.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDatosApertura;
        private System.Windows.Forms.TextBox txtCierre;
        private System.Windows.Forms.Label lblCierre;
        private System.Windows.Forms.TextBox txtApertura;
        private System.Windows.Forms.Label lblApertura;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.ToolStrip tsMenuDatosApertura;
        private System.Windows.Forms.ToolStripButton tsBtnGuardar;
        private System.Windows.Forms.ToolStripButton tsBtnSalir;
        private System.Windows.Forms.TextBox txtFecha;
        private System.Windows.Forms.Button btnEditarFecha;
    }
}