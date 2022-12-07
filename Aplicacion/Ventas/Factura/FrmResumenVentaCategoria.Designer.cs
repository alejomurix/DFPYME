namespace Aplicacion.Ventas.Factura
{
    partial class FrmResumenVentaCategoria
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmResumenVentaCategoria));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbCritero = new System.Windows.Forms.GroupBox();
            this.txtCategoria = new System.Windows.Forms.TextBox();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.txtCodCategoria = new System.Windows.Forms.TextBox();
            this.btnBuscarCategoria = new System.Windows.Forms.Button();
            this.cbFecha = new System.Windows.Forms.ComboBox();
            this.dtpFecha1 = new System.Windows.Forms.DateTimePicker();
            this.dtpFecha2 = new System.Windows.Forms.DateTimePicker();
            this.btnBuscar = new System.Windows.Forms.Button();
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
            this.grbResumenVentasCategorias = new System.Windows.Forms.GroupBox();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.txtTotalVentasCategorias = new System.Windows.Forms.TextBox();
            this.btnBuscarTotalesCategoria = new System.Windows.Forms.Button();
            this.btnCategorias = new System.Windows.Forms.Button();
            this.dgvTotales = new System.Windows.Forms.DataGridView();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtValorCatVerduraRemision = new System.Windows.Forms.TextBox();
            this.txtTotalCatVerduraVentaRemision = new System.Windows.Forms.TextBox();
            this.txtNameCategoriaVerdura = new System.Windows.Forms.TextBox();
            this.txtCodCategoriaVerdura = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtValorCategoriaRemision = new System.Windows.Forms.TextBox();
            this.txtTotalCategoriaVentaRemision = new System.Windows.Forms.TextBox();
            this.txtNameCategoriaRemision = new System.Windows.Forms.TextBox();
            this.txtCodCategoriaRemision = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gbCritero.SuspendLayout();
            this.gbResumenVentas.SuspendLayout();
            this.gbResumenTributaria.SuspendLayout();
            this.tsMenu.SuspendLayout();
            this.gbResumenUtilidad.SuspendLayout();
            this.grbResumenVentasCategorias.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTotales)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbCritero
            // 
            this.gbCritero.Controls.Add(this.txtCategoria);
            this.gbCritero.Controls.Add(this.lblCategoria);
            this.gbCritero.Controls.Add(this.txtCodCategoria);
            this.gbCritero.Controls.Add(this.btnBuscarCategoria);
            this.gbCritero.Controls.Add(this.cbFecha);
            this.gbCritero.Controls.Add(this.dtpFecha1);
            this.gbCritero.Controls.Add(this.dtpFecha2);
            this.gbCritero.Controls.Add(this.btnBuscar);
            this.gbCritero.Location = new System.Drawing.Point(12, 31);
            this.gbCritero.Name = "gbCritero";
            this.gbCritero.Size = new System.Drawing.Size(915, 67);
            this.gbCritero.TabIndex = 3;
            this.gbCritero.TabStop = false;
            this.gbCritero.Text = "Criterio de Consulta";
            // 
            // txtCategoria
            // 
            this.txtCategoria.Enabled = false;
            this.txtCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCategoria.Location = new System.Drawing.Point(193, 27);
            this.txtCategoria.Margin = new System.Windows.Forms.Padding(4);
            this.txtCategoria.Name = "txtCategoria";
            this.txtCategoria.Size = new System.Drawing.Size(327, 22);
            this.txtCategoria.TabIndex = 16;
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Location = new System.Drawing.Point(5, 30);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(67, 16);
            this.lblCategoria.TabIndex = 15;
            this.lblCategoria.Text = "Categoría";
            // 
            // txtCodCategoria
            // 
            this.txtCodCategoria.Location = new System.Drawing.Point(78, 27);
            this.txtCodCategoria.MaxLength = 30;
            this.txtCodCategoria.Name = "txtCodCategoria";
            this.txtCodCategoria.Size = new System.Drawing.Size(82, 22);
            this.txtCodCategoria.TabIndex = 1;
            this.txtCodCategoria.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodCategoria_KeyPress);
            // 
            // btnBuscarCategoria
            // 
            this.btnBuscarCategoria.Location = new System.Drawing.Point(164, 26);
            this.btnBuscarCategoria.Name = "btnBuscarCategoria";
            this.btnBuscarCategoria.Size = new System.Drawing.Size(25, 23);
            this.btnBuscarCategoria.TabIndex = 2;
            this.btnBuscarCategoria.Text = "...";
            this.btnBuscarCategoria.UseVisualStyleBackColor = true;
            this.btnBuscarCategoria.Click += new System.EventHandler(this.btnBuscarCategoria_Click);
            // 
            // cbFecha
            // 
            this.cbFecha.DisplayMember = "Nombre";
            this.cbFecha.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFecha.FormattingEnabled = true;
            this.cbFecha.Location = new System.Drawing.Point(539, 26);
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
            this.dtpFecha1.Location = new System.Drawing.Point(688, 27);
            this.dtpFecha1.Name = "dtpFecha1";
            this.dtpFecha1.Size = new System.Drawing.Size(84, 22);
            this.dtpFecha1.TabIndex = 7;
            // 
            // dtpFecha2
            // 
            this.dtpFecha2.CustomFormat = "dd/MM/yyyy";
            this.dtpFecha2.Enabled = false;
            this.dtpFecha2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecha2.Location = new System.Drawing.Point(778, 26);
            this.dtpFecha2.Name = "dtpFecha2";
            this.dtpFecha2.Size = new System.Drawing.Size(84, 22);
            this.dtpFecha2.TabIndex = 8;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(874, 25);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(25, 23);
            this.btnBuscar.TabIndex = 9;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // gbResumenVentas
            // 
            this.gbResumenVentas.Controls.Add(this.lblBase);
            this.gbResumenVentas.Controls.Add(this.txtBase);
            this.gbResumenVentas.Controls.Add(this.lblIva);
            this.gbResumenVentas.Controls.Add(this.txtIva);
            this.gbResumenVentas.Controls.Add(this.lblTotal);
            this.gbResumenVentas.Controls.Add(this.txtTotal);
            this.gbResumenVentas.Location = new System.Drawing.Point(12, 106);
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
            this.gbResumenTributaria.Location = new System.Drawing.Point(12, 173);
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
            this.tsMenu.Size = new System.Drawing.Size(938, 25);
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
            this.gbResumenUtilidad.Location = new System.Drawing.Point(12, 241);
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
            // grbResumenVentasCategorias
            // 
            this.grbResumenVentasCategorias.Controls.Add(this.btnImprimir);
            this.grbResumenVentasCategorias.Controls.Add(this.txtTotalVentasCategorias);
            this.grbResumenVentasCategorias.Controls.Add(this.btnBuscarTotalesCategoria);
            this.grbResumenVentasCategorias.Controls.Add(this.btnCategorias);
            this.grbResumenVentasCategorias.Controls.Add(this.dgvTotales);
            this.grbResumenVentasCategorias.Controls.Add(this.label1);
            this.grbResumenVentasCategorias.Location = new System.Drawing.Point(12, 312);
            this.grbResumenVentasCategorias.Name = "grbResumenVentasCategorias";
            this.grbResumenVentasCategorias.Size = new System.Drawing.Size(469, 184);
            this.grbResumenVentasCategorias.TabIndex = 10;
            this.grbResumenVentasCategorias.TabStop = false;
            // 
            // btnImprimir
            // 
            this.btnImprimir.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimir.Image")));
            this.btnImprimir.Location = new System.Drawing.Point(435, 65);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(25, 23);
            this.btnImprimir.TabIndex = 17;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // txtTotalVentasCategorias
            // 
            this.txtTotalVentasCategorias.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalVentasCategorias.Location = new System.Drawing.Point(312, 154);
            this.txtTotalVentasCategorias.Name = "txtTotalVentasCategorias";
            this.txtTotalVentasCategorias.ReadOnly = true;
            this.txtTotalVentasCategorias.Size = new System.Drawing.Size(119, 22);
            this.txtTotalVentasCategorias.TabIndex = 7;
            this.txtTotalVentasCategorias.Text = "0";
            this.txtTotalVentasCategorias.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnBuscarTotalesCategoria
            // 
            this.btnBuscarTotalesCategoria.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscarTotalesCategoria.Image")));
            this.btnBuscarTotalesCategoria.Location = new System.Drawing.Point(435, 40);
            this.btnBuscarTotalesCategoria.Name = "btnBuscarTotalesCategoria";
            this.btnBuscarTotalesCategoria.Size = new System.Drawing.Size(25, 23);
            this.btnBuscarTotalesCategoria.TabIndex = 17;
            this.btnBuscarTotalesCategoria.UseVisualStyleBackColor = true;
            this.btnBuscarTotalesCategoria.Click += new System.EventHandler(this.btnBuscarTotalesCategoria_Click);
            // 
            // btnCategorias
            // 
            this.btnCategorias.Location = new System.Drawing.Point(435, 15);
            this.btnCategorias.Name = "btnCategorias";
            this.btnCategorias.Size = new System.Drawing.Size(25, 23);
            this.btnCategorias.TabIndex = 16;
            this.btnCategorias.Text = "...";
            this.btnCategorias.UseVisualStyleBackColor = true;
            this.btnCategorias.Click += new System.EventHandler(this.btnCategorias_Click);
            // 
            // dgvTotales
            // 
            this.dgvTotales.AllowUserToAddRows = false;
            this.dgvTotales.AllowUserToResizeColumns = false;
            this.dgvTotales.AllowUserToResizeRows = false;
            this.dgvTotales.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvTotales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTotales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.Categoria,
            this.Total});
            this.dgvTotales.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvTotales.Location = new System.Drawing.Point(9, 16);
            this.dgvTotales.Name = "dgvTotales";
            this.dgvTotales.RowHeadersVisible = false;
            this.dgvTotales.Size = new System.Drawing.Size(422, 134);
            this.dgvTotales.TabIndex = 0;
            // 
            // Codigo
            // 
            this.Codigo.DataPropertyName = "CodigoCategoria";
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "Codigo";
            // 
            // Categoria
            // 
            this.Categoria.DataPropertyName = "NombreCategoria";
            this.Categoria.HeaderText = "Categoría";
            this.Categoria.Name = "Categoria";
            this.Categoria.Width = 200;
            // 
            // Total
            // 
            this.Total.DataPropertyName = "Valor";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = null;
            this.Total.DefaultCellStyle = dataGridViewCellStyle1;
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(235, 157);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "TOTALES:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtValorCatVerduraRemision);
            this.groupBox1.Controls.Add(this.txtTotalCatVerduraVentaRemision);
            this.groupBox1.Controls.Add(this.txtNameCategoriaVerdura);
            this.groupBox1.Controls.Add(this.txtCodCategoriaVerdura);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtValorCategoriaRemision);
            this.groupBox1.Controls.Add(this.txtTotalCategoriaVentaRemision);
            this.groupBox1.Controls.Add(this.txtNameCategoriaRemision);
            this.groupBox1.Controls.Add(this.txtCodCategoriaRemision);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(496, 312);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(431, 184);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Resumen de remisiones";
            // 
            // txtValorCatVerduraRemision
            // 
            this.txtValorCatVerduraRemision.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValorCatVerduraRemision.Location = new System.Drawing.Point(294, 107);
            this.txtValorCatVerduraRemision.Name = "txtValorCatVerduraRemision";
            this.txtValorCatVerduraRemision.ReadOnly = true;
            this.txtValorCatVerduraRemision.Size = new System.Drawing.Size(92, 22);
            this.txtValorCatVerduraRemision.TabIndex = 9;
            this.txtValorCatVerduraRemision.Text = "0";
            this.txtValorCatVerduraRemision.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotalCatVerduraVentaRemision
            // 
            this.txtTotalCatVerduraVentaRemision.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalCatVerduraVentaRemision.Location = new System.Drawing.Point(294, 137);
            this.txtTotalCatVerduraVentaRemision.Name = "txtTotalCatVerduraVentaRemision";
            this.txtTotalCatVerduraVentaRemision.ReadOnly = true;
            this.txtTotalCatVerduraVentaRemision.Size = new System.Drawing.Size(92, 22);
            this.txtTotalCatVerduraVentaRemision.TabIndex = 10;
            this.txtTotalCatVerduraVentaRemision.Text = "0";
            this.txtTotalCatVerduraVentaRemision.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtNameCategoriaVerdura
            // 
            this.txtNameCategoriaVerdura.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNameCategoriaVerdura.Location = new System.Drawing.Point(115, 107);
            this.txtNameCategoriaVerdura.Name = "txtNameCategoriaVerdura";
            this.txtNameCategoriaVerdura.ReadOnly = true;
            this.txtNameCategoriaVerdura.Size = new System.Drawing.Size(173, 22);
            this.txtNameCategoriaVerdura.TabIndex = 11;
            // 
            // txtCodCategoriaVerdura
            // 
            this.txtCodCategoriaVerdura.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodCategoriaVerdura.Location = new System.Drawing.Point(13, 107);
            this.txtCodCategoriaVerdura.Name = "txtCodCategoriaVerdura";
            this.txtCodCategoriaVerdura.ReadOnly = true;
            this.txtCodCategoriaVerdura.Size = new System.Drawing.Size(92, 22);
            this.txtCodCategoriaVerdura.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(106, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(182, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "TOTAL VENTA + REMISION:";
            // 
            // txtValorCategoriaRemision
            // 
            this.txtValorCategoriaRemision.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValorCategoriaRemision.Location = new System.Drawing.Point(294, 29);
            this.txtValorCategoriaRemision.Name = "txtValorCategoriaRemision";
            this.txtValorCategoriaRemision.ReadOnly = true;
            this.txtValorCategoriaRemision.Size = new System.Drawing.Size(92, 22);
            this.txtValorCategoriaRemision.TabIndex = 7;
            this.txtValorCategoriaRemision.Text = "0";
            this.txtValorCategoriaRemision.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotalCategoriaVentaRemision
            // 
            this.txtTotalCategoriaVentaRemision.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalCategoriaVentaRemision.Location = new System.Drawing.Point(294, 59);
            this.txtTotalCategoriaVentaRemision.Name = "txtTotalCategoriaVentaRemision";
            this.txtTotalCategoriaVentaRemision.ReadOnly = true;
            this.txtTotalCategoriaVentaRemision.Size = new System.Drawing.Size(92, 22);
            this.txtTotalCategoriaVentaRemision.TabIndex = 7;
            this.txtTotalCategoriaVentaRemision.Text = "0";
            this.txtTotalCategoriaVentaRemision.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtNameCategoriaRemision
            // 
            this.txtNameCategoriaRemision.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNameCategoriaRemision.Location = new System.Drawing.Point(115, 29);
            this.txtNameCategoriaRemision.Name = "txtNameCategoriaRemision";
            this.txtNameCategoriaRemision.ReadOnly = true;
            this.txtNameCategoriaRemision.Size = new System.Drawing.Size(173, 22);
            this.txtNameCategoriaRemision.TabIndex = 7;
            // 
            // txtCodCategoriaRemision
            // 
            this.txtCodCategoriaRemision.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodCategoriaRemision.Location = new System.Drawing.Point(13, 29);
            this.txtCodCategoriaRemision.Name = "txtCodCategoriaRemision";
            this.txtCodCategoriaRemision.ReadOnly = true;
            this.txtCodCategoriaRemision.Size = new System.Drawing.Size(92, 22);
            this.txtCodCategoriaRemision.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(106, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(182, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "TOTAL VENTA + REMISION:";
            // 
            // FrmResumenVentaCategoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(938, 504);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grbResumenVentasCategorias);
            this.Controls.Add(this.gbResumenUtilidad);
            this.Controls.Add(this.tsMenu);
            this.Controls.Add(this.gbResumenTributaria);
            this.Controls.Add(this.gbResumenVentas);
            this.Controls.Add(this.gbCritero);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmResumenVentaCategoria";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Resumen de ventas y utilidad por categoría";
            this.Load += new System.EventHandler(this.FrmResumenVenta_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmResumenVenta_KeyDown);
            this.gbCritero.ResumeLayout(false);
            this.gbCritero.PerformLayout();
            this.gbResumenVentas.ResumeLayout(false);
            this.gbResumenVentas.PerformLayout();
            this.gbResumenTributaria.ResumeLayout(false);
            this.gbResumenTributaria.PerformLayout();
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.gbResumenUtilidad.ResumeLayout(false);
            this.gbResumenUtilidad.PerformLayout();
            this.grbResumenVentasCategorias.ResumeLayout(false);
            this.grbResumenVentasCategorias.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTotales)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbCritero;
        private System.Windows.Forms.TextBox txtCodCategoria;
        private System.Windows.Forms.Button btnBuscarCategoria;
        private System.Windows.Forms.ComboBox cbFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha1;
        private System.Windows.Forms.DateTimePicker dtpFecha2;
        private System.Windows.Forms.Button btnBuscar;
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
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.TextBox txtCategoria;
        private System.Windows.Forms.GroupBox grbResumenVentasCategorias;
        private System.Windows.Forms.DataGridView dgvTotales;
        private System.Windows.Forms.Button btnCategorias;
        private System.Windows.Forms.Button btnBuscarTotalesCategoria;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Categoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.TextBox txtTotalVentasCategorias;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtValorCategoriaRemision;
        private System.Windows.Forms.TextBox txtNameCategoriaRemision;
        private System.Windows.Forms.TextBox txtCodCategoriaRemision;
        private System.Windows.Forms.TextBox txtTotalCategoriaVentaRemision;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtValorCatVerduraRemision;
        private System.Windows.Forms.TextBox txtTotalCatVerduraVentaRemision;
        private System.Windows.Forms.TextBox txtNameCategoriaVerdura;
        private System.Windows.Forms.TextBox txtCodCategoriaVerdura;
        private System.Windows.Forms.Label label3;
    }
}