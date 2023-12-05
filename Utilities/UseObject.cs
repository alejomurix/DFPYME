using System;
using System.Collections.Generic;

namespace Utilities
{
    /// <summary>
    /// Representa una clase para el uso y manejo de objetos en general
    /// </summary>
    public class UseObject
    {
        /// <summary>
        /// Devuelve una cadena de caracteres en grupos de tres caracteres separados 
        /// por un carácter punto (.) creando la cifra significativa de miles.
        /// </summary>
        /// <param name="cadena">Cadena de caracteres a separar.</param>
        /// <returns></returns>
        public static string InsertSeparatorMil(string cadena)
        {
            bool minus = false;
            if (Convert.ToDouble(cadena) < 0)
            {
                minus = true;
                cadena = (Convert.ToDouble(cadena) * -1).ToString();
            }
            char character = '.';
            var position = 3;
            var cadenaSplit = cadena.Split(',');
            if (cadenaSplit.Length > 1)
            {
                cadena = cadenaSplit[0];
            }
            var miStringChar = cadena.ToCharArray();
            string miString = "";
            int modulo = (miStringChar.Length - 1) % position;
            int i = 0;
            try
            {
                miString += miStringChar[i];
                if (modulo == 0)
                {
                    if (miStringChar.Length > 3)
                    {
                        miString += character;
                    }
                }
                else
                {
                    if (modulo == 1)
                    {
                        miString += miStringChar[i + 1];
                        if (miStringChar.Length > 3)
                        {
                            miString += character;
                        }
                    }
                    else
                    {
                        miString += miStringChar[i + 1];
                        miString += miStringChar[i + 2];
                        if (miStringChar.Length > 3)
                        {
                            miString += character;
                        }
                    }
                }
                int contador = 0;
                for (int j = modulo + 1; j < miStringChar.Length; j++)
                {
                    contador++;
                    miString += miStringChar[j];
                    if (contador % position == 0 && j < miStringChar.Length - 1)
                    {
                        miString += character;
                    }
                }
                if (cadenaSplit.Length > 1)
                {
                    miString += ",";
                    miString += cadenaSplit[1];
                }
                miStringChar = null;
                cadenaSplit = null;
                if (minus)
                    miString = "-" + miString;
                return miString;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static string InsertSeparatorMilMasDigito(string cadena)
        {
            var cadenaSplit = cadena.Split('-');
            if (cadenaSplit.Length > 1)
            {
                return InsertSeparatorMil(cadenaSplit[0]) + "-" + cadenaSplit[1];
            }
            else
            {
                return InsertSeparatorMil(cadenaSplit[0]);
            }
        }

        /// <summary>
        /// Devuelve un número decimal extraído de una cadena de caracteres suprimiendo el carácter punto (.).
        /// </summary>
        /// <param name="cadena">Cadena de caracteres a editar.</param>
        /// <returns></returns>
        public static double RemoveSeparatorMil(string cadena)
        {
            var cadenaSplit = cadena.Split(',');
            if (cadenaSplit.Length > 1)
            {
                cadena = cadenaSplit[0];
            }
            cadena = Convert.ToInt64(Convert.ToDouble(cadena)).ToString();
            if (cadenaSplit.Length > 1)
            {
                cadena += ",";
                cadena += cadenaSplit[1];
            }
            cadenaSplit = null;
            return Convert.ToDouble(cadena);
        }

        public static string RemoverPunto(string cadena)
        {
            char[] arrChar = cadena.ToCharArray();
            string miCadena = "";
            foreach (char c in arrChar)
            {
                if (c != '.')
                {
                    miCadena += c.ToString();
                }
            }
            return miCadena;
        }

        /// <summary>
        /// Remueve de la cadena todos los caracteres que se indique.
        /// </summary>
        /// <param name="cadena">Cadena a ser analizada.</param>
        /// <param name="character">Carácter a suprimir de la cadena.</param>
        /// <returns></returns>
        public static double RemoveCharacter(string cadena, char character)
        {
            cadena = cadena.Replace('.', ',');
            var cadenaSplit = cadena.Split(character);
            var miString = "";
            for (int i = 0; i < cadenaSplit.Length; i++)
            {
                miString += cadenaSplit[i];
            }
            cadenaSplit = null;
            var r = Convert.ToDouble(miString);
            return r;//Convert.ToDouble(miString);
        }

        public static string RemoveCharacterString(string cadena, char character)
        {
            cadena = cadena.Replace('.', ',');
            var cadenaSplit = cadena.Split(character);
            var miString = "";
            for (int i = 0; i < cadenaSplit.Length; i++)
            {
                miString += cadenaSplit[i];
            }
            cadenaSplit = null;
            return miString;
        }

        public static string Split(string cadena, int numCaracters)
        {
            char[] charStr = cadena.ToCharArray();
            if (numCaracters > charStr.Length)
            {
                return cadena;
            }
            else
            {
                var rta = "";
                for (int i = 0; i < numCaracters; i++)
                {
                    rta += charStr[i];
                }
                return rta;
            }
        }

        public static string[] MiSubString(string cadena, int inicio, int medio)
        {
            short index = 3;
            string codigo = "";
            string valor = "";
            for (int i = 0; i < cadena.Length - 1; i++) 
            ///for (int i = 0; i < cadena.Length; i++)
            {
                if (i >= inicio && i <= medio)
                {
                    codigo += cadena[i];
                }
                if (i > medio)
                {
                    if (i == (index + medio)) /// 10
                    {
                        valor += ".";
                    }
                    valor += cadena[i];
                }
            }
            return new string[] { codigo, valor };
        }

        public static string[] MiSubStringPrice(string cadena, int posicionCodigo, int medio)
        {
            string codigo = "" + cadena[posicionCodigo];
            string valor = "";

            for (int i = 0; i < cadena.Length - 1; i++)
            {
                /*if (i >= inicio && i <= medio)
                {
                    codigo += cadena[i];
                }*/
                if (i > medio)
                {
                    /*if (i == 10)
                    {
                        valor += ".";
                    }*/
                    valor += cadena[i];
                }
            }
            return new string[] { codigo, valor };
        }

        public static string IncrementaConsecutivo(string numero)
        {
            var num = "";
            if (Convert.ToInt32(numero) >= 10)
            {
                num += "0" + (Convert.ToInt32(numero) + 1).ToString();
            }
            else
            {
                num += "00" + (Convert.ToInt32(numero) + 1).ToString();
            }
            return num;
        }

        /// <summary>
        /// Incrementa en una unidad un número determinado.
        /// </summary>
        /// <param name="numero">Número a incrementar.</param>
        /// <returns></returns>
        public static string NumberIncrement(string numero)
        {
            long num = 0;
            try
            {
                num = Convert.ToInt64(numero);
                num++;
                numero = CerosToLeft(numero) + num.ToString();
            }
            catch
            {
                var n = numero.Split('-');
                num = Convert.ToInt64(n[1]);
                num++;
                numero = n[0] + '-' + CerosToLeft(numero) +
                         num.ToString();
                n = null;
            }
            return numero;
        }

        /// <summary>
        /// Incrementa en una unidad un número determinado.
        /// </summary>
        /// <param name="numero">Número a incrementar.</param>
        /// <returns></returns>
        public static string SoloNumberIncrement(string numero)
        {
            long num = 0;
            try
            {
                num = Convert.ToInt64(numero);
                num++;
                if (num % 10 == 0)
                {
                    numero = CerosToLeft(numero, true) + num.ToString();
                }
                else
                {
                    numero = CerosToLeft(numero, false) + num.ToString();
                }
            }
            catch
            {
            }
            return numero;
        }

        /// <summary>
        /// Obtiene el conjunto de ceros dispuesto a la izquierda de un número.
        /// </summary>
        /// <param name="numero">Número a extraer los ceros.</param>
        /// <returns></returns>
        public static string CerosToLeft(string numero)
        {
            char[] num = numero.ToCharArray();
            string ceros = "";
            for (int i = 0; i < num.Length; i++)
            {
                if (num[i].Equals('0'))
                {
                    ceros += num[i];
                }
                else
                {
                    break;
                }
            }
            return ceros;
        }

        /// <summary>
        /// Obtiene el conjunto de ceros dispuesto a la izquierda de un número.
        /// </summary>
        /// <param name="numero">Número a extraer los ceros.</param>
        /// <returns></returns>
        public static string CerosToLeft(string numero, bool decima)
        {
            char[] num = numero.ToCharArray();
            string ceros = "";
            for (int i = 0; i < num.Length; i++)
            {
                if (num[i].Equals('0'))
                {
                    ceros += num[i];
                }
                else
                {
                    break;
                }
            }
            if (decima)
            {
                char[] arrCeros = ceros.ToCharArray();
                ceros = "";
                for (int i = 0; i < arrCeros.Length - 1; i++)
                {
                    ceros += arrCeros[i];
                }
            }
            return ceros;
        }

        public static int Aproximar(int numero, bool tipo)
        {
            var precioAprox = Convert.ToInt32(numero);
            if (precioAprox > 9)
            {
                precioAprox = 0;
                char[] precioChar = numero.ToString().ToCharArray();
                if (tipo) //Aprox centena
                {
                    if (precioChar.Length > 1)
                    {
                        var digito = Convert.ToInt32(precioChar[precioChar.Length - 2].ToString()
                                                    + precioChar[precioChar.Length - 1].ToString());
                        if (digito > 50)
                        {
                            precioAprox = numero + (100 - digito);
                        }
                        else
                        {
                            precioAprox = numero - digito;
                        }
                    }
                    else
                    {
                        precioAprox = numero;
                    }
                }
                else  //aprox decena
                {
                    if (Convert.ToInt32(precioChar[precioChar.Length - 1].ToString()) > 5)
                    {
                        precioAprox = numero + (10 - Convert.ToInt32(precioChar[precioChar.Length - 1].ToString()));
                    }
                    else
                    {
                        precioAprox = numero - Convert.ToInt32(precioChar[precioChar.Length - 1].ToString());
                    }
                }
            }
            return precioAprox;
        }

        public static int AproximacionDian(double numero)
        {
            var arr = numero.ToString().Split(',');
            if (arr.Length > 1)
            {
                if (Convert.ToInt32(arr[1]) <= 5) // No aproxima
                {
                    return Convert.ToInt32(arr[0]);
                }
                else   // Aproxima
                {
                    return Convert.ToInt32(arr[0]) + 1;
                }
            }
            else
            {
                return Convert.ToInt32(arr[0]);
            }
        }

        public static int AproximacionSobreCinco(double numero)
        {
            var arr = numero.ToString().Split(',');
            if (arr.Length > 1)
            {
                if (Convert.ToInt32(arr[1]) < 5) // No aproxima
                {
                    return Convert.ToInt32(arr[0]);
                }
                else   // Aproxima
                {
                    return Convert.ToInt32(arr[0]) + 1;
                }
            }
            else
            {
                return Convert.ToInt32(arr[0]);
            }
        }

        public static int RetiraDecima(double numero)
        {
            var arr = numero.ToString().Split(',');
            return Convert.ToInt32(arr[0]);
        }

        public static int DoubleToInt(double numero)
        {
            int num = 0;
            var arr = numero.ToString().Split(',');
            num = Convert.ToInt32(arr[0]);
            if (Convert.ToInt32(arr[1]) > 0)
            {
                num++;
            }
            return num;
        }

        public static bool NitCliente(string nit)
        {
            string[] nitSplit = nit.Split('-');
            bool nit_ = false;
            try
            {
                Convert.ToInt32(nitSplit[0]);
                nit_ = true;
            }
            catch
            {
                nit_ = false;
            }
            return nit_;
        }

        public static void CodeWeight(string code, string[] codeWeight, int indexStart, bool codeBar)
        {
            codeWeight[0] = code;
            codeWeight[1] = "0";
            if (codeBar)
            {
                if (Convert.ToInt64(code) < 0 && code.Length.Equals(14))  // negaitvo & longitud = 14
                {
                    codeWeight[0] = code.Substring(indexStart, 5);
                    codeWeight[1] = code.Substring(8, 2) + "." + code.Substring(10, 4);
                }
                else if (code.Length.Equals(13) && code[0].Equals('1')) // longitud = 13 & primer caracter es 1
                {
                    codeWeight[0] = code.Substring(indexStart, 7);
                    codeWeight[1] = code.Substring(7, 2) + "." + code.Substring(9, 4);
                }
            }
        }

        static DateTime DateNow = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

        /// DateTime validity : formato 'yyyymmdd';
        public static string MessageValidateNumbering(int currentNumber, int endNumber, int numberAlert, DateTime validity)
        {
            string msnValidateNumber = "Le restan # números de facturación.";
            string msnValidateDate = "Le restan # días de vigencia de autorización de facturación.";
            string msnValidateAll = "";

            if ((endNumber - currentNumber) <= numberAlert)
            {
                msnValidateNumber = msnValidateNumber.Replace("#", (endNumber - currentNumber).ToString());
                msnValidateAll = msnValidateNumber;
            }
            if ((validity - DateNow).Days <= 2)
            {
                //var d = (validity - DateTime.Now).Days;
                msnValidateDate = msnValidateDate.Replace("#", (validity - DateNow).Days.ToString());
                if (msnValidateNumber.Contains("#"))
                {
                    msnValidateAll = msnValidateDate;
                }
                else
                {
                    msnValidateAll = msnValidateNumber + "\n" + msnValidateDate;
                }
            }
            return msnValidateAll;
        }

        public static string AjusteDeCaracteres(string data, int tamanio)
        {
            try
            {
                string ajuste = "";
                string[] arr = new string[tamanio];
                int cont = tamanio - 1;
                for (int i = data.Length - 1; i >= 0; i--)
                {
                    arr[cont] = data[i].ToString();
                    cont--;
                }
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] == null)
                    {
                        arr[i] = " ";
                    }
                }
                foreach (var d in arr)
                {
                    ajuste += d;
                }
                return ajuste;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static string AjusteDeCaracteresDerecha(string data, int tamanio)
        {
            try
            {
                string ajuste = "";
                string[] arr = new string[tamanio];
                for (int i = data.Length - 1; i >= 0; i--)
                {
                    arr[i] = data[i].ToString();
                }
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] == null)
                    {
                        arr[i] = " ";
                    }
                }
                foreach (var d in arr)
                {
                    ajuste += d;
                }
                return ajuste;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static string AjusteDeCaracteresDerecha(string texto)
        {
            int maxLength_35 = 35;
            string stringBuilderDetalleTotal =
                FuncionEspacio(maxLength_35 - texto.Length) + texto;
            return stringBuilderDetalleTotal;
        }

