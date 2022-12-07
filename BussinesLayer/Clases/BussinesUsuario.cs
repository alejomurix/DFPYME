using System;
using System.Linq;
using System.Data;
using DataAccessLayer.Clases;
using DTO.Clases;
using System.Collections.Generic;

namespace BussinesLayer.Clases
{
    /// <summary>
    /// Representa una clase para la logica de Usuario.
    /// </summary>
    public class BussinesUsuario
    {
        /// <summary>
        /// Representa el objeto para tranzaccion a base de datos.
        /// </summary>
        private DaoUsuario miDaoUsuario;

        /// <summary>
        /// Inicializa una instancia de BussinesUsuario.
        /// </summary>
        public BussinesUsuario()
        {
            this.miDaoUsuario = new DaoUsuario();
        }

        /// <summary>
        /// Inserta usuario a la base de datos.
        /// </summary>
        /// <param name="usuario"></param>
        public void InsertarUsuario(Usuario usuario)
        {
            miDaoUsuario.InsertarUsuarioSistema(usuario);
        }

        public Usuario Usuario_(Usuario u)
        {
            return this.miDaoUsuario.Usuario_(u);
        }

        public Usuario Usuario_(int documento)
        {
            return this.miDaoUsuario.Usuario_(documento);
        }

        public bool VerificarUsuario(string usuario_, string password, int idPermiso)
        {
            return this.miDaoUsuario.VerificarUsuario(usuario_, password, idPermiso);
        }

        public DataTable Usuarios()
        {
            return this.miDaoUsuario.Usuarios();
        }

        public void EditaUsuario(Usuario usuario)
        {
            miDaoUsuario.EditaUsuario(usuario);
        }




        /// <summary>
        /// Elimina el usuario del sistema.
        /// </summary>
        /// <param name="idUsuario">id del usuario a eliminar</param>
        public void EliminaUsuario(int idUsuario)
        {
            miDaoUsuario.EliminaUsuario(idUsuario);
        }

        public DataTable ConsultaUsuario(int id)
        {
            return miDaoUsuario.ConsultaUsuario(id);
        }

        /// <summary>
        /// Consultar usuario por documento.
        /// </summary>
        /// <param name="documento">documentodel usuario a consultar</param>
        /// <returns></returns>
        public DataTable ConsultarUsuarioDocumento(int documento)
        {
            return miDaoUsuario.ConsultaUsuarioDocumento(documento);
        }

        /// <summary>
        /// Consulta usuario nombre que sea igual.
        /// </summary>
        /// <param name="nombre">nombre del usulario a consultar</param>
        /// <returns></returns>
        public DataTable ConsultarUsuarioNombreIgual(string nombre)
        {
            return miDaoUsuario.ConsultarUsuarioNombreIgual(nombre);
        }

        /// <summary>
        /// Consulta usuarios activos en el sistema
        /// </summary>
        /// <param name="nombre">nombre del usuario a consultar</param>
        /// <returns></returns>
        public DataTable ConsultarUsuarioNombreContengaActivos(string nombre)
        {
            return miDaoUsuario.ConsultarUsuarioNombreContengaActivos(nombre);
        }

        /// <summary>
        /// Consulta usuarios sean activos o inactivos en el sistema.
        /// </summary>
        /// <param name="nombre">nombre del usuario a consultar</param>
        /// <returns></returns>
        public DataTable ConsultarUsuarioNombreContenga(string nombre)
        {
            return miDaoUsuario.ConsultarUsuarioContenga(nombre);
        }

        /// <summary>
        /// Consulta usuarios por cargo sean activos o inactivos en el sistema-
        /// </summary>
        /// <param name="idCargo">id cargo a consultar</param>
        /// <returns></returns>
        public DataTable ConsultarUsuarioCargo(int idCargo)
        {
            return miDaoUsuario.ConsultarUsuarioCargo(idCargo);
        }

        /// <summary>
        /// Consulta usuario por cargo  solo activos en el sistema.
        /// </summary>
        /// <param name="idcargo"></param>
        /// <returns></returns>
        public DataTable consultarUsuariocargoActivo(int idcargo)
        {
            return miDaoUsuario.ConsultarUsuarioCargoActivo(idcargo);
        }

        public Usuario ConsultarUsuarioFactura(int id, bool venta)
        {
            //pa programar.
            var miUsuario = new DTO.Clases.Usuario();
            miUsuario.Id = 6;
            miUsuario.Identificacion = 1054916821;
            miUsuario.Nombres = "Manuel Alejandro Murillo Vasquez";
            return miUsuario;
        }

