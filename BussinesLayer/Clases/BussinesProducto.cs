using System;
using System.Data;
using System.Collections.Generic;
using DataAccessLayer.Clases;
using DTO.Clases;
using System.Collections;

namespace BussinesLayer.Clases
{
    /// <summary>
    /// Representa una clase de logica de negocio de Producto.
    /// </summary>
    public class BussinesProducto
    {
        /// <summary>
        /// Objeto de tranzacion a Base de datos de Producto.
        /// </summary>
        private DaoProducto miProducto;

        /// <summary>
        /// Inicializa una nueva instancia de la clase BussinesProducto
        /// </summary>
        public BussinesProducto()
        {
            miProducto = new DaoProducto();
        }

       /* public BussinesProducto(string ipServer)
        {
            miProducto = new DaoProducto(ipServer);
        }*/


        public DataTable CuentasContables()
        {
            return miProducto.CuentasContables();
        }

        public DataTable TiposInventario()
        {
            return miProducto.TiposInventario();
        }

        public DataTable ProductosProceso(int idTipoInventario)
        {
            return miProducto.ProductosProceso(idTipoInventario);
        }

        public string CodigoProductoProceso(string codProductoInsumo)
        {
            return miProducto.CodigoProductoProceso(codProductoInsumo);
        }

        public Producto ProductoProcesoPresentacion(string codProductoInsumo)
        {
            return miProducto.ProductoProcesoPresentacion(codProductoInsumo);
        }


        /// <summary>
        /// Obtiene un número disponible para el Codigo Interno para registro del Producto
        /// </summary>
        /// <returns></returns>
        public int CapturarCodigoInterno()
        {
            return miProducto.ObtenerCodigoInterno();
        }

        /// <summary>
        /// Obtiene un número disponible del Codigo de Barras para registro del Producto
        /// </summary>
        /// <returns></returns>
        public string CapturarCodbarras()
        {
            return miProducto.ObtenerCodigoBarras();
        }

        /// <summary>
        /// Comprueba si el codigo existe en un registro de Producto.
        /// </summary>
        /// <param name="codigo">Codigo a comprobar.</param>
        /// <returns></returns>
        public bool ExisteCodigo_(string codigo)
        {
            return miProducto.ComprobarCodigoInterno(codigo);
        }

        /// <summary>
        /// Comprueba si el codigo existe en un registro de Producto.
        /// </summary>
        /// <param name="codigo">Codigo a comprobar.</param>
        /// <returns></returns>
        public bool ExisteCodigoBarras(string codigo)
        {
            return miProducto.ComprobarCodigoBarras(codigo);
        }

        public bool ExisteCodigo(string codigo)
        {
            return this.miProducto.ExisteCodigo(codigo);
        }

        public DataTable Ico()
        {
            return this.miProducto.Ico();
        }

        /// <summary>
        /// Ingresa un registro de Producto en la base de datos.
        /// </summary>
        /// <param name="producto">Producto a ingresar.</param>
        public void InsertarProducto(Producto producto)
        {
            miProducto.InsertarProducto(producto);
        }

        /// <summary>
        /// Obtiene el valor que indica si el Producto aplica talla o no.
        /// </summary>
        /// <param name="codigo">Codigo del Producto a consultar.</param>
        /// <returns></returns>
        public bool ProductoConTalla(string codigo)
        {
            return miProducto.ProductoConTalla(codigo);
        }

        public DataTable Productos()
        {
            return this.miProducto.Productos();
        }

        /// <summary>
        /// Obtiene el listado de los productos.
        /// </summary>
        /// <param name="registroBase">Registro base para la consulta.</param>
        /// <param name="registrosMaximos">Numero de registros a recuperar.</param>
        /// <returns></returns>
        public DataTable ListarProductos(int registroBase, int registrosMaximos)
        {
            return miProducto.ListarProductos(registroBase, registrosMaximos);
        }

        /// <summary>
        /// Obtiene el listado de la consulta un una coleccion.
        /// </summary>
        /// <param name="codigo">Codigo interno o de barras a consultar.</param>
        /// <returns></returns>
        public DataTable ConsultaPorCodigo(string codigo)
        {
            return miProducto.ConsultaPorCodigo(codigo);
        }

