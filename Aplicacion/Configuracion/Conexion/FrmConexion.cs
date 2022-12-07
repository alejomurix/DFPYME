using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using BussinesLayer.Clases;
using CustomControl;
using Utilities;

namespace Aplicacion.Configuracion.Conexion
{
    public partial class FrmConexion : Form
    {
        /// <summary>
        /// Objeto que encapsula la lógica de negocio de BaseDatos.
        /// </summary>
        private BussinesBaseDatos miBussinesBaseDatos;

        /// <summary>
        /// Objeto para el acceso al ensamblado de la aplicación.
        /// </summary>
        private System.Reflection.Assembly assembly;

        /// <summary>
        /// Representa el Stream de la Imagen de Agregar o deshacer Nueva Unidad de Medida.
        /// </summary>
        private System.IO.StreamReader streamReader;

        /// <summary>
        /// Objeto tipo hilo que me premite realiza ejecuciones asincronas y sincrona.
        /// </summary>
        private Thread miThread;

        /// <summary>
        /// Objeto que representa el panel de opcion a mostrar.
        /// </summary>
        private OptionPane miOption;

        /// <summary>
        /// Obtiene o establece el valor que indica si el cruce se realizo con exito.
        /// </summary>
        private bool Success = false;

        /// <summary>
        /// Representa la ruta del recurso incrustado Demo.txt que contiene los datos necesarios para el Script.
        /// </summary>
        private const string Script = "Aplicacion.Recursos.Documentos.Demo.txt";

        /// <summary>
        /// Representa el texto: La conexión de prueba se realizó correctamente.
        /// </summary>
        private const string MsnSuccess = "La conexión de prueba se realizó correctamente.";

        /// <summary>
        /// Representa el texto: La conexión y Base de datos se ha establecido correctamente.
        /// </summary>
        private const string MsnSuccessSave = "La conexión y Base de datos se ha establecido correctamente.";

        /// <summary>
        /// Representa el texto: Fallo de autenticación al servidor de base de datos. 
        /// Por favor compruebe su configuración
        /// </summary>
        private const string MsnError = "Fallo de autenticación al servidor de base de datos.\n"
                                      + "Por favor compruebe su configuración.";

        /// <summary>
        /// Representa un mensaje de error en un control.
        /// </summary>
        private ErrorProvider miError;

        /// <summary>
        /// Obtiene o establece el valor que indica si se guarda los datos.
        /// </summary>
        private bool Guardar = false;

        /// <summary>
        /// Indica si la base de datos ingresada es correcta.
        /// </summary>
        private bool BaseDatos = false;

        /// <summary>
        /// Indica si el Password ingresado es correcto.
        /// </summary>
        private bool Password = false;

        /// <summary>
        /// Representa el texto: El campo Base de datos es requerido.
        /// </summary>
        private const string BaseDReq = "El campo Base de datos es requerido.";

        /// <summary>
        /// Representa el texto: La Base de Datos que ingreso tiene formato incorrecto.
        /// </summary>
        private const string BaseFormato = "La Base de Datos que ingreso tiene formato incorrecto.";

        /// <summary>
        /// Representa el texto: La Contraseña que ingreso tiene formato incorrecto.
        /// </summary>
        private const string PassFormato = "La Contraseña que ingreso tiene formato incorrecto.";

        public FrmConexion()
        {
            InitializeComponent();
            assembly = System.Reflection.Assembly.GetExecutingAssembly();
            miBussinesBaseDatos = new BussinesBaseDatos();
            miError = new ErrorProvider();
        }

        private void FrmConexion_Load(object sender, EventArgs e)
        {
            CargarConfiguracion();
        }

        private void FrmConexion_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar = true;
            txtBaseDatos_Validating(null, null);
            txtPassword_Validating(null, null);
            if (BaseDatos && Password)
            {
                GuardarConfiguracion();
                try
                {
                    try
                    {
                        miOption = new OptionPane();
                        miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Marquee;
                        miOption.FrmProgressBar.Closed_ = true;
                        miOption.ProgressShow("Espere mientras se realizan las operaciones necesarias...",
                            "Operacion en progreso");
                        this.Enabled = false;
                        miThread = new Thread(start);
                        miThread.Start();
                    }
                    catch (Exception ex)
                    {
                        OptionPane.MessageError(ex.Message);
                    }
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
            Guardar = false;
        }

        private void tsSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBaseDatos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtBaseDatos_Validating(null, null);
            }
        }

