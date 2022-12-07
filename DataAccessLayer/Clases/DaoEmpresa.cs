using System;
using System.Data;
using DTO.Clases;
using Npgsql;

namespace DataAccessLayer.Clases
{
    /// <summary>
    /// Representa una clase para la pertinencia de datos de Empresa.
    /// </summary>
    public class DaoEmpresa
    {
        #region Transacción a base de datos.

        /// <summary>
        /// Representa un objeto con acceso a la conexión de base de datos Postgresql.
        /// </summary>
        private Conexion miConexion;

        /// <summary>
        /// Representa un comando de ejecucion de sentencias SQL a PostgreSQL.
        /// </summary>
        private NpgsqlCommand miComando;

        /// <summary>
        /// Objeto que representa un adaptador de comandos SQl.
        /// </summary>
        private NpgsqlDataAdapter miAdapter;

        /// <summary>
        /// Representa un objeto de transaccion de daoCuadre a PostgresSQL.
        /// </summary>
        private DaoCuenta miDaoCuenta;

        #endregion

        #region Funciones

        /// <summary>
        /// Representa la función insertar_empresa;
        /// </summary>
        private string InsertarEmpresa_ = "insertar_empresa";

        /// <summary>
        /// Representa la función obtiene_empresa.
        /// </summary>
        private string ConsultaEmpresa = "obtiene_empresa";

        /// <summary>
        /// Representa la función: print_empresa.
        /// </summary>
        private string PrintEmpresa_ = "print_empresa";

        /// <summary>
        /// Representa la funcion existe_empresa_nit.
        /// </summary>
        private string ExisteNit_ = "existe_empresa_nit";

        /// <summary>
        /// Representa la función editar_empresa.
        /// </summary>
        private string EditaEmpresa = "editar_empresa";

        #endregion

        #region Mensajes

        /// <summary>
        /// Representa el texto: Ocurrió un error al cargar la Empresa.
        /// </summary>
        private string ErrorObtener = "Ocurrió un error al cargar la Empresa.\n";

        #endregion

        /// <summary>
        /// Inicializa una nueva instancia de DaoEmpresa.
        /// </summary>
        public DaoEmpresa()
        {
            this.miConexion = new Conexion();
        }

        /// <summary>
        /// Insertar empresa a la base de datos
        /// </summary>
        /// <param name="empresa">objeto empresa</param>
        public void InsertarEmpresa(Empresa empresa)
        {
            var cuenta = new DaoCuenta();
            try
            {
                CargarComando(InsertarEmpresa_);
                miComando.Parameters.AddWithValue("nitempresa", empresa.NitEmpresa);
                miComando.Parameters.AddWithValue("regimen", empresa.Regimen.IdRegimen);
                miComando.Parameters.AddWithValue("nombrecomercial", empresa.NombreComercialEmpresa);
                miComando.Parameters.AddWithValue("nombrejuridico", empresa.NombreJuridicoEmpresa);
                miComando.Parameters.AddWithValue("telefono", empresa.TelefonoEmpresa);
                miComando.Parameters.AddWithValue("celular", empresa.CelularEmpresa);
                miComando.Parameters.AddWithValue("fax", empresa.FaxEmpresa);
                miComando.Parameters.AddWithValue("email", empresa.EmailEmpresa);
                miComando.Parameters.AddWithValue("paginaweb", empresa.PagWebEmpresa);
                miComando.Parameters.AddWithValue("representante", empresa.RepresentanteLegalEmpresa);
                miComando.Parameters.AddWithValue("departamnto", empresa.Departamento.IdDepartamento);
                miComando.Parameters.AddWithValue("ciudad", empresa.Ciudad.IdCiudad);
                miComando.Parameters.AddWithValue("direccion", empresa.DireccionEmpresa);
                miComando.Parameters.AddWithValue("estado", empresa.EstadoEmpresa);
                miComando.Parameters.AddWithValue("descripcion", empresa.Descripcion);
                miComando.Parameters.AddWithValue("recauda", empresa.RecaudaIVA);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();

                /*foreach (Cuenta miC in empresa.cuenta)
                {
                    miC.NitEmpresa = empresa.NitEmpresa;
                    cuenta.InsertarCuenta(miC);
                }*/
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar Empresa" + ex.Message);
            }
            finally
            { miConexion.MiConexion.Close(); }
        }

