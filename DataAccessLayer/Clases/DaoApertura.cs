using System;
using System.Data;
using System.Linq;
using System.Text;
using DTO.Clases;
using Npgsql;

namespace DataAccessLayer.Clases
{
    public class DaoApertura
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

        private DaoCierre miDaoCierre;

        private string ErrorIngresar = "Ocurrió un error al ingresar la Apertura de Caja.\n";

        private string ErrorLista = "Ocurrió un error al listar los datos de Apertura de Caja.\n";

        private string ErrorEdita = "Ocurrió un error al editar los datos.\n";

        public DaoApertura()
        {
            this.miConexion = new Conexion();
            this.miDaoCierre = new DaoCierre();
        }

        public int Ingresar(Apertura apertura)
        {
            try
            {
                CargarComando("insertar_apertura");
                miComando.Parameters.AddWithValue("fecha", apertura.Fecha);
                miComando.Parameters.AddWithValue("hora", apertura.Fecha.TimeOfDay);
                miComando.Parameters.AddWithValue("caja", apertura.Caja.Id);
                miComando.Parameters.AddWithValue("turno", apertura.Turno.Id);
                miComando.Parameters.AddWithValue("usuario", apertura.Usuario.Id);
                miComando.Parameters.AddWithValue("valor", apertura.Valor);
                miConexion.MiConexion.Open();
                var id = Convert.ToInt32(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                EliminarRegistroApertura(apertura.Caja.Id);
                IngresarRegistroApertura(apertura.Caja.Id, id);
                return id;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorIngresar + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

      /*  public long CountApertura(DateTime fecha, int idCaja, int idTurno)
        {
            try
            {
                CargarComando("count_apertura");
                miComando.Parameters.AddWithValue("", fecha);
                miComando.Parameters.AddWithValue("", idCaja);
                miComando.Parameters.AddWithValue("", idTurno);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al contar la apertura.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }*/

        public Apertura Apertura(int id)
        {
            try
            {
                var apertura = new Apertura();
                CargarComando("apertura");
                miComando.Parameters.AddWithValue("", id);
                miConexion.MiConexion.Open();
                NpgsqlDataReader miReader = miComando.ExecuteReader();
                while (miReader.Read())
                {
                    apertura.Id = miReader.GetInt32(0);
                    apertura.Fecha = miReader.GetDateTime(3);
                    apertura.Caja.Id = miReader.GetInt32(4);
                    apertura.Turno.Id = miReader.GetInt32(5);
                    apertura.Usuario.Id = miReader.GetInt32(6);
                    apertura.Valor = miReader.GetInt32(7);
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return apertura;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar la apertura.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public Apertura Apertura(DateTime fecha, int idcaja)
        {
            try
            {
                var apertura = new Apertura();
                CargarComando("aperturas");
                miComando.Parameters.AddWithValue("fecha", fecha);
                miComando.Parameters.AddWithValue("caja", idcaja);
                miConexion.MiConexion.Open();
                NpgsqlDataReader miReader = miComando.ExecuteReader();
                while (miReader.Read())
                {
                    apertura.Id = miReader.GetInt32(0);
                    var fecha_ = miReader.GetDateTime(1);
                    var hora = miReader.GetDateTime(2);
                    apertura.Fecha = 
                        new DateTime(fecha_.Year, fecha_.Month, fecha_.Day, hora.Hour, hora.Minute, hora.Second);
                    apertura.Caja.Id = miReader.GetInt32(3);
                    apertura.Turno.Id = miReader.GetInt32(4);
                    apertura.Usuario.Id = miReader.GetInt32(5);
                    apertura.Valor = miReader.GetInt32(6);
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return apertura;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar la apertura.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public Apertura AperturaAnterior(DateTime fecha, int idcaja)
        {
            try
            {
                var apertura = new Apertura();
                CargarComando("apertura_anterior");
                miComando.Parameters.AddWithValue("fecha", fecha);
                miComando.Parameters.AddWithValue("caja", idcaja);
                miConexion.MiConexion.Open();
                NpgsqlDataReader miReader = miComando.ExecuteReader();
                while (miReader.Read())
                {
                    apertura.Id = miReader.GetInt32(0);
                    var fecha_ = miReader.GetDateTime(1);
                    var hora = miReader.GetDateTime(2);
                    apertura.Fecha =
                        new DateTime(fecha_.Year, fecha_.Month, fecha_.Day, hora.Hour, hora.Minute, hora.Second);
                    apertura.Caja.Id = miReader.GetInt32(3);
                    apertura.Turno.Id = miReader.GetInt32(4);
                    apertura.Usuario.Id = miReader.GetInt32(5);
                    apertura.Valor = miReader.GetInt32(6);
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return apertura;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar la apertura.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public Apertura Apertura(DateTime fecha, int idcaja, int idturno)
        {
            try
            {
                var apertura = new Apertura();
                CargarComando("aperturas");
                miComando.Parameters.AddWithValue("fecha", fecha);
                miComando.Parameters.AddWithValue("caja", idcaja);
                miComando.Parameters.AddWithValue("turno", idturno);
                miConexion.MiConexion.Open();
                NpgsqlDataReader miReader = miComando.ExecuteReader();
                while (miReader.Read())
                {
                    apertura.Id = miReader.GetInt32(0);
                    var fecha_ = miReader.GetDateTime(1);
                    var hora = miReader.GetDateTime(2);
                    apertura.Fecha =
                        new DateTime(fecha_.Year, fecha_.Month, fecha_.Day, hora.Hour, hora.Minute, hora.Second);
                    apertura.Caja.Id = miReader.GetInt32(3);
                    apertura.Turno.Id = miReader.GetInt32(4);
                    apertura.Usuario.Id = miReader.GetInt32(5);
                    apertura.Valor = miReader.GetInt32(6);
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return apertura;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar la apertura.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable Aperturas(int idCaja, int idTurno)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("aperturas_cierre");
                miAdapter.SelectCommand.Parameters.AddWithValue("", idCaja);
                miAdapter.SelectCommand.Parameters.AddWithValue("", idTurno);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar las aperturas.\n" + ex.Message);
            }
        }


        // Registros de apertura
        /// <summary>
        /// 
        /// </summary>
        /// <param name="numero">Número que representa el ID de la apertura.</param>
        /// <returns></returns>
        public int IngresarRegistroApertura(int idCaja, int numero)
        {
            try
            {
                CargarComando("insertar_apertura_registro");
                miComando.Parameters.AddWithValue("idCaja", idCaja);
                miComando.Parameters.AddWithValue("numero", numero);
                miConexion.MiConexion.Open();
                var id = Convert.ToInt32(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return id;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al ingresar el registro de la apertura.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable RegistrosApertura(int idCaja)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("consulta_apertura_registro");
                miAdapter.SelectCommand.Parameters.AddWithValue("idcaja", idCaja);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los registros de apertura.\n" + ex.Message);
            }
        }

        public Apertura RegistroApertura(int idCaja)
        {
            try
            {
                CargarComando("consulta_apertura_registro");
                miComando.Parameters.AddWithValue("idcaja", idCaja);
                var registro = new Apertura();
                miConexion.MiConexion.Open();
                NpgsqlDataReader reader = miComando.ExecuteReader();
                while (reader.Read())
                {
                    registro.Id = reader.GetInt32(0);
                    registro.Valor = reader.GetInt32(2);
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return registro;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el registro de apertura.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public void EditarApertura(int id, int valor)
        {
            try
            {
                CargarComando("editar_valor_apertura");
                miComando.Parameters.AddWithValue("", id);
                miComando.Parameters.AddWithValue("", valor);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al editar la apertura.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public void EliminarRegistroApertura(int idCaja)
        {
            try
            {
                CargarComando("eliminar_apertura_registro");
                miComando.Parameters.AddWithValue("idcaja", idCaja);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al ingresar el registro de la apertura.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        /*
        public Apertura Caja(int id)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapter("listado_base_caja_id");
                miAdapter.SelectCommand.Parameters.AddWithValue("id", id);
                miAdapter.Fill(tabla);
                var cRow = tabla.AsEnumerable().Single();
                Apertura caja = new Apertura
                {
                    Id = Convert.ToInt32(cRow["Id"]),
                    Fecha = Convert.ToDateTime(cRow["Fecha"]),
                    Apertura = Convert.ToInt32(cRow["Apertura"]),
                    Cierre = Convert.ToInt32(cRow["Cierre"])
                };
                return caja;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorLista + ex.Message);
            }
        }

        public DataTable Listado(int rowBase, int rowMax)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapter("listado_base_caja");
                miAdapter.Fill(rowBase, rowMax, tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorLista + ex.Message);
            }
        }

        public long GetRowsListado()
        {
            try
            {
                CargarComando("count_listado_base_caja");
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorLista + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable Listado(DateTime fecha, int rowBase, int rowMax)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapter("listado_base_caja");
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.Fill(rowBase, rowMax, tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorLista + ex.Message);
            }
        }

        public long GetRowsListado(DateTime fecha)
        {
            try
            {
                CargarComando("count_listado_base_caja");
                miComando.Parameters.AddWithValue("fecha", fecha);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorLista + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public void Edita(Apertura baseCaja)
        {
            try
            {
                CargarComando("editar_base_caja");
                miComando.Parameters.AddWithValue("id", baseCaja.Id);
                miComando.Parameters.AddWithValue("fecha", baseCaja.Fecha);
                miComando.Parameters.AddWithValue("apertura", baseCaja.Apertura);
                miComando.Parameters.AddWithValue("cierre", baseCaja.Cierre);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorEdita + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataSet Print(int idCaja, DateTime fecha)
        {
            var dataSet = new DataSet();
            try
            {
                CargarAdapter("print_base_caja");
                miAdapter.SelectCommand.Parameters.AddWithValue("idCaja", idCaja);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.Fill(dataSet, "Base");
                return dataSet;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
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