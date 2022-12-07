using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer.Clases;
using DTO.Clases;

namespace BussinesLayer.Clases
{
    public class BussinesCompraSimple
    {
        private DaoCompraSimple miDaoCompraSimple;

        public BussinesCompraSimple()
        {
            this.miDaoCompraSimple = new DaoCompraSimple();
        }

        // ****************************************************************************************
        //  DESCUENTOS

        public DataTable Descuentos()
        {
            return this.miDaoCompraSimple.Descuentos();
        }

        // ****************************************************************************************

        // ****************************************************************************************
        //      COMPRA SIMPLE

        public int IngresarCompra(FacturaProveedor factura)
        {
            return this.miDaoCompraSimple.IngresarCompra(factura);
        }



        // TODOS + FECHA
        public DataTable Compras(DateTime fecha, int rowIndex, int rowMax)
        {
            return this.miDaoCompraSimple.Compras(fecha, rowIndex, rowMax);
        }

        public long CountCompras(DateTime fecha)
        {
            return this.miDaoCompraSimple.CountCompras(fecha);
        }

        // TODOS + PERIODO
        public DataTable Compras(DateTime fecha, DateTime fecha2, int rowIndex, int rowMax)
        {
            return this.miDaoCompraSimple.Compras(fecha, fecha2, rowIndex, rowMax);
        }

        public long CountCompras(DateTime fecha, DateTime fecha2)
        {
            return this.miDaoCompraSimple.CountCompras(fecha, fecha2);
        }

        // PROVEEDOR
        public DataTable Compras(int codProveedor, int rowIndex, int rowMax)
        {
            return this.miDaoCompraSimple.Compras(codProveedor, rowIndex, rowMax);
        }

        public long CountCompras(int codProveedor)
        {
            return this.miDaoCompraSimple.CountCompras(codProveedor);
        }

        // PROVEEDOR + FECHA
        public DataTable Compras(int codProveedor, DateTime fecha, int rowIndex, int rowMax)
        {
            return this.miDaoCompraSimple.Compras(codProveedor, fecha, rowIndex, rowMax);
        }

        public long CountCompras(int codProveedor, DateTime fecha)
        {
            return this.miDaoCompraSimple.CountCompras(codProveedor, fecha);
        }

        // PROVEEDOR + PERIODO
        public DataTable Compras(int codProveedor, DateTime fecha, DateTime fecha2, int rowIndex, int rowMax)
        {
            return this.miDaoCompraSimple.Compras(codProveedor, fecha, fecha2, rowIndex, rowMax);
        }

        public long CountCompras(int codProveedor, DateTime fecha, DateTime fecha2)
        {
            return this.miDaoCompraSimple.CountCompras(codProveedor, fecha, fecha2);
        }


        public DataTable Compras(DateTime fecha)
        {
            return this.miDaoCompraSimple.Compras(fecha);
        }

        public DataTable Compras(DateTime fecha, DateTime fecha2)
        {
            return this.miDaoCompraSimple.Compras(fecha, fecha2);
        }

        public DataTable Compras(int codProveedor)
        {
            return this.miDaoCompraSimple.Compras(codProveedor);
        }

        public DataTable Compras(int codProveedor, DateTime fecha)
        {
            return this.miDaoCompraSimple.Compras(codProveedor, fecha);
        }

        public DataTable Compras(int codProveedor, DateTime fecha, DateTime fecha2)
        {
            return this.miDaoCompraSimple.Compras(codProveedor, fecha, fecha2);
        }


        public DataTable ResumenCompra(DateTime fecha)
        {
            return this.miDaoCompraSimple.ResumenCompra(fecha);
        }

        public DataTable ResumenCompra(DateTime fecha, DateTime fecha2)
        {
            return this.miDaoCompraSimple.ResumenCompra(fecha, fecha2);
        }

        public DataTable ResumenCompra(int codProveedor, DateTime fecha)
        {
            return this.miDaoCompraSimple.ResumenCompra(codProveedor, fecha);
        }

        public DataTable ResumenCompra(int codProveedor, DateTime fecha, DateTime fecha2)
        {
            return this.miDaoCompraSimple.ResumenCompra(codProveedor, fecha, fecha2);
        }


        public List<FacturaProveedor> Cartera(int codProveedor)
        {
            return this.miDaoCompraSimple.Cartera(codProveedor);
        }


        public int AjustarCompraPagos(int id)
        {
            return this.miDaoCompraSimple.AjustarCompraPagos(id);
        }

        // ****************************************************************************************
        //      PRODUCTO COMPRA SIMPLE
        public void IngresarProductoCompra(ProductoFacturaProveedor producto)
        {
            this.miDaoCompraSimple.IngresarProductoCompra(producto);
        }

        public DataTable ProductosDeCompra(int idCompra)
        {
            return this.miDaoCompraSimple.ProductosDeCompra(idCompra);
        }

        public void EditarProducto(ProductoFacturaProveedor producto, bool suma)
        {
            this.miDaoCompraSimple.EditarProducto(producto, suma);
        }

        public void EliminarProducto(int id)
        {
            this.miDaoCompraSimple.EliminarProducto(id);
        }

        // ****************************************************************************************
        //      DESCUENTO COMPRA SIMPLE

        public void IngresarDescuentoCompra(Descuento descuento)
        {
            this.miDaoCompraSimple.IngresarDescuentoCompra(descuento);
        }

        public DataTable Descuentos(int idCompra)
        {
            return this.miDaoCompraSimple.Descuentos(idCompra);
        }


        public DataTable ResumenDescuentos(DateTime fecha)
        {
            return this.miDaoCompraSimple.ResumenDescuentos(fecha);
        }

        public DataTable ResumenDescuentos(DateTime fecha, DateTime fecha2)
        {
            return this.miDaoCompraSimple.ResumenDescuentos(fecha, fecha2);
        }

        public DataTable ResumenDescuentos(int codProveedor, DateTime fecha)
        {
            return this.miDaoCompraSimple.ResumenDescuentos(codProveedor, fecha);
        }

        public DataTable ResumenDescuentos(int codProveedor, DateTime fecha, DateTime fecha2)
        {
            return this.miDaoCompraSimple.ResumenDescuentos(codProveedor, fecha, fecha2);
        }


        public void EditarDescuento(int id, int valor)
        {
            this.miDaoCompraSimple.EditarDescuento(id, valor);
        }

        public void EliminarDescuento(int id)
        {
            this.miDaoCompraSimple.EliminarDescuento(id);
        }


        // ****************************************************************************************
        //      PAGO COMPRA SIMPLE

        public void IngresarPagoCompra(FormaPago pago)
        {
            this.miDaoCompraSimple.IngresarPagoCompra(pago);
        }

        public string IngresarPagoGeneral(int codProveedor, int valor, List<FacturaProveedor> cartera)
        {
            return this.miDaoCompraSimple.IngresarPagoGeneral(codProveedor, valor, cartera);
        }


        public int ResumenPago(DateTime fecha)
        {
            return this.miDaoCompraSimple.ResumenPago(fecha);
        }

        public int ResumenPago(DateTime fecha, DateTime fecha2)
        {
            return this.miDaoCompraSimple.ResumenPago(fecha, fecha2);
        }

        public int ResumenPago(int codProveedor, DateTime fecha)
        {
            return this.miDaoCompraSimple.ResumenPago(codProveedor, fecha);
        }

        public int ResumenPago(int codProveedor, DateTime fecha, DateTime fecha2)
        {
            return this.miDaoCompraSimple.ResumenPago(codProveedor, fecha, fecha2);
        }
    }
}