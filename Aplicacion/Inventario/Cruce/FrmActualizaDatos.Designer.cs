namespace Aplicacion.Inventario.Cruce
{
    partial class FrmActualizaDatos
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
            this.gbCompra = new System.Windows.Forms.GroupBox();
            this.lblCompra = new System.Windows.Forms.Label();
            this.txtNumeroCompra = new System.Windows.Forms.TextBox();
            this.btnActCompra = new System.Windows.Forms.Button();
            this.gbVenta = new System.Windows.Forms.GroupBox();
            this.lblFacturaVenta = new System.Windows.Forms.Label();
            this.txtNumeroFactura = new System.Windows.Forms.TextBox();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.gbCompra.SuspendLayout();
            this.gbVenta.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbCompra
            // 
            this.gbCompra.Controls.Add(this.lblCompra);
            this.gbCompra.Controls.Add(this.txtNumeroCompra);
            this.gbCompra.Controls.Add(this.btnActCompra);
            this.gbCompra.Location = new System.Drawing.Point(12, 89);
            this.gbCompra.Name = "gbCompra";
            this.gbCompra.Size = new System.Drawing.Size(381, 79);
            this.gbCompra.TabIndex = 1;
            this.gbCompra.TabStop = false;
            this.gbCompra.Text = "Datos de Factura de Compra";
            // 
            // lblCompra
            // 
            this.lblCompra.AutoSize = true;
            this.lblCompra.Location = new System.Drawing.Point(7, 34);
            this.lblCompra.Name = "lblCompra";
            this.lblCompra.Size = new System.Drawing.Size(155, 16);
            this.lblCompra.TabIndex = 2;
            this.lblCompra.Text = "Número Factura Compra";
            // 
            // txtNumeroCompra
            // 
            this.txtNumeroCompra.Location = new System.Drawing.Point(168, 31);
            this.txtNumeroCompra.Name = "txtNumeroCompra";
            this.txtNumeroCompra.Size = new System.Drawing.Size(100, 22);
            this.txtNumeroCompra.TabIndex = 0;
            // 
            // btnActCompra
            // 
            this.btnActCompra.Location = new System.Drawing.Point(284, 30);
            this.btnActCompra.Name = "btnActCompra";
            this.btnActCompra.Size = new System.Drawing.Size(89, 23);
            this.btnActCompra.TabIndex = 1;
            this.btnActCompra.Text = "Actualizar";
            this.btnActCompra.UseVisualStyleBackColor = true;
            this.btnActCompra.Click += new System.EventHandler(this.btnActCompra_Click);
            // 
            // gbVenta
            // 
            this.gbVenta.Controls.Add(this.lblFacturaVenta);
            this.gbVenta.Controls.Add(this.txtNumeroFactura);
            this.gbVenta.Controls.Add(this.btnActualizar);
            this.gbVenta.Location = new System.Drawing.Point(12, 12);
            this.gbVenta.Name = "gbVenta";
            this.gbVenta.Size = new System.Drawing.Size(381, 71);
            this.gbVenta.TabIndex = 0;
            this.gbVenta.TabStop = false;
            this.gbVenta.Text = "Datos de Factura de Venta";
            // 
            // lblFacturaVenta
            // 
            this.lblFacturaVenta.AutoSize = true;
            this.lblFacturaVenta.Location = new System.Drawing.Point(7, 30);
            this.lblFacturaVenta.Name = "lblFacturaVenta";
            this.lblFacturaVenta.Size = new System.Drawing.Size(145, 16);
            this.lblFacturaVenta.TabIndex = 2;
            this.lblFacturaVenta.Text = "Número Última Factura";
            // 
            // txtNumeroFactura
            // 
            this.txtNumeroFactura.Location = new System.Drawing.Point(158, 27);
            this.txtNumeroFactura.Name = "txtNumeroFactura";
            this.txtNumeroFactura.Size = new System.Drawing.Size(100, 22);
            this.txtNumeroFactura.TabIndex = 0;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(274, 26);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(89, 23);
            this.btnActualizar.TabIndex = 1;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // FrmActualizaDatos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(410, 180);
            this.Controls.Add(this.gbVenta);
            this.Controls.Add(this.gbCompra);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmActualizaDatos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Actualizar datos";
            this.Load += new System.EventHandler(this.FrmActualizaDatos_Load);
            this.gbCompra.ResumeLayout(false);
            this.gbCompra.PerformLayout();
            this.gbVenta.ResumeLayout(false);
            this.gbVenta.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbCompra;
        private System.Windows.Forms.GroupBox gbVenta;
        private System.Windows.Forms.TextBox txtNumeroFactura;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Label lblFacturaVenta;
        private System.Windows.Forms.Label lblCompra;
        private System.Windows.Forms.TextBox txtNumeroCompra;
        private System.Windows.Forms.Button btnActCompra;
    }
}