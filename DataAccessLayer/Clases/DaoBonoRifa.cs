using System;
using System.Collections.Generic;
using System.Data;
using DTO.Clases;
using Npgsql;

namespace DataAccessLayer.Clases
{
    public class DaoBonoRifa
    {
        /// <summary>
        /// Objeto que me permite a acceder a la conexión a base de datos PostgreSQL.
        /// </summary>
        private Conexion miConexion;

        /// <summary>
        /// Representa un comando de ejecucion de sentencias SQL a PostgreSQL.
        /// </summary>
        private NpgsqlCommand miComando;

        /// <summary>
        /// Representa un adaptador de sentencias SQL a PostgreSQL.
        /// </summary>
        private NpgsqlDataAdapter miAdapter;

        public DaoBonoRifa()
        {
            this.miConexion = new Conexion();
        }

        public void Ingresar(Bono bono)
        {
            try
            {
                this.CargarComando("insertar_bono_rifa");
                this.miComando.Parameters.AddWithValue("", bono.Numero);
                this.miComando.Parameters.AddWithValue("", bono.Fecha);
                this.miComando.Parameters.AddWithValue("", bono.Valor);
                this.miComando.Parameters.AddWithValue("", bono.Canje);
                this.miComando.Parameters.AddWithValue("", bono.Concepto);

                this.miConexion.MiConexion.Open();
                this.miComando.ExecuteNonQuery();
                this.miConexion.MiConexion.Close();
                this.miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al ingresar el sorteo.\n" + ex.Message);
            }
            finally { this.miConexion.MiConexion.Close(); }
        }

        public DataTable BonosRifa()
        {
            try
            {
                this.CargarAdapter("bonos_rifa");
                var tabla = new DataTable();
                this.miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al listar los bonos de rifas.\n" + ex.Message);
            }
        }

        public void EditarEstado(bool estado)
        {
            try
            {
                this.CargarComando("editar_estado_bono_rifa");
                this.miComando.Parameters.AddWithValue("", estado);
                this.miConexion.MiConexion.Open();
                this.miComando.ExecuteNonQuery();
                this.miConexion.MiConexion.Close();
                this.miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al editar el estado del bono.\n" + ex.Message);
            }
            finally { this.miConexion.MiConexion.Close(); }
        }

        public Bono BonoRifa()
        {
            try
            {
                var bono = new Bono();
                this.CargarComando("bono_rifa");
                this.miConexion.MiConexion.Open();
                NpgsqlDataReader reader = this.miComando.ExecuteReader();
                while (reader.Read())
                {
                    bono.Id = reader.GetInt32(0);
                    bono.Numero = reader.GetString(1);
                    bono.Fecha = reader.GetDateTime(2);
                    bono.Valor = reader.GetInt32(3);
                    bono.Canje = reader.GetBoolean(4);
                    bono.Concepto = reader.GetString(5);
                }
                this.miConexion.MiConexion.Close();
                this.miComando.Dispose();
                bono.IdMarcas = this.IdMarcas(bono.Id);
                return bono;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al ingresar " + ex.Message);
            }
            finally { this.miConexion.MiConexion.Close(); }
        }

        public List<int> IdMarcas(int idSorteo)
        {
            try
            {
                var idMarcas = new List<int>();
                this.CargarComando("marcas_de_bono_rifa_");
                this.miComando.Parameters.AddWithValue("", idSorteo);
                this.miConexion.MiConexion.Open();
                NpgsqlDataReader reader = this.miComando.ExecuteReader();
                while (reader.Read())
                {
                    idMarcas.Add(reader.GetInt32(0));
                }
                this.miConexion.MiConexion.Close();
                this.miComando.Dispose();
                return idMarcas;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar las marcas del sorteo." + ex.Message);
            }
            finally { this.miConexion.MiConexion.Close(); }
        }

        public void Eliminar(int id)
        {
            try
            {
                this.CargarComando("eliminar_bono_rifa");
                this.miComando.Parameters.AddWithValue("", id);
                this.miConexion.MiConexion.Open();
                this.miComando.ExecuteNonQuery();
                this.miConexion.MiConexion.Close();
                this.miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al eliminar el bono.\n" + ex.Message);
            }
            finally { this.miConexion.MiConexion.Close(); }
        }


        public void IngresarMarcaDeBono(int idSorteo, int idMarca)
        {
            try
            {
                this.CargarComando("insertar_bono_rifa_marca");
                this.miComando.Parameters.AddWithValue("", idSorteo);
                this.miComando.Parameters.AddWithValue("", idMarca);
                this.miConexion.MiConexion.Open();
                this.miComando.ExecuteNonQuery();
                this.miConexion.MiConexion.Close();
                this.miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al ingresar la marca del sorteo.\n" + ex.Message);
            }
            finally { this.miConexion.MiConexion.Close(); }
        }

        public DataTable MarcasDeBono(int idBono)
        {
            try
            {
                this.CargarAdapter("marcas_de_bono_rifa");
                this.miAdapter.SelectCommand.Parameters.AddWithValue("", idBono);
                var tabla = new DataTable();
                this.miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al listar las marcas del sorteo.\n" + ex.Message);
            }
        }


        public void EliminarMarcaDeBono(int id)
        {
            try
            {
                this.CargarComando("eliminar_bono_rifa_marca");
                this.miComando.Parameters.AddWithValue("", id);
                this.miConexion.MiConexion.Open();
                this.miComando.ExecuteNonQuery();
                this.miConexion.MiConexion.Close();
                this.miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al eliminar la marca del sorteo.\n" + ex.Message);
            }
            finally { this.miConexion.MiConexion.Close(); }
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
        /// Inicializa una nueva instancia de NpgsqlDataAdapter de tipo StoredProcedure.
        /// </summary>
        /// <param name="cmd">Comando a ejecutar.</param>
        private void CargarAdapter(string cmd)
        {
            this.miAdapter = new NpgsqlDataAdapter(cmd, miConexion.MiConexion);
            this.miAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        }
    }
}