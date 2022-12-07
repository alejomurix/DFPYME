namespace Aplicacion.Ventas.Factura
{
    partial class FrmUtilidad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUtilidad));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbConsulta = new System.Windows.Forms.GroupBox();
            this.dtpFecha1 = new System.Windows.Forms.DateTimePicker();
            this.dtpFecha2 = new System.Windows.Forms.DateTimePicker();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.gbLista = new System.Windows.Forms.GroupBox();
            this.dgvUtilidad = new Aplicacion.Ventas.Factura.DataGridViewPlus();
            this.Costo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Venta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Diferencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbConsulta.SuspendLayout();
            this.gbLista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUtilidad)).BeginInit();
            this.SuspendLayout();
            // 
            // gbConsulta
            // 
            this.gbConsulta.Controls.Add(this.dtpFecha1);
            this.gbConsulta.Controls.Add(this.dtpFecha2);
            this.gbConsulta.Controls.Add(this.btnBuscar);
            this.gbConsulta.Location = new System.Drawing.Point(12, 12);
            this.gbConsulta.Name = "gbConsulta";
            this.gbConsulta.Size = new System.Drawing.Size(477, 68);
            this.gbConsulta.TabIndex = 1;
            this.gbConsulta.TabStop = false;
            this.gbConsulta.Text = "Periodo";
            // 
            // dtpFecha1
            // 
            this.dtpFecha1.CustomFormat = "dd/MM/yyyy";
            this.dtpFecha1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecha1.Location = new System.Drawing.Point(17, 25);
            this.dtpFecha1.Name = "dtpFecha1";
            this.dtpFecha1.Size = new System.Drawing.Size(84, 22);
            this.dtpFecha1.TabIndex = 10;
            // 
            // dtpFecha2
            // 
            this.dtpFecha2.CustomFormat = "dd/MM/yyyy";
            this.dtpFecha2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecha2.Location = new System.Drawing.Point(129, 25);
            this.dtpFecha2.Name = "dtpFecha2";
            this.dtpFecha2.Size = new System.Drawing.Size(84, 22);
            this.dtpFecha2.TabIndex = 11;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(243, 25);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(25, 23);
            this.btnBuscar.TabIndex = 12;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // gbLista
            // 
            this.gbLista.Controls.Add(this.dgvUtilidad);
            this.gbLista.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.gbLista.Location = new System.Drawing.Point(12, 84);
            this.gbLista.Name = "gbLista";
            this.gbLista.Size = new System.Drawing.Size(477, 133);
            this.gbLista.TabIndex = 8;
            this.gbLista.TabStop = false;
            // 
            // dgvUtilidad
            // 
            this.dgvUtilidad.AllowUserToAddRows = false;
            this.dgvUtilidad.AllowUserToResizeColumns = false;
            this.dgvUtilidad.AllowUserToResizeRows = false;
            this.dgvUtilidad.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvUtilidad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUtilidad.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Costo,
            this.Venta,
            this.Diferencia});
            this.dgvUtilidad.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvUtilidad.Location = new System.Drawing.Point(9, 21);
            this.dgvUtilidad.Name = "dgvUtilidad";
            this.dgvUtilidad.RowHeadersVisible = false;
            this.dgvUtilidad.Size = new System.Drawing.Size(457, 103);
            this.dgvUtilidad.TabIndex = 0;
            // 
            // Costo
            // 
            this.Costo.DataPropertyName = "Costo";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = null;
            this.Costo.DefaultCellStyle = dataGridViewCellStyle1;
            this.Costo.HeaderText = "Costos";
            this.Costo.Name = "Costo";
            this.Costo.Width = 150;
            // 
            // Venta
            // 
            this.Venta.DataPropertyName = "Venta";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.Venta.DefaultCellStyle = dataGridViewCellStyle2;
            this.Venta.FillWeight = 150F;
            this.Venta.HeaderText = "Ventas";
            this.Venta.Name = "Venta";
            this.Venta.ReadOnly = true;
            this.Venta.Width = 150;
            // 
            // Diferencia
            // 
            this.Diferencia.DataPropertyName = "Diferencia";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.Diferencia.DefaultCellStyle = dataGridViewCellStyle3;
            this.Diferencia.HeaderText = "Diferencia";
            this.Diferencia.Name = "Diferencia";
            this.Diferencia.ReadOnly = true;
            this.Diferencia.Width = 150;
            // 
            // FrmUtilidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(506, 231);
            this.Controls.Add(this.gbConsulta);
            this.Controls.Add(this.gbLista);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmUtilidad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Resumen de Utilidad";
            this.Load += new System.EventHandler(this.FrmUtilidad_Load);
            this.gbConsulta.ResumeLayout(false);
            this.gbLista.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUtilidad)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbConsulta;
        private System.Windows.Forms.DateTimePicker dtpFecha1;
        private System.Windows.Forms.DateTimePicker dtpFecha2;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.GroupBox gbLista;
        private DataGridViewPlus dgvUtilidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Costo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Venta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Diferencia;
    }
}