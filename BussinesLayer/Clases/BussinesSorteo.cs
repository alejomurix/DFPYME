using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO.Clases;
using DataAccessLayer.Clases;
using System.Data;

namespace BussinesLayer.Clases
{
    public class BussinesSorteo
    {
        private DaoSorteo miDaoSorteo = new DaoSorteo();

        private DaoMarca miDaoMarca = new DaoMarca();

        private DaoCategoria miDaoCategoria = new DaoCategoria();

        private DaoProducto miDaoProducto = new DaoProducto();

        /// <summary>
        /// Insertar sorteo.
        /// </summary>
        /// <param name="sorteo"></param>
        public void InsertaSorteo(Sorteo sorteo)
        {
            miDaoSorteo.IsartarSorteo(sorteo);
        }

        /// <summary>
        /// lista sorteo
        /// </summary>
        /// <returns></returns>
        public DataTable ListaSorteo(string estado, int registroBase, int registroMaximo)
        {
            return miDaoSorteo.ListarSorteo(estado , registroBase, registroMaximo);
        }

        /// <summary>
        /// Obtiene el total de los registros de estado sorteo
        /// </summary>
        /// <param name="estado">activo inactivo</param>
        /// <returns></returns>
        public long RowsListarEstadoSorteo(string estado)
        {
            return miDaoSorteo.RowsListarSorteosActivos(estado);
        }

        /// <summary>
        /// Edita sorteo
        /// </summary>
        /// <param name="sorteo"></param>
        public void EditaSorteo(Sorteo sorteo)
        {
            miDaoSorteo.Editasorteo(sorteo);
        }

        /// <summary>
        /// eliminar Sorteo.
        /// </summary>
        /// <param name="idsorteo"></param>
        public void EliminarSorteo(int idsorteo)
        {
            miDaoSorteo.EliminarSorteo(idsorteo);
        }

        /// <summary>
        /// lista el historial de el sorteo
        /// </summary>
        /// <returns></returns>
        public DataTable ListaHistorialSorteo(int registroBase, int registroMaximo)
        {
            return miDaoSorteo.ListarHistorialSorteo(registroBase ,registroMaximo);
        }

        /// <summary>
        /// Obtiene el total de los registros de historial sorteo.
        /// </summary>
        /// <returns></returns>
        public long RowsListarHistorialSorteo()
        {
            return miDaoSorteo.RowListarHistorialSorteo();
        }
        
        /// <summary>
        /// Lista sorteo nombre
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        public DataTable ListaSorteoNombre(string nombre, bool historial)
        {
            return miDaoSorteo.ListaSorteoNombre(nombre, historial);
        }

        /// <summary>
        /// Lista sorteo patrocinador.
        /// </summary>
        /// <param name="patrocinador"></param>
        /// <returns></returns>
        public DataTable ListaSorteoPatrocinador(string patrocinador, bool historial)
        {
            return miDaoSorteo.ListaSorteoPatrocinador(patrocinador, historial);
        }

        /// <summary>
        /// Consulta Nombre de sorteo.
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        public DataTable ConsultaSorteoNombre(string nombre, bool historial)
        {
            return miDaoSorteo.ConsultaNombreSorteo(nombre, historial);
        }

        /// <summary>
        /// Consulta patrocinador de sorteo.
        /// </summary>
        /// <param name="patrocinador"></param>
        /// <returns></returns>
        public DataTable ConsultaSorteoPatrocinador(string patrocinador, bool historial)
        {
            return miDaoSorteo.ConsultaPatrocinadorSorteo(patrocinador, historial);
        }

        /// <summary>
        /// Consulta sorteo marca por fecha
        /// </summary>
        /// <param name="idTipo">id tipo</param>
        /// <param name="idMarca">id marca</param>
        /// <param name="fechas">fecha</param>
        /// <param name="historial">determina el tipo de consulta</param>
        /// <returns></returns>
        public DataTable ConsultarSorteoMarcaFechas
            (int idTipo, int idMarca, DateTime fechas, bool historial)
        {
            return miDaoSorteo.ConsultarSorteoMarcaFechas(idTipo, idMarca, fechas, historial);
        }

