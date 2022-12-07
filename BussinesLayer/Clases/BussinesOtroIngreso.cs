using System;
using System.Data;
using DTO.Clases;
using DataAccessLayer.Clases;

namespace BussinesLayer.Clases
{
    public class BussinesOtroIngreso
    {
        private DaoOtroIngreso miDaoOtroIngreso;

        public BussinesOtroIngreso()
        {
            this.miDaoOtroIngreso = new DaoOtroIngreso();
        }

        // Otro Ingreso

        public int AlmacenarIngreso(OtroIngreso ingreso)
        {
            return miDaoOtroIngreso.AlmacenarIngreso(ingreso);
        }

        public OtroIngreso Ingreso(string numero)
        {
            return miDaoOtroIngreso.Ingreso(numero);
        }

        public DataTable Ingresos(int rowBase, int rowMax)
        {
            return miDaoOtroIngreso.Ingresos(rowBase, rowMax);
        }

        public long GetRowsIngresos()
        {
            return miDaoOtroIngreso.GetRowsIngresos();
        }

        public DataTable Ingresos(string numero)
        {
            return miDaoOtroIngreso.Ingresos(numero);
        }

        public DataTable Ingresos(DateTime fecha, int rowBase, int rowMax)
        {
            return miDaoOtroIngreso.Ingresos(fecha, rowBase, rowMax);
        }

        public long GetRowsIngresos(DateTime fecha)
        {
            return miDaoOtroIngreso.GetRowsIngresos(fecha);
        }

        public DataTable Ingresos(DateTime fecha, DateTime fecha2, int rowBase, int rowMax)
        {
            return miDaoOtroIngreso.Ingresos(fecha, fecha2, rowBase, rowMax);
        }

        public long GetRowsIngresos(DateTime fecha, DateTime fecha2)
        {
            return miDaoOtroIngreso.GetRowsIngresos(fecha, fecha2);
        }

        public void AnularIngreso(int idIngreso)
        {
            miDaoOtroIngreso.AnularIngreso(idIngreso);
        }

        // Concepto Otro Ingreso

        public int MaxCodigo()
        {
            return this.miDaoOtroIngreso.MaxCodigo();
        }

        public void AlmacenarConcepto(ConceptoOtroIngreso concepto)
        {
            miDaoOtroIngreso.AlmacenarConcepto(concepto);
        }

        public ConceptoOtroIngreso Concepto(int codigo)
        {
            return miDaoOtroIngreso.Concepto(codigo);
        }

        public DataTable Conceptos(int codigo)
        {
            return miDaoOtroIngreso.Conceptos(codigo);
        }

        public DataTable Conceptos(string nombre)
        {
            return miDaoOtroIngreso.Conceptos(nombre);
        }

        // Forma de pago de otro ingreso.

        public DataTable FormasDePago(int idIngreso)
        {
            return miDaoOtroIngreso.FormasDePago(idIngreso);
        }

        // Concepto Ingreso (relacion)

        public DataTable ConceptosDeIngreso(int id)
        {
            return miDaoOtroIngreso.ConceptosDeIngreso(id);
        }
    }
}