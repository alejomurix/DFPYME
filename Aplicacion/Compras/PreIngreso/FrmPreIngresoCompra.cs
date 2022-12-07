using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DTO.Clases;
using BussinesLayer.Clases;
using CustomControl;
using Utilities;
using Aplicacion.Compras.IngresarCompra;

namespace Aplicacion.Compras.PreIngreso
{
    public partial class FrmPreIngresoCompra : Form
    {
        private DTO.Clases.Proveedor Proveedor;

        private Producto Producto;

        private ValorUnidadMedida miMedida;

        private TallaYcolor miTallaYcolor;


        private bool SingleSize;

        private bool SingleColor;

        private ErrorProvider miError;

        private bool CantidadMatch;

        private bool CostoMatch;

        private bool CostoIvaMatch;

        private bool D1Match;

        private bool D2Match;

        private bool ProveedorMatch;

        private bool NumeroMatch;

        private BussinesProveedor miBussinesProveedor;

        private BussinesProducto miBussinesProducto;

        private BussinesValorUnidadMedida miBussinesMedida;

        private BussinesColor miBussinesColor;

        private BussinesFacturaProveedor miBussinesFactura;

        private BussinesIva miBussinesIva;

        private BussinesInventario miBussinesInventario;


        private DataTable Tproductos;

        private int Contador;

        public FrmPreIngresoCompra()
        {
            InitializeComponent();
            this.miError = new ErrorProvider();
            this.CantidadMatch = false;
            this.CostoMatch = false;
            this.CostoIvaMatch = false;
            this.D1Match = false;
            this.D2Match = false;
            this.ProveedorMatch = false;
            this.NumeroMatch = false;
            this.SingleSize = false;
            this.Contador = 1;
            this.miBussinesProveedor = new BussinesProveedor();
            this.miBussinesProducto = new BussinesProducto();
            this.miBussinesMedida = new BussinesValorUnidadMedida();
            this.miBussinesColor = new BussinesColor();
            this.miBussinesFactura = new BussinesFacturaProveedor();
            this.miBussinesIva = new BussinesIva();
            this.miBussinesInventario = new BussinesInventario();

            this.Tproductos = new DataTable();
            Tproductos.Columns.Add(new DataColumn("Id", typeof(int)));
            Tproductos.Columns.Add(new DataColumn("Codigo", typeof(string)));
            Tproductos.Columns.Add(new DataColumn("Producto", typeof(string)));
            Tproductos.Columns.Add(new DataColumn("IdMedida", typeof(int)));
            Tproductos.Columns.Add(new DataColumn("IdColor", typeof(int)));
            Tproductos.Columns.Add(new DataColumn("Lote", typeof(string)));
            Tproductos.Columns.Add(new DataColumn("Cantidad", typeof(double)));
            Tproductos.Columns.Add(new DataColumn("Valor", typeof(double)));
            Tproductos.Columns.Add(new DataColumn("Iva", typeof(double)));
            Tproductos.Columns.Add(new DataColumn("Descuento", typeof(double)));
            Tproductos.Columns.Add(new DataColumn("Descuento2", typeof(double)));
            Tproductos.Columns.Add(new DataColumn("ValorUnitario", typeof(double)));
            Tproductos.Columns.Add(new DataColumn("Total", typeof(double)));
        }

        private void FrmPreIngresoCompra_Load(object sender, EventArgs e)
        {
            CompletaEventos.Completa += new CompletaEventos.CompletaAccion(CompletaEventos_Completo);
            CompletaEventos.CompAxTInvFactProvee += new CompletaEventos.ComAxTransferInvFactProve(CompletaEventos_CompAxTInvFactProvee);
            this.dgvListaArticulos.AutoGenerateColumns = false;
        }

