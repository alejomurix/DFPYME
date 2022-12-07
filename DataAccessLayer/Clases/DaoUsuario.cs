using System;
using System.Data;
using Npgsql;
using DTO.Clases;
using System.Collections.Generic;

namespace DataAccessLayer.Clases
{
    /// <summary>
    /// Representa una clase para la tranzación de Usuario a base de datos.
    /// </summary>
    public class DaoUsuario
    {
        #region Atributos de Base de datos


        /// <summary>
        /// Represent un objeto de conexion a base de datos PostgreSQL.
        /// </summary>
        private Conexion miConexion;

        /// <summary>
        /// Representa una sentencia sql postgres sql
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

        private DaoPermiso miDaoPermiso;

        #endregion

        #region Procedimientos Alamcenados

        private const string sqlVerificarAdmin = "verificar_usuario_admin";

        /// <summary>
        /// Representa la función insertar_usuario_sistema.
        /// </summary>
        private string sqlInsertarUsuario = "insertar_usuario_sistema";

        /// <summary>
        /// Representa la funcion existe_usuario.
        /// </summary>
        private string sqlExisteUsuario = "existe_usuario";

        /// <summary>
        /// Representa la función consulta_usuario_sistema_codigo.
        /// </summary>
        private string sqlConsultaUsuarioDocumento = "consulta_usuario_sistema_codigo";

        /// <summary>
        /// Representa la función consulta_usuario_sistema_nombre.
        /// </summary>
        private string sqlConsultarUsuarioNombre = "consulta_usuario_sistema_nombre";

        /// <summary>
        ///Representa la función consulta_usuario_sistema_nombre_contenga_activo.
        /// </summary>
        private string sqlConsultarUsuarioNombreActivo = "consulta_usuario_sistema_nombre_contenga_activo";

        /// <summary>
        /// Representa la función consulta_usuario_sistema_nombre_contenga;
        /// </summary>
        private string sqlConsultarUsuarioNombreContenga = "consulta_usuario_sistema_nombre_contenga";

        /// <summary>
        /// Representa la función consulta_usuario_sistema_cargo.
        /// </summary>
        private string sqlConsultarUsuarioCargo = "consulta_usuario_sistema_cargo";

        /// <summary>
        /// Representa la función consulta_usuario_sistema_cargo_activo.
        /// </summary>
        private string sqlConsultarUsuariocargoActivo = "consulta_usuario_sistema_cargo_activo";

        /// <summary>
        /// Representa edita_usuario_sistema.
        /// </summary>
        private string sqlEditaUsuario = "edita_usuario_sistema";

        /// <summary>
        /// representa ña funcion existe_documeto.
        /// </summary>
        private string sqlExistedocumento = "existe_documeto";

        /// <summary>
        /// Representa a función eliminar_usuario.
        /// </summary>
        private string sqlEliminarUsuario = "eliminar_usuario";       

        /// <summary>
        /// Representa la función existe_usuario_contrasena.
        /// </summary>
        private string sqlExisteUsuarioContraseña = "existe_usuario_contrasena";

        /// <summary>
        /// Representa la funcionedita_contrasena_usuario.
        /// </summary>
        private string sqlEditaContrasenaUsuario = "edita_contrasena_usuario";

        /// <summary>
        /// Representa la funcion edita_usuario_propio.
        /// </summary>
        private string sqlEditausuarioPropio = "edita_usuario_propio";

        /// <summary>
        /// Representa la función usuario_activo.
        /// </summary>
        private string sqlExisteUsuarioActivo = "usuario_activo";

        /// <summary>
        /// Representa la función usuario_activo_pass.
        /// </summary>
        private string sqlExisteUsuarioPass = "usuario_activo_pass";

        /// <summary>
        /// Representa la función: print_usuario.
        /// </summary>
        private string PrintUsuario_ = "print_usuario";

        private string PrintUsuarioVenta_ = "print_usuario_venta";

        #endregion

        #region Constantes

        /// <summary>
        /// Representa el texto: Ocurrio un error al verificar el usuario.
        /// </summary>
        private const string msnVerificar = "Ocurrio un error al verificar el usuario.\n";

        /// <summary>
        /// Representa el text: Ocurrió un error al consultar al Usuario de la Factura..
        /// </summary>
        private string ErrorConsulta = "Ocurrió un error al consultar al Usuario de la Factura.\n";

