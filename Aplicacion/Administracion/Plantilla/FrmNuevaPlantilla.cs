using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utilities;
using DTO.Clases;
using CustomControl;
using BussinesLayer.Clases;

namespace Aplicacion.Administracion.Plantilla
{
    public partial class FrmNuevaPlantilla : Form
    {
       /* private bool CodigoMatch;

        private bool NombreMatch;*/

        private ErrorProvider miError;

        private DataTable TCuentas { set; get; }

        private BindingSource bSource;

        private int Cont { set; get; }

        private BussinesPlantilla miBussinesPlantilla;

        public FrmNuevaPlantilla()
        {
            InitializeComponent();
           /*this.CodigoMatch = false;
            this.NombreMatch = false;*/
            this.miError = new ErrorProvider();
            this.CrearTabla();
            this.dgvCuentas.AutoGenerateColumns = false;
            this.bSource = new BindingSource();
            this.dgvCuentas.DataSource = this.bSource;
            this.Cont = 1;
            this.miBussinesPlantilla = new BussinesPlantilla();
        }

        private void FrmNuevaPlantilla_Load(object sender, EventArgs e)
        {
            CompletaEventos.Completa += new CompletaEventos.CompletaAccion(CompletaEventos_Completa);
            this.bSource.DataSource = this.TCuentas;
        }

        private void FrmNuevaPlantilla_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.F2))
            {
                this.btnGuardar_Click(this.btnGuardar, new EventArgs());
            }
            else
            {
                if (e.KeyData.Equals(Keys.Escape))
                {
                    this.Close();
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.txtCodigo.Text))
            {
                if (!String.IsNullOrEmpty(this.txtNombre.Text))
                {
                    this.miError.SetError(this.txtCodigo, null);
                    this.miError.SetError(this.txtNombre, null);
                    if (this.dgvCuentas.RowCount != 0)
                    {
                        try
                        {
                            var plantilla = new DTO.Clases.Plantilla();
                            plantilla.Codigo = this.txtCodigo.Text.ToUpper();
                            plantilla.Concepto = this.txtNombre.Text.ToUpper();
                            plantilla.Cuentas = Cuentas();
                            miBussinesPlantilla.IngresarPlantilla(plantilla);
                            OptionPane.MessageInformation("La plantilla se ingresó con exito.");
                            this.txtCodigo.Focus();
                            this.txtCodigo.Text = "";
                            this.txtNombre.Text = "";
                            while (this.dgvCuentas.RowCount != 0)
                            {
                                this.dgvCuentas.Rows.RemoveAt(0);
                            }
                            this.TCuentas.Rows.Clear();
                            CompletaEventos.CapturaEvento(new ObjectAbstract
                            {
                                Id = 240
                            });
                        }
                        catch (Exception ex)
                        {
                            OptionPane.MessageError(ex.Message);
                        }
                    }
                    else
                    {
                        OptionPane.MessageInformation("Debe cargar las cuentas para la plantilla.");
                    }
                }
                else
                {
                    this.miError.SetError(this.txtNombre, "El campo es requerido.");
                }
            }
            else
            {
                this.miError.SetError(this.txtCodigo, "El campo es requerido.");
            }
        }

        private void tsSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNueva_Click(object sender, EventArgs e)
        {
            var frmSeleccionarCta = new FrmSeleccionCuenta();
            frmSeleccionarCta.ShowDialog();
        }

        private void CrearTabla()
        {
            this.TCuentas = new DataTable();
            this.TCuentas.Columns.Add(new DataColumn("Id", typeof(int)));
            this.TCuentas.Columns.Add(new DataColumn("IdSCta", typeof(int)));
            this.TCuentas.Columns.Add(new DataColumn("Cuenta", typeof(string)));
            this.TCuentas.Columns.Add(new DataColumn("Descripcion", typeof(string)));
            this.TCuentas.Columns.Add(new DataColumn("IdNat", typeof(int)));
            this.TCuentas.Columns.Add(new DataColumn("Nat", typeof(string)));
        }

        void CompletaEventos_Completa(CompletaArgumentosDeEvento args)
        {
            try
            {
                var obj = (ObjectAbstract)args.MiObjeto;
                if (obj.Id.Equals(660))
                {
                    var ctaAux = (CuentaAuxiliar)obj.Objeto;
                    var row = this.TCuentas.NewRow();
                    row["Id"] = this.Cont;
                    row["IdSCta"] = ctaAux.IdCuenta;
                    row["Cuenta"] = ctaAux.Numero;
                    row["Descripcion"] = ctaAux.Nombre;
                    row["IdNat"] = ctaAux.IdNaturaleza;
                    row["Nat"] = ctaAux.Naturaleza;
                    this.TCuentas.Rows.Add(row);
                    this.Cont++;
                    RecargarGridView();
                }
            }
            catch { }
        }

        private void RecargarGridView()
        {
            IEnumerable<DataRow> query = from data in this.TCuentas.AsEnumerable()
                                         orderby data.Field<int>("Id") ascending
                                         select data;
            DataTable copy = query.CopyToDataTable<DataRow>();
            this.bSource.DataSource = copy;
        }

        private List<CuentaPlantilla> Cuentas()
        {
            var lst = new List<CuentaPlantilla>();
            foreach(DataRow cRow in this.TCuentas.Rows)
            {
                bool nat = false;
                if (Convert.ToInt32(cRow["IdNat"]).Equals(1))
                {
                    nat = true;
                }
                lst.Add(new CuentaPlantilla
                {
                    IdCuenta = Convert.ToInt32(cRow["IdSCta"]),
                    Naturaleza = nat
                });
            }
            return lst;
        }
    }
}