namespace Aplicacion.Administracion.Bonos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grbPuntos = new System.Windows.Forms.GroupBox();
            this.btnEliminarBono = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.dgvBonos = new System.Windows.Forms.DataGridView();
            this.chkAplicar = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNota = new System.Windows.Forms.TextBox();
            this.txtNoSorteo = new System.Windows.Forms.TextBox();
            this.lblVentaMinima = new System.Windows.Forms.Label();
            this.txtVentaMinima = new System.Windows.Forms.TextBox();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumeroSorteo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VentaMinima = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgvMarcas = new System.Windows.Forms.DataGridView();
            this.IdBonoRifaMarca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Marca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEliminarMarca = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtMarca = new System.Windows.Forms.TextBox();
            this.txtCodigoMarca = new System.Windows.Forms.TextBox();
            this.btnBuscarMarca = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.grbPuntos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBonos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMarcas)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbPuntos
            // 
            this.grbPuntos.Controls.Add(this.btnEliminarBono);
            this.grbPuntos.Controls.Add(this.btnGuardar);
            this.grbPuntos.Controls.Add(this.dtpFecha);
            this.grbPuntos.Controls.Add(this.dgvBonos);
            this.grbPuntos.Controls.Add(this.chkAplicar);
            this.grbPuntos.Controls.Add(this.label2);
            this.grbPuntos.Controls.Add(this.label3);
            this.grbPuntos.Controls.Add(this.label1);
            this.grbPuntos.Controls.Add(this.txtNota);
            this.grbPuntos.Controls.Add(this.txtNoSorteo);
            this.grbPuntos.Controls.Add(this.lblVentaMinima);
            this.grbPuntos.Controls.Add(this.txtVentaMinima);
            this.grbPuntos.Location = new System.Drawing.Point(8, 7);
            this.grbPuntos.Margin = new System.Windows.Forms.Padding(4);
            this.grbPuntos.Name = "grbPuntos";
            this.grbPuntos.Padding = new System.Windows.Forms.Padding(4);
            this.grbPuntos.Size = new System.Drawing.Size(749, 295);
            this.grbPuntos.TabIndex = 0;
            this.grbPuntos.TabStop = false;
            this.grbPuntos.Text = "Configurar de sorteo";
            // 
            // btnEliminarBono
            // 
            this.btnEliminarBono.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminarBono.Image")));
            this.btnEliminarBono.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEliminarBono.Location = new System.Drawing.Point(720, 90);
            this.btnEliminarBono.Name = "btnEliminarBono";
            this.btnEliminarBono.Size = new System.Drawing.Size(25, 25);
            this.btnEliminarBono.TabIndex = 78;
            this.btnEliminarBono.UseVisualStyleBackColor = true;
            this.btnEliminarBono.Click += new System.EventHandler(this.btnEliminarBono_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.Location = new System.Drawing.Point(628, 54);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(84, 24);
            this.btnGuardar.TabIndex = 5;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // dtpFecha
            // 
            this.dtpFecha.CustomFormat = "dd/MM/yyyy";
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecha.Location = new System.Drawing.Point(301, 22);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(109, 22);
            this.dtpFecha.TabIndex = 1;
            // 
            // dgvBonos
            // 
            this.dgvBonos.AllowUserToAddRows = false;
            this.dgvBonos.AllowUserToResizeColumns = false;
            this.dgvBonos.AllowUserToResizeRows = false;
            this.dgvBonos.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvBonos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBonos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.NumeroSorteo,
            this.Fecha,
            this.VentaMinima,
            this.Nota,
            this.Estado});
            this.dgvBonos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvBonos.Location = new System.Drawing.Point(7, 90);
            this.dgvBonos.Name = "dgvBonos";
            this.dgvBonos.RowHeadersVisible = false;
            this.dgvBonos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvBonos.Size = new System.Drawing.Size(713, 197);
            this.dgvBonos.TabIndex = 11;
            this.dgvBonos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBonos_CellClick);
            this.dgvBonos.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvBonos_CurrentCellDirtyStateChanged);
            // 
            // chkAplicar
            // 
            this.chkAplicar.AutoSize = true;
            this.chkAplicar.Checked = true;
            this.chkAplicar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAplicar.Location = new System.Drawing.Point(643, 24);
            this.chkAplicar.Name = "chkAplicar";
            this.chkAplicar.Size = new System.Drawing.Size(69, 20);
            this.chkAplicar.TabIndex = 4;
            this.chkAplicar.Text = "Aplicar";
            this.chkAplicar.UseVisualStyleBackColor = true;
            this.chkAplicar.CheckedChanged += new System.EventHandler(this.chkAplicar_CheckedChanged);
            this.chkAplicar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.chkAplicar_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(251, 25);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Fecha";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 58);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Nota";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Número de sorteo";
            // 
            // txtNota
            // 
            this.txtNota.Location = new System.Drawing.Point(123, 55);
            this.txtNota.Margin = new System.Windows.Forms.Padding(4);
            this.txtNota.Name = "txtNota";
            this.txtNota.Size = new System.Drawing.Size(494, 22);
            this.txtNota.TabIndex = 3;
            this.txtNota.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNota_KeyPress);
            // 
            // txtNoSorteo
            // 
            this.txtNoSorteo.Location = new System.Drawing.Point(123, 22);
            this.txtNoSorteo.Margin = new System.Windows.Forms.Padding(4);
            this.txtNoSorteo.Name = "txtNoSorteo";
            this.txtNoSorteo.Size = new System.Drawing.Size(109, 22);
            this.txtNoSorteo.TabIndex = 0;
            this.txtNoSorteo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNoSorteo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNoSorteo_KeyPress);
            // 
            // lblVentaMinima
            // 
            this.lblVentaMinima.AutoSize = true;
            this.lblVentaMinima.Location = new System.Drawing.Point(429, 25);
            this.lblVentaMinima.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVentaMinima.Name = "lblVentaMinima";
            this.lblVentaMinima.Size = new System.Drawing.Size(76, 16);
            this.lblVentaMinima.TabIndex = 4;
            this.lblVentaMinima.Text = "Valor venta";
            // 
            // txtVentaMinima
            // 
            this.txtVentaMinima.Location = new System.Drawing.Point(508, 22);
            this.txtVentaMinima.Margin = new System.Windows.Forms.Padding(4);
            this.txtVentaMinima.Name = "txtVentaMinima";
            this.txtVentaMinima.Size = new System.Drawing.Size(109, 22);
            this.txtVentaMinima.TabIndex = 2;
            this.txtVentaMinima.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtVentaMinima.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVentaMinima_KeyPress);
            this.txtVentaMinima.Validating += new System.ComponentModel.CancelEventHandler(this.txtVentaMinima_Validating);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // NumeroSorteo
            // 
            this.NumeroSorteo.DataPropertyName = "numero";
            this.NumeroSorteo.HeaderText = "No. Sorteo";
            this.NumeroSorteo.Name = "NumeroSorteo";
            this.NumeroSorteo.Width = 120;
            // 
            // Fecha
            // 
            this.Fecha.DataPropertyName = "fecha";
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.Width = 120;
            // 
            // VentaMinima
            // 
            this.VentaMinima.DataPropertyName = "venta_minima";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N0";
            dataGridViewCellStyle5.NullValue = null;
            this.VentaMinima.DefaultCellStyle = dataGridViewCellStyle5;
            this.VentaMinima.HeaderText = "Venta mínima";
            this.VentaMinima.Name = "VentaMinima";
            this.VentaMinima.Width = 120;
            // 
            // Nota
            // 
            this.Nota.DataPropertyName = "nota";
            this.Nota.HeaderText = "Nota";
            this.Nota.Name = "Nota";
            this.Nota.Width = 340;
            // 
            // Estado
            // 
            this.Estado.DataPropertyName = "estado";
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.Visible = false;
            // 
            // dgvMarcas
            // 
            this.dgvMarcas.AllowUserToAddRows = false;
            this.dgvMarcas.AllowUserToResizeColumns = false;
            this.dgvMarcas.AllowUserToResizeRows = false;
            this.dgvMarcas.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvMarcas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMarcas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdBonoRifaMarca,
            this.Marca});
            this.dgvMarcas.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvMarcas.Location = new System.Drawing.Point(8, 85);
            this.dgvMarcas.Name = "dgvMarcas";
            this.dgvMarcas.RowHeadersVisible = false;
            this.dgvMarcas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvMarcas.Size = new System.Drawing.Size(184, 197);
            this.dgvMarcas.TabIndex = 11;
            this.dgvMarcas.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvBonos_CurrentCellDirtyStateChanged);
            // 
            // IdBonoRifaMarca
            // 
            this.IdBonoRifaMarca.DataPropertyName = "idmarca";
            this.IdBonoRifaMarca.HeaderText = "IdBonoRifaMarca";
            this.IdBonoRifaMarca.Name = "IdBonoRifaMarca";
            this.IdBonoRifaMarca.Visible = false;
            // 
            // Marca
            // 
            this.Marca.DataPropertyName = "nombremarca";
            this.Marca.HeaderText = "Marcas";
            this.Marca.Name = "Marca";
            this.Marca.Width = 170;
            // 
            // btnEliminarMarca
            // 
            this.btnEliminarMarca.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminarMarca.Image")));
            this.btnEliminarMarca.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEliminarMarca.Location = new System.Drawing.Point(192, 85);
            this.btnEliminarMarca.Name = "btnEliminarMarca";
            this.btnEliminarMarca.Size = new System.Drawing.Size(25, 25);
            this.btnEliminarMarca.TabIndex = 78;
            this.btnEliminarMarca.UseVisualStyleBackColor = true;
            this.btnEliminarMarca.Click += new System.EventHandler(this.btnEliminarMarca_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAceptar);
            this.groupBox1.Controls.Add(this.btnBuscarMarca);
            this.groupBox1.Controls.Add(this.txtCodigoMarca);
            this.groupBox1.Controls.Add(this.txtMarca);
            this.groupBox1.Controls.Add(this.dgvMarcas);
            this.groupBox1.Controls.Add(this.btnEliminarMarca);
            this.groupBox1.Location = new System.Drawing.Point(764, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(223, 290);
            this.groupBox1.TabIndex = 79;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Marcas del sorteo";
            // 
            // txtMarca
            // 
            this.txtMarca.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMarca.Location = new System.Drawing.Point(9, 50);
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.ReadOnly = true;
            this.txtMarca.Size = new System.Drawing.Size(177, 22);
            this.txtMarca.TabIndex = 80;
            // 
            // txtCodigoMarca
            // 
            this.txtCodigoMarca.Location = new System.Drawing.Point(9, 19);
            this.txtCodigoMarca.Name = "txtCodigoMarca";
            this.txtCodigoMarca.Size = new System.Drawing.Size(177, 22);
            this.txtCodigoMarca.TabIndex = 81;
            this.txtCodigoMarca.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoMarca_KeyPress);
            // 
            // btnBuscarMarca
            // 
            this.btnBuscarMarca.Location = new System.Drawing.Point(192, 18);
            this.btnBuscarMarca.Margin = new System.Windows.Forms.Padding(4);
            this.btnBuscarMarca.Name = "btnBuscarMarca";
            this.btnBuscarMarca.Size = new System.Drawing.Size(25, 24);
            this.btnBuscarMarca.TabIndex = 82;
            this.btnBuscarMarca.Text = "...";
            this.btnBuscarMarca.UseVisualStyleBackColor = true;
            this.btnBuscarMarca.Click += new System.EventHandler(this.btnBuscarMarca_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.Image")));
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptar.Location = new System.Drawing.Point(192, 49);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(25, 25);
            this.btnAceptar.TabIndex = 80;
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // FrmBonos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(995, 307);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grbPuntos);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmBonos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sorteos";
            this.Load += new System.EventHandler(this.FrmBonos_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmBonos_KeyDown);
            this.grbPuntos.ResumeLayout(false);
            this.grbPuntos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBonos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMarcas)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbPuntos;
        private System.Windows.Forms.Label lblVentaMinima;
        private System.Windows.Forms.TextBox txtVentaMinima;
        private System.Windows.Forms.CheckBox chkAplicar;
        private System.Windows.Forms.DataGridView dgvBonos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNoSorteo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnEliminarBono;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNota;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumeroSorteo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn VentaMinima;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nota;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Estado;
        private System.Windows.Forms.DataGridView dgvMarcas;
        private System.Windows.Forms.Button btnEliminarMarca;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdBonoRifaMarca;
        private System.Windows.Forms.DataGridViewTextBoxColumn Marca;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.TextBox txtMarca;
        private System.Windows.Forms.TextBox txtCodigoMarca;
        private System.Windows.Forms.Button btnBuscarMarca;
        private System.Windows.Forms.Button btnAceptar;
    }
}