        private void FrmPreIngresoCompra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.F2))
            {
                this.tsGuardar_Click(this.tsGuardar, new EventArgs());
            }
            else
            {
                if (e.KeyData.Equals(Keys.Escape))
                {
                    DialogResult rta = MessageBox.Show("¿Está seguro(a) de salir?", "Preingreso",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (rta.Equals(DialogResult.Yes))
                    {
                        this.Close();
                    }
                }
            }
        }

        private void tsGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvListaArticulos.RowCount != 0)
                {
                    ValidarProveedor();
                    this.txtNumeroFactura_Validating(this.txtNumeroFactura, new CancelEventArgs(false));
                    if (this.ProveedorMatch && this.NumeroMatch)
                    {
                        DialogResult rta = MessageBox.Show("¿Esta seguro(a) de guardar la compra?", "Registro de compra",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (rta.Equals(DialogResult.Yes))
                        {
                            var factura = new FacturaProveedor();
                            factura.Proveedor.CodigoInternoProveedor = this.Proveedor.CodigoInternoProveedor;
                            factura.Numero = this.txtNumeroFactura.Text;
                            factura.FechaFactura = factura.FechaIngreso = this.dtpFecha.Value;
                            factura.Productos = Productos();
                            this.miBussinesFactura.IngresarCompraTemporal(factura);
                            OptionPane.MessageInformation("La compra se guardo con exito.");
                            this.txtCodigoProveedor.Focus();
                            this.Proveedor = null;
                            this.txtNombreProveedor.Text = "";
                            this.dtpFecha.Value = DateTime.Now;
                            this.txtNumeroFactura.Text = "";
                            this.Tproductos.Rows.Clear();
                            this.dgvListaArticulos.DataSource = null;
                            this.txtTotal.Text = "";
                        }
                    }
                }
                else
                {
                    OptionPane.MessageInformation("Debe cargar registros de productos.");
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

        private void txtNumeroFactura_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.txtCodigoArticulo.Focus();
            }
        }

        private void txtNumeroFactura_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtNumeroFactura.Text))
            {
                this.miError.SetError(txtNumeroFactura, "El proveedor es requerido.");
                this.NumeroMatch = false;
            }
            else
            {
                this.miError.SetError(txtNumeroFactura, null);
                this.NumeroMatch = true;
            }
        }

        private void txtCodigoArticulo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                try
                {
                    if (!String.IsNullOrEmpty(this.txtCodigoArticulo.Text))
                    {
                        if (CodigoOrString(txtCodigoArticulo.Text))
                        {
                            var ArrayProducto = this.miBussinesProducto.ProductoBasico(this.txtCodigoArticulo.Text);
                            if (ArrayProducto.Count != 0)
                            {
                                this.miError.SetError(this.txtCodigoArticulo, null);
                                this.Producto = (DTO.Clases.Producto)ArrayProducto[0];
                                //this.Producto.ValorIva = this.miBussinesIva.Iva(this.Producto.IdIvaTemp).PorcentajeIva;
                                var tabla = miBussinesMedida.MedidasDeProducto(this.Producto.CodigoInternoProducto);
                                if (!this.Producto.AplicaTalla)
                                {
                                    miMedida = (ValorUnidadMedida)ArrayProducto[1];
                                    SingleSize = true;
                                }
                                else
                                {
                                    if (tabla.Rows.Count == 1)
                                    {
                                        var q = (from d in tabla.AsEnumerable()
                                                 select d).Single();
                                        miTallaYcolor.IdTalla = Convert.ToInt32(q["idvalor_unidad_medida"]);
                                        miTallaYcolor.Talla = q["descripcionvalor_unidad_medida"].ToString();
                                        q = null;
                                        SingleSize = true;
                                    }
                                    else
                                    {
                                        SingleSize = false;
                                    }
                                }
                                if (this.Producto.AplicaColor)
                                {
                                    if (tabla.Rows.Count == 1)
                                    {
                                        var q = (from d in tabla.AsEnumerable()
                                                 select d).Single();
                                        var tablaColor = miBussinesColor.ColoresDeProducto
                                            (this.Producto.CodigoInternoProducto, Convert.ToInt32(q["idvalor_unidad_medida"]));
                                        if (tablaColor.Rows.Count.Equals(1))
                                        {
                                            var c = (from d in tablaColor.AsEnumerable()
                                                     select d).Single();
                                            miTallaYcolor.IdColor = Convert.ToInt32(c["idcolor"]);
                                            miTallaYcolor.Color = (Image)c["ImagenBit"];
                                            SingleColor = true;
                                        }
                                        else
                                        {
                                            SingleColor = false;
                                        }
                                    }
                                    else
                                    {
                                        SingleColor = false;
                                    }
                                }
                                else
                                {
                                    SingleColor = true;
                                }

                                this.lblDatosProducto.Text = this.Producto.CodigoInternoProducto + " - " + this.Producto.NombreProducto;

                                this.txtCostoBase.Text = this.Producto.ValorCosto.ToString().Replace(',', '.');
                                this.txtCostoMasIva.Text = Math.Round((this.Producto.ValorCosto +
                                    (this.Producto.ValorCosto * this.Producto.ValorIva / 100)), 2).ToString().Replace(',', '.');

                                this.txtDescuento1.Text = "0";
                                this.txtDescuento2.Text = "0";

                                this.txtCostoBaseInfo.Text = this.txtCostoBase.Text;
                                this.txtIvaInfo.Text = this.Producto.ValorIva.ToString().Replace(',', '.');
                                this.txtCostoMasIvaInfo.Text = this.txtCostoMasIva.Text;
                                if (!this.Producto.AplicaTalla)
                                {
                                    this.txtCantInventario.Text = this.miBussinesInventario.CantidadInventario(
                                        new DTO.Clases.Inventario
                                        {
                                            CodigoProducto = this.Producto.CodigoInternoProducto,
                                            IdMedida = this.miMedida.IdValorUnidadMedida,
                                            IdColor = 0
                                        }).ToString().Replace(',', '.');
                                }
                                else
                                {
                                    this.txtCantInventario.Text = this.miBussinesInventario.CantidadInventario(
                                        new DTO.Clases.Inventario
                                        {
                                            CodigoProducto = this.Producto.CodigoInternoProducto,
                                            IdMedida = this.miTallaYcolor.IdTalla,
                                            IdColor = this.miTallaYcolor.IdColor
                                        }).ToString().Replace(',', '.');
                                }
                                this.txtCantPreingreso.Text =
                                    this.miBussinesFactura.CantidadProductoCompraTemporal(this.Producto.CodigoInternoProducto).ToString().Replace(',', '.');
                                this.txtCantUltCompra.Text =
                                    this.miBussinesFactura.CantidadProductoCompra(this.Producto.CodigoInternoProducto).ToString().Replace(',', '.');
                              
                                if (!SingleSize || !SingleColor)
                                {
                                    btnTallaYcolor.Enabled = true;
                                }
                                else
                                {
                                    btnTallaYcolor.Enabled = false;
                                }
                                this.txtCodigoArticulo.Text = "";
                                this.txtCantidad.Focus();
                            }
                            else
                            {
                                this.miError.SetError(this.txtCodigoArticulo, "El producto no existe.");
                            }
                        }
                        else
                        {
                            var formInventario = new Inventario.Consulta.FrmConsultaInventario();
                            //formInventario.MdiParent = this.MdiParent;
                            formInventario.ExtendVenta = true;
                            formInventario.IsCompra = true;

                            formInventario.IdTipoInventarioNoFabricado = 3;
                            formInventario.IdTipoInventarioFabricado = 4;

                            formInventario.txtCodigoNombre.Text = txtCodigoArticulo.Text;
                            //FormInventario = true;
                            formInventario.ShowDialog();
                            if (this.Producto != null)
                            {
                                this.txtCantidad.Focus();
                            }
                            //formInventario.dgvInventario.Focus();
                        }
                    }
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void txtCantidad_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(this.txtCantidad.Text))
            {
                if (ValidarDecimal(this.txtCantidad.Text))
                {
                    this.miError.SetError(this.txtCantidad, null);
                    this.CantidadMatch = true;
                }
                else
                {
                    this.miError.SetError(this.txtCantidad, "El valor es incorrecto.");
                    this.CantidadMatch = false;
                }
            }
            else
            {
                this.miError.SetError(this.txtCantidad, "El campo es requerido.");
                this.CantidadMatch = false;
            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.txtCostoBase.Focus();
                this.txtCostoBase.SelectAll();
            }
        }

        private void txtCostoBase_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(this.txtCostoBase.Text))
            {
                if (ValidarDecimal(this.txtCostoBase.Text))
                {
                    this.miError.SetError(this.txtCostoBase, null);
                    this.CostoMatch = true;
                }
                else
                {
                    this.miError.SetError(this.txtCostoBase, "El valor es incorrecto.");
                    this.CostoMatch = false;
                }
            }
            else
            {
                this.miError.SetError(this.txtCostoBase, "El campo es requerido.");
                this.CostoMatch = false;
            }
        }

        private void txtCostoBase_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                if (!String.IsNullOrEmpty(this.txtCostoBase.Text))
                {
                    if (ValidarDecimal(this.txtCostoBase.Text))
                    {
                        this.miError.SetError(this.txtCostoBase, null);
                        this.CostoMatch = true;

                        this.txtCostoMasIva.Text = Math.Round((Convert.ToDouble(this.txtCostoBase.Text.Replace('.', ',')) +
                        (Convert.ToDouble(this.txtCostoBase.Text.Replace('.', ',')) * this.Producto.ValorIva / 100)), 2).ToString().Replace(',', '.');
                    }
                    else
                    {
                        this.miError.SetError(this.txtCostoBase, "El valor es incorrecto.");
                        this.CostoMatch = false;
                    }
                }
                else
                {
                    this.miError.SetError(this.txtCostoBase, "El campo es requerido.");
                    this.CostoMatch = false;
                }
                this.txtCostoMasIva.Focus();
                this.txtCostoMasIva.SelectAll();
            }
        }

        private void txtCostoMasIva_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(this.txtCostoMasIva.Text))
            {
                if (ValidarDecimal(this.txtCostoMasIva.Text))
                {
                    this.miError.SetError(this.txtCostoMasIva, null);
                    this.CostoIvaMatch = true;
                }
                else
                {
                    this.miError.SetError(this.txtCostoMasIva, "El valor es incorrecto.");
                    this.CostoIvaMatch = false;
                }
            }
            else
            {
                this.miError.SetError(this.txtCostoMasIva, "El campo es requerido.");
                this.CostoIvaMatch = false;
            }
        }

        private void txtCostoMasIva_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                if (!String.IsNullOrEmpty(this.txtCostoMasIva.Text))
                {
                    if (ValidarDecimal(this.txtCostoMasIva.Text))
                    {
                        this.miError.SetError(this.txtCostoMasIva, null);
                        this.CostoIvaMatch = true;

                        this.txtCostoBase.Text = Math.Round(
                            (Convert.ToDouble(this.txtCostoMasIva.Text.Replace('.', ',')) / (1 + (this.Producto.ValorIva / 100))), 2).
                             ToString().Replace(',', '.');
                        this.txtDescuento1.Focus();
                        //this.btnAgregar_Click(this.btnAgregar, new EventArgs());
                    }
                    else
                    {
                        this.miError.SetError(this.txtCostoMasIva, "El valor es incorrecto.");
                        this.CostoIvaMatch = false;
                    }
                }
                else
                {
                    this.miError.SetError(this.txtCostoMasIva, "El campo es requerido.");
                    this.CostoIvaMatch = false;
                }
            }
        }

        private void txtDescuento1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                if (!String.IsNullOrEmpty(this.txtDescuento1.Text))
                {
                    if (ValidarDecimal(this.txtDescuento1.Text))
                    {
                        this.miError.SetError(this.txtDescuento1, null);
                        //this.CostoIvaMatch = true;

                        /*this.txtCostoBase.Text = Math.Round(
                            (Convert.ToDouble(this.txtCostoMasIva.Text.Replace('.', ',')) / (1 + (this.Producto.ValorIva / 100))), 2).
                             ToString().Replace(',', '.');*/
                        this.txtDescuento2.Focus();
                        //this.btnAgregar_Click(this.btnAgregar, new EventArgs());
                    }
                    else
                    {
                        this.miError.SetError(this.txtDescuento1, "El valor es incorrecto.");
                        //this.CostoIvaMatch = false;
                    }
                }
                else
                {
                    this.miError.SetError(this.txtDescuento1, "El campo es requerido.");
                    //this.CostoIvaMatch = false;
                }
            }
        }

        private void txtDescuento2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                if (!String.IsNullOrEmpty(this.txtDescuento2.Text))
                {
                    if (ValidarDecimal(this.txtDescuento2.Text))
                    {
                        this.miError.SetError(this.txtDescuento2, null);
                        //this.CostoIvaMatch = true;

                        /*this.txtCostoBase.Text = Math.Round(
                            (Convert.ToDouble(this.txtCostoMasIva.Text.Replace('.', ',')) / (1 + (this.Producto.ValorIva / 100))), 2).
                             ToString().Replace(',', '.');*/
                        this.btnAgregar.Focus();
                        //this.btnAgregar_Click(this.btnAgregar, new EventArgs());
                    }
                    else
                    {
                        this.miError.SetError(this.txtDescuento2, "El valor es incorrecto.");
                        //this.CostoIvaMatch = false;
                    }
                }
                else
                {
                    this.miError.SetError(this.txtDescuento2, "El campo es requerido.");
                    //this.CostoIvaMatch = false;
                }
            }
        }

        private void txtDescuento1_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(this.txtDescuento1.Text))
            {
                if (ValidarDecimal(this.txtDescuento1.Text))
                {
                    this.miError.SetError(this.txtDescuento1, null);
                    this.D1Match = true;
                }
                else
                {
                    this.miError.SetError(this.txtDescuento1, "El valor es incorrecto.");
                    this.D1Match = false;
                }
            }
            else
            {
                this.miError.SetError(this.txtDescuento1, "El campo es requerido.");
                this.D1Match = false;
            }
        }

        private void txtDescuento2_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(this.txtDescuento2.Text))
            {
                if (ValidarDecimal(this.txtDescuento2.Text))
                {
                    this.miError.SetError(this.txtDescuento2, null);
                    this.D2Match = true;
                }
                else
                {
                    this.miError.SetError(this.txtDescuento2, "El valor es incorrecto.");
                    this.D2Match = false;
                }
            }
            else
            {
                this.miError.SetError(this.txtDescuento2, "El campo es requerido.");
                this.D2Match = false;
            }
        }



        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                this.txtCantidad_Validating(this.txtCantidad, new CancelEventArgs(false));
                this.txtCostoBase_Validating(this.txtCostoBase, new CancelEventArgs(false));
                this.txtCostoMasIva_Validating(this.txtCostoMasIva, new CancelEventArgs(false));
                this.txtDescuento1_Validating(this.txtDescuento1, new CancelEventArgs(false));
                this.txtDescuento2_Validating(this.txtDescuento2, new CancelEventArgs(false));

                if (this.Producto != null && this.CantidadMatch && this.CostoMatch && 
                    this.CostoIvaMatch && this.D1Match && this.D2Match)
                {
                    var row = this.Tproductos.NewRow();
                    row["Id"] = this.Contador;
                    row["Codigo"] = this.Producto.CodigoInternoProducto;
                    row["Producto"] = this.Producto.NombreProducto;
                    if (this.SingleSize)
                    {
                        row["IdMedida"] = this.miMedida.IdValorUnidadMedida;
                    }
                    else
                    {
                        row["IdMedida"] = this.miTallaYcolor.IdTalla;
                    }
                    if (this.SingleColor)
                    {
                         row["IdColor"] = 0;
                    }
                    else
                    {
                        row["IdColor"] = this.miTallaYcolor.IdColor;
                    }
                    row["Lote"] = this.Producto.CodigoInternoProducto + "-" + CambiarSeparadorFecha(DateTime.Now.ToShortDateString());
                    row["Cantidad"] = Convert.ToDouble(this.txtCantidad.Text.Replace('.', ','));
                    row["Iva"] = this.Producto.ValorIva;
                    row["Valor"] = Convert.ToDouble(this.txtCostoBase.Text.Replace('.', ','));
                    row["ValorUnitario"] = Convert.ToDouble(this.txtCostoMasIva.Text.Replace('.', ','));
                    row["Total"] = Math.Round(
                        (Convert.ToDouble(this.txtCostoMasIva.Text.Replace('.', ',')) * Convert.ToDouble(this.txtCantidad.Text.Replace('.', ','))), 2);

                    /*var costo = this.miBussinesProducto.PrecioDeCosto(this.Producto.CodigoInternoProducto);
                    if (this.Proveedor.IdRegimen.Equals(1))
                    {
                        row["Valor"] = costo;
                        row["Iva"] = this.Producto.ValorIva;
                    }
                    else
                    {
                        row["Valor"] = costo + Convert.ToInt32(costo * this.Producto.ValorIva / 100);
                        row["Iva"] = 0;
                    }*/
                    /*row["Valor"] = this.miBussinesProducto.PrecioDeCosto(this.Producto.CodigoInternoProducto);
                    row["Iva"] = this.Producto.ValorIva;*/

                    row["Descuento"] = Convert.ToDouble(this.txtDescuento1.Text.Replace('.', ','));
                    row["Descuento2"] = Convert.ToDouble(this.txtDescuento2.Text.Replace('.', ','));

                    this.Tproductos.Rows.Add(row);
                    this.Contador++;
                    this.txtCodigoArticulo.Focus();
                    this.Producto = null;
                    this.miTallaYcolor = null;
                    this.txtCodigoArticulo.Text = "";
                    this.lblDatosProducto.Text = "";
                    this.txtCantidad.Text = "";
                    this.txtCostoBase.Text = "";
                    this.txtCostoMasIva.Text = "";
                    this.txtDescuento1.Text = "";
                    this.txtDescuento2.Text = "";
                    this.txtCostoBaseInfo.Text = "";
                    this.txtIvaInfo.Text = "";
                    this.txtCostoMasIvaInfo.Text = "";
                    this.txtCantInventario.Text = "";
                    this.txtCantPreingreso.Text = "";
                    this.txtCantUltCompra.Text = "";
                    
                    RecargarGridview();
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void tsBtnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvListaArticulos.RowCount != 0)
                {
                    var row = (from registro in this.Tproductos.AsEnumerable()
                               where registro.Field<int>("Id").Equals(Convert.ToInt32(this.dgvListaArticulos.CurrentRow.Cells["Id"].Value))
                               select registro).First();
                    //int index = this.Tproductos.Rows.IndexOf(row);

                    this.txtCodigoArticulo.Text = row["Codigo"].ToString();
                    this.txtCodigoArticulo_KeyPress(this.txtCodigoArticulo, new KeyPressEventArgs((char)Keys.Enter));
                    this.txtCantidad.Text = Convert.ToDouble(row["Cantidad"]).ToString().Replace(',', '.');
                    this.txtCostoBase.Text = Convert.ToDouble(row["Valor"]).ToString().Replace(',', '.');
                    this.txtCostoMasIva.Text = Convert.ToDouble(row["ValorUnitario"]).ToString().Replace(',', '.');
                    this.Tproductos.Rows.Remove(row);
                    RecargarGridview();

                    /*Tproductos.Columns.Add(new DataColumn("Cantidad", typeof(double))); ValorUnitario
            Tproductos.Columns.Add(new DataColumn("Valor", typeof(double)));
            Tproductos.Columns.Add(new DataColumn("Iva", typeof(double)));*/
                }
                else
                {
                    OptionPane.MessageInformation("No hay registros para editar.");
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void tsEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvListaArticulos.RowCount != 0)
                {
                    DialogResult rta = MessageBox.Show("¿Esta seguro(a) de eliminar el registro?", "Registro de compra",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (rta.Equals(DialogResult.Yes))
                    {
                        var row = (from registro in this.Tproductos.AsEnumerable()
                                   where registro.Field<int>("Id").Equals(Convert.ToInt32(this.dgvListaArticulos.CurrentRow.Cells["Id"].Value))
                                   select registro).First();
                        this.Tproductos.Rows.Remove(row);
                        RecargarGridview();
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

        void CompletaEventos_CompAxTInvFactProvee(CompletaTransInvFactProvee args)
        {
            try
            {
                var producto = (DTO.Clases.Producto)args.MiObjeto;
                txtCodigoArticulo.Text = producto.CodigoInternoProducto;
                txtCodigoArticulo_KeyPress(this.txtCodigoArticulo, new KeyPressEventArgs((char)Keys.Enter));
            }
            catch { }
        }

        private void ValidarProveedor()
        {
            if (String.IsNullOrEmpty(this.txtNombreProveedor.Text))
            {
                this.miError.SetError(txtNombreProveedor, "El proveedor es requerido.");
                this.ProveedorMatch = false;
            }
            else
            {
                this.miError.SetError(txtNombreProveedor, null);
                this.ProveedorMatch = true;
            }
        }

        private bool ValidarDecimal(string numero)
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

        private bool CodigoOrString(string codigo)
        {
            try
            {
                Convert.ToInt64(codigo);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private string CambiarSeparadorFecha(string fecha)
        {
            var miFecha = fecha.Split('/');
            string fechaResult = miFecha[0] + miFecha[1] + miFecha[2];
            return fechaResult;
        }

        private void RecargarGridview()
        {
            IEnumerable<DataRow> query = from datos in this.Tproductos.AsEnumerable()
                                         orderby datos.Field<int>("Id") descending
                                         select datos;
            DataTable copy = new DataTable();
            if (query.ToArray().Length != 0)
            {
                copy = query.CopyToDataTable<DataRow>();
            }
            this.dgvListaArticulos.DataSource = null;
            this.dgvListaArticulos.DataSource = copy;
            this.txtTotal.Text = UseObject.InsertSeparatorMil(Convert.ToInt32(
                        this.Tproductos.AsEnumerable().Sum(s => s.Field<double>("Total"))).ToString());
        }

        private List<ProductoFacturaProveedor> Productos()
        {
            var productos = new List<ProductoFacturaProveedor>();
            foreach (DataRow row in this.Tproductos.Rows)
            {
                var producto = new ProductoFacturaProveedor();
                producto.Producto.CodigoInternoProducto = row["Codigo"].ToString();
                producto.Cantidad = Convert.ToDouble(row["Cantidad"]);
                //producto.Producto.ValorCosto = Convert.ToDouble(row["ValorUnitario"]);
                producto.Producto.ValorCosto = Convert.ToDouble(row["Valor"]);
               // producto.Producto.ValorVentaProducto = Convert.ToDouble(row["ValorUnitario"]);
                producto.Producto.ValorIva = Convert.ToDouble(row["Iva"]);
                producto.Producto.Descuento = Convert.ToDouble(row["Descuento"]);
                producto.Producto.DescuentoMayor = Convert.ToDouble(row["Descuento2"]);
                producto.Lote.CodigoProducto = row["Codigo"].ToString();
                producto.Lote.Numero = row["Lote"].ToString();
                producto.Lote.Fecha = DateTime.Now;
               // producto.Inventario.CodigoProducto = row["Codigo"].ToString();
                producto.Inventario.IdMedida = Convert.ToInt32(row["IdMedida"]);
                producto.Inventario.IdColor = Convert.ToInt32(row["IdColor"]);
                /*producto.Inventario.Cantidad = Convert.ToDouble(row["Cantidad"]);*/
                productos.Add(producto);
            }
            return productos;
            /*("Id", typeof(int)));
            Tproductos.Columns.Add(new DataColumn("Codigo", typeof(string)));
            Tproductos.Columns.Add(new DataColumn("Producto", typeof(string)));
            Tproductos.Columns.Add(new DataColumn("IdMedida", typeof(int)));
            Tproductos.Columns.Add(new DataColumn("IdColor", typeof(int)));
            Tproductos.Columns.Add(new DataColumn("Lote", typeof(string)));
            Tproductos.Columns.Add(new DataColumn("Cantidad", typeof(double)));
            Tproductos.Columns.Add(new DataColumn("Valor", typeof(int)));
            Tproductos.Columns.Add(new DataColumn("Iva", typeof(double)));
            Tproductos.Columns.Add(new DataColumn("Descuento", typeof(int)));*/
        }

    }
}