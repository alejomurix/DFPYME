using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO.Clases;
using DataAccessLayer.Clases;
using System.Data;
using System.Collections;

namespace BussinesLayer.Clases
{
    public class BussinesCategoria
    {
        private DaoCategoria miCategoria = new DaoCategoria();

        public bool ExisteNombreCategoria(string nombre)
        {
            return miCategoria.ExisteNombreCategoria(nombre);
        }

        /// <summary>
        /// inserta objeto categoria
        /// </summary>
        /// <param name="categoria"></param>
        public void insertarCategoria(Categoria categoria)
        {
            miCategoria.InsertarCategoria(categoria);
        }

        /// <summary>
        /// lista objeto categoria
        /// </summary>
        /// <returns> lista categooria</returns>
        public DataTable ListarCategoria(int registroBase, int registroMaximo)
        {
            return miCategoria.ListadoCategoria(registroBase, registroMaximo);
        }

        public DataTable ListadoCategoria()
        {
            return miCategoria.ListadoCategoria();
        }

        /// <summary>
        /// Obtiene el total de los registros de categoria.
        /// </summary>
        /// <returns></returns>
        public long RowTotalCategoria()
        {
            return miCategoria.RowListarcategoria();
        }

        /// <summary>
        /// Obtiene el cogigo interno de categoria.
        /// </summary>
        /// <returns></returns>
        public int ObtenerCodigocategoria()
        {
            return miCategoria.ObtenerCodigoCategoria();
        }

        /// <summary>
        /// lista objeto categoria
        /// </summary>
        /// <param name="codigoCategoria">parametro a buscar</param>
        /// <returns>lista categoria por codigo</returns>
        public ArrayList FiltrarcategoriaCodigo(string codigoCategoria)
        {
            return miCategoria.FiltrarCategoriaCodigoContenga(codigoCategoria);

        }

        /// <summary>
        /// Obtiene el resultado de la consulta de Categoría por Nombre.
        /// </summary>
        /// <param name="nombreCategoria">Nombre o parte de este de la Categoría.</param>
        /// <param name="registroBase">Registro base para la consulta.</param>
        /// <param name="registroMaximo">Registro máximos recuperados en la consulta.</param>
        /// <returns></returns>
        public DataTable Filtrarcategorianombre
            (string nombreCategoria, int registroBase, int registroMaximo)
        {
            var tabla = miCategoria.FiltroCategoriaNombreContenga
                (nombreCategoria, registroBase, registroMaximo);
            var miTabla = CrearTablaCategoria();
            foreach (DataRow row in tabla.Rows)
            {
                var row_ = miTabla.NewRow();
                row_["CodigoCategoria"] = row["CodigoCategoria"];
                row_["NombreCategoria"] = row["NombreCategoria"];
                row_["DescripcionCategoria"] = row["DescripcionCategoria"];
                var estado = (bool)row["estadocategoria"];
                if (estado)
                {
                    row_["TextoEstado"] = "Activo";
                }
                else
                {
                    row_["TextoEstado"] = "Inactivo";
                }
                miTabla.Rows.Add(row_);
            }
            tabla.Clear();
            tabla = null;
            return miTabla;
        }

        public DataTable ConsultaPorNombre(string nombre)
        {
            return miCategoria.ConsultaPorNombre(nombre);
        }

        /// <summary>
        /// Obtiene el total de registros de una consulta por Nombre de Categoría.
        /// </summary>
        /// <param name="nombre">Nombre o parte de este de la Categoría.</param>
        /// <returns></returns>
        public long RowFiltroCategoriaNombreContenga(string nombre)
        {
            return miCategoria.RowFiltroCategoriaNombreContenga(nombre);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigocategoria"></param>
        /// <returns></returns>
        public ArrayList consultaCategoriaCodigo(string codigocategoria)
        {
            return miCategoria.ConsultaCategoriaCodigoIgual(codigocategoria);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombrecategoria"></param>
        /// <returns></returns>
        public ArrayList consultarCategoriaNombre(string nombrecategoria)
        {
            return miCategoria.ConsultaCategoriaNombreIgual(nombrecategoria);
        }

        /// <summary>
        /// modifica  objeto categoria
        /// </summary>
        /// <param name="categoria"></param>
        public void ModificarCategoria(Categoria categoria)
        {
            miCategoria.ModificarCategoria(categoria);
        }

        /// <summary>
        /// elimina objeto categoria
        /// </summary>
        /// <param name="categoria"></param>
        public void EliminarCategoria(string codigo)
        {
            miCategoria.EliminarCategoria(codigo);
        }

        /// <summary>
        /// determina si el codigo categoria sea true o fanse 
        /// </summary>
        public bool existecategoria(string codigo)
        {
            return miCategoria.ExisteCategoria(codigo);
        }

        public List<Categoria> ResumenVentasTodasCategorias(List<Categoria> categorias, DateTime fecha, DateTime fecha2, bool fecha_)
        {
            return this.miCategoria.ResumenVentasTodasCategorias(categorias, fecha, fecha2, fecha_);
        }

        public Categoria CategoriaData(Categoria categoria, DateTime fecha)
        {
            return this.miCategoria.CategoriaData(categoria, fecha);
        }

        public Categoria CategoriaData(Categoria categoria, DateTime fecha, DateTime fehca2)
        {
            return this.miCategoria.CategoriaData(categoria, fecha, fehca2);
        }

        /// <summary>
        /// Obtien una tabla de memoria de Categoria.
        /// </summary>
        /// <returns></returns>
        private DataTable CrearTablaCategoria()
        {
            var tabla = new DataTable();
            tabla.Columns.Add(new DataColumn("CodigoCategoria", typeof(string)));
            tabla.Columns.Add(new DataColumn("NombreCategoria", typeof(string)));
            tabla.Columns.Add(new DataColumn("DescripcionCategoria", typeof(string)));
            tabla.Columns.Add(new DataColumn("TextoEstado", typeof(string)));
            return tabla;
        }

        public void AjustarCodigosCategoria()
        {
            miCategoria.AjustarCodigosCategoria();
        }


        // Ajustes de IVA en Categoria.

        public void CambiarIva(string codCategoria, int idIva)
        {
            this.miCategoria.CambiarIva(codCategoria, idIva);
        }

        public void RestablecerIva(string codCategoria)
        {
            this.miCategoria.RestablecerIva(codCategoria);
        }
    }
}