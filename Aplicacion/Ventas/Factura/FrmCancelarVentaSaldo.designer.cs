namespace Aplicacion.Ventas.Factura
{
    partial class FrmCancelarVentaSaldo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCancelarVentaSaldo));
            this.label1 = new System.Windows.Forms.Label();
            this.gbFormaPago = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtBono = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtAdelanto = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCambio = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTarjeta = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCheque = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEfectivo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.gbSaldo = new System.Windows.Forms.GroupBox();
            this.lblPesosBono = new System.Windows.Forms.Label();
            this.txtBonoC = new System.Windows.Forms.TextBox();
            this.lblBonos = new System.Windows.Forms.Label();
            this.lblPesosAdelanto = new System.Windows.Forms.Label();
            this.txtAdelantoC = new System.Windows.Forms.TextBox();
            this.lblAdelantos = new System.Windows.Forms.Label();
            this.gbFormaPago.SuspendLayout();
            this.gbSaldo.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label1.Location = new System.Drawing.Point(16, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 31);
            this.label1.TabIndex = 5;
            this.label1.Text = "TOTAL : ";
            // 
            // gbFormaPago
            // 
            this.gbFormaPago.Controls.Add(this.label11);
            this.gbFormaPago.Controls.Add(this.txtBono);
            this.gbFormaPago.Controls.Add(this.label12);
            this.gbFormaPago.Controls.Add(this.label13);
            this.gbFormaPago.Controls.Add(this.txtAdelanto);
            this.gbFormaPago.Controls.Add(this.label14);
            this.gbFormaPago.Controls.Add(this.label10);
            this.gbFormaPago.Controls.Add(this.label9);
            this.gbFormaPago.Controls.Add(this.label8);
            this.gbFormaPago.Controls.Add(this.label7);
            this.gbFormaPago.Controls.Add(this.label6);
            this.gbFormaPago.Controls.Add(this.txtCambio);
            this.gbFormaPago.Controls.Add(this.label5);
            this.gbFormaPago.Controls.Add(this.txtTarjeta);
            this.gbFormaPago.Controls.Add(this.label4);
            this.gbFormaPago.Controls.Add(this.txtCheque);
            this.gbFormaPago.Controls.Add(this.label3);
            this.gbFormaPago.Controls.Add(this.txtEfectivo);
            this.gbFormaPago.Controls.Add(this.label2);
            this.gbFormaPago.Controls.Add(this.txtTotal);
            this.gbFormaPago.Controls.Add(this.label1);
            this.gbFormaPago.Location = new System.Drawing.Point(12, 113);
            this.gbFormaPago.Name = "gbFormaPago";
            this.gbFormaPago.Size = new System.Drawing.Size(425, 364);
            this.gbFormaPago.TabIndex = 0;
            this.gbFormaPago.TabStop = false;
            this.gbFormaPago.Text = "Forma de Pago";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label11.Location = new System.Drawing.Point(159, 254);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(23, 25);
            this.label11.TabIndex = 20;
            this.label11.Text = "$";
            // 
            // txtBono
            // 
            this.txtBono.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.txtBono.Location = new System.Drawing.Point(190, 251);
            this.txtBono.Name = "txtBono";
            this.txtBono.Size = new System.Drawing.Size(208, 30);
            this.txtBono.TabIndex = 4;
            this.txtBono.Text = "0";
            this.txtBono.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtBono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBono_KeyPress);
            this.txtBono.Validating += new System.ComponentModel.CancelEventHandler(this.txtBono_Validating);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label12.Location = new System.Drawing.Point(17, 254);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(82, 25);
            this.label12.TabIndex = 19;
            this.label12.Text = "BONO: ";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label13.Location = new System.Drawing.Point(160, 212);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(23, 25);
            this.label13.TabIndex = 17;
            this.label13.Text = "$";
            // 
            // txtAdelanto
            // 
            this.txtAdelanto.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.txtAdelanto.Location = new System.Drawing.Point(191, 209);
            this.txtAdelanto.Name = "txtAdelanto";
            this.txtAdelanto.Size = new System.Drawing.Size(208, 30);
            this.txtAdelanto.TabIndex = 3;
            this.txtAdelanto.Text = "0";
            this.txtAdelanto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAdelanto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAdelanto_KeyPress);
            this.txtAdelanto.Validating += new System.ComponentModel.CancelEventHandler(this.txtAdelanto_Validating);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label14.Location = new System.Drawing.Point(18, 212);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(132, 25);
            this.label14.TabIndex = 16;
            this.label14.Text = "ADELANTO: ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label10.Location = new System.Drawing.Point(160, 172);
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
            this.label9.Location = new System.Drawing.Point(160, 130);
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
            this.label8.Location = new System.Drawing.Point(160, 87);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(23, 25);
            this.label8.TabIndex = 8;
            this.label8.Text = "$";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label7.Location = new System.Drawing.Point(155, 310);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 31);
            this.label7.TabIndex = 14;
            this.label7.Text = "$";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label6.Location = new System.Drawing.Point(157, 32);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 31);
            this.label6.TabIndex = 6;
            this.label6.Text = "$";
            // 
            // txtCambio
            // 
            this.txtCambio.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtCambio.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.txtCambio.Location = new System.Drawing.Point(189, 307);
            this.txtCambio.Name = "txtCambio";
            this.txtCambio.ReadOnly = true;
            this.txtCambio.Size = new System.Drawing.Size(210, 38);
            this.txtCambio.TabIndex = 3;
            this.txtCambio.Text = "0";
            this.txtCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label5.Location = new System.Drawing.Point(17, 310);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 31);
            this.label5.TabIndex = 13;
            this.label5.Text = "CAMBIO: ";
            // 
            // txtTarjeta
            // 
            this.txtTarjeta.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.txtTarjeta.Location = new System.Drawing.Point(191, 169);
            this.txtTarjeta.Name = "txtTarjeta";
            this.txtTarjeta.Size = new System.Drawing.Size(208, 30);
            this.txtTarjeta.TabIndex = 2;
            this.txtTarjeta.Text = "0";
            this.txtTarjeta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTarjeta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTarjeta_KeyPress);
            this.txtTarjeta.Validating += new System.ComponentModel.CancelEventHandler(this.txtTarjeta_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label4.Location = new System.Drawing.Point(18, 172);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 25);
            this.label4.TabIndex = 6;
            this.label4.Text = "TARJETA: ";
            // 
            // txtCheque
            // 
            this.txtCheque.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.txtCheque.Location = new System.Drawing.Point(191, 127);
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
            this.label3.Location = new System.Drawing.Point(18, 130);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 25);
            this.label3.TabIndex = 9;
            this.label3.Text = "CHEQUE: ";
            // 
            // txtEfectivo
            // 
            this.txtEfectivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.txtEfectivo.Location = new System.Drawing.Point(191, 84);
            this.txtEfectivo.Name = "txtEfectivo";
            this.txtEfectivo.Size = new System.Drawing.Size(208, 30);
            this.txtEfectivo.TabIndex = 0;
            this.txtEfectivo.Text = "0";
            this.txtEfectivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtEfectivo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEfectivo_KeyPress);
            this.txtEfectivo.Validating += new System.ComponentModel.CancelEventHandler(this.txtEfectivo_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label2.Location = new System.Drawing.Point(18, 87);
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
            this.txtTotal.Location = new System.Drawing.Point(191, 29);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(208, 38);
            this.txtTotal.TabIndex = 4;
            this.txtTotal.Text = "0";
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // gbSaldo
            // 
            this.gbSaldo.Controls.Add(this.lblPesosBono);
            this.gbSaldo.Controls.Add(this.txtBonoC);
            this.gbSaldo.Controls.Add(this.lblBonos);
            this.gbSaldo.Controls.Add(this.lblPesosAdelanto);
            this.gbSaldo.Controls.Add(this.txtAdelantoC);
            this.gbSaldo.Controls.Add(this.lblAdelantos);
            this.gbSaldo.Location = new System.Drawing.Point(12, 4);
            this.gbSaldo.Name = "gbSaldo";
            this.gbSaldo.Size = new System.Drawing.Size(425, 107);
            this.gbSaldo.TabIndex = 2;
            this.gbSaldo.TabStop = false;
            this.gbSaldo.Text = "Saldos del Cliente";
            // 
            // lblPesosBono
            // 
            this.lblPesosBono.AutoSize = true;
            this.lblPesosBono.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblPesosBono.Location = new System.Drawing.Point(159, 66);
            this.lblPesosBono.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPesosBono.Name = "lblPesosBono";
            this.lblPesosBono.Size = new System.Drawing.Size(23, 25);
            this.lblPesosBono.TabIndex = 14;
            this.lblPesosBono.Text = "$";
            // 
            // txtBonoC
            // 
            this.txtBonoC.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.txtBonoC.Location = new System.Drawing.Point(190, 63);
            this.txtBonoC.Name = "txtBonoC";
            this.txtBonoC.ReadOnly = true;
            this.txtBonoC.Size = new System.Drawing.Size(208, 30);
            this.txtBonoC.TabIndex = 12;
            this.txtBonoC.Text = "0";
            this.txtBonoC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblBonos
            // 
            this.lblBonos.AutoSize = true;
            this.lblBonos.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblBonos.Location = new System.Drawing.Point(17, 66);
            this.lblBonos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBonos.Name = "lblBonos";
            this.lblBonos.Size = new System.Drawing.Size(96, 25);
            this.lblBonos.TabIndex = 13;
            this.lblBonos.Text = "BONOS: ";
            // 
            // lblPesosAdelanto
            // 
            this.lblPesosAdelanto.AutoSize = true;
            this.lblPesosAdelanto.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblPesosAdelanto.Location = new System.Drawing.Point(160, 25);
            this.lblPesosAdelanto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPesosAdelanto.Name = "lblPesosAdelanto";
            this.lblPesosAdelanto.Size = new System.Drawing.Size(23, 25);
            this.lblPesosAdelanto.TabIndex = 11;
            this.lblPesosAdelanto.Text = "$";
            // 
            // txtAdelantoC
            // 
            this.txtAdelantoC.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.txtAdelantoC.Location = new System.Drawing.Point(191, 22);
            this.txtAdelantoC.Name = "txtAdelantoC";
            this.txtAdelantoC.ReadOnly = true;
            this.txtAdelantoC.Size = new System.Drawing.Size(208, 30);
            this.txtAdelantoC.TabIndex = 9;
            this.txtAdelantoC.Text = "0";
            this.txtAdelantoC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblAdelantos
            // 
            this.lblAdelantos.AutoSize = true;
            this.lblAdelantos.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblAdelantos.Location = new System.Drawing.Point(18, 25);
            this.lblAdelantos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAdelantos.Name = "lblAdelantos";
            this.lblAdelantos.Size = new System.Drawing.Size(146, 25);
            this.lblAdelantos.TabIndex = 10;
            this.lblAdelantos.Text = "ADELANTOS: ";
            // 
            // FrmCancelarVentaSaldo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(454, 487);
            this.Controls.Add(this.gbSaldo);
            this.Controls.Add(this.gbFormaPago);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCancelarVentaSaldo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cancelar Venta";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmCancelarVenta_FormClosing);
            this.Load += new System.EventHandler(this.FrmCancelarVenta_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmCancelarVenta_KeyDown);
            this.gbFormaPago.ResumeLayout(false);
            this.gbFormaPago.PerformLayout();
            this.gbSaldo.ResumeLayout(false);
            this.gbSaldo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbFormaPago;
        private System.Windows.Forms.TextBox txtEfectivo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTarjeta;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCheque;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCambio;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.GroupBox gbSaldo;
        private System.Windows.Forms.Label lblPesosBono;
        private System.Windows.Forms.Label lblBonos;
        private System.Windows.Forms.Label lblPesosAdelanto;
        private System.Windows.Forms.Label lblAdelantos;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtBono;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtAdelanto;
        private System.Windows.Forms.Label label14;
        public System.Windows.Forms.TextBox txtBonoC;
        public System.Windows.Forms.TextBox txtAdelantoC;
    }
}