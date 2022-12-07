namespace Aplicacion.Inventario.SalidaEntrada
{
    partial class FrmAdminInventario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAdminInventario));
            this.gbArticuloSalida = new System.Windows.Forms.GroupBox();
            this.lblCantidadInventario = new System.Windows.Forms.Label();
            this.txtInventarioSalida = new System.Windows.Forms.TextBox();
            this.lblCantidadAgrupar = new System.Windows.Forms.Label();
            this.txtCantSalida = new System.Windows.Forms.TextBox();
            this.lblArticulo = new System.Windows.Forms.Label();
            this.txtCodigoSalida = new System.Windows.Forms.TextBox();
            this.pArticulo = new System.Windows.Forms.Panel();
            this.lblArticuloSalida = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtInventarioEntrada = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCantEntrada = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCodigoEntrada = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblArticuloEntrada = new System.Windows.Forms.Label();
            this.tsmenu = new System.Windows.Forms.ToolStrip();
            this.tsbtnGuardar = new System.Windows.Forms.ToolStripButton();
            this.tsbtnSalir = new System.Windows.Forms.ToolStripButton();
            this.gbArticuloSalida.SuspendLayout();
            this.pArticulo.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tsmenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbArticuloSalida
            // 
            this.gbArticuloSalida.BackColor = System.Drawing.SystemColors.Window;
            this.gbArticuloSalida.Controls.Add(this.lblCantidadInventario);
            this.gbArticuloSalida.Controls.Add(this.txtInventarioSalida);
            this.gbArticuloSalida.Controls.Add(this.lblCantidadAgrupar);
            this.gbArticuloSalida.Controls.Add(this.txtCantSalida);
            this.gbArticuloSalida.Controls.Add(this.lblArticulo);
            this.gbArticuloSalida.Controls.Add(this.txtCodigoSalida);
            this.gbArticuloSalida.Controls.Add(this.pArticulo);
            this.gbArticuloSalida.Location = new System.Drawing.Point(12, 40);
            this.gbArticuloSalida.Name = "gbArticuloSalida";
            this.gbArticuloSalida.Size = new System.Drawing.Size(610, 140);
            this.gbArticuloSalida.TabIndex = 3;
            this.gbArticuloSalida.TabStop = false;
            this.gbArticuloSalida.Text = "Articulo de salida";
            // 
            // lblCantidadInventario
            // 
            this.lblCantidadInventario.AutoSize = true;
            this.lblCantidadInventario.Location = new System.Drawing.Point(381, 23);
            this.lblCantidadInventario.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCantidadInventario.Name = "lblCantidadInventario";
            this.lblCantidadInventario.Size = new System.Drawing.Size(66, 16);
            this.lblCantidadInventario.TabIndex = 13;
            this.lblCantidadInventario.Text = "Inventario";
            // 
            // txtInventarioSalida
            // 
            this.txtInventarioSalida.Enabled = false;
            this.txtInventarioSalida.Location = new System.Drawing.Point(381, 46);
            this.txtInventarioSalida.Margin = new System.Windows.Forms.Padding(4);
            this.txtInventarioSalida.Name = "txtInventarioSalida";
            this.txtInventarioSalida.Size = new System.Drawing.Size(100, 22);
            this.txtInventarioSalida.TabIndex = 11;
            // 
            // lblCantidadAgrupar
            // 
            this.lblCantidadAgrupar.AutoSize = true;
            this.lblCantidadAgrupar.Location = new System.Drawing.Point(491, 23);
            this.lblCantidadAgrupar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCantidadAgrupar.Name = "lblCantidadAgrupar";
            this.lblCantidadAgrupar.Size = new System.Drawing.Size(47, 16);
            this.lblCantidadAgrupar.TabIndex = 14;
            this.lblCantidadAgrupar.Text = "Salida";
            // 
            // txtCantSalida
            // 
            this.txtCantSalida.Location = new System.Drawing.Point(489, 46);
            this.txtCantSalida.Margin = new System.Windows.Forms.Padding(4);
            this.txtCantSalida.MaxLength = 20;
            this.txtCantSalida.Name = "txtCantSalida";
            this.txtCantSalida.Size = new System.Drawing.Size(100, 22);
            this.txtCantSalida.TabIndex = 12;
            this.txtCantSalida.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantSalida_KeyPress);
            this.txtCantSalida.Validating += new System.ComponentModel.CancelEventHandler(this.txtCantSalida_Validating);
            // 
            // lblArticulo
            // 
            this.lblArticulo.AutoSize = true;
            this.lblArticulo.Location = new System.Drawing.Point(10, 49);
            this.lblArticulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblArticulo.Name = "lblArticulo";
            this.lblArticulo.Size = new System.Drawing.Size(52, 16);
            this.lblArticulo.TabIndex = 10;
            this.lblArticulo.Text = "Articulo";
            // 
            // txtCodigoSalida
            // 
            this.txtCodigoSalida.Location = new System.Drawing.Point(65, 46);
            this.txtCodigoSalida.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodigoSalida.MaxLength = 20;
            this.txtCodigoSalida.Name = "txtCodigoSalida";
            this.txtCodigoSalida.Size = new System.Drawing.Size(307, 22);
            this.txtCodigoSalida.TabIndex = 8;
            this.txtCodigoSalida.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoSalida_KeyPress);
            // 
            // pArticulo
            // 
            this.pArticulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.pArticulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pArticulo.Controls.Add(this.lblArticuloSalida);
            this.pArticulo.Location = new System.Drawing.Point(13, 90);
            this.pArticulo.Margin = new System.Windows.Forms.Padding(4);
            this.pArticulo.Name = "pArticulo";
            this.pArticulo.Size = new System.Drawing.Size(576, 22);
            this.pArticulo.TabIndex = 9;
            // 
            // lblArticuloSalida
            // 
            this.lblArticuloSalida.AutoSize = true;
            this.lblArticuloSalida.Location = new System.Drawing.Point(8, 3);
            this.lblArticuloSalida.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblArticuloSalida.Name = "lblArticuloSalida";
            this.lblArticuloSalida.Size = new System.Drawing.Size(0, 16);
            this.lblArticuloSalida.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Window;
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtInventarioEntrada);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtCantEntrada);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtCodigoEntrada);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Location = new System.Drawing.Point(12, 186);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(610, 133);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Articulo de entrada";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(381, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 16);
            this.label1.TabIndex = 13;
            this.label1.Text = "Inventario";
            // 
            // txtInventarioEntrada
            // 
            this.txtInventarioEntrada.Enabled = false;
            this.txtInventarioEntrada.Location = new System.Drawing.Point(381, 47);
            this.txtInventarioEntrada.Margin = new System.Windows.Forms.Padding(4);
            this.txtInventarioEntrada.Name = "txtInventarioEntrada";
            this.txtInventarioEntrada.Size = new System.Drawing.Size(100, 22);
            this.txtInventarioEntrada.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(491, 24);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 16);
            this.label2.TabIndex = 14;
            this.label2.Text = "Entrada";
            // 
            // txtCantEntrada
            // 
            this.txtCantEntrada.Location = new System.Drawing.Point(489, 47);
            this.txtCantEntrada.Margin = new System.Windows.Forms.Padding(4);
            this.txtCantEntrada.MaxLength = 20;
            this.txtCantEntrada.Name = "txtCantEntrada";
            this.txtCantEntrada.Size = new System.Drawing.Size(100, 22);
            this.txtCantEntrada.TabIndex = 12;
            this.txtCantEntrada.Validating += new System.ComponentModel.CancelEventHandler(this.txtCantEntrada_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 50);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Articulo";
            // 
            // txtCodigoEntrada
            // 
            this.txtCodigoEntrada.Location = new System.Drawing.Point(65, 47);
            this.txtCodigoEntrada.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodigoEntrada.MaxLength = 20;
            this.txtCodigoEntrada.Name = "txtCodigoEntrada";
            this.txtCodigoEntrada.Size = new System.Drawing.Size(307, 22);
            this.txtCodigoEntrada.TabIndex = 8;
            this.txtCodigoEntrada.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoEntrada_KeyPress);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(220)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblArticuloEntrada);
            this.panel1.Location = new System.Drawing.Point(13, 87);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(576, 22);
            this.panel1.TabIndex = 9;
            // 
            // lblArticuloEntrada
            // 
            this.lblArticuloEntrada.AutoSize = true;
            this.lblArticuloEntrada.Location = new System.Drawing.Point(8, 3);
            this.lblArticuloEntrada.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblArticuloEntrada.Name = "lblArticuloEntrada";
            this.lblArticuloEntrada.Size = new System.Drawing.Size(0, 16);
            this.lblArticuloEntrada.TabIndex = 0;
            // 
            // tsmenu
            // 
            this.tsmenu.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsmenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnGuardar,
            this.tsbtnSalir});
            this.tsmenu.Location = new System.Drawing.Point(0, 0);
            this.tsmenu.Name = "tsmenu";
            this.tsmenu.Size = new System.Drawing.Size(638, 25);
            this.tsmenu.TabIndex = 17;
            this.tsmenu.Text = "Menu";
            // 
            // tsbtnGuardar
            // 
            this.tsbtnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnGuardar.Image")));
            this.tsbtnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnGuardar.Name = "tsbtnGuardar";
            this.tsbtnGuardar.Size = new System.Drawing.Size(101, 22);
            this.tsbtnGuardar.Text = "Guardar [F2]";
            this.tsbtnGuardar.Click += new System.EventHandler(this.tsbtnGuardar_Click);
            // 
            // tsbtnSalir
            // 
            this.tsbtnSalir.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnSalir.Image")));
            this.tsbtnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnSalir.Name = "tsbtnSalir";
            this.tsbtnSalir.Size = new System.Drawing.Size(87, 22);
            this.tsbtnSalir.Text = "Salir [ESC]";
            this.tsbtnSalir.Click += new System.EventHandler(this.tsbtnSalir_Click);
            // 
            // FrmAdminInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(638, 334);
            this.Controls.Add(this.tsmenu);
            this.Controls.Add(this.gbArticuloSalida);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAdminInventario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administración de inventario";
            this.Load += new System.EventHandler(this.FrmEntradaSalida_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmAdminInventario_KeyDown);
            this.gbArticuloSalida.ResumeLayout(false);
            this.gbArticuloSalida.PerformLayout();
            this.pArticulo.ResumeLayout(false);
            this.pArticulo.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tsmenu.ResumeLayout(false);
            this.tsmenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbArticuloSalida;
        private System.Windows.Forms.Label lblArticulo;
        private System.Windows.Forms.TextBox txtCodigoSalida;
        private System.Windows.Forms.Panel pArticulo;
        private System.Windows.Forms.Label lblArticuloSalida;
        private System.Windows.Forms.Label lblCantidadInventario;
        private System.Windows.Forms.TextBox txtInventarioSalida;
        private System.Windows.Forms.Label lblCantidadAgrupar;
        private System.Windows.Forms.TextBox txtCantSalida;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtInventarioEntrada;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCantEntrada;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCodigoEntrada;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblArticuloEntrada;
        private System.Windows.Forms.ToolStrip tsmenu;
        private System.Windows.Forms.ToolStripButton tsbtnGuardar;
        private System.Windows.Forms.ToolStripButton tsbtnSalir;

    }
}