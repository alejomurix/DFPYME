using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utilities;
using CustomControl;
using BussinesLayer.Clases;

namespace Aplicacion.Administracion.CajaRemision
{
    public partial class FrmConsultaVentaRemision : Form
    {
        private BussinesEmpresa miBussinesEmpresa;

        private BussinesRemision miBussinesRemision;

        public FrmConsultaVentaRemision()
        {
            InitializeComponent();
            //this.miBussinesCaja = new BussinesLayer.Clases.BussinesCaja();
            try
            {
                miBussinesEmpresa = new BussinesEmpresa();
                miBussinesRemision = new BussinesRemision();
            }
            catch (Exception ex)
            {
                CustomControl.OptionPane.MessageError(ex.Message);
            }
        }

        private void FrmConsultaCaja_Load(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void FrmConsultaCajaFecha_KeyDown(object sender, KeyEventArgs e){}

        private void btnComprobante_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow empresaRow = miBussinesEmpresa.PrintEmpresa().Tables[0].AsEnumerable().First();
                var ventasRemision = miBussinesRemision.VentasRemision(dtpFecha.Value);

                Ticket ticket = new Ticket();

                ticket.UseItem = false;
                ticket.AddHeaderLine(empresaRow["Nombre"].ToString().ToUpper());
                ticket.AddHeaderLine(empresaRow["Juridico"].ToString());
                ticket.AddHeaderLine("NIT " + UseObject.InsertSeparatorMilMasDigito(empresaRow["Nit"].ToString()));
                ticket.AddHeaderLine("Régimen: " + empresaRow["Regimen"].ToString());
                ticket.AddHeaderLine(empresaRow["Direccion"].ToString());
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("INFORME DE VENTAS DE REMISIÓN");


            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

    }
}