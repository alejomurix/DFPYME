namespace Aplicacion.Administracion.Puntos
{
    partial class frmPuntos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPuntos));
            this.grbPuntos = new System.Windows.Forms.GroupBox();
            this.chkAplicar = new System.Windows.Forms.CheckBox();
            this.lblVentaMinima = new System.Windows.Forms.Label();
            this.txtVentaMinima = new System.Windows.Forms.TextBox();
            this.lblNumeroPuntos = new System.Windows.Forms.Label();
            this.txtNumeroPuntos = new System.Windows.Forms.TextBox();
            this.lblValorPuntos = new System.Windows.Forms.Label();
            this.txtValorPuntos = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grbPuntos.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbPuntos
            // 
            this.grbPuntos.Controls.Add(this.btnOk);
            this.grbPuntos.Controls.Add(this.btnCancel);
            this.grbPuntos.Controls.Add(this.chkAplicar);
            this.grbPuntos.Controls.Add(this.lblVentaMinima);
            this.grbPuntos.Controls.Add(this.txtVentaMinima);
            this.grbPuntos.Controls.Add(this.lblNumeroPuntos);
            this.grbPuntos.Controls.Add(this.txtNumeroPuntos);
            this.grbPuntos.Controls.Add(this.lblValorPuntos);
            this.grbPuntos.Controls.Add(this.txtValorPuntos);
            this.grbPuntos.Location = new System.Drawing.Point(12, 11);
            this.grbPuntos.Margin = new System.Windows.Forms.Padding(4);
            this.grbPuntos.Name = "grbPuntos";
            this.grbPuntos.Padding = new System.Windows.Forms.Padding(4);
            this.grbPuntos.Size = new System.Drawing.Size(298, 244);
            this.grbPuntos.TabIndex = 0;
            this.grbPuntos.TabStop = false;
            this.grbPuntos.Text = "Configurar puntos";
            // 
            // chkAplicar
            // 
            this.chkAplicar.AutoSize = true;
            this.chkAplicar.Location = new System.Drawing.Point(121, 164);
            this.chkAplicar.Name = "chkAplicar";
            this.chkAplicar.Size = new System.Drawing.Size(69, 20);
            this.chkAplicar.TabIndex = 3;
            this.chkAplicar.Text = "Aplicar";
            this.chkAplicar.UseVisualStyleBackColor = true;
            // 
            // lblVentaMinima
            // 
            this.lblVentaMinima.AutoSize = true;
            this.lblVentaMinima.Location = new System.Drawing.Point(20, 35);
            this.lblVentaMinima.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVentaMinima.Name = "lblVentaMinima";
            this.lblVentaMinima.Size = new System.Drawing.Size(76, 16);
            this.lblVentaMinima.TabIndex = 4;
            this.lblVentaMinima.Text = "Valor venta";
            // 
            // txtVentaMinima
            // 
            this.txtVentaMinima.Location = new System.Drawing.Point(121, 32);
            this.txtVentaMinima.Margin = new System.Windows.Forms.Padding(4);
            this.txtVentaMinima.Name = "txtVentaMinima";
            this.txtVentaMinima.Size = new System.Drawing.Size(153, 22);
            this.txtVentaMinima.TabIndex = 0;
            this.txtVentaMinima.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVentaMinima_KeyPress);
            this.txtVentaMinima.Validating += new System.ComponentModel.CancelEventHandler(this.txtVentaMinima_Validating);
            // 
            // lblNumeroPuntos
            // 
            this.lblNumeroPuntos.AutoSize = true;
            this.lblNumeroPuntos.Location = new System.Drawing.Point(20, 79);
            this.lblNumeroPuntos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNumeroPuntos.Name = "lblNumeroPuntos";
            this.lblNumeroPuntos.Size = new System.Drawing.Size(49, 16);
            this.lblNumeroPuntos.TabIndex = 5;
            this.lblNumeroPuntos.Text = "Puntos";
            // 
            // txtNumeroPuntos
            // 
            this.txtNumeroPuntos.Location = new System.Drawing.Point(121, 76);
            this.txtNumeroPuntos.Margin = new System.Windows.Forms.Padding(4);
            this.txtNumeroPuntos.Name = "txtNumeroPuntos";
            this.txtNumeroPuntos.Size = new System.Drawing.Size(153, 22);
            this.txtNumeroPuntos.TabIndex = 1;
            this.txtNumeroPuntos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeroPuntos_KeyPress);
            this.txtNumeroPuntos.Validating += new System.ComponentModel.CancelEventHandler(this.txtNumeroPuntos_Validating);
            // 
            // lblValorPuntos
            // 
            this.lblValorPuntos.AutoSize = true;
            this.lblValorPuntos.Location = new System.Drawing.Point(20, 123);
            this.lblValorPuntos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblValorPuntos.Name = "lblValorPuntos";
            this.lblValorPuntos.Size = new System.Drawing.Size(83, 16);
            this.lblValorPuntos.TabIndex = 6;
            this.lblValorPuntos.Text = "Valor puntos";
            // 
            // txtValorPuntos
            // 
            this.txtValorPuntos.Location = new System.Drawing.Point(121, 120);
            this.txtValorPuntos.Margin = new System.Windows.Forms.Padding(4);
            this.txtValorPuntos.Name = "txtValorPuntos";
            this.txtValorPuntos.Size = new System.Drawing.Size(153, 22);
            this.txtValorPuntos.TabIndex = 2;
            this.txtValorPuntos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValorPuntos_KeyPress);
            this.txtValorPuntos.Validating += new System.ComponentModel.CancelEventHandler(this.txtValorPuntos_Validating);
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnOk.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.Image")));
            this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOk.Location = new System.Drawing.Point(86, 202);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(83, 25);
            this.btnOk.TabIndex = 9;
            this.btnOk.Text = "Aceptar";
            this.btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.No;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(186, 202);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 25);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmPuntos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(327, 267);
            this.Controls.Add(this.grbPuntos);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPuntos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Puntos";
            this.Load += new System.EventHandler(this.frmPuntos_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPuntos_KeyDown);
            this.grbPuntos.ResumeLayout(false);
            this.grbPuntos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbPuntos;
        private System.Windows.Forms.Label lblNumeroPuntos;
        private System.Windows.Forms.Label lblValorPuntos;
        private System.Windows.Forms.Label lblVentaMinima;
        private System.Windows.Forms.TextBox txtValorPuntos;
        private System.Windows.Forms.TextBox txtNumeroPuntos;
        private System.Windows.Forms.TextBox txtVentaMinima;
        private System.Windows.Forms.CheckBox chkAplicar;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}