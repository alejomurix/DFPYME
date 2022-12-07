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

namespace Aplicacion.Ventas.Remisiones
{
    public partial class FrmConsulta : Form
    {
        /// <summary>
        /// Objeto que encapsula la lógica de negocio de Factura Venta.
        /// </summary>
        private BussinesFacturaVenta miBussinesFactura;

        private BussinesRemision miBussinesRemision;

        private BussinesDevolucion miBussinesDevolucion;

        private BussinesFormaPago miBussinesFormaPago;

        private BussinesCliente miBussinesCliente;

        private BussinesConsecutivo miBussinesConsecutivo;

        private BussinesUsuario miBussinesUsuario;

        private bool Tranfer { set; get; }

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

        private bool ExtendForms = false;

        public Usuario Usuario_ { set; get; }

        private const int IdPermisoFacturarRemision = 63;

        private bool PermisoFacturarRemision;

        private const int IdPermisoAnularRemision = 65;

        private bool PermisoAnularRemision;

        public FrmConsulta()
        {
            InitializeComponent();
            miBussinesFactura = new BussinesFacturaVenta();
            miBussinesFormaPago = new BussinesFormaPago();
            miBussinesRemision = new BussinesRemision();
            miBussinesDevolucion = new BussinesDevolucion();
            miBussinesCliente = new BussinesCliente();
            miBussinesConsecutivo = new BussinesConsecutivo();
            miBussinesUsuario = new BussinesUsuario();
            this.GraneroJhonRiosucio = Convert.ToBoolean(AppConfiguracion.ValorSeccion("graneroJhonRiosucio"));
            RowMaxFactura = 5;
        }

        private void FrmConsulta_Load(object sender, EventArgs e)
        {
            CompletaEventos.Completa += new CompletaEventos.CompletaAccion(CompletaEventos_Completo);
            CompletaEventos.Completaz += new CompletaEventos.CompletaAccionz(CompletaEventos_Completaz);
            CompletaEventos.ComAbonoRemision += new CompletaEventos.ComAxAbonoRemision(CompletaEventos_ComAbonoRemision);
            CompletaEventos.Completaeb += new CompletaEventos.CompletaAccioneb(CompletaEventos_Completaeb);
            CargarUtilidades();
            //CargarCriterioGeneral();
            //CargarPrimerCriterio();
            //CargarSegundoCriterio();
           // CargarTercerCriterio();

            this.PermisoFacturarRemision = false;
            this.PermisoAnularRemision = false;
            foreach (var ps in Usuario_.Permisos)
            {
                switch (ps.IdPermiso)
                {
                    case IdPermisoFacturarRemision:
                        {
                            this.PermisoFacturarRemision = true;
                            break;
                        }
                    case IdPermisoAnularRemision:
                        {
                            this.PermisoAnularRemision = true;
                            break;
                        }
                }
            }
        }

        private void FrmConsulta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F10)
            {
                //this.tsBtnEditar_Click(this.tsBtnEditar, new EventArgs());
            }
            else
            {
                if (e.KeyData == Keys.F12)
                {
                    //this.tsBtnRealizarAbono_Click(this.tsBtnRealizarAbono, new EventArgs());
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

        private void tsBtnEditar_Click(object sender, EventArgs e)
        {
            if (dgvFactura.RowCount != 0)
            {
                var rowFactura = dgvFactura.CurrentRow;
                if (!rowFactura.Cells["EstadoFactura"].Value.ToString().Equals("Facturada"))
                {
                    if (this.PermisoFacturarRemision)
                    {
                        EditarRemision(rowFactura);
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
                                        if (userTemp.Permisos.Where(ps => ps.IdPermiso.Equals(IdPermisoFacturarRemision)).Count() > 0)
                                        {
                                            admin = true;
                                            EditarRemision(rowFactura);
                                        }
                                        else
                                        {
                                            MessageBox.Show("El usuario no tiene permisos para esta acción.", "Remisión venta",
                                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            admin = false;
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show
                                            ("Usuario o contraseña incorrecta.", "Remisión venta", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    OptionPane.MessageInformation("La remisión se encuentra facturada.");
                }
            }
        }

        private void EditarRemision(DataGridViewRow rowFactura)
        {
            var miFactura = new FacturaVenta();
            miFactura.Remision_ = true;
            miFactura.Proveedor.NitProveedor = rowFactura.Cells["Nit"].Value.ToString();
            miFactura.Proveedor.NombreProveedor = rowFactura.Cells["Proveedor"].Value.ToString();
            miFactura.Numero = rowFactura.Cells["Numero"].Value.ToString();
            miFactura.FechaIngreso = (DateTime)rowFactura.Cells["FechaIngreso"].Value;
            miFactura.FechaLimite = Convert.ToDateTime(rowFactura.Cells["FechaLimite"].Value);
            miFactura.AplicaDescuento = (bool)rowFactura.Cells["DesctoFactura"].Value;
            miFactura.Descuento = (double)rowFactura.Cells["Descuento"].Value;
            miFactura.EstadoFactura.Id = Convert.ToInt32(rowFactura.Cells["IdEstado"].Value);

            var editRemision = new Ventas.Factura.Edicion.FrmFacturaVenta();
            if (miFactura.EstadoFactura.Id == 1)
            {
                editRemision.PagoFactRemision = true;
            }

            editRemision.Usuario_ = this.Usuario_;
            editRemision.Remision = true;
            editRemision.MdiParent = this.MdiParent;
            editRemision.lblInfo.Text = "Facturar Remisión";
            editRemision.Factura = miFactura;
            editRemision.Productos = Productos(Convert.ToInt32(miFactura.Numero));
            editRemision.Show();
            editRemision.CargarFacturaEdicion();
            this.Tranfer = true;
        }

        /*private void tsBtnRealizarAbono_Click(object sender, EventArgs e)
        {
            if (dgvFactura.RowCount != 0)
            {
                var idEstado = (int)dgvFactura.CurrentRow.Cells["IdEstado"].Value;
                if (!txtResta.Text.Equals("0") && idEstado == 2)//idEstado == 2)
                {
                    if (Convert.ToBoolean(dgvFactura.CurrentRow.Cells["Activa"].Value))
                    {
                        if (!ExtendForms)
                        {
                            /*var frmCancelarVenta = new Abonos.FrmCancelarVenta();
                            frmCancelarVenta.NumeroFactura = (string)dgvFactura.CurrentRow.Cells["Numero"].Value;
                            frmCancelarVenta.Abono = true;
                            frmCancelarVenta.txtTotal.Text = txtResta.Text;
                            ExtendForms = true;
                            //frmCancelarVenta.MdiParent = this.MdiParent;
                            frmCancelarVenta.Show();*/
                        /*}
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
        }*/

        private void tsBtnCopia_Click(object sender, EventArgs e)
        {
            if (dgvFactura.RowCount != 0)
            {
                var registro = dgvFactura.Rows[dgvFactura.CurrentCell.RowIndex];
                var contado = true;
                if (Convert.ToInt32(registro.Cells["IdEstado"].Value).Equals(2))
                {
                    contado = false;
                }
                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("printCopiaRemision")))
                {
                    PrintPos(registro.Cells["Numero"].Value.ToString(),
                             registro.Cells["Nit"].Value.ToString(),
                             Convert.ToBoolean(registro.Cells["DesctoFactura"].Value),
                             miBussinesRemision.FormasPago(Convert.ToInt32(registro.Cells["Numero"].Value)).
                                                AsEnumerable().Sum(d => d.Field<int>("pago")));
                }
                else
                {
                    /*DialogResult rta = MessageBox.Show("¿Desea visualizar la impresión de la Remisión?", "Remisión",
                        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);*/

                    FrmPrint frmPrint = new FrmPrint();
                    frmPrint.StringCaption = "Consulta Remisión";
                    frmPrint.StringMessage = "Impresión de la Remisión Venta";
                    DialogResult rta = frmPrint.ShowDialog();

                    if (rta.Equals(DialogResult.Yes))
                    {
                        Print(registro.Cells["Numero"].Value.ToString(),
                               Convert.ToBoolean(registro.Cells["DesctoFactura"].Value),
                               registro.Cells["Nit"].Value.ToString(),
                               contado, false);
                    }
                    else
                    {
                        if (rta.Equals(DialogResult.No))
                        {
                            Print(registro.Cells["Numero"].Value.ToString(),
                                   Convert.ToBoolean(registro.Cells["DesctoFactura"].Value),
                                   registro.Cells["Nit"].Value.ToString(),
                                   contado, true);
                        }
                    }

                        /*Print(registro.Cells["Numero"].Value.ToString(),
                               Convert.ToBoolean(registro.Cells["DesctoFactura"].Value),
                               registro.Cells["Nit"].Value.ToString(),
                               contado, true);*/
                }
            }
            else
            {
                OptionPane.MessageInformation("Debe primero cargar un Remisión.");
            }
        }

        private void tsBtnVerPagos_Click(object sender, EventArgs e)
        {
            if (this.txtAbono.Text.Equals("0"))
            {
                OptionPane.MessageInformation("La remisión no presenta pagos.  ");
            }
            else
            {
                var frmPagos = new FrmPagosRemision();
                frmPagos.NumeroRemision = Convert.ToInt32(this.dgvFactura.CurrentRow.Cells["Numero"].Value);
                frmPagos.ShowDialog();
            }
        }

        private void tsBtnConsultaIngresos_Click(object sender, EventArgs e)
        {
            var frmConsultaIngresos = new Administracion.CajaRemision.FrmConsultaCajaRemision();
            frmConsultaIngresos.MdiParent = this.MdiParent;
            frmConsultaIngresos.Show();
        }

        private void tsBtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsBtnSaldarRemision_Click(object sender, EventArgs e)
        {
            if (dgvFactura.RowCount != 0)
            {
                var idEstado = Convert.ToInt32(dgvFactura.CurrentRow.Cells["IdEstado"].Value);
                var facturada = dgvFactura.CurrentRow.Cells["EstadoFactura"].Value.ToString();
                if (!facturada.Equals("Facturada"))
                {
                    if (idEstado.Equals(2))
                    {
                        if (UseObject.RemoveSeparatorMil(txtResta.Text) > 0)
                        {
                            if (!ExtendForms)
                            {
                                var frmCancelarVenta = new Factura.Abonos.FrmCancelarVenta();
                                ///frmCancelarVenta.MdiParent = this.MdiParent;
                                frmCancelarVenta.NumeroFactura = dgvFactura.CurrentRow.Cells["Numero"].Value.ToString();
                                frmCancelarVenta.NitCliente = this.dgvFactura.CurrentRow.Cells["Nit"].Value.ToString();
                                frmCancelarVenta.Abono = true;
                                frmCancelarVenta.EsVenta = false;
                                frmCancelarVenta.txtTotal.Text = txtResta.Text;
                                ExtendForms = true;
                                frmCancelarVenta.ShowDialog();
                            }
                        }
                        else
                        {
                            OptionPane.MessageInformation("La Remisión se encuentra saldada.");
                        }
                    }
                    else
                    {
                        OptionPane.MessageInformation("Esta remisión no se puede saldar.");
                    }
                }
                else
                {
                    OptionPane.MessageInformation("Esta remisión no se puede saldar, se encuentra facturada.");
                }
                //Facturada
            }
            else
            {
                OptionPane.MessageInformation("No hay registros de remisión para saldar.");
            }
        }

        private void cbCriterio_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //ResetConsulta();
            var criterio = Convert.ToInt32(cbCriterio.SelectedValue);
            switch (criterio)
            {
                case 1: //numero
                    {
                        cbCriterio1.SelectedValue = 1;
                        cbCriterio1.Enabled = false;
                        txtCodigo.Enabled = true;
                        btnBuscarCodigo.Enabled = false;
                        cbCriterio2.SelectedValue = 1;
                        cbCriterio2_SelectionChangeCommitted(this.cbCriterio2, new EventArgs());
                        break;
                    }
                case 2: //cliente
                    {
                        cbCriterio1.Enabled = true;
                        cbCriterio1.SelectedValue = 2;
                        txtCodigo.Enabled = true;
                        btnBuscarCodigo.Enabled = true;
                        break;
                    }
                case 3: //estado
                    {
                        cbCriterio1.Enabled = true;
                        cbCriterio1.SelectedValue = 2;
                        txtCodigo.Enabled = false;
                        btnBuscarCodigo.Enabled = false;
                        break;
                    }
            }
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.btnBuscar1_Click(this.btnBuscar1, new EventArgs());
            }
        }

        private void btnBuscarCodigo_Click(object sender, EventArgs e)
        {
            if (!ExtendForms)
            {
                var frmCliente = new Cliente.frmCliente();
                frmCliente.MdiParent = this.MdiParent;
                frmCliente.tcClientes.SelectedIndex = 1;
                frmCliente.ConsultaRemision = true;
                frmCliente.Show();
                ExtendForms = true;
            }
        }

        /*private void btnBuscar_Click(object sender, EventArgs e)
        {
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
                    ConsultaEstado(criterio1);
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
            }
            else
            {
                while (dgvListaArticulos.RowCount != 0)
                {
                    dgvListaArticulos.Rows.RemoveAt(0);
                }
            }
        }*/

        private void cbCriterio1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //ResetConsulta();
            var criterio1 = Convert.ToInt32(cbCriterio1.SelectedValue);
            switch (criterio1)
            {
                case 1:
                    {
                        cbCriterio.SelectedValue = 1;
                        cbCriterio_SelectionChangeCommitted(this.cbCriterio1, new EventArgs());
                        break;
                    }
            }
        }

        private void cbCriterio2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var criterio2 = Convert.ToInt32(cbCriterio2.SelectedValue);
            switch (criterio2)
            {
                case 1:
                    {
                        dtpFecha1.Enabled = false;
                        dtpFecha2.Enabled = false;
                        break;
                    }
                case 2:
                    {
                        dtpFecha1.Enabled = true;
                        dtpFecha2.Enabled = false;
                        break;
                    }
                case 3:
                    {
                        dtpFecha1.Enabled = true;
                        dtpFecha2.Enabled = true;
                        break;
                    }
            }
        }

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

