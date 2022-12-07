using System;
using System.Data;
using System.Collections;
using DTO.Clases;
using DataAccessLayer.Clases;

namespace BussinesLayer.Clases
{
    /// <summary>
    /// Representa una clase de logica de negocio de Inventario.
    /// </summary>
    public class BussinesInventario
    {
        /// <summary>
        /// Objeto de tranzacion a base de datos de Inventario.
        /// </summary>
        private DaoInventario miDaoInventario;

        /// <summary>
        /// Inicializa una nueva instancia de la clase BussinesInventario.
        /// </summary>
        public BussinesInventario()
        {
            this.miDaoInventario = new DaoInventario();
        }

        /// <summary>
        /// Comprueba la existencia de una relacion establecida de un Producto en el inventario.
        /// </summary>
        /// <param name="inventario">Inventario a comprobar.</param>
        /// <returns></returns>
        public bool ComprobarInventario(Inventario inventario, bool color)
        {
            //miDaoInventario.InsertarMedidaColor(inventario);
            return miDaoInventario.ComprobarInventario(inventario, color);
        }

        /// <summary>
        /// Ingresa un registro del inventario a la base de datos.
        /// </summary>
        /// <param name="inventario"></param>
        public void InsertarInventario(Inventario inventario)
        {
            miDaoInventario.InsertarInventario(inventario);
        }

        /// <summary>
        /// Actualiza el color del inventario de un producto en la base de datos.
        /// </summary>
        /// <param name="inventario">Inventario a actualizar.</param>
        public void ActualizarInventario(Inventario inventario)
        {
            miDaoInventario.ActualizarInventario(inventario);
        }

        /// <summary>
        /// Actualiza la cantidad de un registro en especifico del inventario.
        /// </summary>
        /// <param name="inventario">Inventario a actualizar.</param>
        /// <param name="venta">Indica si es una actualización por venta o no.</param>
        public void ActualizarInventario(Inventario inventario, bool venta)
        {
            miDaoInventario.ActualizarInventario(inventario, venta);
        }

        public void ActualizarCantidadInventario(Inventario inventario)
        {
            miDaoInventario.ActualizarCantidadInventario(inventario);
        }

        public void ActualizarCantidad(string codigo, double cantidad)
        {
            miDaoInventario.ActualizarCantidad(codigo, cantidad);
        }

        /// <summary>
        /// Ingresa un regsitro del inventario fisico a la base de datos.
        /// </summary>
        /// <param name="inventario">Inventario a ingresar.</param>
        public void InsertarInventarioFisico(InventarioFisico inventario)
        {
            miDaoInventario.InsertarInventarioFisico(inventario);
        }

        /// <summary>
        /// Obtiene el registro de producto en cuestion
        /// </summary>
        /// <param name="codigo">Codigo del producto a consultar.</param>
        /// <returns></returns>
        public DataTable ConsultarProducto(string codigo)
        {
            return miDaoInventario.ConsultarProducto(codigo);
        }

        /// <summary>
        /// Obtiene el listada de los registros de los productos a cruzar en inventario.
        /// </summary>
        /// <param name="registroBase">Registro base para la consulta</param>
        /// <param name="registrosMaximos">Registros maximos a recuperar.</param>
        /// <returns></returns>
        public DataTable ProductoConCorte(int registroBase, int registrosMaximos)
        {
            return miDaoInventario.ProductoConCorte(registroBase, registrosMaximos);
        }

        /// <summary>
        /// Obtiene el total de registros de los productos a cruzar en inventario.
        /// </summary>
        /// <returns></returns>
        public long GetTotalRowProductoConCorte()
        {
            //miDaoInventario.ActualizarMedidaColor(miInventario);
            return miDaoInventario.GetTotalRowProductoConCorte();
        }

        /// <summary>
        /// Realiza el cruce entre el inventario ingresado y el inventario de sistema.
        /// </summary>
        /// <param name="inventarioSistema">Indica si continua con las cifras de cantidad del sistema.</param>
        /// <param name="fecha">Fecha en que se realiza el cruce</param>
        public void CruzarInventario(bool nivelaCero, bool inventarioSistema, DateTime fecha)
        {
            miDaoInventario.CruzarInventario(nivelaCero, inventarioSistema, fecha);
        }

   // Consulta de Corte de Inventario.

        public DataTable Cortes()
        {
            return miDaoInventario.Cortes();
        }

