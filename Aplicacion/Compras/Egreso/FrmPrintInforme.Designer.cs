namespace Aplicacion.Compras.Egreso
{
    partial class FrmPrintInforme
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrintInforme));
            this.rpvEgresos = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rpvEgresos
            // 
            this.rpvEgresos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpvEgresos.Location = new System.Drawing.Point(0, 0);
            this.rpvEgresos.Name = "rpvEgresos";
            this.rpvEgresos.Size = new System.Drawing.Size(1040, 525);
            this.rpvEgresos.TabIndex = 0;
            // 
            // FrmPrintInforme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 525);
            this.Controls.Add(this.rpvEgresos);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmPrintInforme";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Imprimir";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPrintInforme_FormClosing);
            this.Load += new System.EventHandler(this.FrmPrintInforme_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public Microsoft.Reporting.WinForms.ReportViewer rpvEgresos;

    }
}