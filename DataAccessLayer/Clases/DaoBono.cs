using System;
using System.Data;
using DTO.Clases;
using Npgsql;

namespace DataAccessLayer.Clases
{
    /// <summary>
    /// Representa una clase de Acceso a datos para un Bono.
    /// </summary>
    public class DaoBono
    {
        #region Atributos

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

        #endregion

        #region Funciones

        /// <summary>
        /// Representa la función insertar_bono.
        /// </summary>
        private string Ingresar_ = "insertar_bono";

        /// <summary>
        /// Representa la función insertar_seguimiento_bono.
        /// </summary>
        private string IngresarSeguimiento_ = "insertar_seguimiento_bono";

        #endregion

        #region Mensajes

        /// <summary>
        /// Representa el texto: Ocurrió un error al ingresar el bono.
        /// </summary>
        private string ErrorIngresar = "Ocurrió un error al ingresar el bono.\n";

        /// <summary>
        /// Representa el texto: Ocurrió un error al ingresar el saldo en el bono.
        /// </summary>
        private string ErrorIngSeguimiento = "Ocurrió un error al ingresar el saldo en el bono.\n";

        #endregion

        /// <summary>
        /// Inicializa una nueva instancia de la clase DaoBono.
        /// </summary>
        public DaoBono()
        {
            this.miConexion = new Conexion();
        }

        //BONO

