using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO.Clases;
using DataAccessLayer.Clases;
using System.Data;

namespace BussinesLayer.Clases
{
     public class BussinesPromocion
    {
        private DaoPromocion midaoPromocion=new DaoPromocion();


        /// <summary>
        /// Insertar promoción
        /// </summary>
        /// <param name="promocion">objeto promoción a ingresar</param>
         public void InsertarPromocion(Promocion promocion)
         {
             midaoPromocion.InsertarPromocion(promocion);
         }

         /// <summary>
         /// Editar Promoción
         /// </summary>
         /// <param name="promocion">objeto promoción a editar</param>
         public void EditarPromocion(Promocion promocion)
         {
             midaoPromocion.EditarPromocion(promocion);
         }

         /// <summary>
         /// Eliminar promoción
         /// </summary>
         /// <param name="idPromocion">id promoción a eliminar</param>
         public void EliminaPromocion(int idPromocion)
         {
             midaoPromocion.EliminaPromocion(idPromocion);
         }

         /// <summary>
         /// Consulta promoción marca fecha
         /// </summary>
         /// <param name="idTipo">id tipo promoción(marca)a consultar</param>
         /// <param name="idMarca">id marca a consultar</param>
         /// <param name="fecha">fecha a consultar</param>
         /// <returns></returns>
         public DataTable ConsultarPromocionMarcaFechas(int idTipo, int idMarca, DateTime fecha)
         {
              return midaoPromocion.ConsultarPromocionMarcaFechas(idTipo, idMarca, fecha);
         }

         /// <summary>
         /// Consulta promoción tipo marca fechas
         /// </summary>
         /// <param name="idTipo">id tipo promoción(marca)a consultar</param>
         /// <param name="fecha">fechas a consultar</param>
         /// <param name="registroBase">registro base de la consulta</param>
         /// <param name="registroMaximo">número de registros a recuperar</param>
         /// <returns></returns>
         public DataTable ConsultarPromocionMarcaFechas(int idTipo, DateTime fecha, int registroBase, int registroMaximo)
         {
             return midaoPromocion.ConsultarPromocionMarcaFechas(idTipo, fecha, registroBase, registroMaximo);
         }

         /// <summary>
         /// Obtiene el total de los registros de promoción marca fechas
         /// </summary>
         /// <param name="idTipo">id tipo promoción(marca)a consultar</param>
         /// <param name="fechas">fechas a consular</param>
         /// <returns></returns>
         public long RowListarPromocionMarca(int idTipo, DateTime fechas)
         {
             return midaoPromocion.RowListarPromocionMarca(idTipo, fechas);
         }

         /// <summary>
         /// Consulta promoción marca periodo
         /// </summary>
         /// <param name="idTipo">id tipo promoción(marca)a consultar</param>
         /// <param name="idMarca">id marca a consultar</param>
         /// <param name="fecha1">fecha inicio a consultar</param>
         /// <param name="fecha2">fecha fin a consultar</param>
         /// <returns></returns>
         public DataTable ConsultarPromocionMarcaPeriodo(int idTipo, int idMarca, DateTime fecha1, DateTime fecha2, int registroBase, int registroMaximo)
         {
             return midaoPromocion.ConsultarPromocionMarcaPeriodo(idTipo, idMarca, fecha1, fecha2, registroBase ,registroMaximo);
         }

         /// <summary>
         /// Obtiene al total de los registros de promoción marca fechas
         /// </summary>
         /// <param name="idTipo"> id tipo promoción(marca)a consultar</param>
         /// <param name="idMarca">id marca a consultar</param>
         /// <param name="fecha1">fecha inicio a consultar</param>
         /// <param name="fecha2">fecha fin a consultar</param>
         /// <returns></returns>
         public long RowListarPromocionMarcafechas(int idTipo, int idMarca, DateTime fecha1, DateTime fecha2)
         {
             return midaoPromocion.RowListarPromocionMarcaFechas(idTipo, idMarca, fecha1, fecha2);
         }

