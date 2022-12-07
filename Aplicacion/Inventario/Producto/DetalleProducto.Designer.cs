namespace Aplicacion.Inventario.Producto
{
    partial class frmDetalleProducto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDetalleProducto));
            this.tsMenuDetalle = new System.Windows.Forms.ToolStrip();
            this.tsbSalirDetalleProducto = new System.Windows.Forms.ToolStripButton();
            this.lblPresentacion = new System.Windows.Forms.Label();
            this.lblMedida = new System.Windows.Forms.Label();
            this.lblMarca = new System.Windows.Forms.Label();
            this.lblCantMaxima = new System.Windows.Forms.Label();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.lblCantMinima = new System.Windows.Forms.Label();
            this.lblUtilidad = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.txtMedida = new System.Windows.Forms.TextBox();
            this.txtPresentacion = new System.Windows.Forms.TextBox();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.txtIva = new System.Windows.Forms.TextBox();
            this.txtMarca = new System.Windows.Forms.TextBox();
            this.txtCantidadMinima = new System.Windows.Forms.TextBox();
            this.txtCantidadMaxima = new System.Windows.Forms.TextBox();
            this.txtUtilidad = new System.Windows.Forms.TextBox();
            this.txtEstado = new System.Windows.Forms.TextBox();
            this.lblDescuento = new System.Windows.Forms.Label();
            this.lblRecargo = new System.Windows.Forms.Label();
            this.gbInformacionGeneral = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtImprime = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtAplicaDescto = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAplicaICO = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtICO = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblBarras = new System.Windows.Forms.Label();
            this.txtBarras = new System.Windows.Forms.TextBox();
            this.lblReferencia = new System.Windows.Forms.Label();
            this.txtReferencia = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.txtCategoria = new System.Windows.Forms.TextBox();
            this.gbPrecio = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtValorDestoDistri = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDestoDistri = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtValorDestoMayor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDestoMayor = new System.Windows.Forms.TextBox();
            this.chkCantDecimal = new System.Windows.Forms.CheckBox();
            this.lblAplicaPrecio = new System.Windows.Forms.Label();
            this.txtAplicaPrecio = new System.Windows.Forms.TextBox();
            this.lblIva = new System.Windows.Forms.Label();
            this.cbDescuento = new System.Windows.Forms.ComboBox();
            this.cbRecargo = new System.Windows.Forms.ComboBox();
            this.gbPresentacionMedida = new System.Windows.Forms.GroupBox();
            this.cbMedida = new System.Windows.Forms.ComboBox();
            this.dgvColores = new System.Windows.Forms.DataGridView();
            this.Color = new System.Windows.Forms.DataGridViewImageColumn();
            this.tsMenuDetalle.SuspendLayout();
            this.gbInformacionGeneral.SuspendLayout();
            this.gbPrecio.SuspendLayout();
            this.gbPresentacionMedida.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColores)).BeginInit();
            this.SuspendLayout();
            // 
            // tsMenuDetalle
            // 
            this.tsMenuDetalle.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSalirDetalleProducto});
            this.tsMenuDetalle.Location = new System.Drawing.Point(0, 0);
            this.tsMenuDetalle.Name = "tsMenuDetalle";
            this.tsMenuDetalle.Size = new System.Drawing.Size(807, 25);
            this.tsMenuDetalle.TabIndex = 0;
            this.tsMenuDetalle.Text = "Menu Principal";
            // 
            // tsbSalirDetalleProducto
            // 
            this.tsbSalirDetalleProducto.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.tsbSalirDetalleProducto.Image = ((System.Drawing.Image)(resources.GetObject("tsbSalirDetalleProducto.Image")));
            this.tsbSalirDetalleProducto.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSalirDetalleProducto.Name = "tsbSalirDetalleProducto";
            this.tsbSalirDetalleProducto.Size = new System.Drawing.Size(91, 22);
            this.tsbSalirDetalleProducto.Text = "Salir [ESC]";
            this.tsbSalirDetalleProducto.Click += new System.EventHandler(this.tsbSalirDetalleProducto_Click);
            // 
            // lblPresentacion
            // 
            this.lblPresentacion.AutoSize = true;
            this.lblPresentacion.Location = new System.Drawing.Point(205, 32);
            this.lblPresentacion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPresentacion.Name = "lblPresentacion";
            this.lblPresentacion.Size = new System.Drawing.Size(87, 16);
            this.lblPresentacion.TabIndex = 2;
            this.lblPresentacion.Text = "Presentación";
            // 
            // lblMedida
            // 
            this.lblMedida.AutoSize = true;
            this.lblMedida.Location = new System.Drawing.Point(416, 32);
            this.lblMedida.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMedida.Name = "lblMedida";
            this.lblMedida.Size = new System.Drawing.Size(54, 16);
            this.lblMedida.TabIndex = 4;
            this.lblMedida.Text = "Medida";
            // 
            // lblMarca
            // 
            this.lblMarca.AutoSize = true;
            this.lblMarca.Location = new System.Drawing.Point(7, 124);
            this.lblMarca.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(46, 16);
            this.lblMarca.TabIndex = 12;
            this.lblMarca.Text = "Marca";
            // 
            // lblCantMaxima
            // 
            this.lblCantMaxima.AutoSize = true;
            this.lblCantMaxima.Location = new System.Drawing.Point(12, 92);
            this.lblCantMaxima.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCantMaxima.Name = "lblCantMaxima";
            this.lblCantMaxima.Size = new System.Drawing.Size(69, 16);
            this.lblCantMaxima.TabIndex = 6;
            this.lblCantMaxima.Text = "Cant. Max.";
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Location = new System.Drawing.Point(7, 31);
            this.lblPrecio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(47, 16);
            this.lblPrecio.TabIndex = 0;
            this.lblPrecio.Text = "Precio";
            // 
            // lblCantMinima
            // 
            this.lblCantMinima.AutoSize = true;
            this.lblCantMinima.Location = new System.Drawing.Point(12, 32);
            this.lblCantMinima.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCantMinima.Name = "lblCantMinima";
            this.lblCantMinima.Size = new System.Drawing.Size(65, 16);
            this.lblCantMinima.TabIndex = 0;
            this.lblCantMinima.Text = "Cant. Min.";
            // 
            // lblUtilidad
            // 
            this.lblUtilidad.AutoSize = true;
            this.lblUtilidad.Location = new System.Drawing.Point(204, 31);
            this.lblUtilidad.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUtilidad.Name = "lblUtilidad";
            this.lblUtilidad.Size = new System.Drawing.Size(77, 16);
            this.lblUtilidad.TabIndex = 2;
            this.lblUtilidad.Text = "Utilidad (%)";
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(205, 92);
            this.lblEstado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(51, 16);
            this.lblEstado.TabIndex = 8;
            this.lblEstado.Text = "Estado";
            // 
            // txtMedida
            // 
            this.txtMedida.Enabled = false;
            this.txtMedida.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMedida.Location = new System.Drawing.Point(477, 29);
            this.txtMedida.Name = "txtMedida";
            this.txtMedida.Size = new System.Drawing.Size(290, 22);
            this.txtMedida.TabIndex = 10;
            this.txtMedida.Visible = false;
            // 
            // txtPresentacion
            // 
            this.txtPresentacion.Enabled = false;
            this.txtPresentacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPresentacion.Location = new System.Drawing.Point(300, 29);
            this.txtPresentacion.Name = "txtPresentacion";
            this.txtPresentacion.Size = new System.Drawing.Size(100, 22);
            this.txtPresentacion.TabIndex = 3;
            // 
            // txtPrecio
            // 
            this.txtPrecio.Enabled = false;
            this.txtPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecio.Location = new System.Drawing.Point(57, 28);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(137, 22);
            this.txtPrecio.TabIndex = 1;
            this.txtPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtIva
            // 
            this.txtIva.Enabled = false;
            this.txtIva.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIva.Location = new System.Drawing.Point(610, 30);
            this.txtIva.Name = "txtIva";
            this.txtIva.Size = new System.Drawing.Size(36, 22);
            this.txtIva.TabIndex = 9;
            // 
            // txtMarca
            // 
            this.txtMarca.Enabled = false;
            this.txtMarca.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMarca.Location = new System.Drawing.Point(109, 121);
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.Size = new System.Drawing.Size(183, 22);
            this.txtMarca.TabIndex = 13;
            // 
            // txtCantidadMinima
            // 
            this.txtCantidadMinima.Enabled = false;
            this.txtCantidadMinima.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidadMinima.Location = new System.Drawing.Point(86, 29);
            this.txtCantidadMinima.Name = "txtCantidadMinima";
            this.txtCantidadMinima.Size = new System.Drawing.Size(100, 22);
            this.txtCantidadMinima.TabIndex = 1;
            // 
            // txtCantidadMaxima
            // 
            this.txtCantidadMaxima.Enabled = false;
            this.txtCantidadMaxima.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidadMaxima.Location = new System.Drawing.Point(86, 89);
            this.txtCantidadMaxima.Name = "txtCantidadMaxima";
            this.txtCantidadMaxima.Size = new System.Drawing.Size(100, 22);
            this.txtCantidadMaxima.TabIndex = 7;
            // 
            // txtUtilidad
            // 
            this.txtUtilidad.Enabled = false;
            this.txtUtilidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUtilidad.Location = new System.Drawing.Point(286, 28);
            this.txtUtilidad.Name = "txtUtilidad";
            this.txtUtilidad.Size = new System.Drawing.Size(41, 22);
            this.txtUtilidad.TabIndex = 3;
            // 
            // txtEstado
            // 
            this.txtEstado.Enabled = false;
            this.txtEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEstado.Location = new System.Drawing.Point(300, 89);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Size = new System.Drawing.Size(100, 22);
            this.txtEstado.TabIndex = 9;
            // 
            // lblDescuento
            // 
            this.lblDescuento.AutoSize = true;
            this.lblDescuento.Location = new System.Drawing.Point(12, 155);
            this.lblDescuento.Name = "lblDescuento";
            this.lblDescuento.Size = new System.Drawing.Size(103, 16);
            this.lblDescuento.TabIndex = 4;
            this.lblDescuento.Text = "Descuentos (%)";
            this.lblDescuento.Visible = false;
            // 
            // lblRecargo
            // 
            this.lblRecargo.AutoSize = true;
            this.lblRecargo.Location = new System.Drawing.Point(294, 155);
            this.lblRecargo.Name = "lblRecargo";
            this.lblRecargo.Size = new System.Drawing.Size(91, 16);
            this.lblRecargo.TabIndex = 10;
            this.lblRecargo.Text = "Recargos (%)";
            this.lblRecargo.Visible = false;
            // 
            // gbInformacionGeneral
            // 
            this.gbInformacionGeneral.Controls.Add(this.label7);
            this.gbInformacionGeneral.Controls.Add(this.txtImprime);
            this.gbInformacionGeneral.Controls.Add(this.label8);
            this.gbInformacionGeneral.Controls.Add(this.txtAplicaDescto);
            this.gbInformacionGeneral.Controls.Add(this.label5);
            this.gbInformacionGeneral.Controls.Add(this.txtAplicaICO);
            this.gbInformacionGeneral.Controls.Add(this.label6);
            this.gbInformacionGeneral.Controls.Add(this.txtICO);
            this.gbInformacionGeneral.Controls.Add(this.lblCodigo);
            this.gbInformacionGeneral.Controls.Add(this.txtCodigo);
            this.gbInformacionGeneral.Controls.Add(this.lblBarras);
            this.gbInformacionGeneral.Controls.Add(this.txtBarras);
            this.gbInformacionGeneral.Controls.Add(this.lblReferencia);
            this.gbInformacionGeneral.Controls.Add(this.txtReferencia);
            this.gbInformacionGeneral.Controls.Add(this.lblNombre);
            this.gbInformacionGeneral.Controls.Add(this.txtNombre);
            this.gbInformacionGeneral.Controls.Add(this.lblDescripcion);
            this.gbInformacionGeneral.Controls.Add(this.txtDescripcion);
            this.gbInformacionGeneral.Controls.Add(this.lblCategoria);
            this.gbInformacionGeneral.Controls.Add(this.txtCategoria);
            this.gbInformacionGeneral.Controls.Add(this.lblMarca);
            this.gbInformacionGeneral.Controls.Add(this.txtMarca);
            this.gbInformacionGeneral.Location = new System.Drawing.Point(15, 29);
            this.gbInformacionGeneral.Name = "gbInformacionGeneral";
            this.gbInformacionGeneral.Size = new System.Drawing.Size(777, 156);
            this.gbInformacionGeneral.TabIndex = 1;
            this.gbInformacionGeneral.TabStop = false;
            this.gbInformacionGeneral.Text = "Informacion General";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(513, 91);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 16);
            this.label7.TabIndex = 18;
            this.label7.Text = "Imprime";
            // 
            // txtImprime
            // 
            this.txtImprime.Enabled = false;
            this.txtImprime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImprime.Location = new System.Drawing.Point(596, 88);
            this.txtImprime.Name = "txtImprime";
            this.txtImprime.Size = new System.Drawing.Size(112, 22);
            this.txtImprime.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(513, 124);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 16);
            this.label8.TabIndex = 20;
            this.label8.Text = "Aplica Dcto";
            // 
            // txtAplicaDescto
            // 
            this.txtAplicaDescto.Enabled = false;
            this.txtAplicaDescto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAplicaDescto.Location = new System.Drawing.Point(596, 121);
            this.txtAplicaDescto.Name = "txtAplicaDescto";
            this.txtAplicaDescto.Size = new System.Drawing.Size(112, 22);
            this.txtAplicaDescto.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(309, 91);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 16);
            this.label5.TabIndex = 14;
            this.label5.Text = "Aplica ICO";
            // 
            // txtAplicaICO
            // 
            this.txtAplicaICO.Enabled = false;
            this.txtAplicaICO.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAplicaICO.Location = new System.Drawing.Point(383, 88);
            this.txtAplicaICO.Name = "txtAplicaICO";
            this.txtAplicaICO.Size = new System.Drawing.Size(112, 22);
            this.txtAplicaICO.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(309, 124);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 16);
            this.label6.TabIndex = 16;
            this.label6.Text = "ICO";
            // 
            // txtICO
            // 
            this.txtICO.Enabled = false;
            this.txtICO.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtICO.Location = new System.Drawing.Point(383, 121);
            this.txtICO.Name = "txtICO";
            this.txtICO.Size = new System.Drawing.Size(112, 22);
            this.txtICO.TabIndex = 17;
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(7, 29);
            this.lblCodigo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(95, 16);
            this.lblCodigo.TabIndex = 0;
            this.lblCodigo.Text = "Codigo Interno";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Enabled = false;
            this.txtCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigo.Location = new System.Drawing.Point(109, 23);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(144, 22);
            this.txtCodigo.TabIndex = 1;
            // 
            // lblBarras
            // 
            this.lblBarras.AutoSize = true;
            this.lblBarras.Location = new System.Drawing.Point(274, 29);
            this.lblBarras.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBarras.Name = "lblBarras";
            this.lblBarras.Size = new System.Drawing.Size(114, 16);
            this.lblBarras.TabIndex = 2;
            this.lblBarras.Text = "Codigo de Barras";
            // 
            // txtBarras
            // 
            this.txtBarras.Enabled = false;
            this.txtBarras.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBarras.Location = new System.Drawing.Point(395, 23);
            this.txtBarras.Name = "txtBarras";
            this.txtBarras.Size = new System.Drawing.Size(100, 22);
            this.txtBarras.TabIndex = 3;
            // 
            // lblReferencia
            // 
            this.lblReferencia.AutoSize = true;
            this.lblReferencia.Location = new System.Drawing.Point(511, 26);
            this.lblReferencia.Name = "lblReferencia";
            this.lblReferencia.Size = new System.Drawing.Size(74, 16);
            this.lblReferencia.TabIndex = 4;
            this.lblReferencia.Text = "Referencia";
            // 
            // txtReferencia
            // 
            this.txtReferencia.Enabled = false;
            this.txtReferencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReferencia.Location = new System.Drawing.Point(596, 23);
            this.txtReferencia.Name = "txtReferencia";
            this.txtReferencia.Size = new System.Drawing.Size(171, 22);
            this.txtReferencia.TabIndex = 5;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(7, 58);
            this.lblNombre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(57, 16);
            this.lblNombre.TabIndex = 6;
            this.lblNombre.Text = "Nombre";
            // 
            // txtNombre
            // 
            this.txtNombre.Enabled = false;
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(109, 55);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(4);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(386, 22);
            this.txtNombre.TabIndex = 7;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(511, 58);
            this.lblDescripcion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(83, 16);
            this.lblDescripcion.TabIndex = 8;
            this.lblDescripcion.Text = "Descripcion ";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Enabled = false;
            this.txtDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.Location = new System.Drawing.Point(596, 55);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(171, 22);
            this.txtDescripcion.TabIndex = 9;
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Location = new System.Drawing.Point(7, 91);
            this.lblCategoria.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(67, 16);
            this.lblCategoria.TabIndex = 10;
            this.lblCategoria.Text = "Categoria";
            // 
            // txtCategoria
            // 
            this.txtCategoria.Enabled = false;
            this.txtCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCategoria.Location = new System.Drawing.Point(109, 88);
            this.txtCategoria.Name = "txtCategoria";
            this.txtCategoria.Size = new System.Drawing.Size(183, 22);
            this.txtCategoria.TabIndex = 11;
            // 
            // gbPrecio
            // 
            this.gbPrecio.Controls.Add(this.label3);
            this.gbPrecio.Controls.Add(this.txtValorDestoDistri);
            this.gbPrecio.Controls.Add(this.label4);
            this.gbPrecio.Controls.Add(this.txtDestoDistri);
            this.gbPrecio.Controls.Add(this.label2);
            this.gbPrecio.Controls.Add(this.txtValorDestoMayor);
            this.gbPrecio.Controls.Add(this.label1);
            this.gbPrecio.Controls.Add(this.txtDestoMayor);
            this.gbPrecio.Controls.Add(this.chkCantDecimal);
            this.gbPrecio.Controls.Add(this.lblPrecio);
            this.gbPrecio.Controls.Add(this.txtPrecio);
            this.gbPrecio.Controls.Add(this.lblUtilidad);
            this.gbPrecio.Controls.Add(this.txtUtilidad);
            this.gbPrecio.Controls.Add(this.lblAplicaPrecio);
            this.gbPrecio.Controls.Add(this.txtAplicaPrecio);
            this.gbPrecio.Controls.Add(this.lblIva);
            this.gbPrecio.Controls.Add(this.txtIva);
            this.gbPrecio.Location = new System.Drawing.Point(15, 194);
            this.gbPrecio.Name = "gbPrecio";
            this.gbPrecio.Size = new System.Drawing.Size(777, 105);
            this.gbPrecio.TabIndex = 2;
            this.gbPrecio.TabStop = false;
            this.gbPrecio.Text = "Informacion de Precio";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(522, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 16);
            this.label3.TabIndex = 20;
            this.label3.Text = "$";
            // 
            // txtValorDestoDistri
            // 
            this.txtValorDestoDistri.Enabled = false;
            this.txtValorDestoDistri.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValorDestoDistri.Location = new System.Drawing.Point(540, 64);
            this.txtValorDestoDistri.Name = "txtValorDestoDistri";
            this.txtValorDestoDistri.Size = new System.Drawing.Size(137, 22);
            this.txtValorDestoDistri.TabIndex = 19;
            this.txtValorDestoDistri.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(339, 67);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 16);
            this.label4.TabIndex = 17;
            this.label4.Text = "Descto a Distribuidor";
            // 
            // txtDestoDistri
            // 
            this.txtDestoDistri.Enabled = false;
            this.txtDestoDistri.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDestoDistri.Location = new System.Drawing.Point(477, 64);
            this.txtDestoDistri.Name = "txtDestoDistri";
            this.txtDestoDistri.Size = new System.Drawing.Size(41, 22);
            this.txtDestoDistri.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(172, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 16);
            this.label2.TabIndex = 16;
            this.label2.Text = "$";
            // 
            // txtValorDestoMayor
            // 
            this.txtValorDestoMayor.Enabled = false;
            this.txtValorDestoMayor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValorDestoMayor.Location = new System.Drawing.Point(190, 64);
            this.txtValorDestoMayor.Name = "txtValorDestoMayor";
            this.txtValorDestoMayor.Size = new System.Drawing.Size(137, 22);
            this.txtValorDestoMayor.TabIndex = 15;
            this.txtValorDestoMayor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 67);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 16);
            this.label1.TabIndex = 13;
            this.label1.Text = "Descto por Mayor";
            // 
            // txtDestoMayor
            // 
            this.txtDestoMayor.Enabled = false;
            this.txtDestoMayor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDestoMayor.Location = new System.Drawing.Point(127, 64);
            this.txtDestoMayor.Name = "txtDestoMayor";
            this.txtDestoMayor.Size = new System.Drawing.Size(41, 22);
            this.txtDestoMayor.TabIndex = 14;
            // 
            // chkCantDecimal
            // 
            this.chkCantDecimal.AutoSize = true;
            this.chkCantDecimal.Enabled = false;
            this.chkCantDecimal.Location = new System.Drawing.Point(664, 31);
            this.chkCantDecimal.Name = "chkCantDecimal";
            this.chkCantDecimal.Size = new System.Drawing.Size(107, 20);
            this.chkCantDecimal.TabIndex = 12;
            this.chkCantDecimal.Text = "Cant Decimal";
            this.chkCantDecimal.UseVisualStyleBackColor = true;
            // 
            // lblAplicaPrecio
            // 
            this.lblAplicaPrecio.AutoSize = true;
            this.lblAplicaPrecio.Location = new System.Drawing.Point(338, 31);
            this.lblAplicaPrecio.Name = "lblAplicaPrecio";
            this.lblAplicaPrecio.Size = new System.Drawing.Size(70, 16);
            this.lblAplicaPrecio.TabIndex = 6;
            this.lblAplicaPrecio.Text = "Precio por";
            // 
            // txtAplicaPrecio
            // 
            this.txtAplicaPrecio.Enabled = false;
            this.txtAplicaPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAplicaPrecio.Location = new System.Drawing.Point(411, 28);
            this.txtAplicaPrecio.Name = "txtAplicaPrecio";
            this.txtAplicaPrecio.Size = new System.Drawing.Size(137, 22);
            this.txtAplicaPrecio.TabIndex = 7;
            // 
            // lblIva
            // 
            this.lblIva.AutoSize = true;
            this.lblIva.Location = new System.Drawing.Point(558, 31);
            this.lblIva.Name = "lblIva";
            this.lblIva.Size = new System.Drawing.Size(49, 16);
            this.lblIva.TabIndex = 8;
            this.lblIva.Text = "Iva (%)";
            // 
            // cbDescuento
            // 
            this.cbDescuento.DisplayMember = "ValorDescuento";
            this.cbDescuento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDescuento.FormattingEnabled = true;
            this.cbDescuento.Location = new System.Drawing.Point(132, 152);
            this.cbDescuento.Name = "cbDescuento";
            this.cbDescuento.Size = new System.Drawing.Size(111, 24);
            this.cbDescuento.TabIndex = 5;
            this.cbDescuento.Visible = false;
            // 
            // cbRecargo
            // 
            this.cbRecargo.DisplayMember = "ValorRecargo";
            this.cbRecargo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRecargo.FormattingEnabled = true;
            this.cbRecargo.Location = new System.Drawing.Point(411, 152);
            this.cbRecargo.Name = "cbRecargo";
            this.cbRecargo.Size = new System.Drawing.Size(111, 24);
            this.cbRecargo.TabIndex = 11;
            this.cbRecargo.Visible = false;
            // 
            // gbPresentacionMedida
            // 
            this.gbPresentacionMedida.Controls.Add(this.lblCantMinima);
            this.gbPresentacionMedida.Controls.Add(this.txtCantidadMinima);
            this.gbPresentacionMedida.Controls.Add(this.lblPresentacion);
            this.gbPresentacionMedida.Controls.Add(this.txtPresentacion);
            this.gbPresentacionMedida.Controls.Add(this.lblDescuento);
            this.gbPresentacionMedida.Controls.Add(this.cbDescuento);
            this.gbPresentacionMedida.Controls.Add(this.lblMedida);
            this.gbPresentacionMedida.Controls.Add(this.cbMedida);
            this.gbPresentacionMedida.Controls.Add(this.lblRecargo);
            this.gbPresentacionMedida.Controls.Add(this.cbRecargo);
            this.gbPresentacionMedida.Controls.Add(this.lblCantMaxima);
            this.gbPresentacionMedida.Controls.Add(this.txtCantidadMaxima);
            this.gbPresentacionMedida.Controls.Add(this.lblEstado);
            this.gbPresentacionMedida.Controls.Add(this.txtEstado);
            this.gbPresentacionMedida.Controls.Add(this.txtMedida);
            this.gbPresentacionMedida.Controls.Add(this.dgvColores);
            this.gbPresentacionMedida.Location = new System.Drawing.Point(15, 305);
            this.gbPresentacionMedida.Name = "gbPresentacionMedida";
            this.gbPresentacionMedida.Size = new System.Drawing.Size(777, 144);
            this.gbPresentacionMedida.TabIndex = 3;
            this.gbPresentacionMedida.TabStop = false;
            this.gbPresentacionMedida.Text = "Presentacion y Medida";
            // 
            // cbMedida
            // 
            this.cbMedida.DisplayMember = "descripcionvalor_unidad_medida";
            this.cbMedida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMedida.FormattingEnabled = true;
            this.cbMedida.Location = new System.Drawing.Point(477, 29);
            this.cbMedida.Name = "cbMedida";
            this.cbMedida.Size = new System.Drawing.Size(106, 24);
            this.cbMedida.TabIndex = 5;
            this.cbMedida.ValueMember = "idvalor_unidad_medida";
            this.cbMedida.SelectionChangeCommitted += new System.EventHandler(this.cbMedida_SelectionChangeCommitted);
            // 
            // dgvColores
            // 
            this.dgvColores.AllowUserToAddRows = false;
            this.dgvColores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvColores.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvColores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvColores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Color});
            this.dgvColores.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvColores.Location = new System.Drawing.Point(599, 29);
            this.dgvColores.Name = "dgvColores";
            this.dgvColores.Size = new System.Drawing.Size(150, 152);
            this.dgvColores.TabIndex = 11;
            this.dgvColores.Visible = false;
            // 
            // Color
            // 
            this.Color.DataPropertyName = "Color";
            this.Color.HeaderText = "Color";
            this.Color.Name = "Color";
            this.Color.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Color.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // frmDetalleProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(807, 465);
            this.Controls.Add(this.tsMenuDetalle);
            this.Controls.Add(this.gbInformacionGeneral);
            this.Controls.Add(this.gbPrecio);
            this.Controls.Add(this.gbPresentacionMedida);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDetalleProducto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalle Producto";
            this.Load += new System.EventHandler(this.frmDetalleProducto_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmDetalleProducto_KeyDown);
            this.tsMenuDetalle.ResumeLayout(false);
            this.tsMenuDetalle.PerformLayout();
            this.gbInformacionGeneral.ResumeLayout(false);
            this.gbInformacionGeneral.PerformLayout();
            this.gbPrecio.ResumeLayout(false);
            this.gbPrecio.PerformLayout();
            this.gbPresentacionMedida.ResumeLayout(false);
            this.gbPresentacionMedida.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMenuDetalle;
        private System.Windows.Forms.ToolStripButton tsbSalirDetalleProducto;
        private System.Windows.Forms.Label lblPresentacion;
        private System.Windows.Forms.Label lblMedida;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.Label lblCantMaxima;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.Label lblCantMinima;
        private System.Windows.Forms.Label lblUtilidad;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.TextBox txtMedida;
        private System.Windows.Forms.TextBox txtPresentacion;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.TextBox txtIva;
        private System.Windows.Forms.TextBox txtMarca;
        private System.Windows.Forms.TextBox txtCantidadMinima;
        private System.Windows.Forms.TextBox txtCantidadMaxima;
        private System.Windows.Forms.TextBox txtUtilidad;
        private System.Windows.Forms.TextBox txtEstado;
        private System.Windows.Forms.Label lblDescuento;
        private System.Windows.Forms.Label lblRecargo;
        private System.Windows.Forms.GroupBox gbInformacionGeneral;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.TextBox txtBarras;
        private System.Windows.Forms.Label lblBarras;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtCategoria;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.GroupBox gbPrecio;
        private System.Windows.Forms.Label lblReferencia;
        private System.Windows.Forms.TextBox txtReferencia;
        private System.Windows.Forms.TextBox txtAplicaPrecio;
        private System.Windows.Forms.Label lblAplicaPrecio;
        private System.Windows.Forms.Label lblIva;
        private System.Windows.Forms.ComboBox cbRecargo;
        private System.Windows.Forms.ComboBox cbDescuento;
        private System.Windows.Forms.GroupBox gbPresentacionMedida;
        private System.Windows.Forms.DataGridView dgvColores;
        private System.Windows.Forms.DataGridViewImageColumn Color;
        private System.Windows.Forms.ComboBox cbMedida;
        private System.Windows.Forms.CheckBox chkCantDecimal;
        private System.Windows.Forms.TextBox txtValorDestoMayor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDestoMayor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtValorDestoDistri;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDestoDistri;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAplicaICO;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtICO;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtImprime;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtAplicaDescto;
    }
}