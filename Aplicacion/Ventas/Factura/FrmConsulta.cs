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
using Microsoft.Reporting.WinForms;

namespace Aplicacion.Ventas.Factura
{
    public partial class FrmConsulta : Form
    {
        /// <summary>
        /// Objeto que encapsula la lógica de negocio de Factura Venta.
        /// </summary>
        private BussinesFacturaVenta miBussinesFactura;

        private BussinesFormaPago miBussinesFormaPago;

        private BussinesCliente miBussinesCliente;

        private BussinesEmpresa miBussinesEmpresa;

        private BussinesUsuario miBussinesUsuario;

        private BussinesDian miBussinesDian;

        private BussinesConsecutivo miBussinesConsecutivo;

        private BussinesConfiguracion miBussinesConfiguracion;

        private BussinesImpuestoBolsa miBussinesImpuesto;

        private DataRow RowEmpresa;

        //private bool PrintDetail_;

        #region Paginación

        /// <summary>
        /// Obteien o establece el numero que indica que iteracion se realizo.
        /// </summary>
        private int Iteracion;

        /// <summary>
        /// Obtiene o establece el valor del registro a segir o registro base.
        /// </summary>
        private int RowFactura;

        /// <summary>
        /// Obtiene o establece el número maximo de registro a cargar.
        /// </summary>
        private int RowMaxFactura;

        /// <summary>
        /// Obtiene o establece el total de registros en la base de datos.
        /// </summary>
        private long TotalRowFactura;

        /// <summary>
        /// Obtiene o establece el número total de paginas que componen la consulta.
        /// </summary>
        private long PaginasFactura;

        /// <summary>
        /// Obtiene o establece el número de la pagina actual.
        /// </summary>
        private int CurrentPageFactura;

        /// <summary>
        /// Obtiene o establece el valor de Estado actual de la factura a consultar.
        /// </summary>
        private int EstadoActual;

        /// <summary>
        /// Obtiene o establece el valor del Cliente actual de la factura a consultar.
        /// </summary>
        private string ClienteActual;

        /// <summary>
        /// Obtiene o establece el valor de la primera fecha actual de la factura a consultar.
        /// </summary>
        private DateTime Fecha1Actual;

        /// <summary>
        /// Obtiene o establece el valor de la segunda fecha actual de la factura a consultar.
        /// </summary>
        private DateTime Fecha2Actual;

        #endregion

        private bool GraneroJhonRiosucio { set; get; }

        private ToolTip miToolTip;

        private bool ExtendForms = false;

        public bool Extend = false;

        private int CodigoConfiguracionConsulta;

        public const string SuperUsuario = "SUPER_USUARIO";

        public Usuario Usuario_ { set; get; }

        private const int IdPermisoEditarVenta = 53;

        private bool PermisoEditarVenta;

        private const int IdPermisoAnularVenta = 55;

        private bool PermisoAnularVenta;


        private bool DatosCliente;

