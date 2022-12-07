namespace Aplicacion.Ventas.Cliente
{
    partial class FrmAdelanto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAdelanto));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.tsBtnNuevo = new System.Windows.Forms.ToolStripButton();
            this.tsBtnRetirarSaldo = new System.Windows.Forms.ToolStripButton();
            this.tsBtnCopia = new System.Windows.Forms.ToolStripButton();
            this.tsBtnSalir = new System.Windows.Forms.ToolStripButton();
            this.gbCliente = new System.Windows.Forms.GroupBox();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.btnBuscarCliente = new System.Windows.Forms.Button();
            this.txtNombreCliente = new System.Windows.Forms.TextBox();
            this.gbAdelantos = new System.Windows.Forms.GroupBox();
            this.dgvAdelantos = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Saldo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusSaldo = new System.Windows.Forms.StatusStrip();
            this.btnInicio = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnAnterior = new System.Windows.Forms.ToolStripDropDownButton();
            this.lblStatusSaldo = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnSiguiente = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnFin = new System.Windows.Forms.ToolStripDropDownButton();
            this.gbCanje = new System.Windows.Forms.GroupBox();
            this.dgvCanje = new System.Windows.Forms.DataGridView();
            this.FechaC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaldoC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusCanje = new System.Windows.Forms.StatusStrip();
            this.btnInicioC = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnAnteriorC = new System.Windows.Forms.ToolStripDropDownButton();
            this.lblStatusCanje = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnSiguienteC = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnFinC = new System.Windows.Forms.ToolStripDropDownButton();
            this.gbInformacion = new System.Windows.Forms.GroupBox();
            this.lblPesosSaldo = new System.Windows.Forms.Label();
            this.lblSaldo = new System.Windows.Forms.Label();
            this.txtSaldo = new System.Windows.Forms.TextBox();
            this.tsMenu.SuspendLayout();
            this.gbCliente.SuspendLayout();
            this.gbAdelantos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdelantos)).BeginInit();
            this.StatusSaldo.SuspendLayout();
            this.gbCanje.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCanje)).BeginInit();
            this.StatusCanje.SuspendLayout();
            this.gbInformacion.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMenu
            // 
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnNuevo,
            this.tsBtnRetirarSaldo,
            this.tsBtnCopia,
            this.tsBtnSalir});
            this.tsMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(839, 25);
            this.tsMenu.TabIndex = 0;
            this.tsMenu.Text = "toolStrip1";
            // 
            // tsBtnNuevo
            // 
            this.tsBtnNuevo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsBtnNuevo.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnNuevo.Image")));
            this.tsBtnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnNuevo.Name = "tsBtnNuevo";
            this.tsBtnNuevo.Size = new System.Drawing.Size(117, 22);
            this.tsBtnNuevo.Text = "Nuevo Anticipo";
            this.tsBtnNuevo.Click += new System.EventHandler(this.tsBtnNuevo_Click);
            // 
            // tsBtnRetirarSaldo
            // 
            this.tsBtnRetirarSaldo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsBtnRetirarSaldo.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnRetirarSaldo.Image")));
            this.tsBtnRetirarSaldo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnRetirarSaldo.Name = "tsBtnRetirarSaldo";
            this.tsBtnRetirarSaldo.Size = new System.Drawing.Size(104, 22);
            this.tsBtnRetirarSaldo.Text = "Retirar Saldo";
            this.tsBtnRetirarSaldo.Click += new System.EventHandler(this.tsBtnRetirarSaldo_Click);
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
            this.tsBtnSalir.Size = new System.Drawing.Size(53, 22);
            this.tsBtnSalir.Text = "Salir";
            this.tsBtnSalir.Click += new System.EventHandler(this.tsBtnSalir_Click);
            // 
            // gbCliente
            // 
            this.gbCliente.Controls.Add(this.txtCliente);
            this.gbCliente.Controls.Add(this.btnBuscarCliente);
            this.gbCliente.Controls.Add(this.txtNombreCliente);
            this.gbCliente.Location = new System.Drawing.Point(7, 29);
            this.gbCliente.Name = "gbCliente";
            this.gbCliente.Size = new System.Drawing.Size(824, 67);
            this.gbCliente.TabIndex = 1;
            this.gbCliente.TabStop = false;
            this.gbCliente.Text = "Cliente";
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
            this.btnBuscarCliente.Location = new System.Drawing.Point(132, 26);
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
            this.txtNombreCliente.Location = new System.Drawing.Point(177, 26);
            this.txtNombreCliente.Name = "txtNombreCliente";
            this.txtNombreCliente.Size = new System.Drawing.Size(422, 22);
            this.txtNombreCliente.TabIndex = 12;
            // 
            // gbAdelantos
            // 
            this.gbAdelantos.Controls.Add(this.dgvAdelantos);
            this.gbAdelantos.Controls.Add(this.StatusSaldo);
            this.gbAdelantos.Location = new System.Drawing.Point(7, 102);
            this.gbAdelantos.Name = "gbAdelantos";
            this.gbAdelantos.Size = new System.Drawing.Size(408, 339);
            this.gbAdelantos.TabIndex = 2;
            this.gbAdelantos.TabStop = false;
            this.gbAdelantos.Text = "Anticipos";
            // 
            // dgvAdelantos
            // 
            this.dgvAdelantos.AllowUserToAddRows = false;
            this.dgvAdelantos.AllowUserToDeleteRows = false;
            this.dgvAdelantos.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvAdelantos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAdelantos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Fecha,
            this.Valor,
            this.Saldo});
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAdelantos.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgvAdelantos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvAdelantos.Location = new System.Drawing.Point(3, 23);
            this.dgvAdelantos.Name = "dgvAdelantos";
            this.dgvAdelantos.Size = new System.Drawing.Size(401, 290);
            this.dgvAdelantos.TabIndex = 3;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // Fecha
            // 
            this.Fecha.DataPropertyName = "fecha";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.Format = "G";
            dataGridViewCellStyle9.NullValue = null;
            this.Fecha.DefaultCellStyle = dataGridViewCellStyle9;
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.Width = 155;
            // 
            // Valor
            // 
            this.Valor.DataPropertyName = "valor";
            dataGridViewCellStyle10.Format = "N0";
            dataGridViewCellStyle10.NullValue = null;
            this.Valor.DefaultCellStyle = dataGridViewCellStyle10;
            this.Valor.HeaderText = "Valor $";
            this.Valor.Name = "Valor";
            // 
            // Saldo
            // 
            this.Saldo.DataPropertyName = "saldo";
            dataGridViewCellStyle11.Format = "N0";
            dataGridViewCellStyle11.NullValue = null;
            this.Saldo.DefaultCellStyle = dataGridViewCellStyle11;
            this.Saldo.HeaderText = "Saldo $";
            this.Saldo.Name = "Saldo";
            // 
            // StatusSaldo
            // 
            this.StatusSaldo.BackColor = System.Drawing.Color.LightSteelBlue;
            this.StatusSaldo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnInicio,
            this.btnAnterior,
            this.lblStatusSaldo,
            this.btnSiguiente,
            this.btnFin});
            this.StatusSaldo.Location = new System.Drawing.Point(3, 314);
            this.StatusSaldo.Name = "StatusSaldo";
            this.StatusSaldo.Size = new System.Drawing.Size(402, 22);
            this.StatusSaldo.TabIndex = 2;
            this.StatusSaldo.Text = "Status de Saldos";
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
            // lblStatusSaldo
            // 
            this.lblStatusSaldo.Name = "lblStatusSaldo";
            this.lblStatusSaldo.Size = new System.Drawing.Size(30, 17);
            this.lblStatusSaldo.Text = "0 / 0";
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
            this.gbCanje.Controls.Add(this.dgvCanje);
            this.gbCanje.Controls.Add(this.StatusCanje);
            this.gbCanje.Location = new System.Drawing.Point(423, 102);
            this.gbCanje.Name = "gbCanje";
            this.gbCanje.Size = new System.Drawing.Size(408, 339);
            this.gbCanje.TabIndex = 3;
            this.gbCanje.TabStop = false;
            this.gbCanje.Text = "Transacciones";
            // 
            // dgvCanje
            // 
            this.dgvCanje.AllowUserToAddRows = false;
            this.dgvCanje.AllowUserToDeleteRows = false;
            this.dgvCanje.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvCanje.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCanje.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FechaC,
            this.ValorC,
            this.SaldoC});
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCanje.DefaultCellStyle = dataGridViewCellStyle16;
            this.dgvCanje.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvCanje.Location = new System.Drawing.Point(4, 22);
            this.dgvCanje.Name = "dgvCanje";
            this.dgvCanje.Size = new System.Drawing.Size(399, 290);
            this.dgvCanje.TabIndex = 3;
            // 
            // FechaC
            // 
            this.FechaC.DataPropertyName = "fecha";
            dataGridViewCellStyle13.Format = "G";
            dataGridViewCellStyle13.NullValue = null;
            this.FechaC.DefaultCellStyle = dataGridViewCellStyle13;
            this.FechaC.HeaderText = "Fecha";
            this.FechaC.Name = "FechaC";
            this.FechaC.Width = 155;
            // 
            // ValorC
            // 
            this.ValorC.DataPropertyName = "concepto";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.Format = "N0";
            dataGridViewCellStyle14.NullValue = null;
            this.ValorC.DefaultCellStyle = dataGridViewCellStyle14;
            this.ValorC.HeaderText = "Concepto";
            this.ValorC.Name = "ValorC";
            // 
            // SaldoC
            // 
            this.SaldoC.DataPropertyName = "valor";
            dataGridViewCellStyle15.Format = "N0";
            dataGridViewCellStyle15.NullValue = null;
            this.SaldoC.DefaultCellStyle = dataGridViewCellStyle15;
            this.SaldoC.HeaderText = "Saldo $";
            this.SaldoC.Name = "SaldoC";
            // 
            // StatusCanje
            // 
            this.StatusCanje.BackColor = System.Drawing.Color.LightSteelBlue;
            this.StatusCanje.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnInicioC,
            this.btnAnteriorC,
            this.lblStatusCanje,
            this.btnSiguienteC,
            this.btnFinC});
            this.StatusCanje.Location = new System.Drawing.Point(3, 314);
            this.StatusCanje.Name = "StatusCanje";
            this.StatusCanje.Size = new System.Drawing.Size(402, 22);
            this.StatusCanje.TabIndex = 2;
            this.StatusCanje.Text = "Status de Saldos";
            // 
            // btnInicioC
            // 
            this.btnInicioC.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnInicioC.Image = ((System.Drawing.Image)(resources.GetObject("btnInicioC.Image")));
            this.btnInicioC.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnInicioC.Name = "btnInicioC";
            this.btnInicioC.ShowDropDownArrow = false;
            this.btnInicioC.Size = new System.Drawing.Size(20, 20);
            this.btnInicioC.Text = "Inicio";
            this.btnInicioC.Click += new System.EventHandler(this.btnInicioC_Click);
            // 
            // btnAnteriorC
            // 
            this.btnAnteriorC.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAnteriorC.Image = ((System.Drawing.Image)(resources.GetObject("btnAnteriorC.Image")));
            this.btnAnteriorC.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAnteriorC.Name = "btnAnteriorC";
            this.btnAnteriorC.ShowDropDownArrow = false;
            this.btnAnteriorC.Size = new System.Drawing.Size(20, 20);
            this.btnAnteriorC.Text = "Anterior";
            this.btnAnteriorC.Click += new System.EventHandler(this.btnAnteriorC_Click);
            // 
            // lblStatusCanje
            // 
            this.lblStatusCanje.Name = "lblStatusCanje";
            this.lblStatusCanje.Size = new System.Drawing.Size(30, 17);
            this.lblStatusCanje.Text = "0 / 0";
            // 
            // btnSiguienteC
            // 
            this.btnSiguienteC.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSiguienteC.Image = ((System.Drawing.Image)(resources.GetObject("btnSiguienteC.Image")));
            this.btnSiguienteC.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSiguienteC.Name = "btnSiguienteC";
            this.btnSiguienteC.ShowDropDownArrow = false;
            this.btnSiguienteC.Size = new System.Drawing.Size(20, 20);
            this.btnSiguienteC.Text = "Siguiente";
            this.btnSiguienteC.Click += new System.EventHandler(this.btnSiguienteC_Click);
            // 
            // btnFinC
            // 
            this.btnFinC.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFinC.Image = ((System.Drawing.Image)(resources.GetObject("btnFinC.Image")));
            this.btnFinC.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFinC.Name = "btnFinC";
            this.btnFinC.ShowDropDownArrow = false;
            this.btnFinC.Size = new System.Drawing.Size(20, 20);
            this.btnFinC.Text = "Fin";
            this.btnFinC.Click += new System.EventHandler(this.btnFinC_Click);
            // 
            // gbInformacion
            // 
            this.gbInformacion.Controls.Add(this.lblPesosSaldo);
            this.gbInformacion.Controls.Add(this.lblSaldo);
            this.gbInformacion.Controls.Add(this.txtSaldo);
            this.gbInformacion.Location = new System.Drawing.Point(7, 447);
            this.gbInformacion.Name = "gbInformacion";
            this.gbInformacion.Size = new System.Drawing.Size(408, 54);
            this.gbInformacion.TabIndex = 4;
            this.gbInformacion.TabStop = false;
            this.gbInformacion.Text = "Información General";
            // 
            // lblPesosSaldo
            // 
            this.lblPesosSaldo.AutoSize = true;
            this.lblPesosSaldo.Location = new System.Drawing.Point(170, 23);
            this.lblPesosSaldo.Name = "lblPesosSaldo";
            this.lblPesosSaldo.Size = new System.Drawing.Size(15, 16);
            this.lblPesosSaldo.TabIndex = 6;
            this.lblPesosSaldo.Text = "$";
            // 
            // lblSaldo
            // 
            this.lblSaldo.AutoSize = true;
            this.lblSaldo.Location = new System.Drawing.Point(26, 24);
            this.lblSaldo.Name = "lblSaldo";
            this.lblSaldo.Size = new System.Drawing.Size(84, 16);
            this.lblSaldo.TabIndex = 5;
            this.lblSaldo.Text = "Saldo Actual";
            // 
            // txtSaldo
            // 
            this.txtSaldo.BackColor = System.Drawing.Color.PaleTurquoise;
            this.txtSaldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.txtSaldo.Location = new System.Drawing.Point(188, 18);
            this.txtSaldo.Name = "txtSaldo";
            this.txtSaldo.ReadOnly = true;
            this.txtSaldo.Size = new System.Drawing.Size(197, 27);
            this.txtSaldo.TabIndex = 0;
            this.txtSaldo.Text = "0";
            this.txtSaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // FrmAdelanto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(839, 522);
            this.Controls.Add(this.tsMenu);
            this.Controls.Add(this.gbCliente);
            this.Controls.Add(this.gbAdelantos);
            this.Controls.Add(this.gbCanje);
            this.Controls.Add(this.gbInformacion);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAdelanto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Anticipos de Cliente";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmAdelanto_FormClosing);
            this.Load += new System.EventHandler(this.FrmAdelanto_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmAdelanto_KeyDown);
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.gbCliente.ResumeLayout(false);
            this.gbCliente.PerformLayout();
            this.gbAdelantos.ResumeLayout(false);
            this.gbAdelantos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdelantos)).EndInit();
            this.StatusSaldo.ResumeLayout(false);
            this.StatusSaldo.PerformLayout();
            this.gbCanje.ResumeLayout(false);
            this.gbCanje.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCanje)).EndInit();
            this.StatusCanje.ResumeLayout(false);
            this.StatusCanje.PerformLayout();
            this.gbInformacion.ResumeLayout(false);
            this.gbInformacion.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.GroupBox gbCliente;
        private System.Windows.Forms.GroupBox gbAdelantos;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Button btnBuscarCliente;
        private System.Windows.Forms.TextBox txtNombreCliente;
        private System.Windows.Forms.StatusStrip StatusSaldo;
        private System.Windows.Forms.ToolStripDropDownButton btnInicio;
        private System.Windows.Forms.ToolStripDropDownButton btnAnterior;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusSaldo;
        private System.Windows.Forms.ToolStripDropDownButton btnSiguiente;
        private System.Windows.Forms.ToolStripDropDownButton btnFin;
        private System.Windows.Forms.DataGridView dgvAdelantos;
        private System.Windows.Forms.GroupBox gbCanje;
        private System.Windows.Forms.DataGridView dgvCanje;
        private System.Windows.Forms.StatusStrip StatusCanje;
        private System.Windows.Forms.ToolStripDropDownButton btnInicioC;
        private System.Windows.Forms.ToolStripDropDownButton btnAnteriorC;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusCanje;
        private System.Windows.Forms.ToolStripDropDownButton btnSiguienteC;
        private System.Windows.Forms.ToolStripDropDownButton btnFinC;
        private System.Windows.Forms.GroupBox gbInformacion;
        private System.Windows.Forms.TextBox txtSaldo;
        private System.Windows.Forms.Label lblSaldo;
        private System.Windows.Forms.Label lblPesosSaldo;
        private System.Windows.Forms.ToolStripButton tsBtnSalir;
        private System.Windows.Forms.ToolStripButton tsBtnNuevo;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaC;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorC;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaldoC;
        private System.Windows.Forms.ToolStripButton tsBtnRetirarSaldo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Saldo;
        private System.Windows.Forms.ToolStripButton tsBtnCopia;
    }
}