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
    public partial class FrmCompraSimple : Form
    {
        private bool MedidaCantidad;

        private double KiloPorArroba;

        private int CodigoProveedor;

        private string CedulaProveedor;

        //private string NombreProveedor;

        private ErrorProvider miError;

        private Validacion validacion;

        private BindingSource miBindingSource;

        private DataTable tProductos;

        private BussinesProducto miBussinesProducto;

        private BussinesCompraSimple miBussinesCompraSimple;

        private BussinesProveedor miBussinesProveedor;

        private BussinesEmpresa miBussinesEmpresa;

        private BussinesConsecutivo miBussinesConsecutivo;

        private BussinesBeneficio miBussinesBeneficio;

        private BussinesEgreso miBussinesEgreso;

        private BussinesColor miBussinesColor;

        public FrmCompraSimple()
        {
            InitializeComponent();

            this.KiloPorArroba = 12.5;

            this.dgvProductos.AutoGenerateColumns = false;
            this.CodigoProveedor = 0;
            this.miError = new ErrorProvider();
            this.validacion = new Validacion();
            this.miBindingSource = new BindingSource();

            this.miBussinesProducto = new BussinesProducto();
            this.miBussinesCompraSimple = new BussinesCompraSimple();
            this.miBussinesProveedor = new BussinesProveedor();
            this.miBussinesEmpresa = new BussinesEmpresa();
            this.miBussinesConsecutivo = new BussinesConsecutivo();
            this.miBussinesBeneficio = new BussinesBeneficio();
            this.miBussinesEgreso = new BussinesEgreso();
            this.miBussinesColor = new BussinesColor();

            try
            {
                this.MedidaCantidad = Convert.ToBoolean(AppConfiguracion.ValorSeccion("medidaCantidadCompraSimple"));
            }
            catch(Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void FrmCompraSimple_Load(object sender, EventArgs e)
        {
            try
            {
                CompletaEventos.Completa += new CompletaEventos.CompletaAccion(CompletaEventos_Completo);
                CompletaEventos.Completaz += new CompletaEventos.CompletaAccionz(CompletaEventos_Completaz);

                this.tProductos = this.miBussinesProducto.Productos();
                this.miBindingSource.DataSource = this.tProductos;
                this.dgvProductos.DataSource = this.miBindingSource;
                this.dgvDescuentos.DataSource = this.miBussinesCompraSimple.Descuentos();
                ColorearGridProducto();
                ColorearGridDescuento();

                
                //this.dgvProductos.Refresh();
                //.dgvDescuentos.Refresh();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void FrmCompraSimple_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.F2))
            {
                this.tsGuardar_Click(this.tsGuardar, new EventArgs());
            }
            else
            {
                if (e.KeyData.Equals(Keys.F3))
                {
                    this.tsConsulta_Click(this.tsConsulta, new EventArgs());
                }
                else
                {
                    if (e.KeyData.Equals(Keys.F5))
                    {
                        this.txtPago.Focus();
                        this.txtPago.Select();
                    }
                    else
                    {
                        if (e.KeyData.Equals(Keys.Escape))
                        {
                            this.Close();
                        }
                    }
                }
            }
        }

        private void tsGuardar_Click(object sender, EventArgs e)
        {
            if (this.CodigoProveedor != 0)
            {
                this.miError.SetError(this.txtNombreProveedor, null);
                var v = UseObject.RemoveSeparatorMil(this.txtGranTotal.Text);
                if (Convert.ToInt32(UseObject.RemoveSeparatorMil(this.txtGranTotal.Text)) > 0)
                {
                    this.txtPago_KeyPress(this.txtPago, new KeyPressEventArgs((char)Keys.Enter));
                    this.miError.SetError(this.txtGranTotal, null);
                    if (Convert.ToInt32(UseObject.RemoveSeparatorMil(this.txtPago.Text)) >= 0)
                    {
                        if (Convert.ToInt32(UseObject.RemoveSeparatorMil(this.txtPago.Text)) <=
                            Convert.ToInt32(UseObject.RemoveSeparatorMil(this.txtGranTotal.Text)))
                        {
                            this.miError.SetError(this.txtPago, null);
                            var facturaProveedor = new FacturaProveedor();
                            facturaProveedor.Proveedor.CodigoInternoProveedor = this.CodigoProveedor;
                           // facturaProveedor.Proveedor.NombreProveedor = this.NombreProveedor;
                            facturaProveedor.FechaFactura = this.dtpFecha.Value;
                            facturaProveedor.Valor = facturaProveedor.ValorReal = Convert.ToInt32(UseObject.RemoveSeparatorMil(this.txtSubtotal.Text));
                            //facturaProveedor.Valor = Convert.ToInt32(UseObject.RemoveSeparatorMil(this.txtGranTotal.Text));
                            facturaProveedor.Productos = Productos();
                            facturaProveedor.Descuentos = Descuentos();
                            if (Convert.ToInt32(UseObject.RemoveSeparatorMil(this.txtPago.Text)) > 0)
                            {
                                facturaProveedor.FormaPago.Fecha = this.dtpFecha.Value;
                                facturaProveedor.FormaPago.Valor = Convert.ToInt32(UseObject.RemoveSeparatorMil(this.txtPago.Text));
                            }
                            
                            try
                            {
                                DialogResult rta = MessageBox.Show("¿Está seguro(a) de guardar la compra?", "",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (rta.Equals(DialogResult.Yes))
                                {
                                    facturaProveedor.Id = this.miBussinesCompraSimple.IngresarCompra(facturaProveedor);
                                    OptionPane.MessageInformation("La compra se guardó con éxito.");
                                    Print(facturaProveedor);
                                    if (facturaProveedor.FormaPago.Valor > 0)
                                    {
                                        PrintEgresoPos(GenerarEgreso(facturaProveedor));
                                    }
                                    this.CodigoProveedor = 0;
                                    this.txtNombreProveedor.Text = "";

                                  //  this.miBindingSource.DataSource = this.miBussinesProducto.Productos();

                                    //this.dgvProductos.DataSource = null;
                               /*     while (this.dgvProductos.Rows.Count != 0)
                                    {
                                        this.dgvProductos.Rows.Clear();
                                    }*/
                                   // this.dgvProductos.DataSource = this.miBindingSource;

                                    this.tProductos = this.miBussinesProducto.Productos();
                                    this.miBindingSource.DataSource = this.tProductos;
                                    this.dgvProductos.DataSource = this.miBindingSource;
                                    ColorearGridProducto();

                                    this.dgvDescuentos.DataSource = this.miBussinesCompraSimple.Descuentos();
                                    ColorearGridDescuento();

                                    this.txtTotal.Text = "0";
                                    this.txtTotalDescuento.Text = "0";
                                    this.txtSubtotal.Text = "0";
                                    this.txtTotalDesc.Text = "0";
                                    this.txtGranTotal.Text = "0";
                                    this.txtPago.Text = "0";
                                    this.txtCodigoProveedor.Focus();
                                }
                            }
                            catch (Exception ex)
                            {
                                OptionPane.MessageError(ex.Message);
                            }
                        }
                        else
                        {
                            this.miError.SetError(this.txtPago, "El valor del pago no debe superar el total de la compra.");
                        }
                    }
                    else
                    {
                        this.miError.SetError(this.txtPago, "El valor del pago debe ser superior a cero.");
                    }
                }
                else
                {
                    this.miError.SetError(this.txtGranTotal, "El valor a pagar no debe ser negativo.");
                }
            }
            else
            {
                this.miError.SetError(this.txtNombreProveedor, "Debe cargar un proveedor.");
            }
        }

        private void tsConsulta_Click(object sender, EventArgs e)
        {
            var frmConsulta = new FrmConsultaCompraSimple();
            frmConsulta.MdiParent = this.MdiParent;
            frmConsulta.Show();
        }

        private void tsSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCodigoProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                try
                {
                    var proveedores = this.miBussinesBeneficio.Beneficiarios(this.txtCodigoProveedor.Text);
                    if (proveedores.Count.Equals(0))
                    {
                        DialogResult rta = MessageBox.Show("El proveedor no existe. ¿Desea crearlo?", "Compra proveedor",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (rta.Equals(DialogResult.Yes))
                        {
                            var frmBeneficia = new Beneficiario.FrmBeneficio();
                            //frmBeneficia.txtId.Text = this.txtCodigoProveedor.Text;
                            frmBeneficia.Add = true;
                            frmBeneficia.ShowDialog();
                            if (this.txtNombreProveedor.Text != "")
                            {
                                this.dgvProductos.Focus();
                            }
                        }
                    }
                    else
                    {
                        if (proveedores.Count.Equals(1))
                        {
                            var proveedor = this.miBussinesProveedor.ConsultarPrveedorBasico(proveedores.Single().NitCliente);
                            this.txtNombreProveedor.Text = proveedor.CodigoInternoProveedor + " - NIT: " + proveedor.NitProveedor
                                + " - " + proveedor.RazonSocialProveedor;
                            this.CodigoProveedor = proveedor.CodigoInternoProveedor;
                            this.CedulaProveedor = proveedor.NitProveedor;
                            this.txtCodigoProveedor.Text = "";
                            this.dgvProductos.Focus();
                        }
                        else
                        {
                            var frmBeneficio = new Beneficiario.FrmBeneficio();
                            frmBeneficio.tcBeneficio.SelectTab(1);
                            frmBeneficio.txtConsulta.Text = this.txtCodigoProveedor.Text;
                            frmBeneficio.ShowDialog();
                        }
                    }

                /*    if (this.miBussinesProveedor.ExisteProveedorConNit(this.txtCodigoProveedor.Text))
                    {
                        var proveedor = this.miBussinesProveedor.ConsultarPrveedorBasico(this.txtCodigoProveedor.Text);
                        this.txtNombreProveedor.Text = proveedor.CodigoInternoProveedor + " - NIT: " + proveedor.NitProveedor
                            + " - " + proveedor.RazonSocialProveedor;
                        this.CodigoProveedor = proveedor.CodigoInternoProveedor;
                        this.CedulaProveedor = proveedor.NitProveedor;
                        this.txtCodigoProveedor.Text = "";
                        this.dgvProductos.Focus();
                    }
                    else
                    {
                        DialogResult rta = MessageBox.Show("El proveedor no existe. ¿Desea crearlo?", "Compra proveedor",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (rta.Equals(DialogResult.Yes))
                        {
                            var frmBeneficia = new Beneficiario.FrmBeneficio();
                            frmBeneficia.txtId.Text = this.txtCodigoProveedor.Text;
                            frmBeneficia.Add = true;
                            frmBeneficia.ShowDialog();
                            if (this.txtNombreProveedor.Text != "")
                            {
                                this.dgvProductos.Focus();
                            }
                        }
                    }*/
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {
            var frmBeneficio = new Beneficiario.FrmBeneficio();
            frmBeneficio.tcBeneficio.SelectTab(1);
            frmBeneficio.ShowDialog();
            
           /* var formProveedor = new Proveedor.frmProveedor();
            formProveedor.Extension = true;
            formProveedor.tcProveedor.SelectTab(1);
            formProveedor.ShowDialog();*/
            if (this.txtNombreProveedor.Text != "")
            {
                this.dgvProductos.Focus();
            }
        }



        private void dgvProductos_DataError(object sender, DataGridViewDataErrorEventArgs e){}

        private void dgvProductos_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            var index = e.ColumnIndex;
            if (e.ColumnIndex.Equals(3))  // Precio
            {
                ActualizarInformacion(true, e.ColumnIndex, e.RowIndex, NumeroFormato(e.FormattedValue.ToString(), false));
                return;
            }
            else
            {
                if (e.ColumnIndex.Equals(4) || e.ColumnIndex.Equals(5))  // Cantidad (Kilo o Arroba)
                {
                    ActualizarInformacion(false, e.ColumnIndex, e.RowIndex, NumeroFormato(e.FormattedValue.ToString(), true));
                    return;
                }
            }
            //ColorearGridProducto();
        }

        private void dgvProductos_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (this.dgvProductos.IsCurrentCellDirty)
            {
                this.dgvProductos.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
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
            TotalResumen();
            ColorearGridDescuento();
        }

        private void txtPago_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                if (String.IsNullOrEmpty(this.txtPago.Text))
                {
                    this.txtPago.Text = "0";
                }
                this.txtPago.Text = this.txtPago.Text.Replace(".", "");
              //  if (validacion.ValidarNumeroInt(this.txtPago.Text))
             //   {
                    this.txtPago.Text = UseObject.InsertSeparatorMil(NumeroFormato(this.txtPago.Text).ToString());
               // }

                /*this.txtPago.Text = 
                    UseObject.InsertSeparatorMil(NumeroFormato(UseObject.RemoveSeparatorMil(this.txtPago.Text).ToString()).ToString());*/

               /* this.txtPago.Text = UseObject.InsertSeparatorMil(
                    UseObject.RemoveSeparatorMil(this.txtPago.Text).ToString());*/

                    this.btnGuardar.Focus();
            }
        }


        public void ColorearGridProducto()
        {
            var cont = 0;
            foreach (DataGridViewRow row in this.dgvProductos.Rows)
            {
                cont++;
                if (cont % 2 != 0)
                {
                    row.DefaultCellStyle.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
                }
            }
        }

        public void ColorearGridDescuento()
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

        
        private double NumeroFormato(string numero)
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
                    numero = numero.Replace(".", ",");
                    num = Convert.ToDouble(numero);
                }
                return num;
            }
            catch (FormatException)
            {
                return 0;
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

        private void ActualizarInformacion(bool precio, int columnIndex, int rowIndex, double valor)
        {
            var id = Convert.ToInt32(this.dgvProductos.Rows[rowIndex].Cells["Id"].Value);
            var query = (from data in this.tProductos.AsEnumerable()
                         where data.Field<int>("Id") == id
                         select data).Single();
            var index = this.tProductos.Rows.IndexOf(query);

            if (!precio) // Cantidad (kilo o Arroba)
            {
                if (columnIndex.Equals(4)) // Kilo
                {
                    this.tProductos.Rows[index]["Kilogramo"] = valor;
                    var d_ = decimal.Round(Convert.ToDecimal(valor / KiloPorArroba), 2);
                    this.tProductos.Rows[index]["Arroba"] = decimal.Round(Convert.ToDecimal(valor / KiloPorArroba), 2);
                }
                else
                {
                    if (columnIndex.Equals(5)) // Arroba
                    {
                        this.tProductos.Rows[index]["Arroba"] = valor;
                        var d_ = decimal.Round(Convert.ToDecimal(valor / KiloPorArroba), 2);
                        this.tProductos.Rows[index]["Kilogramo"] = decimal.Round(Convert.ToDecimal(valor * KiloPorArroba), 2);
                    }
                }
                if (MedidaCantidad)  // Kilo
                {
                    this.tProductos.Rows[index]["Valor"] = Convert.ToInt32(
                        Convert.ToDouble(this.tProductos.Rows[index]["Kilogramo"]) * Convert.ToInt32(this.tProductos.Rows[index]["Precio"]));
                }
                else   //  Arroba
                {
                    this.tProductos.Rows[index]["Valor"] = Convert.ToInt32(
                        Convert.ToDouble(this.tProductos.Rows[index]["Arroba"]) * Convert.ToInt32(this.tProductos.Rows[index]["Precio"]));
                }
                //this.tProductos.Rows[index]["Cantidad"] = valor;
                //this.tProductos.Rows[index]["Valor"] = Convert.ToInt32(valor * Convert.ToInt32(this.tProductos.Rows[index]["Precio"]));
            }
            else
            {
                this.tProductos.Rows[index]["Precio"] = valor;

                if (MedidaCantidad)  // Kilo
                {
                    this.tProductos.Rows[index]["Valor"] = Convert.ToInt32(Convert.ToDouble(this.tProductos.Rows[index]["Kilogramo"]) * valor);
                }
                else   //  Arroba
                {
                    this.tProductos.Rows[index]["Valor"] = Convert.ToInt32(Convert.ToDouble(this.tProductos.Rows[index]["Arroba"]) * valor);
                }

                //this.tProductos.Rows[index]["Valor"] = Convert.ToInt32(valor * Convert.ToDouble(this.tProductos.Rows[index]["Cantidad"]));
            }

            this.dgvProductos.DataSource = this.miBindingSource;
            this.dgvProductos.Refresh();
            this.txtTotal.Text = UseObject.InsertSeparatorMil
                (Convert.ToInt32(this.tProductos.AsEnumerable().Sum(s => s.Field<int>("valor"))).ToString());
            TotalResumen();
            ColorearGridProducto();
        }

        private void TotalResumen()
        {
            this.txtSubtotal.Text = this.txtTotal.Text;
            this.txtTotalDesc.Text = this.txtTotalDescuento.Text;
            this.txtGranTotal.Text = UseObject.InsertSeparatorMil(
                (UseObject.RemoveSeparatorMil(this.txtSubtotal.Text) - UseObject.RemoveSeparatorMil(this.txtTotalDesc.Text)).ToString());
        }

        void CompletaEventos_Completo(CompletaArgumentosDeEvento args)
        {
            try
            {

                var proveedor_ = (DTO.Clases.Proveedor)args.MiObjeto;
                this.txtCodigoProveedor.Text = proveedor_.NitProveedor;
                this.txtCodigoProveedor_KeyPress(this.txtCodigoProveedor, new KeyPressEventArgs((char)Keys.Enter));
            }
            catch { }
        }

        void CompletaEventos_Completaz(CompletaArgumentosDeEventoz args)
        {
            try
            {
                this.txtCodigoProveedor.Text = ((Cliente)args.MiZona).NitCliente;
                this.txtCodigoProveedor_KeyPress(this.txtCodigoProveedor, new KeyPressEventArgs((char)Keys.Enter));
            }
            catch { }
        }

        private List<ProductoFacturaProveedor> Productos()
        {
            var productos = new List<ProductoFacturaProveedor>();
            foreach (DataGridViewRow row in this.dgvProductos.Rows)
            {
                if (!(row.Cells["Valor"].Value == null))
                {
                    if (Convert.ToInt32(row.Cells["Valor"].Value) > 0)
                    {
                        var producto = new ProductoFacturaProveedor();
                        producto.Producto.CodigoInternoProducto = row.Cells["Codigo"].Value.ToString();
                        producto.Producto.NombreProducto = row.Cells["Producto"].Value.ToString();

                        if (MedidaCantidad)
                        {
                            producto.Cantidad = Convert.ToDouble(row.Cells["Kilogramo"].Value);
                        }
                        else
                        {
                            producto.Cantidad = Convert.ToDouble(row.Cells["Arroba"].Value);
                        }
                        //producto.Cantidad = Convert.ToDouble(row.Cells["Cantidad"].Value);

                        producto.Valor = Convert.ToInt32(row.Cells["Precio"].Value);
                        producto.ValorReal = Convert.ToInt32(row.Cells["Valor"].Value);

                        producto.Inventario.CodigoProducto = producto.Producto.CodigoInternoProducto;
                        producto.Inventario.IdMedida = this.miBussinesProducto.ProductoMedida(producto.Producto.CodigoInternoProducto).IdValorUnidadMedida;
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
                        producto.Inventario.Cantidad = producto.Cantidad;

                        productos.Add(producto);
                    }
                }
            }
            return productos;
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
                        descuento.IdDescuento = Convert.ToInt32(row.Cells["IdDescuento"].Value);
                        descuento.CodigoInternoProducto = row.Cells["Nombre"].Value.ToString();
                        descuento.ValorDescuento = Convert.ToInt32(row.Cells["ValorDescuento"].Value);
                        descuentos.Add(descuento);
                    }
                }
            }
            return descuentos;
        }

        private void Print(FacturaProveedor factura)
        {
            try
            {
                DialogResult rta = MessageBox.Show("¿Desea imprimir el recibo de compra?", "Compra proveedor",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rta.Equals(DialogResult.Yes))
                {
                    var empresaRow = miBussinesEmpresa.PrintEmpresa().
                                     Tables[0].AsEnumerable().First();
                    var proveedor = this.miBussinesProveedor.ConsultarPrveedorBasico(factura.Proveedor.CodigoInternoProveedor);

                    Ticket ticket = new Ticket();
                    ticket.UseItem = false;

                    ticket.AddHeaderLine(empresaRow["Nombre"].ToString().ToUpper());
                    ticket.AddHeaderLine(empresaRow["Juridico"].ToString());
                    ticket.AddHeaderLine("NIT " + UseObject.InsertSeparatorMilMasDigito(empresaRow["Nit"].ToString()));
                    ticket.AddHeaderLine(empresaRow["Direccion"].ToString());
                    ticket.AddHeaderLine("Tels. " + empresaRow["Telefono"].ToString());
                    ticket.AddHeaderLine("Recibo de compra Nro. " + factura.Id.ToString());
                    ticket.AddHeaderLine("Fecha : " + factura.FechaFactura.ToShortDateString() + "  " +
                                                      factura.FechaFactura.ToShortTimeString());


                    ticket.AddHeaderLine("===================================");
                    ticket.AddHeaderLine("Proveedor : " + proveedor.RazonSocialProveedor);
                    ticket.AddHeaderLine("C.C.    : " + UseObject.InsertSeparatorMilMasDigito(proveedor.NitProveedor));
                    ticket.AddHeaderLine("===================================");
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("");

                    ticket.AddHeaderLine("DESCRIP.       CANT.  COMPRA  TOTAL");
                    ticket.AddHeaderLine("___________________________________");
                    ticket.AddHeaderLine("");
                    foreach (var producto in factura.Productos)
                    {
                        string product = producto.Producto.NombreProducto;
                        if (product.Length > 30)
                        {
                            product = product.Substring(0, 30);

                        }
                        ticket.AddHeaderLine(product);
                        ticket.AddHeaderLine("              " + producto.Cantidad.ToString() + "  " + UseObject.InsertSeparatorMil(producto.Valor.ToString()) +
                                             "  " + UseObject.InsertSeparatorMil((producto.Cantidad * producto.Valor).ToString()));
                    }
                    ticket.AddHeaderLine("");
                   // ticket.AddHeaderLine("___________________________________");
                    ticket.AddHeaderLine("------------DESCUENTOS-------------");
                    ticket.AddHeaderLine("");
                    foreach (var descuento in factura.Descuentos)
                    {
                        ticket.AddHeaderLine(descuento.CodigoInternoProducto + "    : " 
                            + UseObject.InsertSeparatorMil(descuento.ValorDescuento.ToString()));
                    }
                    ticket.AddHeaderLine("");
                   // ticket.AddHeaderLine("___________________________________");
                    ticket.AddHeaderLine("--------------RESUMEN--------------");
                    ticket.AddHeaderLine("");


                    /* foreach (DataRow dRow in tDetalle.Rows)
                     {
                         string product = dRow["Producto"].ToString();
                         if (product.Length > 30)
                         {
                             product = product.Substring(0, 30);
                         }
                         ticket.AddHeaderLine(dRow["Codigo"].ToString() + " " + product);
                         ticket.AddHeaderLine("              " + dRow["Cantidad"].ToString() + " x " + UseObject.InsertSeparatorMil(dRow["Valor_"].ToString()) +
                                              "  " + UseObject.InsertSeparatorMil(dRow["Total_"].ToString()));
                     }*/
                    
                    /*
                    var subt = UseObject.InsertSeparatorMil(factura.Valor.ToString());
                    var desctos = UseObject.InsertSeparatorMil(factura.Descuentos.Sum(s => s.ValorDescuento).ToString());
                    var total_ =
                        UseObject.InsertSeparatorMil((factura.Valor - Convert.ToInt32(factura.Descuentos.Sum(s => s.ValorDescuento))).ToString());
                    ticket.AddHeaderLine("");
                    var abno = UseObject.InsertSeparatorMil(factura.FormaPago.Valor.ToString());
                    var resta = UseObject.InsertSeparatorMil(
                        ((factura.Valor - Convert.ToInt32(factura.Descuentos.Sum(s => s.ValorDescuento))) - Convert.ToInt32(factura.FormaPago.Valor)).ToString());
                    */

                   // ticket.AddHeaderLine("");
                   // ticket.AddHeaderLine("===================================");
                   // ticket.AddHeaderLine("");

                    ticket.AddHeaderLine("SUB-TOTAL : " + UseObject.InsertSeparatorMil(factura.Valor.ToString()));
                    ticket.AddHeaderLine("DESCTOS   : " + UseObject.InsertSeparatorMil(factura.Descuentos.Sum(s => s.ValorDescuento).ToString()));
                    ticket.AddHeaderLine("TOTAL     : " +
                        UseObject.InsertSeparatorMil((factura.Valor - Convert.ToInt32(factura.Descuentos.Sum(s => s.ValorDescuento))).ToString()));
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("ABONO     : " + UseObject.InsertSeparatorMil(factura.FormaPago.Valor.ToString()));
                    ticket.AddHeaderLine("RESTA     : " + UseObject.InsertSeparatorMil(
                        ((factura.Valor - Convert.ToInt32(factura.Descuentos.Sum(s => s.ValorDescuento))) - Convert.ToInt32(factura.FormaPago.Valor)).ToString()));

                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("-----------------------------------");
                    ticket.AddHeaderLine("Software: Digital Fact Pyme");
                    ticket.AddHeaderLine("Soluciones Tecnológicas A&C.");
                    ticket.AddHeaderLine("solucionestecnologicasayc@gmail.com");
                    ticket.AddHeaderLine("");

                    ticket.PrintTicket("IMPREPOS");
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private DTO.Clases.Egreso GenerarEgreso(FacturaProveedor factura)
        {
            try
            {
                var egreso = new DTO.Clases.Egreso();
                egreso.IdCaja = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_caja"));
                egreso.IdUsuario = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_user"));
                egreso.Numero = miBussinesConsecutivo.Consecutivo("Egreso");
                egreso.Fecha = DateTime.Now;
                egreso.TipoBeneficiario = this.miBussinesBeneficio.BeneficiarioNit(this.CedulaProveedor).IdTipoCliente;
                egreso.Pagos.Add(new DTO.Clases.FormaPago { IdFormaPago = 1, Valor = Convert.ToInt32(factura.FormaPago.Valor) });
                egreso.Total = Convert.ToInt32(factura.FormaPago.Valor);
                egreso.Estado = true;
                egreso.Cuentas.Add(new ConceptoEgreso
                {
                    IdCuenta = Convert.ToInt32(AppConfiguracion.ValorSeccion("ctaEgreso")),
                    Nombre = "Abono a compra de proveedor número: " + factura.Id,
                    Numero = egreso.Total.ToString()
                });
                egreso.Id = this.miBussinesEgreso.IngresarEgreso(egreso);
                return egreso;
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
                return null;
            }
        }

        private void PrintEgresoPos(DTO.Clases.Egreso egreso)
        {
            try
            {
                DialogResult rta = MessageBox.Show("¿Desea imprimir el comprobante de egreso?", "Compra proveedor",
                                   MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rta.Equals(DialogResult.Yes))
                {
                    // var miBussinesCaja = new BussinesCaja();
                    var miBussinesEmpresa = new BussinesEmpresa();
                    var miBussinesUsuario = new BussinesUsuario();
                    var miBussinesBeneficia = new BussinesBeneficio();

                    var empresaRow = miBussinesEmpresa.PrintEmpresa().
                                 Tables[0].AsEnumerable().First();
                    // var caja = miBussinesCaja.CajaId(egreso.IdCaja);
                    // var usuario = miBussinesUsuario.ConsultaUsuario(egreso.IdUsuario).AsEnumerable().First();
                    var beneficio = miBussinesBeneficia.BeneficiarioId(egreso.TipoBeneficiario);

                    Ticket ticket = new Ticket();

                    ticket.AddHeaderLine(empresaRow["Nombre"].ToString().ToUpper());
                    ticket.AddHeaderLine(empresaRow["Juridico"].ToString());
                    ticket.AddHeaderLine("NIT " + UseObject.InsertSeparatorMilMasDigito(empresaRow["Nit"].ToString()));
                    ticket.AddHeaderLine(empresaRow["Direccion"].ToString());
                    ticket.AddHeaderLine("Tels. " + empresaRow["Telefono"].ToString());
                    ticket.AddHeaderLine("Fecha : " + egreso.Fecha.ToShortDateString());// +
                    //  "    Caja : " + caja.Numero.ToString());
                    // ticket.AddHeaderLine("Cajero(a)  :  " + usuario["nombre"].ToString());
                    ticket.AddHeaderLine("===================================");
                    ticket.AddHeaderLine("COMPROBANTE DE EGRESO Nro " + egreso.Numero);
                    ticket.AddHeaderLine("===================================");
                    ticket.AddHeaderLine("Remite a : " + beneficio.NombresCliente.ToUpper());
                    ticket.AddHeaderLine("NIT: " + UseObject.InsertSeparatorMilMasDigito(beneficio.NitCliente));
                    ticket.AddHeaderLine("===================================");
                    foreach (var cuenta in egreso.Cuentas)
                    {
                        ticket.AddItem("",
                                       cuenta.Nombre,
                                       UseObject.InsertSeparatorMil(cuenta.Numero));
                    }

                    /*var sTotal = 0;
                    var retencion = 0;
                    var qConcepto = egreso.Cuentas.Where(d => d.IdCuenta != 0);
                    var qRetenciones = egreso.Cuentas.Where(d => d.IdCuenta.Equals(0));
                    if (qConcepto.ToArray().Length != 0)
                    {
                        sTotal = qConcepto.Sum(d => Convert.ToInt32(d.Numero));
                    }
                    if (qRetenciones.ToArray().Length != 0)
                    {
                        retencion = qRetenciones.Sum(d => Convert.ToInt32(d.Numero));
                    }*/
                    // ticket.AddTotal("SUBTOTAL     : ", UseObject.InsertSeparatorMil(sTotal.ToString()));
                    //ticket.AddTotal("RETENCIONES  : ", UseObject.InsertSeparatorMil(retencion.ToString()));
                    ticket.AddTotal("TOTAL        : ", UseObject.InsertSeparatorMil(egreso.Total.ToString()));
                    ticket.AddTotal("", "");
                    ticket.AddTotal("", "");

                    ticket.AddTotal("FORMAS DE PAGO", "");
                    ticket.AddTotal("", "");
                    var pEfectivo = egreso.Pagos.Where(d => d.IdFormaPago.Equals(1));
                    var pCheque = egreso.Pagos.Where(d => d.IdFormaPago.Equals(2));
                    var pTransaccion = egreso.Pagos.Where(d => d.IdFormaPago.Equals(4));
                    if (pEfectivo.ToArray().Length != 0)
                    {
                        ticket.AddTotal("EFECTIVO  : ", UseObject.InsertSeparatorMil(pEfectivo.Sum(d => d.Valor).ToString()));
                    }
                    if (pCheque.ToArray().Length != 0)
                    {
                        ticket.AddTotal("CHEQUE    : ", UseObject.InsertSeparatorMil(pCheque.Sum(d => d.Valor).ToString()));
                    }
                    if (pTransaccion.ToArray().Length != 0)
                    {
                        ticket.AddTotal("TRANSACCIÓN :", UseObject.InsertSeparatorMil(pTransaccion.Sum(d => d.Valor).ToString()));
                    }

                    ticket.AddFooterLine("===================================");
                    ticket.AddFooterLine(".");
                    ticket.AddFooterLine(".");
                    ticket.AddFooterLine("___________________________________");
                    ticket.AddFooterLine("Aprobado:");
                    ticket.AddFooterLine(".");
                    ticket.AddFooterLine("___________________________________");
                    ticket.AddFooterLine("Beneficiario");
                    ticket.AddFooterLine(".");
                    ticket.AddFooterLine(".");

                    ticket.AddFooterLine("Software: Digital Fact Pyme");
                    ticket.AddFooterLine("Soluciones Tecnológicas A&C.");
                    ticket.AddHeaderLine("solucionestecnologicasayc@gmail.com");
                    ticket.AddFooterLine(".");

                    ticket.PrintTicket("IMPREPOS");
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            this.tsGuardar_Click(this.tsGuardar, new EventArgs());
        }
        
    }
}