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
using Utilities;

namespace Aplicacion.Compras.IngresarCompra
{
    public partial class frmMedidaColor : Form
    {
        public bool Venta_ = false;

        /// <summary>
        /// Obtiene o establece el Valor del Codigo del Producto.
        /// </summary>
        public string CodigoProducto { set; get; }

        /// <summary>
        /// Obtiene o establece el valor del Id de la medida del producto.
        /// </summary>
        public int IdMedida_ { set; get; }

        /// <summary>
        /// Obtiene o establece la condición que indica si se trata de una edición de otro Form.
        /// </summary>
        public bool Edit = false;

        /// <summary>
        /// Obtiene o establece el valor que indica si se habilita o no las tallas en el formulario.
        /// </summary>
        public bool AplicaTalla { set; get; }

        /// <summary>
        /// Obtiene o establece el valor que indica si se habilita o no el color en el formulario.
        /// </summary>
        public bool AplicaColor { set; get; }

        /// <summary>
        /// Objeto de logica de negocio de ValorUnidadMedida.
        /// </summary>
        private BussinesValorUnidadMedida miBussinesMedida;

        /// <summary>
        /// Objeto de logica de negocio de Color.
        /// </summary>
        private BussinesColor miBussinesColor;

        /// <summary>
        /// Objeto para el acceso al ensamblado de la aplicación.
        /// </summary>
        private System.Reflection.Assembly assembly;

        /// <summary>
        /// Representa el Stream de la Imagen de Medida.
        /// </summary>
        private System.IO.Stream ImgMedidaStream;

        /// <summary>
        /// Representa el Stream de la Imagen de Color.
        /// </summary>
        private System.IO.Stream ImgColorStream;

        /// <summary>
        /// Representa el Stream de la Imagen de MedidaColor.
        /// </summary>
        private System.IO.Stream ImgMedidaColorStream;

        /// <summary>
        /// Representa la ruta del ensamblado de la imagen Medida.
        /// </summary>
        private const string ImagenMedida = "Aplicacion.Recursos.Iconos.medida.ico";

        /// <summary>
        /// Representa la ruta del ensamblado de la imagen de color.
        /// </summary>
        private const string ImagenColor = "Aplicacion.Recursos.Iconos.color.ico";

        /// <summary>
        /// Representa la ruta del ensamblado de la imagen de medida con color.
        /// </summary>
        private const string ImagenMedidaColor = "Aplicacion.Recursos.Iconos.medidaColor.ico";

        /// <summary>
        /// Incializa una nueva instancia de frmMedidaColor.
        /// </summary>
        public frmMedidaColor()
        {
            InitializeComponent();
            AplicaTalla = true;
            AplicaColor = true;
            miBussinesMedida = new BussinesValorUnidadMedida();
            miBussinesColor = new BussinesColor();
        }

        private void frmMedidaColor_Load(object sender, EventArgs e)
        {
            assembly = System.Reflection.Assembly.GetExecutingAssembly();
            CargarRecursos();
            if (AplicaTalla)
            {
                CargarTallas();
            }
            else
            {
                gbTalla.Visible = false;
                gbColor.Location = new Point(18, 32);
                this.Size = new Size(203, 362);
            }
            if (AplicaColor)
            {
                CargarColor();
            }
            else
            {
                gbColor.Visible = false;
                this.Size = new Size(203, 362);
            }
            CargarIcono();
        }

