namespace Aplicacion.Ventas
{
    partial class Form2
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
            this.cbIvaEditar = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbIvaEditar
            // 
            this.cbIvaEditar.DisplayMember = "PorcentajeIva";
            this.cbIvaEditar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIvaEditar.FormattingEnabled = true;
            this.cbIvaEditar.Location = new System.Drawing.Point(13, 22);
            this.cbIvaEditar.Margin = new System.Windows.Forms.Padding(4);
            this.cbIvaEditar.Name = "cbIvaEditar";
            this.cbIvaEditar.Size = new System.Drawing.Size(124, 21);
            this.cbIvaEditar.TabIndex = 46;
            this.cbIvaEditar.ValueMember = "IdIva";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(156, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 47;
            this.button1.Text = "Ajustar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 77);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cbIvaEditar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ajuste de Iva";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbIvaEditar;
        private System.Windows.Forms.Button button1;
    }
}