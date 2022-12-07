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

namespace FormulariosSistema
{
    public partial class FrmCIIUList : Form
    {
        private RepositoryModel repositoryModel;

        public FrmCIIUList()
        {
            try
            {
                InitializeComponent();
                this.repositoryModel = new RepositoryModel();
                this.dgvCIIUList.DataSource = this.repositoryModel.CIIUList();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }


        private void FrmCIIUList_Load(object sender, EventArgs e)
        {

        }

        
    }
}