        /// <summary>
        /// Consulta sorteo tipo marca fechas
        /// </summary>
        /// <param name="idTipo">id tipo</param>
        /// <param name="fecha">fecha</param>
        /// <param name="historial">determina el estado de la consulta</param>
        /// <param name="registroBase">registro base de la consulta</param>
        /// <param name="registroMaximo">numero de registros a recuperar</param>
        /// <returns></returns>
        public DataTable ConsultarSorteoMarcaFechas
            (int idTipo, DateTime fecha, bool historial, int registroBase, int registroMaximo)
        {
            return miDaoSorteo.ConsultarSorteoMarcaFechas(idTipo, fecha, historial, registroBase, registroMaximo);
        }

        /// <summary>
        /// Obtiene el total de los registros de sorteo tipo marca fechas
        /// </summary>
        /// <param name="idTipo">id tipo</param>
        /// <param name="fechas">fechas</param>
        /// <param name="historial">determina el estado de la consulta</param>
        /// <returns></returns>
        public long RowListarSorteoMarcaFechas
            (int idTipo, DateTime fechas, bool historial)
        {
            return miDaoSorteo.RowListarSorteoMarcaFechas(idTipo, fechas, historial);
        }

        /// <summary>
        /// Consulta sorteo marca periodo
        /// </summary>
        /// <param name="idTipo">id tipo</param>
        /// <param name="idMarca">id marca</param>
        /// <param name="fecha1">fecha1</param>
        /// <param name="fecha2">fecha2</param>
        /// <param name="historial">determina el estado de la consulta</param>
        /// <returns></returns>
        public DataTable ConsultarSorteoMarcaPeriodos
            (int idTipo, int idMarca, DateTime fecha1, DateTime fecha2, bool historial,int registroBase,int registroMaximo)
        {
            return miDaoSorteo.ConsultarSorteoMarcaPeriodo(idTipo, idMarca, fecha1, fecha2, historial, registroBase, registroMaximo);
        }

        /// <summary>
        /// Obtiene el total delos registros de sorteo marca periodos
        /// </summary>
        /// <param name="idTipo">id tipo</param>
        /// <param name="idMarca">id marca</param>
        /// <param name="fecha1">fecha1</param>
        /// <param name="fecha2">fecha2</param>
        /// <param name="historial">determina el valor de la consulta</param>
        /// <returns></returns>
        public long RowListarSorteoMarca
            (int idTipo, int idMarca, DateTime fecha1, DateTime fecha2, bool historial)
        {
            return miDaoSorteo.RowListarSorteoMarca(idTipo, idMarca, fecha1, fecha2, historial);
        }

        /// <summary>
        /// Consulta sorteo tipo marca periodos
        /// </summary>
        /// <param name="idTipo">id tipo</param>
        /// <param name="fecha1">fecha1</param>
        /// <param name="fecha2">fecha2</param>
        /// <param name="historial">determina el estado de la consulta</param>
        /// <param name="registroBase">registro base de la consulta</param>
        /// <param name="registroMaximo">numero de registros a recuperar</param>
        /// <returns></returns>
        public DataTable ConsultarSorteoMarcaPeriodos
            (int idTipo, DateTime fecha1, DateTime fecha2, bool historial, int registroBase, int registroMaximo)
        {
            return miDaoSorteo.ConsultarSorteoMarcaPeriodo(idTipo, fecha1, fecha2, historial, registroBase, registroMaximo);
        }

        /// <summary>
        /// Obtiene el total de los registros de sorteo marca periodo
        /// </summary>
        /// <param name="idTipo">id tipo</param>
        /// <param name="fecha1">fecha1</param>
        /// <param name="fecha2">fecha2</param>
        /// <param name="historial">determina el estado de la consulta</param>
        /// <returns></returns>
        public long RowListarSorteoMarcaPeriodo
            (int idTipo, DateTime fecha1, DateTime fecha2, bool historial)
        {
            return miDaoSorteo.RowListarSorteoMarcaPeriodo(idTipo, fecha1, fecha2, historial);
        }

