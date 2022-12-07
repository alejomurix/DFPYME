namespace Aplicacion.Compras.CarteraRemision
{
    partial class FrmCartera
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCartera));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.tsBtnImprimir = new System.Windows.Forms.ToolStripButton();
            this.tsBtnImprimirResumen = new System.Windows.Forms.ToolStripButton();
            this.tsBtnSalir = new System.Windows.Forms.ToolStripButton();
            this.gbCartera = new System.Windows.Forms.GroupBox();
            this.lblSaldoCliente = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtSaldoProveedor = new System.Windows.Forms.TextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.dgvCartera = new System.Windows.Forms.DataGridView();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Factura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Limite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Abono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Saldo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbCriterio = new System.Windows.Forms.GroupBox();
            this.btnBuscarProveedor = new System.Windows.Forms.Button();
            this.cbCriterioProveedor = new System.Windows.Forms.ComboBox();
            this.cbContado = new System.Windows.Forms.ComboBox();
            this.txtConsulta = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.tsMenu.SuspendLayout();
            this.gbCartera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCartera)).BeginInit();
            this.gbCriterio.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMenu
            // 
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnImprimir,
            this.tsBtnImprimirResumen,
            this.tsBtnSalir});
            this.tsMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(1181, 25);
            this.tsMenu.TabIndex = 0;
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
            // tsBtnImprimirResumen
            // 
            this.tsBtnImprimirResumen.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsBtnImprimirResumen.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnImprimirResumen.Image")));
            this.tsBtnImprimirResumen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnImprimirResumen.Name = "tsBtnImprimirResumen";
            this.tsBtnImprimirResumen.Size = new System.Drawing.Size(176, 22);
            this.tsBtnImprimirResumen.Text = "Imprimir resumen cartera";
            this.tsBtnImprimirResumen.Click += new System.EventHandler(this.tsBtnImprimirResumen_Click);
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
            // gbCartera
            // 
            this.gbCartera.Controls.Add(this.lblSaldoCliente);
            this.gbCartera.Controls.Add(this.txtNombre);
            this.gbCartera.Controls.Add(this.txtSaldoProveedor);
            this.gbCartera.Controls.Add(this.lblTotal);
            this.gbCartera.Controls.Add(this.txtTotal);
            this.gbCartera.Controls.Add(this.dgvCartera);
            this.gbCartera.Location = new System.Drawing.Point(12, 108);
            this.gbCartera.Name = "gbCartera";
            this.gbCartera.Size = new System.Drawing.Size(1160, 423);
            this.gbCartera.TabIndex = 1;
            this.gbCartera.TabStop = false;
            // 
            // lblSaldoCliente
            // 
            this.lblSaldoCliente.AutoSize = true;
            this.lblSaldoCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaldoCliente.Location = new System.Drawing.Point(317, 394);
            this.lblSaldoCliente.Name = "lblSaldoCliente";
            this.lblSaldoCliente.Size = new System.Drawing.Size(134, 18);
            this.lblSaldoCliente.TabIndex = 5;
            this.lblSaldoCliente.Text = "Saldo Proveedor";
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(6, 390);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.ReadOnly = true;
            this.txtNombre.Size = new System.Drawing.Size(305, 24);
            this.txtNombre.TabIndex = 4;
            this.txtNombre.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtSaldoProveedor
            // 
            this.txtSaldoProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSaldoProveedor.Location = new System.Drawing.Point(459, 390);
            this.txtSaldoProveedor.Name = "txtSaldoProveedor";
            this.txtSaldoProveedor.ReadOnly = true;
            this.txtSaldoProveedor.Size = new System.Drawing.Size(111, 24);
            this.txtSaldoProveedor.TabIndex = 3;
            this.txtSaldoProveedor.Text = "0";
            this.txtSaldoProveedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(967, 394);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(60, 18);
            this.lblTotal.TabIndex = 2;
            this.lblTotal.Text = "TOTAL";
            // 
            // txtTotal
            // 
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(1043, 390);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(111, 24);
            this.txtTotal.TabIndex = 1;
            this.txtTotal.Text = "0";
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dgvCartera
            // 
            this.dgvCartera.AllowUserToAddRows = false;
            this.dgvCartera.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvCartera.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCartera.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.Nit,
            this.Nombre,
            this.Factura,
            this.Fecha,
            this.Limite,
            this.Valor,
            this.Abono,
            this.Saldo});
            this.dgvCartera.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvCartera.Location = new System.Drawing.Point(4, 11);
            this.dgvCartera.Name = "dgvCartera";
            this.dgvCartera.RowHeadersVisible = false;
            this.dgvCartera.Size = new System.Drawing.Size(1151, 373);
            this.dgvCartera.TabIndex = 0;
            this.dgvCartera.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCartera_CellClick);
            this.dgvCartera.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvCartera_ColumnHeaderMouseClick);
            this.dgvCartera.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgvCartera_KeyUp);
            // 
            // Codigo
            // 
            this.Codigo.DataPropertyName = "Codigo";
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "Codigo";
            // 
            // Nit
            // 
            this.Nit.DataPropertyName = "Cedula";
            this.Nit.HeaderText = "Nit";
            this.Nit.Name = "Nit";
            this.Nit.Width = 150;
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "Nombre";
            this.Nombre.HeaderText = "Proveedor";
            this.Nombre.Name = "Nombre";
            this.Nombre.Width = 280;
            // 
            // Factura
            // 
            this.Factura.DataPropertyName = "Factura";
            this.Factura.HeaderText = "No. Remisión";
            this.Factura.Name = "Factura";
            this.Factura.Width = 115;
            // 
            // Fecha
            // 
            this.Fecha.DataPropertyName = "Fecha";
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.Fecha.DefaultCellStyle = dataGridViewCellStyle1;
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            // 
            // Limite
            // 
            this.Limite.DataPropertyName = "Limite";
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.Limite.DefaultCellStyle = dataGridViewCellStyle2;
            this.Limite.HeaderText = "Limite";
            this.Limite.Name = "Limite";
            // 
            // Valor
            // 
            this.Valor.DataPropertyName = "Valor";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.Valor.DefaultCellStyle = dataGridViewCellStyle3;
            this.Valor.HeaderText = "Valor";
            this.Valor.Name = "Valor";
            // 
            // Abono
            // 
            this.Abono.DataPropertyName = "Abonos";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = null;
            this.Abono.DefaultCellStyle = dataGridViewCellStyle4;
            this.Abono.HeaderText = "Abonos";
            this.Abono.Name = "Abono";
            // 
            // Saldo
            // 
            this.Saldo.DataPropertyName = "Saldo";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N0";
            dataGridViewCellStyle5.NullValue = null;
            this.Saldo.DefaultCellStyle = dataGridViewCellStyle5;
            this.Saldo.HeaderText = "Saldo";
            this.Saldo.Name = "Saldo";
            // 
            // gbCriterio
            // 
            this.gbCriterio.Controls.Add(this.btnBuscarProveedor);
            this.gbCriterio.Controls.Add(this.cbCriterioProveedor);
            this.gbCriterio.Controls.Add(this.cbContado);
            this.gbCriterio.Controls.Add(this.txtConsulta);
            this.gbCriterio.Controls.Add(this.btnBuscar);
            this.gbCriterio.Location = new System.Drawing.Point(12, 34);
            this.gbCriterio.Name = "gbCriterio";
            this.gbCriterio.Size = new System.Drawing.Size(699, 71);
            this.gbCriterio.TabIndex = 0;
            this.gbCriterio.TabStop = false;
            this.gbCriterio.Text = "Criterios de consulta";
            // 
            // btnBuscarProveedor
            // 
            this.btnBuscarProveedor.Location = new System.Drawing.Point(615, 26);
            this.btnBuscarProveedor.Name = "btnBuscarProveedor";
            this.btnBuscarProveedor.Size = new System.Drawing.Size(25, 23);
            this.btnBuscarProveedor.TabIndex = 24;
            this.btnBuscarProveedor.Text = "...";
            this.btnBuscarProveedor.UseVisualStyleBackColor = true;
            this.btnBuscarProveedor.Click += new System.EventHandler(this.btnBuscarProveedor_Click);
            // 
            // cbCriterioProveedor
            // 
            this.cbCriterioProveedor.DisplayMember = "Nombre";
            this.cbCriterioProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCriterioProveedor.Enabled = false;
            this.cbCriterioProveedor.FormattingEnabled = true;
            this.cbCriterioProveedor.Location = new System.Drawing.Point(182, 25);
            this.cbCriterioProveedor.Name = "cbCriterioProveedor";
            this.cbCriterioProveedor.Size = new System.Drawing.Size(107, 24);
            this.cbCriterioProveedor.TabIndex = 23;
            this.cbCriterioProveedor.ValueMember = "Id";
            // 
            // cbContado
            // 
            this.cbContado.DisplayMember = "Nombre";
            this.cbContado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbContado.FormattingEnabled = true;
            this.cbContado.Location = new System.Drawing.Point(10, 25);
            this.cbContado.Name = "cbContado";
            this.cbContado.Size = new System.Drawing.Size(166, 24);
            this.cbContado.TabIndex = 22;
            this.cbContado.ValueMember = "Id";
            this.cbContado.SelectedIndexChanged += new System.EventHandler(this.cbContado_SelectedIndexChanged);
            // 
            // txtConsulta
            // 
            this.txtConsulta.Location = new System.Drawing.Point(299, 27);
            this.txtConsulta.Name = "txtConsulta";
            this.txtConsulta.Size = new System.Drawing.Size(310, 22);
            this.txtConsulta.TabIndex = 0;
            this.txtConsulta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtConsulta_KeyPress);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(646, 26);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(25, 23);
            this.btnBuscar.TabIndex = 1;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // FrmCartera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1181, 543);
            this.Controls.Add(this.tsMenu);
            this.Controls.Add(this.gbCriterio);
            this.Controls.Add(this.gbCartera);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCartera";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cartera Remisión de proveedores";
            this.Load += new System.EventHandler(this.FrmCartera_Load);
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.gbCartera.ResumeLayout(false);
            this.gbCartera.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCartera)).EndInit();
            this.gbCriterio.ResumeLayout(false);
            this.gbCriterio.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.GroupBox gbCartera;
        private System.Windows.Forms.GroupBox gbCriterio;
        private System.Windows.Forms.DataGridView dgvCartera;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ComboBox cbContado;
        private System.Windows.Forms.TextBox txtConsulta;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.ToolStripButton tsBtnImprimir;
        private System.Windows.Forms.ToolStripButton tsBtnSalir;
        private System.Windows.Forms.ToolStripButton tsBtnImprimirResumen;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtSaldoProveedor;
        private System.Windows.Forms.Label lblSaldoCliente;
        private System.Windows.Forms.ComboBox cbCriterioProveedor;
        private System.Windows.Forms.Button btnBuscarProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Factura;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Limite;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Abono;
        private System.Windows.Forms.DataGridViewTextBoxColumn Saldo;
    }
}