namespace Aplicacion.Compras.Anticipos
{
    partial class FrmConsultarAnticipos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConsultarAnticipos));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.tsBtnListarTodos = new System.Windows.Forms.ToolStripButton();
            this.tsBtnAbono = new System.Windows.Forms.ToolStripButton();
            this.btnImprimir = new System.Windows.Forms.ToolStripButton();
            this.tsBtnAnular = new System.Windows.Forms.ToolStripButton();
            this.tsBtnSalir = new System.Windows.Forms.ToolStripButton();
            this.gbCritero = new System.Windows.Forms.GroupBox();
            this.cbCriterio = new System.Windows.Forms.ComboBox();
            this.txtTercero = new System.Windows.Forms.TextBox();
            this.btnBuscarTercero = new System.Windows.Forms.Button();
            this.cbFecha = new System.Windows.Forms.ComboBox();
            this.dtpFecha1 = new System.Windows.Forms.DateTimePicker();
            this.dtpFecha2 = new System.Windows.Forms.DateTimePicker();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.gbConsulta = new System.Windows.Forms.GroupBox();
            this.dgvConceptos = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdTercero_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdEgreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoEgreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdCuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdSubCuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Concepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusConcepto = new System.Windows.Forms.StatusStrip();
            this.btnInicio = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnAnterior = new System.Windows.Forms.ToolStripDropDownButton();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnSiguiente = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnFin = new System.Windows.Forms.ToolStripDropDownButton();
            this.gbFormasPago = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTransaccion = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCheque = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtEfectivo = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtResta = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCruce = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAbono = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSaldo = new System.Windows.Forms.TextBox();
            this.tsMenu.SuspendLayout();
            this.gbCritero.SuspendLayout();
            this.gbConsulta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConceptos)).BeginInit();
            this.StatusConcepto.SuspendLayout();
            this.gbFormasPago.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMenu
            // 
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnListarTodos,
            this.tsBtnAbono,
            this.btnImprimir,
            this.tsBtnAnular,
            this.tsBtnSalir});
            this.tsMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(1082, 25);
            this.tsMenu.TabIndex = 0;
            this.tsMenu.Text = "Menu";
            // 
            // tsBtnListarTodos
            // 
            this.tsBtnListarTodos.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsBtnListarTodos.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnListarTodos.Image")));
            this.tsBtnListarTodos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnListarTodos.Name = "tsBtnListarTodos";
            this.tsBtnListarTodos.Size = new System.Drawing.Size(100, 22);
            this.tsBtnListarTodos.Text = "Listar Todos";
            this.tsBtnListarTodos.Click += new System.EventHandler(this.tsBtnListarTodos_Click);
            // 
            // tsBtnAbono
            // 
            this.tsBtnAbono.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsBtnAbono.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnAbono.Image")));
            this.tsBtnAbono.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnAbono.Name = "tsBtnAbono";
            this.tsBtnAbono.Size = new System.Drawing.Size(116, 22);
            this.tsBtnAbono.Text = "Realizar abono";
            this.tsBtnAbono.Click += new System.EventHandler(this.tsBtnAbono_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnImprimir.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimir.Image")));
            this.btnImprimir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(77, 22);
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // tsBtnAnular
            // 
            this.tsBtnAnular.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsBtnAnular.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnAnular.Image")));
            this.tsBtnAnular.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnAnular.Name = "tsBtnAnular";
            this.tsBtnAnular.Size = new System.Drawing.Size(65, 22);
            this.tsBtnAnular.Text = "Anular";
            this.tsBtnAnular.Click += new System.EventHandler(this.tsBtnAnular_Click);
            // 
            // tsBtnSalir
            // 
            this.tsBtnSalir.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsBtnSalir.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnSalir.Image")));
            this.tsBtnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnSalir.Name = "tsBtnSalir";
            this.tsBtnSalir.Size = new System.Drawing.Size(53, 22);
            this.tsBtnSalir.Text = "Salir";
            this.tsBtnSalir.Click += new System.EventHandler(this.tsBtnSalir_Click);
            // 
            // gbCritero
            // 
            this.gbCritero.Controls.Add(this.cbCriterio);
            this.gbCritero.Controls.Add(this.txtTercero);
            this.gbCritero.Controls.Add(this.btnBuscarTercero);
            this.gbCritero.Controls.Add(this.cbFecha);
            this.gbCritero.Controls.Add(this.dtpFecha1);
            this.gbCritero.Controls.Add(this.dtpFecha2);
            this.gbCritero.Controls.Add(this.btnBuscar);
            this.gbCritero.Location = new System.Drawing.Point(12, 28);
            this.gbCritero.Name = "gbCritero";
            this.gbCritero.Size = new System.Drawing.Size(897, 58);
            this.gbCritero.TabIndex = 3;
            this.gbCritero.TabStop = false;
            this.gbCritero.Text = "Criterio Consulta";
            // 
            // cbCriterio
            // 
            this.cbCriterio.DisplayMember = "Nombre";
            this.cbCriterio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCriterio.FormattingEnabled = true;
            this.cbCriterio.Location = new System.Drawing.Point(10, 22);
            this.cbCriterio.Name = "cbCriterio";
            this.cbCriterio.Size = new System.Drawing.Size(187, 24);
            this.cbCriterio.TabIndex = 0;
            this.cbCriterio.ValueMember = "Id";
            this.cbCriterio.SelectionChangeCommitted += new System.EventHandler(this.cbCriterio_SelectionChangeCommitted);
            // 
            // txtTercero
            // 
            this.txtTercero.Enabled = false;
            this.txtTercero.Location = new System.Drawing.Point(220, 23);
            this.txtTercero.MaxLength = 30;
            this.txtTercero.Name = "txtTercero";
            this.txtTercero.Size = new System.Drawing.Size(231, 22);
            this.txtTercero.TabIndex = 1;
            this.txtTercero.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTercero_KeyPress);
            // 
            // btnBuscarTercero
            // 
            this.btnBuscarTercero.Enabled = false;
            this.btnBuscarTercero.Location = new System.Drawing.Point(458, 22);
            this.btnBuscarTercero.Name = "btnBuscarTercero";
            this.btnBuscarTercero.Size = new System.Drawing.Size(25, 23);
            this.btnBuscarTercero.TabIndex = 2;
            this.btnBuscarTercero.Text = "...";
            this.btnBuscarTercero.UseVisualStyleBackColor = true;
            this.btnBuscarTercero.Click += new System.EventHandler(this.btnBuscarTercero_Click);
            // 
            // cbFecha
            // 
            this.cbFecha.DisplayMember = "Nombre";
            this.cbFecha.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFecha.FormattingEnabled = true;
            this.cbFecha.Location = new System.Drawing.Point(508, 21);
            this.cbFecha.Name = "cbFecha";
            this.cbFecha.Size = new System.Drawing.Size(138, 24);
            this.cbFecha.TabIndex = 6;
            this.cbFecha.ValueMember = "Id";
            this.cbFecha.SelectionChangeCommitted += new System.EventHandler(this.cbFecha_SelectionChangeCommitted);
            // 
            // dtpFecha1
            // 
            this.dtpFecha1.CustomFormat = "dd/MM/yyyy";
            this.dtpFecha1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecha1.Location = new System.Drawing.Point(663, 22);
            this.dtpFecha1.Name = "dtpFecha1";
            this.dtpFecha1.Size = new System.Drawing.Size(84, 22);
            this.dtpFecha1.TabIndex = 7;
            // 
            // dtpFecha2
            // 
            this.dtpFecha2.CustomFormat = "dd/MM/yyyy";
            this.dtpFecha2.Enabled = false;
            this.dtpFecha2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecha2.Location = new System.Drawing.Point(761, 22);
            this.dtpFecha2.Name = "dtpFecha2";
            this.dtpFecha2.Size = new System.Drawing.Size(84, 22);
            this.dtpFecha2.TabIndex = 8;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(857, 21);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(25, 23);
            this.btnBuscar.TabIndex = 9;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // gbConsulta
            // 
            this.gbConsulta.Controls.Add(this.dgvConceptos);
            this.gbConsulta.Controls.Add(this.StatusConcepto);
            this.gbConsulta.Location = new System.Drawing.Point(12, 89);
            this.gbConsulta.Name = "gbConsulta";
            this.gbConsulta.Size = new System.Drawing.Size(1057, 308);
            this.gbConsulta.TabIndex = 21;
            this.gbConsulta.TabStop = false;
            // 
            // dgvConceptos
            // 
            this.dgvConceptos.AllowUserToAddRows = false;
            this.dgvConceptos.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvConceptos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConceptos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.IdTercero_,
            this.Nit,
            this.Nombre,
            this.Fecha,
            this.IdEgreso,
            this.NoEgreso,
            this.IdCuenta,
            this.IdSubCuenta,
            this.Cuenta,
            this.Concepto,
            this.Valor,
            this.Pago,
            this.Estado});
            this.dgvConceptos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvConceptos.Location = new System.Drawing.Point(3, 11);
            this.dgvConceptos.Name = "dgvConceptos";
            this.dgvConceptos.RowHeadersVisible = false;
            this.dgvConceptos.Size = new System.Drawing.Size(1050, 269);
            this.dgvConceptos.TabIndex = 0;
            this.dgvConceptos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvConceptos_CellClick);
            this.dgvConceptos.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgvConceptos_KeyUp);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // IdTercero_
            // 
            this.IdTercero_.DataPropertyName = "idtercero";
            this.IdTercero_.HeaderText = "IdTercero";
            this.IdTercero_.Name = "IdTercero_";
            this.IdTercero_.Visible = false;
            // 
            // Nit
            // 
            this.Nit.DataPropertyName = "nit";
            this.Nit.HeaderText = "Nit";
            this.Nit.Name = "Nit";
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "tercero";
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.Width = 200;
            // 
            // Fecha
            // 
            this.Fecha.DataPropertyName = "fecha";
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.Width = 120;
            // 
            // IdEgreso
            // 
            this.IdEgreso.DataPropertyName = "idegreso";
            this.IdEgreso.HeaderText = "IdEgreso";
            this.IdEgreso.Name = "IdEgreso";
            this.IdEgreso.Visible = false;
            // 
            // NoEgreso
            // 
            this.NoEgreso.DataPropertyName = "numero";
            this.NoEgreso.HeaderText = "NoEgreso";
            this.NoEgreso.Name = "NoEgreso";
            // 
            // IdCuenta
            // 
            this.IdCuenta.DataPropertyName = "idcuenta";
            this.IdCuenta.HeaderText = "IdCuenta";
            this.IdCuenta.Name = "IdCuenta";
            this.IdCuenta.Visible = false;
            // 
            // IdSubCuenta
            // 
            this.IdSubCuenta.DataPropertyName = "idsubcuenta";
            this.IdSubCuenta.HeaderText = "IdSubCuenta";
            this.IdSubCuenta.Name = "IdSubCuenta";
            this.IdSubCuenta.Visible = false;
            // 
            // Cuenta
            // 
            this.Cuenta.DataPropertyName = "nombre";
            this.Cuenta.HeaderText = "Cuenta";
            this.Cuenta.Name = "Cuenta";
            this.Cuenta.Visible = false;
            this.Cuenta.Width = 120;
            // 
            // Concepto
            // 
            this.Concepto.DataPropertyName = "concepto";
            this.Concepto.HeaderText = "Concepto";
            this.Concepto.Name = "Concepto";
            this.Concepto.Width = 410;
            // 
            // Valor
            // 
            this.Valor.DataPropertyName = "valor";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = null;
            this.Valor.DefaultCellStyle = dataGridViewCellStyle1;
            this.Valor.HeaderText = "Valor";
            this.Valor.Name = "Valor";
            // 
            // Pago
            // 
            this.Pago.DataPropertyName = "pago";
            this.Pago.HeaderText = "Pago";
            this.Pago.Name = "Pago";
            this.Pago.Visible = false;
            // 
            // Estado
            // 
            this.Estado.DataPropertyName = "estado";
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.Visible = false;
            // 
            // StatusConcepto
            // 
            this.StatusConcepto.BackColor = System.Drawing.Color.LightSteelBlue;
            this.StatusConcepto.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnInicio,
            this.btnAnterior,
            this.lblStatus,
            this.btnSiguiente,
            this.btnFin});
            this.StatusConcepto.Location = new System.Drawing.Point(3, 283);
            this.StatusConcepto.Name = "StatusConcepto";
            this.StatusConcepto.Size = new System.Drawing.Size(1051, 22);
            this.StatusConcepto.TabIndex = 1;
            this.StatusConcepto.Text = "Status";
            // 
            // btnInicio
            // 
            this.btnInicio.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnInicio.Image = ((System.Drawing.Image)(resources.GetObject("btnInicio.Image")));
            this.btnInicio.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnInicio.Name = "btnInicio";
            this.btnInicio.ShowDropDownArrow = false;
            this.btnInicio.Size = new System.Drawing.Size(20, 20);
            this.btnInicio.Text = "Inicio";
            this.btnInicio.Click += new System.EventHandler(this.btnInicio_Click);
            // 
            // btnAnterior
            // 
            this.btnAnterior.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAnterior.Image = ((System.Drawing.Image)(resources.GetObject("btnAnterior.Image")));
            this.btnAnterior.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.ShowDropDownArrow = false;
            this.btnAnterior.Size = new System.Drawing.Size(20, 20);
            this.btnAnterior.Text = "Anterior";
            this.btnAnterior.Click += new System.EventHandler(this.btnAnterior_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(30, 17);
            this.lblStatus.Text = "0 / 0";
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSiguiente.Image = ((System.Drawing.Image)(resources.GetObject("btnSiguiente.Image")));
            this.btnSiguiente.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.ShowDropDownArrow = false;
            this.btnSiguiente.Size = new System.Drawing.Size(20, 20);
            this.btnSiguiente.Text = "Siguiente";
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            // 
            // btnFin
            // 
            this.btnFin.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFin.Image = ((System.Drawing.Image)(resources.GetObject("btnFin.Image")));
            this.btnFin.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFin.Name = "btnFin";
            this.btnFin.ShowDropDownArrow = false;
            this.btnFin.Size = new System.Drawing.Size(20, 20);
            this.btnFin.Text = "Fin";
            this.btnFin.Click += new System.EventHandler(this.btnFin_Click);
            // 
            // gbFormasPago
            // 
            this.gbFormasPago.Controls.Add(this.label5);
            this.gbFormasPago.Controls.Add(this.txtTransaccion);
            this.gbFormasPago.Controls.Add(this.label7);
            this.gbFormasPago.Controls.Add(this.txtCheque);
            this.gbFormasPago.Controls.Add(this.label9);
            this.gbFormasPago.Controls.Add(this.txtEfectivo);
            this.gbFormasPago.Location = new System.Drawing.Point(226, 451);
            this.gbFormasPago.Name = "gbFormasPago";
            this.gbFormasPago.Size = new System.Drawing.Size(843, 56);
            this.gbFormasPago.TabIndex = 31;
            this.gbFormasPago.TabStop = false;
            this.gbFormasPago.Text = "Formas de Pago";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(561, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 16);
            this.label5.TabIndex = 48;
            this.label5.Text = "TRANSACCIÓN: ";
            // 
            // txtTransaccion
            // 
            this.txtTransaccion.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtTransaccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTransaccion.Location = new System.Drawing.Point(700, 20);
            this.txtTransaccion.Name = "txtTransaccion";
            this.txtTransaccion.ReadOnly = true;
            this.txtTransaccion.Size = new System.Drawing.Size(124, 22);
            this.txtTransaccion.TabIndex = 47;
            this.txtTransaccion.Text = "0";
            this.txtTransaccion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(299, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 16);
            this.label7.TabIndex = 45;
            this.label7.Text = "CHEQUE:";
            // 
            // txtCheque
            // 
            this.txtCheque.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtCheque.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCheque.Location = new System.Drawing.Point(385, 20);
            this.txtCheque.Name = "txtCheque";
            this.txtCheque.ReadOnly = true;
            this.txtCheque.Size = new System.Drawing.Size(124, 22);
            this.txtCheque.TabIndex = 44;
            this.txtCheque.Text = "0";
            this.txtCheque.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(8, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 16);
            this.label9.TabIndex = 42;
            this.label9.Text = "EFECTIVO: ";
            // 
            // txtEfectivo
            // 
            this.txtEfectivo.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtEfectivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEfectivo.Location = new System.Drawing.Point(111, 20);
            this.txtEfectivo.Name = "txtEfectivo";
            this.txtEfectivo.ReadOnly = true;
            this.txtEfectivo.Size = new System.Drawing.Size(124, 22);
            this.txtEfectivo.TabIndex = 41;
            this.txtEfectivo.Text = "0";
            this.txtEfectivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtResta);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtCruce);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtAbono);
            this.groupBox1.Location = new System.Drawing.Point(226, 510);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(843, 50);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(616, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 16);
            this.label1.TabIndex = 48;
            this.label1.Text = "RESTA: ";
            // 
            // txtResta
            // 
            this.txtResta.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtResta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResta.Location = new System.Drawing.Point(698, 17);
            this.txtResta.Name = "txtResta";
            this.txtResta.ReadOnly = true;
            this.txtResta.Size = new System.Drawing.Size(124, 22);
            this.txtResta.TabIndex = 47;
            this.txtResta.Text = "0";
            this.txtResta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(294, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 16);
            this.label2.TabIndex = 45;
            this.label2.Text = "CRUCES:";
            // 
            // txtCruce
            // 
            this.txtCruce.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtCruce.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCruce.Location = new System.Drawing.Point(385, 17);
            this.txtCruce.Name = "txtCruce";
            this.txtCruce.ReadOnly = true;
            this.txtCruce.Size = new System.Drawing.Size(124, 22);
            this.txtCruce.TabIndex = 44;
            this.txtCruce.Text = "0";
            this.txtCruce.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 16);
            this.label3.TabIndex = 42;
            this.label3.Text = "ABONOS: ";
            // 
            // txtAbono
            // 
            this.txtAbono.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtAbono.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAbono.Location = new System.Drawing.Point(111, 17);
            this.txtAbono.Name = "txtAbono";
            this.txtAbono.ReadOnly = true;
            this.txtAbono.Size = new System.Drawing.Size(124, 22);
            this.txtAbono.TabIndex = 41;
            this.txtAbono.Text = "0";
            this.txtAbono.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtSaldo);
            this.groupBox2.Location = new System.Drawing.Point(845, 401);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(224, 47);
            this.groupBox2.TabIndex = 33;
            this.groupBox2.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 16);
            this.label4.TabIndex = 48;
            this.label4.Text = "SALDO:";
            // 
            // txtSaldo
            // 
            this.txtSaldo.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtSaldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSaldo.Location = new System.Drawing.Point(81, 15);
            this.txtSaldo.Name = "txtSaldo";
            this.txtSaldo.ReadOnly = true;
            this.txtSaldo.Size = new System.Drawing.Size(124, 22);
            this.txtSaldo.TabIndex = 47;
            this.txtSaldo.Text = "0";
            this.txtSaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // FrmConsultarAnticipos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1082, 568);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbFormasPago);
            this.Controls.Add(this.gbConsulta);
            this.Controls.Add(this.tsMenu);
            this.Controls.Add(this.gbCritero);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmConsultarAnticipos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consultar anticipos";
            this.Load += new System.EventHandler(this.FrmConsultarAnticipos_Load);
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.gbCritero.ResumeLayout(false);
            this.gbCritero.PerformLayout();
            this.gbConsulta.ResumeLayout(false);
            this.gbConsulta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConceptos)).EndInit();
            this.StatusConcepto.ResumeLayout(false);
            this.StatusConcepto.PerformLayout();
            this.gbFormasPago.ResumeLayout(false);
            this.gbFormasPago.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.GroupBox gbCritero;
        private System.Windows.Forms.ComboBox cbCriterio;
        private System.Windows.Forms.TextBox txtTercero;
        private System.Windows.Forms.Button btnBuscarTercero;
        private System.Windows.Forms.ComboBox cbFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha1;
        private System.Windows.Forms.DateTimePicker dtpFecha2;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.GroupBox gbConsulta;
        private System.Windows.Forms.DataGridView dgvConceptos;
        private System.Windows.Forms.StatusStrip StatusConcepto;
        private System.Windows.Forms.ToolStripDropDownButton btnInicio;
        private System.Windows.Forms.ToolStripDropDownButton btnAnterior;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripDropDownButton btnSiguiente;
        private System.Windows.Forms.ToolStripDropDownButton btnFin;
        private System.Windows.Forms.GroupBox gbFormasPago;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTransaccion;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCheque;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtEfectivo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtResta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCruce;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAbono;
        private System.Windows.Forms.ToolStripButton tsBtnListarTodos;
        private System.Windows.Forms.ToolStripButton tsBtnAbono;
        private System.Windows.Forms.ToolStripButton tsBtnSalir;
        private System.Windows.Forms.ToolStripButton btnImprimir;
        private System.Windows.Forms.ToolStripButton tsBtnAnular;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdTercero_;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdEgreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoEgreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdCuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdSubCuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Concepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pago;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSaldo;
    }
}