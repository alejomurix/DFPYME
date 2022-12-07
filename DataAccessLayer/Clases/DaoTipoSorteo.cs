using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Npgsql;

namespace DataAccessLayer.Clases
{
   public class DaoTipoSorteo
    {
        /// <summary>
        /// Representa un objeto de tabla en memoria.
        /// </summary>
        private DataTable miDataTable;

        /// <summary>
        /// Representa un adapter de sentencia sql.
        /// </summary>
        private NpgsqlDataAdapter miAdapter;

        /// <summary>
        /// Representa un objeto de conexion a posgres.
        /// </summary>
        private Conexion miConexion;

        /// <summary>
        /// Representa la funcion listado_sorteo.
        /// </summary>
        private string sqlListaTipoSorteo = "listado_tipo_sorteo";

        private string sqlListaPromocion = "listado_tipo_promocion";

        public DataTable ListaTipoSorteo()
        {
            try
            {
                miDataTable = new DataTable();
                miConexion = new Conexion();
                CargaAdapterStoreProsedure(sqlListaTipoSorteo);
                this.miAdapter.Fill(miDataTable);
                return miDataTable;

            }
            catch(Exception ex)
            {
                throw new Exception("Error al listar tipos de sorteo" + ex.Message);
            }
           
        }

       /// <summary>
       /// Lista los tipos de promocion.
       /// </summary>
       /// <returns></returns>
        public DataTable ListaTipoPromocion()
        {
            try
            {
                miDataTable = new DataTable();
                miConexion = new Conexion();
                CargaAdapterStoreProsedure(sqlListaPromocion);
                this.miAdapter.Fill(miDataTable);
                return miDataTable;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar el tipo de promocion" + ex.Message);
            }
        }
        /// <summary>
        /// inicializa una nueva instancia adapter store prosedure
        /// </summary>
        /// <param name="cmd"></param>
        public void CargaAdapterStoreProsedure(string cmd)
        {
            miAdapter = new NpgsqlDataAdapter(cmd,this.miConexion.MiConexion);
            miAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        }
    }
}
