using System;
using System.Data;
using DataAccessLayer.Clases;
using DTO.Clases;
using System.Collections.Generic;

namespace BussinesLayer.Clases
{
    public class BussinesDevolucion
    {
        /// <summary>
        /// Objeto que proporciona acceso a la capa de datos de Devolución.
        /// </summary>
        private DaoDevolucion miDaoDevolucion;

        /// <summary>
        /// Inicializa una nueva instancia de la clase BussinesDevolucion.
        /// </summary>
        public BussinesDevolucion()
        {
            this.miDaoDevolucion = new DaoDevolucion();
        }

        #region Devolucion Venta

        public string GetConsecutivoVenta()
        {
            return miDaoDevolucion.GetConsecutivoVenta();
        }

        public void ActualizarConsecutivoVenta()
        {
            miDaoDevolucion.ActualizarConsecutivoVenta();
        }

        /// <summary>
        /// Ingresa una devolución hecha a una Factura de Venta.
        /// </summary>
        /// <param name="devolucion">Devolución a ser ingresada.</param>
        public int IngresarVenta(Devolucion devolucion)
        {
            return miDaoDevolucion.IngresarVenta(devolucion);
        }

        public void IngresarVenta(FacturaProveedor devolucion)
        {
            miDaoDevolucion.IngresarVenta(devolucion);
        }

        public void IngresarConsecutivoVenta(int consecutivo, int idDevolucion)
        {
            miDaoDevolucion.IngresarConsecutivoVenta(consecutivo, idDevolucion);
        }


        public DataTable DevolucionesDeVenta(string numero)
        {
            return miDaoDevolucion.DevolucionesDeVenta(numero);
        }

        public DataTable DevolucionesDeVenta(DateTime fecha)
        {
            return miDaoDevolucion.DevolucionesDeVenta(fecha);
        }

        public long GetRowsDevolucionesDeVenta(DateTime fecha)
        {
            return miDaoDevolucion.GetRowsDevolucionesDeVenta(fecha);
        }

        public DataTable DevolucionesDeVenta(DateTime fecha, DateTime fecha2)
        {
            return miDaoDevolucion.DevolucionesDeVenta(fecha, fecha2);
        }

        public long GetRowsDevolucionesDeVenta(DateTime fecha, DateTime fecha2)
        {
            return miDaoDevolucion.GetRowsDevolucionesDeVenta(fecha, fecha2);
        }

        public DataTable DevolucionesDeVentaCliente(string cliente)
        {
            return miDaoDevolucion.DevolucionesDeVentaCliente(cliente);
        }

        public long GetRowsDevolucionesDeVentaCliente(string cliente)
        {
            return miDaoDevolucion.GetRowsDevolucionesDeVentaCliente(cliente);
        }


        //***********************
        public Devolucion DevolucionVenta(string numero)
        {
            return miDaoDevolucion.DevolucionVenta(numero);
        }

        public DataTable DetalleDevolucionVenta(int idDevolucion)
        {
            return miDaoDevolucion.DetalleDevolucionVenta(idDevolucion);
        }

        public List<Utilities.DetalleProducto> DevolucionesVenta(string numero)
        {
            var devolucions = new List<Utilities.DetalleProducto>();
            var tabla = ConsultaFactura(numero);
            foreach (DataRow row in tabla.Rows)
            {
                var detalle = new Utilities.DetalleProducto();
                detalle.Codigo = row["codigo"].ToString();
                detalle.Medida = Convert.ToInt32(row["idmedida"]);
                detalle.Color = Convert.ToInt32(row["idcolor"]);
                detalle.Cantidad = Convert.ToDouble(row["cantidad"]);
                devolucions.Add(detalle);
            }
            return devolucions;
        }

        public DataTable Devoluciones(int idEstado, int idCaja, DateTime fecha)
        {
            return miDaoDevolucion.Devoluciones(idEstado, idCaja, fecha);
        }

        public DataTable Devoluciones(int idCaja, DateTime fecha)
        {
            return miDaoDevolucion.Devoluciones(idCaja, fecha);
        }

        public DataTable Devoluciones(DateTime fecha)
        {
            return miDaoDevolucion.Devoluciones(fecha);
        }

        public DataSet IvaDevolucion(int idCaja, DateTime fecha)
        {
            return miDaoDevolucion.IvaDevolucion(idCaja, fecha);
        }

        // Funcion de actualización 23/05/2018
        
