using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CustomControl;
using DTO.Clases;
using Utilities;
using BussinesLayer.Clases;

namespace Aplicacion.Compras.Egreso
{
    public partial class FrmEditarEgreso : Form
    {
        private int CodigoEgreso = 5;

        private BussinesEmpresa miBussinesEmpresa;

        private BussinesEgreso miBussinesEgreso;

        private int IdCuentaEgreso { set; get; }

        /*private BussinesProveedor miBussinesProveedor;

        private BussinesCliente miBussinesCliente;*/

        private BussinesBeneficio miBussinesBeneficia;

        private BussinesCuentaPuc miBussinesCuentaPuc;

        private BussinesRetencion miBussinesRetencion;

        private BussinesConsecutivo miBussinesConsecutivo;

        private BussinesProveedor miBussinesProveedor;

        private Empresa MiEmpresa { set; get; }

        DTO.Clases.Cliente MiCliente { set; get; }

        private List<RetencionConcepto> Conceptos { set; get; }

        private Validacion validacion;

        private ErrorProvider miError;

        private bool FormExtend = false;

        private bool CodigoMatch = false;

        private bool ConceptoMatch = false;

        private bool ValorMatch = false;

        private bool EfectivoMatch = false;

        private bool ChequeMatch = false;

        private bool TransaccionMatch = false;

        private DataTable tabla;

        private int Contador = 0;

        private BindingSource miBindingSource;

        public FrmEditarEgreso()
        {
            InitializeComponent();
            Conceptos = new List<RetencionConcepto>();
            Retenciones = new List<RetencionConcepto>();
            this.IdCuentaEgreso = Convert.ToInt32(AppConfiguracion.ValorSeccion("ctaEgreso"));
            miBussinesEmpresa = new BussinesEmpresa();
            MiEmpresa = miBussinesEmpresa.ObtenerEmpresa();
            miBussinesEgreso = new BussinesEgreso();
            miBussinesBeneficia = new BussinesBeneficio();
            miBussinesCuentaPuc = new BussinesCuentaPuc();
            miBussinesRetencion = new BussinesRetencion();
            miBussinesConsecutivo = new BussinesConsecutivo();
            miBussinesProveedor = new BussinesProveedor();
            validacion = new Validacion();
            miError = new ErrorProvider();
            miBindingSource = new BindingSource();
        }

        private void FrmEgreso_Load(object sender, EventArgs e)
        {
            CargarUtilidades();
            CompletaEventos.Completaz += new CompletaEventos.CompletaAccionz(CompletaEventos_Completaz);
            //CompletaEventos.CapturaEventom
            CompletaEventos.Completam += new CompletaEventos.CompletaAccionm(CompletaEventos_Completam);
            CompletaEventos.Completaeb += new CompletaEventos.CompletaAccioneb(CompletaEventos_Completaeb);
                
            dgvEgreso.AutoGenerateColumns = false;
            dgvEgreso.DataSource = miBindingSource;
        }

