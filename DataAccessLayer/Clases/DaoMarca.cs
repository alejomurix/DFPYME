using System;
using System.Collections;
using System.Collections.Generic;
using Npgsql;
using NpgsqlTypes;
using DTO.Clases;
using System.Data;
using Utilities;

namespace DataAccessLayer.Clases
{
    /// <summary>
    /// Representa una clase de tranzacciones a base de datos de Marca.
    /// </summary>
    public class DaoMarca
    {
        /// <summary>
        /// Objeto de conexion a base de datos PostgreSQL
        /// </summary>
        private Conexion conexion;

        /// <summary>
        /// Representa un objeto de sentencias SQL a PostgreSQL
        /// </summary>
        private NpgsqlCommand comando;

        private NpgsqlDataAdapter miAdapter;

        private DaoProducto miDaoProducto;

        private bool TipoAproximacion;

        /// <summary>
        /// Inicializa una nueva instanca de la clase DaoMarca.
        /// </summary>
        public DaoMarca()
        {
            this.conexion = new Conexion();
            this.miDaoProducto = new DaoProducto();
            this.TipoAproximacion = Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio"));
        }

        /// <summary>
        /// Verifica si el nombre de la marca existe en la base de datos.
        /// </summary>
        /// <param name="nombre">Nombre a comprobar</param>
        /// <returns></returns>
        public bool ExisteMarca(string nombre)
        {
            try
            {
                CargarComandoStoredProcedure("existe_marca");
                comando.Parameters.AddWithValue("nombre", nombre);
                conexion.MiConexion.Open();
                var resutlado = Convert.ToBoolean(comando.ExecuteScalar());
                conexion.MiConexion.Close();
                comando.Dispose();
                return resutlado;
            }
            catch (Exception ex)
            {
                throw new Exception("No se logro verificar la marca. " + ex.Message);
            }
            finally { conexion.MiConexion.Close(); }
        }

