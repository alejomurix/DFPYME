namespace Aplicacion.Ventas.Cliente.Anticipos
{
    partial class FrmAnticipo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAnticipo));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbCritero = new System.Windows.Forms.GroupBox();
            this.cbCriterio = new System.Windows.Forms.ComboBox();
            this.txtTercero = new System.Windows.Forms.TextBox();
            this.btnBuscarTercero = new System.Windows.Forms.Button();
            this.cbFecha = new System.Windows.Forms.ComboBox();
            this.dtpFecha1 = new System.Windows.Forms.DateTimePicker();
            this.dtpFecha2 = new System.Windows.Forms.DateTimePicker();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.tsBtnListarTodos = new System.Windows.Forms.ToolStripButton();
            this.btnImprimir = new System.Windows.Forms.ToolStripButton();
            this.btnImprimirCopia = new System.Windows.Forms.ToolStripButton();
            this.tsBtnRetiro = new System.Windows.Forms.ToolStripButton();
            this.btnImprimirRetiro = new System.Windows.Forms.ToolStripButton();
            this.tsBtnAnular = new System.Windows.Forms.ToolStripButton();
            this.gbConsulta = new System.Windows.Forms.GroupBox();
            this.dgvAnticipos = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Saldo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusConcepto = new System.Windows.Forms.StatusStrip();
            this.btnInicio = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnAnterior = new System.Windows.Forms.ToolStripDropDownButton();
            this.lblStatusSaldo = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnSiguiente = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnFin = new System.Windows.Forms.ToolStripDropDownButton();
            this.gbCanje = new System.Windows.Forms.GroupBox();
            this.dgvCanje = new System.Windows.Forms.DataGridView();
            this.IdC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaldoC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusCanje = new System.Windows.Forms.StatusStrip();
            this.btnInicioC = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnAnteriorC = new System.Windows.Forms.ToolStripDropDownButton();
            this.lblStatusCanje = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnSiguienteC = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnFinC = new System.Windows.Forms.ToolStripDropDownButton();
            this.gbInformacion = new System.Windows.Forms.GroupBox();
            this.lblPesosSaldo = new System.Windows.Forms.Label();
            this.lblSaldo = new System.Windows.Forms.Label();
            this.txtSaldo = new System.Windows.Forms.TextBox();
            this.gbCritero.SuspendLayout();
            this.tsMenu.SuspendLayout();
            this.gbConsulta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnticipos)).BeginInit();
            this.StatusConcepto.SuspendLayout();
            this.gbCanje.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCanje)).BeginInit();
            this.StatusCanje.SuspendLayout();
            this.gbInformacion.SuspendLayout();
            this.SuspendLayout();
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
            this.gbCritero.Location = new System.Drawing.Point(12, 30);
            this.gbCritero.Name = "gbCritero";
            this.gbCritero.Size = new System.Drawing.Size(1141, 58);
            this.gbCritero.TabIndex = 4;
            this.gbCritero.TabStop = false;
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
            // tsMenu
            // 
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnListarTodos,
            this.btnImprimir,
            this.btnImprimirCopia,
            this.tsBtnRetiro,
            this.btnImprimirRetiro,
            this.tsBtnAnular});
            this.tsMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(1164, 25);
            this.tsMenu.TabIndex = 5;
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
            // btnImprimir
            // 
            this.btnImprimir.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnImprimir.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimir.Image")));
            this.btnImprimir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(129, 22);
            this.btnImprimir.Text = "Imprimir consulta";
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnImprimirCopia
            // 
            this.btnImprimirCopia.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnImprimirCopia.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimirCopia.Image")));
            this.btnImprimirCopia.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnImprimirCopia.Name = "btnImprimirCopia";
            this.btnImprimirCopia.Size = new System.Drawing.Size(113, 22);
            this.btnImprimirCopia.Text = "Imprimir copia";
            this.btnImprimirCopia.ToolTipText = "Imprimir copia";
            this.btnImprimirCopia.Click += new System.EventHandler(this.btnImprimirCopia_Click);
            // 
            // tsBtnRetiro
            // 
            this.tsBtnRetiro.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsBtnRetiro.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnRetiro.Image")));
            this.tsBtnRetiro.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnRetiro.Name = "tsBtnRetiro";
            this.tsBtnRetiro.Size = new System.Drawing.Size(117, 22);
            this.tsBtnRetiro.Text = "Retirar anticipo";
            this.tsBtnRetiro.Click += new System.EventHandler(this.tsBtnRetiro_Click);
            // 
            // btnImprimirRetiro
            // 
            this.btnImprimirRetiro.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnImprimirRetiro.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimirRetiro.Image")));
            this.btnImprimirRetiro.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnImprimirRetiro.Name = "btnImprimirRetiro";
            this.btnImprimirRetiro.Size = new System.Drawing.Size(113, 22);
            this.btnImprimirRetiro.Text = "Imprimir retiro";
            this.btnImprimirRetiro.Click += new System.EventHandler(this.btnImprimirRetiro_Click);
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
            // gbConsulta
            // 
            this.gbConsulta.Controls.Add(this.dgvAnticipos);
            this.gbConsulta.Controls.Add(this.StatusConcepto);
            this.gbConsulta.Location = new System.Drawing.Point(12, 91);
            this.gbConsulta.Name = "gbConsulta";
            this.gbConsulta.Size = new System.Drawing.Size(646, 308);
            this.gbConsulta.TabIndex = 22;
            this.gbConsulta.TabStop = false;
            // 
            // dgvAnticipos
            // 
            this.dgvAnticipos.AllowUserToAddRows = false;
            this.dgvAnticipos.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvAnticipos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAnticipos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Nit,
            this.Nombre,
            this.Numero,
            this.Fecha,
            this.Valor,
            this.Estado,
            this.Saldo});
            this.dgvAnticipos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvAnticipos.Location = new System.Drawing.Point(6, 11);
            this.dgvAnticipos.Name = "dgvAnticipos";
            this.dgvAnticipos.RowHeadersVisible = false;
            this.dgvAnticipos.Size = new System.Drawing.Size(632, 269);
            this.dgvAnticipos.TabIndex = 0;
            this.dgvAnticipos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAnticipos_CellClick);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // Nit
            // 
            this.Nit.DataPropertyName = "nit";
            this.Nit.HeaderText = "Nit";
            this.Nit.Name = "Nit";
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "nombre";
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.Width = 250;
            // 
            // Numero
            // 
            this.Numero.DataPropertyName = "numero";
            this.Numero.HeaderText = "Número";
            this.Numero.Name = "Numero";
            this.Numero.Width = 80;
            // 
            // Fecha
            // 
            this.Fecha.DataPropertyName = "fecha";
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.Width = 80;
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
            // Estado
            // 
            this.Estado.DataPropertyName = "estado";
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.Visible = false;
            // 
            // Saldo
            // 
            this.Saldo.DataPropertyName = "saldo";
            this.Saldo.HeaderText = "Saldo";
            this.Saldo.Name = "Saldo";
            this.Saldo.Visible = false;
            // 
            // StatusConcepto
            // 
            this.StatusConcepto.BackColor = System.Drawing.Color.LightSteelBlue;
            this.StatusConcepto.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnInicio,
            this.btnAnterior,
            this.lblStatusSaldo,
            this.btnSiguiente,
            this.btnFin});
            this.StatusConcepto.Location = new System.Drawing.Point(3, 283);
            this.StatusConcepto.Name = "StatusConcepto";
            this.StatusConcepto.Size = new System.Drawing.Size(640, 22);
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
            // lblStatusSaldo
            // 
            this.lblStatusSaldo.Name = "lblStatusSaldo";
            this.lblStatusSaldo.Size = new System.Drawing.Size(30, 17);
            this.lblStatusSaldo.Text = "0 / 0";
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
            // gbCanje
            // 
            this.gbCanje.Controls.Add(this.dgvCanje);
            this.gbCanje.Controls.Add(this.StatusCanje);
            this.gbCanje.Location = new System.Drawing.Point(664, 91);
            this.gbCanje.Name = "gbCanje";
            this.gbCanje.Size = new System.Drawing.Size(489, 308);
            this.gbCanje.TabIndex = 23;
            this.gbCanje.TabStop = false;
            // 
            // dgvCanje
            // 
            this.dgvCanje.AllowUserToAddRows = false;
            this.dgvCanje.AllowUserToDeleteRows = false;
            this.dgvCanje.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvCanje.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCanje.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdC,
            this.FechaC,
            this.ValorC,
            this.SaldoC});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCanje.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvCanje.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvCanje.Location = new System.Drawing.Point(3, 11);
            this.dgvCanje.Name = "dgvCanje";
            this.dgvCanje.RowHeadersVisible = false;
            this.dgvCanje.Size = new System.Drawing.Size(479, 269);
            this.dgvCanje.TabIndex = 3;
            // 
            // IdC
            // 
            this.IdC.DataPropertyName = "id";
            this.IdC.HeaderText = "Número";
            this.IdC.Name = "IdC";
            this.IdC.Width = 80;
            // 
            // FechaC
            // 
            this.FechaC.DataPropertyName = "fecha";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.FechaC.DefaultCellStyle = dataGridViewCellStyle2;
            this.FechaC.HeaderText = "Fecha";
            this.FechaC.Name = "FechaC";
            this.FechaC.Width = 80;
            // 
            // ValorC
            // 
            this.ValorC.DataPropertyName = "concepto";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.ValorC.DefaultCellStyle = dataGridViewCellStyle3;
            this.ValorC.HeaderText = "Concepto";
            this.ValorC.Name = "ValorC";
            this.ValorC.Width = 195;
            // 
            // SaldoC
            // 
            this.SaldoC.DataPropertyName = "valor";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = null;
            this.SaldoC.DefaultCellStyle = dataGridViewCellStyle4;
            this.SaldoC.HeaderText = "Valor";
            this.SaldoC.Name = "SaldoC";
            // 
            // StatusCanje
            // 
            this.StatusCanje.BackColor = System.Drawing.Color.LightSteelBlue;
            this.StatusCanje.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnInicioC,
            this.btnAnteriorC,
            this.lblStatusCanje,
            this.btnSiguienteC,
            this.btnFinC});
            this.StatusCanje.Location = new System.Drawing.Point(3, 283);
            this.StatusCanje.Name = "StatusCanje";
            this.StatusCanje.Size = new System.Drawing.Size(483, 22);
            this.StatusCanje.TabIndex = 2;
            this.StatusCanje.Text = "Status de Saldos";
            // 
            // btnInicioC
            // 
            this.btnInicioC.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnInicioC.Image = ((System.Drawing.Image)(resources.GetObject("btnInicioC.Image")));
            this.btnInicioC.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnInicioC.Name = "btnInicioC";
            this.btnInicioC.ShowDropDownArrow = false;
            this.btnInicioC.Size = new System.Drawing.Size(20, 20);
            this.btnInicioC.Text = "Inicio";
            this.btnInicioC.Click += new System.EventHandler(this.btnInicioC_Click);
            // 
            // btnAnteriorC
            // 
            this.btnAnteriorC.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAnteriorC.Image = ((System.Drawing.Image)(resources.GetObject("btnAnteriorC.Image")));
            this.btnAnteriorC.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAnteriorC.Name = "btnAnteriorC";
            this.btnAnteriorC.ShowDropDownArrow = false;
            this.btnAnteriorC.Size = new System.Drawing.Size(20, 20);
            this.btnAnteriorC.Text = "Anterior";
            this.btnAnteriorC.Click += new System.EventHandler(this.btnAnteriorC_Click);
            // 
            // lblStatusCanje
            // 
            this.lblStatusCanje.Name = "lblStatusCanje";
            this.lblStatusCanje.Size = new System.Drawing.Size(30, 17);
            this.lblStatusCanje.Text = "0 / 0";
            // 
            // btnSiguienteC
            // 
            this.btnSiguienteC.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSiguienteC.Image = ((System.Drawing.Image)(resources.GetObject("btnSiguienteC.Image")));
            this.btnSiguienteC.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSiguienteC.Name = "btnSiguienteC";
            this.btnSiguienteC.ShowDropDownArrow = false;
            this.btnSiguienteC.Size = new System.Drawing.Size(20, 20);
            this.btnSiguienteC.Text = "Siguiente";
            this.btnSiguienteC.Click += new System.EventHandler(this.btnSiguienteC_Click);
            // 
            // btnFinC
            // 
            this.btnFinC.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFinC.Image = ((System.Drawing.Image)(resources.GetObject("btnFinC.Image")));
            this.btnFinC.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFinC.Name = "btnFinC";
            this.btnFinC.ShowDropDownArrow = false;
            this.btnFinC.Size = new System.Drawing.Size(20, 20);
            this.btnFinC.Text = "Fin";
            this.btnFinC.Click += new System.EventHandler(this.btnFinC_Click);
            // 
            // gbInformacion
            // 
            this.gbInformacion.Controls.Add(this.lblPesosSaldo);
            this.gbInformacion.Controls.Add(this.lblSaldo);
            this.gbInformacion.Controls.Add(this.txtSaldo);
            this.gbInformacion.Location = new System.Drawing.Point(327, 405);
            this.gbInformacion.Name = "gbInformacion";
            this.gbInformacion.Size = new System.Drawing.Size(331, 49);
            this.gbInformacion.TabIndex = 24;
            this.gbInformacion.TabStop = false;
            // 
            // lblPesosSaldo
            // 
            this.lblPesosSaldo.AutoSize = true;
            this.lblPesosSaldo.Location = new System.Drawing.Point(103, 19);
            this.lblPesosSaldo.Name = "lblPesosSaldo";
            this.lblPesosSaldo.Size = new System.Drawing.Size(15, 16);
            this.lblPesosSaldo.TabIndex = 6;
            this.lblPesosSaldo.Text = "$";
            // 
            // lblSaldo
            // 
            this.lblSaldo.AutoSize = true;
            this.lblSaldo.Location = new System.Drawing.Point(13, 20);
            this.lblSaldo.Name = "lblSaldo";
            this.lblSaldo.Size = new System.Drawing.Size(84, 16);
            this.lblSaldo.TabIndex = 5;
            this.lblSaldo.Text = "Saldo Actual";
            // 
            // txtSaldo
            // 
            this.txtSaldo.BackColor = System.Drawing.Color.PaleTurquoise;
            this.txtSaldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.txtSaldo.Location = new System.Drawing.Point(121, 14);
            this.txtSaldo.Name = "txtSaldo";
            this.txtSaldo.ReadOnly = true;
            this.txtSaldo.Size = new System.Drawing.Size(197, 27);
            this.txtSaldo.TabIndex = 0;
            this.txtSaldo.Text = "0";
            this.txtSaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // FrmAnticipo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1164, 465);
            this.Controls.Add(this.gbInformacion);
            this.Controls.Add(this.gbCanje);
            this.Controls.Add(this.gbConsulta);
            this.Controls.Add(this.tsMenu);
            this.Controls.Add(this.gbCritero);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAnticipo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Anticipos de cliente";
            this.Load += new System.EventHandler(this.FrmAnticipo_Load);
            this.gbCritero.ResumeLayout(false);
            this.gbCritero.PerformLayout();
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.gbConsulta.ResumeLayout(false);
            this.gbConsulta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnticipos)).EndInit();
            this.StatusConcepto.ResumeLayout(false);
            this.StatusConcepto.PerformLayout();
            this.gbCanje.ResumeLayout(false);
            this.gbCanje.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCanje)).EndInit();
            this.StatusCanje.ResumeLayout(false);
            this.StatusCanje.PerformLayout();
            this.gbInformacion.ResumeLayout(false);
            this.gbInformacion.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbCritero;
        private System.Windows.Forms.ComboBox cbCriterio;
        private System.Windows.Forms.TextBox txtTercero;
        private System.Windows.Forms.Button btnBuscarTercero;
        private System.Windows.Forms.ComboBox cbFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha1;
        private System.Windows.Forms.DateTimePicker dtpFecha2;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.ToolStripButton tsBtnListarTodos;
        private System.Windows.Forms.ToolStripButton btnImprimir;
        private System.Windows.Forms.ToolStripButton tsBtnAnular;
        private System.Windows.Forms.GroupBox gbConsulta;
        private System.Windows.Forms.DataGridView dgvAnticipos;
        private System.Windows.Forms.StatusStrip StatusConcepto;
        private System.Windows.Forms.ToolStripDropDownButton btnInicio;
        private System.Windows.Forms.ToolStripDropDownButton btnAnterior;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusSaldo;
        private System.Windows.Forms.ToolStripDropDownButton btnSiguiente;
        private System.Windows.Forms.ToolStripDropDownButton btnFin;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Saldo;
        private System.Windows.Forms.GroupBox gbCanje;
        private System.Windows.Forms.DataGridView dgvCanje;
        private System.Windows.Forms.StatusStrip StatusCanje;
        private System.Windows.Forms.ToolStripDropDownButton btnInicioC;
        private System.Windows.Forms.ToolStripDropDownButton btnAnteriorC;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusCanje;
        private System.Windows.Forms.ToolStripDropDownButton btnSiguienteC;
        private System.Windows.Forms.ToolStripDropDownButton btnFinC;
        private System.Windows.Forms.GroupBox gbInformacion;
        private System.Windows.Forms.Label lblPesosSaldo;
        private System.Windows.Forms.Label lblSaldo;
        private System.Windows.Forms.TextBox txtSaldo;
        private System.Windows.Forms.ToolStripButton tsBtnRetiro;
        private System.Windows.Forms.ToolStripButton btnImprimirCopia;
        private System.Windows.Forms.ToolStripButton btnImprimirRetiro;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdC;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaC;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorC;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaldoC;
    }
}