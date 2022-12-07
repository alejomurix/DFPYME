namespace Aplicacion.Compras.Egreso.Edit
{
    partial class FrmEditarEgreso
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEditarEgreso));
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.tsBtnGuardar = new System.Windows.Forms.ToolStripButton();
            this.tsBtnSalir = new System.Windows.Forms.ToolStripButton();
            this.gbEgreso = new System.Windows.Forms.GroupBox();
            this.panelEgreso = new System.Windows.Forms.Panel();
            this.lblComprobante = new System.Windows.Forms.Label();
            this.lblNumero = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.gbBeneficiario = new System.Windows.Forms.GroupBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.btnBuscarTercero = new System.Windows.Forms.Button();
            this.txtNit = new System.Windows.Forms.TextBox();
            this.lblBeneficiario = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.tsMenu.SuspendLayout();
            this.gbEgreso.SuspendLayout();
            this.panelEgreso.SuspendLayout();
            this.gbBeneficiario.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMenu
            // 
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnGuardar,
            this.tsBtnSalir});
            this.tsMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(719, 25);
            this.tsMenu.TabIndex = 1;
            this.tsMenu.Text = "toolStrip1";
            // 
            // tsBtnGuardar
            // 
            this.tsBtnGuardar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsBtnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnGuardar.Image")));
            this.tsBtnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnGuardar.Name = "tsBtnGuardar";
            this.tsBtnGuardar.Size = new System.Drawing.Size(101, 22);
            this.tsBtnGuardar.Text = "Guardar [F2]";
            this.tsBtnGuardar.Click += new System.EventHandler(this.tsBtnGuardar_Click);
            // 
            // tsBtnSalir
            // 
            this.tsBtnSalir.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsBtnSalir.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnSalir.Image")));
            this.tsBtnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnSalir.Name = "tsBtnSalir";
            this.tsBtnSalir.Size = new System.Drawing.Size(87, 22);
            this.tsBtnSalir.Text = "Salir [ESC]";
            this.tsBtnSalir.Click += new System.EventHandler(this.tsBtnSalir_Click);
            // 
            // gbEgreso
            // 
            this.gbEgreso.Controls.Add(this.dtpFecha);
            this.gbEgreso.Controls.Add(this.panelEgreso);
            this.gbEgreso.Controls.Add(this.lblFecha);
            this.gbEgreso.Location = new System.Drawing.Point(12, 39);
            this.gbEgreso.Name = "gbEgreso";
            this.gbEgreso.Size = new System.Drawing.Size(688, 73);
            this.gbEgreso.TabIndex = 3;
            this.gbEgreso.TabStop = false;
            this.gbEgreso.Text = "Datos de Egreso";
            // 
            // panelEgreso
            // 
            this.panelEgreso.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panelEgreso.Controls.Add(this.lblComprobante);
            this.panelEgreso.Controls.Add(this.lblNumero);
            this.panelEgreso.Location = new System.Drawing.Point(249, 21);
            this.panelEgreso.Name = "panelEgreso";
            this.panelEgreso.Size = new System.Drawing.Size(425, 35);
            this.panelEgreso.TabIndex = 1;
            // 
            // lblComprobante
            // 
            this.lblComprobante.AutoSize = true;
            this.lblComprobante.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComprobante.Location = new System.Drawing.Point(3, 11);
            this.lblComprobante.Name = "lblComprobante";
            this.lblComprobante.Size = new System.Drawing.Size(244, 16);
            this.lblComprobante.TabIndex = 0;
            this.lblComprobante.Text = "COMPROBANTE DE EGRESO No.";
            // 
            // lblNumero
            // 
            this.lblNumero.AutoSize = true;
            this.lblNumero.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblNumero.Location = new System.Drawing.Point(270, 11);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(16, 16);
            this.lblNumero.TabIndex = 1;
            this.lblNumero.Text = "0";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(7, 34);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(46, 16);
            this.lblFecha.TabIndex = 5;
            this.lblFecha.Text = "Fecha";
            this.lblFecha.Visible = false;
            // 
            // gbBeneficiario
            // 
            this.gbBeneficiario.Controls.Add(this.txtNombre);
            this.gbBeneficiario.Controls.Add(this.btnBuscarTercero);
            this.gbBeneficiario.Controls.Add(this.txtNit);
            this.gbBeneficiario.Controls.Add(this.lblBeneficiario);
            this.gbBeneficiario.Location = new System.Drawing.Point(12, 118);
            this.gbBeneficiario.Name = "gbBeneficiario";
            this.gbBeneficiario.Size = new System.Drawing.Size(688, 67);
            this.gbBeneficiario.TabIndex = 4;
            this.gbBeneficiario.TabStop = false;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(274, 25);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.ReadOnly = true;
            this.txtNombre.Size = new System.Drawing.Size(400, 22);
            this.txtNombre.TabIndex = 6;
            // 
            // btnBuscarTercero
            // 
            this.btnBuscarTercero.Location = new System.Drawing.Point(233, 24);
            this.btnBuscarTercero.Name = "btnBuscarTercero";
            this.btnBuscarTercero.Size = new System.Drawing.Size(25, 24);
            this.btnBuscarTercero.TabIndex = 1;
            this.btnBuscarTercero.Text = "...";
            this.btnBuscarTercero.UseVisualStyleBackColor = true;
            this.btnBuscarTercero.Click += new System.EventHandler(this.btnBuscarTercero_Click);
            // 
            // txtNit
            // 
            this.txtNit.Location = new System.Drawing.Point(69, 25);
            this.txtNit.Name = "txtNit";
            this.txtNit.Size = new System.Drawing.Size(156, 22);
            this.txtNit.TabIndex = 0;
            // 
            // lblBeneficiario
            // 
            this.lblBeneficiario.AutoSize = true;
            this.lblBeneficiario.Location = new System.Drawing.Point(7, 28);
            this.lblBeneficiario.Name = "lblBeneficiario";
            this.lblBeneficiario.Size = new System.Drawing.Size(56, 16);
            this.lblBeneficiario.TabIndex = 3;
            this.lblBeneficiario.Text = "Tercero";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(69, 30);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(114, 22);
            this.dtpFecha.TabIndex = 6;
            // 
            // FrmEditarEgreso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(719, 195);
            this.Controls.Add(this.gbEgreso);
            this.Controls.Add(this.gbBeneficiario);
            this.Controls.Add(this.tsMenu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmEditarEgreso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editar Egreso";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmEditarEgreso_FormClosing);
            this.Load += new System.EventHandler(this.FrmEditarEgreso_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmEditarEgreso_KeyDown);
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.gbEgreso.ResumeLayout(false);
            this.gbEgreso.PerformLayout();
            this.panelEgreso.ResumeLayout(false);
            this.panelEgreso.PerformLayout();
            this.gbBeneficiario.ResumeLayout(false);
            this.gbBeneficiario.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.ToolStripButton tsBtnGuardar;
        private System.Windows.Forms.ToolStripButton tsBtnSalir;
        private System.Windows.Forms.GroupBox gbEgreso;
        private System.Windows.Forms.Panel panelEgreso;
        private System.Windows.Forms.Label lblComprobante;
        private System.Windows.Forms.Label lblNumero;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.GroupBox gbBeneficiario;
        private System.Windows.Forms.Button btnBuscarTercero;
        private System.Windows.Forms.TextBox txtNit;
        private System.Windows.Forms.Label lblBeneficiario;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.DateTimePicker dtpFecha;
    }
}