using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO.Clases;
using Npgsql;

namespace DataAccessLayer.Clases
{
    public class DaoBanco
    {
        /// <summary>
        /// Representa el objeto de conexión.
        /// </summary>
        private Conexion miConexion;

        /// <summary>
        /// Representa una sentenca en sql.
        /// </summary>
        private NpgsqlCommand miComando;

        private DaoPuc miDaoPuc;

        public DaoBanco()
        {
            this.miConexion = new Conexion();
            this.miDaoPuc = new DaoPuc();
        }

        public void Ingresar(Banco banco)
        {
            try
            {
                banco.Cuenta.Id = miDaoPuc.IngresarSubCuenta(
                    new SubCuentaPuc
                        {
                            IdCuenta = banco.Cuenta.IdCuenta,
                            Numero = banco.Cuenta.Numero,
                            Nombre = banco.Cuenta.Nombre
                        });

                CargarComando("insertar_banco");
                miComando.Parameters.AddWithValue("", banco.IdTipo);
                miComando.Parameters.AddWithValue("", banco.Cuenta.Id);
                miComando.Parameters.AddWithValue("", banco.Numero);
                miComando.Parameters.AddWithValue("", banco.Entidad);
                miComando.Parameters.AddWithValue("", banco.Titular);
                miComando.Parameters.AddWithValue("", banco.Sucursal);
                miComando.Parameters.AddWithValue("", banco.Direccion);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al ingresar el banco.\n" + ex.Message);
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
    }
}