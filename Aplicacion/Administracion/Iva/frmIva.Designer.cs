namespace Aplicacion.Administracion.Iva
{
    partial class frmIva
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
          new System.ComponentModel.ComponentResourceManager(typeof(frmIva));


        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIva));
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.tsBtnNuevo = new System.Windows.Forms.ToolStripButton();
            this.tsBtnGuardar = new System.Windows.Forms.ToolStripButton();
            this.tsBtnSalir = new System.Windows.Forms.ToolStripButton();
            this.gbxIva = new System.Windows.Forms.GroupBox();
            this.lblIva = new System.Windows.Forms.Label();
            this.txtIva = new System.Windows.Forms.TextBox();
            this.dgvIva = new System.Windows.Forms.DataGridView();
            this.idIva = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IVA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelMenuGrid = new System.Windows.Forms.Panel();
            this.tsMenuGrid = new System.Windows.Forms.ToolStrip();
            this.tsbtnModificar = new System.Windows.Forms.ToolStripButton();
            this.tsEliminar = new System.Windows.Forms.ToolStripButton();
            this.tsMenu.SuspendLayout();
            this.gbxIva.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIva)).BeginInit();
            this.panelMenuGrid.SuspendLayout();
            this.tsMenuGrid.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMenu
            // 
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnNuevo,
            this.tsBtnGuardar,
            this.tsBtnSalir});
            this.tsMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(287, 25);
            this.tsMenu.TabIndex = 0;
            this.tsMenu.Text = "toolStrip1";
            // 
            // tsBtnNuevo
            // 
            this.tsBtnNuevo.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnNuevo.Image")));
            this.tsBtnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnNuevo.Name = "tsBtnNuevo";
            this.tsBtnNuevo.Size = new System.Drawing.Size(65, 22);
            this.tsBtnNuevo.Text = "Nuevo ";
            this.tsBtnNuevo.Click += new System.EventHandler(this.tsBtnNuevo_Click);
            // 
            // tsBtnGuardar
            // 
            this.tsBtnGuardar.Enabled = false;
            this.tsBtnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnGuardar.Image")));
            this.tsBtnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnGuardar.Name = "tsBtnGuardar";
            this.tsBtnGuardar.Size = new System.Drawing.Size(69, 22);
            this.tsBtnGuardar.Text = "Guardar";
            this.tsBtnGuardar.Click += new System.EventHandler(this.tsBtnGuardar_Click);
            // 
            // tsBtnSalir
            // 
            this.tsBtnSalir.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnSalir.Image")));
            this.tsBtnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnSalir.Name = "tsBtnSalir";
            this.tsBtnSalir.Size = new System.Drawing.Size(49, 22);
            this.tsBtnSalir.Text = "Salir";
            this.tsBtnSalir.Click += new System.EventHandler(this.tsBtnSalir_Click);
            // 
            // gbxIva
            // 
            this.gbxIva.Controls.Add(this.lblIva);
            this.gbxIva.Controls.Add(this.txtIva);
            this.gbxIva.Controls.Add(this.dgvIva);
            this.gbxIva.Controls.Add(this.panelMenuGrid);
            this.gbxIva.Location = new System.Drawing.Point(12, 28);
            this.gbxIva.Name = "gbxIva";
            this.gbxIva.Size = new System.Drawing.Size(261, 321);
            this.gbxIva.TabIndex = 1;
            this.gbxIva.TabStop = false;
            this.gbxIva.Text = "Información IVA";
            // 
            // lblIva
            // 
            this.lblIva.AutoSize = true;
            this.lblIva.Location = new System.Drawing.Point(10, 20);
            this.lblIva.Name = "lblIva";
            this.lblIva.Size = new System.Drawing.Size(44, 16);
            this.lblIva.TabIndex = 1;
            this.lblIva.Text = "IVA %";
            // 
            // txtIva
            // 
            this.txtIva.Location = new System.Drawing.Point(10, 40);
            this.txtIva.MaxLength = 4;
            this.txtIva.Name = "txtIva";
            this.txtIva.ReadOnly = true;
            this.txtIva.Size = new System.Drawing.Size(190, 22);
            this.txtIva.TabIndex = 0;
            this.txtIva.Validating += new System.ComponentModel.CancelEventHandler(this.txtIva_Validating);
            // 
            // dgvIva
            // 
            this.dgvIva.AllowUserToAddRows = false;
            this.dgvIva.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvIva.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvIva.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvIva.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIva.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idIva,
            this.IVA});
            this.dgvIva.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvIva.GridColor = System.Drawing.SystemColors.Window;
            this.dgvIva.Location = new System.Drawing.Point(10, 69);
            this.dgvIva.Name = "dgvIva";
            this.dgvIva.Size = new System.Drawing.Size(192, 242);
            this.dgvIva.TabIndex = 3;
            // 
            // idIva
            // 
            this.idIva.DataPropertyName = "IdIva";
            this.idIva.HeaderText = "Idiva";
            this.idIva.Name = "idIva";
            this.idIva.Visible = false;
            // 
            // IVA
            // 
            this.IVA.DataPropertyName = "PorcentajeIva";
            this.IVA.HeaderText = "IVA %";
            this.IVA.Name = "IVA";
            // 
            // panelMenuGrid
            // 
            this.panelMenuGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMenuGrid.Controls.Add(this.tsMenuGrid);
            this.panelMenuGrid.Location = new System.Drawing.Point(202, 69);
            this.panelMenuGrid.Name = "panelMenuGrid";
            this.panelMenuGrid.Size = new System.Drawing.Size(45, 242);
            this.panelMenuGrid.TabIndex = 2;
            // 
            // tsMenuGrid
            // 
            this.tsMenuGrid.Dock = System.Windows.Forms.DockStyle.Right;
            this.tsMenuGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnModificar,
            this.tsEliminar});
            this.tsMenuGrid.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.tsMenuGrid.Location = new System.Drawing.Point(18, 0);
            this.tsMenuGrid.Name = "tsMenuGrid";
            this.tsMenuGrid.Size = new System.Drawing.Size(25, 240);
            this.tsMenuGrid.TabIndex = 0;
            this.tsMenuGrid.Text = "Menu de Registro";
            // 
            // tsbtnModificar
            // 
            this.tsbtnModificar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnModificar.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnModificar.Image")));
            this.tsbtnModificar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnModificar.Name = "tsbtnModificar";
            this.tsbtnModificar.Size = new System.Drawing.Size(22, 20);
            this.tsbtnModificar.Text = "Modificar";
            this.tsbtnModificar.Click += new System.EventHandler(this.tsbtnModificar_Click);
            // 
            // tsEliminar
            // 
            this.tsEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsEliminar.Image = ((System.Drawing.Image)(resources.GetObject("tsEliminar.Image")));
            this.tsEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsEliminar.Margin = new System.Windows.Forms.Padding(1, 1, 0, 2);
            this.tsEliminar.Name = "tsEliminar";
            this.tsEliminar.Size = new System.Drawing.Size(21, 20);
            this.tsEliminar.Text = "Eliminar Registro";
            this.tsEliminar.Click += new System.EventHandler(this.tsEliminar_Click);
            // 
            // frmIva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(287, 358);
            this.Controls.Add(this.tsMenu);
            this.Controls.Add(this.gbxIva);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmIva";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IVA";
            this.Load += new System.EventHandler(this.frmIva_Load);
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.gbxIva.ResumeLayout(false);
            this.gbxIva.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIva)).EndInit();
            this.panelMenuGrid.ResumeLayout(false);
            this.panelMenuGrid.PerformLayout();
            this.tsMenuGrid.ResumeLayout(false);
            this.tsMenuGrid.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.ToolStripButton tsBtnGuardar;
        private System.Windows.Forms.GroupBox gbxIva;
        private System.Windows.Forms.TextBox txtIva;
        private System.Windows.Forms.DataGridView dgvIva;
        private System.Windows.Forms.ToolStripButton tsBtnNuevo;
        private System.Windows.Forms.ToolStripButton tsBtnSalir;
        private System.Windows.Forms.Label lblIva;
        private System.Windows.Forms.Panel panelMenuGrid;
        private System.Windows.Forms.ToolStrip tsMenuGrid;
        private System.Windows.Forms.ToolStripButton tsbtnModificar;
        private System.Windows.Forms.ToolStripButton tsEliminar;
        private System.Windows.Forms.DataGridViewTextBoxColumn idIva;
        private System.Windows.Forms.DataGridViewTextBoxColumn IVA;
    }
}