        public DataTable TablaCorte()
        {
            return miDaoInventario.TablaCorte();
        }

        /// <summary>
        /// Obtiene el listado de los registros de los productos a cruzar en inventario con sus cifras.
        /// </summary>
        /// <param name="orden">Establece el valor que indica el numero de orden de los registros.</param>
        /// <param name="registroBase">Registro base para la consulta.</param>
        /// <param name="registrosMaximos">Registro base para la consulta.</param>
        /// <returns></returns>
        public DataTable ConsultaCorteGeneral(int orden, int registroBase, int registrosMaximos)
        {
            return miDaoInventario.ConsultaCorteGeneral(orden, registroBase, registrosMaximos);
        }

        /// <summary>
        ///  Obtiene el total de registros de los productos a cruzar en inventario.
        /// </summary>
        /// <returns></returns>
        public long GetRowsConsultaCorteGeneral()
        {
            return miDaoInventario.GetRowsConsultaCorteGeneral();
        }

        public DataTable ConsultaCortePorCategoria(string categoria, int registroBase, int registrosMaximos)
        {
            return miDaoInventario.ConsultaCortePorCategoria(categoria, registroBase, registrosMaximos);
        }

        public int GetRowsConsultaCortePorCategoria(string categoria)
        {
            return miDaoInventario.GetRowsConsultaCortePorCategoria(categoria);
        }

        public DataTable ConsultaPorCodigo(string codigo)
        {
            return miDaoInventario.ConsultaPorCodigo(codigo);
        }

        public DataTable ConsultaPorNombre(string nombre, int registroBase, int registrosMaximos)
        {
            return miDaoInventario.ConsultaPorNombre(nombre, registroBase, registrosMaximos);
        }

        public int GetRowsConsultaPorNombre(string nombre)
        {
            return miDaoInventario.GetRowsConsultaPorNombre(nombre);
        }

        public DataTable ConsultaPorCorte(int corte, int registroBase, int registrosMaximos)
        {
            return miDaoInventario.ConsultaPorCorte(corte, registroBase, registrosMaximos);
        }

        public DataTable ConsultaPorCorte(int orden, int corte, int registroBase, int registrosMaximos)
        {
            return miDaoInventario.ConsultaPorCorte(orden, corte, registroBase, registrosMaximos);
        }

        public DataTable PrintInformeCorte(int orden)
        {
            return miDaoInventario.PrintInformeCorte(orden);
        }

        public DataTable PrintInformeCorte(int orden, int corte)
        {
            return miDaoInventario.PrintInformeCorte(orden, corte);
        }

   // End Consulta de Coste de Inventario.

        /// <summary>
        ///  Obtiene el listado de los registros de los productos en inventario.
        /// </summary>
        /// <param name="registroBase">Registro base para la consulta.</param>
        /// <param name="registrosMaximos">Registros maximos a recuperar.</param>
        /// <returns></returns>
        public DataTable ConsultaProductoResumenInventario(int registroBase, int registrosMaximos)
        {
            return miDaoInventario.ConsultaProductoResumenInventario(registroBase, registrosMaximos);
        }

        /// <summary>
        /// Obtiene el total de registros de los productos en inventario.
        /// </summary>
        /// <returns></returns>
        public long GetRowsConsultaProductoResumenInventario()
        {
            return miDaoInventario.GetRowsConsultaProductoResumenInventario();
        }

        /// <summary>
        /// Obtiene los registro de los productos en una Categoria.
        /// </summary>
        /// <param name="codigo">Codigo de la Categoria.</param>
        /// <param name="registroBase">Registros base para la consulta.</param>
        /// <param name="registrosMaximos">Numero de registros a recuperar.</param>
        /// <returns></returns>
        public DataTable ConsultaProductoPorCategoria
            (string codigo, int registroBase, int registrosMaximos)
        {
            return miDaoInventario.ConsultaProductoPorCategoria
                (codigo, registroBase, registrosMaximos);
        }

        /// <summary>
        /// Obtiene el total de registros de producto en una consulta.
        /// </summary>
        /// <returns></returns>
        public long GetTotalRowProducto(string codigo)
        {
            return miDaoInventario.GetTotalRowProducto(codigo);
        }

