using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer.Clases;
using DTO.Clases;
using System.Data;

namespace BussinesLayer.Clases
{
    public class BussinesDian
    {
        /// <summary>
        /// Objeto de transacción de base de datos dian.
        /// </summary>
        private DaoDian miDaoDian;

        /// <summary>
        /// Inicializa una nueva instancia de la clase BussinesDian.
        /// </summary>
        public BussinesDian()
        {
            this.miDaoDian = new DaoDian();
        }

        /// <summary>
        /// Ingresa los datos del Registro de la Dian en base de datos.
        /// </summary>
        /// <param name="dian">Registro de la Dian a Ingresar.</param>
        /// <param name="contado">Establece el valor que indica si el registro es para Facturas de contado.</param>
        public void InsetarDian(Dian dian, bool contado)
        {
            miDaoDian.InsertaDian(dian, contado);
        }

        /// <summary>
        /// Consulta registros dian.
        /// </summary>
        /// <returns></returns>
        public DataTable ConsultaDian()
        {
            return miDaoDian.ConsultaDian();
        }

        public Dian ConsultaDian(int id)
        {
            return this.miDaoDian.ConsultaDian(id);
        }

        public DataRow DianRow()
        {
            var tDian = this.miDaoDian.ConsultaDian();
            int maxId = tDian.AsEnumerable().Max(m => m.Field<int>("id"));
            return tDian.AsEnumerable().Where(d => d.Field<int>("id").Equals(maxId)).Last();
        }

        /// <summary>
        /// Obtiene los datos del Registro de la Dian para las Facturas de Crédito.
        /// </summary>
        /// <returns></returns>
        public DataTable ConsultaDianCredito()
        {
            return miDaoDian.ConsultaDianCredito();
        }

        /// <summary>
        /// Obtiene los datos del registro de la DIAN para su impresión.
        /// </summary>
        /// <param name="contado">Indica si la factura emitida es de contado o no (crédito).</param>
        /// <returns></returns>
        public DataSet Print(bool contado)
        {
            return miDaoDian.Print(contado);
        }

        public DataSet PrintVoid()
        {
            var dsDian = new DataSet();
            var dt = new DataTable();
            dt.TableName = "TDian";
            dt.Columns.Add(new DataColumn("print_dian", typeof(string)));
            var row = dt.NewRow();
            row["print_dian"] = " ";
            dt.Rows.Add(row);
            dsDian.Tables.Add(dt);
            return dsDian;
        }

        public void EditarTextos(string textoInicial, string textoFinal)
        {
            this.miDaoDian.EditarTextos(textoInicial, textoFinal);
        }

        public bool FacturacionActiva(string nameRegDian, string nameFactura)
        {
            return this.miDaoDian.FacturacionActiva(nameRegDian, nameFactura);
        }

        public Int64 NumeracionRestante(string nameRegDian, string nameFactura)
        {
            return this.miDaoDian.NumeracionRestante(nameRegDian, nameFactura);
        }


        public void ActualizarIdDian()
        {
            this.miDaoDian.ActualizarIdDian();
        }

        public List<Dian> RegistrosDianVentas(int idCaja, DateTime fecha)
        {
            return this.miDaoDian.RegistrosDianVentas(idCaja, fecha);
        }

        public List<Dian> RegistrosDianVentas(DateTime fecha)
        {
            return this.miDaoDian.RegistrosDianVentas(fecha);
        }
    }
}