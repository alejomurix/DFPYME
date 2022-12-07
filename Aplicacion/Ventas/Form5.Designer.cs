namespace Aplicacion.Ventas
{
    partial class Form5
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGrid_1 = new System.Windows.Forms.DataGridView();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.dtpFecha2 = new System.Windows.Forms.DateTimePicker();
            this.btnCargar = new System.Windows.Forms.Button();
            this.txtIdCaja = new System.Windows.Forms.TextBox();
            this.btnLoadSaldosCarteraF4 = new System.Windows.Forms.Button();
            this.btnLoadSaldosRbo = new System.Windows.Forms.Button();
            this.txtSql = new System.Windows.Forms.TextBox();
            this.btnCsv = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtUtilidad = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.txtUtilidadCosto = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.txtUtilidadVentas = new System.Windows.Forms.TextBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvIvaCosto = new System.Windows.Forms.DataGridView();
            this.TarifaIvaCosto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BaseIvaCosto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IvaCosto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubtotalIvaCosto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTotalNetoIvaCosto = new System.Windows.Forms.TextBox();
            this.txtTotalIvaCosto = new System.Windows.Forms.TextBox();
            this.txtTotalBaseIvaCosto = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_1)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIvaCosto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGrid_1
            // 
            this.dataGrid_1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid_1.Location = new System.Drawing.Point(11, 131);
            this.dataGrid_1.Name = "dataGrid_1";
            this.dataGrid_1.Size = new System.Drawing.Size(853, 188);
            this.dataGrid_1.TabIndex = 0;
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(473, 6);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(108, 20);
            this.dtpFecha.TabIndex = 1;
            this.dtpFecha.Visible = false;
            // 
            // dtpFecha2
            // 
            this.dtpFecha2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha2.Location = new System.Drawing.Point(587, 7);
            this.dtpFecha2.Name = "dtpFecha2";
            this.dtpFecha2.Size = new System.Drawing.Size(115, 20);
            this.dtpFecha2.TabIndex = 2;
            this.dtpFecha2.Visible = false;
            // 
            // btnCargar
            // 
            this.btnCargar.Location = new System.Drawing.Point(11, 3);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(75, 23);
            this.btnCargar.TabIndex = 3;
            this.btnCargar.Text = "Cargar";
            this.btnCargar.UseVisualStyleBackColor = true;
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
            // 
            // txtIdCaja
            // 
            this.txtIdCaja.Location = new System.Drawing.Point(424, 6);
            this.txtIdCaja.Name = "txtIdCaja";
            this.txtIdCaja.Size = new System.Drawing.Size(43, 20);
            this.txtIdCaja.TabIndex = 4;
            this.txtIdCaja.Text = "499";
            this.txtIdCaja.Visible = false;
            // 
            // btnLoadSaldosCarteraF4
            // 
            this.btnLoadSaldosCarteraF4.Location = new System.Drawing.Point(708, 5);
            this.btnLoadSaldosCarteraF4.Name = "btnLoadSaldosCarteraF4";
            this.btnLoadSaldosCarteraF4.Size = new System.Drawing.Size(75, 23);
            this.btnLoadSaldosCarteraF4.TabIndex = 3;
            this.btnLoadSaldosCarteraF4.Text = "Saldos F4";
            this.btnLoadSaldosCarteraF4.UseVisualStyleBackColor = true;
            this.btnLoadSaldosCarteraF4.Visible = false;
            this.btnLoadSaldosCarteraF4.Click += new System.EventHandler(this.btnLoadSaldosCarteraF4_Click);
            // 
            // btnLoadSaldosRbo
            // 
            this.btnLoadSaldosRbo.Location = new System.Drawing.Point(789, 5);
            this.btnLoadSaldosRbo.Name = "btnLoadSaldosRbo";
            this.btnLoadSaldosRbo.Size = new System.Drawing.Size(75, 23);
            this.btnLoadSaldosRbo.TabIndex = 3;
            this.btnLoadSaldosRbo.Text = "Saldos Rbo.";
            this.btnLoadSaldosRbo.UseVisualStyleBackColor = true;
            this.btnLoadSaldosRbo.Visible = false;
            this.btnLoadSaldosRbo.Click += new System.EventHandler(this.btnLoadSaldosRbo_Click);
            // 
            // txtSql
            // 
            this.txtSql.Location = new System.Drawing.Point(11, 32);
            this.txtSql.Multiline = true;
            this.txtSql.Name = "txtSql";
            this.txtSql.Size = new System.Drawing.Size(853, 93);
            this.txtSql.TabIndex = 5;
            // 
            // btnCsv
            // 
            this.btnCsv.Location = new System.Drawing.Point(92, 3);
            this.btnCsv.Name = "btnCsv";
            this.btnCsv.Size = new System.Drawing.Size(75, 23);
            this.btnCsv.TabIndex = 3;
            this.btnCsv.Text = "CSV";
            this.btnCsv.UseVisualStyleBackColor = true;
            this.btnCsv.Click += new System.EventHandler(this.btnCsv_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtUtilidad);
            this.groupBox4.Controls.Add(this.textBox9);
            this.groupBox4.Controls.Add(this.txtUtilidadCosto);
            this.groupBox4.Controls.Add(this.textBox10);
            this.groupBox4.Controls.Add(this.txtUtilidadVentas);
            this.groupBox4.Controls.Add(this.textBox11);
            this.groupBox4.Location = new System.Drawing.Point(11, 517);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(353, 65);
            this.groupBox4.TabIndex = 16;
            this.groupBox4.TabStop = false;
            // 
            // txtUtilidad
            // 
            this.txtUtilidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtUtilidad.Location = new System.Drawing.Point(231, 35);
            this.txtUtilidad.Name = "txtUtilidad";
            this.txtUtilidad.ReadOnly = true;
            this.txtUtilidad.Size = new System.Drawing.Size(111, 21);
            this.txtUtilidad.TabIndex = 13;
            this.txtUtilidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox9
            // 
            this.textBox9.BackColor = System.Drawing.SystemColors.Window;
            this.textBox9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.textBox9.Location = new System.Drawing.Point(231, 14);
            this.textBox9.Name = "textBox9";
            this.textBox9.ReadOnly = true;
            this.textBox9.Size = new System.Drawing.Size(111, 21);
            this.textBox9.TabIndex = 13;
            this.textBox9.Text = "Utilidad Prom.";
            this.textBox9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtUtilidadCosto
            // 
            this.txtUtilidadCosto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtUtilidadCosto.Location = new System.Drawing.Point(120, 35);
            this.txtUtilidadCosto.Name = "txtUtilidadCosto";
            this.txtUtilidadCosto.ReadOnly = true;
            this.txtUtilidadCosto.Size = new System.Drawing.Size(111, 21);
            this.txtUtilidadCosto.TabIndex = 13;
            this.txtUtilidadCosto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox10
            // 
            this.textBox10.BackColor = System.Drawing.SystemColors.Window;
            this.textBox10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.textBox10.Location = new System.Drawing.Point(120, 14);
            this.textBox10.Name = "textBox10";
            this.textBox10.ReadOnly = true;
            this.textBox10.Size = new System.Drawing.Size(111, 21);
            this.textBox10.TabIndex = 13;
            this.textBox10.Text = "Costo Prom.";
            this.textBox10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtUtilidadVentas
            // 
            this.txtUtilidadVentas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtUtilidadVentas.Location = new System.Drawing.Point(9, 35);
            this.txtUtilidadVentas.Name = "txtUtilidadVentas";
            this.txtUtilidadVentas.ReadOnly = true;
            this.txtUtilidadVentas.Size = new System.Drawing.Size(111, 21);
            this.txtUtilidadVentas.TabIndex = 13;
            this.txtUtilidadVentas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox11
            // 
            this.textBox11.BackColor = System.Drawing.SystemColors.Window;
            this.textBox11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.textBox11.Location = new System.Drawing.Point(9, 14);
            this.textBox11.Name = "textBox11";
            this.textBox11.ReadOnly = true;
            this.textBox11.Size = new System.Drawing.Size(111, 21);
            this.textBox11.TabIndex = 13;
            this.textBox11.Text = "Ventas";
            this.textBox11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvIvaCosto);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.groupBox3.Location = new System.Drawing.Point(419, 334);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(450, 167);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "IVA en Costos";
            // 
            // dgvIvaCosto
            // 
            this.dgvIvaCosto.AllowUserToAddRows = false;
            this.dgvIvaCosto.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvIvaCosto.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvIvaCosto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIvaCosto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TarifaIvaCosto,
            this.BaseIvaCosto,
            this.IvaCosto,
            this.SubtotalIvaCosto});
            this.dgvIvaCosto.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvIvaCosto.Location = new System.Drawing.Point(7, 23);
            this.dgvIvaCosto.Name = "dgvIvaCosto";
            this.dgvIvaCosto.RowHeadersVisible = false;
            this.dgvIvaCosto.Size = new System.Drawing.Size(437, 115);
            this.dgvIvaCosto.TabIndex = 0;
            // 
            // TarifaIvaCosto
            // 
            this.TarifaIvaCosto.DataPropertyName = "Tarifa";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "N1";
            dataGridViewCellStyle2.NullValue = null;
            this.TarifaIvaCosto.DefaultCellStyle = dataGridViewCellStyle2;
            this.TarifaIvaCosto.HeaderText = "Tarifa";
            this.TarifaIvaCosto.Name = "TarifaIvaCosto";
            this.TarifaIvaCosto.Width = 110;
            // 
            // BaseIvaCosto
            // 
            this.BaseIvaCosto.DataPropertyName = "BaseGravable";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.BaseIvaCosto.DefaultCellStyle = dataGridViewCellStyle3;
            this.BaseIvaCosto.HeaderText = "Base";
            this.BaseIvaCosto.Name = "BaseIvaCosto";
            this.BaseIvaCosto.Width = 110;
            // 
            // IvaCosto
            // 
            this.IvaCosto.DataPropertyName = "ValorIva";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = null;
            this.IvaCosto.DefaultCellStyle = dataGridViewCellStyle4;
            this.IvaCosto.HeaderText = "IVA";
            this.IvaCosto.Name = "IvaCosto";
            this.IvaCosto.Width = 110;
            // 
            // SubtotalIvaCosto
            // 
            this.SubtotalIvaCosto.DataPropertyName = "Total";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N0";
            dataGridViewCellStyle5.NullValue = null;
            this.SubtotalIvaCosto.DefaultCellStyle = dataGridViewCellStyle5;
            this.SubtotalIvaCosto.HeaderText = "SubTotal";
            this.SubtotalIvaCosto.Name = "SubtotalIvaCosto";
            // 
            // txtTotalNetoIvaCosto
            // 
            this.txtTotalNetoIvaCosto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtTotalNetoIvaCosto.Location = new System.Drawing.Point(768, 531);
            this.txtTotalNetoIvaCosto.Name = "txtTotalNetoIvaCosto";
            this.txtTotalNetoIvaCosto.ReadOnly = true;
            this.txtTotalNetoIvaCosto.Size = new System.Drawing.Size(101, 21);
            this.txtTotalNetoIvaCosto.TabIndex = 20;
            this.txtTotalNetoIvaCosto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotalIvaCosto
            // 
            this.txtTotalIvaCosto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtTotalIvaCosto.Location = new System.Drawing.Point(659, 531);
            this.txtTotalIvaCosto.Name = "txtTotalIvaCosto";
            this.txtTotalIvaCosto.ReadOnly = true;
            this.txtTotalIvaCosto.Size = new System.Drawing.Size(111, 21);
            this.txtTotalIvaCosto.TabIndex = 19;
            this.txtTotalIvaCosto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotalBaseIvaCosto
            // 
            this.txtTotalBaseIvaCosto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtTotalBaseIvaCosto.Location = new System.Drawing.Point(549, 531);
            this.txtTotalBaseIvaCosto.Name = "txtTotalBaseIvaCosto";
            this.txtTotalBaseIvaCosto.ReadOnly = true;
            this.txtTotalBaseIvaCosto.Size = new System.Drawing.Size(111, 21);
            this.txtTotalBaseIvaCosto.TabIndex = 18;
            this.txtTotalBaseIvaCosto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotalBaseIvaCosto.TextChanged += new System.EventHandler(this.txtTotalBaseIvaCosto_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Green;
            this.pictureBox1.Location = new System.Drawing.Point(58, 380);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(73, 61);
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(877, 335);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtTotalNetoIvaCosto);
            this.Controls.Add(this.txtTotalIvaCosto);
            this.Controls.Add(this.txtTotalBaseIvaCosto);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.txtSql);
            this.Controls.Add(this.txtIdCaja);
            this.Controls.Add(this.btnLoadSaldosRbo);
            this.Controls.Add(this.btnLoadSaldosCarteraF4);
            this.Controls.Add(this.btnCsv);
            this.Controls.Add(this.btnCargar);
            this.Controls.Add(this.dtpFecha2);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.dataGrid_1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form5";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta de facturas de venta repetidas";
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_1)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIvaCosto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha2;
        private System.Windows.Forms.Button btnCargar;
        private System.Windows.Forms.TextBox txtIdCaja;
        public System.Windows.Forms.DataGridView dataGrid_1;
        private System.Windows.Forms.Button btnLoadSaldosCarteraF4;
        private System.Windows.Forms.Button btnLoadSaldosRbo;
        private System.Windows.Forms.TextBox txtSql;
        private System.Windows.Forms.Button btnCsv;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtUtilidad;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.TextBox txtUtilidadCosto;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.TextBox txtUtilidadVentas;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvIvaCosto;
        private System.Windows.Forms.DataGridViewTextBoxColumn TarifaIvaCosto;
        private System.Windows.Forms.DataGridViewTextBoxColumn BaseIvaCosto;
        private System.Windows.Forms.DataGridViewTextBoxColumn IvaCosto;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubtotalIvaCosto;
        private System.Windows.Forms.TextBox txtTotalNetoIvaCosto;
        private System.Windows.Forms.TextBox txtTotalIvaCosto;
        private System.Windows.Forms.TextBox txtTotalBaseIvaCosto;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}