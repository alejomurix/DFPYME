using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Aplicacion.Compras.Proveedor;
using DTO.Clases;
using BussinesLayer.Clases;
using Utilities;
using Aplicacion.Configuracion.CuentaBancaria;
using CustomControl;


namespace Aplicacion.Configuracion.Empresa
{
    public partial class frmEmpresa : Form
    {
        /// <summary>
        /// Define los atributos de logica necesaria para las tranzaciones de Proveedor
        /// </summary>

        // #region Atributos de Logica de Negocio


        private DTO.Clases.Empresa miEmpresa;
        private BussinesRegimen miBussinesRegimen;
        private BussinesDepartamento miBussinesDepto;
        private BussinesCiudad miBussinesCiudad;
        private BussinesEmpresa miBussinesEmpresa;
        private BussinesCuenta miBussinesCuenta;
        private frmCuentaBancaria formCuentaBanco;
        private TransferenciaCuenta miTransferenciaCuenta;
        private BindingList<Cuenta> listaCuenta = new BindingList<Cuenta>();
        private BindingSource miBindisourse = new BindingSource();
        private string nit;
        private int idRegimen;
        private int idCiudad;
        private int idDepto;

        public bool Extension = false;
        private bool Guardar = false,
        nitMath = false,
        razonMath = true,
        nombreMath = true,
        descripcionMath = false,       
        telefonoMath = false,
        celularMath = false,       
        faxMath = false,
        direccionMath = false,
        emailMath = false,
        representanteMatch = false,
        webMath = false;
        private bool existeNit = false;

        bool editar = false;

        /// <summary>
        /// Representa un objeto para mensajes de error en los formularios.
        /// </summary>
        private ErrorProvider miError = new ErrorProvider();

        /// <summary>
        /// Representa un objeto para validacion de datos.
        /// </summary>
        private Validacion miValidacion = new Validacion();

        /// <summary>
        /// Establece el valor que indica que el usuario presiono el boton Salir
        /// </summary>
        private bool salir = false;

        /// <summary>
        /// Obtiene o establece la condición que indica si se trata de una edición en otro from.
        /// </summary>
        public bool Edit = false;

        /// <summary>
        /// Esablece el valor que indica si es una adicion de cuenta bancaria
        /// </summary>
        private bool adicionCuenta = false;

        #region Atributos constantes

        /// <summary>
        /// Representa un mensaje de Campo Requerido o Incorrecto.
        /// </summary>
        private const string codigoRequerido = "El campo Codigo es Requerido.",

        codigoIncorrecto = "El Codigo tiene formato Incorrecto.",

        nitRequerido = "El campo Nit o Cedula es Requerido.",

        nitIncorrecto = "El Nit o Cedula tiene formato Incorrecto.",

        nombreRequerido = "El campo Nombre es Requerido.",

        nombreIncorrecto = "El Nombre tiene formato Incorrecto.",

        razonRequerida = "El campo Razon Social es Requerido.",

        razonIncorrecto = "La Razon Social tiene formato Incorrecto.",

        nombreComercial="El campo nombre comercial es requerido",

        nComercialIncorrecto = "El nombre Comercial tiene formato Incorrecto.",

        descripcionIncorrecto = "La descripcion tiene formato Incorrecto.",

        telefonoIncorrecto = "El telefono tiene formato Incorrecto.",

        telefonoRequerido = "Debe ingresar un Numero de Telefono.",

        celularRequerido = "El campo Celular es Requerido.",

        celularIncorrecto = "El Celular tiene Formato Incorrecto.",

        faxIncorrecto = "El número de Fax tiene formato Incorrecto.",

        faxRequerido = "El numero de Fax es Requerido.",

        direccionRequerida = "El campo Direccion es Requerido.",

        direccionIncorrecta = "La Direccion tiene formato Incorrecto.",

        emailIncorrecto = "El Email tiene formato Incorrecto.",

        webIncorrecto = "La Pagina Web tiene formato Incorrecto.",

        noRegistros = "No hay registros para editar.",

        representanteRequerido = "El campo Representante legal es requerido.",

        representanteIncorrecto = "El campo de representante legal es incorrecto.";

        private const string msnSalir = "¿Desea guardar los cambios?";

        #endregion

