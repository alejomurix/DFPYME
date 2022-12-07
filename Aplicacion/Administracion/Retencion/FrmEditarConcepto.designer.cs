namespace Aplicacion.Administracion.Retencion
{
    partial class FrmEditarConcepto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEditarConcepto));
            this.gbNuevoRubro = new System.Windows.Forms.GroupBox();
            this.lblRubro = new System.Windows.Forms.Label();
            this.txtConcepto = new System.Windows.Forms.TextBox();
            this.lblCifraUVT = new System.Windows.Forms.Label();
            this.txtCifraUvt = new System.Windows.Forms.TextBox();
            this.lblCifraPesos = new System.Windows.Forms.Label();
            this.txtCifraPesos = new System.Windows.Forms.TextBox();
            this.lblTarifa = new System.Windows.Forms.Label();
            this.txtTarifa = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gbNuevoRubro.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbNuevoRubro
            // 
            this.gbNuevoRubro.Controls.Add(this.lblRubro);
            this.gbNuevoRubro.Controls.Add(this.txtConcepto);
            this.gbNuevoRubro.Controls.Add(this.lblCifraUVT);
            this.gbNuevoRubro.Controls.Add(this.txtCifraUvt);
            this.gbNuevoRubro.Controls.Add(this.lblCifraPesos);
            this.gbNuevoRubro.Controls.Add(this.txtCifraPesos);
            this.gbNuevoRubro.Controls.Add(this.lblTarifa);
            this.gbNuevoRubro.Controls.Add(this.txtTarifa);
            this.gbNuevoRubro.Controls.Add(this.btnOk);
            this.gbNuevoRubro.Controls.Add(this.btnCancel);
            this.gbNuevoRubro.Location = new System.Drawing.Point(12, 9);
            this.gbNuevoRubro.Margin = new System.Windows.Forms.Padding(4);
            this.gbNuevoRubro.Name = "gbNuevoRubro";
            this.gbNuevoRubro.Padding = new System.Windows.Forms.Padding(4);
            this.gbNuevoRubro.Size = new System.Drawing.Size(513, 360);
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
            this.lblRubro.Size = new System.Drawing.Size(66, 16);
            this.lblRubro.TabIndex = 3;
            this.lblRubro.Text = "Concepto";
            // 
            // txtConcepto
            // 
            this.txtConcepto.Location = new System.Drawing.Point(14, 41);
            this.txtConcepto.Margin = new System.Windows.Forms.Padding(4);
            this.txtConcepto.Multiline = true;
            this.txtConcepto.Name = "txtConcepto";
            this.txtConcepto.Size = new System.Drawing.Size(476, 95);
            this.txtConcepto.TabIndex = 0;
            this.txtConcepto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRubro_KeyPress);
            this.txtConcepto.Validating += new System.ComponentModel.CancelEventHandler(this.txtConcepto_Validating);
            // 
            // lblCifraUVT
            // 
            this.lblCifraUVT.AutoSize = true;
            this.lblCifraUVT.Location = new System.Drawing.Point(11, 146);
            this.lblCifraUVT.Name = "lblCifraUVT";
            this.lblCifraUVT.Size = new System.Drawing.Size(66, 16);
            this.lblCifraUVT.TabIndex = 9;
            this.lblCifraUVT.Text = "Cifra UVT";
            // 
            // txtCifraUvt
            // 
            this.txtCifraUvt.Location = new System.Drawing.Point(14, 165);
            this.txtCifraUvt.Name = "txtCifraUvt";
            this.txtCifraUvt.Size = new System.Drawing.Size(476, 22);
            this.txtCifraUvt.TabIndex = 6;
            this.txtCifraUvt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCifraUvt_KeyPress);
            this.txtCifraUvt.Validating += new System.ComponentModel.CancelEventHandler(this.txtCifraUvt_Validating);
            // 
            // lblCifraPesos
            // 
            this.lblCifraPesos.AutoSize = true;
            this.lblCifraPesos.Location = new System.Drawing.Point(11, 202);
            this.lblCifraPesos.Name = "lblCifraPesos";
            this.lblCifraPesos.Size = new System.Drawing.Size(77, 16);
            this.lblCifraPesos.TabIndex = 8;
            this.lblCifraPesos.Text = "Cifra Pesos";
            // 
            // txtCifraPesos
            // 
            this.txtCifraPesos.Location = new System.Drawing.Point(14, 221);
            this.txtCifraPesos.Name = "txtCifraPesos";
            this.txtCifraPesos.Size = new System.Drawing.Size(476, 22);
            this.txtCifraPesos.TabIndex = 5;
            this.txtCifraPesos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCifraPesos_KeyPress);
            this.txtCifraPesos.Validating += new System.ComponentModel.CancelEventHandler(this.txtCifraPesos_Validating);
            // 
            // lblTarifa
            // 
            this.lblTarifa.AutoSize = true;
            this.lblTarifa.Location = new System.Drawing.Point(14, 259);
            this.lblTarifa.Name = "lblTarifa";
            this.lblTarifa.Size = new System.Drawing.Size(58, 16);
            this.lblTarifa.TabIndex = 7;
            this.lblTarifa.Text = "Tarifa %";
            // 
            // txtTarifa
            // 
            this.txtTarifa.Location = new System.Drawing.Point(14, 278);
            this.txtTarifa.Name = "txtTarifa";
            this.txtTarifa.Size = new System.Drawing.Size(476, 22);
            this.txtTarifa.TabIndex = 4;
            this.txtTarifa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTarifa_KeyPress);
            this.txtTarifa.Validating += new System.ComponentModel.CancelEventHandler(this.txtTarifa_Validating);
            // 
            // btnOk
            // 
            this.btnOk.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.Image")));
            this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOk.Location = new System.Drawing.Point(302, 318);
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
            this.btnCancel.Location = new System.Drawing.Point(402, 318);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 25);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FrmEditarConcepto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(538, 383);
            this.Controls.Add(this.gbNuevoRubro);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmEditarConcepto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editar Concepto";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmNuevoConcepto_KeyDown);
            this.gbNuevoRubro.ResumeLayout(false);
            this.gbNuevoRubro.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbNuevoRubro;
        private System.Windows.Forms.Label lblRubro;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblCifraUVT;
        private System.Windows.Forms.Label lblCifraPesos;
        private System.Windows.Forms.Label lblTarifa;
        public System.Windows.Forms.TextBox txtConcepto;
        public System.Windows.Forms.TextBox txtCifraUvt;
        public System.Windows.Forms.TextBox txtCifraPesos;
        public System.Windows.Forms.TextBox txtTarifa;
    }
}