namespace Aplicacion.Configuracion.Conexion
{
    partial class FrmConexion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConexion));
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.btnGuardar = new System.Windows.Forms.ToolStripButton();
            this.tsSalir = new System.Windows.Forms.ToolStripButton();
            this.gbDatosConexion = new System.Windows.Forms.GroupBox();
            this.chkMostrarPassword = new System.Windows.Forms.CheckBox();
            this.btnTestConexion = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtBaseDatos = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblBaseDatos = new System.Windows.Forms.Label();
            this.txtServidor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tsMenu.SuspendLayout();
            this.gbDatosConexion.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMenu
            // 
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnGuardar,
            this.tsSalir});
            this.tsMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(421, 25);
            this.tsMenu.TabIndex = 0;
            this.tsMenu.Text = "toolStrip1";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(76, 22);
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // tsSalir
            // 
            this.tsSalir.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsSalir.Image = ((System.Drawing.Image)(resources.GetObject("tsSalir.Image")));
            this.tsSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsSalir.Name = "tsSalir";
            this.tsSalir.Size = new System.Drawing.Size(53, 22);
            this.tsSalir.Text = "Salir";
            this.tsSalir.Click += new System.EventHandler(this.tsSalir_Click);
            // 
            // gbDatosConexion
            // 
            this.gbDatosConexion.Controls.Add(this.txtServidor);
            this.gbDatosConexion.Controls.Add(this.label1);
            this.gbDatosConexion.Controls.Add(this.chkMostrarPassword);
            this.gbDatosConexion.Controls.Add(this.btnTestConexion);
            this.gbDatosConexion.Controls.Add(this.txtPassword);
            this.gbDatosConexion.Controls.Add(this.txtBaseDatos);
            this.gbDatosConexion.Controls.Add(this.lblPassword);
            this.gbDatosConexion.Controls.Add(this.lblBaseDatos);
            this.gbDatosConexion.Location = new System.Drawing.Point(12, 39);
            this.gbDatosConexion.Name = "gbDatosConexion";
            this.gbDatosConexion.Size = new System.Drawing.Size(397, 183);
            this.gbDatosConexion.TabIndex = 1;
            this.gbDatosConexion.TabStop = false;
            this.gbDatosConexion.Text = "Datos de Conexión";
            // 
            // chkMostrarPassword
            // 
            this.chkMostrarPassword.AutoSize = true;
            this.chkMostrarPassword.Location = new System.Drawing.Point(24, 139);
            this.chkMostrarPassword.Name = "chkMostrarPassword";
            this.chkMostrarPassword.Size = new System.Drawing.Size(144, 20);
            this.chkMostrarPassword.TabIndex = 6;
            this.chkMostrarPassword.Text = "Mostrar Contraseña";
            this.chkMostrarPassword.UseVisualStyleBackColor = true;
            this.chkMostrarPassword.Click += new System.EventHandler(this.chkMostrarPassword_Click);
            // 
            // btnTestConexion
            // 
            this.btnTestConexion.Location = new System.Drawing.Point(250, 139);
            this.btnTestConexion.Name = "btnTestConexion";
            this.btnTestConexion.Size = new System.Drawing.Size(120, 25);
            this.btnTestConexion.TabIndex = 5;
            this.btnTestConexion.Text = "Test Conexión";
            this.btnTestConexion.UseVisualStyleBackColor = true;
            this.btnTestConexion.Click += new System.EventHandler(this.btnTestConexion_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(136, 97);
            this.txtPassword.MaxLength = 20;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(234, 22);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPassword_KeyPress);
            this.txtPassword.Validating += new System.ComponentModel.CancelEventHandler(this.txtPassword_Validating);
            // 
            // txtBaseDatos
            // 
            this.txtBaseDatos.Location = new System.Drawing.Point(136, 60);
            this.txtBaseDatos.MaxLength = 20;
            this.txtBaseDatos.Name = "txtBaseDatos";
            this.txtBaseDatos.Size = new System.Drawing.Size(234, 22);
            this.txtBaseDatos.TabIndex = 2;
            this.txtBaseDatos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBaseDatos_KeyPress);
            this.txtBaseDatos.Validating += new System.ComponentModel.CancelEventHandler(this.txtBaseDatos_Validating);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(21, 100);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(77, 16);
            this.lblPassword.TabIndex = 1;
            this.lblPassword.Text = "Contraseña";
            // 
            // lblBaseDatos
            // 
            this.lblBaseDatos.AutoSize = true;
            this.lblBaseDatos.Location = new System.Drawing.Point(21, 60);
            this.lblBaseDatos.Name = "lblBaseDatos";
            this.lblBaseDatos.Size = new System.Drawing.Size(98, 16);
            this.lblBaseDatos.TabIndex = 0;
            this.lblBaseDatos.Text = "Base de Datos";
            // 
            // txtServidor
            // 
            this.txtServidor.Location = new System.Drawing.Point(136, 24);
            this.txtServidor.MaxLength = 20;
            this.txtServidor.Name = "txtServidor";
            this.txtServidor.Size = new System.Drawing.Size(234, 22);
            this.txtServidor.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Servidor";
            // 
            // FrmConexion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(421, 232);
            this.Controls.Add(this.gbDatosConexion);
            this.Controls.Add(this.tsMenu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmConexion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Conexión a Base de Datos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmConexion_FormClosing);
            this.Load += new System.EventHandler(this.FrmConexion_Load);
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.gbDatosConexion.ResumeLayout(false);
            this.gbDatosConexion.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.GroupBox gbDatosConexion;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtBaseDatos;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblBaseDatos;
        private System.Windows.Forms.ToolStripButton btnGuardar;
        private System.Windows.Forms.Button btnTestConexion;
        private System.Windows.Forms.CheckBox chkMostrarPassword;
        private System.Windows.Forms.ToolStripButton tsSalir;
        private System.Windows.Forms.TextBox txtServidor;
        private System.Windows.Forms.Label label1;
    }
}