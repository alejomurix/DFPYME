namespace Aplicacion.Inventario.Agrupacion
{
    partial class frmListarProducto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListarProducto));
            this.dgvListaArticulo = new System.Windows.Forms.DataGridView();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoBarras = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Articulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Color = new System.Windows.Forms.DataGridViewImageColumn();
            this.Medida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdValorMedida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorMedida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsAceptar = new System.Windows.Forms.ToolStripButton();
            this.tsAgregar = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaArticulo)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvListaArticulo
            // 
            this.dgvListaArticulo.AllowUserToAddRows = false;
            this.dgvListaArticulo.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvListaArticulo.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvListaArticulo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaArticulo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.CodigoBarras,
            this.Articulo,
            this.IdColor,
            this.Color,
            this.Medida,
            this.IdValorMedida,
            this.ValorMedida,
            this.Cantidad});
            this.dgvListaArticulo.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvListaArticulo.GridColor = System.Drawing.SystemColors.Window;
            this.dgvListaArticulo.Location = new System.Drawing.Point(7, 34);
            this.dgvListaArticulo.Margin = new System.Windows.Forms.Padding(4);
            this.dgvListaArticulo.Name = "dgvListaArticulo";
            this.dgvListaArticulo.Size = new System.Drawing.Size(835, 238);
            this.dgvListaArticulo.TabIndex = 0;
            this.dgvListaArticulo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListaArticulo_CellDoubleClick);
            // 
            // Codigo
            // 
            this.Codigo.DataPropertyName = "Codigo";
            this.Codigo.FillWeight = 355.33F;
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "Codigo";
            // 
            // CodigoBarras
            // 
            this.CodigoBarras.DataPropertyName = "Nombre";
            this.CodigoBarras.FillWeight = 57.44501F;
            this.CodigoBarras.HeaderText = "Codigo de barras";
            this.CodigoBarras.Name = "CodigoBarras";
            this.CodigoBarras.Width = 150;
            // 
            // Articulo
            // 
            this.Articulo.DataPropertyName = "Marca";
            this.Articulo.FillWeight = 57.44501F;
            this.Articulo.HeaderText = "Articulo";
            this.Articulo.Name = "Articulo";
            this.Articulo.Width = 200;
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
            this.Color.FillWeight = 57.44501F;
            this.Color.HeaderText = "Color";
            this.Color.Name = "Color";
            this.Color.Width = 60;
            // 
            // Medida
            // 
            this.Medida.DataPropertyName = "Unidad";
            this.Medida.FillWeight = 57.44501F;
            this.Medida.HeaderText = "Medida";
            this.Medida.Name = "Medida";
            this.Medida.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Medida.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Medida.Width = 80;
            // 
            // IdValorMedida
            // 
            this.IdValorMedida.DataPropertyName = "IdValorMedida";
            this.IdValorMedida.HeaderText = "id Valor medida";
            this.IdValorMedida.Name = "IdValorMedida";
            this.IdValorMedida.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IdValorMedida.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.IdValorMedida.Visible = false;
            // 
            // ValorMedida
            // 
            this.ValorMedida.DataPropertyName = "Medida";
            this.ValorMedida.FillWeight = 57.44501F;
            this.ValorMedida.HeaderText = "Velor Medida";
            this.ValorMedida.Name = "ValorMedida";
            this.ValorMedida.Width = 120;
            // 
            // Cantidad
            // 
            this.Cantidad.DataPropertyName = "Inventario";
            this.Cantidad.FillWeight = 57.44501F;
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.Width = 81;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsAceptar,
            this.tsAgregar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(849, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsAceptar
            // 
            this.tsAceptar.Image = ((System.Drawing.Image)(resources.GetObject("tsAceptar.Image")));
            this.tsAceptar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsAceptar.Name = "tsAceptar";
            this.tsAceptar.Size = new System.Drawing.Size(98, 22);
            this.tsAceptar.Text = "Agregar [F12]";
            this.tsAceptar.Click += new System.EventHandler(this.tsAceptar_Click);
            // 
            // tsAgregar
            // 
            this.tsAgregar.Image = ((System.Drawing.Image)(resources.GetObject("tsAgregar.Image")));
            this.tsAgregar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsAgregar.Name = "tsAgregar";
            this.tsAgregar.Size = new System.Drawing.Size(77, 22);
            this.tsAgregar.Text = "Salir [Esc]";
            this.tsAgregar.Click += new System.EventHandler(this.tsAgregar_Click);
            // 
            // frmListarProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 282);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.dgvListaArticulo);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmListarProducto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listar Producto";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmListarProducto_FormClosing);
            this.Load += new System.EventHandler(this.frmListarProducto_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmListarProducto_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaArticulo)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsAgregar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoBarras;
        private System.Windows.Forms.DataGridViewTextBoxColumn Articulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdColor;
        private System.Windows.Forms.DataGridViewImageColumn Color;
        private System.Windows.Forms.DataGridViewTextBoxColumn Medida;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdValorMedida;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorMedida;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.ToolStripButton tsAceptar;
        public System.Windows.Forms.DataGridView dgvListaArticulo;
    }
}