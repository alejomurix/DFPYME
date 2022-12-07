namespace Aplicacion.Administracion.Usuario
{
    partial class frmEditaUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditaUsuario));
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.tsbtnGuardar = new System.Windows.Forms.ToolStripButton();
            this.tsbtnSalir = new System.Windows.Forms.ToolStripButton();
            this.gbxUsuario = new System.Windows.Forms.GroupBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtDocumeto = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.lblDocumento = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.gbxDatosSistema = new System.Windows.Forms.GroupBox();
            this.chbxMostrarContraseña = new System.Windows.Forms.CheckBox();
            this.rbtnInactivo = new System.Windows.Forms.RadioButton();
            this.rbtnActivo = new System.Windows.Forms.RadioButton();
            this.cbxCargo = new System.Windows.Forms.ComboBox();
            this.txtContraseña = new System.Windows.Forms.TextBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblContraseña = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.Cargo = new System.Windows.Forms.Label();
            this.gbxPermisosUsuario = new System.Windows.Forms.GroupBox();
            this.lkDesmarcaraTodos = new System.Windows.Forms.LinkLabel();
            this.lklblMarcartodos = new System.Windows.Forms.LinkLabel();
            this.dgvEditaPermisos = new System.Windows.Forms.DataGridView();
            this.IdPermiso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Permiso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Aplica = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.txtCargoEditar = new System.Windows.Forms.TextBox();
            this.btnEditarCargo = new System.Windows.Forms.Button();
            this.btnDesacer = new System.Windows.Forms.Button();
            this.tsMenu.SuspendLayout();
            this.gbxUsuario.SuspendLayout();
            this.gbxDatosSistema.SuspendLayout();
            this.gbxPermisosUsuario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEditaPermisos)).BeginInit();
            this.SuspendLayout();
            // 
            // tsMenu
            // 
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnGuardar,
            this.tsbtnSalir});
            this.tsMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(767, 25);
            this.tsMenu.TabIndex = 0;
            this.tsMenu.Text = "toolStrip1";
            // 
            // tsbtnGuardar
            // 
            this.tsbtnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnGuardar.Image")));
            this.tsbtnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnGuardar.Name = "tsbtnGuardar";
            this.tsbtnGuardar.Size = new System.Drawing.Size(69, 22);
            this.tsbtnGuardar.Text = "Guardar";
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
            // gbxUsuario
            // 
            this.gbxUsuario.Controls.Add(this.lblNombre);
            this.gbxUsuario.Controls.Add(this.txtNombre);
            this.gbxUsuario.Controls.Add(this.lblDocumento);
            this.gbxUsuario.Controls.Add(this.txtDocumeto);
            this.gbxUsuario.Controls.Add(this.lblTelefono);
            this.gbxUsuario.Controls.Add(this.txtTelefono);
            this.gbxUsuario.Controls.Add(this.lblDireccion);
            this.gbxUsuario.Controls.Add(this.txtDireccion);
            this.gbxUsuario.Location = new System.Drawing.Point(10, 34);
            this.gbxUsuario.Margin = new System.Windows.Forms.Padding(4);
            this.gbxUsuario.Name = "gbxUsuario";
            this.gbxUsuario.Padding = new System.Windows.Forms.Padding(4);
            this.gbxUsuario.Size = new System.Drawing.Size(365, 178);
            this.gbxUsuario.TabIndex = 1;
            this.gbxUsuario.TabStop = false;
            this.gbxUsuario.Text = "Datos del Usuario";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(99, 129);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(230, 22);
            this.txtDireccion.TabIndex = 7;
            this.txtDireccion.Validating += new System.ComponentModel.CancelEventHandler(this.txtDireccion_Validating);
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(99, 93);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(230, 22);
            this.txtTelefono.TabIndex = 6;
            this.txtTelefono.Validating += new System.ComponentModel.CancelEventHandler(this.txtTelefono_Validating);
            // 
            // txtDocumeto
            // 
            this.txtDocumeto.Location = new System.Drawing.Point(99, 58);
            this.txtDocumeto.Name = "txtDocumeto";
            this.txtDocumeto.Size = new System.Drawing.Size(230, 22);
            this.txtDocumeto.TabIndex = 5;
            this.txtDocumeto.Validating += new System.ComponentModel.CancelEventHandler(this.txtDocumeto_Validating);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(99, 23);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(230, 22);
            this.txtNombre.TabIndex = 4;
            this.txtNombre.Validating += new System.ComponentModel.CancelEventHandler(this.txtNombre_Validating);
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Location = new System.Drawing.Point(7, 134);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(65, 16);
            this.lblDireccion.TabIndex = 3;
            this.lblDireccion.Text = "Dirección";
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Location = new System.Drawing.Point(7, 98);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(62, 16);
            this.lblTelefono.TabIndex = 2;
            this.lblTelefono.Text = "Teléfono";
            // 
            // lblDocumento
            // 
            this.lblDocumento.AutoSize = true;
            this.lblDocumento.Location = new System.Drawing.Point(7, 63);
            this.lblDocumento.Name = "lblDocumento";
            this.lblDocumento.Size = new System.Drawing.Size(77, 16);
            this.lblDocumento.TabIndex = 1;
            this.lblDocumento.Text = "Documento";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(7, 28);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(57, 16);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre";
            // 
            // gbxDatosSistema
            // 
            this.gbxDatosSistema.Controls.Add(this.Cargo);
            this.gbxDatosSistema.Controls.Add(this.txtCargoEditar);
            this.gbxDatosSistema.Controls.Add(this.cbxCargo);
            this.gbxDatosSistema.Controls.Add(this.btnEditarCargo);
            this.gbxDatosSistema.Controls.Add(this.btnDesacer);
            this.gbxDatosSistema.Controls.Add(this.lblUsuario);
            this.gbxDatosSistema.Controls.Add(this.txtUsuario);
            this.gbxDatosSistema.Controls.Add(this.lblContraseña);
            this.gbxDatosSistema.Controls.Add(this.txtContraseña);
            this.gbxDatosSistema.Controls.Add(this.chbxMostrarContraseña);
            this.gbxDatosSistema.Controls.Add(this.lblEstado);
            this.gbxDatosSistema.Controls.Add(this.rbtnActivo);
            this.gbxDatosSistema.Controls.Add(this.rbtnInactivo);
            this.gbxDatosSistema.Location = new System.Drawing.Point(392, 34);
            this.gbxDatosSistema.Margin = new System.Windows.Forms.Padding(4);
            this.gbxDatosSistema.Name = "gbxDatosSistema";
            this.gbxDatosSistema.Padding = new System.Windows.Forms.Padding(4);
            this.gbxDatosSistema.Size = new System.Drawing.Size(365, 178);
            this.gbxDatosSistema.TabIndex = 2;
            this.gbxDatosSistema.TabStop = false;
            this.gbxDatosSistema.Text = "Datos del Sistema";
            // 
            // chbxMostrarContraseña
            // 
            this.chbxMostrarContraseña.AutoSize = true;
            this.chbxMostrarContraseña.Location = new System.Drawing.Point(97, 122);
            this.chbxMostrarContraseña.Name = "chbxMostrarContraseña";
            this.chbxMostrarContraseña.Size = new System.Drawing.Size(142, 20);
            this.chbxMostrarContraseña.TabIndex = 9;
            this.chbxMostrarContraseña.Text = "Mostrar contraseña";
            this.chbxMostrarContraseña.UseVisualStyleBackColor = true;
            this.chbxMostrarContraseña.Click += new System.EventHandler(this.chbxMostrarContraseña_Click);
            // 
            // rbtnInactivo
            // 
            this.rbtnInactivo.AutoSize = true;
            this.rbtnInactivo.Location = new System.Drawing.Point(169, 148);
            this.rbtnInactivo.Name = "rbtnInactivo";
            this.rbtnInactivo.Size = new System.Drawing.Size(72, 20);
            this.rbtnInactivo.TabIndex = 8;
            this.rbtnInactivo.TabStop = true;
            this.rbtnInactivo.Text = "Inactivo";
            this.rbtnInactivo.UseVisualStyleBackColor = true;
            // 
            // rbtnActivo
            // 
            this.rbtnActivo.AutoSize = true;
            this.rbtnActivo.Location = new System.Drawing.Point(91, 148);
            this.rbtnActivo.Name = "rbtnActivo";
            this.rbtnActivo.Size = new System.Drawing.Size(63, 20);
            this.rbtnActivo.TabIndex = 7;
            this.rbtnActivo.TabStop = true;
            this.rbtnActivo.Text = "Activo";
            this.rbtnActivo.UseVisualStyleBackColor = true;
            // 
            // cbxCargo
            // 
            this.cbxCargo.DisplayMember = "descripciontipo";
            this.cbxCargo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCargo.FormattingEnabled = true;
            this.cbxCargo.Location = new System.Drawing.Point(91, 23);
            this.cbxCargo.Name = "cbxCargo";
            this.cbxCargo.Size = new System.Drawing.Size(230, 24);
            this.cbxCargo.TabIndex = 6;
            this.cbxCargo.ValueMember = "idtipo";
            // 
            // txtContraseña
            // 
            this.txtContraseña.Location = new System.Drawing.Point(91, 93);
            this.txtContraseña.Name = "txtContraseña";
            this.txtContraseña.Size = new System.Drawing.Size(230, 22);
            this.txtContraseña.TabIndex = 5;
            this.txtContraseña.UseSystemPasswordChar = true;
            this.txtContraseña.Validating += new System.ComponentModel.CancelEventHandler(this.txtContraseña_Validating);
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(91, 57);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(230, 22);
            this.txtUsuario.TabIndex = 4;
            this.txtUsuario.Validating += new System.ComponentModel.CancelEventHandler(this.txtUsuario_Validating);
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(7, 152);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(51, 16);
            this.lblEstado.TabIndex = 3;
            this.lblEstado.Text = "Estado";
            // 
            // lblContraseña
            // 
            this.lblContraseña.AutoSize = true;
            this.lblContraseña.Location = new System.Drawing.Point(7, 98);
            this.lblContraseña.Name = "lblContraseña";
            this.lblContraseña.Size = new System.Drawing.Size(77, 16);
            this.lblContraseña.TabIndex = 2;
            this.lblContraseña.Text = "Contraseña";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(7, 63);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(55, 16);
            this.lblUsuario.TabIndex = 1;
            this.lblUsuario.Text = "Usuario";
            // 
            // Cargo
            // 
            this.Cargo.AutoSize = true;
            this.Cargo.Location = new System.Drawing.Point(7, 28);
            this.Cargo.Name = "Cargo";
            this.Cargo.Size = new System.Drawing.Size(45, 16);
            this.Cargo.TabIndex = 0;
            this.Cargo.Text = "Cargo";
            // 
            // gbxPermisosUsuario
            // 
            this.gbxPermisosUsuario.Controls.Add(this.lklblMarcartodos);
            this.gbxPermisosUsuario.Controls.Add(this.lkDesmarcaraTodos);
            this.gbxPermisosUsuario.Controls.Add(this.dgvEditaPermisos);
            this.gbxPermisosUsuario.Location = new System.Drawing.Point(10, 232);
            this.gbxPermisosUsuario.Margin = new System.Windows.Forms.Padding(4);
            this.gbxPermisosUsuario.Name = "gbxPermisosUsuario";
            this.gbxPermisosUsuario.Padding = new System.Windows.Forms.Padding(4);
            this.gbxPermisosUsuario.Size = new System.Drawing.Size(745, 268);
            this.gbxPermisosUsuario.TabIndex = 3;
            this.gbxPermisosUsuario.TabStop = false;
            this.gbxPermisosUsuario.Text = "Permisos del Usuario";
            // 
            // lkDesmarcaraTodos
            // 
            this.lkDesmarcaraTodos.AutoSize = true;
            this.lkDesmarcaraTodos.Location = new System.Drawing.Point(565, 32);
            this.lkDesmarcaraTodos.Name = "lkDesmarcaraTodos";
            this.lkDesmarcaraTodos.Size = new System.Drawing.Size(112, 16);
            this.lkDesmarcaraTodos.TabIndex = 2;
            this.lkDesmarcaraTodos.TabStop = true;
            this.lkDesmarcaraTodos.Text = "Desmarcar todos";
            this.lkDesmarcaraTodos.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lkDesmarcaraTodos_LinkClicked);
            // 
            // lklblMarcartodos
            // 
            this.lklblMarcartodos.AutoSize = true;
            this.lklblMarcartodos.Location = new System.Drawing.Point(429, 32);
            this.lklblMarcartodos.Name = "lklblMarcartodos";
            this.lklblMarcartodos.Size = new System.Drawing.Size(87, 16);
            this.lklblMarcartodos.TabIndex = 1;
            this.lklblMarcartodos.TabStop = true;
            this.lklblMarcartodos.Text = "Marcar todos";
            this.lklblMarcartodos.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lklblMarcartodos_LinkClicked);
            // 
            // dgvEditaPermisos
            // 
            this.dgvEditaPermisos.AllowUserToAddRows = false;
            this.dgvEditaPermisos.AllowUserToDeleteRows = false;
            this.dgvEditaPermisos.AllowUserToOrderColumns = true;
            this.dgvEditaPermisos.AllowUserToResizeColumns = false;
            this.dgvEditaPermisos.AllowUserToResizeRows = false;
            this.dgvEditaPermisos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEditaPermisos.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvEditaPermisos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEditaPermisos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdPermiso,
            this.Permiso,
            this.Aplica});
            this.dgvEditaPermisos.Location = new System.Drawing.Point(39, 51);
            this.dgvEditaPermisos.Name = "dgvEditaPermisos";
            this.dgvEditaPermisos.Size = new System.Drawing.Size(638, 210);
            this.dgvEditaPermisos.TabIndex = 0;
            // 
            // IdPermiso
            // 
            this.IdPermiso.DataPropertyName = "idpermiso";
            this.IdPermiso.HeaderText = "IdPermiso";
            this.IdPermiso.Name = "IdPermiso";
            this.IdPermiso.Visible = false;
            // 
            // Permiso
            // 
            this.Permiso.DataPropertyName = "descripcionpermiso";
            this.Permiso.HeaderText = "Permiso";
            this.Permiso.Name = "Permiso";
            // 
            // Aplica
            // 
            this.Aplica.HeaderText = "Aplica";
            this.Aplica.Name = "Aplica";
            // 
            // txtCargoEditar
            // 
            this.txtCargoEditar.Location = new System.Drawing.Point(91, 24);
            this.txtCargoEditar.Name = "txtCargoEditar";
            this.txtCargoEditar.Size = new System.Drawing.Size(229, 22);
            this.txtCargoEditar.TabIndex = 10;
            // 
            // btnEditarCargo
            // 
            this.btnEditarCargo.Image = ((System.Drawing.Image)(resources.GetObject("btnEditarCargo.Image")));
            this.btnEditarCargo.Location = new System.Drawing.Point(334, 23);
            this.btnEditarCargo.Name = "btnEditarCargo";
            this.btnEditarCargo.Size = new System.Drawing.Size(24, 24);
            this.btnEditarCargo.TabIndex = 11;
            this.btnEditarCargo.UseVisualStyleBackColor = true;
            this.btnEditarCargo.Click += new System.EventHandler(this.btnEditarCargo_Click);
            // 
            // btnDesacer
            // 
            this.btnDesacer.Image = ((System.Drawing.Image)(resources.GetObject("btnDesacer.Image")));
            this.btnDesacer.Location = new System.Drawing.Point(333, 24);
            this.btnDesacer.Name = "btnDesacer";
            this.btnDesacer.Size = new System.Drawing.Size(25, 24);
            this.btnDesacer.TabIndex = 12;
            this.btnDesacer.UseVisualStyleBackColor = true;
            this.btnDesacer.Click += new System.EventHandler(this.btnDesacer_Click);
            // 
            // frmEditaUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 513);
            this.Controls.Add(this.tsMenu);
            this.Controls.Add(this.gbxUsuario);
            this.Controls.Add(this.gbxDatosSistema);
            this.Controls.Add(this.gbxPermisosUsuario);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEditaUsuario";
            this.Text = "Editar Usuario";
            this.Load += new System.EventHandler(this.frmEditaUsuario_Load);
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.gbxUsuario.ResumeLayout(false);
            this.gbxUsuario.PerformLayout();
            this.gbxDatosSistema.ResumeLayout(false);
            this.gbxDatosSistema.PerformLayout();
            this.gbxPermisosUsuario.ResumeLayout(false);
            this.gbxPermisosUsuario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEditaPermisos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.GroupBox gbxUsuario;
        private System.Windows.Forms.GroupBox gbxDatosSistema;
        private System.Windows.Forms.GroupBox gbxPermisosUsuario;
        private System.Windows.Forms.ToolStripButton tsbtnGuardar;
        private System.Windows.Forms.ToolStripButton tsbtnSalir;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.Label lblDocumento;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtDocumeto;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.RadioButton rbtnInactivo;
        private System.Windows.Forms.RadioButton rbtnActivo;
        private System.Windows.Forms.ComboBox cbxCargo;
        private System.Windows.Forms.TextBox txtContraseña;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblContraseña;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label Cargo;
        private System.Windows.Forms.DataGridView dgvEditaPermisos;
        private System.Windows.Forms.CheckBox chbxMostrarContraseña;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdPermiso;
        private System.Windows.Forms.DataGridViewTextBoxColumn Permiso;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Aplica;
        private System.Windows.Forms.LinkLabel lkDesmarcaraTodos;
        private System.Windows.Forms.LinkLabel lklblMarcartodos;
        private System.Windows.Forms.Button btnDesacer;
        private System.Windows.Forms.Button btnEditarCargo;
        private System.Windows.Forms.TextBox txtCargoEditar;
    }
}