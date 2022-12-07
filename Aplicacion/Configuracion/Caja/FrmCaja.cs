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
using DTO.Clases;
using Utilities;

namespace Aplicacion.Configuracion.Caja
{
    public partial class FrmCaja : Form
    {
        private ErrorProvider miError;

        private BussinesConsecutivo miBussinesConsecutivo;

        private BussinesCaja miBussinesCaja;

        private BussinesTurno miBussinesTurno;

        private bool RangoUnoMatch;

        private bool RangoDosMatch;

        public FrmCaja()
        {
            InitializeComponent();
            RangoUnoMatch = false;
            RangoDosMatch = false;
            miError = new ErrorProvider();
            miBussinesConsecutivo = new BussinesConsecutivo();
            miBussinesCaja = new BussinesCaja();
            miBussinesTurno = new BussinesTurno();
        }

        private void FrmCaja_Load(object sender, EventArgs e)
        {
            CargarElementos();
        }

        private void llGenerarCaja_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                txtNoCaja.Text = miBussinesConsecutivo.Consecutivo("Caja");
                var caja = new DTO.Clases.Caja();
                caja.Numero = Convert.ToInt32(txtNoCaja.Text);
                caja.Estado = true;
                miBussinesCaja.Ingresar(caja);
                CargarElementos();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void btnGuardarCaja_Click(object sender, EventArgs e)
        {
            try
            {
                DataRowView rowCaja = (DataRowView)cbCajas.SelectedItem;
                var caja = new DTO.Clases.Caja
                {
                    Id = Convert.ToInt32(rowCaja["idcaja"]),
                    Numero = Convert.ToInt32(rowCaja["numerocaja"]),
                    Estado = Convert.ToBoolean(rowCaja["estado"])
                };
                if (caja.Estado)
                {
                    miError.SetError(cbCajas, null);
                    AppConfiguracion.SaveConfiguration("id_caja", caja.Id.ToString());
                    AppConfiguracion.SaveConfiguration("no_caja", caja.Numero.ToString());
                    AppConfiguracion.SaveConfiguration("station_name", this.txtNameCaja.Text);
                    miBussinesCaja.ReservarCaja(caja.Id);
                    
                    OptionPane.MessageInformation("El número de caja se asigno con exito.");
                    CargarElementos();
                }
                else
                {
                    OptionPane.MessageInformation("El número de caja ya se encuentra reservado.");
                    miError.SetError(cbCajas, "El número de caja ya se encuentra reservado.");
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void txtRangoUno_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(txtRangoUno, miError, "El campo es requerido."))
            {
                if (Validacion.ConFormato(Validacion.TipoValidacion.Numeros,
                    txtRangoUno, miError, "En número que ingreso es incorrecto."))
                {
                    RangoUnoMatch = true;
                }
                else
                {
                    RangoUnoMatch = false;
                }
            }
            else
            {
                RangoUnoMatch = false;
            }
        }

        private void txtRangoDos_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(txtRangoDos, miError, "El campo es requerido."))
            {
                if (Validacion.ConFormato(Validacion.TipoValidacion.Numeros,
                    txtRangoDos, miError, "En número que ingreso es incorrecto."))
                {
                    RangoDosMatch = true;
                }
                else
                {
                    RangoDosMatch = false;
                }
            }
            else
            {
                RangoDosMatch = false;
            }
        }

        private void btnGuardarTurno_Click(object sender, EventArgs e)
        {
            try
            {
                this.txtRangoUno_Validating(this.txtRangoUno, null);
                this.txtRangoDos_Validating(this.txtRangoDos, null);
                if (RangoUnoMatch && RangoDosMatch)
                {
                    if (miBussinesTurno.Turnos().Rows.Count == 0)
                    {
                        var tmp = "";
                        if (Convert.ToInt32(txtRangoUno.Text) > Convert.ToInt32(txtRangoDos.Text))
                        {
                            tmp = txtRangoUno.Text;
                            txtRangoUno.Text = txtRangoDos.Text;
                            txtRangoDos.Text = tmp;
                        }
                        for (int i = Convert.ToInt32(txtRangoUno.Text); i <= Convert.ToInt32(txtRangoDos.Text); i++)
                        {
                            var turno = new Turno();
                            turno.Numero = i;
                            miBussinesTurno.Ingresar(turno);
                        }
                        CargarElementos();
                        txtRangoUno.Text = "";
                        txtRangoDos.Text = "";
                        OptionPane.MessageInformation("Los turnos se establecieron con éxito.");
                    }
                    else
                    {
                        OptionPane.MessageInformation("Los turnos ya se encuentran establecidos.");
                    }
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void CargarElementos()
        {
            try
            {
                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("reqApertura")))
                {
                    chkRequerirApertura.Checked = true;
                }
                cbCajas.DataSource = miBussinesCaja.Cajas();
                var turnos = miBussinesTurno.Turnos();
                if (turnos.Rows.Count != 0)
                {
                    lblRangoUno.Text = turnos.AsEnumerable().First()["numero"].ToString();
                    lblRangoDos.Text = turnos.AsEnumerable().Last()["numero"].ToString();
                }
                var idCaja = AppConfiguracion.ValorSeccion("id_caja");
                if (!String.IsNullOrEmpty(idCaja))
                {
                    txtActualNoCaja.Text = miBussinesCaja.CajaId(Convert.ToInt32(idCaja)).Numero.ToString();
                }
                var idTurno = AppConfiguracion.ValorSeccion("idturno");
                if (!String.IsNullOrEmpty(idTurno))
                {
                    lblNoTurno.Text = miBussinesTurno.TurnoId(Convert.ToInt32(idTurno)).Numero.ToString();
                }

                this.txtNameCaja.Text = AppConfiguracion.ValorSeccion("station_name");
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void btnGuardarReqApertura_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkRequerirApertura.Checked)
                {
                    AppConfiguracion.SaveConfiguration("reqApertura", "true");
                }
                else
                {
                    AppConfiguracion.SaveConfiguration("reqApertura", "false");
                }
                OptionPane.MessageInformation("Los datos se almacenaron con exito.");
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }
    }
}