using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO.Clases;
using Npgsql;
using System.Data;

namespace DataAccessLayer.Clases
{
    public class DaoPermiso
    {
        /// <summary>
        /// Representa una sentencia sql.
        /// </summary>
        private NpgsqlCommand miComando;

        /// <summary>
        /// Representa un adapter postgres sql.
        /// </summary>
        private NpgsqlDataAdapter miAdapter;

        /// <summary>
        /// Representa una tabla de datos en memoria.
        /// </summary>
        private DataTable mitable;

        /// <summary>
        /// Objeto de conexion sql
        /// </summary>
        private Conexion miConexion;

        /// <summary>
        /// Representa la función insertar_usuario_permiso.
        /// </summary>
        private string sqlInsertarRelacionTipoPermiso = "insertar_usuario_permiso";

        /// <summary>
        /// Representa la funcion listado_permiso.
        /// </summary>
        private string sqlListarPermisoUsuario = "listado_permiso";

        /// <summary>
        /// Representa la función listado_permisos_usuario.
        /// </summary>
        private string sqlListadoPermisosUsuario = "listado_permisos_usuario";

        /// <summary>
        /// Representa la función eliminar_tipo_permiso.
        /// </summary>
        private string sqlEliminaRelacion = "eliminar_tipo_permiso";

        public DaoPermiso()
        {
            this.miConexion = new Conexion();
        }

        /// <summary>
        /// Inserta la relacion entre los usuarios y los tipos de permisos dentro del sistema.
        /// </summary>
        /// <param name="idPermiso">id del permiso a ingresar</param>
        /// <param name="idUsuario">is del usuario aingresar</param>
        public void InsertaPermiso(int idPermiso, int idUsuario)
        {
            try
            {
                CargarComandoStoredProcedure(sqlInsertarRelacionTipoPermiso);
                miComando.Parameters.AddWithValue("idpermiso", idPermiso);
                miComando.Parameters.AddWithValue("idusuario", idUsuario);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar los permisos a los usuarios.\n" + ex.Message);
            }
        }

        public List<Permiso> Permisos(int idUsuario)
        {
            try
            {
                Permiso p = new Permiso();

                List<Permiso> ps = new List<Permiso>();
                CargarComandoStoredProcedure(sqlListadoPermisosUsuario);
                miComando.Parameters.AddWithValue("", idUsuario);
                miConexion.MiConexion.Open();
                NpgsqlDataReader reader = miComando.ExecuteReader();
                while (reader.Read())
                {
                    Permiso p_ = new Permiso();
                    p_.IdPermiso = reader.GetInt32(0);
                    ps.Add(p_);
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();

                // Validar y cargar los permisos adquiridos. (entre list ps y objeto permiso con valores)
                /*  if (ps.Where(ps_ => ps_.IdAdministrar == p.IdAdministrar).Count() > 0)
                  {
                      p.Administrar = true;
                  }*/
                /*foreach (var ps_ in ps)
                {
                    if (ps_.IdPermiso.Equals(p.IdConfiguracion))
                    {
                        p.Configuracion = true;
                    }
                    else
                    {
                        if (ps_.IdPermiso.Equals(p.IdAdministrar))
                        {
                            p.Administrar = true;
                        }
                    }
                }*/


                return ps;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar los permisos del usuario.\n" + ex.Message);
            }
        }

        public void EliminarPermisos(int idUsuario)
        {
            try
            {
                CargarComandoStoredProcedure("eliminar_permisos_usuario");
                miComando.Parameters.AddWithValue("", idUsuario);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al eliminar los permisos.\n" + ex.Message);
            }
        }





        /// <summary>
        /// Lista los permisos de los usuarios.
        /// </summary>
        /// <returns></returns>
        public DataTable ListarPermisosUsuario()
        {
            try
            {
                mitable = new DataTable();
                CargarAdapterStoredProcedure(sqlListarPermisoUsuario);
                miAdapter.Fill(mitable);
                return mitable;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los permisos.\n" + ex.Message);
            }
        }

        /// <summary>
        /// Lista lis permisos de cada usuario.
        /// </summary>
        /// <param name="idUsuario">id usuario a consuñtar los permisos</param>
        /// <returns></returns>
        public DataTable ListarpermisoUsuario(int idUsuario)
        {
            mitable = new DataTable();
            try
            {
                CargarAdapterStoredProcedure(sqlListadoPermisosUsuario);
                miAdapter.SelectCommand.Parameters.AddWithValue("idUsuario", idUsuario);
                miAdapter.Fill(mitable);
                return mitable;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar los permisos de el usuario.");
            }
        }

        /// <summary>
        /// Elimina la relación entre usuarios y permisos.
        /// </summary>
        /// <param name="idPermiso">id del permiso a eliminar.</param>
        /// <param name="documento">documento del usuario a eliminar.</param>
        public void EliminaRelacionUsuario(int idPermiso, int documento)
        {
            try
            {
                CargarComandoStoredProcedure(sqlEliminaRelacion);
                miComando.Parameters.AddWithValue("idcargo", idPermiso);
                miComando.Parameters.AddWithValue("documento", documento);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la relacion usuario permiso.\n" + ex.Message);
            }
        }

        /// <summary>
        /// Inicializa una nueva instancia de NpgsqlCommand de tipo Stored Procedure.
        /// </summary>
        /// <param name="cmd"></param>
        private void CargarComandoStoredProcedure(string cmd)
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
        private void CargarAdapterStoredProcedure(string cmd)
        {
            miAdapter = new NpgsqlDataAdapter(cmd, miConexion.MiConexion);
            miAdapter.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
        }
    }
}