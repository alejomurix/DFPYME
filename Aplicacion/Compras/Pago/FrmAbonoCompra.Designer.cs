namespace Aplicacion.Compras.Pago
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
            this.label17 = new System.Windows.Forms.Label();
            this.txtDescuento = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtDevolucion = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAnticipo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtAbono = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtTransaccion = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTarjeta = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCheque = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEfectivo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbSaldo = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtSaldoDevolucion = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.lblPesosAnticipo = new System.Windows.Forms.Label();
            this.txtAnticipos = new System.Windows.Forms.TextBox();
            this.lblAdelantos = new System.Windows.Forms.Label();
            this.gbFormaPago.SuspendLayout();
            this.gbSaldo.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbFormaPago
            // 
            this.gbFormaPago.Controls.Add(this.label17);
            this.gbFormaPago.Controls.Add(this.txtDescuento);
            this.gbFormaPago.Controls.Add(this.label18);
            this.gbFormaPago.Controls.Add(this.label15);
            this.gbFormaPago.Controls.Add(this.txtDevolucion);
            this.gbFormaPago.Controls.Add(this.label16);
            this.gbFormaPago.Controls.Add(this.label5);
            this.gbFormaPago.Controls.Add(this.txtAnticipo);
            this.gbFormaPago.Controls.Add(this.label7);
            this.gbFormaPago.Controls.Add(this.label13);
            this.gbFormaPago.Controls.Add(this.txtAbono);
            this.gbFormaPago.Controls.Add(this.label14);
            this.gbFormaPago.Controls.Add(this.txtTransaccion);
            this.gbFormaPago.Controls.Add(this.label10);
            this.gbFormaPago.Controls.Add(this.label9);
            this.gbFormaPago.Controls.Add(this.label8);
            this.gbFormaPago.Controls.Add(this.label6);
            this.gbFormaPago.Controls.Add(this.txtTarjeta);
            this.gbFormaPago.Controls.Add(this.label4);
            this.gbFormaPago.Controls.Add(this.txtCheque);
            this.gbFormaPago.Controls.Add(this.label3);
            this.gbFormaPago.Controls.Add(this.txtEfectivo);
            this.gbFormaPago.Controls.Add(this.label2);
            this.gbFormaPago.Controls.Add(this.txtTotal);
            this.gbFormaPago.Controls.Add(this.label1);
            this.gbFormaPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.gbFormaPago.Location = new System.Drawing.Point(11, 121);
            this.gbFormaPago.Name = "gbFormaPago";
            this.gbFormaPago.Size = new System.Drawing.Size(442, 411);
            this.gbFormaPago.TabIndex = 0;
            this.gbFormaPago.TabStop = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label17.Location = new System.Drawing.Point(187, 368);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(23, 25);
            this.label17.TabIndex = 29;
            this.label17.Text = "$";
            // 
            // txtDescuento
            // 
            this.txtDescuento.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.txtDescuento.Location = new System.Drawing.Point(216, 365);
            this.txtDescuento.Name = "txtDescuento";
            this.txtDescuento.Size = new System.Drawing.Size(208, 30);
            this.txtDescuento.TabIndex = 27;
            this.txtDescuento.Text = "0";
            this.txtDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDescuento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescuento_KeyPress);
            this.txtDescuento.Validating += new System.ComponentModel.CancelEventHandler(this.txtDescuento_Validating);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label18.Location = new System.Drawing.Point(9, 368);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(158, 25);
            this.label18.TabIndex = 28;
            this.label18.Text = "DESCUENTOS:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label15.Location = new System.Drawing.Point(188, 325);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(23, 25);
            this.label15.TabIndex = 26;
            this.label15.Text = "$";
            // 
            // txtDevolucion
            // 
            this.txtDevolucion.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.txtDevolucion.Location = new System.Drawing.Point(217, 322);
            this.txtDevolucion.Name = "txtDevolucion";
            this.txtDevolucion.Size = new System.Drawing.Size(208, 30);
            this.txtDevolucion.TabIndex = 24;
            this.txtDevolucion.Text = "0";
            this.txtDevolucion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDevolucion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDevolucion_KeyPress);
            this.txtDevolucion.Validating += new System.ComponentModel.CancelEventHandler(this.txtDevolucion_Validating);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label16.Location = new System.Drawing.Point(10, 325);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(150, 25);
            this.label16.TabIndex = 25;
            this.label16.Text = "DEVOLUCIÓN:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label5.Location = new System.Drawing.Point(188, 281);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 25);
            this.label5.TabIndex = 23;
            this.label5.Text = "$";
            // 
            // txtAnticipo
            // 
            this.txtAnticipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.txtAnticipo.Location = new System.Drawing.Point(217, 278);
            this.txtAnticipo.Name = "txtAnticipo";
            this.txtAnticipo.Size = new System.Drawing.Size(208, 30);
            this.txtAnticipo.TabIndex = 21;
            this.txtAnticipo.Text = "0";
            this.txtAnticipo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAnticipo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAnticipo_KeyPress);
            this.txtAnticipo.Validating += new System.ComponentModel.CancelEventHandler(this.txtAnticipo_Validating);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label7.Location = new System.Drawing.Point(10, 281);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 25);
            this.label7.TabIndex = 22;
            this.label7.Text = "ANTICIPO:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label13.Location = new System.Drawing.Point(183, 79);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 31);
            this.label13.TabIndex = 20;
            this.label13.Text = "$";
            // 
            // txtAbono
            // 
            this.txtAbono.BackColor = System.Drawing.Color.PaleTurquoise;
            this.txtAbono.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.txtAbono.Location = new System.Drawing.Point(218, 76);
            this.txtAbono.Name = "txtAbono";
            this.txtAbono.Size = new System.Drawing.Size(209, 38);
            this.txtAbono.TabIndex = 0;
            this.txtAbono.Text = "0";
            this.txtAbono.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAbono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAbono_KeyPress);
            this.txtAbono.Validating += new System.ComponentModel.CancelEventHandler(this.txtAbono_Validating);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label14.Location = new System.Drawing.Point(8, 79);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(134, 31);
            this.label14.TabIndex = 19;
            this.label14.Text = "ABONO : ";
            // 
            // txtTransaccion
            // 
            this.txtTransaccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.txtTransaccion.Location = new System.Drawing.Point(217, 234);
            this.txtTransaccion.Name = "txtTransaccion";
            this.txtTransaccion.Size = new System.Drawing.Size(208, 30);
            this.txtTransaccion.TabIndex = 4;
            this.txtTransaccion.Text = "0";
            this.txtTransaccion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTransaccion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTransaccion_KeyPress);
            this.txtTransaccion.Validating += new System.ComponentModel.CancelEventHandler(this.txtTransaccion_Validating);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label10.Location = new System.Drawing.Point(188, 236);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(23, 25);
            this.label10.TabIndex = 12;
            this.label10.Text = "$";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label9.Location = new System.Drawing.Point(188, 189);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(23, 25);
            this.label9.TabIndex = 11;
            this.label9.Text = "$";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label8.Location = new System.Drawing.Point(187, 141);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(23, 25);
            this.label8.TabIndex = 8;
            this.label8.Text = "$";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label6.Location = new System.Drawing.Point(182, 26);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 31);
            this.label6.TabIndex = 6;
            this.label6.Text = "$";
            // 
            // txtTarjeta
            // 
            this.txtTarjeta.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.txtTarjeta.Location = new System.Drawing.Point(145, 29);
            this.txtTarjeta.Name = "txtTarjeta";
            this.txtTarjeta.Size = new System.Drawing.Size(27, 30);
            this.txtTarjeta.TabIndex = 3;
            this.txtTarjeta.Text = "0";
            this.txtTarjeta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTarjeta.Visible = false;
            this.txtTarjeta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTarjeta_KeyPress);
            this.txtTarjeta.Validating += new System.ComponentModel.CancelEventHandler(this.txtTarjeta_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label4.Location = new System.Drawing.Point(9, 236);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(170, 25);
            this.label4.TabIndex = 6;
            this.label4.Text = "TRANSACCIÓN: ";
            // 
            // txtCheque
            // 
            this.txtCheque.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.txtCheque.Location = new System.Drawing.Point(216, 186);
            this.txtCheque.Name = "txtCheque";
            this.txtCheque.Size = new System.Drawing.Size(208, 30);
            this.txtCheque.TabIndex = 2;
            this.txtCheque.Text = "0";
            this.txtCheque.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCheque.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCheque_KeyPress);
            this.txtCheque.Validating += new System.ComponentModel.CancelEventHandler(this.txtCheque_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label3.Location = new System.Drawing.Point(9, 189);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 25);
            this.label3.TabIndex = 9;
            this.label3.Text = "CHEQUE: ";
            // 
            // txtEfectivo
            // 
            this.txtEfectivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.txtEfectivo.Location = new System.Drawing.Point(216, 138);
            this.txtEfectivo.Name = "txtEfectivo";
            this.txtEfectivo.Size = new System.Drawing.Size(208, 30);
            this.txtEfectivo.TabIndex = 1;
            this.txtEfectivo.Text = "0";
            this.txtEfectivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtEfectivo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEfectivo_KeyPress);
            this.txtEfectivo.Validating += new System.ComponentModel.CancelEventHandler(this.txtEfectivo_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label2.Location = new System.Drawing.Point(8, 141);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 25);
            this.label2.TabIndex = 7;
            this.label2.Text = "EFECTIVO: ";
            // 
            // txtTotal
            // 
            this.txtTotal.BackColor = System.Drawing.Color.PaleTurquoise;
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.txtTotal.Location = new System.Drawing.Point(217, 23);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(209, 38);
            this.txtTotal.TabIndex = 4;
            this.txtTotal.Text = "0";
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label1.Location = new System.Drawing.Point(7, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 31);
            this.label1.TabIndex = 5;
            this.label1.Text = "TOTAL : ";
            // 
            // gbSaldo
            // 
            this.gbSaldo.Controls.Add(this.label11);
            this.gbSaldo.Controls.Add(this.txtSaldoDevolucion);
            this.gbSaldo.Controls.Add(this.label12);
            this.gbSaldo.Controls.Add(this.lblPesosAnticipo);
            this.gbSaldo.Controls.Add(this.txtAnticipos);
            this.gbSaldo.Controls.Add(this.lblAdelantos);
            this.gbSaldo.Location = new System.Drawing.Point(11, 12);
            this.gbSaldo.Name = "gbSaldo";
            this.gbSaldo.Size = new System.Drawing.Size(443, 107);
            this.gbSaldo.TabIndex = 4;
            this.gbSaldo.TabStop = false;
            this.gbSaldo.Text = "SALDOS";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label11.Location = new System.Drawing.Point(187, 65);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(23, 25);
            this.label11.TabIndex = 14;
            this.label11.Text = "$";
            // 
            // txtSaldoDevolucion
            // 
            this.txtSaldoDevolucion.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.txtSaldoDevolucion.Location = new System.Drawing.Point(218, 62);
            this.txtSaldoDevolucion.Name = "txtSaldoDevolucion";
            this.txtSaldoDevolucion.ReadOnly = true;
            this.txtSaldoDevolucion.Size = new System.Drawing.Size(208, 30);
            this.txtSaldoDevolucion.TabIndex = 12;
            this.txtSaldoDevolucion.Text = "0";
            this.txtSaldoDevolucion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label12.Location = new System.Drawing.Point(5, 65);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(182, 25);
            this.label12.TabIndex = 13;
            this.label12.Text = "DEVOLUCIONES: ";
            // 
            // lblPesosAnticipo
            // 
            this.lblPesosAnticipo.AutoSize = true;
            this.lblPesosAnticipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblPesosAnticipo.Location = new System.Drawing.Point(187, 24);
            this.lblPesosAnticipo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPesosAnticipo.Name = "lblPesosAnticipo";
            this.lblPesosAnticipo.Size = new System.Drawing.Size(23, 25);
            this.lblPesosAnticipo.TabIndex = 11;
            this.lblPesosAnticipo.Text = "$";
            // 
            // txtAnticipos
            // 
            this.txtAnticipos.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.txtAnticipos.Location = new System.Drawing.Point(218, 21);
            this.txtAnticipos.Name = "txtAnticipos";
            this.txtAnticipos.ReadOnly = true;
            this.txtAnticipos.Size = new System.Drawing.Size(208, 30);
            this.txtAnticipos.TabIndex = 9;
            this.txtAnticipos.Text = "0";
            this.txtAnticipos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblAdelantos
            // 
            this.lblAdelantos.AutoSize = true;
            this.lblAdelantos.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblAdelantos.Location = new System.Drawing.Point(5, 24);
            this.lblAdelantos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAdelantos.Name = "lblAdelantos";
            this.lblAdelantos.Size = new System.Drawing.Size(132, 25);
            this.lblAdelantos.TabIndex = 10;
            this.lblAdelantos.Text = "ANTICIPOS: ";
            // 
            // FrmAbonoCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(467, 543);
            this.Controls.Add(this.gbSaldo);
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
            this.gbSaldo.ResumeLayout(false);
            this.gbSaldo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbFormaPago;
        private System.Windows.Forms.TextBox txtTransaccion;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTarjeta;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCheque;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEfectivo;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtAbono;
        private System.Windows.Forms.GroupBox gbSaldo;
        private System.Windows.Forms.Label lblPesosAnticipo;
        public System.Windows.Forms.TextBox txtAnticipos;
        private System.Windows.Forms.Label lblAdelantos;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAnticipo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label11;
        public System.Windows.Forms.TextBox txtSaldoDevolucion;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtDevolucion;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtDescuento;
        private System.Windows.Forms.Label label18;
    }
}