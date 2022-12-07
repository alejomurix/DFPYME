using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DTO.Clases;
using BussinesLayer.Clases;
using CustomControl;
using Utilities;

namespace Aplicacion.Administracion.Caja
{
    public partial class FrmConsultaCaja : Form
    {
        private bool ElectronicaInvoice;

        private Apertura Apertura_;

        private DateTime Fecha2;

        private BussinesIngreso miBussinesIngreso;

        private BussinesFacturaVenta miBussinesFacturaVenta;

        private BussinesRetiro miBussinesRetiro;

        private BussinesApertura miBussinesApertura;

        private BussinesCierre miBussinesCierre;

        private BussinesCaja miBussinesCaja;

        private BussinesTurno miBussinesTurno;

        private BussinesDevolucion miBussinesDevolucion;

        private BussinesEmpresa miBussinesEmpresa;

        private BussinesUsuario miBussinesUsuario;

        private DataTable TablaIngresos { set; get; }

        private List<FormaPago> Payments { set; get; }

        private DataTable Tabla { set; get; }

        private int Variable { set; get; }

        private ErrorProvider miError;


        public const string SuperUsuario = "SUPER_USUARIO";

        public DTO.Clases.Usuario Usuario_ { set; get; }

        private const int IdPermisoEditarRetiro = 38;

        private bool PermisoEditarRetiro;

        private const int IdPermisoEditarApertura = 39;

        private bool PermisoEditarApertura;

        private const int IdPermisoEditarCierre = 40;

        private bool PermisoEditarCierre;

        private System.Threading.Thread thread;

        public FrmConsultaCaja()
        {
            InitializeComponent();
            //this.btnEditarApertura

            try
            {
                this.ElectronicaInvoice = Convert.ToBoolean(AppConfiguracion.ValorSeccion("electronic_invoice"));
                if (!this.ElectronicaInvoice)
                {
                    this.lblFE.Visible = false;
                    this.txtIngresosFE.Visible = false;
                    this.btnDetailIngresosFE.Visible = false;
                }
                this.Apertura_ = new Apertura();
                this.Fecha2 = DateTime.Now;

                this.miBussinesIngreso = new BussinesIngreso();
                this.miBussinesFacturaVenta = new BussinesFacturaVenta();
                this.miBussinesRetiro = new BussinesRetiro();
                this.miBussinesApertura = new BussinesApertura();
                this.miBussinesCierre = new BussinesCierre();
                this.miBussinesCaja = new BussinesCaja();
                this.miBussinesTurno = new BussinesTurno();
                this.miBussinesDevolucion = new BussinesDevolucion();
                this.miBussinesEmpresa = new BussinesEmpresa();
                this.miBussinesUsuario = new BussinesUsuario();
                this.Variable = 1;
                this.miError = new ErrorProvider();

                this.Payments = new List<FormaPago>();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void FrmConsultaRetiro_Load(object sender, EventArgs e)
        {
            CargarElementos();
            CompletaEventos.Completa += new CompletaEventos.CompletaAccion(CompletaEventos_Completo);
            this.PermisoEditarRetiro = false;
            this.PermisoEditarApertura = false;
            this.PermisoEditarCierre = false;
            foreach (var ps in Usuario_.Permisos)
            {
                switch (ps.IdPermiso)
                {
                    case IdPermisoEditarRetiro:
                        {
                            this.PermisoEditarRetiro = true;
                            break;
                        }
                    case IdPermisoEditarApertura:
                        {
                            this.PermisoEditarApertura = true;
                            break;
                        }
                    case IdPermisoEditarCierre:
                        {
                            this.PermisoEditarCierre = true;
                            break;
                        }
                }
            }
        }

        private void FrmConsultaCaja_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Variable = 0;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (Tabla.Rows.Count != 0)
            {
                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("printInformeRetiro")))
                {
                    PrintPos(Tabla);
                }
                else
                {
                }
            }
            else
            {
                OptionPane.MessageInformation("No hay registros para imprimir.");
            }
        }

        private void btnImprimeInforme_Click(object sender, EventArgs e)
        {
            PrintInformePos(dtpFecha.Value);
        }

