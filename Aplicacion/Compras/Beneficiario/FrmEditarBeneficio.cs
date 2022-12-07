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

namespace Aplicacion.Compras.Beneficiario
{
    public partial class FrmEditarBeneficio : Form
    {
        public Cliente Tercero { set; get; }

        private string NitActual { set; get; }

        private BussinesRegimen miBussinesRegimen;

        private BussinesEmpresa miBussinesEmpresa;

        private BussinesCiudad miBussinesCiudad;

        private BussinesBeneficio miBussinesBeneficio;

        private ErrorProvider miError;

        private bool IdMatch = false;

        private bool NombreMatch = false;

        private bool TelefonoMatch = false;

        public FrmEditarBeneficio()
        {
            InitializeComponent();
            miBussinesRegimen = new BussinesRegimen();
            miBussinesEmpresa = new BussinesEmpresa();
            miBussinesCiudad = new BussinesCiudad();
            miBussinesBeneficio = new BussinesBeneficio();
            miError = new ErrorProvider();
        }

        private void FrmEditarBeneficio_Load(object sender, EventArgs e)
        {
            CargarUtilidades();
        }

        private void FrmEditarBeneficio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.F2))
            {
                this.tsGuardar_Click(this.tsGuardar, new EventArgs());
            }
            else
            {
                if (e.KeyData.Equals(Keys.Escape))
                {
                    this.Close();
                }
            }
        }

        private void FrmBeneficio_FormClosing(object sender, FormClosingEventArgs e)
        {
            CompletaEventos.CapturaEventoz(false);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsGuardar_Click(object sender, EventArgs e)
        {
            txtId_Validating(this.txtId, new CancelEventArgs(false));
            txtNombre_Validating(this.txtNombre, new CancelEventArgs(false));
            txtTelefono_Validating(this.txtTelefono, new CancelEventArgs(false));
            if (IdMatch && NombreMatch && TelefonoMatch)
            {
                try
                {
                    var cliente = new Cliente
                    {
                        IdTipoCliente = Tercero.IdTipoCliente,
                        IdRegimen = Convert.ToInt32(cbTipo.SelectedValue),
                        NitCliente = txtId.Text,
                        NombresCliente = txtNombre.Text,
                        TelefonoCliente = txtTelefono.Text,
                        CelularCliente = txtCelular.Text,
                        IdCiudad = Convert.ToInt32(cbCiudad.SelectedValue),
                        DireccionCliente = txtDireccion.Text
                    };
                    miBussinesBeneficio.EditarBeneficiario(cliente);
                    OptionPane.MessageInformation("Los datos se editarón correctamente.");
                    CompletaEventos.CapturaEvento(new ObjectAbstract { Id = 1, Objeto = null });
                    //miBussinesBeneficio.Ingresar(cliente);
                    /*OptionPane.MessageInformation("Los datos se almacenarón correctamente.");
                    txtId.Text = "";
                    txtNombre.Text = "";
                    txtTelefono.Text = "";*/
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void txtId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                txtNombre.Focus();
            }
        }

        private void txtId_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(txtId, miError, "El Campo C.C. o NIT es requerido."))
            {
                if (Validacion.ConFormato(Validacion.TipoValidacion.NumeroGuion, txtId,
                    miError, "La C.C. o NIT son incorrectos."))
                {
                    if (Existe(txtId.Text) && NitActual != txtId.Text)
                    {
                        miError.SetError(txtId, "El nit que ingreso ya se encuentra registrado.");
                        IdMatch = false;
                    }
                    else
                    {
                        miError.SetError(txtId, null);
                        IdMatch = true;
                    }
                }
                else
                {
                    IdMatch = false;
                }
            }
            else
            {
                IdMatch = false;
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                txtTelefono.Focus();
            }
        }

        private void txtNombre_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(txtNombre, miError, "El Campo Nombre es requerido."))
            {
                if (Validacion.ConFormato(Validacion.TipoValidacion.Palabras, txtNombre,
                    miError, "El Nombre son incorrectos."))
                {
                    NombreMatch = true;
                }
                else
                {
                    NombreMatch = false;
                }
            }
            else
            {
                NombreMatch = false;
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                txtId.Focus();
            }
        }

        private void txtTelefono_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtTelefono.Text))
            {
                if (Validacion.ConFormato(Validacion.TipoValidacion.NumeroEspacio, txtTelefono,
                    miError, "El Telefono es incorrecto."))
                {
                    TelefonoMatch = true;
                }
                else
                {
                    TelefonoMatch = false;
                }
            }
            else
            {
                TelefonoMatch = true;
            }
        }

        private void CargarUtilidades()
        {
            try
            {
                this.cbTipo.DataSource = miBussinesRegimen.ListadoRegimen();
                this.cbCiudad.DataSource =
                    miBussinesCiudad.ListaCiudadPorDepartamento(miBussinesEmpresa.ObtenerEmpresa().Departamento.IdDepartamento);

                this.cbTipo.SelectedValue = Tercero.IdRegimen;
                this.NitActual = txtId.Text = Tercero.NitCliente;
                this.txtNombre.Text = Tercero.NombresCliente;
                this.txtTelefono.Text = Tercero.TelefonoCliente;
                this.txtCelular.Text = Tercero.CelularCliente;
                this.cbCiudad.SelectedValue = Tercero.IdCiudad;
                this.txtDireccion.Text = Tercero.DireccionCliente;
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private bool Existe(string nit)
        {
            try
            {
                return miBussinesBeneficio.Existe(nit);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
                return false;
            }
        }
    }
}