        public static string AjusteDeCaracteresDerecha_(string texto)
        {
            int maxLength_27 = 27;
            string stringBuilderDetalleTotal =
                FuncionEspacio(maxLength_27 - texto.Length) + texto;
            return stringBuilderDetalleTotal;
        }

        public static List<string> StringBuilderDataCenter(string data, int maxCharacters)
        {
            List<string> stringBuilderDataCenter = new List<string>();
            List<string> stringSplitData = new List<string>();
            string dataTemp = "";
            for (int i = 0; i <= data.Length; i++)
            {
                if (!(i == data.Length))
                {
                    if (!data[i].Equals(' '))
                    {
                        dataTemp += data[i];
                    }
                    else
                    {
                        stringSplitData.Add(dataTemp);
                        dataTemp = "";
                    }
                }
                else
                {
                    stringSplitData.Add(dataTemp);
                    dataTemp = "";
                }
            }
            List<string> lstStringBuilderData = new List<string>();
            var stringBuilderData = "";
            string strTemp = "";
            int count = 0;
            foreach (var str in stringSplitData)
            {
                count++;
                if (count == 1)
                {
                    strTemp += str;
                }
                else
                {
                    strTemp += " " + str;
                }
                if (!(strTemp.Length > maxCharacters))
                {
                    stringBuilderData = strTemp;
                }
                else
                {
                    lstStringBuilderData.Add(stringBuilderData);
                    stringBuilderData = strTemp = str;
                }
                if (stringSplitData.Count == count)
                {
                    lstStringBuilderData.Add(stringBuilderData);
                }
            }
            int length_ = 0;
            int diferencia = 0;
            foreach (var stringBuilderData_ in lstStringBuilderData)
            {
                length_ = maxCharacters - stringBuilderData_.Length;
                diferencia = length_ / 2;
                if (length_ % 2 == 0)  //  Par
                {
                    stringBuilderDataCenter.Add(
                        FuncionEspacio(diferencia) +
                        stringBuilderData_ + 
                        FuncionEspacio(diferencia));
                }
                else  //                   Impar
                {
                    stringBuilderDataCenter.Add(
                        FuncionEspacio(length_ - diferencia) +
                        stringBuilderData_ + 
                        FuncionEspacio(diferencia));
                }
            }
            return stringBuilderDataCenter;
        }

