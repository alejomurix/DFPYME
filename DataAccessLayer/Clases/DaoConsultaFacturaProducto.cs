using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using DTO.Clases;
using System.Data;

namespace DataAccessLayer.Clases
{
    public class DaoConsultaFacturaProducto
    {
        /// <summary>
        /// Representa el objeto de conexión.
        /// </summary>
        private Conexion miConexion;

        /// <summary>
        /// Representa una sentenca en sql.
        /// </summary>
        private NpgsqlCommand miComando;

        /// <summary>
        /// Representa una sentencia adapter en posgres sql.
        /// </summary>
        private NpgsqlDataAdapter miAdapter;

        public DaoConsultaFacturaProducto()
        {
            miConexion = new Conexion();
        }

        public List<ConsultaFacturaProducto> Consulta(DateTime fecha, DateTime fecha2)
        {
            try
            {
                List<ConsultaFacturaProducto> consultas = new List<ConsultaFacturaProducto>();

                string sql = "SELECT factura_venta.fecha_factura_venta, factura_venta.numerofactura_venta, " +
                "producto_factura_venta.cantidadproducto_factura_venta, producto.nombreproducto, producto_factura_venta.valorunitarioproducto_factura_venta, " +
                "producto_factura_venta.valor_descuento, producto_factura_venta.valor_iva FROM factura_venta, producto_factura_venta, " +
                "producto WHERE factura_venta.id = producto_factura_venta.id_factura AND " +
                "producto_factura_venta.codigointernoproducto = producto.codigointernoproducto AND (factura_venta.idestado = 1 OR factura_venta.idestado = 2) AND " +
                "factura_venta.estado = TRUE AND producto_factura_venta.valor_iva = 1e-007 AND producto_factura_venta.retorno = FALSE AND  " +
                "factura_venta.fecha_factura_venta BETWEEN '" + fecha.ToShortDateString() + "' AND '" + fecha2.ToShortDateString() + "' ORDER BY " +
                "factura_venta.fecha_factura_venta, factura_venta.id, producto_factura_venta.idproducto_factura_venta;";

                sql = "SELECT factura_venta.fecha_factura_venta, factura_venta.numerofactura_venta, producto_factura_venta.cantidadproducto_factura_venta, producto.nombreproducto, " + 
                "producto_factura_venta.valorunitarioproducto_factura_venta, producto_factura_venta.valor_descuento, producto_factura_venta.valor_iva FROM factura_venta, producto_factura_venta, " + 
                "producto WHERE factura_venta.id = producto_factura_venta.id_factura AND producto_factura_venta.codigointernoproducto = producto.codigointernoproducto AND " + 
                "(factura_venta.idestado = 1 OR factura_venta.idestado = 2) AND factura_venta.estado = TRUE AND producto_factura_venta.retorno = FALSE AND  " + 
                "factura_venta.fecha_factura_venta BETWEEN '25-04-2020' AND '30-04-2020' AND (producto_factura_venta.codigointernoproducto = '3223' OR " +
                "producto_factura_venta.codigointernoproducto = '4795' OR producto_factura_venta.codigointernoproducto = '167' OR producto_factura_venta.codigointernoproducto = '3781' OR " + 
                "producto_factura_venta.codigointernoproducto = '538' OR producto_factura_venta.codigointernoproducto = '1251' OR producto_factura_venta.codigointernoproducto = '7822' OR " + 
                "producto_factura_venta.codigointernoproducto = '2707' OR producto_factura_venta.codigointernoproducto = '3152') ORDER BY factura_venta.fecha_factura_venta, factura_venta.id, " +
                "producto_factura_venta.idproducto_factura_venta;";

                miComando = new NpgsqlCommand();
                miComando.Connection = miConexion.MiConexion;
                miComando.CommandType = CommandType.Text;
                miComando.CommandText = sql;
                miComando.CommandTimeout = 0;

                miConexion.MiConexion.Open();
                NpgsqlDataReader reader = miComando.ExecuteReader();
                while (reader.Read())
                {
                    var consulta = new ConsultaFacturaProducto();
                    consulta.Fecha = reader.GetDateTime(0);
                    consulta.Numero = reader.GetString(1);
                    consulta.Cantidad = reader.GetDouble(2);
                    consulta.Producto = reader.GetString(3);
                    consulta.Valor = reader.GetDouble(4);
                    consulta.Descuento = reader.GetDouble(5);
                    if (consulta.Descuento > 0)
                    {
                        consulta.Valor = Math.Round((consulta.Valor -
                            (consulta.Valor * consulta.Descuento / 100)), 0);
                    }
                    consulta.Valor = Utilities.UseObject.Aproximar(Convert.ToInt32(consulta.Valor), Convert.ToBoolean(Utilities.AppConfiguracion.ValorSeccion("tipo_aprox_precio")));
                    consulta.Total = Math.Round((consulta.Valor * consulta.Cantidad), 0);
                    consultas.Add(consulta);
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return consultas;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public List<ConsultaComprasCuentas> ConsultaCompras(DateTime fecha, DateTime fecha2)
        {
            try
            {
                List<ConsultaComprasCuentas> consultas = new List<ConsultaComprasCuentas>();
                CargarComando("consulta_compras_contable");
                miComando.Parameters.AddWithValue("", fecha);
                miComando.Parameters.AddWithValue("", fecha2);
                miConexion.MiConexion.Open();
                NpgsqlDataReader reader = miComando.ExecuteReader();
                while (reader.Read())
                {
                    var consulta = new ConsultaComprasCuentas();
                    consulta.Consecutivo = reader.GetInt32(0);
                    consulta.Fecha = reader.GetString(2);
                    consulta.ClaseDocumento = reader.GetString(3);
                   // consulta.SociedadFI = "FON1";
                    //consulta.FechaContable = reader.GetString(2);
                    //consulta.Moneda = "COP";
                    //consulta.Norma = reader.GetString(2);
                    consulta.Referencia = reader.GetString(4);
                    consulta.Texto = reader.GetString(5);
                    consulta.Clave = reader.GetInt32(6).ToString();
                    consulta.CodProveedor = reader.GetInt32(8);
                    consulta.CuentaTercero = reader.GetString(9);
                    consulta.Cuenta = reader.GetString(10);
                    //consulta.IndicadorCME = reader.GetString(2);
                    consulta.Importe = Convert.ToInt32(reader.GetDouble(11));
                    consulta.IndicadorImpuesto = reader.GetString(12);
                    //consulta.CentroCosto = reader.GetString(2);
                    //consulta.ViaPago = reader.GetString(2);
                    //consulta.BloqueoPago = reader.GetString(2);
                    consultas.Add(consulta);
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return consultas;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }


        private void CargarComando(string cmd)
        {
            this.miComando = new NpgsqlCommand();
            this.miComando.Connection = this.miConexion.MiConexion;
            this.miComando.CommandType = CommandType.StoredProcedure;
            this.miComando.CommandText = cmd;
        }
    }
}