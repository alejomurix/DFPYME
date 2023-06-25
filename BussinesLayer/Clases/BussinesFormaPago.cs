using System;
using System.Data;
using System.Linq;
using DataAccessLayer.Clases;
using DTO.Clases;
using System.Collections.Generic;

namespace BussinesLayer.Clases
{
    public class BussinesFormaPago
    {
        private DaoFormaPago miDaoFromaPago;

        public BussinesFormaPago()
        {
            miDaoFromaPago = new DaoFormaPago();
        }

        #region Forma de Pago

        public void InsertarFormaPago(FormaPago formaPago)
        {
            miDaoFromaPago.InsertarFormaPago(formaPago);
        }

        public DataTable ListarFormaPago()
        {
            return miDaoFromaPago.ListaFormaPago();
        }

        public DataTable FormasDePagoHabiles()
        {
            return miDaoFromaPago.FormasDePagoHabiles();
        }

        public void ModificarformaPago(FormaPago formapago)
        {
            miDaoFromaPago.ModificaFormaPago(formapago);
        }

        public void HabilitaFormaPago(FormaPago pago)
        {
            miDaoFromaPago.HabilitaFormaPago(pago);
        }

        public void EliminaFormaPago(int id)
        {
            miDaoFromaPago.EliminaFormaPago(id);
        }

        #endregion


        /// <summary>
        /// Existe forma de pago
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        public bool ExisteFormaPago(string nombre)
        {
            return miDaoFromaPago.ExisteFormaPago(nombre);
        }

        public int IngresarPagoAFactura(FormaPago pago, bool venta, bool pos)
        {
            return miDaoFromaPago.IngresarPagoAFactura(pago, venta, pos);
            //return miDaoFromaPago.IngresarPagoAFactura(pago, venta, pos);
        }

        /// <summary>
        /// Ingresa los datos del pago o abono realizado a un proveedor.
        /// </summary>
        /// <param name="pago">Pago a realizar.</param>
        public int IngresaPagoAProveedor(FormaPago pago, bool esFactura)
        {
            return miDaoFromaPago.IngresaPagoAProveedor(pago, esFactura);
        }

        // Funciones relacion egreso_pago
        public void IngresarEgresoPago(int idEgreso, int idPago)
        {
            miDaoFromaPago.IngresarEgresoPago(idEgreso, idPago);
        }

        public DataTable EgresosPagos(int idEgreso)
        {
            return miDaoFromaPago.EgresosPagos(idEgreso);
        }

        public void EliminarEgresoPagos(int idEgreso)
        {
            miDaoFromaPago.EliminarEgresoPagos(idEgreso);
        }

        //**********************************************************

        /// <summary>
        /// Obtiene el listado de las formas de pago de una Factura de Venta.
        /// </summary>
        /// <param name="numero">Número de la factura de venta.</param>
        /// <returns></returns>
        public DataTable FormasDePagoDeFacturaVenta(string numero)
        {
            return miDaoFromaPago.FormasDePagoDeFacturaVenta(numero);
        }

        public DataTable FormasDePagoDeFacturaVentaId(int idFactura)
        {
            return this.miDaoFromaPago.FormasDePagoDeFacturaVentaId(idFactura);
        }

        /// <summary>
        /// Obtiene el valor total de los pagos a una Factura de Venta.
        /// </summary>
        /// <param name="numero">Número de la factura de venta.</param>
        /// <returns></returns>
        public int GetTotalFormasDePagoDeFacturaVenta(string numero)
        {
            var tabla = miDaoFromaPago.FormasDePagoDeFacturaVenta(numero);
            var total = 0;
            foreach (DataRow row in tabla.Rows)
            {
                total = total + Convert.ToInt32(row["Pago"]);
            }
            return total;
        }

        public int GetTotalPagoDeFacturaVenta(string numero)
        {
            var tabla = miDaoFromaPago.FormasDePagoDeFacturaVenta(numero);
            var total = 0;
            foreach (DataRow row in tabla.Rows)
            {
                total = total + Convert.ToInt32(row["Valor"]);
            }
            return total;
        }

        public int GetTotalPagoDeFacturaVentaId(int idFactura)
        {
            var tabla = miDaoFromaPago.FormasDePagoDeFacturaVentaId(idFactura);
            var total = 0;
            foreach (DataRow row in tabla.Rows)
            {
                total = total + Convert.ToInt32(row["Valor"]);
                //total = total + Convert.ToInt32(row["Pago"]);
            }
            return total;
        }

