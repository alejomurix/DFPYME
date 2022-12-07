using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using DTO.Clases;
using System.Collections;
using System.Data;

namespace DataAccessLayer.Clases
{
    /// <summary>
    /// Representa una clase de tranzacion de Base de Datos de Unidad de Medida.
    /// </summary>
    public class DaoUnidadMedida
    {
        /// <summary>
        /// Objeto de conexion a base de datos PostgreSQL
        /// </summary>
        private Conexion miConexion;

        /// <summary>
        /// Representa un objeto de sentencias SQL a PostgreSQL
        /// </summary>
        private NpgsqlCommand miComando;

        /// <summary>
        /// Representa un adaptador de sentencias sql.
        /// </summary>
        private NpgsqlDataAdapter miAdapter;

        /// <summary>
        /// Objeto que implementa una coleccion
        /// </summary>
        private ArrayList miArrayList;

        /// <summary>
        /// Objeto de tranzacion de base de datos de Valores de unidad de medida.
        /// </summary>
        private DaoValorUnidadMedida miDaoValorMedida;

        /// <summary>
        /// Representa la funcion listado_unidad_medida.
        /// </summary>
        private string sqlListado = "listado_unidad_medida";

        /// <summary>
        /// Representa la funcion listado_unidad_medida_notalla.
        /// </summary>
        private string sqlListadoNoTalla = "listado_unidad_medida_notalla";

        /// <summary>
        /// Representa la funcion listado_valor_unidad_medida.
        /// </summary>
        private string sqlListaValorUnidad = "listado_valor_unidad_medida";

        /// <summary>
        /// Representa la funcion Insertar_unidad medida
        /// </summary>
        private string sqlInsertar = "insertar_unidad_medida";

        /// <summary>
        /// Reprsenta la funcion existe_unidad_medida
        /// </summary>
        private string sqlExisteUnidadMedida = "existe_unidad_medida";

        /// <summary>
        /// Representa la funcion modifica_unidad_medida
        /// </summary>
        private string sqlModificaUnidadMedida = "modifica_unidad_medida";

        /// <summary>
        ///Representa la funcion eliminar_unidad_medida .
        /// </summary>
        private string sqlEliminarUnidadMedida = "eliminar_unidad_medida";

        /// <summary>
        /// Inicializa una nueva instacia de la clase DaoUnidadMedida
        /// </summary>
        public DaoUnidadMedida()
        {
            this.miConexion = new Conexion();
            miDaoValorMedida = new DaoValorUnidadMedida();
        }

        /// <summary>
        /// Indica si unidad de medida ya existe.
        /// </summary>
        /// <param name="nombre">Medida a buscar.</param>
        /// <returns></returns>
        public bool ExisteUnidadMedida(string nombre)
        {
            try
            {
                CargarComandoStoredProcedure(sqlExisteUnidadMedida);
                miComando.Parameters.AddWithValue("nombre_unidad_medida", nombre);
                miConexion.MiConexion.Open();
                var resultado = Convert.ToBoolean(miComando.ExecuteScalar());
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception("la unidad de medida ya existe" + ex.Message);
            }
            finally
            {
                miConexion.MiConexion.Close();
            }

        }

