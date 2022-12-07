namespace Aplicacion.Ventas.Consultas
{
    partial class FrmConsultaImpVenta
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtTotalNetoIvaCosto = new System.Windows.Forms.TextBox();
            this.txtTotalIvaCosto = new System.Windows.Forms.TextBox();
            this.txtTotalBaseIvaCosto = new System.Windows.Forms.TextBox();
            this.dgvIvaCosto = new System.Windows.Forms.DataGridView();
            this.TarifaIvaCosto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BaseIvaCosto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IvaCosto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubtotalIvaCosto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIvaCosto)).BeginInit();
            this.SuspendLayout();
            // 
            // cbCriterio
            // 
            this.cbCriterio.Size = new System.Drawing.Size(122, 24);
            // 
            // cbTercero
            // 
            this.cbTercero.Size = new System.Drawing.Size(124, 24);
            this.cbTercero.SelectionChangeCommitted += new System.EventHandler(this.cbTercero_SelectionChangeCommitted);
            // 
            // btnBuscarTercero
            // 
            this.btnBuscarTercero.Click += new System.EventHandler(this.btnBuscarTercero_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // gbResumenIva
            // 
            this.gbResumenIva.Location = new System.Drawing.Point(346, 364);
            // 
            // cbFecha
            // 
            this.cbFecha.Size = new System.Drawing.Size(137, 24);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtTotalNetoIvaCosto);
            this.groupBox3.Controls.Add(this.txtTotalIvaCosto);
            this.groupBox3.Controls.Add(this.txtTotalBaseIvaCosto);
            this.groupBox3.Controls.Add(this.dgvIvaCosto);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.groupBox3.Location = new System.Drawing.Point(76, 364);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(250, 167);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Costo de ventas";
            // 
            // txtTotalNetoIvaCosto
            // 
            this.txtTotalNetoIvaCosto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtTotalNetoIvaCosto.Location = new System.Drawing.Point(44, 140);
            this.txtTotalNetoIvaCosto.Name = "txtTotalNetoIvaCosto";
            this.txtTotalNetoIvaCosto.ReadOnly = true;
            this.txtTotalNetoIvaCosto.Size = new System.Drawing.Size(21, 21);
            this.txtTotalNetoIvaCosto.TabIndex = 23;
            this.txtTotalNetoIvaCosto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotalNetoIvaCosto.Visible = false;
            // 
            // txtTotalIvaCosto
            // 
            this.txtTotalIvaCosto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtTotalIvaCosto.Location = new System.Drawing.Point(13, 140);
            this.txtTotalIvaCosto.Name = "txtTotalIvaCosto";
            this.txtTotalIvaCosto.ReadOnly = true;
            this.txtTotalIvaCosto.Size = new System.Drawing.Size(25, 21);
            this.txtTotalIvaCosto.TabIndex = 22;
            this.txtTotalIvaCosto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotalIvaCosto.Visible = false;
            // 
            // txtTotalBaseIvaCosto
            // 
            this.txtTotalBaseIvaCosto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtTotalBaseIvaCosto.Location = new System.Drawing.Point(117, 138);
            this.txtTotalBaseIvaCosto.Name = "txtTotalBaseIvaCosto";
            this.txtTotalBaseIvaCosto.ReadOnly = true;
            this.txtTotalBaseIvaCosto.Size = new System.Drawing.Size(111, 21);
            this.txtTotalBaseIvaCosto.TabIndex = 21;
            this.txtTotalBaseIvaCosto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
            this.dgvIvaCosto.Size = new System.Drawing.Size(234, 115);
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
            this.IvaCosto.Visible = false;
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
            this.SubtotalIvaCosto.Visible = false;
            this.SubtotalIvaCosto.Width = 110;
            // 
            // FrmConsultaImpVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1165, 540);
            this.Controls.Add(this.groupBox3);
            this.Margin = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.Name = "FrmConsultaImpVenta";
            this.Text = "Consulta de ventas";
            this.Load += new System.EventHandler(this.FrmConsultaImpVenta_Load);
            this.Controls.SetChildIndex(this.gbResumenIva, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIvaCosto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvIvaCosto;
        private System.Windows.Forms.TextBox txtTotalNetoIvaCosto;
        private System.Windows.Forms.TextBox txtTotalIvaCosto;
        private System.Windows.Forms.TextBox txtTotalBaseIvaCosto;
        private System.Windows.Forms.DataGridViewTextBoxColumn TarifaIvaCosto;
        private System.Windows.Forms.DataGridViewTextBoxColumn BaseIvaCosto;
        private System.Windows.Forms.DataGridViewTextBoxColumn IvaCosto;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubtotalIvaCosto;

    }
}