        /// <summary>
        /// Obtiene producto por codigo interno o de barras.
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        public Producto ConsultaProductoSimple(string codigo)
        {
         return miProducto.ConsultaProductoSimple(codigo);
        }

        /// <summary>
        /// Obtiene el total de registros de los productos.
        /// </summary>
        /// <returns></returns>
        public long RowsListarProductos()
        {
            return miProducto.RowsListarProductos();
        }

        /// <summary>
        /// Obtiene el listado de la consulta un una coleccion.
        /// </summary>
        /// <param name="nombre">Nombre a consultar.</param>
        /// <returns></returns>
        public DataTable ConsultaPorNombre(string nombre)
        {
            return miProducto.ConsultaPorNombre(nombre);
        }

        /// <summary>
        /// Obtiene el listado de la consulta un una coleccion en base a parte del nombre.
        /// </summary>
        /// <param name="nombre">Nombre o parte de este a consultar.</param>
        /// <param name="registroBase">Registro base para la consulta.</param>
        /// <param name="registrosMaximos">Número de registros a recuperar.</param>
        /// <returns></returns>
        public DataTable FiltroNombre(string nombre, int registroBase, int registrosMaximos)
        {
            return miProducto.FiltroNombre(nombre, registroBase, registrosMaximos);
        }

        /// <summary>
        /// Obtiene el total de registros de una consulta por nombre de producto.
        /// </summary>
        /// <param name="nombre">Nombre del producto o parte de este.</param>
        /// <returns></returns>
        public long RowsFiltroNombre(string nombre)
        {
            return miProducto.RowsFiltroNombre(nombre);
        }

        /// <summary>
        /// Obtiene el listado de productos segun el codigo de la catagoria.
        /// </summary>
        /// <param name="codigo">Codigo de la categoria.</param>
        /// <param name="registroBase">Registro base para la consulta.</param>
        /// <param name="registrosMaximos">Número de registros a recuperar.</param>
        /// <returns></returns>
        public DataTable ConsultaPorCodigoCategoria
            (string codigo, int registroBase, int registrosMaximos)
        {
            return miProducto.ConsultaPorCodigoCategoria
                (codigo, registroBase, registrosMaximos);
        }

        /// <summary>
        /// Obtiene el total de registros de una consulta de Producto por codigo de categoria.
        /// </summary>
        /// <param name="codigo">Codigo de la categoria.</param>
        /// <returns></returns>
        public long RowsConsultaPorCodigoCategoria(string codigo)
        {
            return miProducto.RowsConsultaPorCodigoCategoria(codigo);
        }

        /// <summary>
        /// Obtiene el listado de productos segun el nombre de la categoria.
        /// </summary>
        /// <param name="nombre">Nombre de la categoria o parte de este.</param>
        /// <param name="registroBase">Registro base para la consulta.</param>
        /// <param name="registrosMaximos">Número de registros a recuperar.</param>
        /// <param name="filtro">Indica si es una consulta de filtrado o no.</param>
        /// <returns></returns>
        public DataTable ConsultaPorNombreCategoria
            (string nombre, int registroBase, int registrosMaximos, bool filtro)
        {
            return miProducto.ConsultaPorNombreCategoria
                (nombre, registroBase, registrosMaximos, filtro);
        }

        /// <summary>
        /// Obtiene el total de registros de una consulta de Producto por nombre de categoria.
        /// </summary>
        /// <param name="nombre">Nombre de la categoria o parte de este.</param>
        /// <param name="filtro">Indica si es una consulta de filtrado o no.</param>
        /// <returns></returns>
        public long RowsConsultaPorNombreCategoria(string nombre, bool filtro)
        {
            return miProducto.RowsConsultaPorNombreCategoria(nombre, filtro);
        }

