using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DTO.Clases;
using Npgsql;

namespace DataAccessLayer.Clases
{
    public  class DaoCaracteresEscape
    {
        /// <summary>
        /// Representa una conexion al servidor de Base de Datos PostgreSQL.
        /// </summary>
        private Conexion miConexion;

        /// <summary>
        /// Representa un Comando o StoredProcedure en SQL para ser ejecutado en PostgreSQL.
        /// </summary>
        private NpgsqlCommand miComando;

        public DaoCaracteresEscape()
        {
            this.miConexion = new Conexion();
        }



        public CaracteresEscape CaracteresPredeterminados()
        {
            try
            {
                this.CargarComando("caracteres_escape_predeterminado");
                this.miConexion.MiConexion.Open();
                var caracteres = new CaracteresEscape();
                NpgsqlDataReader reader = this.miComando.ExecuteReader();
                while (reader.Read())
                {
                    caracteres.Id = reader.GetInt32(0);
                    caracteres.Predeterminado = reader.GetBoolean(1);
                    caracteres.Numero = reader.GetInt32(2);
                    caracteres.Caracter_1 = reader.GetString(3);
                    caracteres.Caracter_2 = reader.GetString(4);
                    caracteres.Caracter_3 = reader.GetString(5);
                    caracteres.Caracter_4 = reader.GetString(6);
                    caracteres.Caracter_5 = reader.GetString(7);
                    caracteres.Caracter_6 = reader.GetString(8);
                }
                this.miConexion.MiConexion.Close();
                this.miComando.Dispose();
                return caracteres;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los caracteres.\n" + ex.Message);
            }
            finally { this.miConexion.MiConexion.Close(); }
        }

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
    }
}