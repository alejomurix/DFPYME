namespace Aplicacion.Ventas.Ingresos
{
    partial class FrmConsultaOtro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConsultaOtro));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsMenuConsulta = new System.Windows.Forms.ToolStrip();
            this.tsBtnListarTodos = new System.Windows.Forms.ToolStripButton();
            this.tsBtnCopia = new System.Windows.Forms.ToolStripButton();
            this.tsBtnSalir = new System.Windows.Forms.ToolStripButton();
            this.gbCriterio = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chkAnulado = new System.Windows.Forms.CheckBox();
            this.dtpFecha1 = new System.Windows.Forms.DateTimePicker();
            this.cbFecha = new System.Windows.Forms.ComboBox();
            this.cbCriterio = new System.Windows.Forms.ComboBox();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBuscarFe = new System.Windows.Forms.Button();
            this.lblFecha = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.gbConsulta = new System.Windows.Forms.GroupBox();
            this.dgvEgreso = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdBeneficio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusCaja = new System.Windows.Forms.StatusStrip();
            this.btnInicio = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnAnterior = new System.Windows.Forms.ToolStripDropDownButton();
            this.lblStatusEgreso = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnSiguiente = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnFin = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnAnular = new System.Windows.Forms.Button();
            this.btnFormasPago = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvCuentas = new System.Windows.Forms.DataGridView();
            this.IdC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Concepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbBeneficiario = new System.Windows.Forms.GroupBox();
            this.lblNit = new System.Windows.Forms.Label();
            this.txtNit = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.tsMenuConsulta.SuspendLayout();
            this.gbCriterio.SuspendLayout();
            this.gbConsulta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEgreso)).BeginInit();
            this.StatusCaja.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuentas)).BeginInit();
            this.gbBeneficiario.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMenuConsulta
            // 
            this.tsMenuConsulta.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnListarTodos,
            this.tsBtnCopia,
            this.tsBtnSalir});
            this.tsMenuConsulta.Location = new System.Drawing.Point(0, 0);
            this.tsMenuConsulta.Name = "tsMenuConsulta";
            this.tsMenuConsulta.Size = new System.Drawing.Size(950, 25);
            this.tsMenuConsulta.TabIndex = 0;
            this.tsMenuConsulta.Text = "toolStrip1";
            // 
            // tsBtnListarTodos
            // 
            this.tsBtnListarTodos.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsBtnListarTodos.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnListarTodos.Image")));
            this.tsBtnListarTodos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnListarTodos.Name = "tsBtnListarTodos";
            this.tsBtnListarTodos.Size = new System.Drawing.Size(100, 22);
            this.tsBtnListarTodos.Text = "Listar Todos";
            this.tsBtnListarTodos.Click += new System.EventHandler(this.tsBtnListarTodos_Click);
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
            this.tsBtnSalir.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnSalir.Image")));
            this.tsBtnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnSalir.Name = "tsBtnSalir";
            this.tsBtnSalir.Size = new System.Drawing.Size(49, 22);
            this.tsBtnSalir.Text = "Salir";
            this.tsBtnSalir.Click += new System.EventHandler(this.tsBtnSalir_Click);
            // 
            // gbCriterio
            // 
            this.gbCriterio.Controls.Add(this.label3);
            this.gbCriterio.Controls.Add(this.label2);
            this.gbCriterio.Controls.Add(this.chkAnulado);
            this.gbCriterio.Controls.Add(this.dtpFecha1);
            this.gbCriterio.Controls.Add(this.cbFecha);
            this.gbCriterio.Controls.Add(this.cbCriterio);
            this.gbCriterio.Controls.Add(this.txtNumero);
            this.gbCriterio.Controls.Add(this.label1);
            this.gbCriterio.Controls.Add(this.btnBuscarFe);
            this.gbCriterio.Controls.Add(this.lblFecha);
            this.gbCriterio.Controls.Add(this.dtpFecha);
            this.gbCriterio.Location = new System.Drawing.Point(12, 37);
            this.gbCriterio.Name = "gbCriterio";
            this.gbCriterio.Size = new System.Drawing.Size(926, 67);
            this.gbCriterio.TabIndex = 1;
            this.gbCriterio.TabStop = false;
            this.gbCriterio.Text = "Criterios";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(809, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "Anulados";
            this.label3.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(809, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Incluir";
            this.label2.Visible = false;
            // 
            // chkAnulado
            // 
            this.chkAnulado.AutoSize = true;
            this.chkAnulado.Location = new System.Drawing.Point(792, 31);
            this.chkAnulado.Name = "chkAnulado";
            this.chkAnulado.Size = new System.Drawing.Size(15, 14);
            this.chkAnulado.TabIndex = 9;
            this.chkAnulado.UseVisualStyleBackColor = true;
            this.chkAnulado.Visible = false;
            // 
            // dtpFecha1
            // 
            this.dtpFecha1.Enabled = false;
            this.dtpFecha1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha1.Location = new System.Drawing.Point(668, 27);
            this.dtpFecha1.Name = "dtpFecha1";
            this.dtpFecha1.Size = new System.Drawing.Size(107, 22);
            this.dtpFecha1.TabIndex = 8;
            // 
            // cbFecha
            // 
            this.cbFecha.DisplayMember = "Nombre";
            this.cbFecha.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFecha.Enabled = false;
            this.cbFecha.FormattingEnabled = true;
            this.cbFecha.Location = new System.Drawing.Point(417, 26);
            this.cbFecha.Name = "cbFecha";
            this.cbFecha.Size = new System.Drawing.Size(121, 24);
            this.cbFecha.TabIndex = 7;
            this.cbFecha.ValueMember = "Id";
            this.cbFecha.SelectionChangeCommitted += new System.EventHandler(this.cbFecha_SelectionChangeCommitted);
            // 
            // cbCriterio
            // 
            this.cbCriterio.DisplayMember = "Nombre";
            this.cbCriterio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCriterio.FormattingEnabled = true;
            this.cbCriterio.Location = new System.Drawing.Point(16, 27);
            this.cbCriterio.Name = "cbCriterio";
            this.cbCriterio.Size = new System.Drawing.Size(121, 24);
            this.cbCriterio.TabIndex = 6;
            this.cbCriterio.ValueMember = "Id";
            this.cbCriterio.SelectionChangeCommitted += new System.EventHandler(this.cbCriterio_SelectionChangeCommitted);
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(205, 28);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(134, 22);
            this.txtNumero.TabIndex = 0;
            this.txtNumero.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumero_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(145, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Número";
            // 
            // btnBuscarFe
            // 
            this.btnBuscarFe.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscarFe.Image")));
            this.btnBuscarFe.Location = new System.Drawing.Point(892, 26);
            this.btnBuscarFe.Name = "btnBuscarFe";
            this.btnBuscarFe.Size = new System.Drawing.Size(24, 24);
            this.btnBuscarFe.TabIndex = 3;
            this.btnBuscarFe.UseVisualStyleBackColor = true;
            this.btnBuscarFe.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(366, 31);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(46, 16);
            this.lblFecha.TabIndex = 5;
            this.lblFecha.Text = "Fecha";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Enabled = false;
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(546, 27);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(107, 22);
            this.dtpFecha.TabIndex = 2;
            // 
            // gbConsulta
            // 
            this.gbConsulta.Controls.Add(this.dgvEgreso);
            this.gbConsulta.Controls.Add(this.StatusCaja);
            this.gbConsulta.Location = new System.Drawing.Point(12, 110);
            this.gbConsulta.Name = "gbConsulta";
            this.gbConsulta.Size = new System.Drawing.Size(438, 328);
            this.gbConsulta.TabIndex = 2;
            this.gbConsulta.TabStop = false;
            this.gbConsulta.Text = "Resultado Consulta";
            // 
            // dgvEgreso
            // 
            this.dgvEgreso.AllowUserToAddRows = false;
            this.dgvEgreso.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvEgreso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEgreso.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Numero,
            this.Fecha,
            this.Valor,
            this.Estado,
            this.IdBeneficio});
            this.dgvEgreso.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvEgreso.Location = new System.Drawing.Point(3, 24);
            this.dgvEgreso.Name = "dgvEgreso";
            this.dgvEgreso.Size = new System.Drawing.Size(432, 278);
            this.dgvEgreso.TabIndex = 0;
            this.dgvEgreso.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEgreso_CellClick);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // Numero
            // 
            this.Numero.DataPropertyName = "numero";
            this.Numero.HeaderText = "Numero";
            this.Numero.Name = "Numero";
            this.Numero.Width = 80;
            // 
            // Fecha
            // 
            this.Fecha.DataPropertyName = "fecha";
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
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
            this.Valor.Width = 117;
            // 
            // Estado
            // 
            this.Estado.DataPropertyName = "estado";
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.Width = 90;
            // 
            // IdBeneficio
            // 
            this.IdBeneficio.DataPropertyName = "id_beneficio";
            this.IdBeneficio.HeaderText = "IdBeneficio";
            this.IdBeneficio.Name = "IdBeneficio";
            this.IdBeneficio.Visible = false;
            // 
            // StatusCaja
            // 
            this.StatusCaja.BackColor = System.Drawing.Color.LightSteelBlue;
            this.StatusCaja.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnInicio,
            this.btnAnterior,
            this.lblStatusEgreso,
            this.btnSiguiente,
            this.btnFin});
            this.StatusCaja.Location = new System.Drawing.Point(3, 303);
            this.StatusCaja.Name = "StatusCaja";
            this.StatusCaja.Size = new System.Drawing.Size(432, 22);
            this.StatusCaja.TabIndex = 1;
            this.StatusCaja.Text = "Status de Factura";
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
            // lblStatusEgreso
            // 
            this.lblStatusEgreso.Name = "lblStatusEgreso";
            this.lblStatusEgreso.Size = new System.Drawing.Size(30, 17);
            this.lblStatusEgreso.Text = "0 / 0";
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
            // btnAnular
            // 
            this.btnAnular.Image = ((System.Drawing.Image)(resources.GetObject("btnAnular.Image")));
            this.btnAnular.Location = new System.Drawing.Point(451, 133);
            this.btnAnular.Name = "btnAnular";
            this.btnAnular.Size = new System.Drawing.Size(24, 24);
            this.btnAnular.TabIndex = 17;
            this.btnAnular.UseVisualStyleBackColor = true;
            this.btnAnular.Click += new System.EventHandler(this.btnAnular_Click);
            // 
            // btnFormasPago
            // 
            this.btnFormasPago.Image = ((System.Drawing.Image)(resources.GetObject("btnFormasPago.Image")));
            this.btnFormasPago.Location = new System.Drawing.Point(451, 158);
            this.btnFormasPago.Name = "btnFormasPago";
            this.btnFormasPago.Size = new System.Drawing.Size(24, 24);
            this.btnFormasPago.TabIndex = 16;
            this.btnFormasPago.UseVisualStyleBackColor = true;
            this.btnFormasPago.Visible = false;
            this.btnFormasPago.Click += new System.EventHandler(this.btnFormasPago_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvCuentas);
            this.groupBox1.Location = new System.Drawing.Point(481, 110);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(457, 197);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Conceptos del Ingreso";
            // 
            // dgvCuentas
            // 
            this.dgvCuentas.AllowUserToAddRows = false;
            this.dgvCuentas.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvCuentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCuentas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdC,
            this.Codigo,
            this.Concepto,
            this.ValorC});
            this.dgvCuentas.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvCuentas.Location = new System.Drawing.Point(5, 24);
            this.dgvCuentas.Name = "dgvCuentas";
            this.dgvCuentas.RowHeadersVisible = false;
            this.dgvCuentas.Size = new System.Drawing.Size(447, 164);
            this.dgvCuentas.TabIndex = 0;
            // 
            // IdC
            // 
            this.IdC.DataPropertyName = "id";
            this.IdC.HeaderText = "Id";
            this.IdC.Name = "IdC";
            this.IdC.Visible = false;
            // 
            // Codigo
            // 
            this.Codigo.DataPropertyName = "codigo";
            this.Codigo.HeaderText = "Código";
            this.Codigo.Name = "Codigo";
            this.Codigo.Visible = false;
            this.Codigo.Width = 65;
            // 
            // Concepto
            // 
            this.Concepto.DataPropertyName = "Concepto";
            this.Concepto.HeaderText = "Concepto";
            this.Concepto.Name = "Concepto";
            this.Concepto.Width = 332;
            // 
            // ValorC
            // 
            this.ValorC.DataPropertyName = "valor";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = null;
            this.ValorC.DefaultCellStyle = dataGridViewCellStyle4;
            this.ValorC.HeaderText = "Valor";
            this.ValorC.Name = "ValorC";
            this.ValorC.Width = 110;
            // 
            // gbBeneficiario
            // 
            this.gbBeneficiario.Controls.Add(this.lblNit);
            this.gbBeneficiario.Controls.Add(this.txtNit);
            this.gbBeneficiario.Controls.Add(this.lblNombre);
            this.gbBeneficiario.Controls.Add(this.txtNombre);
            this.gbBeneficiario.Location = new System.Drawing.Point(481, 313);
            this.gbBeneficiario.Name = "gbBeneficiario";
            this.gbBeneficiario.Size = new System.Drawing.Size(457, 122);
            this.gbBeneficiario.TabIndex = 18;
            this.gbBeneficiario.TabStop = false;
            this.gbBeneficiario.Text = "Datos del Beneficiario";
            // 
            // lblNit
            // 
            this.lblNit.AutoSize = true;
            this.lblNit.Location = new System.Drawing.Point(19, 32);
            this.lblNit.Name = "lblNit";
            this.lblNit.Size = new System.Drawing.Size(68, 16);
            this.lblNit.TabIndex = 3;
            this.lblNit.Text = "C.C. o NIT";
            // 
            // txtNit
            // 
            this.txtNit.Location = new System.Drawing.Point(96, 29);
            this.txtNit.Name = "txtNit";
            this.txtNit.ReadOnly = true;
            this.txtNit.Size = new System.Drawing.Size(340, 22);
            this.txtNit.TabIndex = 2;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(19, 74);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(57, 16);
            this.lblNombre.TabIndex = 1;
            this.lblNombre.Text = "Nombre";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(96, 71);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.ReadOnly = true;
            this.txtNombre.Size = new System.Drawing.Size(340, 22);
            this.txtNombre.TabIndex = 0;
            // 
            // FrmConsultaOtro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(950, 448);
            this.Controls.Add(this.gbBeneficiario);
            this.Controls.Add(this.btnAnular);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnFormasPago);
            this.Controls.Add(this.tsMenuConsulta);
            this.Controls.Add(this.gbCriterio);
            this.Controls.Add(this.gbConsulta);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmConsultaOtro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta de Otros Ingresos";
            this.Load += new System.EventHandler(this.FrmConsultaEgreso_Load);
            this.tsMenuConsulta.ResumeLayout(false);
            this.tsMenuConsulta.PerformLayout();
            this.gbCriterio.ResumeLayout(false);
            this.gbCriterio.PerformLayout();
            this.gbConsulta.ResumeLayout(false);
            this.gbConsulta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEgreso)).EndInit();
            this.StatusCaja.ResumeLayout(false);
            this.StatusCaja.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuentas)).EndInit();
            this.gbBeneficiario.ResumeLayout(false);
            this.gbBeneficiario.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMenuConsulta;
        private System.Windows.Forms.ToolStripButton tsBtnListarTodos;
        private System.Windows.Forms.ToolStripButton tsBtnSalir;
        private System.Windows.Forms.GroupBox gbCriterio;
        private System.Windows.Forms.Button btnBuscarFe;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.GroupBox gbConsulta;
        private System.Windows.Forms.StatusStrip StatusCaja;
        private System.Windows.Forms.ToolStripDropDownButton btnInicio;
        private System.Windows.Forms.ToolStripDropDownButton btnAnterior;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusEgreso;
        private System.Windows.Forms.ToolStripDropDownButton btnSiguiente;
        private System.Windows.Forms.ToolStripDropDownButton btnFin;
        private System.Windows.Forms.DataGridView dgvEgreso;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvCuentas;
        private System.Windows.Forms.ComboBox cbCriterio;
        private System.Windows.Forms.ComboBox cbFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha1;
        private System.Windows.Forms.Button btnFormasPago;
        private System.Windows.Forms.Button btnAnular;
        private System.Windows.Forms.CheckBox chkAnulado;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripButton tsBtnCopia;
        private System.Windows.Forms.GroupBox gbBeneficiario;
        private System.Windows.Forms.Label lblNit;
        private System.Windows.Forms.TextBox txtNit;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdC;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Concepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorC;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdBeneficio;
    }
}