        public FrmConsulta()
        {
            InitializeComponent();
            try
            {
                miBussinesFactura = new BussinesFacturaVenta();
                miBussinesFormaPago = new BussinesFormaPago();
                miBussinesCliente = new BussinesCliente();
                miBussinesEmpresa = new BussinesEmpresa();
                miBussinesUsuario = new BussinesUsuario();
                miBussinesDian = new BussinesDian();
                miBussinesConsecutivo = new BussinesConsecutivo();
                miBussinesApertura = new BussinesApertura();
                miBussinesConfiguracion = new BussinesConfiguracion();
                this.miBussinesImpuesto = new BussinesImpuestoBolsa();

                this.RowEmpresa = this.miBussinesEmpresa.PrintEmpresa().Tables[0].AsEnumerable().First();

                this.GraneroJhonRiosucio = Convert.ToBoolean(AppConfiguracion.ValorSeccion("graneroJhonRiosucio"));
                DatosCliente = Convert.ToBoolean(AppConfiguracion.ValorSeccion("datos_cliente"));
                miToolTip = new ToolTip();
                RowMaxFactura = 5;
                this.Edition = false;

                this.CodigoConfiguracionConsulta = 1;
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void FrmConsulta_Load(object sender, EventArgs e)
        {
            if (Extend)
                this.tsBtnSeleccionar.Visible = true;
            CompletaEventos.Completa += new CompletaEventos.CompletaAccion(CompletaEventos_Completo);
            CompletaEventos.ComAbonoFact += new CompletaEventos.ComAxAbonoFact(CompletaEventos_ComAbonoFact);
            CompletaEventos.Completabo += new CompletaEventos.CompletaAccionbo(CompletaEventos_Completabo);
            CargarCriterioGeneral();
            //CargarPrimerCriterio();
            //CargarSegundoCriterio();
            //CargarTercerCriterio();

            this.PermisoEditarVenta = false;
            this.PermisoAnularVenta = false;
            foreach (var ps in Usuario_.Permisos)
            {
                switch (ps.IdPermiso)
                {
                    case IdPermisoEditarVenta:
                        {
                            this.PermisoEditarVenta = true;
                            break;
                        }
                    case IdPermisoAnularVenta:
                        {
                            this.PermisoAnularVenta = true;
                            break;
                        }
                }
            }
        }

        private void FrmConsulta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F2)
            {
                this.tsBtnEditar_Click(this.tsBtnEditar, new EventArgs());
            }
            else
            {
                if (e.KeyData == Keys.F3)
                {
                    this.tsBtnRealizarAbono_Click(this.tsBtnRealizarAbono, new EventArgs());
                }
                else
                {
                    if (e.KeyData.Equals(Keys.F4))
                    {
                        tsBtnAbonoGeneral_Click(this.tsBtnAbonoGeneral, new EventArgs());
                    }
                    else
                    {
                        if (e.KeyData.Equals(Keys.F5))
                        {
                            tsBtnCopia_Click(this.tsBtnCopia, new EventArgs());
                        }
                        else
                        {
                            if (e.KeyData.Equals(Keys.F6))
                            {
                                this.tsBtnVerPagos_Click(this.tsBtnVerPagos, new EventArgs());
                            }
                            else
                            {
                                if (e.KeyData.Equals(Keys.F12))
                                {
                                    if (tsBtnSeleccionar.Visible)
                                    {
                                        tsBtnSeleccionar_Click(this.tsBtnSeleccionar, new EventArgs());
                                    }
                                }
                                else
                                {
                                    if (e.KeyData == Keys.Escape)
                                    {
                                        this.Close();
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (e.KeyData.Equals(Keys.F10))
            {
                try
                {
                    var frm = new Inventario.Producto.FrmReplicas();
                    frm.dgvReplicas.DataSource =
                    miBussinesFactura.ResumenDeUtilidad(dtpFecha1.Value, dtpFecha2.Value);
                    frm.ShowDialog();
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
            if (e.KeyData.Equals(Keys.F11))
            {
                PrintTicket p = new PrintTicket();
                p.UseItem = false;
                p.empresaRow = this.miBussinesEmpresa.PrintEmpresa().Tables[0].AsEnumerable().First();
                p.dianRow = this.miBussinesDian.DianRow();
                p.IdEstado = 1;
                p.ImprimirRemisionVenta();
            }
        }

        private bool Edition { set; get; }
        private void tsBtnEditar_Click(object sender, EventArgs e)
        {
            if (dgvFactura.RowCount != 0)
            {
                try
                {
                    var rowFactura = dgvFactura.CurrentRow;
                    int idEstado = Convert.ToInt32(rowFactura.Cells["IdEstado"].Value);
                    if (Convert.ToBoolean(rowFactura.Cells["Activa"].Value))
                    {
                        if (!(idEstado.Equals(1)))
                        {
                            if (idEstado.Equals(2) && UseObject.RemoveSeparatorMil(this.txtResta.Text).Equals(0))  // valida crédito pagado.
                            {
                                OptionPane.MessageInformation("La factura no se puede editar.");
                            }
                            else
                            {
                                if (this.PermisoEditarVenta)
                                {
                                    CargarVentaEditar(rowFactura);
                                }
                                else
                                {
                                    var admin = false;
                                    while (!admin)
                                    {
                                        string rta = CustomControl.OptionPane.LoginUserPassword();
                                        if (!rta.Equals("false"))
                                        {
                                            try
                                            {
                                                // validar usuario y contraseña incorrectos - si existe o no.
                                                // validar si el usuario tiene permisos o no
                                                // si tiene permisos continua el proceso.
                                                string[] data = rta.Split('&');
                                                var userTemp =
                                                    this.miBussinesUsuario.Usuario_(new Usuario { Usuario_ = data[0], Contrasenia = Encode.Encrypt(data[1]) });
                                                if (userTemp.Id != 0)
                                                {
                                                    if (userTemp.Permisos.Where(ps => ps.IdPermiso.Equals(IdPermisoEditarVenta)).Count() > 0)
                                                    {
                                                        admin = true;
                                                        CargarVentaEditar(rowFactura);
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("El usuario no tiene permisos para esta acción.", "Consulta de venta",
                                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                        admin = false;
                                                    }
                                                }
                                                else
                                                {
                                                    MessageBox.Show
                                                        ("Usuario o contraseña incorrecta.", "Consulta de venta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                    admin = false;
                                                }
                                            }
                                            catch (Exception ex)
                                            {
                                                OptionPane.MessageError(ex.Message);
                                                admin = false;
                                            }
                                        }
                                        else
                                        {
                                            admin = true;
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            OptionPane.MessageInformation("La factura no se puede editar.");
                        }
                    }
                    else
                    {
                        OptionPane.MessageInformation("La factura no se puede editar porque esta anulada.");
                    }
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
            else
            {
                OptionPane.MessageInformation("No hay registros para editar.");
            }
        }

        private void CargarVentaEditar(DataGridViewRow rowFactura)
        {
            //var rowFactura = dgvFactura.CurrentRow;

            //var miFactura = miBussinesFactura.FacturaDeVenta(rowFactura.Cells["Numero"].Value.ToString());// new FacturaVenta();
            var miFactura = miBussinesFactura.FacturaDeVenta(Convert.ToInt32(rowFactura.Cells["IdFactura"].Value));
            miFactura.Id = Convert.ToInt32(rowFactura.Cells["IdFactura"].Value);
            miFactura.IdResolucionDian = Convert.ToInt32(rowFactura.Cells["IdResolucionDian"].Value);
            //miFactura.EstadoFactura.Id = 3;
            miFactura.EstadoFactura.Id = (int)rowFactura.Cells["IdEstado"].Value;
            miFactura.AplicaDescuento = (bool)rowFactura.Cells["Descuento"].Value;
            miFactura.Proveedor.NitProveedor = (string)rowFactura.Cells["Nit"].Value;
            miFactura.Proveedor.NombreProveedor = (string)rowFactura.Cells["Proveedor"].Value;
            miFactura.Numero = (string)rowFactura.Cells["Numero"].Value;
            miFactura.FechaIngreso = UseDate.UnionFechaYHora(Convert.ToDateTime(rowFactura.Cells["FechaIngreso"].Value),
                Convert.ToDateTime(rowFactura.Cells["Hora"].Value));
            miFactura.FechaLimite = Convert.ToDateTime(rowFactura.Cells["FechaLimite"].Value);
            // miFactura.FechaIngreso = (DateTime)rowFactura.Cells["FechaIngreso"].Value;
            //var h = Convert.ToDateTime(rowFactura.Cells["Hora"].Value);
            miFactura.Descuento = (double)rowFactura.Cells["DesctoFactura"].Value;

            //rowFactura.Cells[""].Value;
            var editFactura = new Edicion.FrmFacturaVenta();
            editFactura.Usuario_ = this.Usuario_;
            //editFactura.MdiParent = this.MdiParent;
            editFactura.Factura = miFactura;
            editFactura.Productos = Productos();
            editFactura.Edicion = true;

            //**********  Edición 06 Ago 2019  ******************************************************************
           /* if (Convert.ToInt32(rowFactura.Cells["IdEstado"].Value).Equals(4))
            {
                editFactura.Factura.Pendiente = true;
            }*/

            if (Convert.ToInt32(rowFactura.Cells["IdEstado"].Value).Equals(3) ||
                Convert.ToInt32(rowFactura.Cells["IdEstado"].Value).Equals(4))
            {
                //editFactura.Remision = true;
                editFactura.Factura.Pendiente = true;
            }

            //**********  Edición 06 Ago 2019  ******************************************************************

            /*if (Convert.ToInt32(rowFactura.Cells["IdEstado"].Value).Equals(3) ||
                Convert.ToInt32(rowFactura.Cells["IdEstado"].Value).Equals(4))
            {
                editFactura.Remision = true;
                editFactura.Factura.Pendiente = true;
            }
            else
            {
                editFactura.Remision = false;
                editFactura.Factura.Pendiente = false;
            }*/
            this.Edition = true;
            editFactura.ShowDialog();
        }

        private BussinesApertura miBussinesApertura;

        private void tsBtnRealizarAbono_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvFactura.RowCount != 0)
                {
                    if (miBussinesApertura.RegistrosApertura(Convert.ToInt32(AppConfiguracion.ValorSeccion("id_caja"))).Rows.Count.Equals(0)) //if (String.IsNullOrEmpty(AppConfiguracion.ValorSeccion("id_apertura")))
                    {
                        OptionPane.MessageError("Se requiere apertura de caja para esta función.");
                    }
                    else
                    {
                        var idEstado = (int)dgvFactura.CurrentRow.Cells["IdEstado"].Value;
                        if (!txtResta.Text.Equals("0") && idEstado == 2)//idEstado == 2)
                        {
                            if (Convert.ToBoolean(dgvFactura.CurrentRow.Cells["Activa"].Value))
                            {
                                /* if (!ExtendForms)
                                 {*/
                                /* var frmAbonoVenta = new FrmDinamicCancelar();
                                 frmAbonoVenta.txtTotal.Text = txtResta.Text;
                                 frmAbonoVenta.Abono = true;
                                 frmAbonoVenta.ShowDialog();*/

                                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("btq")))
                                {
                                    var frmCancelarVenta = new Abonos.FrmCancelarVenta2();
                                    frmCancelarVenta.IdFactura = Convert.ToInt32(this.dgvFactura.CurrentRow.Cells["IdFactura"].Value);
                                    frmCancelarVenta.NumeroFactura = (string)dgvFactura.CurrentRow.Cells["Numero"].Value;
                                    frmCancelarVenta.NitCliente = (string)dgvFactura.CurrentRow.Cells["Nit"].Value;
                                    frmCancelarVenta.Abono = true;
                                    frmCancelarVenta.EsVenta = true;
                                    frmCancelarVenta.txtTotal.Text = txtResta.Text;
                                    ExtendForms = true;
                                    AbonoGeneral = false;
                                    frmCancelarVenta.ShowDialog();
                                }
                                else
                                {
                                    var frmCancelarVenta = new Abonos.FrmCancelarVenta();
                                    frmCancelarVenta.RowEmpresa = this.RowEmpresa;
                                    frmCancelarVenta.IdFactura = Convert.ToInt32(this.dgvFactura.CurrentRow.Cells["IdFactura"].Value);
                                    frmCancelarVenta.NumeroFactura = (string)dgvFactura.CurrentRow.Cells["Numero"].Value;
                                    frmCancelarVenta.NitCliente = (string)dgvFactura.CurrentRow.Cells["Nit"].Value;
                                    frmCancelarVenta.Abono = true;
                                    frmCancelarVenta.EsVenta = true;
                                    frmCancelarVenta.txtTotal.Text = txtResta.Text;
                                    frmCancelarVenta.Total = Convert.ToInt32(UseObject.RemoveSeparatorMil(this.txtTotalPago.Text));
                                    ExtendForms = true;
                                    AbonoGeneral = false;
                                    frmCancelarVenta.ShowDialog();
                                }
                                //var frmCancelarVenta = new Abonos.FrmCancelarVenta2();
                                /*frmCancelarVenta.NumeroFactura = (string)dgvFactura.CurrentRow.Cells["Numero"].Value;
                                frmCancelarVenta.NitCliente = (string)dgvFactura.CurrentRow.Cells["Nit"].Value;
                                frmCancelarVenta.Abono = true;
                                frmCancelarVenta.EsVenta = true;
                                frmCancelarVenta.txtTotal.Text = txtResta.Text;
                                ExtendForms = true;
                                AbonoGeneral = false;
                                frmCancelarVenta.ShowDialog();*/

                                AbonoGeneral = false;
                            }
                            else
                            {
                                OptionPane.MessageInformation("Esta factura no se puede abonar porque esta anulada.");
                            }
                        }
                        else
                        {
                            OptionPane.MessageInformation("Esta factura no tiene saldo pendiente.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void tsBtnAbonoGeneral_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvFactura.RowCount != 0)
                {
                    if (!ExtendForms)
                    {
                        /* var total = miBussinesFactura.SaldoPorCliente
                             (2, dgvFactura.CurrentRow.Cells["Nit"].Value.ToString());
                         if (total > 0)
                         {*/
                        if (miBussinesApertura.RegistrosApertura(Convert.ToInt32(AppConfiguracion.ValorSeccion("id_caja"))).Rows.Count.Equals(0)) //if (String.IsNullOrEmpty(AppConfiguracion.ValorSeccion("id_apertura")))
                        {
                            OptionPane.MessageError("Se requiere apertura de caja para esta función.");
                        }
                        else
                        {
                            ///var cartera = this.miBussinesFactura.CarteraCliente(this.dgvFactura.CurrentRow.Cells["Nit"].Value.ToString());
                            var cartera = this.miBussinesFactura.CarteraCliente_(2, this.dgvFactura.CurrentRow.Cells["Nit"].Value.ToString());
                            //var cartera = this.miBussinesFactura.CarteraCliente(2, this.dgvFactura.CurrentRow.Cells["Nit"].Value.ToString());
                            //var total = miBussinesFactura.SaldoPorCliente(2, dgvFactura.CurrentRow.Cells["Nit"].Value.ToString());
                            if (cartera.Count > 0)
                            {
                                var frmAbono = new Abonos.FrmAbonoGeneral();
                                //frmAbono.MdiParent = this.MdiParent;
                                frmAbono.RowEmpresa = this.RowEmpresa;
                                frmAbono.NitCliente = dgvFactura.CurrentRow.Cells["Nit"].Value.ToString();
                                frmAbono.txtProveedor.Text = dgvFactura.CurrentRow.Cells["Proveedor"].Value.ToString();

                                //
                                //var dato = cartera.Sum(c => c.Saldo);
                                //

                                frmAbono.Cartera = cartera;
                                //frmAbono.txtSaldo.Text = UseObject.InsertSeparatorMil(total.ToString());
                                ExtendForms = true;
                                AbonoGeneral = true;
                                frmAbono.ShowDialog();
                            }
                            else
                            {
                                OptionPane.MessageInformation("El cliente se encuentra a paz y salvo.");
                            }
                        }
                        /* }
                         else
                         {
                             OptionPane.MessageInformation("El cliente se encuentra a paz y salvo.");
                         }*/
                    }
                }
                else
                {
                    OptionPane.MessageInformation("Debe seleccionar primero un Cliente.");
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void tsBtnCopia_Click(object sender, EventArgs e)
        {
            if (!dgvFactura.RowCount.Equals(0))
            {
                try
                {//miBussinesImpuesto
                    var registro = this.dgvFactura.Rows[this.dgvFactura.CurrentCell.RowIndex];
                    if (Convert.ToBoolean(registro.Cells["Activa"].Value))
                    {
                        if (!Convert.ToInt32(registro.Cells["IdEstado"].Value).Equals(3))
                        {
                            bool contado = true;
                            if (Convert.ToInt32(registro.Cells["IdEstado"].Value).Equals(2))
                            {
                                contado = false;
                            }
                            //PrintIngresoPos(registro.Cells["Numero"].Value.ToString());
                            if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("printCopiaFVenta")))
                            {
                                //var pagos = miBussinesFormaPago.GetTotalFormasDePagoDeFacturaVenta(registro.Cells["Numero"].Value.ToString());
                                var pagos = miBussinesFormaPago.GetTotalPagoDeFacturaVentaId(Convert.ToInt32(registro.Cells["IdFactura"].Value));

                                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("print_termal_80mm")))
                                {
                                    PrintPos(Convert.ToInt32(registro.Cells["IdFactura"].Value), registro.Cells["Numero"].Value.ToString(), Convert.ToBoolean(registro.Cells["Descuento"].Value),
                                         registro.Cells["Nit"].Value.ToString(), contado, Convert.ToInt32(registro.Cells["IdEstado"].Value),
                                         pagos);
                                }
                                else
                                {
                                    PrintPos50mm(Convert.ToInt32(registro.Cells["IdFactura"].Value), registro.Cells["Numero"].Value.ToString(), Convert.ToBoolean(registro.Cells["Descuento"].Value),
                                         registro.Cells["Nit"].Value.ToString(), contado, Convert.ToInt32(registro.Cells["IdEstado"].Value),
                                         pagos);
                                }
                                /*PrintPosTriunfo(Convert.ToInt32(registro.Cells["IdFactura"].Value), registro.Cells["Numero"].Value.ToString(), Convert.ToBoolean(registro.Cells["Descuento"].Value),
                                         registro.Cells["Nit"].Value.ToString(), contado, Convert.ToInt32(registro.Cells["IdEstado"].Value),
                                         pagos);*/
                            }
                            else
                            {
                                FrmPrint_ frmPrint = new FrmPrint_();
                                frmPrint.StringCaption = "Factura Venta";
                                frmPrint.StringMessage = "Impresión de la Factura de Venta";
                                DialogResult rta = frmPrint.ShowDialog();
                                /*DialogResult rta = MessageBox.Show("¿Desea visualizar la impresión de la Factura de Venta?", "Consulta Venta",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);*/
                                if (rta.Equals(DialogResult.Yes))
                                {
                                    Print(Convert.ToInt32(registro.Cells["IdFactura"].Value), registro.Cells["Numero"].Value.ToString(), Convert.ToBoolean(registro.Cells["Descuento"].Value),
                                          registro.Cells["Nit"].Value.ToString(), contado, Convert.ToInt32(registro.Cells["IdEstado"].Value), false);
                                }
                                else
                                {
                                    if (rta.Equals(DialogResult.No))
                                    {
                                        Print(Convert.ToInt32(registro.Cells["IdFactura"].Value), registro.Cells["Numero"].Value.ToString(), Convert.ToBoolean(registro.Cells["Descuento"].Value),
                                              registro.Cells["Nit"].Value.ToString(), contado, Convert.ToInt32(registro.Cells["IdEstado"].Value), true);
                                    }
                                }
                                /* Print(registro.Cells["Numero"].Value.ToString(), Convert.ToBoolean(registro.Cells["Descuento"].Value),
                                           registro.Cells["Nit"].Value.ToString(), contado, Convert.ToInt32(registro.Cells["IdEstado"].Value), true);*/
                            }
                        }
                        else
                        {
                            OptionPane.MessageInformation("Este tipo de documento no se puede imprimir.");
                        }
                    }
                    else
                    {
                        OptionPane.MessageInformation
                            ("No se puede imprimir una copia de esta factura ya que se encuentra anulada.");
                    }
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
            else
            {
                OptionPane.MessageInformation("No hay registros para imprimir.");
            }
        }

        private void tsBtnVerPagos_Click(object sender, EventArgs e)
        {
            if (this.txtAbono.Text.Equals("0"))
            {
                OptionPane.MessageInformation("La factura no presenta pagos.  ");
            }
            else
            {
                var frmPagos = new FrmPagosFactura();
                frmPagos.IdFactura = Convert.ToInt32(this.dgvFactura.CurrentRow.Cells["IdFactura"].Value);
                //frmPagos.NoFacura = this.dgvFactura.CurrentRow.Cells["Numero"].Value.ToString();
                frmPagos.ShowDialog();
            }
        }

        private void tsBtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /*private void cbCriterio_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var criterio = Convert.ToInt32(cbCriterio.SelectedValue);
            var criterio2 = Convert.ToInt32(cbCriterio2.SelectedValue);
            txtCodigo.Text = "";
            if (criterio == 1)
            {
                CargarPrimerCriterio();
                txtCodigo.Enabled = true;
                cbCriterio1.Enabled = false;
                btnBuscarCodigo.Enabled = false;
                //cbCriterio2.SelectedValue = 1;
                cbCriterio3.Enabled = false;
                dtpFecha1.Enabled = false;
                dtpFecha2.Enabled = false;
                btnBuscar.Enabled = true;
                btnBuscar1.Enabled = false;
                //cbCriterio2.SelectedIndex = 0;
                //cbCriterio2_SelectionChangeCommitted(null, null);
            }
            else
            {
                if (criterio == 2)
                {
                    if (criterio2 != 4)
                    {
                        txtCodigo.Enabled = false;
                        btnBuscarCodigo.Enabled = false;
                        CargarPrimerCriterioOpcion();
                    }
                }
                else
                {
                    txtCodigo.Enabled = true;
                    btnBuscarCodigo.Enabled = true;
                    if (criterio2 != 4)
                    {
                        CargarPrimerCriterio();
                    }
                }
                if (criterio2 != 4)
                {
                    cbCriterio1.Enabled = true;
                }
                else
                {
                    cbCriterio1.Enabled = false;
                }
            }
        }*/

        private void cbCriterio_SelectionChangeCommitted(object sender, EventArgs e)
        {
            switch (Convert.ToInt32(this.cbCriterio.SelectedValue))
            {
                case 1:
                    {
                        this.cbEstado.Enabled = false;
                        this.txtCodigo.Enabled = true;
                        this.txtCodigo.Text = "";
                        this.btnBuscarCodigo.Enabled = false;
                        this.cbFecha.SelectedValue = 1;
                        this.cbFecha_SelectionChangeCommitted(this.cbFecha, new EventArgs());
                        this.cbFecha.Enabled = false;
                        break;
                    }
                case 2:
                    {
                        this.cbEstado.Enabled = true;
                        this.txtCodigo.Text = "";
                        this.txtCodigo.Enabled = false;
                        this.btnBuscarCodigo.Enabled = false;
                        this.cbFecha.Enabled = true;
                        break;
                    }
                case 3:
                    {
                        this.cbEstado.Enabled = true;
                        this.txtCodigo.Enabled = true;
                        this.txtCodigo.Text = "";
                        this.btnBuscarCodigo.Enabled = true;
                        this.cbFecha.Enabled = true;
                        break;
                    }
            }
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                if (Convert.ToInt32(this.cbCriterio.SelectedValue).Equals(3))
                {
                    if (UseObject.NitCliente(this.txtCodigo.Text))
                    {
                        this.btnBuscar_Click(this.btnBuscar, new EventArgs());
                    }
                    else
                    {
                        var frmCliente = new Cliente.frmCliente();
                        frmCliente.tcClientes.SelectedIndex = 1;
                        frmCliente.txtParametro.Text = this.txtCodigo.Text;
                        frmCliente.ConsultaVenta = true;
                        frmCliente.ConsultaVentaBtn = true;
                        frmCliente.ShowDialog();
                    }
                }
                else
                {
                    this.btnBuscar_Click(this.btnBuscar, new EventArgs());
                }


                //this.btnBuscar_Click(this.btnBuscar, new EventArgs());
            }
        }

        private void btnBuscarCodigo_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cbCriterio.SelectedValue).Equals(3))
            {
                if (!ExtendForms)
                {
                    var frmCliente = new Cliente.frmCliente();
                    //frmCliente.MdiParent = this.MdiParent;
                    frmCliente.tcClientes.SelectedIndex = 1;
                    frmCliente.ConsultaVenta = true;
                    ExtendForms = true;
                    frmCliente.ShowDialog();
                }
            }
        }

        private void cbFecha_SelectionChangeCommitted(object sender, EventArgs e)
        {
            switch (Convert.ToInt32(cbFecha.SelectedValue))
            {
                case 1:
                    {
                        this.dtpFecha1.Enabled = false;
                        this.dtpFecha2.Enabled = false;
                        break;
                    }
                case 2:
                    {
                        this.dtpFecha1.Enabled = true;
                        this.dtpFecha2.Enabled = false;
                        break;
                    }
                case 3:
                    {
                        this.dtpFecha1.Enabled = true;
                        this.dtpFecha2.Enabled = true;
                        break;
                    }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cbCriterio.SelectedValue).Equals(3) && String.IsNullOrEmpty(this.txtCodigo.Text))
            {
                OptionPane.MessageInformation("El campo de consulta es requerido.");
            }
            else
            {
                this.dgvFactura.AutoGenerateColumns = false;
                switch (Convert.ToInt32(cbCriterio.SelectedValue))
                {
                    case 1:  // Número
                        {
                            ConsultaNumero(this.txtCodigo.Text);
                            break;
                        }
                    case 2:  // Estado
                        {
                            switch (Convert.ToInt32(cbFecha.SelectedValue))
                            {
                                case 1: // Vacio
                                    {
                                        if (Convert.ToInt32(cbEstado.SelectedValue).Equals(0)) // Todos los estados
                                        {
                                            ConsultaTodas();
                                        }
                                        else   // Con estado
                                        {
                                            ConsultaEstado(Convert.ToInt32(cbEstado.SelectedValue));
                                        }
                                        break;
                                    }
                                case 2: // Fecha
                                    {
                                        if (Convert.ToInt32(cbEstado.SelectedValue).Equals(0)) // Todos los estados
                                        {
                                            ConsultaTodas(this.dtpFecha1.Value);
                                        }
                                        else   // Con estado
                                        {
                                            ConsultaEstadoFechaIngreso(Convert.ToInt32(cbEstado.SelectedValue), this.dtpFecha1.Value);
                                        }
                                        break;
                                    }
                                case 3: // Periodo
                                    {
                                        if (Convert.ToInt32(cbEstado.SelectedValue).Equals(0)) // Todos los estados
                                        {
                                            ConsultaTodas(this.dtpFecha1.Value, this.dtpFecha2.Value);
                                        }
                                        else   // Con estado
                                        {
                                            ConsultaEstadoPeriodoIngreso
                                            (Convert.ToInt32(cbEstado.SelectedValue), this.dtpFecha1.Value, this.dtpFecha2.Value);
                                        }
                                        break;
                                    }
                            }
                            break;
                        }
                    case 3: // Cliente
                        {
                            switch (Convert.ToInt32(cbFecha.SelectedValue))
                            {
                                case 1: // Vacio
                                    {
                                        if (Convert.ToInt32(cbEstado.SelectedValue).Equals(0)) // Todos los estados
                                        {
                                            ConsultaTodasCliente(this.txtCodigo.Text);
                                        }
                                        else   // Con estado
                                        {
                                            ConsultaEstadoCliente(Convert.ToInt32(cbEstado.SelectedValue), this.txtCodigo.Text);
                                        }
                                        break;
                                    }
                                case 2: // Fecha
                                    {
                                        if (Convert.ToInt32(cbEstado.SelectedValue).Equals(0)) // Todos los estados
                                        {
                                            ConsultaPorClienteIngreso(this.txtCodigo.Text, this.dtpFecha1.Value);
                                        }
                                        else   // Con estado
                                        {
                                            ConsultaPorClienteIngreso
                                            (this.txtCodigo.Text, Convert.ToInt32(cbEstado.SelectedValue), this.dtpFecha1.Value);
                                        }
                                        break;
                                    }
                                case 3: // Periodo
                                    {
                                        if (Convert.ToInt32(cbEstado.SelectedValue).Equals(0)) // Todos los estados
                                        {
                                            ConsultaPorClientePeriodoIngreso
                                            (this.txtCodigo.Text, this.dtpFecha1.Value, this.dtpFecha2.Value);
                                        }
                                        else   // Con estado
                                        {
                                            ConsultaPorEstadoClientePeriodoIngreso
                                            (this.txtCodigo.Text, Convert.ToInt32(cbEstado.SelectedValue), this.dtpFecha1.Value, this.dtpFecha2.Value);
                                        }
                                        break;
                                    }
                            }
                            break;
                        }
                }
                FacturaAnulada();
                if (this.dgvFactura.RowCount != 0)
                {
                    this.dgvFactura_CellClick(this.dgvFactura, null);
                }
                else
                {
                    LimpiarGridProducto();
                    LimpiarTotales();
                    if (!this.Edition)  // false: lanza el cuardo de mensaje.
                    {
                        OptionPane.MessageInformation("No se encontraron registros de la consulta.");
                    }
                }
            }
        }

        private bool BtnSearch = false;
        /*private void btnBuscar_Click(object sender, EventArgs e)
        {
            BtnSearch = false;
            var criterio = (int)cbCriterio.SelectedValue;
            var criterio1 = (int)cbCriterio1.SelectedValue;
            dgvFactura.AutoGenerateColumns = false;
            if (criterio == 1)
            {
                ConsultaNumero(txtCodigo.Text);
            }
            else
            {
                if (criterio == 2)
                {
                    if (criterio1 == 0)
                    {
                        ConsultaTodas();
                    }
                    else
                    {
                        ConsultaEstado(criterio1);
                    }
                }
                else
                {
                    if (criterio1 == 0)
                    {
                        ConsultaTodasCliente(txtCodigo.Text);
                    }
                    else
                    {
                        ConsultaEstadoCliente(criterio1, txtCodigo.Text);
                    }
                }
            }
            if (dgvFactura.RowCount != 0)
            {
                dgvFactura_CellClick(this.dgvFactura, null);
                FacturaAnulada();
            }
            else
            {
                while (dgvListaArticulos.RowCount != 0)
                {
                    dgvListaArticulos.Rows.RemoveAt(0);
                }
                LimpiarTotales();
            }
        }*/

        /*private void cbCriterio2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var criterio2 = Convert.ToInt32(cbCriterio2.SelectedValue);
            if (criterio2 == 1)
            {
                cbCriterio.Enabled = true;
                //cbCriterio1.Enabled = true;
                cbCriterio3.Enabled = false;
                dtpFecha1.Enabled = false;
                dtpFecha2.Enabled = false;
                btnBuscar.Enabled = true;
                btnBuscar1.Enabled = false;

                
            }
            else
            {
                if (criterio2 == 2)
                {
                    cbCriterio.SelectedValue = 3;
                    cbCriterio.Enabled = false;
                    cbCriterio1.SelectedValue = 2;
                    cbCriterio1.Enabled = false;
                    btnBuscarCodigo.Enabled = true;
                    btnBuscar.Enabled = false;
                    btnBuscar1.Enabled = true;
                    cbCriterio3.Enabled = false;
                    dtpFecha1.Enabled = false;
                    dtpFecha2.Enabled = false;
                }
                else
                {
                    if (criterio2 == 4)
                    {
                        cbCriterio1.Enabled = false;
                        cbCriterio1.SelectedValue = 1;
                    }
                    else
                    {
                        cbCriterio1.Enabled = true;
                    }
                    //if (criterio2 == 3)
                    //{
                    cbCriterio.Enabled = true;
                        cbCriterio.SelectedValue = 2;
                        //cbCriterio1.Enabled = true;
                        btnBuscar.Enabled = false;
                        btnBuscar1.Enabled = true;
                        cbCriterio3.Enabled = true;
                        dtpFecha1.Enabled = true;
                        dtpFecha2.Enabled = false;
                        //this.cbCriterio_SelectionChangeCommitted(this.cbCriterio, new EventArgs());
                    //}
                }
            }
        }*/

        /*private void cbCriterio3_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var criterio3 = Convert.ToInt32(cbCriterio3.SelectedValue);
            if (criterio3 == 1)
            {
                dtpFecha2.Enabled = false;
            }
            else
            {
                dtpFecha2.Enabled = true;
            }
        }*/

        /*private void btnBuscar1_Click(object sender, EventArgs e)
        {
            BtnSearch = true;
            var criterio = (int)cbCriterio.SelectedValue;
            var criterio1 = (int)cbCriterio1.SelectedValue;
            var criterio2 = (int)cbCriterio2.SelectedValue;
            var criterio3 = (int)cbCriterio3.SelectedValue;
            dgvFactura.AutoGenerateColumns = false;
            if (criterio2 == 3) //fecha ingreso
            {
                if (criterio == 2) //estado
                {
                    if (criterio3 == 1) //fecha simple
                    {
                        ConsultaEstadoFechaIngreso(criterio1, dtpFecha1.Value);
                    }
                    else
                    {
                        ConsultaEstadoPeriodoIngreso(criterio1, dtpFecha1.Value, dtpFecha2.Value);
                    }
                }
                else
                {
                    if (criterio == 3) //cliente
                    {
                        if (criterio1 != 0)  //estado
                        {
                            if (criterio3 == 2) //periodo fecha
                            {
                                ConsultaPorEstadoClientePeriodoIngreso
                                    (criterio, txtCodigo.Text, dtpFecha1.Value, dtpFecha2.Value);
                            }
                        }
                        else  //todas
                        {
                            if (criterio3 == 1) //fecha simple
                            {
                                ConsultaPorClienteIngreso(txtCodigo.Text, dtpFecha1.Value);
                            }
                            else   //periodo fecha
                            {
                                ConsultaPorClientePeriodoIngreso
                                    (txtCodigo.Text, dtpFecha1.Value, dtpFecha2.Value);
                            }
                        }
                    }
                }
            }
            else
            {
                if (criterio2 == 4)   //fecha limite
                {
                    if (criterio == 2)  //por estado
                    {
                        if (criterio3 == 1)  //fecha simple
                        {
                            ConsultaEstadoFechaLimite(criterio1, dtpFecha1.Value);
                        }
                        else  //periodo fecha
                        {
                            ConsultaCreditoPeriodo(criterio1, dtpFecha1.Value, dtpFecha2.Value);
                        }
                    }
                    else  //por cliente
                    {
                        if (criterio3 == 1)  //fecha simple
                        {
                            ConsultaClienteCreditoLimite(txtCodigo.Text, criterio1, dtpFecha1.Value);
                        }
                        else  //periodo fecha
                        {
                            ConsultaClienteCreditoLimitePeriodo
                                (txtCodigo.Text, criterio1, dtpFecha1.Value, dtpFecha1.Value);
                        }
                    }
                }
                else  //fact. en mora
                {
                    if (String.IsNullOrEmpty(txtCodigo.Text)) //fact. en mora
                    {
                        ConsultaEnMora(criterio1, DateTime.Today);
                    }
                    else //cliente en mora
                    {
                        ConsultaClienteEnMora(txtCodigo.Text, criterio1, DateTime.Today);
                    }
                }
            }
            if (dgvFactura.RowCount != 0)
            {
                dgvFactura_CellClick(this.dgvFactura, null);
                FacturaAnulada();
            }
            else
            {
                while (dgvListaArticulos.RowCount != 0)
                {
                    dgvListaArticulos.Rows.RemoveAt(0);
                }
                LimpiarTotales();
            }
        }*/

        private void dgvFactura_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvListaArticulos.AutoGenerateColumns = false;
            if (dgvFactura.RowCount != 0)
            {
                var miBussinesRetencion = new BussinesRetencion();
                var id = Convert.ToInt32(this.dgvFactura.CurrentRow.Cells["IdFactura"].Value);
                var numero = (string)dgvFactura.CurrentRow.Cells["Numero"].Value;
                var descto = (bool)dgvFactura.CurrentRow.Cells["Descuento"].Value;
                var idEstado = (int)dgvFactura.CurrentRow.Cells["IdEstado"].Value;
                if (descto)
                {
                    dgvListaArticulos.Columns["Descto"].HeaderText = "Descto";
                    dgvListaArticulos.Columns["ValorMenosDescto"].HeaderText = "Valor - Descto";
                    lblDescuento.Text = "DESCUENTO:";
                }
                else
                {
                    dgvListaArticulos.Columns["Descto"].HeaderText = "Rcargo";
                    dgvListaArticulos.Columns["ValorMenosDescto"].HeaderText = "Valor-Rcargo";
                    lblDescuento.Text = "RECARGO:";
                }
                try
                {
                    //var tabla = miBussinesFactura.ProductoFacturaVenta(numero, descto);
                    var tabla = miBussinesFactura.ProductoFacturaVenta(id, descto);
                    var ivaFacturado = this.miBussinesFactura.IvaFacturado(id);
                    var retenciones = miBussinesRetencion.RetencionesAVenta(numero);
                    var impBolsas = this.miBussinesImpuesto.ImpuestoBolsaDeVenta(id);
                    this.txtImpstoBolsas.Text = (impBolsas.Cantidad * impBolsas.Valor).ToString();
                    CalcularTotales(tabla, ivaFacturado, retenciones);
                    if (idEstado == 2)
                    {
                        PagosAFactura(numero);
                    }
                    else
                    {
                        if (idEstado == 1)
                        {
                            txtTotalPago.Text = UseObject.InsertSeparatorMil((
                                UseObject.RemoveSeparatorMil(txtTotal.Text) -
                                UseObject.RemoveSeparatorMil(txtRetencion.Text)).ToString());
                            txtAbono.Text = txtTotalPago.Text;
                            txtResta.Text = "0";
                            txtSaldoDevolucion.Text = "0";
                        }
                        else
                        {
                            txtTotalPago.Text = UseObject.InsertSeparatorMil((
                                UseObject.RemoveSeparatorMil(txtTotal.Text) -
                                UseObject.RemoveSeparatorMil(txtRetencion.Text)).ToString());
                            txtAbono.Text = txtTotalPago.Text;
                            txtResta.Text = "0";
                            txtSaldoDevolucion.Text = "0";
                        }
                        //saldodevolucino = 0
                    }
                    if (!Convert.ToBoolean(dgvFactura.CurrentRow.Cells["Activa"].Value))
                    {
                        txtAbono.Text = "0";
                        txtSaldoDevolucion.Text = "0";
                        txtResta.Text = "0";
                    }
                    dgvListaArticulos.DataSource = tabla;
                    ColorearGrid();
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void tsBtnAnular_Click(object sender, EventArgs e)
        {
            if (dgvFactura.RowCount != 0)
            {
                if (Convert.ToBoolean(dgvFactura.CurrentRow.Cells["Activa"].Value))
                {
                    if (!(Convert.ToInt32(dgvFactura.CurrentRow.Cells["IdEstado"].Value).Equals(2) &&
                        Convert.ToInt32(UseObject.RemoveSeparatorMil(this.txtAbono.Text)) > 0))
                    {
                        if (this.PermisoAnularVenta)
                        {
                            AnularFactura();
                        }
                        else
                        {
                            var admin = false;
                            while (!admin)
                            {
                                string rta = CustomControl.OptionPane.LoginUserPassword();
                                if (!rta.Equals("false"))
                                {
                                    try
                                    {
                                        // validar usuario y contraseña incorrectos - si existe o no.
                                        // validar si el usuario tiene permisos o no
                                        // si tiene permisos continua el proceso.
                                        string[] data = rta.Split('&');
                                        var userTemp =
                                            this.miBussinesUsuario.Usuario_(new Usuario { Usuario_ = data[0], Contrasenia = Encode.Encrypt(data[1]) });
                                        if (userTemp.Id != 0)
                                        {
                                            if (userTemp.Permisos.Where(ps => ps.IdPermiso.Equals(IdPermisoAnularVenta)).Count() > 0)
                                            {
                                                admin = true;
                                                AnularFactura();
                                            }
                                            else
                                            {
                                                MessageBox.Show("El usuario no tiene permisos para esta acción.", "Consulta de venta",
                                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                admin = false;
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show
                                                ("Usuario o contraseña incorrecta.", "Consulta de venta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            admin = false;
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        OptionPane.MessageError(ex.Message);
                                        admin = false;
                                    }
                                }
                                else
                                {
                                    admin = true;
                                }
                            }
                        }
                    }
                    else
                    {
                        OptionPane.MessageInformation("La factura seleccionada no se puede anular.");
                    }
                }
                else
                {
                    OptionPane.MessageInformation("La factura se encuentra anulada.");
                }
            }
        }

        private void AnularFactura()
        {
            DialogResult rta = MessageBox.Show("¿Está seguro(a) de querer anular esta Factura de venta?", "Factura venta",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (rta.Equals(DialogResult.Yes))
            {
                var carga = false;
                rta = MessageBox.Show("¿Desea cargar los productos de esta factura en inventario?", "Factura venta",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rta.Equals(DialogResult.Yes))
                {
                    carga = true;
                }
                try
                {
                    var rowFactura = dgvFactura.CurrentRow;
                    var factura = new FacturaVenta();
                    factura.Caja.Id = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_caja"));
                    factura.Usuario.Id = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_user"));
                    factura.FechaIngreso = DateTime.Now;
                    factura.Id = Convert.ToInt32(rowFactura.Cells["IdFactura"].Value);
                    factura.Numero = rowFactura.Cells["Numero"].Value.ToString();
                    factura.Proveedor.NitProveedor = rowFactura.Cells["Nit"].Value.ToString();
                    factura.Valor = Convert.ToInt32(UseObject.RemoveSeparatorMil(txtTotalPago.Text));

                    miBussinesFactura.AnularFactura(factura, carga);
                    OptionPane.MessageInformation("La Factura ha sido anulada.");
                    this.btnBuscar_Click(this.btnBuscar, new EventArgs());
                    if (BtnSearch)
                    {
                        //this.btnBuscar1_Click(this.btnBuscar1, new EventArgs());
                    }
                    else
                    {
                        //this.btnBuscar_Click(this.btnBuscar, new EventArgs());
                    }
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void tsSaldoCliente_Click(object sender, EventArgs e)
        {
            if (dgvFactura.RowCount != 0)
            {
                //if (Convert.ToInt32(dgvFactura.CurrentRow.Cells["IdEstado"].Value) == 2)
                //{
                try
                {
                    var total = miBussinesFactura.SaldoPorCliente
                        (2, dgvFactura.CurrentRow.Cells["Nit"].Value.ToString());
                    var frmSaldoC = new Saldos.FrmSaldoCliente();
                    frmSaldoC.MdiParent = this.MdiParent;
                    frmSaldoC.txtCliente.Text = dgvFactura.CurrentRow.Cells["Proveedor"].Value.ToString();
                    frmSaldoC.txtNit.Text = dgvFactura.CurrentRow.Cells["Nit"].Value.ToString();
                    frmSaldoC.txtSaldo.Text = UseObject.InsertSeparatorMil(total.ToString());
                    frmSaldoC.Show();
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
                //}
            }
            else
            {
                OptionPane.MessageInformation("Debe seleccionar primero un Cliente.");
            }
        }

        private void tsBtnSaltoTotalCredito_Click(object sender, EventArgs e)
        {
            /*if (dgvFactura.RowCount != 0)
            {
                if (Convert.ToInt32(dgvFactura.CurrentRow.Cells["IdEstado"].Value) == 2)
                {*/
            try
            {
                var total = miBussinesFactura.SaldoTotalCredito(2);
                var frmSaldo = new Saldos.FrmSaldosTotal();
                frmSaldo.MdiParent = this.MdiParent;
                frmSaldo.txtSaldo.Text = UseObject.InsertSeparatorMil(total.ToString());
                frmSaldo.Show();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            //}
            //}
        }

        private void tsBtnNuevoArticulo_Click(object sender, EventArgs e)
        {

        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            if (CurrentPageFactura > 1)
            {
                var paginaActual = CurrentPageFactura;
                for (int i = paginaActual; i > 1; i--)
                {
                    RowFactura = RowFactura - RowMaxFactura;
                    CurrentPageFactura--;
                }
                try
                {
                    switch (Iteracion)
                    {
                        case 0:
                            {
                                dgvFactura.DataSource =
                                miBussinesFactura.ConsultaTodas(RowFactura, RowMaxFactura);
                                break;
                            }
                        case 1:
                            {
                                dgvFactura.DataSource = miBussinesFactura.ConsultaEstado
                                (EstadoActual, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 2:
                            {
                                dgvFactura.DataSource = miBussinesFactura.ConsultaTodas(Fecha1Actual, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 3:
                            {
                                dgvFactura.DataSource =
                                miBussinesFactura.ConsultaEstadoFechaIngreso(EstadoActual, Fecha1Actual, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 4:
                            {
                                dgvFactura.DataSource =
                                miBussinesFactura.ConsultaTodas(Fecha1Actual, Fecha2Actual, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 5:
                            {
                                dgvFactura.DataSource = miBussinesFactura.ConsultaEstadoPeriodoIngreso
                                (EstadoActual, Fecha1Actual, Fecha2Actual, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 6:
                            {
                                dgvFactura.DataSource =
                                    miBussinesFactura.ConsultaPorCliente(ClienteActual, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 7:
                            {
                                dgvFactura.DataSource = miBussinesFactura.ConsultaPorEstadoYcliente
                                (EstadoActual, ClienteActual, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 8:
                            {
                                dgvFactura.DataSource = miBussinesFactura.ConsultaPorClienteIngreso
                                    (ClienteActual, Fecha1Actual, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 9:
                            {
                                dgvFactura.DataSource = miBussinesFactura.ConsultaPorEstadoClienteIngreso
                                    (EstadoActual, ClienteActual, Fecha1Actual, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 10:
                            {
                                dgvFactura.DataSource = miBussinesFactura.ConsultaPorClientePeriodoIngreso
                                      (ClienteActual, Fecha1Actual, Fecha2Actual, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 11:
                            {
                                dgvFactura.DataSource = miBussinesFactura.ConsultaPorEstadoClientePeriodoIngreso
                                    (EstadoActual, ClienteActual, Fecha1Actual, Fecha2Actual, RowFactura, RowMaxFactura);
                                break;
                            }
                    }
                    lblStatusFactura.Text = CurrentPageFactura + " / " + PaginasFactura;
                    dgvFactura_CellClick(this.dgvFactura, null);
                    FacturaAnulada();
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (CurrentPageFactura > 1)
            {
                RowFactura = RowFactura - RowMaxFactura;
                if (RowFactura <= 0)
                    RowFactura = 0;
                try
                {
                    switch (Iteracion)
                    {
                        case 0:
                            {
                                dgvFactura.DataSource =
                                miBussinesFactura.ConsultaTodas(RowFactura, RowMaxFactura);
                                break;
                            }
                        case 1:
                            {
                                dgvFactura.DataSource = miBussinesFactura.ConsultaEstado
                                (EstadoActual, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 2:
                            {
                                dgvFactura.DataSource = miBussinesFactura.ConsultaTodas(Fecha1Actual, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 3:
                            {
                                dgvFactura.DataSource =
                                miBussinesFactura.ConsultaEstadoFechaIngreso(EstadoActual, Fecha1Actual, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 4:
                            {
                                dgvFactura.DataSource =
                                miBussinesFactura.ConsultaTodas(Fecha1Actual, Fecha2Actual, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 5:
                            {
                                dgvFactura.DataSource = miBussinesFactura.ConsultaEstadoPeriodoIngreso
                                (EstadoActual, Fecha1Actual, Fecha2Actual, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 6:
                            {
                                dgvFactura.DataSource =
                                    miBussinesFactura.ConsultaPorCliente(ClienteActual, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 7:
                            {
                                dgvFactura.DataSource = miBussinesFactura.ConsultaPorEstadoYcliente
                                (EstadoActual, ClienteActual, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 8:
                            {
                                dgvFactura.DataSource = miBussinesFactura.ConsultaPorClienteIngreso
                                    (ClienteActual, Fecha1Actual, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 9:
                            {
                                dgvFactura.DataSource = miBussinesFactura.ConsultaPorEstadoClienteIngreso
                                    (EstadoActual, ClienteActual, Fecha1Actual, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 10:
                            {
                                dgvFactura.DataSource = miBussinesFactura.ConsultaPorClientePeriodoIngreso
                                      (ClienteActual, Fecha1Actual, Fecha2Actual, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 11:
                            {
                                dgvFactura.DataSource = miBussinesFactura.ConsultaPorEstadoClientePeriodoIngreso
                                    (EstadoActual, ClienteActual, Fecha1Actual, Fecha2Actual, RowFactura, RowMaxFactura);
                                break;
                            }
                    }
                    CurrentPageFactura--;
                    lblStatusFactura.Text = CurrentPageFactura + " / " + PaginasFactura;
                    dgvFactura_CellClick(this.dgvFactura, null);
                    FacturaAnulada();
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (CurrentPageFactura < PaginasFactura)
            {
                RowFactura = RowFactura + RowMaxFactura;
                try
                {
                    switch (Iteracion)
                    {
                        case 0:
                            {
                                dgvFactura.DataSource =
                                miBussinesFactura.ConsultaTodas(RowFactura, RowMaxFactura);
                                break;
                            }
                        case 1:
                            {
                                dgvFactura.DataSource = miBussinesFactura.ConsultaEstado
                                (EstadoActual, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 2:
                            {
                                dgvFactura.DataSource = miBussinesFactura.ConsultaTodas(Fecha1Actual, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 3:
                            {
                                dgvFactura.DataSource =
                                miBussinesFactura.ConsultaEstadoFechaIngreso(EstadoActual, Fecha1Actual, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 4:
                            {
                                dgvFactura.DataSource =
                                miBussinesFactura.ConsultaTodas(Fecha1Actual, Fecha2Actual, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 5:
                            {
                                dgvFactura.DataSource = miBussinesFactura.ConsultaEstadoPeriodoIngreso
                                (EstadoActual, Fecha1Actual, Fecha2Actual, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 6:
                            {
                                dgvFactura.DataSource =
                                    miBussinesFactura.ConsultaPorCliente(ClienteActual, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 7:
                            {
                                dgvFactura.DataSource = miBussinesFactura.ConsultaPorEstadoYcliente
                                (EstadoActual, ClienteActual, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 8:
                            {
                                dgvFactura.DataSource = miBussinesFactura.ConsultaPorClienteIngreso
                                    (ClienteActual, Fecha1Actual, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 9:
                            {
                                dgvFactura.DataSource = miBussinesFactura.ConsultaPorEstadoClienteIngreso
                                    (EstadoActual, ClienteActual, Fecha1Actual, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 10:
                            {
                                dgvFactura.DataSource = miBussinesFactura.ConsultaPorClientePeriodoIngreso
                                      (ClienteActual, Fecha1Actual, Fecha2Actual, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 11:
                            {
                                dgvFactura.DataSource = miBussinesFactura.ConsultaPorEstadoClientePeriodoIngreso
                                    (EstadoActual, ClienteActual, Fecha1Actual, Fecha2Actual, RowFactura, RowMaxFactura);
                                break;
                            }
                    }
                    CurrentPageFactura++;
                    lblStatusFactura.Text = CurrentPageFactura + " / " + PaginasFactura;
                    dgvFactura_CellClick(this.dgvFactura, null);
                    FacturaAnulada();
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void btnFin_Click(object sender, EventArgs e)
        {
            if (CurrentPageFactura < PaginasFactura)
            {
                var paginaActual = CurrentPageFactura;
                for (int i = paginaActual; i < PaginasFactura; i++)
                {
                    RowFactura = RowFactura + RowMaxFactura;
                    CurrentPageFactura++;
                }
                try
                {
                    switch (Iteracion)
                    {
                        case 0:
                            {
                                dgvFactura.DataSource =
                                miBussinesFactura.ConsultaTodas(RowFactura, RowMaxFactura);
                                break;
                            }
                        case 1:
                            {
                                dgvFactura.DataSource = miBussinesFactura.ConsultaEstado
                                (EstadoActual, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 2:
                            {
                                dgvFactura.DataSource = miBussinesFactura.ConsultaTodas(Fecha1Actual, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 3:
                            {
                                dgvFactura.DataSource =
                                miBussinesFactura.ConsultaEstadoFechaIngreso(EstadoActual, Fecha1Actual, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 4:
                            {
                                dgvFactura.DataSource =
                                miBussinesFactura.ConsultaTodas(Fecha1Actual, Fecha2Actual, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 5:
                            {
                                dgvFactura.DataSource = miBussinesFactura.ConsultaEstadoPeriodoIngreso
                                (EstadoActual, Fecha1Actual, Fecha2Actual, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 6:
                            {
                                dgvFactura.DataSource =
                                    miBussinesFactura.ConsultaPorCliente(ClienteActual, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 7:
                            {
                                dgvFactura.DataSource = miBussinesFactura.ConsultaPorEstadoYcliente
                                (EstadoActual, ClienteActual, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 8:
                            {
                                dgvFactura.DataSource = miBussinesFactura.ConsultaPorClienteIngreso
                                    (ClienteActual, Fecha1Actual, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 9:
                            {
                                dgvFactura.DataSource = miBussinesFactura.ConsultaPorEstadoClienteIngreso
                                    (EstadoActual, ClienteActual, Fecha1Actual, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 10:
                            {
                                dgvFactura.DataSource = miBussinesFactura.ConsultaPorClientePeriodoIngreso
                                      (ClienteActual, Fecha1Actual, Fecha2Actual, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 11:
                            {
                                dgvFactura.DataSource = miBussinesFactura.ConsultaPorEstadoClientePeriodoIngreso
                                    (EstadoActual, ClienteActual, Fecha1Actual, Fecha2Actual, RowFactura, RowMaxFactura);
                                break;
                            }
                    }
                    this.lblStatusFactura.Text = CurrentPageFactura + " / " + PaginasFactura;
                    this.dgvFactura_CellClick(this.dgvFactura, null);
                    FacturaAnulada();
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        /*
         * if (CurrentPageFactura > 1)
            {
         try
                {
                    switch (Iteracion)
                    {
                        case 1:
                            {
                                dgvFactura.DataSource = miBussinesFactura.ConsultaEstado
                                              (EstadoActual, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 2:
                            {
                                dgvFactura.DataSource = miBussinesFactura.ConsultaPorCliente
                                                 (ClienteActual, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 3:
                            {
                                dgvFactura.DataSource = miBussinesFactura.ConsultaPorEstadoYcliente
                                          (EstadoActual, ClienteActual, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 4:
                            {
                                dgvFactura.DataSource = miBussinesFactura.ConsultaEstadoFechaIngreso
                                            (EstadoActual, Fecha1Actual, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 5:
                            {
                                dgvFactura.DataSource = miBussinesFactura.ConsultaEstadoPeriodoIngreso
                                (EstadoActual, Fecha1Actual, Fecha2Actual, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 6:
                            {
                                dgvFactura.DataSource = miBussinesFactura.ConsultaPorClienteIngreso
                                          (ClienteActual, Fecha1Actual, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 7:
                            {
                                dgvFactura.DataSource = miBussinesFactura.ConsultaPorClientePeriodoIngreso
                                   (ClienteActual, Fecha1Actual, Fecha2Actual, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 8:
                            {
                                dgvFactura.DataSource = miBussinesFactura.ConsultaPorEstadoClientePeriodoIngreso
                                (EstadoActual, ClienteActual, Fecha1Actual, Fecha2Actual, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 9:
                            {
                                dgvFactura.DataSource = miBussinesFactura.ConsultaEstadoFechaLimite
                                           (EstadoActual, Fecha1Actual, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 10:
                            {
                                dgvFactura.DataSource = miBussinesFactura.ConsultaCreditoPeriodo
                                (EstadoActual, Fecha1Actual, Fecha2Actual, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 11:
                            {
                                dgvFactura.DataSource = miBussinesFactura.ConsultaClienteCreditoLimite
                                (ClienteActual, EstadoActual, Fecha1Actual, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 12:
                            {
                                dgvFactura.DataSource = miBussinesFactura.ConsultaClienteCreditoLimitePeriodo
                                (ClienteActual, EstadoActual, Fecha1Actual, Fecha2Actual, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 13:
                            {
                                dgvFactura.DataSource = miBussinesFactura.ConsultaEnMora
                                (EstadoActual, Fecha1Actual, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 14:
                            {
                                dgvFactura.DataSource = miBussinesFactura.ConsultaClienteEnMora
                                (ClienteActual, EstadoActual, Fecha1Actual, RowFactura, RowMaxFactura);
                                break;
                            }
                    }
                    lblStatusFactura.Text = CurrentPageFactura + " / " + PaginasFactura;
                    dgvFactura_CellClick(this.dgvFactura, null);
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
          }
         */




        //Metodos.

        /// <summary>
        /// Carga la lista de criterio General de consulta.
        /// </summary>
        private void CargarCriterioGeneral()
        {
            var lst = new List<Inventario.Producto.Criterio>();
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 1,
                Nombre = "Número"
            });
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 2,
                Nombre = "Estado"
            });
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 3,
                Nombre = "Cliente"
            });
            cbCriterio.DataSource = lst;

            //
            lst = new List<Inventario.Producto.Criterio>();
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 0,
                Nombre = "Todas"
            });
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 1,
                Nombre = "Contado"
            });
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 2,
                Nombre = "Crédito"
            });
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 3,
                Nombre = "Pendiente"
            });
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 4,
                Nombre = "Cotización"
            });
            cbEstado.DataSource = lst;

            //
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
            cbFecha.DataSource = lst;

            try
            {
                //this.PrintDetail_ = AppConfiguracion.ValorSeccion("");

                var configuracion = miBussinesConfiguracion.Configuracion(CodigoConfiguracionConsulta);
                if (!Convert.ToInt32(configuracion.Valor).Equals(0))
                {
                    this.cbCriterio.SelectedValue = Convert.ToInt32(configuracion.Valor);
                    this.cbCriterio_SelectionChangeCommitted(this.cbCriterio, new EventArgs());
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void CargarPrimerCriterio()
        {
        }

        private void CargarPrimerCriterioOpcion()
        {
            var lst = new List<Inventario.Producto.Criterio>();
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 0,
                Nombre = "Todas"
            });
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 1,
                Nombre = "Cancelada"
            });
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 2,
                Nombre = "Crédito"
            });
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 3,
                Nombre = "Pendiente"
            });
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 4,
                Nombre = "Cotización"
            });
            cbEstado.DataSource = lst;
        }

        private void CargarSegundoCriterio()
        {
        }

        private void CargarTercerCriterio()
        {
            var lst = new List<Inventario.Producto.Criterio>();
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 1,
                Nombre = "Fecha simple"
            });
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 2,
                Nombre = "Periodo de fechas"
            });
            //cbCriterio3.DataSource = lst;
        }

        /// <summary>
        /// Obtiene el resultado de la consulta de Factura de Venta por número.
        /// </summary>
        private void ConsultaNumero(string numero)
        {
            try
            {
                dgvFactura.DataSource = miBussinesFactura.ConsultaNumero(numero);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void ConsultaTodas() //iteracion = 0
        {
            RowFactura = 0;
            CurrentPageFactura = 1;
            Iteracion = 0;
            try
            {
                dgvFactura.DataSource = miBussinesFactura.ConsultaTodas(RowFactura, RowMaxFactura);
                this.TotalRowFactura = miBussinesFactura.GetRowsConsultaTodas();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            CalcularPaginas();
        }

        /// <summary>
        /// Obtiene el resultado de la consulta de Factura de Venta por Estado de la Factura.
        /// </summary>
        /// <param name="estado">Estado de la factura a consultar.</param>
        private void ConsultaEstado(int estado)//iteracion = 1
        {
            Iteracion = 1;
            RowFactura = 0;
            CurrentPageFactura = 1;
            EstadoActual = estado;
            try
            {
                dgvFactura.DataSource = miBussinesFactura.ConsultaEstado
                                        (estado, RowFactura, RowMaxFactura);
                TotalRowFactura = miBussinesFactura.GetRowsConsultaEstado(estado);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            CalcularPaginas();
        }

        private void ConsultaTodas(DateTime fecha)//iteracion = 2
        {
            RowFactura = 0;
            CurrentPageFactura = 1;
            Iteracion = 2;
            this.Fecha1Actual = fecha;
            try
            {
                dgvFactura.DataSource = miBussinesFactura.ConsultaTodas(fecha, RowFactura, RowMaxFactura);
                this.TotalRowFactura = miBussinesFactura.GetRowsConsultaTodas(fecha);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            CalcularPaginas();
        }

        private void ConsultaEstadoFechaIngreso(int estado, DateTime fecha)//iteracion = 3
        {
            Iteracion = 3;
            RowFactura = 0;
            CurrentPageFactura = 1;
            EstadoActual = estado;
            Fecha1Actual = fecha;
            try
            {
                dgvFactura.DataSource =
                    miBussinesFactura.ConsultaEstadoFechaIngreso(estado, fecha, RowFactura, RowMaxFactura);
                TotalRowFactura =
                    miBussinesFactura.GetRowsConsultaEstadoFechaIngreso(estado, fecha);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            CalcularPaginas();
        }

        private void ConsultaTodas(DateTime fecha, DateTime fecha2)//iteracion = 4
        {
            Iteracion = 4;
            RowFactura = 0;
            CurrentPageFactura = 1;
            this.Fecha1Actual = fecha;
            this.Fecha2Actual = fecha2;
            try
            {
                dgvFactura.DataSource = miBussinesFactura.ConsultaTodas(fecha, fecha2, RowFactura, RowMaxFactura);
                this.TotalRowFactura = miBussinesFactura.GetRowsConsultaTodas(fecha, fecha2);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            CalcularPaginas();
        }

        private void ConsultaEstadoPeriodoIngreso
            (int estado, DateTime fecha1, DateTime fecha2)//iteracion = 5
        {
            Iteracion = 5;
            RowFactura = 0;
            CurrentPageFactura = 1;
            EstadoActual = estado;
            Fecha1Actual = fecha1;
            Fecha2Actual = fecha2;
            try
            {
                dgvFactura.DataSource = miBussinesFactura.ConsultaEstadoPeriodoIngreso
                                        (estado, fecha1, fecha2, RowFactura, RowMaxFactura);

                TotalRowFactura =
                    miBussinesFactura.GetRowsConsultaEstadoPeriodoIngreso(estado, fecha1, fecha2);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            CalcularPaginas();
        }

        /// <summary>
        /// Obtiene el resultado de la consulta de Factura de Venta por Cliente 
        /// relacionado con la misma.
        /// </summary>
        /// <param name="cliente">Cliente a consultar factura de venta.</param>
        private void ConsultaTodasCliente(string cliente)//iteracion = 6
        {
            Iteracion = 6;
            RowFactura = 0;
            CurrentPageFactura = 1;
            ClienteActual = cliente;
            try
            {
                dgvFactura.DataSource = miBussinesFactura.ConsultaPorCliente
                                        (cliente, RowFactura, RowMaxFactura);
                TotalRowFactura = miBussinesFactura.GetRowsConsultaPorCliente(cliente);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            CalcularPaginas();
        }

        /// <summary>
        /// Obtiene el resultado de la consulta de Factura de Venta por estado y Cliente.
        /// </summary>
        /// <param name="estado">Estado de la factura a consultar.</param>
        /// <param name="cliente">Cliente a consultar factura de venta.</param>
        private void ConsultaEstadoCliente(int estado, string cliente)//iteracion = 7
        {
            Iteracion = 7;
            RowFactura = 0;
            CurrentPageFactura = 1;
            EstadoActual = estado;
            ClienteActual = cliente;
            try
            {
                dgvFactura.DataSource = miBussinesFactura.ConsultaPorEstadoYcliente
                                        (estado, cliente, RowFactura, RowMaxFactura);
                TotalRowFactura =
                    miBussinesFactura.GetRowsConsultaPorEstadoYcliente(estado, cliente);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            CalcularPaginas();
        }

        private void ConsultaPorClienteIngreso(string cliente, DateTime fecha)//iteracion = 8
        {
            Iteracion = 8;
            RowFactura = 0;
            CurrentPageFactura = 1;
            ClienteActual = cliente;
            Fecha1Actual = fecha;
            try
            {
                dgvFactura.DataSource = miBussinesFactura.ConsultaPorClienteIngreso
                                            (cliente, fecha, RowFactura, RowMaxFactura);
                TotalRowFactura = miBussinesFactura.GetRowsConsultaPorClienteIngreso(cliente, fecha);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            CalcularPaginas();
        }

        private void ConsultaPorClienteIngreso(string cliente, int estado, DateTime fecha)//iteracion = 9
        {
            Iteracion = 9;
            RowFactura = 0;
            CurrentPageFactura = 1;
            ClienteActual = cliente;
            EstadoActual = estado;
            Fecha1Actual = fecha;
            try
            {
                dgvFactura.DataSource = miBussinesFactura.ConsultaPorEstadoClienteIngreso
                                            (estado, cliente, fecha, RowFactura, RowMaxFactura);
                TotalRowFactura = miBussinesFactura.GetRowsConsultaPorEstadoClienteIngreso(estado, cliente, fecha);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            CalcularPaginas();
        }

        private void ConsultaPorClientePeriodoIngreso
            (string cliente, DateTime fecha1, DateTime fecha2)//iteracion = 10
        {
            Iteracion = 10;
            RowFactura = 0;
            CurrentPageFactura = 1;
            ClienteActual = cliente;
            Fecha1Actual = fecha1;
            Fecha2Actual = fecha2;
            try
            {
                dgvFactura.DataSource = miBussinesFactura.ConsultaPorClientePeriodoIngreso
                                              (cliente, fecha1, fecha2, RowFactura, RowMaxFactura);
                TotalRowFactura =
                    miBussinesFactura.GetRowsConsultaPorClientePeriodoIngreso(cliente, fecha1, fecha2);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            CalcularPaginas();
        }

        private void ConsultaPorEstadoClientePeriodoIngreso//iteracion = 11
            (string cliente, int estado, DateTime fecha1, DateTime fecha2)
        {
            Iteracion = 11;
            RowFactura = 0;
            CurrentPageFactura = 1;
            ClienteActual = cliente;
            EstadoActual = estado;
            Fecha1Actual = fecha1;
            Fecha2Actual = fecha2;
            try
            {
                dgvFactura.DataSource = miBussinesFactura.ConsultaPorEstadoClientePeriodoIngreso
                                            (estado, cliente, fecha1, fecha2, RowFactura, RowMaxFactura);
                TotalRowFactura =
                miBussinesFactura.GetRowsConsultaPorClientePeriodoIngreso(cliente, fecha1, fecha2);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            CalcularPaginas();
        }



        /*
        private void ConsultaClienteCreditoLimite//iteracion = 11
            (string cliente, int estado, DateTime fecha)
        {
            RowFactura = 0;
            CurrentPageFactura = 1;
            Iteracion = 11;
            ClienteActual = cliente;
            EstadoActual = estado;
            Fecha1Actual = fecha;
            try
            {
                dgvFactura.DataSource = miBussinesFactura.ConsultaClienteCreditoLimite
                                              (cliente, estado, fecha, RowFactura, RowMaxFactura);
                if (dgvFactura.RowCount == 0)
                {
                    LimpiarGridProducto();
                    OptionPane.MessageInformation
                        ("No se encontraron Facturas con ese cliente, en ese estado y en esa fecha.");
                }
                TotalRowFactura =
                    miBussinesFactura.GetRowsConsultaClienteCreditoLimite(cliente, estado, fecha);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            CalcularPaginas();
        }

        private void ConsultaEstadoFechaLimite(int estado, DateTime fecha)//iteracion = 9
        {
            RowFactura = 0;
            CurrentPageFactura = 1;
            Iteracion = 9;
            EstadoActual = estado;
            Fecha1Actual = fecha;
            try
            {
                dgvFactura.DataSource = 
                    miBussinesFactura.ConsultaEstadoFechaLimite(estado, fecha, RowFactura, RowMaxFactura);
                if (dgvFactura.RowCount == 0)
                {
                    LimpiarGridProducto();
                    OptionPane.MessageInformation("No se encontraron Facturas en ese estado y con esa fecha.");
                }
                TotalRowFactura =
                    miBussinesFactura.GetRowsConsultaEstadoFechaLimite(estado, fecha);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            CalcularPaginas();
        }

        private void ConsultaCreditoPeriodo//iteracion = 10
            (int estado, DateTime fecha1, DateTime fecha2)
        {
            RowFactura = 0;
            CurrentPageFactura = 1;
            Iteracion = 10;
            EstadoActual = estado;
            Fecha1Actual = fecha1;
            Fecha2Actual = fecha2;
            try
            {
                dgvFactura.DataSource = miBussinesFactura.ConsultaCreditoPeriodo
                                            (estado, fecha1, fecha2, RowFactura, RowMaxFactura);
                if (dgvFactura.RowCount == 0)
                {
                    LimpiarGridProducto();
                    OptionPane.MessageInformation("No se encontraron Facturas en ese estado y entre esas fechas.");
                }
                TotalRowFactura =
                    miBussinesFactura.GetRowsConsultaCreditoPeriodo(estado, fecha1, fecha2);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            CalcularPaginas();
        }

        private void ConsultaClienteCreditoLimitePeriodo//iteracion = 12
            (string cliente, int estado, DateTime fecha1, DateTime fecha2)
        {
            RowFactura = 0;
            CurrentPageFactura = 1;
            Iteracion = 12;
            ClienteActual = cliente;
            EstadoActual = estado;
            Fecha1Actual = fecha1;
            Fecha2Actual = fecha2;
            try
            {
                dgvFactura.DataSource = miBussinesFactura.ConsultaClienteCreditoLimitePeriodo
                                        (cliente, estado, fecha1, fecha2, RowFactura, RowMaxFactura);
                if (dgvFactura.RowCount == 0)
                {
                    LimpiarGridProducto();
                    OptionPane.MessageInformation
                        ("No se encontraron Facturas con ese cliente, en ese estado y entre esas fechas.");
                }
                TotalRowFactura =
                miBussinesFactura.GetRowsConsultaClienteCreditoLimitePeriodo(cliente, estado, fecha1, fecha2);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            CalcularPaginas();
        }

        private void ConsultaEnMora(int estado, DateTime fecha)//iteracion = 13
        {
            RowFactura = 0;
            CurrentPageFactura = 1;
            Iteracion = 13;
            try
            {
                dgvFactura.DataSource = 
                    miBussinesFactura.ConsultaEnMora(estado, fecha, RowFactura, RowMaxFactura);
                if (dgvFactura.RowCount == 0)
                {
                    LimpiarGridProducto();
                    OptionPane.MessageInformation("No se encontraron Facturas en mora.");
                }
                TotalRowFactura = miBussinesFactura.GetRowsConsultaEnMora(estado, fecha);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            CalcularPaginas();
        }

        private void ConsultaClienteEnMora//iteracion = 14
            (string cliente, int estado, DateTime fecha)
        {
            RowFactura = 0;
            CurrentPageFactura = 1;
            Iteracion = 14;
            ClienteActual = cliente;
            try
            {
                dgvFactura.DataSource = 
                miBussinesFactura.ConsultaClienteEnMora(cliente, estado, fecha, RowFactura, RowMaxFactura);
                if (dgvFactura.RowCount == 0)
                {
                    LimpiarGridProducto();
                    OptionPane.MessageInformation("No se encontraron Facturas en mora de ese cliente.");
                }
                TotalRowFactura = 
                    miBussinesFactura.GetRowsConsultaClienteEnMora(cliente, estado, fecha);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            CalcularPaginas();
        }
        */
        /*
            RowFactura = 0;
            CurrentPageFactura = 1;
            Iteracion = ;
            try
            {
                dgvFactura.DataSource = miBussinesFactura
                if (dgvFactura.RowCount == 0)
                {
                    LimpiarGridProducto();
                    OptionPane.MessageInformation("No se encontraron Facturas en ese estado.");
                }
                //TotalRowFactura = miBussinesFactura
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            CalcularPaginas();
         */

        void CompletaEventos_Completo(CompletaArgumentosDeEvento args)
        {
            try
            {
                if (Convert.ToInt32(args.MiObjeto) == 15)
                {
                    ExtendForms = false;
                }
            }
            catch { }
        }

        void CompletaEventos_ComAbonoFact(CompArgAbonoFact args)
        {
            try
            {
                /*var data = (bool)args.MiObjeto;
                if (data)
                {
                    dgvFactura_CellClick(this.dgvFactura, new DataGridViewCellEventArgs
                        (dgvFactura.CurrentCell.ColumnIndex, dgvFactura.CurrentCell.RowIndex));
                }
                else
                {
                    if (BtnSearch)
                    {
                        this.btnBuscar1_Click(this.btnBuscar1, new EventArgs());
                    }
                    else
                    {
                        this.btnBuscar_Click(this.btnBuscar, new EventArgs());
                    }
                }*/
                var data = (int)args.MiObjeto;
                if (data.Equals(110)) // proviene de abono de factura.
                {
                    dgvFactura_CellClick(this.dgvFactura, new DataGridViewCellEventArgs
                        (dgvFactura.CurrentCell.ColumnIndex, dgvFactura.CurrentCell.RowIndex));
                }
                else
                {
                    if (data.Equals(112))  // proviene de edicion de factura.
                    {
                        if (this.Edition)
                        {
                            this.btnBuscar_Click(this.btnBuscar, new EventArgs());
                            this.Edition = false;
                            /*if (BtnSearch)
                            {
                               // this.btnBuscar1_Click(this.btnBuscar1, new EventArgs());
                            }
                            else
                            {
                               // this.btnBuscar_Click(this.btnBuscar, new EventArgs());
                            }*/
                        }
                    }
                }
            }
            catch { }

            try
            {
                var numero = (string)args.MiObjeto;
                dgvFactura_CellClick(this.dgvFactura, new DataGridViewCellEventArgs
                        (dgvFactura.CurrentCell.ColumnIndex, dgvFactura.CurrentCell.RowIndex));
            }
            catch { }

            try
            {
                this.Edition = Convert.ToBoolean(args.MiObjeto);
            }
            catch { }
        }

        void CompletaEventos_Completabo(CompletaArgumentosDeEventobo args)
        {
            try
            {
                txtCodigo.Text = (string)args.MiBodegabo;
                //btnBuscar.Focus();
            }
            catch { }

            try
            {
                ExtendForms = (bool)args.MiBodegabo;
            }
            catch { }
        }





        /// <summary>
        /// Limpia los registro del DataGrid de Producto.
        /// </summary>
        private void LimpiarGridProducto()
        {
            while (dgvListaArticulos.RowCount != 0)
            {
                dgvListaArticulos.Rows.RemoveAt(0);
            }
            LimpiarTotales();
        }

        /// <summary>
        /// Calcula y muestra el número de paginas devueltas en la consulta.
        /// </summary>
        private void CalcularPaginas()
        {
            PaginasFactura = TotalRowFactura / RowMaxFactura;
            if (TotalRowFactura % RowMaxFactura != 0)
                PaginasFactura++;
            if (CurrentPageFactura > PaginasFactura)
                CurrentPageFactura = 0;
            lblStatusFactura.Text = CurrentPageFactura + " / " + PaginasFactura;
        }

        /// <summary>
        /// Consulta y calcula los totales correspondientes a la factura.
        /// </summary>
        /// <param name="tabla">Tabla que almacena los registros de articulos de la factura.</param>
        private void CalcularTotales(DataTable tabla, List<Iva> ivaFacturado, DataTable retenciones)
        {
            int descto_ = Convert.ToInt32
                  (tabla.AsEnumerable()
                   .Sum(d => ((d.Field<double>("ValorUnitario") *
                               UseObject.RemoveCharacter(d["Descuento"].ToString(), '%') / 100) *
                               d.Field<double>("Cantidad"))));

            txtSubTotal.Text = UseObject.InsertSeparatorMil((ivaFacturado.Sum(s => s.BaseI) + descto_).ToString());
            /*txtSubTotal.Text = UseObject.InsertSeparatorMil
                (Convert.ToInt32
                  (tabla.AsEnumerable().Sum(s => (s.Field<double>("ValorUnitario") *
                                            s.Field<double>("Cantidad")))).ToString()
                );*/

            txtDescuento.Text = UseObject.InsertSeparatorMil(descto_.ToString());
            /*txtDescuento.Text = UseObject.InsertSeparatorMil
                (Convert.ToInt32
                  (tabla.AsEnumerable()
                   .Sum(d => ((d.Field<double>("ValorUnitario") *
                               UseObject.RemoveCharacter(d["Descuento"].ToString(), '%') / 100) *
                               d.Field<double>("Cantidad"))))
                   .ToString()
                );*/

            txtIva.Text = UseObject.InsertSeparatorMil(ivaFacturado.Sum(s => s.ValorIva).ToString());
            /* txtIva.Text = UseObject.InsertSeparatorMil
                 (Convert.ToInt32
                   (tabla.AsEnumerable().Sum(i => (i.Field<double>("ValorIva") *
                                             i.Field<double>("Cantidad")))).ToString()
                 );*/

            txtTotal.Text = UseObject.InsertSeparatorMil
                (
                  (Convert.ToInt32(tabla.AsEnumerable().Sum(t => t.Field<double>("Valor"))) +
                   UseObject.RemoveSeparatorMil(this.txtImpstoBolsas.Text)).ToString()
                );

            if (retenciones.Rows.Count != 0)
            {
                var tasa = Convert.ToDouble(retenciones.AsEnumerable().Single()["tarifa"]);
                miToolTip.SetToolTip(btnInfoRete,
                                     retenciones.AsEnumerable().Single()["concepto"].ToString() + " - " +
                                     tasa.ToString() + "%");

                txtRetencion.Text = UseObject.InsertSeparatorMil
                        (Convert.ToInt32(UseObject.RemoveSeparatorMil(this.txtSubTotal.Text) * tasa / 100).ToString());
                /*var totalFact = Convert.ToInt32
                               (tabla.AsEnumerable().Sum(t => (t.Field<double>("Valor"))));
                txtRetencion.Text = UseObject.InsertSeparatorMil
                        (Convert.ToInt32(totalFact * tasa / 100).ToString());*/
            }
            else
            {
                miToolTip.SetToolTip(btnInfoRete, "");
                txtRetencion.Text = "0";
            }
        }

        private void ColorearGrid()
        {
            foreach (DataGridViewRow row in this.dgvListaArticulos.Rows)
            {
                if (Convert.ToBoolean(row.Cells["Retorno"].Value))
                {
                    row.DefaultCellStyle.BackColor = System.Drawing.Color.Cyan;
                }
            }
        }

        private void LimpiarTotales()
        {
            txtSubTotal.Text = "0";
            txtDescuento.Text = "0";
            txtIva.Text = "0";
            txtTotal.Text = "0";
            txtRetencion.Text = "0";
            txtSaldoDevolucion.Text = "0";
            txtTotalPago.Text = "0";
            txtAbono.Text = "0";
            txtResta.Text = "0";
        }

        private void PagosAFactura(string numero)
        {
            var miBussinesDevolucion = new BussinesDevolucion();
            try
            {
                var pagos = miBussinesFormaPago.GetTotalPagoDeFacturaVentaId(Convert.ToInt32(this.dgvFactura.CurrentRow.Cells["IdFactura"].Value)); //miBussinesFormaPago.GetTotalPagoDeFacturaVenta(numero);
                var saldoDev = miBussinesDevolucion.SaldoDevolucionVenta(numero);
                txtSaldoDevolucion.Text = UseObject.InsertSeparatorMil(saldoDev.ToString());
                txtTotalPago.Text = UseObject.InsertSeparatorMil((
                                    UseObject.RemoveSeparatorMil(txtTotal.Text) -
                                    UseObject.RemoveSeparatorMil(txtRetencion.Text) -
                                    UseObject.RemoveSeparatorMil(txtSaldoDevolucion.Text)).ToString());
                /*txtTotalPago.Text = UseObject.InsertSeparatorMil((
                                    UseObject.RemoveSeparatorMil(txtTotal.Text) -
                                    UseObject.RemoveSeparatorMil(txtRetencion.Text) -
                                    UseObject.RemoveSeparatorMil(txtSaldoDevolucion.Text)).ToString());*/
                if (pagos > UseObject.RemoveSeparatorMil(txtTotalPago.Text))
                {
                    txtAbono.Text = txtTotalPago.Text;
                    txtResta.Text = "0";
                }
                else
                {
                    txtAbono.Text = UseObject.InsertSeparatorMil(pagos.ToString());
                    if ((pagos /*+ saldoDev*/) >= Convert.ToInt32(UseObject.RemoveSeparatorMil(txtTotalPago.Text)))
                    {
                        txtResta.Text = "0";
                    }
                    else
                    {
                        txtResta.Text = UseObject.InsertSeparatorMil(
                            (UseObject.RemoveSeparatorMil(txtTotalPago.Text) - (pagos)).ToString());
                    }

                    /*if ((pagos + saldoDev) >= Convert.ToInt32(UseObject.RemoveSeparatorMil(this.txtTotal.Text)))
                    {
                        txtResta.Text = "0";
                    }
                    else
                    {
                        txtResta.Text = UseObject.InsertSeparatorMil(
                            (UseObject.RemoveSeparatorMil(this.txtTotal.Text) - (pagos + saldoDev)).ToString());
                    }*/
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void FacturaAnulada()
        {
            foreach (DataGridViewRow row in dgvFactura.Rows)
            {
                if (!Convert.ToBoolean(row.Cells["Activa"].Value))
                {
                    //row.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(255, 128, 128);
                    row.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(200, 128, 128);
                }
            }
        }

        /// <summary>
        /// Obtiene los registro de Productos de la consulta de Factura en 
        /// una tabla de memoria.
        /// </summary>
        /// <returns></returns>
        private DataTable Productos()
        {
            var tabla = CrearTabla();
            foreach (DataGridViewRow row in dgvListaArticulos.Rows)
            {
                var row_ = tabla.NewRow();
                row_["Save"] = false;
                row_["Id"] = (int)row.Cells["IdProducto"].Value;
                row_["Codigo"] = row.Cells["Codigo"].Value.ToString();
                row_["Articulo"] = row.Cells["Articulo"].Value.ToString();
                row_["Cantidad"] = (double)row.Cells["Cantidad"].Value;
                var v = row.Cells["Valor"].Value.ToString();
                row_["ValorUnitario"] = Convert.ToDouble(row.Cells["Valor"].Value);
                v = row_["ValorUnitario"].ToString();
                row_["Descuento"] = row.Cells["Descto"].Value.ToString();
                row_["ValorMenosDescto"] = (double)row.Cells["ValorMenosDescto"].Value;
                row_["Iva"] = row.Cells["Iva"].Value.ToString();
                row_["ValorIva"] = (double)row.Cells["ValorIva"].Value;
                row_["TotalMasIva"] = (double)row.Cells["TotalMasIva"].Value;
                row_["Valor"] = (double)row.Cells["Total"].Value;
                row_["Unidad"] = row.Cells["Unidad"].Value.ToString();
                row_["IdMedida"] = (int)row.Cells["IdMedida"].Value;
                row_["Medida"] = row.Cells["Medida"].Value.ToString();
                row_["IdColor"] = (int)row.Cells["IdColor"].Value;
                row_["Color"] = (Image)row.Cells["Color"].Value;
                row_["IdMarca"] = (int)row.Cells["IdMarca"].Value; 
                row_["ValorReal"] = Convert.ToDouble(row.Cells["ValorReal"].Value);//
                row_["Retorno"] = Convert.ToBoolean(row.Cells["Retorno"].Value);
                row_["Ico"] = Convert.ToInt32(row.Cells["Ico"].Value); //Ico
                row_["IdIva"] = 0;
                tabla.Rows.Add(row_);
            }
            return tabla;
        }

        /// <summary>
        /// Obtiene una tabla en memoria de los productos de la Factura.
        /// </summary>
        /// <returns></returns>
        private DataTable CrearTabla()
        {
            var miTabla = new DataTable();
            miTabla.Columns.Add(new DataColumn("Id", typeof(int)));
            miTabla.Columns.Add(new DataColumn("Codigo", typeof(string)));
            miTabla.Columns.Add(new DataColumn("Articulo", typeof(string)));
            miTabla.Columns.Add(new DataColumn("Cantidad", typeof(string)));
            miTabla.Columns.Add(new DataColumn("ValorUnitario", typeof(double)));
            miTabla.Columns.Add(new DataColumn("Descuento", typeof(string)));
            miTabla.Columns.Add(new DataColumn("ValorMenosDescto", typeof(double)));
            miTabla.Columns.Add(new DataColumn("Iva", typeof(string)));
            miTabla.Columns.Add(new DataColumn("TotalMasIva", typeof(double)));
            miTabla.Columns.Add(new DataColumn("Valor", typeof(double)));
            miTabla.Columns.Add(new DataColumn("Unidad", typeof(string)));
            miTabla.Columns.Add(new DataColumn("IdMedida", typeof(int)));
            miTabla.Columns.Add(new DataColumn("Medida", typeof(string)));
            miTabla.Columns.Add(new DataColumn("IdMarca", typeof(int)));
            miTabla.Columns.Add(new DataColumn("IdColor", typeof(int)));
            miTabla.Columns.Add(new DataColumn("Color", typeof(Image)));
            miTabla.Columns.Add(new DataColumn("Save", typeof(bool)));
            miTabla.Columns.Add(new DataColumn("ValorReal", typeof(double)));
            miTabla.Columns.Add(new DataColumn("Retorno", typeof(bool)));
            miTabla.Columns.Add(new DataColumn("Ico", typeof(double)));
            miTabla.Columns.Add(new DataColumn("ValorIva", typeof(double)));
            miTabla.Columns.Add(new DataColumn("IdIva", typeof(int)));
            return miTabla;
        }

        private void IngresarAbono(List<FormaPago> pagos)
        {
            //(string)dgvFactura.CurrentRow.Cells["Numero"].Value;
            var miBussinesIngreso = new BussinesIngreso();
            foreach (FormaPago pago in pagos)
            {
                if (pago.Valor != 0)
                {
                    pago.NumeroFactura = dgvFactura.CurrentRow.Cells["Numero"].Value.ToString();
                    pago.Usuario.Id = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_user"));
                    pago.Caja.Id = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_caja"));
                    pago.Fecha = DateTime.Now;

                    var ingreso = new Ingreso();
                    ingreso.Numero = AppConfiguracion.ValorSeccion("ingreso");
                    ingreso.Concepto = "Abono a Factura Número: " + pago.NumeroFactura;
                    //ingreso.Tipo = 2;
                    ingreso.Fecha = pago.Fecha;
                    ingreso.Valor = Convert.ToInt32(pagos.Sum(p => p.Valor));
                    ingreso.Estado = true;
                    ingreso.Relacion = miBussinesFormaPago.IngresarPagoAFactura(pago, true, Convert.ToBoolean(AppConfiguracion.ValorSeccion("printIngreso")));
                    miBussinesIngreso.Ingresar(ingreso, false);
                    OptionPane.MessageInformation("El abono se realizó con éxito.");
                }
            }
        }

        private void Print
            (int id, string numero, bool descto, string cliente, bool contado, int idEstado, bool view)
        {
            var miBussinesRetencion = new BussinesRetencion();
            var dsDetalle = new DataSet();
            var dsEmpresa = new DataSet();
            var dsFactura = new DataSet();
            var dsUsuario = new DataSet();
            var dsCliente = new DataSet();
            var dsDian = new DataSet();
            try
            {
                /*var empresa = miBussinesEmpresa.ObtenerEmpresa();
                dsDetalle = miBussinesFactura.PrintProducto(numero, descto);
                dsEmpresa = miBussinesEmpresa.PrintEmpresa();
                dsFactura = miBussinesFactura.PrintFacturaVenta(numero);
                dsUsuario = miBussinesUsuario.PrintUsuario(numero);
                dsCliente = miBussinesCliente.PrintCliente(cliente);
                if (idEstado.Equals(4))
                {
                    dsDian = miBussinesDian.PrintVoid();
                }
                else
                {
                    dsDian = miBussinesDian.Print(true);
                }

                LocalReport report = new LocalReport();
                if (empresa.Regimen.IdRegimen.Equals(1))
                {
                    report.ReportPath = AppConfiguracion.ValorSeccion("report") + @"\reports\FacturaVenta.rdlc";
                }
                else
                {
                    report.ReportPath = AppConfiguracion.ValorSeccion("report") + @"\reports\FacturaVentaSimplificado.rdlc";
                }

                report.DataSources.Add(
                  new ReportDataSource("DsDetalle", dsDetalle.Tables["Detalle"]));
                report.DataSources.Add(
                    new ReportDataSource("DsEmpresa", dsEmpresa.Tables["Empresa"]));
                report.DataSources.Add(
                    new ReportDataSource("DsFacturaVenta", dsFactura.Tables["FacturaVenta"]));
                report.DataSources.Add(
                    new ReportDataSource("DsUsuario", dsUsuario.Tables["Usuario"]));
                report.DataSources.Add(
                    new ReportDataSource("DsCliente", dsCliente.Tables["Cliente"]));

                var Fact = new ReportParameter();
                Fact.Name = "Fact";

                var pResDian = new ReportParameter();
                pResDian.Name = "ResDian";
                if (empresa.Regimen.IdRegimen.Equals(1))
                {
                    pResDian.Values.Add(dsDian.Tables["TDian"].AsEnumerable().First()["print_dian"].ToString());
                    if (idEstado == 1 || idEstado == 2)
                    {
                        Fact.Values.Add("FACTURA DE VENTA No.  " + numero);
                    }
                    else
                    {
                        if (idEstado == 4)
                        {
                            Fact.Values.Add("COTIZACIÓN No. " + numero);
                        }
                    }
                }
                else
                {
                    pResDian.Values.Add(" ");
                    Fact.Values.Add("FACTURA DE VENTA No. " + numero);
                }
                report.SetParameters(Fact);
                report.SetParameters(pResDian);

                var pago = new ReportParameter();
                pago.Name = "pago";
                if (idEstado.Equals(1) || idEstado.Equals(4))
                {
                    pago.Values.Add("Contado");
                }
                else
                {
                    if (idEstado == 2)
                    {
                        pago.Values.Add("Crédito");
                    }
                }
                report.SetParameters(pago);

                var totalRete = miBussinesRetencion.ValorRetencionAventa(numero, descto);
                var tReteParam = new ReportParameter();
                tReteParam.Name = "Retencion";
                tReteParam.Values.Add(totalRete.ToString());
                report.SetParameters(tReteParam);

                Imprimir print = new Imprimir();
                print.Report = report;
                print.Print();*/

                var empresa = miBussinesEmpresa.ObtenerEmpresa();
                dsDetalle = miBussinesFactura.PrintProducto(id, descto);
                dsEmpresa = miBussinesEmpresa.PrintEmpresa();
                dsFactura = miBussinesFactura.PrintFacturaVenta(id);
                dsUsuario = miBussinesUsuario.PrintUsuarioVenta(id);
                dsCliente = miBussinesCliente.PrintCliente(cliente);
                //var dianRow = miBussinesDian.ConsultaDian().AsEnumerable().Last();
                var dian = miBussinesDian.ConsultaDian(Convert.ToInt32(dsFactura.Tables["FacturaVenta"].AsEnumerable().First()["id_resolucion_dian"]));

                var DetalleIva = this.miBussinesFactura.IvaFacturado(id);

                /*if (idEstado.Equals(4))
                {
                    dsDian = miBussinesDian.PrintVoid();
                }
                else
                {
                    dsDian = miBussinesDian.Print(true);
                }*/

                var frmPrint = new FrmPrintFactura();

                frmPrint.RptvFactura.LocalReport.DataSources.Clear();
                frmPrint.RptvFactura.LocalReport.Dispose();
                frmPrint.RptvFactura.Reset();

                frmPrint.RptvFactura.LocalReport.DataSources.Add(
                   new ReportDataSource("DsDetalle", dsDetalle.Tables["Detalle"]));
                frmPrint.RptvFactura.LocalReport.DataSources.Add(
                    new ReportDataSource("DsEmpresa", dsEmpresa.Tables["Empresa"]));
                frmPrint.RptvFactura.LocalReport.DataSources.Add(
                    new ReportDataSource("DsFacturaVenta", dsFactura.Tables["FacturaVenta"]));
                frmPrint.RptvFactura.LocalReport.DataSources.Add(
                    new ReportDataSource("DsUsuario", dsUsuario.Tables["Usuario"]));
                frmPrint.RptvFactura.LocalReport.DataSources.Add(
                    new ReportDataSource("DsCliente", dsCliente.Tables["Cliente"]));

               if (empresa.Regimen.IdRegimen.Equals(1))
               {
                   frmPrint.RptvFactura.LocalReport.ReportPath = AppConfiguracion.ValorSeccion("report") + @"\reports\FacturaVenta_carta_act.rdlc";

                   ///frmPrint.RptvFactura.LocalReport.ReportPath = AppConfiguracion.ValorSeccion("report") + @"\reports\FacturaVenta.rdlc";
                   ///frmPrint.RptvFactura.LocalReport.ReportPath = @"C:\reports\FacturaVenta_carta_act.rdlc";

                   //frmPrint.RptvFactura.LocalReport.ReportPath = @"C:\reports\FacturaVenta_carta.rdlc";
               }
               else
               {
                   frmPrint.RptvFactura.LocalReport.ReportPath = AppConfiguracion.ValorSeccion("report") + @"\reports\FacturaVentaSimplificado.rdlc";
                   ///frmPrint.RptvFactura.LocalReport.ReportPath = @"C:\reports\FacturaVentaSimplificado.rdlc";
               }
                //frmPrint.RptvFactura.LocalReport.ReportPath = AppConfiguracion.ValorSeccion("report") + @"\reports\RptFacturaVenta_vc.rdlc";

                //frmPrint.RptvFactura.LocalReport.ReportPath = AppConfiguracion.ValorSeccion("report") + @"\reports\FacturaVenta.rdlc";
                //frmPrint.RptvFactura.LocalReport.ReportPath = @"C:\reports\FacturaVenta.rdlc";

                Label NoFactura = new Label();
                NoFactura.AutoSize = true;
                NoFactura.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                NoFactura.Text = numero;

                var Fact = new ReportParameter();
                Fact.Name = "Fact";

                var pResDian = new ReportParameter();
                pResDian.Name = "ResDian";
                if (empresa.Regimen.IdRegimen.Equals(1))
                {
                    pResDian.Values.Add(
                        "AUTORIZACIÓN NUMERACIÓN DE FACTURACIÓN " + dian.NumeroResolucion +
                        " DE " + dian.FechaExpedicion.ToShortDateString() + 
                        " AUTORIZA DESDE " + dian.SerieInicial + dian.RangoInicial +
                        " HASTA " + dian.SerieInicial + dian.RangoFinal + 
                        " VIGENCIA " + dian.VigenciaMes + 
                        " MESES.");
                    /*AUTORIZACIÓN NUMERACIÓN DE FACTURACIÓN $NUM DE $FECHA AUTORIZA $PREFIJO DESDE $INICIO HASTA $FINAL VIGENCIA $VIGENCIA MESES.*/

                    /**
                    pResDian.Values.Add(dianRow["TxtInicial"].ToString() + dianRow["Resolucion"].ToString() + " de " +
                        Convert.ToDateTime(dianRow["Fecha"]).ToShortDateString() +
                        " del " + dianRow["Desde"].ToString() + " al " + dianRow["Hasta"].ToString() + " " + dianRow["TxtFinal"].ToString() + ".");
                    */

                    /*var j = dsDian.Tables["TDian"].AsEnumerable().Last()["print_dian"].ToString();
                    pResDian.Values.Add(dsDian.Tables["TDian"].AsEnumerable().Last()["print_dian"].ToString());*/
                    /*pResDian.Values.Add("Resolución DIAN No. " + dianRow["Resolucion"].ToString() + " de " +
                        Convert.ToDateTime(dianRow["Fecha"]).ToShortDateString() + " del " + dianRow["Desde"].ToString() + " al " +
                        dianRow["Hasta"].ToString() + " autoriza.");*/

                    /*pResDian.Values.Add(dianRow["TxtInicial"].ToString() + " " + dianRow["Resolucion"].ToString() + " de " + Convert.ToDateTime(dianRow["Fecha"]).ToShortDateString()
                        + " del " + dianRow["Desde"].ToString() + " al " + dianRow["Hasta"].ToString() + " " + dianRow["TxtFinal"].ToString() + ".");*/

                    if (idEstado == 1 || idEstado == 2)
                    {
                        Fact.Values.Add("FACTURA DE VENTA No.  " + NoFactura.Text);
                    }
                    else
                    {
                        if (idEstado == 4)
                        {
                            Fact.Values.Add("COTIZACIÓN No. " + numero);
                        }
                    }
                }
                else
                {
                    pResDian.Values.Add(" ");
                    Fact.Values.Add("FACTURA DE VENTA No. " + NoFactura.Text);
                }
                frmPrint.RptvFactura.LocalReport.SetParameters(Fact);
                frmPrint.RptvFactura.LocalReport.SetParameters(pResDian);

                var pago = new ReportParameter();
                pago.Name = "pago";
                if (idEstado.Equals(1) || idEstado.Equals(4))
                {
                    pago.Values.Add("Contado");
                }
                else
                {
                    if (idEstado == 2)
                    {
                        pago.Values.Add("Crédito");
                    }
                }
                frmPrint.RptvFactura.LocalReport.SetParameters(pago);

               

                var subTotalParam = new ReportParameter();
                subTotalParam.Name = "subTotal";
                subTotalParam.Values.Add(UseObject.RemoveSeparatorMil(this.txtSubTotal.Text).ToString());
                frmPrint.RptvFactura.LocalReport.SetParameters(subTotalParam);

                var desctoParam = new ReportParameter();
                desctoParam.Name = "descto";
                desctoParam.Values.Add(UseObject.RemoveSeparatorMil(this.txtDescuento.Text).ToString());
                frmPrint.RptvFactura.LocalReport.SetParameters(desctoParam);

                ///if (empresa.Regimen.IdRegimen.Equals(1))
                //{
                    var ivaParam = new ReportParameter();
                    ivaParam.Name = "iva";
                    ivaParam.Values.Add(UseObject.RemoveSeparatorMil(this.txtIva.Text).ToString());
                    frmPrint.RptvFactura.LocalReport.SetParameters(ivaParam);
                //}

                //var totalRete = miBussinesRetencion.ValorRetencionAventa(numero, descto);
                var totalRete = miBussinesRetencion.ValorRetencionAventa(numero, id, descto);
                var tReteParam = new ReportParameter();
                tReteParam.Name = "Retencion";
                tReteParam.Values.Add(totalRete.ToString());
                frmPrint.RptvFactura.LocalReport.SetParameters(tReteParam);

                var totalParam = new ReportParameter();
                totalParam.Name = "total";
                totalParam.Values.Add(UseObject.RemoveSeparatorMil(this.txtTotalPago.Text).ToString());
                frmPrint.RptvFactura.LocalReport.SetParameters(totalParam);


                frmPrint.RptvFactura.RefreshReport();

                if (view)
                {
                    frmPrint.ShowDialog();
                }
                else
                {
                    Imprimir print = new Imprimir();
                    print.Report = frmPrint.RptvFactura.LocalReport;
                    print.Print(Imprimir.TamanioPapel.MediaCarta);
                    frmPrint.ResetReport();
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        /*private void Print(string numero, bool descto, string cliente, bool contado, int idEstado)
        {
            var miBussinesRetencion = new BussinesRetencion();
            var dsDetalle = new DataSet();
            var dsEmpresa = new DataSet();
            var dsFactura = new DataSet();
            var dsUsuario = new DataSet();
            var dsCliente = new DataSet();
            var dsDian = new DataSet();
            try
            {
                dsDetalle = miBussinesFactura.PrintProducto(numero, descto);
                dsEmpresa = miBussinesEmpresa.PrintEmpresa();
                dsFactura = miBussinesFactura.PrintFacturaVenta(numero);
                dsUsuario = miBussinesUsuario.PrintUsuario(numero);
                dsCliente = miBussinesCliente.PrintCliente(cliente);
                
                    dsDian = miBussinesDian.Print(true);

                var frmPrint = new FrmPrintFactura();
                //frmPrint.MdiParent = this.MdiParent;

                frmPrint.RptvFactura.LocalReport.DataSources.Clear();
                frmPrint.RptvFactura.LocalReport.Dispose();
                frmPrint.RptvFactura.Reset();

                frmPrint.RptvFactura.LocalReport.DataSources.Add(
                    new ReportDataSource("DsDian", dsDian.Tables["TDian"]));
                frmPrint.RptvFactura.LocalReport.DataSources.Add(
                   new ReportDataSource("DsDetalle", dsDetalle.Tables["Detalle"]));
                frmPrint.RptvFactura.LocalReport.DataSources.Add(
                    new ReportDataSource("DsEmpresa", dsEmpresa.Tables["Empresa"]));
                frmPrint.RptvFactura.LocalReport.DataSources.Add(
                    new ReportDataSource("DsFacturaVenta", dsFactura.Tables["FacturaVenta"]));
                frmPrint.RptvFactura.LocalReport.DataSources.Add(
                    new ReportDataSource("DsUsuario", dsUsuario.Tables["Usuario"]));
                frmPrint.RptvFactura.LocalReport.DataSources.Add(
                    new ReportDataSource("DsCliente", dsCliente.Tables["Cliente"]));

                //frmPrint.RptvFactura.LocalReport.ReportPath = @"..\..\Ventas\Reportes\RptFacturaVenta.rdlc";
                //frmPrint.RptvFactura.LocalReport.ReportPath = @"C:\reports\RptFacturaVenta.rdlc";
                frmPrint.RptvFactura.LocalReport.ReportPath = AppConfiguracion.ValorSeccion("report") + @"\reports\RptFacturaVenta_vc.rdlc";

                Label NoFactura = new Label();
                NoFactura.AutoSize = true;
                NoFactura.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                NoFactura.Text = numero;

                var Fact = new ReportParameter();
                Fact.Name = "Fact";
                if (idEstado == 1 || idEstado == 2)
                {
                    Fact.Values.Add("FACTURA DE VENTA No.  " + NoFactura.Text);
                }
                else
                {
                    if (idEstado == 4)
                    {
                        Fact.Values.Add("COTIZACIÓN");
                    }
                }
                frmPrint.RptvFactura.LocalReport.SetParameters(Fact);

                var pago = new ReportParameter();
                pago.Name = "pago";
                if (idEstado == 1)
                {
                    pago.Values.Add("Contado");
                }
                else
                {
                    if (idEstado == 2)
                    {
                        pago.Values.Add("Crédito");
                    }
                }
                frmPrint.RptvFactura.LocalReport.SetParameters(pago);

                var totalRete = miBussinesRetencion.ValorRetencionAventa(numero, descto);
                var tReteParam = new ReportParameter();
                tReteParam.Name = "Retencion";
                tReteParam.Values.Add(totalRete.ToString());
                frmPrint.RptvFactura.LocalReport.SetParameters(tReteParam);

                frmPrint.RptvFactura.RefreshReport();
                frmPrint.ShowDialog();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }*/

        private void PrintPos
            (int id, string numero, bool descto, string cliente, bool contado, int idEstado, int pago)
        {
            try
            {
                var facturaRow = miBussinesFactura.PrintFacturaVenta(id).Tables[0].AsEnumerable().First();

                PrintTicket printTicket = new PrintTicket();
                printTicket.UseItem = false;
                printTicket.Detail = this.GraneroJhonRiosucio;
                printTicket.EsFactura = true;
                printTicket.Copia = true;

                printTicket.empresaRow = this.RowEmpresa;// this.miBussinesEmpresa.PrintEmpresa().Tables[0].AsEnumerable().First();

                printTicket.IdEstado = idEstado;
                printTicket.Numero = numero;
                printTicket.Fecha = Convert.ToDateTime(facturaRow["Fecha"]);
                printTicket.Hora = Convert.ToDateTime(facturaRow["Hora"]);
                printTicket.Limite = Convert.ToDateTime(facturaRow["FechaLimite"]);

                printTicket.Usuario = this.miBussinesUsuario.PrintUsuarioVenta(id).Tables[0].AsEnumerable().First()["Nombre"].ToString();

                printTicket.NoCaja = facturaRow["Caja"].ToString();
                printTicket.Station = facturaRow["estacion"].ToString();

                printTicket.clienteRow = this.miBussinesCliente.ConsultaClienteNit(cliente).AsEnumerable().First();
                printTicket.DatosCliente = this.DatosCliente;

                printTicket.tDetalle = this.miBussinesFactura.PrintProducto(id, descto).Tables[0];

                if (cliente != "10" && cliente != "1000")
                {
                    printTicket.Puntos = true;
                    printTicket.DataPuntos = new double[] { Convert.ToDouble(printTicket.clienteRow["punto"]) };
                }
                printTicket.Pago = pago;
                printTicket.DetalleIva = this.miBussinesFactura.IvaFacturado(id);
                printTicket.impuesto = this.miBussinesImpuesto.ImpuestoBolsaDeVenta(id);
                //printTicket.dianRow = this.miBussinesDian.DianRow();
                printTicket.DianReg = this.miBussinesDian.ConsultaDian(Convert.ToInt32(facturaRow["id_resolucion_dian"]));
                printTicket.ImprimirVenta();

                /*
                var empresaRow = miBussinesEmpresa.PrintEmpresa().
                                 Tables[0].AsEnumerable().First();
                var facturaRow = miBussinesFactura.PrintFacturaVenta(id).
                                            Tables[0].AsEnumerable().First();
                var usuarioRow = miBussinesUsuario.PrintUsuarioVenta(id).
                                       Tables[0].AsEnumerable().First();
                var clienteRow = miBussinesCliente.PrintCliente(cliente).
                                        Tables[0].AsEnumerable().First();
                var tDetalle = miBussinesFactura.PrintProducto(id, descto).Tables[0];
                var detalleIva = this.miBussinesFactura.IvaFacturado(id);
                var dianRow = this.miBussinesDian.DianRow();
                var impuesto = miBussinesImpuesto.ImpuestoBolsaDeVenta(id);

                var tipoDoc = "";
                var No = "";
                if (idEstado == 1 || idEstado == 2)
                {
                    tipoDoc = "FACTURA DE VENTA";
                    No = facturaRow["Numero"].ToString();
                }
                else
                {
                    if (idEstado == 4)
                    {
                        tipoDoc = "COTIZACIÓN";
                        //No = "";
                        No = facturaRow["Numero"].ToString();
                    }
                }

                Ticket ticket = new Ticket();
                ticket.UseItem = false;
                int maxCharacters = 35;

                foreach (var datos in UseObject.StringBuilderDataCenter(empresaRow["Nombre"].ToString().ToUpper(), maxCharacters))
                {
                    ticket.AddHeaderLine(datos);
                }
                foreach (var datos in UseObject.StringBuilderDataCenter(empresaRow["Juridico"].ToString(), maxCharacters))
                {
                    ticket.AddHeaderLine(datos);
                }
                foreach (var datos in UseObject.StringBuilderDataCenter(
                    "NIT " + UseObject.InsertSeparatorMilMasDigito(empresaRow["Nit"].ToString()), maxCharacters))
                {
                    ticket.AddHeaderLine(datos);
                }
                foreach (var datos in UseObject.StringBuilderDataCenter(empresaRow["Direccion"].ToString(), maxCharacters))
                {
                    ticket.AddHeaderLine(datos);
                }
                foreach (var datos in UseObject.StringBuilderDataCenter(empresaRow["Telefono"].ToString(), maxCharacters))
                {
                    ticket.AddHeaderLine(datos);
                }
                string regimen_ = "";
                if (Convert.ToInt32(empresaRow["idregimen"]).Equals(1))   //  COMÚN
                {
                    ticket.AddHeaderLine("RÉGIMEN " + empresaRow["Regimen"].ToString() + "      " + tipoDoc);
                }
                else     // SIMPLIFICADO
                {
                    regimen_ = empresaRow["Regimen"].ToString().Substring(0, 7);
                    ticket.AddHeaderLine("RÉGIMEN " + regimen_ + "   " + tipoDoc);
                }
                ticket.AddHeaderLine
                    ("Fecha : " + Convert.ToDateTime(facturaRow["Fecha"]).ToShortDateString() + " Nro " + No);
                if (idEstado.Equals(2))  // Credito
                {
                    ticket.AddHeaderLine("CRÉDITO Fecha Limite : " + Convert.ToDateTime(facturaRow["FechaLimite"]).ToShortDateString());
                }
                ticket.AddHeaderLine
                    ("Hora  : " + Convert.ToDateTime(facturaRow["Hora"]).TimeOfDay.Hours + ":" + Convert.ToDateTime(facturaRow["Hora"]).TimeOfDay.Minutes + 
                     "  Cajero: " + usuarioRow["Nombre"].ToString().Substring(0, 12));
                ticket.AddHeaderLine("Caja  : " + facturaRow["Caja"].ToString());

                ticket.AddHeaderLine("-----------------------------------");
                ticket.AddHeaderLine("CLIENTE : " + clienteRow["Nombre"].ToString());
                ticket.AddHeaderLine("NIT     : " + UseObject.InsertSeparatorMilMasDigito(clienteRow["Nit"].ToString()));
                ticket.AddHeaderLine("-----------------------------------");
                ticket.AddHeaderLine("");

                string cant = "";
                string venta = "";
                string total_ = "";
                if (this.GraneroJhonRiosucio)
                {
                    this.PrintDetail(tDetalle, ticket);
                }
                else
                {
                    ticket.AddHeaderLine("DESCRIP.  CANT.    VENTA      TOTAL");
                    ticket.AddHeaderLine("");
                    foreach (DataRow dRow in tDetalle.Rows)
                    {
                        string product = dRow["Producto"].ToString();
                        if (product.Length > 30)
                        {
                            product = product.Substring(0, 30);
                        }
                        ticket.AddHeaderLine(dRow["Codigo"].ToString() + " " + product);
                        cant = UseObject.InsertSeparatorMil(dRow["Cantidad"].ToString());
                        venta = UseObject.InsertSeparatorMil(dRow["Valor_"].ToString());
                        total_ = UseObject.InsertSeparatorMil(dRow["Total_"].ToString());
                        ticket.AddHeaderLine(UseObject.StringBuilderDetalleProducto(cant, venta, total_));
                    }
                }
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("-----------------------------------");
                ticket.AddHeaderLine("");

                var total = tDetalle.AsEnumerable().Sum(d => d.Field<int>("Total_")) + (impuesto.Cantidad * impuesto.Valor);

                total_ = UseObject.InsertSeparatorMil(total.ToString());
                string efectivo = UseObject.InsertSeparatorMil(pago.ToString());
                string cambio = UseObject.InsertSeparatorMil((pago - total).ToString());
                if (idEstado.Equals(2))
                {
                    efectivo = "0";
                    cambio = "0";
                }
                int valorIva = Convert.ToInt32(detalleIva.Sum(s => s.ValorIva));
                ticket.AddHeaderLine("         SUBTOTAL :" + UseObject.StringBuilderDetalleTotal
                                                            (UseObject.InsertSeparatorMil((total - valorIva).ToString())));
                ticket.AddHeaderLine("              IVA :" + UseObject.StringBuilderDetalleTotal
                                                            (UseObject.InsertSeparatorMil(valorIva.ToString())));
                ticket.AddHeaderLine("       TOTAL NETO :" + UseObject.StringBuilderDetalleTotal(total_));
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("         EFECTIVO :" + UseObject.StringBuilderDetalleTotal(efectivo));
                ticket.AddHeaderLine("           CAMBIO :" + UseObject.StringBuilderDetalleTotal(cambio));
                ticket.AddHeaderLine("");

                total_ = "";
                string baseIva_ = "";
                string valorIva_ = "";
                if (Convert.ToInt32(empresaRow["idregimen"]).Equals(1))
                {
                    if (idEstado.Equals(1) || idEstado.Equals(2))
                    {
                        ticket.AddHeaderLine("----------[ DETALLE IVA ]----------");
                        ticket.AddHeaderLine("GRAVADO  COMPRA      BASE      IVA ");
                        foreach (var iva_ in detalleIva)
                        {
                            total_ = UseObject.InsertSeparatorMil(iva_.Total.ToString());
                            baseIva_ = UseObject.InsertSeparatorMil(iva_.BaseI.ToString());
                            valorIva_ = UseObject.InsertSeparatorMil(iva_.ValorIva.ToString());
                            if (total_.Length >= 10)
                            {
                                if (iva_.PorcentajeIva.ToString().Length == 1)
                                {
                                    ticket.AddHeaderLine("  " + iva_.PorcentajeIva + "%");
                                }
                                else
                                {
                                    ticket.AddHeaderLine(" " + iva_.PorcentajeIva + "%");
                                }
                            }
                            ticket.AddHeaderLine(UseObject.StringBuilderDetalleIva(iva_.PorcentajeIva, total_, baseIva_, valorIva_));
                        }
                        ticket.AddHeaderLine("");
                        ticket.AddHeaderLine("-----[ INC. BOLSAS PLÁSTICAS ]-----");
                        ticket.AddHeaderLine("IMP. UNITARIO     CANT.       TOTAL");
                        ticket.AddHeaderLine(UseObject.StringBuilderDetalleINCBP(impuesto.Valor.ToString(), 
                            UseObject.InsertSeparatorMil(impuesto.Cantidad.ToString()),
                            UseObject.InsertSeparatorMil((impuesto.Valor * impuesto.Cantidad).ToString())));
                    }
                }
                ticket.AddHeaderLine("-----------------------------------");
                ticket.AddHeaderLine("");
                if (Convert.ToInt32(empresaRow["idregimen"]).Equals(1))
                {
                    if (idEstado.Equals(1) || idEstado.Equals(2))
                    {
                        foreach (var stringDian in UseObject.StringBuilderDetalleDIAN
                            (dianRow["TxtInicial"].ToString() + dianRow["Resolucion"].ToString(), maxCharacters))
                        {
                            ticket.AddHeaderLine(stringDian);
                        }
                        ticket.AddHeaderLine("de " + Convert.ToDateTime(dianRow["Fecha"]).ToShortDateString());
                        foreach (var stringDian in UseObject.StringBuilderDetalleDIAN
                            (dianRow["TxtFinal"].ToString() + " del " + dianRow["Desde"].ToString() + " al " + dianRow["Hasta"].ToString() + ".", maxCharacters))
                        {
                            ticket.AddHeaderLine(stringDian);
                        }
                    }
                }
                ticket.AddHeaderLine("-----------------------------------");
                ticket.AddHeaderLine("SOFTWARE  DFPYME");
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("*GRACIAS POR SER NUESTROS CLIENTES*");
                ticket.AddHeaderLine("");

                //ticket.PrintTicket("IMPREPOS");
                ticket.PrintTicket("Microsoft XPS Document Writer");
                */
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void PrintPosTriunfo
            (int id, string numero, bool descto, string cliente, bool contado, int idEstado, int pago)
        {
            try
            {
                var facturaRow = miBussinesFactura.PrintFacturaVenta(id).Tables[0].AsEnumerable().First();

                PrintTicket printTicket = new PrintTicket();
                printTicket.UseItem = false;
                printTicket.Detail = this.GraneroJhonRiosucio;
                printTicket.EsFactura = true;
                printTicket.Copia = true;

                printTicket.empresaRow = this.miBussinesEmpresa.PrintEmpresa().Tables[0].AsEnumerable().First();

                printTicket.IdEstado = idEstado;
                printTicket.Numero = numero;
                printTicket.Fecha = Convert.ToDateTime(facturaRow["Fecha"]);
                printTicket.Hora = Convert.ToDateTime(facturaRow["Hora"]);
                printTicket.Limite = Convert.ToDateTime(facturaRow["FechaLimite"]);

                printTicket.Usuario = this.miBussinesUsuario.PrintUsuarioVenta(id).Tables[0].AsEnumerable().First()["Nombre"].ToString();

                printTicket.NoCaja = facturaRow["Caja"].ToString();
                printTicket.clienteRow = this.miBussinesCliente.ConsultaClienteNit(cliente).AsEnumerable().First();

                //
                printTicket.SubTotal = UseObject.RemoveSeparatorMil(txtSubTotal.Text).ToString();
                printTicket.Total_ = UseObject.RemoveSeparatorMil(txtTotal.Text).ToString();
                //

                printTicket.tDetalle = this.miBussinesFactura.PrintProducto(id, descto).Tables[0];

                if (cliente != "10" && cliente != "1000")
                {
                    printTicket.Puntos = true;
                    printTicket.DataPuntos = new double[] { Convert.ToDouble(printTicket.clienteRow["punto"]) };
                }
                printTicket.Pago = pago;
                printTicket.DetalleIva = this.miBussinesFactura.IvaFacturado(id);
                printTicket.impuesto = this.miBussinesImpuesto.ImpuestoBolsaDeVenta(id);
                //printTicket.dianRow = this.miBussinesDian.DianRow();
                printTicket.DianReg = this.miBussinesDian.ConsultaDian(Convert.ToInt32(facturaRow["id_resolucion_dian"]));
                printTicket.ImprimirVenta();

                /*
                var empresaRow = miBussinesEmpresa.PrintEmpresa().
                                 Tables[0].AsEnumerable().First();
                var facturaRow = miBussinesFactura.PrintFacturaVenta(id).
                                            Tables[0].AsEnumerable().First();
                var usuarioRow = miBussinesUsuario.PrintUsuarioVenta(id).
                                       Tables[0].AsEnumerable().First();
                var clienteRow = miBussinesCliente.PrintCliente(cliente).
                                        Tables[0].AsEnumerable().First();
                var tDetalle = miBussinesFactura.PrintProducto(id, descto).Tables[0];
                var detalleIva = this.miBussinesFactura.IvaFacturado(id);
                var dianRow = this.miBussinesDian.DianRow();
                var impuesto = miBussinesImpuesto.ImpuestoBolsaDeVenta(id);

                var tipoDoc = "";
                var No = "";
                if (idEstado == 1 || idEstado == 2)
                {
                    tipoDoc = "FACTURA DE VENTA";
                    No = facturaRow["Numero"].ToString();
                }
                else
                {
                    if (idEstado == 4)
                    {
                        tipoDoc = "COTIZACIÓN";
                        //No = "";
                        No = facturaRow["Numero"].ToString();
                    }
                }

                Ticket ticket = new Ticket();
                ticket.UseItem = false;
                int maxCharacters = 35;

                foreach (var datos in UseObject.StringBuilderDataCenter(empresaRow["Nombre"].ToString().ToUpper(), maxCharacters))
                {
                    ticket.AddHeaderLine(datos);
                }
                foreach (var datos in UseObject.StringBuilderDataCenter(empresaRow["Juridico"].ToString(), maxCharacters))
                {
                    ticket.AddHeaderLine(datos);
                }
                foreach (var datos in UseObject.StringBuilderDataCenter(
                    "NIT " + UseObject.InsertSeparatorMilMasDigito(empresaRow["Nit"].ToString()), maxCharacters))
                {
                    ticket.AddHeaderLine(datos);
                }
                foreach (var datos in UseObject.StringBuilderDataCenter(empresaRow["Direccion"].ToString(), maxCharacters))
                {
                    ticket.AddHeaderLine(datos);
                }
                foreach (var datos in UseObject.StringBuilderDataCenter(empresaRow["Telefono"].ToString(), maxCharacters))
                {
                    ticket.AddHeaderLine(datos);
                }
                string regimen_ = "";
                if (Convert.ToInt32(empresaRow["idregimen"]).Equals(1))   //  COMÚN
                {
                    ticket.AddHeaderLine("RÉGIMEN " + empresaRow["Regimen"].ToString() + "      " + tipoDoc);
                }
                else     // SIMPLIFICADO
                {
                    regimen_ = empresaRow["Regimen"].ToString().Substring(0, 7);
                    ticket.AddHeaderLine("RÉGIMEN " + regimen_ + "   " + tipoDoc);
                }
                ticket.AddHeaderLine
                    ("Fecha : " + Convert.ToDateTime(facturaRow["Fecha"]).ToShortDateString() + " Nro " + No);
                if (idEstado.Equals(2))  // Credito
                {
                    ticket.AddHeaderLine("CRÉDITO Fecha Limite : " + Convert.ToDateTime(facturaRow["FechaLimite"]).ToShortDateString());
                }
                ticket.AddHeaderLine
                    ("Hora  : " + Convert.ToDateTime(facturaRow["Hora"]).TimeOfDay.Hours + ":" + Convert.ToDateTime(facturaRow["Hora"]).TimeOfDay.Minutes + 
                     "  Cajero: " + usuarioRow["Nombre"].ToString().Substring(0, 12));
                ticket.AddHeaderLine("Caja  : " + facturaRow["Caja"].ToString());

                ticket.AddHeaderLine("-----------------------------------");
                ticket.AddHeaderLine("CLIENTE : " + clienteRow["Nombre"].ToString());
                ticket.AddHeaderLine("NIT     : " + UseObject.InsertSeparatorMilMasDigito(clienteRow["Nit"].ToString()));
                ticket.AddHeaderLine("-----------------------------------");
                ticket.AddHeaderLine("");

                string cant = "";
                string venta = "";
                string total_ = "";
                if (this.GraneroJhonRiosucio)
                {
                    this.PrintDetail(tDetalle, ticket);
                }
                else
                {
                    ticket.AddHeaderLine("DESCRIP.  CANT.    VENTA      TOTAL");
                    ticket.AddHeaderLine("");
                    foreach (DataRow dRow in tDetalle.Rows)
                    {
                        string product = dRow["Producto"].ToString();
                        if (product.Length > 30)
                        {
                            product = product.Substring(0, 30);
                        }
                        ticket.AddHeaderLine(dRow["Codigo"].ToString() + " " + product);
                        cant = UseObject.InsertSeparatorMil(dRow["Cantidad"].ToString());
                        venta = UseObject.InsertSeparatorMil(dRow["Valor_"].ToString());
                        total_ = UseObject.InsertSeparatorMil(dRow["Total_"].ToString());
                        ticket.AddHeaderLine(UseObject.StringBuilderDetalleProducto(cant, venta, total_));
                    }
                }
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("-----------------------------------");
                ticket.AddHeaderLine("");

                var total = tDetalle.AsEnumerable().Sum(d => d.Field<int>("Total_")) + (impuesto.Cantidad * impuesto.Valor);

                total_ = UseObject.InsertSeparatorMil(total.ToString());
                string efectivo = UseObject.InsertSeparatorMil(pago.ToString());
                string cambio = UseObject.InsertSeparatorMil((pago - total).ToString());
                if (idEstado.Equals(2))
                {
                    efectivo = "0";
                    cambio = "0";
                }
                int valorIva = Convert.ToInt32(detalleIva.Sum(s => s.ValorIva));
                ticket.AddHeaderLine("         SUBTOTAL :" + UseObject.StringBuilderDetalleTotal
                                                            (UseObject.InsertSeparatorMil((total - valorIva).ToString())));
                ticket.AddHeaderLine("              IVA :" + UseObject.StringBuilderDetalleTotal
                                                            (UseObject.InsertSeparatorMil(valorIva.ToString())));
                ticket.AddHeaderLine("       TOTAL NETO :" + UseObject.StringBuilderDetalleTotal(total_));
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("         EFECTIVO :" + UseObject.StringBuilderDetalleTotal(efectivo));
                ticket.AddHeaderLine("           CAMBIO :" + UseObject.StringBuilderDetalleTotal(cambio));
                ticket.AddHeaderLine("");

                total_ = "";
                string baseIva_ = "";
                string valorIva_ = "";
                if (Convert.ToInt32(empresaRow["idregimen"]).Equals(1))
                {
                    if (idEstado.Equals(1) || idEstado.Equals(2))
                    {
                        ticket.AddHeaderLine("----------[ DETALLE IVA ]----------");
                        ticket.AddHeaderLine("GRAVADO  COMPRA      BASE      IVA ");
                        foreach (var iva_ in detalleIva)
                        {
                            total_ = UseObject.InsertSeparatorMil(iva_.Total.ToString());
                            baseIva_ = UseObject.InsertSeparatorMil(iva_.BaseI.ToString());
                            valorIva_ = UseObject.InsertSeparatorMil(iva_.ValorIva.ToString());
                            if (total_.Length >= 10)
                            {
                                if (iva_.PorcentajeIva.ToString().Length == 1)
                                {
                                    ticket.AddHeaderLine("  " + iva_.PorcentajeIva + "%");
                                }
                                else
                                {
                                    ticket.AddHeaderLine(" " + iva_.PorcentajeIva + "%");
                                }
                            }
                            ticket.AddHeaderLine(UseObject.StringBuilderDetalleIva(iva_.PorcentajeIva, total_, baseIva_, valorIva_));
                        }
                        ticket.AddHeaderLine("");
                        ticket.AddHeaderLine("-----[ INC. BOLSAS PLÁSTICAS ]-----");
                        ticket.AddHeaderLine("IMP. UNITARIO     CANT.       TOTAL");
                        ticket.AddHeaderLine(UseObject.StringBuilderDetalleINCBP(impuesto.Valor.ToString(), 
                            UseObject.InsertSeparatorMil(impuesto.Cantidad.ToString()),
                            UseObject.InsertSeparatorMil((impuesto.Valor * impuesto.Cantidad).ToString())));
                    }
                }
                ticket.AddHeaderLine("-----------------------------------");
                ticket.AddHeaderLine("");
                if (Convert.ToInt32(empresaRow["idregimen"]).Equals(1))
                {
                    if (idEstado.Equals(1) || idEstado.Equals(2))
                    {
                        foreach (var stringDian in UseObject.StringBuilderDetalleDIAN
                            (dianRow["TxtInicial"].ToString() + dianRow["Resolucion"].ToString(), maxCharacters))
                        {
                            ticket.AddHeaderLine(stringDian);
                        }
                        ticket.AddHeaderLine("de " + Convert.ToDateTime(dianRow["Fecha"]).ToShortDateString());
                        foreach (var stringDian in UseObject.StringBuilderDetalleDIAN
                            (dianRow["TxtFinal"].ToString() + " del " + dianRow["Desde"].ToString() + " al " + dianRow["Hasta"].ToString() + ".", maxCharacters))
                        {
                            ticket.AddHeaderLine(stringDian);
                        }
                    }
                }
                ticket.AddHeaderLine("-----------------------------------");
                ticket.AddHeaderLine("SOFTWARE  DFPYME");
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("*GRACIAS POR SER NUESTROS CLIENTES*");
                ticket.AddHeaderLine("");

                //ticket.PrintTicket("IMPREPOS");
                ticket.PrintTicket("Microsoft XPS Document Writer");
                */
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void PrintPos50mm
            (int id, string numero, bool descto, string cliente, bool contado, int idEstado, int pago)
        {
            try
            {
                int maxCharacters = 27;

                var empresaRow = this.miBussinesEmpresa.PrintEmpresa().Tables[0].AsEnumerable().First();
                var facturaRow = miBussinesFactura.PrintFacturaVenta(id).Tables[0].AsEnumerable().First();
                var tProductos = this.miBussinesFactura.PrintProducto(id, descto).Tables[0];
                DataRow rowCliente = this.miBussinesCliente.ConsultaClienteNit(cliente).AsEnumerable().First();
                //printTicket.clienteRow = this.miBussinesCliente.ConsultaClienteNit(cliente).AsEnumerable().First();


                Ticket miTicket = new Ticket();
                miTicket.UseItem = false;
                miTicket.Printer80mm = false;

                miTicket.AddHeaderLine(empresaRow["Nombre"].ToString().ToUpper());
                miTicket.AddHeaderLine(empresaRow["Juridico"].ToString().ToUpper());
                miTicket.AddHeaderLine(empresaRow["Nit"].ToString().ToUpper());
                miTicket.AddHeaderLine(empresaRow["direccion_"].ToString().ToUpper());
                miTicket.AddHeaderLine(empresaRow["ciudad"].ToString().ToUpper() + " " +
                    empresaRow["departamento"].ToString().ToUpper());
                miTicket.AddHeaderLine(empresaRow["celularempresa"].ToString().ToUpper());
                miTicket.AddHeaderLine("---------------------------");
                miTicket.AddHeaderLine("Ticket Venta No. " + facturaRow["Numero"].ToString());
                DateTime hora = Convert.ToDateTime(facturaRow["Hora"]);
                miTicket.AddHeaderLine("Fecha: " + Convert.ToDateTime(facturaRow["Fecha"]).ToShortDateString() + " " +
                    hora.TimeOfDay.Hours + ":" + hora.TimeOfDay.Minutes.ToString());
                if (idEstado.Equals(2))  // Credito
                {
                    miTicket.AddHeaderLine("CRÉDITO");
                }
                miTicket.AddHeaderLine("---------------------------");
                miTicket.AddHeaderLine(rowCliente["nombrescliente"].ToString());
                miTicket.AddHeaderLine(rowCliente["nitcliente"].ToString());
                miTicket.AddHeaderLine("---------------------------");
                miTicket.AddHeaderLine("ARTICULO CANT. V UND. TOTAL");
                miTicket.AddHeaderLine("---------------------------");
                string product = "", cant = "", venta = "", total = "";
                foreach (DataRow pRow in tProductos.Rows)
                {
                    product = pRow["Producto"].ToString();
                    if (product.Length > maxCharacters)
                    {
                        product = product.Substring(0, maxCharacters);
                    }
                    miTicket.AddHeaderLine(product);

                    cant = UseObject.InsertSeparatorMil(pRow["Cantidad"].ToString());
                    venta = UseObject.InsertSeparatorMil(pRow["Valor_"].ToString());
                    total = UseObject.InsertSeparatorMil(pRow["Total_"].ToString());

                    miTicket.AddHeaderLine(UseObject.FuncionEspacio(7 - cant.Length) + cant +
                        UseObject.FuncionEspacio(10 - venta.Length) + venta +
                        UseObject.FuncionEspacio(10 - total.Length) + total);
                }
                miTicket.AddHeaderLine("");
                miTicket.AddHeaderLine("");
                miTicket.AddHeaderLine("---------------------------");
                miTicket.AddHeaderLine("TOTAL: $          " + UseObject.InsertSeparatorMil(tProductos.AsEnumerable().Sum(s => s.Field<int>("Total_")).ToString()));
                miTicket.AddHeaderLine("---------------------------");
                if (idEstado.Equals(1))  // Contado
                {
                    miTicket.AddHeaderLine("Efectivo: $       " + UseObject.InsertSeparatorMil(pago.ToString()));
                    miTicket.AddHeaderLine("Cambio  : $       " + UseObject.InsertSeparatorMil((pago - tProductos.AsEnumerable().Sum(s => s.Field<int>("Total_"))).ToString()));
                }
                miTicket.AddHeaderLine("");
                miTicket.AddHeaderLine("Atendido por: " + this.miBussinesUsuario.PrintUsuarioVenta(id).Tables[0].AsEnumerable().First()["Nombre"].ToString().Substring(0, 13));
                miTicket.AddHeaderLine("");

                miTicket.PrintTicket("");





                /*
                var facturaRow = miBussinesFactura.PrintFacturaVenta(id).Tables[0].AsEnumerable().First();

                PrintTicket printTicket = new PrintTicket();
                printTicket.UseItem = false;
                printTicket.Detail = this.GraneroJhonRiosucio;
                printTicket.EsFactura = true;
                printTicket.Copia = true;

                printTicket.empresaRow = this.miBussinesEmpresa.PrintEmpresa().Tables[0].AsEnumerable().First();

                printTicket.IdEstado = idEstado;
                printTicket.Numero = numero;
                printTicket.Fecha = Convert.ToDateTime(facturaRow["Fecha"]);
                printTicket.Hora = Convert.ToDateTime(facturaRow["Hora"]);
                printTicket.Limite = Convert.ToDateTime(facturaRow["FechaLimite"]);

                printTicket.Usuario = this.miBussinesUsuario.PrintUsuarioVenta(id).Tables[0].AsEnumerable().First()["Nombre"].ToString();

                printTicket.NoCaja = facturaRow["Caja"].ToString();
                printTicket.clienteRow = this.miBussinesCliente.ConsultaClienteNit(cliente).AsEnumerable().First();

                printTicket.tDetalle = this.miBussinesFactura.PrintProducto(id, descto).Tables[0];

                if (cliente != "10" && cliente != "1000")
                {
                    printTicket.Puntos = true;
                    printTicket.DataPuntos = new double[] { Convert.ToDouble(printTicket.clienteRow["punto"]) };
                }
                printTicket.Pago = pago;
                printTicket.DetalleIva = this.miBussinesFactura.IvaFacturado(id);
                printTicket.impuesto = this.miBussinesImpuesto.ImpuestoBolsaDeVenta(id);
                //printTicket.dianRow = this.miBussinesDian.DianRow();
                printTicket.DianReg = this.miBussinesDian.ConsultaDian(Convert.ToInt32(facturaRow["id_resolucion_dian"]));
                printTicket.ImprimirVenta();*/

            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void PrintDetail(DataTable tDetalle, Ticket ticket)
        {
            ticket.AddHeaderLine("CANT  DESCRIPCION             TOTAL");
            ticket.AddHeaderLine("");
            foreach (DataRow dRow in tDetalle.Rows)
            {
                string product = dRow["Producto"].ToString();
                string product_2 = "";
                if (product.Length > 19)
                {
                    product = product.Substring(0, 19);
                    product_2 = dRow["Producto"].ToString().Substring(19);
                }
                var space_cant = "";
                switch (dRow["Cantidad"].ToString().Length)
                {
                    case 1:
                        {
                            space_cant = "     ";
                            break;
                        }
                    case 2:
                        {
                            space_cant = "    ";
                            break;
                        }
                    case 3:
                        {
                            space_cant = "   ";
                            break;
                        }
                    case 4:
                        {
                            space_cant = "  ";
                            break;
                        }
                    case 5:
                        {
                            space_cant = " ";
                            break;
                        }
                }
                var space_total = "";
                switch (UseObject.InsertSeparatorMil(dRow["Total_"].ToString()).Length)
                {
                    case 3:
                        {
                            space_total = "      ";
                            break;
                        }
                    case 5:
                        {
                            space_total = "    ";
                            break;
                        }
                    case 6:
                        {
                            space_total = "   ";
                            break;
                        }
                    case 7:
                        {
                            space_total = "  ";
                            break;
                        }
                    case 9:
                        {
                            space_total = " ";
                            break;
                        }
                }
                ticket.AddHeaderLine("      COD:" + dRow["Codigo"].ToString() + " v/u " + UseObject.InsertSeparatorMil(dRow["Valor_"].ToString()));
                var line = "      COD:" + dRow["Codigo"].ToString() + " v/u " + UseObject.InsertSeparatorMil(dRow["Valor_"].ToString());
                if (UseObject.InsertSeparatorMil(dRow["Total_"].ToString()).Length > 9 && product_2.Length > 18)
                {
                    product_2 = product_2.Substring(0, 16);
                    var space_3 = "";
                    for (int i = (product_2.Length + UseObject.InsertSeparatorMil(dRow["Total_"].ToString()).Length); i < 29; i++)
                    {
                        space_3 += " ";
                    }

                    ticket.AddHeaderLine(dRow["Cantidad"].ToString() + space_cant + product);
                    line = dRow["Cantidad"].ToString() + space_cant + product;
                    ticket.AddHeaderLine("      " + product_2 + space_3 + UseObject.InsertSeparatorMil(dRow["Total_"].ToString()));
                    line = "      " + product_2 + space_3 + UseObject.InsertSeparatorMil(dRow["Total_"].ToString());
                }
                else
                {
                    ticket.AddHeaderLine(dRow["Cantidad"].ToString() + space_cant + product + space_total +
                        UseObject.InsertSeparatorMil(dRow["Total_"].ToString()));
                    line = dRow["Cantidad"].ToString() + space_cant + product + space_total +
                        UseObject.InsertSeparatorMil(dRow["Total_"].ToString());
                    if (product_2 != "")
                    {
                        ticket.AddHeaderLine("      " + product_2);
                        line = "      " + product_2;
                    }
                }
                ticket.AddHeaderLine("");
            }
        }

        /*private List<Iva> DetalleIva()
        {
            List<Iva> detallesIva = new List<Iva>();
            foreach(DataGridViewRow gRow in this.dgvListaArticulos.Rows)
            {
                detallesIva.Add(new Iva
                {
                    PorcentajeIva = UseObject.RemoveCharacter(gRow.Cells["Iva"].Value.ToString(), '%'),
                    Total = Convert.ToInt32(gRow.Cells["Total"].Value)
                });
            }
            var query = from data in detallesIva
                        group data by new
                        {
                            PorcentajeIva = data.PorcentajeIva,
                        }
                            into grupo
                            orderby grupo.Key.PorcentajeIva ascending
                            select new
                            {
                                PorcentajeIva = grupo.Key.PorcentajeIva,
                                Total = grupo.Sum(s => s.Total)
                            };
            List<Iva> detallesIva_ = new List<Iva>();
            foreach (var iva_ in query)
            {
                detallesIva_.Add(new Iva
                {
                    PorcentajeIva = iva_.PorcentajeIva,
                    Total = iva_.Total,
                    BaseI = Convert.ToInt32(iva_.Total / ((iva_.PorcentajeIva / 100) + 1)),
                    ValorIva = iva_.Total - Convert.ToInt32(iva_.Total / ((iva_.PorcentajeIva / 100) + 1))
                });
            }
            return detallesIva_;
        }*/

        bool AbonoGeneral = false;
        private void ImprimirComprobante(List<FormaPago> pagos)
        {
            DialogResult rta = MessageBox.Show("¿Desea imprimir el comprobante de ingreso?", "Abono a Factura",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rta.Equals(DialogResult.Yes))
            {
                try
                {
                    var cliente = miBussinesCliente.ClienteAEditar
                        (dgvFactura.CurrentRow.Cells["Nit"].Value.ToString());
                    var printComprobante = new Cliente.FrmPrintAnticipo();

                    printComprobante.Fecha = DateTime.Now;
                    printComprobante.Cliente = cliente.NombresCliente;
                    printComprobante.Nit = cliente.NitCliente;
                    printComprobante.Direccion =
                        cliente.DireccionCliente + "  " + cliente.Ciudad + "  " + cliente.Departamento;
                    printComprobante.Valor = pagos.Sum(p => p.Valor).ToString();
                    //printComprobante.DsFormas = miBussinesFormaPago.ListFormas(pagos);
                    var efectivo = 0;
                    foreach (FormaPago pago in pagos)
                    {
                        if (pago.IdFormaPago == 1 || pago.IdFormaPago == 3)
                        {
                            efectivo += Convert.ToInt32(pago.Valor);
                        }
                    }
                    printComprobante.Efectivo = efectivo.ToString();
                    printComprobante.Cheque = pagos.Where(p => p.IdFormaPago == 2).Sum(s => s.Valor).ToString();///Single().Valor.ToString();
                    printComprobante.Numero = miBussinesConsecutivo.Consecutivo("Ingreso");// AppConfiguracion.ValorSeccion("ingreso");
                    if (!AbonoGeneral)
                    {
                        printComprobante.Concepto = "Abono a Factura Número: " +
                                                    dgvFactura.CurrentRow.Cells["Numero"].Value.ToString();
                    }
                    else
                    {
                        printComprobante.Concepto = pagos.Where(p => p.IdFormaPago == 1).First().NombreFormaPago;
                    }
                    printComprobante.MdiParent = this.MdiParent;
                    printComprobante.Show();
                    //miBussinesConsecutivo.ActualizarConsecutivo("Ingreso");
                    /* if (Convert.ToInt32(printComprobante.Numero) < 99)
                     {
                         AppConfiguracion.SaveConfiguration
                             ("ingreso", IncrementaConsecutivo(printComprobante.Numero));
                     }
                     else
                     {
                         AppConfiguracion.SaveConfiguration
                             ("ingreso", (Convert.ToInt32(printComprobante.Numero) + 1).ToString());
                     }*/
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void PrintIngresoPos(string numero)
        {
            try
            {
                var miBussinesIngreso = new BussinesIngreso();

                var empresaRow = miBussinesEmpresa.PrintEmpresa().
                                 Tables[0].AsEnumerable().First();
                var ingresoRow = miBussinesIngreso.Ingresos(numero).AsEnumerable().First();

                var tIngresos = miBussinesIngreso.IngresosMultiple(numero);
                var tPagos = miBussinesIngreso.PagosIngreso(Convert.ToInt32(ingresoRow["tipo"]), tIngresos.Rows);
                var query = from item in tPagos.AsEnumerable()
                            group item by item["NoCaja"].ToString()
                                into g
                                select g;
                var noCaja = "";
                if (query.ToArray().Length != 0)
                {
                    noCaja = query.First().Key;
                }
                var usuario = "";
                var queryUser = from item in tPagos.AsEnumerable()
                                group item by item["IdUser"].ToString()
                                    into g
                                    select g;
                if (queryUser.ToArray().Length != 0)
                {
                    usuario = queryUser.First().Key;
                }
                usuario = miBussinesUsuario.ConsultaUsuario(Convert.ToInt32(usuario)).
                                            AsEnumerable().First()["nombre"].ToString();
                var queryFactura = from item in tPagos.AsEnumerable()
                                   group item by item["NoFactura"].ToString()
                                       into g
                                       select g;
                DataRow clienteRow = null;
                if (queryFactura.ToArray().Length != 0)
                {
                    clienteRow = miBussinesFactura.ClienteDeFacutura(queryFactura.First().Key).AsEnumerable().First();
                }

                Ticket ticket = new Ticket();

                ticket.AddHeaderLine(empresaRow["Nombre"].ToString().ToUpper());
                ticket.AddHeaderLine(empresaRow["Juridico"].ToString());
                ticket.AddHeaderLine("NIT " + UseObject.InsertSeparatorMilMasDigito(empresaRow["Nit"].ToString()));
                ticket.AddHeaderLine(empresaRow["Direccion"].ToString());
                ticket.AddHeaderLine("Tels. " + empresaRow["Telefono"].ToString());
                ticket.AddHeaderLine("Fecha : " + Convert.ToDateTime(ingresoRow["fecha"]).ToShortDateString() +
                                     "    Caja : " + noCaja);
                ticket.AddHeaderLine("Cajero(a)  :  " + usuario);
                ticket.AddHeaderLine("===================================");
                ticket.AddHeaderLine("COMPROBANTE DE INGRESO Nro " + numero);
                ticket.AddHeaderLine("===================================");
                ticket.AddHeaderLine("Recibido de : " + clienteRow["nombrescliente"].ToString().ToUpper());
                ticket.AddHeaderLine("NIT o C.C.  : " + UseObject.InsertSeparatorMilMasDigito(clienteRow["nitcliente"].ToString()));
                ticket.AddHeaderLine("===================================");
                ticket.AddItem("",
                               ingresoRow["concepto"].ToString(),
                               UseObject.InsertSeparatorMil(ingresoRow["valor"].ToString()));

                ticket.AddTotal("TOTAL ", UseObject.InsertSeparatorMil(ingresoRow["valor"].ToString()));

                ticket.AddTotal(" ", " ");
                IEnumerable<IGrouping<string, DataRow>> queryPago = from item in tPagos.AsEnumerable()
                                                                    group item by item["FormaPago"].ToString()
                                                                        into g
                                                                        select g;
                var tPagosGroup = PagosGroup(queryPago);
                foreach (DataRow pRow in tPagosGroup.Rows)
                {
                    ticket.AddTotal(pRow["FormaPago"].ToString(),
                                    UseObject.InsertSeparatorMil(pRow["Valor"].ToString()));
                    var t = pRow["FormaPago"].ToString() + " " +
                                    UseObject.InsertSeparatorMil(pRow["Valor"].ToString());
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
                ticket.AddFooterLine(".");

                // miBussinesConsecutivo.ActualizarConsecutivo("Ingreso");

                /*  if (Convert.ToInt32(numero) < 99)
                  {
                      AppConfiguracion.SaveConfiguration
                          ("ingreso", IncrementaConsecutivo(numero));
                  }
                  else
                  {
                      AppConfiguracion.SaveConfiguration
                          ("ingreso", (Convert.ToInt32(numero) + 1).ToString());
                  }*/

                ticket.PrintTicket("IMPREPOS");
            }
            catch (Exception ex)
            {
                OptionPane.MessageError("Ocurrió un error al imprimir el comprobante.\n" + ex.Message);
            }
        }

        private void tsBtnSeleccionar_Click(object sender, EventArgs e)
        {
            this.dgvFactura_CellDoubleClick
                (this.dgvFactura, new DataGridViewCellEventArgs
                                  (dgvFactura.CurrentCell.ColumnIndex, dgvFactura.CurrentCell.RowIndex));
        }

        private void dgvFactura_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvFactura.Rows.Count != 0)
            {
                if (Extend)
                {
                    CompletaEventos.CapturaEventom
                        (Convert.ToString(dgvFactura.CurrentRow.Cells["Numero"].Value));
                    this.Close();
                }
            }
            else
            {
                OptionPane.MessageInformation("No hay registros para seleccionar.");
            }
        }

        private void FrmConsulta_FormClosing(object sender, FormClosingEventArgs e)
        {
            CompletaEventos.CapturaEventom(false);
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

        private DataTable PagosGroup(IEnumerable<IGrouping<string, DataRow>> dataRows)
        {
            var tabla = new DataTable();
            tabla.Columns.Add(new DataColumn("FormaPago", typeof(string)));
            tabla.Columns.Add(new DataColumn("Valor", typeof(int)));
            foreach (IGrouping<string, DataRow> item in dataRows)
            {
                DataRow r = tabla.NewRow();
                r["FormaPago"] = item.Key;
                r["Valor"] = item.Sum<DataRow>(d => Convert.ToInt32(d["Valor"]));
                tabla.Rows.Add(r);
            }
            return tabla;
        }

        private void btnCambio_Click(object sender, EventArgs e)
        {
            try
            {
                string rta = CustomControl.OptionPane.OptionBox
                        ("Ingresar clave .", "Clave", CustomControl.OptionPane.Icon.LoginAdmin);
                if (rta.Equals("2014"))
                {
                    var facturas = miBussinesFactura.ConsultaEstadoPeriodoIngreso(1, dtpFecha1.Value, dtpFecha2.Value);
                    string p = "";
                    foreach (DataRow fRow in facturas.Rows)
                    {
                        var tPagos = miBussinesFormaPago.FormasDePagoDeFacturaVenta(fRow["numero"].ToString());
                        if (tPagos.Rows.Count > 1)
                        {
                            p += fRow["numero"].ToString() + "\n";
                        }
                    }
                    MessageBox.Show(p);
                    /*var facturas = miBussinesFactura.ConsultaEstadoPeriodoIngreso(1, dtpFecha1.Value, dtpFecha2.Value);
                    foreach (DataRow fRow in facturas.Rows)
                    {
                        var pagos = miBussinesFormaPago.FormasDePagoDeFacturaVenta(fRow["numero"].ToString());
                        if (pagos.Rows.Count.Equals(0))
                        {
                            var productos =
                                miBussinesFactura.ProductoFacturaVenta(fRow["numero"].ToString(), Convert.ToBoolean(fRow["descto"]));
                            FormaPago pago = new FormaPago();
                            pago.NumeroFactura = fRow["numero"].ToString();
                            pago.IdFormaPago = 1;
                            pago.Usuario.Id = 6;
                            pago.Caja.Id = 1;
                            var fecha = Convert.ToDateTime(fRow["fecha"]);
                            pago.Fecha =
                                new DateTime(fecha.Year, fecha.Month, fecha.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                            pago.Valor = Convert.ToInt32(productos.AsEnumerable().Sum(t => t.Field<double>("Valor")));
                            miBussinesFormaPago.IngresarPagoAFactura(pago, true, Convert.ToBoolean(AppConfiguracion.ValorSeccion("printIngreso")));
                        }
                    }*/
                    //OptionPane.MessageInformation("Los datos se actualizarón correctamente.");
                }
                else
                {
                    if (rta.Equals("20142"))
                    {
                        int cont = 0;
                        var facturas = miBussinesFactura.ConsultaEstadoPeriodoIngreso(1, dtpFecha1.Value, dtpFecha2.Value);
                        foreach (DataRow fRow in facturas.Rows)
                        {
                            var tPagos = miBussinesFormaPago.FormasDePagoDeFacturaVenta(fRow["numero"].ToString());
                            if (tPagos.Rows.Count.Equals(1))
                            {
                                var id = Convert.ToInt32(tPagos.AsEnumerable().First()["Id"]);
                                var productos =
                                miBussinesFactura.ProductoFacturaVenta(fRow["numero"].ToString(), Convert.ToBoolean(fRow["descto"]));
                                var valor = Convert.ToInt32(productos.AsEnumerable().Sum(t => t.Field<double>("Valor")));
                                miBussinesFormaPago.EditarValores(id, valor, valor);
                                cont++;
                            }
                        }
                        MessageBox.Show("Los datos se ajustaron correctamente.\nSe ajustarón " + cont + " registros.", "Consulta de ventas.",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }
    }
}