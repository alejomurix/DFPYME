namespace Aplicacion.Ventas.Retiro
{
    partial class FrmRetiroDinero
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRetiroDinero));
            this.pDatos = new System.Windows.Forms.Panel();
            this.lblValor = new System.Windows.Forms.Label();
            this.lblPesos = new System.Windows.Forms.Label();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.lblConcepto = new System.Windows.Forms.Label();
            this.txtConcepto = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.cbNominacion = new System.Windows.Forms.ComboBox();
            this.lblNominacion = new System.Windows.Forms.Label();
            this.pDatos.SuspendLayout();
            this.SuspendLayout();
            // 
            // pDatos
            // 
            this.pDatos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pDatos.Controls.Add(this.lblValor);
            this.pDatos.Controls.Add(this.lblPesos);
            this.pDatos.Controls.Add(this.txtValor);
            this.pDatos.Controls.Add(this.lblNominacion);
            this.pDatos.Controls.Add(this.cbNominacion);
            this.pDatos.Controls.Add(this.lblConcepto);
            this.pDatos.Controls.Add(this.txtConcepto);
            this.pDatos.Controls.Add(this.btnAceptar);
            this.pDatos.Controls.Add(this.btnCancelar);
            this.pDatos.Location = new System.Drawing.Point(13, 12);
            this.pDatos.Name = "pDatos";
            this.pDatos.Size = new System.Drawing.Size(299, 188);
            this.pDatos.TabIndex = 0;
            // 
            // lblValor
            // 
            this.lblValor.AutoSize = true;
            this.lblValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.lblValor.Location = new System.Drawing.Point(10, 18);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(52, 22);
            this.lblValor.TabIndex = 4;
            this.lblValor.Text = "Valor";
            // 
            // lblPesos
            // 
            this.lblPesos.AutoSize = true;
            this.lblPesos.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.lblPesos.Location = new System.Drawing.Point(75, 18);
            this.lblPesos.Name = "lblPesos";
            this.lblPesos.Size = new System.Drawing.Size(20, 22);
            this.lblPesos.TabIndex = 5;
            this.lblPesos.Text = "$";
            // 
            // txtValor
            // 
            this.txtValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.txtValor.Location = new System.Drawing.Point(96, 15);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(183, 27);
            this.txtValor.TabIndex = 0;
            this.txtValor.Text = "0";
            this.txtValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtValor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValor_KeyPress);
            this.txtValor.Validating += new System.ComponentModel.CancelEventHandler(this.txtValor_Validating);
            // 
            // lblConcepto
            // 
            this.lblConcepto.AutoSize = true;
            this.lblConcepto.Location = new System.Drawing.Point(11, 91);
            this.lblConcepto.Name = "lblConcepto";
            this.lblConcepto.Size = new System.Drawing.Size(66, 16);
            this.lblConcepto.TabIndex = 6;
            this.lblConcepto.Text = "Concepto";
            // 
            // txtConcepto
            // 
            this.txtConcepto.Location = new System.Drawing.Point(96, 88);
            this.txtConcepto.Multiline = true;
            this.txtConcepto.Name = "txtConcepto";
            this.txtConcepto.Size = new System.Drawing.Size(183, 45);
            this.txtConcepto.TabIndex = 1;
            this.txtConcepto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtConcepto_KeyPress);
            this.txtConcepto.Validating += new System.ComponentModel.CancelEventHandler(this.txtConcepto_Validating);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.Image")));
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptar.Location = new System.Drawing.Point(96, 146);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(89, 24);
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(190, 146);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(89, 24);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // cbNominacion
            // 
            this.cbNominacion.DisplayMember = "Nombre";
            this.cbNominacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNominacion.FormattingEnabled = true;
            this.cbNominacion.Location = new System.Drawing.Point(96, 51);
            this.cbNominacion.Name = "cbNominacion";
            this.cbNominacion.Size = new System.Drawing.Size(183, 24);
            this.cbNominacion.TabIndex = 7;
            this.cbNominacion.ValueMember = "Id";
            this.cbNominacion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbNominacion_KeyPress);
            // 
            // lblNominacion
            // 
            this.lblNominacion.AutoSize = true;
            this.lblNominacion.Location = new System.Drawing.Point(11, 54);
            this.lblNominacion.Name = "lblNominacion";
            this.lblNominacion.Size = new System.Drawing.Size(80, 16);
            this.lblNominacion.TabIndex = 8;
            this.lblNominacion.Text = "Nominación";
            // 
            // FrmRetiroDinero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(324, 212);
            this.Controls.Add(this.pDatos);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmRetiroDinero";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Retiro de Dinero";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmRetiroDinero_FormClosing);
            this.Load += new System.EventHandler(this.FrmRetiroDinero_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmRetiroDinero_KeyDown);
            this.pDatos.ResumeLayout(false);
            this.pDatos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pDatos;
        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.Label lblPesos;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtConcepto;
        private System.Windows.Forms.Label lblConcepto;
        private System.Windows.Forms.ComboBox cbNominacion;
        private System.Windows.Forms.Label lblNominacion;
    }
}