        /// <summary>
        /// consulta sorteo categoria fechas
        /// </summary>
        /// <param name="idTipo">id tipo</param>
        /// <param name="codigoCategoria">codigo categoria</param>
        /// <param name="fechas">fechas</param>
        /// <param name="historial">determina el extado de la consulta</param>
        /// <returns></returns>
        public DataTable ConsultarSorteoCategoriaFechas
            (int idTipo, string codigoCategoria, DateTime fechas, bool historial)
        {
            return miDaoSorteo.ConsultarSorteoCategoriaFechas(idTipo, codigoCategoria, fechas, historial);
        }

        /// <summary>
        /// Consulta sorteo tipo categoria fechas
        /// </summary>
        /// <param name="idTipo">id tipo</param>
        /// <param name="fechas">fechas</param>
        /// <param name="historial">determina el estado de la consulta</param>
        /// <param name="registroBase">registro base de la consulta</param>
        /// <param name="registroMaximo">numero de registros a recuperar</param>
        /// <returns></returns>
        public DataTable ConsultarSorteoCategoriaFechas
            (int idTipo, DateTime fechas, bool historial,int registroBase,int registroMaximo)
        {
            return miDaoSorteo.ConsultarSorteoCategoriaFechas(idTipo, fechas, historial, registroBase, registroMaximo);
        }

        /// <summary>
        /// Obtiene el total de los registros de sorteo categoria.
        /// </summary>
        /// <param name="idTipo">id tipo</param>
        /// <param name="fechas">fechas</param>
        /// <param name="historial">determina el estado de la consulta</param>
        /// <returns></returns>
        public long RowListarSorteoCategoriaFechas
            (int idTipo, DateTime fechas, bool historial)
        {
            return miDaoSorteo.RowListarSorteoCategoriaFechas(idTipo, fechas, historial);
        }

        /// <summary>
        /// Consulta sorteo categoria periodos
        /// </summary>
        /// <param name="idTipo">id tipo</param>
        /// <param name="codigoCategoria">codigo categoria</param>
        /// <param name="fecha1">fecha1</param>
        /// <param name="fecha2">fecha2</param>
        /// <param name="historia">determina el estado de la consulta</param>
        /// <returns></returns>
        public DataTable ConsultarSorteoCategoriaPeriodos
            (int idTipo, string codigoCategoria, DateTime fecha1, DateTime fecha2, bool historia, int registroBase, int registroMaximo)
        {
            return miDaoSorteo.ConsultarSorteoCategoriaPeriodos(idTipo, codigoCategoria, fecha1, fecha2, historia, registroBase, registroMaximo);
        }

        /// <summary>
        /// Obtiene el total de los registros de sorteo categoria periodos
        /// </summary>
        /// <param name="idTipo">id tipo</param>
        /// <param name="codigoCategoria">codigo categoria</param>
        /// <param name="fecha1">fecha1</param>
        /// <param name="fecha2">fecha2</param>
        /// <param name="historial">determina el valor de la cosulta</param>
        /// <returns></returns>
        public long RowListarSorteoCategoria
            (int idTipo, string codigoCategoria, DateTime fecha1, DateTime fecha2, bool historial)
        {
            return miDaoSorteo.RowListarSorteoCategoria(idTipo, codigoCategoria, fecha1, fecha2, historial);
        }

        /// <summary>
        /// consulta sorteo tipo categoria periodo
        /// </summary>
        /// <param name="idTipo">id tipo</param>
        /// <param name="fecha1">fecha1</param>
        /// <param name="fecha2">fecha2</param>
        /// <param name="historial">determina el esatado de la consulta</param>
        /// <param name="registroBase">registro base de la consulta</param>
        /// <param name="registroMaximo">numero de registros a recuperar</param>
        /// <returns></returns>
        public DataTable ConsultarSorteoCategoriaPeriodos
            (int idTipo, DateTime fecha1, DateTime fecha2, bool historial, int registroBase, int registroMaximo)
        {
            return miDaoSorteo.ConsultarSorteoCategoriaPeriodos(idTipo, fecha1, fecha2, historial, registroBase, registroMaximo);
        }

