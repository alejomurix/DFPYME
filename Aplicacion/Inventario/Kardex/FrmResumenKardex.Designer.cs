namespace Aplicacion.Inventario.Kardex
{
    partial class FrmResumenKardex
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmResumenKardex));
            this.gbMovimientos = new System.Windows.Forms.GroupBox();
            this.gbSalidas = new System.Windows.Forms.GroupBox();
            this.dgvKardexSalida = new Aplicacion.Ventas.Factura.DataGridViewPlus();
            this.dgvKardexEntrada = new Aplicacion.Ventas.Factura.DataGridViewPlus();
            this.IdConcepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Articulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IconoOperacion = new System.Windows.Forms.DataGridViewImageColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdConceptoS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ConceptoS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImagenS = new System.Windows.Forms.DataGridViewImageColumn();
            this.CantidadS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbMovimientos.SuspendLayout();
            this.gbSalidas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKardexSalida)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKardexEntrada)).BeginInit();
            this.SuspendLayout();
            // 
            // gbMovimientos
            // 
            this.gbMovimientos.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.gbMovimientos.Controls.Add(this.dgvKardexEntrada);
            this.gbMovimientos.Location = new System.Drawing.Point(12, 12);
            this.gbMovimientos.Name = "gbMovimientos";
            this.gbMovimientos.Size = new System.Drawing.Size(583, 182);
            this.gbMovimientos.TabIndex = 3;
            this.gbMovimientos.TabStop = false;
            this.gbMovimientos.Text = "Entradas";
            // 
            // gbSalidas
            // 
            this.gbSalidas.BackColor = System.Drawing.Color.LightGreen;
            this.gbSalidas.Controls.Add(this.dgvKardexSalida);
            this.gbSalidas.Location = new System.Drawing.Point(12, 197);
            this.gbSalidas.Name = "gbSalidas";
            this.gbSalidas.Size = new System.Drawing.Size(583, 224);
            this.gbSalidas.TabIndex = 4;
            this.gbSalidas.TabStop = false;
            this.gbSalidas.Text = "Salidas";
            // 
            // dgvKardexSalida
            // 
            this.dgvKardexSalida.AllowUserToAddRows = false;
            this.dgvKardexSalida.AllowUserToResizeColumns = false;
            this.dgvKardexSalida.AllowUserToResizeRows = false;
            this.dgvKardexSalida.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvKardexSalida.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKardexSalida.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdConceptoS,
            this.ConceptoS,
            this.ImagenS,
            this.CantidadS,
            this.ValorS});
            this.dgvKardexSalida.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvKardexSalida.Location = new System.Drawing.Point(3, 16);
            this.dgvKardexSalida.Name = "dgvKardexSalida";
            this.dgvKardexSalida.RowHeadersVisible = false;
            this.dgvKardexSalida.Size = new System.Drawing.Size(576, 204);
            this.dgvKardexSalida.TabIndex = 1;
            // 
            // dgvKardexEntrada
            // 
            this.dgvKardexEntrada.AllowUserToAddRows = false;
            this.dgvKardexEntrada.AllowUserToResizeColumns = false;
            this.dgvKardexEntrada.AllowUserToResizeRows = false;
            this.dgvKardexEntrada.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvKardexEntrada.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKardexEntrada.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdConcepto,
            this.Articulo,
            this.IconoOperacion,
            this.Cantidad,
            this.Valor});
            this.dgvKardexEntrada.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvKardexEntrada.Location = new System.Drawing.Point(3, 16);
            this.dgvKardexEntrada.Name = "dgvKardexEntrada";
            this.dgvKardexEntrada.RowHeadersVisible = false;
            this.dgvKardexEntrada.Size = new System.Drawing.Size(576, 161);
            this.dgvKardexEntrada.TabIndex = 1;
            // 
            // IdConcepto
            // 
            this.IdConcepto.DataPropertyName = "IdConcepto";
            this.IdConcepto.HeaderText = "IdConcepto";
            this.IdConcepto.Name = "IdConcepto";
            this.IdConcepto.Visible = false;
            // 
            // Articulo
            // 
            this.Articulo.DataPropertyName = "Concepto";
            this.Articulo.HeaderText = "Concepto";
            this.Articulo.Name = "Articulo";
            this.Articulo.ReadOnly = true;
            this.Articulo.Width = 280;
            // 
            // IconoOperacion
            // 
            this.IconoOperacion.DataPropertyName = "Imagen";
            this.IconoOperacion.HeaderText = "";
            this.IconoOperacion.Name = "IconoOperacion";
            this.IconoOperacion.ReadOnly = true;
            this.IconoOperacion.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IconoOperacion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.IconoOperacion.Width = 78;
            // 
            // Cantidad
            // 
            this.Cantidad.DataPropertyName = "Cantidad";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            this.Cantidad.DefaultCellStyle = dataGridViewCellStyle1;
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            // 
            // Valor
            // 
            this.Valor.DataPropertyName = "Valor";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "C0";
            dataGridViewCellStyle2.NullValue = null;
            this.Valor.DefaultCellStyle = dataGridViewCellStyle2;
            this.Valor.HeaderText = "Valor Prom.";
            this.Valor.Name = "Valor";
            this.Valor.Width = 112;
            // 
            // IdConceptoS
            // 
            this.IdConceptoS.DataPropertyName = "IdConcepto";
            this.IdConceptoS.HeaderText = "IdConcepto";
            this.IdConceptoS.Name = "IdConceptoS";
            this.IdConceptoS.Visible = false;
            // 
            // ConceptoS
            // 
            this.ConceptoS.DataPropertyName = "Concepto";
            this.ConceptoS.HeaderText = "Concepto";
            this.ConceptoS.Name = "ConceptoS";
            this.ConceptoS.ReadOnly = true;
            this.ConceptoS.Width = 280;
            // 
            // ImagenS
            // 
            this.ImagenS.DataPropertyName = "Imagen";
            this.ImagenS.HeaderText = "";
            this.ImagenS.Name = "ImagenS";
            this.ImagenS.ReadOnly = true;
            this.ImagenS.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ImagenS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ImagenS.Width = 78;
            // 
            // CantidadS
            // 
            this.CantidadS.DataPropertyName = "Cantidad";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.CantidadS.DefaultCellStyle = dataGridViewCellStyle3;
            this.CantidadS.HeaderText = "Cantidad";
            this.CantidadS.Name = "CantidadS";
            this.CantidadS.ReadOnly = true;
            // 
            // ValorS
            // 
            this.ValorS.DataPropertyName = "Valor";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "C0";
            dataGridViewCellStyle4.NullValue = null;
            this.ValorS.DefaultCellStyle = dataGridViewCellStyle4;
            this.ValorS.HeaderText = "Valor Prom.";
            this.ValorS.Name = "ValorS";
            this.ValorS.Width = 112;
            // 
            // FrmResumenKardex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(609, 437);
            this.Controls.Add(this.gbSalidas);
            this.Controls.Add(this.gbMovimientos);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmResumenKardex";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Resumen Kardex";
            this.Load += new System.EventHandler(this.FrmResumenKardex_Load);
            this.gbMovimientos.ResumeLayout(false);
            this.gbSalidas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKardexSalida)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKardexEntrada)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbMovimientos;
        private Ventas.Factura.DataGridViewPlus dgvKardexEntrada;
        private System.Windows.Forms.GroupBox gbSalidas;
        private Ventas.Factura.DataGridViewPlus dgvKardexSalida;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdConcepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Articulo;
        private System.Windows.Forms.DataGridViewImageColumn IconoOperacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdConceptoS;
        private System.Windows.Forms.DataGridViewTextBoxColumn ConceptoS;
        private System.Windows.Forms.DataGridViewImageColumn ImagenS;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantidadS;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorS;
    }
}