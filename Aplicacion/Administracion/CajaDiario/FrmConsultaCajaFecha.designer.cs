using System.Windows.Forms;
using System.Drawing;
namespace Aplicacion.Administracion.CajaDiario
{
    partial class FrmConsultaCajaFecha
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConsultaCajaFecha));
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.btnComprobante = new System.Windows.Forms.Button();
            this.btnNotaContable = new System.Windows.Forms.Button();
            this.btnFiscal = new System.Windows.Forms.Button();
            this.gbCaja = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gbGeneral = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnComprobanteGeneral = new System.Windows.Forms.Button();
            this.btnFiscalGeneral = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cbCajas = new System.Windows.Forms.ComboBox();
            this.tcCajaDiario = new System.Windows.Forms.TabControl();
            this.tpConvencional = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.gbPeriodo = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnFiscalGeneralMes = new System.Windows.Forms.Button();
            this.tpRetroActivo = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnComprobanteCajaR = new System.Windows.Forms.Button();
            this.btnFiscalCajaR = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnCompGralR = new System.Windows.Forms.Button();
            this.btnFiscalGralR = new System.Windows.Forms.Button();
            this.gbCaja.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gbGeneral.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tcCajaDiario.SuspendLayout();
            this.tpConvencional.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.gbPeriodo.SuspendLayout();
            this.tpRetroActivo.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(17, 20);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(252, 22);
            this.dtpFecha.TabIndex = 0;
            // 
            // btnComprobante
            // 
            this.btnComprobante.Image = ((System.Drawing.Image)(resources.GetObject("btnComprobante.Image")));
            this.btnComprobante.Location = new System.Drawing.Point(37, 122);
            this.btnComprobante.Name = "btnComprobante";
            this.btnComprobante.Size = new System.Drawing.Size(43, 45);
            this.btnComprobante.TabIndex = 1;
            this.btnComprobante.UseVisualStyleBackColor = true;
            this.btnComprobante.Visible = false;
            this.btnComprobante.Click += new System.EventHandler(this.btnComprobante_Click);
            // 
            // btnNotaContable
            // 
            this.btnNotaContable.Location = new System.Drawing.Point(6, 10);
            this.btnNotaContable.Name = "btnNotaContable";
            this.btnNotaContable.Size = new System.Drawing.Size(14, 23);
            this.btnNotaContable.TabIndex = 0;
            this.btnNotaContable.Text = "Ver";
            this.btnNotaContable.UseVisualStyleBackColor = true;
            this.btnNotaContable.Click += new System.EventHandler(this.btnNotaContable_Click);
            // 
            // btnFiscal
            // 
            this.btnFiscal.Image = ((System.Drawing.Image)(resources.GetObject("btnFiscal.Image")));
            this.btnFiscal.Location = new System.Drawing.Point(37, 25);
            this.btnFiscal.Name = "btnFiscal";
            this.btnFiscal.Size = new System.Drawing.Size(43, 45);
            this.btnFiscal.TabIndex = 0;
            this.btnFiscal.UseVisualStyleBackColor = true;
            this.btnFiscal.Click += new System.EventHandler(this.btnFiscal_Click);
            // 
            // gbCaja
            // 
            this.gbCaja.Controls.Add(this.label2);
            this.gbCaja.Controls.Add(this.label1);
            this.gbCaja.Controls.Add(this.btnFiscal);
            this.gbCaja.Controls.Add(this.btnComprobante);
            this.gbCaja.Location = new System.Drawing.Point(14, 14);
            this.gbCaja.Name = "gbCaja";
            this.gbCaja.Size = new System.Drawing.Size(119, 105);
            this.gbCaja.TabIndex = 1;
            this.gbCaja.TabStop = false;
            this.gbCaja.Text = "Caja";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Informe Fiscal";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 171);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Comprobante";
            this.label1.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnNotaContable);
            this.groupBox2.Enabled = false;
            this.groupBox2.Location = new System.Drawing.Point(276, 141);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(11, 30);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Visible = false;
            // 
            // gbGeneral
            // 
            this.gbGeneral.Controls.Add(this.label4);
            this.gbGeneral.Controls.Add(this.label3);
            this.gbGeneral.Controls.Add(this.btnComprobanteGeneral);
            this.gbGeneral.Controls.Add(this.btnFiscalGeneral);
            this.gbGeneral.Location = new System.Drawing.Point(144, 14);
            this.gbGeneral.Name = "gbGeneral";
            this.gbGeneral.Size = new System.Drawing.Size(121, 105);
            this.gbGeneral.TabIndex = 3;
            this.gbGeneral.TabStop = false;
            this.gbGeneral.Text = "General";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Informe Fiscal";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Comprobante";
            this.label3.Visible = false;
            // 
            // btnComprobanteGeneral
            // 
            this.btnComprobanteGeneral.Image = ((System.Drawing.Image)(resources.GetObject("btnComprobanteGeneral.Image")));
            this.btnComprobanteGeneral.Location = new System.Drawing.Point(44, 122);
            this.btnComprobanteGeneral.Name = "btnComprobanteGeneral";
            this.btnComprobanteGeneral.Size = new System.Drawing.Size(43, 45);
            this.btnComprobanteGeneral.TabIndex = 1;
            this.btnComprobanteGeneral.UseVisualStyleBackColor = true;
            this.btnComprobanteGeneral.Visible = false;
            this.btnComprobanteGeneral.Click += new System.EventHandler(this.btnComprobanteGeneral_Click);
            // 
            // btnFiscalGeneral
            // 
            this.btnFiscalGeneral.Image = ((System.Drawing.Image)(resources.GetObject("btnFiscalGeneral.Image")));
            this.btnFiscalGeneral.Location = new System.Drawing.Point(39, 25);
            this.btnFiscalGeneral.Name = "btnFiscalGeneral";
            this.btnFiscalGeneral.Size = new System.Drawing.Size(43, 45);
            this.btnFiscalGeneral.TabIndex = 0;
            this.btnFiscalGeneral.UseVisualStyleBackColor = true;
            this.btnFiscalGeneral.Click += new System.EventHandler(this.btnFiscalGeneral_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.cbCajas);
            this.groupBox5.Controls.Add(this.dtpFecha);
            this.groupBox5.Location = new System.Drawing.Point(7, 5);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(284, 90);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 55);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(36, 16);
            this.label9.TabIndex = 23;
            this.label9.Text = "Caja";
            // 
            // cbCajas
            // 
            this.cbCajas.DisplayMember = "numerocaja";
            this.cbCajas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCajas.FormattingEnabled = true;
            this.cbCajas.Location = new System.Drawing.Point(62, 52);
            this.cbCajas.Name = "cbCajas";
            this.cbCajas.Size = new System.Drawing.Size(68, 24);
            this.cbCajas.TabIndex = 22;
            this.cbCajas.ValueMember = "idcaja";
            // 
            // tcCajaDiario
            // 
            this.tcCajaDiario.Controls.Add(this.tpConvencional);
            this.tcCajaDiario.Controls.Add(this.tabPage1);
            this.tcCajaDiario.Controls.Add(this.tpRetroActivo);
            this.tcCajaDiario.Location = new System.Drawing.Point(7, 101);
            this.tcCajaDiario.Name = "tcCajaDiario";
            this.tcCajaDiario.SelectedIndex = 0;
            this.tcCajaDiario.Size = new System.Drawing.Size(284, 156);
            this.tcCajaDiario.TabIndex = 12;
            // 
            // tpConvencional
            // 
            this.tpConvencional.Controls.Add(this.gbCaja);
            this.tpConvencional.Controls.Add(this.gbGeneral);
            this.tpConvencional.Location = new System.Drawing.Point(4, 25);
            this.tpConvencional.Name = "tpConvencional";
            this.tpConvencional.Padding = new System.Windows.Forms.Padding(3);
            this.tpConvencional.Size = new System.Drawing.Size(276, 127);
            this.tpConvencional.TabIndex = 0;
            this.tpConvencional.Text = "Fecha";
            this.tpConvencional.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.gbPeriodo);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(276, 222);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Periodo mes";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // gbPeriodo
            // 
            this.gbPeriodo.Controls.Add(this.label10);
            this.gbPeriodo.Controls.Add(this.btnFiscalGeneralMes);
            this.gbPeriodo.Location = new System.Drawing.Point(13, 15);
            this.gbPeriodo.Name = "gbPeriodo";
            this.gbPeriodo.Size = new System.Drawing.Size(121, 108);
            this.gbPeriodo.TabIndex = 3;
            this.gbPeriodo.TabStop = false;
            this.gbPeriodo.Text = "General";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(14, 75);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(91, 16);
            this.label10.TabIndex = 4;
            this.label10.Text = "Informe Fiscal";
            // 
            // btnFiscalGeneralMes
            // 
            this.btnFiscalGeneralMes.Image = ((System.Drawing.Image)(resources.GetObject("btnFiscalGeneralMes.Image")));
            this.btnFiscalGeneralMes.Location = new System.Drawing.Point(36, 27);
            this.btnFiscalGeneralMes.Name = "btnFiscalGeneralMes";
            this.btnFiscalGeneralMes.Size = new System.Drawing.Size(43, 45);
            this.btnFiscalGeneralMes.TabIndex = 0;
            this.btnFiscalGeneralMes.UseVisualStyleBackColor = true;
            this.btnFiscalGeneralMes.Click += new System.EventHandler(this.btnFiscalGeneralMes_Click);
            // 
            // tpRetroActivo
            // 
            this.tpRetroActivo.Controls.Add(this.groupBox3);
            this.tpRetroActivo.Controls.Add(this.groupBox4);
            this.tpRetroActivo.Location = new System.Drawing.Point(4, 25);
            this.tpRetroActivo.Name = "tpRetroActivo";
            this.tpRetroActivo.Padding = new System.Windows.Forms.Padding(3);
            this.tpRetroActivo.Size = new System.Drawing.Size(276, 222);
            this.tpRetroActivo.TabIndex = 1;
            this.tpRetroActivo.Text = "Retroactivo";
            this.tpRetroActivo.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.btnComprobanteCajaR);
            this.groupBox3.Controls.Add(this.btnFiscalCajaR);
            this.groupBox3.Location = new System.Drawing.Point(14, 7);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(115, 171);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Caja";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 144);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 16);
            this.label6.TabIndex = 4;
            this.label6.Text = "Informe Fiscal";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 16);
            this.label5.TabIndex = 3;
            this.label5.Text = "Comprobante";
            // 
            // btnComprobanteCajaR
            // 
            this.btnComprobanteCajaR.Image = ((System.Drawing.Image)(resources.GetObject("btnComprobanteCajaR.Image")));
            this.btnComprobanteCajaR.Location = new System.Drawing.Point(36, 18);
            this.btnComprobanteCajaR.Name = "btnComprobanteCajaR";
            this.btnComprobanteCajaR.Size = new System.Drawing.Size(43, 45);
            this.btnComprobanteCajaR.TabIndex = 1;
            this.btnComprobanteCajaR.UseVisualStyleBackColor = true;
            this.btnComprobanteCajaR.Click += new System.EventHandler(this.btnComprobanteCajaR_Click);
            // 
            // btnFiscalCajaR
            // 
            this.btnFiscalCajaR.Image = ((System.Drawing.Image)(resources.GetObject("btnFiscalCajaR.Image")));
            this.btnFiscalCajaR.Location = new System.Drawing.Point(36, 96);
            this.btnFiscalCajaR.Name = "btnFiscalCajaR";
            this.btnFiscalCajaR.Size = new System.Drawing.Size(43, 45);
            this.btnFiscalCajaR.TabIndex = 0;
            this.btnFiscalCajaR.UseVisualStyleBackColor = true;
            this.btnFiscalCajaR.Click += new System.EventHandler(this.btnFiscalCajaR_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.btnCompGralR);
            this.groupBox4.Controls.Add(this.btnFiscalGralR);
            this.groupBox4.Location = new System.Drawing.Point(147, 7);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(115, 171);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "General";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 145);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 16);
            this.label8.TabIndex = 5;
            this.label8.Text = "Informe Fiscal";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 16);
            this.label7.TabIndex = 4;
            this.label7.Text = "Comprobante";
            // 
            // btnCompGralR
            // 
            this.btnCompGralR.Image = ((System.Drawing.Image)(resources.GetObject("btnCompGralR.Image")));
            this.btnCompGralR.Location = new System.Drawing.Point(36, 18);
            this.btnCompGralR.Name = "btnCompGralR";
            this.btnCompGralR.Size = new System.Drawing.Size(43, 45);
            this.btnCompGralR.TabIndex = 1;
            this.btnCompGralR.UseVisualStyleBackColor = true;
            this.btnCompGralR.Click += new System.EventHandler(this.btnCompGralR_Click);
            // 
            // btnFiscalGralR
            // 
            this.btnFiscalGralR.Image = ((System.Drawing.Image)(resources.GetObject("btnFiscalGralR.Image")));
            this.btnFiscalGralR.Location = new System.Drawing.Point(36, 96);
            this.btnFiscalGralR.Name = "btnFiscalGralR";
            this.btnFiscalGralR.Size = new System.Drawing.Size(43, 45);
            this.btnFiscalGralR.TabIndex = 0;
            this.btnFiscalGralR.UseVisualStyleBackColor = true;
            this.btnFiscalGralR.Click += new System.EventHandler(this.btnFiscalGralR_Click);
            // 
            // FrmConsultaCajaFecha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(297, 261);
            this.Controls.Add(this.tcCajaDiario);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmConsultaCajaFecha";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta Caja Diario";
            this.Load += new System.EventHandler(this.FrmConsultaCaja_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmConsultaCajaFecha_KeyDown);
            this.gbCaja.ResumeLayout(false);
            this.gbCaja.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.gbGeneral.ResumeLayout(false);
            this.gbGeneral.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.tcCajaDiario.ResumeLayout(false);
            this.tpConvencional.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.gbPeriodo.ResumeLayout(false);
            this.gbPeriodo.PerformLayout();
            this.tpRetroActivo.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Button btnComprobante;
        private System.Windows.Forms.Button btnNotaContable;
        private System.Windows.Forms.Button btnFiscal;
        private System.Windows.Forms.GroupBox gbCaja;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox gbGeneral;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnComprobanteGeneral;
        private System.Windows.Forms.Button btnFiscalGeneral;
        private System.Windows.Forms.TabControl tcCajaDiario;
        private System.Windows.Forms.TabPage tpConvencional;
        private System.Windows.Forms.TabPage tpRetroActivo;
        private GroupBox groupBox3;
        private Button btnComprobanteCajaR;
        private Button btnFiscalCajaR;
        private GroupBox groupBox4;
        private Button btnCompGralR;
        private Button btnFiscalGralR;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private ComboBox cbCajas;
        private GroupBox gbPeriodo;
        private Label label10;
        private Button btnFiscalGeneralMes;
        private TabPage tabPage1;
    }
}