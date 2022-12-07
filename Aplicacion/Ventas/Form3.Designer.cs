namespace Aplicacion.Ventas
{
    partial class Form3
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
            this.dataGrid_1 = new System.Windows.Forms.DataGridView();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.dtpFecha2 = new System.Windows.Forms.DateTimePicker();
            this.btnCargar = new System.Windows.Forms.Button();
            this.txtIdCaja = new System.Windows.Forms.TextBox();
            this.dataGrid_2 = new System.Windows.Forms.DataGridView();
            this.btnLoadSaldosCarteraF4 = new System.Windows.Forms.Button();
            this.btnLoadSaldosRbo = new System.Windows.Forms.Button();
            this.dataGrid_3 = new System.Windows.Forms.DataGridView();
            this.dtpFechaAjuste = new System.Windows.Forms.DateTimePicker();
            this.btnCargarFechasTotales = new System.Windows.Forms.Button();
            this.btnConsultaIva = new System.Windows.Forms.Button();
            this.dtpFechaAjuste2 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFechaStop = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_3)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGrid_1
            // 
            this.dataGrid_1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid_1.Location = new System.Drawing.Point(3, 15);
            this.dataGrid_1.Name = "dataGrid_1";
            this.dataGrid_1.Size = new System.Drawing.Size(10, 18);
            this.dataGrid_1.TabIndex = 0;
            this.dataGrid_1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_1_CellContentClick);
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(166, 13);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(93, 20);
            this.dtpFecha.TabIndex = 1;
            // 
            // dtpFecha2
            // 
            this.dtpFecha2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha2.Location = new System.Drawing.Point(265, 13);
            this.dtpFecha2.Name = "dtpFecha2";
            this.dtpFecha2.Size = new System.Drawing.Size(96, 20);
            this.dtpFecha2.TabIndex = 2;
            // 
            // btnCargar
            // 
            this.btnCargar.Location = new System.Drawing.Point(379, 59);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(60, 23);
            this.btnCargar.TabIndex = 3;
            this.btnCargar.Text = "Cargar aj";
            this.btnCargar.UseVisualStyleBackColor = true;
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
            // 
            // txtIdCaja
            // 
            this.txtIdCaja.Location = new System.Drawing.Point(7, 14);
            this.txtIdCaja.Name = "txtIdCaja";
            this.txtIdCaja.Size = new System.Drawing.Size(44, 20);
            this.txtIdCaja.TabIndex = 4;
            this.txtIdCaja.Text = "499";
            // 
            // dataGrid_2
            // 
            this.dataGrid_2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid_2.Location = new System.Drawing.Point(16, 15);
            this.dataGrid_2.Name = "dataGrid_2";
            this.dataGrid_2.Size = new System.Drawing.Size(12, 18);
            this.dataGrid_2.TabIndex = 0;
            this.dataGrid_2.Visible = false;
            this.dataGrid_2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_2_CellContentClick);
            // 
            // btnLoadSaldosCarteraF4
            // 
            this.btnLoadSaldosCarteraF4.Enabled = false;
            this.btnLoadSaldosCarteraF4.Location = new System.Drawing.Point(107, 12);
            this.btnLoadSaldosCarteraF4.Name = "btnLoadSaldosCarteraF4";
            this.btnLoadSaldosCarteraF4.Size = new System.Drawing.Size(29, 23);
            this.btnLoadSaldosCarteraF4.TabIndex = 3;
            this.btnLoadSaldosCarteraF4.Text = "Saldos F4";
            this.btnLoadSaldosCarteraF4.UseVisualStyleBackColor = true;
            this.btnLoadSaldosCarteraF4.Visible = false;
            this.btnLoadSaldosCarteraF4.Click += new System.EventHandler(this.btnLoadSaldosCarteraF4_Click);
            // 
            // btnLoadSaldosRbo
            // 
            this.btnLoadSaldosRbo.Enabled = false;
            this.btnLoadSaldosRbo.Location = new System.Drawing.Point(139, 12);
            this.btnLoadSaldosRbo.Name = "btnLoadSaldosRbo";
            this.btnLoadSaldosRbo.Size = new System.Drawing.Size(21, 23);
            this.btnLoadSaldosRbo.TabIndex = 3;
            this.btnLoadSaldosRbo.Text = "Saldos Rbo.";
            this.btnLoadSaldosRbo.UseVisualStyleBackColor = true;
            this.btnLoadSaldosRbo.Visible = false;
            this.btnLoadSaldosRbo.Click += new System.EventHandler(this.btnLoadSaldosRbo_Click);
            // 
            // dataGrid_3
            // 
            this.dataGrid_3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid_3.Location = new System.Drawing.Point(30, 15);
            this.dataGrid_3.Name = "dataGrid_3";
            this.dataGrid_3.Size = new System.Drawing.Size(12, 18);
            this.dataGrid_3.TabIndex = 0;
            this.dataGrid_3.Visible = false;
            this.dataGrid_3.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_3_CellContentClick);
            // 
            // dtpFechaAjuste
            // 
            this.dtpFechaAjuste.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaAjuste.Location = new System.Drawing.Point(52, 14);
            this.dtpFechaAjuste.Name = "dtpFechaAjuste";
            this.dtpFechaAjuste.Size = new System.Drawing.Size(87, 20);
            this.dtpFechaAjuste.TabIndex = 1;
            // 
            // btnCargarFechasTotales
            // 
            this.btnCargarFechasTotales.Location = new System.Drawing.Point(379, 15);
            this.btnCargarFechasTotales.Name = "btnCargarFechasTotales";
            this.btnCargarFechasTotales.Size = new System.Drawing.Size(57, 23);
            this.btnCargarFechasTotales.TabIndex = 3;
            this.btnCargarFechasTotales.Text = "Cargar t";
            this.btnCargarFechasTotales.UseVisualStyleBackColor = true;
            this.btnCargarFechasTotales.Visible = false;
            this.btnCargarFechasTotales.Click += new System.EventHandler(this.btnCargarFechasTotales_Click);
            // 
            // btnConsultaIva
            // 
            this.btnConsultaIva.Enabled = false;
            this.btnConsultaIva.Location = new System.Drawing.Point(44, 12);
            this.btnConsultaIva.Name = "btnConsultaIva";
            this.btnConsultaIva.Size = new System.Drawing.Size(60, 23);
            this.btnConsultaIva.TabIndex = 3;
            this.btnConsultaIva.Text = "Consulta";
            this.btnConsultaIva.UseVisualStyleBackColor = true;
            this.btnConsultaIva.Visible = false;
            this.btnConsultaIva.Click += new System.EventHandler(this.btnConsultaIva_Click);
            // 
            // dtpFechaAjuste2
            // 
            this.dtpFechaAjuste2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaAjuste2.Location = new System.Drawing.Point(141, 14);
            this.dtpFechaAjuste2.Name = "dtpFechaAjuste2";
            this.dtpFechaAjuste2.Size = new System.Drawing.Size(87, 20);
            this.dtpFechaAjuste2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(228, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "l";
            // 
            // dtpFechaStop
            // 
            this.dtpFechaStop.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaStop.Location = new System.Drawing.Point(273, 14);
            this.dtpFechaStop.Name = "dtpFechaStop";
            this.dtpFechaStop.Size = new System.Drawing.Size(87, 20);
            this.dtpFechaStop.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(242, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Stop";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtIdCaja);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtpFechaAjuste);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpFechaAjuste2);
            this.groupBox1.Controls.Add(this.dtpFechaStop);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(6, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(367, 44);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtpFecha2);
            this.groupBox2.Controls.Add(this.dtpFecha);
            this.groupBox2.Controls.Add(this.btnLoadSaldosRbo);
            this.groupBox2.Controls.Add(this.btnConsultaIva);
            this.groupBox2.Controls.Add(this.dataGrid_3);
            this.groupBox2.Controls.Add(this.btnLoadSaldosCarteraF4);
            this.groupBox2.Controls.Add(this.dataGrid_2);
            this.groupBox2.Controls.Add(this.dataGrid_1);
            this.groupBox2.Location = new System.Drawing.Point(6, 47);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(367, 43);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(460, 108);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCargarFechasTotales);
            this.Controls.Add(this.btnCargar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta de facturas de venta repetidas";
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_3)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha2;
        private System.Windows.Forms.Button btnCargar;
        private System.Windows.Forms.TextBox txtIdCaja;
        public System.Windows.Forms.DataGridView dataGrid_1;
        public System.Windows.Forms.DataGridView dataGrid_2;
        private System.Windows.Forms.Button btnLoadSaldosCarteraF4;
        private System.Windows.Forms.Button btnLoadSaldosRbo;
        public System.Windows.Forms.DataGridView dataGrid_3;
        private System.Windows.Forms.DateTimePicker dtpFechaAjuste;
        private System.Windows.Forms.Button btnCargarFechasTotales;
        private System.Windows.Forms.Button btnConsultaIva;
        private System.Windows.Forms.DateTimePicker dtpFechaAjuste2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFechaStop;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}