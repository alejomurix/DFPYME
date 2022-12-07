using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using System.Data;
using DTO.Clases;
using System.Collections;

namespace DataAccessLayer.Clases
{
    /// <summary>
    /// Representa una clase de transacciones a Base de Datos de Dian.
    /// </summary>
    public class DaoDian
    {
        /// <summary>
        /// Representa una sentencia adapter en posgres sql.
        /// </summary>
        private NpgsqlDataAdapter miAdapter;

        /// <summary>
        /// Representa una sentenca en sql.
        /// </summary>
        private NpgsqlCommand miComando;

        /// <summary>
        /// Representa el objeto de conexión.
        /// </summary>
        private Conexion miConexion;

        

        /// <summary>
        /// Representa una tabla de datos en memoria.
        /// </summary>
        //  private DataTable miDateTable; 

        /// <summary>
        /// Representa la función insertar_dian.
        /// </summary>
        private string sqlInsertarDian = "insertar_dian";

        /// <summary>
        /// Representa la función insertar_dian_credito.
        /// </summary>
        private string IngresaDianCredito = "insertar_dian_credito";

        /// <summary>
        /// representa la función consulta_dian.
        /// </summary>
        private string sqlConsultaDian = "consulta_dian";

        /// <summary>
        /// Representa la función: print_dian.
        /// </summary>
        private string Print_ = "print_dian";

        /// <summary>
        /// Representa la función: print_dian_credito.
        /// </summary>
        private string PrintCredito = "print_dian_credito";

        public DaoDian()
        {
            this.miConexion = new Conexion();
            //this.miDaoConsecutivo = new DaoConsecutivo();
        }

