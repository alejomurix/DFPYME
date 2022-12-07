namespace Aplicacion.Ventas.Factura
{
    partial class FrmCancelarVenta2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCancelarVenta2));
            this.label1 = new System.Windows.Forms.Label();
            this.gbFormaPago = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCambio = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEfectivo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.txtCheque = new System.Windows.Forms.TextBox();
            this.txtTarjeta = new System.Windows.Forms.TextBox();
            this.gbFormaPago.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.label1.Location = new System.Drawing.Point(11, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 39);
            this.label1.TabIndex = 5;
            this.label1.Text = "TOTAL : ";
            // 
            // gbFormaPago
            // 
            this.gbFormaPago.Controls.Add(this.label8);
            this.gbFormaPago.Controls.Add(this.label7);
            this.gbFormaPago.Controls.Add(this.label6);
            this.gbFormaPago.Controls.Add(this.txtCambio);
            this.gbFormaPago.Controls.Add(this.label5);
            this.gbFormaPago.Controls.Add(this.txtTarjeta);
            this.gbFormaPago.Controls.Add(this.txtCheque);
            this.gbFormaPago.Controls.Add(this.txtEfectivo);
            this.gbFormaPago.Controls.Add(this.label2);
            this.gbFormaPago.Controls.Add(this.txtTotal);
            this.gbFormaPago.Controls.Add(this.label1);
            this.gbFormaPago.Location = new System.Drawing.Point(12, 7);
            this.gbFormaPago.Name = "gbFormaPago";
            this.gbFormaPago.Size = new System.Drawing.Size(441, 200);
            this.gbFormaPago.TabIndex = 1;
            this.gbFormaPago.TabStop = false;
            this.gbFormaPago.Text = "Forma de Pago";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label8.Location = new System.Drawing.Point(179, 82);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 31);
            this.label8.TabIndex = 8;
            this.label8.Text = "$";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.label7.Location = new System.Drawing.Point(176, 137);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 39);
            this.label7.TabIndex = 14;
            this.label7.Text = "$";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.label6.Location = new System.Drawing.Point(177, 25);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 39);
            this.label6.TabIndex = 6;
            this.label6.Text = "$";
            // 
            // txtCambio
            // 
            this.txtCambio.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtCambio.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.txtCambio.Location = new System.Drawing.Point(214, 134);
            this.txtCambio.Name = "txtCambio";
            this.txtCambio.ReadOnly = true;
            this.txtCambio.Size = new System.Drawing.Size(209, 45);
            this.txtCambio.TabIndex = 3;
            this.txtCambio.Text = "0";
            this.txtCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.label5.Location = new System.Drawing.Point(11, 137);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(170, 39);
            this.label5.TabIndex = 13;
            this.label5.Text = "CAMBIO: ";
            // 
            // txtEfectivo
            // 
            this.txtEfectivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.txtEfectivo.Location = new System.Drawing.Point(215, 79);
            this.txtEfectivo.Name = "txtEfectivo";
            this.txtEfectivo.Size = new System.Drawing.Size(208, 38);
            this.txtEfectivo.TabIndex = 0;
            this.txtEfectivo.Text = "0";
            this.txtEfectivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtEfectivo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEfectivo_KeyPress);
            this.txtEfectivo.Validating += new System.ComponentModel.CancelEventHandler(this.txtEfectivo_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label2.Location = new System.Drawing.Point(11, 82);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 31);
            this.label2.TabIndex = 7;
            this.label2.Text = "EFECTIVO: ";
            // 
            // txtTotal
            // 
            this.txtTotal.BackColor = System.Drawing.Color.PaleTurquoise;
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.txtTotal.Location = new System.Drawing.Point(214, 22);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(209, 45);
            this.txtTotal.TabIndex = 4;
            this.txtTotal.Text = "0";
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtCheque
            // 
            this.txtCheque.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCheque.Location = new System.Drawing.Point(424, 42);
            this.txtCheque.Name = "txtCheque";
            this.txtCheque.Size = new System.Drawing.Size(14, 20);
            this.txtCheque.TabIndex = 1;
            this.txtCheque.Text = "0";
            this.txtCheque.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCheque.Visible = false;
            this.txtCheque.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCheque_KeyPress);
            this.txtCheque.Validating += new System.ComponentModel.CancelEventHandler(this.txtCheque_Validating);
            // 
            // txtTarjeta
            // 
            this.txtTarjeta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTarjeta.Location = new System.Drawing.Point(424, 98);
            this.txtTarjeta.Name = "txtTarjeta";
            this.txtTarjeta.Size = new System.Drawing.Size(15, 20);
            this.txtTarjeta.TabIndex = 2;
            this.txtTarjeta.Text = "0";
            this.txtTarjeta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTarjeta.Visible = false;
            this.txtTarjeta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTarjeta_KeyPress);
            this.txtTarjeta.Validating += new System.ComponentModel.CancelEventHandler(this.txtTarjeta_Validating);
            // 
            // FrmCancelarVenta2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(468, 220);
            this.Controls.Add(this.gbFormaPago);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCancelarVenta2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cancelar";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmCancelarVenta_FormClosing);
            this.Load += new System.EventHandler(this.FrmCancelarVenta_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmCancelarVenta_KeyDown);
            this.gbFormaPago.ResumeLayout(false);
            this.gbFormaPago.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbFormaPago;
        private System.Windows.Forms.TextBox txtEfectivo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCambio;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.TextBox txtTarjeta;
        private System.Windows.Forms.TextBox txtCheque;
    }
}