        /// <summary>
        /// Obtiene el total de los registros de sorteo categoria periodos
        /// </summary>
        /// <param name="idTipo">id tipo</param>
        /// <param name="fecha1">fecha1</param>
        /// <param name="fecha2">fecha2</param>
        /// <param name="historial">determina el estado de la consulta</param>
        /// <returns></returns>
        public long RowListarSorteoCategoriaPeriodos
            (int idTipo, DateTime fecha1, DateTime fecha2, bool historial)
        {
            return miDaoSorteo.RowListarSorteocategoriaPeriodos(idTipo, fecha1, fecha2, historial);
        }

        /// <summary>
        /// consulta sorteo producto fechas
        /// </summary>
        /// <param name="idTipo">id tipo</param>
        /// <param name="codigoInternoProducto">codigo interno producto</param>
        /// <param name="fechas">fechas</param>
        /// <param name="historial">determina el valor de la consulta</param>
        /// <returns></returns>
        public DataTable ConsultarSorteoProductoFechas
            (int idTipo, string codigoInternoProducto, DateTime fechas, bool historial)
        {
            return miDaoSorteo.ConsultarSorteoProductoFechas(idTipo, codigoInternoProducto, fechas, historial);
        }

        /// <summary>
        /// Consulta sorteo tipo producto fechas
        /// </summary>
        /// <param name="idTipo">id tipo</param>
        /// <param name="fechas">fechas</param>
        /// <param name="historial">determina el valor de la consulta</param>
        /// <param name="registroBase">registro base de la consulta</param>
        /// <param name="registroMaximo">numero de registros a recuperar</param>
        /// <returns></returns>
        public DataTable ConsultarSorteoProductoFechas
            (int idTipo, DateTime fechas, bool historial, int registroBase, int registroMaximo)
        {
            return miDaoSorteo.ConsultarSorteoProductoFechas(idTipo, fechas, historial, registroBase, registroMaximo);
        }

        /// <summary>
        /// Obtiene el total de los registros de sorteo tipo producto fechas
        /// </summary>
        /// <param name="idTipo">id tipo</param>
        /// <param name="fechas">fechas</param>
        /// <param name="historial">determina el valor de la consulta</param>
        /// <returns></returns>
        public long RowListarSorteoProductoFechas
            (int idTipo, DateTime fechas, bool historial)
        {
            return miDaoSorteo.RowListarSorteoProductoFechas(idTipo, fechas, historial);
        }

        /// <summary>
        /// consulta sorteo producto periodos
        /// </summary>
        /// <param name="idTipo">id tipo</param>
        /// <param name="codigoInternoProducto">codigo internoproducto</param>
        /// <param name="fecha1">fecha1</param>
        /// <param name="fecha2">fecha2</param>
        /// <param name="historial">determina el estado de la consulta</param>
        /// <returns></returns>
        public DataTable ConsultarSorteoProductoPeriodo
            (int idTipo, string codigoInternoProducto, DateTime fecha1, DateTime fecha2 ,bool historial,int registroBase, int registroMaximo)
        {
            return miDaoSorteo.ConsultarSorteoProductoPeriodos(idTipo, codigoInternoProducto, fecha1, fecha2, historial, registroBase, registroMaximo);
        }

        /// <summary>
        /// Obtiene el total de los registros de sorteo producto periodos
        /// </summary>
        /// <param name="idTipo">id tipo</param>
        /// <param name="codigoInternoProducto">codigo interno producto</param>
        /// <param name="fecha1">fecha1</param>
        /// <param name="fecha2">fecha2</param>
        /// <param name="historial">determina el valor de la consulta</param>
        /// <returns></returns>
        public long RowListarSorteoProducto
            (int idTipo, string codigoInternoProducto, DateTime fecha1, DateTime fecha2, bool historial)
        {
            return miDaoSorteo.RowListarSorteoProducto(idTipo, codigoInternoProducto, fecha1, fecha2, historial);
        }

