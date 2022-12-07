namespace Aplicacion.Compras.IngresarCompra
{
    partial class FrmActualizarCosto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmActualizarCosto));
            this.gbActualizar = new System.Windows.Forms.GroupBox();
            this.rbtnActual = new System.Windows.Forms.RadioButton();
            this.txtActual = new System.Windows.Forms.TextBox();
            this.rbtnUltimo = new System.Windows.Forms.RadioButton();
            this.txtUltimo = new System.Windows.Forms.TextBox();
            this.rbtnPromedio = new System.Windows.Forms.RadioButton();
            this.txtPromedio = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gbActualizar.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbActualizar
            // 
            this.gbActualizar.Controls.Add(this.rbtnActual);
            this.gbActualizar.Controls.Add(this.txtActual);
            this.gbActualizar.Controls.Add(this.rbtnUltimo);
            this.gbActualizar.Controls.Add(this.txtUltimo);
            this.gbActualizar.Controls.Add(this.rbtnPromedio);
            this.gbActualizar.Controls.Add(this.txtPromedio);
            this.gbActualizar.Controls.Add(this.btnOk);
            this.gbActualizar.Controls.Add(this.btnCancel);
            this.gbActualizar.Location = new System.Drawing.Point(12, 5);
            this.gbActualizar.Name = "gbActualizar";
            this.gbActualizar.Size = new System.Drawing.Size(315, 197);
            this.gbActualizar.TabIndex = 1;
            this.gbActualizar.TabStop = false;
            // 
            // rbtnActual
            // 
            this.rbtnActual.AutoSize = true;
            this.rbtnActual.Checked = true;
            this.rbtnActual.Location = new System.Drawing.Point(15, 29);
            this.rbtnActual.Name = "rbtnActual";
            this.rbtnActual.Size = new System.Drawing.Size(100, 20);
            this.rbtnActual.TabIndex = 10;
            this.rbtnActual.TabStop = true;
            this.rbtnActual.Text = "Costo actual";
            this.rbtnActual.UseVisualStyleBackColor = true;
            // 
            // txtActual
            // 
            this.txtActual.Location = new System.Drawing.Point(195, 27);
            this.txtActual.Name = "txtActual";
            this.txtActual.ReadOnly = true;
            this.txtActual.Size = new System.Drawing.Size(100, 22);
            this.txtActual.TabIndex = 14;
            this.txtActual.Text = "0";
            this.txtActual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // rbtnUltimo
            // 
            this.rbtnUltimo.AutoSize = true;
            this.rbtnUltimo.Location = new System.Drawing.Point(15, 64);
            this.rbtnUltimo.Name = "rbtnUltimo";
            this.rbtnUltimo.Size = new System.Drawing.Size(169, 20);
            this.rbtnUltimo.TabIndex = 8;
            this.rbtnUltimo.Text = "Costo del último registro";
            this.rbtnUltimo.UseVisualStyleBackColor = true;
            // 
            // txtUltimo
            // 
            this.txtUltimo.Location = new System.Drawing.Point(196, 63);
            this.txtUltimo.Name = "txtUltimo";
            this.txtUltimo.ReadOnly = true;
            this.txtUltimo.Size = new System.Drawing.Size(100, 22);
            this.txtUltimo.TabIndex = 13;
            this.txtUltimo.Text = "0";
            this.txtUltimo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // rbtnPromedio
            // 
            this.rbtnPromedio.AutoSize = true;
            this.rbtnPromedio.Location = new System.Drawing.Point(15, 104);
            this.rbtnPromedio.Name = "rbtnPromedio";
            this.rbtnPromedio.Size = new System.Drawing.Size(122, 20);
            this.rbtnPromedio.TabIndex = 11;
            this.rbtnPromedio.Text = "Costo promedio";
            this.rbtnPromedio.UseVisualStyleBackColor = true;
            // 
            // txtPromedio
            // 
            this.txtPromedio.Location = new System.Drawing.Point(195, 103);
            this.txtPromedio.Name = "txtPromedio";
            this.txtPromedio.ReadOnly = true;
            this.txtPromedio.Size = new System.Drawing.Size(100, 22);
            this.txtPromedio.TabIndex = 12;
            this.txtPromedio.Text = "0";
            this.txtPromedio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnOk.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.Image")));
            this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOk.Location = new System.Drawing.Point(107, 147);
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
            this.btnCancel.Location = new System.Drawing.Point(207, 147);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 25);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FrmActualizarCosto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(339, 214);
            this.Controls.Add(this.gbActualizar);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmActualizarCosto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Actualizar Costo";
            this.Load += new System.EventHandler(this.FrmActualizarCosto_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmActualizarCosto_KeyDown);
            this.gbActualizar.ResumeLayout(false);
            this.gbActualizar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbActualizar;
        public System.Windows.Forms.RadioButton rbtnActual;
        public System.Windows.Forms.RadioButton rbtnUltimo;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.RadioButton rbtnPromedio;
        public System.Windows.Forms.TextBox txtActual;
        public System.Windows.Forms.TextBox txtUltimo;
        public System.Windows.Forms.TextBox txtPromedio;
    }
}