        /// <summary>
        /// Ingresa un registro de Unidad de medida con sus valores correspondientes.
        /// </summary>
        /// <param name="unidadMedida">Unidad de medida a ingresar.</param>
        public void InsertarUnidadMedida(UnidadMedida unidadMedida)
        {
            try
            {
                CargarComandoStoredProcedure(sqlInsertar);
                miComando.Parameters.AddWithValue("descripcion", unidadMedida.DescripcionUnidadMedida);
                miConexion.MiConexion.Open();
                var idUnidadMedida = Convert.ToInt32(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                foreach (ValorUnidadMedida v in unidadMedida.ListaValoresUnidaMedida)
                {
                    v.IdUnidadMedida = idUnidadMedida;
                    miDaoValorMedida.InsertarValorUnidadMedida(v);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo ingresar la unidad de  medida" + ex.Message);
            }
        }

        /// <summary>
        /// Metodo modificar unidad de medida
        /// </summary>
        /// <param name="miunidadmedida">Unidad de Medida a modificar</param>
        public void ModificarUnidadMedida(UnidadMedida miunidadmedida)
        {
            try
            {
                CargarComandoStoredProcedure(sqlModificaUnidadMedida);
                miComando.Parameters.AddWithValue("idunidad_medida", miunidadmedida.IdUnidadMedida);
                miComando.Parameters.AddWithValue("descripcion_unidad_medida", miunidadmedida.DescripcionUnidadMedida);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo modificar la unidad de medida" + ex.Message);
            }
            finally
            {
                miConexion.MiConexion.Close();
            }
        }

        /// <summary>
        /// Metodo eliminar unidades demedida.
        /// </summary>
        /// <param name="id">Id de la Medida a eliminar.</param>
        public void EliminarUnidadMedida(int id)
        {
            try
            {
                CargarComandoStoredProcedure(sqlEliminarUnidadMedida);
                miComando.Parameters.AddWithValue("idunidad_medida", id);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                miConexion.MiConexion.Close();
            }
        }

        /// <summary>
        /// Obtiene un listado de las unidades de medida
        /// </summary>
        /// <returns></returns>
        public DataSet ListadoCompleto()
        {
            try
            {
                DataSet miDataSet = new DataSets.DsUnidadMedida();
                miDataSet.EnforceConstraints = false;

                DataTable UnidadMedida = miDataSet.Tables["unidad_medida"];
                DataTable ValorMedida = miDataSet.Tables["valor_unidad_medida"];

                CargaAdapterStoreProcedure(sqlListado);
                miAdapter.Fill(UnidadMedida);

                CargaAdapterStoreProcedure(sqlListaValorUnidad);
                miAdapter.Fill(ValorMedida);

                miAdapter.Fill(miDataSet);
                return miDataSet;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cargar la informacion de las unidades de medida." + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene el  listado de Unidad de Medida en una coleccion
        /// </summary>
        /// <returns></returns>
        public ArrayList ListadoUnidadMedida()
        {
            miArrayList = new ArrayList();
            try
            {
                CargarComandoStoredProcedure(sqlListado);
                miConexion.MiConexion.Open();
                NpgsqlDataReader miReader = miComando.ExecuteReader();
                while (miReader.Read())
                {
                    UnidadMedida unidad = new UnidadMedida();
                    unidad.IdUnidadMedida = miReader.GetInt32(0);
                    unidad.DescripcionUnidadMedida = miReader.GetString(1);
                    miArrayList.Add(unidad);
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return miArrayList;
            }
            catch (Exception ex)
            {
                throw new Exception("El listado de unidades no se pudo cargar. " + ex.Message);
            }
            finally
            {
                miConexion.MiConexion.Close();
            }
        }

        /// <summary>
        /// Obtiene un listado de las medidas sin incluir talla.
        /// </summary>
        /// <returns></returns>
        public ArrayList ListadoUnidadMedidaNoTalla()
        {
            miArrayList = new ArrayList();
            try
            {
                CargarComandoStoredProcedure(sqlListadoNoTalla);
                miConexion.MiConexion.Open();
                NpgsqlDataReader miReader = miComando.ExecuteReader();
                while (miReader.Read())
                {
                    UnidadMedida unidad = new UnidadMedida();
                    unidad.IdUnidadMedida = miReader.GetInt32(0);
                    unidad.DescripcionUnidadMedida = miReader.GetString(1);
                    miArrayList.Add(unidad);
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return miArrayList;
            }
            catch (Exception ex)
            {
                throw new Exception("El listado de unidades no se pudo cargar. " + ex.Message);
            }
            finally
            {
                miConexion.MiConexion.Close();
            }
        }

        /// <summary>
        /// Inicializa una nueva instancia de NpgsqlCommand de tipo Stored Procedure.
        /// </summary>
        /// <param name="cmd">Comando a ejecutar.</param>
        private void CargarComandoStoredProcedure(string cmd)
        {
            miComando = new NpgsqlCommand();
            miComando.Connection = miConexion.MiConexion;
            miComando.CommandType = CommandType.StoredProcedure;
            miComando.CommandText = cmd;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmd"></param>
        public void CargaAdapterStoreProcedure(string cmd)
        {
            miAdapter = new NpgsqlDataAdapter(cmd,this.miConexion.MiConexion);
            miAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        }
    }
}