namespace Aplicacion.Compras.Egreso
{
    partial class FrmEditarEgreso
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEditarEgreso));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbCuentas = new System.Windows.Forms.GroupBox();
            this.lblPesosRetencion = new System.Windows.Forms.Label();
            this.txtRetencion = new System.Windows.Forms.TextBox();
            this.lblRetencion = new System.Windows.Forms.Label();
            this.lblPesosValor = new System.Windows.Forms.Label();
            this.txtValorEgreso = new System.Windows.Forms.TextBox();
            this.lblValor = new System.Windows.Forms.Label();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvEgreso = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Concepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblConcepto = new System.Windows.Forms.Label();
            this.txtConcepto = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.gbFormasPago = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtTransaccion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtEfectivo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCheque = new System.Windows.Forms.TextBox();
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.tsBtnGuardar = new System.Windows.Forms.ToolStripButton();
            this.tsBtnSalir = new System.Windows.Forms.ToolStripButton();
            this.gbBeneficiario = new System.Windows.Forms.GroupBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.btnBuscarBeneficiario = new System.Windows.Forms.Button();
            this.txtNit = new System.Windows.Forms.TextBox();
            this.lblBeneficiario = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblComprobante = new System.Windows.Forms.Label();
            this.lblNumero = new System.Windows.Forms.Label();
            this.gbEgreso = new System.Windows.Forms.GroupBox();
            this.gbCuentas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEgreso)).BeginInit();
            this.gbFormasPago.SuspendLayout();
            this.tsMenu.SuspendLayout();
            this.gbBeneficiario.SuspendLayout();
            this.panel1.SuspendLayout();
            this.gbEgreso.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbCuentas
            // 
            this.gbCuentas.Controls.Add(this.lblPesosRetencion);
            this.gbCuentas.Controls.Add(this.txtRetencion);
            this.gbCuentas.Controls.Add(this.lblRetencion);
            this.gbCuentas.Controls.Add(this.lblPesosValor);
            this.gbCuentas.Controls.Add(this.txtValorEgreso);
            this.gbCuentas.Controls.Add(this.lblValor);
            this.gbCuentas.Controls.Add(this.btnEliminar);
            this.gbCuentas.Controls.Add(this.label6);
            this.gbCuentas.Controls.Add(this.dgvEgreso);
            this.gbCuentas.Controls.Add(this.txtTotal);
            this.gbCuentas.Controls.Add(this.btnAgregar);
            this.gbCuentas.Controls.Add(this.txtValor);
            this.gbCuentas.Controls.Add(this.label1);
            this.gbCuentas.Controls.Add(this.label7);
            this.gbCuentas.Controls.Add(this.lblConcepto);
            this.gbCuentas.Controls.Add(this.txtConcepto);
            this.gbCuentas.Location = new System.Drawing.Point(13, 195);
            this.gbCuentas.Name = "gbCuentas";
            this.gbCuentas.Size = new System.Drawing.Size(721, 237);
            this.gbCuentas.TabIndex = 3;
            this.gbCuentas.TabStop = false;
            // 
            // lblPesosRetencion
            // 
            this.lblPesosRetencion.AutoSize = true;
            this.lblPesosRetencion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblPesosRetencion.Location = new System.Drawing.Point(331, 213);
            this.lblPesosRetencion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPesosRetencion.Name = "lblPesosRetencion";
            this.lblPesosRetencion.Size = new System.Drawing.Size(16, 17);
            this.lblPesosRetencion.TabIndex = 17;
            this.lblPesosRetencion.Text = "$";
            // 
            // txtRetencion
            // 
            this.txtRetencion.BackColor = System.Drawing.Color.PaleTurquoise;
            this.txtRetencion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRetencion.Location = new System.Drawing.Point(348, 210);
            this.txtRetencion.Name = "txtRetencion";
            this.txtRetencion.ReadOnly = true;
            this.txtRetencion.Size = new System.Drawing.Size(97, 20);
            this.txtRetencion.TabIndex = 18;
            this.txtRetencion.Text = "0";
            this.txtRetencion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblRetencion
            // 
            this.lblRetencion.AutoSize = true;
            this.lblRetencion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblRetencion.Location = new System.Drawing.Point(224, 213);
            this.lblRetencion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRetencion.Name = "lblRetencion";
            this.lblRetencion.Size = new System.Drawing.Size(100, 17);
            this.lblRetencion.TabIndex = 16;
            this.lblRetencion.Text = "RETENCIÓN : ";
            // 
            // lblPesosValor
            // 
            this.lblPesosValor.AutoSize = true;
            this.lblPesosValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblPesosValor.Location = new System.Drawing.Point(76, 213);
            this.lblPesosValor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPesosValor.Name = "lblPesosValor";
            this.lblPesosValor.Size = new System.Drawing.Size(16, 17);
            this.lblPesosValor.TabIndex = 14;
            this.lblPesosValor.Text = "$";
            // 
            // txtValorEgreso
            // 
            this.txtValorEgreso.BackColor = System.Drawing.Color.PaleTurquoise;
            this.txtValorEgreso.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValorEgreso.Location = new System.Drawing.Point(93, 210);
            this.txtValorEgreso.Name = "txtValorEgreso";
            this.txtValorEgreso.ReadOnly = true;
            this.txtValorEgreso.Size = new System.Drawing.Size(99, 20);
            this.txtValorEgreso.TabIndex = 15;
            this.txtValorEgreso.Text = "0";
            this.txtValorEgreso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblValor
            // 
            this.lblValor.AutoSize = true;
            this.lblValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblValor.Location = new System.Drawing.Point(7, 213);
            this.lblValor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(67, 17);
            this.lblValor.TabIndex = 13;
            this.lblValor.Text = "VALOR : ";
            // 
            // btnEliminar
            // 
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.Location = new System.Drawing.Point(685, 45);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(24, 24);
            this.btnEliminar.TabIndex = 12;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label6.Location = new System.Drawing.Point(543, 213);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(16, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "$";
            // 
            // dgvEgreso
            // 
            this.dgvEgreso.AllowUserToAddRows = false;
            this.dgvEgreso.AllowUserToDeleteRows = false;
            this.dgvEgreso.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEgreso.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvEgreso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEgreso.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Codigo,
            this.Concepto,
            this.Valor});
            this.dgvEgreso.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvEgreso.Location = new System.Drawing.Point(8, 45);
            this.dgvEgreso.Name = "dgvEgreso";
            this.dgvEgreso.Size = new System.Drawing.Size(676, 163);
            this.dgvEgreso.TabIndex = 8;
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Codigo.DefaultCellStyle = dataGridViewCellStyle2;
            this.Codigo.HeaderText = "Código PUC";
            this.Codigo.Name = "Codigo";
            this.Codigo.Visible = false;
            this.Codigo.Width = 120;
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.Valor.DefaultCellStyle = dataGridViewCellStyle3;
            this.Valor.HeaderText = "Valor";
            this.Valor.Name = "Valor";
            this.Valor.Width = 150;
            // 
            // txtTotal
            // 
            this.txtTotal.BackColor = System.Drawing.Color.PaleTurquoise;
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(560, 210);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(125, 20);
            this.txtTotal.TabIndex = 11;
            this.txtTotal.Text = "0";
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregar.Image")));
            this.btnAgregar.Location = new System.Drawing.Point(685, 15);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(24, 24);
            this.btnAgregar.TabIndex = 4;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(579, 17);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(100, 22);
            this.txtValor.TabIndex = 2;
            this.txtValor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValor_KeyPress);
            this.txtValor.Validating += new System.ComponentModel.CancelEventHandler(this.txtValor_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(474, 213);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "TOTAL : ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(536, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 16);
            this.label7.TabIndex = 7;
            this.label7.Text = "Valor";
            // 
            // lblConcepto
            // 
            this.lblConcepto.AutoSize = true;
            this.lblConcepto.Location = new System.Drawing.Point(12, 20);
            this.lblConcepto.Name = "lblConcepto";
            this.lblConcepto.Size = new System.Drawing.Size(66, 16);
            this.lblConcepto.TabIndex = 6;
            this.lblConcepto.Text = "Concepto";
            // 
            // txtConcepto
            // 
            this.txtConcepto.Location = new System.Drawing.Point(96, 17);
            this.txtConcepto.Name = "txtConcepto";
            this.txtConcepto.Size = new System.Drawing.Size(418, 22);
            this.txtConcepto.TabIndex = 1;
            this.txtConcepto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtConcepto_KeyPress);
            this.txtConcepto.Validating += new System.ComponentModel.CancelEventHandler(this.txtConcepto_Validating);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(244, 44);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(27, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(144, 45);
            this.txtCodigo.MaxLength = 6;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(100, 22);
            this.txtCodigo.TabIndex = 0;
            this.txtCodigo.Visible = false;
            this.txtCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigo_KeyPress);
            this.txtCodigo.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodigo_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(58, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = "Código PUC";
            this.label5.Visible = false;
            // 
            // gbFormasPago
            // 
            this.gbFormasPago.Controls.Add(this.label4);
            this.gbFormasPago.Controls.Add(this.label10);
            this.gbFormasPago.Controls.Add(this.txtTransaccion);
            this.gbFormasPago.Controls.Add(this.label2);
            this.gbFormasPago.Controls.Add(this.label8);
            this.gbFormasPago.Controls.Add(this.txtEfectivo);
            this.gbFormasPago.Controls.Add(this.label9);
            this.gbFormasPago.Controls.Add(this.label3);
            this.gbFormasPago.Controls.Add(this.txtCheque);
            this.gbFormasPago.Location = new System.Drawing.Point(14, 437);
            this.gbFormasPago.Name = "gbFormasPago";
            this.gbFormasPago.Size = new System.Drawing.Size(721, 64);
            this.gbFormasPago.TabIndex = 4;
            this.gbFormasPago.TabStop = false;
            this.gbFormasPago.Text = "Formas de Pago";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.label4.Location = new System.Drawing.Point(585, 28);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "$";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.label10.Location = new System.Drawing.Point(474, 28);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(111, 16);
            this.label10.TabIndex = 7;
            this.label10.Text = "TRANSACCIÓN: ";
            // 
            // txtTransaccion
            // 
            this.txtTransaccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTransaccion.Location = new System.Drawing.Point(604, 25);
            this.txtTransaccion.Name = "txtTransaccion";
            this.txtTransaccion.Size = new System.Drawing.Size(100, 20);
            this.txtTransaccion.TabIndex = 6;
            this.txtTransaccion.Text = "0";
            this.txtTransaccion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTransaccion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTransaccion_KeyPress);
            this.txtTransaccion.Validating += new System.ComponentModel.CancelEventHandler(this.txtTransaccion_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.label2.Location = new System.Drawing.Point(7, 28);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "EFECTIVO: ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.label8.Location = new System.Drawing.Point(86, 28);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(15, 16);
            this.label8.TabIndex = 3;
            this.label8.Text = "$";
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
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.label9.Location = new System.Drawing.Point(318, 28);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(15, 16);
            this.label9.TabIndex = 5;
            this.label9.Text = "$";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.label3.Location = new System.Drawing.Point(240, 28);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "CHEQUE: ";
            // 
            // txtCheque
            // 
            this.txtCheque.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCheque.Location = new System.Drawing.Point(337, 25);
            this.txtCheque.Name = "txtCheque";
            this.txtCheque.Size = new System.Drawing.Size(100, 20);
            this.txtCheque.TabIndex = 1;
            this.txtCheque.Text = "0";
            this.txtCheque.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCheque.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCheque_KeyPress);
            this.txtCheque.Validating += new System.ComponentModel.CancelEventHandler(this.txtCheque_Validating);
            // 
            // tsMenu
            // 
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnGuardar,
            this.tsBtnSalir});
            this.tsMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(747, 25);
            this.tsMenu.TabIndex = 0;
            this.tsMenu.Text = "toolStrip1";
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
            this.gbBeneficiario.Controls.Add(this.txtNombre);
            this.gbBeneficiario.Controls.Add(this.btnBuscarBeneficiario);
            this.gbBeneficiario.Controls.Add(this.txtNit);
            this.gbBeneficiario.Controls.Add(this.lblBeneficiario);
            this.gbBeneficiario.Location = new System.Drawing.Point(13, 93);
            this.gbBeneficiario.Name = "gbBeneficiario";
            this.gbBeneficiario.Size = new System.Drawing.Size(721, 64);
            this.gbBeneficiario.TabIndex = 2;
            this.gbBeneficiario.TabStop = false;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(286, 25);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.ReadOnly = true;
            this.txtNombre.Size = new System.Drawing.Size(417, 22);
            this.txtNombre.TabIndex = 6;
            // 
            // btnBuscarBeneficiario
            // 
            this.btnBuscarBeneficiario.Location = new System.Drawing.Point(255, 24);
            this.btnBuscarBeneficiario.Name = "btnBuscarBeneficiario";
            this.btnBuscarBeneficiario.Size = new System.Drawing.Size(25, 24);
            this.btnBuscarBeneficiario.TabIndex = 1;
            this.btnBuscarBeneficiario.Text = "...";
            this.btnBuscarBeneficiario.UseVisualStyleBackColor = true;
            this.btnBuscarBeneficiario.Click += new System.EventHandler(this.btnBuscarBeneficiario_Click);
            // 
            // txtNit
            // 
            this.txtNit.Location = new System.Drawing.Point(96, 25);
            this.txtNit.Name = "txtNit";
            this.txtNit.Size = new System.Drawing.Size(153, 22);
            this.txtNit.TabIndex = 0;
            this.txtNit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNit_KeyPress);
            // 
            // lblBeneficiario
            // 
            this.lblBeneficiario.AutoSize = true;
            this.lblBeneficiario.Location = new System.Drawing.Point(12, 28);
            this.lblBeneficiario.Name = "lblBeneficiario";
            this.lblBeneficiario.Size = new System.Drawing.Size(56, 16);
            this.lblBeneficiario.TabIndex = 3;
            this.lblBeneficiario.Text = "Tercero";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblFecha.Location = new System.Drawing.Point(6, 30);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(54, 20);
            this.lblFecha.TabIndex = 0;
            this.lblFecha.Text = "Fecha";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.Controls.Add(this.lblComprobante);
            this.panel1.Controls.Add(this.lblNumero);
            this.panel1.Location = new System.Drawing.Point(277, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(425, 45);
            this.panel1.TabIndex = 1;
            // 
            // lblComprobante
            // 
            this.lblComprobante.AutoSize = true;
            this.lblComprobante.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.lblComprobante.Location = new System.Drawing.Point(3, 11);
            this.lblComprobante.Name = "lblComprobante";
            this.lblComprobante.Size = new System.Drawing.Size(296, 22);
            this.lblComprobante.TabIndex = 0;
            this.lblComprobante.Text = "COMPROBANTE DE EGRESO No.";
            // 
            // lblNumero
            // 
            this.lblNumero.AutoSize = true;
            this.lblNumero.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.lblNumero.Location = new System.Drawing.Point(302, 11);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(20, 22);
            this.lblNumero.TabIndex = 1;
            this.lblNumero.Text = "0";
            // 
            // gbEgreso
            // 
            this.gbEgreso.Controls.Add(this.lblFecha);
            this.gbEgreso.Controls.Add(this.panel1);
            this.gbEgreso.Controls.Add(this.button1);
            this.gbEgreso.Controls.Add(this.label5);
            this.gbEgreso.Controls.Add(this.txtCodigo);
            this.gbEgreso.Location = new System.Drawing.Point(13, 28);
            this.gbEgreso.Name = "gbEgreso";
            this.gbEgreso.Size = new System.Drawing.Size(721, 73);
            this.gbEgreso.TabIndex = 1;
            this.gbEgreso.TabStop = false;
            this.gbEgreso.Text = "Datos de Egreso";
            // 
            // FrmEditarEgreso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(747, 509);
            this.Controls.Add(this.gbEgreso);
            this.Controls.Add(this.gbBeneficiario);
            this.Controls.Add(this.tsMenu);
            this.Controls.Add(this.gbFormasPago);
            this.Controls.Add(this.gbCuentas);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmEditarEgreso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Egreso";
            this.Load += new System.EventHandler(this.FrmEgreso_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmEgreso_KeyDown);
            this.gbCuentas.ResumeLayout(false);
            this.gbCuentas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEgreso)).EndInit();
            this.gbFormasPago.ResumeLayout(false);
            this.gbFormasPago.PerformLayout();
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.gbBeneficiario.ResumeLayout(false);
            this.gbBeneficiario.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gbEgreso.ResumeLayout(false);
            this.gbEgreso.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbCuentas;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvEgreso;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblConcepto;
        private System.Windows.Forms.TextBox txtConcepto;
        private System.Windows.Forms.GroupBox gbFormasPago;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtEfectivo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCheque;
        private System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.GroupBox gbBeneficiario;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblComprobante;
        private System.Windows.Forms.Label lblNumero;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.ToolStripButton tsBtnGuardar;
        private System.Windows.Forms.ToolStripButton tsBtnSalir;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.GroupBox gbEgreso;
        private System.Windows.Forms.Label lblBeneficiario;
        private System.Windows.Forms.TextBox txtNit;
        private System.Windows.Forms.Button btnBuscarBeneficiario;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Concepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valor;
        private System.Windows.Forms.Label lblPesosRetencion;
        public System.Windows.Forms.TextBox txtRetencion;
        private System.Windows.Forms.Label lblRetencion;
        private System.Windows.Forms.Label lblPesosValor;
        public System.Windows.Forms.TextBox txtValorEgreso;
        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtTransaccion;

    }
}