        #endregion

        /// <summary>
        /// Inicializa una nueva instancia de la clase DaoUsuario.
        /// </summary>
        /// 
        public DaoUsuario()
        {
            this.miConexion = new Conexion();
            this.miDaoPermiso = new DaoPermiso();
        }

        /// <summary>
        /// Inserta usuario a la base de datos.
        /// </summary>
        /// <param name="usuario"></param>
        public void InsertarUsuarioSistema(Usuario usuario)
        {
            var miDaoPermiso = new DaoPermiso();
            try
            {                
                CargarComandoStoredProcedure(sqlInsertarUsuario);
                miComando.Parameters.AddWithValue("idtipo", usuario.IdTipo);
                miComando.Parameters.AddWithValue("documento", usuario.Identificacion);
                miComando.Parameters.AddWithValue("nombre", usuario.Nombres);
                miComando.Parameters.AddWithValue("usuario", usuario.Usuario_);
                miComando.Parameters.AddWithValue("contraseña", usuario.Contrasenia);
                miComando.Parameters.AddWithValue("estado", usuario.Estado);
                miComando.Parameters.AddWithValue("telefono", usuario.Telefono);
                miComando.Parameters.AddWithValue("direccion", usuario.Direccion);
                miConexion.MiConexion.Open();
                var id = Convert.ToInt32(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();

                foreach (Permiso p in usuario.Permisos)
                {
                    miDaoPermiso.InsertaPermiso(p.IdPermiso, id);
                }       
                
            }
            catch(Exception ex)
            {
                throw new Exception("Error al insertar el ususrio.\n" + ex.Message);
            }
            finally
            {
                miConexion.MiConexion.Close();
            }
        }

        public Usuario Usuario_(Usuario u)
        {
            try
            {
                Usuario usuario = new Usuario();
                CargarComandoStoredProcedure("usuario");
                miComando.Parameters.AddWithValue("", u.Usuario_);
                miComando.Parameters.AddWithValue("", u.Contrasenia);
                miConexion.MiConexion.Open();
                NpgsqlDataReader reader = miComando.ExecuteReader();
                while (reader.Read())
                {
                    usuario.Id = reader.GetInt32(0);
                    usuario.Cargo.IdTipo = reader.GetInt32(1);
                    usuario.Cargo.Descripcion = reader.GetString(2);
                    usuario.Identificacion = reader.GetInt32(3);
                    usuario.Nombres = reader.GetString(4);
                    usuario.Usuario_ = reader.GetString(5);
                    usuario.Contrasenia = reader.GetString(6);
                    usuario.Estado = reader.GetBoolean(10);
                    usuario.Telefono = reader.GetString(8);
                    usuario.Direccion = reader.GetString(9);
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                usuario.Permisos = this.miDaoPermiso.Permisos(usuario.Id);
                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar el usuario.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public Usuario Usuario_(int documento)
        {
            try
            {
                Usuario usuario = new Usuario();
                CargarComandoStoredProcedure("usuario");
                miComando.Parameters.AddWithValue("", documento);
                miConexion.MiConexion.Open();
                NpgsqlDataReader reader = miComando.ExecuteReader();
                while (reader.Read())
                {
                    usuario.Id = reader.GetInt32(0);
                    usuario.Cargo.IdTipo = reader.GetInt32(1);
                    usuario.Cargo.Descripcion = reader.GetString(2);
                    usuario.Identificacion = reader.GetInt32(3);
                    usuario.Nombres = reader.GetString(4);
                    usuario.Usuario_ = reader.GetString(5);
                    usuario.Contrasenia = reader.GetString(6);
                    usuario.Estado = reader.GetBoolean(10);
                    usuario.Telefono = reader.GetString(8);
                    usuario.Direccion = reader.GetString(9);
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                usuario.Permisos = this.miDaoPermiso.Permisos(usuario.Id);
                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar el usuario.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public bool VerificarUsuario(string usuario_, string password, int idPermiso)
        {
            try
            {
                CargarComandoStoredProcedure("verificar_usuario");
                miComando.Parameters.AddWithValue("", usuario_);
                miComando.Parameters.AddWithValue("", password);
                miComando.Parameters.AddWithValue("", idPermiso);
                miConexion.MiConexion.Open();
                var resultado = Convert.ToBoolean(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(msnVerificar + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable Usuarios()
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapterStoredProcedure("consulta_usuario_sistema_activos");
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar los usuarios.\n" + ex.Message);
            }
        }

        public List<Usuario> UsuariosAll()
        {
            try
            {
                List<Usuario> usuarios = new List<Usuario>();
                var tUsuarios = this.Usuarios();
                foreach(DataRow uRow in tUsuarios.Rows)
                {
                    usuarios.Add(new Usuario
                    {
                        Id = Convert.ToInt32(uRow["id"]),
                        Identificacion = Convert.ToInt32(uRow["documento"]),
                        Nombres = uRow["nombre"].ToString(),
                        Usuario_ = uRow["usuario"].ToString(),
                        Contrasenia = Utilities.Encode.Decrypt(uRow["contrasenia"].ToString())
                    });
                }
                return usuarios;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void EditaUsuario(Usuario usuario)
        {
            //var daoPermiso = new DaoPermiso();
            try
            {
                CargarComandoStoredProcedure(sqlEditaUsuario);
                miComando.Parameters.AddWithValue("id", usuario.Id);
                miComando.Parameters.AddWithValue("cargo", usuario.Cargo.IdTipo);
                miComando.Parameters.AddWithValue("documento", usuario.Identificacion);
                miComando.Parameters.AddWithValue("nombre", usuario.Nombres);
                miComando.Parameters.AddWithValue("usuario", usuario.Usuario_);
                miComando.Parameters.AddWithValue("contraseña", usuario.Contrasenia);
                miComando.Parameters.AddWithValue("estado", usuario.Estado);
                miComando.Parameters.AddWithValue("telefono", usuario.Telefono);
                miComando.Parameters.AddWithValue("direccion", usuario.Direccion);             
                
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();

               /* mitable = daoPermiso.ListarpermisoUsuario(usuario.Id);
                var existe = false;
                foreach (Permiso p in usuario.Permisos)
                {
                    existe = false;
                    foreach (DataRow row in mitable.Rows)
                    {                        
                        if (p.IdPermiso == Convert.ToInt32(row["IdPermiso"]))
                        {
                            existe = true;
                            break;
                        }
                        else
                        {
                            existe = false;
                        }
                    }
                    if (!existe)
                    {
                        daoPermiso.InsertaPermiso(p.IdPermiso, usuario.Id);
                    }
                }
                foreach (DataRow row in mitable.Rows)
                {
                    existe = false;
                    foreach (Permiso p in usuario.Permisos)
                    {
                        if (Convert.ToInt32(row["IdPermiso"]) == p.IdPermiso)
                        {
                            existe = true;
                            break;
                        }
                        else
                        {
                            existe = false;
                        }
                    }
                    if (!existe)
                    {
                        daoPermiso.EliminaRelacionUsuario(Convert.ToInt32(row["IdPermiso"]), usuario.Id);
                    }
                }  */
                
            }
            catch(Exception ex)
            {
                throw new Exception("Ocurrió un error al editar el usuario.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }











        /// <summary>
        /// Eliminar usuario
        /// </summary>
        /// <param name="idUsuario">id del usuario a eliminar</param>
        public void EliminaUsuario(int idUsuario)
        {
            try
            {
                CargarComandoStoredProcedure(sqlEliminarUsuario);
                miComando.Parameters.AddWithValue("idusuario", idUsuario);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch(Exception ex)
            {
                throw new Exception("El usuario tiene registros asociados.\n" + ex.Message);
            }
             finally
            {
                miConexion.MiConexion.Close();
            }
        }

        public DataTable ConsultaUsuario(int id)
        {
            mitable = new DataTable();
            try
            {
                CargarAdapterStoredProcedure("consulta_usuario_sistema");
                miAdapter.SelectCommand.Parameters.AddWithValue("id", id);
                miAdapter.Fill(mitable);
                return mitable;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el Usuario.\n" + ex.Message);
            }
        }

        /// <summary>
        /// Consulta usuario por documento
        /// </summary>
        /// <param name="documento">documento del usuario a consultar</param>
        /// <returns></returns>
        public DataTable ConsultaUsuarioDocumento(int documento)
        {
            mitable = new DataTable();
            try
            {
                CargarAdapterStoredProcedure(sqlConsultaUsuarioDocumento);
                miAdapter.SelectCommand.Parameters.AddWithValue("documento", documento);
                miAdapter.Fill(mitable);
                return mitable;
            }
            catch(Exception ex)
            {
                throw new Exception("Error al consultar el documento del usuario.\n" + ex.Message);
            }
        }

        /// <summary>
        /// Consulta usuario por nombre que sea igual.
        /// </summary>
        /// <param name="nombre">nombre del usuario a consultar</param>
        /// <returns></returns>
        public DataTable ConsultarUsuarioNombreIgual(string nombre)
        {
            mitable = new DataTable();
            try
            {
                CargarAdapterStoredProcedure(sqlConsultarUsuarioNombre);
                miAdapter.SelectCommand.Parameters.AddWithValue("nombre", nombre);
                miAdapter.Fill(mitable);
                return mitable;
            }
            catch(Exception ex)
            {
                throw new Exception("Error al consultar nombre de usuario.\n" + ex.Message);
            }
        }

        /// <summary>
        ///Consulta nombre de usuario que contenga que sean activos dentro de la base de datos.
        /// </summary>
        /// <param name="nombre">nombre del usuario a consultar.</param>
        /// <returns></returns>
        public DataTable ConsultarUsuarioNombreContengaActivos(string nombre)
        {
            mitable = new DataTable();
            try
            {
                CargarAdapterStoredProcedure(sqlConsultarUsuarioNombreActivo);
                miAdapter.SelectCommand.Parameters.AddWithValue("nombre", nombre);
                miAdapter.Fill(mitable);
                return mitable;
            }
            catch(Exception ex)
            {
                throw new Exception("Error al consultar el  nombre del usuario.\n" + ex.Message);
            }
        }

        /// <summary>
        /// Consultar nombres de usuario que contenga consulta todos los usuarios que 
        /// traiga la consulta sean activos o inactivos.
        /// </summary>
        /// <param name="nombre">nombre del usuario a consultar</param>
        /// <returns></returns>
        public DataTable ConsultarUsuarioContenga(string nombre)
        {
            mitable = new DataTable();
            try
            {
                CargarAdapterStoredProcedure(sqlConsultarUsuarioNombreContenga);
                miAdapter.SelectCommand.Parameters.AddWithValue("nombre", nombre);
                miAdapter.Fill(mitable);
                return mitable;
            }
            catch(Exception ex)
            {
                throw new Exception("Error al consultar nombre del usuario.\n" + ex.Message);
            }
        }

        /// <summary>
        /// Consulta el usuario por cargo 
        /// consulta sean activos o inactivos.
        /// </summary>
        /// <param name="idcargo"></param>
        /// <returns></returns>
        public DataTable ConsultarUsuarioCargo(int idcargo)
        {
            mitable = new DataTable();
            try
            {
                CargarAdapterStoredProcedure(sqlConsultarUsuarioCargo);
                miAdapter.SelectCommand.Parameters.AddWithValue("idcargo", idcargo);
                miAdapter.Fill(mitable);
                return mitable;
            }
            catch(Exception ex)
            {
                throw new Exception("Error al consultar el cago del usuario.\n" + ex.Message);
            }
        }

        /// <summary>
        /// Consultar usuarios por cargo solo los activos.
        /// </summary>
        /// <param name="idCargo">id cargo a consultar</param>
        /// <returns></returns>
        public DataTable ConsultarUsuarioCargoActivo(int idCargo)
        {
            mitable = new DataTable();
            try
            {
                CargarAdapterStoredProcedure(sqlConsultarUsuariocargoActivo);
                miAdapter.SelectCommand.Parameters.AddWithValue("idcergo", idCargo);
                miAdapter.Fill(mitable);
                return mitable;
            }
            catch(Exception ex)
            {
                throw new Exception("Error al consultar el cargo del usuario.\n" + ex.Message);
            }
        }

        /// <summary>
        /// Consulta en la base de datos si existe el usuario.
        /// </summary>
        /// <param name="usuario">usuario a consultar</param>
        /// <returns></returns>
        public bool ExisteUsuario(string usuario)
        {
            try
            {
                CargarComandoStoredProcedure(sqlExisteUsuario);
                miComando.Parameters.AddWithValue("usuario", usuario);
                miConexion.MiConexion.Open();
                var resultado = Convert.ToBoolean(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return resultado;
            }
            catch(Exception ex)
            {
                throw new Exception("Error al consultar el usuario.\n" + ex.Message);
            }
            finally
            {
                miConexion.MiConexion.Close();
            }
        }

        /// <summary>
        /// Consulta en la base de datos si ay un usuario con este documento.
        /// </summary>
        /// <param name="documento">documento a consultar</param>
        /// <returns></returns>
        public bool ExisteDocumento(int documento)
        {
            try
            {
                CargarComandoStoredProcedure(sqlExistedocumento);
                miComando.Parameters.AddWithValue("documento", documento);
                miConexion.MiConexion.Open();
                var resultado = Convert.ToBoolean(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return resultado;
            }
            catch(Exception ex)
            {
                throw new Exception("Error al consultar el usuario.\n" + ex.Message);
            }
            finally
            {
                miConexion.MiConexion.Close();
            }
        }

        /// <summary>
        /// consulta si la contraseña ingresada es la misma qu hay en la base de datos.
        /// </summary>
        /// <param name="idUsuario">contraseña a consultar</param>
        /// <returns></returns>
        public string ExisteContrasena(int idUsuario)
        {
            try
            {
                CargarComandoStoredProcedure(sqlExisteUsuarioContraseña);
                miComando.Parameters.AddWithValue("idusuario", idUsuario);
                miConexion.MiConexion.Open();
                var resultado = Convert.ToString(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return resultado;
            }
            catch(Exception ex)
            {
                throw new Exception("Error al consultar la contraseña.\n" + ex.Message);
            }
            finally
            {
                miConexion.MiConexion.Close();
            }
        }

        /// <summary>
        /// Consulta si el usiario esta activo dentro de la base de datos.
        /// </summary>
        /// <param name="usuario">usuario a consultar</param>
        /// <returns></returns>
        public bool ExisteUsuarioActivo(string usuario)
        {
            try
            {
                CargarComandoStoredProcedure(sqlExisteUsuarioActivo);
                miComando.Parameters.AddWithValue("usuario", usuario);
                miConexion.MiConexion.Open();
                var resultado = Convert.ToBoolean(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return resultado;
            }
            catch(Exception ex)
            {
                throw new Exception("Error al consultar el usuario.\n" + ex.Message);
            }
            finally
            {
                miConexion.MiConexion.Close();
            }
        }

        /// <summary>
        /// Consulta en la base de datos si el password ingresado corresponde al usuario
        /// </summary>
        /// <param name="usuario">usuario a consultar</param>
        /// <returns></returns>
        public string ExisteUsuarioPass(string usuario)
        {
            try
            {
                CargarComandoStoredProcedure(sqlExisteUsuarioPass);
                miComando.Parameters.AddWithValue("usuario", usuario);
                miConexion.MiConexion.Open();
                var resultado = Convert.ToString(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return resultado;
            }
            catch(Exception ex)
            {
                throw new Exception("Error al consultar el usuario.\n"+ex.Message);
            }
            finally
            { miConexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Edita la contraseña deñ usuario.
        /// </summary>
        /// <param name="idUsuario">id del usuario a consultar</param>
        /// <param name="contrasena">contraseña a editar</param>
        public void EditaContraseña(int idUsuario, string contrasena)
        {
            try
            {
                CargarComandoStoredProcedure(sqlEditaContrasenaUsuario);
                miComando.Parameters.AddWithValue("idusuario", idUsuario);
                miComando.Parameters.AddWithValue("contraseña", contrasena);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch(Exception ex)
            {
                throw new Exception("Error al editar la contraseña.\n" + ex.Message);
            }
            finally
            {
                miConexion.MiConexion.Close();
            }
        }

        /// <summary>
        /// Verifica el registro del usuario administrador del sistema.
        /// </summary>
        /// <param name="password">Password del usuario.</param>
        /// <returns></returns>
        public bool VerificarUsuarioAdmin(string password)
        {
            try
            {
                CargarComandoStoredProcedure(sqlVerificarAdmin);
                miComando.Parameters.AddWithValue("password", password);
                miConexion.MiConexion.Open();
                var resultado = Convert.ToBoolean(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(msnVerificar + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Carga el usuario a modificar
        /// </summary>
        /// <param name="documento">documento a consultar para modificar</param>
        /// <returns></returns>
        public Usuario CargarUsuario(int documento)
        {
            //var daoPermiso=new DaoPermiso();
            try
            {
                mitable = ConsultaUsuarioDocumento(documento);
                var usuario = new Usuario();

                foreach (DataRow row in mitable.Rows)
                {
                    usuario.Id = (int)row["id"];
                    usuario.Nombres = (string)row["nombre"];
                    usuario.Identificacion = (int)row["documento"];
                    usuario.Telefono = (string)row["telefono"];
                    usuario.Direccion = (string)row["direccion"];
                    usuario.Cargo.IdTipo = (int)row["idcargo"];
                    usuario.Cargo.Descripcion = (string)row["cargo"];
                    usuario.Usuario_ = (string)row["usuario"];
                    usuario.Contrasenia = (string)row["contrasenia"];
                    var estado=(string)row["estado"];
                    if (estado.Equals("Activo"))
                    {
                        usuario.Estado = true;
                    }
                    else
                    {
                        usuario.Estado = false;
                    }
                }
               /* var tablaPermiso = daoPermiso.ListarpermisoUsuario(usuario.Id);
                List<Permiso> permisos = new List<Permiso>();
                foreach (DataRow row in tablaPermiso.Rows)
                {
                    var permiso = new Permiso();
                    permiso.IdPermiso = (int)row["idpermiso"];
                    permiso.Descripcion = (string)row["descripcionpermiso"];
                    permisos.Add(permiso);
                }
                usuario.Permisos = permisos;*/
                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cargar el usuario.\n" + ex.Message);
            }
            finally
            {
                miConexion.MiConexion.Close();
            }
        }

        /// <summary>
        /// Edita el usuario logueado en el momento del sistema
        /// </summary>
        /// <param name="idUsuario">id usuario a editar</param>
        /// <param name="direccion">dirección a editar</param>
        /// <param name="telefono">teléfono a editar</param>
        /// <param name="usuario">usuario a editar</param>
        public void EditaUsuarioPropio(int idUsuario, string direccion, string telefono, string usuario)
        {
            try
            {
                CargarComandoStoredProcedure(sqlEditausuarioPropio);
                miComando.Parameters.AddWithValue("idusuario", idUsuario);
                miComando.Parameters.AddWithValue("direccion", direccion);
                miComando.Parameters.AddWithValue("tefono", telefono);
                miComando.Parameters.AddWithValue("usuario", usuario);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al editar el usuario.\n" + ex.Message);
            }
            finally
            {
                miConexion.MiConexion.Close();
            }
        }

        /// <summary>
        /// Obtiene los datos del Usuario de la factura de venta para su impresión.
        /// </summary>
        /// <param name="numero">Número de la Factura de Venta.</param>
        /// <returns></returns>
        public DataSet PrintUsuarioVenta(int id)
        {
            var dataSet = new DataSet();
            try
            {
                CargarAdapterStoredProcedure(PrintUsuarioVenta_);
                miAdapter.SelectCommand.Parameters.AddWithValue("id", id);
                miAdapter.Fill(dataSet, "Usuario");
                return dataSet;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorConsulta + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene los datos del Usuario para su impresión.
        /// </summary>
        /// <param name="id">Id del Usuario.</param>
        /// <returns></returns>
        public DataSet PrintUsuario(int id)
        {
            var dataSet = new DataSet();
            try
            {
                CargarAdapterStoredProcedure(PrintUsuario_);
                miAdapter.SelectCommand.Parameters.AddWithValue("", id);
                miAdapter.Fill(dataSet, "Usuario");
                return dataSet;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorConsulta + ex.Message);
            }
        }

        public DataSet PrintUsuarioRemision(int numero)
        {
            var dataSet = new DataSet();
            try
            {
                CargarAdapterStoredProcedure("print_usuario_remision");
                miAdapter.SelectCommand.Parameters.AddWithValue("numero", numero);
                miAdapter.Fill(dataSet, "Usuario");
                return dataSet;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorConsulta + ex.Message);
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