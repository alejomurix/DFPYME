namespace Aplicacion.Compras.IngresarCompra.ConsultaRemision
{
    partial class FrmDatosFactura
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDatosFactura));
            this.gbDatosFactura = new System.Windows.Forms.GroupBox();
            this.lblNumeroFactura = new System.Windows.Forms.Label();
            this.txtNumeroFactura = new System.Windows.Forms.TextBox();
            this.lblFormaPago = new System.Windows.Forms.Label();
            this.cbFormaPago = new System.Windows.Forms.ComboBox();
            this.lblFechaLimite = new System.Windows.Forms.Label();
            this.dtpFechaLimite = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaIngreso = new System.Windows.Forms.DateTimePicker();
            this.lblFechaIngreso = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gbDatosFactura.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbDatosFactura
            // 
            this.gbDatosFactura.Controls.Add(this.lblNumeroFactura);
            this.gbDatosFactura.Controls.Add(this.txtNumeroFactura);
            this.gbDatosFactura.Controls.Add(this.lblFormaPago);
            this.gbDatosFactura.Controls.Add(this.cbFormaPago);
            this.gbDatosFactura.Controls.Add(this.lblFechaIngreso);
            this.gbDatosFactura.Controls.Add(this.dtpFechaIngreso);
            this.gbDatosFactura.Controls.Add(this.lblFechaLimite);
            this.gbDatosFactura.Controls.Add(this.dtpFechaLimite);
            this.gbDatosFactura.Controls.Add(this.btnOk);
            this.gbDatosFactura.Controls.Add(this.btnCancel);
            this.gbDatosFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.gbDatosFactura.Location = new System.Drawing.Point(12, 12);
            this.gbDatosFactura.Name = "gbDatosFactura";
            this.gbDatosFactura.Size = new System.Drawing.Size(322, 228);
            this.gbDatosFactura.TabIndex = 2;
            this.gbDatosFactura.TabStop = false;
            this.gbDatosFactura.Text = "Datos de Factura";
            // 
            // lblNumeroFactura
            // 
            this.lblNumeroFactura.AutoSize = true;
            this.lblNumeroFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblNumeroFactura.Location = new System.Drawing.Point(11, 25);
            this.lblNumeroFactura.Name = "lblNumeroFactura";
            this.lblNumeroFactura.Size = new System.Drawing.Size(123, 16);
            this.lblNumeroFactura.TabIndex = 10;
            this.lblNumeroFactura.Text = "Número de Factura";
            // 
            // txtNumeroFactura
            // 
            this.txtNumeroFactura.Location = new System.Drawing.Point(140, 23);
            this.txtNumeroFactura.MaxLength = 20;
            this.txtNumeroFactura.Name = "txtNumeroFactura";
            this.txtNumeroFactura.Size = new System.Drawing.Size(159, 22);
            this.txtNumeroFactura.TabIndex = 5;
            // 
            // lblFormaPago
            // 
            this.lblFormaPago.AutoSize = true;
            this.lblFormaPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblFormaPago.Location = new System.Drawing.Point(11, 65);
            this.lblFormaPago.Name = "lblFormaPago";
            this.lblFormaPago.Size = new System.Drawing.Size(102, 16);
            this.lblFormaPago.TabIndex = 12;
            this.lblFormaPago.Text = "Forma de Pago";
            // 
            // cbFormaPago
            // 
            this.cbFormaPago.DisplayMember = "descripcionestado";
            this.cbFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFormaPago.FormattingEnabled = true;
            this.cbFormaPago.Location = new System.Drawing.Point(140, 62);
            this.cbFormaPago.Name = "cbFormaPago";
            this.cbFormaPago.Size = new System.Drawing.Size(159, 24);
            this.cbFormaPago.TabIndex = 6;
            this.cbFormaPago.ValueMember = "idestado";
            // 
            // lblFechaLimite
            // 
            this.lblFechaLimite.AutoSize = true;
            this.lblFechaLimite.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblFechaLimite.Location = new System.Drawing.Point(11, 143);
            this.lblFechaLimite.Name = "lblFechaLimite";
            this.lblFechaLimite.Size = new System.Drawing.Size(84, 16);
            this.lblFechaLimite.TabIndex = 13;
            this.lblFechaLimite.Text = "Fecha Limite";
            // 
            // dtpFechaLimite
            // 
            this.dtpFechaLimite.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaLimite.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaLimite.Location = new System.Drawing.Point(140, 138);
            this.dtpFechaLimite.Name = "dtpFechaLimite";
            this.dtpFechaLimite.Size = new System.Drawing.Size(159, 22);
            this.dtpFechaLimite.TabIndex = 7;
            // 
            // dtpFechaIngreso
            // 
            this.dtpFechaIngreso.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaIngreso.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaIngreso.Location = new System.Drawing.Point(140, 103);
            this.dtpFechaIngreso.Name = "dtpFechaIngreso";
            this.dtpFechaIngreso.Size = new System.Drawing.Size(159, 22);
            this.dtpFechaIngreso.TabIndex = 7;
            // 
            // lblFechaIngreso
            // 
            this.lblFechaIngreso.AutoSize = true;
            this.lblFechaIngreso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblFechaIngreso.Location = new System.Drawing.Point(11, 108);
            this.lblFechaIngreso.Name = "lblFechaIngreso";
            this.lblFechaIngreso.Size = new System.Drawing.Size(94, 16);
            this.lblFechaIngreso.TabIndex = 11;
            this.lblFechaIngreso.Text = "Fecha Ingreso";
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnOk.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.Image")));
            this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOk.Location = new System.Drawing.Point(118, 180);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(83, 25);
            this.btnOk.TabIndex = 14;
            this.btnOk.Text = "Aceptar";
            this.btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.No;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(211, 180);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 25);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FrmDatosFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(352, 255);
            this.Controls.Add(this.gbDatosFactura);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDatosFactura";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Datos Factura";
            this.Load += new System.EventHandler(this.FrmDatosFactura_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmDatosFactura_KeyDown);
            this.gbDatosFactura.ResumeLayout(false);
            this.gbDatosFactura.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDatosFactura;
        private System.Windows.Forms.Label lblNumeroFactura;
        private System.Windows.Forms.TextBox txtNumeroFactura;
        private System.Windows.Forms.Label lblFormaPago;
        private System.Windows.Forms.ComboBox cbFormaPago;
        private System.Windows.Forms.Label lblFechaLimite;
        private System.Windows.Forms.DateTimePicker dtpFechaLimite;
        private System.Windows.Forms.Label lblFechaIngreso;
        private System.Windows.Forms.DateTimePicker dtpFechaIngreso;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}