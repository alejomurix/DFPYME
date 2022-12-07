namespace Aplicacion.Compras.IngresarCompra
{
    partial class FrmConsultaPreIngreso
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConsultaPreIngreso));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.tsFacturar = new System.Windows.Forms.ToolStripButton();
            this.tsSalir = new System.Windows.Forms.ToolStripButton();
            this.gbListadoArticulos = new System.Windows.Forms.GroupBox();
            this.dgvPreIngresos = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Proveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsEliminar = new System.Windows.Forms.ToolStripButton();
            this.tsMenu.SuspendLayout();
            this.gbListadoArticulos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreIngresos)).BeginInit();
            this.SuspendLayout();
            // 
            // tsMenu
            // 
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsFacturar,
            this.tsEliminar,
            this.tsSalir});
            this.tsMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(807, 25);
            this.tsMenu.TabIndex = 3;
            this.tsMenu.Text = "Menu";
            // 
            // tsFacturar
            // 
            this.tsFacturar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsFacturar.Image = ((System.Drawing.Image)(resources.GetObject("tsFacturar.Image")));
            this.tsFacturar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsFacturar.Name = "tsFacturar";
            this.tsFacturar.Size = new System.Drawing.Size(100, 22);
            this.tsFacturar.Text = "Facturar [F2]";
            this.tsFacturar.Click += new System.EventHandler(this.tsFacturar_Click);
            // 
            // tsSalir
            // 
            this.tsSalir.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsSalir.Image = ((System.Drawing.Image)(resources.GetObject("tsSalir.Image")));
            this.tsSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsSalir.Name = "tsSalir";
            this.tsSalir.Size = new System.Drawing.Size(87, 22);
            this.tsSalir.Text = "Salir [ESC]";
            this.tsSalir.Click += new System.EventHandler(this.tsSalir_Click);
            // 
            // gbListadoArticulos
            // 
            this.gbListadoArticulos.Controls.Add(this.dgvPreIngresos);
            this.gbListadoArticulos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.gbListadoArticulos.Location = new System.Drawing.Point(11, 28);
            this.gbListadoArticulos.Name = "gbListadoArticulos";
            this.gbListadoArticulos.Size = new System.Drawing.Size(782, 450);
            this.gbListadoArticulos.TabIndex = 4;
            this.gbListadoArticulos.TabStop = false;
            // 
            // dgvPreIngresos
            // 
            this.dgvPreIngresos.AllowUserToAddRows = false;
            this.dgvPreIngresos.AllowUserToResizeColumns = false;
            this.dgvPreIngresos.AllowUserToResizeRows = false;
            this.dgvPreIngresos.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvPreIngresos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPreIngresos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Codigo,
            this.Nit,
            this.Proveedor,
            this.Numero,
            this.Fecha});
            this.dgvPreIngresos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvPreIngresos.Location = new System.Drawing.Point(7, 14);
            this.dgvPreIngresos.Name = "dgvPreIngresos";
            this.dgvPreIngresos.Size = new System.Drawing.Size(764, 430);
            this.dgvPreIngresos.TabIndex = 3;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // Codigo
            // 
            this.Codigo.DataPropertyName = "codigo_proveedor";
            this.Codigo.HeaderText = "Código";
            this.Codigo.Name = "Codigo";
            // 
            // Nit
            // 
            this.Nit.DataPropertyName = "Nit";
            this.Nit.HeaderText = "Nit";
            this.Nit.Name = "Nit";
            // 
            // Proveedor
            // 
            this.Proveedor.DataPropertyName = "nombre";
            dataGridViewCellStyle3.NullValue = null;
            this.Proveedor.DefaultCellStyle = dataGridViewCellStyle3;
            this.Proveedor.HeaderText = "Proveedor";
            this.Proveedor.Name = "Proveedor";
            this.Proveedor.Width = 300;
            // 
            // Numero
            // 
            this.Numero.DataPropertyName = "numero";
            this.Numero.HeaderText = "Número";
            this.Numero.Name = "Numero";
            // 
            // Fecha
            // 
            this.Fecha.DataPropertyName = "fecha";
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            // 
            // tsEliminar
            // 
            this.tsEliminar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsEliminar.Image = ((System.Drawing.Image)(resources.GetObject("tsEliminar.Image")));
            this.tsEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsEliminar.Margin = new System.Windows.Forms.Padding(1, 1, 0, 2);
            this.tsEliminar.Name = "tsEliminar";
            this.tsEliminar.Size = new System.Drawing.Size(149, 22);
            this.tsEliminar.Text = "Eliminar registro [F3]";
            this.tsEliminar.Click += new System.EventHandler(this.tsEliminar_Click);
            // 
            // FrmConsultaPreIngreso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(807, 490);
            this.Controls.Add(this.gbListadoArticulos);
            this.Controls.Add(this.tsMenu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmConsultaPreIngreso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consultas";
            this.Load += new System.EventHandler(this.FrmConsultaPreIngreso_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmConsultaPreIngreso_KeyDown);
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.gbListadoArticulos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreIngresos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.ToolStripButton tsFacturar;
        private System.Windows.Forms.ToolStripButton tsSalir;
        private System.Windows.Forms.GroupBox gbListadoArticulos;
        private System.Windows.Forms.DataGridView dgvPreIngresos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Proveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.ToolStripButton tsEliminar;
    }
}