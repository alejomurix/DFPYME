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

namespace Aplicacion.Administracion.Puc
{
    public partial class FrmPuc : Form
    {
        public bool Extend = false;

        private bool NoClaseMatch;

        private bool NoGrupoMatch;

        private bool NoCuentaMatch;

        private bool NoScuentaMatch;

        private ErrorProvider miError;

        private BussinesPuc miBussinesPuc;

        public FrmPuc()
        {
            this.NoClaseMatch = false;
            this.NoGrupoMatch = false;
            this.NoCuentaMatch = false;
            this.NoScuentaMatch = false;
            this.miError = new ErrorProvider();
            miBussinesPuc = new BussinesPuc();
            InitializeComponent();
        }

        private void FrmPuc_Load(object sender, EventArgs e)
        {
            //this.tcCuentasPuc.TabPages.Remove(tpClase);
            dgvCuentas.AutoGenerateColumns = false;
            CargarUtilidades();
            this.cbConsultaClase_SelectionChangeCommitted(this.cbConsultaClase, new EventArgs());
        }

        private void FrmPuc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.Escape))
            {
                this.Close();
            }
        }

        private void FrmPuc_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Extend)
            {
                CompletaEventos.CapturaEventoeb(false);
            }
        }

        private void tsSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsBtnSalirConsulta_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //

        private void txtNumeroClase_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(this.txtNumeroClase, miError, "El campo es requerido."))
            {
                if (Validacion.ConFormato(Validacion.TipoValidacion.Numeros, this.txtNumeroClase, miError,
                    "El número tiene formato incorrecto."))
                {
                    if (!ExisteClase(this.txtNumeroClase.Text))
                    {
                        miError.SetError(this.txtNumeroClase, null);
                        this.NoClaseMatch = true;
                    }
                    else
                    {
                        miError.SetError(this.txtNumeroClase, "El número ya tiene una Clase relacionada.");
                        this.NoClaseMatch = false;
                    }
                }
                else
                {
                    this.NoClaseMatch = false;
                }
            }
            else
            {
                this.NoClaseMatch = false;
            }
        }

        private void txtNumeroClase_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.txtNombreClase.Focus();
            }
        }

        private void txtNombreClase_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.txtNombreClase.Text = this.txtNombreClase.Text.ToUpper();
                this.btnGuardarClase_Click(this.btnGuardarClase, new EventArgs());
            }
        }

        //


        private void txtNumeroGrupo_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(this.txtNumeroGrupo, miError, "El campo es requerido."))
            {
                if (Validacion.ConFormato(Validacion.TipoValidacion.Numeros, this.txtNumeroGrupo, miError,
                    "El número tiene formato incorrecto."))
                {
                    if (!ExisteGrupo(this.txtNumeroGrupo.Text))
                    {
                        miError.SetError(this.txtNumeroGrupo, null);
                        this.NoGrupoMatch = true;
                    }
                    else
                    {
                        miError.SetError(this.txtNumeroGrupo, "El número ya tiene un Grupo relacionada.");
                        this.NoGrupoMatch = false;
                    }
                }
                else
                {
                    this.NoGrupoMatch = false;
                }
            }
            else
            {
                this.NoGrupoMatch = false;
            }
        }

        private void txtNumeroGrupo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.txtNombreGrupo.Focus();
            }
        }

        private void txtNombreGrupo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.txtNombreGrupo.Text = this.txtNombreGrupo.Text.ToUpper();
                this.btnGuardarGrupo_Click(this.btnGuardarGrupo, new EventArgs());
            }
        }

        //

        private void txtNumeroCuenta_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(this.txtNumeroCuenta, miError, "El campo es requerido."))
            {
                if (Validacion.ConFormato(Validacion.TipoValidacion.Numeros, this.txtNumeroCuenta, miError,
                    "El número tiene formato incorrecto."))
                {
                    if (!ExisteCuenta(this.txtNumeroCuenta.Text))
                    {
                        miError.SetError(this.txtNumeroCuenta, null);
                        this.NoCuentaMatch = true;
                    }
                    else
                    {
                        miError.SetError(this.txtNumeroCuenta, "El número ya tiene una Cuenta relacionada.");
                        this.NoCuentaMatch = false;
                    }
                }
                else
                {
                    this.NoCuentaMatch = false;
                }
            }
            else
            {
                this.NoCuentaMatch = false;
            }
        }

        private void txtNumeroCuenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.txtNombreCuenta.Focus();
            }
        }

        private void txtNombreCuenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.txtNombreCuenta.Text = this.txtNombreCuenta.Text.ToUpper();
                this.btnGuardarCuenta_Click(this.btnGuardarCuenta, new EventArgs());
            }
        }

        //

        private void txtNumeroScta_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(this.txtNumeroScta, miError, "El campo es requerido."))
            {
                if (Validacion.ConFormato(Validacion.TipoValidacion.Numeros, this.txtNumeroScta, miError,
                    "El número tiene formato incorrecto."))
                {
                    if (!ExisteSubCuenta(this.txtNumeroScta.Text))
                    {
                        miError.SetError(this.txtNumeroScta, null);
                        this.NoScuentaMatch = true;
                    }
                    else
                    {
                        miError.SetError(this.txtNumeroScta, "El número ya tiene una Sub-Cuenta relacionada.");
                        this.NoScuentaMatch = false;
                    }
                }
                else
                {
                    this.NoScuentaMatch = false;
                }
            }
            else
            {
                this.NoScuentaMatch = false;
            }
        }

        private void txtNumeroScta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.txtNombreScta.Focus();
            }
        }

        private void txtNombreScta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.txtNombreScta.Text = this.txtNombreScta.Text.ToUpper();
                this.btnGuardar_Click(this.btnGuardar, new EventArgs());
            }
        }

        //

        private void btnGuardarClase_Click(object sender, EventArgs e)
        {
            if (this.NoClaseMatch)
            {
                var clase = new ClasePuc();
                clase.Numero = txtNumeroClase.Text;
                clase.Nombre = this.txtNombreClase.Text.ToUpper();
                try
                {
                    miBussinesPuc.IngresarClase(clase);
                    OptionPane.MessageInformation("Los datos de la Clase Puc se guardarón con exito.");
                    txtNumeroClase.Text = "";
                    txtNombreClase.Text = "";
                    CargarUtilidades();
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void btnGuardarGrupo_Click(object sender, EventArgs e)
        {
            if (this.NoGrupoMatch)
            {
                var grupo = new GrupoPuc();
                grupo.IdClase = Convert.ToInt32(cbClases.SelectedValue);
                grupo.Numero = txtNumeroGrupo.Text;
                grupo.Nombre = txtNombreGrupo.Text.ToUpper();
                try
                {
                    miBussinesPuc.IngresarGrupo(grupo);
                    OptionPane.MessageInformation("Los datos del Grupo Puc se guardarón con exito.");
                    txtNumeroGrupo.Text = "";
                    txtNombreGrupo.Text = "";
                    CargarUtilidades();
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void btnGuardarCuenta_Click(object sender, EventArgs e)
        {
            if (NoCuentaMatch)
            {
                var cuenta = new CuentaPuc();
                cuenta.IdGrupo = Convert.ToInt32(cbGrupos.SelectedValue);
                cuenta.Numero = txtNumeroCuenta.Text;
                cuenta.Nombre = txtNombreCuenta.Text.ToUpper();
                try
                {
                    miBussinesPuc.IngresarCuenta(cuenta);
                    OptionPane.MessageInformation("Los datos de la Cuenta Puc se guardarón con exito.");
                    txtNumeroCuenta.Text = "";
                    txtNombreCuenta.Text = "";
                    CargarUtilidades();
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (this.NoScuentaMatch)
            {
                var sCuenta = new SubCuentaPuc();
                sCuenta.IdCuenta = Convert.ToInt32(cbCuentas.SelectedValue);
                sCuenta.Numero = txtNumeroScta.Text;
                sCuenta.Nombre = txtNombreScta.Text;
                try
                {
                    miBussinesPuc.IngresarSubCuenta(sCuenta);
                    OptionPane.MessageInformation("Los datos de la Sub-Cuenta se guardarón con exito.");
                    txtNumeroScta.Text = "";
                    txtNombreScta.Text = "";
                    CargarUtilidades();
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void cbClases_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                var g = miBussinesPuc.Clases(Convert.ToInt32(cbClases.SelectedValue));
                if (g.Rows.Count != 0)
                {
                    var gRow = (from data in g.AsEnumerable()
                                select data).Single();
                    txtNameClase.Text = gRow["nombre"].ToString();
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void cbClasesCta_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {//this.Debug();
                if (cbClasesCta.Items.Count != 0)
                {
                    var g = miBussinesPuc.Clases(Convert.ToInt32(cbClasesCta.SelectedValue));
                    if (g.Rows.Count != 0)
                    {
                        var gRow = (from data in g.AsEnumerable()
                                    select data).Single();
                        txtNameClaseC.Text = gRow["nombre"].ToString();
                    }

                    cbGrupos.DataSource =
                        miBussinesPuc.Grupos(Convert.ToInt32(cbClasesCta.SelectedValue));
                    if (cbGrupos.Items.Count != 0)
                    {
                        cbGrupos_SelectionChangeCommitted(this.cbGrupos, new EventArgs());
                    }
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void cbGrupos_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cbGrupos.Items.Count != 0)
                {
                    var g = miBussinesPuc.GrupoId(Convert.ToInt32(cbGrupos.SelectedValue));
                    if (g.Rows.Count != 0)
                    {
                        var gRow = (from data in g.AsEnumerable()
                                    select data).Single();
                        txtNameGrupo.Text = gRow["nombre"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void cbClasesScta_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cbClasesScta.Items.Count != 0)
                {
                    cbGruposScta.DataSource =
                        miBussinesPuc.Grupos(Convert.ToInt32(cbClasesScta.SelectedValue));
                    if (cbGruposScta.Items.Count != 0)
                    {
                        cbCuentas.DataSource =
                            miBussinesPuc.Cuentas(Convert.ToInt32(cbGruposScta.SelectedValue));
                    }
                    var g = miBussinesPuc.Clases(Convert.ToInt32(cbClasesScta.SelectedValue));
                    if (g.Rows.Count != 0)
                    {
                        var gRow = (from data in g.AsEnumerable()
                                    select data).Single();
                        txtNameClaseS.Text = gRow["nombre"].ToString();
                    }

                    if (cbGruposScta.Items.Count != 0)
                    {
                        cbGruposScta_SelectionChangeCommitted(this.cbGruposScta, new EventArgs());
                    }

                    if (cbCuentas.Items.Count != 0)
                    {
                        cbCuentas_SelectionChangeCommitted(this.cbCuentas, new EventArgs());
                    }
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void cbGruposScta_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbGruposScta.Items.Count != 0)
            {
                cbCuentas.DataSource =
                    miBussinesPuc.Cuentas(Convert.ToInt32(cbGruposScta.SelectedValue));
                var g = miBussinesPuc.GrupoId(Convert.ToInt32(cbGruposScta.SelectedValue));
                if (g.Rows.Count != 0)
                {
                    var gRow = (from data in g.AsEnumerable()
                                select data).Single();
                    txtNameGrupoS.Text = gRow["nombre"].ToString();
                }

                if (cbCuentas.Items.Count != 0)
                {
                    cbCuentas_SelectionChangeCommitted(this.cbCuentas, new EventArgs());
                }
            }
        }

        private void cbCuentas_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbCuentas.Items.Count != 0)
            {
                var sC = miBussinesPuc.Cuenta(Convert.ToInt32(cbCuentas.SelectedValue));
                if (sC.Rows.Count != 0)
                {
                    var cRow = (from data in sC.AsEnumerable()
                                select data).Single();
                    txtNameCuentaS.Text = cRow["nombre"].ToString();
                }
            }
        }

        private void cbConsultaClase_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbConsultaClase.Items.Count != 0)
            {
                try
                {
                    var cls = miBussinesPuc.Clases(Convert.ToInt32(this.cbConsultaClase.SelectedValue));
                    if (cls.Rows.Count != 0)
                    {
                        var cRow = (from data in cls.AsEnumerable()
                                    select data).Single();
                        this.txtClaseConsulta.Text = cRow["nombre"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
                CargarGridView(Convert.ToInt32(cbConsultaClase.SelectedValue));
            }
        }

        private void dgvCuentas_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvCuentas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Extend)
            {
                if (dgvCuentas.RowCount != 0)
                {
                    var cuenta = new SubCuentaPuc();
                    cuenta.IdCuenta = Convert.ToInt32(dgvCuentas.CurrentRow.Cells["Id"].Value);
                    cuenta.Numero = dgvCuentas.CurrentRow.Cells["Numero"].Value.ToString();
                    CompletaEventos.CapturaEventoeb(cuenta);
                    this.Close();
                }
            }
        }

        private void CargarUtilidades()
        {
            try
            {
                //var clases = miBussinesPuc.Clases();

                cbClases.DataSource = miBussinesPuc.Clases();

                cbClasesCta.DataSource = miBussinesPuc.Clases();
                if (cbClasesCta.Items.Count != 0)
                {
                    cbGrupos.DataSource =
                        miBussinesPuc.Grupos(Convert.ToInt32(cbClasesCta.SelectedValue));
                }

                cbClasesScta.DataSource = miBussinesPuc.Clases();
                if (cbClasesScta.Items.Count != 0)
                {
                    cbGruposScta.DataSource =
                        miBussinesPuc.Grupos(Convert.ToInt32(cbClasesScta.SelectedValue));
                    if (cbGruposScta.Items.Count != 0)
                    {
                        cbCuentas.DataSource =
                            miBussinesPuc.Cuentas(Convert.ToInt32(cbGruposScta.SelectedValue));
                    }
                }

                cbConsultaClase.DataSource = miBussinesPuc.Clases();
                if (cbConsultaClase.Items.Count != 0)
                {
                    CargarGridView(Convert.ToInt32(cbConsultaClase.SelectedValue));
                }

                if (cbClases.Items.Count != 0)
                {
                    this.cbClases_SelectionChangeCommitted(this.cbClases, new EventArgs());
                }

                if (cbClasesCta.Items.Count != 0)
                {
                    this.cbClasesCta_SelectionChangeCommitted(this.cbClasesCta, new EventArgs());
                }

                if (cbGrupos.Items.Count != 0)
                {
                    this.cbGrupos_SelectionChangeCommitted(this.cbGrupos, new EventArgs());
                }

                if (cbClasesScta.Items.Count != 0)
                {
                    cbClasesScta_SelectionChangeCommitted(this.cbClasesScta, new EventArgs());
                }

                if (cbGruposScta.Items.Count != 0)
                {
                    cbGruposScta_SelectionChangeCommitted(this.cbGruposScta, new EventArgs());
                }

                if (cbCuentas.Items.Count != 0)
                {
                    cbCuentas_SelectionChangeCommitted(this.cbCuentas, new EventArgs());
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void CargarGridView(int idClase)
        {
            try
            {
                dgvCuentas.DataSource = miBussinesPuc.CuentasDelPuc(idClase);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void cbClasesCta_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private bool ValidarNumero(string numero)
        {
            try
            {
                Convert.ToInt32(numero);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool ExisteClase(string numero)
        {
            try
            {
                return miBussinesPuc.ExisteClase(numero);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
                return false;
            }
        }

        private bool ExisteGrupo(string numero)
        {
            try
            {
                return miBussinesPuc.ExisteGrupo(numero);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
                return false;
            }
        }

        private bool ExisteCuenta(string numero)
        {
            try
            {
                return miBussinesPuc.ExisteCuenta(numero);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
                return false;
            }
        }

        private bool ExisteSubCuenta(string numero)
        {
            try
            {
                return miBussinesPuc.ExisteSubCuenta(numero);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
                return false;
            }
        }
    }
}