namespace Aplicacion.Ventas.Ingresos
{
    partial class FrmConsultaConcepto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConsultaConcepto));
            this.gbConsulta = new System.Windows.Forms.GroupBox();
            this.dgvConcepto = new System.Windows.Forms.DataGridView();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtCriterio = new System.Windows.Forms.TextBox();
            this.cbCriterio = new System.Windows.Forms.ComboBox();
            this.gbConsulta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConcepto)).BeginInit();
            this.SuspendLayout();
            // 
            // gbConsulta
            // 
            this.gbConsulta.Controls.Add(this.cbCriterio);
            this.gbConsulta.Controls.Add(this.dgvConcepto);
            this.gbConsulta.Controls.Add(this.txtCriterio);
            this.gbConsulta.Controls.Add(this.btnBuscar);
            this.gbConsulta.Location = new System.Drawing.Point(10, 12);
            this.gbConsulta.Name = "gbConsulta";
            this.gbConsulta.Size = new System.Drawing.Size(401, 353);
            this.gbConsulta.TabIndex = 0;
            this.gbConsulta.TabStop = false;
            // 
            // dgvConcepto
            // 
            this.dgvConcepto.AllowUserToAddRows = false;
            this.dgvConcepto.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvConcepto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConcepto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.Nombre});
            this.dgvConcepto.Location = new System.Drawing.Point(3, 40);
            this.dgvConcepto.Name = "dgvConcepto";
            this.dgvConcepto.RowHeadersVisible = false;
            this.dgvConcepto.Size = new System.Drawing.Size(395, 307);
            this.dgvConcepto.TabIndex = 0;
            this.dgvConcepto.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvConcepto_CellClick);
            // 
            // Codigo
            // 
            this.Codigo.DataPropertyName = "codigo";
            this.Codigo.HeaderText = "Códgo";
            this.Codigo.Name = "Codigo";
            this.Codigo.Width = 120;
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "nombre";
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.Width = 270;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(360, 10);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(24, 24);
            this.btnBuscar.TabIndex = 1;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtCriterio
            // 
            this.txtCriterio.Location = new System.Drawing.Point(6, 12);
            this.txtCriterio.Name = "txtCriterio";
            this.txtCriterio.Size = new System.Drawing.Size(348, 22);
            this.txtCriterio.TabIndex = 0;
            this.txtCriterio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCriterio_KeyPress);
            // 
            // cbCriterio
            // 
            this.cbCriterio.DisplayMember = "Nombre";
            this.cbCriterio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCriterio.FormattingEnabled = true;
            this.cbCriterio.Location = new System.Drawing.Point(387, 11);
            this.cbCriterio.Name = "cbCriterio";
            this.cbCriterio.Size = new System.Drawing.Size(10, 24);
            this.cbCriterio.TabIndex = 2;
            this.cbCriterio.ValueMember = "Id";
            this.cbCriterio.Visible = false;
            this.cbCriterio.SelectionChangeCommitted += new System.EventHandler(this.cbCriterio_SelectionChangeCommitted);
            // 
            // FrmConsultaConcepto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(422, 377);
            this.Controls.Add(this.gbConsulta);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmConsultaConcepto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Conceptos";
            this.Load += new System.EventHandler(this.FrmConsultaConcepto_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmConsultaConcepto_KeyDown);
            this.gbConsulta.ResumeLayout(false);
            this.gbConsulta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConcepto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbConsulta;
        private System.Windows.Forms.DataGridView dgvConcepto;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtCriterio;
        private System.Windows.Forms.ComboBox cbCriterio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
    }
}