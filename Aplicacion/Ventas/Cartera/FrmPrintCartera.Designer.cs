namespace Aplicacion.Ventas.Cartera
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
            this.RptvCartera = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // RptvCartera
            // 
            this.RptvCartera.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RptvCartera.Location = new System.Drawing.Point(0, 0);
            this.RptvCartera.Name = "RptvCartera";
            this.RptvCartera.ShowFindControls = false;
            this.RptvCartera.Size = new System.Drawing.Size(985, 549);
            this.RptvCartera.TabIndex = 0;
            this.RptvCartera.Print += new Microsoft.Reporting.WinForms.ReportPrintEventHandler(this.RptvCartera_Print);
            // 
            // FrmPrintCartera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 549);
            this.Controls.Add(this.RptvCartera);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPrintCartera";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Imprimir Cartera";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPrintFactura_FormClosing);
            this.Load += new System.EventHandler(this.FrmPrintFactura_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public Microsoft.Reporting.WinForms.ReportViewer RptvCartera;

    }
}