        /// <summary>
        /// Obtiene los registros de producto en inventario fisico.
        /// </summary>
        /// <param name="codigo">Codigo del producto a consultar.</param>
        /// <param name="registroBase">Registros base para la consulta.</param>
        /// <param name="registrosMaximos">Número de registros a recuperar.</param>
        /// <returns></returns>
        public DataTable ConsultaInventarioFisico
            (string codigo, int registroBase, int registrosMaximos)
        {
            double cantidad = 0;
            var tabla = miDaoInventario.ConsultarInventarioFisico
                (codigo, registroBase, registrosMaximos);
            var tablaTemp = TablaInventario();
            foreach (DataRow row in tabla.Rows)
            {
                var row_ = tablaTemp.NewRow();
                var color = new ElColor();
                color.MapaBits = (string)row["stringcolor"];

                row_["Id"] = row["id_inventario_fisico"];
                row_["Codigo"] = (string)row["codigointernoproducto"];
                row_["Fecha"] = (DateTime)row["fecha_inventario_fisico"];
                row_["Unidad"] = (string)row["descripcionunidad_medida"];
                row_["Medida"] = (string)row["descripcionvalor_unidad_medida"];
                row_["Color"] = color.ImagenBit;
                //row_["Inventario"] = "---"; 
                row_["Inventario"] = cantidad = this.miDaoInventario.CantidadInventario(new Inventario
                {
                    CodigoProducto = row["codigointernoproducto"].ToString(),
                    IdMedida = Convert.ToInt32(row["idvalor_unidad_medida"]),
                    IdColor = Convert.ToInt32(row["idcolor"])
                });
                row_["Fisico"] = row["cantidad_inventario_fisico"];
                //row_["Diferencia"] = "---";
                row_["Diferencia"] = Convert.ToDouble(row["cantidad_inventario_fisico"]) - cantidad;
                tablaTemp.Rows.Add(row_);
            }
            tabla.Clear();
            tabla = null;
            return tablaTemp;
        }

        /// <summary>
        /// Obtiene el total de registro de una consulta de producto en inventario fisico.
        /// </summary>
        /// <param name="codigo">Codigo del Producto a consultar.</param>
        /// <returns></returns>
        public long GetTotalRowCorteInventario(string codigo)
        {
            return miDaoInventario.GetTotalRowCorteInventario(codigo);
        }

        /// <summary>
        /// Obtiene los registros de producto en inventario fisico.
        /// </summary>
        /// <param name="codigo">Codigo del producto a consultar.</param>
        /// <param name="registroBase">Registros base para la consulta.</param>
        /// <param name="registrosMaximos">Número de registros a recuperar.</param>
        /// <returns></returns>
        public DataTable ConsultarInventarioFisicoNoColor
            (string codigo, int registroBase, int registrosMaximos)
        {
            var tabla = miDaoInventario.ConsultarInventarioFisicoNoColor
                (codigo, registroBase, registrosMaximos);
            var tempTabla = TablaInventario();
            foreach (DataRow row in tabla.Rows)
            {
                var row_ = tempTabla.NewRow();
                row_["Codigo"] = (string)row["codigointernoproducto"];
                row_["Fecha"] = (DateTime)row["fecha_inventario_fisico"];
                row_["Unidad"] = (string)row["descripcionunidad_medida"];
                row_["Medida"] = (string)row["descripcionvalor_unidad_medida"];
                row_["Inventario"] = "---";
                row_["Fisico"] = row["cantidad_inventario_fisico"];
                row_["Diferencia"] = "---";
                tempTabla.Rows.Add(row_);
            }
            tabla.Clear();
            tabla = null;
            return tempTabla;
            //return miDaoInventario.ConsultarInventarioFisicoNoColor(codigo);
        }

        /// <summary>
        /// Obtiene el total de registro de una consulta de producto en inventario fisico.
        /// </summary>
        /// <param name="codigo">Codigo del Producto a consultar.</param>
        /// <returns></returns>
        public long GetRowsInventarioFisicoNoColor(string codigo)
        {
            return miDaoInventario.GetRowsInventarioFisicoNoColor(codigo);
        }

        /// <summary>
        /// Obtiene el listado de los registros de los productos cruzados en inventario con sus cifras.
        /// </summary>
        /// <param name="orden">Establece el valor que indica el numero de orden de los registros.</param>
        /// <param name="registroBase">Registro base para la consulta.</param>
        /// <param name="registrosMaximos">Registro base para la consulta.</param>
        /// <returns></returns>
        public DataTable ConsultaResumenInventario(int orden, int registroBase, int registrosMaximos)
        {
            return miDaoInventario.ConsultaResumenInventario(orden, registroBase, registrosMaximos);
        }

