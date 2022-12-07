namespace Aplicacion.Administracion.Caja
{
    partial class FrmEditarCierreCaja
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEditarCierreCaja));
            this.gbDatosCierre = new System.Windows.Forms.GroupBox();
            this.lblEfectivo = new System.Windows.Forms.Label();
            this.txtEfectivo = new System.Windows.Forms.TextBox();
            this.lblCheque = new System.Windows.Forms.Label();
            this.txtCheque = new System.Windows.Forms.TextBox();
            this.lblTarjeta = new System.Windows.Forms.Label();
            this.txtTarjeta = new System.Windows.Forms.TextBox();
            this.lblTransaccion = new System.Windows.Forms.Label();
            this.txtTransaccion = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.gbDatosCierre.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbDatosCierre
            // 
            this.gbDatosCierre.Controls.Add(this.lblEfectivo);
            this.gbDatosCierre.Controls.Add(this.txtEfectivo);
            this.gbDatosCierre.Controls.Add(this.lblCheque);
            this.gbDatosCierre.Controls.Add(this.txtCheque);
            this.gbDatosCierre.Controls.Add(this.lblTarjeta);
            this.gbDatosCierre.Controls.Add(this.txtTarjeta);
            this.gbDatosCierre.Controls.Add(this.lblTransaccion);
            this.gbDatosCierre.Controls.Add(this.txtTransaccion);
            this.gbDatosCierre.Controls.Add(this.btnGuardar);
            this.gbDatosCierre.Location = new System.Drawing.Point(10, 3);
            this.gbDatosCierre.Name = "gbDatosCierre";
            this.gbDatosCierre.Size = new System.Drawing.Size(357, 177);
            this.gbDatosCierre.TabIndex = 1;
            this.gbDatosCierre.TabStop = false;
            // 
            // lblEfectivo
            // 
            this.lblEfectivo.AutoSize = true;
            this.lblEfectivo.Location = new System.Drawing.Point(15, 19);
            this.lblEfectivo.Name = "lblEfectivo";
            this.lblEfectivo.Size = new System.Drawing.Size(56, 16);
            this.lblEfectivo.TabIndex = 4;
            this.lblEfectivo.Text = "Efectivo";
            // 
            // txtEfectivo
            // 
            this.txtEfectivo.Location = new System.Drawing.Point(103, 16);
            this.txtEfectivo.Name = "txtEfectivo";
            this.txtEfectivo.Size = new System.Drawing.Size(236, 22);
            this.txtEfectivo.TabIndex = 1;
            this.txtEfectivo.Text = "0";
            this.txtEfectivo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEfectivo_KeyPress);
            this.txtEfectivo.Validating += new System.ComponentModel.CancelEventHandler(this.txtEfectivo_Validating);
            // 
            // lblCheque
            // 
            this.lblCheque.AutoSize = true;
            this.lblCheque.Location = new System.Drawing.Point(15, 50);
            this.lblCheque.Name = "lblCheque";
            this.lblCheque.Size = new System.Drawing.Size(55, 16);
            this.lblCheque.TabIndex = 29;
            this.lblCheque.Text = "Cheque";
            // 
            // txtCheque
            // 
            this.txtCheque.Location = new System.Drawing.Point(103, 47);
            this.txtCheque.Name = "txtCheque";
            this.txtCheque.Size = new System.Drawing.Size(236, 22);
            this.txtCheque.TabIndex = 28;
            this.txtCheque.Text = "0";
            this.txtCheque.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCheque_KeyPress);
            this.txtCheque.Validating += new System.ComponentModel.CancelEventHandler(this.txtCheque_Validating);
            // 
            // lblTarjeta
            // 
            this.lblTarjeta.AutoSize = true;
            this.lblTarjeta.Location = new System.Drawing.Point(14, 81);
            this.lblTarjeta.Name = "lblTarjeta";
            this.lblTarjeta.Size = new System.Drawing.Size(51, 16);
            this.lblTarjeta.TabIndex = 31;
            this.lblTarjeta.Text = "Tarjeta";
            // 
            // txtTarjeta
            // 
            this.txtTarjeta.Location = new System.Drawing.Point(103, 78);
            this.txtTarjeta.Name = "txtTarjeta";
            this.txtTarjeta.Size = new System.Drawing.Size(235, 22);
            this.txtTarjeta.TabIndex = 30;
            this.txtTarjeta.Text = "0";
            this.txtTarjeta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTarjeta_KeyPress);
            this.txtTarjeta.Validating += new System.ComponentModel.CancelEventHandler(this.txtTarjeta_Validating);
            // 
            // lblTransaccion
            // 
            this.lblTransaccion.AutoSize = true;
            this.lblTransaccion.Location = new System.Drawing.Point(14, 115);
            this.lblTransaccion.Name = "lblTransaccion";
            this.lblTransaccion.Size = new System.Drawing.Size(83, 16);
            this.lblTransaccion.TabIndex = 33;
            this.lblTransaccion.Text = "Transacción";
            // 
            // txtTransaccion
            // 
            this.txtTransaccion.Location = new System.Drawing.Point(103, 112);
            this.txtTransaccion.Name = "txtTransaccion";
            this.txtTransaccion.Size = new System.Drawing.Size(235, 22);
            this.txtTransaccion.TabIndex = 32;
            this.txtTransaccion.Text = "0";
            this.txtTransaccion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTransaccion_KeyPress);
            this.txtTransaccion.Validating += new System.ComponentModel.CancelEventHandler(this.txtTransaccion_Validating);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.Location = new System.Drawing.Point(255, 140);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(83, 25);
            this.btnGuardar.TabIndex = 27;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // FrmEditarCierreCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(381, 188);
            this.Controls.Add(this.gbDatosCierre);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmEditarCierreCaja";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editar cierre de caja";
            this.Load += new System.EventHandler(this.FrCierreCaja_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrCierreCaja_KeyDown);
            this.gbDatosCierre.ResumeLayout(false);
            this.gbDatosCierre.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDatosCierre;
        private System.Windows.Forms.Label lblEfectivo;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label lblTransaccion;
        private System.Windows.Forms.Label lblTarjeta;
        private System.Windows.Forms.Label lblCheque;
        public System.Windows.Forms.TextBox txtEfectivo;
        public System.Windows.Forms.TextBox txtTransaccion;
        public System.Windows.Forms.TextBox txtTarjeta;
        public System.Windows.Forms.TextBox txtCheque;

    }
}