        private void FrmEgreso_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.F1))
            {
                SeleccionarEfectivo();
            }
            else
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
        }

        private void tsBtnGuardar_Click(object sender, EventArgs e)
        {
            if (!dgvEgreso.RowCount.Equals(0))
            {
                this.txtEfectivo_Validating(this.txtEfectivo, new CancelEventArgs(false));
                this.txtCheque_Validating(this.txtCheque, new CancelEventArgs(false));
                this.txtTransaccion_Validating(this.txtTransaccion, null);
                if (EfectivoMatch && ChequeMatch && TransaccionMatch)
                {
                    if (MiCliente != null)
                    {
                        var suma = UseObject.RemoveSeparatorMil(txtCheque.Text) +
                                   UseObject.RemoveSeparatorMil(txtEfectivo.Text) +
                                   UseObject.RemoveSeparatorMil(txtTransaccion.Text);
                        if (suma.Equals(UseObject.RemoveSeparatorMil(txtTotal.Text)))
                        {
                            //lblNumero.Text = AppConfiguracion.ValorSeccion("numero-e");
                            DialogResult rta = MessageBox.Show("¿Está seguro de querer generar el egreso?", "Egreso",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (rta.Equals(DialogResult.Yes))
                            {
                                try
                                {
                                //miBussinesConsecutivo.Consecutivo("Egreso");
                                    var egreso = new DTO.Clases.Egreso();
                                    egreso.IdUsuario = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_user"));
                                    egreso.IdCaja = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_caja"));

                                    egreso.Numero = miBussinesConsecutivo.Consecutivo("Egreso");//lblNumero.Text;

                                    egreso.Fecha = DateTime.Now;
                                    egreso.Total = Convert.ToInt32(UseObject.RemoveSeparatorMil(txtTotal.Text));
                                    egreso.TipoBeneficiario = MiCliente.IdCiudad;
                                    /*if (rbtnProveedor.Checked)
                                    {
                                        egreso.TipoBeneficiario = 1;
                                    }
                                    else
                                    {
                                        if (rbtnCliente.Checked)
                                        {
                                            egreso.TipoBeneficiario = 2;
                                        }
                                        else
                                        {
                                            egreso.TipoBeneficiario = 3;
                                        }
                                    }
                                    egreso.Beneficiario = Nit;*/
                                    egreso.Estado = true;
                                    egreso.Pagos = Pagos();
                                    egreso.Cuentas = Cuentas();
                               /* try
                                {*/
                                    egreso.Id = miBussinesEgreso.IngresarEgreso(egreso);
                                   /* if (!String.IsNullOrEmpty(this.txtNoFactura.Text))
                                    {
                                        var proveedor = miBussinesProveedor.ProveedorAEditar(MiCliente.NitCliente);
                                        this.miBussinesEgreso.IngresarEgresoCompra(new DTO.Clases.Egreso
                                        {
                                            TipoBeneficiario = miBussinesProveedor.ProveedorAEditar(MiCliente.NitCliente).CodigoInternoProveedor,
                                            Id = egreso.Id,
                                            Numero = this.txtNoFactura.Text,
                                            Fecha = egreso.Fecha,
                                            Total = egreso.Total
                                        });
                                    }*/
                                    OptionPane.MessageInformation("Los Datos del Egreso se almacenarón correctamente.");
                                   /* rta = MessageBox.Show("¿Desea imprimir el comprobante de egreso?", "Comprobante de Egreso",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    if (rta.Equals(DialogResult.Yes))
                                    {*/
                                        if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("printEgreso")))
                                        {
                                            PrintEgresoPos(egreso.Numero, tabla);
                                        }
                                        else
                                        {
                                            var printEgreso = new FrmPrintComprobante();
                                            //printEgreso.MdiParent = this.MdiParent;
                                            printEgreso.Numero = egreso.Numero;
                                            printEgreso.Fecha = DateTime.Now;
                                            printEgreso.Remite = txtNombre.Text + "  CC o NIT: " + MiCliente.NitCliente;
                                            IEnumerable<DataRow> query = from data in tabla.AsEnumerable()
                                                                         select data;
                                            DataTable tCopy = query.CopyToDataTable<DataRow>();
                                            tCopy.TableName = "CuentaPuc";
                                            printEgreso.Cuentas = tCopy;
                                            printEgreso.Cheque = UseObject.RemoveSeparatorMil(txtCheque.Text).ToString();
                                            printEgreso.Efectivo = UseObject.RemoveSeparatorMil(txtEfectivo.Text).ToString();
                                            printEgreso.Transaccion = UseObject.RemoveSeparatorMil(txtTransaccion.Text).ToString();

                                            /*rta = MessageBox.Show("¿Desea visualizar la impresión del egreso?", "Comprobante de Egreso",
                                                                  MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);*/
                                            FrmPrint frmPrint = new FrmPrint();
                                            frmPrint.StringCaption = "Egreso";
                                            frmPrint.StringMessage = "Impresión del Comprobante de Egreso";
                                            rta = frmPrint.ShowDialog();

                                            if (rta.Equals(DialogResult.No))
                                            {
                                                printEgreso.ShowDialog();
                                            }
                                            else
                                            {
                                                if (rta.Equals(DialogResult.Yes))
                                                {
                                                    var no = Convert.ToInt32(AppConfiguracion.ValorSeccion("copyEgreso"));
                                                    Imprimir print = new Imprimir();
                                                    for (int i = 1; i <= no; i++)
                                                    {
                                                        print.Report = printEgreso.CargarDatos();
                                                        print.Print(Imprimir.TamanioPapel.MediaCarta);
                                                        printEgreso.ResetReport();
                                                    }
                                                }
                                            }
                                            //printEgreso.ShowDialog();
                                        }
                                    //}
                                    /*if (Convert.ToInt32(lblNumero.Text) < 99)
                                    {
                                        AppConfiguracion.SaveConfiguration
                                            ("numero-e", IncrementaConsecutivo(lblNumero.Text));
                                    }
                                    else
                                    {
                                        AppConfiguracion.SaveConfiguration
                                            ("numero-e", (Convert.ToInt32(lblNumero.Text) + 1).ToString());
                                    }*/
                                    LimpiarFormulario();
                                }
                                catch (Exception ex)
                                {
                                    OptionPane.MessageError(ex.Message);
                                }
                            }
                            //
                        }
                        else
                        {
                            OptionPane.MessageInformation("La suma de las formas de pago debe igual al total.");
                        }
                    }
                    else
                    {
                        OptionPane.MessageInformation("Debe ingresar un beneficiario(a).");
                    }
                }
            }
            else
            {
                OptionPane.MessageInformation("Debe cargar al menos un concepto con codigo al Egreso.");
            }
        }


        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                txtConcepto.Focus();
            }
        }

        private void txtCodigo_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(txtCodigo, miError, "El campo Código es requerido."))
            {
                if (Validacion.ConFormato(Validacion.TipoValidacion.Numeros, txtCodigo, miError,
                    "El Código que ingreso es invalido."))
                {
                    if (txtCodigo.Text.Length.Equals(6))
                    {
                        if (ValidarCuenta(txtCodigo.Text))
                        {
                            CodigoMatch = true;
                            miError.SetError(txtCodigo, null);
                        }
                        else
                        {
                            CodigoMatch = false;
                            /*miError.SetError
                                (txtCodigo, "El Código de cuenta que ingreso no pertenece a la categoría Gastos.");*/
                            DialogResult rta = MessageBox.Show("El código de cuenta que ingreso no está registrado.\n" +
                            "¿Desea ingresarlo?");
                            if (rta.Equals(DialogResult.Yes))
                            {
                                button1_Click(this.button1, new EventArgs());
                            }
                        }
                    }
                    else
                    {
                        CodigoMatch = false;
                        miError.SetError
                                (txtCodigo, "El Código de cuenta debe tener seis digitos.");
                    }
                }
                else
                {
                    CodigoMatch = false;
                }
            }
            else
            {
                CodigoMatch = false;
            }
        }

        private void txtConcepto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.txtConcepto.Text = this.txtConcepto.Text.ToUpper();
                txtValor.Focus();
            }
        }

        private void txtConcepto_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(txtConcepto, miError, "El campo Concepto es requerido."))
            {
                ConceptoMatch = true;
            }
            else
            {
                ConceptoMatch = false;
            }
        }

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                btnAgregar.Focus();
            }
        }

        private void txtValor_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(txtValor, miError, "El campo Valor es requerido."))
            {
                if (Validacion.ConFormato(Validacion.TipoValidacion.Numeros, txtValor, miError,
                    "El Valor que ingreso es invalido."))
                {
                    if (Convert.ToInt32(txtValor.Text) < 0)
                    {
                        miError.SetError(txtValor, "El valor debe ser superior a cero.");
                        ValorMatch = false;
                    }
                    else
                    {
                        miError.SetError(txtValor, null);
                        ValorMatch = true;
                    }
                }
                else
                {
                    ValorMatch = false;
                }
            }
            else
            {
                ValorMatch = false;
            }
        }

        List<RetencionConcepto> Retenciones { set; get; }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            txtCodigo_Validating(this.txtCodigo, new CancelEventArgs(false));
            txtConcepto_Validating(this.txtConcepto, new CancelEventArgs(false));
            txtValor_Validating(this.txtValor, new CancelEventArgs(false));
            if (ConceptoMatch && ValorMatch)
            {
                try
                {
                    if (MiCliente != null)
                    {
                        DialogResult rta;
                        var id = miBussinesRetencion.IdReteCompra(MiEmpresa.Regimen.IdRegimen, MiCliente.IdRegimen);
                        if (miBussinesRetencion.ExisteAplicaReteCompra(id))
                        {
                            var frmReteCompra = new FrmAplicaRetencion();
                            frmReteCompra.AplicaEgreso = true;
                            frmReteCompra.IdTipoBeneficio = MiCliente.IdRegimen;
                            frmReteCompra.IdTipoEmpresa = MiEmpresa.Regimen.IdRegimen;
                            frmReteCompra.Valor = Convert.ToInt32(txtValor.Text);
                            rta = frmReteCompra.ShowDialog();
                        }
                        else
                        {
                            rta = DialogResult.No;
                        }

                        if (rta.Equals(DialogResult.Yes))
                        {
                            if (tabla.Rows.Count.Equals(0))
                            {
                                Contador++;
                            }
                            else
                            {
                                Contador += tabla.AsEnumerable().Max(m => m.Field<int>("Id"));
                            }
                            if (Retenciones.Count != 0)
                            {
                                /*if (tabla.Rows.Count.Equals(0))
                                {
                                    Contador++;
                                }
                                else
                                {
                                    Contador += tabla.AsEnumerable().Max(m => m.Field<int>("Id"));
                                }*/
                                var row = tabla.NewRow();
                                row["Id"] = Contador;
                                row["IdRetencion"] = 0;
                                row["IdCuenta"] = IdCuentaEgreso;// miBussinesCuentaPuc.IdSubCuenta(txtCodigo.Text.ToCharArray());
                                row["Codigo"] = txtCodigo.Text;
                                row["Concepto"] = txtConcepto.Text;
                                row["Tarifa"] = 0;
                                row["Valor"] = Convert.ToInt32(txtValor.Text);// +Retenciones.Sum(r => r.CifraPesos);
                                tabla.Rows.Add(row);
                                foreach (var retencion in Retenciones)
                                {
                                    Contador++;
                                    row = tabla.NewRow();
                                    row["Id"] = Contador;
                                    row["IdRetencion"] = retencion.Id;
                                    row["IdCuenta"] = retencion.IdCuentaPuc;
                                    //row["Codigo"] = txtCodigo.Text;
                                    row["Concepto"] = retencion.Concepto;
                                    row["Tarifa"] = retencion.Tarifa;
                                    row["Valor"] = Convert.ToInt32(Convert.ToInt32(txtValor.Text) * retencion.Tarifa / 100) * -1;
                                    //row["Valor"] = retencion.CifraPesos;
                                    tabla.Rows.Add(row);
                                }
                                RecargarGridView();
                                CalcularTotal();
                                txtCodigo.Focus();
                                txtCodigo.Text = "";
                                txtConcepto.Text = "";
                                txtValor.Text = "";
                            }
                        }
                        else
                        {
                            if (rta.Equals(DialogResult.No))
                            {
                                Contador++;
                                var row = tabla.NewRow();
                                row["Id"] = Contador;
                                row["IdRetencion"] = 0;
                                row["IdCuenta"] = IdCuentaEgreso;
                                row["Codigo"] = txtCodigo.Text;
                                row["Concepto"] = txtConcepto.Text;
                                row["Tarifa"] = 0;
                                row["Valor"] = Convert.ToInt32(txtValor.Text);
                                tabla.Rows.Add(row);
                                RecargarGridView();
                                CalcularTotal();
                                txtCodigo.Focus();
                                txtCodigo.Text = "";
                                txtConcepto.Text = "";
                                txtValor.Text = "";
                            }
                        }
                    }
                    else
                    {
                        OptionPane.MessageInformation("Debe cargar primero un Beneficiario.");
                    }
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvEgreso.RowCount != 0)
            {
                DialogResult rta = MessageBox.Show("¿Está seguro(a) de retirar el registro?", "Egreso",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rta.Equals(DialogResult.Yes))
                {
                    try
                    {
                        var id = (int)dgvEgreso.CurrentRow.Cells["Id"].Value;
                        var row = (from data in tabla.AsEnumerable()
                                   where data.Field<int>("Id") == id
                                   select data).Single();
                        if ( Retenciones != null)
                        {
                            Retenciones.RemoveAll(r => r.Id.Equals(Convert.ToInt32(row["IdRetencion"])));
                        }
                        tabla.Rows.Remove(row);
                        if (tabla.Rows.Count != 0)
                        {
                            RecargarGridView();
                        }
                        else
                        {
                            this.dgvEgreso.Rows.RemoveAt(
                                this.dgvEgreso.CurrentCell.RowIndex);
                        }
                        CalcularTotal();
                    }
                    catch (Exception ex)
                    {
                        OptionPane.MessageError(ex.Message);
                    }
                }
            }
            else
            {
                OptionPane.MessageInformation("No hay registro para retirar.");
            }
        }



        private void txtEfectivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                txtCheque.Focus();
                //txtEfectivo_Validating(this.txtEfectivo, new CancelEventArgs(false));
               // this.tsBtnGuardar_Click(this.tsBtnGuardar, new EventArgs());
            }
        }

        private void txtEfectivo_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtEfectivo.Text))
            {
                txtEfectivo.Text = txtEfectivo.Text.Replace(".", "");
                if (validacion.ValidarNumeroInt(txtEfectivo.Text))
                {
                    miError.SetError(txtEfectivo, null);
                    txtEfectivo.Text = UseObject.InsertSeparatorMil(txtEfectivo.Text);
                    EfectivoMatch = true;
                }
                else
                {
                    // OptionPane.MessageError("El valor del Efectivo es inválido.");
                    miError.SetError(txtEfectivo, "El valor que ingreso es incorrecto.");
                    EfectivoMatch = false;
                }
            }
            else
            {
                txtEfectivo.Text = "0";
                EfectivoMatch = true;
            }
        }

        private void txtCheque_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.txtTransaccion.Focus();
            }
        }

        private void txtCheque_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtCheque.Text))
            {
                txtCheque.Text = txtCheque.Text.Replace(".", "");
                if (validacion.ValidarNumeroInt(txtCheque.Text))
                {
                    miError.SetError(txtCheque, null);
                    txtCheque.Text = UseObject.InsertSeparatorMil(txtCheque.Text);
                    ChequeMatch = true;
                }
                else
                {
                    //OptionPane.MessageError("El valor del Cheque es inválido.");
                    miError.SetError(txtCheque, "El valor que ingreso es incorrecto.");
                    ChequeMatch = false;
                }
            }
            else
            {
                txtCheque.Text = "0";
                ChequeMatch = true;
            }
        }

        private void txtTransaccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.txtTransaccion_Validating(this.txtTransaccion, null);
                this.tsBtnGuardar_Click(this.tsBtnGuardar, new EventArgs());
            }
        }

        private void txtTransaccion_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtTransaccion.Text))
            {
                txtTransaccion.Text = txtTransaccion.Text.Replace(".", "");
                if (validacion.ValidarNumeroInt(txtTransaccion.Text))
                {
                    miError.SetError(txtTransaccion, null);
                    txtTransaccion.Text = UseObject.InsertSeparatorMil(txtTransaccion.Text);
                    TransaccionMatch = true;
                }
                else
                {
                    miError.SetError(txtTransaccion, "El valor que ingreso es incorrecto.");
                    TransaccionMatch = false;
                }
            }
            else
            {
                txtTransaccion.Text = "0";
                TransaccionMatch = true;
            }
        }



        private void CargarUtilidades()
        {
            try
            {
                lblFecha.Text = DateTime.Today.ToLongDateString();
                lblNumero.Text = miBussinesConsecutivo.Consecutivo("Egreso"); //AppConfiguracion.ValorSeccion("numero-e");
                tabla = new DataTable();
                tabla.TableName = "CuentaPuc";
                tabla.Columns.Add(new DataColumn("Id", typeof(int)));
                tabla.Columns.Add(new DataColumn("IdRetencion", typeof(int)));
                tabla.Columns.Add(new DataColumn("IdCuenta", typeof(int)));
                tabla.Columns.Add(new DataColumn("Codigo", typeof(string)));
                tabla.Columns.Add(new DataColumn("Concepto", typeof(string)));
                tabla.Columns.Add(new DataColumn("Tarifa", typeof(double)));
                tabla.Columns.Add(new DataColumn("Valor", typeof(int)));
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
                /*MiCliente = (DTO.Clases.Cliente)args.MiZona;
                txtNit.Text = MiCliente.NitCliente;
                txtNombre.Text = MiCliente.NombresCliente;
                txtConcepto.Focus();*/
                txtNit.Text = ((DTO.Clases.Cliente)args.MiZona).NitCliente;
                txtNit_KeyPress(this.txtNit, new KeyPressEventArgs((char)Keys.Enter));
            }
            catch { }

            try
            {
                FormExtend = Convert.ToBoolean(args.MiZona);
            }
            catch { }
        }

        void CompletaEventos_Completam(CompletaArgumentosDeEventom args)
        {
            try
            {
                txtNit.Text = (string)args.MiMarca;
                txtNit_KeyPress(this.txtNit, new KeyPressEventArgs((char)Keys.Enter));
            }
            catch { }

            try
            {
                FormExtend = Convert.ToBoolean(args.MiMarca);
            }
            catch { }
        }

        void CompletaEventos_Completaeb(CompletaArgumentosDeEventoeb args)
        {
            try
            {
                var cuenta = (SubCuentaPuc)args.MiBodegaeb;
                txtCodigo.Text = cuenta.Numero;
                txtCodigo_Validating(this.txtCodigo, new CancelEventArgs(false));
                txtCodigo_KeyPress(this.txtCodigo, new KeyPressEventArgs((char)Keys.Enter));
            }
            catch { }

            try
            {
                FormExtend = Convert.ToBoolean(args.MiBodegaeb);
            }
            catch { }

            try
            {
                Retenciones = (List<RetencionConcepto>)args.MiBodegaeb;
            }
            catch { }
        }

        private bool ValidarCuenta(int subCuenta, int cuenta)
        {
            try
            {
                return miBussinesEgreso.ValidarCuenta(subCuenta, cuenta);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
                return false;
            }
        }

        private bool ValidarCuenta(string subCuenta)
        {
            try
            {
                return miBussinesCuentaPuc.ValidarSubCuenta(subCuenta.ToCharArray());
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
                return false;
            }
        }

        private void RecargarGridView()
        {
            IEnumerable<DataRow> query = from datos in tabla.AsEnumerable()
                                         orderby datos.Field<int>("Id") ascending
                                         select datos;
            DataTable copy = query.CopyToDataTable<DataRow>();
            miBindingSource.DataSource = copy;
        }
        List<int> cifra = new List<int>();
        private void CalcularTotal()
        {
            var queryConceptos = tabla.AsEnumerable().Where(d => d.Field<int>("IdRetencion").Equals(0));
            var queryRetenciones = tabla.AsEnumerable().Where(d => d.Field<int>("IdRetencion") != 0);
            if (queryConceptos.ToArray().Length != 0)
            {
                txtValorEgreso.Text = UseObject.InsertSeparatorMil
                                  (queryConceptos.Sum(d => d.Field<int>("Valor")).ToString());
            }
            else
            {
                txtValorEgreso.Text = "0";
            }
            if (queryRetenciones.ToArray().Length != 0)
            {
                txtRetencion.Text = UseObject.InsertSeparatorMil
                    (queryRetenciones.Sum(d => d.Field<int>("Valor")).ToString());
            }
            else
            {
                txtRetencion.Text = "0";
            }
           /* if (Retenciones != null && Retenciones.Count != 0)
            {
                cifra.Add(Convert.ToInt32(Retenciones.Sum(s => s.CifraPesos)));
                txtValorEgreso.Text = UseObject.InsertSeparatorMil
                    (((tabla.AsEnumerable().Sum(s => s.Field<int>("Valor")) + (cifra.Sum()) * -1)).ToString());

                txtRetencion.Text = UseObject.InsertSeparatorMil(cifra.Sum().ToString());
            }
            else
            {
                txtValorEgreso.Text = UseObject.InsertSeparatorMil(
                            (tabla.AsEnumerable().Sum(s => s.Field<int>("Valor"))).ToString());

                txtRetencion.Text = UseObject.InsertSeparatorMil(cifra.Sum().ToString());
            }*/
           /* txtTotal.Text = UseObject.InsertSeparatorMil(Convert.ToInt32(
                UseObject.RemoveSeparatorMil(this.txtValorEgreso.Text) - UseObject.RemoveSeparatorMil(this.txtRetencion.Text)).ToString());*/
            txtTotal.Text = UseObject.InsertSeparatorMil(
                (tabla.AsEnumerable().Sum(s => s.Field<int>("Valor"))).ToString());
            cifra.Clear();
        }

        private void SeleccionarEfectivo()
        {
            txtCodigo.Text = AppConfiguracion.ValorSeccion("temp");
            txtConcepto.Text = "a";
            txtValor.Text = "0";
            txtEfectivo.Focus();
            txtEfectivo.SelectAll();
            txtCodigo.Text = "";
            txtConcepto.Text = "";
            txtValor.Text = "";
        }

        private List<FormaPago> Pagos()
        {
            var lst = new List<FormaPago>();
            if (!txtEfectivo.Text.Equals("0"))
            {
                lst.Add(new FormaPago
                {
                    IdFormaPago = 1,
                    Valor = Convert.ToInt32(UseObject.RemoveSeparatorMil(txtEfectivo.Text))
                });
            }
            if (!txtCheque.Text.Equals("0"))
            {
                lst.Add(new FormaPago
                {
                    IdFormaPago = 2,
                    Valor = Convert.ToInt32(UseObject.RemoveSeparatorMil(txtCheque.Text))
                });
            }
            if (!txtTransaccion.Text.Equals("0"))
            {
                lst.Add(new FormaPago
                {
                    IdFormaPago = 4,
                    Valor = Convert.ToInt32(UseObject.RemoveSeparatorMil(txtTransaccion.Text))
                });
            }
            return lst;
        }

        private List<ConceptoEgreso> Cuentas()
        {
            var lst = new List<ConceptoEgreso>();
            foreach (DataRow row in tabla.Rows)
            {
                lst.Add(new ConceptoEgreso
                {
                    IdCuenta = Convert.ToInt32(row["IdCuenta"]),
                    Nombre = row["Concepto"].ToString(),
                    Tarifa = Convert.ToDouble(row["Tarifa"]),
                    Numero = row["Valor"].ToString()
                });
               /* lst.Add(new SubCuentaPuc
                {
                    Codigo = Convert.ToInt32(row["IdCuenta"]),
                    Descripcion = row["Concepto"].ToString(),
                    Valor = Convert.ToInt32(row["Valor"])
                });*/
            }
            return lst;
        }

        private void LimpiarFormulario()
        {
            try
            {
                lblNumero.Text = miBussinesConsecutivo.Consecutivo("Egreso");//AppConfiguracion.ValorSeccion("numero-e");
                txtNit.Focus();
                // rbtnProveedor.Checked = true;
                Nit = "";
                txtNit.Text = "";
                txtNombre.Text = "";
                while (dgvEgreso.RowCount != 0)
                {
                    dgvEgreso.Rows.RemoveAt(0);
                }
                tabla.Rows.Clear();
                cifra.Clear();
                if (Retenciones != null)
                {
                    Retenciones.Clear();
                }
                Contador = 0;
                txtValorEgreso.Text = "0";
                txtRetencion.Text = "0";
                txtTotal.Text = "0";
                txtCheque.Text = "0";
                txtEfectivo.Text = "0";
                txtTransaccion.Text = "";
                MiCliente = null;
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void PrintEgresoPos(string numero, DataTable items)
        {
            try
            {
                DialogResult rta = MessageBox.Show("¿Desea imprimir el egreso?", "Egreso", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rta.Equals(DialogResult.Yes))
                {
                    int MaxCharacters = 35;

                    var miBussinesUsuario = new BussinesUsuario();
                    var miBussinesCaja = new BussinesCaja();

                    var empresaRow = miBussinesEmpresa.PrintEmpresa().
                                     Tables[0].AsEnumerable().First();
                    var egreso = miBussinesEgreso.EgresoNumero(numero);
                    egreso.Pagos = miBussinesEgreso.PagosEgreso(egreso.Id);
                    var caja = miBussinesCaja.CajaId(egreso.IdCaja);
                    var usuario = miBussinesUsuario.ConsultaUsuario(egreso.IdUsuario).AsEnumerable().First();
                    var beneficio = miBussinesBeneficia.BeneficiarioId(egreso.TipoBeneficiario);


                    Ticket ticket = new Ticket();
                    ticket.UseItem = false;

                    foreach (var datos_ in UseObject.StringBuilderDataCenter(empresaRow["Nombre"].ToString().ToUpper(), MaxCharacters))
                    {
                        ticket.AddHeaderLine(datos_);
                    }
                    foreach (var datos_ in UseObject.StringBuilderDataCenter(empresaRow["Juridico"].ToString().ToUpper(), MaxCharacters))
                    {
                        ticket.AddHeaderLine(datos_);
                    }

                    //ticket.AddHeaderLine(empresaRow["Nombre"].ToString().ToUpper());
                    //ticket.AddHeaderLine(empresaRow["Juridico"].ToString());
                    ticket.AddHeaderLine("NIT " + UseObject.InsertSeparatorMilMasDigito(empresaRow["Nit"].ToString()));

                    foreach (var datos_ in UseObject.StringBuilderDataIzquierda(empresaRow["Direccion"].ToString().ToUpper(), MaxCharacters))
                    {
                        ticket.AddHeaderLine(datos_);
                    }

                    //ticket.AddHeaderLine(empresaRow["Direccion"].ToString());
                    ticket.AddHeaderLine("Tels. " + empresaRow["Telefono"].ToString());
                    ticket.AddHeaderLine("Fecha : " + egreso.Fecha.ToShortDateString() +
                                     "    Caja : " + caja.Numero.ToString());
                    ticket.AddHeaderLine("Cajero(a)  :  " + usuario["nombre"].ToString());
                    ticket.AddHeaderLine("===================================");
                    ticket.AddHeaderLine("COMPROBANTE DE EGRESO Nro " + egreso.Numero);
                    ticket.AddHeaderLine("===================================");

                    foreach (var datos_ in UseObject.StringBuilderDataIzquierda("Remite a : " + beneficio.NombresCliente.ToUpper(), MaxCharacters))
                    {
                        ticket.AddHeaderLine(datos_);
                    }
                    //ticket.AddHeaderLine("Remite a : " + beneficio.NombresCliente.ToUpper());

                    ticket.AddHeaderLine("NIT: " + UseObject.InsertSeparatorMilMasDigito(beneficio.NitCliente));
                    ticket.AddHeaderLine("===================================");
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("      CONCEPTO               VALOR ");
                    ticket.AddHeaderLine("");
                    int maxCharacters_18 = 18;
                    int maxCharacters_15 = 15;
                    string valor = "";
                    List<string> datos = new List<string>();

                    
                    foreach (DataRow cuenta in items.Rows)
                    {
                        valor = UseObject.InsertSeparatorMil(cuenta["Valor"].ToString());
                        datos = UseObject.StringBuilderDataIzquierda(cuenta["Concepto"].ToString(), maxCharacters_18);
                        for (int i = 0; i < datos.Count; i++)
                        {
                            if (i == datos.Count - 1)
                            {
                                ticket.AddHeaderLine(datos[i] + UseObject.FuncionEspacio(maxCharacters_18 - datos[i].Length) + "  " +
                                    UseObject.FuncionEspacio(maxCharacters_15 - valor.Length) + valor);
                            }
                            else
                            {
                                ticket.AddHeaderLine(datos[i]);
                            }
                        }
                    }

                    /*foreach (var cuenta in egreso.Cuentas)
                    {
                        valor = UseObject.InsertSeparatorMil(cuenta.Numero);
                        datos = UseObject.StringBuilderDataIzquierda(cuenta.Nombre, maxCharacters_18);
                        for (int i = 0; i < datos.Count; i++)
                        {
                            if (i == datos.Count - 1)
                            {
                                ticket.AddHeaderLine(datos[i] + UseObject.FuncionEspacio(maxCharacters_18 - datos[i].Length) + "  " +
                                    UseObject.FuncionEspacio(maxCharacters_15 - valor.Length) + valor);
                            }
                            else
                            {
                                ticket.AddHeaderLine(datos[i]);
                            }
                        }
                    }*/



                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("===================================");
                    ticket.AddHeaderLine("");
                    var sTotal = 0;
                    var retencion = 0;
                    //var qConcepto = egreso.Cuentas.Where(d => d.IdCuenta != 0);
                    var qConcepto = items.AsEnumerable().Where(d => d.Field<int>("IdCuenta") != 0);
                    //var qRetenciones = egreso.Cuentas.Where(d => d.IdCuenta.Equals(0));
                    var qRetenciones = items.AsEnumerable().Where(d => d.Field<int>("IdCuenta") == 0);
                    if (qConcepto.ToArray().Length != 0)
                    {
                        //sTotal = qConcepto.Sum(d => Convert.ToInt32(d.Numero));
                        sTotal = Convert.ToInt32(qConcepto.Sum(d => d.Field<int>("Valor")));
                    }
                    if (qRetenciones.ToArray().Length != 0)
                    {
                        //retencion = qRetenciones.Sum(d => Convert.ToInt32(d.Numero));
                        retencion = Convert.ToInt32(qRetenciones.Sum(d => d.Field<int>("Valor")));
                    }
                    ticket.AddHeaderLine("         SUBTOTAL :" + UseObject.StringBuilderDetalleTotal(
                        UseObject.InsertSeparatorMil(sTotal.ToString())));
                    ticket.AddHeaderLine("      RETENCIONES :" + UseObject.StringBuilderDetalleTotal(
                        UseObject.InsertSeparatorMil(retencion.ToString())));
                    ticket.AddHeaderLine("            TOTAL :" + UseObject.StringBuilderDetalleTotal(
                        UseObject.InsertSeparatorMil((sTotal + retencion).ToString())));
                    ticket.AddHeaderLine("");


                    var pEfectivo = egreso.Pagos.Where(d => d.IdFormaPago.Equals(1));
                    var pCheque = egreso.Pagos.Where(d => d.IdFormaPago.Equals(2));
                    var pTransaccion = egreso.Pagos.Where(d => d.IdFormaPago.Equals(4));

                    if (pEfectivo.ToArray().Length != 0)
                    {
                        //ticket.AddTotal("EFECTIVO  : ", UseObject.InsertSeparatorMil(pEfectivo.Sum(d => d.Valor).ToString()));
                        ticket.AddHeaderLine("         EFECTIVO :" + UseObject.StringBuilderDetalleTotal(
                        UseObject.InsertSeparatorMil(pEfectivo.Sum(d => d.Valor).ToString())));
                    }
                    if (pCheque.ToArray().Length != 0)
                    {
                        //ticket.AddTotal("CHEQUE    : ", UseObject.InsertSeparatorMil(pCheque.Sum(d => d.Valor).ToString()));
                        ticket.AddHeaderLine("           CHEQUE :" + UseObject.StringBuilderDetalleTotal(
                        UseObject.InsertSeparatorMil(pCheque.Sum(d => d.Valor).ToString())));
                    }
                    if (pTransaccion.ToArray().Length != 0)
                    {
                        //ticket.AddTotal("TRANSACCIÓN :", UseObject.InsertSeparatorMil(pTransaccion.Sum(d => d.Valor).ToString()));
                        ticket.AddHeaderLine("      TRANSACCIÓN :" + UseObject.StringBuilderDetalleTotal(
                        UseObject.InsertSeparatorMil(pTransaccion.Sum(d => d.Valor).ToString())));
                    }
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("===================================");
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("___________________________________");
                    ticket.AddHeaderLine("Aprobado:");
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("___________________________________");
                    ticket.AddHeaderLine("Beneficiario");
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("Software: DFPYME");
                    ticket.AddHeaderLine("");
                    ticket.PrintTicket("");


/*
                    Ticket ticket = new Ticket();

                    ticket.AddHeaderLine(empresaRow["Nombre"].ToString().ToUpper());
                    ticket.AddHeaderLine(empresaRow["Juridico"].ToString());
                    ticket.AddHeaderLine("NIT " + UseObject.InsertSeparatorMilMasDigito(empresaRow["Nit"].ToString()));
                    ticket.AddHeaderLine(empresaRow["Direccion"].ToString());
                    ticket.AddHeaderLine("Tels. " + empresaRow["Telefono"].ToString());
                    ticket.AddHeaderLine("Fecha : " + egreso.Fecha.ToShortDateString() +
                                         "    Caja : " + caja.Numero.ToString());
                    ticket.AddHeaderLine("Cajero(a)  :  " + usuario["nombre"].ToString());
                    ticket.AddHeaderLine("===================================");
                    ticket.AddHeaderLine("COMPROBANTE DE EGRESO Nro " + egreso.Numero);
                    ticket.AddHeaderLine("===================================");
                    ticket.AddHeaderLine("Remite a : " + beneficio.NombresCliente.ToUpper());
                    ticket.AddHeaderLine("NIT: " + UseObject.InsertSeparatorMilMasDigito(beneficio.NitCliente));
                    ticket.AddHeaderLine("===================================");
                    foreach (DataRow row in items.Rows)
                    {
                        ticket.AddItem("",
                                       row["Concepto"].ToString(),
                                       UseObject.InsertSeparatorMil(row["Valor"].ToString()));
                    }

                    var sTotal = 0;
                    var retencion = 0;
                    var qConceptos = items.AsEnumerable().Where(d => d.Field<int>("IdRetencion").Equals(0));
                    var qRetenciones = items.AsEnumerable().Where(d => d.Field<int>("IdRetencion") != 0);
                    if (qConceptos.ToArray().Length != 0)
                    {
                        sTotal = qConceptos.Sum(d => d.Field<int>("Valor"));
                    }
                    if (qRetenciones.ToArray().Length != 0)
                    {
                        retencion = qRetenciones.Sum(d => d.Field<int>("Valor"));
                    }
                    ticket.AddTotal("SUBTOTAL     : ", UseObject.InsertSeparatorMil(sTotal.ToString()));
                    ticket.AddTotal("RETENCIONES  : ", UseObject.InsertSeparatorMil(retencion.ToString()));
                    ticket.AddTotal("TOTAL        : ", UseObject.InsertSeparatorMil((sTotal + retencion).ToString()));
                    ticket.AddTotal("", "");
                    ticket.AddTotal("", "");

                    ticket.AddTotal("FORMAS DE PAGO", "");
                    ticket.AddTotal("", "");
                    var pEfectivo = egreso.Pagos.Where(d => d.IdFormaPago.Equals(1));
                    var pCheque = egreso.Pagos.Where(d => d.IdFormaPago.Equals(2));
                    var pTransaccion = egreso.Pagos.Where(d => d.IdFormaPago.Equals(4));
                    if (pEfectivo.ToArray().Length != 0)
                    {
                        ticket.AddTotal("EFECTIVO    : ", UseObject.InsertSeparatorMil(pEfectivo.Sum(d => d.Valor).ToString()));
                    }
                    if (pCheque.ToArray().Length != 0)
                    {
                        ticket.AddTotal("CHEQUE      : ", UseObject.InsertSeparatorMil(pCheque.Sum(d => d.Valor).ToString()));
                    }
                    if (pTransaccion.ToArray().Length != 0)
                    {
                        ticket.AddTotal("TRANSACCIÓN :", UseObject.InsertSeparatorMil(pTransaccion.Sum(d => d.Valor).ToString()));
                    }

                    ticket.AddFooterLine("===================================");
                    ticket.AddFooterLine(".");
                    ticket.AddFooterLine(".");
                    ticket.AddFooterLine("___________________________________");
                    ticket.AddFooterLine("Aprobado:");
                    ticket.AddFooterLine(".");
                    ticket.AddFooterLine("___________________________________");
                    ticket.AddFooterLine("Beneficiario");
                    ticket.AddFooterLine(".");
                    ticket.AddFooterLine(".");

                    ticket.AddFooterLine("Software: DFPyme");
                    ticket.AddFooterLine(".");

                    ticket.PrintTicket("IMPREPOS");*/
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        public string IncrementaConsecutivo(string numero)
        {
            var num = "";
            if (Convert.ToInt32(numero) >= 10)
            {
                num += "0" + (Convert.ToInt32(numero) + 1).ToString();
            }
            else
            {
                num += "00" + (Convert.ToInt32(numero) + 1).ToString();
            }
            return num;
        }

        private string Nit { set; get; }
        private void txtNit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                try
                {
                    var beneficia = miBussinesBeneficia.BeneficiariosNit(txtNit.Text);
                    if (beneficia.Rows.Count.Equals(0))
                    {
                        DialogResult rta = MessageBox.Show("El Beneficiario no existe. \n¿Desea Crearlo?", "Egreso",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (rta.Equals(DialogResult.Yes))
                        {
                            if (!FormExtend)
                            {
                                var frmBeneficia = new Beneficiario.FrmBeneficio();
                                frmBeneficia.MdiParent = this.MdiParent;
                                frmBeneficia.txtId.Text = txtNit.Text;
                                frmBeneficia.Add = true;
                                frmBeneficia.Show();
                                frmBeneficia.txtId.Focus();
                                FormExtend = true;
                            }
                        }
                    }
                    else
                    {
                        if (beneficia.Rows.Count > 1)
                        {
                            if (!FormExtend)
                            {
                                var frmBeneficia = new Beneficiario.FrmBeneficio();
                                frmBeneficia.MdiParent = this.MdiParent;
                                frmBeneficia.tcBeneficio.SelectTab(1);
                                frmBeneficia.txtConsulta.Text = txtNit.Text;
                                frmBeneficia.Search = true;
                                frmBeneficia.Show();
                                FormExtend = true;
                            }
                        }
                        else
                        {
                            var query = (from data in beneficia.AsEnumerable()
                                         select data).Single();
                            this.MiCliente = new Cliente
                            {
                                IdCiudad = Convert.ToInt32(query["id"]),
                                IdRegimen = Convert.ToInt32(query["idregimen"]),
                                NitCliente = query["nit"].ToString(),
                                NombresCliente = query["nombre"].ToString()
                            };
                            txtNombre.Text = MiCliente.NombresCliente;
                            txtConcepto.Focus();
                        }
                    }
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
                /*if (rbtnProveedor.Checked)
                {
                    try
                    {
                        var proveedor = miBussinesProveedor.ConsultarPrveedorBasico(txtNit.Text);
                        if (String.IsNullOrEmpty(proveedor.NitProveedor))
                        {
                            OptionPane.MessageInformation("EL Proveedor no existe en la base de datos.");
                        }
                        else
                        {
                            Nit = proveedor.NitProveedor;
                            txtNombre.Text = proveedor.RazonSocialProveedor;
                            txtCodigo.Focus();
                        }
                    }
                    catch (Exception ex)
                    {
                        OptionPane.MessageError(ex.Message);
                    }
                }
                else
                {
                    if (rbtnCliente.Checked)
                    {
                        try
                        {
                            var cliente = miBussinesCliente.ClienteAEditar(txtNit.Text);
                            if (String.IsNullOrEmpty(cliente.NitCliente))
                            {
                                OptionPane.MessageInformation("El Cliente no existe en la base de datos.");
                            }
                            else
                            {
                                Nit = cliente.NitCliente;
                                txtNombre.Text = cliente.NombresCliente;
                                txtCodigo.Focus();
                            }
                        }
                        catch (Exception ex)
                        {
                            OptionPane.MessageError(ex.Message);
                        }
                    }
                    else
                    {
                    }
                }*/
            }
        }

        private void btnBuscarBeneficiario_Click(object sender, EventArgs e)
        {
            if (!FormExtend)
            {
                var frmBeneficio = new Beneficiario.FrmBeneficio();
                frmBeneficio.MdiParent = this.MdiParent;
                frmBeneficio.tcBeneficio.SelectTab(1);
                frmBeneficio.Show();
                frmBeneficio.txtConsulta.Focus();
                FormExtend = true;
            }
            /*if (rbtnProveedor.Checked)
            {
                if (!FormExtend)
                {
                    var proveedor = new Compras.Proveedor.frmProveedor();
                    proveedor.MdiParent = this.MdiParent;
                    proveedor.tcProveedor.SelectTab(1);
                    proveedor.Extension = true;
                    proveedor.Egreso_ = true;
                    proveedor.Show();
                    FormExtend = true;
                }
            }
            else
            {
                if (rbtnCliente.Checked)
                {
                    if (!FormExtend)
                    {
                        var cliente = new Ventas.Cliente.frmCliente();
                        cliente.MdiParent = this.MdiParent;
                        cliente.tcClientes.SelectTab(1);
                        cliente.Egreso_ = true;
                        cliente.Show();
                        FormExtend = true;
                    }
                }
                else
                {
                }
            }*/
        }

        private void tsBtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!FormExtend)
            {
                var frmPuc = new Administracion.Puc.FrmPuc();
                frmPuc.Extend = true;
                frmPuc.MdiParent = this.MdiParent;
                FormExtend = true;
                frmPuc.Show();
            }
        }

        /*
        private void txtEfectivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                txtCheque.Focus();
            }
        }

        private void txtEfectivo_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtEfectivo.Text))
            {
                txtEfectivo.Text = txtEfectivo.Text.Replace(".", "");
                if (validacion.ValidarNumeroInt(txtEfectivo.Text))
                {
                    txtEfectivo.Text = UseObject.InsertSeparatorMil(txtEfectivo.Text);
                    EfectivoMatch = true;
                }
                else
                {
                    OptionPane.MessageError("El valor del Efectivo es inválido.");
                    EfectivoMatch = false;
                }
            }
            else
            {
                txtEfectivo.Text = "0";
                EfectivoMatch = true;
            }
        }

        private void txtCheque_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                txtTarjeta.Focus();
            }
        }

        private void txtCheque_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtCheque.Text))
            {
                txtCheque.Text = txtCheque.Text.Replace(".", "");
                if (validacion.ValidarNumeroInt(txtCheque.Text))
                {
                    txtCheque.Text = UseObject.InsertSeparatorMil(txtCheque.Text);
                    ChequeMatch = true;
                }
                else
                {
                    OptionPane.MessageError("El valor del Cheque es inválido.");
                    ChequeMatch = false;
                }
            }
            else
            {
                txtCheque.Text = "0";
                ChequeMatch = true;
            }
        }

        private void txtTarjeta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                txtTransaccion.Focus();
            }
        }

        private void txtTarjeta_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtTarjeta.Text))
            {
                txtTarjeta.Text = txtTarjeta.Text.Replace(".", "");
                if (validacion.ValidarNumeroInt(txtTarjeta.Text))
                {
                    txtTarjeta.Text = UseObject.InsertSeparatorMil(txtTarjeta.Text);
                    TarjetaMatch = true;
                }
                else
                {
                    OptionPane.MessageError("El valor de la Tarjeta es inválido.");
                    TarjetaMatch = false;
                }
            }
            else
            {
                txtTarjeta.Text = "0";
                TarjetaMatch = true;
            }
        }

        private void txtTransaccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.FrmEgreso_KeyDown(this, new KeyEventArgs(Keys.F6));
            }
        }

        private void txtTransaccion_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtTransaccion.Text))
            {
                txtTransaccion.Text = txtTransaccion.Text.Replace(".", "");
                if (validacion.ValidarNumeroInt(txtTransaccion.Text))
                {
                    txtTransaccion.Text = UseObject.InsertSeparatorMil(txtTransaccion.Text);
                    TransacionMatch = true;
                }
                else
                {
                    OptionPane.MessageError("El valor de la Transacción es inválido.");
                    TransacionMatch = false;
                }
            }
            else
            {
                txtTransaccion.Text = "0";
                TransacionMatch = true;
            }
        }

        /// <summary>
        /// Carga los datos necesarios para el uso del formulario.
        /// </summary>
        private void CargarUtilidades()
        {
            lblNumero.Text = "Egreso No " + AppConfiguracion.ValorSeccion("const-e") +
                                            AppConfiguracion.ValorSeccion("numero-e");
            var lst = new List<Inventario.Producto.Criterio>();
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 1,
                Nombre = "Caja Registradora"
            });
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 2,
                Nombre = "Caja General"
            });
            cbRegistro.DataSource = lst;
        }

        /// <summary>
        /// Valida de nuevo los campos de texto.
        /// </summary>
        private void Validar()
        {
            txtEfectivo_Validating(this.txtEfectivo, new CancelEventArgs(false));
            txtCheque_Validating(this.txtCheque, new CancelEventArgs(false));
            txtTarjeta_Validating(this.txtTarjeta, new CancelEventArgs(false));
            txtTransaccion_Validating(this.txtTransaccion, new CancelEventArgs(false));
        }

        private List<DTO.Clases.FormaPago> FormasDePago()
        {
            var Formas = new List<DTO.Clases.FormaPago>();
            Formas.Add(new DTO.Clases.FormaPago
            {
                IdFormaPago = 1,
                Valor = Convert.ToInt32
                (UseObject.RemoveSeparatorMil(txtEfectivo.Text))
            });
            Formas.Add(new DTO.Clases.FormaPago
            {
                IdFormaPago = 2,
                Valor = Convert.ToInt32
                (UseObject.RemoveSeparatorMil(txtCheque.Text))
            });
            Formas.Add(new DTO.Clases.FormaPago
            {
                IdFormaPago = 3,
                Valor = Convert.ToInt32
                (UseObject.RemoveSeparatorMil(txtTarjeta.Text))
            });
            Formas.Add(new DTO.Clases.FormaPago
            {
                IdFormaPago = 4,
                Valor = Convert.ToInt32
                (UseObject.RemoveSeparatorMil(txtTransaccion.Text))
            });
            txtTotal.Text = 
                UseObject.InsertSeparatorMil(Formas.Sum(f => f.Valor).ToString());
            return Formas;
        }

        private void LimpiarForm()
        {
            lblNumero.Text = "Egreso No" + AppConfiguracion.ValorSeccion("const-e") +
                                           AppConfiguracion.ValorSeccion("numero-e");
            txtConcepto.Text = "";
            txtEfectivo.Text = "0";
            txtCheque.Text = "0";
            txtTarjeta.Text = "0";
            txtTransaccion.Text = "0";
            txtTotal.Text = "0";
            txtConcepto.Focus();
        }
        */
    }
}