        public List<IvaDevolucion> IvaDevoluciones(int idCaja, DateTime fecha)
        {
            return this.miDaoDevolucion.IvaDevoluciones(idCaja, fecha);
        }

        public List<IvaDevolucion> IvaDevoluciones(DateTime fecha)
        {
            return this.miDaoDevolucion.IvaDevoluciones(fecha);
        }

        public List<IvaDevolucion> IvaDevoluciones(DateTime fecha, DateTime fecha2)
        {
            return miDaoDevolucion.IvaDevoluciones(fecha, fecha2);
        }

        public DataTable TIvaDevoluciones(int idCaja, DateTime fecha)
        {
            return this.TableDetalleIvaDevoluciones(this.miDaoDevolucion.IvaDevoluciones(idCaja, fecha));
        }

        public DataTable TIvaDevoluciones(DateTime fecha)
        {
            return this.TableDetalleIvaDevoluciones(this.miDaoDevolucion.IvaDevoluciones(fecha));
        }

        public DataTable TIvaDevoluciones(DateTime fecha, DateTime fecha2)
        {
            return this.TableDetalleIvaDevoluciones(this.miDaoDevolucion.IvaDevoluciones(fecha, fecha2));
        }

        private DataTable TableDetalleIvaDevoluciones(List<IvaDevolucion> ivaDevoluciones)
        {
            var tabla = new DataTable();
            tabla.TableName = "IvaDevolucion";
            tabla.Columns.Add(new DataColumn("NoFrv", typeof(string)));
            tabla.Columns.Add(new DataColumn("IvaD", typeof(string)));
            tabla.Columns.Add(new DataColumn("BaseD", typeof(double)));
            tabla.Columns.Add(new DataColumn("VIvaD", typeof(double)));
            tabla.Columns.Add(new DataColumn("SubTotalD", typeof(int)));
            foreach (var ivaDevolucion in ivaDevoluciones)
            {
                var row = tabla.NewRow();
                if (ivaDevolucion.NoFactura.Equals(""))
                {
                    row["NoFrv"] = "Frv. General";
                }
                else
                {
                    row["NoFrv"] = ivaDevolucion.NoFactura;
                }
                row["IvaD"] = ivaDevolucion.PorcentajeIva;
                row["BaseD"] = ivaDevolucion.BaseI;
                row["VIvaD"] = ivaDevolucion.ValorIva;
                row["SubTotalD"] = ivaDevolucion.Total;
                tabla.Rows.Add(row);
            }
            return tabla;
        }
        
        // Fin función de actualización 23/05/2018

        public DataSet IvaDevolucion(DateTime fecha)
        {
            return miDaoDevolucion.IvaDevolucion(fecha);
        }

        public int TotalDevoluciones(DateTime fecha, DateTime fecha2, int idCaja, int idTurno)
        {
            return miDaoDevolucion.TotalDevoluciones(fecha, fecha2, idCaja, idTurno);
        }

        public int TotalDevolucionesComplemento(DateTime fecha, DateTime fecha2, int idCaja, int idTurno)
        {
            return miDaoDevolucion.TotalDevolucionesComplemento(fecha, fecha2, idCaja, idTurno);
        }

        public int TotalDevoluciones(DateTime fecha, int idCaja, int idTurno)
        {
            return miDaoDevolucion.TotalDevoluciones(fecha, idCaja, idTurno);
        }

        public int TotalDevolucionesHoras(DateTime fecha, DateTime fecha2, int idCaja, int idTurno)
        {
            return miDaoDevolucion.TotalDevolucionesHoras(fecha, fecha2, idCaja, idTurno);
        }

        public int TotalDevolucionRemision(int idCaja, DateTime fecha, DateTime fecha2)
        {
            return miDaoDevolucion.TotalDevolucionRemision(idCaja, fecha, fecha2);
        }

        /// <summary>
        /// Obtiene la consulta de las devoluciones según el número de la factura.
        /// </summary>
        /// <param name="numero">Número de la factura a consultar.</param>
        /// <returns></returns>
        public DataTable ConsultaFactura(string numero)
        {
            return miDaoDevolucion.ConsultaFactura(numero);
        }

        /// <summary>
        /// Obtiene el total de registros de la consulta de las devoluciones según una fecha.
        /// </summary>
        /// <param name="fecha">Fecha a la cual se le hace la consulta.</param>
        /// <param name="saldo">Indica si la consulta es a devoluciones con saldo o canceladas.</param>
        /// <returns></returns>
        public DataTable ConsultaFecha(DateTime fecha, bool saldo)
        {
            return miDaoDevolucion.ConsultaFecha(fecha, saldo);
        }

