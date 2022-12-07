namespace Aplicacion.Configuracion.Inventarios
{
    partial class FrmInventarios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInventarios));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkNegativoTraslado = new System.Windows.Forms.CheckBox();
            this.chkVerCostoInventario = new System.Windows.Forms.CheckBox();
            this.chkCostoConIva = new System.Windows.Forms.CheckBox();
            this.btnInfoFacturaCero = new System.Windows.Forms.Button();
            this.btnInfoInventarioSistema = new System.Windows.Forms.Button();
            this.btnInfoNivleCero = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.chkFacturaNegativo = new System.Windows.Forms.CheckBox();
            this.chkInventarioSistema = new System.Windows.Forms.CheckBox();
            this.chkNivelar = new System.Windows.Forms.CheckBox();
            this.chkFrmConsultaInventario = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkNegativoTraslado);
            this.groupBox1.Controls.Add(this.chkFrmConsultaInventario);
            this.groupBox1.Controls.Add(this.chkVerCostoInventario);
            this.groupBox1.Controls.Add(this.chkCostoConIva);
            this.groupBox1.Controls.Add(this.btnInfoFacturaCero);
            this.groupBox1.Controls.Add(this.btnInfoInventarioSistema);
            this.groupBox1.Controls.Add(this.btnInfoNivleCero);
            this.groupBox1.Controls.Add(this.btnOk);
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.chkFacturaNegativo);
            this.groupBox1.Controls.Add(this.chkInventarioSistema);
            this.groupBox1.Controls.Add(this.chkNivelar);
            this.groupBox1.Location = new System.Drawing.Point(12, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(381, 330);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // chkNegativoTraslado
            // 
            this.chkNegativoTraslado.AutoSize = true;
            this.chkNegativoTraslado.Location = new System.Drawing.Point(41, 126);
            this.chkNegativoTraslado.Name = "chkNegativoTraslado";
            this.chkNegativoTraslado.Size = new System.Drawing.Size(293, 20);
            this.chkNegativoTraslado.TabIndex = 38;
            this.chkNegativoTraslado.Text = "Cantidad negativa en traslado de inventarios";
            this.chkNegativoTraslado.UseVisualStyleBackColor = true;
            // 
            // chkVerCostoInventario
            // 
            this.chkVerCostoInventario.AutoSize = true;
            this.chkVerCostoInventario.Location = new System.Drawing.Point(41, 55);
            this.chkVerCostoInventario.Name = "chkVerCostoInventario";
            this.chkVerCostoInventario.Size = new System.Drawing.Size(249, 20);
            this.chkVerCostoInventario.TabIndex = 37;
            this.chkVerCostoInventario.Text = "Ver Costo de Inventario. (En consulta)";
            this.chkVerCostoInventario.UseVisualStyleBackColor = true;
            // 
            // chkCostoConIva
            // 
            this.chkCostoConIva.AutoSize = true;
            this.chkCostoConIva.Location = new System.Drawing.Point(41, 90);
            this.chkCostoConIva.Name = "chkCostoConIva";
            this.chkCostoConIva.Size = new System.Drawing.Size(274, 20);
            this.chkCostoConIva.TabIndex = 36;
            this.chkCostoConIva.Text = "Costo de Inventario con IVA. (En consulta)";
            this.chkCostoConIva.UseVisualStyleBackColor = true;
            // 
            // btnInfoFacturaCero
            // 
            this.btnInfoFacturaCero.FlatAppearance.BorderSize = 0;
            this.btnInfoFacturaCero.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInfoFacturaCero.Image = ((System.Drawing.Image)(resources.GetObject("btnInfoFacturaCero.Image")));
            this.btnInfoFacturaCero.Location = new System.Drawing.Point(6, 232);
            this.btnInfoFacturaCero.Name = "btnInfoFacturaCero";
            this.btnInfoFacturaCero.Size = new System.Drawing.Size(25, 23);
            this.btnInfoFacturaCero.TabIndex = 35;
            this.btnInfoFacturaCero.UseVisualStyleBackColor = true;
            this.btnInfoFacturaCero.Click += new System.EventHandler(this.btnInfoFacturaCero_Click);
            // 
            // btnInfoInventarioSistema
            // 
            this.btnInfoInventarioSistema.FlatAppearance.BorderSize = 0;
            this.btnInfoInventarioSistema.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInfoInventarioSistema.Image = ((System.Drawing.Image)(resources.GetObject("btnInfoInventarioSistema.Image")));
            this.btnInfoInventarioSistema.Location = new System.Drawing.Point(6, 197);
            this.btnInfoInventarioSistema.Name = "btnInfoInventarioSistema";
            this.btnInfoInventarioSistema.Size = new System.Drawing.Size(25, 23);
            this.btnInfoInventarioSistema.TabIndex = 34;
            this.btnInfoInventarioSistema.UseVisualStyleBackColor = true;
            this.btnInfoInventarioSistema.Click += new System.EventHandler(this.btnInfoInventarioSistema_Click);
            // 
            // btnInfoNivleCero
            // 
            this.btnInfoNivleCero.FlatAppearance.BorderSize = 0;
            this.btnInfoNivleCero.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInfoNivleCero.Image = ((System.Drawing.Image)(resources.GetObject("btnInfoNivleCero.Image")));
            this.btnInfoNivleCero.Location = new System.Drawing.Point(6, 161);
            this.btnInfoNivleCero.Name = "btnInfoNivleCero";
            this.btnInfoNivleCero.Size = new System.Drawing.Size(25, 23);
            this.btnInfoNivleCero.TabIndex = 33;
            this.btnInfoNivleCero.UseVisualStyleBackColor = true;
            this.btnInfoNivleCero.Click += new System.EventHandler(this.btnInfoNivleCero_Click);
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnOk.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.Image")));
            this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOk.Location = new System.Drawing.Point(185, 269);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(83, 25);
            this.btnOk.TabIndex = 5;
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
            this.btnCancel.Location = new System.Drawing.Point(278, 269);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 25);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // chkFacturaNegativo
            // 
            this.chkFacturaNegativo.AutoSize = true;
            this.chkFacturaNegativo.Location = new System.Drawing.Point(41, 234);
            this.chkFacturaNegativo.Name = "chkFacturaNegativo";
            this.chkFacturaNegativo.Size = new System.Drawing.Size(333, 20);
            this.chkFacturaNegativo.TabIndex = 2;
            this.chkFacturaNegativo.Text = "Permitir factura con inventario en cero (0) o negativo";
            this.chkFacturaNegativo.UseVisualStyleBackColor = true;
            // 
            // chkInventarioSistema
            // 
            this.chkInventarioSistema.AutoSize = true;
            this.chkInventarioSistema.Location = new System.Drawing.Point(41, 199);
            this.chkInventarioSistema.Name = "chkInventarioSistema";
            this.chkInventarioSistema.Size = new System.Drawing.Size(199, 20);
            this.chkInventarioSistema.TabIndex = 1;
            this.chkInventarioSistema.Text = "Seguir inventario del sistema";
            this.chkInventarioSistema.UseVisualStyleBackColor = true;
            // 
            // chkNivelar
            // 
            this.chkNivelar.AutoSize = true;
            this.chkNivelar.Location = new System.Drawing.Point(41, 163);
            this.chkNivelar.Name = "chkNivelar";
            this.chkNivelar.Size = new System.Drawing.Size(323, 20);
            this.chkNivelar.TabIndex = 0;
            this.chkNivelar.Text = "Nivelar a Cero (0) los artículos sin inventario fisico.";
            this.chkNivelar.UseVisualStyleBackColor = true;
            // 
            // chkFrmConsultaInventario
            // 
            this.chkFrmConsultaInventario.AutoSize = true;
            this.chkFrmConsultaInventario.Location = new System.Drawing.Point(41, 20);
            this.chkFrmConsultaInventario.Name = "chkFrmConsultaInventario";
            this.chkFrmConsultaInventario.Size = new System.Drawing.Size(159, 20);
            this.chkFrmConsultaInventario.TabIndex = 37;
            this.chkFrmConsultaInventario.Text = "Consulta de inventario";
            this.chkFrmConsultaInventario.UseVisualStyleBackColor = true;
            // 
            // FrmInventarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(408, 352);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmInventarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manejo de Inventarios";
            this.Load += new System.EventHandler(this.FrmInventarios_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmInventarios_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkNivelar;
        private System.Windows.Forms.CheckBox chkInventarioSistema;
        private System.Windows.Forms.CheckBox chkFacturaNegativo;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnInfoFacturaCero;
        private System.Windows.Forms.Button btnInfoInventarioSistema;
        private System.Windows.Forms.Button btnInfoNivleCero;
        private System.Windows.Forms.CheckBox chkCostoConIva;
        private System.Windows.Forms.CheckBox chkVerCostoInventario;
        private System.Windows.Forms.CheckBox chkNegativoTraslado;
        private System.Windows.Forms.CheckBox chkFrmConsultaInventario;
    }
}