namespace Aplicacion.Configuracion.Compra
{
    partial class FrmConfiguracion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConfiguracion));
            this.gbProveedor = new System.Windows.Forms.GroupBox();
            this.lblDescripcionProveedor = new System.Windows.Forms.Label();
            this.rbtnProveedorCodigo = new System.Windows.Forms.RadioButton();
            this.rbtnProveedorNit = new System.Windows.Forms.RadioButton();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gbMenu = new System.Windows.Forms.GroupBox();
            this.chkMenuCompras = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rbtKilogramo = new System.Windows.Forms.RadioButton();
            this.rbtnArroba = new System.Windows.Forms.RadioButton();
            this.gbProveedor.SuspendLayout();
            this.gbMenu.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbProveedor
            // 
            this.gbProveedor.Controls.Add(this.lblDescripcionProveedor);
            this.gbProveedor.Controls.Add(this.rbtnProveedorCodigo);
            this.gbProveedor.Controls.Add(this.rbtnProveedorNit);
            this.gbProveedor.Location = new System.Drawing.Point(12, 12);
            this.gbProveedor.Name = "gbProveedor";
            this.gbProveedor.Size = new System.Drawing.Size(255, 97);
            this.gbProveedor.TabIndex = 8;
            this.gbProveedor.TabStop = false;
            // 
            // lblDescripcionProveedor
            // 
            this.lblDescripcionProveedor.AutoSize = true;
            this.lblDescripcionProveedor.Location = new System.Drawing.Point(8, 19);
            this.lblDescripcionProveedor.Name = "lblDescripcionProveedor";
            this.lblDescripcionProveedor.Size = new System.Drawing.Size(141, 16);
            this.lblDescripcionProveedor.TabIndex = 3;
            this.lblDescripcionProveedor.Text = "Cargar proveedor por:";
            // 
            // rbtnProveedorCodigo
            // 
            this.rbtnProveedorCodigo.AutoSize = true;
            this.rbtnProveedorCodigo.Location = new System.Drawing.Point(11, 58);
            this.rbtnProveedorCodigo.Name = "rbtnProveedorCodigo";
            this.rbtnProveedorCodigo.Size = new System.Drawing.Size(70, 20);
            this.rbtnProveedorCodigo.TabIndex = 4;
            this.rbtnProveedorCodigo.TabStop = true;
            this.rbtnProveedorCodigo.Text = "Código";
            this.rbtnProveedorCodigo.UseVisualStyleBackColor = true;
            // 
            // rbtnProveedorNit
            // 
            this.rbtnProveedorNit.AutoSize = true;
            this.rbtnProveedorNit.Location = new System.Drawing.Point(159, 58);
            this.rbtnProveedorNit.Name = "rbtnProveedorNit";
            this.rbtnProveedorNit.Size = new System.Drawing.Size(48, 20);
            this.rbtnProveedorNit.TabIndex = 5;
            this.rbtnProveedorNit.TabStop = true;
            this.rbtnProveedorNit.Text = "NIT";
            this.rbtnProveedorNit.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnOk.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.Image")));
            this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOk.Location = new System.Drawing.Point(78, 278);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(83, 25);
            this.btnOk.TabIndex = 9;
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
            this.btnCancel.Location = new System.Drawing.Point(178, 278);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 25);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // gbMenu
            // 
            this.gbMenu.Controls.Add(this.chkMenuCompras);
            this.gbMenu.Location = new System.Drawing.Point(12, 115);
            this.gbMenu.Name = "gbMenu";
            this.gbMenu.Size = new System.Drawing.Size(255, 46);
            this.gbMenu.TabIndex = 11;
            this.gbMenu.TabStop = false;
            // 
            // chkMenuCompras
            // 
            this.chkMenuCompras.AutoSize = true;
            this.chkMenuCompras.Location = new System.Drawing.Point(11, 16);
            this.chkMenuCompras.Name = "chkMenuCompras";
            this.chkMenuCompras.Size = new System.Drawing.Size(224, 20);
            this.chkMenuCompras.TabIndex = 0;
            this.chkMenuCompras.Text = "Ver Menu de consulta de compra";
            this.chkMenuCompras.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtnArroba);
            this.groupBox1.Controls.Add(this.rbtKilogramo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 167);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(255, 100);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(241, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Medida de cantidad en compra simple:";
            // 
            // rbtKilogramo
            // 
            this.rbtKilogramo.AutoSize = true;
            this.rbtKilogramo.Location = new System.Drawing.Point(11, 54);
            this.rbtKilogramo.Name = "rbtKilogramo";
            this.rbtKilogramo.Size = new System.Drawing.Size(87, 20);
            this.rbtKilogramo.TabIndex = 5;
            this.rbtKilogramo.TabStop = true;
            this.rbtKilogramo.Text = "Kilogramo";
            this.rbtKilogramo.UseVisualStyleBackColor = true;
            // 
            // rbtnArroba
            // 
            this.rbtnArroba.AutoSize = true;
            this.rbtnArroba.Location = new System.Drawing.Point(159, 54);
            this.rbtnArroba.Name = "rbtnArroba";
            this.rbtnArroba.Size = new System.Drawing.Size(67, 20);
            this.rbtnArroba.TabIndex = 6;
            this.rbtnArroba.TabStop = true;
            this.rbtnArroba.Text = "Arroba";
            this.rbtnArroba.UseVisualStyleBackColor = true;
            // 
            // FrmConfiguracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(284, 320);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbMenu);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.gbProveedor);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmConfiguracion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuración en compras";
            this.Load += new System.EventHandler(this.FrmConfiguracion_Load);
            this.gbProveedor.ResumeLayout(false);
            this.gbProveedor.PerformLayout();
            this.gbMenu.ResumeLayout(false);
            this.gbMenu.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbProveedor;
        private System.Windows.Forms.Label lblDescripcionProveedor;
        private System.Windows.Forms.RadioButton rbtnProveedorCodigo;
        private System.Windows.Forms.RadioButton rbtnProveedorNit;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox gbMenu;
        private System.Windows.Forms.CheckBox chkMenuCompras;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbtnArroba;
        private System.Windows.Forms.RadioButton rbtKilogramo;
    }
}