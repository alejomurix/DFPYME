namespace Aplicacion.Compras.IngresarCompra
{
    partial class FrmValidaActualizar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmValidaActualizar));
            this.gbActualizar = new System.Windows.Forms.GroupBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.rbtnValor = new System.Windows.Forms.RadioButton();
            this.rbtnPorcentaje = new System.Windows.Forms.RadioButton();
            this.gbActualizar.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbActualizar
            // 
            this.gbActualizar.Controls.Add(this.rbtnPorcentaje);
            this.gbActualizar.Controls.Add(this.rbtnValor);
            this.gbActualizar.Controls.Add(this.btnOk);
            this.gbActualizar.Controls.Add(this.btnCancel);
            this.gbActualizar.Location = new System.Drawing.Point(9, 6);
            this.gbActualizar.Name = "gbActualizar";
            this.gbActualizar.Size = new System.Drawing.Size(272, 153);
            this.gbActualizar.TabIndex = 0;
            this.gbActualizar.TabStop = false;
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnOk.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.Image")));
            this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOk.Location = new System.Drawing.Point(71, 108);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(83, 25);
            this.btnOk.TabIndex = 5;
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
            this.btnCancel.Location = new System.Drawing.Point(171, 108);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 25);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // rbtnValor
            // 
            this.rbtnValor.AutoSize = true;
            this.rbtnValor.Location = new System.Drawing.Point(15, 64);
            this.rbtnValor.Name = "rbtnValor";
            this.rbtnValor.Size = new System.Drawing.Size(225, 20);
            this.rbtnValor.TabIndex = 8;
            this.rbtnValor.Text = "Aplica precio por valor ingresado";
            this.rbtnValor.UseVisualStyleBackColor = true;
            // 
            // rbtnPorcentaje
            // 
            this.rbtnPorcentaje.AutoSize = true;
            this.rbtnPorcentaje.Checked = true;
            this.rbtnPorcentaje.Location = new System.Drawing.Point(15, 29);
            this.rbtnPorcentaje.Name = "rbtnPorcentaje";
            this.rbtnPorcentaje.Size = new System.Drawing.Size(195, 20);
            this.rbtnPorcentaje.TabIndex = 10;
            this.rbtnPorcentaje.TabStop = true;
            this.rbtnPorcentaje.Text = "Aplica precio por porcentaje";
            this.rbtnPorcentaje.UseVisualStyleBackColor = true;
            // 
            // FrmValidaActualizar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(293, 170);
            this.Controls.Add(this.gbActualizar);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmValidaActualizar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Actualizar Precio";
            this.Load += new System.EventHandler(this.FrmValidaActualizar_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmValidaActualizar_KeyDown);
            this.gbActualizar.ResumeLayout(false);
            this.gbActualizar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbActualizar;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.RadioButton rbtnPorcentaje;
        public System.Windows.Forms.RadioButton rbtnValor;
    }
}