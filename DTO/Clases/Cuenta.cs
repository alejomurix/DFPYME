using System;
using System.Collections.Generic;

namespace DTO.Clases
{
    /// <summary>
    /// Representa una clase para Cuenta
    /// </summary>
    public class Cuenta
    {
        /// <summary>
        /// Inicializa una nueva Instacia de la clase Cuenta.
        /// </summary>
        public Cuenta()
        {
            this.IdCuenta = 0;
            this.IdTipoCuenta = 0;
            this.TipoCuenta = "";
            this.CodigoInternoProveedor = 0;
            this.NitEmpresa= "" ;
            this.BancoCuenta = "";
            this.NumeroCuenta = "";
            this.TitularCuenta = "";
        }

        public int IdCuenta { set; get; }
        public int IdTipoCuenta { set; get; }
        public string TipoCuenta { set; get; }
        public int CodigoInternoProveedor { set; get; }
        public string NitEmpresa { set; get; }
        public string BancoCuenta { set; get; }
        public string NumeroCuenta { set; get; }
        public string TitularCuenta { set; get; }
    }
}