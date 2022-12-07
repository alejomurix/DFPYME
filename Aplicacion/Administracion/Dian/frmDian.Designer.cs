namespace Aplicacion.Administracion.Dian
{
    partial class frmDian
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDian));
            this.gbxResolicion = new System.Windows.Forms.GroupBox();
            this.cbModalidad = new System.Windows.Forms.ComboBox();
            this.dtpFechaExpedicion = new System.Windows.Forms.DateTimePicker();
            this.txtNumeroResolucion = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblfecha = new System.Windows.Forms.Label();
            this.lblNumeroResolucion = new System.Windows.Forms.Label();
            this.txtTextoInicialSave = new System.Windows.Forms.TextBox();
            this.txtTextoFinalSave = new System.Windows.Forms.TextBox();
            this.lblSerieInicio = new System.Windows.Forms.Label();
            this.lblNumeroInicio = new System.Windows.Forms.Label();
            this.lblSerieFin = new System.Windows.Forms.Label();
            this.lblNumeroFin = new System.Windows.Forms.Label();
            this.txtSerieInicio = new System.Windows.Forms.TextBox();
            this.gbxdesde = new System.Windows.Forms.GroupBox();
            this.txtNumeroInicio = new System.Windows.Forms.TextBox();
            this.gbxhasta = new System.Windows.Forms.GroupBox();
            this.txtNumeroFin = new System.Windows.Forms.TextBox();
            this.txtSerieFinal = new System.Windows.Forms.TextBox();
            this.tcConsultar = new System.Windows.Forms.TabControl();
            this.tpInsertarResolucion = new System.Windows.Forms.TabPage();
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.tsCbDescto = new System.Windows.Forms.ToolStripComboBox();
            this.tsbtnGuardar = new System.Windows.Forms.ToolStripButton();
            this.tsbtnSalir = new System.Windows.Forms.ToolStripButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnGuardarConfigDian = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.chkBloquearFacturacion = new System.Windows.Forms.CheckBox();
            this.txtNumerosRestantes = new System.Windows.Forms.TextBox();
            this.dgvDian = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Resolucion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Desde = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hasta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblMuestraTirilla_3 = new System.Windows.Forms.Label();
            this.lblMuestraTirilla_2 = new System.Windows.Forms.Label();
            this.lblMuestraTirilla_1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblMuestraCarta = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTextoInicial = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTextoFinal = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsBtnGuardarConfImpresion = new System.Windows.Forms.ToolStripButton();
            this.gbxResolicion.SuspendLayout();
            this.gbxdesde.SuspendLayout();
            this.gbxhasta.SuspendLayout();
            this.tcConsultar.SuspendLayout();
            this.tpInsertarResolucion.SuspendLayout();
            this.tsMenu.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDian)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxResolicion
            // 
            this.gbxResolicion.Controls.Add(this.cbModalidad);
            this.gbxResolicion.Controls.Add(this.dtpFechaExpedicion);
            this.gbxResolicion.Controls.Add(this.txtNumeroResolucion);
            this.gbxResolicion.Controls.Add(this.label4);
            this.gbxResolicion.Controls.Add(this.lblfecha);
            this.gbxResolicion.Controls.Add(this.lblNumeroResolucion);
            this.gbxResolicion.Location = new System.Drawing.Point(6, 41);
            this.gbxResolicion.Name = "gbxResolicion";
            this.gbxResolicion.Size = new System.Drawing.Size(675, 62);
            this.gbxResolicion.TabIndex = 1;
            this.gbxResolicion.TabStop = false;
            this.gbxResolicion.Text = "Resolución";
            // 
            // cbModalidad
            // 
            this.cbModalidad.DisplayMember = "Nombre";
            this.cbModalidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbModalidad.FormattingEnabled = true;
            this.cbModalidad.Location = new System.Drawing.Point(538, 22);
            this.cbModalidad.Name = "cbModalidad";
            this.cbModalidad.Size = new System.Drawing.Size(121, 24);
            this.cbModalidad.TabIndex = 4;
            this.cbModalidad.ValueMember = "Id";
            // 
            // dtpFechaExpedicion
            // 
            this.dtpFechaExpedicion.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaExpedicion.Location = new System.Drawing.Point(305, 23);
            this.dtpFechaExpedicion.Name = "dtpFechaExpedicion";
            this.dtpFechaExpedicion.Size = new System.Drawing.Size(136, 22);
            this.dtpFechaExpedicion.TabIndex = 1;
            // 
            // txtNumeroResolucion
            // 
            this.txtNumeroResolucion.Location = new System.Drawing.Point(69, 23);
            this.txtNumeroResolucion.MaxLength = 50;
            this.txtNumeroResolucion.Name = "txtNumeroResolucion";
            this.txtNumeroResolucion.Size = new System.Drawing.Size(169, 22);
            this.txtNumeroResolucion.TabIndex = 0;
            this.txtNumeroResolucion.Validating += new System.ComponentModel.CancelEventHandler(this.txtNumeroResolucion_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(457, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Modalidad";
            // 
            // lblfecha
            // 
            this.lblfecha.AutoSize = true;
            this.lblfecha.Location = new System.Drawing.Point(247, 26);
            this.lblfecha.Name = "lblfecha";
            this.lblfecha.Size = new System.Drawing.Size(46, 16);
            this.lblfecha.TabIndex = 3;
            this.lblfecha.Text = "Fecha";
            // 
            // lblNumeroResolucion
            // 
            this.lblNumeroResolucion.AutoSize = true;
            this.lblNumeroResolucion.Location = new System.Drawing.Point(13, 26);
            this.lblNumeroResolucion.Name = "lblNumeroResolucion";
            this.lblNumeroResolucion.Size = new System.Drawing.Size(56, 16);
            this.lblNumeroResolucion.TabIndex = 2;
            this.lblNumeroResolucion.Text = "Número";
            // 
            // txtTextoInicialSave
            // 
            this.txtTextoInicialSave.Location = new System.Drawing.Point(656, 24);
            this.txtTextoInicialSave.MaxLength = 50;
            this.txtTextoInicialSave.Name = "txtTextoInicialSave";
            this.txtTextoInicialSave.Size = new System.Drawing.Size(10, 22);
            this.txtTextoInicialSave.TabIndex = 1;
            this.txtTextoInicialSave.Text = "Autorización Dian No. ";
            this.txtTextoInicialSave.Visible = false;
            this.txtTextoInicialSave.Validating += new System.ComponentModel.CancelEventHandler(this.txtNumeroInicio_Validating);
            // 
            // txtTextoFinalSave
            // 
            this.txtTextoFinalSave.Location = new System.Drawing.Point(656, 24);
            this.txtTextoFinalSave.MaxLength = 50;
            this.txtTextoFinalSave.Name = "txtTextoFinalSave";
            this.txtTextoFinalSave.Size = new System.Drawing.Size(13, 22);
            this.txtTextoFinalSave.TabIndex = 1;
            this.txtTextoFinalSave.Text = "habilita";
            this.txtTextoFinalSave.Visible = false;
            this.txtTextoFinalSave.Validating += new System.ComponentModel.CancelEventHandler(this.txtNumeroInicio_Validating);
            // 
            // lblSerieInicio
            // 
            this.lblSerieInicio.AutoSize = true;
            this.lblSerieInicio.Location = new System.Drawing.Point(13, 27);
            this.lblSerieInicio.Name = "lblSerieInicio";
            this.lblSerieInicio.Size = new System.Drawing.Size(40, 16);
            this.lblSerieInicio.TabIndex = 2;
            this.lblSerieInicio.Text = "Serie";
            // 
            // lblNumeroInicio
            // 
            this.lblNumeroInicio.AutoSize = true;
            this.lblNumeroInicio.Location = new System.Drawing.Point(175, 27);
            this.lblNumeroInicio.Name = "lblNumeroInicio";
            this.lblNumeroInicio.Size = new System.Drawing.Size(56, 16);
            this.lblNumeroInicio.TabIndex = 3;
            this.lblNumeroInicio.Text = "Numero";
            // 
            // lblSerieFin
            // 
            this.lblSerieFin.AutoSize = true;
            this.lblSerieFin.Location = new System.Drawing.Point(13, 27);
            this.lblSerieFin.Name = "lblSerieFin";
            this.lblSerieFin.Size = new System.Drawing.Size(40, 16);
            this.lblSerieFin.TabIndex = 2;
            this.lblSerieFin.Text = "Serie";
            // 
            // lblNumeroFin
            // 
            this.lblNumeroFin.AutoSize = true;
            this.lblNumeroFin.Location = new System.Drawing.Point(175, 27);
            this.lblNumeroFin.Name = "lblNumeroFin";
            this.lblNumeroFin.Size = new System.Drawing.Size(56, 16);
            this.lblNumeroFin.TabIndex = 3;
            this.lblNumeroFin.Text = "Numero";
            // 
            // txtSerieInicio
            // 
            this.txtSerieInicio.Location = new System.Drawing.Point(59, 24);
            this.txtSerieInicio.MaxLength = 50;
            this.txtSerieInicio.Name = "txtSerieInicio";
            this.txtSerieInicio.Size = new System.Drawing.Size(94, 22);
            this.txtSerieInicio.TabIndex = 0;
            this.txtSerieInicio.Validating += new System.ComponentModel.CancelEventHandler(this.txtSerieInicio_Validating);
            // 
            // gbxdesde
            // 
            this.gbxdesde.Controls.Add(this.txtNumeroInicio);
            this.gbxdesde.Controls.Add(this.txtSerieInicio);
            this.gbxdesde.Controls.Add(this.txtTextoFinalSave);
            this.gbxdesde.Controls.Add(this.lblSerieInicio);
            this.gbxdesde.Controls.Add(this.lblNumeroInicio);
            this.gbxdesde.Location = new System.Drawing.Point(6, 109);
            this.gbxdesde.Name = "gbxdesde";
            this.gbxdesde.Size = new System.Drawing.Size(675, 60);
            this.gbxdesde.TabIndex = 2;
            this.gbxdesde.TabStop = false;
            this.gbxdesde.Text = "Desde";
            // 
            // txtNumeroInicio
            // 
            this.txtNumeroInicio.Location = new System.Drawing.Point(237, 24);
            this.txtNumeroInicio.MaxLength = 50;
            this.txtNumeroInicio.Name = "txtNumeroInicio";
            this.txtNumeroInicio.Size = new System.Drawing.Size(410, 22);
            this.txtNumeroInicio.TabIndex = 1;
            this.txtNumeroInicio.Validating += new System.ComponentModel.CancelEventHandler(this.txtNumeroInicio_Validating);
            // 
            // gbxhasta
            // 
            this.gbxhasta.Controls.Add(this.txtNumeroFin);
            this.gbxhasta.Controls.Add(this.txtTextoInicialSave);
            this.gbxhasta.Controls.Add(this.txtSerieFinal);
            this.gbxhasta.Controls.Add(this.lblSerieFin);
            this.gbxhasta.Controls.Add(this.lblNumeroFin);
            this.gbxhasta.Location = new System.Drawing.Point(6, 175);
            this.gbxhasta.Name = "gbxhasta";
            this.gbxhasta.Size = new System.Drawing.Size(675, 60);
            this.gbxhasta.TabIndex = 3;
            this.gbxhasta.TabStop = false;
            this.gbxhasta.Text = "Hasta";
            // 
            // txtNumeroFin
            // 
            this.txtNumeroFin.Location = new System.Drawing.Point(237, 24);
            this.txtNumeroFin.MaxLength = 50;
            this.txtNumeroFin.Name = "txtNumeroFin";
            this.txtNumeroFin.Size = new System.Drawing.Size(410, 22);
            this.txtNumeroFin.TabIndex = 1;
            this.txtNumeroFin.Validating += new System.ComponentModel.CancelEventHandler(this.txtNumeroFin_Validating);
            // 
            // txtSerieFinal
            // 
            this.txtSerieFinal.Location = new System.Drawing.Point(59, 24);
            this.txtSerieFinal.MaxLength = 50;
            this.txtSerieFinal.Name = "txtSerieFinal";
            this.txtSerieFinal.Size = new System.Drawing.Size(94, 22);
            this.txtSerieFinal.TabIndex = 0;
            this.txtSerieFinal.Validating += new System.ComponentModel.CancelEventHandler(this.txtSerieFinal_Validating);
            // 
            // tcConsultar
            // 
            this.tcConsultar.Controls.Add(this.tpInsertarResolucion);
            this.tcConsultar.Controls.Add(this.tabPage2);
            this.tcConsultar.Controls.Add(this.tabPage1);
            this.tcConsultar.Location = new System.Drawing.Point(0, 1);
            this.tcConsultar.Name = "tcConsultar";
            this.tcConsultar.SelectedIndex = 0;
            this.tcConsultar.Size = new System.Drawing.Size(698, 275);
            this.tcConsultar.TabIndex = 0;
            // 
            // tpInsertarResolucion
            // 
            this.tpInsertarResolucion.Controls.Add(this.tsMenu);
            this.tpInsertarResolucion.Controls.Add(this.gbxhasta);
            this.tpInsertarResolucion.Controls.Add(this.gbxResolicion);
            this.tpInsertarResolucion.Controls.Add(this.gbxdesde);
            this.tpInsertarResolucion.Location = new System.Drawing.Point(4, 25);
            this.tpInsertarResolucion.Name = "tpInsertarResolucion";
            this.tpInsertarResolucion.Padding = new System.Windows.Forms.Padding(3);
            this.tpInsertarResolucion.Size = new System.Drawing.Size(690, 246);
            this.tpInsertarResolucion.TabIndex = 0;
            this.tpInsertarResolucion.Text = "Configuración Dian";
            this.tpInsertarResolucion.UseVisualStyleBackColor = true;
            // 
            // tsMenu
            // 
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsCbDescto,
            this.tsbtnGuardar,
            this.tsbtnSalir});
            this.tsMenu.Location = new System.Drawing.Point(3, 3);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(684, 25);
            this.tsMenu.TabIndex = 0;
            this.tsMenu.Text = "Menu";
            // 
            // tsCbDescto
            // 
            this.tsCbDescto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tsCbDescto.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsCbDescto.Name = "tsCbDescto";
            this.tsCbDescto.Size = new System.Drawing.Size(80, 25);
            this.tsCbDescto.Visible = false;
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
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnGuardarConfigDian);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.chkBloquearFacturacion);
            this.tabPage2.Controls.Add(this.txtNumerosRestantes);
            this.tabPage2.Controls.Add(this.dgvDian);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(690, 246);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Consultar";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnGuardarConfigDian
            // 
            this.btnGuardarConfigDian.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.5F);
            this.btnGuardarConfigDian.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardarConfigDian.Image")));
            this.btnGuardarConfigDian.Location = new System.Drawing.Point(653, 213);
            this.btnGuardarConfigDian.Name = "btnGuardarConfigDian";
            this.btnGuardarConfigDian.Size = new System.Drawing.Size(27, 22);
            this.btnGuardarConfigDian.TabIndex = 77;
            this.btnGuardarConfigDian.UseVisualStyleBackColor = true;
            this.btnGuardarConfigDian.Click += new System.EventHandler(this.btnGuardarConfigDian_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(71, 188);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(269, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Cantidad de números restantes para alertar.";
            // 
            // chkBloquearFacturacion
            // 
            this.chkBloquearFacturacion.AutoSize = true;
            this.chkBloquearFacturacion.Location = new System.Drawing.Point(13, 216);
            this.chkBloquearFacturacion.Name = "chkBloquearFacturacion";
            this.chkBloquearFacturacion.Size = new System.Drawing.Size(530, 20);
            this.chkBloquearFacturacion.TabIndex = 1;
            this.chkBloquearFacturacion.Text = "Bloquear facturación si no hay registros siguientes y una vez se agote la numerac" +
                "ión.";
            this.chkBloquearFacturacion.UseVisualStyleBackColor = true;
            this.chkBloquearFacturacion.Visible = false;
            // 
            // txtNumerosRestantes
            // 
            this.txtNumerosRestantes.Location = new System.Drawing.Point(11, 185);
            this.txtNumerosRestantes.Name = "txtNumerosRestantes";
            this.txtNumerosRestantes.Size = new System.Drawing.Size(55, 22);
            this.txtNumerosRestantes.TabIndex = 0;
            this.txtNumerosRestantes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dgvDian
            // 
            this.dgvDian.AllowUserToAddRows = false;
            this.dgvDian.AllowUserToDeleteRows = false;
            this.dgvDian.AllowUserToOrderColumns = true;
            this.dgvDian.AllowUserToResizeColumns = false;
            this.dgvDian.AllowUserToResizeRows = false;
            this.dgvDian.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDian.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvDian.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDian.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Resolucion,
            this.Fecha,
            this.Desde,
            this.Hasta});
            this.dgvDian.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvDian.Location = new System.Drawing.Point(8, 4);
            this.dgvDian.Name = "dgvDian";
            this.dgvDian.Size = new System.Drawing.Size(672, 172);
            this.dgvDian.TabIndex = 0;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // Resolucion
            // 
            this.Resolucion.DataPropertyName = "Resolucion";
            this.Resolucion.HeaderText = "No. Resolución";
            this.Resolucion.Name = "Resolucion";
            // 
            // Fecha
            // 
            this.Fecha.DataPropertyName = "Fecha";
            this.Fecha.HeaderText = "Fecha de expedición";
            this.Fecha.Name = "Fecha";
            // 
            // Desde
            // 
            this.Desde.DataPropertyName = "Desde";
            this.Desde.HeaderText = "Desde";
            this.Desde.Name = "Desde";
            // 
            // Hasta
            // 
            this.Hasta.DataPropertyName = "Hasta";
            this.Hasta.HeaderText = "Hasta";
            this.Hasta.Name = "Hasta";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.toolStrip1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(690, 246);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Configuración de impresión";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblMuestraTirilla_3);
            this.groupBox3.Controls.Add(this.lblMuestraTirilla_2);
            this.groupBox3.Controls.Add(this.lblMuestraTirilla_1);
            this.groupBox3.Location = new System.Drawing.Point(13, 133);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(664, 103);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Muestra en tirilla";
            // 
            // lblMuestraTirilla_3
            // 
            this.lblMuestraTirilla_3.AutoSize = true;
            this.lblMuestraTirilla_3.Location = new System.Drawing.Point(7, 71);
            this.lblMuestraTirilla_3.Name = "lblMuestraTirilla_3";
            this.lblMuestraTirilla_3.Size = new System.Drawing.Size(0, 16);
            this.lblMuestraTirilla_3.TabIndex = 0;
            // 
            // lblMuestraTirilla_2
            // 
            this.lblMuestraTirilla_2.AutoSize = true;
            this.lblMuestraTirilla_2.Location = new System.Drawing.Point(7, 50);
            this.lblMuestraTirilla_2.Name = "lblMuestraTirilla_2";
            this.lblMuestraTirilla_2.Size = new System.Drawing.Size(0, 16);
            this.lblMuestraTirilla_2.TabIndex = 0;
            // 
            // lblMuestraTirilla_1
            // 
            this.lblMuestraTirilla_1.AutoSize = true;
            this.lblMuestraTirilla_1.Location = new System.Drawing.Point(7, 28);
            this.lblMuestraTirilla_1.Name = "lblMuestraTirilla_1";
            this.lblMuestraTirilla_1.Size = new System.Drawing.Size(0, 16);
            this.lblMuestraTirilla_1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblMuestraCarta);
            this.groupBox2.Location = new System.Drawing.Point(13, 77);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(664, 50);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Muestra en media carta";
            // 
            // lblMuestraCarta
            // 
            this.lblMuestraCarta.AutoSize = true;
            this.lblMuestraCarta.Location = new System.Drawing.Point(7, 22);
            this.lblMuestraCarta.Name = "lblMuestraCarta";
            this.lblMuestraCarta.Size = new System.Drawing.Size(0, 16);
            this.lblMuestraCarta.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtTextoInicial);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtTextoFinal);
            this.groupBox1.Location = new System.Drawing.Point(13, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(664, 47);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Texto incial:";
            // 
            // txtTextoInicial
            // 
            this.txtTextoInicial.Location = new System.Drawing.Point(92, 16);
            this.txtTextoInicial.Name = "txtTextoInicial";
            this.txtTextoInicial.Size = new System.Drawing.Size(203, 22);
            this.txtTextoInicial.TabIndex = 2;
            this.txtTextoInicial.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtTextoInicial_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(323, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Texto final:";
            // 
            // txtTextoFinal
            // 
            this.txtTextoFinal.Location = new System.Drawing.Point(408, 16);
            this.txtTextoFinal.Name = "txtTextoFinal";
            this.txtTextoFinal.Size = new System.Drawing.Size(203, 22);
            this.txtTextoFinal.TabIndex = 0;
            this.txtTextoFinal.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtTextoFinal_KeyUp);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnGuardarConfImpresion});
            this.toolStrip1.Location = new System.Drawing.Point(3, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(684, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "Menu";
            // 
            // tsBtnGuardarConfImpresion
            // 
            this.tsBtnGuardarConfImpresion.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnGuardarConfImpresion.Image")));
            this.tsBtnGuardarConfImpresion.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnGuardarConfImpresion.Name = "tsBtnGuardarConfImpresion";
            this.tsBtnGuardarConfImpresion.Size = new System.Drawing.Size(69, 22);
            this.tsBtnGuardarConfImpresion.Text = "Guardar";
            this.tsBtnGuardarConfImpresion.Click += new System.EventHandler(this.tsBtnGuardarConfImpresion_Click);
            // 
            // frmDian
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 275);
            this.Controls.Add(this.tcConsultar);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDian";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dian";
            this.Load += new System.EventHandler(this.frmDian_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmDian_KeyDown);
            this.gbxResolicion.ResumeLayout(false);
            this.gbxResolicion.PerformLayout();
            this.gbxdesde.ResumeLayout(false);
            this.gbxdesde.PerformLayout();
            this.gbxhasta.ResumeLayout(false);
            this.gbxhasta.PerformLayout();
            this.tcConsultar.ResumeLayout(false);
            this.tpInsertarResolucion.ResumeLayout(false);
            this.tpInsertarResolucion.PerformLayout();
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDian)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxResolicion;
        private System.Windows.Forms.DateTimePicker dtpFechaExpedicion;
        private System.Windows.Forms.TextBox txtNumeroResolucion;
        private System.Windows.Forms.Label lblfecha;
        private System.Windows.Forms.Label lblNumeroResolucion;
        private System.Windows.Forms.Label lblSerieInicio;
        private System.Windows.Forms.Label lblNumeroInicio;
        private System.Windows.Forms.Label lblSerieFin;
        private System.Windows.Forms.Label lblNumeroFin;
        private System.Windows.Forms.TextBox txtSerieInicio;
        private System.Windows.Forms.GroupBox gbxdesde;
        private System.Windows.Forms.TextBox txtNumeroInicio;
        private System.Windows.Forms.GroupBox gbxhasta;
        private System.Windows.Forms.TextBox txtNumeroFin;
        private System.Windows.Forms.TextBox txtSerieFinal;
        private System.Windows.Forms.TabControl tcConsultar;
        private System.Windows.Forms.TabPage tpInsertarResolucion;
        private System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.ToolStripButton tsbtnGuardar;
        private System.Windows.Forms.ToolStripButton tsbtnSalir;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgvDian;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Resolucion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Desde;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hasta;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsBtnGuardarConfImpresion;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTextoInicial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTextoFinal;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblMuestraCarta;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblMuestraTirilla_1;
        private System.Windows.Forms.Label lblMuestraTirilla_3;
        private System.Windows.Forms.Label lblMuestraTirilla_2;
        private System.Windows.Forms.ToolStripComboBox tsCbDescto;
        private System.Windows.Forms.TextBox txtTextoInicialSave;
        private System.Windows.Forms.TextBox txtTextoFinalSave;
        private System.Windows.Forms.CheckBox chkBloquearFacturacion;
        private System.Windows.Forms.TextBox txtNumerosRestantes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGuardarConfigDian;
        private System.Windows.Forms.ComboBox cbModalidad;
        private System.Windows.Forms.Label label4;
    }
}