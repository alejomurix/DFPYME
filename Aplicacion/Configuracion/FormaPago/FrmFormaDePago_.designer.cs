namespace Aplicacion.Configuracion.FormaPago
{
    partial class FrmFormaDePago_
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox17 = new System.Windows.Forms.GroupBox();
            this.RInventarioMCarta = new System.Windows.Forms.RadioButton();
            this.RInventarioTirilla = new System.Windows.Forms.RadioButton();
            this.label21 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox17.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.groupBox17);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(631, 265);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(189, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "HABILITAR";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(278, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "NO HABILITAR";
            // 
            // groupBox17
            // 
            this.groupBox17.Controls.Add(this.RInventarioMCarta);
            this.groupBox17.Controls.Add(this.RInventarioTirilla);
            this.groupBox17.Controls.Add(this.label21);
            this.groupBox17.Location = new System.Drawing.Point(15, 66);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.Size = new System.Drawing.Size(349, 40);
            this.groupBox17.TabIndex = 7;
            this.groupBox17.TabStop = false;
            // 
            // RInventarioMCarta
            // 
            this.RInventarioMCarta.AutoSize = true;
            this.RInventarioMCarta.Location = new System.Drawing.Point(289, 17);
            this.RInventarioMCarta.Name = "RInventarioMCarta";
            this.RInventarioMCarta.Size = new System.Drawing.Size(14, 13);
            this.RInventarioMCarta.TabIndex = 5;
            this.RInventarioMCarta.TabStop = true;
            this.RInventarioMCarta.UseVisualStyleBackColor = true;
            // 
            // RInventarioTirilla
            // 
            this.RInventarioTirilla.AutoSize = true;
            this.RInventarioTirilla.Location = new System.Drawing.Point(203, 15);
            this.RInventarioTirilla.Name = "RInventarioTirilla";
            this.RInventarioTirilla.Size = new System.Drawing.Size(14, 13);
            this.RInventarioTirilla.TabIndex = 4;
            this.RInventarioTirilla.TabStop = true;
            this.RInventarioTirilla.UseVisualStyleBackColor = true;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(8, 15);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(148, 16);
            this.label21.TabIndex = 3;
            this.label21.Text = "Inventario de productos";
            // 
            // FrmFormaDePago_
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(662, 311);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmFormaDePago_";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Formas de pago";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox17.ResumeLayout(false);
            this.groupBox17.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox17;
        private System.Windows.Forms.RadioButton RInventarioMCarta;
        private System.Windows.Forms.RadioButton RInventarioTirilla;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;

    }
}