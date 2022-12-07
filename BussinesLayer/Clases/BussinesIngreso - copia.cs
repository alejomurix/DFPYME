using System;
using System.Data;
using DTO.Clases;
using DataAccessLayer.Clases;

namespace BussinesLayer.Clases
{
    public class BussinesIngreso
    {
        private DaoIngreso miDaoIngreso;

        public BussinesIngreso()
        {
            this.miDaoIngreso = new DaoIngreso();
        }

        public int Ingresar(Ingreso ingreso, bool multiple)
        {
            return miDaoIngreso.Ingresar(ingreso, multiple);
        }

        // Ingreso de Remision de Venta.
        public void IngresoDeRemision(Ingreso ingreso)
        {
            miDaoIngreso.IngresoDeRemision(ingreso);
        }

        public DataTable IngresosRemision(string numero)
        {
            return miDaoIngreso.IngresosRemision(numero);
        }

        public DataTable FormasPagoIngresoRemision(int idIngreso)
        {
            return miDaoIngreso.FormasPagoIngresoRemision(idIngreso);
        }

        public DataTable IngresosRemisionHoras(int idEstado, int idcaja, DateTime fecha, DateTime fecha2)
        {
            return this.miDaoIngreso.IngresosRemisionHoras(idEstado, idcaja, fecha, fecha2);
        }

        //--------------------------

        public DataTable Ingresos(int rowIndex, int rowMax)
        {
            return miDaoIngreso.Ingresos(rowIndex, rowMax);
        }

        public long GetRowsIngresos()
        {
            return miDaoIngreso.GetRowsIngresos();
        }

        public DataTable Ingresos(string numero)
        {
            return miDaoIngreso.Ingresos(numero);
        }

        public DataTable IngresosMultiple(string numero)
        {
            return miDaoIngreso.IngresosMultiple(numero);
        }

        public DataTable Ingresos(DateTime fecha)
        {
            return miDaoIngreso.Ingresos(fecha);
        }

        public DataTable Ingresos(DateTime fecha, DateTime fecha2)
        {
            return miDaoIngreso.Ingresos(fecha, fecha2);
        }

        public DataTable ClienteConSaldo(string numero, int tipo)
        {
            return miDaoIngreso.ClienteConSaldo(numero, tipo);
        }

        public DataTable PagosAnticipoCliente(string numero, int tipo)
        {
            return miDaoIngreso.PagosAnticipoCliente(numero, tipo);
        }

        public DataTable AbonosVenta(string numero, int tipo)
        {
            return miDaoIngreso.AbonosVenta(numero, tipo);
        }

