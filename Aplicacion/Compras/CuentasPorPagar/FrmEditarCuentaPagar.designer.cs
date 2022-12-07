namespace Aplicacion.Compras.CuentasPorPagar
{
    partial class FrmEditarCuentaPagar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEditarCuentaPagar));
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.tsBtnGuardar = new System.Windows.Forms.ToolStripButton();
            this.tsBtnSalir = new System.Windows.Forms.ToolStripButton();
            this.gbTercero = new System.Windows.Forms.GroupBox();
            this.lblTercero = new System.Windows.Forms.Label();
            this.txtNit = new System.Windows.Forms.TextBox();
            this.btnBuscarTercero = new System.Windows.Forms.Button();
            this.txtTercero = new System.Windows.Forms.TextBox();
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.cbDocumento = new System.Windows.Forms.ComboBox();
            this.btnEditarDocumento = new System.Windows.Forms.Button();
            this.btnDeshacerDocumento = new System.Windows.Forms.Button();
            this.gbDatos = new System.Windows.Forms.GroupBox();
            this.lblNumero = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblFechaLimite = new System.Windows.Forms.Label();
            this.dtpLimite = new System.Windows.Forms.DateTimePicker();
            this.lblCuenta = new System.Windows.Forms.Label();
            this.cbCuentas = new System.Windows.Forms.ComboBox();
            this.gbRetencion = new System.Windows.Forms.GroupBox();
            this.lblRetencion = new System.Windows.Forms.Label();
            this.lblPesoRetencion = new System.Windows.Forms.Label();
            this.txtRetencion = new System.Windows.Forms.TextBox();
            this.lblTasaRetencion = new System.Windows.Forms.Label();
            this.btnInfoRete = new System.Windows.Forms.Button();
            this.btnCambiarRetencion = new System.Windows.Forms.Button();
            this.tsMenu.SuspendLayout();
            this.gbTercero.SuspendLayout();
            this.gbDatos.SuspendLayout();
            this.gbRetencion.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMenu
            // 
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnGuardar,
            this.tsBtnSalir});
            this.tsMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(900, 25);
            this.tsMenu.TabIndex = 2;
            this.tsMenu.Text = "Menu";
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
            // gbTercero
            // 
            this.gbTercero.Controls.Add(this.lblTercero);
            this.gbTercero.Controls.Add(this.txtNit);
            this.gbTercero.Controls.Add(this.btnBuscarTercero);
            this.gbTercero.Controls.Add(this.txtTercero);
            this.gbTercero.Controls.Add(this.txtDocumento);
            this.gbTercero.Controls.Add(this.cbDocumento);
            this.gbTercero.Controls.Add(this.btnEditarDocumento);
            this.gbTercero.Controls.Add(this.btnDeshacerDocumento);
            this.gbTercero.Location = new System.Drawing.Point(7, 36);
            this.gbTercero.Name = "gbTercero";
            this.gbTercero.Size = new System.Drawing.Size(881, 67);
            this.gbTercero.TabIndex = 4;
            this.gbTercero.TabStop = false;
            // 
            // lblTercero
            // 
            this.lblTercero.AutoSize = true;
            this.lblTercero.Location = new System.Drawing.Point(6, 28);
            this.lblTercero.Name = "lblTercero";
            this.lblTercero.Size = new System.Drawing.Size(56, 16);
            this.lblTercero.TabIndex = 3;
            this.lblTercero.Text = "Tercero";
            // 
            // txtNit
            // 
            this.txtNit.Location = new System.Drawing.Point(64, 25);
            this.txtNit.Name = "txtNit";
            this.txtNit.Size = new System.Drawing.Size(144, 22);
            this.txtNit.TabIndex = 0;
            this.txtNit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNit_KeyPress);
            // 
            // btnBuscarTercero
            // 
            this.btnBuscarTercero.Location = new System.Drawing.Point(213, 24);
            this.btnBuscarTercero.Name = "btnBuscarTercero";
            this.btnBuscarTercero.Size = new System.Drawing.Size(25, 24);
            this.btnBuscarTercero.TabIndex = 1;
            this.btnBuscarTercero.Text = "...";
            this.btnBuscarTercero.UseVisualStyleBackColor = true;
            this.btnBuscarTercero.Click += new System.EventHandler(this.btnBuscarTercero_Click);
            // 
            // txtTercero
            // 
            this.txtTercero.Location = new System.Drawing.Point(244, 25);
            this.txtTercero.Name = "txtTercero";
            this.txtTercero.ReadOnly = true;
            this.txtTercero.Size = new System.Drawing.Size(391, 22);
            this.txtTercero.TabIndex = 6;
            // 
            // txtDocumento
            // 
            this.txtDocumento.Location = new System.Drawing.Point(641, 25);
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.ReadOnly = true;
            this.txtDocumento.Size = new System.Drawing.Size(206, 22);
            this.txtDocumento.TabIndex = 39;
            // 
            // cbDocumento
            // 
            this.cbDocumento.DisplayMember = "Nombre";
            this.cbDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDocumento.FormattingEnabled = true;
            this.cbDocumento.Location = new System.Drawing.Point(641, 24);
            this.cbDocumento.Name = "cbDocumento";
            this.cbDocumento.Size = new System.Drawing.Size(206, 24);
            this.cbDocumento.TabIndex = 16;
            this.cbDocumento.ValueMember = "Id";
            this.cbDocumento.Visible = false;
            this.cbDocumento.SelectionChangeCommitted += new System.EventHandler(this.cbDocumento_SelectionChangeCommitted);
            // 
            // btnEditarDocumento
            // 
            this.btnEditarDocumento.Image = ((System.Drawing.Image)(resources.GetObject("btnEditarDocumento.Image")));
            this.btnEditarDocumento.Location = new System.Drawing.Point(850, 25);
            this.btnEditarDocumento.Name = "btnEditarDocumento";
            this.btnEditarDocumento.Size = new System.Drawing.Size(25, 22);
            this.btnEditarDocumento.TabIndex = 17;
            this.btnEditarDocumento.UseVisualStyleBackColor = true;
            this.btnEditarDocumento.Click += new System.EventHandler(this.btnEditarDocumento_Click);
            // 
            // btnDeshacerDocumento
            // 
            this.btnDeshacerDocumento.Image = ((System.Drawing.Image)(resources.GetObject("btnDeshacerDocumento.Image")));
            this.btnDeshacerDocumento.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDeshacerDocumento.Location = new System.Drawing.Point(850, 25);
            this.btnDeshacerDocumento.Name = "btnDeshacerDocumento";
            this.btnDeshacerDocumento.Size = new System.Drawing.Size(25, 22);
            this.btnDeshacerDocumento.TabIndex = 18;
            this.btnDeshacerDocumento.UseVisualStyleBackColor = true;
            this.btnDeshacerDocumento.Visible = false;
            this.btnDeshacerDocumento.Click += new System.EventHandler(this.btnDeshacerDocumento_Click);
            // 
            // gbDatos
            // 
            this.gbDatos.Controls.Add(this.lblNumero);
            this.gbDatos.Controls.Add(this.txtNumero);
            this.gbDatos.Controls.Add(this.lblFecha);
            this.gbDatos.Controls.Add(this.dtpFecha);
            this.gbDatos.Controls.Add(this.lblFechaLimite);
            this.gbDatos.Controls.Add(this.dtpLimite);
            this.gbDatos.Controls.Add(this.lblCuenta);
            this.gbDatos.Controls.Add(this.cbCuentas);
            this.gbDatos.Location = new System.Drawing.Point(7, 109);
            this.gbDatos.Name = "gbDatos";
            this.gbDatos.Size = new System.Drawing.Size(881, 62);
            this.gbDatos.TabIndex = 18;
            this.gbDatos.TabStop = false;
            // 
            // lblNumero
            // 
            this.lblNumero.AutoSize = true;
            this.lblNumero.Location = new System.Drawing.Point(12, 26);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(56, 16);
            this.lblNumero.TabIndex = 23;
            this.lblNumero.Text = "Número";
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(79, 23);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(129, 22);
            this.txtNumero.TabIndex = 22;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(230, 26);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(46, 16);
            this.lblFecha.TabIndex = 10;
            this.lblFecha.Text = "Fecha";
            // 
            // dtpFecha
            // 
            this.dtpFecha.CustomFormat = "dd/MM/yyyy";
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecha.Location = new System.Drawing.Point(281, 23);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(84, 22);
            this.dtpFecha.TabIndex = 19;
            // 
            // lblFechaLimite
            // 
            this.lblFechaLimite.AutoSize = true;
            this.lblFechaLimite.Location = new System.Drawing.Point(391, 27);
            this.lblFechaLimite.Name = "lblFechaLimite";
            this.lblFechaLimite.Size = new System.Drawing.Size(84, 16);
            this.lblFechaLimite.TabIndex = 20;
            this.lblFechaLimite.Text = "Fecha Limite";
            // 
            // dtpLimite
            // 
            this.dtpLimite.CustomFormat = "dd/MM/yyyy";
            this.dtpLimite.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpLimite.Location = new System.Drawing.Point(479, 23);
            this.dtpLimite.Name = "dtpLimite";
            this.dtpLimite.Size = new System.Drawing.Size(84, 22);
            this.dtpLimite.TabIndex = 21;
            // 
            // lblCuenta
            // 
            this.lblCuenta.AutoSize = true;
            this.lblCuenta.Location = new System.Drawing.Point(581, 26);
            this.lblCuenta.Name = "lblCuenta";
            this.lblCuenta.Size = new System.Drawing.Size(50, 16);
            this.lblCuenta.TabIndex = 8;
            this.lblCuenta.Text = "Cuenta";
            // 
            // cbCuentas
            // 
            this.cbCuentas.DisplayMember = "Nombre";
            this.cbCuentas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCuentas.FormattingEnabled = true;
            this.cbCuentas.Location = new System.Drawing.Point(641, 20);
            this.cbCuentas.Name = "cbCuentas";
            this.cbCuentas.Size = new System.Drawing.Size(213, 24);
            this.cbCuentas.TabIndex = 7;
            this.cbCuentas.ValueMember = "Id";
            // 
            // gbRetencion
            // 
            this.gbRetencion.Controls.Add(this.lblRetencion);
            this.gbRetencion.Controls.Add(this.lblPesoRetencion);
            this.gbRetencion.Controls.Add(this.txtRetencion);
            this.gbRetencion.Controls.Add(this.lblTasaRetencion);
            this.gbRetencion.Controls.Add(this.btnInfoRete);
            this.gbRetencion.Controls.Add(this.btnCambiarRetencion);
            this.gbRetencion.Location = new System.Drawing.Point(7, 177);
            this.gbRetencion.Name = "gbRetencion";
            this.gbRetencion.Size = new System.Drawing.Size(881, 67);
            this.gbRetencion.TabIndex = 21;
            this.gbRetencion.TabStop = false;
            // 
            // lblRetencion
            // 
            this.lblRetencion.AutoSize = true;
            this.lblRetencion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRetencion.Location = new System.Drawing.Point(12, 30);
            this.lblRetencion.Name = "lblRetencion";
            this.lblRetencion.Size = new System.Drawing.Size(100, 16);
            this.lblRetencion.TabIndex = 34;
            this.lblRetencion.Text = "RETENCION:";
            // 
            // lblPesoRetencion
            // 
            this.lblPesoRetencion.AutoSize = true;
            this.lblPesoRetencion.Location = new System.Drawing.Point(116, 30);
            this.lblPesoRetencion.Name = "lblPesoRetencion";
            this.lblPesoRetencion.Size = new System.Drawing.Size(15, 16);
            this.lblPesoRetencion.TabIndex = 35;
            this.lblPesoRetencion.Text = "$";
            // 
            // txtRetencion
            // 
            this.txtRetencion.BackColor = System.Drawing.SystemColors.Control;
            this.txtRetencion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRetencion.Location = new System.Drawing.Point(133, 27);
            this.txtRetencion.MaxLength = 10;
            this.txtRetencion.Name = "txtRetencion";
            this.txtRetencion.ReadOnly = true;
            this.txtRetencion.Size = new System.Drawing.Size(100, 22);
            this.txtRetencion.TabIndex = 33;
            this.txtRetencion.Text = "0";
            this.txtRetencion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTasaRetencion
            // 
            this.lblTasaRetencion.AutoSize = true;
            this.lblTasaRetencion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTasaRetencion.Location = new System.Drawing.Point(237, 30);
            this.lblTasaRetencion.Name = "lblTasaRetencion";
            this.lblTasaRetencion.Size = new System.Drawing.Size(27, 16);
            this.lblTasaRetencion.TabIndex = 36;
            this.lblTasaRetencion.Text = "0%";
            // 
            // btnInfoRete
            // 
            this.btnInfoRete.FlatAppearance.BorderSize = 0;
            this.btnInfoRete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInfoRete.Image = ((System.Drawing.Image)(resources.GetObject("btnInfoRete.Image")));
            this.btnInfoRete.Location = new System.Drawing.Point(286, 25);
            this.btnInfoRete.Name = "btnInfoRete";
            this.btnInfoRete.Size = new System.Drawing.Size(25, 23);
            this.btnInfoRete.TabIndex = 37;
            this.btnInfoRete.UseVisualStyleBackColor = true;
            // 
            // btnCambiarRetencion
            // 
            this.btnCambiarRetencion.Image = ((System.Drawing.Image)(resources.GetObject("btnCambiarRetencion.Image")));
            this.btnCambiarRetencion.Location = new System.Drawing.Point(321, 24);
            this.btnCambiarRetencion.Name = "btnCambiarRetencion";
            this.btnCambiarRetencion.Size = new System.Drawing.Size(22, 26);
            this.btnCambiarRetencion.TabIndex = 38;
            this.btnCambiarRetencion.UseVisualStyleBackColor = true;
            this.btnCambiarRetencion.Click += new System.EventHandler(this.btnCambiarRetencion_Click);
            // 
            // FrmEditarCuentaPagar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(900, 262);
            this.Controls.Add(this.tsMenu);
            this.Controls.Add(this.gbTercero);
            this.Controls.Add(this.gbDatos);
            this.Controls.Add(this.gbRetencion);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmEditarCuentaPagar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editar Cuenta por Pagar";
            this.Load += new System.EventHandler(this.FrmCuentaPagar_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmEditarCuentaPagar_KeyDown);
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.gbTercero.ResumeLayout(false);
            this.gbTercero.PerformLayout();
            this.gbDatos.ResumeLayout(false);
            this.gbDatos.PerformLayout();
            this.gbRetencion.ResumeLayout(false);
            this.gbRetencion.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.ToolStripButton tsBtnGuardar;
        private System.Windows.Forms.ToolStripButton tsBtnSalir;
        private System.Windows.Forms.GroupBox gbTercero;
        private System.Windows.Forms.TextBox txtTercero;
        private System.Windows.Forms.Button btnBuscarTercero;
        private System.Windows.Forms.TextBox txtNit;
        private System.Windows.Forms.Label lblTercero;
        private System.Windows.Forms.ComboBox cbDocumento;
        private System.Windows.Forms.GroupBox gbDatos;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblCuenta;
        private System.Windows.Forms.ComboBox cbCuentas;
        private System.Windows.Forms.DateTimePicker dtpLimite;
        private System.Windows.Forms.Label lblFechaLimite;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.GroupBox gbRetencion;
        private System.Windows.Forms.Button btnCambiarRetencion;
        private System.Windows.Forms.Label lblRetencion;
        private System.Windows.Forms.TextBox txtRetencion;
        private System.Windows.Forms.Button btnInfoRete;
        private System.Windows.Forms.Label lblPesoRetencion;
        private System.Windows.Forms.Label lblTasaRetencion;
        private System.Windows.Forms.Label lblNumero;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Button btnEditarDocumento;
        private System.Windows.Forms.Button btnDeshacerDocumento;
        private System.Windows.Forms.TextBox txtDocumento;
    }
}