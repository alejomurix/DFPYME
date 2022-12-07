namespace Aplicacion.Compras.CuentasPorPagar
{
    partial class FrmCuentaPagar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCuentaPagar));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.tsBtnGuardar = new System.Windows.Forms.ToolStripButton();
            this.tsBtnSalir = new System.Windows.Forms.ToolStripButton();
            this.gbTercero = new System.Windows.Forms.GroupBox();
            this.lblTercero = new System.Windows.Forms.Label();
            this.txtNit = new System.Windows.Forms.TextBox();
            this.btnBuscarTercero = new System.Windows.Forms.Button();
            this.txtTercero = new System.Windows.Forms.TextBox();
            this.cbDocumento = new System.Windows.Forms.ComboBox();
            this.gbDatos = new System.Windows.Forms.GroupBox();
            this.lblNumero = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblFechaLimite = new System.Windows.Forms.Label();
            this.dtpLimite = new System.Windows.Forms.DateTimePicker();
            this.lblCuenta = new System.Windows.Forms.Label();
            this.cbCuentas = new System.Windows.Forms.ComboBox();
            this.gbConceptos = new System.Windows.Forms.GroupBox();
            this.lblConcepto = new System.Windows.Forms.Label();
            this.txtConcepto = new System.Windows.Forms.TextBox();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.lblValor = new System.Windows.Forms.Label();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.gbListaConceptos = new System.Windows.Forms.GroupBox();
            this.dgvConceptos = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Concepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.lblPesosTotal = new System.Windows.Forms.Label();
            this.btnCambiarRetencion = new System.Windows.Forms.Button();
            this.lblRetencion = new System.Windows.Forms.Label();
            this.txtRetencion = new System.Windows.Forms.TextBox();
            this.btnInfoRete = new System.Windows.Forms.Button();
            this.lblPesoRetencion = new System.Windows.Forms.Label();
            this.lblTasaRetencion = new System.Windows.Forms.Label();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.txtSubTotal = new System.Windows.Forms.TextBox();
            this.lblPesosSubTotal = new System.Windows.Forms.Label();
            this.tsMenu.SuspendLayout();
            this.gbTercero.SuspendLayout();
            this.gbDatos.SuspendLayout();
            this.gbConceptos.SuspendLayout();
            this.gbListaConceptos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConceptos)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMenu
            // 
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnGuardar,
            this.tsBtnSalir});
            this.tsMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(900, 25);
            this.tsMenu.TabIndex = 2;
            this.tsMenu.Text = "Menu";
            // 
            // tsBtnGuardar
            // 
            this.tsBtnGuardar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsBtnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnGuardar.Image")));
            this.tsBtnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnGuardar.Name = "tsBtnGuardar";
            this.tsBtnGuardar.Size = new System.Drawing.Size(101, 22);
            this.tsBtnGuardar.Text = "Guardar [F2]";
            this.tsBtnGuardar.Click += new System.EventHandler(this.tsBtnGuardar_Click);
            // 
            // tsBtnSalir
            // 
            this.tsBtnSalir.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsBtnSalir.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnSalir.Image")));
            this.tsBtnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnSalir.Name = "tsBtnSalir";
            this.tsBtnSalir.Size = new System.Drawing.Size(87, 22);
            this.tsBtnSalir.Text = "Salir [ESC]";
            this.tsBtnSalir.Click += new System.EventHandler(this.tsBtnSalir_Click);
            // 
            // gbTercero
            // 
            this.gbTercero.Controls.Add(this.lblTercero);
            this.gbTercero.Controls.Add(this.txtNit);
            this.gbTercero.Controls.Add(this.btnBuscarTercero);
            this.gbTercero.Controls.Add(this.txtTercero);
            this.gbTercero.Controls.Add(this.cbDocumento);
            this.gbTercero.Location = new System.Drawing.Point(14, 36);
            this.gbTercero.Name = "gbTercero";
            this.gbTercero.Size = new System.Drawing.Size(862, 67);
            this.gbTercero.TabIndex = 4;
            this.gbTercero.TabStop = false;
            // 
            // lblTercero
            // 
            this.lblTercero.AutoSize = true;
            this.lblTercero.Location = new System.Drawing.Point(6, 28);
            this.lblTercero.Name = "lblTercero";
            this.lblTercero.Size = new System.Drawing.Size(56, 16);
            this.lblTercero.TabIndex = 3;
            this.lblTercero.Text = "Tercero";
            // 
            // txtNit
            // 
            this.txtNit.Location = new System.Drawing.Point(64, 25);
            this.txtNit.Name = "txtNit";
            this.txtNit.Size = new System.Drawing.Size(171, 22);
            this.txtNit.TabIndex = 0;
            this.txtNit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNit_KeyPress);
            // 
            // btnBuscarTercero
            // 
            this.btnBuscarTercero.Location = new System.Drawing.Point(238, 24);
            this.btnBuscarTercero.Name = "btnBuscarTercero";
            this.btnBuscarTercero.Size = new System.Drawing.Size(25, 24);
            this.btnBuscarTercero.TabIndex = 1;
            this.btnBuscarTercero.Text = "...";
            this.btnBuscarTercero.UseVisualStyleBackColor = true;
            this.btnBuscarTercero.Click += new System.EventHandler(this.btnBuscarTercero_Click);
            // 
            // txtTercero
            // 
            this.txtTercero.Location = new System.Drawing.Point(269, 25);
            this.txtTercero.Name = "txtTercero";
            this.txtTercero.ReadOnly = true;
            this.txtTercero.Size = new System.Drawing.Size(391, 22);
            this.txtTercero.TabIndex = 6;
            // 
            // cbDocumento
            // 
            this.cbDocumento.DisplayMember = "Nombre";
            this.cbDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDocumento.FormattingEnabled = true;
            this.cbDocumento.Location = new System.Drawing.Point(672, 24);
            this.cbDocumento.Name = "cbDocumento";
            this.cbDocumento.Size = new System.Drawing.Size(177, 24);
            this.cbDocumento.TabIndex = 16;
            this.cbDocumento.ValueMember = "Id";
            this.cbDocumento.SelectionChangeCommitted += new System.EventHandler(this.cbDocumento_SelectionChangeCommitted);
            // 
            // gbDatos
            // 
            this.gbDatos.Controls.Add(this.lblNumero);
            this.gbDatos.Controls.Add(this.txtNumero);
            this.gbDatos.Controls.Add(this.lblFecha);
            this.gbDatos.Controls.Add(this.dtpFecha);
            this.gbDatos.Controls.Add(this.lblFechaLimite);
            this.gbDatos.Controls.Add(this.dtpLimite);
            this.gbDatos.Controls.Add(this.lblCuenta);
            this.gbDatos.Controls.Add(this.cbCuentas);
            this.gbDatos.Location = new System.Drawing.Point(14, 109);
            this.gbDatos.Name = "gbDatos";
            this.gbDatos.Size = new System.Drawing.Size(862, 62);
            this.gbDatos.TabIndex = 18;
            this.gbDatos.TabStop = false;
            // 
            // lblNumero
            // 
            this.lblNumero.AutoSize = true;
            this.lblNumero.Location = new System.Drawing.Point(12, 26);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(56, 16);
            this.lblNumero.TabIndex = 23;
            this.lblNumero.Text = "Número";
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(79, 23);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(129, 22);
            this.txtNumero.TabIndex = 22;
            this.txtNumero.Validating += new System.ComponentModel.CancelEventHandler(this.txtNumero_Validating);
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(230, 26);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(46, 16);
            this.lblFecha.TabIndex = 10;
            this.lblFecha.Text = "Fecha";
            // 
            // dtpFecha
            // 
            this.dtpFecha.CustomFormat = "dd/MM/yyyy";
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecha.Location = new System.Drawing.Point(281, 23);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(84, 22);
            this.dtpFecha.TabIndex = 19;
            // 
            // lblFechaLimite
            // 
            this.lblFechaLimite.AutoSize = true;
            this.lblFechaLimite.Location = new System.Drawing.Point(391, 27);
            this.lblFechaLimite.Name = "lblFechaLimite";
            this.lblFechaLimite.Size = new System.Drawing.Size(84, 16);
            this.lblFechaLimite.TabIndex = 20;
            this.lblFechaLimite.Text = "Fecha Limite";
            // 
            // dtpLimite
            // 
            this.dtpLimite.CustomFormat = "dd/MM/yyyy";
            this.dtpLimite.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpLimite.Location = new System.Drawing.Point(479, 23);
            this.dtpLimite.Name = "dtpLimite";
            this.dtpLimite.Size = new System.Drawing.Size(84, 22);
            this.dtpLimite.TabIndex = 21;
            this.dtpLimite.Validating += new System.ComponentModel.CancelEventHandler(this.dtpLimite_Validating);
            // 
            // lblCuenta
            // 
            this.lblCuenta.AutoSize = true;
            this.lblCuenta.Location = new System.Drawing.Point(581, 26);
            this.lblCuenta.Name = "lblCuenta";
            this.lblCuenta.Size = new System.Drawing.Size(50, 16);
            this.lblCuenta.TabIndex = 8;
            this.lblCuenta.Text = "Cuenta";
            // 
            // cbCuentas
            // 
            this.cbCuentas.DisplayMember = "Nombre";
            this.cbCuentas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCuentas.FormattingEnabled = true;
            this.cbCuentas.Location = new System.Drawing.Point(636, 21);
            this.cbCuentas.Name = "cbCuentas";
            this.cbCuentas.Size = new System.Drawing.Size(213, 24);
            this.cbCuentas.TabIndex = 7;
            this.cbCuentas.ValueMember = "Id";
            // 
            // gbConceptos
            // 
            this.gbConceptos.Controls.Add(this.lblConcepto);
            this.gbConceptos.Controls.Add(this.txtConcepto);
            this.gbConceptos.Controls.Add(this.lblCantidad);
            this.gbConceptos.Controls.Add(this.txtCantidad);
            this.gbConceptos.Controls.Add(this.lblValor);
            this.gbConceptos.Controls.Add(this.txtValor);
            this.gbConceptos.Controls.Add(this.btnAgregar);
            this.gbConceptos.Location = new System.Drawing.Point(14, 177);
            this.gbConceptos.Name = "gbConceptos";
            this.gbConceptos.Size = new System.Drawing.Size(862, 63);
            this.gbConceptos.TabIndex = 19;
            this.gbConceptos.TabStop = false;
            // 
            // lblConcepto
            // 
            this.lblConcepto.AutoSize = true;
            this.lblConcepto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblConcepto.Location = new System.Drawing.Point(12, 24);
            this.lblConcepto.Name = "lblConcepto";
            this.lblConcepto.Size = new System.Drawing.Size(66, 16);
            this.lblConcepto.TabIndex = 16;
            this.lblConcepto.Text = "Concepto";
            // 
            // txtConcepto
            // 
            this.txtConcepto.Location = new System.Drawing.Point(84, 21);
            this.txtConcepto.MaxLength = 100;
            this.txtConcepto.Name = "txtConcepto";
            this.txtConcepto.Size = new System.Drawing.Size(325, 22);
            this.txtConcepto.TabIndex = 12;
            this.txtConcepto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtConcepto_KeyPress);
            this.txtConcepto.Validating += new System.ComponentModel.CancelEventHandler(this.txtConcepto_Validating);
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblCantidad.Location = new System.Drawing.Point(425, 24);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(62, 16);
            this.lblCantidad.TabIndex = 17;
            this.lblCantidad.Text = "Cantidad";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(490, 21);
            this.txtCantidad.MaxLength = 20;
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(140, 22);
            this.txtCantidad.TabIndex = 14;
            this.txtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);
            this.txtCantidad.Validating += new System.ComponentModel.CancelEventHandler(this.txtCantidad_Validating);
            // 
            // lblValor
            // 
            this.lblValor.AutoSize = true;
            this.lblValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblValor.Location = new System.Drawing.Point(648, 24);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(40, 16);
            this.lblValor.TabIndex = 18;
            this.lblValor.Text = "Valor";
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(693, 21);
            this.txtValor.MaxLength = 20;
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(136, 22);
            this.txtValor.TabIndex = 15;
            this.txtValor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValor_KeyPress);
            this.txtValor.Validating += new System.ComponentModel.CancelEventHandler(this.txtValor_Validating);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregar.Image")));
            this.btnAgregar.Location = new System.Drawing.Point(834, 20);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(24, 24);
            this.btnAgregar.TabIndex = 19;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // gbListaConceptos
            // 
            this.gbListaConceptos.Controls.Add(this.dgvConceptos);
            this.gbListaConceptos.Controls.Add(this.btnEliminar);
            this.gbListaConceptos.Location = new System.Drawing.Point(14, 246);
            this.gbListaConceptos.Name = "gbListaConceptos";
            this.gbListaConceptos.Size = new System.Drawing.Size(862, 209);
            this.gbListaConceptos.TabIndex = 20;
            this.gbListaConceptos.TabStop = false;
            // 
            // dgvConceptos
            // 
            this.dgvConceptos.AllowUserToAddRows = false;
            this.dgvConceptos.AllowUserToDeleteRows = false;
            this.dgvConceptos.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvConceptos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvConceptos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConceptos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Concepto,
            this.Cantidad,
            this.Valor});
            this.dgvConceptos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvConceptos.Location = new System.Drawing.Point(5, 10);
            this.dgvConceptos.Name = "dgvConceptos";
            this.dgvConceptos.Size = new System.Drawing.Size(829, 193);
            this.dgvConceptos.TabIndex = 9;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // Concepto
            // 
            this.Concepto.DataPropertyName = "Producto";
            this.Concepto.HeaderText = "Concepto";
            this.Concepto.Name = "Concepto";
            this.Concepto.Width = 475;
            // 
            // Cantidad
            // 
            this.Cantidad.DataPropertyName = "Cantidad";
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.Width = 147;
            // 
            // Valor
            // 
            this.Valor.DataPropertyName = "Valor_";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = null;
            this.Valor.DefaultCellStyle = dataGridViewCellStyle4;
            this.Valor.HeaderText = "Valor";
            this.Valor.Name = "Valor";
            this.Valor.Width = 147;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.Location = new System.Drawing.Point(834, 10);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(24, 24);
            this.btnEliminar.TabIndex = 13;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblTotal);
            this.groupBox1.Controls.Add(this.txtTotal);
            this.groupBox1.Controls.Add(this.lblPesosTotal);
            this.groupBox1.Controls.Add(this.btnCambiarRetencion);
            this.groupBox1.Controls.Add(this.lblRetencion);
            this.groupBox1.Controls.Add(this.txtRetencion);
            this.groupBox1.Controls.Add(this.btnInfoRete);
            this.groupBox1.Controls.Add(this.lblPesoRetencion);
            this.groupBox1.Controls.Add(this.lblTasaRetencion);
            this.groupBox1.Controls.Add(this.lblSubtotal);
            this.groupBox1.Controls.Add(this.txtSubTotal);
            this.groupBox1.Controls.Add(this.lblPesosSubTotal);
            this.groupBox1.Location = new System.Drawing.Point(14, 461);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(862, 67);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(655, 28);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(65, 16);
            this.lblTotal.TabIndex = 39;
            this.lblTotal.Text = "TOTAL :";
            // 
            // txtTotal
            // 
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(749, 25);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(100, 22);
            this.txtTotal.TabIndex = 41;
            this.txtTotal.Text = "0";
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblPesosTotal
            // 
            this.lblPesosTotal.AutoSize = true;
            this.lblPesosTotal.Location = new System.Drawing.Point(729, 28);
            this.lblPesosTotal.Name = "lblPesosTotal";
            this.lblPesosTotal.Size = new System.Drawing.Size(15, 16);
            this.lblPesosTotal.TabIndex = 40;
            this.lblPesosTotal.Text = "$";
            // 
            // btnCambiarRetencion
            // 
            this.btnCambiarRetencion.Enabled = false;
            this.btnCambiarRetencion.Image = ((System.Drawing.Image)(resources.GetObject("btnCambiarRetencion.Image")));
            this.btnCambiarRetencion.Location = new System.Drawing.Point(587, 22);
            this.btnCambiarRetencion.Name = "btnCambiarRetencion";
            this.btnCambiarRetencion.Size = new System.Drawing.Size(22, 26);
            this.btnCambiarRetencion.TabIndex = 38;
            this.btnCambiarRetencion.UseVisualStyleBackColor = true;
            this.btnCambiarRetencion.Click += new System.EventHandler(this.btnCambiarRetencion_Click);
            // 
            // lblRetencion
            // 
            this.lblRetencion.AutoSize = true;
            this.lblRetencion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRetencion.Location = new System.Drawing.Point(278, 28);
            this.lblRetencion.Name = "lblRetencion";
            this.lblRetencion.Size = new System.Drawing.Size(100, 16);
            this.lblRetencion.TabIndex = 34;
            this.lblRetencion.Text = "RETENCION:";
            // 
            // txtRetencion
            // 
            this.txtRetencion.BackColor = System.Drawing.SystemColors.Control;
            this.txtRetencion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRetencion.Location = new System.Drawing.Point(399, 25);
            this.txtRetencion.MaxLength = 10;
            this.txtRetencion.Name = "txtRetencion";
            this.txtRetencion.ReadOnly = true;
            this.txtRetencion.Size = new System.Drawing.Size(100, 22);
            this.txtRetencion.TabIndex = 33;
            this.txtRetencion.Text = "0";
            this.txtRetencion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnInfoRete
            // 
            this.btnInfoRete.Enabled = false;
            this.btnInfoRete.FlatAppearance.BorderSize = 0;
            this.btnInfoRete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInfoRete.Image = ((System.Drawing.Image)(resources.GetObject("btnInfoRete.Image")));
            this.btnInfoRete.Location = new System.Drawing.Point(552, 23);
            this.btnInfoRete.Name = "btnInfoRete";
            this.btnInfoRete.Size = new System.Drawing.Size(25, 23);
            this.btnInfoRete.TabIndex = 37;
            this.btnInfoRete.UseVisualStyleBackColor = true;
            // 
            // lblPesoRetencion
            // 
            this.lblPesoRetencion.AutoSize = true;
            this.lblPesoRetencion.Location = new System.Drawing.Point(382, 28);
            this.lblPesoRetencion.Name = "lblPesoRetencion";
            this.lblPesoRetencion.Size = new System.Drawing.Size(15, 16);
            this.lblPesoRetencion.TabIndex = 35;
            this.lblPesoRetencion.Text = "$";
            // 
            // lblTasaRetencion
            // 
            this.lblTasaRetencion.AutoSize = true;
            this.lblTasaRetencion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTasaRetencion.Location = new System.Drawing.Point(503, 28);
            this.lblTasaRetencion.Name = "lblTasaRetencion";
            this.lblTasaRetencion.Size = new System.Drawing.Size(27, 16);
            this.lblTasaRetencion.TabIndex = 36;
            this.lblTasaRetencion.Text = "0%";
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.AutoSize = true;
            this.lblSubtotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtotal.Location = new System.Drawing.Point(9, 28);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(96, 16);
            this.lblSubtotal.TabIndex = 18;
            this.lblSubtotal.Text = "SUBTOTAL :";
            // 
            // txtSubTotal
            // 
            this.txtSubTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubTotal.Location = new System.Drawing.Point(130, 25);
            this.txtSubTotal.Name = "txtSubTotal";
            this.txtSubTotal.ReadOnly = true;
            this.txtSubTotal.Size = new System.Drawing.Size(100, 22);
            this.txtSubTotal.TabIndex = 20;
            this.txtSubTotal.Text = "0";
            this.txtSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblPesosSubTotal
            // 
            this.lblPesosSubTotal.AutoSize = true;
            this.lblPesosSubTotal.Location = new System.Drawing.Point(111, 28);
            this.lblPesosSubTotal.Name = "lblPesosSubTotal";
            this.lblPesosSubTotal.Size = new System.Drawing.Size(15, 16);
            this.lblPesosSubTotal.TabIndex = 19;
            this.lblPesosSubTotal.Text = "$";
            // 
            // FrmCuentaPagar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(900, 538);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tsMenu);
            this.Controls.Add(this.gbTercero);
            this.Controls.Add(this.gbDatos);
            this.Controls.Add(this.gbConceptos);
            this.Controls.Add(this.gbListaConceptos);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCuentaPagar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cuentas por Pagar";
            this.Load += new System.EventHandler(this.FrmCuentaPagar_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmCuentaPagar_KeyDown);
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.gbTercero.ResumeLayout(false);
            this.gbTercero.PerformLayout();
            this.gbDatos.ResumeLayout(false);
            this.gbDatos.PerformLayout();
            this.gbConceptos.ResumeLayout(false);
            this.gbConceptos.PerformLayout();
            this.gbListaConceptos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConceptos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.ToolStripButton tsBtnGuardar;
        private System.Windows.Forms.ToolStripButton tsBtnSalir;
        private System.Windows.Forms.GroupBox gbTercero;
        private System.Windows.Forms.TextBox txtTercero;
        private System.Windows.Forms.Button btnBuscarTercero;
        private System.Windows.Forms.TextBox txtNit;
        private System.Windows.Forms.Label lblTercero;
        private System.Windows.Forms.ComboBox cbDocumento;
        private System.Windows.Forms.GroupBox gbDatos;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblCuenta;
        private System.Windows.Forms.ComboBox cbCuentas;
        private System.Windows.Forms.DateTimePicker dtpLimite;
        private System.Windows.Forms.Label lblFechaLimite;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.GroupBox gbConceptos;
        private System.Windows.Forms.Label lblConcepto;
        private System.Windows.Forms.TextBox txtConcepto;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.GroupBox gbListaConceptos;
        private System.Windows.Forms.DataGridView dgvConceptos;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.TextBox txtSubTotal;
        private System.Windows.Forms.Label lblPesosSubTotal;
        private System.Windows.Forms.Button btnCambiarRetencion;
        private System.Windows.Forms.Label lblRetencion;
        private System.Windows.Forms.TextBox txtRetencion;
        private System.Windows.Forms.Button btnInfoRete;
        private System.Windows.Forms.Label lblPesoRetencion;
        private System.Windows.Forms.Label lblTasaRetencion;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label lblPesosTotal;
        private System.Windows.Forms.Label lblNumero;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Concepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valor;
    }
}