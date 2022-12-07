using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataAccessLayer.Repository;
using DataAccessLayer.Models;
using CustomControl;
using DTO;
using Utilities;
using BussinesLayer.Clases;

namespace FormulariosSistema
{
    public partial class FrmPayment : Form
    {
        private string CodeEfectivo = "10";

        private string CodeTransferencia = "31";

        private string CodeTarjeta = "49";

        private int CodeTranserEvent = 65412597;


        private ErrorProvider Error { set; get; }

        public int IDDE { set; get; }

        public double Total { set; get; }

        public int IdUser { set; get; }

        public int IdCaja { set; get; }

        private ElectronicPayment EPayment { set; get; }

        public ElectronicDocument Document { set; get; }


        private RepositoryModel repositoryModel;

        public FrmPayment()
        {
            InitializeComponent();
            this.Error = new ErrorProvider();
            this.EPayment = new ElectronicPayment();
            
            try
            {
                this.repositoryModel = new RepositoryModel();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void FrmPayment_Load(object sender, EventArgs e)
        {
            this.EPayment.Total = this.Total;
            this.txtTotal.Text = UseObject.InsertSeparatorMil(this.Total.ToString().Replace('.', ','));
        }
        
        private void FrmPayment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Escape)) //&& this.EPayment.Payments.Count > 0)
            {
                this.Close();
            }
        }

