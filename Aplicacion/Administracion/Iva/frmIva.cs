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

namespace Aplicacion.Administracion.Iva
{
    public partial class frmIva : Form
    {
        /// <summary>
        /// Atributos del modelo de negocios.
        /// </summary>
        private BussinesIva miIva;

        /// <summary>
        /// Control de mensajes de error.
        /// </summary>
        private ErrorProvider miError;

        /// <summary>
        /// Establece el valor de el id iva.
        /// </summary>
        private int idIva_ = 0;
        
        /// <summary>
        /// Establece la condición de validación si es ingresar o modificar.
        /// </summary>
        private bool ingresar = false;

        /// <summary>
        /// Determina el valor en la validación.
        /// </summary>
        private bool iva_ = false;

        /// <summary>
        /// Indica que quiero modificar un registro del grid.
        /// </summary>
        private bool btnModificarIva = true;

        /// <summary>
        /// Indica que cancela la acción de modificar IVA.
        /// </summary>
        private bool btnCancelarModificarIva = true;

        /// <summary>
        /// Indica que quiero ingresar un nuevo valor de IVA.
        /// </summary>
        private bool btnNuevoIva = true;

        /// <summary>
        /// Indica que quiero cancelar lo de ingresar nuevo IVA.
        /// </summary>
        private bool btnCancelarNuevaIva = true;

        /// <summary>
        /// Obtiene o establece el valor de la validación.
        /// </summary>
        private bool nuevo_ = false;

        /// <summary>
        /// Objeto para el acceso al ensamblado de la aplicación.
        /// </summary>
        private System.Reflection.Assembly assembly;

        /// <summary>
        /// Representa el stream de la imagen de cancelar;
        /// </summary>
        private System.IO.Stream imgCancelarStream;

        /// <summary>
        /// Representa al stream de la imagen de cancelar.
        /// </summary>
        private System.IO.Stream imgCancelNuevoStream;

        /// <summary>
        /// Representa la ruta de ensamblado de botón cancelar.
        /// </summary>
        private const string imagenCancelar = "Aplicacion.Recursos.Iconos.deshacer.png";

        /// <summary>
        /// Representa la ruta de ensamblado de botón cancelar.
        /// </summary>
        private const string imagenCancelar_ = "Aplicacion.Recursos.Iconos.deshacer.png";

        public frmIva()
        {
            InitializeComponent();
            miIva = new BussinesIva();
            miError = new ErrorProvider();
        }

        private void frmIva_Load(object sender, EventArgs e)
        {
            ConsultaIva();
            assembly = System.Reflection.Assembly.GetExecutingAssembly();
            CargaRecurso();
            txtIva.ReadOnly = true;
        }

