using System;
using System.Data;
using System.Linq;
using DataAccessLayer.Clases;
using DTO.Clases;
using System.Collections.Generic;

namespace BussinesLayer.Clases
{
    /// <summary>
    /// Representa una clase para la lógica de negocio de Egreso.
    /// </summary>
    public class BussinesEgreso
    {
        /// <summary>
        /// Objeto de transacción a Base de Datos de Egreso.
        /// </summary>
        private DaoEgreso miDaoEgreso;

        /// <summary>
        /// Inicializa una nueva instancia de la clase BussinesEgreso.
        /// </summary>
        public BussinesEgreso()
        {
            this.miDaoEgreso = new DaoEgreso();
        }

        public bool ValidarCuenta(int subCuenta, int cuenta)
        {
            return miDaoEgreso.ValidarCuenta(subCuenta, cuenta);
        }

        public bool ValidarCuenta(string subCuenta)
        {
            return miDaoEgreso.ValidarCuenta(subCuenta);
        }

        /// <summary>
        /// Ingresa el registro de un Egreso a la Base de Datos.
        /// </summary>
        /// <param name="egreso">Egreso a ingresar.</param>
        public int IngresarEgreso(Egreso egreso)
        {
            return miDaoEgreso.IngresarEgreso(egreso);
        }

        public void IngresarEgresoCompra(Egreso egreso)
        {
            this.miDaoEgreso.IngresarEgresoCompra(egreso);
        }

        public DataTable Listado(bool anulado, int rowBase, int rowMax)
        {
            return miDaoEgreso.Listado(anulado, rowBase, rowMax);
        }

        public long GetRowslistado(bool anulado)
        {
            return miDaoEgreso.GetRowslistado(anulado);
        }

        public DataTable Listado(string numero)
        {
            return miDaoEgreso.Listado(numero);
        }

        public DataTable Listado(DateTime fecha, bool anulado, int rowBase, int rowMax)
        {
            return miDaoEgreso.Listado(fecha, anulado, rowBase, rowMax);
        }

        public long GetRowslistado(DateTime fecha, bool anulado)
        {
            return miDaoEgreso.GetRowslistado(fecha, anulado);
        }

        public DataTable Listado
            (DateTime fecha, DateTime fecha1, bool anulado, int rowBase, int rowMax)
        {
            return miDaoEgreso.Listado(fecha, fecha1, anulado, rowBase, rowMax);
        }

        public long GetRowslistado(DateTime fecha, DateTime fecha1, bool anulado)
        {
            return miDaoEgreso.GetRowslistado(fecha, fecha1, anulado);
        }

        public DataTable Listado(int idBeneficio, int rowBase, int rowMax)
        {
            return miDaoEgreso.Listado(idBeneficio, rowBase, rowMax);
        }

        public long GetRowslistado(int idBeneficio)
        {
            return miDaoEgreso.GetRowslistado(idBeneficio);
        }
        //
        public DataTable Listado(int idBeneficio, DateTime fecha, int rowBase, int rowMax)
        {
            return miDaoEgreso.Listado(idBeneficio, fecha, rowBase, rowMax);
        }

        public long GetRowslistado(int idBeneficio, DateTime fecha)
        {
            return miDaoEgreso.GetRowslistado(idBeneficio, fecha);
        }

        public DataTable Listado
            (int idBeneficio, DateTime fecha, DateTime fecha2, int rowBase, int rowMax)
        {
            return miDaoEgreso.Listado(idBeneficio, fecha, fecha2, rowBase, rowMax);
        }

        public long GetRowslistado(int idBeneficio, DateTime fecha, DateTime fecha2)
        {
            return miDaoEgreso.GetRowslistado(idBeneficio, fecha, fecha2);
        }



        public DataTable Listado(string numero, DateTime fecha)
        {
            return miDaoEgreso.Listado(numero, fecha);
        }

        /*public DataSet Listado(DateTime fecha)
        {
            return miDaoEgreso.Listado(fecha);
        }*/

        public DataTable Listado(int idCaja, DateTime fecha)
        {
            return miDaoEgreso.Listado(idCaja, fecha);
        }

        public DataTable Listado(DateTime fecha)
        {
            return miDaoEgreso.Listado(fecha);
        }

        /*public DataTable EgresoId(int id)
        {
            return miDaoEgreso.EgresoId(id);
        }*/

