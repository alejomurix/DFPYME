using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BussinesLayer.Clases;
using CustomControl;
using Utilities;

namespace Aplicacion.Administracion.TipoUsuario
{
    public partial class frmCargo : Form
    {
        /// <summary>
        /// Atributos del modelo de negocios.
        /// </summary>
        private BussinesTipoUsuario miTipoUsuario;

        /// <summary>
        /// Objeto de mensajeria de error.
        /// </summary>
        private ErrorProvider miError;

        /// <summary>
        /// Indica que va a modificar un registro en el grid.
        /// </summary>
        private bool btnModificarCargo = true;

        /// <summary>
        /// indica que ba a cancelar lode modificar gid
        /// </summary>
        private bool btnCancelarCargo = true;

        /// <summary>
        /// Indica que va a ingresar un nuevo cargo.
        /// </summary>
        private bool btnNuevocargo = true;

        /// <summary>
        /// Indica que va a cancelar lo de nuevo cargo.
        /// </summary>
        private bool btnCancalarNuvoCargo = true;

        /// <summary>
        /// Objeto para el acceso al ensamblado de la aplicación.
        /// </summary>
        private System.Reflection.Assembly assembly;

        /// <summary>
        /// Representa un stream de la imagen cancelar
        /// </summary>
        private System.IO.Stream imgCancelarStream;

        /// <summary>
        /// Representa la ruta de ensamblado de botón cancelar.
        /// </summary>
        private const string imagenCancelar = "Aplicacion.Recursos.Iconos.deshacer.png";

        /// <summary>
        /// Obtiene o establece el valor de la validación.
        /// </summary>
        private bool Cargo_ = false;

        /// <summary>
        /// 
        /// </summary>
        private bool nuevo = false;

        /// <summary>
        /// Obtiene el valir del id del cargo.
        /// </summary>
        private int idCargo;

        /// <summary>
        /// Obtiene o establece el valor de la validacion.
        /// </summary>
        private bool Insert = false;

        public frmCargo()
        {
            InitializeComponent();
            miTipoUsuario = new BussinesTipoUsuario();
            miError = new ErrorProvider();
        }

        private void frmCargo_Load(object sender, EventArgs e)
        {
            CargarCargo();
            assembly = System.Reflection.Assembly.GetExecutingAssembly();
            CargarRecursos();
            tsbtnGuardar.Enabled = false;
        }       

        private void tsbtnGuardar_Click(object sender, EventArgs e)
        {
            txtCargo_Validating(null, null);
            var cargo = new DTO.Clases.TipoUsuario();
            if (Cargo_)
            {
                if (Insert)
                {
                    if (ExisteCargo(txtCargo.Text))
                    {
                        cargo.Descripcion = txtCargo.Text;
                        miTipoUsuario.InsertaCargo(cargo);
                        OptionPane.MessageInformation("El cargo se a guardado exitosamente.");
                        tsbtnNuevo_Click(tsbtnNuevo, new EventArgs());
                    }
                }
                else
                {
                    if (ExisteCargo(txtCargo.Text))
                    {
                        cargo.IdTipo = idCargo;
                        cargo.Descripcion = txtCargo.Text;
                        miTipoUsuario.EditaCargo(cargo);
                        OptionPane.MessageInformation("El cargo se a editado exitosamente.");
                        tsbtnModificar_Click(tsbtnModificar, new EventArgs());
                    }
                }
                CargarCargo();
                nuevo = false;
            }
        }     

