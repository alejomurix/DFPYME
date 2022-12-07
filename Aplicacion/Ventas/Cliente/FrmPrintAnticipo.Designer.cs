namespace Aplicacion.Ventas.Cliente
{
    partial class FrmPrintAnticipo
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
            this.rpvAnticipo = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rpvAnticipo
            // 
            this.rpvAnticipo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpvAnticipo.Location = new System.Drawing.Point(0, 0);
            this.rpvAnticipo.Name = "rpvAnticipo";
            this.rpvAnticipo.ShowExportButton = false;
            this.rpvAnticipo.Size = new System.Drawing.Size(878, 494);
            this.rpvAnticipo.TabIndex = 0;
            this.rpvAnticipo.Print += new Microsoft.Reporting.WinForms.ReportPrintEventHandler(this.rpvAnticipo_Print);
            // 
            // FrmPrintAnticipo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(878, 494);
            this.Controls.Add(this.rpvAnticipo);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPrintAnticipo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Comprobante de Ingreso";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPrintAnticipo_FormClosing);
            this.Load += new System.EventHandler(this.FrmPrintAnticipo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvAnticipo;
    }
}