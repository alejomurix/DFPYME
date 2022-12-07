namespace Aplicacion.Administracion.Descuentos
{
    partial class FrmDescuento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDescuento));
            this.gbDescuento = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtConcepto = new System.Windows.Forms.TextBox();
            this.txtCuenta = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtPorcejante = new System.Windows.Forms.TextBox();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.rbtnAplicaPorcentaje = new System.Windows.Forms.RadioButton();
            this.rbtnAplicaValor = new System.Windows.Forms.RadioButton();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.gbDescuento.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbDescuento
            // 
            this.gbDescuento.Controls.Add(this.label5);
            this.gbDescuento.Controls.Add(this.label4);
            this.gbDescuento.Controls.Add(this.label3);
            this.gbDescuento.Controls.Add(this.label2);
            this.gbDescuento.Controls.Add(this.label1);
            this.gbDescuento.Controls.Add(this.txtCodigo);
            this.gbDescuento.Controls.Add(this.txtConcepto);
            this.gbDescuento.Controls.Add(this.txtCuenta);
            this.gbDescuento.Controls.Add(this.btnBuscar);
            this.gbDescuento.Controls.Add(this.txtPorcejante);
            this.gbDescuento.Controls.Add(this.txtValor);
            this.gbDescuento.Controls.Add(this.rbtnAplicaPorcentaje);
            this.gbDescuento.Controls.Add(this.rbtnAplicaValor);
            this.gbDescuento.Controls.Add(this.btnAceptar);
            this.gbDescuento.Controls.Add(this.btnCancelar);
            this.gbDescuento.Location = new System.Drawing.Point(13, 13);
            this.gbDescuento.Name = "gbDescuento";
            this.gbDescuento.Size = new System.Drawing.Size(440, 323);
            this.gbDescuento.TabIndex = 0;
            this.gbDescuento.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "Código";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "Concepto";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Cuenta";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Porcentaje";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 194);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Valor";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(135, 34);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(100, 22);
            this.txtCodigo.TabIndex = 0;
            this.txtCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigo_KeyPress);
            this.txtCodigo.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodigo_Validating);
            // 
            // txtConcepto
            // 
            this.txtConcepto.Location = new System.Drawing.Point(133, 71);
            this.txtConcepto.Name = "txtConcepto";
            this.txtConcepto.Size = new System.Drawing.Size(288, 22);
            this.txtConcepto.TabIndex = 1;
            this.txtConcepto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtConcepto_KeyPress);
            this.txtConcepto.Validating += new System.ComponentModel.CancelEventHandler(this.txtConcepto_Validating);
            // 
            // txtCuenta
            // 
            this.txtCuenta.Location = new System.Drawing.Point(133, 108);
            this.txtCuenta.Name = "txtCuenta";
            this.txtCuenta.ReadOnly = true;
            this.txtCuenta.Size = new System.Drawing.Size(100, 22);
            this.txtCuenta.TabIndex = 2;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.btnBuscar.Location = new System.Drawing.Point(237, 109);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(24, 20);
            this.btnBuscar.TabIndex = 3;
            this.btnBuscar.Text = "...";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtPorcejante
            // 
            this.txtPorcejante.Location = new System.Drawing.Point(133, 146);
            this.txtPorcejante.Name = "txtPorcejante";
            this.txtPorcejante.Size = new System.Drawing.Size(100, 22);
            this.txtPorcejante.TabIndex = 4;
            this.txtPorcejante.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPorcejante_KeyPress);
            this.txtPorcejante.Validating += new System.ComponentModel.CancelEventHandler(this.txtPorcejante_Validating);
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(133, 188);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(100, 22);
            this.txtValor.TabIndex = 5;
            this.txtValor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValor_KeyPress);
            this.txtValor.Validating += new System.ComponentModel.CancelEventHandler(this.txtValor_Validating);
            // 
            // rbtnAplicaPorcentaje
            // 
            this.rbtnAplicaPorcentaje.AutoSize = true;
            this.rbtnAplicaPorcentaje.Location = new System.Drawing.Point(133, 226);
            this.rbtnAplicaPorcentaje.Name = "rbtnAplicaPorcentaje";
            this.rbtnAplicaPorcentaje.Size = new System.Drawing.Size(91, 20);
            this.rbtnAplicaPorcentaje.TabIndex = 6;
            this.rbtnAplicaPorcentaje.Text = "Porcentaje";
            this.rbtnAplicaPorcentaje.UseVisualStyleBackColor = true;
            // 
            // rbtnAplicaValor
            // 
            this.rbtnAplicaValor.AutoSize = true;
            this.rbtnAplicaValor.Checked = true;
            this.rbtnAplicaValor.Location = new System.Drawing.Point(266, 226);
            this.rbtnAplicaValor.Name = "rbtnAplicaValor";
            this.rbtnAplicaValor.Size = new System.Drawing.Size(58, 20);
            this.rbtnAplicaValor.TabIndex = 7;
            this.rbtnAplicaValor.TabStop = true;
            this.rbtnAplicaValor.Text = "Valor";
            this.rbtnAplicaValor.UseVisualStyleBackColor = true;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.Image")));
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptar.Location = new System.Drawing.Point(140, 275);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(89, 24);
            this.btnAceptar.TabIndex = 8;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(235, 275);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(89, 24);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // FrmDescuento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(469, 356);
            this.Controls.Add(this.gbDescuento);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDescuento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nuevo descuento";
            this.Load += new System.EventHandler(this.FrmDescuento_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmDescuento_KeyDown);
            this.gbDescuento.ResumeLayout(false);
            this.gbDescuento.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDescuento;
        private System.Windows.Forms.TextBox txtPorcejante;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.RadioButton rbtnAplicaPorcentaje;
        private System.Windows.Forms.RadioButton rbtnAplicaValor;
        private System.Windows.Forms.TextBox txtCuenta;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.TextBox txtConcepto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
    }
}