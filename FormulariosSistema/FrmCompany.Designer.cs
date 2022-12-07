namespace FormulariosSistema
{
    partial class FrmCompany
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCompany));
            this.lblNit = new System.Windows.Forms.Label();
            this.txtNit = new System.Windows.Forms.TextBox();
            this.cbRegimen = new System.Windows.Forms.ComboBox();
            this.lblCelular = new System.Windows.Forms.Label();
            this.txtCelular = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCodePostal = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbCodePostal = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCodeCity = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCodeDepto = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbDepto = new System.Windows.Forms.ComboBox();
            this.cbCiudad_ = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbCity = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtDV = new System.Windows.Forms.TextBox();
            this.txtNombreComercial = new System.Windows.Forms.TextBox();
            this.txtRazonSocial = new System.Windows.Forms.TextBox();
            this.cbTipoDocumento = new System.Windows.Forms.ComboBox();
            this.cbTipoPersona = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dgvDetallesTributarios = new System.Windows.Forms.DataGridView();
            this.Codigo_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descricpcion_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClearDetalleTributario = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.cbDetalleTributario = new System.Windows.Forms.ComboBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.dgvDetallesRUT = new System.Windows.Forms.DataGridView();
            this.Codigo_r = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbInfoTributarioRUT = new System.Windows.Forms.ComboBox();
            this.btnClearInfoTributarioRUT = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.txtCIIU4 = new System.Windows.Forms.TextBox();
            this.btnListadoCIIU = new System.Windows.Forms.Button();
            this.txtCIIU3 = new System.Windows.Forms.TextBox();
            this.txtCIIU2 = new System.Windows.Forms.TextBox();
            this.txtCIIU1 = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetallesTributarios)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetallesRUT)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNit
            // 
            this.lblNit.AutoSize = true;
            this.lblNit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblNit.Location = new System.Drawing.Point(341, 25);
            this.lblNit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNit.Name = "lblNit";
            this.lblNit.Size = new System.Drawing.Size(156, 16);
            this.lblNit.TabIndex = 3;
            this.lblNit.Text = "Número de identificación";
            // 
            // txtNit
            // 
            this.txtNit.Location = new System.Drawing.Point(342, 43);
            this.txtNit.Margin = new System.Windows.Forms.Padding(4);
            this.txtNit.MaxLength = 50;
            this.txtNit.Name = "txtNit";
            this.txtNit.Size = new System.Drawing.Size(161, 22);
            this.txtNit.TabIndex = 0;
            // 
            // cbRegimen
            // 
            this.cbRegimen.DisplayMember = "NombreRegimen";
            this.cbRegimen.FormattingEnabled = true;
            this.cbRegimen.Location = new System.Drawing.Point(551, 41);
            this.cbRegimen.Margin = new System.Windows.Forms.Padding(4);
            this.cbRegimen.Name = "cbRegimen";
            this.cbRegimen.Size = new System.Drawing.Size(224, 24);
            this.cbRegimen.TabIndex = 2;
            this.cbRegimen.ValueMember = "IdRegimen";
            // 
            // lblCelular
            // 
            this.lblCelular.AutoSize = true;
            this.lblCelular.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCelular.Location = new System.Drawing.Point(442, 21);
            this.lblCelular.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCelular.Name = "lblCelular";
            this.lblCelular.Size = new System.Drawing.Size(114, 16);
            this.lblCelular.TabIndex = 4;
            this.lblCelular.Text = "Telefono / Celular";
            // 
            // txtCelular
            // 
            this.txtCelular.Location = new System.Drawing.Point(441, 39);
            this.txtCelular.Margin = new System.Windows.Forms.Padding(4);
            this.txtCelular.MaxLength = 100;
            this.txtCelular.Name = "txtCelular";
            this.txtCelular.Size = new System.Drawing.Size(316, 22);
            this.txtCelular.TabIndex = 1;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblEmail.Location = new System.Drawing.Point(8, 21);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(119, 16);
            this.lblEmail.TabIndex = 5;
            this.lblEmail.Text = "Correo Electronico";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(8, 39);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmail.MaxLength = 255;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(427, 22);
            this.txtEmail.TabIndex = 2;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(81, 20);
            this.txtDireccion.Margin = new System.Windows.Forms.Padding(4);
            this.txtDireccion.MaxLength = 255;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(417, 22);
            this.txtDireccion.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtCodePostal);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cbCodePostal);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtDireccion);
            this.groupBox1.Controls.Add(this.txtCodeCity);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtCodeDepto);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbDepto);
            this.groupBox1.Controls.Add(this.cbCiudad_);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cbCity);
            this.groupBox1.ForeColor = System.Drawing.Color.Blue;
            this.groupBox1.Location = new System.Drawing.Point(3, 136);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(784, 123);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DATOS DE UBICACIÓN";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(651, 96);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 16);
            this.label8.TabIndex = 12;
            this.label8.Text = "Code";
            // 
            // txtCodePostal
            // 
            this.txtCodePostal.BackColor = System.Drawing.Color.MintCream;
            this.txtCodePostal.Enabled = false;
            this.txtCodePostal.Location = new System.Drawing.Point(696, 93);
            this.txtCodePostal.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodePostal.MaxLength = 20;
            this.txtCodePostal.Name = "txtCodePostal";
            this.txtCodePostal.Size = new System.Drawing.Size(61, 22);
            this.txtCodePostal.TabIndex = 11;
            this.txtCodePostal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(504, 48);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 16);
            this.label7.TabIndex = 10;
            this.label7.Text = "Código postal";
            // 
            // cbCodePostal
            // 
            this.cbCodePostal.DisplayMember = "nombre";
            this.cbCodePostal.FormattingEnabled = true;
            this.cbCodePostal.Location = new System.Drawing.Point(506, 66);
            this.cbCodePostal.Margin = new System.Windows.Forms.Padding(4);
            this.cbCodePostal.Name = "cbCodePostal";
            this.cbCodePostal.Size = new System.Drawing.Size(251, 24);
            this.cbCodePostal.TabIndex = 9;
            this.cbCodePostal.ValueMember = "c_postal";
            this.cbCodePostal.SelectionChangeCommitted += new System.EventHandler(this.cbCodePostal_SelectionChangeCommitted);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(440, 49);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 16);
            this.label6.TabIndex = 8;
            this.label6.Text = "Code";
            // 
            // txtCodeCity
            // 
            this.txtCodeCity.BackColor = System.Drawing.Color.MintCream;
            this.txtCodeCity.Enabled = false;
            this.txtCodeCity.Location = new System.Drawing.Point(441, 67);
            this.txtCodeCity.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodeCity.MaxLength = 20;
            this.txtCodeCity.Name = "txtCodeCity";
            this.txtCodeCity.Size = new System.Drawing.Size(57, 22);
            this.txtCodeCity.TabIndex = 7;
            this.txtCodeCity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(115, 96);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "Code";
            // 
            // txtCodeDepto
            // 
            this.txtCodeDepto.BackColor = System.Drawing.Color.MintCream;
            this.txtCodeDepto.Enabled = false;
            this.txtCodeDepto.Location = new System.Drawing.Point(160, 93);
            this.txtCodeDepto.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodeDepto.MaxLength = 20;
            this.txtCodeDepto.Name = "txtCodeDepto";
            this.txtCodeDepto.Size = new System.Drawing.Size(57, 22);
            this.txtCodeDepto.TabIndex = 5;
            this.txtCodeDepto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label15.Location = new System.Drawing.Point(8, 23);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(65, 16);
            this.label15.TabIndex = 3;
            this.label15.Text = "Dirección";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(6, 47);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Departamento";
            // 
            // cbDepto
            // 
            this.cbDepto.DisplayMember = "nombre";
            this.cbDepto.FormattingEnabled = true;
            this.cbDepto.Location = new System.Drawing.Point(8, 65);
            this.cbDepto.Margin = new System.Windows.Forms.Padding(4);
            this.cbDepto.Name = "cbDepto";
            this.cbDepto.Size = new System.Drawing.Size(208, 24);
            this.cbDepto.TabIndex = 0;
            this.cbDepto.ValueMember = "id";
            this.cbDepto.SelectionChangeCommitted += new System.EventHandler(this.cbDepto_SelectionChangeCommitted);
            // 
            // cbCiudad_
            // 
            this.cbCiudad_.DisplayMember = "NombreCiudad";
            this.cbCiudad_.FormattingEnabled = true;
            this.cbCiudad_.Location = new System.Drawing.Point(222, 66);
            this.cbCiudad_.Margin = new System.Windows.Forms.Padding(4);
            this.cbCiudad_.Name = "cbCiudad_";
            this.cbCiudad_.Size = new System.Drawing.Size(213, 24);
            this.cbCiudad_.TabIndex = 1;
            this.cbCiudad_.ValueMember = "IdCiudad";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(220, 48);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Ciudad";
            // 
            // cbCity
            // 
            this.cbCity.DisplayMember = "nombre";
            this.cbCity.FormattingEnabled = true;
            this.cbCity.Location = new System.Drawing.Point(222, 93);
            this.cbCity.Margin = new System.Windows.Forms.Padding(4);
            this.cbCity.Name = "cbCity";
            this.cbCity.Size = new System.Drawing.Size(213, 24);
            this.cbCity.TabIndex = 1;
            this.cbCity.ValueMember = "code";
            this.cbCity.SelectionChangeCommitted += new System.EventHandler(this.cbCity_SelectionChangeCommitted);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.lblNit);
            this.groupBox2.Controls.Add(this.txtDV);
            this.groupBox2.Controls.Add(this.txtNombreComercial);
            this.groupBox2.Controls.Add(this.txtRazonSocial);
            this.groupBox2.Controls.Add(this.txtNit);
            this.groupBox2.Controls.Add(this.cbRegimen);
            this.groupBox2.Controls.Add(this.cbTipoDocumento);
            this.groupBox2.Controls.Add(this.cbTipoPersona);
            this.groupBox2.ForeColor = System.Drawing.Color.Blue;
            this.groupBox2.Location = new System.Drawing.Point(3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(784, 128);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "DATOS DE LA EMPRESA";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(157, 23);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(127, 16);
            this.label10.TabIndex = 3;
            this.label10.Text = "Tipo de Documento";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label12.Location = new System.Drawing.Point(549, 23);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 16);
            this.label12.TabIndex = 3;
            this.label12.Text = "Régimen";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(7, 23);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(109, 16);
            this.label9.TabIndex = 3;
            this.label9.Text = "Tipo de Persona";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(509, 25);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(27, 16);
            this.label11.TabIndex = 3;
            this.label11.Text = "DV";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label14.Location = new System.Drawing.Point(341, 77);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(121, 16);
            this.label14.TabIndex = 3;
            this.label14.Text = "Nombre Comercial";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label13.Location = new System.Drawing.Point(7, 76);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(88, 16);
            this.label13.TabIndex = 3;
            this.label13.Text = "Razón Social";
            // 
            // txtDV
            // 
            this.txtDV.Location = new System.Drawing.Point(511, 43);
            this.txtDV.Margin = new System.Windows.Forms.Padding(4);
            this.txtDV.MaxLength = 1;
            this.txtDV.Name = "txtDV";
            this.txtDV.Size = new System.Drawing.Size(32, 22);
            this.txtDV.TabIndex = 1;
            // 
            // txtNombreComercial
            // 
            this.txtNombreComercial.Location = new System.Drawing.Point(342, 95);
            this.txtNombreComercial.Margin = new System.Windows.Forms.Padding(4);
            this.txtNombreComercial.MaxLength = 250;
            this.txtNombreComercial.Name = "txtNombreComercial";
            this.txtNombreComercial.Size = new System.Drawing.Size(433, 22);
            this.txtNombreComercial.TabIndex = 8;
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.Location = new System.Drawing.Point(8, 95);
            this.txtRazonSocial.Margin = new System.Windows.Forms.Padding(4);
            this.txtRazonSocial.MaxLength = 250;
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.Size = new System.Drawing.Size(324, 22);
            this.txtRazonSocial.TabIndex = 7;
            // 
            // cbTipoDocumento
            // 
            this.cbTipoDocumento.DisplayMember = "descripcion";
            this.cbTipoDocumento.FormattingEnabled = true;
            this.cbTipoDocumento.Location = new System.Drawing.Point(158, 41);
            this.cbTipoDocumento.Margin = new System.Windows.Forms.Padding(4);
            this.cbTipoDocumento.Name = "cbTipoDocumento";
            this.cbTipoDocumento.Size = new System.Drawing.Size(174, 24);
            this.cbTipoDocumento.TabIndex = 4;
            this.cbTipoDocumento.ValueMember = "codigo";
            // 
            // cbTipoPersona
            // 
            this.cbTipoPersona.DisplayMember = "descripcion";
            this.cbTipoPersona.FormattingEnabled = true;
            this.cbTipoPersona.Location = new System.Drawing.Point(8, 41);
            this.cbTipoPersona.Margin = new System.Windows.Forms.Padding(4);
            this.cbTipoPersona.Name = "cbTipoPersona";
            this.cbTipoPersona.Size = new System.Drawing.Size(142, 24);
            this.cbTipoPersona.TabIndex = 3;
            this.cbTipoPersona.ValueMember = "codigo";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox3.Controls.Add(this.txtEmail);
            this.groupBox3.Controls.Add(this.lblEmail);
            this.groupBox3.Controls.Add(this.txtCelular);
            this.groupBox3.Controls.Add(this.lblCelular);
            this.groupBox3.ForeColor = System.Drawing.Color.Blue;
            this.groupBox3.Location = new System.Drawing.Point(3, 266);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(784, 67);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "DATOS DE CONTACTO";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox4.Controls.Add(this.dgvDetallesTributarios);
            this.groupBox4.Controls.Add(this.btnClearDetalleTributario);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.cbDetalleTributario);
            this.groupBox4.ForeColor = System.Drawing.Color.Blue;
            this.groupBox4.Location = new System.Drawing.Point(3, 338);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(389, 169);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "DETALLES TRIBUTARIOS";
            // 
            // dgvDetallesTributarios
            // 
            this.dgvDetallesTributarios.AllowUserToAddRows = false;
            this.dgvDetallesTributarios.BackgroundColor = System.Drawing.Color.MintCream;
            this.dgvDetallesTributarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetallesTributarios.ColumnHeadersVisible = false;
            this.dgvDetallesTributarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo_,
            this.Name_,
            this.Descricpcion_});
            this.dgvDetallesTributarios.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvDetallesTributarios.Location = new System.Drawing.Point(8, 63);
            this.dgvDetallesTributarios.Name = "dgvDetallesTributarios";
            this.dgvDetallesTributarios.RowHeadersVisible = false;
            this.dgvDetallesTributarios.Size = new System.Drawing.Size(350, 97);
            this.dgvDetallesTributarios.TabIndex = 6;
            // 
            // Codigo_
            // 
            this.Codigo_.DataPropertyName = "codigo";
            this.Codigo_.HeaderText = "";
            this.Codigo_.Name = "Codigo_";
            this.Codigo_.Width = 34;
            // 
            // Name_
            // 
            this.Name_.DataPropertyName = "nombre";
            this.Name_.HeaderText = "";
            this.Name_.Name = "Name_";
            this.Name_.Width = 74;
            // 
            // Descricpcion_
            // 
            this.Descricpcion_.DataPropertyName = "descripcion";
            this.Descricpcion_.HeaderText = "";
            this.Descricpcion_.Name = "Descricpcion_";
            this.Descricpcion_.Width = 226;
            // 
            // btnClearDetalleTributario
            // 
            this.btnClearDetalleTributario.Location = new System.Drawing.Point(360, 137);
            this.btnClearDetalleTributario.Name = "btnClearDetalleTributario";
            this.btnClearDetalleTributario.Size = new System.Drawing.Size(22, 23);
            this.btnClearDetalleTributario.TabIndex = 7;
            this.btnClearDetalleTributario.Text = ".";
            this.btnClearDetalleTributario.UseVisualStyleBackColor = true;
            this.btnClearDetalleTributario.Click += new System.EventHandler(this.btnClearDetalleTributario_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label16.Location = new System.Drawing.Point(6, 20);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(169, 16);
            this.label16.TabIndex = 5;
            this.label16.Text = "Detalle tributario del cliente";
            // 
            // cbDetalleTributario
            // 
            this.cbDetalleTributario.DisplayMember = "descripcion";
            this.cbDetalleTributario.FormattingEnabled = true;
            this.cbDetalleTributario.Location = new System.Drawing.Point(8, 38);
            this.cbDetalleTributario.Margin = new System.Windows.Forms.Padding(4);
            this.cbDetalleTributario.Name = "cbDetalleTributario";
            this.cbDetalleTributario.Size = new System.Drawing.Size(374, 24);
            this.cbDetalleTributario.TabIndex = 4;
            this.cbDetalleTributario.ValueMember = "code";
            this.cbDetalleTributario.SelectionChangeCommitted += new System.EventHandler(this.cbDetalleTributario_SelectionChangeCommitted);
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox5.Controls.Add(this.dgvDetallesRUT);
            this.groupBox5.Controls.Add(this.cbInfoTributarioRUT);
            this.groupBox5.Controls.Add(this.btnClearInfoTributarioRUT);
            this.groupBox5.Controls.Add(this.label17);
            this.groupBox5.ForeColor = System.Drawing.Color.Blue;
            this.groupBox5.Location = new System.Drawing.Point(398, 338);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(389, 169);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "INFORMACION TRIBUTARIA Y ADUANERA";
            // 
            // dgvDetallesRUT
            // 
            this.dgvDetallesRUT.AllowUserToAddRows = false;
            this.dgvDetallesRUT.BackgroundColor = System.Drawing.Color.MintCream;
            this.dgvDetallesRUT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetallesRUT.ColumnHeadersVisible = false;
            this.dgvDetallesRUT.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo_r,
            this.dataGridViewTextBoxColumn1});
            this.dgvDetallesRUT.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvDetallesRUT.Location = new System.Drawing.Point(7, 64);
            this.dgvDetallesRUT.Name = "dgvDetallesRUT";
            this.dgvDetallesRUT.RowHeadersVisible = false;
            this.dgvDetallesRUT.Size = new System.Drawing.Size(350, 96);
            this.dgvDetallesRUT.TabIndex = 6;
            // 
            // Codigo_r
            // 
            this.Codigo_r.DataPropertyName = "codigo";
            this.Codigo_r.HeaderText = "";
            this.Codigo_r.Name = "Codigo_r";
            this.Codigo_r.Width = 74;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "descripcion";
            this.dataGridViewTextBoxColumn1.HeaderText = "";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 260;
            // 
            // cbInfoTributarioRUT
            // 
            this.cbInfoTributarioRUT.DisplayMember = "display";
            this.cbInfoTributarioRUT.FormattingEnabled = true;
            this.cbInfoTributarioRUT.Location = new System.Drawing.Point(7, 38);
            this.cbInfoTributarioRUT.Margin = new System.Windows.Forms.Padding(4);
            this.cbInfoTributarioRUT.Name = "cbInfoTributarioRUT";
            this.cbInfoTributarioRUT.Size = new System.Drawing.Size(373, 24);
            this.cbInfoTributarioRUT.TabIndex = 9;
            this.cbInfoTributarioRUT.ValueMember = "codigo";
            this.cbInfoTributarioRUT.SelectionChangeCommitted += new System.EventHandler(this.cbInfoTributarioRUT_SelectionChangeCommitted);
            // 
            // btnClearInfoTributarioRUT
            // 
            this.btnClearInfoTributarioRUT.Location = new System.Drawing.Point(358, 137);
            this.btnClearInfoTributarioRUT.Name = "btnClearInfoTributarioRUT";
            this.btnClearInfoTributarioRUT.Size = new System.Drawing.Size(22, 23);
            this.btnClearInfoTributarioRUT.TabIndex = 8;
            this.btnClearInfoTributarioRUT.Text = ".";
            this.btnClearInfoTributarioRUT.UseVisualStyleBackColor = true;
            this.btnClearInfoTributarioRUT.Click += new System.EventHandler(this.btnClearInfoTributarioRUT_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label17.Location = new System.Drawing.Point(5, 20);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(232, 16);
            this.label17.TabIndex = 5;
            this.label17.Text = "Valores de la casilla 53 ó 54 del RUT.";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnGuardar.Location = new System.Drawing.Point(714, 526);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(73, 38);
            this.btnGuardar.TabIndex = 8;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox6.Controls.Add(this.txtCIIU4);
            this.groupBox6.Controls.Add(this.btnListadoCIIU);
            this.groupBox6.Controls.Add(this.txtCIIU3);
            this.groupBox6.Controls.Add(this.txtCIIU2);
            this.groupBox6.Controls.Add(this.txtCIIU1);
            this.groupBox6.ForeColor = System.Drawing.Color.Blue;
            this.groupBox6.Location = new System.Drawing.Point(3, 510);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(389, 54);
            this.groupBox6.TabIndex = 9;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "CODIGOS ACTIVIDAD ECONOMICA";
            // 
            // txtCIIU4
            // 
            this.txtCIIU4.Location = new System.Drawing.Point(296, 23);
            this.txtCIIU4.MaxLength = 4;
            this.txtCIIU4.Name = "txtCIIU4";
            this.txtCIIU4.Size = new System.Drawing.Size(54, 22);
            this.txtCIIU4.TabIndex = 12;
            // 
            // btnListadoCIIU
            // 
            this.btnListadoCIIU.Image = ((System.Drawing.Image)(resources.GetObject("btnListadoCIIU.Image")));
            this.btnListadoCIIU.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnListadoCIIU.Location = new System.Drawing.Point(357, 22);
            this.btnListadoCIIU.Margin = new System.Windows.Forms.Padding(4);
            this.btnListadoCIIU.Name = "btnListadoCIIU";
            this.btnListadoCIIU.Size = new System.Drawing.Size(25, 24);
            this.btnListadoCIIU.TabIndex = 11;
            this.btnListadoCIIU.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnListadoCIIU.UseVisualStyleBackColor = true;
            this.btnListadoCIIU.Click += new System.EventHandler(this.btnListadoCIIU_Click);
            // 
            // txtCIIU3
            // 
            this.txtCIIU3.Location = new System.Drawing.Point(236, 23);
            this.txtCIIU3.MaxLength = 4;
            this.txtCIIU3.Name = "txtCIIU3";
            this.txtCIIU3.Size = new System.Drawing.Size(54, 22);
            this.txtCIIU3.TabIndex = 2;
            // 
            // txtCIIU2
            // 
            this.txtCIIU2.Location = new System.Drawing.Point(175, 23);
            this.txtCIIU2.MaxLength = 4;
            this.txtCIIU2.Name = "txtCIIU2";
            this.txtCIIU2.Size = new System.Drawing.Size(54, 22);
            this.txtCIIU2.TabIndex = 1;
            // 
            // txtCIIU1
            // 
            this.txtCIIU1.Location = new System.Drawing.Point(115, 23);
            this.txtCIIU1.MaxLength = 4;
            this.txtCIIU1.Name = "txtCIIU1";
            this.txtCIIU1.Size = new System.Drawing.Size(54, 22);
            this.txtCIIU1.TabIndex = 0;
            // 
            // FrmCompany
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(791, 567);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCompany";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EMPRESA";
            this.Load += new System.EventHandler(this.FrmCompany_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetallesTributarios)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetallesRUT)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbRegimen;
        private System.Windows.Forms.Label lblNit;
        private System.Windows.Forms.Label lblCelular;
        private System.Windows.Forms.TextBox txtCelular;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtDireccion;
        public System.Windows.Forms.TextBox txtNit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbDepto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbCity;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCodePostal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbCodePostal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCodeCity;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCodeDepto;
        private System.Windows.Forms.ComboBox cbCiudad_;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbTipoPersona;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbTipoDocumento;
        private System.Windows.Forms.Label label11;
        public System.Windows.Forms.TextBox txtDV;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        public System.Windows.Forms.TextBox txtRazonSocial;
        private System.Windows.Forms.Label label14;
        public System.Windows.Forms.TextBox txtNombreComercial;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cbDetalleTributario;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btnClearDetalleTributario;
        private System.Windows.Forms.ComboBox cbInfoTributarioRUT;
        private System.Windows.Forms.Button btnClearInfoTributarioRUT;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.DataGridView dgvDetallesTributarios;
        private System.Windows.Forms.DataGridView dgvDetallesRUT;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo_r;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo_;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name_;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descricpcion_;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox txtCIIU1;
        private System.Windows.Forms.TextBox txtCIIU3;
        private System.Windows.Forms.TextBox txtCIIU2;
        private System.Windows.Forms.Button btnListadoCIIU;
        private System.Windows.Forms.TextBox txtCIIU4;
    }
}