        private void tsBtnGuardar_Click(object sender, EventArgs e)
        {
            txtIva_Validating(null,null);
            if (iva_)
            {
                var iva = new DTO.Clases.Iva();
                try
                {
                    if (ExisteIva(Convert.ToDouble(txtIva.Text)))
                    {
                        if (ingresar)
                        {
                            iva.PorcentajeIva = UseObject.RemoveCharacter(txtIva.Text, '.');                          
                            miIva.IngresarIva(iva);
                            tsBtnNuevo_Click(null, null);
                        }
                        else
                        {
                            iva.IdIva = idIva_;
                            iva.PorcentajeIva = UseObject.RemoveCharacter(txtIva.Text, '.');                             
                            miIva.EditaIva(iva);
                            tsbtnModificar_Click(null, null);
                        }
                        OptionPane.MessageInformation("Se a guardado con exito.");
                        ConsultaIva();
                        tsBtnGuardar.Enabled = false;
                        tsBtnNuevo.Enabled = true;
                        nuevo_ = false;
                    }
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void tsBtnNuevo_Click(object sender, EventArgs e)
        {
            if (btnNuevoIva)
            {
                ingresar = true;
                txtIva.Text = "";
                txtIva.ReadOnly = false;
                tsBtnGuardar.Enabled = true;
                tsbtnModificar.Enabled = false;
                tsEliminar.Enabled = false;
                tsBtnNuevo.Image = new Bitmap(imgCancelNuevoStream);
                tsBtnNuevo.Text = "Cancelar";
                btnNuevoIva = false;
                btnCancelarNuevaIva = true;
                nuevo_ = true;
                dgvIva.Enabled = false;
                lblIva.Text = "Nuevo IVA %";
            }
            else
            {
                if (btnCancelarNuevaIva)
                {
                    txtIva.Text = "";
                    txtIva.ReadOnly = true;
                    tsBtnGuardar.Enabled = false;
                    tsbtnModificar.Enabled = true;
                    tsEliminar.Enabled = true;
                    tsBtnNuevo.Image = ((Image)(miResources.GetObject("tsBtnNuevo.Image")));
                    tsBtnNuevo.Text = "Nuevo";
                    btnNuevoIva = true;
                    btnCancelarNuevaIva = false;
                    nuevo_ = false;
                    dgvIva.Enabled = true;
                    lblIva.Text = "IVA %";
                }
            }
        }

        private void tsbtnModificar_Click(object sender, EventArgs e)
        {
            if (dgvIva.CurrentRow != null)
            {
                if (btnModificarIva)
                {
                    DataGridViewRow currentRow = dgvIva.Rows[dgvIva.CurrentCell.RowIndex];
                    idIva_ = Convert.ToInt32(currentRow.Cells[0].Value);
                    txtIva.Text = Convert.ToString(currentRow.Cells[1].Value);
                    tsBtnGuardar.Enabled = true;
                    tsBtnNuevo.Enabled = false;
                    tsEliminar.Enabled = false;
                    tsbtnModificar.Image = new Bitmap(imgCancelarStream);
                    tsbtnModificar.Text = "Cancelar";
                    btnModificarIva = false;
                    btnCancelarModificarIva = true;
                    txtIva.ReadOnly = false;
                    ingresar = false;
                    nuevo_ = true;
                    dgvIva.Enabled = false;
                    lblIva.Text = "Editar IVA %";
                }
                else
                {
                    if (btnCancelarModificarIva)
                    {
                        tsbtnModificar.Image = ((Image)(miResources.GetObject("tsbtnModificar.Image")));
                        tsbtnModificar.Text = "Editar";
                        txtIva.Text = "";
                        txtIva.ReadOnly = true;
                        tsBtnGuardar.Enabled = false;
                        tsBtnNuevo.Enabled = true;
                        tsEliminar.Enabled = true;
                        btnModificarIva = true;
                        btnCancelarModificarIva = false;
                        nuevo_ = false;
                        dgvIva.Enabled = true;
                        lblIva.Text = "IVA %";
                    }
                }
            }
            else
            { }
        }

        private void tsEliminar_Click(object sender, EventArgs e)
        {
            if (dgvIva.RowCount != 0)
            {
                DialogResult r = MessageBox.Show("Desea eliminar el registro",
                    "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (r == DialogResult.Yes)
                {
                    var id = (int)dgvIva.CurrentRow.Cells["IdIva"].Value;
                    try
                    {
                        miIva.EliminarIva(id);
                        OptionPane.MessageInformation("Se a eliminado con exito");
                        ConsultaIva();
                    }
                    catch(Exception ex)
                    {
                        OptionPane.MessageError("El registro del IVA no se puede eliminar.");
                    }
                }
            }
            else
            {
                OptionPane.MessageInformation("No hay registros a eliminar.");
            }
        }

        private void tsBtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtIva_Validating(object sender, CancelEventArgs e)
        {
            if (nuevo_)
            {
                if (!Validacion.EsVacio(txtIva, miError, "El Campo es requerido."))
                {
                    if (Validacion.ConFormato(Validacion.TipoValidacion.NumerosYPunto, txtIva, miError, "El valor del iva tiene formato incorrecto"))
                    {
                        iva_ = true;
                    }
                    else
                        iva_ = false;
                }
                else
                    iva_ = false;
            }
        }

        /// <summary>
        /// Consultar IVA.
        /// </summary>
        private void ConsultaIva()
        {
            try
            {
                dgvIva.AutoGenerateColumns = false;
                dgvIva.DataSource = miIva.ListadoIva();
            }
            catch(Exception  ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        /// <summary>
        /// Carga los recursos del ensamblado usado en el formulario
        /// </summary>
        private void CargaRecurso()
        {
            try
            {
                imgCancelarStream = assembly.GetManifestResourceStream(imagenCancelar);
                imgCancelNuevoStream = assembly.GetManifestResourceStream(imagenCancelar_);
            }
            catch(Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        /// <summary>
        /// Consulta si existe el registro de IVA ingresado.
        /// </summary>
        /// <param name="valorIva">valor del IVA a comparar.</param>
        /// <returns></returns>
        private bool ExisteIva(double valorIva)
        {
            try
            {
                var res = miIva.ExisteIva(valorIva);
                if (!res)
                {
                    return true;
                }
                else
                {
                    OptionPane.MessageInformation("El iva ingresado ya existe.");
                    return false;
                }
            }
            catch(Exception ex)
            {
                OptionPane.MessageError(ex.Message);
                return false;
            }
        }
    }
}