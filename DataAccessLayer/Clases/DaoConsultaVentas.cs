using System;
using System.Linq;
using System.Data;
using DTO.Clases;
using Npgsql;
using System.Collections;
using System.Collections.Generic;
using Utilities;

namespace DataAccessLayer.Clases
{
    public class DaoConsultaVentas
    {
        /// <summary>
        /// Representa un objeto con acceso a la conexión de base de datos Postgresql.
        /// </summary>
        private Conexion miConexion;

        /// <summary>
        /// Representa un comando de ejecucion de sentencias SQL a PostgreSQL.
        /// </summary>
        private NpgsqlCommand miComando;

        /// <summary>
        /// Objeto adaptador de consultas SQL a servidor PostgreSQL.
        /// </summary>
        private NpgsqlDataAdapter miAdapter;



        public DaoConsultaVentas()
        {
            this.miConexion = new Conexion();
        }

        // todas + fecha
        public List<ConsultaImpuesto> ConsultaImpVenta(DateTime fecha)
        {
            try
            {
                List<ConsultaImpuesto> consulta = new List<ConsultaImpuesto>();
                CargarComando("consulta_impuestos_ventas");
                miComando.Parameters.AddWithValue("", fecha);
                miConexion.MiConexion.Open();
                NpgsqlDataReader reader = miComando.ExecuteReader();
                PasarReaderAimpuesto(consulta, reader);
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return consulta;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al realizar la consulta.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        // todas + periodo
        public List<ConsultaImpuesto> ConsultaImpVenta(DateTime fecha, DateTime fecha2)
        {
            try
            {
                List<ConsultaImpuesto> consulta = new List<ConsultaImpuesto>();
                CargarComando("consulta_impuestos_ventas_periodo");
                miComando.Parameters.AddWithValue("", fecha);
                miComando.Parameters.AddWithValue("", fecha2);
                miConexion.MiConexion.Open();
                NpgsqlDataReader reader = miComando.ExecuteReader();
                PasarReaderAimpuesto(consulta, reader);
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return consulta;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al realizar la consulta.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        // estado + fecha
        public List<ConsultaImpuesto> ConsultaImpVenta(int idEstado, DateTime fecha)
        {
            try
            {
                List<ConsultaImpuesto> consulta = new List<ConsultaImpuesto>();
                CargarComando("consulta_impuestos_ventas");
                miComando.Parameters.AddWithValue("", idEstado);
                miComando.Parameters.AddWithValue("", fecha);
                miConexion.MiConexion.Open();
                NpgsqlDataReader reader = miComando.ExecuteReader();
                PasarReaderAimpuesto(consulta, reader);
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return consulta;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al realizar la consulta.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        // estado + periodo
        public List<ConsultaImpuesto> ConsultaImpVenta(int idEstado, DateTime fecha, DateTime fecha2)
        {
            try
            {
                List<ConsultaImpuesto> consulta = new List<ConsultaImpuesto>();
                CargarComando("consulta_impuestos_ventas");
                miComando.Parameters.AddWithValue("", idEstado);
                miComando.Parameters.AddWithValue("", fecha);
                miComando.Parameters.AddWithValue("", fecha2);
                miConexion.MiConexion.Open();
                NpgsqlDataReader reader = miComando.ExecuteReader();
                PasarReaderAimpuesto(consulta, reader);
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return consulta;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al realizar la consulta.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }


        // todas + cliente + fecha
        public List<ConsultaImpuesto> ConsultaImpVenta(string cliente, DateTime fecha)
        {
            try
            {
                List<ConsultaImpuesto> consulta = new List<ConsultaImpuesto>();
                CargarComando("consulta_impuestos_ventas_cliente");
                miComando.Parameters.AddWithValue("", cliente);
                miComando.Parameters.AddWithValue("", fecha);
                miConexion.MiConexion.Open();
                NpgsqlDataReader reader = miComando.ExecuteReader();
                PasarReaderAimpuesto(consulta, reader);
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return consulta;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al realizar la consulta.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        // todas + cliente + periodo
        public List<ConsultaImpuesto> ConsultaImpVenta(string cliente, DateTime fecha, DateTime fecha2)
        {
            try
            {
                List<ConsultaImpuesto> consulta = new List<ConsultaImpuesto>();
                CargarComando("consulta_impuestos_ventas_cliente_periodo");
                miComando.Parameters.AddWithValue("", cliente);
                miComando.Parameters.AddWithValue("", fecha);
                miComando.Parameters.AddWithValue("", fecha2);
                miConexion.MiConexion.Open();
                NpgsqlDataReader reader = miComando.ExecuteReader();
                PasarReaderAimpuesto(consulta, reader);
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return consulta;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al realizar la consulta.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        // todas + usuario + fecha
        public List<ConsultaImpuesto> ConsultaImpVentaUsuario(int idUsuario, DateTime fecha)
        {
            try
            {
                List<ConsultaImpuesto> consulta = new List<ConsultaImpuesto>();
                CargarComando("consulta_impuestos_ventas_usuario");
                miComando.Parameters.AddWithValue("", idUsuario);
                miComando.Parameters.AddWithValue("", fecha);
                miConexion.MiConexion.Open();
                NpgsqlDataReader reader = miComando.ExecuteReader();
                PasarReaderAimpuesto(consulta, reader);
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return consulta;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al realizar la consulta.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        // todas + usuario + periodo
        public List<ConsultaImpuesto> ConsultaImpVentaUsuario(int idUsuario, DateTime fecha, DateTime fecha2)
        {
            try
            {
                List<ConsultaImpuesto> consulta = new List<ConsultaImpuesto>();
                CargarComando("consulta_impuestos_ventas_usuario_periodo");
                miComando.Parameters.AddWithValue("", idUsuario);
                miComando.Parameters.AddWithValue("", fecha);
                miComando.Parameters.AddWithValue("", fecha2);
                miConexion.MiConexion.Open();
                NpgsqlDataReader reader = miComando.ExecuteReader();
                PasarReaderAimpuesto(consulta, reader);
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return consulta;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al realizar la consulta.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }


        // estado + cliente + fecha
        public List<ConsultaImpuesto> ConsultaImpVenta(int idEstado, string cliente, DateTime fecha)
        {
            try
            {
                List<ConsultaImpuesto> consulta = new List<ConsultaImpuesto>();
                CargarComando("consulta_impuestos_ventas_cliente");
                miComando.Parameters.AddWithValue("", idEstado);
                miComando.Parameters.AddWithValue("", cliente);
                miComando.Parameters.AddWithValue("", fecha);
                miConexion.MiConexion.Open();
                NpgsqlDataReader reader = miComando.ExecuteReader();
                PasarReaderAimpuesto(consulta, reader);
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return consulta;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al realizar la consulta.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        // estado + cliente + periodo
        public List<ConsultaImpuesto> ConsultaImpVenta(int idEstado, string cliente, DateTime fecha, DateTime fecha2)
        {
            try
            {
                List<ConsultaImpuesto> consulta = new List<ConsultaImpuesto>();
                CargarComando("consulta_impuestos_ventas_cliente");
                miComando.Parameters.AddWithValue("", idEstado);
                miComando.Parameters.AddWithValue("", cliente);
                miComando.Parameters.AddWithValue("", fecha);
                miComando.Parameters.AddWithValue("", fecha2);
                miConexion.MiConexion.Open();
                NpgsqlDataReader reader = miComando.ExecuteReader();
                PasarReaderAimpuesto(consulta, reader);
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return consulta;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al realizar la consulta.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        // estado + usuario + fecha
        public List<ConsultaImpuesto> ConsultaImpVentaUsuario(int idEstado, int idUsuario, DateTime fecha)
        {
            try
            {
                List<ConsultaImpuesto> consulta = new List<ConsultaImpuesto>();
                CargarComando("consulta_impuestos_ventas_usuario");
                miComando.Parameters.AddWithValue("", idEstado);
                miComando.Parameters.AddWithValue("", idUsuario);
                miComando.Parameters.AddWithValue("", fecha);
                miConexion.MiConexion.Open();
                NpgsqlDataReader reader = miComando.ExecuteReader();
                PasarReaderAimpuesto(consulta, reader);
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return consulta;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al realizar la consulta.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        // estado + usuario + periodo
        public List<ConsultaImpuesto> ConsultaImpVentaUsuario(int idEstado, int idUsuario, DateTime fecha, DateTime fecha2)
        {
            try
            {
                List<ConsultaImpuesto> consulta = new List<ConsultaImpuesto>();
                CargarComando("consulta_impuestos_ventas_usuario");
                miComando.Parameters.AddWithValue("", idEstado);
                miComando.Parameters.AddWithValue("", idUsuario);
                miComando.Parameters.AddWithValue("", fecha);
                miComando.Parameters.AddWithValue("", fecha2);
                miConexion.MiConexion.Open();
                NpgsqlDataReader reader = miComando.ExecuteReader();
                PasarReaderAimpuesto(consulta, reader);
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return consulta;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al realizar la consulta.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }


        private void PasarReaderAimpuesto(List<ConsultaImpuesto> consulta, NpgsqlDataReader reader)
        {
            string factura = "";
            try
            {
                while (reader.Read())
                {
                    var impuesto = new ConsultaImpuesto();
                    impuesto.NitTercero = reader.GetString(5);
                    impuesto.Tercero = reader.GetString(6);
                    factura = impuesto.Numero = reader.GetString(7);
                    impuesto.Fecha = reader.GetDateTime(8);

                    impuesto.Base0 = Convert.ToDouble(reader.GetDecimal(9));
                    impuesto.Iva0 = Convert.ToDouble(reader.GetDecimal(10));
                    impuesto.Costo0 = Convert.ToDouble(reader.GetDecimal(11));

                    impuesto.Base5 = Convert.ToDouble(reader.GetDecimal(12));
                    impuesto.Iva5 = Convert.ToDouble(reader.GetDecimal(13));
                    impuesto.IcoBase5 = reader.GetDouble(14);
                    impuesto.Costo5 = Math.Round(Convert.ToDouble(reader.GetDecimal(15)) / 1.05, 0);

                    impuesto.Base19 = Convert.ToDouble(reader.GetDecimal(16));
                    impuesto.Iva19 = Convert.ToDouble(reader.GetDecimal(17));
                    impuesto.IcoBase19 = reader.GetDouble(18);
                    impuesto.Costo19 = Math.Round(Convert.ToDouble(reader.GetDecimal(19)) / 1.19, 0);

                    impuesto.Base1E = Convert.ToDouble(reader.GetDecimal(20));
                    impuesto.Iva1E = Convert.ToDouble(reader.GetDecimal(21));
                    impuesto.Costo1E = Convert.ToDouble(reader.GetDecimal(22));

                    impuesto.IncBolsa = reader.GetDouble(23);
                    impuesto.Retencion = Convert.ToDouble(reader.GetInt64(24));
                    impuesto.Total = reader.GetDouble(25);
                    impuesto.Descuento = Convert.ToDouble(reader.GetDecimal(26));
                    impuesto.CostoVenta = impuesto.Costo0 + impuesto.Costo1E + impuesto.Costo5 + impuesto.Costo19;

                    consulta.Add(impuesto);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "\n" + "Factura No. " + factura);
            }
        }


        /// <summary>
        /// Inicializa una nueva instancia de NpgsqlCommand de tipo StoredProcedure.
        /// </summary>
        /// <param name="cmd">Comando a ejecutar.</param>
        private void CargarComando(string cmd)
        {
            miComando = new NpgsqlCommand();
            miComando.Connection = miConexion.MiConexion;
            miComando.CommandType = CommandType.StoredProcedure;
            miComando.CommandText = cmd;
            miComando.CommandTimeout = 0;
        }

        /// <summary>
        /// Inicializa una nueva instancia de NpgsqlDataAdapter de tipo StoredProcedure.
        /// </summary>
        /// <param name="cmd">Comando a ejecutar.</param>
        private void CargarAdapter(string cmd)
        {
            this.miAdapter = new NpgsqlDataAdapter(cmd, miConexion.MiConexion);
            this.miAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            this.miAdapter.SelectCommand.CommandTimeout = 0;
        }
    }
}