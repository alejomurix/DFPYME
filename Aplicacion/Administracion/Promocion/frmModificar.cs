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
using DTO.Clases;
using System.Collections;

namespace Aplicacion.Administracion.Promocion
{
    public partial class frmEditarPromocion : Form
    {
        private DTO.Clases.Promocion miPromocionOriginal;

        private DTO.Clases.Marca miMarca;

        private DTO.Clases.Categoria miCategoria;

        private DTO.Clases.Producto miProducto;

        /// <summary>
        /// Objeto de modelo de negocios.
        /// </summary>
        private BussinesPromocion miBussinesPromocion;

        /// <summary>
        /// Objeto de modelo de negocios.
        /// </summary>
        private BussinesDescuento miBussinesDescuento;

        /// <summary>
        /// objeto de modelo de negocios.
        /// </summary>
        private BussinesCategoria miCat;

        /// <summary>
        /// Objeto de modelo de negocios.
        /// </summary>
        private BussinesProducto miPro;
       
        /// <summary>
        /// Representa una tabla de datos en memoria.
        /// </summary>
        private DataTable miTabla;

        /// <summary>
        ///Probador de mensajes de error
        /// </summary>
        private ErrorProvider er;

        /// <summary>
        /// Coleccion de objetos(categoria).
        /// </summary>
        private ArrayList arrayCategoria;

        /// <summary>
        /// Coleccion de objetos(producto)
        /// </summary>
        private ArrayList arrayproducto;

        /// <summary>
        /// Determina el estado de la validacion.
        /// </summary>
        private bool keyPress;

        /// <summary>
        /// Determina el estado de la validacion.
        /// </summary>
        private bool matchCantidad = false;

        /// <summary>
        /// Determina el estado de fecha en la validacion
        /// </summary>
        private bool matchFecha = false;

        public frmEditarPromocion()
        {
            InitializeComponent();
            miBussinesPromocion = new BussinesPromocion();
            miBussinesDescuento = new BussinesDescuento();            
            miCat = new BussinesCategoria();
            miPro = new BussinesProducto();
            er = new ErrorProvider();
            
        }

        private void frmEditarPromocion_Load(object sender, EventArgs e)
        {
            CompletaEventos.Completam += new CompletaEventos.CompletaAccionm(CompletaEventosm_Completo);
            CargarLisbox();
            CargarOrigenLisBox();
        }

