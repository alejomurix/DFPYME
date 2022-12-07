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

namespace Aplicacion.Ventas.EditarPrecio
{
    public partial class FrmConsultaPrecio : Form
    {
        private bool Transfer;

        private BussinesProducto miBussinesProducto;

        private BussinesInventario miBussinesInventario;

        public FrmConsultaPrecio()
        {
            InitializeComponent();
            this.Transfer = false;
            this.miBussinesProducto = new BussinesProducto();
            this.miBussinesInventario = new BussinesInventario();
        }

        private void FrmConsultaPrecio_Load(object sender, EventArgs e)
        {
            CompletaEventos.Completam += new CompletaEventos.CompletaAccionm(CompletaEventos_Completam);
            this.lblCodProducto.Text = "";
            this.lblDatosProducto.Text = "";
            this.lblPrecioProducto.Text = "";
            this.lblPrecio2.Text = "";
            this.lblPrecio3.Text = "";
            this.lblPrecio4.Text = "";
        }

        private void FrmConsultaPrecio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.F3))
            {
                var formInventario = new Inventario.Consulta.FrmConsultaInventario();
                formInventario.IsVenta = false;
                formInventario.ExtendVenta = true;
               // formInventario.txtCodigoNombre.Text = txtCodigoArticulo.Text;
                this.Transfer = true;
                formInventario.ShowDialog();
            }
            else
            {
                if (e.KeyData.Equals(Keys.Escape))
                {
                    this.Close();
                }
            }
        }

        private void tsConsultarProducto_Click(object sender, EventArgs e)
        {
            var formInventario = new Inventario.Consulta.FrmConsultaInventario();
            formInventario.IsVenta = false;
            formInventario.ExtendVenta = true;
            //formInventario.txtCodigoNombre.Text = txtCodigoArticulo.Text;
            this.Transfer = true;
            formInventario.ShowDialog();
        }

        private void tsBtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCodigoArticulo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                try
                {
                    if (!String.IsNullOrEmpty(this.txtCodigoArticulo.Text))
                    {
                        if (CodigoOrString())
                        {
                            if (ExisteProducto(this.txtCodigoArticulo.Text))
                            {
                                var ArrayProducto = miBussinesProducto.ProductoBasico(txtCodigoArticulo.Text);
                                var MiProducto = (Producto)ArrayProducto[0];
                                var tProducto = this.miBussinesInventario.ConsultaInventario(MiProducto.CodigoInternoProducto).AsEnumerable().First();

                                this.lblCodProducto.Text = "Codigo: " + MiProducto.CodigoInternoProducto;
                                this.lblDatosProducto.Text = MiProducto.NombreProducto;
                                this.lblPrecioProducto.Text = "(1) $ " + UseObject.InsertSeparatorMil(MiProducto.ValorVentaProducto.ToString());
                                this.lblPrecio2.Text = "(2) $ " + UseObject.InsertSeparatorMil(Convert.ToInt32(tProducto["mayorista"]).ToString());
                                this.lblPrecio3.Text = "(3) $ " + UseObject.InsertSeparatorMil(Convert.ToInt32(tProducto["distribuidor"]).ToString());
                                this.lblPrecio4.Text = "(4) $ " + UseObject.InsertSeparatorMil(Convert.ToInt32(tProducto["precio_4"]).ToString());
                                this.txtCodigoArticulo.Text = "";
                            }
                        }
                        else
                        {
                            /// inventario
                            var formInventario = new Inventario.Consulta.FrmConsultaInventario();
                            formInventario.IsVenta = false;
                            formInventario.ExtendVenta = true;
                            formInventario.txtCodigoNombre.Text = txtCodigoArticulo.Text;
                            this.Transfer = true;
                            formInventario.ShowDialog();
                        }
                    }
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
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

        void CompletaEventos_Completam(CompletaArgumentosDeEventom args)
        {
            try
            {
                if (this.Transfer)
                {
                    Producto producto = (Producto)args.MiMarca;
                    this.txtCodigoArticulo.Text = producto.CodigoInternoProducto;
                    this.txtCodigoArticulo_KeyPress(this.txtCodigoArticulo, new KeyPressEventArgs((char)Keys.Enter));
                    this.Transfer = false;
                }
            }
            catch { }
        }
    }
}