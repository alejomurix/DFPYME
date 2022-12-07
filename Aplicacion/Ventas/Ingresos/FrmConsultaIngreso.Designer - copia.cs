namespace Aplicacion.Ventas.Ingresos
{
    partial class FrmConsultaIngreso
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConsultaIngreso));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsMenuConsulta = new System.Windows.Forms.ToolStrip();
            this.tsBtnListarTodos = new System.Windows.Forms.ToolStripButton();
            this.tsBtnEditar = new System.Windows.Forms.ToolStripButton();
            this.tsBtnCopia = new System.Windows.Forms.ToolStripButton();
            this.tsBtnSalir = new System.Windows.Forms.ToolStripButton();
            this.gbConsultas = new System.Windows.Forms.GroupBox();
            this.cbFecha = new System.Windows.Forms.ComboBox();
            this.dtpFecha1 = new System.Windows.Forms.DateTimePicker();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.cbCriterio = new System.Windows.Forms.ComboBox();
            this.gbResultado = new System.Windows.Forms.GroupBox();
            this.StatusIgreso = new System.Windows.Forms.StatusStrip();
            this.btnInicio = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnAnterior = new System.Windows.Forms.ToolStripDropDownButton();
            this.lblStatusIngreso = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnSiguiente = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnFin = new System.Windows.Forms.ToolStripDropDownButton();
            this.dgvIvaContado = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NitCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Concepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsMenuConsulta.SuspendLayout();
            this.gbConsultas.SuspendLayout();
            this.gbResultado.SuspendLayout();
            this.StatusIgreso.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIvaContado)).BeginInit();
            this.SuspendLayout();
            // 
            // tsMenuConsulta
            // 
            this.tsMenuConsulta.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnListarTodos,
            this.tsBtnEditar,
            this.tsBtnCopia,
            this.tsBtnSalir});
            this.tsMenuConsulta.Location = new System.Drawing.Point(0, 0);
            this.tsMenuConsulta.Name = "tsMenuConsulta";
            this.tsMenuConsulta.Size = new System.Drawing.Size(1036, 25);
            this.tsMenuConsulta.TabIndex = 1;
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
            // tsBtnEditar
            // 
            this.tsBtnEditar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsBtnEditar.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnEditar.Image")));
            this.tsBtnEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnEditar.Name = "tsBtnEditar";
            this.tsBtnEditar.Size = new System.Drawing.Size(62, 22);
            this.tsBtnEditar.Text = "Editar";
            this.tsBtnEditar.Visible = false;
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
            // gbConsultas
            // 
            this.gbConsultas.Controls.Add(this.cbFecha);
            this.gbConsultas.Controls.Add(this.dtpFecha1);
            this.gbConsultas.Controls.Add(this.dtpFecha);
            this.gbConsultas.Controls.Add(this.btnBuscar);
            this.gbConsultas.Controls.Add(this.txtNumero);
            this.gbConsultas.Controls.Add(this.cbCriterio);
            this.gbConsultas.Location = new System.Drawing.Point(12, 33);
            this.gbConsultas.Name = "gbConsultas";
            this.gbConsultas.Size = new System.Drawing.Size(652, 79);
            this.gbConsultas.TabIndex = 0;
            this.gbConsultas.TabStop = false;
            this.gbConsultas.Text = "Criterio de Consulta";
            // 
            // cbFecha
            // 
            this.cbFecha.DisplayMember = "Nombre";
            this.cbFecha.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFecha.Enabled = false;
            this.cbFecha.FormattingEnabled = true;
            this.cbFecha.Location = new System.Drawing.Point(272, 31);
            this.cbFecha.Name = "cbFecha";
            this.cbFecha.Size = new System.Drawing.Size(117, 24);
            this.cbFecha.TabIndex = 1;
            this.cbFecha.ValueMember = "Id";
            this.cbFecha.SelectionChangeCommitted += new System.EventHandler(this.cbFecha_SelectionChangeCommitted);
            // 
            // dtpFecha1
            // 
            this.dtpFecha1.Enabled = false;
            this.dtpFecha1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha1.Location = new System.Drawing.Point(507, 31);
            this.dtpFecha1.Name = "dtpFecha1";
            this.dtpFecha1.Size = new System.Drawing.Size(96, 22);
            this.dtpFecha1.TabIndex = 3;
            // 
            // dtpFecha
            // 
            this.dtpFecha.Enabled = false;
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(405, 32);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(96, 22);
            this.dtpFecha.TabIndex = 2;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(614, 30);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(26, 23);
            this.btnBuscar.TabIndex = 4;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(145, 32);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(117, 22);
            this.txtNumero.TabIndex = 0;
            this.txtNumero.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumero_KeyPress);
            // 
            // cbCriterio
            // 
            this.cbCriterio.DisplayMember = "Nombre";
            this.cbCriterio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCriterio.FormattingEnabled = true;
            this.cbCriterio.Location = new System.Drawing.Point(7, 31);
            this.cbCriterio.Name = "cbCriterio";
            this.cbCriterio.Size = new System.Drawing.Size(133, 24);
            this.cbCriterio.TabIndex = 5;
            this.cbCriterio.ValueMember = "Id";
            this.cbCriterio.SelectionChangeCommitted += new System.EventHandler(this.cbCriterio_SelectionChangeCommitted);
            // 
            // gbResultado
            // 
            this.gbResultado.Controls.Add(this.StatusIgreso);
            this.gbResultado.Controls.Add(this.dgvIvaContado);
            this.gbResultado.Location = new System.Drawing.Point(12, 118);
            this.gbResultado.Name = "gbResultado";
            this.gbResultado.Size = new System.Drawing.Size(1012, 337);
            this.gbResultado.TabIndex = 3;
            this.gbResultado.TabStop = false;
            this.gbResultado.Text = "Resultado de la Consulta";
            // 
            // StatusIgreso
            // 
            this.StatusIgreso.BackColor = System.Drawing.Color.LightSteelBlue;
            this.StatusIgreso.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnInicio,
            this.btnAnterior,
            this.lblStatusIngreso,
            this.btnSiguiente,
            this.btnFin});
            this.StatusIgreso.Location = new System.Drawing.Point(3, 312);
            this.StatusIgreso.Name = "StatusIgreso";
            this.StatusIgreso.Size = new System.Drawing.Size(646, 22);
            this.StatusIgreso.TabIndex = 6;
            this.StatusIgreso.Text = "Status de Factura";
            this.StatusIgreso.Visible = false;
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
            // 
            // lblStatusIngreso
            // 
            this.lblStatusIngreso.Name = "lblStatusIngreso";
            this.lblStatusIngreso.Size = new System.Drawing.Size(30, 17);
            this.lblStatusIngreso.Text = "0 / 0";
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
            // 
            // dgvIvaContado
            // 
            this.dgvIvaContado.AllowUserToAddRows = false;
            this.dgvIvaContado.AllowUserToDeleteRows = false;
            this.dgvIvaContado.AllowUserToResizeColumns = false;
            this.dgvIvaContado.AllowUserToResizeRows = false;
            this.dgvIvaContado.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvIvaContado.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvIvaContado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIvaContado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.NitCliente,
            this.Cliente,
            this.Numero,
            this.Fecha,
            this.Concepto,
            this.Valor,
            this.Tipo,
            this.Estado});
            this.dgvIvaContado.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvIvaContado.Location = new System.Drawing.Point(4, 21);
            this.dgvIvaContado.Name = "dgvIvaContado";
            this.dgvIvaContado.RowHeadersVisible = false;
            this.dgvIvaContado.Size = new System.Drawing.Size(1002, 310);
            this.dgvIvaContado.TabIndex = 5;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // NitCliente
            // 
            this.NitCliente.DataPropertyName = "nitcliente";
            this.NitCliente.HeaderText = "Nit o C.C.";
            this.NitCliente.Name = "NitCliente";
            // 
            // Cliente
            // 
            this.Cliente.DataPropertyName = "nombrescliente";
            this.Cliente.HeaderText = "Cliente";
            this.Cliente.Name = "Cliente";
            this.Cliente.Width = 250;
            // 
            // Numero
            // 
            this.Numero.DataPropertyName = "numero";
            this.Numero.HeaderText = "Número";
            this.Numero.Name = "Numero";
            this.Numero.Width = 85;
            // 
            // Fecha
            // 
            this.Fecha.DataPropertyName = "fecha";
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.Width = 85;
            // 
            // Concepto
            // 
            this.Concepto.DataPropertyName = "concepto";
            this.Concepto.HeaderText = "Concepto";
            this.Concepto.Name = "Concepto";
            this.Concepto.Width = 348;
            // 
            // Valor
            // 
            this.Valor.DataPropertyName = "valor";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = null;
            this.Valor.DefaultCellStyle = dataGridViewCellStyle4;
            this.Valor.HeaderText = "Valor";
            this.Valor.Name = "Valor";
            // 
            // Tipo
            // 
            this.Tipo.DataPropertyName = "tipo";
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.Name = "Tipo";
            this.Tipo.Visible = false;
            // 
            // Estado
            // 
            this.Estado.DataPropertyName = "estado";
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.Visible = false;
            // 
            // FrmConsultaIngreso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1036, 467);
            this.Controls.Add(this.gbResultado);
            this.Controls.Add(this.gbConsultas);
            this.Controls.Add(this.tsMenuConsulta);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmConsultaIngreso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta de Ingresos";
            this.Load += new System.EventHandler(this.FrmConsultaIngreso_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmConsultaIngreso_KeyDown);
            this.tsMenuConsulta.ResumeLayout(false);
            this.tsMenuConsulta.PerformLayout();
            this.gbConsultas.ResumeLayout(false);
            this.gbConsultas.PerformLayout();
            this.gbResultado.ResumeLayout(false);
            this.gbResultado.PerformLayout();
            this.StatusIgreso.ResumeLayout(false);
            this.StatusIgreso.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIvaContado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMenuConsulta;
        private System.Windows.Forms.ToolStripButton tsBtnListarTodos;
        private System.Windows.Forms.ToolStripButton tsBtnEditar;
        private System.Windows.Forms.ToolStripButton tsBtnCopia;
        private System.Windows.Forms.ToolStripButton tsBtnSalir;
        private System.Windows.Forms.GroupBox gbConsultas;
        private System.Windows.Forms.ComboBox cbCriterio;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha1;
        private System.Windows.Forms.ComboBox cbFecha;
        private System.Windows.Forms.GroupBox gbResultado;
        private System.Windows.Forms.DataGridView dgvIvaContado;
        private System.Windows.Forms.StatusStrip StatusIgreso;
        private System.Windows.Forms.ToolStripDropDownButton btnInicio;
        private System.Windows.Forms.ToolStripDropDownButton btnAnterior;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusIngreso;
        private System.Windows.Forms.ToolStripDropDownButton btnSiguiente;
        private System.Windows.Forms.ToolStripDropDownButton btnFin;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn NitCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Concepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
    }
}