using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Npgsql;
using DTO.Clases;
using Utilities;

namespace DataAccessLayer.Clases
{
    public class DaoSaldo
    {
        /// <summary>
        /// Representa una conexion al servidor de Base de Datos PostgreSQL.
        /// </summary>
        private Conexion miConexion;

        /// <summary>
        /// Representa un Comando o StoredProcedure en SQL para ser ejecutado en PostgreSQL.
        /// </summary>
        private NpgsqlCommand miComando;

        /// <summary>
        /// Representa un DataAdapter de multiples comandos: select, insert, update, delete
        /// </summary>
        private NpgsqlDataAdapter miAdapter;

        /// <summary>
        /// Inicializa una nueva instancia de la clase DaoSaldo.
        /// </summary>
        public DaoSaldo()
        {
            this.miConexion = new Conexion();
        }


        // Saldo

        /// <summary>
        /// Ingresa un registro de Saldo en la Base de datos.
        /// </summary>
        /// <param name="saldo">Saldo a ingresar.</param>
        public long IngresarSaldo(Saldo saldo)
        {
            var daoIngreso = new DaoIngreso();
            var daoConsecutivo = new DaoConsecutivo();
            try
            {
                var tabla = UltimoSaldo(saldo.NitCliente);
                if (tabla.Rows.Count != 0)
                {
                    var query = (from data in tabla.AsEnumerable()
                                 select data).Single();
                    saldo.VSaldo = Convert.ToInt32(query["saldo"]) + saldo.Valor;
                }
                else
                {
                    saldo.VSaldo = saldo.Valor;
                }
                CargarComando("insertar_saldo_cliente");
                miComando.Parameters.AddWithValue("cliente", saldo.NitCliente);
                miComando.Parameters.AddWithValue("usuario", saldo.IdUsuario);
                miComando.Parameters.AddWithValue("caja", saldo.IdCaja);
                miComando.Parameters.AddWithValue("fecha", saldo.Fecha);
                miComando.Parameters.AddWithValue("hora", saldo.Fecha.TimeOfDay);
                miComando.Parameters.AddWithValue("valor", saldo.Valor);
                miComando.Parameters.AddWithValue("saldo", saldo.VSaldo);
                miComando.Parameters.AddWithValue("estado", saldo.Estado);
                miComando.Parameters.AddWithValue("numero", saldo.Ingreso.Numero);
                miConexion.MiConexion.Open();
                var id = Convert.ToInt32(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                daoConsecutivo.ActualizarConsecutivo("Anticipo");
                saldo.Ingreso.Relacion = id;
                long n = daoIngreso.IngresarRecibo(saldo.Ingreso);
                foreach (FormaPago pago in saldo.FormasPago)
                {
                    if (pago.Valor != 0)
                    {
                        CargarComando("insertar_saldo_cliente_forma_pago");
                        miComando.Parameters.AddWithValue("id", id);
                        miComando.Parameters.AddWithValue("idPago", pago.IdFormaPago);
                        miComando.Parameters.AddWithValue("valor", pago.Valor);
                        miConexion.MiConexion.Open();
                        miComando.ExecuteNonQuery();
                        miConexion.MiConexion.Close();
                        miComando.Dispose();
                    }
                }
                daoIngreso.IngresarAcumulado(saldo.IdCaja, saldo.Fecha, saldo.Ingreso.Valor);
                return n;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al ingresar el Saldo del cliente.\n" + ex.Message + "\n");
            }
            finally { miConexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Obtiene el resultado de la consulta de los saldos del cliente.
        /// </summary>
        /// <param name="nit">Nit del Cliente a consultar.</param>
        /// <param name="rowBase">Registro base para la consulta.</param>
        /// <param name="rowMax">Cantidad de registros máximos a recuperar.</param>
        /// <returns></returns>
        public DataTable SaldosCliente(string nit, int rowBase, int rowMax)
        {
            var tabla = new DataTable();
            var miTabla = TablaDeDatos();
            try
            {
                CargarDataAdapter("saldos_cliente");
                miAdapter.SelectCommand.Parameters.AddWithValue("nit", nit);
                miAdapter.Fill(rowBase, rowMax, tabla);
                foreach (DataRow row in tabla.Rows)
                {
                    var row_ = miTabla.NewRow();
                    row_["id"] = row["id"];
                    row_["nitcliente"] = row["nitcliente"];
                    row_["idusuario"] = row["idusuario"];
                    row_["idcaja"] = row["idcaja"];
                    row_["fecha"] = UseDate.UnionFechaYHora(Convert.ToDateTime(row["fecha"]), Convert.ToDateTime(row["hora"]));
                    row_["valor"] = row["valor"];
                    row_["saldo"] = row["saldo"];
                    row_["estado"] = row["estado"];
                    miTabla.Rows.Add(row_);
                }
                tabla.Rows.Clear();
                tabla.Columns.Clear();
                tabla = null;
                return miTabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los saldos del Cliente.\n" + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene el total de registros de la consulta de los saldos del cliente.
        /// </summary>
        /// <param name="nit">Nit del Cliente a consultar.</param>
        /// <returns></returns>
        public long GetRowsSaldosCliente(string nit)
        {
            try
            {
                CargarComando("count_saldos_cliente");
                miComando.Parameters.AddWithValue("nit", nit);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception
                    ("Ocurrió un error al cargar el total de registros de los adelantos.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataSet SaldosDelDia(int idCaja, DateTime fecha)
        {
            var tabla = new DataSet();
            try
            {
                CargarDataAdapter("print_anticipos");
                miAdapter.SelectCommand.Parameters.AddWithValue("caja", idCaja);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.Fill(tabla, "Anticipo");
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Saldo Saldo(int id)
        {
            try
            {
                CargarComando("saldos_cliente");
                miComando.Parameters.AddWithValue("id", id);
                miConexion.MiConexion.Open();
                NpgsqlDataReader miReader = miComando.ExecuteReader();
                var saldo = new Saldo();
                while (miReader.Read())
                {
                    saldo.Id = miReader.GetInt32(0);
                    saldo.NitCliente = miReader.GetString(1);
                    saldo.IdUsuario = miReader.GetInt32(2);
                    saldo.IdCaja = miReader.GetInt32(3);
                    saldo.Fecha = UseDate.UnionFechaYHora(miReader.GetDateTime(4), miReader.GetDateTime(5));
                    saldo.Valor = miReader.GetInt32(6);
                    saldo.VSaldo = miReader.GetInt32(7);
                    saldo.Estado = miReader.GetBoolean(8);
                    saldo.Numero = miReader.GetString(9);
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                saldo.FormasPago = PagosDeSaldo(id);
                return saldo;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el anticipo.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public List<Saldo> Saldos(string nit)
        {
            try
            {
                var lst = new List<Saldo>();
                CargarComando("anticipos_cliente_nit_saldo");
                miComando.Parameters.AddWithValue("", nit);
                miConexion.MiConexion.Open();
                NpgsqlDataReader reader = miComando.ExecuteReader();
                while (reader.Read())
                {
                    var saldo = new Saldo();
                    saldo.Id = reader.GetInt32(0);
                    saldo.NitCliente = reader.GetString(1);
                    saldo.IdUsuario = reader.GetInt32(3);
                    saldo.IdCaja = reader.GetInt32(4);
                    saldo.Fecha = UseDate.UnionFechaYHora(reader.GetDateTime(5), reader.GetDateTime(6));
                    saldo.Valor = reader.GetInt32(7);
                    saldo.Estado = reader.GetBoolean(9);
                    saldo.Numero = reader.GetString(10);
                    saldo.VSaldo = Convert.ToInt32(reader.GetInt64(12));
                    lst.Add(saldo);
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return lst;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al listar los anticipos del cliente.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }


        /// <summary>
        /// Obtiene el ultimo registro del saldo de un cliente.
        /// </summary>
        /// <param name="nit">Nit del cliente a consultar.</param>
        /// <returns></returns>
        public DataTable UltimoSaldo(string nit)
        {
            var tabla = new DataTable();
            try
            {
                CargarDataAdapter("ultimo_saldo_cliente");
                miAdapter.SelectCommand.Parameters.AddWithValue("nit", nit);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void EditarUltimoSaldo(int id, int valor)
        {
            try
            {
                CargarComando("editar_solo_saldo_cliente");
                miComando.Parameters.AddWithValue("id", id);
                miComando.Parameters.AddWithValue("valor", valor);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public List<FormaPago> PagosDeSaldo(int id)
        {
            try
            {
                CargarComando("pagos_saldos_cliente");
                miComando.Parameters.AddWithValue("id", id);
                miConexion.MiConexion.Open();
                NpgsqlDataReader miReader = miComando.ExecuteReader();
                List<FormaPago> pagos = new List<FormaPago>();
                while (miReader.Read())
                {
                    var pago = new FormaPago();
                    pago.IdEgreso = miReader.GetInt32(1);
                    pago.IdFormaPago = miReader.GetInt32(2);
                    pago.NombreFormaPago = miReader.GetString(3);
                    pago.Valor = miReader.GetInt32(4);
                    pagos.Add(pago);
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return pagos;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los pagos del anticipo.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Obtiene una estructura de la tabla Saldo_Cliente en memoria.
        /// </summary>
        /// <returns></returns>
        private DataTable TablaDeDatos()
        {
            var tabla = new DataTable();
            tabla.Columns.Add(new DataColumn("id", typeof(int)));
            tabla.Columns.Add(new DataColumn("nitcliente", typeof(string)));
            tabla.Columns.Add(new DataColumn("idusuario", typeof(int)));
            tabla.Columns.Add(new DataColumn("idcaja", typeof(int)));
            tabla.Columns.Add(new DataColumn("fecha", typeof(DateTime)));
            //tabla.Columns.Add(new DataColumn("", typeof(time)));
            tabla.Columns.Add(new DataColumn("valor", typeof(int)));
            tabla.Columns.Add(new DataColumn("saldo", typeof(int)));
            tabla.Columns.Add(new DataColumn("estado", typeof(bool)));

            tabla.Columns.Add(new DataColumn("concepto", typeof(string)));
            return tabla;
        }

        // END SALDO

        // Canje Saldo

        public int IngresarCanje(Canje canje)
        {
            try
            {
                CargarComando("insertar_canje_saldo_cliente");
                miComando.Parameters.AddWithValue("cliente", canje.NitCliente);
                miComando.Parameters.AddWithValue("usuario", canje.IdUsuario);
                miComando.Parameters.AddWithValue("caja", canje.IdCaja);
                miComando.Parameters.AddWithValue("fecha", canje.Fecha);
                miComando.Parameters.AddWithValue("hora", canje.Fecha.TimeOfDay);
                miComando.Parameters.AddWithValue("concepto", canje.Concepto);
                miComando.Parameters.AddWithValue("valor", canje.Valor);
                miComando.Parameters.AddWithValue("retiro", canje.Estado);
                miComando.Parameters.AddWithValue("saldo", canje.VSaldo);
                miComando.Parameters.AddWithValue("idsaldo", canje.IdSaldo);
                miConexion.MiConexion.Open();
                int id = Convert.ToInt32(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                var saldo = UltimoSaldo(canje.NitCliente);
                if (saldo.Rows.Count != 0)
                {
                    var query = (from data in saldo.AsEnumerable()
                                 select data).Single();
                    EditarUltimoSaldo(Convert.ToInt32(query["id"]),
                                      Convert.ToInt32(query["saldo"]) - canje.Valor);
                    //= Convert.ToInt32(query["saldo"]) + saldo.Valor;
                }
                return id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public List<Canje> IngresarCanje(Canje canje, int valor)
        {
            try
            {
                var canjes = new List<Canje>();
                foreach (var anticipo in Saldos(canje.NitCliente))
                {
                    if (valor > 0)
                    {
                        canje.IdSaldo = anticipo.Id;
                        if (valor > anticipo.VSaldo)
                        {
                            canje.Valor = anticipo.VSaldo;
                            //canje.VSaldo = 0;
                            canje.VSaldo = Saldos(canje.NitCliente).Sum(s => s.VSaldo);
                            valor -= canje.Valor;
                        }
                        else
                        {
                            canje.Valor = valor;
                            //canje.VSaldo = anticipo.VSaldo - valor;
                            canje.VSaldo = Saldos(canje.NitCliente).Sum(s => s.VSaldo);
                            valor = 0;
                        }
                        canje.Id = IngresarCanje(canje);
                        canjes.Add(canje);
                    }
                    else
                    {
                        break;
                    }
                }
                return canjes;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al ingresar el retiro de anticipo.\n" + ex.Message + "\n");
            }
            finally { miConexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Obtiene el resultado de la consulta de las transacciones del cliente.
        /// </summary>
        /// <param name="nit">Nit del Cliente a consultar.</param>
        /// <param name="rowBase">Registro base para la consulta.</param>
        /// <param name="rowMax">Cantidad de registros máximos a recuperar.</param>
        /// <returns></returns>
        public DataTable CanjesCliente(string nit, int rowBase, int rowMax)
        {
            var tabla = new DataTable();
            //var miTabla = TablaDeDatos();
            try
            {
                CargarDataAdapter("canjes_saldo_cliente");
                miAdapter.SelectCommand.Parameters.AddWithValue("nit", nit);
                miAdapter.Fill(rowBase, rowMax, tabla);
                return tabla;
               /* foreach (DataRow row in tabla.Rows)
                {
                    var row_ = miTabla.NewRow();
                    row_["id"] = row["id"];
                    row_["nitcliente"] = row["nitcliente"];
                    row_["idusuario"] = row["idusuario"];
                    row_["idcaja"] = row["idcaja"];
                    row_["fecha"] = UseDate.UnionFechaYHora(Convert.ToDateTime(row["fecha"]), Convert.ToDateTime(row["hora"]));
                    row_["concepto"] = row["concepto"];
                    row_["valor"] = row["valor"];
                    miTabla.Rows.Add(row_);
                }
                tabla.Rows.Clear();
                tabla.Columns.Clear();
                tabla = null;
                return miTabla;*/
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar las Transacciones del Cliente.\n" + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene el total de registros de la consulta de las transacciones del cliente.
        /// </summary>
        /// <param name="nit">Nit del Cliente a consultar.</param>
        /// <returns></returns>
        public long GetRowsCanjesCliente(string nit)
        {
            try
            {
                CargarComando("count_canjes_saldo_cliente");
                miComando.Parameters.AddWithValue("nit", nit);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception
                    ("Ocurrió un error al cargar el total de registros de las transacciones.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable CanjesCliente(int idCaja, DateTime fecha)
        {
            var tabla = new DataTable();
            tabla.TableName = "CruceAnticipos";
            try
            {
                CargarDataAdapter("canjes_anticipos");
                miAdapter.SelectCommand.Parameters.AddWithValue("caja", idCaja);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los cruces con Anticipos.\n" + ex.Message);
            }
        }

        public DataSet Canjes(int idCaja, DateTime fecha, bool caja)
        {
            var dataSet = new DataSet();
            try
            {
                CargarDataAdapter("canjes_cliente");
                if (caja)
                {
                    miAdapter.SelectCommand.Parameters.AddWithValue("caja", idCaja);
                }
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.Fill(dataSet, "Canje");
                return dataSet;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar el cruce de anticipos.\n" + ex.Message);
            }
        }

        public DataTable Canjes(int idAnticipo)
        {
            try
            {
                var tabla = new DataTable();
                CargarDataAdapter("canjes_saldo_cliente");
                miAdapter.SelectCommand.Parameters.AddWithValue("", idAnticipo);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los retiros del anticipo.\n" + ex.Message);
            }
        }

        public Canje Canje(int id)
        {
            try
            {
                var canje = new Canje();
                CargarComando("canje_cliente");
                miComando.Parameters.AddWithValue("", id);
                miConexion.MiConexion.Open();
                NpgsqlDataReader reader = miComando.ExecuteReader();
                while(reader.Read())
                {
                    canje.Id = reader.GetInt32(0);
                    canje.NitCliente = reader.GetString(1);
                    canje.IdUsuario = reader.GetInt32(2);
                    canje.IdCaja = reader.GetInt32(3);
                    canje.Fecha = UseDate.UnionFechaYHora(reader.GetDateTime(4), reader.GetDateTime(5));
                    canje.Concepto = reader.GetString(6);
                    canje.Valor = reader.GetInt32(7);
                    canje.VSaldo = reader.GetInt32(9);
                    canje.IdSaldo = reader.GetInt32(10);
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return canje;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el retiro de anticipo.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        // END CANJE SALDO

        public DataTable Anticipos(int rowIndex, int rowMax)
        {
            try
            {
                var tabla = new DataTable();
                CargarDataAdapter("anticipos_cliente");
                miAdapter.Fill(rowIndex, rowMax, tabla);
                return tabla;
            }
            catch(Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los anticipos.\n" + ex.Message);
            }
        }

        public int GetRowsAnticipos()
        {
            try
            {
                CargarComando("count_anticipos_cliente");
                miConexion.MiConexion.Open();
                int total = Convert.ToInt32(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return total;
            }
            catch (InvalidCastException)
            {
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar el conteo de registros.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable Anticipos(DateTime fecha, int rowIndex, int rowMax)
        {
            try
            {
                var tabla = new DataTable();
                CargarDataAdapter("anticipos_cliente");
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha);
                miAdapter.Fill(rowIndex, rowMax, tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los anticipos.\n" + ex.Message);
            }
        }

        public int GetRowsAnticipos(DateTime fecha)
        {
            try
            {
                CargarComando("count_anticipos_cliente");
                miComando.Parameters.AddWithValue("", fecha);
                miConexion.MiConexion.Open();
                int total = Convert.ToInt32(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return total;
            }
            catch (InvalidCastException)
            {
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar el conteo de registros.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable Anticipos(DateTime fecha, DateTime fecha2, int rowIndex, int rowMax)
        {
            try
            {
                var tabla = new DataTable();
                CargarDataAdapter("anticipos_cliente");
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha2);
                miAdapter.Fill(rowIndex, rowMax, tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los anticipos.\n" + ex.Message);
            }
        }

        public int GetRowsAnticipos(DateTime fecha, DateTime fecha2)
        {
            try
            {
                CargarComando("count_anticipos_cliente");
                miComando.Parameters.AddWithValue("", fecha);
                miComando.Parameters.AddWithValue("", fecha2);
                miConexion.MiConexion.Open();
                int total = Convert.ToInt32(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return total;
            }
            catch (InvalidCastException)
            {
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar el conteo de registros.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable Anticipos(string nit, DateTime fecha, int rowIndex, int rowMax)
        {
            try
            {
                var tabla = new DataTable();
                CargarDataAdapter("anticipos_cliente_nit");
                miAdapter.SelectCommand.Parameters.AddWithValue("", nit);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha);
                miAdapter.Fill(rowIndex, rowMax, tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los anticipos.\n" + ex.Message);
            }
        }

        public int GetRowsAnticipos(string nit, DateTime fecha)
        {
            try
            {
                CargarComando("count_anticipos_cliente_nit");
                miComando.Parameters.AddWithValue("", nit);
                miComando.Parameters.AddWithValue("", fecha);
                miConexion.MiConexion.Open();
                int total = Convert.ToInt32(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return total;
            }
            catch (InvalidCastException)
            {
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar el conteo de registros.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable Anticipos(string nit, DateTime fecha, DateTime fecha2, int rowIndex, int rowMax)
        {
            try
            {
                var tabla = new DataTable();
                CargarDataAdapter("anticipos_cliente");
                miAdapter.SelectCommand.Parameters.AddWithValue("", nit);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha2);
                miAdapter.Fill(rowIndex, rowMax, tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los anticipos.\n" + ex.Message);
            }
        }

        public int GetRowsAnticipos(string nit, DateTime fecha, DateTime fecha2)
        {
            try
            {
                CargarComando("count_anticipos_cliente");
                miComando.Parameters.AddWithValue("", nit);
                miComando.Parameters.AddWithValue("", fecha);
                miComando.Parameters.AddWithValue("", fecha2);
                miConexion.MiConexion.Open();
                int total = Convert.ToInt32(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return total;
            }
            catch (InvalidCastException)
            {
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar el conteo de registros.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable AnticiposSaldo(int rowIndex, int rowMax)
        {
            try
            {
                var tabla = new DataTable();
                CargarDataAdapter("anticipos_cliente_saldo");
                miAdapter.Fill(rowIndex, rowMax, tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los anticipos.\n" + ex.Message);
            }
        }

        public int GetRowsAnticiposSaldo()
        {
            try
            {
                CargarComando("count_anticipos_cliente_saldo");
                miConexion.MiConexion.Open();
                int total = Convert.ToInt32(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return total;
            }
            catch (InvalidCastException)
            {
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar el conteo de registros.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable AnticiposSaldo()
        {
            try
            {
                var tabla = new DataTable();
                CargarDataAdapter("anticipos_cliente_saldo");
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los anticipos.\n" + ex.Message);
            }
        }

        public DataTable AnticiposSaldo(DateTime fecha)
        {
            try
            {
                var tabla = new DataTable();
                CargarDataAdapter("anticipos_cliente_saldo");
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los anticipos.\n" + ex.Message);
            }
        }

        public DataTable AnticiposSaldo(DateTime fecha, DateTime fecha2)
        {
            try
            {
                var tabla = new DataTable();
                CargarDataAdapter("anticipos_cliente_saldo");
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha2);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los anticipos.\n" + ex.Message);
            }
        }

        public DataTable AnticiposSaldo(string nit, DateTime fecha)
        {
            try
            {
                var tabla = new DataTable();
                CargarDataAdapter("anticipos_cliente_nit_saldo");
                miAdapter.SelectCommand.Parameters.AddWithValue("", nit);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los anticipos.\n" + ex.Message);
            }
        }

        public DataTable AnticiposSaldo(string nit, DateTime fecha, DateTime fecha2)
        {
            try
            {
                var tabla = new DataTable();
                CargarDataAdapter("anticipos_cliente_saldo");
                miAdapter.SelectCommand.Parameters.AddWithValue("", nit);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("", fecha2);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los anticipos.\n" + ex.Message);
            }
        }
        
        public int TotalAnticiposSaldo()
        {
            try
            {
                CargarComando("total_anticipos_cliente_saldo");
                miConexion.MiConexion.Open();
                int total = Convert.ToInt32(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return total;
            }
            catch (InvalidCastException)
            {
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el saldo de los anticipos.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public int TotalAnticiposSaldo(DateTime fecha)
        {
            try
            {
                CargarComando("total_anticipos_cliente_saldo");
                miComando.Parameters.AddWithValue("", fecha);
                miConexion.MiConexion.Open();
                int total = Convert.ToInt32(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return total;
            }
            catch (InvalidCastException)
            {
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el saldo de los anticipos.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public int TotalAnticiposSaldo(DateTime fecha, DateTime fecha2)
        {
            try
            {
                CargarComando("total_anticipos_cliente_saldo");
                miComando.Parameters.AddWithValue("", fecha);
                miComando.Parameters.AddWithValue("", fecha2);
                miConexion.MiConexion.Open();
                int total = Convert.ToInt32(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return total;
            }
            catch (InvalidCastException)
            {
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el saldo de los anticipos.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public int TotalAnticiposSaldo(string nit, DateTime fecha)
        {
            try
            {
                CargarComando("total_anticipos_cliente_nit_saldo");
                miComando.Parameters.AddWithValue("", nit);
                miComando.Parameters.AddWithValue("", fecha);
                miConexion.MiConexion.Open();
                int total = Convert.ToInt32(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return total;
            }
            catch (InvalidCastException)
            {
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el saldo de los anticipos.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public int TotalAnticiposSaldo(string nit, DateTime fecha, DateTime fecha2)
        {
            try
            {
                CargarComando("total_anticipos_cliente_saldo");
                miComando.Parameters.AddWithValue("", nit);
                miComando.Parameters.AddWithValue("", fecha);
                miComando.Parameters.AddWithValue("", fecha2);
                miConexion.MiConexion.Open();
                int total = Convert.ToInt32(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return total;
            }
            catch (InvalidCastException)
            {
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el saldo de los anticipos.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }


        public void AnularSaldo(int id)
        {
            try
            {
                CargarComando("anular_saldo_cliente");
                miComando.Parameters.AddWithValue("" , id);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al anular el anticipo del cliente.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }




        /*public DataTable Anticipos(int rowIndex, int rowMax)
        {
            try
            {
                var tabla = new DataTable();
                CargarDataAdapter("anticipos_cliente");
                miAdapter.Fill(rowIndex, rowMax, tabla);
                return tabla;
            }
            catch(Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los anticipos.\n" + ex.Message);
            }
        }

        public int GetRowsAnticipos()
        {
            try
            {
                CargarComando("");
                miConexion.MiConexion.Open();
                int total = Convert.ToInt32(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return total;
            }
            catch (InvalidCastException)
            {
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar el conteo de registros.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }*/

        /// <summary>
        /// Inicializa una nueva instancia del comando, tipo Stored Procedure
        /// </summary>
        /// <param name="cmd">Stored Procedure a ejecutar</param>
        private void CargarComando(string cmd)
        {
            miComando = new NpgsqlCommand();
            miComando.Connection = miConexion.MiConexion;
            miComando.CommandType = CommandType.StoredProcedure;
            miComando.CommandText = cmd;
        }

        /// <summary>
        /// Inicializa una nueva instancia del DataAdapter, tipo Stored Procedure
        /// </summary>
        /// <param name="cmd">Stored Procedure a ejecutar</param>
        private void CargarDataAdapter(string cmd)
        {
            this.miAdapter = new NpgsqlDataAdapter(cmd, this.miConexion.MiConexion);
            this.miAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        }
    }
}