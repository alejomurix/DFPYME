using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BussinesLayer.Clases;
using Utilities;

namespace Aplicacion.Inventario.Bodega
{
    public partial class frmEditarBodega : Form
    {
        /// <summary>
        /// Atributos de la mascara de negocios.
        /// </summary>
        private BussinesBodega mibodega;

        /// <summary>
        /// Inicializa un nuevo objeto error previder.
        /// </summary>
        private ErrorProvider er = new ErrorProvider();

        /// <summary>
        /// Guarda el id de bodega 
        /// </summary>
        private int idBodega = 0;

        public frmEditarBodega()
        {
            InitializeComponent();
            mibodega = new BussinesBodega();
        }

        /// <summary>
        /// carga los valores seleccionados en el grid.
        /// </summary>
        public void CargaBodega(DataGridViewRow registro)
        {
            try
            {
                idBodega = Convert.ToInt32(registro.Cells[0].Value);
                this.txtNombreBodegaEditar.Text = Convert.ToString(registro.Cells[1].Value);
                this.txtUbicacionBodegaEditar.Text = Convert.ToString(registro.Cells[2].Value);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        /// <summary>
        /// Guardo y Modifico Bodega
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbGuardarCambiosEditarBodega_Click(object sender, EventArgs e)
        {
            var modificar = new DTO.Clases.Bodega();
            try
            {
                modificar.IdBodega = idBodega;
                modificar.NombreBodega = txtNombreBodegaEditar.Text;
                modificar.LugarBodega = txtUbicacionBodegaEditar.Text;
                mibodega.EditarBodega(modificar);

                MessageBox.Show("La edicion se ha realizado correctamente");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Existe nombre bodega
        /// </summary>
        /// <param name="nombre">parametro enviado</param>
        /// <returns>false true</returns>
        private bool ExisteBodega(string nombre)
        {
            try
            {
                return mibodega.ExiteBodega(nombre);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

        }

        /// <summary>
        /// Existe Ubicacion de Bodega
        /// </summary>
        /// <param name="ubicacion">parametros enviados</param>
        /// <returns>false  true</returns>
        private bool ExisteUbicacion(string ubicacion)
        {
            try 
            {
                return mibodega.ExisteUbicacion(ubicacion);
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// valido campo vacio formato y existe de nombre bodega.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNombreBodegaEditar_Validating(object sender, CancelEventArgs e)
        {
            if (Validacion.EsVacio(txtNombreBodegaEditar, er, "El campo es requerido"))
            {
                if (Validacion.ConFormato(Validacion.TipoValidacion.Palabras, txtNombreBodegaEditar, er, "Formato incorrecto"))
                {
                    if (ExisteBodega(txtNombreBodegaEditar.Text))
                    { }
                }
            }
        }
       
        /// <summary>
        /// Valido campo vacio formato y existe de ubicacion bodega.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUbicacionBodegaEditar_Validating(object sender, CancelEventArgs e)
        {

        }
    }
}
