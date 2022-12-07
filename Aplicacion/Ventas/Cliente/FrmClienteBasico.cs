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

namespace Aplicacion.Ventas.Cliente
{
    public partial class FrmClienteBasico : Form
    {
        #region Logica de Negocio

        private BussinesDepartamento miBussinesDepto;

        private BussinesCiudad miBussinesCiudad;

        private BussinesCliente miBussinesCliente;

        #endregion

        #region Validación

        private bool ClienteMatch = false;

        private bool AceptarMatch = false;

        private ErrorProvider miError;

        private bool NitMatch = false;

        private bool NameMatch = false;

        private bool CelMatch = false;

        private string NitReq = "El campo Nit o C.C. es requerido.";

        private string NitFormato = "El Nit o C.C. que ingreso es inválido.";

        private string NameReq = "El campo Nombres es requerido.";

        private string NameFormato = "El Nombre que ingreso es inválido.";

        private string CelReq = "El campo Celular es requerido.";

        private string CelFormato = "El Celular que ingreso es inválido.";

        #endregion

        public FrmClienteBasico()
        {
            InitializeComponent();
            miError = new ErrorProvider();
            miBussinesDepto = new BussinesDepartamento();
            miBussinesCiudad = new BussinesCiudad();
            miBussinesCliente = new BussinesCliente();
        }

        private void FrmClienteBasico_Load(object sender, EventArgs e)
        {
            CargarDepartamentos();
        }

