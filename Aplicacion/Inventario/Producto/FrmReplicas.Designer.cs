namespace Aplicacion.Inventario.Producto
{
    partial class FrmReplicas
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
            this.dgvReplicas = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReplicas)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvReplicas
            // 
            this.dgvReplicas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReplicas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReplicas.Location = new System.Drawing.Point(0, 0);
            this.dgvReplicas.Name = "dgvReplicas";
            this.dgvReplicas.Size = new System.Drawing.Size(676, 527);
            this.dgvReplicas.TabIndex = 0;
            // 
            // FrmReplicas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(676, 527);
            this.Controls.Add(this.dgvReplicas);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmReplicas";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Replicas";
            ((System.ComponentModel.ISupportInitialize)(this.dgvReplicas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dgvReplicas;

    }
}