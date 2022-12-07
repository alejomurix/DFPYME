namespace Aplicacion.Administracion.Puc
{
    partial class FrmPuc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPuc));
            this.gbNuevo = new System.Windows.Forms.GroupBox();
            this.tcCuentasPuc = new System.Windows.Forms.TabControl();
            this.tpClase = new System.Windows.Forms.TabPage();
            this.txtNombreClase = new System.Windows.Forms.TextBox();
            this.lblNombreClase = new System.Windows.Forms.Label();
            this.txtNumeroClase = new System.Windows.Forms.TextBox();
            this.lblNumeroClase = new System.Windows.Forms.Label();
            this.tsMenuClase = new System.Windows.Forms.ToolStrip();
            this.btnGuardarClase = new System.Windows.Forms.ToolStripButton();
            this.tpGrupo = new System.Windows.Forms.TabPage();
            this.txtNameClase = new System.Windows.Forms.TextBox();
            this.lblSeleccioneClase = new System.Windows.Forms.Label();
            this.cbClases = new System.Windows.Forms.ComboBox();
            this.txtNombreGrupo = new System.Windows.Forms.TextBox();
            this.lblNombreGrupo = new System.Windows.Forms.Label();
            this.txtNumeroGrupo = new System.Windows.Forms.TextBox();
            this.lblNumeroGrupo = new System.Windows.Forms.Label();
            this.tsMenuGrupo = new System.Windows.Forms.ToolStrip();
            this.btnGuardarGrupo = new System.Windows.Forms.ToolStripButton();
            this.tpCuenta = new System.Windows.Forms.TabPage();
            this.txtNameGrupo = new System.Windows.Forms.TextBox();
            this.txtNameClaseC = new System.Windows.Forms.TextBox();
            this.lblSeleccioneGrupo = new System.Windows.Forms.Label();
            this.cbGrupos = new System.Windows.Forms.ComboBox();
            this.lblSeleccionesClaseCta = new System.Windows.Forms.Label();
            this.cbClasesCta = new System.Windows.Forms.ComboBox();
            this.txtNombreCuenta = new System.Windows.Forms.TextBox();
            this.lblNombreCuenta = new System.Windows.Forms.Label();
            this.txtNumeroCuenta = new System.Windows.Forms.TextBox();
            this.lblNumeroCuenta = new System.Windows.Forms.Label();
            this.tsMenuCuenta = new System.Windows.Forms.ToolStrip();
            this.btnGuardarCuenta = new System.Windows.Forms.ToolStripButton();
            this.tpSubCuenta = new System.Windows.Forms.TabPage();
            this.txtNameCuentaS = new System.Windows.Forms.TextBox();
            this.txtNameGrupoS = new System.Windows.Forms.TextBox();
            this.txtNameClaseS = new System.Windows.Forms.TextBox();
            this.lblCuentaScta = new System.Windows.Forms.Label();
            this.cbCuentas = new System.Windows.Forms.ComboBox();
            this.lblSeleccioneGrupoScta = new System.Windows.Forms.Label();
            this.cbGruposScta = new System.Windows.Forms.ComboBox();
            this.lblSeleccioneClaseScta = new System.Windows.Forms.Label();
            this.cbClasesScta = new System.Windows.Forms.ComboBox();
            this.txtNombreScta = new System.Windows.Forms.TextBox();
            this.lblNombreScta = new System.Windows.Forms.Label();
            this.txtNumeroScta = new System.Windows.Forms.TextBox();
            this.lblNumeroScta = new System.Windows.Forms.Label();
            this.tsMenuSubCuenta = new System.Windows.Forms.ToolStrip();
            this.btnGuardar = new System.Windows.Forms.ToolStripButton();
            this.tsMenuConsulta = new System.Windows.Forms.ToolStrip();
            this.tsBtnSalirConsulta = new System.Windows.Forms.ToolStripButton();
            this.tpConsultas = new System.Windows.Forms.TabPage();
            this.gbConsultas = new System.Windows.Forms.GroupBox();
            this.dgvCuentas = new System.Windows.Forms.DataGridView();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbConsultaClase = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtClaseConsulta = new System.Windows.Forms.TextBox();
            this.tpNuevaCuenta = new System.Windows.Forms.TabPage();
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.tsSalir = new System.Windows.Forms.ToolStripButton();
            this.tcPuc = new System.Windows.Forms.TabControl();
            this.gbNuevo.SuspendLayout();
            this.tcCuentasPuc.SuspendLayout();
            this.tpClase.SuspendLayout();
            this.tsMenuClase.SuspendLayout();
            this.tpGrupo.SuspendLayout();
            this.tsMenuGrupo.SuspendLayout();
            this.tpCuenta.SuspendLayout();
            this.tsMenuCuenta.SuspendLayout();
            this.tpSubCuenta.SuspendLayout();
            this.tsMenuSubCuenta.SuspendLayout();
            this.tsMenuConsulta.SuspendLayout();
            this.tpConsultas.SuspendLayout();
            this.gbConsultas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuentas)).BeginInit();
            this.tpNuevaCuenta.SuspendLayout();
            this.tsMenu.SuspendLayout();
            this.tcPuc.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbNuevo
            // 
            this.gbNuevo.Controls.Add(this.tcCuentasPuc);
            this.gbNuevo.Controls.Add(this.tcPuc);
            this.gbNuevo.Location = new System.Drawing.Point(10, 34);
            this.gbNuevo.Name = "gbNuevo";
            this.gbNuevo.Size = new System.Drawing.Size(543, 291);
            this.gbNuevo.TabIndex = 0;
            this.gbNuevo.TabStop = false;
            // 
            // tcCuentasPuc
            // 
            this.tcCuentasPuc.Controls.Add(this.tpClase);
            this.tcCuentasPuc.Controls.Add(this.tpGrupo);
            this.tcCuentasPuc.Controls.Add(this.tpCuenta);
            this.tcCuentasPuc.Controls.Add(this.tpSubCuenta);
            this.tcCuentasPuc.Location = new System.Drawing.Point(22, 26);
            this.tcCuentasPuc.Name = "tcCuentasPuc";
            this.tcCuentasPuc.SelectedIndex = 0;
            this.tcCuentasPuc.Size = new System.Drawing.Size(497, 244);
            this.tcCuentasPuc.TabIndex = 0;
            // 
            // tpClase
            // 
            this.tpClase.Controls.Add(this.txtNombreClase);
            this.tpClase.Controls.Add(this.lblNombreClase);
            this.tpClase.Controls.Add(this.txtNumeroClase);
            this.tpClase.Controls.Add(this.lblNumeroClase);
            this.tpClase.Controls.Add(this.tsMenuClase);
            this.tpClase.Location = new System.Drawing.Point(4, 25);
            this.tpClase.Name = "tpClase";
            this.tpClase.Padding = new System.Windows.Forms.Padding(3);
            this.tpClase.Size = new System.Drawing.Size(489, 215);
            this.tpClase.TabIndex = 0;
            this.tpClase.Text = "Clase";
            this.tpClase.UseVisualStyleBackColor = true;
            // 
            // txtNombreClase
            // 
            this.txtNombreClase.Location = new System.Drawing.Point(91, 70);
            this.txtNombreClase.Name = "txtNombreClase";
            this.txtNombreClase.Size = new System.Drawing.Size(331, 22);
            this.txtNombreClase.TabIndex = 4;
            this.txtNombreClase.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombreClase_KeyPress);
            // 
            // lblNombreClase
            // 
            this.lblNombreClase.AutoSize = true;
            this.lblNombreClase.Location = new System.Drawing.Point(88, 45);
            this.lblNombreClase.Name = "lblNombreClase";
            this.lblNombreClase.Size = new System.Drawing.Size(57, 16);
            this.lblNombreClase.TabIndex = 3;
            this.lblNombreClase.Text = "Nombre";
            // 
            // txtNumeroClase
            // 
            this.txtNumeroClase.Location = new System.Drawing.Point(19, 70);
            this.txtNumeroClase.Name = "txtNumeroClase";
            this.txtNumeroClase.Size = new System.Drawing.Size(53, 22);
            this.txtNumeroClase.TabIndex = 2;
            this.txtNumeroClase.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeroClase_KeyPress);
            this.txtNumeroClase.Validating += new System.ComponentModel.CancelEventHandler(this.txtNumeroClase_Validating);
            // 
            // lblNumeroClase
            // 
            this.lblNumeroClase.AutoSize = true;
            this.lblNumeroClase.Location = new System.Drawing.Point(16, 45);
            this.lblNumeroClase.Name = "lblNumeroClase";
            this.lblNumeroClase.Size = new System.Drawing.Size(56, 16);
            this.lblNumeroClase.TabIndex = 1;
            this.lblNumeroClase.Text = "Número";
            // 
            // tsMenuClase
            // 
            this.tsMenuClase.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnGuardarClase});
            this.tsMenuClase.Location = new System.Drawing.Point(3, 3);
            this.tsMenuClase.Name = "tsMenuClase";
            this.tsMenuClase.Size = new System.Drawing.Size(483, 25);
            this.tsMenuClase.TabIndex = 0;
            this.tsMenuClase.Text = "toolStrip1";
            // 
            // btnGuardarClase
            // 
            this.btnGuardarClase.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.btnGuardarClase.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardarClase.Image")));
            this.btnGuardarClase.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGuardarClase.Name = "btnGuardarClase";
            this.btnGuardarClase.Size = new System.Drawing.Size(74, 22);
            this.btnGuardarClase.Text = "Guardar";
            this.btnGuardarClase.Click += new System.EventHandler(this.btnGuardarClase_Click);
            // 
            // tpGrupo
            // 
            this.tpGrupo.Controls.Add(this.txtNameClase);
            this.tpGrupo.Controls.Add(this.lblSeleccioneClase);
            this.tpGrupo.Controls.Add(this.cbClases);
            this.tpGrupo.Controls.Add(this.txtNombreGrupo);
            this.tpGrupo.Controls.Add(this.lblNombreGrupo);
            this.tpGrupo.Controls.Add(this.txtNumeroGrupo);
            this.tpGrupo.Controls.Add(this.lblNumeroGrupo);
            this.tpGrupo.Controls.Add(this.tsMenuGrupo);
            this.tpGrupo.Location = new System.Drawing.Point(4, 25);
            this.tpGrupo.Name = "tpGrupo";
            this.tpGrupo.Padding = new System.Windows.Forms.Padding(3);
            this.tpGrupo.Size = new System.Drawing.Size(489, 215);
            this.tpGrupo.TabIndex = 1;
            this.tpGrupo.Text = "Grupo";
            this.tpGrupo.UseVisualStyleBackColor = true;
            // 
            // txtNameClase
            // 
            this.txtNameClase.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtNameClase.Location = new System.Drawing.Point(141, 45);
            this.txtNameClase.Name = "txtNameClase";
            this.txtNameClase.ReadOnly = true;
            this.txtNameClase.Size = new System.Drawing.Size(328, 22);
            this.txtNameClase.TabIndex = 12;
            // 
            // lblSeleccioneClase
            // 
            this.lblSeleccioneClase.AutoSize = true;
            this.lblSeleccioneClase.Location = new System.Drawing.Point(17, 47);
            this.lblSeleccioneClase.Name = "lblSeleccioneClase";
            this.lblSeleccioneClase.Size = new System.Drawing.Size(43, 16);
            this.lblSeleccioneClase.TabIndex = 11;
            this.lblSeleccioneClase.Text = "Clase";
            // 
            // cbClases
            // 
            this.cbClases.DisplayMember = "numero";
            this.cbClases.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbClases.FormattingEnabled = true;
            this.cbClases.Location = new System.Drawing.Point(92, 43);
            this.cbClases.Name = "cbClases";
            this.cbClases.Size = new System.Drawing.Size(43, 24);
            this.cbClases.TabIndex = 10;
            this.cbClases.ValueMember = "id";
            this.cbClases.SelectionChangeCommitted += new System.EventHandler(this.cbClases_SelectionChangeCommitted);
            // 
            // txtNombreGrupo
            // 
            this.txtNombreGrupo.Location = new System.Drawing.Point(92, 100);
            this.txtNombreGrupo.Name = "txtNombreGrupo";
            this.txtNombreGrupo.Size = new System.Drawing.Size(377, 22);
            this.txtNombreGrupo.TabIndex = 9;
            this.txtNombreGrupo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombreGrupo_KeyPress);
            // 
            // lblNombreGrupo
            // 
            this.lblNombreGrupo.AutoSize = true;
            this.lblNombreGrupo.Location = new System.Drawing.Point(89, 75);
            this.lblNombreGrupo.Name = "lblNombreGrupo";
            this.lblNombreGrupo.Size = new System.Drawing.Size(57, 16);
            this.lblNombreGrupo.TabIndex = 8;
            this.lblNombreGrupo.Text = "Nombre";
            // 
            // txtNumeroGrupo
            // 
            this.txtNumeroGrupo.Location = new System.Drawing.Point(20, 100);
            this.txtNumeroGrupo.Name = "txtNumeroGrupo";
            this.txtNumeroGrupo.Size = new System.Drawing.Size(53, 22);
            this.txtNumeroGrupo.TabIndex = 7;
            this.txtNumeroGrupo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeroGrupo_KeyPress);
            this.txtNumeroGrupo.Validating += new System.ComponentModel.CancelEventHandler(this.txtNumeroGrupo_Validating);
            // 
            // lblNumeroGrupo
            // 
            this.lblNumeroGrupo.AutoSize = true;
            this.lblNumeroGrupo.Location = new System.Drawing.Point(17, 75);
            this.lblNumeroGrupo.Name = "lblNumeroGrupo";
            this.lblNumeroGrupo.Size = new System.Drawing.Size(56, 16);
            this.lblNumeroGrupo.TabIndex = 6;
            this.lblNumeroGrupo.Text = "Número";
            // 
            // tsMenuGrupo
            // 
            this.tsMenuGrupo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnGuardarGrupo});
            this.tsMenuGrupo.Location = new System.Drawing.Point(3, 3);
            this.tsMenuGrupo.Name = "tsMenuGrupo";
            this.tsMenuGrupo.Size = new System.Drawing.Size(483, 25);
            this.tsMenuGrupo.TabIndex = 5;
            this.tsMenuGrupo.Text = "toolStrip2";
            // 
            // btnGuardarGrupo
            // 
            this.btnGuardarGrupo.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.btnGuardarGrupo.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardarGrupo.Image")));
            this.btnGuardarGrupo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGuardarGrupo.Name = "btnGuardarGrupo";
            this.btnGuardarGrupo.Size = new System.Drawing.Size(74, 22);
            this.btnGuardarGrupo.Text = "Guardar";
            this.btnGuardarGrupo.Click += new System.EventHandler(this.btnGuardarGrupo_Click);
            // 
            // tpCuenta
            // 
            this.tpCuenta.Controls.Add(this.txtNameGrupo);
            this.tpCuenta.Controls.Add(this.txtNameClaseC);
            this.tpCuenta.Controls.Add(this.lblSeleccioneGrupo);
            this.tpCuenta.Controls.Add(this.cbGrupos);
            this.tpCuenta.Controls.Add(this.lblSeleccionesClaseCta);
            this.tpCuenta.Controls.Add(this.cbClasesCta);
            this.tpCuenta.Controls.Add(this.txtNombreCuenta);
            this.tpCuenta.Controls.Add(this.lblNombreCuenta);
            this.tpCuenta.Controls.Add(this.txtNumeroCuenta);
            this.tpCuenta.Controls.Add(this.lblNumeroCuenta);
            this.tpCuenta.Controls.Add(this.tsMenuCuenta);
            this.tpCuenta.Location = new System.Drawing.Point(4, 25);
            this.tpCuenta.Name = "tpCuenta";
            this.tpCuenta.Padding = new System.Windows.Forms.Padding(3);
            this.tpCuenta.Size = new System.Drawing.Size(489, 215);
            this.tpCuenta.TabIndex = 2;
            this.tpCuenta.Text = "Cuenta";
            this.tpCuenta.UseVisualStyleBackColor = true;
            // 
            // txtNameGrupo
            // 
            this.txtNameGrupo.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtNameGrupo.Location = new System.Drawing.Point(123, 75);
            this.txtNameGrupo.Name = "txtNameGrupo";
            this.txtNameGrupo.ReadOnly = true;
            this.txtNameGrupo.Size = new System.Drawing.Size(348, 22);
            this.txtNameGrupo.TabIndex = 17;
            // 
            // txtNameClaseC
            // 
            this.txtNameClaseC.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtNameClaseC.Location = new System.Drawing.Point(123, 38);
            this.txtNameClaseC.Name = "txtNameClaseC";
            this.txtNameClaseC.ReadOnly = true;
            this.txtNameClaseC.Size = new System.Drawing.Size(348, 22);
            this.txtNameClaseC.TabIndex = 16;
            // 
            // lblSeleccioneGrupo
            // 
            this.lblSeleccioneGrupo.AutoSize = true;
            this.lblSeleccioneGrupo.Location = new System.Drawing.Point(19, 78);
            this.lblSeleccioneGrupo.Name = "lblSeleccioneGrupo";
            this.lblSeleccioneGrupo.Size = new System.Drawing.Size(45, 16);
            this.lblSeleccioneGrupo.TabIndex = 15;
            this.lblSeleccioneGrupo.Text = "Grupo";
            // 
            // cbGrupos
            // 
            this.cbGrupos.DisplayMember = "numero";
            this.cbGrupos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGrupos.FormattingEnabled = true;
            this.cbGrupos.Location = new System.Drawing.Point(75, 74);
            this.cbGrupos.Name = "cbGrupos";
            this.cbGrupos.Size = new System.Drawing.Size(42, 24);
            this.cbGrupos.TabIndex = 14;
            this.cbGrupos.ValueMember = "id";
            this.cbGrupos.SelectionChangeCommitted += new System.EventHandler(this.cbGrupos_SelectionChangeCommitted);
            // 
            // lblSeleccionesClaseCta
            // 
            this.lblSeleccionesClaseCta.AutoSize = true;
            this.lblSeleccionesClaseCta.Location = new System.Drawing.Point(19, 40);
            this.lblSeleccionesClaseCta.Name = "lblSeleccionesClaseCta";
            this.lblSeleccionesClaseCta.Size = new System.Drawing.Size(43, 16);
            this.lblSeleccionesClaseCta.TabIndex = 13;
            this.lblSeleccionesClaseCta.Text = "Clase";
            // 
            // cbClasesCta
            // 
            this.cbClasesCta.DisplayMember = "numero";
            this.cbClasesCta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbClasesCta.FormattingEnabled = true;
            this.cbClasesCta.Location = new System.Drawing.Point(75, 36);
            this.cbClasesCta.Name = "cbClasesCta";
            this.cbClasesCta.Size = new System.Drawing.Size(42, 24);
            this.cbClasesCta.TabIndex = 12;
            this.cbClasesCta.ValueMember = "id";
            this.cbClasesCta.SelectionChangeCommitted += new System.EventHandler(this.cbClasesCta_SelectionChangeCommitted);
            this.cbClasesCta.SelectedValueChanged += new System.EventHandler(this.cbClasesCta_SelectedValueChanged);
            // 
            // txtNombreCuenta
            // 
            this.txtNombreCuenta.Location = new System.Drawing.Point(94, 156);
            this.txtNombreCuenta.Name = "txtNombreCuenta";
            this.txtNombreCuenta.Size = new System.Drawing.Size(377, 22);
            this.txtNombreCuenta.TabIndex = 9;
            this.txtNombreCuenta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombreCuenta_KeyPress);
            // 
            // lblNombreCuenta
            // 
            this.lblNombreCuenta.AutoSize = true;
            this.lblNombreCuenta.Location = new System.Drawing.Point(91, 131);
            this.lblNombreCuenta.Name = "lblNombreCuenta";
            this.lblNombreCuenta.Size = new System.Drawing.Size(57, 16);
            this.lblNombreCuenta.TabIndex = 8;
            this.lblNombreCuenta.Text = "Nombre";
            // 
            // txtNumeroCuenta
            // 
            this.txtNumeroCuenta.Location = new System.Drawing.Point(22, 156);
            this.txtNumeroCuenta.Name = "txtNumeroCuenta";
            this.txtNumeroCuenta.Size = new System.Drawing.Size(53, 22);
            this.txtNumeroCuenta.TabIndex = 7;
            this.txtNumeroCuenta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeroCuenta_KeyPress);
            this.txtNumeroCuenta.Validating += new System.ComponentModel.CancelEventHandler(this.txtNumeroCuenta_Validating);
            // 
            // lblNumeroCuenta
            // 
            this.lblNumeroCuenta.AutoSize = true;
            this.lblNumeroCuenta.Location = new System.Drawing.Point(19, 131);
            this.lblNumeroCuenta.Name = "lblNumeroCuenta";
            this.lblNumeroCuenta.Size = new System.Drawing.Size(56, 16);
            this.lblNumeroCuenta.TabIndex = 6;
            this.lblNumeroCuenta.Text = "Número";
            // 
            // tsMenuCuenta
            // 
            this.tsMenuCuenta.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnGuardarCuenta});
            this.tsMenuCuenta.Location = new System.Drawing.Point(3, 3);
            this.tsMenuCuenta.Name = "tsMenuCuenta";
            this.tsMenuCuenta.Size = new System.Drawing.Size(483, 25);
            this.tsMenuCuenta.TabIndex = 5;
            this.tsMenuCuenta.Text = "toolStrip3";
            // 
            // btnGuardarCuenta
            // 
            this.btnGuardarCuenta.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.btnGuardarCuenta.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardarCuenta.Image")));
            this.btnGuardarCuenta.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGuardarCuenta.Name = "btnGuardarCuenta";
            this.btnGuardarCuenta.Size = new System.Drawing.Size(74, 22);
            this.btnGuardarCuenta.Text = "Guardar";
            this.btnGuardarCuenta.Click += new System.EventHandler(this.btnGuardarCuenta_Click);
            // 
            // tpSubCuenta
            // 
            this.tpSubCuenta.Controls.Add(this.txtNameCuentaS);
            this.tpSubCuenta.Controls.Add(this.txtNameGrupoS);
            this.tpSubCuenta.Controls.Add(this.txtNameClaseS);
            this.tpSubCuenta.Controls.Add(this.lblCuentaScta);
            this.tpSubCuenta.Controls.Add(this.cbCuentas);
            this.tpSubCuenta.Controls.Add(this.lblSeleccioneGrupoScta);
            this.tpSubCuenta.Controls.Add(this.cbGruposScta);
            this.tpSubCuenta.Controls.Add(this.lblSeleccioneClaseScta);
            this.tpSubCuenta.Controls.Add(this.cbClasesScta);
            this.tpSubCuenta.Controls.Add(this.txtNombreScta);
            this.tpSubCuenta.Controls.Add(this.lblNombreScta);
            this.tpSubCuenta.Controls.Add(this.txtNumeroScta);
            this.tpSubCuenta.Controls.Add(this.lblNumeroScta);
            this.tpSubCuenta.Controls.Add(this.tsMenuSubCuenta);
            this.tpSubCuenta.Location = new System.Drawing.Point(4, 25);
            this.tpSubCuenta.Name = "tpSubCuenta";
            this.tpSubCuenta.Padding = new System.Windows.Forms.Padding(3);
            this.tpSubCuenta.Size = new System.Drawing.Size(489, 215);
            this.tpSubCuenta.TabIndex = 3;
            this.tpSubCuenta.Text = "Sub Cuenta";
            this.tpSubCuenta.UseVisualStyleBackColor = true;
            // 
            // txtNameCuentaS
            // 
            this.txtNameCuentaS.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtNameCuentaS.Location = new System.Drawing.Point(122, 106);
            this.txtNameCuentaS.Name = "txtNameCuentaS";
            this.txtNameCuentaS.ReadOnly = true;
            this.txtNameCuentaS.Size = new System.Drawing.Size(348, 22);
            this.txtNameCuentaS.TabIndex = 24;
            // 
            // txtNameGrupoS
            // 
            this.txtNameGrupoS.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtNameGrupoS.Location = new System.Drawing.Point(122, 72);
            this.txtNameGrupoS.Name = "txtNameGrupoS";
            this.txtNameGrupoS.ReadOnly = true;
            this.txtNameGrupoS.Size = new System.Drawing.Size(348, 22);
            this.txtNameGrupoS.TabIndex = 23;
            // 
            // txtNameClaseS
            // 
            this.txtNameClaseS.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtNameClaseS.Location = new System.Drawing.Point(122, 37);
            this.txtNameClaseS.Name = "txtNameClaseS";
            this.txtNameClaseS.ReadOnly = true;
            this.txtNameClaseS.Size = new System.Drawing.Size(348, 22);
            this.txtNameClaseS.TabIndex = 22;
            // 
            // lblCuentaScta
            // 
            this.lblCuentaScta.AutoSize = true;
            this.lblCuentaScta.Location = new System.Drawing.Point(19, 108);
            this.lblCuentaScta.Name = "lblCuentaScta";
            this.lblCuentaScta.Size = new System.Drawing.Size(50, 16);
            this.lblCuentaScta.TabIndex = 21;
            this.lblCuentaScta.Text = "Cuenta";
            // 
            // cbCuentas
            // 
            this.cbCuentas.DisplayMember = "numero";
            this.cbCuentas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCuentas.FormattingEnabled = true;
            this.cbCuentas.Location = new System.Drawing.Point(75, 104);
            this.cbCuentas.Name = "cbCuentas";
            this.cbCuentas.Size = new System.Drawing.Size(41, 24);
            this.cbCuentas.TabIndex = 20;
            this.cbCuentas.ValueMember = "id";
            this.cbCuentas.SelectionChangeCommitted += new System.EventHandler(this.cbCuentas_SelectionChangeCommitted);
            // 
            // lblSeleccioneGrupoScta
            // 
            this.lblSeleccioneGrupoScta.AutoSize = true;
            this.lblSeleccioneGrupoScta.Location = new System.Drawing.Point(19, 74);
            this.lblSeleccioneGrupoScta.Name = "lblSeleccioneGrupoScta";
            this.lblSeleccioneGrupoScta.Size = new System.Drawing.Size(45, 16);
            this.lblSeleccioneGrupoScta.TabIndex = 19;
            this.lblSeleccioneGrupoScta.Text = "Grupo";
            // 
            // cbGruposScta
            // 
            this.cbGruposScta.DisplayMember = "numero";
            this.cbGruposScta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGruposScta.FormattingEnabled = true;
            this.cbGruposScta.Location = new System.Drawing.Point(75, 71);
            this.cbGruposScta.Name = "cbGruposScta";
            this.cbGruposScta.Size = new System.Drawing.Size(41, 24);
            this.cbGruposScta.TabIndex = 18;
            this.cbGruposScta.ValueMember = "id";
            this.cbGruposScta.SelectionChangeCommitted += new System.EventHandler(this.cbGruposScta_SelectionChangeCommitted);
            // 
            // lblSeleccioneClaseScta
            // 
            this.lblSeleccioneClaseScta.AutoSize = true;
            this.lblSeleccioneClaseScta.Location = new System.Drawing.Point(19, 39);
            this.lblSeleccioneClaseScta.Name = "lblSeleccioneClaseScta";
            this.lblSeleccioneClaseScta.Size = new System.Drawing.Size(43, 16);
            this.lblSeleccioneClaseScta.TabIndex = 17;
            this.lblSeleccioneClaseScta.Text = "Clase";
            // 
            // cbClasesScta
            // 
            this.cbClasesScta.DisplayMember = "numero";
            this.cbClasesScta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbClasesScta.FormattingEnabled = true;
            this.cbClasesScta.Location = new System.Drawing.Point(75, 36);
            this.cbClasesScta.Name = "cbClasesScta";
            this.cbClasesScta.Size = new System.Drawing.Size(41, 24);
            this.cbClasesScta.TabIndex = 16;
            this.cbClasesScta.ValueMember = "id";
            this.cbClasesScta.SelectionChangeCommitted += new System.EventHandler(this.cbClasesScta_SelectionChangeCommitted);
            // 
            // txtNombreScta
            // 
            this.txtNombreScta.Location = new System.Drawing.Point(96, 172);
            this.txtNombreScta.Name = "txtNombreScta";
            this.txtNombreScta.Size = new System.Drawing.Size(374, 22);
            this.txtNombreScta.TabIndex = 9;
            this.txtNombreScta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombreScta_KeyPress);
            // 
            // lblNombreScta
            // 
            this.lblNombreScta.AutoSize = true;
            this.lblNombreScta.Location = new System.Drawing.Point(93, 147);
            this.lblNombreScta.Name = "lblNombreScta";
            this.lblNombreScta.Size = new System.Drawing.Size(57, 16);
            this.lblNombreScta.TabIndex = 8;
            this.lblNombreScta.Text = "Nombre";
            // 
            // txtNumeroScta
            // 
            this.txtNumeroScta.Location = new System.Drawing.Point(24, 172);
            this.txtNumeroScta.Name = "txtNumeroScta";
            this.txtNumeroScta.Size = new System.Drawing.Size(53, 22);
            this.txtNumeroScta.TabIndex = 7;
            this.txtNumeroScta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeroScta_KeyPress);
            this.txtNumeroScta.Validating += new System.ComponentModel.CancelEventHandler(this.txtNumeroScta_Validating);
            // 
            // lblNumeroScta
            // 
            this.lblNumeroScta.AutoSize = true;
            this.lblNumeroScta.Location = new System.Drawing.Point(21, 147);
            this.lblNumeroScta.Name = "lblNumeroScta";
            this.lblNumeroScta.Size = new System.Drawing.Size(56, 16);
            this.lblNumeroScta.TabIndex = 6;
            this.lblNumeroScta.Text = "Número";
            // 
            // tsMenuSubCuenta
            // 
            this.tsMenuSubCuenta.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnGuardar});
            this.tsMenuSubCuenta.Location = new System.Drawing.Point(3, 3);
            this.tsMenuSubCuenta.Name = "tsMenuSubCuenta";
            this.tsMenuSubCuenta.Size = new System.Drawing.Size(483, 25);
            this.tsMenuSubCuenta.TabIndex = 5;
            this.tsMenuSubCuenta.Text = "toolStrip4";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(74, 22);
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // tsMenuConsulta
            // 
            this.tsMenuConsulta.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnSalirConsulta});
            this.tsMenuConsulta.Location = new System.Drawing.Point(0, 0);
            this.tsMenuConsulta.Name = "tsMenuConsulta";
            this.tsMenuConsulta.Size = new System.Drawing.Size(567, 25);
            this.tsMenuConsulta.TabIndex = 15;
            this.tsMenuConsulta.Text = "toolStrip1";
            // 
            // tsBtnSalirConsulta
            // 
            this.tsBtnSalirConsulta.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.tsBtnSalirConsulta.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnSalirConsulta.Image")));
            this.tsBtnSalirConsulta.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnSalirConsulta.Name = "tsBtnSalirConsulta";
            this.tsBtnSalirConsulta.Size = new System.Drawing.Size(91, 22);
            this.tsBtnSalirConsulta.Text = "Salir [ESC]";
            this.tsBtnSalirConsulta.Click += new System.EventHandler(this.tsSalir_Click);
            // 
            // tpConsultas
            // 
            this.tpConsultas.Controls.Add(this.txtClaseConsulta);
            this.tpConsultas.Controls.Add(this.label1);
            this.tpConsultas.Controls.Add(this.cbConsultaClase);
            this.tpConsultas.Controls.Add(this.gbConsultas);
            this.tpConsultas.Location = new System.Drawing.Point(4, 25);
            this.tpConsultas.Name = "tpConsultas";
            this.tpConsultas.Padding = new System.Windows.Forms.Padding(3);
            this.tpConsultas.Size = new System.Drawing.Size(555, 299);
            this.tpConsultas.TabIndex = 1;
            this.tpConsultas.Text = "Consultas";
            this.tpConsultas.UseVisualStyleBackColor = true;
            // 
            // gbConsultas
            // 
            this.gbConsultas.Controls.Add(this.dgvCuentas);
            this.gbConsultas.Location = new System.Drawing.Point(7, 84);
            this.gbConsultas.Name = "gbConsultas";
            this.gbConsultas.Size = new System.Drawing.Size(540, 302);
            this.gbConsultas.TabIndex = 0;
            this.gbConsultas.TabStop = false;
            // 
            // dgvCuentas
            // 
            this.dgvCuentas.AllowUserToAddRows = false;
            this.dgvCuentas.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvCuentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCuentas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Numero,
            this.Nombre});
            this.dgvCuentas.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvCuentas.Location = new System.Drawing.Point(6, 12);
            this.dgvCuentas.Name = "dgvCuentas";
            this.dgvCuentas.RowHeadersVisible = false;
            this.dgvCuentas.Size = new System.Drawing.Size(528, 282);
            this.dgvCuentas.TabIndex = 0;
            this.dgvCuentas.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCuentas_CellContentDoubleClick);
            this.dgvCuentas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCuentas_CellDoubleClick);
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "nombre";
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.Width = 400;
            // 
            // Numero
            // 
            this.Numero.DataPropertyName = "numero";
            this.Numero.HeaderText = "Número";
            this.Numero.Name = "Numero";
            // 
            // Id
            // 
            this.Id.DataPropertyName = "id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // cbConsultaClase
            // 
            this.cbConsultaClase.DisplayMember = "numero";
            this.cbConsultaClase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbConsultaClase.FormattingEnabled = true;
            this.cbConsultaClase.Location = new System.Drawing.Point(60, 57);
            this.cbConsultaClase.Name = "cbConsultaClase";
            this.cbConsultaClase.Size = new System.Drawing.Size(88, 24);
            this.cbConsultaClase.TabIndex = 12;
            this.cbConsultaClase.ValueMember = "id";
            this.cbConsultaClase.SelectionChangeCommitted += new System.EventHandler(this.cbConsultaClase_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 16);
            this.label1.TabIndex = 13;
            this.label1.Text = "Clase";
            // 
            // txtClaseConsulta
            // 
            this.txtClaseConsulta.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtClaseConsulta.Location = new System.Drawing.Point(158, 59);
            this.txtClaseConsulta.Name = "txtClaseConsulta";
            this.txtClaseConsulta.ReadOnly = true;
            this.txtClaseConsulta.Size = new System.Drawing.Size(383, 22);
            this.txtClaseConsulta.TabIndex = 25;
            // 
            // tpNuevaCuenta
            // 
            this.tpNuevaCuenta.Controls.Add(this.tsMenu);
            this.tpNuevaCuenta.Location = new System.Drawing.Point(4, 25);
            this.tpNuevaCuenta.Name = "tpNuevaCuenta";
            this.tpNuevaCuenta.Padding = new System.Windows.Forms.Padding(3);
            this.tpNuevaCuenta.Size = new System.Drawing.Size(100, 0);
            this.tpNuevaCuenta.TabIndex = 0;
            this.tpNuevaCuenta.Text = "Núeva Cuenta";
            this.tpNuevaCuenta.UseVisualStyleBackColor = true;
            // 
            // tsMenu
            // 
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsSalir});
            this.tsMenu.Location = new System.Drawing.Point(3, 3);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(94, 25);
            this.tsMenu.TabIndex = 1;
            this.tsMenu.Text = "toolStrip1";
            // 
            // tsSalir
            // 
            this.tsSalir.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.tsSalir.Image = ((System.Drawing.Image)(resources.GetObject("tsSalir.Image")));
            this.tsSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsSalir.Name = "tsSalir";
            this.tsSalir.Size = new System.Drawing.Size(91, 22);
            this.tsSalir.Text = "Salir [ESC]";
            this.tsSalir.Click += new System.EventHandler(this.tsSalir_Click);
            // 
            // tcPuc
            // 
            this.tcPuc.Controls.Add(this.tpNuevaCuenta);
            this.tcPuc.Controls.Add(this.tpConsultas);
            this.tcPuc.Location = new System.Drawing.Point(292, 19);
            this.tcPuc.Name = "tcPuc";
            this.tcPuc.SelectedIndex = 0;
            this.tcPuc.Size = new System.Drawing.Size(108, 26);
            this.tcPuc.TabIndex = 1;
            this.tcPuc.Visible = false;
            // 
            // FrmPuc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(567, 337);
            this.Controls.Add(this.tsMenuConsulta);
            this.Controls.Add(this.gbNuevo);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPuc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Núeva cuenta";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPuc_FormClosing);
            this.Load += new System.EventHandler(this.FrmPuc_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmPuc_KeyDown);
            this.gbNuevo.ResumeLayout(false);
            this.tcCuentasPuc.ResumeLayout(false);
            this.tpClase.ResumeLayout(false);
            this.tpClase.PerformLayout();
            this.tsMenuClase.ResumeLayout(false);
            this.tsMenuClase.PerformLayout();
            this.tpGrupo.ResumeLayout(false);
            this.tpGrupo.PerformLayout();
            this.tsMenuGrupo.ResumeLayout(false);
            this.tsMenuGrupo.PerformLayout();
            this.tpCuenta.ResumeLayout(false);
            this.tpCuenta.PerformLayout();
            this.tsMenuCuenta.ResumeLayout(false);
            this.tsMenuCuenta.PerformLayout();
            this.tpSubCuenta.ResumeLayout(false);
            this.tpSubCuenta.PerformLayout();
            this.tsMenuSubCuenta.ResumeLayout(false);
            this.tsMenuSubCuenta.PerformLayout();
            this.tsMenuConsulta.ResumeLayout(false);
            this.tsMenuConsulta.PerformLayout();
            this.tpConsultas.ResumeLayout(false);
            this.tpConsultas.PerformLayout();
            this.gbConsultas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuentas)).EndInit();
            this.tpNuevaCuenta.ResumeLayout(false);
            this.tpNuevaCuenta.PerformLayout();
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.tcPuc.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbNuevo;
        private System.Windows.Forms.TabControl tcCuentasPuc;
        private System.Windows.Forms.TabPage tpClase;
        private System.Windows.Forms.TabPage tpGrupo;
        private System.Windows.Forms.TabPage tpCuenta;
        private System.Windows.Forms.TabPage tpSubCuenta;
        private System.Windows.Forms.ToolStrip tsMenuClase;
        private System.Windows.Forms.Label lblNumeroClase;
        private System.Windows.Forms.TextBox txtNombreClase;
        private System.Windows.Forms.Label lblNombreClase;
        private System.Windows.Forms.TextBox txtNumeroClase;
        private System.Windows.Forms.TextBox txtNombreGrupo;
        private System.Windows.Forms.Label lblNombreGrupo;
        private System.Windows.Forms.TextBox txtNumeroGrupo;
        private System.Windows.Forms.Label lblNumeroGrupo;
        private System.Windows.Forms.ToolStrip tsMenuGrupo;
        private System.Windows.Forms.TextBox txtNombreCuenta;
        private System.Windows.Forms.Label lblNombreCuenta;
        private System.Windows.Forms.TextBox txtNumeroCuenta;
        private System.Windows.Forms.Label lblNumeroCuenta;
        private System.Windows.Forms.ToolStrip tsMenuCuenta;
        private System.Windows.Forms.TextBox txtNombreScta;
        private System.Windows.Forms.Label lblNombreScta;
        private System.Windows.Forms.TextBox txtNumeroScta;
        private System.Windows.Forms.Label lblNumeroScta;
        private System.Windows.Forms.ToolStrip tsMenuSubCuenta;
        private System.Windows.Forms.ComboBox cbClases;
        private System.Windows.Forms.Label lblSeleccioneClase;
        private System.Windows.Forms.Label lblSeleccioneGrupo;
        private System.Windows.Forms.ComboBox cbGrupos;
        private System.Windows.Forms.Label lblSeleccionesClaseCta;
        private System.Windows.Forms.ComboBox cbClasesCta;
        private System.Windows.Forms.Label lblSeleccioneGrupoScta;
        private System.Windows.Forms.ComboBox cbGruposScta;
        private System.Windows.Forms.Label lblSeleccioneClaseScta;
        private System.Windows.Forms.ComboBox cbClasesScta;
        private System.Windows.Forms.Label lblCuentaScta;
        private System.Windows.Forms.ComboBox cbCuentas;
        private System.Windows.Forms.ToolStripButton btnGuardarClase;
        private System.Windows.Forms.ToolStripButton btnGuardarGrupo;
        private System.Windows.Forms.ToolStripButton btnGuardarCuenta;
        private System.Windows.Forms.ToolStripButton btnGuardar;
        private System.Windows.Forms.TextBox txtNameClase;
        private System.Windows.Forms.TextBox txtNameGrupo;
        private System.Windows.Forms.TextBox txtNameClaseC;
        private System.Windows.Forms.TextBox txtNameCuentaS;
        private System.Windows.Forms.TextBox txtNameGrupoS;
        private System.Windows.Forms.TextBox txtNameClaseS;
        private System.Windows.Forms.ToolStrip tsMenuConsulta;
        private System.Windows.Forms.ToolStripButton tsBtnSalirConsulta;
        private System.Windows.Forms.TabPage tpConsultas;
        private System.Windows.Forms.TextBox txtClaseConsulta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbConsultaClase;
        private System.Windows.Forms.GroupBox gbConsultas;
        private System.Windows.Forms.DataGridView dgvCuentas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.TabPage tpNuevaCuenta;
        private System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.ToolStripButton tsSalir;
        public System.Windows.Forms.TabControl tcPuc;
    }
}