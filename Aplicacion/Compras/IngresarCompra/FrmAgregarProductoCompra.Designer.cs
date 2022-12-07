namespace Aplicacion.Compras.IngresarCompra
{
    partial class FrmAgregarProductoCompra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAgregarProductoCompra));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnTallaYcolor = new System.Windows.Forms.Button();
            this.lblProducto = new System.Windows.Forms.Label();
            this.txtCodigoArticulo = new System.Windows.Forms.TextBox();
            this.panelProducto = new System.Windows.Forms.Panel();
            this.lblDatosProducto = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.panelProducto.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblCantidad);
            this.groupBox1.Controls.Add(this.txtCantidad);
            this.groupBox1.Controls.Add(this.btnOk);
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.btnTallaYcolor);
            this.groupBox1.Controls.Add(this.lblProducto);
            this.groupBox1.Controls.Add(this.txtCodigoArticulo);
            this.groupBox1.Controls.Add(this.panelProducto);
            this.groupBox1.Location = new System.Drawing.Point(12, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(862, 128);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblCantidad.Location = new System.Drawing.Point(696, 22);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(38, 16);
            this.lblCantidad.TabIndex = 24;
            this.lblCantidad.Text = "Cant.";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(740, 19);
            this.txtCantidad.MaxLength = 20;
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(106, 22);
            this.txtCantidad.TabIndex = 23;
            this.txtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);
            this.txtCantidad.Validating += new System.ComponentModel.CancelEventHandler(this.txtCantidad_Validating);
            // 
            // btnOk
            // 
            this.btnOk.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.Image")));
            this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOk.Location = new System.Drawing.Point(658, 88);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(83, 25);
            this.btnOk.TabIndex = 21;
            this.btnOk.Text = "Aceptar";
            this.btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(758, 88);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 25);
            this.btnCancel.TabIndex = 22;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnTallaYcolor
            // 
            this.btnTallaYcolor.Enabled = false;
            this.btnTallaYcolor.FlatAppearance.BorderSize = 0;
            this.btnTallaYcolor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTallaYcolor.Image = ((System.Drawing.Image)(resources.GetObject("btnTallaYcolor.Image")));
            this.btnTallaYcolor.Location = new System.Drawing.Point(653, 16);
            this.btnTallaYcolor.Name = "btnTallaYcolor";
            this.btnTallaYcolor.Size = new System.Drawing.Size(25, 25);
            this.btnTallaYcolor.TabIndex = 20;
            this.btnTallaYcolor.UseVisualStyleBackColor = true;
            this.btnTallaYcolor.Click += new System.EventHandler(this.btnTallaYcolor_Click);
            // 
            // lblProducto
            // 
            this.lblProducto.AutoSize = true;
            this.lblProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblProducto.Location = new System.Drawing.Point(14, 22);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(52, 16);
            this.lblProducto.TabIndex = 18;
            this.lblProducto.Text = "Articulo";
            // 
            // txtCodigoArticulo
            // 
            this.txtCodigoArticulo.Location = new System.Drawing.Point(70, 19);
            this.txtCodigoArticulo.MaxLength = 100;
            this.txtCodigoArticulo.Name = "txtCodigoArticulo";
            this.txtCodigoArticulo.Size = new System.Drawing.Size(576, 22);
            this.txtCodigoArticulo.TabIndex = 17;
            this.txtCodigoArticulo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoArticulo_KeyPress);
            // 
            // panelProducto
            // 
            this.panelProducto.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panelProducto.Controls.Add(this.lblDatosProducto);
            this.panelProducto.Location = new System.Drawing.Point(15, 48);
            this.panelProducto.Name = "panelProducto";
            this.panelProducto.Size = new System.Drawing.Size(631, 27);
            this.panelProducto.TabIndex = 19;
            // 
            // lblDatosProducto
            // 
            this.lblDatosProducto.AutoSize = true;
            this.lblDatosProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblDatosProducto.Location = new System.Drawing.Point(8, 6);
            this.lblDatosProducto.Name = "lblDatosProducto";
            this.lblDatosProducto.Size = new System.Drawing.Size(0, 16);
            this.lblDatosProducto.TabIndex = 0;
            // 
            // FrmAgregarProductoCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(886, 147);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAgregarProductoCompra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agregar producto";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmAgregarProductoCompra_FormClosing);
            this.Load += new System.EventHandler(this.FrmEditarProductoCompra_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmEditarProductoCompra_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panelProducto.ResumeLayout(false);
            this.panelProducto.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.TextBox txtCodigoArticulo;
        private System.Windows.Forms.Panel panelProducto;
        private System.Windows.Forms.Label lblDatosProducto;
        private System.Windows.Forms.Button btnTallaYcolor;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.TextBox txtCantidad;
    }
}