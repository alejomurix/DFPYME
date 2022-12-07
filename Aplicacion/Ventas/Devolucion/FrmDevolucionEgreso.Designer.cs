namespace Aplicacion.Ventas.Devolucion
{
    partial class FrmDevolucionEgreso
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDevolucionEgreso));
            this.gbInfoDevolucion = new System.Windows.Forms.GroupBox();
            this.lblValor = new System.Windows.Forms.Label();
            this.lblValorPesos = new System.Windows.Forms.Label();
            this.txtTotalDevolucion = new System.Windows.Forms.TextBox();
            this.gbBeneficiario = new System.Windows.Forms.GroupBox();
            this.txtNit = new System.Windows.Forms.TextBox();
            this.btnBuscarBeneficiario = new System.Windows.Forms.Button();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.gbCobro = new System.Windows.Forms.GroupBox();
            this.lblEfectivo = new System.Windows.Forms.Label();
            this.btnCobro = new System.Windows.Forms.Button();
            this.gbDesctoGlobal = new System.Windows.Forms.GroupBox();
            this.btnCambio = new System.Windows.Forms.Button();
            this.gbInfoDevolucion.SuspendLayout();
            this.gbBeneficiario.SuspendLayout();
            this.gbCobro.SuspendLayout();
            this.gbDesctoGlobal.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbInfoDevolucion
            // 
            this.gbInfoDevolucion.Controls.Add(this.lblValor);
            this.gbInfoDevolucion.Controls.Add(this.lblValorPesos);
            this.gbInfoDevolucion.Controls.Add(this.txtTotalDevolucion);
            this.gbInfoDevolucion.Location = new System.Drawing.Point(12, 12);
            this.gbInfoDevolucion.Name = "gbInfoDevolucion";
            this.gbInfoDevolucion.Size = new System.Drawing.Size(342, 71);
            this.gbInfoDevolucion.TabIndex = 4;
            this.gbInfoDevolucion.TabStop = false;
            this.gbInfoDevolucion.Text = "Información de Deovolución";
            // 
            // lblValor
            // 
            this.lblValor.AutoSize = true;
            this.lblValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblValor.Location = new System.Drawing.Point(11, 29);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(78, 18);
            this.lblValor.TabIndex = 27;
            this.lblValor.Text = "Val. Devol.";
            // 
            // lblValorPesos
            // 
            this.lblValorPesos.AutoSize = true;
            this.lblValorPesos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblValorPesos.Location = new System.Drawing.Point(94, 29);
            this.lblValorPesos.Name = "lblValorPesos";
            this.lblValorPesos.Size = new System.Drawing.Size(16, 18);
            this.lblValorPesos.TabIndex = 30;
            this.lblValorPesos.Text = "$";
            // 
            // txtTotalDevolucion
            // 
            this.txtTotalDevolucion.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtTotalDevolucion.Enabled = false;
            this.txtTotalDevolucion.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.txtTotalDevolucion.Location = new System.Drawing.Point(111, 25);
            this.txtTotalDevolucion.Name = "txtTotalDevolucion";
            this.txtTotalDevolucion.ReadOnly = true;
            this.txtTotalDevolucion.Size = new System.Drawing.Size(213, 27);
            this.txtTotalDevolucion.TabIndex = 26;
            // 
            // gbBeneficiario
            // 
            this.gbBeneficiario.Controls.Add(this.txtNit);
            this.gbBeneficiario.Controls.Add(this.btnBuscarBeneficiario);
            this.gbBeneficiario.Controls.Add(this.txtNombre);
            this.gbBeneficiario.Location = new System.Drawing.Point(12, 89);
            this.gbBeneficiario.Name = "gbBeneficiario";
            this.gbBeneficiario.Size = new System.Drawing.Size(342, 105);
            this.gbBeneficiario.TabIndex = 5;
            this.gbBeneficiario.TabStop = false;
            this.gbBeneficiario.Text = "Datos de Beneficiario";
            // 
            // txtNit
            // 
            this.txtNit.Location = new System.Drawing.Point(11, 29);
            this.txtNit.Name = "txtNit";
            this.txtNit.Size = new System.Drawing.Size(282, 22);
            this.txtNit.TabIndex = 0;
            this.txtNit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNit_KeyPress);
            // 
            // btnBuscarBeneficiario
            // 
            this.btnBuscarBeneficiario.Location = new System.Drawing.Point(299, 28);
            this.btnBuscarBeneficiario.Name = "btnBuscarBeneficiario";
            this.btnBuscarBeneficiario.Size = new System.Drawing.Size(25, 24);
            this.btnBuscarBeneficiario.TabIndex = 1;
            this.btnBuscarBeneficiario.Text = "...";
            this.btnBuscarBeneficiario.UseVisualStyleBackColor = true;
            this.btnBuscarBeneficiario.Click += new System.EventHandler(this.btnBuscarBeneficiario_Click);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(11, 65);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.ReadOnly = true;
            this.txtNombre.Size = new System.Drawing.Size(313, 22);
            this.txtNombre.TabIndex = 6;
            // 
            // gbCobro
            // 
            this.gbCobro.Controls.Add(this.lblEfectivo);
            this.gbCobro.Controls.Add(this.btnCobro);
            this.gbCobro.Location = new System.Drawing.Point(12, 200);
            this.gbCobro.Name = "gbCobro";
            this.gbCobro.Size = new System.Drawing.Size(342, 56);
            this.gbCobro.TabIndex = 9;
            this.gbCobro.TabStop = false;
            // 
            // lblEfectivo
            // 
            this.lblEfectivo.AutoSize = true;
            this.lblEfectivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblEfectivo.Location = new System.Drawing.Point(121, 20);
            this.lblEfectivo.Name = "lblEfectivo";
            this.lblEfectivo.Size = new System.Drawing.Size(149, 18);
            this.lblEfectivo.TabIndex = 6;
            this.lblEfectivo.Text = "Reintegro de Efectivo";
            // 
            // btnCobro
            // 
            this.btnCobro.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnCobro.Image = ((System.Drawing.Image)(resources.GetObject("btnCobro.Image")));
            this.btnCobro.Location = new System.Drawing.Point(285, 13);
            this.btnCobro.Name = "btnCobro";
            this.btnCobro.Size = new System.Drawing.Size(39, 34);
            this.btnCobro.TabIndex = 7;
            this.btnCobro.UseVisualStyleBackColor = true;
            this.btnCobro.Click += new System.EventHandler(this.btnCobro_Click);
            // 
            // gbDesctoGlobal
            // 
            this.gbDesctoGlobal.Controls.Add(this.btnCambio);
            this.gbDesctoGlobal.Location = new System.Drawing.Point(12, 257);
            this.gbDesctoGlobal.Name = "gbDesctoGlobal";
            this.gbDesctoGlobal.Size = new System.Drawing.Size(342, 18);
            this.gbDesctoGlobal.TabIndex = 11;
            this.gbDesctoGlobal.TabStop = false;
            this.gbDesctoGlobal.Visible = false;
            // 
            // btnCambio
            // 
            this.btnCambio.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnCambio.Image = ((System.Drawing.Image)(resources.GetObject("btnCambio.Image")));
            this.btnCambio.Location = new System.Drawing.Point(299, 9);
            this.btnCambio.Name = "btnCambio";
            this.btnCambio.Size = new System.Drawing.Size(22, 16);
            this.btnCambio.TabIndex = 9;
            this.btnCambio.UseVisualStyleBackColor = true;
            this.btnCambio.Click += new System.EventHandler(this.btnCambio_Click);
            // 
            // FrmDevolucionEgreso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(371, 279);
            this.Controls.Add(this.gbInfoDevolucion);
            this.Controls.Add(this.gbBeneficiario);
            this.Controls.Add(this.gbCobro);
            this.Controls.Add(this.gbDesctoGlobal);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDevolucionEgreso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Resumen de Devolución";
            this.Load += new System.EventHandler(this.FrmDevolucionEgreso_Load);
            this.gbInfoDevolucion.ResumeLayout(false);
            this.gbInfoDevolucion.PerformLayout();
            this.gbBeneficiario.ResumeLayout(false);
            this.gbBeneficiario.PerformLayout();
            this.gbCobro.ResumeLayout(false);
            this.gbCobro.PerformLayout();
            this.gbDesctoGlobal.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbInfoDevolucion;
        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.Label lblValorPesos;
        public System.Windows.Forms.TextBox txtTotalDevolucion;
        private System.Windows.Forms.GroupBox gbBeneficiario;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Button btnBuscarBeneficiario;
        private System.Windows.Forms.TextBox txtNit;
        public System.Windows.Forms.GroupBox gbCobro;
        private System.Windows.Forms.Button btnCobro;
        private System.Windows.Forms.Label lblEfectivo;
        public System.Windows.Forms.GroupBox gbDesctoGlobal;
        private System.Windows.Forms.Button btnCambio;
    }
}