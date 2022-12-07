using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using BussinesLayer.Clases;
using CustomControl;
using DTO.Clases;
using Utilities;

namespace Aplicacion.Ventas
{
    public partial class Form3 : Form
    {
        private BussinesFacturaVenta miBussinesFactura;

        private BussinesDevolucion miBussDevol;


        private BussinesFacturaProveedor miBussCompra;

        private BussinesUsuario miBussUser;


        private BussinesCliente miBussCliente;

        private BussinesRemision miBussRemision;

        private BussinesConsultaSQL miBussinessConsulta;

        private BussinesConsultaFacturaProducto miBussinesConsultaImpuesto;


        private DateTime FechaActual;

        private DateTime FechaActual2;

        private int maxValor;

        private Thread miThread;

        private OptionPane miOption;

        DataTable table_1 = new DataTable();

        DataTable table_2 = new DataTable();

        DataTable table_3 = new DataTable();

        DataTable tClientes = new DataTable();

        List<FacturaVenta> lstFacturas = new List<FacturaVenta>();

        public Form3()
        {
            InitializeComponent();
            this.maxValor = 0;
            this.miBussinesFactura = new BussinesFacturaVenta();
            this.miBussDevol = new BussinesDevolucion();
            this.miBussCompra = new BussinesFacturaProveedor();
            this.miBussUser = new BussinesUsuario();
            this.miBussCliente = new BussinesCliente();
            this.miBussRemision = new BussinesRemision();

            miBussinessConsulta = new BussinesConsultaSQL();

            miBussinesConsultaImpuesto = new BussinesConsultaFacturaProducto();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            //this.dgvIvaDevoluciones.AutoGenerateColumns = false;
            //this.dgvIvaAnuladas.AutoGenerateColumns = false;
        }