        private void btnBuscar1_Click(object sender, EventArgs e)
        {
            var criterio = Convert.ToInt32(cbCriterio.SelectedValue);
            var criterio1 = Convert.ToInt32(cbCriterio1.SelectedValue);
            var criterio2 = Convert.ToInt32(cbCriterio2.SelectedValue);
            dgvFactura.AutoGenerateColumns = false;

            if (criterio2 != 1) //con fecha
            {
                if (criterio2 == 2) //fecha simple
                {
                    if (criterio == 2 && criterio1 == 2)  //cliente y remision
                    {
                        ConsultaCliente(txtCodigo.Text, true, dtpFecha1.Value);
                    }
                    else
                    {
                        if (criterio == 2 && criterio1 == 3) //Cliente y facturada
                        {
                            ConsultaCliente(txtCodigo.Text, false, dtpFecha1.Value);
                        }
                        else
                        {
                            if (criterio == 3 && criterio1 == 2) //estado y remision
                            {
                                ConsultaEstado(true, dtpFecha1.Value);
                            }
                            else
                            {
                                if (criterio == 3 && criterio1 == 3) //estado y facturada
                                {
                                    ConsultaEstado(false, dtpFecha1.Value);
                                }
                            }
                        }
                    }
                }
                else  //periodo
                {
                    if (criterio == 2 && criterio1 == 2)  //cliente y remision
                    {
                        ConsultaCliente(txtCodigo.Text, true, dtpFecha1.Value, dtpFecha2.Value);
                    }
                    else
                    {
                        if (criterio == 2 && criterio1 == 3) //Cliente y facturada
                        {
                            ConsultaCliente(txtCodigo.Text, false, dtpFecha1.Value, dtpFecha2.Value);
                        }
                        else
                        {
                            if (criterio == 3 && criterio1 == 2) //estado y remision
                            {
                                ConsultaEstado(true, dtpFecha1.Value, dtpFecha2.Value);
                            }
                            else
                            {
                                if (criterio == 3 && criterio1 == 3) //estado y facturada
                                {
                                    ConsultaEstado(false, dtpFecha1.Value, dtpFecha2.Value);
                                }
                            }
                        }
                    }
                }
            }
            else //sin fecha
            {
                if (criterio == 1)  //Numero
                {
                    ConsultaNumero(Convert.ToInt32(txtCodigo.Text));
                }
                else
                {
                    if (criterio == 2 && criterio1 == 2)  //cliente y remision
                    {
                        ConsultaCliente(txtCodigo.Text, true);
                    }
                    else
                    {
                        if (criterio == 2 && criterio1 == 3) //Cliente y facturada
                        {
                            ConsultaCliente(txtCodigo.Text, false);
                        }
                        else
                        {
                            if (criterio == 3 && criterio1 == 2) //estado y remision
                            {
                                ConsultaEstado(true);
                            }
                            else
                            {
                                if (criterio == 3 && criterio1 == 3 && criterio2 == 1) //estado y facturada
                                {
                                    ConsultaEstado(false);
                                }
                            }
                        }
                    }
                }
            }
            if (dgvFactura.RowCount != 0)
            {
                dgvFactura_CellClick(this.dgvFactura,
                    new DataGridViewCellEventArgs(dgvFactura.CurrentCell.ColumnIndex, dgvFactura.CurrentCell.RowIndex));
                RemisionAnulada();
            }
            else
            {

            }
        }

