namespace Aplicacion.Ventas.Consultas
{
    partial class FrmConsultaVentaProductosUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConsultaVentaProductosUsuario));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.tsBtnImprimir = new System.Windows.Forms.ToolStripButton();
            this.tsBtnSalir = new System.Windows.Forms.ToolStripButton();
            this.gbCriterio = new System.Windows.Forms.GroupBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbDias2 = new System.Windows.Forms.ComboBox();
            this.cbMeses2 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbDias = new System.Windows.Forms.ComboBox();
            this.cbMeses = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cbUsuario = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbMarcas = new System.Windows.Forms.ComboBox();
            this.cbCategoria = new System.Windows.Forms.ComboBox();
            this.cbCritFecha = new System.Windows.Forms.ComboBox();
            this.cbAnios = new System.Windows.Forms.ComboBox();
            this.gbFactura = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtTotalCantidad = new System.Windows.Forms.TextBox();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.Nit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsMenu.SuspendLayout();
            this.gbCriterio.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbFactura.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // tsMenu
            // 
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnImprimir,
            this.tsBtnSalir});
            this.tsMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(1191, 25);
            this.tsMenu.TabIndex = 1;
            this.tsMenu.Text = "toolStrip1";
            // 
            // tsBtnImprimir
            // 
            this.tsBtnImprimir.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsBtnImprimir.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnImprimir.Image")));
            this.tsBtnImprimir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnImprimir.Name = "tsBtnImprimir";
            this.tsBtnImprimir.Size = new System.Drawing.Size(77, 22);
            this.tsBtnImprimir.Text = "Imprimir";
            this.tsBtnImprimir.Click += new System.EventHandler(this.tsBtnImprimir_Click);
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
            // gbCriterio
            // 
            this.gbCriterio.Controls.Add(this.btnBuscar);
            this.gbCriterio.Controls.Add(this.groupBox2);
            this.gbCriterio.Controls.Add(this.groupBox1);
            this.gbCriterio.Controls.Add(this.label11);
            this.gbCriterio.Controls.Add(this.label9);
            this.gbCriterio.Controls.Add(this.cbUsuario);
            this.gbCriterio.Controls.Add(this.label8);
            this.gbCriterio.Controls.Add(this.label2);
            this.gbCriterio.Controls.Add(this.cbMarcas);
            this.gbCriterio.Controls.Add(this.cbCategoria);
            this.gbCriterio.Controls.Add(this.cbCritFecha);
            this.gbCriterio.Controls.Add(this.cbAnios);
            this.gbCriterio.Location = new System.Drawing.Point(6, 35);
            this.gbCriterio.Name = "gbCriterio";
            this.gbCriterio.Size = new System.Drawing.Size(1179, 83);
            this.gbCriterio.TabIndex = 2;
            this.gbCriterio.TabStop = false;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(1144, 42);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(25, 23);
            this.btnBuscar.TabIndex = 24;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbDias2);
            this.groupBox2.Controls.Add(this.cbMeses2);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(292, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(132, 64);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            // 
            // cbDias2
            // 
            this.cbDias2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDias2.FormattingEnabled = true;
            this.cbDias2.Location = new System.Drawing.Point(85, 33);
            this.cbDias2.Name = "cbDias2";
            this.cbDias2.Size = new System.Drawing.Size(40, 24);
            this.cbDias2.TabIndex = 22;
            // 
            // cbMeses2
            // 
            this.cbMeses2.DisplayMember = "Nombre";
            this.cbMeses2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMeses2.FormattingEnabled = true;
            this.cbMeses2.Location = new System.Drawing.Point(30, 33);
            this.cbMeses2.Name = "cbMeses2";
            this.cbMeses2.Size = new System.Drawing.Size(53, 24);
            this.cbMeses2.TabIndex = 22;
            this.cbMeses2.ValueMember = "Id";
            this.cbMeses2.SelectedIndexChanged += new System.EventHandler(this.cbMeses2_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 16);
            this.label5.TabIndex = 3;
            this.label5.Text = "Mes";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(88, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 16);
            this.label6.TabIndex = 3;
            this.label6.Text = "Día";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 38);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 16);
            this.label7.TabIndex = 3;
            this.label7.Text = "Fin";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbDias);
            this.groupBox1.Controls.Add(this.cbMeses);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(163, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(127, 64);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            // 
            // cbDias
            // 
            this.cbDias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDias.FormattingEnabled = true;
            this.cbDias.Location = new System.Drawing.Point(82, 33);
            this.cbDias.Name = "cbDias";
            this.cbDias.Size = new System.Drawing.Size(40, 24);
            this.cbDias.TabIndex = 22;
            // 
            // cbMeses
            // 
            this.cbMeses.DisplayMember = "Nombre";
            this.cbMeses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMeses.FormattingEnabled = true;
            this.cbMeses.Location = new System.Drawing.Point(28, 33);
            this.cbMeses.Name = "cbMeses";
            this.cbMeses.Size = new System.Drawing.Size(53, 24);
            this.cbMeses.TabIndex = 22;
            this.cbMeses.ValueMember = "Id";
            this.cbMeses.SelectedIndexChanged += new System.EventHandler(this.cbMeses_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Mes";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(85, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Día";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Ini";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(875, 18);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 16);
            this.label11.TabIndex = 3;
            this.label11.Text = "Usuario";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(654, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 16);
            this.label9.TabIndex = 3;
            this.label9.Text = "Marca";
            // 
            // cbUsuario
            // 
            this.cbUsuario.DisplayMember = "nombre";
            this.cbUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUsuario.FormattingEnabled = true;
            this.cbUsuario.Location = new System.Drawing.Point(876, 41);
            this.cbUsuario.Name = "cbUsuario";
            this.cbUsuario.Size = new System.Drawing.Size(264, 24);
            this.cbUsuario.TabIndex = 22;
            this.cbUsuario.ValueMember = "id";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(433, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 16);
            this.label8.TabIndex = 3;
            this.label8.Text = "Categoria";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(101, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Año";
            // 
            // cbMarcas
            // 
            this.cbMarcas.DisplayMember = "NombreMarca";
            this.cbMarcas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMarcas.FormattingEnabled = true;
            this.cbMarcas.Location = new System.Drawing.Point(653, 41);
            this.cbMarcas.Name = "cbMarcas";
            this.cbMarcas.Size = new System.Drawing.Size(213, 24);
            this.cbMarcas.TabIndex = 22;
            this.cbMarcas.ValueMember = "IdMarca";
            // 
            // cbCategoria
            // 
            this.cbCategoria.DisplayMember = "nombrecategoria";
            this.cbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCategoria.FormattingEnabled = true;
            this.cbCategoria.Location = new System.Drawing.Point(430, 41);
            this.cbCategoria.Name = "cbCategoria";
            this.cbCategoria.Size = new System.Drawing.Size(213, 24);
            this.cbCategoria.TabIndex = 22;
            this.cbCategoria.ValueMember = "codigocategoria";
            // 
            // cbCritFecha
            // 
            this.cbCritFecha.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCritFecha.FormattingEnabled = true;
            this.cbCritFecha.Location = new System.Drawing.Point(7, 41);
            this.cbCritFecha.Name = "cbCritFecha";
            this.cbCritFecha.Size = new System.Drawing.Size(91, 24);
            this.cbCritFecha.TabIndex = 22;
            // 
            // cbAnios
            // 
            this.cbAnios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAnios.FormattingEnabled = true;
            this.cbAnios.Location = new System.Drawing.Point(100, 41);
            this.cbAnios.Name = "cbAnios";
            this.cbAnios.Size = new System.Drawing.Size(60, 24);
            this.cbAnios.TabIndex = 22;
            // 
            // gbFactura
            // 
            this.gbFactura.Controls.Add(this.label12);
            this.gbFactura.Controls.Add(this.label10);
            this.gbFactura.Controls.Add(this.txtTotalCantidad);
            this.gbFactura.Controls.Add(this.txtTotal);
            this.gbFactura.Controls.Add(this.dgvProductos);
            this.gbFactura.Location = new System.Drawing.Point(6, 124);
            this.gbFactura.Name = "gbFactura";
            this.gbFactura.Size = new System.Drawing.Size(1179, 436);
            this.gbFactura.TabIndex = 6;
            this.gbFactura.TabStop = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F);
            this.label12.Location = new System.Drawing.Point(689, 405);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(122, 20);
            this.label12.TabIndex = 8;
            this.label12.Text = "TOTAL CANT.:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F);
            this.label10.Location = new System.Drawing.Point(920, 405);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(130, 20);
            this.label10.TabIndex = 8;
            this.label10.Text = "TOTAL VALOR:";
            // 
            // txtTotalCantidad
            // 
            this.txtTotalCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F);
            this.txtTotalCantidad.Location = new System.Drawing.Point(814, 402);
            this.txtTotalCantidad.Name = "txtTotalCantidad";
            this.txtTotalCantidad.ReadOnly = true;
            this.txtTotalCantidad.Size = new System.Drawing.Size(88, 26);
            this.txtTotalCantidad.TabIndex = 7;
            this.txtTotalCantidad.Text = "0";
            this.txtTotalCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotal
            // 
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F);
            this.txtTotal.Location = new System.Drawing.Point(1054, 402);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(118, 26);
            this.txtTotal.TabIndex = 7;
            this.txtTotal.Text = "0";
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dgvProductos
            // 
            this.dgvProductos.AllowUserToAddRows = false;
            this.dgvProductos.AllowUserToDeleteRows = false;
            this.dgvProductos.AllowUserToResizeColumns = false;
            this.dgvProductos.AllowUserToResizeRows = false;
            this.dgvProductos.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nit,
            this.Cliente,
            this.Codigo,
            this.Producto,
            this.Cantidad,
            this.Valor,
            this.Total});
            this.dgvProductos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvProductos.Location = new System.Drawing.Point(8, 18);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.RowHeadersVisible = false;
            this.dgvProductos.Size = new System.Drawing.Size(1164, 378);
            this.dgvProductos.TabIndex = 0;
            // 
            // Nit
            // 
            this.Nit.DataPropertyName = "nit";
            this.Nit.HeaderText = "Nit o Ced.";
            this.Nit.Name = "Nit";
            // 
            // Cliente
            // 
            this.Cliente.DataPropertyName = "cliente";
            this.Cliente.HeaderText = "Cliente";
            this.Cliente.Name = "Cliente";
            this.Cliente.Width = 235;
            // 
            // Codigo
            // 
            this.Codigo.DataPropertyName = "codigo";
            this.Codigo.HeaderText = "Código";
            this.Codigo.Name = "Codigo";
            this.Codigo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Codigo.Width = 110;
            // 
            // Producto
            // 
            this.Producto.DataPropertyName = "producto";
            this.Producto.HeaderText = "Producto";
            this.Producto.Name = "Producto";
            this.Producto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Producto.Width = 360;
            // 
            // Cantidad
            // 
            this.Cantidad.DataPropertyName = "cantidad";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            this.Cantidad.DefaultCellStyle = dataGridViewCellStyle1;
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            // 
            // Valor
            // 
            this.Valor.DataPropertyName = "promedio";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.Valor.DefaultCellStyle = dataGridViewCellStyle2;
            this.Valor.HeaderText = "Valor pr.";
            this.Valor.Name = "Valor";
            this.Valor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Valor.Width = 120;
            // 
            // Total
            // 
            this.Total.DataPropertyName = "total";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.Total.DefaultCellStyle = dataGridViewCellStyle3;
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            this.Total.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Total.Width = 120;
            // 
            // FrmConsultaVentaProductosUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1191, 565);
            this.Controls.Add(this.gbFactura);
            this.Controls.Add(this.gbCriterio);
            this.Controls.Add(this.tsMenu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmConsultaVentaProductosUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta de venta de productos por usuario";
            this.Load += new System.EventHandler(this.FrmConsultaVentaProductos_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmConsultaVentaProductos_KeyDown);
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.gbCriterio.ResumeLayout(false);
            this.gbCriterio.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbFactura.ResumeLayout(false);
            this.gbFactura.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.ToolStripButton tsBtnImprimir;
        private System.Windows.Forms.ToolStripButton tsBtnSalir;
        private System.Windows.Forms.GroupBox gbCriterio;
        private System.Windows.Forms.ComboBox cbAnios;
        private System.Windows.Forms.ComboBox cbDias;
        private System.Windows.Forms.ComboBox cbMeses;
        private System.Windows.Forms.ComboBox cbCategoria;
        private System.Windows.Forms.ComboBox cbMarcas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbDias2;
        private System.Windows.Forms.ComboBox cbMeses2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox gbFactura;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ComboBox cbCritFecha;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtTotalCantidad;
    }
}