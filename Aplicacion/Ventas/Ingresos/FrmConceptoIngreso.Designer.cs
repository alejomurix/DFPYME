namespace Aplicacion.Ventas.Ingresos
{
    partial class FrmConceptoIngreso
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConceptoIngreso));
            this.gbNuevoRubro = new System.Windows.Forms.GroupBox();
            this.lblRubro = new System.Windows.Forms.Label();
            this.txtRubro = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gbNuevoRubro.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbNuevoRubro
            // 
            this.gbNuevoRubro.Controls.Add(this.lblRubro);
            this.gbNuevoRubro.Controls.Add(this.txtRubro);
            this.gbNuevoRubro.Controls.Add(this.lblNombre);
            this.gbNuevoRubro.Controls.Add(this.txtNombre);
            this.gbNuevoRubro.Controls.Add(this.btnOk);
            this.gbNuevoRubro.Controls.Add(this.btnCancel);
            this.gbNuevoRubro.Location = new System.Drawing.Point(14, 7);
            this.gbNuevoRubro.Margin = new System.Windows.Forms.Padding(4);
            this.gbNuevoRubro.Name = "gbNuevoRubro";
            this.gbNuevoRubro.Padding = new System.Windows.Forms.Padding(4);
            this.gbNuevoRubro.Size = new System.Drawing.Size(334, 144);
            this.gbNuevoRubro.TabIndex = 0;
            this.gbNuevoRubro.TabStop = false;
            // 
            // lblRubro
            // 
            this.lblRubro.AutoSize = true;
            this.lblRubro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblRubro.Location = new System.Drawing.Point(20, 25);
            this.lblRubro.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRubro.Name = "lblRubro";
            this.lblRubro.Size = new System.Drawing.Size(52, 16);
            this.lblRubro.TabIndex = 4;
            this.lblRubro.Text = "Código";
            // 
            // txtRubro
            // 
            this.txtRubro.Location = new System.Drawing.Point(90, 22);
            this.txtRubro.Margin = new System.Windows.Forms.Padding(4);
            this.txtRubro.Name = "txtRubro";
            this.txtRubro.ReadOnly = true;
            this.txtRubro.Size = new System.Drawing.Size(212, 22);
            this.txtRubro.TabIndex = 3;
            this.txtRubro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRubro_KeyPress);
            this.txtRubro.Validating += new System.ComponentModel.CancelEventHandler(this.txtRubro_Validating);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblNombre.Location = new System.Drawing.Point(20, 67);
            this.lblNombre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(57, 16);
            this.lblNombre.TabIndex = 5;
            this.lblNombre.Text = "Nombre";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(90, 64);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(4);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(212, 22);
            this.txtNombre.TabIndex = 0;
            this.txtNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombre_KeyPress);
            this.txtNombre.Validating += new System.ComponentModel.CancelEventHandler(this.txtNombre_Validating);
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnOk.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.Image")));
            this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOk.Location = new System.Drawing.Point(102, 101);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(83, 25);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "Aceptar";
            this.btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.No;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(202, 101);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 25);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FrmConceptoIngreso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(365, 163);
            this.Controls.Add(this.gbNuevoRubro);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmConceptoIngreso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Concepto de Ingreso";
            this.Load += new System.EventHandler(this.FrmConceptoIngreso_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmConceptoIngreso_KeyDown);
            this.gbNuevoRubro.ResumeLayout(false);
            this.gbNuevoRubro.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbNuevoRubro;
        private System.Windows.Forms.Label lblRubro;
        private System.Windows.Forms.TextBox txtRubro;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;

    }
}