        public int IngresarPagoRemision(FormaPago fPago)
        {
            return miDaoFromaPago.IngresarPagoRemision(fPago);
        }

        public void IngresarPagoRemision(Cliente cliente, FormaPago pago)
        {
            var daoRemision = new DaoRemision();

            int monto = Convert.ToInt32(pago.Valor);
            foreach (var sale in cliente.Sales)
            {
                if (monto > 0)
                {
                    pago.IdFactura = sale.Id;
                    pago.NumeroFactura = sale.Numero;
                    pago.NombreFormaPago += sale.Numero + ", ";
                    if (monto > sale.Saldo)
                    {
                        pago.Valor = pago.Pago = sale.Saldo;
                        sale.Pagos += sale.Saldo;

                        monto -= sale.Saldo;
                    }
                    else
                    {
                        pago.Valor = pago.Pago = monto;
                        sale.Pagos += monto;

                        monto -= monto;
                    }
                    sale.Saldo = Convert.ToInt32(sale.Total) - sale.Pagos;
                    miDaoFromaPago.IngresarPagoRemision(pago);
                    if (sale.Total.Equals(sale.Pagos))
                    {
                        sale.Cancel = true;
                        daoRemision.UpdateCancel(sale);
                    }
                }
                else
                {
                    break;
                }
            }
        }

        public int GetTotalPagoRemision(int numero)
        {
            var tabla = miDaoFromaPago.FormasDePagoRemision(numero);
            var total = 0;
            if (tabla.Rows.Count != 0)
            {
                total = tabla.AsEnumerable().Sum(s => s.Field<int>("valor"));
            }
            return total;
        }

        public DataTable PagosARemisionVentaId(int numeroRemision)
        {
            return miDaoFromaPago.PagosARemisionVentaId(numeroRemision);
        }



        public DataTable TablaPagosAProveedor(int idFactura)
        {
            return miDaoFromaPago.PagosAProveedor(idFactura);
        }

        /// <summary>
        /// Obtiene el valor total de los pagos o abono realizados a una factura de Proveedor.
        /// </summary>
        /// <param name="idFactura">Id de la factura a consultar pagos.</param>
        /// <returns></returns>
        public int PagosAProveedor(int idFactura)
        {
            var tabla = miDaoFromaPago.PagosAProveedor(idFactura);
            var total = 0;
            foreach (DataRow row in tabla.Rows)
            {
                total = total + Convert.ToInt32(row["valorpago_factura_proveedor"]);
            }
            return total;
        }

        public DataTable PagosFacturaProveedor(int idFactura)
        {
            return this.miDaoFromaPago.PagosFacturaProveedor(idFactura);
        }

        public void EditarPagoDeCompra(int id, int valor)
        {
            miDaoFromaPago.EditarPagoDeCompra(id, valor);
        }

        public void EliminarPagoDeCompra(int id)
        {
            miDaoFromaPago.EliminarPagoDeCompra(id);
        }

        public DataTable ListFormas(List<FormaPago> formas)
        {
            var tabla = new DataTable();
            tabla.TableName = "Formas";
            tabla.Columns.Add(new DataColumn("Nombre", typeof(string)));
            tabla.Columns.Add(new DataColumn("Valor", typeof(int)));
            foreach (var forma in formas)
            {
                if (forma.Valor != 0)
                {
                    var row = tabla.NewRow();
                    row["Nombre"] = forma.NombreFormaPago;
                    row["Valor"] = forma.Valor;
                    tabla.Rows.Add(row);
                }
            }
            return tabla;
        }

        // Remision Proveedor
        public int TotalPagosRemisionProveedor(int idRemision)
        {
            var tabla = miDaoFromaPago.PagosRemisionProveedor(idRemision);
            var total = 0;
            foreach (DataRow row in tabla.Rows)
            {
                total += Convert.ToInt32(row["valor"]);
            }
            return total;
        }

        public void EditarValores(int id, int valor, int pago)
        {
            miDaoFromaPago.EditarValores(id, valor, pago);
        }

        // Pago a Egresos

        public void IngresarEgresoPago(FormaPago pago)
        {
            miDaoFromaPago.IngresarEgresoPago(pago);
        }

        public void EliminarEgresoPago(int id)
        {
            miDaoFromaPago.EliminarEgresoPago(id);
        }
    }
}