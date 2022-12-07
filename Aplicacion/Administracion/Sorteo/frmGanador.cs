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

namespace Aplicacion.Administracion.Sorteo
{
    public partial class frmGanador : Form
    {

        public DTO.Clases.Sorteo miSorteo;

        public BussinesSorteo miBussinesSorteo;

        public int idSorteo { set; get; }

        public frmGanador()
        {
            InitializeComponent();
            miBussinesSorteo = new BussinesSorteo();
        }

        private void frmGanador_Load(object sender, EventArgs e)
        {
            lblNSorteo.Text = idSorteo.ToString();
        }

        private void btnBuscarGanador_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtNFacturaGanador.Text))
                {
                    var miCliente = miBussinesSorteo.ClienteGanadorSorteo
                        (idSorteo, Convert.ToInt32(txtNFacturaGanador.Text));
                    if (!String.IsNullOrEmpty(miCliente.NitCliente))
                    {
                        txtDocumentoGanador.Text = miCliente.NitCliente;
                        txtNombreGanador.Text = miCliente.NombresCliente;
                        txtTelefonoGanador.Text = miCliente.TelefonoCliente;
                        txtNumeroCelularGanador.Text = miCliente.CelularCliente;
                    }
                    else
                    {
                        OptionPane.MessageInformation("No se encontro ningun registro.");
                    }
                }
                else
                {
                    OptionPane.MessageInformation("El numero de la factura es requerido.");
                }

            }
            catch (Exception ex)
            {
                OptionPane.MessageError(" Error al Mostrar el cliente." + ex.Message);
            }
        }     

        private void tsbtnGuardarGanador_Click(object sender, EventArgs e)
        {
            try
            {
                if (idSorteo > 0 && !String.IsNullOrEmpty(txtNFacturaGanador.Text))
                {
                    if (!String.IsNullOrEmpty(txtDocumentoGanador.Text))
                    {
                        DialogResult r = MessageBox.Show("Esta seguro que desea guardar el ganador.", "Edicion",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                        if (r == DialogResult.Yes)
                        {
                            miBussinesSorteo.IngresarGanador(idSorteo, Convert.ToString(txtNFacturaGanador.Text));
                            lblNSorteo.Text = "0";
                            idSorteo = 0;
                            txtNFacturaGanador.Text = "";
                            txtDocumentoGanador.Text = "";
                            txtNombreGanador.Text = "";
                            txtNumeroCelularGanador.Text = "";
                            txtTelefonoGanador.Text = "";
                        }
                        else
                        {
                            txtNFacturaGanador.Text = "";
                            lblNSorteo.Text = "0";
                            idSorteo = 0;
                            txtNFacturaGanador.Text = "";
                            txtDocumentoGanador.Text = "";
                            txtNombreGanador.Text = "";
                            txtNumeroCelularGanador.Text = "";
                            txtTelefonoGanador.Text = "";
                        }
                    }
                    else
                    {
                        OptionPane.MessageInformation("Ingrese primero el ganador de la factura ganadora");
                    }
                }
                else
                {
                    OptionPane.MessageInformation("La factura o el sorteo no estan relacionados a un sorteo.");
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError("Error al insertar el ganador." + ex.Message);
            }
        }

        private void tsbtnSalirGanador_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}