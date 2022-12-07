using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Npgsql;
using DTO.Clases;

namespace DataAccessLayer.Clases
{
    public class DaoUtilidades
    {
        /// <summary>
        /// Representa una sentencia sql.
        /// </summary>
        private NpgsqlCommand miComando;

        /// <summary>
        /// Representa un adapter postgres sql.
        /// </summary>
        private NpgsqlDataAdapter miAdapter;

        /// <summary>
        /// Objeto de conexion sql
        /// </summary>
        private Conexion miConexion;


        public DaoUtilidades()
        {
        }

        public List<InventarioFisico> InventariosFisico(string dataBase, DateTime fecha)
        {
            try
            {
                this.miConexion = new Conexion(dataBase);

                var lista = new List<InventarioFisico>();
                string sql = "SELECT * FROM inventario_fisico WHERE fecha_inventario_fisico >= '"+fecha.ToShortDateString()+"';";
                this.miComando = new NpgsqlCommand();
                this.miComando.Connection = this.miConexion.MiConexion;
                this.miComando.CommandType = CommandType.Text;
                this.miComando.CommandText = sql;

                this.miConexion.MiConexion.Open();
                NpgsqlDataReader reader = this.miComando.ExecuteReader();
                while (reader.Read())
                {
                    var inventario = new InventarioFisico();
                    //inventario.Id = reader.GetInt32(0);
                    //inventario.Fecha = reader.GetDateTime(1);
                    inventario.CodigoProducto = reader.GetString(2);
                    inventario.IdMedida = reader.GetInt32(3);
                    inventario.IdColor = reader.GetInt32(4);
                    inventario.CantidadFisico = reader.GetDouble(5);
                    inventario.Corte = reader.GetBoolean(6);
                    inventario.Cantidad = reader.GetInt32(7);
                    inventario.Costo = reader.GetDouble(8);
                    lista.Add(inventario);
                }
                this.miConexion.MiConexion.Close();
                this.miComando.Dispose();
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar la consulta.\nDB: " + dataBase + "\n" + ex.Message);
            }
            finally { this.miConexion.MiConexion.Close(); }
        }

        public void ActualizarInventarioFisico(List<InventarioFisico> inventarios, string dataBase)
        {
            try
            {
                this.miConexion = new Conexion(dataBase);
                foreach (var inven in inventarios)
                {
                    var invenFisico = this.RegistroInventarioFisico(inven.CodigoProducto, inven.IdMedida, inven.IdColor);
                    if (invenFisico.Id == 0) // sin registro - hay que insertar
                    {
                        inven.Fecha = DateTime.Now;
                        InsertarInventarioFisico(inven);
                    }
                    else // con registro - hay que editar
                    {
                        invenFisico.CodigoProducto = inven.CodigoProducto;
                        invenFisico.CantidadFisico += inven.CantidadFisico;
                        this.EditarInventarioFisico(invenFisico);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al editar el inventario fisico.\n" + ex.Message);
            }
        }



        private InventarioFisico RegistroInventarioFisico(string codigo, int idMedida, int idColor)
        {
            try
            {
                CargarComando("registro_producto_inventario_fisico");
                miComando.Parameters.AddWithValue("", codigo);
                miComando.Parameters.AddWithValue("", idMedida);
                miComando.Parameters.AddWithValue("", idColor);
                miConexion.MiConexion.Open();
                NpgsqlDataReader miReader = miComando.ExecuteReader();
                var inventario = new InventarioFisico();
                while (miReader.Read())
                {
                    inventario.Id = miReader.GetInt32(0);
                    inventario.Fecha = miReader.GetDateTime(1);
                    inventario.CantidadFisico = miReader.GetDouble(5);
                    inventario.Costo = miReader.GetDouble(8);
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return inventario;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el inventario fisico.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        private void EditarInventarioFisico(InventarioFisico inventario)
        {
            try
            {
                double j = Convert.ToDouble(inventario.CantidadFisico);
                
                string sql =
                "UPDATE inventario_fisico SET cantidad_inventario_fisico = " + inventario.CantidadFisico + 
                " WHERE codigointernoproducto = '" + inventario.CodigoProducto + "';";

                string sql_ = "UPDATE inventario_fisico SET cantidad_inventario_fisico = " + inventario.CantidadFisico.ToString().Replace(',', '.') +
                " WHERE codigointernoproducto = '" + inventario.CodigoProducto + "';";

                this.miComando = new NpgsqlCommand();
                this.miComando.Connection = this.miConexion.MiConexion;
                this.miComando.CommandType = CommandType.Text;
                this.miComando.CommandText = sql_;

                this.miConexion.MiConexion.Open();
                this.miComando.ExecuteNonQuery();
                this.miConexion.MiConexion.Close();
                this.miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al editar el inventario fisico.\n" + ex.Message);
            }
            finally { this.miConexion.MiConexion.Close(); }
        }


        public void InsertarInventarioFisico(InventarioFisico inventario)
        {
            try
            {
                CargarComando("insertar_inventario_fisico");
                miComando.Parameters.AddWithValue("", inventario.Fecha.ToShortDateString());
                miComando.Parameters.AddWithValue("", inventario.CodigoProducto);
                miComando.Parameters.AddWithValue("", inventario.IdMedida);
                miComando.Parameters.AddWithValue("", inventario.IdColor);
                miComando.Parameters.AddWithValue("", inventario.CantidadFisico);
                miComando.Parameters.AddWithValue("", inventario.Corte);
                miComando.Parameters.AddWithValue("", Convert.ToInt32(inventario.Cantidad));
                miComando.Parameters.AddWithValue("", inventario.Costo);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al ingresar el inventario fisico.\n" + ex.Message);
            }
            finally { this.miConexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Inicializa una nueva instancia de NpgsqlCommand de tipo Stored Procedure.
        /// </summary>
        /// <param name="cmd"></param>
        private void CargarComando(string cmd)
        {
            this.miComando = new NpgsqlCommand();
            this.miComando.Connection = this.miConexion.MiConexion;
            this.miComando.CommandType = CommandType.StoredProcedure;
            this.miComando.CommandText = cmd;
        }

        /// <summary>
        /// Inicializa una nueva instancia de NpgsqlDataAdapter de tipo Stored Procedure.
        /// </summary>
        /// <param name="cmd">Sentencia a ejecutar.</param>
        private void CargarAdapter(string cmd)
        {
            miAdapter = new NpgsqlDataAdapter(cmd, miConexion.MiConexion);
            miAdapter.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
        }
    }
}