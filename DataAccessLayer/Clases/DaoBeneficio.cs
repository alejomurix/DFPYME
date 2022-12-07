using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DTO.Clases;
using Npgsql;

namespace DataAccessLayer.Clases
{
    public class DaoBeneficio
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

        public DaoBeneficio()
        {
            this.miConexion = new Conexion();
        }

        public void Ingresar(Cliente beneficio)
        {
            try
            {
                if (!Existe(beneficio.NitCliente))
                {
                    CargarComando("insertar_beneficio");
                    miComando.Parameters.AddWithValue("id", beneficio.NitCliente);
                    miComando.Parameters.AddWithValue("nombre", beneficio.NombresCliente);
                    miComando.Parameters.AddWithValue("telefono", beneficio.TelefonoCliente);
                    miComando.Parameters.AddWithValue("idtipo", beneficio.IdRegimen);
                    miComando.Parameters.AddWithValue("celular", beneficio.CelularCliente);
                    miComando.Parameters.AddWithValue("idciudad", beneficio.IdCiudad);
                    miComando.Parameters.AddWithValue("direccion", beneficio.DireccionCliente);
                    miConexion.MiConexion.Open();
                    miComando.ExecuteNonQuery();
                    miConexion.MiConexion.Close();
                    miComando.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al ingresar el Beneficiario.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public bool Existe(string nit)
        {
            try
            {
                CargarComando("existe_beneficio");
                miComando.Parameters.AddWithValue("nit", nit);
                miConexion.MiConexion.Open();
                var existe = Convert.ToBoolean(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return existe;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al verificar el Tercero.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public Cliente BeneficiarioId(int id)
        {
            try
            {
                CargarComando("beneficiarios_id");
                miComando.Parameters.AddWithValue("id", id);
                var cliente = new Cliente();
                miConexion.MiConexion.Open();
                NpgsqlDataReader reader = miComando.ExecuteReader();
                while (reader.Read())
                {
                    cliente.IdTipoCliente = reader.GetInt32(0);
                    cliente.NitCliente = reader.GetString(1);
                    cliente.NombresCliente = reader.GetString(2);
                    cliente.TelefonoCliente = reader.GetString(3);
                    cliente.IdRegimen = reader.GetInt32(4);
                    cliente.CelularCliente = reader.GetString(5);
                    cliente.IdCiudad = reader.GetInt32(6);
                    cliente.DireccionCliente = reader.GetString(7);
                }
                miComando.Dispose();
                miConexion.MiConexion.Close();
                return cliente;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el Beneficiario.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public Cliente BeneficiarioNit(string nit)
        {
            try
            {
                CargarComando("beneficiarios_nit");
                miComando.Parameters.AddWithValue("nit", nit);
                var cliente = new Cliente();
                miConexion.MiConexion.Open();
                NpgsqlDataReader reader = miComando.ExecuteReader();
                while (reader.Read())
                {
                    cliente.IdTipoCliente = reader.GetInt32(0);
                    cliente.NitCliente = reader.GetString(1);
                    cliente.NombresCliente = reader.GetString(2);
                    cliente.TelefonoCliente = reader.GetString(3);
                    cliente.IdRegimen = reader.GetInt32(4);
                }
                miComando.Dispose();
                miConexion.MiConexion.Close();
                return cliente;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el Beneficiario.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable BeneficiariosNit(string nit)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapter("beneficiarios_nit");
                miAdapter.SelectCommand.Parameters.AddWithValue("nit", nit);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los Beneficiarios.\n" + ex.Message);
            }
        }

        public DataTable BeneficiariosNombre(string nombre)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapter("beneficiarios_nombre");
                miAdapter.SelectCommand.Parameters.AddWithValue("nombre", nombre);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los Beneficiarios.\n" + ex.Message);
            }
        }

        public DataTable BeneficiariosT(string criterio)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapter("beneficiarios");
                miAdapter.SelectCommand.Parameters.AddWithValue("nombre", criterio);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los Beneficiarios.\n" + ex.Message);
            }
        }

        public List<Cliente> Beneficiarios(string criterio)
        {
            try
            {
                var clientes = new List<Cliente>();
                CargarComando("beneficiarios");
                miComando.Parameters.AddWithValue("", criterio);
                miConexion.MiConexion.Open();
                NpgsqlDataReader reader = miComando.ExecuteReader();
                while (reader.Read())
                {
                    var cliente = new Cliente();
                    cliente.IdTipoCliente = reader.GetInt32(0);
                    cliente.NitCliente = reader.GetString(1);
                    cliente.NombresCliente = reader.GetString(2);
                    cliente.TelefonoCliente = reader.GetString(3);
                    cliente.IdRegimen = reader.GetInt32(4);
                    cliente.CelularCliente = reader.GetString(5);
                    cliente.IdCiudad = reader.GetInt32(6);
                    cliente.DireccionCliente = reader.GetString(7);
                    clientes.Add(cliente);
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return clientes;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el proveedor.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public void EditarBeneficiario(Cliente beneficiario)
        {
            try
            {
                CargarComando("editar_tercero");
                miComando.Parameters.AddWithValue("id", beneficiario.IdTipoCliente);
                miComando.Parameters.AddWithValue("nit", beneficiario.NitCliente);
                miComando.Parameters.AddWithValue("nombre", beneficiario.NombresCliente);
                miComando.Parameters.AddWithValue("telefono", beneficiario.TelefonoCliente);
                miComando.Parameters.AddWithValue("idregimen", beneficiario.IdRegimen);
                miComando.Parameters.AddWithValue("celular", beneficiario.CelularCliente);
                miComando.Parameters.AddWithValue("idciudad", beneficiario.IdCiudad);
                miComando.Parameters.AddWithValue("direccion", beneficiario.DireccionCliente);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al editar el Tercero.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Clone(); }
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