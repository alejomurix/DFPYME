namespace Aplicacion.Compras.Pago
{
    partial class FrmAbonoGeneralCompra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAbonoGeneralCompra));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAbono = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtProveedor = new System.Windows.Forms.TextBox();
            this.txtNit = new System.Windows.Forms.TextBox();
            this.txtSaldo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.gbSaldoProveedor = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.gbSaldoProveedor.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtAbono);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.groupBox1.Location = new System.Drawing.Point(12, 187);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(512, 79);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F);
            this.label1.Location = new System.Drawing.Point(116, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 29);
            this.label1.TabIndex = 8;
            this.label1.Text = "$";
            // 
            // txtAbono
            // 
            this.txtAbono.BackColor = System.Drawing.Color.PaleTurquoise;
            this.txtAbono.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F);
            this.txtAbono.Location = new System.Drawing.Point(149, 23);
            this.txtAbono.Name = "txtAbono";
            this.txtAbono.Size = new System.Drawing.Size(340, 33);
            this.txtAbono.TabIndex = 0;
            this.txtAbono.Text = "0";
            this.txtAbono.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAbono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAbono_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F);
            this.label6.Location = new System.Drawing.Point(7, 27);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 29);
            this.label6.TabIndex = 7;
            this.label6.Text = "ABONO: ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F);
            this.label7.Location = new System.Drawing.Point(16, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(126, 29);
            this.label7.TabIndex = 0;
            this.label7.Text = "Proveedor";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F);
            this.label5.Location = new System.Drawing.Point(19, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 29);
            this.label5.TabIndex = 1;
            this.label5.Text = "Cedula";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F);
            this.label3.Location = new System.Drawing.Point(19, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 29);
            this.label3.TabIndex = 2;
            this.label3.Text = "Saldo";
            // 
            // txtProveedor
            // 
            this.txtProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F);
            this.txtProveedor.Location = new System.Drawing.Point(149, 28);
            this.txtProveedor.Name = "txtProveedor";
            this.txtProveedor.ReadOnly = true;
            this.txtProveedor.Size = new System.Drawing.Size(340, 33);
            this.txtProveedor.TabIndex = 3;
            // 
            // txtNit
            // 
            this.txtNit.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F);
            this.txtNit.Location = new System.Drawing.Point(149, 71);
            this.txtNit.Name = "txtNit";
            this.txtNit.ReadOnly = true;
            this.txtNit.Size = new System.Drawing.Size(340, 33);
            this.txtNit.TabIndex = 4;
            // 
            // txtSaldo
            // 
            this.txtSaldo.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtSaldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F);
            this.txtSaldo.Location = new System.Drawing.Point(149, 113);
            this.txtSaldo.Name = "txtSaldo";
            this.txtSaldo.ReadOnly = true;
            this.txtSaldo.Size = new System.Drawing.Size(340, 33);
            this.txtSaldo.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F);
            this.label4.Location = new System.Drawing.Point(117, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 29);
            this.label4.TabIndex = 6;
            this.label4.Text = "$";
            // 
            // gbSaldoProveedor
            // 
            this.gbSaldoProveedor.Controls.Add(this.label4);
            this.gbSaldoProveedor.Controls.Add(this.txtSaldo);
            this.gbSaldoProveedor.Controls.Add(this.txtNit);
            this.gbSaldoProveedor.Controls.Add(this.txtProveedor);
            this.gbSaldoProveedor.Controls.Add(this.label3);
            this.gbSaldoProveedor.Controls.Add(this.label5);
            this.gbSaldoProveedor.Controls.Add(this.label7);
            this.gbSaldoProveedor.Location = new System.Drawing.Point(12, 12);
            this.gbSaldoProveedor.Name = "gbSaldoProveedor";
            this.gbSaldoProveedor.Size = new System.Drawing.Size(512, 169);
            this.gbSaldoProveedor.TabIndex = 2;
            this.gbSaldoProveedor.TabStop = false;
            this.gbSaldoProveedor.Text = "Saldo del proveedor";
            // 
            // FrmAbonoGeneralCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(545, 288);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbSaldoProveedor);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAbonoGeneralCompra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cancelar compras de proveedor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmAbonoCompra_FormClosing);
            this.Load += new System.EventHandler(this.FrmAbonoCompra_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmAbonoCompra_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbSaldoProveedor.ResumeLayout(false);
            this.gbSaldoProveedor.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAbono;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtProveedor;
        public System.Windows.Forms.TextBox txtNit;
        public System.Windows.Forms.TextBox txtSaldo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox gbSaldoProveedor;
    }
}