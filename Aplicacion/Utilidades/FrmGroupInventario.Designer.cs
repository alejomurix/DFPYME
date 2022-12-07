namespace Aplicacion.Utilidades
{
    partial class FrmGroupInventario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGroupInventario));
            this.txtDbOrg = new System.Windows.Forms.TextBox();
            this.txtDb1 = new System.Windows.Forms.TextBox();
            this.txtDb2 = new System.Windows.Forms.TextBox();
            this.btnAgrupar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtFecha = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtDbOrg
            // 
            this.txtDbOrg.Location = new System.Drawing.Point(173, 19);
            this.txtDbOrg.Name = "txtDbOrg";
            this.txtDbOrg.Size = new System.Drawing.Size(206, 20);
            this.txtDbOrg.TabIndex = 0;
            // 
            // txtDb1
            // 
            this.txtDb1.Location = new System.Drawing.Point(173, 50);
            this.txtDb1.Name = "txtDb1";
            this.txtDb1.Size = new System.Drawing.Size(206, 20);
            this.txtDb1.TabIndex = 1;
            // 
            // txtDb2
            // 
            this.txtDb2.Location = new System.Drawing.Point(173, 81);
            this.txtDb2.Name = "txtDb2";
            this.txtDb2.Size = new System.Drawing.Size(206, 20);
            this.txtDb2.TabIndex = 2;
            // 
            // btnAgrupar
            // 
            this.btnAgrupar.Location = new System.Drawing.Point(173, 142);
            this.btnAgrupar.Name = "btnAgrupar";
            this.btnAgrupar.Size = new System.Drawing.Size(75, 23);
            this.btnAgrupar.TabIndex = 4;
            this.btnAgrupar.Text = "Agrupar";
            this.btnAgrupar.UseVisualStyleBackColor = true;
            this.btnAgrupar.Click += new System.EventHandler(this.btnAgrupar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtFecha);
            this.groupBox1.Controls.Add(this.txtDbOrg);
            this.groupBox1.Controls.Add(this.btnAgrupar);
            this.groupBox1.Controls.Add(this.txtDb1);
            this.groupBox1.Controls.Add(this.txtDb2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(402, 184);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // dtFecha
            // 
            this.dtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFecha.Location = new System.Drawing.Point(173, 112);
            this.dtFecha.Name = "dtFecha";
            this.dtFecha.Size = new System.Drawing.Size(121, 20);
            this.dtFecha.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Base de datos original";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Primera base de datos 1a";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Fecha inicio inventario";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Segunda ase de datos 2da";
            // 
            // FrmGroupInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(430, 212);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmGroupInventario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agrupación de inventario";
            this.Load += new System.EventHandler(this.FrmGroupInventario_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtDbOrg;
        private System.Windows.Forms.TextBox txtDb1;
        private System.Windows.Forms.TextBox txtDb2;
        private System.Windows.Forms.Button btnAgrupar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtFecha;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}