        private void tsbtnModificarGuardar_Click(object sender, EventArgs e)
        {
            var promocion = new DTO.Clases.Promocion();
            try
            {
                Revalidar();
                if (matchFecha)
                {
                    promocion.idPromocion = miPromocionOriginal.idPromocion;
                    promocion.idTipo = miPromocionOriginal.idTipo;
                    promocion.idDescuento = Convert.ToInt32(lbxModificaDescuento.SelectedValue);
                    promocion.fechaInicio = dtpModificaFechaInicio.Value;
                    promocion.fechaFin = dtpModificaFechaFin.Value;
                    if (miPromocionOriginal.idTipo == 2)
                    {
                        promocion.Marca = miMarca.IdMarca;
                    }
                    else
                    {
                        if (miPromocionOriginal.idTipo == 3)
                        {
                            promocion.Categoria = miCategoria.CodigoCategoria;
                        }
                        else
                        {
                            if (matchCantidad)
                            {
                                promocion.Producto = miProducto.CodigoInternoProducto;
                                promocion.Producto = txtModificarNArticulos.Text;
                            }
                        }
                    }
                    miBussinesPromocion.EditarPromocion(promocion);
                    OptionPane.MessageInformation("La promocion se ha editado con exito.");
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError("Error al modificar la promocion." + ex.Message);
            }
        }  
        

        private void btnModificarFechaInicio_Click(object sender, EventArgs e)
        {
            txtModificafechaIniciuo.Visible = false;
            dtpModificaFechaInicio.Visible = true;
            btnDesacerFechaInicio.Visible = true;
            btnModificarFechaInicio.Visible = false;
        }

        private void btnModificarfechaFin_Click(object sender, EventArgs e)
        {
            txtModificafechaFin.Visible = false;
            dtpModificaFechaFin.Visible = true;
            btnDesacerFechaFin.Visible = true;
            btnModificarfechaFin.Visible = false;
        }

        private void btnModificarDescuento_Click(object sender, EventArgs e)
        {
            lbxModificaDescuento.Enabled = true;
            btnModificarDescuento.Visible = false;
            btnDesacerDescuento.Visible = true;
        }

        private void btnModificarCantidad_Click(object sender, EventArgs e)
        {
            txtModificarNArticulos.Enabled = true;
            btnDesacerCantidad.Visible = true;
            btnModificarCantidad.Visible = false;
        }

        private void btnDesacerFechaInicio_Click(object sender, EventArgs e)
        {
            dtpModificaFechaInicio.Value = miPromocionOriginal.fechaInicio;
        }

        private void btnDesacerFechaFin_Click(object sender, EventArgs e)
        {
            dtpModificaFechaFin.Value = miPromocionOriginal.fechaFin;
        }

        private void btnDesacerDescuento_Click(object sender, EventArgs e)
        {
            CargarOrigenLisBox();
        }

        private void btnDesacerCantidad_Click(object sender, EventArgs e)
        {
            txtModificarNArticulos.Text = Convert.ToString(miPromocionOriginal.cantidad);
        }

        private void btnModificarBuscar_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Esta seguro de ingresar un nuevo registro.", "Edicion",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (r == DialogResult.OK)
            {
                try
                {
                    if (miPromocionOriginal.idTipo == 2)
                    {
                        Configuracion.Marcas.frmMarca marca = new Configuracion.Marcas.frmMarca();
                        marca.Extension = true;
                        marca.CargaGrillaMarca();
                        marca.Show();
                    }
                    else
                    {
                        if (miPromocionOriginal.idTipo == 3)
                        {
                            Inventario.Categoria.FrmCategoria categoria = new Inventario.Categoria.FrmCategoria();
                            categoria.Extencion = true;
                            categoria.CargarGridCategorias();
                            categoria.Show();
                        }
                        else
                        {
                            Inventario.Producto.FrmIngresarProducto producto = new Inventario.Producto.FrmIngresarProducto();
                            producto.Show();
                        }
                    }
                }
                catch
                { }
            }
        }

        private void tsbtnModificarSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
        
        private void txtModificamarcaCategoriaProducto_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {
                if (ValidaCodigo() || ValidaBarras())
                {
                    if (Existe(txtModificamarcaCategoriaProducto.Text))
                    {
                        cargar();
                        er.SetError(txtModificamarcaCategoriaProducto, null);
                        keyPress = true;
                    }
                    else
                    {
                        OptionPane.MessageInformation("No existe al codigo en la base de datos.");
                        er.SetError(txtModificamarcaCategoriaProducto, "No existe el codigo en la base de datos");
                    }
                }
                else
                { }
            }
            else
            {
                keyPress = false;
            }
        }

        private void txtModificamarcaCategoriaProducto_Validating(object sender, CancelEventArgs e)
        {
            if (!keyPress)
            {
                if (ValidaCodigo() || ValidaBarras())
                {
                    if (Existe(txtModificamarcaCategoriaProducto.Text))
                    {
                        cargar();
                        er.SetError(txtModificamarcaCategoriaProducto, null);
                    }
                    else
                    {
                        OptionPane.MessageError("El codigo ingresado no existe en lña base de datos");
                        er.SetError(txtModificamarcaCategoriaProducto, "El codigo ingresado no existe en la base de datos");
                    }
                }
                else
                { }
            }
        }

        private void txtModificarNArticulos_Validating(object sender, CancelEventArgs e)
        {
            var criterio = miPromocionOriginal.idTipo;
            if (criterio == 4)
            {
                if (!string.IsNullOrEmpty(txtModificarNArticulos.Text))
                {
                    if (Validacion.ConFormato(Validacion.TipoValidacion.Numeros, txtModificarNArticulos, er, "Formato incorrecto"))
                    {
                        matchCantidad = true;
                        er.SetError(txtModificarNArticulos, null);
                    }
                    else
                        matchCantidad = false;
                }
                else
                {
                    er.SetError(txtModificarNArticulos, "El campo es requerido");
                    matchCantidad = false;
                }
            }
        }

