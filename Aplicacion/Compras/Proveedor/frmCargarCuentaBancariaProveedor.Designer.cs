namespace Aplicacion.Compras.Proveedor
{
    partial class frmCargarCuentaBancariaProveedor
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtNombreBancoProveedor = new System.Windows.Forms.TextBox();
            this.txtTitularCuentaProveedor = new System.Windows.Forms.TextBox();
            this.txtNumeroCuentaProveedor = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCargarInformacionBancaria = new System.Windows.Forms.Button();
            this.cbTipoCuenta = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbTipoCuenta);
            this.groupBox1.Controls.Add(this.txtNombreBancoProveedor);
            this.groupBox1.Controls.Add(this.txtTitularCuentaProveedor);
            this.groupBox1.Controls.Add(this.txtNumeroCuentaProveedor);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(27, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(386, 184);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Información de Cuanta Bancaria";
            // 
            // txtNombreBancoProveedor
            // 
            this.txtNombreBancoProveedor.Location = new System.Drawing.Point(159, 143);
            this.txtNombreBancoProveedor.Name = "txtNombreBancoProveedor";
            this.txtNombreBancoProveedor.Size = new System.Drawing.Size(221, 22);
            this.txtNombreBancoProveedor.TabIndex = 7;
            // 
            // txtTitularCuentaProveedor
            // 
            this.txtTitularCuentaProveedor.Location = new System.Drawing.Point(159, 110);
            this.txtTitularCuentaProveedor.Name = "txtTitularCuentaProveedor";
            this.txtTitularCuentaProveedor.Size = new System.Drawing.Size(221, 22);
            this.txtTitularCuentaProveedor.TabIndex = 6;
            // 
            // txtNumeroCuentaProveedor
            // 
            this.txtNumeroCuentaProveedor.Location = new System.Drawing.Point(159, 38);
            this.txtNumeroCuentaProveedor.Name = "txtNumeroCuentaProveedor";
            this.txtNumeroCuentaProveedor.Size = new System.Drawing.Size(221, 22);
            this.txtNumeroCuentaProveedor.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Titular de la Cuenta";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nombre del Banco";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tipo de Cuenta";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Numero de Cuanta";
            // 
            // btnCargarInformacionBancaria
            // 
            this.btnCargarInformacionBancaria.Location = new System.Drawing.Point(167, 212);
            this.btnCargarInformacionBancaria.Name = "btnCargarInformacionBancaria";
            this.btnCargarInformacionBancaria.Size = new System.Drawing.Size(108, 23);
            this.btnCargarInformacionBancaria.TabIndex = 1;
            this.btnCargarInformacionBancaria.Text = "Cargar Información";
            this.btnCargarInformacionBancaria.UseVisualStyleBackColor = true;
            this.btnCargarInformacionBancaria.Click += new System.EventHandler(this.btnCargarInformacionBancaria_Click);
            // 
            // cbTipoCuenta
            // 
            this.cbTipoCuenta.DisplayMember = "DescripcionCuenta";
            this.cbTipoCuenta.FormattingEnabled = true;
            this.cbTipoCuenta.Location = new System.Drawing.Point(159, 73);
            this.cbTipoCuenta.Name = "cbTipoCuenta";
            this.cbTipoCuenta.Size = new System.Drawing.Size(121, 24);
            this.cbTipoCuenta.TabIndex = 8;
            this.cbTipoCuenta.ValueMember = "IdTipoCuenta";
            this.cbTipoCuenta.SelectedIndexChanged += new System.EventHandler(this.cbTipoCuenta_SelectedIndexChanged);
            // 
            // frmCargarCuentaBancariaProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 262);
            this.Controls.Add(this.btnCargarInformacionBancaria);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmCargarCuentaBancariaProveedor";
            this.Text = "Cargar Cuenta Bancaria Proveedor";
            this.Load += new System.EventHandler(this.frmCargarCuentaBancariaProveedor_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtNombreBancoProveedor;
        private System.Windows.Forms.TextBox txtTitularCuentaProveedor;
        private System.Windows.Forms.TextBox txtNumeroCuentaProveedor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCargarInformacionBancaria;
        private System.Windows.Forms.ComboBox cbTipoCuenta;
    }
}