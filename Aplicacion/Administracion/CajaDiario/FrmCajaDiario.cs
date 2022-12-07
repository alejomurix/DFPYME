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
using Microsoft.Reporting.WinForms;
using Utilities;

namespace Aplicacion.Administracion.CajaDiario
{
    public partial class FrmCajaDiario : Form
    {
        public bool General { set; get; }

        public bool PeriodoFecha { set; get; }

        public bool RetroActivo { set; get; }

        

        public DateTime Fecha { set; get; }

        public DateTime Fecha2 { set; get; }

        public string FechaParameter { set; get; }

        public bool Soporte { set; get; }

        public bool Numeracion { set; get; }

        public bool Admin { set; get; }

        public int IdCaja { set; get; }

        public int IdUser { set; get; }

        public string ReportPath { set; get; }

        private int TotalDevContado { set; get; }

        private int AcumuladoToday { set; get; }

        private BussinesCaja miBussinesCaja;

        private BussinesEmpresa miBussinesEmpresa;

        private BussinesUsuario miBussinesUsuario;

        private BussinesFacturaVenta miBussinesFactura;

        private BussinesImpuestoBolsa miBussinesImpuestoBolsas;

        private BussinesDevolucion miBussinesDevolcion;

        private BussinesEgreso miBussinesEgreso;

        private BussinesAcumulado miBussinesAcumulado;

        private BussinesDian miBussinesDian;

        private DataSet DsEmpresa;

        private DataSet DsUsuario;

        private DataSet DsIvaGravado;

        // NUEVO CODIGO 02-02-2016
        private DataTable DtIvaGravado;


        private DTO.Clases.ImpuestoBolsa ImpstoBolsas;

        private DataSet DsAbono;

        private DataSet DsIvaDevolucion;

        private DataTable tIvaVentasAnuladas;

        private DataTable tIvaDevolucion;

        private DataTable DsDevolucion;

        private DataTable DsEgreso;

        private DataSet DsFacturaCredito;

        List<IvaDevolucion> ivaDevoluciones;

        List<IvaAnulado> ivaAnuladas;

        List<DTO.Clases.Dian> autorFactsDian;


        public List<Impuesto> Impuestos;


        public bool AnexoInfo { set; get; }

        public int Dia_ { set; get; }

        ///public bool ThreadTicket;

        public FrmCajaDiario()
        {
            InitializeComponent();
            try
            {
                miBussinesCaja = new BussinesCaja();
                miBussinesEmpresa = new BussinesEmpresa();
                miBussinesUsuario = new BussinesUsuario();
                miBussinesFactura = new BussinesFacturaVenta();
                miBussinesImpuestoBolsas = new BussinesImpuestoBolsa();
                miBussinesDevolcion = new BussinesDevolucion();
                miBussinesEgreso = new BussinesEgreso();
                miBussinesAcumulado = new BussinesAcumulado();
                miBussinesDian = new BussinesDian();

                General = false;
                this.PeriodoFecha = false;
                RetroActivo = false;
                IdCaja = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_caja"));
                IdUser = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_user"));
                Soporte = false;
                Numeracion = false;
                AcumuladoToday = 0;
                ReportPath = AppConfiguracion.ValorSeccion("report") + @"\reports\RptCajaDiario_Caja.rdlc";

                DsEmpresa = new DataSet();
                DsUsuario = new DataSet();
                DsIvaGravado = new DataSet();
                // NUEVO CODIGO 02-02-2016
                DtIvaGravado = new DataTable();
                DsAbono = new DataSet();
                DsIvaDevolucion = new DataSet();
                this.tIvaVentasAnuladas = new DataTable();
                this.tIvaDevolucion = new DataTable();
                DsDevolucion = new DataTable();
                DsEgreso = new DataTable();
                DsFacturaCredito = new DataSet();


                this.AnexoInfo = false;
                this.Dia_ = 0;
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void FrmCajaDiario_Load(object sender, EventArgs e)
        {
            this.rptVCajaDiario.RefreshReport();
            if (Soporte)
            {
                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("printCompDiario")))
                {
                    PrintComprobantePos();
                }
                else
                {
                    if (!Admin)//otro
                    {
                        //Fecha = DateTime.Now;
                        CargarDatosGenerales();
                        //CargarDatos();
                        if (this.PeriodoFecha)
                        {
                            this.CargarDatosPeriodo();
                        }
                        else
                        {
                            this.CargarDatos();
                        }
                        CargarDatosFinales();
                    }
                    else//admin
                    {

                    }
                }
            }
            else
            {
                if (!Admin)//otro
                {
                    //Fecha = DateTime.Now;
                    this.CargarDatosGenerales();
                    if (this.PeriodoFecha)
                    {
                        this.CargarDatosPeriodo();
                    }
                    else
                    {
                        this.CargarDatos();
                    }
                    this.CargarDatosFinales();
                }
                else//admin
                {

                }
            }
            //CargarDatos();
        }

        public void rptVCajaDiario_Print(object sender, ReportPrintEventArgs e)
        {
            try
            {
                Imprimir print = new Imprimir();
                //print.Carta = true;
                print.Report = this.rptVCajaDiario.LocalReport;
                print.Print(Imprimir.TamanioPapel.Carta);
                //this.Close();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void FrmCajaDiario_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.rptVCajaDiario.Reset();
        }

        public void LoadData()
        {
            //this.rptVCajaDiario.RefreshReport();
            if (Soporte)
            {
                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("printCompDiario")))
                {
                    PrintComprobantePos();
                }
                else
                {
                    if (!Admin)//otro
                    {
                        //Fecha = DateTime.Now;
                        CargarDatosGenerales();
                        //CargarDatos();
                        if (this.PeriodoFecha)
                        {
                            this.CargarDatosPeriodo();
                        }
                        else
                        {
                            this.CargarDatos();
                        }
                        CargarDatosFinales();
                    }
                    else//admin
                    {

                    }
                }
            }
            else
            {
                if (!Admin)//otro
                {
                    //Fecha = DateTime.Now;
                    this.CargarDatosGenerales();
                    if (this.PeriodoFecha)
                    {
                        this.CargarDatosPeriodo();
                    }
                    else
                    {
                        this.CargarDatos();
                    }
                    this.CargarDatosFinales();
                }
                else//admin
                {

                }
            }
        }

