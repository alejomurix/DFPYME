namespace Aplicacion.Administracion.Retencion
{
    partial class FrmEditarRubro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEditarRubro));
            this.gbNuevoRubro = new System.Windows.Forms.GroupBox();
            this.lblRubro = new System.Windows.Forms.Label();
            this.txtRubro = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gbNuevoRubro.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbNuevoRubro
            // 
            this.gbNuevoRubro.Controls.Add(this.lblRubro);
            this.gbNuevoRubro.Controls.Add(this.txtRubro);
            this.gbNuevoRubro.Controls.Add(this.btnOk);
            this.gbNuevoRubro.Controls.Add(this.btnCancel);
            this.gbNuevoRubro.Location = new System.Drawing.Point(10, 6);
            this.gbNuevoRubro.Margin = new System.Windows.Forms.Padding(4);
            this.gbNuevoRubro.Name = "gbNuevoRubro";
            this.gbNuevoRubro.Padding = new System.Windows.Forms.Padding(4);
            this.gbNuevoRubro.Size = new System.Drawing.Size(503, 142);
            this.gbNuevoRubro.TabIndex = 1;
            this.gbNuevoRubro.TabStop = false;
            // 
            // lblRubro
            // 
            this.lblRubro.AutoSize = true;
            this.lblRubro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblRubro.Location = new System.Drawing.Point(13, 20);
            this.lblRubro.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRubro.Name = "lblRubro";
            this.lblRubro.Size = new System.Drawing.Size(83, 16);
            this.lblRubro.TabIndex = 3;
            this.lblRubro.Text = "Editar Rubro";
            // 
            // txtRubro
            // 
            this.txtRubro.Location = new System.Drawing.Point(14, 53);
            this.txtRubro.Margin = new System.Windows.Forms.Padding(4);
            this.txtRubro.Name = "txtRubro";
            this.txtRubro.Size = new System.Drawing.Size(476, 22);
            this.txtRubro.TabIndex = 0;
            this.txtRubro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRubro_KeyPress);
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.Image")));
            this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOk.Location = new System.Drawing.Point(302, 97);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(83, 25);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "Aceptar";
            this.btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(402, 97);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 25);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FrmEditarRubro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(527, 161);
            this.Controls.Add(this.gbNuevoRubro);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmEditarRubro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editar Rubro";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmEditarRubro_KeyDown);
            this.gbNuevoRubro.ResumeLayout(false);
            this.gbNuevoRubro.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbNuevoRubro;
        private System.Windows.Forms.Label lblRubro;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.TextBox txtRubro;
    }
}