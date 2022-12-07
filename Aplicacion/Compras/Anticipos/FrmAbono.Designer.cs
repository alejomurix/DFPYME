namespace Aplicacion.Compras.Anticipos
{
    partial class FrmAbono
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAbono));
            this.gbFormaPago = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtAbono = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtTransaccion = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCheque = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEfectivo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbFormaPago.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbFormaPago
            // 
            this.gbFormaPago.Controls.Add(this.label13);
            this.gbFormaPago.Controls.Add(this.txtAbono);
            this.gbFormaPago.Controls.Add(this.label14);
            this.gbFormaPago.Controls.Add(this.txtTransaccion);
            this.gbFormaPago.Controls.Add(this.label10);
            this.gbFormaPago.Controls.Add(this.label9);
            this.gbFormaPago.Controls.Add(this.label8);
            this.gbFormaPago.Controls.Add(this.label6);
            this.gbFormaPago.Controls.Add(this.label4);
            this.gbFormaPago.Controls.Add(this.txtCheque);
            this.gbFormaPago.Controls.Add(this.label3);
            this.gbFormaPago.Controls.Add(this.txtEfectivo);
            this.gbFormaPago.Controls.Add(this.label2);
            this.gbFormaPago.Controls.Add(this.txtTotal);
            this.gbFormaPago.Controls.Add(this.label1);
            this.gbFormaPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.gbFormaPago.Location = new System.Drawing.Point(12, 7);
            this.gbFormaPago.Name = "gbFormaPago";
            this.gbFormaPago.Size = new System.Drawing.Size(442, 284);
            this.gbFormaPago.TabIndex = 0;
            this.gbFormaPago.TabStop = false;
            this.gbFormaPago.Text = "Forma de Pago";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label13.Location = new System.Drawing.Point(180, 79);
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
            this.label10.Location = new System.Drawing.Point(180, 236);
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
            this.label9.Location = new System.Drawing.Point(180, 189);
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
            this.label8.Location = new System.Drawing.Point(180, 141);
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
            this.label6.Location = new System.Drawing.Point(179, 26);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 31);
            this.label6.TabIndex = 6;
            this.label6.Text = "$";
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
            // FrmAbono
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(467, 303);
            this.Controls.Add(this.gbFormaPago);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAbono";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Abono a Factura Proveedor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmAbonoCompra_FormClosing);
            this.Load += new System.EventHandler(this.FrmAbonoCompra_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmAbonoCompra_KeyDown);
            this.gbFormaPago.ResumeLayout(false);
            this.gbFormaPago.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbFormaPago;
        private System.Windows.Forms.TextBox txtTransaccion;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
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
    }
}