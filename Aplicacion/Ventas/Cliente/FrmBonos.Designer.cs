namespace Aplicacion.Ventas.Cliente
{
    partial class FrmBonos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBonos));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.tsBtnCanjeBono = new System.Windows.Forms.ToolStripButton();
            this.tsBtnCanjeSaldo = new System.Windows.Forms.ToolStripButton();
            this.tsBtnCopia = new System.Windows.Forms.ToolStripButton();
            this.tsBtnSalir = new System.Windows.Forms.ToolStripButton();
            this.gbCliente = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chkCanje = new System.Windows.Forms.CheckBox();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.btnBuscarCliente = new System.Windows.Forms.Button();
            this.txtNombreCliente = new System.Windows.Forms.TextBox();
            this.gbBono = new System.Windows.Forms.GroupBox();
            this.dgvBonos = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Factura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusBono = new System.Windows.Forms.StatusStrip();
            this.btnInicio = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnAnterior = new System.Windows.Forms.ToolStripDropDownButton();
            this.lblStatusBono = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnSiguiente = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnFin = new System.Windows.Forms.ToolStripDropDownButton();
            this.gbCanje = new System.Windows.Forms.GroupBox();
            this.dgvSeguimiento = new System.Windows.Forms.DataGridView();
            this.FechaC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbInformacion = new System.Windows.Forms.GroupBox();
            this.lblPesosSaldoB = new System.Windows.Forms.Label();
            this.lblSaldoBono = new System.Windows.Forms.Label();
            this.txtSaldoBono = new System.Windows.Forms.TextBox();
            this.lblPesosSaldo = new System.Windows.Forms.Label();
            this.lblSaldo = new System.Windows.Forms.Label();
            this.txtSaldo = new System.Windows.Forms.TextBox();
            this.tsMenu.SuspendLayout();
            this.gbCliente.SuspendLayout();
            this.gbBono.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBonos)).BeginInit();
            this.StatusBono.SuspendLayout();
            this.gbCanje.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeguimiento)).BeginInit();
            this.gbInformacion.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMenu
            // 
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnCopia,
            this.tsBtnCanjeBono,
            this.tsBtnCanjeSaldo,
            this.tsBtnSalir});
            this.tsMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(686, 25);
            this.tsMenu.TabIndex = 1;
            this.tsMenu.Text = "toolStrip1";
            // 
            // tsBtnCanjeBono
            // 
            this.tsBtnCanjeBono.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsBtnCanjeBono.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnCanjeBono.Image")));
            this.tsBtnCanjeBono.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnCanjeBono.Name = "tsBtnCanjeBono";
            this.tsBtnCanjeBono.Size = new System.Drawing.Size(101, 22);
            this.tsBtnCanjeBono.Text = "Retirar Bono";
            this.tsBtnCanjeBono.Visible = false;
            this.tsBtnCanjeBono.Click += new System.EventHandler(this.tsBtnCanjeBono_Click);
            // 
            // tsBtnCanjeSaldo
            // 
            this.tsBtnCanjeSaldo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsBtnCanjeSaldo.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnCanjeSaldo.Image")));
            this.tsBtnCanjeSaldo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnCanjeSaldo.Name = "tsBtnCanjeSaldo";
            this.tsBtnCanjeSaldo.Size = new System.Drawing.Size(104, 22);
            this.tsBtnCanjeSaldo.Text = "Retirar Saldo";
            this.tsBtnCanjeSaldo.Visible = false;
            this.tsBtnCanjeSaldo.Click += new System.EventHandler(this.tsBtnCanjeSaldo_Click);
            // 
            // tsBtnCopia
            // 
            this.tsBtnCopia.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsBtnCopia.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnCopia.Image")));
            this.tsBtnCopia.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnCopia.Name = "tsBtnCopia";
            this.tsBtnCopia.Size = new System.Drawing.Size(115, 22);
            this.tsBtnCopia.Text = "Imprimir Copia";
            this.tsBtnCopia.Click += new System.EventHandler(this.tsBtnCopia_Click);
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
            // gbCliente
            // 
            this.gbCliente.Controls.Add(this.label2);
            this.gbCliente.Controls.Add(this.label1);
            this.gbCliente.Controls.Add(this.chkCanje);
            this.gbCliente.Controls.Add(this.txtCliente);
            this.gbCliente.Controls.Add(this.btnBuscarCliente);
            this.gbCliente.Controls.Add(this.txtNombreCliente);
            this.gbCliente.Location = new System.Drawing.Point(7, 30);
            this.gbCliente.Name = "gbCliente";
            this.gbCliente.Size = new System.Drawing.Size(673, 67);
            this.gbCliente.TabIndex = 2;
            this.gbCliente.TabStop = false;
            this.gbCliente.Text = "Cliente";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(180, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 16);
            this.label2.TabIndex = 15;
            this.label2.Text = "Canjeables";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(180, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 16);
            this.label1.TabIndex = 14;
            this.label1.Text = "Solo";
            // 
            // chkCanje
            // 
            this.chkCanje.AutoSize = true;
            this.chkCanje.Checked = true;
            this.chkCanje.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCanje.Location = new System.Drawing.Point(163, 31);
            this.chkCanje.Name = "chkCanje";
            this.chkCanje.Size = new System.Drawing.Size(15, 14);
            this.chkCanje.TabIndex = 13;
            this.chkCanje.UseVisualStyleBackColor = true;
            this.chkCanje.Click += new System.EventHandler(this.chkCanje_Click);
            // 
            // txtCliente
            // 
            this.txtCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCliente.Location = new System.Drawing.Point(18, 26);
            this.txtCliente.MaxLength = 10;
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(104, 22);
            this.txtCliente.TabIndex = 10;
            this.txtCliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCliente_KeyPress);
            // 
            // btnBuscarCliente
            // 
            this.btnBuscarCliente.Location = new System.Drawing.Point(127, 26);
            this.btnBuscarCliente.Name = "btnBuscarCliente";
            this.btnBuscarCliente.Size = new System.Drawing.Size(25, 22);
            this.btnBuscarCliente.TabIndex = 11;
            this.btnBuscarCliente.Text = "...";
            this.btnBuscarCliente.UseVisualStyleBackColor = true;
            this.btnBuscarCliente.Click += new System.EventHandler(this.btnBuscarCliente_Click);
            // 
            // txtNombreCliente
            // 
            this.txtNombreCliente.Enabled = false;
            this.txtNombreCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreCliente.Location = new System.Drawing.Point(263, 26);
            this.txtNombreCliente.Name = "txtNombreCliente";
            this.txtNombreCliente.Size = new System.Drawing.Size(399, 22);
            this.txtNombreCliente.TabIndex = 12;
            // 
            // gbBono
            // 
            this.gbBono.Controls.Add(this.dgvBonos);
            this.gbBono.Controls.Add(this.StatusBono);
            this.gbBono.Location = new System.Drawing.Point(7, 103);
            this.gbBono.Name = "gbBono";
            this.gbBono.Size = new System.Drawing.Size(351, 339);
            this.gbBono.TabIndex = 3;
            this.gbBono.TabStop = false;
            this.gbBono.Text = "Notas de Crédito";
            // 
            // dgvBonos
            // 
            this.dgvBonos.AllowUserToAddRows = false;
            this.dgvBonos.AllowUserToDeleteRows = false;
            this.dgvBonos.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvBonos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBonos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Fecha,
            this.Factura,
            this.Valor});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBonos.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvBonos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvBonos.Location = new System.Drawing.Point(3, 23);
            this.dgvBonos.Name = "dgvBonos";
            this.dgvBonos.Size = new System.Drawing.Size(345, 290);
            this.dgvBonos.TabIndex = 3;
            this.dgvBonos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBonos_CellClick);
            this.dgvBonos.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgvBonos_KeyUp);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "idbono";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // Fecha
            // 
            this.Fecha.DataPropertyName = "fechabono";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.NullValue = null;
            this.Fecha.DefaultCellStyle = dataGridViewCellStyle1;
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            // 
            // Factura
            // 
            this.Factura.DataPropertyName = "numerofactura";
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.Factura.DefaultCellStyle = dataGridViewCellStyle2;
            this.Factura.HeaderText = "Factura";
            this.Factura.Name = "Factura";
            // 
            // Valor
            // 
            this.Valor.DataPropertyName = "valorbono";
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.Valor.DefaultCellStyle = dataGridViewCellStyle3;
            this.Valor.HeaderText = "Valor $";
            this.Valor.Name = "Valor";
            // 
            // StatusBono
            // 
            this.StatusBono.BackColor = System.Drawing.Color.LightSteelBlue;
            this.StatusBono.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnInicio,
            this.btnAnterior,
            this.lblStatusBono,
            this.btnSiguiente,
            this.btnFin});
            this.StatusBono.Location = new System.Drawing.Point(3, 314);
            this.StatusBono.Name = "StatusBono";
            this.StatusBono.Size = new System.Drawing.Size(345, 22);
            this.StatusBono.TabIndex = 2;
            this.StatusBono.Text = "Status de Saldos";
            // 
            // btnInicio
            // 
            this.btnInicio.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnInicio.Image = ((System.Drawing.Image)(resources.GetObject("btnInicio.Image")));
            this.btnInicio.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnInicio.Name = "btnInicio";
            this.btnInicio.ShowDropDownArrow = false;
            this.btnInicio.Size = new System.Drawing.Size(20, 20);
            this.btnInicio.Text = "Inicio";
            this.btnInicio.Click += new System.EventHandler(this.btnInicio_Click);
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
            // lblStatusBono
            // 
            this.lblStatusBono.Name = "lblStatusBono";
            this.lblStatusBono.Size = new System.Drawing.Size(30, 17);
            this.lblStatusBono.Text = "0 / 0";
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
            // btnFin
            // 
            this.btnFin.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFin.Image = ((System.Drawing.Image)(resources.GetObject("btnFin.Image")));
            this.btnFin.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFin.Name = "btnFin";
            this.btnFin.ShowDropDownArrow = false;
            this.btnFin.Size = new System.Drawing.Size(20, 20);
            this.btnFin.Text = "Fin";
            this.btnFin.Click += new System.EventHandler(this.btnFin_Click);
            // 
            // gbCanje
            // 
            this.gbCanje.Controls.Add(this.dgvSeguimiento);
            this.gbCanje.Location = new System.Drawing.Point(368, 103);
            this.gbCanje.Name = "gbCanje";
            this.gbCanje.Size = new System.Drawing.Size(310, 316);
            this.gbCanje.TabIndex = 4;
            this.gbCanje.TabStop = false;
            this.gbCanje.Text = "Transacciones";
            // 
            // dgvSeguimiento
            // 
            this.dgvSeguimiento.AllowUserToAddRows = false;
            this.dgvSeguimiento.AllowUserToDeleteRows = false;
            this.dgvSeguimiento.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvSeguimiento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSeguimiento.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FechaC,
            this.ValorS});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSeguimiento.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvSeguimiento.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvSeguimiento.Location = new System.Drawing.Point(4, 22);
            this.dgvSeguimiento.Name = "dgvSeguimiento";
            this.dgvSeguimiento.Size = new System.Drawing.Size(302, 290);
            this.dgvSeguimiento.TabIndex = 3;
            // 
            // FechaC
            // 
            this.FechaC.DataPropertyName = "fechaseguimiento_bono";
            dataGridViewCellStyle5.Format = "G";
            dataGridViewCellStyle5.NullValue = null;
            this.FechaC.DefaultCellStyle = dataGridViewCellStyle5;
            this.FechaC.HeaderText = "Fecha";
            this.FechaC.Name = "FechaC";
            this.FechaC.Width = 155;
            // 
            // ValorS
            // 
            this.ValorS.DataPropertyName = "valor";
            dataGridViewCellStyle6.Format = "N0";
            dataGridViewCellStyle6.NullValue = null;
            this.ValorS.DefaultCellStyle = dataGridViewCellStyle6;
            this.ValorS.HeaderText = "Valor $";
            this.ValorS.Name = "ValorS";
            // 
            // gbInformacion
            // 
            this.gbInformacion.Controls.Add(this.lblPesosSaldoB);
            this.gbInformacion.Controls.Add(this.lblSaldoBono);
            this.gbInformacion.Controls.Add(this.txtSaldoBono);
            this.gbInformacion.Controls.Add(this.lblPesosSaldo);
            this.gbInformacion.Controls.Add(this.lblSaldo);
            this.gbInformacion.Controls.Add(this.txtSaldo);
            this.gbInformacion.Location = new System.Drawing.Point(7, 448);
            this.gbInformacion.Name = "gbInformacion";
            this.gbInformacion.Size = new System.Drawing.Size(671, 54);
            this.gbInformacion.TabIndex = 5;
            this.gbInformacion.TabStop = false;
            this.gbInformacion.Text = "Información General";
            // 
            // lblPesosSaldoB
            // 
            this.lblPesosSaldoB.AutoSize = true;
            this.lblPesosSaldoB.Location = new System.Drawing.Point(447, 23);
            this.lblPesosSaldoB.Name = "lblPesosSaldoB";
            this.lblPesosSaldoB.Size = new System.Drawing.Size(15, 16);
            this.lblPesosSaldoB.TabIndex = 9;
            this.lblPesosSaldoB.Text = "$";
            // 
            // lblSaldoBono
            // 
            this.lblSaldoBono.AutoSize = true;
            this.lblSaldoBono.Location = new System.Drawing.Point(361, 24);
            this.lblSaldoBono.Name = "lblSaldoBono";
            this.lblSaldoBono.Size = new System.Drawing.Size(76, 16);
            this.lblSaldoBono.TabIndex = 8;
            this.lblSaldoBono.Text = "Saldo Nota";
            // 
            // txtSaldoBono
            // 
            this.txtSaldoBono.BackColor = System.Drawing.Color.PaleTurquoise;
            this.txtSaldoBono.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.txtSaldoBono.Location = new System.Drawing.Point(465, 18);
            this.txtSaldoBono.Name = "txtSaldoBono";
            this.txtSaldoBono.ReadOnly = true;
            this.txtSaldoBono.Size = new System.Drawing.Size(197, 27);
            this.txtSaldoBono.TabIndex = 7;
            this.txtSaldoBono.Text = "0";
            this.txtSaldoBono.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblPesosSaldo
            // 
            this.lblPesosSaldo.AutoSize = true;
            this.lblPesosSaldo.Location = new System.Drawing.Point(114, 23);
            this.lblPesosSaldo.Name = "lblPesosSaldo";
            this.lblPesosSaldo.Size = new System.Drawing.Size(15, 16);
            this.lblPesosSaldo.TabIndex = 6;
            this.lblPesosSaldo.Text = "$";
            // 
            // lblSaldo
            // 
            this.lblSaldo.AutoSize = true;
            this.lblSaldo.Location = new System.Drawing.Point(11, 24);
            this.lblSaldo.Name = "lblSaldo";
            this.lblSaldo.Size = new System.Drawing.Size(84, 16);
            this.lblSaldo.TabIndex = 5;
            this.lblSaldo.Text = "Saldo Actual";
            // 
            // txtSaldo
            // 
            this.txtSaldo.BackColor = System.Drawing.Color.PaleTurquoise;
            this.txtSaldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.txtSaldo.Location = new System.Drawing.Point(132, 18);
            this.txtSaldo.Name = "txtSaldo";
            this.txtSaldo.ReadOnly = true;
            this.txtSaldo.Size = new System.Drawing.Size(197, 27);
            this.txtSaldo.TabIndex = 0;
            this.txtSaldo.Text = "0";
            this.txtSaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // FrmBonos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(686, 522);
            this.Controls.Add(this.gbInformacion);
            this.Controls.Add(this.gbCanje);
            this.Controls.Add(this.gbBono);
            this.Controls.Add(this.gbCliente);
            this.Controls.Add(this.tsMenu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmBonos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nota Crédito de Cliente";
            this.Load += new System.EventHandler(this.FrmBonos_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmBonos_KeyDown);
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.gbCliente.ResumeLayout(false);
            this.gbCliente.PerformLayout();
            this.gbBono.ResumeLayout(false);
            this.gbBono.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBonos)).EndInit();
            this.StatusBono.ResumeLayout(false);
            this.StatusBono.PerformLayout();
            this.gbCanje.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeguimiento)).EndInit();
            this.gbInformacion.ResumeLayout(false);
            this.gbInformacion.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.ToolStripButton tsBtnSalir;
        private System.Windows.Forms.GroupBox gbCliente;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Button btnBuscarCliente;
        private System.Windows.Forms.TextBox txtNombreCliente;
        private System.Windows.Forms.GroupBox gbBono;
        private System.Windows.Forms.DataGridView dgvBonos;
        private System.Windows.Forms.StatusStrip StatusBono;
        private System.Windows.Forms.ToolStripDropDownButton btnInicio;
        private System.Windows.Forms.ToolStripDropDownButton btnAnterior;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusBono;
        private System.Windows.Forms.ToolStripDropDownButton btnSiguiente;
        private System.Windows.Forms.ToolStripDropDownButton btnFin;
        private System.Windows.Forms.GroupBox gbCanje;
        private System.Windows.Forms.DataGridView dgvSeguimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Factura;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valor;
        private System.Windows.Forms.GroupBox gbInformacion;
        private System.Windows.Forms.Label lblPesosSaldo;
        private System.Windows.Forms.Label lblSaldo;
        private System.Windows.Forms.TextBox txtSaldo;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaC;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorS;
        private System.Windows.Forms.Label lblPesosSaldoB;
        private System.Windows.Forms.Label lblSaldoBono;
        private System.Windows.Forms.TextBox txtSaldoBono;
        private System.Windows.Forms.CheckBox chkCanje;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripButton tsBtnCanjeBono;
        private System.Windows.Forms.ToolStripButton tsBtnCanjeSaldo;
        private System.Windows.Forms.ToolStripButton tsBtnCopia;
    }
}