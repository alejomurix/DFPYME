namespace Aplicacion.Ventas.Cliente.Cartera
{
    partial class FrmPrintCartera
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrintCartera));
            this.rptCartera = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rptCartera
            // 
            this.rptCartera.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptCartera.Location = new System.Drawing.Point(0, 0);
            this.rptCartera.Name = "rptCartera";
            this.rptCartera.ShowExportButton = false;
            this.rptCartera.Size = new System.Drawing.Size(879, 600);
            this.rptCartera.TabIndex = 0;
            this.rptCartera.Print += new Microsoft.Reporting.WinForms.ReportPrintEventHandler(this.rptCartera_Print);
            // 
            // FrmPrintCartera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(879, 600);
            this.Controls.Add(this.rptCartera);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPrintCartera";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Resumen de Cartera";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmCajaDiario_FormClosing);
            this.Load += new System.EventHandler(this.FrmCajaDiario_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rptCartera;
    }
}