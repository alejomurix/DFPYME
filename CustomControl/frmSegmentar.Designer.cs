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
            this.lblInfo = new System.Windows.Forms.Label();
            this.lblSegment = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRetry = new System.Windows.Forms.Button();
            this.btnYes = new System.Windows.Forms.Button();
            this.OK = new System.Windows.Forms.Button();
            this.btnNo = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblInfo.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblInfo.Location = new System.Drawing.Point(12, 11);
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
            this.lblSegment.Location = new System.Drawing.Point(12, 29);
            this.lblSegment.Name = "lblSegment";
            this.lblSegment.Size = new System.Drawing.Size(243, 16);
            this.lblSegment.TabIndex = 0;
            this.lblSegment.Text = "Articulo mayor, no se puede segmentar.";
            this.lblSegment.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.label1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label1.Location = new System.Drawing.Point(37, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Seg (1)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.label2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label2.Location = new System.Drawing.Point(103, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Ord (2)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.label3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label3.Location = new System.Drawing.Point(161, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Sg+Or (3)";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Controls.Add(this.btnRetry);
            this.panel1.Controls.Add(this.btnYes);
            this.panel1.Controls.Add(this.OK);
            this.panel1.Controls.Add(this.btnNo);
            this.panel1.Controls.Add(this.lblInfo);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblSegment);
            this.panel1.Location = new System.Drawing.Point(10, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(293, 108);
            this.panel1.TabIndex = 0;
            // 
            // btnRetry
            // 
            this.btnRetry.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnRetry.DialogResult = System.Windows.Forms.DialogResult.Retry;
            this.btnRetry.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnRetry.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRetry.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRetry.Image = ((System.Drawing.Image)(resources.GetObject("btnRetry.Image")));
            this.btnRetry.Location = new System.Drawing.Point(178, 73);
            this.btnRetry.Name = "btnRetry";
            this.btnRetry.Size = new System.Drawing.Size(26, 26);
            this.btnRetry.TabIndex = 2;
            this.btnRetry.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRetry.UseVisualStyleBackColor = false;
            // 
            // btnYes
            // 
            this.btnYes.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnYes.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnYes.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnYes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnYes.Image = ((System.Drawing.Image)(resources.GetObject("btnYes.Image")));
            this.btnYes.Location = new System.Drawing.Point(113, 73);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(26, 26);
            this.btnYes.TabIndex = 1;
            this.btnYes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnYes.UseVisualStyleBackColor = false;
            // 
            // OK
            // 
            this.OK.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OK.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.OK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OK.Image = ((System.Drawing.Image)(resources.GetObject("OK.Image")));
            this.OK.Location = new System.Drawing.Point(48, 73);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(26, 26);
            this.OK.TabIndex = 0;
            this.OK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.OK.UseVisualStyleBackColor = false;
            // 
            // btnNo
            // 
            this.btnNo.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnNo.DialogResult = System.Windows.Forms.DialogResult.No;
            this.btnNo.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNo.Image = ((System.Drawing.Image)(resources.GetObject("btnNo.Image")));
            this.btnNo.Location = new System.Drawing.Point(242, 73);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(26, 26);
            this.btnNo.TabIndex = 3;
            this.btnNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNo.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.label4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label4.Location = new System.Drawing.Point(230, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Elec (4)";
            // 
            // frmSegmentar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(317, 127);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSegmentar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Segmentar venta";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSegmentar_FormClosing);
            this.Load += new System.EventHandler(this.frmPassword_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPassword_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Label lblInfo;
        public System.Windows.Forms.Label lblSegment;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnRetry;
        private System.Windows.Forms.Button btnYes;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Button btnNo;
        public System.Windows.Forms.Label label4;
    }
}