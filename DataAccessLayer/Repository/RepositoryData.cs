using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer.Clases;
using Npgsql;
using DTO;
using DataAccessLayer.Models;

namespace DataAccessLayer.Repository
{
    public class RepositoryDataFiscal
    {
        private Conexion miConexion;

        /// <summary>
        /// Representa una sentenca en sql.
        /// </summary>
        private NpgsqlCommand miComando;

        /// <summary>
        /// Representa una sentencia adapter en posgres sql.
        /// </summary>
        private NpgsqlDataAdapter miAdapter;

        public RepositoryDataFiscal()
        {
            this.miConexion = new Conexion();
        }

        public DataTable TypesPerson()
        {
            try
            {
                DataTable dtPersons = new DataTable();
                string sql = "select * from tipo_persona order by codigo;";
                CargarAdapter(sql);
                miAdapter.Fill(dtPersons);
                return dtPersons;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar los tipos de persona.\n" + ex.Message);
            }
        }

        public DataTable IdDocuments()
        {
            try
            {
                DataTable dtDocuments = new DataTable();
                string sql = "select * from documento_identidad where estado = true order by codigo;";
                CargarAdapter(sql);
                miAdapter.Fill(dtDocuments);
                DataRow select = dtDocuments.NewRow();
                select[0] = "0";
                select[1] = "Seleccione una opción";
                dtDocuments.Rows.InsertAt(select, 0);
                return dtDocuments;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar los tipos de documentos.\n" + ex.Message);
            }
        }

        public DataTable FiscalRegimen()
        {
            try
            {
                DataTable dtRegimen = new DataTable();
                string sql = "select * from regimen order by idregimen;";
                CargarAdapter(sql);
                miAdapter.Fill(dtRegimen);
                return dtRegimen;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar los tipos de regimen fiscal.\n" + ex.Message);
            }
        }

        public DataTable InfoTributary()
        {
            try
            {
                DataTable dtTributary = new DataTable();
                string sql =
                    "select codigo, descripcion, codigo || '  ' || descripcion as display from responsabilidad_fiscal where estado = true order by codigo;";
                    //"select codigo, descripcion as nombre, codigo || '_' || descripcion as descripcion from responsabilidad_fiscal where estado = true order by codigo;";
                CargarAdapter(sql);
                miAdapter.Fill(dtTributary);
                return dtTributary;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar los tipos de responsabilidad fiscal.\n" + ex.Message);
            }
        }

        public List<IdentifyTax> IdentifyTaxes()
        {
            try
            {
                var taxes = new List<IdentifyTax>();
                string sql = "select * from impuestos order by codigo;";
                CargarComando(sql);
                this.miConexion.MiConexion.Open();
                NpgsqlDataReader reader = this.miComando.ExecuteReader();
                while (reader.Read())
                {
                    taxes.Add(new IdentifyTax
                    {
                        Code = reader.GetString(0),
                        Name = reader.GetString(1),
                        Descripcion = reader.GetString(2), // + " " + reader.GetString(1),
                        IsTax = reader.GetBoolean(3),
                        Percent = reader.GetBoolean(4),
                        Estate = reader.GetBoolean(5)
                    });
                }
                this.miConexion.MiConexion.Close();
                return taxes;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar los tipos de impuestos.\n" + ex.Message);
            }
            finally { this.miConexion.MiConexion.Close(); }
        }

        /*
        public DataTable TributaryRegimen(bool estado)
        {
            try
            {
                DataTable dtTributary = new DataTable();
                string sql =
                    "select * from regimen_tributario where estado = @estado order by codigo;";
                miAdapter.SelectCommand.Parameters.AddWithValue("estado", estado);
                CargarAdapter(sql);
                miAdapter.Fill(dtTributary);
                return dtTributary;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar los tipos de persona.\n" + ex.Message);
            }
        }
        */

        public DataTable TarifasTax(string code)
        {
            try
            {
                DataTable dtTarifas = new DataTable();
                string sql = 
                    "select tarifa, tarifa || ' ' || concepto as concepto from tarifa_impuesto where codigo_impuesto = '" + code + "' order by id_order;";
                //miAdapter.SelectCommand.Parameters.AddWithValue("code_", code);
                CargarAdapter(sql);
                miAdapter.Fill(dtTarifas);
                return dtTarifas;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar los tipos de documento electronico.\n" + ex.Message);
            }
        }


        public DataTable TypesElectronicDocument()
        {
            try
            {
                DataTable dtDocument = new DataTable();
                string sql = "select * from tipo_documento_electronico;";
                CargarAdapter(sql);
                miAdapter.Fill(dtDocument);
                return dtDocument;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar los tipos de documento electronico.\n" + ex.Message);
            }
        }

        public DataTable TypesElectronicInvoic(string typeDoc)
        {
            try
            {
                DataTable dtTypeInvoic = new DataTable();
                string sql = "select * from tipo_factura_electronica where tipo_documento = @type;";
                CargarAdapter(sql);
                miAdapter.SelectCommand.Parameters.AddWithValue("type", typeDoc);
                miAdapter.Fill(dtTypeInvoic);
                return dtTypeInvoic;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar los tipos de factura electronica.\n" + ex.Message);
            }
        }

        public DataTable TypesOperation(string typeOp)
        {
            try
            {
                DataTable dtTypeOp = new DataTable();
                string sql = "select * from tipo_operacion_electronica where tipo_documento = @type order by id;";
                CargarAdapter(sql);
                miAdapter.SelectCommand.Parameters.AddWithValue("type", typeOp);
                miAdapter.Fill(dtTypeOp);
                return dtTypeOp;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar los tipos de operaciones de FE.\n" + ex.Message);
            }
        }

        public DataTable MetodoPago()
        {
            try
            {
                DataTable dtMetodo = new DataTable();
                string sql = "select * from estado where idestado = 1 or idestado = 2 order by idestado;";
                CargarAdapter(sql);
                miAdapter.Fill(dtMetodo);
                return dtMetodo;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar los metodos de pago.\n" + ex.Message);
            }
        }

        public DataTable MedioPago()
        {
            try
            {
                DataTable dtMedio = new DataTable();
                string sql = "select * from medio_pago where estado = true;";
                CargarAdapter(sql);
                miAdapter.Fill(dtMedio);
                return dtMedio;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al cargar los medios de pago.\n" + ex.Message);
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
            miAdapter.SelectCommand.CommandType = CommandType.Text;
        }
    }
}