        /// <summary>
        /// Ingresa los datos de Bono a la base de datos.
        /// </summary>
        /// <param name="bono">Bono a ser ingresado.</param>
        public int Ingresar(Bono bono)
        {
            var miDaoConsecutivo = new DaoConsecutivo();
            try
            {
                CargarComando(Ingresar_);
                miComando.Parameters.AddWithValue("cliente", bono.Cliente);
                miComando.Parameters.AddWithValue("factura", bono.Factura);
                miComando.Parameters.AddWithValue("fecha", bono.Fecha);
                miComando.Parameters.AddWithValue("valor", bono.Valor);
                miComando.Parameters.AddWithValue("canje", bono.Canje);
                miComando.Parameters.AddWithValue("usuario", bono.IdUsuario);
                miComando.Parameters.AddWithValue("caja", bono.IdCaja);
                miComando.Parameters.AddWithValue("numero", bono.Numero);
                miComando.Parameters.AddWithValue("concepto", bono.Concepto);
                miConexion.MiConexion.Open();
                var id = Convert.ToInt32(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                miDaoConsecutivo.ActualizarConsecutivo("Bono");
                return id;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorIngresar + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Obtiene el resultado de la consulta de Bono.
        /// </summary>
        /// <param name="cliente">Cliente a consultar bono.</param>
        /// <returns></returns>
        public DataTable Bonos(string cliente)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapter("bonos");
                miAdapter.SelectCommand.Parameters.AddWithValue("cliente", cliente);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los bonos.\n" + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene el resultado de la consulta de Bono.
        /// </summary>
        /// <param name="cliente">Cliente a consultar bono.</param>
        /// <param name="canjeables">Indica si se consulta todos los bonos o solo los canjeables.</param>
        /// <param name="rowBase">Registro base para la consulta.</param>
        /// <param name="rowMax">Registros maximos a recuperar.</param>
        /// <returns></returns>
        public DataTable Bonos(string cliente, bool canjeables, int rowBase, int rowMax)
        {
            var tabla = new DataTable();
            try
            {
                if (canjeables)
                {
                    CargarAdapter("bonos_con_canje");
                }
                else
                {
                    CargarAdapter("bonos");
                }
                miAdapter.SelectCommand.Parameters.AddWithValue("cliente", cliente);
                miAdapter.Fill(rowBase, rowMax, tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los bonos.\n" + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene el total de registros del resultado de la consulta de Bono.
        /// </summary>
        /// <param name="cliente">Cliente a consultar bono.</param>
        /// <param name="canjeables">Indica si se consulta todos los bonos o solo los canjeables.</param>
        /// <returns></returns>
        public long GetRowsBonos(string cliente, bool canjeables)
        {
            try
            {
                if (canjeables)
                {
                    CargarComando("count_bonos_con_canje");
                }
                else
                {
                    CargarComando("count_bonos");
                }
                miComando.Parameters.AddWithValue("cliente", cliente);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar el total de registros de la consulta.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable Bonos(int idCaja, DateTime fecha)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapter("bonos_de_cliente");
                miAdapter.SelectCommand.Parameters.AddWithValue("caja", idCaja);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los Bonos.\n" + ex.Message);
            }
        }

        public Bono NotaCredito(int id)
        {
            try
            {
                CargarComando("bonos");
                miComando.Parameters.AddWithValue("id", id);
                miConexion.MiConexion.Open();
                NpgsqlDataReader miReader = miComando.ExecuteReader();
                var bono = new Bono();
                while (miReader.Read())
                {
                    bono.Id = miReader.GetInt32(0);
                    bono.Cliente = miReader.GetString(1);
                    bono.Factura = miReader.GetString(2);
                    bono.Fecha = miReader.GetDateTime(3);
                    bono.Valor = miReader.GetInt32(4);
                    bono.Canje = miReader.GetBoolean(5);
                    bono.IdUsuario = miReader.GetInt32(6);
                    bono.IdCaja = miReader.GetInt32(7);
                    bono.Numero = miReader.GetString(8);
                    bono.Concepto = miReader.GetString(9);
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return bono;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al obtener el saldo de los Bonos.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Obtiene el total del saldo de Bonos de un Cliente.
        /// </summary>
        /// <param name="cliente">Cliente a consultar saldo.</param>
        /// <returns></returns>
        public long SaldoEnBonos(string cliente)
        {
            long total = 0;
            long sTotal = 0;
            try
            {
                var bonos = Bonos(cliente);
                foreach (DataRow row in bonos.Rows)
                {
                    var totalS = TotalSeguimiento(Convert.ToInt32(row["idbono"]));
                    total = Convert.ToInt32(row["valorbono"]) - totalS;
                    sTotal += total;
                }
                return sTotal;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al obtener el saldo de los Bonos.\n" + ex.Message);
            }
        }

        /// <summary>
        /// Edita el Bono de manera que este pasa a estar canjeado.
        /// </summary>
        /// <param name="idBono">Id del Bono editar o canjear.</param>
        public void CanjeBono(int idBono)
        {
            try
            {
                CargarComando("canje_bono");
                miComando.Parameters.AddWithValue("id", idBono);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al realizar el canje del Bono.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        //SEGUIMIENTO BONO

        /// <summary>
        /// Ingresa los datos de Seguimiento de Bono en la base de datos.
        /// </summary>
        /// <param name="bono">Datos del Seguimiento de Bono a ingresar.</param>
        public void IngresarSeguimiento(Bono bono, string noFactura)
        {
            try
            {
                CargarComando(IngresarSeguimiento_);
                miComando.Parameters.AddWithValue("idbono", bono.Id);
                miComando.Parameters.AddWithValue("fecha", bono.Fecha);
                miComando.Parameters.AddWithValue("valor", bono.Valor);
                miComando.Parameters.AddWithValue("usuario", bono.IdUsuario);
                miComando.Parameters.AddWithValue("caja", bono.IdCaja);
                miConexion.MiConexion.Open();
                var id = Convert.ToInt32(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();

                CargarComando("insertar_seguimiento_bono_factura");
                miComando.Parameters.AddWithValue("id_seguimiento", id);
                miComando.Parameters.AddWithValue("factura", noFactura);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorIngSeguimiento + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Ingresa los datos de Seguimiento de Bono teniendo empezando por el bono con menor saldo.
        /// </summary>
        /// <param name="cliente">Cliente al cual pertenece el bono.</param>
        /// <param name="valor">Valor del seguimiento del bono.</param>
        public void IngresarSeguimiento
            (string cliente, int valor, int idCaja, int idUser, string noFactura)
        {
            var vSeguim = valor;
            try
            {
                var bonos = Bonos(cliente);
                foreach (DataRow row in bonos.Rows)
                {
                    var totalS = TotalSeguimiento(Convert.ToInt32(row["idbono"]));
                    var total = Convert.ToInt32(row["valorbono"]) - totalS;
                    if (total > 0)
                    {
                        var bono = new Bono();
                        bono.Id = Convert.ToInt32(row["idbono"]);
                        bono.IdCaja = idCaja;
                        bono.IdUsuario = idUser;
                        bono.Fecha = DateTime.Now;
                        if (vSeguim >= total)
                        {
                            bono.Valor = Convert.ToInt32(total);
                            bono.Canje = true;
                            vSeguim = vSeguim - Convert.ToInt32(total);
                        }
                        else
                        {
                            bono.Valor = /*Convert.ToInt32(total) -*/ vSeguim;
                            bono.Canje = false;
                            vSeguim = 0;
                        }
                        if (!noFactura.Equals(""))
                        {
                            IngresarSeguimiento(bono, noFactura);
                        }
                        if (bono.Canje)
                        {
                            CanjeBono(bono.Id);
                        }
                        if (vSeguim.Equals(0))
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorIngSeguimiento + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene el resultado de la consulta de los canjes hechos a un bono.
        /// </summary>
        /// <param name="bono">Id del Bono a consultar.</param>
        /// <returns></returns>
        public DataTable Seguimientos(int bono)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapter("seguimiento_bonos");
                miAdapter.SelectCommand.Parameters.AddWithValue("idbono", bono);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar las transacciones del Bono.\n" + ex.Message);
            }
        }

        public DataSet Seguimientos(int idCaja, DateTime fecha, bool caja)
        {
            var dataSet = new DataSet();
            try
            {
                if (caja)
                {
                    CargarAdapter("seguimiento_bonos");
                    miAdapter.SelectCommand.Parameters.AddWithValue("caja", idCaja);
                    miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                }
                else
                {
                    CargarAdapter("seguimiento_bonos_fecha");
                    miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                }
                miAdapter.Fill(dataSet, "Bono");
                return dataSet;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar los canjes de Bono.\n" + ex.Message);
            }
        }

        public DataTable SeguimientosDeBonoCliente(int idCaja, DateTime fecha)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapter("seguimientos_de_bono_cliente");
                miAdapter.SelectCommand.Parameters.AddWithValue("caja", idCaja);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar los Bonos de Cliente.\n" + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene el total de la suma de los seguimientos hechos a un Bono.
        /// </summary>
        /// <param name="idBono">Id del Bono a consultar.</param>
        /// <returns></returns>
        public long TotalSeguimiento(int idBono)
        {
            try
            {
                CargarComando("total_seguimiento_bono");
                miComando.Parameters.AddWithValue("idBono", idBono);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al obtener el total del seguimiento del Bono.\n" + ex.Message);
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