        public DataTable ConsultaResumenInventario(int registroBase, int registrosMaximos)
        {
            return miDaoInventario.ConsultaResumenInventario(registroBase, registrosMaximos);
        }

        public DataTable ConsultaResumenInventario(string codigo)//, int registroBase, int registrosMaximos)
        {
            return miDaoInventario.ConsultaResumenInventario(codigo);//, registroBase, registrosMaximos);
        }

        /// <summary>
        /// Obtiene el total de registros de Resumen de Inventario.
        /// </summary>
        /// <returns></returns>
        public long GetRowsConsultaResumenInventario()
        {
            return miDaoInventario.GetRowsConsultaResumenInventario();
        }

        public DataTable ConsultaResumenInventarioCategoria(string categoria, int registroBase, int registrosMaximos)
        {
            return miDaoInventario.ConsultaResumenInventarioCategoria(categoria, registroBase, registrosMaximos);
        }

        public int GetRowsConsultaResumenInventarioCategoria(string categoria)
        {
            return miDaoInventario.GetRowsConsultaResumenInventarioCategoria(categoria);
        }

        public DataTable ConsultaResumenInventarioNombre(string nombre, int registroBase, int registrosMaximos)
        {
            return miDaoInventario.ConsultaResumenInventarioNombre(nombre, registroBase, registrosMaximos);
        }

        public int GetRowsConsultaResumenInventarioNombre(string nombre)
        {
            return miDaoInventario.GetRowsConsultaResumenInventarioNombre(nombre);
        }


        public DataTable ConsultaResumenInventario(DateTime fecha, int registroBase, int registrosMaximos)
        {
            return miDaoInventario.ConsultaResumenInventario(fecha, registroBase, registrosMaximos);
        }

        public int GetRowsConsultaResumenInventario(DateTime fecha)
        {
            return miDaoInventario.GetRowsConsultaResumenInventario(fecha);
        }

        public DataTable PrintInformeResumen(int orden)
        {
            return miDaoInventario.PrintInformeResumen(orden);
        }

        public DataTable PrintInformeResumen(DateTime fecha, int orden)
        {
            return miDaoInventario.PrintInformeResumen(fecha, orden);
        }

        /// <summary>
        /// Obtiene los registros de una consulta de Resumen de inventario.
        /// </summary>
        /// <param name="codigo">Codigo del producto a consultar.</param>
        /// <param name="registroBase">Registros base para la consulta.</param>
        /// <param name="registrosMaximos">Número de registros a recuperar.</param>
        /// <returns></returns>
        public DataTable ResumenInventarioColor
            (string codigo, int registroBase, int registrosMaximos)
        {
            var tabla = miDaoInventario.ResumenInventarioColor
                (codigo, registroBase, registrosMaximos);
            var tempTabla = TablaInventario();
            foreach (DataRow row in tabla.Rows)
            {
                var row_ = tempTabla.NewRow();
                var color = new ElColor();
                color.MapaBits = (string)row["stringcolor"];
                row_["Codigo"] = (string)row["codigointernoproducto"];
                row_["Fecha"] = (DateTime)row["fecha_resumen"];
                row_["Unidad"] = (string)row["descripcionunidad_medida"];
                row_["Medida"] = (string)row["descripcionvalor_unidad_medida"];
                row_["Color"] = color.ImagenBit;
                row_["Inventario"] = row["cantidad_inventario"];
                row_["Fisico"] = row["cantidad_inventario_fisico"];
                row_["Diferencia"] = row["cantidad_resumen"];
                tempTabla.Rows.Add(row_);
            }
            tabla.Clear();
            tabla = null;
            return tempTabla;
        }

        /// <summary>
        /// Obtiene el total de registro de una consulta de producto en Resumen de Inventario
        /// </summary>
        /// <param name="codigo">Codigo del Producto a consultar.</param>
        /// <returns></returns>
        public long GetRowsResumenInventarioColor(string codigo)
        {
            return miDaoInventario.GetRowsResumenInventarioColor(codigo);
        }

