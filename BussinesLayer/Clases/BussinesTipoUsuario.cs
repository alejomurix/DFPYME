using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO.Clases;
using DataAccessLayer.Clases;
using System.Data;
using DTO.Clases;

namespace BussinesLayer.Clases
{
   public class BussinesTipoUsuario
    {
        /// <summary>
        /// Objeto de transacción de datos a base de datos.
        /// </summary>
        private DaoTipoUsuario miDaoTipoUsuario;

        /// <summary>
        /// Inicializa una nueva instancia de bussines tipo usuario.
        /// </summary>
        public BussinesTipoUsuario()
        {
            this.miDaoTipoUsuario = new DaoTipoUsuario();
        }
       /// <summary>
       /// Inserta cargo a la base de datos.
       /// </summary>
       /// <param name="cargo"></param>
        public void InsertaCargo(TipoUsuario cargo)
        {
            miDaoTipoUsuario.Insertacargo(cargo);
        }

        /// <summary>
        /// Lista cargo dela base de datos.
        /// </summary>
        /// <returns></returns>
        public DataTable ListarCargo()
        {
            return miDaoTipoUsuario.ListarCargo();
        }

       /// <summary>
       /// Edita cargo
       /// </summary>
       /// <param name="cargo"></param>
        public void EditaCargo(TipoUsuario cargo)
        {
            miDaoTipoUsuario.EditraCargo(cargo);
        }

       /// <summary>
       /// Elimina cargo.
       /// </summary>
       /// <param name="idCargo">id del cargo a eliminar.</param>
        public void EliminarCargo(int idCargo)
        {
            miDaoTipoUsuario.EliminaCargo(idCargo);
        }

       /// <summary>
       /// Consulta si existe un cargo.
       /// </summary>
       /// <param name="cargo">cargo a consultar</param>
       /// <returns></returns>
        public bool ExisteCargo(string cargo)
        {
            return miDaoTipoUsuario.ExisteCargo(cargo);
        }
   }
}