        public static List<string> StringBuilderDataIzquierda(string data, int maxCharacters)
        {
            List<string> stringBuilderDataIzquierda = new List<string>();
            List<string> stringSplitData = new List<string>();
            string dataTemp = "";
            for (int i = 0; i <= data.Length; i++)
            {
                if (!(i == data.Length))
                {
                    if (!data[i].Equals(' '))
                    {
                        dataTemp += data[i];
                    }
                    else
                    {
                        stringSplitData.Add(dataTemp);
                        dataTemp = "";
                    }
                }
                else
                {
                    stringSplitData.Add(dataTemp);
                    dataTemp = "";
                }
            }
            List<string> lstStringBuilderData = new List<string>();
            var stringBuilderData = "";
            string strTemp = "";
            int count = 0;
            foreach (var str in stringSplitData)
            {
                count++;
                if (count == 1)
                {
                    strTemp += str;
                }
                else
                {
                    strTemp += " " + str;
                }
                if (!(strTemp.Length > maxCharacters))
                {
                    stringBuilderData = strTemp;
                }
                else
                {
                    lstStringBuilderData.Add(stringBuilderData);
                    stringBuilderData = strTemp = str;
                }
                if (stringSplitData.Count == count)
                {
                    lstStringBuilderData.Add(stringBuilderData);
                }
            }
            /*for (int i = 0; i < lstStringBuilderData.Count; i++)
            {
                if (i == lstStringBuilderData.Count - 1)
                {

                }
                else
                {
                    stringBuilderDataIzquierda.Add(lstStringBuilderData[i]);
                }
            }

            int length_ = 0;*/
            /*int diferencia = 0;
            foreach (var stringBuilderData_ in lstStringBuilderData)
            {
                length_ = maxCharacters - stringBuilderData_.Length;
                diferencia = length_ / 2;
                if (length_ % 2 == 0)  //  Par
                {
                    stringBuilderDataCenter.Add(
                        FuncionEspacio(diferencia) +
                        stringBuilderData_ +
                        FuncionEspacio(diferencia));
                }
                else  //                   Impar
                {
                    stringBuilderDataCenter.Add(
                        FuncionEspacio(length_ - diferencia) +
                        stringBuilderData_ +
                        FuncionEspacio(diferencia));
                }
            }*/
            return lstStringBuilderData;
        }

