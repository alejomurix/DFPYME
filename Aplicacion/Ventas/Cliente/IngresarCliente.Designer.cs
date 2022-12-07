namespace Aplicacion.Ventas.Cliente
{
    partial class IngresarCliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IngresarCliente));
            this.gbDatosPersonales = new System.Windows.Forms.GroupBox();
            this.lblNit = new System.Windows.Forms.Label();
            this.txtNit = new System.Windows.Forms.TextBox();
            this.lblNombres = new System.Windows.Forms.Label();
            this.txtNombres = new System.Windows.Forms.TextBox();
            this.lblRegimen = new System.Windows.Forms.Label();
            this.cbRegimen = new System.Windows.Forms.ComboBox();
            this.lblCiudad = new System.Windows.Forms.Label();
            this.cbCiudad = new System.Windows.Forms.ComboBox();
            this.lblDepartamento = new System.Windows.Forms.Label();
            this.cbDepartamentos = new System.Windows.Forms.ComboBox();
            this.tcClientes = new System.Windows.Forms.TabControl();
            this.tpIngresarCliente = new System.Windows.Forms.TabPage();
            this.tsIngresarCliente = new System.Windows.Forms.ToolStrip();
            this.tsBtnGuardar = new System.Windows.Forms.ToolStripButton();
            this.gbDatosContacto = new System.Windows.Forms.GroupBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.lblCelular = new System.Windows.Forms.Label();
            this.txtCelular = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.gbDireccion = new System.Windows.Forms.GroupBox();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.tpConsultarCliente = new System.Windows.Forms.TabPage();
            this.tsConsultarCliente = new System.Windows.Forms.ToolStrip();
            this.tsBtnListarTodos = new System.Windows.Forms.ToolStripButton();
            this.gbRealizarConsultas = new System.Windows.Forms.GroupBox();
            this.rbtnConsultaCedula = new System.Windows.Forms.RadioButton();
            this.rbtnConsultaNombre = new System.Windows.Forms.RadioButton();
            this.txtParametro = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.gbResultadoConsulta = new System.Windows.Forms.GroupBox();
            this.dgvListado1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbDatosPersonales.SuspendLayout();
            this.tcClientes.SuspendLayout();
            this.tpIngresarCliente.SuspendLayout();
            this.tsIngresarCliente.SuspendLayout();
            this.gbDatosContacto.SuspendLayout();
            this.gbDireccion.SuspendLayout();
            this.tpConsultarCliente.SuspendLayout();
            this.tsConsultarCliente.SuspendLayout();
            this.gbRealizarConsultas.SuspendLayout();
            this.gbResultadoConsulta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbDatosPersonales
            // 
            this.gbDatosPersonales.Controls.Add(this.lblNit);
            this.gbDatosPersonales.Controls.Add(this.txtNit);
            this.gbDatosPersonales.Controls.Add(this.lblNombres);
            this.gbDatosPersonales.Controls.Add(this.txtNombres);
            this.gbDatosPersonales.Controls.Add(this.lblRegimen);
            this.gbDatosPersonales.Controls.Add(this.cbRegimen);
            this.gbDatosPersonales.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDatosPersonales.Location = new System.Drawing.Point(39, 50);
            this.gbDatosPersonales.Name = "gbDatosPersonales";
            this.gbDatosPersonales.Size = new System.Drawing.Size(803, 95);
            this.gbDatosPersonales.TabIndex = 0;
            this.gbDatosPersonales.TabStop = false;
            this.gbDatosPersonales.Text = "Datos Personales";
            // 
            // lblNit
            // 
            this.lblNit.AutoSize = true;
            this.lblNit.Location = new System.Drawing.Point(8, 33);
            this.lblNit.Name = "lblNit";
            this.lblNit.Size = new System.Drawing.Size(81, 16);
            this.lblNit.TabIndex = 3;
            this.lblNit.Text = "Cedula o Nit";
            // 
            // txtNit
            // 
            this.txtNit.Location = new System.Drawing.Point(103, 29);
            this.txtNit.Name = "txtNit";
            this.txtNit.Size = new System.Drawing.Size(109, 22);
            this.txtNit.TabIndex = 0;
            this.txtNit.Validating += new System.ComponentModel.CancelEventHandler(this.ValidarCamposVacios);
            // 
            // lblNombres
            // 
            this.lblNombres.AutoSize = true;
            this.lblNombres.Location = new System.Drawing.Point(229, 33);
            this.lblNombres.Name = "lblNombres";
            this.lblNombres.Size = new System.Drawing.Size(134, 16);
            this.lblNombres.TabIndex = 2;
            this.lblNombres.Text = "Nombres y Apellidos";
            // 
            // txtNombres
            // 
            this.txtNombres.Location = new System.Drawing.Point(374, 30);
            this.txtNombres.Name = "txtNombres";
            this.txtNombres.Size = new System.Drawing.Size(198, 22);
            this.txtNombres.TabIndex = 1;
            // 
            // lblRegimen
            // 
            this.lblRegimen.AutoSize = true;
            this.lblRegimen.Location = new System.Drawing.Point(590, 34);
            this.lblRegimen.Name = "lblRegimen";
            this.lblRegimen.Size = new System.Drawing.Size(63, 16);
            this.lblRegimen.TabIndex = 5;
            this.lblRegimen.Text = "Regimen";
            // 
            // cbRegimen
            // 
            this.cbRegimen.DisplayMember = "NombreRegimen";
            this.cbRegimen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRegimen.FormattingEnabled = true;
            this.cbRegimen.Location = new System.Drawing.Point(661, 30);
            this.cbRegimen.Name = "cbRegimen";
            this.cbRegimen.Size = new System.Drawing.Size(121, 24);
            this.cbRegimen.TabIndex = 2;
            this.cbRegimen.ValueMember = "IdRegimen";
            // 
            // lblCiudad
            // 
            this.lblCiudad.AutoSize = true;
            this.lblCiudad.Location = new System.Drawing.Point(289, 43);
            this.lblCiudad.Name = "lblCiudad";
            this.lblCiudad.Size = new System.Drawing.Size(51, 16);
            this.lblCiudad.TabIndex = 5;
            this.lblCiudad.Text = "Ciudad";
            // 
            // cbCiudad
            // 
            this.cbCiudad.DisplayMember = "NombreCiudad";
            this.cbCiudad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCiudad.FormattingEnabled = true;
            this.cbCiudad.Location = new System.Drawing.Point(357, 39);
            this.cbCiudad.Name = "cbCiudad";
            this.cbCiudad.Size = new System.Drawing.Size(121, 24);
            this.cbCiudad.TabIndex = 1;
            this.cbCiudad.ValueMember = "IdCiudad";
            // 
            // lblDepartamento
            // 
            this.lblDepartamento.AutoSize = true;
            this.lblDepartamento.Location = new System.Drawing.Point(8, 42);
            this.lblDepartamento.Name = "lblDepartamento";
            this.lblDepartamento.Size = new System.Drawing.Size(94, 16);
            this.lblDepartamento.TabIndex = 3;
            this.lblDepartamento.Text = "Departamento";
            // 
            // cbDepartamentos
            // 
            this.cbDepartamentos.DisplayMember = "NombreDepartamento";
            this.cbDepartamentos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDepartamentos.FormattingEnabled = true;
            this.cbDepartamentos.Location = new System.Drawing.Point(115, 39);
            this.cbDepartamentos.Name = "cbDepartamentos";
            this.cbDepartamentos.Size = new System.Drawing.Size(121, 24);
            this.cbDepartamentos.TabIndex = 0;
            this.cbDepartamentos.ValueMember = "IdDepartamento";
            this.cbDepartamentos.SelectionChangeCommitted += new System.EventHandler(this.cbDepartamentos_SelectionChangeCommitted);
            // 
            // tcClientes
            // 
            this.tcClientes.Controls.Add(this.tpIngresarCliente);
            this.tcClientes.Controls.Add(this.tpConsultarCliente);
            this.tcClientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.tcClientes.Location = new System.Drawing.Point(0, 1);
            this.tcClientes.Name = "tcClientes";
            this.tcClientes.SelectedIndex = 0;
            this.tcClientes.Size = new System.Drawing.Size(901, 500);
            this.tcClientes.TabIndex = 2;
            // 
            // tpIngresarCliente
            // 
            this.tpIngresarCliente.Controls.Add(this.tsIngresarCliente);
            this.tpIngresarCliente.Controls.Add(this.gbDatosPersonales);
            this.tpIngresarCliente.Controls.Add(this.gbDatosContacto);
            this.tpIngresarCliente.Controls.Add(this.gbDireccion);
            this.tpIngresarCliente.Location = new System.Drawing.Point(4, 25);
            this.tpIngresarCliente.Name = "tpIngresarCliente";
            this.tpIngresarCliente.Padding = new System.Windows.Forms.Padding(3);
            this.tpIngresarCliente.Size = new System.Drawing.Size(893, 471);
            this.tpIngresarCliente.TabIndex = 0;
            this.tpIngresarCliente.Text = "Ingresar Cliente";
            this.tpIngresarCliente.UseVisualStyleBackColor = true;
            // 
            // tsIngresarCliente
            // 
            this.tsIngresarCliente.BackColor = System.Drawing.Color.Transparent;
            this.tsIngresarCliente.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsIngresarCliente.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnGuardar});
            this.tsIngresarCliente.Location = new System.Drawing.Point(3, 3);
            this.tsIngresarCliente.Name = "tsIngresarCliente";
            this.tsIngresarCliente.Size = new System.Drawing.Size(887, 25);
            this.tsIngresarCliente.TabIndex = 0;
            this.tsIngresarCliente.Text = "Menu Cliente";
            // 
            // tsBtnGuardar
            // 
            this.tsBtnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnGuardar.Image")));
            this.tsBtnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnGuardar.Name = "tsBtnGuardar";
            this.tsBtnGuardar.Size = new System.Drawing.Size(76, 22);
            this.tsBtnGuardar.Text = "Guardar";
            this.tsBtnGuardar.Click += new System.EventHandler(this.tsBtnGuardar_Click);
            // 
            // gbDatosContacto
            // 
            this.gbDatosContacto.Controls.Add(this.lblTelefono);
            this.gbDatosContacto.Controls.Add(this.txtTelefono);
            this.gbDatosContacto.Controls.Add(this.lblCelular);
            this.gbDatosContacto.Controls.Add(this.txtCelular);
            this.gbDatosContacto.Controls.Add(this.lblEmail);
            this.gbDatosContacto.Controls.Add(this.txtEmail);
            this.gbDatosContacto.Location = new System.Drawing.Point(39, 154);
            this.gbDatosContacto.Name = "gbDatosContacto";
            this.gbDatosContacto.Size = new System.Drawing.Size(803, 119);
            this.gbDatosContacto.TabIndex = 7;
            this.gbDatosContacto.TabStop = false;
            this.gbDatosContacto.Text = "Datos de Contacto";
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Location = new System.Drawing.Point(8, 44);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(62, 16);
            this.lblTelefono.TabIndex = 0;
            this.lblTelefono.Text = "Telefono";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(98, 38);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(120, 22);
            this.txtTelefono.TabIndex = 0;
            // 
            // lblCelular
            // 
            this.lblCelular.AutoSize = true;
            this.lblCelular.Location = new System.Drawing.Point(244, 41);
            this.lblCelular.Name = "lblCelular";
            this.lblCelular.Size = new System.Drawing.Size(50, 16);
            this.lblCelular.TabIndex = 2;
            this.lblCelular.Text = "Celular";
            // 
            // txtCelular
            // 
            this.txtCelular.Location = new System.Drawing.Point(305, 38);
            this.txtCelular.Name = "txtCelular";
            this.txtCelular.Size = new System.Drawing.Size(141, 22);
            this.txtCelular.TabIndex = 1;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(468, 40);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(52, 16);
            this.lblEmail.TabIndex = 4;
            this.lblEmail.Text = "E - Mail";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(539, 37);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(148, 22);
            this.txtEmail.TabIndex = 2;
            // 
            // gbDireccion
            // 
            this.gbDireccion.Controls.Add(this.lblDepartamento);
            this.gbDireccion.Controls.Add(this.cbDepartamentos);
            this.gbDireccion.Controls.Add(this.lblCiudad);
            this.gbDireccion.Controls.Add(this.cbCiudad);
            this.gbDireccion.Controls.Add(this.lblDireccion);
            this.gbDireccion.Controls.Add(this.txtDireccion);
            this.gbDireccion.Location = new System.Drawing.Point(39, 284);
            this.gbDireccion.Name = "gbDireccion";
            this.gbDireccion.Size = new System.Drawing.Size(803, 112);
            this.gbDireccion.TabIndex = 8;
            this.gbDireccion.TabStop = false;
            this.gbDireccion.Text = "Datos de Direccion";
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Location = new System.Drawing.Point(531, 43);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(65, 16);
            this.lblDireccion.TabIndex = 6;
            this.lblDireccion.Text = "Direccion";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(613, 40);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(140, 22);
            this.txtDireccion.TabIndex = 2;
            // 
            // tpConsultarCliente
            // 
            this.tpConsultarCliente.Controls.Add(this.tsConsultarCliente);
            this.tpConsultarCliente.Controls.Add(this.gbRealizarConsultas);
            this.tpConsultarCliente.Controls.Add(this.gbResultadoConsulta);
            this.tpConsultarCliente.Location = new System.Drawing.Point(4, 25);
            this.tpConsultarCliente.Name = "tpConsultarCliente";
            this.tpConsultarCliente.Padding = new System.Windows.Forms.Padding(3);
            this.tpConsultarCliente.Size = new System.Drawing.Size(893, 471);
            this.tpConsultarCliente.TabIndex = 1;
            this.tpConsultarCliente.Text = "Consultar Cliente";
            this.tpConsultarCliente.UseVisualStyleBackColor = true;
            // 
            // tsConsultarCliente
            // 
            this.tsConsultarCliente.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsConsultarCliente.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnListarTodos});
            this.tsConsultarCliente.Location = new System.Drawing.Point(3, 3);
            this.tsConsultarCliente.Name = "tsConsultarCliente";
            this.tsConsultarCliente.Size = new System.Drawing.Size(887, 25);
            this.tsConsultarCliente.TabIndex = 0;
            this.tsConsultarCliente.Text = "Menu Consulta";
            // 
            // tsBtnListarTodos
            // 
            this.tsBtnListarTodos.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnListarTodos.Image")));
            this.tsBtnListarTodos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnListarTodos.Name = "tsBtnListarTodos";
            this.tsBtnListarTodos.Size = new System.Drawing.Size(100, 22);
            this.tsBtnListarTodos.Text = "Listar Todos";
            this.tsBtnListarTodos.Click += new System.EventHandler(this.tsBtnListarTodos_Click);
            // 
            // gbRealizarConsultas
            // 
            this.gbRealizarConsultas.Controls.Add(this.rbtnConsultaCedula);
            this.gbRealizarConsultas.Controls.Add(this.rbtnConsultaNombre);
            this.gbRealizarConsultas.Controls.Add(this.txtParametro);
            this.gbRealizarConsultas.Controls.Add(this.btnBuscar);
            this.gbRealizarConsultas.Location = new System.Drawing.Point(14, 33);
            this.gbRealizarConsultas.Name = "gbRealizarConsultas";
            this.gbRealizarConsultas.Size = new System.Drawing.Size(864, 159);
            this.gbRealizarConsultas.TabIndex = 3;
            this.gbRealizarConsultas.TabStop = false;
            this.gbRealizarConsultas.Text = "Realizar Consultas";
            // 
            // rbtnConsultaCedula
            // 
            this.rbtnConsultaCedula.AutoSize = true;
            this.rbtnConsultaCedula.Checked = true;
            this.rbtnConsultaCedula.Location = new System.Drawing.Point(19, 36);
            this.rbtnConsultaCedula.Name = "rbtnConsultaCedula";
            this.rbtnConsultaCedula.Size = new System.Drawing.Size(93, 20);
            this.rbtnConsultaCedula.TabIndex = 2;
            this.rbtnConsultaCedula.TabStop = true;
            this.rbtnConsultaCedula.Text = "Por Cedula";
            this.rbtnConsultaCedula.UseVisualStyleBackColor = true;
            // 
            // rbtnConsultaNombre
            // 
            this.rbtnConsultaNombre.AutoSize = true;
            this.rbtnConsultaNombre.Location = new System.Drawing.Point(19, 72);
            this.rbtnConsultaNombre.Name = "rbtnConsultaNombre";
            this.rbtnConsultaNombre.Size = new System.Drawing.Size(99, 20);
            this.rbtnConsultaNombre.TabIndex = 3;
            this.rbtnConsultaNombre.TabStop = true;
            this.rbtnConsultaNombre.Text = "Por Nombre";
            this.rbtnConsultaNombre.UseVisualStyleBackColor = true;
            // 
            // txtParametro
            // 
            this.txtParametro.Location = new System.Drawing.Point(19, 115);
            this.txtParametro.Name = "txtParametro";
            this.txtParametro.Size = new System.Drawing.Size(229, 22);
            this.txtParametro.TabIndex = 1;
            this.txtParametro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtParametro_KeyPress);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(261, 114);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(31, 23);
            this.btnBuscar.TabIndex = 4;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // gbResultadoConsulta
            // 
            this.gbResultadoConsulta.Controls.Add(this.dgvListado1);
            this.gbResultadoConsulta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gbResultadoConsulta.Location = new System.Drawing.Point(8, 198);
            this.gbResultadoConsulta.Name = "gbResultadoConsulta";
            this.gbResultadoConsulta.Size = new System.Drawing.Size(876, 264);
            this.gbResultadoConsulta.TabIndex = 2;
            this.gbResultadoConsulta.TabStop = false;
            this.gbResultadoConsulta.Text = "Resultado de la Consulta";
            // 
            // dgvListado1
            // 
            this.dgvListado1.AllowUserToAddRows = false;
            this.dgvListado1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvListado1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvListado1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvListado1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9});
            this.dgvListado1.GridColor = System.Drawing.SystemColors.Window;
            this.dgvListado1.Location = new System.Drawing.Point(13, 21);
            this.dgvListado1.Name = "dgvListado1";
            this.dgvListado1.ReadOnly = true;
            this.dgvListado1.Size = new System.Drawing.Size(843, 237);
            this.dgvListado1.TabIndex = 1;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "NitCliente";
            this.Column1.HeaderText = "Cedula o Nit";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "NombresCliente";
            this.Column2.HeaderText = "Nombres";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "CelularCliente";
            this.Column4.HeaderText = "Celular";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "DireccionCliente";
            this.Column5.HeaderText = "Direccion";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "NombreCiudad";
            this.Column6.HeaderText = "Ciudad";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "NombreDepartamento";
            this.Column7.HeaderText = "Departamento";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "EmailCliente";
            this.Column8.HeaderText = "E-mail";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "NombreRegimen";
            this.Column9.HeaderText = "Regimen";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // IngresarCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 500);
            this.Controls.Add(this.tcClientes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "IngresarCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ingresar Cliente";
            this.Load += new System.EventHandler(this.IngresarCliente_Load);
            this.gbDatosPersonales.ResumeLayout(false);
            this.gbDatosPersonales.PerformLayout();
            this.tcClientes.ResumeLayout(false);
            this.tpIngresarCliente.ResumeLayout(false);
            this.tpIngresarCliente.PerformLayout();
            this.tsIngresarCliente.ResumeLayout(false);
            this.tsIngresarCliente.PerformLayout();
            this.gbDatosContacto.ResumeLayout(false);
            this.gbDatosContacto.PerformLayout();
            this.gbDireccion.ResumeLayout(false);
            this.gbDireccion.PerformLayout();
            this.tpConsultarCliente.ResumeLayout(false);
            this.tpConsultarCliente.PerformLayout();
            this.tsConsultarCliente.ResumeLayout(false);
            this.tsConsultarCliente.PerformLayout();
            this.gbRealizarConsultas.ResumeLayout(false);
            this.gbRealizarConsultas.PerformLayout();
            this.gbResultadoConsulta.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDatosPersonales;
        private System.Windows.Forms.ComboBox cbRegimen;
        private System.Windows.Forms.TextBox txtNombres;
        private System.Windows.Forms.ComboBox cbDepartamentos;
        private System.Windows.Forms.Label lblDepartamento;
        private System.Windows.Forms.ComboBox cbCiudad;
        private System.Windows.Forms.Label lblCiudad;
        private System.Windows.Forms.TabControl tcClientes;
        private System.Windows.Forms.TabPage tpIngresarCliente;
        private System.Windows.Forms.TabPage tpConsultarCliente;
        private System.Windows.Forms.Label lblNombres;
        private System.Windows.Forms.ToolStrip tsIngresarCliente;
        private System.Windows.Forms.ToolStripButton tsBtnGuardar;
        private System.Windows.Forms.Label lblNit;
        private System.Windows.Forms.TextBox txtNit;
        private System.Windows.Forms.Label lblRegimen;
        private System.Windows.Forms.GroupBox gbDatosContacto;
        private System.Windows.Forms.Label lblCelular;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox txtCelular;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.GroupBox gbDireccion;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.ToolStrip tsConsultarCliente;
        private System.Windows.Forms.ToolStripButton tsBtnListarTodos;
        private System.Windows.Forms.GroupBox gbResultadoConsulta;
        private System.Windows.Forms.DataGridView dgvListado1;
        private System.Windows.Forms.GroupBox gbRealizarConsultas;
        private System.Windows.Forms.TextBox txtParametro;
        private System.Windows.Forms.RadioButton rbtnConsultaCedula;
        private System.Windows.Forms.RadioButton rbtnConsultaNombre;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
    }
}