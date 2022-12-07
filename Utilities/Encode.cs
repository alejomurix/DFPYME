using System;
using System.Text;
using System.Security.Cryptography;

namespace Utilities
{
    /// <summary>
    /// Representa una clase para encryptar texto.
    /// </summary>
    public class Encode
    {
        /// <summary>
        /// Clave para cifrar y decifrar los datos. Debe ser la misma en todos los casos usados.
        /// </summary>
        static string key = "http://www.solucionestecnologicasayc.com/";

        /// <summary>
        /// Obtiene una cadena encriptada.
        /// </summary>
        /// <param name="text">Texto a encriptar.</param>
        /// <returns></returns>
        public static string Encrypt(string text)
        {
            //Arreglo donde guradaremos la clave.
            byte[] keyArray;

            //Arreglo donde guardaremos el texto que vamos a encriptar.
            byte[] textArray = UTF8Encoding.UTF8.GetBytes(text);

            //Utilizamos el Algoritmo MD5 del Framework.
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();

            //Guardamos la clave para que se le realiza hashing.
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));

            hashmd5.Clear();

            //Algoritmo 3DAS
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();

            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            //Se transforma la cadena.
            ICryptoTransform cTransform = tdes.CreateEncryptor();

            //Arreglo donde se guarda la cadena cifrada.
            byte[] ArrayResultado = 
                cTransform.TransformFinalBlock(textArray, 0, textArray.Length);

            tdes.Clear();

            return Convert.ToBase64String(ArrayResultado, 0, ArrayResultado.Length);
        }

        /// <summary>
        /// Obtiene una cadena desencriptada.
        /// </summary>
        /// <param name="text">Texto a desencriptar.</param>
        /// <returns></returns>
        public static string Decrypt(string text)
        {
            byte[] keyArray;

            //Convierte el texto en una secuencia de bytes
            byte[] textArray = Convert.FromBase64String(text);

            //Utilizamos el algoritmo MD5 de encriptacion y realizamos el hashing.
            MD5CryptoServiceProvider hasmd5 = new MD5CryptoServiceProvider();

            keyArray = hasmd5.ComputeHash(
                UTF8Encoding.UTF8.GetBytes(key));

            hasmd5.Clear();

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();

            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();

            byte[] resutlArray = cTransform.TransformFinalBlock(textArray, 0, textArray.Length);

            tdes.Clear();

            return UTF8Encoding.UTF8.GetString(resutlArray);
        }
    }
}