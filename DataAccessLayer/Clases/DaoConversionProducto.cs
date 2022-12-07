using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO.Clases;
using Npgsql;

namespace DataAccessLayer.Clases
{
    public class DaoConversionProducto
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


        public DaoConversionProducto()
        {
            this.miConexion = new Conexion();
        }

        public bool ExisteConversion(string codigo)
        {
            try
            {
                CargarComando("existe_conversion");
                this.miComando.Parameters.AddWithValue("", codigo);
                this.miConexion.MiConexion.Open();
                var existe = Convert.ToBoolean(this.miComando.ExecuteScalar());
                this.miConexion.MiConexion.Close();
                this.miComando.Dispose();
                return existe;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al verificar la conversión del producto.\n" + ex.Message);
            }
            finally { this.miConexion.MiConexion.Close(); }
        }



        public void IngresarConversion(Conversion conversion)
        {
            try
            {
                CargarComando("insertar_conversion_producto");
                this.miComando.Parameters.AddWithValue("", conversion.CodigoProducto);
                this.miComando.Parameters.AddWithValue("", conversion.Cantidad);
                this.miConexion.MiConexion.Open();
                var id = Convert.ToInt32(this.miComando.ExecuteScalar());
                this.miConexion.MiConexion.Close();
                this.miComando.Dispose();
                foreach (var detalle in conversion.Detalles)
                {
                    detalle.IdConversion = id;
                    IngresarDetalleConversion(detalle);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al ingresar la conversión.\n" + ex.Message);
            }
            finally { this.miConexion.MiConexion.Close(); }
        }

        public void IngresarDetalleConversion(DetalleConversion detalle)
        {
            try
            {
                CargarComando("insertar_detalle_conversion_producto");
                this.miComando.Parameters.AddWithValue("", detalle.IdConversion);
                this.miComando.Parameters.AddWithValue("", detalle.CodigoProducto);
                this.miComando.Parameters.AddWithValue("", detalle.Cantidad);
                this.miConexion.MiConexion.Open();
                this.miComando.ExecuteNonQuery();
                this.miConexion.MiConexion.Close();
                this.miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al ingresar los detalles de la conversión.\n" + ex.Message);
            }
            finally { this.miConexion.MiConexion.Close(); }
        }

        public Conversion Conversion(string codigo)
        {
            try
            {
                var conversion = new Conversion();
                this.CargarComando("conversion_producto");
                this.miComando.Parameters.AddWithValue("", codigo);
                this.miConexion.MiConexion.Open();
                NpgsqlDataReader reader = this.miComando.ExecuteReader();
                while (reader.Read())
                {
                    conversion.Id = reader.GetInt32(0);
                    conversion.CodigoProducto = reader.GetString(1);
                    conversion.Cantidad = reader.GetDouble(4);
                }
                this.miConexion.MiConexion.Close();
                this.miComando.Dispose();
                return conversion;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar la conversión.\n" + ex.Message);
            }
            finally { this.miConexion.MiConexion.Close(); }
        }

        public DataTable Conversiones()
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("conversion_producto");
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar las conversiones.\n" + ex.Message);
            }
        }

        public DataTable Conversiones(string codigo)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("conversion_producto");
                miAdapter.SelectCommand.Parameters.AddWithValue("", codigo);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar las conversiones.\n" + ex.Message);
            }
        }

        public DataTable DetallesConversion(int idConversion)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("detalles_conversion_producto");
                miAdapter.SelectCommand.Parameters.AddWithValue("", idConversion);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los detalles de las conversiones.\n" + ex.Message);
            }
        }



        public DataTable DetalleConversion(string productoConversion)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("detalles_conversion_producto");
                miAdapter.SelectCommand.Parameters.AddWithValue("", productoConversion);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los detalles de conversión.\n" + ex.Message);
            }
        }


        public DataTable ConversionDetalle(string productoDetalle)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("conversion_producto_a_detalle");
                miAdapter.SelectCommand.Parameters.AddWithValue("", productoDetalle);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el producto de conversión.\n" + ex.Message);
            }
        }


        public void EliminarConversion(int id)
        {
            try
            {
                this.CargarComando("eliminar_conversion");
                this.miComando.Parameters.AddWithValue("", id);
                this.miConexion.MiConexion.Open();
                this.miComando.ExecuteNonQuery();
                this.miConexion.MiConexion.Close();
                this.miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al eliminar el registro de conversión.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public void EliminarDetalle(int id)
        {
            try
            {
                this.CargarComando("eliminar_detalle_conversion");
                this.miComando.Parameters.AddWithValue("", id);
                this.miConexion.MiConexion.Open();
                this.miComando.ExecuteNonQuery();
                this.miConexion.MiConexion.Close();
                this.miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al eliminar el producto de conversión.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }



        // codigo para la programacion de productos fabricados (recetas.)

        public void InsertarProductoFabricado(string prodFabricado, string prodProceso, double cantidad)
        {
            try
            {
                CargarComando("insertar_producto_fabricado");
                miComando.Parameters.AddWithValue("", prodFabricado);
                miComando.Parameters.AddWithValue("", prodProceso);
                miComando.Parameters.AddWithValue("", cantidad);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al ingresar la configuración.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable ProductosFabricados(int idTipoInventario)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("producto_presentacion");
                miAdapter.SelectCommand.Parameters.AddWithValue("", idTipoInventario);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar los productos.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable ProductosReceta(string codigo)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("productos_receta");
                miAdapter.SelectCommand.Parameters.AddWithValue("", codigo);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar los productos de receta.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        

        public void EliminarProductoReceta(int id)
        {
            try
            {
                this.CargarComandoText("delete from producto_fabricado where id = @id;");
                this.miComando.Parameters.AddWithValue("id", id);
                this.miConexion.MiConexion.Open();
                this.miComando.ExecuteNonQuery();
                this.miConexion.MiConexion.Close();
                this.miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al eliminar el producto de conversión.\n" + ex.Message);
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

        private void CargarComandoText(string cmd)
        {
            miComando = new NpgsqlCommand();
            miComando.Connection = miConexion.MiConexion;
            miComando.CommandType = CommandType.Text;
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