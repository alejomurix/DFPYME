namespace Aplicacion.Administracion.Plantilla
{
    partial class FrmSeleccionCuenta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSeleccionCuenta));
            this.gbSeleccionCuenta = new System.Windows.Forms.GroupBox();
            this.txtCuenta = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.cbNaturaleza = new System.Windows.Forms.ComboBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.gbSeleccionCuenta.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbSeleccionCuenta
            // 
            this.gbSeleccionCuenta.Controls.Add(this.txtCuenta);
            this.gbSeleccionCuenta.Controls.Add(this.btnBuscar);
            this.gbSeleccionCuenta.Controls.Add(this.txtNombre);
            this.gbSeleccionCuenta.Controls.Add(this.cbNaturaleza);
            this.gbSeleccionCuenta.Controls.Add(this.btnAceptar);
            this.gbSeleccionCuenta.Controls.Add(this.btnCancelar);
            this.gbSeleccionCuenta.Location = new System.Drawing.Point(9, 9);
            this.gbSeleccionCuenta.Name = "gbSeleccionCuenta";
            this.gbSeleccionCuenta.Size = new System.Drawing.Size(646, 106);
            this.gbSeleccionCuenta.TabIndex = 0;
            this.gbSeleccionCuenta.TabStop = false;
            // 
            // txtCuenta
            // 
            this.txtCuenta.Location = new System.Drawing.Point(11, 25);
            this.txtCuenta.Name = "txtCuenta";
            this.txtCuenta.Size = new System.Drawing.Size(100, 22);
            this.txtCuenta.TabIndex = 0;
            this.txtCuenta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCuenta_KeyPress);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.btnBuscar.Location = new System.Drawing.Point(115, 26);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(24, 20);
            this.btnBuscar.TabIndex = 1;
            this.btnBuscar.Text = "...";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(145, 25);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.ReadOnly = true;
            this.txtNombre.Size = new System.Drawing.Size(374, 22);
            this.txtNombre.TabIndex = 2;
            // 
            // cbNaturaleza
            // 
            this.cbNaturaleza.DisplayMember = "Nombre";
            this.cbNaturaleza.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNaturaleza.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cbNaturaleza.FormattingEnabled = true;
            this.cbNaturaleza.Location = new System.Drawing.Point(525, 24);
            this.cbNaturaleza.Name = "cbNaturaleza";
            this.cbNaturaleza.Size = new System.Drawing.Size(109, 23);
            this.cbNaturaleza.TabIndex = 3;
            this.cbNaturaleza.ValueMember = "Id";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.Image")));
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptar.Location = new System.Drawing.Point(450, 68);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(89, 24);
            this.btnAceptar.TabIndex = 4;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(545, 68);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(89, 24);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // FrmSeleccionCuenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(670, 127);
            this.Controls.Add(this.gbSeleccionCuenta);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSeleccionCuenta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Selección de cuenta";
            this.Load += new System.EventHandler(this.FrmSeleccionCuenta_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmSeleccionCuenta_KeyDown);
            this.gbSeleccionCuenta.ResumeLayout(false);
            this.gbSeleccionCuenta.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSeleccionCuenta;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtCuenta;
        private System.Windows.Forms.ComboBox cbNaturaleza;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
    }
}