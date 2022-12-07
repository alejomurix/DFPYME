namespace Aplicacion.Inventario.Traslado
{
    partial class FrmConsultaTraslado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConsultaTraslado));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsMenuTraslado = new System.Windows.Forms.ToolStrip();
            this.tsBtnSalir = new System.Windows.Forms.ToolStripButton();
            this.tsBtnImprimir = new System.Windows.Forms.ToolStripButton();
            this.gbDatosTraslado = new System.Windows.Forms.GroupBox();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.cbCriterio = new System.Windows.Forms.ComboBox();
            this.gbListadoArticulos = new System.Windows.Forms.GroupBox();
            this.dgvListaArticulos = new Aplicacion.Ventas.Factura.DataGridViewPlus();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Articulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Costo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridViewPlus1 = new Aplicacion.Ventas.Factura.DataGridViewPlus();
            this.IdTraslado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsMenuTraslado.SuspendLayout();
            this.gbDatosTraslado.SuspendLayout();
            this.gbListadoArticulos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaArticulos)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPlus1)).BeginInit();
            this.SuspendLayout();
            // 
            // tsMenuTraslado
            // 
            this.tsMenuTraslado.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsMenuTraslado.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnImprimir,
            this.tsBtnSalir});
            this.tsMenuTraslado.Location = new System.Drawing.Point(0, 0);
            this.tsMenuTraslado.Name = "tsMenuTraslado";
            this.tsMenuTraslado.Size = new System.Drawing.Size(1014, 25);
            this.tsMenuTraslado.TabIndex = 4;
            this.tsMenuTraslado.Text = "Menu Principal";
            // 
            // tsBtnSalir
            // 
            this.tsBtnSalir.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnSalir.Image")));
            this.tsBtnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnSalir.Name = "tsBtnSalir";
            this.tsBtnSalir.Size = new System.Drawing.Size(87, 22);
            this.tsBtnSalir.Text = "Salir [ESC]";
            // 
            // tsBtnImprimir
            // 
            this.tsBtnImprimir.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnImprimir.Image")));
            this.tsBtnImprimir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnImprimir.Name = "tsBtnImprimir";
            this.tsBtnImprimir.Size = new System.Drawing.Size(129, 22);
            this.tsBtnImprimir.Text = "Imprimir traslado";
            // 
            // gbDatosTraslado
            // 
            this.gbDatosTraslado.Controls.Add(this.cbCriterio);
            this.gbDatosTraslado.Controls.Add(this.dateTimePicker1);
            this.gbDatosTraslado.Controls.Add(this.btnBuscar);
            this.gbDatosTraslado.Controls.Add(this.dtpFecha);
            this.gbDatosTraslado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.gbDatosTraslado.Location = new System.Drawing.Point(7, 29);
            this.gbDatosTraslado.Name = "gbDatosTraslado";
            this.gbDatosTraslado.Size = new System.Drawing.Size(464, 54);
            this.gbDatosTraslado.TabIndex = 5;
            this.gbDatosTraslado.TabStop = false;
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(176, 19);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(112, 22);
            this.dtpFecha.TabIndex = 22;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(424, 18);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(25, 23);
            this.btnBuscar.TabIndex = 24;
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(300, 19);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(112, 22);
            this.dateTimePicker1.TabIndex = 25;
            // 
            // cbCriterio
            // 
            this.cbCriterio.DisplayMember = "Nombre";
            this.cbCriterio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCriterio.FormattingEnabled = true;
            this.cbCriterio.Location = new System.Drawing.Point(13, 18);
            this.cbCriterio.Name = "cbCriterio";
            this.cbCriterio.Size = new System.Drawing.Size(152, 24);
            this.cbCriterio.TabIndex = 26;
            this.cbCriterio.ValueMember = "Id";
            // 
            // gbListadoArticulos
            // 
            this.gbListadoArticulos.Controls.Add(this.dgvListaArticulos);
            this.gbListadoArticulos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.gbListadoArticulos.Location = new System.Drawing.Point(7, 392);
            this.gbListadoArticulos.Name = "gbListadoArticulos";
            this.gbListadoArticulos.Size = new System.Drawing.Size(900, 195);
            this.gbListadoArticulos.TabIndex = 6;
            this.gbListadoArticulos.TabStop = false;
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
            this.dgvListaArticulos.Size = new System.Drawing.Size(885, 171);
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
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.Cantidad.DefaultCellStyle = dataGridViewCellStyle5;
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            // 
            // Costo
            // 
            this.Costo.DataPropertyName = "Costo";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N0";
            dataGridViewCellStyle6.NullValue = null;
            this.Costo.DefaultCellStyle = dataGridViewCellStyle6;
            this.Costo.HeaderText = "Costo";
            this.Costo.Name = "Costo";
            this.Costo.ReadOnly = true;
            this.Costo.Width = 110;
            // 
            // Precio
            // 
            this.Precio.DataPropertyName = "Valor";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N0";
            dataGridViewCellStyle7.NullValue = null;
            this.Precio.DefaultCellStyle = dataGridViewCellStyle7;
            this.Precio.HeaderText = "Precio";
            this.Precio.Name = "Precio";
            this.Precio.ReadOnly = true;
            this.Precio.Width = 110;
            // 
            // SubTotal
            // 
            this.SubTotal.DataPropertyName = "Total";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N0";
            dataGridViewCellStyle8.NullValue = null;
            this.SubTotal.DefaultCellStyle = dataGridViewCellStyle8;
            this.SubTotal.HeaderText = "Sub total";
            this.SubTotal.Name = "SubTotal";
            this.SubTotal.ReadOnly = true;
            this.SubTotal.Width = 110;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridViewPlus1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.groupBox1.Location = new System.Drawing.Point(7, 89);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(900, 262);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // dataGridViewPlus1
            // 
            this.dataGridViewPlus1.AllowUserToAddRows = false;
            this.dataGridViewPlus1.AllowUserToResizeColumns = false;
            this.dataGridViewPlus1.AllowUserToResizeRows = false;
            this.dataGridViewPlus1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridViewPlus1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPlus1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdTraslado,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.dataGridViewPlus1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewPlus1.Location = new System.Drawing.Point(7, 14);
            this.dataGridViewPlus1.Name = "dataGridViewPlus1";
            this.dataGridViewPlus1.RowHeadersVisible = false;
            this.dataGridViewPlus1.Size = new System.Drawing.Size(885, 239);
            this.dataGridViewPlus1.TabIndex = 0;
            // 
            // IdTraslado
            // 
            this.IdTraslado.DataPropertyName = "Id";
            this.IdTraslado.HeaderText = "Id";
            this.IdTraslado.Name = "IdTraslado";
            this.IdTraslado.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Codigo";
            this.dataGridViewTextBoxColumn2.HeaderText = "Codigo";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Nombre";
            this.dataGridViewTextBoxColumn3.HeaderText = "Producto";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 330;
            // 
            // FrmConsultaTraslado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1014, 617);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbListadoArticulos);
            this.Controls.Add(this.gbDatosTraslado);
            this.Controls.Add(this.tsMenuTraslado);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmConsultaTraslado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta de traslados";
            this.Load += new System.EventHandler(this.FrmConsultaTraslado_Load);
            this.tsMenuTraslado.ResumeLayout(false);
            this.tsMenuTraslado.PerformLayout();
            this.gbDatosTraslado.ResumeLayout(false);
            this.gbListadoArticulos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaArticulos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPlus1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMenuTraslado;
        private System.Windows.Forms.ToolStripButton tsBtnSalir;
        private System.Windows.Forms.ToolStripButton tsBtnImprimir;
        private System.Windows.Forms.GroupBox gbDatosTraslado;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ComboBox cbCriterio;
        private System.Windows.Forms.GroupBox gbListadoArticulos;
        private Ventas.Factura.DataGridViewPlus dgvListaArticulos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Articulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Costo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubTotal;
        private System.Windows.Forms.GroupBox groupBox1;
        private Ventas.Factura.DataGridViewPlus dataGridViewPlus1;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdTraslado;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
    }
}