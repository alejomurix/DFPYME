namespace Aplicacion.Compras.Anticipos
{
    partial class FrmAnticipo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAnticipo));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.tsBtnGuardar = new System.Windows.Forms.ToolStripButton();
            this.tsBtnSalir = new System.Windows.Forms.ToolStripButton();
            this.gbBeneficiario = new System.Windows.Forms.GroupBox();
            this.txtTercero = new System.Windows.Forms.TextBox();
            this.btnBuscarTercero = new System.Windows.Forms.Button();
            this.txtNit = new System.Windows.Forms.TextBox();
            this.lblTercero = new System.Windows.Forms.Label();
            this.gbDatosAnticipo = new System.Windows.Forms.GroupBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblDataFecha = new System.Windows.Forms.Label();
            this.lblCuenta = new System.Windows.Forms.Label();
            this.cbCuentas = new System.Windows.Forms.ComboBox();
            this.gbConceptos = new System.Windows.Forms.GroupBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.dgvConceptos = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Concepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.lblValor = new System.Windows.Forms.Label();
            this.lblConcepto = new System.Windows.Forms.Label();
            this.txtConcepto = new System.Windows.Forms.TextBox();
            this.gbFormasPago = new System.Windows.Forms.GroupBox();
            this.lblPesosTransaccion = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtTransaccion = new System.Windows.Forms.TextBox();
            this.lblEfectivo = new System.Windows.Forms.Label();
            this.lblPesosEfectivo = new System.Windows.Forms.Label();
            this.txtEfectivo = new System.Windows.Forms.TextBox();
            this.lblPesosCheque = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCheque = new System.Windows.Forms.TextBox();
            this.tsMenu.SuspendLayout();
            this.gbBeneficiario.SuspendLayout();
            this.gbDatosAnticipo.SuspendLayout();
            this.gbConceptos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConceptos)).BeginInit();
            this.gbFormasPago.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMenu
            // 
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnGuardar,
            this.tsBtnSalir});
            this.tsMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(721, 25);
            this.tsMenu.TabIndex = 1;
            this.tsMenu.Text = "Menu";
            // 
            // tsBtnGuardar
            // 
            this.tsBtnGuardar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsBtnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnGuardar.Image")));
            this.tsBtnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnGuardar.Name = "tsBtnGuardar";
            this.tsBtnGuardar.Size = new System.Drawing.Size(101, 22);
            this.tsBtnGuardar.Text = "Guardar [F2]";
            this.tsBtnGuardar.Click += new System.EventHandler(this.tsBtnGuardar_Click);
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
            // gbBeneficiario
            // 
            this.gbBeneficiario.Controls.Add(this.txtTercero);
            this.gbBeneficiario.Controls.Add(this.btnBuscarTercero);
            this.gbBeneficiario.Controls.Add(this.txtNit);
            this.gbBeneficiario.Controls.Add(this.lblTercero);
            this.gbBeneficiario.Location = new System.Drawing.Point(9, 32);
            this.gbBeneficiario.Name = "gbBeneficiario";
            this.gbBeneficiario.Size = new System.Drawing.Size(697, 67);
            this.gbBeneficiario.TabIndex = 3;
            this.gbBeneficiario.TabStop = false;
            // 
            // txtTercero
            // 
            this.txtTercero.Location = new System.Drawing.Point(291, 25);
            this.txtTercero.Name = "txtTercero";
            this.txtTercero.ReadOnly = true;
            this.txtTercero.Size = new System.Drawing.Size(391, 22);
            this.txtTercero.TabIndex = 6;
            // 
            // btnBuscarTercero
            // 
            this.btnBuscarTercero.Location = new System.Drawing.Point(248, 24);
            this.btnBuscarTercero.Name = "btnBuscarTercero";
            this.btnBuscarTercero.Size = new System.Drawing.Size(25, 24);
            this.btnBuscarTercero.TabIndex = 1;
            this.btnBuscarTercero.Text = "...";
            this.btnBuscarTercero.UseVisualStyleBackColor = true;
            this.btnBuscarTercero.Click += new System.EventHandler(this.btnBuscarTercero_Click);
            // 
            // txtNit
            // 
            this.txtNit.Location = new System.Drawing.Point(71, 25);
            this.txtNit.Name = "txtNit";
            this.txtNit.Size = new System.Drawing.Size(171, 22);
            this.txtNit.TabIndex = 0;
            this.txtNit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNit_KeyPress);
            // 
            // lblTercero
            // 
            this.lblTercero.AutoSize = true;
            this.lblTercero.Location = new System.Drawing.Point(12, 28);
            this.lblTercero.Name = "lblTercero";
            this.lblTercero.Size = new System.Drawing.Size(56, 16);
            this.lblTercero.TabIndex = 3;
            this.lblTercero.Text = "Tercero";
            // 
            // gbDatosAnticipo
            // 
            this.gbDatosAnticipo.Controls.Add(this.lblFecha);
            this.gbDatosAnticipo.Controls.Add(this.lblDataFecha);
            this.gbDatosAnticipo.Controls.Add(this.lblCuenta);
            this.gbDatosAnticipo.Controls.Add(this.cbCuentas);
            this.gbDatosAnticipo.Location = new System.Drawing.Point(9, 101);
            this.gbDatosAnticipo.Name = "gbDatosAnticipo";
            this.gbDatosAnticipo.Size = new System.Drawing.Size(697, 62);
            this.gbDatosAnticipo.TabIndex = 4;
            this.gbDatosAnticipo.TabStop = false;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(12, 24);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(46, 16);
            this.lblFecha.TabIndex = 10;
            this.lblFecha.Text = "Fecha";
            // 
            // lblDataFecha
            // 
            this.lblDataFecha.AutoSize = true;
            this.lblDataFecha.Location = new System.Drawing.Point(68, 24);
            this.lblDataFecha.Name = "lblDataFecha";
            this.lblDataFecha.Size = new System.Drawing.Size(11, 16);
            this.lblDataFecha.TabIndex = 9;
            this.lblDataFecha.Text = ".";
            // 
            // lblCuenta
            // 
            this.lblCuenta.AutoSize = true;
            this.lblCuenta.Location = new System.Drawing.Point(288, 24);
            this.lblCuenta.Name = "lblCuenta";
            this.lblCuenta.Size = new System.Drawing.Size(50, 16);
            this.lblCuenta.TabIndex = 8;
            this.lblCuenta.Text = "Cuenta";
            this.lblCuenta.Visible = false;
            // 
            // cbCuentas
            // 
            this.cbCuentas.DisplayMember = "Nombre";
            this.cbCuentas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCuentas.FormattingEnabled = true;
            this.cbCuentas.Location = new System.Drawing.Point(352, 21);
            this.cbCuentas.Name = "cbCuentas";
            this.cbCuentas.Size = new System.Drawing.Size(213, 24);
            this.cbCuentas.TabIndex = 7;
            this.cbCuentas.ValueMember = "Id";
            this.cbCuentas.Visible = false;
            this.cbCuentas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbCuentas_KeyPress);
            // 
            // gbConceptos
            // 
            this.gbConceptos.Controls.Add(this.lblTotal);
            this.gbConceptos.Controls.Add(this.txtTotal);
            this.gbConceptos.Controls.Add(this.btnEliminar);
            this.gbConceptos.Controls.Add(this.dgvConceptos);
            this.gbConceptos.Controls.Add(this.btnAgregar);
            this.gbConceptos.Controls.Add(this.txtValor);
            this.gbConceptos.Controls.Add(this.lblValor);
            this.gbConceptos.Controls.Add(this.lblConcepto);
            this.gbConceptos.Controls.Add(this.txtConcepto);
            this.gbConceptos.Location = new System.Drawing.Point(9, 165);
            this.gbConceptos.Name = "gbConceptos";
            this.gbConceptos.Size = new System.Drawing.Size(697, 244);
            this.gbConceptos.TabIndex = 5;
            this.gbConceptos.TabStop = false;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(428, 212);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(61, 16);
            this.lblTotal.TabIndex = 24;
            this.lblTotal.Text = "TOTAL:";
            // 
            // txtTotal
            // 
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(493, 209);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(155, 22);
            this.txtTotal.TabIndex = 23;
            this.txtTotal.Text = "0";
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.Location = new System.Drawing.Point(649, 45);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(24, 24);
            this.btnEliminar.TabIndex = 12;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // dgvConceptos
            // 
            this.dgvConceptos.AllowUserToAddRows = false;
            this.dgvConceptos.AllowUserToDeleteRows = false;
            this.dgvConceptos.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvConceptos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvConceptos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConceptos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Concepto,
            this.Valor});
            this.dgvConceptos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvConceptos.Location = new System.Drawing.Point(8, 45);
            this.dgvConceptos.Name = "dgvConceptos";
            this.dgvConceptos.RowHeadersVisible = false;
            this.dgvConceptos.Size = new System.Drawing.Size(640, 163);
            this.dgvConceptos.TabIndex = 8;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // Concepto
            // 
            this.Concepto.DataPropertyName = "Concepto";
            this.Concepto.HeaderText = "Concepto";
            this.Concepto.Name = "Concepto";
            this.Concepto.Width = 482;
            // 
            // Valor
            // 
            this.Valor.DataPropertyName = "Valor";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.Valor.DefaultCellStyle = dataGridViewCellStyle2;
            this.Valor.HeaderText = "Valor";
            this.Valor.Name = "Valor";
            this.Valor.Width = 150;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregar.Image")));
            this.btnAgregar.Location = new System.Drawing.Point(649, 15);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(24, 24);
            this.btnAgregar.TabIndex = 4;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(541, 17);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(100, 22);
            this.txtValor.TabIndex = 2;
            this.txtValor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValor_KeyPress);
            this.txtValor.Validating += new System.ComponentModel.CancelEventHandler(this.txtValor_Validating);
            // 
            // lblValor
            // 
            this.lblValor.AutoSize = true;
            this.lblValor.Location = new System.Drawing.Point(498, 20);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(40, 16);
            this.lblValor.TabIndex = 7;
            this.lblValor.Text = "Valor";
            // 
            // lblConcepto
            // 
            this.lblConcepto.AutoSize = true;
            this.lblConcepto.Location = new System.Drawing.Point(11, 20);
            this.lblConcepto.Name = "lblConcepto";
            this.lblConcepto.Size = new System.Drawing.Size(66, 16);
            this.lblConcepto.TabIndex = 6;
            this.lblConcepto.Text = "Concepto";
            // 
            // txtConcepto
            // 
            this.txtConcepto.Location = new System.Drawing.Point(81, 17);
            this.txtConcepto.Name = "txtConcepto";
            this.txtConcepto.Size = new System.Drawing.Size(401, 22);
            this.txtConcepto.TabIndex = 1;
            this.txtConcepto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtConcepto_KeyPress);
            this.txtConcepto.Validating += new System.ComponentModel.CancelEventHandler(this.txtConcepto_Validating);
            // 
            // gbFormasPago
            // 
            this.gbFormasPago.Controls.Add(this.lblPesosTransaccion);
            this.gbFormasPago.Controls.Add(this.label10);
            this.gbFormasPago.Controls.Add(this.txtTransaccion);
            this.gbFormasPago.Controls.Add(this.lblEfectivo);
            this.gbFormasPago.Controls.Add(this.lblPesosEfectivo);
            this.gbFormasPago.Controls.Add(this.txtEfectivo);
            this.gbFormasPago.Controls.Add(this.lblPesosCheque);
            this.gbFormasPago.Controls.Add(this.label3);
            this.gbFormasPago.Controls.Add(this.txtCheque);
            this.gbFormasPago.Location = new System.Drawing.Point(9, 415);
            this.gbFormasPago.Name = "gbFormasPago";
            this.gbFormasPago.Size = new System.Drawing.Size(697, 64);
            this.gbFormasPago.TabIndex = 6;
            this.gbFormasPago.TabStop = false;
            this.gbFormasPago.Text = "Formas de Pago";
            // 
            // lblPesosTransaccion
            // 
            this.lblPesosTransaccion.AutoSize = true;
            this.lblPesosTransaccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblPesosTransaccion.Location = new System.Drawing.Point(563, 28);
            this.lblPesosTransaccion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPesosTransaccion.Name = "lblPesosTransaccion";
            this.lblPesosTransaccion.Size = new System.Drawing.Size(15, 16);
            this.lblPesosTransaccion.TabIndex = 8;
            this.lblPesosTransaccion.Text = "$";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.label10.Location = new System.Drawing.Point(452, 28);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(111, 16);
            this.label10.TabIndex = 7;
            this.label10.Text = "TRANSACCIÓN: ";
            // 
            // txtTransaccion
            // 
            this.txtTransaccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTransaccion.Location = new System.Drawing.Point(582, 25);
            this.txtTransaccion.Name = "txtTransaccion";
            this.txtTransaccion.Size = new System.Drawing.Size(100, 20);
            this.txtTransaccion.TabIndex = 6;
            this.txtTransaccion.Text = "0";
            this.txtTransaccion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTransaccion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTransaccion_KeyPress);
            this.txtTransaccion.Validating += new System.ComponentModel.CancelEventHandler(this.txtTransaccion_Validating);
            // 
            // lblEfectivo
            // 
            this.lblEfectivo.AutoSize = true;
            this.lblEfectivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblEfectivo.Location = new System.Drawing.Point(7, 28);
            this.lblEfectivo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEfectivo.Name = "lblEfectivo";
            this.lblEfectivo.Size = new System.Drawing.Size(80, 16);
            this.lblEfectivo.TabIndex = 2;
            this.lblEfectivo.Text = "EFECTIVO: ";
            // 
            // lblPesosEfectivo
            // 
            this.lblPesosEfectivo.AutoSize = true;
            this.lblPesosEfectivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblPesosEfectivo.Location = new System.Drawing.Point(86, 28);
            this.lblPesosEfectivo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPesosEfectivo.Name = "lblPesosEfectivo";
            this.lblPesosEfectivo.Size = new System.Drawing.Size(15, 16);
            this.lblPesosEfectivo.TabIndex = 3;
            this.lblPesosEfectivo.Text = "$";
            // 
            // txtEfectivo
            // 
            this.txtEfectivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEfectivo.Location = new System.Drawing.Point(105, 25);
            this.txtEfectivo.Name = "txtEfectivo";
            this.txtEfectivo.Size = new System.Drawing.Size(100, 20);
            this.txtEfectivo.TabIndex = 0;
            this.txtEfectivo.Text = "0";
            this.txtEfectivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtEfectivo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEfectivo_KeyPress);
            this.txtEfectivo.Validating += new System.ComponentModel.CancelEventHandler(this.txtEfectivo_Validating);
            // 
            // lblPesosCheque
            // 
            this.lblPesosCheque.AutoSize = true;
            this.lblPesosCheque.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblPesosCheque.Location = new System.Drawing.Point(309, 28);
            this.lblPesosCheque.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPesosCheque.Name = "lblPesosCheque";
            this.lblPesosCheque.Size = new System.Drawing.Size(15, 16);
            this.lblPesosCheque.TabIndex = 5;
            this.lblPesosCheque.Text = "$";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.label3.Location = new System.Drawing.Point(231, 28);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "CHEQUE: ";
            // 
            // txtCheque
            // 
            this.txtCheque.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCheque.Location = new System.Drawing.Point(328, 25);
            this.txtCheque.Name = "txtCheque";
            this.txtCheque.Size = new System.Drawing.Size(100, 20);
            this.txtCheque.TabIndex = 1;
            this.txtCheque.Text = "0";
            this.txtCheque.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCheque.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCheque_KeyPress);
            this.txtCheque.Validating += new System.ComponentModel.CancelEventHandler(this.txtCheque_Validating);
            // 
            // FrmAnticipo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(721, 493);
            this.Controls.Add(this.gbFormasPago);
            this.Controls.Add(this.gbConceptos);
            this.Controls.Add(this.gbDatosAnticipo);
            this.Controls.Add(this.gbBeneficiario);
            this.Controls.Add(this.tsMenu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAnticipo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Anticipos";
            this.Load += new System.EventHandler(this.FrmAnticipo_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmAnticipo_KeyDown);
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.gbBeneficiario.ResumeLayout(false);
            this.gbBeneficiario.PerformLayout();
            this.gbDatosAnticipo.ResumeLayout(false);
            this.gbDatosAnticipo.PerformLayout();
            this.gbConceptos.ResumeLayout(false);
            this.gbConceptos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConceptos)).EndInit();
            this.gbFormasPago.ResumeLayout(false);
            this.gbFormasPago.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.ToolStripButton tsBtnGuardar;
        private System.Windows.Forms.ToolStripButton tsBtnSalir;
        private System.Windows.Forms.GroupBox gbBeneficiario;
        private System.Windows.Forms.TextBox txtTercero;
        private System.Windows.Forms.Button btnBuscarTercero;
        private System.Windows.Forms.TextBox txtNit;
        private System.Windows.Forms.Label lblTercero;
        private System.Windows.Forms.GroupBox gbDatosAnticipo;
        private System.Windows.Forms.ComboBox cbCuentas;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblDataFecha;
        private System.Windows.Forms.Label lblCuenta;
        private System.Windows.Forms.GroupBox gbConceptos;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.DataGridView dgvConceptos;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.Label lblConcepto;
        private System.Windows.Forms.TextBox txtConcepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Concepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valor;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.GroupBox gbFormasPago;
        private System.Windows.Forms.Label lblPesosTransaccion;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtTransaccion;
        private System.Windows.Forms.Label lblEfectivo;
        private System.Windows.Forms.Label lblPesosEfectivo;
        private System.Windows.Forms.TextBox txtEfectivo;
        private System.Windows.Forms.Label lblPesosCheque;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCheque;
    }
}