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

namespace Aplicacion.Ventas.Devolucion
{
    public partial class FrmConsultaRemision : Form
    {
        private BussinesDevolucion miBussinesDevolucion;

        public FrmConsultaRemision()
        {
            InitializeComponent();
            miBussinesDevolucion = new BussinesDevolucion();
        }

        private void FrmConsulta_Load(object sender, EventArgs e)
        {
            CargarUtilidades();
        }

        private void FrmConsultaRemision_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.Escape))
            {
                this.Close();
            }
        }

        private void tsBtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbCriterio_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(cbCriterio.SelectedValue);
            if (id != 2)
            {
                cbCriterio2.Enabled = true;
                cbCriterio2.SelectedValue = 2;
                cbCriterio2_SelectionChangeCommitted(this.cbCriterio2, new EventArgs());
                if (id == 1)
                {
                    txtCodigo.Text = "";
                    txtCodigo.Enabled = false;
                    btnBuscarCodigo.Enabled = false;
                }
                else
                {
                    txtCodigo.Enabled = true;
                    btnBuscarCodigo.Enabled = true;
                }
            }
            else
            {
                txtCodigo.Enabled = true;
                cbCriterio2.SelectedValue = 1;
                cbCriterio2_SelectionChangeCommitted(this.cbCriterio2, new EventArgs());
                cbCriterio2.Enabled = false;
            }
            txtCodigo.Focus();
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                btnBuscar_Click(this.btnBuscar, new EventArgs());
            }
        }

        private void cbCriterio2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cbCriterio2.SelectedValue).Equals(2))
            {
                dtpFecha1.Enabled = true;
                dtpFecha2.Enabled = false;
            }
            else
            {
                if (Convert.ToInt32(cbCriterio2.SelectedValue).Equals(3))
                {
                    dtpFecha1.Enabled = true;
                    dtpFecha2.Enabled = true;
                }
                else
                {
                    dtpFecha1.Enabled = false;
                    dtpFecha2.Enabled = false;
                    if (!Convert.ToInt32(cbCriterio.SelectedValue).Equals(2))
                    {
                        cbCriterio2.SelectedValue = 2;
                        cbCriterio2_SelectionChangeCommitted(this.cbCriterio2, new EventArgs());
                    }
                }
            }
        }



        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvFactura.AutoGenerateColumns = false;
            var id = Convert.ToInt32(cbCriterio.SelectedValue);
            var id2 = Convert.ToInt32(cbCriterio2.SelectedValue);
            switch (id)
            {
                case 1: //solo dev
                    {
                        if (id2.Equals(2)) //fecha simple
                        {
                        }
                        else  //periodo
                        {
                        }
                        break;
                    }
                case 2: //No de remision
                    {
                        ConsultaRemision(Convert.ToInt32(txtCodigo.Text));
                        break;
                    }
                case 3: //nit cliente
                    {
                        if (id2.Equals(2)) //fecha simple
                        {
                        }
                        else  //periodo
                        {
                        }
                        break;
                    }
                case 4: //nombre cliente
                    {
                        if (id2.Equals(2)) //fecha simple
                        {
                        }
                        else  //periodo
                        {
                        }
                        break;
                    }
            }



            
            //dgvFactura.DataSource = miBussinesDevolucion.ConsultaRemision(Convert.ToInt32(txtCodigo.Text));

            //dataGrid1.DataSource = miBussinesDevolucion.ConsultaFactura(txtCodigo.Text, true);
        }


        /// <summary>
        /// Carga en el formulario los datos necesarios para su visualización.
        /// </summary>
        private void CargarUtilidades()
        {
            var lst = new List<Inventario.Producto.Criterio>();
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 1,
                Nombre = "Solo Devoluciones"
            });
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 2,
                Nombre = "No. Remisión"
            });
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 3,
                Nombre = "Nit o C.C. del Cliente"
            });
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 4,
                Nombre = "Nombre del Cliente"
            });
            cbCriterio.DataSource = lst;

            /*lst = new List<Inventario.Producto.Criterio>();
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 1,
                Nombre = "Efectiva"
            });
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 2,
                Nombre = "Con saldo"
            });
            cbCriterio1.DataSource = lst;*/

            lst = new List<Inventario.Producto.Criterio>();
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 1,
                Nombre = ""
            });
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 2,
                Nombre = "Fecha"
            });
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 3,
                Nombre = "Periodo"
            });
            cbCriterio2.DataSource = lst;
            cbCriterio2.SelectedValue = 2;
            cbCriterio2_SelectionChangeCommitted(this.cbCriterio2, new EventArgs());
        }

        private void ConsultaRemision(int numero)
        {
            try
            {
                dgvFactura.DataSource = miBussinesDevolucion.ConsultaRemision(numero);
                if (dgvFactura.RowCount.Equals(0))
                {
                    OptionPane.MessageInformation("No se encontraron devoluciones de remisión con ese número.");
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }





    }
}