        private void btnCargar_Click(object sender, EventArgs e)
        {
            try
            {
                /*
                int maxCharacters = 18;
                List<string> lstStringBuilderDataCenter = new List<string>();
                List<string> stringSplitData = new List<string>();
                string data = "PAGO FACTURA PROVEEDOR NÚMERO 83362";
                string dataTemp = "";
                var datos = UseObject.StringBuilderDataIzquierda(data, maxCharacters);
                Console.WriteLine("===================================");
                for (int i = 0; i < datos.Count; i++)
                {
                    if (i == datos.Count - 1)
                    {
                        string d = datos[i] + UseObject.FuncionEspacio(maxCharacters - datos[i].Length) + "  " +
                            UseObject.FuncionEspacio("156.452".Length - 15) + "156.452";
                        Console.WriteLine(datos[i] + UseObject.FuncionEspacio(maxCharacters - datos[i].Length) + "  " +
                            UseObject.FuncionEspacio(15 - "156.452".Length) + "156.452");
                    }
                    else
                    {
                        Console.WriteLine(datos[i]);
                    }
                }
                */


                /*foreach (var str in UseObject.StringBuilderDataIzquierda(data, maxCharacters))
                {
                    Console.WriteLine(str);
                }*/
                /*
                for (int i = 0; i <= data.Length; i++)
                {
                    if (!(i == data.Length))
                    {
                        if (!data[i].Equals(' '))
                        {
                            dataTemp += data[i];
                            //Console.WriteLine("OK");
                        }
                        else
                        {
                            stringSplitData.Add(dataTemp);
                            dataTemp = "";
                        }
                    }
                    else
                    {
                        stringSplitData.Add(dataTemp);
                        dataTemp = "";
                    }
                }
                var stringBuilderDataCenter = "";
                string strTemp = "";
                int count = 0;
                foreach (var str in stringSplitData)
                {
                    count++;
                    if (count == 1)
                    {
                        strTemp += str;
                    }
                    else
                    {
                        strTemp += " " + str;
                    }
                    if (!(strTemp.Length > maxCharacters))
                    {
                        stringBuilderDataCenter = strTemp;
                        //strTemp += " ";
                    }
                    else
                    {
                        lstStringBuilderDataCenter.Add(stringBuilderDataCenter);
                        //stringBuilderDataCenter = "";
                        stringBuilderDataCenter = strTemp = str;// +" ";
                    }
                    if (stringSplitData.Count == count)
                    {
                        lstStringBuilderDataCenter.Add(stringBuilderDataCenter);
                    }
                }
                int valor = Convert.ToInt32(this.txtIdCaja.Text);
                if (valor % 2 == 0)  // Par
                {
                   // Console.WriteLine("Par");
                }
                else   //  Impar
                {
                  //  Console.WriteLine("Impar");
                }
                int diferencia_ = valor / 2;
                //Console.WriteLine(diferencia_);
                //Console.WriteLine(valor - diferencia_);

                List<string> lstStringBuilderDataCenter_ = new List<string>();
                foreach (var stringBuilderDataCenter_ in lstStringBuilderDataCenter)
                {
                    int length_ = maxCharacters - stringBuilderDataCenter_.Length;
                    int diferencia = length_ / 2;
                    if (length_ % 2 == 0)  //  Par
                    {
                        lstStringBuilderDataCenter_.Add(
                            UseObject.FuncionEspacio(diferencia) +
                            stringBuilderDataCenter_ + UseObject.FuncionEspacio(diferencia));
                    }
                    else  //                   Impar
                    {
                        lstStringBuilderDataCenter_.Add(
                            UseObject.FuncionEspacio(length_ - diferencia) +
                            stringBuilderDataCenter_ + UseObject.FuncionEspacio(diferencia));
                    }
                }
                Console.WriteLine("");
                Console.WriteLine("-----------------------------------");
                foreach (var string_ in lstStringBuilderDataCenter_)
                {
                    Console.WriteLine(string_);
                }
                */

                //this.dgvClientes.DataSource = this.miBussCompra.TableCompras(361);

                //this.dgvClientes.DataSource = this.miBussCompra.AjustarComprasAndPagos(Convert.ToInt32(this.txtIdCaja.Text));

                

                //this.dgvClientes.DataSource = this.miBussDevol.TIvaDevoluciones(Convert.ToInt32(this.txtIdCaja.Text), this.dtpFecha.Value);

                //var ivaDevol = this.miBussDevol.IvaDevoluciones(Convert.ToInt32(this.txtIdCaja.Text), this.dtpFecha.Value);

               /* this.dgvClientes.DataSource = this.miBussinesFactura.TVentasAnuladas( this.dtpFecha.Value);

                var ivaDevol = this.miBussinesFactura.VentasAnuladas( this.dtpFecha.Value);

                var query = from data in ivaDevol
                            group data by new
                            {
                                NoFrv = data.NoFactura
                            }
                                into grupo
                                select new
                                {
                                    NoFrv = grupo.Key.NoFrv
                                };
                foreach (var frv in query)
                {
                    if (frv.NoFrv.Equals(""))
                    {
                        Console.WriteLine("Frv. General");
                    }
                    else
                    {
                        Console.WriteLine("Frv. No.  " + frv.NoFrv);
                    }
                    var ivaDevols = ivaDevol.Where(i => i.NoFactura.Equals(frv.NoFrv));
                    foreach (var ivaDevol_ in ivaDevols)
                    {
                        Console.WriteLine
                         ("     " + ivaDevol_.PorcentajeIva + "%     " + ivaDevol_.Total + "    " + ivaDevol_.BaseI + "    " + ivaDevol_.ValorIva);
                    }
                }*/

               /* DataTable dsIvaDevolucion = this.miBussDevol.TIvaDevoluciones(Convert.ToInt32(this.txtIdCaja.Text), this.dtpFecha.Value);

                //this.dgvClientes.DataSource = dsIvaDevolucion;
                var frm4 = new Form4();

                frm4.reportViewer1.LocalReport.DataSources.Clear();
                frm4.reportViewer1.LocalReport.Dispose();
                frm4.reportViewer1.Reset();
                frm4.reportViewer1.LocalReport.DataSources.Add(
                    new Microsoft.Reporting.WinForms.ReportDataSource("DsIvaDevolucion", dsIvaDevolucion));
                frm4.reportViewer1.LocalReport.ReportPath = 
                    @"C:\Users\alejo_cq\Documents\Visual Studio 2010\Projects\DFPYME\Aplicacion\Informes\IvaDevolucion.rdlc";

                frm4.reportViewer1.RefreshReport();
                frm4.ShowDialog();*/

                /*
                DataTable tIvaVentas = this.miBussinesFactura.TotalIvaFacturado2(Convert.ToInt32(this.txtIdCaja.Text), this.dtpFecha.Value);
                List<IvaDevolucion> ivaDevoluciones = this.miBussDevol.IvaDevoluciones(Convert.ToInt32(this.txtIdCaja.Text), this.dtpFecha.Value);
                List<IvaAnulado> ivaAnuladas = this.miBussinesFactura.VentasAnuladas(Convert.ToInt32(this.txtIdCaja.Text), this.dtpFecha.Value);
               
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
                string total_ = "";
                string baseIva_ = "";
                string valorIva_ = "";
                
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("");
                Console.WriteLine("IVA en ventas");
                foreach (DataRow row in tIvaVentas.Rows)
                {
                    total_ = UseObject.InsertSeparatorMil(row["SubTotal"].ToString());
                    baseIva_ = UseObject.InsertSeparatorMil(row["Base"].ToString());
                    valorIva_ = UseObject.InsertSeparatorMil(row["VIva"].ToString());
                    if (total_.Length >= 10)
                    {
                        if (row["Iva"].ToString().Length == 1)
                        {
                            Console.WriteLine("  " + row["Iva"].ToString() + "%");
                        }
                        else
                        {
                            Console.WriteLine(" " + row["Iva"].ToString() + "%");
                        }
                    }
                    Console.WriteLine(UseObject.StringBuilderDetalleIva(Convert.ToDouble(row["Iva"]), total_, baseIva_, valorIva_));
                }
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("IVA en Devoluciones");
                Console.WriteLine("");
                Console.WriteLine("GRAVADO   VENTA      BASE      IVA ");
                Console.WriteLine("");
                foreach (var noFacturaDevolucion in QivaDevoluciones)
                {
                    if (noFacturaDevolucion.NoFactura.Equals(""))
                    {
                        Console.WriteLine("Frv. General");
                    }
                    else
                    {
                        Console.WriteLine("Frv. No.  " + noFacturaDevolucion.NoFactura);
                    }
                    foreach (var ivaDevoluciones_ in ivaDevoluciones.Where(i => i.NoFactura.Equals(noFacturaDevolucion.NoFactura)))
                    {
                        total_ = UseObject.InsertSeparatorMil(ivaDevoluciones_.Total.ToString());
                        baseIva_ = UseObject.InsertSeparatorMil(ivaDevoluciones_.BaseI.ToString());
                        valorIva_ = UseObject.InsertSeparatorMil(ivaDevoluciones_.ValorIva.ToString());
                        Console.WriteLine(UseObject.StringBuilderDetalleIva(ivaDevoluciones_.PorcentajeIva, total_, baseIva_, valorIva_));
                    }
                    Console.WriteLine("");
                }
                Console.WriteLine("");
                Console.WriteLine("IVA de ventas anuladas.");
                Console.WriteLine("");
                foreach (var noFacturaAnulada in QivaAnuladas)
                {
                    if (noFacturaAnulada.NoFactura.Equals(""))
                    {
                        Console.WriteLine("Frv. General");
                    }
                    else
                    {
                        Console.WriteLine("Frv. No.  " + noFacturaAnulada.NoFactura);
                    }
                    foreach (var ivaAnuladas_ in ivaAnuladas.Where(i => i.NoFactura.Equals(noFacturaAnulada.NoFactura)))
                    {
                        total_ = UseObject.InsertSeparatorMil(ivaAnuladas_.Total.ToString());
                        baseIva_ = UseObject.InsertSeparatorMil(ivaAnuladas_.BaseI.ToString());
                        valorIva_ = UseObject.InsertSeparatorMil(ivaAnuladas_.ValorIva.ToString());
                        Console.WriteLine(UseObject.StringBuilderDetalleIva(ivaAnuladas_.PorcentajeIva, total_, baseIva_, valorIva_));
                    }
                    Console.WriteLine("");
                }
                Console.WriteLine("");
                Console.WriteLine("-----------------------------------");

                */

                /*foreach (var noFacturaDevolucion in QivaDevoluciones)
                {
                    if (noFacturaDevolucion.NoFactura.Equals(""))
                    {
                        Console.WriteLine("Frv. General");
                    }
                    else
                    {
                        Console.WriteLine("Frv. No.  " + noFacturaDevolucion.NoFactura);
                    }
                    foreach (var ivaDevoluciones_ in ivaDevoluciones.Where(i => i.NoFactura.Equals(noFacturaDevolucion.NoFactura)))
                    {
                        total_ = UseObject.InsertSeparatorMil(ivaDevoluciones_.Total.ToString());
                        baseIva_ = UseObject.InsertSeparatorMil(ivaDevoluciones_.BaseI.ToString());
                        valorIva_ = UseObject.InsertSeparatorMil(ivaDevoluciones_.ValorIva.ToString());

                        if (ivaDevoluciones_.PorcentajeIva == 0)                  // IVA 0%
                        {
                            if (total_.Length < 10)
                            {
                                Console.WriteLine("  " + ivaDevoluciones_.PorcentajeIva + "%" +
                                    this.FuncionEspacio(maxLength_11 - total_.Length) + total_ +
                                    this.FuncionEspacio(maxLength_10 - baseIva_.Length) + baseIva_  +
                                    this.FuncionEspacio(maxLength_10 - valorIva_.Length) + valorIva_);
                            }
                            else
                            {
                                if (total_.Length == 10)
                                {
                                    Console.WriteLine("  " + ivaDevoluciones_.PorcentajeIva + "%");
                                    Console.WriteLine(this.FuncionEspacio(maxLength_14 - total_.Length) + total_ +
                                                      this.FuncionEspacio(maxLength_11 - baseIva_.Length) + baseIva_ +
                                                      this.FuncionEspacio(maxLength_10 - valorIva_.Length) + valorIva_);
                                }
                                else
                                {
                                    Console.WriteLine("  " + ivaDevoluciones_.PorcentajeIva + "%");
                                    Console.WriteLine(this.FuncionEspacio(maxLength_13 - total_.Length) + total_ +
                                                      this.FuncionEspacio(maxLength_12 - baseIva_.Length) + baseIva_ +
                                                      this.FuncionEspacio(maxLength_10 - valorIva_.Length) + valorIva_);
                                }
                            }
                        }
                        else
                        {
                            if (ivaDevoluciones_.PorcentajeIva.ToString().Length == 1)        // IVA 5%
                            {
                                if (total_.Length < 10)
                                {
                                    Console.WriteLine("  " + ivaDevoluciones_.PorcentajeIva + "%" +
                                        this.FuncionEspacio(maxLength_11 - total_.Length) + total_ +
                                        this.FuncionEspacio(maxLength_10 - baseIva_.Length) + baseIva_ +
                                        this.FuncionEspacio(maxLength_10 - valorIva_.Length) + valorIva_);
                                }
                                else
                                {
                                    if (total_.Length == 10)
                                    {
                                        Console.WriteLine("  " + ivaDevoluciones_.PorcentajeIva + "%");
                                        Console.WriteLine(this.FuncionEspacio(maxLength_14 - total_.Length) + total_ +
                                                          this.FuncionEspacio(maxLength_11 - baseIva_.Length) + baseIva_ +
                                                          this.FuncionEspacio(maxLength_10 - valorIva_.Length) + valorIva_);
                                    }
                                    else
                                    {
                                        Console.WriteLine("  " + ivaDevoluciones_.PorcentajeIva + "%");
                                        Console.WriteLine(this.FuncionEspacio(maxLength_12 - total_.Length) + total_ +
                                                          this.FuncionEspacio(maxLength_12 - baseIva_.Length) + baseIva_ +
                                                          this.FuncionEspacio(maxLength_11 - valorIva_.Length) + valorIva_);
                                    }
                                }
                            }
                            else  // - - - - - - - - - - - - -  - - - - - - - - - - - - - - - - IVA 19%
                            {
                                if (total_.Length < 10)
                                {
                                    Console.WriteLine(" " + ivaDevoluciones_.PorcentajeIva + "%" +
                                        this.FuncionEspacio(maxLength_11 - total_.Length) + total_ +
                                        this.FuncionEspacio(maxLength_10 - baseIva_.Length) + baseIva_ +
                                        this.FuncionEspacio(maxLength_10 - valorIva_.Length) + valorIva_);
                                }
                                else
                                {
                                    if (total_.Length == 10)
                                    {
                                        Console.WriteLine(" " + ivaDevoluciones_.PorcentajeIva + "%");
                                        Console.WriteLine(this.FuncionEspacio(maxLength_13 - total_.Length) + total_ +
                                                          this.FuncionEspacio(maxLength_11 - baseIva_.Length) + baseIva_ +
                                                          this.FuncionEspacio(maxLength_11 - valorIva_.Length) + valorIva_);
                                    }
                                    else
                                    {
                                        Console.WriteLine(" " + ivaDevoluciones_.PorcentajeIva + "%");
                                        Console.WriteLine(this.FuncionEspacio(maxLength_11 - total_.Length) + total_ +
                                                          this.FuncionEspacio(maxLength_12 - baseIva_.Length) + baseIva_ +
                                                          this.FuncionEspacio(maxLength_11 - valorIva_.Length) + valorIva_);
                                    }
                                }
                            }
                        }
                    }
                    Console.WriteLine("");
                }*/
                
                

                /*foreach (IvaDevolucion ivaDevol in ivaDevoluciones)
                {

                }*/


                /*
                this.dgvIvaDevoluciones.DataSource = ivaDevoluciones;
                this.dgvIvaAnuladas.DataSource = ivaAnuladas;
                */


                
                FechaActual = dtpFecha.Value;
                FechaActual2 = dtpFecha2.Value;

                this.miOption = new OptionPane();
                this.miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Marquee;
                this.miOption.FrmProgressBar.Closed_ = true;
                this.miOption.ProgressShow("Espere mientras se realizan las operaciones necesarias...",
                    "Operacion en progreso");
                this.Enabled = false;
                this.miThread = new Thread(Cargar);
                this.miThread.Start();
                

                //miBussinesConsultaImpuesto.ConsultaCompras(dtpFecha.Value, dtpFecha2.Value);
                
                /**
                foreach (DataRow row in this.miBussUser.Usuarios().Rows)
                {
                    Console.WriteLine(row["documento"].ToString() + "  " + row["usuario"].ToString() + "  " + Encode.Decrypt(row["contrasenia"].ToString()));
                }
                */

                /*var miBussinesInventario = new BussinesInventario();
                miBussinesInventario.VerCodigosRepetidosInventario();*/

                //this.dgvIvaAnuladas.DataSource = this.miBussUser.UsuariosAll();

                //StringBuilderDetalleValor(string detalle, string valor, int maxCharacters)

                /*Ticket t = new Ticket();
                foreach (var s in
                UseObject.StringBuilderDetalleValor("Abono a factura número: 4013.", "88.760", 35))
                {
                    t.AddHeaderLine(s);
                }
                t.PrintTicket("Microsoft XPS Document Writer");*/
              //  this.dgvIvaAnuladas.DataSource = this.miBussinesFactura.ValoresFacturaVenta(this.dtpFecha.Value, this.dtpFecha2.Value);


                //this.dgvIvaDevoluciones.DataSource = this.miBussDevol.Repetidos();
                //this.miBussDevol.LimpiarSpace_ProduDupli();
                //OptionPane.MessageInformation("Listo.. !");

            }
            catch (Exception ex) { OptionPane.MessageError(ex.Message); }


           /* this.FechaActual = this.dtpFecha.Value;
            this.FechaActual2 = this.dtpFecha2.Value;*/

            //this.maxValor = Convert.ToInt32(this.txtIdCaja.Text);

           


        }


