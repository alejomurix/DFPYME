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
using Aplicacion.Inventario.Bodega;
using Utilities;


namespace Aplicacion.Inventario.Zona
{
    public partial class frmZona : Form
    {
        /// <summary>
        /// Atributos de modelo de negocios.
        /// </summary>
        private BussinesZona mizona;

        /// <summary>
        /// Carga los criterios de bisqueda
        /// </summary>
        private CargarCriteriosZona micarga;

        private ErrorProvider er=new ErrorProvider();

        /// <summary>
        /// Carga el id de bodega;
        /// </summary>
        private int idbodega = 0;

        /// <summary>
        /// Establece la condicion del Nombre en la validacion.
        /// </summary>
        private bool nombreZona = false;

        /// <summary>
        /// Establece la condicion del Numero en la validacion.
        /// </summary>
        private bool numeroZona = false;

        /// <summary>
        /// Establece la condicion de la capacidad en la validacion.
        /// </summary>
        private bool capacidadZona = false;

        /// <summary>
        /// Establece la condicion de bodega en la validacion.
        /// </summary>
        private bool Bodega = false;

        public frmZona()
        {
            InitializeComponent();
            mizona = new BussinesZona();
            micarga = new CargarCriteriosZona();
        }

        private void frmZona_Load(object sender, EventArgs e)
        {
            micarga = new CargarCriteriosZona();
            dgbZona.AutoGenerateColumns = false;
            cbxBusquedaZona.DataSource = micarga.lista1;

            CompletaEventos.Completaeb += new CompletaEventos.CompletaAccioneb(CompletaEventoseb_Completo);

        }

