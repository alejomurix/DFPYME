using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO.Clases;

namespace Utilities
{
    public class PrintTicket
    {
        private Ticket miTicket { set; get; }

        public bool UseItem { set; get; }

        public int MaxCharacters { set; get; }

        public bool Detail { set; get; }

        public bool Copia { set; get; }


        public DataRow empresaRow { set; get; }

        /// <summary>
        /// Obtiene o establece si el documento es una factura de venta. True si es factura, False no es facutra.
        /// </summary>
        public bool EsFactura { set; get; }

        public int IdEstado { set; get; }

        public string TipoDocumento { set; get; }

        public string Numero { set; get; }



        //public DataRow fechaRow { set; get; }

        public DateTime Fecha { set; get; }

        public DateTime Hora { set; get; }

        public DateTime Limite { set; get; }


        public string Usuario { set; get; }

        public string NoCaja { set; get; }

        public string Station { set; get; }

        public Cliente Cliente { set; get; }

        public DataRow clienteRow { set; get; }

        public DataTable tDetalle { set; get; }


        public bool DatosCliente { set; get; }


        public int Pago { set; get; }


        public bool Puntos { set; get; }

        public double[] DataPuntos { set; get; }

        public bool DescuentoMarca { set; get; }

        public int Ahorro { set; get; }



        public List<Iva> DetalleIva { set; get; }

        public ImpuestoBolsa impuesto { set; get; }

        public DataRow dianRow { set; get; }

        public Dian DianReg { set; get; }



        public Bono Bono { set; get; }



        public string DetalleRbo { set; get; }

        public string ValorRbo { set; get; }

        public List<FormaPago> PagosRbo { set; get; }

        public Saldo anticipo;

        public bool Abono;

        public DataTable tPagos;

        public string saldoAbono;



        //public DataRow 

        //public List<ProductoFacturaProveedor> lstProductos { set; get; }

        private string product;

        private string cant;

        private string venta;

        private string subTotal;

        private string total_;

        private double total;

        private string efectivo;

        private string cambio;


        //  variables temporales
        public string SubTotal { set; get; }

        public string Total_ { set; get; }


        public PrintTicket()
        {
            this.miTicket = new Ticket();
            this.UseItem = true;
            this.MaxCharacters = 35;
            this.Detail = false;
            this.Copia = false;

            this.DatosCliente = false;

            this.DescuentoMarca = false;

            this.impuesto = new ImpuestoBolsa();
            //this.lstProductos = new List<ProductoFacturaProveedor>();

            this.product = "";
            this.cant = "";
            this.venta = "";
            this.subTotal = "";
            this.total_ = "";
            this.total = 0;
            this.efectivo = "";
            this.cambio = "";
        }



