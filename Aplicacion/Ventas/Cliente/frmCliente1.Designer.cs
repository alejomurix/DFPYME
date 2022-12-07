namespace Aplicacion.Ventas.Cliente
{
    partial class frmCliente1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCliente1));
            this.menuCliente = new System.Windows.Forms.ToolStrip();
            this.tsbNuevoCliente = new System.Windows.Forms.ToolStripButton();
            this.menuCliente.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuCliente
            // 
            this.menuCliente.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNuevoCliente});
            this.menuCliente.Location = new System.Drawing.Point(0, 0);
            this.menuCliente.Name = "menuCliente";
            this.menuCliente.Size = new System.Drawing.Size(984, 25);
            this.menuCliente.TabIndex = 1;
            this.menuCliente.Text = "toolStrip1";
            // 
            // tsbNuevoCliente
            // 
            this.tsbNuevoCliente.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsbNuevoCliente.Image = ((System.Drawing.Image)(resources.GetObject("tsbNuevoCliente.Image")));
            this.tsbNuevoCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsbNuevoCliente.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNuevoCliente.Name = "tsbNuevoCliente";
            this.tsbNuevoCliente.Size = new System.Drawing.Size(109, 22);
            this.tsbNuevoCliente.Text = "Nuevo Cliente";
            this.tsbNuevoCliente.Click += new System.EventHandler(this.tsbNuevoCliente_Click);
            // 
            // frmCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 622);
            this.Controls.Add(this.menuCliente);
            this.IsMdiContainer = true;
            this.Name = "frmCliente";
            this.Text = "Cliente";
            this.Load += new System.EventHandler(this.frmCliente_Load);
            this.menuCliente.ResumeLayout(false);
            this.menuCliente.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip menuCliente;
        private System.Windows.Forms.ToolStripButton tsbNuevoCliente;

    }
}