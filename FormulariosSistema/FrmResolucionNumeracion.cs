using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BussinesLayer.Bussines;
using BussinesLayer.Clases;
using Utilities;
using CustomControl;
using System.Threading;
using DTO;
using DTO.Clases;
using DataAccessLayer.Repository;
using DataAccessLayer.DataSets;
using DataAccessLayer.Models;

namespace FormulariosSistema
{
    public partial class FrmResolucionNumeracion : Form
    {
        /// <summary>
        /// Representa un objeto para mostrar mensajes de error
        /// </summary>
        private ErrorProvider miError = new ErrorProvider();

        

      

        private readonly RepositoryModel repositoryModel;





        public FrmResolucionNumeracion()
        {
            InitializeComponent();
            dgvFormularios.AutoGenerateColumns = false;
            

        }

       


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                
                
            }
            catch (Exception ex)
            {
                OptionPane.MessageError("Ocurrió un error al guardar el cliente.\n" + ex.Message);
            }
        }

        private void FrmResolucionNumeracion_Load(object sender, EventArgs e)
        {

        }

    }
}