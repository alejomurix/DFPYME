namespace Aplicacion.Administracion.Puc
{
    partial class FrmRelacionCuentas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRelacionCuentas));
            this.txtNCtaVentaTransaccion = new System.Windows.Forms.TextBox();
            this.txtCtaVentaTransaccion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbRelacionCuenta = new System.Windows.Forms.GroupBox();
            this.btnPucVentaCheque = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNCtaVentaCheque = new System.Windows.Forms.TextBox();
            this.txtCtaVentaCheque = new System.Windows.Forms.TextBox();
            this.btnPucVentaTransaccion = new System.Windows.Forms.Button();
            this.btnPucVentaEfectivo = new System.Windows.Forms.Button();
            this.btnPucVentaCredito = new System.Windows.Forms.Button();
            this.btnPucInventario = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNCtaInventario = new System.Windows.Forms.TextBox();
            this.txtCtaInventario = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNCtaVentaCredito = new System.Windows.Forms.TextBox();
            this.txtCtaVentaCredito = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNCtaVentaEfectivo = new System.Windows.Forms.TextBox();
            this.txtCtaVentaEfectivo = new System.Windows.Forms.TextBox();
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.btnGuardar = new System.Windows.Forms.ToolStripButton();
            this.gbRelacionCuenta.SuspendLayout();
            this.tsMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtNCtaVentaTransaccion
            // 
            this.txtNCtaVentaTransaccion.Location = new System.Drawing.Point(310, 135);
            this.txtNCtaVentaTransaccion.Name = "txtNCtaVentaTransaccion";
            this.txtNCtaVentaTransaccion.ReadOnly = true;
            this.txtNCtaVentaTransaccion.Size = new System.Drawing.Size(420, 22);
            this.txtNCtaVentaTransaccion.TabIndex = 0;
            // 
            // txtCtaVentaTransaccion
            // 
            this.txtCtaVentaTransaccion.Location = new System.Drawing.Point(177, 135);
            this.txtCtaVentaTransaccion.Name = "txtCtaVentaTransaccion";
            this.txtCtaVentaTransaccion.Size = new System.Drawing.Size(100, 22);
            this.txtCtaVentaTransaccion.TabIndex = 1;
            this.txtCtaVentaTransaccion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCtaVentaTransaccion_KeyPress);
            this.txtCtaVentaTransaccion.Validating += new System.ComponentModel.CancelEventHandler(this.txtCtaVentaTransaccion_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ventas en transacción";
            // 
            // gbRelacionCuenta
            // 
            this.gbRelacionCuenta.Controls.Add(this.btnPucVentaCheque);
            this.gbRelacionCuenta.Controls.Add(this.label5);
            this.gbRelacionCuenta.Controls.Add(this.txtNCtaVentaCheque);
            this.gbRelacionCuenta.Controls.Add(this.txtCtaVentaCheque);
            this.gbRelacionCuenta.Controls.Add(this.btnPucVentaTransaccion);
            this.gbRelacionCuenta.Controls.Add(this.btnPucVentaEfectivo);
            this.gbRelacionCuenta.Controls.Add(this.btnPucVentaCredito);
            this.gbRelacionCuenta.Controls.Add(this.btnPucInventario);
            this.gbRelacionCuenta.Controls.Add(this.label4);
            this.gbRelacionCuenta.Controls.Add(this.txtNCtaInventario);
            this.gbRelacionCuenta.Controls.Add(this.txtCtaInventario);
            this.gbRelacionCuenta.Controls.Add(this.label3);
            this.gbRelacionCuenta.Controls.Add(this.txtNCtaVentaCredito);
            this.gbRelacionCuenta.Controls.Add(this.txtCtaVentaCredito);
            this.gbRelacionCuenta.Controls.Add(this.label2);
            this.gbRelacionCuenta.Controls.Add(this.txtNCtaVentaEfectivo);
            this.gbRelacionCuenta.Controls.Add(this.txtCtaVentaEfectivo);
            this.gbRelacionCuenta.Controls.Add(this.label1);
            this.gbRelacionCuenta.Controls.Add(this.txtNCtaVentaTransaccion);
            this.gbRelacionCuenta.Controls.Add(this.txtCtaVentaTransaccion);
            this.gbRelacionCuenta.Location = new System.Drawing.Point(12, 33);
            this.gbRelacionCuenta.Name = "gbRelacionCuenta";
            this.gbRelacionCuenta.Size = new System.Drawing.Size(745, 221);
            this.gbRelacionCuenta.TabIndex = 3;
            this.gbRelacionCuenta.TabStop = false;
            // 
            // btnPucVentaCheque
            // 
            this.btnPucVentaCheque.Location = new System.Drawing.Point(279, 172);
            this.btnPucVentaCheque.Name = "btnPucVentaCheque";
            this.btnPucVentaCheque.Size = new System.Drawing.Size(25, 24);
            this.btnPucVentaCheque.TabIndex = 19;
            this.btnPucVentaCheque.Text = "...";
            this.btnPucVentaCheque.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 16);
            this.label5.TabIndex = 18;
            this.label5.Text = "Ventas con cheque";
            // 
            // txtNCtaVentaCheque
            // 
            this.txtNCtaVentaCheque.Location = new System.Drawing.Point(310, 173);
            this.txtNCtaVentaCheque.Name = "txtNCtaVentaCheque";
            this.txtNCtaVentaCheque.ReadOnly = true;
            this.txtNCtaVentaCheque.Size = new System.Drawing.Size(420, 22);
            this.txtNCtaVentaCheque.TabIndex = 16;
            // 
            // txtCtaVentaCheque
            // 
            this.txtCtaVentaCheque.Location = new System.Drawing.Point(177, 173);
            this.txtCtaVentaCheque.Name = "txtCtaVentaCheque";
            this.txtCtaVentaCheque.Size = new System.Drawing.Size(100, 22);
            this.txtCtaVentaCheque.TabIndex = 17;
            this.txtCtaVentaCheque.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCtaVentaCheque_KeyPress);
            this.txtCtaVentaCheque.Validating += new System.ComponentModel.CancelEventHandler(this.txtCtaVentaCheque_Validating);
            // 
            // btnPucVentaTransaccion
            // 
            this.btnPucVentaTransaccion.Location = new System.Drawing.Point(279, 134);
            this.btnPucVentaTransaccion.Name = "btnPucVentaTransaccion";
            this.btnPucVentaTransaccion.Size = new System.Drawing.Size(25, 24);
            this.btnPucVentaTransaccion.TabIndex = 15;
            this.btnPucVentaTransaccion.Text = "...";
            this.btnPucVentaTransaccion.UseVisualStyleBackColor = true;
            // 
            // btnPucVentaEfectivo
            // 
            this.btnPucVentaEfectivo.Location = new System.Drawing.Point(279, 94);
            this.btnPucVentaEfectivo.Name = "btnPucVentaEfectivo";
            this.btnPucVentaEfectivo.Size = new System.Drawing.Size(25, 24);
            this.btnPucVentaEfectivo.TabIndex = 14;
            this.btnPucVentaEfectivo.Text = "...";
            this.btnPucVentaEfectivo.UseVisualStyleBackColor = true;
            // 
            // btnPucVentaCredito
            // 
            this.btnPucVentaCredito.Location = new System.Drawing.Point(279, 58);
            this.btnPucVentaCredito.Name = "btnPucVentaCredito";
            this.btnPucVentaCredito.Size = new System.Drawing.Size(25, 24);
            this.btnPucVentaCredito.TabIndex = 13;
            this.btnPucVentaCredito.Text = "...";
            this.btnPucVentaCredito.UseVisualStyleBackColor = true;
            // 
            // btnPucInventario
            // 
            this.btnPucInventario.Location = new System.Drawing.Point(279, 20);
            this.btnPucInventario.Name = "btnPucInventario";
            this.btnPucInventario.Size = new System.Drawing.Size(25, 24);
            this.btnPucInventario.TabIndex = 12;
            this.btnPucInventario.Text = "...";
            this.btnPucInventario.UseVisualStyleBackColor = true;
            this.btnPucInventario.Click += new System.EventHandler(this.btnPucInventario_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "Inventario de productos";
            // 
            // txtNCtaInventario
            // 
            this.txtNCtaInventario.Location = new System.Drawing.Point(310, 21);
            this.txtNCtaInventario.Name = "txtNCtaInventario";
            this.txtNCtaInventario.ReadOnly = true;
            this.txtNCtaInventario.Size = new System.Drawing.Size(420, 22);
            this.txtNCtaInventario.TabIndex = 9;
            // 
            // txtCtaInventario
            // 
            this.txtCtaInventario.Location = new System.Drawing.Point(177, 21);
            this.txtCtaInventario.Name = "txtCtaInventario";
            this.txtCtaInventario.Size = new System.Drawing.Size(100, 22);
            this.txtCtaInventario.TabIndex = 10;
            this.txtCtaInventario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCtaInventario_KeyPress);
            this.txtCtaInventario.Validating += new System.ComponentModel.CancelEventHandler(this.txtCtaInventario_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Ventas a crédito";
            // 
            // txtNCtaVentaCredito
            // 
            this.txtNCtaVentaCredito.Location = new System.Drawing.Point(310, 59);
            this.txtNCtaVentaCredito.Name = "txtNCtaVentaCredito";
            this.txtNCtaVentaCredito.ReadOnly = true;
            this.txtNCtaVentaCredito.Size = new System.Drawing.Size(420, 22);
            this.txtNCtaVentaCredito.TabIndex = 6;
            // 
            // txtCtaVentaCredito
            // 
            this.txtCtaVentaCredito.Location = new System.Drawing.Point(177, 59);
            this.txtCtaVentaCredito.Name = "txtCtaVentaCredito";
            this.txtCtaVentaCredito.Size = new System.Drawing.Size(100, 22);
            this.txtCtaVentaCredito.TabIndex = 7;
            this.txtCtaVentaCredito.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCtaVentaCredito_KeyPress);
            this.txtCtaVentaCredito.Validating += new System.ComponentModel.CancelEventHandler(this.txtCtaVentaCredito_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Ventas en efectivo";
            // 
            // txtNCtaVentaEfectivo
            // 
            this.txtNCtaVentaEfectivo.Location = new System.Drawing.Point(310, 96);
            this.txtNCtaVentaEfectivo.Name = "txtNCtaVentaEfectivo";
            this.txtNCtaVentaEfectivo.ReadOnly = true;
            this.txtNCtaVentaEfectivo.Size = new System.Drawing.Size(420, 22);
            this.txtNCtaVentaEfectivo.TabIndex = 3;
            // 
            // txtCtaVentaEfectivo
            // 
            this.txtCtaVentaEfectivo.Location = new System.Drawing.Point(177, 96);
            this.txtCtaVentaEfectivo.Name = "txtCtaVentaEfectivo";
            this.txtCtaVentaEfectivo.Size = new System.Drawing.Size(100, 22);
            this.txtCtaVentaEfectivo.TabIndex = 4;
            this.txtCtaVentaEfectivo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCtaVentaEfectivo_KeyPress);
            this.txtCtaVentaEfectivo.Validating += new System.ComponentModel.CancelEventHandler(this.txtCtaVentaEfectivo_Validating);
            // 
            // tsMenu
            // 
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnGuardar});
            this.tsMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(772, 25);
            this.tsMenu.TabIndex = 6;
            this.tsMenu.Text = "Menu";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(74, 22);
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // FrmRelacionCuentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(772, 331);
            this.Controls.Add(this.tsMenu);
            this.Controls.Add(this.gbRelacionCuenta);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmRelacionCuentas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmRelacionCuentas";
            this.Load += new System.EventHandler(this.FrmRelacionCuentas_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmRelacionCuentas_KeyDown);
            this.gbRelacionCuenta.ResumeLayout(false);
            this.gbRelacionCuenta.PerformLayout();
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNCtaVentaTransaccion;
        private System.Windows.Forms.TextBox txtCtaVentaTransaccion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbRelacionCuenta;
        private System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.ToolStripButton btnGuardar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNCtaInventario;
        private System.Windows.Forms.TextBox txtCtaInventario;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNCtaVentaCredito;
        private System.Windows.Forms.TextBox txtCtaVentaCredito;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNCtaVentaEfectivo;
        private System.Windows.Forms.TextBox txtCtaVentaEfectivo;
        private System.Windows.Forms.Button btnPucInventario;
        private System.Windows.Forms.Button btnPucVentaTransaccion;
        private System.Windows.Forms.Button btnPucVentaEfectivo;
        private System.Windows.Forms.Button btnPucVentaCredito;
        private System.Windows.Forms.Button btnPucVentaCheque;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNCtaVentaCheque;
        private System.Windows.Forms.TextBox txtCtaVentaCheque;
    }
}