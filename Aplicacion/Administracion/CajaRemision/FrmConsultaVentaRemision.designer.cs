using System.Windows.Forms;
using System.Drawing;
namespace Aplicacion.Administracion.CajaRemision
{
    partial class FrmConsultaVentaRemision
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConsultaVentaRemision));
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.btnComprobante = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(17, 20);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(100, 22);
            this.dtpFecha.TabIndex = 0;
            // 
            // btnComprobante
            // 
            this.btnComprobante.Image = ((System.Drawing.Image)(resources.GetObject("btnComprobante.Image")));
            this.btnComprobante.Location = new System.Drawing.Point(36, 54);
            this.btnComprobante.Name = "btnComprobante";
            this.btnComprobante.Size = new System.Drawing.Size(43, 45);
            this.btnComprobante.TabIndex = 1;
            this.btnComprobante.UseVisualStyleBackColor = true;
            this.btnComprobante.Click += new System.EventHandler(this.btnComprobante_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Comprobante";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.dtpFecha);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.btnComprobante);
            this.groupBox5.Location = new System.Drawing.Point(7, 5);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(284, 138);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            // 
            // FrmConsultaVentaRemision
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(298, 151);
            this.Controls.Add(this.groupBox5);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmConsultaVentaRemision";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta remision";
            this.Load += new System.EventHandler(this.FrmConsultaCaja_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmConsultaCajaFecha_KeyDown);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Button btnComprobante;
        private System.Windows.Forms.GroupBox groupBox5;
        private Label label1;
    }
}