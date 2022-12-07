namespace Aplicacion.Inventario.Cruce
{
    partial class FrmResumenInventario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmResumenInventario));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbListadoProducto = new System.Windows.Forms.GroupBox();
            this.statusInventario = new System.Windows.Forms.StatusStrip();
            this.btnInicioRowInventario = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnAnterior = new System.Windows.Forms.ToolStripDropDownButton();
            this.lblStatusInventario = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnSiguiente = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnFinRowInventario = new System.Windows.Forms.ToolStripDropDownButton();
            this.dgvInventario = new System.Windows.Forms.DataGridView();
            this.tsMenuCorteGeneral = new System.Windows.Forms.ToolStrip();
            this.tsBtnListarTodos = new System.Windows.Forms.ToolStripButton();
            this.tsBtnSalir = new System.Windows.Forms.ToolStripButton();
            this.gbOrdenar = new System.Windows.Forms.GroupBox();
            this.btnListaTodos = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.cbOrden = new System.Windows.Forms.ComboBox();
            this.lblOrden = new System.Windows.Forms.Label();
            this.gbConsulta = new System.Windows.Forms.GroupBox();
            this.btnFecha = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.cbCriterio = new System.Windows.Forms.ComboBox();
            this.Categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Marca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Medida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Color = new System.Windows.Forms.DataGridViewImageColumn();
            this.Inventario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fisico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Diferencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Costo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Subtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbListadoProducto.SuspendLayout();
            this.statusInventario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventario)).BeginInit();
            this.tsMenuCorteGeneral.SuspendLayout();
            this.gbOrdenar.SuspendLayout();
            this.gbConsulta.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbListadoProducto
            // 
            this.gbListadoProducto.Controls.Add(this.statusInventario);
            this.gbListadoProducto.Controls.Add(this.dgvInventario);
            this.gbListadoProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.gbListadoProducto.Location = new System.Drawing.Point(5, 108);
            this.gbListadoProducto.Name = "gbListadoProducto";
            this.gbListadoProducto.Size = new System.Drawing.Size(1159, 418);
            this.gbListadoProducto.TabIndex = 0;
            this.gbListadoProducto.TabStop = false;
            this.gbListadoProducto.Text = "Resultado de la Consulta";
            // 
            // statusInventario
            // 
            this.statusInventario.BackColor = System.Drawing.Color.LightSteelBlue;
            this.statusInventario.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnInicioRowInventario,
            this.btnAnterior,
            this.lblStatusInventario,
            this.btnSiguiente,
            this.btnFinRowInventario});
            this.statusInventario.Location = new System.Drawing.Point(3, 393);
            this.statusInventario.Name = "statusInventario";
            this.statusInventario.Size = new System.Drawing.Size(1153, 22);
            this.statusInventario.TabIndex = 1;
            this.statusInventario.Text = "Estado Inventario";
            // 
            // btnInicioRowInventario
            // 
            this.btnInicioRowInventario.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnInicioRowInventario.Image = ((System.Drawing.Image)(resources.GetObject("btnInicioRowInventario.Image")));
            this.btnInicioRowInventario.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnInicioRowInventario.Name = "btnInicioRowInventario";
            this.btnInicioRowInventario.ShowDropDownArrow = false;
            this.btnInicioRowInventario.Size = new System.Drawing.Size(20, 20);
            this.btnInicioRowInventario.Click += new System.EventHandler(this.btnInicioRowInventario_Click);
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
            // lblStatusInventario
            // 
            this.lblStatusInventario.Name = "lblStatusInventario";
            this.lblStatusInventario.Size = new System.Drawing.Size(30, 17);
            this.lblStatusInventario.Text = "0 / 0";
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
            // btnFinRowInventario
            // 
            this.btnFinRowInventario.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFinRowInventario.Image = ((System.Drawing.Image)(resources.GetObject("btnFinRowInventario.Image")));
            this.btnFinRowInventario.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFinRowInventario.Name = "btnFinRowInventario";
            this.btnFinRowInventario.ShowDropDownArrow = false;
            this.btnFinRowInventario.Size = new System.Drawing.Size(20, 20);
            this.btnFinRowInventario.Click += new System.EventHandler(this.btnFinRowInventario_Click);
            // 
            // dgvInventario
            // 
            this.dgvInventario.AllowUserToAddRows = false;
            this.dgvInventario.AllowUserToResizeColumns = false;
            this.dgvInventario.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvInventario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Categoria,
            this.Codigo,
            this.Nombre,
            this.Marca,
            this.Fecha,
            this.Unidad,
            this.Medida,
            this.Color,
            this.Inventario,
            this.Fisico,
            this.Diferencia,
            this.Estado,
            this.Costo,
            this.Subtotal});
            this.dgvInventario.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvInventario.Location = new System.Drawing.Point(6, 21);
            this.dgvInventario.Name = "dgvInventario";
            this.dgvInventario.RowHeadersVisible = false;
            this.dgvInventario.Size = new System.Drawing.Size(1148, 371);
            this.dgvInventario.TabIndex = 0;
            // 
            // tsMenuCorteGeneral
            // 
            this.tsMenuCorteGeneral.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnListarTodos,
            this.tsBtnSalir});
            this.tsMenuCorteGeneral.Location = new System.Drawing.Point(0, 0);
            this.tsMenuCorteGeneral.Name = "tsMenuCorteGeneral";
            this.tsMenuCorteGeneral.Size = new System.Drawing.Size(1172, 25);
            this.tsMenuCorteGeneral.TabIndex = 1;
            this.tsMenuCorteGeneral.Text = "Menu";
            // 
            // tsBtnListarTodos
            // 
            this.tsBtnListarTodos.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsBtnListarTodos.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnListarTodos.Image")));
            this.tsBtnListarTodos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnListarTodos.Name = "tsBtnListarTodos";
            this.tsBtnListarTodos.Size = new System.Drawing.Size(99, 22);
            this.tsBtnListarTodos.Text = "Listar Todos";
            this.tsBtnListarTodos.Visible = false;
            this.tsBtnListarTodos.Click += new System.EventHandler(this.tsBtnListarTodos_Click);
            // 
            // tsBtnSalir
            // 
            this.tsBtnSalir.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsBtnSalir.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnSalir.Image")));
            this.tsBtnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnSalir.Name = "tsBtnSalir";
            this.tsBtnSalir.Size = new System.Drawing.Size(84, 22);
            this.tsBtnSalir.Text = "Salir [Esc]";
            this.tsBtnSalir.Click += new System.EventHandler(this.tsBtnSalir_Click);
            // 
            // gbOrdenar
            // 
            this.gbOrdenar.Controls.Add(this.btnListaTodos);
            this.gbOrdenar.Controls.Add(this.btnPrint);
            this.gbOrdenar.Controls.Add(this.cbOrden);
            this.gbOrdenar.Controls.Add(this.lblOrden);
            this.gbOrdenar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.gbOrdenar.Location = new System.Drawing.Point(597, 30);
            this.gbOrdenar.Name = "gbOrdenar";
            this.gbOrdenar.Size = new System.Drawing.Size(330, 73);
            this.gbOrdenar.TabIndex = 2;
            this.gbOrdenar.TabStop = false;
            this.gbOrdenar.Text = "Informe";
            // 
            // btnListaTodos
            // 
            this.btnListaTodos.Image = ((System.Drawing.Image)(resources.GetObject("btnListaTodos.Image")));
            this.btnListaTodos.Location = new System.Drawing.Point(257, 31);
            this.btnListaTodos.Name = "btnListaTodos";
            this.btnListaTodos.Size = new System.Drawing.Size(25, 23);
            this.btnListaTodos.TabIndex = 5;
            this.btnListaTodos.UseVisualStyleBackColor = true;
            this.btnListaTodos.Click += new System.EventHandler(this.btnListaTodos_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.Location = new System.Drawing.Point(288, 31);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(25, 23);
            this.btnPrint.TabIndex = 4;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // cbOrden
            // 
            this.cbOrden.DisplayMember = "Nombre";
            this.cbOrden.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOrden.FormattingEnabled = true;
            this.cbOrden.Location = new System.Drawing.Point(105, 30);
            this.cbOrden.Name = "cbOrden";
            this.cbOrden.Size = new System.Drawing.Size(144, 24);
            this.cbOrden.TabIndex = 1;
            this.cbOrden.ValueMember = "Id";
            this.cbOrden.SelectionChangeCommitted += new System.EventHandler(this.cbOrden_SelectionChangeCommitted);
            // 
            // lblOrden
            // 
            this.lblOrden.AutoSize = true;
            this.lblOrden.Location = new System.Drawing.Point(18, 33);
            this.lblOrden.Name = "lblOrden";
            this.lblOrden.Size = new System.Drawing.Size(81, 16);
            this.lblOrden.TabIndex = 0;
            this.lblOrden.Text = "Ordenar Por";
            // 
            // gbConsulta
            // 
            this.gbConsulta.Controls.Add(this.btnFecha);
            this.gbConsulta.Controls.Add(this.btnBuscar);
            this.gbConsulta.Controls.Add(this.txtCodigo);
            this.gbConsulta.Controls.Add(this.cbCriterio);
            this.gbConsulta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.gbConsulta.Location = new System.Drawing.Point(11, 30);
            this.gbConsulta.Name = "gbConsulta";
            this.gbConsulta.Size = new System.Drawing.Size(570, 73);
            this.gbConsulta.TabIndex = 3;
            this.gbConsulta.TabStop = false;
            this.gbConsulta.Text = "Consultas";
            // 
            // btnFecha
            // 
            this.btnFecha.Enabled = false;
            this.btnFecha.Location = new System.Drawing.Point(499, 30);
            this.btnFecha.Name = "btnFecha";
            this.btnFecha.Size = new System.Drawing.Size(25, 23);
            this.btnFecha.TabIndex = 3;
            this.btnFecha.Text = "...";
            this.btnFecha.UseVisualStyleBackColor = true;
            this.btnFecha.Click += new System.EventHandler(this.btnFecha_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(530, 30);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(25, 23);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(173, 30);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(320, 22);
            this.txtCodigo.TabIndex = 1;
            this.txtCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigo_KeyPress);
            // 
            // cbCriterio
            // 
            this.cbCriterio.DisplayMember = "Nombre";
            this.cbCriterio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCriterio.FormattingEnabled = true;
            this.cbCriterio.Location = new System.Drawing.Point(14, 28);
            this.cbCriterio.Name = "cbCriterio";
            this.cbCriterio.Size = new System.Drawing.Size(152, 24);
            this.cbCriterio.TabIndex = 0;
            this.cbCriterio.ValueMember = "Id";
            this.cbCriterio.SelectionChangeCommitted += new System.EventHandler(this.cbCriterio_SelectionChangeCommitted);
            // 
            // Categoria
            // 
            this.Categoria.DataPropertyName = "Categoria";
            this.Categoria.HeaderText = "Categoria";
            this.Categoria.Name = "Categoria";
            this.Categoria.Width = 140;
            // 
            // Codigo
            // 
            this.Codigo.DataPropertyName = "Codigo";
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "Codigo";
            this.Codigo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Codigo.Width = 80;
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "Nombre";
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Nombre.Width = 300;
            // 
            // Marca
            // 
            this.Marca.DataPropertyName = "Marca";
            this.Marca.HeaderText = "Marca";
            this.Marca.Name = "Marca";
            this.Marca.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Marca.Visible = false;
            // 
            // Fecha
            // 
            this.Fecha.DataPropertyName = "Fecha";
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Unidad
            // 
            this.Unidad.DataPropertyName = "Unidad";
            this.Unidad.HeaderText = "Unidad";
            this.Unidad.Name = "Unidad";
            this.Unidad.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Unidad.Visible = false;
            this.Unidad.Width = 80;
            // 
            // Medida
            // 
            this.Medida.DataPropertyName = "Medida";
            this.Medida.HeaderText = "Medida";
            this.Medida.Name = "Medida";
            this.Medida.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Medida.Width = 80;
            // 
            // Color
            // 
            this.Color.DataPropertyName = "Color";
            this.Color.HeaderText = "Color";
            this.Color.Name = "Color";
            this.Color.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Color.Visible = false;
            // 
            // Inventario
            // 
            this.Inventario.DataPropertyName = "Inventario";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Format = "N3";
            dataGridViewCellStyle1.NullValue = null;
            this.Inventario.DefaultCellStyle = dataGridViewCellStyle1;
            this.Inventario.HeaderText = "Inventario";
            this.Inventario.Name = "Inventario";
            this.Inventario.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Inventario.Width = 80;
            // 
            // Fisico
            // 
            this.Fisico.DataPropertyName = "Fisico";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "N3";
            dataGridViewCellStyle2.NullValue = null;
            this.Fisico.DefaultCellStyle = dataGridViewCellStyle2;
            this.Fisico.HeaderText = "Fisico";
            this.Fisico.Name = "Fisico";
            this.Fisico.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Fisico.Width = 80;
            // 
            // Diferencia
            // 
            this.Diferencia.DataPropertyName = "Diferencia";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "N3";
            dataGridViewCellStyle3.NullValue = null;
            this.Diferencia.DefaultCellStyle = dataGridViewCellStyle3;
            this.Diferencia.HeaderText = "Diferencia";
            this.Diferencia.Name = "Diferencia";
            this.Diferencia.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Diferencia.Width = 80;
            // 
            // Estado
            // 
            this.Estado.DataPropertyName = "Estado";
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Estado.Visible = false;
            // 
            // Costo
            // 
            this.Costo.DataPropertyName = "Costo";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N1";
            dataGridViewCellStyle4.NullValue = null;
            this.Costo.DefaultCellStyle = dataGridViewCellStyle4;
            this.Costo.HeaderText = "Costo";
            this.Costo.Name = "Costo";
            // 
            // Subtotal
            // 
            this.Subtotal.DataPropertyName = "Subtotal";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N1";
            dataGridViewCellStyle5.NullValue = null;
            this.Subtotal.DefaultCellStyle = dataGridViewCellStyle5;
            this.Subtotal.HeaderText = "Subtotal";
            this.Subtotal.Name = "Subtotal";
            // 
            // FrmResumenInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1172, 531);
            this.Controls.Add(this.gbConsulta);
            this.Controls.Add(this.gbOrdenar);
            this.Controls.Add(this.tsMenuCorteGeneral);
            this.Controls.Add(this.gbListadoProducto);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmResumenInventario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Resumen de Inventario";
            this.Load += new System.EventHandler(this.frmCorteGeneral_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCorteGeneral_KeyDown);
            this.gbListadoProducto.ResumeLayout(false);
            this.gbListadoProducto.PerformLayout();
            this.statusInventario.ResumeLayout(false);
            this.statusInventario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventario)).EndInit();
            this.tsMenuCorteGeneral.ResumeLayout(false);
            this.tsMenuCorteGeneral.PerformLayout();
            this.gbOrdenar.ResumeLayout(false);
            this.gbOrdenar.PerformLayout();
            this.gbConsulta.ResumeLayout(false);
            this.gbConsulta.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbListadoProducto;
        private System.Windows.Forms.DataGridView dgvInventario;
        private System.Windows.Forms.StatusStrip statusInventario;
        private System.Windows.Forms.ToolStripDropDownButton btnAnterior;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusInventario;
        private System.Windows.Forms.ToolStripDropDownButton btnSiguiente;
        private System.Windows.Forms.ToolStrip tsMenuCorteGeneral;
        private System.Windows.Forms.ToolStripButton tsBtnSalir;
        private System.Windows.Forms.ComboBox cbOrden;
        private System.Windows.Forms.Label lblOrden;
        private System.Windows.Forms.ToolStripDropDownButton btnInicioRowInventario;
        private System.Windows.Forms.ToolStripDropDownButton btnFinRowInventario;
        public System.Windows.Forms.GroupBox gbOrdenar;
        public System.Windows.Forms.GroupBox gbConsulta;
        private System.Windows.Forms.ComboBox cbCriterio;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ToolStripButton tsBtnListarTodos;
        private System.Windows.Forms.Button btnFecha;
        private System.Windows.Forms.Button btnListaTodos;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.DataGridViewTextBoxColumn Categoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Marca;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Medida;
        private System.Windows.Forms.DataGridViewImageColumn Color;
        private System.Windows.Forms.DataGridViewTextBoxColumn Inventario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fisico;
        private System.Windows.Forms.DataGridViewTextBoxColumn Diferencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Costo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Subtotal;
    }
}