        /// <summary>
        /// Obtiene los registros de una consulta de Resumen de inventario.
        /// </summary>
        /// <param name="codigo">Codigo del producto a consultar.</param>
        /// <param name="registroBase">Registros base para la consulta.</param>
        /// <param name="registrosMaximos">Número de registros a recuperar.</param>
        /// <returns></returns>
        public DataTable ResumenInventarioNoColor
            (string codigo, int registroBase, int registrosMaximos)
        {
            var tabla = miDaoInventario.ResumenInventarioNoColor
                (codigo, registroBase, registrosMaximos);
            var tempTabla = TablaInventario();
            foreach (DataRow row in tabla.Rows)
            {
                var row_ = tempTabla.NewRow();
                row_["Codigo"] = (string)row["codigointernoproducto"];
                row_["Fecha"] = (DateTime)row["fecha_resumen"];
                row_["Unidad"] = (string)row["descripcionunidad_medida"];
                row_["Medida"] = (string)row["descripcionvalor_unidad_medida"];
                row_["Inventario"] = row["cantidad_inventario"];
                row_["Fisico"] = row["cantidad_inventario_fisico"];
                row_["Diferencia"] = row["cantidad_resumen"];
                tempTabla.Rows.Add(row_);
            }
            tabla.Clear();
            tabla = null;
            return tempTabla;
        }

        /// <summary>
        /// Obtiene el total de registro de una consulta de producto en Resumen de Inventario
        /// </summary>
        /// <param name="codigo">Codigo del Producto a consultar.</param>
        /// <returns></returns>
        public long GetRowsResumenInventarioNoColor(string codigo)
        {
            return miDaoInventario.GetRowsResumenInventarioNoColor(codigo);
        }

        /// <summary>
        /// Obtiene el ultimo registro del producto en el Resumen de Inventario
        /// </summary>
        /// <param name="codigo">Codigo del producto a consultar.</param>
        /// <param name="color">Indica si la consulta incluye color en el producto.</param>
        /// <param name="registroBase">Registros base para la consulta.</param>
        /// <param name="registrosMaximos">Número de registros a recuperar.</param>
        /// <returns></returns>
        public DataTable UltimoRegistroInventario
            (string codigo, bool color, int registroBase, int registrosMaximos)
        {
            var tabla = miDaoInventario.UltimoRegistroInventario
                (codigo, color,registroBase, registrosMaximos);
            var tempTabla = TablaInventario();
            foreach (DataRow row in tabla.Rows)
            {
                var row_ = tempTabla.NewRow();
                row_["Codigo"] = (string)row["codigointernoproducto"];
                row_["Fecha"] = (DateTime)row["fecha_resumen"];
                row_["Unidad"] = (string)row["descripcionunidad_medida"];
                row_["Medida"] = (string)row["descripcionvalor_unidad_medida"];
                row_["Inventario"] = row["cantidad_inventario"];
                row_["Fisico"] = row["cantidad_inventario_fisico"];
                row_["Diferencia"] = row["cantidad_resumen"];
                if (color)
                {
                    var color_ = new ElColor();
                    color_.MapaBits = (string)row["stringcolor"];
                    row_["Color"] = color_.ImagenBit;
                }
                tempTabla.Rows.Add(row_);
            }
            tabla.Clear();
            tabla = null;
            return tempTabla;
        }

        /// <summary>
        /// Obtiene el total de registro de una consulta de producto en Resumen de Inventario
        /// </summary>
        /// <param name="codigo">Codigo del Producto a consultar.</param>
        /// <returns></returns>
        public long GetRowsUltimoRegistroInventario(string codigo)
        {
            return miDaoInventario.GetRowsUltimoRegistroInventario(codigo);
        }

