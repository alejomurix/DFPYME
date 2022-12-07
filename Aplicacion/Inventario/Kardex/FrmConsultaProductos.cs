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

namespace Aplicacion.Inventario.Kardex
{
    // Consulta de productos vendidos por debado del precio de venta.

    public partial class FrmConsultaProductos : Form
    {
        private BussinesFacturaVenta miBussinesFactura;

        private DataTable tData;

        public FrmConsultaProductos()
        {
            InitializeComponent();
            this.miBussinesFactura = new BussinesFacturaVenta();
            this.tData = new DataTable();
        }

        private void FrmConsultaProductos_Load(object sender, EventArgs e)
        {
            this.dgvProductos.AutoGenerateColumns = false;
            this.cbCriterio.DataSource =
                                        new List<Aplicacion.Inventario.Producto.Criterio>
                                        {
                                            new Aplicacion.Inventario.Producto.Criterio
                                            {
                                                Id = 1,
                                                Nombre = "Fecha"
                                            },
                                            new Aplicacion.Inventario.Producto.Criterio
                                            {
                                                Id = 2,
                                                Nombre = "Periodo"
                                            }
                                        };
        }

        private void tsBtnCopia_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.tData.Rows.Count != 0)
                {
                    var miBussinesEmpresa = new BussinesEmpresa();
                    var miBussinesProducto = new BussinesProducto();

                    var empresaRow = miBussinesEmpresa.PrintEmpresa().Tables[0].AsEnumerable().First();

                    Ticket ticket = new Ticket();
                    ticket.UseItem = false;
                    ticket.AddHeaderLine(empresaRow["Nombre"].ToString().ToUpper());
                    ticket.AddHeaderLine(empresaRow["Juridico"].ToString());
                    ticket.AddHeaderLine("NIT " + UseObject.InsertSeparatorMilMasDigito(empresaRow["Nit"].ToString()));
                    ticket.AddHeaderLine(empresaRow["Direccion"].ToString());
                    ticket.AddHeaderLine("Tels. " + empresaRow["Telefono"].ToString());
                    ticket.AddHeaderLine("REGIMEN " + empresaRow["Regimen"].ToString());

                    ticket.AddHeaderLine("===================================");
                    ticket.AddHeaderLine("PRODUCTOS VENDIDOS POR DEBAJO DEL");
                    ticket.AddHeaderLine("PRECIO");
                    ticket.AddHeaderLine("===================================");
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("COD.  DESCRIPCION.            ");
                    ticket.AddHeaderLine("___________________________________");//35 CARACTERES
                    ticket.AddHeaderLine("");
                    foreach (DataRow row in this.tData.Rows)
                    {
                        string product = row["producto"].ToString();
                        if (product.Length > 29)
                        {
                            product = product.Substring(0, 29);
                        }
                        ticket.AddHeaderLine(UseObject.AjusteDeCaracteresDerecha(row["codigo"].ToString(), 5) + " " + product);
                        ticket.AddHeaderLine("      c " + row["caja"].ToString() + "|" + Convert.ToDateTime(row["fecha"]).ToShortDateString() + "|F#" + row["numero"].ToString());
                        ticket.AddHeaderLine("      Cant " + row["cantidad"].ToString() +
                                                  "|v " + UseObject.InsertSeparatorMil(row["valor"].ToString()) +
                                                  "|vv " + UseObject.InsertSeparatorMil(row["venta"].ToString()));
                    }
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("===================================");
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("Software: Digital Fact Pyme");
                    ticket.AddHeaderLine("solucionestecnologicasayc@gmail.com");
                    ticket.AddHeaderLine("");
                    ticket.PrintTicket("IMPREPOS");
                }
                else
                {
                    OptionPane.MessageInformation("Debe cargar una consulta.");
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void tsBtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbCriterio_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (Convert.ToInt32(this.cbCriterio.SelectedValue).Equals(1))
            {
                this.dtpFecha1.Enabled = true;
                this.dtpFecha2.Enabled = false;
            }
            else
            {
                this.dtpFecha1.Enabled = true;
                this.dtpFecha2.Enabled = true;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(this.cbCriterio.SelectedValue).Equals(1))
                {
                    this.tData = this.miBussinesFactura.VentasDebajoPrecio(this.dtpFecha1.Value);
                }
                else
                {
                    this.tData = this.miBussinesFactura.VentasDebajoPrecio(this.dtpFecha1.Value, this.dtpFecha2.Value);
                }
                this.dgvProductos.DataSource = this.tData;
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        

       
    }
}