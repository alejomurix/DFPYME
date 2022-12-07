using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DTO.Clases;
using BussinesLayer.Clases;
using Utilities;
using CustomControl;

namespace Aplicacion.Administracion.CajaDiario
{
    public partial class FrmConsultaCaja : Form
    {
        private int IdUser;

        private ToolTip miToolTip;

        private BussinesApertura miBussinesCaja;

        private BussinesFacturaVenta miBussinesVenta;

        private BussinesSaldo miBussinesSaldo;

        private BussinesBono miBussinesBono;

        public FrmConsultaCaja()
        {
            InitializeComponent();
            miBussinesCaja = new BussinesApertura();
            miToolTip = new ToolTip();
            miBussinesVenta = new BussinesFacturaVenta();
            miBussinesSaldo = new BussinesSaldo();
            miBussinesBono = new BussinesBono();
        }

        private void FrmConsultaCaja_Load(object sender, EventArgs e)
        {
            CompletaEventos.Completa += new CompletaEventos.CompletaAccion(CompletaEventos_Completa);
            CargarUtilidades();
        }

        private void FrmConsultaCaja_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.F5))
            {
                IdUser = 0;
                txtUsuario.Text = "";
            }
        }


        private void cbCriterio_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cbCriterio.SelectedValue).Equals(1))
            {
                dtpFecha1.Enabled = false;
            }
            else
            {
                dtpFecha1.Enabled = true;
            }
        }

        private void btnBuscarUser_Click(object sender, EventArgs e)
        {
            var frmUsuario = new Usuario.frmUsuarioSistema();
            frmUsuario.tpPermiso.SelectedIndex = 1;
            frmUsuario.tsBtnSeleccionar.Visible = true;
            frmUsuario.MdiParent = this.MdiParent;
            frmUsuario.Show();
        }



        //
        private void btnVer_Click(object sender, EventArgs e)
        {
            var idCaja = Convert.ToInt32(cbCaja.SelectedValue);
            if (Convert.ToInt32(cbCriterio.SelectedValue).Equals(1))//fecha simple
            {
                if (String.IsNullOrEmpty(txtUsuario.Text))//sin usuario
                {
                    ConsultarDatos(dtpFecha.Value, idCaja);
                }
                else//con usuario
                {
                }
            }
            else//periodo
            {
                if (String.IsNullOrEmpty(txtUsuario.Text))//sin usuario
                {
                }
                else//con usuario
                {
                }
            }
            /*var frmCaja = new Administracion.CajaDiario.FrmCajaDiario();
            frmCaja.Fecha = dtpFecha.Value;
            frmCaja.ShowDialog();
            this.Close();*/
        }

        private void CargarUtilidades()
        {
            miToolTip.SetToolTip(txtUsuario, "Limpiar Usuario [F5]");
            var lst = new List<Aplicacion.Inventario.Producto.Criterio>();
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 1,
                Nombre = "Fecha"
            });
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 2,
                Nombre = "Periodo"
            });
            cbCriterio.DataSource = lst;
            try
            {
                var tabla = new DataTable();
                tabla.Columns.Add(new DataColumn("idcaja", typeof(int)));
                tabla.Columns.Add(new DataColumn("numerocaja", typeof(string)));
                var row = tabla.NewRow();
                row["idcaja"] = 0;
                row["numerocaja"] = "Todas";
                tabla.Rows.Add(row);
                /*var tablaDB = miBussinesCaja.Cajas();
                foreach (DataRow row_ in tablaDB.Rows)
                {
                    var r = tabla.NewRow();
                    r["idcaja"] = row_["idcaja"];
                    r["numerocaja"] = row_["numerocaja"].ToString();
                    tabla.Rows.Add(r);
                }
                tablaDB.Rows.Clear();
                tablaDB.Columns.Clear();
                tablaDB.Clear();
                tablaDB = null;*/
                cbCaja.DataSource = tabla;
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        void CompletaEventos_Completa(CompletaArgumentosDeEvento args)
        {
            try
            {
                var user = (Inventario.Producto.Criterio)args.MiObjeto;
                IdUser = user.Id;
                txtUsuario.Text = user.Nombre;
            }
            catch { }
        }

        private void ConsultarDatos(DateTime fecha, int idCaja)
        {
            try
            {
                if (idCaja.Equals(0))//todas las cajas
                {
                    var ds = miBussinesVenta.TotalFacturasContado(fecha);
                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        var n = ds.Tables[0].AsEnumerable().Sum(s => s.Field<int>("Total"));
                        txtVentaContado.Text = UseObject.InsertSeparatorMil(n.ToString());
                    }
                    dgvIvaContado.DataSource = miBussinesVenta.IvaFacturaContado(idCaja, fecha, false);
                    dgvIvaContado.DataMember = "IvaGravado";

                    var canjes = miBussinesSaldo.Canjes(idCaja, fecha, false);
                    txtCruceAnticipos.Text = UseObject.InsertSeparatorMil(
                        canjes.Tables[0].AsEnumerable().Sum(s => s.Field<int>("valor")).ToString());

                    var CruceBonos = miBussinesBono.Seguimientos(idCaja, fecha, false);
                    txtCruceBonos.Text = UseObject.InsertSeparatorMil(
                        CruceBonos.Tables[0].AsEnumerable().Sum(s => s.Field<int>("valor")).ToString());
                }
                else//una caja
                {
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }
    }
}