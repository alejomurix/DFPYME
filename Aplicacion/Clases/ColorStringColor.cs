using System;

namespace Aplicacion.Clases
{
    /// <summary>
    /// Representa una clase para manipular colores y sus mapas de bits.
    /// </summary>
    public class ColorStringColor
    {
        /// <summary>
        /// Establece la carpeta temporal donde se almacenara la imagen.
        /// </summary>
        private const string folder = "C:\\ImagesTemp";

        /// <summary>
        /// Establece el nombre y extencion de la imagen que se almacenara. Por defecto es .JPEG.
        /// </summary>
        private const string file = "temp.jpg";

        /// <summary>
        /// Estabelce la ruta y el nombre del archivo completo.
        /// </summary>
        private const string rutaYArchivo = folder + "\\" + file;

        /// <summary>
        /// Representa el texto: Ocurrio un error al crear el color.
        /// </summary>
        private const string errorConversion = "Ocurrio un error al crear el color. ";

        /// <summary>
        /// Inicializa una nueva instancia de la clase ColorStringColor.
        /// </summary>
        public ColorStringColor()
        {
            if (!System.IO.Directory.Exists(folder))
            {
                System.IO.Directory.CreateDirectory(folder);
                System.IO.File.SetAttributes
                    (folder, System.IO.FileAttributes.Hidden);
            }
        }

        /// <summary>
        /// Obtiene un string Base64 que representa el mapa de bits del color.
        /// </summary>
        /// <param name="colorSelecionado">Color seleccionado.</param>
        /// <returns></returns>
        public string ImagenComoString
            (System.Windows.Forms.PictureBox colorSelecionado)
        {
            AlmacenarImagen(colorSelecionado);

            string sBase64 = "";
            System.IO.FileStream fs = new System.IO.FileStream
                (rutaYArchivo, System.IO.FileMode.Open);

            System.IO.BinaryReader br = new System.IO.BinaryReader(fs);

            byte[] bytes = new byte[(int)fs.Length];

            try
            {
                br.Read(bytes, 0, bytes.Length);
                sBase64 = Convert.ToBase64String(bytes);
                return sBase64;
            }
            catch
            {
                throw new Exception(errorConversion);
            }
            finally
            {
                fs.Close();
                fs = null;
                br = null;
                bytes = null;
            }
        }

        /// <summary>
        /// Almacena el color como una imagen en un archivo y carpeta temporal.
        /// </summary>
        /// <param name="colorSelecionado">Color seleccionado.</param>
        private void AlmacenarImagen
                ( System.Windows.Forms.PictureBox colorSelecionado ) 
        {
            colorSelecionado.Image = new System.Drawing.Bitmap
                (colorSelecionado.Width, colorSelecionado.Height);

            System.Drawing.Graphics grafico = System.Drawing.Graphics.FromImage
                (colorSelecionado.Image);

            grafico.Clear(colorSelecionado.BackColor);

            colorSelecionado.Image.Save
                (rutaYArchivo, System.Drawing.Imaging.ImageFormat.Jpeg);

        }
    }
}