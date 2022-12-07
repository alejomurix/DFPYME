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
    public partial class FrmBeneficio : Form
    {
        public bool Search = false;

        public bool Add = false;

        private BussinesEmpresa miBussinesEmpresa;

        private BussinesRegimen miBussinesRegimen;

        private BussinesCiudad miBussinesCiudad;

        private BussinesBeneficio miBussinesBeneficio;

        private ErrorProvider miError;

        private bool IdMatch = false;

        private bool NombreMatch = false;

        private bool TelefonoMatch = false;

        public bool Edit;

        public FrmBeneficio()
        {
            InitializeComponent();
            this.Edit = false;
            miBussinesEmpresa = new BussinesEmpresa();
            miBussinesRegimen = new BussinesRegimen();
            miBussinesCiudad = new BussinesCiudad();
            miBussinesBeneficio = new BussinesBeneficio();
            miError = new ErrorProvider();
        }

        private void FrmBeneficio_Load(object sender, EventArgs e)
        {
            dgBeneficiarios.AutoGenerateColumns = false;
            CargarUtilidades();
            if (Search)
            {
                cbCriterio.SelectedValue = 2;
                btnBuscar_Click(this.btnBuscar, new EventArgs());
            }
            else
            {
                btnBuscar_Click(this.btnBuscar, new EventArgs());
            }
            CompletaEventos.Completa += new CompletaEventos.CompletaAccion(CompletaEventos_Completa);
        }

        private void FrmBeneficio_KeyDown(object sender, KeyEventArgs e)
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
                    DialogResult rta = MessageBox.Show("¿Está seguro de crear el tercero?", "Tercero",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (rta.Equals(DialogResult.Yes))
                    {
                        var cliente = new Cliente
                        {
                            IdRegimen = Convert.ToInt32(cbTipo.SelectedValue),
                            NitCliente = txtId.Text,
                            NombresCliente = txtNombre.Text,
                            TelefonoCliente = txtTelefono.Text,
                            CelularCliente = txtCelular.Text,
                            IdCiudad = Convert.ToInt32(cbCiudad.SelectedValue),
                            DireccionCliente = txtDireccion.Text
                        };
                        miBussinesBeneficio.Ingresar(cliente);

                        var miBussinesCliente = new BussinesCliente();
                        miBussinesCliente.InsertarCliente(new Cliente
                        {
                            IdRegimen = Convert.ToInt32(cbTipo.SelectedValue),
                            NitCliente = txtId.Text,
                            NombresCliente = txtNombre.Text,
                            TelefonoCliente = txtTelefono.Text,
                            CelularCliente = txtCelular.Text,
                            IdCiudad = Convert.ToInt32(cbCiudad.SelectedValue),
                            DireccionCliente = txtDireccion.Text
                        });

                        var miBussinesProveedor = new BussinesProveedor();
                        miBussinesProveedor.InsertarProveedor(new DTO.Clases.Proveedor
                        {
                            CodigoInternoProveedor = miBussinesProveedor.ObtenerCodigoConsecutivo(),
                            NitProveedor = this.txtId.Text,
                            IdRegimen = Convert.ToInt32(this.cbTipo.SelectedValue),
                            RazonSocialProveedor = this.txtNombre.Text,
                            NombreComercialProveedor = this.txtNombre.Text,
                            CelularProveedor = this.txtCelular.Text,
                            IdCiudad = Convert.ToInt32(this.cbCiudad.SelectedValue),
                            DireccionProveedor = this.txtDireccion.Text
                        });

                        this.txtId.Focus();
                        OptionPane.MessageInformation("Los datos se almacenarón correctamente.");
                        txtId.Text = "";
                        txtNombre.Text = "";
                        txtTelefono.Text = "";
                        txtCelular.Text = "";
                        txtDireccion.Text = "";
                        if (Add)
                        {
                            CompletaEventos.CapturaEventoz(cliente);
                            this.Close();
                        }
                    }
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
                    if (!Existe(txtId.Text))
                    {
                        miError.SetError(txtId, null);
                        IdMatch = true;
                    }
                    else
                    {
                        miError.SetError(txtId, "El nit que ingreso ya se encuentra registrado.");
                        IdMatch = false;
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
                this.txtNombre.Text = this.txtNombre.Text.ToUpper();
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
                txtCelular.Focus();
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

        private void txtCelular_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                cbCiudad.Focus();
            }
        }

        private void cbCiudad_Enter(object sender, EventArgs e)
        {
            cbCiudad.DroppedDown = true;
        }

        private void cbCiudad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                txtDireccion.Focus();
            }
        }

        private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.tsGuardar_Click(this.tsGuardar, new EventArgs());
            }
        }

        // Consultas.

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgBeneficiarios.RowCount != 0)
            {
                try
                {
                    var frmEditar = new FrmEditarBeneficio();
                    frmEditar.Tercero = miBussinesBeneficio.BeneficiarioId
                        (Convert.ToInt32(dgBeneficiarios.CurrentRow.Cells["Id"].Value));
                    frmEditar.ShowDialog();
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void txtConsulta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                btnBuscar_Click(this.btnBuscar, new EventArgs());
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                this.dgBeneficiarios.DataSource = this.miBussinesBeneficio.BeneficiariosT(this.txtConsulta.Text);
                if (this.dgBeneficiarios.RowCount.Equals(0))
                {
                    OptionPane.MessageInformation("No se encontraron datos con ese Nombre.");
                }
               /* if (Convert.ToInt32(cbCriterio.SelectedValue).Equals(1))
                {
                    dgBeneficiarios.DataSource =
                        miBussinesBeneficio.BeneficiariosNombre(txtConsulta.Text);
                    if (dgBeneficiarios.RowCount.Equals(0))
                    {
                        OptionPane.MessageInformation("No se encontraron datos con ese Nombre.");
                    }
                }
                else
                {
                    dgBeneficiarios.DataSource =
                        miBussinesBeneficio.BeneficiariosNit(txtConsulta.Text);
                    if (dgBeneficiarios.RowCount.Equals(0))
                    {
                        OptionPane.MessageInformation("No se encontraron datos con ese NIT.");
                    }
                }*/
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void dgBeneficiarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgBeneficiarios.RowCount != 0)
            {
                var beneficio = new DTO.Clases.Cliente
                {
                    IdCiudad = Convert.ToInt32(dgBeneficiarios.CurrentRow.Cells["Id"].Value),
                    IdRegimen = Convert.ToInt32(dgBeneficiarios.CurrentRow.Cells["IdRegimen"].Value),
                    NitCliente = dgBeneficiarios.CurrentRow.Cells["Nit"].Value.ToString(),
                    NombresCliente = dgBeneficiarios.CurrentRow.Cells["Nombre"].Value.ToString()
                };
                if (Edit)
                {
                    CompletaEventos.CapturaEvento(new ObjectAbstract
                    {
                        Id = 125,
                        Objeto = beneficio
                    });
                }
                else
                {
                    CompletaEventos.CapturaEventoz(beneficio);
                }
                this.Close();
            }
            else
            {
                OptionPane.MessageInformation("No hay registros para cargar.");
            }
        }

        private void CargarUtilidades()
        {
            try
            {
                cbTipo.DataSource = miBussinesRegimen.ListadoRegimen();
                cbTipo.SelectedValue = 2;
                this.cbCiudad.DataSource = 
                    miBussinesCiudad.ListaCiudadPorDepartamento(miBussinesEmpresa.ObtenerEmpresa().Departamento.IdDepartamento);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }

            var lst = new List<Inventario.Producto.Criterio>();
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 1,
                Nombre = "Nombre"
            });
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 2,
                Nombre = "C.C. o NIT"
            });
            cbCriterio.DataSource = lst;
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

        void CompletaEventos_Completa(CompletaArgumentosDeEvento args)
        {
            try
            {
                var obj = (ObjectAbstract)args.MiObjeto;
                if (obj.Id.Equals(1))
                {
                    this.btnBuscar_Click(this.btnBuscar, new EventArgs());
                }
            }
            catch { }
        }
    }
}