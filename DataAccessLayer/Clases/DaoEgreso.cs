using System;
using System.Linq;
using System.Data;
using DTO.Clases;
using Npgsql;
using System.Collections.Generic;

namespace DataAccessLayer.Clases
{
    /// <summary>
    /// Representa una clase de transacciones a Base de Datos de Egreso.
    /// </summary>
    public class DaoEgreso
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

        /// <summary>
        /// Representa la función: insertar_egreso.
        /// </summary>
        private string Ingresar = "insertar_egreso";

        /// <summary>
        /// Representa el texto: Ocurrió un error al ingresar el Egreso.
        /// </summary>
        private string ErrorIngresar = "Ocurrió un error al ingresar el Egreso.\n";

        //Retiro

        /// <summary>
        /// Representa la función: insertar_retiro.
        /// </summary>
        //private string IngresarRetiro_ = "insertar_retiro";



        /// <summary>
        /// Representa el texto: Ocurrió un error al ingresar el Retiro.
        /// </summary>
        private string ErrorIngRetiro = "Ocurrió un error al ingresar el Retiro.\n";

        //Arqueo

        /// <summary>
        /// Representa la función: insertar_arqueo.
        /// </summary>
        private string IngresarArqueo_ = "insertar_arqueo";


        /// <summary>
        /// Representa el texto: Ocurrió un error al ingresar el Arqueo.
        /// </summary>
        private string ErrorIngArqueo = "Ocurrió un error al ingresar el Arqueo.\n";

        /// <summary>
        /// Inicializa una nueva instancia de la clase DaoEgreso.
        /// </summary>
        public DaoEgreso()
        {
            this.miConexion = new Conexion();
        }

