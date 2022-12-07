using System;
using System.Drawing;
using System.IO;

namespace DTO.Clases
{
    /// <summary>
    /// Representa una clase para la manipulacio de colores.
    /// </summary>
    public class ElColor
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase ElColor.
        /// </summary>
        public ElColor()
        {
            this.IdColor = 0;
            this.MapaBits = "";
        }

        /// <summary>
        /// Obtiene o establece el valor del Id del color.
        /// </summary>
        public int IdColor { set; get; }

        /// <summary>
        /// Obtiene o establece los caracteres que representan le mapa de bits del color.
        /// </summary>
        public string MapaBits { set; get; }

        /// <summary>
        /// Obtiene el color en una imagen de mapa de bits.
        /// </summary>
        public Bitmap ImagenBit
        {
            get
            {
                MemoryStream ms = new MemoryStream
                 (Convert.FromBase64String(this.MapaBits));
                Bitmap img = new Bitmap(ms);
                return img;
            }
        }

        /// <summary>
        /// Obtiene o establece la imagen a mostrar.
        /// </summary>
        public Image Imagen { set; get; }
    }
}