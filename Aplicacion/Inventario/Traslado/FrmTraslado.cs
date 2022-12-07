using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CustomControl;
using BussinesLayer.Clases;
using DTO.Clases;
using Utilities;
using Microsoft.Reporting.WinForms;

namespace Aplicacion.Inventario.Traslado
{
    public partial class FrmTraslado : Form
    {
        private bool CantidadNegativo { set; get; }

        private bool RequiereCantidad { set; get; }

        private ErrorProvider miError;

        private ToolTip miToolTip;

        private DTO.Clases.Producto MiProducto;

        private int Contador = 0;

        private int IdTipo = 1;

        private int IdTipoDestino = 2;

        private Caja CajaTest;


        private BussinesCaja miBussinesCaja;

        private BussinesProducto miBussinesProducto;

        private BussinesInventario miBussinesInventario;

        private BussinesTrasladoInventario miBussinesTraslado;

        private BussinesEmpresa miBussinesEmpresa;

        private List<ProductoFacturaProveedor> Detalle;

        private BindingSource miBindingSource;

        public FrmTraslado()
        {
            InitializeComponent();

            try
            {
                miToolTip = new ToolTip();
                miToolTip.SetToolTip(btnConexionNo, "No se ha establecido la conexión, revise su configuración.");
                miToolTip.SetToolTip(btnConexionSi, "La conexión se estableció exitosamente.");

                CantidadNegativo = Convert.ToBoolean(AppConfiguracion.ValorSeccion("trasaldo_inven_cant_negativa"));
                RequiereCantidad = Convert.ToBoolean(AppConfiguracion.ValorSeccion("reqCantidad"));
                miError = new ErrorProvider();

                miBussinesCaja = new BussinesCaja();
                miBussinesProducto = new BussinesProducto();
                miBussinesInventario = new BussinesInventario();
                miBussinesEmpresa = new BussinesEmpresa();
                //miBussinesTraslado = new BussinesTrasladoInventario();

                txtCajaOrigen.Text = "CAJA  " + miBussinesCaja.CajaId(Convert.ToInt32(AppConfiguracion.ValorSeccion("id_caja"))).Numero;
                cbCaja.DataSource = miBussinesCaja.Cajas();

                Detalle = new List<ProductoFacturaProveedor>();
                miBindingSource = new BindingSource();
                dgvListaArticulos.AutoGenerateColumns = false;
                dgvListaArticulos.DataSource = miBindingSource;
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void FrmTraslado_Load(object sender, EventArgs e)
        {

        }

        private void FrmTraslado_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult rta = MessageBox.Show("¿Está seguro(a) de querer salir?", "Traslado inventario",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rta.Equals(DialogResult.Yes))
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void tsBtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(AppConfiguracion.ValorSeccion("id_caja")) != Convert.ToInt32(cbCaja.SelectedValue))
                {
                    if (ValidarConexion())
                    {
                        if (dgvListaArticulos.RowCount != 0)
                        {
                            DialogResult rta = MessageBox.Show("¿Está seguro(a) de guardar el traslado de inventario?", "Traslado inventario",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (rta.Equals(DialogResult.Yes))
                            {
                                var cajaOrigen = miBussinesCaja.CajaId(Convert.ToInt32(AppConfiguracion.ValorSeccion("id_caja")));
                                var cajaDestino = miBussinesCaja.CajaId(Convert.ToInt32(cbCaja.SelectedValue));

                                TrasladoInventario traslado = new TrasladoInventario();
                                traslado.Tipo = IdTipo;
                                //traslado.IdTipoDestino = IdTipoDestino;
                                //traslado.Caja.Id = Convert.ToInt32(cbCaja.SelectedValue);
                                traslado.Usuario.Id = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_user"));
                                traslado.FechaFactura = dtpFecha.Value;
                                traslado.CajaHostOrigen = miBussinesCaja.CajaId(Convert.ToInt32(AppConfiguracion.ValorSeccion("id_caja"))).Numero.ToString();
                                traslado.CajaHostDestino = miBussinesCaja.CajaId(Convert.ToInt32(cbCaja.SelectedValue)).Numero.ToString();
                                traslado.Productos = Detalle;

                                miBussinesTraslado = new BussinesTrasladoInventario(cajaOrigen.IpServer);
                                miBussinesTraslado.IngresarTraslado(traslado, true);

                                traslado.Tipo = IdTipoDestino;
                                miBussinesTraslado = new BussinesTrasladoInventario(cajaDestino.IpServer);
                                miBussinesTraslado.IngresarTraslado(traslado, false);

                                OptionPane.MessageInformation("El traslado se realizó con éxito.");
                                PrintTraslado(traslado);
                                LimpiarCamposNuevo();
                            }
                        }
                        else
                        {
                            OptionPane.MessageInformation("Debe cargar al menos un producto.");
                        }
                    }
                    else
                    {
                        OptionPane.MessageInformation("No se ha establecido conexión con la caja destino.");
                    }
                }
                else
                {
                    OptionPane.MessageInformation("La caja de destino debe ser diferente a la de origen.");
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void tsCargarInventario_Click(object sender, EventArgs e)
        {
            try
            {  ///  OJO VALIDACION PARA QUE NO CARGUE LOS MISMOS PRODUCTOS.  
                if (Detalle.Count.Equals(0))
                {
                    foreach (DataRow iRow in miBussinesInventario.ConsultaInventario().AsEnumerable().OrderByDescending(o => o.Field<string>("nombre")))
                    {
                        if (CantidadNegativo)
                        {
                            if (Convert.ToDouble(iRow["cantidad"]) != 0)
                            {
                                CargarProductosTraslado(iRow);
                            }
                        }
                        else
                        {
                            if (Convert.ToDouble(iRow["cantidad"]) > 0)
                            {
                                CargarProductosTraslado(iRow);
                            }
                        }
                    }
                    txtTotal.Text = UseObject.InsertSeparatorMil(Detalle.Sum(s => s.Total).ToString());
                    RecargarGridview();
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

        private void cbCaja_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                ValidarConexion();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void btnConexionNo_Click(object sender, EventArgs e)
        {
            try
            {
                ValidarConexion();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void btnConexionSi_Click(object sender, EventArgs e)
        {
            try
            {
                ValidarConexion();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        

        private void txtCodigoArticulo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (!String.IsNullOrEmpty(this.txtCodigoArticulo.Text))
                {
                    if (this.CodigoOrString())
                    {
                        if (ExisteProducto(txtCodigoArticulo.Text))
                        {
                            if (CargarProducto())
                            {
                                if (RequiereCantidad)
                                {
                                    txtCantidad.Focus();
                                }
                                else
                                {
                                    EstructurarConsulta();
                                }
                            }
                        }
                    }
                }
            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (String.IsNullOrEmpty(txtCantidad.Text))
                {
                    txtCantidad.Text = "1";
                }
                if (ValidarCantidad(txtCantidad.Text))
                {
                    if (!Convert.ToDouble(txtCantidad.Text).Equals(0))
                    {
                        miError.SetError(txtCantidad, null);
                        if (MiProducto != null)
                        {
                            EstructurarConsulta();
                        }
                        else
                        {
                            txtCodigoArticulo.Focus();
                        }
                    }
                    else
                    {
                        miError.SetError(txtCantidad, "La cantidad debe ser diferente de cero.");
                        txtCantidad.Focus();
                    }
                }
                else
                {
                    miError.SetError(txtCantidad, "La cantidad que ingreso tiene formato incorrecto.");
                    txtCantidad.Focus();
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult rta = MessageBox.Show("¿Está seguro(a) de eliminar el registro?", "Traslado inventario", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rta.Equals(DialogResult.Yes))
                {
                    var id = Convert.ToInt32(dgvListaArticulos.CurrentRow.Cells["Id"].Value);
                    Detalle.Remove(Detalle.Where(p => p.Id.Equals(id)).First());
                    /*if (Detalle.Count.Equals(0))
                    {
                        Detalle.Clear();
                    }*/
                    //var c = Detalle.Count;
                    txtTotal.Text = UseObject.InsertSeparatorMil(Detalle.Sum(s => s.Total).ToString());
                    RecargarGridview();
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private bool ValidarConexion()
        {
            CajaTest = miBussinesCaja.CajaId(Convert.ToInt32(cbCaja.SelectedValue));
            miBussinesTraslado = new BussinesTrasladoInventario(CajaTest.IpServer);
            bool conexion = miBussinesTraslado.TestearConexion(CajaTest.IpServer);
            if (conexion)
            {
                btnConexionSi.Visible = true;
                btnConexionNo.Visible = false;

                // this.btnConexionNo.Location = new System.Drawing.Point(522, 48); 
            }
            else
            {
                btnConexionSi.Visible = false;
                btnConexionNo.Visible = true;
            }
            return conexion;
        }

        private bool CodigoOrString()
        {
            var num = true;
            try
            {
                Convert.ToInt64(txtCodigoArticulo.Text);
            }
            catch (FormatException)
            {
                num = false;
            }
            catch (OverflowException)
            {
                num = true;
            }
            return num;
        }

        private bool ExisteProducto(string codigo)
        {
            try
            {
                var barras = miBussinesProducto.ExisteCodigoBarras(codigo);
                var code = miBussinesProducto.ExisteCodigo(codigo);
                if (barras || code)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
                return false;
            }
        }

        private bool CargarProducto()
        {
            var resultado = false;
            try
            {
                var ArrayProducto = miBussinesProducto.ProductoBasico(txtCodigoArticulo.Text);
                MiProducto = (DTO.Clases.Producto)ArrayProducto[0];
                MiProducto.IdMedida = ((ValorUnidadMedida)ArrayProducto[1]).IdValorUnidadMedida;
                lblDatosProducto.Text = MiProducto.CodigoInternoProducto + " - " + MiProducto.NombreProducto;
                txtInventario.Text = miBussinesInventario.CantidadInventario(new DTO.Clases.Inventario
                                    {
                                        CodigoProducto = MiProducto.CodigoInternoProducto,
                                        IdMedida = MiProducto.IdMedida
                                    }).ToString();
                resultado = true;
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            return resultado;
        }

        private void EstructurarConsulta()
        {
            if (Detalle.Count(c => c.Codigo.Equals(MiProducto.CodigoInternoProducto)) > 0)
            {
                foreach (var product in Detalle.Where(d => d.Codigo.Equals(MiProducto.CodigoInternoProducto)))
                {
                    product.Cantidad += Convert.ToDouble(this.txtCantidad.Text.Replace('.', ','));
                    product.Total = Convert.ToInt32(product.Costo * product.Cantidad);
                }
            }
            else
            {
                Contador++;
                ProductoFacturaProveedor p = new ProductoFacturaProveedor();
                p.Id = Contador;
                p.Codigo = MiProducto.CodigoInternoProducto;
                p.Nombre = MiProducto.NombreProducto;
                p.Producto.IdMedida = MiProducto.IdMedida;
                p.Producto.IdColor = MiProducto.IdColor;
                p.Cantidad = Convert.ToDouble(this.txtCantidad.Text.Replace('.', ','));
                p.Costo = Convert.ToInt32(MiProducto.ValorCosto);
                p.Valor = MiProducto.ValorVentaProducto;
                p.Total = Convert.ToInt32(p.Costo * p.Cantidad);
                Detalle.Add(p);
            }
            txtTotal.Text = UseObject.InsertSeparatorMil(Detalle.Sum(s => s.Total).ToString());
            RecargarGridview();
            LimpiarCampos();
        }

        private void CargarProductosTraslado(DataRow iRow)
        {
            Contador++;
            ProductoFacturaProveedor p = new ProductoFacturaProveedor();
            p.Id = Contador;
            p.Codigo = iRow["codigo"].ToString();
            p.Nombre = iRow["nombre"].ToString();
            p.Producto.IdMedida = Convert.ToInt32(iRow["idvalormedida"]);
            p.Producto.IdColor = Convert.ToInt32(iRow["idcolor"]);
            p.Cantidad = Convert.ToDouble(iRow["cantidad"]);
            p.Costo = Convert.ToInt32(iRow["valor_mas_iva"]);
            p.Valor = Convert.ToDouble(iRow["venta"]);
            p.Total = Convert.ToInt32(p.Costo * p.Cantidad);
            Detalle.Add(p);
        }


        private void LimpiarCampos()
        {
            this.txtCodigoArticulo.Focus();
            this.txtCodigoArticulo.Text = "";
            txtCantidad.Text = "1";
            MiProducto = null;
        }

        private void RecargarGridview()
        {
            miBindingSource.DataSource = Detalle.OrderByDescending(o => o.Id);
            if (Detalle.Count.Equals(0))
            {
                dgvListaArticulos.Rows.Clear();
            }
        }

        private bool ValidarCantidad(string cant)
        {
            var pass = false;
            try
            {
                Convert.ToDouble(cant);
                pass = true;
            }
            catch (FormatException)
            {
                pass = false;
            }
            try
            {
                Convert.ToInt32(Convert.ToDouble(cant));
                pass = true;
            }
            catch (OverflowException)
            {
                pass = false;
            }
            catch (FormatException)
            {
                pass = false;
            }
            return pass;
        }

        private void PrintTraslado(TrasladoInventario traslado)
        {
            try
            {
                var dsEmpresa = miBussinesEmpresa.PrintEmpresa();

                var frmPrint = new Ventas.Factura.FrmPrintFactura();
                frmPrint.Text = "Imprimir";
                frmPrint.RptvFactura.LocalReport.DataSources.Clear();
                frmPrint.RptvFactura.LocalReport.Dispose();
                frmPrint.RptvFactura.Reset();

                frmPrint.RptvFactura.LocalReport.DataSources.Add(
                   new ReportDataSource("DsEmpresa", dsEmpresa.Tables["Empresa"]));
                frmPrint.RptvFactura.LocalReport.DataSources.Add(new ReportDataSource("ProductoDetalle", traslado.Productos));

                frmPrint.RptvFactura.LocalReport.ReportPath = AppConfiguracion.ValorSeccion("report") + @"\reports\InformeTrasladoInventario.rdlc";
                //frmPrint.RptvFactura.LocalReport.ReportPath = @"C:\reports\InformeTrasladoInventario.rdlc";

                var pFecha = new ReportParameter();
                pFecha.Name = "Fecha";
                pFecha.Values.Add(dtpFecha.Value.ToShortDateString());
                frmPrint.RptvFactura.LocalReport.SetParameters(pFecha);

                var pCajaOrigen = new ReportParameter();
                pCajaOrigen.Name = "CajaOrigen";
                pCajaOrigen.Values.Add(traslado.CajaHostOrigen);
                frmPrint.RptvFactura.LocalReport.SetParameters(pCajaOrigen);

                var pCajaDestino = new ReportParameter();
                pCajaDestino.Name = "CajaDestino";
                pCajaDestino.Values.Add(traslado.CajaHostDestino);
                frmPrint.RptvFactura.LocalReport.SetParameters(pCajaDestino);

                frmPrint.RptvFactura.RefreshReport();

                frmPrint.ShowDialog();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void LimpiarCamposNuevo()
        {
            dtpFecha.Value = DateTime.Now;
            cbCaja.SelectedIndex = 0;
            MiProducto = null;
            while (dgvListaArticulos.RowCount != 0)
            {
                dgvListaArticulos.Rows.RemoveAt(0);
            }
            Detalle.Clear();
            Contador = 0;
            lblDatosProducto.Text = "";
            txtCantidad.Text = "1";
            txtTotal.Text = "0";
            txtCodigoArticulo.Focus();
        }

        

    }
}