        public static string StringBuilderDetalleProducto(string cant, string venta, string total)
        {
            int maxLength_9 = 9;
            int maxLength_11 = 11;
            int maxLength_15 = 15;
            string stringBuilderDetalleProducto =
                FuncionEspacio(maxLength_15 - cant.Length) + cant +
                FuncionEspacio(maxLength_9 - venta.Length) + venta +
                FuncionEspacio(maxLength_11 - total.Length) + total;
            return stringBuilderDetalleProducto;
        }

        public static string StringBuilderDetalleTotal(string detalle)
        {
            int maxLength_16 = 16;
            string stringBuilderDetalleTotal =
                FuncionEspacio(maxLength_16 - detalle.Length) + detalle;
            return stringBuilderDetalleTotal;
        }

        public static string StringBuilderDetalleTotalEspacio(string detalle)
        {
            int maxLength_14 = 14;
            int espacionLength_7 = 7;
            string stringBuilderDetalleTotal =
                FuncionEspacio(maxLength_14 - detalle.Length) + detalle + FuncionEspacio(espacionLength_7);
            return stringBuilderDetalleTotal;
        }

        public static string StringBuilderDetalleTotal(string detalle, int maxLength)
        {
            string stringBuilderDetalleTotal =
                FuncionEspacio(maxLength - detalle.Length) + detalle;
            return stringBuilderDetalleTotal;
        }