        /// <summary>
        /// Consulta sorteo tipo producto periodo
        /// </summary>
        /// <param name="idTipo">id tipo</param>
        /// <param name="fecah1">fecha1</param>
        /// <param name="fecha2">fecha2</param>
        /// <param name="historial">determina el valor de la consulta</param>
        /// <param name="registroBase">registro base de la consulta</param>
        /// <param name="registroMaximo">numero de registros a recuperar</param>
        /// <returns></returns>
        public DataTable ConsultarSorteoProductoPeriodo
            (int idTipo, DateTime fecah1, DateTime fecha2, bool historial, int registroBase, int registroMaximo)
        {
            return miDaoSorteo.ConsultarSorteoProductoPeriodos(idTipo, fecah1, fecha2, historial, registroBase, registroMaximo);
        }

        /// <summary>
        /// Obtiene el total de los registros de sorteo producto.
        /// </summary>
        /// <param name="idTipo">id tipo</param>
        /// <param name="fecha1">fecha1</param>
        /// <param name="fecha2">fecha2</param>
        /// <param name="historial">determina el valor de la consulta</param>
        /// <returns></returns>
        public long RowListarSorteoProductoPeriodo
            (int idTipo, DateTime fecha1, DateTime fecha2, bool historial)
        {
            return RowListarSorteoProductoPeriodo(idTipo, fecha1, fecha2, historial);
        }

        /// <summary>
        /// Consultar sorteo factura fechas
        /// </summary>
        /// <param name="idTipo">id tipo</param>
        /// <param name="fechas">fechas</param>
        /// <param name="historial">determina el valor de la consulta</param>
        /// <returns></returns>
        public DataTable ConsultarSorteoFacturaFechas
            (int idTipo, DateTime fechas, bool historial)
        {
            return miDaoSorteo.ConsultarSorteoFacturaFechas(idTipo, fechas, historial);
        }

        /// <summary>
        /// Consulta sorteo factuta periodo
        /// </summary>
        /// <param name="idTipo">id tipo</param>
        /// <param name="fecha1">fecha1</param>
        /// <param name="fecha2">fecha2</param>
        /// <param name="historial">determina el valor de la consulta</param>
        /// <param name="registroBase">registro base de la consulta</param>
        /// <param name="registroMaximo">numero de registroa a recuperar</param>
        /// <returns></returns>
        public DataTable ConsultarSorteoFacturaPeriodo
            (int idTipo, DateTime fecha1, DateTime fecha2, bool historial, int registroBase, int registroMaximo)
        {
            return miDaoSorteo.ConsultarSorteoFacturaPeriodos
                (idTipo, fecha1, fecha2, historial, registroBase, registroMaximo);
        }

        /// <summary>
        /// Obtiene el total de los registros de sorteo factura
        /// </summary>
        /// <param name="idTipo">id tipo</param>
        /// <param name="fecha1">fecha1</param>
        /// <param name="fecha2">fecha2</param>
        /// <param name="historial">determina el valor de la consulta</param>
        /// <returns></returns>
        public long RowListarSorteoFactura
            (int idTipo, DateTime fecha1, DateTime fecha2, bool historial)
        {
            return miDaoSorteo.RowListarSorteoFacturaPeriodo(idTipo, fecha1, fecha2, historial);
        }

        /// <summary>
        /// consulta sorteo fechas
        /// </summary>
        /// <param name="fechas">fechas</param>
        /// <param name="historial">determina el valor de la consulta</param>
        /// <param name="registroBase">registro base de la consulta</param>
        /// <param name="registroMaximo">numero de registros a recuperar</param>
        /// <returns></returns>
        public DataTable ConsultarSorteoFechas
            (DateTime fechas, bool historial, int registroBase, int registroMaximo)
        {
            return miDaoSorteo.ConsultarSorteoFechas(fechas, historial, registroBase, registroMaximo);
        }

        /// <summary>
        /// Obtine el total de los registros de sorteo fechas
        /// </summary>
        /// <param name="fechas">fechas</param>
        /// <param name="historial">determina el estado de la consulta</param>
        /// <returns></returns>
        public long RowListarSorteoFechas
            (DateTime fechas, bool historial)
        {
            return miDaoSorteo.RowListarSorteoFechas(fechas, historial);
        }