        /// <summary>
        /// Obtiene los registros de una consulta por fecha de Resumen de inventario.
        /// </summary>
        /// <param name="codigo">Codigo del producto a consultar.</param>
        /// <param name="fecha">Fecha a la cual se hace referencia.</param>
        /// <param name="color">Indica si la consulta incluye color en el producto.</param>
        /// <param name="registroBase">Registros base para la consulta.</param>
        /// <param name="registrosMaximos">Número de registros a recuperar.</param>
        /// <returns></returns>
        public DataTable ConsultaInventarioFecha
          (string codigo, DateTime fecha, bool color, int registroBase, int registrosMaximos)
        {
            var tabla = miDaoInventario.ConsultaInventarioFecha
                (codigo, fecha, color, registroBase, registrosMaximos);
            var tempTabla = TablaInventario();
            foreach (DataRow row in tabla.Rows)
            {
                var row_ = tempTabla.NewRow();
                row_["Codigo"] = (string)row["codigointernoproducto"];
                row_["Fecha"] = (DateTime)row["fecha_resumen"];
                row_["Unidad"] = (string)row["descripcionunidad_medida"];
                row_["Medida"] = (string)row["descripcionvalor_unidad_medida"];
                row_["Inventario"] = row["cantidad_inventario"];
                row_["Fisico"] = row["cantidad_inventario_fisico"];
                row_["Diferencia"] = row["cantidad_resumen"];
                if (color)
                {
                    var color_ = new ElColor();
                    color_.MapaBits = (string)row["stringcolor"];
                    row_["Color"] = color_.ImagenBit;
                }
                tempTabla.Rows.Add(row_);
            }
            tabla.Clear();
            tabla = null;
            return tempTabla;
        }

        /// <summary>
        /// Obtiene el total de registro de una consulta por fecha de producto en Resumen de Inventario.
        /// </summary>
        /// <param name="codigo">Codigo del Producto a consultar.</param>
        /// <param name="fecha">Fecha a la cual se hace referencia.</param>
        /// <returns></returns>
        public long GetRowsConsultaInventarioFecha(string codigo, DateTime fecha)
        {
            return miDaoInventario.GetRowsConsultaInventarioFecha(codigo, fecha);
        }

        /// <summary>
        /// Obtiene los registros de una consulta por periodo de fecha de Resumen de inventario.
        /// </summary>
        /// <param name="codigo">Codigo del producto a consultar.</param>
        /// <param name="fecha1">Fecha inicial a la cual se hace referencia.</param>
        /// <param name="fecha2">Fecha final a la cual se hace referencia.</param>
        /// <param name="registroBase">Registros base para la consulta.</param>
        /// <param name="registrosMaximos">Número de registros a recuperar.</param>
        /// <returns></returns>
        public DataTable ConsultaInventarioPeriodo
            (string codigo, DateTime fecha1, DateTime fecha2, int registroBase, int registrosMaximos)
        {
            var tabla = miDaoInventario.ConsultaInventarioPeriodo
                (codigo, fecha1, fecha2, registroBase, registrosMaximos);
            var tempTabla = TablaInventario();
            foreach (DataRow row in tabla.Rows)
            {
                var row_ = tempTabla.NewRow();
                var color_ = new ElColor();
                color_.MapaBits = (string)row["stringcolor"];
                row_["Codigo"] = (string)row["codigointernoproducto"];
                row_["Fecha"] = (DateTime)row["fecha_resumen"];
                row_["Unidad"] = (string)row["descripcionunidad_medida"];
                row_["Medida"] = (string)row["descripcionvalor_unidad_medida"];
                row_["Color"] = color_.ImagenBit;
                row_["Inventario"] = row["cantidad_inventario"];
                row_["Fisico"] = row["cantidad_inventario_fisico"];
                row_["Diferencia"] = row["cantidad_resumen"];
                tempTabla.Rows.Add(row_);
            }
            tabla.Clear();
            tabla = null;
            return tempTabla;
        }

        /// <summary>
        /// Obtiene el total de registro de una consulta por periodo de fecha de Resumen de Inventario.
        /// </summary>
        /// <param name="codigo">Codigo del Producto a consultar.</param>
        /// <param name="fecha1">Fecha inicial a la cual se hace referencia.</param>
        /// <param name="fecha2">Fecha final a la cual se hace referencia.</param>
        /// <returns></returns>
        public long GetRowsConsultaInventarioPeriodo(string codigo, DateTime fecha1, DateTime fecha2)
        {
            return miDaoInventario.GetRowsConsultaInventarioPeriodo
                (codigo, fecha1, fecha2);
        }

