namespace Aplicacion.Configuracion.Bancos
{
    partial class FrmBancos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBancos));
            this.gbDatosCuenta = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSucursal = new System.Windows.Forms.TextBox();
            this.lblTipoCuenta = new System.Windows.Forms.Label();
            this.cbTipoCuenta = new System.Windows.Forms.ComboBox();
            this.lblNumeroCuenta = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.lblTitularCuenta = new System.Windows.Forms.Label();
            this.txtTitular = new System.Windows.Forms.TextBox();
            this.lblBanco = new System.Windows.Forms.Label();
            this.txtBanco = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCuentaAuxiliar = new System.Windows.Forms.TextBox();
            this.txtNombreAuxiliar = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCuenta = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.tsbtnGuardar = new System.Windows.Forms.ToolStripButton();
            this.tsbtnSalir = new System.Windows.Forms.ToolStripButton();
            this.gbDatosCuenta.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tsMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbDatosCuenta
            // 
            this.gbDatosCuenta.Controls.Add(this.label2);
            this.gbDatosCuenta.Controls.Add(this.txtDireccion);
            this.gbDatosCuenta.Controls.Add(this.label1);
            this.gbDatosCuenta.Controls.Add(this.txtSucursal);
            this.gbDatosCuenta.Controls.Add(this.lblTipoCuenta);
            this.gbDatosCuenta.Controls.Add(this.cbTipoCuenta);
            this.gbDatosCuenta.Controls.Add(this.lblNumeroCuenta);
            this.gbDatosCuenta.Controls.Add(this.txtNumero);
            this.gbDatosCuenta.Controls.Add(this.lblTitularCuenta);
            this.gbDatosCuenta.Controls.Add(this.txtTitular);
            this.gbDatosCuenta.Controls.Add(this.lblBanco);
            this.gbDatosCuenta.Controls.Add(this.txtBanco);
            this.gbDatosCuenta.Location = new System.Drawing.Point(12, 48);
            this.gbDatosCuenta.Name = "gbDatosCuenta";
            this.gbDatosCuenta.Size = new System.Drawing.Size(648, 169);
            this.gbDatosCuenta.TabIndex = 1;
            this.gbDatosCuenta.TabStop = false;
            this.gbDatosCuenta.Text = "Datos de Cuenta Bancaria";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.label2.Location = new System.Drawing.Point(318, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Dirección";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(435, 122);
            this.txtDireccion.MaxLength = 50;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(185, 22);
            this.txtDireccion.TabIndex = 9;
            this.txtDireccion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDireccion_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.label1.Location = new System.Drawing.Point(15, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Sucursal";
            // 
            // txtSucursal
            // 
            this.txtSucursal.Location = new System.Drawing.Point(111, 122);
            this.txtSucursal.MaxLength = 50;
            this.txtSucursal.Name = "txtSucursal";
            this.txtSucursal.Size = new System.Drawing.Size(185, 22);
            this.txtSucursal.TabIndex = 7;
            this.txtSucursal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSucursal_KeyPress);
            // 
            // lblTipoCuenta
            // 
            this.lblTipoCuenta.AutoSize = true;
            this.lblTipoCuenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblTipoCuenta.Location = new System.Drawing.Point(15, 37);
            this.lblTipoCuenta.Name = "lblTipoCuenta";
            this.lblTipoCuenta.Size = new System.Drawing.Size(81, 16);
            this.lblTipoCuenta.TabIndex = 0;
            this.lblTipoCuenta.Text = "Tipo Cuenta";
            // 
            // cbTipoCuenta
            // 
            this.cbTipoCuenta.DisplayMember = "descripciontipo_cuenta";
            this.cbTipoCuenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoCuenta.FormattingEnabled = true;
            this.cbTipoCuenta.Location = new System.Drawing.Point(112, 34);
            this.cbTipoCuenta.Name = "cbTipoCuenta";
            this.cbTipoCuenta.Size = new System.Drawing.Size(121, 24);
            this.cbTipoCuenta.TabIndex = 5;
            this.cbTipoCuenta.ValueMember = "idtipo_cuenta";
            this.cbTipoCuenta.SelectionChangeCommitted += new System.EventHandler(this.cbTipoCuenta_SelectionChangeCommitted);
            // 
            // lblNumeroCuenta
            // 
            this.lblNumeroCuenta.AutoSize = true;
            this.lblNumeroCuenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblNumeroCuenta.Location = new System.Drawing.Point(318, 34);
            this.lblNumeroCuenta.Name = "lblNumeroCuenta";
            this.lblNumeroCuenta.Size = new System.Drawing.Size(56, 16);
            this.lblNumeroCuenta.TabIndex = 2;
            this.lblNumeroCuenta.Text = "Número";
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(435, 31);
            this.txtNumero.MaxLength = 15;
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(185, 22);
            this.txtNumero.TabIndex = 0;
            this.txtNumero.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumero_KeyPress);
            this.txtNumero.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNumero_KeyUp);
            // 
            // lblTitularCuenta
            // 
            this.lblTitularCuenta.AutoSize = true;
            this.lblTitularCuenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblTitularCuenta.Location = new System.Drawing.Point(15, 83);
            this.lblTitularCuenta.Name = "lblTitularCuenta";
            this.lblTitularCuenta.Size = new System.Drawing.Size(45, 16);
            this.lblTitularCuenta.TabIndex = 4;
            this.lblTitularCuenta.Text = "Titular";
            // 
            // txtTitular
            // 
            this.txtTitular.Location = new System.Drawing.Point(111, 78);
            this.txtTitular.MaxLength = 80;
            this.txtTitular.Name = "txtTitular";
            this.txtTitular.Size = new System.Drawing.Size(185, 22);
            this.txtTitular.TabIndex = 1;
            this.txtTitular.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTitular_KeyPress);
            // 
            // lblBanco
            // 
            this.lblBanco.AutoSize = true;
            this.lblBanco.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblBanco.Location = new System.Drawing.Point(318, 79);
            this.lblBanco.Name = "lblBanco";
            this.lblBanco.Size = new System.Drawing.Size(111, 16);
            this.lblBanco.TabIndex = 6;
            this.lblBanco.Text = "Entidad Bancaria";
            // 
            // txtBanco
            // 
            this.txtBanco.Location = new System.Drawing.Point(435, 76);
            this.txtBanco.MaxLength = 50;
            this.txtBanco.Name = "txtBanco";
            this.txtBanco.Size = new System.Drawing.Size(185, 22);
            this.txtBanco.TabIndex = 2;
            this.txtBanco.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBanco_KeyPress);
            this.txtBanco.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBanco_KeyUp);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtCuentaAuxiliar);
            this.groupBox1.Controls.Add(this.txtNombreAuxiliar);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtCuenta);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Location = new System.Drawing.Point(12, 233);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(648, 127);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos contables";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.label4.Location = new System.Drawing.Point(15, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Auxiliar";
            // 
            // txtCuentaAuxiliar
            // 
            this.txtCuentaAuxiliar.Location = new System.Drawing.Point(112, 74);
            this.txtCuentaAuxiliar.Name = "txtCuentaAuxiliar";
            this.txtCuentaAuxiliar.ReadOnly = true;
            this.txtCuentaAuxiliar.Size = new System.Drawing.Size(100, 22);
            this.txtCuentaAuxiliar.TabIndex = 7;
            // 
            // txtNombreAuxiliar
            // 
            this.txtNombreAuxiliar.Location = new System.Drawing.Point(219, 74);
            this.txtNombreAuxiliar.Name = "txtNombreAuxiliar";
            this.txtNombreAuxiliar.ReadOnly = true;
            this.txtNombreAuxiliar.Size = new System.Drawing.Size(401, 22);
            this.txtNombreAuxiliar.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.label3.Location = new System.Drawing.Point(15, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Cuenta";
            // 
            // txtCuenta
            // 
            this.txtCuenta.Location = new System.Drawing.Point(112, 36);
            this.txtCuenta.Name = "txtCuenta";
            this.txtCuenta.ReadOnly = true;
            this.txtCuenta.Size = new System.Drawing.Size(100, 22);
            this.txtCuenta.TabIndex = 3;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(219, 36);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.ReadOnly = true;
            this.txtNombre.Size = new System.Drawing.Size(401, 22);
            this.txtNombre.TabIndex = 5;
            // 
            // tsMenu
            // 
            this.tsMenu.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnGuardar,
            this.tsbtnSalir});
            this.tsMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(681, 25);
            this.tsMenu.TabIndex = 3;
            this.tsMenu.Text = "Menu";
            // 
            // tsbtnGuardar
            // 
            this.tsbtnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnGuardar.Image")));
            this.tsbtnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnGuardar.Name = "tsbtnGuardar";
            this.tsbtnGuardar.Size = new System.Drawing.Size(76, 22);
            this.tsbtnGuardar.Text = "Guardar";
            this.tsbtnGuardar.Click += new System.EventHandler(this.tsbtnGuardar_Click);
            // 
            // tsbtnSalir
            // 
            this.tsbtnSalir.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnSalir.Image")));
            this.tsbtnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnSalir.Name = "tsbtnSalir";
            this.tsbtnSalir.Size = new System.Drawing.Size(53, 22);
            this.tsbtnSalir.Text = "Salir";
            this.tsbtnSalir.Click += new System.EventHandler(this.tsbtnSalir_Click);
            // 
            // FrmBancos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(681, 375);
            this.Controls.Add(this.tsMenu);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbDatosCuenta);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmBancos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bancos";
            this.Load += new System.EventHandler(this.Bancos_Load);
            this.gbDatosCuenta.ResumeLayout(false);
            this.gbDatosCuenta.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDatosCuenta;
        private System.Windows.Forms.Label lblTipoCuenta;
        private System.Windows.Forms.ComboBox cbTipoCuenta;
        private System.Windows.Forms.Label lblNumeroCuenta;
        public System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label lblTitularCuenta;
        public System.Windows.Forms.TextBox txtTitular;
        private System.Windows.Forms.Label lblBanco;
        public System.Windows.Forms.TextBox txtBanco;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtSucursal;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtCuenta;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCuentaAuxiliar;
        private System.Windows.Forms.TextBox txtNombreAuxiliar;
        private System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.ToolStripButton tsbtnGuardar;
        private System.Windows.Forms.ToolStripButton tsbtnSalir;
    }
}