        /// <summary>
        /// Consulta sorteo periodos
        /// </summary>
        /// <param name="fecha1">fecha1</param>
        /// <param name="fecha2">fecha2</param>
        /// <param name="historial">determina el valor de las consultas</param>
        /// <param name="registroBase">registro base de la consulta</param>
        /// <param name="registroMaximo">numero de registros a recuperar</param>
        /// <returns></returns>
        public DataTable ConsultarSorteoPeriodos
            (DateTime fecha1, DateTime fecha2, bool historial, int registroBase, int registroMaximo)
        {
            return miDaoSorteo.ConsultarSorteoPeriodos(fecha1, fecha2, historial, registroBase, registroMaximo);
        }

        /// <summary>
        /// Obtiene el total de los registros de sorteo periodos
        /// </summary>
        /// <param name="fecha1">fecha1</param>
        /// <param name="fecha2">fecha2</param>
        /// <param name="historial">determina el valor de la consulta</param>
        /// <returns></returns>
        public long RowListarSorteoPeriodos
            (DateTime fecha1, DateTime fecha2, bool historial)
        {
            return miDaoSorteo.RowListarSorteoPeriodo(fecha1, fecha2, historial);
        }        

        /// <summary>
        /// Lista sorteo por fecha simple,
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public DataTable ConsultarFechaInicio
            (DateTime fecha, bool historial)
        {
            return miDaoSorteo.ConsultaSorteoFechaInicioFechas(fecha, historial);
        }       

        /// <summary>
        /// ConsultaSorteo fecha inicio periodos.
        /// </summary>
        /// <param name="fecha1">fecha1</param>
        /// <param name="fecha2">fecha2</param>
        /// <param name="historial">determina el valor de la consulta</param>
        /// <param name="registroBase">registro base de la consulta</param>
        /// <param name="registroMaximo">numero de registros a recuperar</param>
        /// <returns></returns>
        public DataTable ConsultarSorteoFechaInicioPeriodos
            (DateTime fecha1, DateTime fecha2,bool historial, int registroBase, int registroMaximo)
        {
            return miDaoSorteo.ConsultaSorteoFechaInicioPeriodo(fecha1,fecha2,historial,registroBase,registroMaximo);
        }

        /// <summary>
        /// Obtiene el total de registros de sorteo fecha inicio periodo.
        /// </summary>
        /// <param name="fecha1">fecha1</param>
        /// <param name="fecha2">fecha2</param>
        /// <param name="historial">determina el valor de la consulta</param>
        /// <returns></returns>
        public long RowListarSorteoFechaInicio
            (DateTime fecha1, DateTime fecha2, bool historial)
        {
            return miDaoSorteo.RowListarFechaInicioPeriodos(fecha1,fecha2,historial);
        }

        /// <summary>
        /// Consulta sorteo fecha fin.
        /// </summary>
        /// <param name="fecha">fecha</param>
        /// <param name="historial">determina el valor de la consulta</param>
        /// <returns></returns>
        public DataTable ConsultarSorteoFechaFinFechas
            (DateTime fecha, bool historial)
        {
            return miDaoSorteo.ConsultaSorteoFechaFinFechas(fecha, historial);
        }

        /// <summary>
        /// Consulta Sorteo fecha Fin periodos
        /// </summary>
        /// <param name="fecha1">fecha1</param>
        /// <param name="fecha2">fecha2</param>
        /// <param name="historial">determina el valor de la consulta</param>
        /// <param name="registroBase">registro base de la consulta</param>
        /// <param name="registroMaximo">numero de registros a recuperar</param>
        /// <returns></returns>
        public DataTable ConsultarSorteoFechaFinPeriodo
            (DateTime fecha1, DateTime fecha2, bool historial, int registroBase, int registroMaximo)
        {
            return miDaoSorteo.ConsultaSorteoFechaFinPeriodo(fecha1, fecha2, historial, registroBase, registroMaximo);
        }

        /// <summary>
        /// Obtiene el total de los registros de sorteo fecha fin
        /// </summary>
        /// <param name="fecha1">fecha1</param>
        /// <param name="fecha2">fecha2</param>
        /// <param name="historial">determina el valor de la consulta</param>
        /// <returns></returns>
        public long RowListarSorteoFechaFin
            (DateTime fecha1, DateTime fecha2, bool historial)
        {
            return miDaoSorteo.RowListarFechaFinPeriodos(historial, fecha1, fecha2);
        }