        /// <summary>
        /// Obtiene los registros de una consulta por periodo de fecha de Resumen de inventario sin incluir color.
        /// </summary>
        /// <param name="codigo">Codigo del producto a consultar.</param>
        /// <param name="fecha1">Fecha inicial a la cual se hace referencia.</param>
        /// <param name="fecha2">Fecha final a la cual se hace referencia.</param>
        /// <param name="registroBase">Registros base para la consulta.</param>
        /// <param name="registrosMaximos">Número de registros a recuperar.</param>
        /// <returns></returns>
        public DataTable ConsultaInventarioPeriodoNoColor
            (string codigo, DateTime fecha1, DateTime fecha2, int registroBase, int registrosMaximos)
        {
            var tabla = miDaoInventario.ConsultaInventarioPeriodoNoColor
                (codigo, fecha1, fecha2, registroBase, registrosMaximos);
            var tempTabla = TablaInventario();
            foreach (DataRow row in tabla.Rows)
            {
                var row_ = tempTabla.NewRow();
                row_["Codigo"] = (string)row["codigointernoproducto"];
                row_["Fecha"] = (DateTime)row["fecha_resumen"];
                row_["Unidad"] = (string)row["descripcionunidad_medida"];
                row_["Medida"] = (string)row["descripcionvalor_unidad_medida"];
                row_["Inventario"] = row["cantidad_inventario"];
                row_["Fisico"] = row["cantidad_inventario_fisico"];
                row_["Diferencia"] = row["cantidad_resumen"];
                tempTabla.Rows.Add(row_);
            }
            tabla.Clear();
            tabla = null;
            return tempTabla;
        }

        /// <summary>
        /// Obtiene el total de registro de una consulta por periodo de fecha de Resumen de Inventario sin incluir color.
        /// </summary>
        /// <param name="codigo">Codigo del producto a consultar.</param>
        /// <param name="fecha1">Fecha inicial a la cual se hace referencia.</param>
        /// <param name="fecha2">Fecha final a la cual se hace referencia.</param>
        /// <returns></returns>
        public long GetRowsConsultaInventarioPeriodoNoColor(string codigo, DateTime fecha1, DateTime fecha2)
        {
            return miDaoInventario.GetRowsConsultaInventarioPeriodoNoColor
                (codigo, fecha1, fecha2);
        }

        /// <summary>
        /// Elimina un registro del Inventario.
        /// </summary>
        /// <param name="inventario">Inventario a eliminar.</param>
        public bool EliminarInventario(Inventario inventario)
        {
            return miDaoInventario.EliminarInventario(inventario);
        }

        public DataTable InformeInventario()
        {
            return miDaoInventario.InformeInventario();
        }

        /// <summary>
        /// Obtiene una DataTable tipado para la vista de Resumen de Inventario.
        /// </summary>
        /// <returns></returns>
        private DataTable TablaInventario()
        {
            var tabla = new DataTable();
            tabla.Columns.Add(new DataColumn("Id", typeof(int)));
            tabla.Columns.Add(new DataColumn("Codigo", typeof(string)));
            tabla.Columns.Add(new DataColumn("Fecha", typeof(DateTime)));
            tabla.Columns.Add(new DataColumn("Unidad", typeof(string)));
            tabla.Columns.Add(new DataColumn("Medida", typeof(string)));
            tabla.Columns.Add(new DataColumn("Color", typeof(System.Drawing.Image)));
            tabla.Columns.Add(new DataColumn("Inventario", typeof(string)));
            tabla.Columns.Add(new DataColumn("Fisico", typeof(string)));
            tabla.Columns.Add(new DataColumn("Diferencia", typeof(string)));
            return tabla;
        }

        /// <summary>
        /// Obtiene la cantidad de un registro de Inventario.
        /// </summary>
        /// <param name="inventario">Inventario a consultar.</param>
        /// <returns></returns>
        public double CantidadInventario(Inventario inventario)
        {
            return miDaoInventario.CantidadInventario(inventario);
        }

        /// <summary>
        /// Lista cantidady descripcion de un articulo
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        public DataTable ListarCantidadInventario(string codigo)
        {
            return miDaoInventario.ListarProductoInventario(codigo);
        }

        public DataTable ConsultaInventario(int rowBase, int rowMax)
        {
            return miDaoInventario.ConsultaInventario(rowBase, rowMax);
        }

        public long GetRowsConsultaInventario()
        {
            return miDaoInventario.GetRowsConsultaInventario();
        }

        public DataTable ConsultaInventario(string codigo, int rowBase, int rowMax)
        {
            return miDaoInventario.ConsultaInventario(codigo, rowBase, rowMax);
        }

        public long GetRowsConsultaInventario(string codigo)
        {
            return miDaoInventario.GetRowsConsultaInventario(codigo);
        }

        public DataTable ConsultaInventarioNombre(string nombre, int rowBase, int rowMax)
        {
            return miDaoInventario.ConsultaInventarioNombre(nombre, rowBase, rowMax);
        }