        private void txtEfectivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                if (this.Validate(this.txtEfectivo))
                {
                    this.Error.SetError(this.txtEfectivo, null);
                    this.CalculateChange();
                    //this.AddPayment(this.CodeEfectivo, Convert.ToDouble(this.txtEfectivo.Text));
                    this.txtTransferencia.Focus();
                    this.txtTransferencia.SelectAll();
                }
                else
                {
                    this.Error.SetError(this.txtEfectivo, "Valor incorrecto.");
                }
            }
        }

        private void txtTransferencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                if (this.Valide(this.txtTransferencia.Text))
                {
                    this.Error.SetError(this.txtTransferencia, null);
                    this.CalculateChange();
                    //this.AddPayment(this.CodeTransferencia, Convert.ToDouble(this.txtTransferencia.Text));
                    //this.LoadPayment();
                    this.txtTarjeta.Focus();
                    this.txtTarjeta.SelectAll();
                }
                else
                {
                    this.Error.SetError(this.txtTransferencia, "Valor incorrecto.");
                }
            }
        }

        private void txtTarjeta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                if (this.Valide(this.txtTarjeta.Text))
                {
                    this.Error.SetError(this.txtTarjeta, null);
                    this.CalculateChange();
                    this.LoadPayment();
                    //this.AddPayment(this.CodeTarjeta, Convert.ToDouble(this.txtTarjeta.Text));
                    //this.txtTransferencia.Focus();
                }
                else
                {
                    this.Error.SetError(this.txtTarjeta, "Valor incorrecto.");
                }
            }
        }



        private bool Valide(string data)
        {
            bool valide = true;
            if (String.IsNullOrEmpty(data))
            {
                valide = false;
            }
            if (!Validacion.ValidateDouble(data))
            {
                valide = false;
            }
            return valide;
        }

        private bool Validate(TextBox textBox)
        {
            if (String.IsNullOrEmpty(textBox.Text))
            {
                textBox.Text = "0";
                return true;
            }
            else
            {
                return Validacion.ValidateDouble(textBox.Text);
            }
        }

        private Payment GetPayment(string codePay, double pay, double transfer, double card, double total)
        {
            Payment p = new Payment();
            if (pay > 0)
            {
                p.Pago = pay;
                p.Code = codePay;
                if (codePay.Equals(this.CodeTransferencia))
                {
                    if (pay <= total)
                    {
                        p.Valor = pay;
                    }
                    else
                    {
                        p.Valor = total;
                    }
                }
                else
                {
                    if (codePay.Equals(this.CodeTarjeta))
                    {
                        if (pay <= total)
                        {
                            p.Valor = pay;
                        }
                        else
                        {
                            p.Valor = total;
                        }
                    }
                    else
                    {
                        if (codePay.Equals(this.CodeEfectivo))
                        {
                            if (pay <= Math.Round(total - transfer - card, 2))
                            {
                                p.Valor = pay;
                            }
                            else
                            {
                                p.Valor = Math.Round(total - transfer - card, 2);
                            }
                        }
                    }
                }
            }
            return p;
        }

        private void LoadPayment()
        {
            try
            {
                if (Convert.ToDouble(this.txtTransferencia.Text.Replace('.', ',')) > 0 ||
                    Convert.ToDouble(this.txtEfectivo.Text.Replace('.', ',')) > 0 ||
                    Convert.ToDouble(this.txtTarjeta.Text.Replace('.', ',')) > 0)
                {
                    //var payment = new ElectronicPayment();
                    this.EPayment = new ElectronicPayment();
                    this.EPayment.IdDE = this.IDDE;
                    this.EPayment.IdUser = this.IdUser;
                    this.EPayment.IdCaja = this.IdCaja;
                    this.EPayment.Total = this.Total;

                    if (Convert.ToDouble(this.txtTransferencia.Text.Replace('.', ',')) > 0)
                    {
                        this.EPayment.Payments.Add(
                            GetPayment(this.CodeTransferencia,
                                       Convert.ToDouble(this.txtTransferencia.Text.Replace('.', ',')),
                                       Convert.ToDouble(this.txtTransferencia.Text.Replace('.', ',')),
                                       Convert.ToDouble(this.txtTransferencia.Text.Replace('.', ',')),
                                       this.EPayment.Total)
                            );
                    }
                    if (Convert.ToDouble(this.txtTarjeta.Text.Replace('.', ',')) > 0)
                    {
                        this.EPayment.Payments.Add(
                            GetPayment(this.CodeTarjeta,
                                       Convert.ToDouble(this.txtTarjeta.Text.Replace('.', ',')),
                                       Convert.ToDouble(this.txtTarjeta.Text.Replace('.', ',')),
                                       Convert.ToDouble(this.txtTarjeta.Text.Replace('.', ',')),
                                       this.EPayment.Total)
                            );
                    }
                    if (Convert.ToDouble(this.txtEfectivo.Text) > 0)
                    {
                        if (Convert.ToDouble(this.txtTransferencia.Text) + Convert.ToDouble(this.txtTarjeta.Text) 
                            < this.EPayment.Total)
                        {
                            this.EPayment.Payments.Add(
                                GetPayment(this.CodeEfectivo,
                                           Convert.ToDouble(this.txtEfectivo.Text.Replace('.', ',')),
                                           Convert.ToDouble(this.txtTransferencia.Text.Replace('.', ',')),
                                           Convert.ToDouble(this.txtTarjeta.Text.Replace('.', ',')),
                                           this.EPayment.Total)
                                );
                        }
                    }




                    /*if (Convert.ToDouble(this.txtTransferencia.Text) < this.EPayment.Total)
                    {
                        if (Convert.ToDouble(this.txtEfectivo.Text) > 0)
                        {
                            this.EPayment.Payments.Add(
                                GetPayment(this.CodeEfectivo,
                                           Convert.ToDouble(this.txtEfectivo.Text.Replace('.', ',')),
                                           Convert.ToDouble(this.txtTransferencia.Text.Replace('.', ',')),
                                           Convert.ToDouble(this.txtTarjeta.Text.Replace('.', ',')),
                                           this.EPayment.Total)
                                );
                        }
                    }*/

                    /*
                    //TEST
                    foreach (var p in this.EPayment.Payments)
                    {
                        Console.WriteLine(p.Code + ": " + p.Valor + " " + p.Pago);
                    }

                    if (this.EPayment.Payments.Sum(s => s.Valor) > this.EPayment.Total)
                    {
                        this.txtCambio.Text = UseObject.InsertSeparatorMil((this.EPayment.Payments.Sum(s => s.Valor) - this.EPayment.Total).ToString());
                    }
                    //END TEST */

                    
                    if (this.EPayment.Payments.Sum(s => s.Valor) > 0)
                    {
                        this.Error.SetError(this.txtTotal, null);
                        if (this.EPayment.Payments.Sum(s => s.Valor) > this.EPayment.Total)
                        {
                            this.txtCambio.Text = UseObject.InsertSeparatorMil((this.EPayment.Payments.Sum(s => s.Valor) - this.EPayment.Total).ToString());
                        }
                        DialogResult rta = MessageBox.Show("¿Desea realizar el pago?", "Factura electronica",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (rta.Equals(DialogResult.Yes))
                        {
                            this.EPayment.Date = DateTime.Now;
                            this.repositoryModel.AddPayment(this.EPayment);
                            CompletaEventos.CapturaEvento(new ObjectAbstract { Id = this.CodeTranserEvent });
                            OptionPane.MessageInformation("El pago se registró con éxito");
                            this.cpPayment.Enabled = false;
                            this.lblMessenger.Visible = true;

                            // print ticket medios de pagos
                            if (this.EPayment.Payments.Where
                                (p => p.Code.Equals(this.CodeTarjeta) || p.Code.Equals(this.CodeTransferencia)).Count() > 0)
                            {
                                //this.Document.Fecha = this.EPayment.Date;
                                PrintInvoice p = new PrintInvoice();
                                p.PrintPayments(this.Document, this.EPayment);
                            }
                        }
                    }
                    else
                    {
                        this.Error.SetError(this.txtTotal, "Los pagos deben ser mayores a cero.");
                    }
                    
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private Payment GetPayment_(string codePay, double pay, double transfer, double total)
        {
            Payment p = new Payment();
            if (pay > 0)
            {
                p.Pago = pay;
                p.Code = codePay;
                if (codePay.Equals(this.CodeTransferencia))
                {
                    if (pay <= total)
                    {
                        p.Valor = pay;
                    }
                    else
                    {
                        p.Valor = total;
                    }
                    /*if (total < pay)
                    {
                        p.Valor = total;
                    }
                    else
                    {
                        p.Valor = pay;
                    }*/
                }
                else
                {
                    if (codePay.Equals(this.CodeEfectivo))
                    {
                        if (pay <= (total - transfer))
                        {
                            p.Valor = pay;
                        }
                        else
                        {
                            p.Valor = total - transfer;
                        }
                        /*if (transfer > 0)
                        {
                            if (total > transfer)
                            {
                                p.Valor = total - transfer;
                            }
                        }*/
                    }
                }
            }
            return p;
        }

        private void LoadPayment_()
        {
            try
            {
                if (Convert.ToDouble(this.txtTransferencia.Text.Replace('.', ',')) > 0 ||
                    Convert.ToDouble(this.txtEfectivo.Text.Replace('.', ',')) > 0)
                {
                    //var payment = new ElectronicPayment();
                    this.EPayment = new ElectronicPayment();
                    this.EPayment.IdDE = this.IDDE;
                    this.EPayment.IdUser = this.IdUser;
                    this.EPayment.IdCaja = this.IdCaja;
                    this.EPayment.Total = this.Total;

                    if (Convert.ToDouble(this.txtTransferencia.Text.Replace('.', ',')) > 0)
                    {
                        /*this.EPayment.Payments.Add(
                            GetPayment(this.CodeTransferencia,
                                       Convert.ToDouble(this.txtTransferencia.Text.Replace('.', ',')),
                                       Convert.ToDouble(this.txtTransferencia.Text.Replace('.', ',')),
                                       this.EPayment.Total)
                            );*/
                    }
                    if (Convert.ToDouble(this.txtTransferencia.Text) < this.EPayment.Total)
                    {
                        if (Convert.ToDouble(this.txtEfectivo.Text) > 0)
                        {
                            /*this.EPayment.Payments.Add(
                                GetPayment(this.CodeEfectivo,
                                           Convert.ToDouble(this.txtEfectivo.Text.Replace('.', ',')),
                                           Convert.ToDouble(this.txtTransferencia.Text.Replace('.', ',')),
                                           this.EPayment.Total)
                                );*/
                        }
                    }

                    /**
                    //TEST
                    foreach (var p in this.EPayment.Payments)
                    {
                        Console.WriteLine(p.Code + ": " + p.Valor + " " + p.Pago);
                    }

                    if (this.EPayment.Payments.Sum(s => s.Valor) > this.EPayment.Total)
                    {
                        this.txtCambio.Text = UseObject.InsertSeparatorMil((this.EPayment.Payments.Sum(s => s.Valor) - this.EPayment.Total).ToString());
                    }
                    //END TEST */

                    /*
                    if (Convert.ToDouble(this.txtEfectivo.Text) > 0)
                    {
                        this.EPayment.Payments.Add(new Payment
                        {
                            Code = this.CodeEfectivo,
                            Valor = Convert.ToDouble(this.txtEfectivo.Text)
                        });
                    }


                    if (Convert.ToDouble(this.txtTransferencia.Text) > 0)
                    {
                        this.EPayment.Payments.Add(new Payment
                        {
                            Code = this.CodeTransferencia,
                            Valor = Convert.ToDouble(this.txtTransferencia.Text)
                        });
                    }
                    */

                    
                    if (this.EPayment.Payments.Sum(s => s.Valor) > 0)
                    {
                        this.Error.SetError(this.txtTotal, null);
                        if (this.EPayment.Payments.Sum(s => s.Valor) > this.EPayment.Total)
                        {
                            this.txtCambio.Text = UseObject.InsertSeparatorMil((this.EPayment.Payments.Sum(s => s.Valor) - this.EPayment.Total).ToString());
                        }
                        DialogResult rta = MessageBox.Show("¿Desea realizar el pago?", "Factura electronica",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (rta.Equals(DialogResult.Yes))
                        {
                            this.EPayment.Date = DateTime.Now;
                            this.repositoryModel.AddPayment(this.EPayment);
                            CompletaEventos.CapturaEvento(new ObjectAbstract { Id = this.CodeTranserEvent });
                            OptionPane.MessageInformation("El pago se registró con éxito");
                            this.cpPayment.Enabled = false;
                            this.lblMessenger.Visible = true;
                        }
                    }
                    else
                    {
                        this.Error.SetError(this.txtTotal, "Los pagos deben ser mayores a cero.");
                    }
                    
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        /*
        private void AddPayment(string code, double valor)
        {
            this.EPayment.Payments.Add(new Payment
            {
                Code = code,
                Valor = valor
            });
            if (this.EPayment.Payments.Sum(s => s.Valor) > this.EPayment.Total)
            {
                this.txtCambio.Text = UseObject.InsertSeparatorMil((this.EPayment.Payments.Sum(s => s.Valor) - this.EPayment.Total).ToString());
            }
        }
        */

        private void CalculateChange()
        {
            this.EPayment.Change =
                Convert.ToDouble(this.txtEfectivo.Text.Replace('.', ',')) +
                Convert.ToDouble(this.txtTransferencia.Text.Replace('.', ',')) +
                Convert.ToDouble(this.txtTarjeta.Text.Replace('.', ','));
            if (this.EPayment.Change > this.EPayment.Total)
            {
                this.EPayment.Change = Math.Round(this.EPayment.Change - this.EPayment.Total, 2);
            }
            else
            {
                this.EPayment.Change = 0;
            }
            this.txtCambio.Text = UseObject.InsertSeparatorMil(this.EPayment.Change.ToString().Replace('.', ','));
        }
        
    }
}