        /// <summary>
        /// Consulta sorteo fecha sorteo fechas
        /// </summary>
        /// <param name="fecha">fecha</param>
        /// <param name="historial">determina el estado de la consulta</param>
        /// <returns></returns>
        public DataTable ConsultarSorteoFechaSorteo
            (DateTime fecha, bool historial)
        {
            return miDaoSorteo.ConsultaSorteoFechaSorteoFechas(fecha, historial);
        }

        /// <summary>
        /// Consultar sorteo fecha sorteo periodos
        /// </summary>
        /// <param name="fecha1">fecha1</param>
        /// <param name="fecha2">fecha2</param>
        /// <param name="historial">determina el valor de la consulta</param>
        /// <param name="registroBase">registro base de la consulta</param>
        /// <param name="registroMaximo">numero de registros a recuperar</param>
        /// <returns></returns>
        public DataTable ConsultarSorteoFechaSorteoPeriodo
            (DateTime fecha1, DateTime fecha2, bool historial,int registroBase,int registroMaximo)
        {
            return miDaoSorteo.ConsultaSorteoFechaSorteoperiodos(fecha1, fecha2, historial, registroBase, registroMaximo);
        }

        /// <summary>
        /// Obtine el total de los registros de fecha sorteo periodo
        /// </summary>
        /// <param name="fecha1">fecha1</param>
        /// <param name="fecha2">fecha2</param>
        /// <param name="historial">determina el valor de la consulta</param>
        /// <returns></returns>
        public long RowListarSorteofechaSorteo
            (DateTime fecha1, DateTime fecha2, bool historial)
        {
            return miDaoSorteo.RowListarFechaSorteoPeriodo(historial,fecha1,fecha2);
        }

        /// <summary>
        /// Existe marca sorteo
        /// </summary>
        /// <param name="codigo">codigo</param>
        /// <param name="fecha1">fecha1</param>
        /// <param name="fecha2">fecha2</param>
        /// <returns></returns>
        public bool ExisteSorteoMarca(int codigo, DateTime fecha1, DateTime fecha2)
        {
            return miDaoSorteo.ExisteSorteoMarca(codigo, fecha1, fecha2);
        }

        /// <summary>
        /// Existe sorteo categoria
        /// </summary>
        /// <param name="codigo">codigo</param>
        /// <param name="fecha1">fecha1</param>
        /// <param name="fecha2">fecha2</param>
        /// <returns></returns>
        public bool ExisteSorteocategoria(string codigo, DateTime fecha1, DateTime fecha2)
        {
            return miDaoSorteo.ExisteSorteoCategoria(codigo, fecha1, fecha2);
        }

        /// <summary>
        /// Existe sorteo Producto.
        /// </summary>
        /// <param name="codigo">codigo</param>
        /// <param name="fecha1">fecha1</param>
        /// <param name="fecha2">fecha2</param>
        /// <returns></returns>
        public bool ExisteSorteoProducto(string codigo, DateTime fecha1, DateTime fecha2)
        {
            return miDaoSorteo.ExisteSorteoProducto(codigo, fecha1, fecha2);
        }

        /// <summary>
        /// Existe sorteo factura
        /// </summary>
        /// <param name="idTipo">id tipo factura</param>
        /// <param name="fecha1">fecha1</param>
        /// <param name="fecha2">fecha2</param>
        /// <returns></returns>
        public bool ExisteSorteoFactura(int idTipo, DateTime fecha1, DateTime fecha2)
        {
            return miDaoSorteo.ExisteSorteoFactura(idTipo, fecha1, fecha2);
        }

        /// <summary>
        /// carga sorteo.
        /// </summary>
        /// <param name="idsorteo"></param>
        /// <returns></returns>
        public Sorteo CargaSorteo(int idsorteo,bool historial)
        {
            return miDaoSorteo.CargarSorteo(idsorteo,historial);
        }

        /// <summary>
        /// Eliminar marca del sorteo,
        /// </summary>
        /// <param name="idSorteoOriginal"></param>
        /// <param name="idMarca"></param>
        public void EliminarMarcaSoreo(int idSorteoOriginal, int idMarca)
        {
            miDaoSorteo.EliminaSorteoMarca(idSorteoOriginal, idMarca);
        }

