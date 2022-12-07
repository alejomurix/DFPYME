using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BussinesLayer.Clases;

namespace Aplicacion.Configuracion.Version
{
    public partial class FrmVersion : Form
    {
        private BussinesSistema miBussinesSistema;

        public FrmVersion()
        {
            InitializeComponent();
            miBussinesSistema = new BussinesSistema();
        }

        private void FrmVersion_Load(object sender, EventArgs e)
        {
            try
            {
                var sistema = miBussinesSistema.Sistema();
                lblNombre.Text = sistema.Nombre;
                lblVersion.Text = "Versión " + sistema.Version;
                lblAnioEmpresa.Text = "© " + sistema.Fecha.Year.ToString() + " " + sistema.Fabricante;
                lblDerechos.Text = sistema.Derecho;
                lblLicencia.Text = "Licencia " + sistema.Licencia;
            }
            catch (Exception ex)
            {
                CustomControl.OptionPane.MessageError(ex.Message);
            }
        }
    }
}