        private void tsEliminar_Click(object sender, EventArgs e)
        {
            if (dgvcargo.RowCount != 0)
            {
                DialogResult r = MessageBox.Show("Desea eliminar el registro", "Eliminar",
                                 MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (r == DialogResult.Yes)
                {
                    try
                    {
                        var idCargo = Convert.ToInt32(dgvcargo.CurrentRow.Cells["Idcargo"].Value);
                        if (idCargo != 0)
                        {
                            miTipoUsuario.EliminarCargo(idCargo);
                            OptionPane.MessageInformation("El cargo se a eliminado exitosamente.");
                            CargarCargo();
                        }
                        else
                        {
                             var CargoU = Convert.ToInt32(dgvcargo.CurrentRow.Cells["Cargo"].Value);
                             OptionPane.MessageInformation("El el cargo " + CargoU + " no se puede eliminar.");
                        }
                    }
                    catch(Exception ex)
                    {
                        OptionPane.MessageInformation(ex.Message);
                    }
                }
            }
            else
            {
                OptionPane.MessageInformation("No hay registros a eliminar.");
            }
        }

        private void tsbtnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvcargo.RowCount != 0)
                {
                    if (btnModificarCargo)
                    {
                        idCargo = Convert.ToInt32(dgvcargo.CurrentRow.Cells["Idcargo"].Value);
                        txtCargo.Text = Convert.ToString(dgvcargo.CurrentRow.Cells["Cargo"].Value);
                        tsbtnGuardar.Enabled = true;
                        tsbtnNuevo.Enabled = false;
                        tsbtnModificar.Image = new Bitmap(imgCancelarStream);
                        tsbtnModificar.Text = "Cancelar";
                        btnModificarCargo = false;
                        btnCancelarCargo = true;
                        txtCargo.ReadOnly = false;
                        Insert = false;
                        nuevo = true;
                        tsEliminar.Enabled = false;
                    }
                    else
                    {
                        if (btnCancelarCargo)
                        {
                            tsbtnModificar.Image = ((Image)(miResources.GetObject("tsbtnModificar.Image")));
                            tsbtnModificar.Text = "Editar";
                            txtCargo.Text = "";
                            txtCargo.ReadOnly = true;
                            tsbtnGuardar.Enabled = false;
                            tsbtnNuevo.Enabled = true;
                            btnModificarCargo = true;
                            btnCancelarCargo = false;
                            nuevo = true;
                            tsEliminar.Enabled = false;
                        }
                    }
                }
                else
                {
                    OptionPane.MessageInformation("No hay registros a editar.");
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void tsbtnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnNuevocargo)
                {
                    Insert = true;
                    txtCargo.Text = "";
                    txtCargo.ReadOnly = false;
                    tsbtnGuardar.Enabled = true;
                    tsbtnNuevo.Image = new Bitmap(imgCancelarStream);
                    tsbtnNuevo.Text = "Cancelar";
                    btnNuevocargo = false;
                    btnCancalarNuvoCargo = true;
                    tsbtnModificar.Enabled = false;
                    tsEliminar.Enabled = false;
                    nuevo = true;
                }
                else
                {
                    if (btnCancalarNuvoCargo)
                    {
                        txtCargo.Text = "";
                        txtCargo.ReadOnly = true;
                        tsbtnGuardar.Enabled = false;
                        tsbtnNuevo.Image = ((Image)(miResources.GetObject("tsbtnNuevo.Image")));
                        tsbtnNuevo.Text = "Nuevo";
                        btnNuevocargo = true;
                        btnCancalarNuvoCargo = false;
                        tsbtnModificar.Enabled = true;
                        tsEliminar.Enabled = true;
                        nuevo = false;
                    }
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }      

        private void tsbtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCargo_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(txtCargo, miError, "El campo del cargo s requeerido."))
            {
                if (Validacion.ConFormato(Validacion.TipoValidacion.Palabras, txtCargo, miError, "El campo del cargo tiene formato incorrecto."))
                {
                    Cargo_ = true;
                }
                else
                    Cargo_ = false;
            }
            else
                Cargo_ = false;
            }

        /// <summary>
        /// Consulta los cargos existentes en la base de datos.
        /// </summary>
        private void CargarCargo()
        {
            try
            {
                dgvcargo.AutoGenerateColumns = false;
                dgvcargo.DataSource = miTipoUsuario.ListarCargo();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        /// <summary>
        /// Carga los recursos del ensamblado usado en el formulario
        /// </summary>
        private void CargarRecursos()
        {
            try
            {
                imgCancelarStream = assembly.GetManifestResourceStream(imagenCancelar);
            }
            catch(Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private bool ExisteCargo(string cargo)
        {
            try
            {
                var res = miTipoUsuario.ExisteCargo(cargo);
                if (!res)
                {
                    return true;
                }
                else
                {
                    OptionPane.MessageInformation("El cargo ingresado ya existe.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
                return false;
            }
        }
        
    }
}
