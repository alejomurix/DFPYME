namespace Aplicacion.Administracion.Caja
{
    partial class FrmAperturaCaja
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAperturaCaja));
            this.gbDatosApertura = new System.Windows.Forms.GroupBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.lblTurno = new System.Windows.Forms.Label();
            this.cbTurnos = new System.Windows.Forms.ComboBox();
            this.txtApertura = new System.Windows.Forms.TextBox();
            this.lblApertura = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.txtCaja = new System.Windows.Forms.TextBox();
            this.lblCaja = new System.Windows.Forms.Label();
            this.gbDatosApertura.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbDatosApertura
            // 
            this.gbDatosApertura.Controls.Add(this.lblFecha);
            this.gbDatosApertura.Controls.Add(this.dtpFecha);
            this.gbDatosApertura.Controls.Add(this.lblCaja);
            this.gbDatosApertura.Controls.Add(this.txtCaja);
            this.gbDatosApertura.Controls.Add(this.lblTurno);
            this.gbDatosApertura.Controls.Add(this.cbTurnos);
            this.gbDatosApertura.Controls.Add(this.lblApertura);
            this.gbDatosApertura.Controls.Add(this.txtApertura);
            this.gbDatosApertura.Controls.Add(this.btnGuardar);
            this.gbDatosApertura.Location = new System.Drawing.Point(8, 3);
            this.gbDatosApertura.Name = "gbDatosApertura";
            this.gbDatosApertura.Size = new System.Drawing.Size(359, 229);
            this.gbDatosApertura.TabIndex = 0;
            this.gbDatosApertura.TabStop = false;
            this.gbDatosApertura.Text = "Datos de Apertura";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.Location = new System.Drawing.Point(259, 187);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(83, 25);
            this.btnGuardar.TabIndex = 26;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // lblTurno
            // 
            this.lblTurno.AutoSize = true;
            this.lblTurno.Location = new System.Drawing.Point(18, 112);
            this.lblTurno.Name = "lblTurno";
            this.lblTurno.Size = new System.Drawing.Size(43, 16);
            this.lblTurno.TabIndex = 25;
            this.lblTurno.Text = "Turno";
            // 
            // cbTurnos
            // 
            this.cbTurnos.DisplayMember = "numero";
            this.cbTurnos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTurnos.FormattingEnabled = true;
            this.cbTurnos.Location = new System.Drawing.Point(83, 107);
            this.cbTurnos.Name = "cbTurnos";
            this.cbTurnos.Size = new System.Drawing.Size(66, 24);
            this.cbTurnos.TabIndex = 24;
            this.cbTurnos.ValueMember = "id";
            // 
            // txtApertura
            // 
            this.txtApertura.Location = new System.Drawing.Point(83, 146);
            this.txtApertura.Name = "txtApertura";
            this.txtApertura.Size = new System.Drawing.Size(259, 22);
            this.txtApertura.TabIndex = 1;
            this.txtApertura.Text = "0";
            this.txtApertura.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtApertura_KeyPress);
            this.txtApertura.Validating += new System.ComponentModel.CancelEventHandler(this.txtApertura_Validating);
            // 
            // lblApertura
            // 
            this.lblApertura.AutoSize = true;
            this.lblApertura.Location = new System.Drawing.Point(18, 149);
            this.lblApertura.Name = "lblApertura";
            this.lblApertura.Size = new System.Drawing.Size(59, 16);
            this.lblApertura.TabIndex = 4;
            this.lblApertura.Text = "Apertura";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(17, 33);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(46, 16);
            this.lblFecha.TabIndex = 3;
            this.lblFecha.Text = "Fecha";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Enabled = false;
            this.dtpFecha.Location = new System.Drawing.Point(83, 30);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(259, 22);
            this.dtpFecha.TabIndex = 2;
            // 
            // txtCaja
            // 
            this.txtCaja.Location = new System.Drawing.Point(83, 68);
            this.txtCaja.Name = "txtCaja";
            this.txtCaja.ReadOnly = true;
            this.txtCaja.Size = new System.Drawing.Size(66, 22);
            this.txtCaja.TabIndex = 27;
            // 
            // lblCaja
            // 
            this.lblCaja.AutoSize = true;
            this.lblCaja.Location = new System.Drawing.Point(18, 71);
            this.lblCaja.Name = "lblCaja";
            this.lblCaja.Size = new System.Drawing.Size(36, 16);
            this.lblCaja.TabIndex = 28;
            this.lblCaja.Text = "Caja";
            // 
            // FrmAperturaCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(381, 244);
            this.Controls.Add(this.gbDatosApertura);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAperturaCaja";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Apertura de Caja";
            this.Load += new System.EventHandler(this.FrmAperturaCaja_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmAperturaCaja_KeyDown);
            this.gbDatosApertura.ResumeLayout(false);
            this.gbDatosApertura.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDatosApertura;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.TextBox txtApertura;
        private System.Windows.Forms.Label lblApertura;
        private System.Windows.Forms.Label lblTurno;
        private System.Windows.Forms.ComboBox cbTurnos;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TextBox txtCaja;
        private System.Windows.Forms.Label lblCaja;
    }
}