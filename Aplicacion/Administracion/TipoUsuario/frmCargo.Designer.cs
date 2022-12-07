namespace Aplicacion.Administracion.TipoUsuario
{
    partial class frmCargo
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
         new System.ComponentModel.ComponentResourceManager(typeof(frmCargo));


        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCargo));
            this.gbxcargo = new System.Windows.Forms.GroupBox();
            this.lblcargo = new System.Windows.Forms.Label();
            this.txtCargo = new System.Windows.Forms.TextBox();
            this.dgvcargo = new System.Windows.Forms.DataGridView();
            this.Idcargo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cargo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelMenuGrid = new System.Windows.Forms.Panel();
            this.tsMenuGrid = new System.Windows.Forms.ToolStrip();
            this.tsbtnModificar = new System.Windows.Forms.ToolStripButton();
            this.tsEliminar = new System.Windows.Forms.ToolStripButton();
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.tsbtnNuevo = new System.Windows.Forms.ToolStripButton();
            this.tsbtnGuardar = new System.Windows.Forms.ToolStripButton();
            this.tsbtnSalir = new System.Windows.Forms.ToolStripButton();
            this.gbxcargo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvcargo)).BeginInit();
            this.panelMenuGrid.SuspendLayout();
            this.tsMenuGrid.SuspendLayout();
            this.tsMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxcargo
            // 
            this.gbxcargo.Controls.Add(this.lblcargo);
            this.gbxcargo.Controls.Add(this.txtCargo);
            this.gbxcargo.Controls.Add(this.dgvcargo);
            this.gbxcargo.Controls.Add(this.panelMenuGrid);
            this.gbxcargo.Location = new System.Drawing.Point(13, 29);
            this.gbxcargo.Margin = new System.Windows.Forms.Padding(4);
            this.gbxcargo.Name = "gbxcargo";
            this.gbxcargo.Padding = new System.Windows.Forms.Padding(4);
            this.gbxcargo.Size = new System.Drawing.Size(389, 415);
            this.gbxcargo.TabIndex = 2;
            this.gbxcargo.TabStop = false;
            this.gbxcargo.Text = "Cargo";
            // 
            // lblcargo
            // 
            this.lblcargo.AutoSize = true;
            this.lblcargo.Location = new System.Drawing.Point(40, 53);
            this.lblcargo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblcargo.Name = "lblcargo";
            this.lblcargo.Size = new System.Drawing.Size(45, 16);
            this.lblcargo.TabIndex = 1;
            this.lblcargo.Text = "Cargo";
            // 
            // txtCargo
            // 
            this.txtCargo.Location = new System.Drawing.Point(105, 49);
            this.txtCargo.Margin = new System.Windows.Forms.Padding(4);
            this.txtCargo.MaxLength = 50;
            this.txtCargo.Name = "txtCargo";
            this.txtCargo.ReadOnly = true;
            this.txtCargo.Size = new System.Drawing.Size(252, 22);
            this.txtCargo.TabIndex = 0;
            this.txtCargo.Validating += new System.ComponentModel.CancelEventHandler(this.txtCargo_Validating);
            // 
            // dgvcargo
            // 
            this.dgvcargo.AllowUserToAddRows = false;
            this.dgvcargo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvcargo.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvcargo.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvcargo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvcargo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Idcargo,
            this.Cargo});
            this.dgvcargo.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvcargo.GridColor = System.Drawing.SystemColors.Window;
            this.dgvcargo.Location = new System.Drawing.Point(44, 96);
            this.dgvcargo.Margin = new System.Windows.Forms.Padding(4);
            this.dgvcargo.Name = "dgvcargo";
            this.dgvcargo.Size = new System.Drawing.Size(256, 298);
            this.dgvcargo.TabIndex = 3;
            // 
            // Idcargo
            // 
            this.Idcargo.DataPropertyName = "idtipo";
            this.Idcargo.HeaderText = "IdCargo";
            this.Idcargo.Name = "Idcargo";
            this.Idcargo.Visible = false;
            // 
            // Cargo
            // 
            this.Cargo.DataPropertyName = "descripciontipo";
            this.Cargo.HeaderText = "Cargo";
            this.Cargo.Name = "Cargo";
            // 
            // panelMenuGrid
            // 
            this.panelMenuGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMenuGrid.Controls.Add(this.tsMenuGrid);
            this.panelMenuGrid.Location = new System.Drawing.Point(300, 96);
            this.panelMenuGrid.Margin = new System.Windows.Forms.Padding(4);
            this.panelMenuGrid.Name = "panelMenuGrid";
            this.panelMenuGrid.Size = new System.Drawing.Size(59, 297);
            this.panelMenuGrid.TabIndex = 2;
            // 
            // tsMenuGrid
            // 
            this.tsMenuGrid.Dock = System.Windows.Forms.DockStyle.Right;
            this.tsMenuGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnModificar,
            this.tsEliminar});
            this.tsMenuGrid.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.tsMenuGrid.Location = new System.Drawing.Point(32, 0);
            this.tsMenuGrid.Name = "tsMenuGrid";
            this.tsMenuGrid.Size = new System.Drawing.Size(25, 295);
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
            // tsMenu
            // 
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnNuevo,
            this.tsbtnGuardar,
            this.tsbtnSalir});
            this.tsMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(416, 25);
            this.tsMenu.TabIndex = 3;
            this.tsMenu.Text = "tsMenu";
            // 
            // tsbtnNuevo
            // 
            this.tsbtnNuevo.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnNuevo.Image")));
            this.tsbtnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnNuevo.Name = "tsbtnNuevo";
            this.tsbtnNuevo.Size = new System.Drawing.Size(62, 22);
            this.tsbtnNuevo.Text = "Nuevo";
            this.tsbtnNuevo.Click += new System.EventHandler(this.tsbtnNuevo_Click);
            // 
            // tsbtnGuardar
            // 
            this.tsbtnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnGuardar.Image")));
            this.tsbtnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnGuardar.Name = "tsbtnGuardar";
            this.tsbtnGuardar.Size = new System.Drawing.Size(69, 22);
            this.tsbtnGuardar.Text = "Guardar";
            this.tsbtnGuardar.Click += new System.EventHandler(this.tsbtnGuardar_Click);
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
            // frmCargo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 451);
            this.Controls.Add(this.tsMenu);
            this.Controls.Add(this.gbxcargo);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCargo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmCargo";
            this.Load += new System.EventHandler(this.frmCargo_Load);
            this.gbxcargo.ResumeLayout(false);
            this.gbxcargo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvcargo)).EndInit();
            this.panelMenuGrid.ResumeLayout(false);
            this.panelMenuGrid.PerformLayout();
            this.tsMenuGrid.ResumeLayout(false);
            this.tsMenuGrid.PerformLayout();
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxcargo;
        private System.Windows.Forms.Label lblcargo;
        private System.Windows.Forms.TextBox txtCargo;
        private System.Windows.Forms.DataGridView dgvcargo;
        private System.Windows.Forms.Panel panelMenuGrid;
        private System.Windows.Forms.ToolStrip tsMenuGrid;
        private System.Windows.Forms.ToolStripButton tsbtnModificar;
        private System.Windows.Forms.ToolStripButton tsEliminar;
        private System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.ToolStripButton tsbtnGuardar;
        private System.Windows.Forms.ToolStripButton tsbtnNuevo;
        private System.Windows.Forms.ToolStripButton tsbtnSalir;
        private System.Windows.Forms.DataGridViewTextBoxColumn Idcargo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cargo;
    }
}