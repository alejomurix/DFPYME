using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Npgsql;
using Utilities;

namespace DataAccessLayer.Clases
{
    public class DaoConsecutivo
    {
        //private DaoCaja miDaoCaja;

        private DaoDian miDaoDian;

        /// <summary>
        /// Representa el objeto de conexión.
        /// </summary>
        private Conexion miConexion;

        /// <summary>
        /// Representa una sentenca en sql.
        /// </summary>
        private NpgsqlCommand miComando;

        public DaoConsecutivo()
        {
            //this.miDaoCaja = new DaoCaja();
            this.miDaoDian = new DaoDian();
            this.miConexion = new Conexion();
        }

        public string Consecutivo(string nombre)
        {
            try
            {
                CargarComando("recuperar_consecutivo");
                miComando.Parameters.AddWithValue("nombre",  nombre);
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

        public void ActualizarNumeroFacturaDeVenta(int idCaja)
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void ActualizarNumeroFacturaDeVenta(string nameRegDian, string namePrefijo, string nameFactura)
        {
            int idDian = Convert.ToInt32(Consecutivo(nameRegDian));
            var dian = this.miDaoDian.ConsultaDian(idDian);
            var numero = UseObject.SoloNumberIncrement(this.Consecutivo(nameFactura));
            int maxId = this.miDaoDian.MaxId();
           // Int64 rows = this.miDaoDian.CountRows();
            if (Convert.ToInt64(numero) <= dian.RangoFinal)  // numero dentro de este registro de la DIAN. actualizacion normal
            {
                this.ActualizarConsecutivo(nameFactura, numero);
            }
            else  // validacion
            {
                if (dian.Id != maxId)
                {
                    int countId = dian.Id;
                    while (dian.Id != maxId)
                    {
                        //idDian++;
                        //dian = this.miDaoDian.ConsultaDian(idDian);
                        countId++;
                        dian = this.miDaoDian.ConsultaDian(countId);
                        if (dian.Id != 0 && dian.Id != idDian)
                        {
                            break;
                        }
                    }
                    // actualizo en la tabla consecutivo:
                    // IdRegistroDian = dian.Id;
                    this.ActualizarConsecutivo(nameRegDian, dian.Id.ToString());

                    // FacturaPrefijo = dian.SerieInicial;
                    this.ActualizarConsecutivo(namePrefijo, dian.SerieInicial);

                    // Factura        = dian.RangoInicial;
                    this.ActualizarConsecutivo(nameFactura, dian.RangoInicial.ToString());
                }
                else
                {
                    //Realizar pruebas
                    this.ActualizarConsecutivo(nameFactura, numero);
                }


              /*  while (dian.Id == idDian || dian.Id != 0)
                {
                    idDian++;
                    dian = this.miDaoDian.ConsultaDian(idDian);
                }*/
                

            }
        }

        public void ActualizarConsecutivo(string nombre, string numero)
        {
            try
            {
                CargarComando("actualizar_consecutivo");
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

        public void ActualizarConsecutivo(string nombre)
        {
            try
            {
                var consecutivo = Consecutivo(nombre);
                var numero = UseObject.SoloNumberIncrement(consecutivo);
                CargarComando("actualizar_consecutivo");
                miComando.Parameters.AddWithValue("numero", nombre);
                miComando.Parameters.AddWithValue("valor", numero);
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