using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO.Clases;
using NpgsqlTypes;
using Npgsql;
using System.Data;

namespace DataAccessLayer.Clases
{
    public class DaoPunto
    {
        private Conexion miConexion;

        private NpgsqlCommand miComando;
    
        private string sqlModificarPunto = "modifica_punto";

        private string sqlCargar = "listado_valor_punto";

        public DaoPunto()
        {
            this.miConexion = new Conexion();
        }

        public Punto CargaPunto()
        {
            try
            {
                Punto mipunto = new Punto();
                this.CargarComando("listado_valor_punto");
                //this.miComando.Parameters.AddWithValue("", mipunto.IdPuntos);
                this.miConexion.MiConexion.Open();
                NpgsqlDataReader myreader = miComando.ExecuteReader();
                while (myreader.Read())
                {
                    mipunto.IdPuntos = myreader.GetInt32(0);
                    mipunto.ValorVentaMinPunto = myreader.GetInt32(1);
                    mipunto.NumeroPuntos = myreader.GetDouble(2);
                    mipunto.ValorPunto = myreader.GetDouble(3);
                    mipunto.EstadoPunto = myreader.GetBoolean(4);
                }
                this.miConexion.MiConexion.Close();
                this.miComando.Dispose();
                return mipunto;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un erro al consultar el registro de punto.\n" + ex.Message);
            }
            finally { this.miConexion.MiConexion.Close(); }
        }
        
        public void ModificaPunto(Punto punto)
        {
            try
            {
                this.CargarComando("modifica_punto");
                this.miComando.Parameters.AddWithValue("", punto.IdPuntos);
                this.miComando.Parameters.AddWithValue("", punto.ValorVentaMinPunto);
                this.miComando.Parameters.AddWithValue("", punto.NumeroPuntos);
                this.miComando.Parameters.AddWithValue("", punto.ValorPunto);
                this.miComando.Parameters.AddWithValue("", punto.EstadoPunto);
                this.miConexion.MiConexion.Open();
                this.miComando.ExecuteNonQuery();
                this.miConexion.MiConexion.Close();
                this.miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al editar los datso.\n" + ex.Message);
            }
            finally { this.miConexion.MiConexion.Close(); }
        }

        /// <summary>
        /// Inicializa una nueva instancia de NpgsqlCommand de tipo StoredProcedure.
        /// </summary>
        /// <param name="cmd">Comando a ejecutar.</param>
        private void CargarComando(string cmd)
        {
            this.miComando = new NpgsqlCommand();
            this.miComando.Connection = this.miConexion.MiConexion;
            this.miComando.CommandType = CommandType.StoredProcedure;
            this.miComando.CommandText = cmd;
        }
    }
}