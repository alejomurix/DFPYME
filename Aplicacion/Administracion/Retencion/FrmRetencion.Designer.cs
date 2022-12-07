namespace Aplicacion.Administracion.Retencion
{
    partial class FrmRetencion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRetencion));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbRubro = new System.Windows.Forms.GroupBox();
            this.StatusRubro = new System.Windows.Forms.StatusStrip();
            this.btnAgregarRubro = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnEditarRubro = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnEliminarRubro = new System.Windows.Forms.ToolStripDropDownButton();
            this.dgvRubro = new System.Windows.Forms.DataGridView();
            this.IdRubro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreRubro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbReteConcepto = new System.Windows.Forms.GroupBox();
            this.StatusConcepto = new System.Windows.Forms.StatusStrip();
            this.btnAgregarConcepto = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnEditarConcepto = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnEliminarConcepto = new System.Windows.Forms.ToolStripDropDownButton();
            this.dgvReteConcepto = new System.Windows.Forms.DataGridView();
            this.IdConcepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdRetencion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Concepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CifraUVT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CifraPesos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tarifa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pbImgDian = new System.Windows.Forms.PictureBox();
            this.gbRubro.SuspendLayout();
            this.StatusRubro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRubro)).BeginInit();
            this.gbReteConcepto.SuspendLayout();
            this.StatusConcepto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReteConcepto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImgDian)).BeginInit();
            this.SuspendLayout();
            // 
            // gbRubro
            // 
            this.gbRubro.Controls.Add(this.StatusRubro);
            this.gbRubro.Controls.Add(this.dgvRubro);
            this.gbRubro.Location = new System.Drawing.Point(11, 10);
            this.gbRubro.Margin = new System.Windows.Forms.Padding(2);
            this.gbRubro.Name = "gbRubro";
            this.gbRubro.Padding = new System.Windows.Forms.Padding(2);
            this.gbRubro.Size = new System.Drawing.Size(786, 227);
            this.gbRubro.TabIndex = 3;
            this.gbRubro.TabStop = false;
            // 
            // StatusRubro
            // 
            this.StatusRubro.Dock = System.Windows.Forms.DockStyle.Right;
            this.StatusRubro.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.StatusRubro.GripMargin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.StatusRubro.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAgregarRubro,
            this.btnEditarRubro,
            this.btnEliminarRubro});
            this.StatusRubro.Location = new System.Drawing.Point(762, 17);
            this.StatusRubro.Name = "StatusRubro";
            this.StatusRubro.Padding = new System.Windows.Forms.Padding(1, 2, 1, 21);
            this.StatusRubro.Size = new System.Drawing.Size(22, 208);
            this.StatusRubro.TabIndex = 2;
            this.StatusRubro.Text = "statusStrip1";
            // 
            // btnAgregarRubro
            // 
            this.btnAgregarRubro.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAgregarRubro.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregarRubro.Image")));
            this.btnAgregarRubro.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAgregarRubro.Name = "btnAgregarRubro";
            this.btnAgregarRubro.ShowDropDownArrow = false;
            this.btnAgregarRubro.Size = new System.Drawing.Size(20, 20);
            this.btnAgregarRubro.Text = "Agregar Rubro";
            this.btnAgregarRubro.Click += new System.EventHandler(this.btnAgregarRubro_Click);
            // 
            // btnEditarRubro
            // 
            this.btnEditarRubro.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEditarRubro.Image = ((System.Drawing.Image)(resources.GetObject("btnEditarRubro.Image")));
            this.btnEditarRubro.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditarRubro.Name = "btnEditarRubro";
            this.btnEditarRubro.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnEditarRubro.ShowDropDownArrow = false;
            this.btnEditarRubro.Size = new System.Drawing.Size(20, 20);
            this.btnEditarRubro.Text = "Editar Rubro";
            this.btnEditarRubro.Click += new System.EventHandler(this.btnEditarRubro_Click);
            // 
            // btnEliminarRubro
            // 
            this.btnEliminarRubro.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEliminarRubro.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminarRubro.Image")));
            this.btnEliminarRubro.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEliminarRubro.Name = "btnEliminarRubro";
            this.btnEliminarRubro.ShowDropDownArrow = false;
            this.btnEliminarRubro.Size = new System.Drawing.Size(20, 20);
            this.btnEliminarRubro.Text = "Eliminar Rubro";
            this.btnEliminarRubro.Click += new System.EventHandler(this.btnEliminarRubro_Click);
            // 
            // dgvRubro
            // 
            this.dgvRubro.AllowUserToAddRows = false;
            this.dgvRubro.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvRubro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRubro.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdRubro,
            this.NombreRubro});
            this.dgvRubro.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvRubro.Location = new System.Drawing.Point(7, 17);
            this.dgvRubro.Margin = new System.Windows.Forms.Padding(2);
            this.dgvRubro.Name = "dgvRubro";
            this.dgvRubro.RowHeadersVisible = false;
            this.dgvRubro.Size = new System.Drawing.Size(752, 205);
            this.dgvRubro.TabIndex = 0;
            this.dgvRubro.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRubro_CellClick);
            // 
            // IdRubro
            // 
            this.IdRubro.DataPropertyName = "id";
            this.IdRubro.HeaderText = "Id";
            this.IdRubro.Name = "IdRubro";
            this.IdRubro.Visible = false;
            // 
            // NombreRubro
            // 
            this.NombreRubro.DataPropertyName = "rubro";
            this.NombreRubro.HeaderText = "Rubro";
            this.NombreRubro.Name = "NombreRubro";
            this.NombreRubro.Width = 745;
            // 
            // gbReteConcepto
            // 
            this.gbReteConcepto.Controls.Add(this.StatusConcepto);
            this.gbReteConcepto.Controls.Add(this.dgvReteConcepto);
            this.gbReteConcepto.Location = new System.Drawing.Point(11, 238);
            this.gbReteConcepto.Margin = new System.Windows.Forms.Padding(2);
            this.gbReteConcepto.Name = "gbReteConcepto";
            this.gbReteConcepto.Padding = new System.Windows.Forms.Padding(2);
            this.gbReteConcepto.Size = new System.Drawing.Size(1246, 317);
            this.gbReteConcepto.TabIndex = 4;
            this.gbReteConcepto.TabStop = false;
            // 
            // StatusConcepto
            // 
            this.StatusConcepto.Dock = System.Windows.Forms.DockStyle.Right;
            this.StatusConcepto.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.StatusConcepto.GripMargin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.StatusConcepto.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAgregarConcepto,
            this.btnEditarConcepto,
            this.btnEliminarConcepto});
            this.StatusConcepto.Location = new System.Drawing.Point(1222, 17);
            this.StatusConcepto.Name = "StatusConcepto";
            this.StatusConcepto.Padding = new System.Windows.Forms.Padding(1, 2, 1, 21);
            this.StatusConcepto.Size = new System.Drawing.Size(22, 298);
            this.StatusConcepto.TabIndex = 1;
            this.StatusConcepto.Text = "statusStrip1";
            // 
            // btnAgregarConcepto
            // 
            this.btnAgregarConcepto.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAgregarConcepto.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregarConcepto.Image")));
            this.btnAgregarConcepto.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAgregarConcepto.Name = "btnAgregarConcepto";
            this.btnAgregarConcepto.ShowDropDownArrow = false;
            this.btnAgregarConcepto.Size = new System.Drawing.Size(20, 20);
            this.btnAgregarConcepto.Text = "Agregar Concepto";
            this.btnAgregarConcepto.Click += new System.EventHandler(this.btnAgregarConcepto_Click);
            // 
            // btnEditarConcepto
            // 
            this.btnEditarConcepto.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEditarConcepto.Image = ((System.Drawing.Image)(resources.GetObject("btnEditarConcepto.Image")));
            this.btnEditarConcepto.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditarConcepto.Name = "btnEditarConcepto";
            this.btnEditarConcepto.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnEditarConcepto.ShowDropDownArrow = false;
            this.btnEditarConcepto.Size = new System.Drawing.Size(20, 20);
            this.btnEditarConcepto.Text = "Editar Concepto";
            this.btnEditarConcepto.Click += new System.EventHandler(this.btnEditarConcepto_Click);
            // 
            // btnEliminarConcepto
            // 
            this.btnEliminarConcepto.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEliminarConcepto.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminarConcepto.Image")));
            this.btnEliminarConcepto.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEliminarConcepto.Name = "btnEliminarConcepto";
            this.btnEliminarConcepto.ShowDropDownArrow = false;
            this.btnEliminarConcepto.Size = new System.Drawing.Size(20, 20);
            this.btnEliminarConcepto.Text = "Eliminar Concepto";
            this.btnEliminarConcepto.Click += new System.EventHandler(this.btnEliminarConcepto_Click);
            // 
            // dgvReteConcepto
            // 
            this.dgvReteConcepto.AllowUserToAddRows = false;
            this.dgvReteConcepto.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvReteConcepto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReteConcepto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdConcepto,
            this.IdRetencion,
            this.Concepto,
            this.CifraUVT,
            this.CifraPesos,
            this.Tarifa});
            this.dgvReteConcepto.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvReteConcepto.Location = new System.Drawing.Point(5, 17);
            this.dgvReteConcepto.Margin = new System.Windows.Forms.Padding(2);
            this.dgvReteConcepto.Name = "dgvReteConcepto";
            this.dgvReteConcepto.RowHeadersVisible = false;
            this.dgvReteConcepto.Size = new System.Drawing.Size(1214, 296);
            this.dgvReteConcepto.TabIndex = 0;
            // 
            // IdConcepto
            // 
            this.IdConcepto.DataPropertyName = "id";
            this.IdConcepto.HeaderText = "Id";
            this.IdConcepto.Name = "IdConcepto";
            this.IdConcepto.Visible = false;
            this.IdConcepto.Width = 30;
            // 
            // IdRetencion
            // 
            this.IdRetencion.DataPropertyName = "idretencion";
            this.IdRetencion.HeaderText = "Id";
            this.IdRetencion.Name = "IdRetencion";
            this.IdRetencion.Visible = false;
            this.IdRetencion.Width = 30;
            // 
            // Concepto
            // 
            this.Concepto.DataPropertyName = "concepto";
            this.Concepto.HeaderText = "Concepto";
            this.Concepto.Name = "Concepto";
            this.Concepto.Width = 950;
            // 
            // CifraUVT
            // 
            this.CifraUVT.DataPropertyName = "cifra_uvt";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.Format = "N1";
            dataGridViewCellStyle10.NullValue = null;
            this.CifraUVT.DefaultCellStyle = dataGridViewCellStyle10;
            this.CifraUVT.HeaderText = "Cifra UVT";
            this.CifraUVT.Name = "CifraUVT";
            this.CifraUVT.Width = 90;
            // 
            // CifraPesos
            // 
            this.CifraPesos.DataPropertyName = "cifra_pesos";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.Format = "N1";
            dataGridViewCellStyle11.NullValue = null;
            this.CifraPesos.DefaultCellStyle = dataGridViewCellStyle11;
            this.CifraPesos.HeaderText = "Cifra Pesos";
            this.CifraPesos.Name = "CifraPesos";
            // 
            // Tarifa
            // 
            this.Tarifa.DataPropertyName = "tarifa";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.Format = "N1";
            dataGridViewCellStyle12.NullValue = null;
            this.Tarifa.DefaultCellStyle = dataGridViewCellStyle12;
            this.Tarifa.HeaderText = "Tarifa%";
            this.Tarifa.Name = "Tarifa";
            this.Tarifa.Width = 70;
            // 
            // pbImgDian
            // 
            this.pbImgDian.Image = ((System.Drawing.Image)(resources.GetObject("pbImgDian.Image")));
            this.pbImgDian.Location = new System.Drawing.Point(805, 12);
            this.pbImgDian.Name = "pbImgDian";
            this.pbImgDian.Size = new System.Drawing.Size(452, 225);
            this.pbImgDian.TabIndex = 6;
            this.pbImgDian.TabStop = false;
            // 
            // FrmRetencion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1269, 571);
            this.Controls.Add(this.pbImgDian);
            this.Controls.Add(this.gbReteConcepto);
            this.Controls.Add(this.gbRubro);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmRetencion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Retenciones";
            this.Load += new System.EventHandler(this.FrmRetencion_Load);
            this.gbRubro.ResumeLayout(false);
            this.gbRubro.PerformLayout();
            this.StatusRubro.ResumeLayout(false);
            this.StatusRubro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRubro)).EndInit();
            this.gbReteConcepto.ResumeLayout(false);
            this.gbReteConcepto.PerformLayout();
            this.StatusConcepto.ResumeLayout(false);
            this.StatusConcepto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReteConcepto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImgDian)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbRubro;
        private System.Windows.Forms.DataGridView dgvRubro;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdRubro;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreRubro;
        private System.Windows.Forms.GroupBox gbReteConcepto;
        private System.Windows.Forms.StatusStrip StatusConcepto;
        private System.Windows.Forms.ToolStripDropDownButton btnAgregarConcepto;
        private System.Windows.Forms.ToolStripDropDownButton btnEditarConcepto;
        private System.Windows.Forms.DataGridView dgvReteConcepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdConcepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdRetencion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Concepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn CifraUVT;
        private System.Windows.Forms.DataGridViewTextBoxColumn CifraPesos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tarifa;
        private System.Windows.Forms.StatusStrip StatusRubro;
        private System.Windows.Forms.ToolStripDropDownButton btnAgregarRubro;
        private System.Windows.Forms.ToolStripDropDownButton btnEditarRubro;
        private System.Windows.Forms.ToolStripDropDownButton btnEliminarRubro;
        private System.Windows.Forms.ToolStripDropDownButton btnEliminarConcepto;
        private System.Windows.Forms.PictureBox pbImgDian;
    }
}