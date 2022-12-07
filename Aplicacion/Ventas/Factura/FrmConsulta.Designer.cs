namespace Aplicacion.Ventas.Factura
{
    partial class FrmConsulta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConsulta));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbCritero = new System.Windows.Forms.GroupBox();
            this.cbEstado = new System.Windows.Forms.ComboBox();
            this.cbCriterio = new System.Windows.Forms.ComboBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.btnBuscarCodigo = new System.Windows.Forms.Button();
            this.cbFecha = new System.Windows.Forms.ComboBox();
            this.dtpFecha1 = new System.Windows.Forms.DateTimePicker();
            this.dtpFecha2 = new System.Windows.Forms.DateTimePicker();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.tsBtnEditar = new System.Windows.Forms.ToolStripButton();
            this.tsBtnRealizarAbono = new System.Windows.Forms.ToolStripButton();
            this.tsBtnAbonoGeneral = new System.Windows.Forms.ToolStripButton();
            this.tsBtnCopia = new System.Windows.Forms.ToolStripButton();
            this.tsBtnVerPagos = new System.Windows.Forms.ToolStripButton();
            this.tsBtnSeleccionar = new System.Windows.Forms.ToolStripButton();
            this.tsBtnAnular = new System.Windows.Forms.ToolStripButton();
            this.tsBtnSalir = new System.Windows.Forms.ToolStripButton();
            this.tsSaldoCliente = new System.Windows.Forms.ToolStripButton();
            this.tsBtnSaltoTotalCredito = new System.Windows.Forms.ToolStripButton();
            this.gbFactura = new System.Windows.Forms.GroupBox();
            this.dgvFactura = new System.Windows.Forms.DataGridView();
            this.IdFactura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Proveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstadoFactura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaIngreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaLimite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DesctoFactura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Activa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdResolucionDian = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusFactura = new System.Windows.Forms.StatusStrip();
            this.btnInicio = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnAnterior = new System.Windows.Forms.ToolStripDropDownButton();
            this.lblStatusFactura = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnSiguiente = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnFin = new System.Windows.Forms.ToolStripDropDownButton();
            this.gbListadoArticulos = new System.Windows.Forms.GroupBox();
            this.PanelMenuArticulo = new System.Windows.Forms.Panel();
            this.tsMenuArticulo = new System.Windows.Forms.ToolStrip();
            this.tsBtnNuevoArticulo = new System.Windows.Forms.ToolStripButton();
            this.dgvListaArticulos = new Aplicacion.Ventas.Factura.DataGridViewPlus();
            this.IdProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Articulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdMedida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Medida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Color = new System.Windows.Forms.DataGridViewImageColumn();
            this.IdMarca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorMenosDescto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Iva = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorIva = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalMasIva = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Retorno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorReal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbResumen = new System.Windows.Forms.GroupBox();
            this.btnInfoRete = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTotalPago = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblPesosTotalPago = new System.Windows.Forms.Label();
            this.txtSaldoDevolucion = new System.Windows.Forms.TextBox();
            this.txtImpstoBolsas = new System.Windows.Forms.TextBox();
            this.txtTotalPago = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtRetencion = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAbono = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtResta = new System.Windows.Forms.TextBox();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.lblPesosSubTotal = new System.Windows.Forms.Label();
            this.txtSubTotal = new System.Windows.Forms.TextBox();
            this.lblIva = new System.Windows.Forms.Label();
            this.lblPesosIva = new System.Windows.Forms.Label();
            this.txtIva = new System.Windows.Forms.TextBox();
            this.lblDescuento = new System.Windows.Forms.Label();
            this.lblPesoDescuento = new System.Windows.Forms.Label();
            this.txtDescuento = new System.Windows.Forms.TextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblPesosTotal = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.txtIco = new System.Windows.Forms.TextBox();
            this.btnCambio = new System.Windows.Forms.Button();
            this.gbCritero.SuspendLayout();
            this.tsMenu.SuspendLayout();
            this.gbFactura.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFactura)).BeginInit();
            this.StatusFactura.SuspendLayout();
            this.gbListadoArticulos.SuspendLayout();
            this.PanelMenuArticulo.SuspendLayout();
            this.tsMenuArticulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaArticulos)).BeginInit();
            this.gbResumen.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbCritero
            // 
            this.gbCritero.Controls.Add(this.cbEstado);
            this.gbCritero.Controls.Add(this.cbCriterio);
            this.gbCritero.Controls.Add(this.txtCodigo);
            this.gbCritero.Controls.Add(this.btnBuscarCodigo);
            this.gbCritero.Controls.Add(this.cbFecha);
            this.gbCritero.Controls.Add(this.dtpFecha1);
            this.gbCritero.Controls.Add(this.dtpFecha2);
            this.gbCritero.Controls.Add(this.btnBuscar);
            this.gbCritero.Location = new System.Drawing.Point(5, 28);
            this.gbCritero.Name = "gbCritero";
            this.gbCritero.Size = new System.Drawing.Size(1099, 58);
            this.gbCritero.TabIndex = 2;
            this.gbCritero.TabStop = false;
            this.gbCritero.Text = "Criterio Consulta";
            // 
            // cbEstado
            // 
            this.cbEstado.DisplayMember = "Nombre";
            this.cbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEstado.Enabled = false;
            this.cbEstado.FormattingEnabled = true;
            this.cbEstado.Location = new System.Drawing.Point(142, 22);
            this.cbEstado.Name = "cbEstado";
            this.cbEstado.Size = new System.Drawing.Size(109, 24);
            this.cbEstado.TabIndex = 4;
            this.cbEstado.ValueMember = "Id";
            // 
            // cbCriterio
            // 
            this.cbCriterio.DisplayMember = "Nombre";
            this.cbCriterio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCriterio.FormattingEnabled = true;
            this.cbCriterio.Location = new System.Drawing.Point(10, 22);
            this.cbCriterio.Name = "cbCriterio";
            this.cbCriterio.Size = new System.Drawing.Size(117, 24);
            this.cbCriterio.TabIndex = 0;
            this.cbCriterio.ValueMember = "Id";
            this.cbCriterio.SelectionChangeCommitted += new System.EventHandler(this.cbCriterio_SelectionChangeCommitted);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(266, 23);
            this.txtCodigo.MaxLength = 30;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(287, 22);
            this.txtCodigo.TabIndex = 1;
            this.txtCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigo_KeyPress);
            // 
            // btnBuscarCodigo
            // 
            this.btnBuscarCodigo.Enabled = false;
            this.btnBuscarCodigo.Location = new System.Drawing.Point(562, 22);
            this.btnBuscarCodigo.Name = "btnBuscarCodigo";
            this.btnBuscarCodigo.Size = new System.Drawing.Size(25, 23);
            this.btnBuscarCodigo.TabIndex = 2;
            this.btnBuscarCodigo.Text = "...";
            this.btnBuscarCodigo.UseVisualStyleBackColor = true;
            this.btnBuscarCodigo.Click += new System.EventHandler(this.btnBuscarCodigo_Click);
            // 
            // cbFecha
            // 
            this.cbFecha.DisplayMember = "Nombre";
            this.cbFecha.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFecha.Enabled = false;
            this.cbFecha.FormattingEnabled = true;
            this.cbFecha.Location = new System.Drawing.Point(600, 21);
            this.cbFecha.Name = "cbFecha";
            this.cbFecha.Size = new System.Drawing.Size(132, 24);
            this.cbFecha.TabIndex = 5;
            this.cbFecha.ValueMember = "Id";
            this.cbFecha.SelectionChangeCommitted += new System.EventHandler(this.cbFecha_SelectionChangeCommitted);
            // 
            // dtpFecha1
            // 
            this.dtpFecha1.CustomFormat = "dd/MM/yyyy";
            this.dtpFecha1.Enabled = false;
            this.dtpFecha1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecha1.Location = new System.Drawing.Point(748, 22);
            this.dtpFecha1.Name = "dtpFecha1";
            this.dtpFecha1.Size = new System.Drawing.Size(99, 22);
            this.dtpFecha1.TabIndex = 7;
            // 
            // dtpFecha2
            // 
            this.dtpFecha2.CustomFormat = "dd/MM/yyyy";
            this.dtpFecha2.Enabled = false;
            this.dtpFecha2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecha2.Location = new System.Drawing.Point(858, 22);
            this.dtpFecha2.Name = "dtpFecha2";
            this.dtpFecha2.Size = new System.Drawing.Size(95, 22);
            this.dtpFecha2.TabIndex = 8;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(975, 21);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(25, 23);
            this.btnBuscar.TabIndex = 9;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // tsMenu
            // 
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnEditar,
            this.tsBtnRealizarAbono,
            this.tsBtnAbonoGeneral,
            this.tsBtnCopia,
            this.tsBtnVerPagos,
            this.tsBtnSeleccionar,
            this.tsBtnAnular,
            this.tsBtnSalir,
            this.tsSaldoCliente,
            this.tsBtnSaltoTotalCredito});
            this.tsMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(1136, 25);
            this.tsMenu.TabIndex = 3;
            this.tsMenu.Text = "toolStrip1";
            // 
            // tsBtnEditar
            // 
            this.tsBtnEditar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsBtnEditar.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnEditar.Image")));
            this.tsBtnEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnEditar.Name = "tsBtnEditar";
            this.tsBtnEditar.Size = new System.Drawing.Size(87, 22);
            this.tsBtnEditar.Text = "Editar [F2]";
            this.tsBtnEditar.Click += new System.EventHandler(this.tsBtnEditar_Click);
            // 
            // tsBtnRealizarAbono
            // 
            this.tsBtnRealizarAbono.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsBtnRealizarAbono.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnRealizarAbono.Image")));
            this.tsBtnRealizarAbono.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnRealizarAbono.Name = "tsBtnRealizarAbono";
            this.tsBtnRealizarAbono.Size = new System.Drawing.Size(142, 22);
            this.tsBtnRealizarAbono.Text = "Realizar Abono [F3]";
            this.tsBtnRealizarAbono.Click += new System.EventHandler(this.tsBtnRealizarAbono_Click);
            // 
            // tsBtnAbonoGeneral
            // 
            this.tsBtnAbonoGeneral.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsBtnAbonoGeneral.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnAbonoGeneral.Image")));
            this.tsBtnAbonoGeneral.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnAbonoGeneral.Name = "tsBtnAbonoGeneral";
            this.tsBtnAbonoGeneral.Size = new System.Drawing.Size(146, 22);
            this.tsBtnAbonoGeneral.Text = "Abono a Cliente [F4]";
            this.tsBtnAbonoGeneral.Click += new System.EventHandler(this.tsBtnAbonoGeneral_Click);
            // 
            // tsBtnCopia
            // 
            this.tsBtnCopia.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsBtnCopia.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnCopia.Image")));
            this.tsBtnCopia.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnCopia.Name = "tsBtnCopia";
            this.tsBtnCopia.Size = new System.Drawing.Size(140, 22);
            this.tsBtnCopia.Text = "Imprimir Copia [F5]";
            this.tsBtnCopia.Click += new System.EventHandler(this.tsBtnCopia_Click);
            // 
            // tsBtnVerPagos
            // 
            this.tsBtnVerPagos.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsBtnVerPagos.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnVerPagos.Image")));
            this.tsBtnVerPagos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnVerPagos.Name = "tsBtnVerPagos";
            this.tsBtnVerPagos.Size = new System.Drawing.Size(112, 22);
            this.tsBtnVerPagos.Text = "Ver Pagos [F6]";
            this.tsBtnVerPagos.ToolTipText = "Ver Pagos";
            this.tsBtnVerPagos.Click += new System.EventHandler(this.tsBtnVerPagos_Click);
            // 
            // tsBtnSeleccionar
            // 
            this.tsBtnSeleccionar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsBtnSeleccionar.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnSeleccionar.Image")));
            this.tsBtnSeleccionar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnSeleccionar.Name = "tsBtnSeleccionar";
            this.tsBtnSeleccionar.Size = new System.Drawing.Size(126, 22);
            this.tsBtnSeleccionar.Text = "Seleccionar [F12]";
            this.tsBtnSeleccionar.Visible = false;
            this.tsBtnSeleccionar.Click += new System.EventHandler(this.tsBtnSeleccionar_Click);
            // 
            // tsBtnAnular
            // 
            this.tsBtnAnular.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnAnular.Image")));
            this.tsBtnAnular.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnAnular.Name = "tsBtnAnular";
            this.tsBtnAnular.Size = new System.Drawing.Size(104, 22);
            this.tsBtnAnular.Text = "Anular Factura";
            this.tsBtnAnular.Click += new System.EventHandler(this.tsBtnAnular_Click);
            // 
            // tsBtnSalir
            // 
            this.tsBtnSalir.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnSalir.Image")));
            this.tsBtnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnSalir.Name = "tsBtnSalir";
            this.tsBtnSalir.Size = new System.Drawing.Size(80, 22);
            this.tsBtnSalir.Text = "Salir [ESC]";
            this.tsBtnSalir.Click += new System.EventHandler(this.tsBtnSalir_Click);
            // 
            // tsSaldoCliente
            // 
            this.tsSaldoCliente.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsSaldoCliente.Image = ((System.Drawing.Image)(resources.GetObject("tsSaldoCliente.Image")));
            this.tsSaldoCliente.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsSaldoCliente.Name = "tsSaldoCliente";
            this.tsSaldoCliente.Size = new System.Drawing.Size(23, 22);
            this.tsSaldoCliente.Text = "Ver Saldo Total Cliente [F3]";
            this.tsSaldoCliente.Visible = false;
            // 
            // tsBtnSaltoTotalCredito
            // 
            this.tsBtnSaltoTotalCredito.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnSaltoTotalCredito.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnSaltoTotalCredito.Image")));
            this.tsBtnSaltoTotalCredito.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnSaltoTotalCredito.Name = "tsBtnSaltoTotalCredito";
            this.tsBtnSaltoTotalCredito.Size = new System.Drawing.Size(23, 22);
            this.tsBtnSaltoTotalCredito.Text = "Ver Saldo Total Créditos [F4]";
            this.tsBtnSaltoTotalCredito.Visible = false;
            // 
            // gbFactura
            // 
            this.gbFactura.Controls.Add(this.dgvFactura);
            this.gbFactura.Controls.Add(this.StatusFactura);
            this.gbFactura.Location = new System.Drawing.Point(5, 86);
            this.gbFactura.Name = "gbFactura";
            this.gbFactura.Size = new System.Drawing.Size(1120, 194);
            this.gbFactura.TabIndex = 4;
            this.gbFactura.TabStop = false;
            // 
            // dgvFactura
            // 
            this.dgvFactura.AllowUserToAddRows = false;
            this.dgvFactura.AllowUserToDeleteRows = false;
            this.dgvFactura.AllowUserToResizeColumns = false;
            this.dgvFactura.AllowUserToResizeRows = false;
            this.dgvFactura.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvFactura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFactura.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdFactura,
            this.Nit,
            this.Proveedor,
            this.IdEstado,
            this.EstadoFactura,
            this.Numero,
            this.FechaIngreso,
            this.Hora,
            this.FechaLimite,
            this.Estacion,
            this.Descuento,
            this.DesctoFactura,
            this.Activa,
            this.IdResolucionDian});
            this.dgvFactura.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvFactura.Location = new System.Drawing.Point(7, 13);
            this.dgvFactura.Name = "dgvFactura";
            this.dgvFactura.RowHeadersVisible = false;
            this.dgvFactura.Size = new System.Drawing.Size(1110, 155);
            this.dgvFactura.TabIndex = 0;
            this.dgvFactura.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFactura_CellClick);
            this.dgvFactura.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFactura_CellDoubleClick);
            // 
            // IdFactura
            // 
            this.IdFactura.DataPropertyName = "id";
            this.IdFactura.HeaderText = "IdFactura";
            this.IdFactura.Name = "IdFactura";
            this.IdFactura.Visible = false;
            // 
            // Nit
            // 
            this.Nit.DataPropertyName = "nit";
            this.Nit.HeaderText = "Nit";
            this.Nit.Name = "Nit";
            this.Nit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Nit.Width = 120;
            // 
            // Proveedor
            // 
            this.Proveedor.DataPropertyName = "Cliente";
            this.Proveedor.HeaderText = "Cliente";
            this.Proveedor.Name = "Proveedor";
            this.Proveedor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Proveedor.Width = 280;
            // 
            // IdEstado
            // 
            this.IdEstado.DataPropertyName = "idestado";
            this.IdEstado.HeaderText = "Id";
            this.IdEstado.Name = "IdEstado";
            this.IdEstado.Visible = false;
            // 
            // EstadoFactura
            // 
            this.EstadoFactura.DataPropertyName = "estado";
            this.EstadoFactura.HeaderText = "Estado";
            this.EstadoFactura.Name = "EstadoFactura";
            this.EstadoFactura.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Numero
            // 
            this.Numero.DataPropertyName = "numero";
            this.Numero.HeaderText = "Número";
            this.Numero.Name = "Numero";
            this.Numero.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Numero.Width = 110;
            // 
            // FechaIngreso
            // 
            this.FechaIngreso.DataPropertyName = "fecha";
            this.FechaIngreso.HeaderText = "Fecha";
            this.FechaIngreso.Name = "FechaIngreso";
            this.FechaIngreso.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FechaIngreso.Width = 115;
            // 
            // Hora
            // 
            this.Hora.DataPropertyName = "hora";
            dataGridViewCellStyle1.Format = "t";
            dataGridViewCellStyle1.NullValue = null;
            this.Hora.DefaultCellStyle = dataGridViewCellStyle1;
            this.Hora.HeaderText = "Hora";
            this.Hora.Name = "Hora";
            // 
            // FechaLimite
            // 
            this.FechaLimite.DataPropertyName = "limite";
            this.FechaLimite.HeaderText = "Fecha Limite";
            this.FechaLimite.Name = "FechaLimite";
            this.FechaLimite.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FechaLimite.Width = 115;
            // 
            // Estacion
            // 
            this.Estacion.DataPropertyName = "estacion";
            this.Estacion.HeaderText = "Estacion";
            this.Estacion.Name = "Estacion";
            this.Estacion.Width = 150;
            // 
            // Descuento
            // 
            this.Descuento.DataPropertyName = "descto";
            this.Descuento.HeaderText = "Descto";
            this.Descuento.Name = "Descuento";
            this.Descuento.Visible = false;
            // 
            // DesctoFactura
            // 
            this.DesctoFactura.DataPropertyName = "descuento";
            this.DesctoFactura.HeaderText = "Descuento";
            this.DesctoFactura.Name = "DesctoFactura";
            this.DesctoFactura.Visible = false;
            // 
            // Activa
            // 
            this.Activa.DataPropertyName = "activa";
            this.Activa.HeaderText = "Activa";
            this.Activa.Name = "Activa";
            this.Activa.Visible = false;
            // 
            // IdResolucionDian
            // 
            this.IdResolucionDian.DataPropertyName = "id_resolucion_dian";
            this.IdResolucionDian.HeaderText = "IdResolucionDian";
            this.IdResolucionDian.Name = "IdResolucionDian";
            this.IdResolucionDian.Visible = false;
            // 
            // StatusFactura
            // 
            this.StatusFactura.BackColor = System.Drawing.Color.LightSteelBlue;
            this.StatusFactura.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnInicio,
            this.btnAnterior,
            this.lblStatusFactura,
            this.btnSiguiente,
            this.btnFin});
            this.StatusFactura.Location = new System.Drawing.Point(3, 169);
            this.StatusFactura.Name = "StatusFactura";
            this.StatusFactura.Size = new System.Drawing.Size(1114, 22);
            this.StatusFactura.TabIndex = 1;
            this.StatusFactura.Text = "Status de Factura";
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
            // lblStatusFactura
            // 
            this.lblStatusFactura.Name = "lblStatusFactura";
            this.lblStatusFactura.Size = new System.Drawing.Size(30, 17);
            this.lblStatusFactura.Text = "0 / 0";
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
            // gbListadoArticulos
            // 
            this.gbListadoArticulos.Controls.Add(this.PanelMenuArticulo);
            this.gbListadoArticulos.Controls.Add(this.dgvListaArticulos);
            this.gbListadoArticulos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.gbListadoArticulos.Location = new System.Drawing.Point(8, 285);
            this.gbListadoArticulos.Name = "gbListadoArticulos";
            this.gbListadoArticulos.Size = new System.Drawing.Size(1117, 217);
            this.gbListadoArticulos.TabIndex = 7;
            this.gbListadoArticulos.TabStop = false;
            this.gbListadoArticulos.Text = "Listado de Articulos";
            // 
            // PanelMenuArticulo
            // 
            this.PanelMenuArticulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelMenuArticulo.Controls.Add(this.tsMenuArticulo);
            this.PanelMenuArticulo.Location = new System.Drawing.Point(1067, 19);
            this.PanelMenuArticulo.Name = "PanelMenuArticulo";
            this.PanelMenuArticulo.Size = new System.Drawing.Size(38, 190);
            this.PanelMenuArticulo.TabIndex = 3;
            // 
            // tsMenuArticulo
            // 
            this.tsMenuArticulo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnNuevoArticulo});
            this.tsMenuArticulo.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.tsMenuArticulo.Location = new System.Drawing.Point(0, 0);
            this.tsMenuArticulo.Name = "tsMenuArticulo";
            this.tsMenuArticulo.Size = new System.Drawing.Size(36, 111);
            this.tsMenuArticulo.TabIndex = 0;
            this.tsMenuArticulo.Text = "Menu de Registro";
            // 
            // tsBtnNuevoArticulo
            // 
            this.tsBtnNuevoArticulo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnNuevoArticulo.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnNuevoArticulo.Image")));
            this.tsBtnNuevoArticulo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnNuevoArticulo.Name = "tsBtnNuevoArticulo";
            this.tsBtnNuevoArticulo.Size = new System.Drawing.Size(34, 20);
            this.tsBtnNuevoArticulo.Text = "Anular Factura [F2]";
            this.tsBtnNuevoArticulo.Visible = false;
            this.tsBtnNuevoArticulo.Click += new System.EventHandler(this.tsBtnNuevoArticulo_Click);
            // 
            // dgvListaArticulos
            // 
            this.dgvListaArticulos.AllowUserToAddRows = false;
            this.dgvListaArticulos.AllowUserToResizeColumns = false;
            this.dgvListaArticulos.AllowUserToResizeRows = false;
            this.dgvListaArticulos.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvListaArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaArticulos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdProducto,
            this.Codigo,
            this.Articulo,
            this.Unidad,
            this.IdMedida,
            this.Medida,
            this.IdColor,
            this.Color,
            this.IdMarca,
            this.Cantidad,
            this.Valor,
            this.Descto,
            this.ValorMenosDescto,
            this.Iva,
            this.ValorIva,
            this.TotalMasIva,
            this.Ico,
            this.Total,
            this.Retorno,
            this.ValorReal});
            this.dgvListaArticulos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvListaArticulos.Location = new System.Drawing.Point(5, 19);
            this.dgvListaArticulos.Name = "dgvListaArticulos";
            this.dgvListaArticulos.RowHeadersVisible = false;
            this.dgvListaArticulos.Size = new System.Drawing.Size(1062, 190);
            this.dgvListaArticulos.TabIndex = 0;
            // 
            // IdProducto
            // 
            this.IdProducto.DataPropertyName = "Id";
            this.IdProducto.HeaderText = "Id";
            this.IdProducto.Name = "IdProducto";
            this.IdProducto.Visible = false;
            // 
            // Codigo
            // 
            this.Codigo.DataPropertyName = "Codigo";
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            this.Codigo.Width = 78;
            // 
            // Articulo
            // 
            this.Articulo.DataPropertyName = "Articulo";
            this.Articulo.HeaderText = "Articulo";
            this.Articulo.Name = "Articulo";
            this.Articulo.ReadOnly = true;
            this.Articulo.Width = 300;
            // 
            // Unidad
            // 
            this.Unidad.DataPropertyName = "Unidad";
            this.Unidad.HeaderText = "Unidad";
            this.Unidad.Name = "Unidad";
            this.Unidad.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Unidad.Visible = false;
            this.Unidad.Width = 55;
            // 
            // IdMedida
            // 
            this.IdMedida.DataPropertyName = "IdMedida";
            this.IdMedida.HeaderText = "IdMedida";
            this.IdMedida.Name = "IdMedida";
            this.IdMedida.Visible = false;
            // 
            // Medida
            // 
            this.Medida.DataPropertyName = "Medida";
            this.Medida.HeaderText = "Medida";
            this.Medida.Name = "Medida";
            this.Medida.Visible = false;
            this.Medida.Width = 60;
            // 
            // IdColor
            // 
            this.IdColor.DataPropertyName = "IdColor";
            this.IdColor.HeaderText = "IdColor";
            this.IdColor.Name = "IdColor";
            this.IdColor.Visible = false;
            // 
            // Color
            // 
            this.Color.DataPropertyName = "Color";
            this.Color.HeaderText = "Color";
            this.Color.Name = "Color";
            this.Color.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Color.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Color.Visible = false;
            this.Color.Width = 60;
            // 
            // IdMarca
            // 
            this.IdMarca.DataPropertyName = "IdMarca";
            this.IdMarca.HeaderText = "IdMarca";
            this.IdMarca.Name = "IdMarca";
            this.IdMarca.Visible = false;
            // 
            // Cantidad
            // 
            this.Cantidad.DataPropertyName = "Cantidad";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.Cantidad.DefaultCellStyle = dataGridViewCellStyle2;
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            this.Cantidad.Width = 98;
            // 
            // Valor
            // 
            this.Valor.DataPropertyName = "ValorUnitario";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.Valor.DefaultCellStyle = dataGridViewCellStyle3;
            this.Valor.HeaderText = "Valor Unitario";
            this.Valor.Name = "Valor";
            this.Valor.Width = 112;
            // 
            // Descto
            // 
            this.Descto.DataPropertyName = "Descuento";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.NullValue = null;
            this.Descto.DefaultCellStyle = dataGridViewCellStyle4;
            this.Descto.HeaderText = "Descto";
            this.Descto.Name = "Descto";
            this.Descto.ReadOnly = true;
            this.Descto.Width = 57;
            // 
            // ValorMenosDescto
            // 
            this.ValorMenosDescto.DataPropertyName = "ValorMenosDescto";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.ValorMenosDescto.DefaultCellStyle = dataGridViewCellStyle5;
            this.ValorMenosDescto.HeaderText = "Valor - Descto";
            this.ValorMenosDescto.Name = "ValorMenosDescto";
            this.ValorMenosDescto.ReadOnly = true;
            this.ValorMenosDescto.Width = 116;
            // 
            // Iva
            // 
            this.Iva.DataPropertyName = "Iva";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Iva.DefaultCellStyle = dataGridViewCellStyle6;
            this.Iva.HeaderText = "Iva";
            this.Iva.Name = "Iva";
            this.Iva.ReadOnly = true;
            this.Iva.Width = 43;
            // 
            // ValorIva
            // 
            this.ValorIva.DataPropertyName = "ValorIva";
            this.ValorIva.HeaderText = "ValorIva";
            this.ValorIva.Name = "ValorIva";
            this.ValorIva.Visible = false;
            // 
            // TotalMasIva
            // 
            this.TotalMasIva.DataPropertyName = "TotalMasIva";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            dataGridViewCellStyle7.NullValue = null;
            this.TotalMasIva.DefaultCellStyle = dataGridViewCellStyle7;
            this.TotalMasIva.HeaderText = "Valor + Iva";
            this.TotalMasIva.Name = "TotalMasIva";
            this.TotalMasIva.ReadOnly = true;
            this.TotalMasIva.Width = 120;
            // 
            // Ico
            // 
            this.Ico.DataPropertyName = "Ico";
            this.Ico.HeaderText = "Ico";
            this.Ico.Name = "Ico";
            this.Ico.Visible = false;
            // 
            // Total
            // 
            this.Total.DataPropertyName = "Valor";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N2";
            dataGridViewCellStyle8.NullValue = null;
            this.Total.DefaultCellStyle = dataGridViewCellStyle8;
            this.Total.HeaderText = "Valor Total";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            this.Total.Width = 130;
            // 
            // Retorno
            // 
            this.Retorno.DataPropertyName = "retorno";
            this.Retorno.HeaderText = "Retorno";
            this.Retorno.Name = "Retorno";
            this.Retorno.Visible = false;
            // 
            // ValorReal
            // 
            this.ValorReal.DataPropertyName = "ValorReal";
            this.ValorReal.HeaderText = "ValorReal";
            this.ValorReal.Name = "ValorReal";
            this.ValorReal.Visible = false;
            // 
            // gbResumen
            // 
            this.gbResumen.Controls.Add(this.btnInfoRete);
            this.gbResumen.Controls.Add(this.label6);
            this.gbResumen.Controls.Add(this.label5);
            this.gbResumen.Controls.Add(this.lblTotalPago);
            this.gbResumen.Controls.Add(this.label7);
            this.gbResumen.Controls.Add(this.label8);
            this.gbResumen.Controls.Add(this.lblPesosTotalPago);
            this.gbResumen.Controls.Add(this.txtSaldoDevolucion);
            this.gbResumen.Controls.Add(this.txtImpstoBolsas);
            this.gbResumen.Controls.Add(this.txtTotalPago);
            this.gbResumen.Controls.Add(this.label10);
            this.gbResumen.Controls.Add(this.txtRetencion);
            this.gbResumen.Controls.Add(this.label9);
            this.gbResumen.Controls.Add(this.label1);
            this.gbResumen.Controls.Add(this.label2);
            this.gbResumen.Controls.Add(this.txtAbono);
            this.gbResumen.Controls.Add(this.label3);
            this.gbResumen.Controls.Add(this.label4);
            this.gbResumen.Controls.Add(this.txtResta);
            this.gbResumen.Controls.Add(this.lblSubtotal);
            this.gbResumen.Controls.Add(this.lblPesosSubTotal);
            this.gbResumen.Controls.Add(this.txtSubTotal);
            this.gbResumen.Controls.Add(this.lblIva);
            this.gbResumen.Controls.Add(this.lblPesosIva);
            this.gbResumen.Controls.Add(this.txtIva);
            this.gbResumen.Controls.Add(this.lblDescuento);
            this.gbResumen.Controls.Add(this.lblPesoDescuento);
            this.gbResumen.Controls.Add(this.txtDescuento);
            this.gbResumen.Controls.Add(this.lblTotal);
            this.gbResumen.Controls.Add(this.lblPesosTotal);
            this.gbResumen.Controls.Add(this.txtTotal);
            this.gbResumen.Location = new System.Drawing.Point(7, 506);
            this.gbResumen.Name = "gbResumen";
            this.gbResumen.Size = new System.Drawing.Size(1118, 87);
            this.gbResumen.TabIndex = 8;
            this.gbResumen.TabStop = false;
            this.gbResumen.Text = "Resumen de Factura";
            // 
            // btnInfoRete
            // 
            this.btnInfoRete.FlatAppearance.BorderSize = 0;
            this.btnInfoRete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInfoRete.Image = ((System.Drawing.Image)(resources.GetObject("btnInfoRete.Image")));
            this.btnInfoRete.Location = new System.Drawing.Point(621, 52);
            this.btnInfoRete.Name = "btnInfoRete";
            this.btnInfoRete.Size = new System.Drawing.Size(25, 23);
            this.btnInfoRete.TabIndex = 47;
            this.btnInfoRete.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(653, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 16);
            this.label6.TabIndex = 46;
            this.label6.Text = "DEVOL. : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(778, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(15, 16);
            this.label5.TabIndex = 44;
            this.label5.Text = "$";
            // 
            // lblTotalPago
            // 
            this.lblTotalPago.AutoSize = true;
            this.lblTotalPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPago.Location = new System.Drawing.Point(653, 57);
            this.lblTotalPago.Name = "lblTotalPago";
            this.lblTotalPago.Size = new System.Drawing.Size(115, 16);
            this.lblTotalPago.TabIndex = 46;
            this.lblTotalPago.Text = "TOTAL PAGO : ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(419, 57);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 16);
            this.label7.TabIndex = 24;
            this.label7.Text = "RETE.: ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(495, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(15, 16);
            this.label8.TabIndex = 25;
            this.label8.Text = "$";
            // 
            // lblPesosTotalPago
            // 
            this.lblPesosTotalPago.AutoSize = true;
            this.lblPesosTotalPago.Location = new System.Drawing.Point(778, 56);
            this.lblPesosTotalPago.Name = "lblPesosTotalPago";
            this.lblPesosTotalPago.Size = new System.Drawing.Size(15, 16);
            this.lblPesosTotalPago.TabIndex = 44;
            this.lblPesosTotalPago.Text = "$";
            // 
            // txtSaldoDevolucion
            // 
            this.txtSaldoDevolucion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSaldoDevolucion.Location = new System.Drawing.Point(795, 22);
            this.txtSaldoDevolucion.Name = "txtSaldoDevolucion";
            this.txtSaldoDevolucion.ReadOnly = true;
            this.txtSaldoDevolucion.Size = new System.Drawing.Size(105, 22);
            this.txtSaldoDevolucion.TabIndex = 23;
            this.txtSaldoDevolucion.Text = "0";
            this.txtSaldoDevolucion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtImpstoBolsas
            // 
            this.txtImpstoBolsas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImpstoBolsas.Location = new System.Drawing.Point(315, 53);
            this.txtImpstoBolsas.Name = "txtImpstoBolsas";
            this.txtImpstoBolsas.ReadOnly = true;
            this.txtImpstoBolsas.Size = new System.Drawing.Size(93, 22);
            this.txtImpstoBolsas.TabIndex = 23;
            this.txtImpstoBolsas.Text = "0";
            this.txtImpstoBolsas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotalPago
            // 
            this.txtTotalPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalPago.Location = new System.Drawing.Point(795, 53);
            this.txtTotalPago.Name = "txtTotalPago";
            this.txtTotalPago.ReadOnly = true;
            this.txtTotalPago.Size = new System.Drawing.Size(105, 22);
            this.txtTotalPago.TabIndex = 45;
            this.txtTotalPago.Text = "0";
            this.txtTotalPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(227, 56);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 16);
            this.label10.TabIndex = 21;
            this.label10.Text = "INC BOL: ";
            // 
            // txtRetencion
            // 
            this.txtRetencion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRetencion.Location = new System.Drawing.Point(512, 53);
            this.txtRetencion.Name = "txtRetencion";
            this.txtRetencion.ReadOnly = true;
            this.txtRetencion.Size = new System.Drawing.Size(105, 22);
            this.txtRetencion.TabIndex = 26;
            this.txtRetencion.Text = "0";
            this.txtRetencion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(297, 56);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(15, 16);
            this.label9.TabIndex = 22;
            this.label9.Text = "$";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(913, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 16);
            this.label1.TabIndex = 15;
            this.label1.Text = "ABONOS : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(995, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 16);
            this.label2.TabIndex = 16;
            this.label2.Text = "$";
            // 
            // txtAbono
            // 
            this.txtAbono.BackColor = System.Drawing.Color.PaleTurquoise;
            this.txtAbono.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAbono.Location = new System.Drawing.Point(1013, 19);
            this.txtAbono.Name = "txtAbono";
            this.txtAbono.ReadOnly = true;
            this.txtAbono.Size = new System.Drawing.Size(93, 22);
            this.txtAbono.TabIndex = 17;
            this.txtAbono.Text = "0";
            this.txtAbono.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(915, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 16);
            this.label3.TabIndex = 18;
            this.label3.Text = "RESTA : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(995, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 16);
            this.label4.TabIndex = 13;
            this.label4.Text = "$";
            // 
            // txtResta
            // 
            this.txtResta.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtResta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResta.Location = new System.Drawing.Point(1013, 53);
            this.txtResta.Name = "txtResta";
            this.txtResta.ReadOnly = true;
            this.txtResta.Size = new System.Drawing.Size(93, 22);
            this.txtResta.TabIndex = 14;
            this.txtResta.Text = "0";
            this.txtResta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.AutoSize = true;
            this.lblSubtotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtotal.Location = new System.Drawing.Point(5, 25);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(96, 16);
            this.lblSubtotal.TabIndex = 3;
            this.lblSubtotal.Text = "SUBTOTAL :";
            // 
            // lblPesosSubTotal
            // 
            this.lblPesosSubTotal.AutoSize = true;
            this.lblPesosSubTotal.Location = new System.Drawing.Point(111, 25);
            this.lblPesosSubTotal.Name = "lblPesosSubTotal";
            this.lblPesosSubTotal.Size = new System.Drawing.Size(15, 16);
            this.lblPesosSubTotal.TabIndex = 5;
            this.lblPesosSubTotal.Text = "$";
            // 
            // txtSubTotal
            // 
            this.txtSubTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubTotal.Location = new System.Drawing.Point(129, 22);
            this.txtSubTotal.Name = "txtSubTotal";
            this.txtSubTotal.ReadOnly = true;
            this.txtSubTotal.Size = new System.Drawing.Size(93, 22);
            this.txtSubTotal.TabIndex = 4;
            this.txtSubTotal.Text = "0";
            this.txtSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblIva
            // 
            this.lblIva.AutoSize = true;
            this.lblIva.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIva.Location = new System.Drawing.Point(228, 24);
            this.lblIva.Name = "lblIva";
            this.lblIva.Size = new System.Drawing.Size(44, 16);
            this.lblIva.TabIndex = 6;
            this.lblIva.Text = "IVA : ";
            // 
            // lblPesosIva
            // 
            this.lblPesosIva.AutoSize = true;
            this.lblPesosIva.Location = new System.Drawing.Point(296, 24);
            this.lblPesosIva.Name = "lblPesosIva";
            this.lblPesosIva.Size = new System.Drawing.Size(15, 16);
            this.lblPesosIva.TabIndex = 7;
            this.lblPesosIva.Text = "$";
            // 
            // txtIva
            // 
            this.txtIva.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIva.Location = new System.Drawing.Point(315, 21);
            this.txtIva.Name = "txtIva";
            this.txtIva.ReadOnly = true;
            this.txtIva.Size = new System.Drawing.Size(93, 22);
            this.txtIva.TabIndex = 8;
            this.txtIva.Text = "0";
            this.txtIva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblDescuento
            // 
            this.lblDescuento.AutoSize = true;
            this.lblDescuento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescuento.Location = new System.Drawing.Point(5, 56);
            this.lblDescuento.Name = "lblDescuento";
            this.lblDescuento.Size = new System.Drawing.Size(106, 16);
            this.lblDescuento.TabIndex = 9;
            this.lblDescuento.Text = "DESCUENTO:";
            // 
            // lblPesoDescuento
            // 
            this.lblPesoDescuento.AutoSize = true;
            this.lblPesoDescuento.Location = new System.Drawing.Point(110, 56);
            this.lblPesoDescuento.Name = "lblPesoDescuento";
            this.lblPesoDescuento.Size = new System.Drawing.Size(15, 16);
            this.lblPesoDescuento.TabIndex = 10;
            this.lblPesoDescuento.Text = "$";
            // 
            // txtDescuento
            // 
            this.txtDescuento.BackColor = System.Drawing.SystemColors.Control;
            this.txtDescuento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescuento.Location = new System.Drawing.Point(130, 53);
            this.txtDescuento.Name = "txtDescuento";
            this.txtDescuento.ReadOnly = true;
            this.txtDescuento.Size = new System.Drawing.Size(92, 22);
            this.txtDescuento.TabIndex = 11;
            this.txtDescuento.Text = "0";
            this.txtDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(419, 25);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(69, 16);
            this.lblTotal.TabIndex = 12;
            this.lblTotal.Text = "TOTAL : ";
            // 
            // lblPesosTotal
            // 
            this.lblPesosTotal.AutoSize = true;
            this.lblPesosTotal.Location = new System.Drawing.Point(493, 25);
            this.lblPesosTotal.Name = "lblPesosTotal";
            this.lblPesosTotal.Size = new System.Drawing.Size(15, 16);
            this.lblPesosTotal.TabIndex = 0;
            this.lblPesosTotal.Text = "$";
            // 
            // txtTotal
            // 
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(512, 21);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(106, 22);
            this.txtTotal.TabIndex = 1;
            this.txtTotal.Text = "0";
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtIco
            // 
            this.txtIco.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIco.Location = new System.Drawing.Point(1111, 64);
            this.txtIco.Name = "txtIco";
            this.txtIco.ReadOnly = true;
            this.txtIco.Size = new System.Drawing.Size(14, 22);
            this.txtIco.TabIndex = 1;
            this.txtIco.Text = "0";
            this.txtIco.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtIco.Visible = false;
            // 
            // btnCambio
            // 
            this.btnCambio.Location = new System.Drawing.Point(1073, 49);
            this.btnCambio.Name = "btnCambio";
            this.btnCambio.Size = new System.Drawing.Size(25, 23);
            this.btnCambio.TabIndex = 10;
            this.btnCambio.Text = "#";
            this.btnCambio.UseVisualStyleBackColor = true;
            this.btnCambio.Visible = false;
            this.btnCambio.Click += new System.EventHandler(this.btnCambio_Click);
            // 
            // FrmConsulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1136, 598);
            this.Controls.Add(this.btnCambio);
            this.Controls.Add(this.gbResumen);
            this.Controls.Add(this.gbListadoArticulos);
            this.Controls.Add(this.gbFactura);
            this.Controls.Add(this.tsMenu);
            this.Controls.Add(this.gbCritero);
            this.Controls.Add(this.txtIco);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmConsulta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta Facturas de Venta";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmConsulta_FormClosing);
            this.Load += new System.EventHandler(this.FrmConsulta_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmConsulta_KeyDown);
            this.gbCritero.ResumeLayout(false);
            this.gbCritero.PerformLayout();
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.gbFactura.ResumeLayout(false);
            this.gbFactura.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFactura)).EndInit();
            this.StatusFactura.ResumeLayout(false);
            this.StatusFactura.PerformLayout();
            this.gbListadoArticulos.ResumeLayout(false);
            this.PanelMenuArticulo.ResumeLayout(false);
            this.PanelMenuArticulo.PerformLayout();
            this.tsMenuArticulo.ResumeLayout(false);
            this.tsMenuArticulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaArticulos)).EndInit();
            this.gbResumen.ResumeLayout(false);
            this.gbResumen.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbCritero;
        private System.Windows.Forms.ComboBox cbCriterio;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Button btnBuscarCodigo;
        private System.Windows.Forms.ComboBox cbFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha1;
        private System.Windows.Forms.DateTimePicker dtpFecha2;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.ComboBox cbEstado;
        private System.Windows.Forms.GroupBox gbFactura;
        private System.Windows.Forms.DataGridView dgvFactura;
        private System.Windows.Forms.StatusStrip StatusFactura;
        private System.Windows.Forms.ToolStripDropDownButton btnInicio;
        private System.Windows.Forms.ToolStripDropDownButton btnAnterior;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusFactura;
        private System.Windows.Forms.ToolStripDropDownButton btnSiguiente;
        private System.Windows.Forms.ToolStripDropDownButton btnFin;
        private System.Windows.Forms.GroupBox gbListadoArticulos;
        private DataGridViewPlus dgvListaArticulos;
        private System.Windows.Forms.GroupBox gbResumen;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.Label lblPesosSubTotal;
        private System.Windows.Forms.TextBox txtSubTotal;
        private System.Windows.Forms.Label lblIva;
        private System.Windows.Forms.Label lblPesosIva;
        private System.Windows.Forms.TextBox txtIva;
        private System.Windows.Forms.Label lblDescuento;
        private System.Windows.Forms.Label lblPesoDescuento;
        private System.Windows.Forms.TextBox txtDescuento;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblPesosTotal;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.ToolStripButton tsBtnEditar;
        private System.Windows.Forms.ToolStripButton tsBtnRealizarAbono;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAbono;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtResta;
        private System.Windows.Forms.ToolStripButton tsBtnSalir;
        private System.Windows.Forms.ToolStripButton tsBtnSeleccionar;
        private System.Windows.Forms.ToolStripButton tsBtnCopia;
        private System.Windows.Forms.ToolStripButton tsBtnAbonoGeneral;
        private System.Windows.Forms.TextBox txtSaldoDevolucion;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtRetencion;
        private System.Windows.Forms.Label lblPesosTotalPago;
        private System.Windows.Forms.TextBox txtTotalPago;
        private System.Windows.Forms.Label lblTotalPago;
        private System.Windows.Forms.Button btnInfoRete;
        private System.Windows.Forms.Panel PanelMenuArticulo;
        private System.Windows.Forms.ToolStrip tsMenuArticulo;
        private System.Windows.Forms.ToolStripButton tsBtnNuevoArticulo;
        private System.Windows.Forms.Button btnCambio;
        private System.Windows.Forms.ToolStripButton tsBtnVerPagos;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtImpstoBolsas;
        private System.Windows.Forms.TextBox txtIco;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Articulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdMedida;
        private System.Windows.Forms.DataGridViewTextBoxColumn Medida;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdColor;
        private System.Windows.Forms.DataGridViewImageColumn Color;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdMarca;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descto;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorMenosDescto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Iva;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorIva;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalMasIva;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ico;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DataGridViewTextBoxColumn Retorno;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorReal;
        private System.Windows.Forms.ToolStripButton tsBtnAnular;
        private System.Windows.Forms.ToolStripButton tsSaldoCliente;
        private System.Windows.Forms.ToolStripButton tsBtnSaltoTotalCredito;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdFactura;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Proveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn EstadoFactura;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaIngreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hora;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaLimite;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descuento;
        private System.Windows.Forms.DataGridViewTextBoxColumn DesctoFactura;
        private System.Windows.Forms.DataGridViewTextBoxColumn Activa;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdResolucionDian;
    }
}