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

namespace Aplicacion.Administracion.Caja
{
    public partial class FrmAperturaCaja : Form
    {
        private bool AperturaMatch = false;

        private ErrorProvider miError;

        private BussinesApertura miBussinesApertura;

        private BussinesTurno miBussinesTurno;

        private BussinesCaja miBussinesCaja;

        private DataTable Registros { set; get; }

        public FrmAperturaCaja()
        {
            InitializeComponent();
            miBussinesApertura = new BussinesApertura();
            miBussinesTurno = new BussinesTurno();
            miBussinesCaja = new BussinesCaja();
            miError = new ErrorProvider();
        }

        private void FrmAperturaCaja_Load(object sender, EventArgs e)
        {
            CargarElementos();
        }

        private void FrmAperturaCaja_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.F2))
            {
                this.btnGuardar_Click(this.btnGuardar, new EventArgs());
            }
            else
            {
                if (e.KeyData.Equals(Keys.Escape))
                {
                    this.Close();
                }
            }
        }

        private void txtApertura_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtApertura.Text))
            {
                if (Validacion.ConFormato
                    (Validacion.TipoValidacion.Numeros, txtApertura, miError, "El valor de la apertura tiene formato incorrecto."))
                {
                    AperturaMatch = true;
                }
                else
                {
                    AperturaMatch = false;
                }
            }
            else
            {
                txtApertura.Text = "0";
                AperturaMatch = true;
            }
        }

        private void txtApertura_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.btnGuardar_Click(this.btnGuardar, new EventArgs());
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            this.txtApertura_Validating(this.txtApertura, null);
            if (AperturaMatch)
            {
                try
                {
                    var idCaja = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_caja"));
                    var idTurno = Convert.ToInt32(cbTurnos.SelectedValue);
                    this.Registros = miBussinesApertura.RegistrosApertura(idCaja);
                    if (this.Registros.Rows.Count.Equals(0))  //if (String.IsNullOrEmpty(AppConfiguracion.ValorSeccion("id_apertura")))
                    {
                      /*  var fechasTurno = miBussinesTurno.FechasTurno(dtpFecha.Value);
                        if (fechasTurno.Rows.Count.Equals(0))
                        {*/
                            miBussinesTurno.IngresarFechaTurno(dtpFecha.Value, idCaja, idTurno);
                            var apertura = new Apertura();
                            apertura.Fecha = dtpFecha.Value;
                            apertura.Caja.Id = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_caja"));
                            apertura.Turno.Id = Convert.ToInt32(cbTurnos.SelectedValue);
                            apertura.Usuario.Id = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_user"));
                            apertura.Valor = Convert.ToInt32(txtApertura.Text);
                            var id = miBussinesApertura.Ingresar(apertura);
                            //AppConfiguracion.SaveConfiguration("id_apertura", id.ToString());
                            AppConfiguracion.SaveConfiguration("idturno", apertura.Turno.Id.ToString());
                            //AppConfiguracion.SaveConfiguration("fecha", DateTime.Now.ToShortDateString());
                            txtApertura.Text = "0";
                            OptionPane.MessageInformation("Los datos de la apertura se almacenarón con exito.");


                            /*MessageBox.Show("Guardo");
                            AppConfiguracion.SaveConfiguration("id_apertura", "6");
                            AppConfiguracion.SaveConfiguration("idturno", idTurno.ToString());*/
                       // }
                       /* else
                        {
                            var query = fechasTurno.AsEnumerable().Where(d => d.Field<int>("idcaja").Equals(idCaja) &&
                                                                              d.Field<int>("idturno").Equals(idTurno)).ToArray().Length;
                            if (query != 0) // ya esta el turno en esa fecha
                            {
                                OptionPane.MessageError("El turno seleccionado ya fue usado.");
                            }
                            else
                            {
                                miBussinesTurno.IngresarFechaTurno(dtpFecha.Value, idCaja, idTurno);
                                var apertura = new Apertura();
                                apertura.Fecha = dtpFecha.Value;
                                apertura.Caja.Id = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_caja"));
                                apertura.Turno.Id = Convert.ToInt32(cbTurnos.SelectedValue);
                                apertura.Usuario.Id = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_user"));
                                apertura.Valor = Convert.ToInt32(txtApertura.Text);
                                var id = miBussinesApertura.Ingresar(apertura);
                                //AppConfiguracion.SaveConfiguration("id_apertura", id.ToString());
                                AppConfiguracion.SaveConfiguration("idturno", apertura.Turno.Id.ToString());
                                //AppConfiguracion.SaveConfiguration("fecha", DateTime.Now.ToShortDateString());
                                txtApertura.Text = "0";
                                OptionPane.MessageInformation("Los datos de la apertura se almacenarón con exito.");
                                */
                                /*MessageBox.Show("Guardo");
                                AppConfiguracion.SaveConfiguration("id_apertura", "6");
                                AppConfiguracion.SaveConfiguration("idturno", idTurno.ToString());*/
                          //  }
                       // }

                        /*if (String.IsNullOrEmpty(AppConfiguracion.ValorSeccion("idturno")))
                        {
                            AppConfiguracion.SaveConfiguration("idturno", idTurno.ToString());
                            AppConfiguracion.SaveConfiguration("fecha", DateTime.Now.ToShortDateString());
                            MessageBox.Show("Guardo");
                        }
                        else
                        {
                            if (AppConfiguracion.ValorSeccion("fecha").Equals(DateTime.Now.ToShortDateString()))
                            {
                                if (AppConfiguracion.ValorSeccion("idturno").Equals(idTurno.ToString()))
                                {
                                    MessageBox.Show("Error");
                                }
                                else
                                {
                                    AppConfiguracion.SaveConfiguration("idturno", idTurno.ToString());
                                    MessageBox.Show("Guardo");
                                }
                            }
                            else
                            {
                                AppConfiguracion.SaveConfiguration("idturno", idTurno.ToString());
                                AppConfiguracion.SaveConfiguration("fecha", DateTime.Now.ToShortDateString());
                                MessageBox.Show("Guardo");
                            }*/

                            /*var idTurno = Convert.ToInt32(cbTurnos.SelectedValue);
                            if (AppConfiguracion.ValorSeccion("fecha").Equals(DateTime.Now.ToShortDateString()) &&
                                AppConfiguracion.ValorSeccion("idturno").Equals(idTurno.ToString()))
                            {
                                MessageBox.Show("Error");
                            }
                            else
                            {
                                var apertura_ = new Apertura();
                                apertura_.Turno.Id = Convert.ToInt32(cbTurnos.SelectedValue);

                                AppConfiguracion.SaveConfiguration("idturno", apertura_.Turno.Id.ToString());
                                AppConfiguracion.SaveConfiguration("fecha", DateTime.Now.ToShortDateString());
                                MessageBox.Show("Guardo");
                            }*/
                        //}

                        //var idTurno = Convert.ToInt32(cbTurnos.SelectedValue);
                        /*var apertura = new Apertura();
                        apertura.Fecha = dtpFecha.Value;
                        apertura.Caja.Id = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_caja"));
                        apertura.Turno.Id = Convert.ToInt32(cbTurnos.SelectedValue);
                        apertura.Usuario.Id = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_user"));
                        apertura.Valor = Convert.ToInt32(txtApertura.Text);
                        var id = miBussinesApertura.Ingresar(apertura);
                        AppConfiguracion.SaveConfiguration("id_apertura", id.ToString());
                        AppConfiguracion.SaveConfiguration("idturno", apertura.Turno.Id.ToString());
                        AppConfiguracion.SaveConfiguration("fecha", DateTime.Now.ToShortDateString());
                        txtApertura.Text = "0";
                        OptionPane.MessageInformation("Los datos de la apertura se almacenarón con exito.");*/
                    }
                    else
                    {
                        OptionPane.MessageError("El punto de venta ya tiene una apertura de caja.");
                    }
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void CargarElementos()
        {
            try
            {
                this.txtCaja.Text = miBussinesCaja.CajaId(
                    Convert.ToInt32(AppConfiguracion.ValorSeccion("id_caja"))).Numero.ToString();
                this.cbTurnos.DataSource = miBussinesTurno.Turnos();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }
    }
}