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

namespace Aplicacion.Administracion.DescuentosYRecargos
{
    public partial class frmDescuentosYRecargos : Form
    {
        /// <summary>
        /// Atributos del modelo de negocios.
        /// </summary>
        private BussinesDescuento miBussinesDescuento;

        /// <summary>
        /// Atributos del modelo de negocios.
        /// </summary>
        private BussinesRecargo miBussinesRecargo;

        /// <summary>
        /// Probador de mensajes de error.
        /// </summary>
        private ErrorProvider er;

        /// <summary>
        /// Obtiene o establece el valor de la validación (al prerder el foco) descuento
        /// </summary>
        private bool ValidacionDescuento = false;

        /// <summary>
        /// Obtiene o establece el valor de la validación (al prerder el foco) recargo
        /// </summary>
        private bool ValidacionRecargo = false;

        /// <summary>
        /// Obtiene o establece el valor del id del descuento.
        /// </summary>
        private int idDescuento;

        /// <summary>
        /// Obtiene o establece al valor de descuento en la validación 
        /// </summary>
        private bool descuento=false;

        /// <summary>
        /// Obtiene o establece la condición de la propiedad del método (insert descuento)
        /// </summary>
        private bool insertDescuento = true;

        /// <summary>
        /// Indica que va a ingresar un nuevo descuento.
        /// </summary>
        private bool btnNuevoDescuento = true;

        /// <summary>
        /// Indica que va a cancelar lo de nuevo descuento.
        /// </summary>
        private bool btnCancelarNuevoDescuento = true;

        /// <summary>
        /// Indica que va a modificar un descuento.
        /// </summary>
        private bool btnModificarDescuento = true;

        /// <summary>
        /// Indica que va a cancelar lo de modificar descuento.
        /// </summary>
        private bool btnCancelarModificar = true;

        /// <summary>
        /// Obtiene o establece el valor en la validación. 
        /// </summary>
        private bool recargo = false;

        /// <summary>
        /// Obtiene o establece el valor del id recargo.
        /// </summary>
        private int idRecargo;

        /// <summary>
        /// Obtiene o establece la condición de insertRecargo o modificar recargo.
        /// </summary>
        private bool insertRecargo = false;

        /// <summary>
        /// Indica que va a ingresar un nuevo recargo.
        /// </summary>
        private bool btnNuevoRecargo = true;

        /// <summary>
        ///Indica que va a cancelar lo de nuevo recargo.
        /// </summary>
        private bool btnCancelarNuevorecargo = true;

        /// <summary>
        /// Indica que va a modificar un recargo.
        /// </summary>
        private bool btnModificarRecargo=true;

        /// <summary>
        /// Indica que va a cancelar lo de mpodificar recargo.
        /// </summary>
        private bool btnCancelarModificarRecargo = true;

        /// <summary>
        /// Representa el stream de la imagen de cancelar.
        /// </summary>
        private System.IO.Stream imgCancelarStream;

        /// <summary>
        /// Objeto para el acceso al ensamblado de la aplicación.
        /// </summary>
        private System.Reflection.Assembly assembly;

        /// <summary>
        /// Representa la ruta de ensamblado de cancelar.
        /// </summary>
        private const string imagenCancelar = "Aplicacion.Recursos.Iconos.deshacer.png";

        public frmDescuentosYRecargos()
        {
            InitializeComponent();
            miBussinesDescuento = new BussinesDescuento();
            miBussinesRecargo = new BussinesRecargo();
            er = new ErrorProvider();
        }

        private void frmDescuentosYRecargos_Load(object sender, EventArgs e)
        {
            ListarDescuento();
            ListarRecargo();
            assembly = System.Reflection.Assembly.GetExecutingAssembly();
            CargarRecursos();
            tsbtnGuardarDescunto.Enabled = false;
            tsbtnGuardarRecargos.Enabled = false;
        }

