using System;
using System.Windows.Forms;

namespace CustomControl
{
    /// <summary>
    /// Muestra un cuadro de mensaje que puede contener texto, cajas de texto, botones y simbolos.
    /// </summary>
    public class OptionPane
    {
        /// <summary>
        /// Objeto que permite el acceso al formulario.
        /// </summary>
        private static frmPassword FrmPassword = new frmPassword();

        private static frmSegmentar FrmSegmentar = new frmSegmentar();

        private static FrmLoginUserPassword FrmLoginUserPassword_ = new FrmLoginUserPassword();


        /// <summary>
        /// Objeto que permite el acceso al formulario.
        /// </summary>
        public frmProgressBar FrmProgressBar;

        /// <summary>
        /// Establece el valor para el recurso de imagen loginAdmin.
        /// </summary>
        private const string loginAdmin = "CustomControl.Resource.loginAdmin.png";

        /// <summary>
        /// Establece el tipo de campo de texto requerido.
        /// </summary>
        public enum Type
        {
            /// <summary>
            /// Establece que el campo de texto es para uso de contraseña.
            /// </summary>
            Password,

            /// <summary>
            /// Establece que el campo es simple texto.
            /// </summary>
            Text
        }

        /// <summary>
        /// Establece el tipo de icono que se mostrara al usuario en el cuadro de dialogo.
        /// </summary>
        public enum Icon
        {
            /// <summary>
            /// Muestra un icono con dos avatares y un candado.
            /// </summary>
            LoginAdmin
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase OptionPane
        /// </summary>
        public OptionPane()
        {
            this.FrmProgressBar = new frmProgressBar();
        }

        /// <summary>
        /// Muestra un cuadro de dialogo frente del objeto especificado
        /// </summary>
        /// <param name="text">Texto a mostrar en el dialogo.</param>
        /// <param name="caption">Titulo de la ventana.</param>
        /// <returns></returns>
        public static string OptionBox(string text, string caption, Icon icon)
        {
            if (text.Length > 22)
                FormResizePassword(text.Length);
            FrmPassword.Text = caption;
            FrmPassword.text.Text = text;
            FrmPassword.pbIcono.Image = SelectImage(icon);
            FrmPassword.password.Focus();
            DialogResult rta = FrmPassword.ShowDialog();
            var result = FrmPassword.password.Text;
            if (rta == DialogResult.Cancel)
                result = "false";
            FrmPassword.password.Text = "";
            return result;
        }

        public static string OptionBox(bool segmenta, bool electronic)
        {
            char option = '0';
            FrmSegmentar.Segment = segmenta;
            FrmSegmentar.Electronic = electronic;
            DialogResult rta = FrmSegmentar.ShowDialog();
            switch (rta)
            {
                case DialogResult.OK:
                    option = '1';
                    break;
                case DialogResult.Yes:
                    option = '2';
                    break;
                case DialogResult.Retry:
                    option = '3';
                    break;
                case DialogResult.No:
                    option = '4';
                    break;
            }
            /*if (rta.Equals(DialogResult.Cancel))
            {
                option = '2';
            }*/
            return option.ToString();
        }

        public static string LoginUserPassword()
        {
            FrmLoginUserPassword_.pbIcono.Image = SelectImage(Icon.LoginAdmin);
            FrmLoginUserPassword_.txtUsuario.Focus();
            FrmLoginUserPassword_.DialogResult = DialogResult.None;
            DialogResult rta = FrmLoginUserPassword_.ShowDialog();
            var result = FrmLoginUserPassword_.txtUsuario.Text + "&" + FrmLoginUserPassword_.txtPassword.Text;
            if (rta == DialogResult.Cancel)
                result = "false";
            FrmLoginUserPassword_.txtUsuario.Text = "";
            FrmLoginUserPassword_.txtPassword.Text = "";
            return result;
        }