        private void FrmClienteBasico_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.Escape))
            {
                this.Close();
            }
        }

        private void tsBtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmClienteBasico_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!AceptarMatch)
            {
                DialogResult rta = MessageBox.Show("Está a punto de salir.\n¿Desea guardar los cambios?", "Cliente",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (rta.Equals(DialogResult.Yes))
                {
                    btnAceptar_Click(this.btnAceptar, new EventArgs());
                }
                else
                {
                    if (rta.Equals(DialogResult.Cancel))
                    {
                        e.Cancel = true;
                    }
                }
            }
            CompletaEventos.CapturaEventobo(false);
        }

        private void txtNit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                txtNombres.Focus();
            }
        }

        private void txtNit_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(txtNit, miError, NitReq))
            {
                if (Validacion.ConFormato(Validacion.TipoValidacion.NumeroGuion,
                    txtNit, miError, NitFormato))
                {
                    if (!txtNit.Text.Equals("1000"))
                    {
                        try
                        {
                            var cliente = miBussinesCliente.ClienteAEditar(txtNit.Text);
                            if (!String.IsNullOrEmpty(cliente.NitCliente))
                            {
                                ClienteExiste(cliente);
                                btnAceptar.Focus();
                            }
                            else
                            {
                                ClienteMatch = false;
                                //txtNombres.Focus();
                            }
                        }
                        catch (Exception ex)
                        {
                            ClienteMatch = false;
                            OptionPane.MessageError(ex.Message);
                        }
                        NitMatch = true;
                    }
                    else
                    {
                        NitMatch = false;
                        OptionPane.MessageError("El cliente a ingresar no puede ser el Cliente General.");
                        miError.SetError(txtNit, "El cliente a ingresar no puede ser el Cliente General.");
                    }
                }
                else
                {
                    NitMatch = false;
                }
            }
            else
            {
                NitMatch = false;
            }
        }

        private void txtNombres_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                txtCelular.Focus();
            }
        }

        private void txtNombres_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(txtNombres, miError, NameReq))
            {
                if (Validacion.ConFormato(Validacion.TipoValidacion.Palabras,
                    txtNombres, miError, NameFormato))
                {
                    NameMatch = true;
                }
                else
                {
                    NameMatch = false;
                }
            }
            else
            {
                NameMatch = false;
            }
        }

        private void txtCelular_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                cbDepto.Focus();
            }
        }

        private void txtCelular_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(txtCelular, miError, CelReq))
            {
                if (Validacion.ConFormato(Validacion.TipoValidacion.NumeroEspacio,
                    txtCelular, miError, CelFormato))
                {
                    CelMatch = true;
                }
                else
                {
                    CelMatch = false;
                }
            }
            else
            {
                CelMatch = false;
            }
        }

        private void cbDepto_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int idDepartamento = Convert.ToInt32(this.cbDepto.SelectedValue);
            CargarCiudades(idDepartamento);
        }

        private void cbDepto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                cbCiudad.Focus();
            }
        }

        private void cbCiudad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                btnAceptar.Focus();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ClienteMatch)
            {
                CompletaEventos.CapturaEventobo(txtNit.Text);
                AceptarMatch = true;
                this.Close();
            }
            else
            {
                Validar();
                if (NitMatch && NameMatch && CelMatch)
                {
                    DialogResult rta = MessageBox.Show("¿Está seguro(a) de guardar el Cliente?", "Cliente",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (rta.Equals(DialogResult.Yes))
                    {
                        var cliente_ = new DTO.Clases.Cliente();
                        cliente_.NitCliente = txtNit.Text;
                        cliente_.NombresCliente = txtNombres.Text;
                        cliente_.CelularCliente = txtCelular.Text;
                        cliente_.IdDepartamento = Convert.ToInt32(cbDepto.SelectedValue);
                        cliente_.IdCiudad = Convert.ToInt32(cbCiudad.SelectedValue);
                        try
                        {
                            miBussinesCliente.InsertarCliente(cliente_);
                            OptionPane.MessageInformation("Los datos del cliente se ingresaron con éxito.");
                            AceptarMatch = true;
                            CompletaEventos.CapturaEventobo(txtNit.Text);
                            this.Close();
                        }
                        catch (Exception ex)
                        {
                            OptionPane.MessageError(ex.Message);
                        }
                    }
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //if (ClienteMatch)
            //{
                txtNit.Enabled = true;
                txtNombres.Enabled = true;
                txtCelular.Enabled = true;
                cbDepto.Enabled = true;
                cbCiudad.Enabled = true;
                ClienteMatch = false;
                txtNit.Focus();
                txtNit.Text = "";
                txtNombres.Text = "";
                txtCelular.Text = "";
            //}
        }



        /// <summary>
        /// Cargar los departamentos de Colombia
        /// </summary>
        private void CargarDepartamentos()
        {
            try
            {
                cbDepto.DataSource = miBussinesDepto.ListadoDepartamentos();
                if (cbDepto.Items.Count != 0)
                {
                    cbDepto.SelectedValue = 751;
                    int idDepartamento = Convert.ToInt32(cbDepto.SelectedValue);
                    CargarCiudades(idDepartamento);
                    cbCiudad.SelectedValue = 319;
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

        /// <summary>
        /// Cargar las ciudades segun el Departamento.
        /// </summary>
        /// <param name="idDepartamento">Id del departamento al cual cargar las ciudades.</param>
        private void CargarCiudades(int idDepartamento)
        {
            try
            {
                cbCiudad.DataSource = 
                    miBussinesCiudad.ListaCiudadPorDepartamento(idDepartamento);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Establece los valores necesarios cuando el cliente ingresado ya existe.
        /// </summary>
        /// <param name="cliente">Cliente que establece los valores.</param>
        private void ClienteExiste(DTO.Clases.Cliente cliente)
        {
            txtNombres.Text = cliente.NombresCliente;
            txtCelular.Text = cliente.CelularCliente;
            cbDepto.SelectedValue = cliente.IdDepartamento;
            CargarCiudades(cliente.IdDepartamento);
            cbCiudad.SelectedValue = cliente.IdCiudad;
            txtNit.Enabled = false;
            txtNombres.Enabled = false;
            txtCelular.Enabled = false;
            cbDepto.Enabled = false;
            cbCiudad.Enabled = false;
            ClienteMatch = true;
        }

        /// <summary>
        /// Valida los campos de datos del formulario.
        /// </summary>
        private void Validar()
        {
            txtNit_Validating(this.txtNit, new CancelEventArgs(false));
            txtNombres_Validating(this.txtNombres, new CancelEventArgs(false));
            txtCelular_Validating(this.txtCelular, new CancelEventArgs(false));
        }
    }
}