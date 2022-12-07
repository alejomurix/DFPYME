using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using System.Collections;
using System.Data;
using DTO.Clases;

namespace DataAccessLayer.Clases
{
    public class DaoTipoCuenta
    {
        /// <summary>
        /// Representa la Funcion listado_tipo_cuenta
        /// </summary>
        private const string sqlListado = "listado_tipo_cuenta";
        
        /// <summary>
        /// Representa un objeto de conexion a Postgres
        /// </summary>
        private Conexion conexion;

        /// <summary>
        /// Representa un Adapter para sentencias sql
        /// </summary>
        private NpgsqlDataAdapter miAdapter;

        /// <summary>
        /// Representa un objeto de tabla en memoria.
        /// </summary>
        private DataTable miDataTable;

        /// <summary>
        /// Obtiene el listado de tipos de cuenta en un DataTable.
        /// </summary>
        /// <returns></returns>
        public DataTable listadoTipoCuenta()
        {
            try
            {
                conexion = new Conexion();
                miDataTable = new DataTable();
                CargarAdapterStoredProcedured(sqlListado);
                this.miAdapter.Fill(miDataTable);
                return miDataTable;
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo listar los tipos de cuenta. " + ex.Message);
            }
        }

        /// <summary>
        /// Inicializa una nueva instacia del Adapter de tipo stored procedure
        /// </summary>
        /// <param name="cmd">Sentencia sql a ejecutar</param>
        private void CargarAdapterStoredProcedured(string cmd)
        {
            this.miAdapter = new NpgsqlDataAdapter(cmd, this.conexion.MiConexion);
            this.miAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        }

    }
}
