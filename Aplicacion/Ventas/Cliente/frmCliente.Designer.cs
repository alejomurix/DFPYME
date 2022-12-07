namespace Aplicacion.Ventas.Cliente
{
    partial class frmCliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCliente));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbDatosPersonales = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbTipo = new System.Windows.Forms.ComboBox();
            this.lblNit = new System.Windows.Forms.Label();
            this.txtNit = new System.Windows.Forms.TextBox();
            this.lblNombres = new System.Windows.Forms.Label();
            this.txtNombres = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblRegimen = new System.Windows.Forms.Label();
            this.cbClasificacion = new System.Windows.Forms.ComboBox();
            this.cbRegimen = new System.Windows.Forms.ComboBox();
            this.lblCiudad = new System.Windows.Forms.Label();
            this.cbCiudad = new System.Windows.Forms.ComboBox();
            this.lblDepartamento = new System.Windows.Forms.Label();
            this.cbDepartamentos = new System.Windows.Forms.ComboBox();
            this.tcClientes = new System.Windows.Forms.TabControl();
            this.tpIngresarCliente = new System.Windows.Forms.TabPage();
            this.tsIngresarCliente = new System.Windows.Forms.ToolStrip();
            this.tsBtnGuardar = new System.Windows.Forms.ToolStripButton();
            this.tsbtnSalir = new System.Windows.Forms.ToolStripButton();
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
            this.tpConsultaCliente = new System.Windows.Forms.TabPage();
            this.tsConsultarCliente = new System.Windows.Forms.ToolStrip();
            this.tsBtnListarTodos = new System.Windows.Forms.ToolStripButton();
            this.tsbtnEditarCliente = new System.Windows.Forms.ToolStripButton();
            this.tsBtnCanjear = new System.Windows.Forms.ToolStripButton();
            this.tsbtnEliminarCliente = new System.Windows.Forms.ToolStripButton();
            this.tsbtnConsultaSalir = new System.Windows.Forms.ToolStripButton();
            this.gbRealizarConsultas = new System.Windows.Forms.GroupBox();
            this.cbCriterio1 = new System.Windows.Forms.ComboBox();
            this.cbCriterio2 = new System.Windows.Forms.ComboBox();
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
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Clasificacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Puntos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbDatosPersonales.SuspendLayout();
            this.tcClientes.SuspendLayout();
            this.tpIngresarCliente.SuspendLayout();
            this.tsIngresarCliente.SuspendLayout();
            this.gbDatosContacto.SuspendLayout();
            this.gbDireccion.SuspendLayout();
            this.tpConsultaCliente.SuspendLayout();
            this.tsConsultarCliente.SuspendLayout();
            this.gbRealizarConsultas.SuspendLayout();
            this.gbResultadoConsulta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbDatosPersonales
            // 
            this.gbDatosPersonales.Controls.Add(this.label1);
            this.gbDatosPersonales.Controls.Add(this.cbTipo);
            this.gbDatosPersonales.Controls.Add(this.lblNit);
            this.gbDatosPersonales.Controls.Add(this.txtNit);
            this.gbDatosPersonales.Controls.Add(this.lblNombres);
            this.gbDatosPersonales.Controls.Add(this.txtNombres);
            this.gbDatosPersonales.Controls.Add(this.label2);
            this.gbDatosPersonales.Controls.Add(this.lblRegimen);
            this.gbDatosPersonales.Controls.Add(this.cbClasificacion);
            this.gbDatosPersonales.Controls.Add(this.cbRegimen);
            this.gbDatosPersonales.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDatosPersonales.Location = new System.Drawing.Point(7, 44);
            this.gbDatosPersonales.Name = "gbDatosPersonales";
            this.gbDatosPersonales.Size = new System.Drawing.Size(971, 107);
            this.gbDatosPersonales.TabIndex = 0;
            this.gbDatosPersonales.TabStop = false;
            this.gbDatosPersonales.Text = "Datos Personales";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(328, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Tipo";
            // 
            // cbTipo
            // 
            this.cbTipo.DisplayMember = "descripcion";
            this.cbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipo.FormattingEnabled = true;
            this.cbTipo.Location = new System.Drawing.Point(467, 67);
            this.cbTipo.Name = "cbTipo";
            this.cbTipo.Size = new System.Drawing.Size(164, 24);
            this.cbTipo.TabIndex = 6;
            this.cbTipo.ValueMember = "id";
            // 
            // lblNit
            // 
            this.lblNit.AutoSize = true;
            this.lblNit.Location = new System.Drawing.Point(8, 33);
            this.lblNit.Name = "lblNit";
            this.lblNit.Size = new System.Drawing.Size(51, 16);
            this.lblNit.TabIndex = 3;
            this.lblNit.Text = "Cedula";
            // 
            // txtNit
            // 
            this.txtNit.Location = new System.Drawing.Point(75, 29);
            this.txtNit.MaxLength = 20;
            this.txtNit.Name = "txtNit";
            this.txtNit.Size = new System.Drawing.Size(190, 22);
            this.txtNit.TabIndex = 0;
            this.txtNit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNit_KeyPress);
            this.txtNit.Validating += new System.ComponentModel.CancelEventHandler(this.txtNit_Validating);
            // 
            // lblNombres
            // 
            this.lblNombres.AutoSize = true;
            this.lblNombres.Location = new System.Drawing.Point(327, 32);
            this.lblNombres.Name = "lblNombres";
            this.lblNombres.Size = new System.Drawing.Size(134, 16);
            this.lblNombres.TabIndex = 4;
            this.lblNombres.Text = "Nombres y Apellidos";
            // 
            // txtNombres
            // 
            this.txtNombres.Location = new System.Drawing.Point(467, 29);
            this.txtNombres.MaxLength = 100;
            this.txtNombres.Name = "txtNombres";
            this.txtNombres.Size = new System.Drawing.Size(489, 22);
            this.txtNombres.TabIndex = 1;
            this.txtNombres.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombres_KeyPress);
            this.txtNombres.Validating += new System.ComponentModel.CancelEventHandler(this.txtNombres_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(669, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Clasificación";
            // 
            // lblRegimen
            // 
            this.lblRegimen.AutoSize = true;
            this.lblRegimen.Location = new System.Drawing.Point(8, 71);
            this.lblRegimen.Name = "lblRegimen";
            this.lblRegimen.Size = new System.Drawing.Size(63, 16);
            this.lblRegimen.TabIndex = 5;
            this.lblRegimen.Text = "Regimen";
            // 
            // cbClasificacion
            // 
            this.cbClasificacion.DisplayMember = "descripcion";
            this.cbClasificacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbClasificacion.FormattingEnabled = true;
            this.cbClasificacion.Location = new System.Drawing.Point(766, 67);
            this.cbClasificacion.Name = "cbClasificacion";
            this.cbClasificacion.Size = new System.Drawing.Size(190, 24);
            this.cbClasificacion.TabIndex = 2;
            this.cbClasificacion.ValueMember = "id";
            // 
            // cbRegimen
            // 
            this.cbRegimen.DisplayMember = "NombreRegimen";
            this.cbRegimen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRegimen.FormattingEnabled = true;
            this.cbRegimen.Location = new System.Drawing.Point(75, 67);
            this.cbRegimen.Name = "cbRegimen";
            this.cbRegimen.Size = new System.Drawing.Size(190, 24);
            this.cbRegimen.TabIndex = 2;
            this.cbRegimen.ValueMember = "IdRegimen";
            // 
            // lblCiudad
            // 
            this.lblCiudad.AutoSize = true;
            this.lblCiudad.Location = new System.Drawing.Point(327, 35);
            this.lblCiudad.Name = "lblCiudad";
            this.lblCiudad.Size = new System.Drawing.Size(51, 16);
            this.lblCiudad.TabIndex = 4;
            this.lblCiudad.Text = "Ciudad";
            // 
            // cbCiudad
            // 
            this.cbCiudad.DisplayMember = "NombreCiudad";
            this.cbCiudad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCiudad.FormattingEnabled = true;
            this.cbCiudad.Location = new System.Drawing.Point(395, 31);
            this.cbCiudad.Name = "cbCiudad";
            this.cbCiudad.Size = new System.Drawing.Size(161, 24);
            this.cbCiudad.TabIndex = 1;
            this.cbCiudad.ValueMember = "IdCiudad";
            // 
            // lblDepartamento
            // 
            this.lblDepartamento.AutoSize = true;
            this.lblDepartamento.Location = new System.Drawing.Point(11, 34);
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
            this.cbDepartamentos.Location = new System.Drawing.Point(130, 31);
            this.cbDepartamentos.Name = "cbDepartamentos";
            this.cbDepartamentos.Size = new System.Drawing.Size(157, 24);
            this.cbDepartamentos.TabIndex = 0;
            this.cbDepartamentos.ValueMember = "IdDepartamento";
            this.cbDepartamentos.SelectionChangeCommitted += new System.EventHandler(this.cbDepartamentos_SelectionChangeCommitted);
            // 
            // tcClientes
            // 
            this.tcClientes.Controls.Add(this.tpIngresarCliente);
            this.tcClientes.Controls.Add(this.tpConsultaCliente);
            this.tcClientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.tcClientes.Location = new System.Drawing.Point(1, 1);
            this.tcClientes.Name = "tcClientes";
            this.tcClientes.SelectedIndex = 0;
            this.tcClientes.Size = new System.Drawing.Size(992, 416);
            this.tcClientes.TabIndex = 0;
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
            this.tpIngresarCliente.Size = new System.Drawing.Size(984, 387);
            this.tpIngresarCliente.TabIndex = 0;
            this.tpIngresarCliente.Text = "Ingresar Cliente";
            this.tpIngresarCliente.UseVisualStyleBackColor = true;
            // 
            // tsIngresarCliente
            // 
            this.tsIngresarCliente.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsIngresarCliente.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnGuardar,
            this.tsbtnSalir});
            this.tsIngresarCliente.Location = new System.Drawing.Point(3, 3);
            this.tsIngresarCliente.Name = "tsIngresarCliente";
            this.tsIngresarCliente.Size = new System.Drawing.Size(978, 25);
            this.tsIngresarCliente.TabIndex = 3;
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
            // tsbtnSalir
            // 
            this.tsbtnSalir.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnSalir.Image")));
            this.tsbtnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnSalir.Name = "tsbtnSalir";
            this.tsbtnSalir.Size = new System.Drawing.Size(53, 22);
            this.tsbtnSalir.Text = "Salir";
            this.tsbtnSalir.Click += new System.EventHandler(this.tsbtnSalir_Click);
            // 
            // gbDatosContacto
            // 
            this.gbDatosContacto.Controls.Add(this.lblTelefono);
            this.gbDatosContacto.Controls.Add(this.txtTelefono);
            this.gbDatosContacto.Controls.Add(this.lblCelular);
            this.gbDatosContacto.Controls.Add(this.txtCelular);
            this.gbDatosContacto.Controls.Add(this.lblEmail);
            this.gbDatosContacto.Controls.Add(this.txtEmail);
            this.gbDatosContacto.Location = new System.Drawing.Point(7, 175);
            this.gbDatosContacto.Name = "gbDatosContacto";
            this.gbDatosContacto.Size = new System.Drawing.Size(971, 86);
            this.gbDatosContacto.TabIndex = 1;
            this.gbDatosContacto.TabStop = false;
            this.gbDatosContacto.Text = "Datos de Contacto";
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Location = new System.Drawing.Point(11, 38);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(62, 16);
            this.lblTelefono.TabIndex = 3;
            this.lblTelefono.Text = "Telefono";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(114, 35);
            this.txtTelefono.MaxLength = 20;
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(120, 22);
            this.txtTelefono.TabIndex = 0;
            this.txtTelefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTelefono_KeyPress);
            this.txtTelefono.Validating += new System.ComponentModel.CancelEventHandler(this.txtTelefono_Validating);
            // 
            // lblCelular
            // 
            this.lblCelular.AutoSize = true;
            this.lblCelular.Location = new System.Drawing.Point(274, 38);
            this.lblCelular.Name = "lblCelular";
            this.lblCelular.Size = new System.Drawing.Size(50, 16);
            this.lblCelular.TabIndex = 4;
            this.lblCelular.Text = "Celular";
            // 
            // txtCelular
            // 
            this.txtCelular.Location = new System.Drawing.Point(334, 35);
            this.txtCelular.MaxLength = 20;
            this.txtCelular.Name = "txtCelular";
            this.txtCelular.Size = new System.Drawing.Size(264, 22);
            this.txtCelular.TabIndex = 1;
            this.txtCelular.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCelular_KeyPress);
            this.txtCelular.Validating += new System.ComponentModel.CancelEventHandler(this.txtCelular_Validating);
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(620, 38);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(52, 16);
            this.lblEmail.TabIndex = 5;
            this.lblEmail.Text = "E - Mail";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(691, 35);
            this.txtEmail.MaxLength = 255;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(265, 22);
            this.txtEmail.TabIndex = 2;
            this.txtEmail.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEmail_KeyPress);
            this.txtEmail.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmail_Validating);
            // 
            // gbDireccion
            // 
            this.gbDireccion.Controls.Add(this.lblDepartamento);
            this.gbDireccion.Controls.Add(this.cbDepartamentos);
            this.gbDireccion.Controls.Add(this.lblCiudad);
            this.gbDireccion.Controls.Add(this.cbCiudad);
            this.gbDireccion.Controls.Add(this.lblDireccion);
            this.gbDireccion.Controls.Add(this.txtDireccion);
            this.gbDireccion.Location = new System.Drawing.Point(7, 289);
            this.gbDireccion.Name = "gbDireccion";
            this.gbDireccion.Size = new System.Drawing.Size(971, 78);
            this.gbDireccion.TabIndex = 2;
            this.gbDireccion.TabStop = false;
            this.gbDireccion.Text = "Datos de Direccion";
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Location = new System.Drawing.Point(607, 35);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(65, 16);
            this.lblDireccion.TabIndex = 5;
            this.lblDireccion.Text = "Direccion";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(691, 32);
            this.txtDireccion.MaxLength = 255;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(265, 22);
            this.txtDireccion.TabIndex = 2;
            this.txtDireccion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDireccion_KeyPress);
            this.txtDireccion.Validating += new System.ComponentModel.CancelEventHandler(this.txtDireccion_Validating);
            // 
            // tpConsultaCliente
            // 
            this.tpConsultaCliente.Controls.Add(this.tsConsultarCliente);
            this.tpConsultaCliente.Controls.Add(this.gbRealizarConsultas);
            this.tpConsultaCliente.Controls.Add(this.gbResultadoConsulta);
            this.tpConsultaCliente.Location = new System.Drawing.Point(4, 25);
            this.tpConsultaCliente.Name = "tpConsultaCliente";
            this.tpConsultaCliente.Padding = new System.Windows.Forms.Padding(3);
            this.tpConsultaCliente.Size = new System.Drawing.Size(984, 387);
            this.tpConsultaCliente.TabIndex = 1;
            this.tpConsultaCliente.Text = "Consultar Cliente";
            this.tpConsultaCliente.UseVisualStyleBackColor = true;
            // 
            // tsConsultarCliente
            // 
            this.tsConsultarCliente.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsConsultarCliente.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnListarTodos,
            this.tsbtnEditarCliente,
            this.tsBtnCanjear,
            this.tsbtnEliminarCliente,
            this.tsbtnConsultaSalir});
            this.tsConsultarCliente.Location = new System.Drawing.Point(3, 3);
            this.tsConsultarCliente.Name = "tsConsultarCliente";
            this.tsConsultarCliente.Size = new System.Drawing.Size(978, 25);
            this.tsConsultarCliente.TabIndex = 0;
            this.tsConsultarCliente.Text = "Menu Consulta";
            // 
            // tsBtnListarTodos
            // 
            this.tsBtnListarTodos.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnListarTodos.Image")));
            this.tsBtnListarTodos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnListarTodos.Name = "tsBtnListarTodos";
            this.tsBtnListarTodos.Size = new System.Drawing.Size(99, 22);
            this.tsBtnListarTodos.Text = "Listar Todos";
            this.tsBtnListarTodos.Click += new System.EventHandler(this.tsBtnListarTodos_Click);
            // 
            // tsbtnEditarCliente
            // 
            this.tsbtnEditarCliente.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnEditarCliente.Image")));
            this.tsbtnEditarCliente.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnEditarCliente.Name = "tsbtnEditarCliente";
            this.tsbtnEditarCliente.Size = new System.Drawing.Size(62, 22);
            this.tsbtnEditarCliente.Text = "Editar";
            this.tsbtnEditarCliente.Click += new System.EventHandler(this.tsbtnEditarCliente_Click);
            // 
            // tsBtnCanjear
            // 
            this.tsBtnCanjear.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnCanjear.Image")));
            this.tsBtnCanjear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnCanjear.Name = "tsBtnCanjear";
            this.tsBtnCanjear.Size = new System.Drawing.Size(116, 22);
            this.tsBtnCanjear.Text = "Canjear puntos";
            this.tsBtnCanjear.Click += new System.EventHandler(this.tsBtnCanjear_Click);
            // 
            // tsbtnEliminarCliente
            // 
            this.tsbtnEliminarCliente.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnEliminarCliente.Image")));
            this.tsbtnEliminarCliente.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnEliminarCliente.Name = "tsbtnEliminarCliente";
            this.tsbtnEliminarCliente.Size = new System.Drawing.Size(74, 22);
            this.tsbtnEliminarCliente.Text = "Eliminar";
            this.tsbtnEliminarCliente.Click += new System.EventHandler(this.tsbtnEliminarCliente_Click);
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
            // gbRealizarConsultas
            // 
            this.gbRealizarConsultas.Controls.Add(this.cbCriterio1);
            this.gbRealizarConsultas.Controls.Add(this.cbCriterio2);
            this.gbRealizarConsultas.Controls.Add(this.txtParametro);
            this.gbRealizarConsultas.Controls.Add(this.btnBuscar);
            this.gbRealizarConsultas.Location = new System.Drawing.Point(14, 33);
            this.gbRealizarConsultas.Name = "gbRealizarConsultas";
            this.gbRealizarConsultas.Size = new System.Drawing.Size(966, 79);
            this.gbRealizarConsultas.TabIndex = 3;
            this.gbRealizarConsultas.TabStop = false;
            this.gbRealizarConsultas.Text = "Realizar Consultas";
            // 
            // cbCriterio1
            // 
            this.cbCriterio1.DisplayMember = "Nombre";
            this.cbCriterio1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCriterio1.FormattingEnabled = true;
            this.cbCriterio1.Location = new System.Drawing.Point(19, 36);
            this.cbCriterio1.Name = "cbCriterio1";
            this.cbCriterio1.Size = new System.Drawing.Size(121, 24);
            this.cbCriterio1.TabIndex = 5;
            this.cbCriterio1.ValueMember = "Id";
            this.cbCriterio1.SelectionChangeCommitted += new System.EventHandler(this.cbCriterio1_SelectionChangeCommitted);
            // 
            // cbCriterio2
            // 
            this.cbCriterio2.DisplayMember = "Nombre";
            this.cbCriterio2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCriterio2.Enabled = false;
            this.cbCriterio2.FormattingEnabled = true;
            this.cbCriterio2.Location = new System.Drawing.Point(158, 36);
            this.cbCriterio2.Name = "cbCriterio2";
            this.cbCriterio2.Size = new System.Drawing.Size(121, 24);
            this.cbCriterio2.TabIndex = 6;
            this.cbCriterio2.ValueMember = "Id";
            // 
            // txtParametro
            // 
            this.txtParametro.Location = new System.Drawing.Point(301, 37);
            this.txtParametro.Name = "txtParametro";
            this.txtParametro.Size = new System.Drawing.Size(582, 22);
            this.txtParametro.TabIndex = 1;
            this.txtParametro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtParametro_KeyPress);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(907, 37);
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
            this.gbResultadoConsulta.Location = new System.Drawing.Point(8, 118);
            this.gbResultadoConsulta.Name = "gbResultadoConsulta";
            this.gbResultadoConsulta.Size = new System.Drawing.Size(972, 264);
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
            this.dgvListado1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListado1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Tipo,
            this.Clasificacion,
            this.Puntos});
            this.dgvListado1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvListado1.GridColor = System.Drawing.SystemColors.Window;
            this.dgvListado1.Location = new System.Drawing.Point(6, 21);
            this.dgvListado1.Name = "dgvListado1";
            this.dgvListado1.ReadOnly = true;
            this.dgvListado1.RowHeadersVisible = false;
            this.dgvListado1.Size = new System.Drawing.Size(959, 237);
            this.dgvListado1.TabIndex = 1;
            this.dgvListado1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListado1_CellDoubleClick);
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
            this.Column2.Width = 220;
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
            this.Column5.Width = 150;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "NombreCiudad";
            this.Column6.HeaderText = "Ciudad";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 120;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "NombreDepartamento";
            this.Column7.HeaderText = "Departamento";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Visible = false;
            this.Column7.Width = 120;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "EmailCliente";
            this.Column8.HeaderText = "E-mail";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Visible = false;
            this.Column8.Width = 105;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "NombreRegimen";
            this.Column9.HeaderText = "Regimen";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Visible = false;
            this.Column9.Width = 105;
            // 
            // Tipo
            // 
            this.Tipo.DataPropertyName = "descripcion";
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.Name = "Tipo";
            this.Tipo.ReadOnly = true;
            this.Tipo.Width = 90;
            // 
            // Clasificacion
            // 
            this.Clasificacion.DataPropertyName = "clasificacion";
            this.Clasificacion.HeaderText = "Clasific.";
            this.Clasificacion.Name = "Clasificacion";
            this.Clasificacion.ReadOnly = true;
            this.Clasificacion.Width = 120;
            // 
            // Puntos
            // 
            this.Puntos.DataPropertyName = "punto";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = null;
            this.Puntos.DefaultCellStyle = dataGridViewCellStyle1;
            this.Puntos.HeaderText = "PTS.";
            this.Puntos.Name = "Puntos";
            this.Puntos.ReadOnly = true;
            this.Puntos.Width = 35;
            // 
            // frmCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 416);
            this.Controls.Add(this.tcClientes);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ingresar Cliente";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCliente_FormClosing);
            this.Load += new System.EventHandler(this.IngresarCliente_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCliente_KeyDown);
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
            this.tpConsultaCliente.ResumeLayout(false);
            this.tpConsultaCliente.PerformLayout();
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
        private System.Windows.Forms.ComboBox cbDepartamentos;
        private System.Windows.Forms.Label lblDepartamento;
        private System.Windows.Forms.ComboBox cbCiudad;
        private System.Windows.Forms.Label lblCiudad;
        private System.Windows.Forms.TabPage tpIngresarCliente;
        private System.Windows.Forms.TabPage tpConsultaCliente;
        private System.Windows.Forms.Label lblNombres;
        private System.Windows.Forms.ToolStrip tsIngresarCliente;
        private System.Windows.Forms.ToolStripButton tsBtnGuardar;
        private System.Windows.Forms.Label lblNit;
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
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ComboBox cbCriterio2;
        private System.Windows.Forms.ToolStripButton tsbtnEditarCliente;
        private System.Windows.Forms.ToolStripButton tsbtnEliminarCliente;
        private System.Windows.Forms.ToolStripButton tsbtnSalir;
        private System.Windows.Forms.ToolStripButton tsbtnConsultaSalir;
        public System.Windows.Forms.TextBox txtNit;
        public System.Windows.Forms.TextBox txtNombres;
        public System.Windows.Forms.TabControl tcClientes;
        public System.Windows.Forms.ComboBox cbCriterio1;
        public System.Windows.Forms.TextBox txtParametro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbTipo;
        private System.Windows.Forms.ToolStripButton tsBtnCanjear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbClasificacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Clasificacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Puntos;
    }
}