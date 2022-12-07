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

namespace Aplicacion.Administracion.Caja
{
    public partial class FrCierreCaja : Form
    {
        private ErrorProvider miError;

        private bool CierreMatch;

        private bool ChequeMatch;

        private bool TarjetaMatch;

        private bool TransaccionMatch;

        private DataTable Registros { set; get; }

        private BussinesEmpresa miBussinesEmpresa;

        private BussinesCierre miBussinesCierre;

        private BussinesApertura miBussinesApertura;

        private BussinesCaja miBussinesCaja;

        private BussinesTurno miBussinesTurno;

        public FrCierreCaja()
        {
            InitializeComponent();
            miError = new ErrorProvider();
            CierreMatch = false;
            miBussinesEmpresa = new BussinesEmpresa();
            miBussinesCierre = new BussinesCierre();
            miBussinesApertura = new BussinesApertura();
            miBussinesCaja = new BussinesCaja();
            miBussinesTurno = new BussinesTurno();
        }

        private void FrCierreCaja_Load(object sender, EventArgs e)
        {
            try
            {
                lblNoCaja.Text = miBussinesCaja.CajaId(
                    Convert.ToInt32(AppConfiguracion.ValorSeccion("id_caja"))).Numero.ToString();
                lblNoTurno.Text = miBussinesTurno.TurnoId(
                    Convert.ToInt32(AppConfiguracion.ValorSeccion("idturno"))).Numero.ToString();
                this.Registros = miBussinesApertura.RegistrosApertura(Convert.ToInt32(AppConfiguracion.ValorSeccion("id_caja")));
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void FrCierreCaja_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.F2))
            {
                this.btnGuardar_Click(this.btnGuardar, new EventArgs());
            }
            else
            {
                if (e.KeyData.Equals(Keys.Escape))
                {
                    this.Close();
                }
            }
        }

