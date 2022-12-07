namespace Aplicacion.Configuracion.Caja
{
    partial class FrmCaja
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCaja));
            this.TabConfigEstacion = new System.Windows.Forms.TabControl();
            this.PageCaja = new System.Windows.Forms.TabPage();
            this.gbCajas = new System.Windows.Forms.GroupBox();
            this.btnGuardarReqApertura = new System.Windows.Forms.Button();
            this.txtActualNoCaja = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNuevaCaja = new System.Windows.Forms.Label();
            this.txtNoCaja = new System.Windows.Forms.TextBox();
            this.llGenerarCaja = new System.Windows.Forms.LinkLabel();
            this.lblInformacion = new System.Windows.Forms.Label();
            this.lblNumero = new System.Windows.Forms.Label();
            this.cbCajas = new System.Windows.Forms.ComboBox();
            this.chkRequerirApertura = new System.Windows.Forms.CheckBox();
            this.btnGuardarCaja = new System.Windows.Forms.Button();
            this.PageTurno = new System.Windows.Forms.TabPage();
            this.gbTurnos = new System.Windows.Forms.GroupBox();
            this.lblNoTurno = new System.Windows.Forms.Label();
            this.lblTurno = new System.Windows.Forms.Label();
            this.lblInformacionUno = new System.Windows.Forms.Label();
            this.lblInformacionDos = new System.Windows.Forms.Label();
            this.lblRango = new System.Windows.Forms.Label();
            this.txtRangoUno = new System.Windows.Forms.TextBox();
            this.txtRangoDos = new System.Windows.Forms.TextBox();
            this.lblInfoRango = new System.Windows.Forms.Label();
            this.lblAsignado = new System.Windows.Forms.Label();
            this.lblRangoUno = new System.Windows.Forms.Label();
            this.lblRangoDos = new System.Windows.Forms.Label();
            this.btnGuardarTurno = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNameCaja = new System.Windows.Forms.TextBox();
            this.TabConfigEstacion.SuspendLayout();
            this.PageCaja.SuspendLayout();
            this.gbCajas.SuspendLayout();
            this.PageTurno.SuspendLayout();
            this.gbTurnos.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabConfigEstacion
            // 
            this.TabConfigEstacion.Controls.Add(this.PageCaja);
            this.TabConfigEstacion.Controls.Add(this.PageTurno);
            this.TabConfigEstacion.Location = new System.Drawing.Point(2, 2);
            this.TabConfigEstacion.Name = "TabConfigEstacion";
            this.TabConfigEstacion.SelectedIndex = 0;
            this.TabConfigEstacion.Size = new System.Drawing.Size(295, 249);
            this.TabConfigEstacion.TabIndex = 0;
            // 
            // PageCaja
            // 
            this.PageCaja.Controls.Add(this.gbCajas);
            this.PageCaja.Location = new System.Drawing.Point(4, 25);
            this.PageCaja.Name = "PageCaja";
            this.PageCaja.Padding = new System.Windows.Forms.Padding(3);
            this.PageCaja.Size = new System.Drawing.Size(287, 220);
            this.PageCaja.TabIndex = 0;
            this.PageCaja.Text = "Cajas";
            this.PageCaja.UseVisualStyleBackColor = true;
            // 
            // gbCajas
            // 
            this.gbCajas.Controls.Add(this.label2);
            this.gbCajas.Controls.Add(this.btnGuardarReqApertura);
            this.gbCajas.Controls.Add(this.txtNameCaja);
            this.gbCajas.Controls.Add(this.txtActualNoCaja);
            this.gbCajas.Controls.Add(this.label1);
            this.gbCajas.Controls.Add(this.lblNuevaCaja);
            this.gbCajas.Controls.Add(this.txtNoCaja);
            this.gbCajas.Controls.Add(this.llGenerarCaja);
            this.gbCajas.Controls.Add(this.lblInformacion);
            this.gbCajas.Controls.Add(this.lblNumero);
            this.gbCajas.Controls.Add(this.cbCajas);
            this.gbCajas.Controls.Add(this.chkRequerirApertura);
            this.gbCajas.Controls.Add(this.btnGuardarCaja);
            this.gbCajas.Location = new System.Drawing.Point(9, 6);
            this.gbCajas.Name = "gbCajas";
            this.gbCajas.Size = new System.Drawing.Size(269, 209);
            this.gbCajas.TabIndex = 27;
            this.gbCajas.TabStop = false;
            // 
            // btnGuardarReqApertura
            // 
            this.btnGuardarReqApertura.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardarReqApertura.Image")));
            this.btnGuardarReqApertura.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardarReqApertura.Location = new System.Drawing.Point(34, 46);
            this.btnGuardarReqApertura.Name = "btnGuardarReqApertura";
            this.btnGuardarReqApertura.Size = new System.Drawing.Size(14, 10);
            this.btnGuardarReqApertura.TabIndex = 29;
            this.btnGuardarReqApertura.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardarReqApertura.UseVisualStyleBackColor = true;
            this.btnGuardarReqApertura.Visible = false;
            this.btnGuardarReqApertura.Click += new System.EventHandler(this.btnGuardarReqApertura_Click);
            // 
            // txtActualNoCaja
            // 
            this.txtActualNoCaja.Location = new System.Drawing.Point(116, 87);
            this.txtActualNoCaja.Name = "txtActualNoCaja";
            this.txtActualNoCaja.ReadOnly = true;
            this.txtActualNoCaja.Size = new System.Drawing.Size(77, 22);
            this.txtActualNoCaja.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 16);
            this.label1.TabIndex = 27;
            this.label1.Text = "Asignar número";
            // 
            // lblNuevaCaja
            // 
            this.lblNuevaCaja.AutoSize = true;
            this.lblNuevaCaja.Location = new System.Drawing.Point(10, 23);
            this.lblNuevaCaja.Name = "lblNuevaCaja";
            this.lblNuevaCaja.Size = new System.Drawing.Size(79, 16);
            this.lblNuevaCaja.TabIndex = 26;
            this.lblNuevaCaja.Text = "Nueva Caja";
            // 
            // txtNoCaja
            // 
            this.txtNoCaja.Location = new System.Drawing.Point(104, 20);
            this.txtNoCaja.Name = "txtNoCaja";
            this.txtNoCaja.ReadOnly = true;
            this.txtNoCaja.Size = new System.Drawing.Size(88, 22);
            this.txtNoCaja.TabIndex = 25;
            // 
            // llGenerarCaja
            // 
            this.llGenerarCaja.AutoSize = true;
            this.llGenerarCaja.Location = new System.Drawing.Point(199, 23);
            this.llGenerarCaja.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.llGenerarCaja.Name = "llGenerarCaja";
            this.llGenerarCaja.Size = new System.Drawing.Size(57, 16);
            this.llGenerarCaja.TabIndex = 24;
            this.llGenerarCaja.TabStop = true;
            this.llGenerarCaja.Text = "Generar";
            this.llGenerarCaja.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llGenerarCaja_LinkClicked);
            // 
            // lblInformacion
            // 
            this.lblInformacion.Location = new System.Drawing.Point(11, 60);
            this.lblInformacion.Name = "lblInformacion";
            this.lblInformacion.Size = new System.Drawing.Size(175, 20);
            this.lblInformacion.TabIndex = 0;
            this.lblInformacion.Text = "Configurar de estación";
            // 
            // lblNumero
            // 
            this.lblNumero.AutoSize = true;
            this.lblNumero.Location = new System.Drawing.Point(11, 89);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(104, 16);
            this.lblNumero.TabIndex = 23;
            this.lblNumero.Text = "Número de caja";
            // 
            // cbCajas
            // 
            this.cbCajas.DisplayMember = "numerocaja";
            this.cbCajas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCajas.FormattingEnabled = true;
            this.cbCajas.Location = new System.Drawing.Point(116, 115);
            this.cbCajas.Name = "cbCajas";
            this.cbCajas.Size = new System.Drawing.Size(77, 24);
            this.cbCajas.TabIndex = 22;
            this.cbCajas.ValueMember = "idcaja";
            // 
            // chkRequerirApertura
            // 
            this.chkRequerirApertura.AutoSize = true;
            this.chkRequerirApertura.Location = new System.Drawing.Point(13, 42);
            this.chkRequerirApertura.Name = "chkRequerirApertura";
            this.chkRequerirApertura.Size = new System.Drawing.Size(15, 14);
            this.chkRequerirApertura.TabIndex = 5;
            this.chkRequerirApertura.UseVisualStyleBackColor = true;
            this.chkRequerirApertura.Visible = false;
            // 
            // btnGuardarCaja
            // 
            this.btnGuardarCaja.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardarCaja.Image")));
            this.btnGuardarCaja.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardarCaja.Location = new System.Drawing.Point(232, 175);
            this.btnGuardarCaja.Name = "btnGuardarCaja";
            this.btnGuardarCaja.Size = new System.Drawing.Size(25, 25);
            this.btnGuardarCaja.TabIndex = 4;
            this.btnGuardarCaja.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardarCaja.UseVisualStyleBackColor = true;
            this.btnGuardarCaja.Click += new System.EventHandler(this.btnGuardarCaja_Click);
            // 
            // PageTurno
            // 
            this.PageTurno.Controls.Add(this.gbTurnos);
            this.PageTurno.Location = new System.Drawing.Point(4, 25);
            this.PageTurno.Name = "PageTurno";
            this.PageTurno.Padding = new System.Windows.Forms.Padding(3);
            this.PageTurno.Size = new System.Drawing.Size(287, 204);
            this.PageTurno.TabIndex = 1;
            this.PageTurno.Text = "Turnos";
            this.PageTurno.UseVisualStyleBackColor = true;
            // 
            // gbTurnos
            // 
            this.gbTurnos.Controls.Add(this.lblNoTurno);
            this.gbTurnos.Controls.Add(this.lblTurno);
            this.gbTurnos.Controls.Add(this.lblInformacionUno);
            this.gbTurnos.Controls.Add(this.lblInformacionDos);
            this.gbTurnos.Controls.Add(this.lblRango);
            this.gbTurnos.Controls.Add(this.txtRangoUno);
            this.gbTurnos.Controls.Add(this.txtRangoDos);
            this.gbTurnos.Controls.Add(this.lblInfoRango);
            this.gbTurnos.Controls.Add(this.lblAsignado);
            this.gbTurnos.Controls.Add(this.lblRangoUno);
            this.gbTurnos.Controls.Add(this.lblRangoDos);
            this.gbTurnos.Controls.Add(this.btnGuardarTurno);
            this.gbTurnos.Location = new System.Drawing.Point(9, 3);
            this.gbTurnos.Name = "gbTurnos";
            this.gbTurnos.Size = new System.Drawing.Size(263, 193);
            this.gbTurnos.TabIndex = 0;
            this.gbTurnos.TabStop = false;
            // 
            // lblNoTurno
            // 
            this.lblNoTurno.AutoSize = true;
            this.lblNoTurno.Location = new System.Drawing.Point(132, 143);
            this.lblNoTurno.Name = "lblNoTurno";
            this.lblNoTurno.Size = new System.Drawing.Size(15, 16);
            this.lblNoTurno.TabIndex = 16;
            this.lblNoTurno.Text = "0";
            // 
            // lblTurno
            // 
            this.lblTurno.AutoSize = true;
            this.lblTurno.Location = new System.Drawing.Point(11, 143);
            this.lblTurno.Name = "lblTurno";
            this.lblTurno.Size = new System.Drawing.Size(43, 16);
            this.lblTurno.TabIndex = 15;
            this.lblTurno.Text = "Turno";
            // 
            // lblInformacionUno
            // 
            this.lblInformacionUno.AutoSize = true;
            this.lblInformacionUno.Location = new System.Drawing.Point(11, 13);
            this.lblInformacionUno.Name = "lblInformacionUno";
            this.lblInformacionUno.Size = new System.Drawing.Size(208, 16);
            this.lblInformacionUno.TabIndex = 9;
            this.lblInformacionUno.Text = "Ingrese el rango numérico para la";
            // 
            // lblInformacionDos
            // 
            this.lblInformacionDos.AutoSize = true;
            this.lblInformacionDos.Location = new System.Drawing.Point(9, 36);
            this.lblInformacionDos.Name = "lblInformacionDos";
            this.lblInformacionDos.Size = new System.Drawing.Size(138, 16);
            this.lblInformacionDos.TabIndex = 10;
            this.lblInformacionDos.Text = " asignación de turnos.";
            // 
            // lblRango
            // 
            this.lblRango.AutoSize = true;
            this.lblRango.Location = new System.Drawing.Point(11, 64);
            this.lblRango.Name = "lblRango";
            this.lblRango.Size = new System.Drawing.Size(49, 16);
            this.lblRango.TabIndex = 8;
            this.lblRango.Text = "Rango";
            // 
            // txtRangoUno
            // 
            this.txtRangoUno.Location = new System.Drawing.Point(72, 61);
            this.txtRangoUno.Name = "txtRangoUno";
            this.txtRangoUno.Size = new System.Drawing.Size(80, 22);
            this.txtRangoUno.TabIndex = 7;
            this.txtRangoUno.Validating += new System.ComponentModel.CancelEventHandler(this.txtRangoUno_Validating);
            // 
            // txtRangoDos
            // 
            this.txtRangoDos.Location = new System.Drawing.Point(162, 61);
            this.txtRangoDos.Name = "txtRangoDos";
            this.txtRangoDos.Size = new System.Drawing.Size(83, 22);
            this.txtRangoDos.TabIndex = 6;
            this.txtRangoDos.Validating += new System.ComponentModel.CancelEventHandler(this.txtRangoDos_Validating);
            // 
            // lblInfoRango
            // 
            this.lblInfoRango.AutoSize = true;
            this.lblInfoRango.Location = new System.Drawing.Point(11, 94);
            this.lblInfoRango.Name = "lblInfoRango";
            this.lblInfoRango.Size = new System.Drawing.Size(49, 16);
            this.lblInfoRango.TabIndex = 11;
            this.lblInfoRango.Text = "Rango";
            // 
            // lblAsignado
            // 
            this.lblAsignado.AutoSize = true;
            this.lblAsignado.Location = new System.Drawing.Point(11, 113);
            this.lblAsignado.Name = "lblAsignado";
            this.lblAsignado.Size = new System.Drawing.Size(65, 16);
            this.lblAsignado.TabIndex = 14;
            this.lblAsignado.Text = "asignado";
            // 
            // lblRangoUno
            // 
            this.lblRangoUno.AutoSize = true;
            this.lblRangoUno.Location = new System.Drawing.Point(132, 105);
            this.lblRangoUno.Name = "lblRangoUno";
            this.lblRangoUno.Size = new System.Drawing.Size(15, 16);
            this.lblRangoUno.TabIndex = 12;
            this.lblRangoUno.Text = "0";
            // 
            // lblRangoDos
            // 
            this.lblRangoDos.AutoSize = true;
            this.lblRangoDos.Location = new System.Drawing.Point(230, 106);
            this.lblRangoDos.Name = "lblRangoDos";
            this.lblRangoDos.Size = new System.Drawing.Size(15, 16);
            this.lblRangoDos.TabIndex = 13;
            this.lblRangoDos.Text = "0";
            // 
            // btnGuardarTurno
            // 
            this.btnGuardarTurno.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardarTurno.Image")));
            this.btnGuardarTurno.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardarTurno.Location = new System.Drawing.Point(162, 161);
            this.btnGuardarTurno.Name = "btnGuardarTurno";
            this.btnGuardarTurno.Size = new System.Drawing.Size(83, 25);
            this.btnGuardarTurno.TabIndex = 5;
            this.btnGuardarTurno.Text = "Guardar";
            this.btnGuardarTurno.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardarTurno.UseVisualStyleBackColor = true;
            this.btnGuardarTurno.Click += new System.EventHandler(this.btnGuardarTurno_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 16);
            this.label2.TabIndex = 30;
            this.label2.Text = "Nombre";
            // 
            // txtNameCaja
            // 
            this.txtNameCaja.Location = new System.Drawing.Point(116, 147);
            this.txtNameCaja.Name = "txtNameCaja";
            this.txtNameCaja.Size = new System.Drawing.Size(140, 22);
            this.txtNameCaja.TabIndex = 28;
            // 
            // FrmCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(296, 253);
            this.Controls.Add(this.TabConfigEstacion);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCaja";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuración de estación";
            this.Load += new System.EventHandler(this.FrmCaja_Load);
            this.TabConfigEstacion.ResumeLayout(false);
            this.PageCaja.ResumeLayout(false);
            this.gbCajas.ResumeLayout(false);
            this.gbCajas.PerformLayout();
            this.PageTurno.ResumeLayout(false);
            this.gbTurnos.ResumeLayout(false);
            this.gbTurnos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabConfigEstacion;
        private System.Windows.Forms.TabPage PageCaja;
        private System.Windows.Forms.TabPage PageTurno;
        private System.Windows.Forms.Button btnGuardarCaja;
        private System.Windows.Forms.CheckBox chkRequerirApertura;
        private System.Windows.Forms.ComboBox cbCajas;
        private System.Windows.Forms.Label lblNumero;
        private System.Windows.Forms.Label lblNuevaCaja;
        private System.Windows.Forms.TextBox txtNoCaja;
        private System.Windows.Forms.LinkLabel llGenerarCaja;
        private System.Windows.Forms.Label lblInformacion;
        private System.Windows.Forms.GroupBox gbCajas;
        private System.Windows.Forms.GroupBox gbTurnos;
        private System.Windows.Forms.Button btnGuardarTurno;
        private System.Windows.Forms.Label lblRango;
        private System.Windows.Forms.TextBox txtRangoUno;
        private System.Windows.Forms.TextBox txtRangoDos;
        private System.Windows.Forms.Label lblInformacionDos;
        private System.Windows.Forms.Label lblInformacionUno;
        private System.Windows.Forms.Label lblRangoDos;
        private System.Windows.Forms.Label lblRangoUno;
        private System.Windows.Forms.Label lblInfoRango;
        private System.Windows.Forms.Label lblAsignado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtActualNoCaja;
        private System.Windows.Forms.Button btnGuardarReqApertura;
        private System.Windows.Forms.Label lblNoTurno;
        private System.Windows.Forms.Label lblTurno;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNameCaja;
    }
}