        private void txtBaseDatos_Validating(object sender, CancelEventArgs e)
        {
            if (Guardar && !Validacion.EsVacio(
                txtBaseDatos, miError, BaseDReq))
            {
                if (Validacion.ConFormato(Validacion.TipoValidacion.LetrasNumerosCaracteres,
                    txtBaseDatos, miError, BaseFormato))
                {
                    BaseDatos = true;
                }
                else
                    BaseDatos = false;
            }
            //else
           //     BaseDatos = true;
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtPassword_Validating(null, null);
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtPassword.Text))
            {
                if (Validacion.ConFormato(Validacion.TipoValidacion.LetrasNumerosCaracteres,
                    txtPassword, miError, PassFormato))
                {
                    Password = true;
                }
                else
                    Password = false;
            }
            else
                Password = true;
        }

        private void chkMostrarPassword_Click(object sender, EventArgs e)
        {
            if (chkMostrarPassword.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void btnTestConexion_Click(object sender, EventArgs e)
        {
            /*FrmPrint f = new FrmPrint();
            f.StringCaption = "Conexión";
            DialogResult rta = f.ShowDialog();
            MessageBox.Show(rta.ToString());*/

            TestConfiguracionPassword();
            try
            {
                if (miBussinesBaseDatos.TestConexion())
                {
                    OptionPane.MessageSuccess(MsnSuccess);
                }
                else
                {
                    OptionPane.MessageError(MsnError);
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        /// <summary>
        /// Carga la configuración inicial para la conexión a base de datos.
        /// </summary>
        private void CargarConfiguracion()
        {
            try
            {
                txtServidor.Text = AppConfiguracion.ValorSeccion("server");
                txtBaseDatos.Text = AppConfiguracion.ValorSeccion("dataBase");
                txtPassword.Text = AppConfiguracion.ValorSeccion("password");
                streamReader = new System.IO.StreamReader
                (assembly.GetManifestResourceStream(Script));
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        /// <summary>
        /// Almacena los valores de la configuración elegida en por el usuario en el archivo.
        /// </summary>
        private void GuardarConfiguracion()
        {
            try
            {
                AppConfiguracion.SaveConfiguration("server", txtServidor.Text);
                AppConfiguracion.SaveConfiguration("dataBase", txtBaseDatos.Text);
                AppConfiguracion.SaveConfiguration("password", txtPassword.Text);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        /// <summary>
        /// Almacena el valor del Password en la configuración.
        /// </summary>
        private void TestConfiguracionPassword()
        {
            try
            {
                AppConfiguracion.SaveConfiguration("password", txtPassword.Text);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        /// <summary>
        /// Obtiene la lectura contenida en el recurso incrustado Demo.txt
        /// </summary>
        /// <returns></returns>
        private string GetStrigRecursoDemo()
        {
            try
            {
                if (streamReader.Peek() != -1)
                {
                    return streamReader.ReadToEnd();
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                OptionPane.MessageError("Ocurrió un error al cargar el recurso Demo.txt.");
                return null;
            }
        }

        /// <summary>
        /// Despliega el proceso en el hilo (Thread).
        /// </summary>
        private void start()
        {
            GuardarConfiguracionYBaseDatos();
        }

        /// <summary>
        /// Realiza la operacion de guardado con ayuda de el hilo (Thread).
        /// </summary>
        private void GuardarConfiguracionYBaseDatos()
        {
            try
            {
                var script = GetStrigRecursoDemo();
                miBussinesBaseDatos.CrearDataBase(txtBaseDatos.Text, script);
                Success = true;
                if (this.InvokeRequired)
                    this.Invoke(new Action(FinishProcess));
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
                AppConfiguracion.SaveConfiguration("conection", "false");
                Success = false;
                if (this.InvokeRequired)
                    this.Invoke(new Action(FinishProcess));
            }
        }

        /// <summary>
        /// Finaliza las funciones del proceso de Guardado.
        /// </summary>
        private void FinishProcess()
        {
            try
            {
                miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Blocks;
                miOption.FrmProgressBar.Closed_ = false;
                miOption.FrmProgressBar.Close();
                this.Enabled = true;
                if (Success)
                {
                    OptionPane.MessageSuccess(MsnSuccessSave);
                    AppConfiguracion.SaveConfiguration("conection", "true");
                    var frmPrincipal = (Principal.frmPrincipal)this.MdiParent;
                    frmPrincipal.HabilitarMenu();
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }
    }
}