        private void dtpModificaFechaFin_Validating(object sender, CancelEventArgs e)
        {
            var fechaInicio = new DateTime(dtpModificaFechaInicio.Value.Year, dtpModificaFechaInicio.Value.Month, dtpModificaFechaInicio.Value.Day);
            var fechaFin = new DateTime(dtpModificaFechaFin.Value.Year, dtpModificaFechaFin.Value.Month, dtpModificaFechaFin.Value.Day);
            if (fechaInicio <= fechaFin)
            {
                matchFecha = true;
                er.SetError(dtpModificaFechaFin, null);
            }
            else
            {
                matchFecha = false;
                er.SetError(dtpModificaFechaFin, "La fecha de inicio debe ser menor a la fecha final.");
            }
        }

        /// <summary>
        /// Cargar promocion
        /// </summary>
        /// <param name="idPromocion">id promocion</param>
        public void CargarPromocion(int idPromocion, int idTipo)
        {
            try
            {
                miPromocionOriginal = miBussinesPromocion.CargarPromocion(idPromocion, idTipo);
                txtModifcaTipoPromocion.Text = miPromocionOriginal.NombreTipoPromocion;
                txtModificafechaIniciuo.Text = miPromocionOriginal.fechaInicio.ToShortDateString();
                txtModificafechaFin.Text = miPromocionOriginal.fechaFin.ToShortDateString();
                if (miPromocionOriginal.idTipo == 2)
                {
                    lblModificaCategoriamarcaProducto.Text = "Seleccione la marca";
                    txtModificamarcaCategoriaProducto.Text = miPromocionOriginal.MarcaValor;                   
                    lblModificaProductoCategoriamarca.Text = miPromocionOriginal.MarcaValor;
                    lbxModificaDescuento.Focus();
                }
                else
                {
                    if (miPromocionOriginal.idTipo == 3)
                    {
                        lblModificaCategoriamarcaProducto.Text = "Seleccione la categoria";
                        txtModificamarcaCategoriaProducto.Enabled = true;
                        txtModificamarcaCategoriaProducto.Text = miPromocionOriginal.Categoria;
                        lblModificaProductoCategoriamarca.Text = miPromocionOriginal.CategoriaValor;                        
                    }
                    else
                    {
                        lblModificaCategoriamarcaProducto.Text = "Seleccione el producto";
                        btnModificarCantidad.Enabled = true;
                        txtModificamarcaCategoriaProducto.Enabled = true;
                        txtModificamarcaCategoriaProducto.Text = miPromocionOriginal.Producto;
                        lblModificaProductoCategoriamarca.Text = miPromocionOriginal.ProductoValor;
                        txtModificarNArticulos.Text = Convert.ToString(miPromocionOriginal.cantidad);                       
                    }
                }
               
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        /// <summary>
        /// Lista descuento.
        /// </summary>
        public void CargarLisbox()
        {
            try
            {
                lbxModificaDescuento.DataSource = miBussinesDescuento.ListadoDescuento();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError("Error al listar descunto.");
            }
        }

        /// <summary>
        /// Completa acciones de eventos
        /// </summary>
        /// <param name="arg"></param>
        void CompletaEventosm_Completo(CompletaArgumentosDeEventom arg)
        {
            try
            {
                TransferirMarca m = (TransferirMarca)arg.MiMarca;

                miMarca = new Marca();
                miMarca.IdMarca = m.IdMarca;
                miMarca.NombreMarca = m.NombreMarca;
                txtModificamarcaCategoriaProducto.Text = miMarca.NombreMarca;
                lblModificaProductoCategoriamarca.Text = miMarca.NombreMarca;
            }
            catch
            { }
            try
            {

                DTO.Clases.Categoria c = (DTO.Clases.Categoria)arg.MiMarca;

                miCategoria = new Categoria();
                miCategoria.CodigoCategoria = c.CodigoCategoria;
                miCategoria.NombreCategoria = c.NombreCategoria;
                lblModificaProductoCategoriamarca.Text = miCategoria.CodigoCategoria + " - " + miCategoria.NombreCategoria;
            }
            catch
            { }
            try
            {
                Producto p = (Producto)arg.MiMarca;

                miProducto = new Producto();
                miProducto.CodigoInternoProducto = p.CodigoInternoProducto;
                miProducto.NombreProducto = p.NombreProducto;
                lblModificaProductoCategoriamarca.Text = miProducto.CodigoInternoProducto + " . " + miProducto.NombreProducto;
            }
            catch
            { }
        }

        /// <summary>
        /// Cargar Lisbox.
        /// </summary>
        private void CargarOrigenLisBox()
        {
            var cont = 0;
            foreach (Descuento d in lbxModificaDescuento.Items)
            {
                if (d.IdDescuento == miPromocionOriginal.idDescuento)
                {
                    break;
                }
                cont++;
            }
            lbxModificaDescuento.SetSelected(cont, true);
        }

        
        /// <summary>
        /// valida campo vacio y formato.
        /// </summary>
        /// <returns></returns>
        private bool ValidaCodigo()
        {
            var validaCodigo = false;
            if (!Validacion.EsVacio(txtModificamarcaCategoriaProducto, er, "El campo es requerido"))
            {
                if (Validacion.ConFormato(Validacion.TipoValidacion.NumeroEspacio, txtModificamarcaCategoriaProducto, er, "Formato incorrecto"))
                {
                    return validaCodigo = true;
                }
            }
            return validaCodigo = false;
        }

        /// <summary>
        /// Valida campo vacio y formato.
        /// </summary>
        /// <returns></returns>
        private bool ValidaBarras()
        {
            var validaBarras = false;
            if (!Validacion.EsVacio(txtModificamarcaCategoriaProducto, er, "El campo es requerido"))
            {
                if (Validacion.ConFormato(Validacion.TipoValidacion.Numeros, txtModificamarcaCategoriaProducto, er, "FormatoIncorrecto"))
                {
                    return validaBarras = true;
                }
            }
            return validaBarras = false;
        }

        /// <summary>
        /// Rebalida campos
        /// </summary>
        public void Revalidar()
        {
            dtpModificaFechaFin_Validating(null, null);
            txtModificarNArticulos_Validating(null, null);   
        }

        /// <summary>
        /// Valida existe
        /// </summary>
        /// <param name="codigo"> codigo</param>
        /// <returns></returns>
        private bool Existe(string codigo)
        {
            var criterio = miPromocionOriginal.idTipo;
            try
            {
                if (criterio == 3)
                {
                    miCat.existecategoria(codigo);
                    return true;
                }
                else
                {
                    if (criterio == 4)
                    {
                        var codex = miPro.ExisteCodigo(codigo);
                        var barras = miPro.ExisteCodigoBarras(codigo);
                        if (codex || barras)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            catch(Exception ex)
            {
                OptionPane.MessageInformation("Error de busqueda." + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Cargar datos el el label.
        /// </summary>
        private void cargar()
        {
            var criterio = miPromocionOriginal.idTipo;
            try
            {
                if (criterio == 3)
                {
                    arrayCategoria = miCat.consultaCategoriaCodigo(txtModificamarcaCategoriaProducto.Text);
                    miCategoria = (DTO.Clases.Categoria)arrayCategoria[0];
                    lblModificaProductoCategoriamarca.Text = miCategoria.CodigoCategoria + " - " + miCategoria.NombreCategoria;
                }
                else
                {
                    arrayproducto = miPro.ProductoBasico(txtModificamarcaCategoriaProducto.Text);
                    miProducto = (DTO.Clases.Producto)arrayproducto[0];
                    lblModificaProductoCategoriamarca.Text = miProducto.CodigoInternoProducto + " - " + miProducto.NombreProducto;
                }
            }
            catch(Exception ex)
            {
                OptionPane.MessageError("Error de carga" + ex.Message);
            }
        }        
    }
}