        private void tsbtnGuardarDescunto_Click(object sender, EventArgs e)
        {
            try
            {
                txtDescuento_Validating(null, null);
                if (descuento)
                {
                    if (ExisteDescuento(Convert.ToDouble(txtDescuento.Text)))
                    {
                        /*if (descuento)
                        {*/
                        ValidacionDescuento = false;
                        var midescuento = new DTO.Clases.Descuento();
                        if (insertDescuento)
                        {
                            midescuento.ValorDescuento = UseObject.RemoveCharacter(txtDescuento.Text, '.');
                            miBussinesDescuento.InsertaDescuento(midescuento);
                            ListarDescuento();
                            tsbtnNuevoDescuento_Click(null, null);
                        }
                        else
                        {
                            midescuento.IdDescuento = idDescuento;
                            midescuento.ValorDescuento = UseObject.RemoveCharacter(txtDescuento.Text, '.');
                            miBussinesDescuento.EditaDescuento(midescuento);
                            ListarDescuento();
                            tsbtnModificarDescuento_Click(null, null);
                        }
                        OptionPane.MessageInformation("Se a guardado exitosamente.");
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }        
        }

        private void tsbtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbtnNuevoDescuento_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnNuevoDescuento)
                {
                    insertDescuento = true;
                    ValidacionDescuento = true;
                    txtDescuento.Text = "";
                    txtDescuento.ReadOnly = false;
                    tsbtnGuardarDescunto.Enabled = true;
                    tsEliminarDescuento.Enabled = false;
                    tsbtnNuevoDescuento.Image = new Bitmap(imgCancelarStream);
                    tsbtnNuevoDescuento.Text = "Cancelar";
                    tsbtnModificarDescuento.Enabled = false;
                    btnNuevoDescuento = false;
                    btnCancelarNuevoDescuento = true;
                }
                else
                {
                    if (btnCancelarNuevoDescuento)
                    {
                        ValidacionDescuento = false;
                        txtDescuento.Text = "";
                        txtDescuento.ReadOnly = true;
                        tsbtnGuardarDescunto.Enabled = false;
                        tsEliminarDescuento.Enabled = true;
                        tsbtnNuevoDescuento.Image = ((Image)(miResources.GetObject("tsbtnNuevoDescuento.Image")));
                        tsbtnNuevoDescuento.Text = "Nuevo";
                        tsbtnModificarDescuento.Enabled = true;
                        btnNuevoDescuento = true;
                        btnCancelarNuevoDescuento = false;
                    }
                }
            }
            catch { }
        }

