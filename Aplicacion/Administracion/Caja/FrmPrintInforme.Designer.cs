namespace Aplicacion.Administracion.Caja
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
            this.RptvInforme = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // RptvInforme
            // 
            this.RptvInforme.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RptvInforme.Location = new System.Drawing.Point(0, 0);
            this.RptvInforme.Name = "RptvInforme";
            this.RptvInforme.ShowExportButton = false;
            this.RptvInforme.ShowFindControls = false;
            this.RptvInforme.Size = new System.Drawing.Size(692, 589);
            this.RptvInforme.TabIndex = 1;
            // 
            // FrmPrintInforme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 589);
            this.Controls.Add(this.RptvInforme);
            this.Name = "FrmPrintInforme";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Imprimir Informe";
            this.Load += new System.EventHandler(this.FrmPrintInforme_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public Microsoft.Reporting.WinForms.ReportViewer RptvInforme;
    }
}