using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataAccessLayer.Repository;
using DataAccessLayer.Models;
using CustomControl;
using DTO;
using Utilities;

namespace FormulariosSistema
{
    public partial class FrmIncomeFE : Form
    {
        public int IdCaja { set; get; }

        public DateTime BeginDate { set; get; }

        public DateTime EndDate { set; get; }

        private RepositoryModel repositoryModel;

        private DataTable Payments; 

        public FrmIncomeFE()
        {
            InitializeComponent();
            this.dgvIngresos.AutoGenerateColumns = false;

            try
            {
                this.repositoryModel = new RepositoryModel();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void FrmProductList_Load(object sender, EventArgs e)
        {
            try
            {
                this.Payments = this.repositoryModel.Payments(this.IdCaja, this.BeginDate, this.EndDate);
                this.dgvIngresos.DataSource = this.Payments;
                var pays = from p in Payments.AsEnumerable()
                           group p by new { nombre = p.Field<string>("nombre") }
                               into paysm
                               orderby paysm.Key.nombre
                               select new
                               {
                                   nombre = paysm.Key.nombre,
                                   valor = Math.Round(paysm.Sum(s => s.Field<double>("valor")), 2)
                               };
                this.dgResumen.DataSource = pays.ToList();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void FrmProductList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals((char)Keys.Escape))
            {
                this.Close();
            }
        }
    }
}