        private void btnCargarFechasTotales_Click(object sender, EventArgs e)
        {
            try
            {
                this.miOption = new OptionPane();
                this.miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Marquee;
                this.miOption.FrmProgressBar.Closed_ = true;
                this.miOption.ProgressShow("Espere mientras se realizan las operaciones necesarias...",
                    "Operacion en progreso");
                this.Enabled = false;
                this.miThread = new Thread(Cargar_F4);
                this.miThread.Start();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }


        private void btnConsultaIva_Click(object sender, EventArgs e)
        {
            try
            {
                FechaActual = dtpFecha.Value;
                FechaActual2 = dtpFecha2.Value;


                this.miOption = new OptionPane();
                this.miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Marquee;
                this.miOption.FrmProgressBar.Closed_ = true;
                this.miOption.ProgressShow("Espere mientras se realizan las operaciones necesarias...",
                    "Operacion en progreso");
                this.Enabled = false;
                this.miThread = new Thread(Cargar_Rbo);
                this.miThread.Start();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }


        private void btnLoadSaldosCarteraF4_Click(object sender, EventArgs e)
        {
            try
            {
                this.miOption = new OptionPane();
                this.miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Marquee;
                this.miOption.FrmProgressBar.Closed_ = true;
                this.miOption.ProgressShow("Espere mientras se realizan las operaciones necesarias...",
                    "Operacion en progreso");
                this.Enabled = false;
                this.miThread = new Thread(Cargar_F4);
                this.miThread.Start();
            }
            catch { }
        }

        private void btnLoadSaldosRbo_Click(object sender, EventArgs e)
        {
            try
            {
                this.miOption = new OptionPane();
                this.miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Marquee;
                this.miOption.FrmProgressBar.Closed_ = true;
                this.miOption.ProgressShow("Espere mientras se realizan las operaciones necesarias...",
                    "Operacion en progreso");
                this.Enabled = false;
                this.miThread = new Thread(Cargar_Rbo);
                this.miThread.Start();
            }
            catch { }
        }

        private string FuncionEspacio(int lengthEspacio)
        {
            string espacio = "";
            for(int i = 1; i <= lengthEspacio; i++)
            {
                espacio += " ";
            }
            return espacio;
        }


        private void Cargar()
        {
            try
            {
                //this.tClientes = this.miBussinesFactura.CargarPuntos(this.FechaActual, this.FechaActual2);
                //this.miBussCompra.AjustarComprasAndPagos(this.maxValor);

               // this.tClientes = this.miBussinesFactura.NumerosFacturasRepetidas();


                //this.miBussCompra.AjustarPreciosDeProductos();

                //this.tClientes = this.miBussinesFactura.FacturasYpagos(Convert.ToInt32(this.txtIdCaja.Text), this.dtpFecha.Value);

                //this.lstFacturas = this.miBussinesFactura.FacturasDeCartera();

                /*this.table_1 = this.miBussinesFactura.FacturasDeCarteraNew();
                this.table_2 = this.miBussinesFactura.ProductosFacturasDeCartera();
                this.table_3 = this.miBussinesFactura.PagosFacturasDeCartera();*/

                /*DateTime fecha = new DateTime(dtpFechaAjuste.Value.Year, dtpFechaAjuste.Value.Month, dtpFechaAjuste.Value.Day, 12, 0, 0);
                DateTime fecha2 = new DateTime(dtpFechaAjuste2.Value.Year, dtpFechaAjuste2.Value.Month, dtpFechaAjuste2.Value.Day, 12, 0, 0);*/

                
                DateTime fechaStop = new DateTime(dtpFechaStop.Value.Year, dtpFechaStop.Value.Month, dtpFechaStop.Value.Day, 0, 0, 0);
                DateTime fechaMonto = new DateTime(dtpFechaAjuste.Value.Year, dtpFechaAjuste.Value.Month, dtpFechaAjuste.Value.Day, 0, 0, 0);
                
                this.miBussRemision.AjusteIvaVenta(fechaStop, fechaMonto, Convert.ToInt32(this.txtIdCaja.Text));  // este es el de uso, ajuste de iva La Campiña
                

                //miBussRemision.AjusteDeInventario();

                miBussinessConsulta.ActualizarTotalProductoVenta(FechaActual, FechaActual2);

                ///miBussinessConsulta.AjustarCodigosBarrasInterno();

                //miBussinessConsulta.InflarValorBaseVenta();

                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(Finalizar));
                }
            }
            catch (Exception ex)
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(Finalizar));
                }
                OptionPane.MessageError(ex.Message);
            }
        }

        private void Finalizar()
        {
            try
            {
                //this.dataGrid_1.DataSource = this.tClientes;

                /*this.dataGrid_1.DataSource = this.table_1;
                this.dataGrid_2.DataSource = this.table_2;
                this.dataGrid_3.DataSource = this.table_3;*/

                miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Blocks;
                miOption.FrmProgressBar.Closed_ = false;
                miOption.FrmProgressBar.Close();
                this.Enabled = true;
                OptionPane.MessageInformation("La operación se realizó con éxito.");
            }
            catch (Exception ex)
            {
                miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Blocks;
                miOption.FrmProgressBar.Closed_ = false;
                miOption.FrmProgressBar.Close();
                this.Enabled = true;
                OptionPane.MessageError(ex.Message);
            }
        }


        private void Cargar_F4()
        {
            try
            {
                /*this.tClientes.Columns.Add(new DataColumn("cedula", typeof(string)));
                this.tClientes.Columns.Add(new DataColumn("cliente", typeof(string)));
                this.tClientes.Columns.Add(new DataColumn("saldo", typeof(double)));

                var clientesT = this.miBussCliente.ListadoDeClientes();
                foreach (DataRow ctRow in clientesT.Rows)
                {
                    var cRow = tClientes.NewRow();
                    cRow["cedula"] = ctRow["nitcliente"];
                    cRow["cliente"] = ctRow["nombrescliente"];
                    cRow["saldo"] = this.miBussinesFactura.CarteraCliente_(2, ctRow["nitcliente"].ToString()).Sum(s => s.Saldo);
                    tClientes.Rows.Add(cRow);
                }*/

                //this.tClientes = this.miBussinesFactura.ProductosDeVentas(this.lstFacturas);


                DateTime fecha = new DateTime(dtpFecha.Value.Year, dtpFecha.Value.Month, dtpFecha.Value.Day, 12, 0, 0);
                DateTime fecha2 = new DateTime(dtpFecha2.Value.Year, dtpFecha2.Value.Month, dtpFecha2.Value.Day, 12, 0, 0);

                this.miBussRemision.FechasyTotalesVentas(fecha, fecha2);

                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(Finalizar_LoadF4));
                }
            }
            catch (Exception ex)
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(Finalizar_LoadF4));
                }
                OptionPane.MessageError(ex.Message);
            }
        }

        private void Finalizar_LoadF4()
        {
            try
            {
                //this.dataGrid_2.DataSource = this.tClientes;

                miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Blocks;
                miOption.FrmProgressBar.Closed_ = false;
                miOption.FrmProgressBar.Close();
                this.Enabled = true;
                OptionPane.MessageInformation("La operación se realizó con éxito.");
            }
            catch (Exception ex)
            {
                miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Blocks;
                miOption.FrmProgressBar.Closed_ = false;
                miOption.FrmProgressBar.Close();
                this.Enabled = true;
                OptionPane.MessageError(ex.Message);
            }
        }


        private void Cargar_Rbo()
        {
            try
            {
               /* this.tClientes.Columns.Add(new DataColumn("cedula", typeof(string)));
                this.tClientes.Columns.Add(new DataColumn("cliente", typeof(string)));
                this.tClientes.Columns.Add(new DataColumn("saldo", typeof(double)));

                var clientesT = this.miBussCliente.ListadoDeClientes();
                foreach (DataRow ctRow in clientesT.Rows)
                {
                    var cRow = tClientes.NewRow();
                    cRow["cedula"] = ctRow["nitcliente"];
                    cRow["cliente"] = ctRow["nombrescliente"];
                    cRow["saldo"] = this.miBussinesFactura.SaldoClienteRboIngreso(ctRow["nitcliente"].ToString());
                    tClientes.Rows.Add(cRow);
                }*/


                table_1.Columns.Add(new DataColumn("Fecha", typeof(DateTime)));
                table_1.Columns.Add(new DataColumn("Iva", typeof(string)));
                table_1.Columns.Add(new DataColumn("Base", typeof(double)));
                table_1.Columns.Add(new DataColumn("VIva", typeof(double)));
                table_1.Columns.Add(new DataColumn("SubTotal", typeof(double)));

                int diaIni = FechaActual.Day;
                int diaFin = FechaActual2.Day;
                DataTable tIva = new DataTable();

                while (diaIni <= diaFin)
                {
                    tIva = miBussinesFactura.TotalIvaFacturado_Datos(FechaActual, FechaActual);
                    foreach (DataRow iRow in tIva.Rows)
                    {
                        var iNewRow = table_1.NewRow();
                        iNewRow["Fecha"] = iRow["Fecha"];
                        iNewRow["Iva"] = iRow["Iva"];
                        iNewRow["Base"] = iRow["Base"];
                        iNewRow["VIva"] = iRow["VIva"];
                        iNewRow["SubTotal"] = iRow["SubTotal"];
                        table_1.Rows.Add(iNewRow);
                    }
                    diaIni++;
                    FechaActual = FechaActual.AddDays(1);
                }

                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(Finalizar_Rbo));
                }
            }
            catch (Exception ex)
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(Finalizar_Rbo));
                }
                OptionPane.MessageError(ex.Message);
            }
        }

        private void Finalizar_Rbo()
        {
            try
            {
                //this.dataGrid_1.DataSource = this.tClientes;

                dataGrid_1.DataSource = table_1;

                miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Blocks;
                miOption.FrmProgressBar.Closed_ = false;
                miOption.FrmProgressBar.Close();
                this.Enabled = true;
                OptionPane.MessageInformation("La operación se realizó con éxito.");
            }
            catch (Exception ex)
            {
                miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Blocks;
                miOption.FrmProgressBar.Closed_ = false;
                miOption.FrmProgressBar.Close();
                this.Enabled = true;
                OptionPane.MessageError(ex.Message);
            }
        }

        private void dataGrid_2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGrid_3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGrid_1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        

        



       
    }
}