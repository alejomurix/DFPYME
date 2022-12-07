namespace Aplicacion.Compras.Proveedor
{
    partial class frmProveedor
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProveedor));
            this.InformacionProveedor = new System.Windows.Forms.GroupBox();
            this.lblCodigoInterno = new System.Windows.Forms.Label();
            this.txtCodigoInterno = new System.Windows.Forms.TextBox();
            this.lkbGenerar = new System.Windows.Forms.LinkLabel();
            this.lblNit = new System.Windows.Forms.Label();
            this.txtNitCedula = new System.Windows.Forms.TextBox();
            this.lblRegimen = new System.Windows.Forms.Label();
            this.cbRegimen = new System.Windows.Forms.ComboBox();
            this.lblRazonSocial = new System.Windows.Forms.Label();
            this.txtRazonSocial = new System.Windows.Forms.TextBox();
            this.lblNombreComercial = new System.Windows.Forms.Label();
            this.txtNombreComercial = new System.Windows.Forms.TextBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.InformacionContacto = new System.Windows.Forms.GroupBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtIndicativoTel = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.lblCelular = new System.Windows.Forms.Label();
            this.txtCelular = new System.Windows.Forms.TextBox();
            this.lblFax = new System.Windows.Forms.Label();
            this.txtIndicativoFax = new System.Windows.Forms.TextBox();
            this.txtNumeroFax = new System.Windows.Forms.TextBox();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.lblDepartamento = new System.Windows.Forms.Label();
            this.cbDepartamento = new System.Windows.Forms.ComboBox();
            this.lblMunicipio = new System.Windows.Forms.Label();
            this.cbCiudad = new System.Windows.Forms.ComboBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblPaginaWeb = new System.Windows.Forms.Label();
            this.txtPaginaWeb = new System.Windows.Forms.TextBox();
            this.InformacionBancaria = new System.Windows.Forms.GroupBox();
            this.btnAgregarInformacionBancaria = new System.Windows.Forms.Button();
            this.btnEliminarCuenta = new System.Windows.Forms.Button();
            this.dgvDatosBancario = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InformacionVendedor = new System.Windows.Forms.GroupBox();
            this.btnAgregarInformacionVendedor = new System.Windows.Forms.Button();
            this.btnEliminarVendedor = new System.Windows.Forms.Button();
            this.dgvDatosVendedor = new System.Windows.Forms.DataGridView();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tcProveedor = new System.Windows.Forms.TabControl();
            this.tpCrearProveedor = new System.Windows.Forms.TabPage();
            this.tsMenuCrearProveedor = new System.Windows.Forms.ToolStrip();
            this.tsbtnGuardar = new System.Windows.Forms.ToolStripButton();
            this.tsbtnSalir = new System.Windows.Forms.ToolStripButton();
            this.tpBusquedasProveedor = new System.Windows.Forms.TabPage();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.gbCuentasBanco = new System.Windows.Forms.GroupBox();
            this.bnCtaBanco = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem1 = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem1 = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.txtTipoCta = new System.Windows.Forms.TextBox();
            this.txtBancoCta = new System.Windows.Forms.TextBox();
            this.txtTitularCta = new System.Windows.Forms.TextBox();
            this.txtNumeroCta = new System.Windows.Forms.TextBox();
            this.lblTipoCuenta = new System.Windows.Forms.Label();
            this.lblBanco = new System.Windows.Forms.Label();
            this.lblTitular = new System.Windows.Forms.Label();
            this.lblNumero = new System.Windows.Forms.Label();
            this.gbContacto = new System.Windows.Forms.GroupBox();
            this.txtEstadoVendedor = new System.Windows.Forms.TextBox();
            this.lblEstadoVendedor = new System.Windows.Forms.Label();
            this.bnVendedor = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.txtCelularVendedor = new System.Windows.Forms.TextBox();
            this.txtNombreVendedor = new System.Windows.Forms.TextBox();
            this.txtCedulaVendedor = new System.Windows.Forms.TextBox();
            this.lblCedula = new System.Windows.Forms.Label();
            this.lblNombreVendedor = new System.Windows.Forms.Label();
            this.lblCelularVendedor = new System.Windows.Forms.Label();
            this.lblEmailVendedor = new System.Windows.Forms.Label();
            this.txtEmailVendedor = new System.Windows.Forms.TextBox();
            this.gbConsulta = new System.Windows.Forms.GroupBox();
            this.cbCriterio2 = new System.Windows.Forms.ComboBox();
            this.cbCriterio1 = new System.Windows.Forms.ComboBox();
            this.btnConsulta = new System.Windows.Forms.Button();
            this.txtConsulta = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvListadoProveedor = new System.Windows.Forms.DataGridView();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ciudad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsMenuBusqueda = new System.Windows.Forms.ToolStrip();
            this.tsbtnListarTodos = new System.Windows.Forms.ToolStripButton();
            this.tsbtnEditarProveedor = new System.Windows.Forms.ToolStripButton();
            this.tsbtnEliminar = new System.Windows.Forms.ToolStripButton();
            this.tsbtnConsultaSalir = new System.Windows.Forms.ToolStripButton();
            this.InformacionProveedor.SuspendLayout();
            this.InformacionContacto.SuspendLayout();
            this.InformacionBancaria.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosBancario)).BeginInit();
            this.InformacionVendedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosVendedor)).BeginInit();
            this.tcProveedor.SuspendLayout();
            this.tpCrearProveedor.SuspendLayout();
            this.tsMenuCrearProveedor.SuspendLayout();
            this.tpBusquedasProveedor.SuspendLayout();
            this.gbCuentasBanco.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bnCtaBanco)).BeginInit();
            this.bnCtaBanco.SuspendLayout();
            this.gbContacto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bnVendedor)).BeginInit();
            this.bnVendedor.SuspendLayout();
            this.gbConsulta.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoProveedor)).BeginInit();
            this.tsMenuBusqueda.SuspendLayout();
            this.SuspendLayout();
            // 
            // InformacionProveedor
            // 
            this.InformacionProveedor.Controls.Add(this.lblCodigoInterno);
            this.InformacionProveedor.Controls.Add(this.txtCodigoInterno);
            this.InformacionProveedor.Controls.Add(this.lkbGenerar);
            this.InformacionProveedor.Controls.Add(this.lblNit);
            this.InformacionProveedor.Controls.Add(this.txtNitCedula);
            this.InformacionProveedor.Controls.Add(this.lblRegimen);
            this.InformacionProveedor.Controls.Add(this.cbRegimen);
            this.InformacionProveedor.Controls.Add(this.lblRazonSocial);
            this.InformacionProveedor.Controls.Add(this.txtRazonSocial);
            this.InformacionProveedor.Controls.Add(this.lblNombreComercial);
            this.InformacionProveedor.Controls.Add(this.txtNombreComercial);
            this.InformacionProveedor.Controls.Add(this.lblDescripcion);
            this.InformacionProveedor.Controls.Add(this.txtDescripcion);
            this.InformacionProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InformacionProveedor.Location = new System.Drawing.Point(16, 39);
            this.InformacionProveedor.Margin = new System.Windows.Forms.Padding(4);
            this.InformacionProveedor.Name = "InformacionProveedor";
            this.InformacionProveedor.Padding = new System.Windows.Forms.Padding(4);
            this.InformacionProveedor.Size = new System.Drawing.Size(950, 123);
            this.InformacionProveedor.TabIndex = 0;
            this.InformacionProveedor.TabStop = false;
            this.InformacionProveedor.Text = "Datos Proveedor";
            // 
            // lblCodigoInterno
            // 
            this.lblCodigoInterno.AutoSize = true;
            this.lblCodigoInterno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblCodigoInterno.Location = new System.Drawing.Point(10, 26);
            this.lblCodigoInterno.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCodigoInterno.Name = "lblCodigoInterno";
            this.lblCodigoInterno.Size = new System.Drawing.Size(95, 16);
            this.lblCodigoInterno.TabIndex = 0;
            this.lblCodigoInterno.Text = "Codigo Interno";
            // 
            // txtCodigoInterno
            // 
            this.txtCodigoInterno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigoInterno.Location = new System.Drawing.Point(152, 20);
            this.txtCodigoInterno.MaxLength = 100;
            this.txtCodigoInterno.Name = "txtCodigoInterno";
            this.txtCodigoInterno.Size = new System.Drawing.Size(79, 22);
            this.txtCodigoInterno.TabIndex = 0;
            this.txtCodigoInterno.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoInterno_KeyPress);
            this.txtCodigoInterno.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodigoInterno_Validating);
            // 
            // lkbGenerar
            // 
            this.lkbGenerar.AutoSize = true;
            this.lkbGenerar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lkbGenerar.Location = new System.Drawing.Point(239, 24);
            this.lkbGenerar.Name = "lkbGenerar";
            this.lkbGenerar.Size = new System.Drawing.Size(83, 16);
            this.lkbGenerar.TabIndex = 11;
            this.lkbGenerar.TabStop = true;
            this.lkbGenerar.Text = "Generar [F3]";
            this.lkbGenerar.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lkbGenerar_LinkClicked);
            // 
            // lblNit
            // 
            this.lblNit.AutoSize = true;
            this.lblNit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblNit.Location = new System.Drawing.Point(340, 24);
            this.lblNit.Name = "lblNit";
            this.lblNit.Size = new System.Drawing.Size(87, 16);
            this.lblNit.TabIndex = 1;
            this.lblNit.Text = "NIT o Cedula";
            // 
            // txtNitCedula
            // 
            this.txtNitCedula.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNitCedula.Location = new System.Drawing.Point(436, 22);
            this.txtNitCedula.MaxLength = 100;
            this.txtNitCedula.Name = "txtNitCedula";
            this.txtNitCedula.Size = new System.Drawing.Size(113, 22);
            this.txtNitCedula.TabIndex = 1;
            this.txtNitCedula.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNitCedula_KeyPress);
            this.txtNitCedula.Validating += new System.ComponentModel.CancelEventHandler(this.txtNitCedula_Validating);
            // 
            // lblRegimen
            // 
            this.lblRegimen.AutoSize = true;
            this.lblRegimen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblRegimen.Location = new System.Drawing.Point(596, 24);
            this.lblRegimen.Name = "lblRegimen";
            this.lblRegimen.Size = new System.Drawing.Size(63, 16);
            this.lblRegimen.TabIndex = 2;
            this.lblRegimen.Text = "Regimen";
            // 
            // cbRegimen
            // 
            this.cbRegimen.DisplayMember = "NombreRegimen";
            this.cbRegimen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRegimen.FormattingEnabled = true;
            this.cbRegimen.Location = new System.Drawing.Point(667, 19);
            this.cbRegimen.Name = "cbRegimen";
            this.cbRegimen.Size = new System.Drawing.Size(108, 24);
            this.cbRegimen.TabIndex = 2;
            this.cbRegimen.ValueMember = "IdRegimen";
            this.cbRegimen.Enter += new System.EventHandler(this.cbRegimen_Enter);
            this.cbRegimen.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbRegimen_KeyPress);
            // 
            // lblRazonSocial
            // 
            this.lblRazonSocial.AutoSize = true;
            this.lblRazonSocial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblRazonSocial.Location = new System.Drawing.Point(11, 57);
            this.lblRazonSocial.Name = "lblRazonSocial";
            this.lblRazonSocial.Size = new System.Drawing.Size(88, 16);
            this.lblRazonSocial.TabIndex = 4;
            this.lblRazonSocial.Text = "Razón Social";
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRazonSocial.Location = new System.Drawing.Point(152, 55);
            this.txtRazonSocial.MaxLength = 150;
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.Size = new System.Drawing.Size(250, 22);
            this.txtRazonSocial.TabIndex = 3;
            this.txtRazonSocial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRazonSocial_KeyPress);
            this.txtRazonSocial.Validating += new System.ComponentModel.CancelEventHandler(this.txtRazonSocial_Validating);
            // 
            // lblNombreComercial
            // 
            this.lblNombreComercial.AutoSize = true;
            this.lblNombreComercial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreComercial.Location = new System.Drawing.Point(10, 90);
            this.lblNombreComercial.Name = "lblNombreComercial";
            this.lblNombreComercial.Size = new System.Drawing.Size(121, 16);
            this.lblNombreComercial.TabIndex = 3;
            this.lblNombreComercial.Text = "Nombre Comercial";
            // 
            // txtNombreComercial
            // 
            this.txtNombreComercial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreComercial.Location = new System.Drawing.Point(152, 88);
            this.txtNombreComercial.MaxLength = 150;
            this.txtNombreComercial.Name = "txtNombreComercial";
            this.txtNombreComercial.Size = new System.Drawing.Size(250, 22);
            this.txtNombreComercial.TabIndex = 4;
            this.txtNombreComercial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombreComercial_KeyPress);
            this.txtNombreComercial.Validating += new System.ComponentModel.CancelEventHandler(this.txtNombreComercial_Validating);
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblDescripcion.Location = new System.Drawing.Point(433, 55);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(80, 16);
            this.lblDescripcion.TabIndex = 5;
            this.lblDescripcion.Text = "Descripción";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.Location = new System.Drawing.Point(529, 55);
            this.txtDescripcion.MaxLength = 1000;
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(406, 55);
            this.txtDescripcion.TabIndex = 5;
            this.txtDescripcion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescripcion_KeyPress);
            this.txtDescripcion.Validating += new System.ComponentModel.CancelEventHandler(this.txtDescripcion_Validating);
            // 
            // InformacionContacto
            // 
            this.InformacionContacto.Controls.Add(this.lblTelefono);
            this.InformacionContacto.Controls.Add(this.txtIndicativoTel);
            this.InformacionContacto.Controls.Add(this.txtTelefono);
            this.InformacionContacto.Controls.Add(this.lblCelular);
            this.InformacionContacto.Controls.Add(this.txtCelular);
            this.InformacionContacto.Controls.Add(this.lblFax);
            this.InformacionContacto.Controls.Add(this.txtIndicativoFax);
            this.InformacionContacto.Controls.Add(this.txtNumeroFax);
            this.InformacionContacto.Controls.Add(this.lblDireccion);
            this.InformacionContacto.Controls.Add(this.txtDireccion);
            this.InformacionContacto.Controls.Add(this.lblDepartamento);
            this.InformacionContacto.Controls.Add(this.cbDepartamento);
            this.InformacionContacto.Controls.Add(this.lblMunicipio);
            this.InformacionContacto.Controls.Add(this.cbCiudad);
            this.InformacionContacto.Controls.Add(this.lblEmail);
            this.InformacionContacto.Controls.Add(this.txtEmail);
            this.InformacionContacto.Controls.Add(this.lblPaginaWeb);
            this.InformacionContacto.Controls.Add(this.txtPaginaWeb);
            this.InformacionContacto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.InformacionContacto.Location = new System.Drawing.Point(16, 170);
            this.InformacionContacto.Margin = new System.Windows.Forms.Padding(4);
            this.InformacionContacto.Name = "InformacionContacto";
            this.InformacionContacto.Padding = new System.Windows.Forms.Padding(4);
            this.InformacionContacto.Size = new System.Drawing.Size(950, 131);
            this.InformacionContacto.TabIndex = 1;
            this.InformacionContacto.TabStop = false;
            this.InformacionContacto.Text = "Información de Contacto";
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblTelefono.Location = new System.Drawing.Point(8, 29);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(62, 16);
            this.lblTelefono.TabIndex = 0;
            this.lblTelefono.Text = "Teléfono";
            // 
            // txtIndicativoTel
            // 
            this.txtIndicativoTel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIndicativoTel.Location = new System.Drawing.Point(91, 25);
            this.txtIndicativoTel.MaxLength = 3;
            this.txtIndicativoTel.Name = "txtIndicativoTel";
            this.txtIndicativoTel.Size = new System.Drawing.Size(42, 22);
            this.txtIndicativoTel.TabIndex = 0;
            this.txtIndicativoTel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIndicativoTel_KeyPress);
            this.txtIndicativoTel.Validating += new System.ComponentModel.CancelEventHandler(this.txtIndicativoTel_Validating);
            // 
            // txtTelefono
            // 
            this.txtTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelefono.Location = new System.Drawing.Point(137, 25);
            this.txtTelefono.MaxLength = 20;
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(131, 22);
            this.txtTelefono.TabIndex = 1;
            this.txtTelefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTelefono_KeyPress);
            this.txtTelefono.Validating += new System.ComponentModel.CancelEventHandler(this.txtTelefono_Validating);
            // 
            // lblCelular
            // 
            this.lblCelular.AutoSize = true;
            this.lblCelular.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblCelular.Location = new System.Drawing.Point(351, 28);
            this.lblCelular.Name = "lblCelular";
            this.lblCelular.Size = new System.Drawing.Size(50, 16);
            this.lblCelular.TabIndex = 1;
            this.lblCelular.Text = "Celular";
            // 
            // txtCelular
            // 
            this.txtCelular.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCelular.Location = new System.Drawing.Point(454, 25);
            this.txtCelular.MaxLength = 20;
            this.txtCelular.Name = "txtCelular";
            this.txtCelular.Size = new System.Drawing.Size(124, 22);
            this.txtCelular.TabIndex = 2;
            this.txtCelular.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCelular_KeyPress);
            this.txtCelular.Validating += new System.ComponentModel.CancelEventHandler(this.txtCelular_Validating);
            // 
            // lblFax
            // 
            this.lblFax.AutoSize = true;
            this.lblFax.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFax.Location = new System.Drawing.Point(604, 29);
            this.lblFax.Name = "lblFax";
            this.lblFax.Size = new System.Drawing.Size(30, 16);
            this.lblFax.TabIndex = 2;
            this.lblFax.Text = "Fax";
            // 
            // txtIndicativoFax
            // 
            this.txtIndicativoFax.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIndicativoFax.Location = new System.Drawing.Point(681, 26);
            this.txtIndicativoFax.MaxLength = 3;
            this.txtIndicativoFax.Name = "txtIndicativoFax";
            this.txtIndicativoFax.Size = new System.Drawing.Size(40, 22);
            this.txtIndicativoFax.TabIndex = 3;
            this.txtIndicativoFax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIndicativoFax_KeyPress);
            this.txtIndicativoFax.Validating += new System.ComponentModel.CancelEventHandler(this.txtIndicativoFax_Validating);
            // 
            // txtNumeroFax
            // 
            this.txtNumeroFax.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumeroFax.Location = new System.Drawing.Point(727, 26);
            this.txtNumeroFax.MaxLength = 20;
            this.txtNumeroFax.Name = "txtNumeroFax";
            this.txtNumeroFax.Size = new System.Drawing.Size(108, 22);
            this.txtNumeroFax.TabIndex = 4;
            this.txtNumeroFax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeroFax_KeyPress);
            this.txtNumeroFax.Validating += new System.ComponentModel.CancelEventHandler(this.txtNumeroFax_Validating);
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblDireccion.Location = new System.Drawing.Point(8, 64);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(65, 16);
            this.lblDireccion.TabIndex = 3;
            this.lblDireccion.Text = "Dirección";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDireccion.Location = new System.Drawing.Point(90, 60);
            this.txtDireccion.MaxLength = 100;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(153, 22);
            this.txtDireccion.TabIndex = 5;
            this.txtDireccion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDireccion_KeyPress);
            this.txtDireccion.Validating += new System.ComponentModel.CancelEventHandler(this.txtDireccion_Validating);
            // 
            // lblDepartamento
            // 
            this.lblDepartamento.AutoSize = true;
            this.lblDepartamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDepartamento.Location = new System.Drawing.Point(350, 61);
            this.lblDepartamento.Name = "lblDepartamento";
            this.lblDepartamento.Size = new System.Drawing.Size(94, 16);
            this.lblDepartamento.TabIndex = 5;
            this.lblDepartamento.Text = "Departamento";
            // 
            // cbDepartamento
            // 
            this.cbDepartamento.DisplayMember = "NombreDepartamento";
            this.cbDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDepartamento.FormattingEnabled = true;
            this.cbDepartamento.Location = new System.Drawing.Point(454, 57);
            this.cbDepartamento.Name = "cbDepartamento";
            this.cbDepartamento.Size = new System.Drawing.Size(121, 24);
            this.cbDepartamento.TabIndex = 6;
            this.cbDepartamento.ValueMember = "IdDepartamento";
            this.cbDepartamento.SelectionChangeCommitted += new System.EventHandler(this.cbDepartamento_SelectionChangeCommitted);
            this.cbDepartamento.Enter += new System.EventHandler(this.cbDepartamento_Enter);
            this.cbDepartamento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbDepartamento_KeyPress);
            // 
            // lblMunicipio
            // 
            this.lblMunicipio.AutoSize = true;
            this.lblMunicipio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblMunicipio.Location = new System.Drawing.Point(603, 61);
            this.lblMunicipio.Name = "lblMunicipio";
            this.lblMunicipio.Size = new System.Drawing.Size(65, 16);
            this.lblMunicipio.TabIndex = 4;
            this.lblMunicipio.Text = "Municipio";
            // 
            // cbCiudad
            // 
            this.cbCiudad.DisplayMember = "NombreCiudad";
            this.cbCiudad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCiudad.Location = new System.Drawing.Point(681, 57);
            this.cbCiudad.Name = "cbCiudad";
            this.cbCiudad.Size = new System.Drawing.Size(120, 24);
            this.cbCiudad.TabIndex = 7;
            this.cbCiudad.ValueMember = "IdCiudad";
            this.cbCiudad.Enter += new System.EventHandler(this.cbCiudad_Enter);
            this.cbCiudad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbCiudad_KeyPress);
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(8, 99);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(46, 16);
            this.lblEmail.TabIndex = 7;
            this.lblEmail.Text = "E-mail";
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(90, 96);
            this.txtEmail.MaxLength = 100;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(227, 22);
            this.txtEmail.TabIndex = 8;
            this.txtEmail.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEmail_KeyPress);
            this.txtEmail.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmail_Validating);
            // 
            // lblPaginaWeb
            // 
            this.lblPaginaWeb.AutoSize = true;
            this.lblPaginaWeb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaginaWeb.Location = new System.Drawing.Point(350, 99);
            this.lblPaginaWeb.Name = "lblPaginaWeb";
            this.lblPaginaWeb.Size = new System.Drawing.Size(83, 16);
            this.lblPaginaWeb.TabIndex = 8;
            this.lblPaginaWeb.Text = "Pagina Web";
            // 
            // txtPaginaWeb
            // 
            this.txtPaginaWeb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaginaWeb.Location = new System.Drawing.Point(452, 96);
            this.txtPaginaWeb.MaxLength = 100;
            this.txtPaginaWeb.Name = "txtPaginaWeb";
            this.txtPaginaWeb.Size = new System.Drawing.Size(270, 22);
            this.txtPaginaWeb.TabIndex = 9;
            this.txtPaginaWeb.Validating += new System.ComponentModel.CancelEventHandler(this.txtPaginaWeb_Validating);
            // 
            // InformacionBancaria
            // 
            this.InformacionBancaria.Controls.Add(this.btnAgregarInformacionBancaria);
            this.InformacionBancaria.Controls.Add(this.btnEliminarCuenta);
            this.InformacionBancaria.Controls.Add(this.dgvDatosBancario);
            this.InformacionBancaria.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.InformacionBancaria.Location = new System.Drawing.Point(17, 307);
            this.InformacionBancaria.Margin = new System.Windows.Forms.Padding(4);
            this.InformacionBancaria.Name = "InformacionBancaria";
            this.InformacionBancaria.Padding = new System.Windows.Forms.Padding(4);
            this.InformacionBancaria.Size = new System.Drawing.Size(950, 140);
            this.InformacionBancaria.TabIndex = 2;
            this.InformacionBancaria.TabStop = false;
            this.InformacionBancaria.Text = "Información Bancaria";
            // 
            // btnAgregarInformacionBancaria
            // 
            this.btnAgregarInformacionBancaria.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.btnAgregarInformacionBancaria.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregarInformacionBancaria.Image")));
            this.btnAgregarInformacionBancaria.Location = new System.Drawing.Point(54, 31);
            this.btnAgregarInformacionBancaria.Name = "btnAgregarInformacionBancaria";
            this.btnAgregarInformacionBancaria.Size = new System.Drawing.Size(25, 24);
            this.btnAgregarInformacionBancaria.TabIndex = 0;
            this.btnAgregarInformacionBancaria.UseVisualStyleBackColor = true;
            this.btnAgregarInformacionBancaria.Click += new System.EventHandler(this.btnAgregarInformacionBancaria_Click);
            // 
            // btnEliminarCuenta
            // 
            this.btnEliminarCuenta.Enabled = false;
            this.btnEliminarCuenta.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminarCuenta.Image")));
            this.btnEliminarCuenta.Location = new System.Drawing.Point(92, 32);
            this.btnEliminarCuenta.Name = "btnEliminarCuenta";
            this.btnEliminarCuenta.Size = new System.Drawing.Size(31, 23);
            this.btnEliminarCuenta.TabIndex = 1;
            this.btnEliminarCuenta.UseVisualStyleBackColor = true;
            this.btnEliminarCuenta.Click += new System.EventHandler(this.btnEliminarCuenta_Click);
            // 
            // dgvDatosBancario
            // 
            this.dgvDatosBancario.AllowUserToAddRows = false;
            this.dgvDatosBancario.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDatosBancario.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvDatosBancario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatosBancario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column3,
            this.Column4,
            this.Column2});
            this.dgvDatosBancario.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvDatosBancario.Location = new System.Drawing.Point(243, 13);
            this.dgvDatosBancario.Name = "dgvDatosBancario";
            this.dgvDatosBancario.Size = new System.Drawing.Size(686, 110);
            this.dgvDatosBancario.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "NumeroCuenta";
            this.Column1.HeaderText = "Numero  Cuenta";
            this.Column1.Name = "Column1";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "TitularCuenta";
            this.Column3.HeaderText = "Titular";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "BancoCuenta";
            this.Column4.HeaderText = "Banco";
            this.Column4.Name = "Column4";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "TipoCuenta";
            this.Column2.HeaderText = "Tipo Cuenta ";
            this.Column2.Name = "Column2";
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // InformacionVendedor
            // 
            this.InformacionVendedor.Controls.Add(this.btnAgregarInformacionVendedor);
            this.InformacionVendedor.Controls.Add(this.btnEliminarVendedor);
            this.InformacionVendedor.Controls.Add(this.dgvDatosVendedor);
            this.InformacionVendedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.InformacionVendedor.Location = new System.Drawing.Point(16, 455);
            this.InformacionVendedor.Name = "InformacionVendedor";
            this.InformacionVendedor.Size = new System.Drawing.Size(950, 140);
            this.InformacionVendedor.TabIndex = 3;
            this.InformacionVendedor.TabStop = false;
            this.InformacionVendedor.Text = "Información Vendedor";
            // 
            // btnAgregarInformacionVendedor
            // 
            this.btnAgregarInformacionVendedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.btnAgregarInformacionVendedor.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregarInformacionVendedor.Image")));
            this.btnAgregarInformacionVendedor.Location = new System.Drawing.Point(54, 31);
            this.btnAgregarInformacionVendedor.Name = "btnAgregarInformacionVendedor";
            this.btnAgregarInformacionVendedor.Size = new System.Drawing.Size(25, 24);
            this.btnAgregarInformacionVendedor.TabIndex = 0;
            this.btnAgregarInformacionVendedor.UseVisualStyleBackColor = true;
            this.btnAgregarInformacionVendedor.Click += new System.EventHandler(this.btnAgregarInformacionVendedor_Click);
            // 
            // btnEliminarVendedor
            // 
            this.btnEliminarVendedor.Enabled = false;
            this.btnEliminarVendedor.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminarVendedor.Image")));
            this.btnEliminarVendedor.Location = new System.Drawing.Point(92, 32);
            this.btnEliminarVendedor.Name = "btnEliminarVendedor";
            this.btnEliminarVendedor.Size = new System.Drawing.Size(31, 23);
            this.btnEliminarVendedor.TabIndex = 1;
            this.btnEliminarVendedor.UseVisualStyleBackColor = true;
            this.btnEliminarVendedor.Click += new System.EventHandler(this.btnEliminarVendedor_Click);
            // 
            // dgvDatosVendedor
            // 
            this.dgvDatosVendedor.AllowUserToAddRows = false;
            this.dgvDatosVendedor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDatosVendedor.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvDatosVendedor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatosVendedor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9});
            this.dgvDatosVendedor.Location = new System.Drawing.Point(245, 16);
            this.dgvDatosVendedor.Name = "dgvDatosVendedor";
            this.dgvDatosVendedor.Size = new System.Drawing.Size(685, 116);
            this.dgvDatosVendedor.TabIndex = 0;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "CedulaContacto";
            this.Column5.HeaderText = "Cedula";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "NombreContacto";
            this.Column6.HeaderText = "Nombre";
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "TelefonoContacto";
            this.Column7.HeaderText = "Telefono";
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "CelularContacto";
            this.Column8.HeaderText = "Celular";
            this.Column8.Name = "Column8";
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "EmailContacto";
            this.Column9.HeaderText = "Email";
            this.Column9.Name = "Column9";
            // 
            // tcProveedor
            // 
            this.tcProveedor.Controls.Add(this.tpCrearProveedor);
            this.tcProveedor.Controls.Add(this.tpBusquedasProveedor);
            this.tcProveedor.Location = new System.Drawing.Point(3, 1);
            this.tcProveedor.Name = "tcProveedor";
            this.tcProveedor.SelectedIndex = 0;
            this.tcProveedor.Size = new System.Drawing.Size(991, 634);
            this.tcProveedor.TabIndex = 4;
            // 
            // tpCrearProveedor
            // 
            this.tpCrearProveedor.Controls.Add(this.tsMenuCrearProveedor);
            this.tpCrearProveedor.Controls.Add(this.InformacionProveedor);
            this.tpCrearProveedor.Controls.Add(this.InformacionContacto);
            this.tpCrearProveedor.Controls.Add(this.InformacionBancaria);
            this.tpCrearProveedor.Controls.Add(this.InformacionVendedor);
            this.tpCrearProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpCrearProveedor.Location = new System.Drawing.Point(4, 25);
            this.tpCrearProveedor.Name = "tpCrearProveedor";
            this.tpCrearProveedor.Padding = new System.Windows.Forms.Padding(3);
            this.tpCrearProveedor.Size = new System.Drawing.Size(983, 605);
            this.tpCrearProveedor.TabIndex = 0;
            this.tpCrearProveedor.Text = "Crear Proveedor";
            this.tpCrearProveedor.UseVisualStyleBackColor = true;
            // 
            // tsMenuCrearProveedor
            // 
            this.tsMenuCrearProveedor.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsMenuCrearProveedor.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnGuardar,
            this.tsbtnSalir});
            this.tsMenuCrearProveedor.Location = new System.Drawing.Point(3, 3);
            this.tsMenuCrearProveedor.Name = "tsMenuCrearProveedor";
            this.tsMenuCrearProveedor.Size = new System.Drawing.Size(977, 25);
            this.tsMenuCrearProveedor.TabIndex = 0;
            this.tsMenuCrearProveedor.Text = "Menu Crear Proveedor";
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
            // tpBusquedasProveedor
            // 
            this.tpBusquedasProveedor.Controls.Add(this.btnActualizar);
            this.tpBusquedasProveedor.Controls.Add(this.gbCuentasBanco);
            this.tpBusquedasProveedor.Controls.Add(this.gbContacto);
            this.tpBusquedasProveedor.Controls.Add(this.gbConsulta);
            this.tpBusquedasProveedor.Controls.Add(this.groupBox1);
            this.tpBusquedasProveedor.Controls.Add(this.tsMenuBusqueda);
            this.tpBusquedasProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.tpBusquedasProveedor.Location = new System.Drawing.Point(4, 25);
            this.tpBusquedasProveedor.Name = "tpBusquedasProveedor";
            this.tpBusquedasProveedor.Padding = new System.Windows.Forms.Padding(3);
            this.tpBusquedasProveedor.Size = new System.Drawing.Size(983, 605);
            this.tpBusquedasProveedor.TabIndex = 1;
            this.tpBusquedasProveedor.Text = "Consultar Proveedores";
            this.tpBusquedasProveedor.UseVisualStyleBackColor = true;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(894, 571);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(75, 23);
            this.btnActualizar.TabIndex = 5;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Visible = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // gbCuentasBanco
            // 
            this.gbCuentasBanco.Controls.Add(this.bnCtaBanco);
            this.gbCuentasBanco.Controls.Add(this.txtTipoCta);
            this.gbCuentasBanco.Controls.Add(this.txtBancoCta);
            this.gbCuentasBanco.Controls.Add(this.txtTitularCta);
            this.gbCuentasBanco.Controls.Add(this.txtNumeroCta);
            this.gbCuentasBanco.Controls.Add(this.lblTipoCuenta);
            this.gbCuentasBanco.Controls.Add(this.lblBanco);
            this.gbCuentasBanco.Controls.Add(this.lblTitular);
            this.gbCuentasBanco.Controls.Add(this.lblNumero);
            this.gbCuentasBanco.Location = new System.Drawing.Point(352, 381);
            this.gbCuentasBanco.Name = "gbCuentasBanco";
            this.gbCuentasBanco.Size = new System.Drawing.Size(297, 213);
            this.gbCuentasBanco.TabIndex = 4;
            this.gbCuentasBanco.TabStop = false;
            this.gbCuentasBanco.Text = "Cuentas Bancarias";
            // 
            // bnCtaBanco
            // 
            this.bnCtaBanco.AddNewItem = null;
            this.bnCtaBanco.CountItem = this.bindingNavigatorCountItem1;
            this.bnCtaBanco.DeleteItem = null;
            this.bnCtaBanco.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem1,
            this.bindingNavigatorMovePreviousItem1,
            this.bindingNavigatorSeparator3,
            this.bindingNavigatorPositionItem1,
            this.bindingNavigatorCountItem1,
            this.bindingNavigatorSeparator4,
            this.bindingNavigatorMoveNextItem1,
            this.bindingNavigatorMoveLastItem1,
            this.bindingNavigatorSeparator5});
            this.bnCtaBanco.Location = new System.Drawing.Point(3, 18);
            this.bnCtaBanco.MoveFirstItem = this.bindingNavigatorMoveFirstItem1;
            this.bnCtaBanco.MoveLastItem = this.bindingNavigatorMoveLastItem1;
            this.bnCtaBanco.MoveNextItem = this.bindingNavigatorMoveNextItem1;
            this.bnCtaBanco.MovePreviousItem = this.bindingNavigatorMovePreviousItem1;
            this.bnCtaBanco.Name = "bnCtaBanco";
            this.bnCtaBanco.PositionItem = this.bindingNavigatorPositionItem1;
            this.bnCtaBanco.Size = new System.Drawing.Size(291, 25);
            this.bnCtaBanco.TabIndex = 8;
            this.bnCtaBanco.Text = "Cuentas Bancarias";
            // 
            // bindingNavigatorCountItem1
            // 
            this.bindingNavigatorCountItem1.Name = "bindingNavigatorCountItem1";
            this.bindingNavigatorCountItem1.Size = new System.Drawing.Size(37, 22);
            this.bindingNavigatorCountItem1.Text = "de {0}";
            this.bindingNavigatorCountItem1.ToolTipText = "Número total de elementos";
            // 
            // bindingNavigatorMoveFirstItem1
            // 
            this.bindingNavigatorMoveFirstItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem1.Image")));
            this.bindingNavigatorMoveFirstItem1.Name = "bindingNavigatorMoveFirstItem1";
            this.bindingNavigatorMoveFirstItem1.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem1.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem1.Text = "Mover primero";
            // 
            // bindingNavigatorMovePreviousItem1
            // 
            this.bindingNavigatorMovePreviousItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem1.Image")));
            this.bindingNavigatorMovePreviousItem1.Name = "bindingNavigatorMovePreviousItem1";
            this.bindingNavigatorMovePreviousItem1.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem1.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem1.Text = "Mover anterior";
            // 
            // bindingNavigatorSeparator3
            // 
            this.bindingNavigatorSeparator3.Name = "bindingNavigatorSeparator3";
            this.bindingNavigatorSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem1
            // 
            this.bindingNavigatorPositionItem1.AccessibleName = "Posición";
            this.bindingNavigatorPositionItem1.AutoSize = false;
            this.bindingNavigatorPositionItem1.Name = "bindingNavigatorPositionItem1";
            this.bindingNavigatorPositionItem1.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem1.Text = "0";
            this.bindingNavigatorPositionItem1.ToolTipText = "Posición actual";
            // 
            // bindingNavigatorSeparator4
            // 
            this.bindingNavigatorSeparator4.Name = "bindingNavigatorSeparator4";
            this.bindingNavigatorSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem1
            // 
            this.bindingNavigatorMoveNextItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem1.Image")));
            this.bindingNavigatorMoveNextItem1.Name = "bindingNavigatorMoveNextItem1";
            this.bindingNavigatorMoveNextItem1.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem1.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem1.Text = "Mover siguiente";
            // 
            // bindingNavigatorMoveLastItem1
            // 
            this.bindingNavigatorMoveLastItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem1.Image")));
            this.bindingNavigatorMoveLastItem1.Name = "bindingNavigatorMoveLastItem1";
            this.bindingNavigatorMoveLastItem1.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem1.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem1.Text = "Mover último";
            // 
            // bindingNavigatorSeparator5
            // 
            this.bindingNavigatorSeparator5.Name = "bindingNavigatorSeparator5";
            this.bindingNavigatorSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // txtTipoCta
            // 
            this.txtTipoCta.Location = new System.Drawing.Point(123, 174);
            this.txtTipoCta.Name = "txtTipoCta";
            this.txtTipoCta.ReadOnly = true;
            this.txtTipoCta.Size = new System.Drawing.Size(152, 22);
            this.txtTipoCta.TabIndex = 7;
            // 
            // txtBancoCta
            // 
            this.txtBancoCta.Location = new System.Drawing.Point(123, 140);
            this.txtBancoCta.Name = "txtBancoCta";
            this.txtBancoCta.ReadOnly = true;
            this.txtBancoCta.Size = new System.Drawing.Size(152, 22);
            this.txtBancoCta.TabIndex = 6;
            // 
            // txtTitularCta
            // 
            this.txtTitularCta.Location = new System.Drawing.Point(123, 104);
            this.txtTitularCta.Name = "txtTitularCta";
            this.txtTitularCta.ReadOnly = true;
            this.txtTitularCta.Size = new System.Drawing.Size(152, 22);
            this.txtTitularCta.TabIndex = 5;
            // 
            // txtNumeroCta
            // 
            this.txtNumeroCta.Location = new System.Drawing.Point(123, 65);
            this.txtNumeroCta.Name = "txtNumeroCta";
            this.txtNumeroCta.ReadOnly = true;
            this.txtNumeroCta.Size = new System.Drawing.Size(152, 22);
            this.txtNumeroCta.TabIndex = 4;
            // 
            // lblTipoCuenta
            // 
            this.lblTipoCuenta.AutoSize = true;
            this.lblTipoCuenta.Location = new System.Drawing.Point(11, 174);
            this.lblTipoCuenta.Name = "lblTipoCuenta";
            this.lblTipoCuenta.Size = new System.Drawing.Size(81, 16);
            this.lblTipoCuenta.TabIndex = 3;
            this.lblTipoCuenta.Text = "Tipo Cuenta";
            // 
            // lblBanco
            // 
            this.lblBanco.AutoSize = true;
            this.lblBanco.Location = new System.Drawing.Point(11, 140);
            this.lblBanco.Name = "lblBanco";
            this.lblBanco.Size = new System.Drawing.Size(47, 16);
            this.lblBanco.TabIndex = 2;
            this.lblBanco.Text = "Banco";
            // 
            // lblTitular
            // 
            this.lblTitular.AutoSize = true;
            this.lblTitular.Location = new System.Drawing.Point(11, 104);
            this.lblTitular.Name = "lblTitular";
            this.lblTitular.Size = new System.Drawing.Size(45, 16);
            this.lblTitular.TabIndex = 1;
            this.lblTitular.Text = "Titular";
            // 
            // lblNumero
            // 
            this.lblNumero.AutoSize = true;
            this.lblNumero.Location = new System.Drawing.Point(11, 65);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(101, 16);
            this.lblNumero.TabIndex = 0;
            this.lblNumero.Text = "Numero Cuenta";
            // 
            // gbContacto
            // 
            this.gbContacto.Controls.Add(this.txtEstadoVendedor);
            this.gbContacto.Controls.Add(this.lblEstadoVendedor);
            this.gbContacto.Controls.Add(this.bnVendedor);
            this.gbContacto.Controls.Add(this.txtCelularVendedor);
            this.gbContacto.Controls.Add(this.txtNombreVendedor);
            this.gbContacto.Controls.Add(this.txtCedulaVendedor);
            this.gbContacto.Controls.Add(this.lblCedula);
            this.gbContacto.Controls.Add(this.lblNombreVendedor);
            this.gbContacto.Controls.Add(this.lblCelularVendedor);
            this.gbContacto.Controls.Add(this.lblEmailVendedor);
            this.gbContacto.Controls.Add(this.txtEmailVendedor);
            this.gbContacto.Location = new System.Drawing.Point(10, 382);
            this.gbContacto.Name = "gbContacto";
            this.gbContacto.Size = new System.Drawing.Size(297, 212);
            this.gbContacto.TabIndex = 3;
            this.gbContacto.TabStop = false;
            this.gbContacto.Text = "Vendedores";
            // 
            // txtEstadoVendedor
            // 
            this.txtEstadoVendedor.Location = new System.Drawing.Point(93, 180);
            this.txtEstadoVendedor.Name = "txtEstadoVendedor";
            this.txtEstadoVendedor.ReadOnly = true;
            this.txtEstadoVendedor.Size = new System.Drawing.Size(173, 22);
            this.txtEstadoVendedor.TabIndex = 10;
            // 
            // lblEstadoVendedor
            // 
            this.lblEstadoVendedor.AutoSize = true;
            this.lblEstadoVendedor.Location = new System.Drawing.Point(12, 183);
            this.lblEstadoVendedor.Name = "lblEstadoVendedor";
            this.lblEstadoVendedor.Size = new System.Drawing.Size(51, 16);
            this.lblEstadoVendedor.TabIndex = 9;
            this.lblEstadoVendedor.Text = "Estado";
            // 
            // bnVendedor
            // 
            this.bnVendedor.AddNewItem = null;
            this.bnVendedor.CountItem = this.bindingNavigatorCountItem;
            this.bnVendedor.DeleteItem = null;
            this.bnVendedor.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2});
            this.bnVendedor.Location = new System.Drawing.Point(3, 18);
            this.bnVendedor.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bnVendedor.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bnVendedor.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bnVendedor.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bnVendedor.Name = "bnVendedor";
            this.bnVendedor.PositionItem = this.bindingNavigatorPositionItem;
            this.bnVendedor.Size = new System.Drawing.Size(291, 25);
            this.bnVendedor.TabIndex = 8;
            this.bnVendedor.Text = "Listado Vendedores";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(37, 22);
            this.bindingNavigatorCountItem.Text = "de {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Número total de elementos";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Mover primero";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Mover anterior";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Posición";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Posición actual";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Mover siguiente";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Mover último";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // txtCelularVendedor
            // 
            this.txtCelularVendedor.Location = new System.Drawing.Point(93, 114);
            this.txtCelularVendedor.Name = "txtCelularVendedor";
            this.txtCelularVendedor.ReadOnly = true;
            this.txtCelularVendedor.Size = new System.Drawing.Size(173, 22);
            this.txtCelularVendedor.TabIndex = 7;
            // 
            // txtNombreVendedor
            // 
            this.txtNombreVendedor.Location = new System.Drawing.Point(93, 82);
            this.txtNombreVendedor.Name = "txtNombreVendedor";
            this.txtNombreVendedor.ReadOnly = true;
            this.txtNombreVendedor.Size = new System.Drawing.Size(173, 22);
            this.txtNombreVendedor.TabIndex = 6;
            // 
            // txtCedulaVendedor
            // 
            this.txtCedulaVendedor.Location = new System.Drawing.Point(93, 51);
            this.txtCedulaVendedor.Name = "txtCedulaVendedor";
            this.txtCedulaVendedor.ReadOnly = true;
            this.txtCedulaVendedor.Size = new System.Drawing.Size(173, 22);
            this.txtCedulaVendedor.TabIndex = 5;
            // 
            // lblCedula
            // 
            this.lblCedula.AutoSize = true;
            this.lblCedula.Location = new System.Drawing.Point(12, 51);
            this.lblCedula.Name = "lblCedula";
            this.lblCedula.Size = new System.Drawing.Size(51, 16);
            this.lblCedula.TabIndex = 4;
            this.lblCedula.Text = "Cedula";
            // 
            // lblNombreVendedor
            // 
            this.lblNombreVendedor.AutoSize = true;
            this.lblNombreVendedor.Location = new System.Drawing.Point(12, 82);
            this.lblNombreVendedor.Name = "lblNombreVendedor";
            this.lblNombreVendedor.Size = new System.Drawing.Size(64, 16);
            this.lblNombreVendedor.TabIndex = 3;
            this.lblNombreVendedor.Text = "Nombres";
            // 
            // lblCelularVendedor
            // 
            this.lblCelularVendedor.AutoSize = true;
            this.lblCelularVendedor.Location = new System.Drawing.Point(11, 114);
            this.lblCelularVendedor.Name = "lblCelularVendedor";
            this.lblCelularVendedor.Size = new System.Drawing.Size(50, 16);
            this.lblCelularVendedor.TabIndex = 2;
            this.lblCelularVendedor.Text = "Celular";
            // 
            // lblEmailVendedor
            // 
            this.lblEmailVendedor.AutoSize = true;
            this.lblEmailVendedor.Location = new System.Drawing.Point(10, 148);
            this.lblEmailVendedor.Name = "lblEmailVendedor";
            this.lblEmailVendedor.Size = new System.Drawing.Size(42, 16);
            this.lblEmailVendedor.TabIndex = 1;
            this.lblEmailVendedor.Text = "Email";
            // 
            // txtEmailVendedor
            // 
            this.txtEmailVendedor.Location = new System.Drawing.Point(93, 148);
            this.txtEmailVendedor.Name = "txtEmailVendedor";
            this.txtEmailVendedor.ReadOnly = true;
            this.txtEmailVendedor.Size = new System.Drawing.Size(173, 22);
            this.txtEmailVendedor.TabIndex = 0;
            // 
            // gbConsulta
            // 
            this.gbConsulta.Controls.Add(this.cbCriterio2);
            this.gbConsulta.Controls.Add(this.cbCriterio1);
            this.gbConsulta.Controls.Add(this.btnConsulta);
            this.gbConsulta.Controls.Add(this.txtConsulta);
            this.gbConsulta.Location = new System.Drawing.Point(9, 30);
            this.gbConsulta.Name = "gbConsulta";
            this.gbConsulta.Size = new System.Drawing.Size(968, 58);
            this.gbConsulta.TabIndex = 2;
            this.gbConsulta.TabStop = false;
            this.gbConsulta.Text = "Realizar Consultas";
            // 
            // cbCriterio2
            // 
            this.cbCriterio2.DisplayMember = "Nombre2";
            this.cbCriterio2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCriterio2.Enabled = false;
            this.cbCriterio2.FormattingEnabled = true;
            this.cbCriterio2.Location = new System.Drawing.Point(166, 22);
            this.cbCriterio2.Name = "cbCriterio2";
            this.cbCriterio2.Size = new System.Drawing.Size(132, 24);
            this.cbCriterio2.TabIndex = 6;
            this.cbCriterio2.ValueMember = "Id2";
            // 
            // cbCriterio1
            // 
            this.cbCriterio1.DisplayMember = "Nombre1";
            this.cbCriterio1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCriterio1.FormattingEnabled = true;
            this.cbCriterio1.Location = new System.Drawing.Point(16, 22);
            this.cbCriterio1.Name = "cbCriterio1";
            this.cbCriterio1.Size = new System.Drawing.Size(134, 24);
            this.cbCriterio1.TabIndex = 5;
            this.cbCriterio1.ValueMember = "Id1";
            this.cbCriterio1.SelectionChangeCommitted += new System.EventHandler(this.cbCriterio1_SelectionChangeCommitted);
            // 
            // btnConsulta
            // 
            this.btnConsulta.Image = ((System.Drawing.Image)(resources.GetObject("btnConsulta.Image")));
            this.btnConsulta.Location = new System.Drawing.Point(521, 22);
            this.btnConsulta.Name = "btnConsulta";
            this.btnConsulta.Size = new System.Drawing.Size(29, 23);
            this.btnConsulta.TabIndex = 4;
            this.btnConsulta.UseVisualStyleBackColor = true;
            this.btnConsulta.Click += new System.EventHandler(this.btnConsulta_Click);
            // 
            // txtConsulta
            // 
            this.txtConsulta.Location = new System.Drawing.Point(315, 23);
            this.txtConsulta.Name = "txtConsulta";
            this.txtConsulta.Size = new System.Drawing.Size(188, 22);
            this.txtConsulta.TabIndex = 3;
            this.txtConsulta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtConsulta_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvListadoProveedor);
            this.groupBox1.Location = new System.Drawing.Point(5, 92);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(970, 284);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Resultado de la Consulta";
            // 
            // dgvListadoProveedor
            // 
            this.dgvListadoProveedor.AllowUserToAddRows = false;
            this.dgvListadoProveedor.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvListadoProveedor.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvListadoProveedor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column10,
            this.Column11,
            this.Column12,
            this.Column13,
            this.Column14,
            this.Column15,
            this.Column16,
            this.Ciudad,
            this.Column18});
            this.dgvListadoProveedor.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvListadoProveedor.Location = new System.Drawing.Point(5, 17);
            this.dgvListadoProveedor.Name = "dgvListadoProveedor";
            this.dgvListadoProveedor.RowHeadersVisible = false;
            this.dgvListadoProveedor.Size = new System.Drawing.Size(959, 261);
            this.dgvListadoProveedor.TabIndex = 0;
            this.dgvListadoProveedor.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListadoProveedor_CellDoubleClick);
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "Codigo";
            this.Column10.HeaderText = "Codigo";
            this.Column10.Name = "Column10";
            // 
            // Column11
            // 
            this.Column11.DataPropertyName = "Nit";
            this.Column11.HeaderText = "Nit o Cedula";
            this.Column11.Name = "Column11";
            this.Column11.Width = 110;
            // 
            // Column12
            // 
            this.Column12.DataPropertyName = "Regimen";
            this.Column12.HeaderText = "Regimen";
            this.Column12.Name = "Column12";
            // 
            // Column13
            // 
            this.Column13.DataPropertyName = "Nombre";
            this.Column13.HeaderText = "Nombre";
            this.Column13.Name = "Column13";
            this.Column13.Width = 250;
            // 
            // Column14
            // 
            this.Column14.DataPropertyName = "Telefono";
            this.Column14.HeaderText = "Telefono";
            this.Column14.Name = "Column14";
            this.Column14.Visible = false;
            this.Column14.Width = 115;
            // 
            // Column15
            // 
            this.Column15.DataPropertyName = "Celular";
            this.Column15.HeaderText = "Celular";
            this.Column15.Name = "Column15";
            // 
            // Column16
            // 
            this.Column16.DataPropertyName = "Direccion";
            this.Column16.HeaderText = "Direccion";
            this.Column16.Name = "Column16";
            this.Column16.Width = 150;
            // 
            // Ciudad
            // 
            this.Ciudad.DataPropertyName = "Ciudad";
            this.Ciudad.HeaderText = "Ciudad";
            this.Ciudad.Name = "Ciudad";
            this.Ciudad.Width = 130;
            // 
            // Column18
            // 
            this.Column18.DataPropertyName = "Estado";
            this.Column18.HeaderText = "Estado";
            this.Column18.Name = "Column18";
            this.Column18.Visible = false;
            // 
            // tsMenuBusqueda
            // 
            this.tsMenuBusqueda.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsMenuBusqueda.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnListarTodos,
            this.tsbtnEditarProveedor,
            this.tsbtnEliminar,
            this.tsbtnConsultaSalir});
            this.tsMenuBusqueda.Location = new System.Drawing.Point(3, 3);
            this.tsMenuBusqueda.Name = "tsMenuBusqueda";
            this.tsMenuBusqueda.Size = new System.Drawing.Size(977, 25);
            this.tsMenuBusqueda.TabIndex = 0;
            this.tsMenuBusqueda.Text = "toolStrip1";
            // 
            // tsbtnListarTodos
            // 
            this.tsbtnListarTodos.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsbtnListarTodos.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnListarTodos.Image")));
            this.tsbtnListarTodos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnListarTodos.Name = "tsbtnListarTodos";
            this.tsbtnListarTodos.Size = new System.Drawing.Size(100, 22);
            this.tsbtnListarTodos.Text = "Listar Todos";
            this.tsbtnListarTodos.Click += new System.EventHandler(this.tsbtnListarTodos_Click);
            // 
            // tsbtnEditarProveedor
            // 
            this.tsbtnEditarProveedor.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnEditarProveedor.Image")));
            this.tsbtnEditarProveedor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnEditarProveedor.Name = "tsbtnEditarProveedor";
            this.tsbtnEditarProveedor.Size = new System.Drawing.Size(62, 22);
            this.tsbtnEditarProveedor.Text = "Editar";
            this.tsbtnEditarProveedor.Click += new System.EventHandler(this.tsbtnEditarProveedor_Click);
            // 
            // tsbtnEliminar
            // 
            this.tsbtnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnEliminar.Image")));
            this.tsbtnEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnEliminar.Name = "tsbtnEliminar";
            this.tsbtnEliminar.Size = new System.Drawing.Size(74, 22);
            this.tsbtnEliminar.Text = "Eliminar";
            this.tsbtnEliminar.Click += new System.EventHandler(this.tsbtnEliminar_Click);
            // 
            // tsbtnConsultaSalir
            // 
            this.tsbtnConsultaSalir.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnConsultaSalir.Image")));
            this.tsbtnConsultaSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnConsultaSalir.Name = "tsbtnConsultaSalir";
            this.tsbtnConsultaSalir.Size = new System.Drawing.Size(53, 22);
            this.tsbtnConsultaSalir.Text = "Salir";
            this.tsbtnConsultaSalir.Click += new System.EventHandler(this.tsbtnConsultaSalir_Click);
            // 
            // frmProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(994, 636);
            this.Controls.Add(this.tcProveedor);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmProveedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Proveedor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmProveedor_FormClosing);
            this.Load += new System.EventHandler(this.frmCrearProveedor_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmProveedor_KeyDown);
            this.InformacionProveedor.ResumeLayout(false);
            this.InformacionProveedor.PerformLayout();
            this.InformacionContacto.ResumeLayout(false);
            this.InformacionContacto.PerformLayout();
            this.InformacionBancaria.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosBancario)).EndInit();
            this.InformacionVendedor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosVendedor)).EndInit();
            this.tcProveedor.ResumeLayout(false);
            this.tpCrearProveedor.ResumeLayout(false);
            this.tpCrearProveedor.PerformLayout();
            this.tsMenuCrearProveedor.ResumeLayout(false);
            this.tsMenuCrearProveedor.PerformLayout();
            this.tpBusquedasProveedor.ResumeLayout(false);
            this.tpBusquedasProveedor.PerformLayout();
            this.gbCuentasBanco.ResumeLayout(false);
            this.gbCuentasBanco.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bnCtaBanco)).EndInit();
            this.bnCtaBanco.ResumeLayout(false);
            this.bnCtaBanco.PerformLayout();
            this.gbContacto.ResumeLayout(false);
            this.gbContacto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bnVendedor)).EndInit();
            this.bnVendedor.ResumeLayout(false);
            this.bnVendedor.PerformLayout();
            this.gbConsulta.ResumeLayout(false);
            this.gbConsulta.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoProveedor)).EndInit();
            this.tsMenuBusqueda.ResumeLayout(false);
            this.tsMenuBusqueda.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        #region Metodos set get

        public System.Windows.Forms.TabPage PestaniaCrearProveedor
        {
            set { this.tpCrearProveedor = value; }
            get { return this.tpCrearProveedor; }
        }

        #endregion

        private System.Windows.Forms.GroupBox InformacionProveedor;
        private System.Windows.Forms.GroupBox InformacionContacto;
        private System.Windows.Forms.GroupBox InformacionBancaria;
        private System.Windows.Forms.Label lblCodigoInterno;
        private System.Windows.Forms.Label lblNit;
        private System.Windows.Forms.ComboBox cbRegimen;
        private System.Windows.Forms.LinkLabel lkbGenerar;
        private System.Windows.Forms.TextBox txtNombreComercial;
        private System.Windows.Forms.TextBox txtRazonSocial;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblRazonSocial;
        private System.Windows.Forms.Label lblNombreComercial;
        private System.Windows.Forms.Label lblRegimen;
        private System.Windows.Forms.TextBox txtIndicativoFax;
        private System.Windows.Forms.TextBox txtIndicativoTel;
        private System.Windows.Forms.TextBox txtNumeroFax;
        private System.Windows.Forms.TextBox txtCelular;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label lblPaginaWeb;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblDepartamento;
        private System.Windows.Forms.Label lblMunicipio;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.Label lblFax;
        private System.Windows.Forms.Label lblCelular;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox txtPaginaWeb;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.GroupBox InformacionVendedor;
        private System.Windows.Forms.DataGridView dgvDatosVendedor;
        private System.Windows.Forms.Button btnAgregarInformacionBancaria;
        private System.Windows.Forms.Button btnAgregarInformacionVendedor;
        private System.Windows.Forms.TabPage tpCrearProveedor;
        private System.Windows.Forms.TabPage tpBusquedasProveedor;
        private System.Windows.Forms.DataGridView dgvDatosBancario;
        private System.Windows.Forms.ToolStrip tsMenuBusqueda;
        private System.Windows.Forms.ToolStripButton tsbtnListarTodos;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvListadoProveedor;
        private System.Windows.Forms.ComboBox cbDepartamento;
        private System.Windows.Forms.ComboBox cbCiudad;
        private System.Windows.Forms.Button btnEliminarCuenta;
        private System.Windows.Forms.ToolStrip tsMenuCrearProveedor;
        private System.Windows.Forms.ToolStripButton tsbtnGuardar;
        private System.Windows.Forms.Button btnEliminarVendedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.ToolStripButton tsbtnSalir;
        private System.Windows.Forms.GroupBox gbConsulta;
        private System.Windows.Forms.TextBox txtConsulta;
        private System.Windows.Forms.Button btnConsulta;
        private System.Windows.Forms.GroupBox gbContacto;
        private System.Windows.Forms.Label lblEmailVendedor;
        private System.Windows.Forms.TextBox txtEmailVendedor;
        private System.Windows.Forms.Label lblNombreVendedor;
        private System.Windows.Forms.Label lblCelularVendedor;
        private System.Windows.Forms.Label lblCedula;
        private System.Windows.Forms.TextBox txtCelularVendedor;
        private System.Windows.Forms.TextBox txtNombreVendedor;
        private System.Windows.Forms.TextBox txtCedulaVendedor;
        private System.Windows.Forms.BindingNavigator bnVendedor;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.Label lblEstadoVendedor;
        private System.Windows.Forms.TextBox txtEstadoVendedor;
        private System.Windows.Forms.GroupBox gbCuentasBanco;
        private System.Windows.Forms.Label lblTipoCuenta;
        private System.Windows.Forms.Label lblBanco;
        private System.Windows.Forms.Label lblTitular;
        private System.Windows.Forms.Label lblNumero;
        private System.Windows.Forms.TextBox txtNumeroCta;
        private System.Windows.Forms.TextBox txtTitularCta;
        private System.Windows.Forms.TextBox txtTipoCta;
        private System.Windows.Forms.TextBox txtBancoCta;
        private System.Windows.Forms.BindingNavigator bnCtaBanco;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem1;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator3;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem1;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator4;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem1;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator5;
        private System.Windows.Forms.ComboBox cbCriterio1;
        private System.Windows.Forms.ComboBox cbCriterio2;
        private System.Windows.Forms.ToolStripButton tsbtnEditarProveedor;
        private System.Windows.Forms.ToolStripButton tsbtnEliminar;
        private System.Windows.Forms.ToolStripButton tsbtnConsultaSalir;
        public System.Windows.Forms.TabControl tcProveedor;
        public System.Windows.Forms.TextBox txtCodigoInterno;
        public System.Windows.Forms.TextBox txtNitCedula;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column15;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column16;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ciudad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column18;
    }
}