        /// <summary>
        /// Ingresa zona a la base de datos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbGuardarZona_Click(object sender, EventArgs e)
        {
            Revalidar();
            if (nombreZona && numeroZona && capacidadZona && Bodega)
            {
                var zona = new DTO.Clases.Zona();
                try
                {

                    zona.NombreZona = txtNombreZona.Text;
                    zona.NumeroZona = Convert.ToInt32(txtNumeroZona.Text);
                    zona.Capacidad = txtCapacidadZona.Text;
                    zona.IdBodega = idbodega;
                    zona.NombreBodega = txtNombreBodega.Text;
                    zona.LugarBodega = txtUbicacionBodega.Text;
                    zona.DisponibleZona = true;

                    mizona.InsertarZona(zona);

                    MessageBox.Show("Zona Ingresada");

                    LimpiaCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        /// <summary>
        /// Listar zonas.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbListarTodas_Click(object sender, EventArgs e)
        {
            try
            {
                dgbZona.DataSource = mizona.ListaZonas();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        /// <summary>
        /// Filtro zona por nombre.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnListarZonaNombre_Click(object sender, EventArgs e)
        {
            try
            {
                ListaZona();
                if (dgbZona.RowCount == 0)
                {
                    MessageBox.Show("No se encontraron registros");

                    this.txtBuscarZona.Text = "";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Mando los datos de zona al formulario de editar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbEditarZona_Click(object sender, EventArgs e)
        {
            if (this.dgbZona.RowCount != 0)
            {
                try
                {
                    frmEditarZona editazona = new frmEditarZona();
                    var id = (int)dgbZona.CurrentRow.Cells[0].Value;
                    editazona.CargarZonaEditar(id);
                    editazona.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("No hay zonas a modificar \n seleccione la zona a modificar");
            }
        }

        /// <summary>
        /// Eliminar zona.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbEliminarZona_Click(object sender, EventArgs e)
        {
            if (this.dgbZona.RowCount != 0)
            {
                var zona = new DTO.Clases.Zona();
                DataGridViewRow currentRow = dgbZona.Rows[dgbZona.CurrentCell.RowIndex];

                try
                {
                    mizona.EliminarZona(Convert.ToInt32(currentRow.Cells[0].Value));

                    MessageBox.Show("La zona ha sido eliminada");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("No hay zonas para eliminar \n seleccione la zona a eliminar");
            }
        }


        /// <summary>
        /// Lisatar zona.
        /// </summary>
        public void ListaZona()
        {
            int criterio1 = Convert.ToInt32(this.cbxBusquedaZona.SelectedValue);
            if (this.txtBuscarZona.Text != "")
            {
                if (criterio1 == 1)
                {
                    this.ConsultaNombreZona(txtBuscarZona.Text);
                }

                if (criterio1 == 2)
                {
                    this.ConsultaZonaCapacidad(txtBuscarZona.Text);
                }
            }
            else
            {
                this.dgbZona.DataSource = null;
                MessageBox.Show("El campo es requerido", "Zona", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        /// <summary>
        /// Consulta por nombre la zona
        /// </summary>
        /// <param name="nombre"></param>
        public void ConsultaNombreZona(string nombre)
        {
            try
            {
                this.dgbZona.DataSource = mizona.ListarZonaNombre(nombre);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Consultar zona por capacidad.
        /// </summary>
        /// <param name="capacidad"></param>
        public void ConsultaZonaCapacidad(string capacidad)
        {
            try
            {
                this.dgbZona.DataSource = mizona.ListaCapacidadZona(capacidad);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       
        /// <summary>
        /// Me lleba al formulario de bodega.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregarBodegaZona_Click(object sender, EventArgs e)
        {
            
            
                frmBodega muestrabodega = new frmBodega();
                muestrabodega.Show();
          
        }

        /// <summary>
        /// Me trae los datos zona a editar zona.
        /// </summary>
        /// <param name="args"></param>
        void CompletaEventoseb_Completo(CompletaArgumentosDeEventoeb args)
        {
            try
            {
                TransferirBodegaeb b = (TransferirBodegaeb)args.MiBodegaeb;
                idbodega = b.idbodega;
                txtNombreBodega.Text = b.nombrebodega;
                txtUbicacionBodega.Text = b.lugarbodega;
            }
            catch 
            {
                
            }
            try
            {
                var id =(int) args.MiBodegaeb;

                RefrescaGrd(id);
            }
            catch
            { 
            }
        }

        private void tsbbtnsalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// valida campo vacio y formato.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNombreZona_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(txtNombreZona, er, "El campo es requerido"))
            {
                if (Validacion.ConFormato(Validacion.TipoValidacion.PalabrasNumeroCaracter, txtNombreZona, er,
                    "Formato incorrecto"))
                {
                    nombreZona = true;
                }
                else
                {
                    nombreZona = false;
                }
            }
            else
            {
                nombreZona = false;
            }
        }

        /// <summary>
        /// Validacion de campo vacio y formato.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNumeroZona_Validating(object sender, CancelEventArgs e)
        {
            if(!Validacion.EsVacio(txtNumeroZona,er,"El campo es requerido"))
            {
               if(Validacion.ConFormato(Validacion.TipoValidacion.NumeroGuion,txtNumeroZona,er,
                   "Formato Incorrecto"))
               {
                   numeroZona=true;
               }
               else
               {
                   numeroZona=false;
               }
            }
            else
            {
                numeroZona=false;
            }

        }

        /// <summary>
        /// Validacion de campo vacio y formato.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCapacidadZona_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(txtCapacidadZona, er, "El campo es requerido"))
            {
                if (Validacion.ConFormato(Validacion.TipoValidacion.PalabrasNumeroCaracter, txtCapacidadZona, er,
                    "Formato Incorrecto"))
                {
                    capacidadZona = true;
                }
                else
                {
                    capacidadZona = false;
                }
            }
            else
            {
                capacidadZona = false;
            }                        
        }
        
        /// <summary>
        /// Revalido los campos
        /// </summary>
        private void Revalidar()
        {
            this.txtNombreZona_Validating(null, null);
            this.txtNumeroZona_Validating(null, null);
            this.txtCapacidadZona_Validating(null, null);
            this.txtNombreBodega_Validating(null, null);
        }

        /// <summary>
        /// limpia los campos de el formulario
        /// </summary>
        private void LimpiaCampos()
        {
            this.txtNombreZona.Text = "";
            this.txtNumeroZona.Text = "";
            this.txtCapacidadZona.Text = "";
            this.txtNombreBodega.Text = "";
            this.txtUbicacionBodega.Text = "";
        }

        /// <summary>
        /// valido campo vacio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNombreBodega_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(txtNombreBodega, er, "Deve ingresar una bodega"))
            {
                Bodega = true;
            }
            else
            {
                Bodega=false;
            }
        }

        /// <summary>
        /// consulta y refresca la grilla
        /// </summary>
        /// <param name="id"></param>
        private void RefrescaGrd(int id)
        {
            try 
            {
                dgbZona.DataSource = mizona.ListaZonas(id);                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
 
        }
    }
}