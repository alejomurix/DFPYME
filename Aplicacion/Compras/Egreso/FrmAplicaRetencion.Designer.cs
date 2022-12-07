namespace Aplicacion.Compras.Egreso
{
    partial class FrmAplicaRetencion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAplicaRetencion));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbRubro = new System.Windows.Forms.GroupBox();
            this.dgvRubro = new System.Windows.Forms.DataGridView();
            this.IdRubro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreRubro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbAplica = new System.Windows.Forms.GroupBox();
            this.StatusReteAplica = new System.Windows.Forms.StatusStrip();
            this.btnAgregar = new System.Windows.Forms.ToolStripDropDownButton();
            this.dgvReteConceptoAplica = new System.Windows.Forms.DataGridView();
            this.IdAplica = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdConceptoAplica = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdRetencionAplica = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RubroAplcia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ConceptoAplica = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CifraUVTAplica = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CifraPesosAplica = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TarifaAplica = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAplicar = new System.Windows.Forms.Button();
            this.btnNoAplica = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.pbImgDian = new System.Windows.Forms.PictureBox();
            this.gbRubro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRubro)).BeginInit();
            this.gbAplica.SuspendLayout();
            this.StatusReteAplica.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReteConceptoAplica)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImgDian)).BeginInit();
            this.SuspendLayout();
            // 
            // gbRubro
            // 
            this.gbRubro.Controls.Add(this.dgvRubro);
            this.gbRubro.Location = new System.Drawing.Point(6, 0);
            this.gbRubro.Margin = new System.Windows.Forms.Padding(2);
            this.gbRubro.Name = "gbRubro";
            this.gbRubro.Padding = new System.Windows.Forms.Padding(2);
            this.gbRubro.Size = new System.Drawing.Size(762, 158);
            this.gbRubro.TabIndex = 3;
            this.gbRubro.TabStop = false;
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
            this.dgvRubro.Location = new System.Drawing.Point(5, 12);
            this.dgvRubro.Margin = new System.Windows.Forms.Padding(2);
            this.dgvRubro.Name = "dgvRubro";
            this.dgvRubro.RowHeadersVisible = false;
            this.dgvRubro.Size = new System.Drawing.Size(751, 143);
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
            // gbAplica
            // 
            this.gbAplica.Controls.Add(this.StatusReteAplica);
            this.gbAplica.Controls.Add(this.dgvReteConceptoAplica);
            this.gbAplica.Location = new System.Drawing.Point(6, 159);
            this.gbAplica.Margin = new System.Windows.Forms.Padding(2);
            this.gbAplica.Name = "gbAplica";
            this.gbAplica.Padding = new System.Windows.Forms.Padding(2);
            this.gbAplica.Size = new System.Drawing.Size(1249, 196);
            this.gbAplica.TabIndex = 4;
            this.gbAplica.TabStop = false;
            // 
            // StatusReteAplica
            // 
            this.StatusReteAplica.Dock = System.Windows.Forms.DockStyle.Right;
            this.StatusReteAplica.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.StatusReteAplica.GripMargin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.StatusReteAplica.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAgregar});
            this.StatusReteAplica.Location = new System.Drawing.Point(1214, 17);
            this.StatusReteAplica.Name = "StatusReteAplica";
            this.StatusReteAplica.Padding = new System.Windows.Forms.Padding(1, 2, 1, 21);
            this.StatusReteAplica.Size = new System.Drawing.Size(33, 177);
            this.StatusReteAplica.TabIndex = 3;
            this.StatusReteAplica.Text = "statusStrip1";
            // 
            // btnAgregar
            // 
            this.btnAgregar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAgregar.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregar.Image")));
            this.btnAgregar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.ShowDropDownArrow = false;
            this.btnAgregar.Size = new System.Drawing.Size(31, 20);
            this.btnAgregar.Text = "Eliminar Seleccionado(s)";
            this.btnAgregar.Visible = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // dgvReteConceptoAplica
            // 
            this.dgvReteConceptoAplica.AllowUserToAddRows = false;
            this.dgvReteConceptoAplica.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvReteConceptoAplica.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReteConceptoAplica.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdAplica,
            this.IdConceptoAplica,
            this.IdRetencionAplica,
            this.RubroAplcia,
            this.ConceptoAplica,
            this.CifraUVTAplica,
            this.CifraPesosAplica,
            this.TarifaAplica});
            this.dgvReteConceptoAplica.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvReteConceptoAplica.Location = new System.Drawing.Point(6, 18);
            this.dgvReteConceptoAplica.Margin = new System.Windows.Forms.Padding(2);
            this.dgvReteConceptoAplica.Name = "dgvReteConceptoAplica";
            this.dgvReteConceptoAplica.Size = new System.Drawing.Size(1218, 170);
            this.dgvReteConceptoAplica.TabIndex = 1;
            // 
            // IdAplica
            // 
            this.IdAplica.DataPropertyName = "id";
            this.IdAplica.HeaderText = "Id";
            this.IdAplica.Name = "IdAplica";
            this.IdAplica.Visible = false;
            this.IdAplica.Width = 30;
            // 
            // IdConceptoAplica
            // 
            this.IdConceptoAplica.DataPropertyName = "IdConceptoAplica";
            this.IdConceptoAplica.HeaderText = "IdC";
            this.IdConceptoAplica.Name = "IdConceptoAplica";
            this.IdConceptoAplica.Visible = false;
            this.IdConceptoAplica.Width = 30;
            // 
            // IdRetencionAplica
            // 
            this.IdRetencionAplica.DataPropertyName = "IdRetencionAplica";
            this.IdRetencionAplica.HeaderText = "Id";
            this.IdRetencionAplica.Name = "IdRetencionAplica";
            this.IdRetencionAplica.Visible = false;
            this.IdRetencionAplica.Width = 30;
            // 
            // RubroAplcia
            // 
            this.RubroAplcia.DataPropertyName = "RubroAplica";
            this.RubroAplcia.HeaderText = "Rubro";
            this.RubroAplcia.Name = "RubroAplcia";
            this.RubroAplcia.Width = 180;
            // 
            // ConceptoAplica
            // 
            this.ConceptoAplica.DataPropertyName = "ConceptoAplica";
            this.ConceptoAplica.HeaderText = "Concepto";
            this.ConceptoAplica.Name = "ConceptoAplica";
            this.ConceptoAplica.Width = 730;
            // 
            // CifraUVTAplica
            // 
            this.CifraUVTAplica.DataPropertyName = "CifraUVTAplica";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Format = "N1";
            dataGridViewCellStyle1.NullValue = null;
            this.CifraUVTAplica.DefaultCellStyle = dataGridViewCellStyle1;
            this.CifraUVTAplica.HeaderText = "Cifra UVT";
            this.CifraUVTAplica.Name = "CifraUVTAplica";
            this.CifraUVTAplica.Width = 90;
            // 
            // CifraPesosAplica
            // 
            this.CifraPesosAplica.DataPropertyName = "CifraPesosAplica";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "N1";
            dataGridViewCellStyle2.NullValue = null;
            this.CifraPesosAplica.DefaultCellStyle = dataGridViewCellStyle2;
            this.CifraPesosAplica.HeaderText = "Cifra Pesos";
            this.CifraPesosAplica.Name = "CifraPesosAplica";
            // 
            // TarifaAplica
            // 
            this.TarifaAplica.DataPropertyName = "TarifaAplica";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "N1";
            dataGridViewCellStyle3.NullValue = null;
            this.TarifaAplica.DefaultCellStyle = dataGridViewCellStyle3;
            this.TarifaAplica.HeaderText = "Tarifa%";
            this.TarifaAplica.Name = "TarifaAplica";
            this.TarifaAplica.Width = 70;
            // 
            // btnAplicar
            // 
            this.btnAplicar.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnAplicar.Location = new System.Drawing.Point(944, 366);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(75, 23);
            this.btnAplicar.TabIndex = 5;
            this.btnAplicar.Text = "Aplicar";
            this.btnAplicar.UseVisualStyleBackColor = true;
            this.btnAplicar.Click += new System.EventHandler(this.btnAplicar_Click);
            // 
            // btnNoAplica
            // 
            this.btnNoAplica.DialogResult = System.Windows.Forms.DialogResult.No;
            this.btnNoAplica.Location = new System.Drawing.Point(1040, 366);
            this.btnNoAplica.Name = "btnNoAplica";
            this.btnNoAplica.Size = new System.Drawing.Size(90, 23);
            this.btnNoAplica.TabIndex = 6;
            this.btnNoAplica.Text = "No Aplica";
            this.btnNoAplica.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Ignore;
            this.btnCancelar.Location = new System.Drawing.Point(1155, 366);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // pbImgDian
            // 
            this.pbImgDian.Image = ((System.Drawing.Image)(resources.GetObject("pbImgDian.Image")));
            this.pbImgDian.Location = new System.Drawing.Point(786, 7);
            this.pbImgDian.Name = "pbImgDian";
            this.pbImgDian.Size = new System.Drawing.Size(452, 151);
            this.pbImgDian.TabIndex = 8;
            this.pbImgDian.TabStop = false;
            // 
            // FrmAplicaRetencion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1258, 401);
            this.Controls.Add(this.pbImgDian);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnNoAplica);
            this.Controls.Add(this.btnAplicar);
            this.Controls.Add(this.gbAplica);
            this.Controls.Add(this.gbRubro);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAplicaRetencion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aplicar Retenciones";
            this.Load += new System.EventHandler(this.FrmAplicaRetencion_Load);
            this.gbRubro.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRubro)).EndInit();
            this.gbAplica.ResumeLayout(false);
            this.gbAplica.PerformLayout();
            this.StatusReteAplica.ResumeLayout(false);
            this.StatusReteAplica.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReteConceptoAplica)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImgDian)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbRubro;
        private System.Windows.Forms.DataGridView dgvRubro;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdRubro;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreRubro;
        private System.Windows.Forms.GroupBox gbAplica;
        private System.Windows.Forms.DataGridView dgvReteConceptoAplica;
        private System.Windows.Forms.StatusStrip StatusReteAplica;
        private System.Windows.Forms.ToolStripDropDownButton btnAgregar;
        private System.Windows.Forms.Button btnAplicar;
        private System.Windows.Forms.Button btnNoAplica;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdAplica;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdConceptoAplica;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdRetencionAplica;
        private System.Windows.Forms.DataGridViewTextBoxColumn RubroAplcia;
        private System.Windows.Forms.DataGridViewTextBoxColumn ConceptoAplica;
        private System.Windows.Forms.DataGridViewTextBoxColumn CifraUVTAplica;
        private System.Windows.Forms.DataGridViewTextBoxColumn CifraPesosAplica;
        private System.Windows.Forms.DataGridViewTextBoxColumn TarifaAplica;
        private System.Windows.Forms.PictureBox pbImgDian;

    }
}