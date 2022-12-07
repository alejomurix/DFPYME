namespace Aplicacion.Ventas.Factura
{
    partial class FrmResumenVenta
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

        private System.ComponentModel.ComponentResourceManager miResources =
            new System.ComponentModel.ComponentResourceManager(typeof(FrmResumenVenta));

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmResumenVenta));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbCritero = new System.Windows.Forms.GroupBox();
            this.cbCliente = new System.Windows.Forms.ComboBox();
            this.cbCriterio = new System.Windows.Forms.ComboBox();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.btnBuscarCliente = new System.Windows.Forms.Button();
            this.cbFecha = new System.Windows.Forms.ComboBox();
            this.dtpFecha1 = new System.Windows.Forms.DateTimePicker();
            this.dtpFecha2 = new System.Windows.Forms.DateTimePicker();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.gbFactura = new System.Windows.Forms.GroupBox();
            this.dgvFactura = new System.Windows.Forms.DataGridView();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Factura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Base = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Iva = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.StatusStrip();
            this.btnInicio = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnAnterior = new System.Windows.Forms.ToolStripDropDownButton();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnSiguiente = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnFin = new System.Windows.Forms.ToolStripDropDownButton();
            this.gbResumenVentas = new System.Windows.Forms.GroupBox();
            this.lblBase = new System.Windows.Forms.Label();
            this.txtBase = new System.Windows.Forms.TextBox();
            this.lblIva = new System.Windows.Forms.Label();
            this.txtIva = new System.Windows.Forms.TextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.gbResumenTributaria = new System.Windows.Forms.GroupBox();
            this.lblIvaCompra = new System.Windows.Forms.Label();
            this.txtIvaCompra = new System.Windows.Forms.TextBox();
            this.lblIvaVenta = new System.Windows.Forms.Label();
            this.txtIvaVenta = new System.Windows.Forms.TextBox();
            this.lblDiferencia = new System.Windows.Forms.Label();
            this.txtDiferencia = new System.Windows.Forms.TextBox();
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.btnVerUtilidad = new System.Windows.Forms.ToolStripButton();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            this.gbResumenUtilidad = new System.Windows.Forms.GroupBox();
            this.txtCostoView = new System.Windows.Forms.TextBox();
            this.txtVentaView = new System.Windows.Forms.TextBox();
            this.txtUtilidadView = new System.Windows.Forms.TextBox();
            this.lblCosto = new System.Windows.Forms.Label();
            this.txtCosto = new System.Windows.Forms.TextBox();
            this.lblVenta = new System.Windows.Forms.Label();
            this.txtVenta = new System.Windows.Forms.TextBox();
            this.lblUtilidad = new System.Windows.Forms.Label();
            this.txtUtilidad = new System.Windows.Forms.TextBox();
            this.gbCritero.SuspendLayout();
            this.gbFactura.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFactura)).BeginInit();
            this.Status.SuspendLayout();
            this.gbResumenVentas.SuspendLayout();
            this.gbResumenTributaria.SuspendLayout();
            this.tsMenu.SuspendLayout();
            this.gbResumenUtilidad.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbCritero
            // 
            this.gbCritero.Controls.Add(this.cbCliente);
            this.gbCritero.Controls.Add(this.cbCriterio);
            this.gbCritero.Controls.Add(this.txtCliente);
            this.gbCritero.Controls.Add(this.btnBuscarCliente);
            this.gbCritero.Controls.Add(this.cbFecha);
            this.gbCritero.Controls.Add(this.dtpFecha1);
            this.gbCritero.Controls.Add(this.dtpFecha2);
            this.gbCritero.Controls.Add(this.btnBuscar);
            this.gbCritero.Location = new System.Drawing.Point(12, 31);
            this.gbCritero.Name = "gbCritero";
            this.gbCritero.Size = new System.Drawing.Size(893, 67);
            this.gbCritero.TabIndex = 3;
            this.gbCritero.TabStop = false;
            this.gbCritero.Text = "Criterio de Consulta";
            // 
            // cbCliente
            // 
            this.cbCliente.DisplayMember = "Nombre";
            this.cbCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCliente.FormattingEnabled = true;
            this.cbCliente.Location = new System.Drawing.Point(145, 26);
            this.cbCliente.Name = "cbCliente";
            this.cbCliente.Size = new System.Drawing.Size(100, 24);
            this.cbCliente.TabIndex = 4;
            this.cbCliente.ValueMember = "Id";
            this.cbCliente.SelectionChangeCommitted += new System.EventHandler(this.cbCliente_SelectionChangeCommitted);
            // 
            // cbCriterio
            // 
            this.cbCriterio.DisplayMember = "Nombre";
            this.cbCriterio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCriterio.FormattingEnabled = true;
            this.cbCriterio.Location = new System.Drawing.Point(14, 26);
            this.cbCriterio.Name = "cbCriterio";
            this.cbCriterio.Size = new System.Drawing.Size(122, 24);
            this.cbCriterio.TabIndex = 0;
            this.cbCriterio.ValueMember = "Id";
            // 
            // txtCliente
            // 
            this.txtCliente.Enabled = false;
            this.txtCliente.Location = new System.Drawing.Point(287, 27);
            this.txtCliente.MaxLength = 30;
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(183, 22);
            this.txtCliente.TabIndex = 1;
            // 
            // btnBuscarCliente
            // 
            this.btnBuscarCliente.Enabled = false;
            this.btnBuscarCliente.Location = new System.Drawing.Point(476, 26);
            this.btnBuscarCliente.Name = "btnBuscarCliente";
            this.btnBuscarCliente.Size = new System.Drawing.Size(25, 23);
            this.btnBuscarCliente.TabIndex = 2;
            this.btnBuscarCliente.Text = "...";
            this.btnBuscarCliente.UseVisualStyleBackColor = true;
            this.btnBuscarCliente.Click += new System.EventHandler(this.btnBuscarCliente_Click);
            // 
            // cbFecha
            // 
            this.cbFecha.DisplayMember = "Nombre";
            this.cbFecha.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFecha.FormattingEnabled = true;
            this.cbFecha.Location = new System.Drawing.Point(517, 26);
            this.cbFecha.Name = "cbFecha";
            this.cbFecha.Size = new System.Drawing.Size(136, 24);
            this.cbFecha.TabIndex = 5;
            this.cbFecha.ValueMember = "Id";
            this.cbFecha.SelectionChangeCommitted += new System.EventHandler(this.cbFecha_SelectionChangeCommitted);
            // 
            // dtpFecha1
            // 
            this.dtpFecha1.CustomFormat = "dd/MM/yyyy";
            this.dtpFecha1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecha1.Location = new System.Drawing.Point(666, 27);
            this.dtpFecha1.Name = "dtpFecha1";
            this.dtpFecha1.Size = new System.Drawing.Size(84, 22);
            this.dtpFecha1.TabIndex = 7;
            // 
            // dtpFecha2
            // 
            this.dtpFecha2.CustomFormat = "dd/MM/yyyy";
            this.dtpFecha2.Enabled = false;
            this.dtpFecha2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecha2.Location = new System.Drawing.Point(756, 26);
            this.dtpFecha2.Name = "dtpFecha2";
            this.dtpFecha2.Size = new System.Drawing.Size(84, 22);
            this.dtpFecha2.TabIndex = 8;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(852, 25);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(25, 23);
            this.btnBuscar.TabIndex = 9;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // gbFactura
            // 
            this.gbFactura.Controls.Add(this.dgvFactura);
            this.gbFactura.Controls.Add(this.Status);
            this.gbFactura.Location = new System.Drawing.Point(12, 100);
            this.gbFactura.Name = "gbFactura";
            this.gbFactura.Size = new System.Drawing.Size(1017, 289);
            this.gbFactura.TabIndex = 5;
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
            this.Fecha,
            this.Nit,
            this.Cliente,
            this.Factura,
            this.Pago,
            this.Estado,
            this.Base,
            this.Iva,
            this.Total});
            this.dgvFactura.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvFactura.Location = new System.Drawing.Point(3, 13);
            this.dgvFactura.Name = "dgvFactura";
            this.dgvFactura.RowHeadersVisible = false;
            this.dgvFactura.Size = new System.Drawing.Size(1010, 250);
            this.dgvFactura.TabIndex = 0;
            // 
            // Fecha
            // 
            this.Fecha.DataPropertyName = "Fecha";
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Nit
            // 
            this.Nit.DataPropertyName = "Nit";
            this.Nit.HeaderText = "Nit";
            this.Nit.Name = "Nit";
            this.Nit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Cliente
            // 
            this.Cliente.DataPropertyName = "Cliente";
            this.Cliente.HeaderText = "Cliente";
            this.Cliente.Name = "Cliente";
            this.Cliente.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Cliente.Width = 200;
            // 
            // Factura
            // 
            this.Factura.DataPropertyName = "Factura";
            this.Factura.HeaderText = "Factura";
            this.Factura.Name = "Factura";
            this.Factura.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Pago
            // 
            this.Pago.DataPropertyName = "Pago";
            this.Pago.HeaderText = "Pago";
            this.Pago.Name = "Pago";
            // 
            // Estado
            // 
            this.Estado.DataPropertyName = "Estado";
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Base
            // 
            this.Base.DataPropertyName = "Base";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = null;
            this.Base.DefaultCellStyle = dataGridViewCellStyle1;
            this.Base.HeaderText = "Base";
            this.Base.Name = "Base";
            this.Base.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Iva
            // 
            this.Iva.DataPropertyName = "Iva";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.Iva.DefaultCellStyle = dataGridViewCellStyle2;
            this.Iva.HeaderText = "Iva";
            this.Iva.Name = "Iva";
            this.Iva.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Total
            // 
            this.Total.DataPropertyName = "Total";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.Total.DefaultCellStyle = dataGridViewCellStyle3;
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            this.Total.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Status
            // 
            this.Status.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnInicio,
            this.btnAnterior,
            this.lblStatus,
            this.btnSiguiente,
            this.btnFin});
            this.Status.Location = new System.Drawing.Point(3, 264);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(1011, 22);
            this.Status.TabIndex = 1;
            this.Status.Text = "Status";
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
            this.lblStatus.Size = new System.Drawing.Size(29, 17);
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
            // gbResumenVentas
            // 
            this.gbResumenVentas.Controls.Add(this.lblBase);
            this.gbResumenVentas.Controls.Add(this.txtBase);
            this.gbResumenVentas.Controls.Add(this.lblIva);
            this.gbResumenVentas.Controls.Add(this.txtIva);
            this.gbResumenVentas.Controls.Add(this.lblTotal);
            this.gbResumenVentas.Controls.Add(this.txtTotal);
            this.gbResumenVentas.Location = new System.Drawing.Point(114, 395);
            this.gbResumenVentas.Name = "gbResumenVentas";
            this.gbResumenVentas.Size = new System.Drawing.Size(915, 65);
            this.gbResumenVentas.TabIndex = 6;
            this.gbResumenVentas.TabStop = false;
            this.gbResumenVentas.Text = "Resumen de ventas";
            // 
            // lblBase
            // 
            this.lblBase.AutoSize = true;
            this.lblBase.Location = new System.Drawing.Point(90, 30);
            this.lblBase.Name = "lblBase";
            this.lblBase.Size = new System.Drawing.Size(40, 16);
            this.lblBase.TabIndex = 5;
            this.lblBase.Text = "Base";
            // 
            // txtBase
            // 
            this.txtBase.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBase.Location = new System.Drawing.Point(145, 27);
            this.txtBase.Name = "txtBase";
            this.txtBase.ReadOnly = true;
            this.txtBase.Size = new System.Drawing.Size(150, 22);
            this.txtBase.TabIndex = 4;
            this.txtBase.Text = "0";
            this.txtBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblIva
            // 
            this.lblIva.AutoSize = true;
            this.lblIva.Location = new System.Drawing.Point(401, 30);
            this.lblIva.Name = "lblIva";
            this.lblIva.Size = new System.Drawing.Size(29, 16);
            this.lblIva.TabIndex = 3;
            this.lblIva.Text = "IVA";
            // 
            // txtIva
            // 
            this.txtIva.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIva.Location = new System.Drawing.Point(442, 27);
            this.txtIva.Name = "txtIva";
            this.txtIva.ReadOnly = true;
            this.txtIva.Size = new System.Drawing.Size(150, 22);
            this.txtIva.TabIndex = 2;
            this.txtIva.Text = "0";
            this.txtIva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(663, 30);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(39, 16);
            this.lblTotal.TabIndex = 1;
            this.lblTotal.Text = "Total";
            // 
            // txtTotal
            // 
            this.txtTotal.BackColor = System.Drawing.Color.PaleTurquoise;
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(718, 27);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(150, 22);
            this.txtTotal.TabIndex = 0;
            this.txtTotal.Text = "0";
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // gbResumenTributaria
            // 
            this.gbResumenTributaria.Controls.Add(this.lblIvaCompra);
            this.gbResumenTributaria.Controls.Add(this.txtIvaCompra);
            this.gbResumenTributaria.Controls.Add(this.lblIvaVenta);
            this.gbResumenTributaria.Controls.Add(this.txtIvaVenta);
            this.gbResumenTributaria.Controls.Add(this.lblDiferencia);
            this.gbResumenTributaria.Controls.Add(this.txtDiferencia);
            this.gbResumenTributaria.Location = new System.Drawing.Point(114, 462);
            this.gbResumenTributaria.Name = "gbResumenTributaria";
            this.gbResumenTributaria.Size = new System.Drawing.Size(915, 65);
            this.gbResumenTributaria.TabIndex = 7;
            this.gbResumenTributaria.TabStop = false;
            this.gbResumenTributaria.Text = "Resumen tributario";
            // 
            // lblIvaCompra
            // 
            this.lblIvaCompra.AutoSize = true;
            this.lblIvaCompra.Location = new System.Drawing.Point(25, 30);
            this.lblIvaCompra.Name = "lblIvaCompra";
            this.lblIvaCompra.Size = new System.Drawing.Size(105, 16);
            this.lblIvaCompra.TabIndex = 5;
            this.lblIvaCompra.Text = "IVA en Compras";
            // 
            // txtIvaCompra
            // 
            this.txtIvaCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIvaCompra.Location = new System.Drawing.Point(145, 27);
            this.txtIvaCompra.Name = "txtIvaCompra";
            this.txtIvaCompra.ReadOnly = true;
            this.txtIvaCompra.Size = new System.Drawing.Size(150, 22);
            this.txtIvaCompra.TabIndex = 4;
            this.txtIvaCompra.Text = "0";
            this.txtIvaCompra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblIvaVenta
            // 
            this.lblIvaVenta.AutoSize = true;
            this.lblIvaVenta.Location = new System.Drawing.Point(338, 30);
            this.lblIvaVenta.Name = "lblIvaVenta";
            this.lblIvaVenta.Size = new System.Drawing.Size(92, 16);
            this.lblIvaVenta.TabIndex = 3;
            this.lblIvaVenta.Text = "IVA en Ventas";
            // 
            // txtIvaVenta
            // 
            this.txtIvaVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIvaVenta.Location = new System.Drawing.Point(442, 27);
            this.txtIvaVenta.Name = "txtIvaVenta";
            this.txtIvaVenta.ReadOnly = true;
            this.txtIvaVenta.Size = new System.Drawing.Size(150, 22);
            this.txtIvaVenta.TabIndex = 2;
            this.txtIvaVenta.Text = "0";
            this.txtIvaVenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblDiferencia
            // 
            this.lblDiferencia.AutoSize = true;
            this.lblDiferencia.Location = new System.Drawing.Point(640, 30);
            this.lblDiferencia.Name = "lblDiferencia";
            this.lblDiferencia.Size = new System.Drawing.Size(69, 16);
            this.lblDiferencia.TabIndex = 1;
            this.lblDiferencia.Text = "Diferencia";
            // 
            // txtDiferencia
            // 
            this.txtDiferencia.BackColor = System.Drawing.Color.PaleTurquoise;
            this.txtDiferencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiferencia.Location = new System.Drawing.Point(718, 27);
            this.txtDiferencia.Name = "txtDiferencia";
            this.txtDiferencia.ReadOnly = true;
            this.txtDiferencia.Size = new System.Drawing.Size(150, 22);
            this.txtDiferencia.TabIndex = 0;
            this.txtDiferencia.Text = "0";
            this.txtDiferencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tsMenu
            // 
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnVerUtilidad,
            this.btnSalir});
            this.tsMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(1040, 25);
            this.tsMenu.TabIndex = 8;
            this.tsMenu.Text = "Menu";
            // 
            // btnVerUtilidad
            // 
            this.btnVerUtilidad.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnVerUtilidad.Image = ((System.Drawing.Image)(resources.GetObject("btnVerUtilidad.Image")));
            this.btnVerUtilidad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnVerUtilidad.Name = "btnVerUtilidad";
            this.btnVerUtilidad.Size = new System.Drawing.Size(97, 22);
            this.btnVerUtilidad.Text = "Ver Utilidad";
            this.btnVerUtilidad.Click += new System.EventHandler(this.btnVerUtilidad_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(47, 22);
            this.btnSalir.Text = "Salir";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // gbResumenUtilidad
            // 
            this.gbResumenUtilidad.Controls.Add(this.txtCostoView);
            this.gbResumenUtilidad.Controls.Add(this.txtVentaView);
            this.gbResumenUtilidad.Controls.Add(this.txtUtilidadView);
            this.gbResumenUtilidad.Controls.Add(this.lblCosto);
            this.gbResumenUtilidad.Controls.Add(this.txtCosto);
            this.gbResumenUtilidad.Controls.Add(this.lblVenta);
            this.gbResumenUtilidad.Controls.Add(this.txtVenta);
            this.gbResumenUtilidad.Controls.Add(this.lblUtilidad);
            this.gbResumenUtilidad.Controls.Add(this.txtUtilidad);
            this.gbResumenUtilidad.Location = new System.Drawing.Point(114, 530);
            this.gbResumenUtilidad.Name = "gbResumenUtilidad";
            this.gbResumenUtilidad.Size = new System.Drawing.Size(915, 65);
            this.gbResumenUtilidad.TabIndex = 9;
            this.gbResumenUtilidad.TabStop = false;
            this.gbResumenUtilidad.Text = "Resumen de utilidad";
            // 
            // txtCostoView
            // 
            this.txtCostoView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCostoView.Location = new System.Drawing.Point(145, 27);
            this.txtCostoView.Name = "txtCostoView";
            this.txtCostoView.ReadOnly = true;
            this.txtCostoView.Size = new System.Drawing.Size(150, 22);
            this.txtCostoView.TabIndex = 8;
            this.txtCostoView.Text = "0";
            this.txtCostoView.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtVentaView
            // 
            this.txtVentaView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVentaView.Location = new System.Drawing.Point(442, 27);
            this.txtVentaView.Name = "txtVentaView";
            this.txtVentaView.ReadOnly = true;
            this.txtVentaView.Size = new System.Drawing.Size(150, 22);
            this.txtVentaView.TabIndex = 7;
            this.txtVentaView.Text = "0";
            this.txtVentaView.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtUtilidadView
            // 
            this.txtUtilidadView.BackColor = System.Drawing.Color.PaleTurquoise;
            this.txtUtilidadView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUtilidadView.Location = new System.Drawing.Point(718, 27);
            this.txtUtilidadView.Name = "txtUtilidadView";
            this.txtUtilidadView.ReadOnly = true;
            this.txtUtilidadView.Size = new System.Drawing.Size(150, 22);
            this.txtUtilidadView.TabIndex = 6;
            this.txtUtilidadView.Text = "0";
            this.txtUtilidadView.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblCosto
            // 
            this.lblCosto.AutoSize = true;
            this.lblCosto.Location = new System.Drawing.Point(25, 30);
            this.lblCosto.Name = "lblCosto";
            this.lblCosto.Size = new System.Drawing.Size(105, 16);
            this.lblCosto.TabIndex = 5;
            this.lblCosto.Text = "Costo Promedio";
            // 
            // txtCosto
            // 
            this.txtCosto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCosto.Location = new System.Drawing.Point(145, 27);
            this.txtCosto.Name = "txtCosto";
            this.txtCosto.ReadOnly = true;
            this.txtCosto.Size = new System.Drawing.Size(150, 22);
            this.txtCosto.TabIndex = 4;
            this.txtCosto.Text = "0";
            this.txtCosto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCosto.Visible = false;
            // 
            // lblVenta
            // 
            this.lblVenta.AutoSize = true;
            this.lblVenta.Location = new System.Drawing.Point(380, 30);
            this.lblVenta.Name = "lblVenta";
            this.lblVenta.Size = new System.Drawing.Size(50, 16);
            this.lblVenta.TabIndex = 3;
            this.lblVenta.Text = "Ventas";
            // 
            // txtVenta
            // 
            this.txtVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVenta.Location = new System.Drawing.Point(442, 27);
            this.txtVenta.Name = "txtVenta";
            this.txtVenta.ReadOnly = true;
            this.txtVenta.Size = new System.Drawing.Size(150, 22);
            this.txtVenta.TabIndex = 2;
            this.txtVenta.Text = "0";
            this.txtVenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtVenta.Visible = false;
            // 
            // lblUtilidad
            // 
            this.lblUtilidad.AutoSize = true;
            this.lblUtilidad.Location = new System.Drawing.Point(648, 30);
            this.lblUtilidad.Name = "lblUtilidad";
            this.lblUtilidad.Size = new System.Drawing.Size(54, 16);
            this.lblUtilidad.TabIndex = 1;
            this.lblUtilidad.Text = "Utilidad";
            // 
            // txtUtilidad
            // 
            this.txtUtilidad.BackColor = System.Drawing.Color.PaleTurquoise;
            this.txtUtilidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUtilidad.Location = new System.Drawing.Point(718, 27);
            this.txtUtilidad.Name = "txtUtilidad";
            this.txtUtilidad.ReadOnly = true;
            this.txtUtilidad.Size = new System.Drawing.Size(150, 22);
            this.txtUtilidad.TabIndex = 0;
            this.txtUtilidad.Text = "0";
            this.txtUtilidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtUtilidad.Visible = false;
            // 
            // FrmResumenVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1040, 602);
            this.Controls.Add(this.gbResumenUtilidad);
            this.Controls.Add(this.tsMenu);
            this.Controls.Add(this.gbResumenTributaria);
            this.Controls.Add(this.gbResumenVentas);
            this.Controls.Add(this.gbFactura);
            this.Controls.Add(this.gbCritero);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmResumenVenta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Resumen de ventas y utilidad";
            this.Load += new System.EventHandler(this.FrmResumenVenta_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmResumenVenta_KeyDown);
            this.gbCritero.ResumeLayout(false);
            this.gbCritero.PerformLayout();
            this.gbFactura.ResumeLayout(false);
            this.gbFactura.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFactura)).EndInit();
            this.Status.ResumeLayout(false);
            this.Status.PerformLayout();
            this.gbResumenVentas.ResumeLayout(false);
            this.gbResumenVentas.PerformLayout();
            this.gbResumenTributaria.ResumeLayout(false);
            this.gbResumenTributaria.PerformLayout();
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.gbResumenUtilidad.ResumeLayout(false);
            this.gbResumenUtilidad.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbCritero;
        private System.Windows.Forms.ComboBox cbCliente;
        private System.Windows.Forms.ComboBox cbCriterio;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Button btnBuscarCliente;
        private System.Windows.Forms.ComboBox cbFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha1;
        private System.Windows.Forms.DateTimePicker dtpFecha2;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.GroupBox gbFactura;
        private System.Windows.Forms.DataGridView dgvFactura;
        private System.Windows.Forms.StatusStrip Status;
        private System.Windows.Forms.ToolStripDropDownButton btnInicio;
        private System.Windows.Forms.ToolStripDropDownButton btnAnterior;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripDropDownButton btnSiguiente;
        private System.Windows.Forms.ToolStripDropDownButton btnFin;
        private System.Windows.Forms.GroupBox gbResumenVentas;
        private System.Windows.Forms.Label lblBase;
        private System.Windows.Forms.TextBox txtBase;
        private System.Windows.Forms.Label lblIva;
        private System.Windows.Forms.TextBox txtIva;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.GroupBox gbResumenTributaria;
        private System.Windows.Forms.Label lblIvaCompra;
        private System.Windows.Forms.TextBox txtIvaCompra;
        private System.Windows.Forms.Label lblIvaVenta;
        private System.Windows.Forms.TextBox txtIvaVenta;
        private System.Windows.Forms.Label lblDiferencia;
        private System.Windows.Forms.TextBox txtDiferencia;
        private System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.GroupBox gbResumenUtilidad;
        private System.Windows.Forms.Label lblCosto;
        private System.Windows.Forms.TextBox txtCosto;
        private System.Windows.Forms.Label lblVenta;
        private System.Windows.Forms.TextBox txtVenta;
        private System.Windows.Forms.Label lblUtilidad;
        private System.Windows.Forms.TextBox txtUtilidad;
        private System.Windows.Forms.ToolStripButton btnSalir;
        private System.Windows.Forms.ToolStripButton btnVerUtilidad;
        private System.Windows.Forms.TextBox txtUtilidadView;
        private System.Windows.Forms.TextBox txtVentaView;
        private System.Windows.Forms.TextBox txtCostoView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Factura;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pago;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Base;
        private System.Windows.Forms.DataGridViewTextBoxColumn Iva;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
    }
}