        private void dgvFactura_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvListaArticulos.AutoGenerateColumns = false;
            if (dgvFactura.RowCount != 0)
            {
                var numero = (int)dgvFactura.CurrentRow.Cells["Numero"].Value;
                var descto = (bool)dgvFactura.CurrentRow.Cells["DesctoFactura"].Value;
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
                    var tabla = miBussinesRemision.ProductoRemision(numero, descto);
                    dgvListaArticulos.DataSource = tabla;
                    CalcularTotales(tabla, numero);
                    if (idEstado == 2)
                    {
                        PagosAFactura(numero);
                    }
                    else
                    {
                        if (idEstado == 1)
                        {
                            txtAbono.Text = txtTotal.Text;
                            txtResta.Text = "0";
                        }
                        else
                        {
                            txtAbono.Text = "0";
                            txtResta.Text = "0";
                        }
                    }

                    //dgvListaArticulos.DataSource = tabla;
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            if (dgvFactura.RowCount != 0)
            {
                try
                {
                    if (!miBussinesRemision.RemisionAnulada(Convert.ToInt32(dgvFactura.CurrentRow.Cells["Numero"].Value)))
                    {
                        if (!dgvFactura.CurrentRow.Cells["EstadoFactura"].Value.ToString().Equals("Facturada"))
                        {
                            if (this.PermisoAnularRemision)
                            {
                                AnularRemision();
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
                                                if (userTemp.Permisos.Where(ps => ps.IdPermiso.Equals(IdPermisoAnularRemision)).Count() > 0)
                                                {
                                                    admin = true;
                                                    AnularRemision();
                                                }
                                                else
                                                {
                                                    MessageBox.Show("El usuario no tiene permisos para esta acción.", "Remisión venta",
                                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                    admin = false;
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show
                                                    ("Usuario o contraseña incorrecta.", "Remisión venta", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                            OptionPane.MessageInformation("Esta remisión no se puede anular.");
                        }
                    }
                    else
                    {
                        OptionPane.MessageInformation("Esta remisión se encuentra anulada.");
                    }
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void AnularRemision()
        {
            DialogResult rta = MessageBox.Show("¿Está seguro(a) de querer anular esta Remisión?", "Remisión de venta",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (rta.Equals(DialogResult.Yes))
            {
                var carga = false;
                rta = MessageBox.Show("¿Desea cargar los productos de esta remisión en inventario?", "Remisión de venta",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rta.Equals(DialogResult.Yes))
                {
                    carga = true;
                }
                miBussinesRemision.AnularRemision
                    (Convert.ToInt32(dgvFactura.CurrentRow.Cells["Numero"].Value), carga);
                OptionPane.MessageInformation("La Remisión ha sido anulada.");
                btnBuscar1_Click(this.btnBuscar1, new EventArgs());
            }
        }
/*
        private void tsBtnAnular_Click(object sender, EventArgs e)
        {
            if (dgvFactura.RowCount != 0)
            {
                if (Convert.ToBoolean(dgvFactura.CurrentRow.Cells["Activa"].Value))
                {
                    DialogResult rta = MessageBox.Show("¿Está seguro(a) de querer anular esta Factura de Venta?", "Factura Venta",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (rta.Equals(DialogResult.Yes))
                    {
                        try
                        {
                            miBussinesFactura.AnularFactura
                                (Convert.ToString(dgvFactura.CurrentRow.Cells["Numero"].Value));
                            OptionPane.MessageInformation("La Factura ha sido anulada.");
                        }
                        catch (Exception ex)
                        {
                            OptionPane.MessageError(ex.Message);
                        }
                    }
                }
                else
                {
                    OptionPane.MessageInformation("Esta factura ya esta anulada.");
                }
            }
        }

        private void tsSaldoCliente_Click(object sender, EventArgs e)
        {
            if (dgvFactura.RowCount != 0)
            {
                if (Convert.ToInt32(dgvFactura.CurrentRow.Cells["IdEstado"].Value) == 2)
                {
                    try
                    {
                        var total = miBussinesFactura.SaldoPorCliente
                            (2, dgvFactura.CurrentRow.Cells["Nit"].Value.ToString());
                        /*var frmSaldoC = new Saldos.FrmSaldoCliente();
                        frmSaldoC.MdiParent = this.MdiParent;
                        frmSaldoC.txtCliente.Text = dgvFactura.CurrentRow.Cells["Proveedor"].Value.ToString();
                        frmSaldoC.txtNit.Text = dgvFactura.CurrentRow.Cells["Nit"].Value.ToString();
                        frmSaldoC.txtSaldo.Text = UseObject.InsertSeparatorMil(total.ToString());
                        frmSaldoC.Show();*/
                  /*  }
                    catch (Exception ex)
                    {
                        OptionPane.MessageError(ex.Message);
                    }
                }
            }
        }

        /*private void tsBtnSaltoTotalCredito_Click(object sender, EventArgs e)
        {
            /*if (dgvFactura.RowCount != 0)
            {
                if (Convert.ToInt32(dgvFactura.CurrentRow.Cells["IdEstado"].Value) == 2)
                {*/
                   /* try
                    {
                        /*var total = miBussinesFactura.SaldoTotalCredito(2);
                        var frmSaldo = new Saldos.FrmSaldosTotal();
                        frmSaldo.MdiParent = this.MdiParent;
                        frmSaldo.txtSaldo.Text = UseObject.InsertSeparatorMil(total.ToString());
                        frmSaldo.Show();*/
                    /*}
                    catch (Exception ex)
                    {
                        OptionPane.MessageError(ex.Message);
                    }
                //}
            //}
        }
*/
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
                        case 1:
                            {
                                dgvFactura.DataSource =
                                miBussinesRemision.ConsultaCliente(ClienteActual, true, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 2:
                            {
                                dgvFactura.DataSource =
                                miBussinesRemision.ConsultaCliente(ClienteActual, false, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 3:
                            {
                                dgvFactura.DataSource = miBussinesRemision.ConsultaEstado(true, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 4:
                            {
                                dgvFactura.DataSource = miBussinesRemision.ConsultaEstado(false, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 5:
                            {
                                dgvFactura.DataSource =
                                miBussinesRemision.ConsultaCliente(ClienteActual, true, Fecha1Actual, Fecha2Actual, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 6:
                            {
                                dgvFactura.DataSource =
                                miBussinesRemision.ConsultaCliente(ClienteActual, false, Fecha1Actual, Fecha2Actual, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 7:
                            {
                                dgvFactura.DataSource =
                                miBussinesRemision.consultaEstado(true, Fecha1Actual, Fecha2Actual, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 8:
                            {
                                dgvFactura.DataSource =
                                miBussinesRemision.consultaEstado(false, Fecha1Actual, Fecha2Actual, RowFactura, RowMaxFactura);
                                break;
                            }
                    }
                    lblStatusFactura.Text = CurrentPageFactura + " / " + PaginasFactura;
                    dgvFactura_CellClick(this.dgvFactura, null);
                    RemisionAnulada();
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
                        case 1:
                            {
                                dgvFactura.DataSource =
                                miBussinesRemision.ConsultaCliente(ClienteActual, true, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 2:
                            {
                                dgvFactura.DataSource =
                                miBussinesRemision.ConsultaCliente(ClienteActual, false, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 3:
                            {
                                dgvFactura.DataSource = miBussinesRemision.ConsultaEstado(true, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 4:
                            {
                                dgvFactura.DataSource = miBussinesRemision.ConsultaEstado(false, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 5:
                            {
                                dgvFactura.DataSource =
                                miBussinesRemision.ConsultaCliente(ClienteActual, true, Fecha1Actual, Fecha2Actual, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 6:
                            {
                                dgvFactura.DataSource =
                                miBussinesRemision.ConsultaCliente(ClienteActual, false, Fecha1Actual, Fecha2Actual, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 7:
                            {
                                dgvFactura.DataSource =
                                miBussinesRemision.consultaEstado(true, Fecha1Actual, Fecha2Actual, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 8:
                            {
                                dgvFactura.DataSource =
                                miBussinesRemision.consultaEstado(false, Fecha1Actual, Fecha2Actual, RowFactura, RowMaxFactura);
                                break;
                            }
                    }
                    CurrentPageFactura--;
                    lblStatusFactura.Text = CurrentPageFactura + " / " + PaginasFactura;
                    dgvFactura_CellClick(this.dgvFactura, null);
                    RemisionAnulada();
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
                        case 1:
                            {
                                dgvFactura.DataSource =
                                miBussinesRemision.ConsultaCliente(ClienteActual, true, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 2:
                            {
                                dgvFactura.DataSource =
                                miBussinesRemision.ConsultaCliente(ClienteActual, false, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 3:
                            {
                                dgvFactura.DataSource = miBussinesRemision.ConsultaEstado(true, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 4:
                            {
                                dgvFactura.DataSource = miBussinesRemision.ConsultaEstado(false, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 5:
                            {
                                dgvFactura.DataSource =
                                miBussinesRemision.ConsultaCliente(ClienteActual, true, Fecha1Actual, Fecha2Actual, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 6:
                            {
                                dgvFactura.DataSource =
                                miBussinesRemision.ConsultaCliente(ClienteActual, false, Fecha1Actual, Fecha2Actual, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 7:
                            {
                                dgvFactura.DataSource =
                                miBussinesRemision.consultaEstado(true, Fecha1Actual, Fecha2Actual, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 8:
                            {
                                dgvFactura.DataSource =
                                miBussinesRemision.consultaEstado(false, Fecha1Actual, Fecha2Actual, RowFactura, RowMaxFactura);
                                break;
                            }
                    }
                    CurrentPageFactura++;
                    lblStatusFactura.Text = CurrentPageFactura + " / " + PaginasFactura;
                    dgvFactura_CellClick(this.dgvFactura, null);
                    RemisionAnulada();
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
                        case 1:
                            {
                                dgvFactura.DataSource =
                                miBussinesRemision.ConsultaCliente(ClienteActual, true, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 2:
                            {
                                dgvFactura.DataSource =
                                miBussinesRemision.ConsultaCliente(ClienteActual, false, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 3:
                            {
                                dgvFactura.DataSource = miBussinesRemision.ConsultaEstado(true, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 4:
                            {
                                dgvFactura.DataSource = miBussinesRemision.ConsultaEstado(false, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 5:
                            {
                                dgvFactura.DataSource =
                                miBussinesRemision.ConsultaCliente(ClienteActual, true, Fecha1Actual, Fecha2Actual, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 6:
                            {
                                dgvFactura.DataSource =
                                miBussinesRemision.ConsultaCliente(ClienteActual, false, Fecha1Actual, Fecha2Actual, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 7:
                            {
                                dgvFactura.DataSource =
                                miBussinesRemision.consultaEstado(true, Fecha1Actual, Fecha2Actual, RowFactura, RowMaxFactura);
                                break;
                            }
                        case 8:
                            {
                                dgvFactura.DataSource =
                                miBussinesRemision.consultaEstado(false, Fecha1Actual, Fecha2Actual, RowFactura, RowMaxFactura);
                                break;
                            }
                    }
                    lblStatusFactura.Text = CurrentPageFactura + " / " + PaginasFactura;
                    dgvFactura_CellClick(this.dgvFactura, null);
                    RemisionAnulada();
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
        /// Carga las utilidades necesarias para la ejecución del formulario.
        /// </summary>
        private void CargarUtilidades()
        {
            //CRITERIO
            var lst = new List<Inventario.Producto.Criterio>();
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 1,
                Nombre = "Número"
            });
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 2,
                Nombre = "Cliente"
            });
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 3,
                Nombre = "Estado"
            });
            cbCriterio.DataSource = lst;

            //CRITERIO 1
            lst = new List<Inventario.Producto.Criterio>();
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 1,
                Nombre = ""
            });
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 2,
                Nombre = "Remisión"
            });
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 3,
                Nombre = "Facturada"
            });
            cbCriterio1.DataSource = lst;

            //CRITERIO 2
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
        }

        /// <summary>
        /// Carga la lista de criterio General de consulta.
        /// </summary>
        private void CargarCriterioGeneral()
        {
            
        }

        private void CargarPrimerCriterio()
        {
            
        }

        private void CargarPrimerCriterioOpcion()
        {
           
        }

        private void CargarSegundoCriterio()
        {
            /*var lst = new List<Inventario.Producto.Criterio>();
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 1,
                Nombre = ""
            });
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 2,
                Nombre = "Fact. en mora"
            });
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 3,
                Nombre = "Fecha Ingreso"
            });
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 4,
                Nombre = "Fecha Limite"
            });
            cbCriterio2.DataSource = lst;*/
        }

        private void CargarTercerCriterio()
        {
            /*var lst = new List<Inventario.Producto.Criterio>();
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
            cbCriterio3.DataSource = lst;*/
        }

        /// <summary>
        /// Obtiene el resultado de la consulta de Remisión por número.
        /// </summary>
        private void ConsultaNumero(int numero)
        {
            try
            {
                dgvFactura.DataSource = miBussinesRemision.ConsultaNumero(numero);
                if (dgvFactura.RowCount == 0)
                {
                    LimpiarGridProducto();
                    lblStatusFactura.Text = "0 / 0";
                    OptionPane.MessageInformation("No se encontraron remisiones con ese número.");
                }
                else
                    lblStatusFactura.Text = "1 / 1";
            }
            catch (Exception ex)
            {
                lblStatusFactura.Text = "0 / 0";
                OptionPane.MessageError(ex.Message);
            }
        }

        public void ConsultaCliente(string nit, bool remision)//iteracion = 1(true); iteracion = 2(false)
        {
            RowFactura = 0;
            CurrentPageFactura = 1;
            if (remision)
                Iteracion = 1;
            else
                Iteracion = 2;
            ClienteActual = nit;
            try
            {
                dgvFactura.DataSource = 
                    miBussinesRemision.ConsultaCliente(nit, remision, RowFactura, RowMaxFactura);
                if (dgvFactura.RowCount == 0)
                {
                    LimpiarGridProducto();
                    OptionPane.MessageInformation("No se encontraron remisiones con ese cliente.");
                }
                TotalRowFactura = miBussinesRemision.GetRowsConsultaCliente(nit, remision);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            CalcularPaginas();
        }

        public void ConsultaEstado(bool remision)//iteracion = 3(true); iteracion = 4(false)
        {
            RowFactura = 0;
            CurrentPageFactura = 1;
            if (remision)
                Iteracion = 3;
            else
                Iteracion = 4;
            try
            {
                dgvFactura.DataSource = miBussinesRemision.ConsultaEstado(remision, RowFactura, RowMaxFactura);
                if (dgvFactura.RowCount == 0)
                {
                    LimpiarGridProducto();
                    OptionPane.MessageInformation("No se encontraron remisiones en ese estado.");
                }
                TotalRowFactura = miBussinesRemision.GetRowsConsultaEstado(remision);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            CalcularPaginas();
        }

        public void ConsultaCliente(string nit, bool remision, DateTime fecha)
        {
            try
            {
                dgvFactura.DataSource = 
                    miBussinesRemision.ConsultaCliente(nit, remision, fecha);
                if (dgvFactura.RowCount == 0)
                {
                    lblStatusFactura.Text = "0 / 0";
                    LimpiarGridProducto();
                    OptionPane.MessageInformation("No se encontraron remisiones con ese Cliente en esa fecha.");
                }
                else
                    lblStatusFactura.Text = "1 / 1";
            }
            catch (Exception ex)
            {
                lblStatusFactura.Text = "0 / 0";
                OptionPane.MessageError(ex.Message);
            }
            
        }

        public void ConsultaEstado(bool remision, DateTime fecha)
        {
            try
            {
                dgvFactura.DataSource = miBussinesRemision.ConsultaEstado(remision, fecha);
                if (dgvFactura.RowCount == 0)
                {
                    lblStatusFactura.Text = "0 / 0";
                    LimpiarGridProducto();
                    OptionPane.MessageInformation("No se encontraron remisiones en ese estado y esa fecha.");
                }
                else
                    lblStatusFactura.Text = "1 / 1";
            }
            catch (Exception ex)
            {
                lblStatusFactura.Text = "0 / 0";
                OptionPane.MessageError(ex.Message);
            }
        }

        public void ConsultaCliente
            (string nit, bool remision, DateTime fecha, DateTime fecha1)//iteracion = 5(true); iteracion = 6(false)
        {
            RowFactura = 0;
            CurrentPageFactura = 1;
            ClienteActual = nit;
            Fecha1Actual = fecha;
            Fecha2Actual = fecha1;
            if (remision)
                Iteracion = 5;
            else
                Iteracion = 6;
            try
            {
                dgvFactura.DataSource =
                 miBussinesRemision.ConsultaCliente(nit, remision, fecha, fecha1, RowFactura, RowMaxFactura);
                if (dgvFactura.RowCount == 0)
                {
                    LimpiarGridProducto();
                    OptionPane.MessageInformation("No se encontraron remisiones con ese cliente entre dicho periodo.");
                }
                TotalRowFactura =
                 miBussinesRemision.GetRowsConsultaCliente(nit, remision, fecha, fecha1);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            CalcularPaginas();
        }

        public void ConsultaEstado
            (bool remision, DateTime fecha, DateTime fecha1)//iteracion = 7(true); iteracion = 8(false)
        {
            RowFactura = 0;
            CurrentPageFactura = 1;
            Fecha1Actual = fecha;
            Fecha2Actual = fecha1;
            if (remision)
                Iteracion = 7;
            else
                Iteracion = 8;
            try
            {
                dgvFactura.DataSource =
                    miBussinesRemision.consultaEstado(remision, fecha, fecha1, RowFactura, RowMaxFactura);
                if (dgvFactura.RowCount == 0)
                {
                    LimpiarGridProducto();
                    OptionPane.MessageInformation("No se encontraron remisiones en ese estado y en dicho periodo.");
                }
                TotalRowFactura = miBussinesRemision.GetRowsConsultaEstado(remision, fecha, fecha1);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            CalcularPaginas();
        }


        /*
        /// <summary>
        /// Obtiene el resultado de la consulta de Factura de Venta por Estado de la Factura.
        /// </summary>
        /// <param name="estado">Estado de la factura a consultar.</param>
        private void ConsultaEstado(int estado)//iteracion = 1
        {
            RowFactura = 0;
            CurrentPageFactura = 1;
            Iteracion = 1;
            EstadoActual = estado;
            try
            {
                dgvFactura.DataSource = miBussinesFactura.ConsultaEstado
                                        (estado, RowFactura, RowMaxFactura);
                if (dgvFactura.RowCount == 0)
                {
                    LimpiarGridProducto();
                    OptionPane.MessageInformation("No se encontraron Facturas en ese estado.");
                }
                TotalRowFactura = miBussinesFactura.GetRowsConsultaEstado(estado);
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
        private void ConsultaTodasCliente(string cliente)//iteracion = 2
        {
            RowFactura = 0;
            CurrentPageFactura = 1;
            Iteracion = 2;
            ClienteActual = cliente;
            try
            {
                dgvFactura.DataSource = miBussinesFactura.ConsultaPorCliente
                                        (cliente, RowFactura, RowMaxFactura);
                if (dgvFactura.RowCount == 0)
                {
                    LimpiarGridProducto();
                    OptionPane.MessageInformation("No se encontraron Facturas con ese Cliente.");
                }
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
        private void ConsultaEstadoCliente(int estado, string cliente)//iteracion = 3
        {
            RowFactura = 0;
            CurrentPageFactura = 1;
            Iteracion = 3;
            EstadoActual = estado;
            ClienteActual = cliente;
            try
            {
                dgvFactura.DataSource = miBussinesFactura.ConsultaPorEstadoYcliente
                                        (estado, cliente, RowFactura, RowMaxFactura);
                if (dgvFactura.RowCount == 0)
                {
                    LimpiarGridProducto();
                    OptionPane.MessageInformation
                        ("No se encontraron Facturas con ese Cliente en ese estado.");
                }
                TotalRowFactura = 
                    miBussinesFactura.GetRowsConsultaPorEstadoYcliente(estado, cliente);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            CalcularPaginas();
        }

        private void ConsultaEstadoFechaIngreso(int estado, DateTime fecha)//iteracion = 4
        {
            RowFactura = 0;
            CurrentPageFactura = 1;
            Iteracion = 4;
            EstadoActual = estado;
            Fecha1Actual = fecha;
            try
            {
                dgvFactura.DataSource = miBussinesFactura.ConsultaEstadoFechaIngreso
                                        (estado, fecha, RowFactura, RowMaxFactura);
                if (dgvFactura.RowCount == 0)
                {
                    LimpiarGridProducto();
                    OptionPane.MessageInformation
                        ("No se encontraron Facturas en ese estado y fecha de ingreso.");
                }
                TotalRowFactura = 
                    miBussinesFactura.GetRowsConsultaEstadoFechaIngreso(estado, fecha);
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
            RowFactura = 0;
            CurrentPageFactura = 1;
            Iteracion = 5;
            EstadoActual = estado;
            Fecha1Actual = fecha1;
            Fecha2Actual = fecha2;
            try
            {
                dgvFactura.DataSource = miBussinesFactura.ConsultaEstadoPeriodoIngreso
                                        (estado, fecha1, fecha2, RowFactura, RowMaxFactura);
                if (dgvFactura.RowCount == 0)
                {
                    LimpiarGridProducto();
                    OptionPane.MessageInformation
                        ("No se encontraron Facturas en ese estado y entre esas fechas.");
                }
                TotalRowFactura = 
                    miBussinesFactura.GetRowsConsultaEstadoPeriodoIngreso(estado, fecha1, fecha2);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            CalcularPaginas();
        }

        private void ConsultaPorClienteIngreso(string cliente, DateTime fecha)//iteracion = 6
        {
            RowFactura = 0;
            CurrentPageFactura = 1;
            Iteracion = 6;
            ClienteActual = cliente;
            Fecha1Actual = fecha;
            try
            {
                dgvFactura.DataSource = miBussinesFactura.ConsultaPorClienteIngreso
                                            (cliente, fecha, RowFactura, RowMaxFactura);
                if (dgvFactura.RowCount == 0)
                {
                    LimpiarGridProducto();
                    OptionPane.MessageInformation("No se encontraron Facturas en ese cliente y en esa fecha.");
                }
                TotalRowFactura = miBussinesFactura.GetRowsConsultaPorClienteIngreso(cliente, fecha);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            CalcularPaginas();
        }

        private void ConsultaPorClientePeriodoIngreso
            (string cliente, DateTime fecha1, DateTime fecha2)//iteracion = 7
        {
            RowFactura = 0;
            CurrentPageFactura = 1;
            Iteracion = 7;
            ClienteActual = cliente;
            Fecha1Actual = fecha1;
            Fecha2Actual = fecha2;
            try
            {
                dgvFactura.DataSource = miBussinesFactura.ConsultaPorClientePeriodoIngreso
                                              (cliente, fecha1, fecha2, RowFactura, RowMaxFactura);
                if (dgvFactura.RowCount == 0)
                {
                    LimpiarGridProducto();
                    OptionPane.MessageInformation
                        ("No se encontraron Facturas en ese cliente y entre esas fechas.");
                }
                TotalRowFactura =
                    miBussinesFactura.GetRowsConsultaPorClientePeriodoIngreso(cliente, fecha1, fecha2);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            CalcularPaginas();
        }

        private void ConsultaPorEstadoClientePeriodoIngreso//iteracion = 8
            (int estado, string cliente, DateTime fecha1, DateTime fecha2)
        {
            RowFactura = 0;
            CurrentPageFactura = 1;
            Iteracion = 8;
            try
            {
                dgvFactura.DataSource = miBussinesFactura.ConsultaPorEstadoClientePeriodoIngreso
                                            (estado, cliente, fecha1, fecha2, RowFactura, RowMaxFactura);
                if (dgvFactura.RowCount == 0)
                {
                    LimpiarGridProducto();
                    OptionPane.MessageInformation
                        ("No se encontraron Facturas en ese estado, con ese cliente y entre esas fechas.");
                }
                TotalRowFactura =
                miBussinesFactura.GetRowsConsultaPorClientePeriodoIngreso(cliente, fecha1, fecha2);
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

        void CompletaEventos_Completaz(CompletaArgumentosDeEventoz args)
        {
            try
            {
                if (this.Tranfer)
                {
                    if (Convert.ToBoolean(args.MiZona))
                    {
                        this.btnBuscar1_Click(this.btnBuscar1, new EventArgs());
                    }
                    this.Tranfer = false;
                }
            }
            catch { }
        }

        void CompletaEventos_ComAbonoRemision(CompArgAbonoRemision args)
        {
            try
            {
                //var formas = (List<FormaPago>)args.MiObjeto;
                //ImprimirComprobante(formas);
                dgvFactura_CellClick(this.dgvFactura, new DataGridViewCellEventArgs
                        (dgvFactura.CurrentCell.ColumnIndex, dgvFactura.CurrentCell.RowIndex));
            }
            catch { }
        }

        void CompletaEventos_Completaeb(CompletaArgumentosDeEventoeb args)
        {
            try
            {
                txtCodigo.Text = (string)args.MiBodegaeb;
            }
            catch { }

            try
            {
                ExtendForms = (bool)args.MiBodegaeb;
            }
            catch { }
        }



        private void ResetConsulta()
        {
            LimpiarGridProducto();
            while (dgvFactura.RowCount != 0)
            {
                dgvFactura.Rows.RemoveAt(0);
            }
            lblStatusFactura.Text = "0 / 0";
        }

        /// <summary>
        /// Limpia los registro del DataGrid de Producto.
        /// </summary>
        private void LimpiarGridProducto()
        {
            this.txtSubTotal.Text = "0";
            this.txtDescuento.Text = "0";
            this.txtIva.Text = "0";
            this.txtTotal.Text = "0";
            this.txtDevolucion.Text = "0";
            this.txtDiferencia.Text = "0";
            this.txtAbono.Text = "0";
            this.txtResta.Text = "0";
            while (dgvListaArticulos.RowCount != 0)
            {
                dgvListaArticulos.Rows.RemoveAt(0);
            }
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
        private void CalcularTotales(DataTable tabla, int numero)
        {
            txtSubTotal.Text = UseObject.InsertSeparatorMil
                ( Convert.ToInt32(
                  (tabla.AsEnumerable().Sum(s => (s.Field<double>("ValorUnitario") * 
                                            s.Field<double>("Cantidad")))) ) .ToString()
                );

            txtDescuento.Text = UseObject.InsertSeparatorMil
                ( Convert.ToInt32(
                  (tabla.AsEnumerable()
                   .Sum(d => ((d.Field<double>("ValorUnitario") *
                               UseObject.RemoveCharacter(d["Descuento"].ToString(), '%') / 100) * 
                               d.Field<double>("Cantidad")))) )
                   .ToString()
                );

            txtIva.Text = UseObject.InsertSeparatorMil
                (Convert.ToInt32(
                  (tabla.AsEnumerable().Sum(i => (i.Field<double>("ValorIva") * 
                                            i.Field<double>("Cantidad")))) ) .ToString()
                );

            txtTotal.Text = UseObject.InsertSeparatorMil
                (
                  ( Convert.ToInt32( tabla.AsEnumerable().Sum(t => t.Field<int>("Valor")) ) ).ToString()
                );

            try
            {
                var tablaDev = miBussinesDevolucion.ConsultaRemision(numero);
                if (tablaDev.Rows.Count != 0)
                {
                    foreach (DataGridViewRow gRow in dgvListaArticulos.Rows)
                    {
                        var tRow = from data in tablaDev.AsEnumerable()
                                   where data.Field<string>("codigo") == gRow.Cells["Codigo"].Value.ToString()
                                      && data.Field<int>("idmedida") == Convert.ToInt32(gRow.Cells["IdMedida"].Value)
                                      && data.Field<int>("idcolor") == Convert.ToInt32(gRow.Cells["IdColor"].Value)
                                   select data;
                        if (tRow.ToArray().Length != 0)
                        {
                            //var j = (tRow.Single().Field<double>("cantidad")).ToString();
                            //var j1 = tRow.Single().Field<double>("cantidad").ToString();
                            gRow.Cells["Devolucion"].Value = (tRow.Single().Field<double>("cantidad")).ToString();
                        }
                        else
                        {
                            gRow.Cells["Devolucion"].Value = "0";
                        }
                    }
                    txtDevolucion.Text = UseObject.InsertSeparatorMil(
                        tablaDev.AsEnumerable().Sum(s => s.Field<int>("total")).ToString()
                        );
                    txtDiferencia.Text = UseObject.InsertSeparatorMil(
                                        (UseObject.RemoveSeparatorMil(txtTotal.Text) -
                                         UseObject.RemoveSeparatorMil(txtDevolucion.Text)
                                        ).ToString());
                }
                else
                {
                    txtDevolucion.Text = "0";
                    txtDiferencia.Text = txtTotal.Text;
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        /*private void MostrarDevoluciones(int numero)
        {
            try
            {
                var devoluciones = miBussinesDevolucion.DevolucionesRemision(numero);
                foreach (DataGridViewRow row in dgvFactura.Rows)
                {
                    var qRow = from data in devoluciones
                               where data.Codigo == row.Cells[""].Value.ToString()
                                  && data.Medida == Convert.ToInt32(row.Cells[""].Value)
                                  && data.
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }*/

        /*private void PagosAFactura(string numero)
        {
            try
            {
                var total = miBussinesFormaPago.GetTotalFormasDePagoDeFacturaVenta(numero);
                if (total > UseObject.RemoveSeparatorMil(txtTotal.Text))
                {
                    txtAbono.Text = txtTotal.Text;
                    txtResta.Text = "0";
                }
                else
                {
                    txtAbono.Text = UseObject.InsertSeparatorMil(total.ToString());
                    txtResta.Text = UseObject.InsertSeparatorMil(
                        (UseObject.RemoveSeparatorMil(txtTotal.Text) - total).ToString());
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }*/

        /// <summary>
        /// Obtiene los registro de Productos de la consulta de Factura en 
        /// una tabla de memoria.
        /// </summary>
        /// <returns></returns>
        private DataTable Productos(int numero)
        {
            var devoluciones = miBussinesDevolucion.DevolucionesRemision(numero);
            var tabla = CrearTabla();
            foreach (DataGridViewRow row in dgvListaArticulos.Rows)
            {
                var qRow = from data in devoluciones
                           where data.Codigo == row.Cells["Codigo"].Value.ToString()
                              && data.Medida == Convert.ToInt32(row.Cells["IdMedida"].Value)
                              && data.Color == Convert.ToInt32(row.Cells["IdColor"].Value)
                           select data;
                if (qRow.ToArray().Length != 0)
                {
                    if ((Convert.ToInt32(row.Cells["Cantidad"].Value) - qRow.Single().Cantidad) != 0)
                    {
                        var row_ = tabla.NewRow();
                        row_["Save"] = false;
                        row_["Id"] = (int)row.Cells["IdProducto"].Value;
                        row_["Codigo"] = row.Cells["Codigo"].Value.ToString();
                        row_["Articulo"] = row.Cells["Articulo"].Value.ToString();
                        var cant = Convert.ToDouble(row.Cells["Cantidad"].Value);
                        row_["Cantidad"] = Convert.ToDouble(row.Cells["Cantidad"].Value) - qRow.Single().Cantidad;//(int)row.Cells["Cantidad"].Value;
                        var v = Convert.ToDouble(row.Cells["Valor"].Value);
                        row_["ValorUnitario"] = Convert.ToDouble(row.Cells["Valor"].Value);
                        row_["Descuento"] = row.Cells["Descto"].Value.ToString();
                        row_["ValorMenosDescto"] = row_["ValorReal"] = (double)row.Cells["ValorMenosDescto"].Value;
                        row_["Iva"] = row.Cells["Iva"].Value.ToString();
                        row_["TotalMasIva"] = (double)row.Cells["TotalMasIva"].Value;

                        row_["ValorIva"] = Convert.ToDouble(row.Cells["ValorIva"].Value);

                        // ***************    
                        row_["Ico"] = Convert.ToDouble(row.Cells["Ico"].Value);
                        // ***********************

                        row_["Valor"] = (double)row.Cells["Total"].Value;
                        row_["Unidad"] = row.Cells["Unidad"].Value.ToString();
                        row_["IdMedida"] = (int)row.Cells["IdMedida"].Value;
                        row_["Medida"] = row.Cells["Medida"].Value.ToString();
                        row_["IdColor"] = (int)row.Cells["IdColor"].Value;
                        row_["Color"] = (string)row.Cells["Color"].Value;
                        row_["IdMarca"] = Convert.ToInt32(row.Cells["IdMarca"].Value);
                        tabla.Rows.Add(row_);
                    }
                }
                else
                {
                    var row_ = tabla.NewRow();
                    row_["Save"] = false;
                    row_["Id"] = (int)row.Cells["IdProducto"].Value;
                    row_["Codigo"] = row.Cells["Codigo"].Value.ToString();
                    row_["Articulo"] = row.Cells["Articulo"].Value.ToString();
                    row_["Cantidad"] = (double)row.Cells["Cantidad"].Value;
                    var cant = (double)row.Cells["Cantidad"].Value;
                    row_["ValorUnitario"] = Convert.ToDouble(row.Cells["Valor"].Value);
                    var v = row_["ValorUnitario"].ToString();
                    row_["Descuento"] = row.Cells["Descto"].Value.ToString();
                    row_["ValorMenosDescto"] = row_["ValorReal"] = (double)row.Cells["ValorMenosDescto"].Value;
                    row_["Iva"] = row.Cells["Iva"].Value.ToString();
                    row_["TotalMasIva"] = (double)row.Cells["TotalMasIva"].Value;

                    row_["ValorIva"] = Convert.ToDouble(row.Cells["ValorIva"].Value);

                    // ***************    
                    row_["Ico"] = Convert.ToDouble(row.Cells["Ico"].Value);
                    // ***********************

                    row_["Valor"] = (int)row.Cells["Total"].Value;
                    row_["Unidad"] = row.Cells["Unidad"].Value.ToString();
                    row_["IdMedida"] = (int)row.Cells["IdMedida"].Value;
                    row_["Medida"] = row.Cells["Medida"].Value.ToString();
                    row_["IdColor"] = (int)row.Cells["IdColor"].Value;
                    row_["Color"] = (Image)row.Cells["Color"].Value;
                    row_["IdMarca"] = Convert.ToInt32(row.Cells["IdMarca"].Value);
                    row_["Retorno"] = false;
                    tabla.Rows.Add(row_);
                }
                
                /*var row_ = tabla.NewRow();
                row_["Save"] = false;
                row_["Id"] = (int)row.Cells["IdProducto"].Value;
                row_["Codigo"] = row.Cells["Codigo"].Value.ToString();
                row_["Articulo"] = row.Cells["Articulo"].Value.ToString();
                row_["Cantidad"] = (int)row.Cells["Cantidad"].Value;
                row_["ValorUnitario"] = (int)row.Cells["Valor"].Value;
                row_["Descuento"] = row.Cells["Descto"].Value.ToString();
                row_["ValorMenosDescto"] = (double)row.Cells["ValorMenosDescto"].Value;
                row_["Iva"] = row.Cells["Iva"].Value.ToString();
                row_["TotalMasIva"] = (double)row.Cells["TotalMasIva"].Value;
                row_["Valor"] = (double)row.Cells["Total"].Value;
                row_["Unidad"] = row.Cells["Unidad"].Value.ToString();
                row_["IdMedida"] = (int)row.Cells["IdMedida"].Value;
                row_["Medida"] = row.Cells["Medida"].Value.ToString();
                row_["IdColor"] = (int)row.Cells["IdColor"].Value;
                row_["Color"] = (string)row.Cells["Color"].Value;
                tabla.Rows.Add(row_);*/
            }
            return tabla;
        }

        private void PagosAFactura(int numero)
        {
            try
            {
                var total = miBussinesFormaPago.GetTotalPagoRemision(numero);
                if (total > UseObject.RemoveSeparatorMil(txtDiferencia.Text))
                {
                    txtAbono.Text = txtDiferencia.Text;
                    txtResta.Text = "0";
                }
                else
                {
                    txtAbono.Text = UseObject.InsertSeparatorMil(total.ToString());
                    txtResta.Text = UseObject.InsertSeparatorMil(
                        (UseObject.RemoveSeparatorMil(txtDiferencia.Text) - total).ToString());
                }

                /**if (total > UseObject.RemoveSeparatorMil(txtTotal.Text))
                {
                    txtAbono.Text = txtTotal.Text;
                    txtResta.Text = "0";
                }
                else
                {
                    txtAbono.Text = UseObject.InsertSeparatorMil(total.ToString());
                    txtResta.Text = UseObject.InsertSeparatorMil(
                        (UseObject.RemoveSeparatorMil(txtTotal.Text) - total).ToString());
                }*/
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void RemisionAnulada()
        {
            foreach (DataGridViewRow row in dgvFactura.Rows)
            {
                if (miBussinesRemision.RemisionAnulada(Convert.ToInt32(row.Cells["Numero"].Value)))
                {
                    //row.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(255, 128, 128);
                    row.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(200, 128, 128);
                }
            }
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
            miTabla.Columns.Add(new DataColumn("Cantidad", typeof(double)));
            miTabla.Columns.Add(new DataColumn("ValorUnitario", typeof(double)));
            miTabla.Columns.Add(new DataColumn("Descuento", typeof(string)));
            miTabla.Columns.Add(new DataColumn("ValorMenosDescto", typeof(double)));
            miTabla.Columns.Add(new DataColumn("Iva", typeof(string)));
            miTabla.Columns.Add(new DataColumn("TotalMasIva", typeof(double)));
            miTabla.Columns.Add(new DataColumn("Valor", typeof(double)));
            miTabla.Columns.Add(new DataColumn("Unidad", typeof(string)));
            miTabla.Columns.Add(new DataColumn("IdMedida", typeof(int)));
            miTabla.Columns.Add(new DataColumn("Medida", typeof(string)));
            miTabla.Columns.Add(new DataColumn("IdColor", typeof(int)));
            miTabla.Columns.Add(new DataColumn("Color", typeof(string)));
            miTabla.Columns.Add(new DataColumn("IdMarca", typeof(int)));
            miTabla.Columns.Add(new DataColumn("Save", typeof(bool)));
            miTabla.Columns.Add(new DataColumn("ValorReal", typeof(double)));
            miTabla.Columns.Add(new DataColumn("Retorno", typeof(bool)));

            miTabla.Columns.Add(new DataColumn("Ico", typeof(double)));

            miTabla.Columns.Add(new DataColumn("ValorIva", typeof(double)));
            return miTabla;
        }

        private void ImprimirComprobante(List<FormaPago> pagos)
        {
            DialogResult rta = MessageBox.Show("¿Desea imprimir el comprobante de ingreso?", "Abono a Remisión",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rta.Equals(DialogResult.Yes))
            {
                try
                {
                    var cliente = miBussinesCliente.ClienteAEditar
                        (dgvFactura.CurrentRow.Cells["Nit"].Value.ToString());
                    var printComp = new Cliente.FrmPrintAnticipo();
                    printComp.Fecha = DateTime.Now;
                    printComp.Cliente = cliente.NombresCliente;
                    printComp.Nit = cliente.NitCliente;
                    printComp.Direccion = cliente.DireccionCliente + "  " +
                        cliente.Ciudad + "  " + cliente.Departamento;
                    printComp.Valor = pagos.Sum(p => p.Valor).ToString();
                    var efectivo = 0;
                    foreach (FormaPago pago in pagos)
                    {
                        if (pago.IdFormaPago.Equals(1) || pago.IdFormaPago.Equals(3))
                        {
                            efectivo += Convert.ToInt32(pago.Valor);
                        }
                    }
                    printComp.Efectivo = efectivo.ToString();
                    printComp.Cheque = pagos.Where(p => p.IdFormaPago == 2).Sum(s => s.Valor).ToString();
                    printComp.Numero = miBussinesConsecutivo.Consecutivo("ConsIngresoRemision") +
                                       miBussinesConsecutivo.Consecutivo("IngresoRemision");
                    printComp.Concepto = "Abono a Remisión Número: " +
                                          dgvFactura.CurrentRow.Cells["Numero"].Value.ToString();
                    printComp.MdiParent = this.MdiParent;
                    printComp.Show();
                    miBussinesConsecutivo.ActualizarConsecutivo("IngresoRemision");
                    /*if (Convert.ToInt32(AppConfiguracion.ValorSeccion("ing_remision")) < 99)
                    {
                        AppConfiguracion.SaveConfiguration(
                            "ing_remision", IncrementaConsecutivo(AppConfiguracion.ValorSeccion("ing_remision")));
                    }
                    else
                    {
                        AppConfiguracion.SaveConfiguration(
                            "ing_remision", (Convert.ToInt32(AppConfiguracion.ValorSeccion("ing_remision")) + 1).ToString());
                    }*/
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
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

        private void Print
            (string numero, bool descto, string cliente, bool contado, bool view)
        {
            var miBussinesEmpresa = new BussinesEmpresa();
            var miBussinesUsuario = new BussinesUsuario();
            var dsDetalle = new DataSet();
            var dsEmpresa = new DataSet();
            var dsFactura = new DataSet();
            var dsUsuario = new DataSet();
            var dsCliente = new DataSet();
            var dsDian = new DataSet();
            try
            {
                //dsDetalle = miBussinesFactura.PrintProducto(numero, descto);
                dsDetalle = miBussinesRemision.PrintProducto(Convert.ToInt32(numero), descto);
                dsEmpresa = miBussinesEmpresa.PrintEmpresa();
                //dsFactura = miBussinesFactura.PrintFacturaVenta(numero);
                dsFactura = miBussinesRemision.PrintRemision(numero);
                dsUsuario = miBussinesUsuario.PrintUsuarioRemision(Convert.ToInt32(numero));
                dsCliente = miBussinesCliente.PrintCliente(cliente);

                var frmPrint = new Factura.FrmPrintFactura();
                frmPrint.Text = "Imprimir Remisión";
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

                //frmPrint.RptvFactura.LocalReport.ReportPath = @"C:\reports\RptRemision.rdlc";
                frmPrint.RptvFactura.LocalReport.ReportPath = AppConfiguracion.ValorSeccion("report") + @"\reports\RptRemision.rdlc";
                //frmPrint.RptvFactura.LocalReport.ReportPath = @"D:\Proyectos\SistemaFacturacion\SVN-SIF-I\Test-Setup-1\BackUp-3\Edit-Home\SistemaFactura\Aplicacion\Ventas\Reportes\RptRemision.rdlc";

                ///frmPrint.RptvFactura.LocalReport.ReportPath = @"C:\reports\RptRemision.rdlc";

                Label NoFactura = new Label();
                NoFactura.AutoSize = true;
                NoFactura.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                NoFactura.Text = numero;

                var Fact = new ReportParameter();
                Fact.Name = "Fact";
                Fact.Values.Add("REMISIÓN No.  " + NoFactura.Text);
                frmPrint.RptvFactura.LocalReport.SetParameters(Fact);

                var pago = new ReportParameter();
                pago.Name = "pago";
                if (contado)
                {
                    pago.Values.Add("Contado");
                }
                else
                {
                    pago.Values.Add("Crédito");
                }
                frmPrint.RptvFactura.LocalReport.SetParameters(pago);

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

        private void PrintPos(string numero, string cliente, bool descto, int pago)
        {
            try
            {
                var miBussinesEmpresa = new BussinesEmpresa();
                var miBussinesProducto = new BussinesProducto();
                //var lstProducto = new List<ProductoFacturaProveedor>();

                var remisionRow = this.miBussinesRemision.PrintRemision(numero).Tables[0].AsEnumerable().First();

                PrintTicket printTicket = new PrintTicket();
                printTicket.UseItem = false;
                printTicket.Detail = this.GraneroJhonRiosucio;
                printTicket.EsFactura = false;
                printTicket.Copia = true;

                printTicket.empresaRow = miBussinesEmpresa.PrintEmpresa().Tables[0].AsEnumerable().First();

                printTicket.IdEstado = Convert.ToInt32(remisionRow["IdEstado"]);
                printTicket.Numero = numero;
                printTicket.Fecha = Convert.ToDateTime(remisionRow["Fecha"]);
                printTicket.Hora = Convert.ToDateTime(remisionRow["Hora"]);
                printTicket.Limite = Convert.ToDateTime(remisionRow["FechaLimite"]);
                printTicket.Usuario = this.miBussinesUsuario.PrintUsuarioRemision(
                    Convert.ToInt32(numero)).Tables[0].AsEnumerable().First()["Nombre"].ToString();
                printTicket.NoCaja = remisionRow["NoCaja"].ToString();
                printTicket.clienteRow = this.miBussinesCliente.ConsultaClienteNit(cliente).AsEnumerable().First();

                printTicket.tDetalle = this.miBussinesRemision.PrintProducto(Convert.ToInt32(numero), descto).Tables[0];

                if (cliente != "10" && cliente != "1000")
                {
                    printTicket.Puntos = true;
                    printTicket.DataPuntos = new double[] { Convert.ToDouble(printTicket.clienteRow["punto"]) };
                }

                printTicket.Pago = pago;

                printTicket.ImprimirRemisionVenta();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void PrintPos_(string numero, string cliente, bool descto, int pago)
        {
            try
            {
                var miBussinesEmpresa = new BussinesEmpresa();
                //var miBussinesUsuario = new BussinesUsuario();

                
                    var empresaRow = miBussinesEmpresa.PrintEmpresa().
                                     Tables[0].AsEnumerable().First();
                    var remisionRow = miBussinesRemision.PrintRemision(numero).
                                             Tables[0].AsEnumerable().First();
                    var usuarioRow = miBussinesUsuario.PrintUsuarioRemision(Convert.ToInt32(numero)).
                                                                    Tables[0].AsEnumerable().First();
                    var clienteRow = miBussinesCliente.PrintCliente(cliente).
                                                Tables[0].AsEnumerable().First();
                    var tDetalle = miBussinesRemision.PrintProducto(Convert.ToInt32(numero), descto).Tables[0];

                    Ticket ticket = new Ticket();
                    ticket.UseItem = false;

                    ticket.AddHeaderLine(empresaRow["Nombre"].ToString().ToUpper());
                    ticket.AddHeaderLine(empresaRow["Juridico"].ToString());
                    ticket.AddHeaderLine("NIT " + UseObject.InsertSeparatorMilMasDigito(empresaRow["Nit"].ToString()));
                    ticket.AddHeaderLine(empresaRow["Direccion"].ToString());
                    ticket.AddHeaderLine("Tels. " + empresaRow["Telefono"].ToString());
                    ticket.AddHeaderLine("REGIMEN " + UseObject.Split(empresaRow["Regimen"].ToString(), 5) +
                                         "      REMISIÓN");
                    ticket.AddHeaderLine("Fecha : " + Convert.ToDateTime(remisionRow["Fecha"]).ToShortDateString() +
                                         " Nro " + numero);
                    ticket.AddHeaderLine("Hora  : " + Convert.ToDateTime(remisionRow["Hora"]).ToShortTimeString() +
                                         " Caja  : " + remisionRow["NoCaja"].ToString());
                    if (!Convert.ToInt32(remisionRow["IdEstado"]).Equals(1))  // Estado : Crédito
                    {
                        ticket.AddHeaderLine(remisionRow["Estado"].ToString().ToUpper() + "  Fecha Limite : " +
                                             Convert.ToDateTime(remisionRow["FechaLimite"]).ToShortDateString());
                    }
                    ticket.AddHeaderLine("Cajero(a)  :  " + usuarioRow["Nombre"].ToString());
                    ticket.AddHeaderLine("===================================");
                    ticket.AddHeaderLine("CLIENTE : " + clienteRow["Nombre"].ToString());
                    ticket.AddHeaderLine("NIT     : " + UseObject.InsertSeparatorMilMasDigito(clienteRow["Nit"].ToString()));
                    ticket.AddHeaderLine("===================================");
                    ticket.AddHeaderLine("");

                    if (this.GraneroJhonRiosucio)
                    {
                        this.PrintDetail(tDetalle, ticket);
                    }
                    else
                    {
                        ticket.AddHeaderLine("COD.  DESCRIP.  CANT.  VENTA  TOTAL");
                        ticket.AddHeaderLine("");
                        foreach (DataRow dRow in tDetalle.Rows)
                        {
                            string product = dRow["Producto"].ToString();
                            if (product.Length > 30)
                            {
                                product = product.Substring(0, 30);
                            }
                            ticket.AddHeaderLine(dRow["Codigo"].ToString() + " " + product);
                            ticket.AddHeaderLine("              " + dRow["Cantidad"].ToString() + " x " + UseObject.InsertSeparatorMil(dRow["Valor_"].ToString()) +
                                                 "  " + UseObject.InsertSeparatorMil(dRow["Total_"].ToString()));
                        }
                    }
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("===================================");
                    ticket.AddHeaderLine("");

                    var total = tDetalle.AsEnumerable().Sum(d => d.Field<int>("Total_"));
                    ticket.AddHeaderLine("TOTAL     : " + UseObject.InsertSeparatorMil(total.ToString()));
                    if (Convert.ToInt32(remisionRow["IdEstado"]).Equals(1))
                    {
                        ticket.AddHeaderLine("EFECTIVO  : " + UseObject.InsertSeparatorMil(pago.ToString()));
                        ticket.AddHeaderLine("CAMBIO    : " + UseObject.InsertSeparatorMil((pago - total).ToString()));
                    }
                    else
                    {
                        if (Convert.ToInt32(remisionRow["IdEstado"]).Equals(2))
                        {
                            ticket.AddHeaderLine("EFECTIVO  : " + "0");
                            ticket.AddHeaderLine("CAMBIO    : " + "0");
                        }
                    }
                    ticket.AddHeaderLine("-----------------------------------");
                    ticket.AddHeaderLine("Software: DFPyme");
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("*GRACIAS POR SER NUESTROS CLIENTES*");
                    ticket.AddHeaderLine("");

                    //ticket.PrintTicket("IMPREPOS");
                    ticket.PrintTicket("Microsoft XPS Document Writer");

                    /*ticket.AddTotal("TOTAL     : ", UseObject.InsertSeparatorMil(total.ToString()));
                    if (Convert.ToInt32(remisionRow["IdEstado"]).Equals(1))
                    {
                        ticket.AddTotal("EFECTIVO  : ", UseObject.InsertSeparatorMil(pago.ToString()));
                        ticket.AddTotal("CAMBIO    : ", UseObject.InsertSeparatorMil((pago - total).ToString()));
                        var q = "CAMBIO    : " + UseObject.InsertSeparatorMil((pago - total).ToString());
                    }
                    else
                    {
                        ticket.AddTotal("EFECTIVO  : ", "0");
                        ticket.AddTotal("CAMBIO    : ", "0");
                    }
                    ticket.AddHeaderLine("===================================");  // Revisar
                    ticket.AddFooterLine(".");
                    ticket.AddFooterLine(".");
                    ticket.AddFooterLine("Software: DFPyme");
                    ticket.AddFooterLine(".");
                    ticket.AddFooterLine("*GRACIAS POR SER NUESTROS CLIENTES*");
                    ticket.AddFooterLine(".");
                    ticket.AddFooterLine(".");

                    ticket.PrintTicket("IMPREPOS");*/
                
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void PrintDetail(DataTable tDetalle, Ticket ticket)
        {
            //ticket.AddHeaderLine("CANT  DESCRIPCION           IMPORTE");
            ticket.AddHeaderLine("CANT  DESCRIPCION             TOTAL");
            ticket.AddHeaderLine("");
            foreach (DataRow dRow in tDetalle.Rows)
            {
                /* lstProducto.Add(new ProductoFacturaProveedor
                 {
                     Cantidad = Convert.ToDouble(dRow["Cantidad"]),
                     Valor = this.miBussinesProducto.ValorDeProducto(dRow["Codigo"].ToString())
                 });*/
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

        private void PrintPos_old(string numero, string cliente, bool descto, int pago)
        {
            try
            {
                var miBussinesEmpresa = new BussinesEmpresa();
                //var miBussinesUsuario = new BussinesUsuario();

                var empresaRow = miBussinesEmpresa.PrintEmpresa().
                                 Tables[0].AsEnumerable().First();
                var remisionRow = miBussinesRemision.PrintRemision(numero).
                                         Tables[0].AsEnumerable().First();
                var usuarioRow = miBussinesUsuario.PrintUsuarioRemision(Convert.ToInt32(numero)).
                                                                Tables[0].AsEnumerable().First();
                var clienteRow = miBussinesCliente.PrintCliente(cliente).
                                            Tables[0].AsEnumerable().First();
                var tDetalle = miBussinesRemision.PrintProducto(Convert.ToInt32(numero), descto).Tables[0];

                Ticket ticket = new Ticket();

                ticket.AddHeaderLine(empresaRow["Nombre"].ToString().ToUpper());
                ticket.AddHeaderLine(empresaRow["Juridico"].ToString());
                ticket.AddHeaderLine("NIT " + UseObject.InsertSeparatorMilMasDigito(empresaRow["Nit"].ToString()));
                ticket.AddHeaderLine(empresaRow["Direccion"].ToString());
                ticket.AddHeaderLine("Tels. " + empresaRow["Telefono"].ToString());
                ticket.AddHeaderLine("REGIMEN " + UseObject.Split(empresaRow["Regimen"].ToString(), 5) +
                                     "      REMISIÓN");
                ticket.AddHeaderLine("Fecha : " + Convert.ToDateTime(remisionRow["Fecha"]).ToShortDateString() +
                                     " Nro " + numero);
                ticket.AddHeaderLine("Hora  : " + Convert.ToDateTime(remisionRow["Hora"]).ToShortTimeString() +
                                     " Caja  : " + remisionRow["NoCaja"].ToString());
                ticket.AddHeaderLine(remisionRow["Estado"].ToString().ToUpper() + "  Fecha Limite : " +
                                     Convert.ToDateTime(remisionRow["FechaLimite"]).ToShortTimeString());
                ticket.AddHeaderLine("Cajero(a)  :  " + usuarioRow["Nombre"].ToString());
                ticket.AddHeaderLine("===================================");
                ticket.AddHeaderLine("CLIENTE : " + clienteRow["Nombre"].ToString());
                ticket.AddHeaderLine("NIT     : " + UseObject.InsertSeparatorMilMasDigito(clienteRow["Nit"].ToString()));

                foreach (DataRow dRow in tDetalle.Rows)
                {
                    ticket.AddItem("",
                                   "COD:" + dRow["Codigo"].ToString() +
                                   " v/u " + UseObject.InsertSeparatorMil(dRow["Valor_"].ToString()).ToString(),
                                   "");
                    ticket.AddItem(dRow["Cantidad"].ToString(),
                                   dRow["Producto"].ToString(),
                                   UseObject.InsertSeparatorMil(dRow["Total_"].ToString()));
                    ticket.AddItem("", "", "");

                    /*var n = dRow["Cantidad"].ToString();
                    var o = dRow["Producto"].ToString();
                    var p = UseObject.InsertSeparatorMil(dRow["Total_"].ToString());*/
                }

                var total = tDetalle.AsEnumerable().Sum(d => d.Field<int>("Total_"));

                ticket.AddTotal("TOTAL     : ", UseObject.InsertSeparatorMil(total.ToString()));
                if (Convert.ToInt32(remisionRow["IdEstado"]).Equals(1))
                {
                    ticket.AddTotal("EFECTIVO  : ", UseObject.InsertSeparatorMil(pago.ToString()));
                    ticket.AddTotal("CAMBIO    : ", UseObject.InsertSeparatorMil((pago - total).ToString()));
                    var q = "CAMBIO    : " + UseObject.InsertSeparatorMil((pago - total).ToString());
                }
                else
                {
                    ticket.AddTotal("EFECTIVO  : ", "0");
                    ticket.AddTotal("CAMBIO    : ", "0");
                }
                ticket.AddHeaderLine("===================================");  // Revisar
                ticket.AddFooterLine(".");
                ticket.AddFooterLine(".");
                ticket.AddFooterLine("Software: DFPyme");
                //ticket.AddFooterLine("Soluciones Tecnológicas A&C.");
                //ticket.AddFooterLine("Cel. 3128068807");
                ticket.AddFooterLine(".");
                ticket.AddFooterLine("*GRACIAS POR SER NUESTROS CLIENTES*");
                ticket.AddFooterLine(".");
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