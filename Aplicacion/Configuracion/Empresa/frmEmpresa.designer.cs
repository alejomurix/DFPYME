namespace Aplicacion.Configuracion.Empresa
{
    partial class frmEmpresa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmpresa));
            this.DatosEmpresa = new System.Windows.Forms.GroupBox();
            this.chkIva = new System.Windows.Forms.CheckBox();
            this.txtRegimen = new System.Windows.Forms.TextBox();
            this.btnEditaRegimen = new System.Windows.Forms.Button();
            this.txtRepresentanteLegal = new System.Windows.Forms.TextBox();
            this.lblRepresentanteLegal = new System.Windows.Forms.Label();
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
            this.InformacionEmpresa = new System.Windows.Forms.GroupBox();
            this.btnEditaMunicipio = new System.Windows.Forms.Button();
            this.txtMunicipio = new System.Windows.Forms.TextBox();
            this.txtDepto = new System.Windows.Forms.TextBox();
            this.btnEditaDepte = new System.Windows.Forms.Button();
            this.rbInactivo = new System.Windows.Forms.RadioButton();
            this.rbActivo = new System.Windows.Forms.RadioButton();
            this.lblDepartamento = new System.Windows.Forms.Label();
            this.cbDepartamento = new System.Windows.Forms.ComboBox();
            this.lblMunicipio = new System.Windows.Forms.Label();
            this.cbCiudad = new System.Windows.Forms.ComboBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.lblCelular = new System.Windows.Forms.Label();
            this.txtCelular = new System.Windows.Forms.TextBox();
            this.lblFax = new System.Windows.Forms.Label();
            this.txtNumeroFax = new System.Windows.Forms.TextBox();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblPaginaWeb = new System.Windows.Forms.Label();
            this.txtPaginaWeb = new System.Windows.Forms.TextBox();
            this.InformacionBancaria = new System.Windows.Forms.GroupBox();
            this.btnEditarCuenta = new System.Windows.Forms.Button();
            this.btnAgregarInformacionBancaria = new System.Windows.Forms.Button();
            this.btnEliminarCuenta = new System.Windows.Forms.Button();
            this.dgvDatosBancario = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idTipoCuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsMenuCrearProveedor = new System.Windows.Forms.ToolStrip();
            this.tsbtnGuardar = new System.Windows.Forms.ToolStripButton();
            this.tsbtnSalir = new System.Windows.Forms.ToolStripButton();
            this.DatosEmpresa.SuspendLayout();
            this.InformacionEmpresa.SuspendLayout();
            this.InformacionBancaria.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosBancario)).BeginInit();
            this.tsMenuCrearProveedor.SuspendLayout();
            this.SuspendLayout();
            // 
            // DatosEmpresa
            // 
            this.DatosEmpresa.Controls.Add(this.chkIva);
            this.DatosEmpresa.Controls.Add(this.txtRegimen);
            this.DatosEmpresa.Controls.Add(this.btnEditaRegimen);
            this.DatosEmpresa.Controls.Add(this.txtRepresentanteLegal);
            this.DatosEmpresa.Controls.Add(this.lblRepresentanteLegal);
            this.DatosEmpresa.Controls.Add(this.lblNit);
            this.DatosEmpresa.Controls.Add(this.txtNitCedula);
            this.DatosEmpresa.Controls.Add(this.lblRegimen);
            this.DatosEmpresa.Controls.Add(this.cbRegimen);
            this.DatosEmpresa.Controls.Add(this.lblRazonSocial);
            this.DatosEmpresa.Controls.Add(this.txtRazonSocial);
            this.DatosEmpresa.Controls.Add(this.lblNombreComercial);
            this.DatosEmpresa.Controls.Add(this.txtNombreComercial);
            this.DatosEmpresa.Controls.Add(this.lblDescripcion);
            this.DatosEmpresa.Controls.Add(this.txtDescripcion);
            this.DatosEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DatosEmpresa.Location = new System.Drawing.Point(13, 44);
            this.DatosEmpresa.Margin = new System.Windows.Forms.Padding(4);
            this.DatosEmpresa.Name = "DatosEmpresa";
            this.DatosEmpresa.Padding = new System.Windows.Forms.Padding(4);
            this.DatosEmpresa.Size = new System.Drawing.Size(986, 123);
            this.DatosEmpresa.TabIndex = 1;
            this.DatosEmpresa.TabStop = false;
            this.DatosEmpresa.Text = "Datos Empresa";
            // 
            // chkIva
            // 
            this.chkIva.AutoSize = true;
            this.chkIva.Location = new System.Drawing.Point(829, 71);
            this.chkIva.Name = "chkIva";
            this.chkIva.Size = new System.Drawing.Size(107, 20);
            this.chkIva.TabIndex = 14;
            this.chkIva.Text = "Recauda IVA";
            this.chkIva.UseVisualStyleBackColor = true;
            // 
            // txtRegimen
            // 
            this.txtRegimen.Enabled = false;
            this.txtRegimen.Location = new System.Drawing.Point(808, 25);
            this.txtRegimen.Name = "txtRegimen";
            this.txtRegimen.Size = new System.Drawing.Size(128, 22);
            this.txtRegimen.TabIndex = 10;
            // 
            // btnEditaRegimen
            // 
            this.btnEditaRegimen.Image = ((System.Drawing.Image)(resources.GetObject("btnEditaRegimen.Image")));
            this.btnEditaRegimen.Location = new System.Drawing.Point(941, 25);
            this.btnEditaRegimen.Name = "btnEditaRegimen";
            this.btnEditaRegimen.Size = new System.Drawing.Size(38, 23);
            this.btnEditaRegimen.TabIndex = 2;
            this.btnEditaRegimen.UseVisualStyleBackColor = true;
            this.btnEditaRegimen.Click += new System.EventHandler(this.btnEditaRegimen_Click);
            // 
            // txtRepresentanteLegal
            // 
            this.txtRepresentanteLegal.Location = new System.Drawing.Point(519, 25);
            this.txtRepresentanteLegal.MaxLength = 255;
            this.txtRepresentanteLegal.Name = "txtRepresentanteLegal";
            this.txtRepresentanteLegal.Size = new System.Drawing.Size(202, 22);
            this.txtRepresentanteLegal.TabIndex = 1;
            this.txtRepresentanteLegal.Validating += new System.ComponentModel.CancelEventHandler(this.txtRepresentanteLegal_Validating);
            // 
            // lblRepresentanteLegal
            // 
            this.lblRepresentanteLegal.AutoSize = true;
            this.lblRepresentanteLegal.Location = new System.Drawing.Point(379, 28);
            this.lblRepresentanteLegal.Name = "lblRepresentanteLegal";
            this.lblRepresentanteLegal.Size = new System.Drawing.Size(134, 16);
            this.lblRepresentanteLegal.TabIndex = 8;
            this.lblRepresentanteLegal.Text = "Representante Legal";
            // 
            // lblNit
            // 
            this.lblNit.AutoSize = true;
            this.lblNit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblNit.Location = new System.Drawing.Point(12, 28);
            this.lblNit.Name = "lblNit";
            this.lblNit.Size = new System.Drawing.Size(87, 16);
            this.lblNit.TabIndex = 7;
            this.lblNit.Text = "NIT o Cedula";
            // 
            // txtNitCedula
            // 
            this.txtNitCedula.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNitCedula.Location = new System.Drawing.Point(152, 25);
            this.txtNitCedula.MaxLength = 30;
            this.txtNitCedula.Name = "txtNitCedula";
            this.txtNitCedula.Size = new System.Drawing.Size(208, 22);
            this.txtNitCedula.TabIndex = 0;
            this.txtNitCedula.Validating += new System.ComponentModel.CancelEventHandler(this.txtNitCedula_Validating);
            // 
            // lblRegimen
            // 
            this.lblRegimen.AutoSize = true;
            this.lblRegimen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblRegimen.Location = new System.Drawing.Point(738, 28);
            this.lblRegimen.Name = "lblRegimen";
            this.lblRegimen.Size = new System.Drawing.Size(63, 16);
            this.lblRegimen.TabIndex = 9;
            this.lblRegimen.Text = "Regimen";
            // 
            // cbRegimen
            // 
            this.cbRegimen.DisplayMember = "NombreRegimen";
            this.cbRegimen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRegimen.FormattingEnabled = true;
            this.cbRegimen.Location = new System.Drawing.Point(807, 25);
            this.cbRegimen.Name = "cbRegimen";
            this.cbRegimen.Size = new System.Drawing.Size(128, 24);
            this.cbRegimen.TabIndex = 3;
            this.cbRegimen.ValueMember = "IdRegimen";
            this.cbRegimen.Visible = false;
            this.cbRegimen.SelectedIndexChanged += new System.EventHandler(this.cbRegimen_SelectedIndexChanged);
            // 
            // lblRazonSocial
            // 
            this.lblRazonSocial.AutoSize = true;
            this.lblRazonSocial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblRazonSocial.Location = new System.Drawing.Point(11, 57);
            this.lblRazonSocial.Name = "lblRazonSocial";
            this.lblRazonSocial.Size = new System.Drawing.Size(88, 16);
            this.lblRazonSocial.TabIndex = 11;
            this.lblRazonSocial.Text = "Razón Social";
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRazonSocial.Location = new System.Drawing.Point(152, 55);
            this.txtRazonSocial.MaxLength = 255;
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.Size = new System.Drawing.Size(208, 22);
            this.txtRazonSocial.TabIndex = 4;
            this.txtRazonSocial.Validating += new System.ComponentModel.CancelEventHandler(this.txtRazonSocial_Validating);
            // 
            // lblNombreComercial
            // 
            this.lblNombreComercial.AutoSize = true;
            this.lblNombreComercial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreComercial.Location = new System.Drawing.Point(10, 90);
            this.lblNombreComercial.Name = "lblNombreComercial";
            this.lblNombreComercial.Size = new System.Drawing.Size(121, 16);
            this.lblNombreComercial.TabIndex = 13;
            this.lblNombreComercial.Text = "Nombre Comercial";
            // 
            // txtNombreComercial
            // 
            this.txtNombreComercial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreComercial.Location = new System.Drawing.Point(152, 88);
            this.txtNombreComercial.MaxLength = 255;
            this.txtNombreComercial.Name = "txtNombreComercial";
            this.txtNombreComercial.Size = new System.Drawing.Size(208, 22);
            this.txtNombreComercial.TabIndex = 5;
            this.txtNombreComercial.Validating += new System.ComponentModel.CancelEventHandler(this.txtNombreComercial_Validating);
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblDescripcion.Location = new System.Drawing.Point(379, 57);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(80, 16);
            this.lblDescripcion.TabIndex = 12;
            this.lblDescripcion.Text = "Descripción";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.Location = new System.Drawing.Point(519, 55);
            this.txtDescripcion.MaxLength = 500;
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(282, 55);
            this.txtDescripcion.TabIndex = 6;
            this.txtDescripcion.Validating += new System.ComponentModel.CancelEventHandler(this.txtDescripcion_Validating);
            // 
            // InformacionEmpresa
            // 
            this.InformacionEmpresa.Controls.Add(this.btnEditaMunicipio);
            this.InformacionEmpresa.Controls.Add(this.txtMunicipio);
            this.InformacionEmpresa.Controls.Add(this.txtDepto);
            this.InformacionEmpresa.Controls.Add(this.btnEditaDepte);
            this.InformacionEmpresa.Controls.Add(this.rbInactivo);
            this.InformacionEmpresa.Controls.Add(this.rbActivo);
            this.InformacionEmpresa.Controls.Add(this.lblDepartamento);
            this.InformacionEmpresa.Controls.Add(this.cbDepartamento);
            this.InformacionEmpresa.Controls.Add(this.lblMunicipio);
            this.InformacionEmpresa.Controls.Add(this.cbCiudad);
            this.InformacionEmpresa.Controls.Add(this.lblTelefono);
            this.InformacionEmpresa.Controls.Add(this.txtTelefono);
            this.InformacionEmpresa.Controls.Add(this.lblCelular);
            this.InformacionEmpresa.Controls.Add(this.txtCelular);
            this.InformacionEmpresa.Controls.Add(this.lblFax);
            this.InformacionEmpresa.Controls.Add(this.txtNumeroFax);
            this.InformacionEmpresa.Controls.Add(this.lblDireccion);
            this.InformacionEmpresa.Controls.Add(this.txtDireccion);
            this.InformacionEmpresa.Controls.Add(this.lblEmail);
            this.InformacionEmpresa.Controls.Add(this.txtEmail);
            this.InformacionEmpresa.Controls.Add(this.lblPaginaWeb);
            this.InformacionEmpresa.Controls.Add(this.txtPaginaWeb);
            this.InformacionEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.InformacionEmpresa.Location = new System.Drawing.Point(14, 175);
            this.InformacionEmpresa.Margin = new System.Windows.Forms.Padding(4);
            this.InformacionEmpresa.Name = "InformacionEmpresa";
            this.InformacionEmpresa.Padding = new System.Windows.Forms.Padding(4);
            this.InformacionEmpresa.Size = new System.Drawing.Size(985, 145);
            this.InformacionEmpresa.TabIndex = 2;
            this.InformacionEmpresa.TabStop = false;
            this.InformacionEmpresa.Text = "Información de la Empresa";
            // 
            // btnEditaMunicipio
            // 
            this.btnEditaMunicipio.Image = ((System.Drawing.Image)(resources.GetObject("btnEditaMunicipio.Image")));
            this.btnEditaMunicipio.Location = new System.Drawing.Point(597, 63);
            this.btnEditaMunicipio.Name = "btnEditaMunicipio";
            this.btnEditaMunicipio.Size = new System.Drawing.Size(42, 23);
            this.btnEditaMunicipio.TabIndex = 5;
            this.btnEditaMunicipio.UseVisualStyleBackColor = true;
            this.btnEditaMunicipio.Click += new System.EventHandler(this.btnEditaMunicipio_Click);
            // 
            // txtMunicipio
            // 
            this.txtMunicipio.Enabled = false;
            this.txtMunicipio.Location = new System.Drawing.Point(433, 63);
            this.txtMunicipio.Name = "txtMunicipio";
            this.txtMunicipio.Size = new System.Drawing.Size(158, 22);
            this.txtMunicipio.TabIndex = 18;
            // 
            // txtDepto
            // 
            this.txtDepto.Enabled = false;
            this.txtDepto.Location = new System.Drawing.Point(114, 63);
            this.txtDepto.Name = "txtDepto";
            this.txtDepto.Size = new System.Drawing.Size(175, 22);
            this.txtDepto.TabIndex = 16;
            // 
            // btnEditaDepte
            // 
            this.btnEditaDepte.Image = ((System.Drawing.Image)(resources.GetObject("btnEditaDepte.Image")));
            this.btnEditaDepte.Location = new System.Drawing.Point(296, 63);
            this.btnEditaDepte.Name = "btnEditaDepte";
            this.btnEditaDepte.Size = new System.Drawing.Size(42, 23);
            this.btnEditaDepte.TabIndex = 3;
            this.btnEditaDepte.UseVisualStyleBackColor = true;
            this.btnEditaDepte.Click += new System.EventHandler(this.btnEditaDepte_Click);
            // 
            // rbInactivo
            // 
            this.rbInactivo.AutoSize = true;
            this.rbInactivo.Location = new System.Drawing.Point(862, 104);
            this.rbInactivo.Name = "rbInactivo";
            this.rbInactivo.Size = new System.Drawing.Size(72, 20);
            this.rbInactivo.TabIndex = 11;
            this.rbInactivo.Text = "Inactivo";
            this.rbInactivo.UseVisualStyleBackColor = true;
            // 
            // rbActivo
            // 
            this.rbActivo.AutoSize = true;
            this.rbActivo.Checked = true;
            this.rbActivo.Location = new System.Drawing.Point(753, 104);
            this.rbActivo.Name = "rbActivo";
            this.rbActivo.Size = new System.Drawing.Size(63, 20);
            this.rbActivo.TabIndex = 10;
            this.rbActivo.TabStop = true;
            this.rbActivo.Text = "Activo";
            this.rbActivo.UseVisualStyleBackColor = true;
            // 
            // lblDepartamento
            // 
            this.lblDepartamento.AutoSize = true;
            this.lblDepartamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDepartamento.Location = new System.Drawing.Point(14, 66);
            this.lblDepartamento.Name = "lblDepartamento";
            this.lblDepartamento.Size = new System.Drawing.Size(94, 16);
            this.lblDepartamento.TabIndex = 15;
            this.lblDepartamento.Text = "Departamento";
            // 
            // cbDepartamento
            // 
            this.cbDepartamento.DisplayMember = "NombreDepartamento";
            this.cbDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDepartamento.FormattingEnabled = true;
            this.cbDepartamento.Location = new System.Drawing.Point(114, 63);
            this.cbDepartamento.Name = "cbDepartamento";
            this.cbDepartamento.Size = new System.Drawing.Size(176, 24);
            this.cbDepartamento.TabIndex = 4;
            this.cbDepartamento.ValueMember = "IdDepartamento";
            this.cbDepartamento.Visible = false;
            this.cbDepartamento.SelectionChangeCommitted += new System.EventHandler(this.cbDepartamento_SelectionChangeCommitted);
            // 
            // lblMunicipio
            // 
            this.lblMunicipio.AutoSize = true;
            this.lblMunicipio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblMunicipio.Location = new System.Drawing.Point(344, 67);
            this.lblMunicipio.Name = "lblMunicipio";
            this.lblMunicipio.Size = new System.Drawing.Size(65, 16);
            this.lblMunicipio.TabIndex = 17;
            this.lblMunicipio.Text = "Municipio";
            // 
            // cbCiudad
            // 
            this.cbCiudad.DisplayMember = "NombreCiudad";
            this.cbCiudad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCiudad.Location = new System.Drawing.Point(433, 61);
            this.cbCiudad.Name = "cbCiudad";
            this.cbCiudad.Size = new System.Drawing.Size(158, 24);
            this.cbCiudad.TabIndex = 6;
            this.cbCiudad.ValueMember = "IdCiudad";
            this.cbCiudad.Visible = false;
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblTelefono.Location = new System.Drawing.Point(12, 28);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(62, 16);
            this.lblTelefono.TabIndex = 12;
            this.lblTelefono.Text = "Teléfono";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelefono.Location = new System.Drawing.Point(141, 25);
            this.txtTelefono.MaxLength = 40;
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(176, 22);
            this.txtTelefono.TabIndex = 0;
            this.txtTelefono.Validating += new System.ComponentModel.CancelEventHandler(this.txtTelefono_Validating);
            // 
            // lblCelular
            // 
            this.lblCelular.AutoSize = true;
            this.lblCelular.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblCelular.Location = new System.Drawing.Point(344, 28);
            this.lblCelular.Name = "lblCelular";
            this.lblCelular.Size = new System.Drawing.Size(50, 16);
            this.lblCelular.TabIndex = 13;
            this.lblCelular.Text = "Celular";
            // 
            // txtCelular
            // 
            this.txtCelular.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCelular.Location = new System.Drawing.Point(433, 25);
            this.txtCelular.MaxLength = 40;
            this.txtCelular.Name = "txtCelular";
            this.txtCelular.Size = new System.Drawing.Size(158, 22);
            this.txtCelular.TabIndex = 1;
            this.txtCelular.Validating += new System.ComponentModel.CancelEventHandler(this.txtCelular_Validating);
            // 
            // lblFax
            // 
            this.lblFax.AutoSize = true;
            this.lblFax.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFax.Location = new System.Drawing.Point(645, 28);
            this.lblFax.Name = "lblFax";
            this.lblFax.Size = new System.Drawing.Size(30, 16);
            this.lblFax.TabIndex = 14;
            this.lblFax.Text = "Fax";
            // 
            // txtNumeroFax
            // 
            this.txtNumeroFax.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumeroFax.Location = new System.Drawing.Point(720, 25);
            this.txtNumeroFax.MaxLength = 40;
            this.txtNumeroFax.Name = "txtNumeroFax";
            this.txtNumeroFax.Size = new System.Drawing.Size(215, 22);
            this.txtNumeroFax.TabIndex = 2;
            this.txtNumeroFax.Validating += new System.ComponentModel.CancelEventHandler(this.txtNumeroFax_Validating);
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblDireccion.Location = new System.Drawing.Point(645, 66);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(65, 16);
            this.lblDireccion.TabIndex = 19;
            this.lblDireccion.Text = "Dirección";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDireccion.Location = new System.Drawing.Point(720, 63);
            this.txtDireccion.MaxLength = 255;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(215, 22);
            this.txtDireccion.TabIndex = 7;
            this.txtDireccion.Validating += new System.ComponentModel.CancelEventHandler(this.txtDireccion_Validating);
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(12, 106);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(46, 16);
            this.lblEmail.TabIndex = 20;
            this.lblEmail.Text = "E-mail";
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(93, 103);
            this.txtEmail.MaxLength = 255;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(224, 22);
            this.txtEmail.TabIndex = 8;
            this.txtEmail.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmail_Validating);
            // 
            // lblPaginaWeb
            // 
            this.lblPaginaWeb.AutoSize = true;
            this.lblPaginaWeb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaginaWeb.Location = new System.Drawing.Point(344, 106);
            this.lblPaginaWeb.Name = "lblPaginaWeb";
            this.lblPaginaWeb.Size = new System.Drawing.Size(83, 16);
            this.lblPaginaWeb.TabIndex = 21;
            this.lblPaginaWeb.Text = "Pagina Web";
            // 
            // txtPaginaWeb
            // 
            this.txtPaginaWeb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaginaWeb.Location = new System.Drawing.Point(433, 103);
            this.txtPaginaWeb.MaxLength = 255;
            this.txtPaginaWeb.Name = "txtPaginaWeb";
            this.txtPaginaWeb.Size = new System.Drawing.Size(272, 22);
            this.txtPaginaWeb.TabIndex = 9;
            this.txtPaginaWeb.Validating += new System.ComponentModel.CancelEventHandler(this.txtPaginaWeb_Validating);
            // 
            // InformacionBancaria
            // 
            this.InformacionBancaria.Controls.Add(this.btnEditarCuenta);
            this.InformacionBancaria.Controls.Add(this.btnAgregarInformacionBancaria);
            this.InformacionBancaria.Controls.Add(this.btnEliminarCuenta);
            this.InformacionBancaria.Controls.Add(this.dgvDatosBancario);
            this.InformacionBancaria.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.InformacionBancaria.Location = new System.Drawing.Point(14, 322);
            this.InformacionBancaria.Margin = new System.Windows.Forms.Padding(4);
            this.InformacionBancaria.Name = "InformacionBancaria";
            this.InformacionBancaria.Padding = new System.Windows.Forms.Padding(4);
            this.InformacionBancaria.Size = new System.Drawing.Size(950, 140);
            this.InformacionBancaria.TabIndex = 3;
            this.InformacionBancaria.TabStop = false;
            this.InformacionBancaria.Text = "Información Bancaria";
            // 
            // btnEditarCuenta
            // 
            this.btnEditarCuenta.Enabled = false;
            this.btnEditarCuenta.Image = ((System.Drawing.Image)(resources.GetObject("btnEditarCuenta.Image")));
            this.btnEditarCuenta.Location = new System.Drawing.Point(138, 32);
            this.btnEditarCuenta.Name = "btnEditarCuenta";
            this.btnEditarCuenta.Size = new System.Drawing.Size(31, 23);
            this.btnEditarCuenta.TabIndex = 2;
            this.btnEditarCuenta.UseVisualStyleBackColor = true;
            this.btnEditarCuenta.Click += new System.EventHandler(this.btnEditarCuenta_Click);
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
            this.id,
            this.idTipoCuenta,
            this.Column1,
            this.Column3,
            this.Column4,
            this.Column2});
            this.dgvDatosBancario.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvDatosBancario.Location = new System.Drawing.Point(248, 22);
            this.dgvDatosBancario.Name = "dgvDatosBancario";
            this.dgvDatosBancario.Size = new System.Drawing.Size(686, 110);
            this.dgvDatosBancario.TabIndex = 3;
            // 
            // id
            // 
            this.id.DataPropertyName = "IdCuenta";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.Visible = false;
            // 
            // idTipoCuenta
            // 
            this.idTipoCuenta.DataPropertyName = "idTipoCuenta";
            this.idTipoCuenta.HeaderText = "idTipoCuenta";
            this.idTipoCuenta.Name = "idTipoCuenta";
            this.idTipoCuenta.Visible = false;
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
            // tsMenuCrearProveedor
            // 
            this.tsMenuCrearProveedor.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsMenuCrearProveedor.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnGuardar,
            this.tsbtnSalir});
            this.tsMenuCrearProveedor.Location = new System.Drawing.Point(0, 0);
            this.tsMenuCrearProveedor.Name = "tsMenuCrearProveedor";
            this.tsMenuCrearProveedor.Size = new System.Drawing.Size(1012, 25);
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
            // frmEmpresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1012, 469);
            this.Controls.Add(this.InformacionBancaria);
            this.Controls.Add(this.InformacionEmpresa);
            this.Controls.Add(this.DatosEmpresa);
            this.Controls.Add(this.tsMenuCrearProveedor);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEmpresa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Empresa";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmProveedor_FormClosing);
            this.Load += new System.EventHandler(this.frmCrearProveedor_Load);
            this.DatosEmpresa.ResumeLayout(false);
            this.DatosEmpresa.PerformLayout();
            this.InformacionEmpresa.ResumeLayout(false);
            this.InformacionEmpresa.PerformLayout();
            this.InformacionBancaria.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosBancario)).EndInit();
            this.tsMenuCrearProveedor.ResumeLayout(false);
            this.tsMenuCrearProveedor.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        #region Metodos set get

       
        #endregion

        private System.Windows.Forms.GroupBox DatosEmpresa;
        private System.Windows.Forms.GroupBox InformacionEmpresa;
        private System.Windows.Forms.GroupBox InformacionBancaria;
        private System.Windows.Forms.Label lblNit;
        private System.Windows.Forms.ComboBox cbRegimen;
        private System.Windows.Forms.TextBox txtNombreComercial;
        private System.Windows.Forms.TextBox txtRazonSocial;
        private System.Windows.Forms.TextBox txtNitCedula;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblRazonSocial;
        private System.Windows.Forms.Label lblNombreComercial;
        private System.Windows.Forms.Label lblRegimen;
        private System.Windows.Forms.TextBox txtNumeroFax;
        private System.Windows.Forms.TextBox txtCelular;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label lblPaginaWeb;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.Label lblFax;
        private System.Windows.Forms.Label lblCelular;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox txtPaginaWeb;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Button btnAgregarInformacionBancaria;
        private System.Windows.Forms.DataGridView dgvDatosBancario;
        private System.Windows.Forms.Button btnEliminarCuenta;
        private System.Windows.Forms.TextBox txtRepresentanteLegal;
        private System.Windows.Forms.Label lblRepresentanteLegal;
        private System.Windows.Forms.ToolStrip tsMenuCrearProveedor;
        private System.Windows.Forms.ToolStripButton tsbtnGuardar;
        private System.Windows.Forms.ToolStripButton tsbtnSalir;
        private System.Windows.Forms.RadioButton rbInactivo;
        private System.Windows.Forms.RadioButton rbActivo;
        private System.Windows.Forms.Label lblDepartamento;
        private System.Windows.Forms.ComboBox cbDepartamento;
        private System.Windows.Forms.Label lblMunicipio;
        private System.Windows.Forms.ComboBox cbCiudad;
        private System.Windows.Forms.Button btnEditaRegimen;
        private System.Windows.Forms.Button btnEditaDepte;
        private System.Windows.Forms.TextBox txtRegimen;
        private System.Windows.Forms.TextBox txtMunicipio;
        private System.Windows.Forms.TextBox txtDepto;
        private System.Windows.Forms.Button btnEditaMunicipio;
        private System.Windows.Forms.Button btnEditarCuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTipoCuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.CheckBox chkIva;
    }
}