        /// <summary>
        /// Selecciona la imagen segun la eleccion del metodo.
        /// </summary>
        /// <param name="icon">Establece el tipo de icono que mostrara como imagen.</param>
        /// <returns></returns>
        static System.Drawing.Bitmap SelectImage(Icon icon)
        {
            switch (icon)
            {
                case Icon.LoginAdmin:
                    {
                        return LoadImage(loginAdmin);
                    }
                default:
                    {
                        return null;
                    }
            }
        }

        /// <summary>
        /// Obtiene una imagen segun el archivo de recurso incrustado.
        /// </summary>
        /// <param name="resource">Nombre del archivo incrustado.</param>
        /// <returns></returns>
        static System.Drawing.Bitmap LoadImage(string resource)
        {
            var stream = System.Reflection.Assembly.GetExecutingAssembly()
                .GetManifestResourceStream(resource);
            var bitMap = new System.Drawing.Bitmap(stream);
            return bitMap;
        }

        /// <summary>
        /// Muestra un cuadro con el progreso de una tranzacion.
        /// </summary>
        /// <param name="text">Texto a mostrar en el cuadro.</param>
        /// <param name="caption">Titulo de la ventana.</param>
        public void ProgressShow(string text, string caption)
        {
            if (text.Length > 46)
                FormResizeProgressBar(text.Length);
            this.FrmProgressBar.Text = caption;
            this.FrmProgressBar.lblTexto.Text = text;
            this.FrmProgressBar.Show();
        }

        /// <summary>
        /// Muestra un cuadro con el progreso de una tranzacion.
        /// </summary>
        /// <param name="text">Texto a mostrar en el cuadro.</param>
        /// <param name="caption">Titulo de la ventana.</param>
        /// <param name="dialog">Indica si es ventana de dialogo.</param>
        public void ProgressShow(string text, string caption, bool dialog)
        {
            if (text.Length > 46)
                FormResizeProgressBar(text.Length);
            this.FrmProgressBar.Text = caption;
            this.FrmProgressBar.lblTexto.Text = text;
            this.FrmProgressBar.ShowDialog();
        }

        /// <summary>
        /// Muestra un cuadro de mensaje de Informacion.
        /// </summary>
        /// <param name="message">Mensaje a mostrar.</param>
        public static void MessageInformation(string message)
        {
            MessageBox.Show(message, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Muestra un cuadro de mensaje de Exito.
        /// </summary>
        /// <param name="message">Mensaje a mostrar.</param>
        public static void MessageSuccess(string message)
        {
            MessageBox.Show(message, "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Muestra un cuadro de mensaje de Error.
        /// </summary>
        /// <param name="message">Mensaje a mostrar.</param>
        public static void MessageError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void MessageWarning(string message)
        {
            MessageBox.Show(message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// Redimensiona los objetos del formulario frmPassword segun la necesidad.
        /// </summary>
        /// <param name="length">Tamaño que proporciona la redimencion.</param>
        static void FormResizePassword(int length)
        {
            var residuo = length - 22;
            var pixel = residuo * 5;
            FrmPassword.ClientSize = new System.Drawing.Size(265 + pixel, 150);
            FrmPassword.password.Size = new System.Drawing.Size(213 + pixel, 20);
            //FrmPassword.Cancel.Location = new System.Drawing.Point(162 + pixel, 115);
            //FrmPassword.OK.Location = new System.Drawing.Point(69 + pixel, 115);
            FrmPassword.OK.Location = new System.Drawing.Point(162 + pixel, 115);
        }

        /// <summary>
        /// Redimensiona los objetos del formulario frmProgresBar segun la necesidad.
        /// </summary>
        /// <param name="length">Tamaño que proporciona la redimencion.</param>
        private void FormResizeProgressBar(int length)
        {
            var residuo = length - 46;
            var pixel = residuo * 5;
            FrmProgressBar.ClientSize = new System.Drawing.Size(434 + pixel, 148);
            FrmProgressBar.barraProgreso.Size = new System.Drawing.Size(357 + pixel, 23);
        }
    }
}