        public static string TaxDetails(string gravado, string baseIva, string valorIva)
        {
            if (gravado.Length == 1)
            {
                gravado = " " + gravado;
            }
            string stringBuilderDetalleIva = "  " + gravado +
                          FuncionEspacio(18 - baseIva.Length) + baseIva +
                          FuncionEspacio(13 - valorIva.Length) + valorIva;

            return stringBuilderDetalleIva;
        }

        public static string StringBuilderDetalleIva(double gravado, string total, string baseIva, string valorIva)
        {
            int maxLength_9 = 9;
            int maxLength_10 = 10;
            int maxLength_11 = 11;
            int maxLength_12 = 12;
            int maxLength_13 = 13;
            int maxLength_14 = 14;
            string stringBuilderDetalleIva = "";
            if (gravado == 0)                        //  IVA  0%
            {
                if (total.Length < 10)
                {
                    stringBuilderDetalleIva += "  " + gravado + "%" +
                        FuncionEspacio(maxLength_11 - total.Length) + total +
                        FuncionEspacio(maxLength_10 - baseIva.Length) + baseIva +
                        FuncionEspacio(maxLength_10 - valorIva.Length) + valorIva;
                }
                else
                {
                    if (total.Length == 10)
                    {
                        stringBuilderDetalleIva += 
                            FuncionEspacio(maxLength_14 - total.Length) + total +
                            FuncionEspacio(maxLength_11 - baseIva.Length) + baseIva +
                            FuncionEspacio(maxLength_10 - valorIva.Length) + valorIva;
                    }
                    else
                    {
                        stringBuilderDetalleIva += 
                            FuncionEspacio(maxLength_13 - total.Length) + total +
                            FuncionEspacio(maxLength_12 - baseIva.Length) + baseIva +
                            FuncionEspacio(maxLength_10 - valorIva.Length) + valorIva;
                    }
                }
            }
            else
            {
                if (gravado.ToString().Length == 1)  //  IVA  5%
                {
                    if (total.Length < 10)
                    {
                        stringBuilderDetalleIva += "  " + gravado + "%" +
                            FuncionEspacio(maxLength_11 - total.Length) + total +
                            FuncionEspacio(maxLength_10 - baseIva.Length) + baseIva +
                            FuncionEspacio(maxLength_10 - valorIva.Length) + valorIva;
                    }
                    else
                    {
                        if (total.Length == 10)
                        {
                            stringBuilderDetalleIva += 
                                FuncionEspacio(maxLength_14 - total.Length) + total +
                                FuncionEspacio(maxLength_11 - baseIva.Length) + baseIva +
                                FuncionEspacio(maxLength_10 - valorIva.Length) + valorIva;
                        }
                        else
                        {
                            stringBuilderDetalleIva += 
                                FuncionEspacio(maxLength_12 - total.Length) + total +
                                FuncionEspacio(maxLength_12 - baseIva.Length) + baseIva +
                                FuncionEspacio(maxLength_11 - valorIva.Length) + valorIva;
                        }
                    }
                }
                else                                 //  IVA  19%
                {
                    if (gravado.ToString().Length == 2)  //  IVA19%
                    {
                        if (total.Length < 10)
                        {
                            stringBuilderDetalleIva += " " + gravado + "%" +
                                FuncionEspacio(maxLength_11 - total.Length) + total +
                                FuncionEspacio(maxLength_10 - baseIva.Length) + baseIva +
                                FuncionEspacio(maxLength_10 - valorIva.Length) + valorIva;
                        }
                        else
                        {
                            if (total.Length == 10)
                            {
                                stringBuilderDetalleIva +=
                                    FuncionEspacio(maxLength_13 - total.Length) + total +
                                    FuncionEspacio(maxLength_11 - baseIva.Length) + baseIva +
                                    FuncionEspacio(maxLength_11 - valorIva.Length) + valorIva;
                            }
                            else
                            {
                                stringBuilderDetalleIva +=
                                    FuncionEspacio(maxLength_11 - total.Length) + total +
                                    FuncionEspacio(maxLength_12 - baseIva.Length) + baseIva +
                                    FuncionEspacio(maxLength_11 - valorIva.Length) + valorIva;
                            }
                        }
                    }
                    else
                    {
                        if (total.Length < 10)  //10.000.000
                        {
                            stringBuilderDetalleIva += gravado + 
                                FuncionEspacio(maxLength_9 - total.Length) + total +
                                FuncionEspacio(maxLength_11 - baseIva.Length) + baseIva +
                                FuncionEspacio(maxLength_10 - valorIva.Length) + valorIva;
                        }
                        else
                        {
                        }
                    }
                }
            }
            return stringBuilderDetalleIva;
        }