        /// <summary>
        /// Ingresa los datos del Registro de la Dian en base de datos.
        /// </summary>
        /// <param name="dian">Registro de la Dian a Ingresar.</param>
        /// <param name="contado">Establece el valor que indica si el registro es para Facturas de contado.</param>
        public void InsertaDian(Dian dian, bool contado)
        {
            //var miDaoFactura = new DaoFacturaVenta();
            try
            {
                if (contado)
                {
                    CargarComandoStoreProsedure(sqlInsertarDian);
                }
                else
                {
                    CargarComandoStoreProsedure(IngresaDianCredito);
                }
                miComando.Parameters.AddWithValue("", dian.NumeroResolucion);
                miComando.Parameters.AddWithValue("", dian.FechaExpedicion);
                miComando.Parameters.AddWithValue("", dian.RangoInicial);
                miComando.Parameters.AddWithValue("", dian.RangoFinal);
                miComando.Parameters.AddWithValue("", dian.SerieInicial);
                miComando.Parameters.AddWithValue("", dian.SerieFinal);
                miComando.Parameters.AddWithValue("", dian.TextoInicial);
                miComando.Parameters.AddWithValue("", dian.TextoFinal);
                miComando.Parameters.AddWithValue("", dian.IdModalidad);
                miComando.Parameters.AddWithValue("", dian.FechaExpedicion.AddMonths(6));  //  Vigencia 6 meses
                miComando.Parameters.AddWithValue("", 1);                                  //  Id_caja = 1, codigo quemado.
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();

                //ActualizarConsecutivo("FacturaPrefijo", dian.SerieInicial);
                
                //miDaoFactura.ActualizarConsecutivo(dian.RangoInicial.ToString(), contado);
                //miDaoFactura.ActualizarConsecutivo(dian.SerieInicial + dian.RangoInicial.ToString(), contado);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al insertar el registro Dian.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        private void ActualizarConsecutivo(string nombre, string numero)
        {
            try
            {
                CargarComandoStoreProsedure("actualizar_consecutivo");
                miComando.Parameters.AddWithValue("", nombre);
                miComando.Parameters.AddWithValue("", numero);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al actualizar el consecutivo.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Ago la consulta en la base dedatos 
        /// </summary>
        /// <returns></returns>
        public DataTable ConsultaDian()
        {
            var miTable = Tabla();
            try
            {
                var t = new DataTable();
                CargarAdapterStoredProcedure(sqlConsultaDian);
                miAdapter.Fill(t);
                foreach (DataRow row in t.Rows)
                {
                    var row_ = miTable.NewRow();
                    row_["id"] = row["iddian"];
                    row_["Resolucion"] = row["numeroresoluciondian"];
                    row_["Fecha"] = row["fechadian"];
                    row_["Desde"] = row["inicialestatica"].ToString() + row["rangoinicialdian"].ToString();
                    row_["Hasta"] = row["finalestatica"].ToString() + row["rangofinaldian"].ToString();
                    row_["TxtInicial"] = row["texto_inicial"];
                    row_["TxtFinal"] = row["texto_final"];
                    miTable.Rows.Add(row_);
                }

                return miTable;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar Dian." + ex.Message);
            }
        }

        public Dian ConsultaDian(int id)
        {
            try
            {
                this.CargarComandoStoreProsedure("consulta_dian");
                this.miComando.Parameters.AddWithValue("", id);
                this.miConexion.MiConexion.Open();
                NpgsqlDataReader reader = this.miComando.ExecuteReader();
                Dian dian = new Dian();
                while (reader.Read())
                {
                    dian.Id = reader.GetInt32(0);
                    dian.NumeroResolucion = reader.GetInt64(1);
                    dian.FechaExpedicion = reader.GetDateTime(2);
                    dian.RangoInicial = reader.GetInt64(3);
                    dian.RangoFinal = reader.GetInt64(4);
                    dian.SerieInicial = reader.GetString(5);
                    dian.SerieFinal = reader.GetString(6);
                    dian.TextoInicial = reader.GetString(7);
                    dian.TextoFinal = reader.GetString(8);
                    dian.VigenciaMes = reader.GetInt32(12);
                }
                this.miConexion.MiConexion.Close();
                this.miComando.Dispose();
                return dian;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { this.miConexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Obtiene los datos del Registro de la Dian para las Facturas de Crédito.
        /// </summary>
        /// <returns></returns>
        public DataTable ConsultaDianCredito()
        { 
            var miTable = Tabla();
            try
            {
                var t = new DataTable();
                CargarAdapterStoredProcedure("consulta_dian_credito");
                miAdapter.Fill(t);
                foreach (DataRow row in t.Rows)
                {
                    var row_ = miTable.NewRow();
                    row_["id"] = row["iddian"];
                    row_["Resolucion"] = row["numeroresoluciondian"];
                    row_["Fecha"] = row["fechadian"];
                    row_["Desde"] = row["inicialestatica"] + row["rangoinicialdian"].ToString();
                    row_["Hasta"] = row["finalestatica"] + row["rangofinaldian"].ToString();
                    miTable.Rows.Add(row_);
                }

                return miTable;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar Dian." + ex.Message);
            }
        }

        public List<Dian> RegistrosDianVentas(int idCaja, DateTime fecha)
        {
            try
            {
                List<Dian> registrosDian = new List<Dian>();
                this.CargarComandoStoreProsedure("dian_ventas");
                this.miComando.Parameters.AddWithValue("", idCaja);
                this.miComando.Parameters.AddWithValue("", fecha);
                this.miConexion.MiConexion.Open();
                NpgsqlDataReader reader = this.miComando.ExecuteReader();
                while (reader.Read())
                {
                    var dian = new Dian();
                    dian.Id = reader.GetInt32(0);
                    dian.NumeroResolucion = reader.GetInt64(1);
                    dian.FechaExpedicion = reader.GetDateTime(2);
                    dian.RangoInicial = reader.GetInt64(3);
                    dian.RangoFinal = reader.GetInt64(4);
                    dian.SerieInicial = reader.GetString(5);
                    dian.SerieFinal = reader.GetString(6);
                    dian.IdModalidad = reader.GetInt32(9);
                    dian.Vigencia = reader.GetDateTime(10);
                    registrosDian.Add(dian);
                }
                this.miConexion.MiConexion.Close();
                this.miComando.Dispose();
                return registrosDian;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { this.miConexion.MiConexion.Close(); }
        }

        public List<Dian> RegistrosDianVentas(DateTime fecha)
        {
            try
            {
                List<Dian> registrosDian = new List<Dian>();
                this.CargarComandoStoreProsedure("dian_ventas");
                this.miComando.Parameters.AddWithValue("", fecha);
                this.miConexion.MiConexion.Open();
                NpgsqlDataReader reader = this.miComando.ExecuteReader();
                while (reader.Read())
                {
                    var dian = new Dian();
                    dian.Id = reader.GetInt32(0);
                    dian.NumeroResolucion = reader.GetInt64(1);
                    dian.FechaExpedicion = reader.GetDateTime(2);
                    dian.RangoInicial = reader.GetInt64(3);
                    dian.RangoFinal = reader.GetInt64(4);
                    dian.SerieInicial = reader.GetString(5);
                    dian.SerieFinal = reader.GetString(6);
                    dian.IdModalidad = reader.GetInt32(9);
                    dian.Vigencia = reader.GetDateTime(10);
                    registrosDian.Add(dian);
                }
                this.miConexion.MiConexion.Close();
                this.miComando.Dispose();
                return registrosDian;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { this.miConexion.MiConexion.Close(); }
        }

        public string SerieDian()
        {
            try
            {
                var serie = "";
                CargarComandoStoreProsedure("serie_dian");
                miConexion.MiConexion.Open();
                serie = Convert.ToString(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return serie;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar la serie.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Tabal general
        /// </summary>
        /// <returns></returns>
        private DataTable Tabla()
        {
            var miTabla = new DataTable();
            miTabla.Columns.Add(new DataColumn("id", typeof(int)));
            miTabla.Columns.Add(new DataColumn("Resolucion", typeof(string)));
            miTabla.Columns.Add(new DataColumn("Fecha", typeof(DateTime)));
            miTabla.Columns.Add(new DataColumn("Desde", typeof(string)));
            miTabla.Columns.Add(new DataColumn("Hasta", typeof(string)));
            miTabla.Columns.Add(new DataColumn("TxtInicial", typeof(string)));
            miTabla.Columns.Add(new DataColumn("TxtFinal", typeof(string)));
            return miTabla;
        }

        /// <summary>
        /// Obtiene los datos del registro de la DIAN para su impresión.
        /// </summary>
        /// <param name="contado">Indica si la factura emitida es de contado o no(crédito).</param>
        /// <returns></returns>
        public DataSet Print(bool contado)
        {
            var dataSet = new DataSet();
            try
            {
                if (contado)
                {
                    CargarAdapterStoredProcedure(Print_);
                }
                else
                {
                    CargarAdapterStoredProcedure(Print_);
                    miAdapter.SelectCommand.Parameters.AddWithValue("pago", contado);
                }
                miAdapter.Fill(dataSet, "TDian");
                return dataSet;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar los datos de la DIAN.\n" + ex.Message);
            }
        }

        public void EditarTextos(string textoInicial, string textoFinal)
        {
            try
            {
                CargarComandoStoreProsedure("editar_dian_texto");
                this.miComando.Parameters.AddWithValue("", textoInicial);
                this.miComando.Parameters.AddWithValue("", textoFinal);
                this.miConexion.MiConexion.Open();
                this.miComando.ExecuteNonQuery();
                this.miConexion.MiConexion.Close();
                this.miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al editar los textos.\n" + ex.Message);
            }
            finally { this.miConexion.MiConexion.Close(); }
        }

        public Int32 MaxId()
        {
            try
            {
                this.CargarComandoStoreProsedure("max_dian");
                this.miConexion.MiConexion.Open();
                int count = Convert.ToInt32(this.miComando.ExecuteScalar());
                this.miConexion.MiConexion.Close();
                this.miComando.Dispose();
                return count;
            }
            catch (InvalidCastException)
            {
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { this.miConexion.MiConexion.Close(); }
        }

        public bool FacturacionActiva(string nameRegDian, string nameFactura)
        {
            try
            {
                bool activa = true;
                var dian = this.ConsultaDian(Convert.ToInt32(this.Consecutivo(nameRegDian)));
                var numero = Convert.ToInt32(this.Consecutivo(nameFactura));
                if (dian.Id == this.MaxId() && numero > dian.RangoFinal)
                {
                    activa = false;
                }
                return activa;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Int64 NumeracionRestante(string nameRegDian, string nameFactura)
        {
            try
            {
                //var dian = this.ConsultaDian(Convert.ToInt32(this.Consecutivo(nameRegDian)));
                var dian = this.ConsultaDian(this.MaxId());
                var numero = Convert.ToInt32(this.Consecutivo(nameFactura));
                return (Convert.ToInt64(dian.RangoFinal) - Convert.ToInt64(numero));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string Consecutivo(string nombre)
        {
            try
            {
                CargarComandoStoreProsedure("recuperar_consecutivo");
                miComando.Parameters.AddWithValue("nombre", nombre);
                miConexion.MiConexion.Open();
                var numero = Convert.ToString(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return numero;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al obtener el consecutivo.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }



        public void ActualizarIdDian()
        {
            try
            {
                //var facts = this.Facturas();
                var dians = this.RegistrosDian();

                foreach (var fact in this.Facturas())
                {
                    if (fact.Tipo == 38562)
                    {
                        var j = fact.Tipo;
                    }
                    foreach (var dian in dians)
                    {
                        
                        if (fact.Tipo >= dian.RangoInicial && fact.Tipo <= dian.RangoFinal)
                        {
                            this.ActualizarIdDianInFrv(fact.Id, dian.Id);
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private List<Dian> RegistrosDian()
        {
            try
            {
                List<Dian> registros = new List<Dian>();

                string sql = "SELECT * FROM dian ORDER BY iddian;";
                this.miComando = new NpgsqlCommand();
                this.miComando.Connection = miConexion.MiConexion;
                this.miComando.CommandType = CommandType.Text;
                this.miComando.CommandText = sql;
                this.miConexion.MiConexion.Open();
                NpgsqlDataReader reader = this.miComando.ExecuteReader();
                while (reader.Read())
                {
                    Dian dian = new Dian();
                    dian.Id = reader.GetInt32(0);
                    dian.NumeroResolucion = reader.GetInt64(1);
                    dian.FechaExpedicion = reader.GetDateTime(2);
                    dian.RangoInicial = reader.GetInt64(3);
                    dian.RangoFinal = reader.GetInt64(4);
                    dian.SerieInicial = reader.GetString(5);
                    dian.SerieFinal = reader.GetString(6);
                    dian.TextoInicial = reader.GetString(7);
                    dian.TextoFinal = reader.GetString(8);
                    registros.Add(dian);
                }
                this.miConexion.MiConexion.Close();
                this.miComando.Dispose();
                return registros;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { this.miConexion.MiConexion.Close(); }
        }

        private List<FacturaVenta> Facturas()
        {
            try
            {
                List<FacturaVenta> registros = new List<FacturaVenta>();

                string sql = "SELECT id, numerofactura_venta FROM factura_venta ORDER BY id ASC;";
                this.miComando = new NpgsqlCommand();
                this.miComando.Connection = miConexion.MiConexion;
                this.miComando.CommandType = CommandType.Text;
                this.miComando.CommandText = sql;
                this.miConexion.MiConexion.Open();
                NpgsqlDataReader reader = this.miComando.ExecuteReader();
                while (reader.Read())
                {
                    FacturaVenta facts = new FacturaVenta();
                    facts.Id = reader.GetInt32(0);
                    facts.Tipo = this.NoFact(reader.GetString(1));
                    //facts.Numero = reader.GetInt64(1);
                    registros.Add(facts);
                }
                this.miConexion.MiConexion.Close();
                this.miComando.Dispose();
                return registros;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { this.miConexion.MiConexion.Close(); }
        }

        private int NoFact(string num)
        {
            try
            {
                if (num.Equals("A1"))
                {
                    var j = num;
                }
                string numero = "";
                try
                {
                    return Convert.ToInt32(num);
                }
                catch (FormatException)
                {
                    var n = num.ToArray();
                    for (int i = 0; i < n.Length; i++)
                    {
                        if (!this.IsString(n[i].ToString()))
                        {
                            numero += n[i];
                        }
                    }
                    return Convert.ToInt32(numero);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "\nCOD: " + num);
            }
        }

        private bool IsString(string n)
        {
            try
            {
                Convert.ToInt32(n);
                return false;
            }
            catch
            {
                return true;
            }
        }

        private void ActualizarIdDianInFrv(int id, int idDian)
        {
            try
            {
                string sql = "UPDATE factura_venta SET id_resolucion_dian = " + idDian +" WHERE id = " + id + ";";

                miComando = new NpgsqlCommand();
                miComando.Connection = miConexion.MiConexion;
                miComando.CommandType = CommandType.Text;
                miComando.CommandText = sql;
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { this.miConexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Inicializa una nueva instancia de NpgsqlCommand de tipo StoredProcedure.
        /// </summary>
        /// <param name="cmd">Comando a ejecutar.</param>
        private void CargarComandoStoreProsedure(string cmd)
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
        private void CargarAdapterStoredProcedure(string cmd)
        {
            miAdapter = new NpgsqlDataAdapter(cmd, miConexion.MiConexion);
            miAdapter.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
        }
    }
}