        /// <summary>
        /// Obtiene la consulta de las devoluciones según el número de la factura.
        /// </summary>
        /// <param name="numero">Número de la factura a consultar.</param>
        /// <param name="saldo">Indica si la consulta es a devoluciones con saldo o canceladas</param>
        /// <returns></returns>
        public DataTable ConsultaFactura(string numero, bool saldo)
        {
            return miDaoDevolucion.ConsultaFactura(numero, saldo);
        }

        /// <summary>
        /// Obtiene la consulta de las devoluciones según el Nit del cliente.
        /// </summary>
        /// <param name="nit">Nit del cliente a consultar.</param>
        /// <param name="saldo">Indica si la consulta es a devoluciones con saldo o canceladas</param>
        /// <param name="rowBase">Registro base para la consulta.</param>
        /// <param name="rowMax">Número de registros a recuperar.</param>
        /// <returns></returns>
        public DataTable ConsultaCliente(string nit, bool saldo, int rowBase, int rowMax)
        {
            return miDaoDevolucion.ConsultaCliente(nit, saldo, rowBase, rowMax);
        }

        /// <summary>
        /// Obtiene el total de registros de la consulta de las devoluciones según el Nit del cliente.
        /// </summary>
        /// <param name="nit">Nit del cliente a consultar.</param>
        /// <param name="saldo">Indica si la consulta es a devoluciones con saldo o canceladas.</param>
        /// <returns></returns>
        public long GetRowsConsultaCliente(string nit, bool saldo)
        {
            return miDaoDevolucion.GetRowsConsultaCliente(nit, saldo);
        }

        /// <summary>
        /// Obtiene el total de registros de la consulta de las devoluciones según el nombre del cliente.
        /// </summary>
        /// <param name="nombre">Nombre del cliente a consultar.</param>
        /// <param name="saldo">Indica si la consulta es a devoluciones con saldo o canceladas.</param>
        /// <param name="rowBase">Registro base para la consulta.</param>
        /// <param name="rowMax">Número de registros a recuperar.</param>
        /// <returns></returns>
        public DataTable ConsultaClienteName(string nombre, bool saldo, int rowBase, int rowMax)
        {
            return miDaoDevolucion.ConsultaClienteName(nombre, saldo, rowBase, rowMax);
        }

        /// <summary>
        /// Obtiene el total de registros de la consulta de las devoluciones según el nombre del cliente.
        /// </summary>
        /// <param name="nombre">Nombre del cliente a consultar.</param>
        /// <param name="saldo">Indica si la consulta es a devoluciones con saldo o canceladas.</param>
        /// <returns></returns>
        public long GetRowsConsultaClienteName(string nombre, bool saldo)
        {
            return miDaoDevolucion.GetRowsConsultaClienteName(nombre, saldo);
        }

        #endregion

        #region Devolucion Remisión

        public void IngresarRemision(Devolucion devolucion)
        {
            miDaoDevolucion.IngresarRemision(devolucion);
        }

        /// <summary>
        /// Obtiene el resultado de la consulta de una Devolución de Remisión.
        /// </summary>
        /// <param name="numero">Número de Remisión a consultar.</param>
        /// <returns></returns>
        public DataTable ConsultaRemision(int numero)
        {
            return miDaoDevolucion.ConsultaRemision(numero);
        }

        public int SaldoRemision(int numero)
        {
            return miDaoDevolucion.SaldoRemision(numero);
        }


        public List<Utilities.DetalleProducto> DevolucionesRemision(int numero)
        {
            var devoluciones = new List<Utilities.DetalleProducto>();
            var tabla = ConsultaRemision(numero);
            foreach (DataRow row in tabla.Rows)
            {
                var detalle = new Utilities.DetalleProducto();
                detalle.Codigo = row["codigo"].ToString();
                detalle.Medida = Convert.ToInt32(row["idmedida"]);
                detalle.Color = Convert.ToInt32(row["idcolor"]);
                detalle.Cantidad = Convert.ToDouble(row["cantidad"]);
                devoluciones.Add(detalle);
            }
            tabla = null;
            return devoluciones;
        }

        #endregion

        #region Devolución de Compra

        public int IngresarCompra(FacturaProveedor devolucion)
        {
            return miDaoDevolucion.IngresarCompra(devolucion);
        }

        public FacturaProveedor DevolucionesDeCompra(int id)
        {
            return miDaoDevolucion.DevolucionesDeCompra(id);
        }