         /// <summary>
         /// Consulta promoción tipo marca periodos
         /// </summary>
         /// <param name="idTipo">id tipo promoción(marca)a consultar</param>
         /// <param name="fecha1">fecha inicio a consultar</param>
         /// <param name="fecha2">fecha fin a consultar</param>
         /// <param name="registroBase">registro base de la consulta</param>
         /// <param name="registroMaximo">número de registros a recuperar</param>
         /// <returns></returns>
         public DataTable ConsultarPromocionMarcaPeriodo(int idTipo, DateTime fecha1, DateTime fecha2, int registroBase, int registroMaximo)
         {
             return midaoPromocion.ConsultarPromocionMarcaPeriodo(idTipo, fecha1, fecha2, registroBase, registroMaximo);
         }

         /// <summary>
         /// Obtiene el total de los registros de promoción marca periodos
         /// </summary>
         /// <param name="idTipo">id tipo promoción (marca) a consultar</param>
         /// <param name="fecha1">fecha inicio a consultar</param>
         /// <param name="fecha2">fecha fin a consultar</param>
         /// <returns></returns>
         public long RowListarPromocionMarca(int idTipo, DateTime fecha1, DateTime fecha2)
         {
             return midaoPromocion.RowListarPromocionMarca(idTipo, fecha1, fecha2);
         }

         /// <summary>
         /// Consulta Promoción Categoría fechas
         /// </summary>
         /// <param name="idTipo">id tipo promoción(categoría)a consultar</param>
         /// <param name="codigoCategoria">código categoría a consultar</param>
         /// <param name="fecha">fecha a consultar</param>
         /// <returns></returns>
         public DataTable ConsultarPromocionCategoriaFechas(int idTipo, string codigoCategoria, DateTime fecha)
         {
             return midaoPromocion.ConsultarPromocionCategoriaFechas(idTipo, codigoCategoria, fecha);
         }

         /// <summary>
         /// Consulta promoción tipo categoría fechas
         /// </summary>
         /// <param name="idTipo">id tipo promoción(categoría) a consultar</param>
         /// <param name="fecha">fecha a consultar</param>
         /// <param name="registroBase">registro base de la consulta</param>
         /// <param name="registromaximo">número de registros a recuperar</param>
         /// <returns></returns>
         public DataTable ConsultarPromocionCategoriaFechas(int idTipo, DateTime fecha, int registroBase, int registromaximo)
         {
             return midaoPromocion.ConsultarPromocionCategoriaFechas(idTipo, fecha, registroBase, registromaximo);
         }

         /// <summary>
         /// Obtiene el total de los registros de promoción categoría fechas.
         /// </summary>
         /// <param name="idTipo">id tipo promoción(categorial)a consultar</param>
         /// <param name="fechas">fecha a consultar</param>
         /// <returns></returns>
         public long RowListarPromocionCategoria(int idTipo, DateTime fechas)
         {
             return midaoPromocion.RowListarPromocionCategoria(idTipo, fechas);
         }

         /// <summary>
         /// Consulta promoción categoría periodo
         /// </summary>
         /// <param name="idTipo">id tipo promoción (categoría)a consultar</param>
         /// <param name="codigoCategoria">código categoría a consultar</param>
         /// <param name="fecha">fecha a consultar</param>
         /// <returns></returns>
         public DataTable ConsultarPromocionCategoriaPeriodo(int idTipo, string codigoCategoria, DateTime fecha, DateTime fecha2, int registroBase,int registroMaximo)
         {
             return midaoPromocion.ConsultarPromocionCategoriaPeriodo(idTipo, codigoCategoria, fecha, fecha2, registroBase, registroMaximo);
         }