        /// <summary>
        /// Obtiene el resultado de una consulta de Producto por Referencia
        /// </summary>
        /// <param name="referencia">Referencia a consultar.</param>
        /// <param name="registroBase">Registro base para la consulta.</param>
        /// <param name="registrosMaximos">Número de registros a recuperar.</param>
        /// <param name="color">Indica si recupera el color relacionado en la consulta.</param>
        /// <returns></returns>
        public DataTable ConsultaProductoPorReferencia
            (string referencia, int registroBase, int registrosMaximos, bool color)
        {
            if (color)
            {
                var tabla = miProducto.ConsultaProductoPorReferencia
                    (referencia, registroBase, registrosMaximos, color);
                var tempTabla = TablaProducto();
                foreach (DataRow row in tabla.Rows)
                {
                    var row_ = tempTabla.NewRow();
                    var c = new ElColor();
                    c.MapaBits = (string)row["Color"];
                    row_["CodigoInternoProducto"] = row["CodigoInternoProducto"];
                    row_["CodigoBarrasProducto"] = row["CodigoBarrasProducto"];
                    row_["NombreProducto"] = row["NombreProducto"];
                    row_["CodigoCategoria"] = row["CodigoCategoria"];
                    row_["NombreCategoria"] = row["NombreCategoria"];
                    row_["ValorVentaProducto"] = row["ValorVentaProducto"];
                    row_["ValorIva"] = row["ValorIva"];
                    row_["EstadoProducto"] = row["EstadoProducto"];
                    row_["NombreMarca"] = row["NombreMarca"];
                    row_["ReferenciaProducto"] = row["ReferenciaProducto"];
                    row_["Medida"] = row["Medida"];
                    row_["Color"] = c.ImagenBit;
                    tempTabla.Rows.Add(row_);
                }
                tabla.Clear();
                tabla = null;
                return tempTabla;
            }
            else
            {
                return miProducto.ConsultaProductoPorReferencia
                    (referencia, registroBase, registrosMaximos, color);
            }
        }

        /// <summary>
        /// Obtiene el total de registros de una consulta de Producto por Referencia.
        /// </summary>
        /// <param name="referencia">Referencia o parte de esta a consultar.</param>
        /// <param name="color">Indica si la consulta incluye color o no.</param>
        /// <returns></returns>
        public long RowsConsultaProductoPorReferencia(string referencia, bool color)
        {
            return miProducto.RowsConsultaProductoPorReferencia(referencia, color);
        }

        /// <summary>
        /// Obtiene el listado de productos segun el codigo o el nombre y la referencia.
        /// </summary>
        /// <param name="codigo">Codigo del producto a consultar.</param>
        /// <param name="nombre">Nombre o parte de este del producto a consultar.</param>
        /// <param name="referencia">Referencia o parte de esta a consultar.</param>
        /// <param name="code">Indica si se consulta por Codigo del producto o no.</param>
        /// <param name="color">Indica si la consulta incluye color o no.</param>
        /// <param name="registroBase">Registro base para la consulta.</param>
        /// <param name="registrosMaximos">Número de registros a recuperar.</param>
        /// <returns></returns>
        public DataTable ConsultaProductoConReferencia
            (string codigo, string nombre, string referencia, bool code, bool color,
             int registroBase, int registrosMaximos)
        {
            if (color)
            {
                var tabla = miProducto.ConsultaProductoConReferencia
                    (codigo, nombre, referencia, code, color, registroBase, registrosMaximos);
                var tempTabla = TablaProducto();
                foreach (DataRow row in tabla.Rows)
                {
                    var row_ = tempTabla.NewRow();
                    var c = new ElColor();
                    c.MapaBits = (string)row["Color"];
                    row_["CodigoInternoProducto"] = row["CodigoInternoProducto"];
                    row_["CodigoBarrasProducto"] = row["CodigoBarrasProducto"];
                    row_["NombreProducto"] = row["NombreProducto"];
                    row_["CodigoCategoria"] = row["CodigoCategoria"];
                    row_["NombreCategoria"] = row["NombreCategoria"];
                    row_["ValorVentaProducto"] = row["ValorVentaProducto"];
                    row_["ValorIva"] = row["ValorIva"];
                    row_["EstadoProducto"] = row["EstadoProducto"];
                    row_["NombreMarca"] = row["NombreMarca"];
                    row_["ReferenciaProducto"] = row["ReferenciaProducto"];
                    row_["Medida"] = row["Medida"];
                    row_["Color"] = c.ImagenBit;
                    tempTabla.Rows.Add(row_);
                }
                tabla.Clear();
                tabla = null;
                return tempTabla;
            }
            else
            {
                return miProducto.ConsultaProductoConReferencia
                    (codigo, nombre, referencia, code, color, registroBase, registrosMaximos);
            }
        }

