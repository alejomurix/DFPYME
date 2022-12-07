namespace CustomControl
{
    partial class FrmPrint_
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrint_));
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnVisualizar = new System.Windows.Forms.Button();
            this.PanelPrint = new System.Windows.Forms.Panel();
            this.lblVisualizar = new System.Windows.Forms.Label();
            this.lblCancelar = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.PanelPrint.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.Location = new System.Drawing.Point(185, 22);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(43, 38);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnVisualizar
            // 
            this.btnVisualizar.DialogResult = System.Windows.Forms.DialogResult.No;
            this.btnVisualizar.Image = ((System.Drawing.Image)(resources.GetObject("btnVisualizar.Image")));
            this.btnVisualizar.Location = new System.Drawing.Point(35, 22);
            this.btnVisualizar.Margin = new System.Windows.Forms.Padding(4);
            this.btnVisualizar.Name = "btnVisualizar";
            this.btnVisualizar.Size = new System.Drawing.Size(43, 38);
            this.btnVisualizar.TabIndex = 1;
            this.btnVisualizar.UseVisualStyleBackColor = true;
            // 
            // PanelPrint
            // 
            this.PanelPrint.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.PanelPrint.Controls.Add(this.btnVisualizar);
            this.PanelPrint.Controls.Add(this.lblVisualizar);
            this.PanelPrint.Controls.Add(this.btnCancelar);
            this.PanelPrint.Controls.Add(this.lblCancelar);
            this.PanelPrint.Location = new System.Drawing.Point(0, 56);
            this.PanelPrint.Margin = new System.Windows.Forms.Padding(4);
            this.PanelPrint.Name = "PanelPrint";
            this.PanelPrint.Size = new System.Drawing.Size(267, 101);
            this.PanelPrint.TabIndex = 0;
            // 
            // lblVisualizar
            // 
            this.lblVisualizar.AutoSize = true;
            this.lblVisualizar.Location = new System.Drawing.Point(26, 64);
            this.lblVisualizar.Name = "lblVisualizar";
            this.lblVisualizar.Size = new System.Drawing.Size(66, 16);
            this.lblVisualizar.TabIndex = 4;
            this.lblVisualizar.Text = "Visualizar";
            // 
            // lblCancelar
            // 
            this.lblCancelar.AutoSize = true;
            this.lblCancelar.Location = new System.Drawing.Point(176, 64);
            this.lblCancelar.Name = "lblCancelar";
            this.lblCancelar.Size = new System.Drawing.Size(62, 16);
            this.lblCancelar.TabIndex = 5;
            this.lblCancelar.Text = "Cancelar";
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(12, 21);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(30, 16);
            this.lblInfo.TabIndex = 0;
            this.lblInfo.Text = "Imp";
            // 
            // FrmPrint_
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(268, 157);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.PanelPrint);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPrint_";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmPrint";
            this.Load += new System.EventHandler(this.FrmPrint_Load);
            this.PanelPrint.ResumeLayout(false);
            this.PanelPrint.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnVisualizar;
        private System.Windows.Forms.Panel PanelPrint;
        private System.Windows.Forms.Label lblVisualizar;
        private System.Windows.Forms.Label lblCancelar;
        private System.Windows.Forms.Label lblInfo;
    }
}