        public long GetRowsConsultaInventarioNombre(string nombre)
        {
            return miDaoInventario.GetRowsConsultaInventarioNombre(nombre);
        }

        public DataTable ConsultaInventarioCategoria(string categoria, int rowBase, int rowMax)
        {
            return miDaoInventario.ConsultaInventarioCategoria(categoria, rowBase, rowMax);
        }

        public long GetRowsConsultaInventarioCategoria(string categoria)
        {
            return miDaoInventario.GetRowsConsultaInventarioCategoria(categoria);
        }


        // Funciones con filtro por tipo inventario de productos, productos fabricados y no fabricados

        public DataTable ConsultaInventario(bool compra, int rowBase, int rowMax, int idTipoInventario, int idTipoInventario2)
        {
            return miDaoInventario.ConsultaInventario(compra, rowBase, rowMax, idTipoInventario, idTipoInventario2);
        }

        public long GetRowsConsultaInventario(bool compra, int idTipoInventario, int idTipoInventario2)
        {
            return miDaoInventario.GetRowsConsultaInventario(compra, idTipoInventario, idTipoInventario2);
        }

        public DataTable ConsultaInventario(bool compra, string codigo, int rowBase, int rowMax, int idTipoInventario, int idTipoInventario2)
        {
            return miDaoInventario.ConsultaInventario(compra, codigo, rowBase, rowMax, idTipoInventario, idTipoInventario2);
        }

        public long GetRowsConsultaInventario(bool compra, string codigo, int idTipoInventario, int idTipoInventario2)
        {
            return miDaoInventario.GetRowsConsultaInventario(compra, codigo, idTipoInventario, idTipoInventario2);
        }

        public DataTable ConsultaInventarioNombre(bool compra, string nombre, int rowBase, int rowMax, int idTipoInventario, int idTipoInventario2)
        {
            return miDaoInventario.ConsultaInventarioNombre(compra, nombre, rowBase, rowMax, idTipoInventario, idTipoInventario2);
        }

        public long GetRowsConsultaInventarioNombre(bool compra, string nombre, int idTipoInventario, int idTipoInventario2)
        {
            return miDaoInventario.GetRowsConsultaInventarioNombre(compra, nombre, idTipoInventario, idTipoInventario2);
        }

        public DataTable ConsultaInventarioCategoria(bool compra, string categoria, int rowBase, int rowMax, int idTipoInventario, int idTipoInventario2)
        {
            return miDaoInventario.ConsultaInventarioCategoria(compra, categoria, rowBase, rowMax, idTipoInventario, idTipoInventario2);
        }

        public long GetRowsConsultaInventarioCategoria(bool compra, string categoria, int idTipoInventario, int idTipoInventario2)
        {
            return miDaoInventario.GetRowsConsultaInventarioCategoria(compra, categoria, idTipoInventario, idTipoInventario2);
        }

        // Funciones para impresion
        public DataTable ConsultaInventario()
        {
            return this.miDaoInventario.ConsultaInventario();
        }

        public DataTable ConsultaInventario(string codigo)
        {
            return this.miDaoInventario.ConsultaInventario(codigo);
        }

        public DataTable ConsultaInventarioNombre(string nombre)
        {
            return this.miDaoInventario.ConsultaInventarioNombre(nombre);
        }

        public DataTable ConsultaInventarioCategoria(string categoria)
        {
            return this.miDaoInventario.ConsultaInventarioCategoria(categoria);
        }



        public DataTable ConsultaInventario_()
        {
            return this.miDaoInventario.ConsultaInventario_();
        }

        public DataTable ConsultaInventario_(string codigo)
        {
            return this.miDaoInventario.ConsultaInventario_(codigo);
        }

        public DataTable ConsultaInventarioCategoria_(string codCategoria)
        {
            return this.miDaoInventario.ConsultaInventarioCategoria_(codCategoria);
        }

        public DataTable ConsultaInventarioNombre_(string nombre)
        {
            return this.miDaoInventario.ConsultaInventarioNombre_(nombre);
        }


        public void VerCodigosRepetidosInventario()
        {
            this.miDaoInventario.VerCodigosRepetidosInventario();
        }

        public void EditarCantidadInventarioFisico(int id, double cantidad)
        {
            this.miDaoInventario.EditarCantidadInventarioFisico(id, cantidad);
        }
    }
}