        public void CargarDatos()
        {
            try
            {
                if (General)
                {
                    //DsIvaGravado = miBussinesFactura.TotalIvaFacturado(IdCaja, Fecha, false);
                    // NUEVO CODIGO 23-02-2017
                    //this.DsIvaGravado = miBussinesFactura.TotalIvaFacturado2Ds(Fecha);

                //this.DtIvaGravado = miBussinesFactura.TotalIvaFacturado(Fecha, "EXENTO");
                    ///Impuestos = miBussinesFactura.TotalesImpuesto(Fecha);
                    this.ImpstoBolsas = this.miBussinesImpuestoBolsas.ImpuestoBolsaDeVenta(this.Fecha);
                    //DsAbono = miBussinesFactura.TotalAbonosFecha(Fecha);
                    //DsIvaDevolucion = miBussinesDevolcion.IvaDevolucion(Fecha);

                    this.tIvaVentasAnuladas = this.miBussinesFactura.TVentasAnuladas(this.Fecha);
                    this.tIvaDevolucion = this.miBussinesDevolcion.TIvaDevoluciones(this.Fecha);
                    if (Soporte)
                    {
                        var DsAnulada = new DataTable();
                        DsAnulada = miBussinesFactura.FacturasAnuladas(Fecha);
                        DsDevolucion = miBussinesDevolcion.Devoluciones(Fecha);

                        this.rptVCajaDiario.LocalReport.DataSources.Add(
                            new ReportDataSource("DsAnulada", DsAnulada));

                        this.rptVCajaDiario.LocalReport.DataSources.Add(
                            new ReportDataSource("DsDevolucion", DsDevolucion));
                    }
                    else
                    {
                        /**
                        DsEgreso = miBussinesEgreso.Listado(Fecha);
                        DsFacturaCredito = miBussinesFactura.TotalFacturasCredito(2, IdCaja, Fecha, false);

                        this.rptVCajaDiario.LocalReport.DataSources.Add(
                        new ReportDataSource("DsEgreso", DsEgreso));

                        this.rptVCajaDiario.LocalReport.DataSources.Add(
                        new ReportDataSource("DsFacturaCredito", DsFacturaCredito.Tables["FacturaCredito"]));*/

                        //AcumuladoToday = Acumulado(Fecha);
                        AcumuladoToday = Acumulado(new DateTime(Fecha.Year, Fecha.Month, 1), Fecha);
                    }

                    /*this.rptVCajaDiario.LocalReport.DataSources.Add(
                    new ReportDataSource("DsIvaGravado", this.DtIvaGravado));*/

                    //this.rptVCajaDiario.LocalReport.DataSources.Add(new ReportDataSource("",

                    this.rptVCajaDiario.LocalReport.DataSources.Add(
                        new ReportDataSource("ImpuestoIva", this.Impuestos));


                    /*this.rptVCajaDiario.LocalReport.DataSources.Add(
                        new ReportDataSource("DsAbono", DsAbono.Tables["Abono"]));*/

                    this.rptVCajaDiario.LocalReport.DataSources.Add(
                        new ReportDataSource("DsIvaVentaAnulada", this.tIvaVentasAnuladas));
                    this.rptVCajaDiario.LocalReport.DataSources.Add(
                        new ReportDataSource("DsIvaDevolucion", this.tIvaDevolucion));
                }
                else
                {
                   //AcumuladoToday = AcumuladoCaja_(IdCaja, new DateTime(Fecha.Year, Fecha.Month, 1), Fecha);

                    //DsIvaGravado = miBussinesFactura.TotalIvaFacturado(IdCaja, Fecha, true);
                    // NUEVO CODIGO 02-02-2016
                    //this.DtIvaGravado = miBussinesFactura.TotalIvaFacturado(IdCaja, Fecha);


               //this.DtIvaGravado = miBussinesFactura.TotalIvaFacturadoConExcento(IdCaja, Fecha, "EXENTO");              // Nuevo codigo: 24 Nov. 2019
                    ///Impuestos = miBussinesFactura.TotalesImpuesto(IdCaja, Fecha);
                    this.ImpstoBolsas = this.miBussinesImpuestoBolsas.ImpuestoBolsaDeVenta(this.IdCaja, this.Fecha);

                    ///DsAbono = miBussinesFactura.TotalAbonos(IdCaja, Fecha);
                    //DsIvaDevolucion = miBussinesDevolcion.IvaDevolucion(IdCaja, Fecha);

                    this.tIvaVentasAnuladas = this.miBussinesFactura.TVentasAnuladas(this.IdCaja, this.Fecha);
                    this.tIvaDevolucion = this.miBussinesDevolcion.TIvaDevoluciones(this.IdCaja, this.Fecha);

                    if (Soporte)
                    {
                        var DsAnulada = new DataTable();
                        DsAnulada = miBussinesFactura.FacturasAnuladas(IdCaja, Fecha);
                        DsDevolucion = miBussinesDevolcion.Devoluciones(IdCaja, Fecha);

                        this.rptVCajaDiario.LocalReport.DataSources.Add(
                            new ReportDataSource("DsAnulada", DsAnulada));

                        this.rptVCajaDiario.LocalReport.DataSources.Add(
                        new ReportDataSource("DsDevolucion", DsDevolucion));
                    }
                    else
                    {
                        /**
                        DsEgreso = miBussinesEgreso.Listado(IdCaja, Fecha);
                        DsFacturaCredito = miBussinesFactura.TotalFacturasCredito(2, IdCaja, Fecha, true);

                        this.rptVCajaDiario.LocalReport.DataSources.Add(
                        new ReportDataSource("DsEgreso", DsEgreso));

                        this.rptVCajaDiario.LocalReport.DataSources.Add(
                        new ReportDataSource("DsFacturaCredito", DsFacturaCredito.Tables["FacturaCredito"]));*/

                       // AcumuladoToday = AcumuladoCaja(Fecha, IdCaja);

                        // NUEVO CODIGO 30-01-2016
                        AcumuladoToday = AcumuladoCaja_(IdCaja, new DateTime(Fecha.Year, Fecha.Month, 1), Fecha);

                    }

                    

                    // NUEVO CODIGO 02-02-2016
             /*this.rptVCajaDiario.LocalReport.DataSources.Add(
                        new ReportDataSource("DsIvaGravado", this.DtIvaGravado));*/

                    this.rptVCajaDiario.LocalReport.DataSources.Add(
                        new ReportDataSource("ImpuestoIva", this.Impuestos));

                    //
                    /*this.rptVCajaDiario.LocalReport.DataSources.Add(
                        new ReportDataSource("DsAbono", DsAbono.Tables["Abono"]));*/

                    this.rptVCajaDiario.LocalReport.DataSources.Add(
                        new ReportDataSource("DsIvaVentaAnulada", this.tIvaVentasAnuladas));
                    this.rptVCajaDiario.LocalReport.DataSources.Add(
                        new ReportDataSource("DsIvaDevolucion", this.tIvaDevolucion));
                }

                ///AcumuladoToday += Convert.ToInt32(ImpstoBolsas.Cantidad * ImpstoBolsas.Valor);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        public void CargarDatosPeriodo()  // Todas las cajas (General)
        {
            try
            {
            //this.DtIvaGravado       = this.miBussinesFactura.TotalIvaFacturado(this.Fecha, this.Fecha2);

                ///Impuestos = this.miBussinesFactura.TotalesImpuesto(Fecha, Fecha2);
                Impuestos = miBussinesFactura.TotalesImpuesto(0, Fecha, Fecha2);        // improve to fiscal report: new 2022
                
                this.ImpstoBolsas       = this.miBussinesImpuestoBolsas.ImpuestoBolsaDeVenta(this.Fecha, this.Fecha2);
                this.tIvaVentasAnuladas = this.miBussinesFactura.TVentasAnuladas(this.Fecha, this.Fecha2);
                this.tIvaDevolucion     = this.miBussinesDevolcion.TIvaDevoluciones(this.Fecha, this.Fecha2);
                //this.DsFacturaCredito   = this.miBussinesFactura.TotalFacturasCredito(2, this.IdCaja, this.Fecha, this.Fecha2, false);

            //this.rptVCajaDiario.LocalReport.DataSources.Add(new ReportDataSource("DsIvaGravado", this.DtIvaGravado));
                this.rptVCajaDiario.LocalReport.DataSources.Add(new ReportDataSource("ImpuestoIva", this.Impuestos));
                this.rptVCajaDiario.LocalReport.DataSources.Add(new ReportDataSource("DsIvaVentaAnulada", this.tIvaVentasAnuladas));
                this.rptVCajaDiario.LocalReport.DataSources.Add(new ReportDataSource("DsIvaDevolucion", this.tIvaDevolucion));
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void CargarDatosGenerales()
        {
            try
            {
                this.rptVCajaDiario.LocalReport.DataSources.Clear();
                this.rptVCajaDiario.LocalReport.Dispose();
                this.rptVCajaDiario.Reset();

                DsEmpresa = miBussinesEmpresa.PrintEmpresa();
                /*DsUsuario = miBussinesUsuario.PrintUsuario
                    (Convert.ToInt32(AppConfiguracion.ValorSeccion("id_user")));*/

                this.rptVCajaDiario.LocalReport.DataSources.Add(
                    new ReportDataSource("DsEmpresa", DsEmpresa.Tables["Empresa"]));
                /*this.rptVCajaDiario.LocalReport.DataSources.Add(
                    new ReportDataSource("DsUsuario", DsUsuario.Tables["Usuario"]));*/
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void CargarDatosCajaFecha()
        {

        }

        private void CargarDatosFinales()
        {
            try
            {
                this.rptVCajaDiario.LocalReport.ReportPath = this.ReportPath;
                if (General)
                {
                    var regInicial = " ";
                    var regFinal = " ";
                    var totalReg = " ";

                    var tabla = new DataTable();
                    if (this.PeriodoFecha)
                    {
                        tabla = this.miBussinesFactura.RegistroVentas(this.Fecha, this.Fecha2);
                    }
                    else
                    {
                        tabla = this.miBussinesFactura.RegistroVentas(IdCaja, Fecha, false);
                    }
                    if (tabla.Rows.Count > 0)
                    {
                        regInicial = tabla.Rows[0]["numerofactura_venta"].ToString();
                        regFinal = tabla.Rows[tabla.Rows.Count - 1]["numerofactura_venta"].ToString();
                        totalReg = tabla.Rows.Count.ToString();
                    }
                    var pRegInicial = new ReportParameter();
                    pRegInicial.Name = "RegInicial";
                    pRegInicial.Values.Add(regInicial);
                    this.rptVCajaDiario.LocalReport.SetParameters(pRegInicial);

                    var pRegFinal = new ReportParameter();
                    pRegFinal.Name = "RegFinal";
                    pRegFinal.Values.Add(regFinal);
                    this.rptVCajaDiario.LocalReport.SetParameters(pRegFinal);

                    var pRegTotal = new ReportParameter();
                    pRegTotal.Name = "RegTotal";
                    pRegTotal.Values.Add(totalReg);
                    this.rptVCajaDiario.LocalReport.SetParameters(pRegTotal);

                    var pFecha = new ReportParameter();
                    pFecha.Name = "Fecha";
                    pFecha.Values.Add(FechaParameter);
                    /*if (this.PeriodoFecha)
                    {
                        pFecha.Values.Add(this.Fecha.ToShortDateString() + " a " + this.Fecha2.ToShortDateString());
                    }
                    else
                    {
                        pFecha.Values.Add(Fecha.ToString());
                    }*/
                    this.rptVCajaDiario.LocalReport.SetParameters(pFecha);

                    var pCaja = new ReportParameter();
                    pCaja.Name = "Caja";
                    pCaja.Values.Add("0");
                    this.rptVCajaDiario.LocalReport.SetParameters(pCaja);

                    var pIcoBolsasCant = new ReportParameter();
                    pIcoBolsasCant.Name = "IncbCantidad";
                    pIcoBolsasCant.Values.Add(this.ImpstoBolsas.Cantidad.ToString());
                    this.rptVCajaDiario.LocalReport.SetParameters(pIcoBolsasCant);

                    var pIcoBolsasValor = new ReportParameter();
                    pIcoBolsasValor.Name = "IncbValor";
                    pIcoBolsasValor.Values.Add(this.ImpstoBolsas.Valor.ToString());
                    this.rptVCajaDiario.LocalReport.SetParameters(pIcoBolsasValor);

                    var pIcoBolsasTotal = new ReportParameter();
                    pIcoBolsasTotal.Name = "IncbTotal";
                    pIcoBolsasTotal.Values.Add((this.ImpstoBolsas.Cantidad * this.ImpstoBolsas.Valor).ToString());
                    this.rptVCajaDiario.LocalReport.SetParameters(pIcoBolsasTotal);


                    //                                  edit for improve fiscal report 2022

                    var pAcumulado = new ReportParameter();
                    pAcumulado.Name = "Acumulado";
                    if (PeriodoFecha)
                    {
                        pAcumulado.Values.Add("0");
                    }
                    else
                    {
                        pAcumulado.Values.Add(AcumuladoToday.ToString());
                    }
                    this.rptVCajaDiario.LocalReport.SetParameters(pAcumulado);

                    var pNo = new ReportParameter();
                    pNo.Name = "No";
                    pNo.Values.Add(Consecutivo(Fecha).ToString());
                    this.rptVCajaDiario.LocalReport.SetParameters(pNo);

                    //                                  edit for improve fiscal report 2022




                    /**     // edit for improve fiscal report 2022
                    if (!this.PeriodoFecha)
                    {
                        if (!Soporte)
                        {
                            var pAcumulado = new ReportParameter();
                            pAcumulado.Name = "Acumulado";
                            pAcumulado.Values.Add(AcumuladoToday.ToString());
                            this.rptVCajaDiario.LocalReport.SetParameters(pAcumulado);
                        }
                    }
                    if (Numeracion)
                    {
                        var pNo = new ReportParameter();
                        pNo.Name = "No";
                        pNo.Values.Add(Consecutivo(Fecha).ToString());
                        this.rptVCajaDiario.LocalReport.SetParameters(pNo);
                    }
                    */
                }
                else
                {
                   // this.rptVCajaDiario.LocalReport.ReportPath = this.ReportPath;
                    var regInicial = " ";
                    var regFinal = " ";
                    var totalReg = " ";

                    var tabla = miBussinesFactura.RegistroVentas(IdCaja, Fecha, true);
                    if (tabla.Rows.Count > 0)
                    {
                        regInicial = tabla.Rows[0]["numerofactura_venta"].ToString();
                        regFinal = tabla.Rows[tabla.Rows.Count - 1]["numerofactura_venta"].ToString();
                        totalReg = tabla.Rows.Count.ToString();
                    }
                    var pRegInicial = new ReportParameter();
                    pRegInicial.Name = "RegInicial";
                    pRegInicial.Values.Add(regInicial);
                    this.rptVCajaDiario.LocalReport.SetParameters(pRegInicial);

                    var pRegFinal = new ReportParameter();
                    pRegFinal.Name = "RegFinal";
                    pRegFinal.Values.Add(regFinal);
                    this.rptVCajaDiario.LocalReport.SetParameters(pRegFinal);

                    var pRegTotal = new ReportParameter();
                    pRegTotal.Name = "RegTotal";
                    pRegTotal.Values.Add(totalReg);
                    this.rptVCajaDiario.LocalReport.SetParameters(pRegTotal);

                    var pFecha = new ReportParameter();
                    pFecha.Name = "Fecha";
                    pFecha.Values.Add(FechaParameter);
                    this.rptVCajaDiario.LocalReport.SetParameters(pFecha);

                    var pCaja = new ReportParameter();
                    pCaja.Name = "Caja";
                    pCaja.Values.Add(miBussinesCaja.CajaId(this.IdCaja).Numero.ToString());
                    this.rptVCajaDiario.LocalReport.SetParameters(pCaja);

                    var pIcoBolsasCant = new ReportParameter();
                    pIcoBolsasCant.Name = "IncbCantidad";
                    pIcoBolsasCant.Values.Add(this.ImpstoBolsas.Cantidad.ToString());
                    this.rptVCajaDiario.LocalReport.SetParameters(pIcoBolsasCant);

                    var pIcoBolsasValor = new ReportParameter();
                    pIcoBolsasValor.Name = "IncbValor";
                    pIcoBolsasValor.Values.Add(this.ImpstoBolsas.Valor.ToString());
                    this.rptVCajaDiario.LocalReport.SetParameters(pIcoBolsasValor);

                    var pIcoBolsasTotal = new ReportParameter();
                    pIcoBolsasTotal.Name = "IncbTotal";
                    pIcoBolsasTotal.Values.Add((this.ImpstoBolsas.Cantidad * this.ImpstoBolsas.Valor).ToString());
                    this.rptVCajaDiario.LocalReport.SetParameters(pIcoBolsasTotal);

                    if (!Soporte)
                    {
                        var pAcumulado = new ReportParameter();
                        pAcumulado.Name = "Acumulado";
                        pAcumulado.Values.Add(AcumuladoToday.ToString());
                        this.rptVCajaDiario.LocalReport.SetParameters(pAcumulado);
                    }

                    if (Numeracion)
                    {
                        var pNo = new ReportParameter();
                        pNo.Name = "No";
                        pNo.Values.Add(Consecutivo(Fecha).ToString());
                        this.rptVCajaDiario.LocalReport.SetParameters(pNo);
                    }
                }

                this.rptVCajaDiario.RefreshReport();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private long Consecutivo(DateTime fecha)
        {
            int id = 0;
            var miBussinesRegistro = new BussinesConsecutivoInforme();
            if (General)
            {
                if (RetroActivo)
                {
                    if (miBussinesRegistro.CountGeneral().Equals(0)) // no hay registros de consecutivo de informe.
                    {
                        if (miBussinesFactura.CountRegistroVentas().Equals(0))
                        {
                            id = miBussinesCaja.ConsecutivoGeneral();
                            miBussinesRegistro.IngresarRegistroGeneral(fecha, id);
                            miBussinesCaja.ActualizarConsecutivoGeneral();
                        }
                        else
                        {
                            DateTime minVenta = UseDate.FechaSinHora(miBussinesFactura.MinFecha());
                            DateTime newDate = UseDate.FechaSinHora(fecha);

                            TimeSpan ts = newDate - minVenta;

                            int difDays = ts.Days + 1;
                            for (int i = 1; i <= difDays; i++)
                            {
                                //minVenta = minVenta.AddDays(1);
                                miBussinesRegistro.IngresarRegistroGeneral(minVenta, miBussinesCaja.ConsecutivoGeneral());
                                miBussinesCaja.ActualizarConsecutivoGeneral();
                                minVenta = minVenta.AddDays(1);
                            }
                            var tabla = miBussinesRegistro.ConsultarRegistroGeneral(fecha);
                            id = Convert.ToInt32(tabla.AsEnumerable().Single()["numero"]);
                        }
                    }
                    else  //  si hay registros de consecutivo de informe.
                    {
                        var tabla = miBussinesRegistro.ConsultarRegistroGeneral(fecha);
                        if (tabla.Rows.Count != 0)  //  la fecha corresponde a un registro.
                        {
                            id = Convert.ToInt32(tabla.AsEnumerable().Single()["numero"]);
                        }
                        else  //  la fecha no corresponde a ningun registro.
                        {
                            DateTime oldDate = UseDate.FechaSinHora(miBussinesRegistro.MaxFechaGeneral());
                            DateTime newDate = UseDate.FechaSinHora(fecha);

                            TimeSpan ts = newDate - oldDate;

                            int difDays = ts.Days;
                            for (int i = 1; i <= difDays; i++)
                            {
                                oldDate = oldDate.AddDays(1);
                                miBussinesRegistro.IngresarRegistroGeneral(oldDate, miBussinesCaja.ConsecutivoGeneral());
                                miBussinesCaja.ActualizarConsecutivoGeneral();
                            }
                            tabla = miBussinesRegistro.ConsultarRegistroGeneral(fecha);
                            id = Convert.ToInt32(tabla.AsEnumerable().Single()["numero"]);
                        }
                    }
                }
                else
                {
                    var tabla = miBussinesRegistro.ConsultarRegistroGeneral(fecha);
                    if (tabla.Rows.Count != 0)
                    {
                        //Fecha ya existe
                        var row = tabla.AsEnumerable().Single();
                        id = Convert.ToInt32(row["numero"]);
                    }
                    else
                    {
                        id = miBussinesCaja.ConsecutivoGeneral();
                        miBussinesRegistro.IngresarRegistroGeneral(fecha, id);
                        miBussinesCaja.ActualizarConsecutivoGeneral();
                    }
                }
                /*var tabla = miBussinesRegistro.ConsultarRegistroGeneral(fecha);
                if (tabla.Rows.Count != 0)
                {
                    //Fecha ya existe
                    var row = tabla.AsEnumerable().Single();
                    id = Convert.ToInt32(row["numero"]);
                }
                else
                {
                    id = miBussinesCaja.ConsecutivoGeneral(IdCaja);
                    miBussinesRegistro.IngresarRegistroGeneral(fecha, IdCaja, id);
                    miBussinesCaja.ActualizarConsecutivoGeneral(IdCaja);
                }*/
            }
            else
            {
                if (!RetroActivo)// dia por dia
                {
                    var tabla = miBussinesRegistro.ConsultarRegistro(fecha, IdCaja);
                    if (tabla.Rows.Count != 0)
                    {
                        //Fecha ya existe
                        var row = tabla.AsEnumerable().Single();
                        id = Convert.ToInt32(row["numero"]);
                    }
                    else
                    {
                        //Fecha no existe
                        id = miBussinesCaja.Consecutivo(IdCaja);
                        miBussinesRegistro.IngresarRegistro(fecha, IdCaja, id);
                        miBussinesCaja.ActualizarConsecutivo(IdCaja);
                    }
                }
                else
                {
                    if (miBussinesRegistro.Count(IdCaja).Equals(0)) // no hay registros de consecutivo de informe.
                    {
                        if (miBussinesFactura.CountRegistroVentas(IdCaja).Equals(0))
                        {
                            id = miBussinesCaja.Consecutivo(IdCaja);
                            miBussinesRegistro.IngresarRegistro(fecha, IdCaja, id);
                            miBussinesCaja.ActualizarConsecutivo(IdCaja);
                        }
                        else
                        {
                            DateTime minVenta = UseDate.FechaSinHora(miBussinesFactura.MinFecha());
                            DateTime newDate = UseDate.FechaSinHora(fecha);

                            TimeSpan ts = newDate - minVenta;

                            int difDays = ts.Days + 1;
                            for (int i = 1; i <= difDays; i++)
                            {
                               // minVenta = minVenta.AddDays(1);
                                miBussinesRegistro.IngresarRegistro(minVenta, IdCaja, miBussinesCaja.Consecutivo(IdCaja));
                                miBussinesCaja.ActualizarConsecutivo(IdCaja);
                                minVenta = minVenta.AddDays(1);
                            }
                            var tabla = miBussinesRegistro.ConsultarRegistro(fecha, IdCaja);
                            id = Convert.ToInt32(tabla.AsEnumerable().Single()["numero"]);
                        }
                    }
                    else  //  si hay registros de consecutivo de informe.
                    {
                        var tabla = miBussinesRegistro.ConsultarRegistro(fecha, IdCaja);
                        if (tabla.Rows.Count != 0)  //  la fecha corresponde a un registro.
                        {
                            id = Convert.ToInt32(tabla.AsEnumerable().Single()["numero"]);
                        }
                        else  //  la fecha no corresponde a ningun registro.
                        {
                            DateTime oldDate = UseDate.FechaSinHora(miBussinesRegistro.MaxFecha(IdCaja));
                            DateTime newDate = UseDate.FechaSinHora(fecha);

                            TimeSpan ts = newDate - oldDate;

                            int difDays = ts.Days;
                            for (int i = 1; i <= difDays; i++)
                            {
                                oldDate = oldDate.AddDays(1);
                                miBussinesRegistro.IngresarRegistro(oldDate, IdCaja, miBussinesCaja.Consecutivo(IdCaja));
                                miBussinesCaja.ActualizarConsecutivo(IdCaja);
                            }
                            tabla = miBussinesRegistro.ConsultarRegistro(fecha, IdCaja);
                            id = Convert.ToInt32(tabla.AsEnumerable().Single()["numero"]);
                        }
                    }
                }
            }

            
            /*if (miBussinesRegistro.Count().Equals(0)) // no hay registros de consecutivo de informe.
            {

            }
            else  //  si hay registros de consecutivo de informe.
            {
                var tabla = miBussinesRegistro.ConsultarRegistro(fecha);
                if (tabla.Rows.Count != 0)  //  la fecha corresponde a un registro.
                {
                    id = Convert.ToInt64(tabla.AsEnumerable().Single()["id"]);
                }
                else  //  la fecha no corresponde a ningun registro.
                {
                    DateTime oldDate = UseDate.FechaSinHora(miBussinesRegistro.MaxFecha());
                    DateTime newDate = UseDate.FechaSinHora(fecha);

                    TimeSpan ts = newDate - oldDate;

                    int difDays = ts.Days;
                    for (int i = 1; i <= difDays; i++)
                    {
                        oldDate = oldDate.AddDays(1);
                        miBussinesRegistro.IngresarRegistro(oldDate, IdCaja, miBussinesCaja.Consecutivo(IdCaja));
                        miBussinesCaja.ActualizarConsecutivo(IdCaja);
                    }
                    tabla = miBussinesRegistro.ConsultarRegistro(fecha);
                    id = Convert.ToInt64(tabla.AsEnumerable().Single()["id"]);
                }
            }*/





           /* var tabla = miBussinesRegistro.ConsultarRegistro(fecha);
            if (tabla.Rows.Count != 0)
            {
                //Fecha ya existe
                var row = tabla.AsEnumerable().Single();
                id = Convert.ToInt32(row["id"]);
            }
            else
            {
                //Fecha no existe
                id = miBussinesRegistro.IngresarRegistro(fecha);
            }*/
            return id;
        }

       /* private int Acumualdo(DateTime fecha)
        {
            
        }*/

        /*private int AcumuladoRetroActivo(DateTime fecha)
        {
            int acumulado = 0;

            if (RetroActivo)
            {
                if (miBussinesAcumulado.CountAcumuladoCaja().Equals(0))
                {
                }
            }
            else
            {
            }





            DateTime oldDate = UseDate.FechaSinHora(miBussinesAcumulado.MaxFechaCaja());
            DateTime newDate = UseDate.FechaSinHora(fecha);

            TimeSpan ts = newDate - oldDate;

            int difDays = ts.Days;
            //int acumulado = 0;
        }*/

        private int AcumuladoCaja(DateTime fecha, int idCaja) // Acumulado por caja.
        {
            int acumulado = 0;
            if (RetroActivo)
            {
                if (miBussinesAcumulado.CountAcumuladoCaja(idCaja).Equals(0))//no hay registros de acumulado
                {
                    if (miBussinesFactura.CountRegistroVentas(idCaja).Equals(0))//no hay registros de ventas
                    {
                        miBussinesAcumulado.IngresarCaja(fecha, idCaja, acumulado);
                    }
                    else // hay registro de ventas
                    {
                        DateTime minVenta = UseDate.FechaSinHora(miBussinesFactura.MinFecha(idCaja));
                        //DateTime minVenta = new DateTime(2014, 1, 2, 12, 0, 0);
                        DateTime newDate = UseDate.FechaSinHora(fecha);
                        TimeSpan ts = newDate - minVenta;
                        int difDays = ts.Days + 1;
                        for (int i = 1; i <= difDays; i++)
                        {
                            if (minVenta.Day.Equals(1))
                            {
                                acumulado = miBussinesFactura.TotalIvaFacturado(idCaja, minVenta, true)
                                            .Tables[0].AsEnumerable().Sum(d => d.Field<int>("SubTotal"));
                            }
                            else
                            {
                                acumulado += miBussinesFactura.TotalIvaFacturado(idCaja, minVenta, true)
                                            .Tables[0].AsEnumerable().Sum(d => d.Field<int>("SubTotal"));
                            }
                            miBussinesAcumulado.IngresarCaja(minVenta, idCaja, acumulado);
                            minVenta = minVenta.AddDays(1);
                        }
                    }
                }
                else  // si hay registros de acumulado.
                {
                    var tAcumulado = miBussinesAcumulado.AcumuladosCaja(fecha, idCaja);
                    if (tAcumulado.Rows.Count != 0)// si hay registro con esa fecha.
                    {
                        acumulado = Convert.ToInt32(tAcumulado.AsEnumerable().First()["valor"]);
                    }
                    else
                    {
                        DateTime minDate = UseDate.FechaSinHora(miBussinesAcumulado.MaxFechaCaja(idCaja));
                        DateTime newDate = UseDate.FechaSinHora(fecha);
                        TimeSpan ts = newDate - minDate;

                        int difDays = ts.Days;
                        for (int i = 1; i <= difDays; i++)
                        {
                            minDate = minDate.AddDays(1);
                            if (minDate.Day.Equals(1))
                            {
                                acumulado = miBussinesFactura.TotalIvaFacturado(idCaja, minDate, true)
                                            .Tables[0].AsEnumerable().Sum(d => d.Field<int>("SubTotal"));
                            }
                            else
                            {
                                acumulado += miBussinesFactura.TotalIvaFacturado(idCaja, minDate, true)
                                            .Tables[0].AsEnumerable().Sum(d => d.Field<int>("SubTotal"));
                            }
                            miBussinesAcumulado.IngresarCaja(minDate, idCaja, acumulado);
                        }
                    }
                }
            }
            else
            {
                var countAcumulado = miBussinesAcumulado.CountAcumuladoCaja(IdCaja);

                var tVenta = DsIvaGravado.Tables[0].AsEnumerable().
                                                 Sum(d => d.Field<int>("SubTotal"));
                var totalVenta = UseObject.AproximacionSobreCinco(tVenta);

                if (countAcumulado > 0)
                {
                    var tAcumulado = miBussinesAcumulado.AcumuladosCaja(Fecha, IdCaja);
                    if (tAcumulado.Rows.Count != 0) // Consulta
                    {
                        acumulado = Convert.ToInt32(tAcumulado.AsEnumerable().First()["valor"]);
                    }
                    else  // Nuevo
                    {
                        var find = false;
                        var miFecha = Fecha.AddDays(-1);
                        if (Fecha.Month != miFecha.Month)
                        {
                            miBussinesAcumulado.IngresarCaja(Fecha, IdCaja, totalVenta);
                            acumulado = totalVenta;
                            //find = true;
                        }
                        else
                        {
                            while (!find)
                            {
                                var tableAcum = miBussinesAcumulado.AcumuladosCaja(miFecha, IdCaja);
                                if (tableAcum.Rows.Count != 0)
                                {
                                    acumulado = Convert.ToInt32(miBussinesAcumulado.AcumuladosCaja(miFecha, IdCaja).
                                                                    AsEnumerable().First()["valor"]);
                                    if (Fecha.Month != miFecha.Month)
                                    {
                                        miBussinesAcumulado.IngresarCaja(Fecha, IdCaja, totalVenta);
                                        acumulado = totalVenta;
                                    }
                                    else
                                    {
                                        miBussinesAcumulado.IngresarCaja(Fecha, IdCaja, totalVenta + acumulado);
                                        acumulado = totalVenta + acumulado;
                                    }
                                    find = true;
                                }
                                else
                                {
                                    find = false;
                                }
                                miFecha = miFecha.AddDays(-1);
                            }
                        }
                    }
                }
                else
                {
                    //primero
                    miBussinesAcumulado.IngresarCaja(Fecha, IdCaja, totalVenta);
                    acumulado = totalVenta;
                }
            }
            return acumulado;
        }

        private int Acumulado(DateTime fecha) // Acumulado general.
        {
            int acumulado = 0;
            if (RetroActivo)
            {
                if (miBussinesAcumulado.CountAcumulado().Equals(0))//no hay registros de acumulado
                {
                    if (miBussinesFactura.CountRegistroVentas().Equals(0))//no hay registros de ventas
                    {
                        miBussinesAcumulado.Ingresar(fecha, acumulado);
                    }
                    else // hay registro de ventas
                    {
                        DateTime minVenta = UseDate.FechaSinHora(miBussinesFactura.MinFecha());
                        DateTime newDate = UseDate.FechaSinHora(fecha);
                        TimeSpan ts = newDate - minVenta;
                        int difDays = ts.Days + 1;
                        for (int i = 1; i <= difDays; i++)
                        {
                            if (minVenta.Day.Equals(1))
                            {
                                acumulado = miBussinesFactura.TotalIvaFacturado(0, minVenta, false)
                                            .Tables[0].AsEnumerable().Sum(d => d.Field<int>("SubTotal"));
                            }
                            else
                            {
                                acumulado += miBussinesFactura.TotalIvaFacturado(0, minVenta, false)
                                            .Tables[0].AsEnumerable().Sum(d => d.Field<int>("SubTotal"));
                            }
                            miBussinesAcumulado.Ingresar(minVenta, acumulado);
                            minVenta = minVenta.AddDays(1);
                        }
                    }
                }
                else  // si hay registros de acumulado.
                {
                    var tAcumulado = miBussinesAcumulado.Acumulados(fecha);
                    if (tAcumulado.Rows.Count != 0)// si hay registro con esa fecha.
                    {
                        acumulado = Convert.ToInt32(tAcumulado.AsEnumerable().First()["valor"]);
                    }
                    else
                    {
                        DateTime minDate = UseDate.FechaSinHora(miBussinesAcumulado.MaxFecha());
                        DateTime newDate = UseDate.FechaSinHora(fecha);
                        TimeSpan ts = newDate - minDate;

                        int difDays = ts.Days;
                        for (int i = 1; i <= difDays; i++)
                        {
                            minDate = minDate.AddDays(1);
                            if (minDate.Day.Equals(1))
                            {
                                acumulado = miBussinesFactura.TotalIvaFacturado(0, minDate, false)
                                            .Tables[0].AsEnumerable().Sum(d => d.Field<int>("SubTotal"));
                            }
                            else
                            {
                                acumulado += miBussinesFactura.TotalIvaFacturado(0, minDate, false)
                                            .Tables[0].AsEnumerable().Sum(d => d.Field<int>("SubTotal"));
                            }
                            miBussinesAcumulado.Ingresar(minDate, acumulado);
                        }
                    }
                }
            }
            else
            {
                var countAcumulado = miBussinesAcumulado.CountAcumulado();

                var tVenta = this.DtIvaGravado.AsEnumerable().
                                                 Sum(d => d.Field<double>("SubTotal"));
                var totalVenta = UseObject.AproximacionSobreCinco(tVenta);

                if (countAcumulado > 0)
                {
                    var tAcumulado = miBussinesAcumulado.Acumulados(Fecha);
                    if (tAcumulado.Rows.Count != 0) // Consulta
                    {
                        acumulado = Convert.ToInt32(tAcumulado.AsEnumerable().First()["valor"]);
                    }
                    else  // Nuevo
                    {
                        var find = false;
                        var miFecha = Fecha.AddDays(-1);
                        if (Fecha.Month != miFecha.Month)
                        {
                            miBussinesAcumulado.Ingresar(Fecha, totalVenta);
                            acumulado = totalVenta;
                            //find = true;
                        }
                        else
                        {
                            while (!find)
                            {
                                var tableAcum = miBussinesAcumulado.Acumulados(miFecha);
                                if (tableAcum.Rows.Count != 0)
                                {
                                    acumulado = Convert.ToInt32(miBussinesAcumulado.Acumulados(miFecha).
                                                                    AsEnumerable().First()["valor"]);
                                    if (Fecha.Month != miFecha.Month)
                                    {
                                        miBussinesAcumulado.Ingresar(Fecha, totalVenta);
                                        acumulado = totalVenta;
                                    }
                                    else
                                    {
                                        miBussinesAcumulado.Ingresar(Fecha, totalVenta + acumulado);
                                        acumulado = totalVenta + acumulado;
                                    }
                                    find = true;
                                }
                                else
                                {
                                    find = false;
                                }
                                miFecha = miFecha.AddDays(-1);
                            }
                        }
                    }
                }
                else
                {
                    //primero
                    miBussinesAcumulado.Ingresar(Fecha, totalVenta);
                    acumulado = totalVenta;
                }
            }
            
            return acumulado;
        }

        // CODIGO NUEVO 30-01-2016

        private int AcumuladoCaja_(int idCaja, DateTime fecha, DateTime fecha2) // Acumulado por caja.
        {
            int acumulado = 0;
            try
            {
                acumulado = this.miBussinesFactura.Acumulado(IdCaja, fecha, fecha2);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            return acumulado;
        }

        private int Acumulado(DateTime fecha, DateTime fecha2) // Acumulado General.
        {
            int acumulado = 0;
            try
            {
                acumulado = this.miBussinesFactura.Acumulado(fecha, fecha2);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            return acumulado;
        }

        // FIN CODIGO NUEVO 30-01-2016


        

        public void PrintComprobantePos()
        {
            try
            {
                DataRow empresaRow = miBussinesEmpresa.PrintEmpresa().
                        Tables[0].AsEnumerable().First();
                var usuarioRow = miBussinesUsuario.PrintUsuario
                    (Convert.ToInt32(AppConfiguracion.ValorSeccion("id_user"))).Tables[0].AsEnumerable().First();
                var tabla = new DataTable();
                if (General)
                {
                    tabla = miBussinesFactura.RegistroVentas(IdCaja, Fecha, false);
                    //DsIvaGravado = miBussinesFactura.TotalIvaFacturado(IdCaja, Fecha, false);
                    DtIvaGravado = miBussinesFactura.TotalIvaFacturado2(Fecha);
                    this.ImpstoBolsas = this.miBussinesImpuestoBolsas.ImpuestoBolsaDeVenta(this.Fecha);
                    DsAbono = miBussinesFactura.TotalAbonosFecha(Fecha);
                    DsIvaDevolucion = miBussinesDevolcion.IvaDevolucion(Fecha);
                    DsDevolucion = miBussinesDevolcion.Devoluciones(Fecha);

                    /*DsIvaGravado = miBussinesFactura.TotalIvaFacturado(IdCaja, Fecha, false);
                    DsAbono = miBussinesFactura.TotalAbonosFecha(Fecha);
                    DsIvaDevolucion = miBussinesDevolcion.IvaDevolucion(Fecha);*/
                }
                else
                {
                    tabla = miBussinesFactura.RegistroVentas(IdCaja, Fecha, true);

                    // Edicion Jueves 11 de Agosto de 2016

                    //DsIvaGravado = miBussinesFactura.TotalIvaFacturado(IdCaja, Fecha, true);
                    DtIvaGravado = miBussinesFactura.TotalIvaFacturado2(IdCaja, Fecha);
                    this.ImpstoBolsas = this.miBussinesImpuestoBolsas.ImpuestoBolsaDeVenta(this.IdCaja, this.Fecha);

                    // ***********************************
                    
                    DsAbono = miBussinesFactura.TotalAbonos(IdCaja, Fecha);
                    DsIvaDevolucion = miBussinesDevolcion.IvaDevolucion(IdCaja, Fecha);
                    DsDevolucion = miBussinesDevolcion.Devoluciones(IdCaja, Fecha);
                }

                var regInicial = " ";
                var regFinal = " ";
                var totalReg = " ";
                //var tabla = miBussinesFactura.RegistroVentas(IdCaja, Fecha, true);
                if (tabla.Rows.Count > 0)
                {
                    regInicial = tabla.Rows[0]["numerofactura_venta"].ToString();
                    regFinal = tabla.Rows[tabla.Rows.Count - 1]["numerofactura_venta"].ToString();
                    totalReg = tabla.Rows.Count.ToString();
                }

                //DsIvaGravado = miBussinesFactura.TotalIvaFacturado(IdCaja, Fecha, true);
                //DsAbono = miBussinesFactura.TotalAbonos(IdCaja, Fecha);
                var DsAnulada = new DataTable();
                if (Soporte)
                {
                    if (!General)
                    {
                        DsAnulada = miBussinesFactura.FacturasAnuladas(IdCaja, Fecha);
                    }
                    else
                    {
                        DsAnulada = miBussinesFactura.FacturasAnuladas(Fecha);
                    }
                }
                //DsIvaDevolucion = miBussinesDevolcion.IvaDevolucion(IdCaja, Fecha);
                //DsDevolucion = miBussinesDevolcion.Devoluciones(IdCaja, Fecha);

                Ticket ticket = new Ticket();
                ticket.UseItem = false;

                ticket.AddHeaderLine(empresaRow["Nombre"].ToString().ToUpper());
                ticket.AddHeaderLine(empresaRow["Juridico"].ToString());
                ticket.AddHeaderLine("NIT " + UseObject.InsertSeparatorMilMasDigito(empresaRow["Nit"].ToString()));
                ticket.AddHeaderLine("Régimen: " + empresaRow["Regimen"].ToString());
                ticket.AddHeaderLine(empresaRow["Direccion"].ToString());
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("COMPROBANTE INFORME DIARIO");
                if (Numeracion)
                {
                    ticket.AddHeaderLine("Nro. " + Consecutivo(Fecha).ToString());
                }
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("Fecha : " + Fecha.ToShortDateString());
                ticket.AddHeaderLine("");
                if (!General)
                {
                    ticket.AddHeaderLine("Caja : " + miBussinesCaja.CajaId(this.IdCaja).Numero.ToString());
                    //ticket.AddHeaderLine("Caja : " + AppConfiguracion.ValorSeccion("no_caja"));
                    ticket.AddHeaderLine("");
                }
                ticket.AddHeaderLine("Registro Inicial  : " + regInicial);
                ticket.AddHeaderLine("Registro Final    : " + regFinal);
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("Total Registros   : " + totalReg);
                ticket.AddHeaderLine("===================================");
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("INFORMACIÓN DE IVA.");
                ticket.AddHeaderLine("");
                foreach (DataRow row in DtIvaGravado.Rows)  // <- Edicion Jueves 11 de Agosto de 2016
                {
                    if (row["Iva"].ToString().Equals("0%"))
                    {
                        //ticket.AddHeaderLine("===================================");
                        ticket.AddHeaderLine("NO GRAVADO          " + row["Iva"].ToString());
                        ticket.AddHeaderLine("        Base : " + UseObject.InsertSeparatorMil(Convert.ToInt32(row["Base"]).ToString()));
                        ticket.AddHeaderLine("         IVA : " + UseObject.InsertSeparatorMil(Convert.ToInt32(row["VIva"]).ToString()));
                        ticket.AddHeaderLine("    SubTotal : " + UseObject.InsertSeparatorMil(Convert.ToInt32(row["SubTotal"]).ToString()));

                        var base_ = Convert.ToInt32(row["Base"]).ToString();
                        var viva_ = Convert.ToInt32(row["VIva"]).ToString();
                        var subtotal_ = Convert.ToInt32(row["SubTotal"]).ToString();
                    }
                    else
                    {
                        ticket.AddHeaderLine("GRAVADO            " + row["Iva"].ToString());
                        ticket.AddHeaderLine("        Base : " + UseObject.InsertSeparatorMil(Convert.ToInt32(row["Base"]).ToString()));
                        ticket.AddHeaderLine("         IVA : " + UseObject.InsertSeparatorMil(Convert.ToInt32(row["VIva"]).ToString()));
                        ticket.AddHeaderLine("    SubTotal : " + UseObject.InsertSeparatorMil(Convert.ToInt32(row["SubTotal"]).ToString()));

                        var iva_ = row["Iva"].ToString();
                        var base_ = Convert.ToInt32(row["Base"]).ToString();
                        var viva_ = Convert.ToInt32(row["VIva"]).ToString();
                        var subtotal_ = Convert.ToInt32(row["SubTotal"]).ToString();
                    }
                }

                //ticket.AddHeaderLine("GRAVADO    BASE      IVA      TOTAL");
                /*foreach (DataRow row in DsIvaGravado.Tables[0].Rows)
                {
                    ticket.AddHeaderLine("  " + row["Iva"].ToString() +
                                         "     " + UseObject.InsertSeparatorMil(Convert.ToInt32(row["Base"]).ToString()) +
                                         "    " + UseObject.InsertSeparatorMil(Convert.ToInt32(row["VIva"]).ToString()) +
                                         "    " + UseObject.InsertSeparatorMil(Convert.ToInt32(row["SubTotal"]).ToString()));
                }*/
                ticket.AddHeaderLine("___________________________________");
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("TOTALES");
                ticket.AddHeaderLine("");

                // Edicion Jueves 11 de Agosto de 2016

                /*ticket.AddHeaderLine("BASE   : " + UseObject.InsertSeparatorMil(
                    DsIvaGravado.Tables[0].AsEnumerable().Sum(d => d.Field<int>("Base")).ToString()));
                ticket.AddHeaderLine("IVA    : " + UseObject.InsertSeparatorMil(
                    DsIvaGravado.Tables[0].AsEnumerable().Sum(d => d.Field<int>("VIva")).ToString()));
                ticket.AddHeaderLine("TOTAL  : " + UseObject.InsertSeparatorMil(
                    DsIvaGravado.Tables[0].AsEnumerable().Sum(d => d.Field<int>("SubTotal")).ToString()));*/

                ticket.AddHeaderLine("BASE   : " + UseObject.InsertSeparatorMil(
                    DtIvaGravado.AsEnumerable().Sum(d => d.Field<double>("Base")).ToString()));
                ticket.AddHeaderLine("IVA    : " + UseObject.InsertSeparatorMil(
                    DtIvaGravado.AsEnumerable().Sum(d => d.Field<double>("VIva")).ToString()));
                ticket.AddHeaderLine("TOTAL  : " + UseObject.InsertSeparatorMil(
                    DtIvaGravado.AsEnumerable().Sum(d => d.Field<double>("SubTotal")).ToString()));

                // **************************************

                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("___________________________________");
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("IMPUESTO A CONSUMO DE BOLSAS PLAST.");
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("CANTIDAD   :  " + this.ImpstoBolsas.Cantidad.ToString());
                ticket.AddHeaderLine("VALOR UNI. :  " + this.ImpstoBolsas.Valor.ToString());
                ticket.AddHeaderLine("TOTAL      :  " + UseObject.InsertSeparatorMil((
                    this.ImpstoBolsas.Cantidad * this.ImpstoBolsas.Valor).ToString()));
                //ticket.AddHeaderLine("");

                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("___________________________________");
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("FACTURAS ANULADAS");
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("No.         CLIENTE");
                if (Soporte)
                {
                    foreach (DataRow aRow in DsAnulada.Rows)
                    {
                        ticket.AddHeaderLine(aRow["numero_factura"].ToString() + "      " + 
                            UseObject.InsertSeparatorMilMasDigito(aRow["nitcliente"].ToString()));
                    }
                }
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("___________________________________");
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("DEVOLUCIONES");
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("GRAVADO    BASE      IVA      TOTAL");
                foreach (DataRow dRow in DsIvaDevolucion.Tables[0].Rows)
                {
                    ticket.AddHeaderLine("  " + dRow["IvaD"].ToString() +
                                         "     " + UseObject.InsertSeparatorMil(Convert.ToInt32(dRow["BaseD"]).ToString()) +
                                         "    " + UseObject.InsertSeparatorMil(Convert.ToInt32(dRow["VIvaD"]).ToString()) +
                                         "    " + UseObject.InsertSeparatorMil(Convert.ToInt32(dRow["SubTotalD"]).ToString()));
                }
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("-----------------------------------");
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("Saldo a favor de facturas por devoluciones");
                ticket.AddHeaderLine("");
                foreach (DataRow sdRow in DsDevolucion.Rows)
                {
                    ticket.AddHeaderLine("FACTURA   : " + sdRow["NoFactura"].ToString());
                    ticket.AddHeaderLine("NIT O C.C : " + sdRow["Nit"].ToString());
                    ticket.AddHeaderLine("CLIENTE   : " + sdRow["Cliente"].ToString());
                    ticket.AddHeaderLine("VALOR     : " + sdRow["Valor"].ToString());
                    ticket.AddHeaderLine("");
                }
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("___________________________________");
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("___________________________________");
                ticket.AddHeaderLine("Firma");
                ticket.AddHeaderLine(usuarioRow["Nombre"].ToString());
                ticket.AddHeaderLine(Fecha.ToShortDateString());


                /*ticket.AddFooterLine("-------Discriminación de IVA-------");
                ticket.AddFooterLine("GRAVADO    BASE      IVA      TOTAL");
                foreach (DataRow iRow in tIva.Rows)
                {
                    ticket.AddFooterLine("  " + iRow["Iva"].ToString() +
                                         "    " + UseObject.InsertSeparatorMil(Convert.ToInt32(row["Base"]).ToString()) +
                                         "    " + UseObject.InsertSeparatorMil(Convert.ToInt32(row["VIva"]).ToString()) +
                                         "    " + UseObject.InsertSeparatorMil(Convert.ToInt32(row["SubTotal"]).ToString()));
                   var q = "  " + iRow["Iva"].ToString() +
                                         "    " + UseObject.InsertSeparatorMil(Convert.ToInt32(iRow["Base"]).ToString()) +
                                         "    " + UseObject.InsertSeparatorMil(Convert.ToInt32(iRow["VIva"]).ToString()) +
                                         "    " + UseObject.InsertSeparatorMil(Convert.ToInt32(iRow["SubTotal"]).ToString());
                }
                ticket.AddFooterLine("-----------------------------------");*/


                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("");

               // ticket.PrintTicket("IMPREPOS");
                ticket.PrintTicket("Microsoft XPS Document Writer");
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        public void PrintComprobantePos_2()
        {
            try
            {
                DataRow empresaRow = this.miBussinesEmpresa.PrintEmpresa().Tables[0].AsEnumerable().First();
                DataRow usuarioRow = this.miBussinesUsuario.PrintUsuario
                    (Convert.ToInt32(AppConfiguracion.ValorSeccion("id_user"))).Tables[0].AsEnumerable().First();
                var tVentas = new DataTable();

                string total_ = "";
                string baseIva_ = "";
                string valorIva_ = "";

                //int ventasCredito = 0;
                int totalVentas = 0;  // auxiliar
                double impoConsumo = 0;  // auxiliar
                int abonos = 0;       // auxiliar
                 
                if (this.General)
                {
                    tVentas = this.miBussinesFactura.RegistroVentas(this.IdCaja, this.Fecha, false);
                    //this.DtIvaGravado = this.miBussinesFactura.TotalIvaFacturado2(this.Fecha);
                //this.DtIvaGravado = this.miBussinesFactura.TotalIvaFacturado(this.Fecha, "EXEN");
                    Impuestos = miBussinesFactura.TotalesImpuesto(Fecha);
                    //impoConsumo = this.miBussinesFactura.TotalImpoConsumo(this.Fecha);

                    this.ImpstoBolsas = this.miBussinesImpuestoBolsas.ImpuestoBolsaDeVenta(this.Fecha);
                    this.DsAbono = this.miBussinesFactura.TotalAbonosFecha(this.Fecha);
                    this.ivaDevoluciones = this.miBussinesDevolcion.IvaDevoluciones(this.Fecha);
                    this.ivaAnuladas = this.miBussinesFactura.VentasAnuladas(this.Fecha);
                    this.DsDevolucion = this.miBussinesDevolcion.Devoluciones(this.Fecha);

                    this.autorFactsDian = this.miBussinesDian.RegistrosDianVentas(this.Fecha);

                    //totalVentas = this.miBussinesFactura.TotalVenta(this.Fecha);  // uso de funcion auxiliar.
                }
                else
                {
                    tVentas = this.miBussinesFactura.RegistroVentas(this.IdCaja, this.Fecha, true);
                    //this.DtIvaGravado = this.miBussinesFactura.TotalIvaFacturado2(this.IdCaja, this.Fecha);

                    /*this.DtIvaGravado = this.miBussinesFactura.TotalIvaFacturado(this.IdCaja, this.Fecha);
                    impoConsumo = this.miBussinesFactura.TotalImpoConsumo(this.IdCaja, this.Fecha);*/

               //this.DtIvaGravado = this.miBussinesFactura.TotalIvaFacturadoConExcento(this.IdCaja, this.Fecha, "EXEN"); 
                    Impuestos = miBussinesFactura.TotalesImpuesto(IdCaja, Fecha);

                    this.ImpstoBolsas = this.miBussinesImpuestoBolsas.ImpuestoBolsaDeVenta(this.IdCaja, this.Fecha);
                    this.DsAbono = this.miBussinesFactura.TotalAbonos(this.IdCaja, this.Fecha);
                    this.ivaDevoluciones = this.miBussinesDevolcion.IvaDevoluciones(this.IdCaja, this.Fecha);
                    this.ivaAnuladas = this.miBussinesFactura.VentasAnuladas(this.IdCaja, this.Fecha);
                    this.DsDevolucion = this.miBussinesDevolcion.Devoluciones(this.IdCaja, this.Fecha);

                    this.autorFactsDian = this.miBussinesDian.RegistrosDianVentas(this.IdCaja, this.Fecha);

                    //totalVentas = this.miBussinesFactura.TotalVenta(this.IdCaja, this.Fecha);  // uso de funcion auxiliar.
                }
                var regInicial = " ";
                var regFinal = " ";
                var totalReg = " ";
                if (tVentas.Rows.Count > 0)
                {
                    regInicial = tVentas.Rows[0]["numerofactura_venta"].ToString();
                    regFinal = tVentas.Rows[tVentas.Rows.Count - 1]["numerofactura_venta"].ToString();
                    totalReg = tVentas.Rows.Count.ToString();
                }
                var QivaDevoluciones = from data in ivaDevoluciones
                                       group data by new
                                       {
                                           NoFactura = data.NoFactura
                                       }
                                           into grupo
                                           select new
                                           {
                                               NoFactura = grupo.Key.NoFactura
                                           };
                var QivaAnuladas = from data_ in ivaAnuladas
                                   group data_ by new
                                   {
                                       NoFactura = data_.NoFactura
                                   }
                                       into grupo_
                                       select new
                                       {
                                           NoFactura = grupo_.Key.NoFactura
                                       };
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
                foreach (var datos in UseObject.StringBuilderDataCenter("RÉGIMEN  " + empresaRow["Regimen"].ToString(), maxCharacters))
                {
                    ticket.AddHeaderLine(datos);
                }
                /*ticket.AddHeaderLine(empresaRow["Nombre"].ToString().ToUpper());
                ticket.AddHeaderLine(empresaRow["Juridico"].ToString());
                ticket.AddHeaderLine("NIT " + UseObject.InsertSeparatorMilMasDigito(empresaRow["Nit"].ToString()));
                ticket.AddHeaderLine("Régimen: " + empresaRow["Regimen"].ToString());
                ticket.AddHeaderLine(empresaRow["Direccion"].ToString());*/
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("COMPROBANTE FISCAL DIARIO");
                if (Numeracion)
                {
                    ticket.AddHeaderLine("Nro. " + this.Consecutivo(this.Fecha).ToString());
                }
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("Fecha : " + this.Fecha.ToShortDateString());
                ticket.AddHeaderLine("");
                if (!General)
                {
                    if (this.IdCaja != 0)
                    {
                        var caja = this.miBussinesCaja.CajaId(this.IdCaja);
                        ticket.AddHeaderLine("Caja : " + caja.Numero.ToString());
                        ticket.AddHeaderLine("");
                        if (!String.IsNullOrEmpty(caja.SeriePrinter))
                        {
                            ticket.AddHeaderLine("Maquina Serie No. " + caja.SeriePrinter);
                            ticket.AddHeaderLine("");
                        }
                    }
                }
               /* if (this.AnexoInfo)
                {
                    if (this.IdCaja == 1)
                    {
                      //ticket.AddHeaderLine("---------[ IVA EN VENTAS ]---------");
                        ticket.AddHeaderLine("Maquina Serie No. TC6Y439571");
                        ticket.AddHeaderLine("");
                    }
                    else
                    {
                        ticket.AddHeaderLine("Maquina Serie No. TC6Y441405");
                        ticket.AddHeaderLine("");
                    }
                }*/
                ticket.AddHeaderLine("Registro Inicial  : " + regInicial);
                ticket.AddHeaderLine("Registro Final    : " + regFinal);
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("Total Registros   : " + totalReg);
                //ticket.AddHeaderLine("===================================");
                ticket.AddHeaderLine("");
                //ticket.AddHeaderLine("");
                ticket.AddHeaderLine("===================================");
                ticket.AddHeaderLine(" GRAVADO           BASE      I.V.A.");
                ticket.AddHeaderLine("===================================");
                foreach (Impuesto impuesto in Impuestos)
                {
                 // ticket.AddHeaderLine("===================================");
                    ticket.AddHeaderLine("   TARIFA                    " + impuesto.Tarifa + "%");
                    ticket.AddHeaderLine("        Base : " + UseObject.StringBuilderDetalleTotalEspacio(
                        UseObject.InsertSeparatorMil(impuesto.BaseGravable.ToString())));
                    ticket.AddHeaderLine("         IVA : " + UseObject.StringBuilderDetalleTotalEspacio(
                        UseObject.InsertSeparatorMil(impuesto.ValorIva.ToString())));
                    ticket.AddHeaderLine("    SubTotal : " + UseObject.StringBuilderDetalleTotalEspacio(
                        UseObject.InsertSeparatorMil((impuesto.BaseGravable + impuesto.ValorIva).ToString())));
                    ticket.AddHeaderLine("");
                    //ticket.AddHeaderLine("");
                }

                ticket.AddHeaderLine("-----------------------------------");
                ticket.AddHeaderLine("   TOTALES");
                ticket.AddHeaderLine("        Base : " + UseObject.StringBuilderDetalleTotalEspacio(
                    UseObject.InsertSeparatorMil(Impuestos.Sum(i => i.BaseGravable).ToString())));
                ticket.AddHeaderLine("         IVA : " + UseObject.StringBuilderDetalleTotalEspacio(
                    UseObject.InsertSeparatorMil(Impuestos.Sum(i => i.ValorIva).ToString())));
                ticket.AddHeaderLine(" Impoconsumo : " + UseObject.StringBuilderDetalleTotalEspacio(
                    UseObject.InsertSeparatorMil(Impuestos.Sum(i => i.Impoconsumo).ToString())));
                ticket.AddHeaderLine("       Total : " + UseObject.StringBuilderDetalleTotalEspacio(
                    UseObject.InsertSeparatorMil(Impuestos.Sum(i => i.Neto).ToString())));
                //ticket.AddHeaderLine("===================================");


                /*foreach (DataRow vRow in this.DtIvaGravado.Rows)
                {
                    total_ = UseObject.InsertSeparatorMil(vRow["SubTotal"].ToString());
                    baseIva_ = UseObject.InsertSeparatorMil(vRow["Base"].ToString());
                    valorIva_ = UseObject.InsertSeparatorMil(vRow["VIva"].ToString());
                    
                    if (total_.Length >= 10)
                    {
                        if (vRow["Iva"].ToString().Length == 7)
                        {
                            ticket.AddHeaderLine(vRow["Iva"].ToString());
                        }
                        else
                        {
                            if (vRow["Iva"].ToString().Length == 1)
                            {
                                ticket.AddHeaderLine("  " + vRow["Iva"].ToString());
                            }
                            else
                            {
                                ticket.AddHeaderLine(" " + vRow["Iva"].ToString());
                            }
                        }
                    }
                    ticket.AddHeaderLine(UseObject.StringBuilderDetalleIvaEx(vRow["Iva"].ToString(), total_, baseIva_, valorIva_));



                    ticket.AddHeaderLine("     TOTALES");

                    ticket.AddHeaderLine("             BASE :" + UseObject.StringBuilderDetalleTotal(UseObject.InsertSeparatorMil(
                    this.DtIvaGravado.AsEnumerable().Sum(d => d.Field<double>("Base")).ToString())));

                    ticket.AddHeaderLine("              IVA :" + UseObject.StringBuilderDetalleTotal(UseObject.InsertSeparatorMil(
                        this.DtIvaGravado.AsEnumerable().Sum(d => d.Field<double>("VIva")).ToString())));

                    ticket.AddHeaderLine("            TOTAL :" + UseObject.StringBuilderDetalleTotal(UseObject.InsertSeparatorMil(
                    this.DtIvaGravado.AsEnumerable().Sum(d => d.Field<double>("SubTotal")).ToString())));

                }*/




                /*ticket.AddHeaderLine("---------[ IVA EN VENTAS ]---------");
                ticket.AddHeaderLine("GRAVADO   VENTA      BASE      IVA ");
                ticket.AddHeaderLine("");
                foreach (DataRow vRow in this.DtIvaGravado.Rows)
                {
                    total_ = UseObject.InsertSeparatorMil(vRow["SubTotal"].ToString());
                    baseIva_ = UseObject.InsertSeparatorMil(vRow["Base"].ToString());
                    valorIva_ = UseObject.InsertSeparatorMil(vRow["VIva"].ToString());
                    if (total_.Length >= 10)
                    {
                        // Nuevo codigo, añade impoconsumo excento. 28/06/2019
                        if (vRow["Iva"].ToString().Length == 7)
                        {
                            ticket.AddHeaderLine(vRow["Iva"].ToString());
                        }
                        else
                        {
                            if (vRow["Iva"].ToString().Length == 1)
                            {
                                ticket.AddHeaderLine("  " + vRow["Iva"].ToString());
                            }
                            else
                            {
                                ticket.AddHeaderLine(" " + vRow["Iva"].ToString());
                            }
                        }
                    }
                    ticket.AddHeaderLine(UseObject.StringBuilderDetalleIvaEx(vRow["Iva"].ToString(), total_, baseIva_, valorIva_));
                }*/

                //impoConsumo = totalVentas - Convert.ToInt32(this.ImpstoBolsas.Cantidad * this.ImpstoBolsas.Valor) - Convert.ToInt32(this.DtIvaGravado.AsEnumerable().Sum(d => d.Field<double>("SubTotal")));

          /* ticket.AddHeaderLine("");
                ticket.AddHeaderLine("-----------------------------------");
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("     TOTALES");
             ticket.AddHeaderLine("");*/

                /*ticket.AddHeaderLine("         SUBTOTAL :" + UseObject.StringBuilderDetalleTotal
                                                                (UseObject.InsertSeparatorMil((total - valorIva).ToString())));*/
               /* ticket.AddHeaderLine("             BASE :" + UseObject.StringBuilderDetalleTotal
                                                                (UseObject.InsertSeparatorMil((10000000).ToString())));
                ticket.AddHeaderLine("              IVA :" + UseObject.StringBuilderDetalleTotal
                                                                (UseObject.InsertSeparatorMil((1900000).ToString())));
                ticket.AddHeaderLine("      IMPOCONSUMO :" + UseObject.StringBuilderDetalleTotal
                                                                (UseObject.InsertSeparatorMil((3256220).ToString())));
                ticket.AddHeaderLine("            TOTAL :" + UseObject.StringBuilderDetalleTotal
                                                                (UseObject.InsertSeparatorMil((15156220).ToString())));*/

               /* ticket.AddHeaderLine("BASE        : " + UseObject.InsertSeparatorMil(
                    this.DtIvaGravado.AsEnumerable().Sum(d => d.Field<double>("Base")).ToString()));

                ticket.AddHeaderLine("IVA         : " + UseObject.InsertSeparatorMil(
                    this.DtIvaGravado.AsEnumerable().Sum(d => d.Field<double>("VIva")).ToString()));

                ticket.AddHeaderLine("IMPOCONSUMO : " + UseObject.InsertSeparatorMil(impoConsumo.ToString()));

                ticket.AddHeaderLine("TOTAL       : " + UseObject.InsertSeparatorMil(totalVentas.ToString()));*/

                /*ticket.AddHeaderLine("TOTAL       : " + UseObject.InsertSeparatorMil(
                    this.DtIvaGravado.AsEnumerable().Sum(d => d.Field<double>("SubTotal")).ToString()));*/

          /*ticket.AddHeaderLine("             BASE :" + UseObject.StringBuilderDetalleTotal(UseObject.InsertSeparatorMil(
                    this.DtIvaGravado.AsEnumerable().Sum(d => d.Field<double>("Base")).ToString())));

            ticket.AddHeaderLine("              IVA :" + UseObject.StringBuilderDetalleTotal(UseObject.InsertSeparatorMil(
                    this.DtIvaGravado.AsEnumerable().Sum(d => d.Field<double>("VIva")).ToString())));*/

                //ticket.AddHeaderLine("      IMPOCONSUMO :" + UseObject.StringBuilderDetalleTotal(UseObject.InsertSeparatorMil(impoConsumo.ToString())));

                //ticket.AddHeaderLine("      IMPOCONSUMO :" + UseObject.StringBuilderDetalleTotal(UseObject.InsertSeparatorMil(impoConsumo.ToString())));

               /* ticket.AddHeaderLine("            TOTAL :" + UseObject.StringBuilderDetalleTotal(UseObject.InsertSeparatorMil(
                   (this.DtIvaGravado.AsEnumerable().Sum(d => d.Field<double>("SubTotal")) + impoConsumo).ToString())));*/

            /*ticket.AddHeaderLine("            TOTAL :" +  UseObject.StringBuilderDetalleTotal(UseObject.InsertSeparatorMil(
                    this.DtIvaGravado.AsEnumerable().Sum(d => d.Field<double>("SubTotal")).ToString())));*/


                ticket.AddHeaderLine("");
                //this.DtIvaGravado.AsEnumerable().Sum(d => d.Field<double>("SubTotal"))

                var incBolsas = (this.ImpstoBolsas.Cantidad * this.ImpstoBolsas.Valor);
               // var totalVentasIva_ = this.DtIvaGravado.AsEnumerable().Sum(d => d.Field<double>("SubTotal"));

                
                /*if (impoConsumo > 0)
                {
                    ticket.AddHeaderLine("----------[ IMPOCONSUMO ]----------");
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("ICO    : " + UseObject.InsertSeparatorMil(impoConsumo.ToString()));
                    ticket.AddHeaderLine("");
                }*/

                if (this.ImpstoBolsas.Cantidad > 0)
                {
                    ticket.AddHeaderLine("-----[ INC. BOLSAS PLÁSTICAS ]-----");
                    ticket.AddHeaderLine("CANTIDAD   :  " + this.ImpstoBolsas.Cantidad.ToString());
                    ticket.AddHeaderLine("VALOR UNI. :  " + this.ImpstoBolsas.Valor.ToString());
                    ticket.AddHeaderLine("TOTAL      :  " + UseObject.InsertSeparatorMil((
                        this.ImpstoBolsas.Cantidad * this.ImpstoBolsas.Valor).ToString()));
                    ticket.AddHeaderLine("");
                }

                if (QivaAnuladas.Count() > 0)
                {
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("------[ IVA VENTAS ANULADAS ]------");
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("GRAVADO   VENTA      BASE      IVA ");
                    foreach (var noFacturaAnulada in QivaAnuladas)
                    {
                        if (noFacturaAnulada.NoFactura.Equals(""))
                        {
                            ticket.AddHeaderLine("Frv. General");
                        }
                        else
                        {
                            ticket.AddHeaderLine("Frv. No.  " + noFacturaAnulada.NoFactura);
                        }
                        foreach (var ivaAnuladas_ in ivaAnuladas.Where(i => i.NoFactura.Equals(noFacturaAnulada.NoFactura)))
                        {
                            total_ = UseObject.InsertSeparatorMil(ivaAnuladas_.Total.ToString());
                            baseIva_ = UseObject.InsertSeparatorMil(ivaAnuladas_.BaseI.ToString());
                            valorIva_ = UseObject.InsertSeparatorMil(ivaAnuladas_.ValorIva.ToString());
                            ticket.AddHeaderLine(UseObject.StringBuilderDetalleIva(ivaAnuladas_.PorcentajeIva, total_, baseIva_, valorIva_));
                        }
                        ticket.AddHeaderLine("");
                    }
                    ticket.AddHeaderLine("");
                }

                if (QivaDevoluciones.Count() > 0)
                {
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("------[ IVA EN DEVOLUCIONES ]------");
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("GRAVADO   VENTA      BASE      IVA ");
                    foreach (var noFacturaDevolucion in QivaDevoluciones)
                    {
                        if (noFacturaDevolucion.NoFactura.Equals(""))
                        {
                            ticket.AddHeaderLine("Frv. General");
                        }
                        else
                        {
                            ticket.AddHeaderLine("Frv. No.  " + noFacturaDevolucion.NoFactura);
                        }
                        foreach (var ivaDevoluciones_ in ivaDevoluciones.Where(i => i.NoFactura.Equals(noFacturaDevolucion.NoFactura)))
                        {
                            total_ = UseObject.InsertSeparatorMil(ivaDevoluciones_.Total.ToString());
                            baseIva_ = UseObject.InsertSeparatorMil(ivaDevoluciones_.BaseI.ToString());
                            valorIva_ = UseObject.InsertSeparatorMil(ivaDevoluciones_.ValorIva.ToString());
                            ticket.AddHeaderLine(UseObject.StringBuilderDetalleIva(ivaDevoluciones_.PorcentajeIva, total_, baseIva_, valorIva_));
                        }
                        ticket.AddHeaderLine("");
                    }
                    ticket.AddHeaderLine("");
                }

                if (DsDevolucion.Rows.Count > 0)
                {
                    ticket.AddHeaderLine("-----[ SALDO DE DEVOLUCIONES ]-----");
                    ticket.AddHeaderLine("");
                    foreach (DataRow sdRow in DsDevolucion.Rows)
                    {
                        ticket.AddHeaderLine("FACTURA   : " + sdRow["NoFactura"].ToString());
                        ticket.AddHeaderLine("NIT O C.C : " + sdRow["Nit"].ToString());
                        ticket.AddHeaderLine("CLIENTE   : " + sdRow["Cliente"].ToString());
                        ticket.AddHeaderLine("VALOR     : " + sdRow["Valor"].ToString());
                        ticket.AddHeaderLine("");
                    }
                }

                abonos = Convert.ToInt32(this.DsAbono.Tables[0].AsEnumerable().Sum(s => s.Field<long>("valor")));
                if (abonos > 0)
                {
                    //ticket.AddHeaderLine("-----[ SALDO DE DEVOLUCIONES ]-----");
                    ticket.AddHeaderLine("-------------[ ABONOS ]------------");
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("TOTAL ABONOS: " + UseObject.InsertSeparatorMil(abonos.ToString()));
                    ticket.AddHeaderLine("");
                }

                // Codigo nuevo para exigencia en Las Vegas Armenia.
                /*foreach (var stringDian in UseObject.StringBuilderDetalleDIAN(
                    "Autorización Numeración De Facturación por Computador No. 18762014267651", 35))
                {
                    ticket.AddHeaderLine(stringDian);
                }*/
                ticket.AddHeaderLine("-----------------------------------");
                ticket.AddHeaderLine("");
                /*foreach (DTO.Clases.Dian dian in this.autorFactsDian)
                {
                    ticket.AddHeaderLine("Autorización Numeración de ");
                    if (dian.IdModalidad == 1)  // modalidad 1 : POS
                    {
                        ticket.AddHeaderLine("Facturación POS ");
                    }
                    else                        // modalidad 2 : COMPUTADOR
                    {
                        ticket.AddHeaderLine("Facturación por Computador  ");
                    }
                    ticket.AddHeaderLine("No. " + dian.NumeroResolucion + " ");
                    ticket.AddHeaderLine("Fecha " + dian.FechaExpedicion.ToShortDateString());
                    ticket.AddHeaderLine("Autoriza del " + dian.SerieInicial + dian.RangoInicial + " hasta " + dian.SerieFinal + dian.RangoFinal);
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("Vigencia hasta: " + dian.Vigencia.ToShortDateString());
                    //ticket.AddHeaderLine("");
                }*/






                /*if (this.AnexoInfo)
                {
                    if (this.Fecha.Month == 6)
                    {
                        if (this.Dia_ < 50)
                        {
                            ticket.AddHeaderLine("-----------------------------------");
                            ticket.AddHeaderLine("");
                            ticket.AddHeaderLine("Autorización Numeración de ");
                            ticket.AddHeaderLine("Facturación por Computador ");
                            ticket.AddHeaderLine("No. 18762014454389 ");
                            ticket.AddHeaderLine("Fecha 10/05/2019");
                            ticket.AddHeaderLine("Autoriza del 1001 hasta 765345");
                        }
                        else
                        {
                            ticket.AddHeaderLine("-----------------------------------");
                            ticket.AddHeaderLine("");
                            ticket.AddHeaderLine("Autorización Numeración de ");
                            ticket.AddHeaderLine("Facturación POS ");
                            ticket.AddHeaderLine("No. 18762015161032 ");
                            ticket.AddHeaderLine("Fecha 15/06/2019");
                            ticket.AddHeaderLine("Autoriza del A1 hasta A70000");
                        }
                    }
                    else
                    {
                        if (this.IdCaja == 1 && this.Dia_ < 10)
                        {
                            ticket.AddHeaderLine("-----------------------------------");
                            ticket.AddHeaderLine("");
                            ticket.AddHeaderLine("Autorización Numeración de ");
                            ticket.AddHeaderLine("Facturación por Computador ");
                            ticket.AddHeaderLine("No. 18762014267651 ");
                            ticket.AddHeaderLine("Fecha 30/04/2019");
                            ticket.AddHeaderLine("Autoriza del 1 hasta 1000");
                        }
                        else
                        {
                            if (this.IdCaja == 1 && this.Dia_ >= 10)
                            {
                                ticket.AddHeaderLine("-----------------------------------");
                                ticket.AddHeaderLine("");
                                ticket.AddHeaderLine("Autorización Numeración de ");
                                ticket.AddHeaderLine("Facturación por Computador ");
                                ticket.AddHeaderLine("No. 18762014454389 ");
                                ticket.AddHeaderLine("Fecha 10/05/2019");
                                ticket.AddHeaderLine("Autoriza del 1001 hasta 765345");
                            }
                            else
                            {
                                if (this.IdCaja == 2 && this.Dia_ == 10)
                                {
                                    ticket.AddHeaderLine("-----------------------------------");
                                    ticket.AddHeaderLine("");
                                    ticket.AddHeaderLine("Autorización Numeración de ");
                                    ticket.AddHeaderLine("Facturación por Computador ");
                                    ticket.AddHeaderLine("No. 18762014267651 ");
                                    ticket.AddHeaderLine("Fecha 30/04/2019");
                                    ticket.AddHeaderLine("Autoriza del 1 hasta 1000");
                                    ticket.AddHeaderLine("");
                                    ticket.AddHeaderLine("Autorización Numeración de ");
                                    ticket.AddHeaderLine("Facturación por Computador ");
                                    ticket.AddHeaderLine("No. 18762014454389 ");
                                    ticket.AddHeaderLine("Fecha 10/05/2019");
                                    ticket.AddHeaderLine("Autoriza del 1001 hasta 765345");
                                }
                                else
                                {
                                    if (this.IdCaja == 2 && this.Dia_ < 10)
                                    {
                                        ticket.AddHeaderLine("-----------------------------------");
                                        ticket.AddHeaderLine("");
                                        ticket.AddHeaderLine("Autorización Numeración de ");
                                        ticket.AddHeaderLine("Facturación por Computador ");
                                        ticket.AddHeaderLine("No. 18762014267651 ");
                                        ticket.AddHeaderLine("Fecha 30/04/2019");
                                        ticket.AddHeaderLine("Autoriza del 1 hasta 1000");
                                    }
                                    else
                                    {
                                        if (this.IdCaja == 2 && this.Dia_ > 10)
                                        {
                                            ticket.AddHeaderLine("-----------------------------------");
                                            ticket.AddHeaderLine("");
                                            ticket.AddHeaderLine("Autorización Numeración de ");
                                            ticket.AddHeaderLine("Facturación por Computador ");
                                            ticket.AddHeaderLine("No. 18762014454389 ");
                                            ticket.AddHeaderLine("Fecha 10/05/2019");
                                            ticket.AddHeaderLine("Autoriza del 1001 hasta 765345");
                                        }
                                    }
                                }
                            }
                        }
                    }

                }*/

                //ticket.AddHeaderLine("");
                ticket.AddHeaderLine("");
                //ticket.AddHeaderLine("===================================");
                ticket.AddHeaderLine("-----------------------------------");
                foreach (var datos in UseObject.StringBuilderDataCenter("SOFTWARE DFPYME", maxCharacters))
                {
                    ticket.AddHeaderLine(datos);
                }
                foreach (var datos in UseObject.StringBuilderDataCenter("INTREDETE", maxCharacters))
                {
                    ticket.AddHeaderLine(datos);
                }
                foreach (var datos in UseObject.StringBuilderDataCenter("comercial@intredete.com", maxCharacters))
                {
                    ticket.AddHeaderLine(datos);
                }

                /*ticket.AddHeaderLine("SOFTWARE DFPYME");
                ticket.AddHeaderLine("SOLUCIONES TECNOLOGICAS AYC");
                ticket.AddHeaderLine("NIT. 98713702-9");*/

                /*ticket.AddHeaderLine("");
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("___________________________________");
                ticket.AddHeaderLine("Firma");
                ticket.AddHeaderLine(usuarioRow["Nombre"].ToString());
                ticket.AddHeaderLine(Fecha.ToShortDateString());
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("");*/
                //ticket.PrintTicket("IMPREPOS");
                ticket.PrintTicket("");
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        public void Print58mm()
        {
            try
            {
                DataRow empresaRow = this.miBussinesEmpresa.PrintEmpresa().Tables[0].AsEnumerable().First();

                var tVentas = new DataTable();

                if (!PeriodoFecha)
                {
                    tVentas = this.miBussinesFactura.RegistroVentas(this.IdCaja, this.Fecha, true);
                    DtIvaGravado = this.miBussinesFactura.TotalIvaFacturadoConExcento(this.IdCaja, this.Fecha, "EXEN");

                    AcumuladoToday = AcumuladoCaja_(IdCaja, new DateTime(Fecha.Year, Fecha.Month, 1), Fecha);

                    DsFacturaCredito = miBussinesFactura.TotalFacturasCredito(2, IdCaja, Fecha, true);
                    DsAbono = this.miBussinesFactura.TotalAbonos(this.IdCaja, this.Fecha);

                    ivaDevoluciones = this.miBussinesDevolcion.IvaDevoluciones(this.IdCaja, this.Fecha);
                    ivaAnuladas = this.miBussinesFactura.VentasAnuladas(this.IdCaja, this.Fecha);
                }
                else
                {
                    tVentas = this.miBussinesFactura.RegistroVentas(this.Fecha, this.Fecha2);
                    DtIvaGravado = this.miBussinesFactura.TotalIvaFacturado(this.Fecha, this.Fecha2);

                    ivaDevoluciones = this.miBussinesDevolcion.IvaDevoluciones(this.Fecha, this.Fecha2);
                    ivaAnuladas = this.miBussinesFactura.VentasAnuladas(this.Fecha, this.Fecha2);
                }

                var regInicial = " ";
                var regFinal = " ";
                var totalReg = " ";
                if (tVentas.Rows.Count > 0)
                {
                    regInicial = tVentas.Rows[0]["numerofactura_venta"].ToString();
                    regFinal = tVentas.Rows[tVentas.Rows.Count - 1]["numerofactura_venta"].ToString();
                    totalReg = tVentas.Rows.Count.ToString();
                }

                Ticket miTicket = new Ticket();
                miTicket.UseItem = false;
                miTicket.Printer80mm = false;

                miTicket.AddHeaderLine(empresaRow["Nombre"].ToString().ToUpper());
                miTicket.AddHeaderLine(empresaRow["Juridico"].ToString().ToUpper());
                miTicket.AddHeaderLine(empresaRow["Nit"].ToString().ToUpper());
                miTicket.AddHeaderLine(empresaRow["direccion_"].ToString().ToUpper());
                miTicket.AddHeaderLine(empresaRow["ciudad"].ToString().ToUpper() + " " +
                    empresaRow["departamento"].ToString().ToUpper());
                miTicket.AddHeaderLine(empresaRow["celularempresa"].ToString().ToUpper());

                miTicket.AddHeaderLine("---------------------------");
                miTicket.AddHeaderLine("INFORME DE VENTAS");
                miTicket.AddHeaderLine("");
                if (!PeriodoFecha)
                {
                    miTicket.AddHeaderLine("FECHA: " + Fecha.ToShortDateString());
                }
                else
                {
                    miTicket.AddHeaderLine("PERIODO: ");
                    miTicket.AddHeaderLine(UseObject.AjusteDeCaracteresDerecha_(
                        Fecha.ToShortDateString() + " a " + Fecha2.ToShortDateString()));
                }
                miTicket.AddHeaderLine("");
                miTicket.AddHeaderLine("REG IN: " + regInicial);
                miTicket.AddHeaderLine("REG FIN " + regFinal);
                miTicket.AddHeaderLine("N. REG: " + totalReg);
                miTicket.AddHeaderLine("");

                miTicket.AddHeaderLine("TOTAL VENTAS");
                miTicket.AddHeaderLine(UseObject.AjusteDeCaracteresDerecha_(UseObject.InsertSeparatorMil(
                    DtIvaGravado.AsEnumerable().Sum(s => s.Field<double>("SubTotal")).ToString())));

                if (!PeriodoFecha)
                {
                    miTicket.AddHeaderLine("---------------------------");
                    miTicket.AddHeaderLine("ACUMULADO");
                    miTicket.AddHeaderLine(UseObject.AjusteDeCaracteresDerecha_(UseObject.InsertSeparatorMil(AcumuladoToday.ToString())));

                    miTicket.AddHeaderLine("---------------------------");
                    miTicket.AddHeaderLine("VENTAS CRÉDITO");
                    miTicket.AddHeaderLine("");
                    foreach (DataRow credRow in DsFacturaCredito.Tables[0].Rows)
                    {//NoFacturaC
                        miTicket.AddHeaderLine(credRow["ClienteC"].ToString());
                        foreach (var datosCred in UseObject.StringBuilderDetalleValor(credRow["NoFacturaC"].ToString(),
                            UseObject.InsertSeparatorMil(Convert.ToInt32(credRow["TotalC"]).ToString()), 27))
                        {
                            miTicket.AddHeaderLine(datosCred);
                        }
                        /*miTicket.AddHeaderLine(UseObject.AjusteDeCaracteresDerecha_(UseObject.InsertSeparatorMil(
                            Convert.ToInt32(credRow["TotalC"]).ToString())));*/

                        miTicket.AddHeaderLine("");
                    }
                    miTicket.AddHeaderLine("---------------------------");
                    miTicket.AddHeaderLine("ABONOS");
                    miTicket.AddHeaderLine("");
                    foreach (DataRow abonoRow in DsAbono.Tables[0].Rows)
                    {//numero
                        miTicket.AddHeaderLine(abonoRow["nombre"].ToString());
                        foreach (var datosCred in UseObject.StringBuilderDetalleValor(abonoRow["numero"].ToString(),
                            UseObject.InsertSeparatorMil(Convert.ToInt32(abonoRow["valor"]).ToString()), 27))
                        {
                            miTicket.AddHeaderLine(datosCred);
                        }
                        /*miTicket.AddHeaderLine(UseObject.AjusteDeCaracteresDerecha_(UseObject.InsertSeparatorMil(
                            Convert.ToInt32(abonoRow["valor"]).ToString())));*/
                        miTicket.AddHeaderLine("");
                    }
                }

                miTicket.AddHeaderLine("---------------------------");
                miTicket.AddHeaderLine("DEVOLUCIONES");
                miTicket.AddHeaderLine(UseObject.AjusteDeCaracteresDerecha_(UseObject.InsertSeparatorMil(
                    ivaDevoluciones.Sum(i => i.Total).ToString())));
                miTicket.AddHeaderLine("---------------------------");
                miTicket.AddHeaderLine("ANULADAS");
                if (ivaAnuladas.Count > 0)
                {
                    foreach (var anuladas in ivaAnuladas)
                    {
                        foreach (var datosCred in UseObject.StringBuilderDetalleValor("No. " + anuladas.NoFactura,
                            UseObject.InsertSeparatorMil(anuladas.Total.ToString()), 27))
                        {
                            miTicket.AddHeaderLine(datosCred);
                        }
                        /*miTicket.AddHeaderLine("No. " + anuladas.NoFactura);
                        miTicket.AddHeaderLine(UseObject.AjusteDeCaracteresDerecha_(UseObject.InsertSeparatorMil(
                            anuladas.Total.ToString())));*/
                    }
                }
                else
                {
                    miTicket.AddHeaderLine("                          0");
                }
                miTicket.AddHeaderLine("---------------------------");
                miTicket.PrintTicket("");
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        public LocalReport LoadReport()
        {
            this.CargarDatosGenerales();
            if (this.PeriodoFecha)
            {
                this.CargarDatosPeriodo();
            }
            else
            {
                this.CargarDatos();
            }
            this.CargarDatosFinales();
            return this.rptVCajaDiario.LocalReport;
        }

        public void ResetReport()
        {
            this.rptVCajaDiario.Reset();
        }
    }
}