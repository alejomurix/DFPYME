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

namespace Aplicacion.Compras.PreIngreso
{
    public partial class FrmFacturar : Form
    {
        private enum Calculo { Util_, Pventa, Descto };

        private bool DiscountD1;

        public int Id { set; get; }

        private Empresa Empresa;

        private FacturaProveedor Factura;

        private DataTable TProductos;

        private List<Item> Items;

        private BindingSource bindingSource;

        private DTO.Clases.Proveedor Proveedor;

        private RetencionConcepto Retencion;

        private List<RetencionConcepto> Retenciones;

        private Producto Producto;

        private ToolTip miToolTip;

        private ErrorProvider miError;

        private bool Transfer;

        private bool AdicionProducto;

        private bool Edit;

        private bool DefaultUtilPercentage;

        private bool UtilidadAntesIva;

        private bool CalculoUtilMultiplicado;

        private bool AproxPrecio;

        private bool RedondearPrecio2;

        private bool UtilMatch;

        private bool Util2Match;

        private bool Util3Match;

        private bool PrecioVentaMatch;

        private bool PrecioVenta2Match;

        private bool PrecioVenta3Match;

        private bool Descto2Match;

        private bool Descto3Match;

        private BussinesEmpresa miBussinesEmpresa;

        private BussinesEstado miBussinesEstado;

        private BussinesFacturaProveedor miBussinesFactura;

        private BussinesProveedor miBussinesProveedor;

        private BussinesProducto miBussinesProducto;

        private BussinesConsecutivo miBussinesConsecutivo;

        private BussinesLote miBussinesLote;

