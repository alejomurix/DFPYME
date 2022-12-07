namespace Aplicacion.Administracion.Caja
{
    partial class FrCierreCaja
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrCierreCaja));
            this.gbDatosCierre = new System.Windows.Forms.GroupBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblCaja = new System.Windows.Forms.Label();
            this.lblNoCaja = new System.Windows.Forms.Label();
            this.lblTurno = new System.Windows.Forms.Label();
            this.lblNoTurno = new System.Windows.Forms.Label();
            this.lblEfectivo = new System.Windows.Forms.Label();
            this.txtEfectivo = new System.Windows.Forms.TextBox();
            this.txtCheque = new System.Windows.Forms.TextBox();
            this.txtTarjeta = new System.Windows.Forms.TextBox();
            this.lblTransaccion = new System.Windows.Forms.Label();
            this.txtTransaccion = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.gbDatosCierre.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbDatosCierre
            // 
            this.gbDatosCierre.Controls.Add(this.lblFecha);
            this.gbDatosCierre.Controls.Add(this.dtpFecha);
            this.gbDatosCierre.Controls.Add(this.lblCaja);
            this.gbDatosCierre.Controls.Add(this.lblNoCaja);
            this.gbDatosCierre.Controls.Add(this.lblTurno);
            this.gbDatosCierre.Controls.Add(this.lblNoTurno);
            this.gbDatosCierre.Controls.Add(this.lblEfectivo);
            this.gbDatosCierre.Controls.Add(this.txtEfectivo);
            this.gbDatosCierre.Controls.Add(this.txtCheque);
            this.gbDatosCierre.Controls.Add(this.txtTarjeta);
            this.gbDatosCierre.Controls.Add(this.lblTransaccion);
            this.gbDatosCierre.Controls.Add(this.txtTransaccion);
            this.gbDatosCierre.Controls.Add(this.btnGuardar);
            this.gbDatosCierre.Location = new System.Drawing.Point(10, 6);
            this.gbDatosCierre.Name = "gbDatosCierre";
            this.gbDatosCierre.Size = new System.Drawing.Size(357, 219);
            this.gbDatosCierre.TabIndex = 1;
            this.gbDatosCierre.TabStop = false;
            this.gbDatosCierre.Text = "Datos de Cierre";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(12, 26);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(46, 16);
            this.lblFecha.TabIndex = 3;
            this.lblFecha.Text = "Fecha";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Enabled = false;
            this.dtpFecha.Location = new System.Drawing.Point(78, 23);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(259, 22);
            this.dtpFecha.TabIndex = 2;
            // 
            // lblCaja
            // 
            this.lblCaja.AutoSize = true;
            this.lblCaja.Location = new System.Drawing.Point(13, 57);
            this.lblCaja.Name = "lblCaja";
            this.lblCaja.Size = new System.Drawing.Size(36, 16);
            this.lblCaja.TabIndex = 34;
            this.lblCaja.Text = "Caja";
            // 
            // lblNoCaja
            // 
            this.lblNoCaja.AutoSize = true;
            this.lblNoCaja.Location = new System.Drawing.Point(98, 57);
            this.lblNoCaja.Name = "lblNoCaja";
            this.lblNoCaja.Size = new System.Drawing.Size(11, 16);
            this.lblNoCaja.TabIndex = 35;
            this.lblNoCaja.Text = ".";
            // 
            // lblTurno
            // 
            this.lblTurno.AutoSize = true;
            this.lblTurno.Location = new System.Drawing.Point(13, 91);
            this.lblTurno.Name = "lblTurno";
            this.lblTurno.Size = new System.Drawing.Size(43, 16);
            this.lblTurno.TabIndex = 36;
            this.lblTurno.Text = "Turno";
            // 
            // lblNoTurno
            // 
            this.lblNoTurno.AutoSize = true;
            this.lblNoTurno.Location = new System.Drawing.Point(98, 91);
            this.lblNoTurno.Name = "lblNoTurno";
            this.lblNoTurno.Size = new System.Drawing.Size(11, 16);
            this.lblNoTurno.TabIndex = 37;
            this.lblNoTurno.Text = ".";
            // 
            // lblEfectivo
            // 
            this.lblEfectivo.AutoSize = true;
            this.lblEfectivo.Location = new System.Drawing.Point(13, 127);
            this.lblEfectivo.Name = "lblEfectivo";
            this.lblEfectivo.Size = new System.Drawing.Size(56, 16);
            this.lblEfectivo.TabIndex = 4;
            this.lblEfectivo.Text = "Efectivo";
            // 
            // txtEfectivo
            // 
            this.txtEfectivo.Location = new System.Drawing.Point(101, 124);
            this.txtEfectivo.Name = "txtEfectivo";
            this.txtEfectivo.Size = new System.Drawing.Size(236, 22);
            this.txtEfectivo.TabIndex = 1;
            this.txtEfectivo.Text = "0";
            this.txtEfectivo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEfectivo_KeyPress);
            this.txtEfectivo.Validating += new System.ComponentModel.CancelEventHandler(this.txtCierre_Validating);
            // 
            // txtCheque
            // 
            this.txtCheque.Location = new System.Drawing.Point(311, 57);
            this.txtCheque.Name = "txtCheque";
            this.txtCheque.Size = new System.Drawing.Size(20, 22);
            this.txtCheque.TabIndex = 28;
            this.txtCheque.Text = "0";
            this.txtCheque.Visible = false;
            this.txtCheque.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCheque_KeyPress);
            this.txtCheque.Validating += new System.ComponentModel.CancelEventHandler(this.txtCheque_Validating);
            // 
            // txtTarjeta
            // 
            this.txtTarjeta.Location = new System.Drawing.Point(311, 85);
            this.txtTarjeta.Name = "txtTarjeta";
            this.txtTarjeta.Size = new System.Drawing.Size(25, 22);
            this.txtTarjeta.TabIndex = 30;
            this.txtTarjeta.Text = "0";
            this.txtTarjeta.Visible = false;
            this.txtTarjeta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTarjeta_KeyPress);
            this.txtTarjeta.Validating += new System.ComponentModel.CancelEventHandler(this.txtTarjeta_Validating);
            // 
            // lblTransaccion
            // 
            this.lblTransaccion.AutoSize = true;
            this.lblTransaccion.Location = new System.Drawing.Point(12, 159);
            this.lblTransaccion.Name = "lblTransaccion";
            this.lblTransaccion.Size = new System.Drawing.Size(83, 16);
            this.lblTransaccion.TabIndex = 33;
            this.lblTransaccion.Text = "Transacción";
            // 
            // txtTransaccion
            // 
            this.txtTransaccion.Location = new System.Drawing.Point(101, 156);
            this.txtTransaccion.Name = "txtTransaccion";
            this.txtTransaccion.Size = new System.Drawing.Size(236, 22);
            this.txtTransaccion.TabIndex = 32;
            this.txtTransaccion.Text = "0";
            this.txtTransaccion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTransaccion_KeyPress);
            this.txtTransaccion.Validating += new System.ComponentModel.CancelEventHandler(this.txtTransaccion_Validating);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.Location = new System.Drawing.Point(253, 186);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(83, 25);
            this.btnGuardar.TabIndex = 27;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // FrCierreCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(381, 234);
            this.Controls.Add(this.gbDatosCierre);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrCierreCaja";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cierre de Caja";
            this.Load += new System.EventHandler(this.FrCierreCaja_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrCierreCaja_KeyDown);
            this.gbDatosCierre.ResumeLayout(false);
            this.gbDatosCierre.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDatosCierre;
        private System.Windows.Forms.TextBox txtEfectivo;
        private System.Windows.Forms.Label lblEfectivo;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TextBox txtTransaccion;
        private System.Windows.Forms.Label lblTransaccion;
        private System.Windows.Forms.TextBox txtTarjeta;
        private System.Windows.Forms.TextBox txtCheque;
        private System.Windows.Forms.Label lblCaja;
        private System.Windows.Forms.Label lblNoCaja;
        private System.Windows.Forms.Label lblNoTurno;
        private System.Windows.Forms.Label lblTurno;

    }
}