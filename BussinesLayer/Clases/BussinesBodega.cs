using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer.Clases;
using DTO.Clases;
using System.Collections;

namespace BussinesLayer.Clases
{
    public class BussinesBodega
    {

        private DaoBodega miDaoBodega = new DaoBodega();

        /// <summary>
        /// Inserto bodega a la base de datos
        /// </summary>
        /// <param name="miBodega"></param>
        public void InsertarBodega(Bodega miBodega)
        {
            miDaoBodega.InsertarBodega(miBodega);        
        }
       
        /// <summary>
        /// Listo bodega de la base de datos.
        /// </summary>
        /// <returns></returns>
        public ArrayList ListarBodegas()
        {
           return miDaoBodega.ListarBodegas();
        
        }

        /// <summary>
        /// LIsta bodegas por Nombre.
        /// </summary>
        /// <param name="nombrebodega"></param>
        /// <returns></returns>
        public ArrayList ListarBodegasNombre(string nombrebodega)
        {
            
            return miDaoBodega.ListarBodegasNombre(nombrebodega);
        }

        /// <summary>
        /// Edita bodega
        /// </summary>
        /// <param name="mibodega"></param>
        public void EditarBodega(Bodega mibodega)
        {
           miDaoBodega.EditarBodega(mibodega);

        }
        /// 
        /// <summary>
        /// Elimino bodega
        /// </summary>
        /// <param name="idbodega"></param>
        public void EliminarBodega(int idbodega)
        {
            miDaoBodega.EliminarBodega(idbodega);
        }

        /// <summary>
        /// Existe bodega
        /// </summary>
        /// <param name="nombre">parametro enviado</param>
        /// <returns>true false</returns>
        public bool ExiteBodega(string nombre)
        {
            return miDaoBodega.ExisteBodega(nombre);
        }

        /// <summary>
        /// Existe ubicacion Bodega
        /// </summary>
        /// <param name="Ubicacion">Parametro enviado</param>
        /// <returns>true false</returns>
        public bool ExisteUbicacion(string Ubicacion)
        {
            return miDaoBodega.ExisteUbicacion(Ubicacion);
        }
             
    }
}
