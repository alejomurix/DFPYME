using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO.Clases;
using System.Data;
using DataAccessLayer.Clases;

namespace BussinesLayer.Clases
{
  public  class BussinesTipoCuenta
    {
      //creo un objeto de tipo DaoTipoCuenta y lo inicializo 
      private DaoTipoCuenta miDaoTipoCuenta;
      //creo un metodo publico de tipo arrayList
      public DataTable listadoTipoCuenta()
      {
          miDaoTipoCuenta = new DaoTipoCuenta();
          //reterno tipoCunenta utilizando el array de listadoTipoCuenta
          return miDaoTipoCuenta.listadoTipoCuenta();
      }
    }
}
