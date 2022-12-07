namespace Aplicacion.Administracion.CajaDiario
{
    partial class FrmCajaDiario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCajaDiario));
            this.rptVCajaDiario = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rptVCajaDiario
            // 
            this.rptVCajaDiario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptVCajaDiario.Location = new System.Drawing.Point(0, 0);
            this.rptVCajaDiario.Name = "rptVCajaDiario";
            this.rptVCajaDiario.Size = new System.Drawing.Size(879, 600);
            this.rptVCajaDiario.TabIndex = 0;
            this.rptVCajaDiario.Print += new Microsoft.Reporting.WinForms.ReportPrintEventHandler(this.rptVCajaDiario_Print);
            // 
            // FrmCajaDiario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(879, 600);
            this.Controls.Add(this.rptVCajaDiario);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCajaDiario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Resumen de Caja Diario";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmCajaDiario_FormClosing);
            this.Load += new System.EventHandler(this.FrmCajaDiario_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rptVCajaDiario;
    }
}