        /// <summary>
        /// Obtiene el total de registros de una consulta segun el codigo o el nombre y la referencia.
        /// </summary>
        /// <param name="codigo">Codigo del producto a consultar.</param>
        /// <param name="nombre">Nombre o parte de este del producto a consultar.</param>
        /// <param name="referencia">Referencia o parte de esta a consultar.</param>
        /// <param name="code">Indica si se consulta por Codigo del producto o no.</param>
        /// <param name="color">Indica si la consulta incluye color o no.</param>
        /// <returns></returns>
        public long RowsConsultaProductoConReferencia
            (string codigo, string nombre, string referencia, bool code, bool color)
        {
            return miProducto.RowsConsultaProductoConReferencia
                (codigo, nombre, referencia, code, color);
        }

        /// <summary>
        /// Obtiene el listado de productos segun la marca.
        /// </summary>
        /// <param name="codigo">Codigo del producto a consultar.</param>
        /// <param name="nombre">Nombre o parte de este del producto a consultar.</param>
        /// <param name="marca">Marca o parte de esta a consultar.</param>
        /// <param name="talla">Talla o parte de esta a consultar.</param>
        /// <param name="size">Indica si la consulta incluye talla o no.</param>
        /// <param name="product">Indica si la consulta incluye Producto o no.</param>
        /// <param name="code">Indica si se consulta por Codigo del producto o no.</param>
        /// <param name="color">Indica si la consulta incluye color o no.</param>
        /// <param name="registroBase">Registro base para la consulta.</param>
        /// <param name="registrosMaximos">Número de registros a recuperar.</param>
        /// <returns></returns>
        public DataTable ConsultaProductoPorMarca
            (string codigo, string nombre, string marca, string talla, bool size,
             bool product, bool code, bool color, int registroBase, int registrosMaximos)
        {
            if (color)
            {
                var tabla = miProducto.ConsultaProductoPorMarca(codigo, nombre, marca, talla,
                    size, product, code, color, registroBase, registrosMaximos);
                var tempTabla = TablaProducto();
                foreach (DataRow row in tabla.Rows)
                {
                    var row_ = tempTabla.NewRow();
                    var c = new ElColor();
                    c.MapaBits = (string)row["Color"];
                    row_["CodigoInternoProducto"] = row["CodigoInternoProducto"];
                    row_["CodigoBarrasProducto"] = row["CodigoBarrasProducto"];
                    row_["NombreProducto"] = row["NombreProducto"];
                    row_["CodigoCategoria"] = row["CodigoCategoria"];
                    row_["NombreCategoria"] = row["NombreCategoria"];
                    row_["ValorVentaProducto"] = row["ValorVentaProducto"];
                    row_["ValorIva"] = row["ValorIva"];
                    row_["EstadoProducto"] = row["EstadoProducto"];
                    row_["NombreMarca"] = row["NombreMarca"];
                    row_["ReferenciaProducto"] = row["ReferenciaProducto"];
                    row_["Medida"] = row["Medida"];
                    row_["Color"] = c.ImagenBit;
                    tempTabla.Rows.Add(row_);
                }
                tabla.Clear();
                tabla = null;
                return tempTabla;
            }
            else
            {
                return miProducto.ConsultaProductoPorMarca(codigo, nombre, marca, talla,
                    size, product, code, color, registroBase, registrosMaximos);
            }
        }

        /// <summary>
        /// Obtiene el total de registros de una consulta segun el codigo o el nombre y la marca.
        /// </summary>
        /// <param name="codigo">Codigo del producto a consultar.</param>
        /// <param name="nombre">Nombre o parte de este del producto a consultar.</param>
        /// <param name="marca">Marca o parte de esta a consultar.</param>
        /// <param name="talla">Talla o parte de esta a consultar.</param>
        /// <param name="size">Indica si la consulta incluye talla o no.</param>
        /// <param name="product">Indica si la consulta incluye Producto o no.</param>
        /// <param name="code">Indica si se consulta por Codigo del producto o no.</param>
        /// <param name="color">Indica si la consulta incluye color o no.</param>
        /// <returns></returns>
        public long RowsConsultaProductoPorMarca
            (string codigo, string nombre, string marca, string talla, bool size,
             bool product, bool code, bool color)
        {
            return miProducto.RowsConsultaProductoPorMarca(codigo, nombre, marca, talla, size, product,
                code, color);
        }