        private void tsbtnModificarDescuento_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnModificarDescuento)
                {
                    insertDescuento = false;
                    ValidacionDescuento = true;
                    idDescuento = Convert.ToInt32(dgvDescuento.CurrentRow.Cells["Id"].Value);
                    txtDescuento.Text = Convert.ToString(dgvDescuento.CurrentRow.Cells["Descuento"].Value);
                    txtDescuento.ReadOnly = false;
                    tsbtnGuardarDescunto.Enabled = true;
                    tsEliminarDescuento.Enabled = false;
                    tsbtnModificarDescuento.Image = new Bitmap(imgCancelarStream);
                    tsbtnModificarDescuento.Text = "Cancelar";
                    tsbtnNuevoDescuento.Enabled = false;
                    btnModificarDescuento = false;
                    btnCancelarModificar = true;
                }
                else
                {
                    if (btnCancelarModificar)
                    {
                        ValidacionDescuento = false;
                        txtDescuento.Text = "";
                        txtDescuento.ReadOnly = true;
                        tsbtnGuardarDescunto.Enabled = false;
                        tsEliminarDescuento.Enabled = true;
                        tsbtnModificarDescuento.Image = ((Image)(miResources.GetObject("tsbtnModificarDescuento.Image")));
                        tsbtnModificarDescuento.Text = "Editar";
                        tsbtnNuevoDescuento.Enabled = true;
                        btnModificarDescuento = true;
                        btnCancelarModificar = false;
                    }
                } 
            }
            catch
            { }
        }

        private void tsEliminarDescuento_Click(object sender, EventArgs e)
        {
            if (dgvDescuento.RowCount != 0)
            {
                DialogResult r = MessageBox.Show("Desea eliminar el registro.",
                    "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (r == DialogResult.Yes)
                {
                    var id = (int)dgvDescuento.CurrentRow.Cells["Id"].Value;
                    try
                    {
                        miBussinesDescuento.Eliminardescuento(id);
                        OptionPane.MessageInformation("Se a eliminado con exito.");
                        ListarDescuento();
                    }
                    catch (Exception ex)
                    {
                        OptionPane.MessageError(ex.Message);
                    }
                }
            }
            else
            {
                OptionPane.MessageInformation("No hay registros a liminar");
            }
        }

        private void tsbtnGuardarRecargos_Click(object sender, EventArgs e)
        {
            try
            {
                txtRecargo_Validating(null, null);
                if (recargo)
                {
                    if (ExisteRecargo(Convert.ToDouble(txtRecargo.Text)))
                    {

                       /* if (recargo)
                        {*/
                            ValidacionRecargo = false;
                            var miRecargo = new DTO.Clases.Recargo();
                            if (insertRecargo)
                            {
                                miRecargo.ValorRecargo = UseObject.RemoveCharacter(txtRecargo.Text, '.');
                                miBussinesRecargo.InsertarRcargo(miRecargo);
                                ListarRecargo();
                                tsbtnNuevoRecargo_Click(null, null);
                            }
                            else
                            {
                                miRecargo.IdRecargo = idRecargo;
                                miRecargo.ValorRecargo = UseObject.RemoveCharacter(txtRecargo.Text, '.');
                                miBussinesRecargo.EditarRecargo(miRecargo);
                                ListarRecargo();
                                tsbtnModificarRecargo_Click(null, null);
                            }
                            OptionPane.MessageInformation("Se a guardado exitosamente.");
                            lblRecargo.Focus();
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void tsbtnNuevoRecargo_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnNuevoRecargo)
                {
                    insertRecargo = true;
                    ValidacionRecargo = true;
                    txtRecargo.Text = "";
                    txtRecargo.ReadOnly = false;
                    tsbtnGuardarRecargos.Enabled = true;
                    tsbtEliminarRecargo.Enabled = false;
                    tsbtnNuevoRecargo.Image = new Bitmap(imgCancelarStream);
                    tsbtnNuevoRecargo.Text = "Cancelar";
                    tsbtnModificarRecargo.Enabled = false;
                    btnNuevoRecargo = false;
                    btnCancelarNuevorecargo = true;
                }
                else
                {
                    if (btnCancelarNuevorecargo)
                    {
                        ValidacionRecargo = false;
                        txtRecargo.Text = "";
                        txtRecargo.ReadOnly = true;
                        tsbtnGuardarRecargos.Enabled = false;
                        tsbtnNuevoRecargo.Image = ((Image)(miResources.GetObject("tsbtnNuevoRecargo.Image")));
                        tsbtnNuevoRecargo.Text = "Nuevo";
                        tsbtnModificarRecargo.Enabled = true;
                        tsbtEliminarRecargo.Enabled = true;
                        btnNuevoRecargo = true;
                        btnCancelarNuevorecargo = false;
                    }
                }
            }
            catch
            { }
        }

        private void tsbtnModificarRecargo_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnModificarRecargo)
                {
                    insertRecargo= false;
                    ValidacionRecargo = true;
                    idRecargo = Convert.ToInt32(dgvRecargo.CurrentRow.Cells["IdR"].Value);
                    txtRecargo.Text = Convert.ToString(dgvRecargo.CurrentRow.Cells["Recargo"].Value);
                    txtRecargo.ReadOnly = false;
                    tsbtnGuardarRecargos.Enabled = true;
                    tsbtEliminarRecargo.Enabled = false;
                    tsbtnModificarRecargo.Image = new Bitmap(imgCancelarStream);
                    tsbtnModificarRecargo.Text = "Cancelar";
                    tsbtnNuevoRecargo.Enabled = false;
                    btnModificarRecargo = false;
                    btnCancelarModificarRecargo = true;
                }
                else
                {
                    if (btnCancelarModificarRecargo)
                    {
                        txtRecargo.Text = "";
                        ValidacionRecargo = false;
                        txtRecargo.ReadOnly = true;
                        tsbtnGuardarRecargos.Enabled = false;
                        tsbtEliminarRecargo.Enabled = true;
                        tsbtnModificarRecargo.Image = ((Image)(miResources.GetObject("tsbtnModificarRecargo.Image")));
                        tsbtnModificarRecargo.Text = "Editar";
                        tsbtnNuevoRecargo.Enabled = true;
                        btnModificarRecargo = true;
                        btnCancelarModificarRecargo = false;
                    }
                }
            }
            catch
            { }
        }

        private void tsbtEliminarRecargo_Click(object sender, EventArgs e)
        {
            if (dgvRecargo.CurrentRow != null)
            {
                DialogResult r=MessageBox.Show("Desea eliminar el registro",
                    "Eliminar",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
                if(r==DialogResult.Yes)
                {
                    var id=(int)dgvRecargo.CurrentRow.Cells["IdR"].Value;
                    try
                    {
                        miBussinesRecargo.EliminaRecargo(id);
                        OptionPane .MessageInformation("Se a eliminado con exito");
                        ListarRecargo();
                    }
                    catch(Exception ex)
                    {
                        OptionPane.MessageInformation(ex.Message);
                    }
                }
            }
            else
            {
                OptionPane.MessageInformation("No hay registros a liminar.");
            }
        }

        private void txtDescuento_Validating(object sender, CancelEventArgs e)
        {
            if (ValidacionDescuento)
            {
                if (!Validacion.EsVacio(txtDescuento, er, "El campo es requerido"))
                {
                    if (Validacion.ConFormato(Validacion.TipoValidacion.NumerosYPunto, txtDescuento, er, "El porcentaje del descuento tiene formato incorrecto."))
                    {
                        descuento = true;
                    }
                    else
                        descuento = false;
                }
                else
                    descuento = false;
            }
        }

        private void txtRecargo_Validating(object sender, CancelEventArgs e)
        {
            if (ValidacionRecargo)
            {
                if (!Validacion.EsVacio(txtRecargo, er, "El campo es requerido"))
                {
                    if (Validacion.ConFormato(Validacion.TipoValidacion.NumerosYPunto, txtRecargo, er, "El porcentaje del recargo tiene formato incorrecto."))
                    {
                        recargo = true;
                    }
                    else
                        recargo = false;
                }
                else
                    recargo = false;
            }
        }

        /// <summary>
        /// Listar descuento.
        /// </summary>
        private void ListarDescuento()
        {
            try
            {
                dgvDescuento.AutoGenerateColumns = false;
                dgvDescuento.DataSource = miBussinesDescuento.ListadoDescuento();
            }
            catch(Exception ex)
            {
                OptionPane.MessageError(ex.Message);            
            
            }
        }

        /// <summary>
        /// Listar recargos.
        /// </summary>
        private void ListarRecargo()
        {
            try
            {
                dgvRecargo.AutoGenerateColumns = false;
                dgvRecargo.DataSource = miBussinesRecargo.ListadoRecargo();
            }
            catch(Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        /// <summary>
        ///Carga los recursos del ensamblado usado en el formulario. 
        /// </summary>
        private void CargarRecursos()
        {
            try            
            {
                imgCancelarStream = assembly.GetManifestResourceStream(imagenCancelar);
            }
            catch
            { }
        }

        /// <summary>
        /// Existe descuento en la base de datos.
        /// </summary>
        /// <param name="valorDescuento"> valor del descuento a consultar</param>
        /// <returns></returns>
        private bool ExisteDescuento(double valorDescuento)
        {
            try
            {
                var res = miBussinesDescuento.ExisteDescuento(valorDescuento);
                if (!res)
                {
                    return true;
                    er.SetError(txtDescuento,null);
                }
                else
                {
                    OptionPane.MessageInformation("El descuento ingresado ya existe.");
                    er.SetError(txtDescuento, "El descuento ingresado ya existe.");
                    return false;
                }
            }
            catch(Exception ex)
            {
                OptionPane.MessageError(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Existe recargo en la base de datos
        /// </summary>
        /// <param name="ValorRecargo">valor del recargo a consultar</param>
        /// <returns></returns>
        private bool ExisteRecargo(double ValorRecargo)
        {
            try
            {
                var res = miBussinesRecargo.ExisteRecargo(ValorRecargo);
                if (!res)
                {
                    return true;
                    er.SetError(txtRecargo, null);
                }
                else
                {
                    OptionPane.MessageInformation("El recargo ingresado ya existe.");
                    er.SetError(txtRecargo, "El recargo ingresado ya existe.");
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

