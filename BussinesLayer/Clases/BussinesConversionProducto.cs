using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO.Clases;
using DataAccessLayer.Clases;

namespace BussinesLayer.Clases
{
    public  class BussinesConversionProducto
    {
        private DaoConversionProducto miDaoConversion;

        public BussinesConversionProducto()
        {
            this.miDaoConversion = new DaoConversionProducto();
        }

        public bool ExisteConversion(string codigo)
        {
            return this.miDaoConversion.ExisteConversion(codigo);
        }

        public void IngresarConversion(Conversion conversion)
        {
            this.miDaoConversion.IngresarConversion(conversion);
        }

        public void IngresarDetalleConversion(DetalleConversion detalle)
        {
            this.miDaoConversion.IngresarDetalleConversion(detalle);
        }

        public Conversion Conversion(string codigo)
        {
            return this.miDaoConversion.Conversion(codigo);
        }

        public DataTable Conversiones()
        {
            return this.miDaoConversion.Conversiones();
        }

        public DataTable Conversiones(string codigo)
        {
            return this.miDaoConversion.Conversiones(codigo);
        }

        public DataTable DetallesConversion(int idConversion)
        {
            return this.miDaoConversion.DetallesConversion(idConversion);
        }


        public DataTable DetalleConversion(string productoConversion)
        {
            return this.miDaoConversion.DetalleConversion(productoConversion);
        }


        public DataTable ConversionDetalle(string productoDetalle)
        {
            return this.miDaoConversion.ConversionDetalle(productoDetalle);
        }



        public void EliminarConversion(int id)
        {
            this.miDaoConversion.EliminarConversion(id);
        }

        public void EliminarDetalle(int id)
        {
            this.miDaoConversion.EliminarDetalle(id);
        }



        /// codigo para la programacion de productos fabricados (recetas.)

        public void InsertarProductoFabricado(string prodFabricado, string prodProceso, double cantidad)
        {
            miDaoConversion.InsertarProductoFabricado(prodFabricado, prodProceso, cantidad);
        }

        public DataTable ProductosFabricados(int idTipoInventario)
        {
            return miDaoConversion.ProductosFabricados(idTipoInventario);
        }

        public DataTable ProductosReceta(string codigo)
        {
            return miDaoConversion.ProductosReceta(codigo);
        }

        public void EliminarProductoReceta(int id)
        {
            miDaoConversion.EliminarProductoReceta(id);
        }
    }
}