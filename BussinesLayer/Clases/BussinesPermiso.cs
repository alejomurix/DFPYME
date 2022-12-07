using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer.Clases;
using System.Data;
using DTO.Clases;

namespace BussinesLayer.Clases
{
   public  class BussinesPermiso
    {
       /// <summary>
       /// Representa un obleto de transacción de base de datos.
       /// </summary>
       private DaoPermiso miDaoPermiso;      

       public BussinesPermiso()
       {
         this.miDaoPermiso = new DaoPermiso();
       }

       /// <summary>
       /// Inserta la relacion de los usuarios con respecto  alos permisos asignados
       /// en el sistema.
       /// </summary>
       /// <param name="idPermiso">id del permiso a ingresar</param>
       /// <param name="idUsuario">id usuario a ingresar</param>
       public void InsertaPermisoUsuario(int idPermiso, int idUsuario)
       {
           miDaoPermiso.InsertaPermiso(idPermiso, idUsuario);
       }

       public List<Permiso> Permisos(int idUsuario)
       {
           return this.miDaoPermiso.Permisos(idUsuario);
       }

       public void EliminarPermisos(int idUsuario)
       {
           this.miDaoPermiso.EliminarPermisos(idUsuario);
       }



       /// <summary>
       /// Lista los permisos del usuario.
       /// </summary>
       public DataTable ListarPermiso()
       {
           return miDaoPermiso.ListarPermisosUsuario();
       }

       /// <summary>
       /// Lista los permisos de cada usuario.
       /// </summary>
       /// <param name="idUsuario">id usuario a consultar los permisos</param>
       /// <returns></returns>
       public DataTable ListarPermisosUsuario(int idUsuario)
       {
           return miDaoPermiso.ListarpermisoUsuario(idUsuario);
       }

    }
}