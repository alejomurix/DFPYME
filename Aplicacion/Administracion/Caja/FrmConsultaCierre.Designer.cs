namespace Aplicacion.Administracion.Caja
{
    partial class FrmConsultaCierre
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConsultaCierre));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.tsBtnSalir = new System.Windows.Forms.ToolStripButton();
            this.gbCierre = new System.Windows.Forms.GroupBox();
            this.dgvCierre = new System.Windows.Forms.DataGridView();
            this.PagoIngreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorIngreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblCierre = new System.Windows.Forms.Label();
            this.txtCierre = new System.Windows.Forms.TextBox();
            this.tsMenu.SuspendLayout();
            this.gbCierre.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCierre)).BeginInit();
            this.SuspendLayout();
            // 
            // tsMenu
            // 
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnSalir});
            this.tsMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(368, 25);
            this.tsMenu.TabIndex = 0;
            this.tsMenu.Text = "toolStrip1";
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
            // gbCierre
            // 
            this.gbCierre.Controls.Add(this.lblCierre);
            this.gbCierre.Controls.Add(this.txtCierre);
            this.gbCierre.Controls.Add(this.dgvCierre);
            this.gbCierre.Location = new System.Drawing.Point(9, 36);
            this.gbCierre.Name = "gbCierre";
            this.gbCierre.Size = new System.Drawing.Size(345, 239);
            this.gbCierre.TabIndex = 1;
            this.gbCierre.TabStop = false;
            this.gbCierre.Text = "Consulta";
            // 
            // dgvCierre
            // 
            this.dgvCierre.AllowUserToAddRows = false;
            this.dgvCierre.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvCierre.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCierre.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PagoIngreso,
            this.ValorIngreso});
            this.dgvCierre.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvCierre.Location = new System.Drawing.Point(8, 21);
            this.dgvCierre.Name = "dgvCierre";
            this.dgvCierre.RowHeadersVisible = false;
            this.dgvCierre.Size = new System.Drawing.Size(327, 181);
            this.dgvCierre.TabIndex = 1;
            // 
            // PagoIngreso
            // 
            this.PagoIngreso.DataPropertyName = "pago";
            this.PagoIngreso.HeaderText = "Pago";
            this.PagoIngreso.Name = "PagoIngreso";
            this.PagoIngreso.Width = 200;
            // 
            // ValorIngreso
            // 
            this.ValorIngreso.DataPropertyName = "valor";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N0";
            dataGridViewCellStyle5.NullValue = null;
            this.ValorIngreso.DefaultCellStyle = dataGridViewCellStyle5;
            this.ValorIngreso.HeaderText = "Valor";
            this.ValorIngreso.Name = "ValorIngreso";
            this.ValorIngreso.Width = 120;
            // 
            // lblCierre
            // 
            this.lblCierre.AutoSize = true;
            this.lblCierre.Location = new System.Drawing.Point(159, 211);
            this.lblCierre.Name = "lblCierre";
            this.lblCierre.Size = new System.Drawing.Size(39, 16);
            this.lblCierre.TabIndex = 8;
            this.lblCierre.Text = "Total";
            // 
            // txtCierre
            // 
            this.txtCierre.BackColor = System.Drawing.Color.PaleTurquoise;
            this.txtCierre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCierre.Location = new System.Drawing.Point(205, 208);
            this.txtCierre.Name = "txtCierre";
            this.txtCierre.ReadOnly = true;
            this.txtCierre.Size = new System.Drawing.Size(130, 22);
            this.txtCierre.TabIndex = 7;
            this.txtCierre.Text = "0";
            this.txtCierre.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // FrmConsultaCierre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(368, 285);
            this.Controls.Add(this.gbCierre);
            this.Controls.Add(this.tsMenu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmConsultaCierre";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta de cierre";
            this.Load += new System.EventHandler(this.FrmConsultaCierre_Load);
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.gbCierre.ResumeLayout(false);
            this.gbCierre.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCierre)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.GroupBox gbCierre;
        private System.Windows.Forms.DataGridView dgvCierre;
        private System.Windows.Forms.ToolStripButton tsBtnSalir;
        private System.Windows.Forms.DataGridViewTextBoxColumn PagoIngreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorIngreso;
        private System.Windows.Forms.Label lblCierre;
        private System.Windows.Forms.TextBox txtCierre;
    }
}