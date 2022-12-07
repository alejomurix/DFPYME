namespace Aplicacion.Compras.Proveedor.ContactoProveedor
{
    partial class frmContactoProveedor
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

        public System.Windows.Forms.Button BtnExtAceptar
        {
            set { this.btnExtAceptar = value; }
            get { return this.btnExtAceptar; }
        }

        public System.Windows.Forms.Button BtnExtCancelar
        {
            set { this.btnExtCancelar = value; }
            get { return this.btnExtCancelar; }
        }

        public System.Windows.Forms.ToolStrip TsMenuContato
        {
            set { this.tsMenuContacto = value; }
            get { return this.tsMenuContacto; }
        }

        public System.Windows.Forms.TextBox TxtCedula
        {
            set { this.txtCedula = value; }
            get { return this.txtCedula; }
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmContactoProveedor));
            this.tpIngresarContacto = new System.Windows.Forms.TabPage();
            this.tsMenuContacto = new System.Windows.Forms.ToolStrip();
            this.tsbtnGuardarContacto = new System.Windows.Forms.ToolStripButton();
            this.gbDatosContacto = new System.Windows.Forms.GroupBox();
            this.panelEditarEstado = new System.Windows.Forms.Panel();
            this.rbtnBaja = new System.Windows.Forms.RadioButton();
            this.rbtnAlta = new System.Windows.Forms.RadioButton();
            this.txtEditarEstado = new System.Windows.Forms.TextBox();
            this.lblEditarEstado = new System.Windows.Forms.Label();
            this.lblCedula = new System.Windows.Forms.Label();
            this.txtCedula = new System.Windows.Forms.TextBox();
            this.lblNombres = new System.Windows.Forms.Label();
            this.txtNombres = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.lblCelular = new System.Windows.Forms.Label();
            this.txtCelular = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.btnExtAceptar = new System.Windows.Forms.Button();
            this.btnExtCancelar = new System.Windows.Forms.Button();
            this.tbContactoProveedor = new System.Windows.Forms.TabControl();
            this.tpIngresarContacto.SuspendLayout();
            this.tsMenuContacto.SuspendLayout();
            this.gbDatosContacto.SuspendLayout();
            this.panelEditarEstado.SuspendLayout();
            this.tbContactoProveedor.SuspendLayout();
            this.SuspendLayout();
            // 
            // tpIngresarContacto
            // 
            this.tpIngresarContacto.Controls.Add(this.tsMenuContacto);
            this.tpIngresarContacto.Controls.Add(this.gbDatosContacto);
            this.tpIngresarContacto.Location = new System.Drawing.Point(4, 25);
            this.tpIngresarContacto.Name = "tpIngresarContacto";
            this.tpIngresarContacto.Padding = new System.Windows.Forms.Padding(3);
            this.tpIngresarContacto.Size = new System.Drawing.Size(516, 414);
            this.tpIngresarContacto.TabIndex = 0;
            this.tpIngresarContacto.Text = "Ingresar Contacto";
            this.tpIngresarContacto.UseVisualStyleBackColor = true;
            // 
            // tsMenuContacto
            // 
            this.tsMenuContacto.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnGuardarContacto});
            this.tsMenuContacto.Location = new System.Drawing.Point(3, 3);
            this.tsMenuContacto.Name = "tsMenuContacto";
            this.tsMenuContacto.Size = new System.Drawing.Size(510, 25);
            this.tsMenuContacto.TabIndex = 0;
            this.tsMenuContacto.Text = "Menu Contacto";
            // 
            // tsbtnGuardarContacto
            // 
            this.tsbtnGuardarContacto.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnGuardarContacto.Image")));
            this.tsbtnGuardarContacto.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnGuardarContacto.Name = "tsbtnGuardarContacto";
            this.tsbtnGuardarContacto.Size = new System.Drawing.Size(69, 22);
            this.tsbtnGuardarContacto.Text = "Guardar";
            // 
            // gbDatosContacto
            // 
            this.gbDatosContacto.Controls.Add(this.panelEditarEstado);
            this.gbDatosContacto.Controls.Add(this.lblCedula);
            this.gbDatosContacto.Controls.Add(this.txtCedula);
            this.gbDatosContacto.Controls.Add(this.lblNombres);
            this.gbDatosContacto.Controls.Add(this.txtNombres);
            this.gbDatosContacto.Controls.Add(this.lblTelefono);
            this.gbDatosContacto.Controls.Add(this.txtTelefono);
            this.gbDatosContacto.Controls.Add(this.lblCelular);
            this.gbDatosContacto.Controls.Add(this.txtCelular);
            this.gbDatosContacto.Controls.Add(this.lblEmail);
            this.gbDatosContacto.Controls.Add(this.txtEmail);
            this.gbDatosContacto.Controls.Add(this.btnExtAceptar);
            this.gbDatosContacto.Controls.Add(this.btnExtCancelar);
            this.gbDatosContacto.Location = new System.Drawing.Point(13, 40);
            this.gbDatosContacto.Name = "gbDatosContacto";
            this.gbDatosContacto.Size = new System.Drawing.Size(482, 359);
            this.gbDatosContacto.TabIndex = 0;
            this.gbDatosContacto.TabStop = false;
            this.gbDatosContacto.Text = "Datos de Contacto";
            // 
            // panelEditarEstado
            // 
            this.panelEditarEstado.Controls.Add(this.rbtnBaja);
            this.panelEditarEstado.Controls.Add(this.rbtnAlta);
            this.panelEditarEstado.Controls.Add(this.txtEditarEstado);
            this.panelEditarEstado.Controls.Add(this.lblEditarEstado);
            this.panelEditarEstado.Location = new System.Drawing.Point(17, 253);
            this.panelEditarEstado.Name = "panelEditarEstado";
            this.panelEditarEstado.Size = new System.Drawing.Size(420, 37);
            this.panelEditarEstado.TabIndex = 7;
            this.panelEditarEstado.Visible = false;
            // 
            // rbtnBaja
            // 
            this.rbtnBaja.AutoSize = true;
            this.rbtnBaja.Location = new System.Drawing.Point(303, 6);
            this.rbtnBaja.Name = "rbtnBaja";
            this.rbtnBaja.Size = new System.Drawing.Size(98, 20);
            this.rbtnBaja.TabIndex = 3;
            this.rbtnBaja.TabStop = true;
            this.rbtnBaja.Text = "Dar de Baja";
            this.rbtnBaja.UseVisualStyleBackColor = true;
            // 
            // rbtnAlta
            // 
            this.rbtnAlta.AutoSize = true;
            this.rbtnAlta.Location = new System.Drawing.Point(203, 6);
            this.rbtnAlta.Name = "rbtnAlta";
            this.rbtnAlta.Size = new System.Drawing.Size(93, 20);
            this.rbtnAlta.TabIndex = 2;
            this.rbtnAlta.TabStop = true;
            this.rbtnAlta.Text = "Dar de Alta";
            this.rbtnAlta.UseVisualStyleBackColor = true;
            // 
            // txtEditarEstado
            // 
            this.txtEditarEstado.Location = new System.Drawing.Point(99, 5);
            this.txtEditarEstado.Name = "txtEditarEstado";
            this.txtEditarEstado.ReadOnly = true;
            this.txtEditarEstado.Size = new System.Drawing.Size(90, 22);
            this.txtEditarEstado.TabIndex = 1;
            // 
            // lblEditarEstado
            // 
            this.lblEditarEstado.AutoSize = true;
            this.lblEditarEstado.Location = new System.Drawing.Point(3, 5);
            this.lblEditarEstado.Name = "lblEditarEstado";
            this.lblEditarEstado.Size = new System.Drawing.Size(51, 16);
            this.lblEditarEstado.TabIndex = 0;
            this.lblEditarEstado.Text = "Estado";
            // 
            // lblCedula
            // 
            this.lblCedula.AutoSize = true;
            this.lblCedula.Location = new System.Drawing.Point(20, 38);
            this.lblCedula.Name = "lblCedula";
            this.lblCedula.Size = new System.Drawing.Size(51, 16);
            this.lblCedula.TabIndex = 0;
            this.lblCedula.Text = "Cedula";
            // 
            // txtCedula
            // 
            this.txtCedula.Location = new System.Drawing.Point(116, 35);
            this.txtCedula.MaxLength = 10;
            this.txtCedula.Name = "txtCedula";
            this.txtCedula.Size = new System.Drawing.Size(182, 22);
            this.txtCedula.TabIndex = 0;
            this.txtCedula.Validating += new System.ComponentModel.CancelEventHandler(this.txtCedula_Validating);
            // 
            // lblNombres
            // 
            this.lblNombres.AutoSize = true;
            this.lblNombres.Location = new System.Drawing.Point(20, 82);
            this.lblNombres.Name = "lblNombres";
            this.lblNombres.Size = new System.Drawing.Size(64, 16);
            this.lblNombres.TabIndex = 1;
            this.lblNombres.Text = "Nombres";
            // 
            // txtNombres
            // 
            this.txtNombres.Location = new System.Drawing.Point(116, 79);
            this.txtNombres.MaxLength = 80;
            this.txtNombres.Name = "txtNombres";
            this.txtNombres.Size = new System.Drawing.Size(182, 22);
            this.txtNombres.TabIndex = 1;
            this.txtNombres.Validating += new System.ComponentModel.CancelEventHandler(this.txtNombres_Validating);
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Location = new System.Drawing.Point(20, 128);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(62, 16);
            this.lblTelefono.TabIndex = 2;
            this.lblTelefono.Text = "Telefono";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(116, 125);
            this.txtTelefono.MaxLength = 15;
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(182, 22);
            this.txtTelefono.TabIndex = 2;
            this.txtTelefono.Validating += new System.ComponentModel.CancelEventHandler(this.txtTelefono_Validating);
            // 
            // lblCelular
            // 
            this.lblCelular.AutoSize = true;
            this.lblCelular.Location = new System.Drawing.Point(20, 175);
            this.lblCelular.Name = "lblCelular";
            this.lblCelular.Size = new System.Drawing.Size(50, 16);
            this.lblCelular.TabIndex = 3;
            this.lblCelular.Text = "Celular";
            // 
            // txtCelular
            // 
            this.txtCelular.Location = new System.Drawing.Point(116, 172);
            this.txtCelular.MaxLength = 15;
            this.txtCelular.Name = "txtCelular";
            this.txtCelular.Size = new System.Drawing.Size(182, 22);
            this.txtCelular.TabIndex = 3;
            this.txtCelular.Validating += new System.ComponentModel.CancelEventHandler(this.txtCelular_Validating);
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(20, 217);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(42, 16);
            this.lblEmail.TabIndex = 4;
            this.lblEmail.Text = "Email";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(116, 214);
            this.txtEmail.MaxLength = 80;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(182, 22);
            this.txtEmail.TabIndex = 4;
            this.txtEmail.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmail_Validating);
            // 
            // btnExtAceptar
            // 
            this.btnExtAceptar.Location = new System.Drawing.Point(41, 281);
            this.btnExtAceptar.Name = "btnExtAceptar";
            this.btnExtAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnExtAceptar.TabIndex = 5;
            this.btnExtAceptar.Text = "Aceptar";
            this.btnExtAceptar.UseVisualStyleBackColor = true;
            this.btnExtAceptar.Visible = false;
            this.btnExtAceptar.Click += new System.EventHandler(this.btnExtAceptar_Click);
            // 
            // btnExtCancelar
            // 
            this.btnExtCancelar.Location = new System.Drawing.Point(152, 281);
            this.btnExtCancelar.Name = "btnExtCancelar";
            this.btnExtCancelar.Size = new System.Drawing.Size(79, 23);
            this.btnExtCancelar.TabIndex = 6;
            this.btnExtCancelar.Text = "Cancelar";
            this.btnExtCancelar.UseVisualStyleBackColor = true;
            this.btnExtCancelar.Visible = false;
            this.btnExtCancelar.Click += new System.EventHandler(this.btnExtCancelar_Click);
            // 
            // tbContactoProveedor
            // 
            this.tbContactoProveedor.Controls.Add(this.tpIngresarContacto);
            this.tbContactoProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.tbContactoProveedor.Location = new System.Drawing.Point(1, 2);
            this.tbContactoProveedor.Name = "tbContactoProveedor";
            this.tbContactoProveedor.SelectedIndex = 0;
            this.tbContactoProveedor.Size = new System.Drawing.Size(524, 443);
            this.tbContactoProveedor.TabIndex = 0;
            // 
            // frmContactoProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 447);
            this.Controls.Add(this.tbContactoProveedor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmContactoProveedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Contacto de Proveedor";
            this.Load += new System.EventHandler(this.frmContactoProveedor_Load);
            this.tpIngresarContacto.ResumeLayout(false);
            this.tpIngresarContacto.PerformLayout();
            this.tsMenuContacto.ResumeLayout(false);
            this.tsMenuContacto.PerformLayout();
            this.gbDatosContacto.ResumeLayout(false);
            this.gbDatosContacto.PerformLayout();
            this.panelEditarEstado.ResumeLayout(false);
            this.panelEditarEstado.PerformLayout();
            this.tbContactoProveedor.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tpIngresarContacto;
        private System.Windows.Forms.ToolStrip tsMenuContacto;
        private System.Windows.Forms.ToolStripButton tsbtnGuardarContacto;
        private System.Windows.Forms.GroupBox gbDatosContacto;
        public System.Windows.Forms.Panel panelEditarEstado;
        public System.Windows.Forms.RadioButton rbtnBaja;
        public System.Windows.Forms.RadioButton rbtnAlta;
        public System.Windows.Forms.TextBox txtEditarEstado;
        private System.Windows.Forms.Label lblEditarEstado;
        private System.Windows.Forms.Label lblCedula;
        public System.Windows.Forms.TextBox txtCedula;
        private System.Windows.Forms.Label lblNombres;
        public System.Windows.Forms.TextBox txtNombres;
        private System.Windows.Forms.Label lblTelefono;
        public System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label lblCelular;
        public System.Windows.Forms.TextBox txtCelular;
        private System.Windows.Forms.Label lblEmail;
        public System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Button btnExtAceptar;
        private System.Windows.Forms.Button btnExtCancelar;
        private System.Windows.Forms.TabControl tbContactoProveedor;

    }
}