        //Egreso
        //ojo editar
        public bool ValidarCuenta(int subCuenta, int cuenta)
        {
            try
            {
                CargarComando("validar_cuenta_puc");
                miComando.Parameters.AddWithValue("sCuenta", subCuenta);
                miComando.Parameters.AddWithValue("cuenta", cuenta);
                miConexion.MiConexion.Open();
                var valida = Convert.ToBoolean(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                return valida;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al validar la Cuenta.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public bool ValidarCuenta(string subCuenta)
        {
            try
            {
                CargarComando("validar_cuenta_puc");
                miComando.Parameters.AddWithValue("sCuenta", subCuenta);
                miConexion.MiConexion.Open();
                var valida = Convert.ToBoolean(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                return valida;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al validar la Cuenta.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Ingresa el registro de un Egreso a la Base de Datos.
        /// </summary>
        /// <param name="egreso">Egreso a ingresar.</param>
        public int IngresarEgreso(Egreso egreso)
        {
            var daoCuentaPuc = new DaoCuentaPuc();
            var daoFormaPago = new DaoFormaPago();
            var daoConsecutivo = new DaoConsecutivo();
            try
            {
                CargarComando(Ingresar);
                miComando.Parameters.AddWithValue("caja", egreso.IdCaja);
                miComando.Parameters.AddWithValue("user", egreso.IdUsuario);
                miComando.Parameters.AddWithValue("numero", egreso.Numero);
                miComando.Parameters.AddWithValue("fecha", egreso.Fecha);
                miComando.Parameters.AddWithValue("total", egreso.Total);
                miComando.Parameters.AddWithValue("tipo", egreso.TipoBeneficiario);
                miComando.Parameters.AddWithValue("beneficiario", egreso.Beneficiario);
                miComando.Parameters.AddWithValue("estado", egreso.Estado);
                miConexion.MiConexion.Open();
                var id = Convert.ToInt32(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                foreach (var cuenta in egreso.Cuentas)
                {
                    cuenta.Id = id;
                    daoCuentaPuc.IngresarEgresoCuenta(cuenta);
                }
                foreach (var pago in egreso.Pagos)
                {
                    if (pago.IdFormaPago != 0 && pago.Valor != 0)
                    {
                        pago.Caja.Id = id;
                        daoFormaPago.IngresarEgresoPago(pago);
                    }
                }
                daoConsecutivo.ActualizarConsecutivo("Egreso");
                return id;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorIngresar + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public void IngresarEgresoCompra(Egreso egreso)
        {
            try
            {
                CargarComando("insertar_egreso_compra");
                miComando.Parameters.AddWithValue("", egreso.TipoBeneficiario);
                miComando.Parameters.AddWithValue("", egreso.Id);
                miComando.Parameters.AddWithValue("", egreso.Numero);
                miComando.Parameters.AddWithValue("", egreso.Fecha);
                miComando.Parameters.AddWithValue("", egreso.Total);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al ingresar la relación con la compra.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable Listado(bool anulado, int rowBase, int rowMax)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdpter("egresos_basico_anulada");
                miAdapter.Fill(rowBase, rowMax, tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un errror al cargar los egresos.\n" + ex.Message);
            }
        }

        public long GetRowslistado(bool anulado)
        {
            try
            {
                if (anulado)
                {
                    CargarComando("count_egresos_basico_anulada");
                }
                else
                {
                    CargarComando("count_egresos_basico");
                }
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable Listado(string numero)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdpter("egresos_basico_no");
                miAdapter.SelectCommand.Parameters.AddWithValue("numero", numero);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un errror al cargar los egresos.\n" + ex.Message);
            }
        }

        public DataTable Listado(DateTime fecha, bool anulado, int rowBase, int rowMax)
        {
            var tabla = new DataTable();
            try
            {
                if (anulado)
                {
                    CargarAdpter("egresos_basico_fe_anulados");
                }
                else
                {
                    CargarAdpter("egresos_basico_fe");
                }
                miAdapter.SelectCommand.Parameters.AddWithValue("numero", fecha);
                miAdapter.Fill(rowBase, rowMax, tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un errror al cargar los egresos.\n" + ex.Message);
            }
        }

        public long GetRowslistado(DateTime fecha, bool anulado)
        {
            try
            {
                if (anulado)
                {
                    CargarComando("count_egresos_basico_fe_anulados");
                }
                else
                {
                    CargarComando("count_egresos_basico_fe");
                }
                miComando.Parameters.AddWithValue("fecha", fecha);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable Listado
            (DateTime fecha, DateTime fecha1, bool anulado, int rowBase, int rowMax)
        {
            var tabla = new DataTable();
            try
            {
                if (anulado)
                {
                    CargarAdpter("egresos_basico_fe_anulados");
                }
                else
                {
                    CargarAdpter("egresos_basico_fe");
                }
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha1", fecha1);
                miAdapter.Fill(rowBase, rowMax, tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un errror al cargar los egresos.\n" + ex.Message);
            }
        }

        public long GetRowslistado(DateTime fecha, DateTime fecha1, bool anulado)
        {
            try
            {
                if (anulado)
                {
                    CargarComando("count_egresos_basico_fe_anulados");
                }
                else
                {
                    CargarComando("count_egresos_basico_fe");
                }
                miComando.Parameters.AddWithValue("fecha", fecha);
                miComando.Parameters.AddWithValue("fecha1", fecha1);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable Listado(int idBeneficio, int rowBase, int rowMax)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdpter("egresos_basico_beneficio");
                miAdapter.SelectCommand.Parameters.AddWithValue("id", idBeneficio);
                miAdapter.Fill(rowBase, rowMax, tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un errror al cargar los egresos.\n" + ex.Message);
            }
        }

        public long GetRowslistado(int idBeneficio)
        {
            try
            {
                CargarComando("count_egresos_basico_beneficio");
                miComando.Parameters.AddWithValue("id", idBeneficio);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }
        //
        public DataTable Listado(int idBeneficio, DateTime fecha, int rowBase, int rowMax)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdpter("egresos_basico_beneficio");
                miAdapter.SelectCommand.Parameters.AddWithValue("id", idBeneficio);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.Fill(rowBase, rowMax, tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un errror al cargar los egresos.\n" + ex.Message);
            }
        }

        public long GetRowslistado(int idBeneficio, DateTime fecha)
        {
            try
            {
                CargarComando("count_egresos_basico_beneficio");
                miComando.Parameters.AddWithValue("id", idBeneficio);
                miComando.Parameters.AddWithValue("fecha", fecha);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable Listado
            (int idBeneficio, DateTime fecha, DateTime fecha2, int rowBase, int rowMax)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdpter("egresos_basico_beneficio");
                miAdapter.SelectCommand.Parameters.AddWithValue("id", idBeneficio);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha2", fecha2);
                miAdapter.Fill(rowBase, rowMax, tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un errror al cargar los egresos.\n" + ex.Message);
            }
        }

        public long GetRowslistado(int idBeneficio, DateTime fecha, DateTime fecha2)
        {
            try
            {
                CargarComando("count_egresos_basico_beneficio");
                miComando.Parameters.AddWithValue("id", idBeneficio);
                miComando.Parameters.AddWithValue("fecha", fecha);
                miComando.Parameters.AddWithValue("fecha2", fecha2);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }



        public DataTable Listado(string numero, DateTime fecha)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdpter("egresos_basico_1_no_fe");
                miAdapter.SelectCommand.Parameters.AddWithValue("numero", numero);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un errror al cargar los egresos.\n" + ex.Message);
            }
        }

       /* public DataSet Listado(DateTime fecha)
        {
            var tabla = new DataSet();
            try
            {
                CargarAdpter("listado_egreso_fecha");
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.Fill(tabla, "Egreso");
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un errror al cargar los egresos.\n" + ex.Message);
            }
        }*/

        public DataTable Listado(int idCaja, DateTime fecha)
        {
            var tabla = new DataTable();
            tabla.TableName = "Egreso";
            try
            {
                CargarAdpter("print_egresos_2");
                miAdapter.SelectCommand.Parameters.AddWithValue("caja", idCaja);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un errror al cargar los egresos.\n" + ex.Message);
            }
        }

        public DataTable Listado(DateTime fecha)
        {
            var tabla = new DataTable();
            tabla.TableName = "Egreso";
            try
            {
                CargarAdpter("print_egresos_2");
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un errror al cargar los egresos.\n" + ex.Message);
            }
        }

        public Egreso EgresoId(int id)
        {
            var daoCuenta = new DaoCuentaPuc();
            var daoPagos = new DaoFormaPago();
            try
            {
                CargarComando("egreso_id");
                miComando.Parameters.AddWithValue("id", id);
                miConexion.MiConexion.Open();
                NpgsqlDataReader reader = miComando.ExecuteReader();
                var egreso = new Egreso();
                while (reader.Read())
                {
                    egreso.Id = reader.GetInt32(0);
                    egreso.IdCaja = reader.GetInt32(1);
                    egreso.IdUsuario = reader.GetInt32(2);
                    egreso.Numero = reader.GetString(3);
                    egreso.Fecha = reader.GetDateTime(4);
                    egreso.Total = reader.GetInt32(5);
                    egreso.Estado = reader.GetBoolean(6);
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                egreso.Cuentas = daoCuenta.CuentasEgreso(id);
                egreso.Pagos = PagosEgreso(id);
                return egreso;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar los datos del Egreso.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public Egreso EgresoNumero(string numero)
        {
            try
            {
                CargarComando("egreso_numero");
                miComando.Parameters.AddWithValue("numero", numero);
                miConexion.MiConexion.Open();
                NpgsqlDataReader reader = miComando.ExecuteReader();
                var egreso = new Egreso();
                while (reader.Read())
                {
                    egreso.Id = reader.GetInt32(0);
                    egreso.IdCaja = reader.GetInt32(1);
                    egreso.IdUsuario = reader.GetInt32(2);
                    egreso.Numero = reader.GetString(3);
                    egreso.Fecha = reader.GetDateTime(4);
                    egreso.Total = reader.GetInt32(5);
                    egreso.TipoBeneficiario = reader.GetInt32(6);
                    egreso.Estado = reader.GetBoolean(8);
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return egreso;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar los datos del Egreso.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable EgresoPuc(int idEgreso)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdpter("egresos_puc");
                miAdapter.SelectCommand.Parameters.AddWithValue("idegreso", idEgreso);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar las Cuentas y Conceptos del Egreso.\n" + ex.Message);
            }
        }

        public DataTable EgresoPuc(int idEgreso, int idCuenta)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdpter("egresos_puc");
                miAdapter.SelectCommand.Parameters.AddWithValue("idegreso", idEgreso);
                miAdapter.SelectCommand.Parameters.AddWithValue("idcuenta", idCuenta);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar las Cuentas y Conceptos del Egreso.\n" + ex.Message);
            }
        }

        public List<FormaPago> PagosEgreso(int idEgreso)
        {
            var lst = new List<FormaPago>();
            try
            {
                CargarComando("egresos_pago");
                miComando.Parameters.AddWithValue("idegreso", idEgreso);
                miConexion.MiConexion.Open();
                NpgsqlDataReader reader = miComando.ExecuteReader();
                while (reader.Read())
                {
                    lst.Add(new FormaPago
                    {
                        IdEgreso = reader.GetInt32(1),
                        IdFormaPago = reader.GetInt32(2),
                        Valor = reader.GetInt32(3)
                    });
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los pagos del Egreso.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
            return lst;
        }

         public void EditarEgreso(Egreso egreso)
         {
             try
             {
                 CargarComando("editar_egreso");
                 miComando.Parameters.AddWithValue("id", egreso.Id);
                 miComando.Parameters.AddWithValue("fecha", egreso.Fecha);
                 miComando.Parameters.AddWithValue("tercero", egreso.TipoBeneficiario);
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

        public void AnularEgreso(int idEgreso)
        {
            try
            {
                CargarComando("anular_egreso");
                miComando.Parameters.AddWithValue("id", idEgreso);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al anular el Egreso.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public void EliminarEgreso(int id)
        {
            try
            {
                CargarComando("eliminar_egreso");
                miComando.Parameters.AddWithValue("id", id);
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

        // Metodos para Informe de Egresos.
        public DataTable Egresos(int idCuenta, string numero)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdpter("egresos_informe");
                miAdapter.SelectCommand.Parameters.AddWithValue("idcuenta", idCuenta);
                miAdapter.SelectCommand.Parameters.AddWithValue("numero", numero);
                miAdapter.Fill(tabla);
                return EstructuraConsulta(tabla);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los Egresos.\n" + ex.Message);
            }
        }

        public DataTable Egresos(int idCuenta, DateTime fecha)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdpter("egresos_informe_fecha");
                miAdapter.SelectCommand.Parameters.AddWithValue("idcuenta", idCuenta);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.Fill(tabla);
                return EstructuraConsulta(tabla);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los Egresos.\n" + ex.Message);
            }
        }

        public DataTable Egresos(int idCuenta, DateTime fecha, DateTime fecha2)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdpter("egresos_informe_periodo");
                miAdapter.SelectCommand.Parameters.AddWithValue("idcuenta", idCuenta);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha2", fecha2);
                miAdapter.Fill(tabla);
                return EstructuraConsulta(tabla);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los Egresos.\n" + ex.Message);
            }
        }

        public DataTable Egresos(int idCuenta, int idTercero)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdpter("egresos_informe");
                miAdapter.SelectCommand.Parameters.AddWithValue("idcuenta", idCuenta);
                miAdapter.SelectCommand.Parameters.AddWithValue("tercero", idTercero);
                miAdapter.Fill(tabla);
                return EstructuraConsulta(tabla);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los Egresos.\n" + ex.Message);
            }
        }

        public DataTable Egresos(int idCuenta, int idTercero, DateTime fecha)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdpter("egresos_informe");
                miAdapter.SelectCommand.Parameters.AddWithValue("idcuenta", idCuenta);
                miAdapter.SelectCommand.Parameters.AddWithValue("tercero", idTercero);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.Fill(tabla);
                return EstructuraConsulta(tabla);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los Egresos.\n" + ex.Message);
            }
        }

        public DataTable Egresos
            (int idCuenta, int idTercero, DateTime fecha, DateTime fecha2)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdpter("egresos_informe");
                miAdapter.SelectCommand.Parameters.AddWithValue("idcuenta", idCuenta);
                miAdapter.SelectCommand.Parameters.AddWithValue("tercero", idTercero);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha2", fecha2);
                miAdapter.Fill(tabla);
                return EstructuraConsulta(tabla);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los Egresos.\n" + ex.Message);
            }
        }

        private DataTable EstructuraConsulta(DataTable tabla)
        {
            var tEgresos = TablaEgresos();
            var idTmp = 0;
            var cont = 0;
            foreach (DataRow tRow in tabla.Rows)
            {
                var query = tabla.AsEnumerable().
                    Where(t => t.Field<int>("id").Equals(Convert.ToInt32(tRow["id"])));
                var total = 0;
                var max = 0;
                long rete = 0;
                if (Convert.ToBoolean(tRow["estado"]))
                {
                   // if (query.ToArray().Length > 1)
                    //{
                        total = query.Sum(s => s.Field<int>("valor"));
                        max = query.Max(m => m.Field<int>("idcuenta"));
                        rete = ValorRetencion(2, Convert.ToInt32(tRow["id"]));
                    //}
                }
                /*if (query.ToArray().Length > 1)
                {
                    id = 2;
                }*/
                var row = tEgresos.NewRow();
                var j = Convert.ToInt32(tRow["id"]);
                if (!Convert.ToInt32(tRow["id"]).Equals(idTmp))
                {
                    cont++;
                    //row["Id"] = 1;
                }
                /*else
                {
                    //row["Id"] = 2;
                }*/
                row["Id"] = cont;
                row["Numero"] = tRow["numero"];
                row["Fecha"] = tRow["fecha"];
                if (Convert.ToBoolean(tRow["estado"]))
                {
                    row["Estado"] = "Activo";
                }
                else
                {
                    row["Estado"] = "Anulado";
                }
                row["Nit"] = tRow["nit"];
                row["Tercero"] = tRow["nombre"];
                row["Concepto"] = tRow["concepto"];
                row["Valor"] = tRow["valor"];
                if (Convert.ToInt32(tRow["idcuenta"]).Equals(max))
                {
                    row["Consolidado"] = total;
                    row["VMenosRetencion"] = total + rete;
                }
                else
                {
                    if (query.ToArray().Length.Equals(1))
                    {
                        row["Consolidado"] = total;
                        row["VMenosRetencion"] = total + rete;
                    }
                }
                tEgresos.Rows.Add(row);
                idTmp = Convert.ToInt32(tRow["id"]);
            }
            return tEgresos;
        }

        public long ValorRetencion(int idCuenta, int idEgreso)
        {
            try
            {
                CargarComando("valor_retencion_egreso");
                miComando.Parameters.AddWithValue("idcuenta", idCuenta);
                miComando.Parameters.AddWithValue("idegreso", idEgreso);
                miConexion.MiConexion.Open();
                long id = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return id;
            }
            catch (InvalidCastException)
            {
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar la retención del Egreso.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        private DataTable TablaEgresos()
        {
            var tabla = new DataTable();
            tabla.Columns.Add(new DataColumn("Id", typeof(int)));
            tabla.Columns.Add(new DataColumn("Numero", typeof(string)));
            tabla.Columns.Add(new DataColumn("Fecha", typeof(DateTime)));
            tabla.Columns.Add(new DataColumn("Estado", typeof(string)));
            tabla.Columns.Add(new DataColumn("Nit", typeof(string)));
            tabla.Columns.Add(new DataColumn("Tercero", typeof(string)));
            tabla.Columns.Add(new DataColumn("Concepto", typeof(string)));
            tabla.Columns.Add(new DataColumn("Valor", typeof(int)));
            tabla.Columns.Add(new DataColumn("Consolidado", typeof(int)));
            tabla.Columns.Add(new DataColumn("VMenosRetencion", typeof(int)));
            return tabla;
        }

        // Egreso Remision de Proveedor

        public void IngresarEgresoRemision(Egreso egreso)
        {
            //var daoCuentaPuc = new DaoCuentaPuc();
            var daoFormaPago = new DaoFormaPago();
            var daoConsecutivo = new DaoConsecutivo();
            try
            {
                CargarComando("insertar_egreso_remision");
                miComando.Parameters.AddWithValue("caja", egreso.IdCaja);
                miComando.Parameters.AddWithValue("user", egreso.IdUsuario);
                miComando.Parameters.AddWithValue("numero", egreso.Numero);
                miComando.Parameters.AddWithValue("fecha", egreso.Fecha);
                miComando.Parameters.AddWithValue("total", egreso.Total);
                miComando.Parameters.AddWithValue("tipo", egreso.TipoBeneficiario);
                miComando.Parameters.AddWithValue("estado", egreso.Estado);
                miConexion.MiConexion.Open();
                var id = Convert.ToInt32(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                foreach (var cuenta in egreso.Cuentas)
                {
                    cuenta.Id = id;
                   // daoCuentaPuc.IngresarEgresoCuenta(cuenta);
                    IngresarEgresoRemisionConcepto(cuenta);
                }
                foreach (var pago in egreso.Pagos)
                {
                    if (pago.Valor != 0)
                    {
                        pago.Caja.Id = id;
                        daoFormaPago.IngresarEgresoPagoRemisionProveedor(pago);
                    }
                }
                daoConsecutivo.ActualizarConsecutivo("EgresoRemision");
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorIngresar + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        private void IngresarEgresoRemisionConcepto(SubCuentaPuc concepto)
        {
            try
            {
                CargarComando("insertar_egreso_remision_concepto");
                miComando.Parameters.AddWithValue("idegreso", concepto.Id);
                miComando.Parameters.AddWithValue("concepto", concepto.Nombre);
                miComando.Parameters.AddWithValue("valor", Convert.ToInt32(concepto.Numero));
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al ingresar el concepto del egreso.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        // End Egreso Remisino de ProveedorEgreso Remision de Proveedor

        //Retiro

        /// <summary>
        /// Ingresa el registro de un Retiro a la Base de Datos.
        /// </summary>
        /// <param name="retiro">Retiro a ingresar.</param>
        /*public void IngresarRetiro(Egreso retiro)
        {
            try
            {*/
                //CargarComando(IngresarRetiro_);
               /* miComando.Parameters.AddWithValue("caja", retiro.IdBaseCaja);
                miComando.Parameters.AddWithValue("pago", retiro.IdPago);
                miComando.Parameters.AddWithValue("hora", retiro.Hora.TimeOfDay);
                miComando.Parameters.AddWithValue("valor", retiro.Valor);
                miComando.Parameters.AddWithValue("concepto", retiro.Concepto);*/
                /*miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorIngRetiro + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }*/

        //Arqueo

        /// <summary>
        /// Ingresa el registro de un Arqueo a la Base de Datos.
        /// </summary>
        /// <param name="arqueo">Arqueo a ingresar.</param>
        public void IngresarArqueo(Arqueo arqueo)
        {
            try
            {
                CargarComando(IngresarArqueo_);
                miComando.Parameters.AddWithValue("fecha", arqueo.Fecha);
                miComando.Parameters.AddWithValue("hora", arqueo.Fecha.TimeOfDay);
                miComando.Parameters.AddWithValue("caja", arqueo.Caja.Id);
                miComando.Parameters.AddWithValue("usuario", arqueo.Usuario.Id);
                //miComando.Parameters.AddWithValue("efectivo", arqueo.Apertura);
                miComando.Parameters.AddWithValue("cheque", arqueo.Cierre);
                miComando.Parameters.AddWithValue("tarjeta", arqueo.Tarjeta);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorIngArqueo + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Obtiene el resultado de la consulta del Arqueos.
        /// </summary>
        /// <param name="idCaja">Id de la caja a consultar Arqueos.</param>
        /// <param name="fecha">Fecha a consultar Arqueos.</param>
        /// <returns></returns>
        public DataTable Arqueos(int idCaja, DateTime fecha)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdpter("arqueos");
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("caja", idCaja);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los arqueos.\n" + ex.Message);
            }
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
        /// Inicializa una nueva instancia de NpgsqlDataAdapter de tipo Stored Procedure.
        /// </summary>
        /// <param name="cmd">Sentencia a ejecutar.</param>
        public void CargarAdpter(string cmd)
        {
            miAdapter = new NpgsqlDataAdapter(cmd, miConexion.MiConexion);
            miAdapter.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
        }
    }
}