        public static string StringBuilderDetalleIvaEx(string gravado, string total, string baseIva, string valorIva)
        {
            int maxLength_9 = 9;
            int maxLength_10 = 10;
            int maxLength_11 = 11;
            int maxLength_12 = 12;
            int maxLength_13 = 13;
            int maxLength_14 = 14;
            string stringBuilderDetalleIva = "";
            if (gravado == "EXEN")
            {
                if (total.Length >= 10)
                {
                    stringBuilderDetalleIva += "    " + //"%" +
                                FuncionEspacio(maxLength_10 - total.Length) + total +
                                FuncionEspacio(maxLength_10 - baseIva.Length) + baseIva +
                                FuncionEspacio(maxLength_10 - valorIva.Length) + valorIva;
                }
                else
                {
                    stringBuilderDetalleIva += gravado + //"%" +
                                FuncionEspacio(maxLength_10 - total.Length) + total +
                                FuncionEspacio(maxLength_10 - baseIva.Length) + baseIva +
                                FuncionEspacio(maxLength_10 - valorIva.Length) + valorIva;
                }
            }
            else
            {
                if (gravado == "0")                        //  IVA  0%
                {
                    if (total.Length < 10)
                    {
                        stringBuilderDetalleIva += "  " + gravado + //"%" +
                            FuncionEspacio(maxLength_11 - total.Length) + total +
                            FuncionEspacio(maxLength_10 - baseIva.Length) + baseIva +
                            FuncionEspacio(maxLength_10 - valorIva.Length) + valorIva;
                    }
                    else
                    {
                        if (total.Length == 10)
                        {
                            stringBuilderDetalleIva +=
                                FuncionEspacio(maxLength_14 - total.Length) + total +
                                FuncionEspacio(maxLength_11 - baseIva.Length) + baseIva +
                                FuncionEspacio(maxLength_10 - valorIva.Length) + valorIva;
                        }
                        else
                        {
                            stringBuilderDetalleIva +=
                                FuncionEspacio(maxLength_13 - total.Length) + total +
                                FuncionEspacio(maxLength_12 - baseIva.Length) + baseIva +
                                FuncionEspacio(maxLength_10 - valorIva.Length) + valorIva;
                        }
                    }
                }
                else
                {
                    if (gravado.ToString().Length == 1)  //  IVA  5%
                    {
                        if (total.Length < 10)
                        {
                            stringBuilderDetalleIva += "  " + gravado + //"%" +
                                FuncionEspacio(maxLength_11 - total.Length) + total +
                                FuncionEspacio(maxLength_10 - baseIva.Length) + baseIva +
                                FuncionEspacio(maxLength_10 - valorIva.Length) + valorIva;
                        }
                        else
                        {
                            if (total.Length == 10)
                            {
                                stringBuilderDetalleIva +=
                                    FuncionEspacio(maxLength_14 - total.Length) + total +
                                    FuncionEspacio(maxLength_11 - baseIva.Length) + baseIva +
                                    FuncionEspacio(maxLength_10 - valorIva.Length) + valorIva;
                            }
                            else
                            {
                                stringBuilderDetalleIva +=
                                    FuncionEspacio(maxLength_12 - total.Length) + total +
                                    FuncionEspacio(maxLength_12 - baseIva.Length) + baseIva +
                                    FuncionEspacio(maxLength_11 - valorIva.Length) + valorIva;
                            }
                        }
                    }
                    else                                 //  IVA  19%
                    {
                        if (total.Length < 10)
                        {
                            stringBuilderDetalleIva += " " + gravado + //"%" +
                                FuncionEspacio(maxLength_11 - total.Length) + total +
                                FuncionEspacio(maxLength_10 - baseIva.Length) + baseIva +
                                FuncionEspacio(maxLength_10 - valorIva.Length) + valorIva;
                        }
                        else
                        {
                            if (total.Length == 10)
                            {
                                stringBuilderDetalleIva +=
                                    FuncionEspacio(maxLength_13 - total.Length) + total +
                                    FuncionEspacio(maxLength_11 - baseIva.Length) + baseIva +
                                    FuncionEspacio(maxLength_11 - valorIva.Length) + valorIva;
                            }
                            else
                            {
                                stringBuilderDetalleIva +=
                                    FuncionEspacio(maxLength_11 - total.Length) + total +
                                    FuncionEspacio(maxLength_12 - baseIva.Length) + baseIva +
                                    FuncionEspacio(maxLength_11 - valorIva.Length) + valorIva;
                            }
                        }
                    }
                }
            }
            return stringBuilderDetalleIva;
        }

