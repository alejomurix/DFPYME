namespace FormulariosSistema
{
    partial class FrmProductList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProductList));
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dgvListItems = new System.Windows.Forms.DataGridView();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C_Barras = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Referencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Equivalente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Marca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customPanel3 = new FormulariosSistema.CustomPanel();
            this.chkVerId = new System.Windows.Forms.CheckBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListItems)).BeginInit();
            this.customPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox4.Controls.Add(this.dgvListItems);
            this.groupBox4.Controls.Add(this.customPanel3);
            this.groupBox4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox4.ForeColor = System.Drawing.Color.Blue;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(944, 376);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            // 
            // dgvListItems
            // 
            this.dgvListItems.AllowUserToAddRows = false;
            this.dgvListItems.BackgroundColor = System.Drawing.Color.MintCream;
            this.dgvListItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.C_Barras,
            this.Descripcion,
            this.Referencia,
            this.Equivalente,
            this.Marca,
            this.Precio,
            this.Precio2,
            this.Precio3,
            this.Precio4});
            this.dgvListItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvListItems.Location = new System.Drawing.Point(4, 38);
            this.dgvListItems.Name = "dgvListItems";
            this.dgvListItems.RowHeadersWidth = 12;
            this.dgvListItems.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.MintCream;
            this.dgvListItems.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvListItems.Size = new System.Drawing.Size(933, 330);
            this.dgvListItems.TabIndex = 26;
            // 
            // Codigo
            // 
            this.Codigo.DataPropertyName = "CodigoInternoProducto";
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "Codigo";
            this.Codigo.Width = 80;
            // 
            // C_Barras
            // 
            this.C_Barras.DataPropertyName = "CodigoBarrasProducto";
            this.C_Barras.HeaderText = "C. Barras";
            this.C_Barras.Name = "C_Barras";
            this.C_Barras.Visible = false;
            // 
            // Descripcion
            // 
            this.Descripcion.DataPropertyName = "NombreProducto";
            this.Descripcion.HeaderText = "Descripción";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.Width = 410;
            // 
            // Referencia
            // 
            this.Referencia.DataPropertyName = "ReferenciaProducto";
            this.Referencia.HeaderText = "Referencia";
            this.Referencia.Name = "Referencia";
            this.Referencia.Visible = false;
            this.Referencia.Width = 140;
            // 
            // Equivalente
            // 
            this.Equivalente.DataPropertyName = "DescripcionProducto";
            this.Equivalente.HeaderText = "Equivalente";
            this.Equivalente.Name = "Equivalente";
            this.Equivalente.Visible = false;
            this.Equivalente.Width = 130;
            // 
            // Marca
            // 
            this.Marca.DataPropertyName = "NombreMarca";
            this.Marca.HeaderText = "Marca";
            this.Marca.Name = "Marca";
            this.Marca.Visible = false;
            // 
            // Precio
            // 
            this.Precio.DataPropertyName = "ValorVentaProducto";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N1";
            dataGridViewCellStyle1.NullValue = null;
            this.Precio.DefaultCellStyle = dataGridViewCellStyle1;
            this.Precio.HeaderText = "Precio (1)";
            this.Precio.Name = "Precio";
            // 
            // Precio2
            // 
            this.Precio2.DataPropertyName = "DescuentoMayor";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N1";
            dataGridViewCellStyle2.NullValue = null;
            this.Precio2.DefaultCellStyle = dataGridViewCellStyle2;
            this.Precio2.HeaderText = "P. Mayor (2)";
            this.Precio2.Name = "Precio2";
            this.Precio2.Width = 105;
            // 
            // Precio3
            // 
            this.Precio3.DataPropertyName = "Price3";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N1";
            dataGridViewCellStyle3.NullValue = null;
            this.Precio3.DefaultCellStyle = dataGridViewCellStyle3;
            this.Precio3.HeaderText = "P. Distr. (3)";
            this.Precio3.Name = "Precio3";
            // 
            // Precio4
            // 
            this.Precio4.DataPropertyName = "Price4";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N1";
            dataGridViewCellStyle4.NullValue = null;
            this.Precio4.DefaultCellStyle = dataGridViewCellStyle4;
            this.Precio4.HeaderText = "Precio (4)";
            this.Precio4.Name = "Precio4";
            // 
            // customPanel3
            // 
            this.customPanel3.Controls.Add(this.chkVerId);
            this.customPanel3.Controls.Add(this.btnSearch);
            this.customPanel3.Controls.Add(this.txtSearch);
            this.customPanel3.Location = new System.Drawing.Point(4, 7);
            this.customPanel3.Name = "customPanel3";
            this.customPanel3.Size = new System.Drawing.Size(933, 31);
            this.customPanel3.TabIndex = 0;
            // 
            // chkVerId
            // 
            this.chkVerId.AutoSize = true;
            this.chkVerId.ForeColor = System.Drawing.Color.Black;
            this.chkVerId.Location = new System.Drawing.Point(477, 6);
            this.chkVerId.Name = "chkVerId";
            this.chkVerId.Size = new System.Drawing.Size(110, 20);
            this.chkVerId.TabIndex = 2;
            this.chkVerId.Text = "Ver ID articulo";
            this.chkVerId.UseVisualStyleBackColor = true;
            this.chkVerId.Visible = false;
            this.chkVerId.CheckedChanged += new System.EventHandler(this.chkVerId_CheckedChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnSearch.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(426, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(31, 23);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(3, 5);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearch.MaxLength = 255;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(422, 22);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // FrmProductList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(943, 376);
            this.Controls.Add(this.groupBox4);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmProductList";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LISTADO DE ARTICULOS";
            this.Load += new System.EventHandler(this.FrmProductList_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmProductList_KeyDown);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListItems)).EndInit();
            this.customPanel3.ResumeLayout(false);
            this.customPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private CustomPanel customPanel3;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dgvListItems;
        private System.Windows.Forms.CheckBox chkVerId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn C_Barras;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Referencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Equivalente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Marca;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio4;
    }
}