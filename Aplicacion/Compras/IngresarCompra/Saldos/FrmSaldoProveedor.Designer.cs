namespace Aplicacion.Compras.IngresarCompra.Saldos
{
    partial class FrmSaldoProveedor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSaldoProveedor));
            this.gbSaldoProveedor = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSaldo = new System.Windows.Forms.TextBox();
            this.txtNit = new System.Windows.Forms.TextBox();
            this.txtProveedor = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gbSaldoProveedor.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbSaldoProveedor
            // 
            this.gbSaldoProveedor.Controls.Add(this.label4);
            this.gbSaldoProveedor.Controls.Add(this.txtSaldo);
            this.gbSaldoProveedor.Controls.Add(this.txtNit);
            this.gbSaldoProveedor.Controls.Add(this.txtProveedor);
            this.gbSaldoProveedor.Controls.Add(this.label3);
            this.gbSaldoProveedor.Controls.Add(this.label2);
            this.gbSaldoProveedor.Controls.Add(this.label1);
            this.gbSaldoProveedor.Location = new System.Drawing.Point(12, 12);
            this.gbSaldoProveedor.Name = "gbSaldoProveedor";
            this.gbSaldoProveedor.Size = new System.Drawing.Size(452, 168);
            this.gbSaldoProveedor.TabIndex = 1;
            this.gbSaldoProveedor.TabStop = false;
            this.gbSaldoProveedor.Text = "Saldo Proveedor";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.Location = new System.Drawing.Point(79, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "$";
            // 
            // txtSaldo
            // 
            this.txtSaldo.Enabled = false;
            this.txtSaldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtSaldo.Location = new System.Drawing.Point(100, 116);
            this.txtSaldo.Name = "txtSaldo";
            this.txtSaldo.Size = new System.Drawing.Size(340, 26);
            this.txtSaldo.TabIndex = 5;
            // 
            // txtNit
            // 
            this.txtNit.Enabled = false;
            this.txtNit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtNit.Location = new System.Drawing.Point(100, 74);
            this.txtNit.Name = "txtNit";
            this.txtNit.Size = new System.Drawing.Size(340, 26);
            this.txtNit.TabIndex = 4;
            // 
            // txtProveedor
            // 
            this.txtProveedor.Enabled = false;
            this.txtProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtProveedor.Location = new System.Drawing.Point(100, 31);
            this.txtProveedor.Name = "txtProveedor";
            this.txtProveedor.Size = new System.Drawing.Size(340, 26);
            this.txtProveedor.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(8, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Saldo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(8, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "NIT O C.C.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(7, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Proveedor";
            // 
            // FrmSaldoProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(480, 192);
            this.Controls.Add(this.gbSaldoProveedor);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSaldoProveedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Saldo";
            this.Load += new System.EventHandler(this.FrmSaldoProveedor_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmSaldoProveedor_KeyDown);
            this.gbSaldoProveedor.ResumeLayout(false);
            this.gbSaldoProveedor.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSaldoProveedor;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txtSaldo;
        public System.Windows.Forms.TextBox txtNit;
        public System.Windows.Forms.TextBox txtProveedor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}