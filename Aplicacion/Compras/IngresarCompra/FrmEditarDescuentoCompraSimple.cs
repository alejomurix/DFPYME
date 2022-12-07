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
using DTO.Clases;
using Utilities;

namespace Aplicacion.Compras.IngresarCompra
{
    public partial class FrmEditarDescuentoCompraSimple : Form
    {
        public int IdCompra { set; get; }

        public int IdDescuento { set; get; }

        public DTO.Clases.Proveedor Proveedor { set; get; }

        private BussinesCompraSimple miBussinesCompra;

        private BussinesEmpresa miBussinesEmpresa;

        public FrmEditarDescuentoCompraSimple()
        {
            InitializeComponent();
            this.IdCompra = 0;
            this.IdDescuento = 0;
            this.Proveedor = new DTO.Clases.Proveedor();
            this.miBussinesCompra = new BussinesCompraSimple();
            this.miBussinesEmpresa = new BussinesEmpresa();
        }

        private void FrmEditarDescuentoCompraSimple_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.Escape))
            {
                this.Close();
            }
        }

        private void tsGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult rta = MessageBox.Show("¿Está seguro(a) de guardar los cambios?", "Edición de producto",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rta.Equals(DialogResult.Yes))
                {
                    this.miBussinesCompra.EditarDescuento(this.IdDescuento, Convert.ToInt32(NumeroFormato(this.txtValor.Text, false)));
                    int diferencia = this.miBussinesCompra.AjustarCompraPagos(this.IdCompra);
                    OptionPane.MessageInformation("La edición se guardó con éxito.");
                    if (diferencia > 0)
                    {
                        Print(diferencia);
                    }
                    CompletaEventos.CapturaEvento(new ObjectAbstract { Id = 555666889 });
                    this.Close();
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

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.txtValor.Text = NumeroFormato(this.txtValor.Text, false).ToString();
                this.tsGuardar_Click(this.tsGuardar, new EventArgs());
            }
        }

        private double NumeroFormato(string numero, bool cantidad)
        {
            try
            {
                double num = 0;
                if (String.IsNullOrEmpty(numero))
                {
                    num = 0;
                }
                else
                {
                    if (cantidad)
                    {
                        numero = numero.Replace(".", ",");
                    }
                    else
                    {
                        numero = numero.Replace(".", "");
                    }
                    //numero = numero.Replace(".", ",");
                    num = Convert.ToDouble(numero);
                }
                return num;
            }
            catch (FormatException)
            {
                return 0;
            }
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