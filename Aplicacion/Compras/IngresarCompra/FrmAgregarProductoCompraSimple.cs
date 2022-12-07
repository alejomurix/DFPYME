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
    public partial class FrmAgregarProductoCompraSimple : Form
    {
        public int IdCompra { set; get; }

        private bool MedidaCantidad;

        private double KiloPorArroba;

        private BindingSource miBindingSource;

        private DataTable tProductos;

        public DTO.Clases.Proveedor Proveedor { set; get; }

        private BussinesProducto miBussinesProducto;

        private BussinesColor miBussinesColor;

        private BussinesCompraSimple miBussinesCompraSimple;

        private BussinesInventario miBussinesInventario;

        private BussinesEmpresa miBussinesEmpresa;

        public FrmAgregarProductoCompraSimple()
        {
            InitializeComponent();
            this.KiloPorArroba = 12.5;
            this.miBindingSource = new BindingSource();
            this.Proveedor = new DTO.Clases.Proveedor();
            this.miBussinesProducto = new BussinesProducto();
            this.miBussinesColor = new BussinesColor();
            this.miBussinesCompraSimple = new BussinesCompraSimple();
            this.miBussinesInventario = new BussinesInventario();
            this.miBussinesEmpresa = new BussinesEmpresa();
            try
            {
                this.MedidaCantidad = Convert.ToBoolean(AppConfiguracion.ValorSeccion("medidaCantidadCompraSimple"));

                this.tProductos = this.miBussinesProducto.Productos();
                this.miBindingSource.DataSource = this.tProductos;
                this.dgvProductos.DataSource = this.miBindingSource;
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void FrmAgregarProductoCompraSimple_Load(object sender, EventArgs e)
        {
            try
            {
                //CompletaEventos.Completa += new CompletaEventos.CompletaAccion(CompletaEventos_Completo);
                //CompletaEventos.Completaz += new CompletaEventos.CompletaAccionz(CompletaEventos_Completaz);

                
                ColorearGridProducto();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void FrmAgregarProductoCompraSimple_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.F2))
            {
                this.tsGuardar_Click(this.tsGuardar, new EventArgs());
            }
            else
            {
                if (e.KeyData.Equals(Keys.Escape))
                {
                    this.Close();
                }
            }
        }

        private void tsGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                 DialogResult rta = MessageBox.Show("¿Está seguro(a) de agregar los productos a la compra?", "Compras",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                 if (rta.Equals(DialogResult.Yes))
                 {
                     foreach (var producto in Productos())
                     {
                         this.miBussinesCompraSimple.IngresarProductoCompra(producto);
                         this.miBussinesInventario.ActualizarInventario(producto.Inventario, false);
                     }
                     int diferencia = this.miBussinesCompraSimple.AjustarCompraPagos(this.IdCompra);
                    // OptionPane.MessageInformation("La edición se guardó con éxito.");
                     OptionPane.MessageInformation("Los productos se agregaron con éxito.");
                     if (diferencia > 0)
                     {
                         Print(diferencia);
                     }
                     CompletaEventos.CapturaEvento(new ObjectAbstract { Id = 555666889 });

                    
                     this.miBindingSource.DataSource = this.miBussinesProducto.Productos();
                     this.dgvProductos.DataSource = this.miBindingSource;
                     ColorearGridProducto();
                     this.txtTotal.Text = "0";
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

        


        

        private void dgvProductos_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (this.dgvProductos.IsCurrentCellDirty)
            {
                this.dgvProductos.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgvProductos_DataError(object sender, DataGridViewDataErrorEventArgs e) { }

        private void dgvProductos_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            var index = e.ColumnIndex;
            if (e.ColumnIndex.Equals(4))  // Precio
            {
                ActualizarInformacion(true, e.ColumnIndex, e.RowIndex, NumeroFormato(e.FormattedValue.ToString(), false));
                return;
            }
            else
            {
                if (e.ColumnIndex.Equals(5) || e.ColumnIndex.Equals(6))  // Cantidad (Kilo o Arroba)
                {
                    ActualizarInformacion(false, e.ColumnIndex, e.RowIndex, NumeroFormato(e.FormattedValue.ToString(), true));
                    return;
                }
            }
        }


        private void ColorearGridProducto()
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
                if (columnIndex.Equals(5)) // Kilo
                {
                    this.tProductos.Rows[index]["Kilogramo"] = valor;
                    var d_ = decimal.Round(Convert.ToDecimal(valor / KiloPorArroba), 2);
                    this.tProductos.Rows[index]["Arroba"] = decimal.Round(Convert.ToDecimal(valor / KiloPorArroba), 2);
                }
                else
                {
                    if (columnIndex.Equals(6)) // Arroba
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
            //TotalResumen();
            ColorearGridProducto();
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
                        producto.IdFactura = this.IdCompra;
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