        public frmEmpresa()
        {
            InitializeComponent();
            miBussinesEmpresa = new BussinesEmpresa();
        }

        private void frmCrearProveedor_Load(object sender, EventArgs e)
        {
            dgvDatosBancario.DataSource = miBindisourse;
            CargarRegimen();
            CargarDepartamentos();
            CompletaEventos.Completa += new CompletaEventos.CompletaAccion(CompletaEventos_Completo);
            CargaEmpresa();
        }

        private void tsbtnGuardar_Click(object sender, EventArgs e)
        {
            miBussinesEmpresa = new BussinesEmpresa();
            try
            {
                ValidacionParaGuardar();

                if (!existeNit && nitMath && razonMath && nombreMath && descripcionMath &&
                    telefonoMath && celularMath && faxMath && direccionMath && emailMath && webMath && representanteMatch)
                {
                    if (editar)
                    {
                        EditaEmpresa(txtNitCedula.Text);
                        miBussinesEmpresa.EditaEmpresa(miEmpresa);
                    }
                    else
                    {
                        InsertarEmpresa();
                        miBussinesEmpresa.InsertarEmpresa(miEmpresa);
                        
                        editar = true;
                    }                    
                    OptionPane.MessageInformation("La información ha sido guardada.");
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tsbtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }        

        private void btnAgregarInformacionBancaria_Click(object sender, EventArgs e)
        {
            formCuentaBanco = new frmCuentaBancaria();
            formCuentaBanco.MdiParent = this.MdiParent;
            formCuentaBanco.Show();
        }

        private void btnEliminarCuenta_Click(object sender, EventArgs e)
        {
            miBussinesCuenta = new BussinesCuenta();
            try
            {
                var id = Convert.ToInt32(dgvDatosBancario.CurrentRow.Cells["id"].Value);
                DialogResult r = MessageBox.Show("Desea eliminar la cuenta.", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (r == DialogResult.Yes)
                {
                    miBussinesCuenta.EliminaCuenta(id);
                    OptionPane.MessageInformation("Sea eliminado exitosamente.");
                    this.dgvDatosBancario.Rows.RemoveAt(this.dgvDatosBancario.CurrentCell.RowIndex);
                    if (this.dgvDatosBancario.CurrentCell == null)
                    {
                        this.btnEliminarCuenta.Enabled = false;
                        this.btnEditarCuenta.Enabled = false;
                    }
                }

            }
            catch(Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void btnEditaRegimen_Click(object sender, EventArgs e)
        {
            var empresa = miBussinesEmpresa.ObtenerEmpresa();
            cbRegimen.Visible = true;
            txtRegimen.Visible = false;
            if (miEmpresa.Regimen.IdRegimen != 0)
            {
                cbRegimen.SelectedValue = empresa.Regimen.IdRegimen;
            }
        }

        private void btnEditaDepte_Click(object sender, EventArgs e)
        {
            cbDepartamento.SelectedValue = miEmpresa.Departamento.IdDepartamento;
            cbDepartamento.Visible = true;
            txtDepto.Visible = false;
            CargarCiudad(miEmpresa.Departamento.IdDepartamento);
            cbCiudad.SelectedValue = miEmpresa.Ciudad.IdCiudad;
            cbCiudad.Visible = true;
            txtMunicipio.Visible = false;

            //miEmpresa = miBussinesEmpresa.ObtenerEmpresa();
            
            //if (miEmpresa.Departamento.IdDepartamento != 0)
            //{
                
                //CargarCiudad(miEmpresa.Departamento.IdDepartamento);
            //}
            
        }

        private void btnEditaMunicipio_Click(object sender, EventArgs e)
        {
            //miEmpresa = miBussinesEmpresa.ObtenerEmpresa();
            
            //if (miEmpresa.Ciudad.IdCiudad != 0)
            //{
                //CargarCiudad(miEmpresa.Departamento.IdDepartamento);
                cbCiudad.SelectedValue = miEmpresa.Ciudad.IdCiudad;
            //}
            cbCiudad.Visible = true;
            txtMunicipio.Visible = false;
        }

        private void btnEditarCuenta_Click(object sender, EventArgs e)
        {
            DataGridViewRow r =
                  this.dgvDatosBancario.Rows[this.dgvDatosBancario.CurrentCell.RowIndex];

            Configuracion.CuentaBancaria.frmCuentaBancaria frmCuenta =
                new Configuracion.CuentaBancaria.frmCuentaBancaria();
            frmCuenta.idCuenta = Convert.ToInt32(r.Cells["id"].Value);
            frmCuenta.idTipoCuenta = Convert.ToInt32(r.Cells["idTipoCuenta"].Value);
            frmCuenta.TxtEditarTipoCuenta.Text = Convert.ToString(r.Cells["Column2"].Value);
            var numero = Convert.ToString(r.Cells["Column1"].Value);
            frmCuenta.txtNumeroCuenta.Text = numero;
            frmCuenta.numeroCuenta = numero;
            frmCuenta.txtTitularCuenta.Text = Convert.ToString(r.Cells["Column3"].Value);
            frmCuenta.txtBanco.Text = Convert.ToString(r.Cells["Column4"].Value);
            frmCuenta.TxtEditarTipoCuenta.Visible = true;
            frmCuenta.CbTipoCuenta.Visible = false;
            frmCuenta.btnEditarTipoCuenta.Visible = true;
            frmCuenta.edicion = true;
            adicionCuenta = false;
            frmCuenta.Show();
        }

        private void cbDepartamento_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int idDepartamento = Convert.ToInt32(this.cbDepartamento.SelectedValue);
            CargarCiudad(idDepartamento);
        }

        void CompletaEventos_Completo(CompletaArgumentosDeEvento args)
        {
            try
            {
                miTransferenciaCuenta = (TransferenciaCuenta)args.MiObjeto;
                Cuenta c = new Cuenta();

                c.IdTipoCuenta = miTransferenciaCuenta.IdTipoCuenta;
                c.TipoCuenta = miTransferenciaCuenta.TipoCuenta;
                c.NumeroCuenta = miTransferenciaCuenta.NumeroCuenta;
                c.TitularCuenta = miTransferenciaCuenta.TitularCuenta;
                c.BancoCuenta = miTransferenciaCuenta.NombreBanco;
                listaCuenta.Add(c);
                miBindisourse.DataSource = listaCuenta;

                CargaBtn();
            }
            catch { }

            try
            {
                var cuenta = (DTO.Clases.Cuenta)args.MiObjeto;
                var query = (from data in listaCuenta
                             where data.IdCuenta == cuenta.IdCuenta
                             select data).Single();
                listaCuenta.Remove(query);
                listaCuenta.Add(cuenta);
            }
            catch { }
        }

        private void txtNitCedula_Validating(object sender, CancelEventArgs e)
        {
            if (!EsVacio(txtNitCedula, nitRequerido))
            {
                nitMath = true;

                if (ConFormato(Validacion.TipoValidacion.NumeroGuion, txtNitCedula, nitIncorrecto))
                {
                    nitMath = true;

                    if (txtNitCedula.Text != nit)
                    {
                        if (ExisteNit(txtNitCedula.Text))
                        {
                            miError.SetError(txtNitCedula, "Ya existe este Nit  Asociado. ");
                            existeNit = true;
                        }
                        else
                        {
                            miError.SetError(txtNitCedula, null);
                            existeNit = false;
                        }
                    }
                    else
                    {
                        nitMath = true;
                    }

                }
                else
                {
                    nitMath = false;
                }
            }
            else
                nitMath = false;
        }

        private void txtRazonSocial_Validating(object sender, CancelEventArgs e)
        {
            if (!EsVacio(txtRazonSocial, razonRequerida))
            {
                razonMath = true;

                if (ConFormato(Validacion.TipoValidacion.PalabrasNumeroCaracter, txtRazonSocial, razonIncorrecto))
                {
                    razonMath = true;
                }
                else
                {
                    razonMath = false;
                }
            }
            else
                razonMath = false;
        }

        private void txtNombreComercial_Validating(object sender, CancelEventArgs e)
        {
            /*if (!Validacion.EsVacio(txtNombreComercial, miError, nombreComercial))
            {
                if (Validacion.ConFormato
                    (Validacion.TipoValidacion.PalabrasNumeroCaracter, txtNombreComercial, miError, nComercialIncorrecto))
                {
                    nombreMath = true;
                }
                else
                {
                    nombreMath = false;
                }
            }
            else
            {
                nombreMath = false;
            }*/
            /*if (!EsVacio(txtNombreComercial,nombreComercial))
            {
                nombreMath = true;
                
                if (ConFormato(Validacion.TipoValidacion.Palabras, txtNombreComercial, nComercialIncorrecto))
                {
                    nombreMath = true;
                }
                else
                {
                    nombreMath = false;
                }
            }
            else
            {            
                nombreMath = true;
            }*/
        }

        private void txtDescripcion_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtDescripcion.Text))
            {
                descripcionMath = true;
                /*if (ConFormato(Validacion.TipoValidacion.PalabrasNumeroCaracter, txtDescripcion, descripcionIncorrecto))
                {
                    descripcionMath = true;
                }
                else
                {
                    descripcionMath = false;
                }*/
            }
            else
            {
                miError.SetError(txtDescripcion, null);
                descripcionMath = true;
            }

        }

        private void txtTelefono_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtTelefono.Text))
            {
                if (ConFormato(Validacion.TipoValidacion.NumeroEspacionGuion, txtTelefono, telefonoIncorrecto))
                {
                    telefonoMath = true;
                }
                else
                {
                    telefonoMath = false;
                }
            }
            else
                telefonoMath = true;
        }

        private void txtCelular_Validating(object sender, CancelEventArgs e)
        {
            if (!EsVacio(txtCelular, celularRequerido))
            {
                celularMath = true;

                if (ConFormato(Validacion.TipoValidacion.NumeroEspacio, txtCelular, celularIncorrecto))
                {
                    celularMath = true;
                }
                else
                {
                    celularMath = false;
                }
            }
            else
                celularMath = false;
        }

        private void txtNumeroFax_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtNumeroFax.Text))
            {
                if (ConFormato(Validacion.TipoValidacion.NumeroEspacionGuion, txtNumeroFax, faxIncorrecto))
                {
                    faxMath = true;
                }
                else
                {
                    faxMath = false;
                }
            }
            else
                faxMath = true;
        }

        private void txtDireccion_Validating(object sender, CancelEventArgs e)
        {
            if (!EsVacio(txtDireccion, direccionRequerida))
            {
                direccionMath = true;

                if (ConFormato(Validacion.TipoValidacion.Domicilio, txtDireccion, direccionIncorrecta))
                {
                    direccionMath = true;
                }
                else
                {
                    direccionMath = false;
                }
            }
            else
                direccionMath = false;
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtEmail.Text))
            {
                if (ConFormato(Validacion.TipoValidacion.Email, txtEmail, emailIncorrecto))
                {
                    emailMath = true;
                }
                else
                {
                    emailMath = false;
                }
            }
            else
            {
                miError.SetError(txtEmail, null);
                emailMath = true;
            }
        }

        private void txtPaginaWeb_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtPaginaWeb.Text))
            {
                if (ConFormato(Validacion.TipoValidacion.Url, txtPaginaWeb, webIncorrecto))
                {
                    webMath = true;
                }
                else
                {
                    webMath = false;
                }
            }
            else
            {
                miError.SetError(txtPaginaWeb, null);
                webMath = true;
            }
        }

        private void txtRepresentanteLegal_Validating(object sender, CancelEventArgs e)
        {
            if (!EsVacio(txtRepresentanteLegal, representanteRequerido))
            {
                representanteMatch = true;

                if (ConFormato(Validacion.TipoValidacion.Palabras, txtRepresentanteLegal, representanteIncorrecto))
                {
                    representanteMatch = true;
                }
                else
                {                  
                    representanteMatch = false;
                }
            }
            else
                representanteMatch = false;
        }

        private void frmProveedor_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult rta = MessageBox.Show
                   (msnSalir, "Empresa", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (rta == DialogResult.Yes)
            {
                tsbtnGuardar_Click(null, null);
                if (!existeNit &&
                    nitMath &&
                    razonMath &&
                    nombreMath &&
                    descripcionMath &&
                    telefonoMath &&
                    celularMath &&
                    faxMath &&
                    direccionMath &&
                    emailMath &&
                    webMath)
                {
                    e.Cancel = false;
                }
                else
                    e.Cancel = true;
            }
            if (rta == DialogResult.Cancel)
                e.Cancel = true;


            if (Extension)
                CompletaEventos.CapturaEvento(false);

        }       
       
        private void CargarRegimen()
        {
            try
            {
                miBussinesRegimen = new BussinesRegimen();
                this.cbRegimen.DataSource = miBussinesRegimen.ListadoRegimen();
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
                miBussinesDepto = new BussinesDepartamento();
                cbDepartamento.DataSource = miBussinesDepto.ListadoDepartamentos();
                if (cbDepartamento.Items.Count != 0)
                {
                    int idDepartamento = Convert.ToInt32(this.cbDepartamento.SelectedValue);
                    CargarCiudad(idDepartamento);
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

        private void CargarCiudad(int idDepartamento)
        {
            try
            {
                miBussinesCiudad = new BussinesCiudad();
                cbCiudad.DataSource = miBussinesCiudad.ListaCiudadPorDepartamento(idDepartamento);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CargaBtn()
        {
            if (dgvDatosBancario.CurrentCell != null)
            {
                btnEditarCuenta.Enabled = true;
                btnEliminarCuenta.Enabled = true;
            }
        }


        /// <summary>
        /// Insertar empresa a la base de datos.
        /// </summary>
        private void InsertarEmpresa()
        {

            miEmpresa = new DTO.Clases.Empresa();
            miEmpresa.NitEmpresa = txtNitCedula.Text.ToUpper();
            nit = txtNitCedula.Text;
            miEmpresa.RepresentanteLegalEmpresa = txtRepresentanteLegal.Text;
            miEmpresa.Regimen.IdRegimen = Convert.ToInt32(cbRegimen.SelectedValue);
            miEmpresa.NombreJuridicoEmpresa = txtRazonSocial.Text;
            miEmpresa.NombreComercialEmpresa = txtNombreComercial.Text;
            miEmpresa.Descripcion = txtDescripcion.Text;
            miEmpresa.TelefonoEmpresa = txtTelefono.Text;
            miEmpresa.CelularEmpresa = txtCelular.Text;
            miEmpresa.FaxEmpresa = txtNumeroFax.Text;
            miEmpresa.DireccionEmpresa = txtDireccion.Text;
            miEmpresa.Departamento.IdDepartamento = Convert.ToInt32(cbDepartamento.SelectedValue);
            miEmpresa.Ciudad.IdCiudad = Convert.ToInt32(cbCiudad.SelectedValue);
            miEmpresa.EmailEmpresa = txtEmail.Text;
            miEmpresa.PagWebEmpresa = txtPaginaWeb.Text;
            miEmpresa.EstadoEmpresa = true;
            if (chkIva.Checked)
            {
                miEmpresa.RecaudaIVA = true;
            }
            else
            {
                miEmpresa.RecaudaIVA = false;
            }
            miEmpresa.cuenta = listaCuenta;
        }

        /// <summary>
        /// Valida si el texto del control es vacio y muestra el mensaje de error. Devuleve True si el texto es vacio.
        /// </summary>
        /// <param name="control">Control a validar.</param>
        /// <param name="texto">Texto del mensaje</param>
        /// <returns></returns>
        private bool EsVacio(Control control, string texto)
        {
            if (String.IsNullOrEmpty(control.Text))  //Devuelve true si es vacia
            {
                miError.SetError(control, texto);
                return true;
            }
            else
            {
                miError.SetError(control, null);
                return false;
            }
        }

        /// <summary>
        /// Valida el formato de la cadena de texto, devuelve true si el formato es correcto.
        /// </summary>
        /// <param name="tipoValidacion">Tipo de validacion a realizar.</param>
        /// <param name="control">Control a validar.</param>
        /// <param name="mensaje">Mensaje que se mostrar si hay error.</param>
        /// <returns>Retorna true si el formato es correcto.</returns>
        private bool ConFormato(Validacion.TipoValidacion tipoValidacion, Control control, string mensaje)
        {
            bool resultado = false;
            switch (tipoValidacion)
            {
                case Validacion.TipoValidacion.Numeros:
                    {
                        resultado = miValidacion.ValidarNumeroInt(control.Text);
                        break;
                    }
                case Validacion.TipoValidacion.NumeroGuion:
                    {
                        resultado = miValidacion.ValidarCuentaBancaria(control.Text);
                        break;
                    }
                case Validacion.TipoValidacion.NumeroEspacio:
                    {
                        resultado = miValidacion.ValidarNumeroCelular(control.Text);
                        break;
                    }
                case Validacion.TipoValidacion.NumeroEspacionGuion:
                    {
                        resultado = miValidacion.ValidarTelefonoFijo(control.Text);
                        break;
                    }
                case Validacion.TipoValidacion.Palabra:
                    {
                        resultado = miValidacion.ValidarPalabra(control.Text);
                        break;
                    }
                case Validacion.TipoValidacion.Palabras:
                    {
                        resultado = miValidacion.ValidarPalabraCompuesta(control.Text);
                        break;
                    }
                case Validacion.TipoValidacion.Email:
                    {
                        resultado = miValidacion.ValidarEmail(control.Text);
                        break;
                    }
                case Validacion.TipoValidacion.PalabrasNumeroCaracter:
                    {
                        resultado = miValidacion.ValidarPalabrasConCarater(control.Text);
                        break;
                    }
                case Validacion.TipoValidacion.Domicilio:
                    {
                        resultado = miValidacion.ValidarDireccionDomicilio(control.Text);
                        break;
                    }
                case Validacion.TipoValidacion.Url:
                    {
                        resultado = miValidacion.ValidarUrl(control.Text);
                        break;
                    }

                default:
                    {
                        miError.SetError(control, null);
                        break;
                    }
            }
            if (!resultado)
            {
                miError.SetError(control, mensaje);
            }
            else
            {
                miError.SetError(control, null);
            }
            return resultado;
        }

        /// <summary>
        /// Valida de nuevo todos los campos antes de guardar los datos.
        /// </summary>
        private void ValidacionParaGuardar()
        {
            txtNitCedula_Validating(null, null);
            txtRazonSocial_Validating(null, null);
            txtNombreComercial_Validating(null, null);
            txtDescripcion_Validating(null, null);
            txtTelefono_Validating(null, null);
            txtCelular_Validating(null, null);
            txtNumeroFax_Validating(null, null);
            txtDireccion_Validating(null, null);
            txtEmail_Validating(null, null);
            txtPaginaWeb_Validating(null, null);
            txtRepresentanteLegal_Validating(null, null);
        }

        /// <summary>
        /// Verifica si existe el Nit del Proveedor en la base de datos.
        /// </summary>
        /// <param name="codigo">Nit a Verificar.</param>
        /// <returns></returns>
        private bool ExisteNit(string nit)
        {
            try
            {
                miBussinesEmpresa = new BussinesEmpresa();
                return miBussinesEmpresa.ExisteNit(nit);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Limpia todos los datos de los controles en el formulario Empresa.
        /// </summary>
        private void LimpiarCampos()
        {
            this.txtNitCedula.Text = "";
            this.txtRazonSocial.Text = "";
            this.txtNombreComercial.Text = "";
            this.txtDescripcion.Text = "";
            this.txtTelefono.Text = "";
            this.txtNumeroFax.Text = "";
            this.txtCelular.Text = "";
            this.txtDireccion.Text = "";
            this.txtEmail.Text = "";
            this.txtPaginaWeb.Text = "";
            this.txtRepresentanteLegal.Text = "";
            this.dgvDatosBancario.DataSource = null;
        }

        /// <summary>
        /// Carga objeto empresa.
        /// </summary>
        private void CargaEmpresa()
        {
            try
            {
                miEmpresa = miBussinesEmpresa.ObtenerEmpresa();
                if (miEmpresa.NitEmpresa != "")
                { 
                    editar = true;
                }
                else
                    editar=false;
                nit = miEmpresa.NitEmpresa;
                txtNitCedula.Text = miEmpresa.NitEmpresa;
                idRegimen = miEmpresa.Regimen.IdRegimen;
                txtRegimen.Text = miEmpresa.Regimen.NombreRegimen;
                txtNombreComercial.Text = miEmpresa.NombreComercialEmpresa;
                txtRazonSocial.Text = miEmpresa.NombreJuridicoEmpresa;
                txtTelefono.Text = miEmpresa.TelefonoEmpresa;
                txtCelular.Text = miEmpresa.CelularEmpresa;
                txtNumeroFax.Text = miEmpresa.FaxEmpresa;
                txtEmail.Text = miEmpresa.EmailEmpresa;
                txtPaginaWeb.Text = miEmpresa.PagWebEmpresa;
                txtRepresentanteLegal.Text = miEmpresa.RepresentanteLegalEmpresa;
                idDepto = miEmpresa.Departamento.IdDepartamento;
                txtDepto.Text = miEmpresa.Departamento.NombreDepartamento;

                if (miEmpresa.Departamento.IdDepartamento != 0)
                {
                    cbDepartamento.SelectedValue = miEmpresa.Departamento.IdDepartamento;
                    CargarCiudad(miEmpresa.Departamento.IdDepartamento);
                    cbCiudad.SelectedValue = miEmpresa.Ciudad.IdCiudad;
                    //cbDepartamento.SelectedValue = miEmpresa.Departamento.IdDepartamento;
                }
                else
                {
                    txtDepto.Visible = false;
                    btnEditaDepte.Visible = false;
                    cbDepartamento.Visible = true;
                }
                if (miEmpresa.Ciudad.IdCiudad == 0)
                {
                    txtMunicipio.Visible = false;
                    btnEditaMunicipio.Visible = false;
                    cbCiudad.Visible = true;
                }
                
                idCiudad = miEmpresa.Ciudad.IdCiudad;
                txtMunicipio.Text = miEmpresa.Ciudad.NombreCiudad;
                txtDireccion.Text = miEmpresa.DireccionEmpresa;
                if (miEmpresa.EstadoEmpresa)
                {
                    rbActivo.Checked = true;
                }
                else
                {
                    rbInactivo.Checked = true;
                }
                if (miEmpresa.RecaudaIVA)
                {
                    chkIva.Checked = true;
                }
                else
                {
                    chkIva.Checked = false;
                }
                txtDescripcion.Text = miEmpresa.Descripcion;
                dgvDatosBancario.AutoGenerateColumns = false;
                listaCuenta = miEmpresa.cuenta;
                miBindisourse.DataSource = listaCuenta;
                ///dgvDatosBancario.DataSource = miBindisourse;
                CargaBtn();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        /// <summary>
        /// Edita empresa.
        /// </summary>
        /// <param name="nit">nit empresa a editar.</param>
        private void EditaEmpresa(string nit)
        {
            try
            {
                //miEmpresa = new DTO.Clases.Empresa();
                //miEmpresa.NitEmpresa = txtNitCedula.Text;
                miEmpresa.NitEditado = txtNitCedula.Text;
                miEmpresa.Regimen.IdRegimen = idRegimen;//Convert.ToInt32(cbRegimen.SelectedValue);
                miEmpresa.NombreComercialEmpresa = txtNombreComercial.Text.ToUpper();
                miEmpresa.NombreJuridicoEmpresa = txtRazonSocial.Text;
                miEmpresa.TelefonoEmpresa = txtTelefono.Text;
                miEmpresa.CelularEmpresa = txtCelular.Text;
                miEmpresa.FaxEmpresa = txtNumeroFax.Text;
                miEmpresa.EmailEmpresa = txtEmail.Text;
                miEmpresa.PagWebEmpresa = txtPaginaWeb.Text;
                miEmpresa.RepresentanteLegalEmpresa = txtRepresentanteLegal.Text;
                miEmpresa.Departamento.IdDepartamento = Convert.ToInt32(cbDepartamento.SelectedValue);
                miEmpresa.Ciudad.IdCiudad = Convert.ToInt32(cbCiudad.SelectedValue);
                miEmpresa.DireccionEmpresa = txtDireccion.Text;
                if (rbActivo.Checked)
                {
                    miEmpresa.EstadoEmpresa = true;
                }
                else
                {
                    miEmpresa.EstadoEmpresa = false;
                }
                if (chkIva.Checked)
                {
                    miEmpresa.RecaudaIVA = true;
                }
                else
                {
                    miEmpresa.RecaudaIVA = false;
                }
                miEmpresa.Descripcion = txtDescripcion.Text;
                miEmpresa.cuenta = listaCuenta;
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void cbRegimen_SelectedIndexChanged(object sender, EventArgs e)
        {
            idRegimen = Convert.ToInt32(cbRegimen.SelectedValue);
        }

    }
}