namespace Aplicacion.Ventas.Factura
{
    partial class FrmDinamicCancelar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDinamicCancelar));
            this.label1 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.gbFormaPago = new System.Windows.Forms.GroupBox();
            this.PanelCambio = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCambio = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panelTotal = new System.Windows.Forms.Panel();
            this.gbFormaPago.SuspendLayout();
            this.PanelCambio.SuspendLayout();
            this.panelTotal.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label1.Location = new System.Drawing.Point(7, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 31);
            this.label1.TabIndex = 5;
            this.label1.Text = "TOTAL : ";
            // 
            // txtTotal
            // 
            this.txtTotal.BackColor = System.Drawing.SystemColors.Window;
            this.txtTotal.Enabled = false;
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.txtTotal.Location = new System.Drawing.Point(184, 6);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(208, 38);
            this.txtTotal.TabIndex = 0;
            this.txtTotal.Text = "0";
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label6.Location = new System.Drawing.Point(147, 9);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 31);
            this.label6.TabIndex = 6;
            this.label6.Text = "$";
            // 
            // gbFormaPago
            // 
            this.gbFormaPago.Controls.Add(this.PanelCambio);
            this.gbFormaPago.Controls.Add(this.panelTotal);
            this.gbFormaPago.Location = new System.Drawing.Point(12, 4);
            this.gbFormaPago.Name = "gbFormaPago";
            this.gbFormaPago.Size = new System.Drawing.Size(430, 364);
            this.gbFormaPago.TabIndex = 0;
            this.gbFormaPago.TabStop = false;
            this.gbFormaPago.Text = "Forma de Pago";
            // 
            // PanelCambio
            // 
            this.PanelCambio.BackColor = System.Drawing.Color.LightSteelBlue;
            this.PanelCambio.Controls.Add(this.label7);
            this.PanelCambio.Controls.Add(this.txtCambio);
            this.PanelCambio.Controls.Add(this.label5);
            this.PanelCambio.Location = new System.Drawing.Point(9, 69);
            this.PanelCambio.Name = "PanelCambio";
            this.PanelCambio.Size = new System.Drawing.Size(402, 48);
            this.PanelCambio.TabIndex = 23;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label7.Location = new System.Drawing.Point(147, 8);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 31);
            this.label7.TabIndex = 17;
            this.label7.Text = "$";
            // 
            // txtCambio
            // 
            this.txtCambio.BackColor = System.Drawing.SystemColors.Window;
            this.txtCambio.Enabled = false;
            this.txtCambio.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.txtCambio.Location = new System.Drawing.Point(184, 5);
            this.txtCambio.Name = "txtCambio";
            this.txtCambio.ReadOnly = true;
            this.txtCambio.Size = new System.Drawing.Size(208, 38);
            this.txtCambio.TabIndex = 0;
            this.txtCambio.Text = "0";
            this.txtCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label5.Location = new System.Drawing.Point(5, 8);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(143, 31);
            this.label5.TabIndex = 16;
            this.label5.Text = "CAMBIO : ";
            // 
            // panelTotal
            // 
            this.panelTotal.BackColor = System.Drawing.Color.PaleTurquoise;
            this.panelTotal.Controls.Add(this.label1);
            this.panelTotal.Controls.Add(this.label6);
            this.panelTotal.Controls.Add(this.txtTotal);
            this.panelTotal.Location = new System.Drawing.Point(9, 19);
            this.panelTotal.Name = "panelTotal";
            this.panelTotal.Size = new System.Drawing.Size(402, 50);
            this.panelTotal.TabIndex = 22;
            // 
            // FrmDinamicCancelar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(454, 385);
            this.Controls.Add(this.gbFormaPago);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDinamicCancelar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cancelar Venta";
            this.Load += new System.EventHandler(this.FrmCancelarVenta_Load);
            this.gbFormaPago.ResumeLayout(false);
            this.PanelCambio.ResumeLayout(false);
            this.PanelCambio.PerformLayout();
            this.panelTotal.ResumeLayout(false);
            this.panelTotal.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panelTotal;
        public System.Windows.Forms.GroupBox gbFormaPago;
        private System.Windows.Forms.Panel PanelCambio;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCambio;
        private System.Windows.Forms.Label label5;

    }
}