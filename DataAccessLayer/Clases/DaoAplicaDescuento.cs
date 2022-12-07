using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using DTO.Clases;

namespace DataAccessLayer.Clases
{
    public class DaoAplicaDescuento
    {
        private DaoGrupoDescuento miDaoGrupo;

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

        public DaoAplicaDescuento()
        {
            this.miConexion = new Conexion();
            this.miDaoGrupo = new DaoGrupoDescuento();
        }

        public int Ingresar(AplicaDescuento descuento)
        {
            try
            {
                CargarComando("insertar_aplica_descuento");
                miComando.Parameters.AddWithValue("", descuento.Codigo);
                miComando.Parameters.AddWithValue("", descuento.Concepto);
                miComando.Parameters.AddWithValue("", descuento.IdCuenta);
                miComando.Parameters.AddWithValue("", descuento.Porcentaje);
                miComando.Parameters.AddWithValue("", descuento.Valor);
                miComando.Parameters.AddWithValue("", descuento.Aplica);
                miConexion.MiConexion.Open();
                var id = Convert.ToInt32(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                miDaoGrupo.IngresarGrupoDescuento(descuento.IdGrupo, id);
                return id;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al ingresar el descuento.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable Descuentos(int idGrupo)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("descuentos");
                miAdapter.SelectCommand.Parameters.AddWithValue("", idGrupo);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los decuentos.\n" + ex.Message);
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