        public static string StringBuilderDetalleINCBP(string vUnitario, string cantidad, string total)
        {
            string stringBuilderDetalleINCBP = "";
            int maxLength_11 = 11;
            int maxLength_12 = 12;
            stringBuilderDetalleINCBP +=
                FuncionEspacio(maxLength_12 - vUnitario.Length) + vUnitario +
                FuncionEspacio(maxLength_11 - cantidad.Length) + cantidad +
                FuncionEspacio(maxLength_12 - total.Length) + total;
            return stringBuilderDetalleINCBP;
        }

        public static List<string> StringBuilderDetalleDIAN(string detalle, int maxCharacters)
        {
            List<string> stringSplitData = new List<string>();
            string dataTemp = "";
            for (int i = 0; i <= detalle.Length; i++)
            {
                if (!(i == detalle.Length))
                {
                    if (!detalle[i].Equals(' '))
                    {
                        dataTemp += detalle[i];
                    }
                    else
                    {
                        stringSplitData.Add(dataTemp);
                        dataTemp = "";
                    }
                }
                else
                {
                    stringSplitData.Add(dataTemp);
                    dataTemp = "";
                }
            }
            List<string> stringBuilderDetalleDIAN = new List<string>();
            var stringBuilderData = "";
            string strTemp = "";
            int count = 0;
            foreach (var str in stringSplitData)
            {
                count++;
                if (count == 1)
                {
                    strTemp += str;
                }
                else
                {
                    strTemp += " " + str;
                }
                if (!(strTemp.Length > maxCharacters))
                {
                    stringBuilderData = strTemp;
                }
                else
                {
                    stringBuilderDetalleDIAN.Add(stringBuilderData);
                    stringBuilderData = strTemp = str;
                }
                if (stringSplitData.Count == count)
                {
                    if (stringBuilderDetalleDIAN.Count > 0)
                    {
                        stringBuilderDetalleDIAN.Add(FuncionEspacio(maxCharacters - stringBuilderData.Length) + stringBuilderData);
                    }
                    else
                    {
                        stringBuilderDetalleDIAN.Add(stringBuilderData);
                    }
                }
            }
            return stringBuilderDetalleDIAN;
        }

