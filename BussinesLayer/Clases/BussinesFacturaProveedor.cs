using System;
using System.Data;
using System.Linq;
using DataAccessLayer.Clases;
using DTO.Clases;
using System.Collections.Generic;
using Utilities;

namespace BussinesLayer.Clases
{
    /// <summary>
    /// Representa una clase para la logica de negocio de FacturaProveedor.
    /// </summary>
    public class BussinesFacturaProveedor
    {
        /// <summary>
        /// Proporciona acceso a la capa de datos de FacturaProveedor.
        /// </summary>
        private DaoFacturaProveedor miDaoFacturaProveedor;

        /// <summary>
        /// Proporciona acceso a la capa de datos de ProductoFacturaProveedor.
        /// </summary>
        private DaoProductoFacturaProveedor miDaoProductoFactura;

        private DaoRetencion miDaoRetencion;

        /// <summary>
        /// Inicializa una nueva instancia de la clase BussinesFacturaProveedor.
        /// </summary>
        public BussinesFacturaProveedor()
        {
            miDaoFacturaProveedor = new DaoFacturaProveedor();
            miDaoProductoFactura = new DaoProductoFacturaProveedor();
            miDaoRetencion = new DaoRetencion();
        }

        /// <summary>
        /// Obtiene el consecutivo del número del Lote.
        /// </summary>
        /// <returns></returns>
        public string ObtenerNumeroLote()
        {
            return miDaoFacturaProveedor.ObtenerNumeroLote();
        }

        /// <summary>
        /// Actualiza el registro consecutivo del lote.
        /// </summary>
        /// <param name="lote">Número de lote a actualizar.</param>
        public void ActualizarLote(int lote)
        {
            miDaoFacturaProveedor.ActualizarLote(lote);
        }

        public bool ExisteNumeroFactura(int codProveedor, string numero)
        {
            return miDaoProductoFactura.ExisteNumeroFactura(codProveedor, numero);
        }

        /// <summary>
        /// Ingresa toda la información necesaria del registro de Factura de Proveedor.
        /// </summary>
        /// <param name="miFactura">Factura a ingresar.</param>
        public int IngresarFactura(FacturaProveedor miFactura, bool esFactura, bool retencion)
        {
            return miDaoFacturaProveedor.IngresarFactura(miFactura, esFactura, retencion);
        }

        public bool EsFacturaVenta(int idFactura)
        {
            return miDaoFacturaProveedor.EsFacturaVenta(idFactura);
        }

        /// <summary>
        /// Obtiene los registros de la consulta de una Factura de Proveedor.
        /// </summary>
        /// <param name="id">Número de identificación unico de la Factura.</param>
        /// <returns></returns>
        public FacturaProveedor ConsultaFacturaProveedor(int id)
        {
            return miDaoFacturaProveedor.ConsultaFacturaProveedor(id);
        }

        public DataTable Consulta(int registroBase, int registroMax)
        {
            return miDaoFacturaProveedor.Consulta(registroBase, registroMax);
        }

        public long GetRowsConsulta()
        {
            return miDaoFacturaProveedor.GetRowsConsulta();
        }

        /// <summary>
        /// Obtiene los registros de la consulta de una Factura de Proveedor.
        /// </summary>
        /// <param name="numero">Número de la Factura a consultar.</param>
        /// <param name="activa">Indica si solo se recupera registros activos.</param>
        /// <returns></returns>
        public DataTable ConsultaFacturaProveedor(string numero, bool activa)
        {
            return miDaoFacturaProveedor.ConsultaFacturaProveedor(numero, activa);
        }

        /// <summary>
        /// Obtiene los registros de la consulta de una Factura de Proveedor.
        /// </summary>
        /// <param name="codigo">Codigo del Proveedor a consultar.</param>
        /// <param name="activa">Indica si solo se recupera registros activos.</param>
        /// <param name="registroBase">Registro base para la consulta.</param>
        /// <param name="registroMax">Número de registros a recuperar.</param>
        /// <returns></returns>
        public DataTable ConsultaFacturaProveedor(int codigo, bool activa, int registroBase, int registroMax)
        {
            return miDaoFacturaProveedor.ConsultaFacturaProveedor(codigo, activa, registroBase, registroMax);
        }

        /// <summary>
        /// Obtiene el total de registros de una consulta de Factura de Proveedor.
        /// </summary>
        /// <param name="codigo">Codigo del Proveedor a consultar.</param>
        /// <param name="activa">Indica si solo se recupera registros activos.</param>
        /// <returns></returns>
        public long GetRowsConsultaFacturaProveedor(int codigo, bool activa)
        {
            return miDaoFacturaProveedor.GetRowsConsultaFacturaProveedor(codigo, activa);
        }

        /// <summary>
        /// Obtiene los registros de la consulta de una Factura de Proveedor.
        /// </summary>
        /// <param name="fecha">Fecha con la cual se compara la fecha con la que ingreso la Factura.</param>
        /// <param name="activa">Indica si solo se recupera registros activos.</param>
        /// <param name="registroBase">Registro base para la consulta.</param>
        /// <param name="registroMax">Número de registros a recuperar.</param>
        /// <returns></returns>
        public DataTable ConsultaFacturaProveedor
            (DateTime fecha, bool activa, int registroBase, int registroMax)
        {
            return miDaoFacturaProveedor.ConsultaFacturaProveedor(fecha, activa, registroBase, registroMax);
        }

        /// <summary>
        /// Obtiene el total de registros de una consulta de Factura de Proveedor.
        /// </summary>
        /// <param name="fecha">Fecha con la cual se compara la fecha con la que ingreso la Factura.</param>
        /// <param name="activa">Indica si solo se recupera registros activos.</param>
        /// <returns></returns>
        public long GetRowsConsultaFacturaProveedor(DateTime fecha, bool activa)
        {
            return miDaoFacturaProveedor.GetRowsConsultaFacturaProveedor(fecha, activa);
        }

