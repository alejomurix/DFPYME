using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer.Clases;
using DTO.Clases;

namespace BussinesLayer.Clases
{
    public class BussinesTrasladoInventario
    {
        private DaoTrasladoInventario miDaoTraslado;

        public BussinesTrasladoInventario()
        {
            miDaoTraslado = new DaoTrasladoInventario();
        }

        public BussinesTrasladoInventario(string ipServer)
        {
            miDaoTraslado = new DaoTrasladoInventario(ipServer);
        }

        public bool TestearConexion(string ipServer)
        {
            return miDaoTraslado.TestearConexion(ipServer);
        }

        public void IngresarTraslado(TrasladoInventario traslado, bool salida)
        {
            miDaoTraslado.IngresarTraslado(traslado, salida);
        }

        public string SincronizarPrecio()
        {
            return miDaoTraslado.SincronizarPrecio();
        }
    }
}