        public static List<string> StringBuilderDetalleValor(string detalle, string valor, int maxCharacters)
        {
            List<string> stringBuilderDetalleValor = new List<string>();
            if ((detalle + valor).Length >= maxCharacters)
            {
                List<string> stringSplitData = new List<string>();
                string dataTemp = "";
                for (int i = 0; i <= detalle.Length; i++)
                {
                    if (!(i == detalle.Length))
                    {
                        if (!detalle[i].Equals(' '))
                        {
                            dataTemp += detalle[i];
                        }
                        else
                        {
                            stringSplitData.Add(dataTemp);
                            dataTemp = "";
                        }
                    }
                    else
                    {
                        stringSplitData.Add(dataTemp);
                        dataTemp = "";
                    }
                }

                var stringBuilderData = "";
                string strTemp = "";
                int count = 0;
                foreach (var str in stringSplitData)
                {
                    count++;
                    if (count == 1)
                    {
                        strTemp += str;
                    }
                    else
                    {
                        strTemp += " " + str;
                    }
                    if (!(strTemp.Length > (maxCharacters - valor.Length - 2)))
                    {
                        stringBuilderData = strTemp;
                    }
                    else
                    {
                        stringBuilderDetalleValor.Add(stringBuilderData);
                        stringBuilderData = strTemp = str;
                    }
                    if (stringSplitData.Count == count)
                    {
                        if (stringBuilderDetalleValor.Count > 0)
                        {
                            //stringBuilderDetalleValor.Add(FuncionEspacio(maxCharacters - stringBuilderData.Length) + stringBuilderData);
                            stringBuilderDetalleValor.Add(
                                stringBuilderData + FuncionEspacio(maxCharacters - stringBuilderData.Length - valor.Length) + valor);
                        }
                        else
                        {
                            stringBuilderDetalleValor.Add(stringBuilderData);
                        }
                    }
                }
            }
            else
            {
                stringBuilderDetalleValor.Add(detalle + FuncionEspacio(maxCharacters - detalle.Length - valor.Length) + valor);
            }
            return stringBuilderDetalleValor;


            /*
            List<string> stringSplitData = new List<string>();
            string dataTemp = "";
            for (int i = 0; i <= detalle.Length; i++)
            {
                if (!(i == detalle.Length))
                {
                    if (!detalle[i].Equals(' '))
                    {
                        dataTemp += detalle[i];
                    }
                    else
                    {
                        stringSplitData.Add(dataTemp);
                        dataTemp = "";
                    }
                }
                else
                {
                    stringSplitData.Add(dataTemp);
                    dataTemp = "";
                }
            }
            List<string> stringBuilderDetalleDIAN = new List<string>();
            var stringBuilderData = "";
            string strTemp = "";
            int count = 0;
            foreach (var str in stringSplitData)
            {
                count++;
                if (count == 1)
                {
                    strTemp += str;
                }
                else
                {
                    strTemp += " " + str;
                }
                if (!(strTemp.Length > maxCharacters))
                {
                    stringBuilderData = strTemp;
                }
                else
                {
                    stringBuilderDetalleDIAN.Add(stringBuilderData);
                    stringBuilderData = strTemp = str;
                }
                if (stringSplitData.Count == count)
                {
                    if (stringBuilderDetalleDIAN.Count > 0)
                    {
                        stringBuilderDetalleDIAN.Add(FuncionEspacio(maxCharacters - stringBuilderData.Length) + stringBuilderData);
                    }
                    else
                    {
                        stringBuilderDetalleDIAN.Add(stringBuilderData);
                    }
                }
            }
            return stringBuilderDetalleDIAN;*/
        }

        public static string FuncionEspacio(int lengthEspacio)
        {
            string espacio = "";
            for (int i = 1; i <= lengthEspacio; i++)
            {
                espacio += " ";
            }
            return espacio;
        }

        public static string AnadirCeroEnUnidad(int numeroUnidad)
        {
            string valor = "";
            if (numeroUnidad < 10)
            {
                valor = "0" + numeroUnidad;
            }
            else
            {
                valor = numeroUnidad.ToString();
            }
            return valor;
        }
    }
}