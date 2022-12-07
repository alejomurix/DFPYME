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

namespace Aplicacion.Ventas.Ingresos
{
    public partial class FrmOtroIngreso : Form
    {
        private BussinesConsecutivo miBussinesConsecutivo;

        private BussinesEmpresa miBussinesEmpresa;

        private BussinesBeneficio miBussinesBeneficia;

        private BussinesOtroIngreso miBussinesOtroIngreso;

        private Empresa MiEmpresa { set; get; }

        DTO.Clases.Cliente MiCliente { set; get; }

        private Validacion validacion;

        private ErrorProvider miError;

        private bool FormExtend = false;

        private bool ConceptoMatch = false;

        private bool ValorMatch = false;

        private DataTable tabla;

        private int Contador = 0;

        private BindingSource miBindingSource;

        private bool EfectivoMatch = false;

        private bool TransaccionMatch = false;

        private bool ChequeMatch = false;

        public FrmOtroIngreso()
        {
            InitializeComponent();
            try
            {
                miBussinesConsecutivo = new BussinesConsecutivo();
                miBussinesEmpresa = new BussinesEmpresa();
                miBussinesBeneficia = new BussinesBeneficio();
                miBussinesOtroIngreso = new BussinesOtroIngreso();
                this.MiEmpresa = this.miBussinesEmpresa.ObtenerEmpresa();
                validacion = new Validacion();
                miError = new ErrorProvider();
                dgvEgreso.AutoGenerateColumns = false;
                miBindingSource = new BindingSource();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void FrmEgreso_Load(object sender, EventArgs e)
        {
            CargarUtilidades();
            CompletaEventos.Completaz += new CompletaEventos.CompletaAccionz(CompletaEventos_Completaz);
            CompletaEventos.CompletaAdelanto += new CompletaEventos.CompletaAccionAdelanto(CompletaEventos_CompletaAdelanto);

            dgvEgreso.AutoGenerateColumns = false;
            dgvEgreso.DataSource = miBindingSource;
        }

        private void FrmEgreso_KeyDown(object sender, KeyEventArgs e)
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
            if (!dgvEgreso.RowCount.Equals(0))
            {
                this.txtEfectivo_Validating(this.txtEfectivo, new CancelEventArgs(false));
                this.txtCheque_Validating(this.txtCheque, new CancelEventArgs(false));
                this.txtTransaccion_Validating(this.txtTransaccion, null);
                if (EfectivoMatch && ChequeMatch && TransaccionMatch)
                {
                    var suma = UseObject.RemoveSeparatorMil(txtCheque.Text) +
                                   UseObject.RemoveSeparatorMil(txtEfectivo.Text) +
                                   UseObject.RemoveSeparatorMil(txtTransaccion.Text);
                    if (suma.Equals(UseObject.RemoveSeparatorMil(txtTotal.Text)))
                    {
                        if (MiCliente != null)
                        {
                            DialogResult rta = MessageBox.Show("¿Está seguro de querer generar el Ingreso?", "Ingreso",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (rta.Equals(DialogResult.Yes))
                            {
                                try
                                {
                                    var otroIngreso = new OtroIngreso();
                                    otroIngreso.IdUsuario = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_user"));
                                    otroIngreso.IdCaja = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_caja"));
                                    otroIngreso.Numero = miBussinesConsecutivo.Consecutivo("ReciboCaja");
                                    otroIngreso.Tipo = MiCliente.IdCiudad;
                                    otroIngreso.Fecha = DateTime.Now;
                                    otroIngreso.Valor = Convert.ToInt32(UseObject.RemoveSeparatorMil(txtTotal.Text));
                                    otroIngreso.Conceptos = Conceptos();
                                    otroIngreso.FormasPago = Pagos();

                                    miBussinesOtroIngreso.AlmacenarIngreso(otroIngreso);
                                    OptionPane.MessageInformation("El recibo de caja se almacenó correctamente.");

                                    /*rta = MessageBox.Show("¿Desea visualizar la impresión del Recibo de Caja?", "Recibo de Caja",
                                        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);*/
                                    //printRboCaja
                                    if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("printRboCaja")))
                                    {
                                        ImpirmirPos(otroIngreso);
                                    }
                                    else
                                    {
                                        FrmPrint frmPrint = new FrmPrint();
                                        frmPrint.StringCaption = "Recibo de Caja";
                                        frmPrint.StringMessage = "Impresión del Recibo de Caja";
                                        rta = frmPrint.ShowDialog();

                                        if (!rta.Equals(DialogResult.Cancel))
                                        {
                                            var frmPrintIngreso = new FrmPrintIngreso();
                                            frmPrintIngreso.Fecha = otroIngreso.Fecha;
                                            frmPrintIngreso.Cliente = MiCliente.NombresCliente;
                                            frmPrintIngreso.Nit = MiCliente.NitCliente;
                                            frmPrintIngreso.Valor = otroIngreso.Valor.ToString();
                                            frmPrintIngreso.Numero = otroIngreso.Numero;
                                            frmPrintIngreso.DsConcepto = tabla;
                                            frmPrintIngreso.Efectivo = otroIngreso.FormasPago.Where(p => p.IdFormaPago.Equals(1)).Sum(s => s.Valor).ToString();
                                            frmPrintIngreso.Cheque = otroIngreso.FormasPago.Where(p => p.IdFormaPago.Equals(2)).Sum(s => s.Valor).ToString();
                                            frmPrintIngreso.Transaccion = otroIngreso.FormasPago.Where(p => p.IdFormaPago.Equals(4)).Sum(s => s.Valor).ToString();

                                            if (rta.Equals(DialogResult.No))
                                            {
                                                frmPrintIngreso.ShowDialog();
                                            }
                                            else
                                            {
                                                var no = Convert.ToInt32(AppConfiguracion.ValorSeccion("copyRboCaja"));
                                                Imprimir print = new Imprimir();
                                                for (int i = 1; i <= no; i++)
                                                {
                                                    print.Report = frmPrintIngreso.CargarDatos();
                                                    print.Print(Imprimir.TamanioPapel.MediaCarta);
                                                    frmPrintIngreso.ResetReport();
                                                }
                                            }
                                        }
                                    }

                                    LimpiarFormulario();
                                }
                                catch (Exception ex)
                                {
                                    OptionPane.MessageError(ex.Message);
                                }
                            }
                        }
                        else
                        {
                            OptionPane.MessageInformation("Debe ingresar un Tercero.");
                        }
                    }
                    else
                    {
                        OptionPane.MessageInformation("La suma de las formas de pago debe igual al total.");
                    }
                }
            }
            else
            {
                OptionPane.MessageInformation("Debe cargar al menos un Concepto para el Ingreso.");
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
                    var beneficia = miBussinesBeneficia.BeneficiariosNit(txtNit.Text);
                    if (beneficia.Rows.Count.Equals(0))
                    {
                        DialogResult rta = MessageBox.Show("El Beneficiario no existe. \n¿Desea Crearlo?", "Egreso",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (rta.Equals(DialogResult.Yes))
                        {
                            if (!FormExtend)
                            {
                                var frmBeneficia = new Compras.Beneficiario.FrmBeneficio();
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
                                var frmBeneficia = new Compras.Beneficiario.FrmBeneficio();
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
                            this.MiCliente = new DTO.Clases.Cliente
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
            }
        }

        private void btnBuscarBeneficiario_Click(object sender, EventArgs e)
        {
            if (!FormExtend)
            {
                var frmBeneficio = new Compras.Beneficiario.FrmBeneficio();
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

        private void txtConcepto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                txtValor.Focus();
            }
        }

        private void txtConcepto_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(this.txtConcepto, this.miError, "El campo Concepto es requerido."))
            {
                if (Validacion.ConFormato(Validacion.TipoValidacion.Numeros, this.txtConcepto, this.miError, null)) // es numero (codigo)
                {
                    var concepto = this.miBussinesOtroIngreso.Concepto(Convert.ToInt32(this.txtConcepto.Text));
                    if (concepto.Nombre.Equals(""))
                    {
                        this.ConceptoMatch = false;
                        this.miError.SetError(this.txtConcepto, "El código no existe.");
                    }
                    else
                    {
                        this.ConceptoMatch = true;
                        this.lblNameConcepto.Text = concepto.Nombre;
                    }
                }
                else  // texto
                {
                    this.ConceptoMatch = true;
                    this.lblNameConcepto.Text = this.txtConcepto.Text.ToUpper();
                }
            }
            else
            {
                this.ConceptoMatch = false;
            }

            /*if (!Validacion.EsVacio(txtConcepto, miError, "El campo Concepto es requerido."))
            {
                if (Validacion.ConFormato(Validacion.TipoValidacion.Numeros, txtConcepto, miError,
                    "El Código que ingreso es incorrecto."))
                {
                    var concepto = miBussinesOtroIngreso.Concepto(Convert.ToInt32(txtConcepto.Text));
                    if (concepto.Nombre.Equals(""))
                    {
                        DialogResult rta = MessageBox.Show("El Código no existe. \n¿Desea Crearlo?", "Recibo de Caja",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (rta.Equals(DialogResult.Yes))
                        {

                        }
                    }
                    else
                    {
                        ConceptoMatch = true;
                        lblNameConcepto.Text = concepto.Nombre;
                    }
                }
                else
                {
                    ConceptoMatch = false;
                }

            }
            else
            {
                ConceptoMatch = false;
            }*/
        }

        private void btnBuscarConcepto_Click(object sender, EventArgs e)
        {
            var frmBuscarConcepto = new FrmConsultaConcepto();
            frmBuscarConcepto.ShowDialog();
        }

        private void btnNuevoConcepto_Click(object sender, EventArgs e)
        {
            var frmNuevoConcepto = new FrmConceptoIngreso();
            DialogResult rta = frmNuevoConcepto.ShowDialog();
            if (rta.Equals(DialogResult.Yes))
            {
                txtValor.Focus();
            }
            else
            {
                txtConcepto.Focus();
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
                    ValorMatch = true;
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



        private void btnAgregar_Click(object sender, EventArgs e)
        {
            txtConcepto_Validating(this.txtConcepto, new CancelEventArgs(false));
            txtValor_Validating(this.txtValor, new CancelEventArgs(false));
            if (ConceptoMatch && ValorMatch)
            {
                try
                {
                    if (MiCliente != null)
                    {
                        Contador++;
                        var row = tabla.NewRow();
                        row["Id"] = Contador;
                        row["Codigo"] = 0;
                        row["Concepto"] = lblNameConcepto.Text;
                        row["Valor"] = Convert.ToInt32(txtValor.Text);
                        tabla.Rows.Add(row);
                        RecargarGridView();
                        CalcularTotal();
                        txtConcepto.Text = "";
                        lblNameConcepto.Text = "";
                        txtValor.Text = "";
                        txtConcepto.Focus();
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
                    var id = (int)dgvEgreso.CurrentRow.Cells["Id"].Value;
                    var row = (from data in tabla.AsEnumerable()
                               where data.Field<int>("Id") == id
                               select data).Single();
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
                this.txtCheque.Focus();
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
                this.txtTransaccion_Validating(this.txtTransaccion, new CancelEventArgs(false));
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
                lblNumero.Text = miBussinesConsecutivo.Consecutivo("ReciboCaja");
                tabla = new DataTable();
                tabla.Columns.Add(new DataColumn("Id", typeof(int)));
                tabla.Columns.Add(new DataColumn("Codigo", typeof(string)));
                tabla.Columns.Add(new DataColumn("Concepto", typeof(string)));
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
                MiCliente = (DTO.Clases.Cliente)args.MiZona;
                txtNit.Text = MiCliente.NitCliente;
                txtNombre.Text = MiCliente.NombresCliente;
                txtNit_KeyPress(this.txtNit, new KeyPressEventArgs((char)Keys.Enter));
            }
            catch { }

            try
            {
                FormExtend = Convert.ToBoolean(args.MiZona);
            }
            catch { }
        }

        void CompletaEventos_CompletaAdelanto(CompletaArgumentosDeAdelanto args)
        {
            try
            {
                var concepto = (ConceptoOtroIngreso)args.MiObjeto;
                txtConcepto.Text = concepto.Codigo.ToString();
                txtConcepto_Validating(this.txtConcepto, new CancelEventArgs(false));
                /*txtConcepto.Text = concepto.Codigo.ToString();
                lblNameConcepto.Text = concepto.Nombre;*/
                //txtValor.Focus();
            }
            catch { }
        }

        private void RecargarGridView()
        {

            IEnumerable<DataRow> query = from datos in tabla.AsEnumerable()
                                         orderby datos.Field<int>("Id") ascending
                                         select datos;
            DataTable copy = query.CopyToDataTable<DataRow>();
            miBindingSource.DataSource = copy;
        }

        private void CalcularTotal()
        {
            txtTotal.Text = UseObject.InsertSeparatorMil(
                (tabla.AsEnumerable().Sum(s => s.Field<int>("Valor"))).ToString());
            /* if (Retenciones != null && Retenciones.Count != 0)
             {
                 cifra.Add(Convert.ToInt32(Retenciones.Sum(s => s.CifraPesos)));
                 txtValorEgreso.Text = UseObject.InsertSeparatorMil
                     ((/*UseObject.RemoveSeparatorMil(txtValorEgreso.Text) + 
                      (tabla.AsEnumerable().Sum(s => s.Field<int>("Valor")) + (cifra.Sum()) * -1)).ToString());
                 txtRetencion.Text = UseObject.InsertSeparatorMil( ( UseObject.RemoveSeparatorMil(txtRetencion.Text) + Retenciones.Sum(s => s.CifraPesos) ).ToString());
             }
             else
             {
                 txtValorEgreso.Text = UseObject.InsertSeparatorMil(
                             (tabla.AsEnumerable().Sum(s => s.Field<int>("Valor"))).ToString());
             }
             txtTotal.Text = UseObject.InsertSeparatorMil(
                 (tabla.AsEnumerable().Sum(s => s.Field<int>("Valor"))).ToString());*/
        }

        private List<ConceptoOtroIngreso> Conceptos()
        {
            var lst = new List<ConceptoOtroIngreso>();
            foreach (DataRow row in tabla.Rows)
            {
                lst.Add(new ConceptoOtroIngreso
                    {
                        Codigo = Convert.ToInt32(row["Codigo"]),
                        Nombre = row["Concepto"].ToString(),
                        Valor = Convert.ToDouble(row["Valor"])
                    });
            }
            return lst;
        }

        private List<FormaPago> Pagos()
        {
            var lst = new List<FormaPago>();
            if (!txtEfectivo.Text.Equals("0"))
            {
                lst.Add(new FormaPago
                {
                    IdFormaPago = 1,
                    NombreFormaPago = "Efectivo",
                    Valor = Convert.ToInt32(UseObject.RemoveSeparatorMil(txtEfectivo.Text))
                });
            }
            if (!txtCheque.Text.Equals("0"))
            {
                lst.Add(new FormaPago
                {
                    IdFormaPago = 2,
                    NombreFormaPago = "Cheque",
                    Valor = Convert.ToInt32(UseObject.RemoveSeparatorMil(txtCheque.Text))
                });
            }
            if (!txtTransaccion.Text.Equals("0"))
            {
                lst.Add(new FormaPago
                {
                    IdFormaPago = 4,
                    NombreFormaPago = "Transacción",
                    Valor = Convert.ToInt32(UseObject.RemoveSeparatorMil(txtTransaccion.Text))
                });
            }
            return lst;
        }

        private void LimpiarFormulario()
        {
            try
            {
                lblNumero.Text = miBussinesConsecutivo.Consecutivo("ReciboCaja");
                txtNit.Focus();
                miError.SetError(txtConcepto, null);
                txtNit.Text = "";
                txtNombre.Text = "";
                while (dgvEgreso.RowCount != 0)
                {
                    dgvEgreso.Rows.RemoveAt(0);
                }
                tabla.Rows.Clear();
                Contador = 0;
                txtTotal.Text = "0";
                this.txtEfectivo.Text = "0";
                this.txtCheque.Text = "0";
                this.txtTransaccion.Text = "0";
                MiCliente = null;
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

        public void ImpirmirPos(OtroIngreso ingreso)
        {
            try
            {

                var bussinesCaja = new BussinesCaja();
                var bussinesUser = new BussinesUsuario();

                var caja = bussinesCaja.CajaId(ingreso.IdCaja);
                var usuario = bussinesUser.ConsultaUsuario(ingreso.IdUsuario).AsEnumerable().First()["nombre"].ToString();
                var cliente = miBussinesBeneficia.BeneficiarioId(ingreso.Tipo);

                Ticket ticket = new Ticket();

                ticket.AddHeaderLine(MiEmpresa.NombreComercialEmpresa.ToUpper());
                ticket.AddHeaderLine(MiEmpresa.NombreJuridicoEmpresa.ToString());
                ticket.AddHeaderLine("NIT " + UseObject.InsertSeparatorMilMasDigito(MiEmpresa.NitEmpresa));
                ticket.AddHeaderLine(MiEmpresa.DireccionEmpresa);
                ticket.AddHeaderLine("Tels. " + MiEmpresa.TelefonoEmpresa);
                ticket.AddHeaderLine("Fecha : " + ingreso.Fecha.ToShortDateString() +
                                     "    Caja : " + caja.Numero);
                ticket.AddHeaderLine("Cajero(a)  :  " + usuario);
                ticket.AddHeaderLine("===================================");
                ticket.AddHeaderLine("RECIBO DE CAJA Nro " + ingreso.Numero);
                ticket.AddHeaderLine("===================================");
                ticket.AddHeaderLine("Recibido de : " + cliente.NombresCliente);
                ticket.AddHeaderLine("NIT o C.C.  : " + UseObject.InsertSeparatorMilMasDigito(cliente.NitCliente));
                ticket.AddHeaderLine("===================================");
                foreach (var concepto in ingreso.Conceptos)
                {
                    ticket.AddItem("",
                                   concepto.Nombre,
                                   UseObject.InsertSeparatorMil(concepto.Valor.ToString()));
                }
                ticket.AddTotal("TOTAL ", UseObject.InsertSeparatorMil(ingreso.Valor.ToString()));
                ticket.AddTotal(" ", " ");
                foreach (var pago in ingreso.FormasPago)
                {
                    ticket.AddTotal(pago.NombreFormaPago,
                                    UseObject.InsertSeparatorMil(pago.Valor.ToString()));
                }
                ticket.AddFooterLine("===================================");
                ticket.AddFooterLine(".");
                ticket.AddFooterLine(".");
                ticket.AddFooterLine("Firma:");
                ticket.AddFooterLine("-----------------------------------");
                ticket.AddFooterLine("C.C. o NIT:");
                ticket.AddFooterLine("-----------------------------------");
                ticket.AddFooterLine("Fecha:");
                ticket.AddFooterLine("-----------------------------------");
                ticket.AddFooterLine(".");
                ticket.AddFooterLine("Software: DFPyme");
                //ticket.AddFooterLine("solucionestecnologicasayc@gmail.com");
                ticket.AddFooterLine(".");

                ticket.PrintTicket("IMPREPOS");
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }
    }
}