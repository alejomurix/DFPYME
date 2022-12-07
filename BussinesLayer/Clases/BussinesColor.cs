using System;
using System.Collections.Generic;
using System.Data;
using DataAccessLayer.Clases;
using DTO.Clases;

namespace BussinesLayer.Clases
{
    /// <summary>
    /// Representa una clase de logica de negocios de Color.
    /// </summary>
    public class BussinesColor
    {
        /// <summary>
        /// Representa un objeto de transeferecia a Base de Datos de Color.
        /// </summary>
        private DaoColor miDaoColor;

        /// <summary>
        /// Inicializa una nueva Instancia de la clase BussinesColor.
        /// </summary>
        public BussinesColor()
        {
            miDaoColor = new DaoColor();
        }

        /// <summary>
        /// Verifica si un color existe en la base de datos.
        /// </summary>
        /// <param name="color">String del color a verificar.</param>
        /// <returns></returns>
        public bool ExisteColor(string color)
        {
            return miDaoColor.ExisteColor(color);
        }
        
        /// <summary>
        /// Ingresa un registro de ElColor en la base de datos y retorna el Id generado.
        /// </summary>
        /// <param name="color">Color a ingresar.</param>
        /// <returns></returns>
        public int InsertarColor(ElColor color)
        {
            return miDaoColor.InsertarColor(color);
        }

        /// <summary>
        /// Obtiene el listado de los colores de la base de datos.
        /// </summary>
        /// <returns></returns>
        public List<ElColor> ListadoDeColores()
        {
            return miDaoColor.ListadoDeColores();
        }

        /// <summary>
        /// Obtiene el listado de colores relacionados a un Producto.
        /// </summary>
        /// <param name="codigo">Código del Producto a consultar.</param>
        /// <param name="idMedida">Id de la medida del Producto.</param>
        /// <returns></returns>
        public DataTable ColoresDeProducto(string codigo, int idMedida)
        {
            var tabla = miDaoColor.ColoresDeProducto(codigo, idMedida);
            var tablaTemp = TablaColor();
            var elColor = new ElColor();
            foreach (DataRow row in tabla.Rows)
            {
                var row_ = tablaTemp.NewRow();
                elColor.MapaBits = row["stringcolor"].ToString();
                row_["IdColor"] = row["idcolor"];
                row_["ImagenBit"] = elColor.ImagenBit;
                tablaTemp.Rows.Add(row_);
            }
            tabla.Clear();
            tabla = null;
            return tablaTemp;
        }

        /// <summary>
        /// Obtiene una tabla en memoria de la Clase ElColor.
        /// </summary>
        /// <returns></returns>
        private DataTable TablaColor()
        {
            var tabla = new DataTable();
            tabla.Columns.Add(new DataColumn("IdColor", typeof(int)));
            tabla.Columns.Add(new DataColumn("ImagenBit", typeof(System.Drawing.Bitmap)));
            return tabla;
        }
    }
}