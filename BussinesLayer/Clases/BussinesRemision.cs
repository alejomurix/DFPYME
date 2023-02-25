using System;
using System.Data;
using System.Linq;
using DataAccessLayer.Clases;
using DTO.Clases;
using System.Collections.Generic;
using Utilities;

namespace BussinesLayer.Clases
{
    public class BussinesRemision
    {
        private DaoRemision miDaoRemision;

        private bool RedondearPrecio2 { set; get; }

        public BussinesRemision()
        {
            this.miDaoRemision = new DaoRemision();
            try
            {
                this.RedondearPrecio2 = Convert.ToBoolean(AppConfiguracion.ValorSeccion("redondeo_precio_dos"));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Obtiene el Número consecutivo a se asignado en la Remisión.
        /// </summary>
        /// <returns></returns>
        public string ObtenerNumero()
        {
            return miDaoRemision.ObtenerNumero();
        }

        public void Ingresar(FacturaVenta remision)
        {
            miDaoRemision.Ingresar(remision);
        }

        public DataSet PrintRemision(string numero)
        {
            return miDaoRemision.PrintRemision(numero);
        }

        /// <summary>
        /// Obtiene el resultado de la consulta de Remisión por número.
        /// </summary>
        /// <param name="numero">Número de la Remisión a consultar.</param>
        /// <returns></returns>
        public DataTable ConsultaNumero(int numero)
        {
            return miDaoRemision.ConsultaNumero(numero);
        }

        public DataTable ConsultaCliente(string nit)
        {
            return miDaoRemision.ConsultaCliente(nit);
        }

        public DataTable ConsultaCliente(string nit, bool remision, int rowBase, int rowMax)
        {
            return miDaoRemision.ConsultaCliente(nit, remision, rowBase, rowMax);
        }

        public long GetRowsConsultaCliente(string nit, bool remision)
        {
            return miDaoRemision.GetRowsConsultaCliente(nit, remision);
        }

        public DataTable ConsultaEstado(bool remision, int rowBase, int rowMax)
        {
            return miDaoRemision.ConsultaEstado(remision, rowBase, rowMax);
        }

        public long GetRowsConsultaEstado(bool remision)
        {
            return miDaoRemision.GetRowsConsultaEstado(remision);
        }

        public DataTable ConsultaCliente(string nit, bool remision, DateTime fecha)
        {
            return miDaoRemision.ConsultaCliente(nit, remision, fecha);
        }

        public DataTable ConsultaEstado(bool remision, DateTime fecha)
        {
            return miDaoRemision.ConsultaEstado(remision, fecha);
        }

        public DataTable ConsultaCliente
            (string nit, bool remision, DateTime fecha, DateTime fecha1, int rowBase, int rowMax)
        {
            return miDaoRemision.ConsultaCliente(nit, remision, fecha, fecha1, rowBase, rowMax);
        }

        public long GetRowsConsultaCliente
            (string nit, bool remision, DateTime fecha, DateTime fecha1)
        {
            return miDaoRemision.GetRowsConsultaCliente(nit, remision, fecha, fecha1);
        }

        public DataTable consultaEstado
            (bool remision, DateTime fecha, DateTime fecha1, int rowBase, int rowMax)
        {
            return miDaoRemision.consultaEstado(remision, fecha, fecha1, rowBase, rowMax);
        }

        public long GetRowsConsultaEstado(bool remision, DateTime fecha, DateTime fecha1)
        {
            return miDaoRemision.GetRowsConsultaEstado(remision, fecha, fecha1);
        }

        public bool RemisionAnulada(int numero)
        {
            return miDaoRemision.RemisionAnulada(numero);
        }

        public void AnularRemision(int numero, bool carga)
        {
            miDaoRemision.AnularRemision(numero, carga);
        }

        public DataTable FormasPago(int numero)
        {
            return miDaoRemision.FormasPago(numero);
        }

        public DataTable ClienteDeRemsion(int numero)
        {
            return miDaoRemision.ClienteDeRemsion(numero);
        }

        public DataTable CarteraClientes(bool saldo, bool customer, string cliente)
        {
            var miDaoCliente = new DaoCliente();
            var miBussinesPago = new BussinesFormaPago();
            var miDaoDevolucion = new DaoDevolucion();
            var tabla = TablaCartera();
            var tClientes = new DataTable();

            if (customer)
            {
                tClientes = miDaoCliente.ConsultaClienteNit(cliente);
            }
            else
            {
                tClientes = miDaoCliente.ListadoDeClientes();
            }
            //tClientes = miDaoCliente.ListadoDeClientes();

            foreach (DataRow rCliente in tClientes.Rows)
            {
                var tRemisiones = miDaoRemision.ConsultaCliente(rCliente["nitcliente"].ToString());
                var valorFactura = 0.0;
                var pagosFactura = 0.0;
                var saldoFactura = 0.0;
                foreach (DataRow fRow in tRemisiones.Rows)
                {
                    valorFactura = ProductoRemision(Convert.ToInt32(fRow["numero"]), Convert.ToBoolean(fRow["aplica_descuento"])).
                                            AsEnumerable().Sum(s => s.Field<int>("Valor"));
                    pagosFactura = miBussinesPago.GetTotalPagoRemision(Convert.ToInt32(fRow["numero"]));
                    var saldoDevRemision = miDaoDevolucion.SaldoRemision(Convert.ToInt32(fRow["numero"]));
                    saldoFactura = valorFactura - (pagosFactura + saldoDevRemision);
                    if (saldoFactura > 0)
                    {
                        var row = tabla.NewRow();
                        row["Cedula"] = rCliente["nitcliente"].ToString();
                        row["Nombre"] = rCliente["nombrescliente"].ToString();
                        row["Factura"] = fRow["numero"].ToString();
                        row["Fecha"] = fRow["fecha"].ToString();
                        row["Limite"] = fRow["fechalimite"].ToString();
                        row["Valor"] = valorFactura;
                        row["Abonos"] = pagosFactura;
                        row["Saldo"] = saldoFactura;
                        tabla.Rows.Add(row);
                    }
                }
            }
            if (!saldo)
            {
                foreach (DataRow rCliente in tClientes.Rows)
                {
                    var query = tabla.AsEnumerable().Where(d => d.Field<string>("Cedula").Equals(rCliente["nitcliente"].ToString()));
                    if (query.ToArray().Length.Equals(0))
                    {
                        var row = tabla.NewRow();
                        row["Cedula"] = rCliente["nitcliente"].ToString();
                        row["Nombre"] = rCliente["nombrescliente"].ToString();
                        row["Factura"] = "";
                        row["Fecha"] = DateTime.Now;
                        row["Limite"] = DateTime.Now;
                        row["Valor"] = 0;
                        row["Abonos"] = 0;
                        row["Saldo"] = 0;
                        tabla.Rows.Add(row);
                    }
                }
            }
            if (tabla.Rows.Count != 0)
            {
                IEnumerable<DataRow> rQuery = from data in tabla.AsEnumerable()
                                              orderby data.Field<string>("Nombre") ascending
                                              select data;
                return rQuery.CopyToDataTable<DataRow>();
            }
            else
            {
                return tabla;
            }
            //return tabla;
        }

        // update cartera: 17-02-2023
        public List<FacturaVenta> Cartera(FacturaVenta remision)
        {
            return miDaoRemision.Cartera(remision);
        }

        public long SaldoDeCliente(string cliente)
        {
            var miBussinesPago = new BussinesFormaPago();
            var miDaoDevolucion = new DaoDevolucion();
            int totalFact = 0;
            int pagosFact = 0;
            int saldoDev = 0;
            int saldo = 0;
            int saldoTotal = 0;
            var remisiones = ConsultaCliente(cliente);
            foreach (DataRow rRow in remisiones.Rows)
            {
                totalFact = ProductoRemision(Convert.ToInt32(rRow["numero"]), Convert.ToBoolean(rRow["aplica_descuento"])).
                                             AsEnumerable().Sum(s => s.Field<int>("Valor"));
                pagosFact = miBussinesPago.GetTotalPagoRemision(Convert.ToInt32(rRow["numero"]));
                saldoDev = miDaoDevolucion.SaldoRemision(Convert.ToInt32(rRow["numero"]));
                if (totalFact > (pagosFact + saldoDev))
                {
                    saldo = totalFact - (pagosFact + saldoDev);
                    saldoTotal += saldo;
                }
            }
            return saldoTotal;
        }

        public DataTable ResumenCarteraClientes()
        {
            var miDaoCliente = new DaoCliente();
            var tabla = TablaCartera();
            var tClientes = miDaoCliente.ListadoDeClientes();
            foreach (DataRow rCliente in tClientes.Rows)
            {
                if(SaldoDeCliente(rCliente["nitcliente"].ToString()) > 0)
                {
                    var row = tabla.NewRow();
                    row["Cedula"] = rCliente["nitcliente"];
                    row["Nombre"] = rCliente["nombrescliente"];
                    row["Saldo"] = SaldoDeCliente(rCliente["nitcliente"].ToString());
                    tabla.Rows.Add(row);
                }
            }
            return tabla;
        }



        public void NewConection()
        {
            this.miDaoRemision.NewConection();
        }

        public DataTable ResumenIvaCompras(DateTime fecha, DateTime fecha2)
        {
            return this.miDaoRemision.ResumenIvaCompras(fecha, fecha2);
        }

        public DataTable ResumenIvaVentas(DateTime fecha, DateTime fecha2)
        {
            return this.miDaoRemision.ResumenIvaVentas(fecha, fecha2);
        }

        public List<Impuesto> ResumenDevolucion(DateTime fecha, DateTime fecha2)
        {
            return this.miDaoRemision.ResumenDevolucion(fecha, fecha2);
        }

        public double TotalCostoVenta(DateTime fecha, DateTime fecha2)
        {
            return this.miDaoRemision.TotalCostoVenta(fecha, fecha2);
        }

        // update data of new columns in remision
        public void UpdateTotalCancel(DateTime fecha, DateTime fecha1)
        {
            var miBussinesPago = new BussinesFormaPago();
            var miDaoDevolucion = new DaoDevolucion();

            FacturaVenta remision;
            foreach (DataRow row in miDaoRemision.consultaEstado(true, fecha, fecha1, 0, 10000000).Rows)
            {
                remision = new FacturaVenta { Numero = row["numero"].ToString() };

                remision.Total = ProductoRemision(Convert.ToInt32(row["numero"]), Convert.ToBoolean(row["aplica_descuento"]))
                    .AsEnumerable().Sum(s => s.Field<int>("Valor"));
                remision.Pagos = miBussinesPago.GetTotalPagoRemision(Convert.ToInt32(row["numero"]));
                remision.Saldo = miDaoDevolucion.SaldoRemision(Convert.ToInt32(row["numero"]));
                remision.Saldo = Convert.ToInt32(remision.Total) - (remision.Pagos + remision.Saldo);
                
                if (remision.Saldo == 0)
                {
                    remision.Cancel = true;
                }
                miDaoRemision.UpdateTotalCancel(remision);
            }

            /*valorFactura = ProductoRemision(Convert.ToInt32(fRow["numero"]), Convert.ToBoolean(fRow["aplica_descuento"])).
                                            AsEnumerable().Sum(s => s.Field<int>("Valor"));
                    pagosFactura = miBussinesPago.GetTotalPagoRemision(Convert.ToInt32(fRow["numero"]));
                    var saldoDevRemision = miDaoDevolucion.SaldoRemision(Convert.ToInt32(fRow["numero"]));
                    saldoFactura = valorFactura - (pagosFactura + saldoDevRemision);*/
            //public DataTable consultaEstado
            //(bool remision, DateTime fecha, DateTime fecha1, int rowBase, int rowMax)
        }

        //PRODUCTO REMISION

        public DataSet PrintProducto(int numero, bool descuento)
        {
            return miDaoRemision.PrintProducto(numero, descuento);
        }

        public DataTable ProductoRemision(int numero, bool descuento)
        {
            var miTabla = CrearDataTable();
            var tabla = miDaoRemision.ProductoRemision(numero);
            var color = new ElColor();
            foreach (DataRow row in tabla.Rows)
            {
                var row_ = miTabla.NewRow();
                row_["Id"] = row["id"];
                row_["Codigo"] = row["codigo"];
                row_["Articulo"] = row["producto"];
                row_["Unidad"] = row["unidad"];
                row_["IdMedida"] = row["idmedida"];
                row_["Medida"] = row["medida"];
                row_["IdColor"] = row["idcolor"];
                color.MapaBits = row["color"].ToString();
                row_["Color"] = color.ImagenBit; //row["color"];
                row_["IdMarca"] = row["idmarca"];
                row_["Cantidad"] = row["cantidad"];
                row_["ValorUnitario"] = row["valor"];
                if (descuento)
                {
                    row_["Descuento"] = row["descto"].ToString() + "%";
                    row_["ValorMenosDescto"] = Math.Round(
                        ( Convert.ToDouble(row["valor"]) -
                        (Convert.ToDouble(row["valor"]) * Convert.ToDouble(row["descto"]) / 100)), 1);
                }
                else
                {
                    row_["Descuento"] = row["recargo"].ToString() + "%";
                    row_["ValorMenosDescto"] = Math.Round(
                        (Convert.ToDouble(row["valor"]) +
                        (Convert.ToDouble(row["valor"]) * Convert.ToDouble(row["recargo"]) / 100)), 1);
                }
                row_["Iva"] = row["iva"].ToString() + "%";

                double vIva = Math.Round(
                    (Convert.ToDouble(row_["ValorMenosDescto"]) * Convert.ToDouble(row["Iva"]) / 100), 1);

                row_["ValorIva"] = vIva;
                row_["Ico"] = row["impoconsumo"];

                if (this.RedondearPrecio2)
                {
                    row_["TotalMasIva"] = UseObject.Aproximar(Convert.ToInt32(Convert.ToDouble(row_["ValorMenosDescto"]) + vIva + Convert.ToInt32(row["impoconsumo"])),
                        Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio")));
                }
                else
                {
                    row_["TotalMasIva"] = Convert.ToInt32(Convert.ToDouble(row_["ValorMenosDescto"]) + vIva + Convert.ToInt32(row["impoconsumo"]));
                }

                //row_["TotalMasIva"] = UseObject.Aproximar(Convert.ToInt32(Convert.ToDouble(row_["ValorMenosDescto"]) + vIva),
                                                        //  Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio")));

                /*
                row_["ValorIva"] = Convert.ToInt32(
                    Convert.ToDouble(row_["ValorMenosDescto"]) * Convert.ToDouble(row["iva"]) / 100);
                row_["TotalMasIva"] = Convert.ToInt32(
                     Convert.ToDouble(row_["ValorMenosDescto"]) +
                    (Convert.ToDouble(row_["ValorMenosDescto"]) * Convert.ToDouble(row["iva"]) / 100));
                */
                
                row_["Valor"] = Convert.ToInt32(
                    Convert.ToDouble(row_["TotalMasIva"]) * Convert.ToDouble(row["cantidad"]));

                // ***************    OJO
                //row_["Ico"] = 0;
                // ***********************

                miTabla.Rows.Add(row_);
            }
            tabla.Clear();
            tabla = null;
            return miTabla;
        }

        public List<Utilities.DetalleProducto> Detalles(int numero, bool descuento)
        {
            var detalles = new List<Utilities.DetalleProducto>();
            var tabla = ProductoRemision(numero, descuento);
            foreach (DataRow row in tabla.Rows)
            {
                var detalle = new Utilities.DetalleProducto();
                detalle.Codigo = row["Codigo"].ToString();
                detalle.Medida = Convert.ToInt32(row["IdMedida"]);
                detalle.Color = Convert.ToInt32(row["IdColor"]);
                detalle.Cantidad = Convert.ToDouble(row["Cantidad"]);
                detalles.Add(detalle);
            }
            tabla = null;
            return detalles;
        }

        public bool ProductoDeRemision(FacturaVenta factura, Utilities.DetalleProducto dProducto)
        {
            var tabla = ProductoRemision(Convert.ToInt32(factura.Numero), factura.AplicaDescuento);
            var qRow = (from data in tabla.AsEnumerable()
                        where data.Field<string>("Codigo") == dProducto.Codigo
                        && data.Field<int>("IdMedida") == dProducto.Medida
                        && data.Field<int>("IdColor") == dProducto.Color
                        select data);
            if (qRow.ToArray().Length != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        // Remision Proveedor

        public FacturaProveedor ConsultaProveedor(int id)
        {
            return miDaoRemision.ConsultaProveedor(id);
        }

        public DataTable ConsultaProveedor(string numero)
        {
            return miDaoRemision.ConsultaProveedor(numero);
        }

        public DataTable ConsultaProveedorNit(string nit, int rowBase, int rowMax)
        {
            return miDaoRemision.ConsultaProveedorNit(nit, rowBase, rowMax);
        }

        public long CountConsultaProveedor(string nit)
        {
            return miDaoRemision.CountConsultaProveedor(nit);
        }

        public DataTable ConsultaProveedor(int codigo, int rowBase, int rowMax)
        {
            return miDaoRemision.ConsultaProveedor(codigo, rowBase, rowMax);
        }

        public long CountConsultaProveedor(int codigo)
        {
            return miDaoRemision.CountConsultaProveedor(codigo);
        }

        public DataTable ConsultaRemisionProveedor(int codigo)
        {
            return miDaoRemision.ConsultaRemisionProveedor(codigo);
        }

        public DataTable ConsultaRemisionProveedor(string nit)
        {
            return miDaoRemision.ConsultaRemisionProveedor(nit);
        }

        public DataTable ConsultaProveedor(DateTime fecha, int rowBase, int rowMax)
        {
            return miDaoRemision.ConsultaProveedor(fecha, rowBase, rowMax);
        }

        public long CountConsultaProveedor(DateTime fecha)
        {
            return miDaoRemision.CountConsultaProveedor(fecha);
        }

        public DataTable ConsultaProveedor(DateTime fecha, DateTime fecha2, int rowBase, int rowMax)
        {
            return miDaoRemision.ConsultaProveedor(fecha, fecha2, rowBase, rowMax);
        }

        public long CountConsultaProveedor(DateTime fecha, DateTime fecha2)
        {
            return miDaoRemision.CountConsultaProveedor(fecha, fecha2);
        }

        public DataTable ConsultaProveedor(int codigo, DateTime fecha, int rowBase, int rowMax)
        {
            return miDaoRemision.ConsultaProveedor(codigo, fecha, rowBase, rowMax);
        }

        public long CountConsultaProveedor(int codigo, DateTime fecha)
        {
            return miDaoRemision.CountConsultaProveedor(codigo, fecha);
        }

        public DataTable ConsultaProveedor
            (int codigo, DateTime fecha, DateTime fecha2, int rowBase, int rowMax)
        {
            return miDaoRemision.ConsultaProveedor(codigo, fecha, fecha2, rowBase, rowMax);
        }

        public long CountConsultaProveedor(int codigo, DateTime fecha, DateTime fecha2)
        {
            return miDaoRemision.CountConsultaProveedor(codigo, fecha, fecha2);
        }

        public DataTable ConsultaProveedor
            (string nit, DateTime fecha, int rowBase, int rowMax)
        {
            return miDaoRemision.ConsultaProveedor(nit, fecha, rowBase, rowMax);
        }

        public long CountConsultaProveedor(string nit, DateTime fecha)
        {
            return miDaoRemision.CountConsultaProveedor(nit, fecha);
        }

        public DataTable ConsultaProveedor
            (string nit, DateTime fecha, DateTime fecha2, int rowBase, int rowMax)
        {
            return miDaoRemision.ConsultaProveedor(nit, fecha, fecha2, rowBase, rowMax);
        }

        public long CountConsultaProveedor(string nit, DateTime fecha, DateTime fecha2)
        {
            return miDaoRemision.CountConsultaProveedor(nit, fecha, fecha2);
        }

        public void EditarRemisionProveedor(FacturaProveedor remision)
        {
            miDaoRemision.EditarRemisionProveedor(remision);
        }

        public void FacturarRemisionProveedor(int id, bool facturada)
        {
            miDaoRemision.FacturarRemisionProveedor(id, facturada);
        }

        public DataTable CarteraProveedores(bool saldo_, bool provider, int proveedor)
        {
            var miDaoProveedor = new DaoProveedor();
            var miBussinesPago = new BussinesFormaPago();
            var tabla = TablaCartera();

            var tProveedores = new DataTable();
            if (provider)
            {
                tProveedores = miDaoProveedor.Proveedores(proveedor);
            }
            else
            {
                tProveedores = miDaoProveedor.Proveedores();
            }
            foreach (DataRow pRow in tProveedores.Rows)
            {
                var remisiones = ConsultaRemisionProveedor(Convert.ToInt32(pRow["Codigo"]));
                foreach (DataRow Rrow in remisiones.Rows)
                {
                    var valorRemision = CalcularTotalFactura(ConsultaProductoProveedor(Convert.ToInt32(Rrow["Id"])));
                    //var saldoDev =   IMPLEMENTAR DEVOLUCION A REMISION
                    var pago = miBussinesPago.TotalPagosRemisionProveedor(Convert.ToInt32(Rrow["Id"]));
                    var saldo = valorRemision - pago;
                    if (saldo > 0)
                    {
                        var row = tabla.NewRow();
                        row["Codigo"] = pRow["Codigo"];
                        row["Cedula"] = pRow["Nit"];
                        row["Nombre"] = pRow["Nombre"];
                        row["Factura"] = Rrow["Numero"];
                        row["Fecha"] = Rrow["Ingreso"];
                        row["Limite"] = Rrow["Limite"];
                        row["Valor"] = valorRemision;
                        row["Abonos"] = pago;
                        row["Saldo"] = saldo;
                        tabla.Rows.Add(row);
                    }
                }
            }
            if (!saldo_)
            {
                foreach (DataRow pRow in tProveedores.Rows)
                {
                    var query = tabla.AsEnumerable().Where(d => d.Field<int>("Codigo").Equals(Convert.ToInt32(pRow["Codigo"])));
                    if (query.ToArray().Length.Equals(0))
                    {
                        var row = tabla.NewRow();
                        row["Codigo"] = pRow["Codigo"];
                        row["Cedula"] = pRow["Nit"];
                        row["Nombre"] = pRow["Nombre"];
                        row["Factura"] = "";
                        row["Fecha"] = DateTime.Now;
                        row["Limite"] = DateTime.Now;
                        row["Valor"] = 0;
                        row["Abonos"] = 0;
                        row["Saldo"] = 0;
                        tabla.Rows.Add(row);
                    }
                }
            }
            if (tabla.Rows.Count != 0)
            {
                IEnumerable<DataRow> rQuery = from data in tabla.AsEnumerable()
                                              orderby data.Field<string>("Nombre") ascending
                                              select data;
                return rQuery.CopyToDataTable<DataRow>();
            }
            else
            {
                return tabla;
            }
        }

        private int CalcularTotalFactura(DataTable tabla)
        {
            var subTotal = Convert.ToInt32(
                tabla.AsEnumerable().Sum(s => (s.Field<int>("Valor") * s.Field<double>("Cantidad"))));
            int valorDescuento = 0;
            int valorIva = 0;
            foreach (DataRow row in tabla.Rows)
            {
                valorDescuento += Convert.ToInt32((Convert.ToDouble(row["Valor"]) *
                                                   Utilities.UseObject.RemoveCharacter(row["Descuento"].ToString(), '%') / 100) *
                                                   Convert.ToDouble(row["Cantidad"]));
                valorIva = Convert.ToInt32(valorIva + Convert.ToDouble(row["ValorIva"]));
            }
            return (subTotal - valorDescuento) + valorIva;
        }

        public DataTable ResumenCarteraProveedores()
        {
            var miDaoProveedor = new DaoProveedor();
            var tabla = TablaCartera();
            var proveedores = miDaoProveedor.Proveedores();
            foreach (DataRow rProveedor in proveedores.Rows)
            {
                var saldo = SaldoDeProveedor(rProveedor["Nit"].ToString());
                if (saldo > 0)
                {
                    var row = tabla.NewRow();
                    row["Codigo"] = rProveedor["Codigo"];
                    row["Cedula"] = rProveedor["Nit"];
                    row["Nombre"] = rProveedor["Nombre"];
                    row["Saldo"] = saldo;
                    tabla.Rows.Add(row);
                }
            }
            return tabla;
        }

        public long SaldoDeProveedor(string nit)
        {
            var miBussinesPago = new BussinesFormaPago();
            var miDaoDevolucion = new DaoDevolucion();
            int totalFact = 0;
            int pagosFact = 0;
            int saldoDev = 0;
            int saldo = 0;
            int saldoTotal = 0;
            var remisiones = ConsultaRemisionProveedor(nit);
            foreach (DataRow rRow in remisiones.Rows)
            {
                totalFact = CalcularTotalFactura(ConsultaProductoProveedor(Convert.ToInt32(rRow["Id"])));
                pagosFact = miBussinesPago.TotalPagosRemisionProveedor(Convert.ToInt32(rRow["Id"]));
                saldoDev = 0;  //  IMPLEMENTAR SALDO DEVOLUCION REMISION DE PROVEEDOR
                if (totalFact > (pagosFact + saldoDev))
                {
                    saldo = totalFact - (pagosFact + saldoDev);
                    saldoTotal += saldo;
                }
            }
            return saldoTotal;
        }


        //Producto Remision

        public DataTable ConsultaProductoProveedor(int id)
        {
            var tabla = CrearDataTable();
            var productos = miDaoRemision.ConsultaProductoProveedor(id);
            foreach (DataRow row in productos.Rows)
            {
                var color = new ElColor();
                color.MapaBits = Convert.ToString(row["Color"]);
                var row_ = tabla.NewRow();
                row_["Id"] = row["Id"];
                row_["IdRemision"] = row["IdRemision"];
                row_["Codigo"] = row["Codigo"];
                row_["Articulo"] = row["Articulo"];
                row_["Cantidad"] = row["Cantidad"];
                row_["Unidad"] = row["Unidad"];
                row_["IdMedida"] = row["IdMedida"];
                row_["Medida"] = row["Medida"];
                row_["IdColor"] = row["IdColor"];
                row_["Color"] = color.ImagenBit;
                row_["IdLote"] = row["IdLote"];
                row_["Lote"] = row["Lote"];
                row_["Iva"] = row["Iva"].ToString() + "%";
                row_["Valor"] = row["Valor"];

                row_["Descuento"] = row["Descuento"].ToString() + "%";

                row_["ValorMenosDescto"] = Math.Round((Convert.ToDouble(row["Valor"]) -
                    (Convert.ToDouble(row["Valor"]) * Convert.ToDouble(row["Descuento"]) / 100)), 2);

                row_["ValorIva"] = Math.Round((Convert.ToDouble(row_["ValorMenosDescto"]) * Convert.ToDouble(row["Iva"]) / 100), 2);

                row_["TotalMasIva"] = Convert.ToDouble(row_["ValorMenosDescto"]) + Convert.ToDouble(row_["ValorIva"]);

                row_["ValorIva"] = Math.Round(
                    ((Convert.ToDouble(row_["ValorMenosDescto"]) * Convert.ToDouble(row["Iva"]) / 100) *
                      Convert.ToDouble(row["Cantidad"])), 2);

                row_["Total"] = Math.Round((Convert.ToDouble(row_["TotalMasIva"]) * Convert.ToDouble(row["Cantidad"])), 2);

                tabla.Rows.Add(row_);
            }
            productos.Clear();
            productos = null;
            return tabla;


            //return miDaoRemision.ConsultaProductoProveedor(id);
        }


        public void EditarProductoRemisionProveedor(ProductoFacturaProveedor producto)
        {
            miDaoRemision.EditarProductoRemisionProveedor(producto);
        }

        public void EditarProductoRemisionProveedor(ProductoFacturaProveedor producto, bool actInventario)
        {
            miDaoRemision.EditarProductoRemisionProveedor(producto, actInventario);
        }

        public void EliminarProductoRemisionProveedor(int id)
        {
            miDaoRemision.EliminarProductoRemisionProveedor(id);
        }

        //End Remision Proveedor

        /// <summary>
        /// Crea las respectivas columnas del DataTable para ProductoRemision.
        /// </summary>
        private DataTable CrearDataTable()
        {
            var miTabla = new DataTable();
            miTabla.Columns.Add(new DataColumn("Id", typeof(int)));
            miTabla.Columns.Add(new DataColumn("IdRemision", typeof(int)));
            miTabla.Columns.Add(new DataColumn("Codigo", typeof(string)));
            miTabla.Columns.Add(new DataColumn("Articulo", typeof(string)));
            miTabla.Columns.Add(new DataColumn("Cantidad", typeof(double)));
            miTabla.Columns.Add(new DataColumn("Unidad", typeof(string)));
            miTabla.Columns.Add(new DataColumn("IdMedida", typeof(int)));
            miTabla.Columns.Add(new DataColumn("Medida", typeof(string)));
            miTabla.Columns.Add(new DataColumn("IdColor", typeof(int)));
            miTabla.Columns.Add(new DataColumn("Color", typeof(System.Drawing.Image)));
            miTabla.Columns.Add(new DataColumn("IdMarca", typeof(int)));
            miTabla.Columns.Add(new DataColumn("IdLote", typeof(int)));
            miTabla.Columns.Add(new DataColumn("Lote", typeof(string)));
            miTabla.Columns.Add(new DataColumn("Iva", typeof(string)));
            miTabla.Columns.Add(new DataColumn("Valor", typeof(int)));
            miTabla.Columns.Add(new DataColumn("Total", typeof(double)));
            miTabla.Columns.Add(new DataColumn("ValorIva", typeof(double)));
            miTabla.Columns.Add(new DataColumn("TotalMasIva", typeof(double)));
            miTabla.Columns.Add(new DataColumn("ValorUnitario", typeof(double)));
            miTabla.Columns.Add(new DataColumn("Descuento", typeof(string)));
            miTabla.Columns.Add(new DataColumn("ValorMenosDescto", typeof(double)));

            miTabla.Columns.Add(new DataColumn("Ico", typeof(double)));
            return miTabla;
        }

        private DataTable TablaCartera()
        {
            var tabla = new DataTable();
            tabla.TableName = "Cartera";
            tabla.Columns.Add(new DataColumn("Codigo", typeof(int)));
            tabla.Columns.Add(new DataColumn("Cedula", typeof(string)));
            tabla.Columns.Add(new DataColumn("Nombre", typeof(string)));
            tabla.Columns.Add(new DataColumn("Factura", typeof(string)));
            tabla.Columns.Add(new DataColumn("Fecha", typeof(DateTime)));
            tabla.Columns.Add(new DataColumn("Limite", typeof(DateTime)));
            tabla.Columns.Add(new DataColumn("Valor", typeof(int)));
            tabla.Columns.Add(new DataColumn("Abonos", typeof(int)));
            tabla.Columns.Add(new DataColumn("Saldo", typeof(int)));
            return tabla;
        }



        //  Funciones para el ajuste de valores de IVA

        public void FechasyTotalesVentas(DateTime fecha, DateTime fecha2)
        {
            this.miDaoRemision.FechasyTotalesVentas(fecha, fecha2);
        }

        public void AjusteIvaVenta(DateTime fechaStop, DateTime fechaMonto, int monto)
        {
            this.miDaoRemision.AjusteIvaVenta(fechaStop, fechaMonto, monto);
        }

        //  Fin funciones para el ajuste de valores de IVA


        public void AjusteDeInventario()
        {
            this.miDaoRemision.AjusteDeInventario();
        }



        //  Funciones para reporte diario de ventas por remision

        public List<FacturaVenta> VentasRemision(DateTime fecha)
        {
            return miDaoRemision.VentasRemision(fecha);
        }

        // Funciones para reporte diario de ventas por remision
    }
}