        private void txtEfectivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                txtTransaccion.Focus();
            }
        }

        private void txtCierre_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtEfectivo.Text))
            {
                if (Validacion.ConFormato
                    (Validacion.TipoValidacion.Numeros, txtEfectivo, miError, "El valor del cierre tiene formato incorrecto."))
                {
                    CierreMatch = true;
                }
                else
                {
                    CierreMatch = false;
                }
            }
            else
            {
                txtEfectivo.Text = "0";
                CierreMatch = true;
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
                if (Validacion.ConFormato
                    (Validacion.TipoValidacion.Numeros, txtCheque, miError, "El valor del cierre tiene formato incorrecto."))
                {
                    ChequeMatch = true;
                }
                else
                {
                    ChequeMatch = false;
                }
            }
            else
            {
                txtCheque.Text = "0";
                ChequeMatch = true;
            }
        }

        private void txtTarjeta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                txtTransaccion.Focus();
            }
        }

        private void txtTarjeta_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtTarjeta.Text))
            {
                if (Validacion.ConFormato
                    (Validacion.TipoValidacion.Numeros, txtTarjeta, miError, "El valor del cierre tiene formato incorrecto."))
                {
                    TarjetaMatch = true;
                }
                else
                {
                    TarjetaMatch = false;
                }
            }
            else
            {
                txtTarjeta.Text = "0";
                TarjetaMatch = true;
            }
        }

        private void txtTransaccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                btnGuardar_Click(this.btnGuardar, new EventArgs());
            }
        }

        private void txtTransaccion_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtTransaccion.Text))
            {
                if (Validacion.ConFormato
                    (Validacion.TipoValidacion.Numeros, txtTransaccion, miError, "El valor del cierre tiene formato incorrecto."))
                {
                    TransaccionMatch = true;
                }
                else
                {
                    TransaccionMatch = false;
                }
            }
            else
            {
                txtTransaccion.Text = "0";
                TransaccionMatch = true;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try 
            {
                this.txtCierre_Validating(this.txtEfectivo, null);
                this.txtCheque_Validating(this.txtCheque, null);
                this.txtTarjeta_Validating(this.txtTarjeta, null);
                this.txtTransaccion_Validating(this.txtTransaccion, null);
                if (CierreMatch && ChequeMatch && TarjetaMatch && TransaccionMatch)
                {
                    // PARA MEJORAR POR LAS FORMAS DE PAGO, DINAMICAS...
                    if (!this.Registros.Rows.Count.Equals(0))  //if (!String.IsNullOrEmpty(AppConfiguracion.ValorSeccion("id_apertura")))
                    {
                        DialogResult rta = MessageBox.Show("¿Está seguro(a) de realizar el cierre de caja?", "Cierre de Caja",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (rta.Equals(DialogResult.Yes))
                        {
                            var cierre = new Cierre();
                            cierre.Fecha = dtpFecha.Value;
                            //cierre.IdApertura = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_apertura"));
                            cierre.IdApertura = miBussinesApertura.RegistroApertura(Convert.ToInt32(AppConfiguracion.ValorSeccion("id_caja"))).Valor;
                            cierre.Caja.Id = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_caja"));
                            cierre.Turno.Id = Convert.ToInt32(AppConfiguracion.ValorSeccion("idturno"));
                            cierre.Usuario.Id = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_user"));
                            cierre.Valores.Add(new FormaPago
                            {
                                IdFormaPago = 1,
                                NombreFormaPago = "Efectivo",
                                Valor = Convert.ToInt32(txtEfectivo.Text)
                            });
                            cierre.Valores.Add(new FormaPago
                            {
                                IdFormaPago = 2,
                                NombreFormaPago = "Cheque",
                                Valor = Convert.ToInt32(txtCheque.Text)
                            });
                            cierre.Valores.Add(new FormaPago
                            {
                                IdFormaPago = 3,
                                NombreFormaPago = "Tarjeta",
                                Valor = Convert.ToInt32(txtTarjeta.Text)
                            });
                            cierre.Valores.Add(new FormaPago
                            {
                                IdFormaPago = 4,
                                NombreFormaPago = "Transacción",
                                Valor = Convert.ToInt32(txtTransaccion.Text)
                            });
                            miBussinesCierre.Ingresar(cierre);
                            miBussinesApertura.EliminarRegistroApertura(cierre.Caja.Id);
                            //AppConfiguracion.SaveConfiguration("id_apertura", "");
                            //OptionPane.MessageInformation("El cierre de caja se realizó con éxito.");
                            rta = MessageBox.Show("El cierre de caja se realizó con éxito.\n¿Desea imprimir el comprobante?", "Cierre de caja",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (rta.Equals(DialogResult.Yes))
                            {
                                Print(cierre);
                            }

                            rta = MessageBox.Show("¿Desea imprimir el movimiento de caja?", "Cierre de caja",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (rta.Equals(DialogResult.Yes))
                            {
                                var frmMovCaja = new FrmConsultaCaja();
                                frmMovCaja.PrintMovimientoCaja(cierre.IdApertura);
                            }
                            this.Close();
                        }
                    }
                    else
                    {
                        OptionPane.MessageError("La estación no presenta apertura de caja.");
                    }
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void Print(Cierre cierre)
        {
            try
            {
                DataRow empresaRow = miBussinesEmpresa.PrintEmpresa().
                        Tables[0].AsEnumerable().First();

                Ticket ticket = new Ticket();
                ticket.UseItem = false;

                ticket.AddHeaderLine(empresaRow["Nombre"].ToString().ToUpper());
                ticket.AddHeaderLine(empresaRow["Juridico"].ToString());
                ticket.AddHeaderLine("NIT " + UseObject.InsertSeparatorMilMasDigito(empresaRow["Nit"].ToString()));
                ticket.AddHeaderLine("Régimen: " + empresaRow["Regimen"].ToString());
                ticket.AddHeaderLine(empresaRow["Direccion"].ToString());
                ticket.AddHeaderLine("");

                ticket.AddHeaderLine("CIERRE DE CAJA");
                ticket.AddHeaderLine("Fecha : " + cierre.Fecha.ToShortDateString());
                ticket.AddHeaderLine("Hora  : " + cierre.Fecha.ToShortTimeString());
                ticket.AddHeaderLine("Caja  : " + miBussinesCaja.CajaId(cierre.Caja.Id).Numero.ToString());
                ticket.AddHeaderLine("Turno : " + miBussinesTurno.TurnoId(cierre.Turno.Id).Numero.ToString());
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("");
                foreach (FormaPago valor in cierre.Valores)
                {
                    if (valor.Valor > 0)
                    {
                        ticket.AddHeaderLine(valor.NombreFormaPago + " : " +
                                             UseObject.InsertSeparatorMil(valor.Valor.ToString()));
                    }
                }
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("TOTAL CIERRE : " + 
                    UseObject.InsertSeparatorMil(cierre.Valores.Sum(s => s.Valor).ToString()));
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("Firma:");
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("-----------------------------------");
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("");
                ticket.PrintTicket("IMPREPOS");
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }


        
    }
}