        /// <summary>
        /// Obtiene los registros de la consulta de una Factura de Proveedor.
        /// </summary>
        /// <param name="codigo">Codigo del Proveedor a consultar.</param>
        /// <param name="fecha">Fecha con la cual se compara la fecha con la que ingreso la Factura.</param>
        /// <param name="activa">Indica si solo se recupera registros activos.</param>
        /// <returns></returns>
        public DataTable ConsultaFacturaProveedor(int codigo, DateTime fecha, bool activa)
        {
            return miDaoFacturaProveedor.ConsultaFacturaProveedor(codigo, fecha, activa);
        }

        /// <summary>
        /// Obtiene los registros de la consulta de una Factura de Proveedor.
        /// </summary>
        /// <param name="fecha1">Primer fecha que proporciona el periodo.</param>
        /// <param name="fecha2">Segunda fecha que proporciona el periodo.</param>
        /// <param name="activa">Indica si solo se recupera registros activos.</param>
        /// <param name="registroBase">Registro base para la consulta.</param>
        /// <param name="registroMax">Número de registros a recuperar.</param>
        /// <returns></returns>
        public DataTable ConsultaFacturaProveedor
            (DateTime fecha1, DateTime fecha2, bool activa, int registroBase, int registroMax)
        {
            return miDaoFacturaProveedor.ConsultaFacturaProveedor
                (fecha1, fecha2, activa, registroBase, registroMax);
        }

        /// <summary>
        /// Obtiene el total de registros de una consulta de Factura de Proveedor.
        /// </summary>
        /// <param name="fecha1">Primer fecha que proporciona el periodo.</param>
        /// <param name="fecha2">Segunda fecha que proporciona el periodo.</param>
        /// <param name="activa">Indica si solo se recupera registros activos.</param>
        /// <returns></returns>
        public long GetRowsConsultaFacturaProveedor(DateTime fecha1, DateTime fecha2, bool activa)
        {
            return miDaoFacturaProveedor.GetRowsConsultaFacturaProveedor(fecha1, fecha2, activa);
        }

        /// <summary>
        /// Obtiene los registros de la consulta de una Factura de Proveedor.
        /// </summary>
        /// <param name="codigo">Codigo del Proveedor a consultar.</param>
        /// <param name="fecha1">Primer fecha que proporciona el periodo.</param>
        /// <param name="fecha2">Segunda fecha que proporciona el periodo.</param>
        /// <param name="activa">Indica si solo se recupera registros activos.</param>
        /// <param name="registroBase">Registro base para la consulta.</param>
        /// <param name="registroMax">Número de registros a recuperar.</param>
        /// <returns></returns>
        public DataTable ConsultaFacturaProveedor
            (int codigo, DateTime fecha1, DateTime fecha2, bool activa, int registroBase, int registroMax)
        {
            return miDaoFacturaProveedor.ConsultaFacturaProveedor
                (codigo, fecha1, fecha2, activa, registroBase, registroMax);
        }

        /// <summary>
        /// Obtiene el total de registros de una consulta de Factura de Proveedor.
        /// </summary>
        /// <param name="codigo">Codigo del Proveedor a consultar.</param>
        /// <param name="fecha1">Primer fecha que proporciona el periodo.</param>
        /// <param name="fecha2">Segunda fecha que proporciona el periodo.</param>
        /// <param name="activa">Indica si solo se recupera registros activos.</param>
        /// <returns></returns>
        public long GetRowsConsultaFacturaProveedor
            (int codigo, DateTime fecha1, DateTime fecha2, bool activa)
        {
            return miDaoFacturaProveedor.GetRowsConsultaFacturaProveedor
                (codigo, fecha1, fecha2, activa);
        }

        public double ConsultaAjuste(int id)
        {
            return miDaoFacturaProveedor.ConsultaAjuste(id);
        }

        /// <summary>
        /// Obtiene los registros de los producto relacionado a una Factura de Proveedor.
        /// </summary>
        /// <param name="id">Id de la Factura consultada.</param>
        /// <returns></returns>
        public DataTable ConsultaProductoFacturaProveedor(int id)
        {
            var miTabla = CrearDataTable();
            var tabla = miDaoFacturaProveedor.ConsultaProductoFacturaProveedor(id);
            foreach (DataRow row in tabla.Rows)
            {
                var color = new ElColor();
                color.MapaBits = Convert.ToString(row["Color"]);
                var row_ = miTabla.NewRow();
                row_["Id"] = row["Id"];
                row_["Numero"] = row["Numero"];
                row_["Codigo"] = row["Codigo"];
                row_["Articulo"] = row["Articulo"];
                row_["Cantidad"] = row["Cantidad"];
                row_["Unidad"] = row["Unidad"];
                row_["IdMedida"] = row["IdMedida"];
                row_["Medida"] = row["Medida"];
                row_["IdColor"] = row["IdColor"];
                row_["Color"] = color.ImagenBit;
                //id_tipo_inventario
                row_["IdTipoInventario"] = row["id_tipo_inventario"];
                row_["IdLote"] = row["IdLote"];
                row_["Lote"] = row["Lote"];
                row_["Iva"] = row["Iva"].ToString() + "%";
                row_["PIva"] = row["Iva"];
                row_["Valor"] = row["Valor"];
                row_["Impoconsumo"] = row["impoconsumo"];

                var data = row_["Codigo"].ToString();
               /* if (data == "3102")
                {
                    var j_ = data;
                }*/
                //data = row_["Cantidad"].ToString();
                //data = row_["Valor"].ToString();


                row_["Descuento"] = row["Descuento"].ToString() + "%";
                //data = row_["Descuento"].ToString();

                //data = Math.Round((Convert.ToDouble(row["Valor"]) * Convert.ToDouble(row["Descuento"]) / 100), 2).ToString();

                row_["ValorMenosDescto"] = Math.Round((Convert.ToDouble(row["Valor"]) -
                    (Convert.ToDouble(row["Valor"]) * Convert.ToDouble(row["Descuento"]) / 100)), 2);
                //data = row_["ValorMenosDescto"].ToString();
                row_["Valorbase"] = Math.Round((Convert.ToDouble(row_["ValorMenosDescto"]) * Convert.ToDouble(row["Cantidad"])), 2);

                row_["ValorIva"] = Math.Round((Convert.ToDouble(row_["ValorMenosDescto"]) * Convert.ToDouble(row["Iva"]) / 100), 2);
                //data = row_["ValorIva"].ToString();

                row_["TotalMasIva"] = Math.Round(
                    (Convert.ToDouble(row_["ValorMenosDescto"]) + Convert.ToDouble(row_["ValorIva"]) + Convert.ToDouble(row_["Impoconsumo"])), 2);
                //row_["TotalMasIva"] = Convert.ToDouble(row_["ValorMenosDescto"]) + Convert.ToDouble(row_["ValorIva"]);
                //data = row_["TotalMasIva"].ToString();

                row_["ValorIva"] = Math.Round(
                    ((Convert.ToDouble(row_["ValorMenosDescto"]) * Convert.ToDouble(row["Iva"]) / 100) *
                      Convert.ToDouble(row["Cantidad"])), 2);
                //data = row_["ValorIva"].ToString();

                row_["Total"] = Math.Round((Convert.ToDouble(row_["TotalMasIva"]) * Convert.ToDouble(row["Cantidad"])), 2);
                //data = row_["Total"].ToString();

                // Antes...
                /*
                row_["Descuento"] = row["Descuento"].ToString() + "%";

                row_["ValorMenosDescto"] = Convert.ToDouble(row["Valor"]) -
                              (Convert.ToDouble(row["Valor"]) * Convert.ToDouble(row["Descuento"]) / 100);

                row_["ValorIva"] = Math.Round((Convert.ToDouble(row_["ValorMenosDescto"]) * Convert.ToDouble(row["Iva"]) / 100), 2);

                row_["TotalMasIva"] = Convert.ToDouble(row_["ValorMenosDescto"]) + Convert.ToDouble(row_["ValorIva"]);

                row_["Total"] = Convert.ToDouble(row_["TotalMasIva"]) * Convert.ToDouble(row["Cantidad"]);
                */

                miTabla.Rows.Add(row_);
            }
            tabla.Clear();
            tabla = null;
            return miTabla;
        }

