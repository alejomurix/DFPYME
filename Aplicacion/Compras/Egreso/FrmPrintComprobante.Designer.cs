namespace Aplicacion.Compras.Egreso
{
    partial class FrmPrintComprobante
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
            this.rpvEgreso = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rpvEgreso
            // 
            this.rpvEgreso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpvEgreso.Location = new System.Drawing.Point(0, 0);
            this.rpvEgreso.Name = "rpvEgreso";
            this.rpvEgreso.ShowExportButton = false;
            this.rpvEgreso.Size = new System.Drawing.Size(854, 464);
            this.rpvEgreso.TabIndex = 0;
            this.rpvEgreso.Print += new Microsoft.Reporting.WinForms.ReportPrintEventHandler(this.rpvEgreso_Print);
            // 
            // FrmPrintComprobante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 464);
            this.Controls.Add(this.rpvEgreso);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPrintComprobante";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Imprimir Comprobante de Egreso";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPrintComprobante_FormClosing);
            this.Load += new System.EventHandler(this.FrmPrintComprobante_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvEgreso;
    }
}