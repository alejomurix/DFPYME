using System;
using System.Data;
using System.Linq;
using DTO.Clases;
using DataAccessLayer.Clases;
using System.Collections.Generic;
using Utilities;

namespace BussinesLayer.Clases
{
    /// <summary>
    /// Representa una clase de logica de negocio de Factura Venta.
    /// </summary>
    public class BussinesFacturaVenta
    {
        /// <summary>
        /// Proporciona acceso a la capa de datos de FacturaVenta.
        /// </summary>
        private DaoFacturaVenta miDaoFacturaVenta;

        /// <summary>
        /// Proporciona acceso a la capa de datos de ProductoFacturaVenta.
        /// </summary>
        private DaoProductoFacturaVenta miDaoProducto;

        private DaoCliente daoCliente;

        private DataTable Tabla { set; get; }

        private bool RedondearPrecio2 { set; get; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase BussinesFacturaVenta.
        /// </summary>
        public BussinesFacturaVenta()
        {
            try
            {
                this.miDaoFacturaVenta = new DaoFacturaVenta();
                this.miDaoProducto = new DaoProductoFacturaVenta();
                daoCliente = new DaoCliente();

                TablaResumen();
                this.RedondearPrecio2 = Convert.ToBoolean(AppConfiguracion.ValorSeccion("redondeo_precio_dos"));
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Obtiene el Número consecutivo a se asignado en la Factura.
        /// </summary>
        /// <returns></returns>
        public string ObtenerNumero(bool contado, int idRegimen)
        {
            return miDaoFacturaVenta.ObtenerNumero(contado, idRegimen);
        }

        /// <summary>
        /// Obtiene el número correspondiente al rango final del registro de la Dian.
        /// </summary>
        /// <returns></returns>
        public long ObtenerRangoFinal(bool contado)
        {
            return miDaoFacturaVenta.ObtenerRangoFinal(contado);
        }

        int Id;

        /// <summary>
        /// Ingresa el registro de una Factura a base de datos.
        /// </summary>
        /// <param name="factura">Factura a ingresar.</param>
        /// <param name="edicion">Indica si la factura proviene de una edición de la misma.</param>
        public int IngresarFactura(FacturaVenta factura, bool edicion, bool anutigua, bool consecutivoCaja)
        {
            Id = 0;
            factura.Total = factura.Productos.Sum(s => s.Total);
            Id = miDaoFacturaVenta.IngresarFactura(factura, edicion, anutigua, consecutivoCaja);
            factura.Puntos = CargarPuntos(factura.Punto, factura.Proveedor.NitProveedor, Id, factura.AplicaDescuento);
            return Id;
        }

        private double[] CargarPuntos(Punto punto, string nitCliente, int id, bool descto)
        {
            double[] data = new double[2];
            if (punto.EstadoPunto)
            {
                if (nitCliente != "1000" ||
                    nitCliente != "10" ||
                    nitCliente != "22222222" ||
                    nitCliente != "222222222222")
                {
                    try
                    {
                        int total =
                            PrintProducto(id, descto).Tables[0].AsEnumerable().Sum(d => d.Field<int>("Total_"));
                        double p = daoCliente.Puntos(nitCliente);
                        int puntos = 0;
                        if (punto.ValorVentaMinPunto > 0 && total > punto.ValorVentaMinPunto)
                        {
                            //puntos = Convert.ToInt32(total / punto.ValorPunto);
                            puntos = UseObject.RetiraDecima(total / punto.ValorPunto);
                            puntos *= Convert.ToInt32(punto.NumeroPuntos);
                            p += puntos;
                        daoCliente.EditarPuntos(nitCliente, p);
                            data[0] = puntos;
                            data[1] = p;
                        }
                        else
                        {
                            data[0] = 0;
                            data[1] = p;
                        }
                    }
                    catch (Exception)
                    {
                        data[0] = 0;
                        data[1] = 0;
                        //OptionPane.MessageError(ex.Message);
                    }
                }
            }
            return data;
        }

        public FacturaVenta FacturaDeVenta(string numero)
        {
            return miDaoFacturaVenta.FacturaDeVenta(numero);
        }

        public FacturaVenta FacturaDeVenta(int id)
        {
            return this.miDaoFacturaVenta.FacturaDeVenta(id);
        }


        // Act segment POS
        public void FromPOStoElectronic(FacturaVenta factura)
        {
            DataAccessLayer.Repository.RepositoryModel repositoryModel = new DataAccessLayer.Repository.RepositoryModel();
            var de = new DataAccessLayer.Models.ElectronicDocument
            {
                NitCliente = factura.Proveedor.NitProveedor,
                Tipo = "INVOIC",
                TipoFactura = "01",  // 01 fact venta nacional
                TipoOperacion = "10",  // 10 Estandar
                Moneda = "COP",
                MetodoPago = factura.EstadoFactura.Id,
                MedioPago = "10",    // 10 Efectivo
                TipoAmbiente = Convert.ToString(AppConfiguracion.ValorSeccion("type_enviroment")),
                VUBL = "UBL 2.1",
                VDIAN = "DIAN 2.1",
                IdCaja = factura.Caja.Id,
                FechaLimite = factura.FechaLimite,
                FechaPago = factura.FechaLimite//,
                //Neto = factura.Productos.Sum(p => p.Total)
            };
            if (de.NitCliente.Equals("22222222")) de.NitCliente += "2222";
            de = repositoryModel.AddElectronicDocument(de);
            int cont = 1;
            foreach (var p in factura.Productos)
            {
                if (!p.Retorno)
                {
                    var item = new DataAccessLayer.Models.Item
                    {
                        IDDE = de.ID,
                        Numero = cont,
                        Code = p.Producto.CodigoInternoProducto,
                        Description = p.Producto.NombreProducto,
                        UnitMedida = p.Producto.ValorUnidadMedida,
                        Quantity = p.Cantidad,
                        Costo = p.Producto.ValorCosto,
                        IVA = p.Producto.ValorIva,
                        IC = p.ImpoConsumo,
                        INC = 0,
                        UnitPrice = p.Price,
                        //Neto = p.Valor,

                        TypeStandar = new DataAccessLayer.Models.TypeStandar
                        {
                            CodeItem = p.Producto.CodigoInternoProducto,
                            CodeStandard = p.CodeStandard
                        }
                    };
                    item.Neto = Math.Round((Convert.ToDouble(item.UnitPrice) * (1 + (item.IVA / 100))), 3)
                            + item.IC;
                    item.Total = Math.Round(item.Neto * item.Quantity, 3);
                    repositoryModel.AddItem(item);
                    de.Items.Add(item);
                    cont++;
                }
            }
            de.Total = de.Neto = Math.Round(de.Items.Sum(i => i.Total), 3);
            repositoryModel.EditElectronicDocument(de);
        }

        // End Act segment POS


        /// <summary>
        /// Edita el cliente relacionado en la factura de venta.
        /// </summary>
        /// <param name="factura">Datos de la factura de venta a editar.</param>
        public void EditarCliente(FacturaVenta factura)
        {
            miDaoFacturaVenta.EditarCliente(factura);
        }

        public void EditarFactura(FacturaVenta factura)
        {
            miDaoFacturaVenta.EditarFactura(factura);
        }

        /// <summary>
        /// Obtiene los datos de la factura de venta para su impresión.
        /// </summary>
        /// <param name="numero">Número de la factura de venta.</param>
        /// <returns></returns>
        public DataSet PrintFacturaVenta(string numero)
        {
            return miDaoFacturaVenta.PrintFacturaVenta(numero);
        }

        public DataSet PrintFacturaVenta(int id)
        {
            return this.miDaoFacturaVenta.PrintFacturaVenta(id);
        }

        /// <summary>
        /// Obtiene los datos de los productos en una factura de venta para su impresión.
        /// </summary>
        /// <param name="numero">Número de la factura de venta.</param>
        /// <param name="descuento">Indica si el producto aplica descuento o no (recargo).</param>
        /// <returns></returns>
        public DataSet PrintProducto(int id, bool descuento)
        {
            return miDaoProducto.PrintProducto(id, descuento);
        }

        public DataTable ConsultaTodas(int rowBase, int rowMax)
        {
            return miDaoFacturaVenta.ConsultaTodas(rowBase, rowMax);
        }

        public long GetRowsConsultaTodas()
        {
            return miDaoFacturaVenta.GetRowsConsultaTodas();
        }

        public DataTable ConsultaTodas(DateTime fecha, int rowBase, int rowMax)
        {
            return miDaoFacturaVenta.ConsultaTodas(fecha, rowBase, rowMax);
        }

        public long GetRowsConsultaTodas(DateTime fecha)
        {
            return miDaoFacturaVenta.GetRowsConsultaTodas(fecha);
        }

        public DataTable ConsultaTodas(DateTime fecha, DateTime fecha2, int rowBase, int rowMax)
        {
            return miDaoFacturaVenta.ConsultaTodas(fecha, fecha2, rowBase, rowMax);
        }

        public long GetRowsConsultaTodas(DateTime fecha, DateTime fecha2)
        {
            return miDaoFacturaVenta.GetRowsConsultaTodas(fecha, fecha2);
        }
        
        /// <summary>
        /// Obtiene el resultado de la consulta de Factura de Venta por número.
        /// </summary>
        /// <param name="numero">Número de la Factura a consultar.</param>
        /// <returns></returns>
        public DataTable ConsultaNumero(string numero)
        {
            return miDaoFacturaVenta.ConsultaNumero(numero);
        }

        /// <summary>
        /// Obtiene el resultado de la consulta de Factura de Venta por Estado de la Factura.
        /// </summary>
        /// <param name="estado">Estado de la factura a consultar.</param>
        /// <param name="rowBase">Registro base para la consulta.</param>
        /// <param name="rowMax">Número de registros a recuperar.</param>
        /// <returns></returns>
        public DataTable ConsultaEstado(int estado, int rowBase, int rowMax)
        {
            return miDaoFacturaVenta.ConsultaEstado(estado, rowBase, rowMax);
        }

        /// <summary>
        /// Obtiene el total de registros de resultado de la consulta de Factura de Venta 
        /// por Estado de la Factura.
        /// </summary>
        /// <param name="estado">Estado de la factura a consultar.</param>
        /// <returns></returns>
        public long GetRowsConsultaEstado(int estado)
        {
            return miDaoFacturaVenta.GetRowsConsultaEstado(estado);
        }

        /// <summary>
        /// Obtiene el resultado de la consulta de Factura de Venta por Estado de la Factura 
        /// y fecha de ingreso de la misma.
        /// </summary>
        /// <param name="estado">Estado de la factura a consultar.</param>
        /// <param name="fecha">Fecha de ingreso a consultar la factura.</param>
        /// <param name="rowBase">Registro base para la consulta.</param>
        /// <param name="rowMax">Número de registros a recuperar.</param>
        /// <returns></returns>
        public DataTable ConsultaEstadoFechaIngreso
            (int estado, DateTime fecha, int rowBase, int rowMax)
        {
            return miDaoFacturaVenta.ConsultaEstadoFechaIngreso
                (estado, fecha, rowBase, rowMax);
        }

        /// <summary>
        /// Obtiene el total de registros de la consulta de Factura de Venta por Estado de la Factura 
        /// y fecha de ingreso de la misma.
        /// </summary>
        /// <param name="estado">Estado de la factura a consultar.</param>
        /// <param name="fecha">Fecha de ingreso a consultar la factura.</param>
        /// <returns></returns>
        public long GetRowsConsultaEstadoFechaIngreso(int estado, DateTime fecha)
        {
            return miDaoFacturaVenta.GetRowsConsultaEstadoFechaIngreso(estado, fecha);
        }

        /// <summary>
        /// Obtiene el resultado de la consulta de Factura de Venta por Estado de la Factura 
        /// y un periodo de fechas para la consulta en la fecha de ingreso.
        /// </summary>
        /// <param name="estado">Estado de la factura a consultar.</param>
        /// <param name="fecha1">Primer rango de fecha.</param>
        /// <param name="fecha2">Segundo rango de fecha.</param>
        /// <param name="rowBase">Registro base para la consulta.</param>
        /// <param name="rowMax">Número de registros a recuperar.</param>
        /// <returns></returns>
        public DataTable ConsultaEstadoPeriodoIngreso
            (int estado, DateTime fecha1, DateTime fecha2, int rowBase, int rowMax)
        {
            return miDaoFacturaVenta.ConsultaEstadoPeriodoIngreso
                (estado, fecha1, fecha2, rowBase, rowMax);
        }

        public DataTable ConsultaEstadoPeriodoIngreso
                         (int estado, DateTime fecha1, DateTime fecha2)
        {
            return miDaoFacturaVenta.ConsultaEstadoPeriodoIngreso(estado, fecha1, fecha2);
        }

        /// <summary>
        /// Obtiene el total de registros de la consulta de Factura de Venta por Estado de la Factura 
        /// y un periodo de fechas para la consulta en la fecha de ingreso.
        /// </summary>
        /// <param name="estado">Estado de la factura a consultar.</param>
        /// <param name="fecha1">Primer rango de fecha.</param>
        /// <param name="fecha2">Segundo rango de fecha.</param>
        /// <returns></returns>
        public long GetRowsConsultaEstadoPeriodoIngreso
            (int estado, DateTime fecha1, DateTime fecha2)
        {
            return miDaoFacturaVenta.GetRowsConsultaEstadoPeriodoIngreso(estado, fecha1, fecha2);
        }

        /// <summary>
        /// Obtiene el resultado de la consulta de Factura de Venta por Cliente 
        /// relacionado con la misma.
        /// </summary>
        /// <param name="cliente">Cliente a consultar factura de venta.</param>
        /// <param name="rowBase">Registro base para la consulta.</param>
        /// <param name="rowMax">Número de registros a recuperar.</param>
        /// <returns></returns>
        public DataTable ConsultaPorCliente(string cliente, int rowBase, int rowMax)
        {
            return miDaoFacturaVenta.ConsultaPorCliente(cliente, rowBase, rowMax);
        }

        /// <summary>
        /// Obtiene el total de registros de la consulta de de Factura de Venta por Cliente 
        /// relacionado con la misma.
        /// </summary>
        /// <param name="cliente">Cliente a consultar factura de venta.</param>
        /// <returns></returns>
        public long GetRowsConsultaPorCliente(string cliente)
        {
            return miDaoFacturaVenta.GetRowsConsultaPorCliente(cliente);
        }

        /// <summary>
        /// Obtiene el resultado de la consulta de Factura de Venta por estado y Cliente.
        /// </summary>
        /// <param name="estado">Estado de la factura a consultar.</param>
        /// <param name="cliente">Cliente a consultar factura de venta.</param>
        /// <param name="rowBase">Registro base para la consulta.</param>
        /// <param name="rowMax">Número de registros a recuperar.</param>
        /// <returns></returns>
        public DataTable ConsultaPorEstadoYcliente
            (int estado, string cliente, int rowBase, int rowMax)
        {
            return miDaoFacturaVenta.ConsultaPorEstadoYcliente
                (estado, cliente, rowBase, rowMax);
        }

        /// <summary>
        /// Obtiene el total de registros de la consulta de Factura de Venta por estado y Cliente.
        /// </summary>
        /// <param name="estado">Estado de la factura a consultar.</param>
        /// <param name="cliente">Cliente a consultar factura de venta.</param>
        /// <returns></returns>
        public long GetRowsConsultaPorEstadoYcliente(int estado, string cliente)
        {
            return miDaoFacturaVenta.GetRowsConsultaPorEstadoYcliente(estado, cliente);
        }

        /// <summary>
        /// Obtiene el resultado de la consulta de Factura de Venta por Cliente 
        /// y fecha de ingreso de la misma.
        /// </summary>
        /// <param name="cliente">Cliente a consultar factura de venta.</param>
        /// <param name="fecha">Fecha de ingreso a consultar la factura.</param>
        /// <param name="rowBase">Registro base para la consulta.</param>
        /// <param name="rowMax">Número de registros a recuperar.</param>
        /// <returns></returns>
        public DataTable ConsultaPorClienteIngreso
            (string cliente, DateTime fecha, int rowBase, int rowMax)
        {
            return miDaoFacturaVenta.ConsultaPorClienteIngreso
                (cliente, fecha, rowBase, rowMax);
        }

        /// <summary>
        /// Obtiene el total de registros de la consulta de Factura de Venta por Cliente 
        /// y fecha de ingreso de la misma.
        /// </summary>
        /// <param name="cliente">Cliente a consultar factura de venta.</param>
        /// <param name="fecha">Fecha de ingreso a consultar la factura.</param>
        /// <returns></returns>
        public long GetRowsConsultaPorClienteIngreso(string cliente, DateTime fecha)
        {
            return miDaoFacturaVenta.GetRowsConsultaPorClienteIngreso(cliente, fecha);
        }

        /// <summary>
        /// Obtiene el resultado de la consulta de Factura de Venta por Estado, 
        /// Cliente y fecha de ingreso.
        /// </summary>
        /// <param name="estado">Estado de la factura a consultar.</param>
        /// <param name="cliente">Cliente a consultar factura de venta.</param>
        /// <param name="fecha">Fecha de ingreso a consultar la factura.</param>
        /// <returns></returns>
        public DataTable ConsultaPorEstadoClienteIngreso
            (int estado, string cliente, DateTime fecha, int rowBase, int rowMax)
        {
            return 
                miDaoFacturaVenta.ConsultaPorEstadoClienteIngreso(estado, cliente, fecha, rowBase, rowMax);
        }

        public long GetRowsConsultaPorEstadoClienteIngreso(int estado, string cliente, DateTime fecha)
        {
            return miDaoFacturaVenta.GetRowsConsultaPorEstadoClienteIngreso(estado, cliente, fecha);
        }


        /// <summary>
        /// Obtiene el resultado de la consulta de Factura de Venta por Cliente 
        /// en un periodo de fechas de ingreso.
        /// </summary>
        /// <param name="cliente">Cliente a consultar factura de venta.</param>
        /// <param name="fecha1">Primer rango de fecha.</param>
        /// <param name="fecha2">Segundo rango de fecha.</param>
        /// <param name="rowBase">Registro base para la consulta.</param>
        /// <param name="rowMax">Número de registros a recuperar.</param>
        /// <returns></returns>
        public DataTable ConsultaPorClientePeriodoIngreso
            (string cliente, DateTime fecha1, DateTime fecha2, int rowBase, int rowMax)
        {
            return miDaoFacturaVenta.ConsultaPorClientePeriodoIngreso
                (cliente, fecha1, fecha2, rowBase, rowMax);
        }

        /// <summary>
        /// Obtiene el total de registros de la consulta de Factura de Venta por Cliente 
        /// en un periodo de fechas de ingreso.
        /// </summary>
        /// <param name="cliente">Cliente a consultar factura de venta.</param>
        /// <param name="fecha1">Primer rango de fecha.</param>
        /// <param name="fecha2">Segundo rango de fecha.</param>
        /// <returns></returns>
        public long GetRowsConsultaPorClientePeriodoIngreso
            (string cliente, DateTime fecha1, DateTime fecha2)
        {
            return miDaoFacturaVenta.GetRowsConsultaPorClientePeriodoIngreso(cliente, fecha1, fecha2);
        }



        /// <summary>
        /// Obtiene el resultado de la consulta de Factura de Venta por Estado, 
        /// Cliente y un periodo entre fechas de ingreso.
        /// </summary>
        /// <param name="estado">Estado de la factura a consultar.</param>
        /// <param name="cliente">Cliente a consultar factura de venta.</param>
        /// <param name="fecha1">Primer rango de fecha.</param>
        /// <param name="fecha2">Segundo rango de fecha.</param>
        /// <param name="rowBase">Registro base para la consulta.</param>
        /// <param name="rowMax">Número de registros a recuperar.</param>
        /// <returns></returns>
        public DataTable ConsultaPorEstadoClientePeriodoIngreso
            (int estado, string cliente, DateTime fecha1, DateTime fecha2, int rowBase, int rowMax)
        {
            return miDaoFacturaVenta.ConsultaPorEstadoClientePeriodoIngreso
                (estado, cliente, fecha1, fecha2, rowBase, rowMax);
        }

        /// <summary>
        /// Obtiene el total de registros de la consulta de Factura de Venta por Estado, 
        /// Cliente y un periodo entre fechas de ingreso.
        /// </summary>
        /// <param name="estado">Estado de la factura a consultar.</param>
        /// <param name="cliente">Cliente a consultar factura de venta.</param>
        /// <param name="fecha1">Primer rango de fecha.</param>
        /// <param name="fecha2">Segundo rango de fecha.</param>
        /// <returns></returns>
        public long GetRowsEstadoClientePeriodoIngreso
            (int estado, string cliente, DateTime fecha1, DateTime fecha2)
        {
            return miDaoFacturaVenta.GetRowsEstadoClientePeriodoIngreso(estado, cliente, fecha1, fecha2);
        }

        /// <summary>
        /// Obtiene el resultado de la consulta de las Facturas de Venta 
        /// que se encuentran en mora hasta la fecha actual.
        /// </summary>
        /// <param name="estado">Estado de la factura a consultar.</param>
        /// <param name="fecha">Fecha actual de la consulta.</param>
        /// <param name="rowBase">Registro base para la consulta.</param>
        /// <param name="rowMax">Número de registros a recuperar.</param>
        /// <returns></returns>
        public DataTable ConsultaEnMora
            (int estado, DateTime fecha, int rowBase, int rowMax)
        {
            return miDaoFacturaVenta.ConsultaEnMora
                (estado, fecha, rowBase, rowMax);
        }

        /// <summary>
        /// Obtiene el total de registros de la consulta de Facturas de Venta 
        /// que se encuentran en mora hasta la fecha actual.
        /// </summary>
        /// <param name="estado">Estado (Crédito) de la factura a consultar.</param>
        /// <param name="fecha">Fecha actual de la consulta.</param>
        /// <returns></returns>
        public long GetRowsConsultaEnMora(int estado, DateTime fecha)
        {
            return miDaoFacturaVenta.GetRowsConsultaEnMora(estado, fecha);
        }

        /// <summary>
        /// Obtiene el resultado de la consulta de las Facturas de Venta 
        /// de un Cliente que se encuentran en mora hasta la fecha actual.
        /// </summary>
        /// <param name="cliente">Cliente a consultar factura de venta.</param>
        /// <param name="estado">Estado de la factura a consultar.</param>
        /// <param name="fecha">Fecha actual de la consulta.</param>
        /// <param name="rowBase">Registro base para la consulta.</param>
        /// <param name="rowMax">Número de registros a recuperar.</param>
        /// <returns></returns>
        public DataTable ConsultaClienteEnMora
            (string cliente, int estado, DateTime fecha, int rowBase, int rowMax)
        {
            return miDaoFacturaVenta.ConsultaClienteEnMora
                (cliente, estado, fecha, rowBase, rowMax);
        }

        /// <summary>
        /// Obtiene el total de registros de la consulta de las Facturas de Venta 
        /// de un Cliente que se encuentran en mora hasta la fecha actual.
        /// </summary>
        /// <param name="cliente">Cliente a consultar factura de venta.</param>
        /// <param name="estado">Estado (Crédito) de la factura a consultar.</param>
        /// <param name="fecha">Fecha actual de la consulta.</param>
        /// <returns></returns>
        public long GetRowsConsultaClienteEnMora(string cliente, int estado, DateTime fecha)
        {
            return miDaoFacturaVenta.GetRowsConsultaClienteEnMora(cliente, estado, fecha);
        }

        /// <summary>
        /// Obtiene el resultado de la consulta de las Facturas de Venta 
        /// con un tope en la fecha límite.
        /// </summary>
        /// <param name="estado">Estado de la factura a consultar.</param>
        /// <param name="fecha">Fecha límite hasta donde se quiere consultar.</param>
        /// <param name="rowBase">Registro base para la consulta.</param>
        /// <param name="rowMax">Número de registros a recuperar.</param>
        /// <returns></returns>
        public DataTable ConsultaEstadoFechaLimite
                         (int estado, DateTime fecha, int rowBase, int rowMax)
        {
            return miDaoFacturaVenta.ConsultaEstadoFechaLimite
                (estado, fecha, rowBase, rowMax);
        }

        /// <summary>
        /// Obtiene el total de registros de la consulta de las Facturas de Venta 
        /// con un tope en la fecha límite.
        /// </summary>
        /// <param name="estado">Estado (Crédito) de la factura a consultar.</param>
        /// <param name="fecha">Fecha límite hasta donde se quiere consultar.</param>
        /// <returns></returns>
        public long GetRowsConsultaEstadoFechaLimite(int estado, DateTime fecha)
        {
            return miDaoFacturaVenta.GetRowsConsultaEstadoFechaLimite(estado, fecha);
        }

        /// <summary>
        /// Obtiene el resultado de la consulta de las Facturas de Venta 
        /// en crédito en un periodo de fechas.
        /// </summary>
        /// <param name="estado">Estado (Crédito) de la factura a consultar.</param>
        /// <param name="fecha1">Primer rango de fecha.</param>
        /// <param name="fecha2">Segundo rango de fecha.</param>
        /// <param name="rowBase">Registro base para la consulta.</param>
        /// <param name="rowMax">Número de registros a recuperar.</param>
        /// <returns></returns>
        public DataTable ConsultaCreditoPeriodo
            (int estado, DateTime fecha1, DateTime fecha2, int rowBase, int rowMax)
        {
            return miDaoFacturaVenta.ConsultaCreditoPeriodo
                (estado, fecha1, fecha2, rowBase, rowMax);
        }

        /// <summary>
        /// Obtiene el total de registros de la consulta de las Facturas de Venta 
        /// en crédito en un periodo de fechas.
        /// </summary>
        /// <param name="estado">Estado (Crédito) de la factura a consultar.</param>
        /// <param name="fecha1">Primer rango de fecha.</param>
        /// <param name="fecha2">Segundo rango de fecha.</param>
        /// <returns></returns>
        public long GetRowsConsultaCreditoPeriodo(int estado, DateTime fecha1, DateTime fecha2)
        {
            return miDaoFacturaVenta.GetRowsConsultaCreditoPeriodo(estado, fecha1, fecha2);
        }

        /// <summary>
        /// Obtiene el resultado de la consulta de las Facturas de Venta 
        /// en Crédito de un Cliente.
        /// </summary>
        /// <param name="cliente">Cliente a consultar factura de venta.</param>
        /// <param name="estado">Estado (Crédito) de la factura a consultar.</param>
        /// <param name="fecha">Fecha límite hasta donde se quiere consultar.</param>
        /// <param name="rowBase">Registro base para la consulta.</param>
        /// <param name="rowMax">Número de registros a recuperar.</param>
        /// <returns></returns>
        public DataTable ConsultaClienteCreditoLimite
            (string cliente, int estado, DateTime fecha, int rowBase, int rowMax)
        {
            return miDaoFacturaVenta.ConsultaClienteCreditoLimite
                (cliente, estado, fecha, rowBase, rowMax);
        }

        /// <summary>
        /// Obtiene el total de registros de la consulta de las Facturas de Venta 
        /// en Crédito de un Cliente.
        /// </summary>
        /// <param name="cliente">Cliente a consultar factura de venta.</param>
        /// <param name="estado">Estado (Crédito) de la factura a consultar.</param>
        /// <param name="fecha">Fecha límite hasta donde se quiere consultar.</param>
        /// <returns></returns>
        public long GetRowsConsultaClienteCreditoLimite(string cliente, int estado, DateTime fecha)
        {
            return miDaoFacturaVenta.GetRowsConsultaClienteCreditoLimite(cliente, estado, fecha);
        }

        /// <summary>
        /// Obtiene el resultado de la consulta de las Facturas de Venta 
        /// en Crédito de un Cliente en un periodo determinado.
        /// </summary>
        /// <param name="cliente">Cliente a consultar factura de venta.</param>
        /// <param name="estado">Estado (Crédito) de la factura a consultar.</param>
        /// <param name="fecha1">Primer rango de fecha.</param>
        /// <param name="fecha2">Segundo rango de fecha.</param>
        /// <param name="rowBase">Registro base para la consulta.</param>
        /// <param name="rowMax">Número de registros a recuperar.</param>
        /// <returns></returns>
        public DataTable ConsultaClienteCreditoLimitePeriodo
            (string cliente, int estado, DateTime fecha1, DateTime fecha2, int rowBase, int rowMax)
        {
            return miDaoFacturaVenta.ConsultaClienteCreditoLimitePeriodo
                (cliente, estado, fecha1, fecha2, rowBase, rowMax);
        }

        /// <summary>
        /// Obtiene el total de registros de la consulta de las Facturas de Venta 
        /// en Crédito de un Cliente en un periodo determinado.
        /// </summary>
        /// <param name="cliente">Cliente a consultar factura de venta.</param>
        /// <param name="estado">Estado (Crédito) de la factura a consultar.</param>
        /// <param name="fecha1">Primer rango de fecha.</param>
        /// <param name="fecha2">Segundo rango de fecha.</param>
        /// <returns></returns>
        public long GetRowsConsultaClienteCreditoLimitePeriodo
            (string cliente, int estado, DateTime fecha1, DateTime fecha2)
        {
            return miDaoFacturaVenta.GetRowsConsultaClienteCreditoLimitePeriodo
                                                            (cliente, estado, fecha1, fecha2);
        }

        public DataTable CarteraClientes(bool saldo, bool customer, string cliente)
        {
            var miDaoCliente = new DaoCliente();
            var miDaoImpuesto = new DaoImpuestoBolsa();
            var miDaoDevolucion = new DaoDevolucion();
            var miDaoRetencion = new DaoRetencion();
            var tabla = TablaCartera();
            var tClientes = new DataTable();
            if (customer)
            {
                tClientes = miDaoCliente.ConsultaClienteNit(cliente);
            }
            else
            {
                tClientes = miDaoCliente.ListadoDeClientes();
            }
            //var tClientes = miDaoCliente.ListadoDeClientes();
            foreach (DataRow rCliente in tClientes.Rows)
            {
                var tFacturas = miDaoFacturaVenta.ConsultaPorEstadoYcliente(2, rCliente["nitcliente"].ToString());
                double subTotal = 0;
                double v_iva = 0;
                var valorFactura = 0.0;
                var retencion = 0.0;
                var pagosFactura = 0.0;
                var saldoFactura = 0.0;
                foreach (DataRow fRow in tFacturas.Rows)
                {
                    ///var num = fRow["numero"].ToString();
                    /*subTotal = ProductoFacturaVenta(fRow["numero"].ToString(), Convert.ToBoolean(fRow["descto"])).
                               AsEnumerable().Sum(t => (t.Field<double>("ValorUnitario") * t.Field<double>("Cantidad")));
                    valorFactura = ProductoFacturaVenta(fRow["numero"].ToString(), Convert.ToBoolean(fRow["descto"])).
                                       AsEnumerable().Sum(t => t.Field<double>("Valor"));*/

                    DataTable tProductos = ProductoFacturaVenta(Convert.ToInt32(fRow["id"]), Convert.ToBoolean(fRow["descto"]));
                    subTotal = tProductos.AsEnumerable().Sum(t => (t.Field<double>("ValorUnitario") * t.Field<double>("Cantidad")));
                    v_iva = Convert.ToInt32(tProductos.AsEnumerable().Sum(t => (t.Field<double>("ValorIva") * t.Field<double>("Cantidad"))));
                    valorFactura = tProductos.AsEnumerable().Sum(t => t.Field<double>("Valor"));

                    /**
                    subTotal = ProductoFacturaVenta(Convert.ToInt32(fRow["id"]), Convert.ToBoolean(fRow["descto"])).
                               AsEnumerable().Sum(t => (t.Field<double>("ValorUnitario") * t.Field<double>("Cantidad")));
                    //ValorIva
                    v_iva = Convert.ToInt32(
                        ProductoFacturaVenta(Convert.ToInt32(fRow["id"]), Convert.ToBoolean(fRow["descto"])).
                        AsEnumerable().Sum(t => (t.Field<double>("ValorIva") * t.Field<double>("Cantidad"))));
                    valorFactura = ProductoFacturaVenta(Convert.ToInt32(fRow["id"]), Convert.ToBoolean(fRow["descto"])).
                                       AsEnumerable().Sum(t => t.Field<double>("Valor"));
                    */

                    var icoBolsa = miDaoImpuesto.ImpuestoBolsaDeVenta(Convert.ToInt32(fRow["id"]));
                    valorFactura += (icoBolsa.Cantidad * icoBolsa.Valor);

                    retencion = 0.0;
                    var tReteciones = miDaoRetencion.RetencionesAVenta(Convert.ToInt32(fRow["id"]));
                    foreach (DataRow rRow in tReteciones.Rows)
                    {
                        retencion += Convert.ToInt32(subTotal * Convert.ToDouble(rRow["tarifa"]) / 100);
                    }
                    valorFactura -= retencion;

                    pagosFactura = miDaoFacturaVenta.GetTotalFormasDePagoDeFacturaVenta(Convert.ToInt32(fRow["id"]));
                    var saldoDevFactura = miDaoDevolucion.SaldoDevolucionVenta(fRow["numero"].ToString());
                    saldoFactura = valorFactura - (pagosFactura + saldoDevFactura);
                    if (saldoFactura > 0)
                    {
                        var row = tabla.NewRow();
                        row["Id"] = Convert.ToInt32(fRow["id"]);

                        row["Cedula"] = rCliente["nitcliente"].ToString();
                        row["Nombre"] = rCliente["nombrescliente"].ToString();

                        row["Regimen"] = rCliente["nombreregimen"];
                        row["Direccion"] = rCliente["direccioncliente"];
                        row["Ciudad"] = rCliente["nombreciudad"];
                        row["Depto"] = rCliente["nombredepartamento"];
                        /*
                                     tabla.Columns.Add(new DataColumn("Regimen", typeof(string)));
            tabla.Columns.Add(new DataColumn("Direccion", typeof(string)));
            tabla.Columns.Add(new DataColumn("Ciudad", typeof(string)));
            tabla.Columns.Add(new DataColumn("Depto", typeof(string)));*/

                        row["Factura"] = fRow["numero"].ToString();
                        row["Fecha"] = fRow["fecha"].ToString();
                        row["Limite"] = fRow["limite"].ToString();

                        row["V_Iva"] = v_iva;

                        row["Valor"] = valorFactura;
                        row["Abonos"] = pagosFactura;
                        row["Saldo"] = saldoFactura;
                        tabla.Rows.Add(row);
                    }
                }
            }
            if (!saldo)
            {
                foreach (DataRow rCliente in tClientes.Rows)
                {
                    //var j = rCliente["nitcliente"].ToString();
                    var query = tabla.AsEnumerable().Where(d => d.Field<string>("Cedula").Equals(rCliente["nitcliente"].ToString()));
                    //var l = query.ToArray().Length;
                    if (query.ToArray().Length.Equals(0))
                    {
                        var row = tabla.NewRow();
                        row["Cedula"] = rCliente["nitcliente"].ToString();
                        row["Nombre"] = rCliente["nombrescliente"].ToString();
                        row["Factura"] = "";
                        row["Fecha"] = DateTime.Now;
                        row["Limite"] = DateTime.Now;
                        row["Valor"] = 0;
                        row["Abonos"] = 0;
                        row["Saldo"] = 0;
                        tabla.Rows.Add(row);
                    }
                }
            }
            if (tabla.Rows.Count != 0)
            {
                IEnumerable<DataRow> rQuery = from data in tabla.AsEnumerable()
                                              orderby data.Field<string>("Nombre") ascending
                                              select data;
                return rQuery.CopyToDataTable<DataRow>();
            }
            else
            {
                return tabla;
            }
            //return tabla;
        }

        // ACT 25/09/2017 mejoras a consulta cartera de clientes

        public DataTable CarteraClientes(int idEstado)
        {
            var miDaoImpuesto = new DaoImpuestoBolsa();
            var miDaoRetencion = new DaoRetencion();
            var miDaoDevolucion = new DaoDevolucion();

            double subTotal = 0;
            double v_iva = 0;
            double valorFactura = 0;
            int retencion = 0;
            ImpuestoBolsa icoBolsa;
            int pagosFactura = 0;

            var tData = new DataTable();
            tData.Columns.Add(new DataColumn("cedula", typeof(string)));
            tData.Columns.Add(new DataColumn("nombre", typeof(string)));
            /*tData.Columns.Add(new DataColumn("regimen", typeof(string)));
            tData.Columns.Add(new DataColumn("direccion", typeof(string)));
            tData.Columns.Add(new DataColumn("ciudad", typeof(string)));
            tData.Columns.Add(new DataColumn("depto", typeof(string)));*/

            tData.Columns.Add(new DataColumn("id", typeof(int)));
            tData.Columns.Add(new DataColumn("factura", typeof(string)));
            tData.Columns.Add(new DataColumn("fecha", typeof(DateTime)));
            tData.Columns.Add(new DataColumn("limite", typeof(DateTime)));
            tData.Columns.Add(new DataColumn("idestado", typeof(int)));
            tData.Columns.Add(new DataColumn("valor", typeof(int)));
            tData.Columns.Add(new DataColumn("v_iva", typeof(int)));
            tData.Columns.Add(new DataColumn("abonos", typeof(Int64)));
            tData.Columns.Add(new DataColumn("saldo", typeof(int)));

            var tCartera = this.miDaoFacturaVenta.CarteraDeClientes(idEstado);
            foreach (DataRow cRow in tCartera.Rows)
            {
                /*if (cRow["factura"].ToString().Equals("429903"))
                {
                    var j = 0;
                }*/
                DataTable tProductos = ProductoFacturaVenta(Convert.ToInt32(cRow["id"]), true);
                subTotal = tProductos.AsEnumerable().Sum(t => (t.Field<double>("ValorUnitario") * t.Field<double>("Cantidad")));

               // v_iva = Convert.ToInt32(tProductos.
                       // AsEnumerable().Sum(t => (t.Field<double>("Valor_1") / (1 + (UseObject.RemoveCharacter(t.Field<string>("Iva"), '%') / 100)))));

                valorFactura = tProductos.AsEnumerable().Sum(t => t.Field<double>("Valor"));

                //v_iva = valorFactura - v_iva;

                icoBolsa = miDaoImpuesto.ImpuestoBolsaDeVenta(Convert.ToInt32(cRow["id"]));
                valorFactura += (icoBolsa.Cantidad * icoBolsa.Valor);
                retencion = 0;
                var tReteciones = miDaoRetencion.RetencionesAVenta(cRow["factura"].ToString());
                foreach (DataRow rRow in tReteciones.Rows)
                {
                    retencion += Convert.ToInt32(subTotal * Convert.ToDouble(rRow["tarifa"]) / 100);
                }
                valorFactura -= retencion;
                valorFactura -= Convert.ToInt32(cRow["saldo_devolucion"]);
                pagosFactura = Convert.ToInt32(cRow["abonos"]);
                if ((valorFactura - pagosFactura) > 0)
                {
                    tData.Rows.Add
                    (
                       cRow["cedula"],
                       cRow["nombre"],

                       /*cRow["nombreregimen"],
                       cRow["direccioncliente"],
                       cRow["nombreciudad"],
                       cRow["nombredepartamento"],*/

                       cRow["id"],
                       cRow["factura"],
                       cRow["fecha"],
                       cRow["limite"],
                       cRow["idestado"],
                       valorFactura,
                       v_iva,
                       cRow["abonos"],
                       Convert.ToInt32(valorFactura - pagosFactura)
                    );
                }
            }
            if (tData.Rows.Count != 0)
            {
                IEnumerable<DataRow> rQuery = from data in tData.AsEnumerable()
                                              orderby data.Field<string>("nombre") ascending
                                              select data;
                return rQuery.CopyToDataTable<DataRow>();
            }
            else
            {
                return tData;
            }
        }

        // END ACT 25/09/2017 mejoras a consulta cartera de clientes

        public DataTable CarteraDeClientes(int idEstado)
        {
            return this.miDaoFacturaVenta.CarteraDeClientes(idEstado);
        }

        public DataTable CarteraDeClientes(int idEstado, int rowIndex, int rowMax)
        {
            return this.miDaoFacturaVenta.CarteraDeClientes(idEstado, rowIndex, rowMax);
        }

        public int CountCarteraDeClientes(int idEstado)
        {
            return this.miDaoFacturaVenta.CountCarteraDeClientes(idEstado);
        }

        public DataTable CarteraDeClientes(int idEstado, string nitCliente)
        {
            return this.miDaoFacturaVenta.CarteraDeClientes(idEstado, nitCliente);
        }

        public DataTable CarteraClientes(DateTime fecha, DateTime fecha2)
        {
            var miDaoDevolucion = new DaoDevolucion();
            var miDaoRetencion = new DaoRetencion();
            var tabla = TablaCartera();
            var tFacturas = miDaoFacturaVenta.ConsultaEstadoPeriodoIngreso(2, fecha, fecha2);
            var valorFactura = 0.0;
            var retencion = 0.0;
            var pagosFactura = 0.0;
            var saldoFactura = 0.0;
            foreach (DataRow fRow in tFacturas.Rows)
            {
                valorFactura = ProductoFacturaVenta(fRow["numero"].ToString(), Convert.ToBoolean(fRow["descto"])).
                                   AsEnumerable().Sum(t => t.Field<double>("Valor"));
                retencion = 0.0;
                var tReteciones = miDaoRetencion.RetencionesAVenta(fRow["numero"].ToString());
                foreach (DataRow rRow in tReteciones.Rows)
                {
                    retencion += Convert.ToInt32(valorFactura * Convert.ToDouble(rRow["tarifa"]) / 100);
                }
                valorFactura -= retencion;

                pagosFactura = miDaoFacturaVenta.GetTotalFormasDePagoDeFacturaVenta(fRow["numero"].ToString());
                var saldoDevFactura = miDaoDevolucion.SaldoDevolucionVenta(fRow["numero"].ToString());
                saldoFactura = valorFactura - (pagosFactura + saldoDevFactura);
                if (saldoFactura > 0)
                {
                    var row = tabla.NewRow();
                    row["Cedula"] = fRow["nit"].ToString();
                    row["Nombre"] = fRow["cliente"].ToString();
                    row["Factura"] = fRow["numero"].ToString();
                    row["Fecha"] = fRow["fecha"].ToString();
                    row["Limite"] = fRow["limite"].ToString();
                    row["Valor"] = valorFactura;
                    row["Abonos"] = pagosFactura;
                    row["Saldo"] = saldoFactura;
                    tabla.Rows.Add(row);
                }
            }
            return tabla;
        }

        public DataTable ResumenCarteraClientes(bool saldo)
        {
            var tabla = TablaCartera();


            var miDaoCliente = new DaoCliente();
            //var miDaoDevolucion = new DaoDevolucion();
            
            var tClientes = miDaoCliente.ListadoDeClientes();
            foreach (DataRow rCliente in tClientes.Rows)
            {
                if (miDaoFacturaVenta.SaldoDeCliente(rCliente["nitcliente"].ToString()) > 0)
                {
                    var row = tabla.NewRow();
                    row["Cedula"] = rCliente["nitcliente"];
                    row["Nombre"] = rCliente["nombrescliente"];
                    row["Saldo"] = miDaoFacturaVenta.SaldoDeCliente(rCliente["nitcliente"].ToString());
                    tabla.Rows.Add(row);
                }
            }
            return tabla;
        }

        public DataTable ResumenCarteraClientes()
        {
            return this.miDaoFacturaVenta.ResumenCarteraClientes();
        }

        // Nuevas.

        //RESUMEN DE VENTAS Y UTILIDAD

        // 1
        public DataTable ConsultaFacturasActivas(DateTime fecha, int rowBase, int rowMax)
        {
            //return miDaoFacturaVenta.ConsultaFacturasActivas(fecha, rowBase, rowMax);
            return TablaResumen(miDaoFacturaVenta.ConsultaFacturasActivas(fecha, rowBase, rowMax));
        }

        public long GetRowsConsultaFacturasActivas(DateTime fecha)
        {
            return miDaoFacturaVenta.GetRowsConsultaFacturasActivas(fecha);
        }

        // 2
        public DataTable ConsultaFacturasActivas
                         (DateTime fecha, DateTime fecha2, int rowBase, int rowMax)
        {
            //return miDaoFacturaVenta.ConsultaFacturasActivas(fecha, fecha2, rowBase, rowMax);
            return TablaResumen(miDaoFacturaVenta.ConsultaFacturasActivas(fecha, fecha2, rowBase, rowMax));
        }

        public long GetRowsConsultaFacturasActivas(DateTime fecha, DateTime fecha2)
        {
            return miDaoFacturaVenta.GetRowsConsultaFacturasActivas(fecha, fecha2);
        }

        // 3
        public DataTable ConsultaFacturasActivas(string cliente, DateTime fecha, int rowBase, int rowMax)
        {
            return TablaResumen(miDaoFacturaVenta.ConsultaFacturasActivas(cliente, fecha, rowBase, rowMax));
        }

        public long GetRowsConsultaFacturasActivas(string cliente, DateTime fecha)
        {
            return miDaoFacturaVenta.GetRowsConsultaFacturasActivas(cliente, fecha);
        }

        // 4
        public DataTable ConsultaFacturasActivas
            (string cliente, DateTime fecha, DateTime fecha2, int rowBase, int rowMax)
        {
            return TablaResumen(miDaoFacturaVenta.ConsultaFacturasActivas(cliente, fecha, fecha2, rowBase, rowMax));
        }

        public long GetRowsConsultaFacturasActivas(string cliente, DateTime fecha, DateTime fecha2)
        {
            return miDaoFacturaVenta.GetRowsConsultaFacturasActivas(cliente, fecha, fecha2);
        }

        // 5
        public DataTable ConsultaFacturasContadoActivas(DateTime fecha, int rowBase, int rowMax)
        {
            //return miDaoFacturaVenta.ConsultaFacturasContadoActivas(fecha, rowBase, rowMax);+
            return TablaResumen(miDaoFacturaVenta.ConsultaFacturasContadoActivas(fecha, rowBase, rowMax));
        }

        public long GetRowsConsultaFacturasContadoActivas(DateTime fecha)
        {
            return miDaoFacturaVenta.GetRowsConsultaFacturasContadoActivas(fecha);
        }

        // 6
        public DataTable ConsultaFacturasContadoActivas
            (DateTime fecha, DateTime fecha2, int rowBase, int rowMax)
        {
            //return miDaoFacturaVenta.ConsultaFacturasContadoActivas(fecha, fecha2, rowBase, rowMax);
            return TablaResumen(miDaoFacturaVenta.ConsultaFacturasContadoActivas(fecha, fecha2, rowBase, rowMax));
        }

        public long GetRowsConsultaFacturasContadoActivas(DateTime fecha, DateTime fecha2)
        {
            return miDaoFacturaVenta.GetRowsConsultaFacturasContadoActivas(fecha, fecha2);
        }

        // 7
        public DataTable ConsultaFacturasContadoActivas(string cliente, DateTime fecha, int rowBase, int rowMax)
        {
            return TablaResumen(miDaoFacturaVenta.ConsultaFacturasContadoActivas(cliente, fecha, rowBase, rowMax));
        }

        public long GetRowsConsultaFacturasContadoActivas(string cliente, DateTime fecha)
        {
            return miDaoFacturaVenta.GetRowsConsultaFacturasContadoActivas(cliente, fecha);
        }

        // 8
        public DataTable ConsultaFacturasContadoActivas
            (string cliente, DateTime fecha, DateTime fecha2, int rowBase, int rowMax)
        {
            return TablaResumen(miDaoFacturaVenta.ConsultaFacturasContadoActivas(cliente, fecha, fecha2, rowBase, rowMax));
        }

        public long GetRowsConsultaFacturasContadoActivas(string cliente, DateTime fecha, DateTime fecha2)
        {
            return miDaoFacturaVenta.GetRowsConsultaFacturasContadoActivas(cliente, fecha, fecha2);
        }

        // 9
        public DataTable ConsultaFacturasCreditoActivas(DateTime fecha, int rowBase, int rowMax)
        {
            //return miDaoFacturaVenta.ConsultaFacturasCreditoActivas(fecha, rowBase, rowMax);
            return TablaResumen(miDaoFacturaVenta.ConsultaFacturasCreditoActivas(fecha, rowBase, rowMax));
        }

        public long GetRowsConsultaFacturasCreditoActivas(DateTime fecha)
        {
            return miDaoFacturaVenta.GetRowsConsultaFacturasCreditoActivas(fecha);
        }

        // 10
        public DataTable ConsultaFacturasCreditoActivas
            (DateTime fecha, DateTime fecha2, int rowBase, int rowMax)
        {
            //return miDaoFacturaVenta.ConsultaFacturasCreditoActivas(fecha, fecha2, rowBase, rowMax);
            return TablaResumen(miDaoFacturaVenta.ConsultaFacturasCreditoActivas(fecha, fecha2, rowBase, rowMax));
        }

        public long GetRowsConsultaFacturasCreditoActivas(DateTime fecha, DateTime fecha2)
        {
            return miDaoFacturaVenta.GetRowsConsultaFacturasCreditoActivas(fecha, fecha2);
        }

        // 11
        public DataTable ConsultaFacturasCreditoActivas(string cliente, DateTime fecha, int rowBase, int rowMax)
        {
            return TablaResumen(miDaoFacturaVenta.ConsultaFacturasCreditoActivas(cliente, fecha, rowBase, rowMax));
        }

        public long GetRowsConsultaFacturasCreditoActivas(string cliente, DateTime fecha)
        {
            return miDaoFacturaVenta.GetRowsConsultaFacturasCreditoActivas(cliente, fecha);
        }

        // 12
        public DataTable ConsultaFacturasCreditoActivas
            (string cliente, DateTime fecha, DateTime fecha2, int rowBase, int rowMax)
        {
            return TablaResumen(miDaoFacturaVenta.ConsultaFacturasCreditoActivas(cliente, fecha, fecha2, rowBase, rowMax));
        }

        public long GetRowsConsultaFacturasCreditoActivas(string cliente, DateTime fecha, DateTime fecha2)
        {
            return miDaoFacturaVenta.GetRowsConsultaFacturasCreditoActivas(cliente, fecha, fecha2);
        }

        // 13
        public DataTable ConsultaFacturasAnuladas(DateTime fecha, int rowBase, int rowMax)
        {
            return TablaResumen(miDaoFacturaVenta.ConsultaFacturasAnuladas(fecha, rowBase, rowMax));
        }

        public long GetRowsConsultaFacturasAnuladas(DateTime fecha)
        {
            return miDaoFacturaVenta.GetRowsConsultaFacturasAnuladas(fecha);
        }

        // 14
        public DataTable ConsultaFacturasAnuladas(DateTime fecha, DateTime fecha2, int rowBase, int rowMax)
        {
            return TablaResumen(miDaoFacturaVenta.ConsultaFacturasAnuladas(fecha, fecha2, rowBase, rowMax));
        }

        public long GetRowsConsultaFacturasAnuladas(DateTime fecha, DateTime fecha2)
        {
            return miDaoFacturaVenta.GetRowsConsultaFacturasAnuladas(fecha, fecha2);
        }

        // 15
        public DataTable ConsultaFacturasAnuladas
            (string cliente, DateTime fecha, int rowBase, int rowMax)
        {
            return TablaResumen(miDaoFacturaVenta.ConsultaFacturasAnuladas(cliente, fecha, rowBase, rowMax));
        }

        public long GetRowsConsultaFacturasAnuladas(string cliente, DateTime fecha)
        {
            return miDaoFacturaVenta.GetRowsConsultaFacturasAnuladas(cliente, fecha);
        }

        // 16
        public DataTable ConsultaFacturasAnuladas
            (string cliente, DateTime fecha, DateTime fecha2, int rowBase, int rowMax)
        {
            return TablaResumen(miDaoFacturaVenta.ConsultaFacturasAnuladas(cliente, fecha, fecha2, rowBase, rowMax));
        }

        public long GetRowsConsultaFacturasAnuladas(string cliente, DateTime fecha, DateTime fecha2)
        {
            return miDaoFacturaVenta.GetRowsConsultaFacturasAnuladas(cliente, fecha, fecha2);
        }



        // Funciones de consulta con usuario

        public DataTable ConsultaFacturasActivas(int idUsuario, DateTime fecha, int rowBase, int rowMax)
        {
            return this.TablaResumen(this.miDaoFacturaVenta.ConsultaFacturasActivas(idUsuario, fecha, rowBase, rowMax));
        }

        public long GetRowsConsultaFacturasActivas(int idUsuario, DateTime fecha)
        {
            return this.miDaoFacturaVenta.GetRowsConsultaFacturasActivas(idUsuario, fecha);
        }

        public DataTable ConsultaFacturasActivas(int idUsuario, DateTime fecha, DateTime fecha2, int rowBase, int rowMax)
        {
            return this.TablaResumen(this.miDaoFacturaVenta.ConsultaFacturasActivas(idUsuario, fecha, fecha2, rowBase, rowMax));
        }

        public long GetRowsConsultaFacturasActivas(int idUsuario, DateTime fecha, DateTime fecha2)
        {
            return this.miDaoFacturaVenta.GetRowsConsultaFacturasActivas(idUsuario, fecha, fecha2);
        }


        public DataTable ConsultaFacturasContadoActivas(int idUsuario, DateTime fecha, int rowBase, int rowMax)
        {
            return this.TablaResumen(this.miDaoFacturaVenta.ConsultaFacturasContadoActivas(idUsuario, fecha, rowBase, rowMax));
        }

        public long GetRowsConsultaFacturasContadoActivas(int idUsuario, DateTime fecha)
        {
            return this.miDaoFacturaVenta.GetRowsConsultaFacturasContadoActivas(idUsuario, fecha);
        }

        public DataTable ConsultaFacturasContadoActivas(int idUsuario, DateTime fecha, DateTime fecha2, int rowBase, int rowMax)
        {
            return this.TablaResumen(this.miDaoFacturaVenta.ConsultaFacturasContadoActivas(idUsuario, fecha, fecha2, rowBase, rowMax));
        }

        public long GetRowsConsultaFacturasContadoActivas(int idUsuario, DateTime fecha, DateTime fecha2)
        {
            return this.miDaoFacturaVenta.GetRowsConsultaFacturasContadoActivas(idUsuario, fecha, fecha2);
        }


        public DataTable ConsultaFacturasCreditoActivas(int idUsuario, DateTime fecha, int rowBase, int rowMax)
        {
            return this.TablaResumen(this.miDaoFacturaVenta.ConsultaFacturasCreditoActivas(idUsuario, fecha, rowBase, rowMax));
        }

        public long GetRowsConsultaFacturasCreditoActivas(int idUsuario, DateTime fecha)
        {
            return this.miDaoFacturaVenta.GetRowsConsultaFacturasCreditoActivas(idUsuario, fecha);
        }

        public DataTable ConsultaFacturasCreditoActivas(int idUsuario, DateTime fecha, DateTime fecha2, int rowBase, int rowMax)
        {
            return this.TablaResumen(this.miDaoFacturaVenta.ConsultaFacturasCreditoActivas(idUsuario, fecha, fecha2, rowBase, rowMax));
        }

        public long GetRowsConsultaFacturasCreditoActivas(int idUsuario, DateTime fecha, DateTime fecha2)
        {
            return this.miDaoFacturaVenta.GetRowsConsultaFacturasCreditoActivas(idUsuario, fecha, fecha2);
        }


        public DataTable ConsultaFacturasAnuladas(int idUsuario, DateTime fecha, int rowBase, int rowMax)
        {
            return this.TablaResumen(this.miDaoFacturaVenta.ConsultaFacturasAnuladas(idUsuario, fecha, rowBase, rowMax));
        }

        public long GetRowsConsultaFacturasAnuladas(int idUsuario, DateTime fecha)
        {
            return this.miDaoFacturaVenta.GetRowsConsultaFacturasAnuladas(idUsuario, fecha);
        }

        public DataTable ConsultaFacturasAnuladas(int idUsuario, DateTime fecha, DateTime fecha2, int rowBase, int rowMax)
        {
            return this.TablaResumen(this.miDaoFacturaVenta.ConsultaFacturasAnuladas(idUsuario, fecha, fecha2, rowBase, rowMax));
        }

        public long GetRowsConsultaFacturasAnuladas(int idUsuario, DateTime fecha, DateTime fecha2)
        {
            return this.miDaoFacturaVenta.GetRowsConsultaFacturasAnuladas(idUsuario, fecha, fecha2);
        }



        // CALCULOS EN RESUMEN DE VENTAS Y UTILIDAD

        private DataTable TablaResumen(DataTable tResumen)
        {
           /* var tabla = new DataTable();
            tabla.Columns.Add(new DataColumn("Fecha", typeof(DateTime)));
            tabla.Columns.Add(new DataColumn("Nit", typeof(string)));
            tabla.Columns.Add(new DataColumn("Cliente", typeof(string)));
            tabla.Columns.Add(new DataColumn("Factura", typeof(string)));
            tabla.Columns.Add(new DataColumn("Estado", typeof(string)));
            tabla.Columns.Add(new DataColumn("Base", typeof(int)));
            tabla.Columns.Add(new DataColumn("Iva", typeof(int)));
            tabla.Columns.Add(new DataColumn("Total", typeof(int)));*/
            this.Tabla.Rows.Clear();

            foreach (DataRow rRow in tResumen.Rows)
            {
                //var tProductos = ProductoFacturaVenta(rRow["numero"].ToString(), true);
                var tProductos = ProductoFacturaVenta(Convert.ToInt32(rRow["id"]), true);

                var row = Tabla.NewRow();
                row["Fecha"] = rRow["fecha"];
                row["Nit"] = rRow["nit"];
                row["Cliente"] = rRow["cliente"];
                row["Factura"] = rRow["numero"];
                if (Convert.ToBoolean(rRow["activa"]))
                {
                    row["Estado"] = "Activa";
                }
                else
                {
                    row["Estado"] = "Anulada";
                }
                row["Pago"] = rRow["estado"];
                row["Base"] = Convert.ToInt32(tProductos.AsEnumerable().
                    Sum((s => s.Field<double>("ValorMenosDescto") * s.Field<double>("Cantidad"))));
                row["Iva"] = Convert.ToInt32
                    (tProductos.AsEnumerable().Sum(s => s.Field<double>("ValorIva") * s.Field<double>("Cantidad")));
                row["Total"] = Convert.ToInt32(tProductos.AsEnumerable().Sum(s => s.Field<double>("Valor")));
                Tabla.Rows.Add(row);
            }
            return Tabla;
        }


        
        // Resumen Tributario de ventas

        // 1. 
        public DataTable ResumenDeVentas(DateTime fecha)
        {
            return miDaoFacturaVenta.ResumenDeVentas(fecha);
        }

        public DataTable ResumenDeVentas2(DateTime fecha)
        {
            return miDaoFacturaVenta.ResumenDeVentas2(fecha);
        }

        // 2
        public DataTable ResumenDeVentas(DateTime fecha, DateTime fecha2)
        {
            return miDaoFacturaVenta.ResumenDeVentas(fecha, fecha2);
        }

        public DataTable ResumenDeVentas2(DateTime fecha, DateTime fecha2)
        {
            return miDaoFacturaVenta.ResumenDeVentas2(fecha, fecha2);
        }

        // 3
        public DataTable ResumenDeVentas(string cliente, DateTime fecha)
        {
            return miDaoFacturaVenta.ResumenDeVentas(cliente, fecha);
        }

        public DataTable ResumenDeVentas2(string cliente, DateTime fecha)
        {
            return miDaoFacturaVenta.ResumenDeVentas2(cliente, fecha);
        }

        // 4
        public DataTable ResumenDeVentas(string cliente, DateTime fecha, DateTime fecha2)
        {
            return miDaoFacturaVenta.ResumenDeVentas(cliente, fecha, fecha2);
        }

        public DataTable ResumenDeVentas2(string cliente, DateTime fecha, DateTime fecha2)
        {
            return miDaoFacturaVenta.ResumenDeVentas2(cliente, fecha, fecha2);
        }

        // 5
        public DataTable ResumenDeVentasContado(DateTime fecha)
        {
            return miDaoFacturaVenta.ResumenDeVentasContado(fecha);
        }

        public DataTable ResumenDeVentasContado2(DateTime fecha)
        {
            return miDaoFacturaVenta.ResumenDeVentasContado2(fecha);
        }

        // 6
        public DataTable ResumenDeVentasContado(DateTime fecha, DateTime fecha2)
        {
            return miDaoFacturaVenta.ResumenDeVentasContado(fecha, fecha2);
        }

        public DataTable ResumenDeVentasContado2(DateTime fecha, DateTime fecha2)
        {
            return miDaoFacturaVenta.ResumenDeVentasContado2(fecha, fecha2);
        }

        // 7.
        public DataTable ResumenDeVentasContado(string cliente, DateTime fecha)
        {
            return miDaoFacturaVenta.ResumenDeVentasContado(cliente, fecha);
        }

        public DataTable ResumenDeVentasContado2(string cliente, DateTime fecha)
        {
            return miDaoFacturaVenta.ResumenDeVentasContado2(cliente, fecha);
        }

        // 8
        public DataTable ResumenDeVentasContado(string cliente, DateTime fecha, DateTime fecha2)
        {
            return miDaoFacturaVenta.ResumenDeVentasContado(cliente, fecha, fecha2);
        }

        public DataTable ResumenDeVentasContado2(string cliente, DateTime fecha, DateTime fecha2)
        {
            return miDaoFacturaVenta.ResumenDeVentasContado2(cliente, fecha, fecha2);
        }

        // 9
        public DataTable ResumenDeVentasCredito(DateTime fecha)
        {
            return miDaoFacturaVenta.ResumenDeVentasCredito(fecha);
        }

        public DataTable ResumenDeVentasCredito2(DateTime fecha)
        {
            return miDaoFacturaVenta.ResumenDeVentasCredito2(fecha);
        }

        // 10
        public DataTable ResumenDeVentasCredito(DateTime fecha, DateTime fecha2)
        {
            return miDaoFacturaVenta.ResumenDeVentasCredito(fecha, fecha2);
        }

        public DataTable ResumenDeVentasCredito2(DateTime fecha, DateTime fecha2)
        {
            return miDaoFacturaVenta.ResumenDeVentasCredito2(fecha, fecha2);
        }

        // 11
        public DataTable ResumenDeVentasCredito(string cliente, DateTime fecha)
        {
            return miDaoFacturaVenta.ResumenDeVentasCredito(cliente, fecha);
        }

        public DataTable ResumenDeVentasCredito2(string cliente, DateTime fecha)
        {
            return miDaoFacturaVenta.ResumenDeVentasCredito2(cliente, fecha);
        }

        // 12
        public DataTable ResumenDeVentasCredito(string cliente, DateTime fecha, DateTime fecha2)
        {
            return miDaoFacturaVenta.ResumenDeVentasCredito(cliente, fecha, fecha2);
        }

        public DataTable ResumenDeVentasCredito2(string cliente, DateTime fecha, DateTime fecha2)
        {
            return miDaoFacturaVenta.ResumenDeVentasCredito2(cliente, fecha, fecha2);
        }

        // 13
        public DataTable ResumenDeVentasAnulada(DateTime fecha)
        {
            return miDaoFacturaVenta.ResumenDeVentasAnulada(fecha);
        }

        public DataTable ResumenDeVentasAnulada2(DateTime fecha)
        {
            return miDaoFacturaVenta.ResumenDeVentasAnulada2(fecha);
        }

        // 14
        public DataTable ResumenDeVentasAnulada(DateTime fecha, DateTime fecha2)
        {
            return miDaoFacturaVenta.ResumenDeVentasAnulada(fecha, fecha2);
        }

        public DataTable ResumenDeVentasAnulada2(DateTime fecha, DateTime fecha2)
        {
            return miDaoFacturaVenta.ResumenDeVentasAnulada2(fecha, fecha2);
        }

        // 15
        public DataTable ResumenDeVentasAnulada(string cliente, DateTime fecha)
        {
            return miDaoFacturaVenta.ResumenDeVentasAnulada(cliente, fecha);
        }

        public DataTable ResumenDeVentasAnulada2(string cliente, DateTime fecha)
        {
            return miDaoFacturaVenta.ResumenDeVentasAnulada2(cliente, fecha);
        }

        // 16
        public DataTable ResumenDeVentasAnulada(string cliente, DateTime fecha, DateTime fecha2)
        {
            return miDaoFacturaVenta.ResumenDeVentasAnulada(cliente, fecha, fecha2);
        }

        public DataTable ResumenDeVentasAnulada2(string cliente, DateTime fecha, DateTime fecha2)
        {
            return miDaoFacturaVenta.ResumenDeVentasAnulada2(cliente, fecha, fecha2);
        }


        // Funciones de resumen de consulta con usuario

        public DataTable ResumenDeVentas2(int idUsuario, DateTime fecha)
        {
            return this.miDaoFacturaVenta.ResumenDeVentas2(idUsuario, fecha);
        }

        public DataTable ResumenDeVentas2(int idUsuario, DateTime fecha, DateTime fecha2)
        {
            return this.miDaoFacturaVenta.ResumenDeVentas2(idUsuario, fecha, fecha2);
        }

        public DataTable ResumenDeVentasContado2(int idUsuario, DateTime fecha)
        {
            return this.miDaoFacturaVenta.ResumenDeVentasContado2(idUsuario, fecha);
        }

        public DataTable ResumenDeVentasContado2(int idUsuario, DateTime fecha, DateTime fecha2)
        {
            return this.miDaoFacturaVenta.ResumenDeVentasContado2(idUsuario, fecha, fecha2);
        }

        public DataTable ResumenDeVentasCredito2(int idUsuario, DateTime fecha)
        {
            return this.miDaoFacturaVenta.ResumenDeVentasCredito2(idUsuario, fecha);
        }

        public DataTable ResumenDeVentasCredito2(int idUsuario, DateTime fecha, DateTime fecha2)
        {
            return this.miDaoFacturaVenta.ResumenDeVentasCredito2(idUsuario, fecha, fecha2);
        }

        public DataTable ResumenDeVentasAnulada2(int idUsuario, DateTime fecha)
        {
            return this.miDaoFacturaVenta.ResumenDeVentasAnulada2(idUsuario, fecha);
        }

        public DataTable ResumenDeVentasAnulada2(int idUsuario, DateTime fecha, DateTime fecha2)
        {
            return this.miDaoFacturaVenta.ResumenDeVentasAnulada2(idUsuario, fecha, fecha2);
        }



        public List<ProductoFacturaProveedor> ResumenVentas3(DateTime fecha)
        {
            return this.miDaoFacturaVenta.ResumenVentas3(fecha);
        }

        public List<ProductoFacturaProveedor> ResumenVentas3(DateTime fecha, DateTime fecha2)
        {
            return this.miDaoFacturaVenta.ResumenVentas3(fecha, fecha2);
        }
        
        public List<ProductoFacturaProveedor> ResumenVentas3(string nit, DateTime fecha)
        {
            return this.miDaoFacturaVenta.ResumenVentas3(nit, fecha);
        }

        public List<ProductoFacturaProveedor> ResumenVentas3(string nit, DateTime fecha, DateTime fecha2)
        {
            return this.miDaoFacturaVenta.ResumenVentas3(nit, fecha, fecha2);
        }

        public List<ProductoFacturaProveedor> ResumenVentas3(int idUsuario, DateTime fecha)
        {
            return this.miDaoFacturaVenta.ResumenVentas3(idUsuario, fecha);
        }

        public List<ProductoFacturaProveedor> ResumenVentas3(int idUsuario, DateTime fecha, DateTime fecha2)
        {
            return this.miDaoFacturaVenta.ResumenVentas3(idUsuario, fecha, fecha2);
        }



        public DataTable ResumenDeVentasCategoria(string codCategoria, DateTime fecha)
        {
            return this.miDaoFacturaVenta.ResumenDeVentasCategoria(codCategoria, fecha);
        }

        public DataTable ResumenDeVentasCategoria(string codCategoria, DateTime fecha, DateTime fecha2)
        {
            return this.miDaoFacturaVenta.ResumenDeVentasCategoria(codCategoria, fecha, fecha2);
        }

        //

        private DataTable TablaCartera()
        {
            var tabla = new DataTable();
            tabla.TableName = "Cartera";
            tabla.Columns.Add(new DataColumn("Cedula", typeof(string)));
            tabla.Columns.Add(new DataColumn("Nombre", typeof(string)));
            tabla.Columns.Add(new DataColumn("Regimen", typeof(string)));
            tabla.Columns.Add(new DataColumn("Direccion", typeof(string)));
            tabla.Columns.Add(new DataColumn("Ciudad", typeof(string)));
            tabla.Columns.Add(new DataColumn("Depto", typeof(string)));

            tabla.Columns.Add(new DataColumn("Factura", typeof(string)));
            tabla.Columns.Add(new DataColumn("Fecha", typeof(DateTime)));
            tabla.Columns.Add(new DataColumn("Limite", typeof(DateTime)));
            tabla.Columns.Add(new DataColumn("V_Iva", typeof(int)));
            tabla.Columns.Add(new DataColumn("Valor", typeof(int)));

            tabla.Columns.Add(new DataColumn("Abonos", typeof(int)));
            tabla.Columns.Add(new DataColumn("Saldo", typeof(int)));

            tabla.Columns.Add(new DataColumn("Id", typeof(int)));
            return tabla;
        }

        /// <summary>
        /// Anula una Factura de Venta.
        /// </summary>
        /// <param name="numero">Número de la Factura de Venta a anular.</param>
        public void AnularFactura(FacturaVenta factura, bool carga)
        {
            miDaoFacturaVenta.AnularFactura(factura, carga);
        }

        // seccion actualizacion segmemto POS 17-03-2023

        public DataTable LoadProducts(int idFactura)
        {
            var miTabla = new DataTable();
            miTabla.Columns.Add(new DataColumn("Id", typeof(int)));
            miTabla.Columns.Add(new DataColumn("Codigo", typeof(string)));      //  *
            miTabla.Columns.Add(new DataColumn("Articulo", typeof(string)));    //  *
            miTabla.Columns.Add(new DataColumn("Cantidad", typeof(string)));    //  *
            miTabla.Columns.Add(new DataColumn("ValorUnitario", typeof(double)));       // precio venta sin impuestos
            miTabla.Columns.Add(new DataColumn("Descuento", typeof(string)));
            miTabla.Columns.Add(new DataColumn("ValorMenosDescto", typeof(double)));    //valmenosdesc sin impuestos
            miTabla.Columns.Add(new DataColumn("Iva", typeof(string)));                 //  % iva
            miTabla.Columns.Add(new DataColumn("TotalMasIva", typeof(double)));         // valor mas impuestos (precio unit) *
            miTabla.Columns.Add(new DataColumn("Valor", typeof(double)));               // valor total = precio * cant       *
            miTabla.Columns.Add(new DataColumn("Unidad", typeof(string)));
            miTabla.Columns.Add(new DataColumn("IdMedida", typeof(int)));
            miTabla.Columns.Add(new DataColumn("Medida", typeof(string)));
            miTabla.Columns.Add(new DataColumn("IdColor", typeof(int)));
            miTabla.Columns.Add(new DataColumn("IdMarca", typeof(int)));
            miTabla.Columns.Add(new DataColumn("Color", typeof(System.Drawing.Image)));
            miTabla.Columns.Add(new DataColumn("Save", typeof(bool)));

            miTabla.Columns.Add(new DataColumn("Retorno", typeof(bool)));        //  *
            miTabla.Columns.Add(new DataColumn("Valor_", typeof(double)));              // igual a ValorMenosDescto
            miTabla.Columns.Add(new DataColumn("Ico", typeof(double)));

            miTabla.Columns.Add(new DataColumn("ValorIva", typeof(double)));            // valor del iva

            miTabla.Columns.Add(new DataColumn("IdTipoInventario", typeof(int)));
            miTabla.Columns.Add(new DataColumn("IdIva", typeof(int)));

            foreach (DataRow row in miDaoProducto.ProductoFacturaVenta(idFactura).Rows)
            {
                var rw = miTabla.NewRow();
                rw["Codigo"] = row["Codigo"];
                rw["Articulo"] = row["Producto"];
                rw["Cantidad"] = row["Cantidad"];
                rw["Ico"] = Convert.ToInt32(row["impoconsumo"]);
                rw["ValorMenosDescto"] = Math.Round(
                         (Convert.ToDouble(row["Valor"]) -
                         (Convert.ToDouble(row["Valor"]) * Convert.ToDouble(row["Descuento"]) / 100)), 1);
                
                double vIva = Math.Round(
                    (Convert.ToDouble(rw["ValorMenosDescto"]) * Convert.ToDouble(row["Iva"]) / 100), 1);
                rw["TotalMasIva"] = Math.Round((Convert.ToDouble(rw["ValorMenosDescto"]) + vIva + Convert.ToInt32(row["impoconsumo"])), 0);
                if (this.RedondearPrecio2)
                {
                    rw["TotalMasIva"] = UseObject.Aproximar(Convert.ToInt32(rw["TotalMasIva"]),
                                            Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio")));
                }
                rw["Valor"] = Convert.ToInt32(
                              Convert.ToDouble(rw["TotalMasIva"]) * Convert.ToDouble(rw["Cantidad"]));

                rw["Retorno"] = row["retorno"];


                rw["ValorUnitario"] = row["Valor"];
                rw["Descuento"] = row["Descuento"];
                rw["Iva"] = row["Iva"];

                rw["IdMedida"] = row["IdMedida"];
                rw["IdColor"] = row["IdColor"];
                rw["IdMarca"] = row["idmarca"];

                miTabla.Rows.Add(rw);
            }

            return miTabla;
        }

        // fin seccion actualizacion segmemto POS

        /// <summary>
        /// Obtiene el resultado de la consulta de los productos de una Factura de Venta.
        /// </summary>
        /// <param name="numero">Número de la Factura de Venta.</param>
        /// <param name="descuento">Indica si la factura aplica descuento o no (Recargo)</param>
        /// <returns></returns>
        public DataTable ProductoFacturaVenta(string numero, bool descuento)//
        {// here
            var miTabla = CrearDataTable();
            var tabla = miDaoProducto.ProductoFacturaVenta(numero);
            foreach (DataRow row in tabla.Rows)
            {
                var color = new ElColor();
                color.MapaBits = row["Color"].ToString();
                var row_ = miTabla.NewRow();
                row_["Id"] = row["Id"];
                row_["Codigo"] = row["Codigo"];
                row_["Articulo"] = row["Producto"];
                row_["Unidad"] = row["Unidad"];
                row_["IdMedida"] = row["IdMedida"];
                row_["Medida"] = row["Medida"];
                row_["IdColor"] = row["IdColor"];
                row_["Color"] = color.ImagenBit;
                row_["Cantidad"] = row["Cantidad"];
                row_["ValorUnitario"] = row["Valor"];

                var v = row["Valor"].ToString();
                if (descuento)
                {
                    row_["Descuento"] = row["Descuento"].ToString() + "%";
                    row_["ValorMenosDescto"] = Math.Round(
                         (Convert.ToDouble(row["Valor"]) -
                         (Convert.ToDouble(row["Valor"]) * Convert.ToDouble(row["Descuento"]) / 100)), 1);
                }
                else
                {
                    row_["Descuento"] = row["Recargo"].ToString() + "%";
                    row_["ValorMenosDescto"] = Math.Round(
                         (Convert.ToDouble(row["Valor"]) +
                         (Convert.ToDouble(row["Valor"]) * Convert.ToDouble(row["Recargo"]) / 100)), 1);
                }
               // v = row_["ValorMenosDescto"].ToString();

                row_["Iva"] = row["Iva"].ToString() + "%";

                double vIva = Math.Round(
                    (Convert.ToDouble(row_["ValorMenosDescto"]) * Convert.ToDouble(row["Iva"]) / 100), 1);
                //int AprxIva = UseObject.AproximacionDian(vIva);

                row_["ValorIva"] = vIva;
                //row_["TotalMasIva"] = Convert.ToDouble(row_["ValorMenosDescto"]) + vIva;





               // antes row_["TotalMasIva"] = Convert.ToInt32(Convert.ToDouble(row_["ValorMenosDescto"]) + vIva);
                row_["TotalMasIva"] = Math.Round((Convert.ToDouble(row_["ValorMenosDescto"]) + vIva), 2);





                /*row_["ValorIva"] = Convert.ToInt32(
                    Convert.ToDouble(row_["ValorMenosDescto"]) * Convert.ToDouble(row["Iva"]) / 100);
                v = row_["ValorIva"].ToString();*/

                /*/row_["TotalMasIva"] = Convert.ToInt32(
                     Convert.ToDouble(row_["ValorMenosDescto"]) +
                    (Convert.ToDouble(row_["ValorMenosDescto"]) * Convert.ToDouble(row["Iva"]) / 100));*/
               // v = row_["TotalMasIva"].ToString();


                //************
                row_["Valor"] = //Convert.ToInt32(
                                Convert.ToInt32(
                                Convert.ToDouble(row_["TotalMasIva"]) * Convert.ToDouble(row["Cantidad"]));//despues
               // v = row_["Valor"].ToString();

                row_["Retorno"] = row["retorno"];
                row_["Valor_"] = row["valor"];

                miTabla.Rows.Add(row_);
            }
            tabla.Clear();
            tabla = null;
            return miTabla;
        }

        public DataTable ProductoFacturaVenta(int idFactura, bool descuento)//
        {// here
            var miTabla = CrearDataTable();
            var tabla = miDaoProducto.ProductoFacturaVenta(idFactura);
            foreach (DataRow row in tabla.Rows)
            {
                var color = new ElColor();
                color.MapaBits = row["Color"].ToString();
                var row_ = miTabla.NewRow();
                row_["Id"] = row["Id"];
                row_["Codigo"] = row["Codigo"];
                row_["Articulo"] = row["Producto"];
                row_["Unidad"] = row["Unidad"];
                row_["IdMedida"] = row["IdMedida"];
                row_["Medida"] = row["Medida"];
                row_["IdMarca"] = row["idmarca"]; 
                row_["Color"] = color.ImagenBit;
                row_["IdColor"] = row["IdColor"];
                row_["Cantidad"] = row["Cantidad"];
                row_["ValorUnitario"] = row["Valor"];

                var v_ = row["Codigo"].ToString();

             //   v = row["Valor"].ToString();

              //  var doubleV = Convert.ToDouble(row["Valor"]);

                if (descuento)
                {
                    row_["Descuento"] = row["Descuento"].ToString() + "%";
                    row_["ValorMenosDescto"] = Math.Round(
                         (Convert.ToDouble(row["Valor"]) -
                         (Convert.ToDouble(row["Valor"]) * Convert.ToDouble(row["Descuento"]) / 100)), 1);
                }
                else
                {
                    row_["Descuento"] = row["Recargo"].ToString() + "%";
                    row_["ValorMenosDescto"] = Math.Round(
                         (Convert.ToDouble(row["Valor"]) +
                         (Convert.ToDouble(row["Valor"]) * Convert.ToDouble(row["Recargo"]) / 100)), 1);
                }

                row_["Ico"] = Convert.ToInt32(row["impoconsumo"]);
              //   v = row_["ValorMenosDescto"].ToString();

                row_["ValorReal"] = row["valor_venta_real"];

                row_["Iva"] = row["Iva"].ToString() + "%";

                double vIva = Math.Round(
                    (Convert.ToDouble(row_["ValorMenosDescto"]) * Convert.ToDouble(row["Iva"]) / 100), 1);
                //int AprxIva = UseObject.AproximacionDian(vIva);

                row_["ValorIva"] = vIva;


                //***
                
               /* double vIvaUsoIco = Math.Round((Convert.ToDouble(row["Valor"]) * Convert.ToDouble(row["Iva"]) / 100), 1);
                int valorMasIco = Convert.ToInt32(Convert.ToDouble(row["Valor"]) + vIvaUsoIco + Convert.ToDouble(row["impoconsumo"]));
                int valorMenosDescto_ = Convert.ToInt32(valorMasIco - (valorMasIco * Convert.ToDouble(row["Descuento"]) / 100));
                comentado el 12/03/2019
                */

                //**


                // Edición ajuste redondeo de TotalMasIva  16-04-2017
                //row_["TotalMasIva"] = UseObject.Aproximar(Convert.ToInt32(Convert.ToDouble(row_["ValorMenosDescto"]) + vIva), 
                                                          //Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio")));

                // Codigo antes del ajuste redondeo de TotalMasIva 16-04-2017
                 
                //row_["TotalMasIva"] = Convert.ToDouble(row_["ValorMenosDescto"]) + vIva;

                // antes row_["TotalMasIva"] = Convert.ToInt32(Convert.ToDouble(row_["ValorMenosDescto"]) + vIva);
               /* if (row["Codigo"].ToString() == "1307" || row["Codigo"].ToString() == "1297" || row["Codigo"].ToString() == "1304")
                {
                    var impoconsumo_ = Convert.ToInt32(row["impoconsumo"]);
                }*/
                //var round_ = Math.Round((Convert.ToDouble(row_["ValorMenosDescto"]) + vIva), 0);
                if (this.RedondearPrecio2)
                {
                    row_["TotalMasIva_"] = UseObject.Aproximar(Convert.ToInt32(Convert.ToDouble(row_["ValorMenosDescto"]) + vIva),
                        Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio")));         //  para impresion de iva.

                    /*if (Convert.ToDouble(row["impoconsumo"]) > 0)
                    {
                        row_["TotalMasIva"] = UseObject.Aproximar(valorMenosDescto_, Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio")));
                    }
                    else
                    {*/
                        //row_["TotalMasIva"] = Math.Round((Convert.ToDouble(row_["ValorMenosDescto"]) + vIva), 2);
                        row_["TotalMasIva"] = UseObject.Aproximar(Convert.ToInt32(Convert.ToDouble(row_["ValorMenosDescto"]) + vIva + Convert.ToInt32(row["impoconsumo"])),
                            Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio")));
                    //}
                }
                else
                {
                    row_["TotalMasIva_"] = Math.Round((Convert.ToDouble(row_["ValorMenosDescto"]) + vIva), 0);  // para impresion de iva.

                    /*if (Convert.ToDouble(row["impoconsumo"]) > 0)
                    {
                        row_["TotalMasIva"] = valorMenosDescto_;
                    }
                    else
                    {*/
                    row_["TotalMasIva"] = Math.Round((Convert.ToDouble(row_["ValorMenosDescto"]) + vIva + Convert.ToInt32(row["impoconsumo"])), 0);
                    //}
                }
                /**** Codigo antes del ajuste redondeo de TotalMasIva 16-04-2017  */


                //  v = row_["TotalMasIva"].ToString();

                /*row_["ValorIva"] = Convert.ToInt32(
                    Convert.ToDouble(row_["ValorMenosDescto"]) * Convert.ToDouble(row["Iva"]) / 100);
                v = row_["ValorIva"].ToString();*/

                /*/row_["TotalMasIva"] = Convert.ToInt32(
                     Convert.ToDouble(row_["ValorMenosDescto"]) +
                    (Convert.ToDouble(row_["ValorMenosDescto"]) * Convert.ToDouble(row["Iva"]) / 100));*/
                // v = row_["TotalMasIva"].ToString();


                //************

               /* var doubleTotalMasIva = Convert.ToDouble(row_["TotalMasIva"]);
                var doubleCantidad = Convert.ToDouble(row["Cantidad"]);
                var t = doubleTotalMasIva * doubleCantidad;
                Console.WriteLine("{0,20:R}", t);
                int intT = Convert.ToInt32(t);
                double intTD = Math.Round(t, 0, MidpointRounding.AwayFromZero);*/
                //int intParse = int.Parse(t.ToString());

                // valor sin impoconsumo
                row_["Valor_1"] = Convert.ToInt32(
                                  Convert.ToDouble(row_["TotalMasIva_"]) * Convert.ToDouble(row["Cantidad"]));

                // valor con impoconsumo
                row_["Valor"] = //Convert.ToInt32(
                                Convert.ToInt32(
                                Convert.ToDouble(row_["TotalMasIva"]) * Convert.ToDouble(row["Cantidad"])); //despues
                //row_["Valor"] =  row["total"];
                var v = row_["Valor"].ToString();

                row_["Retorno"] = row["retorno"];
                row_["Valor_"] = row["valor"];

                miTabla.Rows.Add(row_);
            }
            tabla.Clear();
            tabla = null;
            return miTabla;
        }

        /// <summary>
        /// Obtiene la lista de detalles de los productos de una factura.
        /// </summary>
        /// <param name="factura">Factura a la cual se le hace la consulta.</param>
        /// <returns></returns>
        public List<Utilities.DetalleProducto> Detalles(string factura)
        {
            var detalles = new List<Utilities.DetalleProducto>();
            var tabla = miDaoProducto.ProductoFacturaVenta(factura);
            foreach (DataRow row in tabla.Rows)
            {
                var detalle = new Utilities.DetalleProducto();
                detalle.Codigo = row["Codigo"].ToString();
                detalle.Medida = Convert.ToInt32(row["IdMedida"]);
                detalle.Color = Convert.ToInt32(row["IdColor"]);
                detalle.Cantidad = Convert.ToDouble(row["Cantidad"]);
                detalles.Add(detalle);
            }
            return detalles;
        }

        public List<Utilities.DetalleProducto> Detalles(int idFactura)
        {
            var detalles = new List<Utilities.DetalleProducto>();
            var tabla = miDaoProducto.ProductoFacturaVenta(idFactura);
            foreach (DataRow row in tabla.Rows)
            {
                var detalle = new Utilities.DetalleProducto();
                detalle.Codigo = row["Codigo"].ToString();
                detalle.Medida = Convert.ToInt32(row["IdMedida"]);
                detalle.Color = Convert.ToInt32(row["IdColor"]);
                detalle.Cantidad = Convert.ToDouble(row["Cantidad"]);
                detalle.Impoconsumo = Convert.ToDouble(row["impoconsumo"]);
                detalles.Add(detalle);
            }
            return detalles;
        }

        /// <summary>
        /// Comprueba si en la factura se encuentra un producto determinado.
        /// </summary>
        /// <param name="factura">Factura de la cual se hace la consulta.</param>
        /// <param name="dProducto">Producto a buscar en la Factura.</param>
        /// <returns></returns>
        public bool ProductoDeFactura(string factura, Utilities.DetalleProducto dProducto)
        {
            var tabla = miDaoProducto.ProductoFacturaVenta(factura);
            var qRow = (from data in tabla.AsEnumerable()
                        where data.Field<string>("Codigo") == dProducto.Codigo
                        && data.Field<int>("IdMedida") == dProducto.Medida
                        && data.Field<int>("IdColor") == dProducto.Color
                        select data);
            if (qRow.ToArray().Length != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ProductoDeFactura(int idFactura, Utilities.DetalleProducto dProducto)
        {
            var tabla = miDaoProducto.ProductoFacturaVenta(idFactura);
            var qRow = (from data in tabla.AsEnumerable()
                        where data.Field<string>("Codigo") == dProducto.Codigo
                        && data.Field<int>("IdMedida") == dProducto.Medida
                        && data.Field<int>("IdColor") == dProducto.Color
                        select data);
            if (qRow.ToArray().Length != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public DataTable ClienteDeFacutura(string numero)
        {
            return miDaoFacturaVenta.ClienteDeFacutura(numero);
        }

        /// <summary>
        /// Obtiene el saldo pendiente de un cliente por todas sus factura.
        /// </summary>
        /// <param name="idEstado">Estdo del la factura (Crédito).</param>
        /// <param name="nitCliente">Nit del Cliente a consultar.</param>
        /// <returns></returns>
        public int SaldoPorCliente(int idEstado, string nitCliente)
        {
            return miDaoFacturaVenta.SaldoPorCliente(idEstado, nitCliente);
        }

        public List<FacturaVenta> CarteraCliente(int idEstado, string nitCliente)
        {
            return this.miDaoFacturaVenta.CarteraCliente(idEstado, nitCliente);
        }

        public List<FacturaVenta> CarteraCliente_(int idEstado, string nitCliente)
        {
            return this.miDaoFacturaVenta.CarteraCliente_(idEstado, nitCliente);
        }

        public List<FacturaVenta> CarteraCliente(string nitCliente)
        {
            List<FacturaVenta> facturas = new List<FacturaVenta>();
            DataTable tCartera = CarteraClientes(true, true, nitCliente);
            foreach (DataRow cRow in tCartera.Rows)
            {
                facturas.Add(new FacturaVenta
                {
                    Id = Convert.ToInt32(cRow["Id"]),
                    Numero = cRow["Factura"].ToString(),
                    Saldo = Convert.ToInt32(cRow["Saldo"])
                });
            }
            return facturas;


            /*
             var factura = new FacturaVenta();
                        factura.Proveedor.NitProveedor = row["cedula"].ToString();
                        factura.Proveedor.NombreProveedor = row["nombre"].ToString();
                        factura.Id = Convert.ToInt32(row["id"]);
                        factura.Numero = row["factura"].ToString();
                        factura.FechaFactura = Convert.ToDateTime(row["fecha"]);
                        factura.FechaLimite = Convert.ToDateTime(row["limite"]);
                        factura.EstadoFactura.Id = Convert.ToInt32(row["idestado"]);
                        factura.Valor = Convert.ToInt32(valorFactura);
                        factura.Pagos = pagosFactura;
                        factura.Saldo = factura.Valor - factura.Pagos;
                        if (factura.Saldo > 0)
                        {
                            cartera.Add(factura);
                        }
            */

            /*
            tabla.Columns.Add(new DataColumn("Cedula", typeof(string)));
            tabla.Columns.Add(new DataColumn("Nombre", typeof(string)));
            tabla.Columns.Add(new DataColumn("Regimen", typeof(string)));
            tabla.Columns.Add(new DataColumn("Direccion", typeof(string)));
            tabla.Columns.Add(new DataColumn("Ciudad", typeof(string)));
            tabla.Columns.Add(new DataColumn("Depto", typeof(string)));

            tabla.Columns.Add(new DataColumn("Factura", typeof(string)));
            tabla.Columns.Add(new DataColumn("Fecha", typeof(DateTime)));
            tabla.Columns.Add(new DataColumn("Limite", typeof(DateTime)));
            tabla.Columns.Add(new DataColumn("V_Iva", typeof(int)));
            tabla.Columns.Add(new DataColumn("Valor", typeof(int)));

            tabla.Columns.Add(new DataColumn("Abonos", typeof(int)));
            tabla.Columns.Add(new DataColumn("Saldo", typeof(int)));

            tabla.Columns.Add(new DataColumn("Id", typeof(int)));
            */
        }


        /// <summary>
        /// Obtiene el saldo pendiente de todas las facturas a crédito.
        /// </summary>
        /// <param name="idEstado">Estado de la factura (Crédito).</param>
        /// <returns></returns>
        public int SaldoTotalCredito(int idEstado)
        {
            return miDaoFacturaVenta.SaldoTotalCredito(idEstado);
        }

        /*public DataSet TotalFacturasContado(DateTime fecha)
        {
            return miDaoFacturaVenta.TotalFacturasContado(fecha);
        }*/

        /*public DataSet TotalFacturasContado(int idCaja, DateTime fecha)
        {
            return miDaoFacturaVenta.TotalFacturasContado(idCaja, fecha);
        }*/


        public DataSet TotalFacturasCredito(int idEstado, int idCaja, DateTime fecha, bool caja)
        {
            return miDaoFacturaVenta.TotalFacturasCredito(idEstado, idCaja, fecha, caja);
        }

       /* public DataSet TotalFacturasCredito(int idEstado, int idCaja, DateTime fecha, DateTime fecha2, bool caja)
        {
            return miDaoFacturaVenta.TotalFacturasCredito(idEstado, idCaja, fecha, fecha2, caja);
        }*/


        public DataTable TotalFacturasCredito(int idEstado, int idCaja, DateTime fecha, DateTime fecha2)
        {
            return miDaoFacturaVenta.TotalFacturasCredito(idEstado, idCaja, fecha, fecha2);
        }

        public DataTable TotalFacturasCreditoHoras(int idEstado, int idCaja, DateTime fecha, DateTime fecha2)
        {
            return miDaoFacturaVenta.TotalFacturasCreditoHoras(idEstado, idCaja, fecha, fecha2);
        }

        public double TotalVentas(int idEstado, int idCaja, DateTime fecha, DateTime fecha2)
        {
            return this.miDaoFacturaVenta.TotalVentas(idEstado, idCaja, fecha, fecha2);
        }

        public long CountRegistroVentas()
        {
            return miDaoFacturaVenta.CountRegistroVentas();
        }

        public long CountRegistroVentas(int idCaja)
        {
            return miDaoFacturaVenta.CountRegistroVentas(idCaja);
        }

        public DateTime MinFecha()
        {
            return miDaoFacturaVenta.MinFecha();
        }

        public DateTime MinFecha(int idCaja)
        {
            return miDaoFacturaVenta.MinFecha(idCaja);
        }

        public DataTable RegistroVentas(int idCaja, DateTime fecha, bool caja)
        {
            return miDaoFacturaVenta.RegistroVentas(idCaja, fecha, caja);
        }

        public DataTable RegistroVentas(DateTime fecha, DateTime fecha2)
        {
            return this.miDaoFacturaVenta.NumeroFacturasTodas(fecha, fecha2);

        }

        public DataTable SerieNumeroFacturas(int idCaja, DateTime fecha, bool caja)
        {
            return miDaoFacturaVenta.SerieNumeroFacturas(idCaja, fecha, caja);
        }

        public DataSet TotalAbonos(DateTime fecha)
        {
            return miDaoFacturaVenta.TotalAbonos(fecha);
        }

        public DataSet TotalAbonos(int idCaja, DateTime fecha)
        {
            return miDaoFacturaVenta.TotalAbonos(idCaja, fecha);
        }

        public DataSet TotalAbonosFecha(DateTime fecha)
        {
            return miDaoFacturaVenta.TotalAbonosFecha(fecha);
        }

        /* DataSet IvaFacturaContado(int idCaja, DateTime fecha, bool caja)
        {
            return miDaoFacturaVenta.IvaFacturaContado(idCaja, fecha, caja);
        }*/

        /*public DataTable ListaIvaContado(int idCaja, DateTime fecha, bool caja)
        {
            return miDaoFacturaVenta.ListaIvaContado(idCaja, fecha, caja);
        }*/

        /*public DataSet IvaFacturaCredito(int idCaja, DateTime fecha, bool caja)
        {
            return miDaoFacturaVenta.IvaFacturaCredito(idCaja, fecha, caja);
        }*/

        //
        public DataTable IvaFacturado(int id, bool descto)
        {
            return miDaoFacturaVenta.IvaFacturado(id, descto);
        }

        public DataSet TotalIvaFacturado(int idCaja, DateTime fecha, bool caja)
        {
            var tIva = miDaoFacturaVenta.TotalIvaFacturado(idCaja, fecha, caja);
            var ds = new DataSet();
            var tabla = new DataTable();
            tabla.TableName = "IvaGravado";
            tabla.Columns.Add(new DataColumn("Iva", typeof(string)));
            tabla.Columns.Add(new DataColumn("Base", typeof(int)));
            tabla.Columns.Add(new DataColumn("VIva", typeof(int)));
            tabla.Columns.Add(new DataColumn("SubTotal", typeof(int)));

            foreach (DataRow row in tIva.Tables[0].Rows)
            {
                var tRow = tabla.NewRow();
                tRow["Iva"] = row["Iva"];
                tRow["Base"] = Convert.ToInt32(row["Base"]);
                tRow["VIva"] = Convert.ToInt32(row["VIva"]);
                tRow["SubTotal"] = Convert.ToInt32(row["SubTotal"]);
                tabla.Rows.Add(tRow);
            }
            ds.Tables.Add(tabla);
            return ds;
        }


        // Funciones de actualización 23/05/2018 & 12/07/2018, Mejora al calculo de Iva.

        /// <summary>
        /// Devuelve una lista de los valroes de IVA para la impresion de factura de venta.
        /// </summary>
        /// <param name="id">ID de la factura de venta.</param>
        /// <returns></returns>
        public List<Iva> IvaFacturado(int id)
        {
            List<Iva> detallesIva = new List<Iva>();
            foreach (DataRow pRow in this.ProductoFacturaVenta(id, true).Rows)
            {
                detallesIva.Add(new Iva
                {
                    PorcentajeIva = UseObject.RemoveCharacter(pRow["Iva"].ToString(), '%'),
                    Total = Convert.ToInt32(pRow["Valor"]),
                    TotalSinIco = Convert.ToInt32(pRow["Valor_1"])
                });
            }
            var query = from data in detallesIva
                        group data by new
                        {
                            PorcentajeIva = data.PorcentajeIva,
                        }
                            into grupo
                            orderby grupo.Key.PorcentajeIva ascending
                            select new
                            {
                                PorcentajeIva = grupo.Key.PorcentajeIva,
                                Total = grupo.Sum(s => s.Total),
                                TotalSinIco = grupo.Sum(s => s.TotalSinIco)
                            };
            List<Iva> ivaFacturado = new List<Iva>();
            foreach (var iva_ in query)
            {
                ivaFacturado.Add(new Iva
                {
                    PorcentajeIva = iva_.PorcentajeIva,
                    Total = iva_.Total,
                    BaseI = Convert.ToInt32(iva_.TotalSinIco / ((iva_.PorcentajeIva / 100) + 1)),
                    ValorIva = iva_.TotalSinIco - Convert.ToInt32(iva_.TotalSinIco / ((iva_.PorcentajeIva / 100) + 1))
                });
            }
            return ivaFacturado;
        }


        // Fin funciones de actualización 23/05/2018 & 12/07/2018, Mejora al calculo de Iva.


        // NUEVO CODIGO 02-02-2016

        /*public DataTable TotalIvaFacturado(int idCaja, DateTime fecha)
        {
            return this.miDaoFacturaVenta.TotalIvaFacturado(idCaja, fecha);
        }*/

        //11-04-2016  1. Iva por caja y fecha, impresion media carta y en tirilla.
        public DataTable TotalIvaFacturado2(int idCaja, DateTime fecha)
        {
            return this.miDaoFacturaVenta.TotalIvaFacturado2(idCaja, fecha);
        }

        // FIN NUEVO CODIGO 02-02-2016

        // Actualización comprobante diario fiscal general 23-02-2017

        //  3.  Iva por fecha, impresion en tirilla.
        public DataTable TotalIvaFacturado2(DateTime fecha)
        {
            return this.miDaoFacturaVenta.TotalIvaFacturado2(fecha);
        }

        //  2.  Iva por fecha, impresion media carta.
        public DataSet TotalIvaFacturado2Ds(DateTime fecha)
        {
            return this.miDaoFacturaVenta.TotalIvaFacturado2Ds(fecha);
        }

        // Fin Actualización


        //  Funciones de actualización 12/07/2018, Mejora al calculo de Iva.

        public DataTable TotalIvaFacturado(int idCaja, DateTime fecha)
        {
            return this.miDaoFacturaVenta.TotalIvaFacturado(idCaja, fecha);
        }

        public DataTable TotalIvaFacturado(DateTime fecha, string exento)
        {
            return this.miDaoFacturaVenta.TotalIvaFacturado(fecha, exento);
        }

        public DataTable TotalIvaFacturado(DateTime fecha, DateTime fecha2)
        {
            return this.miDaoFacturaVenta.TotalIvaFacturado(fecha, fecha2);
        }


        public DataTable TotalIvaFacturado_Datos(DateTime fecha, DateTime fecha2)
        {
            return this.miDaoFacturaVenta.TotalIvaFacturado_Datos(fecha, fecha2);
        }


        public DataTable TotalIvaFacturadoConExcento(int idCaja, DateTime fecha, string exento)
        {
            return this.miDaoFacturaVenta.TotalIvaFacturadoConExcento(idCaja, fecha, exento);
        }


        // Funciones actualización, nuevo calculo de impuestos 09 - 09 -2020        ***

        public List<Impuesto> TotalesImpuesto(int idCaja, DateTime fecha)
        {
            return miDaoFacturaVenta.TotalesImpuesto(idCaja, fecha);
        }

        public List<Impuesto> TotalesImpuesto(DateTime fecha)
        {
            return miDaoFacturaVenta.TotalesImpuesto(fecha);
        }

        public List<Impuesto> TotalesImpuesto(DateTime fecha, DateTime fecha2)
        {
            return miDaoFacturaVenta.TotalesImpuesto(fecha, fecha2);
        }


        /// New query, add id_iva and improve performance                       2022 11 26
        /// 
        public List<Impuesto> TotalesImpuesto(int idCaja, DateTime fecha, DateTime fecha2)
        {
            return miDaoFacturaVenta.TotalesImpuesto(idCaja, fecha,fecha2);
        }

        // Fin Funciones actualización, nuevo calculo de impuestos                  ***


        public int Acumulado(int idCaja, DateTime fecha, DateTime fecha2)
        {
            return this.miDaoFacturaVenta.Acumulado(idCaja, fecha, fecha2);
        }

        public int Acumulado(DateTime fecha, DateTime fecha2)
        {
            return this.miDaoFacturaVenta.Acumulado(fecha, fecha2);
        }

        public double TotalImpoConsumo(int idCaja, DateTime fecha2)
        {
            return this.miDaoFacturaVenta.TotalImpoConsumo(idCaja, fecha2);
        }

        public double TotalImpoConsumo(DateTime fecha2)
        {
            return this.miDaoFacturaVenta.TotalImpoConsumo(fecha2);
        }

        //  Fin funciones de actualización 12/07/2018, Mejora al calculo de Iva.


        public DataTable  ResumenDeUtilidad(DateTime fecha, DateTime fecha2)
        {
            return null;
        }

       /* public DataTable TotalIvaFacturado(int idCaja, DateTime fecha, bool caja, string no)
        {

        }*/

        public long SaldoDeCliente(string cliente)
        {
            return miDaoFacturaVenta.SaldoDeCliente(cliente);
        }

        public DataTable DatosSaldoDeCliente
            (string cliente, bool cartera, List<Ingreso> transacciones)
        {
            return miDaoFacturaVenta.DatosSaldoDeCliente(cliente, cartera, transacciones);
        }

        public DataTable FacturasAnuladas(int idCaja, DateTime fecha)
        {
            return miDaoFacturaVenta.FacturasAnuladas(idCaja, fecha);
        }

        public DataTable FacturasAnuladas(DateTime fecha)
        {
            return miDaoFacturaVenta.FacturasAnuladas(fecha);
        }

        // Funciones de actualización 23/05/2018
        
        public List<IvaAnulado> VentasAnuladas(int idCaja, DateTime fecha)
        {
            return this.miDaoFacturaVenta.VentasAnuladas(idCaja, fecha);
        }

        public List<IvaAnulado> VentasAnuladas(DateTime fecha)
        {
            return this.miDaoFacturaVenta.VentasAnuladas(fecha);
        }

        public List<IvaAnulado> VentasAnuladas(DateTime fecha, DateTime fecha2)
        {
            return miDaoFacturaVenta.VentasAnuladas(fecha, fecha2);
        }

        public DataTable TVentasAnuladas(int idCaja, DateTime fecha)
        {
            return this.TableDetalleIvaAnulado(this.miDaoFacturaVenta.VentasAnuladas(idCaja, fecha));
        }

        public DataTable TVentasAnuladas(DateTime fecha)
        {
            return this.TableDetalleIvaAnulado(this.miDaoFacturaVenta.VentasAnuladas(fecha));
        }

        public DataTable TVentasAnuladas(DateTime fecha, DateTime fecha2)
        {
            return this.TableDetalleIvaAnulado(this.miDaoFacturaVenta.VentasAnuladas(fecha, fecha2));
        }

        private DataTable TableDetalleIvaAnulado(List<IvaAnulado> ivaAnulados)
        {
            var tabla = new DataTable();
            tabla.TableName = "IvaAnulado";
            tabla.Columns.Add(new DataColumn("NoFrv", typeof(string)));
            tabla.Columns.Add(new DataColumn("Iva", typeof(string)));
            tabla.Columns.Add(new DataColumn("Base", typeof(double)));
            tabla.Columns.Add(new DataColumn("VIva", typeof(double)));
            tabla.Columns.Add(new DataColumn("SubTotal", typeof(int)));
            foreach (var ivaAnulado_ in ivaAnulados)
            {
                var row = tabla.NewRow();
                if (ivaAnulado_.NoFactura.Equals(""))
                {
                    row["NoFrv"] = "Frv. General";
                }
                else
                {
                    row["NoFrv"] = ivaAnulado_.NoFactura;
                }
                row["Iva"] = ivaAnulado_.PorcentajeIva;
                row["Base"] = ivaAnulado_.BaseI;
                row["VIva"] = ivaAnulado_.ValorIva;
                row["SubTotal"] = ivaAnulado_.Total;
                tabla.Rows.Add(row);
            }
            return tabla;
        }
        
        // Fin funciones de actualización 23/05/2018

        public string IngresarPagoGeneral(string cliente, FormaPago pago, Ingreso ingreso)
        {
            return miDaoFacturaVenta.IngresarPagoGeneral(cliente, pago, ingreso);
        }

        public void IngresarPagoGeneral(string nitCliente, FormaPago pago, Ingreso ingreso, List<FacturaVenta> cartera)
        {
            this.miDaoFacturaVenta.IngresarPagoGeneral(nitCliente, pago, ingreso, cartera);
        }

        public void IngresarPagoGeneral(string nitCliente, Ingreso ingreso, List<FacturaVenta> cartera)
        {
            this.miDaoFacturaVenta.IngresarPagoGeneral(nitCliente, ingreso, cartera);
        }


        /* public void AjusteIngresos()
         {
             var daoPago = new DaoFormaPago();
             var pagos = daoPago.FormasDePagoDeFacturaVenta();
             foreach (DataRow pRow in pagos.Rows)
             {
                 daoPago.EditarValorPagado(Convert.ToInt32(pRow["Id"]), Convert.ToInt32(pRow["Valor"]));
             }

             foreach (DataRow pRow in pagos.Rows)
             {
                 var total = Convert.ToInt32(
                     ProductoFacturaVenta(pRow["Factura"].ToString(), true).
                     AsEnumerable().Sum(s => s.Field<double>("Valor")));
                 daoPago.EditarValorPago(Convert.ToInt32(pRow["Id"]), total);
             }
         }*/

        /// <summary>
        /// Crea las respectivas columnas del DataTable para ProductoFacturaVenta.
        /// </summary>
        private DataTable CrearDataTable()
        {
            var miTabla = new DataTable();
            miTabla.Columns.Add(new DataColumn("Id", typeof(int)));
            miTabla.Columns.Add(new DataColumn("Codigo", typeof(string)));
            miTabla.Columns.Add(new DataColumn("Articulo", typeof(string)));
            miTabla.Columns.Add(new DataColumn("Unidad", typeof(string)));
            miTabla.Columns.Add(new DataColumn("IdMedida", typeof(int)));
            miTabla.Columns.Add(new DataColumn("Medida", typeof(string)));
            miTabla.Columns.Add(new DataColumn("IdColor", typeof(int)));
            miTabla.Columns.Add(new DataColumn("Color", typeof(System.Drawing.Image)));
            miTabla.Columns.Add(new DataColumn("IdMarca", typeof(int)));
            miTabla.Columns.Add(new DataColumn("Cantidad", typeof(double)));
            miTabla.Columns.Add(new DataColumn("ValorUnitario", typeof(double)));
            miTabla.Columns.Add(new DataColumn("Descuento", typeof(string)));
            miTabla.Columns.Add(new DataColumn("ValorMenosDescto", typeof(double)));
            miTabla.Columns.Add(new DataColumn("Iva", typeof(string)));
            miTabla.Columns.Add(new DataColumn("ValorIva", typeof(double)));
            miTabla.Columns.Add(new DataColumn("TotalMasIva", typeof(double)));
            miTabla.Columns.Add(new DataColumn("Valor", typeof(double)));

            miTabla.Columns.Add(new DataColumn("TotalMasIva_", typeof(double)));
            miTabla.Columns.Add(new DataColumn("Valor_1", typeof(double)));

            miTabla.Columns.Add(new DataColumn("Retorno", typeof(bool)));
            miTabla.Columns.Add(new DataColumn("Valor_", typeof(double)));

            miTabla.Columns.Add(new DataColumn("ValorReal", typeof(double)));
            miTabla.Columns.Add(new DataColumn("Ico", typeof(double)));
            return miTabla;
        }

        private void TablaResumen()
        {
            this.Tabla = new DataTable();
            Tabla.Columns.Add(new DataColumn("Fecha", typeof(DateTime)));
            Tabla.Columns.Add(new DataColumn("Nit", typeof(string)));
            Tabla.Columns.Add(new DataColumn("Cliente", typeof(string)));
            Tabla.Columns.Add(new DataColumn("Factura", typeof(string)));
            Tabla.Columns.Add(new DataColumn("Estado", typeof(string)));
            Tabla.Columns.Add(new DataColumn("Pago", typeof(string)));
            Tabla.Columns.Add(new DataColumn("Base", typeof(int)));
            Tabla.Columns.Add(new DataColumn("Iva", typeof(int)));
            Tabla.Columns.Add(new DataColumn("Total", typeof(int)));
        }


        // consultas de productos vendidos por debajo del precio de venta.

        public DataTable VentasDebajoPrecio(DateTime fecha)
        {
            return this.miDaoFacturaVenta.VentasDebajoPrecio(fecha);
        }

        public DataTable VentasDebajoPrecio(DateTime fecha, DateTime fecha2)
        {
            return this.miDaoFacturaVenta.VentasDebajoPrecio(fecha, fecha2);
        }

        #region Consulta venta de producto

        public List<int> Anios()
        {
            return this.miDaoFacturaVenta.Anios();
        }

        public List<Producto> VentaProductos(DateTime fecha)
        {
            return this.miDaoFacturaVenta.VentaProductos(fecha);
        }

        public List<Producto> VentaProductos(DateTime fecha, int idMarca)
        {
            return this.miDaoFacturaVenta.VentaProductos(fecha, idMarca);
        }

        public List<Producto> VentaProductos(DateTime fecha, string codCategoria, int idMarca)
        {
            return this.miDaoFacturaVenta.VentaProductos(fecha, codCategoria, idMarca);
        }

        public List<Producto> VentaProductos(DateTime fecha, string codCategoria)
        {
            return this.miDaoFacturaVenta.VentaProductos(fecha, codCategoria);
        }

        public List<Producto> VentaProductos(DateTime fecha, DateTime fecha2)
        {
            return this.miDaoFacturaVenta.VentaProductos(fecha, fecha2);
        }

        public List<Producto> VentaProductos(DateTime fecha, DateTime fecha2, int idMarca)
        {
            return this.miDaoFacturaVenta.VentaProductos(fecha, fecha2, idMarca);
        }

        public List<Producto> VentaProductos(DateTime fecha, DateTime fecha2, string codCategoria, int idMarca)
        {
            return this.miDaoFacturaVenta.VentaProductos(fecha, fecha2, codCategoria, idMarca);
        }

        public List<Producto> VentaProductos(DateTime fecha, DateTime fecha2, string codCategoria)
        {
            return this.miDaoFacturaVenta.VentaProductos(fecha, fecha2, codCategoria);
        }

        #endregion


        #region Consulta venta de productos por clasificación de clientes

        // Periodo + Clasificacion
        public DataTable ConsultaVentasClasificacionCliente(DateTime fecha, DateTime fecha2, int idClasificacion)
        {
            return this.miDaoFacturaVenta.ConsultaVentasClasificacionCliente(fecha, fecha2, idClasificacion);
        }

        // Periodo + Clasificacion + Categoria *
        public DataTable ConsultaVentasClasificacionCliente(DateTime fecha, DateTime fecha2, int idClasificacion, string codCategoria)
        {
            return this.miDaoFacturaVenta.ConsultaVentasClasificacionCliente(fecha, fecha2, idClasificacion, codCategoria);
        }

        // Periodo + Clasificacion + Marca
        public DataTable ConsultaVentasClasificacionCliente(DateTime fecha, DateTime fecha2, int idClasificacion, int idMarca)
        {
            return this.miDaoFacturaVenta.ConsultaVentasClasificacionCliente(fecha, fecha2, idClasificacion, idMarca);
        }

        // Periodo + Clasificacion + Categoria + Marca
        public DataTable ConsultaVentasClasificacionCliente(DateTime fecha, DateTime fecha2, int idClasificacion, string codCategoria, int idMarca)
        {
            return this.miDaoFacturaVenta.ConsultaVentasClasificacionCliente(fecha, fecha2, idClasificacion, codCategoria, idMarca);
        }

        // Periodo + Clasificacion + Producto
        public DataTable ConsultaVentasClasificacionClienteProducto(DateTime fecha, DateTime fecha2, int idClasificacion, string codProducto)
        {
            return this.miDaoFacturaVenta.ConsultaVentasClasificacionClienteProducto(fecha, fecha2, idClasificacion, codProducto);
        }

        #endregion


        #region Consulta venta de productos por Usuario

        public DataTable ConsultaVentasProductosUsuario(DateTime fecha, DateTime fecha2, int idUsuario)
        {
            return miDaoFacturaVenta.ConsultaVentasProductosUsuario(fecha, fecha2, idUsuario);
        }

        public DataTable ConsultaVentasProductosUsuario(DateTime fecha, DateTime fecha2, int idUsuario, string codCategoria)
        {
            return miDaoFacturaVenta.ConsultaVentasProductosUsuario(fecha, fecha2, idUsuario, codCategoria);
        }

        public DataTable ConsultaVentasProductosUsuario(DateTime fecha, DateTime fecha2, int idUsuario, int idMarca)
        {
            return miDaoFacturaVenta.ConsultaVentasProductosUsuario(fecha, fecha2, idUsuario, idMarca);
        }

        public DataTable ConsultaVentasProductosUsuario(DateTime fecha, DateTime fecha2, int idUsuario, string codCategoria, int idMarca)
        {
            return miDaoFacturaVenta.ConsultaVentasProductosUsuario(fecha, fecha2, idUsuario, codCategoria, idMarca);
        }

        #endregion 


        // Retorno temporal de articulos.

        public void IngresarRetornoTemporal(ProductoFacturaProveedor producto)
        {
            miDaoProducto.IngresarRetornoTemporal(producto);
        }

        public void EliminarRetornoTemporal()
        {
            miDaoProducto.EliminarRetornoTemporal();
        }

        public void AjustarCosto()
        {
            miDaoFacturaVenta.AjustarCosto();
        }

        public void VistaFaltante()
        {
            this.miDaoFacturaVenta.VistaFaltante();
        }

         // codigo para verificar
        public DataTable PagosDeFactura(int idEstado, DateTime fecha, DateTime fecha2)
        {
            return this.miDaoFacturaVenta.PagosDeFactura(idEstado, fecha, fecha2);
        }

        public void AjusteVentaIva(int idIva)
        {
            miDaoFacturaVenta.AjusteVentaIva(idIva);
        }

        public DataTable Clientes()
        {
            return this.miDaoFacturaVenta.Clientes();
        }


        // Codigo para cargar puntos a clientes

        public DataTable CargarPuntos(DateTime fecha, DateTime fecha2)
        {
            return this.miDaoFacturaVenta.CargarPuntos(fecha, fecha2);
        }


        // Codigo para consultar los numeros repetidos de facturas de venta.

        public DataTable NumerosFacturasRepetidas()
        {
            return this.miDaoFacturaVenta.NumerosFacturasRepetidas();
        }


        // Codigo para nivelar valores de facturas de venta 16/03/2019

        public DataTable FacturasYpagos(int idCaja, DateTime fecha)
        {
            return this.miDaoFacturaVenta.FacturasYpagos_org(idCaja, fecha);
        }

        // Fin Codigo para nivelar valores de facturas de venta 16/03/2019

        public int SaldoClienteRboIngreso(string nitCliente)
        {
            return this.miDaoFacturaVenta.SaldoClienteRboIngreso(nitCliente);
        }


        // Funcion auxiliar para tomar el valor del total de ventas, en comp. diario "Todas las cajas"

        public int TotalVenta(DateTime fecha)
        {
            return this.miDaoFacturaVenta.TotalVenta(fecha);
        }

        public int TotalVenta(int idCaja, DateTime fecha)
        {
            return this.miDaoFacturaVenta.TotalVenta(idCaja, fecha);
        }

        public int VentasCredito(int idEstado, int idCaja, DateTime fecha, DateTime fecha2)
        {
            return this.miDaoFacturaVenta.VentasCredito(idEstado, idCaja, fecha, fecha2);
        }

        public List<FacturaVenta> Ventas(int idCaja, DateTime fecha, DateTime fecha2)
        {
            return miDaoFacturaVenta.Ventas(idCaja, fecha, fecha2);
        }

        public List<FacturaVenta> POSJoinElectronicInvoices(int idCaja, DateTime fecha, DateTime fecha2)
        {
            return this.miDaoFacturaVenta.POSJoinElectronicInvoices(idCaja, fecha, fecha2);
        }

        /*public int VentasCredito(int idEstado, DateTime fecha, DateTime fecha2)
        {
            return this.miDaoFacturaVenta.VentasCredito(idEstado, fecha, fecha2);
        }

        public int VentasCredito(int idEstado, DateTime fecha)
        {
            return this.miDaoFacturaVenta.VentasCredito(idEstado, fecha);
        }*/



        public DataTable ValoresFacturaVenta(DateTime fecha, DateTime fecha2)
        {
            return this.miDaoFacturaVenta.ValoresFacturaVenta(fecha, fecha2);
        }


        // Datos de cartera para importar
        public List<FacturaVenta> FacturasDeCartera()
        {
            try
            {
                var facturas = new List<FacturaVenta>();
                var tCartera = this.CarteraClientes(false, false, null);
                foreach (DataRow cartRow in tCartera.Rows)
                {
                    facturas.Add(this.miDaoFacturaVenta.FacturaDeVenta(Convert.ToInt32(cartRow["Id"])));
                }
                return facturas;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ProductosDeVentas(List<FacturaVenta> facturas)
        {
            try
            {
                var tProductos = this.miDaoProducto.CrearTabla();
                tProductos.Columns.Add(new DataColumn("numero", typeof(string)));
                tProductos.Columns.Add(new DataColumn("id", typeof(int)));
                tProductos.Columns.Add(new DataColumn("idfact", typeof(int)));
                tProductos.Columns.Add(new DataColumn("idmedida", typeof(int)));
                tProductos.Columns.Add(new DataColumn("idcolor", typeof(int)));
                tProductos.Columns.Add(new DataColumn("retorno", typeof(bool)));
                tProductos.Columns.Add(new DataColumn("v_real", typeof(double)));

                foreach (FacturaVenta f in facturas)
                {
                    foreach (DataRow pRow in this.miDaoProducto.ProductoFacturaVenta(f.Id).Rows)
                    {
                        var miProw = tProductos.NewRow();
                        miProw["id"] = pRow["Id"];
                        miProw["numero"] = pRow["Numero"];
                        miProw["Codigo"] = pRow["Codigo"];
                        miProw["Cantidad"] = pRow["Cantidad"];
                        miProw["Valor"] = pRow["Valor"];
                        miProw["idmedid"] = pRow["IdMedida"];
                        miProw["idcolor"] = pRow["IdColor"];
                        miProw["Descuento"] = pRow["Descuento"];
                        miProw["Descto"] = pRow["Recargo"];
                        miProw["Iva"] = pRow["Iva"];
                        miProw["retorno"] = pRow["retorno"];
                        miProw["Valor_"] = pRow["valor"];
                        miProw["Sub_Total"] = pRow["costo"];
                        miProw["idfact"] = pRow["id_factura"];
                        miProw["v_real"] = pRow["valor_venta_real"];
                        miProw["Ico"] = pRow["impoconsumo"];
                        tProductos.Rows.Add(miProw);
                    }
                }
                return tProductos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable FormasDePago(List<FacturaVenta> facturas)
        {
            try
            {
                var miDaoPago = new DaoFormaPago();
                var tPagos = new DataTable();
                tPagos.Columns.Add(new DataColumn("id", typeof(int)));
                tPagos.Columns.Add(new DataColumn("numero", typeof(string)));
                tPagos.Columns.Add(new DataColumn("iduser", typeof(int)));
                tPagos.Columns.Add(new DataColumn("idcaja", typeof(int)));
                tPagos.Columns.Add(new DataColumn("idforma", typeof(int)));
                tPagos.Columns.Add(new DataColumn("fecha", typeof(DateTime)));
                tPagos.Columns.Add(new DataColumn("hora", typeof(DateTime)));
                tPagos.Columns.Add(new DataColumn("valor_f", typeof(int)));
                tPagos.Columns.Add(new DataColumn("idturno", typeof(int)));
                tPagos.Columns.Add(new DataColumn("valor_p", typeof(int)));
                tPagos.Columns.Add(new DataColumn("id_factura", typeof(int)));

                var pagos = new List<FormaPago>();

                foreach (FacturaVenta f in facturas)
                {
                    foreach (DataRow fPagos in miDaoPago.FormasDePagoDeFacturaVentaId(f.Id).Rows)
                    {
                        var pRow = tPagos.NewRow();
                        pRow["id"] = fPagos["Id"];
                        pRow["numero"] = fPagos["Factura"];
                        pRow["iduser"] = fPagos["IdUsuario"];
                        pRow["idcaja"] = fPagos["Caja"];
                        pRow["idforma"] = fPagos["IdFormaPago"];
                        pRow["fecha"] = fPagos["Fecha"];
                        pRow["hora"] = fPagos["Hora"];
                        pRow["valor_f"] = fPagos["Valor"];
                        pRow["idturno"] = fPagos["IdTurno"];
                        pRow["valor_p"] = fPagos["Pago"];
                        pRow["id_factura"] = fPagos["id_factura"];
                        tPagos.Rows.Add(pRow);
                    }
                   // var tFormasPagos = miDaoPago.FormasDePagoDeFacturaVentaId(f.Id);
                }
                return tPagos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public DataTable FacturasDeCarteraNew()
        {
            return this.miDaoFacturaVenta.FacturasDeCartera();
        }

        public DataTable ProductosFacturasDeCartera()
        {
            return this.miDaoFacturaVenta.ProductosFacturasDeCartera();
        }

        public DataTable PagosFacturasDeCartera()
        {
            return this.miDaoFacturaVenta.PagosFacturasDeCartera();
        }



        public void AjustarCartera(DataTable cartera)
        {
            this.miDaoFacturaVenta.AjustarCartera(cartera);
        }


    }
}