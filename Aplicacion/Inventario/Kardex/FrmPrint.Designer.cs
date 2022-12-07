namespace Aplicacion.Inventario.Kardex
{
    partial class FrmPrint
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrint));
            this.DsInventarioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.RptViewInforme = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.DsInventarioBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // DsInventarioBindingSource
            // 
            this.DsInventarioBindingSource.DataMember = "Inventario";
            this.DsInventarioBindingSource.DataSource = typeof(Aplicacion.DataSets.DsInventario);
            // 
            // RptViewInforme
            // 
            this.RptViewInforme.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RptViewInforme.Location = new System.Drawing.Point(0, 0);
            this.RptViewInforme.Name = "RptViewInforme";
            this.RptViewInforme.Size = new System.Drawing.Size(931, 660);
            this.RptViewInforme.TabIndex = 0;
            // 
            // FrmPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 660);
            this.Controls.Add(this.RptViewInforme);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPrint";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Imprimir";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmInformeInventario_FormClosing);
            this.Load += new System.EventHandler(this.FrmInformeInventario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DsInventarioBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource DsInventarioBindingSource;
        private Microsoft.Reporting.WinForms.ReportViewer RptViewInforme;
    }
}