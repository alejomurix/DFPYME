using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO.Clases;
using Npgsql;

namespace DataAccessLayer.Clases
{
    public class DaoComprobanteCruce
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

        public DaoComprobanteCruce()
        {
            this.miConexion = new Conexion();
        }

        public long Ingresar(ComprobanteCruce cruce)
        {
            try
            {
                CargarComando("insertar_comprobante_cruce");
                miComando.Parameters.AddWithValue("cliente", cruce.NitCliente);
                miComando.Parameters.AddWithValue("fecha", cruce.Fecha);
                miComando.Parameters.AddWithValue("concepto", cruce.Concepto);
                miComando.Parameters.AddWithValue("valor", cruce.Valor);
                miComando.Parameters.AddWithValue("restante", cruce.Restante);
                miComando.Parameters.AddWithValue("v_restante", cruce.ValorRestante);
                miConexion.MiConexion.Open();
                var id = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return id;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al ingresar el Comprobante de Cruce.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public long IngresarReciboRetiro(ComprobanteCruce cruce)
        {
            try
            {
                CargarComando("insertar_recibo_retiro");
                miComando.Parameters.AddWithValue("cliente", cruce.NitCliente);
                miComando.Parameters.AddWithValue("fecha", cruce.Fecha);
                miComando.Parameters.AddWithValue("concepto", cruce.Concepto);
                miComando.Parameters.AddWithValue("valor", cruce.Valor);
                miComando.Parameters.AddWithValue("restante", cruce.Restante);
                miComando.Parameters.AddWithValue("v_restante", cruce.ValorRestante);
                miConexion.MiConexion.Open();
                var id = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return id;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al ingresar el Recibo de Retiro.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
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
        }

        /// <summary>
        /// Inicializa una nueva instancia de NpgsqlDataAdapter de tipo Stored Procedure.
        /// </summary>
        /// <param name="cmd">Sentencia a ejecutar.</param>
        private void CargarAdapter(string cmd)
        {
            miAdapter = new NpgsqlDataAdapter(cmd, miConexion.MiConexion);
            miAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        }
    }
}