namespace Aplicacion.Configuracion.CuentaBancaria
{
    partial class frmCuentaBancaria
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

        public System.Windows.Forms.TextBox TxtEditarTipoCuenta
        {
            set { this.txtEditarTipoCuenta = value; }
            get { return this.txtEditarTipoCuenta; }
        }


        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCuentaBancaria));
            this.gbDatosCuenta = new System.Windows.Forms.GroupBox();
            this.btnEditarTipoCuenta = new System.Windows.Forms.Button();
            this.txtEditarTipoCuenta = new System.Windows.Forms.TextBox();
            this.lblTipoCuenta = new System.Windows.Forms.Label();
            this.cbTipoCuenta = new System.Windows.Forms.ComboBox();
            this.lblNumeroCuenta = new System.Windows.Forms.Label();
            this.txtNumeroCuenta = new System.Windows.Forms.TextBox();
            this.lblTitularCuenta = new System.Windows.Forms.Label();
            this.txtTitularCuenta = new System.Windows.Forms.TextBox();
            this.lblBanco = new System.Windows.Forms.Label();
            this.txtBanco = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.gbDatosCuenta.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbDatosCuenta
            // 
            this.gbDatosCuenta.Controls.Add(this.btnEditarTipoCuenta);
            this.gbDatosCuenta.Controls.Add(this.txtEditarTipoCuenta);
            this.gbDatosCuenta.Controls.Add(this.lblTipoCuenta);
            this.gbDatosCuenta.Controls.Add(this.cbTipoCuenta);
            this.gbDatosCuenta.Controls.Add(this.lblNumeroCuenta);
            this.gbDatosCuenta.Controls.Add(this.txtNumeroCuenta);
            this.gbDatosCuenta.Controls.Add(this.lblTitularCuenta);
            this.gbDatosCuenta.Controls.Add(this.txtTitularCuenta);
            this.gbDatosCuenta.Controls.Add(this.lblBanco);
            this.gbDatosCuenta.Controls.Add(this.txtBanco);
            this.gbDatosCuenta.Controls.Add(this.btnAceptar);
            this.gbDatosCuenta.Controls.Add(this.btnCancelar);
            this.gbDatosCuenta.Location = new System.Drawing.Point(12, 12);
            this.gbDatosCuenta.Name = "gbDatosCuenta";
            this.gbDatosCuenta.Size = new System.Drawing.Size(366, 259);
            this.gbDatosCuenta.TabIndex = 0;
            this.gbDatosCuenta.TabStop = false;
            this.gbDatosCuenta.Text = "Datos de Cuenta Bancaria";
            // 
            // btnEditarTipoCuenta
            // 
            this.btnEditarTipoCuenta.Image = ((System.Drawing.Image)(resources.GetObject("btnEditarTipoCuenta.Image")));
            this.btnEditarTipoCuenta.Location = new System.Drawing.Point(257, 30);
            this.btnEditarTipoCuenta.Name = "btnEditarTipoCuenta";
            this.btnEditarTipoCuenta.Size = new System.Drawing.Size(31, 23);
            this.btnEditarTipoCuenta.TabIndex = 8;
            this.btnEditarTipoCuenta.UseVisualStyleBackColor = true;
            this.btnEditarTipoCuenta.Visible = false;
            this.btnEditarTipoCuenta.Click += new System.EventHandler(this.btnEditarTipoCuenta_Click);
            // 
            // txtEditarTipoCuenta
            // 
            this.txtEditarTipoCuenta.Enabled = false;
            this.txtEditarTipoCuenta.Location = new System.Drawing.Point(167, 31);
            this.txtEditarTipoCuenta.Name = "txtEditarTipoCuenta";
            this.txtEditarTipoCuenta.Size = new System.Drawing.Size(84, 20);
            this.txtEditarTipoCuenta.TabIndex = 7;
            this.txtEditarTipoCuenta.Visible = false;
            // 
            // lblTipoCuenta
            // 
            this.lblTipoCuenta.AutoSize = true;
            this.lblTipoCuenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblTipoCuenta.Location = new System.Drawing.Point(22, 33);
            this.lblTipoCuenta.Name = "lblTipoCuenta";
            this.lblTipoCuenta.Size = new System.Drawing.Size(81, 16);
            this.lblTipoCuenta.TabIndex = 0;
            this.lblTipoCuenta.Text = "Tipo Cuenta";
            // 
            // cbTipoCuenta
            // 
            this.cbTipoCuenta.DisplayMember = "descripciontipo_cuenta";
            this.cbTipoCuenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoCuenta.FormattingEnabled = true;
            this.cbTipoCuenta.Location = new System.Drawing.Point(167, 31);
            this.cbTipoCuenta.Name = "cbTipoCuenta";
            this.cbTipoCuenta.Size = new System.Drawing.Size(121, 21);
            this.cbTipoCuenta.TabIndex = 5;
            this.cbTipoCuenta.ValueMember = "idtipo_cuenta";
            // 
            // lblNumeroCuenta
            // 
            this.lblNumeroCuenta.AutoSize = true;
            this.lblNumeroCuenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblNumeroCuenta.Location = new System.Drawing.Point(22, 74);
            this.lblNumeroCuenta.Name = "lblNumeroCuenta";
            this.lblNumeroCuenta.Size = new System.Drawing.Size(120, 16);
            this.lblNumeroCuenta.TabIndex = 2;
            this.lblNumeroCuenta.Text = "Numero de Cuenta";
            // 
            // txtNumeroCuenta
            // 
            this.txtNumeroCuenta.Location = new System.Drawing.Point(166, 74);
            this.txtNumeroCuenta.MaxLength = 15;
            this.txtNumeroCuenta.Name = "txtNumeroCuenta";
            this.txtNumeroCuenta.Size = new System.Drawing.Size(145, 20);
            this.txtNumeroCuenta.TabIndex = 0;
            this.txtNumeroCuenta.Validating += new System.ComponentModel.CancelEventHandler(this.txtNumeroCuenta_Validating);
            // 
            // lblTitularCuenta
            // 
            this.lblTitularCuenta.AutoSize = true;
            this.lblTitularCuenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblTitularCuenta.Location = new System.Drawing.Point(22, 118);
            this.lblTitularCuenta.Name = "lblTitularCuenta";
            this.lblTitularCuenta.Size = new System.Drawing.Size(123, 16);
            this.lblTitularCuenta.TabIndex = 4;
            this.lblTitularCuenta.Text = "Titular de la Cuenta";
            // 
            // txtTitularCuenta
            // 
            this.txtTitularCuenta.Location = new System.Drawing.Point(166, 114);
            this.txtTitularCuenta.MaxLength = 80;
            this.txtTitularCuenta.Name = "txtTitularCuenta";
            this.txtTitularCuenta.Size = new System.Drawing.Size(185, 20);
            this.txtTitularCuenta.TabIndex = 1;
            this.txtTitularCuenta.Validating += new System.ComponentModel.CancelEventHandler(this.txtTitularCuenta_Validating);
            // 
            // lblBanco
            // 
            this.lblBanco.AutoSize = true;
            this.lblBanco.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblBanco.Location = new System.Drawing.Point(22, 162);
            this.lblBanco.Name = "lblBanco";
            this.lblBanco.Size = new System.Drawing.Size(111, 16);
            this.lblBanco.TabIndex = 6;
            this.lblBanco.Text = "Entidad Bancaria";
            // 
            // txtBanco
            // 
            this.txtBanco.Location = new System.Drawing.Point(166, 158);
            this.txtBanco.MaxLength = 50;
            this.txtBanco.Name = "txtBanco";
            this.txtBanco.Size = new System.Drawing.Size(185, 20);
            this.txtBanco.TabIndex = 2;
            this.txtBanco.Validating += new System.ComponentModel.CancelEventHandler(this.txtBanco_Validating);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(70, 210);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 3;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(213, 210);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmCuentaBancaria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(397, 290);
            this.Controls.Add(this.gbDatosCuenta);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "frmCuentaBancaria";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cuenta Bancaria";
            this.Load += new System.EventHandler(this.frmCuentaBancaria_Load);
            this.gbDatosCuenta.ResumeLayout(false);
            this.gbDatosCuenta.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDatosCuenta;
        private System.Windows.Forms.Label lblTipoCuenta;
        private System.Windows.Forms.ComboBox cbTipoCuenta;
        private System.Windows.Forms.Label lblNumeroCuenta;
        private System.Windows.Forms.Label lblTitularCuenta;
        private System.Windows.Forms.Label lblBanco;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.TextBox txtEditarTipoCuenta;
        public System.Windows.Forms.Button btnEditarTipoCuenta;
        public System.Windows.Forms.TextBox txtNumeroCuenta;
        public System.Windows.Forms.TextBox txtTitularCuenta;
        public System.Windows.Forms.TextBox txtBanco;
    }
}