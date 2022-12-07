namespace Aplicacion.Inventario.Categoria
{
    partial class FrmModificarCategoria
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmModificarCategoria));
            this.gbmodificarcategoria = new System.Windows.Forms.GroupBox();
            this.txtmodificardes = new System.Windows.Forms.TextBox();
            this.txtmodificarnom = new System.Windows.Forms.TextBox();
            this.txtmodificarcod = new System.Windows.Forms.TextBox();
            this.lbldescripcion = new System.Windows.Forms.Label();
            this.lblnombre = new System.Windows.Forms.Label();
            this.lblmodificarcodigo = new System.Windows.Forms.Label();
            this.gbEstado = new System.Windows.Forms.GroupBox();
            this.lblestado = new System.Windows.Forms.Label();
            this.rbtEstadoInactivo = new System.Windows.Forms.RadioButton();
            this.txtmodificarEstado = new System.Windows.Forms.TextBox();
            this.rbtnEstadoActivo = new System.Windows.Forms.RadioButton();
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.tsbtnModificarGardar = new System.Windows.Forms.ToolStripButton();
            this.btnsalirModificar = new System.Windows.Forms.ToolStripButton();
            this.gbmodificarcategoria.SuspendLayout();
            this.gbEstado.SuspendLayout();
            this.tsMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbmodificarcategoria
            // 
            this.gbmodificarcategoria.Controls.Add(this.txtmodificardes);
            this.gbmodificarcategoria.Controls.Add(this.txtmodificarnom);
            this.gbmodificarcategoria.Controls.Add(this.txtmodificarcod);
            this.gbmodificarcategoria.Controls.Add(this.lbldescripcion);
            this.gbmodificarcategoria.Controls.Add(this.lblnombre);
            this.gbmodificarcategoria.Controls.Add(this.lblmodificarcodigo);
            this.gbmodificarcategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.gbmodificarcategoria.Location = new System.Drawing.Point(13, 34);
            this.gbmodificarcategoria.Margin = new System.Windows.Forms.Padding(4);
            this.gbmodificarcategoria.Name = "gbmodificarcategoria";
            this.gbmodificarcategoria.Padding = new System.Windows.Forms.Padding(4);
            this.gbmodificarcategoria.Size = new System.Drawing.Size(499, 209);
            this.gbmodificarcategoria.TabIndex = 0;
            this.gbmodificarcategoria.TabStop = false;
            this.gbmodificarcategoria.Text = "Modificar Categoria";
            // 
            // txtmodificardes
            // 
            this.txtmodificardes.Location = new System.Drawing.Point(106, 117);
            this.txtmodificardes.Margin = new System.Windows.Forms.Padding(4);
            this.txtmodificardes.Multiline = true;
            this.txtmodificardes.Name = "txtmodificardes";
            this.txtmodificardes.Size = new System.Drawing.Size(369, 74);
            this.txtmodificardes.TabIndex = 6;
            this.txtmodificardes.Validating += new System.ComponentModel.CancelEventHandler(this.txtmodificardes_Validating);
            // 
            // txtmodificarnom
            // 
            this.txtmodificarnom.Location = new System.Drawing.Point(106, 74);
            this.txtmodificarnom.Margin = new System.Windows.Forms.Padding(4);
            this.txtmodificarnom.Name = "txtmodificarnom";
            this.txtmodificarnom.Size = new System.Drawing.Size(369, 22);
            this.txtmodificarnom.TabIndex = 5;
            this.txtmodificarnom.Validating += new System.ComponentModel.CancelEventHandler(this.txtmodificarnom_Validating);
            // 
            // txtmodificarcod
            // 
            this.txtmodificarcod.Location = new System.Drawing.Point(106, 31);
            this.txtmodificarcod.Margin = new System.Windows.Forms.Padding(4);
            this.txtmodificarcod.Name = "txtmodificarcod";
            this.txtmodificarcod.Size = new System.Drawing.Size(369, 22);
            this.txtmodificarcod.TabIndex = 4;
            this.txtmodificarcod.Validating += new System.ComponentModel.CancelEventHandler(this.txtmodificarcod_Validating);
            // 
            // lbldescripcion
            // 
            this.lbldescripcion.AutoSize = true;
            this.lbldescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lbldescripcion.Location = new System.Drawing.Point(19, 120);
            this.lbldescripcion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbldescripcion.Name = "lbldescripcion";
            this.lbldescripcion.Size = new System.Drawing.Size(80, 16);
            this.lbldescripcion.TabIndex = 3;
            this.lbldescripcion.Text = "Descripcion";
            // 
            // lblnombre
            // 
            this.lblnombre.AutoSize = true;
            this.lblnombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblnombre.Location = new System.Drawing.Point(19, 77);
            this.lblnombre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblnombre.Name = "lblnombre";
            this.lblnombre.Size = new System.Drawing.Size(57, 16);
            this.lblnombre.TabIndex = 2;
            this.lblnombre.Text = "Nombre";
            // 
            // lblmodificarcodigo
            // 
            this.lblmodificarcodigo.AutoSize = true;
            this.lblmodificarcodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblmodificarcodigo.Location = new System.Drawing.Point(19, 34);
            this.lblmodificarcodigo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblmodificarcodigo.Name = "lblmodificarcodigo";
            this.lblmodificarcodigo.Size = new System.Drawing.Size(52, 16);
            this.lblmodificarcodigo.TabIndex = 1;
            this.lblmodificarcodigo.Text = "Codigo";
            // 
            // gbEstado
            // 
            this.gbEstado.Controls.Add(this.lblestado);
            this.gbEstado.Controls.Add(this.rbtEstadoInactivo);
            this.gbEstado.Controls.Add(this.txtmodificarEstado);
            this.gbEstado.Controls.Add(this.rbtnEstadoActivo);
            this.gbEstado.Location = new System.Drawing.Point(16, 249);
            this.gbEstado.Name = "gbEstado";
            this.gbEstado.Size = new System.Drawing.Size(496, 87);
            this.gbEstado.TabIndex = 12;
            this.gbEstado.TabStop = false;
            this.gbEstado.Text = "Estado de la Categoria";
            // 
            // lblestado
            // 
            this.lblestado.AutoSize = true;
            this.lblestado.Location = new System.Drawing.Point(16, 43);
            this.lblestado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblestado.Name = "lblestado";
            this.lblestado.Size = new System.Drawing.Size(51, 16);
            this.lblestado.TabIndex = 7;
            this.lblestado.Text = "Estado";
            // 
            // rbtEstadoInactivo
            // 
            this.rbtEstadoInactivo.AutoSize = true;
            this.rbtEstadoInactivo.Location = new System.Drawing.Point(335, 37);
            this.rbtEstadoInactivo.Name = "rbtEstadoInactivo";
            this.rbtEstadoInactivo.Size = new System.Drawing.Size(98, 20);
            this.rbtEstadoInactivo.TabIndex = 11;
            this.rbtEstadoInactivo.Text = "Dar de Baja";
            this.rbtEstadoInactivo.UseVisualStyleBackColor = true;
            // 
            // txtmodificarEstado
            // 
            this.txtmodificarEstado.Location = new System.Drawing.Point(103, 38);
            this.txtmodificarEstado.Margin = new System.Windows.Forms.Padding(4);
            this.txtmodificarEstado.Name = "txtmodificarEstado";
            this.txtmodificarEstado.ReadOnly = true;
            this.txtmodificarEstado.Size = new System.Drawing.Size(136, 22);
            this.txtmodificarEstado.TabIndex = 8;
            // 
            // rbtnEstadoActivo
            // 
            this.rbtnEstadoActivo.AutoSize = true;
            this.rbtnEstadoActivo.Location = new System.Drawing.Point(255, 38);
            this.rbtnEstadoActivo.Name = "rbtnEstadoActivo";
            this.rbtnEstadoActivo.Size = new System.Drawing.Size(67, 20);
            this.rbtnEstadoActivo.TabIndex = 10;
            this.rbtnEstadoActivo.Text = "Activar";
            this.rbtnEstadoActivo.UseVisualStyleBackColor = true;
            // 
            // tsMenu
            // 
            this.tsMenu.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnModificarGardar,
            this.btnsalirModificar});
            this.tsMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(522, 25);
            this.tsMenu.TabIndex = 1;
            this.tsMenu.Text = "Menu";
            // 
            // tsbtnModificarGardar
            // 
            this.tsbtnModificarGardar.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnModificarGardar.Image")));
            this.tsbtnModificarGardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnModificarGardar.Name = "tsbtnModificarGardar";
            this.tsbtnModificarGardar.Size = new System.Drawing.Size(76, 22);
            this.tsbtnModificarGardar.Text = "Guardar";
            this.tsbtnModificarGardar.Click += new System.EventHandler(this.btnmodificarcat_Click);
            // 
            // btnsalirModificar
            // 
            this.btnsalirModificar.Image = ((System.Drawing.Image)(resources.GetObject("btnsalirModificar.Image")));
            this.btnsalirModificar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnsalirModificar.Name = "btnsalirModificar";
            this.btnsalirModificar.Size = new System.Drawing.Size(53, 22);
            this.btnsalirModificar.Text = "Salir";
            this.btnsalirModificar.Click += new System.EventHandler(this.btnsalirModificar_Click);
            // 
            // FrmModificarCategoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(522, 345);
            this.Controls.Add(this.gbEstado);
            this.Controls.Add(this.tsMenu);
            this.Controls.Add(this.gbmodificarcategoria);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmModificarCategoria";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modificar Categoria";
            this.Load += new System.EventHandler(this.FrmModificarCategoria_Load);
            this.gbmodificarcategoria.ResumeLayout(false);
            this.gbmodificarcategoria.PerformLayout();
            this.gbEstado.ResumeLayout(false);
            this.gbEstado.PerformLayout();
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbmodificarcategoria;
        private System.Windows.Forms.TextBox txtmodificardes;
        private System.Windows.Forms.TextBox txtmodificarnom;
        private System.Windows.Forms.TextBox txtmodificarcod;
        private System.Windows.Forms.Label lbldescripcion;
        private System.Windows.Forms.Label lblnombre;
        private System.Windows.Forms.Label lblmodificarcodigo;
        private System.Windows.Forms.TextBox txtmodificarEstado;
        private System.Windows.Forms.Label lblestado;
        private System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.ToolStripButton btnsalirModificar;
        private System.Windows.Forms.GroupBox gbEstado;
        private System.Windows.Forms.RadioButton rbtEstadoInactivo;
        private System.Windows.Forms.RadioButton rbtnEstadoActivo;
        private System.Windows.Forms.ToolStripButton tsbtnModificarGardar;
    }
}