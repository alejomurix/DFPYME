namespace CustomControl
{
    partial class frmSegmentar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSegmentar));
            this.OK = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            this.lblSegment = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // OK
            // 
            this.OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OK.Location = new System.Drawing.Point(205, 71);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(75, 23);
            this.OK.TabIndex = 2;
            this.OK.Text = "Segmentar";
            this.OK.UseVisualStyleBackColor = true;
            // 
            // Cancel
            // 
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.Location = new System.Drawing.Point(116, 71);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(76, 23);
            this.Cancel.TabIndex = 3;
            this.Cancel.Text = "F. Electronic";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Visible = false;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblInfo.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblInfo.Location = new System.Drawing.Point(14, 17);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(267, 16);
            this.lblInfo.TabIndex = 0;
            this.lblInfo.Text = "La factura supera el monto, elija una opción:";
            // 
            // lblSegment
            // 
            this.lblSegment.AutoSize = true;
            this.lblSegment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblSegment.ForeColor = System.Drawing.Color.Red;
            this.lblSegment.Location = new System.Drawing.Point(38, 40);
            this.lblSegment.Name = "lblSegment";
            this.lblSegment.Size = new System.Drawing.Size(243, 16);
            this.lblSegment.TabIndex = 0;
            this.lblSegment.Text = "Articulo mayor, no se puede segmentar.";
            this.lblSegment.Visible = false;
            // 
            // frmSegmentar
            // 
            this.AcceptButton = this.OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(303, 113);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.lblSegment);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.Cancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSegmentar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmPassword_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPassword_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Button OK;
        public System.Windows.Forms.Button Cancel;
        public System.Windows.Forms.Label lblInfo;
        public System.Windows.Forms.Label lblSegment;
    }
}