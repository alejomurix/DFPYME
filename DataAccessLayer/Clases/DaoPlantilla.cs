using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using DTO.Clases;

namespace DataAccessLayer.Clases
{
    public class DaoPlantilla
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

        public DaoPlantilla()
        {
            this.miConexion = new Conexion();
        }

        // Plantilla

        public void IngresarPlantilla(Plantilla plantilla)
        {
            try
            {
                CargarComando("insertar_plantilla");
                miComando.Parameters.AddWithValue("", plantilla.Codigo);
                miComando.Parameters.AddWithValue("", plantilla.Concepto);
                miConexion.MiConexion.Open();
                var id = Convert.ToInt32(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                foreach (CuentaPlantilla cuenta in plantilla.Cuentas)
                {
                    cuenta.IdPlantilla = id;
                    InsertarCuentaPlantilla(cuenta);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al ingresar la plantilla\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable Plantillas()
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("plantillas");
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar las plantillas.\n" + ex.Message);
            }
        }

        // CuentaPlantilla

        private void InsertarCuentaPlantilla(CuentaPlantilla cuenta)
        {
            try 
            {
                CargarComando("insertar_cuenta_plantilla");
                miComando.Parameters.AddWithValue("", cuenta.IdPlantilla);
                miComando.Parameters.AddWithValue("", cuenta.IdCuenta);
                miComando.Parameters.AddWithValue("", cuenta.Naturaleza);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al ingresar la plantilla\n" + ex.Message);
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