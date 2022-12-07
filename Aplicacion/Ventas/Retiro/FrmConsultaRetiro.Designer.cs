namespace Aplicacion.Ventas.Retiro
{
    partial class FrmConsultaRetiro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConsultaRetiro));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbConsulta = new System.Windows.Forms.GroupBox();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.btnImprimir = new System.Windows.Forms.ToolStripButton();
            this.lblMsnRetiro = new System.Windows.Forms.Label();
            this.StatusRetiro = new System.Windows.Forms.StatusStrip();
            this.btnInicio = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnAnterior = new System.Windows.Forms.ToolStripDropDownButton();
            this.lblStatusCaja = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnSiguiente = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnFin = new System.Windows.Forms.ToolStripDropDownButton();
            this.dgvRetiros = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Caja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Turno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbCriterios = new System.Windows.Forms.GroupBox();
            this.lblTurno = new System.Windows.Forms.Label();
            this.lblCaja = new System.Windows.Forms.Label();
            this.cbTurno = new System.Windows.Forms.ComboBox();
            this.cbCaja = new System.Windows.Forms.ComboBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblFecha = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnImprimeInforme = new System.Windows.Forms.ToolStripButton();
            this.btnInformeGeneral = new System.Windows.Forms.ToolStripButton();
            this.gbPagos = new System.Windows.Forms.GroupBox();
            this.dgvPagos = new System.Windows.Forms.DataGridView();
            this.IdPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Concepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvPagoIngresos = new System.Windows.Forms.DataGridView();
            this.IdPagoIngreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PagoIngreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorIngreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblMsnIngreso = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripDropDownButton3 = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripDropDownButton4 = new System.Windows.Forms.ToolStripDropDownButton();
            this.dgvIngresos = new System.Windows.Forms.DataGridView();
            this.IdIngreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaIngreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoraIngreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CajaIngreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TurnoIngreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UsuarioIngreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbConsulta.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.StatusRetiro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRetiros)).BeginInit();
            this.gbCriterios.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.gbPagos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPagos)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPagoIngresos)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngresos)).BeginInit();
            this.SuspendLayout();
            // 
            // gbConsulta
            // 
            this.gbConsulta.Controls.Add(this.toolStrip2);
            this.gbConsulta.Controls.Add(this.lblMsnRetiro);
            this.gbConsulta.Controls.Add(this.StatusRetiro);
            this.gbConsulta.Controls.Add(this.dgvRetiros);
            this.gbConsulta.Location = new System.Drawing.Point(479, 97);
            this.gbConsulta.Name = "gbConsulta";
            this.gbConsulta.Size = new System.Drawing.Size(456, 313);
            this.gbConsulta.TabIndex = 3;
            this.gbConsulta.TabStop = false;
            this.gbConsulta.Text = "Retiros";
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnImprimir});
            this.toolStrip2.Location = new System.Drawing.Point(3, 18);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(450, 25);
            this.toolStrip2.TabIndex = 4;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // btnImprimir
            // 
            this.btnImprimir.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnImprimir.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimir.Image")));
            this.btnImprimir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(77, 22);
            this.btnImprimir.Text = "Imprimir";
            // 
            // lblMsnRetiro
            // 
            this.lblMsnRetiro.AutoSize = true;
            this.lblMsnRetiro.Location = new System.Drawing.Point(6, 51);
            this.lblMsnRetiro.Name = "lblMsnRetiro";
            this.lblMsnRetiro.Size = new System.Drawing.Size(11, 16);
            this.lblMsnRetiro.TabIndex = 3;
            this.lblMsnRetiro.Text = ".";
            // 
            // StatusRetiro
            // 
            this.StatusRetiro.BackColor = System.Drawing.Color.LightSteelBlue;
            this.StatusRetiro.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnInicio,
            this.btnAnterior,
            this.lblStatusCaja,
            this.btnSiguiente,
            this.btnFin});
            this.StatusRetiro.Location = new System.Drawing.Point(3, 288);
            this.StatusRetiro.Name = "StatusRetiro";
            this.StatusRetiro.Size = new System.Drawing.Size(450, 22);
            this.StatusRetiro.TabIndex = 2;
            this.StatusRetiro.Text = "Status de Factura";
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
            // 
            // lblStatusCaja
            // 
            this.lblStatusCaja.Name = "lblStatusCaja";
            this.lblStatusCaja.Size = new System.Drawing.Size(30, 17);
            this.lblStatusCaja.Text = "0 / 0";
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
            // 
            // dgvRetiros
            // 
            this.dgvRetiros.AllowUserToAddRows = false;
            this.dgvRetiros.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvRetiros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRetiros.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Fecha,
            this.Hora,
            this.Caja,
            this.Turno,
            this.Usuario});
            this.dgvRetiros.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvRetiros.Location = new System.Drawing.Point(4, 72);
            this.dgvRetiros.Name = "dgvRetiros";
            this.dgvRetiros.RowHeadersVisible = false;
            this.dgvRetiros.Size = new System.Drawing.Size(447, 215);
            this.dgvRetiros.TabIndex = 0;
            this.dgvRetiros.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRetiros_CellClick);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // Fecha
            // 
            this.Fecha.DataPropertyName = "fecha";
            dataGridViewCellStyle5.Format = "d";
            dataGridViewCellStyle5.NullValue = null;
            this.Fecha.DefaultCellStyle = dataGridViewCellStyle5;
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.Width = 80;
            // 
            // Hora
            // 
            this.Hora.DataPropertyName = "hora";
            dataGridViewCellStyle6.Format = "t";
            dataGridViewCellStyle6.NullValue = null;
            this.Hora.DefaultCellStyle = dataGridViewCellStyle6;
            this.Hora.HeaderText = "Hora";
            this.Hora.Name = "Hora";
            this.Hora.Width = 80;
            // 
            // Caja
            // 
            this.Caja.DataPropertyName = "nocaja";
            this.Caja.HeaderText = "Caja";
            this.Caja.Name = "Caja";
            this.Caja.Width = 50;
            // 
            // Turno
            // 
            this.Turno.DataPropertyName = "noturno";
            this.Turno.HeaderText = "Turno";
            this.Turno.Name = "Turno";
            this.Turno.Width = 50;
            // 
            // Usuario
            // 
            this.Usuario.DataPropertyName = "usuario";
            this.Usuario.HeaderText = "Usuario";
            this.Usuario.Name = "Usuario";
            this.Usuario.Width = 180;
            // 
            // gbCriterios
            // 
            this.gbCriterios.Controls.Add(this.lblTurno);
            this.gbCriterios.Controls.Add(this.lblCaja);
            this.gbCriterios.Controls.Add(this.cbTurno);
            this.gbCriterios.Controls.Add(this.cbCaja);
            this.gbCriterios.Controls.Add(this.btnBuscar);
            this.gbCriterios.Controls.Add(this.lblFecha);
            this.gbCriterios.Controls.Add(this.dtpFecha);
            this.gbCriterios.Location = new System.Drawing.Point(12, 35);
            this.gbCriterios.Name = "gbCriterios";
            this.gbCriterios.Size = new System.Drawing.Size(500, 56);
            this.gbCriterios.TabIndex = 4;
            this.gbCriterios.TabStop = false;
            this.gbCriterios.Text = "Criterios";
            // 
            // lblTurno
            // 
            this.lblTurno.AutoSize = true;
            this.lblTurno.Location = new System.Drawing.Point(319, 24);
            this.lblTurno.Name = "lblTurno";
            this.lblTurno.Size = new System.Drawing.Size(43, 16);
            this.lblTurno.TabIndex = 25;
            this.lblTurno.Text = "Turno";
            // 
            // lblCaja
            // 
            this.lblCaja.AutoSize = true;
            this.lblCaja.Location = new System.Drawing.Point(181, 24);
            this.lblCaja.Name = "lblCaja";
            this.lblCaja.Size = new System.Drawing.Size(36, 16);
            this.lblCaja.TabIndex = 24;
            this.lblCaja.Text = "Caja";
            // 
            // cbTurno
            // 
            this.cbTurno.DisplayMember = "numero";
            this.cbTurno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTurno.FormattingEnabled = true;
            this.cbTurno.Location = new System.Drawing.Point(368, 20);
            this.cbTurno.Name = "cbTurno";
            this.cbTurno.Size = new System.Drawing.Size(75, 24);
            this.cbTurno.TabIndex = 23;
            this.cbTurno.ValueMember = "id";
            // 
            // cbCaja
            // 
            this.cbCaja.DisplayMember = "numerocaja";
            this.cbCaja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCaja.FormattingEnabled = true;
            this.cbCaja.Location = new System.Drawing.Point(230, 20);
            this.cbCaja.Name = "cbCaja";
            this.cbCaja.Size = new System.Drawing.Size(75, 24);
            this.cbCaja.TabIndex = 22;
            this.cbCaja.ValueMember = "idcaja";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(453, 20);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(24, 24);
            this.btnBuscar.TabIndex = 1;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(8, 24);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(46, 16);
            this.lblFecha.TabIndex = 2;
            this.lblFecha.Text = "Fecha";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(63, 20);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(106, 22);
            this.dtpFecha.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnImprimeInforme,
            this.btnInformeGeneral});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(950, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnImprimeInforme
            // 
            this.btnImprimeInforme.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnImprimeInforme.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimeInforme.Image")));
            this.btnImprimeInforme.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnImprimeInforme.Name = "btnImprimeInforme";
            this.btnImprimeInforme.Size = new System.Drawing.Size(126, 22);
            this.btnImprimeInforme.Text = "Imprimir Informe";
            this.btnImprimeInforme.Click += new System.EventHandler(this.btnImprimeInforme_Click);
            // 
            // btnInformeGeneral
            // 
            this.btnInformeGeneral.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnInformeGeneral.Image = ((System.Drawing.Image)(resources.GetObject("btnInformeGeneral.Image")));
            this.btnInformeGeneral.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnInformeGeneral.Name = "btnInformeGeneral";
            this.btnInformeGeneral.Size = new System.Drawing.Size(126, 22);
            this.btnInformeGeneral.Text = "Movimiento Caja";
            this.btnInformeGeneral.Click += new System.EventHandler(this.btnInformeGeneral_Click);
            // 
            // gbPagos
            // 
            this.gbPagos.Controls.Add(this.dgvPagos);
            this.gbPagos.Location = new System.Drawing.Point(479, 416);
            this.gbPagos.Name = "gbPagos";
            this.gbPagos.Size = new System.Drawing.Size(456, 159);
            this.gbPagos.TabIndex = 6;
            this.gbPagos.TabStop = false;
            this.gbPagos.Text = "Formas de pago de retiros";
            // 
            // dgvPagos
            // 
            this.dgvPagos.AllowUserToAddRows = false;
            this.dgvPagos.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvPagos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPagos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdPago,
            this.Pago,
            this.Valor,
            this.Concepto});
            this.dgvPagos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvPagos.Location = new System.Drawing.Point(4, 24);
            this.dgvPagos.Name = "dgvPagos";
            this.dgvPagos.RowHeadersVisible = false;
            this.dgvPagos.Size = new System.Drawing.Size(446, 129);
            this.dgvPagos.TabIndex = 0;
            // 
            // IdPago
            // 
            this.IdPago.DataPropertyName = "id";
            this.IdPago.HeaderText = "Id";
            this.IdPago.Name = "IdPago";
            this.IdPago.Visible = false;
            // 
            // Pago
            // 
            this.Pago.DataPropertyName = "pago";
            this.Pago.HeaderText = "Pago";
            this.Pago.Name = "Pago";
            this.Pago.Width = 120;
            // 
            // Valor
            // 
            this.Valor.DataPropertyName = "valor";
            this.Valor.HeaderText = "Valor";
            this.Valor.Name = "Valor";
            this.Valor.Width = 120;
            // 
            // Concepto
            // 
            this.Concepto.DataPropertyName = "concepto";
            this.Concepto.HeaderText = "Concepto";
            this.Concepto.Name = "Concepto";
            this.Concepto.Width = 200;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvPagoIngresos);
            this.groupBox1.Location = new System.Drawing.Point(12, 416);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(456, 159);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Formas de pago de ingresos";
            // 
            // dgvPagoIngresos
            // 
            this.dgvPagoIngresos.AllowUserToAddRows = false;
            this.dgvPagoIngresos.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvPagoIngresos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPagoIngresos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdPagoIngreso,
            this.PagoIngreso,
            this.ValorIngreso});
            this.dgvPagoIngresos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvPagoIngresos.Location = new System.Drawing.Point(4, 24);
            this.dgvPagoIngresos.Name = "dgvPagoIngresos";
            this.dgvPagoIngresos.RowHeadersVisible = false;
            this.dgvPagoIngresos.Size = new System.Drawing.Size(446, 129);
            this.dgvPagoIngresos.TabIndex = 0;
            // 
            // IdPagoIngreso
            // 
            this.IdPagoIngreso.DataPropertyName = "id";
            this.IdPagoIngreso.HeaderText = "Id";
            this.IdPagoIngreso.Name = "IdPagoIngreso";
            this.IdPagoIngreso.Visible = false;
            // 
            // PagoIngreso
            // 
            this.PagoIngreso.DataPropertyName = "pago";
            this.PagoIngreso.HeaderText = "Pago";
            this.PagoIngreso.Name = "PagoIngreso";
            this.PagoIngreso.Width = 200;
            // 
            // ValorIngreso
            // 
            this.ValorIngreso.DataPropertyName = "valor";
            this.ValorIngreso.HeaderText = "Valor";
            this.ValorIngreso.Name = "ValorIngreso";
            this.ValorIngreso.Width = 200;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblMsnIngreso);
            this.groupBox2.Controls.Add(this.statusStrip1);
            this.groupBox2.Controls.Add(this.dgvIngresos);
            this.groupBox2.Location = new System.Drawing.Point(12, 97);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(456, 313);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ingresos";
            // 
            // lblMsnIngreso
            // 
            this.lblMsnIngreso.AutoSize = true;
            this.lblMsnIngreso.Location = new System.Drawing.Point(8, 20);
            this.lblMsnIngreso.Name = "lblMsnIngreso";
            this.lblMsnIngreso.Size = new System.Drawing.Size(11, 16);
            this.lblMsnIngreso.TabIndex = 4;
            this.lblMsnIngreso.Text = ".";
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripDropDownButton2,
            this.toolStripStatusLabel1,
            this.toolStripDropDownButton3,
            this.toolStripDropDownButton4});
            this.statusStrip1.Location = new System.Drawing.Point(3, 288);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(450, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "Status de Factura";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.ShowDropDownArrow = false;
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(20, 20);
            this.toolStripDropDownButton1.Text = "Inicio";
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton2.Image")));
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.ShowDropDownArrow = false;
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(20, 20);
            this.toolStripDropDownButton2.Text = "Anterior";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(30, 17);
            this.toolStripStatusLabel1.Text = "0 / 0";
            // 
            // toolStripDropDownButton3
            // 
            this.toolStripDropDownButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton3.Image")));
            this.toolStripDropDownButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton3.Name = "toolStripDropDownButton3";
            this.toolStripDropDownButton3.ShowDropDownArrow = false;
            this.toolStripDropDownButton3.Size = new System.Drawing.Size(20, 20);
            this.toolStripDropDownButton3.Text = "Siguiente";
            // 
            // toolStripDropDownButton4
            // 
            this.toolStripDropDownButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton4.Image")));
            this.toolStripDropDownButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton4.Name = "toolStripDropDownButton4";
            this.toolStripDropDownButton4.ShowDropDownArrow = false;
            this.toolStripDropDownButton4.Size = new System.Drawing.Size(20, 20);
            this.toolStripDropDownButton4.Text = "Fin";
            // 
            // dgvIngresos
            // 
            this.dgvIngresos.AllowUserToAddRows = false;
            this.dgvIngresos.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvIngresos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIngresos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdIngreso,
            this.FechaIngreso,
            this.HoraIngreso,
            this.CajaIngreso,
            this.TurnoIngreso,
            this.UsuarioIngreso});
            this.dgvIngresos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvIngresos.Location = new System.Drawing.Point(4, 41);
            this.dgvIngresos.Name = "dgvIngresos";
            this.dgvIngresos.RowHeadersVisible = false;
            this.dgvIngresos.Size = new System.Drawing.Size(447, 244);
            this.dgvIngresos.TabIndex = 0;
            this.dgvIngresos.Click += new System.EventHandler(this.dgvIngresos_Click);
            // 
            // IdIngreso
            // 
            this.IdIngreso.DataPropertyName = "id";
            this.IdIngreso.HeaderText = "Id";
            this.IdIngreso.Name = "IdIngreso";
            this.IdIngreso.Visible = false;
            // 
            // FechaIngreso
            // 
            this.FechaIngreso.DataPropertyName = "fecha";
            dataGridViewCellStyle7.Format = "d";
            dataGridViewCellStyle7.NullValue = null;
            this.FechaIngreso.DefaultCellStyle = dataGridViewCellStyle7;
            this.FechaIngreso.HeaderText = "Fecha";
            this.FechaIngreso.Name = "FechaIngreso";
            this.FechaIngreso.Width = 80;
            // 
            // HoraIngreso
            // 
            this.HoraIngreso.DataPropertyName = "hora";
            dataGridViewCellStyle8.Format = "t";
            dataGridViewCellStyle8.NullValue = null;
            this.HoraIngreso.DefaultCellStyle = dataGridViewCellStyle8;
            this.HoraIngreso.HeaderText = "Hora";
            this.HoraIngreso.Name = "HoraIngreso";
            this.HoraIngreso.Width = 80;
            // 
            // CajaIngreso
            // 
            this.CajaIngreso.DataPropertyName = "nocaja";
            this.CajaIngreso.HeaderText = "Caja";
            this.CajaIngreso.Name = "CajaIngreso";
            this.CajaIngreso.Width = 50;
            // 
            // TurnoIngreso
            // 
            this.TurnoIngreso.DataPropertyName = "noturno";
            this.TurnoIngreso.HeaderText = "Turno";
            this.TurnoIngreso.Name = "TurnoIngreso";
            this.TurnoIngreso.Width = 50;
            // 
            // UsuarioIngreso
            // 
            this.UsuarioIngreso.DataPropertyName = "usuario";
            this.UsuarioIngreso.HeaderText = "Usuario";
            this.UsuarioIngreso.Name = "UsuarioIngreso";
            this.UsuarioIngreso.Width = 180;
            // 
            // FrmConsultaRetiro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(950, 584);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gbPagos);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.gbCriterios);
            this.Controls.Add(this.gbConsulta);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmConsultaRetiro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta de movimientos de caja";
            this.Load += new System.EventHandler(this.FrmConsultaRetiro_Load);
            this.gbConsulta.ResumeLayout(false);
            this.gbConsulta.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.StatusRetiro.ResumeLayout(false);
            this.StatusRetiro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRetiros)).EndInit();
            this.gbCriterios.ResumeLayout(false);
            this.gbCriterios.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.gbPagos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPagos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPagoIngresos)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngresos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbConsulta;
        private System.Windows.Forms.StatusStrip StatusRetiro;
        private System.Windows.Forms.ToolStripDropDownButton btnInicio;
        private System.Windows.Forms.ToolStripDropDownButton btnAnterior;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusCaja;
        private System.Windows.Forms.ToolStripDropDownButton btnSiguiente;
        private System.Windows.Forms.ToolStripDropDownButton btnFin;
        private System.Windows.Forms.DataGridView dgvRetiros;
        private System.Windows.Forms.GroupBox gbCriterios;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.ComboBox cbCaja;
        private System.Windows.Forms.ComboBox cbTurno;
        private System.Windows.Forms.Label lblCaja;
        private System.Windows.Forms.Label lblTurno;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hora;
        private System.Windows.Forms.DataGridViewTextBoxColumn Caja;
        private System.Windows.Forms.DataGridViewTextBoxColumn Turno;
        private System.Windows.Forms.DataGridViewTextBoxColumn Usuario;
        private System.Windows.Forms.GroupBox gbPagos;
        private System.Windows.Forms.DataGridView dgvPagos;
        private System.Windows.Forms.ToolStripButton btnImprimeInforme;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvPagoIngresos;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton3;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton4;
        private System.Windows.Forms.DataGridView dgvIngresos;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pago;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Concepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdPagoIngreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn PagoIngreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorIngreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdIngreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaIngreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoraIngreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn CajaIngreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn TurnoIngreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn UsuarioIngreso;
        private System.Windows.Forms.Label lblMsnRetiro;
        private System.Windows.Forms.Label lblMsnIngreso;
        private System.Windows.Forms.ToolStripButton btnInformeGeneral;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton btnImprimir;
    }
}