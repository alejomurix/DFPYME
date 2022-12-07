using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DTO.Clases;
using Npgsql;

namespace DataAccessLayer.Clases
{
    public class DaoPuc
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

        public DaoPuc()
        {
            this.miConexion = new Conexion();
        }

        public bool ExisteClase(string numero)
        {
            try
            {
                CargarComando("existe_clase_puc");
                miComando.Parameters.AddWithValue("numero", numero);
                miConexion.MiConexion.Open();
                var existe = Convert.ToBoolean(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return existe;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al comprobar la clase.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public bool ExisteGrupo(string numero)
        {
            try
            {
                CargarComando("existe_grupo_puc");
                miComando.Parameters.AddWithValue("numero", numero);
                miConexion.MiConexion.Open();
                var existe = Convert.ToBoolean(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return existe;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al comprobar el grupo.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public bool ExisteCuenta(string numero)
        {
            try
            {
                CargarComando("existe_cuenta_puc");
                miComando.Parameters.AddWithValue("numero", numero);
                miConexion.MiConexion.Open();
                var existe = Convert.ToBoolean(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return existe;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al comprobar la cuenta.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public bool ExisteSubCuenta(string numero)
        {
            try
            {
                CargarComando("existe_sub_cuenta_puc");
                miComando.Parameters.AddWithValue("numero", numero);
                miConexion.MiConexion.Open();
                var existe = Convert.ToBoolean(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return existe;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al comprobar la sub-cuenta.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public int IngresarClase(ClasePuc clase)
        {
            try
            {
                CargarComando("insertar_clase_puc");
                miComando.Parameters.AddWithValue("numero", clase.Numero);
                miComando.Parameters.AddWithValue("nombre", clase.Nombre);
                miConexion.MiConexion.Open();
                var id = Convert.ToInt32(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return id;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al ingresar la Clase del PUC.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public int IngresarGrupo(GrupoPuc grupo)
        {
            try
            {
                CargarComando("insertar_grupo_puc");
                miComando.Parameters.AddWithValue("idclase", grupo.IdClase);
                miComando.Parameters.AddWithValue("numero", grupo.Numero);
                miComando.Parameters.AddWithValue("nombre", grupo.Nombre);
                miConexion.MiConexion.Open();
                var id = Convert.ToInt32(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return id;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al ingresar el Grupo del PUC.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public int IngresarCuenta(CuentaPuc cuenta)
        {
            try
            {
                CargarComando("insertar_cuenta_puc");
                miComando.Parameters.AddWithValue("idgrupo", cuenta.IdGrupo);
                miComando.Parameters.AddWithValue("numero", cuenta.Numero);
                miComando.Parameters.AddWithValue("nombre", cuenta.Nombre);
                miConexion.MiConexion.Open();
                var id = Convert.ToInt32(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return id;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al ingresar la Cuenta del PUC.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public int IngresarSubCuenta(SubCuentaPuc sCuenta)
        {
            try
            {
                CargarComando("insertar_sub_cuenta_puc");
                miComando.Parameters.AddWithValue("idcuenta", sCuenta.IdCuenta);
                miComando.Parameters.AddWithValue("numero", sCuenta.Numero);
                miComando.Parameters.AddWithValue("nombre", sCuenta.Nombre);
                miComando.Parameters.AddWithValue("estado", sCuenta.Estado);
                miConexion.MiConexion.Open();
                var id = Convert.ToInt32(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return id;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al ingresar la Sub-Cuenta del PUC.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable Clases()
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapter("clases_puc");
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar las Clases del PUC.\n" + ex.Message);
            }
        }

        public DataTable Clases(int id)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapter("clases_puc");
                miAdapter.SelectCommand.Parameters.AddWithValue("id", id);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar las Clases del PUC.\n" + ex.Message);
            }
        }

        public DataTable Grupos(int idClase)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapter("grupos_puc");
                miAdapter.SelectCommand.Parameters.AddWithValue("idclase", idClase);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los Grupos del PUC.\n" + ex.Message);
            }
        }

        public DataTable GrupoId(int id)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapter("grupos_puc_id");
                miAdapter.SelectCommand.Parameters.AddWithValue("id", id);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el Grupo del PUC.\n" + ex.Message);
            }
        }

        public DataTable Cuentas(int idGrupo)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapter("cuentas_puc");
                miAdapter.SelectCommand.Parameters.AddWithValue("idgrupo", idGrupo);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar las Cuentas del PUC.\n" + ex.Message);
            }
        }

        public DataTable Cuenta(int id)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapter("cuenta_puc");
                miAdapter.SelectCommand.Parameters.AddWithValue("id", id);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar las Cuentas del PUC.\n" + ex.Message);
            }
        }

        public DataTable SubCuentas(int idCuenta)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapter("sub_cuentas_puc");
                miAdapter.SelectCommand.Parameters.AddWithValue("idcuenta", idCuenta);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar las Sub-Cuentas del PUC.\n" + ex.Message);
            }
        }

        public DataTable SubCuentaId(int id)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapter("sub_cuenta_puc_id");
                miAdapter.SelectCommand.Parameters.AddWithValue("id", id);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar las Sub Cuentas del PUC.\n" + ex.Message);
            }
        }

        public DataTable CuentasDelPuc(int idClase)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapter("cuentas_del_puc");
                miAdapter.SelectCommand.Parameters.AddWithValue("numero", idClase);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar las Clases del PUC.\n" + ex.Message);
            }
        }

        public string GetSubCuenta(int idSubcuenta)
        {
            var cta = "";
            var tabla = new DataTable();
            try
            {
                CargarAdapter("sub_cuentas_del_puc");
                miAdapter.SelectCommand.Parameters.AddWithValue("idcuenta", idSubcuenta);
                miAdapter.Fill(tabla);
                foreach(DataRow row in tabla.Rows)
                {
                    cta = row["numero"].ToString();
                }
                return cta;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar la Clases del PUC.\n" + ex.Message);
            }
        }

        public CuentaPuc Cuenta(string numero)
        {
            try
            {
                var cuenta = new CuentaPuc();
                CargarComando("cuenta_del_puc");
                miComando.Parameters.AddWithValue("", numero);
                miConexion.MiConexion.Open();
                NpgsqlDataReader reader = miComando.ExecuteReader();
                while (reader.Read())
                {
                    cuenta.Id = reader.GetInt32(1);
                    cuenta.Numero = reader.GetString(2);
                    cuenta.Nombre = reader.GetString(3);
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return cuenta;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar la cuenta.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public CuentaPuc CuentaPuc(string numero)
        {
            try
            {
                var cuenta = new CuentaPuc();
                CargarComando("cuenta_de_cuenta_puc");
                miComando.Parameters.AddWithValue("", numero);
                miConexion.MiConexion.Open();
                NpgsqlDataReader reader = miComando.ExecuteReader();
                while (reader.Read())
                {
                    cuenta.Id = reader.GetInt32(1);
                    cuenta.Numero = reader.GetString(2);
                    cuenta.Nombre = reader.GetString(3);
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return cuenta;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar la cuenta.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public void EditarSubCuenta(int id, bool estado)
        {
            try
            {
                CargarComando("editar_sub_cuenta_puc");
                miComando.Parameters.AddWithValue("", id);
                miComando.Parameters.AddWithValue("", estado);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al editar la cuenta.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public bool ExisteSubCuentas(int idClase)
        {
            try
            {
                CargarComando("existen_sub_cuentas");
                miComando.Parameters.AddWithValue("", idClase);
                miConexion.MiConexion.Open();
                var existe = Convert.ToBoolean(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return existe;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar las cuentas.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }


        // Relacion de Cuentas
        public long GetRowsRelacion()
        {
            try
            {
                CargarComando("count_relacion_cuenta");
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (InvalidCastException)
            {
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al realizar el conteo de registros de relación de cuenta.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable Relaciones()
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("relaciones_cuenta");
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar las relaciones.\n" + ex.Message);
            }
        }

        public void IngresarRelacion(SubCuentaPuc cuenta)
        {
            try
            {
                CargarComando("insertar_relacion_cuenta");
                miComando.Parameters.AddWithValue("", cuenta.Id);
                miComando.Parameters.AddWithValue("", cuenta.IdCuenta);
                miComando.Parameters.AddWithValue("", cuenta.Concepto);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al ingresar la relación de la cuenta.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public void EditarRelacion(SubCuentaPuc cuenta)
        {
            try
            {
                CargarComando("editar_relacion_cuenta");
                miComando.Parameters.AddWithValue("", cuenta.Id);
                miComando.Parameters.AddWithValue("", cuenta.IdCuenta);
                miComando.Parameters.AddWithValue("", cuenta.Concepto);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al editar la relación de la cuenta.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        /*
         try
            {
                CargarComando("");
                miComando.Parameters.Add("", );
                miComando.Parameters.Add("numero", );
                miComando.Parameters.Add("nombre", );
                miConexion.MiConexion.Open();
                var id = Convert.ToInt32(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return id;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al ingresar la Clase del PUC.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
         * 
         var tabla = new DataTable();
            try
            {
                CargarAdapter("");
                miAdapter.SelectCommand.Parameters.AddWithValue("", );
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar las Clases del PUC.\n" + ex.Message);
            }
         */

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