        /// <summary>
        /// Obtiene el listado de productos segun la talla.
        /// </summary>
        /// <param name="codigo">Codigo del producto a consultar.</param>
        /// <param name="nombre">Nombre o parte de este del producto a consultar.</param>
        /// <param name="talla">Talla o parte de esta a consultar.</param>
        /// <param name="product">Indica si la consulta incluye Producto o no.</param>
        /// <param name="code">Indica si se consulta por Codigo del producto o no.</param>
        /// <param name="color">Indica si la consulta incluye color o no.</param>
        /// <param name="registroBase">Registro base para la consulta.</param>
        /// <param name="registrosMaximos">Número de registros a recuperar.</param>
        /// <returns></returns>
        public DataTable ConsultaProductoPorTalla(string codigo, string nombre, string talla,
            bool product, bool code, bool color, int registroBase, int registrosMaximos)
        {
            if (color)
            {
                var tabla = miProducto.ConsultaProductoPorTalla(codigo, nombre, talla,
                    product, code, color, registroBase, registrosMaximos);
                var tempTabla = TablaProducto();
                foreach (DataRow row in tabla.Rows)
                {
                    var row_ = tempTabla.NewRow();
                    var c = new ElColor();
                    c.MapaBits = (string)row["Color"];
                    row_["CodigoInternoProducto"] = row["CodigoInternoProducto"];
                    row_["CodigoBarrasProducto"] = row["CodigoBarrasProducto"];
                    row_["NombreProducto"] = row["NombreProducto"];
                    row_["CodigoCategoria"] = row["CodigoCategoria"];
                    row_["NombreCategoria"] = row["NombreCategoria"];
                    row_["ValorVentaProducto"] = row["ValorVentaProducto"];
                    row_["ValorIva"] = row["ValorIva"];
                    row_["EstadoProducto"] = row["EstadoProducto"];
                    row_["NombreMarca"] = row["NombreMarca"];
                    row_["ReferenciaProducto"] = row["ReferenciaProducto"];
                    row_["Medida"] = row["Medida"];
                    row_["Color"] = c.ImagenBit;
                    tempTabla.Rows.Add(row_);
                }
                tabla.Clear();
                tabla = null;
                return tempTabla;
            }
            else
            {
                return miProducto.ConsultaProductoPorTalla(codigo, nombre, talla,
                            product, code, color, registroBase, registrosMaximos);
            }
        }

        /// <summary>
        /// Obtiene el total de registros de una consulta segun el codigo o el nombre y la talla.
        /// </summary>
        /// <param name="codigo">Codigo del producto a consultar.</param>
        /// <param name="nombre">Nombre o parte de este del producto a consultar.</param>
        /// <param name="talla">Talla o parte de esta a consultar.</param>
        /// <param name="product">Indica si la consulta incluye Producto o no.</param>
        /// <param name="code">Indica si se consulta por Codigo del producto o no.</param>
        /// <param name="color">Indica si la consulta incluye color o no.</param>
        /// <returns></returns>
        public long RowsConsultaProductoPorTalla(string codigo, string nombre, string talla,
            bool product, bool code, bool color)
        {
            return miProducto.RowsConsultaProductoPorTalla(codigo, nombre, talla, product, code, color);
        }

        /// <summary>
         /// Obtiene el registro completo de los datos de un Producto.
         /// </summary>
         /// <param name="codigo">Codigo Interno del producto a consultar.</param>
         /// <returns></returns>
        public Producto ProductoCompleto(string codigo)
        {
            return miProducto.ProductoCompleto(codigo);
        }

        /// <summary>
        /// Obtiene el listado de los registros de medida de los productos.
        /// </summary>
        /// <param name="codigo">Codigo del producto a consultar.</param>
        /// <returns></returns>
        public DataTable ProductoConMedida(string codigo)
        {
            return miProducto.ProductoConMedida(codigo);
        }

