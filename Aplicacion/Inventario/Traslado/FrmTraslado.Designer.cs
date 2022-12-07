namespace Aplicacion.Inventario.Traslado
{
    partial class FrmTraslado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTraslado));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsMenuTraslado = new System.Windows.Forms.ToolStrip();
            this.tsBtnGuardar = new System.Windows.Forms.ToolStripButton();
            this.tsBtnSalir = new System.Windows.Forms.ToolStripButton();
            this.gbDatosTraslado = new System.Windows.Forms.GroupBox();
            this.btnConexionSi = new System.Windows.Forms.Button();
            this.btnConexionNo = new System.Windows.Forms.Button();
            this.txtCajaDestino = new System.Windows.Forms.TextBox();
            this.txtCajaOrigen = new System.Windows.Forms.TextBox();
            this.txtTrasladoDestino = new System.Windows.Forms.TextBox();
            this.txtTrasladoOrigen = new System.Windows.Forms.TextBox();
            this.cbCaja = new System.Windows.Forms.ComboBox();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblFecha = new System.Windows.Forms.Label();
            this.gbListadoArticulos = new System.Windows.Forms.GroupBox();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.dgvListaArticulos = new Aplicacion.Ventas.Factura.DataGridViewPlus();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Articulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Costo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbCargaProducto = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtInventario = new System.Windows.Forms.TextBox();
            this.txtCodigoArticulo = new System.Windows.Forms.TextBox();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.panelProducto = new System.Windows.Forms.Panel();
            this.lblDatosProducto = new System.Windows.Forms.Label();
            this.tsCargarInventario = new System.Windows.Forms.ToolStripButton();
            this.tsMenuTraslado.SuspendLayout();
            this.gbDatosTraslado.SuspendLayout();
            this.gbListadoArticulos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaArticulos)).BeginInit();
            this.gbCargaProducto.SuspendLayout();
            this.panelProducto.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMenuTraslado
            // 
            this.tsMenuTraslado.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsMenuTraslado.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnGuardar,
            this.tsCargarInventario,
            this.tsBtnSalir});
            this.tsMenuTraslado.Location = new System.Drawing.Point(0, 0);
            this.tsMenuTraslado.Name = "tsMenuTraslado";
            this.tsMenuTraslado.Size = new System.Drawing.Size(940, 25);
            this.tsMenuTraslado.TabIndex = 3;
            this.tsMenuTraslado.Text = "Menu Principal";
            // 
            // tsBtnGuardar
            // 
            this.tsBtnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnGuardar.Image")));
            this.tsBtnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnGuardar.Name = "tsBtnGuardar";
            this.tsBtnGuardar.Size = new System.Drawing.Size(101, 22);
            this.tsBtnGuardar.Text = "Guardar [F2]";
            this.tsBtnGuardar.Click += new System.EventHandler(this.tsBtnGuardar_Click);
            // 
            // tsBtnSalir
            // 
            this.tsBtnSalir.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnSalir.Image")));
            this.tsBtnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnSalir.Name = "tsBtnSalir";
            this.tsBtnSalir.Size = new System.Drawing.Size(87, 22);
            this.tsBtnSalir.Text = "Salir [ESC]";
            this.tsBtnSalir.Click += new System.EventHandler(this.tsBtnSalir_Click);
            // 
            // gbDatosTraslado
            // 
            this.gbDatosTraslado.Controls.Add(this.btnConexionSi);
            this.gbDatosTraslado.Controls.Add(this.btnConexionNo);
            this.gbDatosTraslado.Controls.Add(this.txtCajaDestino);
            this.gbDatosTraslado.Controls.Add(this.txtCajaOrigen);
            this.gbDatosTraslado.Controls.Add(this.txtTrasladoDestino);
            this.gbDatosTraslado.Controls.Add(this.txtTrasladoOrigen);
            this.gbDatosTraslado.Controls.Add(this.cbCaja);
            this.gbDatosTraslado.Controls.Add(this.dtpFecha);
            this.gbDatosTraslado.Controls.Add(this.lblFecha);
            this.gbDatosTraslado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.gbDatosTraslado.Location = new System.Drawing.Point(11, 28);
            this.gbDatosTraslado.Name = "gbDatosTraslado";
            this.gbDatosTraslado.Size = new System.Drawing.Size(547, 82);
            this.gbDatosTraslado.TabIndex = 2;
            this.gbDatosTraslado.TabStop = false;
            // 
            // btnConexionSi
            // 
            this.btnConexionSi.FlatAppearance.BorderSize = 0;
            this.btnConexionSi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConexionSi.Image = ((System.Drawing.Image)(resources.GetObject("btnConexionSi.Image")));
            this.btnConexionSi.Location = new System.Drawing.Point(522, 49);
            this.btnConexionSi.Name = "btnConexionSi";
            this.btnConexionSi.Size = new System.Drawing.Size(19, 18);
            this.btnConexionSi.TabIndex = 30;
            this.btnConexionSi.UseVisualStyleBackColor = true;
            this.btnConexionSi.Visible = false;
            this.btnConexionSi.Click += new System.EventHandler(this.btnConexionSi_Click);
            // 
            // btnConexionNo
            // 
            this.btnConexionNo.FlatAppearance.BorderSize = 0;
            this.btnConexionNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConexionNo.Image = ((System.Drawing.Image)(resources.GetObject("btnConexionNo.Image")));
            this.btnConexionNo.Location = new System.Drawing.Point(522, 48);
            this.btnConexionNo.Name = "btnConexionNo";
            this.btnConexionNo.Size = new System.Drawing.Size(19, 18);
            this.btnConexionNo.TabIndex = 29;
            this.btnConexionNo.UseVisualStyleBackColor = true;
            this.btnConexionNo.Click += new System.EventHandler(this.btnConexionNo_Click);
            // 
            // txtCajaDestino
            // 
            this.txtCajaDestino.Enabled = false;
            this.txtCajaDestino.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCajaDestino.Location = new System.Drawing.Point(350, 46);
            this.txtCajaDestino.Name = "txtCajaDestino";
            this.txtCajaDestino.Size = new System.Drawing.Size(88, 22);
            this.txtCajaDestino.TabIndex = 28;
            this.txtCajaDestino.Text = "CAJA";
            // 
            // txtCajaOrigen
            // 
            this.txtCajaOrigen.Enabled = false;
            this.txtCajaOrigen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCajaOrigen.Location = new System.Drawing.Point(181, 47);
            this.txtCajaOrigen.Name = "txtCajaOrigen";
            this.txtCajaOrigen.Size = new System.Drawing.Size(156, 22);
            this.txtCajaOrigen.TabIndex = 27;
            this.txtCajaOrigen.Text = "CAJA ";
            // 
            // txtTrasladoDestino
            // 
            this.txtTrasladoDestino.Enabled = false;
            this.txtTrasladoDestino.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTrasladoDestino.Location = new System.Drawing.Point(350, 19);
            this.txtTrasladoDestino.Name = "txtTrasladoDestino";
            this.txtTrasladoDestino.Size = new System.Drawing.Size(169, 22);
            this.txtTrasladoDestino.TabIndex = 26;
            this.txtTrasladoDestino.Text = "TRASLADO DESTINO";
            // 
            // txtTrasladoOrigen
            // 
            this.txtTrasladoOrigen.Enabled = false;
            this.txtTrasladoOrigen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTrasladoOrigen.Location = new System.Drawing.Point(181, 19);
            this.txtTrasladoOrigen.Name = "txtTrasladoOrigen";
            this.txtTrasladoOrigen.Size = new System.Drawing.Size(156, 22);
            this.txtTrasladoOrigen.TabIndex = 25;
            this.txtTrasladoOrigen.Text = "TRASLADO ORIGEN";
            // 
            // cbCaja
            // 
            this.cbCaja.DisplayMember = "numerocaja";
            this.cbCaja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCaja.FormattingEnabled = true;
            this.cbCaja.Location = new System.Drawing.Point(444, 45);
            this.cbCaja.Name = "cbCaja";
            this.cbCaja.Size = new System.Drawing.Size(75, 24);
            this.cbCaja.TabIndex = 24;
            this.cbCaja.ValueMember = "idcaja";
            this.cbCaja.SelectionChangeCommitted += new System.EventHandler(this.cbCaja_SelectionChangeCommitted);
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(63, 19);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(108, 22);
            this.dtpFecha.TabIndex = 22;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblFecha.Location = new System.Drawing.Point(13, 22);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(46, 16);
            this.lblFecha.TabIndex = 23;
            this.lblFecha.Text = "Fecha";
            // 
            // gbListadoArticulos
            // 
            this.gbListadoArticulos.Controls.Add(this.btnEliminar);
            this.gbListadoArticulos.Controls.Add(this.label1);
            this.gbListadoArticulos.Controls.Add(this.txtTotal);
            this.gbListadoArticulos.Controls.Add(this.dgvListaArticulos);
            this.gbListadoArticulos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.gbListadoArticulos.Location = new System.Drawing.Point(11, 220);
            this.gbListadoArticulos.Name = "gbListadoArticulos";
            this.gbListadoArticulos.Size = new System.Drawing.Size(920, 353);
            this.gbListadoArticulos.TabIndex = 1;
            this.gbListadoArticulos.TabStop = false;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.Location = new System.Drawing.Point(892, 13);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(25, 23);
            this.btnEliminar.TabIndex = 7;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label1.Location = new System.Drawing.Point(695, 315);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 25);
            this.label1.TabIndex = 9;
            this.label1.Text = "TOTAL";
            // 
            // txtTotal
            // 
            this.txtTotal.BackColor = System.Drawing.SystemColors.Control;
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.txtTotal.Location = new System.Drawing.Point(777, 313);
            this.txtTotal.MaxLength = 10;
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(115, 29);
            this.txtTotal.TabIndex = 8;
            this.txtTotal.Text = "0";
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
            this.Cantidad,
            this.Costo,
            this.Precio,
            this.SubTotal});
            this.dgvListaArticulos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvListaArticulos.Location = new System.Drawing.Point(7, 14);
            this.dgvListaArticulos.Name = "dgvListaArticulos";
            this.dgvListaArticulos.RowHeadersVisible = false;
            this.dgvListaArticulos.Size = new System.Drawing.Size(885, 297);
            this.dgvListaArticulos.TabIndex = 0;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // Codigo
            // 
            this.Codigo.DataPropertyName = "Codigo";
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            // 
            // Articulo
            // 
            this.Articulo.DataPropertyName = "Nombre";
            this.Articulo.HeaderText = "Producto";
            this.Articulo.Name = "Articulo";
            this.Articulo.ReadOnly = true;
            this.Articulo.Width = 330;
            // 
            // Cantidad
            // 
            this.Cantidad.DataPropertyName = "Cantidad";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "N2";
            dataGridViewCellStyle9.NullValue = null;
            this.Cantidad.DefaultCellStyle = dataGridViewCellStyle9;
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            // 
            // Costo
            // 
            this.Costo.DataPropertyName = "Costo";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "N0";
            dataGridViewCellStyle10.NullValue = null;
            this.Costo.DefaultCellStyle = dataGridViewCellStyle10;
            this.Costo.HeaderText = "Costo";
            this.Costo.Name = "Costo";
            this.Costo.ReadOnly = true;
            this.Costo.Width = 110;
            // 
            // Precio
            // 
            this.Precio.DataPropertyName = "Valor";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Format = "N0";
            dataGridViewCellStyle11.NullValue = null;
            this.Precio.DefaultCellStyle = dataGridViewCellStyle11;
            this.Precio.HeaderText = "Precio";
            this.Precio.Name = "Precio";
            this.Precio.ReadOnly = true;
            this.Precio.Width = 110;
            // 
            // SubTotal
            // 
            this.SubTotal.DataPropertyName = "Total";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.Format = "N0";
            dataGridViewCellStyle12.NullValue = null;
            this.SubTotal.DefaultCellStyle = dataGridViewCellStyle12;
            this.SubTotal.HeaderText = "Sub total";
            this.SubTotal.Name = "SubTotal";
            this.SubTotal.ReadOnly = true;
            this.SubTotal.Width = 110;
            // 
            // gbCargaProducto
            // 
            this.gbCargaProducto.Controls.Add(this.label2);
            this.gbCargaProducto.Controls.Add(this.txtInventario);
            this.gbCargaProducto.Controls.Add(this.txtCodigoArticulo);
            this.gbCargaProducto.Controls.Add(this.lblCantidad);
            this.gbCargaProducto.Controls.Add(this.txtCantidad);
            this.gbCargaProducto.Controls.Add(this.panelProducto);
            this.gbCargaProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.gbCargaProducto.Location = new System.Drawing.Point(11, 112);
            this.gbCargaProducto.Name = "gbCargaProducto";
            this.gbCargaProducto.Size = new System.Drawing.Size(901, 104);
            this.gbCargaProducto.TabIndex = 0;
            this.gbCargaProducto.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label2.Location = new System.Drawing.Point(528, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 25);
            this.label2.TabIndex = 9;
            this.label2.Text = "Inventario";
            // 
            // txtInventario
            // 
            this.txtInventario.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtInventario.Enabled = false;
            this.txtInventario.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInventario.Location = new System.Drawing.Point(627, 15);
            this.txtInventario.MaxLength = 10;
            this.txtInventario.Name = "txtInventario";
            this.txtInventario.Size = new System.Drawing.Size(82, 30);
            this.txtInventario.TabIndex = 8;
            this.txtInventario.Text = "0";
            this.txtInventario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtCodigoArticulo
            // 
            this.txtCodigoArticulo.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtCodigoArticulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.txtCodigoArticulo.Location = new System.Drawing.Point(9, 15);
            this.txtCodigoArticulo.MaxLength = 255;
            this.txtCodigoArticulo.Name = "txtCodigoArticulo";
            this.txtCodigoArticulo.Size = new System.Drawing.Size(514, 30);
            this.txtCodigoArticulo.TabIndex = 1;
            this.txtCodigoArticulo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoArticulo_KeyPress);
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblCantidad.Location = new System.Drawing.Point(715, 17);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(91, 25);
            this.lblCantidad.TabIndex = 4;
            this.lblCantidad.Text = "Cantidad";
            // 
            // txtCantidad
            // 
            this.txtCantidad.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.txtCantidad.Location = new System.Drawing.Point(810, 15);
            this.txtCantidad.MaxLength = 10;
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(82, 30);
            this.txtCantidad.TabIndex = 2;
            this.txtCantidad.Text = "0";
            this.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);
            // 
            // panelProducto
            // 
            this.panelProducto.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panelProducto.Controls.Add(this.lblDatosProducto);
            this.panelProducto.Location = new System.Drawing.Point(9, 52);
            this.panelProducto.Name = "panelProducto";
            this.panelProducto.Size = new System.Drawing.Size(883, 41);
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
            // tsCargarInventario
            // 
            this.tsCargarInventario.Image = ((System.Drawing.Image)(resources.GetObject("tsCargarInventario.Image")));
            this.tsCargarInventario.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsCargarInventario.Name = "tsCargarInventario";
            this.tsCargarInventario.Size = new System.Drawing.Size(154, 22);
            this.tsCargarInventario.Text = "Cargar inventario [F4]";
            this.tsCargarInventario.Click += new System.EventHandler(this.tsCargarInventario_Click);
            // 
            // FrmTraslado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(940, 580);
            this.Controls.Add(this.gbCargaProducto);
            this.Controls.Add(this.gbListadoArticulos);
            this.Controls.Add(this.gbDatosTraslado);
            this.Controls.Add(this.tsMenuTraslado);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmTraslado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Traslado de inventario";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmTraslado_FormClosing);
            this.Load += new System.EventHandler(this.FrmTraslado_Load);
            this.tsMenuTraslado.ResumeLayout(false);
            this.tsMenuTraslado.PerformLayout();
            this.gbDatosTraslado.ResumeLayout(false);
            this.gbDatosTraslado.PerformLayout();
            this.gbListadoArticulos.ResumeLayout(false);
            this.gbListadoArticulos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaArticulos)).EndInit();
            this.gbCargaProducto.ResumeLayout(false);
            this.gbCargaProducto.PerformLayout();
            this.panelProducto.ResumeLayout(false);
            this.panelProducto.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMenuTraslado;
        private System.Windows.Forms.ToolStripButton tsBtnGuardar;
        private System.Windows.Forms.ToolStripButton tsBtnSalir;
        private System.Windows.Forms.GroupBox gbDatosTraslado;
        private System.Windows.Forms.GroupBox gbListadoArticulos;
        private Ventas.Factura.DataGridViewPlus dgvListaArticulos;
        private System.Windows.Forms.GroupBox gbCargaProducto;
        public System.Windows.Forms.TextBox txtCodigoArticulo;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Panel panelProducto;
        private System.Windows.Forms.Label lblDatosProducto;
        private System.Windows.Forms.ComboBox cbCaja;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.TextBox txtTrasladoDestino;
        private System.Windows.Forms.TextBox txtTrasladoOrigen;
        private System.Windows.Forms.TextBox txtCajaDestino;
        private System.Windows.Forms.TextBox txtCajaOrigen;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnConexionNo;
        private System.Windows.Forms.Button btnConexionSi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtInventario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Articulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Costo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubTotal;
        private System.Windows.Forms.ToolStripButton tsCargarInventario;
    }
}