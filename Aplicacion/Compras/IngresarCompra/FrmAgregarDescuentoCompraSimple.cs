using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utilities;
using CustomControl;
using DTO.Clases;
using BussinesLayer.Clases;

namespace Aplicacion.Compras.IngresarCompra
{
    public partial class FrmAgregarDescuentoCompraSimple : Form
    {
        public int IdCompra { set; get; }

        public DTO.Clases.Proveedor Proveedor { set; get; }

        private BussinesCompraSimple miBussinesCompra;

        private BussinesEmpresa miBussinesEmpresa;

        public FrmAgregarDescuentoCompraSimple()
        {
            InitializeComponent();
            this.Proveedor = new DTO.Clases.Proveedor();
            this.miBussinesCompra = new BussinesCompraSimple();
            this.miBussinesEmpresa = new BussinesEmpresa();
        }

        private void FrmAgregarDescuentoCompraSimple_Load(object sender, EventArgs e)
        {
            try
            {
                this.dgvDescuentos.DataSource = this.miBussinesCompra.Descuentos();
                ColorearGridDescuento();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void FrmAgregarDescuentoCompraSimple_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData.Equals(Keys.F2))
            {
                this.tsGuardar_Click(this.tsGuardar, new EventArgs());
            }
            else
            {
                if(e.KeyData.Equals(Keys.Escape))
                {
                    this.Close();
                }
            }
        }

        private void tsGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult rta = MessageBox.Show("¿Está seguro(a) de agregar los descuentos a la compra?", "Compras",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rta.Equals(DialogResult.Yes))
                {
                    foreach (var descto in Descuentos())
                    {
                        this.miBussinesCompra.IngresarDescuentoCompra(descto);
                        int diferencia = this.miBussinesCompra.AjustarCompraPagos(this.IdCompra);
                        OptionPane.MessageInformation("Los descuento se agregaron con éxito.");
                        if (diferencia > 0)
                        {
                            Print(diferencia);
                        }
                        CompletaEventos.CapturaEvento(new ObjectAbstract { Id = 555666889 });

                        this.dgvDescuentos.DataSource = this.miBussinesCompra.Descuentos();
                        ColorearGridDescuento();
                        this.txtTotalDescuento.Text = "0";
                    }
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void tsSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvDescuentos_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (this.dgvDescuentos.IsCurrentCellDirty)
            {
                this.dgvDescuentos.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgvDescuentos_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            int total = 0;
            foreach (DataGridViewRow row in this.dgvDescuentos.Rows)
            {
                if (!(row.Cells["ValorDescuento"].Value == null))
                {
                    if (!row.Cells["ValorDescuento"].Value.Equals(""))
                    {
                        total += Convert.ToInt32(Convert.ToDouble(row.Cells["ValorDescuento"].Value));
                    }
                }
            }
            this.txtTotalDescuento.Text = UseObject.InsertSeparatorMil(total.ToString());
            ColorearGridDescuento();
        }

        private void ColorearGridDescuento()
        {
            var cont = 0;
            foreach (DataGridViewRow row in this.dgvDescuentos.Rows)
            {
                cont++;
                if (cont % 2 != 0)
                {
                    row.DefaultCellStyle.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
                }
            }
        }

        private List<Descuento> Descuentos()
        {
            var descuentos = new List<Descuento>();
            foreach (DataGridViewRow row in this.dgvDescuentos.Rows)
            {
                if (!(row.Cells["ValorDescuento"].Value == null))
                {
                    if (!row.Cells["ValorDescuento"].Value.Equals(""))
                    {
                        var descuento = new Descuento();
                        descuento.IdFactura = this.IdCompra;
                        descuento.IdDescuento = Convert.ToInt32(row.Cells["IdDescuento"].Value);
                        descuento.CodigoInternoProducto = row.Cells["Nombre"].Value.ToString();
                        descuento.ValorDescuento = Convert.ToInt32(row.Cells["ValorDescuento"].Value);
                        descuentos.Add(descuento);
                    }
                }
            }
            return descuentos;
        }

        private void Print(int diferencia)
        {
            try
            {
                var empresaRow = this.miBussinesEmpresa.PrintEmpresa().Tables[0].AsEnumerable().First();

                Ticket ticket = new Ticket();
                ticket.UseItem = false;

                ticket.AddHeaderLine(empresaRow["Nombre"].ToString().ToUpper());
                ticket.AddHeaderLine(empresaRow["Juridico"].ToString());
                ticket.AddHeaderLine("NIT " + UseObject.InsertSeparatorMilMasDigito(empresaRow["Nit"].ToString()));
                ticket.AddHeaderLine(empresaRow["Direccion"].ToString());
                ticket.AddHeaderLine("Tels. " + empresaRow["Telefono"].ToString());
                ticket.AddHeaderLine("COMPROBANTE DE AJUSTE");
                ticket.AddHeaderLine("Fecha : " + DateTime.Now.ToShortDateString());
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("===================================");
                ticket.AddHeaderLine("No. compra: " + this.IdCompra);
                ticket.AddHeaderLine("Proveedor : " + this.Proveedor.NombreProveedor);
                ticket.AddHeaderLine("C.C.      : " + UseObject.InsertSeparatorMilMasDigito(this.Proveedor.NitProveedor));
                ticket.AddHeaderLine("===================================");
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("Valor diferencia : " + diferencia);
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("-----------------------------------");
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("Software: Digital Fact Pyme");
                ticket.AddHeaderLine("Soluciones Tecnológicas A&C.");
                ticket.AddHeaderLine("solucionestecnologicasayc@gmail.com");
                ticket.AddHeaderLine("");

                ticket.PrintTicket("IMPREPOS");

            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }
        
    }
}