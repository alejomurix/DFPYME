namespace Aplicacion.Configuracion.PrecioVenta
{
    partial class FrmPrecioVenta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrecioVenta));
            this.gbPrecioVenta = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rbtnAsignado = new System.Windows.Forms.RadioButton();
            this.rbtnPromedio = new System.Windows.Forms.RadioButton();
            this.txtNumPromedio = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gbConfAproximacion = new System.Windows.Forms.GroupBox();
            this.rbtnDecena = new System.Windows.Forms.RadioButton();
            this.rbtnCentena = new System.Windows.Forms.RadioButton();
            this.txtValorAprox = new System.Windows.Forms.TextBox();
            this.btnInfoAprox = new System.Windows.Forms.Button();
            this.gbUtilidadProducto = new System.Windows.Forms.GroupBox();
            this.PanelInfo = new System.Windows.Forms.Panel();
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.lblBase = new System.Windows.Forms.Label();
            this.lblUtilidad = new System.Windows.Forms.Label();
            this.txtCosto = new System.Windows.Forms.TextBox();
            this.txtUtilidad = new System.Windows.Forms.TextBox();
            this.lblPorcentaje = new System.Windows.Forms.Label();
            this.rbtnPorUtilidad = new System.Windows.Forms.RadioButton();
            this.PanelCostoPor = new System.Windows.Forms.Panel();
            this.lblCostoPor = new System.Windows.Forms.Label();
            this.PanelUtilPor = new System.Windows.Forms.Panel();
            this.lblUtilPor = new System.Windows.Forms.Label();
            this.PanelValorPor = new System.Windows.Forms.Panel();
            this.lblValorPor = new System.Windows.Forms.Label();
            this.txtCostoPor = new System.Windows.Forms.TextBox();
            this.txtUtilPor = new System.Windows.Forms.TextBox();
            this.txtValorPor = new System.Windows.Forms.TextBox();
            this.btnInfoPor = new System.Windows.Forms.Button();
            this.rbtnSobreUtilidad = new System.Windows.Forms.RadioButton();
            this.PanelCostoSobre = new System.Windows.Forms.Panel();
            this.lblCostoSobre = new System.Windows.Forms.Label();
            this.PanelUtilSobre = new System.Windows.Forms.Panel();
            this.lblUtilidadSobre = new System.Windows.Forms.Label();
            this.PanelValorSobre = new System.Windows.Forms.Panel();
            this.lblValorSobre = new System.Windows.Forms.Label();
            this.txtCostoSobre = new System.Windows.Forms.TextBox();
            this.txtUtilSobre = new System.Windows.Forms.TextBox();
            this.txtValorSobre = new System.Windows.Forms.TextBox();
            this.btnInfoSobre = new System.Windows.Forms.Button();
            this.gbIva = new System.Windows.Forms.GroupBox();
            this.rbtnIncluye = new System.Windows.Forms.RadioButton();
            this.rbtnNoIncluye = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkPreguntarUtil = new System.Windows.Forms.CheckBox();
            this.chkPreguntaPrecioVenta = new System.Windows.Forms.CheckBox();
            this.gbUtilidadIva = new System.Windows.Forms.GroupBox();
            this.rbtnAntesIva = new System.Windows.Forms.RadioButton();
            this.rbtnDespuesIva = new System.Windows.Forms.RadioButton();
            this.gbCosto = new System.Windows.Forms.GroupBox();
            this.rbtnCostoIva = new System.Windows.Forms.RadioButton();
            this.rbtnCostoNoIva = new System.Windows.Forms.RadioButton();
            this.gbPrecioVenta.SuspendLayout();
            this.gbConfAproximacion.SuspendLayout();
            this.gbUtilidadProducto.SuspendLayout();
            this.PanelInfo.SuspendLayout();
            this.PanelCostoPor.SuspendLayout();
            this.PanelUtilPor.SuspendLayout();
            this.PanelValorPor.SuspendLayout();
            this.PanelCostoSobre.SuspendLayout();
            this.PanelUtilSobre.SuspendLayout();
            this.PanelValorSobre.SuspendLayout();
            this.gbIva.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbUtilidadIva.SuspendLayout();
            this.gbCosto.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbPrecioVenta
            // 
            this.gbPrecioVenta.Controls.Add(this.label1);
            this.gbPrecioVenta.Controls.Add(this.rbtnAsignado);
            this.gbPrecioVenta.Controls.Add(this.rbtnPromedio);
            this.gbPrecioVenta.Controls.Add(this.txtNumPromedio);
            this.gbPrecioVenta.Location = new System.Drawing.Point(9, 8);
            this.gbPrecioVenta.Name = "gbPrecioVenta";
            this.gbPrecioVenta.Size = new System.Drawing.Size(372, 89);
            this.gbPrecioVenta.TabIndex = 0;
            this.gbPrecioVenta.TabStop = false;
            this.gbPrecioVenta.Text = "Configurar precio de venta";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(252, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Últimos registros de compra a promediar";
            // 
            // rbtnAsignado
            // 
            this.rbtnAsignado.AutoSize = true;
            this.rbtnAsignado.Checked = true;
            this.rbtnAsignado.Enabled = false;
            this.rbtnAsignado.Location = new System.Drawing.Point(7, 22);
            this.rbtnAsignado.Name = "rbtnAsignado";
            this.rbtnAsignado.Size = new System.Drawing.Size(126, 20);
            this.rbtnAsignado.TabIndex = 0;
            this.rbtnAsignado.TabStop = true;
            this.rbtnAsignado.Text = "Precio Asignado";
            this.rbtnAsignado.UseVisualStyleBackColor = true;
            this.rbtnAsignado.Click += new System.EventHandler(this.rbtnAsignado_Click);
            // 
            // rbtnPromedio
            // 
            this.rbtnPromedio.AutoSize = true;
            this.rbtnPromedio.Enabled = false;
            this.rbtnPromedio.Location = new System.Drawing.Point(149, 22);
            this.rbtnPromedio.Name = "rbtnPromedio";
            this.rbtnPromedio.Size = new System.Drawing.Size(150, 20);
            this.rbtnPromedio.TabIndex = 1;
            this.rbtnPromedio.Text = "Precio por Promedio";
            this.rbtnPromedio.UseVisualStyleBackColor = true;
            this.rbtnPromedio.Click += new System.EventHandler(this.rbtnPromedio_Click);
            // 
            // txtNumPromedio
            // 
            this.txtNumPromedio.Location = new System.Drawing.Point(291, 51);
            this.txtNumPromedio.Name = "txtNumPromedio";
            this.txtNumPromedio.Size = new System.Drawing.Size(65, 22);
            this.txtNumPromedio.TabIndex = 2;
            this.txtNumPromedio.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNumPromedio_KeyUp);
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnOk.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.Image")));
            this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOk.Location = new System.Drawing.Point(575, 359);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(83, 25);
            this.btnOk.TabIndex = 3;
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
            this.btnCancel.Location = new System.Drawing.Point(675, 359);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 25);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // gbConfAproximacion
            // 
            this.gbConfAproximacion.Controls.Add(this.rbtnDecena);
            this.gbConfAproximacion.Controls.Add(this.rbtnCentena);
            this.gbConfAproximacion.Controls.Add(this.txtValorAprox);
            this.gbConfAproximacion.Controls.Add(this.btnInfoAprox);
            this.gbConfAproximacion.Location = new System.Drawing.Point(9, 183);
            this.gbConfAproximacion.Name = "gbConfAproximacion";
            this.gbConfAproximacion.Size = new System.Drawing.Size(372, 64);
            this.gbConfAproximacion.TabIndex = 1;
            this.gbConfAproximacion.TabStop = false;
            this.gbConfAproximacion.Text = "Configurar modo de aproximar";
            // 
            // rbtnDecena
            // 
            this.rbtnDecena.AutoSize = true;
            this.rbtnDecena.Checked = true;
            this.rbtnDecena.Location = new System.Drawing.Point(11, 26);
            this.rbtnDecena.Name = "rbtnDecena";
            this.rbtnDecena.Size = new System.Drawing.Size(115, 20);
            this.rbtnDecena.TabIndex = 0;
            this.rbtnDecena.TabStop = true;
            this.rbtnDecena.Text = "Aprox. Decena";
            this.rbtnDecena.UseVisualStyleBackColor = true;
            this.rbtnDecena.Click += new System.EventHandler(this.rbtnDecena_Click);
            // 
            // rbtnCentena
            // 
            this.rbtnCentena.AutoSize = true;
            this.rbtnCentena.Location = new System.Drawing.Point(147, 26);
            this.rbtnCentena.Name = "rbtnCentena";
            this.rbtnCentena.Size = new System.Drawing.Size(117, 20);
            this.rbtnCentena.TabIndex = 1;
            this.rbtnCentena.Text = "Aprox. Centena";
            this.rbtnCentena.UseVisualStyleBackColor = true;
            this.rbtnCentena.Click += new System.EventHandler(this.rbtnCentena_Click);
            // 
            // txtValorAprox
            // 
            this.txtValorAprox.Location = new System.Drawing.Point(273, 24);
            this.txtValorAprox.Name = "txtValorAprox";
            this.txtValorAprox.Size = new System.Drawing.Size(56, 22);
            this.txtValorAprox.TabIndex = 2;
            this.txtValorAprox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtValorAprox_KeyUp);
            // 
            // btnInfoAprox
            // 
            this.btnInfoAprox.FlatAppearance.BorderSize = 0;
            this.btnInfoAprox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInfoAprox.Image = ((System.Drawing.Image)(resources.GetObject("btnInfoAprox.Image")));
            this.btnInfoAprox.Location = new System.Drawing.Point(333, 24);
            this.btnInfoAprox.Name = "btnInfoAprox";
            this.btnInfoAprox.Size = new System.Drawing.Size(25, 23);
            this.btnInfoAprox.TabIndex = 3;
            this.btnInfoAprox.UseVisualStyleBackColor = true;
            // 
            // gbUtilidadProducto
            // 
            this.gbUtilidadProducto.Controls.Add(this.PanelInfo);
            this.gbUtilidadProducto.Controls.Add(this.lblBase);
            this.gbUtilidadProducto.Controls.Add(this.lblUtilidad);
            this.gbUtilidadProducto.Controls.Add(this.txtCosto);
            this.gbUtilidadProducto.Controls.Add(this.txtUtilidad);
            this.gbUtilidadProducto.Controls.Add(this.lblPorcentaje);
            this.gbUtilidadProducto.Controls.Add(this.rbtnPorUtilidad);
            this.gbUtilidadProducto.Controls.Add(this.PanelCostoPor);
            this.gbUtilidadProducto.Controls.Add(this.PanelUtilPor);
            this.gbUtilidadProducto.Controls.Add(this.PanelValorPor);
            this.gbUtilidadProducto.Controls.Add(this.txtCostoPor);
            this.gbUtilidadProducto.Controls.Add(this.txtUtilPor);
            this.gbUtilidadProducto.Controls.Add(this.txtValorPor);
            this.gbUtilidadProducto.Controls.Add(this.btnInfoPor);
            this.gbUtilidadProducto.Controls.Add(this.rbtnSobreUtilidad);
            this.gbUtilidadProducto.Controls.Add(this.PanelCostoSobre);
            this.gbUtilidadProducto.Controls.Add(this.PanelUtilSobre);
            this.gbUtilidadProducto.Controls.Add(this.PanelValorSobre);
            this.gbUtilidadProducto.Controls.Add(this.txtCostoSobre);
            this.gbUtilidadProducto.Controls.Add(this.txtUtilSobre);
            this.gbUtilidadProducto.Controls.Add(this.txtValorSobre);
            this.gbUtilidadProducto.Controls.Add(this.btnInfoSobre);
            this.gbUtilidadProducto.Location = new System.Drawing.Point(394, 8);
            this.gbUtilidadProducto.Name = "gbUtilidadProducto";
            this.gbUtilidadProducto.Size = new System.Drawing.Size(368, 269);
            this.gbUtilidadProducto.TabIndex = 2;
            this.gbUtilidadProducto.TabStop = false;
            this.gbUtilidadProducto.Text = "Configurar Utilidad de producto";
            // 
            // PanelInfo
            // 
            this.PanelInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelInfo.Controls.Add(this.txtInfo);
            this.PanelInfo.Location = new System.Drawing.Point(144, 16);
            this.PanelInfo.Name = "PanelInfo";
            this.PanelInfo.Size = new System.Drawing.Size(214, 95);
            this.PanelInfo.TabIndex = 42;
            this.PanelInfo.Visible = false;
            // 
            // txtInfo
            // 
            this.txtInfo.Location = new System.Drawing.Point(3, 2);
            this.txtInfo.Multiline = true;
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.Size = new System.Drawing.Size(208, 90);
            this.txtInfo.TabIndex = 0;
            // 
            // lblBase
            // 
            this.lblBase.AutoSize = true;
            this.lblBase.Location = new System.Drawing.Point(22, 29);
            this.lblBase.Name = "lblBase";
            this.lblBase.Size = new System.Drawing.Size(118, 16);
            this.lblBase.TabIndex = 11;
            this.lblBase.Text = "Costo de producto";
            // 
            // lblUtilidad
            // 
            this.lblUtilidad.AutoSize = true;
            this.lblUtilidad.Location = new System.Drawing.Point(165, 29);
            this.lblUtilidad.Name = "lblUtilidad";
            this.lblUtilidad.Size = new System.Drawing.Size(54, 16);
            this.lblUtilidad.TabIndex = 13;
            this.lblUtilidad.Text = "Utilidad";
            // 
            // txtCosto
            // 
            this.txtCosto.Location = new System.Drawing.Point(24, 51);
            this.txtCosto.MaxLength = 7;
            this.txtCosto.Name = "txtCosto";
            this.txtCosto.Size = new System.Drawing.Size(116, 22);
            this.txtCosto.TabIndex = 0;
            this.txtCosto.Text = "1000";
            this.txtCosto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCosto.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCosto_KeyUp);
            // 
            // txtUtilidad
            // 
            this.txtUtilidad.Location = new System.Drawing.Point(167, 51);
            this.txtUtilidad.MaxLength = 4;
            this.txtUtilidad.Name = "txtUtilidad";
            this.txtUtilidad.Size = new System.Drawing.Size(52, 22);
            this.txtUtilidad.TabIndex = 1;
            this.txtUtilidad.Text = "10";
            this.txtUtilidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtUtilidad.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtUtilidad_KeyUp);
            // 
            // lblPorcentaje
            // 
            this.lblPorcentaje.AutoSize = true;
            this.lblPorcentaje.Location = new System.Drawing.Point(222, 54);
            this.lblPorcentaje.Name = "lblPorcentaje";
            this.lblPorcentaje.Size = new System.Drawing.Size(20, 16);
            this.lblPorcentaje.TabIndex = 15;
            this.lblPorcentaje.Text = "%";
            // 
            // rbtnPorUtilidad
            // 
            this.rbtnPorUtilidad.AutoSize = true;
            this.rbtnPorUtilidad.Checked = true;
            this.rbtnPorUtilidad.Location = new System.Drawing.Point(24, 90);
            this.rbtnPorUtilidad.Name = "rbtnPorUtilidad";
            this.rbtnPorUtilidad.Size = new System.Drawing.Size(127, 20);
            this.rbtnPorUtilidad.TabIndex = 17;
            this.rbtnPorUtilidad.TabStop = true;
            this.rbtnPorUtilidad.Text = "Valor por utilidad";
            this.rbtnPorUtilidad.UseVisualStyleBackColor = true;
            // 
            // PanelCostoPor
            // 
            this.PanelCostoPor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelCostoPor.Controls.Add(this.lblCostoPor);
            this.PanelCostoPor.Location = new System.Drawing.Point(24, 117);
            this.PanelCostoPor.Name = "PanelCostoPor";
            this.PanelCostoPor.Size = new System.Drawing.Size(73, 25);
            this.PanelCostoPor.TabIndex = 1;
            // 
            // lblCostoPor
            // 
            this.lblCostoPor.AutoSize = true;
            this.lblCostoPor.Location = new System.Drawing.Point(3, 4);
            this.lblCostoPor.Name = "lblCostoPor";
            this.lblCostoPor.Size = new System.Drawing.Size(43, 16);
            this.lblCostoPor.TabIndex = 0;
            this.lblCostoPor.Text = "Costo";
            // 
            // PanelUtilPor
            // 
            this.PanelUtilPor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelUtilPor.Controls.Add(this.lblUtilPor);
            this.PanelUtilPor.Location = new System.Drawing.Point(96, 117);
            this.PanelUtilPor.Name = "PanelUtilPor";
            this.PanelUtilPor.Size = new System.Drawing.Size(73, 25);
            this.PanelUtilPor.TabIndex = 0;
            // 
            // lblUtilPor
            // 
            this.lblUtilPor.AutoSize = true;
            this.lblUtilPor.Location = new System.Drawing.Point(3, 4);
            this.lblUtilPor.Name = "lblUtilPor";
            this.lblUtilPor.Size = new System.Drawing.Size(54, 16);
            this.lblUtilPor.TabIndex = 0;
            this.lblUtilPor.Text = "Utilidad";
            // 
            // PanelValorPor
            // 
            this.PanelValorPor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelValorPor.Controls.Add(this.lblValorPor);
            this.PanelValorPor.Location = new System.Drawing.Point(167, 117);
            this.PanelValorPor.Name = "PanelValorPor";
            this.PanelValorPor.Size = new System.Drawing.Size(73, 25);
            this.PanelValorPor.TabIndex = 1;
            // 
            // lblValorPor
            // 
            this.lblValorPor.AutoSize = true;
            this.lblValorPor.Location = new System.Drawing.Point(3, 4);
            this.lblValorPor.Name = "lblValorPor";
            this.lblValorPor.Size = new System.Drawing.Size(40, 16);
            this.lblValorPor.TabIndex = 0;
            this.lblValorPor.Text = "Valor";
            // 
            // txtCostoPor
            // 
            this.txtCostoPor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCostoPor.Enabled = false;
            this.txtCostoPor.Location = new System.Drawing.Point(24, 141);
            this.txtCostoPor.Name = "txtCostoPor";
            this.txtCostoPor.Size = new System.Drawing.Size(73, 22);
            this.txtCostoPor.TabIndex = 36;
            this.txtCostoPor.Text = "0";
            this.txtCostoPor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtUtilPor
            // 
            this.txtUtilPor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUtilPor.Enabled = false;
            this.txtUtilPor.Location = new System.Drawing.Point(96, 141);
            this.txtUtilPor.Name = "txtUtilPor";
            this.txtUtilPor.Size = new System.Drawing.Size(73, 22);
            this.txtUtilPor.TabIndex = 37;
            this.txtUtilPor.Text = "0";
            this.txtUtilPor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtValorPor
            // 
            this.txtValorPor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtValorPor.Enabled = false;
            this.txtValorPor.Location = new System.Drawing.Point(167, 141);
            this.txtValorPor.Name = "txtValorPor";
            this.txtValorPor.Size = new System.Drawing.Size(73, 22);
            this.txtValorPor.TabIndex = 38;
            this.txtValorPor.Text = "0";
            this.txtValorPor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnInfoPor
            // 
            this.btnInfoPor.FlatAppearance.BorderSize = 0;
            this.btnInfoPor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInfoPor.Image = ((System.Drawing.Image)(resources.GetObject("btnInfoPor.Image")));
            this.btnInfoPor.Location = new System.Drawing.Point(250, 119);
            this.btnInfoPor.Name = "btnInfoPor";
            this.btnInfoPor.Size = new System.Drawing.Size(25, 23);
            this.btnInfoPor.TabIndex = 2;
            this.btnInfoPor.UseVisualStyleBackColor = true;
            this.btnInfoPor.MouseLeave += new System.EventHandler(this.btnInfoPor_MouseLeave);
            this.btnInfoPor.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnInfoPor_MouseMove);
            // 
            // rbtnSobreUtilidad
            // 
            this.rbtnSobreUtilidad.AutoSize = true;
            this.rbtnSobreUtilidad.Location = new System.Drawing.Point(24, 186);
            this.rbtnSobreUtilidad.Name = "rbtnSobreUtilidad";
            this.rbtnSobreUtilidad.Size = new System.Drawing.Size(142, 20);
            this.rbtnSobreUtilidad.TabIndex = 16;
            this.rbtnSobreUtilidad.Text = "Valor sobre utilidad";
            this.rbtnSobreUtilidad.UseVisualStyleBackColor = true;
            // 
            // PanelCostoSobre
            // 
            this.PanelCostoSobre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelCostoSobre.Controls.Add(this.lblCostoSobre);
            this.PanelCostoSobre.Location = new System.Drawing.Point(24, 214);
            this.PanelCostoSobre.Name = "PanelCostoSobre";
            this.PanelCostoSobre.Size = new System.Drawing.Size(73, 25);
            this.PanelCostoSobre.TabIndex = 6;
            // 
            // lblCostoSobre
            // 
            this.lblCostoSobre.AutoSize = true;
            this.lblCostoSobre.Location = new System.Drawing.Point(3, 4);
            this.lblCostoSobre.Name = "lblCostoSobre";
            this.lblCostoSobre.Size = new System.Drawing.Size(43, 16);
            this.lblCostoSobre.TabIndex = 0;
            this.lblCostoSobre.Text = "Costo";
            // 
            // PanelUtilSobre
            // 
            this.PanelUtilSobre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelUtilSobre.Controls.Add(this.lblUtilidadSobre);
            this.PanelUtilSobre.Location = new System.Drawing.Point(96, 214);
            this.PanelUtilSobre.Name = "PanelUtilSobre";
            this.PanelUtilSobre.Size = new System.Drawing.Size(73, 25);
            this.PanelUtilSobre.TabIndex = 5;
            // 
            // lblUtilidadSobre
            // 
            this.lblUtilidadSobre.AutoSize = true;
            this.lblUtilidadSobre.Location = new System.Drawing.Point(3, 4);
            this.lblUtilidadSobre.Name = "lblUtilidadSobre";
            this.lblUtilidadSobre.Size = new System.Drawing.Size(54, 16);
            this.lblUtilidadSobre.TabIndex = 0;
            this.lblUtilidadSobre.Text = "Utilidad";
            // 
            // PanelValorSobre
            // 
            this.PanelValorSobre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelValorSobre.Controls.Add(this.lblValorSobre);
            this.PanelValorSobre.Location = new System.Drawing.Point(167, 214);
            this.PanelValorSobre.Name = "PanelValorSobre";
            this.PanelValorSobre.Size = new System.Drawing.Size(73, 25);
            this.PanelValorSobre.TabIndex = 7;
            // 
            // lblValorSobre
            // 
            this.lblValorSobre.AutoSize = true;
            this.lblValorSobre.Location = new System.Drawing.Point(3, 4);
            this.lblValorSobre.Name = "lblValorSobre";
            this.lblValorSobre.Size = new System.Drawing.Size(40, 16);
            this.lblValorSobre.TabIndex = 0;
            this.lblValorSobre.Text = "Valor";
            // 
            // txtCostoSobre
            // 
            this.txtCostoSobre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCostoSobre.Enabled = false;
            this.txtCostoSobre.Location = new System.Drawing.Point(24, 238);
            this.txtCostoSobre.Name = "txtCostoSobre";
            this.txtCostoSobre.Size = new System.Drawing.Size(73, 22);
            this.txtCostoSobre.TabIndex = 39;
            this.txtCostoSobre.Text = "0";
            this.txtCostoSobre.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtUtilSobre
            // 
            this.txtUtilSobre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUtilSobre.Enabled = false;
            this.txtUtilSobre.Location = new System.Drawing.Point(96, 238);
            this.txtUtilSobre.Name = "txtUtilSobre";
            this.txtUtilSobre.Size = new System.Drawing.Size(73, 22);
            this.txtUtilSobre.TabIndex = 40;
            this.txtUtilSobre.Text = "0";
            this.txtUtilSobre.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtValorSobre
            // 
            this.txtValorSobre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtValorSobre.Enabled = false;
            this.txtValorSobre.Location = new System.Drawing.Point(167, 238);
            this.txtValorSobre.Name = "txtValorSobre";
            this.txtValorSobre.Size = new System.Drawing.Size(73, 22);
            this.txtValorSobre.TabIndex = 41;
            this.txtValorSobre.Text = "0";
            this.txtValorSobre.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnInfoSobre
            // 
            this.btnInfoSobre.FlatAppearance.BorderSize = 0;
            this.btnInfoSobre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInfoSobre.Image = ((System.Drawing.Image)(resources.GetObject("btnInfoSobre.Image")));
            this.btnInfoSobre.Location = new System.Drawing.Point(250, 216);
            this.btnInfoSobre.Name = "btnInfoSobre";
            this.btnInfoSobre.Size = new System.Drawing.Size(25, 23);
            this.btnInfoSobre.TabIndex = 3;
            this.btnInfoSobre.UseVisualStyleBackColor = true;
            this.btnInfoSobre.MouseLeave += new System.EventHandler(this.btnInfoSobre_MouseLeave);
            this.btnInfoSobre.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnInfoSobre_MouseMove);
            // 
            // gbIva
            // 
            this.gbIva.Controls.Add(this.rbtnIncluye);
            this.gbIva.Controls.Add(this.rbtnNoIncluye);
            this.gbIva.Enabled = false;
            this.gbIva.Location = new System.Drawing.Point(9, 107);
            this.gbIva.Name = "gbIva";
            this.gbIva.Size = new System.Drawing.Size(372, 58);
            this.gbIva.TabIndex = 5;
            this.gbIva.TabStop = false;
            this.gbIva.Text = "IVA en precio de venta";
            // 
            // rbtnIncluye
            // 
            this.rbtnIncluye.AutoSize = true;
            this.rbtnIncluye.Checked = true;
            this.rbtnIncluye.Location = new System.Drawing.Point(11, 22);
            this.rbtnIncluye.Name = "rbtnIncluye";
            this.rbtnIncluye.Size = new System.Drawing.Size(92, 20);
            this.rbtnIncluye.TabIndex = 0;
            this.rbtnIncluye.TabStop = true;
            this.rbtnIncluye.Text = "Inclyue IVA";
            this.rbtnIncluye.UseVisualStyleBackColor = true;
            // 
            // rbtnNoIncluye
            // 
            this.rbtnNoIncluye.AutoSize = true;
            this.rbtnNoIncluye.Location = new System.Drawing.Point(142, 22);
            this.rbtnNoIncluye.Name = "rbtnNoIncluye";
            this.rbtnNoIncluye.Size = new System.Drawing.Size(113, 20);
            this.rbtnNoIncluye.TabIndex = 1;
            this.rbtnNoIncluye.Text = "No incluye IVA";
            this.rbtnNoIncluye.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkPreguntarUtil);
            this.groupBox1.Controls.Add(this.chkPreguntaPrecioVenta);
            this.groupBox1.Location = new System.Drawing.Point(394, 276);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(369, 74);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // chkPreguntarUtil
            // 
            this.chkPreguntarUtil.AutoSize = true;
            this.chkPreguntarUtil.Location = new System.Drawing.Point(11, 22);
            this.chkPreguntarUtil.Name = "chkPreguntarUtil";
            this.chkPreguntarUtil.Size = new System.Drawing.Size(196, 20);
            this.chkPreguntarUtil.TabIndex = 0;
            this.chkPreguntarUtil.Text = "Preguntar si actulizar utilidad";
            this.chkPreguntarUtil.UseVisualStyleBackColor = true;
            // 
            // chkPreguntaPrecioVenta
            // 
            this.chkPreguntaPrecioVenta.AutoSize = true;
            this.chkPreguntaPrecioVenta.Location = new System.Drawing.Point(10, 48);
            this.chkPreguntaPrecioVenta.Name = "chkPreguntaPrecioVenta";
            this.chkPreguntaPrecioVenta.Size = new System.Drawing.Size(254, 20);
            this.chkPreguntaPrecioVenta.TabIndex = 1;
            this.chkPreguntaPrecioVenta.Text = "Preguntar si actualizar precio de venta";
            this.chkPreguntaPrecioVenta.UseVisualStyleBackColor = true;
            // 
            // gbUtilidadIva
            // 
            this.gbUtilidadIva.Controls.Add(this.rbtnAntesIva);
            this.gbUtilidadIva.Controls.Add(this.rbtnDespuesIva);
            this.gbUtilidadIva.Location = new System.Drawing.Point(200, 274);
            this.gbUtilidadIva.Name = "gbUtilidadIva";
            this.gbUtilidadIva.Size = new System.Drawing.Size(181, 76);
            this.gbUtilidadIva.TabIndex = 7;
            this.gbUtilidadIva.TabStop = false;
            this.gbUtilidadIva.Text = "Calculo de utilidad";
            // 
            // rbtnAntesIva
            // 
            this.rbtnAntesIva.AutoSize = true;
            this.rbtnAntesIva.Checked = true;
            this.rbtnAntesIva.Location = new System.Drawing.Point(7, 21);
            this.rbtnAntesIva.Name = "rbtnAntesIva";
            this.rbtnAntesIva.Size = new System.Drawing.Size(151, 20);
            this.rbtnAntesIva.TabIndex = 2;
            this.rbtnAntesIva.TabStop = true;
            this.rbtnAntesIva.Text = "Utilidad antes de IVA";
            this.rbtnAntesIva.UseVisualStyleBackColor = true;
            // 
            // rbtnDespuesIva
            // 
            this.rbtnDespuesIva.AutoSize = true;
            this.rbtnDespuesIva.Location = new System.Drawing.Point(7, 45);
            this.rbtnDespuesIva.Name = "rbtnDespuesIva";
            this.rbtnDespuesIva.Size = new System.Drawing.Size(171, 20);
            this.rbtnDespuesIva.TabIndex = 3;
            this.rbtnDespuesIva.Text = "Utilidad después de IVA";
            this.rbtnDespuesIva.UseVisualStyleBackColor = true;
            // 
            // gbCosto
            // 
            this.gbCosto.Controls.Add(this.rbtnCostoIva);
            this.gbCosto.Controls.Add(this.rbtnCostoNoIva);
            this.gbCosto.Location = new System.Drawing.Point(9, 270);
            this.gbCosto.Name = "gbCosto";
            this.gbCosto.Size = new System.Drawing.Size(181, 80);
            this.gbCosto.TabIndex = 8;
            this.gbCosto.TabStop = false;
            this.gbCosto.Text = "Costo";
            // 
            // rbtnCostoIva
            // 
            this.rbtnCostoIva.AutoSize = true;
            this.rbtnCostoIva.Checked = true;
            this.rbtnCostoIva.Location = new System.Drawing.Point(7, 22);
            this.rbtnCostoIva.Name = "rbtnCostoIva";
            this.rbtnCostoIva.Size = new System.Drawing.Size(92, 20);
            this.rbtnCostoIva.TabIndex = 2;
            this.rbtnCostoIva.TabStop = true;
            this.rbtnCostoIva.Text = "Incluye IVA";
            this.rbtnCostoIva.UseVisualStyleBackColor = true;
            // 
            // rbtnCostoNoIva
            // 
            this.rbtnCostoNoIva.AutoSize = true;
            this.rbtnCostoNoIva.Location = new System.Drawing.Point(7, 47);
            this.rbtnCostoNoIva.Name = "rbtnCostoNoIva";
            this.rbtnCostoNoIva.Size = new System.Drawing.Size(113, 20);
            this.rbtnCostoNoIva.TabIndex = 3;
            this.rbtnCostoNoIva.Text = "No Incluye IVA";
            this.rbtnCostoNoIva.UseVisualStyleBackColor = true;
            // 
            // FrmPrecioVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(776, 399);
            this.Controls.Add(this.gbCosto);
            this.Controls.Add(this.gbUtilidadIva);
            this.Controls.Add(this.gbPrecioVenta);
            this.Controls.Add(this.gbIva);
            this.Controls.Add(this.gbConfAproximacion);
            this.Controls.Add(this.gbUtilidadProducto);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPrecioVenta";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Utilidad y precio";
            this.Load += new System.EventHandler(this.FrmPrecioVenta_Load);
            this.gbPrecioVenta.ResumeLayout(false);
            this.gbPrecioVenta.PerformLayout();
            this.gbConfAproximacion.ResumeLayout(false);
            this.gbConfAproximacion.PerformLayout();
            this.gbUtilidadProducto.ResumeLayout(false);
            this.gbUtilidadProducto.PerformLayout();
            this.PanelInfo.ResumeLayout(false);
            this.PanelInfo.PerformLayout();
            this.PanelCostoPor.ResumeLayout(false);
            this.PanelCostoPor.PerformLayout();
            this.PanelUtilPor.ResumeLayout(false);
            this.PanelUtilPor.PerformLayout();
            this.PanelValorPor.ResumeLayout(false);
            this.PanelValorPor.PerformLayout();
            this.PanelCostoSobre.ResumeLayout(false);
            this.PanelCostoSobre.PerformLayout();
            this.PanelUtilSobre.ResumeLayout(false);
            this.PanelUtilSobre.PerformLayout();
            this.PanelValorSobre.ResumeLayout(false);
            this.PanelValorSobre.PerformLayout();
            this.gbIva.ResumeLayout(false);
            this.gbIva.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbUtilidadIva.ResumeLayout(false);
            this.gbUtilidadIva.PerformLayout();
            this.gbCosto.ResumeLayout(false);
            this.gbCosto.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbPrecioVenta;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.RadioButton rbtnAsignado;
        private System.Windows.Forms.RadioButton rbtnPromedio;
        private System.Windows.Forms.TextBox txtNumPromedio;
        private System.Windows.Forms.GroupBox gbConfAproximacion;
        private System.Windows.Forms.RadioButton rbtnDecena;
        private System.Windows.Forms.RadioButton rbtnCentena;
        private System.Windows.Forms.TextBox txtValorAprox;
        private System.Windows.Forms.Button btnInfoAprox;
        private System.Windows.Forms.GroupBox gbUtilidadProducto;
        private System.Windows.Forms.Panel PanelUtilPor;
        private System.Windows.Forms.Label lblUtilPor;
        private System.Windows.Forms.Panel PanelCostoPor;
        private System.Windows.Forms.Label lblCostoPor;
        private System.Windows.Forms.Panel PanelValorPor;
        private System.Windows.Forms.Label lblValorPor;
        private System.Windows.Forms.Panel PanelCostoSobre;
        private System.Windows.Forms.Label lblCostoSobre;
        private System.Windows.Forms.Panel PanelValorSobre;
        private System.Windows.Forms.Label lblValorSobre;
        private System.Windows.Forms.Panel PanelUtilSobre;
        private System.Windows.Forms.Label lblUtilidadSobre;
        private System.Windows.Forms.Label lblBase;
        private System.Windows.Forms.TextBox txtCosto;
        private System.Windows.Forms.TextBox txtUtilidad;
        private System.Windows.Forms.Label lblUtilidad;
        private System.Windows.Forms.Label lblPorcentaje;
        private System.Windows.Forms.RadioButton rbtnPorUtilidad;
        private System.Windows.Forms.RadioButton rbtnSobreUtilidad;
        private System.Windows.Forms.Button btnInfoSobre;
        private System.Windows.Forms.Button btnInfoPor;
        private System.Windows.Forms.TextBox txtCostoPor;
        private System.Windows.Forms.TextBox txtValorPor;
        private System.Windows.Forms.TextBox txtUtilPor;
        private System.Windows.Forms.TextBox txtValorSobre;
        private System.Windows.Forms.TextBox txtUtilSobre;
        private System.Windows.Forms.TextBox txtCostoSobre;
        private System.Windows.Forms.Panel PanelInfo;
        private System.Windows.Forms.TextBox txtInfo;
        private System.Windows.Forms.GroupBox gbIva;
        private System.Windows.Forms.RadioButton rbtnIncluye;
        private System.Windows.Forms.RadioButton rbtnNoIncluye;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkPreguntaPrecioVenta;
        private System.Windows.Forms.CheckBox chkPreguntarUtil;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbUtilidadIva;
        private System.Windows.Forms.RadioButton rbtnAntesIva;
        private System.Windows.Forms.RadioButton rbtnDespuesIva;
        private System.Windows.Forms.GroupBox gbCosto;
        private System.Windows.Forms.RadioButton rbtnCostoIva;
        private System.Windows.Forms.RadioButton rbtnCostoNoIva;
    }
}