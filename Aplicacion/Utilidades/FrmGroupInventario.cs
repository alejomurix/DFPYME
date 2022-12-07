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
using System.Threading;

namespace Aplicacion.Utilidades
{
    public partial class FrmGroupInventario : Form
    {
        private BussinesUtilidades miBussinesUtilidades;

        private string DbOriginal;

        private string Db1;

        private string Db2;

        private DateTime Fecha;

        private Thread miThread;

        private OptionPane miOption;

        public FrmGroupInventario()
        {
            InitializeComponent();

            this.miBussinesUtilidades = new BussinesUtilidades();
        }

        private void FrmGroupInventario_Load(object sender, EventArgs e)
        {
        }

        private void btnAgrupar_Click(object sender, EventArgs e)
        {
           // var arreglo = Utilities.UseObject.MiSubString("-2417107001751", 3, 7);

            /*DialogResult rta = MessageBox.Show("¿Está seguro de agrupar los inventarios?", "Agrupación de inventarios",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rta.Equals(DialogResult.Yes))
            {
                this.DbOriginal = this.txtDbOrg.Text;
                this.Db1 = this.txtDb1.Text;
                this.Db2 = this.txtDb2.Text;
                this.Fecha = this.dtFecha.Value;

                this.groupBox1.Enabled = false;

                miOption = new OptionPane();
                miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Marquee;
                miOption.FrmProgressBar.Closed_ = true;
                miOption.ProgressShow("Espere mientras se realizan las operaciones necesarias...",
                    "Operacion en progreso");
                miThread = new Thread(Agrupar);
                miThread.Start();
            }*/
        }

        private void Agrupar()
        {
            try
            {
                var invFisico1 = this.miBussinesUtilidades.InventariosFisico(this.Db1, this.Fecha);
                var invFisico2 = this.miBussinesUtilidades.InventariosFisico(this.Db2, this.Fecha);

                foreach (var inv1 in invFisico1)
                {
                    invFisico2.Add(inv1);
                }

                var query = from data in invFisico2
                            group data by new
                            {
                                Codigo = data.CodigoProducto,
                                Idmedida = data.IdMedida,
                                Idcolor = data.IdColor,
                                Corte_ = data.Corte,
                                Nocorte = Convert.ToInt32(data.Cantidad),
                                Costo_ = data.Costo
                            }
                                into grupo
                                select new
                                {
                                    Codigo = grupo.Key.Codigo,
                                    Idmedida = grupo.Key.Idmedida,
                                    IdColor = grupo.Key.Idcolor,
                                    Corte_ = grupo.Key.Corte_,
                                    Nocorte = grupo.Key.Nocorte,
                                    Costo_ = grupo.Key.Costo_,
                                    Cantidad = grupo.Sum(s => s.CantidadFisico)
                                };
                var inventarios = new List<InventarioFisico>();
                foreach (var row in query)
                {
                    inventarios.Add(new InventarioFisico
                    {
                        CodigoProducto = row.Codigo,
                        IdMedida = row.Idmedida,
                        IdColor = row.IdColor,
                        Corte = row.Corte_,
                        Cantidad = row.Nocorte,
                        Costo = row.Costo_,
                        CantidadFisico = row.Cantidad
                    });
                }
                this.miBussinesUtilidades.ActualizarInventarioFisico(inventarios, this.DbOriginal);
                
                if (this.InvokeRequired)
                    this.Invoke(new Action(Finalizar));

                OptionPane.MessageInformation("La agrupación se realizo con éxito.");
            }
            catch (Exception ex)
            {
                if (this.InvokeRequired)
                    this.Invoke(new Action(Finalizar));
                OptionPane.MessageError(ex.Message);
            }
        }

        private void Finalizar()
        {
            miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Blocks;
            miOption.FrmProgressBar.Closed_ = false;
            miOption.FrmProgressBar.Close();

            this.groupBox1.Enabled = true;
        }
    }
}