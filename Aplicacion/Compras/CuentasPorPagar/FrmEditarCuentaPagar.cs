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
using Utilities;

namespace Aplicacion.Compras.CuentasPorPagar
{
    public partial class FrmEditarCuentaPagar : Form
    {
        public CuentaPagar Cuenta { set; get; }

        public RetencionConcepto Retencion { set; get; }

        public int SubTotal { set; get; }

        private Empresa MiEmpresa { set; get; }

        private int IdCtaCuentaPagar { set; get; }

        private bool Transfer { set; get; }

        private Cliente Tercero { set; get; }

        private ToolTip miToolTip;

        private bool AplicaRete;

        private int IdRubroRetencion;

        List<RetencionConcepto> Retenciones { set; get; }

        private BussinesEmpresa miBussinesEmpresa;

        private BussinesTipoDocumento miBussinesTipoDoc;

        private BussinesConsecutivo miBussinesConsecutivo;

        private BussinesBeneficio miBussinesTercero;

        private BussinesRetencion miBussinesRetencion;

        private BussinesCuentaPagar miBussinesCuentaPagar;

        public FrmEditarCuentaPagar()
        {
            InitializeComponent();
            this.Cuenta = new CuentaPagar();
            this.Retencion = new RetencionConcepto();
            this.SubTotal = 0;
            this.miToolTip = new ToolTip();
            this.Transfer = false;
            this.AplicaRete = false;
            this.IdRubroRetencion = 2;

            miBussinesEmpresa = new BussinesEmpresa();
            miBussinesTipoDoc = new BussinesTipoDocumento();
            miBussinesConsecutivo = new BussinesConsecutivo();
            miBussinesTercero = new BussinesBeneficio();
            miBussinesRetencion = new BussinesRetencion();

            miBussinesCuentaPagar = new BussinesCuentaPagar();

            try
            {
                MiEmpresa = miBussinesEmpresa.ObtenerEmpresa();
                this.IdCtaCuentaPagar = Convert.ToInt32(AppConfiguracion.ValorSeccion("ctaCuentaPagar"));
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void FrmCuentaPagar_Load(object sender, EventArgs e)
        {
            CargarDatos();
            CargarCuenta();
            CompletaEventos.Completaz +=
                new CompletaEventos.CompletaAccionz(CompletaEventos_Completaz);
            CompletaEventos.Completabo += new CompletaEventos.CompletaAccionbo(CompletaEventos_Completabo);
        }

        private void FrmEditarCuentaPagar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.F2))
            {
                this.tsBtnGuardar_Click(this.tsBtnGuardar, new EventArgs());
            }
            else
            {
                if (e.KeyData.Equals(Keys.Escape))
                {
                    this.Close();
                }
            }
        }

        private void tsBtnGuardar_Click(object sender, EventArgs e)
        {
            if (this.Tercero != null)
            {
                if (!String.IsNullOrEmpty(txtNumero.Text))
                {
                    try
                    {
                        CuentaPagar cuenta = new CuentaPagar();
                        cuenta.Id = this.Cuenta.Id;
                        cuenta.IdCuenta = Convert.ToInt32(cbCuentas.SelectedValue);
                        cuenta.IdTercero = this.Tercero.IdTipoCliente;
                        cuenta.IdTipo = this.Cuenta.IdTipo;
                        cuenta.IdTipoEdit = Convert.ToInt32(cbDocumento.SelectedValue);
                        if (Convert.ToInt32(cbDocumento.SelectedValue).Equals(3)) // Documento Equivalente.
                        {
                            cuenta.Numero = miBussinesConsecutivo.Consecutivo("Documento");
                        }
                        else // Factura y Remisión.
                        {
                            cuenta.Numero = txtNumero.Text;
                        }
                        cuenta.FechaDocumento = dtpFecha.Value;
                        cuenta.FechaLimite = dtpLimite.Value;
                        cuenta.Retenciones.Add(this.Retencion);
                        miBussinesCuentaPagar.EditarCuentaPagar(cuenta);
                        this.Cuenta.IdTipo = cuenta.IdTipoEdit;
                        CompletaEventos.CapturaEvento(new ObjectAbstract
                        {
                            Id = 360,
                            Objeto = null
                        });
                        OptionPane.MessageInformation("Los datos se editaron con exito.");
                    }
                    catch (Exception ex)
                    {
                        OptionPane.MessageError(ex.Message);
                    }
                }
                else
                {
                    OptionPane.MessageInformation("El campo Número es requerido.");
                }
            }
            else
            {
                OptionPane.MessageInformation("Debe ingresar un Tercero.");
            }
        }

