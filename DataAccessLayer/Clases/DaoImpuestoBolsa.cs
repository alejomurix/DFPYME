using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DTO.Clases;
using Npgsql;

namespace DataAccessLayer.Clases
{
    public class DaoImpuestoBolsa
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

        public DaoImpuestoBolsa()
        {
            this.miConexion = new Conexion();
        }

        public ImpuestoBolsa ImpuestoBolsa(int id)
        {
            try
            {
                CargarComando("impuesto_bolsa");
                this.miComando.Parameters.AddWithValue("", id);
                this.miConexion.MiConexion.Open();
                NpgsqlDataReader reader = this.miComando.ExecuteReader();
                var impuesto = new ImpuestoBolsa();
                while (reader.Read())
                {
                    impuesto.Id = reader.GetInt32(0);
                    impuesto.Cantidad = reader.GetDouble(1);
                    impuesto.Valor = reader.GetDouble(2);
                }
                this.miConexion.MiConexion.Close();
                this.miComando.Dispose();
                return impuesto;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el impuesto.\n" + ex.Message);
            }
            finally { this.miConexion.MiConexion.Close(); }
        }

        public void Insertar(ImpuestoBolsa impuesto)
        {
            try
            {
                this.CargarComando("insertar_venta_impuesto_bolsa");
                this.miComando.Parameters.AddWithValue("", impuesto.IdFactura);
                this.miComando.Parameters.AddWithValue("", impuesto.Cantidad);
                this.miComando.Parameters.AddWithValue("", impuesto.Valor);
                this.miConexion.MiConexion.Open();
                this.miComando.ExecuteNonQuery();
                this.miConexion.MiConexion.Close();
                this.miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al ingresar el impuesto a las bolsas.\n" + ex.Message);
            }
            finally { this.miConexion.MiConexion.Close(); }
        }

        public ImpuestoBolsa ImpuestoBolsaDeVenta(int idFactura)
        {
            try
            {
                CargarComando("impuesto_bolsa_de_venta");
                this.miComando.Parameters.AddWithValue("", idFactura);
                this.miConexion.MiConexion.Open();
                NpgsqlDataReader reader = this.miComando.ExecuteReader();
                var impuesto = new ImpuestoBolsa();
                while (reader.Read())
                {
                    impuesto.Id = reader.GetInt32(0);
                    impuesto.IdFactura = reader.GetInt32(1);
                    impuesto.Cantidad = reader.GetDouble(2);
                    impuesto.Valor = reader.GetDouble(3);
                }
                this.miConexion.MiConexion.Close();
                this.miComando.Dispose();
                return impuesto;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el impuesto.\n" + ex.Message);
            }
            finally { this.miConexion.MiConexion.Close(); }
        }

        // caja y fecha
        public ImpuestoBolsa ImpuestoBolsaDeVenta(int idCaja, DateTime fecha)
        {
            try
            {
                CargarComando("impuesto_bolsa_de_venta");
                this.miComando.Parameters.AddWithValue("", idCaja);
                this.miComando.Parameters.AddWithValue("", fecha);
                this.miConexion.MiConexion.Open();
                NpgsqlDataReader reader = this.miComando.ExecuteReader();
                var impuesto = new ImpuestoBolsa();
                while (reader.Read())
                {
                    impuesto.Cantidad = reader.GetInt32(0);
                    impuesto.Valor = reader.GetInt32(1);
                }
                this.miConexion.MiConexion.Close();
                this.miComando.Dispose();
                return impuesto;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el impuesto.\n" + ex.Message);
            }
            finally { this.miConexion.MiConexion.Close(); }
        }

        // fecha
        public ImpuestoBolsa ImpuestoBolsaDeVenta(DateTime fecha)
        {
            try
            {
                CargarComando("impuesto_bolsa_de_venta_fecha");
                this.miComando.Parameters.AddWithValue("", fecha);
                this.miConexion.MiConexion.Open();
                NpgsqlDataReader reader = this.miComando.ExecuteReader();
                var impuesto = new ImpuestoBolsa();
                while (reader.Read())
                {
                    impuesto.Cantidad = reader.GetInt32(0);
                    impuesto.Valor = reader.GetInt32(1);
                }
                this.miConexion.MiConexion.Close();
                this.miComando.Dispose();
                return impuesto;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el impuesto.\n" + ex.Message);
            }
            finally { this.miConexion.MiConexion.Close(); }
        }


        public ImpuestoBolsa ImpuestoBolsaDeVenta(DateTime fecha, DateTime fecha2)
        {
            try
            {
                CargarComando("impuesto_bolsa_de_venta_fecha");
                this.miComando.Parameters.AddWithValue("", fecha);
                this.miComando.Parameters.AddWithValue("", fecha2);
                this.miConexion.MiConexion.Open();
                NpgsqlDataReader reader = this.miComando.ExecuteReader();
                var impuesto = new ImpuestoBolsa();
                while (reader.Read())
                {
                    impuesto.Cantidad = reader.GetInt32(0);
                    impuesto.Valor = reader.GetInt32(1);
                }
                this.miConexion.MiConexion.Close();
                this.miComando.Dispose();
                return impuesto;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el impuesto.\n" + ex.Message);
            }
            finally { this.miConexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Inicializa una nueva instancia de NpgsqlCommand de tipo StoredProcedure.
        /// </summary>
        /// <param name="cmd">Comando a ejecutar.</param>
        private void CargarComando(string cmd)
        {
            this.miComando = new NpgsqlCommand();
            this.miComando.Connection = this.miConexion.MiConexion;
            this.miComando.CommandType = CommandType.StoredProcedure;
            this.miComando.CommandText = cmd;
        }

        /// <summary>
        /// Inicializa una nueva instancia de NpgsqlDataAdapter de tipo Stored Procedure.
        /// </summary>
        /// <param name="cmd">Sentencia a ejecutar.</param>
        private void CargarAdapter(string cmd)
        {
            this.miAdapter = new NpgsqlDataAdapter(cmd, this.miConexion.MiConexion);
            this.miAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        }
    }
}