        public DataTable DevolucionesDeCompra(string numero)
        {
            return miDaoDevolucion.DevolucionesDeCompra(numero);
        }

        public DataTable DevolucionesDeCompraProveedor(string proveedor, int rowBase, int rowMax)
        {
            return miDaoDevolucion.DevolucionesDeCompraProveedor(proveedor, rowBase, rowMax);
        }

        public long GetRowsDevolucionesDeCompraProveedor(string proveedor)
        {
            return miDaoDevolucion.GetRowsDevolucionesDeCompraProveedor(proveedor);
        }

        public DataTable DevolucionesDeCompra(DateTime fecha, int rowBase, int rowMax)
        {
            return miDaoDevolucion.DevolucionesDeCompra(fecha, rowBase, rowMax);
        }

        public long GetRowsDevolucionesDeCompra(DateTime fecha)
        {
            return miDaoDevolucion.GetRowsDevolucionesDeCompra(fecha);
        }

        public DataTable DevolucionesDeCompra(DateTime fecha, DateTime fecha2, int rowBase, int rowMax)
        {
            return miDaoDevolucion.DevolucionesDeCompra(fecha, fecha2, rowBase, rowMax);
        }

        public long GetRowsDevolucionesDeCompra(DateTime fecha, DateTime fecha2)
        {
            return miDaoDevolucion.GetRowsDevolucionesDeCompra(fecha, fecha2);
        }


        public DataTable DetalleDevolucionCompra(int idDevolucion)
        {
            return miDaoDevolucion.DetalleDevolucionCompra(idDevolucion);
        }

        #endregion

        #region Saldos en Devolucion de Venta

        public int IngresarSaldoDevolucionVenta
            (string factura, int valor, int idUsuario, int idCaja, DateTime fecha)
        {
            return miDaoDevolucion.IngresarSaldoDevolucionVenta
                    (factura, valor, idUsuario, idCaja, fecha);
        }

        public List<Ingreso> IngresarSaldoGeneralDevolucionVenta
            (string cliente, ref int valor, int idUsuario, int idCaja, DateTime fecha)
        {
            return miDaoDevolucion.IngresarSaldoGeneralDevolucionVenta
                                    (cliente, ref valor, idUsuario, idCaja, fecha);
        }

        public int SaldoDevolucionVenta(string factura)
        {
            return miDaoDevolucion.SaldoDevolucionVenta(factura);
        }

        public Saldo SaldoDevolucionVenta(string factura, bool data)
        {
            return miDaoDevolucion.SaldoDevolucionVenta(factura, data);
        }

        public DataTable SaldosDeDevolucionVenta(int id)
        {
            return miDaoDevolucion.SaldosDeDevolucionVenta(id);
        }

        public int SaldoDevolucionVenta(int id)
        {
            return miDaoDevolucion.SaldoDevolucionVenta(id);
        }

        public DataTable SaldosDeDevolucion(int idCaja, DateTime fecha)
        {
            return miDaoDevolucion.SaldosDeDevolucion(idCaja, fecha);
        }

        #endregion

        #region Saldos en Devolucion de Compra

        public bool ExisteSaldoCompra(int codigoProveedor)
        {
            return this.miDaoDevolucion.ExisteSaldoCompra(codigoProveedor);
        }

        public int SaldoCompra(int codigoProveedor)
        {
            return this.miDaoDevolucion.SaldoCompra(codigoProveedor);
        }

        public int IngresarSaldoCompra(Bono saldo)
        {
            return miDaoDevolucion.IngresarSaldoCompra(saldo);
        }

        public void EditarSaldoCompra(int codigoProveedor, int valor)
        {
            this.miDaoDevolucion.EditarSaldoCompra(codigoProveedor, valor);
        }

        public double SaldoDevolucionCompra_(int idFactura)
        {
            return this.miDaoDevolucion.SaldoDevolucionCompra_(idFactura);
        }



        public int SaldoDevolucionCompra(int idFactura)
        {
            return miDaoDevolucion.SaldoDevolucionCompra(idFactura);
        }

        public void SaldarDevolucionCompra(int idDevolucion)
        {
            miDaoDevolucion.SaldarDevolucionCompra(idDevolucion);
        }

        #endregion


        public DataTable Repetidos()
        {
            return this.miDaoDevolucion.Repetidos();
        }

        public void LimpiarSpace_ProduDupli()
        {
            this.miDaoDevolucion.LimpiarSpace_ProduDupli();
        }
    }
}