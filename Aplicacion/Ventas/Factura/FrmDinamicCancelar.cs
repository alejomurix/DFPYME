using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BussinesLayer.Clases;
using CustomControl;
using DTO.Clases;
using Utilities;
using Aplicacion.Inventario.Producto;

namespace Aplicacion.Ventas.Factura
{
    public partial class FrmDinamicCancelar : Form
    {
        private ErrorProvider miError;

        private BussinesFormaPago miBussinesPago;

        public bool Abono;

        public string ValorAbono;

        private int LocationY { set; get; }

        private List<Criterio> ObjControls { set; get; }

        public FrmDinamicCancelar()
        {
            InitializeComponent();
            Abono = false;
            ValorAbono = "";
            ObjControls = new List<Criterio>();
            miError = new ErrorProvider();
            miBussinesPago = new BussinesFormaPago();
        }

        private void FrmCancelarVenta_Load(object sender, EventArgs e)
        {
            try
            {
                txtTotal.TabIndex = 10;
                LocationY = PanelCambio.Size.Height + PanelCambio.Location.Y + 1;

                if (Abono)
                {
                    PanelAbono();
                }

                var formas = miBussinesPago.FormasDePagoHabiles();
                foreach (DataRow fRow in formas.Rows)
                {
                    var miPanel = CreatePanel();
                    miPanel.Name = "P" + fRow["nombreforma_pago"].ToString();
                    miPanel.BorderStyle = BorderStyle.FixedSingle;
                    miPanel.Location = new Point(9, LocationY);

                    var miLabelName = CreateLabelNombre();
                    miLabelName.Name = "lbl" + fRow["nombreforma_pago"].ToString();
                    miLabelName.Text = fRow["nombreforma_pago"].ToString().ToUpper();

                    miPanel.Controls.Add(miLabelName);

                    miLabelName = CreateLabelPesos();
                    miLabelName.Name = "lblPesos" + fRow["nombreforma_pago"].ToString();
                    miLabelName.Text = "$";

                    miPanel.Controls.Add(miLabelName);

                    var miTxtName = CreateTextBox();
                    miTxtName.Name = fRow["nombreforma_pago"].ToString().ToUpper();
                    miTxtName.Text = "0";
                    miTxtName.TabIndex = Convert.ToInt32(fRow["idforma_pago"]);
                    miTxtName.KeyPress += new KeyPressEventHandler(Dynamic_keyPress);

                    ObjControls.Add(new Criterio
                                {
                                    Id = Convert.ToInt32(fRow["idforma_pago"]),
                                    Nombre = fRow["nombreforma_pago"].ToString().ToUpper()
                                });

                    miPanel.Controls.Add(miTxtName);

                    miPanel.ResumeLayout(false);
                    miPanel.PerformLayout();

                    gbFormaPago.Controls.Add(miPanel);

                    LocationY = miPanel.Size.Height + miPanel.Location.Y + 1;
                }
                /*PanelCambio.Location = new Point(9, LocationY);
                LocationY = PanelCambio.Size.Height + PanelCambio.Location.Y + 5;*/

                gbFormaPago.Size = new Size(this.gbFormaPago.Size.Width, LocationY + 10);

                this.Size = new Size(this.Size.Width, this.gbFormaPago.Size.Height + 60);

                if (!Abono)
                {
                    var control = ObjControls.Find(d => d.Id.Equals(ObjControls.Min(d2 => d2.Id)));
                    var c = gbFormaPago.Controls.Find(control.Nombre, true);
                    var j = c.First();
                    j.Focus();
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void AnticipoCliente()
        {
            Label lblAdelantos = new Label();

            // lblAdelantos
            // 
            lblAdelantos.AutoSize = true;
            lblAdelantos.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            lblAdelantos.Location = new System.Drawing.Point(18, 21);
            lblAdelantos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblAdelantos.Name = "lblAdelantos";
            lblAdelantos.Size = new System.Drawing.Size(146, 25);
            lblAdelantos.TabIndex = 10;
            lblAdelantos.Text = "ADELANTOS: ";

            Label lblPesosAdelanto = new Label();
            // lblPesosAdelanto
            // 
            lblPesosAdelanto.AutoSize = true;
            lblPesosAdelanto.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            lblPesosAdelanto.Location = new System.Drawing.Point(160, 21);
            lblPesosAdelanto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblPesosAdelanto.Name = "lblPesosAdelanto";
            lblPesosAdelanto.Size = new System.Drawing.Size(23, 25);
            lblPesosAdelanto.TabIndex = 11;
            lblPesosAdelanto.Text = "$";

            // txtAdelantoC
            //
            TextBox txtAdelantoC = new TextBox();
            txtAdelantoC.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            txtAdelantoC.Location = new System.Drawing.Point(191, 18);
            txtAdelantoC.Name = "txtAdelantoC";
            txtAdelantoC.ReadOnly = true;
            txtAdelantoC.Size = new System.Drawing.Size(208, 30);
            txtAdelantoC.TabIndex = 9;
            txtAdelantoC.Text = "0";
            txtAdelantoC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            // lblBonos
            // 
            Label lblBonos = new Label();
            lblBonos.AutoSize = true;
            lblBonos.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            lblBonos.Location = new System.Drawing.Point(17, 58);
            lblBonos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblBonos.Name = "lblBonos";
            lblBonos.Size = new System.Drawing.Size(96, 25);
            lblBonos.TabIndex = 13;
            lblBonos.Text = "BONOS: ";

            // lblPesosBono
            // 
            Label lblPesosBono = new Label();
            lblPesosBono.AutoSize = true;
            lblPesosBono.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            lblPesosBono.Location = new System.Drawing.Point(159, 58);
            lblPesosBono.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblPesosBono.Name = "lblPesosBono";
            lblPesosBono.Size = new System.Drawing.Size(23, 25);
            lblPesosBono.TabIndex = 14;
            lblPesosBono.Text = "$";

            // txtBonoC
            // 
            TextBox txtBonoC = new TextBox();
            txtBonoC.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            txtBonoC.Location = new System.Drawing.Point(190, 55);
            txtBonoC.Name = "txtBonoC";
            txtBonoC.ReadOnly = true;
            txtBonoC.Size = new System.Drawing.Size(208, 30);
            txtBonoC.TabIndex = 12;
            txtBonoC.Text = "0";
            txtBonoC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            GroupBox gbSaldo = new GroupBox();

            // gbSaldo
            //
            gbSaldo.SuspendLayout();

            gbSaldo.Controls.Add(lblAdelantos);
            gbSaldo.Controls.Add(lblPesosAdelanto);
            gbSaldo.Controls.Add(txtAdelantoC);
            gbSaldo.Controls.Add(lblBonos);
            gbSaldo.Controls.Add(lblPesosBono);
            gbSaldo.Controls.Add(txtBonoC);
            gbSaldo.Location = new System.Drawing.Point(12, 4);
            gbSaldo.Name = "gbSaldo";
            gbSaldo.Size = new System.Drawing.Size(425, 94);
            gbSaldo.TabIndex = 2;
            gbSaldo.TabStop = false;
            gbSaldo.Text = "Saldos del Cliente";

            gbSaldo.ResumeLayout(false);
            gbSaldo.PerformLayout();

            this.Controls.Add(gbSaldo);
        }

        private void PagoAnticipoCliente()
        {
            // lblAdelanto
            // 
            Label lblAdelanto = new Label();
            lblAdelanto.AutoSize = true;
            lblAdelanto.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            lblAdelanto.Location = new System.Drawing.Point(18, 212);
            lblAdelanto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblAdelanto.Name = "label14";
            lblAdelanto.Size = new System.Drawing.Size(132, 25);
            lblAdelanto.TabIndex = 16;
            lblAdelanto.Text = "ADELANTO: ";

            // lblPesosAdelanto
            // 
            Label lblPesosAdelanto = new Label();
            lblPesosAdelanto.AutoSize = true;
            lblPesosAdelanto.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            lblPesosAdelanto.Location = new System.Drawing.Point(160, 212);
            lblPesosAdelanto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblPesosAdelanto.Name = "label13";
            lblPesosAdelanto.Size = new System.Drawing.Size(23, 25);
            lblPesosAdelanto.TabIndex = 17;
            lblPesosAdelanto.Text = "$";

            // txtAdelanto
            // 
            TextBox txtAdelanto = new TextBox();
            txtAdelanto.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            txtAdelanto.Location = new System.Drawing.Point(191, 209);
            txtAdelanto.Name = "txtAdelanto";
            txtAdelanto.Size = new System.Drawing.Size(208, 30);
            txtAdelanto.TabIndex = 3;
            txtAdelanto.Text = "0";
            txtAdelanto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            // lblBono
            // 
            Label lblBono = new Label();
            lblBono.AutoSize = true;
            lblBono.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            lblBono.Location = new System.Drawing.Point(17, 254);
            lblBono.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblBono.Name = "label12";
            lblBono.Size = new System.Drawing.Size(82, 25);
            lblBono.TabIndex = 19;
            lblBono.Text = "BONO: ";

            // lblPesosBono
            // 
            Label lblPesosBono = new Label();
            lblPesosBono.AutoSize = true;
            lblPesosBono.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            lblPesosBono.Location = new System.Drawing.Point(159, 254);
            lblPesosBono.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblPesosBono.Name = "label11";
            lblPesosBono.Size = new System.Drawing.Size(23, 25);
            lblPesosBono.TabIndex = 20;
            lblPesosBono.Text = "$";

            // txtBono
            // 
            TextBox txtBono = new TextBox();
            txtBono.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            txtBono.Location = new System.Drawing.Point(190, 251);
            txtBono.Name = "txtBono";
            txtBono.Size = new System.Drawing.Size(208, 30);
            txtBono.TabIndex = 4;
            txtBono.Text = "0";
            txtBono.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;


        }

        private void Cambio()
        {
            // lblCambio
            // 
            Label lblCambio = new Label();
            lblCambio.AutoSize = true;
            lblCambio.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            lblCambio.Location = new System.Drawing.Point(17, 310);
            lblCambio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblCambio.Name = "label5";
            lblCambio.Size = new System.Drawing.Size(136, 31);
            lblCambio.TabIndex = 13;
            lblCambio.Text = "CAMBIO: ";

            // lblPesosCambio
            // 
            Label lblPesosCambio = new Label();
            lblPesosCambio.AutoSize = true;
            lblPesosCambio.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            lblPesosCambio.Location = new System.Drawing.Point(155, 310);
            lblPesosCambio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblPesosCambio.Name = "label7";
            lblPesosCambio.Size = new System.Drawing.Size(29, 31);
            lblPesosCambio.TabIndex = 14;
            lblPesosCambio.Text = "$";

            // txtCambio
            // 
            TextBox txtCambio = new TextBox();
            txtCambio.BackColor = System.Drawing.Color.LightSteelBlue;
            txtCambio.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            txtCambio.Location = new System.Drawing.Point(189, 307);
            txtCambio.Name = "txtCambio";
            txtCambio.ReadOnly = true;
            txtCambio.Size = new System.Drawing.Size(210, 38);
            txtCambio.TabIndex = 3;
            txtCambio.Text = "0";
            txtCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
        }

        private void PanelAbono()
        {
            var PanelAbono = CreatePanel();
            PanelAbono.Name = "pAbono";
            PanelAbono.Location = new Point(9, LocationY);
            PanelAbono.BackColor = Color.LightSkyBlue;

            var miLabelName = CreateLabelNombre();
            miLabelName.Name = "lblAbono";
            miLabelName.Text = "ABONO :";

            PanelAbono.Controls.Add(miLabelName);

            miLabelName = CreateLabelPesos();
            miLabelName.Name = "lblPesosAbono";
            miLabelName.Text = "$";

            PanelAbono.Controls.Add(miLabelName);

            var miTxtName = CreateTextBox();
            miTxtName.Name = "txtAbono";
            miTxtName.Text = "";
            //miTxtName.TabIndex = Convert.ToInt32(fRow["idforma_pago"]);
            miTxtName.KeyPress += new KeyPressEventHandler(DynamicAbono_KeyPress);
            PanelAbono.Controls.Add(miTxtName);

            PanelAbono.ResumeLayout(false);
            PanelAbono.PerformLayout();

            gbFormaPago.Controls.Add(PanelAbono);

            LocationY = PanelAbono.Size.Height + PanelAbono.Location.Y + 1;

            miTxtName.Focus();
        }

        private Panel CreatePanel()
        {
            Panel miPanel = new Panel();
            miPanel.SuspendLayout();

           /* this.panelTotal.Controls.Add(this.label1);
            this.panelTotal.Controls.Add(this.label6);
            this.panelTotal.Controls.Add(this.txtTotal);*/
            //this.panelTotal.Location = new System.Drawing.Point(9, 19);
           // this.panelTotal.Name = "panelTotal";
            miPanel.Size = new System.Drawing.Size(402, 50);
            //this.panelTotal.TabIndex = 22;

            //miPanel.ResumeLayout(false);
            //miPanel.PerformLayout();
            return miPanel;
        }

        private Label CreateLabelNombre()
        {
            Label miLabel = new Label();
            miLabel.AutoSize = true;
            miLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            miLabel.Location = new System.Drawing.Point(10, 11);
            miLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            miLabel.Size = new System.Drawing.Size(132, 25);
            return miLabel;
        }

        private Label CreateLabelPesos()
        {
            Label miLabel = new Label();
            miLabel.AutoSize = true;
            miLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            miLabel.Location = new System.Drawing.Point(152, 11);
            miLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            miLabel.Size = new System.Drawing.Size(23, 25);
            return miLabel;
        }

        private TextBox CreateTextBox()
        {
            TextBox miTextBox = new TextBox();
            miTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            miTextBox.Location = new System.Drawing.Point(185, 8);
            miTextBox.Size = new System.Drawing.Size(208, 30);
            miTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            return miTextBox;
        }

        private void Dynamic_keyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                try
                {
                    if (ObjControls.Count > 1)
                    {
                        var maxId = ObjControls.Max(d => d.Id);
                        var id = ((TextBox)sender).TabIndex;
                        if (maxId.Equals(id))
                        {
                            DynamicPago();
                        }
                        else
                        {
                            var nameSearch = "";
                            var find = false;
                            while (!find)
                            {
                                id++;
                                var query = ObjControls.Find(d => d.Id.Equals(id));
                                if (query != null)
                                {
                                    nameSearch = query.Nombre;
                                    find = true;
                                }
                            }
                            if (!nameSearch.Equals(""))
                            {
                                var txtFollow = gbFormaPago.Controls.Find(nameSearch, true).First();
                                if (String.IsNullOrEmpty(((TextBox)sender).Text))
                                {
                                    txtFollow.Text = "0";
                                }
                                if (Validacion.ConFormato(Validacion.TipoValidacion.Numeros, (TextBox)sender,
                                    miError, "El valor que ingreso es invalido."))
                                {
                                    DynamicSuma();
                                    txtFollow.Focus();
                                }
                            }
                        }
                    }
                    else
                    {
                        DynamicPago();
                    }
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void DynamicAbono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                try
                {
                    TextBox txtAbn = (TextBox)sender;
                    if (!Validacion.EsVacio(txtAbn, miError, "El campo es requerido."))
                    {
                        if (Validacion.ConFormato(Validacion.TipoValidacion.Numeros, txtAbn,
                                                 miError, "El valor que ingreso es incorrecto."))
                        {
                            txtAbn.Text = UseObject.RemoveSeparatorMil(txtAbn.Text).ToString();
                            //txtAbn.Text = UseObject.InsertSeparatorMil(txtAbn.Text);
                            if (Convert.ToInt32(txtAbn.Text) > 0 &&
                                Convert.ToDouble(txtAbn.Text) <= UseObject.RemoveSeparatorMil(txtTotal.Text))
                            {
                                ValorAbono = txtAbn.Text;
                                txtAbn.Text = UseObject.InsertSeparatorMil(txtAbn.Text);
                                var control = ObjControls.Find(d => d.Id.Equals(ObjControls.Min(d2 => d2.Id)));
                                var c = gbFormaPago.Controls.Find(control.Nombre, true);
                                var j = c.First();
                                j.Focus();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void DynamicSuma()
        {
            var totalPago = 0;
            foreach (var dato in ObjControls)
            {
                var control = gbFormaPago.Controls.Find(dato.Nombre, true).First();
                totalPago += Convert.ToInt32(control.Text);
            }
            var vPago = txtTotal.Text;
            if (Abono)
            {
                vPago = ValorAbono;
            }
            txtCambio.Text = UseObject.InsertSeparatorMil(
                    (totalPago - Convert.ToInt32(UseObject.RemoveSeparatorMil(vPago))).ToString());
        }

        private void DynamicPago()
        {
            var totalPago = 0;
            var Formas = new List<DTO.Clases.FormaPago>();
            foreach (var dato in ObjControls)
            {
                var control = gbFormaPago.Controls.Find(dato.Nombre, true).First();
                Formas.Add(new FormaPago
                               {
                                   IdFormaPago = control.TabIndex,
                                   NombreFormaPago = control.Name,
                                   Valor = Convert.ToInt32(control.Text)
                               });
                totalPago += Convert.ToInt32(control.Text);
            }
            var vTotalPago = txtTotal.Text;
            if(Abono)
            {
                vTotalPago = ValorAbono;
            }
            if (totalPago >= Convert.ToInt32(UseObject.RemoveSeparatorMil(vTotalPago)))
            {
                txtCambio.Text = UseObject.InsertSeparatorMil(
                    (totalPago - Convert.ToInt32(UseObject.RemoveSeparatorMil(vTotalPago))).ToString());
                DialogResult rta = MessageBox.Show("¿Está seguro(a) de querer cerrar la venta?",
                                    "Cerrar Venta", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (rta == DialogResult.Yes)
                {
                    if (Abono)
                    {
                        CompletaEventos.CapEvenAbonoFact(Formas);
                    }
                    else
                    {
                        CompletaEventos.CapturaEvento(Formas);
                    }
                    this.Close();
                }
            }
            else
            {
                OptionPane.MessageInformation("Los valores ingresados debe superar al total.");
            }
        }

        /*
        private void FrmCancelarVenta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F6)
            {
                txtEfectivo_Validating(txtEfectivo, new CancelEventArgs(false));
                txtCheque_Validating(txtCheque, new CancelEventArgs(false));
                txtTarjeta_Validating(txtTarjeta, new CancelEventArgs(false));
                txtAdelanto_Validating(txtAdelanto, new CancelEventArgs(false));
                txtBono_Validating(txtBono, new CancelEventArgs(false));
                if (Venta)
                {
                    if (!Abono)
                    {
                        if (Efectivo && Cheque && Tarjeta && Adelanto && Bono)
                        {
                            if ((UseObject.RemoveSeparatorMil(txtAdelanto.Text) +
                                 UseObject.RemoveSeparatorMil(txtBono.Text)) <=
                                 UseObject.RemoveSeparatorMil(txtTotal.Text))
                            {
                                var suma = UseObject.RemoveSeparatorMil(txtEfectivo.Text) +
                                           UseObject.RemoveSeparatorMil(txtCheque.Text) +
                                           UseObject.RemoveSeparatorMil(txtTarjeta.Text) +
                                           UseObject.RemoveSeparatorMil(txtAdelanto.Text) +
                                           UseObject.RemoveSeparatorMil(txtBono.Text);
                                if (suma >= UseObject.RemoveSeparatorMil(txtTotal.Text))
                                {
                                    txtCambio.Text = UseObject.InsertSeparatorMil
                                        (
                                            ((UseObject.RemoveSeparatorMil(txtEfectivo.Text) +
                                             UseObject.RemoveSeparatorMil(txtCheque.Text) +
                                             UseObject.RemoveSeparatorMil(txtTarjeta.Text)) +
                                             UseObject.RemoveSeparatorMil(txtAdelanto.Text) +
                                             UseObject.RemoveSeparatorMil(txtBono.Text) -
                                             UseObject.RemoveSeparatorMil(txtTotal.Text))
                                             .ToString()
                                        );
                                    DialogResult rta = MessageBox.Show("¿Está seguro(a) de querer cerrar la venta?",
                                    "Cerrar Venta", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                    if (rta == DialogResult.Yes)
                                    {
                                        var formas = FormasDePago();
                                        CompletaEventos.CapturaEvento(formas);
                                        Venta = false;
                                        formas = null;
                                        this.Close();
                                    }
                                }
                                else
                                {
                                    OptionPane.MessageInformation("El valor ingresado debe ser superior " +
                                        "al de la venta.");
                                }
                            }
                            else
                            {
                                OptionPane.MessageInformation("La suma de los saldos del cliente no debe superar el total.");
                            }


                        }
                        /*DialogResult rta = MessageBox.Show("¿Está seguro(a) de querer cerrar la venta?",
                                "Cerrar Venta", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (rta == DialogResult.Yes)
                        {
                            
                        }//
                    }
                    else
                    {
                        DialogResult rta = MessageBox.Show("¿Está seguro(a) de querer realizar el abono?",
                                "Realizar Abono", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (rta == DialogResult.Yes)
                        {
                            if (Efectivo && Cheque && Tarjeta)
                            {
                                var suma = UseObject.RemoveSeparatorMil(txtEfectivo.Text) +
                                           UseObject.RemoveSeparatorMil(txtCheque.Text) +
                                           UseObject.RemoveSeparatorMil(txtTarjeta.Text);

                                var formas = FormasDePago();
                                
                                    try
                                    {
                                        foreach (FormaPago pago in formas)
                                        {
                                            if (pago.Valor != 0)
                                            {
                                                pago.NumeroFactura = NumeroFactura;
                                                pago.Fecha = DateTime.Now;
                                                miBussinesPago.IngresarPagoAFactura(pago, true);
                                                
                                            }
                                        }
                                        OptionPane.MessageInformation("El abono se realizó con éxito.");
                                    }
                                    catch (Exception ex)
                                    {
                                        OptionPane.MessageError(ex.Message);
                                    }
                            }
                        }
                    }
                }
            }
            else
            {
                if (e.KeyData == Keys.Escape)
                {
                    this.Close();
                    /*DialogResult rta = MessageBox.Show("¿Está seguro(a) de querer cerrar la venta?",
                        "Cerrar Venta", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (rta == DialogResult.Yes)
                    {
                        OptionPane.MessageSuccess("La venta se realizó con éxito!");
                        CompletaEventos.CapturaEvento(true);
                        this.Close();
                    }//
                }
            }
        }

        private void FrmCancelarVenta_FormClosing(object sender, FormClosingEventArgs e)
        {
            CompletaEventos.CapturaEvento(false);
        }

        private void txtEfectivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                txtCheque.Focus();
            }
        }

        private void txtEfectivo_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtEfectivo.Text))
            {
                txtEfectivo.Text = txtEfectivo.Text.Replace(".", "");
                if (validacion.ValidarNumeroInt(txtEfectivo.Text))
                {
                    txtEfectivo.Text = UseObject.InsertSeparatorMil(txtEfectivo.Text);
                    Efectivo = true;
                    if (!txtEfectivo.Text.Equals("0"))
                    {
                        txtCambio.Text = UseObject.InsertSeparatorMil
                                (
                                    (UseObject.RemoveSeparatorMil(txtEfectivo.Text) -
                                        UseObject.RemoveSeparatorMil(txtTotal.Text))
                                        .ToString()
                                );
                    }
                }
                else
                {
                    OptionPane.MessageError("El valor del Efectivo es incorrecto.");
                    Efectivo = false;
                }
            }
            else
            {
                txtEfectivo.Text = "0";
                Efectivo = true;
            }
        }

        private void txtCheque_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                txtTarjeta.Focus();
            }
        }

        private void txtCheque_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtCheque.Text))
            {
                txtCheque.Text = txtCheque.Text.Replace(".", "");
                if (validacion.ValidarNumeroInt(txtCheque.Text))
                {
                    txtCheque.Text = UseObject.InsertSeparatorMil(txtCheque.Text);
                    Cheque = true;
                    if (!txtCheque.Text.Equals("0"))
                    {
                        txtCambio.Text = UseObject.InsertSeparatorMil
                                (
                                    ((UseObject.RemoveSeparatorMil(txtEfectivo.Text) +
                                        UseObject.RemoveSeparatorMil(txtCheque.Text)) -
                                        UseObject.RemoveSeparatorMil(txtTotal.Text))
                                        .ToString()
                                );
                    }
                }
                else
                {
                    OptionPane.MessageError("El valor del Cheque es incorrecto.");
                    Cheque = false;
                }
            }
            else
            {
                txtCheque.Text = "0";
                Cheque = true;
            }
        }

        private void txtTarjeta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                txtAdelanto.Focus();
                //FrmCancelarVenta_KeyDown(this, new KeyEventArgs(Keys.F6));
            }
        }

        private void txtTarjeta_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtTarjeta.Text))
            {
                txtTarjeta.Text = txtTarjeta.Text.Replace(".", "");
                if (validacion.ValidarNumeroInt(txtTarjeta.Text))
                {
                    txtTarjeta.Text = UseObject.InsertSeparatorMil(txtTarjeta.Text);
                    Tarjeta = true;
                    if (!txtTarjeta.Text.Equals("0"))
                    {
                        txtCambio.Text = UseObject.InsertSeparatorMil
                                (
                                    ((UseObject.RemoveSeparatorMil(txtEfectivo.Text) +
                                        UseObject.RemoveSeparatorMil(txtCheque.Text) +
                                        UseObject.RemoveSeparatorMil(txtTarjeta.Text)) -
                                        UseObject.RemoveSeparatorMil(txtTotal.Text))
                                        .ToString()
                                );
                    }
                }
                else
                {
                    OptionPane.MessageError("El valor de la Tarjeta es incorrecto.");
                    Tarjeta = false;
                }
            }
            else
            {
                txtTarjeta.Text = "0";
                Tarjeta = true;
            }
        }

        private void txtAdelanto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                txtBono.Focus();
            }
        }

        private void txtAdelanto_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtAdelanto.Text))
            {
                txtAdelanto.Text = txtAdelanto.Text.Replace(".", "");
                if (validacion.ValidarNumeroInt(txtAdelanto.Text))
                {
                    if (!txtAdelantoC.Text.Equals("0"))
                    {
                        if (UseObject.RemoveSeparatorMil(txtAdelantoC.Text) >=
                            UseObject.RemoveSeparatorMil(txtAdelanto.Text))
                        {
                            txtAdelanto.Text = UseObject.InsertSeparatorMil(txtAdelanto.Text);
                            miError.SetError(txtAdelanto, null);
                            Adelanto = true;
                            if (!txtAdelanto.Text.Equals("0"))
                            {
                                txtCambio.Text = UseObject.InsertSeparatorMil
                                        (
                                            ((UseObject.RemoveSeparatorMil(txtEfectivo.Text) +
                                                UseObject.RemoveSeparatorMil(txtCheque.Text) +
                                                UseObject.RemoveSeparatorMil(txtTarjeta.Text) +
                                                UseObject.RemoveSeparatorMil(txtAdelanto.Text)) -
                                                UseObject.RemoveSeparatorMil(txtTotal.Text))
                                                .ToString()
                                        );
                            }
                        }
                        else
                        {
                            Adelanto = false;
                            OptionPane.MessageInformation("El pago del Adelanto no puede superar el Adelanto del Cliente.");
                            miError.SetError(txtAdelanto, "El pago del Adelanto no puede superar el Adelanto del Cliente.");
                            txtAdelanto.Focus();
                        }
                    }
                    else
                    {
                        Adelanto = true;
                    }
                }
                else
                {
                    OptionPane.MessageError("El valor del Adelanto es incorrecto.");
                    Adelanto = false;
                }
            }
            else
            {
                txtAdelanto.Text = "0";
                Adelanto = true;
            }
        }

        private void txtBono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                //txtCambio.Focus();
                FrmCancelarVenta_KeyDown(this, new KeyEventArgs(Keys.F6));
            }
        }

        private void txtBono_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtBono.Text))
            {
                txtBono.Text = txtBono.Text.Replace(".", "");
                if (validacion.ValidarNumeroInt(txtBono.Text))
                {
                    if (!txtBono.Text.Equals("0"))
                    {
                        if (UseObject.RemoveSeparatorMil(txtBonoC.Text) >=
                            UseObject.RemoveSeparatorMil(txtBono.Text))
                        {
                            txtBono.Text = UseObject.InsertSeparatorMil(txtBono.Text);
                            miError.SetError(txtBono, null);
                            Bono = true;
                            if (!txtBono.Text.Equals("0"))
                            {
                                txtCambio.Text = UseObject.InsertSeparatorMil
                                        (
                                            ((UseObject.RemoveSeparatorMil(txtEfectivo.Text) +
                                                UseObject.RemoveSeparatorMil(txtCheque.Text) +
                                                UseObject.RemoveSeparatorMil(txtTarjeta.Text) +
                                                UseObject.RemoveSeparatorMil(txtAdelanto.Text) +
                                                UseObject.RemoveSeparatorMil(txtBono.Text)) -
                                                UseObject.RemoveSeparatorMil(txtTotal.Text))
                                                .ToString()
                                        );
                            }
                        }
                        else
                        {
                            Bono = false;
                            OptionPane.MessageInformation("El pago del Bono no puede superar el Bono del Cliente.");
                            miError.SetError(txtBono, "El pago del Bono no puede superar el Bono del Cliente.");
                            txtBono.Focus();
                        }
                    }
                    else
                    {
                        Bono = true;
                    }
                }
                else
                {
                    OptionPane.MessageError("El valor del Bono es incorrecto.");
                    Bono = false;
                }
            }
            else
            {
                txtBono.Text = "0";
                Bono = true;
            }
        }

        private List<DTO.Clases.FormaPago> FormasDePago()
        {
            var Formas = new List<DTO.Clases.FormaPago>();
            Formas.Add(new DTO.Clases.FormaPago
            {
                IdFormaPago = 1,
                Valor = Convert.ToInt32
                (UseObject.RemoveSeparatorMil(txtEfectivo.Text))
            });
            Formas.Add(new DTO.Clases.FormaPago
            {
                IdFormaPago = 2,
                Valor = Convert.ToInt32
                (UseObject.RemoveSeparatorMil(txtCheque.Text))
            });
            Formas.Add(new DTO.Clases.FormaPago
            {
                IdFormaPago = 3,
                Valor = Convert.ToInt32
                (UseObject.RemoveSeparatorMil(txtTarjeta.Text))
            });
            Formas.Add(new DTO.Clases.FormaPago
            {
                IdFormaPago = 5,
                Valor = Convert.ToInt32
                (UseObject.RemoveSeparatorMil(txtAdelanto.Text))
            });
            Formas.Add(new DTO.Clases.FormaPago
            {
                IdFormaPago = 6,
                Valor = Convert.ToInt32
                (UseObject.RemoveSeparatorMil(txtBono.Text))
            });
            return Formas;
        }
        */
    }
}