        private void tsBtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                try
                {
                    var tTercero = miBussinesTercero.BeneficiariosNit(txtNit.Text);
                    if (tTercero.Rows.Count.Equals(0))
                    {
                        DialogResult rta = MessageBox.Show("El Tercero no existe. \n¿Desea Crearlo?", "Anticipos y Préstamos",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (rta.Equals(DialogResult.Yes))
                        {
                            var frmBeneficia = new Beneficiario.FrmBeneficio();
                            frmBeneficia.txtId.Text = txtNit.Text;
                            frmBeneficia.Add = true;
                            Transfer = true;
                            frmBeneficia.ShowDialog();
                        }
                    }
                    else
                    {
                        var query = (from data in tTercero.AsEnumerable()
                                     select data).First();
                        this.Tercero = new Cliente
                        {
                            IdTipoCliente = Convert.ToInt32(query["id"]),
                            IdRegimen = Convert.ToInt32(query["idregimen"]),
                            NitCliente = query["nit"].ToString(),
                            NombresCliente = query["nombre"].ToString(),
                            CelularCliente = query["telefono"].ToString()
                        };
                        txtTercero.Text = "NIT o CC: " + Tercero.NitCliente + " - " + Tercero.NombresCliente;
                        txtNit.Text = "";
                        ValidarRetencion();
                        cbCuentas.Focus();
                    }
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void btnBuscarTercero_Click(object sender, EventArgs e)
        {
            var frmBeneficio = new Beneficiario.FrmBeneficio();
            frmBeneficio.tcBeneficio.SelectTab(1);
            this.Transfer = true;
            frmBeneficio.ShowDialog();
        }

        private void cbDocumento_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cbDocumento.SelectedValue).Equals(3)) // Documento Equivalente.
                {
                    if (this.Cuenta.IdTipo != 3)
                    {
                        this.txtNumero.Text = miBussinesConsecutivo.Consecutivo("Documento");
                    }
                    else
                    {
                        this.txtNumero.Text = this.Cuenta.Numero;
                    }
                    this.txtNumero.ReadOnly = true;
                    //this.txtNumero.Text = this.Cuenta.Numero;
                }
                else // Factura y Remisión.
                {
                    txtNumero.ReadOnly = false;
                    txtNumero.Text = "";
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void btnEditarDocumento_Click(object sender, EventArgs e)
        {
            this.cbDocumento.Visible = true;
            this.txtDocumento.Visible = false;
            this.btnDeshacerDocumento.Visible = true;
            this.btnEditarDocumento.Visible = false;
        }

        private void btnDeshacerDocumento_Click(object sender, EventArgs e)
        {
            this.cbDocumento.SelectedValue = this.Cuenta.IdTipo;
            this.cbDocumento.Visible = false;
            this.txtDocumento.Visible = true;
            this.btnEditarDocumento.Visible = true;
            this.btnDeshacerDocumento.Visible = false;
            if (this.Cuenta.IdTipo.Equals(3))
            {
                this.txtNumero.Text = this.Cuenta.Numero;
            }
        }

        private void btnCambiarRetencion_Click(object sender, EventArgs e)
        {
            if (this.Tercero != null)
            {
                if (AplicaRete)
                {
                    var frmReteCompra = new Egreso.FrmAplicaRetencion();
                    frmReteCompra.AplicaCompra = true;
                    frmReteCompra.IdTipoBeneficio = this.Tercero.IdRegimen;
                    frmReteCompra.IdTipoEmpresa = this.MiEmpresa.Regimen.IdRegimen;
                    DialogResult rta = frmReteCompra.ShowDialog();
                    if (rta.Equals(DialogResult.Yes))
                    {
                        if (this.Retenciones.Count != 0)
                        {
                            var query = this.Retenciones.First();
                            this.Retencion.Tarifa = query.Tarifa;
                            this.Retencion.CifraPesos = query.CifraPesos;
                            this.Retencion.CifraUVT = query.CifraUVT;
                            this.Retencion.Concepto = query.Concepto;
                            lblTasaRetencion.Text = query.Tarifa.ToString() + "%";
                            miToolTip.SetToolTip(btnInfoRete, query.Concepto);
                            if (this.SubTotal > query.CifraPesos)
                            {
                                txtRetencion.Text = UseObject.InsertSeparatorMil((Convert.ToInt32
                                   (this.SubTotal * query.Tarifa / 100)).ToString());
                            }
                            else
                            {
                                txtRetencion.Text = "0";
                            }
                        }
                    }
                    else
                    {
                        if (rta.Equals(DialogResult.No))
                        {
                            this.Retencion.Tarifa = 0;
                            this.Retencion.CifraPesos = 0;
                            this.Retencion.CifraUVT = 0;
                            this.Retencion.Concepto = "";
                            lblTasaRetencion.Text = this.Retencion.Tarifa.ToString() + "%";
                            miToolTip.SetToolTip(btnInfoRete, this.Retencion.Concepto);
                            txtRetencion.Text = "0";
                        }
                    }
                   
                }
                else
                {
                    OptionPane.MessageInformation("No hay retenciones aplciadas para el Tercero.");
                }
            }
            else
            {
                OptionPane.MessageInformation("Debe cargar un Tercero para aplicar retenciones.");
            }
        }

        private void CargarDatos()
        {
            try
            {
                cbDocumento.DataSource = miBussinesTipoDoc.Lista();

                var lst = new List<Inventario.Producto.Criterio>();
                lst.Add(new Inventario.Producto.Criterio
                {
                    Id = this.IdCtaCuentaPagar,
                    Nombre = "CUENTAS POR PAGAR",
                });
                cbCuentas.DataSource = lst;
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        void CompletaEventos_Completaz(CompletaArgumentosDeEventoz args)
        {
            try
            {
                if (Transfer)
                {
                    txtNit.Text = ((Cliente)args.MiZona).NitCliente;
                    txtNit_KeyPress(this.txtNit, new KeyPressEventArgs((char)Keys.Enter));
                    Transfer = false;
                    cbCuentas.Focus();
                }
            }
            catch { }
        }

        void CompletaEventos_Completabo(CompletaArgumentosDeEventobo args)
        {
            try
            {
                Retenciones = (List<RetencionConcepto>)args.MiBodegabo;
            }
            catch { }
        }

        private void ValidarRetencion()
        {
            try
            {
                if (miBussinesRetencion.RetencionesAplicadasACompra
                    (MiEmpresa.Regimen.IdRegimen, Tercero.IdRegimen, IdRubroRetencion).Rows.Count != 0)
                {
                    this.AplicaRete = true;
                    /*btnInfoRete.Enabled = true;
                    btnCambiarRetencion.Enabled = true;*/
                }
                else
                {
                    this.AplicaRete = false;
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void RecargarRetencion()
        {
            if (AplicaRete)
            {
                if (this.SubTotal > this.Retencion.CifraPesos)
                {
                    txtRetencion.Text = UseObject.InsertSeparatorMil((Convert.ToInt32
                                (this.SubTotal * this.Retencion.Tarifa / 100)).ToString());
                }
                else
                {
                    txtRetencion.Text = "0";
                }
            }
            else
            {
                txtRetencion.Text = "0";
            }
            this.lblTasaRetencion.Text = this.Retencion.Tarifa + "%";
            this.miToolTip.SetToolTip(this.btnInfoRete, this.Retencion.Concepto);
        }

        private void CargarCuenta()
        {
            try
            {
                this.Tercero = this.Cuenta.Tercero;
                this.txtTercero.Text = "NIT o CC: " + this.Tercero.NitCliente + " - " + this.Tercero.NombresCliente;
                this.txtDocumento.Text = this.Cuenta.Documento;
                this.cbDocumento.SelectedValue = this.Cuenta.IdTipo;
                this.txtNumero.Text = this.Cuenta.Numero;
                this.dtpFecha.Value = this.Cuenta.FechaDocumento;
                this.dtpLimite.Value = this.Cuenta.FechaLimite;
                if (this.Cuenta.IdTipo.Equals(3))
                {
                    this.txtNumero.ReadOnly = true;
                }
                ValidarRetencion();
                RecargarRetencion();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }
    }
}