        private void frmMedidaColor_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Up || e.KeyData == Keys.Down)
            {
                if (dgvTalla.RowCount > 0 && dgvColor.RowCount > 0)
                {
                    if (dgvTalla.Focused)
                    {
                        dgvTalla_Click(this.dgvTalla, new EventArgs());
                    }
                }
            }
        }

        private void frmMedidaColor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F12)
            {
                tsBtnAceptar_Click(this.tsBtnAceptar, new EventArgs());
            }
        }

        private void frmMedidaColor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Edit)
            {
                CompletaEventos.CapturaEvento(false);
            }
        }

        private void tsBtnAceptar_Click(object sender, EventArgs e)
        {
            var tallaYcolor = new TallaYcolor();
            if (AplicaTalla)
            {
                tallaYcolor.IdTalla = (int)dgvTalla.CurrentRow.Cells["IdMedida"].Value;
                tallaYcolor.Talla = (string)dgvTalla.CurrentRow.Cells["Talla"].Value;
            }
            if (AplicaColor)
            {
                tallaYcolor.IdColor = (int)dgvColor.CurrentRow.Cells["IdColor"].Value;
                tallaYcolor.Color = (Image)dgvColor.CurrentRow.Cells["Color"].Value;
            }
            if (Venta_)
            {
                CompletaEventos.CapturaEventoVenta(tallaYcolor);
            }
            else
            {
                CompletaEventos.CapturaEvento(tallaYcolor);
            }
            this.Close();
        }

        private void dgvTalla_Click(object sender, EventArgs e)
        {
            if (AplicaColor)
            {
                //IdMedida_ = (int)dgvTalla.CurrentRow.Cells["IdMedida"].Value;
                CargarColor();
            }
        }

        /// <summary>
        /// Carga el Grid con las tallas.
        /// </summary>
        private void CargarTallas()
        {
            try
            {
                dgvTalla.AutoGenerateColumns = false;
                //dgvTalla.DataSource = miBussinesMedida.ListadoDeTallas();
                //miBussinesMedida.MedidasDeProducto
                dgvTalla.DataSource = miBussinesMedida.MedidasDeProducto(CodigoProducto);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        /// <summary>
        /// Carga el Grid con los colores.
        /// </summary>
        private void CargarColor()
        {
            try
            {
                if (AplicaTalla)
                {
                    IdMedida_ = (int)dgvTalla.CurrentRow.Cells["IdMedida"].Value;
                }
                dgvColor.AutoGenerateColumns = false;
                //dgvColor.DataSource = miBussinesColor.ListadoDeColores();
                //dgvColor.DataSource = miBussinesInventario.
                dgvColor.DataSource = miBussinesColor.ColoresDeProducto(CodigoProducto, IdMedida_);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        /// <summary>
        /// Carga los recursos del ensamblado usados en el formulario.
        /// </summary>
        private void CargarRecursos()
        {
            try
            {
                ImgMedidaStream = assembly.GetManifestResourceStream(ImagenMedida);
                ImgColorStream = assembly.GetManifestResourceStream(ImagenColor);
                ImgMedidaColorStream = assembly.GetManifestResourceStream(ImagenMedidaColor);
            }
            catch
            {
                OptionPane.MessageError("Ocurrio un error al cargar los recursos.");
            }
        }

        /// <summary>
        /// Establece el Icono del Formulario segun su necesidad.
        /// </summary>
        private void CargarIcono()
        {
            if (AplicaTalla && AplicaColor)
            {
                this.Icon = new Icon(ImgMedidaColorStream);
                this.Text = "Seleccionar Talla y Color";
            }
            else
            {
                if (AplicaColor)
                {
                    this.Icon = new Icon(ImgColorStream);
                    this.Text = "Seleccionar Color";
                }
                else
                {
                    this.Icon = new Icon(ImgMedidaStream);
                    this.Text = "Seleccionar Talla";
                }
            }
        }

    }

    /// <summary>
    /// Representa una clase para la carga de datos especifios.
    /// </summary>
    internal class TallaYcolor
    {
        /// <summary>
        /// Obtiene o establece el valor del Id de la Talla.
        /// </summary>
        public int IdTalla { set; get; }

        /// <summary>
        /// Obtiene o establece el valor del Id del Color.
        /// </summary>
        public int IdColor { set; get; }

        /// <summary>
        /// Obtiene o establece el valor de la Talla.
        /// </summary>
        public string Talla { set; get; }

        /// <summary>
        /// Obtiene o establece el valor del Color.
        /// </summary>
        public Image Color { set; get; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase TallaYcolor.
        /// </summary>
        public TallaYcolor()
        {
            this.IdTalla = 0;
            this.IdColor = 0;
            this.Talla = "";
            this.Color = null;
        }
    }
}