        private void EncabezadoEmpresa()
        {
            try
            {
                this.miTicket.UseItem = this.UseItem;

                foreach (var datos in UseObject.StringBuilderDataCenter(this.empresaRow["Nombre"].ToString().ToUpper(), this.MaxCharacters))
                {
                    this.miTicket.AddHeaderLine(datos);
                }
                foreach (var datos in UseObject.StringBuilderDataCenter(this.empresaRow["Juridico"].ToString(), this.MaxCharacters))
                {
                    this.miTicket.AddHeaderLine(datos);
                }
                foreach (var datos in UseObject.StringBuilderDataCenter(
                    "NIT " + UseObject.InsertSeparatorMilMasDigito(this.empresaRow["Nit"].ToString()), this.MaxCharacters))
                {
                    this.miTicket.AddHeaderLine(datos);
                }
                foreach (var datos in UseObject.StringBuilderDataCenter(this.empresaRow["Direccion"].ToString(), this.MaxCharacters))
                {
                    this.miTicket.AddHeaderLine(datos);
                }
                string tels = "";
                if (this.empresaRow["Telefono"].ToString().Length > 3)
                {
                    tels = this.empresaRow["Telefono"].ToString() + " - ";
                }
                if (this.empresaRow["celularempresa"].ToString().Length > 3)
                {
                    tels += this.empresaRow["celularempresa"].ToString();
                }
                foreach (var datos in UseObject.StringBuilderDataCenter("TELS. " + tels, this.MaxCharacters))
                {
                    this.miTicket.AddHeaderLine(datos);
                }
                foreach (var datos in UseObject.StringBuilderDataCenter(empresaRow["Regimen"].ToString(), this.MaxCharacters))
                {
                    this.miTicket.AddHeaderLine(datos);
                }
                this.miTicket.AddHeaderLine("");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void EncabezadoDocumentoFechaUsuarioCaja()
        {
            try
            {
                string texto = "";

                if (this.EsFactura)
                {
                    if (this.IdEstado == 1 || this.IdEstado == 2)
                    {
                        this.TipoDocumento = "FACTURA DE VENTA POS";
                    }
                    else
                    {
                        if (this.IdEstado == 4)
                        {
                            this.TipoDocumento = "COTIZACIÓN";
                        }
                    }
                }
                else
                {
                    this.TipoDocumento = "REMISIÓN   VENTA";
                }
                this.miTicket.AddHeaderLine(this.TipoDocumento + " No. " + Numero);


               /* if (Convert.ToInt32(empresaRow["idregimen"]).Equals(1))   //  COMÚN
                {
                    this.miTicket.AddHeaderLine("-----------------------------------");
                    this.miTicket.AddHeaderLine("RESPONSABLE DE IVA FACTURA DE VENTA");
                    
                    this.miTicket.AddHeaderLine("RÉGIMEN " + empresaRow["Regimen"].ToString() + "      " + this.TipoDocumento);
                }
                else     // SIMPLIFICADO
                {
                    texto = empresaRow["Regimen"].ToString().Substring(0, 7);
                    this.miTicket.AddHeaderLine("RÉGIMEN " + texto + "   " + this.TipoDocumento);
                }*/

                this.miTicket.AddHeaderLine(
                    "Fecha : " + this.Fecha.ToShortDateString() + "  " + this.Hora.TimeOfDay.Hours + ":" +  UseObject.AnadirCeroEnUnidad(this.Hora.TimeOfDay.Minutes));
                if (this.IdEstado.Equals(2))  // Credito
                {
                    this.miTicket.AddHeaderLine("CRÉDITO Fecha Limite : " + this.Limite.ToShortDateString());
                }
                if (Usuario.Length >= 19)  //  12
                {
                    texto = this.Usuario.Substring(0, 19);  // 12
                }
                else
                {
                    texto = this.Usuario;
                }
               // this.miTicket.AddHeaderLine("-----------------------------------");
               // this.miTicket.AddHeaderLine("CAJA 1  CAJERO: USUARIO ADMINISTRAD");
                this.miTicket.AddHeaderLine("CAJA " + NoCaja + "  CAJERO: " + texto);
                this.miTicket.AddHeaderLine("ESTACION: " + this.Station);
                //this.miTicket.AddHeaderLine("Caja  : " + NoCaja);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /*private void EncabezadoFechaUsuarioCaja()
        {
            try
            {
                this.miTicket.AddHeaderLine("Fecha : " + this.Fecha.ToShortDateString() + " Nro " + Numero);
                if (this.IdEstado.Equals(2))  // Credito
                {
                    this.miTicket.AddHeaderLine("CRÉDITO Fecha Limite : " + this.Limite.ToShortDateString());
                }
                this.miTicket.AddHeaderLine
                        ("Hora  : " + this.Hora.TimeOfDay.Hours + ":" + this.Hora.TimeOfDay.Minutes +
                         "  Cajero: " + this.Usuario.Substring(0, 12));
                this.miTicket.AddHeaderLine("Caja  : " + NoCaja);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }*/

        private void EncabezadoCliente()
        {
            try
            {
                this.miTicket.AddHeaderLine("-----------------------------------");
                if (clienteRow["nombrescliente"].ToString().Count() > 25)
                {
                    var stringCliente = UseObject.StringBuilderDataIzquierda(clienteRow["nombrescliente"].ToString(), 25);
                    for (int i = 0; i < stringCliente.Count; i++)
                    {
                        if (i.Equals(0))
                        {
                            this.miTicket.AddHeaderLine("CLIENTE : " + stringCliente[i]);
                        }
                        else
                        {
                            this.miTicket.AddHeaderLine("          " + stringCliente[i]);
                        }
                    }
                }
                else
                {
                    this.miTicket.AddHeaderLine("CLIENTE : " + clienteRow["nombrescliente"].ToString());
                }
                this.miTicket.AddHeaderLine("NIT     : " + UseObject.InsertSeparatorMilMasDigito(clienteRow["nitcliente"].ToString()));

                if (this.DatosCliente)
                {
                    if (clienteRow["direccioncliente"].ToString().Count() > 25)
                    {
                        var stringDireccion = UseObject.StringBuilderDataIzquierda(clienteRow["direccioncliente"].ToString(), 25);
                        for (int i = 0; i < stringDireccion.Count; i++)
                        {
                            if (i.Equals(0))
                            {
                                this.miTicket.AddHeaderLine("DIR.    : " + stringDireccion[i]);
                            }
                            else
                            {
                                this.miTicket.AddHeaderLine("          " + stringDireccion[i]);
                            }
                        }
                    }
                    else
                    {
                        this.miTicket.AddHeaderLine("DIR.    : " + clienteRow["direccioncliente"].ToString());
                    }
                    this.miTicket.AddHeaderLine("          " + clienteRow["nombreciudad"].ToString() + " " +
                                                               clienteRow["nombredepartamento"].ToString());
                    this.miTicket.AddHeaderLine("TELS.   : " + clienteRow["celularcliente"].ToString());
                    if (clienteRow["emailcliente"].ToString().Count() > 25)
                    {
                        this.miTicket.AddHeaderLine("E-MAIL  : ");
                        this.miTicket.AddHeaderLine(clienteRow["emailcliente"].ToString());
                    }
                    else
                    {
                        this.miTicket.AddHeaderLine("E-MAIL  : " + clienteRow["emailcliente"].ToString());
                    }
                }

                this.miTicket.AddHeaderLine("-----------------------------------");
                this.miTicket.AddHeaderLine("");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void EncabezadoClienteRecibo()
        {
            try
            {
                this.miTicket.AddHeaderLine("-----------------------------------");
                this.miTicket.AddHeaderLine("RECIBIDO DE : " + this.Cliente.NombresCliente.ToUpper());
                this.miTicket.AddHeaderLine("NIT O C.C.  : " + UseObject.InsertSeparatorMilMasDigito(this.Cliente.NitCliente));

                this.miTicket.AddHeaderLine("-----------------------------------");
                this.miTicket.AddHeaderLine("");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void EncabezadoClienteDevolucion()
        {
            try
            {
                /*foreach (var datos_ in UseObject.StringBuilderDataIzquierda("Remite a : " + beneficio.NombresCliente.ToUpper(), MaxCharacters))
                    {
                        ticket.AddHeaderLine(datos_);
                    }*/

                this.miTicket.AddHeaderLine("-----------------------------------");
                foreach (var datos_ in UseObject.StringBuilderDataIzquierda("CLIENTE    : " + this.Cliente.NombresCliente.ToUpper(), MaxCharacters))
                {
                    this.miTicket.AddHeaderLine(datos_);
                }
                //this.miTicket.AddHeaderLine("CLIENTE    : " + this.Cliente.NombresCliente.ToUpper());
                this.miTicket.AddHeaderLine("NIT O C.C. : " + UseObject.InsertSeparatorMilMasDigito(this.Cliente.NitCliente));

                this.miTicket.AddHeaderLine("-----------------------------------");
                this.miTicket.AddHeaderLine("");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void EncabezadoDescripcionDetalle()
        {
            if (this.Detail)
            {
                this.miTicket.AddHeaderLine("CANT  DESCRIPCION             TOTAL");
                this.miTicket.AddHeaderLine("");
            }
            else
            {
                this.miTicket.AddHeaderLine("DESCRIP.  CANT.    VENTA      TOTAL");
                this.miTicket.AddHeaderLine("");

               // Console.WriteLine("DESCRIP.  CANT.    VENTA      TOTAL");
               // Console.WriteLine("");
            }
        }

        private void EncabezadoDescripcionRecibo()
        {
            this.miTicket.AddHeaderLine("  CONCEPTO                    TOTAL");
            this.miTicket.AddHeaderLine("");
        }

        private void DetalleRecibido()
        {
            foreach (var s in
                UseObject.StringBuilderDetalleValor(this.DetalleRbo, this.ValorRbo, 35))
            {
                this.miTicket.AddHeaderLine(s);
            }
        }

        /*private void EncabezadoRemisionVenta()
        {
            try
            {
                string regimen_ = "";
                if (Convert.ToInt32(empresaRow["idregimen"]).Equals(1))   //  COMÚN
                {
                    this.miTicket.AddHeaderLine("RÉGIMEN " + empresaRow["Regimen"].ToString() + "      REMISIÓN   VENTA");
                }
                else     // SIMPLIFICADO
                {
                    regimen_ = empresaRow["Regimen"].ToString().Substring(0, 7);
                    this.miTicket.AddHeaderLine("RÉGIMEN " + regimen_ + "   REMISIÓN   VENTA");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }*/

        /* private void EncabezadoFacturaVenta()
         {
             try
             {

             }
             catch (Exception ex)
             {
                 throw new Exception(ex.Message);
             }
         }*/

        private void DetalleArticulos()
        {
            try
            {
                if (this.Detail)
                {
                    this.PrintDetail();
                }
                else
                {
                    foreach (DataRow dRow in tDetalle.Rows)
                    {
                        this.product = dRow["Codigo"].ToString() + " " + dRow["Producto"].ToString();
                        if (this.product.Length > this.MaxCharacters)
                        {
                            this.product = this.product.Substring(0, this.MaxCharacters);
                        }
                        this.miTicket.AddHeaderLine(this.product);
                        this.cant = UseObject.InsertSeparatorMil(dRow["Cantidad"].ToString());
                        this.venta = UseObject.InsertSeparatorMil(dRow["Valor_"].ToString());
                        this.total_ = UseObject.InsertSeparatorMil(dRow["Total_"].ToString());
                        this.miTicket.AddHeaderLine(UseObject.StringBuilderDetalleProducto(this.cant, this.venta, this.total_));

                       // Console.WriteLine(UseObject.StringBuilderDetalleProducto(this.cant, this.venta, this.total_));
                    }
                }
                this.miTicket.AddHeaderLine("");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void PrintDetail()
        {
            foreach (DataRow dRow in this.tDetalle.Rows)
            {
                string product = dRow["Producto"].ToString();
                string product_2 = "";
                if (product.Length > 19)
                {
                    product = product.Substring(0, 19);
                    product_2 = dRow["Producto"].ToString().Substring(19);
                }
                var space_cant = "";
                switch (dRow["Cantidad"].ToString().Length)
                {
                    case 1:
                        {
                            space_cant = "     ";
                            break;
                        }
                    case 2:
                        {
                            space_cant = "    ";
                            break;
                        }
                    case 3:
                        {
                            space_cant = "   ";
                            break;
                        }
                    case 4:
                        {
                            space_cant = "  ";
                            break;
                        }
                    case 5:
                        {
                            space_cant = " ";
                            break;
                        }
                }
                var space_total = "";
                switch (UseObject.InsertSeparatorMil(dRow["Total_"].ToString()).Length)
                {
                    case 3:
                        {
                            space_total = "      ";
                            break;
                        }
                    case 5:
                        {
                            space_total = "    ";
                            break;
                        }
                    case 6:
                        {
                            space_total = "   ";
                            break;
                        }
                    case 7:
                        {
                            space_total = "  ";
                            break;
                        }
                    case 9:
                        {
                            space_total = " ";
                            break;
                        }
                }
                this.miTicket.AddHeaderLine("      COD:" + dRow["Codigo"].ToString() + " v/u " + UseObject.InsertSeparatorMil(dRow["Valor_"].ToString()));
                var line = "      COD:" + dRow["Codigo"].ToString() + " v/u " + UseObject.InsertSeparatorMil(dRow["Valor_"].ToString());
                if (UseObject.InsertSeparatorMil(dRow["Total_"].ToString()).Length > 9 && product_2.Length > 18)
                {
                    product_2 = product_2.Substring(0, 16);
                    var space_3 = "";
                    for (int i = (product_2.Length + UseObject.InsertSeparatorMil(dRow["Total_"].ToString()).Length); i < 29; i++)
                    {
                        space_3 += " ";
                    }

                    this.miTicket.AddHeaderLine(dRow["Cantidad"].ToString() + space_cant + product);
                    line = dRow["Cantidad"].ToString() + space_cant + product;
                    this.miTicket.AddHeaderLine("      " + product_2 + space_3 + UseObject.InsertSeparatorMil(dRow["Total_"].ToString()));
                    line = "      " + product_2 + space_3 + UseObject.InsertSeparatorMil(dRow["Total_"].ToString());
                }
                else
                {
                    this.miTicket.AddHeaderLine(dRow["Cantidad"].ToString() + space_cant + product + space_total +
                        UseObject.InsertSeparatorMil(dRow["Total_"].ToString()));
                    line = dRow["Cantidad"].ToString() + space_cant + product + space_total +
                        UseObject.InsertSeparatorMil(dRow["Total_"].ToString());
                    if (product_2 != "")
                    {
                        this.miTicket.AddHeaderLine("      " + product_2);
                        line = "      " + product_2;
                    }
                }
                this.miTicket.AddHeaderLine("");
            }
        }

        private void DetalleTotalEfectivoCambio()
        {
            try
            {
                this.total = this.tDetalle.AsEnumerable().Sum(d => d.Field<int>("Total_"));
                                // +(this.impuesto.Cantidad * this.impuesto.Valor);
                this.total_ = UseObject.InsertSeparatorMil((this.total + (this.impuesto.Cantidad * this.impuesto.Valor)).ToString());
                this.efectivo = UseObject.InsertSeparatorMil(this.Pago.ToString());
                this.cambio = UseObject.InsertSeparatorMil((this.Pago - UseObject.RemoveSeparatorMil(this.total_)).ToString());
                /*if (this.IdEstado.Equals(2))
                {
                    efectivo = "0";
                    cambio = "0";
                }*/
                //this.miTicket.AddHeaderLine("");
                this.miTicket.AddHeaderLine("-----------------------------------");
                this.miTicket.AddHeaderLine("");

                if (EsFactura)
                {
                    int totalIva = Convert.ToInt32(this.DetalleIva.Sum(s => s.Total));
                    int BaseIva = Convert.ToInt32(this.DetalleIva.Sum(s => s.BaseI));
                    int valorIva = Convert.ToInt32(this.DetalleIva.Sum(s => s.ValorIva));

                    if (Convert.ToInt32(empresaRow["idregimen"]).Equals(1))  // RESPONSABLE DE IVA
                    {
                        /*this.miTicket.AddHeaderLine("         SUBTOTAL :" + UseObject.StringBuilderDetalleTotal
                                                                    (UseObject.InsertSeparatorMil(SubTotal)));

                        this.miTicket.AddHeaderLine("              IVA :" + UseObject.StringBuilderDetalleTotal
                            (UseObject.InsertSeparatorMil((Convert.ToInt32(Total_) - Convert.ToInt32(SubTotal)).ToString())));   //  triunfo*/

                        this.miTicket.AddHeaderLine("         SUBTOTAL :" + UseObject.StringBuilderDetalleTotal
                                                                    (UseObject.InsertSeparatorMil((total - valorIva).ToString())));
                        this.miTicket.AddHeaderLine("              IVA :" + UseObject.StringBuilderDetalleTotal
                                                                    (UseObject.InsertSeparatorMil(valorIva.ToString())));
                    }

                    //this.miTicket.AddHeaderLine("       TOTAL NETO :" + UseObject.StringBuilderDetalleTotal( UseObject.InsertSeparatorMil(Total_)));   //  triunfo
                    this.miTicket.AddHeaderLine("       TOTAL NETO :" + UseObject.StringBuilderDetalleTotal(total_));

                    if (this.IdEstado.Equals(1))
                    {
                        this.miTicket.AddHeaderLine("");
                    }

                   /* Console.WriteLine("");
                    Console.WriteLine("         SUBTOTAL :" + UseObject.StringBuilderDetalleTotal
                                                                (UseObject.InsertSeparatorMil((total - valorIva).ToString())));
                    Console.WriteLine("              IVA :" + UseObject.StringBuilderDetalleTotal
                                                                (UseObject.InsertSeparatorMil(valorIva.ToString())));
                    Console.WriteLine("       TOTAL NETO :" + UseObject.StringBuilderDetalleTotal(total_));*/
                }
                else
                {
                    this.miTicket.AddHeaderLine("       TOTAL NETO :" + UseObject.StringBuilderDetalleTotal(total_));
                }
                if (this.IdEstado.Equals(1))
                {
                    this.miTicket.AddHeaderLine("         EFECTIVO :" + UseObject.StringBuilderDetalleTotal(efectivo));
                    this.miTicket.AddHeaderLine("           CAMBIO :" + UseObject.StringBuilderDetalleTotal(cambio));
                }
                this.miTicket.AddHeaderLine("");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /*private void DetalleTotal(string detalle)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }*/

        private void DetallePuntosDescuento()
        {
            try
            {

                if (this.Puntos || this.Ahorro > 0)
                {
                    if (this.DataPuntos[0] > 0 || this.DataPuntos[1] > 0)
                    {
                        this.miTicket.AddHeaderLine("-----------------------------------");
                        this.miTicket.AddHeaderLine("");
                    }
                }
                if (this.Puntos)
                {
                    if (this.DataPuntos[0] > 0 || this.DataPuntos[1] > 0)
                    {
                        if (this.Copia)
                        {
                            this.miTicket.AddHeaderLine
                                ("Puntos acumulados a " + DateTime.Now.ToShortDateString() + " : ");
                            this.miTicket.AddHeaderLine
                                (UseObject.AjusteDeCaracteresDerecha(UseObject.InsertSeparatorMil(this.DataPuntos[0].ToString())));
                        }
                        else
                        {
                            this.miTicket.AddHeaderLine("Puntos de la venta : " + this.DataPuntos[0].ToString());
                            this.miTicket.AddHeaderLine("Puntos acumulados  : " + this.DataPuntos[1].ToString());
                        }
                        this.miTicket.AddHeaderLine("");
                    }
                }
                if (this.DescuentoMarca)
                {
                    if (this.Ahorro > 0)
                    {
                        //this.miTicket.AddHeaderLine("");
                        this.miTicket.AddHeaderLine("Su ahorro fue de   : $" + UseObject.InsertSeparatorMil(this.Ahorro.ToString()));
                        this.miTicket.AddHeaderLine("");
                        //this.miTicket.AddHeaderLine("");
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void DetalleIvaINCBolsas()
        {
            try
            {
                total_ = "";
                string baseIva_ = "";
                string valorIva_ = "";

                if (Convert.ToInt32(empresaRow["idregimen"]).Equals(1))
                {
                    if (this.IdEstado.Equals(1) || this.IdEstado.Equals(2))
                    {
                        /*Console.WriteLine("----------[ DETALLE IVA ]----------");
                        Console.WriteLine("GRAVADO   VENTA      BASE      IVA ");*/

                        this.miTicket.AddHeaderLine("----------[ DETALLE IVA ]----------");
                        this.miTicket.AddHeaderLine("GRAVADO   VENTA      BASE      IVA ");
                        foreach (var iva_ in this.DetalleIva)
                        {
                            total_ = UseObject.InsertSeparatorMil(iva_.Total.ToString());
                            baseIva_ = UseObject.InsertSeparatorMil(iva_.BaseI.ToString());
                            valorIva_ = UseObject.InsertSeparatorMil(iva_.ValorIva.ToString());

                           /* total_ = UseObject.InsertSeparatorMil(Total_);
                            baseIva_ = UseObject.InsertSeparatorMil(SubTotal);
                            valorIva_ = UseObject.InsertSeparatorMil((Convert.ToInt32(Total_) - Convert.ToInt32(SubTotal)).ToString());   //   triunfo */

                            if (total_.Length >= 10)
                            {
                                if (iva_.PorcentajeIva.ToString().Length == 1)
                                {
                                    //Console.WriteLine("  " + iva_.PorcentajeIva + "%");

                                    this.miTicket.AddHeaderLine("  " + iva_.PorcentajeIva + "%");
                                }
                                else
                                {
                                    //Console.WriteLine(" " + iva_.PorcentajeIva + "%");

                                    this.miTicket.AddHeaderLine(" " + iva_.PorcentajeIva + "%");
                                }
                            }
                            // Console.WriteLine(UseObject.StringBuilderDetalleIva(iva_.PorcentajeIva, total_, baseIva_, valorIva_));

                            this.miTicket.AddHeaderLine(UseObject.StringBuilderDetalleIva(iva_.PorcentajeIva, total_, baseIva_, valorIva_));
                        }

                        int ico = Convert.ToInt32(this.tDetalle.AsEnumerable().Sum(s => s.Field<double>("Cantidad") * s.Field<double>("Ico")));
                        if (ico > 0)
                        {
                            this.miTicket.AddHeaderLine("");
                            this.miTicket.AddHeaderLine("Impoconsumo: " + UseObject.InsertSeparatorMil(ico.ToString()));
                        }

                        if (impuesto.Cantidad > 0)
                        {
                            this.miTicket.AddHeaderLine("");
                            this.miTicket.AddHeaderLine("-----[ INC. BOLSAS PLÁSTICAS ]-----");
                            this.miTicket.AddHeaderLine("IMP. UNITARIO     CANT.       TOTAL");
                            this.miTicket.AddHeaderLine(UseObject.StringBuilderDetalleINCBP(impuesto.Valor.ToString(),
                                UseObject.InsertSeparatorMil(impuesto.Cantidad.ToString()),
                                UseObject.InsertSeparatorMil((impuesto.Valor * impuesto.Cantidad).ToString())));
                        }
                    }
                }

                //this.miTicket.AddHeaderLine("-----------------------------------");
                


               /* Console.WriteLine("-----------------------------------");
                Console.WriteLine("Impoconsumo: " + UseObject.InsertSeparatorMil(
                    Convert.ToInt32(this.tDetalle.AsEnumerable().Sum(s => s.Field<double>("Cantidad") * s.Field<double>("Ico"))).ToString()));*/
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void PieImpresion()
        {
            ///this.miTicket.AddHeaderLine("-----------------------------------");
            ///this.miTicket.AddHeaderLine("AUTORIZACIÓN FACTURACION ELECTRONIC");
            ///this.miTicket.AddHeaderLine("No. 18764029549683 VÁLIDA DESDE ");
            ///this.miTicket.AddHeaderLine("2020-01-01 HASTA 2022-12-31 ");
            ///this.miTicket.AddHeaderLine("RANGO: TCFA28521 A TCFA28620 ");
            try
            {
                this.miTicket.AddHeaderLine("");
                if (EsFactura)
                {
                    
                    if (Convert.ToInt32(empresaRow["idregimen"]).Equals(1))
                    {
                        if (this.IdEstado.Equals(1) || this.IdEstado.Equals(2))
                        {
                            foreach (var stringDian in UseObject.StringBuilderDetalleDIAN
                                (this.DianReg.TextoInicial + this.DianReg.NumeroResolucion, this.MaxCharacters))
                            {
                                this.miTicket.AddHeaderLine(stringDian);
                            }
                            this.miTicket.AddHeaderLine("de " + this.DianReg.FechaExpedicion.ToShortDateString());
                            foreach (var stringDian in UseObject.StringBuilderDetalleDIAN
                                (this.DianReg.TextoFinal + " del " + this.DianReg.SerieInicial + this.DianReg.RangoInicial + " al " + 
                                 this.DianReg.SerieFinal + this.DianReg.RangoFinal + ".", this.MaxCharacters))
                            {
                                this.miTicket.AddHeaderLine(stringDian);
                            }



                          /*  foreach (var stringDian in UseObject.StringBuilderDetalleDIAN
                                (this.dianRow["TxtInicial"].ToString() + this.dianRow["Resolucion"].ToString(), this.MaxCharacters))
                            {
                                this.miTicket.AddHeaderLine(stringDian);
                            }
                            this.miTicket.AddHeaderLine("de " + Convert.ToDateTime(this.dianRow["Fecha"]).ToShortDateString());
                            foreach (var stringDian in UseObject.StringBuilderDetalleDIAN
                                (this.dianRow["TxtFinal"].ToString() + " del " + this.dianRow["Desde"].ToString() + " al " + this.dianRow["Hasta"].ToString() + ".", this.MaxCharacters))
                            {
                                this.miTicket.AddHeaderLine(stringDian);
                            }*/


                        }
                    }
                }
                this.miTicket.AddHeaderLine("-----------------------------------");
                foreach (var datos in UseObject.StringBuilderDataCenter("SOFTWARE DFPYME", this.MaxCharacters))
                {
                    this.miTicket.AddHeaderLine(datos);
                }
                foreach (var datos in UseObject.StringBuilderDataCenter("INTREDETE", this.MaxCharacters))
                {
                    this.miTicket.AddHeaderLine(datos);
                }
                foreach (var datos in UseObject.StringBuilderDataCenter("comercial@intredete.com", this.MaxCharacters))
                {
                    this.miTicket.AddHeaderLine(datos);
                }
                this.miTicket.AddHeaderLine("");
                this.miTicket.AddHeaderLine("*GRACIAS POR SER NUESTROS CLIENTES*");
                this.miTicket.AddHeaderLine("");
                //this.EnviarImpresion();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void EnviarImpresion()
        {
            try
            {
                //this.miTicket.PrintTicket("Microsoft XPS Document Writer");
                this.miTicket.PrintTicket("IMPREPOS");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public void ImprimirRemisionVenta()
        {
            try
            {
                this.EncabezadoEmpresa();
                this.EncabezadoDocumentoFechaUsuarioCaja();
                this.EncabezadoCliente();
                this.EncabezadoDescripcionDetalle();
                this.DetalleArticulos();
                this.DetalleTotalEfectivoCambio();
                //this.DetallePuntosDescuento();
                this.PieImpresion();
                this.EnviarImpresion();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void ImprimirVenta()
        {
            try
            {
                this.EncabezadoEmpresa();
                this.EncabezadoDocumentoFechaUsuarioCaja();
                this.EncabezadoCliente();
                this.EncabezadoDescripcionDetalle();
                this.DetalleArticulos();
                this.DetalleTotalEfectivoCambio();
                //this.DetallePuntosDescuento();
                this.DetalleIvaINCBolsas();
                this.PieImpresion();
                this.EnviarImpresion();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public void ImprimirBonoRifa()
        {
            try
            {
                this.EncabezadoEmpresa();
                this.miTicket.AddHeaderLine("");
                this.miTicket.AddHeaderLine("SORTEO NÚMERO    :   " + this.Bono.Numero);
                this.miTicket.AddHeaderLine("FECHA DEL SORTEO :   " + this.Bono.Fecha.ToShortDateString());
                this.miTicket.AddHeaderLine("");
                this.miTicket.AddHeaderLine("DATOS DEL CLIENTE:");
                this.miTicket.AddHeaderLine("");
                this.miTicket.AddHeaderLine("Nombres: " + this.Cliente.NombresCliente);
                this.miTicket.AddHeaderLine("Cedula : " + this.Cliente.NitCliente);
                this.miTicket.AddHeaderLine("Celular : " + this.Cliente.CelularCliente);
                this.miTicket.AddHeaderLine("");
                this.miTicket.AddHeaderLine("");
                this.miTicket.AddHeaderLine("Fecha: " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
                this.miTicket.AddHeaderLine("Documento No. " + this.Numero);
                this.miTicket.AddHeaderLine("");
                foreach (var datos in UseObject.StringBuilderDataCenter(this.Bono.Concepto, this.MaxCharacters))
                {
                    this.miTicket.AddHeaderLine(datos);
                }
                this.EnviarImpresion();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public void PrintPayments(FacturaVenta invoice)
        {
            try
            {
                this.miTicket = new Ticket();
                this.EncabezadoEmpresa();

                UseObject.StringBuilderDataCenter("COMPROBANTE DE PAGO", MaxCharacters).
                    ForEach((data) => this.miTicket.AddHeaderLine(data));
                this.miTicket.AddHeaderLine("");
                this.miTicket.AddHeaderLine("Fecha: " + invoice.FechaIngreso.ToShortDateString() + " " +
                    invoice.FechaIngreso.TimeOfDay.Hours + ":" + invoice.FechaIngreso.TimeOfDay.Minutes);
                this.miTicket.AddHeaderLine("");
                this.miTicket.AddHeaderLine("No. factura:   " + invoice.Numero);
                this.miTicket.AddHeaderLine("Valor factura: " + UseObject.InsertSeparatorMil(invoice.Total.ToString().Replace('.', ',')));
                this.miTicket.AddHeaderLine("Valor pago:    " + UseObject.InsertSeparatorMil(invoice.FormasDePago.Sum(s => s.Valor).ToString().Replace('.', ',')));
                this.miTicket.AddHeaderLine("");
                this.miTicket.AddHeaderLine("Medios de pago");
                this.miTicket.AddHeaderLine("");
                this.miTicket.AddHeaderLine("Efectivo:      " + UseObject.InsertSeparatorMil(invoice.FormasDePago.Where
                    (p => p.IdFormaPago.Equals(1)).Sum(s => s.Valor).ToString().Replace('.', ',')));
                this.miTicket.AddHeaderLine("-----------------------------------");
                this.miTicket.AddHeaderLine("Transferencia: " + UseObject.InsertSeparatorMil(invoice.FormasDePago.Where
                    (p => p.IdFormaPago.Equals(4)).Sum(s => s.Valor).ToString().Replace('.', ',')));
                /*this.miTicket.AddHeaderLine("Tarjeta:       " + UseObject.InsertSeparatorMil(payment.Payments.Where
                    (p => p.Code.Equals("49")).Sum(s => s.Valor).ToString().Replace('.', ',')));*/
                this.miTicket.AddHeaderLine("");
                this.miTicket.AddHeaderLine("TOTAL BANCOS:  " + UseObject.InsertSeparatorMil(
                    invoice.FormasDePago.Where(p => p.IdFormaPago.Equals(4)).Sum(s => s.Valor).ToString().Replace('.', ',')));
                this.miTicket.AddHeaderLine("");
                this.miTicket.AddHeaderLine("");
                this.miTicket.AddHeaderLine("");
                this.miTicket.AddHeaderLine("___________________________________");
                this.miTicket.AddHeaderLine("FIRMA");
                this.miTicket.AddHeaderLine("___________________________________");
                this.miTicket.AddHeaderLine("CEDULA");
                this.miTicket.AddHeaderLine("___________________________________");
                this.miTicket.AddHeaderLine("TELEFONO");

                this.EnviarImpresion();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public void ImprimirEgreso()
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public void ImprimirRboAnticipo()
        {
            this.EncabezadoEmpresa();
            this.miTicket.AddHeaderLine("Fecha : " + anticipo.Fecha.ToShortDateString() +
                                     "    Caja : " + NoCaja);
            this.miTicket.AddHeaderLine("Cajero(a)  :  " + this.Usuario);
            //this.miTicket.AddHeaderLine("===================================");
            this.miTicket.AddHeaderLine("-----------------------------------");
            this.miTicket.AddHeaderLine("RECIBO DE ANTICIPO No " + anticipo.Numero);
            this.EncabezadoClienteRecibo();
            this.EncabezadoDescripcionRecibo();
            this.DetalleRecibido();
            this.miTicket.AddHeaderLine("");
            foreach(var pago in this.PagosRbo)
            {
                this.miTicket.AddHeaderLine("        " + pago.NombreFormaPago + " :" + UseObject.StringBuilderDetalleTotal
                                                             (UseObject.InsertSeparatorMil(pago.Valor.ToString())));
            }
            this.miTicket.AddHeaderLine("");
            
            this.miTicket.AddHeaderLine("-----------------------------------");
            this.miTicket.AddHeaderLine("");
            this.miTicket.AddHeaderLine("");
            this.miTicket.AddHeaderLine("Firma:");
            this.miTicket.AddHeaderLine("-----------------------------------");
            this.miTicket.AddHeaderLine("C.C. o NIT:");
            this.miTicket.AddHeaderLine("-----------------------------------");
            this.miTicket.AddHeaderLine("Fecha:");
            this.miTicket.AddHeaderLine("-----------------------------------");
            this.miTicket.AddHeaderLine("");
            //this.miTicket.AddHeaderLine("-----------------------------------");
            this.miTicket.AddHeaderLine("SOFTWARE:  DFPYME.");
            this.miTicket.AddHeaderLine("");
            this.EnviarImpresion();
        }

        public void ImprimirRboAbono()
        {
            this.EncabezadoEmpresa();
            this.miTicket.AddHeaderLine("Fecha : " + anticipo.Fecha.ToShortDateString() +
                                     "    Caja : " + NoCaja);
            this.miTicket.AddHeaderLine("Cajero(a)  :  " + this.Usuario);
            //this.miTicket.AddHeaderLine("===================================");
            this.miTicket.AddHeaderLine("-----------------------------------");
            this.miTicket.AddHeaderLine("COMPROBANTE DE INGRESO Nro " + anticipo.Numero);
            this.EncabezadoClienteRecibo();
            this.EncabezadoDescripcionRecibo();
            this.DetalleRecibido();
            this.miTicket.AddHeaderLine("");
            foreach (DataRow pRow in tPagos.Rows)
            {
                this.miTicket.AddHeaderLine("        " + pRow["nombre"].ToString() + " :" + UseObject.StringBuilderDetalleTotal
                                                             (UseObject.InsertSeparatorMil(pRow["valor"].ToString())));
            }
           /* foreach (var pago in this.PagosRbo)
            {
                this.miTicket.AddHeaderLine("        " + pago.NombreFormaPago + " :" + UseObject.StringBuilderDetalleTotal
                                                             (UseObject.InsertSeparatorMil(pago.Valor.ToString())));
            }*/
            this.miTicket.AddHeaderLine("");
            this.miTicket.AddHeaderLine("            SALDO :" + UseObject.FuncionEspacio(16 - saldoAbono.Length) + saldoAbono);
            this.miTicket.AddHeaderLine("-----------------------------------");
            this.miTicket.AddHeaderLine("");
            this.miTicket.AddHeaderLine("");
            this.miTicket.AddHeaderLine("Firma:");
            this.miTicket.AddHeaderLine("-----------------------------------");
            this.miTicket.AddHeaderLine("C.C. o NIT:");
            this.miTicket.AddHeaderLine("-----------------------------------");
            this.miTicket.AddHeaderLine("Fecha:");
            this.miTicket.AddHeaderLine("-----------------------------------");
            this.miTicket.AddHeaderLine("");
            //this.miTicket.AddHeaderLine("-----------------------------------");
            this.miTicket.AddHeaderLine("SOFTWARE:  DFPYME.");
            this.miTicket.AddHeaderLine("");
            this.EnviarImpresion();
        }


        public void ImprimirDevolucionVenta()
        {
            this.EncabezadoEmpresa();
            this.miTicket.AddHeaderLine("Fecha : " + this.Fecha.ToShortDateString() +
                                     "    Caja : " + this.NoCaja);
            this.miTicket.AddHeaderLine("Cajero(a)  :  " + this.Usuario);
            //this.miTicket.AddHeaderLine("===================================");
            this.miTicket.AddHeaderLine("-----------------------------------");
            this.miTicket.AddHeaderLine("COMPROBANTE DE DEVOLUCIÓN Nro " + this.Numero);
            this.EncabezadoClienteDevolucion();
            this.EncabezadoDescripcionDetalle();
            this.DetalleArticulos();

            this.miTicket.AddHeaderLine("-----------------------------------");
            this.miTicket.AddHeaderLine("");

            this.miTicket.AddHeaderLine("         TOTAL :" + UseObject.StringBuilderDetalleTotal(UseObject.InsertSeparatorMil(
                tDetalle.AsEnumerable().Sum(s => s.Field<int>("Total_")).ToString())));

            this.miTicket.AddHeaderLine("");
            this.miTicket.AddHeaderLine("-----------------------------------");
            this.miTicket.AddHeaderLine("");
            this.miTicket.AddHeaderLine("");
            this.miTicket.AddHeaderLine("Firma:");
            this.miTicket.AddHeaderLine("-----------------------------------");
            this.miTicket.AddHeaderLine("C.C. o NIT:");
            this.miTicket.AddHeaderLine("-----------------------------------");
            this.miTicket.AddHeaderLine("Fecha:");
            this.miTicket.AddHeaderLine("-----------------------------------");
            this.miTicket.AddHeaderLine("");
            //this.miTicket.AddHeaderLine("-----------------------------------");
            this.miTicket.AddHeaderLine("SOFTWARE:  DFPYME.");
            this.miTicket.AddHeaderLine("");
            this.EnviarImpresion();
        }
    }
}