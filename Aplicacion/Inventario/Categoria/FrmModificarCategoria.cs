using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Aplicacion.Inventario.Categoria;
using BussinesLayer.Clases;
using CustomControl;
using DTO.Clases;
using Utilities;

namespace Aplicacion.Inventario.Categoria
{
    public partial class FrmModificarCategoria : Form
    {
        /// <summary>
        /// Objeto de logica de negocio de Categoria.
        /// </summary>
        private BussinesCategoria miBussinesCategoria;

        /// <summary>
        /// Obtiene o Establece el Codigo Original de la categoria.
        /// </summary>
        private string codigoOriginal = "";

        /// <summary>
        /// Objeto para mostrar errores en el formulario.
        /// </summary>
        private ErrorProvider er = new ErrorProvider();

        /// <summary>
        /// Establece la condicion del codigo en la validacion.
        /// </summary>
        private bool modificacodigocategoria = false;

        /// <summary>
        /// Establece la condicion del nombre en la validacion.
        /// </summary>
        private bool modificanombrecategoria = false;

        /// <summary>
        /// Establece la condicion de la descripcion en la validacion.
        /// </summary>
        private bool modificadescripcioncategoria = false;

        public FrmModificarCategoria()
        {
            InitializeComponent();
            miBussinesCategoria = new BussinesCategoria();
        }

        private void FrmModificarCategoria_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Carga el registro de la categoria en el formulario de edicion.
        /// </summary>
        /// <param name="registro"></param>
        public void CargarCategoria(DataGridViewRow registro)
        {
            codigoOriginal = Convert.ToString(registro.Cells[0].Value);
            this.txtmodificarcod.Text = Convert.ToString(registro.Cells[0].Value);
            this.txtmodificarnom.Text = Convert.ToString(registro.Cells[1].Value);
            this.txtmodificardes.Text = Convert.ToString(registro.Cells[2].Value);
            var estado = Convert.ToString(registro.Cells[3].Value);
            if (estado == "Activo")
            {
                this.txtmodificarEstado.Text = "ACTIVO";
                this.rbtnEstadoActivo.Checked = true;
            }
            else
            {
                this.txtmodificarEstado.Text = "INACTIVO";
                this.rbtEstadoInactivo.Checked = true;
            }

        }

        /// <summary>
        /// modifica ol objeto categoria
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnmodificarcat_Click(object sender, EventArgs e)
        {
            validacion();
            if (modificacodigocategoria && modificanombrecategoria && modificadescripcioncategoria)
            {
                BussinesCategoria Buscat = new BussinesCategoria();
                DTO.Clases.Categoria modificarcategoria = new DTO.Clases.Categoria();
                try
                {
                    modificarcategoria.CodigoCategoria = codigoOriginal;
                    modificarcategoria.CodigoNuevo = txtmodificarcod.Text;
                    modificarcategoria.NombreCategoria = txtmodificarnom.Text;
                    modificarcategoria.DescripcionCategoria = txtmodificardes.Text;
                    if (rbtnEstadoActivo.Checked)
                    {
                        modificarcategoria.EstadoCategoria = true;
                    }
                    else if (rbtEstadoInactivo.Checked)
                    {
                        modificarcategoria.EstadoCategoria = false;
                    }
                    Buscat.ModificarCategoria(modificarcategoria);
                    OptionPane.MessageInformation("Los datos se editaron correctamente.");
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        /// <summary>
        /// boton salir
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnsalirModificar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        ///limpia los campos de el formumilario
        /// </summary>
        private void LimpiaCampo()
        {
            this.txtmodificarcod.Text = "";
            this.txtmodificarnom.Text = "";
            this.txtmodificardes.Text = "";
            this.txtmodificarEstado.Text = "";
        }

        /// <summary>
        /// validacion de campo vacio y formato modifica codigo categoria
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtmodificarcod_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(txtmodificarcod, er, "El campo es requerido"))
            {
                if (Validacion.ConFormato(Validacion.TipoValidacion.PalabrasNumeroCaracter, txtmodificarcod, er, "Formato incorrecto"))
                {
                    if (ExisteCodigoCategoria(txtmodificarcod.Text) && txtmodificarcod.Text != codigoOriginal)
                    {
                        modificacodigocategoria = false;
                        er.SetError(txtmodificarcod, "El codigo ya existe en la base de datos.");
                    }
                    else
                    {
                        modificacodigocategoria = true;
                        er.SetError(txtmodificarcod, null);
                    }
                }
                else
                {
                    modificacodigocategoria = false;
                }
            }
            else
            {
                modificacodigocategoria = false;
            }
        }

        /// <summary>
        /// valida campo vacio y formato de modificar nombre categoria
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtmodificarnom_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(txtmodificarnom, er, "El campo es requerido"))
            {
               /* if (Validacion.ConFormato(Validacion.TipoValidacion.Palabras, txtmodificarnom, er, "Formato incorrecto"))
                {*/
                    modificanombrecategoria = true;
                /*}
                else
                {
                    modificanombrecategoria = false;
                }*/
            }
            else
            {
                modificanombrecategoria = false;
            }
        }

        /// <summary>
        /// valida los campos nulos y formato modificar descripcion categoria
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtmodificardes_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(txtmodificardes, er, "El campo es requerido"))
            {
               /* if (Validacion.ConFormato(Validacion.TipoValidacion.Palabras, txtmodificardes, er, "Formato incorrecto"))
                {*/
                    modificadescripcioncategoria = true;
                /*}
                else
                {
                    modificadescripcioncategoria = false;
                }*/
            }
            else
            {
                modificadescripcioncategoria = false;
            }

        }

        /// <summary>
        /// Valida si un codigo existe en la base de datos.
        /// </summary>
        /// <param name="codigo">Codigo a Validar.</param>
        /// <returns></returns>
        private bool ExisteCodigoCategoria(string codigo)
        {
            try
            {
                return miBussinesCategoria.existecategoria(codigo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// validacion de los campos
        /// </summary>
        private void validacion()
        {
            this.txtmodificarcod_Validating(null, null);
            this.txtmodificarnom_Validating(null, null);
            this.txtmodificardes_Validating(null, null);
        }
    }
}