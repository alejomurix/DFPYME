using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BussinesLayer.Clases;
using DTO.Clases;
using CustomControl;
using Utilities;

namespace Aplicacion.Administracion.Usuario
{
    public partial class frmUsuarioSistema : Form
    {
        private int IdUser { set; get; }

        private string User_ { set; get; }

        private string Document_ { set; get; }

        private bool EditUser { set; get; }

        /// <summary>
        /// Atributos del modelo de negocios.
        /// </summary>
        private BussinesUsuario miUsuario;

        /// <summary>
        /// Atributos del modelo de negocios.
        /// </summary>
        private BussinesPermiso miPermiso;

        private BussinesTipoUsuario miTipoUsuario;

        /// <summary>
        /// Proporciona una interfaz que indica que el formulario tiene un error asociado.
        /// </summary>
        private ErrorProvider miError;

        /// <summary>
        /// Listado de permisos;
        /// </summary>
      //  private List<Permiso> Permisos;

        private CargarCriterioUsuario CriterioUsuario;

        /// <summary>
        /// Determina el valor de la validación en el formulario.
        /// </summary>
        private bool nombreUsuario = false;
        private bool documentoUsuario= false;
        private bool telefonoUsuario = true;
        private bool usuarioSistema = false;
        private bool ContraseniaUsuario = false;
        private bool DireccionUsuario = true;



        public frmUsuarioSistema()
        {
            InitializeComponent();
            this.IdUser = 0;
            this.EditUser = false;
            miUsuario = new BussinesUsuario();
            miTipoUsuario = new BussinesTipoUsuario();
            miPermiso = new BussinesPermiso();
            miError = new ErrorProvider();
           // Permisos = new List<Permiso>();
            CriterioUsuario = new CargarCriterioUsuario();
        }

        private void frmUsuarioSistema_Load(object sender, EventArgs e)
        {
            this.tpPermiso.Controls.Remove(tpConsultapermosoYUsuario);
            CargarComboBox();
            ListarPermisosUsuario();
            CompletaEventos.Completa += new CompletaEventos.CompletaAccion(CompletaEventos_Completa);
        }

        private void tsbtnGuardar_Click(object sender, EventArgs e)
        {
            cbxCargo.Focus();
            try
            {
                Revalidar();
                if (nombreUsuario && documentoUsuario && telefonoUsuario && usuarioSistema && ContraseniaUsuario && DireccionUsuario)
                {
                    var usuario = new DTO.Clases.Usuario();
                    usuario.IdTipo = (int)cbxCargo.SelectedValue;
                    usuario.Identificacion = Convert.ToInt32(txtDocumento.Text);
                    usuario.Nombres = txtNombre.Text;
                    usuario.Usuario_ = txtUsuario.Text;
                    usuario.Contrasenia = Encode.Encrypt(txtContraseña.Text);
                    usuario.Estado = true;
                    usuario.Telefono = txtTelefono.Text;
                    usuario.Direccion = txtDireccion.Text;
                   // CargarPermiso();
                    //usuario.Permisos = Permisos;
                    miUsuario.InsertarUsuario(usuario);

                    OptionPane.MessageInformation("El Usuario se a guardado exitosamente.");
                    LimpiaCampos();
                }
            }
            catch(Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            var idCriterio = (int)cbxConsultaCriterio.SelectedValue;
            if (idCriterio == 1)
            {
                if (ValidaDocumento())
                {
                    ConsultarUsuarioDocumento(Convert.ToInt32(txtConsulta.Text));
                }               
            }
            else
            {
                if (idCriterio == 2)
                {
                    if (ValidaNombre())
                    {
                        ConsultarUsuarioNombre(txtConsulta.Text, idCriterio);
                    }
                }
                else
                {
                    if (idCriterio == 3)
                    {
                        var id = (int)cbxCargoUsuario.SelectedValue;
                        ConsultarUsuarioCargo(id);
                    }
                }
            }
            if (dgvUsuario.RowCount != 0)
            {
                dgvUsuario_Click(null, null);
            }
        }

        private void tsbtnEditar_Click(object sender, EventArgs e)
        {
            if (dgvUsuario.RowCount != 0)
            {
                try
                {
                    frmEditaUsuario edita = new frmEditaUsuario();
                    edita.Documento = (int)dgvUsuario.CurrentRow.Cells["Documento"].Value;
                    edita.Show();
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
            else
            {
                OptionPane.MessageInformation("No hay usuarios  a Editar");
            }
        }

        private void tsbtnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvUsuario.RowCount != 0)
            {
                DialogResult r = MessageBox.Show("Desea eliminar el Usuario.", "Eliminar",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (r == DialogResult.Yes)
                {
                    var id = (int)dgvUsuario.CurrentRow.Cells["IdUsuario"].Value;
                    try
                    {
                        miUsuario.EliminaUsuario(id);
                        OptionPane.MessageInformation("Se a eliminado el usuario exitosamente.");
                        dgvUsuario.Rows.RemoveAt(dgvUsuario.CurrentCell.RowIndex);
                        if (dgvUsuario.RowCount != 0)
                        {
                            dgvUsuario_Click(dgvUsuario, new EventArgs());
                        }
                        else
                        {
                            while (dgvPermisoUsuario.RowCount != 0)
                            {
                                dgvPermisoUsuario.Rows.RemoveAt(0);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        OptionPane.MessageError(ex.Message);
                    }
                }
            }
            else
            {
                OptionPane.MessageInformation("No hay registros a eliminar.");
            }
        }

        private void tsbtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbtnSalirConsulta_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lklblMarcar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            foreach (DataGridViewRow row in dgvPermiso.Rows)
            {
                row.Cells["Aplica"].Value = true;
            }
            ColorearGrid();
        }

        private void lklblDesmarcar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            foreach (DataGridViewRow row in dgvPermiso.Rows)
            {
                row.Cells["Aplica"].Value = false;
            }
            ColorearGrid();
            this.dgvPermiso_CurrentCellDirtyStateChanged(this.dgvPermiso, null);
        }

        private void txtNombre_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(txtNombre, miError, "El campo de nombre es requerido."))
            {
                nombreUsuario = true;
               /* if (Validacion.ConFormato(Validacion.TipoValidacion.Palabras, txtNombre, miError, "El campo de nombre tiene formato incorrecto."))
                {
                    nombreUsuario = true;
                }
                else
                    nombreUsuario = false;*/
            }
            else
                nombreUsuario = false;
        }