        /// <summary>
        /// edita empresa
        /// </summary>
        /// <param name="empresa">empresa a editar</param>
        public void EditarEmpresa(Empresa empresa)
        {
            var cuenta = new DaoCuenta();
            try
            {
                CargarComando(EditaEmpresa);
                miComando.Parameters.AddWithValue("nitempresa", empresa.NitEmpresa);
                miComando.Parameters.AddWithValue("nitEditado", empresa.NitEditado);
                miComando.Parameters.AddWithValue("regimen", empresa.Regimen.IdRegimen);
                miComando.Parameters.AddWithValue("nombrecomercial", empresa.NombreComercialEmpresa);
                miComando.Parameters.AddWithValue("nombrejuridico", empresa.NombreJuridicoEmpresa);
                miComando.Parameters.AddWithValue("telefono", empresa.TelefonoEmpresa);
                miComando.Parameters.AddWithValue("celular", empresa.CelularEmpresa);
                miComando.Parameters.AddWithValue("fax", empresa.FaxEmpresa);
                miComando.Parameters.AddWithValue("email", empresa.EmailEmpresa);
                miComando.Parameters.AddWithValue("paginaweb", empresa.PagWebEmpresa);
                miComando.Parameters.AddWithValue("representante", empresa.RepresentanteLegalEmpresa);
                miComando.Parameters.AddWithValue("departamnto", empresa.Departamento.IdDepartamento);
                miComando.Parameters.AddWithValue("ciudad", empresa.Ciudad.IdCiudad);
                miComando.Parameters.AddWithValue("direccion", empresa.DireccionEmpresa);
                miComando.Parameters.AddWithValue("estado", empresa.EstadoEmpresa);
                miComando.Parameters.AddWithValue("descripcion", empresa.Descripcion);
                miComando.Parameters.AddWithValue("recauda", empresa.RecaudaIVA);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();

                var cuentas = cuenta.ListaCuetaEmpresa(empresa.NitEmpresa);
                //Actualizo el nit de las cuentas de la empresa
                foreach (var c in cuentas)
                {
                    c.NitEmpresa = empresa.NitEditado;
                    cuenta.EditarCuenta(c);
                }
                foreach (var ce in empresa.cuenta)//cuentas empresa
                {
                    var ex = false;
                    foreach (var c in cuentas)//cuentas db
                    {
                        if (ce.IdCuenta.Equals(c.IdCuenta))
                        {
                            ex = true;
                            break;
                        }
                        else
                        {
                            ex = false;
                        }
                    }
                    if (!ex)
                    {
                        ce.NitEmpresa = empresa.NitEmpresa;
                        cuenta.InsertarCuenta(ce);
                    }
                }
                foreach (var ce in empresa.cuenta)
                {
                    ce.NitEmpresa = empresa.NitEmpresa;
                    cuenta.EditarCuenta(ce);
                }

                /*foreach (Cuenta miC in empresa.cuenta)
                {

                    miC.NitEmpresa = empresa.NitEmpresa;
                    cuenta.InsertarCuenta(miC);
                }*/
            }
            catch (Exception ex)
            {
                throw new Exception("Error al editar la empresa." + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Consulta si existe nit en la base de datos.
        /// </summary>
        /// <param name="nit">Nit a consultar</param>
        /// <returns>true o false</returns>
        public bool ExisteNit(string nit)
        {
            try
            {
                CargarComando(ExisteNit_);
                miComando.Parameters.AddWithValue("nit", nit);
                miConexion.MiConexion.Open();
                var resultado = Convert.ToBoolean(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar en nit" + ex.Message);
            }
            finally
            { miConexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Obtiene los datos del registro de la Empresa.
        /// </summary>
        /// <returns></returns>
        public Empresa ObtenerEmpresa()
        {
            var empresa = new Empresa();
            var daoCuenta = new DaoCuenta();
            try
            {
                CargarComando(ConsultaEmpresa);
                miConexion.MiConexion.Open();
                NpgsqlDataReader miReader = miComando.ExecuteReader();
                while (miReader.Read())
                {
                    empresa.NitEmpresa = miReader.GetString(0);
                    empresa.Regimen.IdRegimen = miReader.GetInt32(1);
                    empresa.Regimen.NombreRegimen = miReader.GetString(2);
                    empresa.NombreComercialEmpresa = miReader.GetString(3);
                    empresa.NombreJuridicoEmpresa = miReader.GetString(4);
                    empresa.TelefonoEmpresa = miReader.GetString(5);
                    empresa.CelularEmpresa = miReader.GetString(6);
                    empresa.FaxEmpresa = miReader.GetString(7);
                    empresa.EmailEmpresa = miReader.GetString(8);
                    empresa.PagWebEmpresa = miReader.GetString(9);
                    empresa.RepresentanteLegalEmpresa = miReader.GetString(10);
                    empresa.Departamento.NombreDepartamento = miReader.GetString(11);
                    empresa.Ciudad.NombreCiudad = miReader.GetString(12);
                    empresa.DireccionEmpresa = miReader.GetString(13);
                    empresa.EstadoEmpresa = miReader.GetBoolean(14);
                    empresa.Descripcion = miReader.GetString(15);
                    empresa.Departamento.IdDepartamento = miReader.GetInt32(16);
                    empresa.Ciudad.IdCiudad = miReader.GetInt32(17);
                    empresa.RecaudaIVA = miReader.GetBoolean(18);
                }
                miConexion.MiConexion.Close();
                miComando.Dispose();
                empresa.cuenta = daoCuenta.ListaCuetaEmpresa(empresa.NitEmpresa);
                return empresa;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorObtener + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Obtiene los datos de la Empresa para su impresión.
        /// </summary>
        /// <returns></returns>
        public DataSet PrintEmpresa()
        {
            var dataSet = new DataSet();
            try
            {
                CargarAdapter(PrintEmpresa_);
                miAdapter.Fill(dataSet, "Empresa");
                return dataSet;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorObtener + ex.Message);
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
        /// Inicializa una nueva instancia de NpgsqlDataAdapter de tipo StoredProcedure.
        /// </summary>
        /// <param name="cmd">Comando o Procedimiento a ejecutar.</param>
        private void CargarAdapter(string cmd)
        {
            miAdapter = new NpgsqlDataAdapter(cmd, miConexion.MiConexion);
            miAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        }
    }
}