        public FrmFacturar()
        {
            InitializeComponent();
            try
            {
                this.DiscountD1 = Convert.ToBoolean(AppConfiguracion.ValorSeccion("costo_discount_d1"));

                this.miToolTip = new ToolTip();
                this.miError = new ErrorProvider();
                this.Transfer = false;
                this.AdicionProducto = true;
                this.Edit = false;
                this.UtilMatch = false;
                this.Util2Match = false;
                this.Util3Match = false;
                this.PrecioVentaMatch = false;
                this.PrecioVenta2Match = false;
                this.PrecioVenta3Match = false;
                this.Descto2Match = false;
                this.Descto3Match = false;
                this.bindingSource = new BindingSource();
                this.Retencion = new RetencionConcepto();
                this.Retenciones = new List<RetencionConcepto>();
                this.miBussinesEmpresa = new BussinesEmpresa();
                this.miBussinesEstado = new BussinesEstado();
                this.miBussinesFactura = new BussinesFacturaProveedor();
                this.miBussinesProveedor = new BussinesProveedor();
                this.miBussinesProducto = new BussinesProducto();
                this.miBussinesConsecutivo = new BussinesConsecutivo();
                this.miBussinesLote = new BussinesLote();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void FrmFacturar_Load(object sender, EventArgs e)
        {
            try
            {
                CompletaEventos.Completa += new CompletaEventos.CompletaAccion(CompletaEventos_Completa);
                CompletaEventos.Completabo += new CompletaEventos.CompletaAccionbo(CompletaEventos_Completabo);

                this.Empresa = this.miBussinesEmpresa.ObtenerEmpresa();
                this.Factura = this.miBussinesFactura.Compra(this.Id);
                this.txtCodigoProveedor.Text = this.Factura.Proveedor.NitProveedor;
                this.txtCodigoProveedor_KeyPress(this.txtCodigoProveedor, new KeyPressEventArgs((char)Keys.Enter));
                this.txtNumeroFactura.Text = this.Factura.Numero;
                this.dtpFecha.Value = this.Factura.FechaIngreso;

                this.UtilidadAntesIva = Convert.ToBoolean(AppConfiguracion.ValorSeccion("utilidad_mas_iva"));
                this.CalculoUtilMultiplicado = Convert.ToBoolean(AppConfiguracion.ValorSeccion("calculo_util_multiplica"));
                this.AproxPrecio = Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio"));
                this.RedondearPrecio2 = Convert.ToBoolean(AppConfiguracion.ValorSeccion("redondeo_precio_dos"));

                DefaultUtilPercentage = Convert.ToBoolean(AppConfiguracion.ValorSeccion("default_util_percent"));

                this.cbFormaPago.DataSource = this.miBussinesEstado.Lista();
                this.cbFormaPago.SelectedIndex = 1;
                var lst = new List<Inventario.Producto.Criterio>();
                lst.Add(new Inventario.Producto.Criterio
                {
                    Id = 1,
                    Nombre = "Factura"
                });
                lst.Add(new Inventario.Producto.Criterio
                {
                    Id = 2,
                    Nombre = "Remisión"
                });
                lst.Add(new Inventario.Producto.Criterio
                {
                    Id = 3,
                    Nombre = "Documento Equivalente"
                });
                this.cbRemision.DataSource = lst;

                this.dgvArticulos.AutoGenerateColumns = false;
                this.dgvArticulos.DataSource = this.bindingSource;
                //this.bindingSource.DataSource = this.Items;

                ///this.TProductos = this.miBussinesFactura.ProductosCompra(this.Id);
                ///this.bindingSource.DataSource = this.TProductos;
                
                /*
                this.Items = this.miBussinesFactura.ItemsCompra(this.Id);
                this.bindingSource.DataSource = this.Items;
                */

                //this.dgvArticulos_CellClick(this.dgvArticulos, null);
                CargarDatos();

                //this.Items = this.miBussinesFactura.ItemsCompra(this.Id);
                //this.dgvArticulos.DataSource = this.Items;
                //this.bindingSource.DataSource = this.Items;
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void FrmFacturar_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.F2:
                    {
                        this.tsGuardar_Click(this.tsGuardar, new EventArgs());
                        break;
                    }
                case Keys.F3:
                    {
                        this.tsAgregar_Click(this.tsAgregar, new EventArgs());
                        break;
                    }
                case Keys.F4:
                    {
                        this.tsBtnEditar_Click(this.tsBtnEditar, new EventArgs());
                        break;
                    }
                case Keys.F5:
                    {
                        this.tsEliminar_Click(this.tsEliminar, new EventArgs());
                        break;
                    }
                case Keys.F6:
                    {
                        this.tsBtnEditarValores_Click(this.tsBtnEditarValores, new EventArgs());
                        break;
                    }
                case Keys.Escape:
                    {
                        this.Close();
                        break;
                    }
            }
        }

        private void FrmFacturar_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult rta = MessageBox.Show("¿Está seguro(a) de salir?", "Preingreso",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (rta.Equals(DialogResult.Yes))
            {
                e.Cancel = false;
                CompletaEventos.CapturaEvento(false);
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void tsGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(this.txtNumeroFactura.Text))
                {
                    this.miError.SetError(this.txtNumeroFactura, null);
                    if (ValidarFecha())
                    {
                        this.miError.SetError(this.dtpLimite, null);

                        DialogResult rta = MessageBox.Show("¿Esta seguro de guardar la compra?", "Ingreso de compra",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (rta.Equals(DialogResult.Yes))
                        {
                            var factura = new FacturaProveedor();
                            bool aplicaRete = false;
                            if (!UseObject.RemoveSeparatorMil(txtRetencion.Text).Equals(0))
                            {
                                aplicaRete = true;
                            }
                            factura.Proveedor.CodigoInternoProveedor = this.Proveedor.CodigoInternoProveedor;
                            factura.EstadoFactura.Id = Convert.ToInt32(cbFormaPago.SelectedValue);
                            factura.Caja.Id = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_caja"));
                            factura.Usuario.Id = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_user"));
                            factura.Tipo = Convert.ToInt32(cbRemision.SelectedValue);
                            if (Convert.ToInt32(cbRemision.SelectedValue).Equals(3))
                            {
                                factura.Numero = this.miBussinesConsecutivo.Consecutivo("Documento");
                            }
                            else
                            {
                                factura.Numero = this.txtNumeroFactura.Text;
                            }
                            factura.FechaFactura = this.dtpFecha.Value;
                            factura.FechaLimite = this.dtpLimite.Value;
                            factura.FechaIngreso = DateTime.Now;
                            factura.Retencion = this.Retencion;
                            if (Convert.ToInt32(cbRemision.SelectedValue).Equals(3))
                            {
                                factura.EsFactura = false;
                            }
                            else
                            {
                                factura.EsFactura = true;
                            }
                            factura.Ajuste = Convert.ToDouble(txtAjuste.Text.Replace('.', ','));
                            if (!(this.txtNota.Text == "NOTA"))
                            {
                                factura.Nota = this.txtNota.Text;
                            }
                            /**foreach (Item item in this.Items)
                            {
                                producto.Producto.CodigoInternoProducto = item.Codigo;

                                factura.Productos.Add(new ProductoFacturaProveedor 
                                { 
                                    Producto = new Producto 
                                    { 
                                        CodigoInternoProducto = item.Codigo ,
                                        ValorIva = item.IVA
                                    } 
                                });
                            }
                            */
                            foreach (DataGridViewRow gRow in this.dgvArticulos.Rows)
                            {
                                var producto = new ProductoFacturaProveedor();
                                producto.Producto.CodigoInternoProducto = gRow.Cells["Codigo"].Value.ToString();
                                producto.Cantidad = Convert.ToDouble(gRow.Cells["Cantidad"].Value);
                                producto.Producto.ValorIva = Convert.ToDouble(gRow.Cells["Iva"].Value);
                                

                                //if (this.Proveedor.IdRegimen.Equals(1))
                                //{
                                   // producto.Producto.ValorCosto = producto.Producto.ValorVentaProducto = Convert.ToDouble(gRow.Cells["Costo"].Value);
                                //}
                                //else
                                //{
                                //    double valorIva = ((Producto)this.miBussinesProducto.ProductoBasico(producto.Producto.CodigoInternoProducto)[0]).ValorIva;
                                //    producto.Producto.ValorVentaProducto = Convert.ToDouble(gRow.Cells["Costo"].Value);
                                //    producto.Producto.ValorCosto =
                                 //       Convert.ToInt32(Convert.ToInt32(gRow.Cells["Costo"].Value) / (1 + (valorIva / 100)));
                                //}

                                producto.Producto.Descuento = Convert.ToDouble(gRow.Cells["D1"].Value);
                                producto.ImpoConsumo = Convert.ToDouble(gRow.Cells["Impoconsumo"].Value);

                                producto.Producto.ValorCosto = producto.Producto.ValorVentaProducto = Convert.ToDouble(gRow.Cells["Costo"].Value); /// valor de costo sin descuentos.
                                                                                                                                                   // modificación porque se debe almacenar el costo sin iva
                                                                                                                                                   // independientemente de si es reg. simplificado o comun
                                if (this.DiscountD1)
                                {
                                    //item.CostoMenosD1 = Math.Round(item.Costo - (item.Costo * item.Descuento / 100), 2);
                                    producto.Producto.ValorCosto = Math.Round(producto.Producto.ValorCosto -
                                        (producto.Producto.ValorCosto * producto.Producto.Descuento / 100), 2);
                                }

                                producto.ValorReal = Convert.ToDouble(gRow.Cells["ValorUnitario"].Value) - Convert.ToDouble(gRow.Cells["Impoconsumo"].Value);
                                producto.ValorReal = Math.Round(producto.ValorReal / (1 + (producto.Producto.ValorIva / 100)), 2);
                                
                                
                                //producto.Producto.ValorCosto = producto.Producto.ValorVentaProducto = Convert.ToDouble(gRow.Cells["Costo"].Value);

                                //producto.Producto.ValorCosto = Convert.ToInt32(Convert.ToDouble(gRow.Cells["Costo"].Value) / (1 + (producto.Producto.ValorIva / 100)));
                                //producto.Producto.ValorVentaProducto = producto.Producto.ValorCosto;
                                // if (gRow.Cells["ActVenta"].Value != null)
                                 //{
                                 //    producto.Producto.ValorVentaProducto = Convert.ToInt32(gRow.Cells["ActVenta"].Value);
                                // }
                                // else
                                // {
                                //     producto.Producto.ValorVentaProducto = Convert.ToInt32(gRow.Cells["Venta"].Value);
                                // }
                                producto.Lote.Id = Convert.ToInt32(gRow.Cells["IdLote"].Value);
                                producto.Inventario.CodigoProducto = producto.Producto.CodigoInternoProducto;
                                producto.Inventario.IdMedida = Convert.ToInt32(gRow.Cells["IdMedida"].Value);
                                producto.Inventario.IdColor = Convert.ToInt32(gRow.Cells["IdColor"].Value);
                                producto.Inventario.Cantidad = producto.Cantidad;
                                factura.Productos.Add(producto);
                            }
                            this.miBussinesFactura.IngresarFactura(factura, factura.EsFactura, aplicaRete);
                            /*  foreach (DataGridViewRow gRow in this.dgvArticulos.Rows)
                              {
                                  if (gRow.Cells["ActVenta"].Value != null)
                                  {
                                      if (Convert.ToInt32(gRow.Cells["ActVenta"].Value) > 0)
                                      {
                                          this.miBussinesProducto.EditarPrecioDeVenta
                                              (gRow.Cells["Codigo"].Value.ToString(), Convert.ToInt32(gRow.Cells["ActVenta"].Value),
                                              Utilidad(Convert.ToDouble(gRow.Cells["Costo"].Value), Convert.ToDouble(gRow.Cells["Iva"].Value), Convert.ToInt32(gRow.Cells["ActVenta"].Value)));
                                      }
                                  }
                              }*/
                            this.miBussinesFactura.EliminarCompraTemporal(this.Id);
                            OptionPane.MessageInformation("Los datos se almacenaron con exito.");
                            CompletaEventos.CapturaEvento(new ObjectAbstract { Id = 4455 });
                            this.Close();
                        }
                    }
                    else
                    {
                        this.miError.SetError(this.dtpLimite, "La fecha limite debe ser superior.");
                    }
                }
                else
                {
                    this.miError.SetError(this.txtNumeroFactura, "El número es requerido.");
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void tsAgregar_Click(object sender, EventArgs e)
        {
            this.AdicionProducto = true;
           // this.Transfer = true;
            var frmEdicion = new FrmAgregarProductoCompra();
            frmEdicion.ID = this.Id;
            frmEdicion.MdiParent = this.MdiParent;
            frmEdicion.Show();
            ///frmEdicion.ShowDialog();
        }

        private void tsBtnEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvArticulos.RowCount != 0)
            {
                /*this.AdicionProducto = false;
                this.Transfer = true;
                var frmEdicion = new FrmEditarProductoCompra();
                frmEdicion.ShowDialog();*/
            }
        }

        private void tsEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvArticulos.RowCount != 0)
                {
                    DialogResult rta = MessageBox.Show("¿Esta seguro(a) de elminar el articulo?", "Pre ingreso",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (rta.Equals(DialogResult.Yes))
                    {
                        var id = Convert.ToInt32(this.dgvArticulos.CurrentRow.Cells["IdProducto"].Value);
                        this.miBussinesFactura.DeleteItem(id);
                        /*
                        var query = (from datos in this.TProductos.AsEnumerable()
                                     where datos.Field<int>("Id") == id
                                     select datos).Single();
                        var index = this.TProductos.Rows.IndexOf(query);
                        this.TProductos.Rows.RemoveAt(index);
                        */
                        /*this.miBussinesFactura.EliminarProductoTemporal(Convert.ToInt32(this.dgvArticulos.CurrentRow.Cells["IdProducto"].Value));
                         this.dgvArticulos.DataSource = this.miBussinesFactura.ProductosCompra(this.Id);*/
                        CargarDatos();
                    }
                }
                else
                {
                    OptionPane.MessageInformation("No hay registros para eliminar.");
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void tsBtnEditarValores_Click(object sender, EventArgs e)
        {
            if (this.dgvArticulos.RowCount != 0)
            {
                this.dgvArticulos.Columns["Cantidad"].ReadOnly = false;
                this.dgvArticulos.Columns["Costo"].ReadOnly = false;
                this.dgvArticulos.Columns["ActVenta"].ReadOnly = false;
                this.dgvArticulos.Columns["Impoconsumo"].ReadOnly = false;
               // this.Edit = true;
                //this.dgvArticulos.Columns["Iva"].ReadOnly = false;
                //this.dgvArticulos.Columns["ActVenta"].ReadOnly = false;

                this.dgvArticulos.Columns["D1"].ReadOnly = false;
                this.dgvArticulos.Columns["D2"].ReadOnly = false;
            }
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
                    this.Proveedor = this.miBussinesProveedor.ConsultarPrveedorBasico(this.txtCodigoProveedor.Text);
                    if (this.Proveedor.CodigoInternoProveedor.Equals(0))
                    {
                        this.miError.SetError(this.txtNombreProveedor, "El proveedor no existe.");
                    }
                    else
                    {
                        this.miError.SetError(this.txtNombreProveedor, null);
                        this.txtNombreProveedor.Text = this.Proveedor.CodigoInternoProveedor + " - NIT: " + this.Proveedor.NitProveedor
                            + " - " + this.Proveedor.RazonSocialProveedor;
                        this.txtCodigoProveedor.Text = "";
                        this.txtNumeroFactura.Focus();
                    }
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {
            var formProveedor = new Proveedor.frmProveedor();
            formProveedor.Extension = true;
            formProveedor.tcProveedor.SelectTab(1);
            // FormProveedor = true;
            formProveedor.MdiParent = this.MdiParent;
            formProveedor.Show();
            // AddProveedor = true;
        }

        private void cbRemision_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                switch (Convert.ToInt32(cbRemision.SelectedValue))
                {
                    case 1:
                        {
                            this.txtNumeroFactura.ReadOnly = false;
                            this.txtNumeroFactura.Text = "";
                            break;
                        }
                    case 2:
                        {
                            this.txtNumeroFactura.ReadOnly = false;
                            this.txtNumeroFactura.Text = "";
                            break;
                        }
                    case 3:
                        {
                            this.txtNumeroFactura.ReadOnly = true;
                            this.txtNumeroFactura.Text = miBussinesConsecutivo.Consecutivo("Documento");
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void dgvArticulos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.dgvArticulos.RowCount != 0)
                {
                    LoadPrice();

                    /**
                    var id = Convert.ToInt32(this.dgvArticulos.CurrentRow.Cells["IdProducto"].Value);
                        //Convert.ToInt32(this.dgvArticulos.Rows[rowIndex].Cells["IdProducto"].Value);
                    var query = (from datos in this.TProductos.AsEnumerable()
                                 where datos.Field<int>("Id") == id
                                 select datos).Single();
                    var index = this.TProductos.Rows.IndexOf(query);

                    this.Producto = this.miBussinesProducto.ProductoCompleto(this.dgvArticulos.CurrentRow.Cells["Codigo"].Value.ToString());
                    this.Producto.Impoconsumo = Convert.ToDouble(this.TProductos.Rows[index]["Impoconsumo"]);

                    var ultimoRegCompra = this.miBussinesFactura.UltimoRegistroCompra(Producto.CodigoInternoProducto);

                    this.txtCantidad.Text = ultimoRegCompra.Cantidad.ToString();
                    this.txtCostoBase.Text = UseObject.InsertSeparatorMil(ultimoRegCompra.Valor.ToString().Replace('.', ','));
                    this.txtCostoMasIva.Text = UseObject.InsertSeparatorMil(
                      Math.Round((ultimoRegCompra.Valor + (ultimoRegCompra.Valor * ultimoRegCompra.Producto.ValorIva / 100)), 2).ToString().Replace('.', ','));
                    this.txtPrecioVenta.Text = UseObject.InsertSeparatorMil(Producto.ValorVentaProducto.ToString());

                    this.lblProducto.Text = Producto.NombreProducto;
                    double costo =
                        Convert.ToDouble(this.TProductos.Rows[index]["Valor"]); // +Convert.ToDouble(this.TProductos.Rows[index]["Impoconsumo"]);  //ValorMasIva
                    var costoMasIva = Math.Round((costo + Math.Round((costo * Producto.ValorIva / 100), 4)), 2);
                    var costoMasIvaMasIco = costoMasIva + this.Producto.Impoconsumo;

                    this.Producto.ValorCosto = costo;

                    //this.txtCostoNoIvaP1.Text = UseObject.InsertSeparatorMil(costo.ToString().Replace('.', ','));           // editado 21/04/2019
                    this.txtCostoNoIvaP1.Text = UseObject.InsertSeparatorMil(costoMasIvaMasIco.ToString().Replace('.', ',')); // editado 21/04/2019
                    this.txtCostoNoIvaP2.Text = this.txtCostoNoIvaP3.Text = this.txtCostoNoIvaP4.Text = this.txtCostoNoIvaP1.Text;

                    this.txtUtilidadP1.Text = Producto.UtilidadPorcentualProducto.ToString();
                    this.txtUtilidadP2.Text = Producto.Utilidad2.ToString();
                    this.txtUtilidadP3.Text = Producto.Utilidad3.ToString();

                    var valUtil = 0.0;
                    var valIvaUtil = 0.0;
                    var venta = 0;

                    if (!this.UtilidadAntesIva)  // Utilidad antes de IVA.
                    {
                        if (this.CalculoUtilMultiplicado)  // Incremento de utilidad multiplic.
                        {
                            valUtil = Math.Round((costo * Producto.UtilidadPorcentualProducto / 100), 2);
                        }
                        else
                        {
                            valUtil = Math.Round(((costo / ((100 - Producto.UtilidadPorcentualProducto) / 100)) - costo), 2);
                        }
                        //valIvaUtil = Math.Round((valUtil * this.MiProducto.ValorIva / 100), 2);
                        if (this.Empresa.Regimen.IdRegimen.Equals(1))
                        {
                            valIvaUtil = Math.Round((valUtil * Producto.ValorIva / 100), 2);
                            //venta = Convert.ToInt32(costoMasIva + valUtil + valIvaUtil);
                        }
                        else
                        {
                            //venta = Convert.ToInt32(costoMasIva + valUtil);
                        }
                        venta = Convert.ToInt32(costoMasIva + valUtil + valIvaUtil);
                    }
                    else
                    {
                        if (this.CalculoUtilMultiplicado)  // Incremento de utilidad multiplic.
                        {
                            valUtil = Math.Round((costoMasIva * Producto.UtilidadPorcentualProducto / 100), 2);
                        }
                        else
                        {
                            valUtil = Math.Round(((costoMasIva / ((100 - Producto.UtilidadPorcentualProducto) / 100)) - costoMasIva), 2);
                        }
                        venta = Convert.ToInt32(costoMasIva + valUtil + valIvaUtil);
                    }

                    venta += Convert.ToInt32(this.Producto.Impoconsumo);

                    this.txtValorUtilidadP1.Text = valUtil.ToString().Replace(',', '.');
                    this.txtValorVentaP1.Text = Producto.ValorVentaProducto.ToString();
                    this.txtValorSugeridoP1.Text = UseObject.Aproximar(venta, AproxPrecio).ToString().Replace(',', '.');

                    // precio 2
                    valUtil = 0.0;
                    valIvaUtil = 0.0;
                    venta = 0;

                    if (!this.UtilidadAntesIva)  // Utilidad antes de IVA.
                    {
                        if (this.CalculoUtilMultiplicado)  // Incremento de utilidad multiplic.
                        {
                            valUtil = Math.Round((costo * Producto.Utilidad2 / 100), 2);
                        }
                        else
                        {
                            valUtil = Math.Round(((costo / ((100 - Producto.Utilidad2) / 100)) - costo), 2);
                        }
                        //valIvaUtil = Math.Round((valUtil * this.MiProducto.ValorIva / 100), 2);
                        if (this.Empresa.Regimen.IdRegimen.Equals(1))
                        {
                            valIvaUtil = Math.Round((valUtil * Producto.ValorIva / 100), 2);
                            //venta = Convert.ToInt32(costoMasIva + valUtil + valIvaUtil);
                        }
                        else
                        {
                            //venta = Convert.ToInt32(costoMasIva + valUtil);
                        }
                    }
                    else
                    {
                        if (this.CalculoUtilMultiplicado)  // Incremento de utilidad multiplic.
                        {
                            valUtil = Math.Round((costoMasIva * Producto.Utilidad2 / 100), 2);
                        }
                        else
                        {
                            valUtil = Math.Round(((costoMasIva / ((100 - Producto.Utilidad2) / 100)) - costoMasIva), 2);
                        }
                    }
                    venta = Convert.ToInt32(costoMasIva + valUtil + valIvaUtil) + Convert.ToInt32(this.Producto.Impoconsumo);

                    this.txtValorUtilidadP2.Text = valUtil.ToString().Replace(',', '.');

                    this.txtValorSugeridoP2.Text = UseObject.Aproximar(venta, AproxPrecio).ToString().Replace(',', '.');

                    int pVenta2 = Convert.ToInt32(this.txtValorVentaP1.Text) - Convert.ToInt32(this.Producto.Impoconsumo);  // adicion 21-04-2019
                    pVenta2 = Convert.ToInt32(pVenta2 - (pVenta2 * Producto.DescuentoMayor / 100));                         // adicion 21-04-2019
                                   
                    pVenta2 += Convert.ToInt32(this.Producto.Impoconsumo);

                    if (this.RedondearPrecio2)  //  Adición de codigo 22/05/2019
                    {
                        pVenta2 = UseObject.Aproximar(pVenta2, AproxPrecio);
                    }

                    this.txtValorVentaP2.Text = pVenta2.ToString();
                    this.txtDescuentoP2DB.Text = this.txtDescuentoP2.Text = Producto.DescuentoMayor.ToString().Replace(',', '.');
                    
                    // precio 3
                    valUtil = 0.0;
                    valIvaUtil = 0.0;
                    venta = 0;

                    if (!this.UtilidadAntesIva)  // Utilidad antes de IVA.
                    {
                        if (this.CalculoUtilMultiplicado)  // Incremento de utilidad multiplic.
                        {
                            valUtil = Math.Round((costo * Producto.Utilidad3 / 100), 2);
                        }
                        else
                        {
                            valUtil = Math.Round(((costo / ((100 - Producto.Utilidad3) / 100)) - costo), 2);
                        }
                        //valIvaUtil = Math.Round((valUtil * this.MiProducto.ValorIva / 100), 2);
                        if (this.Empresa.Regimen.IdRegimen.Equals(1))
                        {
                            valIvaUtil = Math.Round((valUtil * Producto.ValorIva / 100), 2);
                            //venta = Convert.ToInt32(costoMasIva + valUtil + valIvaUtil);
                        }
                        else
                        {
                            //venta = Convert.ToInt32(costoMasIva + valUtil);
                        }
                    }
                    else
                    {
                        if (this.CalculoUtilMultiplicado)  // Incremento de utilidad multiplic.
                        {
                            valUtil = Math.Round((costoMasIva * Producto.Utilidad3 / 100), 2);
                        }
                        else
                        {
                            valUtil = Math.Round(((costoMasIva / ((100 - Producto.Utilidad3) / 100)) - costoMasIva), 2);
                        }
                    }
                    venta = Convert.ToInt32(costoMasIva + valUtil + valIvaUtil) + Convert.ToInt32(this.Producto.Impoconsumo);

                    this.txtValorUtilidadP3.Text = valUtil.ToString().Replace(',', '.');

                    this.txtValorSugeridoP3.Text = UseObject.Aproximar(venta, AproxPrecio).ToString().Replace(',', '.');

                    int pVenta3 = Convert.ToInt32(this.txtValorVentaP1.Text) - Convert.ToInt32(this.Producto.Impoconsumo);
                    pVenta3 = Convert.ToInt32(pVenta3 - (pVenta3 * Producto.DescuentoDistribuidor / 100));
                    pVenta3 += Convert.ToInt32(this.Producto.Impoconsumo);

                    if (this.RedondearPrecio2)  //  Adición de codigo 22/05/2019
                    {
                        pVenta3 = UseObject.Aproximar(pVenta3, AproxPrecio);
                    }

                    this.txtValorVentaP3.Text = pVenta3.ToString();
                    this.txtDescuentoP3DB.Text = this.txtDescuentoP3.Text = Producto.DescuentoDistribuidor.ToString().Replace(',', '.');



                    // precio 4


                    double ivaEdit = this.Producto.ValorIva; //((Iva)cbIvaEditar.SelectedItem).PorcentajeIva;
                    //double util4Edit = Convert.ToDouble(this.txtUtilidadP4.Text.ToString().Replace('.', ','));

                    //double pVenta = Convert.ToDouble(this.txtValorSugeridoP1.Text);
                    //double pVenta = Convert.ToDouble(this.txtValorVentaP1.Text);
                    // double costo = Convert.ToDouble(UseObject.RemoveSeparatorMil(this.txtCostoNoIvaP2.Text).ToString().Replace('.', ','));   // edicion 21/04/2019
                    costo = this.Producto.ValorCosto;  // adicion 21/04/2019
                    //double costoMasIva = Convert.ToDouble(this.txtCostoConIvaP3.Text.Replace('.', ','));
                    costoMasIva = Math.Round((costo + Math.Round((costo * Producto.ValorIva / 100), 4)), 2);
                    double costoCalculado = 0.0;
                    var util = 0.0;
                    valUtil = 0.0;
                    valIvaUtil = 0.0;
                    //var venta = 0;
                    //var descto = 0.0;



                    this.txtCostoNoIvaP4.Text = this.txtCostoNoIvaP1.Text;
                    this.txtDescuentoP4DB.Text = this.txtDescuentoP4.Text = Producto.DescuentoPrecio4.ToString().Replace(',', '.');

                    //this.txtDescuentoP4DB.Text = this.txtDescuentoP4.Text;
                    int pVenta4 = Convert.ToInt32(this.txtValorVentaP1.Text) - Convert.ToInt32(this.Producto.Impoconsumo);
                    var valor = Convert.ToInt32(pVenta4 - (pVenta4 * Convert.ToDouble(this.txtDescuentoP4.Text.Replace('.', ',')) / 100));




                    var valorTemp = valor;
                    // this.txtValorSugeridoP3.Text = this.txtValorVentaP3.Text;
                    if (this.Empresa.Regimen.IdRegimen.Equals(1)) //  Regimen   (Comun) 
                    {
                        costoCalculado = costo;
                    }
                    else   //  Regimen   (Simplificado) 
                    {
                        costoCalculado = costoMasIva;
                    }
                    if (!this.UtilidadAntesIva)  // Utilidad antes de IVA.
                    {
                        if (this.Empresa.Regimen.IdRegimen.Equals(1)) //  Regimen   (Comun) 
                        {
                            valor = Convert.ToInt32(valor / (1 + (ivaEdit / 100)));
                        }
                    }

                    if (CalculoUtilMultiplicado)
                    {
                        util = Math.Round(Convert.ToDouble(((valor - costoCalculado) * 100) / costoCalculado), 2);
                    }
                    else
                    {
                        var div = Math.Round((costoCalculado / valor), 2);
                        util = Math.Round((100 - ((costoCalculado / valor) * 100)), 1);
                    }
                    //valUtil = Math.Round((valor - costoCalculado), 2);
                    valUtil = Math.Round(((costoCalculado / ((100 - util) / 100)) - costoCalculado), 2);
                    if (this.Empresa.Regimen.IdRegimen.Equals(1)) //  Regimen   (Comun) 
                    {
                        valIvaUtil = Math.Round((valUtil * ivaEdit / 100), 2);
                    }
                    //descto = Math.Round((((pVenta - valorTemp) / pVenta) * 100), 1);
                    valorTemp += Convert.ToInt32(this.Producto.Impoconsumo);

                    this.txtUtilidadP4.Text = util.ToString().Replace(',', '.');
                    this.txtValorUtilidadP4.Text = valUtil.ToString().Replace(',', '.');
                    //this.txtValIvaUtilidadP3.Text = valIvaUtil.ToString().Replace(',', '.');
                    this.txtValorVentaP4.Text = valorTemp.ToString();
                    this.txtValorSugeridoP4.Text = UseObject.Aproximar(Convert.ToInt32(valorTemp), AproxPrecio).ToString().Replace(',', '.');

                    */

                    //this.txtDescuentoP4_KeyPress(this.txtDescuentoP4, new KeyPressEventArgs((char)Keys.Enter));




                    /*var producto = this.miBussinesProducto.ProductoCompleto(this.dgvArticulos.CurrentRow.Cells["Codigo"].Value.ToString());
                    double iva = Math.Round((producto.ValorCosto * producto.ValorIva / 100), 2);
                    this.txtCosto.Text = UseObject.InsertSeparatorMil((Convert.ToInt32(producto.ValorCosto + iva)).ToString());
                    this.txtUtilidad.Text = producto.UtilidadPorcentualProducto.ToString();

                    var precioSug = 0;
                    var precioUtil = 0.0;
                    var costo = Convert.ToInt32(UseObject.RemoveSeparatorMil(txtCosto.Text));
                    if (this.Empresa.Regimen.IdRegimen.Equals(1))
                    {
                        if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("costoIva")))//  Precio de Costo                                   (2)
                        {
                            costo = Convert.ToInt32((Convert.ToInt32(costo) / (1 + (producto.ValorIva / 100))));
                        }
                    }
                    else
                    {
                        if (!Convert.ToBoolean(AppConfiguracion.ValorSeccion("costoIva")))//  Precio de Costo                                   (2)
                        {
                            costo = Convert.ToInt32(Convert.ToInt32(costo) + (Convert.ToInt32(costo) * producto.ValorIva / 100));
                        }
                    }
                    if (!Convert.ToBoolean(AppConfiguracion.ValorSeccion("utilidad_mas_iva")))   // Utilidad antes de IVA.                       (3)
                    {
                        if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("calculo_util_multiplica"))) // Incremento de Utilidad         (4)
                        {
                            precioUtil = costo + (costo * producto.UtilidadPorcentualProducto / 100);
                        }
                        else
                        {
                            var UtilComplemento = 100.0 - UseObject.RemoveSeparatorMil(txtUtilidad.Text);
                            precioUtil = costo / (UtilComplemento / 100);
                            //precioSug = Convert.ToInt32(precioUtil + (precioUtil * producto.ValorIva / 100));
                        }
                        if (this.Empresa.Regimen.IdRegimen.Equals(1))//  Regimen                                                                (1)
                        {
                            precioSug = Convert.ToInt32(precioUtil + (precioUtil * producto.ValorIva / 100));
                        }
                        else
                        {
                            precioSug = Convert.ToInt32(precioUtil);
                        }
                    }
                    else  // Utilidad despues de IVA.
                    {
                        if (this.Empresa.Regimen.IdRegimen.Equals(1))//  Regimen                                                                (1)
                        {
                            precioUtil = costo + (costo * producto.ValorIva / 100);
                        }
                        else
                        {
                            precioUtil = costo;
                        }
                        if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("calculo_util_multiplica"))) // Incremento de Utilidad         (4)
                        {
                            //precioUtil = costo + (costo * producto.UtilidadPorcentualProducto / 100);
                            precioSug = Convert.ToInt32(precioUtil + (precioUtil * producto.UtilidadPorcentualProducto / 100));
                        }
                        else
                        {
                            var UtilComplemento = 100.0 - UseObject.RemoveSeparatorMil(txtUtilidad.Text);
                            precioSug = Convert.ToInt32(precioUtil / (UtilComplemento / 100));
                            //precioUtil = costo / (UtilComplemento / 100);
                        }
                    }
                    txtPrecioSugerido.Text = UseObject.InsertSeparatorMil(precioSug.ToString());
                    precioSug = UseObject.Aproximar(precioSug, Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio")));

                    txtPrecioAprox.Text = UseObject.InsertSeparatorMil(precioSug.ToString());*/
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void dgvArticulos_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.Up) || e.KeyData.Equals(Keys.Down))
            {
                this.dgvArticulos_CellClick(this.dgvArticulos, null);
            }
        }

        private void dgvArticulos_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            try
            {
                //if (this.Edit)
                //{
                    //if (e.ColumnIndex.Equals(6) || e.ColumnIndex.Equals(7) || e.ColumnIndex.Equals(8) || e.ColumnIndex.Equals(11))
                if (e.ColumnIndex.Equals(6) || 
                    e.ColumnIndex.Equals(7) || 
                    e.ColumnIndex.Equals(8) || 
                    e.ColumnIndex.Equals(9) || 
                    e.ColumnIndex.Equals(12))
                    {
                        if (!String.IsNullOrEmpty(e.FormattedValue.ToString()))
                        {
                            string valor = "0";
                            if (e.FormattedValue != null)
                            {
                                valor = e.FormattedValue.ToString();
                            }
                            if (ValidarDouble(valor))
                            {
                                this.dgvArticulos.EndEdit();

                                if (e.ColumnIndex.Equals(6) && !Cantidad.ReadOnly)
                                {
                                    EditarCantidad(e.RowIndex, valor);
                                }

                                if (e.ColumnIndex.Equals(7) && !Costo.ReadOnly)
                                {
                                    EditarCosto(e.RowIndex, valor);
                                }

                                if (e.ColumnIndex.Equals(8) && !D1.ReadOnly)
                                {
                                    EditD1(e.RowIndex, valor);
                                }

                                if (e.ColumnIndex.Equals(9) && !D2.ReadOnly)
                                {
                                    EditD2(e.RowIndex, valor);
                                }

                                if (e.ColumnIndex.Equals(12) && !Impoconsumo.ReadOnly)
                                {
                                    EditarImpoconsumo(e.RowIndex, valor);
                                }
                                /* if (e.ColumnIndex.Equals(8) && !Iva.ReadOnly)
                                 {
                                     EditarIva(e.RowIndex, valor);
                                 }*/
                           /*     if (e.ColumnIndex.Equals(12))
                                {
                                    if (ValidarInt(valor))
                                    {
                                        EditarVenta(e.RowIndex, valor);
                                    }
                                }*/
                                /* if (e.ColumnIndex.Equals(7) && !Costo.ReadOnly)
                                 {
                                     AjustarCosto();
                                 }*/
                                /*if (e.ColumnIndex != 11)
                                {
                                    EditarTotal();
                                }*/
                            }
                            else
                            {
                                OptionPane.MessageError("El número que ingreso es incorrecto.");
                                e.Cancel = true;
                            }
                        }
                        else
                        {
                            OptionPane.MessageError("Debe ingresar un valor.");
                            e.Cancel = true;
                        }
                       /* this.dgvArticulos.Columns["Cantidad"].ReadOnly = true;
                        this.dgvArticulos.Columns["Costo"].ReadOnly = true;
                        this.dgvArticulos.Columns["ActVenta"].ReadOnly = true;
                        this.Edit = false;*/
                    }
               // }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void dgvArticulos_CellValidating_old(object sender, DataGridViewCellValidatingEventArgs e)
        {
            try
            {
                //if (this.Edit)
                //{
                //if (e.ColumnIndex.Equals(6) || e.ColumnIndex.Equals(7) || e.ColumnIndex.Equals(8) || e.ColumnIndex.Equals(11))
                if (e.ColumnIndex.Equals(6) || e.ColumnIndex.Equals(7) || e.ColumnIndex.Equals(10))
                {
                    if (!String.IsNullOrEmpty(e.FormattedValue.ToString()))
                    {
                        string valor = "0";
                        if (e.FormattedValue != null)
                        {
                            valor = e.FormattedValue.ToString();
                        }
                        if (ValidarDouble(valor))
                        {
                            this.dgvArticulos.EndEdit();
                            if (e.ColumnIndex.Equals(6) && !Cantidad.ReadOnly)
                            {
                                EditarCantidad(e.RowIndex, valor);
                            }
                            if (e.ColumnIndex.Equals(7) && !Costo.ReadOnly)
                            {
                                EditarCosto(e.RowIndex, valor);
                            }
                            if (e.ColumnIndex.Equals(10) && !Impoconsumo.ReadOnly)
                            {
                                EditarImpoconsumo(e.RowIndex, valor);
                            }
                            /* if (e.ColumnIndex.Equals(8) && !Iva.ReadOnly)
                             {
                                 EditarIva(e.RowIndex, valor);
                             }*/
                            /*     if (e.ColumnIndex.Equals(12))
                                 {
                                     if (ValidarInt(valor))
                                     {
                                         EditarVenta(e.RowIndex, valor);
                                     }
                                 }*/
                            /* if (e.ColumnIndex.Equals(7) && !Costo.ReadOnly)
                             {
                                 AjustarCosto();
                             }*/
                            /*if (e.ColumnIndex != 11)
                            {
                                EditarTotal();
                            }*/
                        }
                        else
                        {
                            OptionPane.MessageError("El número que ingreso es incorrecto.");
                            e.Cancel = true;
                        }
                    }
                    else
                    {
                        OptionPane.MessageError("Debe ingresar un valor.");
                        e.Cancel = true;
                    }
                    /* this.dgvArticulos.Columns["Cantidad"].ReadOnly = true;
                     this.dgvArticulos.Columns["Costo"].ReadOnly = true;
                     this.dgvArticulos.Columns["ActVenta"].ReadOnly = true;
                     this.Edit = false;*/
                }
                // }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void btnCambiarRetencion_Click(object sender, EventArgs e)
        {
            var frmReteCompra = new Egreso.FrmAplicaRetencion();
            frmReteCompra.AplicaCompra = true;
            frmReteCompra.IdTipoBeneficio = this.Proveedor.IdRegimen;
            frmReteCompra.IdTipoEmpresa = Empresa.Regimen.IdRegimen;
            DialogResult rta = frmReteCompra.ShowDialog();
            if (rta.Equals(DialogResult.Yes))
            {
                if (this.Retenciones.Count != 0)
                {
                    var query = Retenciones.First();
                    this.Retencion.Tarifa = query.Tarifa;
                    this.Retencion.CifraPesos = query.CifraPesos;
                    this.Retencion.CifraUVT = query.CifraUVT;
                    this.Retencion.Concepto = query.Concepto;
                    lblTasaRetencion.Text = query.Tarifa.ToString() + "%";
                    miToolTip.SetToolTip(btnInfoRete, query.Concepto);
                    if (UseObject.RemoveSeparatorMil(txtSubTotal.Text) > query.CifraPesos)
                    {
                        txtRetencion.Text = UseObject.InsertSeparatorMil((Convert.ToInt32
                                (UseObject.RemoveSeparatorMil(txtSubTotal.Text) * query.Tarifa / 100)).ToString());
                    }
                    else
                    {
                        txtRetencion.Text = "0";
                    }
                }
            }
            else
            {
                if (rta.Equals(DialogResult.No))
                {
                    this.Retencion.Tarifa = 0;
                    this.Retencion.CifraPesos = 0;
                    this.Retencion.CifraUVT = 0;
                    this.Retencion.Concepto = "";
                    lblTasaRetencion.Text = this.Retencion.Tarifa.ToString() + "%";
                    miToolTip.SetToolTip(btnInfoRete, this.Retencion.Concepto);
                    txtRetencion.Text = "0";
                }
            }
            CargarDatos();
        }

        private void txtAjuste_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                if (!String.IsNullOrEmpty(this.txtAjuste.Text))
                {
                    if (ValidarDouble(this.txtAjuste.Text))
                    {
                        this.miError.SetError(this.txtAjuste, null);
                        CargarDatos();
                    }
                    else
                    {
                        this.miError.SetError(this.txtAjuste, "El valor es incorrecto.");
                    }
                }
                else
                {
                    this.txtAjuste.Text = "0";
                }
            }
        }

        private void CompletaEventos_Completa(CompletaArgumentosDeEvento args)
        {
            try
            {
                var obj = (ObjectAbstract)args.MiObjeto;
                if (obj.Id.Equals(19888))
                {
                    //if (this.Transfer)
                    //{
                        CargarDatos();
                        /*
                        if (this.AdicionProducto)
                        {
                            AgregarAriculo((Producto)obj.Objeto);
                        }
                        else
                        {
                            EditarArticulo((Producto)obj.Objeto);
                        }
                        */
                       // this.Transfer = false;
                   // }
                }
            }
            catch { }

            try
            {
                var proveedor_ = (DTO.Clases.Proveedor)args.MiObjeto;
                this.txtCodigoProveedor.Text = proveedor_.NitProveedor;
                this.txtCodigoProveedor_KeyPress(this.txtCodigoProveedor, new KeyPressEventArgs((char)Keys.Enter));
            }
            catch { }

            try
            {
                this.Transfer = (bool)args.MiObjeto;
            }
            catch { }
        }

        void CompletaEventos_Completabo(CompletaArgumentosDeEventobo args)
        {
            try
            {
                this.Retenciones = (List<RetencionConcepto>)args.MiBodegabo;
            }
            catch { }
        }

        //private Item item;

        private void LoadPrice()
        {
            try
            {
                if (this.dgvArticulos.RowCount != 0)
                {
                    var id = Convert.ToInt32(this.dgvArticulos.CurrentRow.Cells["IdProducto"].Value);
                    Item item = Items.Where(i => i.Id.Equals(id)).First();
                    double costo = Math.Round((item.Precio - item.Impoconsumo) / (1 + (item.IVA / 100)), 2);
                    this.Producto = this.miBussinesProducto.ProductoCompleto(item.Codigo);

                    var ultimoRegCompra = this.miBussinesFactura.UltimoRegistroCompra(Producto.CodigoInternoProducto);
                    this.txtCantidad.Text = ultimoRegCompra.Cantidad.ToString();
                    this.txtCostoBase.Text = UseObject.InsertSeparatorMil(ultimoRegCompra.Valor.ToString().Replace('.', ','));
                    this.txtCostoMasIva.Text = UseObject.InsertSeparatorMil(
                      Math.Round((ultimoRegCompra.Valor + (ultimoRegCompra.Valor * ultimoRegCompra.Producto.ValorIva / 100)), 2).ToString().Replace('.', ','));
                    this.txtPrecioVenta.Text = UseObject.InsertSeparatorMil(Producto.ValorVentaProducto.ToString());

                    this.lblProducto.Text = Producto.NombreProducto;
                    //double costo =                        Convert.ToDouble(this.TProductos.Rows[index]["Valor"]); // +Convert.ToDouble(this.TProductos.Rows[index]["Impoconsumo"]);  //ValorMasIva
                    var costoMasIva = Math.Round((costo + Math.Round((costo * Producto.ValorIva / 100), 4)), 2);
                    var costoMasIvaMasIco = costoMasIva + this.Producto.Impoconsumo;

                    this.Producto.ValorCosto = costo;

                    this.txtCostoNoIvaP1.Text = UseObject.InsertSeparatorMil(costoMasIvaMasIco.ToString().Replace('.', ',')); // editado 21/04/2019
                    this.txtCostoNoIvaP2.Text = this.txtCostoNoIvaP3.Text = this.txtCostoNoIvaP4.Text = this.txtCostoNoIvaP1.Text;

                    this.txtUtilidadP1.Text = Producto.UtilidadPorcentualProducto.ToString();
                    this.txtUtilidadP2.Text = Producto.Utilidad2.ToString();
                    this.txtUtilidadP3.Text = Producto.Utilidad3.ToString();

                    var valUtil = 0.0;
                    var valIvaUtil = 0.0;
                    var venta = 0;

                    if (!DefaultUtilPercentage)
                    {

                        if (!this.UtilidadAntesIva)  // Utilidad antes de IVA.
                        {
                            if (this.CalculoUtilMultiplicado)  // Incremento de utilidad multiplic.
                            {
                                valUtil = Math.Round((costo * Producto.UtilidadPorcentualProducto / 100), 2);
                            }
                            else
                            {
                                valUtil = Math.Round(((costo / ((100 - Producto.UtilidadPorcentualProducto) / 100)) - costo), 2);
                            }
                            //valIvaUtil = Math.Round((valUtil * this.MiProducto.ValorIva / 100), 2);
                            if (this.Empresa.Regimen.IdRegimen.Equals(1))
                            {
                                valIvaUtil = Math.Round((valUtil * Producto.ValorIva / 100), 2);
                                //venta = Convert.ToInt32(costoMasIva + valUtil + valIvaUtil);
                            }
                            else
                            {
                                //venta = Convert.ToInt32(costoMasIva + valUtil);
                            }
                            venta = Convert.ToInt32(costoMasIva + valUtil + valIvaUtil);
                        }
                        else
                        {
                            if (this.CalculoUtilMultiplicado)  // Incremento de utilidad multiplic.
                            {
                                valUtil = Math.Round((costoMasIva * Producto.UtilidadPorcentualProducto / 100), 2);
                            }
                            else
                            {
                                valUtil = Math.Round(((costoMasIva / ((100 - Producto.UtilidadPorcentualProducto) / 100)) - costoMasIva), 2);
                            }
                            venta = Convert.ToInt32(costoMasIva + valUtil + valIvaUtil);
                        }

                        venta += Convert.ToInt32(this.Producto.Impoconsumo);
                        venta = UseObject.Aproximar(venta, AproxPrecio);
                    }
                    else
                    {
                        venta = Convert.ToInt32(PriceProduct.GetPrice(new PriceProduct
                        {
                            Costo = costoMasIva,
                            Util = this.Producto.UtilidadPorcentualProducto
                        }));
                    }

                    this.txtValorUtilidadP1.Text = valUtil.ToString().Replace(',', '.');
                    this.txtValorVentaP1.Text = Producto.ValorVentaProducto.ToString();
                    ///this.txtValorSugeridoP1.Text = UseObject.Aproximar(venta, AproxPrecio).ToString().Replace(',', '.');
                    this.txtValorSugeridoP1.Text = venta.ToString().Replace(',', '.');

                    // precio 2
                    valUtil = 0.0;
                    valIvaUtil = 0.0;
                    venta = 0;

                    if (!this.UtilidadAntesIva)  // Utilidad antes de IVA.
                    {
                        if (this.CalculoUtilMultiplicado)  // Incremento de utilidad multiplic.
                        {
                            valUtil = Math.Round((costo * Producto.Utilidad2 / 100), 2);
                        }
                        else
                        {
                            valUtil = Math.Round(((costo / ((100 - Producto.Utilidad2) / 100)) - costo), 2);
                        }
                        //valIvaUtil = Math.Round((valUtil * this.MiProducto.ValorIva / 100), 2);
                        if (this.Empresa.Regimen.IdRegimen.Equals(1))
                        {
                            valIvaUtil = Math.Round((valUtil * Producto.ValorIva / 100), 2);
                            //venta = Convert.ToInt32(costoMasIva + valUtil + valIvaUtil);
                        }
                        else
                        {
                            //venta = Convert.ToInt32(costoMasIva + valUtil);
                        }
                    }
                    else
                    {
                        if (this.CalculoUtilMultiplicado)  // Incremento de utilidad multiplic.
                        {
                            valUtil = Math.Round((costoMasIva * Producto.Utilidad2 / 100), 2);
                        }
                        else
                        {
                            valUtil = Math.Round(((costoMasIva / ((100 - Producto.Utilidad2) / 100)) - costoMasIva), 2);
                        }
                    }
                    venta = Convert.ToInt32(costoMasIva + valUtil + valIvaUtil) + Convert.ToInt32(this.Producto.Impoconsumo);

                    this.txtValorUtilidadP2.Text = valUtil.ToString().Replace(',', '.');

                    this.txtValorSugeridoP2.Text = UseObject.Aproximar(venta, AproxPrecio).ToString().Replace(',', '.');

                    int pVenta2 = Convert.ToInt32(this.txtValorVentaP1.Text) - Convert.ToInt32(this.Producto.Impoconsumo);  // adicion 21-04-2019
                    pVenta2 = Convert.ToInt32(pVenta2 - (pVenta2 * Producto.DescuentoMayor / 100));                         // adicion 21-04-2019

                    pVenta2 += Convert.ToInt32(this.Producto.Impoconsumo);

                    if (this.RedondearPrecio2)  //  Adición de codigo 22/05/2019
                    {
                        pVenta2 = UseObject.Aproximar(pVenta2, AproxPrecio);
                    }

                    this.txtValorVentaP2.Text = pVenta2.ToString();
                    this.txtDescuentoP2DB.Text = this.txtDescuentoP2.Text = Producto.DescuentoMayor.ToString().Replace(',', '.');


                    // precio 3
                    valUtil = 0.0;
                    valIvaUtil = 0.0;
                    venta = 0;

                    if (!this.UtilidadAntesIva)  // Utilidad antes de IVA.
                    {
                        if (this.CalculoUtilMultiplicado)  // Incremento de utilidad multiplic.
                        {
                            valUtil = Math.Round((costo * Producto.Utilidad3 / 100), 2);
                        }
                        else
                        {
                            valUtil = Math.Round(((costo / ((100 - Producto.Utilidad3) / 100)) - costo), 2);
                        }
                        //valIvaUtil = Math.Round((valUtil * this.MiProducto.ValorIva / 100), 2);
                        if (this.Empresa.Regimen.IdRegimen.Equals(1))
                        {
                            valIvaUtil = Math.Round((valUtil * Producto.ValorIva / 100), 2);
                            //venta = Convert.ToInt32(costoMasIva + valUtil + valIvaUtil);
                        }
                        else
                        {
                            //venta = Convert.ToInt32(costoMasIva + valUtil);
                        }
                    }
                    else
                    {
                        if (this.CalculoUtilMultiplicado)  // Incremento de utilidad multiplic.
                        {
                            valUtil = Math.Round((costoMasIva * Producto.Utilidad3 / 100), 2);
                        }
                        else
                        {
                            valUtil = Math.Round(((costoMasIva / ((100 - Producto.Utilidad3) / 100)) - costoMasIva), 2);
                        }
                    }
                    venta = Convert.ToInt32(costoMasIva + valUtil + valIvaUtil) + Convert.ToInt32(this.Producto.Impoconsumo);

                    this.txtValorUtilidadP3.Text = valUtil.ToString().Replace(',', '.');

                    this.txtValorSugeridoP3.Text = UseObject.Aproximar(venta, AproxPrecio).ToString().Replace(',', '.');

                    int pVenta3 = Convert.ToInt32(this.txtValorVentaP1.Text) - Convert.ToInt32(this.Producto.Impoconsumo);
                    pVenta3 = Convert.ToInt32(pVenta3 - (pVenta3 * Producto.DescuentoDistribuidor / 100));
                    pVenta3 += Convert.ToInt32(this.Producto.Impoconsumo);

                    if (this.RedondearPrecio2)  //  Adición de codigo 22/05/2019
                    {
                        pVenta3 = UseObject.Aproximar(pVenta3, AproxPrecio);
                    }

                    this.txtValorVentaP3.Text = pVenta3.ToString();
                    this.txtDescuentoP3DB.Text = this.txtDescuentoP3.Text = Producto.DescuentoDistribuidor.ToString().Replace(',', '.');


                    // precio 4
                    double ivaEdit = this.Producto.ValorIva;
                    //costo = this.Producto.ValorCosto;  
                    costoMasIva = Math.Round((costo + Math.Round((costo * Producto.ValorIva / 100), 4)), 2);
                    double costoCalculado = 0.0;
                    var util = 0.0;
                    valUtil = 0.0;
                    valIvaUtil = 0.0;

                    this.txtCostoNoIvaP4.Text = this.txtCostoNoIvaP1.Text;
                    this.txtDescuentoP4DB.Text = this.txtDescuentoP4.Text = Producto.DescuentoPrecio4.ToString().Replace(',', '.');

                    int pVenta4 = Convert.ToInt32(this.txtValorVentaP1.Text) - Convert.ToInt32(this.Producto.Impoconsumo);
                    var valor = Convert.ToInt32(pVenta4 - (pVenta4 * Convert.ToDouble(this.txtDescuentoP4.Text.Replace('.', ',')) / 100));

                    var valorTemp = valor;
                    if (this.Empresa.Regimen.IdRegimen.Equals(1)) //  Regimen   (Comun) 
                    {
                        costoCalculado = costo;
                    }
                    else   //  Regimen   (Simplificado) 
                    {
                        costoCalculado = costoMasIva;
                    }
                    if (!this.UtilidadAntesIva)  // Utilidad antes de IVA.
                    {
                        if (this.Empresa.Regimen.IdRegimen.Equals(1)) //  Regimen   (Comun) 
                        {
                            valor = Convert.ToInt32(valor / (1 + (ivaEdit / 100)));
                        }
                    }

                    if (CalculoUtilMultiplicado)
                    {
                        util = Math.Round(Convert.ToDouble(((valor - costoCalculado) * 100) / costoCalculado), 2);
                    }
                    else
                    {
                        var div = Math.Round((costoCalculado / valor), 2);
                        util = Math.Round((100 - ((costoCalculado / valor) * 100)), 1);
                    }

                    valUtil = Math.Round(((costoCalculado / ((100 - util) / 100)) - costoCalculado), 2);
                    if (this.Empresa.Regimen.IdRegimen.Equals(1)) //  Regimen   (Comun) 
                    {
                        valIvaUtil = Math.Round((valUtil * ivaEdit / 100), 2);
                    }
                    valorTemp += Convert.ToInt32(this.Producto.Impoconsumo);

                    this.txtUtilidadP4.Text = util.ToString().Replace(',', '.');
                    this.txtValorUtilidadP4.Text = valUtil.ToString().Replace(',', '.');
                    this.txtValorVentaP4.Text = valorTemp.ToString();
                    this.txtValorSugeridoP4.Text = UseObject.Aproximar(Convert.ToInt32(valorTemp), AproxPrecio).ToString().Replace(',', '.');



                    /// **************************

                    /*
                    var query = (from datos in this.TProductos.AsEnumerable()
                                 where datos.Field<int>("Id") == id
                                 select datos).Single();
                    var index = this.TProductos.Rows.IndexOf(query);
                    */

                    //this.Producto = this.miBussinesProducto.ProductoCompleto(this.dgvArticulos.CurrentRow.Cells["Codigo"].Value.ToString());

                    //this.Producto.Impoconsumo = Convert.ToDouble(this.TProductos.Rows[index]["Impoconsumo"]);

                    /*this.txtCantidad.Text = ultimoRegCompra.Cantidad.ToString();
                    this.txtCostoBase.Text = UseObject.InsertSeparatorMil(ultimoRegCompra.Valor.ToString().Replace('.', ','));
                    this.txtCostoMasIva.Text = UseObject.InsertSeparatorMil(
                      Math.Round((ultimoRegCompra.Valor + (ultimoRegCompra.Valor * ultimoRegCompra.Producto.ValorIva / 100)), 2).ToString().Replace('.', ','));
                    this.txtPrecioVenta.Text = UseObject.InsertSeparatorMil(Producto.ValorVentaProducto.ToString());*/

                    /*
                    this.lblProducto.Text = Producto.NombreProducto;
                    double costo =
                        Convert.ToDouble(this.TProductos.Rows[index]["Valor"]); // +Convert.ToDouble(this.TProductos.Rows[index]["Impoconsumo"]);  //ValorMasIva
                    var costoMasIva = Math.Round((costo + Math.Round((costo * Producto.ValorIva / 100), 4)), 2);
                    var costoMasIvaMasIco = costoMasIva + this.Producto.Impoconsumo;

                    this.Producto.ValorCosto = costo;
                    */

                    //this.txtCostoNoIvaP1.Text = UseObject.InsertSeparatorMil(costo.ToString().Replace('.', ','));           // editado 21/04/2019
                    /*
                    this.txtCostoNoIvaP1.Text = UseObject.InsertSeparatorMil(costoMasIvaMasIco.ToString().Replace('.', ',')); // editado 21/04/2019
                    this.txtCostoNoIvaP2.Text = this.txtCostoNoIvaP3.Text = this.txtCostoNoIvaP4.Text = this.txtCostoNoIvaP1.Text;

                    this.txtUtilidadP1.Text = Producto.UtilidadPorcentualProducto.ToString();
                    this.txtUtilidadP2.Text = Producto.Utilidad2.ToString();
                    this.txtUtilidadP3.Text = Producto.Utilidad3.ToString();
                    */

                    /*
                    var valUtil = 0.0;
                    var valIvaUtil = 0.0;
                    var venta = 0;

                    if (!this.UtilidadAntesIva)  // Utilidad antes de IVA.
                    {
                        if (this.CalculoUtilMultiplicado)  // Incremento de utilidad multiplic.
                        {
                            valUtil = Math.Round((costo * Producto.UtilidadPorcentualProducto / 100), 2);
                        }
                        else
                        {
                            valUtil = Math.Round(((costo / ((100 - Producto.UtilidadPorcentualProducto) / 100)) - costo), 2);
                        }
                        //valIvaUtil = Math.Round((valUtil * this.MiProducto.ValorIva / 100), 2);
                        if (this.Empresa.Regimen.IdRegimen.Equals(1))
                        {
                            valIvaUtil = Math.Round((valUtil * Producto.ValorIva / 100), 2);
                            //venta = Convert.ToInt32(costoMasIva + valUtil + valIvaUtil);
                        }
                        else
                        {
                            //venta = Convert.ToInt32(costoMasIva + valUtil);
                        }
                        venta = Convert.ToInt32(costoMasIva + valUtil + valIvaUtil);
                    }
                    else
                    {
                        if (this.CalculoUtilMultiplicado)  // Incremento de utilidad multiplic.
                        {
                            valUtil = Math.Round((costoMasIva * Producto.UtilidadPorcentualProducto / 100), 2);
                        }
                        else
                        {
                            valUtil = Math.Round(((costoMasIva / ((100 - Producto.UtilidadPorcentualProducto) / 100)) - costoMasIva), 2);
                        }
                        venta = Convert.ToInt32(costoMasIva + valUtil + valIvaUtil);
                    }
                    */

                    /*
                    venta += Convert.ToInt32(this.Producto.Impoconsumo);

                    this.txtValorUtilidadP1.Text = valUtil.ToString().Replace(',', '.');
                    this.txtValorVentaP1.Text = Producto.ValorVentaProducto.ToString();
                    this.txtValorSugeridoP1.Text = UseObject.Aproximar(venta, AproxPrecio).ToString().Replace(',', '.');
                    */

                    /*
                    // precio 2
                    valUtil = 0.0;
                    valIvaUtil = 0.0;
                    venta = 0;

                    if (!this.UtilidadAntesIva)  // Utilidad antes de IVA.
                    {
                        if (this.CalculoUtilMultiplicado)  // Incremento de utilidad multiplic.
                        {
                            valUtil = Math.Round((costo * Producto.Utilidad2 / 100), 2);
                        }
                        else
                        {
                            valUtil = Math.Round(((costo / ((100 - Producto.Utilidad2) / 100)) - costo), 2);
                        }
                        //valIvaUtil = Math.Round((valUtil * this.MiProducto.ValorIva / 100), 2);
                        if (this.Empresa.Regimen.IdRegimen.Equals(1))
                        {
                            valIvaUtil = Math.Round((valUtil * Producto.ValorIva / 100), 2);
                            //venta = Convert.ToInt32(costoMasIva + valUtil + valIvaUtil);
                        }
                        else
                        {
                            //venta = Convert.ToInt32(costoMasIva + valUtil);
                        }
                    }
                    else
                    {
                        if (this.CalculoUtilMultiplicado)  // Incremento de utilidad multiplic.
                        {
                            valUtil = Math.Round((costoMasIva * Producto.Utilidad2 / 100), 2);
                        }
                        else
                        {
                            valUtil = Math.Round(((costoMasIva / ((100 - Producto.Utilidad2) / 100)) - costoMasIva), 2);
                        }
                    }
                    venta = Convert.ToInt32(costoMasIva + valUtil + valIvaUtil) + Convert.ToInt32(this.Producto.Impoconsumo);

                    this.txtValorUtilidadP2.Text = valUtil.ToString().Replace(',', '.');

                    this.txtValorSugeridoP2.Text = UseObject.Aproximar(venta, AproxPrecio).ToString().Replace(',', '.');

                    int pVenta2 = Convert.ToInt32(this.txtValorVentaP1.Text) - Convert.ToInt32(this.Producto.Impoconsumo);  // adicion 21-04-2019
                    pVenta2 = Convert.ToInt32(pVenta2 - (pVenta2 * Producto.DescuentoMayor / 100));                         // adicion 21-04-2019

                    pVenta2 += Convert.ToInt32(this.Producto.Impoconsumo);

                    if (this.RedondearPrecio2)  //  Adición de codigo 22/05/2019
                    {
                        pVenta2 = UseObject.Aproximar(pVenta2, AproxPrecio);
                    }

                    this.txtValorVentaP2.Text = pVenta2.ToString();
                    this.txtDescuentoP2DB.Text = this.txtDescuentoP2.Text = Producto.DescuentoMayor.ToString().Replace(',', '.');
                    */

                    /*
                    // precio 3
                    valUtil = 0.0;
                    valIvaUtil = 0.0;
                    venta = 0;

                    if (!this.UtilidadAntesIva)  // Utilidad antes de IVA.
                    {
                        if (this.CalculoUtilMultiplicado)  // Incremento de utilidad multiplic.
                        {
                            valUtil = Math.Round((costo * Producto.Utilidad3 / 100), 2);
                        }
                        else
                        {
                            valUtil = Math.Round(((costo / ((100 - Producto.Utilidad3) / 100)) - costo), 2);
                        }
                        //valIvaUtil = Math.Round((valUtil * this.MiProducto.ValorIva / 100), 2);
                        if (this.Empresa.Regimen.IdRegimen.Equals(1))
                        {
                            valIvaUtil = Math.Round((valUtil * Producto.ValorIva / 100), 2);
                            //venta = Convert.ToInt32(costoMasIva + valUtil + valIvaUtil);
                        }
                        else
                        {
                            //venta = Convert.ToInt32(costoMasIva + valUtil);
                        }
                    }
                    else
                    {
                        if (this.CalculoUtilMultiplicado)  // Incremento de utilidad multiplic.
                        {
                            valUtil = Math.Round((costoMasIva * Producto.Utilidad3 / 100), 2);
                        }
                        else
                        {
                            valUtil = Math.Round(((costoMasIva / ((100 - Producto.Utilidad3) / 100)) - costoMasIva), 2);
                        }
                    }
                    venta = Convert.ToInt32(costoMasIva + valUtil + valIvaUtil) + Convert.ToInt32(this.Producto.Impoconsumo);

                    this.txtValorUtilidadP3.Text = valUtil.ToString().Replace(',', '.');

                    this.txtValorSugeridoP3.Text = UseObject.Aproximar(venta, AproxPrecio).ToString().Replace(',', '.');

                    int pVenta3 = Convert.ToInt32(this.txtValorVentaP1.Text) - Convert.ToInt32(this.Producto.Impoconsumo);
                    pVenta3 = Convert.ToInt32(pVenta3 - (pVenta3 * Producto.DescuentoDistribuidor / 100));
                    pVenta3 += Convert.ToInt32(this.Producto.Impoconsumo);

                    if (this.RedondearPrecio2)  //  Adición de codigo 22/05/2019
                    {
                        pVenta3 = UseObject.Aproximar(pVenta3, AproxPrecio);
                    }

                    this.txtValorVentaP3.Text = pVenta3.ToString();
                    this.txtDescuentoP3DB.Text = this.txtDescuentoP3.Text = Producto.DescuentoDistribuidor.ToString().Replace(',', '.');
                    */


                    /*
                    // precio 4
                    double ivaEdit = this.Producto.ValorIva; //((Iva)cbIvaEditar.SelectedItem).PorcentajeIva;
                    //double util4Edit = Convert.ToDouble(this.txtUtilidadP4.Text.ToString().Replace('.', ','));

                    //double pVenta = Convert.ToDouble(this.txtValorSugeridoP1.Text);
                    //double pVenta = Convert.ToDouble(this.txtValorVentaP1.Text);
                    // double costo = Convert.ToDouble(UseObject.RemoveSeparatorMil(this.txtCostoNoIvaP2.Text).ToString().Replace('.', ','));   // edicion 21/04/2019
                    costo = this.Producto.ValorCosto;  // adicion 21/04/2019
                    //double costoMasIva = Convert.ToDouble(this.txtCostoConIvaP3.Text.Replace('.', ','));
                    costoMasIva = Math.Round((costo + Math.Round((costo * Producto.ValorIva / 100), 4)), 2);
                    double costoCalculado = 0.0;
                    var util = 0.0;
                    valUtil = 0.0;
                    valIvaUtil = 0.0;
                    //var venta = 0;
                    //var descto = 0.0;



                    this.txtCostoNoIvaP4.Text = this.txtCostoNoIvaP1.Text;
                    this.txtDescuentoP4DB.Text = this.txtDescuentoP4.Text = Producto.DescuentoPrecio4.ToString().Replace(',', '.');

                    //this.txtDescuentoP4DB.Text = this.txtDescuentoP4.Text;
                    int pVenta4 = Convert.ToInt32(this.txtValorVentaP1.Text) - Convert.ToInt32(this.Producto.Impoconsumo);
                    var valor = Convert.ToInt32(pVenta4 - (pVenta4 * Convert.ToDouble(this.txtDescuentoP4.Text.Replace('.', ',')) / 100));




                    var valorTemp = valor;
                    // this.txtValorSugeridoP3.Text = this.txtValorVentaP3.Text;
                    if (this.Empresa.Regimen.IdRegimen.Equals(1)) //  Regimen   (Comun) 
                    {
                        costoCalculado = costo;
                    }
                    else   //  Regimen   (Simplificado) 
                    {
                        costoCalculado = costoMasIva;
                    }
                    if (!this.UtilidadAntesIva)  // Utilidad antes de IVA.
                    {
                        if (this.Empresa.Regimen.IdRegimen.Equals(1)) //  Regimen   (Comun) 
                        {
                            valor = Convert.ToInt32(valor / (1 + (ivaEdit / 100)));
                        }
                    }

                    if (CalculoUtilMultiplicado)
                    {
                        util = Math.Round(Convert.ToDouble(((valor - costoCalculado) * 100) / costoCalculado), 2);
                    }
                    else
                    {
                        var div = Math.Round((costoCalculado / valor), 2);
                        util = Math.Round((100 - ((costoCalculado / valor) * 100)), 1);
                    }
                    //valUtil = Math.Round((valor - costoCalculado), 2);
                    valUtil = Math.Round(((costoCalculado / ((100 - util) / 100)) - costoCalculado), 2);
                    if (this.Empresa.Regimen.IdRegimen.Equals(1)) //  Regimen   (Comun) 
                    {
                        valIvaUtil = Math.Round((valUtil * ivaEdit / 100), 2);
                    }
                    //descto = Math.Round((((pVenta - valorTemp) / pVenta) * 100), 1);
                    valorTemp += Convert.ToInt32(this.Producto.Impoconsumo);

                    this.txtUtilidadP4.Text = util.ToString().Replace(',', '.');
                    this.txtValorUtilidadP4.Text = valUtil.ToString().Replace(',', '.');
                    //this.txtValIvaUtilidadP3.Text = valIvaUtil.ToString().Replace(',', '.');
                    this.txtValorVentaP4.Text = valorTemp.ToString();
                    this.txtValorSugeridoP4.Text = UseObject.Aproximar(Convert.ToInt32(valorTemp), AproxPrecio).ToString().Replace(',', '.');
                    */


                    //this.txtDescuentoP4_KeyPress(this.txtDescuentoP4, new KeyPressEventArgs((char)Keys.Enter));




                    /*var producto = this.miBussinesProducto.ProductoCompleto(this.dgvArticulos.CurrentRow.Cells["Codigo"].Value.ToString());
                    double iva = Math.Round((producto.ValorCosto * producto.ValorIva / 100), 2);
                    this.txtCosto.Text = UseObject.InsertSeparatorMil((Convert.ToInt32(producto.ValorCosto + iva)).ToString());
                    this.txtUtilidad.Text = producto.UtilidadPorcentualProducto.ToString();

                    var precioSug = 0;
                    var precioUtil = 0.0;
                    var costo = Convert.ToInt32(UseObject.RemoveSeparatorMil(txtCosto.Text));
                    if (this.Empresa.Regimen.IdRegimen.Equals(1))
                    {
                        if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("costoIva")))//  Precio de Costo                                   (2)
                        {
                            costo = Convert.ToInt32((Convert.ToInt32(costo) / (1 + (producto.ValorIva / 100))));
                        }
                    }
                    else
                    {
                        if (!Convert.ToBoolean(AppConfiguracion.ValorSeccion("costoIva")))//  Precio de Costo                                   (2)
                        {
                            costo = Convert.ToInt32(Convert.ToInt32(costo) + (Convert.ToInt32(costo) * producto.ValorIva / 100));
                        }
                    }
                    if (!Convert.ToBoolean(AppConfiguracion.ValorSeccion("utilidad_mas_iva")))   // Utilidad antes de IVA.                       (3)
                    {
                        if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("calculo_util_multiplica"))) // Incremento de Utilidad         (4)
                        {
                            precioUtil = costo + (costo * producto.UtilidadPorcentualProducto / 100);
                        }
                        else
                        {
                            var UtilComplemento = 100.0 - UseObject.RemoveSeparatorMil(txtUtilidad.Text);
                            precioUtil = costo / (UtilComplemento / 100);
                            //precioSug = Convert.ToInt32(precioUtil + (precioUtil * producto.ValorIva / 100));
                        }
                        if (this.Empresa.Regimen.IdRegimen.Equals(1))//  Regimen                                                                (1)
                        {
                            precioSug = Convert.ToInt32(precioUtil + (precioUtil * producto.ValorIva / 100));
                        }
                        else
                        {
                            precioSug = Convert.ToInt32(precioUtil);
                        }
                    }
                    else  // Utilidad despues de IVA.
                    {
                        if (this.Empresa.Regimen.IdRegimen.Equals(1))//  Regimen                                                                (1)
                        {
                            precioUtil = costo + (costo * producto.ValorIva / 100);
                        }
                        else
                        {
                            precioUtil = costo;
                        }
                        if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("calculo_util_multiplica"))) // Incremento de Utilidad         (4)
                        {
                            //precioUtil = costo + (costo * producto.UtilidadPorcentualProducto / 100);
                            precioSug = Convert.ToInt32(precioUtil + (precioUtil * producto.UtilidadPorcentualProducto / 100));
                        }
                        else
                        {
                            var UtilComplemento = 100.0 - UseObject.RemoveSeparatorMil(txtUtilidad.Text);
                            precioSug = Convert.ToInt32(precioUtil / (UtilComplemento / 100));
                            //precioUtil = costo / (UtilComplemento / 100);
                        }
                    }
                    txtPrecioSugerido.Text = UseObject.InsertSeparatorMil(precioSug.ToString());
                    precioSug = UseObject.Aproximar(precioSug, Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio")));

                    txtPrecioAprox.Text = UseObject.InsertSeparatorMil(precioSug.ToString());*/
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void EditarCantidad(int rowIndex, string cantidad)
        {
            try
            {
                var id = Convert.ToInt32(this.dgvArticulos.Rows[rowIndex].Cells["IdProducto"].Value);
                this.miBussinesFactura.EditCantidad(id, Convert.ToDouble(cantidad.Replace('.', ',')));
                ReadOnly_True();
                CargarDatos();
                

                /*DataGridViewRow gridRow = this.dgvArticulos.Rows[this.dgvArticulos.CurrentRow.Index];
                
                Item item = Items.Where(i => i.Id.Equals(id)).First();

                var query = (from datos in this.TProductos.AsEnumerable()
                             where datos.Field<int>("Id") == id
                             select datos).Single();
                var index = this.TProductos.Rows.IndexOf(query);

                this.TProductos.Rows[index]["Cantidad"] = Convert.ToDouble(cantidad.Replace('.', ','));
                //  var total = Math.Round((Convert.ToDouble(gridRow.Cells["CostoMasIva"].Value) * Convert.ToDouble(cantidad.Replace('.', ','))), 1);
                this.TProductos.Rows[index]["Total"] =
                    Convert.ToDouble(Convert.ToDouble(gridRow.Cells["ValorUnitario"].Value) * Convert.ToDouble(cantidad.Replace('.', ',')));
                CargarDatos();*/
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void EditarCantidad_old(int rowIndex, string cantidad)
        {
            try
            {
                DataGridViewRow gridRow = this.dgvArticulos.Rows[this.dgvArticulos.CurrentRow.Index];
                var id = Convert.ToInt32(this.dgvArticulos.Rows[rowIndex].Cells["IdProducto"].Value);
                var query = (from datos in this.TProductos.AsEnumerable()
                             where datos.Field<int>("Id") == id
                             select datos).Single();
                var index = this.TProductos.Rows.IndexOf(query);
                this.TProductos.Rows[index]["Cantidad"] = Convert.ToDouble(cantidad.Replace('.', ','));
              //  var total = Math.Round((Convert.ToDouble(gridRow.Cells["CostoMasIva"].Value) * Convert.ToDouble(cantidad.Replace('.', ','))), 1);
                this.TProductos.Rows[index]["Total"] = 
                    Convert.ToDouble(Convert.ToDouble(gridRow.Cells["ValorUnitario"].Value) * Convert.ToDouble(cantidad.Replace('.', ',')));
                CargarDatos();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void EditarCosto(int rowIndex, string costo)
        {
            try
            {
                var id = Convert.ToInt32(this.dgvArticulos.Rows[rowIndex].Cells["IdProducto"].Value);
                this.miBussinesFactura.EditCosto(id, Convert.ToDouble(costo.Replace('.', ',')));
                ReadOnly_True();
                CargarDatos();

                /*DataGridViewRow gridRow = this.dgvArticulos.Rows[this.dgvArticulos.CurrentRow.Index];
                var id = Convert.ToInt32(this.dgvArticulos.Rows[rowIndex].Cells["IdProducto"].Value);
                var query = (from datos in this.TProductos.AsEnumerable()
                             where datos.Field<int>("Id") == id
                             select datos).Single();
                var index = this.TProductos.Rows.IndexOf(query);
                //double costo_ = Convert.ToDouble(costo.Replace('.', ','));
                double costo_ = ValorDecimal(costo);
                double costoMasIva = 0;
                if (this.chkIva.Checked)
                {
                    costoMasIva = costo_;
                    costo_ = Math.Round(Convert.ToDouble(costo_ / (1 + (Convert.ToDouble(gridRow.Cells["Iva"].Value) / 100))), 2);
                }
                else
                {
                    //var m = Math.Round((costo_ * Convert.ToDouble(gridRow.Cells["Iva"].Value) / 100), 2);
                    costoMasIva = costo_ + Math.Round((costo_ * Convert.ToDouble(gridRow.Cells["Iva"].Value) / 100), 2);
                }
                this.TProductos.Rows[index]["Valor"] = costo_;
                this.TProductos.Rows[index]["ValorMasIva"] = costoMasIva;
                this.TProductos.Rows[index]["VIva"] = costoMasIva - costo_;
                this.TProductos.Rows[index]["ValorUnitario"] = Convert.ToDouble(gridRow.Cells["Impoconsumo"].Value) + costoMasIva;
                this.TProductos.Rows[index]["Total"] =
                    Convert.ToDouble(Convert.ToDouble(gridRow.Cells["Cantidad"].Value) * Convert.ToDouble(this.TProductos.Rows[index]["ValorUnitario"]));*/
                /*this.TProductos.Rows[index]["Total"] = 
                    Convert.ToInt32(Convert.ToDouble(gridRow.Cells["Cantidad"].Value) * costoMasIva);*/
                
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void EditD1(int rowIndex, string d1)
        {
            try
            {
                var id = Convert.ToInt32(this.dgvArticulos.Rows[rowIndex].Cells["IdProducto"].Value);
                this.miBussinesFactura.EditD1(id, Convert.ToDouble(d1.Replace('.', ',')));
                ReadOnly_True();
                CargarDatos();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void EditD2(int rowIndex, string d2)
        {
            try
            {
                var id = Convert.ToInt32(this.dgvArticulos.Rows[rowIndex].Cells["IdProducto"].Value);
                this.miBussinesFactura.EditD2(id, Convert.ToDouble(d2.Replace('.', ',')));
                ReadOnly_True();
                CargarDatos();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void EditarCosto_old(int rowIndex, string costo)
        {
            try
            {
                DataGridViewRow gridRow = this.dgvArticulos.Rows[this.dgvArticulos.CurrentRow.Index];
                var id = Convert.ToInt32(this.dgvArticulos.Rows[rowIndex].Cells["IdProducto"].Value);
                var query = (from datos in this.TProductos.AsEnumerable()
                             where datos.Field<int>("Id") == id
                             select datos).Single();
                var index = this.TProductos.Rows.IndexOf(query);
                //double costo_ = Convert.ToDouble(costo.Replace('.', ','));
                double costo_ = ValorDecimal(costo);
                double costoMasIva = 0;
                if (this.chkIva.Checked)
                {
                    costoMasIva = costo_;
                    costo_ = Math.Round(Convert.ToDouble(costo_ / (1 + (Convert.ToDouble(gridRow.Cells["Iva"].Value) / 100))), 2);
                }
                else
                {
                    //var m = Math.Round((costo_ * Convert.ToDouble(gridRow.Cells["Iva"].Value) / 100), 2);
                    costoMasIva = costo_ + Math.Round((costo_ * Convert.ToDouble(gridRow.Cells["Iva"].Value) / 100), 2);
                }
                this.TProductos.Rows[index]["Valor"] = costo_;
                this.TProductos.Rows[index]["ValorMasIva"] = costoMasIva;
                this.TProductos.Rows[index]["VIva"] = costoMasIva - costo_;
                this.TProductos.Rows[index]["ValorUnitario"] = Convert.ToDouble(gridRow.Cells["Impoconsumo"].Value) + costoMasIva;
                this.TProductos.Rows[index]["Total"] =
                    Convert.ToDouble(Convert.ToDouble(gridRow.Cells["Cantidad"].Value) * Convert.ToDouble(this.TProductos.Rows[index]["ValorUnitario"]));
                /*this.TProductos.Rows[index]["Total"] = 
                    Convert.ToInt32(Convert.ToDouble(gridRow.Cells["Cantidad"].Value) * costoMasIva);*/
                CargarDatos();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void EditarImpoconsumo(int rowIndex, string ico)
        {
            try
            {
                var id = Convert.ToInt32(this.dgvArticulos.Rows[rowIndex].Cells["IdProducto"].Value);
                Item item = Items.Where(i => i.Id.Equals(id)).First();
                this.miBussinesFactura.EditImpoconsumo(item.Codigo, ValorDecimal(ico));
                ReadOnly_True();
                CargarDatos();

               /* DataGridViewRow gridRow = this.dgvArticulos.Rows[this.dgvArticulos.CurrentRow.Index];
                var id = Convert.ToInt32(this.dgvArticulos.Rows[rowIndex].Cells["IdProducto"].Value);
                var query = (from datos in this.TProductos.AsEnumerable()
                             where datos.Field<int>("Id") == id
                             select datos).Single();
                var index = this.TProductos.Rows.IndexOf(query);
                double costo_ = ValorDecimal(costo);
                this.TProductos.Rows[index]["Impoconsumo"] = costo_; // Convert.ToDouble(costo.Replace('.', ','));
                this.TProductos.Rows[index]["ValorUnitario"] = Convert.ToDouble(gridRow.Cells["CostoMasIva"].Value) + costo_;*/
                /*this.TProductos.Rows[index]["ValorUnitario"] =
                    Convert.ToDouble(gridRow.Cells["CostoMasIva"].Value) + costo_;
                this.TProductos.Rows[index]["Total"] = Convert.ToDouble(this.TProductos.Rows[index]["ValorUnitario"]) *
                    Convert.ToDouble(gridRow.Cells["Cantidad"].Value);*/

                /*this.TProductos.Rows[index]["Total"] = (Convert.ToDouble(gridRow.Cells["CostoMasIva"].Value) + costo_) *
                    Convert.ToDouble(gridRow.Cells["Cantidad"].Value);*/


              /*  double costo_ = ValorDecimal(costo);

                double costoMasIva = 0;
                if (this.chkIva.Checked)
                {
                    costoMasIva = costo_;
                    costo_ = Math.Round(Convert.ToDouble(costo_ / (1 + (Convert.ToDouble(gridRow.Cells["Iva"].Value) / 100))), 1);
                }
                else
                {
                    var m = Math.Round((costo_ * Convert.ToDouble(gridRow.Cells["Iva"].Value) / 100), 1);
                    costoMasIva = costo_ + Math.Round((costo_ * Convert.ToDouble(gridRow.Cells["Iva"].Value) / 100), 1);
                }
                this.TProductos.Rows[index]["Valor"] = costo_;
                this.TProductos.Rows[index]["ValorMasIva"] = costoMasIva;
                this.TProductos.Rows[index]["Total"] = Convert.ToInt32(Convert.ToDouble(gridRow.Cells["Cantidad"].Value) * costoMasIva);*/
                
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void EditarImpoconsumo_old(int rowIndex, string costo)
        {
            try
            {
                DataGridViewRow gridRow = this.dgvArticulos.Rows[this.dgvArticulos.CurrentRow.Index];
                var id = Convert.ToInt32(this.dgvArticulos.Rows[rowIndex].Cells["IdProducto"].Value);
                var query = (from datos in this.TProductos.AsEnumerable()
                             where datos.Field<int>("Id") == id
                             select datos).Single();
                var index = this.TProductos.Rows.IndexOf(query);
                double costo_ = ValorDecimal(costo);
                this.TProductos.Rows[index]["Impoconsumo"] = costo_; // Convert.ToDouble(costo.Replace('.', ','));
                this.TProductos.Rows[index]["ValorUnitario"] = Convert.ToDouble(gridRow.Cells["CostoMasIva"].Value) + costo_;
                /*this.TProductos.Rows[index]["ValorUnitario"] =
                    Convert.ToDouble(gridRow.Cells["CostoMasIva"].Value) + costo_;
                this.TProductos.Rows[index]["Total"] = Convert.ToDouble(this.TProductos.Rows[index]["ValorUnitario"]) *
                    Convert.ToDouble(gridRow.Cells["Cantidad"].Value);*/

                this.TProductos.Rows[index]["Total"] = (Convert.ToDouble(gridRow.Cells["CostoMasIva"].Value) + costo_) *
                    Convert.ToDouble(gridRow.Cells["Cantidad"].Value);


                /*  double costo_ = ValorDecimal(costo);

                  double costoMasIva = 0;
                  if (this.chkIva.Checked)
                  {
                      costoMasIva = costo_;
                      costo_ = Math.Round(Convert.ToDouble(costo_ / (1 + (Convert.ToDouble(gridRow.Cells["Iva"].Value) / 100))), 1);
                  }
                  else
                  {
                      var m = Math.Round((costo_ * Convert.ToDouble(gridRow.Cells["Iva"].Value) / 100), 1);
                      costoMasIva = costo_ + Math.Round((costo_ * Convert.ToDouble(gridRow.Cells["Iva"].Value) / 100), 1);
                  }
                  this.TProductos.Rows[index]["Valor"] = costo_;
                  this.TProductos.Rows[index]["ValorMasIva"] = costoMasIva;
                  this.TProductos.Rows[index]["Total"] = Convert.ToInt32(Convert.ToDouble(gridRow.Cells["Cantidad"].Value) * costoMasIva);*/
                CargarDatos();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

       /* private Item Item_(int id)
        {
            return Items.Where(i => i.Id.Equals(id)).First();
        }*/

        private void ReadOnly_True()
        {
            this.dgvArticulos.Columns["Cantidad"].ReadOnly = true;
            this.dgvArticulos.Columns["Costo"].ReadOnly = true;
            this.dgvArticulos.Columns["D1"].ReadOnly = true;
            this.dgvArticulos.Columns["D2"].ReadOnly = true;
            ///this.dgvArticulos.Columns["ActVenta"].ReadOnly = true;
            this.dgvArticulos.Columns["Impoconsumo"].ReadOnly = true;
        }

        private void EditarIva(int rowIndex, string iva)
        {
            try
            {
                DataGridViewRow gridRow = this.dgvArticulos.Rows[this.dgvArticulos.CurrentRow.Index];
                var id = Convert.ToInt32(this.dgvArticulos.Rows[rowIndex].Cells["IdProducto"].Value);
                var query = (from datos in this.TProductos.AsEnumerable()
                             where datos.Field<int>("Id") == id
                             select datos).Single();
                var index = this.TProductos.Rows.IndexOf(query);
                double costoMasIva = Math.Round((Convert.ToDouble(gridRow.Cells["Costo"].Value) +
                    (Convert.ToDouble(gridRow.Cells["Costo"].Value) * Convert.ToDouble(iva.Replace('.', ',')) / 100)), 1);
                this.TProductos.Rows[index]["Iva"] = Convert.ToDouble(iva.Replace('.', ','));
                this.TProductos.Rows[index]["ValorMasIva"] = costoMasIva;
                this.TProductos.Rows[index]["Total"] = Convert.ToInt32(Convert.ToDouble(gridRow.Cells["Cantidad"].Value) * costoMasIva);
                CargarDatos();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void EditarVenta(int rowIndex, string venta)
        {
            try
            {
                var id = Convert.ToInt32(this.dgvArticulos.Rows[rowIndex].Cells["IdProducto"].Value);
                var query = (from datos in this.TProductos.AsEnumerable()
                             where datos.Field<int>("Id") == id
                             select datos).Single();
                var index = this.TProductos.Rows.IndexOf(query);
                this.TProductos.Rows[index]["ActVenta"] = Convert.ToDouble(venta.Replace('.', ','));
                
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private double ValorDecimal(string valor)
        {
            double valor_ = 0;
            try
            {
                valor_ = Convert.ToDouble(valor.Replace('.', ','));
            }
            catch
            {
                valor_ = Convert.ToDouble(UseObject.RemoverPunto(valor));
            }
            return valor_;
        }

        private void AjustarCosto()
        {
            try
            {
                DataGridViewRow gridRow = this.dgvArticulos.Rows[this.dgvArticulos.CurrentRow.Index];
                var costo = Convert.ToDouble(gridRow.Cells["Costo"].Value);
                double costoMasIva = 0;
                if (this.chkIva.Checked)
                {
                    costoMasIva = costo;
                    costo = Convert.ToInt32(costo / (1 + (Convert.ToDouble(gridRow.Cells["Iva"].Value) / 100)));
                }
                else
                {
                    costoMasIva = costo + Math.Round((costo * Convert.ToDouble(gridRow.Cells["Iva"].Value) / 100), 0);
                }
                gridRow.Cells["Costo"].Value = costo;
                gridRow.Cells["CostoMasIva"].Value = costoMasIva;
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void CargarDatos()
        {
            try
            {
                this.Items = this.miBussinesFactura.ItemsCompra(this.Id);
                this.bindingSource.DataSource = this.Items;
                //this.dgvArticulos.DataSource = this.Items;

                txtSubTotal.Text = UseObject.InsertSeparatorMil(Math.Round(Items.Sum(s => (s.Costo * s.Cantidad)), 0).ToString());
                txtD1.Text = UseObject.InsertSeparatorMil((Math.Round(
                    Items.Sum(s => (s.Costo * s.Cantidad)) - Items.Sum(s => (s.CostoMenosD1 * s.Cantidad)), 0)).ToString());
                txtD2.Text = UseObject.InsertSeparatorMil(Math.Round(Items.Sum(s => (s.ValorD2 * s.Cantidad)), 0).ToString());
                txtIva.Text = UseObject.InsertSeparatorMil(Math.Round(Items.Sum(s => (s.ValorIVA * s.Cantidad)), 0).ToString());
                txtImpoconsumo.Text = UseObject.InsertSeparatorMil(Math.Round(Items.Sum(s => (s.Impoconsumo * s.Cantidad)), 0).ToString());

                double subTotal = Convert.ToDouble(UseObject.RemoveSeparatorMil(txtSubTotal.Text).ToString().Replace('.', ','));
                subTotal = UseObject.RemoveSeparatorMil(txtSubTotal.Text);
                if (subTotal > Retencion.CifraPesos)
                {
                    txtRetencion.Text = UseObject.InsertSeparatorMil(Convert.ToInt32(subTotal * Retencion.Tarifa / 100).ToString());
                }
                else
                {
                    txtRetencion.Text = "0";
                }
                if (String.IsNullOrEmpty(this.txtAjuste.Text))
                {
                    this.txtAjuste.Text = "0";
                }
                txtTotal.Text = UseObject.InsertSeparatorMil((((
                    UseObject.RemoveSeparatorMil(this.txtSubTotal.Text) -
                    UseObject.RemoveSeparatorMil(this.txtD1.Text)) +
                    UseObject.RemoveSeparatorMil(this.txtIva.Text) +
                    UseObject.RemoveSeparatorMil(this.txtImpoconsumo.Text) +
                    UseObject.RemoveSeparatorMil(this.txtAjuste.Text)) -
                    UseObject.RemoveSeparatorMil(this.txtRetencion.Text)).ToString());

                txtPago.Text = UseObject.InsertSeparatorMil((
                    UseObject.RemoveSeparatorMil(txtTotal.Text) - UseObject.RemoveSeparatorMil(txtD2.Text)).ToString());
               

                /**
                txtTotal.Text = UseObject.InsertSeparatorMil(Convert.ToInt32(
                    (UseObject.RemoveSeparatorMil(this.txtSubTotal.Text) +
                     UseObject.RemoveSeparatorMil(this.txtIva.Text) +
                     UseObject.RemoveSeparatorMil(this.txtImpoconsumo.Text) +
                     UseObject.RemoveSeparatorMil(this.txtAjuste.Text)) -
                     UseObject.RemoveSeparatorMil(this.txtRetencion.Text)).ToString());
                */


                //this.dgvArticulos.Columns["Cantidad"].ReadOnly = true;
                //this.dgvArticulos.Columns["Iva"].ReadOnly = true;
                /*int subTotal = SubTotal();
                int vIva = ValorIva();
                int total = subTotal + vIva;
                this.txtSubTotal.Text = UseObject.InsertSeparatorMil(total.ToString());
                if (subTotal > Retencion.CifraPesos)
                {
                    this.txtRetencion.Text = UseObject.InsertSeparatorMil(Convert.ToInt32(subTotal * Retencion.Tarifa / 100).ToString());
                }
                else
                {
                    this.txtRetencion.Text = "0";
                }
                this.txtTotal.Text = UseObject.InsertSeparatorMil(((UseObject.RemoveSeparatorMil(this.txtSubTotal.Text) -
                    UseObject.RemoveSeparatorMil(this.txtRetencion.Text)) + UseObject.RemoveSeparatorMil(this.txtAjuste.Text)).ToString());*/

                // Edición 26-03-2017

                /**
                this.txtSubTotal.Text = UseObject.InsertSeparatorMil((Math.Round((
                    this.TProductos.AsEnumerable().Sum(s => s.Field<double>("Valor") * s.Field<double>("Cantidad"))), 0)).ToString().Replace('.', ','));
                this.txtIva.Text = UseObject.InsertSeparatorMil((Math.Round((
                    this.TProductos.AsEnumerable().Sum(s => s.Field<double>("VIva") * s.Field<double>("Cantidad"))), 0)).ToString().Replace('.', ','));
                this.txtImpoconsumo.Text = UseObject.InsertSeparatorMil((Math.Round((
                    this.TProductos.AsEnumerable().Sum(s => s.Field<double>("Impoconsumo") * s.Field<double>("Cantidad"))), 0)).ToString().Replace('.', ','));
                         var subTotal = Convert.ToDouble(UseObject.RemoveSeparatorMil(this.txtSubTotal.Text).ToString().Replace('.', ','));
                subTotal = UseObject.RemoveSeparatorMil(this.txtSubTotal.Text);
                if (subTotal > Retencion.CifraPesos)
                {
                    this.txtRetencion.Text = UseObject.InsertSeparatorMil(Convert.ToInt32(subTotal * Retencion.Tarifa / 100).ToString());
                }
                else
                {
                    this.txtRetencion.Text = "0";
                }
                */


                /*this.txtTotal.Text =
                    UseObject.InsertSeparatorMil(Convert.ToInt32((subTotal - UseObject.RemoveSeparatorMil(this.txtRetencion.Text)) +
                    UseObject.RemoveSeparatorMil(this.txtIva.Text) + UseObject.RemoveSeparatorMil(this.txtImpoconsumo.Text) +
                    UseObject.RemoveSeparatorMil(this.txtAjuste.Text)).ToString());*/

                /*this.txtTotal.Text = UseObject.InsertSeparatorMil(Convert.ToInt32(
                    (this.TProductos.AsEnumerable().Sum(s => s.Field<double>("Total")) - 
                    UseObject.RemoveSeparatorMil(this.txtRetencion.Text)) + 
                    UseObject.RemoveSeparatorMil(this.txtAjuste.Text)).ToString());*/

                // Edicion 30/05/2018: mejora la presición del calculo de los totales, consulta, cartera, abono general.

                /**
                this.txtTotal.Text = UseObject.InsertSeparatorMil(Convert.ToInt32(
                    (UseObject.RemoveSeparatorMil(this.txtSubTotal.Text) +
                     UseObject.RemoveSeparatorMil(this.txtIva.Text) +
                     UseObject.RemoveSeparatorMil(this.txtImpoconsumo.Text) +
                     UseObject.RemoveSeparatorMil(this.txtAjuste.Text)) -
                     UseObject.RemoveSeparatorMil(this.txtRetencion.Text)).ToString());
                */

                // Fin Edicion 30/05/2018

                this.dgvArticulos_CellClick(this.dgvArticulos, null);

                // End edición 26-03-2017
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private int SubTotal()
        {
            int subTotal = 0;
            foreach (DataRow row in this.TProductos.Rows)
            {
                var J = Convert.ToInt32(Convert.ToDouble(row["Valor"]) * Convert.ToDouble(row["Cantidad"]));
                subTotal += Convert.ToInt32(Convert.ToDouble(row["Valor"]) * Convert.ToDouble(row["Cantidad"]));
            }
          /*  foreach (DataGridViewRow gRow in this.dgvArticulos.Rows)
            {
               // var sCosto = Convert.ToInt32(gRow.Cells["Costo"].Value);
                subTotal += Convert.ToInt32(Convert.ToDouble(gRow.Cells["Costo"].Value) * Convert.ToDouble(gRow.Cells["Cantidad"].Value));
            }*/
           /* foreach (DataGridViewRow gRow in this.dgvArticulos.Rows)
            {
                var sCosto = Convert.ToInt32(Convert.ToInt32(gRow.Cells["Costo"].Value) / (1 + (Convert.ToDouble(gRow.Cells["Iva"].Value) / 100)));
                subTotal += Convert.ToInt32(sCosto * Convert.ToDouble(gRow.Cells["Cantidad"].Value));
            }*/
            return subTotal;
        }

        private int ValorIva()
        {
            int iva = 0;
            foreach (DataRow row in this.TProductos.Rows)
            {
                var j = Convert.ToInt32((Convert.ToDouble(row["Valor"]) * Convert.ToDouble(row["Iva"]) / 100) * Convert.ToDouble(row["Cantidad"]));
                iva += Convert.ToInt32((Convert.ToDouble(row["Valor"]) * Convert.ToDouble(row["Iva"]) / 100) * Convert.ToDouble(row["Cantidad"]));
            }
            /*foreach (DataGridViewRow gRow in this.dgvArticulos.Rows)
            {
                iva += Convert.ToInt32((Convert.ToDouble(gRow.Cells["Costo"].Value) * Convert.ToDouble(gRow.Cells["Iva"].Value) / 100) * 
                    Convert.ToDouble(gRow.Cells["Cantidad"].Value));
            }*/
            return iva;
        }

        /*private int CostoTotal()
        {
            int total = 0;
            foreach (DataGridViewRow gRow in this.dgvArticulos.Rows)
            {
                var sTotal = Convert.ToInt32(gRow.Cells["Costo"].Value);
                total += Convert.ToInt32(sTotal * Convert.ToDouble(gRow.Cells["Cantidad"].Value));
            }
            return total;
        }*/

        private void AgregarAriculo(Producto producto)
        {
            try
            {
                int id = 1;
                if (this.TProductos.Rows.Count != 0)
                {
                    id = this.TProductos.AsEnumerable().Max(m => m.Field<int>("Id")) + 1;
                }
                var row = this.TProductos.NewRow();
                row["Id"] = id;
                row["Codigo"] = producto.CodigoInternoProducto;
                row["Articulo"] = producto.NombreProducto;
                row["IdMedida"] = producto.IdMedida;
                row["IdColor"] = producto.IdColor;
                row["IdLote"] = this.miBussinesLote.IngresarLote(new Lote { CodigoProducto = producto.CodigoInternoProducto, Fecha = DateTime.Now, 
                    Numero = producto.CodigoInternoProducto + "-" + CambiarSeparadorFecha(DateTime.Now.ToShortDateString()) });
                row["Cantidad"] = producto.Cantidad;
                row["Valor"] = producto.ValorCosto;
                double iva = Math.Round((producto.ValorCosto * producto.ValorIva / 100), 2);
                row["VIva"] = iva;

                row["ValorMasIva"] = Math.Round((producto.ValorCosto + iva), 1);
                row["ValorUnitario"] = Math.Round((producto.ValorCosto + iva), 1) + producto.Impoconsumo;

                row["Iva"] = producto.ValorIva;
                row["Impoconsumo"] = producto.Impoconsumo;
                row["Total"] = Convert.ToInt32(Convert.ToDouble(row["ValorUnitario"]) * Convert.ToDouble(row["cantidad"]));
                row["Venta"] = producto.ValorVentaProducto;
                row["ActVenta"] = 0;
                this.TProductos.Rows.Add(row);

                

               /*var producto_ = new ProductoFacturaProveedor();
                producto_.IdFactura = this.Id;
                producto_.Producto.CodigoInternoProducto = producto.CodigoInternoProducto;
                producto_.Inventario.IdMedida = producto.IdMedida;
                producto_.Inventario.IdColor = producto.IdColor;
                producto_.Lote.CodigoProducto = producto.CodigoInternoProducto;
                producto_.Lote.Fecha = DateTime.Now;
                producto_.Lote.Numero = producto.CodigoInternoProducto + "-" + CambiarSeparadorFecha(DateTime.Now.ToShortDateString());
                producto_.Cantidad = producto.Cantidad;
                producto_.Producto.ValorCosto = producto.ValorCosto;
                producto_.Producto.ValorIva = producto.ValorIva;
                producto_.Producto.Descuento = producto.Descuento;
                this.miBussinesFactura.IngresarProductoTemporal(producto_);
                this.dgvArticulos.DataSource = this.miBussinesFactura.ProductosCompra(this.Id);*/
                CargarDatos();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void EditarArticulo(Producto producto)
        {
            try
            {
                var id = Convert.ToInt32(this.dgvArticulos.CurrentRow.Cells["IdProducto"].Value);
                var query = (from datos in this.TProductos.AsEnumerable()
                             where datos.Field<int>("Id") == id
                             select datos).Single();
                var index = this.TProductos.Rows.IndexOf(query);
                this.TProductos.Rows[index]["Codigo"] = producto.CodigoInternoProducto;
                this.TProductos.Rows[index]["Articulo"] = producto.NombreProducto;
                this.TProductos.Rows[index]["IdMedida"] = producto.IdMedida;
                this.TProductos.Rows[index]["IdColor"] = producto.IdColor;
                //this.TProductos.Rows[index]["Cantidad"] = producto.Cantidad;
                this.TProductos.Rows[index]["Valor"] = producto.ValorCosto;
                double iva = Math.Round((producto.ValorCosto * producto.ValorIva / 100), 2);
                this.TProductos.Rows[index]["ValorMasIva"] = Math.Round((producto.ValorCosto + iva), 1);
                this.TProductos.Rows[index]["ValorUnitario"] = Math.Round((producto.ValorCosto + iva), 1) + producto.Impoconsumo;
                this.TProductos.Rows[index]["Iva"] = producto.ValorIva;
                this.TProductos.Rows[index]["VIva"] = iva;
                this.TProductos.Rows[index]["Impoconsumo"] = producto.Impoconsumo;
                this.TProductos.Rows[index]["Total"] = Convert.ToInt32(Convert.ToDouble(producto.ValorCosto + iva + producto.Impoconsumo) * Convert.ToDouble(this.TProductos.Rows[index]["Cantidad"]));
                this.TProductos.Rows[index]["Venta"] = producto.ValorVentaProducto;
                this.TProductos.Rows[index]["ActVenta"] = 0;

              /*  row["Id"] = this.TProductos.AsEnumerable().Max(m => m.Field<int>("Id")) + 1;
                row["Codigo"] = producto.CodigoInternoProducto;
                row["Articulo"] = producto.NombreProducto;
                row["IdMedida"] = producto.IdMedida;
                row["IdColor"] = producto.IdColor;
                row["IdLote"] = this.miBussinesLote.IngresarLote(new Lote
                {
                    CodigoProducto = producto.CodigoInternoProducto,
                    Fecha = DateTime.Now,
                    Numero = producto.CodigoInternoProducto + "-" + CambiarSeparadorFecha(DateTime.Now.ToShortDateString())
                });
                row["Cantidad"] = producto.Cantidad;
                row["Valor"] = producto.ValorCosto;
                double iva = Math.Round((producto.ValorCosto * producto.ValorIva / 100), 2);
                row["ValorMasIva"] = Convert.ToInt32(producto.ValorCosto + iva);
                row["Iva"] = producto.ValorIva;
                row["Total"] = Convert.ToInt32(Convert.ToDouble(row["ValorMasIva"]) * Convert.ToDouble(row["cantidad"]));
                row["Venta"] = producto.ValorVentaProducto;
                row["ActVenta"] = 0;
                this.TProductos.Rows.Add(row);*
                /*DataGridViewRow gridRow = this.dgvArticulos.Rows[this.dgvArticulos.CurrentRow.Index];
                gridRow.Cells["Codigo"].Value = producto.CodigoInternoProducto;
                gridRow.Cells["Articulo"].Value = producto.NombreProducto;
                gridRow.Cells["IdMedida"].Value = producto.IdMedida;
                gridRow.Cells["IdColor"].Value = producto.IdColor;
                gridRow.Cells["Iva"].Value = producto.ValorIva;
                gridRow.Cells["Costo"].Value = producto.ValorCosto;
                gridRow.Cells["Total"].Value = Convert.ToInt32(producto.ValorCosto * Convert.ToDouble(gridRow.Cells["Cantidad"].Value));
                gridRow.Cells["Venta"].Value = producto.ValorVentaProducto;
                this.dgvArticulos.EndEdit();*/
                CargarDatos();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private bool ValidarInt(string numero)
        {
            try
            {
                Convert.ToInt32(numero);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private bool ValidarDouble(string numero)
        {
            try
            {
                Convert.ToDouble(numero);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private void EditarTotal()
        {
            try
            {
                DataGridViewRow gridRow = this.dgvArticulos.Rows[this.dgvArticulos.CurrentRow.Index];
                gridRow.Cells["Total"].Value = Convert.ToInt32(Convert.ToDouble(gridRow.Cells["Cantidad"].Value) *
                    Convert.ToDouble(gridRow.Cells["CostoMasIva"].Value));
                this.dgvArticulos.EndEdit();
                this.dgvArticulos.Columns["Cantidad"].ReadOnly = true;
                this.dgvArticulos.Columns["Costo"].ReadOnly = true;
                this.dgvArticulos.Columns["ActVenta"].ReadOnly = true;
                CargarDatos();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private string CambiarSeparadorFecha(string fecha)
        {
            var miFecha = fecha.Split('/');
            string fechaResult = miFecha[0] + miFecha[1] + miFecha[2];
            return fechaResult;
        }
        
        private double Utilidad(double costo, double iva, double venta)
        {
            try
            {
                double util = 0;
                int valorCosto = Convert.ToInt32(costo);
                int valorVenta = Convert.ToInt32(venta);
                if (!this.Empresa.Regimen.IdRegimen.Equals(1))  // Regimen comun
                {
                    valorCosto = Convert.ToInt32(valorCosto + (valorCosto * iva / 100));
                }
                if (!Convert.ToBoolean(AppConfiguracion.ValorSeccion("utilidad_mas_iva")))   // Utilidad antes de IVA.                       (3)
                {
                    // Retiro el IVA del precio de venta.
                    if (this.Empresa.Regimen.IdRegimen.Equals(1))//  Regimen   (Comun)                                                          (1)
                    {
                        valorVenta = Convert.ToInt32((valorVenta / (1 + (iva / 100))));
                    }
                }
                else     // Utilidad despues de IVA.
                {
                    if (this.Empresa.Regimen.IdRegimen.Equals(1))//  Regimen   (Comun)                                                          (1)
                    {
                        valorCosto = Convert.ToInt32((valorCosto / (1 + (iva / 100))));
                    }
                }
                // Incremento de la Utilidad.
                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("calculo_util_multiplica"))) // Incremento de Utilidad         (4)
                {
                    // Costo x Util
                    util = Math.Round(Convert.ToDouble(((valorVenta - valorCosto) * 100) / valorCosto), 3);
                }
                else
                {
                    var div = Math.Round(Convert.ToDouble(valorCosto) / Convert.ToDouble(valorVenta), 3);
                    util = 100 - (div * 100);
                }
                return Math.Round(util, 1);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
                return 0;
            }
        }

        private bool ValidarFecha()
        {
            if (Convert.ToInt32(this.cbFormaPago.SelectedValue) == 2)
            {
                if (UseDate.FechaSinHora(this.dtpLimite.Value) > UseDate.FechaSinHora(this.dtpFecha.Value))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }
        
        private void txtUtilidadP1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                if (!String.IsNullOrEmpty(this.txtUtilidadP1.Text))
                {
                    this.miError.SetError(this.txtUtilidadP1, null);
                    if (ValidarDouble(this.txtUtilidadP1.Text.Replace('.', ',')))
                    {
                        this.miError.SetError(this.txtUtilidadP1, null);
                        if (DefaultUtilPercentage)
                        {
                            EditPriceOne(false, Convert.ToDouble(this.txtUtilidadP1.Text.Replace('.', ',')));
                        }
                        else
                        {
                            EditaVentaPrecioUno(false, Convert.ToDouble(this.txtUtilidadP1.Text.Replace('.', ',')));
                        }
                        this.txtValorVentaP1.Focus();
                    }
                    else
                    {
                        this.miError.SetError(this.txtUtilidadP1, "El valor que ingreso es incorrecto.");
                    }
                }
                else
                {
                    this.miError.SetError(this.txtUtilidadP1, "Debe ingresar un valor.");
                }
            }
        }

        private void txtValorVentaP1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                if (!String.IsNullOrEmpty(this.txtValorVentaP1.Text))
                {
                    this.miError.SetError(this.txtValorVentaP1, null);
                    if (ValidarInt(this.txtValorVentaP1.Text))
                    {
                        this.miError.SetError(this.txtValorVentaP1, null);
                        if (DefaultUtilPercentage)
                        {
                            EditPriceOne(true, Convert.ToDouble(this.txtValorVentaP1.Text.Replace('.', ',')));
                        }
                        else
                        {
                            EditaVentaPrecioUno(true, Convert.ToDouble(this.txtValorVentaP1.Text.Replace('.', ',')));
                        }
                        this.txtUtilidadP2.Focus();
                    }
                    else
                    {
                        this.miError.SetError(this.txtValorVentaP1, "El valor que ingreso es incorrecto.");
                    }
                }
                else
                {
                    this.miError.SetError(this.txtValorVentaP1, "Debe ingresar un valor.");
                }
            }
        }

        private void txtUtilidadP2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                if (!String.IsNullOrEmpty(this.txtUtilidadP2.Text))
                {
                    this.miError.SetError(this.txtUtilidadP2, null);
                    if (ValidarDouble(this.txtUtilidadP2.Text.Replace('.', ',')))
                    {
                        this.miError.SetError(this.txtUtilidadP2, null);
                        EditaVentaPrecioDos(Calculo.Util_, Convert.ToDouble(this.txtUtilidadP2.Text.Replace('.', ',')));
                        this.txtValorVentaP2.Focus();
                    }
                    else
                    {
                        this.miError.SetError(this.txtUtilidadP2, "El valor que ingreso es incorrecto.");
                    }
                }
                else
                {
                    this.miError.SetError(this.txtUtilidadP2, "Debe ingresar un valor.");
                }
            }
        }

        private void txtValorVentaP2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                if (!String.IsNullOrEmpty(this.txtValorVentaP2.Text))
                {
                    this.miError.SetError(this.txtValorVentaP2, null);
                    if (ValidarDouble(this.txtValorVentaP2.Text.Replace('.', ',')))
                    {
                        this.miError.SetError(this.txtValorVentaP2, null);
                        EditaVentaPrecioDos(Calculo.Pventa, Convert.ToDouble(this.txtValorVentaP2.Text.Replace('.', ',')));
                        this.txtDescuentoP2.Focus();
                    }
                    else
                    {
                        this.miError.SetError(this.txtValorVentaP2, "El valor que ingreso es incorrecto.");
                    }
                }
                else
                {
                    this.miError.SetError(this.txtValorVentaP2, "Debe ingresar un valor.");
                }
            }
        }

        private void txtDescuentoP2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                if (!String.IsNullOrEmpty(this.txtDescuentoP2.Text))
                {
                    if (ValidarDouble(this.txtDescuentoP2.Text))
                    {
                        this.miError.SetError(this.txtDescuentoP2, null);

                        this.txtDescuentoP2DB.Text = this.txtDescuentoP2.Text;

                        /*int pVenta2 = Convert.ToInt32(Convert.ToInt32(this.txtValorVentaP1.Text) -
                           (Convert.ToInt32(this.txtValorVentaP1.Text) * Convert.ToDouble(this.txtDescuentoP2.Text.Replace('.', ',')) / 100));*/

                        int pVenta2 = Convert.ToInt32(this.txtValorVentaP1.Text) - Convert.ToInt32(this.Producto.Impoconsumo);
                        pVenta2 = Convert.ToInt32(pVenta2 - (pVenta2 * Convert.ToDouble(this.txtDescuentoP2.Text.Replace('.', ',')) / 100));

                        /*if (this.RedondearPrecio2)                                  // **
                        {                                                           // Añadido
                            pVenta2 = UseObject.Aproximar(pVenta2, AproxPrecio);    //
                        }*/                                                           // **
                        //pVenta2 = UseObject.Aproximar(pVenta2, AproxPrecio);
                        EditaVentaPrecioDos(Calculo.Descto, Convert.ToDouble(pVenta2));
                        this.txtUtilidadP3.Focus();
                    }
                    else
                    {
                        this.miError.SetError(this.txtDescuentoP2, "El valor que ingreso es incorrecto.");
                    }
                }
                else
                {
                    this.miError.SetError(this.txtDescuentoP2, "Debe ingresar un valor.");
                }
            }
        }

        private void txtUtilidadP3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                if (!String.IsNullOrEmpty(this.txtUtilidadP3.Text))
                {
                    this.miError.SetError(this.txtUtilidadP3, null);
                    if (ValidarDouble(this.txtUtilidadP3.Text.Replace('.', ',')))
                    {
                        this.miError.SetError(this.txtUtilidadP3, null);
                        EditaVentaPrecioTres(Calculo.Util_, Convert.ToDouble(this.txtUtilidadP3.Text.Replace('.', ',')));
                        this.txtValorVentaP3.Focus();
                    }
                    else
                    {
                        this.miError.SetError(this.txtUtilidadP3, "El valor que ingreso es incorrecto.");
                    }
                }
                else
                {
                    this.miError.SetError(this.txtUtilidadP3, "Debe ingresar un valor.");
                }
            }
        }

        private void txtValorVentaP3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                if (!String.IsNullOrEmpty(this.txtValorVentaP3.Text))
                {
                    this.miError.SetError(this.txtValorVentaP3, null);
                    if (ValidarDouble(this.txtValorVentaP3.Text.Replace('.', ',')))
                    {
                        this.miError.SetError(this.txtValorVentaP3, null);
                        EditaVentaPrecioTres(Calculo.Pventa, Convert.ToDouble(this.txtValorVentaP3.Text.Replace('.', ',')));
                        this.txtDescuentoP3.Focus();
                    }
                    else
                    {
                        this.miError.SetError(this.txtValorVentaP3, "El valor que ingreso es incorrecto.");
                    }
                }
                else
                {
                    this.miError.SetError(this.txtValorVentaP3, "Debe ingresar un valor.");
                }
            }
        }

        private void txtDescuentoP3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                if (!String.IsNullOrEmpty(this.txtDescuentoP3.Text))
                {
                    this.miError.SetError(this.txtDescuentoP3, null);
                    if (ValidarDouble(this.txtDescuentoP3.Text))
                    {
                        this.miError.SetError(this.txtDescuentoP3, null);

                        this.txtDescuentoP3DB.Text = this.txtDescuentoP3.Text;
                        /*int pVenta2 = Convert.ToInt32(Convert.ToInt32(this.txtValorVentaP1.Text) -
                            (Convert.ToInt32(this.txtValorVentaP1.Text) * Convert.ToDouble(this.txtDescuentoP3.Text.Replace('.', ',')) / 100));
                        pVenta2 = UseObject.Aproximar(pVenta2, AproxPrecio);*/
                    //EditaVentaPrecioTres(Calculo.Descto, Convert.ToDouble(pVenta2));
                    //this.btnGuardarEdicionPrecio.Focus();

                        int pVenta2 = Convert.ToInt32(this.txtValorVentaP1.Text) - Convert.ToInt32(this.Producto.Impoconsumo);
                        pVenta2 = Convert.ToInt32(pVenta2 - (pVenta2 * Convert.ToDouble(this.txtDescuentoP3.Text.Replace('.', ',')) / 100));

                        /*if (this.RedondearPrecio2)                                  // **
                        {                                                           // Añadido
                            pVenta2 = UseObject.Aproximar(pVenta2, AproxPrecio);    //
                        }*/                                                           // **
                        this.EditaVentaPrecioTres(Calculo.Descto, Convert.ToDouble(pVenta2));
                        this.txtUtilidadP4.Focus();
                        //this.btnGuardarEdicionPrecio.Focus();
                    }
                    else
                    {
                        this.miError.SetError(this.txtDescuentoP3, "El valor que ingreso es incorrecto.");
                    }
                }
                else
                {
                    this.miError.SetError(this.txtDescuentoP3, "Debe ingresar un valor.");
                }
            }
        }


        private void txtUtilidadP4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                if (!String.IsNullOrEmpty(this.txtUtilidadP4.Text))
                {
                    this.miError.SetError(this.txtUtilidadP4, null);
                    if (ValidarDouble(this.txtUtilidadP3.Text.Replace('.', ',')))
                    {
                        this.miError.SetError(this.txtUtilidadP4, null);
                        EditaVentaPrecioCuatro(Calculo.Util_, Convert.ToDouble(this.txtUtilidadP4.Text.Replace('.', ',')));
                        this.txtValorVentaP4.Focus();
                    }
                    else
                    {
                        this.miError.SetError(this.txtUtilidadP4, "El valor que ingreso es incorrecto.");
                    }
                }
                else
                {
                    this.miError.SetError(this.txtUtilidadP4, "Debe ingresar un valor.");
                }
            }
        }

        private void txtValorVentaP4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                if (!String.IsNullOrEmpty(this.txtValorVentaP4.Text))
                {
                    this.miError.SetError(this.txtValorVentaP4, null);
                    if (ValidarDouble(this.txtValorVentaP4.Text.Replace('.', ',')))
                    {
                        this.miError.SetError(this.txtValorVentaP4, null);
                        EditaVentaPrecioCuatro(Calculo.Pventa, Convert.ToDouble(this.txtValorVentaP4.Text.Replace('.', ',')));
                        this.txtDescuentoP4.Focus();
                    }
                    else
                    {
                        this.miError.SetError(this.txtValorVentaP3, "El valor que ingreso es incorrecto.");
                    }
                }
                else
                {
                    this.miError.SetError(this.txtValorVentaP3, "Debe ingresar un valor.");
                }
            }
        }

        private void txtDescuentoP4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                if (!String.IsNullOrEmpty(this.txtDescuentoP4.Text))
                {
                    this.miError.SetError(this.txtDescuentoP4, null);
                    if (ValidarDouble(this.txtDescuentoP4.Text))
                    {
                        this.miError.SetError(this.txtDescuentoP4, null);

                        this.txtDescuentoP4DB.Text = this.txtDescuentoP4.Text;
                        int pVenta2 = Convert.ToInt32(this.txtValorVentaP1.Text) - Convert.ToInt32(this.Producto.Impoconsumo);
                        pVenta2 = Convert.ToInt32(pVenta2 - (pVenta2 * Convert.ToDouble(this.txtDescuentoP4.Text.Replace('.', ',')) / 100));

                        this.EditaVentaPrecioCuatro(Calculo.Descto, Convert.ToDouble(pVenta2));
                        this.btnGuardarEdicionPrecio.Focus();
                    }
                    else
                    {
                        this.miError.SetError(this.txtDescuentoP4, "El valor que ingreso es incorrecto.");
                    }
                }
                else
                {
                    this.miError.SetError(this.txtDescuentoP4, "Debe ingresar un valor.");
                }
            }
        }


        private void btnGuardarEdicionPrecio_Click(object sender, EventArgs e)
        {
            if (this.Producto != null)
            {
                try
                {
                    if (ValidacionGuardado())
                    {
                        DialogResult rta_ = MessageBox.Show("¿Esta seguro(a) de guardar los cambios?", "Edición de precio",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (rta_.Equals(DialogResult.Yes))
                        {
                            Producto p = new Producto();
                            p.CodigoInternoProducto = this.Producto.CodigoInternoProducto;
                            p.UtilidadPorcentualProducto = Convert.ToDouble(this.txtUtilidadP1.Text.Replace('.', ','));
                            p.ValorVentaProducto = Convert.ToInt32(this.txtValorVentaP1.Text);
                            p.IdIva = this.Producto.IdIva;

                            p.Impoconsumo = Producto.Impoconsumo;

                            p.ValorCosto =
                                Convert.ToDouble(UseObject.RemoveSeparatorMil(this.txtCostoNoIvaP1.Text) - this.Producto.Impoconsumo);
                            p.ValorCosto = Math.Round((p.ValorCosto / (1 + (Producto.ValorIva / 100))), 2);

                            //p.ValorCosto = 
                                //Convert.ToDouble(UseObject.RemoveSeparatorMil(this.txtCostoNoIvaP1.Text).ToString().Replace('.', ','));

                            /*p.DescuentoMayor = Convert.ToDouble(this.txtDescuentoP2.Text.Replace('.', ','));
                            p.DescuentoDistribuidor = Convert.ToDouble(this.txtDescuentoP3.Text.Replace('.', ','));*/

                            p.Utilidad2 = Convert.ToDouble(this.txtUtilidadP2.Text.Replace('.', ','));
                            p.Utilidad3 = Convert.ToDouble(this.txtUtilidadP3.Text.Replace('.', ','));

                            p.DescuentoMayor = Convert.ToDouble(this.txtDescuentoP2DB.Text.Replace('.', ','));
                            p.DescuentoDistribuidor = Convert.ToDouble(this.txtDescuentoP3DB.Text.Replace('.', ','));
                            p.DescuentoPrecio4 = Convert.ToDouble(this.txtDescuentoP4DB.Text.Replace('.', ','));                            

                            this.miBussinesProducto.EditarPrecios(p);
                            OptionPane.MessageInformation("La información del producto se ha almacenado correctamente.");

                            /*this.MiProducto = null;
                            this.txtCodigoArticulo.Focus();

                            this.lblCodigo.Text = "";
                            this.lblBarras.Text = "";
                            this.lblNombreProducto.Text = "";
                            this.txtCostoNoIvaP1.Text = "";

                            this.cbIvaEditar.Visible = false;
                            this.txtIvaP1.Visible = true;
                            this.txtIvaP1.Text = "";
                            this.btnEditarIva.Visible = true;

                            this.txtValorIvaP1.Text = "";
                            this.txtCostoConIvaP1.Text = "";
                            this.txtUtilidadP1.Text = "";
                            this.txtValorUtilidadP1.Text = "";
                            this.txtValIvaUtilidadP1.Text = "";
                            this.txtValorVentaP1.Text = "";
                            this.txtValorSugeridoP1.Text = "";


                            this.txtCostoNoIvaP2.Text = "";
                            this.txtIvaP2.Text = "";
                            this.txtValorIvaP2.Text = "";
                            this.txtCostoConIvaP2.Text = "";
                            this.txtUtilidadP2.Text = "";
                            this.txtValorUtilidadP2.Text = "";
                            this.txtValIvaUtilidadP2.Text = "";
                            this.txtValorVentaP2.Text = "";
                            this.txtValorSugeridoP2.Text = "";
                            this.txtDescuentoP2.Text = "";

                            this.txtCostoNoIvaP3.Text = "";
                            this.txtIvaP3.Text = "";
                            this.txtValorIvaP3.Text = "";
                            this.txtCostoConIvaP3.Text = "";
                            this.txtUtilidadP3.Text = "";
                            this.txtValorUtilidadP3.Text = "";
                            this.txtValIvaUtilidadP3.Text = "";
                            this.txtValorVentaP3.Text = "";
                            this.txtValorSugeridoP3.Text = "";
                            this.txtDescuentoP3.Text = "";*/
                        }
                    }
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
            else
            {
                OptionPane.MessageInformation("Debe cargar un producto.");
            }
        }


        private void EditPriceOne(bool venta_, double valor)
        {
            PriceProduct p = new PriceProduct
            {
                Costo = Math.Round(Producto.ValorCosto * (1 + (Producto.ValorIva / 100)), 0),
                //Costo = Convert.ToDouble(this.txtCostoNoIvaP1.Text.Replace('.', ',')),
                Util = Convert.ToDouble(this.txtUtilidadP1.Text.Replace('.', ',')),
                Price = Convert.ToDouble(this.txtValorVentaP1.Text.Replace('.', ','))
            };

            if (venta_)
            {
                this.txtValorSugeridoP1.Text = valor.ToString();
                this.txtUtilidadP1.Text = PriceProduct.GetUtil(p).ToString().Replace(',', '.');
            }
            else
            {
                this.txtValorSugeridoP1.Text = PriceProduct.GetPrice(p).ToString();
            }
        }

        
        private void EditaVentaPrecioUno(bool venta_, double valor)
        {
            try
            {
                double ivaEdit = this.Producto.ValorIva; //((Iva)cbIvaEditar.SelectedItem).PorcentajeIva;
                double utilEdit = Convert.ToDouble(this.txtUtilidadP1.Text.ToString().Replace('.', ','));

                //double costo = Convert.ToDouble(UseObject.RemoveSeparatorMil(this.txtCostoNoIvaP1.Text).ToString().Replace('.', ','));  // Edicion 21/04/2019
                double costo = this.Producto.ValorCosto;  // adicion 21/04/2019
                double costoMasIva = Math.Round((costo + Math.Round((costo * Producto.ValorIva / 100), 4)), 2);
                //double costoMasIva = Convert.ToDouble(this.txtCostoConIvaP1.Text.Replace('.', ','));
                double costoCalculado = 0.0;

                if (venta_) // indica edicion de precio de venta
                {
                    this.txtValorSugeridoP1.Text = UseObject.Aproximar(Convert.ToInt32(valor), AproxPrecio).ToString().Replace(',', '.');

                    valor -= Convert.ToInt32(this.Producto.Impoconsumo);  // adicion 21/04/2019
                    var util = 0.0;
                    var valUtil = 0.0;
                    var valIvaUtil = 0.0;

                    //this.txtValorSugeridoP1.Text = this.txtValorVentaP1.Text;
                    //this.txtValorSugeridoP1.Text = UseObject.Aproximar(Convert.ToInt32(valor), AproxPrecio).ToString().Replace(',', '.');
                    if (this.Empresa.Regimen.IdRegimen.Equals(1)) //  Regimen   (Comun) 
                    {
                        costoCalculado = costo;
                    }
                    else   //  Regimen   (Simplificado) 
                    {
                        costoCalculado = costoMasIva;
                    }
                    if (!this.UtilidadAntesIva)  // Utilidad antes de IVA.
                    {
                        if (this.Empresa.Regimen.IdRegimen.Equals(1)) //  Regimen   (Comun) 
                        {
                            valor = Convert.ToInt32(valor / (1 + (ivaEdit / 100)));
                        }
                    }

                    if (CalculoUtilMultiplicado)
                    {
                        util = Math.Round(Convert.ToDouble(((valor - costoCalculado) * 100) / costoCalculado), 2);
                    }
                    else
                    {
                        var div = Math.Round((costoCalculado / valor), 2);
                        util = Math.Round((100 - ((costoCalculado / valor) * 100)), 1);
                    }
                    //valUtil = Math.Round((valor - costoCalculado), 2);
                    valUtil = Math.Round(((costoCalculado / ((100 - util) / 100)) - costoCalculado), 2);
                    if (this.Empresa.Regimen.IdRegimen.Equals(1)) //  Regimen   (Comun) 
                    {
                        valIvaUtil = Math.Round((valUtil * ivaEdit / 100), 2);
                    }

                    this.txtUtilidadP1.Text = util.ToString().Replace(',', '.');
                    this.txtValorUtilidadP1.Text = valUtil.ToString().Replace(',', '.');
                    //this.txtValIvaUtilidadP1.Text = valIvaUtil.ToString().Replace(',', '.');
                }
                else  // indica edicion de utilidad
                {
                    var valUtil = 0.0;
                    var valIvaUtil = 0.0;
                    var venta = 0;

                    if (!this.UtilidadAntesIva)  // Utilidad antes de IVA.
                    {
                        if (this.CalculoUtilMultiplicado)  // Incremento de utilidad multiplic.
                        {
                            valUtil = Math.Round((costo * valor / 100), 2);
                        }
                        else
                        {
                            valUtil = Math.Round(((costo / ((100 - valor) / 100)) - costo), 2);
                        }
                        //valIvaUtil = Math.Round((valUtil * this.MiProducto.ValorIva / 100), 2);
                        if (this.Empresa.Regimen.IdRegimen.Equals(1))
                        {
                            valIvaUtil = Math.Round((valUtil * ivaEdit / 100), 2);
                            //venta = Convert.ToInt32(costoMasIva + valUtil + valIvaUtil);
                        }
                        else
                        {
                            //venta = Convert.ToInt32(costoMasIva + valUtil);
                        }
                    }
                    else
                    {
                        if (this.CalculoUtilMultiplicado)  // Incremento de utilidad multiplic.
                        {
                            valUtil = Math.Round((costoMasIva * valor / 100), 2);
                        }
                        else
                        {
                            valUtil = Math.Round(((costoMasIva / ((100 - valor) / 100)) - costoMasIva), 2);
                        }
                    }
                    venta = Convert.ToInt32(costoMasIva + valUtil + valIvaUtil) + Convert.ToInt32(this.Producto.Impoconsumo);

                    this.txtValorUtilidadP1.Text = valUtil.ToString().Replace(',', '.');
                    //this.txtValIvaUtilidadP1.Text = valIvaUtil.ToString().Replace(',', '.');
                    // this.txtValorVentaP1.Text = venta.ToString();
                    this.txtValorSugeridoP1.Text = UseObject.Aproximar(venta, AproxPrecio).ToString().Replace(',', '.');
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void EditaVentaPrecioDos(Calculo c, double valor)
        {
            try
            {
                double ivaEdit = this.Producto.ValorIva; //((Iva)cbIvaEditar.SelectedItem).PorcentajeIva;
                double util2Edit = Convert.ToDouble(this.txtUtilidadP2.Text.ToString().Replace('.', ','));

                //double pVenta = Convert.ToDouble(this.txtValorSugeridoP1.Text);
                double pVenta = Convert.ToDouble(this.txtValorVentaP1.Text);
                //pVenta -= Convert.ToInt32(this.Producto.Impoconsumo);
                //double costo = Convert.ToDouble(UseObject.RemoveSeparatorMil(this.txtCostoNoIvaP2.Text).ToString().Replace('.', ','));  // edicion 21/04/2019
                double costo = this.Producto.ValorCosto;  // adicion 21/04/2019
                double costoMasIva = Math.Round((costo + Math.Round((costo * Producto.ValorIva / 100), 4)), 2);
                //double costoMasIva = Convert.ToDouble(this.txtCostoConIvaP2.Text.Replace('.', ','));
                double costoCalculado = 0.0;
                var util = 0.0;
                var valUtil = 0.0;
                var valIvaUtil = 0.0;
                var venta = 0;
                var descto = 0.0;
                switch (c)
                {
                    case Calculo.Util_:
                        {
                            //***************************************************************************************************************************

                            if (!this.UtilidadAntesIva)  // Utilidad antes de IVA.
                            {
                                if (this.CalculoUtilMultiplicado)  // Incremento de utilidad multiplic.
                                {
                                    valUtil = Math.Round((costo * valor / 100), 2);
                                }
                                else
                                {
                                    valUtil = Math.Round(((costo / ((100 - valor) / 100)) - costo), 2);
                                }
                                //valIvaUtil = Math.Round((valUtil * this.MiProducto.ValorIva / 100), 2);
                                if (this.Empresa.Regimen.IdRegimen.Equals(1))
                                {
                                    valIvaUtil = Math.Round((valUtil * ivaEdit / 100), 2);
                                    //venta = Convert.ToInt32(costoMasIva + valUtil + valIvaUtil);
                                }
                                else
                                {
                                    //venta = Convert.ToInt32(costoMasIva + valUtil);
                                }
                            }
                            else
                            {
                                if (this.CalculoUtilMultiplicado)  // Incremento de utilidad multiplic.
                                {
                                    valUtil = Math.Round((costoMasIva * valor / 100), 2);
                                }
                                else
                                {
                                    valUtil = Math.Round(((costoMasIva / ((100 - valor) / 100)) - costoMasIva), 2);
                                }
                            }
                            venta = Convert.ToInt32(costoMasIva + valUtil + valIvaUtil);

                            // Nuevo codigo 22/05/2019
                            pVenta -= Convert.ToInt32(this.Producto.Impoconsumo);
                            descto = Math.Round((((pVenta - venta) / pVenta) * 100), 3);

                            venta += Convert.ToInt32(this.Producto.Impoconsumo);
                            if (this.RedondearPrecio2)
                            {
                                venta = UseObject.Aproximar(venta, AproxPrecio);
                            }

                            this.txtValorUtilidadP2.Text = valUtil.ToString().Replace(',', '.');
                            this.txtValorSugeridoP2.Text = venta.ToString().Replace(',', '.');
                            this.txtDescuentoP2.Text = descto.ToString().Replace(',', '.');

                            // Fin nuevo codigo 22/05/2019



                         //venta += Convert.ToInt32(this.Producto.Impoconsumo);
                            //descto = Math.Round((((pVenta - venta) / pVenta) * 100), 1);
                         //descto = Math.Round((((pVenta - UseObject.Aproximar(venta, AproxPrecio)) / pVenta) * 100), 3);

                         //this.txtValorUtilidadP2.Text = valUtil.ToString().Replace(',', '.');
                            //this.txtValIvaUtilidadP2.Text = valIvaUtil.ToString().Replace(',', '.');
                            //this.txtValorVentaP2.Text = venta.ToString();
                            //venta += Convert.ToInt32(this.Producto.Impoconsumo);
                         //this.txtValorSugeridoP2.Text = UseObject.Aproximar(venta, AproxPrecio).ToString().Replace(',', '.');
                         //this.txtDescuentoP2.Text = descto.ToString().Replace(',', '.');

                            //***************************************************************************************************************************
                            break;
                        }
                    case Calculo.Pventa:
                        {
                            //***************************************************************************************************************************

                            this.txtValorSugeridoP2.Text = UseObject.Aproximar(Convert.ToInt32(valor), AproxPrecio).ToString().Replace(',', '.');

                            var valorTemp = valor -= Convert.ToInt32(this.Producto.Impoconsumo);
                            pVenta -= Convert.ToInt32(this.Producto.Impoconsumo);
                            //this.txtValorSugeridoP2.Text = this.txtValorVentaP2.Text;
                            
                            if (this.Empresa.Regimen.IdRegimen.Equals(1)) //  Regimen   (Comun) 
                            {
                                costoCalculado = costo;
                            }
                            else   //  Regimen   (Simplificado) 
                            {
                                costoCalculado = costoMasIva;
                            }
                            if (!this.UtilidadAntesIva)  // Utilidad antes de IVA.
                            {
                                if (this.Empresa.Regimen.IdRegimen.Equals(1)) //  Regimen   (Comun) 
                                {
                                    valor = Convert.ToInt32(valor / (1 + (ivaEdit / 100)));
                                }
                            }

                            if (CalculoUtilMultiplicado)
                            {
                                util = Math.Round(Convert.ToDouble(((valor - costoCalculado) * 100) / costoCalculado), 2);
                            }
                            else
                            {
                                var div = Math.Round((costoCalculado / valor), 2);
                                util = Math.Round((100 - ((costoCalculado / valor) * 100)), 1);
                            }
                            //valUtil = Math.Round((valor - costoCalculado), 2);
                            valUtil = Math.Round(((costoCalculado / ((100 - util) / 100)) - costoCalculado), 2);
                            if (this.Empresa.Regimen.IdRegimen.Equals(1)) //  Regimen   (Comun) 
                            {
                                valIvaUtil = Math.Round((valUtil * ivaEdit / 100), 2);
                            }
                            //pVenta += Convert.ToInt32(this.Producto.Impoconsumo);
                            //valorTemp += Convert.ToInt32(this.Producto.Impoconsumo);
                            descto = Math.Round((((pVenta - valorTemp) / pVenta) * 100), 3);

                            this.txtUtilidadP2.Text = util.ToString().Replace(',', '.');
                            this.txtValorUtilidadP2.Text = valUtil.ToString().Replace(',', '.');
                            //this.txtValIvaUtilidadP2.Text = valIvaUtil.ToString().Replace(',', '.');
                            this.txtDescuentoP2.Text = descto.ToString().Replace(',', '.');

                            //***************************************************************************************************************************
                            break;
                        }
                    case Calculo.Descto:
                        {
                            //***************************************************************************************************************************
                            this.txtValorSugeridoP2.Text = this.txtValorVentaP2.Text;
                            var valorTemp = valor; // -= Convert.ToInt32(this.Producto.Impoconsumo);
                            //this.txtValorSugeridoP2.Text = this.txtValorVentaP2.Text;
                            if (this.Empresa.Regimen.IdRegimen.Equals(1)) //  Regimen   (Comun) 
                            {
                                costoCalculado = costo;
                            }
                            else   //  Regimen   (Simplificado) 
                            {
                                costoCalculado = costoMasIva;
                            }
                            if (!this.UtilidadAntesIva)  // Utilidad antes de IVA.
                            {
                                if (this.Empresa.Regimen.IdRegimen.Equals(1)) //  Regimen   (Comun) 
                                {
                                    valor = Convert.ToInt32(valor / (1 + (ivaEdit / 100)));
                                }
                            }

                            if (CalculoUtilMultiplicado)
                            {
                                util = Math.Round(Convert.ToDouble(((valor - costoCalculado) * 100) / costoCalculado), 2);
                            }
                            else
                            {
                                var div = Math.Round((costoCalculado / valor), 2);
                                util = Math.Round((100 - ((costoCalculado / valor) * 100)), 1);
                            }
                            //valUtil = Math.Round((valor - costoCalculado), 2);
                            valUtil = Math.Round(((costoCalculado / ((100 - util) / 100)) - costoCalculado), 2);
                            if (this.Empresa.Regimen.IdRegimen.Equals(1)) //  Regimen   (Comun) 
                            {
                                valIvaUtil = Math.Round((valUtil * ivaEdit / 100), 2);
                            }
                            //descto = Math.Round((((pVenta - valorTemp) / pVenta) * 100), 1);

                            valorTemp += Convert.ToInt32(this.Producto.Impoconsumo);

                            this.txtUtilidadP2.Text = util.ToString().Replace(',', '.');
                            this.txtValorUtilidadP2.Text = valUtil.ToString().Replace(',', '.');
                            //this.txtValIvaUtilidadP2.Text = valIvaUtil.ToString().Replace(',', '.');
                            //this.txtValorVentaP2.Text = valorTemp.ToString();
                           // valorTemp += Convert.ToInt32(this.Producto.Impoconsumo);
                            this.txtValorVentaP2.Text = valorTemp.ToString();
                            this.txtValorSugeridoP2.Text = UseObject.Aproximar(Convert.ToInt32(valorTemp), AproxPrecio).ToString().Replace(',', '.');
                            //this.txtDescuentoP2.Text = descto.ToString().Replace(',', '.');

                            //***************************************************************************************************************************
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void EditaVentaPrecioTres(Calculo c, double valor)
        {
            try
            {
                double ivaEdit = this.Producto.ValorIva; //((Iva)cbIvaEditar.SelectedItem).PorcentajeIva;
                double util3Edit = Convert.ToDouble(this.txtUtilidadP3.Text.ToString().Replace('.', ','));

                //double pVenta = Convert.ToDouble(this.txtValorSugeridoP1.Text);
                double pVenta = Convert.ToDouble(this.txtValorVentaP1.Text);
                // double costo = Convert.ToDouble(UseObject.RemoveSeparatorMil(this.txtCostoNoIvaP2.Text).ToString().Replace('.', ','));   // edicion 21/04/2019
                double costo = this.Producto.ValorCosto;  // adicion 21/04/2019
                //double costoMasIva = Convert.ToDouble(this.txtCostoConIvaP3.Text.Replace('.', ','));
                double costoMasIva = Math.Round((costo + Math.Round((costo * Producto.ValorIva / 100), 4)), 2);
                double costoCalculado = 0.0;
                var util = 0.0;
                var valUtil = 0.0;
                var valIvaUtil = 0.0;
                var venta = 0;
                var descto = 0.0;
                switch (c)
                {
                    case Calculo.Util_:
                        {
                            //***************************************************************************************************************************

                            if (!this.UtilidadAntesIva)  // Utilidad antes de IVA.
                            {
                                if (this.CalculoUtilMultiplicado)  // Incremento de utilidad multiplic.
                                {
                                    valUtil = Math.Round((costo * valor / 100), 2);
                                }
                                else
                                {
                                    valUtil = Math.Round(((costo / ((100 - valor) / 100)) - costo), 2);
                                }
                                //valIvaUtil = Math.Round((valUtil * this.MiProducto.ValorIva / 100), 2);
                                if (this.Empresa.Regimen.IdRegimen.Equals(1))
                                {
                                    valIvaUtil = Math.Round((valUtil * ivaEdit / 100), 2);
                                    //venta = Convert.ToInt32(costoMasIva + valUtil + valIvaUtil);
                                }
                                else
                                {
                                    //venta = Convert.ToInt32(costoMasIva + valUtil);
                                }
                            }
                            else
                            {
                                if (this.CalculoUtilMultiplicado)  // Incremento de utilidad multiplic.
                                {
                                    valUtil = Math.Round((costoMasIva * valor / 100), 2);
                                }
                                else
                                {
                                    valUtil = Math.Round(((costoMasIva / ((100 - valor) / 100)) - costoMasIva), 2);
                                }
                            }
                            venta = Convert.ToInt32(costoMasIva + valUtil + valIvaUtil);

                            //descto = Math.Round((((pVenta - venta) / pVenta) * 100), 1);
                         //descto = Math.Round((((pVenta - UseObject.Aproximar(venta, AproxPrecio)) / pVenta) * 100), 1);

                         //this.txtValorUtilidadP3.Text = valUtil.ToString().Replace(',', '.');
                            //this.txtValIvaUtilidadP3.Text = valIvaUtil.ToString().Replace(',', '.');
                            //this.txtValorVentaP3.Text = venta.ToString();
                         //this.txtValorSugeridoP3.Text = UseObject.Aproximar(venta, AproxPrecio).ToString().Replace(',', '.');
                         //this.txtDescuentoP3.Text = descto.ToString().Replace(',', '.');

                            // Nuevo codigo 22/05/2019
                            pVenta -= Convert.ToInt32(this.Producto.Impoconsumo);
                            descto = Math.Round((((pVenta - venta) / pVenta) * 100), 3);

                            venta += Convert.ToInt32(this.Producto.Impoconsumo);
                            if (this.RedondearPrecio2)
                            {
                                venta = UseObject.Aproximar(venta, AproxPrecio);
                            }

                            this.txtValorUtilidadP3.Text = valUtil.ToString().Replace(',', '.');
                            this.txtValorSugeridoP3.Text = venta.ToString().Replace(',', '.');
                            this.txtDescuentoP3.Text = descto.ToString().Replace(',', '.');

                            // Fin nuevo codigo 22/05/2019

                            //***************************************************************************************************************************
                            break;
                        }
                    case Calculo.Pventa:
                        {
                            //***************************************************************************************************************************
                           /* var valorTemp = valor;
                            //this.txtValorSugeridoP3.Text = this.txtValorVentaP3.Text;
                            this.txtValorSugeridoP3.Text = UseObject.Aproximar(Convert.ToInt32(valor), AproxPrecio).ToString().Replace(',', '.');

                            valorTemp = valor -= Convert.ToInt32(this.Producto.Impoconsumo);
                            pVenta -= Convert.ToInt32(this.Producto.Impoconsumo);*/



                            this.txtValorSugeridoP3.Text = UseObject.Aproximar(Convert.ToInt32(valor), AproxPrecio).ToString().Replace(',', '.');

                            var valorTemp = valor -= Convert.ToInt32(this.Producto.Impoconsumo);
                            pVenta -= Convert.ToInt32(this.Producto.Impoconsumo);


                            if (this.Empresa.Regimen.IdRegimen.Equals(1)) //  Regimen   (Comun) 
                            {
                                costoCalculado = costo;
                            }
                            else   //  Regimen   (Simplificado) 
                            {
                                costoCalculado = costoMasIva;
                            }
                            if (!this.UtilidadAntesIva)  // Utilidad antes de IVA.
                            {
                                if (this.Empresa.Regimen.IdRegimen.Equals(1)) //  Regimen   (Comun) 
                                {
                                    valor = Convert.ToInt32(valor / (1 + (ivaEdit / 100)));
                                }
                            }

                            if (CalculoUtilMultiplicado)
                            {
                                util = Math.Round(Convert.ToDouble(((valor - costoCalculado) * 100) / costoCalculado), 2);
                            }
                            else
                            {
                                var div = Math.Round((costoCalculado / valor), 2);
                                util = Math.Round((100 - ((costoCalculado / valor) * 100)), 1);
                            }
                            //valUtil = Math.Round((valor - costoCalculado), 2);
                            valUtil = Math.Round(((costoCalculado / ((100 - util) / 100)) - costoCalculado), 2);
                            if (this.Empresa.Regimen.IdRegimen.Equals(1)) //  Regimen   (Comun) 
                            {
                                valIvaUtil = Math.Round((valUtil * ivaEdit / 100), 2);
                            }
                            descto = Math.Round((((pVenta - valorTemp) / pVenta) * 100), 3);

                            this.txtUtilidadP3.Text = util.ToString().Replace(',', '.');
                            this.txtValorUtilidadP3.Text = valUtil.ToString().Replace(',', '.');
                           // this.txtValIvaUtilidadP3.Text = valIvaUtil.ToString().Replace(',', '.');
                            this.txtDescuentoP3.Text = descto.ToString().Replace(',', '.');

                            //***************************************************************************************************************************
                            break;
                        }
                    case Calculo.Descto:
                        {
                            //***************************************************************************************************************************

                            var valorTemp = valor;
                            // this.txtValorSugeridoP3.Text = this.txtValorVentaP3.Text;
                            if (this.Empresa.Regimen.IdRegimen.Equals(1)) //  Regimen   (Comun) 
                            {
                                costoCalculado = costo;
                            }
                            else   //  Regimen   (Simplificado) 
                            {
                                costoCalculado = costoMasIva;
                            }
                            if (!this.UtilidadAntesIva)  // Utilidad antes de IVA.
                            {
                                if (this.Empresa.Regimen.IdRegimen.Equals(1)) //  Regimen   (Comun) 
                                {
                                    valor = Convert.ToInt32(valor / (1 + (ivaEdit / 100)));
                                }
                            }

                            if (CalculoUtilMultiplicado)
                            {
                                util = Math.Round(Convert.ToDouble(((valor - costoCalculado) * 100) / costoCalculado), 2);
                            }
                            else
                            {
                                var div = Math.Round((costoCalculado / valor), 2);
                                util = Math.Round((100 - ((costoCalculado / valor) * 100)), 1);
                            }
                            //valUtil = Math.Round((valor - costoCalculado), 2);
                            valUtil = Math.Round(((costoCalculado / ((100 - util) / 100)) - costoCalculado), 2);
                            if (this.Empresa.Regimen.IdRegimen.Equals(1)) //  Regimen   (Comun) 
                            {
                                valIvaUtil = Math.Round((valUtil * ivaEdit / 100), 2);
                            }
                            //descto = Math.Round((((pVenta - valorTemp) / pVenta) * 100), 1);
                            valorTemp += Convert.ToInt32(this.Producto.Impoconsumo);

                            this.txtUtilidadP3.Text = util.ToString().Replace(',', '.');
                            this.txtValorUtilidadP3.Text = valUtil.ToString().Replace(',', '.');
                            //this.txtValIvaUtilidadP3.Text = valIvaUtil.ToString().Replace(',', '.');
                            this.txtValorVentaP3.Text = valorTemp.ToString();
                            this.txtValorSugeridoP3.Text = UseObject.Aproximar(Convert.ToInt32(valorTemp), AproxPrecio).ToString().Replace(',', '.');
                            //this.txtDescuentoP2.Text = descto.ToString().Replace(',', '.');
                            

                            //***************************************************************************************************************************
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }


        private void EditaVentaPrecioCuatro(Calculo c, double valor)
        {
            try
            {
                double ivaEdit = this.Producto.ValorIva; //((Iva)cbIvaEditar.SelectedItem).PorcentajeIva;
                //double util4Edit = Convert.ToDouble(this.txtUtilidadP4.Text.ToString().Replace('.', ','));

                //double pVenta = Convert.ToDouble(this.txtValorSugeridoP1.Text);
                double pVenta = Convert.ToDouble(this.txtValorVentaP1.Text);
                // double costo = Convert.ToDouble(UseObject.RemoveSeparatorMil(this.txtCostoNoIvaP2.Text).ToString().Replace('.', ','));   // edicion 21/04/2019
                double costo = this.Producto.ValorCosto;  // adicion 21/04/2019
                //double costoMasIva = Convert.ToDouble(this.txtCostoConIvaP3.Text.Replace('.', ','));
                double costoMasIva = Math.Round((costo + Math.Round((costo * Producto.ValorIva / 100), 4)), 2);
                double costoCalculado = 0.0;
                var util = 0.0;
                var valUtil = 0.0;
                var valIvaUtil = 0.0;
                var venta = 0;
                var descto = 0.0;
                switch (c)
                {
                    case Calculo.Util_:
                        {
                            //***************************************************************************************************************************

                            if (!this.UtilidadAntesIva)  // Utilidad antes de IVA.
                            {
                                if (this.CalculoUtilMultiplicado)  // Incremento de utilidad multiplic.
                                {
                                    valUtil = Math.Round((costo * valor / 100), 2);
                                }
                                else
                                {
                                    valUtil = Math.Round(((costo / ((100 - valor) / 100)) - costo), 2);
                                }
                                //valIvaUtil = Math.Round((valUtil * this.MiProducto.ValorIva / 100), 2);
                                if (this.Empresa.Regimen.IdRegimen.Equals(1))
                                {
                                    valIvaUtil = Math.Round((valUtil * ivaEdit / 100), 2);
                                    //venta = Convert.ToInt32(costoMasIva + valUtil + valIvaUtil);
                                }
                                else
                                {
                                    //venta = Convert.ToInt32(costoMasIva + valUtil);
                                }
                            }
                            else
                            {
                                if (this.CalculoUtilMultiplicado)  // Incremento de utilidad multiplic.
                                {
                                    valUtil = Math.Round((costoMasIva * valor / 100), 2);
                                }
                                else
                                {
                                    valUtil = Math.Round(((costoMasIva / ((100 - valor) / 100)) - costoMasIva), 2);
                                }
                            }
                            venta = Convert.ToInt32(costoMasIva + valUtil + valIvaUtil);

                            // Nuevo codigo 22/05/2019
                            pVenta -= Convert.ToInt32(this.Producto.Impoconsumo);
                            descto = Math.Round((((pVenta - venta) / pVenta) * 100), 3);

                            venta += Convert.ToInt32(this.Producto.Impoconsumo);
                            if (this.RedondearPrecio2)
                            {
                                venta = UseObject.Aproximar(venta, AproxPrecio);
                            }

                            this.txtValorUtilidadP4.Text = valUtil.ToString().Replace(',', '.');
                            this.txtValorSugeridoP4.Text = venta.ToString().Replace(',', '.');
                            this.txtDescuentoP4.Text = descto.ToString().Replace(',', '.');

                            // Fin nuevo codigo 22/05/2019

                            //***************************************************************************************************************************
                            break;
                        }
                    case Calculo.Pventa:
                        {
                            //***************************************************************************************************************************
                            this.txtValorSugeridoP4.Text = UseObject.Aproximar(Convert.ToInt32(valor), AproxPrecio).ToString().Replace(',', '.');

                            var valorTemp = valor -= Convert.ToInt32(this.Producto.Impoconsumo);
                            pVenta -= Convert.ToInt32(this.Producto.Impoconsumo);


                            if (this.Empresa.Regimen.IdRegimen.Equals(1)) //  Regimen   (Comun) 
                            {
                                costoCalculado = costo;
                            }
                            else   //  Regimen   (Simplificado) 
                            {
                                costoCalculado = costoMasIva;
                            }
                            if (!this.UtilidadAntesIva)  // Utilidad antes de IVA.
                            {
                                if (this.Empresa.Regimen.IdRegimen.Equals(1)) //  Regimen   (Comun) 
                                {
                                    valor = Convert.ToInt32(valor / (1 + (ivaEdit / 100)));
                                }
                            }

                            if (CalculoUtilMultiplicado)
                            {
                                util = Math.Round(Convert.ToDouble(((valor - costoCalculado) * 100) / costoCalculado), 2);
                            }
                            else
                            {
                                var div = Math.Round((costoCalculado / valor), 2);
                                util = Math.Round((100 - ((costoCalculado / valor) * 100)), 1);
                            }
                            //valUtil = Math.Round((valor - costoCalculado), 2);
                            valUtil = Math.Round(((costoCalculado / ((100 - util) / 100)) - costoCalculado), 2);
                            if (this.Empresa.Regimen.IdRegimen.Equals(1)) //  Regimen   (Comun) 
                            {
                                valIvaUtil = Math.Round((valUtil * ivaEdit / 100), 2);
                            }
                            descto = Math.Round((((pVenta - valorTemp) / pVenta) * 100), 3);

                            this.txtUtilidadP4.Text = util.ToString().Replace(',', '.');
                            this.txtValorUtilidadP4.Text = valUtil.ToString().Replace(',', '.');
                            // this.txtValIvaUtilidadP3.Text = valIvaUtil.ToString().Replace(',', '.');
                            this.txtDescuentoP4.Text = descto.ToString().Replace(',', '.');

                            //***************************************************************************************************************************
                            break;
                        }
                    case Calculo.Descto:
                        {
                            //***************************************************************************************************************************

                            var valorTemp = valor;
                            // this.txtValorSugeridoP3.Text = this.txtValorVentaP3.Text;
                            if (this.Empresa.Regimen.IdRegimen.Equals(1)) //  Regimen   (Comun) 
                            {
                                costoCalculado = costo;
                            }
                            else   //  Regimen   (Simplificado) 
                            {
                                costoCalculado = costoMasIva;
                            }
                            if (!this.UtilidadAntesIva)  // Utilidad antes de IVA.
                            {
                                if (this.Empresa.Regimen.IdRegimen.Equals(1)) //  Regimen   (Comun) 
                                {
                                    valor = Convert.ToInt32(valor / (1 + (ivaEdit / 100)));
                                }
                            }

                            if (CalculoUtilMultiplicado)
                            {
                                util = Math.Round(Convert.ToDouble(((valor - costoCalculado) * 100) / costoCalculado), 2);
                            }
                            else
                            {
                                var div = Math.Round((costoCalculado / valor), 2);
                                util = Math.Round((100 - ((costoCalculado / valor) * 100)), 1);
                            }
                            //valUtil = Math.Round((valor - costoCalculado), 2);
                            valUtil = Math.Round(((costoCalculado / ((100 - util) / 100)) - costoCalculado), 2);
                            if (this.Empresa.Regimen.IdRegimen.Equals(1)) //  Regimen   (Comun) 
                            {
                                valIvaUtil = Math.Round((valUtil * ivaEdit / 100), 2);
                            }
                            //descto = Math.Round((((pVenta - valorTemp) / pVenta) * 100), 1);
                            valorTemp += Convert.ToInt32(this.Producto.Impoconsumo);

                            this.txtUtilidadP4.Text = util.ToString().Replace(',', '.');
                            this.txtValorUtilidadP4.Text = valUtil.ToString().Replace(',', '.');
                            //this.txtValIvaUtilidadP3.Text = valIvaUtil.ToString().Replace(',', '.');
                            this.txtValorVentaP4.Text = valorTemp.ToString();
                            this.txtValorSugeridoP4.Text = UseObject.Aproximar(Convert.ToInt32(valorTemp), AproxPrecio).ToString().Replace(',', '.');
                            //this.txtDescuentoP2.Text = descto.ToString().Replace(',', '.');


                            //***************************************************************************************************************************
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }



        private bool ValidacionGuardado()
        {
            if (Convert.ToDouble(this.txtUtilidadP1.Text.Replace('.', ',')) < 0)
            {
                this.miError.SetError(this.txtUtilidadP1, "El valor es incorrecto.");
                this.UtilMatch = false;
            }
            else
            {
                this.miError.SetError(this.txtUtilidadP1, null);
                this.UtilMatch = true;
            }

            if (Convert.ToDouble(this.txtUtilidadP2.Text.Replace('.', ',')) < 0)
            {
                this.miError.SetError(this.txtUtilidadP2, "El valor es incorrecto.");
                this.Util2Match = false;
            }
            else
            {
                this.miError.SetError(this.txtUtilidadP2, null);
                this.Util2Match = true;
            }

            if (Convert.ToDouble(this.txtUtilidadP3.Text.Replace('.', ',')) < 0)
            {
                this.miError.SetError(this.txtUtilidadP3, "El valor es incorrecto.");
                this.Util3Match = false;
            }
            else
            {
                this.miError.SetError(this.txtUtilidadP3, null);
                this.Util3Match = true;
            }

            if (Convert.ToDouble(this.txtValorVentaP1.Text.Replace('.', ',')) < 0)
            {
                this.miError.SetError(this.txtValorVentaP1, "El valor es incorrecto.");
                this.PrecioVentaMatch = false;
            }
            else
            {
                this.miError.SetError(this.txtValorVentaP1, null);
                this.PrecioVentaMatch = true;
            }

            if (Convert.ToDouble(this.txtValorVentaP2.Text.Replace('.', ',')) < 0)
            {
                this.miError.SetError(this.txtValorVentaP2, "El valor es incorrecto.");
                this.PrecioVenta2Match = false;
            }
            else
            {
                this.miError.SetError(this.txtValorVentaP2, null);
                this.PrecioVenta2Match = true;
            }

            if (Convert.ToDouble(this.txtValorVentaP3.Text.Replace('.', ',')) < 0)
            {
                this.miError.SetError(this.txtValorVentaP3, "El valor es incorrecto.");
                this.PrecioVenta3Match = false;
            }
            else
            {
                this.miError.SetError(this.txtValorVentaP3, null);
                this.PrecioVenta3Match = true;
            }

            if (Convert.ToDouble(this.txtDescuentoP2DB.Text.Replace('.', ',')) < 0)
            {
                this.miError.SetError(this.txtDescuentoP2DB, "El valor es incorrecto.");
                this.Descto2Match = false;
            }
            else
            {
                this.miError.SetError(this.txtDescuentoP2DB, null);
                this.Descto2Match = true;
            }

            if (Convert.ToDouble(this.txtDescuentoP3DB.Text.Replace('.', ',')) < 0)
            {
                this.miError.SetError(this.txtDescuentoP3DB, "El valor es incorrecto.");
                this.Descto3Match = false;
            }
            else
            {
                this.miError.SetError(this.txtDescuentoP3DB, null);
                this.Descto3Match = true;
            }

            if (this.UtilMatch &&
                this.Util2Match &&
                this.Util3Match &&
                this.PrecioVentaMatch &&
                this.PrecioVenta2Match &&
                this.PrecioVenta3Match &&
                this.Descto2Match &&
                this.Descto3Match)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void LimpiarErrorProvider()
        {
            this.miError.SetError(this.txtCostoNoIvaP1, null);
            this.miError.SetError(this.txtUtilidadP1, null);
            this.miError.SetError(this.txtUtilidadP2, null);
            this.miError.SetError(this.txtUtilidadP3, null);
            this.miError.SetError(this.txtValorVentaP1, null);
            this.miError.SetError(this.txtValorVentaP2, null);
            this.miError.SetError(this.txtValorVentaP3, null);
            this.miError.SetError(this.txtDescuentoP2DB, null);
            this.miError.SetError(this.txtDescuentoP3DB, null);
        }

    }
}