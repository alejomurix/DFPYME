namespace Aplicacion.Inventario.Consulta
{
    partial class FrmInventario
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
            new System.ComponentModel.ComponentResourceManager(typeof(FrmInventario));

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInventario));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtCodigoNombre = new System.Windows.Forms.TextBox();
            this.gbResultado = new System.Windows.Forms.GroupBox();
            this.chkVerId = new System.Windows.Forms.CheckBox();
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.tsEditarPrecio = new System.Windows.Forms.ToolStripButton();
            this.tsBtnListarTodos = new System.Windows.Forms.ToolStripButton();
            this.tsBtnSalir = new System.Windows.Forms.ToolStripButton();
            this.dgvInventario = new Aplicacion.Inventario.Consulta.DataGridView_Plus();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Referencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Equivalente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Marca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Inventario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CostoMasIva = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Iva = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Utilidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbResultado.SuspendLayout();
            this.tsMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventario)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCodigoNombre
            // 
            this.txtCodigoNombre.BackColor = System.Drawing.SystemColors.Window;
            this.txtCodigoNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtCodigoNombre.Location = new System.Drawing.Point(5, 11);
            this.txtCodigoNombre.Name = "txtCodigoNombre";
            this.txtCodigoNombre.Size = new System.Drawing.Size(395, 23);
            this.txtCodigoNombre.TabIndex = 0;
            this.txtCodigoNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoNombre_KeyPress);
            // 
            // gbResultado
            // 
            this.gbResultado.Controls.Add(this.chkVerId);
            this.gbResultado.Controls.Add(this.txtCodigoNombre);
            this.gbResultado.Controls.Add(this.dgvInventario);
            this.gbResultado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.2F);
            this.gbResultado.Location = new System.Drawing.Point(6, 25);
            this.gbResultado.Name = "gbResultado";
            this.gbResultado.Size = new System.Drawing.Size(1171, 310);
            this.gbResultado.TabIndex = 1;
            this.gbResultado.TabStop = false;
            // 
            // chkVerId
            // 
            this.chkVerId.AutoSize = true;
            this.chkVerId.Location = new System.Drawing.Point(410, 13);
            this.chkVerId.Name = "chkVerId";
            this.chkVerId.Size = new System.Drawing.Size(110, 20);
            this.chkVerId.TabIndex = 1;
            this.chkVerId.Text = "Ver ID articulo";
            this.chkVerId.UseVisualStyleBackColor = true;
            this.chkVerId.CheckedChanged += new System.EventHandler(this.chkVerId_CheckedChanged);
            // 
            // tsMenu
            // 
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsEditarPrecio,
            this.tsBtnListarTodos,
            this.tsBtnSalir});
            this.tsMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(1183, 25);
            this.tsMenu.TabIndex = 2;
            this.tsMenu.Text = "toolStrip1";
            // 
            // tsEditarPrecio
            // 
            this.tsEditarPrecio.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsEditarPrecio.Image = ((System.Drawing.Image)(resources.GetObject("tsEditarPrecio.Image")));
            this.tsEditarPrecio.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsEditarPrecio.Name = "tsEditarPrecio";
            this.tsEditarPrecio.Size = new System.Drawing.Size(103, 22);
            this.tsEditarPrecio.Text = "Editar precio";
            this.tsEditarPrecio.Visible = false;
            this.tsEditarPrecio.Click += new System.EventHandler(this.tsEditarPrecio_Click);
            // 
            // tsBtnListarTodos
            // 
            this.tsBtnListarTodos.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsBtnListarTodos.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnListarTodos.Image")));
            this.tsBtnListarTodos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnListarTodos.Name = "tsBtnListarTodos";
            this.tsBtnListarTodos.Size = new System.Drawing.Size(124, 22);
            this.tsBtnListarTodos.Text = "Listar Todos [F5]";
            this.tsBtnListarTodos.Visible = false;
            this.tsBtnListarTodos.Click += new System.EventHandler(this.tsBtnListarTodos_Click);
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
            // dgvInventario
            // 
            this.dgvInventario.AllowUserToAddRows = false;
            this.dgvInventario.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvInventario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Codigo,
            this.Producto,
            this.Referencia,
            this.Equivalente,
            this.Marca,
            this.Valor,
            this.PrecioVenta,
            this.Precio_,
            this.Descto,
            this.Precio2,
            this.Inventario,
            this.CostoMasIva,
            this.Iva,
            this.Utilidad});
            this.dgvInventario.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvInventario.Location = new System.Drawing.Point(5, 40);
            this.dgvInventario.Name = "dgvInventario";
            this.dgvInventario.RowHeadersVisible = false;
            this.dgvInventario.Size = new System.Drawing.Size(1160, 264);
            this.dgvInventario.TabIndex = 0;
            this.dgvInventario.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInventario_CellClick);
            this.dgvInventario.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInventario_CellDoubleClick);
            this.dgvInventario.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvInventario_CellValidating);
            this.dgvInventario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgvInventario_KeyPress);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "CodigoInternoProducto";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            this.Id.Width = 90;
            // 
            // Codigo
            // 
            this.Codigo.DataPropertyName = "CodigoBarrasProducto";
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            this.Codigo.Width = 120;
            // 
            // Producto
            // 
            this.Producto.DataPropertyName = "NombreProducto";
            this.Producto.HeaderText = "Producto";
            this.Producto.Name = "Producto";
            this.Producto.ReadOnly = true;
            this.Producto.Width = 420;
            // 
            // Referencia
            // 
            this.Referencia.DataPropertyName = "ReferenciaProducto";
            this.Referencia.HeaderText = "Referencia";
            this.Referencia.Name = "Referencia";
            this.Referencia.ReadOnly = true;
            this.Referencia.Width = 150;
            // 
            // Equivalente
            // 
            this.Equivalente.DataPropertyName = "DescripcionProducto";
            this.Equivalente.HeaderText = "Equivalente";
            this.Equivalente.Name = "Equivalente";
            this.Equivalente.ReadOnly = true;
            this.Equivalente.Width = 130;
            // 
            // Marca
            // 
            this.Marca.DataPropertyName = "NombreMarca";
            this.Marca.HeaderText = "Marca";
            this.Marca.Name = "Marca";
            this.Marca.ReadOnly = true;
            // 
            // Valor
            // 
            this.Valor.DataPropertyName = "ValorCosto";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = null;
            this.Valor.DefaultCellStyle = dataGridViewCellStyle1;
            this.Valor.HeaderText = "Costo";
            this.Valor.Name = "Valor";
            this.Valor.ReadOnly = true;
            this.Valor.Visible = false;
            this.Valor.Width = 80;
            // 
            // PrecioVenta
            // 
            this.PrecioVenta.DataPropertyName = "valorventaproducto";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.PrecioVenta.DefaultCellStyle = dataGridViewCellStyle2;
            this.PrecioVenta.HeaderText = "Precio__";
            this.PrecioVenta.Name = "PrecioVenta";
            this.PrecioVenta.Visible = false;
            this.PrecioVenta.Width = 75;
            // 
            // Precio_
            // 
            this.Precio_.DataPropertyName = "ValorVentaProducto";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.Precio_.DefaultCellStyle = dataGridViewCellStyle3;
            this.Precio_.HeaderText = "Precio";
            this.Precio_.Name = "Precio_";
            this.Precio_.ReadOnly = true;
            // 
            // Descto
            // 
            this.Descto.DataPropertyName = "Utilidad2";
            this.Descto.HeaderText = "Descto";
            this.Descto.Name = "Descto";
            this.Descto.Visible = false;
            // 
            // Precio2
            // 
            this.Precio2.DataPropertyName = "DescuentoMayor";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = null;
            this.Precio2.DefaultCellStyle = dataGridViewCellStyle4;
            this.Precio2.HeaderText = "Precio 2";
            this.Precio2.Name = "Precio2";
            // 
            // Inventario
            // 
            this.Inventario.DataPropertyName = "Cantidad";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Inventario.DefaultCellStyle = dataGridViewCellStyle5;
            this.Inventario.HeaderText = "Inventario";
            this.Inventario.Name = "Inventario";
            this.Inventario.ReadOnly = true;
            this.Inventario.Width = 85;
            // 
            // CostoMasIva
            // 
            this.CostoMasIva.DataPropertyName = "ValorCosto";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N0";
            dataGridViewCellStyle6.NullValue = null;
            this.CostoMasIva.DefaultCellStyle = dataGridViewCellStyle6;
            this.CostoMasIva.HeaderText = "Costo IVA";
            this.CostoMasIva.Name = "CostoMasIva";
            this.CostoMasIva.Visible = false;
            this.CostoMasIva.Width = 90;
            // 
            // Iva
            // 
            this.Iva.DataPropertyName = "ValorIva";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N0";
            dataGridViewCellStyle7.NullValue = null;
            this.Iva.DefaultCellStyle = dataGridViewCellStyle7;
            this.Iva.HeaderText = "IVA";
            this.Iva.Name = "Iva";
            this.Iva.Width = 50;
            // 
            // Utilidad
            // 
            this.Utilidad.DataPropertyName = "UtilidadPorcentualProducto";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N0";
            dataGridViewCellStyle8.NullValue = null;
            this.Utilidad.DefaultCellStyle = dataGridViewCellStyle8;
            this.Utilidad.HeaderText = "Util";
            this.Utilidad.Name = "Utilidad";
            this.Utilidad.Visible = false;
            this.Utilidad.Width = 50;
            // 
            // FrmInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1183, 340);
            this.Controls.Add(this.tsMenu);
            this.Controls.Add(this.gbResultado);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmInventario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta de Inventario";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmConsultaInventario_FormClosing);
            this.Load += new System.EventHandler(this.FrmConsultaInventario_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmConsultaInventario_KeyDown);
            this.gbResultado.ResumeLayout(false);
            this.gbResultado.PerformLayout();
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventario)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbResultado;
        private System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.ToolStripButton tsBtnListarTodos;
        private System.Windows.Forms.ToolStripButton tsBtnSalir;
        public System.Windows.Forms.TextBox txtCodigoNombre;
        //public System.Windows.Forms.DataGridView dgvInventario;
        public DataGridView_Plus dgvInventario;
        private System.Windows.Forms.CheckBox chkVerId;
        private System.Windows.Forms.ToolStripButton tsEditarPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Referencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Equivalente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Marca;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio_;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Inventario;
        private System.Windows.Forms.DataGridViewTextBoxColumn CostoMasIva;
        private System.Windows.Forms.DataGridViewTextBoxColumn Iva;
        private System.Windows.Forms.DataGridViewTextBoxColumn Utilidad;
    }
}