        private void txtDocumento_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(txtDocumento, miError, "El campo del documento es requerido."))
            {
                if (Validacion.ConFormato(Validacion.TipoValidacion.Numeros, txtDocumento, miError, "El campo de documento tiene formato incorrecto."))
                {
                    if (!this.EditUser)
                    {
                        if (!ExisteDocumento(Convert.ToInt32(txtDocumento.Text)))
                        {
                            documentoUsuario = true;
                            miError.SetError(txtDocumento, null);
                        }
                        else
                        {
                            //OptionPane.MessageInformation("Ya hay un usuario con este documento.");
                            miError.SetError(txtDocumento, "Ya hay un usuario con este documento.");
                            documentoUsuario = false;
                        }
                    }
                    else
                    {
                        if (this.Document_ != this.txtDocumento.Text)
                        {
                            if (!ExisteDocumento(Convert.ToInt32(txtDocumento.Text)))
                            {
                                documentoUsuario = true;
                                miError.SetError(txtDocumento, null);
                            }
                            else
                            {
                                //OptionPane.MessageInformation("Ya hay un usuario con este documento.");
                                miError.SetError(txtDocumento, "Ya hay un usuario con este documento.");
                                documentoUsuario = false;
                            }
                        }
                        else
                        {
                            this.documentoUsuario = true;
                        }
                    }
                }
                else
                    documentoUsuario = false;               
            }
            else
                documentoUsuario = false;
        }

        private void txtTelefono_Validating(object sender, CancelEventArgs e)
        {
            /*if(!Validacion.EsVacio(txtTelefono,miError,"El campo de teléfono es requerido"))
            {
                if (Validacion.ConFormato(Validacion.TipoValidacion.Numeros, txtTelefono, miError, "El campo teléfono tiene formato incurrecto"))
                {
                    telefonoUsuario = true;
                }
                else
                    telefonoUsuario = false;
            }
            else
                telefonoUsuario=false;*/
        }

        private void txtContraseña_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(txtContraseña, miError, "El campo de la contraseña es requerido."))
            {
               // if (Validacion.ConFormato(Validacion.TipoValidacion.Password, txtContraseña, miError, "El campo de contraseña tiene formato incorrecto."))
                //{
                    ContraseniaUsuario = true;
                //}
              //  else
                //    ContraseniaUsuario = false;
            }
            else
                ContraseniaUsuario = false;
        }

        private void txtUsuario_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(txtUsuario, miError, "El campo de Usuario es requerido."))
            {
               // if (Validacion.ConFormato(Validacion.TipoValidacion.Password, txtUsuario, miError, "El campo de usuario tiene formato incorrecto."))
                //{
                if (!this.EditUser)
                {
                    if (!ExisteUsuario(txtUsuario.Text))
                    {
                        usuarioSistema = true;
                        miError.SetError(txtUsuario, null);
                    }
                    else
                    {
                        //OptionPane.MessageInformation("El usuario ya existe.");
                        usuarioSistema = false;
                        miError.SetError(txtUsuario, "El usuario ya existe.");
                    }
                }
                else
                {
                    if (this.User_ != this.txtUsuario.Text)
                    {
                        if (!ExisteUsuario(txtUsuario.Text))
                        {
                            usuarioSistema = true;
                            miError.SetError(txtUsuario, null);
                        }
                        else
                        {
                            //OptionPane.MessageInformation("El usuario ya existe.");
                            usuarioSistema = false;
                            miError.SetError(txtUsuario, "El usuario ya existe.");
                        }
                    }
                    else
                    {
                        this.usuarioSistema = true;
                    }
                }
               // }
               // else
               //usuarioSistema=false;
            }
            else
                usuarioSistema = false;
        }

        private void txtDireccion_Validating(object sender, CancelEventArgs e)
        {
            
        }

        private void txtConsulta_KeyPress(object sender, KeyPressEventArgs e)
        {           
            if (e.KeyChar == (char)Keys.Enter)
            {   
               btnConsultar_Click(null, null);                    
                 
            }           
        }       

        private void cbxConsultaCriterio_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var id = (int)cbxConsultaCriterio.SelectedValue;
            dgvUsuario.DataSource = null;
            dgvPermisoUsuario.DataSource = null;
            txtConsulta.Text = "";
            if (id == 1)
            {
                txtConsulta.Enabled = true;
                cbxIgualContenga.Enabled = false;
                chbxIncluir.Enabled = false;
                cbxCargoUsuario.Enabled = false;
            }
            else
            {
                if (id == 2)
                {
                    cbxIgualContenga.Enabled = true;
                    txtConsulta.Enabled = true;
                    chbxIncluir.Enabled = false;
                    cbxCargoUsuario.Enabled = false;
                }
                else
                {
                    if (id == 3)
                    {
                        cbxIgualContenga.Enabled = false;
                        txtConsulta.Enabled = false;
                        cbxCargoUsuario.Enabled = true;
                        chbxIncluir.Enabled = true;
                    }
                }
            }
        }

        private void cbxCargoUsuario_SelectionChangeCommitted(object sender, EventArgs e)
        {
            dgvUsuario.DataSource = null;
            dgvPermisoUsuario.DataSource = null;
            txtConsulta.Text = "";
            chbxIncluir.Enabled = false;
        }

        private void cbxIgualContenga_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var id = (int)cbxIgualContenga.SelectedValue;
            if (id == 1)
            {
                dgvUsuario.DataSource = null;
                dgvPermisoUsuario.DataSource = null;
                txtConsulta.Text = "";
                chbxIncluir.Enabled = false;
            }
            else
            {
                dgvUsuario.DataSource = null;
                dgvPermisoUsuario.DataSource = null;
                txtConsulta.Text = "";
                chbxIncluir.Enabled = true;
            }
           
        }

        private void dgvUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                var id = (int)dgvUsuario.CurrentRow.Cells["IdUsuario"].Value;
                dgvPermisoUsuario.AutoGenerateColumns = false;
                dgvPermisoUsuario.DataSource = miPermiso.ListarPermisosUsuario(id);
            }
            catch(Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        /// <summary>
        /// Carga comboBox con los cargos de usuario.
        /// </summary>
        private void CargarComboBox()
        {
            try
            {
                cbxCargo.DataSource = miTipoUsuario.ListarCargo();
                cbxIgualContenga.DataSource = CriterioUsuario.listaCriterioUsuario;
                cbxConsultaCriterio.DataSource = CriterioUsuario.listaCriterioUsuario_;
                cbxCargoUsuario.DataSource = miTipoUsuario.ListarCargo();
            }
            catch(Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        /// <summary>
        /// Lista los permisos de los usuarios.
        /// </summary>
        private void ListarPermisosUsuario()
        {
            try
            {
                this.dgvUsuarios.AutoGenerateColumns = false;
                /*DataTable tUsuarios = this.miUsuario.Usuarios();
                this.dgvUsuarios.DataSource = tUsuarios;*/
                this.dgvUsuarios.DataSource = this.miUsuario.Usuarios();

                dgvPermiso.AutoGenerateColumns = false;
                dgvPermiso.Columns["Permiso"].ReadOnly = true;
                this.dgvUsuarios_CellClick(this.dgvUsuarios, null);
               /* dgvPermiso.DataSource = miPermiso.ListarPermiso();
                var permisos = this.miPermiso.Permisos(Convert.ToInt32(this.dgvUsuarios.CurrentRow.Cells["IdUsuario_"].Value));
                //ColorearGrid();
                foreach(DataGridViewRow gRow in this.dgvPermiso.Rows)
                {
                    if (permisos.Where(ps => ps.IdPermiso.Equals(Convert.ToInt32(gRow.Cells["Id"].Value))).Count() > 0)
                    {
                        gRow.Cells["Aplica"].Value = true;
                    }
                }*/
                //ColorearGrid();
            }
            catch(Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        /// <summary>
        ///Vuelve a validar los campos del formulario.
        /// </summary>
        private void Revalidar()
        {
            this.txtDocumento_Validating(null, null);
            this.txtNombre_Validating(null, null);
            this.txtTelefono_Validating(null, null);
            this.txtUsuario_Validating(this.txtUsuario, null);
            this.txtContraseña_Validating(null, null);
        }

        /// <summary>
        /// Valida si el usuario existe en la base de datos.
        /// </summary>
        /// <param name="usuario">usuario a consultar</param>
        /// <returns></returns>
        public bool ExisteUsuario(string usuario)
        {
            try
            {
                var existeUsuario = miUsuario.ExisteUsuario(usuario);
                if (existeUsuario)
                {
                    return true;
                }
                else
                return false;
            }
            catch(Exception ex)
            {
                OptionPane.MessageError(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// valida si el documento esta dentro de la base de datos
        /// </summary>
        /// <param name="documento">docomento a consultar</param>
        /// <returns></returns>
        public bool ExisteDocumento(int documento)
        {
            try
            {
                var existe = miUsuario.ExisteDocumento(documento);
                if (existe)
                {
                    return true;
                }
                else
                    return false;
            }
            catch(Exception ex)
            {
                OptionPane.MessageError(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Valida el campo de busqueda cuando la busqueda sea por documento.
        /// </summary>
        /// <returns></returns>
        private bool ValidaDocumento()
        {
            var validaDocumento = false;
            if (!Validacion.EsVacio(txtConsulta, miError, "El campo es requerido."))
            {
                if (Validacion.ConFormato(Validacion.TipoValidacion.Numeros, txtConsulta, miError, "El campo tiene formato Incorrecto."))
                {
                    return validaDocumento = true;
                }
                else
                    return validaDocumento;
            }
            else
                return validaDocumento;
        }

        /// <summary>
        /// Valida el campo de busqueda cuando la busqueda sea por nombre.
        /// </summary>
        /// <returns></returns>
        private bool ValidaNombre()
        {
            var validaNombre = false;
            if (!Validacion.EsVacio(txtConsulta, miError, "El campo es requerido."))
            {
                if (Validacion.ConFormato(Validacion.TipoValidacion.Palabras, txtConsulta, miError, "El campo tiene formato incorrecto."))
                {
                    return validaNombre = true;
                }
                else
                    return validaNombre;
            }
            else
                return validaNombre;
        }

        private List<Permiso> CargarPermiso()
        {
            var Permisos = new List<Permiso>();
            foreach (DataGridViewRow chk in dgvPermiso.Rows)
            {
                try
                {
                    if (chk.Cells["Aplica"].Value != null)
                    {
                        var chec = (bool)chk.Cells["Aplica"].Value;
                        if (chec)
                        {
                            var p = new Permiso();
                            p.IdPermiso = (int)chk.Cells["Id"].Value;
                            Permisos.Add(p);
                        }
                    }                    
                }
                catch
                { }
            }
            return Permisos;
        }

        /// <summary>
        /// Limpia los campos del formulario.
        /// </summary>
        private void LimpiaCampos()
        {
            txtContraseña.Text = "";
            txtDocumento.Text = "";
            txtNombre.Text = "";
            txtTelefono.Text="";
            txtUsuario.Text = "";
            txtDireccion.Text = "";           
            ListarPermisosUsuario();
           // Permisos.Clear();
        }

        /// <summary>
        /// Consulta usuario por documento.
        /// </summary>
        /// <param name="documento">documento a consultrar</param>
        private void ConsultarUsuarioDocumento(int documento)
        {
            try
            {
                dgvUsuario.AutoGenerateColumns = false;
                dgvUsuario.DataSource = miUsuario.ConsultarUsuarioDocumento(documento);
                
                if (dgvUsuario.RowCount == 0)
                {
                    OptionPane.MessageInformation("El usuario con este documento no existe.");
                }                
            }
            catch(Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        /// <summary>
        /// Consulta usuarios por nombre.
        /// sean iguales, que contenga .
        /// esten activos o inactivos.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="id"></param>
        private void ConsultarUsuarioNombre(string nombre, int id)
        {
            try
            {
                dgvUsuario.AutoGenerateColumns = false;
                if (id == 1)
                {
                    dgvUsuario.DataSource = miUsuario.ConsultarUsuarioNombreIgual(nombre);
                }
                else
                {
                    if (id == 2)
                    {
                        if (chbxIncluir.Checked)
                        {
                            dgvUsuario.DataSource = miUsuario.ConsultarUsuarioNombreContenga(nombre);
                            ColorInactivos();
                        }
                        else
                        {
                            dgvUsuario.DataSource = miUsuario.ConsultarUsuarioNombreContengaActivos(nombre);
                        }
                    }
                }               
                if (dgvUsuario.RowCount == 0)
                {
                    OptionPane.MessageInformation("El usuario con este nombre no existe.");
                }
            }
            catch(Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        /// <summary>
        /// Consulta usuarios por cargo.
        /// </summary>
        /// <param name="idCargo">is cargo a consultar</param>
        private void ConsultarUsuarioCargo(int idCargo)
        {
            try
            {
                dgvUsuario.AutoGenerateColumns = false;
                if (chbxIncluir.Checked)
                {
                    dgvUsuario.DataSource = miUsuario.ConsultarUsuarioCargo(idCargo);
                    ColorInactivos();
                }
                else
                {
                    dgvUsuario.DataSource = miUsuario.consultarUsuariocargoActivo(idCargo);
                }
                if (dgvUsuario.RowCount == 0)
                {
                    OptionPane.MessageInformation("No hay usuarios con este tipo decargos.");
                }
            }
            catch(Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        

        /// <summary>
        /// Completa eventos de datos de otro formulario.
        /// </summary>
        /// <param name="args"></param>
        private void CompletaEventos_Completa(CompletaArgumentosDeEvento args)
        {
            try
            {
                if(Convert.ToBoolean(args.MiObjeto))
                {
                    btnConsultar_Click(btnConsultar, new EventArgs());
                }
            }
            catch(Exception ex)
            {
                //OptionPane.MessageError(ex.Message);
            }
        }

        private void tsBtnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgvUsuario.RowCount != 0)
            {
                var user = new Inventario.Producto.Criterio();
                user.Id = (int)dgvUsuario.CurrentRow.Cells["IdUsuario"].Value;
                user.Nombre = dgvUsuario.CurrentRow.Cells["Nombre"].Value.ToString();
                CompletaEventos.CapturaEvento(user);
                this.Close();
            }
            else
            {
                OptionPane.MessageInformation("Debe seleccionar un Usuario.");
            }
        }

        private void frmUsuarioSistema_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.F12))
            {
                this.tsBtnSeleccionar_Click(this.tsBtnSeleccionar, new EventArgs());
            }
        }

        private void txtDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.txtNombre.Focus();
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.txtUsuario.Focus();
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.txtDireccion.Focus();
            }
        }

        private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.txtUsuario.Focus();
            }
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.txtContraseña.Focus();
            }
        }

        private void txtContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.btnGuardarUsuario.Focus();
            }
        }

        private void dgvPermiso_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (this.dgvPermiso.IsCurrentCellDirty)
            {
                this.dgvPermiso.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dgvPermiso.DataSource = miPermiso.ListarPermiso();
                var permisos = this.miPermiso.Permisos(Convert.ToInt32(this.dgvUsuarios.CurrentRow.Cells["IdUsuario_"].Value));
                foreach (DataGridViewRow gRow in this.dgvPermiso.Rows)
                {
                    if (permisos.Where(ps => ps.IdPermiso.Equals(Convert.ToInt32(gRow.Cells["Id"].Value))).Count() > 0)
                    {
                        gRow.Cells["Aplica"].Value = true;
                    }
                }
                ColorearGrid();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void dgvPermiso_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /*try
            {
                this.miPermiso.EliminarPermisos(Convert.ToInt32(this.dgvUsuarios.CurrentRow.Cells["IdUsuario_"].Value));
                this.dgvPermiso_CurrentCellDirtyStateChanged(this.dgvPermiso, new EventArgs());
                foreach (var permisos in CargarPermiso())
                {
                    this.miPermiso.InsertaPermisoUsuario
                        (permisos.IdPermiso, Convert.ToInt32(this.dgvUsuarios.CurrentRow.Cells["IdUsuario_"].Value));
                }

            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }*/
        }

        private void btnGuardarPermisos_Click(object sender, EventArgs e)
        {
            try
            {
                this.miPermiso.EliminarPermisos(Convert.ToInt32(this.dgvUsuarios.CurrentRow.Cells["IdUsuario_"].Value));
                foreach (var permisos in CargarPermiso())
                {
                    this.miPermiso.InsertaPermisoUsuario
                        (permisos.IdPermiso, Convert.ToInt32(this.dgvUsuarios.CurrentRow.Cells["IdUsuario_"].Value));
                }
                ColorearGrid();
                OptionPane.MessageInformation("Los permisos se guardaron con éxito.");

            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        /// <summary>
        /// Muestra los usuarios inactivos con otro color
        /// </summary>
        private void ColorInactivos()
        {
            try
            {
                foreach (DataGridViewRow row in dgvUsuario.Rows)
                {
                    if (row.Cells["Estado"].Value.ToString().Equals("Inactivo"))
                    {
                        row.DefaultCellStyle.BackColor = System.Drawing.Color.Silver;
                    }
                }
            }
            catch
            { }
        }

        private void ColorearGrid()
        {
            /*try
            {
                foreach (DataGridViewRow row in this.dgvPermiso.Rows)
                {
                    if (Convert.ToBoolean(row.Cells["menu"].Value))
                    {
                        row.DefaultCellStyle.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
                    }
                }
            }
            catch
            { }*/
        }

        private void btnGuardarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                Revalidar();
                if (documentoUsuario && nombreUsuario && usuarioSistema && ContraseniaUsuario)
                {
                    var usuario = new DTO.Clases.Usuario();
                    usuario.Id = this.IdUser;
                    usuario.IdTipo = (int)cbxCargo.SelectedValue;
                    usuario.Identificacion = Convert.ToInt32(txtDocumento.Text);
                    usuario.Nombres = txtNombre.Text;
                    usuario.Usuario_ = txtUsuario.Text;
                    usuario.Contrasenia = Encode.Encrypt(txtContraseña.Text);
                    usuario.Estado = true;
                    usuario.Telefono = txtTelefono.Text;
                    usuario.Direccion = txtDireccion.Text;

                    if (this.EditUser)
                    {
                        this.miUsuario.EditaUsuario(usuario);
                        OptionPane.MessageInformation("Los datos se editaron con éxito.");
                    }
                    else
                    {
                        this.miUsuario.InsertarUsuario(usuario);
                        OptionPane.MessageInformation("El Usuario se a guardado exitosamente.");
                    }
                    LimpiaCampos();
                    ListarPermisosUsuario();
                    this.EditUser = false;
                }
                
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void btnEditarUsuario_Click(object sender, EventArgs e)
        {
            if (this.dgvUsuarios.RowCount > 0)
            {
                try
                {
                    this.miError.SetError(this.txtDocumento, null);
                    this.miError.SetError(this.txtNombre, null);
                    this.miError.SetError(this.txtUsuario, null);
                    this.miError.SetError(this.txtContraseña, null);

                    this.IdUser = Convert.ToInt32(this.dgvUsuarios.CurrentRow.Cells["IdUsuario_"].Value);
                    this.Document_ = this.txtDocumento.Text = this.dgvUsuarios.CurrentRow.Cells["Documento_"].Value.ToString();
                    this.txtNombre.Text = this.dgvUsuarios.CurrentRow.Cells["NameUsuario"].Value.ToString();
                    this.User_ = this.txtUsuario.Text = this.dgvUsuarios.CurrentRow.Cells["UserUsuario"].Value.ToString();
                    this.txtContraseña.Text = Encode.Decrypt(this.dgvUsuarios.CurrentRow.Cells["Password"].Value.ToString());
                    this.EditUser = true;
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void btnAnularUsuario_Click(object sender, EventArgs e)
        {

        }

        
       
    }
}