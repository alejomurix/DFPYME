using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO.Clases;
using DataAccessLayer.Clases;

namespace BussinesLayer.Clases
{
    public class BussinesConsultaFacturaProducto
    {
        private DaoConsultaFacturaProducto miDaoConsFacturaProducto;

        private DaoEmpresa miDaoEmpresa;

        public BussinesConsultaFacturaProducto()
        {
            miDaoConsFacturaProducto = new DaoConsultaFacturaProducto();
        }

        public List<ConsultaFacturaProducto> Consulta(DateTime fecha, DateTime fecha2)
        {
            return this.miDaoConsFacturaProducto.Consulta(fecha, fecha2);
        }

        public List<ConsultaComprasCuentas> ConsultaCompras(DateTime fecha, DateTime fecha2)
        {
            try
            {
                miDaoEmpresa = new DaoEmpresa();
                var empresa = miDaoEmpresa.ObtenerEmpresa();
                var consultas = miDaoConsFacturaProducto.ConsultaCompras(fecha, fecha2);

                var listCompras = new List<ConsultaComprasCuentas>();
                var result = from item in consultas
                             group item.Importe by new
                             {
                                 item.Consecutivo,
                                 item.Fecha,
                                 item.ClaseDocumento,
                                 item.Referencia,
                                 item.CuentaTercero//,
                                 //item.IndicadorImpuesto
                             }
                                 into it
                                 select new
                                 {
                                     it.Key.Consecutivo,
                                     it.Key.Fecha,
                                     it.Key.ClaseDocumento,
                                     it.Key.Referencia,
                                     it.Key.CuentaTercero,
                                     Importe = it.Sum()//,
                                     //it.Key.IndicadorImpuesto
                                 };
                
                //Console.WriteLine(result);
                //Console.WriteLine("");
                int cont = 1;
                foreach (var r in result)
                {
                    var reg = new ConsultaComprasCuentas();
                    reg.Consecutivo = cont;
                    reg.Fecha = r.Fecha;
                    reg.ClaseDocumento = r.ClaseDocumento;
                    reg.Referencia = r.Referencia;
                    reg.Texto = r.Referencia + " INV.MERCANCIAS TIENDA " + empresa.Descripcion.Split('-')[1];
                    reg.Clave = "34";
                    reg.Cuenta = r.CuentaTercero;
                    reg.Importe = r.Importe;
                    reg.ViaPago = "C";
                    reg.BloqueoPago = "X";
                    listCompras.Add(reg);
                    foreach (var reg_ in consultas.Where(c => c.Consecutivo.Equals(r.Consecutivo)))
                    {
                        reg = new ConsultaComprasCuentas();
                        reg.Consecutivo = cont;
                        reg.Fecha = reg_.Fecha;
                        reg.ClaseDocumento = reg_.ClaseDocumento;
                        reg.Referencia = reg_.Referencia;
                        reg.Texto = reg_.Texto + empresa.Descripcion.Split('-')[1];
                        reg.Clave = reg_.Clave;
                        reg.Cuenta = reg_.Cuenta;
                        reg.Importe = reg_.Importe;
                        reg.IndicadorImpuesto = reg_.IndicadorImpuesto;
                        reg.CentroCosto = empresa.Descripcion.Split('-')[0];
                        listCompras.Add(reg);
                    }

                    cont++;

                   // Console.WriteLine(r.Fecha + "\t" + r.Referencia + "\t" + r.CuentaTercero + "\t" + r.Importe + "\t" + r.IndicadorImpuesto);
                   // Console.WriteLine(r.Consecutivo + "\t" + r.Fecha + "\t" + r.ClaseDocumento + "\t" + r.Referencia + "\t" + r.CuentaTercero + "\t" + r.Importe);
                }
                /*var query = from items in consultas
                            group items by items.Consecutivo into it
                            orderby it.Key
                            select new ConsultaComprasCuentas()
                            {
                                Consecutivo = it.Key,
                                Fecha = it.Key.*/
                return listCompras; //new List<ConsultaComprasCuentas>();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}