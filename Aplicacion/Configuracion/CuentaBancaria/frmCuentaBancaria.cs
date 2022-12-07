using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DTO.Clases;
using BussinesLayer.Clases;
using Utilities;

namespace Aplicacion.Configuracion.CuentaBancaria
{
    public partial class frmCuentaBancaria : Form
    {
        /// <summary>
        /// Representa un objeto de logica de negocion TipoCuenta
        /// </summary>
        private BussinesTipoCuenta miBussinesTipoCuenta;

        /// <summary>
        /// Representa un objeto de logica de negocion Cuenta
        /// </summary>
        private BussinesCuenta miBussinesCuenta;

        /// <summary>
        /// Proporciona un objeto de interfaz de usuario para indicar un error.
        /// </summary>
        private ErrorProvider miError = new ErrorProvider();

        /// <summary>
        /// Representa un objeto de validacio de datos.
        /// </summary>
        private Validacion miValidacion = new Validacion();

        /// <summary>
        /// Establece el valor para guardar los datos.
        /// </summary>
        private bool guardar = false;

        /// <summary>
        /// Establece el valor de existencia de un elemento
        /// </summary>
        private bool existe = false;

        /// <summary>
        /// Establece el valor, si el formulario se usuara para edicion de datos.
        /// </summary>
        public bool edicion = false;

        private bool cuentaMatch = false,
                     titularMatch = false,
                     bancoMatch = false;

        /// <summary>
        /// Establece el valor para el id de la cuenta.
        /// </summary>
        public int idCuenta;

        /// <summary>
        /// Establece el valor de id del tipo de cuenta.
        /// </summary>
        public int idTipoCuenta;

        /// <summary>
        /// Establece el valor del numero de cuenta para validaciones
        /// </summary>
        public string numeroCuenta = "";

        #region Mensajes de validacion

        private const string campoNumeroReq = "El numero de la cuenta es requerido";
        private const string campoTitularReq = "El titular de la cuenta es requerido";
        private const string campoBancoReq = "El nombre del banco es requerido";

        private const string numeroCuentaIncorrecto = "El numero de cuenta tiene formato incorrecto.";
        private const string titularCuentaIncorrecto = "El nombre del Titular de la cuenta tiene formato incorrecto.";
        private const string bancoCuentaIncorrecto = "El nombre del Banco tiene formato incorrecto.";

        private const string errorExiste = "Ya existe una cuenta asociada a ese numero en la Base de Datos.";

        private const string exito = "Los datos de la cuenta se cargaron con exito. \nDesea ingresar otro?";

        #endregion

        public frmCuentaBancaria()
        {
            InitializeComponent();
        }

        private void frmCuentaBancaria_Load(object sender, EventArgs e)
        {
            CargarTipoCuenta();
        }