         /// <summary>
         /// Obtiene al total de los registros de promoción categoría fechas.
         /// </summary>
         /// <param name="idTipo"> id tipo promoción(fechas)a consultar</param>
         /// <param name="codigoCategoria">código categoría a consultar</param>
         /// <param name="fecha1">fecha inicio a consultar</param>
         /// <param name="fecha2">fecha fin a consultar</param>
         /// <returns></returns>
         public long RowListarPromocionCategoriaFechas(int idTipo, string codigoCategoria, DateTime fecha1, DateTime fecha2)
         {
             return midaoPromocion.RowListarPromocionCategoriafechas(idTipo, codigoCategoria, fecha1, fecha2);
         }

         /// <summary>
         /// Consulta promoción tipo categoría periodo
         /// </summary>
         /// <param name="idTipo">id tipo promoción(categoría) a consultar</param>
         /// <param name="fecha1">fecha inicio a consultar</param>
         /// <param name="fecha2">fecha fin a consultar</param>
         /// <param name="registroBase">registro base de la consulta</param>
         /// <param name="registroMaximo">número de registros a recuperar</param>
         /// <returns></returns>
         public DataTable ConsultarPromocionCategoriaPeriodo(int idTipo, DateTime fecha1, DateTime fecha2, int registroBase, int registroMaximo)
         {
             return midaoPromocion.ConsultarPromocionCategoriaPeriodo(idTipo, fecha1, fecha2, registroBase, registroMaximo);
         }

         /// <summary>
         /// Obtiene el total delos registros de promoción categoría periodo.
         /// </summary>
         /// <param name="idTipo">id tipo promoción(categoría)a consultar</param>
         /// <param name="fecha1">fecha inicio a consultar</param>
         /// <param name="fecha2">fecha fin a consultar</param>
         /// <returns></returns>
         public long RowListarPromocionCategoria(int idTipo, DateTime fecha1, DateTime fecha2)
         {
             return midaoPromocion.RowListarPromocionCategoria(idTipo, fecha1, fecha2);
         }

         /// <summary>
         /// Consultar promoción producto fechas
         /// </summary>
         /// <param name="idTipo">id tipo promoción(producto)a consultar</param>
         /// <param name="codigoInternoProducto">código interno producto a consultar</param>
         /// <param name="fecha">fecha a consultar</param>
         /// <returns></returns>
         public DataTable ConsultarPromocionProductoFechas(int idTipo, string codigoInternoProducto, DateTime fecha)
         {
             return midaoPromocion.ConsultarPromocionProductoFechas(idTipo, codigoInternoProducto, fecha);
         }

         /// <summary>
         /// Consulta promoción tipo producto fecha
         /// </summary>
         /// <param name="idTipo">id tipo promoción(producto)a consultar</param>
         /// <param name="fecha">fecha a consultar</param>
         /// <param name="registroBase">registro base de la consulta</param>
         /// <param name="registroMaximo">número de registros a recuperar</param>
         /// <returns></returns>
         public DataTable ConsultarPromocionProductoFechas(int idTipo, DateTime fecha, int registroBase, int registroMaximo)
         {
             return midaoPromocion.ConsultarPromocionProductoFechas(idTipo, fecha, registroBase, registroMaximo);
         }

         /// <summary>
         /// Obtiene el total de los registros de promoción producto
         /// </summary>
         /// <param name="idTipo">id tipo promoción(producto)a consultar</param>
         /// <param name="fechas">fechas a consultar</param>
         /// <returns></returns>
         public long RowListarPromocionProducto(int idTipo, DateTime fechas)
         {
             return midaoPromocion.RowListarPromocionProducto(idTipo, fechas);
         }

         /// <summary>
         /// Consultar promoción producto periodo
         /// </summary>
         /// <param name="idTipo">id tipo promoción(producto)a consultar</param>
         /// <param name="codigoInternoProducto">código interno producto a consultar</param>
         /// <param name="fecha1">fecha inicio a consultar</param>
         /// <param name="fecha2">fecha fin a consultar</param>
         /// <returns></returns>
         public DataTable ConsultarPromocionProductoPeriodo(int idTipo, string codigoInternoProducto, DateTime fecha1, DateTime fecha2, int registroBase,int registroMaximo)
         {
             return midaoPromocion.ConsultarPromocionProductoPeriodo(idTipo, codigoInternoProducto, fecha1, fecha2, registroBase, registroMaximo);
         }

