namespace Aplicacion.Administracion.Usuario
{
    partial class frmUsuarioSistema
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUsuarioSistema));
            this.tpPermiso = new System.Windows.Forms.TabControl();
            this.tpPermisoYUsusrio = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.tsbtnGuardar = new System.Windows.Forms.ToolStripButton();
            this.tsbtnSalir = new System.Windows.Forms.ToolStripButton();
            this.gbxDatosUsuario = new System.Windows.Forms.GroupBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblDocumento = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lblContraseña = new System.Windows.Forms.Label();
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.txtContraseña = new System.Windows.Forms.TextBox();
            this.gbxPermisosUsuario = new System.Windows.Forms.GroupBox();
            this.btnGuardarPermisos = new System.Windows.Forms.Button();
            this.lklblMarcar = new System.Windows.Forms.LinkLabel();
            this.cbxCargo = new System.Windows.Forms.ComboBox();
            this.lklblDesmarcar = new System.Windows.Forms.LinkLabel();
            this.dgvPermiso = new System.Windows.Forms.DataGridView();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.tpConsultapermosoYUsuario = new System.Windows.Forms.TabPage();
            this.tsMenuConsulta = new System.Windows.Forms.ToolStrip();
            this.tsbtnEditar = new System.Windows.Forms.ToolStripButton();
            this.tsbtnEliminar = new System.Windows.Forms.ToolStripButton();
            this.tsBtnSeleccionar = new System.Windows.Forms.ToolStripButton();
            this.tsbtnSalirConsulta = new System.Windows.Forms.ToolStripButton();
            this.gbxConsultaUsuario = new System.Windows.Forms.GroupBox();
            this.cbxConsultaCriterio = new System.Windows.Forms.ComboBox();
            this.cbxIgualContenga = new System.Windows.Forms.ComboBox();
            this.cbxCargoUsuario = new System.Windows.Forms.ComboBox();
            this.txtConsulta = new System.Windows.Forms.TextBox();
            this.chbxIncluir = new System.Windows.Forms.CheckBox();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.gbxUsuario = new System.Windows.Forms.GroupBox();
            this.dgvUsuario = new System.Windows.Forms.DataGridView();
            this.IdUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cargo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Documento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Direccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbxPermisos = new System.Windows.Forms.GroupBox();
            this.dgvPermisoUsuario = new System.Windows.Forms.DataGridView();
            this.IdPermiso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescripcionPermiso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Aplica = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Permiso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Menu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnGuardarUsuario = new System.Windows.Forms.Button();
            this.PanelMenuArticulo = new System.Windows.Forms.Panel();
            this.tsMenuArticulo = new System.Windows.Forms.ToolStrip();
            this.btnEditarUsuario = new System.Windows.Forms.ToolStripButton();
            this.btnAnularUsuario = new System.Windows.Forms.ToolStripButton();
            this.IdUsuario_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Documento_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Password = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpPermiso.SuspendLayout();
            this.tpPermisoYUsusrio.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.tsMenu.SuspendLayout();
            this.gbxDatosUsuario.SuspendLayout();
            this.gbxPermisosUsuario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPermiso)).BeginInit();
            this.tpConsultapermosoYUsuario.SuspendLayout();
            this.tsMenuConsulta.SuspendLayout();
            this.gbxConsultaUsuario.SuspendLayout();
            this.gbxUsuario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuario)).BeginInit();
            this.gbxPermisos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPermisoUsuario)).BeginInit();
            this.PanelMenuArticulo.SuspendLayout();
            this.tsMenuArticulo.SuspendLayout();
            this.SuspendLayout();
            // 
            // tpPermiso
            // 
            this.tpPermiso.Controls.Add(this.tpPermisoYUsusrio);
            this.tpPermiso.Controls.Add(this.tpConsultapermosoYUsuario);
            this.tpPermiso.Location = new System.Drawing.Point(1, 1);
            this.tpPermiso.Name = "tpPermiso";
            this.tpPermiso.SelectedIndex = 0;
            this.tpPermiso.Size = new System.Drawing.Size(1102, 484);
            this.tpPermiso.TabIndex = 0;
            // 
            // tpPermisoYUsusrio
            // 
            this.tpPermisoYUsusrio.Controls.Add(this.groupBox1);
            this.tpPermisoYUsusrio.Controls.Add(this.tsMenu);
            this.tpPermisoYUsusrio.Controls.Add(this.gbxDatosUsuario);
            this.tpPermisoYUsusrio.Controls.Add(this.gbxPermisosUsuario);
            this.tpPermisoYUsusrio.Location = new System.Drawing.Point(4, 25);
            this.tpPermisoYUsusrio.Name = "tpPermisoYUsusrio";
            this.tpPermisoYUsusrio.Padding = new System.Windows.Forms.Padding(3);
            this.tpPermisoYUsusrio.Size = new System.Drawing.Size(1094, 455);
            this.tpPermisoYUsusrio.TabIndex = 0;
            this.tpPermisoYUsusrio.Text = "Ingresar permisos y usuarios";
            this.tpPermisoYUsusrio.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.PanelMenuArticulo);
            this.groupBox1.Controls.Add(this.dgvUsuarios);
            this.groupBox1.Location = new System.Drawing.Point(5, 226);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(553, 225);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // dgvUsuarios
            // 
            this.dgvUsuarios.AllowUserToAddRows = false;
            this.dgvUsuarios.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvUsuarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdUsuario_,
            this.Documento_,
            this.NameUsuario,
            this.UserUsuario,
            this.Password});
            this.dgvUsuarios.Location = new System.Drawing.Point(4, 13);
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.RowHeadersVisible = false;
            this.dgvUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvUsuarios.Size = new System.Drawing.Size(507, 206);
            this.dgvUsuarios.TabIndex = 3;
            this.dgvUsuarios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsuarios_CellClick);
            // 
            // tsMenu
            // 
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnGuardar,
            this.tsbtnSalir});
            this.tsMenu.Location = new System.Drawing.Point(3, 3);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(1088, 25);
            this.tsMenu.TabIndex = 0;
            this.tsMenu.Text = "Menu";
            // 
            // tsbtnGuardar
            // 
            this.tsbtnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnGuardar.Image")));
            this.tsbtnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnGuardar.Name = "tsbtnGuardar";
            this.tsbtnGuardar.Size = new System.Drawing.Size(69, 22);
            this.tsbtnGuardar.Text = "Guardar";
            this.tsbtnGuardar.Visible = false;
            this.tsbtnGuardar.Click += new System.EventHandler(this.tsbtnGuardar_Click);
            // 
            // tsbtnSalir
            // 
            this.tsbtnSalir.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnSalir.Image")));
            this.tsbtnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnSalir.Name = "tsbtnSalir";
            this.tsbtnSalir.Size = new System.Drawing.Size(49, 22);
            this.tsbtnSalir.Text = "Salir";
            this.tsbtnSalir.Click += new System.EventHandler(this.tsbtnSalir_Click);
            // 
            // gbxDatosUsuario
            // 
            this.gbxDatosUsuario.Controls.Add(this.btnGuardarUsuario);
            this.gbxDatosUsuario.Controls.Add(this.lblNombre);
            this.gbxDatosUsuario.Controls.Add(this.txtNombre);
            this.gbxDatosUsuario.Controls.Add(this.lblUsuario);
            this.gbxDatosUsuario.Controls.Add(this.lblDocumento);
            this.gbxDatosUsuario.Controls.Add(this.txtUsuario);
            this.gbxDatosUsuario.Controls.Add(this.lblContraseña);
            this.gbxDatosUsuario.Controls.Add(this.txtDocumento);
            this.gbxDatosUsuario.Controls.Add(this.txtContraseña);
            this.gbxDatosUsuario.Location = new System.Drawing.Point(5, 34);
            this.gbxDatosUsuario.Name = "gbxDatosUsuario";
            this.gbxDatosUsuario.Size = new System.Drawing.Size(553, 186);
            this.gbxDatosUsuario.TabIndex = 1;
            this.gbxDatosUsuario.TabStop = false;
            this.gbxDatosUsuario.Text = "Datos de usuario";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(18, 58);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(60, 16);
            this.lblNombre.TabIndex = 3;
            this.lblNombre.Text = "Nombre ";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(102, 55);
            this.txtNombre.MaxLength = 50;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(428, 22);
            this.txtNombre.TabIndex = 1;
            this.txtNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombre_KeyPress);
            this.txtNombre.Validating += new System.ComponentModel.CancelEventHandler(this.txtNombre_Validating);
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(18, 91);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(55, 16);
            this.lblUsuario.TabIndex = 4;
            this.lblUsuario.Text = "Usuario";
            // 
            // lblDocumento
            // 
            this.lblDocumento.AutoSize = true;
            this.lblDocumento.Location = new System.Drawing.Point(18, 26);
            this.lblDocumento.Name = "lblDocumento";
            this.lblDocumento.Size = new System.Drawing.Size(80, 16);
            this.lblDocumento.TabIndex = 4;
            this.lblDocumento.Text = "Documento ";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(102, 88);
            this.txtUsuario.MaxLength = 50;
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(428, 22);
            this.txtUsuario.TabIndex = 4;
            this.txtUsuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUsuario_KeyPress);
            this.txtUsuario.Validating += new System.ComponentModel.CancelEventHandler(this.txtUsuario_Validating);
            // 
            // lblContraseña
            // 
            this.lblContraseña.AutoSize = true;
            this.lblContraseña.Location = new System.Drawing.Point(18, 125);
            this.lblContraseña.Name = "lblContraseña";
            this.lblContraseña.Size = new System.Drawing.Size(77, 16);
            this.lblContraseña.TabIndex = 5;
            this.lblContraseña.Text = "Contraseña";
            // 
            // txtDocumento
            // 
            this.txtDocumento.Location = new System.Drawing.Point(102, 23);
            this.txtDocumento.MaxLength = 20;
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Size = new System.Drawing.Size(428, 22);
            this.txtDocumento.TabIndex = 0;
            this.txtDocumento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDocumento_KeyPress);
            this.txtDocumento.Validating += new System.ComponentModel.CancelEventHandler(this.txtDocumento_Validating);
            // 
            // txtContraseña
            // 
            this.txtContraseña.Location = new System.Drawing.Point(102, 122);
            this.txtContraseña.MaxLength = 20;
            this.txtContraseña.Name = "txtContraseña";
            this.txtContraseña.Size = new System.Drawing.Size(428, 22);
            this.txtContraseña.TabIndex = 5;
            this.txtContraseña.UseSystemPasswordChar = true;
            this.txtContraseña.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtContraseña_KeyPress);
            this.txtContraseña.Validating += new System.ComponentModel.CancelEventHandler(this.txtContraseña_Validating);
            // 
            // gbxPermisosUsuario
            // 
            this.gbxPermisosUsuario.Controls.Add(this.btnGuardarPermisos);
            this.gbxPermisosUsuario.Controls.Add(this.lklblMarcar);
            this.gbxPermisosUsuario.Controls.Add(this.cbxCargo);
            this.gbxPermisosUsuario.Controls.Add(this.lklblDesmarcar);
            this.gbxPermisosUsuario.Controls.Add(this.dgvPermiso);
            this.gbxPermisosUsuario.Controls.Add(this.txtDireccion);
            this.gbxPermisosUsuario.Controls.Add(this.txtTelefono);
            this.gbxPermisosUsuario.Location = new System.Drawing.Point(578, 34);
            this.gbxPermisosUsuario.Name = "gbxPermisosUsuario";
            this.gbxPermisosUsuario.Size = new System.Drawing.Size(511, 417);
            this.gbxPermisosUsuario.TabIndex = 3;
            this.gbxPermisosUsuario.TabStop = false;
            this.gbxPermisosUsuario.Text = "Permisos de usuario";
            // 
            // btnGuardarPermisos
            // 
            this.btnGuardarPermisos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.5F);
            this.btnGuardarPermisos.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardarPermisos.Image")));
            this.btnGuardarPermisos.Location = new System.Drawing.Point(479, 9);
            this.btnGuardarPermisos.Name = "btnGuardarPermisos";
            this.btnGuardarPermisos.Size = new System.Drawing.Size(27, 22);
            this.btnGuardarPermisos.TabIndex = 52;
            this.btnGuardarPermisos.UseVisualStyleBackColor = true;
            this.btnGuardarPermisos.Click += new System.EventHandler(this.btnGuardarPermisos_Click);
            // 
            // lklblMarcar
            // 
            this.lklblMarcar.AutoSize = true;
            this.lklblMarcar.Location = new System.Drawing.Point(234, 13);
            this.lklblMarcar.Name = "lklblMarcar";
            this.lklblMarcar.Size = new System.Drawing.Size(93, 16);
            this.lklblMarcar.TabIndex = 0;
            this.lklblMarcar.TabStop = true;
            this.lklblMarcar.Text = "Marcar Todos";
            this.lklblMarcar.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lklblMarcar_LinkClicked);
            // 
            // cbxCargo
            // 
            this.cbxCargo.DisplayMember = "descripciontipo";
            this.cbxCargo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCargo.FormattingEnabled = true;
            this.cbxCargo.Location = new System.Drawing.Point(195, 6);
            this.cbxCargo.Name = "cbxCargo";
            this.cbxCargo.Size = new System.Drawing.Size(18, 24);
            this.cbxCargo.TabIndex = 0;
            this.cbxCargo.ValueMember = "idtipo";
            this.cbxCargo.Visible = false;
            // 
            // lklblDesmarcar
            // 
            this.lklblDesmarcar.AutoSize = true;
            this.lklblDesmarcar.Location = new System.Drawing.Point(344, 13);
            this.lklblDesmarcar.Name = "lklblDesmarcar";
            this.lklblDesmarcar.Size = new System.Drawing.Size(118, 16);
            this.lklblDesmarcar.TabIndex = 1;
            this.lklblDesmarcar.TabStop = true;
            this.lklblDesmarcar.Text = "Desmarcar Todos";
            this.lklblDesmarcar.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lklblDesmarcar_LinkClicked);
            // 
            // dgvPermiso
            // 
            this.dgvPermiso.AllowUserToAddRows = false;
            this.dgvPermiso.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvPermiso.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Aplica,
            this.Permiso,
            this.Menu});
            this.dgvPermiso.Location = new System.Drawing.Point(4, 32);
            this.dgvPermiso.Name = "dgvPermiso";
            this.dgvPermiso.RowHeadersVisible = false;
            this.dgvPermiso.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvPermiso.Size = new System.Drawing.Size(502, 379);
            this.dgvPermiso.TabIndex = 2;
            this.dgvPermiso.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPermiso_CellClick);
            this.dgvPermiso.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvPermiso_CurrentCellDirtyStateChanged);
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(179, 9);
            this.txtDireccion.MaxLength = 40;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(10, 22);
            this.txtDireccion.TabIndex = 3;
            this.txtDireccion.Visible = false;
            this.txtDireccion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDireccion_KeyPress);
            this.txtDireccion.Validating += new System.ComponentModel.CancelEventHandler(this.txtDireccion_Validating);
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(164, 9);
            this.txtTelefono.MaxLength = 20;
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(10, 22);
            this.txtTelefono.TabIndex = 2;
            this.txtTelefono.Visible = false;
            this.txtTelefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTelefono_KeyPress);
            this.txtTelefono.Validating += new System.ComponentModel.CancelEventHandler(this.txtTelefono_Validating);
            // 
            // tpConsultapermosoYUsuario
            // 
            this.tpConsultapermosoYUsuario.Controls.Add(this.tsMenuConsulta);
            this.tpConsultapermosoYUsuario.Controls.Add(this.gbxConsultaUsuario);
            this.tpConsultapermosoYUsuario.Controls.Add(this.gbxUsuario);
            this.tpConsultapermosoYUsuario.Controls.Add(this.gbxPermisos);
            this.tpConsultapermosoYUsuario.Location = new System.Drawing.Point(4, 25);
            this.tpConsultapermosoYUsuario.Name = "tpConsultapermosoYUsuario";
            this.tpConsultapermosoYUsuario.Padding = new System.Windows.Forms.Padding(3);
            this.tpConsultapermosoYUsuario.Size = new System.Drawing.Size(1094, 455);
            this.tpConsultapermosoYUsuario.TabIndex = 1;
            this.tpConsultapermosoYUsuario.Text = "Consultar Permisos y usuarios";
            this.tpConsultapermosoYUsuario.UseVisualStyleBackColor = true;
            // 
            // tsMenuConsulta
            // 
            this.tsMenuConsulta.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnEditar,
            this.tsbtnEliminar,
            this.tsBtnSeleccionar,
            this.tsbtnSalirConsulta});
            this.tsMenuConsulta.Location = new System.Drawing.Point(3, 3);
            this.tsMenuConsulta.Name = "tsMenuConsulta";
            this.tsMenuConsulta.Size = new System.Drawing.Size(1088, 25);
            this.tsMenuConsulta.TabIndex = 3;
            this.tsMenuConsulta.Text = "toolStrip1";
            // 
            // tsbtnEditar
            // 
            this.tsbtnEditar.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnEditar.Image")));
            this.tsbtnEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnEditar.Name = "tsbtnEditar";
            this.tsbtnEditar.Size = new System.Drawing.Size(57, 22);
            this.tsbtnEditar.Text = "Editar";
            this.tsbtnEditar.Click += new System.EventHandler(this.tsbtnEditar_Click);
            // 
            // tsbtnEliminar
            // 
            this.tsbtnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnEliminar.Image")));
            this.tsbtnEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnEliminar.Name = "tsbtnEliminar";
            this.tsbtnEliminar.Size = new System.Drawing.Size(70, 22);
            this.tsbtnEliminar.Text = "Eliminar";
            this.tsbtnEliminar.Click += new System.EventHandler(this.tsbtnEliminar_Click);
            // 
            // tsBtnSeleccionar
            // 
            this.tsBtnSeleccionar.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnSeleccionar.Image")));
            this.tsBtnSeleccionar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnSeleccionar.Name = "tsBtnSeleccionar";
            this.tsBtnSeleccionar.Size = new System.Drawing.Size(116, 22);
            this.tsBtnSeleccionar.Text = "Seleccionar [F12]";
            this.tsBtnSeleccionar.Visible = false;
            this.tsBtnSeleccionar.Click += new System.EventHandler(this.tsBtnSeleccionar_Click);
            // 
            // tsbtnSalirConsulta
            // 
            this.tsbtnSalirConsulta.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnSalirConsulta.Image")));
            this.tsbtnSalirConsulta.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnSalirConsulta.Name = "tsbtnSalirConsulta";
            this.tsbtnSalirConsulta.Size = new System.Drawing.Size(49, 22);
            this.tsbtnSalirConsulta.Text = "Salir";
            this.tsbtnSalirConsulta.Click += new System.EventHandler(this.tsbtnSalirConsulta_Click);
            // 
            // gbxConsultaUsuario
            // 
            this.gbxConsultaUsuario.Controls.Add(this.cbxConsultaCriterio);
            this.gbxConsultaUsuario.Controls.Add(this.cbxIgualContenga);
            this.gbxConsultaUsuario.Controls.Add(this.cbxCargoUsuario);
            this.gbxConsultaUsuario.Controls.Add(this.txtConsulta);
            this.gbxConsultaUsuario.Controls.Add(this.chbxIncluir);
            this.gbxConsultaUsuario.Controls.Add(this.btnConsultar);
            this.gbxConsultaUsuario.Location = new System.Drawing.Point(7, 31);
            this.gbxConsultaUsuario.Name = "gbxConsultaUsuario";
            this.gbxConsultaUsuario.Size = new System.Drawing.Size(981, 86);
            this.gbxConsultaUsuario.TabIndex = 0;
            this.gbxConsultaUsuario.TabStop = false;
            this.gbxConsultaUsuario.Text = "Consultar usuarios";
            // 
            // cbxConsultaCriterio
            // 
            this.cbxConsultaCriterio.DisplayMember = "Nombre";
            this.cbxConsultaCriterio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxConsultaCriterio.FormattingEnabled = true;
            this.cbxConsultaCriterio.Location = new System.Drawing.Point(6, 32);
            this.cbxConsultaCriterio.Name = "cbxConsultaCriterio";
            this.cbxConsultaCriterio.Size = new System.Drawing.Size(121, 24);
            this.cbxConsultaCriterio.TabIndex = 0;
            this.cbxConsultaCriterio.ValueMember = "Id";
            this.cbxConsultaCriterio.SelectionChangeCommitted += new System.EventHandler(this.cbxConsultaCriterio_SelectionChangeCommitted);
            // 
            // cbxIgualContenga
            // 
            this.cbxIgualContenga.DisplayMember = "Nombre";
            this.cbxIgualContenga.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxIgualContenga.Enabled = false;
            this.cbxIgualContenga.FormattingEnabled = true;
            this.cbxIgualContenga.Location = new System.Drawing.Point(148, 32);
            this.cbxIgualContenga.Name = "cbxIgualContenga";
            this.cbxIgualContenga.Size = new System.Drawing.Size(121, 24);
            this.cbxIgualContenga.TabIndex = 1;
            this.cbxIgualContenga.ValueMember = "Id";
            this.cbxIgualContenga.SelectionChangeCommitted += new System.EventHandler(this.cbxIgualContenga_SelectionChangeCommitted);
            // 
            // cbxCargoUsuario
            // 
            this.cbxCargoUsuario.DisplayMember = "descripciontipo";
            this.cbxCargoUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCargoUsuario.Enabled = false;
            this.cbxCargoUsuario.FormattingEnabled = true;
            this.cbxCargoUsuario.Location = new System.Drawing.Point(293, 32);
            this.cbxCargoUsuario.Name = "cbxCargoUsuario";
            this.cbxCargoUsuario.Size = new System.Drawing.Size(121, 24);
            this.cbxCargoUsuario.TabIndex = 3;
            this.cbxCargoUsuario.ValueMember = "idtipo";
            this.cbxCargoUsuario.SelectionChangeCommitted += new System.EventHandler(this.cbxCargoUsuario_SelectionChangeCommitted);
            // 
            // txtConsulta
            // 
            this.txtConsulta.Location = new System.Drawing.Point(441, 32);
            this.txtConsulta.Name = "txtConsulta";
            this.txtConsulta.Size = new System.Drawing.Size(306, 22);
            this.txtConsulta.TabIndex = 2;
            this.txtConsulta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtConsulta_KeyPress);
            // 
            // chbxIncluir
            // 
            this.chbxIncluir.AutoSize = true;
            this.chbxIncluir.Enabled = false;
            this.chbxIncluir.Location = new System.Drawing.Point(772, 34);
            this.chbxIncluir.Name = "chbxIncluir";
            this.chbxIncluir.Size = new System.Drawing.Size(117, 20);
            this.chbxIncluir.TabIndex = 5;
            this.chbxIncluir.Text = "Incluir inactivos";
            this.chbxIncluir.UseVisualStyleBackColor = true;
            // 
            // btnConsultar
            // 
            this.btnConsultar.Image = ((System.Drawing.Image)(resources.GetObject("btnConsultar.Image")));
            this.btnConsultar.Location = new System.Drawing.Point(907, 32);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(39, 23);
            this.btnConsultar.TabIndex = 4;
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // gbxUsuario
            // 
            this.gbxUsuario.Controls.Add(this.dgvUsuario);
            this.gbxUsuario.Location = new System.Drawing.Point(7, 123);
            this.gbxUsuario.Name = "gbxUsuario";
            this.gbxUsuario.Size = new System.Drawing.Size(747, 300);
            this.gbxUsuario.TabIndex = 1;
            this.gbxUsuario.TabStop = false;
            this.gbxUsuario.Text = "Usuario";
            // 
            // dgvUsuario
            // 
            this.dgvUsuario.AllowUserToAddRows = false;
            this.dgvUsuario.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsuario.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvUsuario.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvUsuario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdUsuario,
            this.Cargo,
            this.Nombre,
            this.Documento,
            this.Direccion,
            this.Telefono,
            this.Estado});
            this.dgvUsuario.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvUsuario.GridColor = System.Drawing.SystemColors.Window;
            this.dgvUsuario.Location = new System.Drawing.Point(6, 21);
            this.dgvUsuario.Name = "dgvUsuario";
            this.dgvUsuario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvUsuario.Size = new System.Drawing.Size(732, 273);
            this.dgvUsuario.TabIndex = 0;
            this.dgvUsuario.Click += new System.EventHandler(this.dgvUsuario_Click);
            // 
            // IdUsuario
            // 
            this.IdUsuario.DataPropertyName = "id";
            this.IdUsuario.HeaderText = "IdUsuario";
            this.IdUsuario.Name = "IdUsuario";
            this.IdUsuario.Visible = false;
            // 
            // Cargo
            // 
            this.Cargo.DataPropertyName = "cargo";
            this.Cargo.HeaderText = "Cargo";
            this.Cargo.Name = "Cargo";
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "nombre";
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            // 
            // Documento
            // 
            this.Documento.DataPropertyName = "documento";
            this.Documento.HeaderText = "Documento";
            this.Documento.Name = "Documento";
            // 
            // Direccion
            // 
            this.Direccion.DataPropertyName = "direccion";
            this.Direccion.HeaderText = "Direcciòn";
            this.Direccion.Name = "Direccion";
            // 
            // Telefono
            // 
            this.Telefono.DataPropertyName = "telefono";
            this.Telefono.HeaderText = "Telefono";
            this.Telefono.Name = "Telefono";
            // 
            // Estado
            // 
            this.Estado.DataPropertyName = "estado";
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            // 
            // gbxPermisos
            // 
            this.gbxPermisos.Controls.Add(this.dgvPermisoUsuario);
            this.gbxPermisos.Location = new System.Drawing.Point(760, 123);
            this.gbxPermisos.Name = "gbxPermisos";
            this.gbxPermisos.Size = new System.Drawing.Size(228, 300);
            this.gbxPermisos.TabIndex = 2;
            this.gbxPermisos.TabStop = false;
            this.gbxPermisos.Text = "Permisos";
            // 
            // dgvPermisoUsuario
            // 
            this.dgvPermisoUsuario.AllowUserToAddRows = false;
            this.dgvPermisoUsuario.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPermisoUsuario.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvPermisoUsuario.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvPermisoUsuario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPermisoUsuario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdPermiso,
            this.DescripcionPermiso});
            this.dgvPermisoUsuario.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvPermisoUsuario.GridColor = System.Drawing.SystemColors.Window;
            this.dgvPermisoUsuario.Location = new System.Drawing.Point(6, 21);
            this.dgvPermisoUsuario.Name = "dgvPermisoUsuario";
            this.dgvPermisoUsuario.Size = new System.Drawing.Size(216, 273);
            this.dgvPermisoUsuario.TabIndex = 0;
            // 
            // IdPermiso
            // 
            this.IdPermiso.DataPropertyName = "idpermiso";
            this.IdPermiso.HeaderText = "Idpermiso";
            this.IdPermiso.Name = "IdPermiso";
            this.IdPermiso.Visible = false;
            // 
            // DescripcionPermiso
            // 
            this.DescripcionPermiso.DataPropertyName = "descripcionpermiso";
            this.DescripcionPermiso.HeaderText = "Permisos";
            this.DescripcionPermiso.Name = "DescripcionPermiso";
            // 
            // Id
            // 
            this.Id.DataPropertyName = "idpermiso";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // Aplica
            // 
            this.Aplica.HeaderText = "Aplica";
            this.Aplica.Name = "Aplica";
            this.Aplica.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Aplica.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Permiso
            // 
            this.Permiso.DataPropertyName = "descripcionpermiso";
            this.Permiso.HeaderText = "Permisos del usuario";
            this.Permiso.Name = "Permiso";
            this.Permiso.Width = 380;
            // 
            // Menu
            // 
            this.Menu.DataPropertyName = "menu";
            this.Menu.HeaderText = "Menu";
            this.Menu.Name = "Menu";
            this.Menu.Visible = false;
            // 
            // btnGuardarUsuario
            // 
            this.btnGuardarUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.btnGuardarUsuario.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardarUsuario.Image")));
            this.btnGuardarUsuario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardarUsuario.Location = new System.Drawing.Point(447, 155);
            this.btnGuardarUsuario.Name = "btnGuardarUsuario";
            this.btnGuardarUsuario.Size = new System.Drawing.Size(83, 22);
            this.btnGuardarUsuario.TabIndex = 53;
            this.btnGuardarUsuario.Text = "Guardar";
            this.btnGuardarUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardarUsuario.UseVisualStyleBackColor = true;
            this.btnGuardarUsuario.Click += new System.EventHandler(this.btnGuardarUsuario_Click);
            // 
            // PanelMenuArticulo
            // 
            this.PanelMenuArticulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelMenuArticulo.Controls.Add(this.tsMenuArticulo);
            this.PanelMenuArticulo.Location = new System.Drawing.Point(510, 13);
            this.PanelMenuArticulo.Name = "PanelMenuArticulo";
            this.PanelMenuArticulo.Size = new System.Drawing.Size(38, 206);
            this.PanelMenuArticulo.TabIndex = 4;
            // 
            // tsMenuArticulo
            // 
            this.tsMenuArticulo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnEditarUsuario,
            this.btnAnularUsuario});
            this.tsMenuArticulo.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.tsMenuArticulo.Location = new System.Drawing.Point(0, 0);
            this.tsMenuArticulo.Name = "tsMenuArticulo";
            this.tsMenuArticulo.Size = new System.Drawing.Size(36, 34);
            this.tsMenuArticulo.TabIndex = 0;
            this.tsMenuArticulo.Text = "Menu de Registro";
            // 
            // btnEditarUsuario
            // 
            this.btnEditarUsuario.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEditarUsuario.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnEditarUsuario.Image = ((System.Drawing.Image)(resources.GetObject("btnEditarUsuario.Image")));
            this.btnEditarUsuario.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditarUsuario.Name = "btnEditarUsuario";
            this.btnEditarUsuario.Size = new System.Drawing.Size(34, 20);
            this.btnEditarUsuario.Text = "Editar [F2]";
            this.btnEditarUsuario.Click += new System.EventHandler(this.btnEditarUsuario_Click);
            // 
            // btnAnularUsuario
            // 
            this.btnAnularUsuario.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAnularUsuario.Image = ((System.Drawing.Image)(resources.GetObject("btnAnularUsuario.Image")));
            this.btnAnularUsuario.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAnularUsuario.Name = "btnAnularUsuario";
            this.btnAnularUsuario.Size = new System.Drawing.Size(34, 20);
            this.btnAnularUsuario.Text = "Anular Factura [F2]";
            this.btnAnularUsuario.Visible = false;
            this.btnAnularUsuario.Click += new System.EventHandler(this.btnAnularUsuario_Click);
            // 
            // IdUsuario_
            // 
            this.IdUsuario_.DataPropertyName = "id";
            this.IdUsuario_.HeaderText = "Id";
            this.IdUsuario_.Name = "IdUsuario_";
            this.IdUsuario_.Visible = false;
            // 
            // Documento_
            // 
            this.Documento_.DataPropertyName = "documento";
            this.Documento_.HeaderText = "Documento";
            this.Documento_.Name = "Documento_";
            this.Documento_.Width = 140;
            // 
            // NameUsuario
            // 
            this.NameUsuario.DataPropertyName = "nombre";
            this.NameUsuario.HeaderText = "Nombre";
            this.NameUsuario.Name = "NameUsuario";
            this.NameUsuario.Width = 200;
            // 
            // UserUsuario
            // 
            this.UserUsuario.DataPropertyName = "usuario";
            this.UserUsuario.HeaderText = "Usuario";
            this.UserUsuario.Name = "UserUsuario";
            this.UserUsuario.Width = 145;
            // 
            // Password
            // 
            this.Password.DataPropertyName = "contrasenia";
            this.Password.HeaderText = "Password";
            this.Password.Name = "Password";
            this.Password.Visible = false;
            // 
            // frmUsuarioSistema
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1101, 485);
            this.Controls.Add(this.tpPermiso);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUsuarioSistema";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Usuarios del sistema";
            this.Load += new System.EventHandler(this.frmUsuarioSistema_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmUsuarioSistema_KeyDown);
            this.tpPermiso.ResumeLayout(false);
            this.tpPermisoYUsusrio.ResumeLayout(false);
            this.tpPermisoYUsusrio.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.gbxDatosUsuario.ResumeLayout(false);
            this.gbxDatosUsuario.PerformLayout();
            this.gbxPermisosUsuario.ResumeLayout(false);
            this.gbxPermisosUsuario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPermiso)).EndInit();
            this.tpConsultapermosoYUsuario.ResumeLayout(false);
            this.tpConsultapermosoYUsuario.PerformLayout();
            this.tsMenuConsulta.ResumeLayout(false);
            this.tsMenuConsulta.PerformLayout();
            this.gbxConsultaUsuario.ResumeLayout(false);
            this.gbxConsultaUsuario.PerformLayout();
            this.gbxUsuario.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuario)).EndInit();
            this.gbxPermisos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPermisoUsuario)).EndInit();
            this.PanelMenuArticulo.ResumeLayout(false);
            this.PanelMenuArticulo.PerformLayout();
            this.tsMenuArticulo.ResumeLayout(false);
            this.tsMenuArticulo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tpPermisoYUsusrio;
        private System.Windows.Forms.GroupBox gbxPermisosUsuario;
        private System.Windows.Forms.GroupBox gbxDatosUsuario;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtDocumento;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblDocumento;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TabPage tpConsultapermosoYUsuario;
        private System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.ToolStripButton tsbtnGuardar;
        private System.Windows.Forms.ToolStripButton tsbtnSalir;
        private System.Windows.Forms.DataGridView dgvPermiso;
        private System.Windows.Forms.ComboBox cbxCargo;
        private System.Windows.Forms.TextBox txtContraseña;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lblContraseña;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.LinkLabel lklblDesmarcar;
        private System.Windows.Forms.LinkLabel lklblMarcar;
        private System.Windows.Forms.ToolStrip tsMenuConsulta;
        private System.Windows.Forms.GroupBox gbxPermisos;
        private System.Windows.Forms.DataGridView dgvPermisoUsuario;
        private System.Windows.Forms.GroupBox gbxUsuario;
        private System.Windows.Forms.DataGridView dgvUsuario;
        private System.Windows.Forms.GroupBox gbxConsultaUsuario;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.ComboBox cbxCargoUsuario;
        private System.Windows.Forms.TextBox txtConsulta;
        private System.Windows.Forms.ComboBox cbxIgualContenga;
        private System.Windows.Forms.ComboBox cbxConsultaCriterio;
        private System.Windows.Forms.CheckBox chbxIncluir;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdPermiso;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescripcionPermiso;
        private System.Windows.Forms.ToolStripButton tsbtnEditar;
        private System.Windows.Forms.ToolStripButton tsbtnEliminar;
        private System.Windows.Forms.ToolStripButton tsbtnSalirConsulta;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cargo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Documento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Direccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        public System.Windows.Forms.ToolStripButton tsBtnSeleccionar;
        public System.Windows.Forms.TabControl tpPermiso;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.Button btnGuardarPermisos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Aplica;
        private System.Windows.Forms.DataGridViewTextBoxColumn Permiso;
        private System.Windows.Forms.DataGridViewTextBoxColumn Menu;
        private System.Windows.Forms.Button btnGuardarUsuario;
        private System.Windows.Forms.Panel PanelMenuArticulo;
        private System.Windows.Forms.ToolStrip tsMenuArticulo;
        private System.Windows.Forms.ToolStripButton btnEditarUsuario;
        private System.Windows.Forms.ToolStripButton btnAnularUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdUsuario_;
        private System.Windows.Forms.DataGridViewTextBoxColumn Documento_;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Password;
    }
}