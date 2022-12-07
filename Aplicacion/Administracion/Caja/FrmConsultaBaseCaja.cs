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

namespace Aplicacion.Administracion.Caja
{
    public partial class FrmConsultaBaseCaja : Form
    {
        private BussinesApertura miBussinesCaja;

        private BussinesUsuario miBussinesUsuario;

        /// <summary>
        /// Obteien o establece el numero que indica que iteracion se realizo.
        /// </summary>
        private int Iteracion;

        /// <summary>
        /// Obtiene o establece el valor del registro a segir o registro base.
        /// </summary>
        private int RowCaja;

        /// <summary>
        /// Obtiene o establece el número maximo de registro a cargar.
        /// </summary>
        private int RowMaxCaja;

        /// <summary>
        /// Obtiene o establece el total de registros en la base de datos.
        /// </summary>
        private long TotalRowCaja;

        /// <summary>
        /// Obtiene o establece el número total de paginas que componen la consulta.
        /// </summary>
        private long PaginasCaja;

        /// <summary>
        /// Obtiene o establece el número de la pagina actual.
        /// </summary>
        private int CurrentPageCaja;

        private DateTime FechaActual;

        public FrmConsultaBaseCaja()
        {
            miBussinesCaja = new BussinesApertura();
            miBussinesUsuario = new BussinesUsuario();
            RowMaxCaja = 8;
            InitializeComponent();
        }

        private void FrmConsultaBaseCaja_Load(object sender, EventArgs e)
        {

        }

        private void tsBtnListarTodos_Click(object sender, EventArgs e)
        {
            RowCaja = 0;
            Iteracion = 1;
            CurrentPageCaja = 1;
            try
            {
                /*dgvCaja.DataSource = miBussinesCaja.Listado(RowCaja, RowMaxCaja);
                TotalRowCaja = miBussinesCaja.GetRowsListado();*/
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            CalcularPaginas();
        }

        private void tsBtnEditar_Click(object sender, EventArgs e)
        {
            if (dgvCaja.RowCount != 0)
            {
                string rta = CustomControl.OptionPane.OptionBox
                    ("Ingresar contraseña de Administrador .", "Administrador", CustomControl.OptionPane.Icon.LoginAdmin);
                if (!rta.Equals("false"))
                {
                    if (miBussinesUsuario.VerificarUsuarioAdmin(Encode.Encrypt(rta)))
                    {
                        var frmEdita = new FrmEditaBaseCaja();
                        frmEdita.Id = Convert.ToInt32(dgvCaja.CurrentRow.Cells["Id"].Value);
                        frmEdita.MdiParent = this.MdiParent;
                        frmEdita.Show();
                    }
                    else
                    {
                        OptionPane.MessageError("La contraseña es Incorrecta.");
                    }
                }
            }
            else
            {
                OptionPane.MessageInformation("No hay registro para editar");
            }
        }

        private void tsBtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            RowCaja = 0;
            Iteracion = 2;
            CurrentPageCaja = 1;
            FechaActual = dtpFecha.Value;
            try
            {
                /*dgvCaja.DataSource = miBussinesCaja.Listado(dtpFecha.Value, RowCaja, RowMaxCaja);
                TotalRowCaja = miBussinesCaja.GetRowsListado(dtpFecha.Value);*/
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            CalcularPaginas();
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            if (CurrentPageCaja > 1)
            {
                var paginaActual = CurrentPageCaja;
                for (int i = paginaActual; i > 1; i--)
                {
                    RowCaja = RowCaja - RowMaxCaja;
                    CurrentPageCaja--;
                }
                try
                {
                    switch (Iteracion)
                    {
                        case 1:
                            {
                                //dgvCaja.DataSource = 
                                //    miBussinesCaja.Listado(RowCaja, RowMaxCaja);
                                break;
                            }
                        case 2:
                            {
                               // dgvCaja.DataSource =
                               //     miBussinesCaja.Listado(FechaActual, RowCaja, RowMaxCaja);
                                break;
                            }
                    }
                    lblStatusCaja.Text = CurrentPageCaja + " / " + PaginasCaja;
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (CurrentPageCaja > 1)
            {
                RowCaja = RowCaja - RowMaxCaja;
                if (RowCaja <= 0)
                    RowCaja = 0;
                try
                {
                    switch (Iteracion)
                    {
                        case 1:
                            {
                               // dgvCaja.DataSource =
                                //    miBussinesCaja.Listado(RowCaja, RowMaxCaja);
                                break;
                            }
                        case 2:
                            {
                               // dgvCaja.DataSource =
                                  //  miBussinesCaja.Listado(FechaActual, RowCaja, RowMaxCaja);
                                break;
                            }
                    }
                    lblStatusCaja.Text = CurrentPageCaja + " / " + PaginasCaja;
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (CurrentPageCaja < PaginasCaja)
            {
                RowCaja = RowCaja + RowMaxCaja;
                try
                {
                    switch (Iteracion)
                    {
                        case 1:
                            {
                                //dgvCaja.DataSource =
                                //    miBussinesCaja.Listado(RowCaja, RowMaxCaja);
                                break;
                            }
                        case 2:
                            {
                               // dgvCaja.DataSource =
                                //    miBussinesCaja.Listado(FechaActual, RowCaja, RowMaxCaja);
                                break;
                            }
                    }
                    lblStatusCaja.Text = CurrentPageCaja + " / " + PaginasCaja;
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void btnFin_Click(object sender, EventArgs e)
        {
            if (CurrentPageCaja < PaginasCaja)
            {
                var paginaActual = CurrentPageCaja;
                for (int i = paginaActual; i < PaginasCaja; i++)
                {
                    RowCaja = RowCaja + RowMaxCaja;
                    CurrentPageCaja++;
                }
                try
                {
                    switch (Iteracion)
                    {
                        case 1:
                            {
                               // dgvCaja.DataSource =
                                //    miBussinesCaja.Listado(RowCaja, RowMaxCaja);
                                break;
                            }
                        case 2:
                            {
                                //dgvCaja.DataSource =
                                //    miBussinesCaja.Listado(FechaActual, RowCaja, RowMaxCaja);
                                break;
                            }
                    }
                    lblStatusCaja.Text = CurrentPageCaja + " / " + PaginasCaja;
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        /// <summary>
        /// Calcula y muestra el número de paginas devueltas en la consulta.
        /// </summary>
        private void CalcularPaginas()
        {
            PaginasCaja = TotalRowCaja / RowMaxCaja;
            if (TotalRowCaja % RowMaxCaja != 0)
                PaginasCaja++;
            if (CurrentPageCaja > PaginasCaja)
                CurrentPageCaja = 0;
            lblStatusCaja.Text = CurrentPageCaja + " / " + PaginasCaja;
        }
    }
}