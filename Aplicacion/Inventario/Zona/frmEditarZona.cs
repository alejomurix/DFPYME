using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BussinesLayer.Clases;
using Aplicacion.Inventario.Bodega;
using Utilities;
using DTO.Clases;

namespace Aplicacion.Inventario.Zona
{
    public partial class frmEditarZona : Form
    {
        /// <summary>
        /// Carga el id original de zona.
        /// </summary>
        private int IdOriginal=0;

        /// <summary>
        /// Carga el id original de bodega.
        /// </summary>
        private int IdBodegaOriginal = 0;

        /// <summary>
        /// Establece la condicion del Nombre en la validacion.
        /// </summary>
        private bool nombreZonaE = false;

        /// <summary>
        /// Establece la condicion del numero en la validacion.
        /// </summary>
        private bool numeroZonaE = false;

        /// <summary>
        /// Easablece la condicion de la capacidad en la validacion.
        /// </summary>
        private bool capacidadZonaE = false;

        private BussinesZona mibussineszona;

        private ErrorProvider er = new ErrorProvider();

        public frmEditarZona()
        {
            InitializeComponent();
            mibussineszona = new BussinesZona();
        }

        private void frmEditarZona_Load(object sender, EventArgs e)
        {
        CompletaEventos.Completaeb += new CompletaEventos.CompletaAccioneb(CompletaEventoseb_Completo); 

        }


        void CompletaEventoseb_Completo(CompletaArgumentosDeEventoeb args)
        {
            try
            {
                TransferirBodegaeb b = (TransferirBodegaeb)args.MiBodegaeb;

                txtNombreBodegaEditar.Text = b.nombrebodega;
                txtUbicacionBodegaEditar.Text = b.lugarbodega;
                IdBodegaOriginal = (b.idbodega);

            }
            catch
            { }
        }
       
        /// <summary>
        /// Carga los datos de zona a modificar.
        /// </summary>
        /// <param name="IdZona">parametro a enviar</param>
        public void CargarZonaEditar(int IdZona)
        {
           
            DTO.Clases.Zona mizona = mibussineszona.ListarZonaCompletoIdZona(IdZona);
          
            IdOriginal = mizona.IdZona;
            txtNombreZonaEditar.Text = mizona.NombreZona;
            txtNumeroZonaEditar.Text = Convert.ToString(mizona.NumeroZona);           
            txtCapacidadZonaEditar.Text = mizona.Capacidad;
            if (mizona.DisponibleZona)
            {
                rbDisponible.Checked = true;

            }
            else
            {
                rbNoDisponible.Checked = true;
            }
            IdBodegaOriginal = mizona.IdBodega;
            txtNombreBodegaEditar.Text = mizona.NombreBodega;
            txtUbicacionBodegaEditar.Text = mizona.LugarBodega;
           
        }

        /// <summary>
        /// Guarda modificaciones de zona.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbGuardarCambiosEditarZona_Click(object sender, EventArgs e)
        {
            Revalidar();

            if (nombreZonaE && numeroZonaE && capacidadZonaE)
            {
                try
                {
                    var zona = new DTO.Clases.Zona();

                    zona.IdZona = IdOriginal;
                    zona.IdBodega = IdBodegaOriginal;
                    zona.Capacidad = txtCapacidadZonaEditar.Text;
                    zona.NumeroZona = Convert.ToInt32(txtNumeroZonaEditar.Text);
                    zona.NombreZona = txtNombreZonaEditar.Text;
                    if (rbDisponible.Checked)
                    {
                        zona.DisponibleZona = true;
                    }
                    else
                    {
                        zona.DisponibleZona = false;
                    }
                    zona.NombreBodega = txtNombreBodegaEditar.Text;
                    zona.LugarBodega = txtUbicacionBodegaEditar.Text;
                    mibussineszona.EditarZona(zona);

                    MessageBox.Show("Edicion correcta.");

                    CompletaEventos.CapturaEventoeb(IdOriginal);

                    LimpiaCampos();

                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void btnAgregarBodegaZona_Click(object sender, EventArgs e)
        {
            frmBodega agregabodega = new frmBodega();
            agregabodega.Show();
            
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Validacion campo vacio y formato
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNombreZonaEditar_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(txtNombreZonaEditar, er, "El campo es requerido"))
            {
                if (Validacion.ConFormato(Validacion.TipoValidacion.PalabrasNumeroCaracter, txtNombreZonaEditar
                    , er, "Formato incorrecto"))
                {
                    nombreZonaE = true;
                }
                else
                {
                    nombreZonaE = false;
                }
            }
            else
            {
                nombreZonaE = false;
            }
        }

        /// <summary>
        /// Validacion de campo vacio y formato.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNumeroZonaEditar_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(txtNumeroZonaEditar, er, "El campo es requerido"))
            {
                if(Validacion.ConFormato(Validacion.TipoValidacion.NumeroGuion,txtNumeroZonaEditar,
                    er,"Formaro Incorrecto"))
                {
                    numeroZonaE=true;
                }
                else
                {
                    numeroZonaE=false;
                }
            }
            else
            {
                numeroZonaE=false;
            }
        }

        /// <summary>
        /// Validacion campo vacio y formato.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCapacidadZonaEditar_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(txtCapacidadZonaEditar, er, "El campo es requerido"))
            {
                if (Validacion.ConFormato(Validacion.TipoValidacion.PalabrasNumeroCaracter, txtCapacidadZonaEditar, er,
                    "Formato incorrecto"))
                {
                    capacidadZonaE = true;
                }
                else
                {
                    capacidadZonaE = false;
                }
            }
            else
            {
                capacidadZonaE = false;
            }
        }

        /// <summary>
        /// Reevalido los campos
        /// </summary>
        private void Revalidar()
        {
            this.txtNombreZonaEditar_Validating(null, null);
            this.txtNumeroZonaEditar_Validating(null, null);
            this.txtCapacidadZonaEditar_Validating(null, null);
        }

        /// <summary>
        /// limpia campos del formulario.
        /// </summary>
        private void LimpiaCampos()
        {
            this.txtNombreZonaEditar.Text = "";
            this.txtNumeroZonaEditar.Text = "";
            this.txtCapacidadZonaEditar.Text = "";           
        }

    }
}