        public DataTable PagosIngreso(int idTipo, DataRowCollection rows)
        {
            var miDaoFormaPago = new DaoFormaPago();
            var miDaoDevolucion = new DaoDevolucion();
            
            var tabla = new DataTable();
            tabla.Columns.Add(new DataColumn("NoFactura", typeof(string)));
            tabla.Columns.Add(new DataColumn("IdUser", typeof(int)));
            tabla.Columns.Add(new DataColumn("NoCaja", typeof(int)));
            tabla.Columns.Add(new DataColumn("IdPago", typeof(int)));
            tabla.Columns.Add(new DataColumn("FormaPago", typeof(string)));
            tabla.Columns.Add(new DataColumn("Valor", typeof(int)));
            if (idTipo.Equals(2))
            {
                foreach (DataRow row in rows)
                {
                    var tFormas = miDaoFormaPago.FormasDePagoDeFacturaVenta(Convert.ToInt32(row["id_relacion"]));
                    foreach (DataRow fRow in tFormas.Rows)
                    {
                        var row_ = tabla.NewRow();
                        row_["NoFactura"] = fRow["Factura"];
                        row_["IdUser"] = fRow["IdUsuario"];
                        row_["NoCaja"] = fRow["NoCaja"];
                        row_["IdPago"] = fRow["IdFormaPago"];
                        row_["FormaPago"] = fRow["Forma"];
                        row_["Valor"] = fRow["Valor"];
                        tabla.Rows.Add(row_);
                    }
                }
            }
            else
            {
                if (idTipo.Equals(3))
                {
                    //var daoCaja = new DaoCaja();

                    foreach (DataRow row in rows)
                    {
                        var tFormas = miDaoFormaPago.FormasDePagoRemisionId(Convert.ToInt32(row["id_relacion"]));
                        foreach (DataRow fRow in tFormas.Rows)
                        {
                            var row_ = tabla.NewRow();
                            row_["NoFactura"] = fRow["numero_remision"].ToString();
                            row_["IdUser"] = fRow["idusuario"];
                            row_["NoCaja"] = fRow["numerocaja"];
                            row_["IdPago"] = fRow["idforma_pago"];
                            row_["FormaPago"] = fRow["nombreforma_pago"];
                            row_["Valor"] = fRow["valor"];
                            tabla.Rows.Add(row_);
                        }
                    }
                }
                else
                {
                    if (idTipo.Equals(4))
                    {
                        foreach (DataRow row in rows)
                        {
                            var tFormas = miDaoDevolucion.SaldosDeDevolucionVenta(Convert.ToInt32(row["id_relacion"]));
                            foreach (DataRow fRow in tFormas.Rows)
                            {
                                var row_ = tabla.NewRow();
                                row_["NoFactura"] = fRow["numero_factura"].ToString();
                                row_["IdUser"] = fRow["idusuario"];
                                row_["NoCaja"] = fRow["numerocaja"];
                                row_["IdPago"] = 1;             // Cambiar aspecto de forma de pago.
                                row_["FormaPago"] = "Efectivo";
                                row_["Valor"] = fRow["valor"];
                                tabla.Rows.Add(row_);
                            }
                        }
                    }
                }
            }
            // implementar el tipo 2
            return tabla;
        }

        // CONSULTA INGRESOS A CAJA
        public DataTable Ingresos(DateTime fecha, int idcaja, int idturno)
        {
            return miDaoIngreso.Ingresos(fecha, idcaja, idturno);
        }

        public DataTable Ingresos(DateTime fecha, DateTime fecha2, int idcaja, int idturno)
        {
            return miDaoIngreso.Ingresos(fecha, fecha2, idcaja, idturno);
        }

        public DataTable IngresosHoras(DateTime fecha, DateTime fecha2, int idcaja, int idturno)
        {
            return miDaoIngreso.IngresosHoras(fecha, fecha2, idcaja, idturno);
        }

        public DataTable PrintIngresos(DateTime fecha, int idcaja, int idTurno)
        {
            return miDaoIngreso.PrintIngresos(fecha, idcaja, idTurno);
        }

        public DataTable PrintIngresos(DateTime fecha, DateTime fecha2, int idcaja, int idturno)
        {
            return miDaoIngreso.PrintIngresos(fecha, fecha2, idcaja, idturno);
        }

        public DataTable PrintIngresosHoras(DateTime fecha, DateTime fecha2, int idcaja, int idturno)
        {
            return miDaoIngreso.PrintIngresosHoras(fecha, fecha2, idcaja, idturno);
        }

        // ACUMULADO DE INGRESOS
        public int AcumuladoIngresos(int idCaja, DateTime fecha)
        {
            return miDaoIngreso.AcumuladoIngresos(idCaja, fecha);
        }

        public long SumaAcumuladoIngresos(int idCaja, DateTime fecha)
        {
            return miDaoIngreso.SumaAcumuladoIngresos(idCaja, fecha);
        }

        // Formas de pago de Ingreso.
        public void IngresarFormasPago(FormaPago pago)
        {
            miDaoIngreso.IngresarFormasPago(pago);
        }

        public DataTable FormasPagoIngresoVenta(int idIngreso)
        {
            return miDaoIngreso.FormasPagoIngresoVenta(idIngreso);
        }

        // Metodo a parte.
        public void ActualizarNit()
        {
            miDaoIngreso.ActualizarNit();
        }

        public DataTable Replicas()
        {
            return miDaoIngreso.EliminarReplicas();
        }

        public DataTable VerIngresosRemision()
        {
            return miDaoIngreso.VerIngresosRemision();
        }
    }
}