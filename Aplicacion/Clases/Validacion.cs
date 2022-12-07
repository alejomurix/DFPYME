using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Aplicacion.Clases
{
    /// <summary>
    /// Representa una clase para validacion de datos
    /// </summary>
    public class Validacion
    {
        /// <summary>
        /// Establece el tipo de validacion que se realizara.
        /// </summary>
        public enum TipoValidacion 
        {
            /// <summary>
            /// Indica que la validacion se hara a un numero entero.
            /// </summary>
            Numeros = 1 ,

            /// <summary>
            /// Indica que la validacion se hara a solo numeros que pueden tener un guion.
            /// </summary>
            NumeroGuion,

            /// <summary>
            /// Indica que la validacion se hara a solo numeros que pueden tener un punto.
            /// </summary>
            NumerosYPunto,

            /// <summary>
            /// Indica que la validacion se hara a solo numeros que puede tener espacios.
            /// </summary>
            NumeroEspacio,

            /// <summary>
            /// Indica que la validacion se hara a solo numeros que pueden tener guiones y espacios
            /// </summary>
            NumeroEspacionGuion,

            /// <summary>
            /// Indica que la validacion se hara a palabras sin espacios
            /// </summary>
            Palabra,

            /// <summary>
            /// Indica que la validacion se hara a palabras con espacios
            /// </summary>
            Palabras,

            /// <summary>
            /// Indica que la validacion se hara a una direccion de Email
            /// </summary>
            Email,

            /// <summary>
            /// Indica que la validacion se hara a una palabra que contiene caracteres y numeros
            /// </summary>
            PalabrasNumeroCaracter,

            /// <summary>
            /// Indica que la validaacion se hara a una palabra que contiene una direccion de Domicilio.
            /// </summary>
            Domicilio,
            
            /// <summary>
            /// Indica que la Validacion se hara una url
            /// </summary>
            Url,
        };

        //^[a-zA-Z\ \'\u00e1\u00e9\u00ed\u00f3\u00fa\u00c1\u00c9\u00cd\u00d3\u00da\u00f1\u00d1\u00FC\u00DC]+$

        #region Atributos Expresiones Regulares

        private const string nombreRegularExpression = @"^[a-zA-Z\ \'\u00e1\u00e9\u00ed\u00f3\u00fa\u00c1\u00c9\u00cd\u00d3\u00da\u00f1\u00d1\u00FC\u00DC]+$";            //Ejem:  Alberto Nuñez , Aejo Vásquez

        private const string nombreCompuestoRegularExpresion = @"^[a-zA-Z\ \'\u00e1\u00e9\u00ed\u00f3\u00fa\u00c1\u00c9\u00cd\u00d3\u00da\u00f1\u00d1\u00FC\u00DC]+$";

        private const string numeroRegularExpression = "^[0-9]+$";                                              //Ejem 126,  25355698, 1

        private const string numerosPunto = "^[0-9.]+$";

        private const string numeroTelefonoRegularExpression = @"^[0-9\s-]+$";                                  // 853 15 05,  339-36-98

        private const string numeroCelularRegularExpresion = @"^[0-9\s]+$";                                     // 312 718 03 51

        private const string emailRegularExpression =
                    @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-­9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

        private const string cuentaBancoRegularExpresion = "^[0-9]+-{0,}[0-9]+$";                               // 15339644-7

        /// <summary>
        /// Expresion Regular palabras con espacios. Pueden contener espacios , numeros,  caracteres:
        /// </summary>
        private const string palabrasConCaracter =
                   @"^[a-zA-Z\ \'\u00e1\u00e9\u00ed\u00f3\u00fa\u00c1\u00c9\u00cd\u00d3\u00da\u00f1\u00d1\u00FC\u00DC0-9\s&.#\-_]+$";//@"^[a-zA-Z0-9\s\&\.\-\_]+$";

        private const string domicilioRegularExpresion = 
                    @"^[a-zA-Z\ \'\u00e1\u00e9\u00ed\u00f3\u00fa\u00c1\u00c9\u00cd\u00d3\u00da\u00f1\u00d1\u00FC\u00DC0-9\s.#°-]+$";

        private const string urlRegularExpresion = @"\w{0,3}.[a-z\-_\.{0,1}]+\.[com|org|net|edu|gov]+\.{0,1}[a-z]{0,2}$";         //www.icetex.gov.co   acad.ucaldas.edu.co

        #endregion

        /// <summary>
        /// Representa una instacia de Validacion
        /// </summary>
        public Validacion() { }

        /// <summary>
        /// Valida si el texto del control es vacio y muestra un mensaje de error. Devuleve True si el texto es vacio.
        /// </summary>
        /// <param name="control">Control a validar.</param>
        /// <param name="error">Obejto de error utilizado.</param>
        /// <param name="mensaje">Texto del mensaje a mostrar.</param>
        /// <returns></returns>
        public static bool EsVacio(Control control, ErrorProvider error , string mensaje) 
        {
            ErrorProvider miError = new ErrorProvider();
            if (String.IsNullOrEmpty(control.Text))
            {
                error.SetError(control, mensaje);
                return true;
            }
            else
            {
                error.SetError(control, null);
                return false;
            }
        }

        /// <summary>
        /// Valida el formato de la cadena de texto y muestra el mensaje de error si es incorrecto. Devuelve true si el formato es correcto.
        /// </summary>
        /// <param name="tipoValidacion">Tipo de validacion a realizar.</param>
        /// <param name="control">Control a validar.</param>
        /// <param name="error">Obejto de error utilizado.</param>
        /// <param name="mensaje">Mensaje que se mostrara si hay error.</param>
        /// <returns></returns>
        public static bool ConFormato
         (Validacion.TipoValidacion tipoValidacion, Control control, ErrorProvider error, string mensaje)
        {
            bool resultado = false;
            switch (tipoValidacion)
            {
                case Validacion.TipoValidacion.Numeros:
                    {
                        resultado = Regex.IsMatch(control.Text, numeroRegularExpression);
                        break;
                    }
                case Validacion.TipoValidacion.NumerosYPunto:
                    {
                        resultado = Regex.IsMatch(control.Text, numerosPunto);
                        break;
                    }
                case TipoValidacion.NumeroGuion:
                    {
                        resultado = Regex.IsMatch(control.Text, cuentaBancoRegularExpresion);
                        break;
                    }
                case TipoValidacion.PalabrasNumeroCaracter:
                    {
                        resultado = Regex.IsMatch(control.Text, palabrasConCaracter);
                        break;
                    }
                case TipoValidacion.Palabras:
                    {
                        resultado = Regex.IsMatch(control.Text, nombreCompuestoRegularExpresion);
                        break;
                    }
                case TipoValidacion.NumeroEspacionGuion:
                    {
                        resultado = Regex.IsMatch(control.Text, numeroTelefonoRegularExpression);
                        break;
                    }
                case TipoValidacion.NumeroEspacio:
                    {
                        resultado = Regex.IsMatch(control.Text, numeroCelularRegularExpresion);
                        break;
                    }
                case TipoValidacion.Domicilio:
                    {
                        resultado = Regex.IsMatch(control.Text, domicilioRegularExpresion);
                        break;
                    }
                case TipoValidacion.Email:
                    {
                        resultado = Regex.IsMatch(control.Text, emailRegularExpression);
                        break;
                    }
                case TipoValidacion.Url:
                    {
                        resultado = Regex.IsMatch(control.Text, urlRegularExpresion);
                        break;
                    }
            }
            if (!resultado)
            {
                error.SetError(control, mensaje);
            }
            else
            {
                error.SetError(control, null);
            }
            return resultado;
        }

        /// <summary>
        /// Valida si el texto corresponde a un palabra del alfabeto si espacios
        /// </summary>
        /// <param name="nombre">Nombre a validar</param>
        /// <returns></returns>
        public bool ValidarPalabra( string nombre )
        {
            return Regex.IsMatch( nombre , nombreRegularExpression );
        }

        /// <summary>
        /// Valida si el texto corresponde a un Numero Intero sin espacios ni otros caracteres correcto
        /// </summary>
        /// <param name="numero">Numero a validar</param>
        /// <returns></returns>
        public bool ValidarNumeroInt(string numero)
        {
            return  Regex.IsMatch( numero , numeroRegularExpression );
        }

        /// <summary>
        /// Valida si el texto corresponde a un Email correcto
        /// </summary>
        /// <param name="email">Email a validar</param>
        /// <returns></returns>
        public bool ValidarEmail(string email)
        {
            return Regex.IsMatch( email , emailRegularExpression);
        }

        /// <summary>
        /// Valida si el texto corresponde a una Cuenta Bancaria correcta.
        /// </summary>
        /// <param name="cuenta">Cuenta a validar</param>
        /// <returns></returns>
        public bool ValidarCuentaBancaria(string cuenta)
        {
            return Regex.IsMatch(cuenta, cuentaBancoRegularExpresion);
        }

        /// <summary>
        /// Valida si el texto corresponde a palabras compuestas del alfabeto con espacios
        /// </summary>
        /// <param name="nombres">Palabras a validar</param>
        /// <returns></returns>
        public bool ValidarPalabraCompuesta(string nombres)
        {
            return Regex.IsMatch(nombres, nombreCompuestoRegularExpresion);
        }

        /// <summary>
        /// Valida si el texto corresponde a un numero de telefono fijo
        /// </summary>
        /// <param name="numero">Numero a validar</param>
        /// <returns></returns>
        public bool ValidarTelefonoFijo(string numero)
        {
            return Regex.IsMatch(numero, numeroTelefonoRegularExpression);
        }

        /// <summary>
        /// Valida si el texto corresponde a un numero de celular.
        /// </summary>
        /// <param name="numero">Numero a validar</param>
        /// <returns></returns>
        public bool ValidarNumeroCelular(string numero)
        {
            return Regex.IsMatch(numero, numeroCelularRegularExpresion);
        }

        /// <summary>
        /// Valida si el texto corresponde a palabras. Pueden contener espacios y caracteres.
        /// </summary>
        /// <param name="palabras"></param>
        /// <returns></returns>
        public bool ValidarPalabrasConCarater(string palabras)
        {
            return Regex.IsMatch(palabras, palabrasConCaracter);
        }

        /// <summary>
        /// Valida si el texto corresponde a direcciones de Domicilio
        /// </summary>
        /// <param name="domicilio"></param>
        /// <returns></returns>
        public bool ValidarDireccionDomicilio(string domicilio)
        {
            return Regex.IsMatch(domicilio, domicilioRegularExpresion);
        }

        /// <summary>
        /// Valida si el texto Corresponde a una url valida
        /// </summary>
        /// <param name="url">Url a validar</param>
        /// <returns></returns>
        public bool ValidarUrl(string url)
        {
            return Regex.IsMatch(url, urlRegularExpresion);
        }
    }
}