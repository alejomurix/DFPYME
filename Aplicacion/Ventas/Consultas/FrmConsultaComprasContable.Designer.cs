namespace Aplicacion.Ventas.Consultas
{
    partial class FrmConsultaComprasContable
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConsultaComprasContable));
            this.gbCritero = new System.Windows.Forms.GroupBox();
            this.dtpFecha1 = new System.Windows.Forms.DateTimePicker();
            this.dtpFecha2 = new System.Windows.Forms.DateTimePicker();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.gbCritero.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbCritero
            // 
            this.gbCritero.Controls.Add(this.dtpFecha1);
            this.gbCritero.Controls.Add(this.dtpFecha2);
            this.gbCritero.Controls.Add(this.btnBuscar);
            this.gbCritero.Location = new System.Drawing.Point(12, 12);
            this.gbCritero.Name = "gbCritero";
            this.gbCritero.Size = new System.Drawing.Size(269, 64);
            this.gbCritero.TabIndex = 10;
            this.gbCritero.TabStop = false;
            this.gbCritero.Text = "Criterio de Consulta";
            // 
            // dtpFecha1
            // 
            this.dtpFecha1.CustomFormat = "dd/MM/yyyy";
            this.dtpFecha1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecha1.Location = new System.Drawing.Point(13, 25);
            this.dtpFecha1.Name = "dtpFecha1";
            this.dtpFecha1.Size = new System.Drawing.Size(96, 22);
            this.dtpFecha1.TabIndex = 7;
            // 
            // dtpFecha2
            // 
            this.dtpFecha2.CustomFormat = "dd/MM/yyyy";
            this.dtpFecha2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecha2.Location = new System.Drawing.Point(119, 25);
            this.dtpFecha2.Name = "dtpFecha2";
            this.dtpFecha2.Size = new System.Drawing.Size(97, 22);
            this.dtpFecha2.TabIndex = 8;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(227, 24);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(25, 23);
            this.btnBuscar.TabIndex = 9;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // FrmConsultaImpuestos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(303, 89);
            this.Controls.Add(this.gbCritero);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmConsultaImpuestos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta venta de productos";
            this.Load += new System.EventHandler(this.FrmConsultaImpuestos_Load);
            this.gbCritero.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbCritero;
        private System.Windows.Forms.DateTimePicker dtpFecha1;
        private System.Windows.Forms.DateTimePicker dtpFecha2;
        private System.Windows.Forms.Button btnBuscar;
    }
}