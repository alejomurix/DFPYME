using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utilities;
using CustomControl;
using DTO.Clases;
using BussinesLayer.Clases;

namespace Aplicacion.Ventas.Retiro
{
    public partial class FrmRetiroDinero : Form
    {
        //private BussinesEgreso miBussinesEgreso;
        private BussinesRetiro miBussinesRetiro;

        private BussinesEmpresa miBussinesEmpresa;

        private BussinesUsuario miBussinesUsuario;

        private BussinesCaja miBussinesCaja;

        private BussinesTurno miBussinesTurno;

        private ErrorProvider miError;

        private bool ValorMatch = false;

        private bool ConceptoMatch = false;

        private string ValorFormat = "El número que ingreso es invalido.";

        private string ConceptoReq = "El concepto del retiro es requerido.";

        private string ConceptoFormat = "El concepto que ingreso en invalido.";

        public FrmRetiroDinero()
        {
            InitializeComponent();
            //miBussinesEgreso = new BussinesEgreso();
            miBussinesRetiro = new BussinesRetiro();
            miBussinesEmpresa = new BussinesEmpresa();
            miBussinesUsuario = new BussinesUsuario();
            miBussinesCaja = new BussinesCaja();
            miBussinesTurno = new BussinesTurno();
            miError = new ErrorProvider();
        }

        private void FrmRetiroDinero_Load(object sender, EventArgs e)
        {
            CargarUtilidades();
            txtValor.SelectAll();
        }

