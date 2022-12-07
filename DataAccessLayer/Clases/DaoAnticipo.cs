using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO.Clases;
using Npgsql;

namespace DataAccessLayer.Clases
{
    public class DaoAnticipo
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

        private DataTable TablaInforme { set; get; }

        public DaoAnticipo()
        {
            this.miConexion = new Conexion();
            CrearTablaInforme();
        }

        public void IngresarAnticipoTercero(Anticipo anticipo)
        {
            try
            {
                CargarComando("insertar_anticipo_prestamo");
                miComando.Parameters.AddWithValue("idcuenta", anticipo.IdCuenta);
                miComando.Parameters.AddWithValue("idtercero", anticipo.TipoBeneficiario);
                miComando.Parameters.AddWithValue("idegreso", anticipo.IdEgreso);
                miComando.Parameters.AddWithValue("fecha", anticipo.Fecha);
                miComando.Parameters.AddWithValue("pago", anticipo.Pago);
                miComando.Parameters.AddWithValue("estado", anticipo.Estado);
                miConexion.MiConexion.Open();
                var id = Convert.ToInt32(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                foreach (ConceptoEgreso concepto in anticipo.Conceptos)
                {
                    concepto.IdCuenta = id;
                    IngresarConceptoAnticipoTerecero(concepto);
                }
                foreach (FormaPago pago in anticipo.Pagos)
                {
                    pago.IdEgreso = id;
                    IngresarPagoAnticipoTercero(pago);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al ingresar el Anticipo de Tercero.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public void IngresarConceptoAnticipoTerecero(ConceptoEgreso concepto)
        {
            try
            {
                CargarComando("insertar_concepto_anticipo_prestamo");
                miComando.Parameters.AddWithValue("idanticipo", concepto.IdCuenta);
                miComando.Parameters.AddWithValue("concepto", concepto.Nombre);
                miComando.Parameters.AddWithValue("valor", concepto.Numero);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al ingresar el Concepto del Anticipo.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public void IngresarPagoAnticipoTercero(FormaPago pago)
        {
            try
            {
                CargarComando("insertar_anticipo_prestamo_forma_pago");
                miComando.Parameters.AddWithValue("idanticipo", pago.IdEgreso);
                miComando.Parameters.AddWithValue("idpago", pago.IdFormaPago);
                miComando.Parameters.AddWithValue("valor", pago.Valor);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al ingresar el Pago del Anticipo.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        // Consultas
        public DataTable AnticiposATercero(int rowBase, int rowMax)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("anticipos_prestamos");
                miAdapter.Fill(rowBase, rowMax, tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los Préstamos/Anticipos.\n" + ex.Message);
            }
        }

        public long GetRowsAnticiposATercero()
        {
            try
            {
                CargarComando("count_anticipos_prestamos");
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el conteo.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable AnticiposSaldo(int rowBase, int rowMax)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("anticipos_prestamos_saldo");
                miAdapter.Fill(rowBase, rowMax, tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los Préstamos/Anticipos.\n" + ex.Message);
            }
        }

        public long GetRowsAnticiposSaldo()
        {
            try
            {
                CargarComando("count_anticipos_prestamos_saldo");
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el conteo.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }


        public DataTable AnticiposATercero(DateTime fecha, int rowBase, int rowMax)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("anticipos_prestamos_fecha");
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.Fill(rowBase, rowMax, tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los Préstamos/Anticipos.\n" + ex.Message);
            }
        }

        public long GetRowsAnticiposATercero(DateTime fecha)
        {
            try
            {
                CargarComando("count_anticipos_prestamos_fecha");
                miComando.Parameters.AddWithValue("fecha", fecha);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el conteo.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable AnticiposATercero(DateTime fecha, DateTime fecha2, int rowBase, int rowMax)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("anticipos_prestamos_periodo");
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha2", fecha2);
                miAdapter.Fill(rowBase, rowMax, tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los Préstamos/Anticipos.\n" + ex.Message);
            }
        }

        public long GetRowsAnticiposATercero(DateTime fecha, DateTime fecha2)
        {
            try
            {
                CargarComando("count_anticipos_prestamos_periodo");
                miComando.Parameters.AddWithValue("fecha", fecha);
                miComando.Parameters.AddWithValue("fecha2", fecha2);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el conteo.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }


        public DataTable AnticiposATercero
            (int idTercero, DateTime fecha, int rowBase, int rowMax)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("anticipos_prestamos");
                miAdapter.SelectCommand.Parameters.AddWithValue("idtercero", idTercero);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.Fill(rowBase, rowMax, tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los Préstamos/Anticipos.\n" + ex.Message);
            }
        }

        public long GetRowsAnticiposATercero(int idTercero, DateTime fecha)
        {
            try
            {
                CargarComando("count_anticipos_prestamos");
                miComando.Parameters.AddWithValue("idtercero", idTercero);
                miComando.Parameters.AddWithValue("fecha", fecha);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el conteo.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable AnticiposATercero
            (int idTercero, DateTime fecha, DateTime fecha2, int rowBase, int rowMax)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("anticipos_prestamos");
                miAdapter.SelectCommand.Parameters.AddWithValue("idtercero", idTercero);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha2", fecha2);
                miAdapter.Fill(rowBase, rowMax, tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los Préstamos/Anticipos.\n" + ex.Message);
            }
        }

        public long GetRowsAnticiposATercero(int idTercero, DateTime fecha, DateTime fecha2)
        {
            try
            {
                CargarComando("count_anticipos_prestamos");
                miComando.Parameters.AddWithValue("idtercero", idTercero);
                miComando.Parameters.AddWithValue("fecha", fecha);
                miComando.Parameters.AddWithValue("fecha2", fecha2);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el conteo.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable AnticiposATerceroCuenta
            (int idCuenta, DateTime fecha, int rowBase, int rowMax)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("anticipos_prestamos_cuenta");
                miAdapter.SelectCommand.Parameters.AddWithValue("idcuenta", idCuenta);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.Fill(rowBase, rowMax, tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los Préstamos/Anticipos.\n" + ex.Message);
            }
        }

        public long GetRowsAnticiposATerceroCuenta(int idTercero, DateTime fecha)
        {
            try
            {
                CargarComando("count_anticipos_prestamos_cuenta");
                miComando.Parameters.AddWithValue("idtercero", idTercero);
                miComando.Parameters.AddWithValue("fecha", fecha);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el conteo.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable AnticiposATerceroCuenta
            (int idCuenta, DateTime fecha, DateTime fecha2, int rowBase, int rowMax)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("anticipos_prestamos_cuenta");
                miAdapter.SelectCommand.Parameters.AddWithValue("idtercero", idCuenta);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha2", fecha2);
                miAdapter.Fill(rowBase, rowMax, tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los Préstamos/Anticipos.\n" + ex.Message);
            }
        }

        public long GetRowsAnticiposATerceroCuenta(int idCuenta, DateTime fecha, DateTime fecha2)
        {
            try
            {
                CargarComando("count_anticipos_prestamos_cuenta");
                miComando.Parameters.AddWithValue("idtercero", idCuenta);
                miComando.Parameters.AddWithValue("fecha", fecha);
                miComando.Parameters.AddWithValue("fecha2", fecha2);
                miConexion.MiConexion.Open();
                var rows = Convert.ToInt64(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el conteo.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }


        public int SaldoAnticipos()
        {
            try
            {
                CargarComando("saldo_anticipos");
                miConexion.MiConexion.Open();
                int saldo = Convert.ToInt32(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return saldo;
            }
            catch(InvalidCastException)
            {
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el total del saldo.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public int SaldoAnticipos(DateTime fecha)
        {
            try
            {
                CargarComando("saldo_anticipos");
                miComando.Parameters.AddWithValue("", fecha);
                miConexion.MiConexion.Open();
                int saldo = Convert.ToInt32(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return saldo;
            }
            catch (InvalidCastException)
            {
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el total del saldo.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public int SaldoAnticipos(DateTime fecha, DateTime fecha2)
        {
            try
            {
                CargarComando("saldo_anticipos");
                miComando.Parameters.AddWithValue("", fecha);
                miComando.Parameters.AddWithValue("", fecha2);
                miConexion.MiConexion.Open();
                int saldo = Convert.ToInt32(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return saldo;
            }
            catch (InvalidCastException)
            {
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el total del saldo.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public int SaldoAnticipos(int idTercero, DateTime fecha)
        {
            try
            {
                CargarComando("saldo_anticipos");
                miComando.Parameters.AddWithValue("", idTercero);
                miComando.Parameters.AddWithValue("", fecha);
                miConexion.MiConexion.Open();
                int saldo = Convert.ToInt32(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return saldo;
            }
            catch (InvalidCastException)
            {
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el total del saldo.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public int SaldoAnticipos(int idTercero, DateTime fecha, DateTime fecha2)
        {
            try
            {
                CargarComando("saldo_anticipos");
                miComando.Parameters.AddWithValue("", idTercero);
                miComando.Parameters.AddWithValue("", fecha);
                miComando.Parameters.AddWithValue("", fecha2);
                miConexion.MiConexion.Open();
                int saldo = Convert.ToInt32(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                return saldo;
            }
            catch (InvalidCastException)
            {
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar el total del saldo.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }


        
        /// <summary>
        /// Consulta los prestamos/anticipos de un Tercero y que aun no se han saldado.
        /// </summary>
        /// <param name="idCuenta">Id de la cuenta a consultar.</param>
        /// <param name="idTercero">Id del tercero a consultar.</param>
        /// <returns></returns>
        public DataTable AnticiposATerceroNoPagos(int idCuenta, int idTercero)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("anticipos_prestamos_no_pagos");
                miAdapter.SelectCommand.Parameters.AddWithValue("idCuenta", idCuenta);
                miAdapter.SelectCommand.Parameters.AddWithValue("idTercero", idTercero);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los anticipos.\n" + ex.Message);
            }
        }

        public DataTable AnticiposATerceroNoPagos(string nit)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("anticipos_prestamos_no_pagos");
                miAdapter.SelectCommand.Parameters.AddWithValue("", nit);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los anticipos.\n" + ex.Message);
            }
        }

        // Formas de Pago de Préstamos y Anticipos.
        public DataTable PagosAnticiposTercero(int idAnticipo)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("formas_pago_anticipo");
                miAdapter.SelectCommand.Parameters.AddWithValue("idAnticipo", idAnticipo);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar las Formas de Pago.\n" + ex.Message);
            }
        }

        // Funciones para la impresion del informe
        public DataTable AnticiposATercero()
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("anticipos_prestamos_saldo");
                miAdapter.Fill(tabla);

                this.TablaInforme.Rows.Clear();
                foreach (DataRow rRow in tabla.Rows)
                {
                    var iRow = this.TablaInforme.NewRow();
                    iRow["Fecha"] = rRow["fecha"];
                    iRow["NoEgreso"] = rRow["numero"];
                    iRow["Cuenta"] = rRow["nombre"];
                    iRow["Nit"] = rRow["nit"];
                    iRow["Tercero"] = rRow["tercero"];
                    iRow["Concepto"] = rRow["concepto"];
                    iRow["Valor"] = rRow["valor"];

                    iRow["Abono"] = PagosAnticipo(Convert.ToInt32(rRow["id"])).AsEnumerable().
                        Where(p => p.Field<int>("idconcepto").Equals(1)).Sum(s => s.Field<int>("valor"));
                    iRow["Cruce"] = PagosAnticipo(Convert.ToInt32(rRow["id"])).AsEnumerable().
                        Where(p => p.Field<int>("idconcepto").Equals(2)).Sum(s => s.Field<int>("valor"));

                    iRow["Abono"] = Convert.ToInt32(iRow["Abono"]) + Convert.ToInt32(iRow["Cruce"]);
                    iRow["Saldo"] = Convert.ToInt32(iRow["Valor"]) - Convert.ToInt32(iRow["Abono"]);// - Convert.ToInt32(iRow["Cruce"]);
                    this.TablaInforme.Rows.Add(iRow);
                }
                tabla.Rows.Clear();
                tabla = null;
                return this.TablaInforme;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los Préstamos/Anticipos.\n" + ex.Message);
            }
        }

        public DataTable AnticiposATercero(bool abonoMasCruce)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("anticipos_prestamos_saldo");
                miAdapter.Fill(tabla);
                return CruzarDatos(tabla, abonoMasCruce);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los Préstamos/Anticipos.\n" + ex.Message);
            }
        }
        //
        public DataTable AnticiposATercero(DateTime fecha, bool abonoMasCruce)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("anticipos_prestamos_saldo_fecha");
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.Fill(tabla);
                return CruzarDatos(tabla, abonoMasCruce);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los Préstamos/Anticipos.\n" + ex.Message);
            }
        }

        public DataTable AnticiposATercero(DateTime fecha, DateTime fecha2, bool abonoMasCruce)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("anticipos_prestamos_saldo_periodo");
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha2", fecha2);
                miAdapter.Fill(tabla);
                return CruzarDatos(tabla, abonoMasCruce);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los Préstamos/Anticipos.\n" + ex.Message);
            }
        }

        public DataTable AnticiposATercero_(int idTercero, DateTime fecha, bool abonoMasCruce)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("anticipos_prestamos_saldo_tercero");
                miAdapter.SelectCommand.Parameters.AddWithValue("idtercero", idTercero);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.Fill(tabla);
                return CruzarDatos(tabla, abonoMasCruce);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los Préstamos/Anticipos.\n" + ex.Message);
            }
        }

        public DataTable AnticiposATercero_(int idTercero, DateTime fecha, DateTime fecha2, bool abonoMasCruce)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("anticipos_prestamos_saldo_tercero");
                miAdapter.SelectCommand.Parameters.AddWithValue("idtercero", idTercero);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha2", fecha2);
                miAdapter.Fill(tabla);
                return CruzarDatos(tabla, abonoMasCruce);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los Préstamos/Anticipos.\n" + ex.Message);
            }
        }

        public DataTable AnticiposATercero(int idCuenta, DateTime fecha, bool abonoMasCruce)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("anticipos_prestamos_saldo");
                miAdapter.SelectCommand.Parameters.AddWithValue("idcuenta", idCuenta);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.Fill(tabla);
                return CruzarDatos(tabla, abonoMasCruce);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los Préstamos/Anticipos.\n" + ex.Message);
            }
        }

        public DataTable AnticiposATercero
            (int idCuenta, DateTime fecha, DateTime fecha2, bool abonoMasCruce)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("anticipos_prestamos_saldo");
                miAdapter.SelectCommand.Parameters.AddWithValue("idcuenta", idCuenta);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha", fecha);
                miAdapter.SelectCommand.Parameters.AddWithValue("fecha2", fecha2);
                miAdapter.Fill(tabla);
                return CruzarDatos(tabla, abonoMasCruce);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los Préstamos/Anticipos.\n" + ex.Message);
            }
        }





        private DataTable CruzarDatos(DataTable tabla, bool abonoMasCruce)
        {
            //this.TablaInforme.Rows.Clear();
            CrearTablaInforme();
            foreach (DataRow rRow in tabla.Rows)
            {
                var iRow = this.TablaInforme.NewRow();
                iRow["Fecha"] = rRow["fecha"];
                iRow["NoEgreso"] = rRow["numero"];
                iRow["Cuenta"] = rRow["nombre"];
                iRow["Nit"] = rRow["nit"];
                iRow["Tercero"] = rRow["tercero"];
                iRow["Concepto"] = rRow["concepto"];
                iRow["Valor"] = rRow["valor"];

                iRow["Abono"] = PagosAnticipo(Convert.ToInt32(rRow["id"])).AsEnumerable().
                    Where(p => p.Field<int>("idconcepto").Equals(1)).Sum(s => s.Field<int>("valor"));
                iRow["Cruce"] = PagosAnticipo(Convert.ToInt32(rRow["id"])).AsEnumerable().
                    Where(p => p.Field<int>("idconcepto").Equals(2)).Sum(s => s.Field<int>("valor"));
                if (abonoMasCruce)
                {
                    iRow["Abono"] = Convert.ToInt32(iRow["Abono"]) + Convert.ToInt32(iRow["Cruce"]);
                    iRow["Saldo"] = Convert.ToInt32(iRow["Valor"]) - Convert.ToInt32(iRow["Abono"]);// - Convert.ToInt32(iRow["Cruce"]);
                }
                else
                {
                    iRow["Saldo"] = Convert.ToInt32(iRow["Valor"]) - Convert.ToInt32(iRow["Abono"]) - Convert.ToInt32(iRow["Cruce"]);
                }
                //iRow["Saldo"] = Convert.ToInt32(iRow["Valor"]) - Convert.ToInt32(iRow["Abono"]);// - Convert.ToInt32(iRow["Cruce"]);
                this.TablaInforme.Rows.Add(iRow);
            }
            tabla.Rows.Clear();
            tabla = null;
            return this.TablaInforme;
        }


        private void CrearTablaInforme()
        {
            this.TablaInforme = new DataTable();
            this.TablaInforme.TableName = "Anticipo";
            this.TablaInforme.Columns.Add(new DataColumn("Fecha", typeof(DateTime)));
            this.TablaInforme.Columns.Add(new DataColumn("NoEgreso", typeof(string)));
            this.TablaInforme.Columns.Add(new DataColumn("Cuenta", typeof(string)));
            this.TablaInforme.Columns.Add(new DataColumn("Nit", typeof(string)));
            this.TablaInforme.Columns.Add(new DataColumn("Tercero", typeof(string)));
            this.TablaInforme.Columns.Add(new DataColumn("Concepto", typeof(string)));
            this.TablaInforme.Columns.Add(new DataColumn("Valor", typeof(int)));
            this.TablaInforme.Columns.Add(new DataColumn("Abono", typeof(int)));
            this.TablaInforme.Columns.Add(new DataColumn("Cruce", typeof(int)));
            this.TablaInforme.Columns.Add(new DataColumn("Saldo", typeof(int)));
        }

        public void EditarAnticipo(int idAnticipo)
        {
            try
            {
                CargarComando("editar_anticipo_prestamo");
                miComando.Parameters.AddWithValue("idAnticipo", idAnticipo);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al editar el Prestamo y/o Anticipo.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public void AnularAnticipo(int idAnticipo)
        {
            try
            {
                CargarComando("editar_anticipo_prestamo_anular");
                miComando.Parameters.AddWithValue("idAnticipo", idAnticipo);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al anular el Prestamo y/o Anticipo.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }



        // Pagos de Préstamos y Anticipo.
        public int IngresarPagoAnticipo(PagoAnticipo pago)
        {
            try
            {
                CargarComando("insertar_pago_anticipo_prestamo");
                miComando.Parameters.AddWithValue("idanticipo", pago.IdAnticipo);
                miComando.Parameters.AddWithValue("idconcepto", pago.IdConcepto);
                miComando.Parameters.AddWithValue("tipo", pago.Tipo);
                miComando.Parameters.AddWithValue("documento", pago.NoDocumento);
                miComando.Parameters.AddWithValue("concepto", pago.Concepto);
                miComando.Parameters.AddWithValue("valor", pago.Valor);
                miComando.Parameters.AddWithValue("fecha", pago.Fecha);
                miConexion.MiConexion.Open();
                var id = Convert.ToInt32(miComando.ExecuteScalar());
                miConexion.MiConexion.Close();
                miComando.Dispose();
                foreach (FormaPago fPago in pago.Pagos)
                {
                    fPago.IdEgreso = id;
                    IngresarFormaPagoAnticipo(fPago);
                }
                if (PagosAnticiposTercero(pago.IdAnticipo).AsEnumerable().Sum(s => s.Field<int>("valor")).Equals(
                    PagosAnticipo(pago.IdAnticipo).AsEnumerable().Sum(s => s.Field<int>("valor"))))
                {
                    EditarAnticipo(pago.IdAnticipo);
                }
                /**valor = PagosAnticiposTercero(Convert.ToInt32(aRow["id"])).
                                            AsEnumerable().Sum(s => s.Field<int>("valor"));
                        pago = PagosAnticipo(Convert.ToInt32(aRow["id"])).
                                            AsEnumerable().Sum(s => s.Field<int>("valor"));*/
                return id;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al ingresar el pago de Préstamos y anticipos.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public void IngresarCruceAnticipo(int idCuenta, int idTercero, CruceCuentaPagar cruce)
        {
            try
            {
                var monto = cruce.Valor;
                var pagoAnticipo = new PagoAnticipo();
                var valor = 0;
                var pago = 0;
                var tAnticipos = AnticiposATerceroNoPagos(idCuenta, idTercero);
                foreach (DataRow aRow in tAnticipos.Rows)
                {
                    if (monto > 0)
                    {
                        valor = PagosAnticiposTercero(Convert.ToInt32(aRow["id"])).
                                            AsEnumerable().Sum(s => s.Field<int>("valor"));
                        pago = PagosAnticipo(Convert.ToInt32(aRow["id"])).
                                            AsEnumerable().Sum(s => s.Field<int>("valor"));
                        if (valor > pago) // Anticipo con saldo.
                        {
                            pagoAnticipo.IdAnticipo = Convert.ToInt32(aRow["id"]);
                            pagoAnticipo.IdConcepto = 2;
                            pagoAnticipo.Tipo = 1;
                            pagoAnticipo.NoDocumento = cruce.Numero;
                            pagoAnticipo.Concepto = cruce.Concepto;
                            pagoAnticipo.Fecha = DateTime.Now;
                            if (monto > (valor - pago))
                            {
                                pagoAnticipo.Valor = valor - pago;
                                monto -= valor - pago;
                            }
                            else
                            {
                                pagoAnticipo.Valor = Convert.ToInt32(monto);
                                monto = 0;
                            }
                            IngresarPagoAnticipo(pagoAnticipo);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al ingresar el Cruce de Anticipo.\n" + ex.Message);
            }
        }

        public void IngresarCruceAnticipo(string nit, CruceCuentaPagar cruce)
        {
            try
            {
                var monto = cruce.Valor;
                var pagoAnticipo = new PagoAnticipo();
                var valor = 0;
                var pago = 0;
                var tAnticipos = AnticiposATerceroNoPagos(nit);
                foreach (DataRow aRow in tAnticipos.Rows)
                {
                    if (monto > 0)
                    {
                        valor = PagosAnticiposTercero(Convert.ToInt32(aRow["id"])).
                                            AsEnumerable().Sum(s => s.Field<int>("valor"));
                        pago = PagosAnticipo(Convert.ToInt32(aRow["id"])).
                                            AsEnumerable().Sum(s => s.Field<int>("valor"));
                        if (valor > pago) // Anticipo con saldo.
                        {
                            pagoAnticipo.IdAnticipo = Convert.ToInt32(aRow["id"]);
                            pagoAnticipo.IdConcepto = 2;
                            pagoAnticipo.Tipo = 1;
                            pagoAnticipo.NoDocumento = cruce.Numero;
                            pagoAnticipo.Concepto = cruce.Concepto;
                            pagoAnticipo.Fecha = DateTime.Now;
                            if (monto > (valor - pago))
                            {
                                pagoAnticipo.Valor = valor - pago;
                                monto -= valor - pago;
                            }
                            else
                            {
                                pagoAnticipo.Valor = Convert.ToInt32(monto);
                                monto = 0;
                            }
                            IngresarPagoAnticipo(pagoAnticipo);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al ingresar el Cruce de Anticipo.\n" + ex.Message);
            }
        }

        public void IngresarFormaPagoAnticipo(FormaPago pago)
        {
            try
            {
                CargarComando("insertar_pago_anticipo_forma");
                miComando.Parameters.AddWithValue("idpagoanticipo", pago.IdEgreso);
                miComando.Parameters.AddWithValue("idformapago", pago.IdFormaPago);
                miComando.Parameters.AddWithValue("valor", pago.Valor);
                miConexion.MiConexion.Open();
                miComando.ExecuteNonQuery();
                miConexion.MiConexion.Close();
                miComando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al ingresar las Formas de Pago.\n" + ex.Message);
            }
            finally { miConexion.MiConexion.Close(); }
        }

        public DataTable PagosAnticipo(int idAnticipo)
        {
            try
            {
                var tabla = new DataTable();
                CargarAdapter("pagos_anticipo_prestamo");
                miAdapter.SelectCommand.Parameters.AddWithValue("idanticipo", idAnticipo);
                miAdapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al consultar los pagos.\n" + ex.Message);
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