        public List<Utilities.DetalleProducto> Detalles(int idFactura)
        {
            var detalles = new List<Utilities.DetalleProducto>();
            var tabla = ConsultaProductoFacturaProveedor(idFactura);

            foreach (DataRow row in tabla.Rows)
            {
                detalles.Add(new DetalleProducto
                             {
                                 Codigo = row["Codigo"].ToString(),
                                 Medida = Convert.ToInt32(row["IdMedida"]),
                                 Color = Convert.ToInt32(row["IdColor"]),
                                 Cantidad = Convert.ToDouble(row["Cantidad"]),
                                 ValorUnitario = Convert.ToDouble(row["Valor"]),
                                 Descto = UseObject.RemoveCharacter(row["Descuento"].ToString(), '%') //Convert.ToDouble(row["Descuento"].ToString())
                             });
            }
            return detalles;
        }

        public bool ProductoDeFactura(int idFactura, DetalleProducto dProducto)
        {
            var tabla = ConsultaProductoFacturaProveedor(idFactura);
            var qRow = from data in tabla.AsEnumerable()
                       where data.Field<string>("Codigo").Equals(dProducto.Codigo) &&
                             data.Field<int>("IdMedida").Equals(dProducto.Medida) &&
                             data.Field<int>("IdColor").Equals(dProducto.Color)
                       select data;
            if (qRow.ToArray().Length != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public DataTable PrintDetalleFactura(int id)
        {
            var tablaDet = new DataTable();
            tablaDet.Columns.Add(new DataColumn("Codigo", typeof(string)));
            tablaDet.Columns.Add(new DataColumn("Producto", typeof(string)));
            tablaDet.Columns.Add(new DataColumn("Cantidad", typeof(double)));
            tablaDet.Columns.Add(new DataColumn("Valor_", typeof(int)));
            tablaDet.Columns.Add(new DataColumn("Descuento", typeof(string)));
            tablaDet.Columns.Add(new DataColumn("Total_", typeof(int)));
            tablaDet.Columns.Add(new DataColumn("Sub_Total", typeof(int)));
            tablaDet.Columns.Add(new DataColumn("Descto_", typeof(int)));
            tablaDet.Columns.Add(new DataColumn("vIva_", typeof(int)));

            tablaDet.Columns.Add(new DataColumn("Iva", typeof(string)));
            tablaDet.Columns.Add(new DataColumn("ValorMenosDescto", typeof(double)));
            tablaDet.Columns.Add(new DataColumn("Valor", typeof(int)));
            //tablaDet.Columns.Add(new DataColumn("ValorMenosDescto", typeof(double)));
            var tabla = miDaoFacturaProveedor.ConsultaProductoFacturaProveedor(id);
            foreach (DataRow row in tabla.Rows)
            {
                var row_ = tablaDet.NewRow();
                row_["Codigo"] = row["Codigo"];
                row_["Producto"] = row["Articulo"];
                row_["Cantidad"] = row["Cantidad"];
                row_["Iva"] = row["Iva"].ToString() + "%";
                row_["Valor"] = row["Valor"];
                row_["Descuento"] = row["Descuento"].ToString() + "%";
                row_["Valor_"] = Convert.ToDouble(row["Valor"]) +
                    (Convert.ToDouble(row["Valor"]) * UseObject.RemoveCharacter(row_["Iva"].ToString(), '%') / 100);


                row_["ValorMenosDescto"] = Convert.ToDouble(row["Valor"]) -
                              (Convert.ToDouble(row["Valor"]) * Convert.ToDouble(row["Descuento"]) / 100);
                row_["Sub_Total"] = Convert.ToDouble(row["Valor"]) * Convert.ToDouble(row["Cantidad"]);
                row_["Descto_"] = (Convert.ToDouble(row["Valor"]) * UseObject.RemoveCharacter(row["Descuento"].ToString(), '%') / 100)
                    * Convert.ToDouble(row["Cantidad"]);
                var valorMenDescto = Convert.ToInt32(Convert.ToDouble(row["Valor"]) -
                    (Convert.ToDouble(row["Valor"]) * UseObject.RemoveCharacter(row["Descuento"].ToString(), '%') / 100));
                row_["Total_"] = (valorMenDescto + (valorMenDescto * UseObject.RemoveCharacter(row["Iva"].ToString(), '%') / 100))
                    * Convert.ToDouble(row["Cantidad"]);

                row_["vIva_"] = Convert.ToDouble(row_["ValorMenosDescto"]) * Convert.ToDouble(row["Iva"]) / 100;
                row_["vIva_"] = Convert.ToInt32(row_["vIva_"]) * Convert.ToDouble(row["Cantidad"]);
                //var j = row_["vIva"].ToString();
                //row_["TotalMasIva"] = Convert.ToDouble(row_["ValorMenosDescto"]) + Convert.ToDouble(row_["ValorIva"]);
                //row_["Total"] = Convert.ToDouble(row_["TotalMasIva"]) * Convert.ToDouble(row["Cantidad"]);
                tablaDet.Rows.Add(row_);
            }
            tabla.Clear();
            tabla = null;
            return tablaDet;
        }

        public DataTable ConsultaFacturasConSaldo()
        {
            return miDaoFacturaProveedor.ConsultaFacturasConSaldo();
        }

        public DataTable ComprasAproveedor(DateTime fecha, DateTime fecha1)
        {
            return miDaoFacturaProveedor.ComprasAproveedor(fecha, fecha1);
        }

        /// <summary>
        /// Edita los datos de un registro de FacturaProveedor en base de datos.
        /// </summary>
        /// <param name="factura">Registro de FacturaProveedor a editar.</param>
        public void EditarFacturaProveedor(FacturaProveedor factura)
        {
            miDaoFacturaProveedor.EditarFacturaProveedor(factura);
        }

        /// <summary>
        /// Ingresa un registro de ProductoFacturaProveedor estableciendo la relacion necesaria.
        /// </summary>
        /// <param name="producto">Registro de ProductoFacturaProveedor a ingresar.</param>
        public void IngresarProductoFacturaProveedor(ProductoFacturaProveedor producto, bool esFactura)
        {
            miDaoProductoFactura.IngresarProductoFacturaProveedor(producto, esFactura);
        }

        public DataTable ProductosDeFactura(Inventario inventario)
        {
            return miDaoProductoFactura.ProductosDeFactura(inventario);
        }

        /// <summary>
        /// Edita los datos de un registro de ProductoFacturaProveedor en base de datos.
        /// </summary>
        /// <param name="producto">Registro de ProductoFacturaProveedor a editar.</param>
        public void EditarProductoFacturaProveedor(ProductoFacturaProveedor producto)
        {
            miDaoProductoFactura.EditarProductoFacturaProveedor(producto);
        }

        public void EditarProductoFacturaProveedor(ProductoFacturaProveedor producto, bool actInventario)
        {
            miDaoProductoFactura.EditarProductoFacturaProveedor(producto, actInventario);
        }

        public double SaldoAProveedor(string nit)
        {
            int saldoTotal = 0;
            var facturas = FacturasDeProveedor_(nit);
            foreach (DataRow fRow in facturas.Rows)
            {
                var productos = ConsultaProductoFacturaProveedor(Convert.ToInt32(fRow["Id"]));
                var subTotal = Convert.ToInt32
                                      (productos.AsEnumerable().Sum(s => (s.Field<double>("Valor") * s.Field<double>("Cantidad"))));
                int valorDescuento = 0;
                foreach (DataRow row in productos.Rows)
                {
                    valorDescuento += Convert.ToInt32((Convert.ToDouble(row["Valor"]) *
                                                       UseObject.RemoveCharacter(row["Descuento"].ToString(), '%') / 100) *
                                                       Convert.ToDouble(row["Cantidad"]));
                }
                int valorIva = Convert.ToInt32(productos.AsEnumerable().Sum(s => s.Field<double>("ValorIva")));
                /*foreach (DataRow ivaRow in productos.Rows)
                {
                    valorIva = Convert.ToInt32(
                                valorIva + Convert.ToDouble(ivaRow["ValorIva"]));
                }*/
                int impoConsumo =
                        Convert.ToInt32(productos.AsEnumerable().Sum(s => (s.Field<double>("Impoconsumo") * s.Field<double>("Cantidad"))));
                var ajuste = Convert.ToInt32(fRow["valor_ajuste"]);
                var total = (subTotal - valorDescuento) + valorIva + impoConsumo + ajuste;

                var tRetenciones = miDaoRetencion.RetencionesACompra(Convert.ToInt32(fRow["Id"]));
                var retencion = 0;
                foreach (DataRow rRow in tRetenciones.Rows)
                {
                    retencion += Convert.ToInt32((subTotal - valorDescuento) * Convert.ToDouble(rRow["tarifa"]) / 100);
                }
                total -= retencion;

                var pagos = PagosAProveedor(Convert.ToInt32(fRow["Id"]));
                var saldo = total - pagos;
                saldoTotal = saldoTotal + saldo;
            }
            return saldoTotal;
            //return miDaoFacturaProveedor.SaldoAProveedor(nit);
        }

        public DataTable FacturasDeProveedor(string nit)
        {
            return miDaoFacturaProveedor.FacturasDeProveedor(nit);
        }

        public DataTable FacturasDeProveedor_(string nit)
        {
            return miDaoFacturaProveedor.FacturasDeProveedor_(nit);
        }

        public DataTable CarteraProveedores(bool saldo, bool provider, int proveedor)
        {
            int subTotal = 0;
            int descuento = 0;
            int valorIva = 0;

            var miDaoProveedor = new DaoProveedor();
            var miDaoDevolucion = new DaoDevolucion();
            var miBussinesPago = new BussinesFormaPago();
            var tabla = TablaCartera();
            var tProveedores = new DataTable();// miDaoProveedor.Proveedores();

            string numFactura = "";
            string codProducto = "";
            try
            {
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
                    if (Convert.ToBoolean(pRow["Estado"]))
                    {
                        //numFactura = pRow["Nit"].ToString();
                        //var name = pRow["Nombre"].ToString();
                        var tFacturas = miDaoFacturaProveedor.FacturaProveedorTodas(pRow["Nit"].ToString());
                        //tFacturas = miDaoFacturaProveedor.ConsultaFacturaProveedor(1, true);
                        foreach (DataRow fRow in tFacturas.Rows)
                        {
                            if (Convert.ToBoolean(fRow["estado_"]))
                            {
                                numFactura = fRow["Numero"].ToString();

                                if (numFactura.Equals("47906"))
                                {
                                    var fact = numFactura;
                                }

                                subTotal = 0;
                                descuento = 0;
                                valorIva = 0;
                                /*  var no = fRow["Numero"].ToString();
                                  if (no.Equals("3879"))
                                  {
                                      var j_ = no;
                                  }*/
                                /*   var valorFactura = CalcularTotalFactura(
                                                      ConsultaProductoFacturaProveedor(Convert.ToInt32(fRow["Id"])));*/
                                //Convert.ToInt32(fRow["valor_ajuste"]);
                                var tProductos = ConsultaProductoFacturaProveedor(Convert.ToInt32(fRow["Id"]));
                                subTotal = Convert.ToInt32(tProductos.
                                    AsEnumerable().Sum(s => (s.Field<double>("Valor") * s.Field<double>("Cantidad"))));
                                foreach (DataRow row in tProductos.Rows)
                                {
                                    codProducto = row["Codigo"].ToString();

                                    if (codProducto.Equals("1161"))
                                    {
                                        var cod = codProducto;
                                    }

                                    var Valor = Convert.ToDouble(row["Valor"]);
                                    var Descuento = UseObject.RemoveCharacter(row["Descuento"].ToString(), '%');
                                    var Cantidad = Convert.ToDouble(row["Cantidad"]);

                                    descuento += Convert.ToInt32((Convert.ToDouble(row["Valor"]) *
                                                                       UseObject.RemoveCharacter(row["Descuento"].ToString(), '%') / 100) *
                                                                       Convert.ToDouble(row["Cantidad"]));
                                    //valorIva = Convert.ToInt32(valorIva + Convert.ToDouble(row["ValorIva"]));
                                }
                                int impoConsumo =
                                    Convert.ToInt32(tProductos.AsEnumerable().Sum(s => (s.Field<double>("Impoconsumo") * s.Field<double>("Cantidad"))));
                                valorIva = Convert.ToInt32(tProductos.AsEnumerable().Sum(s => s.Field<double>("ValorIva")));

                                subTotal -= descuento;

                                //valorFactura = valorFactura + Convert.ToInt32(fRow["valor_ajuste"]);
                                var tRetenciones = miDaoRetencion.RetencionesACompra(Convert.ToInt32(fRow["Id"]));
                                int retencion = 0;
                                foreach (DataRow rRow in tRetenciones.Rows)
                                {
                                    retencion += Convert.ToInt32(subTotal * Convert.ToDouble(rRow["tarifa"]) / 100);
                                }

                                subTotal -= retencion;
                                subTotal += impoConsumo;
                                subTotal += valorIva;

                                subTotal += Convert.ToInt32(fRow["valor_ajuste"]);

                                //valorFactura -= retencion;

                                //var saldoDev = miDaoDevolucion.SaldoDevolucionCompra(Convert.ToInt32(fRow["Id"]));
                                var pagos = miBussinesPago.PagosAProveedor(Convert.ToInt32(fRow["Id"]));
                                //var vSaldo = subTotal - (saldoDev + pagos);
                                var vSaldo = subTotal - pagos;
                                //var vSaldo = valorFactura - (saldoDev + pagos);
                                if (vSaldo > 0)
                                {
                                    var row = tabla.NewRow();
                                    row["Codigo"] = pRow["Codigo"];
                                    row["Cedula"] = pRow["Nit"];
                                    row["Nombre"] = pRow["Nombre"];
                                    row["Factura"] = fRow["Numero"];
                                    row["Fecha"] = fRow["Ingreso"];
                                    row["Limite"] = fRow["Limite"];
                                    row["Valor"] = subTotal;
                                    // row["Valor"] = valorFactura;
                                    row["Abonos"] = pagos;
                                    row["Saldo"] = vSaldo;
                                    tabla.Rows.Add(row);
                                }
                            }
                        }
                    }
                }
                if (!saldo)
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
            catch (Exception)
            {
                throw new Exception("\nNo.: " + numFactura + "\nProducto: " + codProducto);
            }
        }

        public DataTable CarteraProveedores2(bool saldo, bool provider, int proveedor)
        {
            var miDaoProveedor = new DaoProveedor();
            var miDaoDevolucion = new DaoDevolucion();
            var miBussinesPago = new BussinesFormaPago();
            var tabla = TablaCartera();
            var tProveedores = new DataTable();// miDaoProveedor.Proveedores();
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
               // var tFacturas = miDaoFacturaProveedor.FacturaProveedorEstado(pRow["Nit"].ToString());
                var tFacturas = miDaoFacturaProveedor.ConsultaFacturaProveedor(Convert.ToInt32(pRow["Codigo"]), true);
                foreach (DataRow fRow in tFacturas.Rows)
                {
                    var valorFactura = CalcularTotalFactura(
                                       ConsultaProductoFacturaProveedor(Convert.ToInt32(fRow["Id"])));// +
                    //Convert.ToInt32(fRow["valor_ajuste"]);
                    valorFactura = valorFactura + Convert.ToInt32(fRow["valor_ajuste"]);
                    var saldoDev = miDaoDevolucion.SaldoDevolucionCompra(Convert.ToInt32(fRow["Id"]));
                    var pagos = miBussinesPago.PagosAProveedor(Convert.ToInt32(fRow["Id"]));
                    var vSaldo = valorFactura - (saldoDev + pagos);
                    //if (vSaldo > 0)
                    //{
                        var row = tabla.NewRow();
                        row["Codigo"] = pRow["Codigo"];
                        row["Cedula"] = pRow["Nit"];
                        row["Nombre"] = pRow["Nombre"];
                        row["Factura"] = fRow["Numero"];
                        row["Fecha"] = fRow["Ingreso"];
                        row["Limite"] = fRow["Limite"];
                        row["Valor"] = valorFactura;
                        row["Abonos"] = pagos + saldoDev;
                        row["Saldo"] = vSaldo;
                        tabla.Rows.Add(row);
                    //}
                }
            }
            if (!saldo)
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

        public DataTable ResumenCarteraProveedores()
        {
            var miDaoProveedor = new DaoProveedor();
            var tabla = TablaCartera();
            var proveedores = miDaoProveedor.Proveedores();
            foreach (DataRow rProveedor in proveedores.Rows)
            {
                var saldo = SaldoAProveedor(rProveedor["Nit"].ToString());
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

        public DataTable ConsultaCompras(int proveedor, DateTime fecha, DateTime fecha2)
        {
            var miDaoProveedor = new DaoProveedor();
            var miDaoDevolucion = new DaoDevolucion();
            var miBussinesPago = new BussinesFormaPago();
            var tabla = TablaCartera();
            var tProveedores = new DataTable();

            var valorFactura = 0;
            var saldoDev = 0;
            var pagos = 0;
            var vSaldo = 0;

            if (proveedor.Equals(0))
            {
                tProveedores = miDaoProveedor.Proveedores();
            }
            else
            {
                tProveedores = miDaoProveedor.Proveedores(proveedor);
            }

            foreach (DataRow pRow in tProveedores.Rows)
            {
                var tFacturas = miDaoFacturaProveedor.
                    ConsultaFacturaProveedor(Convert.ToInt32(pRow["Codigo"]), fecha, fecha2);
                foreach (DataRow fRow in tFacturas.Rows)
                {
                    /*valorFactura = CalcularTotalFactura(
                        ConsultaProductoFacturaProveedor(Convert.ToInt32(fRow["Id"])));*/
                    valorFactura = Convert.ToInt32(
                        this.ConsultaProductoFacturaProveedor(Convert.ToInt32(fRow["Id"])).AsEnumerable().Sum(s => s.Field<double>("Total"))); 

                    valorFactura += Convert.ToInt32(fRow["valor_ajuste"]);
                    saldoDev = miDaoDevolucion.SaldoDevolucionCompra(Convert.ToInt32(fRow["Id"]));
                    pagos = miBussinesPago.PagosAProveedor(Convert.ToInt32(fRow["Id"]));
                    vSaldo = valorFactura - (pagos + saldoDev);
                    var row = tabla.NewRow();
                    row["Codigo"] = pRow["Codigo"];
                    row["Cedula"] = pRow["Nit"];
                    row["Nombre"] = pRow["Nombre"];
                    row["Factura"] = fRow["Numero"];
                    row["Fecha"] = fRow["fecha_factura"];
                    row["Limite"] = fRow["Limite"];
                    row["Valor"] = valorFactura;
                    row["Abonos"] = pagos + saldoDev;
                    row["Saldo"] = vSaldo;
                    tabla.Rows.Add(row);
                }
            }
            if (tabla.Rows.Count != 0)
            {
                IEnumerable<DataRow> rQuery = from data in tabla.AsEnumerable()
                                              orderby data.Field<DateTime>("Fecha") ascending,
                                                      data.Field<string>("Nombre") ascending
                                              select data;
                return rQuery.CopyToDataTable<DataRow>();
            }
            else
            {
                return tabla;
            }
        }

        public List<Iva> ConsultaIvaCompras(int proveedor, DateTime fecha, DateTime fecha2)
        {
            var miDaoProveedor = new DaoProveedor();
            var tProveedores = new DataTable();
            var tFacturas = new DataTable();
            var fProductos = new DataTable();
            DataTable tIvaCompras = new DataTable();
            tIvaCompras.Columns.Add(new DataColumn("Gravado", typeof(string)));
            tIvaCompras.Columns.Add(new DataColumn("Base", typeof(double)));
            tIvaCompras.Columns.Add(new DataColumn("VIva", typeof(double)));
            tIvaCompras.Columns.Add(new DataColumn("Total", typeof(double)));
            List<Iva> lstIva = new List<Iva>();
            if (proveedor.Equals(0))
            {
                tProveedores = miDaoProveedor.Proveedores();
            }
            else
            {
                tProveedores = miDaoProveedor.Proveedores(proveedor);
            }
            foreach (DataRow pRow in tProveedores.Rows)
            {
                tFacturas = miDaoFacturaProveedor.
                    ConsultaFacturaProveedor(Convert.ToInt32(pRow["Codigo"]), fecha, fecha2);
                foreach (DataRow fRow in tFacturas.Rows)
                {
                    fProductos = ConsultaProductoFacturaProveedor(Convert.ToInt32(fRow["Id"]));
                    foreach (DataRow psRow in fProductos.Rows)
                    {
                        lstIva.Add(new Iva
                        {
                            PorcentajeIva = Convert.ToDouble(psRow["PIva"]),
                            ConceptoIva = psRow["Iva"].ToString(),
                            BaseI = Convert.ToDouble(psRow["ValorBase"]),
                            ValorIva = Convert.ToDouble(psRow["ValorIva"]),
                            Total = Convert.ToDouble(psRow["ValorBase"]) + Convert.ToDouble(psRow["ValorIva"])
                        });
                    }
                    /*var row = tIvaCompras.NewRow();
                    row["Base"] = fProductos.AsEnumerable().Sum(s => s.Field<double>("ValorBase"));
                    row["VIva"] = fProductos.AsEnumerable().Sum(s => s.Field<double>("ValorIva"));
                    row["Total"] = Convert.ToDouble(row["Base"]) + Convert.ToDouble(row["VIva"]);
                    tIvaCompras.Rows.Add(row);*/
                }
            }
            return this.IvaAgrupado(lstIva);
            //return tIvaCompras;
        }

        public DataTable ConsultaIvaCompras_(int proveedor, DateTime fecha, DateTime fecha2)
        {
            var miDaoProveedor = new DaoProveedor();
            var tProveedores = new DataTable();
            var tFacturas = new DataTable();
            var fProductos = new DataTable();
            DataTable tIvaCompras = new DataTable();
            tIvaCompras.Columns.Add(new DataColumn("Gravado", typeof(string)));
            tIvaCompras.Columns.Add(new DataColumn("Base", typeof(double)));
            tIvaCompras.Columns.Add(new DataColumn("VIva", typeof(double)));
            tIvaCompras.Columns.Add(new DataColumn("Total", typeof(double)));
            List<Iva> lstIva = new List<Iva>();
            if (proveedor.Equals(0))
            {
                tProveedores = miDaoProveedor.Proveedores();
            }
            else
            {
                tProveedores = miDaoProveedor.Proveedores(proveedor);
            }
            foreach (DataRow pRow in tProveedores.Rows)
            {
                tFacturas = miDaoFacturaProveedor.
                    ConsultaFacturaProveedor(Convert.ToInt32(pRow["Codigo"]), fecha, fecha2);
                foreach (DataRow fRow in tFacturas.Rows)
                {
                    fProductos = ConsultaProductoFacturaProveedor(Convert.ToInt32(fRow["Id"]));
                    /*foreach (DataRow psRow in fProductos.Rows)
                    {
                        lstIva.Add(new Iva
                        {
                            PorcentajeIva = Convert.ToDouble(psRow["PIva"]),
                            ConceptoIva = psRow["Iva"].ToString(),
                            BaseI = Convert.ToDouble(psRow["ValorBase"]),
                            ValorIva = Convert.ToDouble(psRow["ValorIva"]),
                            Total = Convert.ToDouble(psRow["ValorBase"]) + Convert.ToDouble(psRow["ValorIva"])
                        });
                    }*/
                    var row = tIvaCompras.NewRow();
                    row["Base"] = fProductos.AsEnumerable().Sum(s => s.Field<double>("ValorBase"));
                    row["VIva"] = fProductos.AsEnumerable().Sum(s => s.Field<double>("ValorIva"));
                    row["Total"] = Convert.ToDouble(row["Base"]) + Convert.ToDouble(row["VIva"]);
                    tIvaCompras.Rows.Add(row);
                }
            }
            //return this.IvaAgrupado(lstIva);
            return tIvaCompras;
        }

        public List<Iva> IvaAgrupado(List<Iva> lstIvas)
        {
            var query = lstIvas
                .GroupBy(i => new
                {
                    i.PorcentajeIva,
                    i.ConceptoIva
                })
                .Select(i => new Iva
                {
                    PorcentajeIva = i.Key.PorcentajeIva,
                    ConceptoIva = i.Key.ConceptoIva,
                    BaseI = i.Sum(i_ => i_.BaseI),
                    ValorIva = i.Sum(i_ => i_.ValorIva),
                    Total = i.Sum(i_ => i_.BaseI) + i.Sum(i_ => i_.ValorIva)
                })
                .OrderBy(i => i.PorcentajeIva).ToList();
            return query;

            /*var dt = new DataTable();
            dt.Columns.Add(new DataColumn("Gravado", typeof(string)));
            dt.Columns.Add(new DataColumn("Base", typeof(double)));
            dt.Columns.Add(new DataColumn("VIva", typeof(double)));
            dt.Columns.Add(new DataColumn("Total", typeof(double)));

            dt.Rows.Add("0%", 1000, 0, 1000);
            dt.Rows.Add("19%", 10000, 1900, 11900);
            dt.Rows.Add("0%", 1000, 0, 1000);
            dt.Rows.Add("5%", 5000, 250, 5250);
            dt.Rows.Add("5%", 1000, 50, 1050);
            dt.Rows.Add("19%", 21000, 3990, 24990);

            var result = from tab in dt.AsEnumerable()
                         group tab by tab["Gravado"]
                             into groutDt
                             select new
                             {
                                 Gravado = groutDt.Key,
                                 Base = groutDt.Sum((s) => decimal.Parse(s["Base"].ToString())),
                                 VIva = groutDt.Sum((s) => decimal.Parse(s["VIva"].ToString())),
                                 Total = groutDt.Sum((s) => decimal.Parse(s["Total"].ToString()))
                             };
            
            return dt;*/
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

        private int CalcularTotalFactura(DataTable tabla)
        {
            var subTotal = Convert.ToInt32(
                tabla.AsEnumerable().Sum(s => (s.Field<double>("Valor") * s.Field<double>("Cantidad"))));
            int valorDescuento = 0;
            int valorIva = 0;
            foreach (DataRow row in tabla.Rows)
            {
                valorDescuento += Convert.ToInt32((Convert.ToDouble(row["Valor"]) *
                                                   UseObject.RemoveCharacter(row["Descuento"].ToString(), '%') / 100) *
                                                   Convert.ToDouble(row["Cantidad"]));
                valorIva = Convert.ToInt32(valorIva + Convert.ToDouble(row["ValorIva"]));
            }
            return (subTotal - valorDescuento) + valorIva;
        }

        public int SaldoTotalCredito()
        {
            return miDaoFacturaProveedor.SaldoTotalCredito();
        }

        public string IngresarPagoGeneral(int codigoProveedor, FormaPago fPago, bool esFactura)
        {
            return miDaoFacturaProveedor.IngresarPagoGeneral(codigoProveedor, fPago, esFactura);
        }

        public List<int> GetArrayFacturas()
        {
            return miDaoFacturaProveedor.GetArrayFacturas();
        }

        public List<int> GetArrayIds()
        {
            return miDaoFacturaProveedor.GetArrayIds();
        }

        public int PagosAProveedor(int idFactura)
        {
            return miDaoFacturaProveedor.PagosAProveedor(idFactura);
        }

         // Ajuste a preingreso
        public double CantidadProductoCompra(string codigo)
        {
            return this.miDaoFacturaProveedor.CantidadProductoCompra(codigo);
        }

        public ProductoFacturaProveedor UltimoRegistroCompra(string codigo)
        {
            return this.miDaoFacturaProveedor.UltimoRegistroCompra(codigo);
        }

        /// <summary>
        /// Elimina un registro de Producto de Factura Proveedor.
        /// </summary>
        /// <param name="id">Id del registro del Producto a eliminar.</param>
        public void EliminarProductoFacturaProveedor(int id)
        {
            miDaoProductoFactura.EliminarProductoFacturaProveedor(id);
        }

        /// <summary>
        /// Crea las respectivas columnas del DataTable para ProductoFacturaProveedor.
        /// </summary>
        private DataTable CrearDataTable()
        {
            var miTabla = new DataTable();
            miTabla.Columns.Add(new DataColumn("Id", typeof(int)));
            miTabla.Columns.Add(new DataColumn("Numero", typeof(int)));
            miTabla.Columns.Add(new DataColumn("Codigo", typeof(string)));
            miTabla.Columns.Add(new DataColumn("Articulo", typeof(string)));
            miTabla.Columns.Add(new DataColumn("Cantidad", typeof(double)));
            miTabla.Columns.Add(new DataColumn("Unidad", typeof(string)));
            miTabla.Columns.Add(new DataColumn("IdMedida", typeof(int)));
            miTabla.Columns.Add(new DataColumn("Medida", typeof(string)));
            miTabla.Columns.Add(new DataColumn("IdColor", typeof(int)));
            miTabla.Columns.Add(new DataColumn("Color", typeof(System.Drawing.Image)));
            miTabla.Columns.Add(new DataColumn("IdLote", typeof(int)));
            miTabla.Columns.Add(new DataColumn("Lote", typeof(string)));
            miTabla.Columns.Add(new DataColumn("PIva", typeof(double)));
            miTabla.Columns.Add(new DataColumn("Iva", typeof(string)));
            miTabla.Columns.Add(new DataColumn("Valor", typeof(double)));
            miTabla.Columns.Add(new DataColumn("Impoconsumo", typeof(double)));
            miTabla.Columns.Add(new DataColumn("Total", typeof(double)));
            miTabla.Columns.Add(new DataColumn("ValorIva", typeof(double)));
            miTabla.Columns.Add(new DataColumn("TotalMasIva", typeof(double)));
            miTabla.Columns.Add(new DataColumn("Descuento", typeof(string)));
            miTabla.Columns.Add(new DataColumn("ValorMenosDescto", typeof(double)));
            miTabla.Columns.Add(new DataColumn("ValorBase", typeof(double)));

            miTabla.Columns.Add(new DataColumn("IdTipoInventario", typeof(int)));
            return miTabla;
        }


        // Compra temporal
        public double CantidadProductoCompraTemporal(string codigo)
        {
            return this.miDaoFacturaProveedor.CantidadProductoCompraTemporal(codigo);
        }

        public void IngresarCompraTemporal(FacturaProveedor compra)
        {
            this.miDaoFacturaProveedor.IngresarCompraTemporal(compra);
        }

        public void IngresarProductoTemporal(ProductoFacturaProveedor producto)
        {
            this.miDaoFacturaProveedor.IngresarProductoTemporal(producto);
        }

        public DataTable ComprasTemporales()
        {
            return this.miDaoFacturaProveedor.ComprasTemporales();
        }


        public FacturaProveedor Compra(int id)
        {
            return this.miDaoFacturaProveedor.Compra(id);
        }

        public DataTable ProductosCompra(int idCompra)
        {
            return this.miDaoFacturaProveedor.ProductosCompra(idCompra);
        }

        public List<Item> ItemsCompra(int idCompra)
        {
            return this.miDaoFacturaProveedor.ItemsCompra(idCompra);
        }

        public void EditCantidad(int id, double cantidad)
        {
            miDaoFacturaProveedor.EditCantidad(id, cantidad);
        }

        public void EditCosto(int id, double costo)
        {
            miDaoFacturaProveedor.EditCosto(id, costo);
        }

        public void EditD1(int id, double d1)
        {
            miDaoFacturaProveedor.EditD1(id, d1);
        }

        public void EditD2(int id, double d2)
        {
            miDaoFacturaProveedor.EditD2(id, d2);
        }

        public void EditImpoconsumo(string codigo, double ico)
        {
            miDaoFacturaProveedor.EditImpoconsumo(codigo, ico);
        }

        public void DeleteItem(int id)
        {
            this.miDaoFacturaProveedor.DeleteItem(id);
        }



        public void EliminarCompraTemporal(int id)
        {
            this.miDaoFacturaProveedor.EliminarCompraTemporal(id);
        }

        public void EliminarProductoTemporal(int id)
        {
            this.miDaoFacturaProveedor.EliminarProductoTemporal(id);
        }



        public DataTable TableCompras(int codProveedor)
        {
            //return this.miDaoFacturaProveedor.TableCompras();

            var tData = new DataTable();
            tData.Columns.Add("proveedor", typeof(string));
            tData.Columns.Add("id", typeof(int));
            tData.Columns.Add("numero", typeof(string));
            tData.Columns.Add("fecha", typeof(DateTime));
            tData.Columns.Add("estado", typeof(bool));
            tData.Columns.Add("ajuste", typeof(double));
            tData.Columns.Add("total", typeof(int));
            tData.Columns.Add("pagos", typeof(int));

            DataTable tCompras = this.miDaoFacturaProveedor.ComprasDeProveedor(codProveedor);
            foreach (DataRow comRow in tCompras.Rows)
            {
                var tdRow = tData.NewRow();
                tdRow["proveedor"] = comRow["proveedor"];
                tdRow["id"] = comRow["id"];
                tdRow["numero"] = comRow["numero"];
                tdRow["fecha"] = comRow["fecha"];
                tdRow["estado"] = comRow["estado"];
                tdRow["ajuste"] = comRow["ajuste"];

                DataTable tProductos = this.ConsultaProductoFacturaProveedor(Convert.ToInt32(comRow["id"]));
                int subTotal = Convert.ToInt32(
                    tProductos.AsEnumerable().Sum(s => (s.Field<double>("Valor") * s.Field<double>("Cantidad"))));
                int vIva = Convert.ToInt32(tProductos.AsEnumerable().Sum(s => s.Field<double>("ValorIva")));

                tdRow["total"] = Convert.ToInt32(subTotal + vIva + Convert.ToDouble(comRow["ajuste"]));
                tdRow["pagos"] = this.miDaoFacturaProveedor.PagosAcompras(Convert.ToInt32(comRow["id"]));
                tData.Rows.Add(tdRow);
            }
            return tData;
        }

        public void AjustarPreciosDeProductos()
        {
            this.miDaoFacturaProveedor.AjustarPreciosDeProductos();
        }



        public DataTable ProveedoresDeCompras()
        {
            return this.miDaoFacturaProveedor.ProveedoresDeCompras();
        }

        public void AjustarComprasAndPagos(int maxValor)
        {
            this.miDaoFacturaProveedor.AjustarComprasAndPagos(maxValor);
        }
    }
}