         /// <summary>
         /// Obtiene el total de los registros de promoción producto fechas
         /// </summary>
         /// <param name="idTipo"> id tipo promoción(producto) a consultar</param>
         /// <param name="codigoInternoProducto"> código interno producto a consultar</param>
         /// <param name="fecha1">fecha inicio a consultar</param>
         /// <param name="fecha2">fecah fin a consultar</param>
         /// <returns></returns>
         public long RowListarPromocionProductoFechas(int idTipo, string codigoInternoProducto, DateTime fecha1, DateTime fecha2)
         {
             return midaoPromocion.RowListarPromocionProductoFechas(idTipo, codigoInternoProducto, fecha1, fecha2);
         }

         /// <summary>
         /// Consultar promoción Tipo Producto periodo
         /// </summary>
         /// <param name="idTipo">id tipo promoción(producto)a consultar</param>
         /// <param name="fecha1">fecha inicio a consultar</param>
         /// <param name="fecha2">fecha fin a consultar</param>
         /// <param name="registroBase">registro base de la consulta</param>
         /// <param name="registroMaximo">número de registros a recuperar</param>
         /// <returns></returns>
         public DataTable ConsultarPromocionProductoPeriodo(int idTipo, DateTime fecha1, DateTime fecha2, int registroBase, int registroMaximo)
         {
             return midaoPromocion.ConsultarPromocionProductoPeriodo(idTipo, fecha1, fecha2, registroBase, registroMaximo);
         }

         /// <summary>
         /// Obtiene el total de los registros de promoción producto periodo
         /// </summary>
         /// <param name="idTipo">id tipo promoción(producto) a consultar</param>
         /// <param name="fecha1">fecha inicio a consultar</param>
         /// <param name="fecha2">fecha fin a consultar</param>
         /// <returns></returns>
         public long RowListarPromocionProducto(int idTipo, DateTime fecha1, DateTime fecha2)
         {
             return midaoPromocion.RowListarPromocionProducto(idTipo, fecha1, fecha2);
         }

         /// <summary>
         /// Carga promoción
         /// </summary>
         /// <param name="idPromocion">id tipo promoción a cargar</param>
         /// <param name="idTipo">id tipo promoción a cargar</param>
         /// <returns></returns>
         public Promocion CargarPromocion(int idPromocion, int idTipo)
         {
            return midaoPromocion.CargarPromocion(idPromocion,idTipo);
         }

         /// <summary>
         /// Existe promoción marca.
         /// </summary>
         /// <param name="codigo">código  marca a consultar</param>
         /// <param name="fecha1">fecha inicio a consultar</param>
         /// <param name="fecha2">fecha fin a consultar</param>
         /// <returns></returns>
         public bool ExistePromocionMarca(int codigo, DateTime fecha1, DateTime fecha2)
         {
             return midaoPromocion.ExistePromocionMarca(codigo, fecha1, fecha2);
         }

         /// <summary>
         /// Existe promoción categoría.
         /// </summary>
         /// <param name="codigo">código categoría a consultar</param>
         /// <param name="fecha1">fecha inicio a consultar</param>
         /// <param name="fecha2">fecha fin a consultar</param>
         /// <returns></returns>
         public bool ExistePromocionCategoria(string codigo, DateTime fecha1, DateTime fecha2)
         {
             return midaoPromocion.ExistePromocionCategoria(codigo, fecha1, fecha2);
         }

         /// <summary>
         /// Existe promoción producto
         /// </summary>
         /// <param name="codigo">código producto a consultar</param>
         /// <param name="fecha1">fecha inicio a consultar</param>
         /// <param name="fecha2">fecha fin a consultar</param>
         /// <returns></returns>
         public bool ExistePromocionProducto(string codigo, DateTime fecha1, DateTime fecha2)
         {
             return midaoPromocion.ExistePromocionProducto(codigo, fecha1, fecha2);    
         }
    }
}
