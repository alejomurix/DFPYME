namespace Aplicacion.Inventario.Producto
{
    partial class frmEditarProducto
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

        public System.Windows.Forms.TextBox TxtCodigoProducto
        {
            set { this.txtCodigo = value; }
            get { return this.txtCodigo; }
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditarProducto));
            this.tsMenuEdicion = new System.Windows.Forms.ToolStrip();
            this.tsbGuardarCambiosEditarProducto = new System.Windows.Forms.ToolStripButton();
            this.tsbSalirEditarProducto = new System.Windows.Forms.ToolStripButton();
            this.gbInformacionGeneral = new System.Windows.Forms.GroupBox();
            this.cbValorICO = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cbAplicaDescuento = new System.Windows.Forms.ComboBox();
            this.cbImprime = new System.Windows.Forms.ComboBox();
            this.cbAplicaICO = new System.Windows.Forms.ComboBox();
            this.lblCuenta = new System.Windows.Forms.Label();
            this.cbCuentaContable = new System.Windows.Forms.ComboBox();
            this.cbProdProceso = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cbTipoInventario = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCodigo_7 = new System.Windows.Forms.TextBox();
            this.txtCodigo_6 = new System.Windows.Forms.TextBox();
            this.txtCodigo_5 = new System.Windows.Forms.TextBox();
            this.txtCodigo_4 = new System.Windows.Forms.TextBox();
            this.txtCodigo_3 = new System.Windows.Forms.TextBox();
            this.txtCodigo_2 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lkGenerarCodigo = new System.Windows.Forms.LinkLabel();
            this.lblBarras = new System.Windows.Forms.Label();
            this.txtBarras = new System.Windows.Forms.TextBox();
            this.lkGenerarBarras = new System.Windows.Forms.LinkLabel();
            this.lblReferencia = new System.Windows.Forms.Label();
            this.txtReferencia = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.txtCategoria = new System.Windows.Forms.TextBox();
            this.btnBuscarCategoria = new System.Windows.Forms.Button();
            this.lblMarca = new System.Windows.Forms.Label();
            this.txtMarca = new System.Windows.Forms.TextBox();
            this.btnBuscarMarca = new System.Windows.Forms.Button();
            this.gbSelecionarColor = new System.Windows.Forms.GroupBox();
            this.btnAgregarColor = new System.Windows.Forms.Button();
            this.btnElegirColor = new System.Windows.Forms.Button();
            this.btnCancelarColor = new System.Windows.Forms.Button();
            this.dgvListaColor = new System.Windows.Forms.DataGridView();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewImageColumn();
            this.chkLstRecargo = new System.Windows.Forms.CheckedListBox();
            this.dgvColor = new System.Windows.Forms.DataGridView();
            this.IdColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Color = new System.Windows.Forms.DataGridViewImageColumn();
            this.chkLstDescuento = new System.Windows.Forms.CheckedListBox();
            this.lbUnidadMedida = new System.Windows.Forms.ListBox();
            this.lbValorMedida = new System.Windows.Forms.ListBox();
            this.rbtnUnidadMedida = new System.Windows.Forms.RadioButton();
            this.lstbTalla = new System.Windows.Forms.ListBox();
            this.btnEliminarColor = new System.Windows.Forms.Button();
            this.btnAddColor = new System.Windows.Forms.Button();
            this.dgvMedida = new System.Windows.Forms.DataGridView();
            this.IdMedida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdUnidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Medida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rbtnTalla = new System.Windows.Forms.RadioButton();
            this.btnAddMedida = new System.Windows.Forms.Button();
            this.btnEliminarMedida = new System.Windows.Forms.Button();
            this.pbColor = new System.Windows.Forms.PictureBox();
            this.gbSeleccionarMedida = new System.Windows.Forms.GroupBox();
            this.btnElegirMedida = new System.Windows.Forms.Button();
            this.btnCancelarMedida = new System.Windows.Forms.Button();
            this.dgvListaMedida = new System.Windows.Forms.DataGridView();
            this.IdTalla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Talla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbPrecio = new System.Windows.Forms.GroupBox();
            this.txtValorDesctoDistrib = new System.Windows.Forms.TextBox();
            this.txtValorDesctoMayor = new System.Windows.Forms.TextBox();
            this.txtDesctoDistribuidor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDesctoMayor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblValorCosto = new System.Windows.Forms.Label();
            this.txtValorCosto = new System.Windows.Forms.TextBox();
            this.chkCantDecimal = new System.Windows.Forms.CheckBox();
            this.lblUtilidad = new System.Windows.Forms.Label();
            this.txtUtilidad = new System.Windows.Forms.TextBox();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.txtValorVenta = new System.Windows.Forms.TextBox();
            this.lblAplicaPrecio = new System.Windows.Forms.Label();
            this.txtAplicaPrecio = new System.Windows.Forms.TextBox();
            this.cbAplicarPrecio = new System.Windows.Forms.ComboBox();
            this.btnEditarAplicaPrecio = new System.Windows.Forms.Button();
            this.lblIva = new System.Windows.Forms.Label();
            this.txtIva = new System.Windows.Forms.TextBox();
            this.cbIvaEditar = new System.Windows.Forms.ComboBox();
            this.btnEditarIva = new System.Windows.Forms.Button();
            this.gbMedida = new System.Windows.Forms.GroupBox();
            this.cbUnidadesMedida = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lblPresentacion = new System.Windows.Forms.Label();
            this.txtUnidadVenta = new System.Windows.Forms.TextBox();
            this.lblCantMinima = new System.Windows.Forms.Label();
            this.txtCantMinima = new System.Windows.Forms.TextBox();
            this.lblCantMaxima = new System.Windows.Forms.Label();
            this.txtCantMaxima = new System.Windows.Forms.TextBox();
            this.rbActivo = new System.Windows.Forms.RadioButton();
            this.rbInactivo = new System.Windows.Forms.RadioButton();
            this.tsMenuEdicion.SuspendLayout();
            this.gbInformacionGeneral.SuspendLayout();
            this.gbSelecionarColor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedida)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbColor)).BeginInit();
            this.gbSeleccionarMedida.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaMedida)).BeginInit();
            this.gbPrecio.SuspendLayout();
            this.gbMedida.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMenuEdicion
            // 
            this.tsMenuEdicion.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbGuardarCambiosEditarProducto,
            this.tsbSalirEditarProducto});
            this.tsMenuEdicion.Location = new System.Drawing.Point(0, 0);
            this.tsMenuEdicion.Name = "tsMenuEdicion";
            this.tsMenuEdicion.Size = new System.Drawing.Size(973, 25);
            this.tsMenuEdicion.TabIndex = 0;
            this.tsMenuEdicion.Text = "Menu Edicion";
            // 
            // tsbGuardarCambiosEditarProducto
            // 
            this.tsbGuardarCambiosEditarProducto.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.tsbGuardarCambiosEditarProducto.Image = ((System.Drawing.Image)(resources.GetObject("tsbGuardarCambiosEditarProducto.Image")));
            this.tsbGuardarCambiosEditarProducto.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbGuardarCambiosEditarProducto.Name = "tsbGuardarCambiosEditarProducto";
            this.tsbGuardarCambiosEditarProducto.Size = new System.Drawing.Size(102, 22);
            this.tsbGuardarCambiosEditarProducto.Text = "Guardar [F2]";
            this.tsbGuardarCambiosEditarProducto.Click += new System.EventHandler(this.tsbGuardarCambiosEditarProducto_Click);
            // 
            // tsbSalirEditarProducto
            // 
            this.tsbSalirEditarProducto.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.tsbSalirEditarProducto.Image = ((System.Drawing.Image)(resources.GetObject("tsbSalirEditarProducto.Image")));
            this.tsbSalirEditarProducto.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSalirEditarProducto.Name = "tsbSalirEditarProducto";
            this.tsbSalirEditarProducto.Size = new System.Drawing.Size(91, 22);
            this.tsbSalirEditarProducto.Text = "Salir [ESC]";
            this.tsbSalirEditarProducto.Click += new System.EventHandler(this.tsbSalirEditarProducto_Click);
            // 
            // gbInformacionGeneral
            // 
            this.gbInformacionGeneral.Controls.Add(this.cbValorICO);
            this.gbInformacionGeneral.Controls.Add(this.label15);
            this.gbInformacionGeneral.Controls.Add(this.label14);
            this.gbInformacionGeneral.Controls.Add(this.label13);
            this.gbInformacionGeneral.Controls.Add(this.cbAplicaDescuento);
            this.gbInformacionGeneral.Controls.Add(this.cbImprime);
            this.gbInformacionGeneral.Controls.Add(this.cbAplicaICO);
            this.gbInformacionGeneral.Controls.Add(this.lblCuenta);
            this.gbInformacionGeneral.Controls.Add(this.cbCuentaContable);
            this.gbInformacionGeneral.Controls.Add(this.cbProdProceso);
            this.gbInformacionGeneral.Controls.Add(this.label12);
            this.gbInformacionGeneral.Controls.Add(this.cbTipoInventario);
            this.gbInformacionGeneral.Controls.Add(this.label11);
            this.gbInformacionGeneral.Controls.Add(this.label3);
            this.gbInformacionGeneral.Controls.Add(this.txtCodigo_7);
            this.gbInformacionGeneral.Controls.Add(this.txtCodigo_6);
            this.gbInformacionGeneral.Controls.Add(this.txtCodigo_5);
            this.gbInformacionGeneral.Controls.Add(this.txtCodigo_4);
            this.gbInformacionGeneral.Controls.Add(this.txtCodigo_3);
            this.gbInformacionGeneral.Controls.Add(this.txtCodigo_2);
            this.gbInformacionGeneral.Controls.Add(this.label8);
            this.gbInformacionGeneral.Controls.Add(this.label7);
            this.gbInformacionGeneral.Controls.Add(this.label6);
            this.gbInformacionGeneral.Controls.Add(this.label5);
            this.gbInformacionGeneral.Controls.Add(this.label4);
            this.gbInformacionGeneral.Controls.Add(this.lblCodigo);
            this.gbInformacionGeneral.Controls.Add(this.txtCodigo);
            this.gbInformacionGeneral.Controls.Add(this.lkGenerarCodigo);
            this.gbInformacionGeneral.Controls.Add(this.lblBarras);
            this.gbInformacionGeneral.Controls.Add(this.txtBarras);
            this.gbInformacionGeneral.Controls.Add(this.lkGenerarBarras);
            this.gbInformacionGeneral.Controls.Add(this.lblReferencia);
            this.gbInformacionGeneral.Controls.Add(this.txtReferencia);
            this.gbInformacionGeneral.Controls.Add(this.lblNombre);
            this.gbInformacionGeneral.Controls.Add(this.txtNombre);
            this.gbInformacionGeneral.Controls.Add(this.lblDescripcion);
            this.gbInformacionGeneral.Controls.Add(this.txtDescripcion);
            this.gbInformacionGeneral.Controls.Add(this.lblCategoria);
            this.gbInformacionGeneral.Controls.Add(this.txtCategoria);
            this.gbInformacionGeneral.Controls.Add(this.btnBuscarCategoria);
            this.gbInformacionGeneral.Controls.Add(this.lblMarca);
            this.gbInformacionGeneral.Controls.Add(this.txtMarca);
            this.gbInformacionGeneral.Controls.Add(this.btnBuscarMarca);
            this.gbInformacionGeneral.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.gbInformacionGeneral.Location = new System.Drawing.Point(13, 29);
            this.gbInformacionGeneral.Margin = new System.Windows.Forms.Padding(4);
            this.gbInformacionGeneral.Name = "gbInformacionGeneral";
            this.gbInformacionGeneral.Padding = new System.Windows.Forms.Padding(4);
            this.gbInformacionGeneral.Size = new System.Drawing.Size(942, 269);
            this.gbInformacionGeneral.TabIndex = 1;
            this.gbInformacionGeneral.TabStop = false;
            this.gbInformacionGeneral.Text = "Informacion General";
            // 
            // cbValorICO
            // 
            this.cbValorICO.DisplayMember = "valor_ico";
            this.cbValorICO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbValorICO.FormattingEnabled = true;
            this.cbValorICO.Location = new System.Drawing.Point(815, 165);
            this.cbValorICO.Name = "cbValorICO";
            this.cbValorICO.Size = new System.Drawing.Size(113, 24);
            this.cbValorICO.TabIndex = 43;
            this.cbValorICO.ValueMember = "id_ico";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.label15.Location = new System.Drawing.Point(614, 238);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(73, 16);
            this.label15.TabIndex = 41;
            this.label15.Text = "Descuento";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.label14.Location = new System.Drawing.Point(614, 203);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(56, 16);
            this.label14.TabIndex = 42;
            this.label14.Text = "Imprime";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.label13.Location = new System.Drawing.Point(614, 169);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(30, 16);
            this.label13.TabIndex = 40;
            this.label13.Text = "ICO";
            // 
            // cbAplicaDescuento
            // 
            this.cbAplicaDescuento.DisplayMember = "Nombre";
            this.cbAplicaDescuento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAplicaDescuento.FormattingEnabled = true;
            this.cbAplicaDescuento.Location = new System.Drawing.Point(698, 234);
            this.cbAplicaDescuento.Name = "cbAplicaDescuento";
            this.cbAplicaDescuento.Size = new System.Drawing.Size(113, 24);
            this.cbAplicaDescuento.TabIndex = 37;
            this.cbAplicaDescuento.ValueMember = "Id";
            // 
            // cbImprime
            // 
            this.cbImprime.DisplayMember = "Nombre";
            this.cbImprime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbImprime.FormattingEnabled = true;
            this.cbImprime.Location = new System.Drawing.Point(698, 199);
            this.cbImprime.Name = "cbImprime";
            this.cbImprime.Size = new System.Drawing.Size(113, 24);
            this.cbImprime.TabIndex = 38;
            this.cbImprime.ValueMember = "Id";
            // 
            // cbAplicaICO
            // 
            this.cbAplicaICO.DisplayMember = "Nombre";
            this.cbAplicaICO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAplicaICO.FormattingEnabled = true;
            this.cbAplicaICO.Location = new System.Drawing.Point(698, 165);
            this.cbAplicaICO.Name = "cbAplicaICO";
            this.cbAplicaICO.Size = new System.Drawing.Size(113, 24);
            this.cbAplicaICO.TabIndex = 39;
            this.cbAplicaICO.ValueMember = "Id";
            // 
            // lblCuenta
            // 
            this.lblCuenta.AutoSize = true;
            this.lblCuenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblCuenta.Location = new System.Drawing.Point(611, 98);
            this.lblCuenta.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCuenta.Name = "lblCuenta";
            this.lblCuenta.Size = new System.Drawing.Size(81, 16);
            this.lblCuenta.TabIndex = 36;
            this.lblCuenta.Text = "Cuenta cont.";
            // 
            // cbCuentaContable
            // 
            this.cbCuentaContable.DisplayMember = "descripcion";
            this.cbCuentaContable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCuentaContable.FormattingEnabled = true;
            this.cbCuentaContable.Location = new System.Drawing.Point(698, 94);
            this.cbCuentaContable.Name = "cbCuentaContable";
            this.cbCuentaContable.Size = new System.Drawing.Size(230, 24);
            this.cbCuentaContable.TabIndex = 35;
            this.cbCuentaContable.ValueMember = "numero";
            this.cbCuentaContable.SelectionChangeCommitted += new System.EventHandler(this.cbCuentaContable_SelectionChangeCommitted);
            // 
            // cbProdProceso
            // 
            this.cbProdProceso.DisplayMember = "producto";
            this.cbProdProceso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProdProceso.Enabled = false;
            this.cbProdProceso.FormattingEnabled = true;
            this.cbProdProceso.Location = new System.Drawing.Point(112, 234);
            this.cbProdProceso.Name = "cbProdProceso";
            this.cbProdProceso.Size = new System.Drawing.Size(491, 24);
            this.cbProdProceso.TabIndex = 34;
            this.cbProdProceso.ValueMember = "codigo";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.label12.Location = new System.Drawing.Point(11, 238);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(90, 16);
            this.label12.TabIndex = 33;
            this.label12.Text = "Prod proceso";
            // 
            // cbTipoInventario
            // 
            this.cbTipoInventario.DisplayMember = "nombre";
            this.cbTipoInventario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoInventario.FormattingEnabled = true;
            this.cbTipoInventario.Location = new System.Drawing.Point(112, 199);
            this.cbTipoInventario.Name = "cbTipoInventario";
            this.cbTipoInventario.Size = new System.Drawing.Size(491, 24);
            this.cbTipoInventario.TabIndex = 32;
            this.cbTipoInventario.ValueMember = "id";
            this.cbTipoInventario.SelectionChangeCommitted += new System.EventHandler(this.cbTipoInventario_SelectionChangeCommitted);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.label11.Location = new System.Drawing.Point(7, 203);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(97, 16);
            this.label11.TabIndex = 31;
            this.label11.Text = "Tipo inventario";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.label3.Location = new System.Drawing.Point(10, 61);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 16);
            this.label3.TabIndex = 22;
            this.label3.Text = "Codigos aux.  1";
            // 
            // txtCodigo_7
            // 
            this.txtCodigo_7.Location = new System.Drawing.Point(811, 58);
            this.txtCodigo_7.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodigo_7.Name = "txtCodigo_7";
            this.txtCodigo_7.Size = new System.Drawing.Size(116, 22);
            this.txtCodigo_7.TabIndex = 24;
            this.txtCodigo_7.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigo_7_KeyPress);
            this.txtCodigo_7.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodigo_7_Validating);
            // 
            // txtCodigo_6
            // 
            this.txtCodigo_6.Location = new System.Drawing.Point(675, 58);
            this.txtCodigo_6.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodigo_6.Name = "txtCodigo_6";
            this.txtCodigo_6.Size = new System.Drawing.Size(116, 22);
            this.txtCodigo_6.TabIndex = 23;
            this.txtCodigo_6.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigo_6_KeyPress);
            this.txtCodigo_6.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodigo_6_Validating);
            // 
            // txtCodigo_5
            // 
            this.txtCodigo_5.Location = new System.Drawing.Point(536, 58);
            this.txtCodigo_5.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodigo_5.Name = "txtCodigo_5";
            this.txtCodigo_5.Size = new System.Drawing.Size(116, 22);
            this.txtCodigo_5.TabIndex = 21;
            this.txtCodigo_5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigo_5_KeyPress);
            this.txtCodigo_5.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodigo_5_Validating);
            // 
            // txtCodigo_4
            // 
            this.txtCodigo_4.Location = new System.Drawing.Point(398, 58);
            this.txtCodigo_4.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodigo_4.Name = "txtCodigo_4";
            this.txtCodigo_4.Size = new System.Drawing.Size(116, 22);
            this.txtCodigo_4.TabIndex = 20;
            this.txtCodigo_4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigo_4_KeyPress);
            this.txtCodigo_4.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodigo_4_Validating);
            // 
            // txtCodigo_3
            // 
            this.txtCodigo_3.Location = new System.Drawing.Point(260, 58);
            this.txtCodigo_3.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodigo_3.Name = "txtCodigo_3";
            this.txtCodigo_3.Size = new System.Drawing.Size(116, 22);
            this.txtCodigo_3.TabIndex = 19;
            this.txtCodigo_3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigo_3_KeyPress);
            this.txtCodigo_3.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodigo_3_Validating);
            // 
            // txtCodigo_2
            // 
            this.txtCodigo_2.Location = new System.Drawing.Point(113, 58);
            this.txtCodigo_2.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodigo_2.Name = "txtCodigo_2";
            this.txtCodigo_2.Size = new System.Drawing.Size(126, 22);
            this.txtCodigo_2.TabIndex = 18;
            this.txtCodigo_2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigo_2_KeyPress);
            this.txtCodigo_2.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodigo_2_Validating);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.label8.Location = new System.Drawing.Point(795, 61);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(15, 16);
            this.label8.TabIndex = 28;
            this.label8.Text = "6";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.label7.Location = new System.Drawing.Point(657, 61);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(15, 16);
            this.label7.TabIndex = 29;
            this.label7.Text = "5";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.label6.Location = new System.Drawing.Point(519, 61);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 16);
            this.label6.TabIndex = 27;
            this.label6.Text = "4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.label5.Location = new System.Drawing.Point(382, 61);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(15, 16);
            this.label5.TabIndex = 25;
            this.label5.Text = "3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.label4.Location = new System.Drawing.Point(244, 61);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 16);
            this.label4.TabIndex = 26;
            this.label4.Text = "2";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblCodigo.Location = new System.Drawing.Point(10, 25);
            this.lblCodigo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(98, 16);
            this.lblCodigo.TabIndex = 9;
            this.lblCodigo.Text = "Codigo Interno ";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(113, 22);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(126, 22);
            this.txtCodigo.TabIndex = 0;
            this.txtCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigo_KeyPress);
            this.txtCodigo.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodigo_Validating);
            // 
            // lkGenerarCodigo
            // 
            this.lkGenerarCodigo.AutoSize = true;
            this.lkGenerarCodigo.Location = new System.Drawing.Point(240, 25);
            this.lkGenerarCodigo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lkGenerarCodigo.Name = "lkGenerarCodigo";
            this.lkGenerarCodigo.Size = new System.Drawing.Size(57, 16);
            this.lkGenerarCodigo.TabIndex = 1;
            this.lkGenerarCodigo.TabStop = true;
            this.lkGenerarCodigo.Text = "Generar";
            this.lkGenerarCodigo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lkGenerarCodigo_LinkClicked);
            // 
            // lblBarras
            // 
            this.lblBarras.AutoSize = true;
            this.lblBarras.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblBarras.Location = new System.Drawing.Point(318, 25);
            this.lblBarras.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBarras.Name = "lblBarras";
            this.lblBarras.Size = new System.Drawing.Size(98, 16);
            this.lblBarras.TabIndex = 10;
            this.lblBarras.Text = "Codigo Barras ";
            // 
            // txtBarras
            // 
            this.txtBarras.Location = new System.Drawing.Point(424, 22);
            this.txtBarras.Margin = new System.Windows.Forms.Padding(4);
            this.txtBarras.Name = "txtBarras";
            this.txtBarras.Size = new System.Drawing.Size(179, 22);
            this.txtBarras.TabIndex = 2;
            this.txtBarras.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBarras_KeyPress);
            this.txtBarras.Validating += new System.ComponentModel.CancelEventHandler(this.txtBarras_Validating);
            // 
            // lkGenerarBarras
            // 
            this.lkGenerarBarras.AutoSize = true;
            this.lkGenerarBarras.Location = new System.Drawing.Point(604, 25);
            this.lkGenerarBarras.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lkGenerarBarras.Name = "lkGenerarBarras";
            this.lkGenerarBarras.Size = new System.Drawing.Size(57, 16);
            this.lkGenerarBarras.TabIndex = 3;
            this.lkGenerarBarras.TabStop = true;
            this.lkGenerarBarras.Text = "Generar";
            this.lkGenerarBarras.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lkGenerarBarras_LinkClicked);
            // 
            // lblReferencia
            // 
            this.lblReferencia.AutoSize = true;
            this.lblReferencia.Location = new System.Drawing.Point(667, 22);
            this.lblReferencia.Name = "lblReferencia";
            this.lblReferencia.Size = new System.Drawing.Size(74, 16);
            this.lblReferencia.TabIndex = 11;
            this.lblReferencia.Text = "Referencia";
            // 
            // txtReferencia
            // 
            this.txtReferencia.Location = new System.Drawing.Point(747, 19);
            this.txtReferencia.Name = "txtReferencia";
            this.txtReferencia.Size = new System.Drawing.Size(181, 22);
            this.txtReferencia.TabIndex = 4;
            this.txtReferencia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtReferencia_KeyPress);
            this.txtReferencia.Validating += new System.ComponentModel.CancelEventHandler(this.txtReferencia_Validating);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblNombre.Location = new System.Drawing.Point(10, 97);
            this.lblNombre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(60, 16);
            this.lblNombre.TabIndex = 12;
            this.lblNombre.Text = "Nombre ";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(113, 94);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(4);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(403, 22);
            this.txtNombre.TabIndex = 5;
            this.txtNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombre_KeyPress);
            this.txtNombre.Validating += new System.ComponentModel.CancelEventHandler(this.txtNombre_Validating);
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblDescripcion.Location = new System.Drawing.Point(612, 133);
            this.lblDescripcion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(80, 16);
            this.lblDescripcion.TabIndex = 13;
            this.lblDescripcion.Text = "Descripción";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(698, 129);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.ReadOnly = true;
            this.txtDescripcion.Size = new System.Drawing.Size(230, 24);
            this.txtDescripcion.TabIndex = 6;
            this.txtDescripcion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescripcion_KeyPress);
            this.txtDescripcion.Validating += new System.ComponentModel.CancelEventHandler(this.txtDescripcion_Validating);
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Location = new System.Drawing.Point(10, 133);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(67, 16);
            this.lblCategoria.TabIndex = 14;
            this.lblCategoria.Text = "Categoria";
            // 
            // txtCategoria
            // 
            this.txtCategoria.Enabled = false;
            this.txtCategoria.Location = new System.Drawing.Point(113, 130);
            this.txtCategoria.Margin = new System.Windows.Forms.Padding(4);
            this.txtCategoria.Name = "txtCategoria";
            this.txtCategoria.Size = new System.Drawing.Size(225, 22);
            this.txtCategoria.TabIndex = 15;
            // 
            // btnBuscarCategoria
            // 
            this.btnBuscarCategoria.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscarCategoria.Image")));
            this.btnBuscarCategoria.Location = new System.Drawing.Point(346, 129);
            this.btnBuscarCategoria.Margin = new System.Windows.Forms.Padding(4);
            this.btnBuscarCategoria.Name = "btnBuscarCategoria";
            this.btnBuscarCategoria.Size = new System.Drawing.Size(30, 24);
            this.btnBuscarCategoria.TabIndex = 7;
            this.btnBuscarCategoria.UseVisualStyleBackColor = true;
            this.btnBuscarCategoria.Click += new System.EventHandler(this.btnBuscarCategoria_Click);
            // 
            // lblMarca
            // 
            this.lblMarca.AutoSize = true;
            this.lblMarca.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblMarca.Location = new System.Drawing.Point(12, 169);
            this.lblMarca.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(46, 16);
            this.lblMarca.TabIndex = 16;
            this.lblMarca.Text = "Marca";
            // 
            // txtMarca
            // 
            this.txtMarca.Enabled = false;
            this.txtMarca.Location = new System.Drawing.Point(113, 165);
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.Size = new System.Drawing.Size(225, 22);
            this.txtMarca.TabIndex = 17;
            // 
            // btnBuscarMarca
            // 
            this.btnBuscarMarca.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscarMarca.Image")));
            this.btnBuscarMarca.Location = new System.Drawing.Point(345, 164);
            this.btnBuscarMarca.Margin = new System.Windows.Forms.Padding(4);
            this.btnBuscarMarca.Name = "btnBuscarMarca";
            this.btnBuscarMarca.Size = new System.Drawing.Size(30, 24);
            this.btnBuscarMarca.TabIndex = 8;
            this.btnBuscarMarca.UseVisualStyleBackColor = true;
            this.btnBuscarMarca.Click += new System.EventHandler(this.btnBuscarMarca_Click);
            // 
            // gbSelecionarColor
            // 
            this.gbSelecionarColor.Controls.Add(this.btnAgregarColor);
            this.gbSelecionarColor.Controls.Add(this.btnElegirColor);
            this.gbSelecionarColor.Controls.Add(this.btnCancelarColor);
            this.gbSelecionarColor.Controls.Add(this.dgvListaColor);
            this.gbSelecionarColor.Controls.Add(this.chkLstRecargo);
            this.gbSelecionarColor.Controls.Add(this.dgvColor);
            this.gbSelecionarColor.Controls.Add(this.chkLstDescuento);
            this.gbSelecionarColor.Controls.Add(this.lbUnidadMedida);
            this.gbSelecionarColor.Controls.Add(this.lbValorMedida);
            this.gbSelecionarColor.Controls.Add(this.rbtnUnidadMedida);
            this.gbSelecionarColor.Controls.Add(this.lstbTalla);
            this.gbSelecionarColor.Controls.Add(this.btnEliminarColor);
            this.gbSelecionarColor.Controls.Add(this.btnAddColor);
            this.gbSelecionarColor.Controls.Add(this.dgvMedida);
            this.gbSelecionarColor.Controls.Add(this.rbtnTalla);
            this.gbSelecionarColor.Controls.Add(this.btnAddMedida);
            this.gbSelecionarColor.Controls.Add(this.btnEliminarMedida);
            this.gbSelecionarColor.Controls.Add(this.pbColor);
            this.gbSelecionarColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.gbSelecionarColor.Location = new System.Drawing.Point(908, 46);
            this.gbSelecionarColor.Name = "gbSelecionarColor";
            this.gbSelecionarColor.Size = new System.Drawing.Size(20, 22);
            this.gbSelecionarColor.TabIndex = 21;
            this.gbSelecionarColor.TabStop = false;
            this.gbSelecionarColor.Visible = false;
            // 
            // btnAgregarColor
            // 
            this.btnAgregarColor.FlatAppearance.BorderSize = 0;
            this.btnAgregarColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarColor.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregarColor.Image")));
            this.btnAgregarColor.Location = new System.Drawing.Point(19, 19);
            this.btnAgregarColor.Name = "btnAgregarColor";
            this.btnAgregarColor.Size = new System.Drawing.Size(19, 18);
            this.btnAgregarColor.TabIndex = 0;
            this.btnAgregarColor.UseVisualStyleBackColor = true;
            this.btnAgregarColor.Click += new System.EventHandler(this.btnAgregarColor_Click);
            // 
            // btnElegirColor
            // 
            this.btnElegirColor.FlatAppearance.BorderSize = 0;
            this.btnElegirColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnElegirColor.Image = ((System.Drawing.Image)(resources.GetObject("btnElegirColor.Image")));
            this.btnElegirColor.Location = new System.Drawing.Point(56, 19);
            this.btnElegirColor.Name = "btnElegirColor";
            this.btnElegirColor.Size = new System.Drawing.Size(19, 18);
            this.btnElegirColor.TabIndex = 1;
            this.btnElegirColor.UseVisualStyleBackColor = true;
            this.btnElegirColor.Click += new System.EventHandler(this.btnElegirColor_Click);
            // 
            // btnCancelarColor
            // 
            this.btnCancelarColor.FlatAppearance.BorderSize = 0;
            this.btnCancelarColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelarColor.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelarColor.Image")));
            this.btnCancelarColor.Location = new System.Drawing.Point(91, 19);
            this.btnCancelarColor.Name = "btnCancelarColor";
            this.btnCancelarColor.Size = new System.Drawing.Size(19, 18);
            this.btnCancelarColor.TabIndex = 2;
            this.btnCancelarColor.UseVisualStyleBackColor = true;
            this.btnCancelarColor.Click += new System.EventHandler(this.btnCancelarColor_Click);
            // 
            // dgvListaColor
            // 
            this.dgvListaColor.AllowUserToAddRows = false;
            this.dgvListaColor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvListaColor.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedHeaders;
            this.dgvListaColor.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvListaColor.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvListaColor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaColor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column10,
            this.Column11});
            this.dgvListaColor.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvListaColor.Location = new System.Drawing.Point(8, 43);
            this.dgvListaColor.Name = "dgvListaColor";
            this.dgvListaColor.Size = new System.Drawing.Size(114, 195);
            this.dgvListaColor.TabIndex = 3;
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "IdColor";
            this.Column10.HeaderText = "Id";
            this.Column10.Name = "Column10";
            this.Column10.Visible = false;
            // 
            // Column11
            // 
            this.Column11.DataPropertyName = "ImagenBit";
            this.Column11.HeaderText = "Color";
            this.Column11.Name = "Column11";
            this.Column11.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // chkLstRecargo
            // 
            this.chkLstRecargo.FormattingEnabled = true;
            this.chkLstRecargo.Location = new System.Drawing.Point(256, 29);
            this.chkLstRecargo.Name = "chkLstRecargo";
            this.chkLstRecargo.Size = new System.Drawing.Size(21, 4);
            this.chkLstRecargo.TabIndex = 3;
            this.chkLstRecargo.Visible = false;
            // 
            // dgvColor
            // 
            this.dgvColor.AllowUserToAddRows = false;
            this.dgvColor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvColor.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvColor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvColor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdColor,
            this.Color});
            this.dgvColor.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvColor.Location = new System.Drawing.Point(128, 49);
            this.dgvColor.Name = "dgvColor";
            this.dgvColor.Size = new System.Drawing.Size(127, 189);
            this.dgvColor.TabIndex = 10;
            this.dgvColor.Visible = false;
            // 
            // IdColor
            // 
            this.IdColor.DataPropertyName = "Id";
            this.IdColor.HeaderText = "Id";
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
            // 
            // chkLstDescuento
            // 
            this.chkLstDescuento.FormattingEnabled = true;
            this.chkLstDescuento.Location = new System.Drawing.Point(201, 29);
            this.chkLstDescuento.Name = "chkLstDescuento";
            this.chkLstDescuento.Size = new System.Drawing.Size(27, 4);
            this.chkLstDescuento.TabIndex = 2;
            this.chkLstDescuento.Visible = false;
            // 
            // lbUnidadMedida
            // 
            this.lbUnidadMedida.DisplayMember = "DescripcionUnidadMedida";
            this.lbUnidadMedida.FormattingEnabled = true;
            this.lbUnidadMedida.ItemHeight = 16;
            this.lbUnidadMedida.Location = new System.Drawing.Point(449, 115);
            this.lbUnidadMedida.Name = "lbUnidadMedida";
            this.lbUnidadMedida.Size = new System.Drawing.Size(10, 4);
            this.lbUnidadMedida.TabIndex = 18;
            this.lbUnidadMedida.ValueMember = "IdUnidadMedida";
            this.lbUnidadMedida.Visible = false;
            this.lbUnidadMedida.SelectedValueChanged += new System.EventHandler(this.lbUnidadMedida_SelectedValueChanged);
            // 
            // lbValorMedida
            // 
            this.lbValorMedida.DisplayMember = "DescripcionValorUnidadMedida";
            this.lbValorMedida.FormattingEnabled = true;
            this.lbValorMedida.ItemHeight = 16;
            this.lbValorMedida.Location = new System.Drawing.Point(449, 123);
            this.lbValorMedida.Name = "lbValorMedida";
            this.lbValorMedida.Size = new System.Drawing.Size(10, 4);
            this.lbValorMedida.TabIndex = 19;
            this.lbValorMedida.ValueMember = "IdValorUnidadMedida";
            this.lbValorMedida.Visible = false;
            // 
            // rbtnUnidadMedida
            // 
            this.rbtnUnidadMedida.AutoSize = true;
            this.rbtnUnidadMedida.Checked = true;
            this.rbtnUnidadMedida.Location = new System.Drawing.Point(449, 76);
            this.rbtnUnidadMedida.Name = "rbtnUnidadMedida";
            this.rbtnUnidadMedida.Size = new System.Drawing.Size(138, 20);
            this.rbtnUnidadMedida.TabIndex = 16;
            this.rbtnUnidadMedida.TabStop = true;
            this.rbtnUnidadMedida.Text = "Unidad de Medida";
            this.rbtnUnidadMedida.UseVisualStyleBackColor = true;
            this.rbtnUnidadMedida.Visible = false;
            this.rbtnUnidadMedida.CheckedChanged += new System.EventHandler(this.rbtnUnidadMedida_CheckedChanged);
            // 
            // lstbTalla
            // 
            this.lstbTalla.DisplayMember = "descripcionvalor_unidad_medida";
            this.lstbTalla.Enabled = false;
            this.lstbTalla.FormattingEnabled = true;
            this.lstbTalla.ItemHeight = 16;
            this.lstbTalla.Location = new System.Drawing.Point(449, 132);
            this.lstbTalla.Name = "lstbTalla";
            this.lstbTalla.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstbTalla.Size = new System.Drawing.Size(10, 4);
            this.lstbTalla.TabIndex = 20;
            this.lstbTalla.ValueMember = "idvalor_unidad_medida";
            this.lstbTalla.Visible = false;
            // 
            // btnEliminarColor
            // 
            this.btnEliminarColor.FlatAppearance.BorderSize = 0;
            this.btnEliminarColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarColor.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminarColor.Image")));
            this.btnEliminarColor.Location = new System.Drawing.Point(261, 71);
            this.btnEliminarColor.Name = "btnEliminarColor";
            this.btnEliminarColor.Size = new System.Drawing.Size(19, 18);
            this.btnEliminarColor.TabIndex = 6;
            this.btnEliminarColor.UseVisualStyleBackColor = true;
            this.btnEliminarColor.Visible = false;
            this.btnEliminarColor.Click += new System.EventHandler(this.btnEliminarColor_Click);
            // 
            // btnAddColor
            // 
            this.btnAddColor.FlatAppearance.BorderSize = 0;
            this.btnAddColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddColor.Image = ((System.Drawing.Image)(resources.GetObject("btnAddColor.Image")));
            this.btnAddColor.Location = new System.Drawing.Point(261, 49);
            this.btnAddColor.Name = "btnAddColor";
            this.btnAddColor.Size = new System.Drawing.Size(19, 18);
            this.btnAddColor.TabIndex = 5;
            this.btnAddColor.UseVisualStyleBackColor = true;
            this.btnAddColor.Visible = false;
            this.btnAddColor.Click += new System.EventHandler(this.btnAddColor_Click);
            // 
            // dgvMedida
            // 
            this.dgvMedida.AllowUserToAddRows = false;
            this.dgvMedida.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMedida.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvMedida.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMedida.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdMedida,
            this.IdUnidad,
            this.Medida});
            this.dgvMedida.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvMedida.Location = new System.Drawing.Point(281, 43);
            this.dgvMedida.Name = "dgvMedida";
            this.dgvMedida.Size = new System.Drawing.Size(137, 189);
            this.dgvMedida.TabIndex = 9;
            this.dgvMedida.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMedida_CellClick);
            this.dgvMedida.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgvMedida_KeyUp);
            // 
            // IdMedida
            // 
            this.IdMedida.DataPropertyName = "idvalor_unidad_medida";
            this.IdMedida.HeaderText = "Id";
            this.IdMedida.Name = "IdMedida";
            this.IdMedida.Visible = false;
            // 
            // IdUnidad
            // 
            this.IdUnidad.DataPropertyName = "idunidad_medida";
            this.IdUnidad.HeaderText = "IdUnidad";
            this.IdUnidad.Name = "IdUnidad";
            this.IdUnidad.Visible = false;
            // 
            // Medida
            // 
            this.Medida.DataPropertyName = "descripcionvalor_unidad_medida";
            this.Medida.HeaderText = "Medida";
            this.Medida.Name = "Medida";
            // 
            // rbtnTalla
            // 
            this.rbtnTalla.AutoSize = true;
            this.rbtnTalla.Location = new System.Drawing.Point(138, 21);
            this.rbtnTalla.Name = "rbtnTalla";
            this.rbtnTalla.Size = new System.Drawing.Size(57, 20);
            this.rbtnTalla.TabIndex = 17;
            this.rbtnTalla.Text = "Talla";
            this.rbtnTalla.UseVisualStyleBackColor = true;
            this.rbtnTalla.Visible = false;
            this.rbtnTalla.CheckedChanged += new System.EventHandler(this.rbtnTalla_CheckedChanged);
            // 
            // btnAddMedida
            // 
            this.btnAddMedida.FlatAppearance.BorderSize = 0;
            this.btnAddMedida.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddMedida.Image = ((System.Drawing.Image)(resources.GetObject("btnAddMedida.Image")));
            this.btnAddMedida.Location = new System.Drawing.Point(421, 43);
            this.btnAddMedida.Name = "btnAddMedida";
            this.btnAddMedida.Size = new System.Drawing.Size(19, 18);
            this.btnAddMedida.TabIndex = 3;
            this.btnAddMedida.UseVisualStyleBackColor = true;
            this.btnAddMedida.Click += new System.EventHandler(this.btnAddMedida_Click);
            // 
            // btnEliminarMedida
            // 
            this.btnEliminarMedida.FlatAppearance.BorderSize = 0;
            this.btnEliminarMedida.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarMedida.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminarMedida.Image")));
            this.btnEliminarMedida.Location = new System.Drawing.Point(421, 67);
            this.btnEliminarMedida.Name = "btnEliminarMedida";
            this.btnEliminarMedida.Size = new System.Drawing.Size(19, 18);
            this.btnEliminarMedida.TabIndex = 4;
            this.btnEliminarMedida.UseVisualStyleBackColor = true;
            this.btnEliminarMedida.Click += new System.EventHandler(this.btnEliminarMedida_Click);
            // 
            // pbColor
            // 
            this.pbColor.BackColor = System.Drawing.Color.White;
            this.pbColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbColor.Enabled = false;
            this.pbColor.Location = new System.Drawing.Point(449, 43);
            this.pbColor.Name = "pbColor";
            this.pbColor.Size = new System.Drawing.Size(49, 16);
            this.pbColor.TabIndex = 39;
            this.pbColor.TabStop = false;
            this.pbColor.Visible = false;
            // 
            // gbSeleccionarMedida
            // 
            this.gbSeleccionarMedida.Controls.Add(this.btnElegirMedida);
            this.gbSeleccionarMedida.Controls.Add(this.btnCancelarMedida);
            this.gbSeleccionarMedida.Controls.Add(this.dgvListaMedida);
            this.gbSeleccionarMedida.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.gbSeleccionarMedida.Location = new System.Drawing.Point(911, 67);
            this.gbSeleccionarMedida.Name = "gbSeleccionarMedida";
            this.gbSeleccionarMedida.Size = new System.Drawing.Size(17, 18);
            this.gbSeleccionarMedida.TabIndex = 15;
            this.gbSeleccionarMedida.TabStop = false;
            this.gbSeleccionarMedida.Visible = false;
            // 
            // btnElegirMedida
            // 
            this.btnElegirMedida.FlatAppearance.BorderSize = 0;
            this.btnElegirMedida.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnElegirMedida.Image = ((System.Drawing.Image)(resources.GetObject("btnElegirMedida.Image")));
            this.btnElegirMedida.Location = new System.Drawing.Point(38, 19);
            this.btnElegirMedida.Name = "btnElegirMedida";
            this.btnElegirMedida.Size = new System.Drawing.Size(19, 18);
            this.btnElegirMedida.TabIndex = 0;
            this.btnElegirMedida.UseVisualStyleBackColor = true;
            this.btnElegirMedida.Click += new System.EventHandler(this.btnElegirMedida_Click);
            // 
            // btnCancelarMedida
            // 
            this.btnCancelarMedida.FlatAppearance.BorderSize = 0;
            this.btnCancelarMedida.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelarMedida.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelarMedida.Image")));
            this.btnCancelarMedida.Location = new System.Drawing.Point(73, 19);
            this.btnCancelarMedida.Name = "btnCancelarMedida";
            this.btnCancelarMedida.Size = new System.Drawing.Size(19, 18);
            this.btnCancelarMedida.TabIndex = 1;
            this.btnCancelarMedida.UseVisualStyleBackColor = true;
            this.btnCancelarMedida.Click += new System.EventHandler(this.btnCancelarMedida_Click);
            // 
            // dgvListaMedida
            // 
            this.dgvListaMedida.AllowUserToAddRows = false;
            this.dgvListaMedida.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvListaMedida.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedHeaders;
            this.dgvListaMedida.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvListaMedida.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvListaMedida.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaMedida.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdTalla,
            this.Talla});
            this.dgvListaMedida.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvListaMedida.Location = new System.Drawing.Point(14, 43);
            this.dgvListaMedida.Name = "dgvListaMedida";
            this.dgvListaMedida.Size = new System.Drawing.Size(114, 195);
            this.dgvListaMedida.TabIndex = 2;
            // 
            // IdTalla
            // 
            this.IdTalla.DataPropertyName = "idvalor_unidad_medida";
            this.IdTalla.HeaderText = "Id";
            this.IdTalla.Name = "IdTalla";
            this.IdTalla.Visible = false;
            // 
            // Talla
            // 
            this.Talla.DataPropertyName = "descripcionvalor_unidad_medida";
            this.Talla.HeaderText = "Medida";
            this.Talla.Name = "Talla";
            // 
            // gbPrecio
            // 
            this.gbPrecio.Controls.Add(this.txtValorDesctoDistrib);
            this.gbPrecio.Controls.Add(this.txtValorDesctoMayor);
            this.gbPrecio.Controls.Add(this.txtDesctoDistribuidor);
            this.gbPrecio.Controls.Add(this.label2);
            this.gbPrecio.Controls.Add(this.txtDesctoMayor);
            this.gbPrecio.Controls.Add(this.label1);
            this.gbPrecio.Controls.Add(this.lblValorCosto);
            this.gbPrecio.Controls.Add(this.txtValorCosto);
            this.gbPrecio.Controls.Add(this.chkCantDecimal);
            this.gbPrecio.Controls.Add(this.lblUtilidad);
            this.gbPrecio.Controls.Add(this.txtUtilidad);
            this.gbPrecio.Controls.Add(this.gbSeleccionarMedida);
            this.gbPrecio.Controls.Add(this.gbSelecionarColor);
            this.gbPrecio.Controls.Add(this.lblPrecio);
            this.gbPrecio.Controls.Add(this.txtValorVenta);
            this.gbPrecio.Controls.Add(this.lblAplicaPrecio);
            this.gbPrecio.Controls.Add(this.txtAplicaPrecio);
            this.gbPrecio.Controls.Add(this.cbAplicarPrecio);
            this.gbPrecio.Controls.Add(this.btnEditarAplicaPrecio);
            this.gbPrecio.Controls.Add(this.lblIva);
            this.gbPrecio.Controls.Add(this.txtIva);
            this.gbPrecio.Controls.Add(this.cbIvaEditar);
            this.gbPrecio.Controls.Add(this.btnEditarIva);
            this.gbPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.gbPrecio.Location = new System.Drawing.Point(13, 306);
            this.gbPrecio.Margin = new System.Windows.Forms.Padding(4);
            this.gbPrecio.Name = "gbPrecio";
            this.gbPrecio.Padding = new System.Windows.Forms.Padding(4);
            this.gbPrecio.Size = new System.Drawing.Size(942, 90);
            this.gbPrecio.TabIndex = 2;
            this.gbPrecio.TabStop = false;
            this.gbPrecio.Text = "Informacion de Precio";
            // 
            // txtValorDesctoDistrib
            // 
            this.txtValorDesctoDistrib.Location = new System.Drawing.Point(776, 57);
            this.txtValorDesctoDistrib.Name = "txtValorDesctoDistrib";
            this.txtValorDesctoDistrib.ReadOnly = true;
            this.txtValorDesctoDistrib.Size = new System.Drawing.Size(118, 22);
            this.txtValorDesctoDistrib.TabIndex = 35;
            // 
            // txtValorDesctoMayor
            // 
            this.txtValorDesctoMayor.Location = new System.Drawing.Point(466, 56);
            this.txtValorDesctoMayor.Name = "txtValorDesctoMayor";
            this.txtValorDesctoMayor.ReadOnly = true;
            this.txtValorDesctoMayor.Size = new System.Drawing.Size(118, 22);
            this.txtValorDesctoMayor.TabIndex = 34;
            // 
            // txtDesctoDistribuidor
            // 
            this.txtDesctoDistribuidor.Location = new System.Drawing.Point(728, 57);
            this.txtDesctoDistribuidor.Name = "txtDesctoDistribuidor";
            this.txtDesctoDistribuidor.Size = new System.Drawing.Size(42, 22);
            this.txtDesctoDistribuidor.TabIndex = 22;
            this.txtDesctoDistribuidor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDesctoDistribuidor_KeyPress);
            this.txtDesctoDistribuidor.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDesctoDistribuidor_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(592, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 16);
            this.label2.TabIndex = 21;
            this.label2.Text = "Descto a distribuidor";
            // 
            // txtDesctoMayor
            // 
            this.txtDesctoMayor.Location = new System.Drawing.Point(420, 56);
            this.txtDesctoMayor.Name = "txtDesctoMayor";
            this.txtDesctoMayor.Size = new System.Drawing.Size(42, 22);
            this.txtDesctoMayor.TabIndex = 20;
            this.txtDesctoMayor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDesctoMayor_KeyPress);
            this.txtDesctoMayor.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDesctoMayor_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(314, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 16);
            this.label1.TabIndex = 19;
            this.label1.Text = "Descto x mayor";
            // 
            // lblValorCosto
            // 
            this.lblValorCosto.AutoSize = true;
            this.lblValorCosto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblValorCosto.Location = new System.Drawing.Point(15, 23);
            this.lblValorCosto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblValorCosto.Name = "lblValorCosto";
            this.lblValorCosto.Size = new System.Drawing.Size(97, 16);
            this.lblValorCosto.TabIndex = 18;
            this.lblValorCosto.Text = "Valor de Costo";
            // 
            // txtValorCosto
            // 
            this.txtValorCosto.Location = new System.Drawing.Point(116, 20);
            this.txtValorCosto.Margin = new System.Windows.Forms.Padding(4);
            this.txtValorCosto.MaxLength = 15;
            this.txtValorCosto.Name = "txtValorCosto";
            this.txtValorCosto.Size = new System.Drawing.Size(162, 22);
            this.txtValorCosto.TabIndex = 17;
            this.txtValorCosto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValorCosto_KeyPress);
            this.txtValorCosto.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtValorCosto_KeyUp);
            // 
            // chkCantDecimal
            // 
            this.chkCantDecimal.AutoSize = true;
            this.chkCantDecimal.Location = new System.Drawing.Point(827, 20);
            this.chkCantDecimal.Name = "chkCantDecimal";
            this.chkCantDecimal.Size = new System.Drawing.Size(107, 20);
            this.chkCantDecimal.TabIndex = 16;
            this.chkCantDecimal.Text = "Cant Decimal";
            this.chkCantDecimal.UseVisualStyleBackColor = true;
            this.chkCantDecimal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.chkCantDecimal_KeyPress);
            // 
            // lblUtilidad
            // 
            this.lblUtilidad.AutoSize = true;
            this.lblUtilidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblUtilidad.Location = new System.Drawing.Point(294, 22);
            this.lblUtilidad.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUtilidad.Name = "lblUtilidad";
            this.lblUtilidad.Size = new System.Drawing.Size(77, 16);
            this.lblUtilidad.TabIndex = 10;
            this.lblUtilidad.Text = "Utilidad (%)";
            // 
            // txtUtilidad
            // 
            this.txtUtilidad.Location = new System.Drawing.Point(377, 19);
            this.txtUtilidad.Margin = new System.Windows.Forms.Padding(4);
            this.txtUtilidad.Name = "txtUtilidad";
            this.txtUtilidad.Size = new System.Drawing.Size(67, 22);
            this.txtUtilidad.TabIndex = 0;
            this.txtUtilidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUtilidad_KeyPress);
            this.txtUtilidad.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtUtilidad_KeyUp);
            this.txtUtilidad.Validating += new System.ComponentModel.CancelEventHandler(this.txtUtilidad_Validating);
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblPrecio.Location = new System.Drawing.Point(668, 23);
            this.lblPrecio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(47, 16);
            this.lblPrecio.TabIndex = 11;
            this.lblPrecio.Text = "Precio";
            // 
            // txtValorVenta
            // 
            this.txtValorVenta.Location = new System.Drawing.Point(717, 20);
            this.txtValorVenta.Margin = new System.Windows.Forms.Padding(4);
            this.txtValorVenta.Name = "txtValorVenta";
            this.txtValorVenta.Size = new System.Drawing.Size(103, 22);
            this.txtValorVenta.TabIndex = 1;
            this.txtValorVenta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValorVenta_KeyPress);
            this.txtValorVenta.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtValorVenta_KeyUp);
            this.txtValorVenta.Validating += new System.ComponentModel.CancelEventHandler(this.txtValorVenta_Validating);
            // 
            // lblAplicaPrecio
            // 
            this.lblAplicaPrecio.AutoSize = true;
            this.lblAplicaPrecio.Location = new System.Drawing.Point(12, 60);
            this.lblAplicaPrecio.Name = "lblAplicaPrecio";
            this.lblAplicaPrecio.Size = new System.Drawing.Size(70, 16);
            this.lblAplicaPrecio.TabIndex = 14;
            this.lblAplicaPrecio.Text = "Precio por";
            // 
            // txtAplicaPrecio
            // 
            this.txtAplicaPrecio.Enabled = false;
            this.txtAplicaPrecio.Location = new System.Drawing.Point(116, 57);
            this.txtAplicaPrecio.Name = "txtAplicaPrecio";
            this.txtAplicaPrecio.Size = new System.Drawing.Size(162, 22);
            this.txtAplicaPrecio.TabIndex = 5;
            // 
            // cbAplicarPrecio
            // 
            this.cbAplicarPrecio.DisplayMember = "Valor";
            this.cbAplicarPrecio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAplicarPrecio.FormattingEnabled = true;
            this.cbAplicarPrecio.Location = new System.Drawing.Point(116, 56);
            this.cbAplicarPrecio.Name = "cbAplicarPrecio";
            this.cbAplicarPrecio.Size = new System.Drawing.Size(162, 24);
            this.cbAplicarPrecio.TabIndex = 6;
            this.cbAplicarPrecio.ValueMember = "Id";
            this.cbAplicarPrecio.Visible = false;
            // 
            // btnEditarAplicaPrecio
            // 
            this.btnEditarAplicaPrecio.Image = ((System.Drawing.Image)(resources.GetObject("btnEditarAplicaPrecio.Image")));
            this.btnEditarAplicaPrecio.Location = new System.Drawing.Point(280, 57);
            this.btnEditarAplicaPrecio.Name = "btnEditarAplicaPrecio";
            this.btnEditarAplicaPrecio.Size = new System.Drawing.Size(27, 22);
            this.btnEditarAplicaPrecio.TabIndex = 4;
            this.btnEditarAplicaPrecio.UseVisualStyleBackColor = true;
            this.btnEditarAplicaPrecio.Click += new System.EventHandler(this.btnEditarAplicaPrecio_Click);
            // 
            // lblIva
            // 
            this.lblIva.AutoSize = true;
            this.lblIva.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblIva.Location = new System.Drawing.Point(449, 23);
            this.lblIva.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIva.Name = "lblIva";
            this.lblIva.Size = new System.Drawing.Size(52, 16);
            this.lblIva.TabIndex = 15;
            this.lblIva.Text = "IVA (%)";
            // 
            // txtIva
            // 
            this.txtIva.Enabled = false;
            this.txtIva.Location = new System.Drawing.Point(505, 20);
            this.txtIva.Name = "txtIva";
            this.txtIva.Size = new System.Drawing.Size(126, 22);
            this.txtIva.TabIndex = 8;
            // 
            // cbIvaEditar
            // 
            this.cbIvaEditar.DisplayMember = "ConceptoIva";
            this.cbIvaEditar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIvaEditar.FormattingEnabled = true;
            this.cbIvaEditar.Location = new System.Drawing.Point(504, 19);
            this.cbIvaEditar.Margin = new System.Windows.Forms.Padding(4);
            this.cbIvaEditar.Name = "cbIvaEditar";
            this.cbIvaEditar.Size = new System.Drawing.Size(127, 24);
            this.cbIvaEditar.TabIndex = 9;
            this.cbIvaEditar.ValueMember = "IdIva";
            this.cbIvaEditar.Visible = false;
            this.cbIvaEditar.SelectedIndexChanged += new System.EventHandler(this.cbIvaEditar_SelectedIndexChanged);
            this.cbIvaEditar.Enter += new System.EventHandler(this.cbIvaEditar_Enter);
            this.cbIvaEditar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbIvaEditar_KeyPress);
            // 
            // btnEditarIva
            // 
            this.btnEditarIva.Image = ((System.Drawing.Image)(resources.GetObject("btnEditarIva.Image")));
            this.btnEditarIva.Location = new System.Drawing.Point(638, 20);
            this.btnEditarIva.Name = "btnEditarIva";
            this.btnEditarIva.Size = new System.Drawing.Size(27, 22);
            this.btnEditarIva.TabIndex = 7;
            this.btnEditarIva.UseVisualStyleBackColor = true;
            this.btnEditarIva.Click += new System.EventHandler(this.btnEditarIva_Click);
            // 
            // gbMedida
            // 
            this.gbMedida.Controls.Add(this.cbUnidadesMedida);
            this.gbMedida.Controls.Add(this.label9);
            this.gbMedida.Controls.Add(this.lblPresentacion);
            this.gbMedida.Controls.Add(this.txtUnidadVenta);
            this.gbMedida.Controls.Add(this.lblCantMinima);
            this.gbMedida.Controls.Add(this.txtCantMinima);
            this.gbMedida.Controls.Add(this.lblCantMaxima);
            this.gbMedida.Controls.Add(this.txtCantMaxima);
            this.gbMedida.Controls.Add(this.rbActivo);
            this.gbMedida.Controls.Add(this.rbInactivo);
            this.gbMedida.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.gbMedida.Location = new System.Drawing.Point(13, 397);
            this.gbMedida.Margin = new System.Windows.Forms.Padding(4);
            this.gbMedida.Name = "gbMedida";
            this.gbMedida.Padding = new System.Windows.Forms.Padding(4);
            this.gbMedida.Size = new System.Drawing.Size(942, 85);
            this.gbMedida.TabIndex = 3;
            this.gbMedida.TabStop = false;
            this.gbMedida.Text = "Presentación y medida";
            // 
            // cbUnidadesMedida
            // 
            this.cbUnidadesMedida.DisplayMember = "DescripcionUnidadMedida";
            this.cbUnidadesMedida.FormattingEnabled = true;
            this.cbUnidadesMedida.Location = new System.Drawing.Point(277, 20);
            this.cbUnidadesMedida.Name = "cbUnidadesMedida";
            this.cbUnidadesMedida.Size = new System.Drawing.Size(386, 24);
            this.cbUnidadesMedida.TabIndex = 30;
            this.cbUnidadesMedida.ValueMember = "IdUnidadMedida";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.label9.Location = new System.Drawing.Point(216, 24);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 16);
            this.label9.TabIndex = 15;
            this.label9.Text = "Medida";
            // 
            // lblPresentacion
            // 
            this.lblPresentacion.AutoSize = true;
            this.lblPresentacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblPresentacion.Location = new System.Drawing.Point(14, 24);
            this.lblPresentacion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPresentacion.Name = "lblPresentacion";
            this.lblPresentacion.Size = new System.Drawing.Size(87, 16);
            this.lblPresentacion.TabIndex = 11;
            this.lblPresentacion.Text = "Presentación";
            // 
            // txtUnidadVenta
            // 
            this.txtUnidadVenta.Location = new System.Drawing.Point(104, 21);
            this.txtUnidadVenta.Margin = new System.Windows.Forms.Padding(4);
            this.txtUnidadVenta.Name = "txtUnidadVenta";
            this.txtUnidadVenta.Size = new System.Drawing.Size(100, 22);
            this.txtUnidadVenta.TabIndex = 0;
            this.txtUnidadVenta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUnidadVenta_KeyPress);
            this.txtUnidadVenta.Validating += new System.ComponentModel.CancelEventHandler(this.txtUnidadVenta_Validating);
            // 
            // lblCantMinima
            // 
            this.lblCantMinima.AutoSize = true;
            this.lblCantMinima.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblCantMinima.Location = new System.Drawing.Point(670, 24);
            this.lblCantMinima.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCantMinima.Name = "lblCantMinima";
            this.lblCantMinima.Size = new System.Drawing.Size(84, 16);
            this.lblCantMinima.TabIndex = 12;
            this.lblCantMinima.Text = "Cant Minima ";
            // 
            // txtCantMinima
            // 
            this.txtCantMinima.Location = new System.Drawing.Point(757, 21);
            this.txtCantMinima.Margin = new System.Windows.Forms.Padding(4);
            this.txtCantMinima.Name = "txtCantMinima";
            this.txtCantMinima.Size = new System.Drawing.Size(81, 22);
            this.txtCantMinima.TabIndex = 1;
            this.txtCantMinima.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantMinima_KeyPress);
            this.txtCantMinima.Validating += new System.ComponentModel.CancelEventHandler(this.txtCantMinima_Validating);
            // 
            // lblCantMaxima
            // 
            this.lblCantMaxima.AutoSize = true;
            this.lblCantMaxima.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblCantMaxima.Location = new System.Drawing.Point(687, 58);
            this.lblCantMaxima.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCantMaxima.Name = "lblCantMaxima";
            this.lblCantMaxima.Size = new System.Drawing.Size(66, 16);
            this.lblCantMaxima.TabIndex = 13;
            this.lblCantMaxima.Text = "Cant Max.";
            // 
            // txtCantMaxima
            // 
            this.txtCantMaxima.Location = new System.Drawing.Point(756, 55);
            this.txtCantMaxima.Margin = new System.Windows.Forms.Padding(4);
            this.txtCantMaxima.Name = "txtCantMaxima";
            this.txtCantMaxima.Size = new System.Drawing.Size(82, 22);
            this.txtCantMaxima.TabIndex = 2;
            this.txtCantMaxima.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantMaxima_KeyPress);
            this.txtCantMaxima.Validating += new System.ComponentModel.CancelEventHandler(this.txtCantMaxima_Validating);
            // 
            // rbActivo
            // 
            this.rbActivo.AutoSize = true;
            this.rbActivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.rbActivo.Location = new System.Drawing.Point(858, 22);
            this.rbActivo.Name = "rbActivo";
            this.rbActivo.Size = new System.Drawing.Size(63, 20);
            this.rbActivo.TabIndex = 7;
            this.rbActivo.TabStop = true;
            this.rbActivo.Text = "Activo";
            this.rbActivo.UseVisualStyleBackColor = true;
            // 
            // rbInactivo
            // 
            this.rbInactivo.AutoSize = true;
            this.rbInactivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.rbInactivo.Location = new System.Drawing.Point(858, 54);
            this.rbInactivo.Name = "rbInactivo";
            this.rbInactivo.Size = new System.Drawing.Size(72, 20);
            this.rbInactivo.TabIndex = 8;
            this.rbInactivo.TabStop = true;
            this.rbInactivo.Text = "Inactivo\r\n";
            this.rbInactivo.UseVisualStyleBackColor = true;
            // 
            // frmEditarProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(973, 487);
            this.Controls.Add(this.tsMenuEdicion);
            this.Controls.Add(this.gbInformacionGeneral);
            this.Controls.Add(this.gbPrecio);
            this.Controls.Add(this.gbMedida);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEditarProducto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editar Producto";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEditarProducto_FormClosing);
            this.Load += new System.EventHandler(this.frmEditarProducto_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmEditarProducto_KeyDown);
            this.tsMenuEdicion.ResumeLayout(false);
            this.tsMenuEdicion.PerformLayout();
            this.gbInformacionGeneral.ResumeLayout(false);
            this.gbInformacionGeneral.PerformLayout();
            this.gbSelecionarColor.ResumeLayout(false);
            this.gbSelecionarColor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedida)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbColor)).EndInit();
            this.gbSeleccionarMedida.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaMedida)).EndInit();
            this.gbPrecio.ResumeLayout(false);
            this.gbPrecio.PerformLayout();
            this.gbMedida.ResumeLayout(false);
            this.gbMedida.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMenuEdicion;
        private System.Windows.Forms.ToolStripButton tsbGuardarCambiosEditarProducto;
        private System.Windows.Forms.GroupBox gbInformacionGeneral;
        public System.Windows.Forms.TextBox txtMarca;
        private System.Windows.Forms.Button btnBuscarCategoria;
        private System.Windows.Forms.Button btnBuscarMarca;
        private System.Windows.Forms.LinkLabel lkGenerarBarras;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.LinkLabel lkGenerarCodigo;
        private System.Windows.Forms.Label lblBarras;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.GroupBox gbPrecio;
        private System.Windows.Forms.ComboBox cbIvaEditar;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.Label lblIva;
        private System.Windows.Forms.Label lblUtilidad;
        private System.Windows.Forms.GroupBox gbMedida;
        private System.Windows.Forms.TextBox txtCantMinima;
        private System.Windows.Forms.TextBox txtCantMaxima;
        private System.Windows.Forms.Label lblCantMinima;
        private System.Windows.Forms.Label lblPresentacion;
        private System.Windows.Forms.TextBox txtUnidadVenta;
        private System.Windows.Forms.Label lblCantMaxima;
        public System.Windows.Forms.TextBox txtCategoria;
        public System.Windows.Forms.TextBox txtNombre;
        public System.Windows.Forms.TextBox txtBarras;
        public System.Windows.Forms.TextBox txtCodigo;
        public System.Windows.Forms.TextBox txtUtilidad;
        public System.Windows.Forms.TextBox txtValorVenta;
        private System.Windows.Forms.TextBox txtIva;
        public System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.RadioButton rbInactivo;
        private System.Windows.Forms.RadioButton rbActivo;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.ToolStripButton tsbSalirEditarProducto;
        private System.Windows.Forms.Label lblReferencia;
        private System.Windows.Forms.TextBox txtReferencia;
        private System.Windows.Forms.Label lblAplicaPrecio;
        private System.Windows.Forms.ComboBox cbAplicarPrecio;
        private System.Windows.Forms.TextBox txtAplicaPrecio;
        private System.Windows.Forms.CheckedListBox chkLstDescuento;
        private System.Windows.Forms.CheckedListBox chkLstRecargo;
        private System.Windows.Forms.DataGridView dgvColor;
        private System.Windows.Forms.DataGridView dgvMedida;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdColor;
        private System.Windows.Forms.DataGridViewImageColumn Color;
        private System.Windows.Forms.Button btnEliminarColor;
        private System.Windows.Forms.Button btnAddColor;
        private System.Windows.Forms.GroupBox gbSelecionarColor;
        private System.Windows.Forms.Button btnCancelarColor;
        private System.Windows.Forms.Button btnElegirColor;
        private System.Windows.Forms.Button btnAgregarColor;
        private System.Windows.Forms.DataGridView dgvListaColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewImageColumn Column11;
        private System.Windows.Forms.PictureBox pbColor;
        private System.Windows.Forms.Button btnAddMedida;
        private System.Windows.Forms.Button btnEliminarMedida;
        private System.Windows.Forms.GroupBox gbSeleccionarMedida;
        private System.Windows.Forms.Button btnCancelarMedida;
        private System.Windows.Forms.Button btnElegirMedida;
        private System.Windows.Forms.DataGridView dgvListaMedida;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdTalla;
        private System.Windows.Forms.DataGridViewTextBoxColumn Talla;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdMedida;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdUnidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Medida;
        private System.Windows.Forms.ListBox lbValorMedida;
        private System.Windows.Forms.ListBox lbUnidadMedida;
        private System.Windows.Forms.ListBox lstbTalla;
        private System.Windows.Forms.RadioButton rbtnTalla;
        private System.Windows.Forms.RadioButton rbtnUnidadMedida;
        private System.Windows.Forms.Button btnEditarAplicaPrecio;
        private System.Windows.Forms.Button btnEditarIva;
        private System.Windows.Forms.CheckBox chkCantDecimal;
        private System.Windows.Forms.Label lblValorCosto;
        private System.Windows.Forms.TextBox txtValorCosto;
        private System.Windows.Forms.TextBox txtDesctoDistribuidor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDesctoMayor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtValorDesctoDistrib;
        private System.Windows.Forms.TextBox txtValorDesctoMayor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCodigo_7;
        private System.Windows.Forms.TextBox txtCodigo_6;
        private System.Windows.Forms.TextBox txtCodigo_5;
        private System.Windows.Forms.TextBox txtCodigo_4;
        private System.Windows.Forms.TextBox txtCodigo_3;
        private System.Windows.Forms.TextBox txtCodigo_2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbUnidadesMedida;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbTipoInventario;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbProdProceso;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblCuenta;
        private System.Windows.Forms.ComboBox cbCuentaContable;
        private System.Windows.Forms.ComboBox cbValorICO;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cbAplicaDescuento;
        private System.Windows.Forms.ComboBox cbImprime;
        private System.Windows.Forms.ComboBox cbAplicaICO;
    }
}