using System;
using System.ComponentModel;
using System.Windows.Forms;
using BussinesLayer.Clases;
using Utilities;
using CustomControl;

namespace Aplicacion.Configuracion.FormaPago
{
    public partial class frmFormaPago : Form
    {
        public BussinesFormaPago miBussinesFormaPago;

        private ErrorProvider miError;

        public frmFormaPago()
        {
            InitializeComponent();
            miBussinesFormaPago = new BussinesFormaPago();
            miError = new ErrorProvider();
        }

        private void frmFormaPago_Load(object sender, EventArgs e)
        {
            ListaFormaPago();
            CompletaEventos.Completa += new CompletaEventos.CompletaAccion(CompletaEventos_Completa);
        }

        private void frmFormaPago_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.Escape))
            {
                this.Close();
            }
        }

        // Metodos de objetos del formularo

        private void txtFormaPago_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                btnGuardar_Click(this.btnGuardar, new EventArgs());
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtFormaPago.Text))
            {
                try
                {
                    miBussinesFormaPago.InsertarFormaPago(
                        new DTO.Clases.FormaPago { NombreFormaPago = txtFormaPago.Text });
                    OptionPane.MessageInformation("La Forma de Pago se ingreso correctamente.");
                    txtFormaPago.Text = "";
                    ListaFormaPago();
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
            else
            {
                miError.SetError(txtFormaPago, "El campo es requerido.");
            }
        }

        private void tsbtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult rta = MessageBox.Show("¿Esta seguro(a) de guardar los cambios?", "Forma de Pago",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rta.Equals(DialogResult.Yes))
                {
                    foreach (DataGridViewRow gRow in dgbFormaPago.Rows)
                    {
                        miBussinesFormaPago.HabilitaFormaPago(new DTO.Clases.FormaPago
                        {
                            IdFormaPago = Convert.ToInt32(gRow.Cells["Codigo"].Value),
                            Habilita = Convert.ToBoolean(gRow.Cells["Habilita"].Value)
                        });
                    }
                    OptionPane.MessageInformation("Los cambios se almacenaron con exito!");
                    ListaFormaPago();
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void tsBtnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgbFormaPago.RowCount != 0)
                {
                    var registro = this.dgbFormaPago.Rows[this.dgbFormaPago.CurrentCell.RowIndex];
                    var frmEdicion = new frmModificaFormaPago();
                    frmEdicion.IdFormaPago = Convert.ToInt32(registro.Cells["Codigo"].Value);
                    frmEdicion.txtNombre.Text = registro.Cells["Nombre"].Value.ToString();
                    frmEdicion.ShowDialog();
                }
                else
                {
                    OptionPane.MessageInformation("No hay registros para editar.");
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void tsbtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgbFormaPago.RowCount != 0)
                {
                    miBussinesFormaPago.EliminaFormaPago(Convert.ToInt32(
                                        dgbFormaPago.CurrentRow.Cells["Codigo"].Value));
                    OptionPane.MessageInformation("La Forma de Pago se eliminó con exito!");
                    ListaFormaPago();
                }
                else
                {
                    OptionPane.MessageInformation("No hay registros para eliminar.");
                }
            }
            catch (Exception)
            {
                OptionPane.MessageError("La Forma de Pago no se puede eliminar.");
            }
        }

        // Metodos

        private void ListaFormaPago()
        {
            try
            {
                miBussinesFormaPago = new BussinesFormaPago();
                dgbFormaPago.DataSource = miBussinesFormaPago.ListarFormaPago();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        void CompletaEventos_Completa(CompletaArgumentosDeEvento args)
        {
            try
            {
                if (Convert.ToString(args.MiObjeto).Equals("formaPago"))
                {
                    ListaFormaPago();
                }
            }
            catch { }
        }
    }
}