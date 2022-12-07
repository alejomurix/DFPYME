using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CustomControl;
using BussinesLayer.Clases;
using DTO.Clases;
using Utilities;
using Microsoft.Reporting.WinForms;

namespace Aplicacion.Compras.IngresarCompra
{
    public partial class FrmConsultaCompraSimple : Form
    {
        private bool MedidaCantidad;

        private int CodProveedor;

        private DateTime Fecha1;

        private DateTime Fecha2;

        private int RowIndex;

        private int RowMax;

        private long TotalRow;

        private long Paginas;

        private int CurrentPage;

        private int Iterador;


        private BussinesCompraSimple miBussinesCompraSimple;

        private BussinesProveedor miBussinesProveedor;

        private BussinesEmpresa miBussinesEmpresa;

        private BussinesProducto miBussinesProducto;

        private BussinesColor miBussinesColor;

        private BussinesInventario miBussinesInventario;

        private DataTable tResumen;


        public FrmConsultaCompraSimple()
        {
            InitializeComponent();

            this.CodProveedor = 0;
            this.RowIndex = 0;
            this.RowMax = 9;
            this.Iterador = 0;

            this.miBussinesCompraSimple = new BussinesCompraSimple();
            this.miBussinesProveedor = new BussinesProveedor();
            this.miBussinesEmpresa = new BussinesEmpresa();
            this.miBussinesProducto = new BussinesProducto();
            this.miBussinesColor = new BussinesColor();
            this.miBussinesInventario = new BussinesInventario();

            try
            {
                this.MedidaCantidad = Convert.ToBoolean(AppConfiguracion.ValorSeccion("medidaCantidadCompraSimple"));
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void FrmConsultaCompraSimple_Load(object sender, EventArgs e)
        {
            try
            {
                if (this.MedidaCantidad)
                {
                    this.Cantidad.HeaderText = "Cant. Kg";
                }
                else
                {
                    this.Cantidad.HeaderText = "Cant. @";
                }

                CompletaEventos.Completa += new CompletaEventos.CompletaAccion(CompletaEventos_Completo);
                CompletaEventos.Completaz += new CompletaEventos.CompletaAccionz(CompletaEventos_Completaz);

                this.cbCriterio.DataSource = new List<Inventario.Producto.Criterio>
                {
                    new Inventario.Producto.Criterio
                    {
                        Id = 1,
                        Nombre = "TODAS"
                    },
                    new Inventario.Producto.Criterio
                    {
                        Id = 2,
                        Nombre = "PROVEEDOR"
                    }
                };

                this.cbFecha.DataSource = new List<Inventario.Producto.Criterio>
                {
                    new Inventario.Producto.Criterio
                    {
                        Id = 1,
                        Nombre = "FECHA"
                    },
                    new Inventario.Producto.Criterio
                    {
                        Id = 2,
                        Nombre = "PERIODO"
                    }
                };

                this.dgvCompras.AutoGenerateColumns = false;
                this.dgvProductos.AutoGenerateColumns = false;
                this.dgvDescuentos.AutoGenerateColumns = false;

                this.CurrentPage = 1;
                this.dgvCompras.DataSource = this.miBussinesCompraSimple.Compras(DateTime.Now, RowIndex, RowMax);
                this.TotalRow = this.miBussinesCompraSimple.CountCompras(DateTime.Now);
                CalcularPaginas();
                ColorearTodos();
                if (this.dgvCompras.Rows.Count > 0)
                {
                    this.dgvCompras_CellClick(this.dgvCompras, null);
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void FrmConsultaCompraSimple_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.F2))
            {
                this.tsBtnAbono_Click(this.tsBtnAbono, new EventArgs());
            }
            else
            {
                if (e.KeyData.Equals(Keys.F3))
                {
                    this.tsBtnAbonoGeneral_Click(this.tsBtnAbonoGeneral, new EventArgs());
                }
                else
                {
                    if (e.KeyData.Equals(Keys.F4))
                    {
                        this.tsBtnImprimirDocumento_Click(this.tsBtnImprimirDocumento, new EventArgs());
                    }
                    else
                    {
                        if (e.KeyData.Equals(Keys.F5))
                        {
                            this.tsBtnImprimirConsulta_Click(this.tsBtnImprimirConsulta, new EventArgs());
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
            }
        }

        private void tsBtnAbono_Click(object sender, EventArgs e)
        {
            if (this.dgvCompras.Rows.Count > 0)
            {
                DataGridViewRow gRow = this.dgvCompras.CurrentRow;
                if (Convert.ToInt32(gRow.Cells["Saldo"].Value) > 0)
                {
                    var frmPago = new Pago.FrmCancelarCompraSimple();
                    frmPago.IdCompra = Convert.ToInt32(gRow.Cells["Id"].Value);
                    frmPago.Nit = gRow.Cells["Cedula"].Value.ToString();
                    frmPago.txtTotal.Text = UseObject.InsertSeparatorMil(gRow.Cells["Saldo"].Value.ToString());
                    frmPago.ShowDialog();
                }
                else
                {
                    OptionPane.MessageInformation("La compra se encuentra paga.");
                }
            }
            else
            {
                OptionPane.MessageInformation("No hay registros para pagar.");
            }
        }

        private void tsBtnAbonoGeneral_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvCompras.Rows.Count > 0)
                {
                    var gRow = this.dgvCompras.CurrentRow;
                    var cartera = this.miBussinesCompraSimple.Cartera(Convert.ToInt32(gRow.Cells["CodigoP"].Value));
                    if (cartera.Count > 0)
                    {
                        var frmPago = new Pago.FrmAbonoGeneralCompra();
                        frmPago.CodigoProveedor = this.CodProveedor;
                        frmPago.txtNit.Text = UseObject.InsertSeparatorMil(gRow.Cells["Cedula"].Value.ToString());
                        frmPago.txtProveedor.Text = gRow.Cells["Proveedor"].Value.ToString();
                        frmPago.Cartera = cartera;
                        frmPago.ShowDialog();
                    }
                    else
                    {
                        OptionPane.MessageInformation("El proveedor no tiene saldo pendiente.");
                    }
                }
                else
                {
                    OptionPane.MessageInformation("No hay registros para pagar.");
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void tsBtnImprimirDocumento_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow gridRow = this.dgvCompras.CurrentRow;

                var empresaRow = miBussinesEmpresa.PrintEmpresa().
                                     Tables[0].AsEnumerable().First();

                Ticket ticket = new Ticket();
                ticket.UseItem = false;

                ticket.AddHeaderLine(empresaRow["Nombre"].ToString().ToUpper());
                ticket.AddHeaderLine(empresaRow["Juridico"].ToString());
                ticket.AddHeaderLine("NIT " + UseObject.InsertSeparatorMilMasDigito(empresaRow["Nit"].ToString()));
                ticket.AddHeaderLine(empresaRow["Direccion"].ToString());
                ticket.AddHeaderLine("Tels. " + empresaRow["Telefono"].ToString());
                ticket.AddHeaderLine("Recibo de compra Nro. " + gridRow.Cells["Id"].Value.ToString());
                ticket.AddHeaderLine("Fecha : " + gridRow.Cells["Fecha"].Value.ToString());


                ticket.AddHeaderLine("===================================");
                ticket.AddHeaderLine("Proveedor : " + gridRow.Cells["Proveedor"].Value.ToString());
                ticket.AddHeaderLine("C.C.    : " + UseObject.InsertSeparatorMilMasDigito(gridRow.Cells["Cedula"].Value.ToString()));
                ticket.AddHeaderLine("===================================");
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("");

                ticket.AddHeaderLine("DESCRIP.       CANT.  COMPRA  TOTAL");
                ticket.AddHeaderLine("___________________________________");
                ticket.AddHeaderLine("");
                foreach (DataGridViewRow gRowProd in this.dgvProductos.Rows)
                {
                    string product = gRowProd.Cells["Producto"].Value.ToString();
                    if (product.Length > 30)
                    {
                        product = product.Substring(0, 30);
                    }
                    ticket.AddHeaderLine(product);
                    ticket.AddHeaderLine("              " + gRowProd.Cells["Cantidad"].Value.ToString() + "  "
                                                          + UseObject.InsertSeparatorMil(gRowProd.Cells["Precio"].Value.ToString()) + " "
                                                          + UseObject.InsertSeparatorMil(Convert.ToInt32(Convert.ToDouble(gRowProd.Cells["Cantidad"].Value) *
                                                                                                         Convert.ToInt32(gRowProd.Cells["Precio"].Value)).ToString()));
                }
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("------------DESCUENTOS-------------");
                ticket.AddHeaderLine("");
                int totalDesctos = 0;
                foreach (DataGridViewRow gRowDescto in this.dgvDescuentos.Rows)
                {
                    ticket.AddHeaderLine(gRowDescto.Cells["Nombre"].Value.ToString() + "    : "
                        + UseObject.InsertSeparatorMil(gRowDescto.Cells["ValorDescuento"].Value.ToString()));
                    totalDesctos += Convert.ToInt32(gRowDescto.Cells["ValorDescuento"].Value);
                }
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("--------------RESUMEN--------------");
                ticket.AddHeaderLine("");


                ticket.AddHeaderLine("SUB-TOTAL : " + UseObject.InsertSeparatorMil(gridRow.Cells["SubTotal"].Value.ToString()));
                ticket.AddHeaderLine("DESCTOS   : " + UseObject.InsertSeparatorMil(totalDesctos.ToString()));
                ticket.AddHeaderLine("TOTAL     : " +
                    UseObject.InsertSeparatorMil((Convert.ToInt32(gridRow.Cells["SubTotal"].Value) - totalDesctos).ToString()));

                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("-----------------------------------");
                ticket.AddHeaderLine("Software: Digital Fact Pyme");
                ticket.AddHeaderLine("Soluciones Tecnológicas A&C.");
                ticket.AddHeaderLine("solucionestecnologicasayc@gmail.com");
                ticket.AddHeaderLine("");

                ticket.PrintTicket("IMPREPOS");
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void tsBtnImprimirConsulta_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvCompras.RowCount != 0)
                {
                    DialogResult rta = DialogResult.Yes;
                   // if (!Convert.ToBoolean(AppConfiguracion.ValorSeccion("printCarteraProveedor")))
                   // {
                        FrmPrint frmPrint_ = new FrmPrint();
                        frmPrint_.StringCaption = "Compras";
                        frmPrint_.StringMessage = "Impresión de compras a proveedores";
                        rta = frmPrint_.ShowDialog();
                 //   }

                    if (!rta.Equals(DialogResult.Cancel))
                    {
                        var tabla = new DataTable();
                        switch (this.Iterador)
                        {
                            case 0:
                                {
                                    tabla = this.miBussinesCompraSimple.Compras(DateTime.Now);
                                    break;
                                }
                            case 1:
                                {
                                    tabla = this.miBussinesCompraSimple.Compras(this.Fecha1);
                                    break;
                                }
                            case 2:
                                {
                                    tabla = this.miBussinesCompraSimple.Compras(this.Fecha1, this.Fecha2);
                                    break;
                                }
                            case 3:
                                {
                                    tabla = this.miBussinesCompraSimple.Compras(this.CodProveedor, this.Fecha1);
                                    break;
                                }
                            case 4:
                                {
                                    tabla = this.miBussinesCompraSimple.Compras(this.CodProveedor, this.Fecha1, this.Fecha2);
                                    break;
                                }
                        }

                        var frmPrint = new FrmPrintCompra();
                        //frmPrint.Fecha = DateTime.Now;
                        frmPrint.Reporte = "INFORME COMPRAS A PROVEEDORES.";
                        if (Convert.ToInt32(this.cbFecha.SelectedValue).Equals(1))
                        {
                            frmPrint.Consulta = "Fecha : " + this.Fecha1.ToShortDateString();
                        }
                        else
                        {
                            frmPrint.Consulta = "Periodo : " + this.Fecha1.ToShortDateString() + " a " + this.Fecha2.ToShortDateString();
                        }
                        

                        frmPrint.Tamanio = Imprimir.TamanioPapel.CartaHorizontal;
                        frmPrint.Tabla = tabla;
                        frmPrint.ReportPath = AppConfiguracion.ValorSeccion("report") + @"\reports\ConsultaCompraSimple.rdlc";
                       // frmPrint.ReportPath = 
                      //  @"C:\Users\alejo\Documents\Visual Studio 2010\Projects\DFPYME\DFPYME\Aplicacion\Compras\Reportes\ConsultaCompraSimple.rdlc";

                            if (rta.Equals(DialogResult.No))
                            {
                                frmPrint.ShowDialog();
                            }
                            else
                            {
                                Imprimir print = new Imprimir();
                                print.Report = frmPrint.Load_();
                                print.Print(Imprimir.TamanioPapel.CartaHorizontal);
                                frmPrint.ResetReport();
                            }
                        //}
                    }
                }
                else
                {
                    OptionPane.MessageInformation("No se ha cargado ninguna consulta para el informe.");
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void tsSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void cbCriterio_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(this.cbCriterio.SelectedValue);
            if (id == 1)
            {
                this.txtCodigo.Enabled = false;
                this.btnBuscarCodigo.Enabled = false;
            }
            else
            {
                this.txtCodigo.Enabled = true;
                this.btnBuscarCodigo.Enabled = true;
            }
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                var frmBeneficio = new Beneficiario.FrmBeneficio();
                frmBeneficio.tcBeneficio.SelectTab(1);
                frmBeneficio.txtConsulta.Text = this.txtCodigo.Text;
                frmBeneficio.ShowDialog();

            }
        }

        private void btnBuscarCodigo_Click(object sender, EventArgs e)
        {
            var frmBeneficio = new Beneficiario.FrmBeneficio();
            frmBeneficio.tcBeneficio.SelectTab(1);
            //frmBeneficio.txtConsulta.Text = this.txtCodigo.Text;
           // frmBeneficio.Search = true;
            frmBeneficio.ShowDialog();

          /*  var formProveedor = new Proveedor.frmProveedor();
            formProveedor.Extension = true;
            formProveedor.tcProveedor.SelectTab(1);
            formProveedor.ShowDialog();*/
        }

        private void cbFecha_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(this.cbFecha.SelectedValue);
            if (id == 1)
            {
                this.dtpFecha2.Enabled = false;
            }
            else
            {
                this.dtpFecha1.Enabled = true;
                this.dtpFecha2.Enabled = true;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtCodigo.Text != "")
                {
                    var proveedor = this.miBussinesProveedor.ConsultarPrveedorBasico(this.txtCodigo.Text);
                    this.CodProveedor = proveedor.CodigoInternoProveedor;
                }

                this.RowIndex = 0;
                this.CurrentPage = 1;
                this.Fecha1 = this.dtpFecha1.Value;
                this.Fecha2 = this.dtpFecha2.Value;

                var id = Convert.ToInt32(this.cbCriterio.SelectedValue);
                var idFecha = Convert.ToInt32(this.cbFecha.SelectedValue);
                if (id == 1)  // TODAS
                {
                    if (idFecha == 1)  // FECHA
                    {
                        Iterador = 1;
                        this.dgvCompras.DataSource =
                            this.miBussinesCompraSimple.Compras(this.Fecha1, this.RowIndex, this.RowMax);
                        this.TotalRow = this.miBussinesCompraSimple.CountCompras(this.Fecha1);
                    }
                    else  // PERIODO
                    {
                        Iterador = 2;
                        this.dgvCompras.DataSource =
                            this.miBussinesCompraSimple.Compras(this.Fecha1, this.Fecha2, this.RowIndex, this.RowMax);
                        this.TotalRow = this.miBussinesCompraSimple.CountCompras(this.Fecha1, this.Fecha2);
                    }
                }
                else  // PROVEEDOR
                {
                    if (idFecha == 1)  // FECHA
                    {
                        Iterador = 3;
                        this.dgvCompras.DataSource =
                            this.miBussinesCompraSimple.Compras(this.CodProveedor, this.Fecha1, this.RowIndex, this.RowMax);
                        this.TotalRow = this.miBussinesCompraSimple.CountCompras(this.CodProveedor, this.Fecha1);
                    }
                    else  // PERIODO
                    {
                        Iterador = 4;
                        this.dgvCompras.DataSource =
                            this.miBussinesCompraSimple.Compras(this.CodProveedor, this.Fecha1, this.Fecha2, this.RowIndex, this.RowMax);
                        this.TotalRow = this.miBussinesCompraSimple.CountCompras(this.CodProveedor, this.Fecha1, this.Fecha2);
                    }
                }
                ResumenCompras();
                ResumenDescuentos();
                CalcularPaginas();
                ColorearTodos();
                if (this.dgvCompras.Rows.Count.Equals(0))
                {
                    this.dgvProductos.DataSource = null;
                    this.dgvDescuentos.DataSource = null;
                    OptionPane.MessageInformation("No se encontraron registros de la consulta.");
                }
                else
                {
                    this.dgvCompras_CellClick(this.dgvCompras, null);
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }



        private void dgvCompras_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.dgvProductos.DataSource =
                    this.miBussinesCompraSimple.ProductosDeCompra(Convert.ToInt32(this.dgvCompras.CurrentRow.Cells["Id"].Value));
                this.dgvDescuentos.DataSource =
                    this.miBussinesCompraSimple.Descuentos(Convert.ToInt32(this.dgvCompras.CurrentRow.Cells["Id"].Value));
                ColorearGridProducto();
                ColorearGridDescuento();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void tsEditarCompra_Click(object sender, EventArgs e)
        {
            if (this.dgvCompras.RowCount > 0)
            {

            }
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            if (this.CurrentPage > 1)
            {
                var paginaActual = this.CurrentPage;
                for (int i = paginaActual; i > 1; i--)
                {
                    this.RowIndex = this.RowIndex - this.RowMax;
                    this.CurrentPage--;
                }
                try
                {
                    switch (this.Iterador)
                    {
                        case 0:
                            {
                                this.dgvCompras.DataSource =
                                    this.miBussinesCompraSimple.Compras(DateTime.Now, this.RowIndex, this.RowMax);
                                break;
                            }
                        case 1:
                            {
                                this.dgvCompras.DataSource =
                                    this.miBussinesCompraSimple.Compras(this.Fecha1, this.RowIndex, this.RowMax);
                                break;
                            }
                        case 2:
                            {
                                this.dgvCompras.DataSource =
                                    this.miBussinesCompraSimple.Compras(this.Fecha1, this.Fecha2, this.RowIndex, this.RowMax);
                                break;
                            }
                        case 3:
                            {
                                this.dgvCompras.DataSource =
                                    this.miBussinesCompraSimple.Compras(this.CodProveedor, this.Fecha1, this.RowIndex, this.RowMax);
                                break;
                            }
                        case 4:
                            {
                                this.dgvCompras.DataSource =
                                    this.miBussinesCompraSimple.Compras(this.CodProveedor, this.Fecha1, this.Fecha2, this.RowIndex, this.RowMax);
                                break;
                            }
                    }
                    ColorearTodos();
                    this.lblStatusFactura.Text = this.CurrentPage + " / " + this.Paginas;
                    this.dgvCompras_CellClick(this.dgvCompras, null);
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (this.CurrentPage > 1)
            {
                this.RowIndex = this.RowIndex - this.RowMax;
                if (this.RowIndex <= 0)
                    this.RowIndex = 0;
                try
                {
                    switch (this.Iterador)
                    {
                        case 0:
                            {
                                this.dgvCompras.DataSource =
                                    this.miBussinesCompraSimple.Compras(DateTime.Now, this.RowIndex, this.RowMax);
                                break;
                            }
                        case 1:
                            {
                                this.dgvCompras.DataSource =
                                    this.miBussinesCompraSimple.Compras(this.Fecha1, this.RowIndex, this.RowMax);
                                break;
                            }
                        case 2:
                            {
                                this.dgvCompras.DataSource =
                                    this.miBussinesCompraSimple.Compras(this.Fecha1, this.Fecha2, this.RowIndex, this.RowMax);
                                break;
                            }
                        case 3:
                            {
                                this.dgvCompras.DataSource =
                                    this.miBussinesCompraSimple.Compras(this.CodProveedor, this.Fecha1, this.RowIndex, this.RowMax);
                                break;
                            }
                        case 4:
                            {
                                this.dgvCompras.DataSource =
                                    this.miBussinesCompraSimple.Compras(this.CodProveedor, this.Fecha1, this.Fecha2, this.RowIndex, this.RowMax);
                                break;
                            }
                    }
                    ColorearTodos();
                    this.CurrentPage--;
                    this.lblStatusFactura.Text = this.CurrentPage + " / " + this.Paginas;
                    this.dgvCompras_CellClick(this.dgvCompras, null);
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (this.CurrentPage < this.Paginas)
            {
                this.RowIndex = this.RowIndex + this.RowMax;
                try
                {
                    switch (this.Iterador)
                    {
                        case 0:
                            {
                                this.dgvCompras.DataSource =
                                    this.miBussinesCompraSimple.Compras(DateTime.Now, this.RowIndex, this.RowMax);
                                break;
                            }
                        case 1:
                            {
                                this.dgvCompras.DataSource =
                                    this.miBussinesCompraSimple.Compras(this.Fecha1, this.RowIndex, this.RowMax);
                                break;
                            }
                        case 2:
                            {
                                this.dgvCompras.DataSource =
                                    this.miBussinesCompraSimple.Compras(this.Fecha1, this.Fecha2, this.RowIndex, this.RowMax);
                                break;
                            }
                        case 3:
                            {
                                this.dgvCompras.DataSource =
                                    this.miBussinesCompraSimple.Compras(this.CodProveedor, this.Fecha1, this.RowIndex, this.RowMax);
                                break;
                            }
                        case 4:
                            {
                                this.dgvCompras.DataSource =
                                    this.miBussinesCompraSimple.Compras(this.CodProveedor, this.Fecha1, this.Fecha2, this.RowIndex, this.RowMax);
                                break;
                            }
                    }
                    ColorearTodos();
                    this.CurrentPage++;
                    this.lblStatusFactura.Text = this.CurrentPage + " / " + this.Paginas;
                    this.dgvCompras_CellClick(this.dgvCompras, null);
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void btnFin_Click(object sender, EventArgs e)
        {
            if (this.CurrentPage < this.Paginas)
            {
                var paginaActual = this.CurrentPage;
                for (int i = paginaActual; i < Paginas; i++)
                {
                    this.RowIndex = this.RowIndex + this.RowMax;
                    this.CurrentPage++;
                }
                try
                {
                    switch (this.Iterador)
                    {
                        case 0:
                            {
                                this.dgvCompras.DataSource =
                                    this.miBussinesCompraSimple.Compras(DateTime.Now, this.RowIndex, this.RowMax);
                                break;
                            }
                        case 1:
                            {
                                this.dgvCompras.DataSource =
                                    this.miBussinesCompraSimple.Compras(this.Fecha1, this.RowIndex, this.RowMax);
                                break;
                            }
                        case 2:
                            {
                                this.dgvCompras.DataSource =
                                    this.miBussinesCompraSimple.Compras(this.Fecha1, this.Fecha2, this.RowIndex, this.RowMax);
                                break;
                            }
                        case 3:
                            {
                                this.dgvCompras.DataSource =
                                    this.miBussinesCompraSimple.Compras(this.CodProveedor, this.Fecha1, this.RowIndex, this.RowMax);
                                break;
                            }
                        case 4:
                            {
                                this.dgvCompras.DataSource =
                                    this.miBussinesCompraSimple.Compras(this.CodProveedor, this.Fecha1, this.Fecha2, this.RowIndex, this.RowMax);
                                break;
                            }
                    }
                    ColorearTodos();
                    this.lblStatusFactura.Text = this.CurrentPage + " / " + this.Paginas;
                    this.dgvCompras_CellClick(this.dgvCompras, null);
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void tsBtnAgregarProducto_Click(object sender, EventArgs e)
        {
            if (this.dgvCompras.RowCount > 0)
            {
                var frmAgregarProducto = new FrmAgregarProductoCompraSimple();
                frmAgregarProducto.IdCompra = Convert.ToInt32(this.dgvCompras.CurrentRow.Cells["Id"].Value);
                frmAgregarProducto.ShowDialog();
            }
        }

        private void tsEditarProducto_Click(object sender, EventArgs e)
        {
            if (this.dgvProductos.RowCount > 0)
            {
                DataGridViewRow gRow = this.dgvProductos.CurrentRow;
                var frmEditarProducto = new FrmEditarProductoCompraSimple();
                frmEditarProducto.IdCompra = Convert.ToInt32(this.dgvCompras.CurrentRow.Cells["Id"].Value);
                frmEditarProducto.IdProducto = Convert.ToInt32(gRow.Cells["IdProducto"].Value);
                frmEditarProducto.CodigoProducto = gRow.Cells["Codigo"].Value.ToString();
                frmEditarProducto.Cantidad = Convert.ToDouble(gRow.Cells["Cantidad"].Value);
                frmEditarProducto.Proveedor.NitProveedor = this.dgvCompras.CurrentRow.Cells["Cedula"].Value.ToString();
                frmEditarProducto.Proveedor.NombreProveedor = this.dgvCompras.CurrentRow.Cells["Proveedor"].Value.ToString();
                frmEditarProducto.txtProducto.Text = gRow.Cells["Producto"].Value.ToString();
                frmEditarProducto.txtPrecio.Text = gRow.Cells["Precio"].Value.ToString();
                frmEditarProducto.txtCantidad.Text = UseObject.InsertSeparatorMil(gRow.Cells["Cantidad"].Value.ToString());
                frmEditarProducto.txtValor.Text = UseObject.InsertSeparatorMil(gRow.Cells["TotalProducto"].Value.ToString());
                frmEditarProducto.ShowDialog();
            }
            else
            {
                OptionPane.MessageInformation("No hay registros para editar.");
            }
        }

        private void tsBtnEliminarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvProductos.RowCount > 0)
                {
                    DialogResult rta = MessageBox.Show("¿Está seguro(a) de eliminar el registro de producto?", "Compras", 
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (rta.Equals(DialogResult.Yes))
                    {
                        var producto = new ProductoFacturaProveedor();
                        producto.Inventario.CodigoProducto = this.dgvProductos.CurrentRow.Cells["Codigo"].Value.ToString();
                        producto.Inventario.IdMedida = this.miBussinesProducto.ProductoMedida(producto.Inventario.CodigoProducto).IdValorUnidadMedida;
                        var tColores = this.miBussinesColor.ColoresDeProducto(producto.Producto.CodigoInternoProducto, producto.Inventario.IdMedida);
                        if (tColores.Rows.Count > 0)
                        {
                            var sRow = (from d in tColores.AsEnumerable() select d).Single();
                            producto.Inventario.IdColor = Convert.ToInt32(sRow["idcolor"]);
                        }
                        else
                        {
                            producto.Inventario.IdColor = 0;
                        }
                        producto.Inventario.Cantidad = Convert.ToDouble(this.dgvProductos.CurrentRow.Cells["Cantidad"].Value);
                        this.miBussinesCompraSimple.EliminarProducto(Convert.ToInt32(this.dgvProductos.CurrentRow.Cells["IdProducto"].Value));
                        this.miBussinesInventario.ActualizarInventario(producto.Inventario, true);
                        int diferencia = this.miBussinesCompraSimple.AjustarCompraPagos(Convert.ToInt32(this.dgvCompras.CurrentRow.Cells["Id"].Value));
                        OptionPane.MessageInformation("El producto se eliminó con éxito.");
                        if (diferencia > 0)
                        {
                            Print(diferencia);
                        }
                        this.dgvCompras_CellClick(this.dgvCompras, null);
                    }
                }
                else
                {
                    OptionPane.MessageInformation("No hay registros para eliminar.");
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void tsBtnImprimirResumenDescuento_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dataResumen = new DataTable();
                switch (this.Iterador)
                {
                    case 0:
                        {
                            dataResumen = this.miBussinesCompraSimple.ResumenDescuentos(DateTime.Now);
                            break;
                        }
                    case 1:
                        {
                            dataResumen = this.miBussinesCompraSimple.ResumenDescuentos(this.Fecha1);
                            break;
                        }
                    case 2:
                        {
                            dataResumen = this.miBussinesCompraSimple.ResumenDescuentos(this.Fecha1, this.Fecha2);
                            break;
                        }
                    case 3:
                        {
                            dataResumen = this.miBussinesCompraSimple.ResumenDescuentos(this.CodProveedor, this.Fecha1);
                            break;
                        }
                    case 4:
                        {
                            dataResumen = this.miBussinesCompraSimple.ResumenDescuentos(this.CodProveedor, this.Fecha1, this.Fecha2);
                            break;
                        }
                }
                if (dataResumen.Rows.Count > 0)
                {
                    var empresaRow = miBussinesEmpresa.PrintEmpresa().
                                         Tables[0].AsEnumerable().First();

                    Ticket ticket = new Ticket();
                    ticket.UseItem = false;

                    ticket.AddHeaderLine(empresaRow["Nombre"].ToString().ToUpper());
                    ticket.AddHeaderLine(empresaRow["Juridico"].ToString());
                    ticket.AddHeaderLine("NIT " + UseObject.InsertSeparatorMilMasDigito(empresaRow["Nit"].ToString()));
                    ticket.AddHeaderLine(empresaRow["Direccion"].ToString());
                    ticket.AddHeaderLine("Tels. " + empresaRow["Telefono"].ToString());
                    ticket.AddHeaderLine("RESUMEN DE DESCUENTOS");
                    ticket.AddHeaderLine("Fecha : " + DateTime.Now.ToShortDateString() + "  " +
                                                      DateTime.Now.ToShortTimeString());
                    if (Convert.ToInt32(this.cbFecha.SelectedValue).Equals(1))
                    {
                        ticket.AddHeaderLine("Consulta fecha : " + this.Fecha1.ToShortDateString());
                    }
                    else
                    {
                        ticket.AddHeaderLine("Consulta periodo : " + this.Fecha1.ToShortDateString() +
                                                             " a " + this.Fecha2.ToShortDateString());
                    }
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("===================================");
                    foreach (DataRow rDescto in dataResumen.Rows)
                    {
                        ticket.AddHeaderLine(rDescto["nombre"].ToString() + "    : "
                            + UseObject.InsertSeparatorMil(rDescto["valor"].ToString()));
                    }
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("-----------------------------------");
                    ticket.AddHeaderLine("Software: Digital Fact Pyme");
                    ticket.AddHeaderLine("Soluciones Tecnológicas A&C.");
                    ticket.AddHeaderLine("solucionestecnologicasayc@gmail.com");
                    ticket.AddHeaderLine("");

                    ticket.PrintTicket("IMPREPOS");
                }
                else
                {
                    OptionPane.MessageInformation("No hay registros para imprimir");
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void tsBtnAgregarDescuento_Click(object sender, EventArgs e)
        {
            if (this.dgvCompras.RowCount > 0)
            {
                DataGridViewRow gRow = this.dgvCompras.CurrentRow;
                var frmAgregarDescto = new FrmAgregarDescuentoCompraSimple();
                frmAgregarDescto.IdCompra = Convert.ToInt32(gRow.Cells["Id"].Value);
                frmAgregarDescto.Proveedor.NitProveedor = gRow.Cells["Cedula"].Value.ToString();
                frmAgregarDescto.Proveedor.NombreProveedor = gRow.Cells["Proveedor"].Value.ToString();
                frmAgregarDescto.ShowDialog();
            }
        }

        private void tsEditarDescuento_Click(object sender, EventArgs e)
        {
            if (this.dgvDescuentos.RowCount > 0)
            {
                DataGridViewRow gRow = this.dgvDescuentos.CurrentRow;
                var frmEditarProducto = new FrmEditarDescuentoCompraSimple();
                frmEditarProducto.IdCompra = Convert.ToInt32(this.dgvCompras.CurrentRow.Cells["Id"].Value);
                frmEditarProducto.IdDescuento = Convert.ToInt32(gRow.Cells["IdDescuento"].Value);
                frmEditarProducto.Proveedor.NitProveedor = this.dgvCompras.CurrentRow.Cells["Cedula"].Value.ToString();
                frmEditarProducto.Proveedor.NombreProveedor = this.dgvCompras.CurrentRow.Cells["Proveedor"].Value.ToString();
                frmEditarProducto.txtDescuento.Text = gRow.Cells["Nombre"].Value.ToString();
                frmEditarProducto.txtValor.Text = UseObject.InsertSeparatorMil(gRow.Cells["ValorDescuento"].Value.ToString());
                frmEditarProducto.ShowDialog();
            }
            else
            {
                OptionPane.MessageInformation("No hay registros para editar.");
            }
        }

        private void tsBtnEliminarDescuento_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvDescuentos.RowCount > 0)
                {
                    DialogResult rta = MessageBox.Show("¿Está seguro(a) de eliminar el registro de descuento?", "Compras",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (rta.Equals(DialogResult.Yes))
                    {
                        this.miBussinesCompraSimple.EliminarDescuento(Convert.ToInt32(this.dgvDescuentos.CurrentRow.Cells["IdDescuento"].Value));
                        int diferencia = this.miBussinesCompraSimple.AjustarCompraPagos(Convert.ToInt32(this.dgvCompras.CurrentRow.Cells["Id"].Value));
                        OptionPane.MessageInformation("El descuento se eliminó con éxito.");
                        if (diferencia > 0)
                        {
                            Print(diferencia);
                        }
                        this.dgvCompras_CellClick(this.dgvCompras, null);
                    }
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void tsBtnImprimirResumen_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvResumen.Rows.Count > 0)
                {
                    var empresaRow = miBussinesEmpresa.PrintEmpresa().
                                         Tables[0].AsEnumerable().First();

                    Ticket ticket = new Ticket();
                    ticket.UseItem = false;

                    ticket.AddHeaderLine(empresaRow["Nombre"].ToString().ToUpper());
                    ticket.AddHeaderLine(empresaRow["Juridico"].ToString());
                    ticket.AddHeaderLine("NIT " + UseObject.InsertSeparatorMilMasDigito(empresaRow["Nit"].ToString()));
                    ticket.AddHeaderLine(empresaRow["Direccion"].ToString());
                    ticket.AddHeaderLine("Tels. " + empresaRow["Telefono"].ToString());
                    ticket.AddHeaderLine("RESUMEN DE COMPRAS");
                    ticket.AddHeaderLine("Fecha : " + DateTime.Now.ToShortDateString() + "  " +
                                                      DateTime.Now.ToShortTimeString());
                    if (Convert.ToInt32(this.cbFecha.SelectedValue).Equals(1))
                    {
                        ticket.AddHeaderLine("Consulta fecha : " + this.Fecha1.ToShortDateString());
                    }
                    else
                    {
                        ticket.AddHeaderLine("Consulta periodo : " + this.Fecha1.ToShortDateString() +
                                                             " a " + this.Fecha2.ToShortDateString());
                    }
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("===================================");
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("DESCRIP.       CANT.  PROM.   TOTAL");
                    ticket.AddHeaderLine("___________________________________");
                    ticket.AddHeaderLine("");
                    foreach(DataGridViewRow gRow in this.dgvResumen.Rows)
                    {
                        string product = gRow.Cells["ProductoR"].Value.ToString();
                        if (product.Length > 30)
                        {
                            product = product.Substring(0, 30);

                        }
                        ticket.AddHeaderLine(product);
                        ticket.AddHeaderLine("              " + gRow.Cells["CantidadR"].Value.ToString() + "  "
                                                              + UseObject.InsertSeparatorMil(gRow.Cells["Promedio"].Value.ToString()) + "  " 
                                                              + UseObject.InsertSeparatorMil(gRow.Cells["ValorR"].Value.ToString()));
                    }
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("-----------------------------------");
                    ticket.AddHeaderLine("Software: Digital Fact Pyme");
                    ticket.AddHeaderLine("Soluciones Tecnológicas A&C.");
                    ticket.AddHeaderLine("solucionestecnologicasayc@gmail.com");
                    ticket.AddHeaderLine("");

                    ticket.PrintTicket("IMPREPOS");
                }
                else
                {
                    OptionPane.MessageInformation("No hay registros para imprimir.");
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }


        private void ResumenCompras()
        {
            try
            {
                this.tResumen = new DataTable();
                this.tResumen.Columns.Add(new DataColumn("Producto", typeof(string)));
                this.tResumen.Columns.Add(new DataColumn("Cantidad", typeof(double)));
                this.tResumen.Columns.Add(new DataColumn("Promedio", typeof(int)));
                this.tResumen.Columns.Add(new DataColumn("Valor", typeof(int)));
                DataTable dataResumen = new DataTable();
                int total_ = 0;
                switch (this.Iterador)
                {
                    case 0:
                        {
                            dataResumen = this.miBussinesCompraSimple.ResumenCompra(DateTime.Now);
                            total_ = this.miBussinesCompraSimple.ResumenPago(DateTime.Now);
                            break;
                        }
                    case 1:
                        {
                            dataResumen = this.miBussinesCompraSimple.ResumenCompra(this.Fecha1);
                            total_ = this.miBussinesCompraSimple.ResumenPago(this.Fecha1);
                            break;
                        }
                    case 2:
                        {
                            dataResumen = this.miBussinesCompraSimple.ResumenCompra(this.Fecha1, this.Fecha2);
                            total_ = this.miBussinesCompraSimple.ResumenPago(this.Fecha1, this.Fecha2);
                            break;
                        }
                    case 3:
                        {
                            dataResumen = this.miBussinesCompraSimple.ResumenCompra(this.CodProveedor, this.Fecha1);
                            total_ = this.miBussinesCompraSimple.ResumenPago(this.CodProveedor, this.Fecha1);
                            break;
                        }
                    case 4:
                        {
                            dataResumen = this.miBussinesCompraSimple.ResumenCompra(this.CodProveedor, this.Fecha1, this.Fecha2);
                            total_ = this.miBussinesCompraSimple.ResumenPago(this.CodProveedor, this.Fecha1, this.Fecha2);
                            break;
                        }
                }
                foreach (DataRow row in dataResumen.Rows)
                {
                    var rRow = tResumen.NewRow();
                    rRow["Producto"] = row["nombreproducto"];
                    rRow["Cantidad"] = row["cantidad"];
                    rRow["Promedio"] = Convert.ToInt32(Convert.ToInt32(row["total"]) / Convert.ToDouble(row["cantidad"]));
                    rRow["Valor"] = row["total"];
                    tResumen.Rows.Add(rRow);
                }
                this.dgvResumen.DataSource = tResumen;
                this.txtTotalResumen.Text = UseObject.InsertSeparatorMil(
                    tResumen.AsEnumerable().Sum(s => s.Field<int>("Valor")).ToString());
                this.txtEfectivo.Text = UseObject.InsertSeparatorMil(total_.ToString());
                this.txtPorCobrar.Text = UseObject.InsertSeparatorMil(
                    (tResumen.AsEnumerable().Sum(s => s.Field<int>("Valor")) - total_).ToString());
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void ResumenDescuentos()
        {
            try
            {
                DataTable dataResumen = new DataTable();
                switch (this.Iterador)
                {
                    case 0:
                        {
                            dataResumen = this.miBussinesCompraSimple.ResumenDescuentos(DateTime.Now);
                            break;
                        }
                    case 1:
                        {
                            dataResumen = this.miBussinesCompraSimple.ResumenDescuentos(this.Fecha1);
                            break;
                        }
                    case 2:
                        {
                            dataResumen = this.miBussinesCompraSimple.ResumenDescuentos(this.Fecha1, this.Fecha2);
                            break;
                        }
                    case 3:
                        {
                            dataResumen = this.miBussinesCompraSimple.ResumenDescuentos(this.CodProveedor, this.Fecha1);
                            break;
                        }
                    case 4:
                        {
                            dataResumen = this.miBussinesCompraSimple.ResumenDescuentos(this.CodProveedor, this.Fecha1, this.Fecha2);
                            break;
                        }
                }
                if (dataResumen.Rows.Count > 0)
                {
                    this.txtTotalDescuento.Text = UseObject.InsertSeparatorMil(dataResumen.AsEnumerable().Sum(s => s.Field<int>("valor")).ToString());
                }
                else
                {
                    this.txtTotalDescuento.Text = "0";
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void CalcularPaginas()
        {
            Paginas = TotalRow / RowMax;
            if (TotalRow % RowMax != 0)
                Paginas++;
            if (CurrentPage > Paginas)
                CurrentPage = 0;
            lblStatusFactura.Text = CurrentPage + " / " + Paginas;
        }

        private void ColorearTodos()
        {
            ColorearGridCompra();
            ColorearGridProducto();
            ColorearGridDescuento();
        }

        private void ColorearGridCompra()
        {
            var cont = 1;
            foreach (DataGridViewRow row in this.dgvCompras.Rows)
            {
                cont++;
                if (cont % 2 != 0)
                {
                    row.DefaultCellStyle.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
                }
            }
        }

        private void ColorearGridProducto()
        {
            var cont = 1;
            foreach (DataGridViewRow row in this.dgvProductos.Rows)
            {
                cont++;
                if (cont % 2 != 0)
                {
                    row.DefaultCellStyle.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
                }
            }
        }

        private void ColorearGridDescuento()
        {
            var cont = 1;
            foreach (DataGridViewRow row in this.dgvDescuentos.Rows)
            {
                cont++;
                if (cont % 2 != 0)
                {
                    row.DefaultCellStyle.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
                }
            }
        }


        void CompletaEventos_Completo(CompletaArgumentosDeEvento args)
        {
            try
            {
                var proveedor = (DTO.Clases.Proveedor)args.MiObjeto;
                this.CodProveedor = proveedor.CodigoInternoProveedor;
                this.txtCodigo.Text = proveedor.NitProveedor;
               // this.txtNombreProveedor.Text = proveedor.NitProveedor + "  " + proveedor.NombreProveedor;
            }
            catch { }

            try
            {
                var obj = (ObjectAbstract)args.MiObjeto;
                if (obj.Id.Equals(555666888))
                {
                    this.btnBuscar_Click(this.btnBuscar, new EventArgs());
                }
            }
            catch { }

            try
            {
                var obj = (ObjectAbstract)args.MiObjeto;
                if (obj.Id.Equals(555666889))
                {
                    this.dgvCompras_CellClick(this.dgvCompras, null);
                }
            }
            catch { }
        }

        void CompletaEventos_Completaz(CompletaArgumentosDeEventoz args)
        {
            try
            {
                this.txtCodigo.Text = ((Cliente)args.MiZona).NitCliente;
                this.txtNombreProveedor.Text = ((Cliente)args.MiZona).NitCliente + "  " + ((Cliente)args.MiZona).NombresCliente;
            }
            catch { }
        }

        private void Print(int diferencia)
        {
            try
            {
                var empresaRow = this.miBussinesEmpresa.PrintEmpresa().Tables[0].AsEnumerable().First();
                DataGridViewRow gRow = this.dgvCompras.CurrentRow;

                Ticket ticket = new Ticket();
                ticket.UseItem = false;

                ticket.AddHeaderLine(empresaRow["Nombre"].ToString().ToUpper());
                ticket.AddHeaderLine(empresaRow["Juridico"].ToString());
                ticket.AddHeaderLine("NIT " + UseObject.InsertSeparatorMilMasDigito(empresaRow["Nit"].ToString()));
                ticket.AddHeaderLine(empresaRow["Direccion"].ToString());
                ticket.AddHeaderLine("Tels. " + empresaRow["Telefono"].ToString());
                ticket.AddHeaderLine("COMPROBANTE DE AJUSTE");
                ticket.AddHeaderLine("Fecha : " + DateTime.Now.ToShortDateString());
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("===================================");
                ticket.AddHeaderLine("No. compra: " + gRow.Cells["Id"].Value.ToString());
                ticket.AddHeaderLine("Proveedor : " + gRow.Cells["Proveedor"].Value.ToString());
                ticket.AddHeaderLine("C.C.      : " + UseObject.InsertSeparatorMilMasDigito(gRow.Cells["Cedula"].Value.ToString()));
                ticket.AddHeaderLine("===================================");
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("Valor diferencia : " + diferencia);
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("-----------------------------------");
                ticket.AddHeaderLine("");
                ticket.AddHeaderLine("Software: Digital Fact Pyme");
                ticket.AddHeaderLine("Soluciones Tecnológicas A&C.");
                ticket.AddHeaderLine("solucionestecnologicasayc@gmail.com");
                ticket.AddHeaderLine("");

                ticket.PrintTicket("IMPREPOS");

            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        

    }
}