        /// <summary>
        /// Eliminar categoria sorteo.
        /// </summary>
        /// <param name="idSorteoOriginal">idsorteoOriginal a eliminar</param>
        /// <param name="codigoCategoria">codigo categoria a eliminar</param>
        public void EliminaCategoriaSorteo(int idSorteoOriginal, string codigoCategoria)
        {
            miDaoSorteo.EliminaSorteoCategoria(idSorteoOriginal, codigoCategoria);
        }

        /// <summary>
        /// Elimina producto de sorteo
        /// </summary>
        /// <param name="idSorteoOriginal">idSorteoOriginal a eliminar</param>
        /// <param name="codigointernoproducto">codigointernoproducto a eliminar</param>
        public void EliminarProductoSorteo(int idSorteoOriginal, string codigointernoproducto)
        {
            miDaoSorteo.EliminaSorteoProducto(idSorteoOriginal, codigointernoproducto);
        }

        /// <summary>
        /// insertar marcas a sorteo.
        /// </summary>
        /// <param name="idSorteOriginal">id sorteo</param>
        /// <param name="idmarca">id de marca</param>
        public void InsertaMarcaSorteo(int idSorteOriginal, int idmarca, bool historial)
        {
            miDaoMarca.InsertaSorteoMarca(idSorteOriginal, idmarca, historial);
        }

        /// <summary>
        /// insertar categoria a sorteo.
        /// </summary>
        /// <param name="idSorteoOriginal">id del sorteo</param>
        /// <param name="codigoCategoria">codigo categoria</param>
        public void InsertarCategoriaSorteo(int idSorteoOriginal, string codigoCategoria, bool historial)
        {
            miDaoCategoria.InsertarSorteoCategoria(idSorteoOriginal, codigoCategoria, historial);
        }

        /// <summary>
        /// Insertar codigo de sorteo
        /// </summary>
        /// <param name="idSorteoOriginal">id sorteo original</param>
        /// <param name="codigoInternoProducto">codigo interno de producto</param>
        public void InsertaProductoSorteo(int idSorteoOriginal, string codigoInternoProducto, bool historial)
        {
            miDaoProducto.InsertarProductoSorteo(idSorteoOriginal, codigoInternoProducto, historial);
        }        

        /// <summary>
        /// Carga cliente ganador
        /// </summary>
        /// <param name="idSorteoOriginal">id del sorteo</param>
        /// <param name="codigoFacturaVenta">codigo factura ganador</param>
        /// <returns></returns>
        public Cliente ClienteGanadorSorteo(int idSorteoOriginal, int codigoFacturaVenta)
        {
            return miDaoSorteo.ClienteGanadorSorteo(idSorteoOriginal, codigoFacturaVenta);
        }

        /// <summary>
        /// Ingresar ganador a sorteo.
        /// </summary>
        /// <param name="idSorteo"></param>
        /// <param name="codigoFactura"></param>
        public void IngresarGanador(int idSorteo, string codigoFactura)
        {
            miDaoSorteo.IngresarGanador(idSorteo, codigoFactura);
        }

        /// <summary>
        /// Lista cliente ganador historial sorteo.
        /// </summary>
        /// <param name="idsorteo"></param>
        /// <returns></returns>
        public Cliente HistorialClienteGanador(int idsorteo)
        {
            return miDaoSorteo.HistorialClienteGanador(idsorteo);
        }

        /// <summary>
        /// Lista las marcas selecccionadad de sorteo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Marca> MarcasSorteo(int id , bool historial)
        {
            return miDaoMarca.CargarMarcasSorteo(id, historial);
        }

        /// <summary>
        /// Lista las categorias de sorteo.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Categoria> CategoriaSorteo(int id, bool historial)
        {
            return miDaoCategoria.CargarCategoriaSorteo(id, historial);
        }

        /// <summary>
        /// Lista los productos de sorteo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Producto> CargarProducto(int id, bool historial)
        {
            return miDaoProducto.CargaProductoSorteo(id, historial);
        }
    }
}