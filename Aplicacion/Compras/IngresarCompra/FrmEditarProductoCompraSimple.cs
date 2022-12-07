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
using BussinesLayer.Clases;
using DTO.Clases;

namespace Aplicacion.Compras.IngresarCompra
{
    public partial class FrmEditarProductoCompraSimple : Form
    {
        public int IdCompra { set; get; }

        public int IdProducto { set; get; }

        public string CodigoProducto { set; get; }

        public double Cantidad { set; get; }

        public DTO.Clases.Proveedor Proveedor { set; get; }

        private BussinesProducto miBussinesProducto;

        private BussinesColor miBussinesColor;

        private BussinesCompraSimple miBussinesCompra;

        private BussinesEmpresa miBussinesEmpresa;

        public FrmEditarProductoCompraSimple()
        {
            InitializeComponent();
            this.IdCompra = 0;
            this.IdProducto = 0;
            this.CodigoProducto = "";
            this.Cantidad = 0;
            this.Proveedor = new DTO.Clases.Proveedor();
            this.miBussinesProducto = new BussinesProducto();
            this.miBussinesColor = new BussinesColor();
            this.miBussinesCompra = new BussinesCompraSimple();
            this.miBussinesEmpresa = new BussinesEmpresa();
        }

        private void FrmEditarProductoCompraSimple_Load(object sender, EventArgs e){}

        private void FrmEditarProductoCompraSimple_KeyDown(object sender, KeyEventArgs e)
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
                    var producto = new ProductoFacturaProveedor();
                    producto.Id = this.IdProducto;
                    producto.Cantidad = Convert.ToDouble(UseObject.RemoveSeparatorMil(this.txtCantidad.Text));
                    producto.Costo = Convert.ToInt32(UseObject.RemoveSeparatorMil(this.txtPrecio.Text));
                    producto.Valor = Convert.ToInt32(UseObject.RemoveSeparatorMil(this.txtValor.Text));
                    if (producto.Cantidad != this.Cantidad)
                    {
                        producto.Inventario.CodigoProducto = this.CodigoProducto;
                        producto.Inventario.IdMedida = this.miBussinesProducto.ProductoMedida(this.CodigoProducto).IdValorUnidadMedida;
                        var tColores = this.miBussinesColor.ColoresDeProducto(producto.Producto.CodigoInternoProducto, producto.Inventario.IdMedida);
                        if (tColores.Rows.Count > 0)
                        {
                            var sRow = (from d in tColores.AsEnumerable() select d).Single();
                            producto.Inventario.IdColor = Convert.ToInt32(sRow["idcolor"]);
                        }
                        else
                        {
                            producto.Inventario.IdColor = 0;
                        }
                        if (this.Cantidad > producto.Cantidad)
                        {
                            producto.Inventario.Cantidad = this.Cantidad - producto.Cantidad;
                        }
                        else
                        {
                            producto.Inventario.Cantidad = producto.Cantidad - this.Cantidad;
                        }
                    }
                    if (this.Cantidad > producto.Cantidad)
                    {
                        this.miBussinesCompra.EditarProducto(producto, true);
                    }
                    else
                    {
                        this.miBussinesCompra.EditarProducto(producto, false);
                    }
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

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.txtPrecio.Text = UseObject.InsertSeparatorMil(NumeroFormato(this.txtPrecio.Text, false).ToString());
                this.txtValor.Text = UseObject.InsertSeparatorMil(Convert.ToInt32(
                    NumeroFormato(this.txtPrecio.Text, false) * NumeroFormato(this.txtCantidad.Text, true)).ToString());
                this.txtCantidad.Focus();
                this.txtCantidad.SelectAll();
            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.txtCantidad.Text = UseObject.InsertSeparatorMil(NumeroFormato(this.txtCantidad.Text, true).ToString());
                this.txtValor.Text = UseObject.InsertSeparatorMil(Convert.ToInt32(
                    NumeroFormato(this.txtPrecio.Text, false) * NumeroFormato(this.txtCantidad.Text, true)).ToString());
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