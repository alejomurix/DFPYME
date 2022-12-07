using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using System.Data;
using DTO.Clases;

namespace DataAccessLayer.Clases
{
   public class DaoTipoUsuario
    {
       /// <summary>
       /// Representa una sentencia sql postgres
       /// </summary>
       private NpgsqlCommand miComando;

       /// <summary>
       /// Representa un adapter sql postgres
       /// </summary>
       private NpgsqlDataAdapter miAdapter;

       /// <summary>
       /// Representa un objeto de conexion sql postgres.
       /// </summary>
       private Conexion miConexion;

       /// <summary>
       /// Representa una tabla de datos en memoria.
       /// </summary>
       private DataTable miTable;

       /// <summary>
       /// Representa la función listado_cargo.
       /// </summary>
       private string sqlListarCargo = "listado_cargo";

       /// <summary>
       /// Representa la función editar_cargo.
       /// </summary>
       private string sqlEditacrgo = "editar_cargo";

       /// <summary>
       /// Representa la funcion insertar_cargo.
       /// </summary>
       private string sqlInsertarCargo = "insertar_cargo";

       /// <summary>
       /// Representa la función eliminar_cargo;
       /// </summary>
       private string sqlEliminarCargo = "eliminar_cargo";

       /// <summary>
       /// Representa la funcion existe_permiso.
       /// </summary>
       private string sqlExisteCargo = "existe_permiso";

       public DaoTipoUsuario()
       {
           this.miConexion=new Conexion();
       }

       /// <summary>
       /// Inserta cargo
       /// </summary>
       /// <param name="cargo"></param>
       public void Insertacargo(TipoUsuario cargo)
       {
           try
           {
               CargarComandoStoreProsedure(sqlInsertarCargo);
               miComando.Parameters.AddWithValue("Cargo", cargo.Descripcion);
               miConexion.MiConexion.Open();
               miComando.ExecuteNonQuery();
               miConexion.MiConexion.Close();
               miComando.Dispose();
           }
           catch (Exception ex)
           {
               throw new Exception("Error al insertar el cargo.\n" + ex.Message);
           }
           finally
           { miConexion.MiConexion.Close(); }
       }

       /// <summary>
       /// Lista los cargos de usuario.
       /// </summary>
       /// <returns></returns>
       public DataTable ListarCargo()
       {
           try
           {
               miTable=new DataTable();
               CargarAdapterStoredProcedure(sqlListarCargo);
               miAdapter.Fill(miTable);
               return miTable;
           }
           catch(Exception ex)
           {
               throw new Exception("Error al listar los cargos.\n" + ex.Message);
           }
       }

       /// <summary>
       /// Edita el cargo.
       /// </summary>
       /// <param name="cargo">cargo a editar</param>
       public void EditraCargo(TipoUsuario cargo)
       {
           try
           {
               CargarComandoStoreProsedure(sqlEditacrgo);
               miComando.Parameters.AddWithValue("idcargo", cargo.IdTipo);
               miComando.Parameters.AddWithValue("cargo", cargo.Descripcion);
               miConexion.MiConexion.Open();
               miComando.ExecuteNonQuery();
               miConexion.MiConexion.Close();
               miComando.Dispose();
           }
           catch(Exception ex)
           {
               throw new Exception("Error al modificar el cargo.\n" + ex.Message);
           }
           finally
           {
               miConexion.MiConexion.Close();
           }
       }

       /// <summary>
       /// Elimina cargo.
       /// </summary>
       /// <param name="idCargo">id carga a eliminar</param>
       public void EliminaCargo(int idCargo)
       {
           try
           {
               CargarComandoStoreProsedure(sqlEliminarCargo);
               miComando.Parameters.AddWithValue("idCargo", idCargo);
               miConexion.MiConexion.Open();
               miComando.ExecuteNonQuery();
               miConexion.MiConexion.Close();
               miComando.Dispose();
           }
           catch(Exception ex)
           {
               throw new Exception ("Error al eliminar el cargo. Hay un registro asociado.\n"+ex.Message);
           }
           finally
           { miConexion.MiConexion.Close();}
       }

       /// <summary>
       /// Consulta si existe el cargo.
       /// </summary>
       /// <param name="cargo">cargo a consultar</param>
       /// <returns></returns>
       public bool ExisteCargo(string cargo)
       {
           try
           {
               CargarComandoStoreProsedure(sqlExisteCargo);
               miComando.Parameters.AddWithValue("cargo", cargo);
               miConexion.MiConexion.Open();
               var resultado = Convert.ToBoolean(miComando.ExecuteScalar());
               miConexion.MiConexion.Close();
               miComando.Dispose();
               return resultado;
           }
           catch (Exception ex)
           {
               throw new Exception("Error al consultar el cargo.");
           }
           finally
           {
               miConexion.MiConexion.Close();
           }
       }

        /// <summary>
        /// Inicializa una nueva instancia de NpgsqlCommand de tipo StoredProcedure.
        /// </summary>
        /// <param name="cmd"></param>
        private void CargarComandoStoreProsedure(string cmd)
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
        private void CargarAdapterStoredProcedure(string cmd)
        {
            miAdapter = new NpgsqlDataAdapter(cmd, miConexion.MiConexion);
            miAdapter.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
        }
    }
}
