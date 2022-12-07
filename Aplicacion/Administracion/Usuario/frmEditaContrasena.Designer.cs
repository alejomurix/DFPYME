namespace Aplicacion.Administracion.Usuario
{
    partial class frmEditaContrasena
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditaContrasena));
            this.gbxContrasena = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.txtConfirmarContrasenia = new System.Windows.Forms.TextBox();
            this.txtNuevaContrasena = new System.Windows.Forms.TextBox();
            this.txtContrasenaActual = new System.Windows.Forms.TextBox();
            this.lblNuebaContrasenia = new System.Windows.Forms.Label();
            this.lblContrasenaNueva = new System.Windows.Forms.Label();
            this.lblcontrasenaBieja = new System.Windows.Forms.Label();
            this.gbxContrasena.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxContrasena
            // 
            this.gbxContrasena.Controls.Add(this.lblcontrasenaBieja);
            this.gbxContrasena.Controls.Add(this.txtContrasenaActual);
            this.gbxContrasena.Controls.Add(this.lblContrasenaNueva);
            this.gbxContrasena.Controls.Add(this.txtNuevaContrasena);
            this.gbxContrasena.Controls.Add(this.lblNuebaContrasenia);
            this.gbxContrasena.Controls.Add(this.txtConfirmarContrasenia);
            this.gbxContrasena.Controls.Add(this.btnOk);
            this.gbxContrasena.Controls.Add(this.btnCancel);
            this.gbxContrasena.Location = new System.Drawing.Point(13, 13);
            this.gbxContrasena.Margin = new System.Windows.Forms.Padding(4);
            this.gbxContrasena.Name = "gbxContrasena";
            this.gbxContrasena.Padding = new System.Windows.Forms.Padding(4);
            this.gbxContrasena.Size = new System.Drawing.Size(392, 191);
            this.gbxContrasena.TabIndex = 0;
            this.gbxContrasena.TabStop = false;
            this.gbxContrasena.Text = "Contraseña";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(284, 156);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(162, 156);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "Guardar";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // txtConfirmarContrasenia
            // 
            this.txtConfirmarContrasenia.Location = new System.Drawing.Point(162, 117);
            this.txtConfirmarContrasenia.Name = "txtConfirmarContrasenia";
            this.txtConfirmarContrasenia.Size = new System.Drawing.Size(197, 22);
            this.txtConfirmarContrasenia.TabIndex = 2;
            this.txtConfirmarContrasenia.UseSystemPasswordChar = true;
            this.txtConfirmarContrasenia.Validating += new System.ComponentModel.CancelEventHandler(this.txtNuevaContrasenia_Validating);
            // 
            // txtNuevaContrasena
            // 
            this.txtNuevaContrasena.Location = new System.Drawing.Point(162, 74);
            this.txtNuevaContrasena.Name = "txtNuevaContrasena";
            this.txtNuevaContrasena.Size = new System.Drawing.Size(197, 22);
            this.txtNuevaContrasena.TabIndex = 1;
            this.txtNuevaContrasena.UseSystemPasswordChar = true;
            this.txtNuevaContrasena.Validating += new System.ComponentModel.CancelEventHandler(this.txtNuevaContraseña_Validating);
            // 
            // txtContrasenaActual
            // 
            this.txtContrasenaActual.Location = new System.Drawing.Point(162, 33);
            this.txtContrasenaActual.Name = "txtContrasenaActual";
            this.txtContrasenaActual.Size = new System.Drawing.Size(197, 22);
            this.txtContrasenaActual.TabIndex = 0;
            this.txtContrasenaActual.UseSystemPasswordChar = true;
            this.txtContrasenaActual.Validating += new System.ComponentModel.CancelEventHandler(this.txtContrasenaActual_Validating);
            // 
            // lblNuebaContrasenia
            // 
            this.lblNuebaContrasenia.AutoSize = true;
            this.lblNuebaContrasenia.Location = new System.Drawing.Point(8, 120);
            this.lblNuebaContrasenia.Name = "lblNuebaContrasenia";
            this.lblNuebaContrasenia.Size = new System.Drawing.Size(135, 16);
            this.lblNuebaContrasenia.TabIndex = 7;
            this.lblNuebaContrasenia.Text = "Confirmar contrasena";
            // 
            // lblContrasenaNueva
            // 
            this.lblContrasenaNueva.AutoSize = true;
            this.lblContrasenaNueva.Location = new System.Drawing.Point(8, 77);
            this.lblContrasenaNueva.Name = "lblContrasenaNueva";
            this.lblContrasenaNueva.Size = new System.Drawing.Size(118, 16);
            this.lblContrasenaNueva.TabIndex = 6;
            this.lblContrasenaNueva.Text = "Nueva contraseña";
            // 
            // lblcontrasenaBieja
            // 
            this.lblcontrasenaBieja.AutoSize = true;
            this.lblcontrasenaBieja.Location = new System.Drawing.Point(8, 36);
            this.lblcontrasenaBieja.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblcontrasenaBieja.Name = "lblcontrasenaBieja";
            this.lblcontrasenaBieja.Size = new System.Drawing.Size(116, 16);
            this.lblcontrasenaBieja.TabIndex = 5;
            this.lblcontrasenaBieja.Text = "Contraseña actual";
            // 
            // frmEditaContrasena
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 213);
            this.Controls.Add(this.gbxContrasena);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEditaContrasena";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EditaContrasena";
            this.Load += new System.EventHandler(this.frmEditaContrasena_Load);
            this.gbxContrasena.ResumeLayout(false);
            this.gbxContrasena.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxContrasena;
        private System.Windows.Forms.Label lblcontrasenaBieja;
        private System.Windows.Forms.TextBox txtConfirmarContrasenia;
        private System.Windows.Forms.TextBox txtNuevaContrasena;
        private System.Windows.Forms.TextBox txtContrasenaActual;
        private System.Windows.Forms.Label lblNuebaContrasenia;
        private System.Windows.Forms.Label lblContrasenaNueva;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
    }
}