        /// <summary>
        /// Obtiene el listado de colores de un producto segun su medida.
        /// </summary>
        /// <param name="codigo">Codigo del producto a consultar.</param>
        /// <param name="idMedida">Id de la medida del Producto.</param>
        /// <returns></returns>
        public DataTable ProductoConMedidaYcolor(string codigo, int idMedida)
        {
            var tabla = miProducto.ProductoConMedidaYcolor(codigo, idMedida);
            var tempTabla = new DataTable();
            tempTabla.Columns.Add(new DataColumn("Id", typeof(int)));
            tempTabla.Columns.Add(new DataColumn("Color", typeof(System.Drawing.Image)));
            foreach (DataRow row in tabla.Rows)
            {
                var color = new ElColor();
                color.MapaBits = (string)row["stringcolor"];
                var row_ = tempTabla.NewRow();
                row_["Id"] = row["idcolor"];
                row_["Color"] = color.ImagenBit;
                tempTabla.Rows.Add(row_);
            }
            tabla.Clear();
            tabla = null;
            return tempTabla;
        }

        public double PrecioDeCosto(string codigo)
        {
            return miProducto.PrecioDeCosto(codigo);
        }

        public DataTable ImprimirProductos(bool addIva)
        {
            return miProducto.ImprimirProductos(addIva);
        }

        public void EditarUtilidadVenta
            (string codigo, double util, int valorVenta, double costo)
        {
            miProducto.EditarUtilidadVenta(codigo, util, valorVenta, costo);
        }

        public void EditarIva(string codigo, int idIva)
        {
            miProducto.EditarIva(codigo, idIva);
        }

        public void EditarDescuentos(string codigo, double desctoMayor, double desctoDistribuidor)
        {
            miProducto.EditarDescuentos(codigo, desctoMayor, desctoDistribuidor);
        }

        // Edicion de formulario de "Edicion de precio de producto."
        public void EditarPrecios(Producto p)
        {
            this.miProducto.EditarPrecios(p);
        }

        //

        /// <summary>
        /// Obtiene el último valor ingresado en factura de un Producto
        /// </summary>
        /// <param name="inventario">Inventario del producto a consultar.</param>
        /// <returns></returns>
        public int UltimoValorProducto(Inventario inventario)
        {
            return miProducto.UltimoValorProducto(inventario);
        }

        /// <summary>
        /// Obtiene un promedio de los valores de Producto segun facturas de proveedor.
        /// </summary>
        /// <param name="inventario">Inventario de Producto a consultar.</param>
        /// <returns></returns>
        public int PromedioValorProducto(Inventario inventario)
        {
            return miProducto.PromedioValorProducto(inventario);
        }


        /// <summary>
        /// Obtiene los datos basicos de un producto.
        /// </summary>
        /// <param name="codigo">Codigo a consultar.</param>
        /// <returns></returns>
        public ArrayList ProductoBasico(string codigo)
        {
            return miProducto.ProductoBasico(codigo);
        }

        public ValorUnidadMedida ProductoMedida(string codigo)
        {
            return this.miProducto.ProductoMedida(codigo);
        }

        /// <summary>
        /// Edita los datos de un registro de Producto.
        /// </summary>
        /// <param name="producto">Producto a editar.</param>
        public void EditarProducto(Producto producto)
        {
            miProducto.EditarProducto(producto);
        }

        public void EditarPrecioDeCosto(string codigo, double costo, double impoconsumo)
        {
            this.miProducto.EditarPrecioDeCosto(codigo, costo, impoconsumo);
        }

        public void EditarPrecioDeVenta(string codigo, int venta, double util)
        {
            this.miProducto.EditarPrecioDeVenta(codigo, venta, util);
        }

        /// <summary>
        /// Elimina el registro de Producto de la base de datos.
        /// </summary>
        /// <param name="codigo">Codigo Interno del Producto a eliminar.</param>
        public void EliminarProducto(string codigo)
        {
            miProducto.EliminarProducto(codigo);
        }

