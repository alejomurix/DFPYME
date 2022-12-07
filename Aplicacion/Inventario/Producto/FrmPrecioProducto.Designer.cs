namespace Aplicacion.Inventario.Producto
{
    partial class FrmPrecioProducto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrecioProducto));
            this.gbCargaProducto = new System.Windows.Forms.GroupBox();
            this.btnTallaYcolor = new System.Windows.Forms.Button();
            this.lblProducto = new System.Windows.Forms.Label();
            this.txtCodigoArticulo = new System.Windows.Forms.TextBox();
            this.panelProducto = new System.Windows.Forms.Panel();
            this.lblDatosProducto = new System.Windows.Forms.Label();
            this.gbPrecio = new System.Windows.Forms.GroupBox();
            this.lblCostoPromedo = new System.Windows.Forms.Label();
            this.txtCosto = new System.Windows.Forms.TextBox();
            this.btnInfoCosto = new System.Windows.Forms.Button();
            this.lblUtilidad = new System.Windows.Forms.Label();
            this.txtUtilidad = new System.Windows.Forms.TextBox();
            this.lblPrecioSugerido = new System.Windows.Forms.Label();
            this.txtPrecioSugerido = new System.Windows.Forms.TextBox();
            this.lblPrecioAprox = new System.Windows.Forms.Label();
            this.txtPrecioAprox = new System.Windows.Forms.TextBox();
            this.lblPrecioVenta = new System.Windows.Forms.Label();
            this.txtPrecioVenta = new System.Windows.Forms.TextBox();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.lblValores = new System.Windows.Forms.Label();
            this.lblValorCosto = new System.Windows.Forms.Label();
            this.lblVUtilidad = new System.Windows.Forms.Label();
            this.lblValorSugerido = new System.Windows.Forms.Label();
            this.lblValorAprox = new System.Windows.Forms.Label();
            this.lblValorVenta = new System.Windows.Forms.Label();
            this.gbCargaProducto.SuspendLayout();
            this.panelProducto.SuspendLayout();
            this.gbPrecio.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbCargaProducto
            // 
            this.gbCargaProducto.Controls.Add(this.btnTallaYcolor);
            this.gbCargaProducto.Controls.Add(this.lblProducto);
            this.gbCargaProducto.Controls.Add(this.txtCodigoArticulo);
            this.gbCargaProducto.Controls.Add(this.panelProducto);
            this.gbCargaProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.gbCargaProducto.Location = new System.Drawing.Point(12, 12);
            this.gbCargaProducto.Name = "gbCargaProducto";
            this.gbCargaProducto.Size = new System.Drawing.Size(497, 80);
            this.gbCargaProducto.TabIndex = 0;
            this.gbCargaProducto.TabStop = false;
            this.gbCargaProducto.Text = "Cargar Producto";
            // 
            // btnTallaYcolor
            // 
            this.btnTallaYcolor.Enabled = false;
            this.btnTallaYcolor.FlatAppearance.BorderSize = 0;
            this.btnTallaYcolor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTallaYcolor.Image = ((System.Drawing.Image)(resources.GetObject("btnTallaYcolor.Image")));
            this.btnTallaYcolor.Location = new System.Drawing.Point(466, 13);
            this.btnTallaYcolor.Name = "btnTallaYcolor";
            this.btnTallaYcolor.Size = new System.Drawing.Size(25, 25);
            this.btnTallaYcolor.TabIndex = 8;
            this.btnTallaYcolor.UseVisualStyleBackColor = true;
            this.btnTallaYcolor.Click += new System.EventHandler(this.btnTallaYcolor_Click);
            // 
            // lblProducto
            // 
            this.lblProducto.AutoSize = true;
            this.lblProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblProducto.Location = new System.Drawing.Point(8, 19);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(52, 16);
            this.lblProducto.TabIndex = 2;
            this.lblProducto.Text = "Articulo";
            // 
            // txtCodigoArticulo
            // 
            this.txtCodigoArticulo.Location = new System.Drawing.Point(84, 16);
            this.txtCodigoArticulo.MaxLength = 100;
            this.txtCodigoArticulo.Name = "txtCodigoArticulo";
            this.txtCodigoArticulo.Size = new System.Drawing.Size(378, 22);
            this.txtCodigoArticulo.TabIndex = 0;
            this.txtCodigoArticulo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoArticulo_KeyPress);
            // 
            // panelProducto
            // 
            this.panelProducto.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panelProducto.Controls.Add(this.lblDatosProducto);
            this.panelProducto.Location = new System.Drawing.Point(9, 45);
            this.panelProducto.Name = "panelProducto";
            this.panelProducto.Size = new System.Drawing.Size(453, 27);
            this.panelProducto.TabIndex = 3;
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
            // gbPrecio
            // 
            this.gbPrecio.BackColor = System.Drawing.SystemColors.ControlLight;
            this.gbPrecio.Controls.Add(this.lblCostoPromedo);
            this.gbPrecio.Controls.Add(this.txtCosto);
            this.gbPrecio.Controls.Add(this.btnInfoCosto);
            this.gbPrecio.Controls.Add(this.lblUtilidad);
            this.gbPrecio.Controls.Add(this.txtUtilidad);
            this.gbPrecio.Controls.Add(this.lblPrecioSugerido);
            this.gbPrecio.Controls.Add(this.txtPrecioSugerido);
            this.gbPrecio.Controls.Add(this.lblPrecioAprox);
            this.gbPrecio.Controls.Add(this.txtPrecioAprox);
            this.gbPrecio.Controls.Add(this.lblPrecioVenta);
            this.gbPrecio.Controls.Add(this.txtPrecioVenta);
            this.gbPrecio.Controls.Add(this.btnActualizar);
            this.gbPrecio.Controls.Add(this.lblValores);
            this.gbPrecio.Controls.Add(this.lblValorCosto);
            this.gbPrecio.Controls.Add(this.lblVUtilidad);
            this.gbPrecio.Controls.Add(this.lblValorSugerido);
            this.gbPrecio.Controls.Add(this.lblValorAprox);
            this.gbPrecio.Controls.Add(this.lblValorVenta);
            this.gbPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.gbPrecio.Location = new System.Drawing.Point(12, 98);
            this.gbPrecio.Name = "gbPrecio";
            this.gbPrecio.Size = new System.Drawing.Size(497, 287);
            this.gbPrecio.TabIndex = 1;
            this.gbPrecio.TabStop = false;
            this.gbPrecio.Text = "Información de costo y venta.";
            // 
            // lblCostoPromedo
            // 
            this.lblCostoPromedo.AutoSize = true;
            this.lblCostoPromedo.Location = new System.Drawing.Point(6, 43);
            this.lblCostoPromedo.Name = "lblCostoPromedo";
            this.lblCostoPromedo.Size = new System.Drawing.Size(105, 16);
            this.lblCostoPromedo.TabIndex = 17;
            this.lblCostoPromedo.Text = "Costo Promedio";
            // 
            // txtCosto
            // 
            this.txtCosto.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtCosto.Location = new System.Drawing.Point(120, 40);
            this.txtCosto.MaxLength = 20;
            this.txtCosto.Name = "txtCosto";
            this.txtCosto.ReadOnly = true;
            this.txtCosto.Size = new System.Drawing.Size(124, 22);
            this.txtCosto.TabIndex = 16;
            // 
            // btnInfoCosto
            // 
            this.btnInfoCosto.FlatAppearance.BorderSize = 0;
            this.btnInfoCosto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInfoCosto.Image = ((System.Drawing.Image)(resources.GetObject("btnInfoCosto.Image")));
            this.btnInfoCosto.Location = new System.Drawing.Point(247, 39);
            this.btnInfoCosto.Name = "btnInfoCosto";
            this.btnInfoCosto.Size = new System.Drawing.Size(25, 23);
            this.btnInfoCosto.TabIndex = 32;
            this.btnInfoCosto.UseVisualStyleBackColor = true;
            // 
            // lblUtilidad
            // 
            this.lblUtilidad.AutoSize = true;
            this.lblUtilidad.Location = new System.Drawing.Point(9, 81);
            this.lblUtilidad.Name = "lblUtilidad";
            this.lblUtilidad.Size = new System.Drawing.Size(69, 16);
            this.lblUtilidad.TabIndex = 15;
            this.lblUtilidad.Text = "Utilidad %";
            // 
            // txtUtilidad
            // 
            this.txtUtilidad.Location = new System.Drawing.Point(120, 78);
            this.txtUtilidad.Name = "txtUtilidad";
            this.txtUtilidad.Size = new System.Drawing.Size(124, 22);
            this.txtUtilidad.TabIndex = 0;
            this.txtUtilidad.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtUtilidad_KeyUp);
            // 
            // lblPrecioSugerido
            // 
            this.lblPrecioSugerido.AutoSize = true;
            this.lblPrecioSugerido.Location = new System.Drawing.Point(9, 123);
            this.lblPrecioSugerido.Name = "lblPrecioSugerido";
            this.lblPrecioSugerido.Size = new System.Drawing.Size(105, 16);
            this.lblPrecioSugerido.TabIndex = 13;
            this.lblPrecioSugerido.Text = "Precio Sugerido";
            // 
            // txtPrecioSugerido
            // 
            this.txtPrecioSugerido.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtPrecioSugerido.Location = new System.Drawing.Point(120, 120);
            this.txtPrecioSugerido.Name = "txtPrecioSugerido";
            this.txtPrecioSugerido.ReadOnly = true;
            this.txtPrecioSugerido.Size = new System.Drawing.Size(124, 22);
            this.txtPrecioSugerido.TabIndex = 12;
            // 
            // lblPrecioAprox
            // 
            this.lblPrecioAprox.AutoSize = true;
            this.lblPrecioAprox.Location = new System.Drawing.Point(9, 165);
            this.lblPrecioAprox.Name = "lblPrecioAprox";
            this.lblPrecioAprox.Size = new System.Drawing.Size(88, 16);
            this.lblPrecioAprox.TabIndex = 34;
            this.lblPrecioAprox.Text = "Precio Aprox.";
            // 
            // txtPrecioAprox
            // 
            this.txtPrecioAprox.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtPrecioAprox.Location = new System.Drawing.Point(120, 162);
            this.txtPrecioAprox.Name = "txtPrecioAprox";
            this.txtPrecioAprox.ReadOnly = true;
            this.txtPrecioAprox.Size = new System.Drawing.Size(124, 22);
            this.txtPrecioAprox.TabIndex = 33;
            // 
            // lblPrecioVenta
            // 
            this.lblPrecioVenta.AutoSize = true;
            this.lblPrecioVenta.Location = new System.Drawing.Point(12, 206);
            this.lblPrecioVenta.Name = "lblPrecioVenta";
            this.lblPrecioVenta.Size = new System.Drawing.Size(104, 16);
            this.lblPrecioVenta.TabIndex = 11;
            this.lblPrecioVenta.Text = "Precio de Venta";
            // 
            // txtPrecioVenta
            // 
            this.txtPrecioVenta.Location = new System.Drawing.Point(120, 203);
            this.txtPrecioVenta.Name = "txtPrecioVenta";
            this.txtPrecioVenta.Size = new System.Drawing.Size(124, 22);
            this.txtPrecioVenta.TabIndex = 1;
            this.txtPrecioVenta.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPrecioVenta_KeyUp);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Image = ((System.Drawing.Image)(resources.GetObject("btnActualizar.Image")));
            this.btnActualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnActualizar.Location = new System.Drawing.Point(151, 243);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(93, 24);
            this.btnActualizar.TabIndex = 2;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // lblValores
            // 
            this.lblValores.AutoSize = true;
            this.lblValores.Location = new System.Drawing.Point(306, 18);
            this.lblValores.Name = "lblValores";
            this.lblValores.Size = new System.Drawing.Size(107, 16);
            this.lblValores.TabIndex = 40;
            this.lblValores.Text = "Valores iniciales";
            // 
            // lblValorCosto
            // 
            this.lblValorCosto.AutoSize = true;
            this.lblValorCosto.Location = new System.Drawing.Point(306, 46);
            this.lblValorCosto.Name = "lblValorCosto";
            this.lblValorCosto.Size = new System.Drawing.Size(15, 16);
            this.lblValorCosto.TabIndex = 35;
            this.lblValorCosto.Text = "0";
            // 
            // lblVUtilidad
            // 
            this.lblVUtilidad.AutoSize = true;
            this.lblVUtilidad.Location = new System.Drawing.Point(306, 84);
            this.lblVUtilidad.Name = "lblVUtilidad";
            this.lblVUtilidad.Size = new System.Drawing.Size(15, 16);
            this.lblVUtilidad.TabIndex = 36;
            this.lblVUtilidad.Text = "0";
            // 
            // lblValorSugerido
            // 
            this.lblValorSugerido.AutoSize = true;
            this.lblValorSugerido.Location = new System.Drawing.Point(306, 126);
            this.lblValorSugerido.Name = "lblValorSugerido";
            this.lblValorSugerido.Size = new System.Drawing.Size(15, 16);
            this.lblValorSugerido.TabIndex = 38;
            this.lblValorSugerido.Text = "0";
            // 
            // lblValorAprox
            // 
            this.lblValorAprox.AutoSize = true;
            this.lblValorAprox.Location = new System.Drawing.Point(306, 168);
            this.lblValorAprox.Name = "lblValorAprox";
            this.lblValorAprox.Size = new System.Drawing.Size(15, 16);
            this.lblValorAprox.TabIndex = 39;
            this.lblValorAprox.Text = "0";
            // 
            // lblValorVenta
            // 
            this.lblValorVenta.AutoSize = true;
            this.lblValorVenta.Location = new System.Drawing.Point(306, 209);
            this.lblValorVenta.Name = "lblValorVenta";
            this.lblValorVenta.Size = new System.Drawing.Size(15, 16);
            this.lblValorVenta.TabIndex = 37;
            this.lblValorVenta.Text = "0";
            // 
            // FrmPrecioProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(522, 398);
            this.Controls.Add(this.gbPrecio);
            this.Controls.Add(this.gbCargaProducto);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPrecioProducto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Precio de productos";
            this.Load += new System.EventHandler(this.FrmPrecioProducto_Load);
            this.gbCargaProducto.ResumeLayout(false);
            this.gbCargaProducto.PerformLayout();
            this.panelProducto.ResumeLayout(false);
            this.panelProducto.PerformLayout();
            this.gbPrecio.ResumeLayout(false);
            this.gbPrecio.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbCargaProducto;
        private System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.TextBox txtCodigoArticulo;
        private System.Windows.Forms.Panel panelProducto;
        private System.Windows.Forms.Label lblDatosProducto;
        private System.Windows.Forms.GroupBox gbPrecio;
        private System.Windows.Forms.Label lblCostoPromedo;
        private System.Windows.Forms.TextBox txtCosto;
        private System.Windows.Forms.Button btnInfoCosto;
        private System.Windows.Forms.Label lblUtilidad;
        private System.Windows.Forms.TextBox txtUtilidad;
        private System.Windows.Forms.Label lblPrecioSugerido;
        private System.Windows.Forms.TextBox txtPrecioSugerido;
        private System.Windows.Forms.Label lblPrecioAprox;
        private System.Windows.Forms.TextBox txtPrecioAprox;
        private System.Windows.Forms.Label lblPrecioVenta;
        private System.Windows.Forms.TextBox txtPrecioVenta;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Label lblValores;
        private System.Windows.Forms.Label lblValorCosto;
        private System.Windows.Forms.Label lblVUtilidad;
        private System.Windows.Forms.Label lblValorSugerido;
        private System.Windows.Forms.Label lblValorAprox;
        private System.Windows.Forms.Label lblValorVenta;
        private System.Windows.Forms.Button btnTallaYcolor;
    }
}