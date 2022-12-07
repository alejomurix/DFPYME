namespace Aplicacion.Compras.IngresarCompra
{
    partial class FrmPrintFactura
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrintFactura));
            this.RptvFactura = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // RptvFactura
            // 
            this.RptvFactura.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RptvFactura.Location = new System.Drawing.Point(0, 0);
            this.RptvFactura.Name = "RptvFactura";
            this.RptvFactura.ShowExportButton = false;
            this.RptvFactura.ShowFindControls = false;
            this.RptvFactura.Size = new System.Drawing.Size(985, 549);
            this.RptvFactura.TabIndex = 0;
            this.RptvFactura.Print += new Microsoft.Reporting.WinForms.ReportPrintEventHandler(this.RptvFactura_Print);
            // 
            // FrmPrintFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 549);
            this.Controls.Add(this.RptvFactura);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPrintFactura";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Imprimir Factura";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPrintFactura_FormClosing);
            this.Load += new System.EventHandler(this.FrmPrintFactura_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public Microsoft.Reporting.WinForms.ReportViewer RptvFactura;

    }
}