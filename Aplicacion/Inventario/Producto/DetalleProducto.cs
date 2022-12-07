using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BussinesLayer.Clases;
using System.Collections;
using DTO.Clases;
using CustomControl;
using Utilities;

namespace Aplicacion.Inventario.Producto
{
    /// <summary>
    /// Estructura una clase para el formulario de Detalle de producto.
    /// </summary>
    public partial class frmDetalleProducto : Form
    {
        /// <summary>
        /// Obtiene o establece el Codigo del Producto a consultar.
        /// </summary>
        public string CodigoProducto { set; get; }

        /// <summary>
        /// Objeto de tranzacion de datos de Producto.
        /// </summary>
        private BussinesProducto miBussinesProducto;

        /// <summary>
        /// Inicializa una nueva instancia de frmDetalleProdcuto.
        /// </summary>
        public frmDetalleProducto()
        {
            InitializeComponent();
            miBussinesProducto = new BussinesProducto();
        }

        private void frmDetalleProducto_Load(object sender, EventArgs e)
        {
            dgvColores.AutoGenerateColumns = false;
            CargaProducto(CodigoProducto);
        }

        private void frmDetalleProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.Escape))
            {
                this.Close();
            }
        }

        private void cbMedida_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var id = (int)cbMedida.SelectedValue;
            try
            {
                dgvColores.DataSource = miBussinesProducto.ProductoConMedidaYcolor(CodigoProducto, id);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void tsbSalirDetalleProducto_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Carga los datos del Producto en el formulario.
        /// </summary>
        /// <param name="codigo">Codigo del producto a cargar.</param>
        private void CargaProducto(string codigo)
        {
            try
            {
                var producto = miBussinesProducto.ProductoCompleto(codigo);
                var medidas = miBussinesProducto.ProductoConMedida(codigo);
                txtCodigo.Text = producto.CodigoInternoProducto;
                txtBarras.Text = producto.CodigoBarrasProducto;
                txtReferencia.Text = producto.ReferenciaProducto;
                txtNombre.Text = producto.NombreProducto;
                txtDescripcion.Text = producto.DescripcionProducto;
                txtCategoria.Text = producto.NombreCategoria;
                txtMarca.Text = producto.NombreMarca;

                txtICO.Text = producto.ValorIco.ToString();
                txtAplicaICO.Text = producto.AplicaIcoToString;
                txtImprime.Text = producto.ImprimeToString;
                txtAplicaDescto.Text = producto.AplicaDesctoToString;

                txtPrecio.Text = UseObject.InsertSeparatorMil(producto.ValorVentaProducto.ToString()); //Convert.ToString(producto.ValorVentaProducto);
                txtUtilidad.Text = Convert.ToString(producto.UtilidadPorcentualProducto);
                cbDescuento.DataSource = producto.Descuentos;
                if (producto.AplicaPrecioPorcentaje)
                {
                    txtAplicaPrecio.Text = "Porcentaje";
                }
                else
                {
                    txtAplicaPrecio.Text = "Valor";
                }
                txtIva.Text = Convert.ToString(producto.ValorIva);

                txtDestoMayor.Text = producto.DescuentoMayor.ToString() + "%";
                txtDestoDistri.Text = producto.DescuentoDistribuidor.ToString() + "%";
                int valor = Convert.ToInt32(producto.ValorVentaProducto) - 
                            Convert.ToInt32(producto.ValorVentaProducto * producto.DescuentoMayor / 100);
                txtValorDestoMayor.Text = UseObject.InsertSeparatorMil(
                    UseObject.Aproximar(valor, Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio"))).ToString());

                valor = Convert.ToInt32(producto.ValorVentaProducto) -
                            Convert.ToInt32(producto.ValorVentaProducto * producto.DescuentoDistribuidor / 100);
                txtValorDestoDistri.Text = UseObject.InsertSeparatorMil(
                    UseObject.Aproximar(valor, Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio"))).ToString());

                cbRecargo.DataSource = producto.Recargos;
                txtCantidadMinima.Text = Convert.ToString(producto.CantidadMinimaProducto);
                txtPresentacion.Text = Convert.ToString(producto.UnidadVentaProducto);
                txtCantidadMaxima.Text = Convert.ToString(producto.CantidadMaximaProducto);
                if (producto.EstadoProducto)
                {
                    txtEstado.Text = "Activo";
                }
                else
                {
                    txtEstado.Text = "Inactivo";
                }
                if (producto.CantidadDecimal)
                {
                    chkCantDecimal.Checked = true;
                }
                TallaYColor(producto.AplicaTalla, producto.AplicaColor, medidas);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        /// <summary>
        /// Organiza el formulario segun las propiedades de talla y color de Producto.
        /// </summary>
        /// <param name="aplicaTalla"></param>
        /// <param name="aplicaColor"></param>
        /// <param name="table"></param>
        private void TallaYColor(bool aplicaTalla, bool aplicaColor, DataTable table)
        {
            cbMedida.Visible = aplicaTalla;
            txtMedida.Visible = !aplicaTalla;
            dgvColores.Visible = aplicaColor;
            /*if(!aplicaTalla)
                txtMedida.Location = new Point(477, 30);*/
            if (!aplicaColor)
            {
                gbPresentacionMedida.Size = new Size(777, 130);
                this.Size = new Size(823, 518);
            }
            if (aplicaTalla)
            {
                cbMedida.DataSource = table;
            }
            else
            {
                foreach (DataRow row in table.Rows)
                {
                    txtMedida.Text = Convert.ToString(row[2]);
                }
            }
            if (!aplicaTalla && aplicaColor)
            {
                var medida = 0;
                foreach (DataRow row in table.Rows)
                {
                   medida = (int)row[0];
                }
                CargarGridColor(medida);
            }
            if (aplicaTalla && aplicaColor)
            {
                cbMedida_SelectionChangeCommitted(null, null);
            }
        }

        /// <summary>
        /// Cargar el DataGrid de color.
        /// </summary>
        /// <param name="idMedida">Id de la medida del Producto</param>
        private void CargarGridColor(int idMedida)
        {
            try
            {
                dgvColores.DataSource = 
                    miBussinesProducto.ProductoConMedidaYcolor(CodigoProducto, idMedida);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }
    }
}