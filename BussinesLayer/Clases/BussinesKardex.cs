using System;
using System.Data;
using DTO.Clases;
using DataAccessLayer.Clases;

namespace BussinesLayer.Clases
{
    public class BussinesKardex
    {
        private DaoKardex miDaoKardex;

        public BussinesKardex()
        {
            this.miDaoKardex = new DaoKardex();
        }

        public void Insertar(Kardex kardex)
        {
            miDaoKardex.Insertar(kardex);
        }


        //consulta por fecha y codigo

        public DataTable Kardex
            (DateTime fecha, string codigo, int rowIndex, int rowMax)
        {
            return miDaoKardex.Kardex(fecha, codigo, rowIndex, rowMax);
        }//*

        public long GetsRowsKardex(DateTime fecha, string codigo)
        {
            return miDaoKardex.GetsRowsKardex(fecha, codigo);
        }

        //consulta por operacion, fecha y codigo

        public DataTable Kardex
            (int idOperacion, DateTime fecha, string codigo, int rowIndex, int rowMax)
        {
            return miDaoKardex.Kardex(idOperacion, fecha, codigo, rowIndex, rowMax);
        }

        public long GetsRowsKardex(int idOperacion, DateTime fecha, string codigo)
        {
            return miDaoKardex.GetsRowsKardex(idOperacion, fecha, codigo);
        }

        //consulta por periodo y codigo

        public DataTable Kardex
            (DateTime fecha, DateTime fecha2, string codigo, int rowIndex, int rowMax)
        {
            return miDaoKardex.Kardex(fecha, fecha2, codigo, rowIndex, rowMax);
        }

        public long GetsRowsKardex(DateTime fecha, DateTime fecha2, string codigo)
        {
            return miDaoKardex.GetsRowsKardex(fecha, fecha2, codigo);
        }

        //consulta por operacion, periodo y codigo

        public DataTable Kardex
            (int idOperacion, DateTime fecha, DateTime fecha2, 
                        string codigo, int rowIndex, int rowMax)
        {
            return miDaoKardex.Kardex(
                idOperacion, fecha, fecha2, codigo, rowIndex, rowMax);
        }

        public long GetsRowsKardex
            (int idOperacion, DateTime fecha, DateTime fecha2, string codigo)
        {
            return miDaoKardex.GetsRowsKardex(idOperacion, fecha, fecha2, codigo);
        }

        public DataTable Resumen(int idOperacion, DateTime fecha, string codigo)
        {
            return miDaoKardex.Resumen(idOperacion, fecha, codigo);
        }

        public DataTable Resumen(int idOperacion, DateTime fecha, DateTime fecha2, string codigo)
        {
            return miDaoKardex.Resumen(idOperacion, fecha, fecha2, codigo);
        }

        // Consultas de impresion
        public DataTable Kardex(DateTime fecha, string codigo)
        {
            return this.miDaoKardex.Kardex(fecha, codigo);
        }

        public DataTable Kardex(int idOperacion, DateTime fecha, string codigo)
        {
            return this.miDaoKardex.Kardex(idOperacion, fecha, codigo);
        }

        public DataTable Kardex(DateTime fecha, DateTime fecha2, string codigo)
        {
            return this.miDaoKardex.Kardex(fecha, fecha2, codigo);
        }

        public DataTable Kardex(int idOperacion, DateTime fecha, DateTime fecha2, string codigo)
        {
            return this.miDaoKardex.Kardex(idOperacion, fecha, fecha2, codigo);
        }


        public DataTable ConstruccionInventario(DateTime fecha, DateTime fecha2)
        {
            return this.miDaoKardex.ConstruccionInventario(fecha, fecha2);
        }

        public DataTable ConstruccionInventarioProducto(string codigo, DateTime fecha, DateTime fecha2)
        {
            return this.miDaoKardex.ConstruccionInventarioProducto(codigo, fecha, fecha2);
        }

        public DataTable ConstruccionInventarioCategoria(string codigoC, DateTime fecha, DateTime fecha2)
        {
            return this.miDaoKardex.ConstruccionInventarioCategoria(codigoC, fecha, fecha2);
        }
    }
}