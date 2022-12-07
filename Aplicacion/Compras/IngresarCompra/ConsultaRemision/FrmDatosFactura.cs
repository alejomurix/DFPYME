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
using DTO.Clases;

namespace Aplicacion.Compras.IngresarCompra.ConsultaRemision
{
    public partial class FrmDatosFactura : Form
    {
        private ErrorProvider miError;

        private BussinesEstado miBussinesEstado;

        public FrmDatosFactura()
        {
            InitializeComponent();
            miBussinesEstado = new BussinesEstado();
        }

        private void FrmDatosFactura_Load(object sender, EventArgs e)
        {
            CargarDatos();
            miError = new ErrorProvider();
        }

        private void FrmDatosFactura_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.Escape))
            {
                this.Close();
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtNumeroFactura.Text))
            {
                DialogResult rta = MessageBox.Show("¿Desea Facturar la remisión?", "Facturar Remisión",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rta.Equals(DialogResult.Yes))
                {
                    miError.SetError(txtNumeroFactura, null);
                    var factura = new FacturaProveedor();
                    factura.Numero = txtNumeroFactura.Text;
                    factura.EstadoFactura.Id = Convert.ToInt32(cbFormaPago.SelectedValue);
                    factura.FechaIngreso = dtpFechaIngreso.Value;
                    factura.FechaLimite = dtpFechaLimite.Value;
                    factura.Caja.Id = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_caja"));
                    factura.Usuario.Id = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_user"));
                    CompletaEventos.CapEvenAbonoFact(factura);
                }
            }
            else
            {
                miError.SetError(txtNumeroFactura, "El número de factura es requerido.");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CargarDatos()
        {
            try
            {
                var tabla = miBussinesEstado.Lista();
                IEnumerable<DataRow> query = from data in tabla.AsEnumerable()
                                             where data.Field<int>("idestado") == 1 ||
                                                   data.Field<int>("idestado") == 2
                                             select data;
                cbFormaPago.DataSource = query.CopyToDataTable<DataRow>();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }
    }
}