        private void FrmRetiroDinero_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.Escape))
            {
                this.Close();
            }
        }

        private void FrmRetiroDinero_FormClosing(object sender, FormClosingEventArgs e)
        {
            CompletaEventos.CapturaEvento(false);
        }

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                cbNominacion.Focus();
            }
        }

        private void txtValor_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtValor.Text))
            {
                txtValor.Text = "0";
                ValorMatch = true;
            }
            if (!txtValor.Text.Equals("0"))
            {
                if (Validacion.ConFormato
                   (Validacion.TipoValidacion.Numeros, txtValor, miError, ValorFormat))
                {
                    ValorMatch = true;
                }
                else
                {
                    ValorMatch = false;
                }
            }
            else
            {
                miError.SetError(txtValor, "El valor del saldo debe ser mayor a cero.");
                ValorMatch = false;
            }
        }

        private void cbNominacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                txtConcepto.Focus();
            }
        }

        private void txtConcepto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                if (!Validacion.EsVacio(txtConcepto, miError, ConceptoReq))
                {
                    ConceptoMatch = true;
                    this.txtConcepto.Text = this.txtConcepto.Text.ToUpper();
                    this.btnAceptar_Click(this.btnAceptar, new EventArgs());
                }
                else
                {
                    ConceptoMatch = false;
                }
            }
        }

        private void txtConcepto_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(txtConcepto, miError, ConceptoReq))
            {
                ConceptoMatch = true;
            }
            else
            {
                ConceptoMatch = false;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            txtValor_Validating(this.txtValor, new CancelEventArgs(false));
            txtConcepto_Validating(this.txtConcepto, new CancelEventArgs(false));
            if (ValorMatch && ConceptoMatch)
            {
                try
                {
                    var retiro = new DTO.Clases.Retiro();
                    retiro.Fecha = DateTime.Now;
                    retiro.Caja.Id = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_caja"));
                    retiro.Turno.Id = Convert.ToInt32(AppConfiguracion.ValorSeccion("idturno"));
                    retiro.Usuario.Id = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_user"));
                    retiro.Valores.Add(new FormaPago
                    {
                        IdFormaPago = Convert.ToInt32(cbNominacion.SelectedValue),
                        NombreFormaPago = ((Inventario.Producto.Criterio)cbNominacion.SelectedItem).Nombre,
                        NumeroFactura = txtConcepto.Text,
                        Valor = Convert.ToInt32(txtValor.Text)
                    });
                    miBussinesRetiro.Ingresar(retiro);
                    DialogResult rta = MessageBox.Show("El retiro se ha realizado correctamente.\n¿Desea imprimir el recibo?", "Retiro",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (rta.Equals(DialogResult.Yes))
                    {
                        if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("print_termal_80mm")))
                        {
                            PrintPos(retiro);
                        }
                        else
                        {
                            PrintPos58mm(retiro);
                        }
                    }
                    txtValor.Focus();
                    txtConcepto.Text = "";
                    txtValor.Text = "";
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }

                /*var retiro = new Egreso();
                retiro.IdBaseCaja = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_base"));
                retiro.IdPago = Convert.ToInt32(cbNominacion.SelectedValue);
                retiro.Hora = DateTime.Now;
                retiro.Valor = Convert.ToInt32(txtValor.Text);
                retiro.Concepto = txtConcepto.Text;
                try
                {
                    miBussinesEgreso.IngresarRetiro(retiro);
                    OptionPane.MessageInformation("El retiro de dinero se ha realizado correctamente.");
                    this.Close();
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }*/
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CargarUtilidades()
        {
            var lst = new List<Inventario.Producto.Criterio>();
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 1,
                Nombre = "Efectivo"
            });
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 2,
                Nombre = "Cheque"
            });
            cbNominacion.DataSource = lst;
        }

        private void PrintPos(DTO.Clases.Retiro retiro)
        {
            try
            {
                DataRow empresaRow = miBussinesEmpresa.PrintEmpresa().
                        Tables[0].AsEnumerable().First();

                var usuarioRow = miBussinesUsuario.ConsultaUsuario(retiro.Usuario.Id).
                                                               AsEnumerable().First();
                Ticket ticket = new Ticket();
                ticket.UseItem = false;

                ticket.AddHeaderLine(empresaRow["Nombre"].ToString().ToUpper());
                ticket.AddHeaderLine(empresaRow["Juridico"].ToString());
                ticket.AddHeaderLine("NIT " + UseObject.InsertSeparatorMilMasDigito(empresaRow["Nit"].ToString()));
                ticket.AddHeaderLine("Régimen: " + empresaRow["Regimen"].ToString());
                ticket.AddHeaderLine(empresaRow["Direccion"].ToString());
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("RECIBO DE RETIRO");
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("Fecha   : " + retiro.Fecha.ToShortDateString());
                ticket.AddHeaderLine("Hora    : " + retiro.Fecha.ToShortTimeString());
                ticket.AddHeaderLine("Usuario : " + usuarioRow["nombre"].ToString());
                ticket.AddHeaderLine("Caja    : " + miBussinesCaja.CajaId(retiro.Caja.Id).Numero.ToString());
                ticket.AddHeaderLine("Turno   : " + miBussinesTurno.TurnoId(retiro.Turno.Id).Numero.ToString());
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("");
                foreach (FormaPago pago in retiro.Valores)
                {
                    ticket.AddHeaderLine("Concepto : " + pago.NumeroFactura);
                    ticket.AddHeaderLine(pago.NombreFormaPago + " : " +
                        UseObject.InsertSeparatorMil(pago.Valor.ToString()));
                }
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("Frima:");
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("-----------------------------------");
                ticket.PrintTicket("IMPREPOS");
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void PrintPos58mm(DTO.Clases.Retiro retiro)
        {
            try
            {
                DataRow empresaRow = miBussinesEmpresa.PrintEmpresa().
                        Tables[0].AsEnumerable().First();

                var usuarioRow = miBussinesUsuario.ConsultaUsuario(retiro.Usuario.Id).
                                                               AsEnumerable().First();
                Ticket ticket = new Ticket();
                ticket.UseItem = false;
                ticket.Printer80mm = false;

                ticket.AddHeaderLine(empresaRow["Nombre"].ToString().ToUpper());
                ticket.AddHeaderLine(empresaRow["Juridico"].ToString().ToUpper());
                ticket.AddHeaderLine(empresaRow["Nit"].ToString().ToUpper());
                ticket.AddHeaderLine(empresaRow["direccion_"].ToString().ToUpper());
                ticket.AddHeaderLine(empresaRow["ciudad"].ToString().ToUpper() + " " +
                    empresaRow["departamento"].ToString().ToUpper());
                ticket.AddHeaderLine(empresaRow["celularempresa"].ToString().ToUpper());

                ticket.AddHeaderLine("---------------------------");
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("RECIBO DE RETIRO");
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("FECHA   : " + retiro.Fecha.ToShortDateString());
                ticket.AddHeaderLine("HORA    : " + retiro.Fecha.ToShortTimeString());
                ticket.AddHeaderLine("");

                ticket.AddHeaderLine("CONCEPTOS:");
                ticket.AddHeaderLine("");
                foreach (FormaPago pago in retiro.Valores)
                {
                    ticket.AddHeaderLine(pago.NumeroFactura);
                    ticket.AddHeaderLine(UseObject.AjusteDeCaracteresDerecha_(
                        UseObject.InsertSeparatorMil(pago.Valor.ToString())));
                }
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("---------------------------");
                ticket.PrintTicket("");

                /* ticket.AddHeaderLine(empresaRow["Nombre"].ToString().ToUpper());
                 ticket.AddHeaderLine(empresaRow["Juridico"].ToString());
                 ticket.AddHeaderLine("NIT " + UseObject.InsertSeparatorMilMasDigito(empresaRow["Nit"].ToString()));
                 ticket.AddHeaderLine("Régimen: " + empresaRow["Regimen"].ToString());
                 ticket.AddHeaderLine(empresaRow["Direccion"].ToString());
                 ticket.AddHeaderLine("");
                 ticket.AddHeaderLine("RECIBO DE RETIRO");
                 ticket.AddHeaderLine("");
                 ticket.AddHeaderLine("Fecha   : " + retiro.Fecha.ToShortDateString());
                 ticket.AddHeaderLine("Hora    : " + retiro.Fecha.ToShortTimeString());
                 ticket.AddHeaderLine("Usuario : " + usuarioRow["nombre"].ToString());
                 ticket.AddHeaderLine("Caja    : " + miBussinesCaja.CajaId(retiro.Caja.Id).Numero.ToString());
                 ticket.AddHeaderLine("Turno   : " + miBussinesTurno.TurnoId(retiro.Turno.Id).Numero.ToString());
                 ticket.AddHeaderLine("");
                 ticket.AddHeaderLine("");
                 foreach (FormaPago pago in retiro.Valores)
                 {
                     ticket.AddHeaderLine("Concepto : " + pago.NumeroFactura);
                     ticket.AddHeaderLine(pago.NombreFormaPago + " : " +
                         UseObject.InsertSeparatorMil(pago.Valor.ToString()));
                 }
                 ticket.AddHeaderLine("");
                 ticket.AddHeaderLine("");
                 ticket.AddHeaderLine("Frima:");
                 ticket.AddHeaderLine("");
                 ticket.AddHeaderLine("-----------------------------------");
                 ticket.PrintTicket("IMPREPOS");*/
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }
    }
}