        /// <summary>
        /// Obtiene una DataTable tipado para la vista de Producto combina.
        /// </summary>
        /// <returns></returns>
        private DataTable TablaProducto()
        {
            var tabla = new DataTable();
            tabla.Columns.Add(new DataColumn("CodigoInternoProducto", typeof(string)));
            tabla.Columns.Add(new DataColumn("CodigoBarrasProducto", typeof(string)));
            tabla.Columns.Add(new DataColumn("NombreProducto", typeof(string)));
            tabla.Columns.Add(new DataColumn("CodigoCategoria", typeof(string)));
            tabla.Columns.Add(new DataColumn("NombreCategoria", typeof(string)));
            tabla.Columns.Add(new DataColumn("ValorVentaProducto", typeof(int)));
            tabla.Columns.Add(new DataColumn("ValorIva", typeof(double)));
            tabla.Columns.Add(new DataColumn("EstadoProducto", typeof(string)));
            tabla.Columns.Add(new DataColumn("NombreMarca", typeof(string)));
            tabla.Columns.Add(new DataColumn("ReferenciaProducto", typeof(string)));
            tabla.Columns.Add(new DataColumn("Medida", typeof(string)));
            tabla.Columns.Add(new DataColumn("Color", typeof(System.Drawing.Image)));
            return tabla;
        }

        // Descuentos por marca 01/03/2018

        public void IngresarValorDeProducto()
        {
            this.miProducto.IngresarValorDeProducto();
        }

        public int CountValorDeProducto()
        {
            return this.miProducto.CountValorDeProducto();
        }

        public void IngresarValorDeProducto(int idMarca)
        {
            this.miProducto.IngresarValorDeProducto(idMarca);
        }

        public int ValorDeProducto(string codigo)
        {
            return this.miProducto.ValorDeProducto(codigo);
        }

        public Marca DescuentoPrecio(string codigo)
        {
            return this.miProducto.DescuentoPrecio(codigo);
        }

        public void RestablecerValor(int idMarca)
        {
            this.miProducto.RestablecerValor(idMarca);
        }

        public void EliminarValorDeProducto()
        {
            this.miProducto.EliminarValorDeProducto();
        }

        public void EliminarValorDeProducto(int idMarca)
        {
            this.miProducto.EliminarValorDeProducto(idMarca);
        }

        // Funcion en uso. "02-06-2019"
        public void EliminarProductosNoNecesarios()
        {
            this.miProducto.EliminarProductosNoNecesarios();
        }


        /*public void ReiniciarSecuenciaProductoValor()
        {
            this.miProducto.ReiniciarSecuenciaProductoValor();
        }*/

        // Fin Descuentos por marca 01/03/2018




        // Metodo para buscar replicas entre Codigo Interno y Codigo de Barras en producto.
        public DataTable Replicas(bool codigo)
        {
            return miProducto.Replicas(codigo);
        }

        public DataTable ReplicasEnFactura()
        {
            return miProducto.ReplicasEnFactura();
        }

        public void AjustarReplicas(bool codigo)
        {
            miProducto.AjustarReplicas(codigo);
        }

        public void AjustarBarrasVacia()
        {
            miProducto.AjustarBarrasVacia();
        }

        public DataTable ProductosAll()
        {
            return this.miProducto.ProductosAll();
        }

        public void EditarUtilidad2_3(string codigo, double util2, double util3)
        {
            this.miProducto.EditarUtilidad2_3(codigo, util2, util3);
        }

        public void EditarUtilidad_2_3(string codigo, int venta, double util, double util2, double util3)
        {
            this.miProducto.EditarUtilidad_2_3(codigo, venta, util, util2, util3);
        }

        public void EditarInical(string codigo)
        {
            miProducto.EditarInical(codigo);
        }

        public DataTable UnidadDeMedida(string name)
        {
            return this.miProducto.UnidadDeMedida(name);
        }

        public DataTable UnidadDeMedida()
        {
            return this.miProducto.UnidadDeMedida();
        }

        // Consultas a producto mejoradas - Form nuevo - ilike multiples  Date: 22-05-2021

        public List<Producto> Productos(string[] filtros)
        {
            return miProducto.Productos(filtros);
        }

        public void EditPrice(string codigo, int price)
        {
            miProducto.EditPrice(codigo, price);
        }

        // End Date: 22-05-2021
    }
}