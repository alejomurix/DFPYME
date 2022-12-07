namespace Aplicacion.Compras.Egreso
{
    partial class frmConsultarEgreso
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsultarEgreso));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsMenuConsulta = new System.Windows.Forms.ToolStrip();
            this.tsBtnListarTodos = new System.Windows.Forms.ToolStripButton();
            this.tsBtnEditar = new System.Windows.Forms.ToolStripButton();
            this.tsBtnCopia = new System.Windows.Forms.ToolStripButton();
            this.tsBtnImprimirConsulta = new System.Windows.Forms.ToolStripButton();
            this.tsBtnAnular = new System.Windows.Forms.ToolStripButton();
            this.tsBtnSalir = new System.Windows.Forms.ToolStripButton();
            this.gbCriterio = new System.Windows.Forms.GroupBox();
            this.btnBuscarBeneficiario = new System.Windows.Forms.Button();
            this.chkAnulado = new System.Windows.Forms.CheckBox();
            this.dtpFecha1 = new System.Windows.Forms.DateTimePicker();
            this.cbFecha = new System.Windows.Forms.ComboBox();
            this.cbCriterio = new System.Windows.Forms.ComboBox();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.btnBuscarFe = new System.Windows.Forms.Button();
            this.lblFecha = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.gbConsulta = new System.Windows.Forms.GroupBox();
            this.btnEditarEgreso = new System.Windows.Forms.Button();
            this.dgvEgreso = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Beneficia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdBeneficio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusCaja = new System.Windows.Forms.StatusStrip();
            this.btnInicio = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnAnterior = new System.Windows.Forms.ToolStripDropDownButton();
            this.lblStatusEgreso = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnSiguiente = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnFin = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnAnular = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnEditarConcepto = new System.Windows.Forms.Button();
            this.dgvCuentas = new System.Windows.Forms.DataGridView();
            this.IdC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Concepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbBeneficiario = new System.Windows.Forms.GroupBox();
            this.lblNit = new System.Windows.Forms.Label();
            this.txtNit = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.gbRetenciones = new System.Windows.Forms.GroupBox();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnRetencion = new System.Windows.Forms.Button();
            this.dgvRetenciones = new System.Windows.Forms.DataGridView();
            this.IdRetencion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ConceptoRetencion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tarifa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorRetencion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblPesosTotal = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTotalRetencion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtValorPagado = new System.Windows.Forms.TextBox();
            this.gbFormasPago = new System.Windows.Forms.GroupBox();
            this.btnEditarPago = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTransaccion = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCheque = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtEfectivo = new System.Windows.Forms.TextBox();
            this.gbValoresEgreso = new System.Windows.Forms.GroupBox();
            this.tsMenuConsulta.SuspendLayout();
            this.gbCriterio.SuspendLayout();
            this.gbConsulta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEgreso)).BeginInit();
            this.StatusCaja.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuentas)).BeginInit();
            this.gbBeneficiario.SuspendLayout();
            this.gbRetenciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRetenciones)).BeginInit();
            this.gbFormasPago.SuspendLayout();
            this.gbValoresEgreso.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMenuConsulta
            // 
            this.tsMenuConsulta.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnListarTodos,
            this.tsBtnEditar,
            this.tsBtnCopia,
            this.tsBtnImprimirConsulta,
            this.tsBtnAnular,
            this.tsBtnSalir});
            this.tsMenuConsulta.Location = new System.Drawing.Point(0, 0);
            this.tsMenuConsulta.Name = "tsMenuConsulta";
            this.tsMenuConsulta.Size = new System.Drawing.Size(950, 25);
            this.tsMenuConsulta.TabIndex = 0;
            this.tsMenuConsulta.Text = "toolStrip1";
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
            // tsBtnEditar
            // 
            this.tsBtnEditar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsBtnEditar.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnEditar.Image")));
            this.tsBtnEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnEditar.Name = "tsBtnEditar";
            this.tsBtnEditar.Size = new System.Drawing.Size(62, 22);
            this.tsBtnEditar.Text = "Editar";
            this.tsBtnEditar.Visible = false;
            this.tsBtnEditar.Click += new System.EventHandler(this.tsBtnEditar_Click);
            // 
            // tsBtnCopia
            // 
            this.tsBtnCopia.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsBtnCopia.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnCopia.Image")));
            this.tsBtnCopia.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnCopia.Name = "tsBtnCopia";
            this.tsBtnCopia.Size = new System.Drawing.Size(115, 22);
            this.tsBtnCopia.Text = "Imprimir Copia";
            this.tsBtnCopia.Click += new System.EventHandler(this.tsBtnCopia_Click);
            // 
            // tsBtnImprimirConsulta
            // 
            this.tsBtnImprimirConsulta.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsBtnImprimirConsulta.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnImprimirConsulta.Image")));
            this.tsBtnImprimirConsulta.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnImprimirConsulta.Name = "tsBtnImprimirConsulta";
            this.tsBtnImprimirConsulta.Size = new System.Drawing.Size(131, 22);
            this.tsBtnImprimirConsulta.Text = "Imprimir Consulta";
            this.tsBtnImprimirConsulta.Click += new System.EventHandler(this.tsBtnImprimirConsulta_Click);
            // 
            // tsBtnAnular
            // 
            this.tsBtnAnular.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsBtnAnular.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnAnular.Image")));
            this.tsBtnAnular.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnAnular.Name = "tsBtnAnular";
            this.tsBtnAnular.Size = new System.Drawing.Size(65, 22);
            this.tsBtnAnular.Text = "Anular";
            this.tsBtnAnular.Click += new System.EventHandler(this.btnAnular_Click);
            // 
            // tsBtnSalir
            // 
            this.tsBtnSalir.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnSalir.Image")));
            this.tsBtnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnSalir.Name = "tsBtnSalir";
            this.tsBtnSalir.Size = new System.Drawing.Size(49, 22);
            this.tsBtnSalir.Text = "Salir";
            this.tsBtnSalir.Click += new System.EventHandler(this.tsBtnSalir_Click);
            // 
            // gbCriterio
            // 
            this.gbCriterio.Controls.Add(this.btnBuscarBeneficiario);
            this.gbCriterio.Controls.Add(this.chkAnulado);
            this.gbCriterio.Controls.Add(this.dtpFecha1);
            this.gbCriterio.Controls.Add(this.cbFecha);
            this.gbCriterio.Controls.Add(this.cbCriterio);
            this.gbCriterio.Controls.Add(this.txtNumero);
            this.gbCriterio.Controls.Add(this.lblName);
            this.gbCriterio.Controls.Add(this.btnBuscarFe);
            this.gbCriterio.Controls.Add(this.lblFecha);
            this.gbCriterio.Controls.Add(this.dtpFecha);
            this.gbCriterio.Location = new System.Drawing.Point(12, 26);
            this.gbCriterio.Name = "gbCriterio";
            this.gbCriterio.Size = new System.Drawing.Size(920, 63);
            this.gbCriterio.TabIndex = 1;
            this.gbCriterio.TabStop = false;
            this.gbCriterio.Text = "Criterios";
            // 
            // btnBuscarBeneficiario
            // 
            this.btnBuscarBeneficiario.Enabled = false;
            this.btnBuscarBeneficiario.Location = new System.Drawing.Point(350, 23);
            this.btnBuscarBeneficiario.Name = "btnBuscarBeneficiario";
            this.btnBuscarBeneficiario.Size = new System.Drawing.Size(25, 24);
            this.btnBuscarBeneficiario.TabIndex = 12;
            this.btnBuscarBeneficiario.Text = "...";
            this.btnBuscarBeneficiario.UseVisualStyleBackColor = true;
            this.btnBuscarBeneficiario.Click += new System.EventHandler(this.btnBuscarBeneficiario_Click);
            // 
            // chkAnulado
            // 
            this.chkAnulado.AutoSize = true;
            this.chkAnulado.Location = new System.Drawing.Point(854, 28);
            this.chkAnulado.Name = "chkAnulado";
            this.chkAnulado.Size = new System.Drawing.Size(15, 14);
            this.chkAnulado.TabIndex = 9;
            this.chkAnulado.UseVisualStyleBackColor = true;
            this.chkAnulado.Visible = false;
            // 
            // dtpFecha1
            // 
            this.dtpFecha1.Enabled = false;
            this.dtpFecha1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha1.Location = new System.Drawing.Point(679, 23);
            this.dtpFecha1.Name = "dtpFecha1";
            this.dtpFecha1.Size = new System.Drawing.Size(107, 22);
            this.dtpFecha1.TabIndex = 8;
            // 
            // cbFecha
            // 
            this.cbFecha.DisplayMember = "Nombre";
            this.cbFecha.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFecha.Enabled = false;
            this.cbFecha.FormattingEnabled = true;
            this.cbFecha.Location = new System.Drawing.Point(428, 22);
            this.cbFecha.Name = "cbFecha";
            this.cbFecha.Size = new System.Drawing.Size(121, 24);
            this.cbFecha.TabIndex = 7;
            this.cbFecha.ValueMember = "Id";
            this.cbFecha.SelectionChangeCommitted += new System.EventHandler(this.cbFecha_SelectionChangeCommitted);
            // 
            // cbCriterio
            // 
            this.cbCriterio.DisplayMember = "Nombre";
            this.cbCriterio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCriterio.FormattingEnabled = true;
            this.cbCriterio.Location = new System.Drawing.Point(12, 23);
            this.cbCriterio.Name = "cbCriterio";
            this.cbCriterio.Size = new System.Drawing.Size(121, 24);
            this.cbCriterio.TabIndex = 6;
            this.cbCriterio.ValueMember = "Id";
            this.cbCriterio.SelectionChangeCommitted += new System.EventHandler(this.cbCriterio_SelectionChangeCommitted);
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(214, 24);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(134, 22);
            this.txtNumero.TabIndex = 0;
            this.txtNumero.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumero_KeyPress);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(139, 27);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(56, 16);
            this.lblName.TabIndex = 4;
            this.lblName.Text = "Número";
            // 
            // btnBuscarFe
            // 
            this.btnBuscarFe.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscarFe.Image")));
            this.btnBuscarFe.Location = new System.Drawing.Point(801, 22);
            this.btnBuscarFe.Name = "btnBuscarFe";
            this.btnBuscarFe.Size = new System.Drawing.Size(24, 24);
            this.btnBuscarFe.TabIndex = 3;
            this.btnBuscarFe.UseVisualStyleBackColor = true;
            this.btnBuscarFe.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(377, 27);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(46, 16);
            this.lblFecha.TabIndex = 5;
            this.lblFecha.Text = "Fecha";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Enabled = false;
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(557, 23);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(107, 22);
            this.dtpFecha.TabIndex = 2;
            // 
            // gbConsulta
            // 
            this.gbConsulta.Controls.Add(this.btnEditarEgreso);
            this.gbConsulta.Controls.Add(this.dgvEgreso);
            this.gbConsulta.Controls.Add(this.StatusCaja);
            this.gbConsulta.Location = new System.Drawing.Point(12, 156);
            this.gbConsulta.Name = "gbConsulta";
            this.gbConsulta.Size = new System.Drawing.Size(380, 311);
            this.gbConsulta.TabIndex = 2;
            this.gbConsulta.TabStop = false;
            this.gbConsulta.Text = "Datos del Egreso";
            // 
            // btnEditarEgreso
            // 
            this.btnEditarEgreso.Image = ((System.Drawing.Image)(resources.GetObject("btnEditarEgreso.Image")));
            this.btnEditarEgreso.Location = new System.Drawing.Point(352, 10);
            this.btnEditarEgreso.Name = "btnEditarEgreso";
            this.btnEditarEgreso.Size = new System.Drawing.Size(25, 22);
            this.btnEditarEgreso.TabIndex = 2;
            this.btnEditarEgreso.UseVisualStyleBackColor = true;
            this.btnEditarEgreso.Click += new System.EventHandler(this.btnEditarEgreso_Click);
            // 
            // dgvEgreso
            // 
            this.dgvEgreso.AllowUserToAddRows = false;
            this.dgvEgreso.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvEgreso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEgreso.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Numero,
            this.Fecha,
            this.Valor,
            this.Estado,
            this.Tipo,
            this.Beneficia,
            this.IdBeneficio});
            this.dgvEgreso.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvEgreso.Location = new System.Drawing.Point(3, 33);
            this.dgvEgreso.Name = "dgvEgreso";
            this.dgvEgreso.RowHeadersVisible = false;
            this.dgvEgreso.Size = new System.Drawing.Size(372, 252);
            this.dgvEgreso.TabIndex = 0;
            this.dgvEgreso.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEgreso_CellClick);
            this.dgvEgreso.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgvEgreso_KeyUp);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // Numero
            // 
            this.Numero.DataPropertyName = "numero";
            this.Numero.HeaderText = "Numero";
            this.Numero.Name = "Numero";
            this.Numero.Width = 120;
            // 
            // Fecha
            // 
            this.Fecha.DataPropertyName = "fecha";
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.Width = 120;
            // 
            // Valor
            // 
            this.Valor.DataPropertyName = "total";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "C0";
            dataGridViewCellStyle1.NullValue = null;
            this.Valor.DefaultCellStyle = dataGridViewCellStyle1;
            this.Valor.HeaderText = "Valor";
            this.Valor.Name = "Valor";
            this.Valor.Visible = false;
            this.Valor.Width = 117;
            // 
            // Estado
            // 
            this.Estado.DataPropertyName = "estado";
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.Width = 120;
            // 
            // Tipo
            // 
            this.Tipo.DataPropertyName = "tipo_benefico";
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.Name = "Tipo";
            this.Tipo.Visible = false;
            // 
            // Beneficia
            // 
            this.Beneficia.DataPropertyName = "benefico";
            this.Beneficia.HeaderText = "Beneficia";
            this.Beneficia.Name = "Beneficia";
            this.Beneficia.Visible = false;
            // 
            // IdBeneficio
            // 
            this.IdBeneficio.DataPropertyName = "tipo_benefico";
            this.IdBeneficio.HeaderText = "IdBeneficio";
            this.IdBeneficio.Name = "IdBeneficio";
            this.IdBeneficio.Visible = false;
            // 
            // StatusCaja
            // 
            this.StatusCaja.BackColor = System.Drawing.Color.LightSteelBlue;
            this.StatusCaja.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnInicio,
            this.btnAnterior,
            this.lblStatusEgreso,
            this.btnSiguiente,
            this.btnFin});
            this.StatusCaja.Location = new System.Drawing.Point(3, 286);
            this.StatusCaja.Name = "StatusCaja";
            this.StatusCaja.Size = new System.Drawing.Size(374, 22);
            this.StatusCaja.TabIndex = 1;
            this.StatusCaja.Text = "Status de Factura";
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
            // lblStatusEgreso
            // 
            this.lblStatusEgreso.Name = "lblStatusEgreso";
            this.lblStatusEgreso.Size = new System.Drawing.Size(30, 17);
            this.lblStatusEgreso.Text = "0 / 0";
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
            // btnAnular
            // 
            this.btnAnular.Image = ((System.Drawing.Image)(resources.GetObject("btnAnular.Image")));
            this.btnAnular.Location = new System.Drawing.Point(875, 22);
            this.btnAnular.Name = "btnAnular";
            this.btnAnular.Size = new System.Drawing.Size(24, 24);
            this.btnAnular.TabIndex = 17;
            this.btnAnular.UseVisualStyleBackColor = true;
            this.btnAnular.Visible = false;
            this.btnAnular.Click += new System.EventHandler(this.btnAnular_Click_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnEditarConcepto);
            this.groupBox1.Controls.Add(this.dgvCuentas);
            this.groupBox1.Location = new System.Drawing.Point(404, 156);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(534, 154);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Conceptos del Egreso";
            // 
            // btnEditarConcepto
            // 
            this.btnEditarConcepto.Image = ((System.Drawing.Image)(resources.GetObject("btnEditarConcepto.Image")));
            this.btnEditarConcepto.Location = new System.Drawing.Point(503, 10);
            this.btnEditarConcepto.Name = "btnEditarConcepto";
            this.btnEditarConcepto.Size = new System.Drawing.Size(25, 22);
            this.btnEditarConcepto.TabIndex = 3;
            this.btnEditarConcepto.UseVisualStyleBackColor = true;
            this.btnEditarConcepto.Click += new System.EventHandler(this.btnEditarConcepto_Click);
            // 
            // dgvCuentas
            // 
            this.dgvCuentas.AllowUserToAddRows = false;
            this.dgvCuentas.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvCuentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCuentas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdC,
            this.Codigo,
            this.Concepto,
            this.ValorC});
            this.dgvCuentas.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvCuentas.Location = new System.Drawing.Point(5, 33);
            this.dgvCuentas.Name = "dgvCuentas";
            this.dgvCuentas.RowHeadersVisible = false;
            this.dgvCuentas.Size = new System.Drawing.Size(523, 116);
            this.dgvCuentas.TabIndex = 0;
            // 
            // IdC
            // 
            this.IdC.DataPropertyName = "id";
            this.IdC.HeaderText = "Id";
            this.IdC.Name = "IdC";
            this.IdC.Visible = false;
            // 
            // Codigo
            // 
            this.Codigo.HeaderText = "Código";
            this.Codigo.Name = "Codigo";
            this.Codigo.Visible = false;
            this.Codigo.Width = 65;
            // 
            // Concepto
            // 
            this.Concepto.DataPropertyName = "concepto";
            this.Concepto.HeaderText = "Concepto";
            this.Concepto.Name = "Concepto";
            this.Concepto.Width = 400;
            // 
            // ValorC
            // 
            this.ValorC.DataPropertyName = "valor";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.ValorC.DefaultCellStyle = dataGridViewCellStyle2;
            this.ValorC.HeaderText = "Valor";
            this.ValorC.Name = "ValorC";
            // 
            // gbBeneficiario
            // 
            this.gbBeneficiario.Controls.Add(this.lblNit);
            this.gbBeneficiario.Controls.Add(this.txtNit);
            this.gbBeneficiario.Controls.Add(this.btnAnular);
            this.gbBeneficiario.Controls.Add(this.lblNombre);
            this.gbBeneficiario.Controls.Add(this.txtNombre);
            this.gbBeneficiario.Location = new System.Drawing.Point(12, 90);
            this.gbBeneficiario.Name = "gbBeneficiario";
            this.gbBeneficiario.Size = new System.Drawing.Size(920, 65);
            this.gbBeneficiario.TabIndex = 19;
            this.gbBeneficiario.TabStop = false;
            this.gbBeneficiario.Text = "Datos del Tercero";
            // 
            // lblNit
            // 
            this.lblNit.AutoSize = true;
            this.lblNit.Location = new System.Drawing.Point(14, 27);
            this.lblNit.Name = "lblNit";
            this.lblNit.Size = new System.Drawing.Size(68, 16);
            this.lblNit.TabIndex = 3;
            this.lblNit.Text = "C.C. o NIT";
            // 
            // txtNit
            // 
            this.txtNit.Location = new System.Drawing.Point(91, 24);
            this.txtNit.Name = "txtNit";
            this.txtNit.ReadOnly = true;
            this.txtNit.Size = new System.Drawing.Size(199, 22);
            this.txtNit.TabIndex = 2;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(311, 27);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(57, 16);
            this.lblNombre.TabIndex = 1;
            this.lblNombre.Text = "Nombre";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(374, 24);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.ReadOnly = true;
            this.txtNombre.Size = new System.Drawing.Size(495, 22);
            this.txtNombre.TabIndex = 0;
            // 
            // gbRetenciones
            // 
            this.gbRetenciones.Controls.Add(this.btnEliminar);
            this.gbRetenciones.Controls.Add(this.btnRetencion);
            this.gbRetenciones.Controls.Add(this.dgvRetenciones);
            this.gbRetenciones.Location = new System.Drawing.Point(404, 313);
            this.gbRetenciones.Name = "gbRetenciones";
            this.gbRetenciones.Size = new System.Drawing.Size(534, 154);
            this.gbRetenciones.TabIndex = 20;
            this.gbRetenciones.TabStop = false;
            this.gbRetenciones.Text = "Retenciones Aplicadas";
            // 
            // btnEliminar
            // 
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.Location = new System.Drawing.Point(503, 13);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(25, 24);
            this.btnEliminar.TabIndex = 5;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnRetencion
            // 
            this.btnRetencion.Image = ((System.Drawing.Image)(resources.GetObject("btnRetencion.Image")));
            this.btnRetencion.Location = new System.Drawing.Point(477, 13);
            this.btnRetencion.Name = "btnRetencion";
            this.btnRetencion.Size = new System.Drawing.Size(25, 24);
            this.btnRetencion.TabIndex = 1;
            this.btnRetencion.UseVisualStyleBackColor = true;
            this.btnRetencion.Click += new System.EventHandler(this.btnRetencion_Click);
            // 
            // dgvRetenciones
            // 
            this.dgvRetenciones.AllowUserToAddRows = false;
            this.dgvRetenciones.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvRetenciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRetenciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdRetencion,
            this.ConceptoRetencion,
            this.Tarifa,
            this.ValorRetencion});
            this.dgvRetenciones.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvRetenciones.Location = new System.Drawing.Point(5, 39);
            this.dgvRetenciones.Name = "dgvRetenciones";
            this.dgvRetenciones.RowHeadersVisible = false;
            this.dgvRetenciones.Size = new System.Drawing.Size(523, 110);
            this.dgvRetenciones.TabIndex = 0;
            // 
            // IdRetencion
            // 
            this.IdRetencion.DataPropertyName = "id";
            this.IdRetencion.HeaderText = "Id";
            this.IdRetencion.Name = "IdRetencion";
            this.IdRetencion.Visible = false;
            // 
            // ConceptoRetencion
            // 
            this.ConceptoRetencion.DataPropertyName = "concepto";
            this.ConceptoRetencion.HeaderText = "Concepto";
            this.ConceptoRetencion.Name = "ConceptoRetencion";
            this.ConceptoRetencion.Width = 320;
            // 
            // Tarifa
            // 
            this.Tarifa.DataPropertyName = "tarifa";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Tarifa.DefaultCellStyle = dataGridViewCellStyle3;
            this.Tarifa.HeaderText = "Tarifa %";
            this.Tarifa.Name = "Tarifa";
            this.Tarifa.Width = 90;
            // 
            // ValorRetencion
            // 
            this.ValorRetencion.DataPropertyName = "valor";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = null;
            this.ValorRetencion.DefaultCellStyle = dataGridViewCellStyle4;
            this.ValorRetencion.HeaderText = "Valor";
            this.ValorRetencion.Name = "ValorRetencion";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(7, 28);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(137, 16);
            this.lblTotal.TabIndex = 23;
            this.lblTotal.Text = "VALOR EGRESO : ";
            // 
            // lblPesosTotal
            // 
            this.lblPesosTotal.AutoSize = true;
            this.lblPesosTotal.Location = new System.Drawing.Point(145, 28);
            this.lblPesosTotal.Name = "lblPesosTotal";
            this.lblPesosTotal.Size = new System.Drawing.Size(15, 16);
            this.lblPesosTotal.TabIndex = 21;
            this.lblPesosTotal.Text = "$";
            // 
            // txtTotal
            // 
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(163, 25);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(125, 22);
            this.txtTotal.TabIndex = 22;
            this.txtTotal.Text = "0";
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(294, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 16);
            this.label1.TabIndex = 26;
            this.label1.Text = "TOTAL RETENCIÓN : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(452, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 16);
            this.label2.TabIndex = 24;
            this.label2.Text = "$";
            // 
            // txtTotalRetencion
            // 
            this.txtTotalRetencion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalRetencion.Location = new System.Drawing.Point(470, 25);
            this.txtTotalRetencion.Name = "txtTotalRetencion";
            this.txtTotalRetencion.ReadOnly = true;
            this.txtTotalRetencion.Size = new System.Drawing.Size(125, 22);
            this.txtTotalRetencion.TabIndex = 25;
            this.txtTotalRetencion.Text = "0";
            this.txtTotalRetencion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(615, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 16);
            this.label3.TabIndex = 29;
            this.label3.Text = "VALOR PAGADO: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(748, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 16);
            this.label4.TabIndex = 27;
            this.label4.Text = "$";
            // 
            // txtValorPagado
            // 
            this.txtValorPagado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValorPagado.Location = new System.Drawing.Point(766, 25);
            this.txtValorPagado.Name = "txtValorPagado";
            this.txtValorPagado.ReadOnly = true;
            this.txtValorPagado.Size = new System.Drawing.Size(125, 22);
            this.txtValorPagado.TabIndex = 28;
            this.txtValorPagado.Text = "0";
            this.txtValorPagado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // gbFormasPago
            // 
            this.gbFormasPago.Controls.Add(this.btnEditarPago);
            this.gbFormasPago.Controls.Add(this.label5);
            this.gbFormasPago.Controls.Add(this.label6);
            this.gbFormasPago.Controls.Add(this.txtTransaccion);
            this.gbFormasPago.Controls.Add(this.label7);
            this.gbFormasPago.Controls.Add(this.label8);
            this.gbFormasPago.Controls.Add(this.txtCheque);
            this.gbFormasPago.Controls.Add(this.label9);
            this.gbFormasPago.Controls.Add(this.label10);
            this.gbFormasPago.Controls.Add(this.txtEfectivo);
            this.gbFormasPago.Location = new System.Drawing.Point(12, 533);
            this.gbFormasPago.Name = "gbFormasPago";
            this.gbFormasPago.Size = new System.Drawing.Size(926, 61);
            this.gbFormasPago.TabIndex = 30;
            this.gbFormasPago.TabStop = false;
            this.gbFormasPago.Text = "Formas de Pago";
            // 
            // btnEditarPago
            // 
            this.btnEditarPago.Image = ((System.Drawing.Image)(resources.GetObject("btnEditarPago.Image")));
            this.btnEditarPago.Location = new System.Drawing.Point(895, 24);
            this.btnEditarPago.Name = "btnEditarPago";
            this.btnEditarPago.Size = new System.Drawing.Size(25, 22);
            this.btnEditarPago.TabIndex = 49;
            this.btnEditarPago.UseVisualStyleBackColor = true;
            this.btnEditarPago.Click += new System.EventHandler(this.btnEditarPago_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(615, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 16);
            this.label5.TabIndex = 48;
            this.label5.Text = "TRANSACCIÓN: ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(748, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 16);
            this.label6.TabIndex = 46;
            this.label6.Text = "$";
            // 
            // txtTransaccion
            // 
            this.txtTransaccion.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtTransaccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTransaccion.Location = new System.Drawing.Point(766, 24);
            this.txtTransaccion.Name = "txtTransaccion";
            this.txtTransaccion.ReadOnly = true;
            this.txtTransaccion.Size = new System.Drawing.Size(125, 22);
            this.txtTransaccion.TabIndex = 47;
            this.txtTransaccion.Text = "0";
            this.txtTransaccion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(367, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 16);
            this.label7.TabIndex = 45;
            this.label7.Text = "CHEQUE:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(452, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(15, 16);
            this.label8.TabIndex = 43;
            this.label8.Text = "$";
            // 
            // txtCheque
            // 
            this.txtCheque.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtCheque.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCheque.Location = new System.Drawing.Point(470, 24);
            this.txtCheque.Name = "txtCheque";
            this.txtCheque.ReadOnly = true;
            this.txtCheque.Size = new System.Drawing.Size(125, 22);
            this.txtCheque.TabIndex = 44;
            this.txtCheque.Text = "0";
            this.txtCheque.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(49, 27);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 16);
            this.label9.TabIndex = 42;
            this.label9.Text = "EFECTIVO: ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(145, 27);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(15, 16);
            this.label10.TabIndex = 40;
            this.label10.Text = "$";
            // 
            // txtEfectivo
            // 
            this.txtEfectivo.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtEfectivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEfectivo.Location = new System.Drawing.Point(163, 24);
            this.txtEfectivo.Name = "txtEfectivo";
            this.txtEfectivo.ReadOnly = true;
            this.txtEfectivo.Size = new System.Drawing.Size(133, 22);
            this.txtEfectivo.TabIndex = 41;
            this.txtEfectivo.Text = "0";
            this.txtEfectivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // gbValoresEgreso
            // 
            this.gbValoresEgreso.Controls.Add(this.lblTotal);
            this.gbValoresEgreso.Controls.Add(this.txtTotal);
            this.gbValoresEgreso.Controls.Add(this.label3);
            this.gbValoresEgreso.Controls.Add(this.label4);
            this.gbValoresEgreso.Controls.Add(this.lblPesosTotal);
            this.gbValoresEgreso.Controls.Add(this.txtValorPagado);
            this.gbValoresEgreso.Controls.Add(this.label1);
            this.gbValoresEgreso.Controls.Add(this.txtTotalRetencion);
            this.gbValoresEgreso.Controls.Add(this.label2);
            this.gbValoresEgreso.Location = new System.Drawing.Point(12, 470);
            this.gbValoresEgreso.Name = "gbValoresEgreso";
            this.gbValoresEgreso.Size = new System.Drawing.Size(926, 61);
            this.gbValoresEgreso.TabIndex = 31;
            this.gbValoresEgreso.TabStop = false;
            this.gbValoresEgreso.Text = "Valores del Egreso";
            // 
            // frmConsultarEgreso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(950, 615);
            this.Controls.Add(this.gbValoresEgreso);
            this.Controls.Add(this.gbFormasPago);
            this.Controls.Add(this.gbRetenciones);
            this.Controls.Add(this.gbBeneficiario);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tsMenuConsulta);
            this.Controls.Add(this.gbCriterio);
            this.Controls.Add(this.gbConsulta);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConsultarEgreso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta de Egresos";
            this.Load += new System.EventHandler(this.FrmConsultaEgreso_Load);
            this.tsMenuConsulta.ResumeLayout(false);
            this.tsMenuConsulta.PerformLayout();
            this.gbCriterio.ResumeLayout(false);
            this.gbCriterio.PerformLayout();
            this.gbConsulta.ResumeLayout(false);
            this.gbConsulta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEgreso)).EndInit();
            this.StatusCaja.ResumeLayout(false);
            this.StatusCaja.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuentas)).EndInit();
            this.gbBeneficiario.ResumeLayout(false);
            this.gbBeneficiario.PerformLayout();
            this.gbRetenciones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRetenciones)).EndInit();
            this.gbFormasPago.ResumeLayout(false);
            this.gbFormasPago.PerformLayout();
            this.gbValoresEgreso.ResumeLayout(false);
            this.gbValoresEgreso.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMenuConsulta;
        private System.Windows.Forms.ToolStripButton tsBtnListarTodos;
        private System.Windows.Forms.ToolStripButton tsBtnEditar;
        private System.Windows.Forms.ToolStripButton tsBtnSalir;
        private System.Windows.Forms.GroupBox gbCriterio;
        private System.Windows.Forms.Button btnBuscarFe;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.GroupBox gbConsulta;
        private System.Windows.Forms.StatusStrip StatusCaja;
        private System.Windows.Forms.ToolStripDropDownButton btnInicio;
        private System.Windows.Forms.ToolStripDropDownButton btnAnterior;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusEgreso;
        private System.Windows.Forms.ToolStripDropDownButton btnSiguiente;
        private System.Windows.Forms.ToolStripDropDownButton btnFin;
        private System.Windows.Forms.DataGridView dgvEgreso;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvCuentas;
        private System.Windows.Forms.ComboBox cbCriterio;
        private System.Windows.Forms.ComboBox cbFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha1;
        private System.Windows.Forms.Button btnAnular;
        private System.Windows.Forms.CheckBox chkAnulado;
        private System.Windows.Forms.ToolStripButton tsBtnCopia;
        private System.Windows.Forms.GroupBox gbBeneficiario;
        private System.Windows.Forms.Label lblNit;
        private System.Windows.Forms.TextBox txtNit;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Button btnBuscarBeneficiario;
        private System.Windows.Forms.GroupBox gbRetenciones;
        private System.Windows.Forms.DataGridView dgvRetenciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdRetencion;
        private System.Windows.Forms.DataGridViewTextBoxColumn ConceptoRetencion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tarifa;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorRetencion;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdC;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Concepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorC;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblPesosTotal;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTotalRetencion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtValorPagado;
        private System.Windows.Forms.GroupBox gbFormasPago;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTransaccion;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCheque;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtEfectivo;
        private System.Windows.Forms.GroupBox gbValoresEgreso;
        private System.Windows.Forms.ToolStripButton tsBtnAnular;
        private System.Windows.Forms.ToolStripButton tsBtnImprimirConsulta;
        private System.Windows.Forms.Button btnEditarEgreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Beneficia;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdBeneficio;
        private System.Windows.Forms.Button btnEditarConcepto;
        private System.Windows.Forms.Button btnRetencion;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnEditarPago;
    }
}