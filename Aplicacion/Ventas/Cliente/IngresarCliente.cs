using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Aplicacion.Clases;
using BussinesLayer.Clases;

namespace Aplicacion.Ventas.Cliente
{
    public partial class IngresarCliente : Form
    {
        #region Atributos de Validacion

        private Validacion miValidacion = new Validacion(); 
        private ErrorProvider miError = new ErrorProvider();
        private bool guardar = true;


        #endregion

        #region Atributos De Logica de Negocio

        /// <summary>
        /// Representa la logica de negocios del Cliente
        /// </summary>
        private BussinesCliente miBussinesCliente;

        private BussinesRegimen miBussinesRegimen;
        private BussinesDepartamento miBussinesDepartamento;
        private BussinesCiudad miBussinesCiudad;

        #endregion

        #region Atributos de Filtrado

        /// <summary>
        /// Contruye el origen de datos.
        /// </summary>
        private BindingSource miBindingSource;

        /// <summary>
        /// Declara el parametro de coincidencia.
        /// </summary>
        private const string like = "Like '{0}%'";

        /// <summary>
        /// Representa la columna Nit o Cedula de la tabla cliente
        /// </summary>
        private const string columnaCedula = "[nitcliente]";

        /// <summary>
        /// Representa la columna Nombres de la tabla cliente
        /// </summary>
        private const string columnaNombre = "[nombrescliente]";

        /// <summary>
        /// Represeta el filtro para los datos en la tabla cliente.
        /// </summary>
        private string filtro;

        #endregion

        #region Constantes de Mensajes

        private const string msgCampoVacio = "El Campo {0} es Requerido";

        private const string campoBusqueda = " de Busqueda";

        #endregion

        public IngresarCliente()
        {
            InitializeComponent();
        }

        private void IngresarCliente_Load(object sender, EventArgs e)
        {
            CargarRegimen();
            CargarDepartamentos();
            this.dgvListado1.AutoGenerateColumns = false;
            this.dgvListado1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void cbDepartamentos_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int idDepartamento = Convert.ToInt32(this.cbDepartamentos.SelectedValue);
            CargarCiudades(idDepartamento);
        }

        private void tsBtnGuardar_Click(object sender, EventArgs e)
        {
            
        }

        private void tsBtnListarTodos_Click(object sender, EventArgs e)
        {
            this.dgvListado1.DataSource = null;
            this.dgvListado1.DataSource = DataTableClientes();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FiltrarCliente();
        }

        private void FiltrarCliente()
        {
            if (this.txtParametro.Text != "")
            {
                if (rbtnConsultaCedula.Checked)
                {
                    FiltrarClientePorCedula(txtParametro.Text);
                }
                if (rbtnConsultaNombre.Checked)
                {
                    FiltrarClientePorNombre(txtParametro.Text);
                }
            }
            else
            {
                this.dgvListado1.DataSource = null;
                MessageBox.Show(String.Format(msgCampoVacio, campoBusqueda));
            }
        }

        private void CargarRegimen()
        {
            try
            {
                miBussinesRegimen = new BussinesRegimen();
                cbRegimen.DataSource = miBussinesRegimen.ListadoRegimen();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CargarDepartamentos()
        {
            
            try
            {
                miBussinesDepartamento = new BussinesDepartamento();
                cbDepartamentos.DataSource = miBussinesDepartamento.ListadoDepartamentos();
                if (cbDepartamentos.Items.Count != 0)
                {
                    int idDepartamento = Convert.ToInt32(cbDepartamentos.SelectedValue);
                    CargarCiudades(idDepartamento);
                }
                else
                {
                    cbCiudad.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CargarCiudades(int idDepartamento)
        {
            try
            {
                miBussinesCiudad = new BussinesCiudad();
                cbCiudad.DataSource = miBussinesCiudad.ListaCiudadPorDepartamento(idDepartamento);

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Obtiene el listado de clientes en un DataTable
        /// </summary>
        /// <returns></returns>
        private DataTable DataTableClientes()
        {
            try
            {
                miBussinesCliente = new BussinesCliente();
                return miBussinesCliente.ListadoDeClientes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Filtra una consulta y carga el DataGridView
        /// </summary>
        /// <param name="cedula">Cedula a buscar</param>
        private void FiltrarClientePorCedula(string cedula) 
        {
            try
            {
                miBussinesCliente = new BussinesCliente();
                this.dgvListado1.DataSource = null;
                this.dgvListado1.DataSource = miBussinesCliente.FiltroClienteCedula(cedula.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Filtra una consulta por nombre Cliente y carga el DataGridView
        /// </summary>
        /// <param name="nombre">Nombre a buscar</param>
        private void FiltrarClientePorNombre(string nombre) 
        {
            try
            {
                miBussinesCliente = new BussinesCliente();
                this.dgvListado1.DataSource = null;
                this.dgvListado1.DataSource = miBussinesCliente.FiltroClienteNombre(nombre.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ValidarCamposVacios(object sender , CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtNit.Text))
            {
                miError.SetError(this.txtNit, "El campo cedula es requerido");
                
            }
            else
            {
                miError.SetError(this.txtNit, "");
            }
        }

        private void txtParametro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                FiltrarCliente();
            }
        }

        

    }
}