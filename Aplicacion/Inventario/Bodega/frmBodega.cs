using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BussinesLayer.Clases;
using DTO.Clases;
using Aplicacion.Inventario.Producto;
using Utilities;

namespace Aplicacion.Inventario.Bodega
{
    public partial class frmBodega : Form
    {
        /// <summary>
        /// Error
        /// </summary>
        private ErrorProvider er = new ErrorProvider();

        /// <summary>
        /// Atributos del modelo de negocios.
        /// </summary>
        private BussinesBodega mibodega;

        /// <summary>
        /// 
        /// </summary>
        private DataGridViewRow registro;

        /// <summary>
        /// Indica guardar nombre bodega en falso.
        /// </summary>
        private bool nombreBodega = false;

        /// <summary>
        /// Indica ubicacion Bodega en falso.
        /// </summary>
        private bool ubicacionBodega = false;

        /// <summary>
        /// Indica modificar bodega en falso.
        /// </summary>
        private bool modificaBodega = false;

        /// <summary>
        /// Indica modificar ubicacion en falso.
        /// </summary>
        private bool modificaUbicacion = false;

        /// <summary>
        /// Indica existe en falso.
        /// </summary>
        private bool Existe = false;

        /// <summary>
        /// Indica modifica existe en falso,
        /// </summary>
        private bool modificaExiste = false;

        /// <summary>
        /// guarda el codigo de bodega
        /// </summary>
        private string nombreOriginal = "";

        /// <summary>
        /// guarda la ubicacion original
        /// </summary>
        private string ubicacionOriginal = "";

        
        private const string msgCampoVacio = "El Campo {0} es Requerido";
        private const string campoBusqueda = " de Busqueda";

        /// <summary>
        /// Guarda el id de bodega 
        /// </summary>
        private int idBodega = 0;

        public frmBodega()
        {
            InitializeComponent();
            mibodega = new BussinesBodega();           

        }

        private void frmBodega_Load(object sender, EventArgs e)
        {
           
        }

        
        /// <summary>
        /// Guardo bodega a la base de datos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbGuardarBodega_Click(object sender, EventArgs e)
        {
            Revalidar();
            if (nombreBodega && ubicacionBodega)
            {
                ValidaExiste();
                if (Existe)
                {
                    var bodega = new DTO.Clases.Bodega();
                    try
                    {
                        bodega.NombreBodega = txtNombreBodega.Text;
                        bodega.LugarBodega = txtUbicacionBodega.Text;
                        mibodega.InsertarBodega(bodega);

                        MessageBox.Show("Se a ingresado correctamente");

                        this.txtNombreBodega.Text = "";
                        this.txtUbicacionBodega.Text = "";

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("el nombre de la bodega ya existe");
                }
            }
        }        

        /// <summary>
        /// Lista  bodegas de la base de datos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbListarBodegas_Click(object sender, EventArgs e)
        {
            
            {
                try
                {
                    grillabodega.DataSource = mibodega.ListarBodegas();
                    grillabodega.Columns["idbodega"].Visible = false;
                    grillabodega_Click(null, null);
                }

                catch (Exception ex)
                {
                    MessageBox.Show("No hay bodegas a listar. Ingrese primero bodega"+ex.Message);
                }
            }
           
        }

        /// <summary>
        /// Buscar Bodega por nombre.
        /// </summary>
        /// <param name="sender">parametro enviado</param>
        /// <param name="e"></param>
        private void btnBuscarBodegaNombre_Click(object sender, EventArgs e)
        {
            if (this.txtBusquedaNombreBodega.Text != "")
            {
                mibodega = new BussinesBodega();
                try
                {
                    string nombre = Convert.ToString(txtBusquedaNombreBodega.Text);
                    grillabodega.DataSource = null;
                    grillabodega.DataSource = mibodega.ListarBodegasNombre(nombre);

                    grillabodega.Columns["idbodega"].Visible = false;
                }
                catch 
                {
                    MessageBox.Show("No existe la Bodega");
                }
            }
            else
            {
                this.grillabodega.DataSource = null;
                MessageBox.Show(string.Format(msgCampoVacio, campoBusqueda));
            }
        }


        /// <summary>
        /// Direcciona a otro formulario para edicion de Bodega
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbEditarBodega_Click(object sender, EventArgs e)
        {
            if (this.grillabodega.RowCount != 0)
            {
                this.gbModificaBodega.Enabled = true;
            }
            else
            {
                MessageBox.Show("Seleccione una bodega a modificar");
            }
        }

       
        /// <summary>
        /// Elimina Bodega
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbEliminarBodega_Click(object sender, EventArgs e)
        {
            if (this.grillabodega.RowCount != 0)
            {
                try
                {
                    int idbodedga = (int)this.grillabodega.CurrentRow.Cells[0].Value;
                    mibodega.EliminarBodega(idbodedga);

                    MessageBox.Show("Se a eliminado Exitosamente");

                    tsbListarBodegas_Click(null, null);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("seleccione la bodega a eliminar");
            }
        }

       
        private void grillabodega_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow currentRow = grillabodega.Rows[grillabodega.CurrentCell.RowIndex];
            TransferirBodegaeb miBodega = TransferirBodegaeb.Instanciaeb();
            miBodega.idbodega = Convert.ToInt32(currentRow.Cells[0].Value);
            miBodega.nombrebodega = Convert.ToString(currentRow.Cells[1].Value);
            miBodega.lugarbodega = Convert.ToString(currentRow.Cells[2].Value);

            CompletaEventos.CapturaEventoeb(miBodega);

            this.Close();

        }

        /// <summary>
        /// Verifica si bodega existe en la base de datos.
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
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
        /// Verifica si ubicacion de la bodega existe.
        /// </summary>
        /// <param name="ubicacion"></param>
        /// <returns></returns>
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
        /// Valido campo vacio formato.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNombreBodega_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(txtNombreBodega, er, "El campo es requerido")) 
            {
                if (Validacion.ConFormato(Validacion.TipoValidacion.Palabras, txtNombreBodega, er, "Formato incorrecto")) 
                {
                  nombreBodega = true;
                }

                else
                {
                nombreBodega=false;
                }
            }

            else
            {
                nombreBodega=false;
            }

        }
    

