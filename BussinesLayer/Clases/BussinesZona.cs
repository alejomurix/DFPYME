using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer.Clases;
using DTO.Clases;
using System.Collections;
namespace BussinesLayer.Clases
{
    public class BussinesZona
    {
        DaoZona miDaoZona = new DaoZona();

        /// <summary>
        /// Inserto zona a la base de datos
        /// </summary>
        /// <param name="mizona"></param>
        public void InsertarZona(Zona mizona)
        {
            miDaoZona.InsertarZona(mizona);
        }

        /// <summary>
        /// Listar zona.
        /// </summary>
        /// <returns>lista zona</returns>
        public ArrayList ListaZonas()
        {
            return miDaoZona.ListarZonas();
        }

        /// <summary>
        /// Filtra zona por nombre
        /// </summary>
        /// <param name="Nombre">parametro emviado</param>
        /// <returns></returns>
        public ArrayList ListarZonaNombre(string Nombre)
        {
            return miDaoZona.ListarZonasNombre(Nombre);
        }

        /// <summary>
        /// lista capacidad de zona
        /// </summary>
        /// <param name="capacidad">parametro a enviar</param>
        /// <returns></returns>
        public DataTable ListaCapacidadZona(string capacidad)
        {
            return miDaoZona.ListaCapacidad(capacidad);
        }

        /// <summary>
        /// Edita zona
        /// </summary>
        /// <param name="mizona"></param>
        public void EditarZona(Zona mizona)
        {
            miDaoZona.EditarZona(mizona);

        }
       
        /// <summary>
        /// cargo zona a editar
        /// </summary>
        /// <param name="IdZona"></param>
        /// <returns></returns>
        public Zona ListarZonaCompletoIdZona(int IdZona)
        {
            return miDaoZona.ListarZonaCompletoIdZona(IdZona);
        }

        
        /// <summary>
        /// Elimina zona
        /// </summary>
        /// <param name="idzona">parametro enviado</param>
        public void EliminarZona(int idzona)

        {

            miDaoZona.EliminarZona(idzona);
        }

        /// <summary>
        /// lista los datos modificados
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ArrayList ListaZonas(int id)
        {
            return miDaoZona.ListarZonas(id);
        }
            
            
    }
}
