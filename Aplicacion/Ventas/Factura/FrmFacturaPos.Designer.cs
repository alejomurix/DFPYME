namespace Aplicacion.Ventas.Factura
{
    partial class FrmFacturaPos
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFacturaPos));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbDatosCliente = new System.Windows.Forms.GroupBox();
            this.txtTipoCliente = new System.Windows.Forms.TextBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.btnBuscarCliente = new System.Windows.Forms.Button();
            this.txtNombreCliente = new System.Windows.Forms.TextBox();
            this.lblFechaIngreso = new System.Windows.Forms.Label();
            this.gbDatosFactura = new System.Windows.Forms.GroupBox();
            this.dtpLimite = new System.Windows.Forms.DateTimePicker();
            this.cbDescuentoProducto = new System.Windows.Forms.ComboBox();
            this.cbRecargoProducto = new System.Windows.Forms.ComboBox();
            this.lblFechaLimite = new System.Windows.Forms.Label();
            this.cbDesctoRecargo = new System.Windows.Forms.ComboBox();
            this.cbContado = new System.Windows.Forms.ComboBox();
            this.dtpFechaLimite = new System.Windows.Forms.DateTimePicker();
            this.rbtnDesctoProducto = new System.Windows.Forms.RadioButton();
            this.pbProducto = new System.Windows.Forms.PictureBox();
            this.rbtnDesctoFactura = new System.Windows.Forms.RadioButton();
            this.btnTallaYcolor = new System.Windows.Forms.Button();
            this.pbFactura = new System.Windows.Forms.PictureBox();
            this.lblDescuentoFactura = new System.Windows.Forms.Label();
            this.txtDescuentoFactura = new System.Windows.Forms.TextBox();
            this.lblDataFecha = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblNoFactura = new System.Windows.Forms.Label();
            this.tsMenuPrincipal = new System.Windows.Forms.ToolStrip();
            this.tsBtnModoCantidad = new System.Windows.Forms.ToolStripButton();
            this.tsBtnDevolucion = new System.Windows.Forms.ToolStripButton();
            this.tsCambiarPrecio = new System.Windows.Forms.ToolStripButton();
            this.tsBtnFormularioVenta = new System.Windows.Forms.ToolStripButton();
            this.tsRealizarVenta = new System.Windows.Forms.ToolStripButton();
            this.tsBtnRetiro = new System.Windows.Forms.ToolStripButton();
            this.tsBtnReset = new System.Windows.Forms.ToolStripButton();
            this.tsBtnSalida = new System.Windows.Forms.ToolStripButton();
            this.tsBtnSalir = new System.Windows.Forms.ToolStripButton();
            this.gbCargaProducto = new System.Windows.Forms.GroupBox();
            this.panelPrecioProducto = new System.Windows.Forms.Panel();
            this.lblPrecioProducto = new System.Windows.Forms.Label();
            this.lblProducto = new System.Windows.Forms.Label();
            this.txtCodigoArticulo = new System.Windows.Forms.TextBox();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.txtValorUnitario = new System.Windows.Forms.TextBox();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.panelProducto = new System.Windows.Forms.Panel();
            this.lblDatosProducto = new System.Windows.Forms.Label();
            this.gbListadoArticulos = new System.Windows.Forms.GroupBox();
            this.btnBorrarImpstoBolsas = new System.Windows.Forms.Button();
            this.txtIcoBolsaCant = new System.Windows.Forms.TextBox();
            this.txtIcoBolsaUnit = new System.Windows.Forms.TextBox();
            this.txtIcoBolsaTotal = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCambiarRetencion = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblRetencion = new System.Windows.Forms.Label();
            this.txtSubtotal = new System.Windows.Forms.TextBox();
            this.txtRetencion = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTasaRetencion = new System.Windows.Forms.Label();
            this.dgvListaArticulos = new Aplicacion.Ventas.Factura.DataGridViewPlus();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Articulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Medida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Color = new System.Windows.Forms.DataGridViewImageColumn();
            this.CLote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorMenosDescto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Iva = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalMasIva = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Retorno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnInfoRete = new System.Windows.Forms.Button();
            this.lblPesoRetencion = new System.Windows.Forms.Label();
            this.txtTotalMenosRete = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gbTotal = new System.Windows.Forms.GroupBox();
            this.chkFacturaPos = new System.Windows.Forms.CheckBox();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.chkAntigua = new System.Windows.Forms.CheckBox();
            this.gbEstado = new System.Windows.Forms.GroupBox();
            this.lblInfoEstado = new System.Windows.Forms.Label();
            this.printForm1 = new Microsoft.VisualBasic.PowerPacks.Printing.PrintForm(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBoxVenta = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.gbDatosCliente.SuspendLayout();
            this.gbDatosFactura.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProducto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFactura)).BeginInit();
            this.tsMenuPrincipal.SuspendLayout();
            this.gbCargaProducto.SuspendLayout();
            this.panelPrecioProducto.SuspendLayout();
            this.panelProducto.SuspendLayout();
            this.gbListadoArticulos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaArticulos)).BeginInit();
            this.gbTotal.SuspendLayout();
            this.gbEstado.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxVenta)).BeginInit();
            this.SuspendLayout();
            // 
            // gbDatosCliente
            // 
            this.gbDatosCliente.Controls.Add(this.txtTipoCliente);
            this.gbDatosCliente.Controls.Add(this.lblCliente);
            this.gbDatosCliente.Controls.Add(this.txtCliente);
            this.gbDatosCliente.Controls.Add(this.btnBuscarCliente);
            this.gbDatosCliente.Controls.Add(this.txtNombreCliente);
            this.gbDatosCliente.Controls.Add(this.lblFechaIngreso);
            this.gbDatosCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.gbDatosCliente.Location = new System.Drawing.Point(3, 25);
            this.gbDatosCliente.Name = "gbDatosCliente";
            this.gbDatosCliente.Size = new System.Drawing.Size(809, 56);
            this.gbDatosCliente.TabIndex = 0;
            this.gbDatosCliente.TabStop = false;
            this.gbDatosCliente.Text = "Datos de Cliente";
            // 
            // txtTipoCliente
            // 
            this.txtTipoCliente.Enabled = false;
            this.txtTipoCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTipoCliente.Location = new System.Drawing.Point(553, 19);
            this.txtTipoCliente.Name = "txtTipoCliente";
            this.txtTipoCliente.Size = new System.Drawing.Size(246, 22);
            this.txtTipoCliente.TabIndex = 12;
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblCliente.Location = new System.Drawing.Point(8, 24);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(49, 16);
            this.lblCliente.TabIndex = 9;
            this.lblCliente.Text = "Cliente";
            // 
            // txtCliente
            // 
            this.txtCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCliente.Location = new System.Drawing.Point(68, 21);
            this.txtCliente.MaxLength = 20;
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(104, 22);
            this.txtCliente.TabIndex = 1;
            this.txtCliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCliente_KeyPress);
            this.txtCliente.Validating += new System.ComponentModel.CancelEventHandler(this.txtCliente_Validating);
            // 
            // btnBuscarCliente
            // 
            this.btnBuscarCliente.Location = new System.Drawing.Point(182, 21);
            this.btnBuscarCliente.Name = "btnBuscarCliente";
            this.btnBuscarCliente.Size = new System.Drawing.Size(25, 22);
            this.btnBuscarCliente.TabIndex = 1;
            this.btnBuscarCliente.Text = "...";
            this.btnBuscarCliente.UseVisualStyleBackColor = true;
            this.btnBuscarCliente.Click += new System.EventHandler(this.btnBuscarCliente_Click);
            // 
            // txtNombreCliente
            // 
            this.txtNombreCliente.Enabled = false;
            this.txtNombreCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreCliente.Location = new System.Drawing.Point(227, 19);
            this.txtNombreCliente.Name = "txtNombreCliente";
            this.txtNombreCliente.Size = new System.Drawing.Size(321, 22);
            this.txtNombreCliente.TabIndex = 2;
            // 
            // lblFechaIngreso
            // 
            this.lblFechaIngreso.AutoSize = true;
            this.lblFechaIngreso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblFechaIngreso.Location = new System.Drawing.Point(351, 56);
            this.lblFechaIngreso.Name = "lblFechaIngreso";
            this.lblFechaIngreso.Size = new System.Drawing.Size(0, 16);
            this.lblFechaIngreso.TabIndex = 11;
            // 
            // gbDatosFactura
            // 
            this.gbDatosFactura.Controls.Add(this.dtpLimite);
            this.gbDatosFactura.Controls.Add(this.cbDescuentoProducto);
            this.gbDatosFactura.Controls.Add(this.cbRecargoProducto);
            this.gbDatosFactura.Controls.Add(this.lblFechaLimite);
            this.gbDatosFactura.Controls.Add(this.cbDesctoRecargo);
            this.gbDatosFactura.Controls.Add(this.cbContado);
            this.gbDatosFactura.Controls.Add(this.dtpFechaLimite);
            this.gbDatosFactura.Controls.Add(this.rbtnDesctoProducto);
            this.gbDatosFactura.Controls.Add(this.pbProducto);
            this.gbDatosFactura.Controls.Add(this.rbtnDesctoFactura);
            this.gbDatosFactura.Controls.Add(this.btnTallaYcolor);
            this.gbDatosFactura.Controls.Add(this.pbFactura);
            this.gbDatosFactura.Controls.Add(this.lblDescuentoFactura);
            this.gbDatosFactura.Controls.Add(this.txtDescuentoFactura);
            this.gbDatosFactura.Controls.Add(this.lblDataFecha);
            this.gbDatosFactura.Controls.Add(this.lblFecha);
            this.gbDatosFactura.Location = new System.Drawing.Point(3, 83);
            this.gbDatosFactura.Name = "gbDatosFactura";
            this.gbDatosFactura.Size = new System.Drawing.Size(809, 57);
            this.gbDatosFactura.TabIndex = 3;
            this.gbDatosFactura.TabStop = false;
            this.gbDatosFactura.Text = "Datos de Factura";
            // 
            // dtpLimite
            // 
            this.dtpLimite.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpLimite.Location = new System.Drawing.Point(456, 21);
            this.dtpLimite.Name = "dtpLimite";
            this.dtpLimite.Size = new System.Drawing.Size(92, 22);
            this.dtpLimite.TabIndex = 24;
            this.dtpLimite.Visible = false;
            // 
            // cbDescuentoProducto
            // 
            this.cbDescuentoProducto.DisplayMember = "valordescuento";
            this.cbDescuentoProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDescuentoProducto.Enabled = false;
            this.cbDescuentoProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.cbDescuentoProducto.FormattingEnabled = true;
            this.cbDescuentoProducto.Location = new System.Drawing.Point(792, 15);
            this.cbDescuentoProducto.Name = "cbDescuentoProducto";
            this.cbDescuentoProducto.Size = new System.Drawing.Size(10, 33);
            this.cbDescuentoProducto.TabIndex = 2;
            this.cbDescuentoProducto.ValueMember = "iddescuento";
            this.cbDescuentoProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbDescuentoProducto_KeyPress);
            // 
            // cbRecargoProducto
            // 
            this.cbRecargoProducto.DisplayMember = "valorRecargo";
            this.cbRecargoProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRecargoProducto.Enabled = false;
            this.cbRecargoProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.cbRecargoProducto.FormattingEnabled = true;
            this.cbRecargoProducto.Location = new System.Drawing.Point(789, 16);
            this.cbRecargoProducto.Name = "cbRecargoProducto";
            this.cbRecargoProducto.Size = new System.Drawing.Size(10, 33);
            this.cbRecargoProducto.TabIndex = 2;
            this.cbRecargoProducto.ValueMember = "IdRecargo";
            this.cbRecargoProducto.Visible = false;
            this.cbRecargoProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbRecargoProducto_KeyPress);
            // 
            // lblFechaLimite
            // 
            this.lblFechaLimite.AutoSize = true;
            this.lblFechaLimite.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblFechaLimite.Location = new System.Drawing.Point(411, 24);
            this.lblFechaLimite.Name = "lblFechaLimite";
            this.lblFechaLimite.Size = new System.Drawing.Size(43, 16);
            this.lblFechaLimite.TabIndex = 23;
            this.lblFechaLimite.Text = "Limite";
            this.lblFechaLimite.Visible = false;
            // 
            // cbDesctoRecargo
            // 
            this.cbDesctoRecargo.DisplayMember = "Nombre";
            this.cbDesctoRecargo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDesctoRecargo.FormattingEnabled = true;
            this.cbDesctoRecargo.Location = new System.Drawing.Point(122, 22);
            this.cbDesctoRecargo.Name = "cbDesctoRecargo";
            this.cbDesctoRecargo.Size = new System.Drawing.Size(110, 24);
            this.cbDesctoRecargo.TabIndex = 22;
            this.cbDesctoRecargo.ValueMember = "Id";
            this.cbDesctoRecargo.SelectionChangeCommitted += new System.EventHandler(this.tsCbDesctoRecargo_SelectedIndexChanged);
            // 
            // cbContado
            // 
            this.cbContado.DisplayMember = "descripcionestado";
            this.cbContado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbContado.FormattingEnabled = true;
            this.cbContado.Location = new System.Drawing.Point(8, 22);
            this.cbContado.Name = "cbContado";
            this.cbContado.Size = new System.Drawing.Size(110, 24);
            this.cbContado.TabIndex = 21;
            this.cbContado.ValueMember = "idestado";
            this.cbContado.SelectionChangeCommitted += new System.EventHandler(this.tsCbContado_SelectedIndexChanged);
            // 
            // dtpFechaLimite
            // 
            this.dtpFechaLimite.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaLimite.Location = new System.Drawing.Point(304, 21);
            this.dtpFechaLimite.Name = "dtpFechaLimite";
            this.dtpFechaLimite.Size = new System.Drawing.Size(92, 22);
            this.dtpFechaLimite.TabIndex = 0;
            this.dtpFechaLimite.Visible = false;
            this.dtpFechaLimite.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtpFechaLimite_KeyPress);
            this.dtpFechaLimite.Validating += new System.ComponentModel.CancelEventHandler(this.dtpFechaLimite_Validating);
            // 
            // rbtnDesctoProducto
            // 
            this.rbtnDesctoProducto.AutoSize = true;
            this.rbtnDesctoProducto.Enabled = false;
            this.rbtnDesctoProducto.Location = new System.Drawing.Point(553, 24);
            this.rbtnDesctoProducto.Name = "rbtnDesctoProducto";
            this.rbtnDesctoProducto.Size = new System.Drawing.Size(14, 13);
            this.rbtnDesctoProducto.TabIndex = 15;
            this.rbtnDesctoProducto.UseVisualStyleBackColor = true;
            this.rbtnDesctoProducto.Click += new System.EventHandler(this.rbtnDesctoProducto_Click);
            // 
            // pbProducto
            // 
            this.pbProducto.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbProducto.BackgroundImage")));
            this.pbProducto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbProducto.InitialImage = null;
            this.pbProducto.Location = new System.Drawing.Point(573, 19);
            this.pbProducto.Name = "pbProducto";
            this.pbProducto.Size = new System.Drawing.Size(24, 24);
            this.pbProducto.TabIndex = 18;
            this.pbProducto.TabStop = false;
            this.pbProducto.Tag = "";
            // 
            // rbtnDesctoFactura
            // 
            this.rbtnDesctoFactura.AutoSize = true;
            this.rbtnDesctoFactura.Checked = true;
            this.rbtnDesctoFactura.Enabled = false;
            this.rbtnDesctoFactura.Location = new System.Drawing.Point(609, 24);
            this.rbtnDesctoFactura.Name = "rbtnDesctoFactura";
            this.rbtnDesctoFactura.Size = new System.Drawing.Size(14, 13);
            this.rbtnDesctoFactura.TabIndex = 16;
            this.rbtnDesctoFactura.TabStop = true;
            this.rbtnDesctoFactura.UseVisualStyleBackColor = true;
            this.rbtnDesctoFactura.Click += new System.EventHandler(this.rbtnDesctoFactura_Click);
            // 
            // btnTallaYcolor
            // 
            this.btnTallaYcolor.Enabled = false;
            this.btnTallaYcolor.FlatAppearance.BorderSize = 0;
            this.btnTallaYcolor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTallaYcolor.Image = ((System.Drawing.Image)(resources.GetObject("btnTallaYcolor.Image")));
            this.btnTallaYcolor.Location = new System.Drawing.Point(773, 23);
            this.btnTallaYcolor.Name = "btnTallaYcolor";
            this.btnTallaYcolor.Size = new System.Drawing.Size(11, 17);
            this.btnTallaYcolor.TabIndex = 3;
            this.btnTallaYcolor.UseVisualStyleBackColor = true;
            this.btnTallaYcolor.Visible = false;
            this.btnTallaYcolor.Click += new System.EventHandler(this.btnTallaYcolor_Click);
            // 
            // pbFactura
            // 
            this.pbFactura.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbFactura.BackgroundImage")));
            this.pbFactura.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbFactura.InitialImage = null;
            this.pbFactura.Location = new System.Drawing.Point(629, 19);
            this.pbFactura.Name = "pbFactura";
            this.pbFactura.Size = new System.Drawing.Size(24, 24);
            this.pbFactura.TabIndex = 19;
            this.pbFactura.TabStop = false;
            this.pbFactura.Tag = "";
            // 
            // lblDescuentoFactura
            // 
            this.lblDescuentoFactura.AutoSize = true;
            this.lblDescuentoFactura.Location = new System.Drawing.Point(656, 24);
            this.lblDescuentoFactura.Name = "lblDescuentoFactura";
            this.lblDescuentoFactura.Size = new System.Drawing.Size(81, 16);
            this.lblDescuentoFactura.TabIndex = 20;
            this.lblDescuentoFactura.Text = "Descto/Fact";
            // 
            // txtDescuentoFactura
            // 
            this.txtDescuentoFactura.Enabled = false;
            this.txtDescuentoFactura.Location = new System.Drawing.Point(746, 21);
            this.txtDescuentoFactura.MaxLength = 5;
            this.txtDescuentoFactura.Name = "txtDescuentoFactura";
            this.txtDescuentoFactura.Size = new System.Drawing.Size(21, 22);
            this.txtDescuentoFactura.TabIndex = 1;
            this.txtDescuentoFactura.Text = "0";
            this.txtDescuentoFactura.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescuentoFactura_KeyPress);
            this.txtDescuentoFactura.Validating += new System.ComponentModel.CancelEventHandler(this.txtDescuentoFactura_Validating);
            // 
            // lblDataFecha
            // 
            this.lblDataFecha.AutoSize = true;
            this.lblDataFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblDataFecha.Location = new System.Drawing.Point(291, 25);
            this.lblDataFecha.Name = "lblDataFecha";
            this.lblDataFecha.Size = new System.Drawing.Size(124, 16);
            this.lblDataFecha.TabIndex = 13;
            this.lblDataFecha.Text = "7  de Mayo de 2013";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblFecha.Location = new System.Drawing.Point(238, 25);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(46, 16);
            this.lblFecha.TabIndex = 14;
            this.lblFecha.Text = "Fecha";
            // 
            // lblNoFactura
            // 
            this.lblNoFactura.AutoSize = true;
            this.lblNoFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoFactura.ForeColor = System.Drawing.Color.Red;
            this.lblNoFactura.Location = new System.Drawing.Point(200, 24);
            this.lblNoFactura.Name = "lblNoFactura";
            this.lblNoFactura.Size = new System.Drawing.Size(16, 16);
            this.lblNoFactura.TabIndex = 13;
            this.lblNoFactura.Text = "0";
            this.lblNoFactura.Visible = false;
            // 
            // tsMenuPrincipal
            // 
            this.tsMenuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnModoCantidad,
            this.tsBtnDevolucion,
            this.tsCambiarPrecio,
            this.tsBtnFormularioVenta,
            this.tsRealizarVenta,
            this.tsBtnRetiro,
            this.tsBtnReset,
            this.tsBtnSalida,
            this.tsBtnSalir});
            this.tsMenuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.tsMenuPrincipal.Name = "tsMenuPrincipal";
            this.tsMenuPrincipal.Size = new System.Drawing.Size(1046, 25);
            this.tsMenuPrincipal.TabIndex = 4;
            // 
            // tsBtnModoCantidad
            // 
            this.tsBtnModoCantidad.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsBtnModoCantidad.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnModoCantidad.Image")));
            this.tsBtnModoCantidad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnModoCantidad.Name = "tsBtnModoCantidad";
            this.tsBtnModoCantidad.Size = new System.Drawing.Size(135, 22);
            this.tsBtnModoCantidad.Text = "Mod cantidad [F4]";
            this.tsBtnModoCantidad.Click += new System.EventHandler(this.tsBtnModoCantidad_Click);
            // 
            // tsBtnDevolucion
            // 
            this.tsBtnDevolucion.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsBtnDevolucion.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnDevolucion.Image")));
            this.tsBtnDevolucion.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnDevolucion.Name = "tsBtnDevolucion";
            this.tsBtnDevolucion.Size = new System.Drawing.Size(117, 22);
            this.tsBtnDevolucion.Text = "Devolucion [F5]";
            this.tsBtnDevolucion.Click += new System.EventHandler(this.tsBtnDevolucion_Click);
            // 
            // tsCambiarPrecio
            // 
            this.tsCambiarPrecio.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsCambiarPrecio.Image = ((System.Drawing.Image)(resources.GetObject("tsCambiarPrecio.Image")));
            this.tsCambiarPrecio.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsCambiarPrecio.Name = "tsCambiarPrecio";
            this.tsCambiarPrecio.Size = new System.Drawing.Size(121, 22);
            this.tsCambiarPrecio.Text = "Mod Precio [F6]";
            this.tsCambiarPrecio.Click += new System.EventHandler(this.tsCambiarPrecio_Click);
            // 
            // tsBtnFormularioVenta
            // 
            this.tsBtnFormularioVenta.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsBtnFormularioVenta.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnFormularioVenta.Image")));
            this.tsBtnFormularioVenta.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnFormularioVenta.Name = "tsBtnFormularioVenta";
            this.tsBtnFormularioVenta.Size = new System.Drawing.Size(121, 22);
            this.tsBtnFormularioVenta.Text = "Form. venta [F7]";
            this.tsBtnFormularioVenta.Click += new System.EventHandler(this.tsBtnFormularioVenta_Click);
            // 
            // tsRealizarVenta
            // 
            this.tsRealizarVenta.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsRealizarVenta.Image = ((System.Drawing.Image)(resources.GetObject("tsRealizarVenta.Image")));
            this.tsRealizarVenta.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsRealizarVenta.Name = "tsRealizarVenta";
            this.tsRealizarVenta.Size = new System.Drawing.Size(135, 22);
            this.tsRealizarVenta.Text = "Realizar Venta [F8]";
            this.tsRealizarVenta.Click += new System.EventHandler(this.tsRealizarVenta_Click);
            // 
            // tsBtnRetiro
            // 
            this.tsBtnRetiro.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsBtnRetiro.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnRetiro.Image")));
            this.tsBtnRetiro.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnRetiro.Name = "tsBtnRetiro";
            this.tsBtnRetiro.Size = new System.Drawing.Size(99, 22);
            this.tsBtnRetiro.Text = "Eliminar [F9]";
            this.tsBtnRetiro.Click += new System.EventHandler(this.tsBtnRetiro_Click);
            // 
            // tsBtnReset
            // 
            this.tsBtnReset.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsBtnReset.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnReset.Image")));
            this.tsBtnReset.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnReset.Name = "tsBtnReset";
            this.tsBtnReset.Size = new System.Drawing.Size(92, 22);
            this.tsBtnReset.Text = "Reset [F10]";
            this.tsBtnReset.Click += new System.EventHandler(this.tsBtnReset_Click);
            // 
            // tsBtnSalida
            // 
            this.tsBtnSalida.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsBtnSalida.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnSalida.Image")));
            this.tsBtnSalida.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnSalida.Name = "tsBtnSalida";
            this.tsBtnSalida.Size = new System.Drawing.Size(95, 22);
            this.tsBtnSalida.Text = "Retiro [F12]";
            this.tsBtnSalida.Click += new System.EventHandler(this.tsBtnSalida_Click);
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
            // gbCargaProducto
            // 
            this.gbCargaProducto.Controls.Add(this.panelPrecioProducto);
            this.gbCargaProducto.Controls.Add(this.lblProducto);
            this.gbCargaProducto.Controls.Add(this.txtCodigoArticulo);
            this.gbCargaProducto.Controls.Add(this.lblCantidad);
            this.gbCargaProducto.Controls.Add(this.txtValorUnitario);
            this.gbCargaProducto.Controls.Add(this.txtCantidad);
            this.gbCargaProducto.Controls.Add(this.panelProducto);
            this.gbCargaProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.gbCargaProducto.Location = new System.Drawing.Point(3, 142);
            this.gbCargaProducto.Name = "gbCargaProducto";
            this.gbCargaProducto.Size = new System.Drawing.Size(809, 127);
            this.gbCargaProducto.TabIndex = 1;
            this.gbCargaProducto.TabStop = false;
            this.gbCargaProducto.Text = "Cargar Producto";
            // 
            // panelPrecioProducto
            // 
            this.panelPrecioProducto.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panelPrecioProducto.Controls.Add(this.lblPrecioProducto);
            this.panelPrecioProducto.Location = new System.Drawing.Point(659, 65);
            this.panelPrecioProducto.Name = "panelPrecioProducto";
            this.panelPrecioProducto.Size = new System.Drawing.Size(140, 41);
            this.panelPrecioProducto.TabIndex = 8;
            // 
            // lblPrecioProducto
            // 
            this.lblPrecioProducto.AutoSize = true;
            this.lblPrecioProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.lblPrecioProducto.Location = new System.Drawing.Point(5, 7);
            this.lblPrecioProducto.Name = "lblPrecioProducto";
            this.lblPrecioProducto.Size = new System.Drawing.Size(0, 25);
            this.lblPrecioProducto.TabIndex = 0;
            // 
            // lblProducto
            // 
            this.lblProducto.AutoSize = true;
            this.lblProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblProducto.Location = new System.Drawing.Point(7, 29);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(77, 25);
            this.lblProducto.TabIndex = 5;
            this.lblProducto.Text = "Articulo";
            // 
            // txtCodigoArticulo
            // 
            this.txtCodigoArticulo.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtCodigoArticulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.txtCodigoArticulo.Location = new System.Drawing.Point(84, 26);
            this.txtCodigoArticulo.MaxLength = 255;
            this.txtCodigoArticulo.Name = "txtCodigoArticulo";
            this.txtCodigoArticulo.Size = new System.Drawing.Size(380, 30);
            this.txtCodigoArticulo.TabIndex = 0;
            this.txtCodigoArticulo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoArticulo_KeyPress);
            this.txtCodigoArticulo.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodigoArticulo_Validating);
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblCantidad.Location = new System.Drawing.Point(470, 28);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(91, 25);
            this.lblCantidad.TabIndex = 4;
            this.lblCantidad.Text = "Cantidad";
            // 
            // txtValorUnitario
            // 
            this.txtValorUnitario.BackColor = System.Drawing.SystemColors.Window;
            this.txtValorUnitario.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.txtValorUnitario.Location = new System.Drawing.Point(659, 26);
            this.txtValorUnitario.MaxLength = 10;
            this.txtValorUnitario.Name = "txtValorUnitario";
            this.txtValorUnitario.Size = new System.Drawing.Size(140, 30);
            this.txtValorUnitario.TabIndex = 2;
            this.txtValorUnitario.Text = "0";
            this.txtValorUnitario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtValorUnitario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValorUnitario_KeyPress);
            this.txtValorUnitario.Validating += new System.ComponentModel.CancelEventHandler(this.txtCantidad_Validating);
            // 
            // txtCantidad
            // 
            this.txtCantidad.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.txtCantidad.Location = new System.Drawing.Point(561, 26);
            this.txtCantidad.MaxLength = 10;
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(95, 30);
            this.txtCantidad.TabIndex = 1;
            this.txtCantidad.Text = "1";
            this.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);
            this.txtCantidad.Validating += new System.ComponentModel.CancelEventHandler(this.txtCantidad_Validating);
            // 
            // panelProducto
            // 
            this.panelProducto.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panelProducto.Controls.Add(this.lblDatosProducto);
            this.panelProducto.Location = new System.Drawing.Point(9, 65);
            this.panelProducto.Name = "panelProducto";
            this.panelProducto.Size = new System.Drawing.Size(649, 41);
            this.panelProducto.TabIndex = 7;
            // 
            // lblDatosProducto
            // 
            this.lblDatosProducto.AutoSize = true;
            this.lblDatosProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.lblDatosProducto.Location = new System.Drawing.Point(5, 7);
            this.lblDatosProducto.Name = "lblDatosProducto";
            this.lblDatosProducto.Size = new System.Drawing.Size(0, 25);
            this.lblDatosProducto.TabIndex = 0;
            // 
            // gbListadoArticulos
            // 
            this.gbListadoArticulos.Controls.Add(this.btnBorrarImpstoBolsas);
            this.gbListadoArticulos.Controls.Add(this.txtIcoBolsaCant);
            this.gbListadoArticulos.Controls.Add(this.txtIcoBolsaUnit);
            this.gbListadoArticulos.Controls.Add(this.txtIcoBolsaTotal);
            this.gbListadoArticulos.Controls.Add(this.label1);
            this.gbListadoArticulos.Controls.Add(this.label4);
            this.gbListadoArticulos.Controls.Add(this.btnCambiarRetencion);
            this.gbListadoArticulos.Controls.Add(this.label5);
            this.gbListadoArticulos.Controls.Add(this.label8);
            this.gbListadoArticulos.Controls.Add(this.label7);
            this.gbListadoArticulos.Controls.Add(this.lblRetencion);
            this.gbListadoArticulos.Controls.Add(this.txtSubtotal);
            this.gbListadoArticulos.Controls.Add(this.txtRetencion);
            this.gbListadoArticulos.Controls.Add(this.label6);
            this.gbListadoArticulos.Controls.Add(this.lblTasaRetencion);
            this.gbListadoArticulos.Controls.Add(this.dgvListaArticulos);
            this.gbListadoArticulos.Controls.Add(this.btnInfoRete);
            this.gbListadoArticulos.Controls.Add(this.lblPesoRetencion);
            this.gbListadoArticulos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.gbListadoArticulos.Location = new System.Drawing.Point(3, 275);
            this.gbListadoArticulos.Name = "gbListadoArticulos";
            this.gbListadoArticulos.Size = new System.Drawing.Size(1038, 355);
            this.gbListadoArticulos.TabIndex = 2;
            this.gbListadoArticulos.TabStop = false;
            this.gbListadoArticulos.Text = "Listado de Articulos";
            // 
            // btnBorrarImpstoBolsas
            // 
            this.btnBorrarImpstoBolsas.Image = ((System.Drawing.Image)(resources.GetObject("btnBorrarImpstoBolsas.Image")));
            this.btnBorrarImpstoBolsas.Location = new System.Drawing.Point(668, 322);
            this.btnBorrarImpstoBolsas.Name = "btnBorrarImpstoBolsas";
            this.btnBorrarImpstoBolsas.Size = new System.Drawing.Size(22, 25);
            this.btnBorrarImpstoBolsas.TabIndex = 43;
            this.btnBorrarImpstoBolsas.UseVisualStyleBackColor = true;
            this.btnBorrarImpstoBolsas.Click += new System.EventHandler(this.btnBorrarImpstoBolsas_Click);
            // 
            // txtIcoBolsaCant
            // 
            this.txtIcoBolsaCant.BackColor = System.Drawing.SystemColors.Control;
            this.txtIcoBolsaCant.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIcoBolsaCant.Location = new System.Drawing.Point(378, 323);
            this.txtIcoBolsaCant.MaxLength = 10;
            this.txtIcoBolsaCant.Name = "txtIcoBolsaCant";
            this.txtIcoBolsaCant.ReadOnly = true;
            this.txtIcoBolsaCant.Size = new System.Drawing.Size(44, 22);
            this.txtIcoBolsaCant.TabIndex = 42;
            this.txtIcoBolsaCant.Text = "0";
            this.txtIcoBolsaCant.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtIcoBolsaUnit
            // 
            this.txtIcoBolsaUnit.BackColor = System.Drawing.SystemColors.Control;
            this.txtIcoBolsaUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIcoBolsaUnit.Location = new System.Drawing.Point(480, 323);
            this.txtIcoBolsaUnit.MaxLength = 10;
            this.txtIcoBolsaUnit.Name = "txtIcoBolsaUnit";
            this.txtIcoBolsaUnit.ReadOnly = true;
            this.txtIcoBolsaUnit.Size = new System.Drawing.Size(52, 22);
            this.txtIcoBolsaUnit.TabIndex = 42;
            this.txtIcoBolsaUnit.Text = "0";
            this.txtIcoBolsaUnit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtIcoBolsaTotal
            // 
            this.txtIcoBolsaTotal.BackColor = System.Drawing.SystemColors.Control;
            this.txtIcoBolsaTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIcoBolsaTotal.Location = new System.Drawing.Point(586, 323);
            this.txtIcoBolsaTotal.MaxLength = 10;
            this.txtIcoBolsaTotal.Name = "txtIcoBolsaTotal";
            this.txtIcoBolsaTotal.ReadOnly = true;
            this.txtIcoBolsaTotal.Size = new System.Drawing.Size(80, 22);
            this.txtIcoBolsaTotal.TabIndex = 42;
            this.txtIcoBolsaTotal.Text = "0";
            this.txtIcoBolsaTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 326);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 16);
            this.label1.TabIndex = 40;
            this.label1.Text = "SUB-TOTAL:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(102, 326);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 16);
            this.label4.TabIndex = 41;
            this.label4.Text = "$";
            // 
            // btnCambiarRetencion
            // 
            this.btnCambiarRetencion.Enabled = false;
            this.btnCambiarRetencion.Image = ((System.Drawing.Image)(resources.GetObject("btnCambiarRetencion.Image")));
            this.btnCambiarRetencion.Location = new System.Drawing.Point(1009, 321);
            this.btnCambiarRetencion.Name = "btnCambiarRetencion";
            this.btnCambiarRetencion.Size = new System.Drawing.Size(22, 26);
            this.btnCambiarRetencion.TabIndex = 38;
            this.btnCambiarRetencion.UseVisualStyleBackColor = true;
            this.btnCambiarRetencion.Click += new System.EventHandler(this.btnCambiarRetencion_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(245, 326);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 16);
            this.label5.TabIndex = 34;
            this.label5.Text = "IMP. BOLSA:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(544, 326);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 16);
            this.label8.TabIndex = 36;
            this.label8.Text = "Total";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(432, 326);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 16);
            this.label7.TabIndex = 36;
            this.label7.Text = "V. Unit.";
            // 
            // lblRetencion
            // 
            this.lblRetencion.AutoSize = true;
            this.lblRetencion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRetencion.Location = new System.Drawing.Point(702, 326);
            this.lblRetencion.Name = "lblRetencion";
            this.lblRetencion.Size = new System.Drawing.Size(100, 16);
            this.lblRetencion.TabIndex = 34;
            this.lblRetencion.Text = "RETENCION:";
            // 
            // txtSubtotal
            // 
            this.txtSubtotal.BackColor = System.Drawing.SystemColors.Control;
            this.txtSubtotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubtotal.Location = new System.Drawing.Point(117, 323);
            this.txtSubtotal.MaxLength = 10000;
            this.txtSubtotal.Name = "txtSubtotal";
            this.txtSubtotal.ReadOnly = true;
            this.txtSubtotal.Size = new System.Drawing.Size(105, 22);
            this.txtSubtotal.TabIndex = 33;
            this.txtSubtotal.Text = "0";
            this.txtSubtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtRetencion
            // 
            this.txtRetencion.BackColor = System.Drawing.SystemColors.Control;
            this.txtRetencion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRetencion.Location = new System.Drawing.Point(823, 323);
            this.txtRetencion.MaxLength = 10;
            this.txtRetencion.Name = "txtRetencion";
            this.txtRetencion.ReadOnly = true;
            this.txtRetencion.Size = new System.Drawing.Size(121, 22);
            this.txtRetencion.TabIndex = 33;
            this.txtRetencion.Text = "0";
            this.txtRetencion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(341, 326);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 16);
            this.label6.TabIndex = 36;
            this.label6.Text = "Cant.";
            // 
            // lblTasaRetencion
            // 
            this.lblTasaRetencion.AutoSize = true;
            this.lblTasaRetencion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTasaRetencion.Location = new System.Drawing.Point(947, 326);
            this.lblTasaRetencion.Name = "lblTasaRetencion";
            this.lblTasaRetencion.Size = new System.Drawing.Size(27, 16);
            this.lblTasaRetencion.TabIndex = 36;
            this.lblTasaRetencion.Text = "0%";
            // 
            // dgvListaArticulos
            // 
            this.dgvListaArticulos.AllowUserToAddRows = false;
            this.dgvListaArticulos.AllowUserToResizeColumns = false;
            this.dgvListaArticulos.AllowUserToResizeRows = false;
            this.dgvListaArticulos.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvListaArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaArticulos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Codigo,
            this.Articulo,
            this.Unidad,
            this.Medida,
            this.Color,
            this.CLote,
            this.Cantidad,
            this.Valor,
            this.Descuento,
            this.ValorMenosDescto,
            this.Iva,
            this.TotalMasIva,
            this.Total,
            this.Retorno});
            this.dgvListaArticulos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvListaArticulos.Location = new System.Drawing.Point(4, 18);
            this.dgvListaArticulos.Name = "dgvListaArticulos";
            this.dgvListaArticulos.RowHeadersVisible = false;
            this.dgvListaArticulos.Size = new System.Drawing.Size(1028, 297);
            this.dgvListaArticulos.TabIndex = 0;
            this.dgvListaArticulos.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvListaArticulos_CellValidating);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            this.Id.Width = 112;
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
            this.Articulo.Width = 406;
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
            // Medida
            // 
            this.Medida.DataPropertyName = "Medida";
            this.Medida.HeaderText = "Medida";
            this.Medida.Name = "Medida";
            this.Medida.Visible = false;
            this.Medida.Width = 60;
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
            // CLote
            // 
            this.CLote.DataPropertyName = "Lote";
            this.CLote.HeaderText = "Lote";
            this.CLote.Name = "CLote";
            this.CLote.Visible = false;
            this.CLote.Width = 60;
            // 
            // Cantidad
            // 
            this.Cantidad.DataPropertyName = "Cantidad";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = null;
            this.Cantidad.DefaultCellStyle = dataGridViewCellStyle1;
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            this.Cantidad.Width = 90;
            // 
            // Valor
            // 
            this.Valor.DataPropertyName = "ValorUnitario";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.Valor.DefaultCellStyle = dataGridViewCellStyle2;
            this.Valor.HeaderText = "Valor Unitario";
            this.Valor.Name = "Valor";
            this.Valor.ReadOnly = true;
            this.Valor.Width = 112;
            // 
            // Descuento
            // 
            this.Descuento.DataPropertyName = "Descuento";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.NullValue = null;
            this.Descuento.DefaultCellStyle = dataGridViewCellStyle3;
            this.Descuento.HeaderText = "Descto";
            this.Descuento.Name = "Descuento";
            this.Descuento.ReadOnly = true;
            this.Descuento.Width = 57;
            // 
            // ValorMenosDescto
            // 
            this.ValorMenosDescto.DataPropertyName = "ValorMenosDescto";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = null;
            this.ValorMenosDescto.DefaultCellStyle = dataGridViewCellStyle4;
            this.ValorMenosDescto.HeaderText = "Valor - Descto";
            this.ValorMenosDescto.Name = "ValorMenosDescto";
            this.ValorMenosDescto.ReadOnly = true;
            this.ValorMenosDescto.Visible = false;
            this.ValorMenosDescto.Width = 116;
            // 
            // Iva
            // 
            this.Iva.DataPropertyName = "Iva";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Iva.DefaultCellStyle = dataGridViewCellStyle5;
            this.Iva.HeaderText = "Iva";
            this.Iva.Name = "Iva";
            this.Iva.ReadOnly = true;
            this.Iva.Width = 43;
            // 
            // TotalMasIva
            // 
            this.TotalMasIva.DataPropertyName = "TotalMasIva";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N0";
            dataGridViewCellStyle6.NullValue = null;
            this.TotalMasIva.DefaultCellStyle = dataGridViewCellStyle6;
            this.TotalMasIva.HeaderText = "Valor + Iva";
            this.TotalMasIva.Name = "TotalMasIva";
            this.TotalMasIva.ReadOnly = true;
            this.TotalMasIva.Width = 110;
            // 
            // Total
            // 
            this.Total.DataPropertyName = "Valor";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N0";
            dataGridViewCellStyle7.NullValue = null;
            this.Total.DefaultCellStyle = dataGridViewCellStyle7;
            this.Total.HeaderText = "Valor Total";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            this.Total.Width = 110;
            // 
            // Retorno
            // 
            this.Retorno.DataPropertyName = "Retorno";
            this.Retorno.HeaderText = "Retorno";
            this.Retorno.Name = "Retorno";
            this.Retorno.Visible = false;
            // 
            // btnInfoRete
            // 
            this.btnInfoRete.Enabled = false;
            this.btnInfoRete.FlatAppearance.BorderSize = 0;
            this.btnInfoRete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInfoRete.Image = ((System.Drawing.Image)(resources.GetObject("btnInfoRete.Image")));
            this.btnInfoRete.Location = new System.Drawing.Point(980, 321);
            this.btnInfoRete.Name = "btnInfoRete";
            this.btnInfoRete.Size = new System.Drawing.Size(25, 23);
            this.btnInfoRete.TabIndex = 37;
            this.btnInfoRete.UseVisualStyleBackColor = true;
            // 
            // lblPesoRetencion
            // 
            this.lblPesoRetencion.AutoSize = true;
            this.lblPesoRetencion.Location = new System.Drawing.Point(806, 326);
            this.lblPesoRetencion.Name = "lblPesoRetencion";
            this.lblPesoRetencion.Size = new System.Drawing.Size(15, 16);
            this.lblPesoRetencion.TabIndex = 35;
            this.lblPesoRetencion.Text = "$";
            // 
            // txtTotalMenosRete
            // 
            this.txtTotalMenosRete.BackColor = System.Drawing.Color.PaleTurquoise;
            this.txtTotalMenosRete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalMenosRete.Location = new System.Drawing.Point(186, 26);
            this.txtTotalMenosRete.MaxLength = 10;
            this.txtTotalMenosRete.Name = "txtTotalMenosRete";
            this.txtTotalMenosRete.ReadOnly = true;
            this.txtTotalMenosRete.Size = new System.Drawing.Size(21, 22);
            this.txtTotalMenosRete.TabIndex = 39;
            this.txtTotalMenosRete.Text = "0";
            this.txtTotalMenosRete.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotalMenosRete.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 31);
            this.label2.TabIndex = 8;
            this.label2.Text = "TOTAL :";
            // 
            // gbTotal
            // 
            this.gbTotal.Controls.Add(this.chkFacturaPos);
            this.gbTotal.Controls.Add(this.txtTotal);
            this.gbTotal.Controls.Add(this.chkAntigua);
            this.gbTotal.Controls.Add(this.label2);
            this.gbTotal.Controls.Add(this.txtTotalMenosRete);
            this.gbTotal.Location = new System.Drawing.Point(818, 142);
            this.gbTotal.Name = "gbTotal";
            this.gbTotal.Size = new System.Drawing.Size(223, 127);
            this.gbTotal.TabIndex = 11;
            this.gbTotal.TabStop = false;
            // 
            // chkFacturaPos
            // 
            this.chkFacturaPos.AutoSize = true;
            this.chkFacturaPos.Location = new System.Drawing.Point(156, 33);
            this.chkFacturaPos.Name = "chkFacturaPos";
            this.chkFacturaPos.Size = new System.Drawing.Size(15, 14);
            this.chkFacturaPos.TabIndex = 1;
            this.chkFacturaPos.UseVisualStyleBackColor = true;
            this.chkFacturaPos.Visible = false;
            this.chkFacturaPos.Click += new System.EventHandler(this.chkFacturaPos_Click);
            // 
            // txtTotal
            // 
            this.txtTotal.BackColor = System.Drawing.Color.PaleTurquoise;
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(7, 66);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(210, 38);
            this.txtTotal.TabIndex = 12;
            this.txtTotal.Text = "0";
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // chkAntigua
            // 
            this.chkAntigua.AutoSize = true;
            this.chkAntigua.Location = new System.Drawing.Point(135, 33);
            this.chkAntigua.Name = "chkAntigua";
            this.chkAntigua.Size = new System.Drawing.Size(15, 14);
            this.chkAntigua.TabIndex = 0;
            this.chkAntigua.UseVisualStyleBackColor = true;
            this.chkAntigua.Visible = false;
            this.chkAntigua.Click += new System.EventHandler(this.chkAntigua_Click);
            // 
            // gbEstado
            // 
            this.gbEstado.Controls.Add(this.lblInfoEstado);
            this.gbEstado.Controls.Add(this.lblNoFactura);
            this.gbEstado.Location = new System.Drawing.Point(818, 27);
            this.gbEstado.Name = "gbEstado";
            this.gbEstado.Size = new System.Drawing.Size(223, 54);
            this.gbEstado.TabIndex = 14;
            this.gbEstado.TabStop = false;
            this.gbEstado.Text = "Estado";
            // 
            // lblInfoEstado
            // 
            this.lblInfoEstado.AutoSize = true;
            this.lblInfoEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfoEstado.Location = new System.Drawing.Point(10, 22);
            this.lblInfoEstado.Name = "lblInfoEstado";
            this.lblInfoEstado.Size = new System.Drawing.Size(157, 18);
            this.lblInfoEstado.TabIndex = 0;
            this.lblInfoEstado.Text = "Factura de Contado";
            // 
            // printForm1
            // 
            this.printForm1.DocumentName = "document";
            this.printForm1.Form = this;
            this.printForm1.PrintAction = System.Drawing.Printing.PrintAction.PrintToPreview;
            this.printForm1.PrinterSettings = ((System.Drawing.Printing.PrinterSettings)(resources.GetObject("printForm1.PrinterSettings")));
            this.printForm1.PrintFileName = null;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Aquamarine;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pictureBoxVenta);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(818, 87);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(223, 53);
            this.panel1.TabIndex = 16;
            // 
            // pictureBoxVenta
            // 
            this.pictureBoxVenta.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxVenta.Image")));
            this.pictureBoxVenta.InitialImage = null;
            this.pictureBoxVenta.Location = new System.Drawing.Point(134, 7);
            this.pictureBoxVenta.Name = "pictureBoxVenta";
            this.pictureBoxVenta.Size = new System.Drawing.Size(43, 36);
            this.pictureBoxVenta.TabIndex = 2;
            this.pictureBoxVenta.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 18);
            this.label3.TabIndex = 1;
            this.label3.Text = "Factura POS";
            // 
            // FrmFacturaPos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1046, 638);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gbEstado);
            this.Controls.Add(this.gbTotal);
            this.Controls.Add(this.gbListadoArticulos);
            this.Controls.Add(this.gbCargaProducto);
            this.Controls.Add(this.tsMenuPrincipal);
            this.Controls.Add(this.gbDatosFactura);
            this.Controls.Add(this.gbDatosCliente);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmFacturaPos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Factura POS";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmFacturaVenta_FormClosing);
            this.Load += new System.EventHandler(this.FrmFacturaVenta_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmFacturaVenta_KeyDown);
            this.gbDatosCliente.ResumeLayout(false);
            this.gbDatosCliente.PerformLayout();
            this.gbDatosFactura.ResumeLayout(false);
            this.gbDatosFactura.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProducto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFactura)).EndInit();
            this.tsMenuPrincipal.ResumeLayout(false);
            this.tsMenuPrincipal.PerformLayout();
            this.gbCargaProducto.ResumeLayout(false);
            this.gbCargaProducto.PerformLayout();
            this.panelPrecioProducto.ResumeLayout(false);
            this.panelPrecioProducto.PerformLayout();
            this.panelProducto.ResumeLayout(false);
            this.panelProducto.PerformLayout();
            this.gbListadoArticulos.ResumeLayout(false);
            this.gbListadoArticulos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaArticulos)).EndInit();
            this.gbTotal.ResumeLayout(false);
            this.gbTotal.PerformLayout();
            this.gbEstado.ResumeLayout(false);
            this.gbEstado.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxVenta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDatosCliente;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Button btnBuscarCliente;
        private System.Windows.Forms.TextBox txtNombreCliente;
        private System.Windows.Forms.Label lblFechaIngreso;
        private System.Windows.Forms.GroupBox gbDatosFactura;
        private System.Windows.Forms.Label lblNoFactura;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.ToolStrip tsMenuPrincipal;
        private System.Windows.Forms.Label lblDataFecha;
        private System.Windows.Forms.PictureBox pbProducto;
        private System.Windows.Forms.RadioButton rbtnDesctoFactura;
        private System.Windows.Forms.PictureBox pbFactura;
        private System.Windows.Forms.Label lblDescuentoFactura;
        private System.Windows.Forms.TextBox txtDescuentoFactura;
        private System.Windows.Forms.GroupBox gbCargaProducto;
        private System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Panel panelProducto;
        private System.Windows.Forms.Label lblDatosProducto;
        private System.Windows.Forms.Button btnTallaYcolor;
        private System.Windows.Forms.ComboBox cbDescuentoProducto;
        private System.Windows.Forms.GroupBox gbListadoArticulos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gbTotal;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.ComboBox cbRecargoProducto;
        private System.Windows.Forms.ToolStripButton tsRealizarVenta;
        private System.Windows.Forms.ToolStripButton tsCambiarPrecio;
        private DataGridViewPlus dgvListaArticulos;
        private System.Windows.Forms.DateTimePicker dtpFechaLimite;
        private System.Windows.Forms.GroupBox gbEstado;
        private System.Windows.Forms.Label lblInfoEstado;
        private System.Windows.Forms.ToolStripButton tsBtnSalir;
        private System.Windows.Forms.ToolStripButton tsBtnModoCantidad;
        private System.Windows.Forms.ToolStripButton tsBtnRetiro;
        private System.Windows.Forms.ToolStripButton tsBtnReset;
        private System.Windows.Forms.ComboBox cbContado;
        private System.Windows.Forms.ComboBox cbDesctoRecargo;
        private System.Windows.Forms.ToolStripButton tsBtnSalida;
        private System.Windows.Forms.CheckBox chkAntigua;
        private System.Windows.Forms.Label lblFechaLimite;
        private System.Windows.Forms.DateTimePicker dtpLimite;
        private System.Windows.Forms.Button btnCambiarRetencion;
        private System.Windows.Forms.Label lblRetencion;
        private System.Windows.Forms.TextBox txtRetencion;
        private System.Windows.Forms.Button btnInfoRete;
        private System.Windows.Forms.Label lblPesoRetencion;
        private System.Windows.Forms.Label lblTasaRetencion;
        private System.Windows.Forms.TextBox txtTotalMenosRete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkFacturaPos;
        private System.Windows.Forms.RadioButton rbtnDesctoProducto;
        public System.Windows.Forms.TextBox txtCliente;
        public System.Windows.Forms.TextBox txtCodigoArticulo;
        private System.Windows.Forms.Panel panelPrecioProducto;
        private System.Windows.Forms.Label lblPrecioProducto;
        private System.Windows.Forms.TextBox txtTipoCliente;
        private Microsoft.VisualBasic.PowerPacks.Printing.PrintForm printForm1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripButton tsBtnFormularioVenta;
        private System.Windows.Forms.PictureBox pictureBoxVenta;
        private System.Windows.Forms.ToolStripButton tsBtnDevolucion;
        private System.Windows.Forms.TextBox txtIcoBolsaTotal;
        private System.Windows.Forms.TextBox txtIcoBolsaUnit;
        private System.Windows.Forms.TextBox txtIcoBolsaCant;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnBorrarImpstoBolsas;
        private System.Windows.Forms.TextBox txtSubtotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Articulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Medida;
        private System.Windows.Forms.DataGridViewImageColumn Color;
        private System.Windows.Forms.DataGridViewTextBoxColumn CLote;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descuento;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorMenosDescto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Iva;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalMasIva;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DataGridViewTextBoxColumn Retorno;
        private System.Windows.Forms.TextBox txtValorUnitario;

    }
}