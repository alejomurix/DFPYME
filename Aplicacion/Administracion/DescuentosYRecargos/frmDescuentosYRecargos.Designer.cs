namespace Aplicacion.Administracion.DescuentosYRecargos
{
    partial class frmDescuentosYRecargos
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

        private System.ComponentModel.ComponentResourceManager miResources =
          new System.ComponentModel.ComponentResourceManager(typeof(frmDescuentosYRecargos ));

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDescuentosYRecargos));
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.tsbtnSalir = new System.Windows.Forms.ToolStripButton();
            this.gbxDescuento = new System.Windows.Forms.GroupBox();
            this.panelMenuGrid = new System.Windows.Forms.Panel();
            this.tsMenuGridDescuento = new System.Windows.Forms.ToolStrip();
            this.tsbtnModificarDescuento = new System.Windows.Forms.ToolStripButton();
            this.tsEliminarDescuento = new System.Windows.Forms.ToolStripButton();
            this.lblDescuento = new System.Windows.Forms.Label();
            this.txtDescuento = new System.Windows.Forms.TextBox();
            this.dgvDescuento = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsMenuDescuento = new System.Windows.Forms.ToolStrip();
            this.tsbtnNuevoDescuento = new System.Windows.Forms.ToolStripButton();
            this.tsbtnGuardarDescunto = new System.Windows.Forms.ToolStripButton();
            this.gbxRecargos = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tsMenuGridRecargo = new System.Windows.Forms.ToolStrip();
            this.tsbtnModificarRecargo = new System.Windows.Forms.ToolStripButton();
            this.tsbtEliminarRecargo = new System.Windows.Forms.ToolStripButton();
            this.lblRecargo = new System.Windows.Forms.Label();
            this.txtRecargo = new System.Windows.Forms.TextBox();
            this.dgvRecargo = new System.Windows.Forms.DataGridView();
            this.IdR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Recargo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsMenuRecargo = new System.Windows.Forms.ToolStrip();
            this.tsbtnNuevoRecargo = new System.Windows.Forms.ToolStripButton();
            this.tsbtnGuardarRecargos = new System.Windows.Forms.ToolStripButton();
            this.tsMenu.SuspendLayout();
            this.gbxDescuento.SuspendLayout();
            this.panelMenuGrid.SuspendLayout();
            this.tsMenuGridDescuento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDescuento)).BeginInit();
            this.tsMenuDescuento.SuspendLayout();
            this.gbxRecargos.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tsMenuGridRecargo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecargo)).BeginInit();
            this.tsMenuRecargo.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMenu
            // 
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnSalir});
            this.tsMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(639, 25);
            this.tsMenu.TabIndex = 0;
            this.tsMenu.Text = "menu";
            // 
            // tsbtnSalir
            // 
            this.tsbtnSalir.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnSalir.Image")));
            this.tsbtnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnSalir.Name = "tsbtnSalir";
            this.tsbtnSalir.Size = new System.Drawing.Size(49, 22);
            this.tsbtnSalir.Text = "Salir";
            this.tsbtnSalir.Click += new System.EventHandler(this.tsbtnSalir_Click);
            // 
            // gbxDescuento
            // 
            this.gbxDescuento.Controls.Add(this.panelMenuGrid);
            this.gbxDescuento.Controls.Add(this.lblDescuento);
            this.gbxDescuento.Controls.Add(this.txtDescuento);
            this.gbxDescuento.Controls.Add(this.dgvDescuento);
            this.gbxDescuento.Controls.Add(this.tsMenuDescuento);
            this.gbxDescuento.Location = new System.Drawing.Point(16, 30);
            this.gbxDescuento.Margin = new System.Windows.Forms.Padding(4);
            this.gbxDescuento.Name = "gbxDescuento";
            this.gbxDescuento.Padding = new System.Windows.Forms.Padding(4);
            this.gbxDescuento.Size = new System.Drawing.Size(292, 393);
            this.gbxDescuento.TabIndex = 1;
            this.gbxDescuento.TabStop = false;
            this.gbxDescuento.Text = "Descuentos";
            // 
            // panelMenuGrid
            // 
            this.panelMenuGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMenuGrid.Controls.Add(this.tsMenuGridDescuento);
            this.panelMenuGrid.Location = new System.Drawing.Point(228, 79);
            this.panelMenuGrid.Margin = new System.Windows.Forms.Padding(4);
            this.panelMenuGrid.Name = "panelMenuGrid";
            this.panelMenuGrid.Size = new System.Drawing.Size(47, 300);
            this.panelMenuGrid.TabIndex = 4;
            // 
            // tsMenuGridDescuento
            // 
            this.tsMenuGridDescuento.Dock = System.Windows.Forms.DockStyle.Right;
            this.tsMenuGridDescuento.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnModificarDescuento,
            this.tsEliminarDescuento});
            this.tsMenuGridDescuento.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.tsMenuGridDescuento.Location = new System.Drawing.Point(20, 0);
            this.tsMenuGridDescuento.Name = "tsMenuGridDescuento";
            this.tsMenuGridDescuento.Size = new System.Drawing.Size(25, 298);
            this.tsMenuGridDescuento.TabIndex = 0;
            this.tsMenuGridDescuento.Text = "Menu de Registro";
            // 
            // tsbtnModificarDescuento
            // 
            this.tsbtnModificarDescuento.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnModificarDescuento.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnModificarDescuento.Image")));
            this.tsbtnModificarDescuento.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnModificarDescuento.Name = "tsbtnModificarDescuento";
            this.tsbtnModificarDescuento.Size = new System.Drawing.Size(22, 20);
            this.tsbtnModificarDescuento.Text = "Modificar Descuento";
            this.tsbtnModificarDescuento.Click += new System.EventHandler(this.tsbtnModificarDescuento_Click);
            // 
            // tsEliminarDescuento
            // 
            this.tsEliminarDescuento.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsEliminarDescuento.Image = ((System.Drawing.Image)(resources.GetObject("tsEliminarDescuento.Image")));
            this.tsEliminarDescuento.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsEliminarDescuento.Margin = new System.Windows.Forms.Padding(1, 1, 0, 2);
            this.tsEliminarDescuento.Name = "tsEliminarDescuento";
            this.tsEliminarDescuento.Size = new System.Drawing.Size(21, 20);
            this.tsEliminarDescuento.Text = "Eliminar Descuento";
            this.tsEliminarDescuento.Click += new System.EventHandler(this.tsEliminarDescuento_Click);
            // 
            // lblDescuento
            // 
            this.lblDescuento.AutoSize = true;
            this.lblDescuento.Location = new System.Drawing.Point(17, 51);
            this.lblDescuento.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescuento.Name = "lblDescuento";
            this.lblDescuento.Size = new System.Drawing.Size(88, 16);
            this.lblDescuento.TabIndex = 3;
            this.lblDescuento.Text = "Descuento %";
            // 
            // txtDescuento
            // 
            this.txtDescuento.Location = new System.Drawing.Point(113, 48);
            this.txtDescuento.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescuento.MaxLength = 3;
            this.txtDescuento.Name = "txtDescuento";
            this.txtDescuento.ReadOnly = true;
            this.txtDescuento.Size = new System.Drawing.Size(162, 22);
            this.txtDescuento.TabIndex = 2;
            this.txtDescuento.Validating += new System.ComponentModel.CancelEventHandler(this.txtDescuento_Validating);
            // 
            // dgvDescuento
            // 
            this.dgvDescuento.AllowUserToAddRows = false;
            this.dgvDescuento.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDescuento.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvDescuento.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvDescuento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDescuento.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Descuento});
            this.dgvDescuento.Location = new System.Drawing.Point(20, 79);
            this.dgvDescuento.Margin = new System.Windows.Forms.Padding(4);
            this.dgvDescuento.Name = "dgvDescuento";
            this.dgvDescuento.Size = new System.Drawing.Size(209, 300);
            this.dgvDescuento.TabIndex = 1;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "IdDescuento";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // Descuento
            // 
            this.Descuento.DataPropertyName = "ValorDescuento";
            this.Descuento.HeaderText = "Descuentos %";
            this.Descuento.Name = "Descuento";
            // 
            // tsMenuDescuento
            // 
            this.tsMenuDescuento.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnNuevoDescuento,
            this.tsbtnGuardarDescunto});
            this.tsMenuDescuento.Location = new System.Drawing.Point(4, 19);
            this.tsMenuDescuento.Name = "tsMenuDescuento";
            this.tsMenuDescuento.Size = new System.Drawing.Size(284, 25);
            this.tsMenuDescuento.TabIndex = 0;
            this.tsMenuDescuento.Text = "toolStrip2";
            // 
            // tsbtnNuevoDescuento
            // 
            this.tsbtnNuevoDescuento.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnNuevoDescuento.Image")));
            this.tsbtnNuevoDescuento.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnNuevoDescuento.Name = "tsbtnNuevoDescuento";
            this.tsbtnNuevoDescuento.Size = new System.Drawing.Size(62, 22);
            this.tsbtnNuevoDescuento.Text = "Nuevo";
            this.tsbtnNuevoDescuento.Click += new System.EventHandler(this.tsbtnNuevoDescuento_Click);
            // 
            // tsbtnGuardarDescunto
            // 
            this.tsbtnGuardarDescunto.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnGuardarDescunto.Image")));
            this.tsbtnGuardarDescunto.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnGuardarDescunto.Name = "tsbtnGuardarDescunto";
            this.tsbtnGuardarDescunto.Size = new System.Drawing.Size(69, 22);
            this.tsbtnGuardarDescunto.Text = "Guardar";
            this.tsbtnGuardarDescunto.Click += new System.EventHandler(this.tsbtnGuardarDescunto_Click);
            // 
            // gbxRecargos
            // 
            this.gbxRecargos.Controls.Add(this.panel1);
            this.gbxRecargos.Controls.Add(this.lblRecargo);
            this.gbxRecargos.Controls.Add(this.txtRecargo);
            this.gbxRecargos.Controls.Add(this.dgvRecargo);
            this.gbxRecargos.Controls.Add(this.tsMenuRecargo);
            this.gbxRecargos.Location = new System.Drawing.Point(328, 30);
            this.gbxRecargos.Margin = new System.Windows.Forms.Padding(4);
            this.gbxRecargos.Name = "gbxRecargos";
            this.gbxRecargos.Padding = new System.Windows.Forms.Padding(4);
            this.gbxRecargos.Size = new System.Drawing.Size(292, 393);
            this.gbxRecargos.TabIndex = 2;
            this.gbxRecargos.TabStop = false;
            this.gbxRecargos.Text = "Recargos";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.tsMenuGridRecargo);
            this.panel1.Location = new System.Drawing.Point(228, 79);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(47, 300);
            this.panel1.TabIndex = 4;
            // 
            // tsMenuGridRecargo
            // 
            this.tsMenuGridRecargo.Dock = System.Windows.Forms.DockStyle.Right;
            this.tsMenuGridRecargo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnModificarRecargo,
            this.tsbtEliminarRecargo});
            this.tsMenuGridRecargo.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.tsMenuGridRecargo.Location = new System.Drawing.Point(20, 0);
            this.tsMenuGridRecargo.Name = "tsMenuGridRecargo";
            this.tsMenuGridRecargo.Size = new System.Drawing.Size(25, 298);
            this.tsMenuGridRecargo.TabIndex = 0;
            this.tsMenuGridRecargo.Text = "Menu de Registro ";
            // 
            // tsbtnModificarRecargo
            // 
            this.tsbtnModificarRecargo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnModificarRecargo.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnModificarRecargo.Image")));
            this.tsbtnModificarRecargo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnModificarRecargo.Name = "tsbtnModificarRecargo";
            this.tsbtnModificarRecargo.Size = new System.Drawing.Size(22, 20);
            this.tsbtnModificarRecargo.Text = "Modificar Recargo";
            this.tsbtnModificarRecargo.Click += new System.EventHandler(this.tsbtnModificarRecargo_Click);
            // 
            // tsbtEliminarRecargo
            // 
            this.tsbtEliminarRecargo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtEliminarRecargo.Image = ((System.Drawing.Image)(resources.GetObject("tsbtEliminarRecargo.Image")));
            this.tsbtEliminarRecargo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtEliminarRecargo.Margin = new System.Windows.Forms.Padding(1, 1, 0, 2);
            this.tsbtEliminarRecargo.Name = "tsbtEliminarRecargo";
            this.tsbtEliminarRecargo.Size = new System.Drawing.Size(21, 20);
            this.tsbtEliminarRecargo.Text = "Eliminar Recargo";
            this.tsbtEliminarRecargo.Click += new System.EventHandler(this.tsbtEliminarRecargo_Click);
            // 
            // lblRecargo
            // 
            this.lblRecargo.AutoSize = true;
            this.lblRecargo.Location = new System.Drawing.Point(17, 51);
            this.lblRecargo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRecargo.Name = "lblRecargo";
            this.lblRecargo.Size = new System.Drawing.Size(76, 16);
            this.lblRecargo.TabIndex = 3;
            this.lblRecargo.Text = "Recargo %";
            // 
            // txtRecargo
            // 
            this.txtRecargo.Location = new System.Drawing.Point(113, 48);
            this.txtRecargo.Margin = new System.Windows.Forms.Padding(4);
            this.txtRecargo.MaxLength = 3;
            this.txtRecargo.Name = "txtRecargo";
            this.txtRecargo.ReadOnly = true;
            this.txtRecargo.Size = new System.Drawing.Size(162, 22);
            this.txtRecargo.TabIndex = 2;
            this.txtRecargo.Validating += new System.ComponentModel.CancelEventHandler(this.txtRecargo_Validating);
            // 
            // dgvRecargo
            // 
            this.dgvRecargo.AllowUserToAddRows = false;
            this.dgvRecargo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRecargo.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvRecargo.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvRecargo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecargo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdR,
            this.Recargo});
            this.dgvRecargo.Location = new System.Drawing.Point(20, 79);
            this.dgvRecargo.Margin = new System.Windows.Forms.Padding(4);
            this.dgvRecargo.Name = "dgvRecargo";
            this.dgvRecargo.Size = new System.Drawing.Size(209, 300);
            this.dgvRecargo.TabIndex = 1;
            // 
            // IdR
            // 
            this.IdR.DataPropertyName = "IdRecargo";
            this.IdR.HeaderText = "Id";
            this.IdR.Name = "IdR";
            this.IdR.Visible = false;
            // 
            // Recargo
            // 
            this.Recargo.DataPropertyName = "ValorRecargo";
            this.Recargo.HeaderText = "Recargos %";
            this.Recargo.Name = "Recargo";
            // 
            // tsMenuRecargo
            // 
            this.tsMenuRecargo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnNuevoRecargo,
            this.tsbtnGuardarRecargos});
            this.tsMenuRecargo.Location = new System.Drawing.Point(4, 19);
            this.tsMenuRecargo.Name = "tsMenuRecargo";
            this.tsMenuRecargo.Size = new System.Drawing.Size(284, 25);
            this.tsMenuRecargo.TabIndex = 0;
            this.tsMenuRecargo.Text = "toolStrip2";
            // 
            // tsbtnNuevoRecargo
            // 
            this.tsbtnNuevoRecargo.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnNuevoRecargo.Image")));
            this.tsbtnNuevoRecargo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnNuevoRecargo.Name = "tsbtnNuevoRecargo";
            this.tsbtnNuevoRecargo.Size = new System.Drawing.Size(62, 22);
            this.tsbtnNuevoRecargo.Text = "Nuevo";
            this.tsbtnNuevoRecargo.Click += new System.EventHandler(this.tsbtnNuevoRecargo_Click);
            // 
            // tsbtnGuardarRecargos
            // 
            this.tsbtnGuardarRecargos.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnGuardarRecargos.Image")));
            this.tsbtnGuardarRecargos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnGuardarRecargos.Name = "tsbtnGuardarRecargos";
            this.tsbtnGuardarRecargos.Size = new System.Drawing.Size(69, 22);
            this.tsbtnGuardarRecargos.Text = "Guardar";
            this.tsbtnGuardarRecargos.Click += new System.EventHandler(this.tsbtnGuardarRecargos_Click);
            // 
            // frmDescuentosYRecargos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 436);
            this.Controls.Add(this.gbxRecargos);
            this.Controls.Add(this.gbxDescuento);
            this.Controls.Add(this.tsMenu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDescuentosYRecargos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Descuentos Y Recargos";
            this.Load += new System.EventHandler(this.frmDescuentosYRecargos_Load);
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.gbxDescuento.ResumeLayout(false);
            this.gbxDescuento.PerformLayout();
            this.panelMenuGrid.ResumeLayout(false);
            this.panelMenuGrid.PerformLayout();
            this.tsMenuGridDescuento.ResumeLayout(false);
            this.tsMenuGridDescuento.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDescuento)).EndInit();
            this.tsMenuDescuento.ResumeLayout(false);
            this.tsMenuDescuento.PerformLayout();
            this.gbxRecargos.ResumeLayout(false);
            this.gbxRecargos.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tsMenuGridRecargo.ResumeLayout(false);
            this.tsMenuGridRecargo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecargo)).EndInit();
            this.tsMenuRecargo.ResumeLayout(false);
            this.tsMenuRecargo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.GroupBox gbxDescuento;
        private System.Windows.Forms.ToolStrip tsMenuDescuento;
        private System.Windows.Forms.ToolStripButton tsbtnSalir;
        private System.Windows.Forms.Label lblDescuento;
        private System.Windows.Forms.TextBox txtDescuento;
        private System.Windows.Forms.DataGridView dgvDescuento;
        private System.Windows.Forms.ToolStripButton tsbtnGuardarDescunto;
        private System.Windows.Forms.ToolStripButton tsbtnNuevoDescuento;
        private System.Windows.Forms.Panel panelMenuGrid;
        private System.Windows.Forms.ToolStrip tsMenuGridDescuento;
        private System.Windows.Forms.ToolStripButton tsbtnModificarDescuento;
        private System.Windows.Forms.ToolStripButton tsEliminarDescuento;
        private System.Windows.Forms.GroupBox gbxRecargos;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip tsMenuGridRecargo;
        private System.Windows.Forms.ToolStripButton tsbtnModificarRecargo;
        private System.Windows.Forms.ToolStripButton tsbtEliminarRecargo;
        private System.Windows.Forms.Label lblRecargo;
        private System.Windows.Forms.TextBox txtRecargo;
        private System.Windows.Forms.DataGridView dgvRecargo;
        private System.Windows.Forms.ToolStrip tsMenuRecargo;
        private System.Windows.Forms.ToolStripButton tsbtnGuardarRecargos;
        private System.Windows.Forms.ToolStripButton tsbtnNuevoRecargo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descuento;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdR;
        private System.Windows.Forms.DataGridViewTextBoxColumn Recargo;
    }
}