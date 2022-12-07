using System;
using System.Linq;
using System.Data;
using DataAccessLayer.Clases;
using DTO.Clases;

namespace BussinesLayer.Clases
{
    public class BussinesRetencion
    {
        private DaoRetencion miDaoRetencion;

        public BussinesRetencion()
        {
            this.miDaoRetencion = new DaoRetencion();
        }

        #region Retencion

        public int IngresarRubro(string rubro)
        {
            return miDaoRetencion.IngresarRubro(rubro);
        }

        public DataTable Rubros()
        {
            return miDaoRetencion.Rubros();
        }

        public void EditarRubro(int id, string rubro)
        {
            miDaoRetencion.EditarRubro(id, rubro);
        }

        public void EliminarRubro(int id)
        {
            miDaoRetencion.EliminarRubro(id);
        }

        public int IngresarConcepto(RetencionConcepto concepto)
        {
            return miDaoRetencion.IngresarConcepto(concepto);
        }

        public DataTable Conceptos(int idRubro)
        {
            return miDaoRetencion.Conceptos(idRubro);
        }

        public void EditarConcepto(RetencionConcepto concepto)
        {
            miDaoRetencion.EditarConcepto(concepto);
        }

        public void EliminarConcepto(int idConcepto)
        {
            miDaoRetencion.EliminarConcepto(idConcepto);
        }

        #endregion

        #region ReteCompra

        public DataTable RetencionesAplicadasACompra(int idEmpresaCompra, int idEmpresaVende)
        {
            return miDaoRetencion.RetencionesAplicadasACompra(idEmpresaCompra, idEmpresaVende);
        }

        public DataTable RetencionesAplicadasACompra
            (int idEmpresaCompra, int idEmpresaVende, int idReteAplicada)
        {
            return miDaoRetencion.RetencionesAplicadasACompra
                (idEmpresaCompra, idEmpresaVende, idReteAplicada);
        }

        public bool ExisteReteCompra(int idEmpresaCompra, int idEmpresaVende)
        {
            return miDaoRetencion.ExisteReteCompra(idEmpresaCompra, idEmpresaVende);
        }

        public int IdReteCompra(int idEmpresaCompra, int idEmpresaVende)
        {
            return miDaoRetencion.IdReteCompra(idEmpresaCompra, idEmpresaVende);
        }

        public long IngresarReteCompra(int idRegimenCompra, int idRegimenVende)
        {
            return miDaoRetencion.IngresarReteCompra(idRegimenCompra, idRegimenVende);
        }

        public bool ExisteAplicaReteCompra(int idReteCompra, int idReteConcepto)
        {
            return miDaoRetencion.ExisteAplicaReteCompra(idReteCompra, idReteConcepto);
        }

        public bool ExisteAplicaReteCompra(int idReteCompra)
        {
            return miDaoRetencion.ExisteAplicaReteCompra(idReteCompra);
        }

        public bool ExisteReteConceptoCompra(int idConcepto)
        {
            return miDaoRetencion.ExisteReteConceptoCompra(idConcepto);
        }

        public long IngresarAplicaReteCompra(int idReteCompra, int idReteConcepto)
        {
            return miDaoRetencion.IngresarAplicaReteCompra(idReteCompra, idReteConcepto);
        }

        public void EliminarAplicaReteCompra(int id)
        {
            miDaoRetencion.EliminarAplicaReteCompra(id);
        }

        public DataTable RetencionesACompra(int idFacturaProveedor)
        {
            return miDaoRetencion.RetencionesACompra(idFacturaProveedor);
        }

        #endregion

        #region ReteVenta

        public DataTable RetencionesAplicadasAVenta(int idEmpresaCompra, int idEmpresaVende)
        {
            return miDaoRetencion.RetencionesAplicadasAVenta(idEmpresaCompra, idEmpresaVende);
        }

        public DataTable RetencionesAplicadasAVenta
            (int idEmpresaCompra, int idEmpresaVende, int idReteAplicada)
        {
            return miDaoRetencion.
                    RetencionesAplicadasAVenta(idEmpresaCompra, idEmpresaVende, idReteAplicada);
        }

        public bool ExisteReteVenta(int idEmpresaCompra, int idEmpresaVende)
        {
            return miDaoRetencion.ExisteReteVenta(idEmpresaCompra, idEmpresaVende);
        }

        public int IdReteVenta(int idEmpresaCompra, int idEmpresaVende)
        {
            return miDaoRetencion.IdReteVenta(idEmpresaCompra, idEmpresaVende);
        }

        public long IngresarReteVenta(int idRegimenCompra, int idRegimenVende)
        {
            return miDaoRetencion.IngresarReteVenta(idRegimenCompra, idRegimenVende);
        }

        public bool ExisteAplicaReteVenta(int idReteVenta, int idReteConcepto)
        {
            return miDaoRetencion.ExisteAplicaReteVenta(idReteVenta, idReteConcepto);
        }

        public bool ExisteReteConceptoVenta(int idConcepto)
        {
            return miDaoRetencion.ExisteReteConceptoVenta(idConcepto);
        }

        public long IngresarAplicaReteVenta(int idReteVenta, int idReteConcepto)
        {
            return miDaoRetencion.IngresarAplicaReteVenta(idReteVenta, idReteConcepto);
        }

        public void EliminarAplicaReteVenta(int id)
        {
            miDaoRetencion.EliminarAplicaReteVenta(id);
        }

        public DataTable RetencionesAVenta(string numeroFactura)
        {
            return miDaoRetencion.RetencionesAVenta(numeroFactura);
        }

        public DataTable RetencionesAVenta(int id)
        {
            return miDaoRetencion.RetencionesAVenta(id);
        }

        public void EditarFacturaVentaRetencion(RetencionConcepto retencion)
        {
            miDaoRetencion.EditarFacturaVentaRetencion(retencion);
        }

        public int ValorRetencionAventa(string numeroFactura, bool descuento)
        {
            var retenciones = miDaoRetencion.RetencionesAVenta(numeroFactura);
            var daoFactura = new DaoFacturaVenta();
            var totalFactura = Convert.ToInt32(
                               daoFactura.ProductoFacturaVenta(numeroFactura, descuento).
                               AsEnumerable().Sum(p => p.Field<double>("SubTotal")));
            var totalRete = 0;
            foreach (DataRow row in retenciones.Rows)
            {
                totalRete = Convert.ToInt32(totalFactura * Convert.ToDouble(row["tarifa"]) / 100);
            }
            return totalRete;
        }

        public int ValorRetencionAventa(string numeroFactura, int idFactura, bool descuento)
        {
            var retenciones = miDaoRetencion.RetencionesAVenta(numeroFactura);
            var daoFactura = new DaoFacturaVenta();
            var totalFactura = Convert.ToInt32(
                               daoFactura.ProductoFacturaVenta(idFactura, descuento).
                               AsEnumerable().Sum(p => p.Field<double>("SubTotal")));
            var totalRete = 0;
            foreach (DataRow row in retenciones.Rows)
            {
                totalRete = Convert.ToInt32(totalFactura * Convert.ToDouble(row["tarifa"]) / 100);
            }
            return totalRete;
        }

        #endregion
    }
}