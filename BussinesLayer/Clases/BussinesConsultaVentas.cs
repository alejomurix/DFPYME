using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO.Clases;
using DataAccessLayer.Clases;

namespace BussinesLayer.Clases
{
    public class BussinesConsultaVentas
    {
        private DaoConsultaVentas miDaoConsultaVenta;

        public BussinesConsultaVentas()
        {
            this.miDaoConsultaVenta = new DaoConsultaVentas();
        }

        // todas + fecha
        public List<ConsultaImpuesto> ConsultaImpVenta(DateTime fecha)
        {
            return this.miDaoConsultaVenta.ConsultaImpVenta(fecha);
        }

        // todas + periodo
        public List<ConsultaImpuesto> ConsultaImpVenta(DateTime fecha, DateTime fecha2)
        {
            return this.miDaoConsultaVenta.ConsultaImpVenta(fecha, fecha2);
        }

        // estado + fecha
        public List<ConsultaImpuesto> ConsultaImpVenta(int idEstado, DateTime fecha)
        {
            return this.miDaoConsultaVenta.ConsultaImpVenta(idEstado,  fecha);
        }

        // estado + periodo
        public List<ConsultaImpuesto> ConsultaImpVenta(int idEstado, DateTime fecha, DateTime fecha2)
        {
            return this.miDaoConsultaVenta.ConsultaImpVenta(idEstado, fecha, fecha2);
        }


        // todas + cliente + fecha
        public List<ConsultaImpuesto> ConsultaImpVenta(string cliente, DateTime fecha)
        {
            return this.miDaoConsultaVenta.ConsultaImpVenta(cliente, fecha);
        }

        // todas + cliente + periodo
        public List<ConsultaImpuesto> ConsultaImpVenta(string cliente, DateTime fecha, DateTime fecha2)
        {
            return this.miDaoConsultaVenta.ConsultaImpVenta(cliente, fecha, fecha2);
        }

        // todas + usuario + fecha
        public List<ConsultaImpuesto> ConsultaImpVentaUsuario(int idUsuario, DateTime fecha)
        {
            return this.miDaoConsultaVenta.ConsultaImpVentaUsuario(idUsuario, fecha);
        }

        // todas + usuario + periodo
        public List<ConsultaImpuesto> ConsultaImpVentaUsuario(int idUsuario, DateTime fecha, DateTime fecha2)
        {
            return this.miDaoConsultaVenta.ConsultaImpVentaUsuario(idUsuario, fecha, fecha2);
        }


        // estado + cliente + fecha
        public List<ConsultaImpuesto> ConsultaImpVenta(int idEstado, string cliente, DateTime fecha)
        {
            return this.miDaoConsultaVenta.ConsultaImpVenta(idEstado, cliente, fecha);
        }

        // estado + cliente + periodo
        public List<ConsultaImpuesto> ConsultaImpVenta(int idEstado, string cliente, DateTime fecha, DateTime fecha2)
        {
            return this.miDaoConsultaVenta.ConsultaImpVenta(idEstado, cliente, fecha, fecha2);
        }

        // estado + usuario + fecha
        public List<ConsultaImpuesto> ConsultaImpVentaUsuario(int idEstado, int idUsuario, DateTime fecha)
        {
            return this.miDaoConsultaVenta.ConsultaImpVentaUsuario(idEstado, idUsuario, fecha);
        }

        // estado + usuario + periodo
        public List<ConsultaImpuesto> ConsultaImpVentaUsuario(int idEstado, int idUsuario, DateTime fecha, DateTime fecha2)
        {
            return this.miDaoConsultaVenta.ConsultaImpVentaUsuario(idEstado, idUsuario, fecha, fecha2);
        }
    }
}