        /// <summary>
        /// Verifica el registro del usuario administrador del sistema.
        /// </summary>
        /// <param name="password">Password del usuario.</param>
        /// <returns></returns>
        public bool VerificarUsuarioAdmin(string password)
        {
            return miDaoUsuario.VerificarUsuarioAdmin(password);
        }

        /// <summary>
        /// Consulta en la base de datos si el usuario existe.
        /// </summary>
        /// <param name="usuario">usuario a consultar</param>
        /// <returns></returns>
        public bool ExisteUsuario(string usuario)
        {
            return miDaoUsuario.ExisteUsuario(usuario);
        }

        /// <summary>
        /// Consulta en la base de datos que la contraseña ingresada sea la misma que hay en la base de datos.
        /// </summary>
        /// <param name="contrasena">contraseña a consultar</param>
        /// <returns></returns>
        public string ExisteContasena(int idUsuario)
        {
            return miDaoUsuario.ExisteContrasena(idUsuario);
        }

        /// <summary>
        /// Consulta en la base de datos si existe un usuario con este tipo de documento. 
        /// </summary>
        /// <param name="documento">documeno a consultar</param>
        /// <returns></returns>
        public bool ExisteDocumento(int documento)
        {
            return miDaoUsuario.ExisteDocumento(documento);
        }

        /// <summary>
        /// Consulta si el usuario esta activo dentro dela base de datos.
        /// </summary>
        /// <param name="usuario">usuario a consultar</param>
        /// <returns></returns>
        public bool ExisteUsuarioActivo(string usuario)
        {
            return miDaoUsuario.ExisteUsuarioActivo(usuario);
        }

        /// <summary>
        /// Consulta si el password ingresado es el mismo que en la base de datos.
        /// </summary>
        /// <param name="usuario">usuario a consultar</param>
        /// <returns></returns>
        public string ExisteUsuarioPassword(string usuario)
        {
            return miDaoUsuario.ExisteUsuarioPass(usuario);
        }

        /// <summary>
        /// Cargo el usuario para ediar
        /// </summary>
        /// <param name="documento">documeto a editar</param>
        /// <returns></returns>
        public Usuario CargaUsuario(int documento)
        {
            return miDaoUsuario.CargarUsuario(documento);
        }

        /// <summary>
        /// Ediata contaseña del usuario.
        /// </summary>
        /// <param name="idUsuario">id usuario a consultar</param>
        /// <param name="contasena_">contraseña a editar</param>
        public void EditaContrasena(int idUsuario, string contasena_)
        {
            miDaoUsuario.EditaContraseña(idUsuario, contasena_);
        }

        /// <summary>
        /// Ediata usuario logueado en el momento dl sistema
        /// </summary>
        /// <param name="idUsuario">id usuario a editar</param>
        /// <param name="direccion">direccion a editar</param>
        /// <param name="telefono">telefono a editar</param>
        /// <param name="usuario">usuario a editar</param>
        public void EditaUsuarioPropio(int idUsuario, string direccion, string telefono, string usuario)
        {
            miDaoUsuario.EditaUsuarioPropio(idUsuario, direccion, telefono, usuario);
        }

        /// <summary>
        /// Obtiene los datos del Usuario de la factura de venta para su impresión.
        /// </summary>
        /// <param name="numero">Número de la Factura de Venta.</param>
        /// <returns></returns>
        public DataSet PrintUsuarioVenta(int id)
        {
            return miDaoUsuario.PrintUsuarioVenta(id);
        }

        /// <summary>
        /// Obtiene los datos del Usuario para su impresión.
        /// </summary>
        /// <param name="id">Id del Usuario.</param>
        /// <returns></returns>
        public DataSet PrintUsuario(int id)
        {
            return miDaoUsuario.PrintUsuario(id);
        }

        public DataSet PrintUsuarioRemision(int numero)
        {
            return miDaoUsuario.PrintUsuarioRemision(numero);
        }

        public object ValorColumna(DataTable tabla, string columna)
        {
            if (tabla.Rows.Count != 0)
            {
                var query = (from data in tabla.AsEnumerable()
                             select data).Single();
                return query[columna];
            }
            else
            {
                return null;
            }
        }


        public List<Usuario> UsuariosAll()
        {
            return this.miDaoUsuario.UsuariosAll();
        }
    }
}