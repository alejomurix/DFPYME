namespace Aplicacion.Administracion.Descuentos
{
    partial class FrmConsulta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConsulta));
            this.gbDescuentos = new System.Windows.Forms.GroupBox();
            this.tsMenuDescuento = new System.Windows.Forms.ToolStrip();
            this.btnNuevoDescuento = new System.Windows.Forms.ToolStripButton();
            this.dgDescuentos = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Concepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Porcentaje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Aplica = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbGrupos = new System.Windows.Forms.GroupBox();
            this.tsMenuGrupo = new System.Windows.Forms.ToolStrip();
            this.btnNuevoGrupo = new System.Windows.Forms.ToolStripButton();
            this.dgvGrupos = new System.Windows.Forms.DataGridView();
            this.IdGrupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoGrupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.tsBtnSalir = new System.Windows.Forms.ToolStripButton();
            this.gbDescuentos.SuspendLayout();
            this.tsMenuDescuento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDescuentos)).BeginInit();
            this.gbGrupos.SuspendLayout();
            this.tsMenuGrupo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrupos)).BeginInit();
            this.tsMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbDescuentos
            // 
            this.gbDescuentos.Controls.Add(this.tsMenuDescuento);
            this.gbDescuentos.Controls.Add(this.dgDescuentos);
            this.gbDescuentos.Location = new System.Drawing.Point(165, 33);
            this.gbDescuentos.Name = "gbDescuentos";
            this.gbDescuentos.Size = new System.Drawing.Size(673, 349);
            this.gbDescuentos.TabIndex = 0;
            this.gbDescuentos.TabStop = false;
            this.gbDescuentos.Text = "Descuentos";
            // 
            // tsMenuDescuento
            // 
            this.tsMenuDescuento.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNuevoDescuento});
            this.tsMenuDescuento.Location = new System.Drawing.Point(3, 18);
            this.tsMenuDescuento.Name = "tsMenuDescuento";
            this.tsMenuDescuento.Size = new System.Drawing.Size(667, 25);
            this.tsMenuDescuento.TabIndex = 5;
            this.tsMenuDescuento.Text = "Menu";
            // 
            // btnNuevoDescuento
            // 
            this.btnNuevoDescuento.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.btnNuevoDescuento.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevoDescuento.Image")));
            this.btnNuevoDescuento.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNuevoDescuento.Name = "btnNuevoDescuento";
            this.btnNuevoDescuento.Size = new System.Drawing.Size(89, 22);
            this.btnNuevoDescuento.Text = "Nuevo [F4]";
            this.btnNuevoDescuento.ToolTipText = "Nuevo [F3]";
            this.btnNuevoDescuento.Click += new System.EventHandler(this.btnNuevoDescuento_Click);
            // 
            // dgDescuentos
            // 
            this.dgDescuentos.AllowUserToAddRows = false;
            this.dgDescuentos.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgDescuentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDescuentos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Codigo,
            this.Concepto,
            this.Cuenta,
            this.Porcentaje,
            this.Valor,
            this.Aplica});
            this.dgDescuentos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgDescuentos.Location = new System.Drawing.Point(11, 48);
            this.dgDescuentos.Name = "dgDescuentos";
            this.dgDescuentos.RowHeadersVisible = false;
            this.dgDescuentos.Size = new System.Drawing.Size(648, 286);
            this.dgDescuentos.TabIndex = 0;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "iddescto";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // Codigo
            // 
            this.Codigo.DataPropertyName = "codigo";
            this.Codigo.HeaderText = "Código";
            this.Codigo.Name = "Codigo";
            this.Codigo.Width = 70;
            // 
            // Concepto
            // 
            this.Concepto.DataPropertyName = "concepto";
            this.Concepto.HeaderText = "Concepto";
            this.Concepto.Name = "Concepto";
            this.Concepto.Width = 300;
            // 
            // Cuenta
            // 
            this.Cuenta.DataPropertyName = "numero";
            this.Cuenta.HeaderText = "Cuenta";
            this.Cuenta.Name = "Cuenta";
            // 
            // Porcentaje
            // 
            this.Porcentaje.DataPropertyName = "porcentaje";
            this.Porcentaje.HeaderText = "%";
            this.Porcentaje.Name = "Porcentaje";
            this.Porcentaje.Width = 50;
            // 
            // Valor
            // 
            this.Valor.DataPropertyName = "valor";
            this.Valor.HeaderText = "Valor";
            this.Valor.Name = "Valor";
            // 
            // Aplica
            // 
            this.Aplica.DataPropertyName = "aplica";
            this.Aplica.HeaderText = "Aplica";
            this.Aplica.Name = "Aplica";
            this.Aplica.Visible = false;
            // 
            // gbGrupos
            // 
            this.gbGrupos.Controls.Add(this.tsMenuGrupo);
            this.gbGrupos.Controls.Add(this.dgvGrupos);
            this.gbGrupos.Location = new System.Drawing.Point(14, 33);
            this.gbGrupos.Name = "gbGrupos";
            this.gbGrupos.Size = new System.Drawing.Size(145, 349);
            this.gbGrupos.TabIndex = 1;
            this.gbGrupos.TabStop = false;
            this.gbGrupos.Text = "Grupos";
            // 
            // tsMenuGrupo
            // 
            this.tsMenuGrupo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNuevoGrupo});
            this.tsMenuGrupo.Location = new System.Drawing.Point(3, 18);
            this.tsMenuGrupo.Name = "tsMenuGrupo";
            this.tsMenuGrupo.Size = new System.Drawing.Size(139, 25);
            this.tsMenuGrupo.TabIndex = 4;
            this.tsMenuGrupo.Text = "Menu";
            // 
            // btnNuevoGrupo
            // 
            this.btnNuevoGrupo.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.btnNuevoGrupo.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevoGrupo.Image")));
            this.btnNuevoGrupo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNuevoGrupo.Name = "btnNuevoGrupo";
            this.btnNuevoGrupo.Size = new System.Drawing.Size(89, 22);
            this.btnNuevoGrupo.Text = "Nuevo [F3]";
            this.btnNuevoGrupo.ToolTipText = "Nuevo [F3]";
            this.btnNuevoGrupo.Click += new System.EventHandler(this.btnNuevoGrupo_Click);
            // 
            // dgvGrupos
            // 
            this.dgvGrupos.AllowUserToAddRows = false;
            this.dgvGrupos.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvGrupos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrupos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdGrupo,
            this.CodigoGrupo});
            this.dgvGrupos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvGrupos.Location = new System.Drawing.Point(12, 48);
            this.dgvGrupos.Name = "dgvGrupos";
            this.dgvGrupos.RowHeadersVisible = false;
            this.dgvGrupos.Size = new System.Drawing.Size(121, 286);
            this.dgvGrupos.TabIndex = 1;
            this.dgvGrupos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGrupos_CellClick);
            this.dgvGrupos.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgvGrupos_KeyUp);
            // 
            // IdGrupo
            // 
            this.IdGrupo.DataPropertyName = "id";
            this.IdGrupo.HeaderText = "Id";
            this.IdGrupo.Name = "IdGrupo";
            this.IdGrupo.Visible = false;
            // 
            // CodigoGrupo
            // 
            this.CodigoGrupo.DataPropertyName = "codigo";
            this.CodigoGrupo.HeaderText = "Código";
            this.CodigoGrupo.Name = "CodigoGrupo";
            // 
            // tsMenu
            // 
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnSalir});
            this.tsMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(850, 25);
            this.tsMenu.TabIndex = 2;
            this.tsMenu.Text = "toolStrip1";
            // 
            // tsBtnSalir
            // 
            this.tsBtnSalir.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsBtnSalir.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnSalir.Image")));
            this.tsBtnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnSalir.Name = "tsBtnSalir";
            this.tsBtnSalir.Size = new System.Drawing.Size(87, 22);
            this.tsBtnSalir.Text = "Salir [ESC]";
            this.tsBtnSalir.Click += new System.EventHandler(this.tsBtnSalir_Click);
            // 
            // FrmConsulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(850, 397);
            this.Controls.Add(this.tsMenu);
            this.Controls.Add(this.gbGrupos);
            this.Controls.Add(this.gbDescuentos);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmConsulta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Descuentos";
            this.Load += new System.EventHandler(this.FrmConsulta_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmConsulta_KeyDown);
            this.gbDescuentos.ResumeLayout(false);
            this.gbDescuentos.PerformLayout();
            this.tsMenuDescuento.ResumeLayout(false);
            this.tsMenuDescuento.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDescuentos)).EndInit();
            this.gbGrupos.ResumeLayout(false);
            this.gbGrupos.PerformLayout();
            this.tsMenuGrupo.ResumeLayout(false);
            this.tsMenuGrupo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrupos)).EndInit();
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDescuentos;
        private System.Windows.Forms.GroupBox gbGrupos;
        private System.Windows.Forms.DataGridView dgDescuentos;
        private System.Windows.Forms.DataGridView dgvGrupos;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdGrupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoGrupo;
        private System.Windows.Forms.ToolStrip tsMenuGrupo;
        private System.Windows.Forms.ToolStripButton btnNuevoGrupo;
        private System.Windows.Forms.ToolStrip tsMenuDescuento;
        private System.Windows.Forms.ToolStripButton btnNuevoDescuento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Concepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Porcentaje;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Aplica;
        private System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.ToolStripButton tsBtnSalir;
    }
}