        public int UltimoId()
        {
            try
            {
                CargarComandoStoredProcedure("ultimo_id_marca");
                conexion.MiConexion.Open();
                var id = Convert.ToInt32(comando.ExecuteScalar());
                conexion.MiConexion.Close();
                comando.Dispose();
                return id;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar el consecutivo.\n" + ex.Message);
            }
            finally { conexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Inserta un registro de marca en la base de datos.
        /// </summary>
        /// <param name="mimarca">Marca a ingresar</param>
        public void InsertarMarca(Marca mimarca)
        {
            try
            {
                CargarComandoStoredProcedure("insertarMarca");
                comando.Parameters.AddWithValue("nombre", mimarca.NombreMarca);
                conexion.MiConexion.Open();
                comando.ExecuteNonQuery();
                conexion.MiConexion.Close();
                comando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error al insertar la marca. " + ex.Message);
            }
            finally { conexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Obtiene el listado de las marcas en una coleccion.
        /// </summary>
        /// <returns></returns>
        public ArrayList ListarMarcas()
        {
            ArrayList listamarcas = new ArrayList();
            try
            {
                CargarComandoStoredProcedure("listar_marcas");
                conexion.MiConexion.Open();
                NpgsqlDataReader myReader = comando.ExecuteReader();
                while (myReader.Read())
                {
                    Marca mimarca = new Marca();
                    mimarca.IdMarca = myReader.GetInt32(0);
                    mimarca.NombreMarca = myReader.GetString(1);
                    listamarcas.Add(mimarca);
                }
                conexion.MiConexion.Close();
                comando.Dispose();
                return listamarcas;
            }
            catch (Exception ex)
            {
                throw new Exception("No se puede consultar Marca.\n" + ex.Message);
            }
            finally { conexion.MiConexion.Close(); }
        }

        public Marca Marca(int codigo)
        {
            var marca = new Marca();
            try
            {
                CargarComandoStoredProcedure("listar_marcas");
                comando.Parameters.AddWithValue("codigo", codigo);
                conexion.MiConexion.Open();
                NpgsqlDataReader myReader = comando.ExecuteReader();
                while (myReader.Read())
                {
                    marca.IdMarca = myReader.GetInt32(0);
                    marca.NombreMarca = myReader.GetString(1);
                }
                conexion.MiConexion.Close();
                comando.Dispose();
                return marca;
            }
            catch (Exception ex)
            {
                throw new Exception("No se puede consultar Marca.\n" + ex.Message);
            }
            finally { conexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Edita el registro de una marca en la base de datos.
        /// </summary>
        /// <param name="mimarca">Marca a editar.</param>
        public void EditarMarca(Marca mimarca)
        {
            try
            {
                CargarComandoStoredProcedure("editarmarca");
                comando.Parameters.AddWithValue("id", mimarca.IdMarca);
                comando.Parameters.AddWithValue("nombre", mimarca.NombreMarca);
                conexion.MiConexion.Open();
                comando.ExecuteNonQuery();
                conexion.MiConexion.Close();
                comando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error al editar la Marca. " + ex.Message);
            }
            finally { conexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Eliminar el registro de una Marca en la base de datos.
        /// </summary>
        /// <param name="idmarca">Id de la marca a eliminar.</param>
        public void EliminarMarca(int idmarca)
        {
            try
            {
                CargarComandoStoredProcedure("eliminar_marca");
                comando.Parameters.AddWithValue("idmarca", idmarca);
                conexion.MiConexion.Open();
                comando.ExecuteNonQuery();
                conexion.MiConexion.Close();
                comando.Dispose();
            }
            catch (Exception)
            {
                throw new Exception("No se puede eliminar la Marca porque tiene registros asociados a ella. ");
            }
            finally { conexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Obtiene el listado de las marcas segun el nombre o parte de este.
        /// </summary>
        /// <param name="nombremarca">Nombre a consultar.</param>
        public ArrayList ListarMarcasNombre(string nombremarca)
        {
            ArrayList listamarcasnombre = new ArrayList();
            try
            {
                CargarComandoStoredProcedure("filtro_marca_nombre");
                comando.Parameters.AddWithValue("nombremarca", nombremarca);
                conexion.MiConexion.Open();
                NpgsqlDataReader myReader = comando.ExecuteReader();
                while (myReader.Read())
                {
                    Marca mimarca = new Marca();
                    mimarca.IdMarca = myReader.GetInt32(0);
                    mimarca.NombreMarca = myReader.GetString(1);
                    listamarcasnombre.Add(mimarca);
                }
                conexion.MiConexion.Close();
                comando.Dispose();
                return listamarcasnombre;
            }
            catch (Exception ex)
            {
                throw new Exception("No se logro obtener el listado de las marcas. " + ex.Message);
            }
            finally { conexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Inserto las marcas selecionadas el sorteo.
        /// </summary>
        /// <param name="idSorteo"></param>
        /// <param name="idMarca"></param>
        public void InsertaSorteoMarca(int idSorteo, int idMarca, bool historial)
        {
            try
            {
                if (historial)
                {
                    CargarComandoStoredProcedure("insertar_historial_sorteo_marca");
                }
                else
                {
                    CargarComandoStoredProcedure("insertar_sorteo_marca");
                }
                comando.Parameters.AddWithValue("idsorteo", idSorteo);
                comando.Parameters.AddWithValue("idmarca", idMarca);
                conexion.MiConexion.Open();
                comando.ExecuteNonQuery();
                conexion.MiConexion.Close();
                comando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar el listado de marcas" + ex.Message);
            }
            finally
            {
                conexion.MiConexion.Close();
            }
        }

        /// <summary>
        /// lista las marcas seleccionadas de sorteo.
        /// </summary>
        /// <param name="idSorteo"></param>
        /// <returns></returns>
        public List<Marca> CargarMarcasSorteo(int idSorteo , bool historial)
    {
         List<Marca> listaMarcaSorteo = new List<Marca> ();
        try
        {
            if (historial)
            {
                CargarComandoStoredProcedure("historial_sorteo_marca");
            }
            else
            {
                CargarComandoStoredProcedure("sorteo_marca");
            }
            comando.Parameters.AddWithValue("idSorteo", idSorteo);           
            conexion.MiConexion.Open();
                NpgsqlDataReader myReader=comando.ExecuteReader();
                while (myReader.Read())
                {
                    Marca miMarca = new Marca();
                    miMarca.IdMarca = myReader.GetInt32(0);
                    miMarca.NombreMarca = myReader.GetString(1);
                    listaMarcaSorteo.Add(miMarca);
                }
                conexion.MiConexion.Close();
                comando.Dispose();
                return listaMarcaSorteo;
        }
        catch(Exception ex)
        {
            throw new Exception("No se pudo listar marca" + ex.Message);
        }
        finally
        {
            conexion.MiConexion.Close();
        }
    }

        /// <summary>
        /// Inserto marcas seleccionadas a promocion; 
        /// </summary>
        /// <param name="idPromocion"></param>
        /// <param name="idMarca"></param>
        public void InsertarpromocionMarca(int idPromocion, int idMarca)
        {
            try
            {
                CargarComandoStoredProcedure("insertar_promocion_marca");
                comando.Parameters.AddWithValue("idPromocion", idPromocion);
                comando.Parameters.AddWithValue("idMarca", idMarca);
                conexion.MiConexion.Open();
                comando.ExecuteNonQuery();
                conexion.MiConexion.Close();
                comando.Dispose();
            }
            catch(Exception ex)
            {
                throw new Exception("Error al insertar la promocion por marcas" + ex.Message);
            }
            finally
            {
                conexion.MiConexion.Close();
            }
        }


        // Descuentos por marca 01/03/2108

        public int CountDescuentoMarca()
        {
            try
            {
                this.CargarComandoStoredProcedure("count_marca_descuento");
                this.conexion.MiConexion.Open();
                int count = Convert.ToInt32(this.comando.ExecuteScalar());
                this.conexion.MiConexion.Close();
                this.comando.Dispose();
                return count;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el conteo de descuentos por marca.\n" + ex.Message);
            }
            finally { this.conexion.MiConexion.Close(); }
        }

        public void IngresarDescuento(Marca marca)
        {
            try
            {
                CargarComandoStoredProcedure("insertar_marca_descuento");
                this.comando.Parameters.AddWithValue("", marca.IdMarca);
                this.comando.Parameters.AddWithValue("", marca.Descuento);
                this.conexion.MiConexion.Open();
                this.comando.ExecuteNonQuery();
                this.conexion.MiConexion.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al ingresar el descuento de la marca.\n" + ex.Message);
            }
            finally { this.conexion.MiConexion.Close(); }
        }

        public void AplicarDescuentoMarca(Marca marca)
        {
            try
            {
                var listProducto = new List<Producto>();
                this.CargarComandoStoredProcedure("productos_marca");
                this.comando.Parameters.AddWithValue("", marca.IdMarca);
                this.conexion.MiConexion.Open();
                NpgsqlDataReader reader = this.comando.ExecuteReader();
                while (reader.Read())
                {
                    listProducto.Add(new Producto
                    {
                        CodigoInternoProducto = reader.GetString(0),
                        UtilidadPorcentualProducto = reader.GetDouble(7),
                        ValorVentaProducto = reader.GetInt32(8)
                    });
                }
                this.conexion.MiConexion.Close();
                this.comando.Dispose();

                foreach (var p in listProducto)
                {
                    p.ValorVentaProducto = p.ValorVentaProducto - (p.ValorVentaProducto * marca.Descuento / 100);
                    p.ValorVentaProducto = UseObject.Aproximar(Convert.ToInt32(p.ValorVentaProducto), TipoAproximacion);
                    this.miDaoProducto.EditarPrecioDeVenta
                        (p.CodigoInternoProducto, Convert.ToInt32(p.ValorVentaProducto), p.UtilidadPorcentualProducto);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al aplicar el descuento.\n" + ex.Message);
            }
            finally { this.conexion.MiConexion.Close(); }
        }

        public DataTable MarcaDescuentos()
        {
            try
            {
                CargarAdapterStoredProcedure("marca_descuentos");
                var tabla = new DataTable();
                this.miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los descuentos de las marcas.\n" + ex.Message);
            }
        }

        /*public void RestablecerValor(int idMarca)
        {
            try
            {
                CargarComandoStoredProcedure("restablecer_valor_producto");
                this.comando.Parameters.AddWithValue("", idMarca);
                this.conexion.MiConexion.Open();
                this.comando.ExecuteNonQuery();
                this.conexion.MiConexion.Close();
                this.comando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al restablecer el valor del producto.\n" + ex.Message);
            }
            finally { this.conexion.MiConexion.Close(); }
        }*/

        /*public void EliminarDescuento()
        {
            try
            {
                this.CargarComandoStoredProcedure("eliminar_marca_descuento");
                this.conexion.MiConexion.Open();
                this.comando.ExecuteNonQuery();
                this.conexion.MiConexion.Close();
                this.comando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al eliminar los valores de los productos.\n" + ex.Message);
            }
            finally { this.conexion.MiConexion.Close(); }
        }*/

        public void EliminarDescuento(int id)
        {
            try
            {
                this.CargarComandoStoredProcedure("eliminar_marca_descuento");
                this.comando.Parameters.AddWithValue("", id);
                this.conexion.MiConexion.Open();
                this.comando.ExecuteNonQuery();
                this.conexion.MiConexion.Close();
                this.comando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al eliminar el descuento de la marca.\n" + ex.Message);
            }
            finally { this.conexion.MiConexion.Close(); }
        }

        public void ReiniciarSecuenciaDescuento()
        {
            try
            {
                this.CargarComandoStoredProcedure("reiniciar_secuencia_marca_descuento");
                this.conexion.MiConexion.Open();
                this.comando.ExecuteNonQuery();
                this.conexion.MiConexion.Close();
                this.comando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al reiniciar la secuencia de los registros de descuento de marca.\n" + ex.Message);
            }
            finally { this.conexion.MiConexion.Close(); }
        }

        // Fin Descuentos por marca 01/03/2108


        public void Ajustar()
        {
            try
            {
                var tMarcas = new DataTable();
                string sql = "SELECT marca.idmarca, marca.nombremarca FROM marca ORDER BY nombremarca ASC;";
                NpgsqlDataAdapter miAdapter = new NpgsqlDataAdapter(sql, conexion.MiConexion);
                miAdapter.SelectCommand.CommandType = CommandType.Text;
                miAdapter.Fill(tMarcas);
                var cont = 100000000;
                comando = new NpgsqlCommand();
                foreach (DataRow mRow in tMarcas.Rows)
                {
                    sql = "UPDATE marca SET idmarca = " + cont + " WHERE idmarca = " + Convert.ToInt32(mRow["idmarca"]) + ";";
                    comando.Connection = conexion.MiConexion;
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = sql;
                    conexion.MiConexion.Open();
                    comando.ExecuteNonQuery();
                    conexion.MiConexion.Close();
                    cont++;
                }
                comando.Dispose();
                Ajustar2();
            }
            catch (Exception ex)
            {
                throw new Exception("OCURRIO UN ERROR.\n" + ex.Message);
            }
            finally { conexion.MiConexion.Close(); }
        }

        public void Ajustar2()
        {
            try
            {
                var tMarcas = new DataTable();
                string sql = "SELECT marca.idmarca, marca.nombremarca FROM marca ORDER BY nombremarca ASC;";
                NpgsqlDataAdapter miAdapter = new NpgsqlDataAdapter(sql, conexion.MiConexion);
                miAdapter.SelectCommand.CommandType = CommandType.Text;
                miAdapter.Fill(tMarcas);
                var cont = 1;
                comando = new NpgsqlCommand();
                foreach (DataRow mRow in tMarcas.Rows)
                {
                    sql = "UPDATE marca SET idmarca = " + cont + " WHERE idmarca = " + Convert.ToInt32(mRow["idmarca"]) + ";";
                    comando.Connection = conexion.MiConexion;
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = sql;
                    conexion.MiConexion.Open();
                    comando.ExecuteNonQuery();
                    conexion.MiConexion.Close();
                    cont++;
                }
                comando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("OCURRIO UN ERROR.\n" + ex.Message);
            }
            finally { conexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Edita Promocion marca.
        /// </summary>
        /// <param name="IdPromocion">idPromocion</param>
        /// <param name="idMarca">id marca</param>
        public  void EditarPromocionMarca(int IdPromocion, int idMarca)
        {
            try
            {
                CargarComandoStoredProcedure("edita_promocion_marca");
                comando.Parameters.AddWithValue("idPromocion", IdPromocion);
                comando.Parameters.AddWithValue("idmarca", idMarca);
                conexion.MiConexion.Open();
                comando.ExecuteNonQuery();
                conexion.MiConexion.Close();
                comando.Dispose();
            }
            catch(Exception ex)
            {
                throw new Exception("Error al editar la marca"+ex.Message);
            }
            finally
            {
                conexion.MiConexion.Close();
            }
        }

        /// <summary>
        /// Inicializa una nueva instancia de NpgsqlCommand de tipo StoredProcedure.
        /// </summary>
        /// <param name="cmd">Comando a ejecutar</param>
        private void CargarComandoStoredProcedure(string cmd)
        {
            comando = new NpgsqlCommand();
            comando.Connection = conexion.MiConexion;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = cmd;
        }

        /// <summary>
        /// Inicializa una nueva instancia de NpgsqlDataAdapter de tipo Stored Procedure.
        /// </summary>
        /// <param name="cmd">Sentencia a ejecutar.</param>
        private void CargarAdapterStoredProcedure(string cmd)
        {
            this.miAdapter = new NpgsqlDataAdapter(cmd, conexion.MiConexion);
            this.miAdapter.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
        }
    }
}