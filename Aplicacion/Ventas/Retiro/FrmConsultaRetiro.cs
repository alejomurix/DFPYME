using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BussinesLayer.Clases;
using CustomControl;
using Utilities;

namespace Aplicacion.Ventas.Retiro
{
    public partial class FrmConsultaRetiro : Form
    {
        private BussinesIngreso miBussinesIngreso;

        private BussinesRetiro miBussinesRetiro;

        private BussinesApertura miBussinesApertura;

        private BussinesCaja miBussinesCaja;

        private BussinesTurno miBussinesTurno;

        private BussinesEmpresa miBussinesEmpresa;

        private DataTable TablaIngresos { set; get; }

        private DataTable Tabla { set; get; }

        public FrmConsultaRetiro()
        {
            InitializeComponent();
            miBussinesIngreso = new BussinesIngreso();
            miBussinesRetiro = new BussinesRetiro();
            miBussinesApertura = new BussinesApertura();
            miBussinesCaja = new BussinesCaja();
            miBussinesTurno = new BussinesTurno();
            miBussinesEmpresa = new BussinesEmpresa();
        }

        private void FrmConsultaRetiro_Load(object sender, EventArgs e)
        {
            CargarElementos();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (Tabla.Rows.Count != 0)
            {
                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("printInformeRetiro")))
                {
                    PrintPos(Tabla);
                }
                else
                {
                }
            }
            else
            {
                OptionPane.MessageInformation("No hay registros para imprimir.");
            }
        }

        private void btnImprimeInforme_Click(object sender, EventArgs e)
        {
            PrintInformePos(dtpFecha.Value);
        }

        private void btnInformeGeneral_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow empresaRow = miBussinesEmpresa.PrintEmpresa().
                        Tables[0].AsEnumerable().First();

                var tCajas = miBussinesCaja.Cajas();
                foreach (DataRow cRow in tCajas.Rows)
                {
                    var tIngresos = miBussinesIngreso.PrintIngresos(dtpFecha.Value, Convert.ToInt32(cRow["idcaja"]));
                    var tRetiros = miBussinesRetiro.Retiros(dtpFecha.Value, Convert.ToInt32(cRow["idcaja"]));
                    var apertura = miBussinesApertura.Apertura(dtpFecha.Value, Convert.ToInt32(cRow["idcaja"]));

                    Ticket ticket = new Ticket();
                    ticket.UseItem = false;

                    ticket.AddHeaderLine(empresaRow["Nombre"].ToString().ToUpper());
                    ticket.AddHeaderLine(empresaRow["Juridico"].ToString());
                    ticket.AddHeaderLine("NIT " + UseObject.InsertSeparatorMilMasDigito(empresaRow["Nit"].ToString()));
                    ticket.AddHeaderLine("Régimen: " + empresaRow["Regimen"].ToString());
                    ticket.AddHeaderLine(empresaRow["Direccion"].ToString());
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("INFORME DE CAJA");
                    ticket.AddHeaderLine("Fecha : " + dtpFecha.Value.ToShortDateString());
                    ticket.AddHeaderLine("Caja  : " + cRow["numerocaja"].ToString());
                    ticket.AddHeaderLine("");

                    ticket.AddHeaderLine("APERTURA : $" + 
                                          UseObject.InsertSeparatorMil(apertura.Valor.ToString()));
                    ticket.AddHeaderLine("");

                    ticket.AddHeaderLine("INGRESOS");
                    ticket.AddHeaderLine("");
                    foreach (DataRow iRow in tIngresos.Rows)
                    {
                        ticket.AddHeaderLine(iRow["pago"].ToString() + " : " +
                                             UseObject.InsertSeparatorMil(iRow["valor"].ToString()));
                        ticket.AddHeaderLine("");
                    }
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("RETIROS");
                    ticket.AddHeaderLine("");
                    foreach (DataRow rRow in tRetiros.Rows)
                    {
                        ticket.AddHeaderLine(rRow["pago"].ToString() + " : " +
                                             UseObject.InsertSeparatorMil(rRow["valor"].ToString()));
                        ticket.AddHeaderLine("");
                    }
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("RESUMEN");
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("TOTAL INGRESOS : " +
                        UseObject.InsertSeparatorMil(tIngresos.AsEnumerable().Sum(s => s.Field<long>("valor")).ToString()));
                    ticket.AddHeaderLine("TOTAL RETIROS  : " +
                        UseObject.InsertSeparatorMil(tRetiros.AsEnumerable().Sum(s => s.Field<long>("valor")).ToString()));
                    ticket.AddHeaderLine("DIFERENCIA     : " + UseObject.InsertSeparatorMil((
                        tIngresos.AsEnumerable().Sum(s => s.Field<long>("valor")) -
                        tRetiros.AsEnumerable().Sum(s => s.Field<long>("valor"))).ToString()));
                    ticket.AddHeaderLine("");
                    ticket.AddFooterLine("-----------------------------------");
                    ticket.PrintTicket("IMPREPOS");
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                // Consulta a ingresos.
                dgvIngresos.AutoGenerateColumns = false;
                dgvPagoIngresos.AutoGenerateColumns = false;
                TablaIngresos = miBussinesIngreso.Ingresos(dtpFecha.Value,
                                                 Convert.ToInt32(cbCaja.SelectedValue),
                                                 Convert.ToInt32(cbTurno.SelectedValue));
                dgvIngresos.DataSource = TablaIngresos;
                if (TablaIngresos.Rows.Count.Equals(0))
                {
                    lblMsnIngreso.Text = "No se encontraron registros de la consulta.";
                    while (dgvPagoIngresos.RowCount != 0)
                    {
                        dgvPagoIngresos.Rows.RemoveAt(0);
                    }
                }
                else
                {
                    lblMsnIngreso.Text = "";
                    var query = TablaIngresos.AsEnumerable().Where
                        (d => d.Field<int>("id").Equals(Convert.ToInt32(dgvIngresos.CurrentRow.Cells["IdIngreso"].Value)));
                    dgvPagoIngresos.DataSource = query.AsDataView();
                }

                // Consulta a retiros.
                dgvRetiros.AutoGenerateColumns = false;
                dgvPagos.AutoGenerateColumns = false;
                Tabla = miBussinesRetiro.Retiros(dtpFecha.Value,
                                                 Convert.ToInt32(cbCaja.SelectedValue),
                                                 Convert.ToInt32(cbTurno.SelectedValue));
                dgvRetiros.DataSource = Tabla;
                if (Tabla.Rows.Count.Equals(0))
                {
                    //OptionPane.MessageInformation("No se encontraron registros de la consulta.");
                    //lblMsnRetiro.ForeColor = Color.Red;
                    lblMsnRetiro.Text = "No se encontraron registros de la consulta.";
                    while (dgvPagos.RowCount != 0)
                    {
                        dgvPagos.Rows.RemoveAt(0);
                    }
                }
                else
                {
                    lblMsnRetiro.Text = "";
                    dgvPagos.DataSource = miBussinesRetiro.PagosRetiro(Convert.ToInt32(dgvRetiros.CurrentRow.Cells["Id"].Value));
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void dgvIngresos_Click(object sender, EventArgs e)
        {
            if (dgvIngresos.RowCount != 0)
            {
                var query = TablaIngresos.AsEnumerable().Where
                            (d => d.Field<int>("id").Equals(Convert.ToInt32(dgvIngresos.CurrentRow.Cells["IdIngreso"].Value)));
                dgvPagoIngresos.DataSource = query.AsDataView();
            }
        }

        private void dgvRetiros_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvRetiros.RowCount != 0)
            {
                dgvPagos.DataSource = miBussinesRetiro.PagosRetiro(Convert.ToInt32(dgvRetiros.CurrentRow.Cells["Id"].Value));
            }
        }

        private void CargarElementos()
        {
            try
            {
                cbCaja.DataSource = miBussinesCaja.Cajas();
                cbTurno.DataSource = miBussinesTurno.Turnos();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void PrintPos(DataTable retiros)
        {
            try
            {
                int total = 0;
                DataRow empresaRow = miBussinesEmpresa.PrintEmpresa().
                        Tables[0].AsEnumerable().First();
                var retiroRow = retiros.AsEnumerable().First();

                Ticket ticket = new Ticket();
                ticket.UseItem = false;

                ticket.AddHeaderLine(empresaRow["Nombre"].ToString().ToUpper());
                ticket.AddHeaderLine(empresaRow["Juridico"].ToString());
                ticket.AddHeaderLine("NIT " + UseObject.InsertSeparatorMilMasDigito(empresaRow["Nit"].ToString()));
                ticket.AddHeaderLine("Régimen: " + empresaRow["Regimen"].ToString());
                ticket.AddHeaderLine(empresaRow["Direccion"].ToString());
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("INFORME DE RETIROS");
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("Fecha : " + Convert.ToDateTime(retiroRow["fecha"]).ToShortDateString());
                ticket.AddHeaderLine("Caja  : " + retiroRow["nocaja"].ToString());
                ticket.AddHeaderLine("Turno : " + retiroRow["noturno"].ToString());
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("");
                foreach (DataRow rRetiro in retiros.Rows)
                {
                    var tPagos = miBussinesRetiro.PagosRetiro(Convert.ToInt32(rRetiro["id"]));
                    ticket.AddHeaderLine("Hora : " + Convert.ToDateTime(rRetiro["hora"]).ToShortTimeString());
                    
                    foreach(DataRow pRow in tPagos.Rows)
                    {
                        ticket.AddHeaderLine("Concepto : " + pRow["concepto"].ToString());
                        ticket.AddHeaderLine(pRow["pago"].ToString() + " : " +
                            UseObject.InsertSeparatorMil(pRow["valor"].ToString()));
                        ticket.AddHeaderLine("");
                        total += Convert.ToInt32(pRow["valor"]);
                    }
                    ticket.AddHeaderLine("");
                }
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("TOTAL RETIROS : " + UseObject.InsertSeparatorMil(total.ToString()));

                ticket.PrintTicket("IMPREPOS");
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void PrintInformePos(DateTime fecha)
        {
            try
            {
                var tCajas = miBussinesCaja.Cajas();
                var tTurnos = miBussinesTurno.Turnos();

                foreach (DataRow cRow in tCajas.Rows)
                {
                    foreach (DataRow tRow in tTurnos.Rows)
                    {
                        var tRetiros = miBussinesRetiro.Retiros
                                       (fecha, Convert.ToInt32(cRow["idcaja"]), Convert.ToInt32(tRow["id"]));
                        if (tRetiros.Rows.Count != 0)
                        {
                            PrintPos(tRetiros);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }
    }
}