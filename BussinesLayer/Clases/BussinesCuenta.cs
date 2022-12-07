using System;
using System.Data;
using DTO.Clases;
using DataAccessLayer.Clases;

namespace BussinesLayer.Clases
{
    /// <summary>
    /// Representa una clase de logica de Negocio de una cuenta
    /// </summary>
    public class BussinesCuenta
    {
        /// <summary>
        /// Representa un objeto de tranzacion a base de datos.
        /// </summary>
        private DaoCuenta miDaoCuenta;

        /// <summary>
        /// Inicializa una nueva instancia de BussinesCuenta.
        /// </summary>
        public BussinesCuenta() { }

        /// <summary>
        /// Verifica si una cuenta existe en la base de datos
        /// </summary>
        /// <param name="cuenta">Numero de cuenta a verificar</param>
        /// <returns></returns>
        public bool ExisteCuenta(string cuenta)
        {
            miDaoCuenta = new DaoCuenta();
            return miDaoCuenta.ExisteCuenta(cuenta);
        }

        /// <summary>
        /// Ingresa una cuenta a la base de datos.
        /// </summary>
        /// <param name="cuenta">Cuenta a ingresar.</param>
        public void InsertarCuenta(Cuenta cuenta)
        {
            miDaoCuenta = new DaoCuenta();
            miDaoCuenta.InsertarCuenta(cuenta);
        }

        /// <summary>
        /// Elimina cuenta
        /// </summary>
        /// <param name="idCuenta">id cuenta a eliminar</param>
        public void EliminaCuenta(int idCuenta)
        {
            miDaoCuenta = new DaoCuenta();
            miDaoCuenta.EliminaCuenta(idCuenta);
        }

        /// <summary>
        /// Obtiene el listado de Cuenta en un DataTable.
        /// </summary>
        /// <returns></returns>
       /* public DataTable ListadoCuentas()
        {
            miDaoCuenta = new DaoCuenta();
            return miDaoCuenta.ListadoCuentas();
        }*/
    }
}