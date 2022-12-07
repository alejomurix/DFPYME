using System;
using System.Collections.Generic;
using System.Data;
using DTO.Clases;
using Npgsql;

namespace DataAccessLayer.Clases
{
    public class DaoCuentaPuc
    {
        /// <summary>
        /// Representa el objeto de conexión.
        /// </summary>
        private Conexion miConexion;

        /// <summary>
        /// Representa una sentenca en sql.
        /// </summary>
        private NpgsqlCommand miComando;

        public DaoCuentaPuc()
        {
            this.miConexion = new Conexion();
        }

        public int IdSubCuenta(char[] codigo)
        {
            try
            {
                CargarComando("id_sub_cuenta");
                miComando.Parameters.AddWithValue("clase", codigo[0].ToString());
                miComando.Parameters.AddWithValue("grupo", codigo[1].ToString());
                miComando.Parameters.AddWithValue("cuenta", codigo[2].ToString() + codigo[3].ToString());
                miComando.Parameters.AddWithValue("subcuenta", codigo[4].ToString() + codigo[5].ToString());
                miConexion.MiConexion.Open();
                var id = Convert.ToInt32(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return id;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al obtener el código de la cuenta.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public bool ValidarSubCuenta(char[] codigo)
        {
            try
            {
                CargarComando("validar_sub_cuenta_puc");
                miComando.Parameters.AddWithValue("clase", codigo[0].ToString());
                miComando.Parameters.AddWithValue("grupo", codigo[1].ToString());
                miComando.Parameters.AddWithValue("cuenta", codigo[2].ToString() + codigo[3].ToString());
                miComando.Parameters.AddWithValue("subcuenta", codigo[4].ToString() + codigo[5].ToString());
                miConexion.MiConexion.Open();
                var existe = Convert.ToBoolean(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return existe;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al validar la cuenta.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public void IngresarEgresoCuenta(ConceptoEgreso cuenta)
        {
            try
            {
                CargarComando("insertar_egreso_cuenta");
                miComando.Parameters.AddWithValue("idegreso", cuenta.Id);
                miComando.Parameters.AddWithValue("codigo", cuenta.IdCuenta);
                miComando.Parameters.AddWithValue("concepto", cuenta.Nombre);
                miComando.Parameters.AddWithValue("valor", Convert.ToInt32(cuenta.Numero));
                miComando.Parameters.AddWithValue("tarifa", cuenta.Tarifa);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al ingresar la Cuenta del Egreso.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public List<ConceptoEgreso> CuentasEgreso(int idEgreso)
        {
            var lst = new List<ConceptoEgreso>();
            try
            {
                CargarComando("egresos_puc");
                miComando.Parameters.AddWithValue("id", idEgreso);
                miConexion.MiConexion.Open();
                NpgsqlDataReader reader = miComando.ExecuteReader();
                while (reader.Read())
                {
                    var cuenta = new ConceptoEgreso();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("\n" + ex.Message + "\n");
            }
            finally { miConexion.MiConexion.Close(); }
            return lst;
        }

        public void EditarEgresoCuenta(ConceptoEgreso cuenta)
        {
            try
            {
                CargarComando("editar_concepto_egreso");
                miComando.Parameters.AddWithValue("id", cuenta.Id);
                miComando.Parameters.AddWithValue("concepto", cuenta.Nombre);
                miComando.Parameters.AddWithValue("valor", Convert.ToInt32(cuenta.Numero));
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al editar la Cuenta del Egreso.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public void EliminarEgresoCuenta(int id)
        {
            try
            {
                CargarComando("eliminar_concepto_egreso");
                miComando.Parameters.AddWithValue("id", id);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al eliminar la Cuenta del Egreso.\n" + ex.Message);
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
    }
}