        private void btnInformeGeneral_Click_Copy(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvAperturas.Rows.Count > 0)
                {


                    //if (this.dgvIngresos.Rows.Count > 0)
                    //{
                    var caja = miBussinesCaja.CajaId(Convert.ToInt32(this.cbCaja.SelectedValue));
                    var turno = miBussinesTurno.TurnoId(Convert.ToInt32(this.cbTurno.SelectedValue));

                    var tIngresos = this.miBussinesIngreso.PrintIngresosHoras(this.Apertura_.Fecha, this.Fecha2, caja.Id, turno.Id);

                    //var tCreditos = miBussinesFacturaVenta.TotalFacturasCreditoHoras(2, caja.Id, this.Apertura_.Fecha, this.Fecha2);

                    //var totalCredito = this.miBussinesFacturaVenta.TotalVentas(2, caja.Id, this.Apertura_.Fecha, this.Fecha2); Remplazado por funcion auxiliar  28/03/2019
                    //var totalCredito = this.miBussinesFacturaVenta.VentasCredito(2, caja.Id, this.Apertura_.Fecha, this.Fecha2);  // funcion auxiliar             28/03/2019

                    var ventas = miBussinesFacturaVenta.Ventas(caja.Id, this.Apertura_.Fecha, this.Fecha2);    /// Actualización de consulta 10-08-2021
                    var totalCredito = ventas.Where(v => v.EstadoFactura.Id.Equals(2)).Sum(s => s.Valor);      /// Actualización de consulta 10-08-2021

                    var tRetiros = miBussinesRetiro.PrintRetirosHoras(this.Apertura_.Fecha, this.Fecha2, caja.Id, turno.Id);
                    //var tCierres = miBussinesCierre.Print(this.Apertura_.Id);
                    var tCierres = miBussinesCierre.Tcierres(this.Apertura_.Id);

                    DataRow empresaRow = miBussinesEmpresa.PrintEmpresa().Tables[0].AsEnumerable().First();

                    if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("print_termal_80mm")))
                    {

                        Ticket ticket = new Ticket();
                        ticket.UseItem = false;
                        int maxCharacters = 35;

                        /*ticket.AddHeaderLine(empresaRow["Nombre"].ToString().ToUpper());
                        ticket.AddHeaderLine(empresaRow["Juridico"].ToString());
                        ticket.AddHeaderLine("NIT " + UseObject.InsertSeparatorMilMasDigito(empresaRow["Nit"].ToString()));
                        ticket.AddHeaderLine("Régimen: " + empresaRow["Regimen"].ToString());
                        ticket.AddHeaderLine(empresaRow["Direccion"].ToString());*/

                        foreach (var datos in UseObject.StringBuilderDataCenter(empresaRow["Nombre"].ToString().ToUpper(), maxCharacters))
                        {
                            ticket.AddHeaderLine(datos);
                        }
                        foreach (var datos in UseObject.StringBuilderDataCenter(empresaRow["Juridico"].ToString(), maxCharacters))
                        {
                            ticket.AddHeaderLine(datos);
                        }
                        foreach (var datos in UseObject.StringBuilderDataCenter(
                            "NIT " + UseObject.InsertSeparatorMilMasDigito(empresaRow["Nit"].ToString()), maxCharacters))
                        {
                            ticket.AddHeaderLine(datos);
                        }
                        foreach (var datos in UseObject.StringBuilderDataCenter(empresaRow["Direccion"].ToString(), maxCharacters))
                        {
                            ticket.AddHeaderLine(datos);
                        }
                        foreach (var datos in UseObject.StringBuilderDataCenter(empresaRow["Telefono"].ToString(), maxCharacters))
                        {
                            ticket.AddHeaderLine(datos);
                        }
                        foreach (var datos in UseObject.StringBuilderDataCenter(empresaRow["Regimen"].ToString(), maxCharacters))
                        {
                            ticket.AddHeaderLine(datos);
                        }
                        ticket.AddHeaderLine("");
                        ticket.AddHeaderLine("INFORME DE CAJA");
                        ticket.AddHeaderLine("Fecha : " + this.Apertura_.Fecha.ToShortDateString());
                        ticket.AddHeaderLine("Caja  : " + caja.Numero);
                        ticket.AddHeaderLine("Turno : " + turno.Numero);

                        ticket.AddHeaderLine("");

                        ticket.AddHeaderLine("MOVIMIENTO DE CAJA");
                        ticket.AddHeaderLine("-----------------------------------");
                        ticket.AddHeaderLine("     APERTURA :" + UseObject.StringBuilderDetalleTotalEspacio(
                            UseObject.InsertSeparatorMil(this.Apertura_.Valor.ToString())));
                        //ticket.AddHeaderLine("INGRESOS");
                        ticket.AddHeaderLine("     EFECTIVO :" + UseObject.StringBuilderDetalleTotalEspacio(UseObject.InsertSeparatorMil(
                            tIngresos.AsEnumerable().Where(i => i.Field<int>("idpago").Equals(1)).Sum(s => s.Field<int>("valor")).ToString())));
                        ticket.AddHeaderLine("  TRANSACCIÓN :" + UseObject.StringBuilderDetalleTotalEspacio(UseObject.InsertSeparatorMil(
                            tIngresos.AsEnumerable().Where(i => i.Field<int>("idpago").Equals(4)).Sum(s => s.Field<int>("valor")).ToString())));
                        ticket.AddHeaderLine("       CHEQUE :" + UseObject.StringBuilderDetalleTotalEspacio(UseObject.InsertSeparatorMil(
                            tIngresos.AsEnumerable().Where(i => i.Field<int>("idpago").Equals(2)).Sum(s => s.Field<int>("valor")).ToString())));


                        /*ticket.AddHeaderLine("Apertura:       " +
                                          UseObject.InsertSeparatorMil(this.Apertura_.Valor.ToString()));

                        ticket.AddHeaderLine("Vent. Efectivo: " + UseObject.InsertSeparatorMil(
                            tIngresos.AsEnumerable().Where(i => i.Field<int>("idpago").Equals(1)).Sum(s => s.Field<int>("valor")).ToString()));
                        ticket.AddHeaderLine("TOTAL:          " + UseObject.InsertSeparatorMil((this.Apertura_.Valor +
                            tIngresos.AsEnumerable().Where(i => i.Field<int>("idpago").Equals(1)).Sum(s => s.Field<int>("valor"))).ToString()));*/


                        ticket.AddHeaderLine("-----------------------------------");
                        ticket.AddHeaderLine("RETIROS");
                        foreach (DataRow rRow in tRetiros.Rows)
                        {
                            ticket.AddHeaderLine("");
                            ticket.AddHeaderLine("Fecha:    " + Convert.ToDateTime(rRow["fecha"]).ToShortDateString() + " " +
                                                                Convert.ToDateTime(rRow["hora"]).ToShortTimeString());
                            ticket.AddHeaderLine("Concepto: " + rRow["concepto"].ToString());
                            ticket.AddHeaderLine("Valor:    " + UseObject.InsertSeparatorMil(rRow["valor"].ToString()));
                        }
                        ticket.AddHeaderLine("");
                        ticket.AddHeaderLine("TOTAL RETIROS :" + UseObject.StringBuilderDetalleTotalEspacio(UseObject.InsertSeparatorMil(
                            tRetiros.AsEnumerable().Sum(s => s.Field<int>("valor")).ToString())));
                        ticket.AddHeaderLine("-----------------------------------");
                        ticket.AddHeaderLine(" DEVOLUCIONES :" + UseObject.StringBuilderDetalleTotalEspacio(this.txtTotalDevolucion.Text));
                        ticket.AddHeaderLine("-----------------------------------");
                        ticket.AddHeaderLine("CUADRE DE CAJA");
                        ticket.AddHeaderLine("");

                        ticket.AddHeaderLine("     EFECTIVO :" + UseObject.StringBuilderDetalleTotalEspacio(UseObject.InsertSeparatorMil(
                            tCierres.AsEnumerable().Where(i => i.Field<int>("idpago").Equals(1)).Sum(s => s.Field<int>("valor")).ToString())));
                        ticket.AddHeaderLine("  TRANSACCIÓN :" + UseObject.StringBuilderDetalleTotalEspacio(UseObject.InsertSeparatorMil(
                            tCierres.AsEnumerable().Where(i => i.Field<int>("idpago").Equals(4)).Sum(s => s.Field<int>("valor")).ToString())));
                        ticket.AddHeaderLine("       CHEQUE :" + UseObject.StringBuilderDetalleTotalEspacio(UseObject.InsertSeparatorMil(
                            tCierres.AsEnumerable().Where(i => i.Field<int>("idpago").Equals(2)).Sum(s => s.Field<int>("valor")).ToString())));
                        ticket.AddHeaderLine("");
                        //ticket.AddHeaderLine("EFEC. + APERT.:" + UseObject.StringBuilderDetalleTotalEspacio(UseObject.InsertSeparatorMil((this.Apertura_.Valor +
                        //tIngresos.AsEnumerable().Where(i => i.Field<int>("idpago").Equals(1)).Sum(s => s.Field<int>("valor"))).ToString()))); 

                        ticket.AddHeaderLine("      RETIROS :" + UseObject.StringBuilderDetalleTotalEspacio(UseObject.InsertSeparatorMil(
                            tRetiros.AsEnumerable().Sum(s => s.Field<int>("valor")).ToString())));
                        ticket.AddHeaderLine(" DEVOLUCIONES :" + UseObject.StringBuilderDetalleTotalEspacio(this.txtTotalDevolucion.Text));
                        ticket.AddHeaderLine("EFEC. EN CAJA :" + UseObject.StringBuilderDetalleTotalEspacio(UseObject.InsertSeparatorMil(((this.Apertura_.Valor +
                            tIngresos.AsEnumerable().Where(i => i.Field<int>("idpago").Equals(1)).Sum(s => s.Field<int>("valor"))) -
                            tRetiros.AsEnumerable().Sum(s => s.Field<int>("valor")) -
                            UseObject.RemoveSeparatorMil(this.txtTotalDevolucion.Text)).ToString())));
                        ticket.AddHeaderLine("");
                        ticket.AddHeaderLine("CIERRE DE CAJA:" + UseObject.StringBuilderDetalleTotalEspacio(this.txtCierre.Text));
                        ticket.AddHeaderLine("         SALDO:" + UseObject.StringBuilderDetalleTotalEspacio(this.txtSaldo.Text));
                        ticket.AddHeaderLine("-----------------------------------");
                        ticket.AddHeaderLine("CREDITOS:      " + UseObject.StringBuilderDetalleTotalEspacio(
                            UseObject.InsertSeparatorMil(totalCredito.ToString())));
                        /*
                        ticket.AddHeaderLine("-----------------------------------");
                        ticket.AddHeaderLine("OTRAS FORMAS DE PAGO");
                        ticket.AddHeaderLine("Cheque:         " + UseObject.InsertSeparatorMil(
                            tIngresos.AsEnumerable().Where(i => i.Field<int>("idpago").Equals(2)).Sum(s => s.Field<int>("valor")).ToString()));
                        ticket.AddHeaderLine("Transacción:    " + UseObject.InsertSeparatorMil(
                            tIngresos.AsEnumerable().Where(i => i.Field<int>("idpago").Equals(4)).Sum(s => s.Field<int>("valor")).ToString()));

                        ticket.AddHeaderLine("Crédito:        " + UseObject.InsertSeparatorMil(totalCredito.ToString()));

                        ticket.AddHeaderLine("TOTAL:          " + UseObject.InsertSeparatorMil((
                            tIngresos.AsEnumerable().Where(i => i.Field<int>("idpago") != 1).Sum(s => s.Field<int>("valor")) + totalCredito).ToString()));
                        */
                        ticket.AddHeaderLine("-----------------------------------");

                        ticket.AddHeaderLine("TOTAL VENTAS:  " + UseObject.StringBuilderDetalleTotalEspacio(
                                                                 UseObject.InsertSeparatorMil(ventas.Sum(s => s.Valor).ToString())));   /// Actualización 10-08-2021
                        /*ticket.AddHeaderLine("TOTAL VENTAS:  " + UseObject.StringBuilderDetalleTotalEspacio(
                            UseObject.InsertSeparatorMil((tIngresos.AsEnumerable().Sum(s => s.Field<int>("valor")) + totalCredito).ToString())));*/

                        ticket.AddHeaderLine("-----------------------------------");
                        ticket.AddHeaderLine("");
                        ticket.AddHeaderLine("");
                        ticket.AddHeaderLine("");
                        ticket.AddHeaderLine("___________________________________");
                        ticket.AddHeaderLine("CAJERO. C.C.");
                        ticket.AddHeaderLine("");
                        ticket.AddHeaderLine("");

                        ticket.PrintTicket("");
                    }
                    else
                    {
                        PrintPos58mm(caja, turno, tIngresos, totalCredito, tRetiros, empresaRow);
                    }
                }
                else
                {
                    OptionPane.MessageInformation("Debe consultar las aperturas.");
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        DTO.Clases.Caja caja;
        Turno turno;

        private void btnInformeGeneral_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvAperturas.Rows.Count > 0)
                {
                    this.btnInformeGeneral.Enabled = false;

                    caja = miBussinesCaja.CajaId(Convert.ToInt32(this.cbCaja.SelectedValue));
                    turno = miBussinesTurno.TurnoId(Convert.ToInt32(this.cbTurno.SelectedValue));

                    this.thread = new System.Threading.Thread(LoadData);
                    this.thread.Start();

                    /** var tIngresos = this.miBussinesIngreso.PrintIngresosHoras(this.Apertura_.Fecha, this.Fecha2, caja.Id, turno.Id);

                    var ventas = miBussinesFacturaVenta.Ventas(caja.Id, this.Apertura_.Fecha, this.Fecha2);    /// Actualización de consulta 10-08-2021
                    var totalCredito = ventas.Where(v => v.EstadoFactura.Id.Equals(2)).Sum(s => s.Valor);      /// Actualización de consulta 10-08-2021

                    var tRetiros = miBussinesRetiro.PrintRetirosHoras(this.Apertura_.Fecha, this.Fecha2, caja.Id, turno.Id);
                    var tCierres = miBussinesCierre.Tcierres(this.Apertura_.Id);

                    DataRow empresaRow = miBussinesEmpresa.PrintEmpresa().Tables[0].AsEnumerable().First();

                    if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("print_termal_80mm")))
                    {

                        Ticket ticket = new Ticket();
                        ticket.UseItem = false;
                        int maxCharacters = 35;

                        foreach (var datos in UseObject.StringBuilderDataCenter(empresaRow["Nombre"].ToString().ToUpper(), maxCharacters))
                        {
                            ticket.AddHeaderLine(datos);
                        }
                        foreach (var datos in UseObject.StringBuilderDataCenter(empresaRow["Juridico"].ToString(), maxCharacters))
                        {
                            ticket.AddHeaderLine(datos);
                        }
                        foreach (var datos in UseObject.StringBuilderDataCenter(
                            "NIT " + UseObject.InsertSeparatorMilMasDigito(empresaRow["Nit"].ToString()), maxCharacters))
                        {
                            ticket.AddHeaderLine(datos);
                        }
                        foreach (var datos in UseObject.StringBuilderDataCenter(empresaRow["Direccion"].ToString(), maxCharacters))
                        {
                            ticket.AddHeaderLine(datos);
                        }
                        foreach (var datos in UseObject.StringBuilderDataCenter(empresaRow["Telefono"].ToString(), maxCharacters))
                        {
                            ticket.AddHeaderLine(datos);
                        }
                        foreach (var datos in UseObject.StringBuilderDataCenter(empresaRow["Regimen"].ToString(), maxCharacters))
                        {
                            ticket.AddHeaderLine(datos);
                        }
                        ticket.AddHeaderLine("");
                        ticket.AddHeaderLine("INFORME DE CAJA");
                        ticket.AddHeaderLine("Fecha : " + this.Apertura_.Fecha.ToShortDateString());
                        ticket.AddHeaderLine("Caja  : " + caja.Numero);
                        ticket.AddHeaderLine("Turno : " + turno.Numero);

                        ticket.AddHeaderLine("");

                        ticket.AddHeaderLine("MOVIMIENTO DE CAJA");
                        ticket.AddHeaderLine("-----------------------------------");
                        ticket.AddHeaderLine("     APERTURA :" + UseObject.StringBuilderDetalleTotalEspacio(
                            UseObject.InsertSeparatorMil(this.Apertura_.Valor.ToString())));
                        ticket.AddHeaderLine("     EFECTIVO :" + UseObject.StringBuilderDetalleTotalEspacio( UseObject.InsertSeparatorMil(
                            tIngresos.AsEnumerable().Where(i => i.Field<int>("idpago").Equals(1)).Sum(s => s.Field<int>("valor")).ToString())));
                        ticket.AddHeaderLine("  TRANSACCIÓN :" + UseObject.StringBuilderDetalleTotalEspacio(UseObject.InsertSeparatorMil(
                            tIngresos.AsEnumerable().Where(i => i.Field<int>("idpago").Equals(4)).Sum(s => s.Field<int>("valor")).ToString())));
                        ticket.AddHeaderLine("       CHEQUE :" + UseObject.StringBuilderDetalleTotalEspacio(UseObject.InsertSeparatorMil(
                            tIngresos.AsEnumerable().Where(i => i.Field<int>("idpago").Equals(2)).Sum(s => s.Field<int>("valor")).ToString())));

                        ticket.AddHeaderLine("-----------------------------------");
                        ticket.AddHeaderLine("RETIROS");
                        foreach (DataRow rRow in tRetiros.Rows)
                        {
                            ticket.AddHeaderLine("");
                            ticket.AddHeaderLine("Fecha:    " + Convert.ToDateTime(rRow["fecha"]).ToShortDateString() + " " +
                                                                Convert.ToDateTime(rRow["hora"]).ToShortTimeString());
                            ticket.AddHeaderLine("Concepto: " + rRow["concepto"].ToString());
                            ticket.AddHeaderLine("Valor:    " + UseObject.InsertSeparatorMil(rRow["valor"].ToString()));
                        }
                        ticket.AddHeaderLine("");
                        ticket.AddHeaderLine("TOTAL RETIROS :" + UseObject.StringBuilderDetalleTotalEspacio(UseObject.InsertSeparatorMil(
                            tRetiros.AsEnumerable().Sum(s => s.Field<int>("valor")).ToString())));
                        ticket.AddHeaderLine("-----------------------------------");
                        ticket.AddHeaderLine(" DEVOLUCIONES :" + UseObject.StringBuilderDetalleTotalEspacio(this.txtTotalDevolucion.Text));
                        ticket.AddHeaderLine("-----------------------------------");
                        ticket.AddHeaderLine("CUADRE DE CAJA");
                        ticket.AddHeaderLine("");

                        ticket.AddHeaderLine("     EFECTIVO :" + UseObject.StringBuilderDetalleTotalEspacio(UseObject.InsertSeparatorMil(
                            tCierres.AsEnumerable().Where(i => i.Field<int>("idpago").Equals(1)).Sum(s => s.Field<int>("valor")).ToString())));
                        ticket.AddHeaderLine("  TRANSACCIÓN :" + UseObject.StringBuilderDetalleTotalEspacio(UseObject.InsertSeparatorMil(
                            tCierres.AsEnumerable().Where(i => i.Field<int>("idpago").Equals(4)).Sum(s => s.Field<int>("valor")).ToString())));
                        ticket.AddHeaderLine("       CHEQUE :" + UseObject.StringBuilderDetalleTotalEspacio(UseObject.InsertSeparatorMil(
                            tCierres.AsEnumerable().Where(i => i.Field<int>("idpago").Equals(2)).Sum(s => s.Field<int>("valor")).ToString())));
                        ticket.AddHeaderLine("");
                       
                        ticket.AddHeaderLine("      RETIROS :" + UseObject.StringBuilderDetalleTotalEspacio(UseObject.InsertSeparatorMil(
                            tRetiros.AsEnumerable().Sum(s => s.Field<int>("valor")).ToString())));
                        ticket.AddHeaderLine(" DEVOLUCIONES :" + UseObject.StringBuilderDetalleTotalEspacio(this.txtTotalDevolucion.Text));
                        ticket.AddHeaderLine("EFEC. EN CAJA :" +  UseObject.StringBuilderDetalleTotalEspacio(UseObject.InsertSeparatorMil(((this.Apertura_.Valor +
                            tIngresos.AsEnumerable().Where(i => i.Field<int>("idpago").Equals(1)).Sum(s => s.Field<int>("valor"))) -
                            tRetiros.AsEnumerable().Sum(s => s.Field<int>("valor")) -
                            UseObject.RemoveSeparatorMil(this.txtTotalDevolucion.Text)).ToString())));
                        ticket.AddHeaderLine("");
                        ticket.AddHeaderLine("CIERRE DE CAJA:" +  UseObject.StringBuilderDetalleTotalEspacio(this.txtCierre.Text));
                        ticket.AddHeaderLine("         SALDO:" + UseObject.StringBuilderDetalleTotalEspacio(this.txtSaldo.Text));
                        ticket.AddHeaderLine("-----------------------------------");
                        ticket.AddHeaderLine("CREDITOS:      " + UseObject.StringBuilderDetalleTotalEspacio(
                            UseObject.InsertSeparatorMil(totalCredito.ToString())));
                        
                        ticket.AddHeaderLine("-----------------------------------");

                        ticket.AddHeaderLine("TOTAL VENTAS:  " + UseObject.StringBuilderDetalleTotalEspacio(
                                                                 UseObject.InsertSeparatorMil(ventas.Sum(s => s.Valor).ToString())));   /// Actualización 10-08-2021

                        ticket.AddHeaderLine("-----------------------------------");
                        ticket.AddHeaderLine("");
                        ticket.AddHeaderLine("");
                        ticket.AddHeaderLine("");
                        ticket.AddHeaderLine("___________________________________");
                        ticket.AddHeaderLine("CAJERO. C.C.");
                        ticket.AddHeaderLine("");
                        ticket.AddHeaderLine("");

                        ticket.PrintTicket("");
                    }
                    else
                    {
                        PrintPos58mm(caja, turno, tIngresos, totalCredito, tRetiros, empresaRow);
                    }
                    */
                }
                else
                {
                    OptionPane.MessageInformation("Debe consultar las aperturas.");
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void PrintPos58mm(DTO.Clases.Caja caja, Turno turno, DataTable tIngresos,
            int totalCredito, DataTable tRetiros, DataRow empresaRow)
        {
            try
            {
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
                ticket.AddHeaderLine("INFORME DE CAJA");
                ticket.AddHeaderLine("Fecha : " + this.Apertura_.Fecha.ToShortDateString());
                ticket.AddHeaderLine("Caja  : " + caja.Numero);
                ticket.AddHeaderLine("Turno : " + turno.Numero);

                ticket.AddHeaderLine("");

                ticket.AddHeaderLine("Movimiento de caja");
                ticket.AddHeaderLine("---------------------------");
                ticket.AddHeaderLine("Ingresos en efectivo");
                ticket.AddHeaderLine(UseObject.AjusteDeCaracteresDerecha_(UseObject.InsertSeparatorMil(
                    tIngresos.AsEnumerable().Where(i => i.Field<int>("idpago").Equals(1)).Sum(s => s.Field<int>("valor")).ToString())));
                ticket.AddHeaderLine("---------------------------");
                ticket.AddHeaderLine("Retiros");
                foreach (DataRow rRow in tRetiros.Rows)
                {
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine(Convert.ToDateTime(rRow["fecha"]).ToShortDateString() + " " +
                        Convert.ToDateTime(rRow["hora"]).ToShortTimeString());
                    ticket.AddHeaderLine(rRow["concepto"].ToString());
                    ticket.AddHeaderLine(UseObject.AjusteDeCaracteresDerecha_(UseObject.InsertSeparatorMil(rRow["valor"].ToString())));
                }
                /*ticket.AddHeaderLine("TOTAL: " + UseObject.StringBuilderDataIzquierda(UseObject.InsertSeparatorMil(
                    tRetiros.AsEnumerable().Sum(s => s.Field<int>("valor")).ToString()) , 20));*/

                ticket.AddHeaderLine("");

                string d_ = "";
                foreach (var datos in UseObject.StringBuilderDetalleTotal(UseObject.InsertSeparatorMil(
                    tRetiros.AsEnumerable().Sum(s => s.Field<int>("valor")).ToString()), 20))
                {
                    d_ += datos;
                }
                ticket.AddHeaderLine("TOTAL: " + d_);

                ticket.AddHeaderLine("---------------------------");
                ticket.AddHeaderLine("Devoluciones");
                ticket.AddHeaderLine(UseObject.AjusteDeCaracteresDerecha_(this.txtTotalDevolucion.Text));
                ticket.AddHeaderLine("---------------------------");
                ticket.AddHeaderLine("SUBTOTAL");
                ticket.AddHeaderLine(UseObject.AjusteDeCaracteresDerecha_(UseObject.InsertSeparatorMil(((
                    tIngresos.AsEnumerable().Where(i => i.Field<int>("idpago").Equals(1)).Sum(s => s.Field<int>("valor"))) -
                    tRetiros.AsEnumerable().Sum(s => s.Field<int>("valor")) -
                    UseObject.RemoveSeparatorMil(this.txtTotalDevolucion.Text)).ToString())));
                ticket.AddHeaderLine("CIERRE");
                ticket.AddHeaderLine(UseObject.AjusteDeCaracteresDerecha_(this.txtCierre.Text));
                ticket.AddHeaderLine("SALDO");
                ticket.AddHeaderLine(UseObject.AjusteDeCaracteresDerecha_(this.txtSaldo.Text));
                ticket.AddHeaderLine("---------------------------");
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("___________________________");
                ticket.AddHeaderLine("CAJER@");
                ticket.PrintTicket("");
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void LoadData()
        {
            try
            {
                var tIngresos = this.miBussinesIngreso.PrintIngresosHoras(this.Apertura_.Fecha, this.Fecha2, caja.Id, turno.Id);

                /**
                List<FacturaVenta> ventas;
                if (this.ElectronicaInvoice)
                {
                    ventas = miBussinesFacturaVenta.POSJoinElectronicInvoices(caja.Id, this.Apertura_.Fecha, this.Fecha2); 
                }
                else
                {
                    ventas = miBussinesFacturaVenta.Ventas(caja.Id, this.Apertura_.Fecha, this.Fecha2);    /// Actualización de consulta 10-08-2021
                }
                var totalCredito = ventas.Where(v => v.EstadoFactura.Id.Equals(2)).Sum(s => s.Valor);      /// Actualización de consulta 10-08-2021
                */

                var tRetiros = miBussinesRetiro.PrintRetirosHoras(this.Apertura_.Fecha, this.Fecha2, caja.Id, turno.Id);
                var tCierres = miBussinesCierre.Tcierres(this.Apertura_.Id);

                DataRow empresaRow = miBussinesEmpresa.PrintEmpresa().Tables[0].AsEnumerable().First();

                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("print_termal_80mm")))
                {
                    Ticket ticket = new Ticket();
                    ticket.UseItem = false;
                    int maxCharacters = 35;

                    foreach (var datos in UseObject.StringBuilderDataCenter(empresaRow["Nombre"].ToString().ToUpper(), maxCharacters))
                    {
                        ticket.AddHeaderLine(datos);
                    }
                    foreach (var datos in UseObject.StringBuilderDataCenter(empresaRow["Juridico"].ToString(), maxCharacters))
                    {
                        ticket.AddHeaderLine(datos);
                    }
                    foreach (var datos in UseObject.StringBuilderDataCenter(
                        "NIT " + UseObject.InsertSeparatorMilMasDigito(empresaRow["Nit"].ToString()), maxCharacters))
                    {
                        ticket.AddHeaderLine(datos);
                    }
                    foreach (var datos in UseObject.StringBuilderDataCenter(empresaRow["Direccion"].ToString(), maxCharacters))
                    {
                        ticket.AddHeaderLine(datos);
                    }
                    foreach (var datos in UseObject.StringBuilderDataCenter(empresaRow["Telefono"].ToString(), maxCharacters))
                    {
                        ticket.AddHeaderLine(datos);
                    }
                    foreach (var datos in UseObject.StringBuilderDataCenter(empresaRow["Regimen"].ToString(), maxCharacters))
                    {
                        ticket.AddHeaderLine(datos);
                    }
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("INFORME DE CAJA");
                    ticket.AddHeaderLine("Fecha : " + this.Apertura_.Fecha.ToShortDateString());
                    ticket.AddHeaderLine("Caja  : " + caja.Numero);
                    ticket.AddHeaderLine("Turno : " + turno.Numero);

                    ticket.AddHeaderLine("");

                    ticket.AddHeaderLine("MOVIMIENTO DE CAJA");
                    ticket.AddHeaderLine("-----------------------------------");
                    ticket.AddHeaderLine("     APERTURA :" + UseObject.StringBuilderDetalleTotalEspacio(
                        UseObject.InsertSeparatorMil(this.Apertura_.Valor.ToString())));
                    //ticket.AddHeaderLine("INGRESOS");
                    ticket.AddHeaderLine("     EFECTIVO :" + UseObject.StringBuilderDetalleTotalEspacio(
                        UseObject.InsertSeparatorMil(Convert.ToInt32
                        (tIngresos.AsEnumerable().Where(i => i.Field<int>("idpago").Equals(1)).Sum(s => s.Field<int>("valor")) +
                         Math.Round(this.Payments.Where(p => p.NombreFormaPago.Equals("10")).Sum(s => s.Valor), 0))
                        .ToString())));

                    ticket.AddHeaderLine("TRANSFERENCIA :" + UseObject.StringBuilderDetalleTotalEspacio(UseObject.InsertSeparatorMil(
                        (tIngresos.AsEnumerable().Where(i => i.Field<int>("idpago").Equals(4)).Sum(s => s.Field<int>("valor")) +
                        Math.Round(this.Payments.Where(p => p.NombreFormaPago.Equals("31")).Sum(s => s.Valor), 0))
                        .ToString())));

                    ticket.AddHeaderLine("      TARJETA :" + UseObject.StringBuilderDetalleTotalEspacio(UseObject.InsertSeparatorMil(
                        (tIngresos.AsEnumerable().Where(i => i.Field<int>("idpago").Equals(3)).Sum(s => s.Field<int>("valor")) +
                         Math.Round(this.Payments.Where(p => p.NombreFormaPago.Equals("49")).Sum(s => s.Valor), 0))
                        .ToString())));

                    ticket.AddHeaderLine("-----------------------------------");
                    ticket.AddHeaderLine("RETIROS");
                    foreach (DataRow rRow in tRetiros.Rows)
                    {
                        ticket.AddHeaderLine("");
                        ticket.AddHeaderLine("Fecha:    " + Convert.ToDateTime(rRow["fecha"]).ToShortDateString() + " " +
                                                            Convert.ToDateTime(rRow["hora"]).ToShortTimeString());
                        ticket.AddHeaderLine("Concepto: " + rRow["concepto"].ToString());
                        ticket.AddHeaderLine("Valor:    " + UseObject.InsertSeparatorMil(rRow["valor"].ToString()));
                    }
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("TOTAL RETIROS :" + UseObject.StringBuilderDetalleTotalEspacio(UseObject.InsertSeparatorMil(
                        tRetiros.AsEnumerable().Sum(s => s.Field<int>("valor")).ToString())));
                    ticket.AddHeaderLine("-----------------------------------");
                    ticket.AddHeaderLine("DEVOLUCIONES  :" + UseObject.StringBuilderDetalleTotalEspacio(this.txtTotalDevolucion.Text));
                    ticket.AddHeaderLine("-----------------------------------");
                    ticket.AddHeaderLine("TOTAL INGRESOS:" + UseObject.StringBuilderDetalleTotalEspacio(UseObject.InsertSeparatorMil((
                        (this.Apertura_.Valor + 
                         tIngresos.AsEnumerable().Sum(s => s.Field<int>("valor")) +
                         Convert.ToInt32(this.Payments.Sum(s => s.Valor))) -
                         tRetiros.AsEnumerable().Sum(s => s.Field<int>("valor")) -
                         UseObject.RemoveSeparatorMil(this.txtTotalDevolucion.Text)).ToString())));
                    ticket.AddHeaderLine("-----------------------------------");
                    ticket.AddHeaderLine("CIERRE DE CAJA");
                    ticket.AddHeaderLine("");

                    ticket.AddHeaderLine("     EFECTIVO :" + UseObject.StringBuilderDetalleTotalEspacio(UseObject.InsertSeparatorMil(
                        tCierres.AsEnumerable().Where(i => i.Field<int>("idpago").Equals(1)).Sum(s => s.Field<int>("valor")).ToString())));
                    ticket.AddHeaderLine("TRANSFERENCIA :" + UseObject.StringBuilderDetalleTotalEspacio(UseObject.InsertSeparatorMil(
                        tCierres.AsEnumerable().Where(i => i.Field<int>("idpago").Equals(4)).Sum(s => s.Field<int>("valor")).ToString())));
                    ticket.AddHeaderLine("      TARJETA :" + UseObject.StringBuilderDetalleTotalEspacio(UseObject.InsertSeparatorMil(
                        tCierres.AsEnumerable().Where(i => i.Field<int>("idpago").Equals(3)).Sum(s => s.Field<int>("valor")).ToString())));
                    ticket.AddHeaderLine("     ***TOTAL :" + UseObject.StringBuilderDetalleTotalEspacio(UseObject.InsertSeparatorMil(
                        tCierres.AsEnumerable().Sum(s => s.Field<int>("valor")).ToString())));
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("      **SALDO :" + UseObject.StringBuilderDetalleTotalEspacio(this.txtSaldo.Text));
                    ticket.AddHeaderLine("-----------------------------------");


                   /* ticket.AddHeaderLine("      RETIROS :" + UseObject.StringBuilderDetalleTotalEspacio(UseObject.InsertSeparatorMil(
                        tRetiros.AsEnumerable().Sum(s => s.Field<int>("valor")).ToString())));
                    ticket.AddHeaderLine(" DEVOLUCIONES :" + UseObject.StringBuilderDetalleTotalEspacio(this.txtTotalDevolucion.Text));

                    ticket.AddHeaderLine("EFEC. EN CAJA :" + UseObject.StringBuilderDetalleTotalEspacio(UseObject.InsertSeparatorMil((
                        (this.Apertura_.Valor + 
                         tIngresos.AsEnumerable().Where(i => i.Field<int>("idpago").Equals(1)).Sum(s => s.Field<int>("valor")) +
                         Convert.ToInt32(this.Payments.Where(p => p.NombreFormaPago.Equals("10")).Sum(s => s.Valor))) -
                        tRetiros.AsEnumerable().Sum(s => s.Field<int>("valor")) -
                        UseObject.RemoveSeparatorMil(this.txtTotalDevolucion.Text)).ToString())));

                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("CIERRE DE CAJA:" + UseObject.StringBuilderDetalleTotalEspacio(this.txtCierre.Text));
                    ticket.AddHeaderLine("         SALDO:" + UseObject.StringBuilderDetalleTotalEspacio(this.txtSaldo.Text));*/

                    

                    /**
                    ticket.AddHeaderLine("CREDITOS:      " + UseObject.StringBuilderDetalleTotalEspacio(
                        UseObject.InsertSeparatorMil(totalCredito.ToString())));
                    
                    ticket.AddHeaderLine("-----------------------------------");

                    ticket.AddHeaderLine("TOTAL VENTAS:  " + UseObject.StringBuilderDetalleTotalEspacio(
                                                             UseObject.InsertSeparatorMil(ventas.Sum(s => s.Valor).ToString())));   /// Actualización 10-08-2021
                    

                    ticket.AddHeaderLine("-----------------------------------");
                    */

                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("___________________________________");
                    ticket.AddHeaderLine("CAJERO. C.C.");
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("");

                    ticket.PrintTicket("");
                }
                else
                {
                    PrintPos58mm(caja, turno, tIngresos, 0, tRetiros, empresaRow);
                }

                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(EndLoad));
                }
            }
            catch (Exception ex)
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(EndLoad));
                }
                OptionPane.MessageError(ex.Message);
            }
        }

        private void EndLoad()
        {
            this.btnInformeGeneral.Enabled = true;
        }


        private void btnInformeGeneral_Click_(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("consultaVenta")))
                {
                    var apertura = miBussinesApertura.Apertura(this.dtpFecha.Value, Convert.ToInt32(cbCaja.SelectedValue));

                    var caja = miBussinesCaja.CajaId(Convert.ToInt32(this.cbCaja.SelectedValue));
                    var turno = miBussinesTurno.TurnoId(Convert.ToInt32(this.cbTurno.SelectedValue));

                    var tIngresos = miBussinesIngreso.PrintIngresos(this.dtpFecha.Value, caja.Id, turno.Id);
                    var tCreditos = miBussinesFacturaVenta.TotalFacturasCredito(2, caja.Id, apertura.Fecha, true).Tables[0];
                    var tRetiros = miBussinesRetiro.PrintRetiros(apertura.Fecha, caja.Id, turno.Id);

                    //var apertura = miBussinesApertura.Apertura(this.dtpFecha.Value, caja.Id, turno.Id);
                    var tCierres = miBussinesCierre.Print(apertura.Id);

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
                    ticket.AddHeaderLine("INFORME DE CAJA");
                    ticket.AddHeaderLine("Fecha : " + dtpFecha.Value.ToShortDateString());
                    ticket.AddHeaderLine("Caja  : " + caja.Numero);
                    ticket.AddHeaderLine("Turno : " + turno.Numero);

                    ticket.AddHeaderLine("");

                    ticket.AddHeaderLine("Movimiento de caja");
                    ticket.AddHeaderLine("-----------------------------------");
                    ticket.AddHeaderLine("Ingresos en efectivo:");
                    ticket.AddHeaderLine("Apertura:       " +
                                      UseObject.InsertSeparatorMil(apertura.Valor.ToString()));
                    /*  foreach (DataRow ingRow in tIngresos.Rows)
                      {
                          var j = ingRow;
                      }*/
                    ticket.AddHeaderLine("Vent. Efectivo: " + UseObject.InsertSeparatorMil(
                        tIngresos.AsEnumerable().Where(i => i.Field<int>("idpago").Equals(1)).Sum(s => s.Field<int>("valor")).ToString()));
                    ticket.AddHeaderLine("TOTAL:          " + UseObject.InsertSeparatorMil((apertura.Valor +
                        tIngresos.AsEnumerable().Where(i => i.Field<int>("idpago").Equals(1)).Sum(s => s.Field<int>("valor"))).ToString()));
                    ticket.AddHeaderLine("-----------------------------------");
                    ticket.AddHeaderLine("Retiros:");
                    foreach (DataRow rRow in tRetiros.Rows)
                    {
                        ticket.AddHeaderLine("");
                        ticket.AddHeaderLine("Hora:     " + Convert.ToDateTime(rRow["hora"]).ToShortTimeString());
                        ticket.AddHeaderLine("Concepto: " + rRow["concepto"].ToString());
                        ticket.AddHeaderLine("Valor:    " + UseObject.InsertSeparatorMil(rRow["valor"].ToString()));
                    }
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("TOTAL RETIROS: " + UseObject.InsertSeparatorMil(
                        tRetiros.AsEnumerable().Sum(s => s.Field<int>("valor")).ToString()));
                    ticket.AddHeaderLine("-----------------------------------");
                    ticket.AddHeaderLine("Devoluciones:");
                    ticket.AddHeaderLine("TOTAL: " + this.txtTotalDevolucion.Text);
                    ticket.AddHeaderLine("-----------------------------------");
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("CUADRE DE CAJA");
                    ticket.AddHeaderLine("Ingr. Efectivo: " + UseObject.InsertSeparatorMil((apertura.Valor +
                        tIngresos.AsEnumerable().Where(i => i.Field<int>("idpago").Equals(1)).Sum(s => s.Field<int>("valor"))).ToString()));
                    ticket.AddHeaderLine("Retiros:        " + UseObject.InsertSeparatorMil(
                        tRetiros.AsEnumerable().Sum(s => s.Field<int>("valor")).ToString()));
                    ticket.AddHeaderLine("Devoluciones:   " + this.txtTotalDevolucion.Text);
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("(Ingr. Efectivo-Retiro-Devol.)");
                    ticket.AddHeaderLine("TOTAL:          " + UseObject.InsertSeparatorMil(((apertura.Valor +
                        tIngresos.AsEnumerable().Where(i => i.Field<int>("idpago").Equals(1)).Sum(s => s.Field<int>("valor"))) -
                        tRetiros.AsEnumerable().Sum(s => s.Field<int>("valor")) -
                        UseObject.RemoveSeparatorMil(this.txtTotalDevolucion.Text)).ToString()));
                    ticket.AddHeaderLine("EFEC. EN CAJA:  " + UseObject.InsertSeparatorMil(((apertura.Valor +
                        tIngresos.AsEnumerable().Where(i => i.Field<int>("idpago").Equals(1)).Sum(s => s.Field<int>("valor"))) -
                        tRetiros.AsEnumerable().Sum(s => s.Field<int>("valor")) -
                        UseObject.RemoveSeparatorMil(this.txtTotalDevolucion.Text)).ToString()));
                    ticket.AddHeaderLine("-----------------------------------");
                    ticket.AddHeaderLine("OTRAS FORMAS DE PAGO");
                    ticket.AddHeaderLine("Cheque: " + UseObject.InsertSeparatorMil(
                        tIngresos.AsEnumerable().Where(i => i.Field<int>("idpago").Equals(2)).Sum(s => s.Field<int>("valor")).ToString()));
                    ticket.AddHeaderLine("Transacción: " + UseObject.InsertSeparatorMil(
                        tIngresos.AsEnumerable().Where(i => i.Field<int>("idpago").Equals(4)).Sum(s => s.Field<int>("valor")).ToString()));
                    /*foreach (DataRow iRow in tIngresos.Rows)
                    {
                        if (!Convert.ToInt32(iRow["idpago"]).Equals(1))
                        {
                            ticket.AddHeaderLine("Cheque: " + 
                            //ticket.AddHeaderLine(iRow["pago"].ToString() + ":  " + UseObject.InsertSeparatorMil(iRow["valor"].ToString()));
                        }

                    }*/
                    ticket.AddHeaderLine("Crédito: " +
                        UseObject.InsertSeparatorMil(tCreditos.AsEnumerable().Sum(s => s.Field<int>("TotalC")).ToString()));
                    ticket.AddHeaderLine("TOTAL: " + UseObject.InsertSeparatorMil((
                        tIngresos.AsEnumerable().Where(i => i.Field<int>("idpago") != 1).Sum(s => s.Field<int>("valor")) +
                        tCreditos.AsEnumerable().Sum(s => s.Field<int>("TotalC"))).ToString()));
                    ticket.AddHeaderLine("-----------------------------------");
                    ticket.AddHeaderLine("Total Ventas: " + UseObject.InsertSeparatorMil((
                        tIngresos.AsEnumerable().Sum(s => s.Field<int>("valor")) + tCreditos.AsEnumerable().Sum(s => s.Field<int>("TotalC"))).ToString()));
                    ticket.AddHeaderLine("-----------------------------------");
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("___________________________________");
                    ticket.AddHeaderLine("CAJERO. C.C.");
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("");

                    ticket.PrintTicket("IMPREPOS");
                }
                else
                {
                    //var miBussinesCierre = new BussinesCierre();

                    DateTime fecha2 = this.dtpFecha.Value;
                    var apertura = miBussinesApertura.Apertura(this.dtpFecha.Value, Convert.ToInt32(cbCaja.SelectedValue));
                    if (apertura.Id.Equals(0))
                    {
                        apertura = miBussinesApertura.AperturaAnterior(this.dtpFecha.Value, Convert.ToInt32(cbCaja.SelectedValue));
                    }
                    var cierre = miBussinesCierre.Cierre(apertura.Id);
                    if (!cierre.Id.Equals(0))
                    {
                        fecha2 = cierre.Fecha;
                    }

                    if (UseDate.FechaSinHora(apertura.Fecha).Equals(UseDate.FechaSinHora(fecha2))) //(apertura.Fecha.Equals(fecha2))
                    {
                        // consulta por la misma fecha y en rango de horas.

                        DataRow empresaRow = miBussinesEmpresa.PrintEmpresa().
                                Tables[0].AsEnumerable().First();

                        var caja = miBussinesCaja.CajaId(Convert.ToInt32(this.cbCaja.SelectedValue));
                        var turno = miBussinesTurno.TurnoId(Convert.ToInt32(this.cbTurno.SelectedValue));

                        var tIngresos = miBussinesIngreso.PrintIngresosHoras(apertura.Fecha, fecha2, caja.Id, turno.Id);
                        var tCreditos = miBussinesFacturaVenta.TotalFacturasCreditoHoras(2, caja.Id, apertura.Fecha, fecha2);
                        var tRetiros = miBussinesRetiro.PrintRetirosHoras(apertura.Fecha, fecha2, caja.Id, turno.Id);
                        var tCierres = miBussinesCierre.Print(apertura.Id);

                        Ticket ticket = new Ticket();

                        ticket.UseItem = false;
                        ticket.AddHeaderLine(empresaRow["Nombre"].ToString().ToUpper());
                        ticket.AddHeaderLine(empresaRow["Juridico"].ToString());
                        ticket.AddHeaderLine("NIT " + UseObject.InsertSeparatorMilMasDigito(empresaRow["Nit"].ToString()));
                        ticket.AddHeaderLine("Régimen: " + empresaRow["Regimen"].ToString());
                        ticket.AddHeaderLine(empresaRow["Direccion"].ToString());
                        ticket.AddHeaderLine("");
                        ticket.AddHeaderLine("INFORME DE CAJA");
                        ticket.AddHeaderLine("Fecha : " + dtpFecha.Value.ToShortDateString());
                        ticket.AddHeaderLine("Caja  : " + caja.Numero);
                        ticket.AddHeaderLine("Turno : " + turno.Numero);

                        ticket.AddHeaderLine("");

                        ticket.AddHeaderLine("Movimiento de caja");
                        ticket.AddHeaderLine("-----------------------------------");
                        ticket.AddHeaderLine("Ingresos en efectivo:");
                        ticket.AddHeaderLine("Apertura:       " +
                                          UseObject.InsertSeparatorMil(apertura.Valor.ToString()));
                        /*  foreach (DataRow ingRow in tIngresos.Rows)
                          {
                              var j = ingRow;
                          }*/
                        ticket.AddHeaderLine("Vent. Efectivo: " + UseObject.InsertSeparatorMil(
                            tIngresos.AsEnumerable().Where(i => i.Field<int>("idpago").Equals(1)).Sum(s => s.Field<int>("valor")).ToString()));
                        ticket.AddHeaderLine("TOTAL:          " + UseObject.InsertSeparatorMil((apertura.Valor +
                            tIngresos.AsEnumerable().Where(i => i.Field<int>("idpago").Equals(1)).Sum(s => s.Field<int>("valor"))).ToString()));
                        ticket.AddHeaderLine("-----------------------------------");
                        ticket.AddHeaderLine("Retiros:");
                        foreach (DataRow rRow in tRetiros.Rows)
                        {
                            ticket.AddHeaderLine("");
                            ticket.AddHeaderLine("Hora:     " + Convert.ToDateTime(rRow["hora"]).ToShortTimeString());
                            ticket.AddHeaderLine("Concepto: " + rRow["concepto"].ToString());
                            ticket.AddHeaderLine("Valor:    " + UseObject.InsertSeparatorMil(rRow["valor"].ToString()));
                        }
                        ticket.AddHeaderLine("");
                        ticket.AddHeaderLine("TOTAL RETIROS: " + UseObject.InsertSeparatorMil(
                            tRetiros.AsEnumerable().Sum(s => s.Field<int>("valor")).ToString()));
                        ticket.AddHeaderLine("-----------------------------------");
                        ticket.AddHeaderLine("Devoluciones:");
                        ticket.AddHeaderLine("TOTAL: " + this.txtTotalDevolucion.Text);
                        ticket.AddHeaderLine("-----------------------------------");
                        ticket.AddHeaderLine("");
                        ticket.AddHeaderLine("CUADRE DE CAJA");
                        ticket.AddHeaderLine("Ingr. Efectivo: " + UseObject.InsertSeparatorMil((apertura.Valor +
                            tIngresos.AsEnumerable().Where(i => i.Field<int>("idpago").Equals(1)).Sum(s => s.Field<int>("valor"))).ToString()));
                        ticket.AddHeaderLine("Retiros:        " + UseObject.InsertSeparatorMil(
                            tRetiros.AsEnumerable().Sum(s => s.Field<int>("valor")).ToString()));
                        ticket.AddHeaderLine("Devoluciones:   " + this.txtTotalDevolucion.Text);
                        ticket.AddHeaderLine("");
                        ticket.AddHeaderLine("(Ingr. Efectivo-Retiro-Devol.)");
                        ticket.AddHeaderLine("TOTAL:          " + UseObject.InsertSeparatorMil(((apertura.Valor +
                            tIngresos.AsEnumerable().Where(i => i.Field<int>("idpago").Equals(1)).Sum(s => s.Field<int>("valor"))) -
                            tRetiros.AsEnumerable().Sum(s => s.Field<int>("valor")) -
                            UseObject.RemoveSeparatorMil(this.txtTotalDevolucion.Text)).ToString()));
                        ticket.AddHeaderLine("EFEC. EN CAJA:  " + UseObject.InsertSeparatorMil(((apertura.Valor +
                            tIngresos.AsEnumerable().Where(i => i.Field<int>("idpago").Equals(1)).Sum(s => s.Field<int>("valor"))) -
                            tRetiros.AsEnumerable().Sum(s => s.Field<int>("valor")) -
                            UseObject.RemoveSeparatorMil(this.txtTotalDevolucion.Text)).ToString()));
                        ticket.AddHeaderLine("-----------------------------------");
                        ticket.AddHeaderLine("OTRAS FORMAS DE PAGO");
                        ticket.AddHeaderLine("Cheque: " + UseObject.InsertSeparatorMil(
                            tIngresos.AsEnumerable().Where(i => i.Field<int>("idpago").Equals(2)).Sum(s => s.Field<int>("valor")).ToString()));
                        ticket.AddHeaderLine("Transacción: " + UseObject.InsertSeparatorMil(
                            tIngresos.AsEnumerable().Where(i => i.Field<int>("idpago").Equals(4)).Sum(s => s.Field<int>("valor")).ToString()));
                        /*foreach (DataRow iRow in tIngresos.Rows)
                        {
                            if (!Convert.ToInt32(iRow["idpago"]).Equals(1))
                            {
                                ticket.AddHeaderLine("Cheque: " + 
                                //ticket.AddHeaderLine(iRow["pago"].ToString() + ":  " + UseObject.InsertSeparatorMil(iRow["valor"].ToString()));
                            }

                        }*/
                        ticket.AddHeaderLine("Crédito: " +
                            UseObject.InsertSeparatorMil(tCreditos.AsEnumerable().Sum(s => s.Field<int>("TotalC")).ToString()));
                        ticket.AddHeaderLine("TOTAL: " + UseObject.InsertSeparatorMil((
                            tIngresos.AsEnumerable().Where(i => i.Field<int>("idpago") != 1).Sum(s => s.Field<int>("valor")) +
                            tCreditos.AsEnumerable().Sum(s => s.Field<int>("TotalC"))).ToString()));
                        ticket.AddHeaderLine("-----------------------------------");
                        ticket.AddHeaderLine("Total Ventas: " + UseObject.InsertSeparatorMil((
                            tIngresos.AsEnumerable().Sum(s => s.Field<int>("valor")) + tCreditos.AsEnumerable().Sum(s => s.Field<int>("TotalC"))).ToString()));
                        ticket.AddHeaderLine("-----------------------------------");
                        ticket.AddHeaderLine("");
                        ticket.AddHeaderLine("");
                        ticket.AddHeaderLine("");
                        ticket.AddHeaderLine("___________________________________");
                        ticket.AddHeaderLine("CAJERO. C.C.");
                        ticket.AddHeaderLine("");
                        ticket.AddHeaderLine("");

                        ticket.PrintTicket("IMPREPOS");
                        // fin consulta por la misma fecha y en rango de horas.
                        //***************************************************
                    }
                    else
                    {

                        DataRow empresaRow = miBussinesEmpresa.PrintEmpresa().
                                Tables[0].AsEnumerable().First();

                        var caja = miBussinesCaja.CajaId(Convert.ToInt32(this.cbCaja.SelectedValue));
                        var turno = miBussinesTurno.TurnoId(Convert.ToInt32(this.cbTurno.SelectedValue));

                        var tIngresos = miBussinesIngreso.PrintIngresos(apertura.Fecha, fecha2, caja.Id, turno.Id);
                        var tCreditos = miBussinesFacturaVenta.TotalFacturasCredito(2, caja.Id, apertura.Fecha, fecha2);
                        var tRetiros = miBussinesRetiro.PrintRetiros(apertura.Fecha, fecha2, caja.Id, turno.Id);

                        //var apertura = miBussinesApertura.Apertura(this.dtpFecha.Value, caja.Id, turno.Id);
                        var tCierres = miBussinesCierre.Print(apertura.Id);

                        Ticket ticket = new Ticket();

                        ticket.UseItem = false;
                        ticket.AddHeaderLine(empresaRow["Nombre"].ToString().ToUpper());
                        ticket.AddHeaderLine(empresaRow["Juridico"].ToString());
                        ticket.AddHeaderLine("NIT " + UseObject.InsertSeparatorMilMasDigito(empresaRow["Nit"].ToString()));
                        ticket.AddHeaderLine("Régimen: " + empresaRow["Regimen"].ToString());
                        ticket.AddHeaderLine(empresaRow["Direccion"].ToString());
                        ticket.AddHeaderLine("");
                        ticket.AddHeaderLine("INFORME DE CAJA");
                        ticket.AddHeaderLine("Fecha : " + dtpFecha.Value.ToShortDateString());
                        ticket.AddHeaderLine("Caja  : " + caja.Numero);
                        ticket.AddHeaderLine("Turno : " + turno.Numero);

                        ticket.AddHeaderLine("");

                        ticket.AddHeaderLine("Movimiento de caja");
                        ticket.AddHeaderLine("-----------------------------------");
                        ticket.AddHeaderLine("Ingresos en efectivo:");
                        ticket.AddHeaderLine("Apertura:       " +
                                          UseObject.InsertSeparatorMil(apertura.Valor.ToString()));
                        /*  foreach (DataRow ingRow in tIngresos.Rows)
                          {
                              var j = ingRow;
                          }*/
                        ticket.AddHeaderLine("Vent. Efectivo: " + UseObject.InsertSeparatorMil(
                            tIngresos.AsEnumerable().Where(i => i.Field<int>("idpago").Equals(1)).Sum(s => s.Field<int>("valor")).ToString()));
                        ticket.AddHeaderLine("TOTAL:          " + UseObject.InsertSeparatorMil((apertura.Valor +
                            tIngresos.AsEnumerable().Where(i => i.Field<int>("idpago").Equals(1)).Sum(s => s.Field<int>("valor"))).ToString()));
                        ticket.AddHeaderLine("-----------------------------------");
                        ticket.AddHeaderLine("Retiros:");
                        foreach (DataRow rRow in tRetiros.Rows)
                        {
                            ticket.AddHeaderLine("");
                            ticket.AddHeaderLine("Hora:     " + Convert.ToDateTime(rRow["hora"]).ToShortTimeString());
                            ticket.AddHeaderLine("Concepto: " + rRow["concepto"].ToString());
                            ticket.AddHeaderLine("Valor:    " + UseObject.InsertSeparatorMil(rRow["valor"].ToString()));
                        }
                        ticket.AddHeaderLine("");
                        ticket.AddHeaderLine("TOTAL RETIROS: " + UseObject.InsertSeparatorMil(
                            tRetiros.AsEnumerable().Sum(s => s.Field<int>("valor")).ToString()));
                        ticket.AddHeaderLine("-----------------------------------");
                        ticket.AddHeaderLine("Devoluciones:");
                        ticket.AddHeaderLine("TOTAL: " + this.txtTotalDevolucion.Text);
                        ticket.AddHeaderLine("-----------------------------------");
                        ticket.AddHeaderLine("");
                        ticket.AddHeaderLine("CUADRE DE CAJA");
                        ticket.AddHeaderLine("Ingr. Efectivo: " + UseObject.InsertSeparatorMil((apertura.Valor +
                            tIngresos.AsEnumerable().Where(i => i.Field<int>("idpago").Equals(1)).Sum(s => s.Field<int>("valor"))).ToString()));
                        ticket.AddHeaderLine("Retiros:        " + UseObject.InsertSeparatorMil(
                            tRetiros.AsEnumerable().Sum(s => s.Field<int>("valor")).ToString()));
                        ticket.AddHeaderLine("Devoluciones:   " + this.txtTotalDevolucion.Text);
                        ticket.AddHeaderLine("");
                        ticket.AddHeaderLine("(Ingr. Efectivo-Retiro-Devol.)");
                        ticket.AddHeaderLine("TOTAL:          " + UseObject.InsertSeparatorMil(((apertura.Valor +
                            tIngresos.AsEnumerable().Where(i => i.Field<int>("idpago").Equals(1)).Sum(s => s.Field<int>("valor"))) -
                            tRetiros.AsEnumerable().Sum(s => s.Field<int>("valor")) -
                            UseObject.RemoveSeparatorMil(this.txtTotalDevolucion.Text)).ToString()));
                        ticket.AddHeaderLine("EFEC. EN CAJA:  " + UseObject.InsertSeparatorMil(((apertura.Valor +
                            tIngresos.AsEnumerable().Where(i => i.Field<int>("idpago").Equals(1)).Sum(s => s.Field<int>("valor"))) -
                            tRetiros.AsEnumerable().Sum(s => s.Field<int>("valor")) -
                            UseObject.RemoveSeparatorMil(this.txtTotalDevolucion.Text)).ToString()));
                        ticket.AddHeaderLine("-----------------------------------");
                        ticket.AddHeaderLine("OTRAS FORMAS DE PAGO");
                        ticket.AddHeaderLine("Cheque: " + UseObject.InsertSeparatorMil(
                            tIngresos.AsEnumerable().Where(i => i.Field<int>("idpago").Equals(2)).Sum(s => s.Field<int>("valor")).ToString()));
                        ticket.AddHeaderLine("Transacción: " + UseObject.InsertSeparatorMil(
                            tIngresos.AsEnumerable().Where(i => i.Field<int>("idpago").Equals(4)).Sum(s => s.Field<int>("valor")).ToString()));
                        /*foreach (DataRow iRow in tIngresos.Rows)
                        {
                            if (!Convert.ToInt32(iRow["idpago"]).Equals(1))
                            {
                                ticket.AddHeaderLine("Cheque: " + 
                                //ticket.AddHeaderLine(iRow["pago"].ToString() + ":  " + UseObject.InsertSeparatorMil(iRow["valor"].ToString()));
                            }

                        }*/
                        ticket.AddHeaderLine("Crédito: " +
                            UseObject.InsertSeparatorMil(tCreditos.AsEnumerable().Sum(s => s.Field<int>("TotalC")).ToString()));
                        ticket.AddHeaderLine("TOTAL: " + UseObject.InsertSeparatorMil((
                            tIngresos.AsEnumerable().Where(i => i.Field<int>("idpago") != 1).Sum(s => s.Field<int>("valor")) +
                            tCreditos.AsEnumerable().Sum(s => s.Field<int>("TotalC"))).ToString()));
                        ticket.AddHeaderLine("-----------------------------------");
                        ticket.AddHeaderLine("Total Ventas: " + UseObject.InsertSeparatorMil((
                            tIngresos.AsEnumerable().Sum(s => s.Field<int>("valor")) + tCreditos.AsEnumerable().Sum(s => s.Field<int>("TotalC"))).ToString()));
                        ticket.AddHeaderLine("-----------------------------------");
                        ticket.AddHeaderLine("");
                        ticket.AddHeaderLine("");
                        ticket.AddHeaderLine("");
                        ticket.AddHeaderLine("___________________________________");
                        ticket.AddHeaderLine("CAJERO. C.C.");
                        ticket.AddHeaderLine("");
                        ticket.AddHeaderLine("");

                        ticket.PrintTicket("IMPREPOS");
                    }
                }

                /*var miBussinesCierre = new BussinesCierre();

                DateTime fecha2 = this.dtpFecha.Value;
                var apertura = miBussinesApertura.Apertura(this.dtpFecha.Value, Convert.ToInt32(cbCaja.SelectedValue));
                if (apertura.Id.Equals(0))
                {
                    apertura = miBussinesApertura.AperturaAnterior(this.dtpFecha.Value, Convert.ToInt32(cbCaja.SelectedValue));
                }
                var cierre = miBussinesCierre.Cierre(apertura.Id);
                if (!cierre.Id.Equals(0))
                {
                    fecha2 = cierre.Fecha;
                }

                DataRow empresaRow = miBussinesEmpresa.PrintEmpresa().
                        Tables[0].AsEnumerable().First();

                var caja = miBussinesCaja.CajaId(Convert.ToInt32(this.cbCaja.SelectedValue));
                var turno = miBussinesTurno.TurnoId(Convert.ToInt32(this.cbTurno.SelectedValue));

                var tIngresos = miBussinesIngreso.PrintIngresos(apertura.Fecha, fecha2, caja.Id, turno.Id);
                var tCreditos = miBussinesFacturaVenta.TotalFacturasCredito(2, caja.Id, apertura.Fecha, fecha2);
                var tRetiros = miBussinesRetiro.PrintRetiros(apertura.Fecha, fecha2, caja.Id, turno.Id);

                //var apertura = miBussinesApertura.Apertura(this.dtpFecha.Value, caja.Id, turno.Id);
                var tCierres = miBussinesCierre.Print(apertura.Id);

                Ticket ticket = new Ticket();

                ticket.UseItem = false;
                ticket.AddHeaderLine(empresaRow["Nombre"].ToString().ToUpper());
                ticket.AddHeaderLine(empresaRow["Juridico"].ToString());
                ticket.AddHeaderLine("NIT " + UseObject.InsertSeparatorMilMasDigito(empresaRow["Nit"].ToString()));
                ticket.AddHeaderLine("Régimen: " + empresaRow["Regimen"].ToString());
                ticket.AddHeaderLine(empresaRow["Direccion"].ToString());
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("INFORME DE CAJA");
                ticket.AddHeaderLine("Fecha : " + dtpFecha.Value.ToShortDateString());
                ticket.AddHeaderLine("Caja  : " + caja.Numero);
                ticket.AddHeaderLine("Turno : " + turno.Numero);

                ticket.AddHeaderLine("");

                ticket.AddHeaderLine("Movimiento de caja");
                ticket.AddHeaderLine("-----------------------------------");
                ticket.AddHeaderLine("Ingresos en efectivo:");
                ticket.AddHeaderLine("Apertura:       " +
                                  UseObject.InsertSeparatorMil(apertura.Valor.ToString()));*/
                /*  foreach (DataRow ingRow in tIngresos.Rows)
                  {
                      var j = ingRow;
                  }*/
                /*  ticket.AddHeaderLine("Vent. Efectivo: " + UseObject.InsertSeparatorMil(
                      tIngresos.AsEnumerable().Where(i => i.Field<int>("idpago").Equals(1)).Sum(s => s.Field<int>("valor")).ToString()));
                  ticket.AddHeaderLine("TOTAL:          " + UseObject.InsertSeparatorMil((apertura.Valor +
                      tIngresos.AsEnumerable().Where(i => i.Field<int>("idpago").Equals(1)).Sum(s => s.Field<int>("valor"))).ToString()));
                  ticket.AddHeaderLine("-----------------------------------");
                  ticket.AddHeaderLine("Retiros:");
                  foreach (DataRow rRow in tRetiros.Rows)
                  {
                      ticket.AddHeaderLine("");
                      ticket.AddHeaderLine("Hora:     " + Convert.ToDateTime(rRow["hora"]).ToShortTimeString());
                      ticket.AddHeaderLine("Concepto: " + rRow["concepto"].ToString());
                      ticket.AddHeaderLine("Valor:    " + UseObject.InsertSeparatorMil(rRow["valor"].ToString()));
                  }
                  ticket.AddHeaderLine("");
                  ticket.AddHeaderLine("TOTAL RETIROS: " + UseObject.InsertSeparatorMil(
                      tRetiros.AsEnumerable().Sum(s => s.Field<int>("valor")).ToString()));
                  ticket.AddHeaderLine("-----------------------------------");
                  ticket.AddHeaderLine("Devoluciones:");
                  ticket.AddHeaderLine("TOTAL: " + this.txtTotalDevolucion.Text);
                  ticket.AddHeaderLine("-----------------------------------");
                  ticket.AddHeaderLine("");
                  ticket.AddHeaderLine("CUADRE DE CAJA");
                  ticket.AddHeaderLine("Ingr. Efectivo: " + UseObject.InsertSeparatorMil((apertura.Valor +
                      tIngresos.AsEnumerable().Where(i => i.Field<int>("idpago").Equals(1)).Sum(s => s.Field<int>("valor"))).ToString()));
                  ticket.AddHeaderLine("Retiros:        " + UseObject.InsertSeparatorMil(
                      tRetiros.AsEnumerable().Sum(s => s.Field<int>("valor")).ToString()));
                  ticket.AddHeaderLine("Devoluciones:   " + this.txtTotalDevolucion.Text);
                  ticket.AddHeaderLine("");
                  ticket.AddHeaderLine("(Ingr. Efectivo-Retiro-Devol.)");
                  ticket.AddHeaderLine("TOTAL:          " + UseObject.InsertSeparatorMil(((apertura.Valor +
                      tIngresos.AsEnumerable().Where(i => i.Field<int>("idpago").Equals(1)).Sum(s => s.Field<int>("valor"))) -
                      tRetiros.AsEnumerable().Sum(s => s.Field<int>("valor")) -
                      UseObject.RemoveSeparatorMil(this.txtTotalDevolucion.Text)).ToString()));
                  ticket.AddHeaderLine("EFEC. EN CAJA:  " + UseObject.InsertSeparatorMil(((apertura.Valor +
                      tIngresos.AsEnumerable().Where(i => i.Field<int>("idpago").Equals(1)).Sum(s => s.Field<int>("valor"))) -
                      tRetiros.AsEnumerable().Sum(s => s.Field<int>("valor")) -
                      UseObject.RemoveSeparatorMil(this.txtTotalDevolucion.Text)).ToString()));
                  ticket.AddHeaderLine("-----------------------------------");
                  ticket.AddHeaderLine("OTRAS FORMAS DE PAGO");
                  ticket.AddHeaderLine("Cheque: " + UseObject.InsertSeparatorMil(
                      tIngresos.AsEnumerable().Where(i => i.Field<int>("idpago").Equals(2)).Sum(s => s.Field<int>("valor")).ToString()));
                  ticket.AddHeaderLine("Transacción: " + UseObject.InsertSeparatorMil(
                      tIngresos.AsEnumerable().Where(i => i.Field<int>("idpago").Equals(4)).Sum(s => s.Field<int>("valor")).ToString()));*/
                /*foreach (DataRow iRow in tIngresos.Rows)
                {
                    if (!Convert.ToInt32(iRow["idpago"]).Equals(1))
                    {
                        ticket.AddHeaderLine("Cheque: " + 
                        //ticket.AddHeaderLine(iRow["pago"].ToString() + ":  " + UseObject.InsertSeparatorMil(iRow["valor"].ToString()));
                    }

                }*/
                /*  ticket.AddHeaderLine("Crédito: " +
                      UseObject.InsertSeparatorMil(tCreditos.AsEnumerable().Sum(s => s.Field<int>("TotalC")).ToString()));
                  ticket.AddHeaderLine("TOTAL: " + UseObject.InsertSeparatorMil((
                      tIngresos.AsEnumerable().Where(i => i.Field<int>("idpago") != 1).Sum(s => s.Field<int>("valor")) +
                      tCreditos.AsEnumerable().Sum(s => s.Field<int>("TotalC"))).ToString()));
                  ticket.AddHeaderLine("-----------------------------------");
                  ticket.AddHeaderLine("Total Ventas: " + UseObject.InsertSeparatorMil((
                      tIngresos.AsEnumerable().Sum(s => s.Field<int>("valor")) + tCreditos.AsEnumerable().Sum(s => s.Field<int>("TotalC"))).ToString()));
                  ticket.AddHeaderLine("-----------------------------------");
                  ticket.AddHeaderLine("");
                  ticket.AddHeaderLine("");
                  ticket.AddHeaderLine("");
                  ticket.AddHeaderLine("___________________________________");
                  ticket.AddHeaderLine("CAJERO. C.C.");
                  ticket.AddHeaderLine("");
                  ticket.AddHeaderLine("");*/




                /*ticket.AddHeaderLine("");
                ticket.AddHeaderLine("APERTURA : $" +
                                  UseObject.InsertSeparatorMil(apertura.Valor.ToString()));
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("INGRESOS");
                ticket.AddHeaderLine("");
                foreach (DataRow iRow in tIngresos.Rows)
                {
                    ticket.AddHeaderLine(iRow["pago"].ToString() + " : " +
                                         UseObject.InsertSeparatorMil(iRow["valor"].ToString()));
                    ticket.AddHeaderLine("");
                }
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("RETIROS");
                ticket.AddHeaderLine("");
              /*  foreach (DataRow rRow in tRetiros.Rows)
                {
                    ticket.AddHeaderLine(rRow["pago"].ToString() + " : " +
                                         UseObject.InsertSeparatorMil(rRow["valor"].ToString()));
                    ticket.AddHeaderLine("");
                }*/
                /*ticket.AddHeaderLine("");
                ticket.AddHeaderLine("RESUMEN");
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("TOTAL INGRESOS : " +
                    UseObject.InsertSeparatorMil(tIngresos.AsEnumerable().Sum(s => s.Field<long>("valor")).ToString()));
                ticket.AddHeaderLine("APERTURA       : " +
                                      UseObject.InsertSeparatorMil(apertura.Valor.ToString()));
                ticket.AddHeaderLine("SUBTOTAL       : " +
                                      UseObject.InsertSeparatorMil((tIngresos.AsEnumerable().Sum(s => s.Field<long>("valor")) +
                                                                    apertura.Valor).ToString()));
                ticket.AddHeaderLine("");

               /* ticket.AddHeaderLine("TOTAL RETIROS  : " +
                    UseObject.InsertSeparatorMil(tRetiros.AsEnumerable().Sum(s => s.Field<long>("valor")).ToString()));*/
                //ticket.AddHeaderLine("");
                /* ticket.AddHeaderLine("DIFERENCIA     : " + UseObject.InsertSeparatorMil((
                     ((tIngresos.AsEnumerable().Sum(s => s.Field<long>("valor")) + apertura.Valor)) -
                     tRetiros.AsEnumerable().Sum(s => s.Field<long>("valor"))).ToString()));*/
                /* ticket.AddHeaderLine("");
                 ticket.AddHeaderLine("");

                 ticket.AddHeaderLine("CIERRE");
                 ticket.AddHeaderLine("");
                 if (tCierres.Rows.Count > 0)
                 {
                     foreach (DataRow ciRow in tCierres.Rows)
                     {
                         ticket.AddHeaderLine(ciRow["pago"].ToString() + " : " +
                                 UseObject.InsertSeparatorMil(ciRow["valor"].ToString()));
                     }
                 }
                 else
                 {
                     ticket.AddHeaderLine("$0");
                 }
                 ticket.AddHeaderLine("");
                 ticket.AddHeaderLine("");

                 ticket.AddFooterLine("-----------------------------------");*/
                // ticket.PrintTicket("IMPREPOS");
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void btnVerCierre_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvAperturas.RowCount > 0)
                {
                    var frmCierre = new FrmConsultaCierre();
                    frmCierre.Cierres =
                        this.miBussinesCierre.Print(Convert.ToInt32(this.dgvAperturas.CurrentRow.Cells["IdApertura"].Value));
                    /*frmCierre.Cierres = miBussinesCierre.Print
                        (dtpFecha.Value, Convert.ToInt32(cbCaja.SelectedValue), Convert.ToInt32(cbTurno.SelectedValue));*/
                    frmCierre.ShowDialog();
                }
                else
                {
                    OptionPane.MessageInformation("Debe cargar los registros de apertura.");
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscarApertura_Click(object sender, EventArgs e)
        {
            try
            {
                this.txtCaja.Text = ((DataRowView)this.cbCaja.SelectedItem).Row["numerocaja"].ToString();
                this.txtTurno.Text = ((DataRowView)this.cbTurno.SelectedItem).Row["numero"].ToString();
                this.dgvAperturas.DataSource =
                    this.miBussinesApertura.Aperturas(Convert.ToInt32(this.cbCaja.SelectedValue), Convert.ToInt32(this.cbTurno.SelectedValue));
                foreach (DataGridViewRow gRow in this.dgvAperturas.Rows)
                {
                    //var t = gRow.Cells["ValorCierre"].Value.ToString();
                    if (gRow.Cells["ValorCierre"].Value.ToString().Equals("") || gRow.Cells["ValorCierre"].Value.ToString().Equals("0"))
                    {
                        gRow.DefaultCellStyle.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
                    }
                }
                if (this.dgvAperturas.Rows.Count > 0)
                {
                    this.Apertura_ = this.miBussinesApertura.Apertura(Convert.ToInt32(this.dgvAperturas.CurrentRow.Cells["IdApertura"].Value));
                    this.txtApertura.Text = UseObject.InsertSeparatorMil(this.Apertura_.Valor.ToString());
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvAperturas.Rows.Count > 0)
                {
                    this.Apertura_ = this.miBussinesApertura.Apertura(Convert.ToInt32(this.dgvAperturas.CurrentRow.Cells["IdApertura"].Value));
                    var cierre = this.miBussinesCierre.Cierre(this.Apertura_.Id);
                    this.Fecha2 = DateTime.Now;
                    if (cierre.Id != 0)
                    {
                        this.Fecha2 = cierre.Fecha;
                    }

                    this.TablaIngresos = this.miBussinesIngreso.IngresosHoras
                        (this.Apertura_.Fecha, this.Fecha2, Convert.ToInt32(cbCaja.SelectedValue), Convert.ToInt32(cbTurno.SelectedValue));
                    this.dgvIngresos.DataSource = this.TablaIngresos;
                    if (TablaIngresos.Rows.Count.Equals(0))
                    {
                        lblMsnIngreso.Text = "No se encontraron registros de la consulta.";
                        while (dgvPagoIngresos.RowCount != 0)
                        {
                            dgvPagoIngresos.Rows.RemoveAt(0);
                        }
                        txtTotalIngresos.Text = "0";
                    }
                    else
                    {
                        lblMsnIngreso.Text = "";
                        var query = TablaIngresos.AsEnumerable().Where
                            (d => d.Field<int>("id").Equals(Convert.ToInt32(dgvIngresos.CurrentRow.Cells["IdIngreso"].Value)));
                        dgvPagoIngresos.DataSource = query.AsDataView();
                        txtTotalIngresos.Text = UseObject.InsertSeparatorMil(
                            TablaIngresos.AsEnumerable().Sum(s => s.Field<int>("valor")).ToString());
                    }

                    this.Tabla = this.miBussinesRetiro.RetirosHoras
                        (this.Apertura_.Fecha, this.Fecha2, Convert.ToInt32(cbCaja.SelectedValue), Convert.ToInt32(cbTurno.SelectedValue));
                    dgvRetiros.DataSource = Tabla;
                    if (Tabla.Rows.Count.Equals(0))
                    {
                        lblMsnRetiro.Text = "No se encontraron registros de la consulta.";
                        while (dgvPagos.RowCount != 0)
                        {
                            dgvPagos.Rows.RemoveAt(0);
                        }
                        txtTotalRetiros.Text = "0";
                    }
                    else
                    {
                        lblMsnRetiro.Text = "";
                        var valor = 0;
                        foreach (DataRow rRow in Tabla.Rows)
                        {
                            valor += Convert.ToInt32(miBussinesRetiro.PagosRetiro(Convert.ToInt32(rRow["id"])).
                                                     AsEnumerable().Sum(s => s.Field<int>("valor")));
                        }
                        var tPagos = miBussinesRetiro.PagosRetiro(Convert.ToInt32(dgvRetiros.CurrentRow.Cells["Id"].Value));
                        dgvPagos.DataSource = tPagos;
                        txtTotalRetiros.Text = UseObject.InsertSeparatorMil(valor.ToString());
                    }

                    /// Ingresos por factura electronica
                    if (this.ElectronicaInvoice)
                    {
                        this.Payments = this.miBussinesIngreso.Payments(Convert.ToInt32(cbCaja.SelectedValue), this.Apertura_.Fecha, this.Fecha2);
                        //this.Apertura_.Fecha, this.Fecha2, Convert.ToInt32(cbCaja.SelectedValue)
                        this.txtIngresosFE.Text = UseObject.InsertSeparatorMil(
                            Convert.ToInt32(this.Payments.Sum(s => s.Valor)).ToString());
                    }

                    this.txtTotalDevolucion.Text = UseObject.InsertSeparatorMil(miBussinesDevolucion.TotalDevolucionesHoras(
                            this.Apertura_.Fecha, this.Fecha2, Convert.ToInt32(cbCaja.SelectedValue), Convert.ToInt32(cbTurno.SelectedValue)).ToString());

                    this.txtIng_Ret_Devol.Text = UseObject.InsertSeparatorMil((
                        (Convert.ToInt32(UseObject.RemoveSeparatorMil(this.txtTotalIngresos.Text)) +
                          Convert.ToInt32(UseObject.RemoveSeparatorMil(this.txtIngresosFE.Text))) -
                        Convert.ToInt32(UseObject.RemoveSeparatorMil(this.txtTotalRetiros.Text)) -
                        Convert.ToInt32(UseObject.RemoveSeparatorMil(this.txtTotalDevolucion.Text))).ToString());

                    this.txtApertura.Text = UseObject.InsertSeparatorMil(this.Apertura_.Valor.ToString());

                    this.txtCierre.Text = UseObject.InsertSeparatorMil(cierre.Valor.ToString());

                    txtSubTotal.Text = UseObject.InsertSeparatorMil((
                        (UseObject.RemoveSeparatorMil(this.txtApertura.Text) + 
                         UseObject.RemoveSeparatorMil(this.txtTotalIngresos.Text) +
                         UseObject.RemoveSeparatorMil(this.txtIngresosFE.Text)) -
                        (UseObject.RemoveSeparatorMil(this.txtTotalDevolucion.Text) + 
                         UseObject.RemoveSeparatorMil(this.txtTotalRetiros.Text))).ToString());

                    txtSaldo.Text = UseObject.InsertSeparatorMil((
                        UseObject.RemoveSeparatorMil(this.txtCierre.Text) - UseObject.RemoveSeparatorMil(this.txtSubTotal.Text)).ToString());
                }
                else
                {
                    OptionPane.MessageInformation("Debe consultar primero las aperturas.");
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void btnBuscar_Click_(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("consultaVenta")))
                {
                    // OptionPane.MessageInformation("Consulta por dia");
                    // Consulta a ingresos.
                    dgvIngresos.AutoGenerateColumns = false;
                    dgvPagoIngresos.AutoGenerateColumns = false;
                    TablaIngresos = miBussinesIngreso.Ingresos(dtpFecha.Value,
                                                     Convert.ToInt32(cbCaja.SelectedValue),
                                                     Convert.ToInt32(cbTurno.SelectedValue));
                    dgvIngresos.DataSource = TablaIngresos;
                    if (TablaIngresos.Rows.Count.Equals(0))
                    {
                        lblMsnIngreso.Text = "No se encontraron registros de la consulta.";
                        while (dgvPagoIngresos.RowCount != 0)
                        {
                            dgvPagoIngresos.Rows.RemoveAt(0);
                        }
                        txtTotalIngresos.Text = "0";
                    }
                    else
                    {
                        lblMsnIngreso.Text = "";
                        var query = TablaIngresos.AsEnumerable().Where
                            (d => d.Field<int>("id").Equals(Convert.ToInt32(dgvIngresos.CurrentRow.Cells["IdIngreso"].Value)));
                        dgvPagoIngresos.DataSource = query.AsDataView();
                        txtTotalIngresos.Text = UseObject.InsertSeparatorMil(
                            TablaIngresos.AsEnumerable().Sum(s => s.Field<int>("valor")).ToString());
                    }

                    // Consulta a retiros.
                    dgvRetiros.AutoGenerateColumns = false;
                    dgvPagos.AutoGenerateColumns = false;
                    Tabla = miBussinesRetiro.Retiros(dtpFecha.Value,
                                                     Convert.ToInt32(cbCaja.SelectedValue),
                                                     Convert.ToInt32(cbTurno.SelectedValue));
                    dgvRetiros.DataSource = Tabla;
                    if (Tabla.Rows.Count.Equals(0))
                    {
                        lblMsnRetiro.Text = "No se encontraron registros de la consulta.";
                        while (dgvPagos.RowCount != 0)
                        {
                            dgvPagos.Rows.RemoveAt(0);
                        }
                        txtTotalRetiros.Text = "0";
                    }
                    else
                    {
                        lblMsnRetiro.Text = "";
                        var valor = 0;
                        foreach (DataRow rRow in Tabla.Rows)
                        {
                            valor += Convert.ToInt32(miBussinesRetiro.PagosRetiro(Convert.ToInt32(rRow["id"])).
                                                     AsEnumerable().Sum(s => s.Field<int>("valor")));
                        }
                        var tPagos = miBussinesRetiro.PagosRetiro(Convert.ToInt32(dgvRetiros.CurrentRow.Cells["Id"].Value));
                        dgvPagos.DataSource = tPagos;
                        txtTotalRetiros.Text = UseObject.InsertSeparatorMil(valor.ToString());
                    }

                    this.txtTotalDevolucion.Text = UseObject.InsertSeparatorMil(miBussinesDevolucion.TotalDevoluciones(
                        this.dtpFecha.Value, Convert.ToInt32(cbCaja.SelectedValue), Convert.ToInt32(cbTurno.SelectedValue)).ToString());

                    txtApertura.Text = UseObject.InsertSeparatorMil(
                        miBussinesApertura.Apertura(dtpFecha.Value, Convert.ToInt32(cbCaja.SelectedValue), Convert.ToInt32(cbTurno.SelectedValue))
                        .Valor.ToString());

                    txtCierre.Text = UseObject.InsertSeparatorMil(
                        miBussinesCierre.Print(dtpFecha.Value, Convert.ToInt32(cbCaja.SelectedValue), Convert.ToInt32(cbTurno.SelectedValue))
                        .AsEnumerable().Sum(s => s.Field<int>("valor")).ToString());

                    txtSubTotal.Text = UseObject.InsertSeparatorMil((
                        (UseObject.RemoveSeparatorMil(txtApertura.Text) + UseObject.RemoveSeparatorMil(txtTotalIngresos.Text)) -
                        (UseObject.RemoveSeparatorMil(this.txtTotalDevolucion.Text) + UseObject.RemoveSeparatorMil(txtTotalRetiros.Text))).ToString());

                    txtSaldo.Text = UseObject.InsertSeparatorMil((
                        UseObject.RemoveSeparatorMil(txtCierre.Text) - UseObject.RemoveSeparatorMil(txtSubTotal.Text)).ToString());

                    txtAcumulado.Text = UseObject.InsertSeparatorMil(
                        miBussinesIngreso.SumaAcumuladoIngresos(Convert.ToInt32(cbCaja.SelectedValue), dtpFecha.Value).ToString());
                }
                else
                {
                    // consultas que incluyen hora

                    DateTime fecha2 = this.dtpFecha.Value;
                    var apertura = miBussinesApertura.Apertura(this.dtpFecha.Value, Convert.ToInt32(cbCaja.SelectedValue));
                    if (apertura.Id.Equals(0))
                    {
                        apertura = miBussinesApertura.AperturaAnterior(this.dtpFecha.Value, Convert.ToInt32(cbCaja.SelectedValue));
                    }

                    var cierre = miBussinesCierre.Cierre(apertura.Id);
                    cierre.Valor = miBussinesCierre.TotalCierre(apertura.Id);
                    if (!cierre.Id.Equals(0))
                    {
                        fecha2 = cierre.Fecha;
                    }

                    if (UseDate.FechaSinHora(apertura.Fecha).Equals(UseDate.FechaSinHora(fecha2))) //(apertura.Fecha.Equals(fecha2))
                    {
                        // consulta por la misma fecha y en rango de horas.
                        dgvIngresos.AutoGenerateColumns = false;
                        dgvPagoIngresos.AutoGenerateColumns = false;
                        TablaIngresos = miBussinesIngreso.IngresosHoras(apertura.Fecha, fecha2,
                                                                 Convert.ToInt32(cbCaja.SelectedValue),
                                                                 Convert.ToInt32(cbTurno.SelectedValue));

                        dgvIngresos.DataSource = TablaIngresos;
                        if (TablaIngresos.Rows.Count.Equals(0))
                        {
                            lblMsnIngreso.Text = "No se encontraron registros de la consulta.";
                            while (dgvPagoIngresos.RowCount != 0)
                            {
                                dgvPagoIngresos.Rows.RemoveAt(0);
                            }
                            txtTotalIngresos.Text = "0";
                        }
                        else
                        {
                            lblMsnIngreso.Text = "";
                            var query = TablaIngresos.AsEnumerable().Where
                                (d => d.Field<int>("id").Equals(Convert.ToInt32(dgvIngresos.CurrentRow.Cells["IdIngreso"].Value)));
                            dgvPagoIngresos.DataSource = query.AsDataView();
                            txtTotalIngresos.Text = UseObject.InsertSeparatorMil(
                                TablaIngresos.AsEnumerable().Sum(s => s.Field<int>("valor")).ToString());
                        }

                        // Consulta a retiros.
                        dgvRetiros.AutoGenerateColumns = false;
                        dgvPagos.AutoGenerateColumns = false;
                        Tabla = miBussinesRetiro.RetirosHoras(apertura.Fecha, fecha2,
                                                                 Convert.ToInt32(cbCaja.SelectedValue),
                                                                 Convert.ToInt32(cbTurno.SelectedValue));

                        dgvRetiros.DataSource = Tabla;
                        if (Tabla.Rows.Count.Equals(0))
                        {
                            lblMsnRetiro.Text = "No se encontraron registros de la consulta.";
                            while (dgvPagos.RowCount != 0)
                            {
                                dgvPagos.Rows.RemoveAt(0);
                            }
                            txtTotalRetiros.Text = "0";
                        }
                        else
                        {
                            lblMsnRetiro.Text = "";
                            var valor = 0;
                            foreach (DataRow rRow in Tabla.Rows)
                            {
                                valor += Convert.ToInt32(miBussinesRetiro.PagosRetiro(Convert.ToInt32(rRow["id"])).
                                                         AsEnumerable().Sum(s => s.Field<int>("valor")));
                            }
                            var tPagos = miBussinesRetiro.PagosRetiro(Convert.ToInt32(dgvRetiros.CurrentRow.Cells["Id"].Value));
                            dgvPagos.DataSource = tPagos;
                            txtTotalRetiros.Text = UseObject.InsertSeparatorMil(valor.ToString());
                        }

                        txtApertura.Text = UseObject.InsertSeparatorMil(apertura.Valor.ToString());

                        this.txtTotalDevolucion.Text = UseObject.InsertSeparatorMil((miBussinesDevolucion.TotalDevoluciones(
                            apertura.Fecha, fecha2, Convert.ToInt32(cbCaja.SelectedValue), Convert.ToInt32(cbTurno.SelectedValue)) +
                            miBussinesDevolucion.TotalDevolucionesComplemento(
                            apertura.Fecha, this.dtpFecha.Value, Convert.ToInt32(cbCaja.SelectedValue), Convert.ToInt32(cbTurno.SelectedValue))).ToString());

                        txtCierre.Text = UseObject.InsertSeparatorMil(cierre.Valor.ToString());

                        txtSubTotal.Text = UseObject.InsertSeparatorMil((
                            (UseObject.RemoveSeparatorMil(txtApertura.Text) + UseObject.RemoveSeparatorMil(txtTotalIngresos.Text)) -
                            (UseObject.RemoveSeparatorMil(this.txtTotalDevolucion.Text) + UseObject.RemoveSeparatorMil(txtTotalRetiros.Text))).ToString());

                        txtSaldo.Text = UseObject.InsertSeparatorMil((
                            UseObject.RemoveSeparatorMil(txtCierre.Text) - UseObject.RemoveSeparatorMil(txtSubTotal.Text)).ToString());

                        txtAcumulado.Text = UseObject.InsertSeparatorMil(
                            miBussinesIngreso.SumaAcumuladoIngresos(Convert.ToInt32(cbCaja.SelectedValue), dtpFecha.Value).ToString());


                        // Fin incluye horas.
                        //*********************************
                    }
                    else
                    {
                        // Consulta a ingresos.
                        dgvIngresos.AutoGenerateColumns = false;
                        dgvPagoIngresos.AutoGenerateColumns = false;
                        TablaIngresos = miBussinesIngreso.Ingresos(apertura.Fecha, fecha2,
                                                         Convert.ToInt32(cbCaja.SelectedValue),
                                                         Convert.ToInt32(cbTurno.SelectedValue));

                        dgvIngresos.DataSource = TablaIngresos;
                        if (TablaIngresos.Rows.Count.Equals(0))
                        {
                            lblMsnIngreso.Text = "No se encontraron registros de la consulta.";
                            while (dgvPagoIngresos.RowCount != 0)
                            {
                                dgvPagoIngresos.Rows.RemoveAt(0);
                            }
                            txtTotalIngresos.Text = "0";
                        }
                        else
                        {
                            lblMsnIngreso.Text = "";
                            var query = TablaIngresos.AsEnumerable().Where
                                (d => d.Field<int>("id").Equals(Convert.ToInt32(dgvIngresos.CurrentRow.Cells["IdIngreso"].Value)));
                            dgvPagoIngresos.DataSource = query.AsDataView();
                            txtTotalIngresos.Text = UseObject.InsertSeparatorMil(
                                TablaIngresos.AsEnumerable().Sum(s => s.Field<int>("valor")).ToString());
                        }

                        // Consulta a retiros.
                        dgvRetiros.AutoGenerateColumns = false;
                        dgvPagos.AutoGenerateColumns = false;
                        Tabla = miBussinesRetiro.Retiros(apertura.Fecha, fecha2,
                                                         Convert.ToInt32(cbCaja.SelectedValue),
                                                         Convert.ToInt32(cbTurno.SelectedValue));

                        dgvRetiros.DataSource = Tabla;
                        if (Tabla.Rows.Count.Equals(0))
                        {
                            lblMsnRetiro.Text = "No se encontraron registros de la consulta.";
                            while (dgvPagos.RowCount != 0)
                            {
                                dgvPagos.Rows.RemoveAt(0);
                            }
                            txtTotalRetiros.Text = "0";
                        }
                        else
                        {
                            lblMsnRetiro.Text = "";
                            var valor = 0;
                            foreach (DataRow rRow in Tabla.Rows)
                            {
                                valor += Convert.ToInt32(miBussinesRetiro.PagosRetiro(Convert.ToInt32(rRow["id"])).
                                                         AsEnumerable().Sum(s => s.Field<int>("valor")));
                            }
                            var tPagos = miBussinesRetiro.PagosRetiro(Convert.ToInt32(dgvRetiros.CurrentRow.Cells["Id"].Value));
                            dgvPagos.DataSource = tPagos;
                            txtTotalRetiros.Text = UseObject.InsertSeparatorMil(valor.ToString());
                        }

                        txtApertura.Text = UseObject.InsertSeparatorMil(apertura.Valor.ToString());

                        this.txtTotalDevolucion.Text = UseObject.InsertSeparatorMil((miBussinesDevolucion.TotalDevoluciones(
                            apertura.Fecha, fecha2, Convert.ToInt32(cbCaja.SelectedValue), Convert.ToInt32(cbTurno.SelectedValue)) +
                            miBussinesDevolucion.TotalDevolucionesComplemento(
                            apertura.Fecha, this.dtpFecha.Value, Convert.ToInt32(cbCaja.SelectedValue), Convert.ToInt32(cbTurno.SelectedValue))).ToString());

                        txtCierre.Text = UseObject.InsertSeparatorMil(cierre.Valor.ToString());

                        txtSubTotal.Text = UseObject.InsertSeparatorMil((
                            (UseObject.RemoveSeparatorMil(txtApertura.Text) + UseObject.RemoveSeparatorMil(txtTotalIngresos.Text)) -
                            (UseObject.RemoveSeparatorMil(this.txtTotalDevolucion.Text) + UseObject.RemoveSeparatorMil(txtTotalRetiros.Text))).ToString());

                        txtSaldo.Text = UseObject.InsertSeparatorMil((
                            UseObject.RemoveSeparatorMil(txtCierre.Text) - UseObject.RemoveSeparatorMil(txtSubTotal.Text)).ToString());

                        txtAcumulado.Text = UseObject.InsertSeparatorMil(
                            miBussinesIngreso.SumaAcumuladoIngresos(Convert.ToInt32(cbCaja.SelectedValue), dtpFecha.Value).ToString());
                    }
                }







                //************************************************

                // Consulta a ingresos.
                /*  dgvIngresos.AutoGenerateColumns = false;
                  dgvPagoIngresos.AutoGenerateColumns = false;
                  TablaIngresos = miBussinesIngreso.Ingresos(dtpFecha.Value,
                                                   Convert.ToInt32(cbCaja.SelectedValue),
                                                   Convert.ToInt32(cbTurno.SelectedValue));
                  dgvIngresos.DataSource = TablaIngresos;
                  if (TablaIngresos.Rows.Count.Equals(0))
                  {
                      lblMsnIngreso.Text = "No se encontraron registros de la consulta.";
                      while (dgvPagoIngresos.RowCount != 0)
                      {
                          dgvPagoIngresos.Rows.RemoveAt(0);
                      }
                      txtTotalIngresos.Text = "0";
                  }
                  else
                  {
                      lblMsnIngreso.Text = "";
                      var query = TablaIngresos.AsEnumerable().Where
                          (d => d.Field<int>("id").Equals(Convert.ToInt32(dgvIngresos.CurrentRow.Cells["IdIngreso"].Value)));
                      dgvPagoIngresos.DataSource = query.AsDataView();
                      txtTotalIngresos.Text = UseObject.InsertSeparatorMil(
                          TablaIngresos.AsEnumerable().Sum(s => s.Field<int>("valor")).ToString());
                  }

                  // Consulta a retiros.
                  dgvRetiros.AutoGenerateColumns = false;
                  dgvPagos.AutoGenerateColumns = false;
                  Tabla = miBussinesRetiro.Retiros(dtpFecha.Value,
                                                   Convert.ToInt32(cbCaja.SelectedValue),
                                                   Convert.ToInt32(cbTurno.SelectedValue));
                  dgvRetiros.DataSource = Tabla;
                  if (Tabla.Rows.Count.Equals(0))
                  {
                      lblMsnRetiro.Text = "No se encontraron registros de la consulta.";
                      while (dgvPagos.RowCount != 0)
                      {
                          dgvPagos.Rows.RemoveAt(0);
                      }
                      txtTotalRetiros.Text = "0";
                  }
                  else
                  {
                      lblMsnRetiro.Text = "";
                      var valor = 0;
                      foreach (DataRow rRow in Tabla.Rows)
                      {
                          valor += Convert.ToInt32(miBussinesRetiro.PagosRetiro(Convert.ToInt32(rRow["id"])).
                                                   AsEnumerable().Sum(s => s.Field<int>("valor")));
                      }
                      var tPagos = miBussinesRetiro.PagosRetiro(Convert.ToInt32(dgvRetiros.CurrentRow.Cells["Id"].Value));
                      dgvPagos.DataSource = tPagos;*/
                /*txtTotalRetiros.Text = UseObject.InsertSeparatorMil(
                    tPagos.AsEnumerable().Sum(s => s.Field<int>("valor")).ToString());*/
                //txtTotalRetiros.Text = UseObject.InsertSeparatorMil(valor.ToString());
                // }

                /*this.txtTotalDevolucion.Text = UseObject.InsertSeparatorMil(miBussinesDevolucion.TotalDevoluciones(
                    this.dtpFecha.Value, Convert.ToInt32(cbCaja.SelectedValue), Convert.ToInt32(cbTurno.SelectedValue)).ToString());*/

                /*txtApertura.Text = UseObject.InsertSeparatorMil(
                    miBussinesApertura.Apertura(dtpFecha.Value, Convert.ToInt32(cbCaja.SelectedValue), Convert.ToInt32(cbTurno.SelectedValue))
                    .Valor.ToString());

                txtCierre.Text = UseObject.InsertSeparatorMil(
                    miBussinesCierre.Print(dtpFecha.Value, Convert.ToInt32(cbCaja.SelectedValue), Convert.ToInt32(cbTurno.SelectedValue))
                    .AsEnumerable().Sum(s => s.Field<int>("valor")).ToString());

                txtSubTotal.Text = UseObject.InsertSeparatorMil((
                    (UseObject.RemoveSeparatorMil(txtApertura.Text) + UseObject.RemoveSeparatorMil(txtTotalIngresos.Text)) -
                    (UseObject.RemoveSeparatorMil(this.txtTotalDevolucion.Text) + UseObject.RemoveSeparatorMil(txtTotalRetiros.Text))).ToString());

                txtSaldo.Text = UseObject.InsertSeparatorMil((
                    UseObject.RemoveSeparatorMil(txtCierre.Text) - UseObject.RemoveSeparatorMil(txtSubTotal.Text)).ToString());

                txtAcumulado.Text = UseObject.InsertSeparatorMil(
                    miBussinesIngreso.SumaAcumuladoIngresos(Convert.ToInt32(cbCaja.SelectedValue), dtpFecha.Value).ToString());*/
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void dgvIngresos_Click(object sender, EventArgs e)
        {
            if (dgvIngresos.RowCount != 0)
            {
                var query = TablaIngresos.AsEnumerable().Where
                            (d => d.Field<int>("id").Equals(Convert.ToInt32(dgvIngresos.CurrentRow.Cells["IdIngreso"].Value)));
                dgvPagoIngresos.DataSource = query.AsDataView();
            }
        }

        private void dgvRetiros_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvRetiros.RowCount != 0)
            {
                dgvPagos.DataSource = miBussinesRetiro.PagosRetiro(Convert.ToInt32(dgvRetiros.CurrentRow.Cells["Id"].Value));
            }
        }

        private void CargarElementos()
        {
            try
            {
                this.dgvAperturas.AutoGenerateColumns = false;
                this.dgvIngresos.AutoGenerateColumns = false;
                this.dgvRetiros.AutoGenerateColumns = false;
                this.dgvPagoIngresos.AutoGenerateColumns = false;
                this.dgvPagos.AutoGenerateColumns = false;
                cbCaja.DataSource = miBussinesCaja.Cajas();
                cbTurno.DataSource = miBussinesTurno.Turnos();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        public void PrintMovimientoCaja(int idApertura)
        {
            try
            {
                
                DataRow empresaRow = miBussinesEmpresa.PrintEmpresa().Tables[0].AsEnumerable().First();

                var apertura = miBussinesApertura.Apertura(idApertura);
                var cierre = miBussinesCierre.Cierre(idApertura);
                var caja = miBussinesCaja.CajaId(apertura.Caja.Id);
                var turno = miBussinesTurno.TurnoId(apertura.Turno.Id);

                var tIngresos = this.miBussinesIngreso.PrintIngresosHoras(apertura.Fecha, cierre.Fecha, apertura.Caja.Id, apertura.Turno.Id);

                /// Ingresos por factura electronica
                List<FormaPago> Payments_ = new List<FormaPago>();
                if (this.ElectronicaInvoice)
                {
                    Payments_ = this.miBussinesIngreso.Payments(apertura.Caja.Id, apertura.Fecha, cierre.Fecha);
                }

                ///var totalCredito = this.miBussinesFacturaVenta.VentasCredito(2, apertura.Caja.Id, apertura.Fecha, cierre.Fecha);  // funcion auxiliar             28/03/2019

                var tRetiros = miBussinesRetiro.PrintRetirosHoras(apertura.Fecha, cierre.Fecha, apertura.Caja.Id, apertura.Turno.Id);

                var valorDevoluciones = miBussinesDevolucion.TotalDevolucionesHoras(apertura.Fecha, cierre.Fecha, apertura.Caja.Id, apertura.Turno.Id);

                //var tCierres = miBussinesCierre.Print(apertura.Id);
                var tCierres = miBussinesCierre.Tcierres(apertura.Id);
                
                Ticket ticket = new Ticket();
                ticket.UseItem = false;
                int maxCharacters = 35;

                foreach (var datos in UseObject.StringBuilderDataCenter(empresaRow["Nombre"].ToString().ToUpper(), maxCharacters))
                {
                    ticket.AddHeaderLine(datos);
                }
                foreach (var datos in UseObject.StringBuilderDataCenter(empresaRow["Juridico"].ToString(), maxCharacters))
                {
                    ticket.AddHeaderLine(datos);
                }
                foreach (var datos in UseObject.StringBuilderDataCenter(
                    "NIT " + UseObject.InsertSeparatorMilMasDigito(empresaRow["Nit"].ToString()), maxCharacters))
                {
                    ticket.AddHeaderLine(datos);
                }
                foreach (var datos in UseObject.StringBuilderDataCenter(empresaRow["Direccion"].ToString(), maxCharacters))
                {
                    ticket.AddHeaderLine(datos);
                }
                foreach (var datos in UseObject.StringBuilderDataCenter(empresaRow["Telefono"].ToString(), maxCharacters))
                {
                    ticket.AddHeaderLine(datos);
                }
                foreach (var datos in UseObject.StringBuilderDataCenter(empresaRow["Regimen"].ToString(), maxCharacters))
                {
                    ticket.AddHeaderLine(datos);
                }
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("INFORME DE CAJA");
                ticket.AddHeaderLine("Fecha : " + apertura.Fecha.ToShortDateString());
                ticket.AddHeaderLine("Caja  : " + caja.Numero);
                ticket.AddHeaderLine("Turno : " + turno.Numero);

                ticket.AddHeaderLine("");

                ticket.AddHeaderLine("MOVIMIENTO DE CAJA");
                ticket.AddHeaderLine("-----------------------------------");
                ticket.AddHeaderLine("     APERTURA :" + UseObject.StringBuilderDetalleTotalEspacio(
                    UseObject.InsertSeparatorMil(apertura.Valor.ToString())));

                ticket.AddHeaderLine("     EFECTIVO :" + UseObject.StringBuilderDetalleTotalEspacio(
                        UseObject.InsertSeparatorMil(Convert.ToInt32
                        (tIngresos.AsEnumerable().Where(i => i.Field<int>("idpago").Equals(1)).Sum(s => s.Field<int>("valor")) +
                         Math.Round(Payments_.Where(p => p.NombreFormaPago.Equals("10")).Sum(s => s.Valor), 0))
                        .ToString())));

                ticket.AddHeaderLine("TRANSFERENCIA :" + UseObject.StringBuilderDetalleTotalEspacio(UseObject.InsertSeparatorMil(
                    (tIngresos.AsEnumerable().Where(i => i.Field<int>("idpago").Equals(4)).Sum(s => s.Field<int>("valor")) +
                    Math.Round(Payments_.Where(p => p.NombreFormaPago.Equals("31")).Sum(s => s.Valor), 0))
                    .ToString())));

                ticket.AddHeaderLine("      TARJETA :" + UseObject.StringBuilderDetalleTotalEspacio(UseObject.InsertSeparatorMil(
                    (tIngresos.AsEnumerable().Where(i => i.Field<int>("idpago").Equals(3)).Sum(s => s.Field<int>("valor")) +
                     Math.Round(Payments_.Where(p => p.NombreFormaPago.Equals("49")).Sum(s => s.Valor), 0))
                    .ToString())));

                //ticket.AddHeaderLine("INGRESOS");
                /*ticket.AddHeaderLine("     EFECTIVO :" + UseObject.StringBuilderDetalleTotalEspacio(UseObject.InsertSeparatorMil(
                    tIngresos.AsEnumerable().Where(i => i.Field<int>("idpago").Equals(1)).Sum(s => s.Field<int>("valor")).ToString())));
                ticket.AddHeaderLine("  TRANSACCIÓN :" + UseObject.StringBuilderDetalleTotalEspacio(UseObject.InsertSeparatorMil(
                    tIngresos.AsEnumerable().Where(i => i.Field<int>("idpago").Equals(4)).Sum(s => s.Field<int>("valor")).ToString())));
                ticket.AddHeaderLine("       CHEQUE :" + UseObject.StringBuilderDetalleTotalEspacio(UseObject.InsertSeparatorMil(
                    tIngresos.AsEnumerable().Where(i => i.Field<int>("idpago").Equals(2)).Sum(s => s.Field<int>("valor")).ToString())));*/
                ticket.AddHeaderLine("-----------------------------------");
                ticket.AddHeaderLine("RETIROS");
                foreach (DataRow rRow in tRetiros.Rows)
                {
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("Fecha:    " + Convert.ToDateTime(rRow["fecha"]).ToShortDateString() + " " +
                                                        Convert.ToDateTime(rRow["hora"]).ToShortTimeString());
                    ticket.AddHeaderLine("Concepto: " + rRow["concepto"].ToString());
                    ticket.AddHeaderLine("Valor:    " + UseObject.InsertSeparatorMil(rRow["valor"].ToString()));
                }
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("TOTAL RETIROS :" + UseObject.StringBuilderDetalleTotalEspacio(UseObject.InsertSeparatorMil(
                    tRetiros.AsEnumerable().Sum(s => s.Field<int>("valor")).ToString())));
                ticket.AddHeaderLine("-----------------------------------");
                ticket.AddHeaderLine("DEVOLUCIONES  :" + UseObject.StringBuilderDetalleTotalEspacio(UseObject.InsertSeparatorMil(valorDevoluciones.ToString())));
                ticket.AddHeaderLine("-----------------------------------");

                var subTotal = (apertura.Valor +
                  tIngresos.AsEnumerable().Sum(s => s.Field<int>("valor")) +
                  Convert.ToInt32(Payments_.Sum(s => s.Valor))) -
                  tRetiros.AsEnumerable().Sum(s => s.Field<int>("valor")) - valorDevoluciones;
                ticket.AddHeaderLine("TOTAL INGRESOS:" + UseObject.StringBuilderDetalleTotalEspacio(UseObject.InsertSeparatorMil(subTotal.ToString())));
                ticket.AddHeaderLine("-----------------------------------");
                ticket.AddHeaderLine("CIERRE DE CAJA");
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("     EFECTIVO :" + UseObject.StringBuilderDetalleTotalEspacio(UseObject.InsertSeparatorMil(
                        tCierres.AsEnumerable().Where(i => i.Field<int>("idpago").Equals(1)).Sum(s => s.Field<int>("valor")).ToString())));
                ticket.AddHeaderLine("TRANSFERENCIA :" + UseObject.StringBuilderDetalleTotalEspacio(UseObject.InsertSeparatorMil(
                    tCierres.AsEnumerable().Where(i => i.Field<int>("idpago").Equals(4)).Sum(s => s.Field<int>("valor")).ToString())));
                ticket.AddHeaderLine("      TARJETA :" + UseObject.StringBuilderDetalleTotalEspacio(UseObject.InsertSeparatorMil(
                    tCierres.AsEnumerable().Where(i => i.Field<int>("idpago").Equals(3)).Sum(s => s.Field<int>("valor")).ToString())));
                ticket.AddHeaderLine("     ***TOTAL :" + UseObject.StringBuilderDetalleTotalEspacio(UseObject.InsertSeparatorMil(
                    tCierres.AsEnumerable().Sum(s => s.Field<int>("valor")).ToString())));
                ticket.AddHeaderLine("      **SALDO :" + UseObject.StringBuilderDetalleTotalEspacio(UseObject.InsertSeparatorMil((cierre.Valor - subTotal).ToString())));


                /*
                ticket.AddHeaderLine("      RETIROS :" + UseObject.StringBuilderDetalleTotalEspacio(UseObject.InsertSeparatorMil(
                    tRetiros.AsEnumerable().Sum(s => s.Field<int>("valor")).ToString())));
                ticket.AddHeaderLine(" DEVOLUCIONES :" + UseObject.StringBuilderDetalleTotalEspacio(
                    UseObject.InsertSeparatorMil(valorDevoluciones.ToString())));


                
                var subTotal = (apertura.Valor +
                  tIngresos.AsEnumerable().Where(i => i.Field<int>("idpago").Equals(1)).Sum(s => s.Field<int>("valor")) + 
                  Convert.ToInt32(Payments_.Where(p => p.NombreFormaPago.Equals("10")).Sum(s => s.Valor))
                  ) -
                  tRetiros.AsEnumerable().Sum(s => s.Field<int>("valor")) - valorDevoluciones;

                ticket.AddHeaderLine("EFEC. EN CAJA :" + UseObject.StringBuilderDetalleTotalEspacio(UseObject.InsertSeparatorMil(subTotal.ToString())));
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("CIERRE DE CAJA:" + UseObject.StringBuilderDetalleTotalEspacio(UseObject.InsertSeparatorMil(cierre.Valor.ToString())));
                ticket.AddHeaderLine("         SALDO:" + UseObject.StringBuilderDetalleTotalEspacio(UseObject.InsertSeparatorMil((cierre.Valor - subTotal ).ToString())));
                */

                ticket.AddHeaderLine("-----------------------------------");
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("___________________________________");
                ticket.AddHeaderLine("CAJERO. C.C.");
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("");
                ticket.PrintTicket("");

                /**
                ticket.AddHeaderLine("     EFECTIVO :" + UseObject.StringBuilderDetalleTotalEspacio(UseObject.InsertSeparatorMil(
                            tCierres.AsEnumerable().Where(i => i.Field<int>("idpago").Equals(1)).Sum(s => s.Field<int>("valor")).ToString())));
                ticket.AddHeaderLine("  TRANSACCIÓN :" + UseObject.StringBuilderDetalleTotalEspacio(UseObject.InsertSeparatorMil(
                    tCierres.AsEnumerable().Where(i => i.Field<int>("idpago").Equals(4)).Sum(s => s.Field<int>("valor")).ToString())));
                ticket.AddHeaderLine("       CHEQUE :" + UseObject.StringBuilderDetalleTotalEspacio(UseObject.InsertSeparatorMil(
                    tCierres.AsEnumerable().Where(i => i.Field<int>("idpago").Equals(2)).Sum(s => s.Field<int>("valor")).ToString())));
                ticket.AddHeaderLine("");

                //ticket.AddHeaderLine("EFEC. + APERT.:" + UseObject.StringBuilderDetalleTotalEspacio(UseObject.InsertSeparatorMil((apertura.Valor +
                    //tIngresos.AsEnumerable().Where(i => i.Field<int>("idpago").Equals(1)).Sum(s => s.Field<int>("valor"))).ToString())));
                ticket.AddHeaderLine("      RETIROS :" + UseObject.StringBuilderDetalleTotalEspacio(UseObject.InsertSeparatorMil(
                    tRetiros.AsEnumerable().Sum(s => s.Field<int>("valor")).ToString())));
                ticket.AddHeaderLine(" DEVOLUCIONES :" + UseObject.StringBuilderDetalleTotalEspacio(
                    UseObject.InsertSeparatorMil(valorDevoluciones.ToString())));

                var subTotal = (apertura.Valor +
                  tIngresos.AsEnumerable().Where(i => i.Field<int>("idpago").Equals(1)).Sum(s => s.Field<int>("valor"))) -
                  tRetiros.AsEnumerable().Sum(s => s.Field<int>("valor")) - valorDevoluciones;

                ticket.AddHeaderLine("EFEC. EN CAJA :" + UseObject.StringBuilderDetalleTotalEspacio(UseObject.InsertSeparatorMil(subTotal.ToString())));
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("CIERRE DE CAJA:" + UseObject.StringBuilderDetalleTotalEspacio(UseObject.InsertSeparatorMil(cierre.Valor.ToString())));
                ticket.AddHeaderLine("         SALDO:" + UseObject.StringBuilderDetalleTotalEspacio(UseObject.InsertSeparatorMil((cierre.Valor -
                    (subTotal + tIngresos.AsEnumerable().Where(i => i.Field<int>("idpago") != 1).Sum(s => s.Field<int>("valor")))).ToString())));

                ticket.AddHeaderLine("-----------------------------------");
                ticket.AddHeaderLine("CREDITOS:      " + UseObject.StringBuilderDetalleTotalEspacio(
                    UseObject.InsertSeparatorMil(totalCredito.ToString())));
                ticket.AddHeaderLine("-----------------------------------");

                ticket.AddHeaderLine("TOTAL VENTAS:  " + UseObject.StringBuilderDetalleTotalEspacio(
                    UseObject.InsertSeparatorMil((tIngresos.AsEnumerable().Sum(s => s.Field<int>("valor")) + totalCredito).ToString())));

                ticket.AddHeaderLine("-----------------------------------");
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("___________________________________");
                ticket.AddHeaderLine("CAJERO. C.C.");
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("");

                ticket.PrintTicket("");
                */


                /*
                ticket.AddHeaderLine(empresaRow["Nombre"].ToString().ToUpper());
                ticket.AddHeaderLine(empresaRow["Juridico"].ToString());
                ticket.AddHeaderLine("NIT " + UseObject.InsertSeparatorMilMasDigito(empresaRow["Nit"].ToString()));
                ticket.AddHeaderLine("Régimen: " + empresaRow["Regimen"].ToString());
                ticket.AddHeaderLine(empresaRow["Direccion"].ToString());
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("INFORME DE CAJA");
                ticket.AddHeaderLine("Fecha : " + apertura.Fecha.ToShortDateString());
                ticket.AddHeaderLine("Caja  : " + caja.Numero);
                ticket.AddHeaderLine("Turno : " + turno.Numero);

                ticket.AddHeaderLine("");

                ticket.AddHeaderLine("Movimiento de caja");
                ticket.AddHeaderLine("-----------------------------------");
                ticket.AddHeaderLine("Ingresos en efectivo:");
                ticket.AddHeaderLine("Apertura:       " +
                                  UseObject.InsertSeparatorMil(apertura.Valor.ToString()));
                ticket.AddHeaderLine("Vent. Efectivo: " + UseObject.InsertSeparatorMil(
                    tIngresos.AsEnumerable().Where(i => i.Field<int>("idpago").Equals(1)).Sum(s => s.Field<int>("valor")).ToString()));
                ticket.AddHeaderLine("TOTAL:          " + UseObject.InsertSeparatorMil((apertura.Valor +
                    tIngresos.AsEnumerable().Where(i => i.Field<int>("idpago").Equals(1)).Sum(s => s.Field<int>("valor"))).ToString()));
                ticket.AddHeaderLine("-----------------------------------");
                ticket.AddHeaderLine("Retiros:");
                foreach (DataRow rRow in tRetiros.Rows)
                {
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("Fecha:    " + Convert.ToDateTime(rRow["fecha"]).ToShortDateString() + " " +
                                                        Convert.ToDateTime(rRow["hora"]).ToShortTimeString());
                    ticket.AddHeaderLine("Concepto: " + rRow["concepto"].ToString());
                    ticket.AddHeaderLine("Valor:    " + UseObject.InsertSeparatorMil(rRow["valor"].ToString()));
                }
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("TOTAL RETIROS:  " + UseObject.InsertSeparatorMil(
                    tRetiros.AsEnumerable().Sum(s => s.Field<int>("valor")).ToString()));
                ticket.AddHeaderLine("-----------------------------------");
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("CUADRE DE CAJA");
                ticket.AddHeaderLine("Ingr. Efectivo: " + UseObject.InsertSeparatorMil((apertura.Valor +
                    tIngresos.AsEnumerable().Where(i => i.Field<int>("idpago").Equals(1)).Sum(s => s.Field<int>("valor"))).ToString()));
                ticket.AddHeaderLine("Retiros:        " + UseObject.InsertSeparatorMil(
                    tRetiros.AsEnumerable().Sum(s => s.Field<int>("valor")).ToString()));
                ticket.AddHeaderLine("Devoluciones:   " + UseObject.InsertSeparatorMil(valorDevoluciones.ToString()));
                var subTotal = (apertura.Valor +
                    tIngresos.AsEnumerable().Where(i => i.Field<int>("idpago").Equals(1)).Sum(s => s.Field<int>("valor"))) -
                    tRetiros.AsEnumerable().Sum(s => s.Field<int>("valor")) - valorDevoluciones;

                ticket.AddHeaderLine("EFEC. EN CAJA:  " + UseObject.InsertSeparatorMil(subTotal.ToString()));

                ticket.AddHeaderLine("");

                ticket.AddHeaderLine("CIERRE DE CAJA: " + UseObject.InsertSeparatorMil(cierre.Valor.ToString()));

                ticket.AddHeaderLine("SALDO:          " + UseObject.InsertSeparatorMil((cierre.Valor - 
                    (subTotal + tIngresos.AsEnumerable().Where(i => i.Field<int>("idpago") != 1).Sum(s => s.Field<int>("valor")))).ToString()));

                ticket.AddHeaderLine("-----------------------------------");
                ticket.AddHeaderLine("OTRAS FORMAS DE PAGO");
                ticket.AddHeaderLine("Cheque:         " + UseObject.InsertSeparatorMil(
                    tIngresos.AsEnumerable().Where(i => i.Field<int>("idpago").Equals(2)).Sum(s => s.Field<int>("valor")).ToString()));
                ticket.AddHeaderLine("Transacción:    " + UseObject.InsertSeparatorMil(
                    tIngresos.AsEnumerable().Where(i => i.Field<int>("idpago").Equals(4)).Sum(s => s.Field<int>("valor")).ToString()));

                ticket.AddHeaderLine("Crédito:        " + UseObject.InsertSeparatorMil(totalCredito.ToString()));

                ticket.AddHeaderLine("TOTAL:          " + UseObject.InsertSeparatorMil((
                    tIngresos.AsEnumerable().Where(i => i.Field<int>("idpago") != 1).Sum(s => s.Field<int>("valor")) + totalCredito).ToString()));

                ticket.AddHeaderLine("-----------------------------------");

                ticket.AddHeaderLine("Total Ventas:   " + UseObject.InsertSeparatorMil((tIngresos.AsEnumerable().Sum(s => s.Field<int>("valor")) + totalCredito).ToString()));

                ticket.AddHeaderLine("-----------------------------------");
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("___________________________________");
                ticket.AddHeaderLine("CAJERO. C.C.");
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("");

                ticket.PrintTicket("");*/
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void PrintPos(DataTable retiros)
        {
            try
            {
                int total = 0;
                DataRow empresaRow = miBussinesEmpresa.PrintEmpresa().
                        Tables[0].AsEnumerable().First();
                var retiroRow = retiros.AsEnumerable().First();

                Ticket ticket = new Ticket();
                ticket.UseItem = false;

                ticket.AddHeaderLine(empresaRow["Nombre"].ToString().ToUpper());
                ticket.AddHeaderLine(empresaRow["Juridico"].ToString());
                ticket.AddHeaderLine("NIT " + UseObject.InsertSeparatorMilMasDigito(empresaRow["Nit"].ToString()));
                ticket.AddHeaderLine("Régimen: " + empresaRow["Regimen"].ToString());
                ticket.AddHeaderLine(empresaRow["Direccion"].ToString());
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("INFORME DE RETIROS");
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("Fecha : " + Convert.ToDateTime(retiroRow["fecha"]).ToShortDateString());
                ticket.AddHeaderLine("Caja  : " + retiroRow["nocaja"].ToString());
                ticket.AddHeaderLine("Turno : " + retiroRow["noturno"].ToString());
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("");
                foreach (DataRow rRetiro in retiros.Rows)
                {
                    var tPagos = miBussinesRetiro.PagosRetiro(Convert.ToInt32(rRetiro["id"]));
                    ticket.AddHeaderLine("Hora : " + Convert.ToDateTime(rRetiro["hora"]).ToShortTimeString());

                    foreach (DataRow pRow in tPagos.Rows)
                    {
                        ticket.AddHeaderLine("Concepto : " + pRow["concepto"].ToString());
                        ticket.AddHeaderLine(pRow["pago"].ToString() + " : " +
                            UseObject.InsertSeparatorMil(pRow["valor"].ToString()));
                        ticket.AddHeaderLine("");
                        total += Convert.ToInt32(pRow["valor"]);
                    }
                    ticket.AddHeaderLine("");
                }
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("TOTAL RETIROS : " + UseObject.InsertSeparatorMil(total.ToString()));

                ticket.PrintTicket("IMPREPOS");
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void PrintInformePos(DateTime fecha)
        {
            try
            {
                var tCajas = miBussinesCaja.Cajas();
                var tTurnos = miBussinesTurno.Turnos();

                foreach (DataRow cRow in tCajas.Rows)
                {
                    foreach (DataRow tRow in tTurnos.Rows)
                    {
                        var tRetiros = miBussinesRetiro.Retiros
                                       (fecha, Convert.ToInt32(cRow["idcaja"]), Convert.ToInt32(tRow["id"]));
                        if (tRetiros.Rows.Count != 0)
                        {
                            PrintPos(tRetiros);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private bool ValidarInt(string numero)
        {
            var pass = false;
            try
            {
                Convert.ToInt32(numero);
                pass = true;
            }
            catch (FormatException)
            {
                pass = false;
            }
            return pass;
        }

        private void btnEditarApertura_Click(object sender, EventArgs e)
        {
            if (this.dgvAperturas.RowCount > 0 || this.dgvIngresos.RowCount > 0)
            {
                if (this.PermisoEditarApertura)
                {
                    this.txtApertura.ReadOnly = false;
                    this.txtApertura.BackColor = System.Drawing.Color.White;
                    this.btnEditarApertura.Visible = false;
                    this.btnGuardarApertura.Visible = true;
                    this.txtApertura.Text = UseObject.RemoveSeparatorMil(this.txtApertura.Text).ToString();
                    this.txtApertura.Focus();
                    this.txtApertura.SelectAll();
                }
                else
                {
                    var admin = false;
                    while (!admin)
                    {
                        string rta = CustomControl.OptionPane.LoginUserPassword();
                        if (!rta.Equals("false"))
                        {
                            try
                            {
                                // validar usuario y contraseña incorrectos - si existe o no.
                                // validar si el usuario tiene permisos o no
                                // si tiene permisos continua el proceso.
                                string[] data = rta.Split('&');
                                var userTemp =
                                    this.miBussinesUsuario.Usuario_(new DTO.Clases.Usuario { Usuario_ = data[0], Contrasenia = Encode.Encrypt(data[1]) });
                                if (userTemp.Id != 0)
                                {
                                    if (userTemp.Permisos.Where(ps => ps.IdPermiso.Equals(IdPermisoEditarApertura)).Count() > 0)
                                    {
                                        this.txtApertura.ReadOnly = false;
                                        this.txtApertura.BackColor = System.Drawing.Color.White;
                                        this.btnEditarApertura.Visible = false;
                                        this.btnGuardarApertura.Visible = true;
                                        this.txtApertura.Text = UseObject.RemoveSeparatorMil(this.txtApertura.Text).ToString();
                                        this.txtApertura.Focus();
                                        this.txtApertura.SelectAll();
                                        admin = true;
                                    }
                                    else
                                    {
                                        MessageBox.Show("El usuario no tiene permisos para esta acción.", "Consulta de caja",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        admin = false;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show
                                        ("Usuario o contraseña incorrecta.", "Consulta de caja", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    admin = false;
                                }
                            }
                            catch (Exception ex)
                            {
                                OptionPane.MessageError(ex.Message);
                                admin = false;
                            }
                        }
                        else
                        {
                            admin = true;
                        }
                    }
                }
            }
            else
            {
                OptionPane.MessageInformation("No hay registros de aperturas cargados.");
            }
        }

        private void btnDetailIngresosFE_Click(object sender, EventArgs e)
        {
            //this.Apertura_.Fecha, this.Fecha2, Convert.ToInt32(cbCaja.SelectedValue)
            FormulariosSistema.FrmIncomeFE frmIncomeFE = new FormulariosSistema.FrmIncomeFE();
            frmIncomeFE.IdCaja = Convert.ToInt32(cbCaja.SelectedValue);
            frmIncomeFE.BeginDate = this.Apertura_.Fecha;
            frmIncomeFE.EndDate = this.Fecha2;
            frmIncomeFE.ShowDialog();
        }

        private void btnGuardarApertura_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.txtApertura.Text))
            {
                this.miError.SetError(this.txtApertura, null);
                if (ValidarInt(this.txtApertura.Text))
                {
                    this.miError.SetError(this.txtApertura, null);
                    DialogResult rta = MessageBox.Show("¿Está seguro(a) de guardar el valor de la apertura?", "Consulta de caja",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (rta.Equals(DialogResult.Yes))
                    {
                        try
                        {
                            this.miBussinesApertura.EditarApertura(Convert.ToInt32(this.dgvAperturas.CurrentRow.Cells["IdApertura"].Value),
                                Convert.ToInt32(this.txtApertura.Text));
                            this.txtApertura.ReadOnly = true;
                            this.txtApertura.BackColor = System.Drawing.Color.PaleTurquoise;
                            this.btnEditarApertura.Visible = true;
                            this.btnGuardarApertura.Visible = false;
                            int index = this.dgvAperturas.CurrentRow.Index;
                            this.btnBuscarApertura_Click(this.btnBuscarApertura, new EventArgs());
                            this.dgvAperturas.Rows[index].Selected = true;
                            this.dgvAperturas.CurrentCell = this.dgvAperturas.Rows[index].Cells[1];
                            this.btnBuscar_Click(this.btnBuscar, new EventArgs());
                            this.dgvAperturas.Focus();
                            OptionPane.MessageInformation("La apertura se edito con éxito.");
                        }
                        catch (Exception ex)
                        {
                            OptionPane.MessageError(ex.Message);
                        }
                    }
                }
                else
                {
                    this.miError.SetError(this.txtApertura, "El número que ingreso es inválido.");
                }
            }
            else
            {
                this.miError.SetError(this.txtApertura, "El campo no debe estar vacio.");
            }

        }

        private void txtApertura_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                if (!this.txtApertura.ReadOnly)
                {
                    this.btnGuardarApertura_Click(this.btnGuardarApertura, new EventArgs());
                }
            }
        }

        private void btnEditarCierre_Click(object sender, EventArgs e)
        {
            if (this.dgvIngresos.RowCount > 0)
            {
                if (!(this.dgvAperturas.CurrentRow.Cells["IdCierre"].Value == DBNull.Value))
                {
                    if (this.PermisoEditarCierre)
                    {
                        var tCierres = this.miBussinesCierre.Tcierres(Convert.ToInt32(this.dgvAperturas.CurrentRow.Cells["IdApertura"].Value));
                        var frmEditarCierre = new FrmEditarCierreCaja();
                        frmEditarCierre.IdCierre = Convert.ToInt32(this.dgvAperturas.CurrentRow.Cells["IdCierre"].Value);
                        frmEditarCierre.txtEfectivo.Text =
                            tCierres.AsEnumerable().Where(p => p.Field<int>("idpago") == 1).Sum(s => s.Field<int>("valor")).ToString();
                        frmEditarCierre.txtCheque.Text =
                            tCierres.AsEnumerable().Where(p => p.Field<int>("idpago") == 2).Sum(s => s.Field<int>("valor")).ToString();
                        frmEditarCierre.txtTarjeta.Text =
                            tCierres.AsEnumerable().Where(p => p.Field<int>("idpago") == 3).Sum(s => s.Field<int>("valor")).ToString();
                        frmEditarCierre.txtTransaccion.Text =
                            tCierres.AsEnumerable().Where(p => p.Field<int>("idpago") == 4).Sum(s => s.Field<int>("valor")).ToString();
                        frmEditarCierre.ShowDialog();
                        /*this.txtCierre.ReadOnly = false;
                        this.txtCierre.BackColor = System.Drawing.Color.White;
                        this.btnEditarCierre.Visible = false;
                        this.btnGuardarCierre.Visible = true;
                        this.txtCierre.Text = UseObject.RemoveSeparatorMil(this.txtCierre.Text).ToString();
                        this.txtCierre.Focus();
                        this.txtCierre.SelectAll();*/
                    }
                    else
                    {
                        var admin = false;
                        while (!admin)
                        {
                            string rta = CustomControl.OptionPane.LoginUserPassword();
                            if (!rta.Equals("false"))
                            {
                                try
                                {
                                    // validar usuario y contraseña incorrectos - si existe o no.
                                    // validar si el usuario tiene permisos o no
                                    // si tiene permisos continua el proceso.
                                    string[] data = rta.Split('&');
                                    var userTemp =
                                        this.miBussinesUsuario.Usuario_(new DTO.Clases.Usuario { Usuario_ = data[0], Contrasenia = Encode.Encrypt(data[1]) });
                                    if (userTemp.Id != 0)
                                    {
                                        if (userTemp.Permisos.Where(ps => ps.IdPermiso.Equals(IdPermisoEditarCierre)).Count() > 0)
                                        {
                                            var tCierres = this.miBussinesCierre.Tcierres(Convert.ToInt32(this.dgvAperturas.CurrentRow.Cells["IdApertura"].Value));
                                            var frmEditarCierre = new FrmEditarCierreCaja();
                                            frmEditarCierre.IdCierre = Convert.ToInt32(this.dgvAperturas.CurrentRow.Cells["IdCierre"].Value);
                                            frmEditarCierre.txtEfectivo.Text =
                                                tCierres.AsEnumerable().Where(p => p.Field<int>("idpago") == 1).Sum(s => s.Field<int>("valor")).ToString();
                                            frmEditarCierre.txtCheque.Text =
                                                tCierres.AsEnumerable().Where(p => p.Field<int>("idpago") == 2).Sum(s => s.Field<int>("valor")).ToString();
                                            frmEditarCierre.txtTarjeta.Text =
                                                tCierres.AsEnumerable().Where(p => p.Field<int>("idpago") == 3).Sum(s => s.Field<int>("valor")).ToString();
                                            frmEditarCierre.txtTransaccion.Text =
                                                tCierres.AsEnumerable().Where(p => p.Field<int>("idpago") == 4).Sum(s => s.Field<int>("valor")).ToString();
                                            frmEditarCierre.ShowDialog();
                                            /*this.txtCierre.ReadOnly = false;
                                            this.txtCierre.BackColor = System.Drawing.Color.White;
                                            this.btnEditarCierre.Visible = false;
                                            this.btnGuardarCierre.Visible = true;
                                            this.txtCierre.Text = UseObject.RemoveSeparatorMil(this.txtCierre.Text).ToString();
                                            this.txtCierre.Focus();
                                            this.txtCierre.SelectAll();*/
                                            admin = true;
                                        }
                                        else
                                        {
                                            MessageBox.Show("El usuario no tiene permisos para esta acción.", "Consulta de caja",
                                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            admin = false;
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show
                                            ("Usuario o contraseña incorrecta.", "Consulta de caja", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        admin = false;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    OptionPane.MessageError(ex.Message);
                                    admin = false;
                                }
                            }
                            else
                            {
                                admin = true;
                            }
                        }
                    }
                }
                else
                {
                    OptionPane.MessageInformation("No existe cierre para el registro.");
                }
            }
            else
            {
                OptionPane.MessageInformation("No hay registros de aperturas cargados.");
            }
        }

        private void btnGuardarCierre_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.txtCierre.Text))
            {
                this.miError.SetError(this.txtCierre, null);
                if (ValidarInt(this.txtCierre.Text))
                {
                    this.miError.SetError(this.txtCierre, null);
                    DialogResult rta = MessageBox.Show("¿Está seguro(a) de guardar el valor del cierre?", "Consulta de caja",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (rta.Equals(DialogResult.Yes))
                    {
                        try
                        {
                            /* this.miBussinesCierre.EditarCierre(Convert.ToInt32(this.dgvAperturas.CurrentRow.Cells["IdCierre"].Value),
                                 Convert.ToInt32(this.txtCierre.Text));*/
                            this.txtCierre.ReadOnly = true;
                            this.txtCierre.BackColor = System.Drawing.Color.PaleTurquoise;
                            this.btnEditarCierre.Visible = true;
                            this.btnGuardarCierre.Visible = false;
                            int index = this.dgvAperturas.CurrentRow.Index;
                            this.btnBuscarApertura_Click(this.btnBuscarApertura, new EventArgs());
                            this.dgvAperturas.Rows[index].Selected = true;
                            this.dgvAperturas.CurrentCell = this.dgvAperturas.Rows[index].Cells[1];
                            this.btnBuscar_Click(this.btnBuscar, new EventArgs());
                            this.dgvAperturas.Focus();
                            OptionPane.MessageInformation("El cierre se edito con éxito.");
                        }
                        catch (Exception ex)
                        {
                            OptionPane.MessageError(ex.Message);
                        }
                    }
                }
                else
                {
                    this.miError.SetError(this.txtCierre, "El número que ingreso es inválido.");
                }
            }
            else
            {
                this.miError.SetError(this.txtCierre, "El campo no debe estar vacio.");
            }
        }

        private void txtCierre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                if (!this.txtCierre.ReadOnly)
                {
                    this.btnGuardarCierre_Click(this.btnGuardarCierre, new EventArgs());
                }
            }
        }

        private void btnEditarRetiros_Click(object sender, EventArgs e)
        {
            if (this.dgvRetiros.RowCount > 0)
            {
                if (this.PermisoEditarRetiro)
                {
                    FrmEditarRetiro frmEditar = new FrmEditarRetiro();
                    frmEditar.Id = Convert.ToInt32(this.dgvRetiros.CurrentRow.Cells["Id"].Value);
                    frmEditar.txtRetiro.Text = this.dgvPagos.CurrentRow.Cells["Valor"].Value.ToString();
                    frmEditar.ShowDialog();
                }
                else
                {
                    var admin = false;
                    while (!admin)
                    {
                        string rta = CustomControl.OptionPane.LoginUserPassword();
                        if (!rta.Equals("false"))
                        {
                            try
                            {
                                // validar usuario y contraseña incorrectos - si existe o no.
                                // validar si el usuario tiene permisos o no
                                // si tiene permisos continua el proceso.
                                string[] data = rta.Split('&');
                                var userTemp =
                                    this.miBussinesUsuario.Usuario_(new DTO.Clases.Usuario { Usuario_ = data[0], Contrasenia = Encode.Encrypt(data[1]) });
                                if (userTemp.Id != 0)
                                {
                                    if (userTemp.Permisos.Where(ps => ps.IdPermiso.Equals(IdPermisoEditarRetiro)).Count() > 0)
                                    {
                                        FrmEditarRetiro frmEditar = new FrmEditarRetiro();
                                        frmEditar.Id = Convert.ToInt32(this.dgvRetiros.CurrentRow.Cells["Id"].Value);
                                        frmEditar.txtRetiro.Text = this.dgvPagos.CurrentRow.Cells["Valor"].Value.ToString();
                                        frmEditar.ShowDialog();
                                        admin = true;
                                    }
                                    else
                                    {
                                        MessageBox.Show("El usuario no tiene permisos para esta acción.", "Consulta de caja",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        admin = false;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show
                                        ("Usuario o contraseña incorrecta.", "Consulta de caja", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    admin = false;
                                }
                            }
                            catch (Exception ex)
                            {
                                OptionPane.MessageError(ex.Message);
                                admin = false;
                            }
                        }
                        else
                        {
                            admin = true;
                        }
                    }
                }
            }
            else
            {
                OptionPane.MessageInformation("No hay registros de retiro para editar.");
            }
        }


        void CompletaEventos_Completo(CompletaArgumentosDeEvento args)
        {
            try
            {
                ObjectAbstract obj = (ObjectAbstract)args.MiObjeto;
                if (obj.Id == 98987)
                {
                    this.dgvRetiros_CellClick(this.dgvRetiros, null);
                }
                else
                {
                    if (obj.Id == 555888779)
                    {
                        int index = this.dgvAperturas.CurrentRow.Index;
                        this.btnBuscarApertura_Click(this.btnBuscarApertura, new EventArgs());
                        this.dgvAperturas.Rows[index].Selected = true;
                        this.dgvAperturas.CurrentCell = this.dgvAperturas.Rows[index].Cells[1];
                        this.btnBuscar_Click(this.btnBuscar, new EventArgs());
                    }
                }
            }
            catch { }
        }

        
    }
}