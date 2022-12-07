namespace CustomControl
{
    partial class FrmDocumento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDocumento));
            this.btnIngreso = new System.Windows.Forms.Button();
            this.btnReciboCaja = new System.Windows.Forms.Button();
            this.lblCompIngreso = new System.Windows.Forms.Label();
            this.lblReciboCaja = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnIngreso
            // 
            this.btnIngreso.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnIngreso.Image = ((System.Drawing.Image)(resources.GetObject("btnIngreso.Image")));
            this.btnIngreso.Location = new System.Drawing.Point(67, 27);
            this.btnIngreso.Margin = new System.Windows.Forms.Padding(4);
            this.btnIngreso.Name = "btnIngreso";
            this.btnIngreso.Size = new System.Drawing.Size(43, 38);
            this.btnIngreso.TabIndex = 0;
            this.btnIngreso.UseVisualStyleBackColor = true;
            // 
            // btnReciboCaja
            // 
            this.btnReciboCaja.DialogResult = System.Windows.Forms.DialogResult.No;
            this.btnReciboCaja.Image = ((System.Drawing.Image)(resources.GetObject("btnReciboCaja.Image")));
            this.btnReciboCaja.Location = new System.Drawing.Point(241, 27);
            this.btnReciboCaja.Margin = new System.Windows.Forms.Padding(4);
            this.btnReciboCaja.Name = "btnReciboCaja";
            this.btnReciboCaja.Size = new System.Drawing.Size(43, 38);
            this.btnReciboCaja.TabIndex = 1;
            this.btnReciboCaja.UseVisualStyleBackColor = true;
            // 
            // lblCompIngreso
            // 
            this.lblCompIngreso.AutoSize = true;
            this.lblCompIngreso.Location = new System.Drawing.Point(15, 69);
            this.lblCompIngreso.Name = "lblCompIngreso";
            this.lblCompIngreso.Size = new System.Drawing.Size(157, 16);
            this.lblCompIngreso.TabIndex = 3;
            this.lblCompIngreso.Text = "Comprobante de Ingreso";
            // 
            // lblReciboCaja
            // 
            this.lblReciboCaja.AutoSize = true;
            this.lblReciboCaja.Location = new System.Drawing.Point(214, 69);
            this.lblReciboCaja.Name = "lblReciboCaja";
            this.lblReciboCaja.Size = new System.Drawing.Size(102, 16);
            this.lblReciboCaja.TabIndex = 4;
            this.lblReciboCaja.Text = "Recibo de Caja";
            // 
            // FrmDocumento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(346, 119);
            this.Controls.Add(this.btnIngreso);
            this.Controls.Add(this.lblCompIngreso);
            this.Controls.Add(this.btnReciboCaja);
            this.Controls.Add(this.lblReciboCaja);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDocumento";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmPrint";
            this.Load += new System.EventHandler(this.FrmPrint_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReciboCaja;
        private System.Windows.Forms.Button btnIngreso;
        private System.Windows.Forms.Label lblCompIngreso;
        private System.Windows.Forms.Label lblReciboCaja;
    }
}