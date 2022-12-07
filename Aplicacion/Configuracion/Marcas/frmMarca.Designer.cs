namespace Aplicacion.Configuracion.Marcas
{
    partial class frmMarca
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

        private System.ComponentModel.ComponentResourceManager miResources =
            new System.ComponentModel.ComponentResourceManager(typeof(frmMarca));

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMarca));
            this.btnBuscarMarcaNombre = new System.Windows.Forms.Button();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtMarcaNombre = new System.Windows.Forms.TextBox();
            this.grillamarca = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbListadoMarca = new System.Windows.Forms.GroupBox();
            this.tsMenuMarca = new System.Windows.Forms.ToolStrip();
            this.tsbtnNuevaMarca = new System.Windows.Forms.ToolStripButton();
            this.tsbtnGuardarMarca = new System.Windows.Forms.ToolStripButton();
            this.tsbtnEditarMarca = new System.Windows.Forms.ToolStripButton();
            this.tsbtnEliminarMarca = new System.Windows.Forms.ToolStripButton();
            this.tsbtnSalir = new System.Windows.Forms.ToolStripButton();
            this.recurso = new System.Windows.Forms.ToolStripButton();
            this.gbMarca = new System.Windows.Forms.GroupBox();
            this.tsMenuMarca2 = new System.Windows.Forms.ToolStrip();
            this.tsbtnListarTodos = new System.Windows.Forms.ToolStripButton();
            this.tsBtnCriterio = new System.Windows.Forms.ToolStripButton();
            this.tsBtnSeleccionar = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.grillamarca)).BeginInit();
            this.gbListadoMarca.SuspendLayout();
            this.tsMenuMarca.SuspendLayout();
            this.gbMarca.SuspendLayout();
            this.tsMenuMarca2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBuscarMarcaNombre
            // 
            this.btnBuscarMarcaNombre.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscarMarcaNombre.Image")));
            this.btnBuscarMarcaNombre.Location = new System.Drawing.Point(316, 22);
            this.btnBuscarMarcaNombre.Name = "btnBuscarMarcaNombre";
            this.btnBuscarMarcaNombre.Size = new System.Drawing.Size(26, 24);
            this.btnBuscarMarcaNombre.TabIndex = 2;
            this.btnBuscarMarcaNombre.UseVisualStyleBackColor = true;
            this.btnBuscarMarcaNombre.Click += new System.EventHandler(this.btnBuscarMarcaNombre_Click);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(42, 26);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(91, 16);
            this.lblNombre.TabIndex = 1;
            this.lblNombre.Text = "Buscar Marca";
            // 
            // txtMarcaNombre
            // 
            this.txtMarcaNombre.Location = new System.Drawing.Point(139, 23);
            this.txtMarcaNombre.Name = "txtMarcaNombre";
            this.txtMarcaNombre.Size = new System.Drawing.Size(171, 22);
            this.txtMarcaNombre.TabIndex = 0;
            this.txtMarcaNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMarcaNombre_KeyPress);
            // 
            // grillamarca
            // 
            this.grillamarca.AllowUserToAddRows = false;
            this.grillamarca.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grillamarca.BackgroundColor = System.Drawing.SystemColors.Window;
            this.grillamarca.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillamarca.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.grillamarca.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grillamarca.Location = new System.Drawing.Point(13, 17);
            this.grillamarca.Name = "grillamarca";
            this.grillamarca.RowHeadersVisible = false;
            this.grillamarca.Size = new System.Drawing.Size(280, 276);
            this.grillamarca.TabIndex = 1;
            this.grillamarca.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grillamarca_CellDoubleClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "IdMarca";
            this.Column1.FillWeight = 81.21828F;
            this.Column1.HeaderText = "Código";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "NombreMarca";
            this.Column2.FillWeight = 118.7817F;
            this.Column2.HeaderText = "Nombre";
            this.Column2.Name = "Column2";
            // 
            // gbListadoMarca
            // 
            this.gbListadoMarca.Controls.Add(this.grillamarca);
            this.gbListadoMarca.Location = new System.Drawing.Point(45, 53);
            this.gbListadoMarca.Name = "gbListadoMarca";
            this.gbListadoMarca.Size = new System.Drawing.Size(299, 299);
            this.gbListadoMarca.TabIndex = 5;
            this.gbListadoMarca.TabStop = false;
            this.gbListadoMarca.Text = "Listado";
            // 
            // tsMenuMarca
            // 
            this.tsMenuMarca.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnNuevaMarca,
            this.tsbtnGuardarMarca,
            this.tsbtnEditarMarca,
            this.tsbtnEliminarMarca,
            this.tsbtnSalir,
            this.recurso});
            this.tsMenuMarca.Location = new System.Drawing.Point(0, 0);
            this.tsMenuMarca.Name = "tsMenuMarca";
            this.tsMenuMarca.Size = new System.Drawing.Size(436, 25);
            this.tsMenuMarca.TabIndex = 1;
            this.tsMenuMarca.Text = "Menu";
            // 
            // tsbtnNuevaMarca
            // 
            this.tsbtnNuevaMarca.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnNuevaMarca.Image")));
            this.tsbtnNuevaMarca.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnNuevaMarca.Name = "tsbtnNuevaMarca";
            this.tsbtnNuevaMarca.Size = new System.Drawing.Size(62, 22);
            this.tsbtnNuevaMarca.Text = "Nuevo";
            this.tsbtnNuevaMarca.Click += new System.EventHandler(this.tsbtnNuevaMarca_Click);
            // 
            // tsbtnGuardarMarca
            // 
            this.tsbtnGuardarMarca.Enabled = false;
            this.tsbtnGuardarMarca.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnGuardarMarca.Image")));
            this.tsbtnGuardarMarca.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnGuardarMarca.Name = "tsbtnGuardarMarca";
            this.tsbtnGuardarMarca.Size = new System.Drawing.Size(69, 22);
            this.tsbtnGuardarMarca.Text = "Guardar";
            this.tsbtnGuardarMarca.Click += new System.EventHandler(this.tsbtnGuardarMarca_Click);
            // 
            // tsbtnEditarMarca
            // 
            this.tsbtnEditarMarca.Enabled = false;
            this.tsbtnEditarMarca.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnEditarMarca.Image")));
            this.tsbtnEditarMarca.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnEditarMarca.Name = "tsbtnEditarMarca";
            this.tsbtnEditarMarca.Size = new System.Drawing.Size(57, 22);
            this.tsbtnEditarMarca.Text = "Editar";
            this.tsbtnEditarMarca.Click += new System.EventHandler(this.tsbtnEditarMarca_Click);
            // 
            // tsbtnEliminarMarca
            // 
            this.tsbtnEliminarMarca.Enabled = false;
            this.tsbtnEliminarMarca.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnEliminarMarca.Image")));
            this.tsbtnEliminarMarca.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnEliminarMarca.Name = "tsbtnEliminarMarca";
            this.tsbtnEliminarMarca.Size = new System.Drawing.Size(70, 22);
            this.tsbtnEliminarMarca.Text = "Eliminar";
            this.tsbtnEliminarMarca.Click += new System.EventHandler(this.tsbtnEliminarMarca_Click);
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
            // recurso
            // 
            this.recurso.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.recurso.Image = ((System.Drawing.Image)(resources.GetObject("recurso.Image")));
            this.recurso.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.recurso.Name = "recurso";
            this.recurso.Size = new System.Drawing.Size(23, 22);
            this.recurso.Text = "toolStripButton1";
            this.recurso.Visible = false;
            // 
            // gbMarca
            // 
            this.gbMarca.Controls.Add(this.lblNombre);
            this.gbMarca.Controls.Add(this.txtMarcaNombre);
            this.gbMarca.Controls.Add(this.btnBuscarMarcaNombre);
            this.gbMarca.Controls.Add(this.gbListadoMarca);
            this.gbMarca.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.gbMarca.Location = new System.Drawing.Point(10, 66);
            this.gbMarca.Name = "gbMarca";
            this.gbMarca.Size = new System.Drawing.Size(403, 364);
            this.gbMarca.TabIndex = 2;
            this.gbMarca.TabStop = false;
            this.gbMarca.Text = "Informacion Marca";
            // 
            // tsMenuMarca2
            // 
            this.tsMenuMarca2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnListarTodos,
            this.tsBtnCriterio,
            this.tsBtnSeleccionar});
            this.tsMenuMarca2.Location = new System.Drawing.Point(0, 25);
            this.tsMenuMarca2.Name = "tsMenuMarca2";
            this.tsMenuMarca2.Size = new System.Drawing.Size(436, 25);
            this.tsMenuMarca2.TabIndex = 3;
            this.tsMenuMarca2.Text = "toolStrip1";
            // 
            // tsbtnListarTodos
            // 
            this.tsbtnListarTodos.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnListarTodos.Image")));
            this.tsbtnListarTodos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnListarTodos.Name = "tsbtnListarTodos";
            this.tsbtnListarTodos.Size = new System.Drawing.Size(86, 22);
            this.tsbtnListarTodos.Text = "Listar Todo";
            this.tsbtnListarTodos.Click += new System.EventHandler(this.tsbtnListarTodos_Click);
            // 
            // tsBtnCriterio
            // 
            this.tsBtnCriterio.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsBtnCriterio.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnCriterio.Image")));
            this.tsBtnCriterio.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnCriterio.Name = "tsBtnCriterio";
            this.tsBtnCriterio.Size = new System.Drawing.Size(96, 22);
            this.tsBtnCriterio.Text = "Criterio [F5]";
            this.tsBtnCriterio.Visible = false;
            this.tsBtnCriterio.Click += new System.EventHandler(this.tsBtnCriterio_Click);
            // 
            // tsBtnSeleccionar
            // 
            this.tsBtnSeleccionar.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.tsBtnSeleccionar.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnSeleccionar.Image")));
            this.tsBtnSeleccionar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnSeleccionar.Name = "tsBtnSeleccionar";
            this.tsBtnSeleccionar.Size = new System.Drawing.Size(129, 22);
            this.tsBtnSeleccionar.Text = "Seleccionar [F12]";
            this.tsBtnSeleccionar.ToolTipText = "Seleccionar [F12]";
            this.tsBtnSeleccionar.Visible = false;
            this.tsBtnSeleccionar.Click += new System.EventHandler(this.tsBtnSeleccionar_Click);
            // 
            // frmMarca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(436, 438);
            this.Controls.Add(this.tsMenuMarca2);
            this.Controls.Add(this.tsMenuMarca);
            this.Controls.Add(this.gbMarca);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMarca";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Marca";
            this.Load += new System.EventHandler(this.frmMarca_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMarca_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.grillamarca)).EndInit();
            this.gbListadoMarca.ResumeLayout(false);
            this.tsMenuMarca.ResumeLayout(false);
            this.tsMenuMarca.PerformLayout();
            this.gbMarca.ResumeLayout(false);
            this.gbMarca.PerformLayout();
            this.tsMenuMarca2.ResumeLayout(false);
            this.tsMenuMarca2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView grillamarca;
        private System.Windows.Forms.Button btnBuscarMarcaNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.GroupBox gbListadoMarca;
        private System.Windows.Forms.ToolStrip tsMenuMarca;
        private System.Windows.Forms.ToolStripButton tsbtnGuardarMarca;
        private System.Windows.Forms.ToolStripButton tsbtnEditarMarca;
        private System.Windows.Forms.ToolStripButton tsbtnEliminarMarca;
        private System.Windows.Forms.ToolStripButton tsbtnSalir;
        private System.Windows.Forms.GroupBox gbMarca;
        private System.Windows.Forms.ToolStripButton tsbtnNuevaMarca;
        private System.Windows.Forms.ToolStripButton recurso;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        public System.Windows.Forms.TextBox txtMarcaNombre;
        private System.Windows.Forms.ToolStrip tsMenuMarca2;
        private System.Windows.Forms.ToolStripButton tsbtnListarTodos;
        private System.Windows.Forms.ToolStripButton tsBtnCriterio;
        private System.Windows.Forms.ToolStripButton tsBtnSeleccionar;
    }
}