        public Egreso EgresoNumero(string numero)
        {
            return miDaoEgreso.EgresoNumero(numero);
        }

        public DataTable Cuentas(int idEgreso)
        {
            var tabla = new DataTable();
            tabla.TableName = "CuentaPuc";
            tabla.Columns.Add(new DataColumn("Codigo", typeof(int)));
            tabla.Columns.Add(new DataColumn("Concepto", typeof(string)));
            tabla.Columns.Add(new DataColumn("Valor", typeof(int)));
            
            var t = EgresoPuc(idEgreso);
            foreach (DataRow row in t.Rows)
            {
                var row_ = tabla.NewRow();
                row_["Codigo"] = row["codigo"];
                row_["Concepto"] = row["concepto"];
                row_["Valor"] = row["valor"];
                tabla.Rows.Add(row_);
            }
            return tabla;
        }

        public DataTable EgresoPuc(int idEgreso)
        {
            return miDaoEgreso.EgresoPuc(idEgreso);
        }

        public DataTable EgresoPuc(int idEgreso, int idCuenta)
        {
            return miDaoEgreso.EgresoPuc(idEgreso, idCuenta);
        }

        public List<FormaPago> PagosEgreso(int idEgreso)
        {
            return miDaoEgreso.PagosEgreso(idEgreso);
        }

        public void EditarEgreso(Egreso egreso)
        {
            miDaoEgreso.EditarEgreso(egreso);
        }

        public void AnularEgreso(int idEgreso)
        {
            miDaoEgreso.AnularEgreso(idEgreso);
        }

        public void EliminarEgreso(int id)
        {
            miDaoEgreso.EliminarEgreso(id);
        }

        // Metodos para Informe de Egresos.
        public DataTable Egresos(int idCuenta, string numero)
        {
            return miDaoEgreso.Egresos(idCuenta, numero);
        }

        public DataTable Egresos(int idCuenta, DateTime fecha)
        {
            return miDaoEgreso.Egresos(idCuenta, fecha);
        }

        public DataTable Egresos(int idCuenta, DateTime fecha, DateTime fecha2)
        {
            return miDaoEgreso.Egresos(idCuenta, fecha, fecha2);
        }

        public DataTable Egresos(int idCuenta, int idTercero)
        {
            return miDaoEgreso.Egresos(idCuenta, idTercero);
        }

        public DataTable Egresos(int idCuenta, int idTercero, DateTime fecha)
        {
            return miDaoEgreso.Egresos(idCuenta, idTercero, fecha);
        }
        
        public DataTable Egresos
            (int idCuenta, int idTercero, DateTime fecha, DateTime fecha2)
        {
            return miDaoEgreso.Egresos(idCuenta, idTercero, fecha, fecha2);
        }

        // Egreso Remision de Proveedor

        public void IngresarEgresoRemision(Egreso egreso)
        {
            miDaoEgreso.IngresarEgresoRemision(egreso);
        }

        // End Egreso Remisino de ProveedorEgreso Remision de Proveedor

        //Retiro

        /// <summary>
        /// Ingresa el registro de un Retiro a la Base de Datos.
        /// </summary>
        /// <param name="retiro">Retiro a ingresar.</param>
        /*public void IngresarRetiro(Egreso retiro)
        {
            miDaoEgreso.IngresarRetiro(retiro);
        }*/

        //Arqueo

        /// <summary>
        /// Ingresa el registro de un Arqueo a la Base de Datos.
        /// </summary>
        /// <param name="arqueo">Arqueo a ingresar.</param>
        public void IngresarArqueo(Arqueo arqueo)
        {
            miDaoEgreso.IngresarArqueo(arqueo);
        }

        /// <summary>
        /// Obtiene la suma total de los arqueos realizados en una fecha segun la caja.
        /// </summary>
        /// <param name="idCaja">Id de la caja a consultar.</param>
        /// <param name="fecha">Fecha a consultar.</param>
        /// <returns></returns>
        public int TotalArqueo(int idCaja, DateTime fecha)
        {
            var tabla = miDaoEgreso.Arqueos(idCaja, fecha);
            if (tabla.Rows.Count != 0)
            {
                return tabla.AsEnumerable().Sum(s => s.Field<int>("efectivo") +
                                                     s.Field<int>("cheque") +
                                                     s.Field<int>("tarjeta"));
            }
            else
            {
                return 0;
            }
        }
    }
}