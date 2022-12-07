namespace Aplicacion.Configuracion.Version
{
    partial class FrmVersion
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
            this.gbVersion = new System.Windows.Forms.GroupBox();
            this.lblLicencia = new System.Windows.Forms.Label();
            this.lblDerechos = new System.Windows.Forms.Label();
            this.lblAnioEmpresa = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.gbVersion.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbVersion
            // 
            this.gbVersion.Controls.Add(this.lblNombre);
            this.gbVersion.Controls.Add(this.lblVersion);
            this.gbVersion.Controls.Add(this.lblAnioEmpresa);
            this.gbVersion.Controls.Add(this.lblDerechos);
            this.gbVersion.Controls.Add(this.lblLicencia);
            this.gbVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.gbVersion.Location = new System.Drawing.Point(12, 10);
            this.gbVersion.Name = "gbVersion";
            this.gbVersion.Size = new System.Drawing.Size(291, 245);
            this.gbVersion.TabIndex = 0;
            this.gbVersion.TabStop = false;
            // 
            // lblLicencia
            // 
            this.lblLicencia.AutoSize = true;
            this.lblLicencia.Location = new System.Drawing.Point(20, 196);
            this.lblLicencia.Name = "lblLicencia";
            this.lblLicencia.Size = new System.Drawing.Size(46, 17);
            this.lblLicencia.TabIndex = 0;
            this.lblLicencia.Text = "label1";
            // 
            // lblDerechos
            // 
            this.lblDerechos.AutoSize = true;
            this.lblDerechos.Location = new System.Drawing.Point(20, 151);
            this.lblDerechos.Name = "lblDerechos";
            this.lblDerechos.Size = new System.Drawing.Size(212, 17);
            this.lblDerechos.TabIndex = 1;
            this.lblDerechos.Text = "Reservados todos los derechos.";
            // 
            // lblAnioEmpresa
            // 
            this.lblAnioEmpresa.AutoSize = true;
            this.lblAnioEmpresa.Location = new System.Drawing.Point(20, 110);
            this.lblAnioEmpresa.Name = "lblAnioEmpresa";
            this.lblAnioEmpresa.Size = new System.Drawing.Size(46, 17);
            this.lblAnioEmpresa.TabIndex = 2;
            this.lblAnioEmpresa.Text = "label3";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(20, 68);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(46, 17);
            this.lblVersion.TabIndex = 3;
            this.lblVersion.Text = "label4";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(20, 29);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(121, 17);
            this.lblNombre.TabIndex = 4;
            this.lblNombre.Text = "Digital Fact Pyme ";
            // 
            // FrmVersion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(319, 270);
            this.Controls.Add(this.gbVersion);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmVersion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Acerca de Digital Fact Pyme ";
            this.Load += new System.EventHandler(this.FrmVersion_Load);
            this.gbVersion.ResumeLayout(false);
            this.gbVersion.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbVersion;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblAnioEmpresa;
        private System.Windows.Forms.Label lblDerechos;
        private System.Windows.Forms.Label lblLicencia;
    }
}