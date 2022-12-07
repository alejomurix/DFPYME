using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DataAccessLayer.Clases;

namespace BussinesLayer.Clases
{
    public class BussinesConsultaSQL
    {
        private DaoConsultaSQL miDaoConsultaSQL;

        public BussinesConsultaSQL()
        {
            this.miDaoConsultaSQL = new DaoConsultaSQL();
        }

        public void NuevaConexion()
        {
            this.miDaoConsultaSQL.NuevaConexion();
        }




        public DataTable Consulta(string sql)
        {
            return this.miDaoConsultaSQL.Consulta(sql);
        }


        public DataTable IvaEnVentas(DateTime fecha, DateTime fecha2)
        {
            return miDaoConsultaSQL.IvaEnVentas(fecha, fecha2);
        }

        public DataTable IvaEnDevoluciones(DateTime fecha, DateTime fecha2)
        {
            return miDaoConsultaSQL.IvaEnDevoluciones(fecha, fecha2);
        }

        public DataTable IvaDeCosto(string codigos, DateTime fecha, DateTime fecha2)
        {
            return miDaoConsultaSQL.IvaDeCosto(codigos, fecha, fecha2);
        }

        public DataTable IvaVentaParaCosto(string codigos, DateTime fecha, DateTime fecha2)
        {
            return miDaoConsultaSQL.IvaVentaParaCosto(codigos, fecha, fecha2);
        }


        public void ActualizarTotalProductoVenta(DateTime fecha, DateTime fecha2)
        {
            miDaoConsultaSQL.ActualizarTotalProductoVenta(fecha, fecha2);
        }


        public void InflarValorBaseVenta()
        {
            miDaoConsultaSQL.InflarValorBaseVenta();
        }


        public void ExecuteNonQuery(string query)
        {
            miDaoConsultaSQL.ExecuteNonQuery(query);
        }

        public DataTable ConsultaIvaCategorias(DateTime fecha, DateTime fecha2, string[] filtro)
        {
            return miDaoConsultaSQL.ConsultaIvaCategorias(fecha, fecha2, filtro);
        }



        public DataTable ConsultaIvaCategoriasFiltroCat(DateTime fecha, DateTime fecha2, string[] filtro)
        {
            return miDaoConsultaSQL.ConsultaIvaCategoriasFiltroCat(fecha, fecha2, filtro);
        }


        public void AjustarCodigosBarrasInterno()
        {
            miDaoConsultaSQL.AjustarCodigosBarrasInterno();
        }


        public void ProductAjust()
        {
            miDaoConsultaSQL.ProductAjust();
        }
    }
}