        /// <summary>
        /// Carga los tipos de cuenta en un ComboBox
        /// </summary>
        private void CargarTipoCuenta()
        {
            try
            {
                miBussinesTipoCuenta = new BussinesTipoCuenta();
                this.cbTipoCuenta.DataSource = miBussinesTipoCuenta.listadoTipoCuenta();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Validacion();
            if (guardar && 
                cuentaMatch &&
                titularMatch &&
                bancoMatch &&
                !existe && 
                !edicion)
            {
                TransferenciaCuenta miCuenta = TransferenciaCuenta.Instancia();
                miCuenta.IdTipoCuenta = Convert.ToInt32(this.cbTipoCuenta.SelectedValue);
                miCuenta.TipoCuenta = ItemTipoCuenta(this.cbTipoCuenta.SelectedItem);
                miCuenta.NumeroCuenta = txtNumeroCuenta.Text;
                miCuenta.TitularCuenta = txtTitularCuenta.Text;
                miCuenta.NombreBanco = txtBanco.Text;
                CompletaEventos.CapturaEvento(miCuenta);
                DialogResult boton = MessageBox.Show(exito, "Datos Correctos", MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Information);
                if (boton == DialogResult.No)
                {
                    LimpiaError();
                    LimpiarCampos();
                    this.Close();                    
                }
                LimpiarCampos();                
            }
            if (guardar &&
                cuentaMatch &&
                titularMatch &&
                bancoMatch &&
                edicion && !existe)
            {
                Cuenta edicionCuenta = new Cuenta();
                edicionCuenta.IdCuenta = idCuenta;
                if (this.cbTipoCuenta.Visible)
                {
                    edicionCuenta.IdTipoCuenta = Convert.ToInt32(this.cbTipoCuenta.SelectedValue);
                    edicionCuenta.TipoCuenta = ItemTipoCuenta(this.cbTipoCuenta.SelectedItem);
                }
                else
                {
                    edicionCuenta.IdTipoCuenta = idTipoCuenta;
                    edicionCuenta.TipoCuenta = txtEditarTipoCuenta.Text;
                }                
                edicionCuenta.NumeroCuenta = txtNumeroCuenta.Text;
                edicionCuenta.TitularCuenta = txtTitularCuenta.Text;
                edicionCuenta.BancoCuenta = txtBanco.Text;
                CompletaEventos.CapturaEvento(edicionCuenta);
                MessageBox.Show("La Edicion se realizon con exito. \nLa ventana se cerrara. ", 
                    "Edicion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        /// <summary>
        /// Obtiene el texto de descripcion de un objeto.
        /// </summary>
        /// <param name="tipoCuenta">Obejeto a castear</param>
        /// <returns></returns>
        private string ItemTipoCuenta(object tipoCuenta)
        {
            DataRowView c = (DataRowView)tipoCuenta;
            return Convert.ToString(c["descripciontipo_cuenta"]);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiaError();
            LimpiarCampos();
            CompletaEventos.CapturaEvento(true);
            this.Close();            
        }

        private void txtNumeroCuenta_Validating(object sender, CancelEventArgs e)
        {
            //Valida que no este vacio.
            if (String.IsNullOrEmpty(txtNumeroCuenta.Text))
            {
                MostrarError(txtNumeroCuenta, campoNumeroReq);
                cuentaMatch = false;
            }
            else 
            {
                QuitarError(txtNumeroCuenta);
                //Valida formato de cuenta correcto
                if (!miValidacion.ValidarCuentaBancaria(txtNumeroCuenta.Text))
                {
                    MostrarError(txtNumeroCuenta, numeroCuentaIncorrecto);
                    cuentaMatch = false;
                }
                else
                {
                    QuitarError(txtNumeroCuenta);
                    if (ExisteCuenta(txtNumeroCuenta.Text) && 
                                 !numeroCuenta.Equals(txtNumeroCuenta.Text))
                    {
                        miError.SetError(txtNumeroCuenta, errorExiste);
                        existe = true;
                    }
                    else
                    {
                        miError.SetError(txtNumeroCuenta, null);
                        existe = false;
                    }
                    cuentaMatch = true;
                }
            }
            
        }

        private void txtTitularCuenta_Validating(object sender, CancelEventArgs e)
        {
            //valida que no este vacio.
            if (String.IsNullOrEmpty(txtTitularCuenta.Text))
            {
                MostrarError(txtTitularCuenta, campoTitularReq);
                titularMatch = false;
            }
            else
            {
                QuitarError(txtTitularCuenta);
                //valida formato de nombres de titular
                if (!miValidacion.ValidarPalabraCompuesta(txtTitularCuenta.Text))
                {
                    MostrarError(txtTitularCuenta, titularCuentaIncorrecto);
                    titularMatch = false;
                }
                else
                {
                    QuitarError(txtTitularCuenta);
                    titularMatch = true;
                }
            }            
        }

        private void txtBanco_Validating(object sender, CancelEventArgs e)
        {
            //valida que el campo no este nulo
            if (String.IsNullOrEmpty(txtBanco.Text))
            {
                MostrarError(txtBanco, campoBancoReq);
                bancoMatch = false;
            }
            else
            {
                QuitarError(txtBanco);
                //valida que el formato este correcto
                if (!miValidacion.ValidarPalabraCompuesta(txtBanco.Text))
                {
                    MostrarError(txtBanco, bancoCuentaIncorrecto);
                    bancoMatch = false;
                }
                else
                {
                    QuitarError(txtBanco);
                    bancoMatch = true;
                }
            }
        }

        /// <summary>
        /// Verifica si una cuenta existe o no en la base de datos.
        /// </summary>
        /// <param name="cuenta">Cuenta a validar.</param>
        /// <returns></returns>
        private bool ExisteCuenta(string cuenta)
        {
            try
            {
                miBussinesCuenta = new BussinesCuenta();
                return miBussinesCuenta.ExisteCuenta(cuenta);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message , "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Muestra el error en el campo indicado y establece guardar en false
        /// </summary>
        /// <param name="control">Campo en el cual se visuliza el error</param>
        /// <param name="mensaje">Mensaje de error al usuario</param>
        private void MostrarError(Control control , string mensaje) 
        {
            miError.SetError(control , mensaje);
            guardar = false;

        }

        /// <summary>
        /// Quita el error en el campo indicado y establece guardar en true
        /// </summary>
        /// <param name="control">Campo en el cual se quitara el error</param>
        private void QuitarError(Control control) 
        {
            miError.SetError(control , null);
            guardar = true;
        }

        /// <summary>
        /// Quita los errores de los campos.
        /// </summary>
        private void LimpiaError()
        {
            miError.SetError(txtNumeroCuenta ,null);
            miError.SetError(txtTitularCuenta, null);
            miError.SetError(txtBanco, null);
        }

        /// <summary>
        /// Limpia todos los campos de texto del formulario.
        /// </summary>
        private void LimpiarCampos()
        {
            this.txtNumeroCuenta.Text = "";
            this.txtTitularCuenta.Text = "";
            this.txtBanco.Text = "";
            txtNumeroCuenta.Focus();
        }

        /// <summary>
        /// Obtine o establece el valor del combo box para el tipo de cuenta.
        /// </summary>
        public ComboBox CbTipoCuenta
        {
            set { this.cbTipoCuenta = value; }
            get { return this.cbTipoCuenta; }
        }

        private void btnEditarTipoCuenta_Click(object sender, EventArgs e)
        {
            this.cbTipoCuenta.Visible = true;
            this.btnEditarTipoCuenta.Visible = false;
            this.txtEditarTipoCuenta.Visible = false;
        }

        /// <summary>
        /// Valida de nuevo los campos.
        /// </summary>
        private void Validacion()
        {
            txtNumeroCuenta_Validating(null, null);
            txtTitularCuenta_Validating(null,null);
            txtBanco_Validating(null, null);
        }
    }
}