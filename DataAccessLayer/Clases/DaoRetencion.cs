using System;
using System.Data;
using System.Linq;
using System.Text;
using DTO.Clases;
using Npgsql;

namespace DataAccessLayer.Clases
{
    public class DaoRetencion
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

        public DaoRetencion()
        {
            this.miConexion = new Conexion();
        }

        #region Retencion

        public int IngresarRubro(string rubro)
        {
            try
            {
                CargarComando("insertar_retencion");
                miComando.Parameters.AddWithValue("rubro", rubro);
                miConexion.MiConexion.Open();
                var id = Convert.ToInt32(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return id;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al ingresar el Rubro de la Retención.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable Rubros()
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapter("retenciones");
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los Rubros de las Retenciones.\n" + ex.Message);
            }
        }

        public void EditarRubro(int id, string rubro)
        {
            try
            {
                CargarComando("editar_retencion");
                miComando.Parameters.AddWithValue("id", id);
                miComando.Parameters.AddWithValue("rubro", rubro);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al Editar el Rubro de la Retención.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public void EliminarRubro(int id)
        {
            try
            {
                CargarComando("eliminar_retencion");
                miComando.Parameters.AddWithValue("id", id);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al Eliminar el Rubro de la Retención.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public int IngresarConcepto(RetencionConcepto concepto)
        {
            try
            {
                CargarComando("insertar_retencion_concepto");
                miComando.Parameters.AddWithValue("idrete", concepto.Id);
                miComando.Parameters.AddWithValue("concepto", concepto.Concepto);
                miComando.Parameters.AddWithValue("cifraUvt", concepto.CifraUVT);
                miComando.Parameters.AddWithValue("cifrapesos", concepto.CifraPesos);
                miComando.Parameters.AddWithValue("tarifa", concepto.Tarifa);
                miConexion.MiConexion.Open();
                var id = Convert.ToInt32(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return id;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al ingresar el Concepto de la Retención.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable Conceptos(int idRubro)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapter("retenciones_concepto");
                miAdapter.SelectCommand.Parameters.AddWithValue("idrubro", idRubro);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar las Clases del PUC.\n" + ex.Message);
            }
        }

        public void EditarConcepto(RetencionConcepto concepto)
        {
            try
            {
                CargarComando("editar_retencion_concepto");
                miComando.Parameters.AddWithValue("id", concepto.Id);
                miComando.Parameters.AddWithValue("concepto", concepto.Concepto);
                miComando.Parameters.AddWithValue("cifraUvt", concepto.CifraUVT);
                miComando.Parameters.AddWithValue("cifraPesos", concepto.CifraPesos);
                miComando.Parameters.AddWithValue("tarifa", concepto.Tarifa);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al editar el concepto de retención.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public void EliminarConcepto(int idConcepto)
        {
            try
            {
                CargarComando("eliminar_retencion_concepto");
                miComando.Parameters.AddWithValue("id", idConcepto);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al eliminar el concepto de retención.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        #endregion

        #region Rete-Compra

        public DataTable RetencionesAplicadasACompra(int idEmpresaCompra, int idEmpresaVende)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapter("retenciones_aplicadas_compras");
                miAdapter.SelectCommand.Parameters.AddWithValue("idcompra", idEmpresaCompra);
                miAdapter.SelectCommand.Parameters.AddWithValue("idvende", idEmpresaVende);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar las Retenciones.\n" + ex.Message);
            }
        }

        public DataTable RetencionesAplicadasACompra
            (int idEmpresaCompra, int idEmpresaVende, int idReteAplicada)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapter("retenciones_aplicadas_compras_por_rubro");
                miAdapter.SelectCommand.Parameters.AddWithValue("idcompra", idEmpresaCompra);
                miAdapter.SelectCommand.Parameters.AddWithValue("idvende", idEmpresaVende);
                miAdapter.SelectCommand.Parameters.AddWithValue("idreteaplica", idReteAplicada);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar las Retenciones Aplicadas.\n" + ex.Message);
            }
        }

        public bool ExisteReteCompra(int idEmpresaCompra, int idEmpresaVende)
        {
            try
            {
                CargarComando("existe_retencion_en_compra");
                miComando.Parameters.AddWithValue("empCompra", idEmpresaCompra);
                miComando.Parameters.AddWithValue("empVenta", idEmpresaVende);
                miConexion.MiConexion.Open();
                var existe = Convert.ToBoolean(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return existe;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al comprobar la Retención en Compra.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public int IdReteCompra(int idEmpresaCompra, int idEmpresaVende)
        {
            try
            {
                CargarComando("id_retencion_en_compra");
                miComando.Parameters.AddWithValue("empCompra", idEmpresaCompra);
                miComando.Parameters.AddWithValue("empVenta", idEmpresaVende);
                miConexion.MiConexion.Open();
                var id = 0;
                var scalar = miComando.ExecuteScalar();
                if (scalar != DBNull.Value)
                {
                    id = Convert.ToInt32(miComando.ExecuteScalar());
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return id;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al comprobar la Retención en Compra.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public long IngresarReteCompra(int idRegimenCompra, int idRegimenVende)
        {
            try
            {
                CargarComando("ingresar_retencion_en_compra");
                miComando.Parameters.AddWithValue("idcompra", idRegimenCompra);
                miComando.Parameters.AddWithValue("idventa", idRegimenVende);
                miConexion.MiConexion.Open();
                var id = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return id;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al ingresar la relación de Empresas.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public bool ExisteAplicaReteCompra(int idReteCompra, int idReteConcepto)
        {
            try
            {
                CargarComando("existe_aplica_retencion_en_compra");
                miComando.Parameters.AddWithValue("empCompra", idReteCompra);
                miComando.Parameters.AddWithValue("empVenta", idReteConcepto);
                miConexion.MiConexion.Open();
                var existe = Convert.ToBoolean(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return existe;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al comprobar la Retención aplicada en Compra.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public bool ExisteAplicaReteCompra(int idReteCompra)
        {
            try
            {
                CargarComando("existe_aplica_retencion_en_compra");
                miComando.Parameters.AddWithValue("empCompra", idReteCompra);
                miConexion.MiConexion.Open();
                var existe = Convert.ToBoolean(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return existe;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al comprobar la Retención aplicada en Compra.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public bool ExisteReteConceptoCompra(int idConcepto)
        {
            try
            {
                CargarComando("existe_retencion_concepto_compra");
                miComando.Parameters.AddWithValue("idConcepto", idConcepto);
                miConexion.MiConexion.Open();
                var existe = Convert.ToBoolean(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return existe;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al comprobar el Concepto de la Retención.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public long IngresarAplicaReteCompra(int idReteCompra, int idReteConcepto)
        {
            try
            {
                CargarComando("ingresar_retencion_aplica_compra");
                miComando.Parameters.AddWithValue("idcompra", idReteCompra);
                miComando.Parameters.AddWithValue("idconcepto", idReteConcepto);
                miConexion.MiConexion.Open();
                var id = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return id;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al ingresar la relación de Retención Aplciada.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public void EliminarAplicaReteCompra(int id)
        {
            try
            {
                CargarComando("eliminar_aplica_retencion_en_compra");
                miComando.Parameters.AddWithValue("idcompra", id);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al eliminar el registro de Retención aplicada.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public long IngresarFacturaRetencion(RetencionConcepto retencion)
        {
            try
            {
                CargarComando("ingresar_retencion_en_compra");
                miComando.Parameters.AddWithValue("idfactura", retencion.Retencion.Id);
                miComando.Parameters.AddWithValue("concepto", retencion.Concepto);
                miComando.Parameters.AddWithValue("uvt", retencion.CifraUVT);
                miComando.Parameters.AddWithValue("pesos", retencion.CifraPesos);
                miComando.Parameters.AddWithValue("tarifa", retencion.Tarifa);
                miConexion.MiConexion.Open();
                var id = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return id;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al ingresar la Retencion en la Factura.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public void EdtarRetencionDeCompra(RetencionConcepto retencion)
        {
            try
            {
                CargarComando("editar_retencion_compra");
                miComando.Parameters.AddWithValue("id", retencion.Id);
                miComando.Parameters.AddWithValue("idfactura", retencion.IdCuentaPuc);
                miComando.Parameters.AddWithValue("Concepto", retencion.Concepto);
                miComando.Parameters.AddWithValue("CifraUVT", retencion.CifraUVT);
                miComando.Parameters.AddWithValue("CifraPesos", retencion.CifraPesos);
                miComando.Parameters.AddWithValue("Tarifa", retencion.Tarifa);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error al editar la retención.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable RetencionesACompra(int idFacturaProveedor)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapter("retencion_de_compras");
                miAdapter.SelectCommand.Parameters.AddWithValue("idfactura", idFacturaProveedor);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar las Retenciones de la Factura.\n" + ex.Message);
            }
        }

        #endregion

        #region Rete-Venta

        public DataTable RetencionesAplicadasAVenta(int idEmpresaCompra, int idEmpresaVende)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapter("retenciones_aplicadas_ventas");
                miAdapter.SelectCommand.Parameters.AddWithValue("idcompra", idEmpresaCompra);
                miAdapter.SelectCommand.Parameters.AddWithValue("idvende", idEmpresaVende);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar las Retenciones.\n" + ex.Message);
            }
        }

        public DataTable RetencionesAplicadasAVenta
            (int idEmpresaCompra, int idEmpresaVende, int idReteAplicada)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapter("retenciones_aplicadas_venta_por_rubro");
                miAdapter.SelectCommand.Parameters.AddWithValue("idcompra", idEmpresaCompra);
                miAdapter.SelectCommand.Parameters.AddWithValue("idvende", idEmpresaVende);
                miAdapter.SelectCommand.Parameters.AddWithValue("idreteaplica", idReteAplicada);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar las Retenciones Aplicadas.\n" + ex.Message);
            }
        }

        public bool ExisteReteVenta(int idEmpresaCompra, int idEmpresaVende)
        {
            try
            {
                CargarComando("existe_retencion_en_venta");
                miComando.Parameters.AddWithValue("empCompra", idEmpresaCompra);
                miComando.Parameters.AddWithValue("empVenta", idEmpresaVende);
                miConexion.MiConexion.Open();
                var existe = Convert.ToBoolean(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return existe;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al comprobar la Retención en Venta.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public int IdReteVenta(int idEmpresaCompra, int idEmpresaVende)
        {
            try
            {
                CargarComando("id_retencion_en_venta");
                miComando.Parameters.AddWithValue("empCompra", idEmpresaCompra);
                miComando.Parameters.AddWithValue("empVenta", idEmpresaVende);
                miConexion.MiConexion.Open();
                var id = Convert.ToInt32(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return id;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al comprobar la Retención en Compra.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public long IngresarReteVenta(int idRegimenCompra, int idRegimenVende)
        {
            try
            {
                CargarComando("ingresar_retencion_en_venta");
                miComando.Parameters.AddWithValue("idcompra", idRegimenCompra);
                miComando.Parameters.AddWithValue("idventa", idRegimenVende);
                miConexion.MiConexion.Open();
                var id = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return id;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al ingresar la relación de Empresas.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public bool ExisteAplicaReteVenta(int idReteVenta, int idReteConcepto)
        {
            try
            {
                CargarComando("existe_aplica_retencion_en_venta");
                miComando.Parameters.AddWithValue("empVende", idReteVenta);
                miComando.Parameters.AddWithValue("reteConcepto", idReteConcepto);
                miConexion.MiConexion.Open();
                var existe = Convert.ToBoolean(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return existe;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al comprobar la Retención aplicada en Venta.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public bool ExisteReteConceptoVenta(int idConcepto)
        {
            try
            {
                CargarComando("existe_retencion_concepto_venta");
                miComando.Parameters.AddWithValue("idConcepto", idConcepto);
                miConexion.MiConexion.Open();
                var existe = Convert.ToBoolean(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return existe;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al comprobar el Concepto de la Retención.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public long IngresarAplicaReteVenta(int idReteVenta, int idReteConcepto)
        {
            try
            {
                CargarComando("ingresar_retencion_aplica_venta");
                miComando.Parameters.AddWithValue("idcompra", idReteVenta);
                miComando.Parameters.AddWithValue("idconcepto", idReteConcepto);
                miConexion.MiConexion.Open();
                var id = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return id;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al ingresar la relación de Retención Aplciada.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public void EliminarAplicaReteVenta(int id)
        {
            try
            {
                CargarComando("eliminar_aplica_retencion_en_venta");
                miComando.Parameters.AddWithValue("idventa", id);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al eliminar el registro de Retención aplicada.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public long IngresarFacturaVentaRetencion(RetencionConcepto retencion)
        {
            try
            {
                CargarComando("ingresar_retencion_en_venta");
                miComando.Parameters.AddWithValue("idfactura", retencion.Retencion.Rubro);
                miComando.Parameters.AddWithValue("concepto", retencion.Concepto);
                miComando.Parameters.AddWithValue("uvt", retencion.CifraUVT);
                miComando.Parameters.AddWithValue("pesos", retencion.CifraPesos);
                miComando.Parameters.AddWithValue("tarifa", retencion.Tarifa);
                miComando.Parameters.AddWithValue("idfactura", retencion.IdFactura);
                miComando.Parameters.AddWithValue("valor", retencion.Valor);
                miConexion.MiConexion.Open();
                var id = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return id;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al ingresar la Retención en la Factura.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public void EditarFacturaVentaRetencion(RetencionConcepto retencion)
        {
            try
            {
                CargarComando("editar_retencion_en_venta");
                miComando.Parameters.AddWithValue("id", retencion.Id);
                miComando.Parameters.AddWithValue("Rubro", retencion.Retencion.Rubro);
                miComando.Parameters.AddWithValue("Concepto", retencion.Concepto);
                miComando.Parameters.AddWithValue("CifraUVT", retencion.CifraUVT);
                miComando.Parameters.AddWithValue("CifraPesos", retencion.CifraPesos);
                miComando.Parameters.AddWithValue("Tarifa", retencion.Tarifa);
                miComando.Parameters.AddWithValue("idfactura", retencion.IdFactura);
                miComando.Parameters.AddWithValue("valor", retencion.Valor);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error al editar la retención.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable RetencionesAVenta(string numeroFactura)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapter("retencion_de_ventas");
                miAdapter.SelectCommand.Parameters.AddWithValue("numeroFactura", numeroFactura);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar las Retenciones de la Factura.\n" + ex.Message);
            }
        }

        public DataTable RetencionesAVenta(int id)
        {
            var tabla = new DataTable();
            try
            {
                CargarAdapter("retencion_de_ventas");
                miAdapter.SelectCommand.Parameters.AddWithValue("", id);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar las Retenciones de la Factura.\n" + ex.Message);
            }
        }

        #endregion

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