        /// <summary>
        /// Valido campo vacio y formato
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUbicacionBodega_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(txtUbicacionBodega, er, "El campo es requerido"))
            {
                if (Validacion.ConFormato(Validacion.TipoValidacion.Domicilio, txtUbicacionBodega, er, "Formato incorrecto"))
                {
                    ubicacionBodega = true;
                }
                else
                {
                    ubicacionBodega = false;
                }
            }
            else
            {
                ubicacionBodega = false;
            }

        }

        /// <summary>
        /// valido existe bodega .      
        /// </summary>
        private void ValidaExiste()
        {
            var bodega = ExisteBodega(txtNombreBodega.Text);
            var ubicacion = ExisteUbicacion(txtUbicacionBodega.Text);

            if ((bodega && !ubicacion) || (!bodega && ubicacion) || (!bodega && !ubicacion))
            {
                Existe = true;
            }
            else
            {
                Existe = false;
            }
 
        }

        /// <summary>
        /// Revalido los campos 
        /// </summary>
        private void Revalidar()
        {
            txtNombreBodega_Validating(null, null);
            txtUbicacionBodega_Validating(null, null);
        }

        /// <summary>
        /// Modifica y Guarda Bodega.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsGuardaBodega_Click(object sender, EventArgs e)
        {
            RevalidaModificar();
            if (modificaBodega && modificaUbicacion)
            {

               var nombreTemp = nombreOriginal.ToLower();
               var ubicacionTemp = ubicacionOriginal.ToLower();

               if (!nombreTemp.Equals(txtModificarBodega.Text.ToLower())
                   && !ubicacionTemp.Equals(txtModificarUbicacion.Text.ToLower()))
               {
                   ExisteCampoModificar();

                   if (modificaExiste)
                   {
                       var modificar = new DTO.Clases.Bodega();
                       try
                       {
                           modificar.IdBodega = idBodega;
                           modificar.NombreBodega = txtModificarBodega.Text;
                           modificar.LugarBodega = txtModificarUbicacion.Text;
                           mibodega.EditarBodega(modificar);

                           MessageBox.Show("La edicion se ha realizado correctamente");

                           this.gbModificaBodega.Enabled = false;
                           tsbListarBodegas_Click(null, null);
                       }
                       catch (Exception ex)
                       {
                           MessageBox.Show(ex.Message);
                       }
                   }
               }
               
            }
        }

        /// <summary>
        /// Carga los valores selecionados en el tex a modificar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grillabodega_Click(object sender, EventArgs e)
        {
            if (this.grillabodega.RowCount != 0)
            {
                registro = this.grillabodega.Rows[this.grillabodega.CurrentCell.RowIndex];

                try
                {
                    idBodega = Convert.ToInt32(registro.Cells[0].Value);
                    this.txtModificarBodega.Text = Convert.ToString(registro.Cells[1].Value);
                    this.txtModificarUbicacion.Text = Convert.ToString(registro.Cells[2].Value);


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Seleccione una bodega" + ex.Message);
                }

            }
            else
            {
                MessageBox.Show("Seleccione la bodega a modificar");
            }
        }

        /// <summary>
        /// valido canpo vacio formato y existe.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtModificarBodega_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(txtModificarBodega, er, "El campo es requerido"))
            {
                if (Validacion.ConFormato(Validacion.TipoValidacion.Palabras, txtModificarBodega, er, "formato incorrecto"))
                {
                    modificaBodega = true;
                }
                else
                {
                    modificaBodega = false;
                }
            }
            else
            {
                modificaBodega = false;
            }
        }

        /// <summary>
        /// Valido campo vacio forma pago y existe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtModificarUbicacion_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(txtModificarUbicacion, er, "El campo es requerido"))
            {
                if (Validacion.ConFormato(Validacion.TipoValidacion.Domicilio, txtModificarUbicacion, er, "Formato incorrecto"))
                {
                    modificaUbicacion = true;
                }
                else
                {
                    modificaUbicacion = false;
                }
            }
            else
            {
                modificaUbicacion = false;
            }
        }

        /// <summary>
        /// Ravalido los campos
        /// </summary>
        private void RevalidaModificar()
        {
            txtModificarBodega_Validating(null, null);
            txtModificarUbicacion_Validating(null, null);
        }

        /// <summary>
        /// valido existe bodega al Modifiacar.
        /// </summary>
        private void ExisteCampoModificar()
        {
            var modificaNonbreBodega =ExisteBodega (txtModificarBodega.Text);
            var modificaUbicacionBodega = ExisteUbicacion(txtModificarUbicacion.Text);

            if ((modificaNonbreBodega && !modificaUbicacionBodega) || (!modificaNonbreBodega && modificaUbicacionBodega)
                || (!modificaUbicacionBodega && !modificaUbicacionBodega))
            {
                modificaExiste = true;

            }
            else
            {
                modificaBodega = false;
            }
        }

        
      
    }
}
