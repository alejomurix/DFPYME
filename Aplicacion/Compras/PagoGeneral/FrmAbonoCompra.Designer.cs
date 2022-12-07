namespace Aplicacion.Compras.PagoGeneral
{
    partial class FrmAbonoCompra
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
            this.gbFormaPago = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtAbono = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gbSaldoProveedor = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtAnticipos = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSaldo = new System.Windows.Forms.TextBox();
            this.txtNit = new System.Windows.Forms.TextBox();
            this.txtProveedor = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtAnticipo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTransaccion = new System.Windows.Forms.TextBox();
            this.txtCheque = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtEfectivo = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.gbFormaPago.SuspendLayout();
            this.gbSaldoProveedor.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbFormaPago
            // 
            this.gbFormaPago.Controls.Add(this.label8);
            this.gbFormaPago.Controls.Add(this.txtAbono);
            this.gbFormaPago.Controls.Add(this.label2);
            this.gbFormaPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.gbFormaPago.Location = new System.Drawing.Point(12, 194);
            this.gbFormaPago.Name = "gbFormaPago";
            this.gbFormaPago.Size = new System.Drawing.Size(452, 58);
            this.gbFormaPago.TabIndex = 0;
            this.gbFormaPago.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label8.Location = new System.Drawing.Point(95, 19);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(23, 25);
            this.label8.TabIndex = 8;
            this.label8.Text = "$";
            // 
            // txtAbono
            // 
            this.txtAbono.BackColor = System.Drawing.Color.PaleTurquoise;
            this.txtAbono.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.txtAbono.Location = new System.Drawing.Point(119, 16);
            this.txtAbono.Name = "txtAbono";
            this.txtAbono.Size = new System.Drawing.Size(321, 30);
            this.txtAbono.TabIndex = 1;
            this.txtAbono.Text = "0";
            this.txtAbono.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAbono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAbono_KeyPress);
            this.txtAbono.Validating += new System.ComponentModel.CancelEventHandler(this.txtAbono_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label2.Location = new System.Drawing.Point(7, 19);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 25);
            this.label2.TabIndex = 7;
            this.label2.Text = "ABONO: ";
            // 
            // gbSaldoProveedor
            // 
            this.gbSaldoProveedor.Controls.Add(this.label12);
            this.gbSaldoProveedor.Controls.Add(this.label4);
            this.gbSaldoProveedor.Controls.Add(this.txtSaldo);
            this.gbSaldoProveedor.Controls.Add(this.txtAnticipos);
            this.gbSaldoProveedor.Controls.Add(this.label13);
            this.gbSaldoProveedor.Controls.Add(this.txtNit);
            this.gbSaldoProveedor.Controls.Add(this.txtProveedor);
            this.gbSaldoProveedor.Controls.Add(this.label3);
            this.gbSaldoProveedor.Controls.Add(this.label5);
            this.gbSaldoProveedor.Controls.Add(this.label7);
            this.gbSaldoProveedor.Location = new System.Drawing.Point(12, 7);
            this.gbSaldoProveedor.Name = "gbSaldoProveedor";
            this.gbSaldoProveedor.Size = new System.Drawing.Size(452, 181);
            this.gbSaldoProveedor.TabIndex = 2;
            this.gbSaldoProveedor.TabStop = false;
            this.gbSaldoProveedor.Text = "Saldo Proveedor";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label12.Location = new System.Drawing.Point(107, 105);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(18, 20);
            this.label12.TabIndex = 9;
            this.label12.Text = "$";
            // 
            // txtAnticipos
            // 
            this.txtAnticipos.Enabled = false;
            this.txtAnticipos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtAnticipos.Location = new System.Drawing.Point(128, 103);
            this.txtAnticipos.Name = "txtAnticipos";
            this.txtAnticipos.Size = new System.Drawing.Size(311, 26);
            this.txtAnticipos.TabIndex = 8;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label13.Location = new System.Drawing.Point(7, 106);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(94, 20);
            this.label13.TabIndex = 7;
            this.label13.Text = "ANTICIPOS";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.Location = new System.Drawing.Point(107, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "$";
            // 
            // txtSaldo
            // 
            this.txtSaldo.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtSaldo.Enabled = false;
            this.txtSaldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtSaldo.Location = new System.Drawing.Point(128, 143);
            this.txtSaldo.Name = "txtSaldo";
            this.txtSaldo.Size = new System.Drawing.Size(311, 26);
            this.txtSaldo.TabIndex = 5;
            // 
            // txtNit
            // 
            this.txtNit.Enabled = false;
            this.txtNit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtNit.Location = new System.Drawing.Point(128, 62);
            this.txtNit.Name = "txtNit";
            this.txtNit.Size = new System.Drawing.Size(311, 26);
            this.txtNit.TabIndex = 4;
            // 
            // txtProveedor
            // 
            this.txtProveedor.Enabled = false;
            this.txtProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtProveedor.Location = new System.Drawing.Point(128, 24);
            this.txtProveedor.Name = "txtProveedor";
            this.txtProveedor.Size = new System.Drawing.Size(311, 26);
            this.txtProveedor.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(8, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "SALDO";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label5.Location = new System.Drawing.Point(8, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "NIT O C.C.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label7.Location = new System.Drawing.Point(7, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 20);
            this.label7.TabIndex = 0;
            this.label7.Text = "Proveedor";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtAnticipo);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtTransaccion);
            this.groupBox1.Controls.Add(this.txtCheque);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtEfectivo);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.groupBox1.Location = new System.Drawing.Point(16, 264);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(448, 154);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Formas de Pago";
            // 
            // txtAnticipo
            // 
            this.txtAnticipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.txtAnticipo.Location = new System.Drawing.Point(216, 112);
            this.txtAnticipo.Name = "txtAnticipo";
            this.txtAnticipo.Size = new System.Drawing.Size(219, 30);
            this.txtAnticipo.TabIndex = 13;
            this.txtAnticipo.Text = "0";
            this.txtAnticipo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAnticipo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAnticipo_KeyPress);
            this.txtAnticipo.Validating += new System.ComponentModel.CancelEventHandler(this.txtAnticipo_Validating);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label6.Location = new System.Drawing.Point(190, 114);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 25);
            this.label6.TabIndex = 15;
            this.label6.Text = "$";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label9.Location = new System.Drawing.Point(8, 114);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(132, 25);
            this.label9.TabIndex = 14;
            this.label9.Text = "ANTICIPOS: ";
            // 
            // txtTransaccion
            // 
            this.txtTransaccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.txtTransaccion.Location = new System.Drawing.Point(216, 69);
            this.txtTransaccion.Name = "txtTransaccion";
            this.txtTransaccion.Size = new System.Drawing.Size(219, 30);
            this.txtTransaccion.TabIndex = 4;
            this.txtTransaccion.Text = "0";
            this.txtTransaccion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTransaccion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTransaccion_KeyPress);
            this.txtTransaccion.Validating += new System.ComponentModel.CancelEventHandler(this.txtTransaccion_Validating);
            // 
            // txtCheque
            // 
            this.txtCheque.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.txtCheque.Location = new System.Drawing.Point(139, 23);
            this.txtCheque.Name = "txtCheque";
            this.txtCheque.Size = new System.Drawing.Size(26, 30);
            this.txtCheque.TabIndex = 12;
            this.txtCheque.Text = "0";
            this.txtCheque.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCheque.Visible = false;
            this.txtCheque.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCheque_KeyPress);
            this.txtCheque.Validating += new System.ComponentModel.CancelEventHandler(this.txtCheque_Validating);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label10.Location = new System.Drawing.Point(190, 71);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(23, 25);
            this.label10.TabIndex = 12;
            this.label10.Text = "$";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label1.Location = new System.Drawing.Point(190, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 25);
            this.label1.TabIndex = 8;
            this.label1.Text = "$";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label11.Location = new System.Drawing.Point(8, 71);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(170, 25);
            this.label11.TabIndex = 6;
            this.label11.Text = "TRANSACCIÓN: ";
            // 
            // txtEfectivo
            // 
            this.txtEfectivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.txtEfectivo.Location = new System.Drawing.Point(216, 23);
            this.txtEfectivo.Name = "txtEfectivo";
            this.txtEfectivo.Size = new System.Drawing.Size(220, 30);
            this.txtEfectivo.TabIndex = 1;
            this.txtEfectivo.Text = "0";
            this.txtEfectivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtEfectivo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEfectivo_KeyPress);
            this.txtEfectivo.Validating += new System.ComponentModel.CancelEventHandler(this.txtEfectivo_Validating);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label15.Location = new System.Drawing.Point(8, 26);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(124, 25);
            this.label15.TabIndex = 7;
            this.label15.Text = "EFECTIVO: ";
            // 
            // FrmAbonoCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(474, 431);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbSaldoProveedor);
            this.Controls.Add(this.gbFormaPago);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAbonoCompra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Abono a factura proveedor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmAbonoCompra_FormClosing);
            this.Load += new System.EventHandler(this.FrmAbonoCompra_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmAbonoCompra_KeyDown);
            this.gbFormaPago.ResumeLayout(false);
            this.gbFormaPago.PerformLayout();
            this.gbSaldoProveedor.ResumeLayout(false);
            this.gbSaldoProveedor.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbFormaPago;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtAbono;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gbSaldoProveedor;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txtSaldo;
        public System.Windows.Forms.TextBox txtNit;
        public System.Windows.Forms.TextBox txtProveedor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtTransaccion;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtEfectivo;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtCheque;
        private System.Windows.Forms.TextBox txtAnticipo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        public System.Windows.Forms.TextBox txtAnticipos;
        private System.Windows.Forms.Label label13;
    }
}