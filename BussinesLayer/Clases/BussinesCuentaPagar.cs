using System;
using System.Data;
using DataAccessLayer.Clases;
using DTO.Clases;

namespace BussinesLayer.Clases
{
    public class BussinesCuentaPagar
    {
        private DaoCuentaPagar miDaoCuentaPagar;

        public BussinesCuentaPagar()
        {
            this.miDaoCuentaPagar = new DaoCuentaPagar();
        }

        public int Ingresar(CuentaPagar cuenta)
        {
            return miDaoCuentaPagar.Ingresar(cuenta);
        }

        public void IngresarDetalle(DetalleCuentaPagar detalle)
        {
            miDaoCuentaPagar.IngresarDetalle(detalle);
        }

        public DataTable CuentasPorPagar(int rowBase, int rowMax)
        {
            return miDaoCuentaPagar.CuentasPorPagar(rowBase, rowMax);
        }

        public long GetRowsCuentasPorPagar()
        {
            return miDaoCuentaPagar.GetRowsCuentasPorPagar();
        }

        public DataTable CuentasPorPagar(string tercero, int rowBase, int rowMax)
        {
            return miDaoCuentaPagar.CuentasPorPagar(tercero, rowBase, rowMax);
        }

        public long GetRowsCuentasPorPagar(string tercero)
        {
            return miDaoCuentaPagar.GetRowsCuentasPorPagar(tercero);
        }

        public DataTable CuentasPorPagar(DateTime fecha, int rowBase, int rowMax)
        {
            return miDaoCuentaPagar.CuentasPorPagar(fecha, rowBase, rowMax);
        }

        public long GetRowsCuentasPorPagar(DateTime fecha)
        {
            return miDaoCuentaPagar.GetRowsCuentasPorPagar(fecha);
        }

        public DataTable CuentasPorPagar
            (DateTime fecha, DateTime fecha2, int rowBase, int rowMax)
        {
            return miDaoCuentaPagar.CuentasPorPagar(fecha, fecha2, rowBase, rowMax);
        }

        public long GetRowsCuentasPorPagar(DateTime fecha, DateTime fecha2)
        {
            return miDaoCuentaPagar.GetRowsCuentasPorPagar(fecha, fecha2);
        }

        public DataTable CuentasPorPagar(string tercero, DateTime fecha, int rowBase, int rowMax)
        {
            return miDaoCuentaPagar.CuentasPorPagar(tercero, fecha, rowBase, rowMax);
        }

        public long GetRowsCuentasPorPagar(string tercero, DateTime fecha)
        {
            return miDaoCuentaPagar.GetRowsCuentasPorPagar(tercero, fecha);
        }

        public DataTable CuentasPorPagar
            (string tercero, DateTime fecha, DateTime fecha2, int rowBase, int rowMax)
        {
            return 
                miDaoCuentaPagar.CuentasPorPagar(tercero, fecha, fecha2, rowBase, rowMax);
        }

        public long GetRowsCuentasPorPagar(string tercero, DateTime fecha, DateTime fecha2)
        {
            return miDaoCuentaPagar.GetRowsCuentasPorPagar(tercero, fecha, fecha2);
        }

        public DataTable CuentasPorPagarNoSaldadas(int idTercero)
        {
            return miDaoCuentaPagar.CuentasPorPagarNoSaldadas(idTercero);
        }

        public void EditarCuentaPagar(int idCuentaPagar)
        {
            miDaoCuentaPagar.EditarCuentaPagar(idCuentaPagar);
        }

        public void EditarCuentaPagar(CuentaPagar cuenta)
        {
            miDaoCuentaPagar.EditarCuentaPagar(cuenta);
        }

        public void EditarCuentaPagarAnular(int idCuentaPagar)
        {
            miDaoCuentaPagar.EditarCuentaPagarAnular(idCuentaPagar);
        }

        // Consulta de Detalles de Cuenta por Pagar.
        public DataTable Detalles(int idCuenta)
        {
            return miDaoCuentaPagar.Detalles(idCuenta);
        }

        public void EliminarDetalle(int idDetalle)
        {
            miDaoCuentaPagar.EliminarDetalle(idDetalle);
        }

        // Consulta Retenciones de Cuenta por Pagar.
        public DataTable Retenciones(int idCuenta)
        {
            return miDaoCuentaPagar.Retenciones(idCuenta);
        }



        // Funciones para la impresion de informes.
        public DataTable CuentasPorPagar()
        {
            return miDaoCuentaPagar.CuentasPorPagar();
        }

        public DataTable CuentasPorPagar(string tercero)
        {
            return miDaoCuentaPagar.CuentasPorPagar(tercero);
        }

        public DataTable CuentasPorPagar(DateTime fecha)
        {
            return miDaoCuentaPagar.CuentasPorPagar(fecha);
        }

        public DataTable CuentasPorPagar(DateTime fecha, DateTime fecha2)
        {
            return miDaoCuentaPagar.CuentasPorPagar(fecha, fecha2);
        }

        public DataTable CuentasPorPagar(string tercero, DateTime fecha)
        {
            return miDaoCuentaPagar.CuentasPorPagar(tercero, fecha);
        }

        public DataTable CuentasPorPagar(string tercero, DateTime fecha, DateTime fecha2)
        {
            return miDaoCuentaPagar.CuentasPorPagar(tercero, fecha, fecha2);
        }



        /// 
        /// Abonos a Cuentas por Pagar
        ///
        public void IngresarAbonoCuentaPorPagar(FormaPago pago)
        {
            miDaoCuentaPagar.IngresarAbonoCuentaPorPagar(pago);
        }

        public DataTable AbonosCuentasPorPagar(int idCuenta)
        {
            return miDaoCuentaPagar.AbonosCuentasPorPagar(idCuenta);
        }

        /// 
        /// Cruces a Cuentas por Pagar
        ///
        public void IngresarCruceCuentaPorPagar(CruceCuentaPagar pago)
        {
            miDaoCuentaPagar.IngresarCruceCuentaPorPagar(pago);
        }

        public DataTable CrucesCuentasPorPagar(int idCuenta)
        {
            return miDaoCuentaPagar.CrucesCuentasPorPagar(idCuenta);
        }
    }
}