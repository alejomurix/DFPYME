namespace Aplicacion.Compras.Beneficiario
{
    partial class FrmBeneficio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBeneficio));
            this.tcBeneficio = new System.Windows.Forms.TabControl();
            this.tpNuevo = new System.Windows.Forms.TabPage();
            this.tsMenuNuevo = new System.Windows.Forms.ToolStrip();
            this.tsGuardar = new System.Windows.Forms.ToolStripButton();
            this.gbDatos = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbCiudad = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCelular = new System.Windows.Forms.TextBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.cbTipo = new System.Windows.Forms.ComboBox();
            this.lblDocumento = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.tpConsultas = new System.Windows.Forms.TabPage();
            this.tsMenuConsulta = new System.Windows.Forms.ToolStrip();
            this.btnEditar = new System.Windows.Forms.ToolStripButton();
            this.cbCriterio = new System.Windows.Forms.ComboBox();
            this.txtConsulta = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.gbConsulta = new System.Windows.Forms.GroupBox();
            this.dgBeneficiarios = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdRegimen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            this.tcBeneficio.SuspendLayout();
            this.tpNuevo.SuspendLayout();
            this.tsMenuNuevo.SuspendLayout();
            this.gbDatos.SuspendLayout();
            this.tpConsultas.SuspendLayout();
            this.tsMenuConsulta.SuspendLayout();
            this.gbConsulta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgBeneficiarios)).BeginInit();
            this.tsMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcBeneficio
            // 
            this.tcBeneficio.Controls.Add(this.tpNuevo);
            this.tcBeneficio.Controls.Add(this.tpConsultas);
            this.tcBeneficio.Location = new System.Drawing.Point(1, 27);
            this.tcBeneficio.Name = "tcBeneficio";
            this.tcBeneficio.SelectedIndex = 0;
            this.tcBeneficio.Size = new System.Drawing.Size(452, 437);
            this.tcBeneficio.TabIndex = 0;
            // 
            // tpNuevo
            // 
            this.tpNuevo.Controls.Add(this.tsMenuNuevo);
            this.tpNuevo.Controls.Add(this.gbDatos);
            this.tpNuevo.Location = new System.Drawing.Point(4, 25);
            this.tpNuevo.Name = "tpNuevo";
            this.tpNuevo.Padding = new System.Windows.Forms.Padding(3);
            this.tpNuevo.Size = new System.Drawing.Size(444, 408);
            this.tpNuevo.TabIndex = 0;
            this.tpNuevo.Text = "Nuevo";
            this.tpNuevo.UseVisualStyleBackColor = true;
            // 
            // tsMenuNuevo
            // 
            this.tsMenuNuevo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsGuardar});
            this.tsMenuNuevo.Location = new System.Drawing.Point(3, 3);
            this.tsMenuNuevo.Name = "tsMenuNuevo";
            this.tsMenuNuevo.Size = new System.Drawing.Size(438, 25);
            this.tsMenuNuevo.TabIndex = 0;
            this.tsMenuNuevo.Text = "toolStrip1";
            // 
            // tsGuardar
            // 
            this.tsGuardar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsGuardar.Image = ((System.Drawing.Image)(resources.GetObject("tsGuardar.Image")));
            this.tsGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsGuardar.Name = "tsGuardar";
            this.tsGuardar.Size = new System.Drawing.Size(101, 22);
            this.tsGuardar.Text = "Guardar [F2]";
            this.tsGuardar.Click += new System.EventHandler(this.tsGuardar_Click);
            // 
            // gbDatos
            // 
            this.gbDatos.Controls.Add(this.label3);
            this.gbDatos.Controls.Add(this.cbCiudad);
            this.gbDatos.Controls.Add(this.label2);
            this.gbDatos.Controls.Add(this.txtDireccion);
            this.gbDatos.Controls.Add(this.label1);
            this.gbDatos.Controls.Add(this.txtCelular);
            this.gbDatos.Controls.Add(this.lblTipo);
            this.gbDatos.Controls.Add(this.cbTipo);
            this.gbDatos.Controls.Add(this.lblDocumento);
            this.gbDatos.Controls.Add(this.txtId);
            this.gbDatos.Controls.Add(this.lblNombre);
            this.gbDatos.Controls.Add(this.txtNombre);
            this.gbDatos.Controls.Add(this.lblTelefono);
            this.gbDatos.Controls.Add(this.txtTelefono);
            this.gbDatos.Location = new System.Drawing.Point(45, 48);
            this.gbDatos.Name = "gbDatos";
            this.gbDatos.Size = new System.Drawing.Size(345, 324);
            this.gbDatos.TabIndex = 1;
            this.gbDatos.TabStop = false;
            this.gbDatos.Text = "Datos del Tercero";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 237);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 16);
            this.label3.TabIndex = 13;
            this.label3.Text = "Ciudad";
            // 
            // cbCiudad
            // 
            this.cbCiudad.DisplayMember = "NombreCiudad";
            this.cbCiudad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCiudad.FormattingEnabled = true;
            this.cbCiudad.Location = new System.Drawing.Point(104, 234);
            this.cbCiudad.Name = "cbCiudad";
            this.cbCiudad.Size = new System.Drawing.Size(207, 24);
            this.cbCiudad.TabIndex = 12;
            this.cbCiudad.ValueMember = "IdCiudad";
            this.cbCiudad.Enter += new System.EventHandler(this.cbCiudad_Enter);
            this.cbCiudad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbCiudad_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 276);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "Dirección";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(104, 273);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(207, 22);
            this.txtDireccion.TabIndex = 10;
            this.txtDireccion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDireccion_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 199);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Celular";
            // 
            // txtCelular
            // 
            this.txtCelular.Location = new System.Drawing.Point(104, 196);
            this.txtCelular.Name = "txtCelular";
            this.txtCelular.Size = new System.Drawing.Size(207, 22);
            this.txtCelular.TabIndex = 8;
            this.txtCelular.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCelular_KeyPress);
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(23, 36);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(36, 16);
            this.lblTipo.TabIndex = 7;
            this.lblTipo.Text = "Tipo";
            // 
            // cbTipo
            // 
            this.cbTipo.DisplayMember = "NombreRegimen";
            this.cbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipo.FormattingEnabled = true;
            this.cbTipo.Location = new System.Drawing.Point(104, 33);
            this.cbTipo.Name = "cbTipo";
            this.cbTipo.Size = new System.Drawing.Size(207, 24);
            this.cbTipo.TabIndex = 6;
            this.cbTipo.ValueMember = "IdRegimen";
            // 
            // lblDocumento
            // 
            this.lblDocumento.AutoSize = true;
            this.lblDocumento.Location = new System.Drawing.Point(23, 78);
            this.lblDocumento.Name = "lblDocumento";
            this.lblDocumento.Size = new System.Drawing.Size(68, 16);
            this.lblDocumento.TabIndex = 3;
            this.lblDocumento.Text = "C.C. o NIT";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(104, 75);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(207, 22);
            this.txtId.TabIndex = 0;
            this.txtId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtId_KeyPress);
            this.txtId.Validating += new System.ComponentModel.CancelEventHandler(this.txtId_Validating);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(23, 118);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(64, 16);
            this.lblNombre.TabIndex = 4;
            this.lblNombre.Text = "Nombres";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(104, 115);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(207, 22);
            this.txtNombre.TabIndex = 1;
            this.txtNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombre_KeyPress);
            this.txtNombre.Validating += new System.ComponentModel.CancelEventHandler(this.txtNombre_Validating);
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Location = new System.Drawing.Point(23, 159);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(62, 16);
            this.lblTelefono.TabIndex = 5;
            this.lblTelefono.Text = "Teléfono";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(104, 156);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(207, 22);
            this.txtTelefono.TabIndex = 2;
            this.txtTelefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTelefono_KeyPress);
            this.txtTelefono.Validating += new System.ComponentModel.CancelEventHandler(this.txtTelefono_Validating);
            // 
            // tpConsultas
            // 
            this.tpConsultas.Controls.Add(this.tsMenuConsulta);
            this.tpConsultas.Controls.Add(this.cbCriterio);
            this.tpConsultas.Controls.Add(this.txtConsulta);
            this.tpConsultas.Controls.Add(this.btnBuscar);
            this.tpConsultas.Controls.Add(this.gbConsulta);
            this.tpConsultas.Location = new System.Drawing.Point(4, 25);
            this.tpConsultas.Name = "tpConsultas";
            this.tpConsultas.Padding = new System.Windows.Forms.Padding(3);
            this.tpConsultas.Size = new System.Drawing.Size(444, 408);
            this.tpConsultas.TabIndex = 1;
            this.tpConsultas.Text = "Consultas";
            this.tpConsultas.UseVisualStyleBackColor = true;
            // 
            // tsMenuConsulta
            // 
            this.tsMenuConsulta.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnEditar});
            this.tsMenuConsulta.Location = new System.Drawing.Point(3, 3);
            this.tsMenuConsulta.Name = "tsMenuConsulta";
            this.tsMenuConsulta.Size = new System.Drawing.Size(438, 25);
            this.tsMenuConsulta.TabIndex = 4;
            this.tsMenuConsulta.Text = "Menu";
            // 
            // btnEditar
            // 
            this.btnEditar.Image = ((System.Drawing.Image)(resources.GetObject("btnEditar.Image")));
            this.btnEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(57, 22);
            this.btnEditar.Text = "Editar";
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // cbCriterio
            // 
            this.cbCriterio.DisplayMember = "Nombre";
            this.cbCriterio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCriterio.FormattingEnabled = true;
            this.cbCriterio.Location = new System.Drawing.Point(394, 45);
            this.cbCriterio.Name = "cbCriterio";
            this.cbCriterio.Size = new System.Drawing.Size(10, 24);
            this.cbCriterio.TabIndex = 0;
            this.cbCriterio.ValueMember = "Id";
            this.cbCriterio.Visible = false;
            // 
            // txtConsulta
            // 
            this.txtConsulta.Location = new System.Drawing.Point(13, 45);
            this.txtConsulta.Name = "txtConsulta";
            this.txtConsulta.Size = new System.Drawing.Size(375, 22);
            this.txtConsulta.TabIndex = 1;
            this.txtConsulta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtConsulta_KeyPress);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(410, 44);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(24, 24);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // gbConsulta
            // 
            this.gbConsulta.Controls.Add(this.dgBeneficiarios);
            this.gbConsulta.Location = new System.Drawing.Point(10, 75);
            this.gbConsulta.Name = "gbConsulta";
            this.gbConsulta.Size = new System.Drawing.Size(424, 325);
            this.gbConsulta.TabIndex = 3;
            this.gbConsulta.TabStop = false;
            this.gbConsulta.Text = "Resultado de la Consulta";
            // 
            // dgBeneficiarios
            // 
            this.dgBeneficiarios.AllowUserToAddRows = false;
            this.dgBeneficiarios.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgBeneficiarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgBeneficiarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.IdRegimen,
            this.Nit,
            this.Nombre});
            this.dgBeneficiarios.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgBeneficiarios.Location = new System.Drawing.Point(6, 21);
            this.dgBeneficiarios.Name = "dgBeneficiarios";
            this.dgBeneficiarios.RowHeadersVisible = false;
            this.dgBeneficiarios.Size = new System.Drawing.Size(406, 298);
            this.dgBeneficiarios.TabIndex = 0;
            this.dgBeneficiarios.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgBeneficiarios_CellDoubleClick);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // IdRegimen
            // 
            this.IdRegimen.DataPropertyName = "idregimen";
            this.IdRegimen.HeaderText = "IdRegimen";
            this.IdRegimen.Name = "IdRegimen";
            this.IdRegimen.Visible = false;
            // 
            // Nit
            // 
            this.Nit.DataPropertyName = "nit";
            this.Nit.HeaderText = "Nit o C.C.";
            this.Nit.Name = "Nit";
            this.Nit.Width = 150;
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "nombre";
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.Width = 250;
            // 
            // tsMenu
            // 
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSalir});
            this.tsMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(451, 25);
            this.tsMenu.TabIndex = 1;
            this.tsMenu.Text = "toolStrip1";
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(87, 22);
            this.btnSalir.Text = "Salir [ESC]";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // FrmBeneficio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(451, 464);
            this.Controls.Add(this.tsMenu);
            this.Controls.Add(this.tcBeneficio);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmBeneficio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Datos de Tercero";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmBeneficio_FormClosing);
            this.Load += new System.EventHandler(this.FrmBeneficio_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmBeneficio_KeyDown);
            this.tcBeneficio.ResumeLayout(false);
            this.tpNuevo.ResumeLayout(false);
            this.tpNuevo.PerformLayout();
            this.tsMenuNuevo.ResumeLayout(false);
            this.tsMenuNuevo.PerformLayout();
            this.gbDatos.ResumeLayout(false);
            this.gbDatos.PerformLayout();
            this.tpConsultas.ResumeLayout(false);
            this.tpConsultas.PerformLayout();
            this.tsMenuConsulta.ResumeLayout(false);
            this.tsMenuConsulta.PerformLayout();
            this.gbConsulta.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgBeneficiarios)).EndInit();
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabPage tpNuevo;
        private System.Windows.Forms.TabPage tpConsultas;
        private System.Windows.Forms.GroupBox gbConsulta;
        private System.Windows.Forms.DataGridView dgBeneficiarios;
        private System.Windows.Forms.GroupBox gbDatos;
        private System.Windows.Forms.Label lblDocumento;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.ToolStrip tsMenuNuevo;
        private System.Windows.Forms.ToolStripButton tsGuardar;
        private System.Windows.Forms.ComboBox cbCriterio;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.ToolStripButton btnSalir;
        public System.Windows.Forms.TabControl tcBeneficio;
        public System.Windows.Forms.TextBox txtId;
        public System.Windows.Forms.TextBox txtConsulta;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.ComboBox cbTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdRegimen;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.ToolStrip tsMenuConsulta;
        private System.Windows.Forms.ToolStripButton btnEditar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCelular;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbCiudad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDireccion;
    }
}