namespace Aplicacion.Configuracion.FormaPago
{
    partial class frmFormaPago
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFormaPago));
            this.gbxFormaPago = new System.Windows.Forms.GroupBox();
            this.panelMenuGrid = new System.Windows.Forms.Panel();
            this.tsMenuGrid = new System.Windows.Forms.ToolStrip();
            this.tsbtnGuardar = new System.Windows.Forms.ToolStripButton();
            this.tsBtnEditar = new System.Windows.Forms.ToolStripButton();
            this.tsbtnEliminar = new System.Windows.Forms.ToolStripButton();
            this.dgbFormaPago = new System.Windows.Forms.DataGridView();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Habilita = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lblFormaPago = new System.Windows.Forms.Label();
            this.txtFormaPago = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.gbxFormaPago.SuspendLayout();
            this.panelMenuGrid.SuspendLayout();
            this.tsMenuGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgbFormaPago)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxFormaPago
            // 
            this.gbxFormaPago.Controls.Add(this.panelMenuGrid);
            this.gbxFormaPago.Controls.Add(this.dgbFormaPago);
            this.gbxFormaPago.Location = new System.Drawing.Point(18, 48);
            this.gbxFormaPago.Margin = new System.Windows.Forms.Padding(4);
            this.gbxFormaPago.Name = "gbxFormaPago";
            this.gbxFormaPago.Padding = new System.Windows.Forms.Padding(4);
            this.gbxFormaPago.Size = new System.Drawing.Size(407, 243);
            this.gbxFormaPago.TabIndex = 3;
            this.gbxFormaPago.TabStop = false;
            // 
            // panelMenuGrid
            // 
            this.panelMenuGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMenuGrid.Controls.Add(this.tsMenuGrid);
            this.panelMenuGrid.Location = new System.Drawing.Point(376, 10);
            this.panelMenuGrid.Name = "panelMenuGrid";
            this.panelMenuGrid.Size = new System.Drawing.Size(30, 94);
            this.panelMenuGrid.TabIndex = 2;
            // 
            // tsMenuGrid
            // 
            this.tsMenuGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnGuardar,
            this.tsBtnEditar,
            this.tsbtnEliminar});
            this.tsMenuGrid.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.tsMenuGrid.Location = new System.Drawing.Point(0, 0);
            this.tsMenuGrid.Name = "tsMenuGrid";
            this.tsMenuGrid.Size = new System.Drawing.Size(28, 99);
            this.tsMenuGrid.TabIndex = 0;
            this.tsMenuGrid.Text = "Menu de Registro";
            // 
            // tsbtnGuardar
            // 
            this.tsbtnGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnGuardar.Image")));
            this.tsbtnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnGuardar.Name = "tsbtnGuardar";
            this.tsbtnGuardar.Size = new System.Drawing.Size(26, 20);
            this.tsbtnGuardar.Click += new System.EventHandler(this.tsbtnGuardar_Click);
            // 
            // tsBtnEditar
            // 
            this.tsBtnEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnEditar.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnEditar.Image")));
            this.tsBtnEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnEditar.Name = "tsBtnEditar";
            this.tsBtnEditar.Size = new System.Drawing.Size(26, 20);
            this.tsBtnEditar.Click += new System.EventHandler(this.tsBtnEditar_Click);
            // 
            // tsbtnEliminar
            // 
            this.tsbtnEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnEliminar.Image")));
            this.tsbtnEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnEliminar.Name = "tsbtnEliminar";
            this.tsbtnEliminar.Size = new System.Drawing.Size(26, 20);
            this.tsbtnEliminar.Text = "Eliminar";
            this.tsbtnEliminar.Click += new System.EventHandler(this.tsbtnEliminar_Click);
            // 
            // dgbFormaPago
            // 
            this.dgbFormaPago.AllowUserToAddRows = false;
            this.dgbFormaPago.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgbFormaPago.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgbFormaPago.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.Nombre,
            this.Habilita});
            this.dgbFormaPago.Location = new System.Drawing.Point(3, 10);
            this.dgbFormaPago.Margin = new System.Windows.Forms.Padding(4);
            this.dgbFormaPago.Name = "dgbFormaPago";
            this.dgbFormaPago.RowHeadersVisible = false;
            this.dgbFormaPago.Size = new System.Drawing.Size(374, 230);
            this.dgbFormaPago.TabIndex = 1;
            // 
            // Codigo
            // 
            this.Codigo.DataPropertyName = "idforma_pago";
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "Codigo";
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "nombreforma_pago";
            this.Nombre.HeaderText = "Forma de Pago";
            this.Nombre.Name = "Nombre";
            this.Nombre.Width = 200;
            // 
            // Habilita
            // 
            this.Habilita.DataPropertyName = "aplica";
            this.Habilita.HeaderText = "Habilitar";
            this.Habilita.Name = "Habilita";
            this.Habilita.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Habilita.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Habilita.Width = 70;
            // 
            // lblFormaPago
            // 
            this.lblFormaPago.AutoSize = true;
            this.lblFormaPago.Location = new System.Drawing.Point(18, 22);
            this.lblFormaPago.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFormaPago.Name = "lblFormaPago";
            this.lblFormaPago.Size = new System.Drawing.Size(48, 16);
            this.lblFormaPago.TabIndex = 1;
            this.lblFormaPago.Text = "Nueva";
            // 
            // txtFormaPago
            // 
            this.txtFormaPago.Location = new System.Drawing.Point(73, 19);
            this.txtFormaPago.Margin = new System.Windows.Forms.Padding(4);
            this.txtFormaPago.Name = "txtFormaPago";
            this.txtFormaPago.Size = new System.Drawing.Size(264, 22);
            this.txtFormaPago.TabIndex = 0;
            this.txtFormaPago.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFormaPago_KeyPress);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(350, 18);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 6;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // frmFormaPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(442, 309);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.gbxFormaPago);
            this.Controls.Add(this.lblFormaPago);
            this.Controls.Add(this.txtFormaPago);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFormaPago";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Forma de Pago";
            this.Load += new System.EventHandler(this.frmFormaPago_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmFormaPago_KeyDown);
            this.gbxFormaPago.ResumeLayout(false);
            this.panelMenuGrid.ResumeLayout(false);
            this.panelMenuGrid.PerformLayout();
            this.tsMenuGrid.ResumeLayout(false);
            this.tsMenuGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgbFormaPago)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxFormaPago;
        private System.Windows.Forms.Label lblFormaPago;
        private System.Windows.Forms.TextBox txtFormaPago;
        private System.Windows.Forms.DataGridView dgbFormaPago;
        private System.Windows.Forms.Panel panelMenuGrid;
        private System.Windows.Forms.ToolStrip tsMenuGrid;
        private System.Windows.Forms.ToolStripButton tsbtnGuardar;
        private System.Windows.Forms.ToolStripButton tsBtnEditar;
        private System.Windows.Forms.ToolStripButton tsbtnEliminar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Habilita;
    }
}